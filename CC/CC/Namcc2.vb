Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmnamcc2
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 9/23/96 -SCS
	
	'****************
	
	Public tmp_txtField_value As String 'added 7/3/03 TMK for filling the default values
	
	Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.AddNew()
	End Sub
	
	Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
		'this may produce an error if you delete the last
		'record or the only record in the recordset
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Delete()
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.MoveNext()
	End Sub
	
	Private Sub cmdRefresh_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRefresh.Click
		'this is really only needed for multi user apps
		Data1.Refresh()
	End Sub
	
	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
		'UPGRADE_ISSUE: Data method Data1.UpdateRecord was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.UpdateRecord()
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Bookmark = VB6.CopyArray(Data1.Recordset.LastModified)
		Me.Close()
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
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
		'UPGRADE_ISSUE: Constant vbDataActionUnload was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
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
			Case vbDataActionUnload
				
				'UPGRADE_WARNING: Controls method Screen.ActiveForm.Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				For num = 0 To System.Windows.Forms.Form.ActiveForm.Controls.Count() - 1
					
					'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
					If TypeOf CType(System.Windows.Forms.Form.ActiveForm.Controls(num), Object) Is System.Windows.Forms.TextBox Or TypeOf CType(System.Windows.Forms.Form.ActiveForm.Controls(num), Object) Is System.Windows.Forms.MaskedTextBox Then
						'UPGRADE_ISSUE: Control method Screen.ActiveForm.Controls.DataChanged was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						CType(System.Windows.Forms.Form.ActiveForm.Controls(num), Object).DataChanged = False
					End If
					
				Next 
		End Select
		'Screen.MousePointer = vbHourglass
	End Sub
	
	
	
	Private Sub frmnamcc2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		On Error Resume Next
		
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
		
		If entry_type_ee = "EDIT" Then
			Save_back.Enabled = True
		End If
		
		'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.RecordSource = "select * from nam_cc where name_key = " & Chr(34) & selected_name_key_cc & Chr(34)
		Data1.Refresh()
		txtFields(1).Text = selected_screen_nam_cc
		txtFields(0).Text = selected_name_key_cc
		
		'next lines to open reference table so it can be used on this form
		
		tmpdb = DAODBEngine_definst.OpenDatabase(cc_data_path & "cc.mdb")
		tmpset = tmpdb.OpenRecordset("reference", dao.RecordsetTypeEnum.dbOpenDynaset)
		
		'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For num = 0 To Me.Controls.Count() - 1
			'this is how you get to the reference table
			'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.Label Then
				err.Clear()
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls(num).Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sqlstmnt = "select * from reference where ctrl_name = ""lbllabels"" and datum = " & Chr(34) & CType(Me.Controls(num), Object).Index & Chr(34) & " and form_name = " & Chr(34) & Me.Name & Chr(34)
				tmpset = tmpdb.OpenRecordset(sqlstmnt)
				If Err.Number <> 343 And Err.Number = 0 Then
					
					Do While Not tmpset.EOF
						
						CType(Me.Controls(num), Object).Text = tmpset.Fields("datum_desc").Value
						tmpset.MoveNext()
					Loop 
				End If
				
			End If
		Next 
		
	End Sub
	
	Private Sub Save_back_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Save_back.Click
		
		'check to make sure that there are deduction number for ded dol
		For num = 24 To 33 Step 3
			If Val(txtFields(num).Text) <> 0 Then
				If Len(txtFields(num - 1).Text) = 0 Then
					MsgBox("You must have a deduction number for each item with deduction dollars.")
					Exit Sub
				End If
			End If
		Next 
		
		
		err.Clear()
		On Error Resume Next
		For num = 24 To 33 Step 3
			If Val(txtFields(num).Text) = 0 Then
				txtFields(num).Text = CStr(0)
			End If
		Next 
		
		'form form1 in the set to reset these if there has been a lookup
		selected_screen_nam = selected_screen_nam_cc
		'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		selected_name_key = selected_name_key_cc
		On Error Resume Next
		'UPGRADE_ISSUE: Data method Data1.UpdateRecord was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.UpdateRecord()
		If Err.Number = 524 Then
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			MsgBox("Incomplete Data - Please check your form.")
			Exit Sub
		End If
		Me.Close()
		frmnamcc1.ShowDialog()
	End Sub
	
	Private Sub Save_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Save.Click
		'check to make sure that there are deduction number for ded dol
		For num = 24 To 33 Step 3
			If Val(txtFields(num).Text) <> 0 Then
				If Len(txtFields(num - 1).Text) = 0 Then
					MsgBox("You must have a deduction number for each item with deduction dollars.")
					Exit Sub
				End If
			End If
		Next 
		
		
		err.Clear()
		On Error Resume Next
		For num = 24 To 37 Step 3
			If Val(txtFields(num).Text) = 0 Then
				txtFields(num).Text = CStr(0)
			End If
		Next 
		
		'UPGRADE_ISSUE: Data method Data1.UpdateRecord was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.UpdateRecord()
		If Err.Number = 524 Then
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			MsgBox("Incomplete Data - Please check your form.")
			Exit Sub
		End If
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Bookmark = VB6.CopyArray(Data1.Recordset.LastModified)
		
		'if data changing for direct deposit then update it
		' For num = 26 To 28
		'If txtFields(num).DataChanged = True Then
		
		'  eedepsit.Recordset.Update
		'       If err = 524 Then
		'       Screen.MousePointer = 0
		'     MsgBox "Incomplete Data for direct deposit- Please check your form."
		'    Exit Sub
		'   End If
		'  Exit For
		'  End If
		' Next
		
		
		Me.Close()
		
		frmnamcc3.ShowDialog()
	End Sub
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
		Dim Index As Short = txtFields.GetIndex(eventSender)
		Call ets_set_selected()
		
		If Index = 2 Then
			txtFields(1).Text = selected_screen_nam_cc
			txtFields(0).Text = selected_name_key_cc
			
			For num = 24 To 33 Step 3
				If Val(Trim(txtFields(num).Text)) <> 0 Then
					senddpt = txtFields(num).Text
					Call etsdednum_chk(senddpt, retdpt, retdptdesc, valid_dpt)
					co_name(num).Text = retdptdesc
				Else
					co_name(num).Text = ""
					txtFields(num - 1).Text = CStr(0)
				End If
			Next 
			
			'Fill the text fields with the default values of the fields - TMK 7/3/03
			'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			For num = 0 To Me.Controls.Count() - 1
				If CType(Me.Controls(num), Object).Name = "txtFields" Then
					If CType(Me.Controls(num), Object).Text = "" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls(num).DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls(num).DataField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If CType(Me.Controls(num), Object).DataField <> "" And CType(Me.Controls(num), Object).DataSource <> "" Then
							'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DataField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
							'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields().DefaultValue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							tmp_txtField_value = Data1.Recordset.Fields(CType(Me.Controls(num), Object).DataField).DefaultValue
							'trim the quotation marks of text default values
							If VB.Left(tmp_txtField_value, 1) = Chr(34) Then
								CType(Me.Controls(num), Object).Text = VB.Right(VB.Left(tmp_txtField_value, Len(tmp_txtField_value) - 1), Len(tmp_txtField_value) - 2)
							End If
						End If
					End If
				End If
			Next 
			
			
		End If
		
		
	End Sub
	
	Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtFields.GetIndex(eventSender)
		If KeyAscii = 13 Then
			Select Case Index
				Case 2, 22
					'checks for yes no
					txtFields(Index).Text = UCase(txtFields(Index).Text)
					If txtFields(Index).Text <> "N" And txtFields(Index).Text <> "Y" Then
						MsgBox("Please enter a Y or N")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
					If Index = 16 And txtFields(Index).Text = "N" Then
						save.Focus()
						GoTo EventExitSub
					End If
					
					
				Case 3
					'checks for yes no v
					txtFields(Index).Text = UCase(txtFields(Index).Text)
					If txtFields(Index).Text <> "N" And txtFields(Index).Text <> "Y" And txtFields(Index).Text <> "V" Then
						MsgBox("Please enter a Y for checks or V for vouchers or N for nocheck.")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
				Case 4
					'checks for m or s
					txtFields(Index).Text = UCase(txtFields(Index).Text)
					If txtFields(Index).Text <> "M" And txtFields(Index).Text <> "S" Then
						MsgBox("Please enter a M or S")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
				Case 5, 21, 14, 22, 25, 28
					'checks for dfq
					txtFields(Index).Text = UCase(txtFields(Index).Text)
					
					If txtFields(Index).Text <> "A" And txtFields(Index).Text <> "M" And txtFields(Index).Text <> "S" And txtFields(Index).Text <> "B" And txtFields(Index).Text <> "W" Then
						MsgBox("Please enter an A,M,S,B, or W")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
				Case 6, 7, 9
					'checks for amount
					If Len(txtFields(Index).Text) = 0 Then
						txtFields(Index).Text = CStr(0)
					End If
					
					
					
				Case 11, 12
					
					If Len(txtFields(Index).Text) = 0 Then
						MsgBox("Please enter a response")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					If txtFields(12).Text = "na" Then
						txtFields(12).Text = " " 'has to be a non zero length field
						GoTo done1
					End If
					
					txtFields(Index).Text = UCase(txtFields(Index).Text)
					valid_State = "N"
					sendstate = txtFields(Index).Text
					Call ets_state_chk(sendstate, retstate, valid_State)
					If valid_State = "N" Then
						MsgBox("Invalid state")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
					
				Case 23, 26, 29, 32
					'checks for dollar amounts and reformats them
					If Len(txtFields(Index).Text) = 0 Then
						txtFields(Index).Text = CStr(0)
					End If
					txtFields(Index).Text = VB6.Format(txtFields(Index).Text, "###0.00;(###0.00)")
					
					
					
				Case 24, 27, 30, 33
					
					'na is a valid name
					
					If txtFields(Index).Text = "na" Then
						co_name(Index).Text = "None"
						GoTo done1
					End If
					
					If Len(txtFields(Index).Text) = 0 Then
						'  sched = "AT"
						deductslookup.ShowDialog()
						'sched = ""
						txtFields(Index).Text = selected_ded_num
						co_name(Index).Text = selected_plan_desc
					End If
					
					valid_dpt = "N"
					senddpt = txtFields(Index).Text
					retdpt = ""
					retdptdesc = ""
					
					Call etsdednum_chk(senddpt, retdpt, retdptdesc, valid_dpt)
					
					If valid_dpt = "N" Then
						MsgBox("Not a valid deduction number.")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
					co_name(Index).Text = retdptdesc
					
					
			End Select
			
done1: 
			System.Windows.Forms.SendKeys.Send("{TAB}")
			KeyAscii = 0
		End If
		
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Leave
		Dim Index As Short = txtFields.GetIndex(eventSender)
		Call ets_de_selected()
		txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
End Class