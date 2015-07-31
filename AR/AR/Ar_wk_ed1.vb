Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class arwk_bill_Ed1
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 6/23/97 -SCS
	'revised 12/27/2007 LHW
	'****************
	
	Public sending As String
	Public fnum As Short
	Public fnum1 As Short
	Public filename As String
	Public filename1 As String
	Public rowvalue, colvalue As Object
	Public Sub rebuild_grid()
		
		'  For num = Grid1.Rows - 1 To 1 Step -1
		'    Grid1.RemoveItem num
		'    Next
		'
		'    'put headings here where xxx is replaced with a field name
		'
		'    Grid1.AddItem "Inv Num" & Chr(9) & "Name Key" & Chr(9) & "Screen Name" & Chr(9) & "Sort Name" & Chr(9) & "Inv Date" & Chr(9) & "Entry_date" & Chr(9) & "Purch Num", 0
		'
		'    Data1.recordsource = "select * from workshop where billed = ""N"" and line_num = 1 and void = ""N"" and glpost = ""N"" order by inv_num "
		'    Data1.Refresh
		'
		'        num = 1
		'     '   Data1.Recordset.MoveFirst
		'        Do While Not Data1.Recordset.EOF
		'        'put in the data for the grid
		'        Grid1.AddItem Data1.Recordset.Fields("inv_num") & Chr(9) & Data1.Recordset.Fields("name_key") & Chr(9) & Data1.Recordset.Fields("screen_nam") & Chr(9) & Data1.Recordset.Fields("sort_name") & Chr(9) & Data1.Recordset.Fields("inv_date") & Chr(9) & Data1.Recordset.Fields("entry_date") & Chr(9) & Data1.Recordset.Fields("purch_num"), num
		'
		'        Data1.Recordset.MoveNext
		'        num = num + 1
		'        Loop
		'        Grid1.RemoveItem num
		'        selectedcell = False
		'
		'        'fix sizes and number of columns
		'
		'        Grid1.ColWidth(0) = 1200
		'        Grid1.ColWidth(1) = 1200
		'        Grid1.ColWidth(2) = 1500
		'        Grid1.ColWidth(3) = 1500
		'        Grid1.ColWidth(4) = 1000
		'        Grid1.ColWidth(5) = 1000
		'        Grid1.ColWidth(6) = 1000
		'
		'        Grid1.TopRow = temp_row
		'        Grid1.Row = actual_row
		
	End Sub
	
	Private Sub add_bill_Click()
		entry_type = "ADD"
		ar_wk_bill.Show()
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
		'Screen.MousePointer = vbDefault
		' On Error Resume Next
		'This will display the current record position
		'for dynasets and snapshots
		' Data1.Caption = "Record: " & (Data1.Recordset.AbsolutePosition + 1)
		'for the table object you must set the index property when
		'the recordset gets created and use the following line
		'Data1.Caption = "Record: " & (Data1.Recordset.RecordCount * (Data1.Recordset.PercentPosition * 0.01)) + 1
	End Sub
	
	'UPGRADE_ISSUE: Data event Data1.Validate was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub Data1_Validate(ByRef Action As Short, ByRef Save As Short)
		'This is where you put validation code
		'This event gets called when the following actions occur
		' Select Case Action
		'   Case vbDataActionMoveFirst
		'   Case vbDataActionMovePrevious
		'   Case vbDataActionMoveNext
		'   Case vbDataActionMoveLast
		'   Case vbDataActionAddNew
		'   Case vbDataActionUpdate
		'   Case vbDataActionDelete
		'   Case vbDataActionFind
		'   Case vbDataActionBookmark
		'   Case vbDataActionClose
		' End Select
		' Screen.MousePointer = vbHourglass
	End Sub
	
	
	Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Edit.Click
		Dim Grid1 As Object
		
		If selectedcell = False Then
			MsgBox("Nothing selected")
			Exit Sub
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object Grid1.TopRow. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		temp_row = Grid1.TopRow
		'UPGRADE_WARNING: Couldn't resolve default property of object Grid1.Row. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		actual_row = Grid1.Row
		
		'  'move the grid data to the transfer variables
		'    Grid1.Col = 0
		'    selected_lookup_num = Grid1.Text
		'    selected_voucher = Grid1.Text
		'    Grid1.Col = 2
		'    selected_lookup_type = Grid1.Text
		'    'Grid1.Col = 3
		'    'selected_lookup_num = Grid1.Text
		'
		'     entry_type = "EDIT"
		'
		'    'goto the form that will fill in the data
		'    ar_wk_bill.Show '1      '01/02/08 modal fix
		'    'use modal to stop here
		'
		'    Data1.Refresh 'after an edit or add rebuilds the file
		'
		'    Call rebuild_grid
		'
		'    Grid1.TopRow = temp_row
		'    Grid1.SelStartRow = actual_row
		'    Grid1.SelEndRow = actual_row
		
		
	End Sub
	
	Private Sub arwk_bill_Ed1_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		' since keypreview of the form is set to true
		'this means that anytime that the enter key is set is sends a tab
		
		If KeyCode = 13 Then System.Windows.Forms.SendKeys.Send("{TAB}")
	End Sub
	
	Private Sub arwk_bill_Ed1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'this eliminates the annoying beep
		If KeyAscii = 13 Then KeyAscii = 0
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub arwk_bill_Ed1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		' data1 =ar
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
		
		
		
		Data1.Refresh()
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		If Data1.Recordset.RecordCount = 0 Then
			MsgBox("No Commercial bills to Edit. Will go directly to ADD.")
			entry_type = "ADD"
			ar_wk_bill.Show()
			Exit Sub
		End If
		
		Call rebuild_grid()
		
	End Sub
	
	
	
	'
	'Private Sub Grid1_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
	'selectedcell = True
	'SendKeys "{tab}"
	'KeyAscii = 0
	'
	'End Sub
End Class