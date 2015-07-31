Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETSCommon.Database
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Configuration
Imports System.Data.SqlClient

Friend Class prep_adp_cc
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 9/23/96 -SCS
	
	'****************
	Public valid_acct_flg As String
	Public valid_co_code As String
	Public outputfilename_b As String
	Public tmp_co_code As String
	Public adpend_date As Date
	Dim tots(22) As Double

	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		Me.Close()
		
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		'MsgBox "Write a new report for this called adp_proof.rpt."
		'prtDestination = 0
		
		
		' prtreportfilename = cc_report_path & "S5A_adp_proof.rpt"
		' Call frmcrystal_Call
        'System.Windows.Forms.SendKeys.Send("{TAB}")

		
	End Sub
	
    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        'this creates S4Y  ADP ascii files to upload

        Dim co_name As String = "S4Y"
        Call write_output_file(co_name)
        MsgBox("S4Y ADP file has been created on c:\etsacct.")

    End Sub

    Private Sub write_output_file(ByVal co_name As String)
        fnum = FreeFile()
        Dim outdate As String
        Dim outday As String
        Dim outmnth As String
        Dim outyr As String

        outday = CStr(VB.Day(CDate(end_date.Text)))
        outmnth = CStr(Month(CDate(end_date.Text)))
        outyr = CStr(Year(CDate(end_date.Text)))
        outdate = outday & outmnth & outyr

        tmp_co_code = "S4Y"

        outputfilename_b = "c:\etsacct\" & tmp_co_code & outdate & ".dat"

        FileOpen(fnum, outputfilename_b, OpenMode.Output, , , 1)

        'create file header record
        Print(fnum, "Co Code,")
        Print(fnum, "Batch ID,")
        Print(fnum, "File#,")
        Print(fnum, "Earnings,")
        PrintLine(fnum, "Tmp Dept")

        sqlstmnt = "select * from adp_tmp where batch_id = " & Beg_chk_num
        sqlstmnt = sqlstmnt & " and co_code = 'S4Y'"
        sqlstmnt = sqlstmnt & " order by file_num,tmp_dept"
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            intcount = 0
            While rs.Read()
                '   search_array(intcount, 0) = rs("db").ToString
                '  search_array(intcount, 1) = rs("tbl").ToString
                intcount = intcount + 1
            End While
            rs.Close()
        End Using

        'now the detail records and assuming no addenda records
        Dim selected_name_key As String
        Dim selected_adp_code As String
        Dim tmp_file_num As String
        Dim left_key As String

        selected_job_num = ""
        selected_name_key = ""
        selected_adp_code = ""

        tmp_file_num = ""
        left_key = "00"
        tots(0) = 0


        '   selected_name_key = tmpset.Fields("name_key") 'same
        '  selected_adp_code = tmpset.Fields("tmp_dept") 'was job#  this is adp_code

        'adding up dollars for like name_key/adp code combinations
        'We need to use name key because this will eliminate dups
        'We will write out the field file_num  this is used by ADP


        ' Do While Not tmpset.EOF

        '   If selected_name_key = tmpset.Fields("name_key") Then

        '            If selected_adp_code = tmpset.Fields("tmp_dept") Then

        '               tots(0) = tots(0) + tmpset.Fields("earnings")

        '                 Else                  'write record when job# changes     same cc# dif adp code
        '                   If tots(0) <> 0 Then
        'Print #fnum, txtfields(1) & ",";
        '                        Print #fnum, tmpset.Fields("co_code") & ",";
        '                       Print #fnum, "BATCH" & tmpset.Fields("batch_id") & ",";                     'Batch id
        '                      Print #fnum, tmpset.Fields("file_num") & ",";
        '                     Print #fnum, tots(0) & ",";
        '                    Print #fnum, selected_adp_code

        '             End If


        '          tots(0) = tmpset.Fields("earnings")
        '         selected_name_key = tmpset.Fields("name_key")
        '        selected_adp_code = tmpset.Fields("tmp_dept")


        '   End If     'end of diff job num

        ' Else
        '      If tots(0) <> 0 Then

        '              Print #fnum, tmpset.Fields("co_code") & ",";                   'company code
        '             Print #fnum, "BATCH" & tmpset.Fields("batch_id") & ",";
        '            Print #fnum, tmpset.Fields("file_num") & ",";
        '           Print #fnum, tots(0) & ",";
        '          Print #fnum, selected_adp_code

        '  End If

        'tots(0) = tmpset.Fields("earnings")

        '   selected_name_key = tmpset.Fields("name_key")        '
        '  selected_adp_code = tmpset.Fields("tmp_dept")


        'End If     'end of diff name key

        '  tmp_co_code = tmpset.Fields("co_code")
        ' tmp_file_num = tmpset.Fields("file_num")

        'tmpset.MoveNext

        ' Loop

        'write out the last record

        If tots(0) <> 0 Then

            Print(fnum, tmp_co_code & ",")
            Print(fnum, "BATCH" & Pr_num1.Text & ",")
            Print(fnum, tmp_file_num & ",")
            Print(fnum, tots(0) & ",")
            PrintLine(fnum, selected_adp_code)

        End If

        FileClose(fnum)
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        'prtDestination = 0


        'prtreportfilename = cc_report_path & "S4Y_adp_proof.rpt"
        'Call frmcrystal_Call
        'System.Windows.Forms.SendKeys.Send("{TAB}")
        'KeyAscii = 0
    End Sub

    Private Sub end_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles end_date.Enter
        Call ets_set_selected()
    End Sub

    Private Sub end_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles end_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            valid_Date = "N"
            senddate = end_date.Text
            valid_Date = etsdate(senddate, valid_Date)

            If valid_Date = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                retdate = CDate(valid_Date)
                end_date.Text = CStr(retdate)
                end_date.Text = CStr(retdate)
                end_date.Text = CStr(CDate(end_date.Text))

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

    Private Sub end_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles end_date.Leave
        Pr_num1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub prep_adp_cc_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)



    End Sub

    Private Sub Pr_num1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Pr_num1.Enter
        Call ets_set_selected()
    End Sub

    Private Sub pr_num1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Pr_num1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar)) 'this is the payroll number
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Beg_chk_num = 0
            end_chk_num = 0
            'check for a comma to set up a range else just one
            If InStr(1, Pr_num1.Text, ",") > 0 Then
                Dim chks As String = Pr_num1.Text.Split(CChar(",")).ToString
                Beg_chk_num = Val(chks(0))
                end_chk_num = Val(chks(1))
            Else
                Beg_chk_num = CInt(Val(Pr_num1.Text))
                end_chk_num = Beg_chk_num
            End If

            System.Windows.Forms.SendKeys.Send("{tab}")


        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_num1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Pr_num1.Leave
        Pr_num1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub Process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Click

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        saved_function_Type = function_type
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = "delete from adp_tmp"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            rs.Close()
        End Using

        'now we read cctime for this pay period     

        For ETSCommon.MODULE1.num = 0 To 8
            tots(num) = 0
        Next

        sqlstmnt = "select * from cctime where pay_num = " & Beg_chk_num
        sqlstmnt = sqlstmnt & " and void <> ""Y"" and dflag <> ""Y"" and glpost <> ""Y"""
        sqlstmnt = sqlstmnt & " and left(cctime.name_key, 1) <> '5'"

        sqlstmnt = sqlstmnt & " and pay_dol > 0 order by dept_num, job_num "
        sqlstmnt = sqlstmnt & " and pay_dol > 0 order by name_key, job_num "

        '         cctime.RecordSource = sqlstmnt
        '        cctime.Refresh
        '       cctime.Recordset.MoveFirst

        Dim selected_job_num As String
        Dim selected_name_key As String
        Dim selected_adp_code As String

        Dim tmp_file_num As String
        Dim left_key As String
        selected_job_num = ""
        selected_name_key = ""
        selected_adp_code = ""
        tmp_co_code = ""
        tmp_file_num = ""
        left_key = "00"
        tots(0) = 0
        tots(1) = 0
        '    selected_name_key = cctime.Recordset.Fields("name_key") 'was dept_num
        '   selected_job_num = cctime.Recordset.Fields("job_num")


        'adding up dollars for like name_key/job combinations

        '   Do While Not cctime.Recordset.EOF

        'If selected_name_key = cctime.Recordset.Fields("name_key") Then

        '  If selected_job_num = cctime.Recordset.Fields("job_num") Then


        '   tots(0) = tots(0) + cctime.Recordset.Fields("pay_dol")
        '  tots(1) = tots(1) + cctime.Recordset.Fields("hours")
        ' sqlstmnt = "select * from ccjob where job_num =" & Chr(34) & cctime.Recordset.Fields("job_num") & Chr(34)
        'ccjob.RecordSource = sqlstmnt
        'ccjob.Refresh
        'ccjob.Recordset.MoveFirst

        '    Else
        If tots(0) <> 0 Then

            sqlstmnt = "select * from ccjob where job_num =" & Chr(34) & selected_job_num & Chr(34)


            '                ccjob.RecordSource = sqlstmnt
            '               ccjob.Refresh
            '              ccjob.Recordset.MoveFirst

            '         validnumset.AddNew
            '        validnumset.Fields("name_key") = selected_name_key
            '       validnumset.Fields("job_num") = selected_job_num

            If VB.Left(selected_name_key, 2) = "00" Then 'to get Company Codes
                tmp_co_code = "S5A"
            Else
                tmp_co_code = "S4Y"
            End If

            '      validnumset.Fields("co_code") = tmp_co_code
            '     validnumset.Fields("batch_id") = beg_chk_num

            '    tmp_file_num = Trim(selected_name_key)

            '   validnumset.Fields("file_num") = left_key & Right(tmp_file_num, 4)    'adp cc number

            '  validnumset.Fields("earnings") = tots(0)
            ' validnumset.Fields("reg_hrs") = tots(1)
            'validnumset.Fields("tmp_dept") = ccjob.Recordset.Fields("adp_code")                'correct

            'validnumset.Update

        End If

        ' tots(0) = cctime.Recordset.Fields("pay_dol")
        'tots(1) = cctime.Recordset.Fields("hours")
        '  selected_name_key = cctime.Recordset.Fields("name_key")        'dept num
        ' selected_job_num = cctime.Recordset.Fields("job_num")


        'End If     'end of diff job num

        'Else
        If tots(0) <> 0 Then

            sqlstmnt = "select * from ccjob where job_num =" & Chr(34) & selected_job_num & Chr(34)

            '                ccjob.RecordSource = sqlstmnt
            '               ccjob.Refresh
            '              ccjob.Recordset.MoveFirst

            '        validnumset.AddNew
            '         validnumset.Fields("name_key") = selected_name_key
            '         validnumset.Fields("job_num") = selected_job_num

            If VB.Left(selected_name_key, 2) = "00" Then 'to get Company Codes
                tmp_co_code = "S5A"
            Else
                tmp_co_code = "S4Y"
            End If

            '        validnumset.Fields("co_code") = tmp_co_code
            '       validnumset.Fields("batch_id") = beg_chk_num

            '      tmp_file_num = Trim(selected_name_key)
            '     validnumset.Fields("file_num") = left_key & Right(tmp_file_num, 4)    'adp cc number

            '    validnumset.Fields("earnings") = tots(0)
            '   validnumset.Fields("reg_hrs") = tots(1)
            '  validnumset.Fields("tmp_dept") = ccjob.Recordset.Fields("adp_code")

            ' validnumset.Update
        End If

        '       tots(0) = cctime.Recordset.Fields("pay_dol")
        '     tots(1) = cctime.Recordset.Fields("hours")
        '    selected_name_key = cctime.Recordset.Fields("name_key")        'dept num
        '   selected_job_num = cctime.Recordset.Fields("job_num")
        '

        ' End If     'end of diff name key

        '     cctime.Recordset.MoveNext

        ' Loop

        'write out the last record

        'If tots(0) <> 0 Then          'removed to see if we can get right totals 12/20/2008
        '  validnumset.AddNew
        '         validnumset.Fields("name_key") = selected_name_key
        '        validnumset.Fields("job_num") = selected_job_num

        If VB.Left(selected_name_key, 2) = "00" Then 'to get Company Codes
            tmp_co_code = "S5A"
        Else
            tmp_co_code = "S4Y"
        End If

        '       validnumset.Fields("co_code") = tmp_co_code
        '      validnumset.Fields("batch_id") = beg_chk_num

        tmp_file_num = Trim(selected_name_key)
        '     validnumset.Fields("file_num") = left_key & Right(tmp_file_num, 4)     'adp cc number

        '    validnumset.Fields("earnings") = tots(0)
        '   validnumset.Fields("reg_hrs") = tots(1)
        '  validnumset.Fields("tmp_dept") = ccjob.Recordset.Fields("adp_code")

        '                  validnumset.Update
        'End If  'removed to see if we can get right totals 12/20/2008



        If Response = 1 Then

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        MsgBox("ADP File Loaded - Print ADP Proof Report")
    End Sub

    Private Sub write_je_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles write_je.Click 'tested 2/20/2009 lhw
        Dim co_name As String = "S5A"
        Call write_output_file(co_name)
        MsgBox("S5A ADP file has been created on c:\etsacct.")
    End Sub
End Class