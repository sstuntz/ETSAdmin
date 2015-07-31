Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports ps.common
Imports System.Data.SqlClient

Public Class frmcustrpt
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "custrpt"
    Public frmWhereClause As String = " where rpt_num = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr() As String

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                numstr = Me.cntrl.Name.Split(CChar("_")) 'Me.cntrl.Name.ToString.Substring(11)
                TagColumnName = Me.cntrl.Tag.ToString
                RowData.Find(AddressOf FindColumnName)
                num1 = CInt(numstr(2))
                RowData.Item(num1).ActualData = Me.cntrl.Text
            End If
        Next
        Select Case entry_type.ToString
            Case "ADD"
                RowData.Item(RowData.Count - 1).ActualData = package_Type
                Call ETSSQL.InsertData(frmTableName, RowData)
            Case "EDIT"
                Call ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)
        End Select
        Me.Close()
        Me.Dispose()

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

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()

    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index
                Case 0      'add fills in next number  edit does not enable 0

                Case 1      'name

                Case 2          'desc


                Case 3 'screen or printer
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    If txtFields(Index).Text <> "S" Then
                        If txtFields(Index).Text <> "P" Then
                            MsgBox("You must enter an S for screen or a P for printer.")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If


                Case 4 'yes or no
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    If txtFields(Index).Text <> "Y" Then
                        If txtFields(Index).Text <> "N" Then
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

    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Leave
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub frmcustrpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ctrform(Me)

        If entry_type = "ADD" Then
            'blank all the fields and make the key enabled
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                    txtFields(0).Enabled = True
                End If
            Next
            txtFields(0).Text = (CInt(ETSSQL.GetOneSQLValue("select top(1) rpt_num as thevalue from custrpt order by rpt_num desc")) + 1).ToString
            txtFields(3).Text = "S"
            txtFields(4).Text = "Y"

        Else
            'copied from template
            frmWhereClause = " where rpt_num = '" & selected_lookup_num & "'"
            entry_type = "EDIT"
            Dim rs As New Collection
            RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    If Len(frmdata.ActualData) <> 0 Then
                        If frmdata.DataType = "datetime" Or frmdata.DataType = "DATE" Then
                            cntrl.Text = CDate(frmdata.ActualData).ToShortDateString
                        Else
                            cntrl.Text = frmdata.ActualData.ToString
                        End If
                    End If
                End If
            Next
            txtFields(0).Enabled = False
        End If

    End Sub
End Class