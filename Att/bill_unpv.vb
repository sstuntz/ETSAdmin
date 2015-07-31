Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient

Public Class bill_unpv
    Inherits System.Windows.Forms.Form

    Dim PVVoid As New List(Of PVData)
    Dim PVBillC As New List(Of BillControlData)

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub encum_Date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles encum_Date.Enter
        Call ets_set_selected()
    End Sub

    Private Sub encum_Date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles encum_Date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = encum_Date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")

            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                encum_Date.Text = CDate(retdate).ToShortDateString
                Process.Enabled = True
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


    Private Sub bill_unpv_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        If function_type = "VOID" Then
            Process.Text = "Void Selected PV"
            Me.Text = "Voiding Unsupported PVs"
            encum_Date.Enabled = False
            invoice_string.Enabled = False
            inv_date.Enabled = False
            'Process.Enabled = True
        End If

        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoGenerateColumns = False

        DataGridView1.Columns.Add("Contract_key", "Contract")
        DataGridView1.Columns.Item(0).DataPropertyName = "Contract_key"
        DataGridView1.Columns.Add("cont_desc", "Description")
        DataGridView1.Columns.Item(1).DataPropertyName = "cont_desc"
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

    Private Sub inv_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles inv_date.Enter
        Call ets_set_selected()
    End Sub

    Private Sub inv_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles inv_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))

        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = inv_date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")

            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                selected_start_date = CDate(retdate)
                Process.Enabled = True
                inv_date.Text = CDate(retdate).ToShortDateString
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

            Dim NewInvoice As String = invoice_string_Create(End_Date.Text, invoice_string.Text)

            If Len(NewInvoice) <> 0 Then
                invoice_string.Text = NewInvoice.ToString
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
            invoice_string.Text = GetNextCompanyInvoiceNum.ToString
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

    Private Sub Process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Click

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

        If function_type <> "VOID" Then
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
        End If ' do not check if void

        selected_inv_date = CDate(inv_date.Text)
        id_num = invoice_string.Text
        selected_start_date = CDate(start_date.Text)
        selected_end_date = CDate(End_Date.Text)


        If function_type = "VOID" Then
            sqlstmnt = "select * from invoice where invoice = '" & invoice_string.Text & "'"
            Dim CompInv As New CompanyInvoiceData
            CompInv = ETSSQL.GetCompanyInvoiceDataOne(sqlstmnt)
            If CompInv.Glpost = "Y" Then
                MsgBox("This billing has been posted to the general ledger and can not be voided.")
                Exit Sub
            End If
            If CompInv.PayAmt <> 0 Then
                MsgBox("This billing has received cash and can not be voided.")
                Exit Sub
            End If

            sqlstmnt = " update invoice set void = 'Y' where invoice = '" & invoice_string.Text & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)

            sqlstmnt = " update mmpv_hist set void = 'Y' where contract_key = '" & selected_contract_key & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)

            sqlstmnt = " update bill_cntrl set comment = 'Void' where contract_key = '" & selected_contract_key
            sqlstmnt = sqlstmnt & "' and serv_beg = '" & start_date.Text
            sqlstmnt = sqlstmnt & "' and serv_End = '" & End_Date.Text & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)

            'repair contract year to date amount
            Call update_contract_ytd(selected_contract_key)
            selectedcell = False
            DataGridView1.Rows.Clear()
            Ref_list.Focus()

        Else ' this creates an unsupported PV

            sqlstmnt = "Delete mmpv_tmp"
            ETSSQL.ExecuteSQL(sqlstmnt)
       
            selected_lookup_num = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "pv_form")
            If Len(selected_lookup_num) = 0 Then
                MsgBox("There is no PV form for this contract.")
                Exit Sub
            End If

            pv_Type = "CREATE"
            Dim NewPv As PVData
            sqlstmnt = " select * from mmpv where pv_form = '" & selected_lookup_num & "'"
            Dim NoPv As Integer = ETSCommon.CheckNumRecords(sqlstmnt)
            If NoPv = 0 Then
                MsgBox("There is no PV Template set up for this contract.")
                Exit Sub
            End If

            NewPv = ETSSQL.GetOnePVData(sqlstmnt)

            NewPv.Pvdate7 = CDate(inv_date.Text)
            NewPv.VinvNum13 = invoice_string.Text
            NewPv.VinvNum37 = invoice_string.Text
            NewPv.FrmDate40 = CDate((start_date.Text))
            NewPv.ToDate41 = CDate(End_Date.Text)
            NewPv.Print = "Y"
            NewPv.Up1 = CDec(ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "unit_rate"))
            sqlstmnt = " insert into mmpv_tmp " & NewPv.PVColumnNames & " values " & NewPv.PVColumnData
            ETSSQL.ExecuteSQL(sqlstmnt)
            entry_type = "EDIT"
            frmmmpv1.ShowDialog()
            Me.Dispose()
            'add attachements here i think   scsjri

            selectedcell = False
        End If
    End Sub

    Private Sub Ref_list_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Ref_list.Click

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
        Dim rs As DataSet
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()

        If function_type = "VOID" Then

            sqlstmnt = "Select  distinct mmpv_hist.contract_key, * from mmpv_hist "
            sqlstmnt = sqlstmnt & " INNER Join cc_cont ON cc_Cont.contract_key = mmpv_hist.contract_key  where void = 'N' and "
            sqlstmnt = sqlstmnt & "[frm_date-40] >= '" & start_date.Text
            sqlstmnt = sqlstmnt & "' and [to_date-41] <= '" & End_Date.Text
            sqlstmnt = sqlstmnt & "' order by mmpv_hist.contract_key "

            PVVoid = ETSSQL.GetPVData(sqlstmnt)

            If PVVoid.Count = 0 Then
                MsgBox("No Unsupported PVs to Void.")
                Exit Sub
            End If

        Else 'not a void contract
            sqlstmnt = "select * from bill_cntrl left join cc_cont on bill_cntrl.contract_key = cc_cont.contract_key where (cc_cont.pv_form is not null and ltrim(rtrim(cc_cont.pv_form)) <> '' and left(cc_cont.bill_type,1) = '9') and serv_beg = '"
           sqlstmnt = sqlstmnt & start_date.Text & "' and serv_end = '"
            sqlstmnt = sqlstmnt & End_Date.Text
            sqlstmnt = sqlstmnt & "' and inv_num = 0 "
            'sqlstmnt = sqlstmnt & " (serv_beg = '"
            'sqlstmnt = sqlstmnt & start_date.Text & "' and serv_end = '"
            'sqlstmnt = sqlstmnt & End_Date.Text
            'sqlstmnt = sqlstmnt & "' ))"
            sqlstmnt = sqlstmnt & " order by cc_cont.contract_key "

            PVBillC = ETSSQL.GetBillControlData(sqlstmnt)

            If PVBillC.Count = 0 Then
                MsgBox("Nothing left to bill")
                Exit Sub
            End If

        End If

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
                '    DataGridView1.PerformLayout()
        End Select


        DataGridView1.AutoResizeColumns()
        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing
        'put dates in rpthead
        sqlstmnt = "update rpthead set beg_date = '" & start_date.Text & "', end_date = ' " & End_Date.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_contract_key = DataGridView1.Item("contract_key", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

        If function_type = "VOID" Then
            'find the right one in pvvoid and fill invoice, encum date and inv date
            For Each pvold In PVVoid
                If pvold.ContractKey = selected_contract_key Then
                    invoice_string.Text = pvold.VinvNum37.ToString
                    inv_date.Text = pvold.Pvdate7.ToShortDateString
                    encum_Date.Text = pvold.Pvdate7.ToShortDateString
                End If
            Next
        End If

        invoice_string.Text = invoice_string_Create(End_Date.Text, selected_contract_key)
        invoice_string.Focus()


    End Sub
End Class