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

Friend Class frmcustrpt
	Inherits System.Windows.Forms.Form
	
	
	
	
	
	'****************
	'revision History
	'original date of this form is 02/17/1999 - SCS
	
	'****************
	'Option Explicit
	Private Sub cmdRefresh_Click()
		'this is really only needed for multi user apps
		'  Data1.Refresh
	End Sub
	
	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
		
		'the following code checks for completeness
        'the string field has a list of the field numbers to check

        For ETSCommon.MODULE1.num = 0 To 100
            msg = "," & CStr(num) & ","
            Response = InStr(",0,1,2,3,4,", msg)
            If Response <> 0 Then
                If Len(txtFields(CShort(num)).Text) = 0 Then
                    MsgBox("You must fill in all required fields.")
                    txtFields(CShort(num)).Focus()
                    Exit Sub
                End If
            End If
        Next

        '  Data1.UpdateRecord
        '  Data1.Recordset.Bookmark = Data1.Recordset.LastModified
        '  Unload Me
    End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	
	
	Private Sub frmcustrpt_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'db=etssys  source = custrpt
		'    For num = 0 To Me.Controls.Count - 1
		'   If TypeOf Me.Controls(num) Is Data Then
		'      sqlstmnt = Right(Me.Controls(num).DatabaseName, Len(Me.Controls(num).DatabaseName) - 20)
		'      Me.Controls(num).DatabaseName = gl_data_path & sqlstmnt
		'      If Len(Me.Controls(num).RecordSource) > 0 Then
		'         Me.Controls(num).Refresh
		'      End If
		'   End If
		'   Next
		'
		'     Select Case package_Type
		'
		'    Case "AP"
		'     Data1.DatabaseName = ap_data_path & "ap.mdb"
		'
		'    Case "AR"
		'    Data1.DatabaseName = ar_data_path & "ar.mdb"
		'
		'    Case "EE"
		'    Data1.DatabaseName = ee_data_path & "ee.mdb"
		'
		'     Case "EEHR"
		'    Data1.DatabaseName = eehr_data_path & "eehr.mdb"
		'
		'    Case "CC"
		'    Data1.DatabaseName = cc_data_path & "cc.mdb"
		'
		'     Case "CCHR"
		'    Data1.DatabaseName = cchr_data_path & "cctr.mdb"
		'
		'    Case "GL"
		'
		'    Case "ATT"
		'    Data1.DatabaseName = att_data_path & "aratt.mdb"
		'    End Select
		'
		'    Data1.RecordSource = "SELECT * From custrpt ORDER BY rpt_desc"
		'    Data1.Refresh
		'
		'     Select Case entry_type
		'
		'    Case "ADD"
		'    Data1.RecordSource = "select * from custrpt order by rpt_num"
		'    Data1.Refresh
		'    On Error Resume Next
		'    Data1.Recordset.MoveLast
		'    If Err = 3021 Then
		'    num = 0
		'    Else
		'    num = Data1.Recordset.Fields("rpt_num")
		'    End If
		'    On Error GoTo 0
		'    'Data1.RecordSource = "select * from custrpt where rpt_num = ''"
		'    'Data1.Refresh
		'    Data1.Recordset.AddNew
		'    txtFields(0) = num + 1
		'
		'    Case "EDIT"
		'    Data1.RecordSource = "select * from custrpt where rpt_num = " & selected_lookup_num
		'    Data1.Refresh
		'    Data1.Recordset.edit
		'    txtFields(0) = Data1.Recordset(0)
		'    txtFields(1) = Data1.Recordset(1)
		'    txtFields(0).Enabled = False
		'    End Select
		'
		'
		
	End Sub
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
		Call ets_set_selected()
		
		'added 7/5/2003 lhw was not giving correct report#
		
		Select Case entry_type
			
			Case "ADD"
				txtFields(0).Text = CStr(num + 1)
				
			Case "EDIT"
				' txtFields(0) = Data1.Recordset(0)
				'txtFields(1) = Data1.Recordset(1) 'removed 5/8/04 lhw
				txtFields(0).Enabled = False
		End Select
		'added to get the defaults to come in
        'Dim tmp_txtField_value As Object 'added 7/3/03 TMK
		
        'If Index = 1 Then 'changed num to num1

        '	'Fill the text fields with the default values of the fields - TMK 7/3/03
        '	'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '	For num1 = 0 To Me.Controls.Count() - 1
        '		'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        '		If TypeOf CType(Me.Controls(num1), Object) Is System.Windows.Forms.TextBox Then
        '			If CType(Me.Controls(num1), Object).Text = "" Then
        '				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls(num1).DataSource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls(num1).DataField. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				If CType(Me.Controls(num1), Object).DataField <> "" And CType(Me.Controls(num1), Object).DataSource <> "" Then
        '					' tmp_txtField_value = Data1.Recordset.Fields(Me.Controls(num1).DataField).DefaultValue
        '					'trim the quotation marks of text default values
        '					'UPGRADE_WARNING: Couldn't resolve default property of object tmp_txtField_value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					If VB.Left(tmp_txtField_value, 1) = Chr(34) Then
        '						'UPGRADE_WARNING: Couldn't resolve default property of object tmp_txtField_value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '						CType(Me.Controls(num1), Object).Text = VB.Right(VB.Left(tmp_txtField_value, Len(tmp_txtField_value) - 1), Len(tmp_txtField_value) - 2)
        '					End If
        '				End If
        '			End If
        '		End If
        '	Next 
        'End If
		
		
		
	End Sub
	
	Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			Select Case Index
				
				
				
				Case 3 'screen or printer
					txtFields(Index).Text = UCase(txtFields(Index).Text)
					If txtFields(Index).Text <> "S" Then
						If txtFields(Index).Text <> "P" Then
							MsgBox("You must enter an S for screen or a P for printer.")
							Call ets_set_selected()
							GoTo EventExitSub
						End If
					End If
					
					
				Case 4 'yes or no
					txtFields(Index).Text = UCase(txtFields(Index).Text)
					If txtFields(Index).Text <> "Y" Then
						If txtFields(Index).Text <> "N" Then
							MsgBox("You must enter a Y to prompt for a Begin Date and End Date or a N for no prompting.")
							Call ets_set_selected()
							GoTo EventExitSub
						End If
					End If
					
			End Select
			
			System.Windows.Forms.SendKeys.Send("{tab}")
			KeyAscii = 0
		End If
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Leave
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
		txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
End Class