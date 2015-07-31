Option Strict Off
Option Explicit On
Imports Microsoft.Office.Core
Imports System
Imports System.Configuration
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop

Public Class ExcelForm
    Inherits System.Windows.Forms.Form

    Dim xlsApp As Excel.Application
    Dim xlsWorkBook As Excel.Workbook
    Dim xlsWorkSheet As Excel.Worksheet
    Dim xlsCell As Excel.Range

    Private Sub ExcelForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim Excel As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Excel = CreateObject("Excel.Basic")
        'Excel.FileOpen(MODULE1.selected_file)
        'PrintOptions = Excel.CurValues.ToolsOptionsPrint
        'Background = PrintOptions.Background
        'PrintOptions = Nothing
        'If (Background <> 0) Then
        '    Excel.ToolsOptionsPrint(Background:=0)
        'End If
        'Excel.FilePrintDefault()
        'If (Background <> 0) Then
        '    Excel.ToolsOptionsPrint(Background:=Background)
        'End If
        'Excel.FileClose(2)
        'Excel = Nothing

        'Me.Close()
        'Me.Dispose()
    End Sub

    Private Sub ShowExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowExcel.Click

        'Dim xlsApp As Excel.Application
        'Dim xlsWorkBook As Excel.Workbook
        'Dim xlsWorkSheet As Excel.Worksheet
        'Dim xlsCell As Excel.Range

        ' Initialise Excel Object
        xlsApp = New Excel.Application


        'create a workbook
        '  xlsWorkBook = xlsApp.Workbooks.Add
        ' Open test Excel spreadsheet
        xlsWorkBook = xlsApp.Workbooks.Open("c:\test.xls")

        ' Open worksheet (can open by number or name)
        xlsWorkSheet = xlsWorkBook.Worksheets(1) ' You could also do it by name: "sheet1"

        xlsApp.Visible = True
        xlsApp.WindowState = XlWindowState.xlMaximized



        ' Read the first cell
        '     xlsCell = xlsWorkSheet.Range("A1")
        ' Display the first cell
        '    MsgBox(xlsCell.Text)


        'create and fill a recordset here, called oRecordset
        '   xlsWorkSheet.Range("B15").CopyFromRecordset("oRecordset")  ' it fills and names but slow for big files

        MsgBox("hold")


        'save the data
        xlsWorkSheet = Nothing
        xlsWorkBook.Close(SaveChanges:=True)
        'or
        '  xlsWorkBook.SaveAs("filename")
        ' xlsWorkBook.Close(SaveChanges:=False)


    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        xlsApp = Nothing
    End Sub
End Class