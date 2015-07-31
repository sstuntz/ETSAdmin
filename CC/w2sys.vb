Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class w2sys
	Inherits System.Windows.Forms.Form
	
	'****************
	'revision History
	'original date of this form is 11/22/2000 - SCS
	
	'****************
	'Option Explicit
	Private Sub cmdRefresh_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRefresh.Click
		'this is really only needed for multi user apps
		Data1.Refresh()
	End Sub
	
	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
		'the following code checks for completeness
		'the string field has a list of the field numbers to check
		For num = 0 To 100
			msg = "," & CStr(num) & ","
			Response = InStr(",1,3,4,5,6,7,8,", msg)
			If Response <> 0 Then
				If Len(txtfields(num).Text) = 0 Then
					MsgBox("Each line must be filled in.")
					txtfields(num).Focus()
					Exit Sub
				End If
			End If
		Next 
		'UPGRADE_ISSUE: Data method Data1.UpdateRecord was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.UpdateRecord()
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Bookmark = VB6.CopyArray(Data1.Recordset.LastModified)
		Me.Close()
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub Command1_Click()
		prtDestination = CStr(0)
		prtreportfilename = ee_report_path & "eespec.rpt"
		Call frmcrystal_call()
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
	
	Private Sub w2sys_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Msgbox ("fix the path name and erase this box")
		'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For num = 0 To Me.Controls.Count() - 1
			'UPGRADE_ISSUE: Data object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.Label Then
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sqlstmnt = VB.Right(CType(Me.Controls(num), Object).DatabaseName, Len(CType(Me.Controls(num), Object).DatabaseName) - 20)
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CType(Me.Controls(num), Object).DatabaseName = cc_data_path & sqlstmnt
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().RecordSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Len(CType(Me.Controls(num), Object).RecordSource) > 0 Then
					CType(Me.Controls(num), Object).Refresh()
				End If
			End If
		Next 
		
		'the following code is to fill data entry screen with repetitive data
		'Data1.RecordSource = 'select * from xxx where name_key = ' & Chr$(34) & selected_name_key_ee & Chr$(34)
		'Data1.Refresh
		'txtFields(1).Text = selected_screen_nam
		'txtFields(0).Text = selected_name_key
	End Sub
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
		Dim Index As Short = txtFields.GetIndex(eventSender)
		Call ets_set_selected()
	End Sub
	
	Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtFields.GetIndex(eventSender)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			Select Case Index
				
				Case 7
					txtfields(Index).Text = UCase(txtfields(Index).Text)
					
				Case 9, 10, 11, 12, 13
					txtfields(Index).Text = UCase(txtfields(Index).Text)
					If txtfields(Index).Text <> "MSA" Then
						If txtfields(Index).Text <> "" Then
							MsgBox("Not a valid choice, please enter MSA or nothing   ")
							Call ets_set_selected()
							GoTo EventExitSub
						End If
					End If
					
				Case 14, 15, 16, 17
					txtfields(Index).Text = UCase(txtfields(Index).Text)
					If txtfields(Index).Text <> "401K" Then
						If txtfields(Index).Text <> "403B" Then
							If txtfields(Index).Text <> "" Then
								MsgBox("Not a valid choice, please enter 401K or 403B or nothing   ")
								Call ets_set_selected()
								GoTo EventExitSub
							End If
						End If
					End If
					
					
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
	
	Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Leave
		Dim Index As Short = txtFields.GetIndex(eventSender)
		txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
End Class