Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class arcashvd_frm1
	Inherits System.Windows.Forms.Form
	Public rowvalue, colvalue As Object
	Public cashdb As dao.Database
	'UPGRADE_WARNING: Arrays in structure cashset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public cashset As dao.Recordset
	Public sqlstmt As String
	Public gljrnldb As dao.Database 'this is the destination
	'UPGRADE_WARNING: Arrays in structure gljrnlset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public gljrnlset As dao.Recordset
	Public nambankdb As dao.Database
	'UPGRADE_WARNING: Arrays in structure nambankset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public nambankset As dao.Recordset
	Public etssysdb As dao.Database
	'UPGRADE_WARNING: Arrays in structure etssysset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public etssysset As dao.Recordset
	Public invoicedb As dao.Database
	'UPGRADE_WARNING: Arrays in structure invoiceset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public invoiceset As dao.Recordset
	'UPGRADE_WARNING: Arrays in structure tmp1set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public tmp1set As dao.Recordset
	Public tmp1db As dao.Database
	Public glposted As String
	Public selected_cash_rct As String
	Public sel_bat_num As String
	Public sel_ent_num As String
	
	
	
	
	
	Public Sub rebuild_grid()
		'
		'  For num = Grid1.Rows - 1 To 1 Step -1
		'    Grid1.RemoveItem num
		'    Next
		'
		'
		'    Grid1.AddItem "cr_acct_num" & Chr(9) & "Check_num" & Chr(9) & "Customer Name" & Chr(9) & "Check Date" & Chr(9) & "Check amt" & Chr(9) & "glpost" & Chr(9) & "batch_num" & Chr(9) & "entry_num" & Chr(9), 0
		'
		'sqlstmnt = "select * from cash where dflag = 'N' and void_chk = 'N' "
		'    sqlstmnt = sqlstmnt & " and len(chk_num) > 0 and isnumeric(chk_num) order by chk_num"
		'    data1.recordsource = sqlstmnt
		'    data1.Refresh
		'
		'        num = 1
		'        data1.Recordset.MoveFirst
		'        Do While Not data1.Recordset.EOF
		'        'put in the data for the grid
		'        Grid1.AddItem data1.Recordset.Fields("cr_acct_nu") & Chr(9) & data1.Recordset.Fields("chk_num") & Chr(9) & data1.Recordset.Fields("screen_nam") & Chr(9) & data1.Recordset.Fields("chk_Date") & Chr(9) & data1.Recordset.Fields("check_amt") & Chr(9) & data1.Recordset.Fields("glpost") & Chr(9) & data1.Recordset.Fields("batch_num") & Chr(9) & data1.Recordset.Fields("entry_num"), num
		'
		'        data1.Recordset.MoveNext
		'        num = num + 1
		'        Loop
		'        Grid1.RemoveItem num
		'        selectedcell = False
		'
		'        'fix sizes and number of columns
		'
		'        Grid1.ColWidth(0) = 1500
		'        Grid1.ColWidth(1) = 500
		'        Grid1.ColWidth(2) = 1000
		'        Grid1.ColWidth(3) = 1500
		'        Grid1.ColWidth(4) = 1000
		'        Grid1.ColWidth(5) = 1500
		'         Grid1.ColWidth(6) = 1500
		'         Grid1.ColWidth(7) = 500
		'
		'
		'        Grid1.TopRow = temp_row
		'        Grid1.Row = actual_row
		
	End Sub
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		Me.Close()
		
	End Sub
	
	Private Sub arcashvd_frm1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		' data1 = ar
		' data2 = gljrnl
		On Error Resume Next
		
		'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For num = 0 To Me.Controls.Count() - 1
			'UPGRADE_ISSUE: Data object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.Label Then
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sqlstmnt = VB.Right(CType(Me.Controls(num), Object).DatabaseName, Len(CType(Me.Controls(num), Object).DatabaseName) - 20)
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CType(Me.Controls(num), Object).DatabaseName = ar_data_path & sqlstmnt
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().recordsource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Len(CType(Me.Controls(num), Object).recordsource) > 0 Then
					CType(Me.Controls(num), Object).Refresh()
				End If
			End If
			
		Next 
		
		sqlstmnt = "select * from cash where dflag = 'N' and void_chk = 'N' "
		sqlstmnt = sqlstmnt & " and len(chk_num) > 0 and isnumeric(chk_num) order by chk_num"
		'UPGRADE_ISSUE: Data property Data1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.recordsource = sqlstmnt
		Data1.Refresh()
		
		db = ar_data_path & "ar.mdb"
		cashdb = DAODBEngine_definst.OpenDatabase(db)
		cashset = cashdb.OpenRecordset("cash", dao.RecordsetTypeEnum.dbOpenDynaset)
		
		invoicedb = DAODBEngine_definst.OpenDatabase(db)
		invoiceset = invoicedb.OpenRecordset("invoice", dao.RecordsetTypeEnum.dbOpenDynaset)
		
		Call rebuild_grid()
		
	End Sub
	
	
	Private Sub void_gl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_gl.Click
		'         Grid1.Col = 1
		'       selected_cash_rct = Grid1.Text
		'        Grid1.Col = 5
		'       glposted = Grid1.Text
		'
		'        Grid1.Col = 6
		'       sel_bat_num = Grid1.Text
		'
		'        Grid1.Col = 7
		'       sel_ent_num = Grid1.Text
		
		
		If selected_cash_rct = "" Then
			MsgBox("Nothing selected")
			Exit Sub
			
		End If
		
		If glposted <> "Y" Then
			MsgBox("Item has not been posted to the General Ledger.")
			Exit Sub
		End If
		
		
		Response = MsgBox("Are you sure that you want to void this check?", 256 + 4)
		If Response = 7 Then
			Exit Sub
		End If
		
		'in cash table set these flags for all records
		'set void_chk to "Y" and dt_cleared to sysdate
		
		sqlstmnt = " chk_num = " & Chr(34) & selected_cash_rct & Chr(34)
		sqlstmnt = sqlstmnt & " and entry_num = " & sel_ent_num
		sqlstmnt = sqlstmnt & " and batch_num = " & sel_bat_num 'DBGrid1.Columns(8).CellText(DBGrid1.RowBookmark(rowvalue))
		
		cashset.FindFirst(sqlstmnt)
		If cashset.NoMatch Then
			MsgBox("System can not find check. No voiding done.")
			Exit Sub
		End If
		
		cashset.FindNext(sqlstmnt) 'to check for duplicates
		If cashset.NoMatch Then
			
			cashset.FindFirst(sqlstmnt)
			save_invoice_num = cashset.Fields("inv_num").Value
			cashset.edit()
			cashset.Fields("void_chk").Value = "Y"
			cashset.update()
		Else
			MsgBox("More than one check with this number.  Call ETS.")
			Exit Sub
		End If
		
		'in invoice table
		'set invoice.paid to "N"
		
		sqlstmnt = " select * from invoice where inv_num = " & save_invoice_num
		invoiceset = invoicedb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
		
		If Not invoiceset.EOF Then
			invoiceset.MoveFirst()
			
			Do While Not invoiceset.EOF
				'rewrite all the invoices to no
				invoiceset.edit()
				invoiceset.Fields("paid").Value = "N"
				invoiceset.Fields("bal_due").Value = invoiceset.Fields("bal_due").Value + cashset.Fields("chk_alloc").Value
				invoiceset.Fields("pay_amt").Value = 0
				invoiceset.update()
				invoiceset.MoveNext()
			Loop 
			
		End If
		
		
		'create a reversing J/E for the voided check
		'get the highest journal entry number
		'write the j/e details out and description
		'the desc will include the chk_num
		'get the bank gl acct number from the bank key
		'get the ar control number from invoice
		
		db = gl_data_path & "gljrnl.mdb"
		jedb = DAODBEngine_definst.OpenDatabase(db)
		jeset = jedb.OpenRecordset("yrgenled")
		
		jeset.AddNew()
		jeset.Fields("jrnl_num").Value = Val(high_je_num.Text) + 1
		jeset.Fields("jrnl_line").Value = 1
		jeset.Fields("entry_type").Value = "AD"
		jeset.Fields("jrnl_name").Value = "VOID"
		jeset.Fields("jrnl_src").Value = "AR"
		'acct num and amount are below
		jeset.Fields("entry_Date").Value = Today
		jeset.Fields("encum_date").Value = Today
		'jeset.fields("post_date") = ""
		jeset.Fields("jrnl_desc").Value = "Void CK# " & cashset.Fields("chk_num").Value
		jeset.Fields("oper_id").Value = "Void Ck"
		jeset.Fields("a_post").Value = "N"
		jeset.Fields("post").Value = "N"
		jeset.Fields("dflag").Value = "N"
		jeset.Fields("void").Value = "N"
		
		db = gl_data_path & "glname.mdb"
		tmpdb = DAODBEngine_definst.OpenDatabase(db)
		tmpset = tmpdb.OpenRecordset("nam_bank", dao.RecordsetTypeEnum.dbOpenDynaset)
		sqlstmnt = "bank_key = " & Chr(34) & cashset.Fields("bank_key").Value & Chr(34)
		tmpset.FindFirst(sqlstmnt)
		
		'create a credit to the bank
		jeset.Fields("Acct_num").Value = tmpset.Fields("dr_pref_ac").Value 'bank
		jeset.Fields("amount").Value = cashset.Fields("check_amt").Value * -1
		
		If Val(cashset.Fields("chk_Disc").Value) <> 0 Then
			jeset.AddNew()
			'credit for a discount if any
			jeset.Fields("jrnl_num").Value = Val(high_je_num.Text) + 1
			jeset.Fields("jrnl_line").Value = 3
			jeset.Fields("entry_type").Value = "AD"
			jeset.Fields("jrnl_name").Value = "VOID"
			jeset.Fields("jrnl_src").Value = "AR"
			jeset.Fields("entry_Date").Value = Today
			jeset.Fields("encum_date").Value = Today
			jeset.Fields("jrnl_desc").Value = "Void CK# " & cashset.Fields("chk_num").Value
			jeset.Fields("oper_id").Value = "COMP"
			jeset.Fields("a_post").Value = "N"
			jeset.Fields("post").Value = "N"
			jeset.Fields("dflag").Value = "N"
			jeset.Fields("void").Value = "N"
			jeset.Fields("Acct_num").Value = tmpset.Fields("cr_pref_ac").Value ' bank
			jeset.Fields("amount").Value = cashset.Fields("chk_disc").Value * -1
			jeset.update()
			
		End If
		
		jeset.AddNew()
		jeset.Fields("jrnl_num").Value = Val(high_je_num.Text) + 1
		jeset.Fields("jrnl_line").Value = 2
		jeset.Fields("entry_type").Value = "AD"
		jeset.Fields("jrnl_name").Value = "VOID"
		jeset.Fields("jrnl_src").Value = "AR"
		jeset.Fields("entry_Date").Value = Today
		jeset.Fields("encum_date").Value = Today
		jeset.Fields("jrnl_desc").Value = "For Void Chk # " & cashset.Fields("chk_num").Value
		jeset.Fields("oper_id").Value = "COMP"
		jeset.Fields("a_post").Value = "N"
		jeset.Fields("post").Value = "N"
		jeset.Fields("dflag").Value = "N"
		jeset.Fields("void").Value = "N"
		'lhw to trap for misc cash item that has no invoice 4/25/01
		'on error resume next
		jeset.Fields("acct_num").Value = invoiceset.Fields("dr_acct_nu").Value 'ar-control #
		'If err = 3021 Then
		'jeset.Fields("acct_num") = cashset.Fields("cr_acct_nu") 'debit misc income #
		'End If
		jeset.Fields("amount").Value = Val(cashset.Fields("chk_alloc").Value)
		jeset.update()
		
		Data1.Refresh()
		
		MsgBox("You are about to print two reports.  Make sure your printer is online.")
		'write check# to ar_rpthead
		db = ar_data_path & "ar.mdb"
		tmp1db = DAODBEngine_definst.OpenDatabase(db)
		tmp1set = tmp1db.OpenRecordset("ar_rpthead", dao.RecordsetTypeEnum.dbOpenDynaset)
		tmp1set.edit()
		tmp1set.Fields("chk_num").Value = cashset.Fields("chk_num").Value
		tmp1set.update()
		'print two reports
		prtDestination = CStr(1)
		prtreportfilename = ar_report_path & "arckvoid.rpt"
		'  ' Call frmcrystal_Call              'void check report
		prtDestination = CStr(1)
		prtreportfilename = ar_report_path & "arcvjrnl.rpt"
		'  ' Call frmcrystal_Call               'printout of j/e
		
	End Sub
	
	Private Sub void_no_gl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_no_gl.Click
		
		
		'     Grid1.Col = 1
		'       selected_cash_rct = Grid1.Text
		'     Grid1.Col = 5
		'       glposted = Grid1.Text
		'
		'        Grid1.Col = 6
		'       sel_bat_num = Grid1.Text
		'
		'        Grid1.Col = 7
		'       sel_ent_num = Grid1.Text
		
		If selected_cash_rct = "" Then
			MsgBox("Nothing selected")
			Exit Sub
		End If
		
		If glposted <> "N" Then
			MsgBox("Item has been posted to the General Ledger.")
			Exit Sub
		End If
		Response = MsgBox("Are you sure that you want to void this check?", 256 + 4)
		If Response = 7 Then
			Exit Sub
		End If
		
		'in cash table set these flags for all records
		
		sqlstmnt = " chk_num = " & Chr(34) & selected_cash_rct & Chr(34)
		' sqlstmnt = sqlstmnt & " and entry_num = " & dbgrid1.Columns(8).CellText(dbgrid1.RowBookmark(rowvalue))
		sqlstmnt = sqlstmnt & " and batch_num = " & sel_bat_num 'DBGrid1.Columns(8).CellText(DBGrid1.RowBookmark(rowvalue))
		
		'first i find how many invoices were paid with this check
		'then i set paid flag to no and amount back to bal due
		
		tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
		tmpset = tmpdb.OpenRecordset("select * from cash where " & sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
		
		cashset.FindFirst(sqlstmnt)
		
		If cashset.NoMatch Then
			MsgBox("System can not find check. No voiding done.")
			Exit Sub
		End If
		
		'xxx check for multiple name keys - ie it means that two customers used the same check num
		'if multiple then little msg box that drops down for a choice of which name
		' and reqequensce the void
		
		
		Do While Not tmpset.EOF
			
			tmpset.edit()
			tmpset.Fields("void_chk").Value = "Y"
			tmpset.update()
			
			'in invoice table
			'set invoice.paid to "N"
			
			sqlstmnt = " select * from invoice where inv_num = " & tmpset.Fields("inv_num").Value
			sqlstmnt = sqlstmnt & " and line_num = " & tmpset.Fields("line_num").Value
			
			invoiceset = invoicedb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
			
			If Not invoiceset.EOF Then
				invoiceset.MoveFirst()
				
				Do While Not invoiceset.EOF
					'rewrite all the invoices to no
					invoiceset.edit()
					invoiceset.Fields("paid").Value = "N"
					invoiceset.Fields("bal_due").Value = invoiceset.Fields("bal_due").Value + tmpset.Fields("chk_alloc").Value
					invoiceset.Fields("pay_amt").Value = 0
					invoiceset.update()
					invoiceset.MoveNext()
				Loop 
				
			End If
			tmpset.MoveNext()
		Loop  ' end for invoices in cash
		
		Data1.Refresh()
		
		MsgBox("You are about to print a report.  Make sure your printer is online.")
		
		'write check# to ar_rpthead
		db = ar_data_path & "ar.mdb"
		tmp1db = DAODBEngine_definst.OpenDatabase(db)
		tmp1set = tmp1db.OpenRecordset("ar_rpthead", dao.RecordsetTypeEnum.dbOpenDynaset)
		tmp1set.edit()
		tmp1set.Fields("chk_num").Value = cashset.Fields("chk_num").Value
		tmp1set.update()
		
		prtDestination = CStr(1)
		prtreportfilename = ar_report_path & "arckvoid.rpt"
		'  ' Call frmcrystal_Call
		
		
		
	End Sub
End Class