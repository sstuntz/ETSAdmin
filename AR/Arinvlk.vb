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
Imports System.Globalization

Public Class invoicelookup
    Inherits System.Windows.Forms.Form

    Dim SelectedIndex As Integer
    Dim sql As String

    Private Sub rebuild_grid()
        ' Dim sql As String = "select inv_num, line_num, invoice, screen_nam, bal_due, alloc_amt, cc_num, cc_name from invoice where void = 'N' and dflag = 'N' and paid = 'N' order by inv_num, line_num"
        Dim rs As DataSet
        sql = "select inv_num, line_num, invoice, screen_nam, bal_due, alloc_amt, cc_num, cc_name from invoice where inv_num in (select distinct inv_num from invoice) and void = 'N' and dflag = 'N' and paid = 'N' and bal_due <> 0 order by invoice desc"

        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
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

        DataGridView1.AutoResizeColumns()
        invoice.Text = ""
        invoice_id.Text = ""

        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("inv_num", e.RowIndex).Value.ToString
            selected_line_num = CInt(DataGridView1.Item("line_num", e.RowIndex).Value.ToString)
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

        Dim bm As BindingManagerBase = DataGridView1.BindingContext(DataGridView1.DataSource, DataGridView1.DataMember)
        Dim dr As DataRow = CType(bm.Current, DataRowView).Row
        Dim cm As CurrencyManager = CType(DataGridView1.BindingContext(DataGridView1.DataSource), CurrencyManager)
        SelectedIndex = cm.Position
        selected_lookup_num = dr.Item(0).ToString
        selected_line_num = CInt(dr.Item(1).ToString)

    End Sub

    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
        entry_type = "ADD"
        arinv.ShowDialog()
        Call rebuild_grid()
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        selected_lookup_num = " "
        selected_lookup_desc = " "
        selected_line_num = 0
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        selected_inv_num = CInt(selected_lookup_num)

        entry_type = "EDIT"
        arinv.ShowDialog()
        Call rebuild_grid()

    End Sub

    Private Sub invoicelookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        '   DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

        DataGridView1.Columns.Item(4).DefaultCellStyle.Format = "N2"
        DataGridView1.Columns.Item(5).DefaultCellStyle.Format = "N2"

        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        Else
            Accept.Enabled = False
        End If

        rebuild_grid()

        invoice_id.Focus()


    End Sub

    Private Sub invoice_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles invoice.Enter
        Call ets_set_selected()
        invoice.BackColor = Color.Aqua
    End Sub

    Private Sub invoice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles invoice.TextChanged
        Dim rownum As Integer
        Dim startletter As String

        ''  invoice.BackColor = Color.White
        'If Len(invoice.Text) = 1 Then
        '    rebuild_grid()
        'End If
        For rownum = 0 To DataGridView1.RowCount - 1
            startletter = UCase(invoice.Text)
            If DataGridView1.Rows(rownum).Cells("inv_num").Value.ToString.StartsWith(startletter, True, CultureInfo.InvariantCulture) Then
                DataGridView1.Rows(rownum).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(rownum).Cells(0)
                DataGridView1.Rows(rownum).Selected = True
                Exit For
            End If
        Next
    End Sub

    Private Sub invoice_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles invoice.Leave
        invoice.BackColor = Color.White
        '  invoice.Text = ""
    End Sub

    Private Sub invoice_id_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles invoice_id.Enter
        Call ets_set_selected()
        invoice_id.BackColor = Color.Aqua
    End Sub

    Private Sub invoice_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles invoice_id.TextChanged
        Dim rownum As Integer
        Dim startletter As String

        For rownum = 0 To DataGridView1.RowCount - 1
            startletter = UCase(invoice_id.Text)

            If DataGridView1.Rows(rownum).Cells("invoice1").Value.ToString.StartsWith(startletter, True, CultureInfo.InvariantCulture) Then
                DataGridView1.Rows(rownum).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(rownum).Cells(0)
                DataGridView1.Rows(rownum).Selected = True
                selectedcell = True
                selected_lookup_num = DataGridView1.Rows(rownum).Cells(0).Value.ToString     'DataGridView1.Item("inv_num", e.RowIndex).Value.ToString
                selected_line_num = CInt(DataGridView1.Rows(rownum).Cells(1).Value.ToString)                         'Item("line_num", e.RowIndex).Value.ToString)
                Exit For
            End If
        Next
    End Sub

    Private Sub invoice_id_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles invoice_id.Leave
        ' invoice_id.Text = ""
        invoice_id.BackColor = Color.White
    End Sub

End Class