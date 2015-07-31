Option Strict On
Option Explicit On
Option Compare Text

Imports System.Data.SqlClient
Imports System.Configuration
Imports ETS.Common.Module1
Imports ps.common
Imports System.Text

Public Class CrystalMod

    Public Sub ShowForm()
        Dim Crystal As New CrystalForm
        CrystalForm.ShowDialog()
        CrystalForm.BringToFront()
    End Sub



    'Public crxApplication As New CRAXDRT.Application
    'Public Report As CRAXDRT.Report
    'Public crys_num As Integer
    'Public crys_num1 As Integer
    'Public crys_num2 As Integer
    'Public crys_num3 As Integer
    'Public CrxDatabaseTable As CRAXDRT.DatabaseTable
    'Public CrxSubreport As CRAXDRT.Report
    'Public CrxParameterField As CRAXDRT.ParameterFieldDefinition 'xxxscs


    'Public prtDestination As String
    'Public prtDiscardSavedData As Short
    'Public prtparameterfields(20) As String
    'Public prtreportfilename As String
    'Public prtWindowState As Short
    'Public prtPrintFileName As String
    'Public prtPrintFileType As Short
    'Public prtPrinterName As String
    'Public prtCopiesToPrinter As Short

    'Public crys_msg As String
    'Public pos1 As Short
    'Public pos2 As Short

    ''set valid flag so can unload easily

    'Public Sub frmcrystal_Call()
    '	Dim CrxParamaterField As Object

    '	valid_YN = "Y"

    '	'here we check for the file name so err handling is simplified
    '	On Error Resume Next

    '	fnum = FreeFile
    '	FileOpen(fnum, prtreportfilename, OpenMode.Input)
    '	Select Case Err.Number
    '		Case 0
    '		Case 53
    '			MsgBox(ErrorToString(Err.Number) & "  Named = " & prtreportfilename)
    '			valid_YN = "N"
    '		Case Else
    '			MsgBox("error = " & Err.Number)
    '			valid_YN = "N"
    '	End Select

    '	FileClose(fnum)

    '	If valid_YN = "N" Then
    '		FileClose(fnum)
    '		Exit Sub
    '	End If

    '	On Error Resume Next
    '	Report = crxApplication.OpenReport(prtreportfilename, 1)

    '	Select Case Err.Number
    '		Case 0

    '		Case Else
    '			MsgBox("error = " & Err.Number)
    '			valid_YN = "N"

    '	End Select

    '	If valid_YN = "N" Then
    '		FileClose(fnum)
    '		Exit Sub
    '	End If

    '	Report.DiscardSavedData()

    '	For	Each CrxDatabaseTable In Report.database.Tables

    '		For crys_num = Len(CrxDatabaseTable.Location) To 0 Step -1
    '			If Mid(CrxDatabaseTable.Location, crys_num, 1) = "\" Then
    '				crys_num2 = Len(CrxDatabaseTable.Location) - crys_num
    '				crys_msg = Right(CrxDatabaseTable.Location, crys_num2)
    '				Exit For
    '			End If
    '		Next 

    '		Select Case crys_msg

    '			Case "glname.mdb", "etssys.mdb", "glchr.mdb", "gljrnl.mdb"
    '				CrxDatabaseTable.Location = gl_data_path & crys_msg

    '			Case "aratt.mdb"
    '				CrxDatabaseTable.Location = att_data_path & crys_msg

    '			Case "ee.mdb"
    '				CrxDatabaseTable.Location = ee_data_path & crys_msg

    '			Case "cc.mdb"
    '				CrxDatabaseTable.Location = cc_data_path & crys_msg

    '			Case "med_fee.mdb", "med_top.mdb", "med_prov.mdb"
    '				CrxDatabaseTable.Location = am1_Data_path & crys_msg

    '			Case "med.mdb"
    '				CrxDatabaseTable.Location = am_data_path & crys_msg

    '			Case "cctr.mdb"
    '				CrxDatabaseTable.Location = ct_data_path & crys_msg

    '			Case "eehr.mdb"
    '				CrxDatabaseTable.Location = eehr_data_path & crys_msg

    '			Case "ap.mdb"
    '				CrxDatabaseTable.Location = ap_data_path & crys_msg

    '			Case "ar.mdb"
    '				CrxDatabaseTable.Location = ar_data_path & crys_msg

    '			Case Else
    '				CrxDatabaseTable.Location = gl_data_path & crys_msg

    '		End Select

    '	Next CrxDatabaseTable
    '	'xxxscs 4/6/02 lhw  next 22 lines
    '	'the following loop moves the parameters to right place
    '	'the new counters start at 1 and the old at 0

    '	For num = 0 To 20
    '		If Len(Trim(prtparameterfields(num))) = 0 Then Exit For
    '		CrxParamaterField = Report.ParameterFields.Item(num + 1)
    '		'find two semicolons and data between them is the parameter being passed
    '		pos1 = InStr(prtparameterfields(num), ";")
    '		pos2 = InStr(pos1 + 1, prtparameterfields(num), ";")
    '		msg = Mid(prtparameterfields(num), pos1 + 1, pos2 - 1 - pos1)

    '		Select Case Report.ParameterFields.Item(num + 1).ValueType
    '			Case 5 '32 bit signed
    '				CrxParameterField.AddDefaultValue(Val(msg))
    '			Case 6 '32 bit unsigne
    '				CrxParameterField.AddDefaultValue(Val(msg))
    '			Case 7 'number
    '				CrxParameterField.AddDefaultValue(Val(msg))
    '			Case 8 'currency
    '				CrxParameterField.AddDefaultValue(Val(msg))
    '			Case 9 'boolean
    '				CrxParameterField.AddDefaultValue(msg)
    '			Case 10 'date
    '				pos1 = InStr(prtparameterfields(num), "(")
    '				pos2 = InStr(pos1 + 1, prtparameterfields(num), ")")
    '				msg = Mid(prtparameterfields(num), pos1 + 1, pos2 - 1 - pos1)
    '				CrxParameterField.AddDefaultValue(CDate(msg))
    '			Case 11 'time
    '				CrxParameterField.AddDefaultValue(msg)
    '			Case 12 'string
    '				CrxParameterField.AddDefaultValue(msg)

    '		End Select



    '	Next 


    '	Select Case prtDestination

    '		Case CStr(0) 'to the screen

    '			frmcrystal.ShowDialog()

    '		Case CStr(1) 'to the printer
    '			'ask the printer dialog box
    '			' Report.PrinterSetup Me.hwnd

    '			'xxxscs the following code makes no printer dialog box if you want to include it
    '			'Select the printer for the report passing the Printer Driver, Printer Name and Printer Port.

    '			'Report.SelectPrinter "HPPCL5MS.DRV", "HP LaserJet 4m Plus",    "\\Vanprt\v1-1mpls-ts"
    '			'Print the Report without prompting the user.
    '			'Report.PrintOut False
    '			'xxxscs

    '			Report.PrintOut()
    '			' Unload Me
    '			Exit Sub


    '	End Select

    'End Sub
End Class