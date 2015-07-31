Option Strict On
Option Explicit On
Option Compare Text

Imports System.Data.SqlClient
Imports System.Configuration
Imports ETS.Common.Module1
Imports ps.common

Namespace ETS

    Public Class GLMod

        Public Shared Function GetNextNameKey() As String
            Return ""
            'Using db As Database = New Database(top_data_path)
            '    Dim rs As SqlDataReader = db.ExecuteQuery("select top 1 * from nam_addr order by name_key desc")
            '    While rs.Read()
            '        Return (CInt(rs("name_key").ToString) + 1).ToString
            '    End While
            '    rs.Close()
            'End Using
        End Function

        Public Shared Function GetNextJENum(ByVal JEType As String) As Integer
            Select Case JEType
                Case "STAND"
                    Using db As Database = New Database(top_data_path)
                        Dim sql As String = "select top 1 * from je_stand order by jrnl_num desc"
                        Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                        While rs.Read()
                            Return CInt(rs("jrnl_num").ToString) + 1
                        End While
                        rs.Close()
                    End Using
                Case Else
                    Using db As Database = New Database(top_data_path)
                        Dim sql As String = "select top 1 * from yrgenled order by jrnl_num desc"
                        Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                        While rs.Read()
                            Return CInt(rs("jrnl_num").ToString) + 1
                        End While
                        rs.Close()
                    End Using
            End Select
        End Function

        Public Shared Function GetTotalFactor() As Decimal
            Dim totalloc As Decimal = 0
            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select * from Alloc"
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                While rs.Read()
                    totalloc = totalloc + CDec(rs("factor").ToString)
                End While
                Return totalloc
                rs.Close()
            End Using
        End Function

        Public Shared Function GetTotalAllocation() As Decimal
            Dim totalloc As Decimal = 0
            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select * from Alloc"
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                While rs.Read()
                    totalloc = totalloc + CDec(rs("amount").ToString)
                End While
                Return totalloc
                rs.Close()
            End Using
        End Function

        Public Shared Function CheckJeData(ByVal sqlstmnt As String) As String
            Dim BadData As String = "N*"
            Dim totalamt As Decimal = 0
            Dim BadLine As String = " * * "
            Using db As Database = New Database(top_data_path)
                Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
                While rs.Read()
                    totalamt = totalamt + CDec(rs("amount").ToString)
                    If (etsacctnum_chk(rs("acct_num").ToString)) = "N" Then
                        BadData = "Y*"
                        BadLine = rs("acct_num").ToString & "*" & rs("jrnl_num").ToString & "*" & rs("jrnl_line").ToString
                        Exit While
                    End If

                End While
                rs.Close()
            End Using

            If totalamt <> 0 Then BadData = "T*"
            BadData = BadData & "*" & BadLine
            Return BadData

        End Function

        Public Shared Function SQLJEDataString(ByVal sqlstmnt As String, ByVal JeRowData As List(Of JeData)) As String
            'creates the list of values to be inserted into the sql table
            'the sql statement sent over tells it what table to do the insert into
            Dim JEDataString As String = sqlstmnt
            For Each jerow In JeRowData
                ' JEDataString = JEDataString & JeRowData.Item(0).JrnlNum & "' , '" & JeRowData.Item(0).JrnlLineNum & "' , '" & JeRowData.Item(0).EntryType & "' , '" & JeRowData.Item(0).JrnlName & "' , '" & JeRowData.Item(0).JrnlSrc & "' , '" & JeRowData.Item(0).EntryDate & "' , '" & JeRowData.Item(0).EncumDate & "' , '" & JeRowData.Item(0).PostDate & "' , '" & JeRowData.Item(0).AcctNum & "' , '" & JeRowData.Item(0).Amount & "' , '" & JeRowData.Item(0).JrnlDesc & "' , '" & JeRowData.Item(0).OperId & "' , '" & JeRowData.Item(0).APost & "' , '" & JeRowData.Item(0).Post & "' , '" & JeRowData.Item(0).dflag & "' , '" & JeRowData.Item(0).Agency & "' , '" & JeRowData.Item(0).Void & "')"
                JEDataString = JEDataString & jerow.JrnlNum & "' , '" & jerow.JrnlLineNum & "' , '" & jerow.EntryType & "' , '" & jerow.JrnlName & "' , '" & jerow.JrnlSrc & "' , '" & jerow.EntryDate & "' , '" & jerow.EncumDate & "' , '" & jerow.PostDate & "' , '" & jerow.AcctNum & "' , '" & jerow.Amount & "' , '" & jerow.JrnlDesc & "' , '" & jerow.OperId & "' , '" & jerow.APost & "' , '" & jerow.Post & "' , '" & jerow.dflag & "' , '" & jerow.Agency & "' , '" & jerow.Void & "')"
                Call ETSSQL.ExecuteSQL(JEDataString)
                JEDataString = sqlstmnt
            Next
            Return JEDataString
        End Function


    End Class
End Namespace

