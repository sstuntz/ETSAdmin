Option Strict Off
Option Explicit On
Friend Class frmnamee1
	Inherits System.Windows.Forms.Form
	
	'****************
	'revision History
	'original date of this form is 9/23/96 -SCS
	'revised 9/5/07 lhw SS# revision removed masked ed box1
	
	'****************
	
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		
		entry_type = "CANCEL"
		Me.Close()
	End Sub
	
	
	
	
	Private Sub frmnamee1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		
		
		If txtfields(10).Text = "na" Or Len(txtfields(10).Text) = 0 Then
			txtfields(10).Text = "na"
			sup_name.Text = "None"
			GoTo done1a
		End If
		
		valid_name = "N"
		'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		selected_name_key = ""
		selected_screen_nam = ""
		Call chkname(txtfields(10))
		
		sup_name.Text = selected_screen_nam
		
done1a: 
		If entry_type <> "ADD" Then
			If txtfields(11).Text = "na" Or Len(txtfields(11).Text) = 0 Then
				txtfields(11).Text = "na"
				txtfields(12).Text = "None"
				GoTo done2a
			End If
			
			rettitledesc = ""
			valid_title = "N"
			Call ets_title_chk(txtfields(11), rettitle, rettitledesc, valid_title)
			
			txtfields(12).Text = rettitledesc
		End If
		
done2a: 
		
		
	End Sub
	
	Private Sub program_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles program.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		If KeyAscii = 13 Then
			txtfields(8).Text = program.Text
			
			System.Windows.Forms.SendKeys.Send("{TAB}")
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub Save_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Save.Click
		'On Error Resume Next
		
		valid_slot = "N"
		retslot = ""
		retloc = ""
		Call etsslotnum_chk(txtfields(7), retslot, retloc, valid_slot)
		If valid_slot = "N" Then
			MsgBox("Invalid Slot number")
			Call ets_set_selected()
			txtfields(7).Focus()
			Exit Sub
		End If
		
		valid_loc = "N"
		sendslot = txtfields(7).Text
		sendloc = txtfields(8).Text
		retloc = ""
		retlocdesc = ""
		
		Call etslocnum_chk(sendslot, sendloc, retloc, retlocdesc, valid_loc)
		If valid_loc = "N" Then
			MsgBox("Not a valid location number.")
			
			Call ets_set_selected()
			program.Focus()
			Exit Sub
		End If
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		On Error Resume Next
		
		'Data1.UpdateRecord
		If Err.Number = 524 Then
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			MsgBox("Incomplete Data - Please check your form.")
			Exit Sub
		End If
		On Error GoTo 0
		
		
		'this finds and sets the agency pay freq code
		freq_code = pay_code_freq.Text
		
		'this adds the nfo to the eeslot table for validation for data entry
		'need to control for adds versus edits-look for it and if not there add it
		'datacontrol is ee_slot
		'ee_slot.Refresh
		'ee_slot.Recordset.MoveFirst
		
		'Do While Not ee_slot.Recordset.EOF
		' If ee_slot.Recordset("name_key") <> txtfields(0) Or ee_slot.Recordset("slot_num") <> txtfields(7) Or ee_slot.Recordset("loc_num") <> txtfields(8) Then
		' ee_slot.Recordset.MoveNext
		' Else
		'GoTo done2
		'End If
		
		'Loop
		
		'Response = MsgBox("This is a new slot location combination. Do you wish to add this combination for THIS EMPLOYEE to the ee slot table?", 4)
		'If Response = vbYes Then
		'ee_slot.Recordset.AddNew
		'ee_slot.Recordset("name_key") = txtfields(0)
		'ee_slot.Recordset("slot_num") = txtfields(7)
		'ee_slot.Recordset("loc_num") = txtfields(8)
		'ee_slot.Recordset("sort_name") = selected_sort_name
		'ee_slot.Recordset.Update
		'Else
		'txtfields(7).SetFocus
		'Call ets_set_selected
		'Exit Sub
		'End If
		'done2:
		
		'this enters the default agency dfq into all the fields
		'
		' If entry_type_ee = "ADD" Then
		'        Data1.Recordset.edit
		'        Data1.Recordset("pay_freq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("fica_exmt") = "N"
		'        Data1.Recordset("med_exmt") = "N"
		'        Data1.Recordset("aeic_elig") = "N"
		'        Data1.Recordset("addfwt_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("addswt_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("a_nt_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("b_nt_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("c_nt_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("d_nt_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("e_nt_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("flx_nt_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("dep_nt_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("pen1a_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("pen1b_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("pen2a_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("pen2b_dfq") = Data3.Recordset("pay_freq")
		'        'Data1.Recordset("pen3a_dfq") = data3.Recordset("pay_freq")
		'        'Data1.Recordset("pen3b_dfq") = data3.Recordset("pay_freq")
		'        Data1.Recordset("save1_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("save2_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("save3_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("dduct1_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("dduct2_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("dduct3_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("dduct4_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("dduct5_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("dduct6_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("dduct7_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("dduct8_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("dduct9_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("misc1_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("misc2_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset("ddep_dfq") = Data3.Recordset("pay_freq")
		'        Data1.Recordset.Update
		'     End If
		
		Me.Close()
		
		'frmnamee2.Show 1
		
	End Sub
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
		Dim Index As Short = txtFields.GetIndex(eventSender)
		'need default code here
		Call ets_set_selected()
		Select Case Index
			Case 3
				txtfields(1).Text = selected_screen_nam_ee
				txtfields(0).Text = selected_name_key_ee
				
			Case 6
				If Len(selected_dpt_num) <> 0 Then
					txtfields(6).Text = selected_dpt_num
					'SendKeys "{TAB}"
					'   KeyAscii = 0
				End If
			Case 8
				
				If Len(selected_loc_num) <> 0 Then
					txtfields(8).Text = selected_loc_num
					program.Visible = False
					txtfields(8).Visible = True
				Else
					txtfields(8).Visible = False
					program.Visible = True
				End If
				
			Case 15 'added lhw SS#
				'this code on old ss box
				program.Items.Add(txtfields(8).Text)
				program.SelectedIndex = 0
				
				
				txtfields(1).Text = selected_screen_nam_ee
				txtfields(0).Text = selected_name_key_ee
				
		End Select
		
	End Sub
	
	Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtFields.GetIndex(eventSender)
		
		If KeyAscii = 13 Then
			
			Select Case Index
				Case 1
				Case 2
					Call ets_format(txtfields(Index), retstring, "2", "N")
					If valid_YN = "N" Then
						MsgBox("invalid phone number")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					txtfields(Index).Text = retstring
					retstring = ""
					
				Case 3, 4
					If Len(txtfields(Index).Text) = 0 Then
						'UPGRADE_ISSUE: TextBox property txtfields.DataChanged was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
						txtfields(Index).DataChanged = False
						System.Windows.Forms.SendKeys.Send("{tab}")
						KeyAscii = 0
						GoTo EventExitSub
					End If
					
					valid_Date = "N"
					Call etsdate(txtfields(Index), retdate, valid_Date)
					If valid_Date = "Y" Then
						txtfields(Index).Text = CStr(CDate(retdate))
						
						If Index = 3 Then 'forces anniv month to be the month of hire date
							txtfields(5).Text = CStr(Month(CDate(txtfields(Index).Text)))
						End If
						
						'added 3/3/06 to delete records in recurring if ee is terminated
						If Index = 4 Then
							
							tmpdb = DAODBEngine_definst.OpenDatabase(ee_data_path & "ee.mdb")
							tmpset = tmpdb.OpenRecordset("eework1_rec")
							sqlstmnt = " select * from eework1_rec where name_key = " & Chr(34) & selected_name_key_ee & Chr(34)
							tmpset = tmpdb.OpenRecordset(sqlstmnt, DAO.RecordsetTypeEnum.dbOpenDynaset)
							
							If tmpset.NoMatch Then
								GoTo EventExitSub
								
							Else
								If Err.Number <> 3021 Then
									Do While Not tmpset.EOF
										tmpset.Delete()
										MsgBox("Person deleted from Recurring Cards also")
										tmpset.MoveNext()
									Loop 
								End If
							End If
						End If
						
						System.Windows.Forms.SendKeys.Send(("{tab}"))
						KeyAscii = 0
						GoTo EventExitSub
					End If
					MsgBox("Not a Valid Date")
					Call ets_set_selected()
					GoTo EventExitSub
					
					
					
					
					
					
				Case 5
					If Val(txtfields(Index).Text) > 12 Or Val(txtfields(Index).Text) < 1 Then
						MsgBox("Invalid Month Number")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
				Case 6
					If txtfields(Index).Text = "na" Then
						txtfields(Index).Text = "00"
						GoTo done1
					End If
					
					valid_dpt = "N"
					senddpt = txtfields(6).Text
					retdpt = ""
					retdptdesc = ""
					selected_dpt_num = ""
					
					Call etsdptnum_chk(senddpt, retdpt, retdptdesc, valid_dpt)
					
					If valid_dpt = "N" Then
						MsgBox("Not a valid department number.")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					txtfields(6).Text = retdpt
					
				Case 7
					'this checks the slot number in data2 control
					'and paints the default program number in the next field
					
					valid_slot = "N"
					retslot = ""
					retloc = ""
					Call etsslotnum_chk(txtfields(7), retslot, retloc, valid_slot)
					If valid_slot = "N" Then
						MsgBox("Invalid Slot number")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
					txtfields(7).Text = retslot
					
					If Len(retloc) <> 0 Then
						txtfields(8).Text = retloc
						program.Items.Clear()
						program.Items.Add(txtfields(8).Text)
						program.SelectedIndex = 0
					Else
						On Error Resume Next
						'Data2.RecordSource = "select * from eeslot1 where slot_num = " & Chr$(34) & txtfields(7) & Chr$(34)
						'Data2.Refresh
						If CDbl(ErrorToString()) = 3021 Then ' this i
							
							
						End If
						
						
						'Data2.Refresh
						program.Items.Clear() 'blank the combo box first
						'fill a combo box for next field
						
						' Data2.Recordset.MoveFirst
						' Do While Not Data2.Recordset.EOF
						' program.AddItem Data2.Recordset.Fields("loc_num")
						' Data2.Recordset.MoveNext
						'Loop
					End If
					
				Case 8
					valid_loc = "N"
					sendloc = txtfields(8).Text
					retloc = ""
					retlocdesc = ""
					
					Call etslocnum_chk(sendslot, sendloc, retloc, retlocdesc, valid_loc)
					
					If valid_loc = "N" Then
						MsgBox("Not a valid program number.")
						
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					txtfields(8).Text = retloc
					txtfields(9).Focus()
					GoTo EventExitSub
					'this is the program number
				Case 9
					
				Case 10
					'this checks the supervisor number form name/address
					'and fills in the name below
					'na is a valid name
					If txtfields(10).Text = "na" Then
						sup_name.Text = "None"
						GoTo done1
					End If
					
					valid_name = "N"
					'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					selected_name_key = ""
					selected_screen_nam = ""
					Call chkname(txtfields(10))
					
					If valid_name = "N" Then
						function_type_saved = function_type
						function_type = "LOOKUP_ONLY"
						
						Call namelookup()
						
						'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						txtfields(10).Text = selected_name_key
						sup_name.Text = selected_screen_nam
						function_type = function_type_saved
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						txtfields(10).Text = selected_name_key
						sup_name.Text = selected_screen_nam
					End If
					
				Case 11
					'this checks the job title name and number
					
					If txtfields(11).Text = "na" Then
						txtfields(12).Text = "None"
						GoTo done1
					End If
					
					valid_title = "N"
					Call ets_title_chk(txtfields(11), rettitle, rettitledesc, valid_title)
					
					If valid_title = "N" Then
						MsgBox("Invalid title number.")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
					txtfields(11).Text = rettitle
					txtfields(12).Text = rettitledesc
					
				Case 12
				Case 13
				Case 14
					
				Case 15 'added 09/05/2007 lhw
					Call ets_format(txtfields(Index), retstring, "1", "N") 'ss# in mod
					If valid_YN = "N" Then
						MsgBox("invalid SS# number")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					txtfields(Index).Text = retstring
					retstring = ""
					
					
					'UPGRADE_ISSUE: TextBox property txtfields.DataChanged was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					If txtfields(15).DataChanged = True Then
						valid_lookup = "N"
						Call check_dup_soc_sec_num(txtfields(15).Text, valid_lookup)
						If valid_lookup = "N" Then
							MsgBox("This is a duplicate social security number.  Please check it or leave blank.")
							GoTo EventExitSub
						End If
					End If
					
				Case Else
					MsgBox("Not a valid entry.")
					GoTo EventExitSub
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
		txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
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
			
			'    If entry_type = "ADD" Or vac_Elig.DataChanged = True Then
			'    If vac_Elig = "Y" Then
			'        On Error Resume Next
			'        'this checks to add a vacation table entry and to ask if you want to edit it
			'        Data4.Recordset.AddNew
			'        Data4.Recordset("name_key") = selected_name_key_ee
			'        Data4.Recordset("screen_nam") = selected_screen_nam_ee
			'        Data4.Recordset.Update
			'        'If err = 3022 Then
			'        'On Error GoTo 0
			'        Response = MsgBox("Do you wish to edit the vacation table now?", 4)
			'        If Response = vbYes Then
			'        frmeevac.Show 1
			'        End If
			'        'End If
			'    End If
			'    End If
			
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
		'added 7/5/03 lhw
		If vac_Elig.Text = "Y" Then
			'frmeevac.Show 1
		Else
			MsgBox("This person not set up for vacation.")
			Call ets_set_selected()
			Exit Sub
		End If
		
		
	End Sub
End Class