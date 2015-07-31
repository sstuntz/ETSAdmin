Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETSCommon.Database
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Data.SqlClient

Friend Class glhead_lookup
    Inherits System.Windows.Forms.Form
    Public edit_flag As String
    'insert point

    Private Sub rebuild_grid()
        Dim sql As String = "select gl_ref_no, acct_type, heading_1, min_1, max_1, heading_2, min_2, max_2, heading_3, min_3, max_3 from headings"
        Dim rs As DataSet
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        selected_lookup_num = ""
        selected_ded_num = ""

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick, DataGridView1.CellClick
        selectedcell = True
        selected_lookup_num = DataGridView1.Item("gl_ref_no", e.RowIndex).Value.ToString
        selected_ded_num = DataGridView1.Item("gl_ref_no", e.RowIndex).Value.ToString

    End Sub

    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        entry_type = ""
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
        entry_type = "ADD"
        frmglhead.ShowDialog()
        Call rebuild_grid()
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cancel.Click
        selected_lookup_num = " " '
        'selected_screen_nam = " "
        'selected_plan_desc = " "
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub glhead_lookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If
        Dim sql As String = "select gl_ref_no, acct_type, heading_1, min_1, max_1, heading_2, min_2, max_2, heading_3, min_3, max_3 from headings"
        Dim rs As DataSet
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)

    End Sub

    Private Sub edit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        entry_type = "EDIT"
        frmglhead.ShowDialog()
        Call rebuild_grid()
    End Sub

End Class