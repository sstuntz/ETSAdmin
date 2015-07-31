Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Compatibility
Imports Microsoft.VisualBasic.PowerPacks
Imports ETSCommon
Imports ETSCommon.MODULE1
Imports System.Data.SqlClient
Imports System.Configuration

Friend Class prep_je_cc
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 9/23/96 -SCS
	'ARCNC form 7/14/04 lhw
	'****************
	Public valid_acct_flg As String
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		Me.Close()
    End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccje.rpt"
        'Call frmcrystal_Call()
        'System.Windows.Forms.SendKeys.Send("{TAB}")
        'KeyAscii = 0
    End Sub
	
    Private Sub command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccpyjrnl.rpt"
        'Call frmcrystal_Call()
    End Sub
	
    Private Sub prep_je_cc_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
  
    End Sub
	
	Private Sub Pr_num1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Pr_num1.Enter
        '	Call ets_set_selected()
    End Sub
	
	Private Sub pr_num1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_num1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			beg_chk_num = 0
			last_Chk_num = 0
			'check for a comma to set up a range else just one
			If InStr(1, Pr_num1.Text, ",") > 0 Then
				beg_chk_num = CInt(VB.Left(Pr_num1.Text, InStr(1, Pr_num1.Text, ",") - 1))
				last_Chk_num = CInt(VB.Right(Pr_num1.Text, Len(Pr_num1.Text) - InStr(1, Pr_num1.Text, ",")))
			Else
				beg_chk_num = CInt(Pr_num1.Text)
				last_Chk_num = beg_chk_num
			End If
			
			System.Windows.Forms.SendKeys.Send("{tab}")
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub pr_num1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_num1.Leave
		Pr_num1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
	
	Private Sub Process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Click

        'this is the way Lynne Sugar of Alliance wants it to be. 2/20/2004
		
		'1 collect all data from ccjob,cc_deduct,ccckstub and move to je_tmp
		'2  zero je tmp
		'3 test je tmp for bad account numbers and in balance
		'4 print report from je_tmp separate command1
		'5 write je from je tmp to yrgenled - separate object write_je
		'first we get the right dollars into the payper dollars of ccjob
		
        saved_function_Type = function_type
		function_type = saved_function_Type
		
		'we set up cc_deduct as temp so we can do a findfirst
        '  tmpset = tmpdb.OpenRecordset("cc_deduct", dao.RecordsetTypeEnum.dbOpenDynaset)
		
        '2 we need to clear the temp je table before doing anything
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = "delete from je_tmp"
            db.ExecuteQuery(sql)
        End Using

        'now we read ccckstub for this pay period and get the liability

        sqlstmnt = "select * from ccckstub where pay_num = " & beg_chk_num & ""
		sqlstmnt = sqlstmnt & " and void <> ""Y"" and dflag = ""N"" and gl_post = ""N"""
		
        '	MsgBox("This pay number does not exist.  Re-enter correct number")
           '  saved_Date = ccckstub.Recordset.Fields("chk_Date").Value

        'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Do While Not ccckstub.Recordset.EOF
        '    'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    tots(0) = tots(0) + ccckstub.Recordset.Fields("fed_tax").Value + ccckstub.Recordset.Fields("add_fwt").Value
        '    'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    tots(1) = tots(1) + (ccckstub.Recordset.Fields("fica_tax").Value + ccckstub.Recordset.Fields("add_fica").Value) * 2
        '    'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    tots(2) = tots(2) + (ccckstub.Recordset.Fields("med_tax").Value + ccckstub.Recordset.Fields("add_med").Value) * 2
        '    'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    tots(3) = tots(3) + ccckstub.Recordset.Fields("net_pay").Value
        '    'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    tots(4) = tots(4) + ccckstub.Recordset.Fields("state1_tax").Value + ccckstub.Recordset.Fields("add_swt").Value
        '    'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    tots(5) = tots(5) + ccckstub.Recordset.Fields("state2_tax").Value
        '    'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    tots(6) = tots(6) + ccckstub.Recordset.Fields("fica_tax").Value
        '    'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    tots(7) = tots(7) + ccckstub.Recordset.Fields("med_tax").Value

        '    'read the fields to see if there is an amount then write those that have

        '        For num = 46 To 53 Step 2
        '            'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            If ccckstub.Recordset.Fields(num).Value <> 0 Then
        '                'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                je_tmp.Recordset.AddNew()
        '                'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                je_tmp.Recordset.Fields("ded_num").Value = ccckstub.Recordset.Fields(num + 1).Value & ""
        '                'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                je_tmp.Recordset.Fields("dept_num").Value = ccckstub.Recordset.Fields("dept_num").Value & ""
        '                'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                je_tmp.Recordset.Fields("dol_amt").Value = ccckstub.Recordset.Fields(num).Value * -1
        '                'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                je_tmp.Recordset.Fields("chk_Date").Value = saved_Date
        '                'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                je_tmp.Recordset.Fields("eff_Date").Value = txtfields.Text
        '                'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                je_tmp.Recordset.Update()
        '            End If
        '        Next

        '        Loop

        '        'move the taxes and net for the proper totalling
        '        Dim deds(7) As String
        '        deds(0) = "9991" 'fwt
        '        deds(1) = "9992" 'fica * 2
        '        deds(2) = "9993" 'med * 2
        '        deds(3) = "9999" 'net
        '        deds(4) = "9970" 'state1
        '        deds(5) = "9971" 'state2
        '        'move the debit for fica and med
        '        deds(6) = "9992" 'fica debit
        '        deds(7) = "9993" 'med debit

        '        For num = 0 To 5 '8
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.AddNew()
        '            'get the right deduction number
        '            'tmpset.FindFirst sqlstmnt
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Fields("ded_num").Value = deds(num) 'tmpset.Fields("cr_acct_nu")
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Fields("dol_amt").Value = tots(num) * -1
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Fields("chk_Date").Value = saved_Date
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Fields("eff_Date").Value = txtfields.Text
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Update()
        '        Next

        '        On Error GoTo 0 ' other part of fica/med
        '        For num = 6 To 7
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.AddNew()
        '            'get the right deduction number
        '            'tmpset.FindFirst sqlstmnt
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Fields("ded_num").Value = deds(num) 'tmpset.Fields("cr_acct_nu")
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Fields("dol_amt").Value = tots(num) '* -1
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Fields("chk_Date").Value = saved_Date
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Update()
        '        Next

        '        'now get the account numbers for the j/e from cc_deduct
        '        je_tmp.Refresh()
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        je_tmp.Recordset.MoveFirst()

        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        Do While Not je_tmp.Recordset.EOF
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            sqlstmnt = "ded_num = " & Chr(34) & je_tmp.Recordset.Fields("ded_num").Value & Chr(34)
        '            tmpset.FindFirst(sqlstmnt)
        '            If tmpset.NoMatch Then
        '                'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default 'lhw99
        '                'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                MsgBox("Invalid deduction number = " & je_tmp.Recordset.Fields("ded_num").Value & je_tmp.Recordset.Fields("dol_amt").Value)
        '                Exit Sub
        '            Else
        '                'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                je_tmp.Recordset.edit()
        '                'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                je_tmp.Recordset.Fields("acct_num").Value = tmpset.Fields("cr_acct_nu").Value & ""
        '                'now we adjust the acct number for the dept
        '                'If tmpset.Fields("ded_type") = "NT" Then
        '                'je_tmp.Recordset.Fields("acct_num") = Left$(je_tmp.Recordset.Fields("acct_num"), 8) & je_tmp.Recordset.Fields("dept_num")
        '                'End If
        '                'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                je_tmp.Recordset.Update()
        '                'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                je_tmp.Recordset.MoveNext()
        '            End If
        '        Loop

        '        'the totals are done now to create the je with acct nums

        '        'now we read cctime to get the gross pay expense amounts



        '        sqlstmnt = "select * from cctime where pay_num = " & beg_chk_num '2002
        '        sqlstmnt = sqlstmnt & " and void <> ""Y"" and dflag <> ""Y"" and glpost <> ""Y"""
        '        sqlstmnt = sqlstmnt & " and pay_dol > 0 order by dept_num, job_num "

        '        'UPGRADE_ISSUE: Data property cctime.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        cctime.RecordSource = sqlstmnt
        '        cctime.Refresh()
        '        'UPGRADE_ISSUE: Data property cctime.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        cctime.Recordset.MoveFirst()

        '        Dim selected_job_num As String
        '        selected_dpt_num = ""
        '        selected_job_num = ""
        '        tots(0) = 0
        '        tots(2) = 0
        '        'UPGRADE_ISSUE: Data property cctime.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        selected_dept_num = cctime.Recordset.Fields("dept_num").Value
        '        'UPGRADE_ISSUE: Data property cctime.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        selected_job_num = cctime.Recordset.Fields("job_num").Value

        '        'adding up dollars for like dept/job combinations
        '        'UPGRADE_ISSUE: Data property cctime.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        Do While Not cctime.Recordset.EOF

        '            'UPGRADE_ISSUE: Data property cctime.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            If selected_dpt_num = cctime.Recordset.Fields("dept_num").Value Then

        '                'UPGRADE_ISSUE: Data property cctime.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                If selected_job_num = cctime.Recordset.Fields("job_num").Value Then
        '                    'UPGRADE_ISSUE: Data property cctime.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    tots(0) = tots(0) + cctime.Recordset.Fields("pay_dol").Value
        '                    'UPGRADE_ISSUE: Data property cctime.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    sqlstmnt = "select * from ccjob where job_num =" & Chr(34) & cctime.Recordset.Fields("job_num").Value & Chr(34)
        '                    'UPGRADE_ISSUE: Data property ccjob.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccjob.RecordSource = sqlstmnt
        '                    ccjob.Refresh()
        '                    'UPGRADE_ISSUE: Data property ccjob.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccjob.Recordset.MoveFirst()

        '                Else
        '                    If tots(0) <> 0 Then

        '                        sqlstmnt = "select * from ccjob where job_num =" & Chr(34) & selected_job_num & Chr(34)
        '                        'UPGRADE_ISSUE: Data property ccjob.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                        ccjob.RecordSource = sqlstmnt
        '                        ccjob.Refresh()
        '                        'UPGRADE_ISSUE: Data property ccjob.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                        ccjob.Recordset.MoveFirst()
        '                        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                        je_tmp.Recordset.AddNew()
        '                        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                        je_tmp.Recordset.Fields("ded_num").Value = "8888"
        '                        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                        'UPGRADE_ISSUE: Data property ccjob.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                        je_tmp.Recordset.Fields("acct_num").Value = ccjob.Recordset.Fields("dr_acct_nu").Value & ""
        '                        'now we adjust the acct number for the dept
        '                        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                        je_tmp.Recordset.Fields("dept_num").Value = selected_dpt_num 'scs
        '                        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                        'UPGRADE_ISSUE: Data property ccjob.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                        je_tmp.Recordset.Fields("acct_num").Value = VB.Left(ccjob.Recordset.Fields("dr_acct_nu").Value, 8) & selected_dpt_num 'cctime.Recordset.Fields("dept_num")
        '                        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                        je_tmp.Recordset.Fields("dol_amt").Value = tots(0)
        '                        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                        je_tmp.Recordset.Fields("chk_Date").Value = saved_Date
        '                        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                        je_tmp.Recordset.Fields("eff_Date").Value = txtfields.Text
        '                        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                        je_tmp.Recordset.Update()
        '                    End If

        '                    'UPGRADE_ISSUE: Data property cctime.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    tots(0) = cctime.Recordset.Fields("pay_dol").Value
        '                    'UPGRADE_ISSUE: Data property cctime.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    selected_dpt_num = cctime.Recordset.Fields("dept_num").Value
        '                    'UPGRADE_ISSUE: Data property cctime.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    selected_job_num = cctime.Recordset.Fields("job_num").Value
        '                End If 'end of diff job num

        '            Else
        '                If tots(0) <> 0 Then

        '                    sqlstmnt = "select * from ccjob where job_num =" & Chr(34) & selected_job_num & Chr(34)
        '                    'UPGRADE_ISSUE: Data property ccjob.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccjob.RecordSource = sqlstmnt
        '                    ccjob.Refresh()
        '                    'UPGRADE_ISSUE: Data property ccjob.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    ccjob.Recordset.MoveFirst()

        '                    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    je_tmp.Recordset.AddNew()
        '                    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    je_tmp.Recordset.Fields("ded_num").Value = "8888"
        '                    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    'UPGRADE_ISSUE: Data property ccjob.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    je_tmp.Recordset.Fields("acct_num").Value = ccjob.Recordset.Fields("dr_acct_nu").Value & ""
        '                    'now we adjust the acct number for the dept
        '                    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    'UPGRADE_ISSUE: Data property ccjob.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    je_tmp.Recordset.Fields("acct_num").Value = VB.Left(ccjob.Recordset.Fields("dr_acct_nu").Value, 8) & selected_dpt_num 'cctime.Recordset.Fields("dept_num")
        '                    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    je_tmp.Recordset.Fields("dept_num").Value = selected_dpt_num 'scs
        '                    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    je_tmp.Recordset.Fields("dol_amt").Value = tots(0)
        '                    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    je_tmp.Recordset.Fields("chk_Date").Value = saved_Date
        '                    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    je_tmp.Recordset.Fields("eff_Date").Value = txtfields.Text
        '                    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    je_tmp.Recordset.Update()
        '                End If

        '                'UPGRADE_ISSUE: Data property cctime.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                tots(0) = cctime.Recordset.Fields("pay_dol").Value
        '                'UPGRADE_ISSUE: Data property cctime.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                selected_dpt_num = cctime.Recordset.Fields("dept_num").Value
        '                'UPGRADE_ISSUE: Data property cctime.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                selected_job_num = cctime.Recordset.Fields("job_num").Value

        '            End If 'end of diff dept num

        '            'UPGRADE_ISSUE: Data property cctime.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            cctime.Recordset.MoveNext()

        '        Loop

        '        'write out the last record
        '        If tots(0) <> 0 Then
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.AddNew()
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Fields("ded_num").Value = "8888"
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_ISSUE: Data property ccjob.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Fields("acct_num").Value = ccjob.Recordset.Fields("dr_acct_nu").Value & ""
        '            'now we adjust the acct number for the dept
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_ISSUE: Data property ccjob.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Fields("acct_num").Value = VB.Left(ccjob.Recordset.Fields("dr_acct_nu").Value, 8) & selected_dpt_num
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Fields("dol_amt").Value = tots(0)
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Fields("chk_Date").Value = saved_Date
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Fields("eff_Date").Value = txtfields.Text
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Update()
        '        End If



        '        ' 3   now test the total to make sure it is zero and check acct numbers
        '        tots(0) = 0
        '        Response = 0
        '        je_tmp.Refresh()
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        je_tmp.Recordset.MoveFirst()

        '        'now the final test of account numbers and dollar amount

        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        Do While Not je_tmp.Recordset.EOF
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            tots(0) = tots(0) + je_tmp.Recordset.Fields("dol_amt").Value
        '            valid_acct = "N"
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            Call chk_acct_num_only(je_tmp.Recordset.Fields("acct_num"), valid_acct)
        '            If valid_acct = "N" Then

        '                'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                MsgBox("You have an invalid GL account number in job or deduction tables = " & je_tmp.Recordset.Fields("acct_num").Value)
        '                Response = 1
        '            End If

        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.MoveNext()
        '        Loop
        '        '   MsgBox "total = " & tots(0)
        '        If tots(0) <> 0 Then 'plug amount to largest $ amount
        '            ' Response = 1
        '            'UPGRADE_ISSUE: Data property je_tmp.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.RecordSource = "select * from je_tmp order by dol_Amt desc"
        '            je_tmp.Refresh()
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.MoveFirst()
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.edit()
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Fields("dol_amt").Value = je_tmp.Recordset.Fields("dol_amt").Value - tots(0)
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            je_tmp.Recordset.Update()
        '        End If

        '        If Response = 1 Then
        '            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '            Exit Sub
        '        End If


        '        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '        MsgBox("J/E Prepared - Print J/E Pre Post Report")
        '        Command1.Focus()

        '	End Sub

        '	Private Sub txtfields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        '        '	Call ets_set_selected()
        '    End Sub

        '	Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        '		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        '		If KeyAscii = 13 Or KeyAscii = 9 Then

        '			If Len(txtfields.Text) = 0 Then
        '				System.Windows.Forms.SendKeys.Send("{tab}")
        '				KeyAscii = 0
        '				GoTo EventExitSub
        '			End If

        '			valid_Date = "N"
        '			senddate = txtfields.Text

        '            Call etsdate(senddate, valid_Date)

        '            If IsDate(valid_Date) Then
        '                txtfields.Text = valid_Date
        '            Else
        '                MsgBox(" Bad Date")
        '                Call ets_set_selected()
        '                GoTo EventExitSub
        '            End If
        '            System.Windows.Forms.SendKeys.Send("{tab}")
        '			KeyAscii = 0

        '		End If
        'EventExitSub: 
        '		eventArgs.KeyChar = Chr(KeyAscii)
        '		If KeyAscii = 0 Then
        '			eventArgs.Handled = True
        '		End If
        '	End Sub

        '	Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        '		Pr_num1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        '	End Sub

        '	Private Sub write_je_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles write_je.Click
        '		'this pushes je_Tmp to yrgenled
        '		'off to write the j/e
        '		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        '		If Response = 1 Then 'bad number or not = 0
        '			MsgBox("The JE will not be posted. It is out of balance and/or bad account number.")
        '			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '			Exit Sub
        '		End If

        '		On Error GoTo 0
        '		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        '		'UPGRADE_ISSUE: Data property je_tmp.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		je_tmp.RecordSource = "select * from je_tmp order by acct_num"
        '		je_tmp.Refresh()
        '		'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		je_tmp.Recordset.MoveFirst()
        '		'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		saved_Date = je_tmp.Recordset.Fields("chk_Date").Value
        '		tots(0) = 0
        '		num = 0

        '		On Error Resume Next

        '		'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		a = je_tmp.Recordset.Fields("acct_num").Value
        '		If Err.Number = 94 Then
        '			MsgBox("You have Bad Data and cannot continue!")
        '			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '			Exit Sub
        '		End If
        '		On Error GoTo 0


        '		Data1.Refresh()
        '		MsgBox("Note the number assigned to this Journal Entry:" & Val(Text1.Text) + 1)

        '		'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Do While Not je_tmp.Recordset.EOF
        '			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			If a = je_tmp.Recordset.Fields("acct_num").Value Then
        '				'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '				tots(0) = tots(0) + je_tmp.Recordset.Fields("dol_Amt").Value
        '			Else
        '				If tots(0) <> 0 Then
        '					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					yrgenled.Recordset.AddNew()
        '					num = num + 1
        '					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					yrgenled.Recordset.Fields("jrnl_num").Value = Val(Text1.Text) + 1
        '					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					yrgenled.Recordset.Fields("jrnl_line").Value = num
        '					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					yrgenled.Recordset.Fields("entry_type").Value = "SD"
        '					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					yrgenled.Recordset.Fields("jrnl_name").Value = "PR"
        '					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					yrgenled.Recordset.Fields("jrnl_src").Value = "PR"
        '					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					yrgenled.Recordset.Fields("acct_num").Value = a
        '					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					yrgenled.Recordset.Fields("amount").Value = tots(0)
        '					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					yrgenled.Recordset.Fields("jrnl_desc").Value = "Client Payroll"
        '					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					yrgenled.Recordset.Fields("oper_id").Value = "Auto"
        '					'yrgenled.Recordset.Fields("encum_Date") = je_tmp.Recordset.Fields("chk_Date")
        '					'changed per lynne sugar 2/18/2004
        '					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					yrgenled.Recordset.Fields("encum_Date").Value = txtfields.Text

        '					On Error Resume Next
        '					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					yrgenled.Recordset.Update()

        '				End If

        '				'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '				tots(0) = je_tmp.Recordset.Fields("dol_Amt").Value
        '				'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '				a = je_tmp.Recordset.Fields("acct_num").Value
        '			End If
        '			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			je_tmp.Recordset.MoveNext()
        '		Loop 
        '		'write out the last record if the amount <> 0
        '		If tots(0) <> 0 Then
        '			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			yrgenled.Recordset.AddNew()
        '			num = num + 1
        '			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			yrgenled.Recordset.Fields("jrnl_num").Value = Val(Text1.Text) + 1
        '			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			yrgenled.Recordset.Fields("jrnl_line").Value = num
        '			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			yrgenled.Recordset.Fields("entry_type").Value = "SD"
        '			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			yrgenled.Recordset.Fields("jrnl_name").Value = "PR"
        '			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			yrgenled.Recordset.Fields("jrnl_src").Value = "PR"
        '			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			yrgenled.Recordset.Fields("acct_num").Value = a
        '			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			yrgenled.Recordset.Fields("amount").Value = tots(0)
        '			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			yrgenled.Recordset.Fields("jrnl_desc").Value = "Client Payroll"
        '			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			yrgenled.Recordset.Fields("oper_id").Value = "Auto"
        '			'yrgenled.Recordset.Fields("encum_Date") = je_tmp.Recordset.Fields("chk_Date")
        '			'changed per lynne sugar 2/18/2004
        '			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			yrgenled.Recordset.Fields("encum_Date").Value = txtfields.Text
        '			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			yrgenled.Recordset.Update()
        '		End If


        '		'update the glpost with Y and ccckstub with je num

        '		sqlstmnt = "select * from ccckstub where pay_num = " & beg_chk_num

        '		'add the ending payroll number here if we want to do that later
        '		'UPGRADE_ISSUE: Data property ccckstub.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		ccckstub.RecordSource = sqlstmnt
        '		ccckstub.Refresh()
        '		'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		ccckstub.Recordset.MoveFirst()

        '		'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Do While Not ccckstub.Recordset.EOF
        '			'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			ccckstub.Recordset.edit()
        '			'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			ccckstub.Recordset.Fields("gl_post").Value = "Y"
        '			'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			ccckstub.Recordset.Fields("jrnl_num").Value = Val(Text1.Text) + 1
        '			'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			ccckstub.Recordset.Update()
        '			'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			ccckstub.Recordset.MoveNext()
        '		Loop 

        '		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        '		MsgBox("Journal Entry Done - Print J/E Just Created")

        '		write_je.Enabled = False



    End Sub
End Class