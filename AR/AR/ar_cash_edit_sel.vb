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

Public Class ar_cash_edit_sel
    Inherits System.Windows.Forms.Form
    Dim SelectedIndex As Integer
    Public rowvalue, colvalue As Object
    Public saved_chk_num As Object

    Private Sub rebuild_grid()  'ByVal sql As String)

        sqlstmnt = "Select chk_alloc, invoice, entry_num, memo, chk_num from cash_tmp1 where batch_num = '" & selected_bat_num & "' order by entry_num"

        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sqlstmnt)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        selected_lookup_num = ""

        On Error Resume Next
        If SelectedIndex > 0 Then
            DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
            DataGridView1.Rows(SelectedIndex).Selected = True
            DataGridView1.Rows(SelectedIndex).Cells(0).Selected = True
            DataGridView1.PerformLayout()
        Else
            DataGridView1.Rows(0).Selected = False
        End If
        On Error GoTo 0

        DataGridView1.AutoResizeColumns()
        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing

        Call calc_bat_Tot()

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = selected_bat_num.ToString
            selected_line_num = CInt(DataGridView1.Item("entry_num", e.RowIndex).Value.ToString)
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

        Call calc_bat_Tot()

    End Sub


    Public Sub calc_bat_Tot()
        sqlstmnt = "Select * from cash_Tmp1 where batch_num = " & selected_bat_num
        tot_amt = CDec(ETSSQL.GetTotalPayments(sqlstmnt))
        bat_bal.Text = String.Format("{0:f2}", tot_amt)
    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        prtDestination = 0
        prtreportfilename = (ar_report_path & "arcbatch.rpt")
        CrystalForm.ShowDialog()
    End Sub

    Private Sub AddEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEntry.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        entry_type = "ADD_EDIT"
        ar_cash_batch.ShowDialog()

        Call rebuild_grid()
    End Sub

    Private Sub del_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles del.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Selected = True Then
                sqlstmnt = "delete from cash_Tmp1 where batch_num = '" & selected_bat_num & "' and entry_num = '" & selected_line_num & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If
        Next


        rebuild_grid()
    End Sub

    Private Sub ar_cash_edit_sel_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        DataGridView1.Columns.Add("chk_alloc", "Chk Alloc")
        DataGridView1.Columns.Item(0).DataPropertyName = "chk_alloc"
        DataGridView1.Columns.Item(0).DefaultCellStyle.Format = "F2"
        DataGridView1.Columns.Item(0).ReadOnly = False
        DataGridView1.Columns.Add("memo", "Memo")
        DataGridView1.Columns.Item(1).ReadOnly = False
        DataGridView1.Columns.Item(1).DataPropertyName = "Memo"
        DataGridView1.Columns.Add("Chk_num", "CHK #")
        DataGridView1.Columns.Item(2).DataPropertyName = "chk_num"
        DataGridView1.Columns.Item(2).ReadOnly = False
        DataGridView1.Columns.Add("cr_acct_nu", "ACCT #")
        DataGridView1.Columns.Item(3).DataPropertyName = "cr_Acct_nu"
        DataGridView1.Columns.Item(3).ReadOnly = False
        DataGridView1.Columns.Add("invoice", "Invoice")
        DataGridView1.Columns.Item(4).DataPropertyName = "invoice"
        DataGridView1.Columns.Item(4).ReadOnly = True
        DataGridView1.Columns.Add("entry_num", "Entry #")
        DataGridView1.Columns.Item(5).ReadOnly = True
        DataGridView1.Columns.Item(5).DataPropertyName = "entry_num"
        ctrform(Me)
        selectedcell = False

        rebuild_grid()

    End Sub

    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click

        For Each row As DataGridViewRow In DataGridView1.Rows
            'change chk_alloc, net_Check, gross amt 
            sqlstmnt = "update cash_tmp1 set chk_alloc = '" & row.Cells("chk_alloc").Value.ToString & "'  , gross_Amt = '" & row.Cells("chk_alloc").Value.ToString & "' , memo = '" & row.Cells("memo").Value.ToString & "' where invoice = '" & row.Cells("invoice").Value.ToString & "' and entry_num = '" & row.Cells("entry_num").Value.ToString & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)
        Next

        Me.Dispose()

    End Sub
End Class