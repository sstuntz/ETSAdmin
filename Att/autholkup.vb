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

Public Class autholookup
    Inherits System.Windows.Forms.Form

    Dim SelectedIndex As Integer

    Private Sub rebuild_grid()  'ByVal sql As String)

        If Val(CStr(new_Fiscal)) = 0 Then
            new_Fiscal = CInt(CStr(Year(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 6, Today))))
        End If

        If current_fiscal <> new_Fiscal Then
            sqlstmnt = "Select autho_num, name_key, sort_name, contract_key from cc_autho where year(autho_End) <> '" & new_Fiscal & "' order by sort_name"
        Else
            sqlstmnt = "Select autho_num, name_key, sort_name, contract_key from cc_autho where year(autho_End) = '" & new_Fiscal & "' order by sort_name"
        End If

        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sqlstmnt)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        selected_lookup_num = ""
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
            selected_lookup_num = DataGridView1.Item("autho_num", e.RowIndex).Value.ToString
            selected_name_key = DataGridView1.Item("name_key", e.RowIndex).Value.ToString
            selected_sort_name = DataGridView1.Item("sort_name", e.RowIndex).Value.ToString
            selected_contract_key = DataGridView1.Item("contract_key", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

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
        frmcc_autho.ShowDialog()

        rebuild_grid()

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        entry_type = "EDIT"
        frmcc_autho.ShowDialog()

        rebuild_grid()

    End Sub

    Private Sub autholookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        DataGridView1.Columns.Add("autho_num", "Autho")
        DataGridView1.Columns.Item(0).DataPropertyName = "autho_num"
        DataGridView1.Columns.Add("name_key", "Name Key")
        DataGridView1.Columns.Item(1).DataPropertyName = "name_key"
        DataGridView1.Columns.Add("sort_name", "Sort Name")
        DataGridView1.Columns.Item(2).DataPropertyName = "sort_name"
        DataGridView1.Columns.Add("contract_key", "Contract")
        DataGridView1.Columns.Item(3).DataPropertyName = "contract_key"
        ' DataGridView1.Columns.Item(3).DefaultCellStyle.Format = "N2"
        ctrform(Me)
        selectedcell = False

        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If

        rebuild_grid()

    End Sub
End Class