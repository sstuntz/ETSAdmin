Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.String
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports System.Exception

Public Class ar_det_app
    Inherits System.Windows.Forms.Form
    Public check_alloc_comp As String
    Dim SelectedIndex As Integer

    Private Sub rebuild_grid()  'ByVal sql As String)
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sqlstmnt)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        selected_lookup_num = ""
        If SelectedIndex > 0 Then
            DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
            DataGridView1.Rows(SelectedIndex).Selected = True
            DataGridView1.Rows(SelectedIndex).Cells(0).Selected = True
            DataGridView1.PerformLayout()
        Else
            On Error Resume Next
            DataGridView1.Rows(0).Selected = False

            On Error GoTo 0
        End If
        Call check_alloc_tot()
        DataGridView1.AutoResizeColumns()

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_invoice = DataGridView1.Item("invoice", e.RowIndex).Value.ToString
            selected_line_num = CInt(DataGridView1.Item("line_num", e.RowIndex).Value.ToString)
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

        Call check_alloc_tot()

    End Sub

    Private Sub dataGridView1_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            Call check_alloc_tot()
        End If
    End Sub

    Private Sub datagridview1_dataerror(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        If e.Exception IsNot Nothing Then
            MsgBox("Please enter a number or 0.")
            e.Cancel = True
        End If

    End Sub

    Public Sub check_alloc_tot()
        tot_amt = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not IsDBNull(row.Cells("chk_alloc").Value) Then
                tot_amt = tot_amt + CDec(row.Cells("chk_alloc").Value)
            End If
        Next

        TextBox1.Text = String.Format("{0:f2}", tot_amt)
        txtfields(6).Text = String.Format("{0:f2}", (Val(txtfields(1).Text) - tot_amt))
        txtfields(1).Text = String.Format("{0:f2}", Val(txtfields(1).Text))

    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        entry_type = "CANCEL"
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ar_det_app_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoGenerateColumns = False


        Dim SearchTerm As String
        SearchTerm = Me.AccessibleDescription
        Dim SearchDate As String
        SearchDate = Me.AccessibleName

        Select Case function_type

            Case "VENDOR"
                If Len(SearchTerm) = 0 Then
                    'sort by invoice.name_key  and encumbered date
                    sqlstmnt = "select *, (isnull(bal_due,0) - isnull(chk_alloc,0)) as newbal from invoice  left outer join cash_tmp1 on invoice.inv_num = cash_tmp1.inv_num and invoice.line_num = cash_tmp1.line_num where invoice.paid = 'N' and invoice.void = 'N' and invoice.name_key = '" & SearchTerm & "'"
                Else
                    'sort by invoice.name_key  and encumbered date
                    sqlstmnt = "select *, (isnull(bal_due,0) - isnull(chk_alloc,0)) as newbal from invoice  left outer join cash_tmp1 on invoice.inv_num = cash_tmp1.inv_num and invoice.line_num = cash_tmp1.line_num where invoice.paid = 'N' and invoice.void = 'N' and invoice.name_key = '" & SearchTerm & "' and invoice.encum_Date = '" & SearchDate & "'"
                End If
            Case "CLIENT"
                'sort by invoice.cc_num
                sqlstmnt = "select *, (isnull(bal_due,0) - isnull(chk_alloc,0)) as newbal from invoice  left outer join cash_tmp1 on invoice.inv_num = cash_tmp1.inv_num and invoice.line_num = cash_tmp1.line_num where invoice.paid = 'N' and invoice.void = 'N' and invoice.cc_num = '" & selected_name_key & "' order by invoice.cc_num"
            Case Else
                sqlstmnt = "select *, (isnull(bal_due,0) - isnull(chk_alloc,0)) as newbal from invoice left join cash_tmp1 on invoice.inv_num = cash_tmp1.inv_num and invoice.line_num = cash_tmp1.line_num "
                sqlstmnt = sqlstmnt & "where invoice.paid = 'N' and invoice.void = 'N' and invoice.invoice = '" & selected_invoice & "' order by invoice.name_key"
                selected_name_key = ETSSQL.GetOneSQLValue("select name_Key as thevalue from invoice where invoice = '" & selected_invoice & "'")
                selected_screen_nam = ETSSQL.GetOneSQLValue("select screen_nam as thevalue from invoice where invoice = '" & selected_invoice & "'")
        End Select

        DataGridView1.Columns.Add("invoice", "Invoice")
        DataGridView1.Columns.Item(0).DataPropertyName = "invoice"
        DataGridView1.Columns.Item(0).ReadOnly = True
        DataGridView1.Columns.Add("line_num", "Line")
        DataGridView1.Columns.Item(1).DataPropertyName = "line_num"
        DataGridView1.Columns.Item(1).ReadOnly = True
        DataGridView1.Columns.Item(1).Width = 20
        DataGridView1.Columns.Add("cc_name", "Client")
        DataGridView1.Columns.Item(2).DataPropertyName = "cc_name"
        DataGridView1.Columns.Item(2).ReadOnly = True
        DataGridView1.Columns.Add("newbal", "Bal Due")
        DataGridView1.Columns.Item(3).DataPropertyName = "newbal"
        DataGridView1.Columns.Item(3).DefaultCellStyle.Format = "f2"
        DataGridView1.Columns.Item(3).ReadOnly = True
        DataGridView1.Columns.Add("chk_alloc", "Amt this batch")
        DataGridView1.Columns.Item(4).DataPropertyName = "chk_alloc"
        DataGridView1.Columns.Item(4).DefaultCellStyle.Format = "f2"
        DataGridView1.Columns.Item(4).ReadOnly = False
        DataGridView1.Columns.Add("memo", "memo")
        DataGridView1.Columns.Item(5).DataPropertyName = "disc_acct"
        DataGridView1.Columns.Item(5).ReadOnly = False
        DataGridView1.Columns.Item(5).DefaultCellStyle.NullValue = ""
        DataGridView1.Columns.Item(5).SortMode = DataGridViewColumnSortMode.Automatic


        ctrform(Me)
        selectedcell = False

        rebuild_grid()

        'take amount to be applied (in me.tag) and put in chk alloc until used up.
        Dim AllocAmt As Decimal
        AllocAmt = CDec(Me.Tag)

        For Each row As DataGridViewRow In DataGridView1.Rows
            row.Cells("chk_alloc").Value = CDec(row.Cells("newbal").Value)
        Next

        txtfields(0).Text = selected_invoice
        txtfields(1).Text = String.Format("{0:f2}", CDec(Me.Tag))
        txtfields(2).Text = selected_screen_nam
        txtfields(3).Text = selected_name_key

        Call check_alloc_tot()

    End Sub

    Private Sub Save_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles save.Click

        If Val(txtfields(6).Text) <> 0 Then
            Response = MsgBox("The full amount to be applied has not been applied. Press YES to correct the amount to be applied. No will let you continue to edit.", MsgBoxStyle.YesNo)
            If Response = vbNo Then Exit Sub
        End If

        Select Case function_type
            Case "INVOICE"
            Case "VENDOR"
            Case "CLENT"

        End Select

        For Each row As DataGridViewRow In DataGridView1.Rows
            If IsDBNull(row.Cells("memo").Value) = True Then
                row.Cells("memo").Value = ""
            End If
            If CDec(row.Cells("chk_alloc").Value) <> 0 Or Len(row.Cells("memo").Value) <> 0 Then      'write it out
                Dim NewCashReceipt As New CashReceiptData
                NewCashReceipt = ETSSQL.GetBlankCashReceiptData
                NewCashReceipt.Agency = AgencyNum
                NewCashReceipt.BankKey = TmpCashReceiptHeader.BankKey
                NewCashReceipt.BatchDate = TmpCashReceiptHeader.BatchDate
                NewCashReceipt.BatchDesc = TmpCashReceiptHeader.BatchDesc
                NewCashReceipt.BatchNum = TmpCashReceiptHeader.BatchNum
                NewCashReceipt.BatchTotal = TmpCashReceiptHeader.BatchTotal
                NewCashReceipt.EncumDate = TmpCashReceiptHeader.EncumDate
                NewCashReceipt.EntryDate = Today
                NewCashReceipt.DiscAcct = CStr(row.Cells("memo").Value)
                NewCashReceipt.SM = "M"
                NewCashReceipt.VoidChk = "N"
                NewCashReceipt.Dflag = "N"
                NewCashReceipt.Donor = ""
                NewCashReceipt.Fund = ""
                NewCashReceipt.JrnlLine = 0
                NewCashReceipt.JrnlNum = 0
                NewCashReceipt.Glpost = "N"
                NewCashReceipt.Checked = "N"
                selected_invoice = row.Cells("invoice").Value.ToString
                selected_line_num = CInt(row.Cells("line_num").Value)

                sqlstmnt = "select * from invoice where void = 'N' and invoice = '" & selected_invoice & "' and line_num = '" & selected_line_num & "'"
                'fill data from invoice
                saved_entry_num = saved_entry_num + 1
                NewCashReceipt.EntryNum = saved_entry_num
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
                NewCashReceipt.ChkNum = TmpCashReceiptHeader.ChkNum
                NewCashReceipt.ChkDate = TmpCashReceiptHeader.ChkDate
                NewCashReceipt.GrossAmt = TmpCashReceiptHeader.GrossAmt
                NewCashReceipt.CheckAmt = TmpCashReceiptHeader.CheckAmt
                NewCashReceipt.ChkAlloc = CDec(row.Cells("chk_alloc").Value)

                sqlstmnt = "Insert into Cash_tmp1 " & NewCashReceipt.CashReceiptColumnNames & " values " & NewCashReceipt.CashReceiptColumnData
                ETSSQL.ExecuteSQL(sqlstmnt)

                NewCashReceipt = Nothing
            End If

        Next
        Me.Close()
        Me.Dispose()
    End Sub

End Class