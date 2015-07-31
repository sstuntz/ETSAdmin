Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmgl_enter
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 6/23/96 -SCS
	'revised 9/24/96 to break acct number into the various fields
	
	'****************
	
	Private Sub acct_num_GotFocus()
		Call ets_set_selected()
		
	End Sub
	
	Private Sub acct_num_KeyPress(ByRef KeyAscii As Short)
		Dim acct_num As Object
		If KeyAscii = 13 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object acct_num.SelStart. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			acct_num.SelStart = 0
			valid_acct = "N"
			'UPGRADE_WARNING: Couldn't resolve default property of object acct_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sendacct = acct_num
			Call chk_acct_num_only(sendacct, valid_acct)
			If valid_acct = "Y" Then
				MsgBox("Account number already exists.")
				Call ets_set_selected()
				Exit Sub
			End If
			
			
			'UPGRADE_WARNING: Couldn't resolve default property of object acct_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtFields(0).Text = acct_num
			'UPGRADE_WARNING: Couldn't resolve default property of object acct_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtFields(8).Text = Mid(acct_num, 1, 4) 'acct_only
			'UPGRADE_WARNING: Couldn't resolve default property of object acct_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtFields(9).Text = Mid(acct_num, 6, 2) 'acct_pgm
			
			Call chk_acct_pgm_only(txtFields(9), valid_acct)
			If valid_acct = "N" Then
				msg = "Program number " & txtFields(9).Text & " is not set up."
				Response = MsgBox(msg)
				Call ets_set_selected()
				Exit Sub
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object acct_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtFields(10).Text = Mid(acct_num, 9, 2) 'acct_dpt
			Call chk_acct_dpt_only(txtFields(10), valid_acct)
			If valid_acct = "N" Then
				msg = "Department number " & txtFields(10).Text & " is not set up."
				Response = MsgBox(msg)
				Call ets_set_selected()
				Exit Sub
			End If
			
			System.Windows.Forms.SendKeys.Send("{tab}")
			KeyAscii = 0
		End If
		
	End Sub
	
	Private Sub acct_num_LostFocus()
		Dim acct_num As Object
		'UPGRADE_WARNING: Couldn't resolve default property of object acct_num.BackColor. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		acct_num.BackColor = RGB(255, 255, 255)
	End Sub
	
	Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
		Dim acct_num As Object
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.AddNew()
		'UPGRADE_WARNING: Couldn't resolve default property of object acct_num.SetFocus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		acct_num.SetFocus()
		'If entry_type <> "" Then acctlookup.Show
		Me.Close()
		
	End Sub
	
	Private Sub cmdRefresh_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRefresh.Click
		'this is really only needed for multi user apps
		Data1.Refresh()
	End Sub
	
	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
		'need code here to check fields for
		
		'UPGRADE_ISSUE: Data method Data1.UpdateRecord was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.UpdateRecord()
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Bookmark = VB6.CopyArray(Data1.Recordset.LastModified)
		'  If entry_type <> "" Then acctlookup.Show
		Me.Close()
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		'If entry_type <> "" Then acctlookup.Show
		Me.Close()
		
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		'need to put master password on this delete key
		'need msgbox to say account# in yrgenled and cannot be deleted
		'  Data1.Recordset.Delete
		'  Data1.Recordset.MoveNext
		
	End Sub
	
	Private Sub frmgl_enter_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim acct_num As Object
		' data1 = glchr
		' data2 = glchr
		' On Error Resume Next
		
		'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For num = 0 To Me.Controls.Count() - 1
			'UPGRADE_ISSUE: Data object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.Label Then
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sqlstmnt = VB.Right(CType(Me.Controls(num), Object).DatabaseName, Len(CType(Me.Controls(num), Object).DatabaseName) - 20)
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CType(Me.Controls(num), Object).DatabaseName = gl_data_path & sqlstmnt
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().recordsource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Len(CType(Me.Controls(num), Object).recordsource) > 0 Then
					CType(Me.Controls(num), Object).Refresh()
				End If
			End If
			
		Next 
		
		'UPGRADE_ISSUE: Data property Data1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.recordsource = "select * from chacct where acct_num = " & Chr(34) & selected_acct_num & Chr(34)
		Data1.Refresh()
		
		Select Case entry_type
			Case "ADD"
				'cmdAdd.Visible = True
				'UPGRADE_WARNING: Couldn't resolve default property of object acct_num.Enabled. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				acct_num.Enabled = True
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Data1.Recordset.AddNew()
				cmdUpdate.Visible = True
			Case "EDIT"
				cmdUpdate.Visible = True
				
		End Select
		
		acctlookup.Hide()
		
		'       If glsys.Recordset.Fields("acct_num_len") <> 10 Then
		'     acct_num.Mask = glsys.Recordset.Fields("Acct_num_mask")
		'   ' Debug.Print acct_num.Mask
		'   acct_num_blank = glsys.Recordset.Fields("Acct_num_blank")
		'  'Debug.Print acct_num_blank
		'  acct_num.Format = glsys.Recordset.Fields("Acct_num_mask")
		' Else
		'        acct_num.Mask = "####-##-##"
		'      acct_num_blank = "____-__-__"
		'     End If
		
		
	End Sub
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
		Dim Index As Short = txtFields.GetIndex(eventSender)
		Call ets_set_selected()
	End Sub
	
	Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtfields.GetIndex(eventSender)
		Dim ref As Object
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			Select Case Index
				'added next 7 line to fix entering a blank ref# 11/19/01 lhw
				Case 2
					If Val(txtFields(2).Text) = 0 Then
						MsgBox("Please enter a number")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
			End Select
			
			If Index = 2 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object ref. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ref = txtFields(Index).Text
				'UPGRADE_WARNING: Couldn't resolve default property of object ref. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sqlstmnt = " gl_ref_no = " & ref
				
				'UPGRADE_ISSUE: Data property Data2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				rs = Data2.Recordset
				rs.FindFirst(sqlstmnt)
				
				'UPGRADE_ISSUE: Data property Data2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				If Data2.Recordset.NoMatch Then
					MsgBox("Invalid Reference number. Please re-enter")
					Call ets_set_selected()
					GoTo EventExitSub
				End If
				
			End If
			
			
			If Index = 3 Then
				txtFields(Index).Text = UCase(txtFields(Index).Text)
				If CStr(txtFields(Index).Text) <> "CR" Then
					If CStr(txtFields(Index).Text) <> "DR" Then
						MsgBox("Please enter CR or DR")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
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
	
	Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
		Dim Index As Short = txtfields.GetIndex(eventSender)
		txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
End Class