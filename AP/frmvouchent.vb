Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Imports ETS.Common.Module1
Imports PS.Common
Imports System.String
Imports ETS.ApMod

Public Class frmvouchent
    Inherits System.Windows.Forms.Form


    Dim invoice_left_to_enter As Decimal
    Dim batch_Amount As Decimal
    Dim voucher_array() As Object
    Dim batch_Total_amt As Decimal
    Dim vouch_Done As Integer
    Dim vouchtotaldetail As Object
    Public miss As String
    Public add_sub As Integer
    Public wline As Integer
    Public oldfocus As Integer
    Public flag_set As Integer
    Dim temp_array(50, 2) As String
    Dim max_grid_line As Short
    Dim BankKey As String
    Dim total_amt As Double
    Public VoucherRowData As List(Of VoucherData)
    Public VoucherLookupNum As Integer
    Public VoucherSource As String
    Public AllocSplit As String()


    Private Sub enterheader()
        If entry_type = "ADD" Or entry_type = "AddRECURRING" Then
            Me.chknum.Enabled = True
            Me.chkdate.Enabled = True
        Else
            Me.chknum.Enabled = False
            Me.chkdate.Enabled = False
            If entry_type <> "ProcessRecurring" Then
                Me.vouchnum.Text = VoucherRowData.Item(0).VouchNum.ToString

            End If
            Me.ent_Date.Text = VoucherRowData.Item(0).EntryDate.ToShortDateString
            Me.invdate.Text = VoucherRowData.Item(0).VendInvDate.ToShortDateString
            Me.encdate.Text = VoucherRowData.Item(0).EncumDate.ToShortDateString
            Me.vendInvNum.Text = VoucherRowData.Item(0).VendInv.ToString
            Me.VendInvAmt.Text = FormatNumber(VoucherRowData.Item(0).VouchAmt.ToString, 2)
            Me.VendDiscAmt.Text = VoucherRowData.Item(0).DiscAmt.ToString
            Me.vendInvNum.Text = VoucherRowData.Item(0).VendInv.ToString
            Me.vend_num.Text = VoucherRowData.Item(0).NameKey.ToString
            Me.bankname.SelectedItem = VoucherRowData.Item(0).BankKey.ToString
            Me.vendname.Text = ETSSQL.GetContactData(Me.vend_num.Text, "nam_vend").Item(0).ScreenName
            Me.duedate.Text = VoucherRowData.Item(0).DtTBePaid
        End If
    End Sub

    Private Sub FillHeader()
        VoucherRowData.Item(0).BankKey = bankname.SelectedValue
        VoucherRowData.Item(0).Agency = AgencyNum.ToString
        ' VoucherRowData.Item(0).BPostDate = ""
        VoucherRowData.Item(0).VouchNum = Val(vouchnum.Text)
        VoucherRowData.Item(0).NameKey = vend_num.Text
        VoucherRowData.Item(0).VendInv = vendInvNum.Text
        VoucherRowData.Item(0).VendInvDate = invdate.Text
        VoucherRowData.Item(0).EncumDate = CDate(encdate.Text)
        VoucherRowData.Item(0).DtTBePaid = CDate(duedate.Text)

    End Sub

    Private Sub acct_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles acct_num.Enter
        Dim Index As Short = acct_num.GetIndex(eventSender)
        acct_num(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        acct_num(Index).SelectionStart = 8
        acct_num(Index).SelectionLength = 2 'Len(acct_num(Index).Text)
        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            reimb(max_grid_line - 1).Focus()
            Exit Sub
        End If
    End Sub

    Private Sub acct_num_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles acct_num.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = acct_num.GetIndex(eventSender)
        Select Case KeyCode
            Case CShort(System.Windows.Forms.Keys.F3) 'duplicate line
                'can only be done on a blank line
                If acct_num(Index).Text <> acct_num_blank Then
                    MsgBox("Please Insert a blank line first")
                    Exit Sub
                End If
                If Index <> 0 Then
                    acct_num(Index).Text = acct_num(CShort(Index - 1)).Text
                    acct_desc(Index).Text = acct_desc(CShort(Index - 1)).Text
                    valid_acct = "N"
                    retacct = etsacctnum_chk(acct_num(Index).Text)
                    If retacct = acct_num_blank Then Exit Sub
                    If retacct <> "N" Then
                        acct_num(Index).Text = retacct
                        acct_desc(Index).Text = ETSSQL.GetAcctDesc(retacct)
                        VoucherRowData.Item(CInt(V_line(Index).Text) - 1).DRAcctNum = retacct
                        VoucherRowData.Item(CInt(V_line(Index).Text) - 1).AcctDesc = acct_desc(Index).Text
                        VoucherRowData.Item(CInt(V_line(Index).Text) - 1).VouchLine = CInt(V_line(Index).Text)
                        VoucherRowData.Item(CInt(V_line(Index).Text) - 1).Memo = vouch_desc(CShort(Index - 1)).Text
                    Else
                        MsgBox("Invalid acct number - Please re-enter")
                        Form.ActiveForm.ActiveControl.BackColor = Color.Aqua()
                        Exit Sub
                    End If

                    amt(CShort(Index - 1)).Focus()
                    KeyAscii = 0
                End If
                Call repaint_grid(CShort(V_line(0).Text))
            Case CShort(System.Windows.Forms.Keys.F5)  'delete line
                msg = "Do you wish to delete this line?"
                Response = MsgBox(msg, MsgBoxStyle.YesNo)
                If Response = MsgBoxResult.No Then Exit Sub
                VoucherRowData.RemoveAt(CInt(V_line(Index).Text) - 1)
                Call repaint_grid(CShort(V_line(0).Text))
                Call tot_amt()
            Case CShort(System.Windows.Forms.Keys.F6)  'insert line
                If Index = 0 Then Exit Sub
                msg = "Do you wish to insert a line before this line?"
                Response = MsgBox(msg, MsgBoxStyle.YesNo)
                If Response = MsgBoxResult.No Then Exit Sub
                Dim emptyrow As New VoucherData
                VoucherRowData.Insert(CInt(V_line(Index).Text), emptyrow) 'VoucherRowData.Item(CInt(jrnl_num.Text)))
                'renumber other lines
                Call repaint_grid(CShort(V_line(0).Text))
                'For Each VoucherRow In VoucherRowData
                '    VoucherRow.JrnlLineNum = 
                'Next
                Call repaint_grid(CShort(V_line(0).Text))
        End Select

        'Select Case KeyCode
        '          Case System.Windows.Forms.Keys.F3

        '              If Index <> 0 Then
        '                  acct_num(Index).Text = acct_num(Index - 1).Text
        '                  System.Windows.Forms.SendKeys.Send("{ENTER}")
        '              End If
        '	Case System.Windows.Forms.Keys.F5
        '		'delete a line
        '		If CDbl(V_line(Index).Text) > max_grid_line Then
        '			MsgBox("Line not yet entered, so it can not be deleted.")
        '			Exit Sub
        '		End If
        '              If MsgBoxResult.No Then Exit Sub
        '		add_sub = -1
        '		Call grid_change(add_sub, V_line(Index), Index)
        '          Case System.Windows.Forms.Keys.F6
        '              'insert a line
        '              If CDbl(V_line(Index).Text) > max_grid_line Then
        '                  MsgBox("This is the last line. No need to add a line.")
        '                  Exit Sub
        '              End If
        '              If MsgBox("Do you wish to insert a line before this line?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        '              add_sub = 1
        '              Call grid_change(add_sub, V_line(Index), Index)
        '      End Select

    End Sub

    Private Sub acct_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles acct_num.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = acct_num.GetIndex(eventSender)

        If KeyAscii = 13 Or KeyAscii = 9 Then
            acct_num(Index).SelectionStart = 0 'to make sure field is cleared
            function_type = "LOOKUP_ONLY"
            Dim acctnum As String
            acctnum = etsacctnum_chk(acct_num(Index).Text)

            If acctnum.Substring(0, 1) = "N" Then
                MsgBox("This account does not exist.")
                acct_num(Index).SelectAll()
                Exit Sub
            End If
            Dim anums = acctnum.Split(CChar("**"))
            acct_num(Index).Text = anums(0)
            acct_desc(Index).Text = anums(2)

            VoucherRowData.Item(Index + offset_grid_line).DRAcctNum = anums(0)   'acct_num(Index).Text
            VoucherRowData.Item(Index + offset_grid_line).AcctDesc = anums(2) 'acct_desc(Index).Text
            VoucherRowData.Item(Index + offset_grid_line).JrnlLineNum = V_line(Index).Text
            If retacct = acct_num_blank Then GoTo EventExitSub
            vouch_desc(Index).Focus()
            KeyAscii = 0
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub acct_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles acct_num.Leave
        Dim Index As Short = acct_num.GetIndex(eventSender)
        acct_num(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub amt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles amt.Enter
        Dim Index As Short = amt.GetIndex(eventSender)
        amt(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        If Len(amt(Index).Text) <> 0 Then
            amt(Index).SelectionStart = 0
            amt(Index).SelectionLength = Len(amt(Index).Text)
            invoice_left_to_enter = invoice_left_to_enter + CDbl(amt(Index).Text)

        End If

        'checks to make sure not below lines allready entered

        If Index > max_grid_line Then
            reimb(max_grid_line - 1).Focus()
            Exit Sub
        End If


    End Sub

    Private Sub amt_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles amt.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = amt.GetIndex(eventSender)
        Select Case KeyCode

            Case System.Windows.Forms.Keys.F3

                If Index <> 0 Then
                    amt(Index).Text = amt(Index - 1).Text
                    System.Windows.Forms.SendKeys.Send("{ENTER}")
                End If
        End Select

    End Sub

    Private Sub amt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles amt.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = amt.GetIndex(eventSender)

        If KeyAscii = 13 Or KeyAscii = 9 Then 'lhw98
            amt(Index).Text = TestText(amt(Index).Text, 0)
            If amt(Index).Text = "NotNumeric" Then
                MsgBox("Please enter a number")
                amt(Index).Text = ""
                Exit Sub
            End If

            If entry_type <> "EDIT" Then        'since all the lines add up.

                If invoice_left_to_enter - CDbl(amt(Index).Text) < 0 Then
                    Response = MsgBox("Exceeded invoice total -- Do you wish to Edit amount", 4)
                    If Response = 6 Then
                        amt(Index).SelectionStart = 0
                        amt(Index).SelectionLength = Len(amt(Index).Text)
                        GoTo EventExitSub
                    End If
                End If
            End If

            VoucherRowData.Item(Index + offset_grid_line).AllocAmt = CDbl(amt(Index).Text)
            amt(Index).Text = FormatNumber(amt(Index).Text, 2, True, True, True)
            Call tot_amt()
            reimb(Index).Focus()
            KeyAscii = 0
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub amt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles amt.Leave
        Dim Index As Short = amt.GetIndex(eventSender)
        amt(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub bankname_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bankname.Enter
        bankname.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        If Len(bankname.Text) = 0 Then
            '     bankname.Text = bankname.Items(0)
        End If
        bankname.SelectionStart = 0
        bankname.SelectionLength = Len(bankname.Text)

    End Sub

    Private Sub bankname_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bankname.SelectedIndexChanged
        On Error Resume Next
        VoucherRowData.Item(0).BankKey = bankname.SelectedValue
    End Sub

    Private Sub bankname_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles bankname.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If (KeyAscii = 13 Or KeyAscii = 9) And bankname.SelectedText.ToString.Length = 0 Then
            MsgBox("Please enter a name or select from the list")
            bankname.Focus()
            GoTo EventExitSub
        End If

        BankKey = bankname.SelectedValue
        On Error Resume Next
        VoucherRowData.Item(0).BankKey = bankname.SelectedValue
        On Error GoTo 0

        If checkYN("nam_bank", "bank_key", BankKey) = "N" Then
            MsgBox(bankname.DisplayMember & " is an invalid bank.  Please select from the list")
            GoTo EventExitSub
        End If
ok1:

        KeyAscii = 0

        '		'this does the work of forcing the allocation of standard bills
        If entry_type = "ADD" Then
            If MsgBox("Do you wish to use a standard allocation?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = vbYes Then
                'create voucherrows and rebuild grid
                Dim apAllocLookup As New apAllocLookup
                Dim frmwhereclause As String = ""
                Dim linenum As Integer = 0
                apAllocLookup.ShowDialog()
                frmwhereclause = " where allocname = '" & selected_lookup_num & "'"
                Dim AllocData As List(Of String) = ETSSQL.GetAllocData("apalloc", frmwhereclause)
                Call FillHeader()
                Dim emptyrow As New VoucherData
                For Each alloc In AllocData
                    AllocSplit = alloc.Split(CChar("**"))
                    If linenum <> 0 Then VoucherRowData.Add(emptyrow)
                    VoucherRowData.Item(linenum).VouchLine = linenum + 1
                    VoucherRowData.Item(linenum).DRAcctNum = AllocSplit(0).ToString
                    VoucherRowData.Item(linenum).AcctDesc = ETSSQL.GetAcctDesc(AllocSplit(0).ToString)
                    VoucherRowData.Item(linenum).Memo = ""
                    VoucherRowData.Item(linenum).AllocAmt = CDbl(Val(AllocSplit(2)) * Val(VendInvAmt.Text))
                    VoucherRowData.Item(linenum).Reimb = "N"
                    linenum = linenum + 1
                Next
                Call repaint_grid(0)

            End If
        End If

        V_line(0).Focus()

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub bankname_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bankname.Leave
        bankname.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Public Sub Cancel_gotfocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.GotFocus
        vouchnum.Focus()
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        entry_type = "CANCEL"
        Call ClearVoucher()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub chkdate_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkdate.Enter
        chkdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        chkdate.SelectionStart = 0
        chkdate.SelectionLength = Len(chkdate.Text)

    End Sub

    Private Sub chkdate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles chkdate.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = chkdate.Text

            If etsdate(senddate, valid_Date) = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                chkdate.Text = Format(etsdate(senddate, valid_Date), "short date")
                VoucherRowData.Item(0).CheckDate = CDate(chkdate.Text)
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

    Private Sub chkdate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkdate.Leave
        chkdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub chknum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chknum.Enter
        chknum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        chknum.SelectionStart = 0
        chknum.SelectionLength = Len(chknum.Text)

    End Sub

    Private Sub chknum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles chknum.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Or KeyAscii = 9 Then

            If chknum.Text.Length = 0 Then
                chknum.Text = ""
                VoucherRowData.Item(0).CheckNum = ""
                vend_num.Focus()
                KeyAscii = 0
                GoTo EventExitSub
            End If

            'if one check pays 2 vouchers need to be able to enter ck# again
            '4/19/00 lhw  changed section below

            valid_check = "N"
            valid_check = ValidateDatumYN("payment", "chk_num", Val(chknum.Text))
            If valid_check = "N" Then
                Response = MsgBox("This check number has been used - Select Yes to Continue", MsgBoxStyle.YesNo)
                If Response = MsgBoxResult.Yes Then
                    VoucherRowData.Item(0).CheckNum = chknum.Text
                    System.Windows.Forms.SendKeys.Send("{tab}")
                    KeyAscii = 0
                Else
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If
            Else
                VoucherRowData.Item(0).CheckNum = chknum.Text
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

    Private Sub chknum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chknum.Leave
        chknum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub down_grid_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles down_grid.Click
        offset_grid_line = CShort(offset_grid_line - 1)
        If offset_grid_line < 0 Then offset_grid_line = 0
        Call repaint_grid(CShort(offset_grid_line))


        'wline = 0
        'If max_grid_line < 6 Then Exit Sub

        'offset_grid_line = offset_grid_line - 1
        'If offset_grid_line > (max_grid_line - 5) Then offset_grid_line = max_grid_line - 5
        'If offset_grid_line < 0 Then offset_grid_line = 0

    End Sub

    Private Sub duedate_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles duedate.Enter
        duedate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        duedate.SelectionStart = 0
        duedate.SelectionLength = Len(duedate.Text)

    End Sub

    Private Sub duedate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles duedate.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Or KeyAscii = 9 Then

            senddate = duedate.Text
            If etsdate(senddate, valid_Date) = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                duedate.Text = Format(etsdate(senddate, valid_Date), "short date")
                VoucherRowData.Item(0).DtTBePaid = CDate(duedate.Text)
                bankname.Focus()
            End If
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub duedate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles duedate.Leave
        duedate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub encdate_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles encdate.Enter
        encdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        encdate.SelectionStart = 0
        encdate.SelectionLength = Len(encdate.Text)

    End Sub

    Private Sub encdate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles encdate.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = encdate.Text
            If etsdate(senddate, valid_Date) = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                encdate.Text = Format(etsdate(senddate, valid_Date), "short date")
                VoucherRowData.Item(0).EncumDate = CDate(encdate.Text)
                duedate.Focus()
            End If
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub encdate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles encdate.Leave
        encdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub repaint_grid(ByVal offset_grid_line As Short)
        'the offset_grid_line number is the first line visible
        Dim linenum As Short
        If offset_grid_line < 0 Then offset_grid_line = 0
        If offset_grid_line > VoucherRowData.Count - 4 Then
            offset_grid_line = CShort(VoucherRowData.Count - 4)
            If offset_grid_line < 0 Then offset_grid_line = 0
            'Exit Sub
        End If
        On Error GoTo 0
        For linenum = 0 To 7
            On Error Resume Next
            V_line(linenum).Text = VoucherRowData.Item(linenum + offset_grid_line).VouchLine.ToString
            acct_num(linenum).Text = VoucherRowData.Item(linenum + offset_grid_line).DRAcctNum.ToString
            If IsNullOrEmpty(VoucherRowData.Item(linenum + offset_grid_line).AcctDesc) Then
                acct_desc(linenum).Text = ETSSQL.GetAcctDesc(VoucherRowData.Item(linenum + offset_grid_line).DRAcctNum.ToString)
            Else
                acct_desc(linenum).Text = VoucherRowData.Item(linenum + offset_grid_line).AcctDesc.ToString
            End If
            amt(linenum).Text = FormatNumber(VoucherRowData.Item(linenum + offset_grid_line).AllocAmt.ToString, 2)
            vouch_desc(linenum).Text = VoucherRowData.Item(linenum + offset_grid_line).Memo.ToString
            reimb(linenum).Text = VoucherRowData.Item(linenum + offset_grid_line).Reimb.ToString
            If Err.Number <> 0 Then
                V_line(linenum).Text = CStr(linenum + offset_grid_line + 1)
                acct_num(linenum).Text = acct_num_blank
                acct_desc(linenum).Text = ""
                amt(linenum).Text = ""
                vouch_desc(linenum).Text = ""
                If linenum + offset_grid_line <> 0 Then
                    Dim emptyrow As New VoucherData
                    VoucherRowData.Add(emptyrow)
                End If
                VoucherRowData.Item(linenum + offset_grid_line).VouchLine = CInt(V_line(linenum).Text)
                VoucherRowData.Item(linenum + offset_grid_line).DRAcctNum = acct_num_blank
                VoucherRowData.Item(linenum + offset_grid_line).AcctDesc = ""
                VoucherRowData.Item(linenum + offset_grid_line).Memo = ""
                VoucherRowData.Item(linenum + offset_grid_line).Reimb = ""
                VoucherRowData.Item(linenum + offset_grid_line).VouchAmt = ""
            End If
        Next
        On Error GoTo 0

        'recalc the offset grid line to keep the focus on the same physical line
        'and for the new line to be sensible

        'line renumbering done on v_line getting the focus
        'Dim i As Integer
        'For i = 0 To 7
        '    If Len(voucher_detail_grid(i + offset_grid_line, 2)) <> 0 Then
        '        acct_num(i).Text = (voucher_detail_grid(i + offset_grid_line, 2))
        '    Else
        '        acct_num(i).Text = acct_num_blank
        '    End If
        '    acct_desc(i).Text = voucher_detail_grid(i + offset_grid_line, 0)
        '    amt(i).Text = Format(voucher_detail_grid(i + offset_grid_line, 4), "###0.00;-###0.00")
        '    vouch_desc(i).Text = voucher_detail_grid(i + offset_grid_line, 3)
        '    reimb(i).Text = voucher_detail_grid(i + offset_grid_line, 5)

        'Next i
        '  If oldfocus < 0 Then oldfocus = 0
        Call tot_amt()
        '   V_line(oldfocus).Focus()

    End Sub

    Private Sub ClearVoucher()

        For Each VoucherRow In VoucherRowData
            VoucherRow = Nothing
        Next
        'blank the grid and set backcolor to white
        Dim linenum As Short
        For linenum = 0 To 7
            V_line(linenum).Text = ""
            acct_num(linenum).Text = ""
            acct_desc(linenum).Text = ""
            vouch_desc(linenum).Text = ""
            reimb(linenum).Text = ""
            amt(linenum).Text = ""
            V_line(linenum).BackColor = Color.White
            acct_num(linenum).BackColor = Color.White
            acct_desc(linenum).BackColor = Color.White
            vouch_desc(linenum).BackColor = Color.White
            reimb(linenum).BackColor = Color.White
            amt(linenum).BackColor = Color.White
        Next
        vouchtotaldetail = 0
        Me.vouchtotaldisplay.Text = Format(vouchtotaldetail, "$####0.00;-$####0.00")
        'blank the header
        Me.chknum.Enabled = True
        Me.chkdate.Enabled = True
        Me.vouchnum.Text = ""
        Me.ent_Date.Text = FormatDateTime(Today, DateFormat.ShortDate)
        Me.invdate.Text = ""
        Me.vendInvNum.Text = ""
        Me.VendInvAmt.Text = ""
        Me.VendDiscAmt.Text = ""
        Me.vend_num.Text = ""
        ' Me.bankname.SelectedItem = ""
        Me.vendname.Text = ""
        Me.duedate.Text = ""
        'Me.encdate.Text = ""

    End Sub

    Private Sub End_Session_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Session.Click
        'xx this is where you print the apron
        'the flag is set to 1 to print
        If flag_set = 1 Then
            prtDestination = CStr(1) 'forces to the printer
            prtreportfilename = ap_report_path & "apprtvch.rpt"
            CrystalForm.ShowDialog()
        End If

        If entry_type = "RECURRING" Or entry_type = "AddRECURRING" Then
            Me.Close()
            'xx print report from  form for recurring vouchers
        Else
            MsgBox(" You are about to print the voucher edit proof. Be sure your printer is turned on and on line.")

            prtDestination = CStr(0) 'to the screen
            prtreportfilename = ap_report_path & "apvedit.rpt"
            CrystalForm.ShowDialog()
            MsgBox("Check the proof.  If errors are found..select Edit Vouchers from the menu. ")
        End If
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmvouchent_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        VoucherLookupNum = Val(selected_lookup_num)
        acct_num_blank = "____-__-__"

        'fill bankname combobox
        Dim bkname As List(Of ContactData) = ETSSQL.GetContactData(0, "nam_bank")
        bankname.DataSource = bkname

        Select Case entry_type
            Case "ADD"
                Me.Text = "ADD Voucher Form"
                VoucherLookupNum = GetNextVouchNum(entry_type).ToString
                'create blank voucherrowdata
                VoucherRowData = ETSSQL.GetBlankVoucherData()
                VoucherRowData.Item(0).JrnlNum = VoucherLookupNum  'next number calculated on lookup form apMod.GetNextVouchNum(entry_type).ToString
                VoucherRowData.Item(0).DRAcctNum = acct_num_blank
                VoucherRowData.Item(0).VouchLine = 1
                Me.ent_Date.Text = Format(Date.Now, "short date")
                VoucherRowData.Item(0).EntryDate = CDate(ent_Date.Text)
                vouchnum.Text = VoucherLookupNum
                vouchnum.SelectAll()
            Case "EDIT"
                Me.Text = "Edit Voucher Form"

                VoucherSource = "select voucher.*, chacct.acct_desc from voucher inner join chacct on voucher.dr_Acct_nu = chacct.acct_num where vouch_num = " & VoucherLookupNum & " order by vouch_line"
                vouchnum.Text = VoucherLookupNum
                vouchnum.Enabled = False
                VoucherRowData = ETSSQL.GetVoucherData(VoucherSource)
                max_grid_line = VoucherRowData.Count
                vend_num.Select()
            Case "RECURRING"
                Me.Text = "Recurring Voucher Form"
                Me.vouchnum.Text = CStr(selected_rec_vouch_num + 1)
                VoucherSource = "select rec_vouc.*, chacct.acct_desc from rec_vouc inner join chacct on rec_vouc.dr_Acct_nu = chacct.acct_num where vouch_num = " & VoucherLookupNum & " order by vouch_line"
                vouchnum.Enabled = False
                VoucherRowData = ETSSQL.GetVoucherData(VoucherSource)
                max_grid_line = VoucherRowData.Count
                vend_num.SelectAll()
            Case "AddRECURRING"
                Me.Text = "Recurring Voucher Form"
                VoucherLookupNum = GetNextVouchNum(entry_type).ToString
                VoucherRowData = ETSSQL.GetBlankVoucherData()
                VoucherRowData.Item(0).JrnlNum = VoucherLookupNum  'next number calculated on lookup form apMod.GetNextVouchNum(entry_type).ToString
                VoucherRowData.Item(0).DRAcctNum = acct_num_blank
                VoucherRowData.Item(0).VouchLine = 1
                Me.ent_Date.Text = Format(Date.Now, "short date")
                VoucherRowData.Item(0).EntryDate = CDate(ent_Date.Text)
                vouchnum.Text = VoucherLookupNum
                vouchnum.SelectAll()
            Case "ProcessRecurring"
                Me.Text = "Adding a Recurring Voucher Form for Payment"
                Me.vouchnum.Text = GetNextVouchNum("ADD").ToString
                VoucherSource = "select rec_vouc.*, chacct.acct_desc from rec_vouc inner join chacct on rec_vouc.dr_Acct_nu = chacct.acct_num where vouch_num = " & VoucherLookupNum & " order by vouch_line"
                vouchnum.Enabled = True
                VoucherRowData = ETSSQL.GetVoucherData(VoucherSource)
                max_grid_line = VoucherRowData.Count
                chknum.Enabled = True
                chkdate.Enabled = True
                vouchnum.Select()
            Case "Revoucher"
                'voucher number is selected_lookup_num
                Me.Text = "Re-Voucher Form to correct a void voucher"
                VoucherLookupNum = save_voucher_num
                Me.vouchnum.Text = CStr(selected_rec_vouch_num + 1)
                VoucherSource = "select voucher.*, chacct.acct_desc from voucher inner join chacct on voucher.dr_Acct_nu = chacct.acct_num where vouch_num = " & VoucherLookupNum & " order by vouch_line"
                vouchnum.Enabled = False
                ' VoucherRowData.Clear()
                VoucherRowData = ETSSQL.GetVoucherData(VoucherSource)
                max_grid_line = VoucherRowData.Count
                vend_num.Select()
        End Select

        ETSForm(Me)

        Label99.Text = Me.Text
        Me.ent_Date.Text = Today.ToShortDateString

        Dim nn As Integer
        Dim n As Integer
        form_showing = "frmvouchent"
        function_type = "DATA_ENTRY"
        On Error Resume Next

        bankname.SelectedValue = VoucherRowData.Item(0).BankKey.Trim

        Call enterheader()
        Call repaint_grid(0)
        Select Case entry_type
            Case "ADD"
                vouchnum.Select()
            Case "EDIT"
                vend_num.Select()
        End Select

    End Sub

    Private Sub invdate_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles invdate.Enter
        invdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        invdate.SelectionStart = 0
        invdate.SelectionLength = Len(invdate.Text)

    End Sub

    Private Sub invdate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles invdate.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = invdate.Text
            If etsdate(senddate, valid_Date) = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                invdate.Text = Format(etsdate(senddate, valid_Date), "short date")
                Me.duedate.Text = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 30, CDate(invdate.Text)))
                VoucherRowData.Item(0).VendInvDate = CDate(invdate.Text)
                VoucherRowData.Item(0).DtTBePaid = CDate(duedate.Text)
                encdate.Focus()
            End If
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub invdate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles invdate.Leave
        invdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub reimb_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles reimb.Enter
        Dim Index As Short = reimb.GetIndex(eventSender)
        reimb(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        reimb(Index).SelectionStart = 0
        reimb(Index).SelectionLength = Len(reimb(Index).Text)
        reimb(Index).Text = "N"

        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            reimb(max_grid_line - 1).Focus()
            Exit Sub
        End If
    End Sub

    Private Sub reimb_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles reimb.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = reimb.GetIndex(eventSender)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            reimb(Index).Text = UCase(reimb(Index).Text)
            If reimb(Index).Text = "N" Or reimb(Index).Text = "Y" Then
                GoTo okyn
            Else
                MsgBox("Must enter Y or N")
                Call ets_set_selected()
                GoTo EventExitSub
            End If
okyn:
            VoucherRowData.Item(Index + offset_grid_line).Reimb = reimb(Index).Text

            If max_grid_line < CDbl(V_line(Index).Text) Then
                max_grid_line = CInt(V_line(Index).Text)
            End If

            If max_grid_line = CDbl(V_line(Index).Text) Then
                If invoice_left_to_enter = 0 Then
                    Response = MsgBox("Voucher complete?", 4)
                    If Response = 6 Then
                        GoTo donevouch
                    End If
                End If
            End If


            If Index = 7 Then
                offset_grid_line = offset_grid_line + 1
                Call repaint_grid(offset_grid_line)
                Me.acct_num(7).Text = acct_num(6).Text
                Me.V_line(7).Focus()
                KeyAscii = 0
                GoTo EventExitSub

            End If
            If (acct_num(Index + 1)).Text = acct_num_blank Then
                acct_num(Index + 1).Text = acct_num(Index).Text
            End If
            Me.V_line(Index + 1).Focus()
            KeyAscii = 0
            voucher_counter = max_grid_line
            GoTo EventExitSub

donevouch:

            voucher_counter = max_grid_line
            'check to see if all the data has been entered into the header
            miss = "CR_acct"
            If Len(VoucherRowData.Item(0).CRAcctNum) = 0 Then GoTo inv2
            miss = "vouch num"
            If Len(VoucherRowData.Item(0).VouchNum) = 0 Then GoTo inv2
            miss = "name key"
            If Len(VoucherRowData.Item(0).NameKey) = 0 Then GoTo inv2
            miss = "screen name"
            If Len(VoucherRowData.Item(0).ScreenNam) = 0 Then GoTo inv2
            miss = "vend inv"
            If Len(VoucherRowData.Item(0).VendInv) = 0 Then GoTo inv2
            miss = "vendor inv date"
            If Len(VoucherRowData.Item(0).VendInvDate) = 0 Then GoTo inv2
            miss = "date to be paid"
            If Len(VoucherRowData.Item(0).DtTBePaid) = 0 Then GoTo inv2
            miss = "bank key"
            If Len(VoucherRowData.Item(0).BankKey) = 0 Then GoTo inv2
            miss = "entry date"
            If Len(VoucherRowData.Item(0).EntryDate) = 0 Then GoTo inv2
            miss = "encum date"
            If Len(VoucherRowData.Item(0).EncumDate) = 0 Then GoTo inv2
            miss = "date paid"
            If Len(VoucherRowData.Item(0).BPostDate) = 0 Then
                If chknum.Text.Length <> 0 Then
                    GoTo inv2
                End If
            End If
            Call tot_amt()
            If invoice_left_to_enter = 0 Then
                'xxthis is where we get the last voucher number used so as
                'to move it to voucher.vouch_num and it will be written to the file
                'what is the key and how do we know it is the highest number
                'should we set up a sql to find it
                'write out the voucher

                Call putvoucher()
                'go back to voucher
                If msg.Length <> 0 Then Exit Sub

                'write out payment if needed

                batch_Amount = batch_Amount + total_amt
                vouch_Done = vouch_Done + 1
                disp_left_to_enter.Text = Format(batch_Amount, "$####0.00;-$####0.00")
                disp_num_of_vouch.Text = CStr(vouch_Done)

                Select Case entry_type
                    Case "RECURRING", "ProcessRecurring", "Revoucher", "EDIT", "AddRECURRING"
                        Me.Close()
                        Me.Dispose()
                        GoTo EventExitSub
                    Case Else

                End Select

                VoucherLookupNum = vouchnum.Text


                Call ClearVoucher()

                VoucherRowData = ETSSQL.GetBlankVoucherData()
                VoucherRowData.Item(0).JrnlNum = VoucherLookupNum  'next number calculated on lookup form apMod.GetNextVouchNum(entry_type).ToString
                VoucherRowData.Item(0).DRAcctNum = acct_num_blank
                Me.ent_Date.Text = FormatDateTime(Today, DateFormat.ShortDate)
                VoucherRowData.Item(0).EntryDate = CDate(ent_Date.Text)
                vouchnum.Text = VoucherLookupNum
                repaint_grid(0)
                vend_num.Focus()
                GoTo EventExitSub
            End If

inv2:
            'message that header is not complete
            MsgBox("Information not complete.  Please complete to continue")
            vouchnum.Focus()
            MsgBox("missing data = " & miss)

        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub reimb_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles reimb.Leave
        Dim Index As Short = reimb.GetIndex(eventSender)
        reimb(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Sub tot_amt()

        total_amt = 0
        For Each VoucherRow In VoucherRowData
            total_amt = total_amt + CDec(VoucherRow.AllocAmt)
        Next
        If Len(VendInvAmt.Text) = 0 Then VendInvAmt.Text = "0"
        invoice_left_to_enter = CDbl(VendInvAmt.Text) - total_amt
        Me.vouchtotaldisplay.Text = FormatNumber(total_amt, 2, True, True, True)

    End Sub

    Private Sub up_grid_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles up_grid.Click
        If max_grid_line < 6 Then Exit Sub


        If VoucherRowData.Item(offset_grid_line + 5).DRAcctNum = acct_num_blank Then
            Exit Sub
        Else
            offset_grid_line = CShort(offset_grid_line + 1)
            Call repaint_grid(CShort(offset_grid_line)) 'oldfocus was index?

        End If

    End Sub

    Private Sub V_Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles V_Cancel.Click
        'decrease vochnum by one sot entclear can add one in this case
        Me.vouchnum.Text = CStr(Val(Me.vouchnum.Text) - 1)
        Call ClearVoucher()
        vouchnum.Focus()

    End Sub

    Private Sub V_line_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles V_line.Enter
        Dim Index As Short = V_line.GetIndex(eventSender)
        ' V_line(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        VoucherRowData.Item(offset_grid_line + Index).JrnlLineNum = V_line(Index).Text
        acct_num(Index).Focus()
        KeyAscii = 0
    End Sub

    Private Sub V_line_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles V_line.Leave
        Dim Index As Short = V_line.GetIndex(eventSender)
        V_line(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub vend_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vend_num.Enter
        vend_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        vend_num.SelectionStart = 0
        vend_num.SelectionLength = Len(vend_num.Text)
    End Sub

    Private Sub vend_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles vend_num.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            If Len(vend_num.Text) = 0 Then
                function_type = "LOOKUP_ONLY"
                Dim namelookup As New frmnamechk
                frmnamechk.ShowDialog()
                Me.vend_num.Text = selected_name_key
            Else
                selected_name_key = vend_num.Text
            End If
            If checkYN("nam_vend", "name_key", vend_num.Text) = "N" Then
                vendname.Text = ""
                MsgBox("Invalid vendor number")

                Call ets_set_selected()
                GoTo EventExitSub
            End If

            Dim vendlist As List(Of ContactData) = ETSSQL.GetContactData(selected_name_key, "nam_addr")
            vendname.Text = vendlist.Item(0).ScreenName
            VoucherRowData.Item(0).NameKey = selected_name_key
            VoucherRowData.Item(0).ScreenNam = vendname.Text
            VoucherRowData.Item(0).SortName = vendlist.Item(0).SortName

            Dim DrAcctNum As String = ETSSQL.GetDRAcct(selected_name_key, "AP")
            If DrAcctNum.Length <> 0 Then
                Me.acct_num(0).Text = DrAcctNum
            End If

            VoucherRowData.Item(0).CRAcctNum = ETSSQL.GetCRAcct(selected_name_key, "AP")

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If


EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub vend_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vend_num.Leave
        vend_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub VendDiscAmt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VendDiscAmt.Enter
        VendDiscAmt.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        VendDiscAmt.SelectionStart = 0
        VendDiscAmt.SelectionLength = Len(VendDiscAmt.Text)

    End Sub

    Private Sub VendDiscAmt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles VendDiscAmt.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            VendDiscAmt.Text = TestText(VendDiscAmt.Text, 0)
            If VendDiscAmt.Text = "NotNumeric" Then
                MsgBox("Please enter a number")
                Exit Sub
            End If
            VendDiscAmt.Text = Format(VendDiscAmt.Text, "Fixed")
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
            VoucherRowData.Item(0).DiscAmt = Val(VendDiscAmt.Text)
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub VendDiscAmt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VendDiscAmt.Leave
        VendDiscAmt.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub VendInvAmt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VendInvAmt.Enter
        VendInvAmt.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        VendInvAmt.SelectionStart = 0
        VendInvAmt.SelectionLength = Len(VendInvAmt.Text)

    End Sub

    Private Sub VendInvAmt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles VendInvAmt.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            VendInvAmt.Text = TestText(VendInvAmt.Text, 0)
            If VendInvAmt.Text = "NotNumeric" Then
                MsgBox("Please enter a number")
                VendInvAmt.Text = ""
                Exit Sub
            End If
            invoice_left_to_enter = CDec(VendInvAmt.Text)
            End_Session.Enabled = False
            VoucherRowData.Item(0).AllocAmt = Val(VendInvAmt.Text)
            VendInvAmt.Text = FormatNumber(VendInvAmt.Text, 2, True, True, True)
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0


        End If


EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub VendInvAmt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VendInvAmt.Leave
        VendInvAmt.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub vendInvNum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vendInvNum.Enter
        vendInvNum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        vendInvNum.SelectionStart = 0
        vendInvNum.SelectionLength = Len(vendInvNum.Text)

    End Sub

    Private Sub vendInvNum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles vendInvNum.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If Len(vendInvNum.Text) = 0 Then vendInvNum.Text = " "
        If KeyAscii = 13 Or KeyAscii = 9 Then
            VoucherRowData.Item(0).VendInv = vendInvNum.Text
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub vendInvNum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vendInvNum.Leave
        vendInvNum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub vouch_desc_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vouch_desc.Enter
        Dim Index As Short = vouch_desc.GetIndex(eventSender)
        vouch_desc(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        vouch_desc(Index).SelectionStart = 0
        vouch_desc(Index).SelectionLength = Len(vouch_desc(Index).Text)

        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            reimb(max_grid_line - 1).Focus()
            Exit Sub
        End If

    End Sub

    Private Sub vouch_desc_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles vouch_desc.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        Dim Index As Short = vouch_desc.GetIndex(eventSender)
        Select Case KeyCode
            Case System.Windows.Forms.Keys.F3
                If Index <> 0 Then
                    vouch_desc(Index).Text = vouch_desc(Index - 1).Text
                    System.Windows.Forms.SendKeys.Send("{ENTER}")
                End If
        End Select

    End Sub

    Private Sub vouch_desc_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles vouch_desc.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = vouch_desc.GetIndex(eventSender)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            VoucherRowData.Item(Index + offset_grid_line).Memo = vouch_desc(Index).Text
            amt(Index).Focus()
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub vouch_desc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vouch_desc.Leave
        Dim Index As Short = vouch_desc.GetIndex(eventSender)
        vouch_desc(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub vouchnum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vouchnum.Enter
        Call ets_set_selected()
        offset_grid_line = 0
        max_grid_line = 1
        End_Session.Enabled = True

    End Sub

    Private Sub vouchnum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles vouchnum.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        If KeyAscii = 13 Or KeyAscii = 9 Then
            vouchnum.Text = TestText(vouchnum.Text, 0)
            If vouchnum.Text = "NotNumeric" Then
                MsgBox("Not a valid number")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            If checkYN("voucher", "vouch_num", vouchnum.Text) = "Y" Then
                MsgBox("This voucher number has been used - Please Re-enter")
                Call ets_set_selected()
                GoTo EventExitSub
            End If
            VoucherRowData.Item(0).VouchNum = CInt(vouchnum.Text)
            chknum.Focus()
            KeyAscii = 0
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub vouchnum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vouchnum.Leave
        vouchnum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub putvoucher()

        'check header complete - first item complete and rest are a copy
        'check lines complete
        'checl accts one more time
        'check total one more time

        'check to see if all the data has been entered into the header
        msg = "Header incomplete.  Please complete."
        If Len(VoucherRowData.Item(0).BankKey) = 0 Then GoTo notdone
        If Len(VoucherRowData.Item(0).DiscAmt) = 0 Then GoTo notdone
        If Len(VoucherRowData.Item(0).DtTBePaid) = 0 Then GoTo notdone
        If Len(VoucherRowData.Item(0).NameKey) = 0 Then GoTo notdone
        If Len(VoucherRowData.Item(0).VendInv) = 0 Then GoTo notdone
        If Len(VoucherRowData.Item(0).EntryDate) = 0 Then GoTo notdone
        If Len(VoucherRowData.Item(0).EncumDate) = 0 Then GoTo notdone
        If Len(VoucherRowData.Item(0).VendInvDate) = 0 Then GoTo notdone
        If Len(VoucherRowData.Item(0).VouchAmt) = 0 Then GoTo notdone
        msg = ""

        'check to make sure voucher number not used while entering voucher
        Select Case entry_type
            Case "ADD"
                If checkYN("voucher", "vouch_num", VoucherLookupNum) = "Y" Then
                    VoucherLookupNum = GetNextVouchNum(entry_type)
                End If
            Case "RECURRING"
                If checkYN("rec_vouc", "vouch_num", VoucherLookupNum) = "Y" Then       'this is an edit
                    ' VoucherLookupNum = ApMod.GetNextVouchNum(entry_type)
                Else        'this is an add
                    'VoucherLookupNum = ApMod.GetNextVouchNum(entry_type)
                    'entry_type = "RECURRING-ADD"
                End If
        End Select

        'delete all rows with blank acct nums - they were added when list was repainted
        'and fill the header info into each row in table
        Dim i As Integer
        For i = VoucherRowData.Count - 1 To 0 Step -1
            If VoucherRowData.Item(i).DRAcctNum = acct_num_blank Or Len(VoucherRowData.Item(i).DRAcctNum) = 0 Then
                VoucherRowData.RemoveAt(i)
            Else
                VoucherRowData.Item(i).VouchNum = VoucherRowData.Item(0).VouchNum
                VoucherRowData.Item(i).Paid = "N"
                VoucherRowData.Item(i).dflag = "N"
                VoucherRowData.Item(i).EncumDate = VoucherRowData.Item(0).EncumDate
                VoucherRowData.Item(i).EntryDate = CDate(ent_Date.Text)
                VoucherRowData.Item(i).Void = "N"
                VoucherRowData.Item(i).GLpost = "N"
                VoucherRowData.Item(i).Agency = AgencyNum.ToString
                VoucherRowData.Item(i).VendInvDate = CDate(invdate.Text)
                VoucherRowData.Item(i).VendInv = vendInvNum.Text
                VoucherRowData.Item(i).VouchAmt = VendInvAmt.Text
                VoucherRowData.Item(i).DiscAmt = Val(VendDiscAmt.Text)
                VoucherRowData.Item(i).NameKey = vend_num.Text
                VoucherRowData.Item(i).ScreenNam = vendname.Text
                VoucherRowData.Item(i).SortName = ETSSQL.GetContactData(Me.vend_num.Text, "nam_vend").Item(0).SortName
                VoucherRowData.Item(i).BankKey = bankname.SelectedValue.ToString
                VoucherRowData.Item(i).DtTBePaid = CDate(duedate.Text)
                VoucherRowData.Item(i).CRAcctNum = VoucherRowData.Item(0).CRAcctNum
            End If
        Next

        'acct nums  - 
        For Each VoucherRow In VoucherRowData
            ' Call etsacctnum_chk(VoucherRow.AcctNum, "", "", "")
            '  If valid_acct = "N" Then
            If etsacctnum_chk(VoucherRow.DRAcctNum) = "N" Then
                msg = "There is an invalid account.  Please edit and  then continue."
                GoTo notdone
                Exit Sub
            End If
        Next

        'check detail lines - line numbers will be fixed here
        Dim inum As Integer = 1
        msg = "Detail lines not complete.  Please complete."
        For Each VoucherRow In VoucherRowData
            If Len(VoucherRow.DRAcctNum) = 0 Then GoTo notdone
            If Len(VoucherRow.AllocAmt) = 0 Then GoTo notdone
            ' If Len(VoucherRow.Memo) = 0 Then GoTo notdone
            If reimb.ToString.Length = 0 Then GoTo notdone
            VoucherRow.VouchLine = inum
            inum = inum + 1
        Next
        msg = ""

        'we now have a good array and if edit old data needs to be removed

        Select Case entry_type
            Case "EDIT", "Revoucher"
                sqlstmnt = "delete from voucher where vouch_num = " & VoucherLookupNum
                ETSSQL.ExecuteSQL(sqlstmnt)
            Case "RECURRING"
                sqlstmnt = "delete from rec_vouc where vouch_num = " & VoucherLookupNum
                ETSSQL.ExecuteSQL(sqlstmnt)
        End Select

        For Each vcn In VoucherRowData ' Dim VCN As New VoucherData
            Select Case entry_type
                Case "EDIT", "Revoucher"
                    sqlstmnt = "insert into voucher " & vcn.VoucherColumnNames & "  values (" & vcn.VoucherColumnData & ")"
                    ETSSQL.ExecuteSQL(sqlstmnt)
                Case "ADD"
                    sqlstmnt = "insert into voucher " & vcn.VoucherColumnNames & "  values (" & vcn.VoucherColumnData & ")"
                    ETSSQL.ExecuteSQL(sqlstmnt)
                Case "RECURRING"
                    sqlstmnt = "insert into rec_vouc " & vcn.VoucherColumnNames & "  values (" & vcn.VoucherColumnData & ")"
                    ETSSQL.ExecuteSQL(sqlstmnt)
                Case "AddRECURRING"
                    sqlstmnt = "insert into rec_vouc " & vcn.VoucherColumnNames & "  values (" & vcn.VoucherColumnData & ")"
                    ETSSQL.ExecuteSQL(sqlstmnt)
                Case "ProcessRecurring"
                    sqlstmnt = "insert into voucher " & vcn.VoucherColumnNames & "  values (" & vcn.VoucherColumnData & ")"
                    ETSSQL.ExecuteSQL(sqlstmnt)
            End Select
        Next

        If entry_type = "ADD" Then
            Response = MsgBox("Do you wish to enter another Voucher?", MsgBoxStyle.YesNo)
            If Response = MsgBoxResult.Yes Then
                vouchnum.Text = GetNextVouchNum("ADD").ToString
                'set jedata object to nothing - blank it
                ' high_je_num = Val(high_je_num) + 1
                vouchnum.Focus()
                'clear array, add one to j/e number, and start over
            End If
        Else
            Me.Close()
        End If

        VoucherRowData.Clear()

        Exit Sub
notdone:
        MsgBox(msg)
        repaint_grid(0)
    End Sub

End Class