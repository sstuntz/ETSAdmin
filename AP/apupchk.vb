Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Imports ETS.Common.Module1
Imports PS.Common

Public Class apupchk
    Inherits System.Windows.Forms.Form

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        'this is to put a "Y" in the checked field

        sqlstmnt = "select * from voucher WHERE voucher.checked <> 'Y' "
        sqlstmnt = sqlstmnt & " and voucher.vouch_num between "
        sqlstmnt = sqlstmnt & txtFields(0).Text & " and "
        sqlstmnt = sqlstmnt & txtFields(1).Text & " order by voucher.vouch_num "
        Dim reccount As Integer = CheckRecordCount(sqlstmnt)
        If reccount = 0 Then
            MsgBox("There are no unchecked Vouchers for this range of numbers.")
            Exit Sub
        End If

        sqlstmnt = "update voucher set checked = 'Y' where voucher.vouch_num between "
        sqlstmnt = sqlstmnt & txtFields(0).Text & " and "
        sqlstmnt = sqlstmnt & txtFields(1).Text & ""
        ETSSQL.ExecuteSQL(sqlstmnt)

        MsgBox("Vouchers selected have been Marked as Checked")
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub apupchk_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        txtFields(0).Text = CStr(0)
        txtFields(1).Text = CStr(0)

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(eventSender)
        Call ets_set_selected()
    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = txtfields.GetIndex(eventSender)
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index

                Case 0, 1 'Trap for valid numbers
                    If Len(txtFields(0).Text) = 0 Then
                        MsgBox("Please enter a number")
                        GoTo EventExitSub
                    End If

                    If Not IsNumeric(txtFields(0).Text) Then
                        MsgBox("Not a valid number")
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

    Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        Dim Index As Short = txtfields.GetIndex(eventSender)
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub
End Class