Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETSCommon.Database
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Configuration
Imports System.Data.SqlClient

Friend Class pclasslookup
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 9/23/96 -SCS
	
	'****************

    Private Sub rebuild_grid()
        Dim sql As String = "select  pay_class, pay_Desc from cc_paycl"
        Dim rs As DataSet
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            rs = db.FillDataSet(sql)
        End Using
        PayClGrid.DataSource = rs.Tables(0)

    End Sub

    Private Sub PayClGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PayClGrid.CellContentClick
        selectedcell = True
         'selected_dpt_num_desc = rs.Fields("name")

        selected_lookup_num = PayClGrid.Item("payclass", e.RowIndex).Value.ToString
        selected_lookup_desc = PayClGrid.Item("paydesc", e.RowIndex).Value.ToString
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
        On Error Resume Next
        entry_type = "ADD"
        frmpclass.ShowDialog()

    End Sub
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		selected_lookup_num = " " '
		selected_screen_nam = " "
		selected_plan_desc = " "
		
		Me.Close()
		
	End Sub
	
	Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Edit.Click
		If selectedcell = False Then
			MsgBox("Nothing selected")
			Exit Sub
		End If

        entry_type = "EDIT"
        frmpclass.ShowDialog()
        'clear the grid

    End Sub
	
	Private Sub pclasslookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        '	On Error Resume Next
        ctrform(Me)
		If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If
        Dim sql As String = "select pay_class, pay_desc from cc_paycl"
        Dim rs As DataSet
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            rs = db.FillDataSet(sql)
        End Using
        PayClGrid.DataSource = rs.Tables(0)
    End Sub
End Class