Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETSCommon.Database
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Configuration
Imports System.Data.SqlClient

Friend Class jobnumlookup
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 9/23/96 -SCS
	
    '****************

    Private Sub rebuild_grid()
        Dim sql As String = "select job_num, Job_Desc, pay_class from ccjob"
        Dim rs As DataSet
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            rs = db.FillDataSet(sql)
        End Using
        JobNumgrid.DataSource = rs.Tables(0)
    End Sub

    Private Sub JobnumGrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles JobNumgrid.CellContentClick
        selectedcell = True
        selected_job_num = JobNumgrid.Item("jobnum", e.RowIndex).Value.ToString
        selected_lookup_num = JobNumgrid.Item("jobnum", e.RowIndex).Value.ToString
        selected_lookup_desc = JobNumgrid.Item("jobdesc", e.RowIndex).Value.ToString
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
        frmclijob.ShowDialog()
        selected_lookup_num = ""
        entry_type = "ADD"
        frmjob.ShowDialog()
        Call rebuild_grid()
    End Sub
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		selected_lookup_num = " " '
		selected_screen_nam = " "
		selected_plan_desc = " "
		
		Me.Close()
		
	End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        entry_type = "EDIT"
        frmjob.ShowDialog()
        Call rebuild_grid()
  End Sub
	
	Private Sub jobnumlookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		ctrform(Me)
		If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
            addacct.Enabled = False
            edit.Enabled = False
        End If
        Dim sql As String = "select job_num, Job_Desc, pay_class from ccjob"
        Dim rs As DataSet
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            rs = db.FillDataSet(sql)
        End Using
        JobNumgrid.DataSource = rs.Tables(0)

	End Sub
	
    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Call ets_set_selected()
    End Sub
	
	Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			txtFields.Text = UCase(txtFields.Text)
			addacct.Enabled = False
			
			On Error Resume Next
			sqlstmnt = "Select * from ccjob where job_num = " & Chr(34) & txtFields.Text & Chr(34)
			sqlstmnt = sqlstmnt & " ORDER BY job_num"
			'  Data1.RecordSource = sqlstmnt
			
			' If Data1.Recordset.RecordCount = 0 Then
			'MsgBox "Please re-enter a valid job number."
			' Call ets_set_selected
			' Exit Sub
			' End If
			On Error GoTo 0
			
			
			
			'  num = 0
			' On Error Resume Next
			' Data1.Recordset.MoveFirst
			' If Err = 3021 Then
			' MsgBox "Please re-enter a valid job num."
			' Call ets_set_selected
			' Exit Sub
			' End If
			' On Error GoTo 0
			
			
			
			
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Leave
     End Sub
End Class