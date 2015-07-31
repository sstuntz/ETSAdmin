Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports System
Imports System.Configuration
Imports ETSCommon.Database
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Data.SqlClient
Friend Class frmcustrpt
	Inherits System.Windows.Forms.Form
	
	'****************
	'revision History
	'original date of this form is 02/17/1999 - SCS
	
	'****************
    'Option Explicit

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "cc_disab"
    Public frmWhereClause As String = " where disab_num = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
		
		'the following code checks for completeness
		'the string field has a list of the field numbers to check
        For Me.num1 = 0 To 100
            msg = "," & CStr(num1) & ","
            Response = InStr(",0,1,2,3,4,", msg)
            If Response <> 0 Then
                If Len(txtFields(CShort(num1)).Text) = 0 Then
                    MsgBox("You must fill in all required fields.")
                    txtFields(CShort(num1)).Focus()
                    Exit Sub
                End If
            End If
        Next

        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                numstr = Me.cntrl.Name.ToString.Substring(11)
                TagColumnName = Me.cntrl.Tag.ToString
                RowData.Find(AddressOf FindColumnName)
                num1 = CInt(numstr)
                RowData.Item(num1).ActualData = Me.cntrl.Text
            End If
        Next

        Select Case entry_type.ToString
            Case "ADD"
                Call ETSCommon.ETSSQL.InsertData(frmTableName, RowData)
            Case "EDIT"
                Call ETSCommon.ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)
        End Select
        Me.Close()
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
    Private Sub frmcustrpt_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        'have to add package type here to get right group of custom reports

        frmWhereClause = " where rpt_num = '" & selected_lookup_num & "'"

        If entry_type = "ADD" Then
            'add one to rpt num to get next sequence and turn that field off

        Else
            entry_type = "EDIT"
            cmdUpdate.Visible = True
            Dim rs As New Collection
            RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
            For Each Me.cntrl In Me.Controls
                If TypeOf Me.cntrl Is TextBox Then
                    numstr = Me.cntrl.Name.ToString.Substring(11)
                    TagColumnName = Me.cntrl.Tag.ToString
                    RowData.Find(AddressOf FindColumnName)
                    num1 = CInt(numstr)
                    Me.cntrl.Text = RowData.Item(num1).ActualData.ToString
                    txtFields(0).Enabled = False
                End If
            Next

        End If

   
        'Select Case package_Type

        '	Case "AP"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = ap_data_path & "ap.mdb"

        '	Case "AR"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = ar_data_path & "ar.mdb"

        '	Case "EE"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = ee_data_path & "ee.mdb"

        '	Case "EEHR"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = eehr_data_path & "eehr.mdb"

        '	Case "CC"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = cc_data_path & "cc.mdb"

        '	Case "CCHR"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = cchr_data_path & "cctr.mdb"

        '	Case "GL"

        '	Case "ATT"
        '		'UPGRADE_ISSUE: Data property Data1.DatabaseName was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Data1.DatabaseName = att_data_path & "aratt.mdb"
        'End Select



    End Sub
	
	Private Sub txtfields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Dim index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
		Call ets_set_selected()
    End Sub
	
	Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			Select Case index
                Case 3 'screen or printer
                    txtFields(index).Text = UCase(txtFields(index).Text)
                    If txtFields(index).Text <> "S" Then
                        If txtFields(index).Text <> "P" Then
                            MsgBox("You must enter an S for screen or a P for printer.")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If
				Case 4 'yes or no
					txtFields(index).Text = UCase(txtFields(index).Text)
					If txtFields(index).Text <> "Y" Then
						If txtFields(index).Text <> "N" Then
							MsgBox("You must enter a Y to prompt for a Begin Date and End Date or a N for no prompting.")
							Call ets_set_selected()
							GoTo EventExitSub
						End If
                    End If
			End Select
			
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
        Dim index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
		txtFields(index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
End Class