Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETSCommon.Database
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Configuration
Imports System.Data.SqlClient

Friend Class ccpr_ed
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 6/23/96 -SCS
	
	'****************
    Private Sub rebuild_grid()
        Dim sql As String = "select pay_num, name_key, sort_name, entry_num  from cctime where  line_num = 1 and paid <> 'Y' order by sort_name "
        Dim rs As DataSet
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            rs = db.FillDataSet(sql)
        End Using
        EdtimeGrid.DataSource = rs.Tables(0)

    End Sub

    Private Sub EdtimeGrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles EdtimeGrid.CellContentClick
        selectedcell = True
        selected_name_key = EdtimeGrid.Item("name_key", e.RowIndex).Value.ToString
        selected_entry_num = CInt(EdtimeGrid.Item("entry_num", e.RowIndex).Value.ToString)
        selected_pay_num = CInt(EdtimeGrid.Item("pay_num", e.RowIndex).Value.ToString)
       
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
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        selected_name_key = ""
        selected_entry_num = CInt("")
        selected_pay_num = CInt("")
        Me.Close()
    End Sub
End Class