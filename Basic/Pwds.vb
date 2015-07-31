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

Public Class frmpwds
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "pwd"
    Public frmWhereClause As String = " where pkg_type = '" & selected_lookup_num & "'"
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

        Dim sql As String = "select * from pwd"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_desc = DataGridView1.Item("password", e.RowIndex).Value.ToString
            selected_lookup_num = DataGridView1.Item("pkg_type", e.RowIndex).Value.ToString
        End If

    End Sub

    Private Sub cmdadd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdAdd.Click
        Dim pwd As New frmpwd
        entry_type = "ADD"
        pwd.ShowDialog()

    End Sub

    Private Sub cmdupdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdUpdate.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        Dim pwd As New frmpwd
        entry_type = "EDIT"
        pwd.ShowDialog()
        Call rebuild_grid()
        selectedcell = False

    End Sub

    Private Sub frmpwds_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        Select Case entry_type
            Case "ADD"
                CmdAdd.Visible = True
                ' If pass_level = 0 Then CmdAdd.Enabled = False
            Case "EDIT"
                CmdUpdate.Visible = True
                ' If pass_level = 0 Then CmdUpdate.Enabled = False
        End Select

        rebuild_grid()
        If package_Type = "DPT" Then
            CmdAdd.Visible = True
            CmdUpdate.Visible = True
        End If
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        selected_lookup_num = " " '

        Me.Close()
        Me.Dispose()
    End Sub

End Class

