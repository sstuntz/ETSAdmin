
Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports System.Collections.Generic
Imports ETSCommon.MODULE1

Public Class ETSSQL

    Public TagColumnName As String
  
    Public Shared Function GetData(ByVal TableName As String, ByVal frmWhereClause As String) As List(Of ETSData)
        Dim intcount As Integer = 0
        Dim RetETSData As New List(Of ETSData)

        sqlstmnt = "select column_name ,data_type from information_schema.columns where table_name = '" & TableName & "'"
        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)

            While rs.Read()
                Dim ds As New ETSData
                ds.ColumnNumber = intcount
                ds.ColumnName = rs("Column_Name").ToString
                ds.DataType = rs("Data_type").ToString
                intcount = intcount + 1
                RetETSData.Add(ds)
            End While
            intcount = intcount - 1
            rs.Close()
        End Using

        Using db As Database = New Database(top_data_path)
            If Len(frmWhereClause) <> 0 Then
                sqlstmnt = "select * from " & TableName & frmWhereClause
            Else
                sqlstmnt = "select * from " & TableName & ""
            End If
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                For MODULE1.num = 0 To intcount
                    RetETSData.Item(num).ActualData = rs(num).ToString
                Next
            End While
            rs.Close()
        End Using

        If intcount = 0 Then        'do not try to edit a blank table
            entry_type = "ADD"

        End If

        Return RetETSData

    End Function

    Public Shared Sub InsertData(ByVal TableName As String, ByVal OneRow As List(Of ETSData))
        sqlstmnt = ""

        sqlstmnt = "Insert into " & TableName & " ("

        For MODULE1.num = 0 To OneRow.Count - 1
            sqlstmnt = sqlstmnt & OneRow.Item(num).ColumnName & ","
        Next

        sqlstmnt = Left(sqlstmnt, (Len(sqlstmnt) - 1)) & ") values ("
        For MODULE1.num = 0 To OneRow.Count - 1
            sqlstmnt = sqlstmnt & Database.StringParam(OneRow.Item(num).ActualData) & ", "
        Next
        sqlstmnt = Left(sqlstmnt, (Len(sqlstmnt) - 2)) & ")"
        '     sqlstmnt = String.Format(sqlstmnt)
        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            db.ExecuteUpdate(sql)
        End Using
    End Sub

    Public Shared Sub UpdateData(ByVal TableName As String, ByVal frmWhereClause As String, ByVal OneRow As List(Of ETSData))
        sqlstmnt = ""

        sqlstmnt = "update " & TableName & " set "

        For MODULE1.num = 0 To OneRow.Count - 1
            sqlstmnt = sqlstmnt & OneRow.Item(num).ColumnName & " = " & Database.StringParam(OneRow.Item(num).ActualData) & ","
        Next

        sqlstmnt = Left(sqlstmnt, (Len(sqlstmnt) - 1)) & frmWhereClause

        Using db As Database = New Database(top_data_path)
            db.ExecuteUpdate(sqlstmnt)
        End Using

    End Sub

    Public Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

End Class


