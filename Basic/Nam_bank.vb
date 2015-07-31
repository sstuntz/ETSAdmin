Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports ps.common
Imports System.Data.SqlClient

Public Class frmnam_bank
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "nam_bank"
    Public frmWhereClause As String = " where bank_key = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        'If Len(txtFields(7).Text) = 0 Then
        '    MsgBox("You must enter an account number in DR_PREF_AC field.")
        '    txtFields(7).Focus()
        '    Exit Sub
        'End If

        'If Len(txtFields(10).Text) = 0 Then
        '    MsgBox("You must enter the Bank ABA Number.")
        '    txtFields(10).Focus()
        '    Exit Sub
        'End If

        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                TagColumnName = Me.cntrl.Tag.ToString
                Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                frmdata.ActualData = Me.cntrl.Text
            End If
        Next

        Select Case entry_type.ToString
            Case "ADD"
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

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "apbank.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub frmnam_bank_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Normal     'added lhw 06/19/2012
        ctrform(Me)


        frmWhereClause = " where bank_key = '" & selected_lookup_num & "'"
        If entry_type = "ADD" Then
            'blank all the fields and make the key enabled
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                    txtFields(0).Enabled = True
                End If
            Next
            txtFields(1).Text = selected_screen_nam
            txtFields(0).Text = selected_name_key
            txtFields(0).Enabled = False
            txtFields(1).Enabled = False
        Else
            entry_type = "EDIT"
            cmdUpdate.Visible = True
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

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))

    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index
                Case 3, 5
                    If ets_format(txtFields(Index).Text, "", 2) <> "N" Then
                        txtFields(Index).Text = ets_format(txtFields(Index).Text, "", 2)
                    Else
                        MsgBox("invalid phone number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                Case 7

                    valid_acct = " N "
                    function_type_saved = function_type
                    function_type = "LOOKUP_ONLY"

                    Dim retacct As String = etsacctnum_chk(txtFields(Index).Text)

                    If retacct = "N" Then
                        txtFields(Index).Text = ""
                        MsgBox(" Bad Account Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtFields(Index).Text = retacct
                    End If
                    function_type = function_type_saved

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