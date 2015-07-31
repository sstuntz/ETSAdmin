Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ps.common.Database
Imports ETS.Common.Module1
Imports ps.common
Imports System.Configuration
Imports System.Data.SqlClient

Public Class dedlkup
    Inherits System.Windows.Forms.Form
    '****************
    'revision History
    'original date of this form is 9/23/96 -SCS

    '****************


    Private Sub rebuild_grid()
        Dim sql As String = "select ded_num, screen_nam, plan_Desc from cc_deduct order by ded_num"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing
        selected_lookup_num = ""
        selected_lookup_desc = ""

    End Sub

    Private Sub DeductGrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("ded_num", e.RowIndex).Value.ToString
            selected_ded_num = DataGridView1.Item("ded_num", e.RowIndex).Value.ToString
            selected_lookup_desc = DataGridView1.Item(2, e.RowIndex).Value.ToString
        End If
    End Sub

    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        ' entry_type = ""
        Me.Close()
    End Sub

    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
        entry_type = "ADD"
        ccdeduct.ShowDialog()
        Call rebuild_grid()
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        selected_ded_num = " " '
        selected_screen_nam = " "
        selected_plan_desc = " "

        Me.Close()

    End Sub

    Private Sub deductslookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If
        rebuild_grid()
        ctrform(Me)
    End Sub

    Private Sub edit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        entry_type = "EDIT"
        ccdeduct.ShowDialog()
        Call rebuild_grid()
    End Sub


End Class