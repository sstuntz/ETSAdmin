Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Imports ETS.common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports System.Exception
Imports System.String

Public Class ar_cash_batch
    Inherits System.Windows.Forms.Form

    Public tot_amt As Decimal
    Public PayAmt As Decimal
    Dim adv_flag As String
    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Dim frmTableName As String = "cash_tmp1"
    Dim frmWhereClause As String = " where batch_num = '" & selected_bat_num & "' and entry_num = '" & selected_line_num & "'"
    Dim RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public NewCashReceipt As New CashReceiptData
    Public ErrFlag As Integer = 0
    Public DefaultBankKey As String = ConfigurationManager.AppSettings("DefaultBankKey")
    Public DefaultMiscNameKey As String = ConfigurationManager.AppSettings("DefaultMiscNameKey")


    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub bat_tot()
        sqlstmnt = "Select * from cash_Tmp1 where batch_num = " & selected_bat_num
        tot_amt = CDec(ETSSQL.GetTotalPayments(sqlstmnt))
        un_cash.Text = String.Format("{0:F2}", (CDec(bat_Amt.Text) - tot_amt))
        If CDbl(un_cash.Text) < 0 Then
            MsgBox("You have exceeded your batch total.")
        End If
        sqlstmnt = "Select isnull(sum(chk_alloc),0) as thevalue from cash_Tmp1 where batch_num = " & selected_bat_num & " and chk_num = '" & TextBox3.Text & "'"
        tot_amt = CDec(ETSSQL.GetOneSQLValue(sqlstmnt))
        If Len(txtfields(3).Text) = 0 Then txtfields(3).Text = "0"
        UnAppChk.Text = String.Format("{0:F2}", (CDec(txtfields(3).Text) - tot_amt))

    End Sub

    Public Sub calc_tot_inv()

        If Len(ETSSQL.GetOneSQLValue("select sum(bal_due)  as TheValue  from invoice where inv_num = '" & selected_inv_num & "'")) = 0 Then
            tot_amt = 0
        Else
            tot_amt = CDec(ETSSQL.GetOneSQLValue("select sum(bal_due)  as TheValue  from invoice where inv_num = '" & selected_inv_num & "'"))
        End If

    End Sub

    Private Sub CalcUNappChk()

        Dim Appchks As Double = CDec(ETSSQL.GetOneSQLValue("select isnull(sum(chk_alloc),0) as thevalue from cash_tmp1 where batch_num = " & selected_bat_num & " and chk_num = '" & TextBox3.Text & "'"))
        UnAppChk.Text = String.Format("{0:F2}", (CDec(txtfields(3).Text) - Appchks))

    End Sub

    Private Sub bat_Amt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bat_Amt.Enter
        Call ets_set_selected()
    End Sub

    Private Sub bat_Amt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles bat_Amt.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            'UPDATE the whole batch for any changes
            bat_Amt.Text = String.Format("{0:F2}", (CDec(bat_Amt.Text)))
            sqlstmnt = "update cash_Tmp1 set batch_total = '" & bat_Amt.Text & "' where batch_num = '" & selected_bat_num & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)
            Call bat_tot()
            txtfields(5).Focus()
            KeyAscii = 0
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub bat_Amt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bat_Amt.Leave
        bat_Amt.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        TextBox3.Focus()
    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ar_cash_batch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        Me.Text = Me.Text & "  " & agency_name
        entry_type = "ADD"

        'saved_entry_num = the last entry in the batch

        'If RowData.Count = 0 Then
        RowData = ETSSQL.GetData("cash_tmp1", " where batch_num  = '" & selected_bat_num & "'")
        '  End If

        Select Case entry_type

            Case "ADD"
                For Each Me.cntrl In Me.Controls
                    If TypeOf cntrl Is TextBox Then
                        cntrl.Text = ""
                    End If
                Next
                Call batch_number_Create()
                bat_Amt.Text = CStr(0)
                txtfields(15).Text = CStr(selected_bat_num)
                start_date1.Text = Today.ToShortDateString
                'deposit num is stored in batch desc and need to increase by one for the same day
                If Len(ETSSQL.GetOneSQLValue("Select top(1) batch_desc  as thevalue from cash_Tmp1 where batch_date = '" & start_date1.Text & "' order by batch_desc Desc")) = 0 Then
                    txtfields(10).Text = "1"
                Else
                    txtfields(10).Text = (CInt(ETSSQL.GetOneSQLValue("Select top(1) batch_desc  as thevalue from cash_Tmp1 where batch_date = '" & start_date1.Text & "' order by batch_desc Desc")) + 1).ToString
                End If
                txtfields(8).Text = start_date1.Text
                saved_entry_num = 0

            Case "EDIT"
                'rowdata found in the definiton area
                For Each Me.cntrl In Me.Controls
                    If TypeOf cntrl Is TextBox Then
                        If Not Len(Me.cntrl.Tag) = 0 Then
                            TagColumnName = Me.cntrl.Tag.ToString
                            Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                            If Len(frmdata.ActualData) <> 0 Then
                                cntrl.Text = frmdata.ActualData.ToString
                            End If
                        End If
                    End If
                Next
                start_date1.Text = CDate(start_date1.Text).ToShortDateString
                txtfields(8).Text = CDate(txtfields(8).Text).ToShortDateString
                sqlstmnt = "select top (1) entry_num as TheValue from cash_tmp1  where batch_num = '" & selected_bat_num & "' order by entry_num DESC"
                saved_entry_num = CInt(ETSSQL.GetOneSQLValue(sqlstmnt))

            Case "ADD_EDIT"
                'load only the header
                For Each Me.cntrl In Me.Controls
                    If TypeOf cntrl Is TextBox Then
                        If Not Len(Me.cntrl.Tag) = 0 Then
                            TagColumnName = Me.cntrl.Tag.ToString
                            Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                            If Len(frmdata.ActualData) <> 0 Then
                                ' cntrl.Text = frmdata.ActualData.ToString
                            End If
                        End If
                    End If
                Next

                txtfields(0).Text = RowData.Item(0).ActualData
                start_date1.Text = CDate(RowData.Item(1).ActualData).ToShortDateString
                txtfields(10).Text = RowData.Item(31).ActualData
                txtfields(15).Text = RowData.Item(30).ActualData
                bat_Amt.Text = String.Format("{0:F2}", RowData.Item(33).ActualData)
                sqlstmnt = "select top (1) entry_num as TheValue from cash_tmp1  where batch_num = '" & selected_bat_num & "' order by entry_num DESC"
                saved_entry_num = CInt(ETSSQL.GetOneSQLValue(sqlstmnt))
        End Select

        TextBox11.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        TextBox11.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextBox11.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        TextBox10.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        TextBox10.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextBox10.AutoCompleteMode = AutoCompleteMode.SuggestAppend


    End Sub

    Private Sub Start_date1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date1.Enter
        Call ets_set_selected()
        'bat_Amt.Text = String.Format("{0:F2}", CDec(bat_Amt.Text))
    End Sub

    Private Sub Start_date1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles start_date1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Then
            valid_Date = "N"
            senddate = start_date1.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")

            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                start_date1.Text = CDate(retdate).ToShortDateString
                selected_start_date = CDate(retdate)
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

    Private Sub Start_date1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date1.Leave
        start_date1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Form.ActiveForm.ActiveControl.BackColor = Color.Aqua '(RGB(0, 255, 255))
        Call ets_set_selected()
        If Index = 0 Then txtfields(0).Text = DefaultBankKey
        If Index = 19 Then txtfields(19).Text = DefaultMiscNameKey

    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        ' Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress 
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index

                Case 0  '0 = bank
                    saved_package_Type = package_Type
                    package_Type = "GL"
                    If Val(txtfields(Index).Text) = 0 Then
                        frmnamechk.ShowDialog()
                        txtfields(Index).Text = selected_name_key
                    End If

                    Call chkname(txtfields(Index).Text)

                    If valid_name = "N" Then
                        screen_nam(Index).Text = ""
                        MsgBox("Invalid Number")
                        Call ets_set_selected()
                        package_Type = saved_package_Type
                        GoTo EventExitSub
                    Else
                        screen_nam(Index).Text = selected_screen_nam
                    End If

                    Call bank_nameget(txtfields(Index).Text) 'this is the bank
                    TextBox11.Text = bank_dr_acct_nu
                    package_Type = saved_package_Type

                Case 19   '19 = name_key
                    If Val(txtfields(Index).Text) = 0 Then
                        frmnamechk.ShowDialog()
                        txtfields(Index).Text = selected_name_key
                    End If

                    Call chkname(txtfields(Index).Text)

                    If valid_name = "N" Then
                        screen_nam(Index).Text = ""
                        MsgBox("Invalid Number")
                        Call ets_set_selected()
                        package_Type = saved_package_Type
                        GoTo EventExitSub

                    Else
                        screen_nam(Index).Text = selected_screen_nam
                        TextBox5.Text = UnAppChk.Text
                    End If
                    Call cust_nameget(txtfields(Index).Text) 'also modified the ar_mod

                    If cust_type = "C" Or cust_type = "M" Then
                        txtfields(13).Text = "MISC" 'this is donor field
                    End If
                    TextBox10.Text = cust_dr_acct_nu

                Case 1 'fiscal month
                    If IsNumeric(txtfields(Index).Text) Then
                        If Len(txtfields(Index).Text) <> 4 Then
                            If Len(txtfields(Index).Text) = 3 Then
                                txtfields(Index).Text = "0" & txtfields(Index).Text
                            Else
                                MsgBox("You must enter four digits.")
                                Call ets_set_selected()
                                GoTo EventExitSub
                            End If
                        End If
                    Else
                        MsgBox("You must enter fiscal month and year as MMYY.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    function_type = "READY_PAY"

                Case 2 ' check to see if contract

                    txtfields(Index).Text = UCase(txtfields(Index).Text)
                    If Len(txtfields(Index).Text) = 0 Then
                        saved_function_Type = function_type
                        function_type = "READY_PAY"
                        contnumlookup.ShowDialog()
                        txtfields(Index).Text = selected_cont_id_num
                        function_type = saved_function_Type
                    Else
                        selected_cont_id_num = txtfields(Index).Text
                        If ETSCommon.CheckYN("cc_Cont", "cont_id_num", selected_cont_id_num, "N") = "N" Then
                            MsgBox("The contract does not exist.")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If
                    If Strings.Len(selected_cont_id_num) = 0 Then
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    TextBox4.Text = String.Format("{0:F2}", CDec(ETSSQL.GetOneSQLValue("select redpy_dol as TheValue  from cc_cont where contract_key = '" & selected_contract_key & "'")))
                    TextBox10.Text = ETSSQL.GetOneSQLValue("select dr_acct_nu as TheValue from cc_cont where cont_id_num = '" & selected_cont_id_num & "'")
                    TextBox12.Text = ETSSQL.GetOneSQLValue("select cont_desc as TheValue from cc_cont where cont_id_num = '" & _txtfields_2.Text & "'")
                    SaveRP.Focus()
                    Exit Sub
                Case 3 'are amounts
                    If Not IsNumeric(txtfields(Index).Text) Then txtfields(Index).Text = "0"
                    txtfields(Index).Text = String.Format("{0:F2}", CDec(txtfields(Index).Text))
                    selected_proc_dol_actual = CDec(txtfields(Index).Text)
                    Call CalcUNappChk()

                Case 5 'invoice
                    txtfields(Index).Text = UCase(txtfields(Index).Text)
                    'check the invoice string if match go on else lookup
                    If Len(txtfields(Index).Text) = 0 Then
                        function_type = "DATA_ENTRY"
                        invoicelookup.ShowDialog()
                        txtfields(Index).Text = ETSSQL.GetOneSQLValue("select invoice as TheValue  from invoice where inv_num = '" & selected_lookup_num & "'")
                        selected_inv_num = CInt(Val(selected_lookup_num))
                    Else
                        sqlstmnt = "Select * from invoice where void = 'N' and invoice = '" & txtfields(5).Text & "'"
                        If ETSCommon.CheckNumRecords(sqlstmnt) = 0 Then
                            Response = MsgBox("This invoice number does not exist. Is this an advance payment?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
                            If Response = MsgBoxResult.No Then
                                Call ets_set_selected()
                                GoTo EventExitSub
                            Else
                                adv_flag = "Y"
                                SaveInv.Focus()
                                GoTo EventExitSub
                            End If
                        Else
                            function_type = "INVOICE"
                        End If
                    End If
                    ' we now have inv num = selected lookup num or 5 is the invoice
                    selected_invoice = txtfields(5).Text
                    selected_inv_num = CInt(ETSSQL.GetOneSQLValue("select inv_num as TheValue from invoice where void = 'N' and invoice = '" & selected_invoice & "'"))
                    TextBox10.Text = ETSSQL.GetOneSQLValue("select dr_Acct_nu as TheValue from invoice where void = 'N' and invoice = '" & selected_invoice & "'")
                    screen_nam(Index).Text = ETSSQL.GetOneSQLValue("select inv_desc as TheValue  from invoice where invoice = '" & selected_invoice & "'")
                    TextBox1.Text = ETSSQL.GetOneSQLValue("select sum(bal_due) as TheValue from invoice where void = 'N' and invoice = '" & selected_invoice & "'")
                    TextBox1.Text = String.Format("{0:F2}", CDec(TextBox1.Text))
                    Call calc_tot_inv()
                    '    TextBox1.Text = ETSSQL.GetOneSQLValue("select sum(bal_due) as TheValue from invoice where void = 'N' and inv_num = '" & selected_lookup_num & "'")
                    TextBox1.Text = String.Format("{0:F2}", CDec(Val(TextBox1.Text)))
                    If Val(TextBox1.Text) = 0 Then
                        Response = MsgBox("This invoice has been paid. Do you want to overpay it?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
                        If Response = MsgBoxResult.No Then
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If
                    TextBox1.Focus()
                    GoTo EventExitSub

                Case 8 'date fields

                    If Len(txtfields(Index).Text) = 0 Then
                        System.Windows.Forms.SendKeys.Send("{tab}")
                        KeyAscii = 0
                        GoTo EventExitSub
                    End If

                    valid_Date = "N"
                    senddate = txtfields(Index).Text
                    Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")

                    If retdate = "N" Then
                        senddate = ""
                        MsgBox(" Bad Date")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtfields(Index).Text = CDate(retdate).ToShortDateString
                    End If

                Case 16
                    tot_amt = CDec(Val(txtfields(16).Text))
                    ret2 = String.Format("{0:F2}", tot_amt)
                    ar_inv_amt_choose.ShowDialog()
                    'the inv num comes back and need to find it
                    'if cancelled then selected_lookup_num is blank so skip
                    If selected_lookup_num <> "" Then
                        txtfields(5).Text = ETSSQL.GetOneSQLValue("select invoice as TheValue  from invoice where void = 'N' and inv_num = '" & selected_lookup_num & "'")
                        screen_nam(5).Text = ETSSQL.GetOneSQLValue("select inv_desc as TheValue  from invoice where void = 'N' and inv_num = '" & selected_lookup_num & "'")
                        Call calc_tot_inv()
                        selected_inv_num = CInt(selected_lookup_num)
                        TextBox1.Text = String.Format("{0:f2}", tot_amt)
                        TextBox1.Focus()
                    End If

                    GoTo EventExitSub
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
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub SaveRP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveRP.Click
        Call CheckData()
        If ErrFlag = 1 Then
            ErrFlag = 0
            Exit Sub
        End If

        If Len(txtfields(2).Text) = 0 Then 'to see if we skipped the contract entry
            MsgBox("You must enter something in the contract field")
            txtfields(2).Focus()
            KeyAscii = 0
            Exit Sub
        End If

        Call CreateNewCashReceipt()
        'look up contract data
        sqlstmnt = "select name_key as theValue from cc_Cont where contract_key = '" & selected_contract_key & "'"
        If ETSCommon.CheckNumRecords(sqlstmnt) = 0 Then
            MsgBox("Since you do not have a contract file the gl account numbers will be missing.")
            msg = InputBox("Please enter an invoice for this ready payment.")
            NewCashReceipt.Invoice = msg
        Else
            Call chkname_top(ETSSQL.GetOneSQLValue(sqlstmnt))
            NewCashReceipt.NameKey = selected_name_key
            NewCashReceipt.ScreenNam = selected_screen_nam
            NewCashReceipt.SortName = selected_sort_name
            '		'generate the inv string
            pr_end_date_tmp = CDate(VB.Left(txtfields(1).Text, 2) & "/15/" & VB.Right(txtfields(1).Text, 2))

            pr_end_date_tmp = DateAdd(Microsoft.VisualBasic.DateInterval.Month, -6, pr_end_date_tmp)
            msg = (invoice_string_Create(CStr(pr_end_date_tmp), selected_contract_key))
            If Len(msg) = 0 Then
                msg = InputBox("Please enter an invoice for this ready payment.")
            End If
            NewCashReceipt.Invoice = msg
            NewCashReceipt.CrAcctNu = ETSSQL.GetOneSQLValue("select dr_Acct_nu as TheValue from cc_Cont where contract_key = '" & selected_contract_key & "'")
        End If

        'fill data from invoice
        NewCashReceipt.EntryNum = saved_entry_num + 1
        NewCashReceipt.TransCode = "ADV"
        ' NewCashReceipt.CrAcctNu = InvRec.DrAcctNu
        NewCashReceipt.DrAcctNu = bank_dr_acct_nu
        NewCashReceipt.ChkDisc = 0
        NewCashReceipt.ChkNum = TextBox3.Text
        NewCashReceipt.ChkDate = CDate(txtfields(8).Text)
        NewCashReceipt.GrossAmt = CDec(txtfields(3).Text)
        NewCashReceipt.CheckAmt = CDec(txtfields(3).Text)
        NewCashReceipt.ChkAlloc = CDec(TextBox4.Text)
        NewCashReceipt.Invoice = "MISC"
        NewCashReceipt.TransCode = "PMT"
        'no invoice so no data
        'Dim InvRec As New CompanyInvoiceData
        'InvRec = ETSSQL.GetCompanyInvoiceDataOne(sqlstmnt)
        'NewCashReceipt.InvNum = InvRec.InvNum
        'NewCashReceipt.LineNum = InvRec.LineNum

        Call FinishReceipt()
        For Each Me.cntrl In Me.Controls
            If TypeOf cntrl Is TextBox Then
                Form.ActiveForm.ActiveControl.BackColor = Color.White
            End If
        Next
        txtfields(1).Focus()
    End Sub

    Private Sub SaveInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveInv.Click

        'advance payment sets a flag = adv_flag = 1
        Call CheckData()
        If ErrFlag = 1 Then
            ErrFlag = 0
            Exit Sub
        End If
        'got here since only one line or do not want to see the detail
        sqlstmnt = "select * from invoice where void = 'N' and inv_num = " & selected_inv_num
        If ETSCommon.CheckNumRecords(sqlstmnt) = 1 Then
            'fill data from screen
            Call CreateNewCashReceipt()
            'fill data from invoice
            NewCashReceipt.EntryNum = saved_entry_num + 1
            Dim InvRec As New CompanyInvoiceData
            InvRec = ETSSQL.GetCompanyInvoiceDataOne(sqlstmnt)
            NewCashReceipt.NameKey = InvRec.NameKey
            NewCashReceipt.ScreenNam = InvRec.ScreenNam
            NewCashReceipt.SortName = InvRec.SortName
            NewCashReceipt.InvNum = InvRec.InvNum
            NewCashReceipt.LineNum = InvRec.LineNum
            NewCashReceipt.Invoice = InvRec.Invoice
            NewCashReceipt.TransCode = "PMT"
            NewCashReceipt.CrAcctNu = InvRec.DrAcctNu
            NewCashReceipt.DrAcctNu = bank_dr_acct_nu
            NewCashReceipt.ChkDisc = 0
            NewCashReceipt.ChkNum = TextBox3.Text
            NewCashReceipt.ChkDate = CDate(txtfields(8).Text)
            NewCashReceipt.GrossAmt = CDec(txtfields(3).Text)
            NewCashReceipt.CheckAmt = CDec(txtfields(3).Text)
            NewCashReceipt.ChkAlloc = CDec(TextBox1.Text)
            Call FinishReceipt()
        Else
            Dim Invoices As List(Of CompanyInvoiceData)
            Invoices = ETSSQL.GetCompanyInvoiceData(sqlstmnt)
            For Each inv In Invoices
                saved_entry_num = saved_entry_num + 1
                Call CreateNewCashReceipt()
                NewCashReceipt.EntryNum = saved_entry_num
                NewCashReceipt.NameKey = inv.NameKey
                NewCashReceipt.ScreenNam = inv.ScreenNam
                NewCashReceipt.SortName = inv.SortName
                NewCashReceipt.InvNum = inv.InvNum
                NewCashReceipt.LineNum = inv.LineNum
                NewCashReceipt.Invoice = inv.Invoice
                NewCashReceipt.TransCode = "PMT"
                NewCashReceipt.CrAcctNu = inv.DrAcctNu
                NewCashReceipt.DrAcctNu = bank_dr_acct_nu
                NewCashReceipt.ChkDisc = 0
                NewCashReceipt.ChkNum = TextBox3.Text
                NewCashReceipt.ChkDate = CDate(txtfields(8).Text)
                NewCashReceipt.GrossAmt = CDec(txtfields(3).Text)
                NewCashReceipt.CheckAmt = CDec(txtfields(3).Text)
                NewCashReceipt.ChkAlloc = inv.BalDue
                selected_name_key = inv.NameKey
                Call FinishReceipt()
            Next
        End If

        If CDec(UnAppChk.Text) <> 0 Then
            txtfields(5).Focus()
        Else
            txtfields(3).Text = ""
            TextBox3.Text = ""
            TextBox3.Focus()
        End If


    End Sub

    Private Sub SaveVend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveVend.Click
        PutCashHeader()
        ar_det_app.AccessibleDescription = TextBox9.Text        'vendor name key
        ar_det_app.AccessibleName = TextBox16.Text
        saved_entry_type = entry_type
        selected_name_key_ee = selected_name_key
        function_type = "VENDOR"
        selected_name_key = TextBox9.Text
        ar_det_app.Tag = CDbl(Val(txtfields(3).Text)).ToString
        ar_det_app.ShowDialog()
        saved_entry_type = entry_type
        selected_name_key = selected_name_key_ee
        If entry_type = "CANCEL" Then
            MsgBox("The entry was cancelled. No Cash applied")
            entry_type = saved_entry_type
        End If

        Call RePaintHeader()
        entry_type = saved_entry_type
        For Each Me.cntrl In Me.Controls
            If TypeOf cntrl Is TextBox Then
                Me.cntrl.BackColor = Color.White
            End If
        Next
        TextBox9.Focus()

    End Sub

    Private Sub SaveClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveClient.Click

        PutCashHeader()
        ar_det_app.AccessibleDescription = TextBox15.Text
        saved_entry_type = entry_type
        selected_name_key_ee = selected_name_key
        function_type = "CLIENT"
        selected_name_key = TextBox15.Text
        ar_det_app.Tag = CDbl(Val(txtfields(3).Text)).ToString
        ar_det_app.ShowDialog()
        saved_entry_type = entry_type
        selected_name_key = selected_name_key_ee
        If entry_type = "CANCEL" Then
            MsgBox("The entry was cancelled. No Cash applied")
            entry_type = saved_entry_type
        End If
        Call RePaintHeader()
        entry_type = saved_entry_type
        For Each Me.cntrl In Me.Controls
            If TypeOf cntrl Is TextBox Then
                Me.cntrl.BackColor = Color.White
            End If
        Next
        TextBox15.Focus()

    End Sub

    Private Sub SaveMisc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveMisc.Click
        Call CheckData()
        If Len(txtfields(13).Text) = 0 Then
            MsgBox("You must enter a description.")
            txtfields(13).Focus()
            Exit Sub
        End If
        If ErrFlag = 1 Then
            ErrFlag = 0
            Exit Sub
        End If

        Call CreateNewCashReceipt()
        'fill data from invoice
        NewCashReceipt.EntryNum = saved_entry_num + 1
        NewCashReceipt.DrAcctNu = bank_dr_acct_nu
        NewCashReceipt.ChkDisc = 0
        NewCashReceipt.ChkNum = TextBox3.Text
        NewCashReceipt.ChkDate = CDate(txtfields(8).Text)
        NewCashReceipt.GrossAmt = CDec(txtfields(3).Text)
        NewCashReceipt.CheckAmt = CDec(txtfields(3).Text)
        NewCashReceipt.ChkAlloc = CDec(TextBox5.Text)
        NewCashReceipt.Invoice = "MISC"
        NewCashReceipt.TransCode = "PMT"
        Call chkname_top(txtfields(19).Text)
        NewCashReceipt.NameKey = selected_name_key
        NewCashReceipt.ScreenNam = selected_screen_nam
        NewCashReceipt.SortName = selected_sort_name
        NewCashReceipt.CrAcctNu = TextBox10.Text

        Call FinishReceipt()
        If CDec(UnAppChk.Text) <> 0 Then
            txtfields(19).Focus()
        Else
            txtfields(3).Text = ""
            TextBox3.Text = ""
            TextBox3.Focus()
        End If

    End Sub

    Private Sub CheckData()
        'check header - amount -acct number
        ErrFlag = 0
        If Len(txtfields(0).Text) = 0 Or Len(txtfields(10).Text) = 0 Or Len(txtfields(15).Text) = 0 Then
            MsgBox("You must enter the header information.")
            bat_Amt.Focus()
            ErrFlag = 1
            Exit Sub
        End If

        If Len(txtfields(3).Text) = 0 Then
            MsgBox("You must enter an amount.")
            txtfields(3).Focus()
            ErrFlag = 1
            Exit Sub
        End If

        If ETSCommon.CheckNumRecords("select * from chacct where jriacct = '" & TextBox10.Text & "'") = 0 Then
            MsgBox("You must enter a cr account.")
            TextBox10.Focus()
            ErrFlag = 1
            Exit Sub
        End If

        If ETSCommon.CheckNumRecords("select * from chacct where jriacct = '" & TextBox11.Text & "'") = 0 Then
            MsgBox("You must enter a cr account.")
            TextBox11.Focus()
            ErrFlag = 1
            Exit Sub
        End If

    End Sub

    Private Sub PutCashHeader()
        TmpCashReceiptHeader = ETSSQL.GetBlankCashReceiptHeader
        TmpCashReceiptHeader.BankKey = txtfields(0).Text
        TmpCashReceiptHeader.BatchDate = CDate((start_date1.Text))
        TmpCashReceiptHeader.BatchDesc = txtfields(10).Text
        TmpCashReceiptHeader.BatchNum = CInt(txtfields(15).Text)
        TmpCashReceiptHeader.BatchTotal = CDec(bat_Amt.Text)
        If Len(TextBox16.Text) <> 0 Then
            TmpCashReceiptHeader.EncumDate = CDate((TextBox16.Text))
        Else
            TmpCashReceiptHeader.EncumDate = CDate((start_date1.Text))
        End If
        TmpCashReceiptHeader.EntryDate = Today
        TmpCashReceiptHeader.CheckAmt = CDec(txtfields(3).Text)
        TmpCashReceiptHeader.ChkDate = CDate(txtfields(8).Text)
        TmpCashReceiptHeader.ChkNum = TextBox3.Text
        TmpCashReceiptHeader.GrossAmt = CDec(txtfields(3).Text)
        TmpCashReceiptHeader.ChkDisc = 0

        ar_det_app.Tag = CDbl(Val(txtfields(3).Text)).ToString

    End Sub

    Private Sub CreateNewCashReceipt()
        newcashreceipt = ETSSQL.GetBlankCashReceiptData

        NewCashReceipt.Agency = AgencyNum
        NewCashReceipt.BankKey = txtfields(0).Text
        NewCashReceipt.BatchDate = CDate((start_date1.Text))
        NewCashReceipt.BatchDesc = txtfields(10).Text
        NewCashReceipt.BatchNum = CInt(txtfields(15).Text)
        NewCashReceipt.BatchTotal = CDec(bat_Amt.Text)
        NewCashReceipt.CrAcctNu = TextBox10.Text
        NewCashReceipt.DrAcctNu = TextBox11.Text
        NewCashReceipt.EncumDate = CDate((start_date1.Text))
        NewCashReceipt.EntryDate = Today
        newcashreceipt.Memo = TextBox2.Text
        NewCashReceipt.SM = "M"
        NewCashReceipt.VoidChk = "N"
        NewCashReceipt.Dflag = "N"
        NewCashReceipt.Donor = ""
        NewCashReceipt.Memo = ""
        NewCashReceipt.Fund = ""
        NewCashReceipt.JrnlLine = 0
        NewCashReceipt.JrnlNum = 0
        NewCashReceipt.DiscAcct = ""
        NewCashReceipt.Glpost = "N"
        NewCashReceipt.Checked = "N"

        If adv_flag = "Y" Then
            NewCashReceipt.TransCode = "ADV"
            adv_flag = "N"
        End If

        If adv_flag = "X" Then
            NewCashReceipt.TransCode = "ADVX"
            adv_flag = "N"
        End If

    End Sub

    Private Sub FinishReceipt()

        last_amt.Text = String.Format("{0:F2}", NewCashReceipt.ChkAlloc)
        last_chk.Text = NewCashReceipt.ChkNum

        Call PutCashReceipt()
        NewCashReceipt = Nothing

        'update header info = batch desc or batch total
        sqlstmnt = "update cash_tmp1 set batch_desc = '" & txtfields(10).Text & "' , bat_total = '" & bat_Amt.Text & "' where batch_num = '" & txtfields(15).Text & "'"
        Call RePaintHeader()

    End Sub

    Private Sub PutCashReceipt()
        'we now have a good array and if edit old data needs to be removed

        Select Case entry_type
            Case "EDIT"
                sqlstmnt = "Delete from cash_tmp1 where batch_num = '" & selected_bat_num & "' and entry_num = '" & selected_line_num & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
        End Select

        sqlstmnt = "Insert into Cash_tmp1 " & NewCashReceipt.CashReceiptColumnNames & " values " & NewCashReceipt.CashReceiptColumnData
        ETSSQL.ExecuteSQL(sqlstmnt)

    End Sub

    Private Sub RePaintHeader()
        'clear all but the header and repaint
        For Each Me.cntrl In Me.Controls
            If TypeOf cntrl Is TextBox Then
                cntrl.Text = ""
                cntrl.BackColor = Color.White
            End If
        Next
        If ETSCommon.CheckNumRecords("select * from cash_tmp1 where batch_num  = '" & selected_bat_num & "'") = 0 Then
            start_date1.Focus()
            Exit Sub
        Else
            RowData = ETSSQL.GetData("cash_tmp1", " where batch_num  = '" & selected_bat_num & "' order by entry_num")
            txtfields(0).Text = RowData.Item(0).ActualData
            start_date1.Text = CDate(RowData.Item(1).ActualData).ToShortDateString
            txtfields(10).Text = RowData.Item(31).ActualData
            txtfields(15).Text = RowData.Item(30).ActualData
            bat_Amt.Text = String.Format("{0:F2}", CDec(RowData.Item(33).ActualData))
            sqlstmnt = "select top (1) entry_num as TheValue from cash_tmp1  where batch_num = '" & selected_bat_num & "' order by entry_num DESC"
            saved_entry_num = CInt(ETSSQL.GetOneSQLValue(sqlstmnt))
            txtfields(8).Text = CDate(RowData.Item(6).ActualData).ToShortDateString
            txtfields(3).Text = String.Format("{0:F2}", CDec(RowData.Item(7).ActualData.ToString))
            TextBox3.Text = RowData.Item(5).ActualData.ToString
            last_amt.Text = String.Format("{0:F2}", RowData.Item(9).ActualData.ToString)
            last_chk.Text = RowData.Item(5).ActualData.ToString
            TextBox11.Text = bank_dr_acct_nu
            adv_flag = "N"

            Call bat_tot()
            Call calc_tot_inv()
            bat_Amt.Text = String.Format("{0:F2}", CDec(bat_Amt.Text))
            last_amt.Text = String.Format("{0:F2}", CDec(last_amt.Text))
            txtfields(3).Text = String.Format("{0:F2}", CDec(txtfields(3).Text))
        End If
    End Sub

    Private Sub textbox_enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextBox10.Enter, TextBox11.Enter, TextBox13.Enter, TextBox15.Enter, TextBox16.Enter, TextBox2.Enter, TextBox3.Enter, TextBox7.Enter, TextBox9.Enter, TextBox1.Enter, TextBox4.Enter, TextBox5.Enter
        Form.ActiveForm.ActiveControl.BackColor = Color.Aqua '(RGB(0, 255, 255))
        Call ets_set_selected()
    End Sub

    Private Sub textbox_leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextBox13.Leave, TextBox15.Leave, TextBox16.Leave, TextBox2.Leave, TextBox3.Leave, TextBox7.Leave, TextBox9.Leave, TextBox1.Leave, TextBox4.Leave, TextBox5.Leave
        ' System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        For Each Me.cntrl In Me.Controls
            If TypeOf cntrl Is TextBox Then
                Me.cntrl.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub textbox10_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox10.KeyDown
        ' Determine whether the key entered is the F1 key. If it is, display Help. 
        If e.KeyCode = Keys.Enter Then
            If Len(TextBox10.Text) = 0 Then
                saved_function_Type = function_type
                function_type = "DATA_ENTRY"
                Call etsacctnum_chk(TextBox10.Text)

                If valid_acct = "N" Then
                    MsgBox("Not a valid account number.")
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If

                TextBox10.Text = retacct
                function_type = saved_function_Type
            End If
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
            Form.ActiveForm.ActiveControl.BackColor = Color.White
        End If
EventExitSub:
        'e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If



    End Sub 'textBox1_KeyDown

    Private Sub textbox11_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox11.KeyDown
        ' Determine whether the key entered is the F1 key. If it is, display Help. 
        If e.KeyCode = Keys.Enter Then
            If Len(TextBox11.Text) = 0 Then
                saved_function_Type = function_type
                function_type = "DATA_ENTRY"
                Call etsacctnum_chk(TextBox11.Text)

                If valid_acct = "N" Then
                    MsgBox("Not a valid account number.")
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If

                TextBox11.Text = retacct
                function_type = saved_function_Type
            End If
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
            Form.ActiveForm.ActiveControl.BackColor = Color.White
        End If
EventExitSub:
        '  e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub 'textBox1_KeyDown

    Private Sub TextBox1_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        'amt to be applied to this invoice
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
            If Not IsNumeric(TextBox1.Text) Then
                MsgBox("Please enter an amount to be applied to this invoice.")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                sqlstmnt = "Select * from invoice where void = 'N' and invoice = '" & txtfields(5).Text & "'"
                If ETSCommon.CheckNumRecords(sqlstmnt) <> 1 Then
                    PutCashHeader()
                    ar_det_app.Tag = CDbl(Val(TextBox1.Text)).ToString
                    'if many lines and full pay then ask if want detail
                    If Val(TextBox1.Text) = Val(ETSSQL.GetOneSQLValue("select sum(bal_due) as TheValue from invoice where void = 'N' and invoice = '" & selected_invoice & "'")) Then
                        Response = MsgBox("this will fully pay the invoice.  Do you wish to see the detail?", vbYesNo)
                        If Response = vbNo Then
                            SaveInv.Focus()
                            Exit Sub
                        Else
                            ar_det_app.ShowDialog()
                            saved_entry_type = entry_type
                            If entry_type = "CANCEL" Then
                                MsgBox("The entry was cancelled. No Cash applied")
                                entry_type = saved_entry_type
                            End If
                            Call RePaintHeader()
                            txtfields(5).Focus()
                            GoTo EventExitSub
                            'based on if check all allocated wherhter go back to invoice or back to check
                            'also fill in the maount to be allocated
                        End If
                    Else
                        ar_det_app.ShowDialog()
                        saved_entry_type = entry_type
                        If entry_type = "CANCEL" Then
                            MsgBox("The entry was cancelled. No Cash applied")
                            entry_type = saved_entry_type
                        End If
                        Call RePaintHeader()
                        txtfields(5).Focus()
                        GoTo EventExitSub
                        'based on if check all allocated wherhter go back to invoice or back to check
                        'also fill in the maount to be allocated
                    End If
                End If
            End If
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
EventExitSub:
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox2_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        'amt to be applied to this invoice
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
EventExitSub:
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub Textbox4_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        'amt to be applied to this invoice
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
            If Not IsNumeric(TextBox4.Text) Then
                MsgBox("Please enter an amount to be applied.")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
                Form.ActiveForm.ActiveControl.BackColor = Color.White
            End If
        End If
EventExitSub:
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub Textbox5_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        'amt to be applied to this invoice
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
            If Not IsNumeric(TextBox5.Text) Then
                MsgBox("Please enter an amount to be applied.")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
                Form.ActiveForm.ActiveControl.BackColor = Color.White
            End If
        End If
EventExitSub:
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub
    Private Sub TextBox3_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        'vendor
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
            TextBox3.Text = UCase(TextBox3.Text)
            'get how many $ are paid on this check and put into box
            txtfields(8).Text = start_date1.Text
            If VB.Left(TextBox3.Text, 3) = "EFT" Then
                txtfields(3).Text = un_cash.Text
                TextBox3.Text = TextBox3.Text & "-" & txtfields(10).Text
            End If

            Call CalcUNappChk()
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
            Form.ActiveForm.ActiveControl.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        End If
EventExitSub:
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox9_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        'vendor
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
            If Len(TextBox9.Text) = 0 Then
                saved_package_Type = package_Type
                package_Type = "AR"
                frmnamechk.ShowDialog()
                package_Type = saved_package_Type
                TextBox9.Text = selected_name_key
            End If
            Call chkname(TextBox9.Text)
            If valid_name = "N" Then
                TextBox7.Text = ""
                MsgBox("Invalid Number")
                Call ets_set_selected()
                package_Type = saved_package_Type
                GoTo EventExitSub
            Else
                TextBox7.Text = selected_screen_nam
            End If
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0

        End If
EventExitSub:
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox15_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox15.KeyPress
        'client
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
            If Len(TextBox15.Text) = 0 Then
                saved_package_Type = package_Type
                package_Type = "ATT"
                frmnamechk.ShowDialog()
                package_Type = saved_package_Type
                TextBox15.Text = selected_name_key
            End If
            Call chkname(TextBox15.Text)
            If valid_name = "N" Then
                TextBox13.Text = ""
                MsgBox("Invalid Number")
                Call ets_set_selected()
                package_Type = saved_package_Type
                GoTo EventExitSub
            Else
                TextBox13.Text = selected_screen_nam
            End If

            KeyAscii = 0
            SaveClient.Focus()
        End If

EventExitSub:
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox16_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox16.KeyPress
        'encumbered date
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
            Dim retdate As String = ETS.Common.Module1.etsdate(TextBox16.Text, "N")
            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                TextBox16.Text = CDate(retdate).ToShortDateString
            End If

            SaveVend.Focus()
        End If

EventExitSub:
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub textbox10_leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextBox10.Leave, TextBox11.Leave
        TextBox6.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from jriacct where jriacct = '" & TextBox10.Text & "'")
        TextBox8.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from jriacct where jriacct = '" & TextBox11.Text & "'")
        TextBox10.BackColor = Color.White
        TextBox11.BackColor = Color.White
    End Sub

    Private Sub _txtfields_0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _txtfields_0.TextChanged
        screen_nam(0).Text = ETSSQL.GetOneSQLValue("select screen_nam as TheValue from nam_addr where name_key = '" & txtfields(0).Text & "'")

    End Sub

End Class

'Option Strict On
'Option Explicit On
'Imports VB = Microsoft.VisualBasic
'Imports System.Diagnostics
'Imports Microsoft.VisualBasic.Conversion
'Imports Microsoft.VisualBasic.PowerPacks
'Imports System
'Imports System.Configuration
'Imports System.Configuration.ConfigurationSettings
'Imports ETS.Common.Module1
'Imports PS.Common
'Imports System.Data.SqlClient
'Imports System.Exception

'Public Class ar_cash_batch
'    Inherits System.Windows.Forms.Form

'    Public tot_amt As Decimal
'    Public PayAmt As Decimal
'    Dim adv_flag As String
'    Public ds(50, 50, 50) As String
'    Public TagColumnName As String
'    Dim frmTableName As String = "cash_tmp1"
'    Dim frmWhereClause As String = " where batch_num = '" & selected_bat_num & "' and entry_num = '" & selected_line_num & "'"
'    Dim RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
'    Public num1 As Integer = 0
'    Public cntrl As Control
'    Public NewCashReceipt As New CashReceiptData
'    Public ErrFlag As Integer = 0
'    Public DefaultBankKey As String = ConfigurationManager.AppSettings("DefaultBankKey")
'    Public DefaultMiscNameKey As String = ConfigurationManager.AppSettings("DefaultMiscNameKey")


'    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
'        If CName.ColumnName = TagColumnName Then
'            Return True
'        Else
'            Return False
'        End If

'    End Function

'    Public Sub bat_tot()
'        sqlstmnt = "Select * from cash_Tmp1 where batch_num = " & selected_bat_num
'        tot_amt = CDec(ETSSQL.GetTotalPayments(sqlstmnt))
'        un_cash.Text = String.Format("{0:F2}", (CDec(bat_Amt.Text) - tot_amt))
'        If CDbl(un_cash.Text) < 0 Then
'            MsgBox("You have exceeded your batch total.")
'        End If
'        sqlstmnt = "Select * from cash_Tmp1 where batch_num = " & selected_bat_num & " and chk_num = '" & TextBox3.Text & "'"
'        tot_amt = CDec(ETSSQL.GetTotalPayments(sqlstmnt))
'        UnAppChk.Text = String.Format("{0:F2}", (Val(txtfields(3).Text) - tot_amt))

'    End Sub

'    Public Sub calc_tot_inv()

'        If Len(ETSSQL.GetOneSQLValue("select sum(bal_due)  as TheValue  from invoice where inv_num = '" & selected_inv_num & "'")) = 0 Then
'            tot_amt = 0
'        Else
'            tot_amt = CDec(ETSSQL.GetOneSQLValue("select sum(bal_due)  as TheValue  from invoice where inv_num = '" & selected_inv_num & "'"))
'        End If

'    End Sub

'    Private Sub bat_Amt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bat_Amt.Enter
'        Call ets_set_selected()
'    End Sub

'    Private Sub bat_Amt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles bat_Amt.KeyPress
'        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
'        If KeyAscii = 13 Or KeyAscii = 9 Then
'            'UPDATE the whole batch for any changes
'            bat_Amt.Text = String.Format("{0:F2}", (CDec(bat_Amt.Text)))
'            sqlstmnt = "update cash_Tmp1 set batch_total = '" & bat_Amt.Text & "' where batch_num = '" & selected_bat_num & "'"
'            ETSSQL.ExecuteSQL(sqlstmnt)
'            Call bat_tot()
'            txtfields(5).Focus()
'            KeyAscii = 0
'        End If

'        eventArgs.KeyChar = Chr(KeyAscii)
'        If KeyAscii = 0 Then
'            eventArgs.Handled = True
'        End If
'    End Sub

'    Private Sub bat_Amt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bat_Amt.Leave
'        bat_Amt.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
'        TextBox3.Focus()
'    End Sub

'    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdClose.Click
'        Me.Close()
'        Me.Dispose()
'    End Sub

'    Private Sub ar_cash_batch_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
'        ctrform(Me)
'        Me.Text = Me.Text & "  " & agency_name
'        'saved_entry_num = the last entry in the batch

'        'If RowData.Count = 0 Then
'        RowData = ETSSQL.GetData("cash_tmp1", " where batch_num  = '" & selected_bat_num & "'")
'        '  End If

'        Select Case entry_type

'            Case "ADD"
'                For Each Me.cntrl In Me.Controls
'                    If TypeOf cntrl Is TextBox Then
'                        cntrl.Text = ""
'                    End If
'                Next
'                Call batch_number_Create()
'                bat_Amt.Text = CStr(0)
'                txtfields(15).Text = CStr(selected_bat_num)
'                start_date1.Text = Today.ToShortDateString
'                'deposit num is stored in batch desc and need to increase by one for the same day
'                If Len(ETSSQL.GetOneSQLValue("Select top(1) batch_desc  as thevalue from cash_Tmp1 where batch_date = '" & start_date1.Text & "' order by batch_desc Desc")) = 0 Then
'                    txtfields(10).Text = "1"
'                Else
'                    txtfields(10).Text = (CInt(ETSSQL.GetOneSQLValue("Select top(1) batch_desc  as thevalue from cash_Tmp1 where batch_date = '" & start_date1.Text & "' order by batch_desc Desc")) + 1).ToString
'                End If
'                txtfields(8).Text = start_date1.Text
'                saved_entry_num = 0

'            Case "EDIT"
'                'rowdata found in the definiton area
'                For Each Me.cntrl In Me.Controls
'                    If TypeOf cntrl Is TextBox Then
'                        If Not Len(Me.cntrl.Tag) = 0 Then
'                            TagColumnName = Me.cntrl.Tag.ToString
'                            Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
'                            If Len(frmdata.ActualData) <> 0 Then
'                                cntrl.Text = frmdata.ActualData.ToString
'                            End If
'                        End If
'                    End If
'                Next
'                start_date1.Text = CDate(start_date1.Text).ToShortDateString
'                txtfields(8).Text = CDate(txtfields(8).Text).ToShortDateString
'                sqlstmnt = "select top (1) entry_num as TheValue from cash_tmp1  where batch_num = '" & selected_bat_num & "' order by entry_num DESC"
'                saved_entry_num = CInt(ETSSQL.GetOneSQLValue(sqlstmnt))

'            Case "ADD_EDIT"
'                'load only the header
'                For Each Me.cntrl In Me.Controls
'                    If TypeOf cntrl Is TextBox Then
'                        If Not Len(Me.cntrl.Tag) = 0 Then
'                            TagColumnName = Me.cntrl.Tag.ToString
'                            Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
'                            If Len(frmdata.ActualData) <> 0 Then
'                                ' cntrl.Text = frmdata.ActualData.ToString
'                            End If
'                        End If
'                    End If
'                Next

'                txtfields(0).Text = RowData.Item(0).ActualData
'                start_date1.Text = CDate(RowData.Item(1).ActualData).ToShortDateString
'                txtfields(10).Text = RowData.Item(31).ActualData
'                txtfields(15).Text = RowData.Item(30).ActualData
'                bat_Amt.Text = String.Format("{0:F2}", RowData.Item(33).ActualData)
'                sqlstmnt = "select top (1) entry_num as TheValue from cash_tmp1  where batch_num = '" & selected_bat_num & "' order by entry_num DESC"
'                saved_entry_num = CInt(ETSSQL.GetOneSQLValue(sqlstmnt))
'        End Select

'        TextBox11.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
'        TextBox11.AutoCompleteSource = AutoCompleteSource.CustomSource
'        TextBox11.AutoCompleteMode = AutoCompleteMode.SuggestAppend

'        TextBox10.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
'        TextBox10.AutoCompleteSource = AutoCompleteSource.CustomSource
'        TextBox10.AutoCompleteMode = AutoCompleteMode.SuggestAppend


'    End Sub

'    Private Sub Start_date1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date1.Enter
'        Call ets_set_selected()
'        'bat_Amt.Text = String.Format("{0:F2}", CDec(bat_Amt.Text))
'    End Sub

'    Private Sub Start_date1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles start_date1.KeyPress
'        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
'        If KeyAscii = 13 Then
'            valid_Date = "N"
'            senddate = start_date1.Text
'            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")

'            If retdate = "N" Then
'                senddate = ""
'                MsgBox(" Bad Date")
'                Call ets_set_selected()
'                GoTo EventExitSub
'            Else
'                start_date1.Text = CDate(retdate).ToShortDateString
'                selected_start_date = CDate(retdate)
'            End If

'            System.Windows.Forms.SendKeys.Send("{tab}")
'            KeyAscii = 0
'        End If

'EventExitSub:
'        eventArgs.KeyChar = Chr(KeyAscii)
'        If KeyAscii = 0 Then
'            eventArgs.Handled = True
'        End If
'    End Sub

'    Private Sub Start_date1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date1.Leave
'        start_date1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
'    End Sub

'    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
'        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
'        Form.ActiveForm.ActiveControl.BackColor = Color.Aqua '(RGB(0, 255, 255))
'        Call ets_set_selected()
'        If Index = 0 Then txtfields(0).Text = DefaultBankKey
'        If Index = 19 Then txtfields(19).Text = DefaultMiscNameKey

'    End Sub

'    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
'        ' Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress 
'        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
'        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
'        If KeyAscii = 13 Or KeyAscii = 9 Then

'            Select Case Index

'                Case 0  '0 = bank
'                    saved_package_Type = package_Type
'                    package_Type = "GL"
'                    If Val(txtfields(Index).Text) = 0 Then
'                        frmnamechk.ShowDialog()
'                        txtfields(Index).Text = selected_name_key
'                    End If

'                    Call chkname(txtfields(Index).Text)

'                    If valid_name = "N" Then
'                        screen_nam(Index).Text = ""
'                        MsgBox("Invalid Number")
'                        Call ets_set_selected()
'                        package_Type = saved_package_Type
'                        GoTo EventExitSub
'                    Else
'                        screen_nam(Index).Text = selected_screen_nam
'                    End If

'                    Call bank_nameget(txtfields(Index).Text) 'this is the bank
'                    TextBox11.Text = bank_dr_acct_nu
'                    package_Type = saved_package_Type

'                Case 19   '19 = name_key
'                    If Val(txtfields(Index).Text) = 0 Then
'                        frmnamechk.ShowDialog()
'                        txtfields(Index).Text = selected_name_key
'                    End If

'                    Call chkname(txtfields(Index).Text)

'                    If valid_name = "N" Then
'                        screen_nam(Index).Text = ""
'                        MsgBox("Invalid Number")
'                        Call ets_set_selected()
'                        package_Type = saved_package_Type
'                        GoTo EventExitSub

'                    Else
'                        screen_nam(Index).Text = selected_screen_nam
'                    End If
'                    Call cust_nameget(txtfields(Index).Text) 'also modified the ar_mod

'                    If cust_type = "C" Or cust_type = "M" Then
'                        txtfields(13).Text = "MISC" 'this is donor field
'                    End If
'                    TextBox10.Text = cust_dr_acct_nu

'                Case 1 'fiscal month
'                    If IsNumeric(txtfields(Index).Text) Then
'                        If Len(txtfields(Index).Text) <> 4 Then
'                            If Len(txtfields(Index).Text) = 3 Then
'                                txtfields(Index).Text = "0" & txtfields(Index).Text
'                            Else
'                                MsgBox("You must enter four digits.")
'                                Call ets_set_selected()
'                                GoTo EventExitSub
'                            End If
'                        End If
'                    Else
'                        MsgBox("You must enter fiscal month and year as MMYY.")
'                        Call ets_set_selected()
'                        GoTo EventExitSub
'                    End If
'                    function_type = "READY_PAY"

'                Case 2 ' check to see if contract
'                    '  function_type = "READY_PAY"
'                    txtfields(Index).Text = UCase(txtfields(Index).Text)
'                    If Len(txtfields(Index).Text) = 0 Then
'                        contnumlookup.ShowDialog()
'                        txtfields(Index).Text = selected_cont_id_num
'                    Else
'                        If ETSCommon.CheckYN("cc_Cont", "contract_key", selected_contract_key, "N") = "N" Then
'                            MsgBox("The contract does not exist.")
'                            Call ets_set_selected()
'                            GoTo EventExitSub
'                        End If
'                    End If
'                    TextBox4.Text = String.Format("{0:F2}", CDec(ETSSQL.GetOneSQLValue("select redpy_dol as TheValue  from cc_cont where contract_key = '" & selected_contract_key & "'")))
'                    TextBox10.Text = ETSSQL.GetOneSQLValue("select dr_acct_nu as TheValue from cc_cont where contract_key = '" & selected_contract_key & "'")
'                    SaveRP.Focus()
'                    Exit Sub
'                Case 3 'are amounts
'                    If Not IsNumeric(txtfields(Index).Text) Then txtfields(Index).Text = "0"
'                    txtfields(Index).Text = String.Format("{0:F2}", CDec(txtfields(Index).Text))
'                    selected_proc_dol_actual = CDec(txtfields(Index).Text)

'                Case 5 'invoice
'                    txtfields(Index).Text = UCase(txtfields(Index).Text)
'                    'check the invoice string if match go on else lookup
'                    If Len(txtfields(Index).Text) = 0 Then
'                        function_type = "DATA_ENTRY"
'                        invoicelookup.ShowDialog()
'                        txtfields(Index).Text = ETSSQL.GetOneSQLValue("select invoice as TheValue  from invoice where inv_num = '" & selected_lookup_num & "'")
'                        screen_nam(Index).Text = ETSSQL.GetOneSQLValue("select inv_desc as TheValue  from invoice where inv_num = '" & selected_lookup_num & "'")
'                        selected_inv_num = CInt(selected_lookup_num)
'                        Call calc_tot_inv()
'                        _screen_nam_5.Text = ETSSQL.GetOneSQLValue("select screen_nam as TheValue  from invoice where inv_num = '" & selected_lookup_num & "'")
'                    Else
'                        sqlstmnt = "Select * from invoice where void = 'N' and invoice = '" & txtfields(5).Text & "'"
'                        If ETSCommon.CheckNumRecords(sqlstmnt) = 0 Then
'                            Response = MsgBox("This invoice number does not exist. Is this an advance payment?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
'                            If Response = MsgBoxResult.No Then
'                                Call ets_set_selected()
'                                GoTo EventExitSub
'                            Else
'                                adv_flag = "Y"
'                                SaveInv.Focus()
'                                GoTo EventExitSub
'                            End If
'                        Else
'                            function_type = "INVOICE"
'                        End If
'                    End If
'                    selected_invoice = txtfields(5).Text
'                    TextBox10.Text = ETSSQL.GetOneSQLValue("select dr_Acct_nu as TheValue from invoice where void = 'N' and invoice = '" & selected_invoice & "'")
'                    TextBox1.Focus()
'                    GoTo EventExitSub

'                Case 8 'date fields

'                    If Len(txtfields(Index).Text) = 0 Then
'                        System.Windows.Forms.SendKeys.Send("{tab}")
'                        KeyAscii = 0
'                        GoTo EventExitSub
'                    End If

'                    valid_Date = "N"
'                    senddate = txtfields(Index).Text
'                    Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")

'                    If retdate = "N" Then
'                        senddate = ""
'                        MsgBox(" Bad Date")
'                        Call ets_set_selected()
'                        GoTo EventExitSub
'                    Else
'                        txtfields(Index).Text = CDate(retdate).ToShortDateString
'                    End If

'                Case 16
'                    tot_amt = CDec(Val(txtfields(16).Text))
'                    ret2 = String.Format("{0:f2}", tot_amt)
'                    ar_inv_amt_choose.ShowDialog()
'                    'the inv num comes back and need to find it
'                    'if cancelled then selected_lookup_num is blank so skip
'                    If selected_lookup_num <> "" Then
'                        txtfields(5).Text = ETSSQL.GetOneSQLValue("select invoice as TheValue  from invoice where void = 'N' and inv_num = '" & selected_lookup_num & "'")
'                        screen_nam(5).Text = ETSSQL.GetOneSQLValue("select inv_desc as TheValue  from invoice where void = 'N' and inv_num = '" & selected_lookup_num & "'")
'                        Call calc_tot_inv()
'                        selected_inv_num = CInt(selected_lookup_num)
'                        TextBox1.Focus()
'                    End If

'                    GoTo EventExitSub
'            End Select

'            System.Windows.Forms.SendKeys.Send("{tab}")
'            KeyAscii = 0
'        End If
'EventExitSub:
'        eventArgs.KeyChar = Chr(KeyAscii)
'        If KeyAscii = 0 Then
'            eventArgs.Handled = True
'        End If
'    End Sub

'    Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
'        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
'        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

'    End Sub

'    Private Sub SaveRP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveRP.Click
'        Call CheckData()
'        If ErrFlag = 1 Then
'            ErrFlag = 0
'            Exit Sub
'        End If

'        If Len(Trim(txtfields(2).Text)) = 0 Then 'to see if we skipped the contract entry
'            MsgBox("You must enter something in the contract field")
'            txtfields(2).Focus()
'            KeyAscii = 0
'            Exit Sub
'        End If

'        Call CreateNewCashReceipt()
'        'look up contract data
'        sqlstmnt = "select name_key as theValue from cc_Cont where contract_key = '" & selected_contract_key & "'"
'        If ETSCommon.CheckNumRecords(sqlstmnt) = 0 Then
'            MsgBox("Since you do not have a contract file the gl account numbers will be missing.")
'            msg = InputBox("Please enter an invoice for this ready payment.")
'            NewCashReceipt.Invoice = msg
'        Else
'            Call chkname_top(ETSSQL.GetOneSQLValue(sqlstmnt))
'            NewCashReceipt.NameKey = selected_name_key
'            NewCashReceipt.ScreenNam = selected_screen_nam
'            NewCashReceipt.SortName = selected_sort_name
'            '		'generate the inv string
'            pr_end_date_tmp = CDate(VB.Left(txtfields(1).Text, 2) & "/15/" & VB.Right(txtfields(1).Text, 2))

'            pr_end_date_tmp = DateAdd(Microsoft.VisualBasic.DateInterval.Month, -6, pr_end_date_tmp)
'            msg = (invoice_string_Create(CStr(pr_end_date_tmp), msg))
'            If Len(msg) = 0 Then
'                msg = InputBox("Please enter an invoice for this ready payment.")
'            End If
'            NewCashReceipt.Invoice = msg
'            NewCashReceipt.CrAcctNu = ETSSQL.GetOneSQLValue("select dr_Acct_nu as TheValue from cc_Cont where contract_key = '" & selected_contract_key & "'")
'        End If

'        'fill data from invoice
'        NewCashReceipt.EntryNum = saved_entry_num + 1
'        NewCashReceipt.TransCode = "ADV"
'        ' NewCashReceipt.CrAcctNu = InvRec.DrAcctNu
'        NewCashReceipt.DrAcctNu = bank_dr_acct_nu
'        NewCashReceipt.ChkDisc = 0
'        NewCashReceipt.ChkNum = TextBox3.Text
'        NewCashReceipt.ChkDate = CDate(txtfields(8).Text)
'        NewCashReceipt.GrossAmt = CDec(txtfields(3).Text)
'        NewCashReceipt.CheckAmt = CDec(txtfields(3).Text)
'        NewCashReceipt.ChkAlloc = CDec(TextBox4.Text)
'        NewCashReceipt.Invoice = "MISC"
'        NewCashReceipt.TransCode = "PMT"
'        'no invoice so no data
'        'Dim InvRec As New CompanyInvoiceData
'        'InvRec = ETSSQL.GetCompanyInvoiceDataOne(sqlstmnt)
'        'NewCashReceipt.InvNum = InvRec.InvNum
'        'NewCashReceipt.LineNum = InvRec.LineNum

'        Call FinishReceipt()
'        For Each Me.cntrl In Me.Controls
'            If TypeOf cntrl Is TextBox Then
'                Form.ActiveForm.ActiveControl.BackColor = Color.White
'            End If
'        Next
'        txtfields(1).Focus()
'    End Sub

'    Private Sub SaveInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveInv.Click

'        'advance payment sets a flag = adv_flag = 1
'        Call CheckData()
'        If ErrFlag = 1 Then
'            ErrFlag = 0
'            Exit Sub
'        End If
'        'got here since only one line or do not want to see the detail
'        sqlstmnt = "select * from invoice where void = 'N' and inv_num = " & selected_inv_num
'        If ETSCommon.CheckNumRecords(sqlstmnt) = 1 Then
'            'fill data from screen
'            Call CreateNewCashReceipt()
'            'fill data from invoice
'            NewCashReceipt.EntryNum = saved_entry_num + 1
'            Dim InvRec As New CompanyInvoiceData
'            InvRec = ETSSQL.GetCompanyInvoiceDataOne(sqlstmnt)
'            NewCashReceipt.NameKey = InvRec.NameKey
'            NewCashReceipt.ScreenNam = InvRec.ScreenNam
'            NewCashReceipt.SortName = InvRec.SortName
'            NewCashReceipt.InvNum = InvRec.InvNum
'            NewCashReceipt.LineNum = InvRec.LineNum
'            NewCashReceipt.Invoice = InvRec.Invoice
'            NewCashReceipt.TransCode = "PMT"
'            NewCashReceipt.CrAcctNu = InvRec.DrAcctNu
'            NewCashReceipt.DrAcctNu = bank_dr_acct_nu
'            NewCashReceipt.ChkDisc = 0
'            NewCashReceipt.ChkNum = TextBox3.Text
'            NewCashReceipt.ChkDate = CDate(txtfields(8).Text)
'            NewCashReceipt.GrossAmt = CDec(txtfields(3).Text)
'            NewCashReceipt.CheckAmt = CDec(txtfields(3).Text)
'            NewCashReceipt.ChkAlloc = CDec(TextBox1.Text)
'            Call FinishReceipt()
'        Else
'            Dim Invoices As List(Of CompanyInvoiceData)
'            Invoices = ETSSQL.GetCompanyInvoiceData(sqlstmnt)
'            For Each inv In Invoices
'                saved_entry_num = saved_entry_num + 1
'                Call CreateNewCashReceipt()
'                NewCashReceipt.EntryNum = saved_entry_num
'                NewCashReceipt.NameKey = inv.NameKey
'                NewCashReceipt.ScreenNam = inv.ScreenNam
'                NewCashReceipt.SortName = inv.SortName
'                NewCashReceipt.InvNum = inv.InvNum
'                NewCashReceipt.LineNum = inv.LineNum
'                NewCashReceipt.Invoice = inv.Invoice
'                NewCashReceipt.TransCode = "PMT"
'                NewCashReceipt.CrAcctNu = inv.DrAcctNu
'                NewCashReceipt.DrAcctNu = bank_dr_acct_nu
'                NewCashReceipt.ChkDisc = 0
'                NewCashReceipt.ChkNum = TextBox3.Text
'                NewCashReceipt.ChkDate = CDate(txtfields(8).Text)
'                NewCashReceipt.GrossAmt = CDec(txtfields(3).Text)
'                NewCashReceipt.CheckAmt = CDec(txtfields(3).Text)
'                NewCashReceipt.ChkAlloc = inv.BalDue
'                Call FinishReceipt()
'            Next
'        End If

'        If CDec(UnAppChk.Text) <> 0 Then
'            txtfields(5).Focus()
'        Else
'            TextBox3.Focus()
'        End If


'    End Sub

'    Private Sub SaveVend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveVend.Click
'        PutCashHeader()
'        ar_det_app.AccessibleDescription = TextBox16.Text
'        saved_entry_type = entry_type
'        function_type = "VENDOR"
'        ar_det_app.ShowDialog()
'        If entry_type = "CANCEL" Then
'            MsgBox("The entry was cancelled. No Cash applied")
'            entry_type = saved_entry_type
'        End If

'        Call RePaintHeader()
'        entry_type = saved_entry_type
'        For Each Me.cntrl In Me.Controls
'            If TypeOf cntrl Is TextBox Then
'                Form.ActiveForm.ActiveControl.BackColor = Color.White
'            End If
'        Next
'        TextBox9.Focus()

'    End Sub

'    Private Sub SaveClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveClient.Click

'        PutCashHeader()
'        ar_det_app.AccessibleDescription = TextBox16.Text
'        saved_entry_type = entry_type
'        function_type = "CLIENT"
'        ar_det_app.ShowDialog()
'        If entry_type = "CANCEL" Then
'            MsgBox("The entry was cancelled. No Cash applied")
'            entry_type = saved_entry_type
'        End If
'        Call RePaintHeader()
'        entry_type = saved_entry_type
'        For Each Me.cntrl In Me.Controls
'            If TypeOf cntrl Is TextBox Then
'                Form.ActiveForm.ActiveControl.BackColor = Color.White
'            End If
'        Next
'        TextBox15.Focus()

'    End Sub

'    Private Sub SaveMisc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveMisc.Click
'        Call CheckData()
'        If ErrFlag = 1 Then
'            ErrFlag = 0
'            Exit Sub
'        End If

'        'check for something in memo or donor
'        If Len(txtfields(13).Text) = 0 Then 'donor
'            If Len(txtfields(17).Text) = 0 Then 'memo
'                MsgBox("Either the reference or memo field must be filled in.")
'                txtfields(19).Focus()
'                Exit Sub
'            End If
'        End If

'        Call CreateNewCashReceipt()
'        'fill data from invoice
'        NewCashReceipt.EntryNum = saved_entry_num + 1
'        NewCashReceipt.DrAcctNu = bank_dr_acct_nu
'        NewCashReceipt.ChkDisc = 0
'        NewCashReceipt.ChkNum = TextBox3.Text
'        NewCashReceipt.ChkDate = CDate(txtfields(8).Text)
'        NewCashReceipt.GrossAmt = CDec(txtfields(3).Text)
'        NewCashReceipt.CheckAmt = CDec(txtfields(3).Text)
'        NewCashReceipt.ChkAlloc = CDec(TextBox5.Text)
'        NewCashReceipt.Invoice = "MISC"
'        NewCashReceipt.TransCode = "PMT"
'        Call chkname_top(txtfields(19).Text)
'        NewCashReceipt.NameKey = selected_name_key
'        NewCashReceipt.ScreenNam = selected_screen_nam
'        NewCashReceipt.SortName = selected_sort_name
'        NewCashReceipt.CrAcctNu = TextBox10.Text

'        Call FinishReceipt()
'        If CDec(UnAppChk.Text) <> 0 Then
'            txtfields(19).Focus()
'        Else
'            TextBox3.Focus()
'        End If

'    End Sub

'    Private Sub CheckData()
'        'check header - amount -acct number
'        ErrFlag = 0
'        If Len(txtfields(0).Text) = 0 Or Len(txtfields(10).Text) = 0 Or Len(txtfields(15).Text) = 0 Then
'            MsgBox("You must enter the header information.")
'            bat_Amt.Focus()
'            ErrFlag = 1
'            Exit Sub
'        End If

'        If Len(txtfields(3).Text) = 0 Then
'            MsgBox("You must enter an amount.")
'            txtfields(3).Focus()
'            ErrFlag = 1
'            Exit Sub
'        End If

'        If ETSCommon.CheckNumRecords("select * from chacct where jriacct = '" & TextBox10.Text & "'") = 0 Then
'            MsgBox("You must enter a cr account.")
'            TextBox10.Focus()
'            ErrFlag = 1
'            Exit Sub
'        End If

'        If ETSCommon.CheckNumRecords("select * from chacct where jriacct = '" & TextBox11.Text & "'") = 0 Then
'            MsgBox("You must enter a cr account.")
'            TextBox11.Focus()
'            ErrFlag = 1
'            Exit Sub
'        End If

'    End Sub

'    Private Sub PutCashHeader()
'        TmpCashReceiptHeader = ETSSQL.GetBlankCashReceiptHeader
'        TmpCashReceiptHeader.BankKey = txtfields(0).Text
'        TmpCashReceiptHeader.BatchDate = CDate((start_date1.Text))
'        TmpCashReceiptHeader.BatchDesc = txtfields(10).Text
'        TmpCashReceiptHeader.BatchNum = CInt(txtfields(15).Text)
'        TmpCashReceiptHeader.BatchTotal = CDec(bat_Amt.Text)
'        If Len(TextBox16.Text) <> 0 Then
'            TmpCashReceiptHeader.EncumDate = CDate((TextBox16.Text))
'        Else
'            TmpCashReceiptHeader.EncumDate = CDate((start_date1.Text))
'        End If
'        TmpCashReceiptHeader.EntryDate = Today
'        TmpCashReceiptHeader.CheckAmt = CDec(txtfields(3).Text)
'        TmpCashReceiptHeader.ChkDate = CDate(txtfields(8).Text)
'        TmpCashReceiptHeader.ChkNum = TextBox3.Text
'        TmpCashReceiptHeader.GrossAmt = CDec(txtfields(3).Text)
'        TmpCashReceiptHeader.ChkDisc = 0

'        ar_det_app.Tag = txtfields(3).Text

'    End Sub

'    Private Sub CreateNewCashReceipt()
'        newcashreceipt = ETSSQL.GetBlankCashReceiptData

'        NewCashReceipt.Agency = AgencyNum
'        NewCashReceipt.BankKey = txtfields(0).Text
'        NewCashReceipt.BatchDate = CDate((start_date1.Text))
'        NewCashReceipt.BatchDesc = txtfields(10).Text
'        NewCashReceipt.BatchNum = CInt(txtfields(15).Text)
'        NewCashReceipt.BatchTotal = CDec(bat_Amt.Text)
'        NewCashReceipt.CrAcctNu = TextBox10.Text
'        NewCashReceipt.DrAcctNu = TextBox11.Text
'        NewCashReceipt.EncumDate = CDate((start_date1.Text))
'        NewCashReceipt.EntryDate = Today
'        newcashreceipt.Memo = TextBox2.Text
'        NewCashReceipt.SM = "M"
'        NewCashReceipt.VoidChk = "N"
'        NewCashReceipt.Dflag = "N"
'        NewCashReceipt.Donor = ""
'        NewCashReceipt.Memo = ""
'        NewCashReceipt.Fund = ""
'        NewCashReceipt.JrnlLine = 0
'        NewCashReceipt.JrnlNum = 0
'        NewCashReceipt.DiscAcct = ""
'        NewCashReceipt.Glpost = "N"
'        NewCashReceipt.Checked = "N"

'        If adv_flag = "Y" Then
'            NewCashReceipt.TransCode = "ADV"
'            adv_flag = "N"
'        End If

'        If adv_flag = "X" Then
'            NewCashReceipt.TransCode = "ADVX"
'            adv_flag = "N"
'        End If

'    End Sub

'    Private Sub FinishReceipt()

'        last_amt.Text = String.Format("{0:F2}", NewCashReceipt.ChkAlloc)
'        last_chk.Text = NewCashReceipt.ChkNum

'        Call PutCashReceipt()
'        NewCashReceipt = Nothing

'        Call RePaintHeader()

'    End Sub

'    Private Sub PutCashReceipt()
'        'we now have a good array and if edit old data needs to be removed

'        Select Case entry_type
'            Case "EDIT"
'                sqlstmnt = "Delete from cash_tmp1 where batch_num = '" & selected_bat_num & "' and entry_num = '" & selected_line_num & "'"
'                ETSSQL.ExecuteSQL(sqlstmnt)
'        End Select

'        sqlstmnt = "Insert into Cash_tmp1 " & NewCashReceipt.CashReceiptColumnNames & " values " & NewCashReceipt.CashReceiptColumnData
'        ETSSQL.ExecuteSQL(sqlstmnt)

'    End Sub

'    Private Sub RePaintHeader()
'        'clear all but the header and repaint
'        For Each Me.cntrl In Me.Controls
'            If TypeOf cntrl Is TextBox Then
'                cntrl.Text = ""
'                cntrl.BackColor = Color.White
'            End If
'        Next
'        If ETSCommon.CheckNumRecords("select * from cash_tmp1 where batch_num  = '" & selected_bat_num & "'") = 0 Then
'            start_date1.Focus()
'            Exit Sub
'        Else
'            RowData = ETSSQL.GetData("cash_tmp1", " where batch_num  = '" & selected_bat_num & "' order by entry_num")
'            txtfields(0).Text = RowData.Item(0).ActualData
'            start_date1.Text = CDate(RowData.Item(1).ActualData).ToShortDateString
'            txtfields(10).Text = RowData.Item(31).ActualData
'            txtfields(15).Text = RowData.Item(30).ActualData
'            bat_Amt.Text = String.Format("{0:F2}", CDec(RowData.Item(33).ActualData))
'            sqlstmnt = "select top (1) entry_num as TheValue from cash_tmp1  where batch_num = '" & selected_bat_num & "' order by entry_num DESC"
'            saved_entry_num = CInt(ETSSQL.GetOneSQLValue(sqlstmnt))
'            txtfields(8).Text = CDate(RowData.Item(6).ActualData).ToShortDateString
'            txtfields(3).Text = String.Format("{0:F2}", CDec(RowData.Item(7).ActualData.ToString))
'            TextBox3.Text = RowData.Item(5).ActualData.ToString
'            last_amt.Text = String.Format("{0:F2}", RowData.Item(9).ActualData.ToString)
'            last_chk.Text = RowData.Item(5).ActualData.ToString
'            TextBox11.Text = bank_dr_acct_nu
'            adv_flag = "N"

'            Call bat_tot()
'            Call calc_tot_inv()
'            bat_Amt.Text = String.Format("{0:F2}", CDec(bat_Amt.Text))
'            last_amt.Text = String.Format("{0:F2}", CDec(last_amt.Text))
'            txtfields(3).Text = String.Format("{0:F2}", CDec(txtfields(3).Text))
'        End If
'    End Sub

'    Private Sub textbox_enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextBox10.Enter, TextBox11.Enter, TextBox13.Enter, TextBox15.Enter, TextBox16.Enter, TextBox2.Enter, TextBox3.Enter, TextBox7.Enter, TextBox9.Enter, TextBox1.Enter, TextBox4.Enter, TextBox5.Enter
'        Form.ActiveForm.ActiveControl.BackColor = Color.Aqua '(RGB(0, 255, 255))
'        Call ets_set_selected()
'    End Sub

'    Private Sub textbox_leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextBox10.Leave, TextBox11.Leave, TextBox13.Leave, TextBox15.Leave, TextBox16.Leave, TextBox2.Leave, TextBox3.Leave, TextBox7.Leave, TextBox9.Leave, TextBox1.Leave, TextBox4.Leave, TextBox5.Leave
'        ' System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
'        For Each Me.cntrl In Me.Controls
'            If TypeOf cntrl Is TextBox Then
'                Me.cntrl.BackColor = Color.White
'            End If
'        Next
'    End Sub

'    Private Sub textbox10_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox10.KeyDown
'        ' Determine whether the key entered is the F1 key. If it is, display Help. 
'        If e.KeyCode = Keys.Enter Then
'            If Len(TextBox10.Text) = 0 Then
'                saved_function_Type = function_type
'                function_type = "DATA_ENTRY"
'                Call etsacctnum_chk(TextBox10.Text)

'                If valid_acct = "N" Then
'                    MsgBox("Not a valid account number.")
'                    Call ets_set_selected()
'                    GoTo EventExitSub
'                End If

'                TextBox10.Text = retacct
'                function_type = saved_function_Type
'            End If
'            System.Windows.Forms.SendKeys.Send("{tab}")
'            KeyAscii = 0
'            Form.ActiveForm.ActiveControl.BackColor = Color.White
'        End If
'EventExitSub:
'        'e.KeyChar = Chr(KeyAscii)
'        If KeyAscii = 0 Then
'            e.Handled = True
'        End If



'    End Sub 'textBox1_KeyDown

'    Private Sub textbox11_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox11.KeyDown
'        ' Determine whether the key entered is the F1 key. If it is, display Help. 
'        If e.KeyCode = Keys.Enter Then
'            If Len(TextBox11.Text) = 0 Then
'                saved_function_Type = function_type
'                function_type = "DATA_ENTRY"
'                Call etsacctnum_chk(TextBox11.Text)

'                If valid_acct = "N" Then
'                    MsgBox("Not a valid account number.")
'                    Call ets_set_selected()
'                    GoTo EventExitSub
'                End If

'                TextBox11.Text = retacct
'                function_type = saved_function_Type
'            End If
'            System.Windows.Forms.SendKeys.Send("{tab}")
'            KeyAscii = 0
'            Form.ActiveForm.ActiveControl.BackColor = Color.White
'        End If
'EventExitSub:
'        '  e.KeyChar = Chr(KeyAscii)
'        If KeyAscii = 0 Then
'            e.Handled = True
'        End If

'    End Sub 'textBox1_KeyDown

'    Private Sub TextBox1_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
'        'amt to be applied to this invoice
'        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
'        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
'            If Not IsNumeric(TextBox1.Text) Then
'                MsgBox("Please enter an amount to be applied to this invoice.")
'                Call ets_set_selected()
'                GoTo EventExitSub
'            Else
'                sqlstmnt = "Select * from invoice where void = 'N' and invoice = '" & txtfields(5).Text & "'"
'                If ETSCommon.CheckNumRecords(sqlstmnt) <> 1 Then
'                    PutCashHeader()
'                    ar_det_app.Tag = TextBox1.Text
'                    'if many lines and full pay then ask if want detail
'                    If Val(TextBox1.Text) = Val(ETSSQL.GetOneSQLValue("select sum(bal_due) as TheValue from invoice where void = 'N' and invoice = '" & selected_invoice & "'")) Then
'                        Response = MsgBox("this will fully pay the invoice.  Do you wish to see the detail?", vbYesNo)
'                        If Response = vbNo Then
'                            SaveInv.Focus()
'                            Exit Sub
'                        Else
'                            ar_det_app.ShowDialog()
'                            If entry_type = "CANCEL" Then
'                                MsgBox("The entry was cancelled. No Cash applied")
'                                entry_type = saved_entry_type
'                            End If
'                            Call RePaintHeader()
'                            txtfields(5).Focus()
'                            GoTo EventExitSub
'                            'based on if check all allocated wherhter go back to invoice or back to check
'                            'also fill in the maount to be allocated
'                        End If
'                    Else
'                        ar_det_app.ShowDialog()
'                        If entry_type = "CANCEL" Then
'                            MsgBox("The entry was cancelled. No Cash applied")
'                            entry_type = saved_entry_type
'                        End If
'                        Call RePaintHeader()
'                        txtfields(5).Focus()
'                        GoTo EventExitSub
'                        'based on if check all allocated wherhter go back to invoice or back to check
'                        'also fill in the maount to be allocated
'                    End If
'                End If
'            End If
'            System.Windows.Forms.SendKeys.Send("{tab}")
'            KeyAscii = 0
'        End If
'EventExitSub:
'        e.KeyChar = Chr(KeyAscii)
'        If KeyAscii = 0 Then
'            e.Handled = True
'        End If

'    End Sub

'    Private Sub TextBox2_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
'        'amt to be applied to this invoice
'        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
'        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
'            System.Windows.Forms.SendKeys.Send("{tab}")
'            KeyAscii = 0
'        End If
'EventExitSub:
'        e.KeyChar = Chr(KeyAscii)
'        If KeyAscii = 0 Then
'            e.Handled = True
'        End If

'    End Sub

'    Private Sub Textbox4_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
'        'amt to be applied to this invoice
'        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
'        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
'            If Not IsNumeric(TextBox4.Text) Then
'                MsgBox("Please enter an amount to be applied.")
'                Call ets_set_selected()
'                GoTo EventExitSub
'            Else
'                System.Windows.Forms.SendKeys.Send("{tab}")
'                KeyAscii = 0
'                Form.ActiveForm.ActiveControl.BackColor = Color.White
'            End If
'        End If
'EventExitSub:
'        e.KeyChar = Chr(KeyAscii)
'        If KeyAscii = 0 Then
'            e.Handled = True
'        End If

'    End Sub

'    Private Sub Textbox5_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
'        'amt to be applied to this invoice
'        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
'        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
'            If Not IsNumeric(TextBox5.Text) Then
'                MsgBox("Please enter an amount to be applied.")
'                Call ets_set_selected()
'                GoTo EventExitSub
'            Else
'                System.Windows.Forms.SendKeys.Send("{tab}")
'                KeyAscii = 0
'                Form.ActiveForm.ActiveControl.BackColor = Color.White
'            End If
'        End If
'EventExitSub:
'        e.KeyChar = Chr(KeyAscii)
'        If KeyAscii = 0 Then
'            e.Handled = True
'        End If

'    End Sub
'    Private Sub TextBox3_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
'        'vendor
'        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
'        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
'            TextBox3.Text = UCase(TextBox3.Text)
'            'get how many $ are paid on this check and put into box
'            txtfields(8).Text = start_date1.Text
'            System.Windows.Forms.SendKeys.Send("{tab}")
'            KeyAscii = 0
'            Form.ActiveForm.ActiveControl.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
'        End If
'EventExitSub:
'        e.KeyChar = Chr(KeyAscii)
'        If KeyAscii = 0 Then
'            e.Handled = True
'        End If

'    End Sub

'    Private Sub TextBox9_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
'        'vendor
'        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
'        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
'            If Len(TextBox9.Text) = 0 Then
'                saved_package_Type = package_Type
'                package_Type = "AR"
'                frmnamechk.ShowDialog()
'                package_Type = saved_package_Type
'                TextBox9.Text = selected_name_key
'            End If
'            Call chkname(TextBox9.Text)
'            If valid_name = "N" Then
'                TextBox7.Text = ""
'                MsgBox("Invalid Number")
'                Call ets_set_selected()
'                package_Type = saved_package_Type
'                GoTo EventExitSub
'            Else
'                TextBox7.Text = selected_screen_nam
'            End If
'            System.Windows.Forms.SendKeys.Send("{tab}")
'            KeyAscii = 0
'            Form.ActiveForm.ActiveControl.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
'        End If
'EventExitSub:
'        e.KeyChar = Chr(KeyAscii)
'        If KeyAscii = 0 Then
'            e.Handled = True
'        End If

'    End Sub

'    Private Sub TextBox15_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox15.KeyPress
'        'client
'        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
'        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
'            If Len(TextBox15.Text) = 0 Then
'                saved_package_Type = package_Type
'                package_Type = "ATT"
'                frmnamechk.ShowDialog()
'                package_Type = saved_package_Type
'                TextBox15.Text = selected_name_key
'            End If
'            Call chkname(TextBox15.Text)
'            If valid_name = "N" Then
'                TextBox13.Text = ""
'                MsgBox("Invalid Number")
'                Call ets_set_selected()
'                package_Type = saved_package_Type
'                GoTo EventExitSub
'            Else
'                TextBox13.Text = selected_screen_nam
'            End If
'            System.Windows.Forms.SendKeys.Send("{tab}")
'            KeyAscii = 0
'            Form.ActiveForm.ActiveControl.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
'            function_type = "CLIENT"
'            ar_det_app.ShowDialog()
'            SaveClient.Focus()
'        End If

'EventExitSub:
'        e.KeyChar = Chr(KeyAscii)
'        If KeyAscii = 0 Then
'            e.Handled = True
'        End If
'    End Sub

'    Private Sub TextBox16_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox16.KeyPress
'        'encumbered date
'        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
'        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
'            Dim retdate As String = ETS.Common.Module1.etsdate(TextBox16.Text, "N")
'            If retdate = "N" Then
'                senddate = ""
'                MsgBox(" Bad Date")
'                Call ets_set_selected()
'                GoTo EventExitSub
'            Else
'                TextBox16.Text = CDate(retdate).ToShortDateString
'            End If

'            SaveVend.Focus()
'        End If

'EventExitSub:
'        e.KeyChar = Chr(KeyAscii)
'        If KeyAscii = 0 Then
'            e.Handled = True
'        End If

'    End Sub

'End Class