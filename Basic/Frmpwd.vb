Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETS.Common.Module1
Imports ps.common

Public Class frmpwd_inp
    Inherits System.Windows.Forms.Form

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        entry_type = "CANCEL"
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub frmpwd_inp_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        Pwd_text.Text = ""
        Dim rect As Rectangle = Screen.PrimaryScreen.WorkingArea
        'Divide the screen in half, and find the center of the form to center it
        Me.Top = CInt((rect.Height / 2) - (Me.Height / 2))
        Me.Left = CInt((rect.Width / 2) - (Me.Width / 2))

    End Sub

    Private Sub pwd_text_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pwd_text.KeyPress
        Dim KeyAscii As Integer = Asc(eventArgs.KeyChar)

        If KeyAscii = 9 Or KeyAscii = 13 Then
            singl = Pwd_text.Text
            eventArgs.Handled = True

            Me.Close()

        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True

        End If
    End Sub
End Class