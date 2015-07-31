Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Compatibility
Imports Microsoft.VisualBasic.PowerPacks
Imports ETSCommon
Imports ETSCommon.MODULE1
Imports System.Data.SqlClient
Imports System.Configuration

Friend Class cc_dup_Dep
    Inherits System.Windows.Forms.Form
    '****************
    'revision History
    'original date of this form is 9/23/96 -SCS
    '****************

    Private Const Spaces As String = "                                " ' for  filling name etc
    Private Const zeroes As String = "00000000000000000000000000000000" ' for  filling name etc
    Public outputfilename_b As String
    Public er_num As String
    Public er_nam As String
    Public tot_rec As Integer
    Public tot_debit As Decimal
    Public tot_credit As Decimal
    Public bat_num As Integer
    Public trace_num As Integer
    Public c_entry_hash As Double
    Public f_entry_hash As Double
    Public tot_block As Double
    Public fnum As Integer = 1

    Public Sub ascii_write(ByVal kind As String)
        'written for one batch per file only
        tot_rec = 0
        tot_debit = 0
        tot_credit = 0
        bat_num = 1
        trace_num = 0
        tot_block = 0
        c_entry_hash = 0
        f_entry_hash = 0

        Select Case kind
            Case "PRE"
                outputfilename_b = "a:\prenote.dat"
                check_Date.Text = CStr(Today)
            Case "DATA"
                outputfilename_b = "a:\deposit.dat"
            Case Else
                outputfilename_b = "a:\deposit.dat"
        End Select

        fnum = FreeFile()
TryAgain:
        FileOpen(fnum, outputfilename_b, OpenMode.Output, , , 1)

        Select Case Err.Number
            Case 0
            Case 71 'disk not ready
                MsgBox(" A drive not ready. Correct the problem and press OK.")
                Err.Clear()
                GoTo TryAgain
            Case 76 'path not found
                MsgBox("Path not found. Correct the problem and press OK.")
                Err.Clear()
                GoTo TryAgain
            Case Else
                MsgBox("error = " & ErrorToString(Err.Number))
                MsgBox("Error opening the prenote file. No file created. CALL ETS.")
                Exit Sub
        End Select
        'record definition follow each line if a -o is at the end the field is optional
        'create file header record
        'bk_acct_no field has the bank transit/routing # in it
        Dim bkAcctNo As String = ""
        Dim selected_agency_name As String = ""
        Dim selected_screen_nam As String = ""
        Dim BankReas As String = ""
        Dim dt As Date = DateTime.Now

        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim rs As SqlDataReader = db.ExecuteQuery("select * from ccsys")
            While rs.Read()
                bkAcctNo = rs("bk_acct_no").ToString
                selected_screen_nam = rs("screen_nam").ToString
                selected_agency_name = rs("agency_name").ToString
                BankReas = rs("bank_reas").ToString
            End While
            rs.Close()
        End Using

        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim rs As SqlDataReader = db.ExecuteQuery("select * from etssys")
            While rs.Read()
                   selected_agency_name = rs("agency_name").ToString
            End While
            rs.Close()
        End Using

        Print(fnum, "1") 'record type
        Print(fnum, "01") 'priority; code
        Print(fnum, " " & VB.Left(bkAcctNo & Spaces, 9)) 'immed dest source bank acc#
        Print(fnum, "1" & VB.Left(er_num & Spaces, 9)) '1 + tax id #
        Print(fnum, String.Format("{0:YYMMDD}", dt)) 'VB6.Format(Today, "YYMMDD")) 'file create date
        Print(fnum, String.Format("{0: HHMM}", dt)) 'VB6.Format(Today, "YYMMDD")) 'file create date
        Print(fnum, "X") 'file modifier
        Print(fnum, "094") 'record size
        Print(fnum, "10") 'blocking size
        Print(fnum, "1") 'format code
        Print(fnum, VB.Left(selected_screen_nam & Spaces, 23)) 'immed dest name -o
        Print(fnum, VB.Left(selected_agency_name & Spaces, 23)) 'immed orign name -o
        PrintLine(fnum, Space(8)) 'reference code generally left blank

        'create company batch header
        'modified for alliance  3/14/01 lhw
        Print(fnum, "5") '1
        Print(fnum, "200") 'serv class code      2-4
        Print(fnum, VB.Left(er_nam & Spaces, 16)) 'comp name 5-20
        Print(fnum, Space(20)) 'comp extra data -o 21-40
        Print(fnum, "1" & VB.Left(er_num & Spaces, 9)) '1 + tax id # 41 - 50
        Print(fnum, "PPD") 'std entry class 51-53
        Print(fnum, VB.Left(BankReas & Spaces, 10)) 'entry desc 54 -63
        Print(fnum, Space(6)) 'blank spaces 64 - 69
        Print(fnum, String.Format("{0:yymmdd}", check_Date.Text)) 'eff date 70 - 75
        Print(fnum, Space(3)) 'settlement date (julian) inserted by ach operator
        Print(fnum, "1") 'orig status code
        Print(fnum, VB.Left(bkAcctNo & Spaces, 8)) 'orig dfi
        PrintLine(fnum, String.Format("{0:0000000}", bat_num)) 'batch num

        'now the detail records and assuming no addenda records
        Dim msg As String = ""

        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim rs As SqlDataReader = db.ExecuteQuery("select * from ccach")
            While rs.Read()
                Print(fnum, "6")
                'for prenote the code is 23 or 33
                '    Select Case ccach.Recordset.Fields("c-or-s").Value
                '        Case "c", "C"
                '            If ccach.Recordset.Fields("$amt").Value > 0 Then
                '                msg = "22"
                '            Else
                '                msg = "27"
                '            End If
                '            If kind = "PRE" Then msg = "23"
                '        Case "s", "S"
                '            If ccach.Recordset.Fields("$amt").Value > 0 Then
                '                msg = "32"
                '            Else
                '                msg = "37"
                '            End If
                '            If kind = "PRE" Then msg = "33"
                '    End Select

                '            Print(fnum, VB.Left(msg & Spaces, 2)) 'tran code
                '            Print(fnum, VB.Left(ccach.Recordset.Fields("bnkaba_num").Value & Spaces, 8)) 'reci ident
                '            Print(fnum, VB.Right(ccach.Recordset.Fields("bnkaba_num").Value, 1)) 'chk digit
                '           Print(fnum, VB.Left(ccach.Recordset.Fields("bnkacct_num").Value & Spaces, 17)) 'dfi acct num
                '            Print(fnum, VB.Right(zeroes & Int(ccach.Recordset.Fields("$amt").Value * 100), 10)) 'amt
                '            Print(fnum, VB.Left(ccach.Recordset.Fields("employ_num").Value & Spaces, 15)) 'ind ident
                '            Print(fnum, VB.Left(ccach.Recordset.Fields("screen_nam").Value & Spaces, 22)) 'ind name
                '            Print(fnum, Space(2)) 'disc data -o
                '            Print(fnum, "0") 'addenda record '79
                '            trace_num = trace_num + 1
                '            PrintLine(fnum, VB6.Format(trace_num, "000000000000000")) 'trace num
                '            'count the records
                '            tot_rec = tot_rec + 1

                '            'sum the credits
                '            'sum the debits
                '           If ccach.Recordset.Fields("$amt").Value > 0 Then
                '               tot_credit = tot_credit + ccach.Recordset.Fields("$amt").Value
                '            Else
                '                tot_debit = tot_debit + ccach.Recordset.Fields("$amt").Value
                '            End If
                '            'create the entry hash
                '            c_entry_hash = c_entry_hash + Val(VB.Left(ccach.Recordset.Fields("bnkaba_num").Value & Spaces, 8))

                '            'End If
            End While
            rs.Close()
        End Using


         f_entry_hash = f_entry_hash + c_entry_hash

        '        'company batch control

        Print(fnum, "8")
        Print(fnum, "200") 'service class code
        Print(fnum, VB6.Format(tot_rec, "000000")) 'entry count
        Print(fnum, VB.Right(zeroes & CStr(c_entry_hash), 10)) 'entry hash
        Print(fnum, VB6.Format(tot_debit * 100, "000000000000")) 'total debit
        Print(fnum, VB6.Format(tot_credit * 100, "000000000000")) 'total cred
        Print(fnum, "1" & VB.Left(er_num & Spaces, 9)) '1 + tax id # 45 -
        Print(fnum, Space(25)) 'unused 55
        Print(fnum, VB.Left(bkAcctNo & Spaces, 8)) 'orig ident
        PrintLine(fnum, VB6.Format(bat_num, "0000000")) 'batch num

        '        'now to 9 fill the block to the end
        tot_block = (tot_rec + 4) / 10 - Int((tot_rec + 4) / 10)
        If tot_block > 0 Then
            For num = 1 To CInt((10 - tot_block * 10))
                ' Print #fnum, String(94, "9")        'this is line removed for not 9 filling
            Next
        End If

        tot_block = ((tot_rec + 4) + (10 - tot_block * 10)) / 10

        '        'file control
        Print(fnum, "9")
        Print(fnum, VB6.Format(bat_num, "000000")) 'batch count
        Print(fnum, VB6.Format(tot_block, "000000")) 'block count
        Print(fnum, VB6.Format(tot_rec, "00000000")) 'entry count
        Print(fnum, VB.Right(zeroes & CStr(f_entry_hash), 10)) 'entry hash
        Print(fnum, VB6.Format(tot_debit * 100, "000000000000")) 'total debit
        Print(fnum, VB6.Format(tot_credit * 100, "000000000000")) 'total cred
        PrintLine(fnum, Space(39)) 'reserved
        FileClose(fnum)
        'Call copy_ascii(outputfilename_b)
        MsgBox("Please remove the floppy disk ")

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub dirdepach_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dirdepach.Click 'from ccach
        '        'prtDestination = CStr(0)
        '        'msg = "Date (" & Year(CDate(check_Date.Text)) & "," & Month(CDate(check_Date.Text)) & "," & VB.Day(CDate(check_Date.Text)) & ")"
        '        'prtparameterfields(0) = "paydate;" & msg & ";FALSE"
        '        'prtreportfilename = cc_report_path & "ccnetck.rpt"
        '        'Call frmcrystal_Call()
        '        'prtparameterfields(0) = ""
    End Sub

    Private Sub dirdeprpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dirdeprpt.Click 'from ccckstub
        '        'prtparameterfields(0) = ""
        '        'msg = "Date (" & Year(CDate(check_Date.Text)) & "," & Month(CDate(check_Date.Text)) & "," & VB.Day(CDate(check_Date.Text)) & ")"
        '        'prtparameterfields(0) = "check_date;" & msg & ";FALSE"
        '        'prtreportfilename = cc_report_path & "ccckdd.rpt"
        '        'Call frmcrystal_Call()
        '        'prtparameterfields(0) = ""
    End Sub

    Private Sub check_Date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles check_Date.Enter
        '        'Call ets_set_selected()
    End Sub

    Private Sub check_Date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles check_Date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            valid_Date = "N"
            Call etsdate(check_Date.ToString, valid_Date)
            If IsDate(valid_Date) Then
                check_Date.Text = valid_Date
            Else
                MsgBox("Not a Valid Date")
                ' Call ets_set_selected()
                GoTo EventExitSub
            End If
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub check_Date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles check_Date.Leave
        '        check_Date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub prenote_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prenote_date.Enter ' added 6/2/00 scs
        '        'Call ets_set_selected()
    End Sub

    Private Sub prenote_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles prenote_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar)) ' added 6/2/00 scs
        If KeyAscii = 13 Or KeyAscii = 9 Then
            valid_Date = "N"
            Call etsdate(prenote_date.ToString, valid_Date)
            If IsDate(valid_Date) Then
                prenote_date.Text = CStr(CDate(retdate))
            Else
                MsgBox("Not a Valid Date")
                Call ets_set_selected()
                GoTo EventExitSub
            End If
            prenote.Focus()
            KeyAscii = 0
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub prenote_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prenote_date.Leave ' added 6/2/00 scs
        prenote_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub prenote_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prenote.Click
        '        'move all the data to ccach with zero dollars and the rest will fall out
        '        'clear the table
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = "delete from ccach"
            db.ExecuteQuery(sql)
        End Using

        'get various agency settings from ccsys
        Dim er_num As String = ""
        Dim er_name As String = ""
         Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim rs As SqlDataReader = db.ExecuteQuery("select * from ccsys")
            While rs.Read()
                er_num = rs("er_fed_id").ToString
                er_name = rs("agency_name").ToString
               
            End While
            rs.Close()
        End Using


        '        tmpset = tmpdb.OpenRecordset("nam_cc", dao.RecordsetTypeEnum.dbOpenDynaset)
        '        ccdepsit.Refresh()

        '        Do While Not ccdepsit.Recordset.EOF

        '            'UPGRADE_ISSUE: Data property ccdepsit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            sqlstmnt = "name_key = " & Chr(34) & ccdepsit.Recordset.Fields("name_key").Value & Chr(34)
        '            tmpset.FindFirst(sqlstmnt)

        '            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        '            If tmpset.Fields("Term_date").Value > Today Or IsDBNull(tmpset.Fields("term_Date").Value) Then

        '                'UPGRADE_ISSUE: Data property glname.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                glname.Recordset.FindFirst(sqlstmnt)
        '                'prenotes only sent if the account is active per lang 2/4/00
        '                'prenotes only sent if the change date is greater than the prenote date entered scs 6/2/00
        '             
        '      ccach.Recordset.AddNew
        '                '      ccach.Recordset.Fields("name_key") = ccdepsit.Recordset.Fields("name_key")
        '                '      ccach.Recordset.Fields("screen_nam") = ccdepsit.Recordset.Fields("screen_nam")
        '                '      ccach.Recordset.Fields("er_num") = er_num
        '                '      ccach.Recordset.Fields("er_nam") = er_nam
        '                '      ccach.Recordset.Fields("employ_num") = ccdepsit.Recordset.Fields("name_key")
        '                '      'look up real first and last name
        '                '      ccach.Recordset.Fields("name") = Left$(glname.Recordset.Fields("last_name") & " " & glname.Recordset.Fields("first_name"), 22)
        '                '      ccach.Recordset.Fields("pay_date") = Date 'ccckstub.Recordset.Fields("chk_date")
        '                '      ccach.Recordset.Fields("bnkaba_num") = ccdepsit.Recordset.Fields("bk1_aba")
        '                '      ccach.Recordset.Fields("bnkacct_num") = ccdepsit.Recordset.Fields("bk1act_num")
        '                '      ccach.Recordset.Fields("c-or-s") = ccdepsit.Recordset.Fields("bk1_c-or-s")
        '                '      ccach.Recordset.Fields("$amt") = 0 'ccckstub.Recordset.Fields("save1_ded")
        '                '      ccach.Recordset.Update
        '                '      End If

        '                '       If Len(Trim(ccdepsit.Recordset.Fields("bk2act_num"))) <> 0 And tmpset.Fields("ddep2_sav2") = "Y" _
        '                ''      And ccdepsit.Recordset.Fields("bk2_chg_date") >= Cdate(prenote_date.text) Then
        '                '      ccach.Recordset.AddNew
        '                '      ccach.Recordset.Fields("name_key") = ccdepsit.Recordset.Fields("name_key")
        '                '      ccach.Recordset.Fields("screen_nam") = ccdepsit.Recordset.Fields("screen_nam")
        '                '      ccach.Recordset.Fields("er_num") = er_num
        '                '      ccach.Recordset.Fields("er_nam") = er_nam
        '                '      ccach.Recordset.Fields("employ_num") = ccdepsit.Recordset.Fields("name_key")
        '                '      'look up real first and last name
        '                '      ccach.Recordset.Fields("name") = Left$(glname.Recordset.Fields("last_name") & " " & glname.Recordset.Fields("first_name"), 22)
        '                '      ccach.Recordset.Fields("pay_date") = Date
        '                '      ccach.Recordset.Fields("bnkaba_num") = ccdepsit.Recordset.Fields("bk2_aba")
        '                '      ccach.Recordset.Fields("bnkacct_num") = ccdepsit.Recordset.Fields("bk2act_num")
        '                '      ccach.Recordset.Fields("c-or-s") = ccdepsit.Recordset.Fields("bk2_c-or-s")
        '                '      ccach.Recordset.Fields("$amt") = 0

        '                '       ccach.Recordset.Update
        '                '       End If

        '                '       If Len(Trim(ccdepsit.Recordset.Fields("bk3act_num"))) <> 0 And tmpset.Fields("ddep3_sav3") = "Y" _
        '                ''      And ccdepsit.Recordset.Fields("bk3_chg_date") >= Cdate(prenote_date.text) Then
        '                '      ccach.Recordset.AddNew
        '                '      ccach.Recordset.Fields("name_key") = ccdepsit.Recordset.Fields("name_key")
        '                '      ccach.Recordset.Fields("screen_nam") = ccdepsit.Recordset.Fields("screen_nam")
        '                '      ccach.Recordset.Fields("er_num") = er_num
        '                '      ccach.Recordset.Fields("er_nam") = er_nam
        '                '      ccach.Recordset.Fields("employ_num") = ccdepsit.Recordset.Fields("name_key")
        '                '      'look up real first and last name
        '                '       ccach.Recordset.Fields("name") = Left$(glname.Recordset.Fields("last_name") & " " & glname.Recordset.Fields("first_name"), 22)
        '                '     ccach.Recordset.Fields("pay_date") = Date
        '                '      ccach.Recordset.Fields("bnkaba_num") = ccdepsit.Recordset.Fields("bk3_aba")
        '                '      ccach.Recordset.Fields("bnkacct_num") = ccdepsit.Recordset.Fields("bk3act_num")
        '                '      ccach.Recordset.Fields("c-or-s") = ccdepsit.Recordset.Fields("bk3_c-or-s")
        '                '      ccach.Recordset.Fields("$amt") = 0

        '                '      ccach.Recordset.Update
        '                '      End If
        '                'only uses net check
        '                'UPGRADE_ISSUE: Data property ccdepsit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                If Len(Trim(ccdepsit.Recordset.Fields("bk4act_num").Value)) <> 0 And tmpset.Fields("ddep_net").Value = "Y" And ccdepsit.Recordset.Fields("bk4_chg_date").Value >= CDate(prenote_date.Text) Then
        '                    'this is bank 4
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.AddNew()
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    'UPGRADE_ISSUE: Data property ccdepsit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("name_key").Value = ccdepsit.Recordset.Fields("name_key").Value
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    'UPGRADE_ISSUE: Data property ccdepsit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("screen_nam").Value = ccdepsit.Recordset.Fields("screen_nam").Value
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("er_num").Value = er_num
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("er_nam").Value = er_nam
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    'UPGRADE_ISSUE: Data property ccdepsit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("employ_num").Value = ccdepsit.Recordset.Fields("name_key").Value
        '                    'look up real first and last name

        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    'UPGRADE_ISSUE: Data property glname.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("name").Value = VB.Left(glname.Recordset.Fields("last_name").Value & " " & glname.Recordset.Fields("first_name").Value, 22)
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("pay_date").Value = Today
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    'UPGRADE_ISSUE: Data property ccdepsit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("bnkaba_num").Value = ccdepsit.Recordset.Fields("bk4_aba").Value
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    'UPGRADE_ISSUE: Data property ccdepsit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("bnkacct_num").Value = ccdepsit.Recordset.Fields("bk4act_num").Value
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    'UPGRADE_ISSUE: Data property ccdepsit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("c-or-s").Value = ccdepsit.Recordset.Fields("bk4_c-or-s").Value
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("$amt").Value = 0

        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Update()
        '                End If
        '            End If
        '            'UPGRADE_ISSUE: Data property ccdepsit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            ccdepsit.Recordset.MoveNext()
        '        Loop
        '        'we now write out the ascii file
        '        On Error Resume Next
        '        'UPGRADE_ISSUE: Data property ccach.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        ccach.RecordSource = "select * from ccach order by name_key"
        '        ccach.Refresh()
        '        'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        ccach.Recordset.MoveFirst()
        '        If Err.Number = 3021 Then
        '            MsgBox("There are no changes in the direct deposit file after the chosen date.")
        '        Else
        '            'each customers file could be different...watch out
        '            MsgBox("This is Alliance Format..Customize and remove this message!!")
        '            Call ascii_write("PRE")
        '            MsgBox("The Pre-Note File has been created on drive A.")
        '        End If
        '        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub prenote_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prenote_rpt.Click
        '        'prtDestination = CStr(0)
        '        'prtparameterfields(0) = ""
        '        ''msg = "Date (" & Year(rpthead.Fields("Check_date")) & "," & Month(rpthead.Fields("Check_date")) & "," & Day(rpthead.Fields("Check_date")) & ")"
        '        ''prtParameterFields(0) = "CkDate;" & msg & ";FALSE"
        '        'prtreportfilename = cc_report_path & "ccprenote.rpt"
        '        'Call frmcrystal_Call()
    End Sub

    Private Sub Process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Click
        '        ' xxnow we create ACH transfers
        '        'clear the table
        '        'output file approved 4/6/01 lhw
        '        ccach.Refresh()
        '        'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        ccach.Recordset.MoveFirst()
        '        If Err.Number <> 3021 Then
        '            'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            Do While Not ccach.Recordset.EOF
        '                'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                ccach.Recordset.Delete()
        '                'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                ccach.Recordset.MoveNext()
        '            Loop
        '        End If

        '        db = cc_data_path & "cc.mdb"
        '        tmpdb = DAODBEngine_definst.OpenDatabase(db)
        '        tmpset = tmpdb.OpenRecordset("cc_deposit", dao.RecordsetTypeEnum.dbOpenDynaset)
        '        On Error GoTo 0
        '        db = cc_data_path & "cc.mdb"
        '        tmp1db = DAODBEngine_definst.OpenDatabase(db)
        '        tmp1set = tmp1db.OpenRecordset("ccsys", dao.RecordsetTypeEnum.dbOpenDynaset)
        '        tmp1set.MoveFirst()


        '        er_num = tmp1set.Fields("er_fed_id").Value
        '        er_nam = tmp1set.Fields("agency_name").Value
        '        'added void = 'N' 4/12/01 lhw
        '        'UPGRADE_ISSUE: Data property ccckstub.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        ccckstub.RecordSource = "select * from ccckstub where void = 'N' and chk_date = #" & check_Date.Text & "#"

        '        ccckstub.Refresh()
        '        'added 3-14-01 lhw
        '        On Error Resume Next
        '        'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        ccckstub.Recordset.MoveFirst()
        '        If Err.Number = 3021 Then
        '            MsgBox("The date entered in not correct.")
        '            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '            check_Date.Focus()
        '            Exit Sub
        '        End If
        '        On Error GoTo 0

        '        'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        Do While Not ccckstub.Recordset.EOF
        '            'check all the deposit flags if none next
        '            'fileds not in client payroll
        '            'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            If ccckstub.Recordset.Fields("chk_dirdep").Value = "Y" Then 'Or ccckstub.Recordset.Fields("ddep_sav1") = "Y" Or ccckstub.Recordset.Fields("ddep_sav2") = "Y" Or ccckstub.Recordset.Fields("ddep_sav3") = "Y" Then
        '                'look up the deposit table once for each person
        '                'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                sqlstmnt = "name_key = " & Chr(34) & ccckstub.Recordset.Fields("name_key").Value & Chr(34)
        '                tmpset.FindFirst(sqlstmnt)

        '                'UPGRADE_ISSUE: Data property glname.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                glname.Recordset.FindFirst(sqlstmnt)

        '                ' If ccckstub.Recordset.Fields("ddep_sav1") = "Y" And Len(Trim(tmpset.Fields("bk1act_num"))) <> 0 Then
        '                ' ccach.Recordset.AddNew
        '                ' ccach.Recordset.Fields("name_key") = ccckstub.Recordset.Fields("name_key")
        '                ' ccach.Recordset.Fields("screen_nam") = ccckstub.Recordset.Fields("screen_nam")
        '                ' ccach.Recordset.Fields("er_num") = er_num
        '                ' ccach.Recordset.Fields("er_nam") = er_nam
        '                ' ccach.Recordset.Fields("employ_num") = ccckstub.Recordset.Fields("name_key")
        '                ' 'look up real first and last name
        '                ' ccach.Recordset.Fields("name") = Left$(glname.Recordset.Fields("last_name") & " " & glname.Recordset.Fields("first_name"), 22)
        '                ' ccach.Recordset.Fields("pay_date") = ccckstub.Recordset.Fields("chk_date")
        '                ' ccach.Recordset.Fields("bnkaba_num") = tmpset.Fields("bk1_aba")
        '                ' ccach.Recordset.Fields("bnkacct_num") = tmpset.Fields("bk1act_num")
        '                ' ccach.Recordset.Fields("c-or-s") = tmpset.Fields("bk1_c-or-s")
        '                ' ccach.Recordset.Fields("$amt") = ccckstub.Recordset.Fields("save1_ded")
        '                ' ccach.Recordset.Update
        '                ' End If

        '                '  If ccckstub.Recordset.Fields("ddep_sav2") = "Y" And Len(Trim(tmpset.Fields("bk2act_num"))) <> 0 Then
        '                ' ccach.Recordset.AddNew
        '                ' ccach.Recordset.Fields("name_key") = ccckstub.Recordset.Fields("name_key")
        '                ' ccach.Recordset.Fields("screen_nam") = ccckstub.Recordset.Fields("screen_nam")
        '                ' ccach.Recordset.Fields("er_num") = er_num
        '                ' ccach.Recordset.Fields("er_nam") = er_nam
        '                ' ccach.Recordset.Fields("employ_num") = ccckstub.Recordset.Fields("name_key")
        '                ' 'look up real first and last name
        '                ' ccach.Recordset.Fields("name") = Left$(glname.Recordset.Fields("last_name") & " " & glname.Recordset.Fields("first_name"), 22)
        '                ' ccach.Recordset.Fields("pay_date") = ccckstub.Recordset.Fields("chk_date")
        '                ''ccach.Recordset.Fields("bnkaba_num") = tmpset.Fields("bk2_aba")
        '                ' ccach.Recordset.Fields("bnkacct_num") = tmpset.Fields("bk2act_num")
        '                ' ccach.Recordset.Fields("c-or-s") = tmpset.Fields("bk2_c-or-s")
        '                ' ccach.Recordset.Fields("$amt") = ccckstub.Recordset.Fields("save2_ded")
        '                '
        '                ' ccach.Recordset.Update
        '                ' End If

        '                '  If ccckstub.Recordset.Fields("ddep_sav3") = "Y" And Len(Trim(tmpset.Fields("bk3act_num"))) <> 0 Then
        '                ' ccach.Recordset.AddNew
        '                ' ccach.Recordset.Fields("name_key") = ccckstub.Recordset.Fields("name_key")
        '                ' ccach.Recordset.Fields("screen_nam") = ccckstub.Recordset.Fields("screen_nam")
        '                ' ccach.Recordset.Fields("er_num") = er_num
        '                ' ccach.Recordset.Fields("er_nam") = er_nam
        '                ' ccach.Recordset.Fields("employ_num") = ccckstub.Recordset.Fields("name_key")
        '                ' 'look up real first and last name
        '                '  ccach.Recordset.Fields("name") = Left$(glname.Recordset.Fields("last_name") & " " & glname.Recordset.Fields("first_name"), 22)
        '                '  ccach.Recordset.Fields("pay_date") = ccckstub.Recordset.Fields("chk_date")
        '                ' ccach.Recordset.Fields("bnkaba_num") = tmpset.Fields("bk3_aba")
        '                ' ccach.Recordset.Fields("bnkacct_num") = tmpset.Fields("bk3act_num")
        '                ' ccach.Recordset.Fields("c-or-s") = tmpset.Fields("bk3_c-or-s")
        '                ' ccach.Recordset.Fields("$amt") = ccckstub.Recordset.Fields("save3_ded")

        '                ' ccach.Recordset.Update
        '                ' End If

        '                'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                If ccckstub.Recordset.Fields("chk_dirdep").Value = "Y" And Len(Trim(tmpset.Fields("bk4act_num").Value)) <> 0 Then
        '                    'this is for net check
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.AddNew()
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("name_key").Value = ccckstub.Recordset.Fields("name_key").Value
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("screen_nam").Value = ccckstub.Recordset.Fields("screen_nam").Value
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("er_num").Value = er_num
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("er_nam").Value = er_nam
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("employ_num").Value = ccckstub.Recordset.Fields("name_key").Value
        '                    'look up real first and last name

        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    'UPGRADE_ISSUE: Data property glname.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("name").Value = VB.Left(glname.Recordset.Fields("last_name").Value & " " & glname.Recordset.Fields("first_name").Value, 22)
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("pay_date").Value = ccckstub.Recordset.Fields("chk_date").Value
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("bnkaba_num").Value = tmpset.Fields("bk4_aba").Value
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("bnkacct_num").Value = tmpset.Fields("bk4act_num").Value
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("c-or-s").Value = tmpset.Fields("bk4_c-or-s").Value
        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Fields("$amt").Value = ccckstub.Recordset.Fields("net_pay").Value

        '                    'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccach.Recordset.Update()
        '                End If
        '            End If 'this is for checking deposit flags

        'nextname:
        '            'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            ccckstub.Recordset.MoveNext()
        '        Loop
        '        'we now write out the ascii file
        '        On Error Resume Next
        '        'UPGRADE_ISSUE: Data property ccach.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        ccach.RecordSource = "select * from ccach order by name_key"
        '        ccach.Refresh()
        '        'UPGRADE_ISSUE: Data property ccach.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        ccach.Recordset.MoveFirst()
        '        Dim ach_amt As Decimal
        '        If Err.Number = 3021 Then
        '            MsgBox("There are no Direct Deposits(ACH transfers) for this payroll.")
        '        Else
        'TryAgain:
        '            Call ascii_write("DATA")
        '            MsgBox("The Direct Deposit File has been created on drive A.")
        '        End If
        '        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

End Class