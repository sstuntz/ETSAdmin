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

Public Class jelookup
    Inherits System.Windows.Forms.Form

    Private Sub rebuild_grid()
        Dim sql As String = "select * from yrgenled where post = 'N' and jrnl_line = 1 and void = 'N' and dflag = 'N' order by jrnl_num "
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        selected_lookup_num = ""
        selected_lookup_desc = ""
    End Sub

    Private Sub DataGridView1_cellclick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("jrnl_num", e.RowIndex).Value.ToString
            selected_lookup_desc = DataGridView1.Item("jrnl_name", e.RowIndex).Value.ToString
        End If
    End Sub

    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        ' selected_lookup_num is returned from datagrid click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
        On Error Resume Next

        entry_type = "ADD"
        je_type = "REGULAR"
        glx_stand.ShowDialog()
        je_type = ""
        Call rebuild_grid()

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        selected_lookup_num = " "
        selected_lookup_desc = " "

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        entry_type = "EDIT"
        je_type = "REGULAR"
        glx_stand.ShowDialog()
        je_type = ""
        Call rebuild_grid()

    End Sub

    Public Sub jelookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        'this for for editing only 7/19/02 lhw
        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If
        Call rebuild_grid()

        addacct.Enabled = False
        Me.BringToFront()

    End Sub

End Class