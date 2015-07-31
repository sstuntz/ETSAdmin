Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETSCommon.Database
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Configuration
Imports System.Data.SqlClient

Friend Class custrpt_lookup
    Inherits System.Windows.Forms.Form

    Public selected_print As String
	
	'****************
	'revision History
	'original date of this form is 6/23/96 -SCS
	'modified to be used as a template on 12/2/98 - scs
	
	'replace xxx with the right names
	
	'****************
    Private Sub rptgrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles RptGrid.CellContentClick
        selectedcell = True
        selected_lookup_num = RptGrid.Item("rpt_num", e.RowIndex).Value.ToString
        selected_lookup_desc = RptGrid.Item("rpt_desc", e.RowIndex).Value.ToString
        selected_print = RptGrid.Item("rpt_screeb", e.RowIndex).Value.ToString
        selected_report = RptGrid.Item("rpt_date", e.RowIndex).Value.ToString

    End Sub

    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        'here we print the report
        'we ask the date question first

        If selected_report = "Y" Then
            MsgBox("Be sure to enter the correct Begin and End Dates.")
            Start_date.Focus()
        Else
            Call print_it()
        End If

    End Sub
	
	Private Sub print_it()
		'now set the destination
		'  prtDiscardSavedData = 1
		' prtparameterfields(0) = ""
		'prtparameterfields(1) = ""
        If selected_print = "S" Then
            '   prtDestination = 0
        Else
            '  prtDestination = 1
        End If

        'now the report
          Select Case package_Type

            Case "AP"
                '   prtreportfilename = ap_report_path & selected_lookup_num

            Case "AR"
                '  prtreportfilename = ar_report_path & selected_lookup_num

            Case "EE"
                ' prtreportfilename = ee_report_path & selected_lookup_num

            Case "EEHR"
                'prtreportfilename = eehr_report_path & selected_lookup_num

            Case "CC"
                '  prtreportfilename = cc_report_path & selected_lookup_num
            Case "CCHR"
                ' prtreportfilename = cchr_report_path & selected_lookup_num

            Case "GL"
                'prtreportfilename = gl_report_path & selected_lookup_num
            Case "ATT"
                '   prtreportfilename = att_report_path & selected_lookup_num
            Case "AM"
                '  prtreportfilename = am_report_path & selected_lookup_num
        End Select


        On Error Resume Next
        'Call frmcrystal_Call

        Select Case Err.Number

            Case 0
            Case 20504, 20507
                '        MsgBox("Report not found in " & prtreportfilename)
            Case Else
                MsgBox("Unexplained error = " & Err.Number & Chr(13) & ErrorToString(Err.Number))
        End Select
        RptGrid.Focus()
    End Sub
	
	Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
		
		If selectedcell = True Then
			MsgBox("Something selected. Can not add.")
			selectedcell = False
			Exit Sub
		End If
		
		entry_type = "ADD"
		selected_lookup_num = ""
		selected_lookup_desc = ""
		selected_name_key = ""
		frmcustrpt.ShowDialog()
		
    End Sub
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		'blank the variables
		selected_lookup_num = ""
		selected_lookup_desc = ""
        selected_name_key = ""
        Me.Close()
		
	End Sub
	
    Private Sub RptDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RptDelete.Click
        'added this button 2/21/02 lhw
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        Response = MsgBox("Do you really want to delete this report?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = MsgBoxResult.Yes Then
            sqlstmnt = " delete * from custrpt where rpt_num = " & selected_lookup_num
            Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
                Dim sql As String = sqlstmnt
                db.ExecuteQuery(sql)
            End Using
        End If

    End Sub
	
    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edit.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        entry_type = "EDIT"

        'goto the form that will fill in the data
        frmcustrpt.ShowDialog()

    End Sub
	
	Private Sub end_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles end_date.Enter
		Call ets_set_selected()
	End Sub
	
	Private Sub end_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles end_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
		If KeyAscii = 13 Or KeyAscii = 9 Then
			valid_Date = "N"
			senddate = End_Date.Text
            Call etsdate(senddate, valid_Date)
			
			If valid_Date <> "N" Then
                End_Date.Text = CStr(retdate)
				End_Date.Text = CStr(CDate(End_Date.Text))
				
				Call print_it()
				
				
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
	
	Private Sub end_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles end_date.Leave
		End_Date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub custrpt_lookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        'data1 is etssys
        'data2 is etssys
		ctrform(Me)
		
        '      'data1 is the custrpt location
        ''data2 is the rpt head location and name

        'Select Case package_Type

        '	Case "AP"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = ap_data_path & "ap.mdb"
        '		'UPGRADE_ISSUE: Data property Data2.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data2.DatabaseName = gl_data_path & "etssys.mdb"
        '	Case "AR"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = ar_data_path & "ar.mdb"
        '		'UPGRADE_ISSUE: Data property Data2.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data2.DatabaseName = ar_data_path & "ar.mdb"
        '		'UPGRADE_ISSUE: Data property Data2.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data2.RecordSource = "select * from ar_rpthead"
        '	Case "EE"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = ee_data_path & "ee.mdb"
        '		'UPGRADE_ISSUE: Data property Data2.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data2.DatabaseName = ee_data_path & "ee.mdb"
        '	Case "EEHR"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = eehr_data_path & "eehr.mdb"
        '		'UPGRADE_ISSUE: Data property Data2.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data2.DatabaseName = eehr_data_path & "eehr.mdb"
        '	Case "CC"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = cc_data_path & "cc.mdb"
        '		'UPGRADE_ISSUE: Data property Data2.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data2.DatabaseName = cc_data_path & "cc.mdb"
        '	Case "CCHR"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = cchr_data_path & "cctr.mdb"
        '		'UPGRADE_ISSUE: Data property Data2.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data2.DatabaseName = cchr_data_path & "cctr.mdb"
        '	Case "GL"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = gl_data_path & "etssys.mdb"
        '		'UPGRADE_ISSUE: Data property Data2.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data2.DatabaseName = gl_data_path & "etssys.mdb"
        '	Case "ATT"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = att_data_path & "aratt.mdb"
        '		'UPGRADE_ISSUE: Data property Data2.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data2.DatabaseName = att_data_path & "aratt.mdb"
        '		'UPGRADE_ISSUE: Data property Data2.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data2.RecordSource = "select * from aratt_rpthead"

        '	Case "AM"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = am_data_path & "etssys.mdb"
        '		'UPGRADE_ISSUE: Data property Data2.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data2.DatabaseName = am_data_path & "etssys.mdb"

        'End Select

        ''UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Data1.RecordSource = "SELECT * From custrpt ORDER BY rpt_desc"
        'Data1.Refresh()
        'Data2.Refresh()

        'Data1.Refresh()
        ''UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If Data1.Recordset.RecordCount = 0 Then
        '	MsgBox("No records yet created for custom reports.  Will go directly to Add")
        '	entry_type = "ADD"
        '	selected_lookup_num = ""
        '	selected_lookup_desc = ""
        '	'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	selected_name_key = ""
        '	frmcustrpt.ShowDialog()
        '	Data1.Refresh()
        '	'Exit Sub
        'End If

        'Call rebuild_grid()
		
	End Sub

	Private Sub start_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date.Enter
		Call ets_set_selected()
	End Sub
	
	Private Sub start_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles start_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
		If KeyAscii = 13 Or KeyAscii = 9 Then
			valid_Date = "N"
			senddate = Start_date.Text
            Call etsdate(senddate, valid_Date)
			
			If valid_Date <> "N" Then
                Start_date.Text = CStr(retdate)
				Start_date.Text = CStr(CDate(Start_date.Text))
				
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
	
	Private Sub start_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date.Leave
		Start_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
End Class