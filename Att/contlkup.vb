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

Public Class contnumlookup
    Inherits System.Windows.Forms.Form
    Dim SelectedIndex As Integer

    Private Sub rebuild_grid()  'ByVal sql As String)
        Select Case function_type
            Case "CLD"
                Me.Text = "Contract Lookup - Closed Contracts "
                sqlstmnt = "select cont_id_num, bill_type, mmars_num,amend_num,cont_desc,contract_key, redpy_dol from cc_Cont where active = " & "'N'" & " order by contract_key"

            Case "READY_PAY"
                sqlstmnt = "select cont_id_num,  bill_type, mmars_num,amend_num,cont_desc,contract_key, redpy_dol from cc_Cont where active = " & "'Y'" & " and redpy_dol <> 0 order by contract_key"
                set_closed_flag.Visible = False
                Accept.Enabled = True
            Case Else
                Me.Text = "Contract Lookup - Open Contracts "
                sqlstmnt = "select cont_id_num, bill_type, mmars_num,amend_num,cont_desc,contract_key, redpy_dol from cc_Cont where active = " & "'Y'" & " order by contract_key"
        End Select
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
        End Select

        DataGridView1.PerformLayout()
        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_cont_id_num = DataGridView1.Item("cont_id_num", e.RowIndex).Value.ToString
            selected_mmars_num = DataGridView1.Item("mmars_num", e.RowIndex).Value.ToString
            selected_amend_num = DataGridView1.Item("amend_num", e.RowIndex).Value.ToString
            selected_contract_key = DataGridView1.Item("contract_key", e.RowIndex).Value.ToString
            selected_desc = DataGridView1.Item("cont_desc", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub

    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click

        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
        On Error Resume Next
        selected_contract_key = ""
        entry_type = "ADD"
        ATTContract.ShowDialog()

        rebuild_grid()

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click

        selected_cont_desc = ""
        selected_cont_id_num = ""
        selected_contract_key = ""

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edit.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        entry_type = "EDIT"
        ATTContract.ShowDialog()

        rebuild_grid()

    End Sub

    Private Sub contnumlookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        DataGridView1.Columns.Add("cont_id_num", "Contract")
        DataGridView1.Columns.Add("mmars_num", "MMARS #")
        DataGridView1.Columns.Add("amend_num", "Amend")
        DataGridView1.Columns.Add("cont_desc", "Description")
        DataGridView1.Columns.Add("Bill_type", "Bill Type")
        DataGridView1.Columns.Add("contract_key", "C Key")
        DataGridView1.Columns.Add("redpy_dol", "Amount")

        DataGridView1.Columns.Item(0).DataPropertyName = "cont_id_num"
        DataGridView1.Columns.Item(3).DataPropertyName = "cont_desc"
        DataGridView1.Columns.Item(4).DataPropertyName = "Bill_type"
        DataGridView1.Columns.Item(1).DataPropertyName = "mmars_num"
        DataGridView1.Columns.Item(2).DataPropertyName = "amend_num"
        DataGridView1.Columns.Item(5).DataPropertyName = "contract_key"
        DataGridView1.Columns.Item(6).DataPropertyName = "redpy_dol"

        DataGridView1.Columns.Item(6).DefaultCellStyle.Format = "f2"

        DataGridView1.Columns.Item(5).Visible = False
        DataGridView1.Columns.Item(6).Visible = False

        DataGridView1.Columns.Item(4).Width = 50
        DataGridView1.Columns.Item(1).Width = 50
        DataGridView1.Columns.Item(2).Width = 50

        ctrform(Me)
        selectedcell = False

        rebuild_grid()

        selectedcell = False
        selected_grouping = ""

        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If

        If function_type = "CLD" Then
            addacct.Enabled = False
            ' Edit.Enabled = False
            Accept.Enabled = False
            set_closed_flag.Text = "Click here to re-activate this contract."
        End If

        If function_type = "READY_PAY" Then
            ShowAllContracts.Visible = True
            DataGridView1.Columns.Item(2).Visible = False
            DataGridView1.Columns.Item(6).Visible = True
            ' DataGridView1.Columns.Item(6).
        End If

    End Sub

    Private Sub set_closed_flag_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles set_closed_flag.Click

        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        If function_type <> "CLD" Then

            Response = MsgBox("Are you sure you want to close this contract?", MsgBoxStyle.YesNo)
        Else
            Response = MsgBox("Are you sure you want to re-open this contract?", MsgBoxStyle.YesNo)
        End If

        If Response = MsgBoxResult.Yes Then
            'select the record, edit and update it
            If function_type <> "CLD" Then
                sqlstmnt = " update cc_cont set active = 'N'  where contract_key =  '" & selected_contract_key & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
            Else
                sqlstmnt = " update cc_cont set active = 'Y'  where contract_key =  '" & selected_contract_key & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If

        End If


        rebuild_grid()


    End Sub

    Private Sub ShowAllContracts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAllContracts.Click
        function_type = ""
        rebuild_grid()

    End Sub
End Class