Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class ar_calc_bal
	Inherits System.Windows.Forms.Form
	
	Public sqlstmt As String
	Public gljrnldb As dao.Database 'this is the destination
	'UPGRADE_WARNING: Arrays in structure gljrnlset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public gljrnlset As dao.Recordset
	
	
	Private Sub close_gl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles close_gl.Click
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		
		selected_end_date = CDate(txtfield(1).Text)
		
		MsgBox("Be patient. This is matching all invoice and cash to set the paid flag.")
		
		Call check_for_Complete_invoice(0, Today)
		MsgBox("Matching Process Complete")
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		
	End Sub
	
	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
		'Stop
		
		'UPGRADE_ISSUE: Data method Data1.UpdateRecord was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.UpdateRecord()
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Bookmark = VB6.CopyArray(Data1.Recordset.LastModified)
		
		close_gl.Enabled = True
		
		'close_gl.SetFocus
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
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
	
	Private Sub ar_calc_bal_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		' data1 = etssys
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
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().recordsource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Len(CType(Me.Controls(num), Object).recordsource) > 0 Then
					CType(Me.Controls(num), Object).Refresh()
				End If
			End If
			
		Next 
		
		
	End Sub
	
	Private Sub mth_name_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mth_name.Enter
		Call ets_set_selected()
	End Sub
	
	Private Sub mth_name_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles mth_name.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			mth_name.Text = VB.Left(UCase(mth_name.Text), 3)
			Response = InStr("JUL,AUG,SEP,OCT,NOV,DEC,JAN,FEB,MAR,APR,MAY,JUN", mth_name.Text)
			
			If Response = 0 Then
				MsgBox("Invalid Month")
				GoTo EventExitSub
			End If
			mth_num.Text = CStr(Int(Response / 4) + 1)
			
			cmdUpdate.Focus()
			KeyAscii = 0
		End If
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub mth_name_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mth_name.Leave
		mth_name.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub mth_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mth_num.Enter
		Call ets_set_selected()
	End Sub
	
	Private Sub mth_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mth_num.Leave
		mth_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub prt_unposted_Click()
		prtDestination = CStr(0)
		prtreportfilename = gl_report_path & "glunpost.rpt"
		' Call frmcrystal_Call
		
	End Sub
	
	Private Sub txtfield_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfield.Enter
		Dim Index As Short = txtfield.GetIndex(eventSender)
		txtfield(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		txtfield(Index).Text = ""
		txtfield(Index).SelectionStart = 0
		txtfield(Index).SelectionLength = Len(txtfield(Index).Text)
	End Sub
	
	Private Sub txtField_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtField.GetIndex(eventSender)
		If KeyAscii = 13 Then
			valid_Date = "N"
			senddate = txtfield(Index).Text
			Call etsdate(senddate, retdate, valid_Date)
			
			If valid_Date <> "N" Then
				txtfield(Index).Text = retdate
				txtfield(Index).Text = CStr(CDate(txtfield(Index).Text))
				
				'to test for a date range
				If Index = 1 Then
					'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
					If DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(txtfield(Index - 1).Text), CDate(txtfield(Index).Text)) > 31 Then
						MsgBox("Date range too large")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
				Else
					'fill in the month
					'this is for a fiscal month calculation
					num = Month(CDate(txtfield(Index).Text))
					
					mth_name.Text = Mid("JAN,FEB,MAR,APR,MAY,JUN,JUL,AUG,SEP,OCT,NOV,DEC", 1 + 4 * (num - 1), 3)
					mth_name.Text = VB.Left(UCase(mth_name.Text), 3)
					Response = InStr("JUL,AUG,SEP,OCT,NOV,DEC,JAN,FEB,MAR,APR,MAY,JUN", mth_name.Text)
					
					If Response = 0 Then
						MsgBox("Invalid Month")
						GoTo EventExitSub
					End If
					mth_num.Text = CStr(Int(Response / 4) + 1)
					
				End If
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
	Private Sub txtField_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField.Leave
		Dim Index As Short = txtField.GetIndex(eventSender)
		txtfield(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
End Class