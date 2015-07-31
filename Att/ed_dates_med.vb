Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System
Imports System.Configuration
Imports JRI.MODULE1
Imports System.Data.SqlClient

Friend Class ed_dates_med
	Inherits System.Windows.Forms.Form
	
	Dim day_num(41) As String
	Dim sdr_type(4) As String
	Dim message As String
	Dim title As String
	'UPGRADE_NOTE: default was upgraded to default_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Dim default_Renamed As String
	
	Dim Start_date As Date
	Dim date_Array(41) As Date
	Dim start_position As Short
	Dim date_choose_array(12) As Date
	Dim saved_Choice As Date
	
	
	
	Sub calc_units()
		
		tot_units.Text = " "
		total_units = 0
		
        'For num = 0 To 41
        '	total_units = total_units + Val(adr(num).Text)
        'Next 
		
		tot_units.Text = CStr(total_units)
		
	End Sub
	
	Private Sub adr_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles adr.DoubleClick
        Dim Index As Short = adr.GetIndex(CType(eventSender, TextBox))
		adr(Index).Text = CStr(0)
	End Sub
	
	Private Sub client_pct_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles client_pct.Enter
		Call ets_set_selected()
		dayt(start_position).Focus()
	End Sub
	
	Private Sub client_pct_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles client_pct.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
		If KeyAscii = 9 Or KeyAscii = 13 Then
            'client_pct.Text = VB6.Format(client_pct.Text, "FIXED")
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub client_pct_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles client_pct.Leave
		client_pct.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub dayt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dayt.Click
        Dim Index As Short = dayt.GetIndex(CType(eventSender, Button))
		'first check to make sure something already in
		If Val(adr(Index).Text) = 0 Then
			sdr(Index).Focus()
			Exit Sub
		End If
		
		
		saved_date = CDate(Month(CDate(text1.Text)) & "/" & Val(dayt(Index).Text) & "/" & Year(CDate(text1.Text)))
		
		'   saved_date = date_Array(Val(dayt(Index).Caption))
		'left2 = saved_date 'dayt(Index).Left + ed_dates.Left
		'top2 = dayt(Index).Top + dayt(Index).Height + ed_dates.Top
		att_in_hrs.ShowDialog()
		'check the record to see if one and then add or remove the ******
		If del_flag = "Y" Then
			dayt(Index).Text = day_num(Index) & ""
		Else
			
			dayt(Index).Text = day_num(Index) & "***"
		End If
		del_flag = "N"
		
		att_in_hrs.Close()
		
	End Sub
	Private Sub cmdRefresh_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRefresh.Click
		'this is really only needed for multi user apps
		Data1.Refresh()
	End Sub
	
	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
		
		'check to make sure something has been entered
        'For num = start_position To 41
        '          'If sdr(num).Text <> "" Then
        '          '	GoTo oktoprocess
        '          'End If
        'Next 
		MsgBox("There is no attendance.  Please enter some or use the cancel button.")
		Exit Sub
		
oktoprocess: 
		
		'now check to see if all units have a proc code
        'For num = 0 To 41 'start_position To 41
        '	If Val(adr(num).Text) <> 0 Then
        '		If Len(Trim(sdr(num).Text)) = 0 Then
        '			MsgBox("There is no procedure code for a day with units. Please correct.")
        '			Exit Sub
        '		End If
        '	End If
        'Next 
		
		
neway:
		'need to start on first of month
		'start positon is the first day with data
		'if start at 0 then can have prior month
		
        'For num = 0 To 41 'start_position To 41 begin on first day
        '	If dayt(num).Enabled = True Then
        '		saved_date = CDate(Month(CDate(text1.Text)) & "/" & Val(dayt(num).Text) & "/" & Year(CDate(text1.Text)))
        '		uni_counter = num
        '		'UPGRADE_ISSUE: TextBox property sdr.DataChanged was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        '		If sdr(num).DataChanged = True Then
        '			Call upd_file(saved_date, uni_counter)
        '			num = uni_counter  2/6/01
        '		Else
        '			'UPGRADE_ISSUE: TextBox property adr.DataChanged was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        '			If adr(num).DataChanged = True Then
        '				Call upd_file(saved_date, uni_counter)
        '				num = uni_counter ' 2/6/01
        '			End If
        '		End If
        '	End If
        'Next 
		
		Call donextname()
		
	End Sub
	Sub oldway()
		
        '' store the record to the temp file
        ''we do this by editing the first record and all others are copies
        ''erase the dataset and then rewrite the new one

        ''write out the sdr(index) to the data file

        ''clear the delete file
        'On Error Resume Next
        'tmpdb = DAODBEngine_definst.OpenDatabase(am_data_path & "med.mdb")
        'sqlstmnt = "delete medopn_del.* from medopn_del"

        'tmpQuery = tmpdb.CreateQueryDef("movetodel", sqlstmnt)

        'If Err.Number = 3012 Then
        '	tmpdb.QueryDefs.delete("movetodel")
        '	tmpQuery = tmpdb.CreateQueryDef("movetodel", sqlstmnt)
        'End If

        'tmpQuery.Execute()

        ''move the unedited fields into del for holding for rewrite with changes and deletions
        ''UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'sqlstmnt = "INSERT INTO medopn_del " & Data1.RecordSource

        'On Error Resume Next
        'tmp1set = tmpdb.OpenRecordset("medopn_del", dao.RecordsetTypeEnum.dbOpenDynaset)
        'tmpQuery = tmpdb.CreateQueryDef("movetodel", sqlstmnt)
        ''UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        'If Err.Number = 3012 Then
        '	tmpdb.QueryDefs.delete("movetodel")
        '	tmpQuery = tmpdb.CreateQueryDef("movetodel", sqlstmnt)
        'End If

        'tmpQuery.Execute()
        'tmpdb.QueryDefs.delete("movetodel")

        'Err.Clear()
        'On Error GoTo 0

        'Data1.Refresh()
        ''UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Data1.Recordset.MoveFirst()

        ''UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        ''clear the old records form tmp
        ''UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not Data1.Recordset.EOF
        '	'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.delete. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	Data1.Recordset.delete()
        '	'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	Data1.Recordset.MoveNext()
        'Loop 

        'On Error Resume Next
        ''UPGRADE_ISSUE: Data property medopn_del.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'medopn_del.RecordSource = "select * from medopn_del"
        'medopn_del.Refresh()
        ''UPGRADE_ISSUE: Data property medopn_del.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object medopn_del.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'medopn_del.Recordset.MoveFirst()
        '' Screen.MousePointer = vbHourglass
        'On Error GoTo 0

        'For num = start_position To 41
        '	If Val(adr(num).Text) <> 0 Then
        '		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.AddNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		Data1.Recordset.AddNew()

        '		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		For i = 0 To Data1.Recordset.Fields.Count - 1
        '			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			'UPGRADE_ISSUE: Data property medopn_del.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			Data1.Recordset((i)) = medopn_del.Recordset(i)
        '		Next i
        '		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		Data1.Recordset.Fields("proc_code") = sdr(num).Text
        '		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		Data1.Recordset.Fields("from_date") = date_Array(num)
        '		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		Data1.Recordset.Fields("to_date") = date_Array(num)
        '		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		Data1.Recordset.Fields("att_units") = adr(num).Text


        '		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		Data1.Recordset.Update()
        '	End If
        'Next num
	End Sub
	
	Sub donextname()
		'now to cycle thru the names
		' we will do this to by checking the name key and going to the next one and then ending
		
		'count the number in the array
		
        'For num = 0 To 41
        '	adr(num).Text = ""
        '	sdr(num).Text = ""
        'Next 
		
		If full_flag = "Y" Then
			'here we check for more dates if so process then go to next name
			
			If mult_mth_flag = "Y" Then
                'For num = 0 To 12
                '	If Year(date_choose_array(num)) = 1899 Then Exit For
                '	If date_choose_array(num) = saved_Choice Then
                '		saved_Choice = date_choose_array(num + 1)
                '		ret2 = CStr(saved_Choice)
                '		If Year(saved_Choice) = 1899 Then
                '			GoTo nextname1
                '		End If

                '		Call nextname()
                '		Exit Sub
                '	End If

                'Next 
			End If
			
			
nextname1: 
			'more name keys but they are in sort name order so have to search list for next one
			
            'For num = 0 To 300
            '	If editname(num) = "" Then Exit For 'done with all the posibilities
            '	'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '	If editname(num) = selected_name_key Then
            '		'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '		saved_name_key = selected_name_key 'for rollover to see if need to reset months
            '		'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '		selected_name_key = editname(num + 1)
            '		'  mult_mth_flag = "N"
            '		'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '		If selected_name_key = "" Then Exit For
            '		Call nextname()
            '		Exit Sub
            '	End If

            'Next 
			Me.Close()
			
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			
		Else
			Me.Close()
			
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			
		End If
		
		
	End Sub
	
	Private Sub upd_file(ByRef saved_date As Object, ByRef num1 As Object)
		
		Dim sqlstmnt1 As String
		
		'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sqlstmnt1 = "select * from medopn_tmp where name_key = " & Chr(34) & Trim(selected_name_key) & Chr(34)
		sqlstmnt1 = sqlstmnt1 & " and contract_key = " & Chr(34) & selected_contract_key & Chr(34)
		' sqlstmnt1 = "name_key = " & Chr(34) & Trim(selected_name_key) & Chr(34)
		'UPGRADE_WARNING: Couldn't resolve default property of object saved_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	sqlstmnt1 = sqlstmnt1 & " and from_Date = " & Chr(35) & saved_date & Chr(35) & " order by place_serv, proc_code "
		
        'tmpdb = DAODBEngine_definst.OpenDatabase(am_data_path & "med.mdb")
        'tmpset = tmpdb.OpenRecordset(sqlstmnt1, dao.RecordsetTypeEnum.dbOpenDynaset)

        'Select Case tmpset.RecordCount

        '	Case 0 'nomatch so addnew

        '		If Val(adr(num1).Text) <> 0 Then
        '			tmp1set.MoveFirst() 'this gets the header info
        '			tmpset.AddNew()
        '			For num = 0 To tmpset.Fields.Count - 1
        '				tmpset.Fields(num).Value = tmp1set.Fields(num).Value
        '			Next 
        '			tmpset.Fields("proc_code").Value = sdr(num1).Text
        '			'UPGRADE_WARNING: Couldn't resolve default property of object num1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			tmpset.Fields("from_date").Value = date_Array(num1)
        '			'UPGRADE_WARNING: Couldn't resolve default property of object num1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			tmpset.Fields("to_date").Value = date_Array(num1)
        '			tmpset.Fields("att_units").Value = Val(adr(num1).Text)
        '			'UPGRADE_WARNING: Couldn't resolve default property of object num1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			Call chk_Proc_code(sdr(num1), date_Array(num1))
        '			tmpset.Fields("usual_fee").Value = selected_proc_fee
        '			tmpset.Fields("proc_desc").Value = selected_proc_desc
        '			tmpset.Fields("dol_net_bill").Value = Int(selected_proc_dol_actual * tmpset.Fields("att_units").Value * 100) / 100
        '			tmpset.Fields("dol_billed").Value = Int(selected_proc_fee * tmpset.Fields("att_units").Value * 100) / 100
        '			tmpset.Update()
        '		End If


        '	Case 1 'it must be the right one

        '		If Val(adr(num1).Text) = 0 Then
        '			tmpset.delete()
        '		Else
        '			tmpset.edit()
        '			tmpset.Fields("proc_code").Value = sdr(num1).Text
        '			'UPGRADE_WARNING: Couldn't resolve default property of object num1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			tmpset.Fields("from_date").Value = date_Array(num1)
        '			'UPGRADE_WARNING: Couldn't resolve default property of object num1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			tmpset.Fields("to_date").Value = date_Array(num1)
        '			tmpset.Fields("att_units").Value = adr(num1).Text
        '			'UPGRADE_WARNING: Couldn't resolve default property of object num1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			Call chk_Proc_code(sdr(num1), date_Array(num1))
        '			tmpset.Fields("usual_fee").Value = selected_proc_fee
        '			tmpset.Fields("proc_desc").Value = selected_proc_desc
        '			tmpset.Fields("dol_net_bill").Value = Int(selected_proc_dol_actual * tmpset.Fields("att_units").Value * 100) / 100
        '			tmpset.Fields("dol_billed").Value = Int(selected_proc_fee * tmpset.Fields("att_units").Value * 100) / 100
        '			tmpset.Update()


        '		End If

        '	Case 2 'just do the first one - the other is done on the box

        '		If Val(adr(num1).Text) = 0 Then
        '			tmpset.delete()
        '		Else
        '			tmpset.edit()
        '			tmpset.Fields("proc_code").Value = sdr(num1).Text
        '			'UPGRADE_WARNING: Couldn't resolve default property of object num1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			tmpset.Fields("from_date").Value = date_Array(num1)
        '			'UPGRADE_WARNING: Couldn't resolve default property of object num1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			tmpset.Fields("to_date").Value = date_Array(num1)
        '			tmpset.Fields("att_units").Value = adr(num1).Text
        '			'UPGRADE_WARNING: Couldn't resolve default property of object num1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			Call chk_Proc_code(sdr(num1), date_Array(num1))
        '			tmpset.Fields("usual_fee").Value = selected_proc_fee
        '			tmpset.Fields("proc_desc").Value = selected_proc_desc
        '			tmpset.Fields("dol_net_bill").Value = Int(selected_proc_dol_actual * tmpset.Fields("att_units").Value * 100) / 100
        '			tmpset.Fields("dol_billed").Value = Int(selected_proc_fee * tmpset.Fields("att_units").Value * 100) / 100
        '			tmpset.Update()


        '		End If

        '	Case Else 'this is a screw up

        '		MsgBox("There are too many procedure codes for this day.  Call ETS for help or delete all records for this person.")

        'End Select
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub dayt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dayt.Enter
        Dim Index As Short = dayt.GetIndex(CType(eventSender, Button))
		If Index = start_position Then
			'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtFields(0).Text = selected_name_key
			
		End If
	End Sub
	
	Private Sub del_attend_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles del_attend.Click
		
		
        '	tmpdb = DAODBEngine_definst.OpenDatabase(am_data_path & "med.mdb")
		
		
		'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sqlstmnt = "select * from medopn_tmp where name_key = " & Chr(34) & Trim(selected_name_key) & Chr(34)
		sqlstmnt = sqlstmnt & " and contract_key = " & Chr(34) & selected_contract_key & Chr(34)
		sqlstmnt = sqlstmnt & " and from_Date between " & Chr(35) & selected_start_date & Chr(35) & " and " & Chr(35) & selected_end_date & Chr(35) & " order by from_Date, place_serv "
        '	tmp1set = tmpdb.OpenRecordset(sqlstmnt)
		
        'Do While Not tmp1set.EOF
        '	tmp1set.delete()
        '	tmp1set.MoveNext()
        'Loop 
		
		'UPGRADE_NOTE: Object tmp1set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        '	tmp1set = Nothing
		
		
		Call donextname()
		
	End Sub
	
	Private Sub ed_dates_med_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
	
		ctrform(Me)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		selected_name_key = editname(0)
		saved_name_key = " "
		mult_mth_flag = "N"
		ret2 = "01/01/1899"
		saved_Choice = CDate("01/01/1899")
		
		Me.Text = Me.Text & "   " & agency_name
		tot_units.Enabled = False
		del_Attend.TabStop = False
		cmdUpdate.TabStop = True
		
		
		Call nextname()
		
	End Sub
	
	Public Sub nextname()
		'clear the screen
		
		
        'For num = 0 To 41
        '	dayt(num).Text = ""
        'Next 

        'For num = 35 To 41
        '	dayt(num).Visible = True
        '	sdr(num).Visible = True
        '	adr(num).Visible = True
        'Next 
		
		
		
        'If function_type = "HISTORY" Then
        '	cmdUpdate.Enabled = False
        '	'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	Data1.RecordSource = "select * from medopn_hist where name_key = " & Chr(34) & Trim(selected_name_key) & Chr(34) & " and void = 'N' "
        '	'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Data1.RecordSource = Data1.RecordSource & " and ((medopn_hist.from_date) between " & Chr(35) & selected_Date_Range_Start & Chr(35)
        '	'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Data1.RecordSource = Data1.RecordSource & " and " & Chr(35) & selected_Date_Range_End & Chr(35) & ") order by from_Date, place_Serv, proc_code "
        'Else
        '	'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	Data1.RecordSource = "select * from medopn_tmp where name_key = " & Chr(34) & Trim(selected_name_key) & Chr(34) & " and void = 'N' "
        '	'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Data1.RecordSource = Data1.RecordSource & " and ((medopn_tmp.from_date) between " & Chr(35) & selected_Date_Range_Start & Chr(35)
        '	'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Data1.RecordSource = Data1.RecordSource & " and " & Chr(35) & selected_Date_Range_End & Chr(35) & ") order by from_Date, place_Serv, proc_code "
        'End If

        'Data1.Refresh()

        ''UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If Data1.Recordset.RecordCount = 0 Then
        '	MsgBox("No records to edit")
        '	Me.Close()
        '	Exit Sub
        'End If

        ''UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Data1.Recordset.MoveFirst()
        ''UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'selected_start_date = Data1.Recordset.Fields("from_Date")
        ''UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.MoveLast. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Data1.Recordset.MoveLast()
        ''UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'selected_end_date = Data1.Recordset.Fields("from_Date")
        ''If mult_mth_flag = "Y" Then ret2 = "01/01/01"
        'responseyear = Year(selected_end_date)
        ''UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'temp_proc_num = Data1.Recordset.Fields("proc_num")
        ''now create the date choice array for this name key

        'num = 0
        '' mult_mth_flag = "N"

        ''UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If selected_name_key <> saved_name_key Then
        '	mult_mth_flag = "N"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	saved_name_key = selected_name_key 'months have been reset
        '	'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	Data1.Recordset.MoveFirst()
        '	date_choose_array(0) = CDate(Month(selected_start_date) & "/1/" & Year(selected_start_date))
        '	saved_Choice = date_choose_array(0)
        '	'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	Do While Not Data1.Recordset.EOF
        '		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		If Month(date_choose_array(num)) * Year(date_choose_array(num)) <> Month(Data1.Recordset.Fields("from_Date")) * Year(Data1.Recordset.Fields("from_Date")) Then
        '			num = num + 1
        '			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			date_choose_array(num) = CDate(Month(Data1.Recordset.Fields("from_Date")) & "/1/" & Year(Data1.Recordset.Fields("from_Date")))
        '			'          saved_Choice = date_choose_array(num)
        '		End If
        '		' Debug.Print Data1.Recordset.Fields("proc_code"), Data1.Recordset.Fields("place_serv"), Data1.Recordset.Fields("sort_name")

        '		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		Data1.Recordset.MoveNext()
        '	Loop 
        'End If


        'If num > 0 Then
        '	mult_mth_flag = "Y"
        '	'now to deal with multiple months
        '	'either it was selected or it is the next in sequence


        '	Select Case full_flag
        '		Case "Y"
        '			If saved_Choice = date_choose_array(0) Then
        '				ret2 = CStr(saved_Choice)
        '			Else
        '				saved_Choice = CDate(ret2)
        '			End If

        '		Case "N"
        '			att_date_choose.ShowDialog()
        '		Case Else
        '			att_date_choose.ShowDialog()
        '	End Select

        'Else
        '	ret2 = CStr(saved_Choice) 'to use the only month
        'End If
        ''here we handle all as a choice
        'If VB.Left(ret2, 3) = "ALL" Then
        '	full_flag = "Y"
        '	ret2 = Mid(ret2, 4)


        'End If

        ''and then set the beginning and end of the chosen month
        ''this overwrites the slected range
        'num = InStr(ret2, "-")
        'Response = Month(CDate(ret2)) 'Left$(ret2, num - 1)
        'responseyear = Year(CDate(ret2)) 'Right$(ret2, 4)
        'Label2.Visible = True
        'text1.Visible = True
        'text1.Text = ret2

        'Select Case Response
        '	Case 1
        '		selected_start_date = CDate("1" & Chr(45) & "1" & Chr(45) & responseyear)
        '		selected_end_date = CDate("1" & Chr(45) & "31" & Chr(45) & responseyear)
        '	Case 2
        '		selected_start_date = CDate("2" & Chr(45) & "1" & Chr(45) & responseyear)
        '		selected_end_date = CDate("2" & Chr(45) & "28" & Chr(45) & responseyear)
        '	Case 3
        '		selected_start_date = CDate("3" & Chr(45) & "1" & Chr(45) & responseyear)
        '		selected_end_date = CDate("3" & Chr(45) & "31" & Chr(45) & responseyear)
        '	Case 4
        '		selected_start_date = CDate("4" & Chr(45) & "1" & Chr(45) & responseyear)
        '		selected_end_date = CDate("4" & Chr(45) & "30" & Chr(45) & responseyear)
        '	Case 5
        '		selected_start_date = CDate("5" & Chr(45) & "1" & Chr(45) & responseyear)
        '		selected_end_date = CDate("5" & Chr(45) & "31" & Chr(45) & responseyear)
        '	Case 6
        '		selected_start_date = CDate("6" & Chr(45) & "1" & Chr(45) & responseyear)
        '		selected_end_date = CDate("6" & Chr(45) & "30" & Chr(45) & responseyear)
        '	Case 7
        '		selected_start_date = CDate("7" & Chr(45) & "1" & Chr(45) & responseyear)
        '		selected_end_date = CDate("7" & Chr(45) & "31" & Chr(45) & responseyear)
        '	Case 8
        '		selected_start_date = CDate("8" & Chr(45) & "1" & Chr(45) & responseyear)
        '		selected_end_date = CDate("8" & Chr(45) & "31" & Chr(45) & responseyear)
        '	Case 9
        '		selected_start_date = CDate("9" & Chr(45) & "1" & Chr(45) & responseyear)
        '		selected_end_date = CDate("9" & Chr(45) & "30" & Chr(45) & responseyear)
        '	Case 10
        '		selected_start_date = CDate("10" & Chr(45) & "1" & Chr(45) & responseyear)
        '		selected_end_date = CDate("10" & Chr(45) & "31" & Chr(45) & responseyear)
        '	Case 11
        '		selected_start_date = CDate("11" & Chr(45) & "1" & Chr(45) & responseyear)
        '		selected_end_date = CDate("11" & Chr(45) & "30" & Chr(45) & responseyear)
        '	Case 12
        '		selected_start_date = CDate("12" & Chr(45) & "1" & Chr(45) & responseyear)
        '		selected_end_date = CDate("12" & Chr(45) & "31" & Chr(45) & responseyear)
        'End Select

        'If VB.Left(CStr(selected_end_date), 2) = "02" Then
        '	If IsDate("2" & Chr(45) & "29" & Chr(45) & responseyear) Then
        '		selected_end_date = CDate("2" & Chr(45) & "29" & Chr(45) & responseyear)
        '	End If
        'End If


        ''this allows us to get the records that we need to edit for one month only

        ''UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Data1.RecordSource = "select * from medopn_tmp where name_key = " & Chr(34) & Trim(selected_name_key) & Chr(34)
        ''UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Data1.RecordSource = Data1.RecordSource & " and contract_key = " & Chr(34) & Trim(selected_contract_key) & Chr(34) 'added for multiple contracts
        ''UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Data1.RecordSource = Data1.RecordSource & " and from_Date between " & Chr(35) & selected_start_date & Chr(35) & " and " & Chr(35) & selected_end_date & Chr(35) & " order by from_Date, place_serv, proc_code "



        ''first step is get the month then make the first and get that weekday
        'ret2 = Month(selected_start_date) & Chr(45) & "1" & Chr(45) & responseyear

        'left2 = WeekDay(CDate(ret2)) ' MyWeekDay contains 4 because
        '' MyDate represents a Wednesday.
        ''start date is the 0 entry in the array
        'date_Array(0) = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1 - left2, CDate(ret2))

        ''paint the date being edited on screen
        'num = InStr(ret2, "-")
        'Response = CInt(VB.Left(ret2, num - 1))
        'responseyear = CInt(VB.Right(ret2, 4))
        'Label2.Visible = True
        ''text1.Visible = True
        'text1.Text = ret2
        'Label5.Text = VB6.Format(ret2, "mmmm")

        'For num = 0 To 41
        '	dayt(num).TabStop = False
        '	dayt(num).Enabled = True
        '	sdr(num).Enabled = True
        '	adr(num).Enabled = True

        '	dayt(num).Text = CStr(VB.Day(date_Array(num)))
        '	day_num(num) = CStr(VB.Day(date_Array(num)))
        '	If num < 41 Then
        '		date_Array(num + 1) = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, date_Array(num))
        '		'set the last days enabled = false
        '	End If
        '	If Month(selected_start_date) <> Month(date_Array(num)) Then
        '		sdr(num).Enabled = False
        '		adr(num).Enabled = False
        '		dayt(num).Enabled = False
        '	End If


        'Next 

        'If CDbl(day_num(41)) > 6 Then
        '	For num = 35 To 41
        '		dayt(num).Visible = False
        '		sdr(num).Visible = False
        '		adr(num).Visible = False
        '	Next 
        'End If

        ''now that the calendar is set now to put the att_code in the right field
        'For num = 0 To 41
        '	If date_Array(num) = selected_start_date Then Exit For
        'Next 
        'start_position = num

        'Data1.Refresh()
        'total_units = 0
        'saved_date = CDate("01/01/1899")

        ''UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not Data1.Recordset.EOF
        '	'check to make sure the right day is lined up
        '	'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	If CDbl(day_num(num)) = VB.Day(Data1.Recordset.Fields("from_date")) Then
        '		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		If saved_date = Data1.Recordset.Fields("from_date") Then
        '			dayt(num).Text = dayt(num).Text & "***" '& Chr(13) & Data1.Recordset.Fields("Att_code")
        '		Else
        '			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      sdr(num).Text = Data1.Recordset.Fields("proc_code") & ""
        '      'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '      'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      total_units = total_units + Data1.Recordset.Fields("Att_units")
        '      'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '      'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      adr(num).Text = Data1.Recordset.Fields("Att_units") & ""
        '		End If

        '      'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '      'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      saved_Date = Data1.Recordset.Fields("from_date")
        '      'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '      'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      Data1.Recordset.MoveNext()
        '	Else
        '      sdr(num).Text = ""
        '	End If

        '      'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '      'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      If Not Data1.Recordset.EOF Then
        '          'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '          'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '          If saved_Date <> Data1.Recordset.Fields("from_date") Then
        '              num = num + 1
        '          End If
        '      End If

        'Loop 

        '      'get tmp1set to hold data if need to write a new record
        '      'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '      'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.MoveLast. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      Data1.Recordset.MoveLast()
        '      tmp1db = DAODBEngine_definst.OpenDatabase(am_data_path & "med.mdb")
        '      tmp1set = tmp1db.OpenRecordset("medopn_del", dao.RecordsetTypeEnum.dbOpenDynaset)

        '      Do While Not tmp1set.EOF
        '          tmp1set.delete()
        '          tmp1set.MoveNext()
        '      Loop

        '      tmp1set.AddNew()
        '      For num = 0 To tmp1set.Fields.Count - 1
        '          'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '          'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '          tmp1set.Fields(num).Value = Data1.Recordset.Fields(num)
        '      Next
        '      tmp1set.Update()

        '      Data1.Refresh()
        '      'dayt(start_position).SetFocus

        '      'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '      'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      Call cont_key_display(Data1.Recordset.Fields("contract_key"), msg)
        '      'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '      'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      selected_contract_key = Data1.Recordset.Fields("contract_key")
        '      txtFields(3).Text = msg
        '      Call calc_units()
        '      tot_units.Text = CStr(total_units)

        '      For num = 0 To 41
        '          sdr(num).TabIndex = num * 2
        '          adr(num).TabIndex = num * 2 + 1
        '          'UPGRADE_ISSUE: TextBox property sdr.DataChanged was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        '          sdr(num).DataChanged = False
        '          'UPGRADE_ISSUE: TextBox property adr.DataChanged was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
        '          adr(num).DataChanged = False
        '      Next

        '      'now to disable not selected time   ' 6/2/00
        '      For num = 0 To 41
        '          If date_Array(num) < selected_Date_Range_Start Or date_Array(num) > selected_Date_Range_End Then
        '              dayt(num).Enabled = False
        '              sdr(num).Enabled = False
        '              adr(num).Enabled = False
        '          End If

        '      Next

        '      'now to put focus in right place
        '      For num = 0 To 41
        '          If sdr(num).Enabled = True Then
        '              On Error Resume Next
        '              sdr(num).Focus()
        '              On Error GoTo 0
        '              Exit For
        '          End If
        '      Next
		
	End Sub
	
	'UPGRADE_WARNING: Event adr.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub adr_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles adr.TextChanged
        Dim Index As Short = adr.GetIndex(CType(eventSender, TextBox))
		adr(Index).Text = Trim(UCase(adr(Index).Text))
		
	End Sub
	
	Private Sub adr_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles adr.Enter
        Dim Index As Short = adr.GetIndex(CType(eventSender, TextBox))
		Call ets_set_selected()
	End Sub
	
	Private Sub adr_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles adr.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = adr.GetIndex(CType(eventSender, TextBox))
		If KeyAscii = 13 Or KeyAscii = 9 Then
			If Len(Trim(adr(Index).Text)) = 0 Then
				adr(Index).Text = CStr(0)
			End If
			
			If Not IsNumeric(adr(Index).Text) Then
				MsgBox("This must be a number.")
				Call ets_set_selected()
			End If
			
			
			Call calc_units()
			
			System.Windows.Forms.SendKeys.Send("{TAB}")
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub adr_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles adr.Leave
        Dim Index As Short = adr.GetIndex(CType(eventSender, TextBox))
		adr(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	
	Private Sub sdr_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sdr.DoubleClick
        Dim Index As Short = sdr.GetIndex(CType(eventSender, TextBox))
		function_type = "DATA_ENTRY"
		
		' medfeelookup.Show 1
		sdr(Index).Text = selected_lookup_num
	End Sub
	
	Private Sub sdr_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sdr.Enter
        Dim Index As Short = sdr.GetIndex(CType(eventSender, TextBox))
		Call ets_set_selected()
	End Sub
	
	Private Sub sdr_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles sdr.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = sdr.GetIndex(CType(eventSender, TextBox))
		If KeyAscii = 13 Or KeyAscii = 9 Then
			sdr(Index).Text = UCase(sdr(Index).Text)
			
            '	valid_yn = "N"
			
			If Len(Trim(sdr(Index).Text)) = 0 Then
				function_type = "DATA_ENTRY"
				
				' medfeelookup.Show 1
				sdr(Index).Text = selected_lookup_num
			End If
			
            '		Call chk_Proc_code(sdr(Index), Today)
			
            'If valid_yn = "N" Then
            '	MsgBox("Invalid Procedure Code.")

            '	Call ets_set_selected()

            '	GoTo EventExitSub
            'End If
			
			If Val(adr(Index).Text) = 0 Then adr(Index).Text = CStr(1)
			Call calc_units()
			
			System.Windows.Forms.SendKeys.Send("{TAB}")
			KeyAscii = 0
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub sdr_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sdr.Leave
        Dim Index As Short = sdr.GetIndex(CType(eventSender, TextBox))
		sdr(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
		
	End Sub
End Class