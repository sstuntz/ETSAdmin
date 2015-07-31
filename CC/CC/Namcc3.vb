Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmnamcc3
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 9/23/96 -SCS
	
	'****************
	Private Sub check_change() ' added 5/6/03 lhw
		
		'looks for changed data and updates the change date field in cc_deposit
		'UPGRADE_WARNING: Controls method Screen.ActiveForm.Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For num = 0 To System.Windows.Forms.Form.ActiveForm.Controls.Count() - 1
			
			'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If TypeOf CType(System.Windows.Forms.Form.ActiveForm.Controls(num), Object) Is System.Windows.Forms.TextBox Then
				
				'UPGRADE_WARNING: Couldn't resolve default property of object Screen.ActiveForm.Controls(num).DataChanged. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If CType(System.Windows.Forms.Form.ActiveForm.Controls(num), Object).DataChanged = True Then
					'update the change date for this bank
					'added bank aba  19 22 25 29   6/6/00 lhw
					On Error Resume Next
					'UPGRADE_WARNING: Couldn't resolve default property of object Screen.ActiveForm.Controls(num).Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Select Case CType(System.Windows.Forms.Form.ActiveForm.Controls(num), Object).Index
						'Case 3, 4, 7, 18, 19
						'eedepsit.Recordset.Fields("bk1_chg_Date") = Date
						'Case 8, 11, 20, 21, 22
						' eedepsit.Recordset.Fields("bk2_chg_Date") = Date
						'Case 12, 15, 23, 24, 25     'had 22  to 12 lhw 6/6/00
						' eedepsit.Recordset.Fields("bk3_chg_Date") = Date
						Case 16, 26, 27, 28, 29
							'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
							cc_deposit.Recordset.Fields("bk4_chg_Date").Value = Today
					End Select
					
					If Err.Number = 3265 Then
						MsgBox("The cc_deposit table has not been updated by ETS." & Chr(10) & "This message will be displayed whenever data is changed until the database is updated.")
					End If
					On Error GoTo 0
				End If
				
			End If
			
		Next 
		
	End Sub
	
	
	
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
	Private Sub Data1_Validate(ByRef Action As Short, ByRef Save As Short)
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
	
	
	Private Sub frmnamcc3_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		On Error Resume Next
		
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
		
		tmpdb = DAODBEngine_definst.OpenDatabase(cc_data_path & "cc.mdb")
		tmpset = tmpdb.OpenRecordset("reference", dao.RecordsetTypeEnum.dbOpenDynaset)
		
		'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For num = 0 To Me.Controls.Count() - 1
			
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
		
		If entry_type_ee = "EDIT" Then
			Save_back.Enabled = True
		End If
		
		'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.RecordSource = "select * from nam_cc where name_key = " & Chr(34) & selected_name_key_cc & Chr(34)
		Data1.Refresh()
		txtFields(1).Text = selected_screen_nam_cc
		txtFields(0).Text = selected_name_key_cc
		
		'UPGRADE_ISSUE: Data property cc_deposit.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		cc_deposit.RecordSource = "select * from cc_deposit where name_key = " & Chr(34) & selected_name_key_cc & Chr(34)
		cc_deposit.Refresh()
		'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		cc_deposit.Recordset.MoveFirst()
		
		If Err.Number = 3021 Then
			'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cc_deposit.Recordset.AddNew()
			'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cc_deposit.Recordset.Fields("screen_nam").Value = selected_screen_nam_cc
			'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cc_deposit.Recordset.Fields("name_key").Value = selected_name_key_cc
			'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cc_deposit.Recordset.Update()
			
		Else
			'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cc_deposit.Recordset.Edit()
			'lookup bank name
			'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			If Len(cc_deposit.Recordset.Fields("aba_num").Value) <> 0 Then
				
				
			End If
		End If
		
		
	End Sub
	
	
	Private Sub Save_go_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Save_go.Click
		err.Clear()
		On Error Resume Next
		
		Call check_change() ' this changes the date in cc_deposit
		
		'UPGRADE_ISSUE: Data method Data1.UpdateRecord was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.UpdateRecord()
		
		'UPGRADE_ISSUE: Data method cc_deposit.UpdateRecord was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		cc_deposit.UpdateRecord()
		'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		cc_deposit.Recordset.Bookmark = VB6.CopyArray(cc_deposit.Recordset.LastModified)
		
		If Err.Number = 524 Then
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			MsgBox("Incomplete Data - Please check your form.")
			Exit Sub
		End If
		
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Bookmark = VB6.CopyArray(Data1.Recordset.LastModified)
		
		Me.Close()
		
	End Sub
	
	Private Sub Save_back_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Save_back.Click
		
		Call check_change() ' this changes the date in cc_deposit
		
		'UPGRADE_ISSUE: Data method Data1.UpdateRecord was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.UpdateRecord()
		
		'UPGRADE_ISSUE: Data method cc_deposit.UpdateRecord was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		cc_deposit.UpdateRecord()
		'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		cc_deposit.Recordset.Bookmark = VB6.CopyArray(cc_deposit.Recordset.LastModified)
		
		If Err.Number = 524 Then
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			MsgBox("Incomplete Data - Please check your form.")
			Exit Sub
		End If
		Me.Close()
		frmnamcc2.ShowDialog()
		
	End Sub
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
		Dim Index As Short = txtFields.GetIndex(eventSender)
		Call ets_set_selected()
		
		If Index = 16 Then
			
			If txtFields(Index).Text = "" Then txtFields(Index).Text = "N" 'added 7/3/03 TMK
			num = 28
			If Len(txtFields(num).Text) <> 0 Then
				Call chkname_top(txtFields(num))
				co_name(num).Text = selected_screen_nam
			Else
				co_name(num).Text = ""
			End If
			
			'need to set data as not changed after all loaded (for loop)     added 6/2/00 scs
			'UPGRADE_WARNING: Controls method Screen.ActiveForm.Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			For num = 0 To System.Windows.Forms.Form.ActiveForm.Controls.Count() - 1
				
				'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				If TypeOf CType(System.Windows.Forms.Form.ActiveForm.Controls(num), Object) Is System.Windows.Forms.TextBox Then
					'UPGRADE_ISSUE: Control method Screen.ActiveForm.Controls.DataChanged was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					CType(System.Windows.Forms.Form.ActiveForm.Controls(num), Object).DataChanged = False
				End If
				
			Next 
			
			
		End If
		
		
	End Sub
	
	Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtFields.GetIndex(eventSender)
		If KeyAscii = 13 Then
			
			Select Case Index
				
				Case 16
					'checks for yes no v
					txtFields(Index).Text = UCase(txtFields(Index).Text)
					If txtFields(Index).Text <> "N" And txtFields(Index).Text <> "Y" And txtFields(Index).Text <> "V" Then
						MsgBox("Please enter a Y for checks or V for vouchers.")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
				Case 28
					package_Type_saved = package_Type
					package_Type = "GL"
					function_type = "DATA_ENTRY"
					
					valid_name = "N"
					'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selected_name_key = ""
					
					If Val(txtFields(Index).Text) = 0 Then
						Call namelookup()
						
						'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						txtFields(Index).Text = selected_name_key
						'on add look up the transit number
						'UPGRADE_ISSUE: Data property nam_bank.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						nam_bank.RecordSource = "select * from nam_Bank where bank_key = " & Chr(34) & txtFields(Index).Text & Chr(34)
						nam_bank.Refresh()
						
					End If
					
					Call chkname(txtFields(Index))
					
					If valid_name = "N" Then
						MsgBox("Invalid bank number")
						Call ets_set_selected()
						package_Type = package_Type_saved
						GoTo EventExitSub
					End If
					
					co_name(Index).Text = selected_screen_nam
					'UPGRADE_ISSUE: Data property nam_bank.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					nam_bank.RecordSource = "select * from nam_Bank where bank_key = " & Chr(34) & txtFields(Index).Text & Chr(34)
					nam_bank.Refresh()
					'UPGRADE_ISSUE: Data property nam_bank.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					txtFields(29).Text = nam_bank.Recordset.Fields("bk_transit").Value & ""
					package_Type = package_Type_saved
					
					
					
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