Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient

Public Class frmre_chk
    Inherits System.Windows.Forms.Form

    Public validYN As String
    Public sending As String

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edit.Click
        Lastgood.Focus()
    End Sub

    Private Sub frmre_chk_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Lastgood_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Lastgood.Enter
        Call ets_set_selected()
    End Sub

    Private Sub Lastgood_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Lastgood.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            If checkYN("apck_pad", "chk_num", Lastgood.Text) = "N" Then
                MsgBox("Not a check number in this run.  Please enter another")
                Call ets_set_selected()
                GoTo EventExitSub
            End If
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub Lastgood_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Lastgood.Leave
        Call ets_de_selected()
        Lastgood.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub newbegnum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles newbegnum.Enter
        Call ets_set_selected()
    End Sub

    Private Sub newbegnum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles newbegnum.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            If Val(newbegnum.Text) - Val(Lastgood.Text) < 1 Then
                MsgBox("Please input a valid starting new starting check number.")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            If Val(newbegnum.Text) - Val(Lastgood.Text) > 10 Then
                MsgBox("Warning- your new check number is more than 10 higher than the last valid number.")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            If checkYN("payment", "chk_num", newbegnum.Text) = "Y" Then
                MsgBox("Check number already used.  Please enter another number.")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0

            End If
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub newbegnum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles newbegnum.Leave
        Call ets_de_selected()
        newbegnum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub prtchk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prtchk.Click
        Response = MsgBox(" LASER Printer Ready?, ok to proceed?", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.No Then Exit Sub

        'delete printed checks from apck pad and renumber
        sqlstmnt = " delete from apck_pad where chk_num <= " & Lastgood.Text
        ETSSQL.ExecuteSQL(sqlstmnt)

        'renumber apck pad checks by adding the difference in check numbers to chk num
        Dim DiffChks As Integer = CInt(CDbl(newbegnum.Text) - CDbl(Lastgood.Text))
        sqlstmnt = " update apck_pad set chk_num = chk_num + " & DiffChks
        ETSSQL.ExecuteSQL(sqlstmnt)

        'renumber apchecks 
        sqlstmnt = "update apchecks set chk_num = chk_num + " & DiffChks & " where chk_num >= " & Lastgood.Text
        ETSSQL.ExecuteSQL(sqlstmnt)

        'put new begin number in rpthead
        sqlstmnt = "update rpthead set beg_num = '" & newbegnum.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        'then print

        prtDestination = 1
        prtreportfilename = ap_report_path & "aplaser.rpt"
        CrystalForm.ShowDialog()

        Response = MsgBox("Did the checks all print?", MsgBoxStyle.YesNo)
        If Response = 6 Then
            Me.Close()
            Me.Dispose()
        Else
            MsgBox("Please start over with the last good check number.")
            Lastgood.Focus()
        End If

    End Sub

End Class