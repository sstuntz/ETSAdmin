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
Imports System.String
Imports System.Object
Imports ETS.Common.EMailMod
Imports System.Configuration.ConfigurationSettings
Imports System.Drawing.Printing
Imports System.Text.RegularExpressions

Public Class att_ed_cntrl
    Inherits System.Windows.Forms.Form

    Public InvoiceLocation As String = ConfigurationManager.AppSettings("InvoiceLocation")
  
    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub att_ed_cntrl_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)

        selectedcell = False
        SelectedIndex = 0

        Dim p As New System.Drawing.Printing.PrinterSettings()
        TextBox1.Text = p.PrinterName

        'for bill control default dates to fiscal year
        If Month(Today) < 7 Then
            start_date.Text = "7/1/" & Year(Today) - 1
            End_Date.Text = "6/30/" & Year(Today)
        Else
            start_date.Text = "7/1/" & Year(Today)
            End_Date.Text = "6/30/" & Year(Today) + 1
        End If

        ComboBox1.SelectedIndex = -1

    End Sub

    Private Sub datagridview1_cellformatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If Me.DataGridView1.Columns(e.ColumnIndex).Name = "contract_key" Then
            Me.DataGridView1.Columns(e.ColumnIndex).DefaultCellStyle.Format = "###-######-##-###-##-##"
        End If
    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.RowIndex <> -1 Then
            selectedcell = True
            ' selected_lookup_num = DataGridView1.Item("autho_num", e.RowIndex).Value.ToString
            'selected_name_key = DataGridView1.Item("name_key", e.RowIndex).Value.ToString
            'selected_sort_name = DataGridView1.Item("sort_name", e.RowIndex).Value.ToString
            selected_contract_key = DataGridView1.Item("contract_key", e.RowIndex).Value.ToString
            SelectedIndex = DataGridView1.CurrentRow.Index
        Else
            selectedcell = False
            selected_contract_key = ""
            SelectedIndex = 0
        End If
    End Sub

    Private Sub DataGridView1__Cellvaluechanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        ' can edit - comment and delivery method
        Select Case e.ColumnIndex
            Case 5  ' comment
                ' DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString

                sqlstmnt = "update bill_cntrl set  comment = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString & "' where invoice = '" & DataGridView1.Rows(e.RowIndex).Cells("Invoice").Value.ToString & "'"
            Case 6  'delievery method
                sqlstmnt = "update bill_cntrl set  deliverymethod = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString & "' where invoice = '" & DataGridView1.Rows(e.RowIndex).Cells("Invoice").Value.ToString & "'"
            Case Else
                Exit Sub
        End Select

        ETSSQL.ExecuteSQL(sqlstmnt)

    End Sub

    Private Sub End_Date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Date.Enter
        Call ets_set_selected()
    End Sub

    Private Sub End_Date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles End_Date.KeyPress
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
                pr_end_date = CDate(retdate)
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

    Private Sub End_Date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Date.Leave
        End_Date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub start_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date.Enter
        Call ets_set_selected()
        'selected_start_date = CDate(pr_start_date1.Text)
    End Sub

    Private Sub start_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles start_date.KeyPress
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
                pr_Start_date = CDate(retdate)
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

    Private Sub start_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date.Leave
        start_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub Ref_list_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Ref_list.Click

        Dim rs As DataSet
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
  
        'bill_cntrl.Contract_key, cont_desc, invoice,amt_billed,comment,deliveryMethod,EmailAddress,serv_brg,Sent,SentDate,bill_date


        sqlstmnt = "select bill_cntrl.Contract_key, cont_id_num, cont_desc, invoice, amt_billed, comment, deliveryMethod, EmailAddress, serv_beg, Sent, SentDate, bill_date  from bill_Cntrl left join cc_cont on cc_cont.contract_key = bill_cntrl.contract_key  "

        'join with invoice and check encum date

        Select Case True
            Case AllContracts.Checked
                sqlstmnt = sqlstmnt & " where amt_billed >= 0 "
            Case Unbilled.Checked
                sqlstmnt = sqlstmnt & " where amt_billed = 0 "
            Case BilledSent.Checked
                sqlstmnt = sqlstmnt & " where amt_billed > 0 and sent = 'Y' "
            Case Unsent.Checked
                sqlstmnt = sqlstmnt & " where amt_billed > 0 and sent = 'N' "
        End Select

        'date range
        sqlstmnt = sqlstmnt & " and bill_date between '" & start_date.Text & "' and '" & End_Date.Text & "'"
        sqlstmnt = sqlstmnt & " and cc_cont.active = 'Y' order by bill_cntrl.contract_key "

        Me.Cursor = Cursors.WaitCursor

        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sqlstmnt)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        selected_lookup_num = ""
        selected_contract_key = ""

        CreateGrid()


        If SelectedIndex > 0 Then
            On Error Resume Next
            DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
            DataGridView1.Rows(SelectedIndex).Selected = True
            DataGridView1.Rows(SelectedIndex).Cells(0).Selected = True
            DataGridView1.PerformLayout()
            On Error GoTo 0
        Else
            On Error Resume Next
            DataGridView1.Rows(0).Selected = False
            On Error GoTo 0
        End If

        DataGridView1.AutoResizeColumns()
        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing

        'put dates in rpthead but not in bill control which has gone to fiscal year
        '    sqlstmnt = "update rpthead set beg_date = '" & start_date.Text & "', end_date = ' " & End_Date.Text & "'"
        '   ETSSQL.ExecuteSQL(sqlstmnt)

        'For num As Integer = 0 To DataGridView1.RowCount - 1
        '    DataGridView1.Rows.Item(num).Cells(0).Value = MakeJRIContractID(DataGridView1.Rows.Item(num).Cells(0).Value.ToString)
        'Next
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendEmail.Click

        Response = MsgBox("Invoices will be printed to " & TextBox1.Text & ".  Is this where you want them?", vbYesNo)
        If Response = 7 Then
            ChangePrinter.Focus()
            Exit Sub
        End If


        For Each DGRow As DataGridViewRow In DataGridView1.SelectedRows
            If DGRow.Cells("Invoice").Value.ToString <> "" Then
                'check if void and do not mail
                ' wont happen since pdf name has void in it and it wont match
                '   selected_contract_key = DGRow.Cells("Contract_Key").Value.ToString  'DataGridView1.Item("contract_key", e.RowIndex).Value.ToString
                If DGRow.Cells("DeliveryMethod").Value.ToString = "E" And DGRow.Cells("Sent").Value.ToString = "N" Then
                    'mail the item  in MailMod to from subject text att)
                    Dim TOPerson As String = DGRow.Cells("EMailAddress").Value.ToString
                    Dim From As String = "JRI Accounts Receivable" 'DGRow.Cells("EMail").Value.ToString
                    Dim Subject As String = "Invoice = " & DGRow.Cells("Invoice").Value.ToString
                    Dim EmailBody As String = "See Attachment" 'DGRow.Cells("EMail").Value.ToString
                    Dim FullInvoiceFolderLocation As String
                    'set folder location

                    FullInvoiceFolderLocation = CheckInvoiceFolder(End_Date.Text, DGRow.Cells("Contract_key").Value.ToString)

                    Dim attachment As String = FullInvoiceFolderLocation & DGRow.Cells("Invoice").Value.ToString() & ".pdf"

                    ETS.Common.EMailMod.SendEMail(TOPerson, From, Subject, EmailBody, attachment)
                    'update the bill control
                    DGRow.Cells("sent").Value = "Y"
                    DGRow.Cells("DateSent").Value = Today
                    sqlstmnt = "update bill_cntrl set sent = 'Y' , SentDate = '" & Today.ToShortDateString & "' where contract_key = '" & DGRow.Cells("Contract_Key").Value.ToString & "' and serv_beg = '" & start_date.Text & "'"
                    ETSSQL.ExecuteSQL(sqlstmnt)
                End If
                If DGRow.Cells("DeliveryMethod").Value.ToString = "P" And DGRow.Cells("Sent").Value.ToString = "N" Then
                    'print to default printer or changed printer  name in textbox1
                    prtPrinterName = TextBox1.Text
                    prtDestination = 2
                    Dim FullInvoiceFolderLocation As String
                    'set folder location

                    FullInvoiceFolderLocation = CheckInvoiceFolder(End_Date.Text, DGRow.Cells("Contract_key").Value.ToString)

                    prtreportfilename = FullInvoiceFolderLocation & DGRow.Cells("Invoice").Value.ToString() & ".pdf"
                    MergeForm.ShowDialog()

                    'update the bill control
                    DGRow.Cells("sent").Value = "Y"
                    DGRow.Cells("SentDate").Value = Today
                    sqlstmnt = "update bill_cntrl set sent = 'Y' , SentDate = '" & Today.ToShortDateString & "', printername = '" & prtPrinterName & "' where invoice = '" & DGRow.Cells("invoice").Value.ToString & "'"
                    ETSSQL.ExecuteSQL(sqlstmnt)
                End If

            End If
        Next
    End Sub


    Private Sub ChangePrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePrinter.Click
        'Dim printers As New Printing.PrintDocument()
        'Dim printername = printers.PrinterSettings.PrinterName
        'For Each printername In printers.PrinterSettings.InstalledPrinters
        '    cboPrinter.Items.Add(printername)
        '    cboPrinter.SelectedItem = pdTest.DefaultPageSettings.PrinterSettings.PrinterName
        'Next

        Dim num As Integer
        For num = 0 To System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count - 1
            'fill drop down box and then selected becomes defualt for this run
            ' Dim p As New System.Drawing.Printing.PrinterSettings()
            ComboBox1.Items.Add(System.Drawing.Printing.PrinterSettings.InstalledPrinters.Item(num))
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Text = ComboBox1.SelectedItem.ToString
    End Sub

    Private Sub AllContracts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllContracts.CheckedChanged
        DataGridView1.DataSource = DBNull.Value
        '   Ref_list.PerformClick()
    End Sub

    Private Sub Unsent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Unsent.CheckedChanged
        DataGridView1.DataSource = DBNull.Value
        '  Ref_list.PerformClick()
    End Sub

    Private Sub BilledSent_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles BilledSent.CheckedChanged
        DataGridView1.DataSource = DBNull.Value
        ' Ref_list.PerformClick()
    End Sub

    Private Sub Unbilled_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Unbilled.CheckedChanged
        DataGridView1.DataSource = DBNull.Value
        'Ref_list.PerformClick()
    End Sub

    Private Sub UpdateData_Click(sender As System.Object, e As System.EventArgs)
        sqlstmnt = "update bill_cntrl set amt_billed = q.alloc_amt, DeliveryMethod = left(q.code1,1), bill_date=q.invoice_date, EmailAddress = q.email"
        sqlstmnt = sqlstmnt & " from (select invoice.inv_num, nam_addr.email, invoice.invoice_date,  invoice.alloc_amt, cc_cont.code1 from bill_cntrl left join cc_cont on bill_cntrl.contract_key =cc_cont.contract_key left join nam_addr on cc_cont.name_key = nam_addr.name_key left join invoice on bill_cntrl.inv_num = invoice.inv_num"
        sqlstmnt = sqlstmnt & " where bill_date between '" & start_date.Text & "' and '" & End_Date.Text & "'"
        sqlstmnt = sqlstmnt & " and cc_cont.active = 'Y') q "
        sqlstmnt = sqlstmnt & " where(bill_cntrl.inv_num = q.inv_num)"
        '   ETSSQL.ExecuteSQL(sqlstmnt)

    End Sub
    Public Sub CreateGrid()
        ' DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        '  DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        ' DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        '  DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.EditMode = DataGridViewEditMode.EditOnEnter
        DataGridView1.EditingPanel.BorderStyle = BorderStyle.Fixed3D

        'DataGridView1.Columns.Add("contract_key", "Contract")
        'DataGridView1.Columns.Item(0).DataPropertyName = "contract_key"
        'DataGridView1.Columns.Item(0).ReadOnly = True
        DataGridView1.Columns.Item(0).Visible = False
        'DataGridView1.Columns.Add("cont_id_mum", "Contract")
        'DataGridView1.Columns.Item(1).DataPropertyName = "cont_id_num"
        DataGridView1.Columns.Item(1).ReadOnly = True
        'DataGridView1.Columns.Item(1).Visible = True
        'DataGridView1.Columns.Add("cont_desc", "Contract Desc")
        'DataGridView1.Columns.Item(2).DataPropertyName = "cont_desc"
        DataGridView1.Columns.Item(2).ReadOnly = True
        'DataGridView1.Columns.Item(2).Visible = True
        'DataGridView1.Columns.Add("invoice", "Invoice")
        'DataGridView1.Columns.Item(3).DataPropertyName = "invoice"
        DataGridView1.Columns.Item(3).ReadOnly = True
        'DataGridView1.Columns.Item(3).Visible = True
        'DataGridView1.Columns.Add("amt_billed", "Billed")
        'DataGridView1.Columns.Item(4).DataPropertyName = "amt_billed"
        DataGridView1.Columns.Item(4).DefaultCellStyle.Format = "N2"
        DataGridView1.Columns("amt_billed").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns.Item(4).ReadOnly = True
        '   DataGridView1.Columns.Item(5).ReadOnly = True
        'DataGridView1.Columns.Add("comment", "Comment")
        'DataGridView1.Columns.Item(5).DataPropertyName = "comment"
        'DataGridView1.Columns.Item(5).ReadOnly = False
        'DataGridView1.Columns.Add("DeliveryMethod", "Delivery")
        'DataGridView1.Columns.Item(6).DataPropertyName = "DeliveryMethod"
        'DataGridView1.Columns.Item(6).Width = 10
        'DataGridView1.Columns.Item(6).ReadOnly = False
        'DataGridView1.Columns.Add("EmailAddress", "EMail")
        'DataGridView1.Columns.Item(7).DataPropertyName = "EmailAddress"
        DataGridView1.Columns.Item(7).ReadOnly = True
        'DataGridView1.Columns.Add("serv_beg", "Beg Date")
        'DataGridView1.Columns.Item(8).DataPropertyName = "serv_beg"
        'DataGridView1.Columns.Item(8).ReadOnly = True
        DataGridView1.Columns.Item(8).Visible = False
        'DataGridView1.Columns.Add("Sent", "Sent")
        'DataGridView1.Columns.Item(9).DataPropertyName = "Sent"
        'DataGridView1.Columns.Item(9).Width = 10
        DataGridView1.Columns.Item(9).ReadOnly = True
        'DataGridView1.Columns.Add("SentDate", "Date Sent")
        'DataGridView1.Columns.Item(10).DataPropertyName = "SentDate"
        DataGridView1.Columns.Item(10).ReadOnly = True
        DataGridView1.Columns.Item(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DataGridView1.Columns.Add("bill_date", "Date Billed")
        'DataGridView1.Columns.Item(11).DataPropertyName = "bill_date"
        DataGridView1.Columns.Item(11).ReadOnly = True
        DataGridView1.Columns.Item(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub
End Class