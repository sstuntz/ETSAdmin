
Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class ETSData
    Private _ColumnNumber As Integer
    Private _ColumnName As String
    Private _DataType As String
    Private _ActualData As String

    Public Property ColumnNumber() As Integer
        Get
            Return _ColumnNumber
        End Get
        Set(ByVal value As Integer)
            _ColumnNumber = value
        End Set
    End Property

    Public Property ColumnName() As String
        Get
            Return _ColumnName
        End Get
        Set(ByVal value As String)
            _ColumnName = value
        End Set
    End Property

    Public Property DataType() As String
        Get
            Return _DataType
        End Get
        Set(ByVal value As String)
            _DataType = value
        End Set
    End Property

    Public Property ActualData() As String
        Get
            Return _ActualData
        End Get
        Set(ByVal value As String)
            _ActualData = value
        End Set
    End Property
End Class

