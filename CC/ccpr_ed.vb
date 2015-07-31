Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ps.common.Database
Imports ETS.Common.Module1
Imports ps.common
Imports System.Configuration
Imports System.Data.SqlClient
Imports ETS.clpr_mod
Imports ETS.stpr_mod
Imports ETS.Common
Imports ETS.pr_common


Public Class ccpr_ed
    Inherits System.Windows.Forms.Form
    '****************
    'revision History
    'original date of this form is 6/23/96 -SCS

    '****************
    Private Sub rebuild_grid()

        Dim sql As String = "select distinct pay_num, name_key, sort_name, entry_num from cctime where (paid = 'N' or paid = 'S') and void = 'N'  order by sort_name, entry_num"

        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridview1.DataSource = rs.Tables(0)

        DataGridview1.ClearSelection()
        DataGridview1.CurrentCell = Nothing

    End Sub

    Private Sub EdtimeGrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridview1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_name_key = DataGridview1.Item("name_key", e.RowIndex).Value.ToString
            selected_entry_num = CInt(DataGridview1.Item("entry_num", e.RowIndex).Value.ToString)
            selected_pay_num = DataGridview1.Item("pay_num", e.RowIndex).Value.ToString
        End If

    End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        entry_type = "EDIT"
        cc_ed_time.ShowDialog()
        Call rebuild_grid()
        selectedcell = False

    End Sub

    Private Sub ccpr_ed_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error Resume Next

        ctrform(Me)
        rebuild_grid()
        Me.BringToFront()

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        selected_name_key = ""
        selected_entry_num = 0
        selected_pay_num = ""
        Me.Close()
    End Sub
End Class