Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETS.Common.Module1
Imports PS.Common
Imports Microsoft.VisualBasic.ErrObject
Imports System.Data.SqlClient
Imports System
Imports System.Configuration

Public Class frmlck
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "rpthead"
    Public frmWhereClause As String = " where agency = 1"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        sqlstmnt = "update rpthead set beg_num = '" & _txtField0_0.Text & "', end_num = ' " & _txtField1_1.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

    End Sub

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
        frm_mnuap.Show()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        prtDestination = 1
        prtreportfilename = ap_report_path & "apchkreg.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Me.Close()
        Me.Dispose()
        frm_mnuap.Show()
    End Sub

    Private Sub frmlck_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        entry_type = "EDIT"
    End Sub

    Private Sub txtField0_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField0.Enter
        Dim Index As Short = txtField0.GetIndex(CType(eventSender, TextBox))
        txtField0(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        txtField0(Index).SelectionStart = 0
        txtField0(Index).SelectionLength = Len(txtField0(Index).Text)

    End Sub

    Private Sub txtField0_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField0.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField0.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtField0_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField0.Leave
        Dim Index As Short = txtField0.GetIndex(CType(eventSender, TextBox))
        txtField0(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub txtField1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField1.Enter
        Dim Index As Short = txtField1.GetIndex(CType(eventSender, TextBox))
        txtField1(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        txtField1(Index).SelectionStart = 0
        txtField1(Index).SelectionLength = Len(txtField1(Index).Text)
    End Sub

    Private Sub txtField1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField1.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtField1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField1.Leave
        Dim Index As Short = txtField1.GetIndex(CType(eventSender, TextBox))
        txtField1(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub
End Class