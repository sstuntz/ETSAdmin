Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETS.Common.Module1
Imports PS.Common

Public Class apmckreg
    Inherits System.Windows.Forms.Form

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        Command1.Focus()

    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        prtDestination = CStr(0)
        prtreportfilename = ap_report_path & "apmckreg.rpt"
        CrystalForm.ShowDialog()
    End Sub


    Private Sub apmckreg_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'data 1 = etssys

    End Sub

    Private Sub txtField0_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField0.Enter
        Dim Index As Short = txtField0.GetIndex(eventSender)
        txtField0(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        txtField0(Index).SelectionStart = 0
        txtField0(Index).SelectionLength = Len(txtField0(Index).Text)
    End Sub

    Private Sub txtField0_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField0.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = txtField0.GetIndex(eventSender)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = txtField0(0).Text
            If etsdate(senddate, "") = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                txtField0(Index).Text = etsdate(senddate, "")
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

    Private Sub txtField0_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField0.Leave
        Dim Index As Short = txtField0.GetIndex(eventSender)
        txtField0(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub txtField1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField1.Enter
        Dim Index As Short = txtField1.GetIndex(eventSender)
        'this is rpthead.end_date
        txtField1(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        txtField1(Index).SelectionStart = 0
        txtField1(Index).SelectionLength = Len(txtField1(Index).Text)
    End Sub

    Private Sub txtField1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField1.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = txtField1.GetIndex(eventSender)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = txtField1(1).Text
            If etsdate(senddate, "") = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub

            Else
                txtField1(1).Text = etsdate(senddate, "")
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

    Private Sub txtField1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField1.Leave
        Dim Index As Short = txtField1.GetIndex(eventSender)
        txtField1(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        cmdUpdate.Focus()
    End Sub
End Class