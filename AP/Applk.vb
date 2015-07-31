Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class applk
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 3/13/98 -lhw
	
	'****************
	
	Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click
		If selectedcell = False Then
			MsgBox("Nothing selected")
			Exit Sub
		End If
		
		'to find the correct name key
		'   Grid1.Col = 0
		'  sqlstmnt = " name_key = "
		'     sqlstmnt = sqlstmnt & Chr(34) & Grid1.Text & Chr(34)
		
		
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		rs = Data1.Recordset
		rs.FindFirst(sqlstmnt)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		selected_name_key = rs.Fields("name_key").Value
		selected_screen_nam = rs.Fields("screen_nam").Value
		selected_lookup_date = rs.Fields("dt_paid").Value
		
		Me.Close()
	End Sub
	
	Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
		On Error Resume Next
		'Load the d/e form
		entry_type = "ADD"
		frmmiscpmt.ShowDialog()
		
		'
		'       'clear the grid
		'
		'    For num = Grid1.Rows - 1 To 1 Step -1
		'    Grid1.RemoveItem num
		'    Next
		'
		'
		'    Data1.Refresh              'fills the grid
		'    num = 0
		'    Data1.Recordset.MoveFirst
		'    Do While Not Data1.Recordset.EOF
		''   Grid1.AddItem Data1.Recordset.Fields("name_key") & Chr(9) & Data1.Recordset.Fields("screen_nam") & Chr(9) & Data1.Recordset.Fields("dt_paid"), num
		'    Data1.Recordset.MoveNext
		'    num = num + 1
		'    Loop
		'    Grid1.RemoveItem num
		'
		'     'fix grid size
		' '   Grid1.ColWidth(0) = 975
		'  '  Grid1.ColWidth(1) = 1815
		'   ' Grid1.ColWidth(2) = 975
		
	End Sub
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		selected_name_key = " "
		selected_screen_nam = " "
		'        selected_lookup_date = " "
		
		Me.Close()
		
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		
		'clear the grid
		
		'   For num = Grid1.Rows - 1 To 1 Step -1
		'    Grid1.RemoveItem num
		'    Next
		'    Grid1.Row = 0
		'    Grid1.Col = 0
		'    Grid1.Text = ""
		'    Grid1.Col = 1
		'    Grid1.Text = ""
		'    Grid1.Col = 2
		'    Grid1.Text = ""
		'
		'
		'    Data1.recordsource = "select * from miscpmt where dflag <> 'Y' and dt_paid = " & Chr(35) & txtfields(0) & Chr(35) & "order by sort_name"
		'
		On Error Resume Next
		Data1.Refresh()
		If Err.Number = 3075 Then
			MsgBox("Enter a check date to select in the box above.")
			txtFields(0).Focus()
			Call ets_set_selected()
			
			Exit Sub
		End If
		On Error GoTo 0
		
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.MoveFirst()
		If Err.Number = 3021 Then
			MsgBox("Enter a valid check date to select in the box above.")
			txtFields(0).Focus()
			Call ets_set_selected()
			
			Exit Sub
		End If
		On Error GoTo 0
		
		num = 0
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not Data1.Recordset.EOF
			'   Grid1.AddItem Data1.Recordset.Fields("name_key") & Chr(9) & Data1.Recordset.Fields("screen_nam") & Chr(9) & Data1.Recordset.Fields("dt_paid"), num
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.MoveNext()
			num = num + 1
		Loop 
		
		'fix grid size
		'  Grid1.ColWidth(0) = 975
		' Grid1.ColWidth(1) = 1815
		'Grid1.ColWidth(2) = 975
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		'  'clear the grid
		'   For num = Grid1.Rows - 1 To 1 Step -1
		'    Grid1.RemoveItem num
		'    Next
		'    Grid1.Row = 0
		'    Grid1.Col = 0
		'    Grid1.Text = ""
		'    Grid1.Col = 1
		'    Grid1.Text = ""
		'    Grid1.Col = 2
		'    Grid1.Text = ""
		'
		'
		'    'load the grid
		'    Data1.recordsource = "select * from miscpmt where dflag <> ""Y"" order by dt_paid "
		'    Data1.Refresh
		'    Data1.Recordset.MoveFirst
		'    num = 0
		'    Do While Not Data1.Recordset.EOF
		'    Grid1.AddItem Data1.Recordset.Fields("name_key") & Chr(9) & Data1.Recordset.Fields("screen_nam") & Chr(9) & Data1.Recordset.Fields("dt_paid"), num
		'    Data1.Recordset.MoveNext
		'    num = num + 1
		'    Loop
		'
		'    'fix grid size
		'    Grid1.ColWidth(0) = 975
		'    Grid1.ColWidth(1) = 1815
		'   Grid1.ColWidth(2) = 975
	End Sub
	
	Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Edit.Click
		If selectedcell = False Then
			MsgBox("Nothing selected")
			Exit Sub
		End If
		
		'     Grid1.Col = 0
		'       sqlstmnt = " name_key = "
		'        sqlstmnt = sqlstmnt & Chr(34) & Grid1.Text & Chr(34)
		'
		
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		rs = Data1.Recordset
		rs.FindFirst(sqlstmnt)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		selected_name_key = rs.Fields("name_key").Value
		
		entry_type = "EDIT"
		frmmiscpmt.ShowDialog()
		'clear the grid
		
		'    For num = Grid1.Rows - 1 To 1 Step -1
		'    Grid1.RemoveItem num
		'    Next
		'
		'    Data1.Refresh
		'    num = 0
		'    Data1.Recordset.MoveFirst
		'    Do While Not Data1.Recordset.EOF
		'    Grid1.AddItem Data1.Recordset.Fields("name_key") & Chr(9) & Data1.Recordset.Fields("screen_nam") & Chr(9) & Data1.Recordset.Fields("dt_paid"), num
		'    Data1.Recordset.MoveNext
		'    num = num + 1
		'    Loop
		'    Grid1.RemoveItem num
		'
		'     'fix grid size
		'    Grid1.ColWidth(0) = 975
		'    Grid1.ColWidth(1) = 1815
		'    Grid1.ColWidth(2) = 975
		
	End Sub
	
	Private Sub applk_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'data 1 = ap
		On Error Resume Next
		
		'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For num = 0 To Me.Controls.Count() - 1
			'UPGRADE_ISSUE: Data object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.Label Then
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sqlstmnt = VB.Right(CType(Me.Controls(num), Object).DatabaseName, Len(CType(Me.Controls(num), Object).DatabaseName) - 20)
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CType(Me.Controls(num), Object).DatabaseName = ap_data_path & sqlstmnt
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().recordsource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Len(CType(Me.Controls(num), Object).recordsource) > 0 Then
					CType(Me.Controls(num), Object).Refresh()
				End If
			End If
			
		Next 
		
		If function_type = "DATA_ENTRY" Then
			Accept.Enabled = True
		End If
		
		'    'clear the grid
		'    For num = 0 To Grid1.Rows - 1
		'    Grid1.RemoveItem num
		'    Next
		'
		'    'load the grid
		'    Data1.recordsource = "select * from miscpmt where dflag <> ""Y"" order by dt_paid "
		'    Data1.Refresh
		'    Data1.Recordset.MoveFirst
		'    num = 0
		'    Do While Not Data1.Recordset.EOF
		'    Grid1.AddItem Data1.Recordset.Fields("name_key") & Chr(9) & Data1.Recordset.Fields("screen_nam") & Chr(9) & Data1.Recordset.Fields("dt_paid"), num
		'    Data1.Recordset.MoveNext
		'    num = num + 1
		'    Loop
		'
		'    'fix grid size
		'    Grid1.ColWidth(0) = 975
		'    Grid1.ColWidth(1) = 1815
		'    Grid1.ColWidth(2) = 975
		'
	End Sub
	'Private Sub Grid1_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
	'    'telling the system a selection has been made
	'    selectedcell = True
	'     SendKeys "{TAB}"
	'    KeyAscii = 0
	'End Sub
	
	
	
	
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
		Dim Index As Short = txtFields.GetIndex(eventSender)
		
		Call ets_set_selected()
		
	End Sub
	
	Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtfields.GetIndex(eventSender)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			Select Case Index
				Case 0
					
					valid_Date = "N"
					senddate = txtFields(Index).Text
					Call etsdate(senddate, retdate, valid_Date)
					
					If valid_Date <> "N" Then
						txtFields(Index).Text = retdate
						txtFields(Index).Text = CStr(CDate(txtFields(Index).Text))
						
					Else
						MsgBox("Bad date")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					selected_lookup_date = CDate(retdate)
					Command1.Focus()
			End Select
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