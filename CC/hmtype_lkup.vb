Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETSCommon.Database
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Configuration
Imports System.Data.SqlClient

Friend Class hmtypelookup
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 9/23/96 -SCS
	'11/14/2008 lhw
	
    '****************

    Private Sub rebuild_grid()
        Dim sql As String = "select type_name, type_Desc from job_types"
        Dim rs As DataSet
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            rs = db.FillDataSet(sql)
        End Using
        TypeGrid.DataSource = rs.Tables(0)


    End Sub

    Private Sub typegrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TypeGrid.CellContentClick
        selectedcell = True
        selected_lookup_num = TypeGrid.Item("type_name", e.RowIndex).Value.ToString
        selected_plan_desc = TypeGrid.Item("type_desc", e.RowIndex).Value.ToString
    End Sub

    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        Me.Close()

    End Sub
	
	Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
		If selectedcell = True Then
			MsgBox("Something selected.  Can not ADD.")
			Exit Sub
		End If

        entry_type = "ADD"
		selected_lookup_num = ""
		selected_lookup_desc = ""
        hmtype.ShowDialog()
		Call rebuild_grid()
    End Sub
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		selected_lookup_num = ""
		selected_lookup_desc = ""
		Me.Close()
		
	End Sub
	
	Private Sub delete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles delete.Click
		If selectedcell = False Then
			MsgBox("Nothing selected")
			Exit Sub
        End If

        Response = MsgBox("Do you really want to delete this record?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = MsgBoxResult.Yes Then
            sqlstmnt = " delete  from job_types where type_name = '" & selected_lookup_num & "'"
            Dim rs As SqlDataReader
            Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
                rs = db.ExecuteQuery(sqlstmnt)
            End Using
            MsgBox("Record has been deleted.")
        End If
        Call rebuild_grid()
    End Sub
	
    Private Sub hmtypelookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
            addacct.Enabled = False
            edit.Enabled = False
            delete.Enabled = False
        End If

        If function_type = "LOOKUP_ONLY" Then
            addacct.Enabled = False
            edit.Enabled = False
            Accept.Enabled = True

        End If

        Call rebuild_grid()

    End Sub
	
    Private Sub edit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        entry_type = "EDIT"
        hmtype.ShowDialog()
        Call rebuild_grid()
    End Sub
End Class