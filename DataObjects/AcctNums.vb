Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class AcctNums
    Private _AcctNum As String
    Private _AcctDpt As String
    Private _AcctPgm As String
    Private _AcctDesc As String
    Private _AcctOnly As String
    Private _GlRefNo As String
    Private _CrDr As String
    Private _AcctTest As String
    Private _Acct_1 As String
    Private _Acct_2 As String
    Private _Acct_3 As String
    Private _Acct_4 As String


    Public Property AcctNum() As String
        Get
            Return _AcctNum
        End Get
        Set(ByVal value As String)
            _AcctNum = value
        End Set
    End Property

    Public Property AcctPgm() As String
        Get
            Return _AcctPgm
        End Get
        Set(ByVal value As String)
            _AcctPgm = value
        End Set
    End Property

    Public Property AcctDpt() As String
        Get
            Return _AcctDpt
        End Get
        Set(ByVal value As String)
            _AcctDpt = value
        End Set
    End Property

    Public Property AcctOnly() As String
        Get
            Return _AcctOnly
        End Get
        Set(ByVal value As String)
            _AcctOnly = value
        End Set
    End Property

    Public Property AcctDesc() As String
        Get
            Return _AcctDesc
        End Get
        Set(ByVal value As String)
            _AcctDesc = value
        End Set
    End Property

    Public Property GlREfNo() As String
        Get
            Return _GlRefNo
        End Get
        Set(ByVal value As String)
            _GlRefNo = value
        End Set
    End Property

    Public Property CRDR() As String
        Get
            Return _CrDr
        End Get
        Set(ByVal value As String)
            _CrDr = value
        End Set
    End Property

    Public Property AcctTest() As String
        Get
            Return _AcctTest
        End Get
        Set(ByVal value As String)
            _AcctTest = value
        End Set
    End Property

    Public Property acct_1() As String
        Get
            Return _Acct_1
        End Get
        Set(ByVal value As String)
            _Acct_1 = value
        End Set
    End Property

    Public Property acct_2() As String
        Get
            Return _Acct_2
        End Get
        Set(ByVal value As String)
            _Acct_2 = value
        End Set
    End Property

    Public Property acct_3() As String
        Get
            Return _Acct_3
        End Get
        Set(ByVal value As String)
            _Acct_3 = value
        End Set
    End Property

End Class
