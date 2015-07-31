Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports Valid_YN

Public Class gljeprt
    Inherits System.Windows.Forms.Form

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "gljeprt.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "gljeprtn.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub frmgljeprt_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ' data1 = etssys

    End Sub

    Private Sub txtField0_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField0.Enter
        Dim Index As Short = txtField0.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub


    Private Sub txtField0_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField0.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField0.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            valid_Date = "N"
            senddate = txtField0(Index).Text
            If etsdate(senddate, valid_Date) <> "N" Then
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
            Else
                MsgBox("Bad date")
                Form.ActiveForm.ActiveControl.BackColor = Color.Aqua()
                GoTo EventExitSub
            End If

            txtField0(Index).Text = senddate
            txtField0(Index).Text = CStr(CDate(txtField0(Index).Text))

        End If

EventExitSub:
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
        Call ets_set_selected()
    End Sub


    Private Sub txtField1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField1.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            valid_Date = "N"

            valid_Date = "N"
            senddate = txtField1(Index).Text
            If etsdate(senddate, valid_Date) <> "N" Then
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
            Else
                MsgBox("Bad date")
                Form.ActiveForm.ActiveControl.BackColor = Color.Aqua()
                GoTo EventExitSub
            End If

            txtField1(Index).Text = senddate
            txtField1(Index).Text = CStr(CDate(txtField0(Index).Text))

        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub txtField1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField1.Leave
        Dim Index As Short = txtField1.GetIndex(CType(eventSender, TextBox))
        txtField1(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub


    Private Sub txtField2_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField2.Enter
        Dim Index As Short = txtField2.GetIndex(CType(eventSender, TextBox))
        txtField2(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        txtField2(Index).SelectionStart = 0
        txtField2(Index).SelectionLength = Len(txtField2(Index).Text)
    End Sub


    Private Sub txtField2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField2.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField2.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub txtField2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField2.Leave
        Dim Index As Short = txtField2.GetIndex(CType(eventSender, TextBox))
        txtField2(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))

    End Sub

    Private Sub txtField3_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField3.Enter
        Dim Index As Short = txtField3.GetIndex(CType(eventSender, TextBox))
        txtField3(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        txtField3(Index).SelectionStart = 0
        txtField3(Index).SelectionLength = Len(txtField3(Index).Text)
    End Sub


    Private Sub txtField3_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField3.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField3.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub txtField3_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField3.Leave
        Dim Index As Short = txtField3.GetIndex(CType(eventSender, TextBox))
        txtField3(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        cmdUpdate.Focus()
    End Sub
End Class