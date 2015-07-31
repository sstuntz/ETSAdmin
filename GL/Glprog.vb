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

Friend Class frm_program
	Inherits System.Windows.Forms.Form

    Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click

    End Sub
	
    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		' prtDestination = 0
		' prtreportfilename = gl_report_path & "glprog.rpt"
		' Call frmcrystal_Call
	End Sub

	Private Sub frm_program_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
        Select Case entry_type

            Case "ADD"
                cmdAdd.Visible = True
                If pass_level = 0 Then cmdAdd.Enabled = False
            Case "EDIT"
                cmdUpdate.Visible = True
                If pass_level = 0 Then cmdUpdate.Enabled = False
        End Select
	End Sub
	
	Private Sub txtField0_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField0.Enter
        Dim Index As Short = txtField0.GetIndex(CType(eventSender, TextBox))
		ets_set_selected()
	End Sub
	
	
	Private Sub txtField0_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField0.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField0.GetIndex(CType(eventSender, TextBox))
		'this is a test for a number already used
		
		If KeyAscii = 13 Then
			On Error Resume Next
			
        End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	
	Private Sub txtField1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField1.Enter
        Dim Index As Short = txtField1.GetIndex(CType(eventSender, TextBox))
		ets_set_selected()
	End Sub
	
	
	Private Sub txtField1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField1.GetIndex(CType(eventSender, TextBox))
		If KeyAscii = 13 Then
			cmdUpdate.Enabled = True
			cmdUpdate.Focus()
			cmdAdd.Enabled = True
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class