Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class arinvvd_frm1
	Inherits System.Windows.Forms.Form
	Public rowvalue, colvalue As Object
	Public tot_amt As Decimal
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
	Public selected_inv_num As String
	
	
	
	
	
	
	Public Sub rebuild_grid()
		
		'  For num = Grid1.Rows - 1 To 1 Step -1
		'    Grid1.RemoveItem num
		'    Next
		'
		'
		'    Grid1.AddItem "inv_num" & Chr(9) & "trans_code" & Chr(9) & "name_key" & Chr(9) & "screen_nam" & Chr(9) & "cc_num" & Chr(9) & "cc_name" & Chr(9) & "inv_Desc" & Chr(9) & "glpost" & Chr(9), 0
		'
		'Data1.recordsource = "select * from invoice where dflag = 'N' and paid = 'N' and line_num = 1 and void = 'N' order by  inv_num"
		'   Data1.Refresh
		'
		'
		'
		'        num = 1
		'        Data1.Recordset.MoveFirst
		'        Do While Not Data1.Recordset.EOF
		'        'put in the data for the grid
		'        Grid1.AddItem Data1.Recordset.Fields("inv_num") & Chr(9) & Data1.Recordset.Fields("trans_code") & Chr(9) & Data1.Recordset.Fields("name_key") & Chr(9) & Data1.Recordset.Fields("screen_nam") & Chr(9) & Data1.Recordset.Fields("cc_num") & Chr(9) & Data1.Recordset.Fields("cc_name") & Chr(9) & Data1.Recordset.Fields("inv_Desc") & Chr(9) & Data1.Recordset.Fields("glpost"), num
		'
		'        Data1.Recordset.MoveNext
		'        num = num + 1
		'        Loop
		'        Grid1.RemoveItem num
		'        selectedcell = False
		'
		'        'fix sizes and number of columns
		'
		'        Grid1.ColWidth(0) = 1000
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
	
	Private Sub arinvvd_frm1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
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
		
		
		'UPGRADE_ISSUE: Data property Data1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.recordsource = "select * from invoice where dflag = 'N' and paid = 'N' and line_num = 1 and void = 'N' order by  inv_num"
		Data1.Refresh()
		
		db = ar_data_path & "ar.mdb"
		cashdb = DAODBEngine_definst.OpenDatabase(db)
		cashset = cashdb.OpenRecordset("cash", dao.RecordsetTypeEnum.dbOpenDynaset)
		
		invoicedb = DAODBEngine_definst.OpenDatabase(db)
		invoiceset = invoicedb.OpenRecordset("invoice", dao.RecordsetTypeEnum.dbOpenDynaset)
		
		Call rebuild_grid()
		
	End Sub
	
	
	Private Sub reinvoice_Click()
		selected_invoice = save_invoice_num
		'a invoice that was paid even if input as paid can not be edited
		
		void_invoice = "Y"
		'recreate the voided invoice with a new invoice number and new fields
		'UPGRADE_ISSUE: Data property Data1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.recordsource = " select * from invoice where inv_num = " & save_invoice_num
		Data1.Refresh()
		invoiceset = invoicedb.OpenRecordset("invoice", dao.RecordsetTypeEnum.dbOpenDynaset)
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.MoveFirst()
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		If Data1.Recordset.Fields("void").Value <> "Y" Then
			MsgBox("The invoice has not been voided")
			Exit Sub
		Else
			
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Do While Not Data1.Recordset.EOF
				invoiceset.AddNew()
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				For num = 0 To Data1.Recordset.Fields.Count - 1
					'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoiceset.Fields(num).Value = Data1.Recordset.Fields(num).Value
				Next 
				'xxxx how are going to number a new invoice
				'        invoiceset.Fields("inv_num") = X
				invoiceset.Fields("void").Value = "N"
				invoiceset.Fields("jrnl_num").Value = "0"
				invoiceset.Fields("jrnl_line").Value = "0"
				'        invoiceset.Fields("gl_post") = "N"
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Data1.Recordset.MoveNext()
			Loop 
		End If
		
		
		
		
		
		Me.Close()
		
	End Sub
	
	Private Sub void_gl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_gl.Click
		'         Grid1.Col = 0
		'       selected_inv_num = Grid1.Text
		'        Grid1.Col = 7
		'       glposted = Grid1.Text
		
		If selected_inv_num = "" Then
			MsgBox("Nothing selected")
			Exit Sub
		End If
		
		If glposted <> "Y" Then
			MsgBox("Item has not been posted to the General Ledger.")
			Exit Sub
		End If
		
		
		Response = MsgBox("Are you sure that you want to void this invoice?", 256 + 4)
		If Response = 7 Then
			Exit Sub
		End If
		
		'in cash table set these flags for all records
		'set void_chk to "Y"
		save_invoice_num = selected_inv_num 'DBGrid1.Columns(0).CellText(DBGrid1.RowBookmark(rowvalue))
		
		'in invoice table
		'set invoice.paid to "N"
		'set dt_paid to blank
		sqlstmnt = " select * from invoice where inv_num = " & save_invoice_num
		invoiceset = invoicedb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
		invoiceset.MoveFirst()
		
		'open the general ledger here so loop can write to it
		db = gl_data_path & "gljrnl.mdb"
		jedb = DAODBEngine_definst.OpenDatabase(db)
		jeset = jedb.OpenRecordset("yrgenled")
		
		'put all the data  into an array so can write out each record with a for loop
		Dim a(25) As String
		
		Dim jeline As Integer 'line counter for the journal entry
		jeline = 0
		
		Do While Not invoiceset.EOF
			'rewrite all the invoices to no
			invoiceset.edit()
			invoiceset.Fields("void").Value = "Y"
			invoiceset.Fields("glpost").Value = "N" 'added 10/14/99 lhw
			invoiceset.update()
			jeline = jeline + 1
			'Loop   normally loop would end here but we need tocycle thru each record to reverse the acct number entry in gl
			
			'create a reversing J/E for the voided invoice
			'get the highest journal entry number
			'write the j/e details out and description
			'the desc will include the chk_num
			'get the bank gl acct number from the bank key
			'get the a/p control number from cust
			'fields in array
			a(0) = CStr(Val(high_je_num.Text) + 1)
			a(1) = CStr(0)
			a(2) = "AD"
			a(3) = "VOID"
			a(4) = "AR"
			a(5) = CStr(Today) 'jeset.Fields("entry_Date") = Now()
			a(6) = CStr(Today) 'jeset.Fields("encum_date") = Now()
			a(7) = "01/01/1901" ' a(7) jeset.fields("post_date") = ""
			a(8) = ""
			a(9) = CStr(0)
			a(10) = "Void INV# " & save_invoice_num 'eset.Fields("jrnl_desc")
			a(11) = "COMP" 'jeset.Fields("oper_id") = "COMP"
			a(12) = "N" 'jeset.Fields("a_post") = "N"
			a(13) = "N" 'jeset.Fields("post") = "N"
			a(14) = "N" 'jeset.Fields("dflag") = "N"
			a(15) = "N" 'jeset.Fields("void") = "N"
			
			jeset.AddNew()
			
			For num = 0 To 15
				jeset.Fields(num).Value = a(num)
			Next 
			
			jeset.Fields("jrnl_line").Value = jeline 'a(1)
			jeset.Fields("Acct_num").Value = invoiceset.Fields("cr_acct_nu").Value 'a(8)
			jeset.Fields("amount").Value = invoiceset.Fields("alloc_amt").Value 'a(9)
			tot_amt = tot_amt + invoiceset.Fields("alloc_amt").Value 'added tot_amt to this line 11/27/00 lhw
			'this was inv_amt and has always been blank
			jeset.update()
			invoiceset.MoveNext()
		Loop 
		
		'this puts in the debit item
		'added next three lines 11/27/00 lhw
		sqlstmnt = " select * from invoice where inv_num = " & save_invoice_num
		invoiceset = invoicedb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
		invoiceset.MoveFirst()
		
		jeset.AddNew()
		
		For num = 0 To 15
			jeset.Fields(num).Value = a(num)
		Next 
		
		jeset.Fields("jrnl_line").Value = jeline + 1 'a(1)
		jeset.Fields("amount").Value = tot_amt * -1 'a(9)  this is the offset
		jeset.Fields("acct_num").Value = invoiceset.Fields("dr_acct_nu").Value
		jeset.update()
		
		'write invoice# to rpthead      in cash void we use ar_rpthead
		db = ar_data_path & "ar.mdb"
		tmpdb = DAODBEngine_definst.OpenDatabase(db)
		tmpset = tmpdb.OpenRecordset("ar_rpthead", dao.RecordsetTypeEnum.dbOpenDynaset)
		tmpset.edit()
		tmpset.Fields("beg_num").Value = save_invoice_num
		
		'why is this code here !!!!!!!!!!  when was this changed
		'    jeset.Fields("acct_num") = tmpset.Fields("dr_acct_nu")
		'    jeset.Update
		
		
		Data1.Refresh()
		MsgBox("You are about to print two reports.  Make sure your printer is online.")
		prtDestination = CStr(1)
		prtreportfilename = ar_report_path & "arinvvoid.rpt"
		'' Call frmcrystal_Call
		prtDestination = CStr(1)
		prtreportfilename = ar_report_path & "arivjrnl.rpt"
		'' Call frmcrystal_Call
	End Sub
	
	Private Sub void_no_gl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_no_gl.Click
		
		'      Grid1.Col = 0
		'       selected_inv_num = Grid1.Text
		'        Grid1.Col = 7
		'       glposted = Grid1.Text
		'
		If selected_inv_num = "" Then
			MsgBox("Nothing selected")
			Exit Sub
		End If
		
		If glposted <> "N" Then
			MsgBox("Item has been posted to the General Ledger.")
			Exit Sub
		End If
		
		Response = MsgBox("Are you sure that you want to void this invoice?", 256 + 4)
		If Response = 7 Then
			Exit Sub
		End If
		
		save_invoice_num = selected_inv_num 'DBGrid1.Columns(0).CellText(DBGrid1.RowBookmark(rowvalue))
		
		'in invoice table
		'set invoice.void to "N"
		
		sqlstmnt = " select * from invoice where inv_num = " & save_invoice_num
		invoiceset = invoicedb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
		invoiceset.MoveFirst()
		
		Do While Not invoiceset.EOF
			'rewrite all the invoices to no
			invoiceset.edit()
			invoiceset.Fields("void").Value = "Y"
			invoiceset.update()
			invoiceset.MoveNext()
		Loop 
		
		Data1.Refresh()
		
		MsgBox("You are about to print a report.  Make sure your printer is online.")
		'write invoice# to ar_rpthead
		db = ar_data_path & "ar.mdb"
		tmpdb = DAODBEngine_definst.OpenDatabase(db)
		tmpset = tmpdb.OpenRecordset("ar_rpthead", dao.RecordsetTypeEnum.dbOpenDynaset)
		tmpset.edit()
		tmpset.Fields("beg_num").Value = save_invoice_num
		tmpset.update()
		'print report and added line above
		prtDestination = CStr(1)
		prtreportfilename = ar_report_path & "arinvvoid.rpt"
		'  ' Call frmcrystal_Call
	End Sub
End Class