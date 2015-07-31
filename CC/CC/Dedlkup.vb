Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETSCommon.Database
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Configuration
Imports System.Data.SqlClient

Friend Class deductslookup
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 9/23/96 -SCS
	
	'****************

    Private Sub rebuild_grid()
        Dim sql As String = "select ded_num, screen_nam, plan_Desc from cc_deduct"
        Dim rs As DataSet
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            rs = db.FillDataSet(sql)
        End Using
        DeductGrid.DataSource = rs.Tables(0)

    End Sub

    Private Sub DeductGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DeductGrid.CellContentClick
        selectedcell = True
        selected_lookup_num = DeductGrid.Item("ded_num", e.RowIndex).Value.ToString
        selected_ded_num = DeductGrid.Item("ded_num", e.RowIndex).Value.ToString
        ' selected_screen_nam = DeductGrid.Item("screen_nam", e.RowIndex).Value.ToString
        ' selected_plan_desc = DeductGrid.Item("plan_desc", e.RowIndex).Value.ToString
    End Sub
    


    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        entry_type = ""
        Me.Close()
    End Sub

    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
        entry_type = "ADD"
        frmdeducts.ShowDialog()
        Call rebuild_grid()
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        selected_ded_num = " " '
        selected_screen_nam = " "
        selected_plan_desc = " "

        Me.Close()

    End Sub

    Private Sub deductslookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If
        Dim sql As String = "select ded_num, screen_nam, plan_Desc from cc_deduct"
        Dim rs As DataSet
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            rs = db.FillDataSet(sql)
        End Using
        DeductGrid.DataSource = rs.Tables(0)

    End Sub

    Private Sub edit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        entry_type = "EDIT"
        frmdeducts.ShowDialog()
        Call rebuild_grid()
    End Sub


End Class