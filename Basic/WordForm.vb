Option Strict Off
Option Explicit On
Imports Microsoft.Office
Imports System
Imports System.Configuration
Imports ETS.Common

Public Class WordForm
    Inherits System.Windows.Forms.Form


    Private Sub WordForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Word As Object
        Dim PrintOptions As Object
        Dim Background As Integer

        Word = CreateObject("Word.Basic")
        Word.FileOpen(MODULE1.selected_file)            '("C:\etsacct\documents\GL Jentry.doc")
        PrintOptions = Word.CurValues.ToolsOptionsPrint
        Background = PrintOptions.Background
        PrintOptions = Nothing
        If (Background <> 0) Then
            Word.ToolsOptionsPrint(Background:=0)
        End If
        Word.FilePrintDefault()
        If (Background <> 0) Then
            Word.ToolsOptionsPrint(Background:=Background)
        End If
        Word.FileClose(2)
        Word = Nothing

        Me.Close()
        Me.Dispose()
    End Sub
End Class