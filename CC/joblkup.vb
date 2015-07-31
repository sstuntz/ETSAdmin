Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ps.common.Database
Imports ETS.Common.Module1
Imports ps.common
Imports System.Configuration
Imports System.Data.SqlClient

Public Class jobnumlookup
    Inherits System.Windows.Forms.Form
    '****************
    'revision History
    'original date of this form is 9/23/96 -SCS

    '****************

    Private Sub rebuild_grid()
        Dim sql As String = "select job_num, Job_Desc, pay_class from ccjob order by job_num"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing
    End Sub

    Private Sub JobnumGrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_job_num = DataGridView1.Item("jobnum", e.RowIndex).Value.ToString
            selected_lookup_num = DataGridView1.Item("jobnum", e.RowIndex).Value.ToString
            selected_lookup_desc = DataGridView1.Item("jobdesc", e.RowIndex).Value.ToString
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
        selected_lookup_num = ""
        entry_type = "ADD"
        job.ShowDialog()
        Call rebuild_grid()
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        selected_lookup_num = " " '
        selected_screen_nam = " "
        selected_plan_desc = " "
        Me.Close()

    End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        entry_type = "EDIT"
        job.ShowDialog()
        Call rebuild_grid()
    End Sub

    Private Sub jobnumlookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        selected_lookup_num = ""
        Call rebuild_grid()
    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Call ets_set_selected()
        txtfields.BackColor = Color.Aqua
    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            txtfields.Text = UCase(txtfields.Text)
            addacct.Enabled = False

            On Error Resume Next
            sqlstmnt = "Select * from ccjob where job_num = " & Chr(34) & txtfields.Text & Chr(34)
            sqlstmnt = sqlstmnt & " ORDER BY job_num"
            '  Data1.RecordSource = sqlstmnt

            ' If Data1.Recordset.RecordCount = 0 Then
            'MsgBox "Please re-enter a valid job number."
            ' Call ets_set_selected
            ' Exit Sub
            ' End If
            On Error GoTo 0



            '  num = 0
            ' On Error Resume Next
            ' Data1.Recordset.MoveFirst
            ' If Err = 3021 Then
            ' MsgBox "Please re-enter a valid job num."
            ' Call ets_set_selected
            ' Exit Sub
            ' End If
            ' On Error GoTo 0




        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        txtfields.BackColor = Color.White
    End Sub

    Private Sub txtfields_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfields.TextChanged
        Dim rownum As Integer
        Dim startletter As String
        For rownum = 0 To DataGridView1.RowCount - 1
            startletter = UCase(txtfields.Text) '& e.KeyCode.ToString
            If DataGridView1.Rows(rownum).Cells("jobnum").Value.ToString.StartsWith(startletter) Then
                DataGridView1.Rows(rownum).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(rownum).Cells(0)
                SetSelectedRow()
                Exit For
            End If
        Next
    End Sub

    Public Sub SetSelectedRow()
        selectedcell = True
        selected_job_num = DataGridView1.Item("jobnum", DataGridView1.CurrentRow.Index).Value.ToString
        selected_lookup_num = DataGridView1.Item("jobnum", DataGridView1.CurrentRow.Index).Value.ToString
        selected_lookup_desc = DataGridView1.Item("jobdesc", DataGridView1.CurrentRow.Index).Value.ToString
        SelectedIndex = DataGridView1.CurrentRow.Index
    End Sub

End Class