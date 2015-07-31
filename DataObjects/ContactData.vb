Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class ContactData
    Private _TableKey As String
    Private _ScreenName As String
    Private _SortName As String

    Public Property TableKey() As String
        Get
            Return _TableKey
        End Get
        Set(ByVal value As String)
            _TableKey = value
        End Set
    End Property

    Public Property ScreenName() As String
        Get
            Return _ScreenName
        End Get
        Set(ByVal value As String)
            _ScreenName = value
        End Set
    End Property

    Public Property SortName() As String
        Get
            Return _SortName
        End Get
        Set(ByVal value As String)
            _SortName = value
        End Set
    End Property

End Class
