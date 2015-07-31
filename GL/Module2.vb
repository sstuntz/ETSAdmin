
Option Explicit Off
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports JRI.Module1
Imports System.Data.SqlClient
Imports JRI.Valid_YN
Imports Microsoft.Office

Public Class WordDoc

    Dim Word As Object = CreateObject("Word.Basic")
    Dim PrintOptions As Object
    Dim Background As Integer


    'Word.FileOpen("C:\etsacct\documents\GL Jentry.doc")
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


End Class

