Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports Valid_YN
Imports ETS

Public Class je_stand_select
    Inherits System.Windows.Forms.Form


    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "stand_list"
    Public frmWhereClause As String = "" '" where = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String

    Private Sub RebuildGrid()
        sqlstmnt = "select * from stand_list order by je_tbl"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sqlstmnt)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
    End Sub

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Prtlist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PrtList.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glhead.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selected_lookup_num = DataGridView1.Item("Je_tbl", e.RowIndex).Value.ToString
            selectedcell = True
        End If
    End Sub

    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click

        entry_type = "ADD"
        je_type = "STAND"

        selectedcell = False

        'create the record in this table here
        'get next record (je_tbl) num

        Dim NextJENum As Integer = GLMod.GetNextJENum(je_type)
        selected_lookup_num = CStr(NextJENum)
        Dim jetitle As String
retry:
        jetitle = InputBox("Enter the name of the J/E up to 20 Characters.")

        If jetitle.Length > 20 Then
            MsgBox("Title too long")
            GoTo retry
        End If

        glx_stand.ShowDialog()
        If entry_type <> "CANCEL" Then
            'add name if did not cancel from glx_Stand
            Using db As Database = New Database(top_data_path)
                Dim sql As String = "insert into stand_list (je_tbl,je_Desc) values (" & NextJENum & ", '" & jetitle & "' )"
                db.ExecuteQuery(sql)
            End Using
        End If
        entry_type = "ADD"
        RebuildGrid()
    End Sub

    Private Sub Delete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles delete.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        Response = MsgBox("Do you really want to delete this record?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = MsgBoxResult.Yes Then
            '	'delete from stand list
            Using db As Database = New Database(top_data_path)
                Dim sql As String = "delete from stand_list where je_tbl = '" & selected_lookup_num & "' "
                db.ExecuteQuery(sql)
            End Using
            '	'delete the whole from je_stand also
            Using db As Database = New Database(top_data_path)
                Dim sql As String = "delete from je_stand where jrnl_num = '" & selected_lookup_num & "' "
                db.ExecuteQuery(sql)
            End Using
            MsgBox("Record has been deleted from Standard JE file.")
        End If

        Call RebuildGrid()
        ' MsgBox("Record has been deleted from Standard JE file.") 'move to within if stmt
    End Sub

    Private Sub CmdEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdEdit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        entry_type = "EDIT"
        je_type = "STAND"
        glx_stand.ShowDialog()
        entry_type = ""
        RebuildGrid()

    End Sub

    Private Sub je_stand_select_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        RebuildGrid()
        function_type = "DATA_ENTRY" 'so you can select

    End Sub

End Class