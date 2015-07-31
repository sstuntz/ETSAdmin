Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class arcominvgl_frm
	Inherits System.Windows.Forms.Form
	Public workshopdb As dao.Database
	'UPGRADE_WARNING: Arrays in structure workshopset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public workshopset As dao.Recordset
	Public sqlstmt As String
	Public gljrnldb As dao.Database 'this is the destination
	'UPGRADE_WARNING: Arrays in structure gljrnlset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public gljrnlset As dao.Recordset
	Public saved_date As Date
	
	
	
	
	Private Sub cmdAdd_Click()
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.AddNew()
	End Sub
	
	Private Sub cmdDelete_Click()
		'this may produce an error if you delete the last
		'record or the only record in the recordset
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.delete()
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.MoveNext()
	End Sub
	
	Private Sub cmdRefresh_Click()
		'this is really only needed for multi user apps
		Data1.Refresh()
	End Sub
	
	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
		'UPGRADE_ISSUE: Data method Data1.UpdateRecord was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.UpdateRecord()
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Bookmark = VB6.CopyArray(Data1.Recordset.LastModified)
		Command4.Focus()
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click 'lhw 3/26/97
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		If Response = 1 Then 'bad number or not = 0
			MsgBox("The JE will not be posted. It is out of balance and/or bad account number.")
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			Exit Sub
		End If
		
		'6 write to yrgenled and print report if bal = 0
		On Error GoTo 0
		'UPGRADE_ISSUE: Data property je_tmp.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		je_tmp.recordsource = "select * from je_tmp order by acct_num"
		je_tmp.Refresh()
		'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		je_tmp.Recordset.MoveFirst()
		'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		saved_date = je_tmp.Recordset.Fields("end_date").Value
		'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		tmp_Acct = je_tmp.Recordset.Fields("acct_num").Value
		tot_amt = 0
		high_je_num.Refresh()
		
		MsgBox("Note the number assigned to this Journal Entry:" & Val(Text1.Text) + 1)
		
		num = 0
		
		'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not je_tmp.Recordset.EOF
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			If Trim(tmp_Acct) = Trim(je_tmp.Recordset.Fields("acct_num").Value) Then
				'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				tot_amt = tot_amt + je_tmp.Recordset.Fields("dol_Amt").Value
			Else
				If tot_amt <> 0 Then
					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					yrgenled.Recordset.AddNew()
					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					yrgenled.Recordset.Fields("jrnl_num").Value = Val(Text1.Text) + 1
					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					yrgenled.Recordset.Fields("jrnl_line").Value = num + 1
					num = num + 1
					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					yrgenled.Recordset.Fields("entry_type").Value = "SD"
					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					yrgenled.Recordset.Fields("jrnl_name").Value = "AR"
					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					yrgenled.Recordset.Fields("jrnl_src").Value = "SA" 'CA for cash
					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					yrgenled.Recordset.Fields("acct_num").Value = tmp_Acct
					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					yrgenled.Recordset.Fields("amount").Value = tot_amt
					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					yrgenled.Recordset.Fields("jrnl_desc").Value = "AR Workshop"
					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					yrgenled.Recordset.Fields("oper_id").Value = "Auto"
					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					yrgenled.Recordset.Fields("encum_Date").Value = saved_date
					'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					yrgenled.Recordset.update()
					
				End If
				
				'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				tot_amt = je_tmp.Recordset.Fields("dol_Amt").Value
				'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				tmp_Acct = je_tmp.Recordset.Fields("acct_num").Value
			End If
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.MoveNext()
		Loop 
		'write out the last record if the amount <> 0
		If tot_amt <> 0 Then
			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			yrgenled.Recordset.AddNew()
			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			yrgenled.Recordset.Fields("jrnl_num").Value = Val(Text1.Text) + 1
			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			yrgenled.Recordset.Fields("jrnl_line").Value = num + 1
			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			yrgenled.Recordset.Fields("entry_type").Value = "SD"
			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			yrgenled.Recordset.Fields("jrnl_name").Value = "AR"
			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			yrgenled.Recordset.Fields("jrnl_src").Value = "SA" 'CA for cash
			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			yrgenled.Recordset.Fields("acct_num").Value = tmp_Acct
			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			yrgenled.Recordset.Fields("amount").Value = tot_amt
			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			yrgenled.Recordset.Fields("jrnl_desc").Value = "AR workshop"
			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			yrgenled.Recordset.Fields("oper_id").Value = "Auto"
			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			yrgenled.Recordset.Fields("encum_Date").Value = saved_date
			'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			yrgenled.Recordset.update()
		End If
		
		
		'7a  update glpost flag and put je num in each workshop record
		
		sqlstmt = "select * from workshop WHERE workshop.glpost <> 'Y' and workshop.void = 'N' "
		sqlstmt = sqlstmt & " and workshop.inv_date between "
		sqlstmt = sqlstmt & Chr(35) & txtField0(0).Text & Chr(35) & " and "
		sqlstmt = sqlstmt & Chr(35) & txtField1(1).Text & Chr(35) & " order by inv_num "
		
		'UPGRADE_ISSUE: Data property workshop.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		workshop.recordsource = sqlstmt
		workshop.Refresh()
		'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		workshop.Recordset.MoveFirst()
		
		'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not workshop.Recordset.EOF
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			workshop.Recordset.edit()
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			workshop.Recordset.Fields("jrnl_num").Value = Val(Text1.Text) + 1
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			workshop.Recordset.Fields("glpost").Value = "Y"
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			workshop.Recordset.update()
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			workshop.Recordset.MoveNext()
		Loop 
		
		Command2.Focus() '5/15/00  lhw
		Command1.Enabled = False
		
		MsgBox("J/E Complete!!! Print the J/E now.")
		
		
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		prtDestination = CStr(1)
		prtreportfilename = ar_report_path & "arcomjrnl.rpt"
		'  ' Call frmcrystal_Call
		
	End Sub
	
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "arjetmpcom.rpt"
		' Call frmcrystal_Call
	End Sub
	
	Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		'1 clean je_tmp first
		'2 this takes dr_acct_nu from workshop and moves it to je_tmp
		'3 this takes cr_acct_nu from workshop and moves it to je_tmp
		'4 test for total = 0 and valid account numbers
		'5 test for invalid account numbers and print error report
		'6 Get next JE# and Post to yrgenled
		'7 Print JE just created--separate command
		'7a update glpost and put je num in each workshop in set
		'some of the dim stmts were changed to public and are in the declarations
		
		
		'1 this cleans the je_tmp table
		je_tmp.Refresh()
		'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		If je_tmp.Recordset.RecordCount <> 0 Then
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.MoveFirst()
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Do While Not je_tmp.Recordset.EOF
				'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				je_tmp.Recordset.delete()
				'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				je_tmp.Recordset.MoveNext()
			Loop 
		End If
		
		'2 workshop data control on form
		'******this is the select changed 3-25-98
		sqlstmt = "select * from workshop WHERE workshop.glpost <> 'Y' and workshop.void <> 'Y' "
		sqlstmt = sqlstmt & " and workshop.inv_date between "
		sqlstmt = sqlstmt & Chr(35) & txtField0(0).Text & Chr(35) & " and "
		sqlstmt = sqlstmt & Chr(35) & txtField1(1).Text & Chr(35) & " order by workshop.dr_pref_ac "
		
		'UPGRADE_ISSUE: Data property workshop.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		workshop.recordsource = sqlstmt
		workshop.Refresh()
		On Error Resume Next
		'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		workshop.Recordset.MoveFirst()
		If Err.Number = 3021 Then
			MsgBox("All records for these dates have been posted to General Ledger")
			Response = 1
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			Exit Sub
		End If
		On Error GoTo 0
		
		
		
		
		'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not workshop.Recordset.EOF
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.AddNew()
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.Fields("acct_num").Value = workshop.Recordset.Fields("dr_pref_ac").Value
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.Fields("dol_amt").Value = workshop.Recordset.Fields("line_tot").Value
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.Fields("inv_num").Value = workshop.Recordset.Fields("inv_num").Value
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.Fields("line_num").Value = workshop.Recordset.Fields("line_num").Value
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.Fields("inv_date").Value = workshop.Recordset.Fields("inv_date").Value
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.Fields("end_date").Value = txtField1(1).Text
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.update()
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			workshop.Recordset.MoveNext()
		Loop 
		
		'3 move the credit records to je tmp
		'******this is the select changed 3-25-98
		sqlstmt = "select * from workshop WHERE workshop.glpost <> 'Y' and workshop.void = 'N' "
		sqlstmt = sqlstmt & " and workshop.inv_date between "
		sqlstmt = sqlstmt & Chr(35) & txtField0(0).Text & Chr(35) & " and "
		sqlstmt = sqlstmt & Chr(35) & txtField1(1).Text & Chr(35) & " order by workshop.cr_pref_ac "
		
		'UPGRADE_ISSUE: Data property workshop.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		workshop.recordsource = sqlstmt
		workshop.Refresh()
		On Error Resume Next
		'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		workshop.Recordset.MoveFirst()
		If Err.Number = 3021 Then
			MsgBox("All records for these dates have been posted to General Ledger")
			Response = 1
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			Exit Sub
		End If
		On Error GoTo 0
		
		
		'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not workshop.Recordset.EOF
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.AddNew()
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.Fields("acct_num").Value = workshop.Recordset.Fields("cr_pref_ac").Value
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.Fields("dol_amt").Value = workshop.Recordset.Fields("line_tot").Value * -1
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.Fields("inv_num").Value = workshop.Recordset.Fields("inv_num").Value
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.Fields("line_num").Value = workshop.Recordset.Fields("line_num").Value
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.Fields("inv_date").Value = workshop.Recordset.Fields("inv_date").Value
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.Fields("end_date").Value = txtField1(1).Text
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.update()
			'UPGRADE_ISSUE: Data property workshop.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			workshop.Recordset.MoveNext()
		Loop 
		
		MsgBox("Data is in JE TMP File")
		
		'4 now test the total to make sure it is zero
		tot_amt = 0
		Response = 0
		je_tmp.Refresh()
		'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		je_tmp.Recordset.MoveFirst()
		
		
		
		'5  test for valid account numbers and amt = 0
		
		'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not je_tmp.Recordset.EOF
			
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			tot_amt = tot_amt + je_tmp.Recordset.Fields("dol_amt").Value
			valid_acct = "N"
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Call chk_acct_num_only(je_tmp.Recordset.Fields("acct_num"), valid_acct)
			If valid_acct = "N" Then
				'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				MsgBox("You have an invalid account number = " & je_tmp.Recordset.Fields("acct_num").Value)
				Response = 1
			End If
			
			'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			je_tmp.Recordset.MoveNext()
		Loop 
		
		MsgBox("JE TMP Total = " & tot_amt)
		
		If tot_amt <> 0 Then
			Response = 1
		End If
		
		
		If Response = 1 Then 'bad number or not = 0
			
			MsgBox("The JE will not be posted. It is out of balance and/or bad account number.")
			MsgBox("You are about to print a detail report to help you find missing data")
			prtDestination = CStr(0)
			prtreportfilename = ar_report_path & "arjetmpcom.rpt"
			'  ' Call frmcrystal_Call
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			Exit Sub
		End If
		Command3.Focus()
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		
		
	End Sub
	
	Private Sub Command6_Click()
		
	End Sub
	
	'UPGRADE_ISSUE: Data event Data1.Error was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub Data1_Error(ByRef DataErr As Short, ByRef Response As Short)
		'This is where you would put error handling code
		'If you want to ignore errors, comment out the next line
		'If you want to trap them, add code here to handle them
		MsgBox("Data error event hit err:" & ErrorToString(DataErr))
		Response = 0 'throw away the error
	End Sub
	
	'UPGRADE_ISSUE: Data event Data1.Reposition was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub Data1_Reposition()
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		On Error Resume Next
		'This will display the current record position
		'for dynasets and snapshots
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Text = "Record: " & (Data1.Recordset.AbsolutePosition + 1)
		'for the table object you must set the index property when
		'the recordset gets created and use the following line
		'Data1.Caption = "Record: " & (Data1.Recordset.RecordCount * (Data1.Recordset.PercentPosition * 0.01)) + 1
	End Sub
	
	'UPGRADE_ISSUE: Data event Data1.Validate was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub Data1_Validate(ByRef Action As Short, ByRef save As Short)
		'This is where you put validation code
		'This event gets called when the following actions occur
		'UPGRADE_ISSUE: Constant vbDataActionClose was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_ISSUE: Constant vbDataActionBookmark was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_ISSUE: Constant vbDataActionFind was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_ISSUE: Constant vbDataActionDelete was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_ISSUE: Constant vbDataActionUpdate was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_ISSUE: Constant vbDataActionAddNew was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_ISSUE: Constant vbDataActionMoveLast was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_ISSUE: Constant vbDataActionMoveNext was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_ISSUE: Constant vbDataActionMovePrevious was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		'UPGRADE_ISSUE: Constant vbDataActionMoveFirst was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		Select Case Action
			Case vbDataActionMoveFirst
			Case vbDataActionMovePrevious
			Case vbDataActionMoveNext
			Case vbDataActionMoveLast
			Case vbDataActionAddNew
			Case vbDataActionUpdate
			Case vbDataActionDelete
			Case vbDataActionFind
			Case vbDataActionBookmark
			Case vbDataActionClose
		End Select
		'Screen.MousePointer = vbHourglass
	End Sub
	
	Private Sub arcominvgl_frm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		' data1 = ar
		On Error Resume Next
		
		'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For num = 0 To Me.Controls.Count() - 1
			'UPGRADE_ISSUE: Data object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.Label Then
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sqlstmnt = VB.Right(CType(Me.Controls(num), Object).DatabaseName, Len(CType(Me.Controls(num), Object).DatabaseName) - 20)
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CType(Me.Controls(num), Object).DatabaseName = ap_data_path & sqlstmnt
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().recordsource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Len(CType(Me.Controls(num), Object).recordsource) > 0 Then
					CType(Me.Controls(num), Object).Refresh()
				End If
			End If
			
		Next 
		
	End Sub
	
	Private Sub txtField0_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField0.Enter
		Dim Index As Short = txtField0.GetIndex(eventSender)
		Call ets_set_selected()
	End Sub
	
	
	Private Sub txtField0_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField0.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtField0.GetIndex(eventSender)
		If KeyAscii = 13 Then
			valid_Date = "N"
			senddate = txtField0(Index).Text
			Call etsdate(senddate, retdate, valid_Date)
			
			If valid_Date <> "N" Then
				txtField0(Index).Text = retdate
				txtField0(Index).Text = CStr(CDate(txtField0(Index).Text))
				
				
				
				System.Windows.Forms.SendKeys.Send("{tab}")
				KeyAscii = 0
			Else
				MsgBox("Bad date")
				Call ets_set_selected()
				GoTo EventExitSub
			End If
		End If
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtField0_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField0.Leave
		Dim Index As Short = txtField0.GetIndex(eventSender)
		txtField0(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub txtField1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField1.Enter
		Dim Index As Short = txtField1.GetIndex(eventSender)
		'this is rpthead.end_date
		txtField1(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		txtField1(Index).SelectionStart = 0
		txtField1(Index).SelectionLength = Len(txtField1(Index).Text)
	End Sub
	
	Private Sub txtField1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField1.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtField1.GetIndex(eventSender)
		If KeyAscii = 13 Then
			valid_Date = "N"
			senddate = txtField1(Index).Text
			Call etsdate(senddate, retdate, valid_Date)
			
			If valid_Date <> "N" Then
				txtField1(Index).Text = retdate
				txtField1(Index).Text = CStr(CDate(txtField1(Index).Text))
				
				
				
				System.Windows.Forms.SendKeys.Send("{tab}")
				KeyAscii = 0
			Else
				MsgBox("Bad date")
				Call ets_set_selected()
				GoTo EventExitSub
			End If
		End If
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	
	
	Private Sub txtField1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField1.Leave
		Dim Index As Short = txtField1.GetIndex(eventSender)
		txtField1(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		cmdUpdate.Focus()
	End Sub
End Class