Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports Valid_YN

Public Class apvchdel_frm
    Inherits System.Windows.Forms.Form

    'Form Process
    'Select all vouchers that have been fully paid and posted and the checks that paid them have been reconciled that are before the selected Date.
    'the reports are from the data files and the d-flags have been set to Y - yes
    'move both the vouchers and payments to the history files
    'delete the vouchers and payments from the data files

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub DeleteRecords_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DeleteRecords.Click
        Response = MsgBox(" Select YES to Continue with Deletion   ", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.Yes Then
            sqlstmnt = "delete from voucher where dflag = 'Y' "
            ETSSQL.ExecuteSQL(sqlstmnt)
            MsgBox("Voucher records have been deleted.")

            sqlstmnt = "delete from payment where dflag = 'Y' "
            ETSSQL.ExecuteSQL(sqlstmnt)
            MsgBox("Payment records have been deleted.")
        End If
    End Sub

    Private Sub CmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub RecordSelect_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RecordSelect.Click
        MsgBox("This is marking records for deletion.")

        'so voucher records where glposted, date < input date
        'if paid (payments (which are posted and reconciled) total to voucher.inv total
        'set the dflag on both sets of records
        sqlstmnt = " select * from voucher where encum_date <= " & Chr(35) & txtFields(0).Text & Chr(35)
        sqlstmnt = sqlstmnt & " and glpost = 'Y' order by vouch_num "


        sqlstmnt = "      DECLARE @VouchNum int DECLARE @VouchAMt numeric"
        sqlstmnt = sqlstmnt & "DECLARE VouchCursor CURSOR FOR SELECT     vouch_num, vouch_amt    FROM         voucher        WHERE     glpost = 'Y' AND vouch_line = 1"
        sqlstmnt = sqlstmnt & "      OPEN(VouchCursor)"
        sqlstmnt = sqlstmnt & "FETCH next FROM         vouchcursor INTO            @vouchnum, @VouchAmt"
        sqlstmnt = sqlstmnt & "WHILE @@fetch_status = 0"
        sqlstmnt = sqlstmnt & "          BEGIN()"
        sqlstmnt = sqlstmnt & "IF"
        sqlstmnt = sqlstmnt & "                        (SELECT     sum(net_amt)"
        sqlstmnt = sqlstmnt & "             FROM(payment)"
        sqlstmnt = sqlstmnt & "                         WHERE      vouch_num = @vouchnum) = @vouchamt BEGIN"
        sqlstmnt = sqlstmnt & "            Update(voucher)"
        sqlstmnt = sqlstmnt & "                        SET              paid = 'Y' , dflag = 'Y'"
        sqlstmnt = sqlstmnt & "                       WHERE     vouch_num = @vouchnum"
        sqlstmnt = sqlstmnt & "           Update(payment)"
        sqlstmnt = sqlstmnt & "                                                   SET              dflag = 'Y'"
        sqlstmnt = sqlstmnt & "                                                WHERE     vouch_num = @vouchnum "
        sqlstmnt = sqlstmnt & "          End"
        sqlstmnt = sqlstmnt & "FETCH next FROM       vouchcursor INTO            @vouchnum, @VouchAmt"
        sqlstmnt = sqlstmnt & "               End"
        sqlstmnt = sqlstmnt & "             Close(vouchcursor)"
        sqlstmnt = sqlstmnt & "            DEALLOCATE(vouchcursor)"

        ETSSQL.ExecuteSQL(sqlstmnt)
        MsgBox("Records have been marked for deletion")

    End Sub

    Private Sub RptVouchDel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RptVouchDel.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "apvch_del.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub RepPmtDel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RptPmtDel.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "appay_del.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub apvchdel_frm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        If singl <> "FRTKNX" & Month(Now) Then
            singl = "N"
            MsgBox("Invalid Password")
            Me.Close()
            End
            Exit Sub
        End If

    End Sub

    Private Sub MovetoHistory_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MovetoHistory.Click

        MsgBox("Now Moving Data to Vchhist and Pmthist")
        'insert into history
        sqlstmnt = "Insert into vchhist from voucher where dflag = 'Y' "
        ETSSQL.ExecuteSQL(sqlstmnt)
        'insert into history
        sqlstmnt = "Insert into pmthist from payment where dflag = 'Y' "
        ETSSQL.ExecuteSQL(sqlstmnt)
        MsgBox("Data moved to Vchhist and Pmthist .")
    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = txtFields(0).Text
            If etsdate(senddate, "") = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                txtFields(0).Text = etsdate(senddate, "")
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

    Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

End Class