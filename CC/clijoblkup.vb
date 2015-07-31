Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports PS.Common.Database
Imports ETS.common.Module1
Imports PS.Common
Imports System.Configuration
Imports System.Data.SqlClient


Public Class clijoblookup
    Inherits System.Windows.Forms.Form
    '****************
    'revision History
    'original date of this form is 9/23/96 -SCS

    '****************

    Private Sub rebuild_grid()
        Dim sql As String = "select cc_clijob.sort_name, cc_clijob.name_key, cc_clijob.job_num, job_desc from cc_clijob left join ccjob on ccjob.job_num = cc_clijob.job_num order by cc_clijob.sort_name"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)

        selectedcell = False
        selected_lookup_num = ""
        selected_lookup_desc = ""

        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing
        DataGridView1.AutoResizeColumns()

    End Sub

    Private Sub datagridview1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("job_num", e.RowIndex).Value.ToString
            selected_name_key = DataGridView1.Item("name_key", e.RowIndex).Value.ToString
            selected_job_num = selected_lookup_num
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
        clijob.ShowDialog()
        Call rebuild_grid()
    End Sub

    Private Sub edit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        entry_type = "EDIT"
        clijob.ShowDialog()
        Call rebuild_grid()
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        selected_lookup_num = " " '
        selected_screen_nam = " "
        selected_plan_desc = " "

        Me.Close()

    End Sub


    Private Sub clijoblookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If
        rebuild_grid()


    End Sub

    Private Sub textbox1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextBox1.Enter
        Call ets_set_selected()
        textbox1.BackColor = Color.Aqua
    End Sub

    Private Sub textbox1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            textbox1.Text = UCase(textbox1.Text)
            addacct.Enabled = False

            sqlstmnt = "Select * from cc_clijob where name_key = '" & TextBox1.Text & "'"
            sqlstmnt = sqlstmnt & " ORDER BY name_key"
    
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub textbox1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextBox1.Leave
        textbox1.BackColor = Color.White
    End Sub

    Private Sub textbox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim rownum As Integer
        Dim startletter As String
        For rownum = 0 To DataGridView1.RowCount - 1
            startletter = UCase(textbox1.Text) '& e.KeyCode.ToString
            If DataGridView1.Rows(rownum).Cells("name_key").Value.ToString.StartsWith(startletter) Then
                DataGridView1.Rows(rownum).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(rownum).Cells(0)
                setselectedrow()
                Exit For
            End If
        Next
    End Sub

    Public Sub SetSelectedRow()
        selectedcell = True
        selected_name_key = DataGridView1.Item("name_key", DataGridView1.CurrentRow.Index).Value.ToString
        selected_lookup_num = DataGridView1.Item("job_num", DataGridView1.CurrentRow.Index).Value.ToString
        selected_job_num = selected_lookup_num
        SelectedIndex = DataGridView1.CurrentRow.Index
    End Sub

End Class