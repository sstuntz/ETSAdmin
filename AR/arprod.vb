Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmar_prod
	Inherits System.Windows.Forms.Form
	
	'****************
	'revision History
	'original date of this form is 02/19/1998 - SCS
	
	'****************
	'Option Explicit
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
	
	Private Sub Command1_Click() ' copied from delete
		'this may produce an error if you delete the last
		'record or the only record in the recordset
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Delete()
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.MoveNext()
	End Sub
	
	Private Sub Delete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Delete.Click
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Delete()
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.MoveNext()
	End Sub
	
	Private Sub frmar_prod_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		' data1 = ar
		'Msgbox ("fix the path name and erase this box")
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
		Select Case entry_type
			
			Case "ADD"
				'UPGRADE_ISSUE: Data property Data1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Data1.recordsource = "select * from product where prod_num = ''"
				Data1.Refresh()
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Data1.Recordset.AddNew()
				txtFields(7).Text = CStr(Today)
				txtFields(8).Text = CStr(Today)
				
			Case "EDIT"
				'UPGRADE_ISSUE: Data property Data1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Data1.recordsource = "select * from product where prod_num = " & Chr(34) & selected_prod_num & Chr(34)
				Data1.Refresh()
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Data1.Recordset.edit()
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				txtFields(0).Text = Data1.Recordset.Fields(0).Value
				
				'added 3/16/00 lhw
				If selected_prod_num = "99" Then
					Label4.Visible = True
					txtFields(5).Visible = True
				End If
				
				txtFields(0).Enabled = False
		End Select
		
	End Sub
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
		Dim Index As Short = txtFields.GetIndex(eventSender)
		Call ets_set_selected()
	End Sub
	
	Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtfields.GetIndex(eventSender)
		Dim tempdb As dao.Database
		'UPGRADE_WARNING: Arrays in structure tempset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim tempset As dao.Recordset
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			Select Case Index
				
				Case 0
					
					db = ar_data_path & "ar.mdb"
					tempdb = DAODBEngine_definst.OpenDatabase(db)
					tempset = tempdb.OpenRecordset("product", dao.RecordsetTypeEnum.dbOpenDynaset)
					
					sqlstmnt = " prod_num = " & Chr(34) & txtFields(0).Text & Chr(34)
					tempset.FindFirst(sqlstmnt)
					
					
					If tempset.NoMatch Then
						txtFields(0).Focus()
					Else
						MsgBox("Product number has been used, re-enter another.")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
					
					If txtFields(0).Text = "99" Then
						Label4.Visible = True
						txtFields(5).Visible = True
						txtFields(1).Text = "Sales Tax"
						txtFields(2).Text = CStr(0.05)
					End If
					
					
					
				Case 2, 4 'format the dollar fields
					
					If Len(txtFields(Index).Text) = 0 Then
						txtFields(Index).Text = CStr(0)
						GoTo EventExitSub
					End If
					
					txtFields(Index).Text = VB6.Format(txtFields(Index).Text, "###0.00000;-###0.000000")
					
					
				Case 5 'gl acct number lookup
					
					valid_acct = " N "
					function_type_saved = function_type
					function_type = "LOOKUP_ONLY"
					
					Call etsacctnum_chk(txtFields(Index), retacct, retacctdesc, valid_acct)
					
					If valid_acct = "N" Then
						MsgBox("Not a valid account number.")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
					txtFields(Index).Text = retacct
					function_type = function_type_saved
					
				Case 7, 8 'Dates
					
					
					valid_Date = "N"
					senddate = txtFields(Index).Text
					Call etsdate(senddate, retdate, valid_Date)
					
					If valid_Date <> "N" Then
						txtFields(Index).Text = retdate
						txtFields(Index).Text = CStr(CDate(txtFields(Index).Text))
						
						
					Else
						MsgBox(" Bad Date")
						Call ets_set_selected()
						GoTo EventExitSub
						
					End If
					
			End Select
			
done3: 
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