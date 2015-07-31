Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmvouchent
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 6/23/96 -SCS
	
	'****************
	Dim invoice_left_to_enter As Decimal
	Dim batch_Amount As Decimal
	Dim voucher_array() As Object
	Dim batch_Total_amt As Decimal
	Dim vouch_Done As Integer
	Dim vouchtotaldetail As Object
	Public miss As String
	Public add_sub As Integer
	Public wline As Integer
	Public oldfocus As Integer
	Public flag_set As Integer
	Public vnumtmpdb As dao.Database
	'UPGRADE_WARNING: Arrays in structure vnumtmpset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public vnumtmpset As dao.Recordset
	Dim temp_array(50, 2) As String
	
	
	Private Sub acct_desc_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles acct_desc.Enter
		Dim Index As Short = acct_desc.GetIndex(eventSender)
		
		'    'checks to make sure not below lines allready entered
		'        If Index > max_grid_line Then
		'       reimb(max_grid_line - 1).SetFocus
		'        Exit Sub
		'        End If
		'    vouch_desc(Index).SetFocus
	End Sub
	
	Private Sub acct_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles acct_num.Enter
		Dim Index As Short = acct_num.GetIndex(eventSender)
		'    acct_num(Index).BackColor = RGB(0, 255, 255)
		'
		'
		'    acct_num(Index).SelStart = 8
		'    acct_num(Index).SelLength = 2   'Len(acct_num(Index).Text)
		'
		'    'checks to make sure not below lines allready entered
		'        If Index > max_grid_line Then
		'       reimb(max_grid_line - 1).SetFocus
		'        Exit Sub
		'        End If
		
	End Sub
	
	Private Sub acct_num_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles acct_num.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = acct_num.GetIndex(eventSender)
		'   Select Case KeyCode
		'
		'    Case vbKeyF3
		'
		'    If Index <> 0 Then
		'    acct_num(Index) = acct_num(Index - 1)
		'      SendKeys "{ENTER}"
		'    End If
		'    Case vbKeyF5
		'        'delete a line
		'        If V_line(Index) > max_grid_line Then
		'        MsgBox "Line not yet entered, so it can not be deleted."
		'        Exit Sub
		'        End If
		'
		'        msg = "Do you wish to delete this line?"
		'        Response = MsgBox(msg, vbYesNo)
		'        If Response = vbNo Then Exit Sub
		'        add_sub = -1
		'        Call grid_change(add_sub, V_line(Index), Index)
		'
		'    Case vbKeyF6
		'        'insert a line
		'        If V_line(Index) > max_grid_line Then
		'        MsgBox "This is the last line. No need to add a line."
		'        Exit Sub
		'        End If
		'
		'        msg = "Do you wish to insert a line before this line?"
		'        Response = MsgBox(msg, vbYesNo)
		'        If Response = vbNo Then Exit Sub
		'        add_sub = 1
		'        Call grid_change(add_sub, V_line(Index), Index)
		'    End Select
		'    Call tot_amt
		
	End Sub
	
	Private Sub acct_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles acct_num.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = acct_num.GetIndex(eventSender)
		
		'        If KeyAscii = 13 Then
		'        acct_num(Index).SelStart = 0  'to make sure field is cleared
		'      valid_acct = "N"
		'     Call etsacctnum_chk(acct_num(Index), retacct, retacctdesc, valid_acct)
		'    If retacct = acct_num_blank Then Exit Sub
		'    If valid_acct = "Y" Then
		'
		'     acct_num(Index).Text = retacct
		''     acct_num(Index).Text = retacct
		'    acct_desc(Index) = retacctdesc
		'     voucher_detail_grid(Index + offset_grid_line, 2) = retacct
		'   voucher_detail_grid(Index + offset_grid_line, 0) = acct_desc(Index)
		'    voucher_detail_grid(Index + offset_grid_line, 1) = V_line(Index)
		'    Else
		'
		'    MsgBox "Invalid acct number - Please re-enter"
		'   Call ets_set_selected
		'    Exit Sub
		'    End If
		'
		'    vouch_desc(Index).SetFocus
		'    KeyAscii = 0
		'
		'End If
		'
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub acct_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles acct_num.Leave
		Dim Index As Short = acct_num.GetIndex(eventSender)
		acct_num(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub amt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles amt.Enter
		Dim Index As Short = amt.GetIndex(eventSender)
		'    amt(Index).BackColor = RGB(0, 255, 255)
		'    If Len(amt(Index).Text) <> 0 Then
		'    amt(Index).SelStart = 0
		'    amt(Index).SelLength = Len(amt(Index).Text)
		'    invoice_left_to_enter = invoice_left_to_enter + Val(amt(Index))
		'
		'End If
		'
		'    'checks to make sure not below lines allready entered
		'        If Index > max_grid_line Then
		'       reimb(max_grid_line - 1).SetFocus
		'        Exit Sub
		'        End If
		
		
	End Sub
	
	Private Sub amt_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles amt.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = amt.GetIndex(eventSender)
		'Select Case KeyCode
		'
		'    Case vbKeyF3
		'
		'    If Index <> 0 Then
		'    amt(Index) = amt(Index - 1)
		'      SendKeys "{ENTER}"
		'    End If
		'    End Select
		
	End Sub
	
	Private Sub amt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles amt.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = amt.GetIndex(eventSender)
		
		'    If KeyAscii = 13 Then        'lhw98
		
		'                            '  If Val(amt(Index)) = 0 Then
		'                            '  MsgBox "Please Enter an amount"
		'                            '  Exit Sub
		'                            '  End If
		
		
		'    If invoice_left_to_enter - Val(amt(Index)) < 0 Then
		'    Response = MsgBox("Exceeded invoice total -- Do you wish to Edit amount", 4)
		'
		'    If Response = 6 Then
		'        amt(Index).SelStart = 0
		'        amt(Index).SelLength = Len(amt(Index).Text)
		'        Exit Sub
		'    End If
		'    End If
		'
		'        Call check_amount(Val(amt(Index)))
		'
		'        voucher_detail_grid(Index + offset_grid_line, 4) = Val(amt(Index).Text)
		'    amt(Index) = Format(amt(Index), "####0.00;-####0.00")
		'    Call tot_amt
		'
		'        reimb(Index).SetFocus
		'        KeyAscii = 0
		'    End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub amt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles amt.Leave
		Dim Index As Short = amt.GetIndex(eventSender)
		amt(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub bankname_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bankname.Enter
		bankname.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		If Len(bankname.Text) = 0 Then
			bankname.Text = VB6.GetItemString(bankname, 0)
		End If
		
		bankname.SelectionStart = 0
		bankname.SelectionLength = Len(bankname.Text)
		
	End Sub
	
	Private Sub bankname_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles bankname.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim bk As Object
		If KeyAscii = 13 And Len(bankname.Text) = 0 Then
			MsgBox("Please enter a name or select from the list")
			bankname.Focus()
			GoTo EventExitSub
		End If
		'does what was entered equal one of the names
		'if it does we need to store the name-key
		If KeyAscii = 13 Then
			
			'UPGRADE_WARNING: Couldn't resolve default property of object bk. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			bk = bankname.Text
			For i = 0 To bankname.Items.Count
				'UPGRADE_WARNING: Couldn't resolve default property of object bk. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If VB6.GetItemString(bankname, i) = bk Then GoTo ok1
			Next i
			'UPGRADE_WARNING: Couldn't resolve default property of object bk. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			MsgBox(bk & " is an invalid bank.  Please select from the list")
			GoTo EventExitSub
ok1: 
			
			KeyAscii = 0
			voucher.bank_key = CStr(VB6.GetItemData(bankname, i))
			Response = MsgBox("Do you wish to use a standard allocation?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
			If Response = 6 Then
				apalloclookup.ShowDialog()
				tmpdb = DAODBEngine_definst.OpenDatabase(ap_data_path & "ap.mdb")
				sqlstmnt = "select * from apalloc where name = " & Chr(34) & selected_lookup_num & Chr(34)
				tmpset = tmpdb.OpenRecordset(sqlstmnt)
				
				On Error Resume Next 'if wrong bank selected lhwxx
				tmpset.MoveFirst()
				If Err.Number = 3021 Then
					GoTo EventExitSub
				End If
				
				num = 0
				Do While Not tmpset.EOF
					temp_array(num, 0) = tmpset.Fields("acct_num").Value
					temp_array(num, 1) = tmpset.Fields("factor").Value
					
					'this does the work of forcing the allocation of standard bills
					
					'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(num + offset_grid_line, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					voucher_detail_grid(num + offset_grid_line, 2) = temp_array(num, 0)
					max_grid_line = num + 1
					
					valid_acct = "N"
					'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call etsacctnum_chk(voucher_detail_grid(num + offset_grid_line, 2), retacct, retacctdesc, valid_acct)
					
					
					'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(num + offset_grid_line, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					voucher_detail_grid(num + offset_grid_line, 2) = retacct
					'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(num + offset_grid_line, 0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					voucher_detail_grid(num + offset_grid_line, 0) = retacctdesc
					'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(num + offset_grid_line, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					voucher_detail_grid(num + offset_grid_line, 1) = V_line(num + 1).Text
					
					'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(num + offset_grid_line, 4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					voucher_detail_grid(num + offset_grid_line, 4) = VB6.Format(Val(temp_array(num, 1)) * CDbl(VendInvAmt.Text), "FIXED")
					
					'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(num + offset_grid_line, 5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					voucher_detail_grid(num + offset_grid_line, 5) = "N"
					
					
					
					tmpset.MoveNext()
					num = num + 1
					
				Loop 
				
				Call repaint_grid(0, 0, 0)
				
				Call tot_amt()
				
				For num = 0 To 50
					temp_array(num, 0) = ""
					temp_array(num, 1) = ""
					temp_array(num, 2) = ""
				Next 
				
				'        Close .tmpset
			End If
			
			V_line(0).Focus()
			
		End If
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub bankname_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bankname.Leave
		bankname.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		Me.Close()
		
	End Sub
	
	Private Sub chkdate_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkdate.Enter
		chkdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		chkdate.SelectionStart = 0
		chkdate.SelectionLength = Len(chkdate.Text)
		
	End Sub
	
	Private Sub chkdate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles chkdate.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			valid_Date = "N"
			senddate = chkdate.Text
			Call etsdate(senddate, retdate, valid_Date)
			
			If valid_Date <> "N" Then
				chkdate.Text = retdate
				chkdate.Text = CStr(CDate(chkdate.Text))
				chkdate.Text = CStr(CDate(chkdate.Text))
				System.Windows.Forms.SendKeys.Send("{tab}")
				KeyAscii = 0
				'UPGRADE_WARNING: Couldn't resolve default property of object voucher.dt_paid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				voucher.dt_paid = chkdate.Text
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
	
	Private Sub chkdate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkdate.Leave
		chkdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub chknum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chknum.Enter
		chknum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		chknum.SelectionStart = 0
		chknum.SelectionLength = Len(chknum.Text)
		
	End Sub
	
	Private Sub chknum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles chknum.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			
			If Val(chknum.Text) = 0 Then
				chknum.Text = ""
				voucher.chk_num = 0
				vend_num.Focus()
				KeyAscii = 0
				GoTo EventExitSub
			End If
			
			'if one check pays 2 vouchers need to be able to enter ck# again
			'4/19/00 lhw  changed section below
			
			valid_check = "N"
			Call chknumverify(Val(chknum.Text))
			If valid_check = "N" Then
				Response = MsgBox("This check number has been used - Select Yes to Continue", MsgBoxStyle.YesNo)
				If Response = MsgBoxResult.Yes Then
					voucher.chk_num = Val(chknum.Text)
					System.Windows.Forms.SendKeys.Send("{tab}")
					KeyAscii = 0
				Else
					Call ets_set_selected()
					GoTo EventExitSub
				End If
			Else
				voucher.chk_num = Val(chknum.Text)
				System.Windows.Forms.SendKeys.Send("{tab}")
				KeyAscii = 0
				
			End If
			
			' voucher.chk_num = Val(chknum.Text)
			' SendKeys "{tab}"
			' KeyAscii = 0
			
		End If
		
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub chknum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chknum.Leave
		chknum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	
	
	Private Sub down_grid_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles down_grid.Click
		wline = 0
		If max_grid_line < 6 Then Exit Sub
		
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		offset_grid_line = offset_grid_line - 1
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If offset_grid_line > (max_grid_line - 5) Then offset_grid_line = max_grid_line - 5
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If offset_grid_line < 0 Then offset_grid_line = 0
		
		Call repaint_grid(offset_grid_line, wline, Index)
		
	End Sub
	
	Private Sub duedate_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles duedate.Enter
		duedate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		duedate.SelectionStart = 0
		duedate.SelectionLength = Len(duedate.Text)
		
	End Sub
	
	Private Sub duedate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles duedate.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			valid_Date = "N"
			senddate = duedate.Text
			Call etsdate(senddate, retdate, valid_Date)
			
			If valid_Date <> "N" Then
				duedate.Text = retdate
				duedate.Text = CStr(CDate(duedate.Text))
				
				System.Windows.Forms.SendKeys.Send("{tab}")
				duedate.Text = CStr(CDate(duedate.Text))
				KeyAscii = 0
				'UPGRADE_WARNING: Couldn't resolve default property of object voucher.dt_tbe_pd. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				voucher.dt_tbe_pd = duedate.Text
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
	
	Private Sub duedate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles duedate.Leave
		duedate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub encdate_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles encdate.Enter
		encdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		encdate.SelectionStart = 0
		encdate.SelectionLength = Len(encdate.Text)
		
	End Sub
	
	Private Sub encdate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles encdate.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			valid_Date = "N"
			senddate = encdate.Text
			Call etsdate(senddate, retdate, valid_Date)
			
			If valid_Date <> "N" Then
				encdate.Text = retdate
				encdate.Text = CStr(CDate(encdate.Text))
				
				encdate.Text = CStr(CDate(encdate.Text))
				'UPGRADE_WARNING: Couldn't resolve default property of object voucher.encum_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				voucher.encum_date = encdate.Text
				
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
	Sub grid_change(ByRef add_sub As Object, ByRef wline As Object, ByRef oldfocus As Object)
		Dim n As Object
		
		Select Case add_sub
			Case 1 'add a line from here on out
				
				max_grid_line = max_grid_line + 1
				
				'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				For n = max_grid_line To wline Step -1
					
					For i = 0 To 5
						'UPGRADE_WARNING: Couldn't resolve default property of object n. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(n - 1, i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(n, i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						voucher_detail_grid(n, i) = voucher_detail_grid(n - 1, i)
					Next i
					
				Next n
				For i = 0 To 5
					'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(wline - 1, i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					voucher_detail_grid(wline - 1, i) = ""
				Next i
				'voucher_detail_grid(n, 1) = Val(voucher_detail_grid(n - 1, 1)) + 1
				
			Case -1
				
				'this test the continuous use of the f5 key
				'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Val(wline) > max_grid_line Then
					'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					wline = max_grid_line
				End If
				
				'this is the special case of deleting the last line
				'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If wline = max_grid_line Then
					max_grid_line = max_grid_line - 1
					
					If max_grid_line < 1 Then max_grid_line = 1
					
					For n = 0 To 5
						'UPGRADE_WARNING: Couldn't resolve default property of object n. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(wline - 1, n). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						voucher_detail_grid(wline - 1, n) = ""
					Next n
					'UPGRADE_WARNING: Couldn't resolve default property of object oldfocus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If oldfocus - 1 < 0 Then
						'UPGRADE_WARNING: Couldn't resolve default property of object oldfocus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						oldfocus = 1
						'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						offset_grid_line = offset_grid_line - 1
						'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If offset_grid_line < 0 Then offset_grid_line = 0
					End If
					
					Call tot_amt()
					'UPGRADE_WARNING: Couldn't resolve default property of object oldfocus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call repaint_grid(offset_grid_line, wline, oldfocus - 1)
					Exit Sub
				End If
				
				max_grid_line = max_grid_line - 1
				If max_grid_line < 1 Then max_grid_line = 1
				
				'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				For n = wline - 1 To max_grid_line
					'UPGRADE_WARNING: Couldn't resolve default property of object n. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(n, 0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					voucher_detail_grid(n, 0) = Val(voucher_detail_grid(n + 1, 0)) - 1
					For i = 0 To 5
						'UPGRADE_WARNING: Couldn't resolve default property of object n. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(n + 1, i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(n, i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						voucher_detail_grid(n, i) = voucher_detail_grid(n + 1, i)
					Next i
				Next n
				For i = 0 To 5
					'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(max_grid_line + 1, i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					voucher_detail_grid(max_grid_line + 1, i) = ""
				Next i
				'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(max_grid_line + 1, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				voucher_detail_grid(max_grid_line + 1, 1) = acct_num_blank
				
		End Select
		Call tot_amt()
		'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call repaint_grid(offset_grid_line, wline - 1, oldfocus)
		
	End Sub
	
	Sub repaint_grid(ByRef offset_grid_line As Object, ByRef wline As Object, ByRef oldfocus As Object)
		'recalc the offset grid line to keep the focus on the same physical line
		'and for the new line to be sensible
		
		'line renumbering done on v_line getting the focus
		
		For i = 0 To 7
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Len(voucher_detail_grid(i + offset_grid_line, 2)) <> 0 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				acct_num(i).Text = (voucher_detail_grid(i + offset_grid_line, 2))
			Else
				acct_num(i).Text = acct_num_blank
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(i + offset_grid_line, 0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			acct_desc(i).Text = voucher_detail_grid(i + offset_grid_line, 0)
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			amt(i).Text = VB6.Format(voucher_detail_grid(i + offset_grid_line, 4), "###0.00;-###0.00")
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(i + offset_grid_line, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			vouch_desc(i).Text = voucher_detail_grid(i + offset_grid_line, 3)
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(i + offset_grid_line, 5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			reimb(i).Text = voucher_detail_grid(i + offset_grid_line, 5)
			
		Next i
		'UPGRADE_WARNING: Couldn't resolve default property of object oldfocus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If oldfocus < 0 Then oldfocus = 0
		Call tot_amt()
		V_line(oldfocus).Focus()
		
	End Sub
	Private Sub entcleardetail()
		Dim nn As Object
		Dim n As Object
		
		For i = 0 To 7
			Me.amt(i).Text = ""
			Me.acct_num(i).Text = acct_num_blank
			Me.acct_desc(i).Text = ""
			Me.V_line(i).Text = ""
			Me.vouch_desc(i).Text = ""
			Me.reimb(i).Text = ""
			
		Next i
		
		'UPGRADE_WARNING: Couldn't resolve default property of object vouchtotaldetail. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		vouchtotaldetail = 0
		
		For n = 0 To 100
			For nn = 0 To 5
				'UPGRADE_WARNING: Couldn't resolve default property of object nn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object n. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(n, nn). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				voucher_detail_grid(n, nn) = ""
			Next nn
		Next n
		
		'UPGRADE_WARNING: Couldn't resolve default property of object vouchtotaldetail. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Me.vouchtotaldisplay.Text = VB6.Format(vouchtotaldetail, "$####0.00;-$####0.00")
		
	End Sub
	Private Sub entclearheader()
		Me.vend_num.Text = ""
		Me.vendInvNum.Text = ""
		Me.VendInvAmt.Text = ""
		Me.VendDiscAmt.Text = ""
		'to default the invdate and due date comment them out 10/5/06 lhw
		Me.invdate.Text = ""
		'frmvouchent.encdate = ""   'this was already commented out
		Me.duedate.Text = ""
		Me.vouchnum.Text = CStr(Val(Me.vouchnum.Text) + 1)
		'frmvouchent.bankname = ""
		Me.vendname.Text = ""
		Me.chknum.Text = ""
		Me.chkdate.Text = ""
		
		
		voucher.dr_Acct = ""
		voucher.cr_Acct = ""
		voucher.vouch_num = 0
		voucher.vouch_line = 0
		voucher.name_key = ""
		voucher.screen_nam = ""
		voucher.cntrct_key = ""
		voucher.vend_inv = ""
		voucher.vouch_Amt = 0
		'UPGRADE_WARNING: Couldn't resolve default property of object voucher.vend_inv_d. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		voucher.vend_inv_d = ""
		'voucher.date_recd = ""
		voucher.po_num = ""
		voucher.chk_num = 0
		'UPGRADE_WARNING: Couldn't resolve default property of object voucher.dt_tbe_pd. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		voucher.dt_tbe_pd = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object voucher.dt_paid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		voucher.dt_paid = ""
		voucher.alloc_amt = 0
		voucher.disc_amt = 0
		'voucher.entry_date = ""
		voucher.bank_key = ""
		' voucher.bpost_date = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object voucher.encum_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		voucher.encum_date = ""
		voucher.glpost = ""
		voucher.reimb = ""
		voucher.memo = ""
		
		
	End Sub
	
	Private Function errorhandler() As Object
		Dim Drive As Object ' Error handler line label.
		
		Select Case Err.Number
			Case 53 : Resume Next
				
			Case 68
				'UPGRADE_WARNING: Couldn't resolve default property of object Drive. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				msg = "ERROR 68: Drive " & Drive & ": not available."
			Case 76 : msg = "ERROR 76: That path doesn't exist."
			Case Else : msg = "ERROR " & Err.Number & " occurred."
		End Select
		MsgBox(msg) ' Display error message.
		Resume Next ' Resume procedure.
		
	End Function
	
	Private Sub encdate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles encdate.Leave
		encdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub End_Session_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Session.Click
		
		'      'xx this is where you print the apron
		'        'the flag is set to 1 to print
		'        If flag_set = 1 Then
		'    prtDestination = 1    'forces to the printer
		'    prtreportfilename = ap_report_path & "apprtvch.rpt"
		'    Call frmcrystal_Call
		'        End If
		'
		'         If entry_type = "RECURRING" Then
		'     Unload frmvouchent
		'         'xx print report from  form for recurring vouchers
		'         Else
		'    MsgBox " You are about to print the voucher edit proof. Be sure your printer is turned on and on line."
		'
		'    prtDestination = 0    'to the screen
		'    prtreportfilename = ap_report_path & "apvedit.rpt"
		'   Call frmcrystal_Call
		'        'End If
		'    message = "Check the proof.  If errors are found..select Edit Vouchers from the menu. "
		''lhw99
		'    MsgBox message
		'        End If
		'    Unload frmvouchent
		'
	End Sub
	
	Private Sub ent_Date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ent_Date.Enter
		Me.ent_Date.Text = VB6.Format(Now, "medium date")
	End Sub
	
	Private Sub frmvouchent_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim nn As Object
		Dim n As Object
		Dim vouchertable As Object
		Dim nambanktable As Object
		
		
		'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For num = 0 To Me.Controls.Count() - 1
			'UPGRADE_ISSUE: Data object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.Label Then
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sqlstmnt = VB.Right(CType(Me.Controls(num), Object).DatabaseName, Len(CType(Me.Controls(num), Object).DatabaseName) - 20)
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CType(Me.Controls(num), Object).DatabaseName = gl_data_path & sqlstmnt
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().RecordSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Len(CType(Me.Controls(num), Object).RecordSource) > 0 Then
					CType(Me.Controls(num), Object).Refresh()
				End If
			End If
			
		Next 
		
		form_showing = "frmvouchent"
		function_type = "DATA_ENTRY"
		On Error Resume Next
		
		db = gl_data_path & "glname.mdb"
		nambankdb = DAODBEngine_definst.OpenDatabase(db)
		nambanktable = nambankdb.OpenRecordset("nam_bank")
		sqlstmnt = "select * from nam_bank order by nam_bank.sort_name"
		nambankset = nambankdb.OpenRecordset(sqlstmnt)
		
		nambankset.MoveFirst()
		Do While Not nambankset.EOF
			Me.bankname.Items.Add(nambankset.Fields("screen_nam").Value)
			'UPGRADE_ISSUE: ComboBox property bankname.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
			VB6.SetItemData(Me.bankname, bankname.NewIndex, nambankset.Fields("bank_key").Value)
			nambankset.MoveNext()
			
		Loop 
		
		db = ap_data_path & "ap.mdb"
		voucherdb = DAODBEngine_definst.OpenDatabase(db)
		vouchertable = voucherdb.OpenRecordset("voucher")
		
		
		For n = 0 To 100
			For nn = 0 To 5
				'UPGRADE_WARNING: Couldn't resolve default property of object nn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object n. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(n, nn). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				voucher_detail_grid(n, nn) = ""
			Next nn
		Next n
		
		For n = 0 To 1000
			'UPGRADE_WARNING: Couldn't resolve default property of object n. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object vouch_num_temp(n). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			vouch_num_temp(n) = 0
		Next n
		Call vouchersetup()
		Call checknumsetup()
		'clears the voucher number table for this session (vnumtmp)
		
		db = ap_data_path & "ap.mdb"
		vnumtmpdb = DAODBEngine_definst.Workspaces(0).OpenDatabase(db)
		vnumtmpset = vnumtmpdb.OpenRecordset("vnumtmp")
		
		sqlstmnt = "select * from vnumtmp"
		vnumtmpset = vnumtmpdb.OpenRecordset(sqlstmnt)
		vnumtmpset.MoveFirst()
		
		Do While Not vnumtmpset.EOF
			vnumtmpset.delete()
			vnumtmpset.MoveNext()
		Loop 
		
		flag_set = 0 'to be sure print is off
		
		If entry_type <> "RECURRING" Then 'added 5-10-04 lhw
			
			Response = MsgBox("Do you wish to print voucher aprons for this session?", 256 + 4)
			If Response = 6 Then
				'sets print apron flag
				flag_set = 1
			Else
				'turns print apron flag off
				flag_set = 0
			End If
		Else
			flag_set = 0
		End If
		'the following lines can be commented out
		' if they are then as long as you are in a/p at all it will continue to count
		
		batch_Amount = 0
		vouch_Done = 0
		Me.ent_Date.Text = VB6.Format(Now, "medium date")
		'UPGRADE_WARNING: Couldn't resolve default property of object voucher.entry_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		voucher.entry_date = Me.ent_Date.Text
		
		If entry_type = "RECURRING" Then
			'get the next recurring voucher number
			Call chkvouchnumverify(0)
			Me.vouchnum.Text = CStr(selected_rec_vouch_num + 1)
		End If
		
		vouchnum.Focus()
		
	End Sub
	
	Private Sub invdate_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles invdate.Enter
		invdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		invdate.SelectionStart = 0
		invdate.SelectionLength = Len(invdate.Text)
		
	End Sub
	
	Private Sub invdate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles invdate.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			valid_Date = "N"
			senddate = invdate.Text
			Call etsdate(senddate, retdate, valid_Date)
			
			If valid_Date <> "N" Then
				invdate.Text = retdate
				invdate.Text = CStr(CDate(invdate.Text))
				
				Me.duedate.Text = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 30, CDate(invdate.Text)))
				'UPGRADE_WARNING: Couldn't resolve default property of object voucher.vend_inv_d. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				voucher.vend_inv_d = invdate.Text
				'UPGRADE_WARNING: Couldn't resolve default property of object voucher.dt_tbe_pd. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				voucher.dt_tbe_pd = Me.duedate.Text
				
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
	
	Private Sub invdate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles invdate.Leave
		invdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	'UPGRADE_WARNING: Event reimb.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub reimb_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles reimb.TextChanged
		Dim Index As Short = reimb.GetIndex(eventSender)
		' change to upper case
		If reimb(Index).Text = Chr(121) Then reimb(Index).Text = Chr(89)
		If reimb(Index).Text = Chr(110) Then reimb(Index).Text = Chr(78)
		
		
	End Sub
	
	Private Sub reimb_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles reimb.Enter
		Dim Index As Short = reimb.GetIndex(eventSender)
		reimb(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		reimb(Index).Text = "N"
		reimb(Index).SelectionStart = 0
		reimb(Index).SelectionLength = Len(reimb(Index).Text)
		
		'checks to make sure not below lines allready entered
		If Index > max_grid_line Then
			reimb(max_grid_line - 1).Focus()
			Exit Sub
		End If
	End Sub
	
	Private Sub reimb_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles reimb.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = reimb.GetIndex(eventSender)
		If KeyAscii = 13 Then
			'if reimb(index) check for yes no
			wline = 0
			If reimb(Index).Text = "N" Or reimb(Index).Text = "Y" Then
				GoTo okyn
			Else
				MsgBox("Must enter Y or N")
				Call ets_set_selected()
				GoTo EventExitSub
			End If
			
okyn: 
			
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(Index + offset_grid_line, 5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			voucher_detail_grid(Index + offset_grid_line, 5) = reimb(Index).Text
			
			If max_grid_line < CDbl(V_line(Index).Text) Then
				max_grid_line = CInt(V_line(Index).Text)
			End If
			
			If invoice_left_to_enter = 0 Then
				Response = MsgBox("Voucher complete?", 4)
				'SendKeys "{NUMLOCK}"
				If Response = 6 Then
					GoTo donevouch
				End If
			End If
			
			If Index = 7 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				offset_grid_line = offset_grid_line + 1
				Call repaint_grid(offset_grid_line, wline, 7)
				Me.acct_num(7).Text = acct_num(6).Text
				Me.V_line(7).Focus()
				KeyAscii = 0
				GoTo EventExitSub
				
			Else
				If (acct_num(Index + 1)).Text = acct_num_blank Then
					acct_num(Index + 1).Text = acct_num(Index).Text
				End If
			End If
			acct_num(Index + 1).Text = acct_num(Index).Text 'added 12/3/03 lhw
			Me.V_line(Index + 1).Focus()
			KeyAscii = 0
			voucher_counter = max_grid_line
			GoTo EventExitSub
			
donevouch: 
			
			voucher_counter = max_grid_line
			'check to see if all the data has been entered into the header
			miss = "CR_acct"
			If Len(voucher.cr_Acct) = 0 Then GoTo inv2
			miss = "vouch num"
			If Len(voucher.vouch_num) = 0 Then GoTo inv2
			miss = "name key"
			If Len(voucher.name_key) = 0 Then GoTo inv2
			miss = "screen name"
			If Len(voucher.screen_nam) = 0 Then GoTo inv2
			miss = "vend inv"
			If Len(voucher.vend_inv) = 0 Then GoTo inv2
			miss = "vendor inv date"
			If Len(voucher.vend_inv_d) = 0 Then GoTo inv2
			miss = "date to be paid"
			If Len(voucher.dt_tbe_pd) = 0 Then GoTo inv2
			'nn = nn + 1
			'If Len(voucher.disc_amt) = 0 Then GoTo inv2:
			miss = "bank key"
			If Len(voucher.bank_key) = 0 Then GoTo inv2
			miss = "entry date"
			If Len(voucher.entry_date) = 0 Then GoTo inv2
			miss = "encum date"
			If Len(voucher.encum_date) = 0 Then GoTo inv2
			miss = "date paid"
			If Len(voucher.dt_paid) = 0 Then
				If (voucher.chk_num) <> 0 Then
					GoTo inv2
				End If
			End If
			
			If invoice_left_to_enter = 0 Then
				'xxthis is where we get the last voucher number used so as
				'to move it to voucher.vouch_num and it will be written to the file
				'what is the key and how do we know it is the highest number
				'should we set up a sql to find it
				
				Call putvoucher()
				batch_Amount = batch_Amount + voucher.vouch_Amt
				vouch_Done = vouch_Done + 1
				disp_left_to_enter.Text = VB6.Format(batch_Amount, "$####0.00;-$####0.00")
				disp_num_of_vouch.Text = CStr(vouch_Done)
				vnumtmpset.AddNew()
				vnumtmpset.Fields("vouch_num").Value = voucher.vouch_num
				vnumtmpset.Update()
				
				If entry_type = "RECURRING" Then
					Me.Close()
					GoTo EventExitSub
				End If
				
				Call entclearheader()
				Call entcleardetail()
				
				vouchnum.Focus()
				GoTo inv3
			End If
			
inv2: 
			'message that header is not complete
			MsgBox("Information not complete.  Please complete to continue")
			vouchnum.Focus()
			MsgBox("missing data = " & miss)
			
		End If
inv3: 
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub scroll_vouch_grid(ByRef offset_grid_line As Object)
		Dim X As Object
		'calculate the effect of offset here and put in x
		
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		X = offset_grid_line
		
		'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If X > max_grid_line - 7 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			X = max_grid_line - 7
			'MsgBox "max grid " & max_grid_line
		End If
		'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If X < 0 Then X = 0
		For i = 0 To 7
			'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(X + i, 4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			amt(i).Text = voucher_detail_grid(X + i, 4)
			'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(X + i, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			acct_num(i).Text = voucher_detail_grid(X + i, 2) 'lhw
			'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(X + i, 0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			acct_desc(i).Text = voucher_detail_grid(X + i, 0)
			'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(X + i, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			V_line(i).Text = voucher_detail_grid(X + i, 1)
			
			'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(X + i, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			vouch_desc(i).Text = voucher_detail_grid(X + i, 3)
			'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(X + i, 5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			reimb(i).Text = voucher_detail_grid(X + i, 5)
			
		Next i
		
		'below is only true if adding another line
		
		If Val(V_line(7).Text) = max_grid_line Then
			
			amt(7).Text = ""
			acct_num(7).Text = acct_num(6).Text
			acct_desc(7).Text = ""
			V_line(7).Text = CStr(Val(V_line(6).Text) + 1)
			vouch_desc(7).Text = ""
			reimb(7).Text = ""
			
		End If
		
	End Sub
	Sub tot_amt()
		Dim n As Object
		'UPGRADE_WARNING: Couldn't resolve default property of object vouchtotaldetail. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		vouchtotaldetail = 0
		
		For n = 0 To max_grid_line
			'UPGRADE_WARNING: Couldn't resolve default property of object n. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object vouchtotaldetail. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			vouchtotaldetail = vouchtotaldetail + Val(voucher_detail_grid(n, 4))
		Next n
		'UPGRADE_WARNING: Couldn't resolve default property of object vouchtotaldetail. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		invoice_left_to_enter = VendInvAmt - vouchtotaldetail
		'UPGRADE_WARNING: Couldn't resolve default property of object vouchtotaldetail. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Me.vouchtotaldisplay.Text = VB6.Format(vouchtotaldetail, "$###0.00;-$###0.00")
		If invoice_left_to_enter = 0 Then
			V_done.Enabled = True
		End If
		
	End Sub
	
	Private Sub reimb_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles reimb.Leave
		Dim Index As Short = reimb.GetIndex(eventSender)
		reimb(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
	
	Private Sub up_grid_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles up_grid.Click
		wline = 0
		If max_grid_line < 6 Then Exit Sub
		
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		offset_grid_line = offset_grid_line + 1
		
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If offset_grid_line > max_grid_line - 8 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			offset_grid_line = max_grid_line - 6
		End If
		
		
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If offset_grid_line > (max_grid_line - 5) Then offset_grid_line = max_grid_line - 5
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If offset_grid_line < 0 Then offset_grid_line = 0
		
		Call repaint_grid(offset_grid_line, wline, Index)
		
	End Sub
	
	Private Sub V_Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles V_Cancel.Click
		
		'decrease vochnum by one sot entclear can add one in this case
		Me.vouchnum.Text = CStr(Val(Me.vouchnum.Text) - 1)
		Call entclearheader()
		Call entcleardetail()
		
		vouchnum.Focus()
		V_done.Enabled = False
		
	End Sub
	
	Private Sub V_line_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles V_line.Enter
		Dim Index As Short = V_line.GetIndex(eventSender)
		Dim n As Object
		
		V_line(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		For n = 0 To 7
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object n. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			V_line(n).Text = n + 1 + offset_grid_line
		Next 
		
		'checks to make sure not below lines all ready entered
		If Index > max_grid_line Then
			reimb(max_grid_line - 1).Focus()
			Exit Sub
			
		End If
		
		'    V_line(Index).Text = Index + 1 + offset_grid_line
		
		'        voucher_detail_grid(Index + offset_grid_line, 1) = CLng(V_line(Index).Text)
		
		acct_num(Index).Focus()
		KeyAscii = 0
		
		
	End Sub
	
	
	Private Sub V_line_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles V_line.Leave
		Dim Index As Short = V_line.GetIndex(eventSender)
		V_line(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	
	Private Sub vend_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vend_num.Enter
		vend_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		vend_num.SelectionStart = 0
		vend_num.SelectionLength = Len(vend_num.Text)
		
	End Sub
	
	Private Sub vend_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles vend_num.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		If KeyAscii = 13 Then
			valid_name = "N"
			'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selected_name_key = ""
			
			
			If Len(vend_num.Text) = 0 Then
				Call namelookup()
				'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Me.vend_num.Text = selected_name_key
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				selected_name_key = vend_num.Text
			End If
			
			Call chkname(vend_num)
			
			If valid_name = "N" Then
				vendname.Text = ""
				MsgBox("Invalid vendor number")
				
				Call ets_set_selected()
				GoTo EventExitSub
			End If
			
			Call vend_nameget(selected_name_key)
			
			voucher.sort_name = selected_sort_name
			'UPGRADE_WARNING: Couldn't resolve default property of object vouch_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			voucher.name_key = vouch_name_key
			'UPGRADE_WARNING: Couldn't resolve default property of object vouch_screen_nam. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			voucher.screen_nam = vouch_screen_nam
			'UPGRADE_WARNING: Couldn't resolve default property of object vouch_screen_nam. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			vendname.Text = vouch_screen_nam
			
			If Len(vouch_dr_acct) <> 0 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object vouch_dr_acct. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Me.acct_num(0).Text = vouch_dr_acct
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
	
	Private Sub vend_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vend_num.Leave
		vend_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub VendDiscAmt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VendDiscAmt.Enter
		VendDiscAmt.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		VendDiscAmt.SelectionStart = 0
		VendDiscAmt.SelectionLength = Len(VendDiscAmt.Text)
		
	End Sub
	
	Private Sub VendDiscAmt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles VendDiscAmt.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		If KeyAscii = 13 Then
			
			Call check_amount(VendDiscAmt)
			VendDiscAmt.Text = VB6.Format(VendDiscAmt.Text, "###0.00;-###0.00")
			System.Windows.Forms.SendKeys.Send("{tab}")
			KeyAscii = 0
			voucher.disc_amt = Val(VendDiscAmt.Text)
			
			
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub VendDiscAmt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VendDiscAmt.Leave
		VendDiscAmt.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub VendInvAmt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VendInvAmt.Enter
		'invoice_left_to_enter = invoice_left_to_enter + vendinvamt
		VendInvAmt.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		'vendinvamt = ""
		VendInvAmt.SelectionStart = 0
		VendInvAmt.SelectionLength = Len(VendInvAmt.Text)
		
	End Sub
	
	Private Sub VendInvAmt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles VendInvAmt.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Then
			If Val(VendInvAmt.Text) = 0 Then
				MsgBox("Please enter an amount")
				GoTo EventExitSub
			End If
			
			invoice_left_to_enter = CDec(VendInvAmt.Text)
			End_Session.Enabled = False
			voucher.vouch_Amt = Val(VendInvAmt.Text)
			VendInvAmt.Text = VB6.Format(VendInvAmt.Text, "###0.00;-###0.00")
			System.Windows.Forms.SendKeys.Send("{tab}")
			KeyAscii = 0
		End If
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub VendInvAmt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VendInvAmt.Leave
		VendInvAmt.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub vendInvNum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vendInvNum.Enter
		vendInvNum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		vendInvNum.SelectionStart = 0
		vendInvNum.SelectionLength = Len(vendInvNum.Text)
		
	End Sub
	
	Private Sub vendInvNum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles vendInvNum.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If Len(vendInvNum.Text) = 0 Then vendInvNum.Text = " "
		If KeyAscii = 13 Then
			voucher.vend_inv = vendInvNum.Text
			System.Windows.Forms.SendKeys.Send("{tab}")
			KeyAscii = 0
			
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub vendInvNum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vendInvNum.Leave
		vendInvNum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	
	
	Private Sub vouch_desc_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vouch_desc.Enter
		Dim Index As Short = vouch_desc.GetIndex(eventSender)
		vouch_desc(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		vouch_desc(Index).SelectionStart = 0
		vouch_desc(Index).SelectionLength = Len(vouch_desc(Index).Text)
		
		'checks to make sure not below lines allready entered
		If Index > max_grid_line Then
			reimb(max_grid_line - 1).Focus()
			Exit Sub
		End If
		
	End Sub
	
	Private Sub vouch_desc_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles vouch_desc.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = vouch_desc.GetIndex(eventSender)
		Select Case KeyCode
			
			Case System.Windows.Forms.Keys.F3
				
				If Index <> 0 Then
					vouch_desc(Index).Text = vouch_desc(Index - 1).Text
					System.Windows.Forms.SendKeys.Send("{ENTER}")
				End If
		End Select
		
	End Sub
	
	Private Sub vouch_desc_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles vouch_desc.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = vouch_desc.GetIndex(eventSender)
		If KeyAscii = 13 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object voucher_detail_grid(Index + offset_grid_line, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			voucher_detail_grid(Index + offset_grid_line, 3) = vouch_desc(Index).Text
			amt(Index).Focus()
			KeyAscii = 0
			
		End If
		
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub vouch_desc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vouch_desc.Leave
		Dim Index As Short = vouch_desc.GetIndex(eventSender)
		vouch_desc(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub vouchnum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vouchnum.Enter
		Dim tempset As Object
		Dim tempdb As Object
		Call ets_set_selected()
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		offset_grid_line = 0
		max_grid_line = 1
		End_Session.Enabled = True
		
		For num = 0 To 50
			temp_array(num, 0) = ""
			temp_array(num, 1) = ""
		Next 
		
		'code to end of sub added to fill in next vouch num 8/27/2009 scs
		'fixed code lhw 09/03/2009  not previously sorted
		db = ap_data_path & "ap.mdb"
		tempdb = DAODBEngine_definst.OpenDatabase(db)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object tempdb.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		tempset = tempdb.OpenRecordset("voucher", dao.RecordsetTypeEnum.dbOpenDynaset)
		sqlstmnt = "Select * from voucher order by vouch_num"
		
		'UPGRADE_WARNING: Couldn't resolve default property of object tempdb.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		tempset = tempdb.OpenRecordset(sqlstmnt)
		'UPGRADE_WARNING: Couldn't resolve default property of object tempset.MoveLast. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		tempset.MoveLast()
		
		'UPGRADE_WARNING: Couldn't resolve default property of object tempset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		vouchnum.Text = CStr(tempset.Fields("vouch_num") + 1)
		voucher.vouch_num = CInt(vouchnum.Text) 'lhw added 09/03/2009
		chknum.Focus()
		
	End Sub
	
	Private Sub vouchnum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles vouchnum.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		If KeyAscii = 13 Then
			If Val(vouchnum.Text) = 0 Then
				MsgBox("Please enter a number")
				GoTo EventExitSub
			End If
			
			If Not IsNumeric(vouchnum.Text) Then
				MsgBox("Not a valid number")
				Call ets_set_selected()
				GoTo EventExitSub
			End If
			
			valid_vouch = "N"
			Call chkvouchnumverify(CStr(vouchnum.Text))
			If valid_vouch = "N" Then
				MsgBox("This voucher number has been used - Please Re-enter")
				Call ets_set_selected()
				GoTo EventExitSub
			End If
			
			voucher.vouch_num = CInt(vouchnum.Text)
			chknum.Focus()
			KeyAscii = 0
			
		End If
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub vouchnum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vouchnum.Leave
		vouchnum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		'End_Session.Enabled = False
	End Sub
End Class