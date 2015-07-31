Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System
Imports System.IO
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports System.ComponentModel



Public Class bill_attend
    Inherits System.Windows.Forms.Form
    Public InvoiceLocation As String = ConfigurationManager.AppSettings("InvoiceLocation")
    Public selected_id_num As String


    Private Sub bill_attend_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

        DataGridView1.Columns.Add("Contract_key", "Contract")
        DataGridView1.Columns.Item(0).DataPropertyName = "Contract_key"
        DataGridView1.Columns.Add("Cont_desc", "Description")
        DataGridView1.Columns.Item(1).DataPropertyName = "Cont_desc"
        DataGridView1.Columns.Add("bill_type", "Bill Type")
        DataGridView1.Columns.Item(2).DataPropertyName = "bill_type"
        DataGridView1.Columns.Add("pv_form", "PV")
        DataGridView1.Columns.Item(3).DataPropertyName = "pv_Form"
        DataGridView1.Columns.Add("rpt_Type", "Report")
        DataGridView1.Columns.Item(4).DataPropertyName = "rpt_type"

        Dim HeaderDates As String() = ETSCommon.GetBeginEndDates.Split(CChar("*"))
        start_date.Text = HeaderDates(0)
        End_Date.Text = HeaderDates(1)

    End Sub

    Public Sub batch_bill()

        If selected_bill_type <= "170" Then
            update_contract_ytd(selected_contract_key)
            Call prepare_attend_rpt(selected_contract_key, start_date.Text, End_Date.Text)
        Else
            '  Call prepare_medopn_tmp_bill()
        End If
    End Sub

    Private Sub detail_print(ByVal selected_rpt_num As String)
        'sends reports to pdf without review
        'break it into reports 3 characters long - get teh report path from rot type and print hte report
        Dim tmp_report_path As String
        Dim RptData As New List(Of ReportTypeData)
        sqlstmnt = "select * from rpt_type where rpt_num = '" & selected_rpt_num & "'"
        RptData = ETSSQL.GetRptTypeData(sqlstmnt)

        tmp_report_path = RptData.Item(0).RptPath
        If Len(tmp_report_path) = 0 Then
            tmp_report_path = att_report_path
        End If
        prtPrinterName = RptData.Item(0).RptPrinter
        prtreportfilename = tmp_report_path & RptData.Item(0).RptName
        prtWindowState = 2
        prtDestination = 2
        CrystalForm.ShowDialog()

    End Sub

    Private Sub detail_review(ByVal selected_rpt_num As String)
        'sends report to screen 
        'comes one reporet at a time so no need to
        'break it into reports 3 characters long - get teh report path from rot type and print hte report
        Dim tmp_report_path As String = ""
        Dim RptData As New List(Of ReportTypeData)
        sqlstmnt = "select * from rpt_type where rpt_num = '" & selected_rpt_num & "'"
        RptData = ETSSQL.GetRptTypeData(sqlstmnt)

        tmp_report_path = RptData.Item(0).RptPath
        If Len(tmp_report_path) = 0 Then
            tmp_report_path = att_report_path
        End If
        prtPrinterName = RptData.Item(0).RptPrinter
        prtreportfilename = tmp_report_path & RptData.Item(0).RptName
        prtDestination = 0      'to screen
        CrystalForm.ShowDialog()
        Response = MsgBox("Do you wish to save this as a PDF?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, MsgBoxStyle))
        If Response = MsgBoxResult.Yes Then
            prtDestination = 2     'to pdf
            CrystalForm.ShowDialog()
            KeyAscii = 0
        End If

    End Sub

    Private Sub CheckData()
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        If Not IsDate(start_date.Text) Then
            MsgBox("You need to enter a start date.")
            start_date.Focus()
            Exit Sub
        End If

        If Not IsDate(End_Date.Text) Then
            MsgBox("You need to enter an end date.")
            End_Date.Focus()
            Exit Sub
        End If

        If Len(invoice_string.Text) = 0 Then
            MsgBox("You need to enter an invoice number.")
            invoice_string.Focus()
            Exit Sub
        End If

        If Not IsDate(inv_date.Text) Then
            MsgBox("You need to enter an invoice date.")
            End_Date.Focus()
            Exit Sub
        End If

        If Not IsDate(encum_Date.Text) Then
            MsgBox("You need to enter an encumbered date.")
            End_Date.Focus()
            Exit Sub
        End If

        selected_inv_date = CDate(inv_date.Text)
        id_num = invoice_string.Text

    End Sub

    Public Sub update_records(ByVal id_num As String)
        tot_amt = 0
        sqlstmnt = "Select * from attend_rpt where contract_key = '" & selected_contract_key & "'"
        Dim AttendRptData As New List(Of AttendReportData)
        AttendRptData = ETSSQL.GetAttendReportData(sqlstmnt)

        Select Case ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "inv_type")
            Case "S"  ' takes data from first contract and creates invoice with amount from total of all

                For Each ARow In AttendRptData
                    tot_amt = CDec(tot_amt + ARow.DolTot)
                Next
                'creates attend_rpt_hist
                sqlstmnt = "insert into attend_rpt_hist " & AttendRptData.Item(0).AttendReportColumnNames & " values " & AttendRptData.Item(0).AttendReportColumnData
                ETSSQL.ExecuteSQL(sqlstmnt)
                Dim NewInvoice As New CompanyInvoiceData
                NewInvoice.Invoice = invoice_string.Text
                NewInvoice.LineNum = 1
                NewInvoice.TransCode = "INV"
                'invoice.Recordset.Fields("po_num") = ""
                NewInvoice.NameKey = AttendRptData.Item(0).CustNum
                'look up the proper name
                Call chkname_top(NewInvoice.NameKey)
                NewInvoice.ScreenNam = selected_screen_nam
                NewInvoice.SortName = selected_sort_name
                NewInvoice.InvDesc = selected_cont_desc
                NewInvoice.ContractKey = selected_contract_key
                NewInvoice.FromDate = AttendRptData.Item(0).AttBeg
                NewInvoice.ToDate = AttendRptData.Item(0).AttEnd
                NewInvoice.Units = AttendRptData.Item(0).UnitTot
                NewInvoice.CrAcctNu = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "cr_acct_nu")
                NewInvoice.DrAcctNu = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "dr_acct_nu")
                NewInvoice.UnitRate = AttendRptData.Item(0).UnitRate
                NewInvoice.EntryDate = Today
                NewInvoice.InvoiceDate = AttendRptData.Item(0).InvoiceDate
                NewInvoice.DtTbePd = DateAdd("d", 30, AttendRptData.Item(0).InvoiceDate)
                NewInvoice.EncumDate = CDate(encum_Date.Text)
                NewInvoice.BalDue = tot_amt
                NewInvoice.AllocAmt = tot_amt
                NewInvoice.InvAmt = 0
                NewInvoice.InvNum = GetNextCompanyInvoiceNum()
                'put the invoice in file
                sqlstmnt = "insert into invoice " & NewInvoice.CompanyInvoiceColumnNames & "  values " & NewInvoice.CompanyInvoiceColumnData
                ETSSQL.ExecuteSQL(sqlstmnt)
            Case "D"
                num = 0
                For Each ARow In AttendRptData
                    ' tot_amt = CDec(tot_amt + ARow.DolTot)

                    sqlstmnt = "insert into attend_rpt_hist " & ARow.AttendReportColumnNames & " values " & ARow.AttendReportColumnData
                    ETSSQL.ExecuteSQL(sqlstmnt)
                    Dim NewInvoice As New CompanyInvoiceData
                    NewInvoice = ETSSQL.GetBlankCompanyInvoiceData
                    If num = 0 Then
                        NewInvoice.InvNum = GetNextCompanyInvoiceNum()
                        save_invoice_num = CStr(NewInvoice.InvNum)
                    Else
                        NewInvoice.InvNum = CInt(save_invoice_num)
                    End If
                    NewInvoice.Invoice = invoice_string.Text
                    NewInvoice.LineNum = 1 + num
                    NewInvoice.TransCode = "INV"
                    NewInvoice.PoNum = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "lea_order_nu")
                    NewInvoice.NameKey = AttendRptData.Item(num).CustNum
                    'look up the proper name
                    Call chkname_top(NewInvoice.NameKey)
                    NewInvoice.ScreenNam = selected_screen_nam
                    NewInvoice.SortName = selected_sort_name
                    NewInvoice.CcNum = AttendRptData.Item(num).NameKey
                    NewInvoice.CcName = AttendRptData.Item(num).ScreenNam
                    NewInvoice.InvDesc = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "cont_desc")
                    NewInvoice.ContractKey = selected_contract_key
                    NewInvoice.FromDate = AttendRptData.Item(num).AttBeg
                    NewInvoice.ToDate = AttendRptData.Item(num).AttEnd
                    NewInvoice.Units = AttendRptData.Item(num).UnitTot
                    NewInvoice.CrAcctNu = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "cr_acct_nu")
                    NewInvoice.DrAcctNu = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "dr_acct_nu")
                    NewInvoice.UnitRate = AttendRptData.Item(num).UnitRate
                    NewInvoice.EntryDate = Today
                    NewInvoice.InvoiceDate = AttendRptData.Item(num).InvoiceDate
                    NewInvoice.DtTbePd = DateAdd("d", 30, AttendRptData.Item(num).InvoiceDate)
                    NewInvoice.EncumDate = CDate(encum_Date.Text)
                    NewInvoice.BalDue = ARow.DolTot 'AttendRptData.Item(num).DolTot - AttendRptData.Item(num).Offset
                    NewInvoice.AllocAmt = ARow.DolTot
                    NewInvoice.InvAmt = 0
                    'put the invoice line in file
                    sqlstmnt = "insert into invoice " & NewInvoice.CompanyInvoiceColumnNames & "  values " & NewInvoice.CompanyInvoiceColumnData
                    ETSSQL.ExecuteSQL(sqlstmnt)
                    num = num + 1
                Next
        End Select

        Dim ControlInvoice As New CompanyInvoiceData
        ControlInvoice = ETSSQL.GetCompanyInvoiceDataOne("select top (1) * from invoice order by inv_num desc")
        ''update the bill control file
        sqlstmnt = " select * from bill_cntrl where contract_key = '" & selected_contract_key & "' and serv_beg = '" & start_date.Text & "'"
        Dim NumRecs As Integer = ETSCommon.CheckNumRecords(sqlstmnt)

        If NumRecs = 0 Then
            Dim BillControl As New BillControlData
            BillControl.BillDate = ControlInvoice.EncumDate
            'from invoice date  per jri
            BillControl.Invoice = ControlInvoice.Invoice
            BillControl.AmtBilled = ControlInvoice.AllocAmt
            BillControl.InvNum = ControlInvoice.InvNum
            BillControl.Comment = "Not and Active Contract"
            BillControl.ServBeg = CDate(start_date.Text)
            BillControl.ServEnd = CDate(End_Date.Text)
            BillControl.ContractKey = ControlInvoice.ContractKey
            BillControl.AcctNum = ETSSQL.GetOneItemList("select dr_acct_nu from cc_cont where contract_key = '" & selected_contract_key & "'", "dr_Acct_nu")
            BillControl.DeliveryMethod = ETSSQL.GetOneItemList("select code1 from cc_cont where contract_key = '" & selected_contract_key & "'", "code1")
            If BillControl.DeliveryMethod <> "E" Or BillControl.DeliveryMethod <> "P" Then
                BillControl.DeliveryMethod = "E"
            End If
            Dim EmailNamKey As String = ETSSQL.GetOneItemList("select name_key from cc_cont where contract_key = '" & selected_contract_key & "'", "name_key")
            BillControl.EmailAddress = ETSSQL.GetOneItemList("select email from nam_Addr where name_key = '" & EmailNamKey & "'", "email")
            If BillControl.EmailAddress.Length = 0 Then
                BillControl.DeliveryMethod = "P"
            End If
            BillControl.Sent = "N"
            BillControl.SentDate = CDate("1/1/1901")
            BillControl.PrinterName = ""
            sqlstmnt = "insert into bill_cntrl " & BillControl.BillControlColumnNames & " values " & BillControl.BillControlColumnData
            ETSSQL.ExecuteSQL(sqlstmnt)
        Else 'edit rather than insert
            sqlstmnt = "update  bill_cntrl set  bill_date = '" & ControlInvoice.InvoiceDate & "', invoice = '" & ControlInvoice.Invoice
            sqlstmnt = sqlstmnt & "' , amt_billed = '" & ControlInvoice.AllocAmt & "' , inv_num = '" & ControlInvoice.InvNum
            sqlstmnt = sqlstmnt & "' , comment = '  '  where contract_key = '" & selected_contract_key & "' and serv_beg = '" & start_date.Text & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)
        End If

        tots(0) = 0
        tots(1) = 0
        For Each AttendRptRow In AttendRptData
            tots(0) = tots(0) + AttendRptRow.UnitTot
            tots(1) = tots(1) + AttendRptRow.DolTot
            'get the right ccfund to update that one  based on b num
            If AttendRptRow.NameKey <> "99996" Or AttendRptRow.NameKey <> "99999" Or AttendRptRow.NameKey <> "99997" Or AttendRptRow.NameKey <> "99998" Then
                Dim NewClientTotal = AttendRptRow.DolTot + CDbl(ETSCommon.GetDatum("cc_fund", "b_num", AttendRptRow.BNum, "client_total"))
                sqlstmnt = "update cc_fund set bill_Date = '" & AttendRptRow.InvoiceDate & "' , client_Total ='" & NewClientTotal & "' where b_num = '" & AttendRptRow.BNum & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If
        Next

        If Len(invoice_string.Text) = 0 Then
            invoice_string.Text = CStr(ControlInvoice.InvNum)
        End If
        sqlstmnt = " update cc_cont set last_invnum = ' " & invoice_string.Text
        sqlstmnt = sqlstmnt & "', last_billdate = '" & inv_date.Text
        sqlstmnt = sqlstmnt & "', ytd_units = ytd_units + '" & tots(0)
        sqlstmnt = sqlstmnt & "', ytd_dol = ytd_dol  + '" & tots(1)
        sqlstmnt = sqlstmnt & "', month_units =  '" & tots(0)
        sqlstmnt = sqlstmnt & "', month_dol = '" & tots(1) & "'"
        sqlstmnt = sqlstmnt & " where contract_key = '" & selected_contract_key & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        'now we move the records to attend_hist

        sqlstmnt = " select * from attend_Tmp where contract_key = '" & selected_contract_key
        sqlstmnt = sqlstmnt & "' and att_Date between '" & start_date.Text
        sqlstmnt = sqlstmnt & "' and '" & End_Date.Text
        sqlstmnt = sqlstmnt & "' order by b_num, att_date"

        Dim MoveAttend As New List(Of AttendData)

        '   MsgBox("start time = " & CStr(TimeOfDay))
        'MoveAttend = ETSSQL.GetAttendanceData(sqlstmnt)

        'For Each Row In MoveAttend
        '    Row.Invoice = invoice_string.Text
        '    Row.Invoice = ControlInvoice.Invoice

        '    Row.InvoiceDate = CDate(inv_date.Text)

        '    sqlstmnt = "insert into attend_hist " & Row.AttendColumnNames & " values " & Row.AttendColumnData
        '    Debug.Print(sqlstmnt)
        '    ETSSQL.ExecuteSQL(sqlstmnt)
        '    sqlstmnt = " update attend_hist set inv_num = '" & ControlInvoice.InvNum
        '    sqlstmnt = sqlstmnt & "' where contract_key = '" & selected_contract_key
        '    sqlstmnt = sqlstmnt & "' and att_Date between '" & start_date.Text
        '    sqlstmnt = sqlstmnt & "' and '" & End_Date.Text & "'"

        '    ETSSQL.ExecuteSQL(sqlstmnt)
        'Next
        sqlstmnt = "insert into attend_hist select * from attend_Tmp where contract_key = '" & selected_contract_key
        sqlstmnt = sqlstmnt & "' and att_Date between '" & start_date.Text
        sqlstmnt = sqlstmnt & "' and '" & End_Date.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)
        sqlstmnt = " update attend_hist set inv_num = '" & ControlInvoice.InvNum
        sqlstmnt = sqlstmnt & "' , invoice = '" & ControlInvoice.Invoice
        sqlstmnt = sqlstmnt & "' , invoice_date = '" & ControlInvoice.InvoiceDate
        sqlstmnt = sqlstmnt & "' where contract_key = '" & selected_contract_key
        sqlstmnt = sqlstmnt & "' and att_Date between '" & start_date.Text
        sqlstmnt = sqlstmnt & "' and '" & End_Date.Text & "'"

        ETSSQL.ExecuteSQL(sqlstmnt)

        '        MsgBox("stop time = " & CStr(TimeOfDay))

        ''now move mmpv_tmp to mmpv_hist
        sqlstmnt = "Select  * from mmpv_tmp  "

        Dim MoveMMPV As New List(Of PVData)
        MoveMMPV = ETSSQL.GetPVData(sqlstmnt)

        For Each row In MoveMMPV
            sqlstmnt = "insert into mmpv_hist " & row.PVColumnNames & "values " & row.PVColumnData
            ETSSQL.ExecuteSQL(sqlstmnt)
        Next

        'delete records from attend_tmp
        ' For Each row In MoveAttend
        sqlstmnt = " delete from attend_Tmp where contract_key = '" & selected_contract_key
        sqlstmnt = sqlstmnt & "' and att_Date between '" & start_date.Text
        sqlstmnt = sqlstmnt & "' and '" & End_Date.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)
        '  Next

    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub encum_Date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles encum_Date.Enter
        Call ets_set_selected()
    End Sub

    Private Sub encum_Date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles encum_Date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Then
            senddate = encum_Date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")

            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                encum_Date.Text = retdate.ToString
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

    Private Sub encum_Date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles encum_Date.Leave
        encum_Date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub



    Private Sub inv_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles inv_date.Enter
        Call ets_set_selected()
    End Sub

    Private Sub inv_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles inv_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))

        If KeyAscii = 13 Then
            senddate = inv_date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")

            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                selected_inv_date = CDate(retdate)
                selected_start_date = CDate(retdate)
                inv_date.Text = CStr(CDate(inv_date.Text))
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

    Private Sub inv_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles inv_date.Leave
        inv_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub invoice_string_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles invoice_string.Enter
        Call ets_set_selected()

    End Sub

    Private Sub invoice_string_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles invoice_string.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            If Len(invoice_string.Text) <> 0 Then
                invoice_string.Text = invoice_string.Text
                id_num = invoice_string.Text 'puts it in the variable where it belongs
            Else
                invoice_string.Text = CStr(high_inv_num)
            End If

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0

        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub invoice_string_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles invoice_string.Leave
        invoice_string.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub End_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Date.Enter
        Call ets_set_selected()
    End Sub

    Private Sub End_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles End_Date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = End_Date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")

            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                End_Date.Text = CDate(retdate).ToShortDateString
                selected_end_date = CDate(retdate)
            End If

            If DateDiff(DateInterval.Day, CDate(start_date.Text), CDate(End_Date.Text)) < 0 Then
                MsgBox("Invalid date range")
                Call ets_set_selected()
                GoTo EventExitSub
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

    Private Sub End_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Date.Leave
        End_Date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub Start_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date.Enter
        Call ets_set_selected()

        If function_type <> "VOID" Then
            inv_date.Text = CStr(Today)
            encum_Date.Text = End_Date.Text
        End If

    End Sub

    Private Sub Start_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles start_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Then
            senddate = start_date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")
            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                selected_start_date = CDate(retdate)
                start_date.Text = CDate(retdate).ToShortDateString
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

    Private Sub Start_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date.Leave
        start_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub PrepareForCrystal()

        Call CheckData()

        'check if multiple selects in which case not a preview
        update_contract_ytd(selected_contract_key)
        Call prepare_attend_rpt(selected_contract_key, start_date.Text, End_Date.Text)

    End Sub

    Private Sub OK_bill_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OK_bill.Click
        Call CheckData()
        Me.Cursor = Cursors.WaitCursor

        For Each DGRow As DataGridViewRow In DataGridView1.SelectedRows
            selected_contract_key = DGRow.Cells("Contract_Key").Value.ToString  'DataGridView1.Item("contract_key", e.RowIndex).Value.ToString
            id_num = invoice_string_Create(End_Date.Text, selected_contract_key)
            invoice_string.Text = id_num
            update_contract_ytd(selected_contract_key)
            prepare_attend_rpt(selected_contract_key, start_date.Text, End_Date.Text)
            DeleteExtraPDFS(id_num)

            sqlstmnt = "select * from cc_cont where contract_key = '" & selected_contract_key & "'"
            Dim SelectedContract As New List(Of ContractData)
            SelectedContract = ETSSQL.GetContractData(sqlstmnt)
            CheckInvoiceFolder(End_Date.Text, selected_contract_key)
            Dim RptList As String = GetReportList(selected_contract_key)
            Dim rpts As String() = RptList.Split(CChar("*"))
            For Each report In rpts
                If Len(report) <> 0 Then
                    Call detail_print(report)
                End If
            Next
            Call update_records(id_num)
            prtDestination = 1
            Call MergeReports(id_num)
        Next

        rebuild_grid()
        Me.Cursor = Cursors.Default

    End Sub

    Public Sub FillPV(ByVal id_num As String)
        'fill sdr data into pv and set up for printing from mmpv2
        tots(0) = 0
        tot_amt = 0
        selected_lookup_num = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "pv_form")

        If Len(selected_lookup_num) = 0 Then
            MsgBox("There is no PV Template for this contract")
            Exit Sub
        End If
        pv_Type = "ACT"
        entry_type = "EDIT"
        'clean out mmpv_tmp at this point
        sqlstmnt = "Delete from mmpv_tmp"
        ETSSQL.ExecuteSQL(sqlstmnt)

        'fill the pv form from here
        'first create the actual from mmpv and then write in the fields
        sqlstmnt = "select * from mmpv where pv_form = '" & selected_lookup_num & "' and contract_key = '" & selected_contract_key & "'"
        Dim NewPV As PVData
        NewPV = ETSSQL.GetOnePVData(sqlstmnt)
        ''now for the detail data
        sqlstmnt = "Select * from attend_rpt where contract_key = '" & selected_contract_key & "'"
        Dim FromAttendRpt As New List(Of AttendReportData)
        FromAttendRpt = ETSSQL.GetAttendReportData(sqlstmnt)
        NewPV.Pvdate7 = CDate(inv_date.Text)
        NewPV.VinvNum13 = invoice_string.Text
        NewPV.VinvNum37 = invoice_string.Text
        NewPV.FrmDate40 = CDate(start_date.Text)
        NewPV.ToDate41 = CDate(End_Date.Text)
        NewPV.Print = "Y"
        NewPV.Up1 = CDec(ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "unit_rate"))
        If Len(Trim(NewPV.D12)) <> 0 Then
            NewPV.D12 = NewPV.D12 & " " & FromAttendRpt.Item(0).AttBeg & " to " & FromAttendRpt.Item(0).AttEnd
        End If

        tot_amt = 0
        tots(0) = 0
        'add the attend_rpt fields up for this line num but not maxx obs
        For Each Row In FromAttendRpt
            If Row.SlotNum = 99 Or Row.SlotNum = 98 Then Exit For
            tot_amt = tot_amt + Row.DolTot
            tots(0) = tots(0) + Row.UnitTot
        Next
        '  NewPV.doctot-11") = tot_amt
        NewPV.Q1 = tots(0)
        NewPV.A1 = tot_amt
        NewPV.Quant42 = tots(0)
        NewPV.Amount43 = tot_amt

        'check for maxx obs and ssi offset

        For Each Row In FromAttendRpt
            If Row.NameKey = "99999" Then
                If Len(NewPV.D1) = 0 Then
                    NewPV.D1 = "Max Ob Offset"
                    NewPV.Ln1 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A1 = Row.DolTot
                    NewPV.Q1 = Row.UnitTot
                ElseIf Len(NewPV.D2) = 0 Then
                    NewPV.D2 = "Max Ob Offset"
                    NewPV.Ln2 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A2 = Row.DolTot
                    NewPV.Q2 = Row.UnitTot
                ElseIf Len(NewPV.D3) = 0 Then
                    NewPV.D3 = "Max Ob Offset"
                    NewPV.Ln3 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A3 = Row.DolTot
                    NewPV.Q3 = Row.UnitTot
                ElseIf Len(NewPV.D4) = 0 Then
                    NewPV.D4 = "Max Ob Offset"
                    NewPV.Ln4 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A4 = Row.DolTot
                    NewPV.Q4 = Row.UnitTot
                ElseIf Len(NewPV.D5) = 0 Then
                    NewPV.D5 = "Max Ob Offset"
                    NewPV.Ln5 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A5 = Row.DolTot
                    NewPV.Q5 = Row.UnitTot
                ElseIf Len(NewPV.D6) = 0 Then
                    NewPV.D6 = "Max Ob Offset"
                    NewPV.Ln6 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A6 = Row.DolTot
                    NewPV.Q6 = Row.UnitTot
                ElseIf Len(NewPV.D7) = 0 Then
                    NewPV.D7 = "Max Ob Offset"
                    NewPV.Ln7 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A7 = Row.DolTot
                    NewPV.Q7 = Row.UnitTot
                ElseIf Len(NewPV.D8) = 0 Then
                    NewPV.D8 = "Max Ob Offset"
                    NewPV.Ln8 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A8 = Row.DolTot
                    NewPV.Q8 = Row.UnitTot
                ElseIf Len(NewPV.D9) = 0 Then
                    NewPV.D9 = "Max Ob Offset"
                    NewPV.Ln9 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A9 = Row.DolTot
                    NewPV.Q9 = Row.UnitTot
                ElseIf Len(NewPV.D10) = 0 Then
                    NewPV.D10 = "Max Ob Offset"
                    NewPV.Ln10 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A10 = Row.DolTot
                    NewPV.Q10 = Row.UnitTot
                End If
            End If

            If Row.NameKey = "99998" Then
                If Len(NewPV.D1) = 0 Then
                    NewPV.D1 = "SSI Offset"
                    NewPV.Ln1 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A1 = Row.DolTot
                    NewPV.Q1 = Row.UnitTot
                ElseIf Len(NewPV.D2) = 0 Then
                    NewPV.D2 = "SSI Offset"
                    NewPV.Ln2 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A2 = Row.DolTot
                    NewPV.Q2 = Row.UnitTot
                ElseIf Len(NewPV.D3) = 0 Then
                    NewPV.D3 = "SSI Offset"
                    NewPV.Ln3 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A3 = Row.DolTot
                    NewPV.Q3 = Row.UnitTot
                ElseIf Len(NewPV.D4) = 0 Then
                    NewPV.D4 = "SSI Offset"
                    NewPV.Ln4 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A4 = Row.DolTot
                    NewPV.Q4 = Row.UnitTot
                ElseIf Len(NewPV.D5) = 0 Then
                    NewPV.D5 = "SSI Offset"
                    NewPV.Ln5 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A5 = Row.DolTot
                    NewPV.Q5 = Row.UnitTot
                ElseIf Len(NewPV.D6) = 0 Then
                    NewPV.D6 = "SSI Offset"
                    NewPV.Ln6 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A6 = Row.DolTot
                    NewPV.Q6 = Row.UnitTot
                ElseIf Len(NewPV.D7) = 0 Then
                    NewPV.D7 = "SSI Offset"
                    NewPV.Ln7 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A7 = Row.DolTot
                    NewPV.Q7 = Row.UnitTot
                ElseIf Len(NewPV.D8) = 0 Then
                    NewPV.D8 = "SSI Offset"
                    NewPV.Ln8 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A8 = Row.DolTot
                    NewPV.Q8 = Row.UnitTot
                ElseIf Len(NewPV.D9) = 0 Then
                    NewPV.D9 = "SSI Offset"
                    NewPV.Ln9 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A9 = Row.DolTot
                    NewPV.Q9 = Row.UnitTot
                ElseIf Len(NewPV.D10) = 0 Then
                    NewPV.D10 = "SSI Offset"
                    NewPV.Ln10 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
                    NewPV.A10 = Row.DolTot
                    NewPV.Q10 = Row.UnitTot
                End If

            End If
        Next
        'put in the net billed line
        'find an empty line and fill it
        tot_amt = NewPV.A1 + NewPV.A2 + NewPV.A3 + NewPV.A4 + NewPV.A5 + NewPV.A6 + NewPV.A7 + NewPV.A8 + NewPV.A9 + NewPV.A10
        If Len(NewPV.D1) = 0 Then
            NewPV.D1 = "Net Billed"
            NewPV.Ln1 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
            NewPV.A1 = tot_amt
            NewPV.Q1 = 0
        ElseIf Len(NewPV.D2) = 0 Then
            NewPV.D2 = "Net Billed"
            NewPV.Ln2 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
            NewPV.A2 = tot_amt
            NewPV.Q2 = 0
        ElseIf Len(NewPV.D3) = 0 Then
            NewPV.D3 = "Net Billed"
            NewPV.Ln3 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
            NewPV.A3 = tot_amt
            NewPV.Q3 = 0
        ElseIf Len(NewPV.D4) = 0 Then
            NewPV.D4 = "Net Billed"
            NewPV.Ln4 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
            NewPV.A4 = tot_amt
            NewPV.Q4 = 0
        ElseIf Len(NewPV.D5) = 0 Then
            NewPV.D5 = "Net Billed"
            NewPV.Ln5 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
            NewPV.A5 = tot_amt
            NewPV.Q5 = 0
        ElseIf Len(NewPV.D6) = 0 Then
            NewPV.D6 = "Net Billed"
            NewPV.Ln6 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
            NewPV.A6 = tot_amt
            NewPV.Q6 = 0
        ElseIf Len(NewPV.D7) = 0 Then
            NewPV.D7 = "Net Billed"
            NewPV.Ln7 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
            NewPV.A7 = tot_amt
            NewPV.Q7 = 0
        ElseIf Len(NewPV.D8) = 0 Then
            NewPV.D8 = "Net Billed"
            NewPV.Ln8 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
            NewPV.A8 = tot_amt
            NewPV.Q8 = 0
        ElseIf Len(NewPV.D9) = 0 Then
            NewPV.D9 = "Net Billed"
            NewPV.Ln9 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
            NewPV.A9 = tot_amt
            NewPV.Q9 = 0
        ElseIf Len(NewPV.D10) = 0 Then
            NewPV.D10 = "Net Billed"
            NewPV.Ln10 = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "mmars_num")
            NewPV.A10 = tot_amt
            NewPV.Q10 = 0
        End If

        sqlstmnt = " insert into mmpv_tmp " & NewPV.PVColumnNames & " values " & NewPV.PVColumnData
        ETSSQL.ExecuteSQL(sqlstmnt)
        '        frmmmpv1.ShowDialog()

        '        prtWindowState = 2
        '        prtDestination = 1
        '        prtreportfilename = att_report_path & "pv6.rpt"
        '        CrystalForm.ShowDialog()


        'donepv:
        'Response = MsgBox("OK to update records?", CType(vbYesNo + vbDefaultButton2, MsgBoxStyle))
        'frmmmpv1.Dispose()
        'If Response = vbYes Then
        '    update_records(id_num)
        '    MergeReports(id_num)
        '    DataGridView1.Rows.Clear()
        '    invoice_string.Text = GetNextCompanyInvoiceNum.ToString
        'Else
        '    MsgBox("This record has not been updated.")
        '    Ref_list.Focus()
        '    Exit Sub
        'End If
        'Else
        'Exit Sub
        'End If

    End Sub

    Private Sub Pre_bill_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Pre_bill.Click
        'preview bill
        Call CheckData()
        update_contract_ytd(selected_contract_key)
        prepare_attend_rpt(selected_contract_key, start_date.Text, End_Date.Text)
        id_num = invoice_string_Create(End_Date.Text, selected_contract_key)
        DeleteExtraPDFS(id_num)
        CheckInvoiceFolder(End_Date.Text, selected_contract_key)
        'do the pv if it exists
        selected_lookup_num = ETSSQL.GetOneSQLValue("select pv_form as thevalue from cc_Cont where contract_key = '" & selected_contract_key & "'")
        If RTrim(LTrim(selected_lookup_num)).Length <> 0 Then
            entry_type = "EDIT"
            pv_Type = "ACT"
            FillPV(id_num)
            frmmmpv1.ShowDialog()
        End If
        Dim RptList As String = GetReportList(selected_contract_key)
        Dim rpts As String() = RptList.Split(CChar("*"))
        For Each report In rpts
            If Len(report) <> 0 Then
                Call detail_review(report)
            End If
        Next

AnotherAttachment:
        Response = MsgBox("Do you wish to add another document to the invoice? ", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = vbYes Then
            'use merge document form  with the button to add to the list and a lookup.
            Dim strfilename As String = OpenFile()
            'move strfilename to temp
            FileSystem.FileCopy(strfilename, InvoiceLocation & "temp\9" & System.IO.Path.GetFileName(strfilename))
            GoTo AnotherAttachment
        End If

        Response = MsgBox("Do you wish to update the data files and merge the reports?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, MsgBoxStyle))
        If Response = vbYes Then
            Me.Cursor = Cursors.WaitCursor
            update_records(id_num)
            selected_end_date = CDate(End_Date.Text)
            prtDestination = 1 'do move and merge
            MergeReports(id_num)
            Me.Cursor = Cursors.Default
        End If

        Call rebuild_grid()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Click
        'create attend rpt and stop there
        Call CheckData()
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'assume a batch process
        For Each DGRow As DataGridViewRow In DataGridView1.SelectedRows
            selected_contract_key = DGRow.Cells("Contract_Key").Value.ToString  'DataGridView1.Item("contract_key", e.RowIndex).Value.ToString
            update_contract_ytd(selected_contract_key)
            Call prepare_attend_rpt(selected_contract_key, start_date.Text, End_Date.Text)
        Next
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Pre_bill.Focus()

    End Sub

    Private Sub Ref_list_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Ref_list.Click
        'put dates in rpthead
        Cursor.Current = Cursors.WaitCursor
        sqlstmnt = "update rpthead set beg_date = '" & start_date.Text & "', end_date = ' " & End_Date.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)
        encum_Date.Text = End_Date.Text  ''subtract one from the next month first
        ' JRI  error
        selected_end_date = CDate(encum_Date.Text)
        Cursor.Current = Cursors.Default

        Call rebuild_grid()
    End Sub

    Private Sub rebuild_grid()

        If Len(start_date.Text) = 0 Then
            MsgBox("You need to enter a start date.")
            start_date.Focus()
            Exit Sub
        End If

        If Len(End_Date.Text) = 0 Then
            MsgBox("You need to enter an end date.")
            End_Date.Focus()
            Exit Sub
        End If
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        invoice_string.Text = ""

        sqlstmnt = " select distinct attend_tmp.contract_key, cc_cont.cont_desc, attend_tmp.bill_type, attend_tmp.pv_Form, attend_tmp.rpt_type from attend_tmp "
        sqlstmnt = sqlstmnt & " INNER Join cc_cont ON cc_Cont.contract_key = attend_tmp.contract_key  where"
        sqlstmnt = sqlstmnt & " att_Date between '" & start_date.Text
        sqlstmnt = sqlstmnt & "' and '" & End_Date.Text
        sqlstmnt = sqlstmnt & "' and void <> 'Y' "
        sqlstmnt = sqlstmnt & " order by contract_key"



        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sqlstmnt)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        selected_lookup_num = ""
        selected_contract_key = ""

        Select Case SelectedIndex
            Case 0
                On Error Resume Next
                DataGridView1.Rows(0).Selected = False
                SelectedIndex = 1
                On Error GoTo 0
            Case Is > DataGridView1.Rows.Count
                SelectedIndex = 1
            Case Else
                DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
                ' DataGridView1.Rows(SelectedIndex).Selected = True
                'DataGridView1.Rows(SelectedIndex).Cells(0).Selected = True
                DataGridView1.PerformLayout()
        End Select

        DataGridView1.AutoResizeColumns()
        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            '     selected_cont_id_num = DataGridView1.Item("cont_id_num", e.RowIndex).Value.ToString
            '    selected_mmars_num = DataGridView1.Item("mmars_num", e.RowIndex).Value.ToString
            '   selected_amend_num = DataGridView1.Item("amend_num", e.RowIndex).Value.ToString
            selected_contract_key = DataGridView1.Item("contract_key", e.RowIndex).Value.ToString
            selected_desc = DataGridView1.Item("cont_desc", e.RowIndex).Value.ToString
            invoice_string.Text = invoice_string_Create(End_Date.Text, selected_contract_key)
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index
        DataGridView1.Rows(SelectedIndex).Selected = True
        invoice_string.Focus()

    End Sub

    Private Sub MergeReports(ByVal id_num As String)
        MergeForm.ShowDialog()
    End Sub

    Private Sub SendBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendBills.Click
        att_ed_cntrl.ShowDialog()
    End Sub

    Private Sub DeleteExtraPDFS(ByVal id_num As String)
        'find pdfs in dir and delete them
        ' InvoiceLocation & invnum
        Dim InvPDF As String
        Dim InvDir As String = InvoiceLocation & "temp\"
        Dim InvFile As String = "*.pdf"
        For Each InvPDF In Directory.GetFiles(InvDir, InvFile)
            File.Delete(InvPDF)
        Next
    End Sub

    Public Function OpenFile() As String
        'declare a string, this is will contain the filename that we return
        Dim strFileName = ""
        'declare a new open file dialog
        Dim fileDialogBox As New OpenFileDialog()

        ''add file filters, this step is optional, but if you notice the screenshot
        ''above it does not look clean if you leave it off, I explained in further
        ''detail on my site how to add/modify these values
        fileDialogBox.Filter = "PDF files (*.pdf)|*.pdf"
        '"Rich Text Format (*.rtf)|*.rtf|" _
        '    & "Text Files (*.txt)|*.txt|" _
        '    & "Word Documents (*.doc;*.docx)|*.doc;*.docx|" _
        '    & "Image Files (*.bmp;*.jpg;*.gif)|*.bmp;*.jpg;*.gif|" _
        '    & "All Files(*.*)|"
        ''this sets the default filter that we created in the line above, if you don't 
        ''set a FilterIndex it will automatically default to 1
        'fileDialogBox.FilterIndex = 3
        ''this line tells the file dialog box what folder it should start off in first
        ''I selected the users my document folder
        fileDialogBox.InitialDirectory = InvoiceLocation & "attachments\"
        fileDialogBox.Filter = "PDF files (*.pdf)|*.pdf"
        fileDialogBox.Title = "Attachment Lookup Screen"
        'Check to see if the user clicked the open button
        If (fileDialogBox.ShowDialog() = DialogResult.OK) Then
            strFileName = fileDialogBox.FileName
            'Else
            '   MsgBox("You did not select a file!")
        End If

        'return the name of the file
        Return strFileName
    End Function


End Class