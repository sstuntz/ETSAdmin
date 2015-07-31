Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class BudgetData

    Private _AcctNum As String
    Private _mth1 As Decimal
    Private _mth2 As Decimal
    Private _mth3 As Decimal
    Private _mth4 As Decimal
    Private _mth5 As Decimal
    Private _mth6 As Decimal
    Private _mth7 As Decimal
    Private _mth8 As Decimal
    Private _mth9 As Decimal
    Private _mth10 As Decimal
    Private _mth11 As Decimal
    Private _mth12 As Decimal
    Private _BudgetTotal As Decimal

    Public Property AcctNum() As String
        Get
            Return _AcctNum
        End Get
        Set(ByVal value As String)
            _AcctNum = value
        End Set
    End Property

    Public Property Mth1() As Decimal
        Get
            Return _mth1
        End Get
        Set(ByVal value As Decimal)
            _mth1 = value
        End Set
    End Property

    Public Property Mth2() As Decimal
        Get
            Return _mth2
        End Get
        Set(ByVal value As Decimal)
            _mth2 = value
        End Set
    End Property

    Public Property Mth3() As Decimal
        Get
            Return _mth3
        End Get
        Set(ByVal value As Decimal)
            _mth3 = value
        End Set
    End Property

    Public Property Mth4() As Decimal
        Get
            Return _mth4
        End Get
        Set(ByVal value As Decimal)
            _mth4 = value
        End Set
    End Property

    Public Property Mth5() As Decimal
        Get
            Return _mth5
        End Get
        Set(ByVal value As Decimal)
            _mth5 = value
        End Set
    End Property

    Public Property Mth6() As Decimal
        Get
            Return _mth6
        End Get
        Set(ByVal value As Decimal)
            _mth6 = value
        End Set
    End Property

    Public Property Mth7() As Decimal
        Get
            Return _mth7
        End Get
        Set(ByVal value As Decimal)
            _mth7 = value
        End Set
    End Property

    Public Property Mth8() As Decimal
        Get
            Return _mth8
        End Get
        Set(ByVal value As Decimal)
            _mth8 = value
        End Set
    End Property

    Public Property Mth9() As Decimal
        Get
            Return _mth9
        End Get
        Set(ByVal value As Decimal)
            _mth9 = value
        End Set
    End Property

    Public Property Mth10() As Decimal
        Get
            Return _mth10
        End Get
        Set(ByVal value As Decimal)
            _mth10 = value
        End Set
    End Property

    Public Property Mth11() As Decimal
        Get
            Return _mth11
        End Get
        Set(ByVal value As Decimal)
            _mth11 = value
        End Set
    End Property

    Public Property Mth12() As Decimal
        Get
            Return _mth12
        End Get
        Set(ByVal value As Decimal)
            _mth12 = value
        End Set
    End Property

    Public Property BudgetTotal() As Decimal
        Get
            BudgetTotal = _mth1 + _mth2 + _mth3 + _mth4 + _mth5 + _mth6 + _mth7 + _mth8 + _mth9 + _mth10 + _mth11 + _mth12
            Return _BudgetTotal
        End Get
        Set(ByVal value As Decimal)
            _BudgetTotal = value
        End Set
    End Property

End Class
