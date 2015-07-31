Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ps.common.Database
Imports ETS.Common.Module1
Imports ps.common
Imports System.Configuration
Imports System.Data.SqlClient

Public Class disablookup
    Inherits System.Windows.Forms.Form
    '****************
    'revision History
    'original date of this form is 9/23/96 -SCS

    '****************

    Private Sub rebuild_grid()

        Dim sql As String = "select disab_num, disab_desc from cc_disab order by disab_num"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        Datagridview1.DataSource = rs.Tables(0)

        Datagridview1.ClearSelection()
        Datagridview1.CurrentCell = Nothing

    End Sub

    Private Sub disabgrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Datagridview1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = Datagridview1.Item("disab_num", e.RowIndex).Value.ToString
            selected_lookup_desc = Datagridview1.Item("disab_desc", e.RowIndex).Value.ToString
        End If
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
        On Error Resume Next
        entry_type = "ADD"
        selected_lookup_num = ""
        selected_lookup_desc = ""
        frmdisab.ShowDialog()
        rebuild_grid()

    End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        entry_type = "EDIT"
        frmdisab.ShowDialog()
        Call rebuild_grid()
        selectedcell = False

    End Sub

    Private Sub disablookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
            addacct.Enabled = False
            edit.Enabled = False
        End If
        rebuild_grid()

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        selected_lookup_num = " " '
        selected_screen_nam = " "
        selected_plan_desc = " "
        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        Response = MsgBox("Do you really want to delete this record?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = MsgBoxResult.Yes Then
            sqlstmnt = "Delete from cc_disab where disab_num = '" & selected_lookup_num & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)
        End If

        rebuild_grid()

        MsgBox("Record has been deleted from cc_disab file.")
    End Sub

End Class