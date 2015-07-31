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

Friend Class ed_range_dates
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 5/19/97 - SCS
	
	'****************
	
	Dim day_num(41) As String
	Dim sdr_type(4) As String
	Dim message As String
	Dim title As String
	'UPGRADE_NOTE: default was upgraded to default_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Dim default_Renamed As String
	Dim start_date As Date
	Dim date_Array(41) As Date
	Dim start_position As Short
	
    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        'For num = 0 To 41
        '    If Len(sdr(num).Text) <> 0 Then
        '        If sdr(num).Text = "DEL" Then
        '            'delete records
        '            'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            Data1.RecordSource = "select * from attend_tmp where contract_key = " & Chr(34) & selected_contract_key & Chr(34)
        '            'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            Data1.RecordSource = Data1.RecordSource & " and att_Date = " & Chr(35) & date_Array(num) & Chr(35)
        '            Data1.Refresh()
        '            'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            Data1.Recordset.MoveFirst()

        '            'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            Do While Not Data1.Recordset.EOF
        '                'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.delete. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                Data1.Recordset.delete()
        '                'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                Data1.Recordset.MoveNext()
        '            Loop

        '        Else
        '            'change records to this value
        '            'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            Data1.RecordSource = "select * from attend_tmp where contract_key = " & Chr(34) & selected_contract_key & Chr(34)
        '            'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            Data1.RecordSource = Data1.RecordSource & " and att_Date = " & Chr(35) & date_Array(num) & Chr(35)
        '            Data1.Refresh()

        '            'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            If Data1.Recordset.Fields("bill_Type") = "125" Then
        '                MsgBox("You can not group modify this bill type.")
        '                Me.Close()
        '                Exit Sub
        '            End If

        '            'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            Data1.Recordset.MoveFirst()
        '            'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            Do While Not Data1.Recordset.EOF
        '                'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.edit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                Data1.Recordset.edit()
        '                'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                Data1.Recordset.Fields("att_code") = sdr(num).Text
        '                'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                Data1.Recordset.Update()
        '                'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                Data1.Recordset.MoveNext()
        '            Loop


        '        End If
        '    End If
        'Next


        Me.Close()

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
	
	Private Sub ed_range_dates_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		ctrform(Me)
		
         sqlstmnt = "select * from attend_tmp where contract_key = '" & selected_contract_key & "' order by att_Date "
        'selected_start_date = Data1.Recordset.Fields("Att_Date")
        'Data1.Recordset.MoveLast()
        'selected_end_date = Data1.Recordset.Fields("Att_Date")
        'If Month(selected_start_date) - Month(selected_end_date) <> 0 Then
        '	'list the months to process and have them select one use a drop down box
        '	att_date_choose.ShowDialog()

        '	num = InStr(ret2, "-")
        '	Response = CInt(VB.Left(ret2, num - 1))
        '	responseyear = CInt(VB.Right(ret2, 4))
        '	Label2.Visible = True
        '	text1.Visible = True
        '	text1.Text = ret2



        '	Select Case Response
        '		Case 1
        '			selected_start_date = CDate("1" & Chr(45) & "1" & Chr(45) & responseyear)
        '			selected_end_date = CDate("1" & Chr(45) & "31" & Chr(45) & responseyear)
        '		Case 2
        '			selected_start_date = CDate("2" & Chr(45) & "1" & Chr(45) & responseyear)
        '			selected_end_date = CDate("2" & Chr(45) & "28" & Chr(45) & responseyear)
        '		Case 3
        '			selected_start_date = CDate("3" & Chr(45) & "1" & Chr(45) & responseyear)
        '			selected_end_date = CDate("3" & Chr(45) & "31" & Chr(45) & responseyear)
        '		Case 4
        '			selected_start_date = CDate("4" & Chr(45) & "1" & Chr(45) & responseyear)
        '			selected_end_date = CDate("4" & Chr(45) & "30" & Chr(45) & responseyear)
        '		Case 5
        '			selected_start_date = CDate("5" & Chr(45) & "1" & Chr(45) & responseyear)
        '			selected_end_date = CDate("5" & Chr(45) & "31" & Chr(45) & responseyear)
        '		Case 6
        '			selected_start_date = CDate("6" & Chr(45) & "1" & Chr(45) & responseyear)
        '			selected_end_date = CDate("6" & Chr(45) & "30" & Chr(45) & responseyear)
        '		Case 7
        '			selected_start_date = CDate("7" & Chr(45) & "1" & Chr(45) & responseyear)
        '			selected_end_date = CDate("7" & Chr(45) & "31" & Chr(45) & responseyear)
        '		Case 8
        '			selected_start_date = CDate("8" & Chr(45) & "1" & Chr(45) & responseyear)
        '			selected_end_date = CDate("8" & Chr(45) & "31" & Chr(45) & responseyear)
        '		Case 9
        '			selected_start_date = CDate("9" & Chr(45) & "1" & Chr(45) & responseyear)
        '			selected_end_date = CDate("9" & Chr(45) & "30" & Chr(45) & responseyear)
        '		Case 10
        '			selected_start_date = CDate("10" & Chr(45) & "1" & Chr(45) & responseyear)
        '			selected_end_date = CDate("10" & Chr(45) & "31" & Chr(45) & responseyear)
        '		Case 11
        '			selected_start_date = CDate("11" & Chr(45) & "1" & Chr(45) & responseyear)
        '			selected_end_date = CDate("11" & Chr(45) & "30" & Chr(45) & responseyear)
        '		Case 12
        '			selected_start_date = CDate("12" & Chr(45) & "1" & Chr(45) & responseyear)
        '			selected_end_date = CDate("12" & Chr(45) & "31" & Chr(45) & responseyear)
        '	End Select

        '	If VB.Left(CStr(selected_end_date), 1) = "2" Then
        '		If IsDate("2" & Chr(45) & "29" & Chr(45) & responseyear) Then
        '			selected_end_date = CDate("2" & Chr(45) & "29" & Chr(45) & responseyear)
        '		End If
        '	End If


        '	'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Data1.RecordSource = "select * from attend_tmp where contract_key = " & Chr(34) & selected_contract_key & Chr(34)
        '	'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	Data1.RecordSource = Data1.RecordSource & " and att_Date between " & Chr(35) & selected_start_date & Chr(35) & " and " & Chr(35) & selected_end_date & Chr(35) & " order by att_Date "
        '	Data1.Refresh()

        'End If

        'function_type = "DATA_ENTRY"
        'For num = 0 To 41
        '	dayt(num).Text = ""
        '	sdr(num).Text = ""
        'Next 

        ''first step is get the month then make the first and get that weekday
        'ret2 = Month(selected_start_date) & Chr(45) & "1" & Chr(45) & Year(selected_start_date)

        'left2 = WeekDay(CDate(ret2)) ' MyWeekDay contains 4 because
        '' MyDate represents a Wednesday.
        ''start date is the 0 entry in the array
        'date_Array(0) = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1 - left2, CDate(ret2))


        'For num = 0 To 41
        '	dayt(num).Enabled = True

        '	dayt(num).Text = CStr(VB.Day(date_Array(num)))
        '	day_num(num) = CStr(VB.Day(date_Array(num)))
        '	If num < 41 Then
        '		date_Array(num + 1) = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, date_Array(num))
        '		'set the last days enabled = false
        '	End If
        'Next 

        'If CDbl(day_num(41)) > 6 Then
        '	For num = 35 To 41
        '		dayt(num).Visible = False
        '		sdr(num).Visible = False
        '	Next 
        'End If

        ''now that the calendar is set now to put the att_code in the right field

        'Data1.Refresh()
        ''dayt(start_position).SetFocus

        ''UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Call cont_key_display(Data1.Recordset.Fields("contract_key"), msg)
        'txtFields(3).Text = msg
		
	End Sub
	
	'UPGRADE_WARNING: Event sdr.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub sdr_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sdr.TextChanged
        Dim Index As Short = sdr.GetIndex(CType(eventSender, TextBox))
		'    sdr(Index).Text = Trim(UCase(sdr(Index).Text))
	End Sub
	
	Private Sub sdr_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sdr.Enter
        Dim Index As Short = sdr.GetIndex(CType(eventSender, TextBox))
		Call ets_set_selected()
	End Sub
	
	Private Sub sdr_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles sdr.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = sdr.GetIndex(CType(eventSender, TextBox))
		If KeyAscii = 13 Or KeyAscii = 9 Then
			sdr(Index).Text = Trim(UCase(sdr(Index).Text))
			If selected_bill_type = "125" Then
				If Val(sdr(Index).Text) = 0 Then sdr(Index).Text = "0"
				If Not IsNumeric(CDbl(sdr(Index).Text)) Then
					MsgBox("This must be a number.")
					Call ets_set_selected()
				End If
			End If
			
			
			
			System.Windows.Forms.SendKeys.Send("{TAB}")
			KeyAscii = 0
		End If
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