Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETS.Common.Module1
Imports PS.Common

Public Class apsvch_frm
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
        prtreportfilename = ap_report_path & "apsvch.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub apsvch_frm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'data 1 = etssys
    End Sub

    Private Sub txtField0_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField0.Click
        Dim Index As Short = txtField0.GetIndex(eventSender)
        txtField0(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        txtField0(Index).SelectionStart = 0
        txtField0(Index).SelectionLength = Len(txtField0(Index).Text)
    End Sub

    Private Sub txtField0_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField0.Leave
        Dim Index As Short = txtField0.GetIndex(eventSender)
        cmdUpdate.Focus()
    End Sub

End Class