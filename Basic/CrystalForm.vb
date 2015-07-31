Option Strict Off
Option Explicit On
Imports Microsoft
Imports System
Imports System.Configuration
'Imports CRVIEWERLib
Imports ETS.Common.Module1
Imports ps.common
'Imports CRAXDDRT

Public Class CrystalForm
    Inherits System.Windows.Forms.Form

    Private Sub CrystalForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Crystal As New CrystalForm
        Me.BringToFront()
        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        'Word.FileOpen(MODULE1.selected_file)            '("C:\etsacct\documents\GL Jentry.doc")
        'PrintOptions = Word.CurValues.ToolsOptionsPrint
        'Background = PrintOptions.Background
        'PrintOptions = Nothing
        'If (Background <> 0) Then
        '    Word.ToolsOptionsPrint(Background:=0)
        'End If
        'Word.FilePrintDefault()
        'If (Background <> 0) Then
        '    Word.ToolsOptionsPrint(Background:=Background)
        'End If
        'Word.FileClose(2)
        'Word = Nothing

        'Me.Close()

        'Dim cr As New CRViewer

        'cr.ReportSource() = "c:\customers\berk\b_tet_reports\" & prtreportfilename
        'cr.Refresh()

        ' Dim rptDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        'Dim RptName As String = "c:\customers\berk\b_test reports\" & prtreportfilename
        'Dim Cryst As Object
        'Dim cryrpt As Object
        '' Cryst = CreateObject("crystal.crpe.application")
        'Cryst = CreateObject("CrystalRuntime.Application.9")
        'cryrpt = Cryst.OpenReport(RptName)
        'cryrpt.ToString()


        Dim rptname As String = "c:\customers\berk\b_test reports\" & prtreportfilename
        Clipboard.SetDataObject(rptname)

        Label2.Text = "Report = " & prtreportfilename









    End Sub

   
End Class