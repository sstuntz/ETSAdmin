Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETSCommon.Database
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Configuration
Imports System.Data.SqlClient

Friend Class clijoblookup
    Inherits System.Windows.Forms.Form
    '****************
    'revision History
    'original date of this form is 9/23/96 -SCS

    '****************

    Private Sub rebuild_grid()
        Dim sql As String = "select sort_name,name_key,job_num from cc_clijob"
        Dim rs As DataSet
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            rs = db.FillDataSet(sql)
        End Using
        JobGrid.DataSource = rs.Tables(0)
    End Sub

    Private Sub clijoblookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If
        Dim sql As String = "select sort_name,name_key,job_num from cc_clijob"
        Dim rs As DataSet
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            rs = db.FillDataSet(sql)
        End Using
        JobGrid.DataSource = rs.Tables(0)

    End Sub

    Private Sub BtnCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        selected_lookup_num = " " '
        selected_screen_nam = " "
        selected_plan_desc = " "

        Me.Close()

    End Sub

    Private Sub btnAccept_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
        Else
            Me.Close()
        End If

    End Sub

    Private Sub BtnAdd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
         entry_type = "ADD"
        selected_name_key = ""
        selected_job_num = ""
        frmclijob.ShowDialog()
        Call rebuild_grid()
    End Sub

    Private Sub btnEdit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        entry_type = "EDIT"
        frmclijob.ShowDialog()
        Call rebuild_grid()
    End Sub

    Private Sub JobGrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles JobGrid.CellContentClick
        selectedcell = True
        selected_job_num = JobGrid.Item("jobnum", e.RowIndex).Value.ToString
        selected_name_key = JobGrid.Item("namekey", e.RowIndex).Value.ToString
    End Sub
End Class