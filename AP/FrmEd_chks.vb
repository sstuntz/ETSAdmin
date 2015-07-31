Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETS.Common.Module1
Imports PS.Common
Imports Microsoft.VisualBasic.ErrObject
Imports System.Data.SqlClient
Imports System
Imports System.Configuration

Public Class frmed_chks
    Inherits System.Windows.Forms.Form

    Public validYN As String
    Public sending As String
    Dim BalanceDue As Double
    Dim SelectedIndex As Integer

    Private Sub rebuild_grid()

        Dim sql As String = "select vouch_num,name_key,screen_nam,vouch_amt,bal_due,n_Chk_amt  from apchecks order by apchecks.sort_name, vouch_num "
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


        Call total_amt()

        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("vouch_num", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index
        edit_amt_vis.Text = FormatCurrency(DataGridView1.Item("n_chk_amt", e.RowIndex).Value.ToString, 2)
        BalanceDue = CDbl(DataGridView1.Item("bal_Due", e.RowIndex).Value.ToString)

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
        If selectedcell = False Then
            MsgBox("Nothing Selected.  Can not delete now")
            Exit Sub
        End If

        sqlstmnt = "Delete from apchecks where vouch_num = '" & selected_lookup_num & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        Call rebuild_grid()

    End Sub

    Private Sub total_amt()
        Dim tot As Double = 0
        Dim i As Integer
        For i = 0 To DataGridView1.RowCount - 1
            tot = CDbl(DataGridView1.Rows(i).Cells("n_Chk_amt").Value) + tot
        Next
        baldue.Text = FormatCurrency(tot, 2, TriState.UseDefault, TriState.UseDefault)
        numcks.Text = FormatNumber(DataGridView1.RowCount, 0)

    End Sub

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        If selectedcell = False Then
            MsgBox("Nothing Selected.")
            Exit Sub
        End If

        Select Case CDbl(edit_amt_vis.Text)
            Case Is < 0.11
                MsgBox("The check will be less than 10 cents.  Please enter a new amount.")
                edit_amt_vis.Focus()
                edit_amt_vis.SelectAll()
                Call ets_set_selected()
                Exit Sub
            Case Is > BalanceDue
                MsgBox("This will overpay the amount due.  Please enter a new amount.")
                edit_amt_vis.Focus()
                edit_amt_vis.SelectAll()
                Call ets_set_selected()
                Exit Sub
        End Select

        sqlstmnt = "update apchecks set n_Chk_amt = '" & edit_amt_vis.Text & "' where vouch_num = '" & selected_lookup_num & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)
        edit_amt_vis.Text = ""
        Call rebuild_grid()

    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Cont_process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cont_process.Click
        Me.Close()
        Me.Dispose()
        frmcompchk.Show()

    End Sub

    Private Sub edit_amt_vis_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edit_amt_vis.Enter
        edit_amt_vis.SelectAll()
        Call ets_set_selected()
    End Sub

    Private Sub edit_amt_vis_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles edit_amt_vis.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case CDbl(edit_amt_vis.Text)
                Case Is < 0.11
                    MsgBox("The check will be less than 10 cents.  Please enter a new amount.")
                    edit_amt_vis.SelectAll()
                    Call ets_set_selected()
                    Exit Sub
                Case Is > BalanceDue
                    MsgBox("This will overpay the amount due.  Please enter a new amount.")
                    edit_amt_vis.SelectAll()
                    Call ets_set_selected()
                    Exit Sub
            End Select

        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        cmdUpdate.Focus()

    End Sub

    Private Sub edit_amt_vis_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edit_amt_vis.Leave
        edit_amt_vis.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub frmed_chks_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        'this eliminates the annoying beep
        If KeyAscii = 13 Then KeyAscii = 0
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub frmed_chks_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Call rebuild_grid()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

End Class