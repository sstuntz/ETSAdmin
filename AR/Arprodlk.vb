Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class productlookup
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 9/23/96 -SCS
	
	'****************
	
	Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click
		If selectedcell = False Then
			MsgBox("Nothing selected")
			Exit Sub
		End If
		
		'    Grid1.Col = 0
		'    'sqlstmnt = " prod_num = " & Grid1.Text
		'   sqlstmnt = " prod_num = " & Chr(34) & Grid1.Text & Chr(34)
		
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		rs = Data1.Recordset
		rs.FindFirst(sqlstmnt)
		
		selected_prod_num = rs.Fields("prod_num").Value
		selected_prod_desc = rs.Fields("prod_Desc").Value
		retlookup_price = rs.Fields("unit_price").Value
		
		Me.Close()
	End Sub
	
	Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
		On Error Resume Next
		
		entry_type = "ADD"
		frmar_prod.ShowDialog()
		
		'clear the grid
		
		'    For num = Grid1.Rows - 1 To 1 Step -1
		'    Grid1.RemoveItem num
		'    Next
		'
		'    Data1.Refresh
		'    num = 0
		'    Data1.Recordset.MoveFirst
		'    Do While Not Data1.Recordset.EOF
		'    Grid1.AddItem Data1.Recordset.Fields("prod_num") & Chr(9) & Data1.Recordset.Fields("prod_desc") & Chr(9) & Data1.Recordset.Fields("unit_price"), num
		'    Data1.Recordset.MoveNext
		'    num = num + 1
		'    Loop
		'    Grid1.RemoveItem num
		'
		'    Grid1.ColWidth(0) = 800
		'    Grid1.ColWidth(1) = 1600
		'    Grid1.ColWidth(2) = 1600
		
	End Sub
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		selected_prod_num = " "
		selected_prod_desc = " "
		retlookup_price = 0
		
		Me.Close()
		
	End Sub
	
	Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Edit.Click
		If selectedcell = False Then
			MsgBox("Nothing selected")
			Exit Sub
		End If
		
		'    Grid1.Col = 0
		'
		'    sqlstmnt = " prod_num = "
		'    sqlstmnt = sqlstmnt & Chr(34) & Grid1.Text & Chr(34)
		'    Set rs = Data1.Recordset
		'    rs.FindFirst sqlstmnt
		'
		'    selected_prod_num = rs.Fields("prod_num")
		'
		'    entry_type = "EDIT"
		'    frmar_prod.Show 1
		'       'clear the grid
		'
		'    For num = Grid1.Rows - 1 To 1 Step -1
		'    Grid1.RemoveItem num
		'    Next
		'
		'    Data1.Refresh
		'    num = 0
		'    Data1.Recordset.MoveFirst
		'    Do While Not Data1.Recordset.EOF
		'    Grid1.AddItem Data1.Recordset.Fields("prod_num") & Chr(9) & Data1.Recordset.Fields("prod_desc") & Chr(9) & Data1.Recordset.Fields("unit_price"), num
		'    Data1.Recordset.MoveNext
		'    num = num + 1
		'    Loop
		'    Grid1.RemoveItem num
		'
		'    Grid1.ColWidth(0) = 800
		'    Grid1.ColWidth(1) = 1600
		'    Grid1.ColWidth(2) = 1600
		
	End Sub
	
	Private Sub productlookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		' data1 = ar
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
		
		
		'selectedcell = False
		
		If function_type = "DATA_ENTRY" Then
			Accept.Enabled = True
		End If
		
		'clear the grid
		'    For num = 0 To Grid1.Rows - 1
		'    Grid1.RemoveItem num
		'    Next
		'
		'    Data1.Refresh
		'    num = 0
		'    Data1.Recordset.MoveFirst
		'    Do While Not Data1.Recordset.EOF
		'    Grid1.AddItem Data1.Recordset.Fields("prod_num") & Chr(9) & Data1.Recordset.Fields("prod_desc") & Chr(9) & Data1.Recordset.Fields("unit_price"), num
		'    Data1.Recordset.MoveNext
		'    num = num + 1
		'    Loop
		'    Grid1.RemoveItem num
		'
		'    'Debug.Print num
		'
		'    Grid1.ColWidth(0) = 800
		'    Grid1.ColWidth(1) = 1600
		'    Grid1.ColWidth(2) = 1600
		
		
		
	End Sub
	'Private Sub Grid1_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
	'    selectedcell = True
	'     SendKeys "{TAB}"
	'    KeyAscii = 0
	'End Sub
	'
End Class