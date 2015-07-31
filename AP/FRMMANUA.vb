Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETS.Common.Module1
Imports PS.Common
Imports Microsoft.VisualBasic.ErrObject
Imports System.Data.SqlClient
Imports System
Imports System.Configuration

Public Class frmmanual
    Inherits System.Windows.Forms.Form

    Public paid_amount As Decimal
    Public PaymentRowData As List(Of PaymentData)


    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click
        ' write out the payment
        ' Dim pmtentry As New PaymentData
        '  pmt.BankKey = bank_key.Text
        ' pmt.Agency = CStr(AgencyNum)
        ' pmt.ChkAlloc = 0
        For Each pmtentry In PaymentRowData
            sqlstmnt = "insert into payment " & pmtentry.PaymentColumnNames & "  values ('" & pmtentry.PaymentColumnData & ")"
            ETSSQL.ExecuteSQL(sqlstmnt)
        Next

        '    Data1.Recordset("chk_num") = chknum
        '     Data1.Recordset("vouch_num") = vouchnum
        '      Data1.Recordset("name_key") = voucherset.Fields("name_key").Value
        '    Data1.Recordset("dt_paid") = chkdate
        '    Data1.Recordset("chk_alloc") = chk_amt
        '    'fixed 11/21/05 lhw disc coming in null
        '    Data1.Recordset("chk_disc") = voucherset.Fields("disc_amt").Value
        '   ' Data1.Recordset("net_Amt") = Val(chk_amt) - Val(disc_amt)
        '    Data1.Recordset("net_Amt") = chk_amt - voucherset.Fields("disc_amt").Value
        '    Data1.Recordset("encum_date") = chkdate
        '    Data1.Recordset("entry_Date") = Date
        '    Data1.Recordset("screen_nam") = voucherset.Fields("screen_nam").Value
        '    Data1.Recordset("bank_key") = voucherset.Fields("bank_key").Value
        '
        '    Data1.Recordset("dr_acct_nu") = voucherset.Fields("cr_acct_nu") 'control
        '    Data1.Recordset("cr_Acct_nu") = bank_dr_acct_nu   'bank_nameget on form
        '    Call vend_nameget(voucherset.Fields("name_key"))
        '    Data1.Recordset("disc_Acct") = vend_disc_Acct
        '    Data1.Recordset.Update
        '
        '     If Text2 = chk_amt Then
        '    selected_voucher = vouchnum
        '    Call update_paid_flag

        vouchnum.Focus()

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub chk_amt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chk_amt.Enter
        Call ets_set_selected()
        chk_amt.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        chk_amt.SelectAll()

    End Sub

    Private Sub chk_amt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles chk_amt.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            chk_amt.Text = TestText(chk_amt.Text, 0)
            If chk_amt.Text = "NotNumeric" Then
                MsgBox("Please enter a number")
                chk_amt.Text = ""
                Exit Sub
            End If
            If CDbl(chk_amt.Text) > (CDbl(Text2.Text) - paid_amount) Then
                MsgBox("This is overpaying the amount due. Please re-enter the amount.")
                Call ets_set_selected()
                Exit Sub
            End If

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0

        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub chk_amt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chk_amt.Leave
        Call ets_de_selected()
        chk_amt.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub chkdate_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkdate.Enter
        Call ets_set_selected()
    End Sub

    Private Sub chkdate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles chkdate.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))

        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = chkdate.Text
            If etsdate(senddate, "") = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                chkdate.Text = Format(etsdate(senddate, valid_Date), "short date")
                If DateDiff("d", Today, chkdate.Text) > 30 Then
                    MsgBox("Date is more than 30 days from Today. Use the mouse to re-enter if wrong'")
                End If
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
                sqlstmnt = "update rpthead set beg_date = " & chkdate.Text
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If

        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub chkdate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkdate.Leave
        Call ets_de_selected()
        chkdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub chknum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chknum.Enter
        Call ets_set_selected()
        chknum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        chknum.SelectAll()
    End Sub

    Private Sub chknum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles chknum.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))

        If KeyAscii = 13 Or KeyAscii = 9 Then
            Dim valid_Check As String = ValidateDatumYN("payment", "chk_num", chknum.Text)
            If valid_Check = "Y" Then
                Response = MsgBox("This check number has been used. If paying another voucher on this check please select Yes.", vbYesNo)
                If Response = 7 Then
                    Call ets_set_selected()
                    chknum.SelectAll()
                    Exit Sub
                End If
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

    Private Sub chknum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chknum.Leave
        Call ets_de_selected()
        chknum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Edit.Click
        vouchnum.Focus()
        vouchnum.SelectAll()
    End Sub

    Private Sub frmmanual_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        PaymentRowData = ETSSQL.GetBlankPaymentData

    End Sub

    Private Sub prtreg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prtreg.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub vouchnum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vouchnum.Enter
        Call ets_set_selected()
        vouchnum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        vouchnum.SelectAll()
    End Sub

    Private Sub vouchnum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles vouchnum.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        'chech for valid voucher number
        'display vendor name and amount

        If KeyAscii = 13 Or KeyAscii = 9 Then

            If Len(vouchnum.Text) = 0 Then
                MsgBox("Please enter a number")
                GoTo EventExitSub
            End If

            Dim VouchData As New List(Of VoucherData)
            sqlstmnt = "select * from voucher where vouch_num = " & vouchnum.Text
            VouchData = ETSSQL.GetVoucherData(sqlstmnt)
            If VouchData.Count = 0 Then
                MsgBox("No such Voucher")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            For Each vouch In VouchData
                If vouch.dflag = "Y" Then
                    MsgBox("Voucher previously deleted")
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If
                If vouch.Paid = "Y" Then
                    MsgBox("Voucher already paid")
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If

                Text1.Text = vouch.ScreenNam
                bank_key.Text = vouch.BankKey
                Call bank_nameget(vouch.BankKey)
                bank_name.Text = bank_screen_nam

                'check for any payments and if any put into the balance due text box
                'record addnew will be done when accept is clcked

                sqlstmnt = "select * from payment where void = 'N' and dflag = 'N' and vouch_num = " & vouchnum.Text
                Dim Tot As Double = ETSSQL.GetTotalPayments(sqlstmnt)

                If Tot = 0 Then
                    Text2.Text = String.Format("{0:c}", vouch.VouchAmt)

                Else
                    Text2.Text = String.Format("{0:c}", vouch.VouchAmt - Tot)
                End If
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
            Next
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub vouchnum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vouchnum.Leave
        Call ets_de_selected()
        vouchnum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

End Class