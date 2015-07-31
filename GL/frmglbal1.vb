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
Imports Valid_YN
Public Class frmglbal1
    Inherits System.Windows.Forms.Form

    Dim SelectedIndex As Integer

    Public Sub rebuild_grid()
        Dim sql As String = "select acct_num, acct_Desc, cr_dr, cur_beg from chacct order by acct_num"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
        DataGridView1.Rows(selectedindex).Selected = True
        DataGridView1.Rows(selectedindex).Cells(0).Selected = True
        DataGridView1.PerformLayout()

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selected_acct_num = DataGridView1.Item("Acct_num", e.RowIndex).Value.ToString
            txtfields(0).Text = selected_acct_num
            txtfields(1).Text = DataGridView1.Item("cur_beg", e.RowIndex).Value.ToString
            _txtfields_0.Focus()

            SelectedIndex = DataGridView1.CurrentRow.Index
        End If
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        txtfields(0).Text = ""
        txtfields(1).Text = ""
        txtfields(2).Text = ""
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub CalcBegBal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CalcBegBal.Click
        'add up cur_beg bal
        Dim TotalBegBal As Decimal = 0
        Using db As Database = New Database(top_data_path)
            Dim sql As String = "select cur_beg from chacct"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            While rs.Read()
                TotalBegBal = TotalBegBal + CDec(rs("cur_beg"))
            End While
            rs.Close()
        End Using
        txtfields(2).Text = String.Format("{0:c}", TotalBegBal)

    End Sub

    Private Sub printBal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PrintBal.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glbegbal.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub frmglbal1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Call rebuild_grid()
    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            Select Case Index
                Case 0

                Case 1
                    sqlstmnt = "update chacct set cur_beg = '" & txtfields(Index).Text & "' where acct_num = '" & txtfields(0).Text & "'"
                    Call ETSSQL.ExecuteSQL(sqlstmnt)

                    'update field right away
                    Call rebuild_grid()
                    txtfields(0).Enabled = True

            End Select
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub update_Click()
        Call rebuild_grid()
    End Sub

End Class