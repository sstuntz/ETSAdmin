Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Compatibility
Imports Microsoft.VisualBasic.PowerPacks
Imports ps.common
Imports ETS.Common.Module1
Imports System.Data.SqlClient
Imports System.Configuration

Public Class DirectDeposit
    Inherits System.Windows.Forms.Form

    Private Const Spaces As String = "                                " ' for  filling name etc
    Private Const zeroes As String = "00000000000000000000000000000000" ' for  filling name etc
    Public OutputFile As String
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
    Public Chk_Date As Date
    Public fed_id_num As String
    Public vamt As Decimal
    Public vkey As String
    Public seq As Integer
    Public xlen As Integer
    Public ACH_date As String
    Public amt As String
    Public bkAcctNo As String = ""
    Public selected_agency_name As String = ""
    Public selected_screen_nam As String = ""
    Public BankReas As String = ""
    Public dt As Date = DateTime.Now
    Public DestBankKey As String
    Public OrigBankKey As String
    Public DestBankABA As String
    Public OrigBankABA As String
    Public DestBankName As String
    Public OrigBankName As String
    Public OrigBankACCT As String
    Public XferType As String
    Public CCABA As String  '- receipients bank
    Public CCACCT As String '  receiptients acct nu
    Public CCCorS As String  ' checking or savings
    Public NetPay As Decimal


    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub DirectDeposit_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'set up title and stuff based on package type
        Me.CenterToScreen()
        'get the default bank accounts

        Select Case package_Type
            Case "AP"
                Me.Text = "Create Accounts Payable Direct Deposit Files."
                DestBankKey = ConfigurationManager.AppSettings("DefaultAPACHTo")
                OrigBankKey = ConfigurationManager.AppSettings("DefaultAPACHFrom")
            Case "CC"
                Me.Text = "Create Consumer Direct Deposit Files - Net ck only."
                DestBankKey = ConfigurationManager.AppSettings("DefaultCCACHTo")
                OrigBankKey = ConfigurationManager.AppSettings("DefaultCCACHFrom")
            Case "EE"
                Me.Text = "Create Staff Payroll Direct Deposit Files."
                DestBankKey = ConfigurationManager.AppSettings("DefaultEEACHTo")
                OrigBankKey = ConfigurationManager.AppSettings("DefaultEEACHFrom")
        End Select

        Dim BankList As New List(Of nam_bankData)
        BankList = ETSSQL.GetBankData("select * from nam_bank order by bank_key")
        For Each bank In BankList
            ComboBox1.Items.Add(bank.BankKey & " - " & bank.SortName)
            ComboBox2.Items.Add(bank.BankKey & " - " & bank.SortName)
        Next

        'where you choose what bank to transfer the funds from
        'fill drop down box by creating a list of bank name key and then screen name
        'get preferred from app config based on pkd type
        'set the default bank
        For num As Integer = 0 To ComboBox1.Items.Count - 1
            If Microsoft.VisualBasic.Left(ComboBox1.Items.Item(num).ToString, 4) = DestBankKey Then
                ComboBox1.SelectedIndex = num
            End If
            If Microsoft.VisualBasic.Left(ComboBox2.Items.Item(num).ToString, 4) = OrigBankKey Then
                ComboBox2.SelectedIndex = num
            End If
        Next

    End Sub

    Public Sub CreateOutputFile(ByVal xfertype As String)

        Dim DefExt As String

        If IsNothing(ConfigurationManager.AppSettings("DefaultACHEXT")) Then
            DefExt = ".txt"
        Else
            DefExt = ConfigurationManager.AppSettings("DefaultACHEXT")
        End If

        OutputFile = "C:\Program Files (x86)\Economised Time Services\FilesToGo\"

        Select Case xfertype
            Case "PRE"
                OutputFile = OutputFile & package_Type & "prenote" & ACH_date & DefExt
                check_Date.Text = DateAdd(DateInterval.Day, 2, Today).ToShortDateString
            Case "PAY"
                OutputFile = OutputFile & package_Type & "ACH" & ACH_date & DefExt
            Case Else
                MsgBox("Call ETS if you get this message.")
                OutputFile = OutputFile & package_Type & "bad" & ACH_date & DefExt
        End Select

        fnum = FreeFile()
        FileOpen(fnum, OutputFile, OpenMode.Output, , , 1)

        If Err.Number <> 0 Then
            MsgBox("error = " & ErrorToString(Err.Number))
            MsgBox("Error opening the ACH file. No file created. CALL ETS.")
            FileClose(fnum)
        End If

    End Sub

    Public Sub GetVariousNames()
        DestBankABA = ETSCommon.GetDatum("nam_bank", "bank_key", DestBankKey, "bk_transit")
        OrigBankABA = ETSCommon.GetDatum("nam_bank", "bank_key", OrigBankKey, "bk_transit")
        DestBankName = UCase(ETSCommon.GetDatum("nam_bank", "bank_key", DestBankKey, "sort_name"))
        OrigBankName = UCase(ETSCommon.GetDatum("nam_bank", "bank_key", OrigBankKey, "sort_name"))
        OrigBankACCT = UCase(ETSCommon.GetDatum("nam_bank", "bank_key", OrigBankKey, "bk_acct_no"))
        Dim ThisAgency As New AgencyData
        ThisAgency = ETSSQL.GetAgencyData("select * from etssys")

        'get various agency settings from ccsys
        Dim er_num As String = ""
        Dim er_name As String = ""
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery("select * from ccsys")
            While rs.Read()
                er_num = rs("er_fed_id").ToString
                er_name = rs("agency_name").ToString
            End While
            rs.Close()
        End Using

        fed_id_num = er_num

    End Sub

    Private Sub prenote_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prenote.Click
        XferType = "PRE"
        GetVariousNames()
        CreateOutputFile(XferType)

        Select Case package_Type
            Case "AP"
                sqlstmnt = "select ap"
                CreatePrenoteFile()
            Case "CC"
                sqlstmnt = "select * from ACHXferAccts left join nam_cc on achxferaccts.name_key = nam_cc.name_key where bk4_chg_date > '" & prenote_date.Text & "' and pkgtype = 'CC' "  'and nam_cc.term_date > '1/1/2001'
                CreatePrenoteFile()
            Case "EE"
                'need to check all the banks.
                sqlstmnt = "select * from ACHXferAccts left join nam_ee on achxferaccts.name_key = nam_ee.name_key where bk4_chg_date > '" & prenote_date.Text & "' and pkgtype = 'EE' "  'and nam_cc.term_date > '1/1/2001'
                CreatePrenoteFile()
        End Select

    End Sub

    Private Sub Process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Click

        If DestBankKey.Length = 0 Or OrigBankKey.Length = 0 Then
            MsgBox("You must enter both a TO and FROM bank names.")
            Exit Sub
        End If
        XferType = "PAY"
        CreateOutputFile(XferType)
        GetVariousNames()

        Select Case package_Type
            Case "AP"
                sqlstmnt = "select ap"
                CreatePayFile()
            Case "CC"
                sqlstmnt = "select cc"
                CreatePayFile()
            Case "EE"
                sqlstmnt = "select ee"
                CreatePayFile()
        End Select

    End Sub

    Public Sub CreatePrenoteFile()

        tot_rec = 0
        tot_debit = 0
        tot_credit = 0
        bat_num = 1
        trace_num = 0
        tot_block = 0
        c_entry_hash = 0
        f_entry_hash = 0

        Write_ACH1()
        Write_ACH5()

        sqlstmnt = "select * from ACHXferAccts left join nam_cc on achxferaccts.name_key = nam_cc.name_key where bk4_chg_date > '" & prenote_date.Text & "' and pkgtype = 'CC' "  'and nam_cc.term_date > '1/1/2001'
        'msg string - code 23 or 33 etc
        'addenda string- number of records  for prenote none
        'amt decimal - $
        'aba string - who gets
        'acct string - their acct
        'trace string- number

        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                CCCorS = rs("bk4_c-or-s").ToString
                selected_name_key = rs("name_key").ToString
                selected_screen_nam = ETSCommon.GetDatum("nam_addr", "name_key", selected_name_key, "screen_nam")
                CCABA = rs("bk4_aba").ToString
                If CCABA.Length = 0 Then GoTo nobankacctinfo
                CCACCT = rs("bk4act_num").ToString
                'for prenote the code is 23 or 33
                Select Case CCCorS
                    Case "c", "C"
                       msg = "23"
                    Case "s", "S"
                        msg = "33"
                    Case Else
                        msg = "23"
                End Select
                'need selected name key and selected screen name
                'need amt and addenda for payments
                trace_num = trace_num + 1
                Write_ACH6(msg, CStr(0), 0, CCABA, CCACCT, CStr(trace_num))

                'count the records
                tot_rec = tot_rec + 1

                'sum the credits = 
                'sum the debits = 0

                tot_credit = tot_credit
                tot_debit = tot_debit

                'create the entry hash
                c_entry_hash = c_entry_hash + Val(VB.Left(CCABA & Spaces, 8))
nobankacctinfo:
            End While
            rs.Close()
        End Using

        f_entry_hash = f_entry_hash + c_entry_hash

        Write_ACH8()
        Write_ACH9()
        MsgBox("Direct Deposit Prenote File Created in " & Chr(10) & " C:\Program Files (x86)\Economised Time Services\FilesToGo")
        Me.Dispose()

    End Sub

    Private Sub CreatePayFile()

        tot_rec = 0
        tot_debit = 0
        tot_credit = 0
        bat_num = 1
        trace_num = 0
        tot_block = 0
        c_entry_hash = 0
        f_entry_hash = 0

        Write_ACH1()
        Write_ACH5()
        sqlstmnt = "select ccckstub.*, achxferaccts.*, first_name, nam_addr.last_name from ccckstub inner join achxferaccts on ccckstub.name_key = achxferaccts.name_key join nam_addr on achxferaccts.name_key = nam_addr.name_key where ccckstub.chk_date = '" & check_Date.Text & "' and ccckstub.void = 'N' and ccckstub.chk_dirdep = 'Y' and ccckstub.chk_dirdep = 'Y' "
       
       '    '                    ccach.Recordset.Fields("name_key").Value = ccckstub.Recordset.Fields("name_key").Value
        '    '                    ccach.Recordset.Fields("screen_nam").Value = ccckstub.Recordset.Fields("screen_nam").Value
        '    '                    ccach.Recordset.Fields("er_num").Value = er_num
        '    '                    ccach.Recordset.Fields("er_nam").Value = er_nam
        '    '                    ccach.Recordset.Fields("employ_num").Value = ccckstub.Recordset.Fields("name_key").Value
        '    '                    'look up real first and last name
        '    '                    ccach.Recordset.Fields("name").Value = VB.Left(glname.Recordset.Fields("last_name").Value & " " & glname.Recordset.Fields("first_name").Value, 22)
        '    '                    ccach.Recordset.Fields("pay_date").Value = ccckstub.Recordset.Fields("chk_date").Value
        '    '                    ccach.Recordset.Fields("bnkaba_num").Value = tmpset.Fields("bk4_aba").Value
        '    '                    ccach.Recordset.Fields("bnkacct_num").Value = tmpset.Fields("bk4act_num").Value
        '    '                    ccach.Recordset.Fields("c-or-s").Value = tmpset.Fields("bk4_c-or-s").Value
        '    '                    ccach.Recordset.Fields("$amt").Value = ccckstub.Recordset.Fields("net_pay").Value
        '    '                    ccach.Recordset.Update()

        'msg string - code 22 or 37 etc
        'addenda string- number of records  for payroll none
        'amt decimal - $
        'aba string - who gets
        'acct string - their acct
        'trace string- number

        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                CCCorS = rs("bk4_c-or-s").ToString
                selected_name_key = rs("name_key").ToString
                selected_screen_nam = ETSCommon.GetDatum("nam_addr", "name_key", selected_name_key, "screen_nam")
                CCABA = rs("bk4_aba").ToString
                If CCABA.Length = 0 Then GoTo nobankacctinfo1
                CCACCT = rs("bk4act_num").ToString
                NetPay = CDec(rs("net_pay").ToString)
                If NetPay = 0 Then
                    GoTo nobankacctinfo1
                End If

                Select Case CCCorS
                    Case "c", "C"
                        If NetPay > 0 Then
                            msg = "22"
                        Else
                            msg = "27"
                        End If
                    Case "s", "S"
                        If NetPay > 0 Then
                            msg = "32"
                        Else
                            msg = "37"
                        End If
                End Select

                'need selected name key and selected screen name
                ' addenda for payments
                trace_num = trace_num + 1
                Write_ACH6(msg, CStr(0), NetPay, CCABA, CCACCT, CStr(trace_num))

                'count the records
                tot_rec = tot_rec + 1

                If NetPay > 0 Then
                    tot_credit = tot_credit + Int(NetPay * 100) / 100
                Else
                    tot_debit = tot_debit + Int(NetPay * 100) / 100
                End If

                'create the entry hash
                c_entry_hash = c_entry_hash + Val(VB.Left(CCABA & Spaces, 8))
nobankacctinfo1:
            End While
            rs.Close()
        End Using

        f_entry_hash = f_entry_hash + c_entry_hash      ' equal at this point

        'now the balancing record
        msg = "27"
        NetPay = tot_credit

        trace_num = trace_num + 1
        selected_name_key = ""
        selected_screen_nam = OrigBankName
        Write_ACH6(msg, CStr(0), NetPay, OrigBankABA, OrigBankACCT, CStr(trace_num))
        'count the records
        tot_rec = tot_rec + 1
        tot_debit = tot_credit

        'create the entry hash
        c_entry_hash = c_entry_hash + Val(VB.Left(OrigBankABA & Spaces, 8))

        f_entry_hash = f_entry_hash + Val(VB.Left(OrigBankABA & Spaces, 8))

        selected_name_key = ""
        selected_screen_nam = ""
        selected_sort_name = ""

        Write_ACH8()
        Write_ACH9()

        MsgBox("Direct Deposit File Created in " & Chr(10) & " C:\Program Files (x86)\Economised Time Services\FilesToGo")
        Me.Dispose()

    End Sub

   

    Public Sub Write_ACH1()

        'Print #fnum, "1";    'record type
        'Print #fnum, "01";   'priority; code
        'Print #fnum, " " & Left(selected_bank_aba_num & spaces, 9); 'immed dest source bank acc#
        'Print #fnum, " " & Left(fed_id_num & spaces, 9);  'tax id of agency
        'Print #fnum, Format(Date + 1, "yyMMdd"); 'file create date plus one for bank needs
        'Print #fnum, Format(Time, "HHMM"); 'file create time -o4
        'Print #fnum, "X";  'file modifier
        'Print #fnum, "094";  'record size
        'Print #fnum, "10";   'blocking size
        'Print #fnum, "1";    'format code
        'Print #fnum, Left(bank_screen_nam & spaces, 23);   'immed dest name  bank
        'Print #fnum, Left(agency_name & spaces, 23);   'immed orign name -o
        'Print #fnum, Space(8)  'reference code generally left blank

        Print(fnum, "1") 'record type
        Print(fnum, "01") 'priority; code
        Print(fnum, " " & VB.Left(DestBankABA & Spaces, 9)) 'immed dest source bank acc#
        Print(fnum, " " & VB.Left(OrigBankABA & Spaces, 9)) '1 + tax id # or not
        Print(fnum, VB.Format(Today, "yyMMdd")) 'VB6.Format(Today, "yyMMdd")) 'file create date
        Print(fnum, VB.Format(Now, "HHMM")) 'file create date
        Print(fnum, "X") 'file modifier
        Print(fnum, "094") 'record size
        Print(fnum, "10") 'blocking size
        Print(fnum, "1") 'format code
        Print(fnum, VB.Left(DestBankName & Spaces, 23)) 'immed dest name -o
        Print(fnum, VB.Left(OrigBankName & Spaces, 23)) 'immed orign name -o
        PrintLine(fnum, Space(8)) 'reference code generally left blank

    End Sub
    Public Sub Write_ACH5()

        'create company batch header
        'Print #fnum, "5";                           '1
        'Print #fnum, "200";   'serv class code      2-4
        'Print #fnum, Left(agency_name & spaces, 16);    'comp name 5-20
        'Print #fnum, Space(20);      'comp extra data -o 21-40
        'Print #fnum, "1" & Left(fed_id_num & spaces, 9); '1 + tax id # 41 - 50
        'Print #fnum, "PPD";          'std entry class 51-53
        'Print #fnum, Left(package_Type, 2) & " ACHPMNT"; 'entry desc 54 -63"
        'Print #fnum, Space(6);     'blank spaces 64 - 69
        'Print #fnum, Format(check_Date, "yyMMdd"); 'eff date 70 - 75
        'Print #fnum, Space(3); 'settlement date (julian) inserted by ach operator
        'Print #fnum, "1";        'orig status code
        'Print #fnum, Left(selected_bank_aba_num & spaces, 8);  'orig dfi
        'Print #fnum, Format(bat_num, "0000000")         'batch num

        Print(fnum, "5")                           '1
        Print(fnum, "200")   'serv class code      2-4
        Print(fnum, VB.Left(agency_name & Spaces, 16))    'comp name 5-20
        Print(fnum, Space(20))      'comp extra data -o 21-40
        Print(fnum, "1" & VB.Left(fed_id_num & Spaces, 9)) '1 + tax id ( 41 - 50
        Print(fnum, "PPD")          'std entry class 51-53
        Print(fnum, VB.Left(package_Type, 2) & "ACHPMNT ") 'entry desc 54 -63"
        Print(fnum, Space(6))     'blank spaces 64 - 69
        Print(fnum, VB.Format(CDate(check_Date.Text), "yyMMdd")) 'eff date 70 - 75
        Print(fnum, Space(3)) 'settlement date (julian) inserted by ach operator
        Print(fnum, "1")        'orig status code
        Print(fnum, VB.Left(OrigBankABA & Spaces, 8))  'orig dfi
        Print(fnum, VB.Format(bat_num, "0000000"))         'batch num
        PrintLine(fnum)

    End Sub
    Public Sub Write_ACH6(msg As String, addenda As String, amt As Decimal, aba As String, acct As String, trace_num As String)

        'Print #fnum, "6";               'in Ach book this is a CCD format
        'Print #fnum, Left(msg & spaces, 2); 'tran code      'destination bank
        'Print #fnum, Left(aba & spaces, 8);   'reci ident
        'Print #fnum, Right(aba, 1);      'chk digit
        'Print #fnum, Left(acct & spaces, 17); 'dfi acct num
        'Print #fnum, Right(zeroes & amt, 10); 'amt
        'Print #fnum, Left(selected_name_key & spaces, 15);    'ind ident
        'Print #fnum, Left(selected_screen_nam & spaces, 22);      'ind name
        'Print #fnum, Space(2);        'disc data -o
        'Print #fnum, Right(zeroes & addenda, 1);    'number of addenda record '79
        'Print #fnum, Left(selected_bank_aba_num & spaces, 8);
        'Print #fnum, Format(trace_num, "0000000")   'trace num

        Print(fnum, "6")               'in Ach book this is a CCD format
        Print(fnum, VB.Left(msg & Spaces, 2)) 'tran code     
        Print(fnum, VB.Left(aba & Spaces, 8))   'reci ident
        Print(fnum, VB.Right(aba, 1))      'chk digit
        Print(fnum, VB.Left(acct & Spaces, 17)) 'dfi acct num
        Print(fnum, VB.Right(zeroes & Int(amt * 100), 10)) 'amt
        Print(fnum, VB.Left(selected_name_key & Spaces, 15))    'ind ident
        Print(fnum, VB.Left(selected_screen_nam & Spaces, 22))      'ind name
        Print(fnum, Space(2))        'disc data -o
        Print(fnum, VB.Right(zeroes & addenda, 1))    'number of addenda record '79
        Print(fnum, VB.Left(OrigBankABA & Spaces, 8))
        Print(fnum, VB.Right(zeroes & trace_num, 7))  'trace num
        PrintLine(fnum)
        '                '            PrintLine(fnum, VB6.Format(trace_num, "000000000000000")) 'trace num

    End Sub
    Public Sub Write_ACH7(vch As String, amt As String, trace_num As String)

        '7 records are addenda with voucher# and amount only one per payment - never combine vouchers on one payment
        'Print #fnum, "7";
        'Print #fnum, "05";
        'Print #fnum, Left(vch & spaces, 30);
        'Print #fnum, Left(amt & spaces, 30);
        'Print #fnum, Space(20);
        'Print #fnum, "0001";
        'Print #fnum, Format(trace_num, "0000000")   'trace num

        Print(fnum, "7")
        Print(fnum, "05")
        Print(fnum, VB.Left(vch & Spaces, 30))
        Print(fnum, VB.Left(amt & Spaces, 30))
        Print(fnum, Space(20))
        Print(fnum, "0001")
        Print(fnum, VB.Format(trace_num, "0000000"))   'trace num
        PrintLine(fnum)

    End Sub
    Public Sub Write_ACH8()

        'company batch control
        'modified 9-13-01 for banknorth group lhw
        'only filling total credit, put tax# in rec2 line 4 03/08/2011 lhw
        'Print #fnum, "8";
        'Print #fnum, "200";                'service class code
        'Print #fnum, Format(tot_rec, "000000");                'entry count
        'Print #fnum, Right(zeroes & CStr(c_entry_hash), 10);    'entry hash
        'Print #fnum, Format(tot_debit * 100, "000000000000");      'total debit
        'Print #fnum, Format(tot_credit * 100, "000000000000");       'total cred
        'Print #fnum, "1" & Left(fed_id_num & spaces, 9); '1 + tax id # 45 - 54
        'Print #fnum, Space(25);    'unused 55
        'Print #fnum, Left(selected_bank_aba_num & spaces, 8);      'orig ident
        'Print #fnum, Format(bat_num, "0000000")                           'batch num

        Print(fnum, "8")
        Print(fnum, "200")                'service class code
        Print(fnum, VB.Format(tot_rec, "000000"))                'entry count
        Print(fnum, VB.Right(zeroes & CStr(c_entry_hash), 10))    'entry hash
        Print(fnum, VB.Format(tot_debit * 100, "000000000000"))      'total debit
        Print(fnum, VB.Format(tot_credit * 100, "000000000000"))       'total cred
        Print(fnum, "1" & VB.Left(fed_id_num & Spaces, 9)) '1 + tax id ( 45 - 54
        Print(fnum, Space(25))    'unused 55
        Print(fnum, VB.Left(OrigBankABA & Spaces, 8))      'orig ident
        Print(fnum, VB.Format(bat_num, "0000000"))                          'batch num
        PrintLine(fnum)

    End Sub
    Public Sub Write_ACH9()

        'now to 9 fill the block to the end
        'first we have to see if there is a partial block
        'and if so add 1 to the block count
        'then we print the 9 record (file control record)
        'then we print the 99999 to fill in the block
        'code modified 3/25/02 to take care of adding the 9's block to the count and fix rounding


        Dim block_Remainder As Double

        'add four to the tot_Rec for the control records
        block_Remainder = (tot_rec + 4) / 10 - Int((tot_rec + 4) / 10)

        If block_Remainder > 0.0001 Then

            tot_block = Int((tot_rec + 4) / 10) + 1       'scs 3/4/02
        Else

            tot_block = Int((tot_rec + 4) / 10)        'scs 3/4/02

        End If
        'file control
        Print(fnum, "9")
        Print(fnum, VB.Format(bat_num, "000000"))     'batch count
        Print(fnum, VB.Format(tot_block, "000000")) 'block count
        Print(fnum, VB.Format(tot_rec, "00000000"))     'entry count
        Print(fnum, VB.Right(zeroes & CStr(f_entry_hash), 10))  'entry hash
        Print(fnum, VB.Format(tot_debit * 100, "000000000000"))      'total debit
        Print(fnum, VB.Format(tot_credit * 100, "000000000000"))       'total cred
        Print(fnum, Space(39))                'reserved

        PrintLine(fnum)

        tot_block = (tot_rec + 4) / 10 - Int((tot_rec + 4) / 10)       'this is remaider needed for 9 filling

        'If tot_block > 0 Then
        '    For num = 1 To (10 - tot_block * 10)
        '        Print #fnum, String(94, "9")        'this  line removed for not 9 filling
        '    Next
        'End If

        FileClose(fnum)

    End Sub

    'XXXXXXXXXXXXXreports
    Private Sub dirdepach_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dirdepach.Click 'from ccach
        prtDestination = 0
        msg = "Date (" & Year(CDate(check_Date.Text)) & "," & Month(CDate(check_Date.Text)) & "," & VB.Day(CDate(check_Date.Text)) & ")"
        prtParameterFields(0) = "paydate;" & msg & ";FALSE"
        prtreportfilename = cc_report_path & "ccnetck.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
    End Sub

    Private Sub dirdeprpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dirdeprpt.Click 'from ccckstub
        prtParameterFields(0) = ""
        msg = "Date (" & Year(CDate(check_Date.Text)) & "," & Month(CDate(check_Date.Text)) & "," & VB.Day(CDate(check_Date.Text)) & ")"
        prtParameterFields(0) = "check_date;" & msg & ";FALSE"
        prtreportfilename = cc_report_path & "ccckdd.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
    End Sub

    Private Sub prenote_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prenote_rpt.Click
        prtDestination = 0
        prtParameterFields(0) = ""
        'msg = "Date (" & Year(rpthead.Fields("Check_date")) & "," & Month(rpthead.Fields("Check_date")) & "," & Day(rpthead.Fields("Check_date")) & ")"
        'prtParameterFields(0) = "CkDate;" & msg & ";FALSE"
        prtreportfilename = cc_report_path & "ccprenote.rpt"
        CrystalForm.ShowDialog()
    End Sub

    'XXXXXXXXXXXXXX data entry fields

    Private Sub prenote_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prenote_date.Enter, check_Date.Enter
        prenote_date.BackColor = Color.Aqua
    End Sub

    Private Sub check_Date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles check_Date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            valid_Date = etsdate(check_Date.Text, valid_Date)
            If IsDate(valid_Date) Then
                check_Date.Text = valid_Date
            Else
                MsgBox("Not a Valid Date")
                GoTo EventExitSub
            End If
            Process.Focus()
            KeyAscii = 0
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub prenote_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles prenote_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar)) ' added 6/2/00 scs
        If KeyAscii = 13 Or KeyAscii = 9 Then
            valid_Date = etsdate(prenote_date.Text, valid_Date)
            If IsDate(valid_Date) Then
                prenote_date.Text = valid_Date
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

    Private Sub prenote_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prenote_date.Leave, check_Date.Leave
        prenote_date.BackColor = Color.White
    End Sub



    '    Public Sub ascii_write(ByVal kind As String)
    '        'written for one batch per file only
    '        tot_rec = 0
    '        tot_debit = 0
    '        tot_credit = 0
    '        bat_num = 1
    '        trace_num = 0
    '        tot_block = 0
    '        c_entry_hash = 0
    '        f_entry_hash = 0

    '        Select Case kind
    '            Case "PRE"
    '                outputfilename_b = "a:\prenote.dat"
    '                check_Date.Text = CStr(Today)
    '            Case "DATA"
    '                outputfilename_b = "a:\deposit.dat"
    '            Case Else
    '                outputfilename_b = "a:\deposit.dat"
    '        End Select

    '        fnum = FreeFile()
    'TryAgain:
    '        FileOpen(fnum, outputfilename_b, OpenMode.Output, , , 1)

    '        Select Case Err.Number
    '            Case 0

    '            Case Else
    '                MsgBox("error = " & ErrorToString(Err.Number))
    '                MsgBox("Error opening the prenote file. No file created. CALL ETS.")
    '                Exit Sub
    '        End Select
    '        'record definition follow each line if a -o is at the end the field is optional
    '        'create file header record
    '        'bk_acct_no field has the bank transit/routing # in it


    '        Using db As Database = New Database(top_data_path)
    '            Dim rs As SqlDataReader = db.ExecuteQuery("select * from ccsys")
    '            While rs.Read()
    '                bkAcctNo = rs("bk_acct_no").ToString
    '                selected_screen_nam = rs("screen_nam").ToString
    '                selected_agency_name = rs("agency_name").ToString
    '                BankReas = rs("bank_reas").ToString
    '            End While
    '            rs.Close()
    '        End Using

    '        Using db As Database = New Database(top_data_path)
    '            Dim rs As SqlDataReader = db.ExecuteQuery("select * from etssys")
    '            While rs.Read()
    '                selected_agency_name = rs("agency_name").ToString
    '            End While
    '            rs.Close()
    '        End Using

    '        Print(fnum, "1") 'record type
    '        Print(fnum, "01") 'priority; code
    '        Print(fnum, " " & VB.Left(bkAcctNo & Spaces, 9)) 'immed dest source bank acc#
    '        Print(fnum, "1" & VB.Left(er_num & Spaces, 9)) '1 + tax id #
    '        Print(fnum, String.Format("{0:yyMMdd}", dt)) 'VB6.Format(Today, "yyMMdd")) 'file create date
    '        Print(fnum, String.Format("{0: HHMM}", dt)) 'VB6.Format(Today, "yyMMdd")) 'file create date
    '        Print(fnum, "X") 'file modifier
    '        Print(fnum, "094") 'record size
    '        Print(fnum, "10") 'blocking size
    '        Print(fnum, "1") 'format code
    '        Print(fnum, VB.Left(selected_screen_nam & Spaces, 23)) 'immed dest name -o
    '        Print(fnum, VB.Left(selected_agency_name & Spaces, 23)) 'immed orign name -o
    '        PrintLine(fnum, Space(8)) 'reference code generally left blank

    '        'create company batch header
    '        'modified for alliance  3/14/01 lhw
    '        Print(fnum, "5") '1
    '        Print(fnum, "200") 'serv class code      2-4
    '        Print(fnum, VB.Left(er_nam & Spaces, 16)) 'comp name 5-20
    '        Print(fnum, Space(20)) 'comp extra data -o 21-40
    '        Print(fnum, "1" & VB.Left(er_num & Spaces, 9)) '1 + tax id # 41 - 50
    '        Print(fnum, "PPD") 'std entry class 51-53
    '        Print(fnum, VB.Left(BankReas & Spaces, 10)) 'entry desc 54 -63
    '        Print(fnum, Space(6)) 'blank spaces 64 - 69
    '        Print(fnum, String.Format("{0:yyMMdd}", check_Date.Text)) 'eff date 70 - 75
    '        Print(fnum, Space(3)) 'settlement date (julian) inserted by ach operator
    '        Print(fnum, "1") 'orig status code
    '        Print(fnum, VB.Left(bkAcctNo & Spaces, 8)) 'orig dfi
    '        PrintLine(fnum, String.Format("{0:0000000}", bat_num)) 'batch num

    '        'now the detail records and assuming no addenda records
    '        Dim msg As String = ""

    '        Using db As Database = New Database(top_data_path)
    '            Dim rs As SqlDataReader = db.ExecuteQuery("select * from ccach")
    '            While rs.Read()
    '                Print(fnum, "6")
    '                'for prenote the code is 23 or 33
    '                '    Select Case ccach.Recordset.Fields("c-or-s").Value
    '                '        Case "c", "C"
    '                '            If ccach.Recordset.Fields("$amt").Value > 0 Then
    '                '                msg = "22"
    '                '            Else
    '                '                msg = "27"
    '                '            End If
    '                '            If kind = "PRE" Then msg = "23"
    '                '        Case "s", "S"
    '                '            If ccach.Recordset.Fields("$amt").Value > 0 Then
    '                '                msg = "32"
    '                '            Else
    '                '                msg = "37"
    '                '            End If
    '                '            If kind = "PRE" Then msg = "33"
    '                '    End Select

    '                '            Print(fnum, VB.Left(msg & Spaces, 2)) 'tran code
    '                '            Print(fnum, VB.Left(ccach.Recordset.Fields("bnkaba_num").Value & Spaces, 8)) 'reci ident
    '                '            Print(fnum, VB.Right(ccach.Recordset.Fields("bnkaba_num").Value, 1)) 'chk digit
    '                '           Print(fnum, VB.Left(ccach.Recordset.Fields("bnkacct_num").Value & Spaces, 17)) 'dfi acct num
    '                '            Print(fnum, VB.Right(zeroes & Int(ccach.Recordset.Fields("$amt").Value * 100), 10)) 'amt
    '                '            Print(fnum, VB.Left(ccach.Recordset.Fields("employ_num").Value & Spaces, 15)) 'ind ident
    '                '            Print(fnum, VB.Left(ccach.Recordset.Fields("screen_nam").Value & Spaces, 22)) 'ind name
    '                '            Print(fnum, Space(2)) 'disc data -o
    '                '            Print(fnum, "0") 'addenda record '79
    '                '            trace_num = trace_num + 1
    '                '            PrintLine(fnum, VB6.Format(trace_num, "000000000000000")) 'trace num
    '                '            'count the records
    '                '            tot_rec = tot_rec + 1

    '                '            'sum the credits
    '                '            'sum the debits
    '                '           If ccach.Recordset.Fields("$amt").Value > 0 Then
    '                '               tot_credit = tot_credit + ccach.Recordset.Fields("$amt").Value
    '                '            Else
    '                '                tot_debit = tot_debit + ccach.Recordset.Fields("$amt").Value
    '                '            End If
    '                '            'create the entry hash
    '                '            c_entry_hash = c_entry_hash + Val(VB.Left(ccach.Recordset.Fields("bnkaba_num").Value & Spaces, 8))

    '                '            'End If
    '            End While
    '            rs.Close()
    '        End Using


    '        f_entry_hash = f_entry_hash + c_entry_hash



    '        '        'company batch control

    '        Print(fnum, "8")
    '        Print(fnum, "200") 'service class code
    '        Print(fnum, VB6.Format(tot_rec, "000000")) 'entry count
    '        Print(fnum, VB.Right(zeroes & CStr(c_entry_hash), 10)) 'entry hash
    '        Print(fnum, VB6.Format(tot_debit * 100, "000000000000")) 'total debit
    '        Print(fnum, VB6.Format(tot_credit * 100, "000000000000")) 'total cred
    '        Print(fnum, "1" & VB.Left(er_num & Spaces, 9)) '1 + tax id # 45 -
    '        Print(fnum, Space(25)) 'unused 55
    '        Print(fnum, VB.Left(bkAcctNo & Spaces, 8)) 'orig ident
    '        PrintLine(fnum, VB6.Format(bat_num, "0000000")) 'batch num

    '        '        'now to 9 fill the block to the end
    '        tot_block = (tot_rec + 4) / 10 - Int((tot_rec + 4) / 10)
    '        If tot_block > 0 Then
    '            For ETS.Common.Module1.num = 1 To CInt((10 - tot_block * 10))
    '                ' Print #fnum, String(94, "9")        'this is line removed for not 9 filling
    '            Next
    '        End If

    '        tot_block = ((tot_rec + 4) + (10 - tot_block * 10)) / 10

    '        '        'file control
    '        Print(fnum, "9")
    '        Print(fnum, VB6.Format(bat_num, "000000")) 'batch count
    '        Print(fnum, VB6.Format(tot_block, "000000")) 'block count
    '        Print(fnum, VB6.Format(tot_rec, "00000000")) 'entry count
    '        Print(fnum, VB.Right(zeroes & CStr(f_entry_hash), 10)) 'entry hash
    '        Print(fnum, VB6.Format(tot_debit * 100, "000000000000")) 'total debit
    '        Print(fnum, VB6.Format(tot_credit * 100, "000000000000")) 'total cred
    '        PrintLine(fnum, Space(39)) 'reserved
    '        FileClose(fnum)
    '        'Call copy_ascii(outputfilename_b)
    '        MsgBox("Please remove the floppy disk ")

    '    End Sub

    'Private Sub Process_Click()  from alliance ap direct payment
    '    'load the variables
    '    'the paying bank is all set


    '    'correct the apchecks file so can write it out
    '    db = ap_data_path & "ap.mdb"
    '    tmpdb = OpenDatabase(db)
    '    tmpset = tmpdb.OpenRecordset("apchecks", dbOpenDynaset)
    '    tmpset.MoveFirst()

    '    Do While Not tmpset.EOF
    '        tmpset.Edit()
    '        tmpset.Fields("chk_date") = CDate(check_Date.Text)    'check date
    '        tmpset.Fields("chk_num") = 0  'check number
    '        tmpset.update()
    '        tmpset.MoveNext()
    '    Loop

    '    ACH_date = Format(check_Date, "yyMMdd")
    '    'create the ACH ascii file
    '    write_ascii("DATA")
    '    Write_ACH1()
    '    Write_ACH5()

    '    'source
    '    tmpset.MoveFirst()
    '    trace_num = 0

    '    Do While Not tmpset.EOF
    '        selected_name_key = tmpset.Fields("name_key")
    '        Call chkname(selected_name_key)
    '        amt = Int(tmpset.Fields("n_chk_amt") * 100)

    '        Select Case tmpset.Fields("eCorS")
    '            Case "c", "C"
    '                If tmpset.Fields("n_chk_amt") > 0 Then
    '                    msg = "22"
    '                Else
    '                    msg = "27"
    '                End If
    '            Case "s", "S"
    '                If tmpset.Fields("n_chk_amt") > 0 Then
    '                    msg = "32"
    '                Else
    '                    msg = "37"
    '                End If
    '        End Select
    '        ' aba = tmpset.Fields("eABAnum")
    '        'acct = tmpset.Fields("eAcctNum")
    '        trace_num = trace_num + 1

    '        'update apchecks with the trace number and payment number
    '        tmpset.Edit()
    '        tmpset.Fields("eTraceNum") = Left(selected_bank_aba_num & spaces, 8) & Format(trace_num, "0000000")   'trace num
    '        tmpset.Fields("PaymentNum") = ACH_date ' add batch number if more than one per day
    '        tmpset.update()

    '        Call Write_ACH6(msg, 1, amt, tmpset.Fields("eABAnum"), tmpset.Fields("eAcctNum"), trace_num)


    '        'count the records
    '        tot_rec = tot_rec + 1

    '        'sum the credits
    '        'sum the debits
    '        If tmpset.Fields("n_chk_amt") > 0 Then
    '            tot_credit = tot_credit + tmpset.Fields("n_chk_amt")
    '            ' tot_credit = tot_credit + vamt
    '        Else
    '            tot_debit = tot_debit + tmpset.Fields("n_chk_amt")
    '            ' tot_debit = tot_debit + vamt
    '        End If
    '        'create the entry hash
    '        c_entry_hash = c_entry_hash + Val(Left(tmpset.Fields("eABAnum") & spaces, 8))

    '        'the detail payment addendum
    '        ' vch = tmpset.Fields("vouch_num")

    '        Call Write_ACH7(tmpset.Fields("vouch_num"), amt, trace_num)


    '        'recount the records
    '        tot_rec = tot_rec + 1


    '        tmpset.MoveNext()

    '    Loop

    '    f_entry_hash = f_entry_hash + c_entry_hash
    '    Call Write_ACH8()
    '    Call Write_ACH9()



    '    MsgBox("The ACH Payment File has been created in c:\etsacct\files_togo.")

    'Close #fnum

    'End Sub

    ' Private Sub prenote_Click()  for AP from alliance

    '     tot_rec = 0
    '     tot_debit = 0
    '     tot_credit = 0
    '     bat_num = 1
    '     trace_num = 0
    '     tot_block = 0
    '     c_entry_hash = 0
    '     f_entry_hash = 0

    '     'go to nam vend and get all epay vendors and go directly to writing the ascii file

    '     Call bank_nameget(bank.BoundText)

    '     ACH_date = Format(prenote_date, "yyMMdd")

    '     write_ascii("PRE")
    '     Write_ACH1()
    '     Write_ACH5()
    '     'for prenote the code is 23 or 33

    '     db = ap_data_path & "glname.mdb"
    '     tmpdb = OpenDatabase(db)
    '     tmpset = tmpdb.OpenRecordset("select * from nam_vend where ePay = 'Y' and eChangeDate >= " & Chr(35) & CDate(prenote_date.Text) & Chr(35), dbOpenDynaset)
    '     On Error Resume Next
    '     tmpset.MoveFirst()
    '     If err = 3021 Then
    '         MsgBox("No vendors have added or change date after date entered.")
    '         Exit Sub
    '     End If




    '     'source

    '     trace_num = 0
    '     Do While Not tmpset.EOF
    '         selected_name_key = tmpset.Fields("name_key")
    '         Call chkname(selected_name_key)
    '         amt = 0

    '         Select Case tmpset.Fields("eCorS")
    '             Case "c", "C"

    '                 msg = "23"

    '             Case "s", "S"

    '                 msg = "33"

    '         End Select
    '         trace_num = trace_num + 1

    '         Call Write_ACH6(msg, 0, amt, tmpset.Fields("eABAnum"), tmpset.Fields("eAcctNum"), trace_num)
    '         'no addenda records in prenote
    '         'count the records
    '         tot_rec = tot_rec + 1
    '         'sum the credits
    '         'sum the debits
    '         '  If tmpset.Fields("n_chk_amt") > 0 Then
    '         tot_credit = tot_credit '+ tmpset.Fields("n_chk_amt")
    '         ' tot_credit = tot_credit + vamt
    '         ' Else
    '         tot_debit = tot_debit '+ tmpset.Fields("n_chk_amt")
    '         ' tot_debit = tot_debit + vamt
    '         '  End If

    '         'create the entry hash
    '         c_entry_hash = c_entry_hash + Val(Left(tmpset.Fields("eABAnum") & spaces, 8))

    '         tmpset.MoveNext()
    '     Loop
    '     tot_credit = 0
    '     tot_debit = 0

    '     f_entry_hash = f_entry_hash + c_entry_hash
    '     Call Write_ACH8()
    '     Call Write_ACH9()

    '     MsgBox("The Pre-Note File has been created on c:\etsacct\files_togo.")

    'Close #fnum


    ' End Sub

    'Private Sub Process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Click
    '    '        ' xxnow we create ACH transfers
    '    '        'clear the table
    '    '        'output file approved 4/6/01 lhw
    '    '        ccach.Refresh()
    '    '        ccach.Recordset.MoveFirst()
    '    '        If Err.Number <> 3021 Then
    '    '            Do While Not ccach.Recordset.EOF
    '    '                ccach.Recordset.Delete()
    '    '                ccach.Recordset.MoveNext()
    '    '            Loop
    '    '        End If

    '    '        db = cc_data_path & "cc.mdb"
    '    '        tmpdb = DAODBEngine_definst.OpenDatabase(db)
    '    '        tmpset = tmpdb.OpenRecordset("cc_deposit", dao.RecordsetTypeEnum.dbOpenDynaset)
    '    '        On Error GoTo 0
    '    '        db = cc_data_path & "cc.mdb"
    '    '        tmp1db = DAODBEngine_definst.OpenDatabase(db)
    '    '        tmp1set = tmp1db.OpenRecordset("ccsys", dao.RecordsetTypeEnum.dbOpenDynaset)
    '    '        tmp1set.MoveFirst()


    '    '        er_num = tmp1set.Fields("er_fed_id").Value
    '    '        er_nam = tmp1set.Fields("agency_name").Value
    '    '        ccckstub.RecordSource = "select * from ccckstub where void = 'N' and chk_date = #" & check_Date.Text & "#"

    '    '        ccckstub.Refresh()
    '    '        'added 3-14-01 lhw
    '    '        On Error Resume Next
    '    '        ccckstub.Recordset.MoveFirst()
    '    '        If Err.Number = 3021 Then
    '    '            MsgBox("The date entered in not correct.")
    '    '            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    '    '            check_Date.Focus()
    '    '            Exit Sub
    '    '        End If
    '    '        On Error GoTo 0
    '    '        Do While Not ccckstub.Recordset.EOF
    '    '            'check all the deposit flags if none next
    '    '            'fileds not in client payroll
    '    '            If ccckstub.Recordset.Fields("chk_dirdep").Value = "Y" Then 'Or ccckstub.Recordset.Fields("ddep_sav1") = "Y" Or ccckstub.Recordset.Fields("ddep_sav2") = "Y" Or ccckstub.Recordset.Fields("ddep_sav3") = "Y" Then
    '    '                'look up the deposit table once for each person
    '    '                sqlstmnt = "name_key = " & Chr(34) & ccckstub.Recordset.Fields("name_key").Value & Chr(34)
    '    '                tmpset.FindFirst(sqlstmnt)
    '    '                glname.Recordset.FindFirst(sqlstmnt)

    '    '                ' If ccckstub.Recordset.Fields("ddep_sav1") = "Y" And Len(Trim(tmpset.Fields("bk1act_num"))) <> 0 Then
    '    '                ' ccach.Recordset.AddNew
    '    '                ' ccach.Recordset.Fields("name_key") = ccckstub.Recordset.Fields("name_key")
    '    '                ' ccach.Recordset.Fields("screen_nam") = ccckstub.Recordset.Fields("screen_nam")
    '    '                ' ccach.Recordset.Fields("er_num") = er_num
    '    '                ' ccach.Recordset.Fields("er_nam") = er_nam
    '    '                ' ccach.Recordset.Fields("employ_num") = ccckstub.Recordset.Fields("name_key")
    '    '                ' 'look up real first and last name
    '    '                ' ccach.Recordset.Fields("name") = Left$(glname.Recordset.Fields("last_name") & " " & glname.Recordset.Fields("first_name"), 22)
    '    '                ' ccach.Recordset.Fields("pay_date") = ccckstub.Recordset.Fields("chk_date")
    '    '                ' ccach.Recordset.Fields("bnkaba_num") = tmpset.Fields("bk1_aba")
    '    '                ' ccach.Recordset.Fields("bnkacct_num") = tmpset.Fields("bk1act_num")
    '    '                ' ccach.Recordset.Fields("c-or-s") = tmpset.Fields("bk1_c-or-s")
    '    '                ' ccach.Recordset.Fields("$amt") = ccckstub.Recordset.Fields("save1_ded")
    '    '                ' ccach.Recordset.Update
    '    '                ' End If

    '    '                '  If ccckstub.Recordset.Fields("ddep_sav2") = "Y" And Len(Trim(tmpset.Fields("bk2act_num"))) <> 0 Then
    '    '                ' ccach.Recordset.AddNew
    '    '                ' ccach.Recordset.Fields("name_key") = ccckstub.Recordset.Fields("name_key")
    '    '                ' ccach.Recordset.Fields("screen_nam") = ccckstub.Recordset.Fields("screen_nam")
    '    '                ' ccach.Recordset.Fields("er_num") = er_num
    '    '                ' ccach.Recordset.Fields("er_nam") = er_nam
    '    '                ' ccach.Recordset.Fields("employ_num") = ccckstub.Recordset.Fields("name_key")
    '    '                ' 'look up real first and last name
    '    '                ' ccach.Recordset.Fields("name") = Left$(glname.Recordset.Fields("last_name") & " " & glname.Recordset.Fields("first_name"), 22)
    '    '                ' ccach.Recordset.Fields("pay_date") = ccckstub.Recordset.Fields("chk_date")
    '    '                ''ccach.Recordset.Fields("bnkaba_num") = tmpset.Fields("bk2_aba")
    '    '                ' ccach.Recordset.Fields("bnkacct_num") = tmpset.Fields("bk2act_num")
    '    '                ' ccach.Recordset.Fields("c-or-s") = tmpset.Fields("bk2_c-or-s")
    '    '                ' ccach.Recordset.Fields("$amt") = ccckstub.Recordset.Fields("save2_ded")
    '    '                '
    '    '                ' ccach.Recordset.Update
    '    '                ' End If

    '    '                '  If ccckstub.Recordset.Fields("ddep_sav3") = "Y" And Len(Trim(tmpset.Fields("bk3act_num"))) <> 0 Then
    '    '                ' ccach.Recordset.AddNew
    '    '                ' ccach.Recordset.Fields("name_key") = ccckstub.Recordset.Fields("name_key")
    '    '                ' ccach.Recordset.Fields("screen_nam") = ccckstub.Recordset.Fields("screen_nam")
    '    '                ' ccach.Recordset.Fields("er_num") = er_num
    '    '                ' ccach.Recordset.Fields("er_nam") = er_nam
    '    '                ' ccach.Recordset.Fields("employ_num") = ccckstub.Recordset.Fields("name_key")
    '    '                ' 'look up real first and last name
    '    '                '  ccach.Recordset.Fields("name") = Left$(glname.Recordset.Fields("last_name") & " " & glname.Recordset.Fields("first_name"), 22)
    '    '                '  ccach.Recordset.Fields("pay_date") = ccckstub.Recordset.Fields("chk_date")
    '    '                ' ccach.Recordset.Fields("bnkaba_num") = tmpset.Fields("bk3_aba")
    '    '                ' ccach.Recordset.Fields("bnkacct_num") = tmpset.Fields("bk3act_num")
    '    '                ' ccach.Recordset.Fields("c-or-s") = tmpset.Fields("bk3_c-or-s")
    '    '                ' ccach.Recordset.Fields("$amt") = ccckstub.Recordset.Fields("save3_ded")

    '    '                ' ccach.Recordset.Update
    '    '                ' End If

    '    '                If ccckstub.Recordset.Fields("chk_dirdep").Value = "Y" And Len(Trim(tmpset.Fields("bk4act_num").Value)) <> 0 Then
    '    '                    'this is for net check
    '    '                    ccach.Recordset.AddNew()
    '    '                    ccach.Recordset.Fields("name_key").Value = ccckstub.Recordset.Fields("name_key").Value
    '    '                    ccach.Recordset.Fields("screen_nam").Value = ccckstub.Recordset.Fields("screen_nam").Value
    '    '                    ccach.Recordset.Fields("er_num").Value = er_num
    '    '                    ccach.Recordset.Fields("er_nam").Value = er_nam
    '    '                    ccach.Recordset.Fields("employ_num").Value = ccckstub.Recordset.Fields("name_key").Value
    '    '                    'look up real first and last name
    '    '                    ccach.Recordset.Fields("name").Value = VB.Left(glname.Recordset.Fields("last_name").Value & " " & glname.Recordset.Fields("first_name").Value, 22)
    '    '                    ccach.Recordset.Fields("pay_date").Value = ccckstub.Recordset.Fields("chk_date").Value
    '    '                    ccach.Recordset.Fields("bnkaba_num").Value = tmpset.Fields("bk4_aba").Value
    '    '                    ccach.Recordset.Fields("bnkacct_num").Value = tmpset.Fields("bk4act_num").Value
    '    '                    ccach.Recordset.Fields("c-or-s").Value = tmpset.Fields("bk4_c-or-s").Value
    '    '                    ccach.Recordset.Fields("$amt").Value = ccckstub.Recordset.Fields("net_pay").Value
    '    '                    ccach.Recordset.Update()
    '    '                End If
    '    '            End If 'this is for checking deposit flags

    '    'nextname:
    '     '            ccckstub.Recordset.MoveNext()
    '    '        Loop
    '    '        'we now write out the ascii file
    '    '        On Error Resume Next
    '    '        ccach.RecordSource = "select * from ccach order by name_key"
    '    '        ccach.Refresh()
    '    '        ccach.Recordset.MoveFirst()
    '    '        Dim ach_amt As Decimal
    '    '        If Err.Number = 3021 Then
    '    '            MsgBox("There are no Direct Deposits(ACH transfers) for this payroll.")
    '    '        Else
    '    'TryAgain:
    '    '            Call ascii_write("DATA")
    '    '            MsgBox("The Direct Deposit File has been created on drive A.")
    '    '        End If
    'End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        DestBankKey = VB.Trim(VB.Left(ComboBox1.Text, InStr(ComboBox1.Text, "-") - 1))
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        OrigBankKey = VB.Trim(VB.Left(ComboBox2.Text, InStr(ComboBox2.Text, "-") - 1))
    End Sub
End Class