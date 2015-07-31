Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ps.common.Database
Imports ETS.Common.Module1
Imports ps.common
Imports System.Configuration
Imports System.Data.SqlClient

Public Class pclasslkup
    Inherits System.Windows.Forms.Form
    '****************
    'revision History
    'original date of this form is 9/23/96 -SCS

    '****************

    Private Sub rebuild_grid()
        Dim sql As String = "select  pay_class, pay_Desc from cc_paycl order by pay_class"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        Datagridview1.DataSource = rs.Tables(0)
        Datagridview1.ClearSelection()
        Datagridview1.CurrentCell = Nothing

    End Sub

    Private Sub PayClGrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagridview1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = Datagridview1.Item("payclass", e.RowIndex).Value.ToString
            selected_lookup_desc = Datagridview1.Item("paydesc", e.RowIndex).Value.ToString
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
        On Error Resume Next
        entry_type = "ADD"
        frmpclass.ShowDialog()
        rebuild_grid()

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        selected_lookup_num = " " '
        selected_screen_nam = " "
        selected_plan_desc = " "

        Me.Dispose()

    End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        entry_type = "EDIT"
        frmpclass.ShowDialog()
        rebuild_grid()

    End Sub

    Private Sub pclasslookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        '	On Error Resume Next
        ctrform(Me)
        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If
        rebuild_grid()
    End Sub
End Class