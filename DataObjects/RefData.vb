Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class RefData
    Private _PackageType As String
    Private _FormName As String
    Private _ControlName As String
    Private _Datum As String
    Private _DatumDesc As String
    Private _ControlVisible As String

    Public Property PackageType() As String
        Get
            Return _PackageType
        End Get
        Set(ByVal value As String)
            _PackageType = value
        End Set
    End Property

    Public Property FormName() As String
        Get
            Return _FormName
        End Get
        Set(ByVal value As String)
            _FormName = value
        End Set
    End Property

    Public Property ControlName() As String
        Get
            Return _ControlName
        End Get
        Set(ByVal value As String)
            _ControlName = value
        End Set
    End Property

    Public Property Datum() As String
        Get
            Return _Datum
        End Get
        Set(ByVal value As String)
            _Datum = value
        End Set
    End Property

    Public Property DatumDesc() As String
        Get
            Return _DatumDesc
        End Get
        Set(ByVal value As String)
            _DatumDesc = value
        End Set
    End Property

    Public Property ControlVisible() As String
        Get
            Return _ControlVisible
        End Get
        Set(ByVal value As String)
            _ControlVisible = value
        End Set
    End Property

End Class
