Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmcrystal
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 9/23/00 -SCS
	
	'****************
	Public crys_msg As String 'added 3/8/02  to make sure msg not overwritten scs lhw
	
	
	'this form controls the printing and viewing of crytal reports
	'based on the destination - screen or printer is what happens when it loads
	
	Public Sub cancel_me()
		Me.Close()
	End Sub
	Public Sub crystal_replace(ByRef rpt_name As Object)
		
	End Sub
	
	Private Sub frmcrystal_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'set valid flag so can unload easily
		
		valid_YN = "Y"
		
		'here we check for the file name so err handling is simplified
		On Error Resume Next
		
		fnum = FreeFile
		FileOpen(fnum, prtreportfilename, OpenMode.Input)
		Select Case Err.Number
			Case 0
			Case 53
				MsgBox(ErrorToString(Err.Number) & "  Named = " & prtreportfilename)
				valid_YN = "N"
			Case Else
				MsgBox("error = " & Err.Number)
				valid_YN = "N"
		End Select
		
		FileClose(fnum)
		
		If valid_YN = "N" Then
			FileClose(fnum)
			Exit Sub
		End If
		
		On Error Resume Next
		Report = crxApplication.OpenReport(prtreportfilename, 1)
		
		Select Case Err.Number
			Case 0
				
			Case Else
				MsgBox("error = " & Err.Number)
				valid_YN = "N"
				
		End Select
		
		If valid_YN = "N" Then
			FileClose(fnum)
			Exit Sub
		End If
		
		Report.DiscardSavedData()
		
		For	Each CrxDatabaseTable In Report.database.Tables
			
			For crys_num = Len(CrxDatabaseTable.Location) To 0 Step -1
				If Mid(CrxDatabaseTable.Location, crys_num, 1) = "\" Then
					crys_num2 = Len(CrxDatabaseTable.Location) - crys_num
					crys_msg = VB.Right(CrxDatabaseTable.Location, crys_num2)
					Exit For
				End If
			Next 
			
			Select Case crys_msg
				
				Case "glname.mdb", "etssys.mdb", "glchr.mdb", "gljrnl.mdb"
					CrxDatabaseTable.Location = gl_data_path & crys_msg
					
				Case "aratt.mdb"
					CrxDatabaseTable.Location = att_data_path & crys_msg
					
				Case "ee.mdb"
					CrxDatabaseTable.Location = ee_data_path & crys_msg
					
				Case "cc.mdb"
					CrxDatabaseTable.Location = cc_data_path & crys_msg
					
				Case "med_fee.mdb", "med_top.mdb", "med_prov.mdb"
					CrxDatabaseTable.Location = am1_Data_path & crys_msg
					
				Case "med.mdb"
					CrxDatabaseTable.Location = am_data_path & crys_msg
					
				Case "cctr.mdb"
					CrxDatabaseTable.Location = ct_data_path & crys_msg
					
				Case "eehr.mdb"
					CrxDatabaseTable.Location = eehr_data_path & crys_msg
					
				Case "ap.mdb"
					CrxDatabaseTable.Location = ap_data_path & crys_msg
					
				Case "ar.mdb"
					CrxDatabaseTable.Location = ar_data_path & crys_msg
					
				Case Else
					CrxDatabaseTable.Location = gl_data_path & crys_msg
					
			End Select
			
		Next CrxDatabaseTable
		'xxxscs 4/6/02 per scs
		'the following loop moves the parameters to right place
		'the new counters start at 1 and the old at 0
		
		For num = 0 To 20
			If Len(Trim(prtparameterfields(num))) = 0 Then Exit For
			CrxParameterField = Report.ParameterFields.Item(num + 1)
			pos1 = InStr(prtparameterfields(num), ";")
			pos2 = InStr(pos1 + 1, prtparameterfields(num), ";")
			msg = Mid(prtparameterfields(num), pos1 + 1, pos2 - 1 - pos1)
			
			Report.ParameterFields.Item(num + 1).DisallowEditing = False
			
			
			
			Select Case Report.ParameterFields.Item(num + 1).ValueType
				
				Case 5 '32 bit signed
					CrxParameterField.AddDefaultValue(Val(msg))
				Case 6 '32 bit unsigne
					CrxParameterField.AddDefaultValue(Val(msg))
				Case 7 'number
					'CrxParameterField.adddefaultvalue Val(msg)
					CrxParameterField.AddDefaultValue(Val(msg))
				Case 8 'currency
					CrxParameterField.AddDefaultValue(Val(msg))
				Case 9 'boolean
					CrxParameterField.AddDefaultValue(msg)
				Case 10 'date
					pos1 = InStr(prtparameterfields(num), "(")
					pos2 = InStr(pos1 + 1, prtparameterfields(num), ")")
					msg = Mid(prtparameterfields(num), pos1 + 1, pos2 - 1 - pos1)
					CrxParameterField.AddDefaultValue(CDate(msg))
				Case 11 'time
					CrxParameterField.AddDefaultValue(msg)
				Case 12 'string
					CrxParameterField.AddDefaultValue(msg)
					
			End Select
			
			
			
			
		Next 
		
		'CRViewer1.ReportSource = Report
		'CRViewer1.ViewReport
		
		
	End Sub
	
	'UPGRADE_WARNING: Event frmcrystal.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmcrystal_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'      CRViewer1.Top = 0
		'     CRViewer1.Left = 0
		'     CRViewer1.Height = ScaleHeight
		'     CRViewer1.Width = ScaleWidth
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
	End Sub
	
	Private Sub frmcrystal_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		
		'UPGRADE_NOTE: Object Report may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Report = Nothing
		
	End Sub
End Class