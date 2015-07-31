Imports System.Data
Imports System.Data.SqlClient

Namespace Allin.Common

    Public Class Database
        Implements IDisposable

        Private amDisposed As Boolean
        Private logAll As Boolean
        Private conn As SqlConnection
        Private tran As SqlTransaction
        Private stmts As ArrayList
        Private rsets As ArrayList
        Private dsets As ArrayList

        Public Shared Function StringParam(ByVal data As String) As String
            If data Is Nothing Then
                Return "''"
            End If
            Return String.Format("'{0}'", data.Replace("'", "''"))
        End Function

        Public Sub New(ByVal connectionString As String, ByVal transacted As Boolean, ByVal isoLevel As System.Data.IsolationLevel)
            Me.amDisposed = False
            Me.logAll = False
            Me.conn = Nothing
            Me.tran = Nothing
            Me.stmts = New ArrayList()
            Me.rsets = New ArrayList()
            Me.dsets = New ArrayList()
            If connectionString IsNot Nothing Then
                Open(connectionString, transacted, isoLevel)
            End If
        End Sub

        Public Sub New(ByVal connectionString As String, ByVal transacted As Boolean)
            Me.New(connectionString, transacted, System.Data.IsolationLevel.Serializable)
        End Sub

        Public Sub New(ByVal connectionString As String)
            Me.New(connectionString, False, Nothing)
        End Sub

        Public Sub New()
            Me.New(Nothing, False, Nothing)
        End Sub

        Public Sub Open(ByVal connectionString As String, ByVal transacted As Boolean, ByVal isoLevel As IsolationLevel)
            If Me.amDisposed Then
                Throw New ObjectDisposedException("Database")
            End If
            If Me.conn IsNot Nothing Then
                Throw New Exception("Database connection already open")
            End If
            Me.conn = New SqlConnection(connectionString)
            Me.conn.Open()
            If transacted Then
                Me.tran = conn.BeginTransaction(isoLevel)
            End If
        End Sub

        Public Sub Open(ByVal connectionString As String, ByVal transacted As Boolean)
            Open(connectionString, transacted, IsolationLevel.Serializable)
        End Sub

        Public Sub Open(ByVal connectionString As String)
            Open(connectionString, False, Nothing)
        End Sub

        Public Function RunProcedure(ByVal procName As String, ByVal params As SqlParameter()) As Integer
            If Me.amDisposed Then
                Throw New ObjectDisposedException("Database")
            End If
            Dim stmt As SqlCommand = CreateCommand(procName, params)
            stmt.ExecuteNonQuery()
            Return CType(stmt.Parameters("ReturnValue").Value, Integer)
        End Function

        Public Function RunProcedureWithResults(ByVal procName As String, ByVal params As SqlParameter()) As SqlDataReader
            If Me.amDisposed Then
                Throw New ObjectDisposedException("Database")
            End If
            Dim stmt As SqlCommand = CreateCommand(procName, params)
            Dim rset As SqlDataReader = stmt.ExecuteReader()
            Me.rsets.Add(rset)
            Return rset
        End Function

        Private Function CreateCommand(ByVal procName As String, ByVal params As SqlParameter()) As SqlCommand
            Dim stmt As SqlCommand = New SqlCommand(procName, Me.conn, Me.tran)
            Me.stmts.Add(stmt)
            stmt.CommandType = CommandType.StoredProcedure
            If params IsNot Nothing Then
                For Each parameter As SqlParameter In params
                    stmt.Parameters.Add(parameter)
                Next
            End If
            stmt.Parameters.Add(New SqlParameter("ReturnValue", SqlDbType.Int, 4, _
                                        ParameterDirection.ReturnValue, False, 0, 0, _
                                        String.Empty, DataRowVersion.Default, Nothing))
            Return stmt
        End Function

        Public Function ExecuteUpdate(ByVal sql As String) As Integer
            If Me.amDisposed Then
                Throw New ObjectDisposedException("Database")
            End If
            Dim stmt As SqlCommand = New SqlCommand(sql, Me.conn, Me.tran)
            Me.stmts.Add(stmt)
            Return stmt.ExecuteNonQuery()
        End Function

        Public Function ExecuteScalar(ByVal sql As String) As String
            If Me.amDisposed Then
                Throw New ObjectDisposedException("Database")
            End If
            Dim stmt As SqlCommand = New SqlCommand(sql, Me.conn, Me.tran)
            Me.stmts.Add(stmt)
            Return stmt.ExecuteScalar().ToString()
        End Function

        Public Function ExecuteQuery(ByVal sql As String) As SqlDataReader
            If Me.amDisposed Then
                Throw New ObjectDisposedException("Database")
            End If
            Dim stmt As SqlCommand = New SqlCommand(sql, Me.conn, Me.tran)
            Me.stmts.Add(stmt)
            Dim rset As SqlDataReader = stmt.ExecuteReader()
            Me.rsets.Add(rset)
            Return rset
        End Function

        Public Function FillDataSet(ByVal sql As String) As DataSet
            If Me.amDisposed Then
                Throw New ObjectDisposedException("Database")
            End If
            Dim adr As SqlDataAdapter = New SqlDataAdapter(sql, Me.conn)
            Dim dset As DataSet = New DataSet()
            Me.dsets.Add(dset)
            adr.Fill(dset)
            adr.Dispose()
            Return dset
        End Function

        Public Sub Commit()
            If Me.amDisposed Then
                Throw New ObjectDisposedException("Database")
            End If
            If Me.tran IsNot Nothing Then
                Me.tran.Commit()
                Me.Dispose()
            End If
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            If Not Me.amDisposed Then
                Me.amDisposed = True
                For Each dset As DataSet In Me.dsets
                    Try
                        dset.Dispose()
                    Catch ex As Exception
                        ' ...
                    End Try
                Next
                Me.dsets = Nothing
                For Each rset As SqlDataReader In Me.rsets
                    Try
                        If Not rset.IsClosed() Then
                            rset.Close()
                        End If
                    Catch ex As Exception
                        ' ...
                    End Try
                Next
                Me.rsets = Nothing
                For Each stmt As SqlCommand In Me.stmts
                    Try
                        stmt.Dispose()
                    Catch ex As Exception
                        ' ...
                    End Try
                Next
                Me.stmts = Nothing
                If Me.tran IsNot Nothing Then
                    Try
                        Me.tran.Rollback()
                    Catch ex As Exception
                        ' ...
                    End Try
                    Try
                        Me.tran.Dispose()
                    Catch ex As Exception
                        ' ...
                    End Try
                    Me.tran = Nothing
                End If
                If conn IsNot Nothing Then
                    Try
                        Me.conn.Close()
                    Catch ex As Exception
                        ' ...
                    End Try
                    Try
                        Me.conn.Dispose()
                    Catch ex As Exception
                        ' ...
                    End Try
                    Me.conn = Nothing
                End If
            End If
        End Sub

        Protected Overrides Sub Finalize()
            If Not Me.amDisposed Then
                Me.Dispose()
            End If
        End Sub

    End Class

End Namespace
