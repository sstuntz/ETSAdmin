Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmnamcc1
	Inherits System.Windows.Forms.Form
	
	'****************
	'revision History
	'original date of this form is 9/23/96 -SCS
	'removed masked edit box on ss# 9/19/2007 lhw
	
	'****************
	
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		
		entry_type = "CANCEL"
		Me.Close()
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
					If TypeOf CType(System.Windows.Forms.Form.ActiveForm.Controls(num), Object) Is System.Windows.Forms.TextBox Or TypeOf CType(System.Windows.Forms.Form.ActiveForm.Controls(num), Object) Is System.Windows.Forms.MaskedTextBox Or TypeOf CType(System.Windows.Forms.Form.ActiveForm.Controls(num), Object) Is System.Windows.Forms.ComboBox Then
						'UPGRADE_ISSUE: Control method Screen.ActiveForm.Controls.DataChanged was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						CType(System.Windows.Forms.Form.ActiveForm.Controls(num), Object).DataChanged = False
					End If
					
				Next 
				
		End Select
		'  Screen.MousePointer = vbHourglass
	End Sub
	
	Private Sub dirdep_Click()
		'frmnamcc5.Show 1
		
	End Sub
	
	
	
	Private Sub frmnamcc1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
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
		
		'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		selected_name_key_cc = selected_name_key
		selected_screen_nam_cc = selected_screen_nam
		selected_sort_name_cc = selected_sort_name
		'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.RecordSource = "select * from nam_cc where name_key = " & Chr(34) & selected_name_key_cc & Chr(34)
		Data1.Refresh()
		
		'this checks to see if adding a record and changing the entry type
		
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		num = Data1.Recordset.RecordCount
		If Err.Number = 91 Or num = 0 Then
			entry_type = "ADD"
			entry_type_ee = "ADD"
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.AddNew()
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("sort_name").Value = selected_sort_name
			'comment out 9/19/2007 lhw
			'MaskEdBox1.Mask = ""
			'MaskEdBox1.Text = ""
			'MaskEdBox1.Mask = "###-##-####"
		Else
			entry_type_ee = "EDIT"
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Edit()
		End If
		
		
		function_type = "DATA_ENTRY"
		
		'the following checks to see if there is a vacation entry in which case yes is put in field vac_elig
		If entry_type_ee = "EDIT" Then
			db = cc_data_path & "cc.mdb"
			tmpdb = DAODBEngine_definst.OpenDatabase(db)
			tmpset = tmpdb.OpenRecordset("ccvac", dao.RecordsetTypeEnum.dbOpenDynaset)
			sqlstmnt = " name_key = " & Chr(34) & selected_name_key_cc & Chr(34)
			tmpset.FindFirst(sqlstmnt)
			If tmpset.NoMatch Then
				vac_Elig.Text = "N"
			Else
				vac_Elig.Text = "Y"
			End If
			
			vacation.Enabled = True
			
			'.Enabled = True
			'goto4.Enabled = True
			'goto5.Enabled = True
			'goto6.Enabled = True
			
		End If
		
		
		If txtFields(11).Text = "na" Or Len(txtFields(10).Text) = 0 Then
			txtFields(11).Text = "na"
			
		End If
		
	End Sub
	
	Private Sub goto6_Click()
		frmnamcc3.ShowDialog()
	End Sub
	
	Private Sub Save_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Save.Click
		On Error Resume Next
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
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
		
		'this finds and sets the agency pay freq code
		' freq_code = pay_code_freq
		
		
		'this enters the default agency dfq into all the fields
		
		If entry_type_ee = "ADD" Then
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Edit()
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("pay_freq").Value = Data3.Recordset.Fields("pay_freq").Value
			'  Data1.Recordset("fica_exmt") = "N"
			' Data1.Recordset("med_exmt") = "N"
			'   Data1.Recordset("aeic_elig") = "N"
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("addfwt_dfq").Value = Data3.Recordset.Fields("pay_freq").Value
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("addswt_dfq").Value = Data3.Recordset.Fields("pay_freq").Value
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("save1_dfq").Value = Data3.Recordset.Fields("pay_freq").Value
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("save2_dfq").Value = Data3.Recordset.Fields("pay_freq").Value
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("save3_dfq").Value = Data3.Recordset.Fields("pay_freq").Value
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("dduct1_dfq").Value = Data3.Recordset.Fields("pay_freq").Value
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("dduct2_dfq").Value = Data3.Recordset.Fields("pay_freq").Value
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("dduct3_dfq").Value = Data3.Recordset.Fields("pay_freq").Value
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("dduct4_dfq").Value = Data3.Recordset.Fields("pay_freq").Value
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("ddep_dfq").Value = Data3.Recordset.Fields("pay_freq").Value
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Update()
		End If
		
		Me.Close()
		
		frmnamcc2.ShowDialog()
		
	End Sub
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
		Dim Index As Short = txtFields.GetIndex(eventSender)
		Call ets_set_selected()
		
		
		Select Case Index
			'Case 7
			'txtfields(1) = selected_screen_nam_cc
			'txtfields(0) = selected_name_key_cc
			
			Case 19 'added 09/19/2007 lhw
				txtFields(1).Text = selected_screen_nam_cc
				txtFields(0).Text = selected_name_key_cc
				'added 7/13/04 lhw  '8/4/04
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				txtFields(6).Text = Data1.Recordset.Fields("dept_num").Value & ""
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				txtFields(11).Text = Data1.Recordset.Fields("disab_num").Value & ""
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				txtFields(18).Text = Data1.Recordset.Fields("makeup").Value & ""
				
				
		End Select
		
	End Sub
	
	Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtFields.GetIndex(eventSender)
		
		If KeyAscii = 13 Then
			
			Select Case Index
				Case 1
				Case 2
					valid_YN = "N"
					Call ets_format(txtFields(Index), retstring, "2", valid_YN)
					If valid_YN = "N" Then
						MsgBox("invalid phone number")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					txtFields(Index).Text = retstring
					retstring = ""
					
				Case 3, 4, 16
					If Len(txtFields(Index).Text) = 0 Then
						'UPGRADE_ISSUE: TextBox property txtFields.DataChanged was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						txtFields(Index).DataChanged = False
						System.Windows.Forms.SendKeys.Send("{tab}")
						KeyAscii = 0
						GoTo EventExitSub
					End If
					
					valid_Date = "N"
					Call etsdate(txtFields(Index), retdate, valid_Date)
					If valid_Date = "Y" Then
						txtFields(Index).Text = CStr(CDate(retdate))
						If Index = 3 Then 'forces anniv month to be the month of hire date
							txtFields(5).Text = CStr(Month(CDate(txtFields(Index).Text)))
						End If
						
						System.Windows.Forms.SendKeys.Send(("{tab}"))
						KeyAscii = 0
						GoTo EventExitSub
					End If
					MsgBox("Not a Valid Date")
					Call ets_set_selected()
					GoTo EventExitSub
					
				Case 5
					If Val(txtFields(Index).Text) > 12 Or Val(txtFields(Index).Text) < 1 Then
						MsgBox("Invalid Month Number")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
				Case 6
					
					valid_dpt = "N"
					senddpt = txtFields(6).Text
					retdpt = ""
					retdptdesc = ""
					
					Call etsdptnum_chk(senddpt, retdpt, retdptdesc, valid_dpt)
					
					If valid_dpt = "N" Then
						MsgBox("Not a valid department number.")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					txtFields(6).Text = retdpt
					
				Case 11
					'this checks the disab name and number
					
					If txtFields(11).Text = "na" Then
						GoTo done1
					End If
					
					
					If Len(txtFields(Index).Text) = 0 Then
						disablookup.ShowDialog()
						txtFields(Index).Text = selected_lookup_num
					End If
					
					valid_YN = "N"
					Call ets_disab_num_chk(txtFields(11), retjobdesc, valid_YN)
					If valid_YN = "N" Then
						MsgBox("Invalid Disab number.")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
					txtFields(Index + 1).Text = retjobdesc
					
				Case 14, 17 'formats $ fields added 11/17/02 lhw
					
					If Len(txtFields(Index).Text) = 0 Then
						txtFields(Index).Text = CStr(0)
					End If
					txtFields(Index).Text = VB6.Format(txtFields(Index).Text, "###0.00;(###0.00)")
					
					
					
				Case 18
					txtFields(Index).Text = UCase(txtFields(Index).Text)
					If txtFields(Index).Text <> "Y" Then
						If txtFields(Index).Text <> "N" Then
							MsgBox("Please use Y or N")
							Call ets_set_selected()
							GoTo EventExitSub
						End If
					End If
					
				Case 19 'added 09/19/2007 lhw
					Call ets_format(txtFields(Index), retstring, "1", "N") 'ss# in mod
					If valid_YN = "N" Then
						MsgBox("invalid SS# number")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					txtFields(Index).Text = retstring
					retstring = ""
					
					
					'UPGRADE_ISSUE: TextBox property txtFields.DataChanged was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					If txtFields(19).DataChanged = True Then
						valid_lookup = "N"
						Call check_dup_soc_sec_num(txtFields(19).Text, valid_lookup)
						If valid_lookup = "N" Then
							'MsgBox ("This is a duplicate social security number.  Please check it or leave blank.")
							GoTo EventExitSub
						End If
					End If
					
					
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
	
	Private Sub vac_Elig_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vac_Elig.Enter
		If vac_Elig.Text = "" Then vac_Elig.Text = "N" 'added 7/3/03 TMK
		Call ets_set_selected()
	End Sub
	
	Private Sub vac_Elig_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles vac_Elig.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		' this is where to put the code to set up vacation table
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			vac_Elig.Text = UCase(vac_Elig.Text)
			If vac_Elig.Text <> "N" And vac_Elig.Text <> "Y" Then
				MsgBox("Please enter a Y or N")
				Call ets_set_selected()
				GoTo EventExitSub
			End If
			
			'UPGRADE_ISSUE: TextBox property vac_Elig.DataChanged was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			If entry_type = "ADD" Or vac_Elig.DataChanged = True Then
				If vac_Elig.Text = "Y" Then
					On Error Resume Next
					'this checks to add a vacation table entry and to ask if you want to edit it
					'UPGRADE_ISSUE: Data property Data4.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					Data4.Recordset.AddNew()
					'UPGRADE_ISSUE: Data property Data4.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					Data4.Recordset.Fields("name_key").Value = selected_name_key_cc
					'UPGRADE_ISSUE: Data property Data4.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					Data4.Recordset.Fields("screen_nam").Value = selected_screen_nam_cc
					'UPGRADE_ISSUE: Data property Data4.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					Data4.Recordset.Fields("sort_name").Value = selected_sort_name_cc
					'UPGRADE_ISSUE: Data property Data4.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					Data4.Recordset.Update()
					'If err = 3022 Then
					'On Error GoTo 0
					Response = MsgBox("Do you wish to edit the vacation table now?", 4)
					If Response = MsgBoxResult.Yes Then
						frmccvac.ShowDialog()
					End If
					'End If
				End If
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
	
	Private Sub vac_Elig_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vac_Elig.Leave
		Call ets_de_selected()
		vac_Elig.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
	
	Private Sub vacation_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vacation.Click
		frmccvac.ShowDialog()
		
	End Sub
End Class