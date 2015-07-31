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

Public Class prog_loc_lookup
    Inherits System.Windows.Forms.Form

    Dim SelectedIndex As Integer

    Private Sub rebuild_grid()  'ByVal sql As String)


        sqlstmnt = "Select prog_loc, prog_desc from prog_location  order by prog_loc"


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
            selected_lookup_num = DataGridView1.Item("prog_loc", e.RowIndex).Value.ToString
            selected_lookup_desc = DataGridView1.Item("prog_desc", e.RowIndex).Value.ToString
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
        selected_lookup_num = ""
        selected_lookup_desc = ""


        prog_loc.ShowDialog()
        rebuild_grid()

    End Sub


    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        entry_type = "EDIT"
        prog_loc.ShowDialog()

        rebuild_grid()

    End Sub


    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        'blank the variables
        selected_lookup_num = ""
        selected_lookup_desc = ""

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub prog_loc_lookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        'data1 -= prog_location

        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        DataGridView1.Columns.Add("prog_loc", "Location")
        DataGridView1.Columns.Item(0).DataPropertyName = "prog_loc"
        DataGridView1.Columns.Add("prog_desc", "Description")
        DataGridView1.Columns.Item(1).DataPropertyName = "prog_desc"
        ctrform(Me)
        selectedcell = False

        rebuild_grid()

        selectedcell = False

        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If

        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
            addacct.Enabled = True
            edit.Enabled = True
        End If

        If function_type = "LOOKUP_ONLY" Then
            addacct.Enabled = False
            edit.Enabled = False
            Accept.Enabled = True
        End If

        Call rebuild_grid()

    End Sub

End Class