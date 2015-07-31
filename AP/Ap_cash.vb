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

Public Class ap_cash
    Inherits System.Windows.Forms.Form

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVerify.Click
        cmdCalBal.Focus()
    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click
        prtDestination = 0
        prtreportfilename = ar_report_path & "cash_bal.rpt"
        CrystalForm.ShowDialog()
    End Sub
    Private Sub Command3_Click()
        prtDestination = 1
        prtreportfilename = ap_report_path & "appyjrnl.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub CmdCalBal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCalBal.Click

        'running balance of dollars in each cash account used in AP or AR.
        'used je_tmp in AP.mdb

        '1 clean je_tmp first

        '2 this takes cr_acct_nu from payment and moves it to je_tmp
        '3 get the correct record from chacct for cur_ytd for payment bank

        '4 this takes dr_acct_nu from cash and moves it to je_tmp
        '5 get the correct record from chacct for cur_ytd for cash bank

        '6 get the correct records from cash_tmp1
        '7 Select any GJ's not posted for 1007-00-00


        '1 this cleans the je_tmp table in AP
        'je_tmp.Refresh()
        'If je_tmp.Recordset.RecordCount <> 0 Then
        '	je_tmp.Recordset.MoveFirst()
        '	Do While Not je_tmp.Recordset.EOF
        '		je_tmp.Recordset.delete()
        '		je_tmp.Recordset.MoveNext()
        '	Loop 
        'End If

        ''2 move the payment records to je tmp

        'sqlstmt = "select * from payment WHERE payment.glpost <> 'Y' and payment.dflag = 'N' and payment.void_chk = 'N'"
        'sqlstmt = "select * from payment WHERE payment.dflag = 'N' and payment.void_chk = 'N'"
        'sqlstmt = sqlstmt & " and payment.encum_date between "
        'sqlstmt = sqlstmt & Chr(35) & txtfields(0).Text & Chr(35) & " and "
        'sqlstmt = sqlstmt & Chr(35) & txtfields(1).Text & Chr(35) & " order by payment.cr_acct_nu "

        'payment.recordsource = sqlstmt
        'payment.Refresh()
        'payment.Recordset.MoveFirst()
        'If Err.Number = 3021 Then
        '  MsgBox("All Payment records for these dates have been posted to General Ledger, will now look at cash records.")
        ' Response = 1
        ''  GoTo sect4 '10/07/2009 for berk
        'Screen.MousePointer = 0
        'Exit Sub
        '	End If
        ' On Error GoTo 0

        'Do While Not payment.Recordset.EOF
        '    je_tmp.Recordset.AddNew()
        '    je_tmp.Recordset.Fields("acct_num").Value = payment.Recordset.Fields("cr_acct_nu").Value
        '    je_tmp.Recordset.Fields("dol_amt").Value = payment.Recordset.Fields("net_amt").Value * -1
        '    je_tmp.Recordset.Fields("inv_num").Value = payment.Recordset.Fields("chk_num").Value
        '    je_tmp.Recordset.Fields("line_num").Value = 1
        '    je_tmp.Recordset.Fields("inv_date").Value = payment.Recordset.Fields("dt_paid").Value
        '    je_tmp.Recordset.Fields("end_date").Value = txtfields(1).Text
        '    je_tmp.Recordset.Fields("type").Value = "P" 'payments
        '    je_tmp.Recordset.update()
        '    p_saved_acct_num = payment.Recordset.Fields("cr_acct_nu").Value
        '    payment.Recordset.MoveNext()
        'Loop
        '3 get the corresponding record from chacct for payments
        'select the record from chacct = to payment cr_acct_nu(bank)
        '        sqlstmt = "select * from chacct WHERE acct_num = " & Chr(34) & p_saved_acct_num & Chr(34)
        '        chacct.recordsource = sqlstmt
        '        chacct.Refresh()
        '        je_tmp.Recordset.AddNew()
        '        je_tmp.Recordset.Fields("acct_num").Value = chacct.Recordset.Fields("acct_num").Value
        '        je_tmp.Recordset.Fields("dol_amt").Value = chacct.Recordset.Fields("cur_ytd").Value
        '        je_tmp.Recordset.Fields("inv_num").Value = 99999
        '        je_tmp.Recordset.Fields("line_num").Value = 1
        '        je_tmp.Recordset.Fields("inv_date").Value = txtfields(0).Text
        '        je_tmp.Recordset.Fields("end_date").Value = txtfields(1).Text
        '        je_tmp.Recordset.Fields("type").Value = "B" 'Bank
        '        je_tmp.Recordset.update()
        'sect4:
        '        '4 cash data control on form   move the cash records
        '        'sqlstmt = "select * from cash WHERE cash.glpost <> 'Y' and cash.dflag = 'N' and cash.void_chk = 'N' "
        '        sqlstmt = "select * from cash WHERE cash.dflag = 'N' and cash.void_chk = 'N' "
        '        sqlstmt = sqlstmt & " and cash.encum_date between "
        '        sqlstmt = sqlstmt & Chr(35) & txtfields(0).Text & Chr(35) & " and "
        '        sqlstmt = sqlstmt & Chr(35) & txtfields(1).Text & Chr(35) & " order by cash.dr_acct_nu "
        '        cash.recordsource = sqlstmt
        '        cash.Refresh()
        '        If Err.Number = 3021 Then
        '            MsgBox("All Cash records for these dates have been posted to General Ledger, will now look at cash_tmp1 records. ")
        '            Response = 1
        '            GoTo sec6 'added 10/07/2009 for bcarc
        '            'Screen.MousePointer = 0
        '            'Exit Sub
        '        End If
        '        Do While Not cash.Recordset.EOF
        '            je_tmp.Recordset.AddNew()
        '            je_tmp.Recordset.Fields("acct_num").Value = cash.Recordset.Fields("dr_acct_nu").Value
        '            je_tmp.Recordset.Fields("dol_amt").Value = cash.Recordset.Fields("chk_alloc").Value - cash.Recordset.Fields("chk_disc").Value
        '            je_tmp.Recordset.Fields("inv_num").Value = cash.Recordset.Fields("inv_num").Value
        '            je_tmp.Recordset.Fields("line_num").Value = 1
        '            je_tmp.Recordset.Fields("inv_date").Value = cash.Recordset.Fields("encum_date").Value
        '            je_tmp.Recordset.Fields("end_date").Value = txtfields(1).Text
        '            je_tmp.Recordset.Fields("type").Value = "C" 'Cash
        '            je_tmp.Recordset.update()
        '            c_saved_acct_num = cash.Recordset.Fields("dr_acct_nu").Value
        '            cash.Recordset.MoveNext()
        '        Loop
        '        '5 select the record from chacct = to cash dr_acct_nu(bank) if not same as pmt acct
        '        If Trim(p_saved_acct_num) <> Trim(c_saved_acct_num) Then
        '            sqlstmt = "select * from chacct WHERE acct_num = " & Chr(34) & Trim(c_saved_acct_num) & Chr(34)
        '            chacct.recordsource = sqlstmt
        '            chacct.Refresh()
        '            je_tmp.Recordset.AddNew()
        '            je_tmp.Recordset.Fields("acct_num").Value = chacct.Recordset.Fields("acct_num").Value
        '            je_tmp.Recordset.Fields("dol_amt").Value = chacct.Recordset.Fields("cur_ytd").Value
        '            je_tmp.Recordset.Fields("inv_num").Value = 88888
        '            je_tmp.Recordset.Fields("line_num").Value = 2
        '            je_tmp.Recordset.Fields("inv_date").Value = txtfields(0).Text
        '            je_tmp.Recordset.Fields("end_date").Value = txtfields(1).Text
        '            je_tmp.Recordset.Fields("type").Value = "C"
        '            je_tmp.Recordset.update()

        '        End If
        'sec6:
        '        '6 cash_tmp1 data control on form   move the cash records
        '        'sqlstmt = "select * from cash WHERE cash.glpost <> 'Y' and cash.dflag = 'N' and cash.void_chk = 'N' "
        '        sqlstmt = "select * from cash_tmp1 WHERE cash_tmp1.dflag = 'N' and cash_tmp1.void_chk = 'N' "
        '        sqlstmt = sqlstmt & " and cash_tmp1.encum_date between "
        '        sqlstmt = sqlstmt & Chr(35) & txtfields(0).Text & Chr(35) & " and "
        '        sqlstmt = sqlstmt & Chr(35) & txtfields(1).Text & Chr(35) & " order by cash_tmp1.dr_acct_nu "
        '        cash_tmp1.recordsource = sqlstmt
        '        cash_tmp1.Refresh()
        '        cash_tmp1.Recordset.MoveFirst()
        '        If Err.Number = 3021 Then
        '            MsgBox("All Cash records for these dates have been posted to General Ledger, will now look at GJ records.")
        '            Response = 1
        '            GoTo sec7
        '            'Screen.MousePointer = 0
        '            'Exit Sub
        '        End If
        '        Do While Not cash_tmp1.Recordset.EOF
        '            je_tmp.Recordset.AddNew()
        '            je_tmp.Recordset.Fields("acct_num").Value = cash_tmp1.Recordset.Fields("dr_acct_nu").Value
        '            je_tmp.Recordset.Fields("dol_amt").Value = cash_tmp1.Recordset.Fields("chk_alloc").Value - cash_tmp1.Recordset.Fields("chk_disc").Value
        '            je_tmp.Recordset.Fields("inv_num").Value = cash_tmp1.Recordset.Fields("inv_num").Value
        '            je_tmp.Recordset.Fields("line_num").Value = 1
        '            je_tmp.Recordset.Fields("inv_date").Value = cash_tmp1.Recordset.Fields("encum_date").Value
        '            je_tmp.Recordset.Fields("end_date").Value = txtfields(1).Text
        '            je_tmp.Recordset.Fields("type").Value = "D" 'cash_tmp1
        '            je_tmp.Recordset.update()
        '            c_saved_acct_num = cash_tmp1.Recordset.Fields("dr_acct_nu").Value
        '            cash_tmp1.Recordset.MoveNext()
        '        Loop
        '        '6 select the record from chacct = to cash_tmp1 dr_acct_nu(bank) if not same as pmt acct
        '        If Trim(p_saved_acct_num) <> Trim(c_saved_acct_num) Then
        '            sqlstmt = "select * from chacct WHERE acct_num = " & Chr(34) & Trim(c_saved_acct_num) & Chr(34)
        '            chacct.recordsource = sqlstmt
        '            chacct.Refresh()
        '            je_tmp.Recordset.AddNew()
        '            je_tmp.Recordset.Fields("acct_num").Value = chacct.Recordset.Fields("acct_num").Value
        '            je_tmp.Recordset.Fields("dol_amt").Value = chacct.Recordset.Fields("cur_ytd").Value
        '            je_tmp.Recordset.Fields("inv_num").Value = 88888
        '            je_tmp.Recordset.Fields("line_num").Value = 2
        '            je_tmp.Recordset.Fields("inv_date").Value = txtfields(0).Text
        '            je_tmp.Recordset.Fields("end_date").Value = txtfields(1).Text
        '            je_tmp.Recordset.Fields("type").Value = "D"
        '            je_tmp.Recordset.update()
        '        End If
        'sec7:
        '        '7 Select unposted GJ's for acct 1007-00-00
        '        sqlstmt = "select * from yrgenled WHERE yrgenled.dflag = 'N' and yrgenled.void = 'N' and yrgenled.post = 'N'"
        '        sqlstmt = sqlstmt & " and yrgenled.a_post = 'N' and yrgenled.acct_num = '1007-00-00'"
        '        sqlstmt = sqlstmt & " and yrgenled.encum_date between "
        '        sqlstmt = sqlstmt & Chr(35) & txtfields(0).Text & Chr(35) & " and "
        '        sqlstmt = sqlstmt & Chr(35) & txtfields(1).Text & Chr(35) & " order by yrgenled.encum_date "
        '        yrgenled.recordsource = sqlstmt
        '        yrgenled.Refresh()
        '        yrgenled.Recordset.MoveFirst()
        '        If Err.Number = 3021 Then
        '            MsgBox("All GJ records for these dates have been posted to General Ledger")
        '            Response = 1
        '            GoTo sec9
        '            'Screen.MousePointer = 0
        '            'Exit Sub
        '        End If
        '        Do While Not yrgenled.Recordset.EOF
        '            je_tmp.Recordset.AddNew()
        '            je_tmp.Recordset.Fields("acct_num").Value = yrgenled.Recordset.Fields("acct_num").Value
        '            je_tmp.Recordset.Fields("dol_amt").Value = yrgenled.Recordset.Fields("amount").Value
        '            je_tmp.Recordset.Fields("inv_num").Value = yrgenled.Recordset.Fields("jrnl_num").Value
        '            je_tmp.Recordset.Fields("line_num").Value = yrgenled.Recordset.Fields("jrnl_line").Value
        '            je_tmp.Recordset.Fields("inv_date").Value = yrgenled.Recordset.Fields("encum_date").Value
        '            je_tmp.Recordset.Fields("end_date").Value = txtfields(1).Text
        '            je_tmp.Recordset.Fields("type").Value = "G" 'GJ
        '            je_tmp.Recordset.update()
        '            c_saved_acct_num = yrgenled.Recordset.Fields("acct_num").Value
        '            yrgenled.Recordset.MoveNext()
        '        Loop
        cmdPrint.Focus()

        'sec9:

        MsgBox("You can now print the Cash Balance Report. Some records might not have been selected.")
    End Sub

    Private Sub ap_cash_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Form.ActiveForm.ActiveControl.BackColor = Color.Aqua '(RGB(0, 255, 255))
    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            valid_Date = "N"
            senddate = etsdate(txtfields(CShort(Index)).Text, valid_Date)
            If senddate = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                txtfields(Index).Text = CDate(senddate).ToShortDateString
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

    Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub
End Class