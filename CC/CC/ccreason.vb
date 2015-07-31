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

Friend Class frmccreason
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 9/23/96 -SCS
	
    '****************

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "cc_reason"
    Public frmWhereClause As String = " where reason_num = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
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

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        selected_lookup_num = ""
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmccreason_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        frmWhereClause = " where disab_num = '" & selected_lookup_num & "'"

        If entry_type = "ADD" Then

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

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        'Call ets_set_selected()
    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index
                Case 0 'check for length of field
                    If Len(txtFields(Index).Text) <> 2 Then
                        MsgBox("Reason number must be 2 characters long.")
                        GoTo EventExitSub
                        Call ets_set_selected()
                    End If

                    If Not IsNumeric(txtFields(Index).Text) Then
                        MsgBox("Reason number must be numeric.")
                        GoTo EventExitSub
                        Call ets_set_selected()
                    End If
                    'check for duplicates if add
                    'under edit this field can not get focus so ok to just check
                    '   If valid_yn = "Y" Then
                    'MsgBox("This number has been used. Please enter a different one or cancel.")
                    'Call ets_set_selected()
                    'GoTo EventExitSub
                    'End If
                Case 2
                    'check for y or bn uppercase
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    If txtFields(Index).Text <> "N" And txtFields(Index).Text <> "Y" Then
                        MsgBox("Please enter a Y or N")
                        Call ets_set_selected()
                        GoTo EventExitSub
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

    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Leave
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

End Class