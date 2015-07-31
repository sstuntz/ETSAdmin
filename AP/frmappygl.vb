Option Strict Off
Option Explicit On

Imports VB = Microsoft.VisualBasic
Imports ETS.Common.Module1
Imports PS.Common
Imports ETS

Public Class frmappygl

    Inherits System.Windows.Forms.Form
    Public VoucherJE As New List(Of JeData)
    Public DRAcctTot As New List(Of AcctNums)
    Public CRAcctTot As New List(Of AcctNums)
    Public JeRowData As New List(Of JeData)

    Private Sub cmdupdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        CmdPrepareJE.Focus() ' -do the work
    End Sub

    Private Sub cmdPost_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdPost.Click
        '7a update glpost and put je num in each voucher in set
        'some of the dim stmts were changed to public and are in the declarations
        '7a  update glpost flag and put je num in each voucher record

        Dim JrnlNum As Integer
        JrnlNum = GLMod.GetNextJENum("regular")
        sqlstmnt = "insert into yrgenled values ('"
        Call GLMod.SQLJEDataString(sqlstmnt, JeRowData)
        ETSSQL.ExecuteSQL(sqlstmnt)
        ''7a  update glpost flag and put je num in each payment record

        sqlstmnt = "update payment set glpost = 'Y' , jrnl_num = '" & JrnlNum & "' where payment.glpost = 'N' and payment.dflag = 'N' and payment.void = 'N'"
        sqlstmnt = sqlstmnt & " and payment.encum_date between "
        sqlstmnt = sqlstmnt & Chr(35) & txtField0(0).Text & Chr(35) & " and "
        sqlstmnt = sqlstmnt & Chr(35) & txtField1(1).Text & Chr(35) & "  "

        MsgBox("J/E Complete!!! Print the J/E now.")

        MsgBox("Note the number assigned to this Journal Entry:" & JrnlNum)
        Command2.Focus() 'added 5/15/00 lhw
        CmdPost.Enabled = False
        MsgBox("J/E Complete!!! Print the J/E now.")

    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        prtDestination = CStr(0)
        prtreportfilename = ar_report_path & "apjetmpp.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        prtDestination = CStr(1)
        prtreportfilename = ap_report_path & "appyjrnl.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub CmdPrepareJE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdPrepareJE.Click

        ' 1 select into list of acct nums for dr and cr 
        ' 2 check acct nums
        ' 3 check bal
        ' 4 get next je number
        ' 5 prepare je



        sqlstmnt = "SELECT dr_acct_nu as AcctNum, SUM(chk_alloc) AS acct_1"
        sqlstmnt = sqlstmnt & " FROM payment where (glpost = 'N') AND (dflag = 'N') AND (void = 'N') AND (encum_date between '"
        sqlstmnt = sqlstmnt & txtField0(0).Text & "' and '" & txtField1(1).Text & " ')"
        sqlstmnt = sqlstmnt & " GROUP BY dr_acct_nu"

        DRAcctTot = ETSSQL.GetTotalAcct(sqlstmnt)

        If DRAcctTot.Count = 0 Then
            MsgBox("All records for these dates have been posted to General Ledger")
            Exit Sub
        End If
        '2 this takes dr_acct_nu from voucher and moves it to jerowdata

        For Each acctnum In DRAcctTot
            Dim ds As New JeData
            ds.AcctNum = acctnum.AcctNum
            ds.Amount = acctnum.acct_1
            JeRowData.Add(ds)
        Next

        '3 this takes cr_acct_nu from voucher and moves it to je_tmp
        sqlstmnt = "SELECT cr_acct_nu as AcctNum, SUM(alloc_amt) AS acct_1"
        sqlstmnt = sqlstmnt & " FROM payment where (glpost = 'N') AND (dflag = 'N') AND (void = 'N') AND (encum_date between '"
        sqlstmnt = sqlstmnt & txtField0(0).Text & "' and '" & txtField1(1).Text & " ')"
        sqlstmnt = sqlstmnt & " GROUP BY cr_acct_nu"

        DRAcctTot = ETSSQL.GetTotalAcct(sqlstmnt)

        For Each acctnum In DRAcctTot
            Dim ds As New JeData
            ds.AcctNum = acctnum.AcctNum
            ds.Amount = acctnum.acct_1 * -1
            JeRowData.Add(ds)
        Next
        'we now have a temp JE to be tested  - if OK fill je num and other stuff
        '4 test for total = 0 and valid account numbers
        Dim total_amt As Double = 0
        For Each JeRow In JeRowData
            total_amt = CDec(total_amt + JeRow.Amount)
        Next
        If total_amt <> 0 Then
            MsgBox("The JE will not be posted. It is out of balance.")
            MsgBox("You are about to print a detail report to help you find missing data")
            prtDestination = 0
            prtreportfilename = ar_report_path & "apjetmpv.rpt"
            CrystalForm.ShowDialog()
            Exit Sub
        End If

        For Each JeRow In JeRowData
            If etsacctnum_chk(JeRow.AcctNum) = "N" Then
                MsgBox("There is an invalid account.")
                MsgBox("You are about to print a detail report to help you find missing data")
                prtDestination = 0
                prtreportfilename = ar_report_path & "apjetmpv.rpt"
                CrystalForm.ShowDialog()
                Exit Sub
            End If
        Next
        'fill the JE data here so have a real JE 
        Dim JeNum As Integer = GLMod.GetNextJENum("regular")
        MsgBox("Note the number assigned to this Journal Entry:" & JeNum)
        Dim n As Integer = 0
        For Each JeRow In JeRowData
            JeRow.JrnlNum = JeNum
            JeRow.JrnlLineNum = n + 1
            JeRow.EntryType = "SD"
            JeRow.JrnlName = "AP"
            JeRow.JrnlSrc = "VCH"
            JeRow.JrnlDesc = "AP Vouch"
            JeRow.OperId = "Auto"
            JeRow.EncumDate = txtField1(1).Text
        Next

    End Sub

    Private Sub frmappygl_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

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