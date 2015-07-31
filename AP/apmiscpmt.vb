Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmmiscpmt
	Inherits System.Windows.Forms.Form
	
	'****************
	'revision History
	'original date of this form is 03/10/1998 - SCS
	
	'****************
	'Option Explicit
	Private Sub cmdRefresh_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRefresh.Click
		'this is really only needed for multi user apps
		Data1.Refresh()
	End Sub
	
	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
		'the following code checks for completeness
		'the string field has a list of the field numbers to check
		'first field is 0
		For num = 0 To 100
			msg = "," & CStr(num) & ","
			Response = InStr(",8,9,11,14,15,", msg)
			If Response <> 0 Then
				If Len(txtfields(num).Text) = 0 Then
					MsgBox("You must fill in all required fields.")
					txtfields(num).Focus()
					Exit Sub
				End If
			End If
		Next 
		
		'Data1.Recordset.Bookmark = Data1.Recordset.LastModified
		'UPGRADE_ISSUE: Data method Data1.UpdateRecord was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.UpdateRecord()
		Me.Close()
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub Command1_Click()
		prtDestination = CStr(0)
		prtreportfilename = ap_report_path & "apmsck.rpt"
		' Call frmcrystal_Call
		
	End Sub
	
	Private Sub Command2_Click()
		' Unload.me
		'need to do some error checking for correct data
		apmcheck.ShowDialog()
		
	End Sub
	Private Sub Command3_Click()
		'add records to payment
		'want to replace screen name in voucher with screen name here
		
	End Sub
	
	'UPGRADE_ISSUE: Data event Data1.Error was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub Data1_Error(ByRef DataErr As Short, ByRef Response As Short)
		'This is where you would put error handling code
		'If you want to ignore errors, comment out the next line
		'If you want to trap them, add code here to handle them
		MsgBox("Data error event hit err:" & ErrorToString(DataErr))
		Response = 0 'throw away the error
	End Sub
	
	Private Sub frmmiscpmt_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		' data1 =  ap
		'Msgbox ("fix the path name and erase this box")
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
		Select Case entry_type ' this is here to blank a new record or fill in data
			
			Case "ADD"
				'UPGRADE_ISSUE: Data property Data1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Data1.recordsource = "select * from miscpmt"
				Data1.Refresh()
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Data1.Recordset.AddNew()
				
				txtfields(9).Text = VB6.Format(Now, "medium date")
				
				
				
			Case "EDIT"
				'UPGRADE_ISSUE: Data property Data1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Data1.recordsource = "select * from miscpmt where name_key = " & Chr(34) & selected_name_key & Chr(34)
				Data1.Refresh()
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Data1.Recordset.edit()
				txtfields(0).Enabled = False ' can't edit key
				
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				txtfields(11).Text = Data1.Recordset.Fields("bank_key").Value & ""
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				txtfields(8).Text = Data1.Recordset.Fields("bank_name").Value & ""
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				txtfields(13).Text = Data1.Recordset.Fields("cr_acct_nu").Value & ""
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				txtfields(14).Text = Data1.Recordset.Fields("dr_acct_nu").Value & ""
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				txtfields(21).Text = Data1.Recordset.Fields("memo1").Value & ""
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				txtfields(22).Text = Data1.Recordset.Fields("memo2").Value & ""
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				txtfields(9).Text = Data1.Recordset.Fields("dt_paid").Value & ""
				txtfields(17).Text = VB6.Format(txtfields(17).Text, "FIXED")
				txtfields(18).Text = VB6.Format(txtfields(18).Text, "FIXED")
				txtfields(16).Text = VB6.Format(txtfields(16).Text, "FIXED")
				txtfields(19).Text = VB6.Format(txtfields(19).Text, "FIXED")
				
				
		End Select
		
	End Sub
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
		Dim Index As Short = txtFields.GetIndex(eventSender)
		Call ets_set_selected()
	End Sub
	
	Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtfields.GetIndex(eventSender)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			'if voucher# entered then skip all other dol fields and put vouch amt
			'in the dol_total field
			Select Case Index
				
				Case 0
					valid_name = "N"
					'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selected_name_key = ""
					function_type_saved = function_type
					function_type = "LOOKUP_ONLY"
					cmdUpdate.Enabled = True
					
					If Index = 0 Then
						saved_package_Type = package_Type
						package_Type = "TY"
					End If
					
					If Val(txtfields(Index).Text) = 0 Then
						Call namelookup()
						'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						txtfields(Index).Text = selected_name_key
					End If
					
					Call chkname(txtfields(Index))
					
					If valid_name = "N" Then
						MsgBox(" Invalid Number")
						Call ets_set_selected()
						cmdUpdate.Enabled = False
						package_Type = saved_package_Type
						GoTo EventExitSub
					End If
					
					'the following code is used to get additional data from nam_Addr
					'that is pushed onto the form ie screen name
					'field must be next in order in table
					
					
					db = gl_data_path & "glname.mdb" 'lookup to glname
					tmpdb = DAODBEngine_definst.OpenDatabase(db)
					tmpset = tmpdb.OpenRecordset("nam_addr", dao.RecordsetTypeEnum.dbOpenDynaset)
					
					sqlstmnt = " name_key = "
					sqlstmnt = sqlstmnt & Chr(34) & txtfields(Index).Text & Chr(34)
					tmpset.FindFirst(sqlstmnt) 'the & "" fixes the null field err msg
					
					txtfields(Index + 1).Text = tmpset.Fields("screen_nam").Value
					txtfields(Index + 2).Text = tmpset.Fields("address1").Value & ""
					txtfields(Index + 3).Text = tmpset.Fields("address2").Value & ""
					txtfields(Index + 4).Text = tmpset.Fields("city").Value & ""
					txtfields(Index + 5).Text = tmpset.Fields("state").Value & ""
					txtfields(Index + 6).Text = tmpset.Fields("zip4").Value & ""
					txtfields(7).Text = tmpset.Fields("sort_name").Value & ""
					function_type = function_type_saved
					package_Type = saved_package_Type
					
				Case 9 'check date
					
					valid_Date = "N"
					senddate = txtfields(Index).Text
					Call etsdate(senddate, retdate, valid_Date)
					
					If valid_Date <> "N" Then
						txtfields(Index).Text = retdate
						txtfields(Index).Text = CStr(CDate(txtfields(Index).Text))
						
					Else
						MsgBox(" Bad Date")
						Call ets_set_selected()
						GoTo EventExitSub
						
					End If
					
				Case 10 'chk_num  no d/e after 7/13/00 lhw
					
					valid_check = "N"
					Call chknumverify(Val(txtfields(Index).Text))
					If valid_check = "N" Then
						MsgBox("This check number has been used - Please Re-enter")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
					db = ap_data_path & "ap.mdb"
					tmpdb = DAODBEngine_definst.OpenDatabase(db)
					tmpset = tmpdb.OpenRecordset("payment", dao.RecordsetTypeEnum.dbOpenDynaset)
					
					On Error Resume Next '2000
					sqlstmnt = " chk_num = " & Val(txtfields(10).Text)
					tmpset.FindFirst(sqlstmnt)
					
					If tmpset.Fields("chk_num").Value = Val(txtfields(10).Text) Then
						MsgBox("The voucher entered has already been paid.")
					Else : Err.Clear()
					End If
					
				Case 11 'bank key
					
					
					valid_name = "N"
					'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selected_name_key = ""
					function_type_saved = function_type
					function_type = "LOOKUP_ONLY"
					
					If Index = 11 Then
						saved_package_Type = package_Type
						package_Type = "GL"
					End If
					
					If Len(txtfields(Index).Text) = 0 Then
						Call namelookup()
						'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						txtfields(Index).Text = selected_name_key
					End If
					
					Call chkname(txtfields(Index))
					
					If valid_name = "N" Then
						txtfields(8).Text = ""
						MsgBox(" Invalid Bank Number")
						Call ets_set_selected()
						package_Type = saved_package_Type
						GoTo EventExitSub
					End If
					
					'the following code is used to get additional data from nam_Addr
					'that is pushed onto the form ie screen name
					'field must be next in order in table
					
					
					db = gl_data_path & "glname.mdb" 'lookup to glname
					tmpdb = DAODBEngine_definst.OpenDatabase(db)
					tmpset = tmpdb.OpenRecordset("nam_addr", dao.RecordsetTypeEnum.dbOpenDynaset)
					
					sqlstmnt = " name_key = " 'text field need chr(34)
					sqlstmnt = sqlstmnt & Chr(34) & txtfields(Index).Text & Chr(34)
					tmpset.FindFirst(sqlstmnt)
					
					txtfields(8).Text = tmpset.Fields("screen_nam").Value
					
					If Index = 11 Then 'look up the account numbers
						Call bank_nameget(txtfields(Index))
						txtfields(13).Text = bank_dr_acct_nu
						txtfields(9).Focus()
						package_Type = saved_package_Type
						GoTo EventExitSub
					End If
					
					function_type = function_type_saved
					package_Type = saved_package_Type
					
				Case 13, 14
					
					valid_acct = " N "
					function_type_saved = function_type
					function_type = "LOOKUP_ONLY"
					
					Call etsacctnum_chk(txtfields(Index), retacct, retacctdesc, valid_acct)
					
					If valid_acct = "N" Then
						MsgBox("Not a valid account number.")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
					txtfields(Index).Text = retacct
					function_type = function_type_saved
					
				Case 15 'calc miles * rate
					If Len(txtfields(Index).Text) > 0 Then
						txtfields(16).Text = CStr(CDbl(txtfields(12).Text) * CDbl(txtfields(15).Text))
						txtfields(16).Text = VB6.Format(txtfields(16).Text, "###0.00")
						txtfields(17).Focus()
						KeyAscii = 0
						GoTo EventExitSub
					End If
					
				Case 17 'dol_other1
					
					If Len(txtfields(Index).Text) >= 0 Then
						txtfields(Index).Text = VB6.Format(txtfields(Index).Text, "###0.00")
						txtfields(22).Focus() ' memo2
						KeyAscii = 0
						GoTo EventExitSub
					End If
					
				Case 18 'dol_other2 use val to convert text to number when adding fields
					
					If Len(txtfields(Index).Text) >= 0 Then
						txtfields(Index).Text = VB6.Format(txtfields(Index).Text, "###0.00")
						txtfields(19).Text = CStr(Val(txtfields(17).Text) + Val(txtfields(18).Text) + Val(txtfields(16).Text))
						txtfields(19).Text = VB6.Format(txtfields(19).Text, "###0.00")
						txtfields(14).Focus() 'acct#
						KeyAscii = 0
						GoTo EventExitSub
						
					End If
					
				Case 19
					
					If Len(txtfields(Index).Text) >= 0 Then
						txtfields(Index).Text = VB6.Format(txtfields(Index).Text, "###0.00")
						cmdUpdate.Focus()
						GoTo EventExitSub
					End If
					
					
					
			End Select ' this is the end of Case
			
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
		txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
End Class