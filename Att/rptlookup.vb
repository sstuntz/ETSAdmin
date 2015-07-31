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

Public Class rptlookup
    Inherits System.Windows.Forms.Form
    Dim SelectedIndex As Integer
    Dim all_selected_rpt_num As String

    Private Sub rebuild_grid()  'ByVal sql As String)
        Dim sql As String = "select rpt_num, rpt_Desc from rpt_type order by rpt_num"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
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
            selected_rpt_num = DataGridView1.Item("rpt_num", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index
        all_selected_rpt_num = all_selected_rpt_num & selected_rpt_num

    End Sub

    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        If Len(all_selected_rpt_num) > 9 Then
            MsgBox("You can only select three reports.  the gird will be cleared and you can select again.")
            rebuild_grid()
            selected_rpt_num = ""
            all_selected_rpt_num = ""
            Exit Sub
        End If
        selected_rpt_num = all_selected_rpt_num
        Me.Dispose()

    End Sub

    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click

        entry_type = "ADD"
        rpt_Type_frm.ShowDialog()

        rebuild_grid()

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click

        Me.Dispose()

    End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        entry_type = "EDIT"
        rpt_Type_frm.ShowDialog()
        rebuild_grid()

    End Sub

    Private Sub rptlookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.Columns.Add("rpt_num", "Report #")
        DataGridView1.Columns.Item(0).DataPropertyName = "rpt_num"
        DataGridView1.Columns.Add("rpt_desc", "Report Description")
        DataGridView1.Columns.Item(1).DataPropertyName = "rpt_Desc"

        ctrform(Me)
        selectedcell = False
        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If
        rebuild_grid()

        selectedcell = False

        ctrform(Me)

    End Sub


End Class