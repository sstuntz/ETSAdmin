Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports ps.common
Imports System.Data.SqlClient

Public Class frmtype
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "type_source"
    Public frmWhereClause As String = ""
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub rebuild_grid()

        Dim sql As String = "select * from type_source order by type_names"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("type_names", e.RowIndex).Value.ToString
        End If
    End Sub

    Private Sub Addacct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Addacct.Click
        Dim NewType As String
        NewType = InputBox("Enter a new type up to 20 characters.")
        If NewType.Length < 20 Then
            sqlstmnt = "Insert into type_source values('" & NewType & "')"
            ETSSQL.ExecuteSQL(sqlstmnt)
            Call rebuild_grid()
        Else
            MsgBox("Name too long")
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Close()
    End Sub

    Private Sub Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit.Click
        Dim NewType As String

        Response = MsgBox("Do you want to change this description?", CType(MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton2, MsgBoxStyle))

        If Response = (MsgBoxResult.Yes) Then
            NewType = InputBox("Enter a new type up to 20 characters.")
            If NewType.Length < 20 Then
                sqlstmnt = "update type_source set type_names = '" & NewType & "' where type_names = '" & selected_lookup_num & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
            Else
                MsgBox("Name too long")
            End If
        Else
            MsgBox("Do you want to delete this description?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
            If Response = (MsgBoxResult.Yes) Then
                sqlstmnt = "Delete from type_source where type_names = '" & selected_lookup_num & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If

        End If
        Call rebuild_grid()
    End Sub

    Private Sub frmtype_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        Call rebuild_grid()
    End Sub
End Class