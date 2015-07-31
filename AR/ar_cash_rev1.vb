Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class ar_cash_rev1
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 5/19/98 - SCS
	
	'****************
	Public rowvalue, colvalue As Object
	Public new_batch_tot As Double
	Public saved_chk_num As Object
	Public saved_inv_num As Integer
	Public saved_line_num As Integer
	Public saved_new_amt As Double
	Public saved_bat_num As Integer 'the new batch
	
	Public glposted As String
	Public selected_inv_num As String
	
	
	Public Sub rebuild_grid()
		
		'  For num = Grid1.Rows - 1 To 1 Step -1
		'    Grid1.RemoveItem num
		'    Next
		'
		'
		'    Grid1.AddItem "inv_num" & Chr(9) & "line" & Chr(9) & "invoice" & Chr(9) & "sort_name" & Chr(9) & "paid_Date" & Chr(9) & "alloc_Amt" & Chr(9) & "bal_due" & Chr(9) & "pay_Amt" & Chr(9) & "chk_num" & Chr(9) & "bank_name" & Chr(9) & "inv_amt" & Chr(9) & "paid" & Chr(9) & "glpost" & Chr(9), 0
		'   ' invoice.RecordSource = " select * from invoice where inv_num > 0 and pay_amt <> 0 order by inv_num, line_num "
		'
		'   invoice.Refresh
		'
		'
		'
		'        num = 1
		'        invoice.Recordset.MoveFirst
		'        Do While Not invoice.Recordset.EOF
		'        'put in the data for the grid
		'        Grid1.AddItem invoice.Recordset.Fields("inv_num") & Chr(9) & invoice.Recordset.Fields("line_num") & Chr(9) & invoice.Recordset.Fields("invoice") & Chr(9) & invoice.Recordset.Fields("sort_name") & Chr(9) & invoice.Recordset.Fields("paid_Date") & Chr(9) & invoice.Recordset.Fields("alloc_amt") & Chr(9) & invoice.Recordset.Fields("bal_due") & Chr(9) & invoice.Recordset.Fields("pay_Amt") & Chr(9) & invoice.Recordset.Fields("chk_num") & Chr(9) & invoice.Recordset.Fields("bank_name") & Chr(9) & invoice.Recordset.Fields("inv_amt") & Chr(9) & invoice.Recordset.Fields("paid") & Chr(9) & invoice.Recordset.Fields("glpost"), num
		'
		'        invoice.Recordset.MoveNext
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
		'         Grid1.ColWidth(8) = 500
		'          Grid1.ColWidth(9) = 500
		'           Grid1.ColWidth(10) = 500
		'            Grid1.ColWidth(11) = 500
		'             Grid1.ColWidth(12) = 500
		'
		'        Grid1.TopRow = temp_row
		'        Grid1.Row = actual_row
		
	End Sub
	
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	
	
	
	'Private Sub grid1_Click()
	'
	'  '  saved_inv_num = dbgrid1.Columns(0).CellText(dbgrid1.RowBookmark(rowvalue))
	'  '  saved_line_num = dbgrid1.Columns(1).CellText(dbgrid1.RowBookmark(rowvalue))
	'  Grid1.Col = 7
	'  new_amt = Format(Val(Grid1.Text), "FIXED")
	''new_amt = Format(Val(DBGrid1.Columns(7).CellText(DBGrid1.RowBookmark(rowvalue))), "FIXED")
	'new_Date = ""
	'new_amt.SetFocus
	'
	'
	'    'new_Date = ""
	'    'SendKeys "{TAB}"
	'    'KeyAscii = 0
	'
	'End Sub
	
	Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Edit.Click
		
		'  Grid1.Col = 0
		
		'    If err = 6028 Or Grid1.Text = "" Then
		'    MsgBox "You must select an item for reversing."
		'    Exit Sub
		'    End If
		'    On Error GoTo 0
		
		tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
		tmpset = tmpdb.OpenRecordset("cash", dao.RecordsetTypeEnum.dbOpenDynaset)
		
		On Error Resume Next 'lhw 99
		
		'  Grid1.Col = 0
		'we now do not allow editing of items with multiple items on one check
		' sqlstmnt = "Select * from cash where inv_num = " & Grid1.Text 'DBGrid1.Columns(0).CellText(DBGrid1.RowBookmark(rowvalue))
		' If err = 6148 Or Grid1.Text = "" Then        'added this and next 4 lines lhw
		'  MsgBox "You must select an item for reversing."
		' Exit Sub
		'End If
		'  On Error GoTo 0
		
		' Grid1.Col = 1
		'sqlstmnt = sqlstmnt & " and line_num = " & Grid1.Text 'DBGrid1.Columns(1).CellText(DBGrid1.RowBookmark(rowvalue))
		sqlstmnt = sqlstmnt & " and chk_alloc = " & new_amt.Text
		sqlstmnt = sqlstmnt & " and chk_Date = " & Chr(35) & new_Date.Text & Chr(35)
		'UPGRADE_ISSUE: Data property cash.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		cash.recordsource = sqlstmnt
		cash.Refresh()
		
		
		'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		If cash.Recordset.RecordCount = 0 Then
			MsgBox("This invoice has no cash payments.")
			Exit Sub
		End If
		
		
		entry_type = "EDIT"
		
		'verify this is the one including the amount
		
		'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		msg = "Invoice = " & cash.Recordset.Fields("inv_num").Value & Chr(10)
		'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		msg = msg & " For " & cash.Recordset.Fields("sort_name").Value & Chr(10)
		msg = msg & "Is this the right invoice?"
		Response = MsgBox(msg, MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
		If Response = MsgBoxResult.No Then
			Exit Sub
		End If
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		
		
		'check if want to do the whole check and set up the loop
		'     Grid1.Col = 0
		'  sqlstmnt = "Select * from cash where inv_num = " & Grid1.Text 'DBGrid1.Columns(0).CellText(DBGrid1.RowBookmark(rowvalue))
		
		tmp1set = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
		If tmp1set.RecordCount > 1 Then
			Response = MsgBox("This invoice has several payments. Do you wish to reverse all of them?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
			If Response = MsgBoxResult.Yes Then 'change the sql
				'    sqlstmnt = "Select * from cash where inv_num = " & Grid1.Text 'DBGrid1.Columns(0).CellText(DBGrid1.RowBookmark(rowvalue))
				'UPGRADE_ISSUE: Data property cash.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				cash.recordsource = sqlstmnt
				cash.Refresh()
			End If
		End If
		
		'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not cash.Recordset.EOF
			'then write negative cash record one record at at time
			tmpset.AddNew()
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			For num = 0 To cash.Recordset.Fields.Count - 1
				'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				tmpset.Fields(num).Value = cash.Recordset.Fields(num).Value
			Next 
			'put here the changed fields
			tmpset.Fields("chk_alloc").Value = CDbl(new_amt.Text) * -1
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			tmpset.Fields("chk_num").Value = cash.Recordset.Fields("chk_num").Value & "R" ' to mark the record
			tmpset.update()
			
			'then write  the new batch one line at a time
			'UPGRADE_ISSUE: Data property cash_Tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash_Tmp1.Recordset.AddNew()
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			For num = 0 To cash.Recordset.Fields.Count - 1
				'UPGRADE_ISSUE: Data property cash_Tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				cash_Tmp1.Recordset.Fields(num).Value = cash.Recordset.Fields(num).Value
			Next 
			'put here the changed fields
			'UPGRADE_ISSUE: Data property cash_Tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash_Tmp1.Recordset.Fields("chk_alloc").Value = new_amt.Text
			'UPGRADE_ISSUE: Data property cash_Tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash_Tmp1.Recordset.Fields("batch_num").Value = selected_bat_num
			'UPGRADE_ISSUE: Data property cash_Tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash_Tmp1.Recordset.Fields("batch_desc").Value = "Re-apply Amt"
			'UPGRADE_ISSUE: Data property cash_Tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash_Tmp1.Recordset.Fields("entry_num").Value = saved_entry_num
			saved_entry_num = saved_entry_num + 1
			new_batch_tot = new_batch_tot + CDbl(new_amt.Text)
			'UPGRADE_ISSUE: Data property cash_Tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash_Tmp1.Recordset.update()
			
			'then correct the invoice
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			sqlstmnt = " select * from invoice where inv_num = " & cash.Recordset.Fields("inv_num").Value
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			sqlstmnt = sqlstmnt & " and line_num = " & cash.Recordset.Fields("line_num").Value
			'UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			invoice.recordsource = sqlstmnt
			
			invoice.Refresh()
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			invoice.Recordset.Edit()
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			invoice.Recordset.Fields("bal_due").Value = invoice.Recordset.Fields("bal_due").Value + new_amt.Text
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			invoice.Recordset.Fields("pay_amt").Value = invoice.Recordset.Fields("pay_amt").Value - CDbl(new_amt.Text)
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			If invoice.Recordset.Fields("bal_Due").Value = 0 Then
				'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				invoice.Recordset.Fields("paid").Value = "Y"
			Else
				'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				invoice.Recordset.Fields("paid").Value = "N"
			End If
			
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			invoice.Recordset.update()
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash.Recordset.MoveNext()
			
		Loop 
		
		'fix the batch total
		'UPGRADE_ISSUE: Data property cash_Tmp1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		cash_Tmp1.recordsource = " select * from cash_tmp1 where batch_num = " & selected_bat_num
		cash_Tmp1.Refresh()
		'UPGRADE_ISSUE: Data property cash_Tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not cash_Tmp1.Recordset.EOF
			'UPGRADE_ISSUE: Data property cash_Tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash_Tmp1.Recordset.Edit()
			'UPGRADE_ISSUE: Data property cash_Tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash_Tmp1.Recordset.Fields("batch_total").Value = new_batch_tot
			'UPGRADE_ISSUE: Data property cash_Tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash_Tmp1.Recordset.update()
			'UPGRADE_ISSUE: Data property cash_Tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash_Tmp1.Recordset.MoveNext()
		Loop 
		
		'redo the grid
		'UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.recordsource = " select * from invoice where inv_num > 0 and pay_amt <> 0 order by inv_num, line_num "
		invoice.Refresh()
		
		'then tell them it is complete and what has happened.
		MsgBox("The reversing process has completed. " & Chr(10) & "Continue to select more entries to reverse or select Exit this Screen. " & Chr(10) & " Select the batch in cash application to finish correcting.")
		
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'UPGRADE_WARNING: Couldn't resolve default property of object rowvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		rowvalue = ""
	End Sub
	Private Sub ar_cash_rev1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		
		
		'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For num = 0 To Me.Controls.Count() - 1
			'UPGRADE_ISSUE: Data object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.Label Then
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sqlstmnt = VB.Right(CType(Me.Controls(num), Object).DatabaseName, Len(CType(Me.Controls(num), Object).DatabaseName) - 20)
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CType(Me.Controls(num), Object).DatabaseName = att_data_path & sqlstmnt
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().recordsource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Len(CType(Me.Controls(num), Object).recordsource) > 0 Then
					CType(Me.Controls(num), Object).Refresh()
				End If
			End If
		Next 
		
		ctrform(Me)
		
		'UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.recordsource = " select * from invoice where inv_num > 0 and pay_amt <> 0 order by inv_num, line_num "
		
		Call batch_number_Create()
		new_batch_tot = 0
		
		Call rebuild_grid()
		
	End Sub
	
	
	Private Sub inv_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles inv_num.Enter
		Call ets_set_selected()
		
		invoice_id.Text = ""
		
	End Sub
	
	Private Sub inv_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles inv_num.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			'look up the invoice number
			tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
			tmpset = tmpdb.OpenRecordset("invoice", dao.RecordsetTypeEnum.dbOpenDynaset)
			'if it exists then refresh the list
			sqlstmnt = "inv_num = " & Val(inv_num.Text)
			tmpset.FindFirst(sqlstmnt)
			If tmpset.NoMatch Then
				MsgBox("That invoice does not exist.")
				Call ets_set_selected()
			Else
				
				'UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				invoice.recordsource = " select * from invoice where inv_num > 0 and pay_amt <> 0 and inv_num = " & Val(inv_num.Text)
				invoice.Refresh()
				new_amt.Text = ""
				new_Date.Text = ""
			End If
			
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub inv_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles inv_num.Leave
		inv_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub invoice_id_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles invoice_id.Enter
		Call ets_set_selected()
		inv_num.Text = ""
		
	End Sub
	
	Private Sub invoice_id_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles invoice_id.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			'look up the invoice_id number
			tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
			tmpset = tmpdb.OpenRecordset("invoice", dao.RecordsetTypeEnum.dbOpenDynaset)
			'if it exists then refresh the list
			sqlstmnt = "invoice = " & Chr(34) & invoice_id.Text & Chr(34)
			
			tmpset.FindFirst(sqlstmnt)
			If tmpset.NoMatch Then
				MsgBox("That invoice does not exist.")
				Call ets_set_selected()
			Else
				
				'UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				invoice.recordsource = " select * from invoice where inv_num > 0 and pay_amt <> 0 and invoice = " & Chr(34) & invoice_id.Text & Chr(34)
				invoice.Refresh()
				new_amt.Text = ""
				new_Date.Text = ""
			End If
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	
	
	Private Sub invoice_id_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles invoice_id.Leave
		invoice_id.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub new_amt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles new_amt.Enter
		Call ets_set_selected()
	End Sub
	
	
	
	Private Sub new_amt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles new_amt.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			'    Grid1.Col = 0
			'  sqlstmnt = "Select * from cash where inv_num = " & Grid1.Text 'DBGrid1.Columns(0).CellText(DBGrid1.RowBookmark(rowvalue))
			' Grid1.Col = 1
			'  sqlstmnt = sqlstmnt & " and line_num = " & Grid1.Text 'DBGrid1.Columns(1).CellText(DBGrid1.RowBookmark(rowvalue))
			sqlstmnt = sqlstmnt & " and chk_alloc = " & new_amt.Text
			'UPGRADE_ISSUE: Data property cash.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash.recordsource = sqlstmnt
			cash.Refresh()
			
			On Error Resume Next
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash.Recordset.MoveLast()
			If Err.Number = 3021 Then
				Response = 0
			Else
				'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Response = cash.Recordset.RecordCount
			End If
			On Error GoTo 0
			
			Select Case Response
				Case 0
					
					MsgBox("This invoice has no cash payments of this amount.")
					Call ets_set_selected()
					new_Date.Text = ""
					GoTo EventExitSub
				Case 1
					
					'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					new_Date.Text = cash.Recordset.Fields("chk_date").Value
					
					
				Case Is > 1
					'make them choose
					sendlook = sqlstmnt 'give the form the sql
					ar_date_choose.ShowDialog()
					
					new_Date.Text = retdate
					
					
			End Select
			
			System.Windows.Forms.SendKeys.Send("{tab}")
			KeyAscii = 0
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub new_amt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles new_amt.Leave
		new_amt.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
	
	Private Sub new_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles new_date.Enter
		Call ets_set_selected()
	End Sub
	
	
	
	Private Sub new_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles new_date.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			valid_Date = "N"
			senddate = new_Date.Text
			Call etsdate(senddate, retdate, valid_Date)
			
			If valid_Date <> "N" Then
				new_Date.Text = retdate
				new_Date.Text = CStr(CDate(new_Date.Text))
			End If
			
			
			System.Windows.Forms.SendKeys.Send("{tab}")
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub new_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles new_date.Leave
		new_Date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
	
	Private Sub ref_list_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ref_list.Click
		'UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.recordsource = " select * from invoice where inv_num > 0 and pay_amt <> 0 order by invoice, line_num "
		invoice.Refresh()
		new_amt.Text = ""
		new_Date.Text = ""
		inv_num.Text = ""
		invoice_id.Text = ""
		
		Call rebuild_grid()
		
	End Sub
	
	Private Sub ref_list_name_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ref_list_name.Click
		'UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.recordsource = " select * from invoice where inv_num > 0 and pay_amt <> 0 order by sort_name, line_num "
		invoice.Refresh()
		new_amt.Text = ""
		new_Date.Text = ""
		inv_num.Text = ""
		invoice_id.Text = ""
		
		Call rebuild_grid()
		
	End Sub
	
	Private Sub ref_lst_inv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ref_lst_inv.Click
		'UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.recordsource = " select * from invoice where inv_num > 0 and pay_amt <> 0 order by inv_num, line_num "
		invoice.Refresh()
		new_amt.Text = ""
		new_Date.Text = ""
		inv_num.Text = ""
		invoice_id.Text = ""
		
		Call rebuild_grid()
		
	End Sub
End Class