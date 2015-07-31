Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class ProgramData
    Private _ProgNum As String
    Private _ProgDesc As String
    Private _ProgRate As Decimal
    Private _Division As String
    Private _FiscalYr As String
    Private _Location As String
    Private _UfrNum As String
    Private _EntryDate As Date

    Public Property ProgNum() As String
        Get
            Return _ProgNum
        End Get
        Set(ByVal value As String)
            _ProgNum = value
        End Set
    End Property

    Public Property ProgDesc() As String
        Get
            Return _ProgDesc
        End Get
        Set(ByVal value As String)
            _ProgDesc = value
        End Set
    End Property

    Public Property ProgRate() As Decimal
        Get
            Return _ProgRate
        End Get
        Set(ByVal value As Decimal)
            _ProgRate = value
        End Set
    End Property

    Public Property Division() As String
        Get
            Return _Division
        End Get
        Set(ByVal value As String)
            _Division = value
        End Set
    End Property

    Public Property FiscalYr() As String
        Get
            Return _FiscalYr
        End Get
        Set(ByVal value As String)
            _FiscalYr = value
        End Set
    End Property

    Public Property Location() As String
        Get
            Return _Location
        End Get
        Set(ByVal value As String)
            _Location = value
        End Set
    End Property

    Public Property UfrNum() As String
        Get
            Return _UfrNum
        End Get
        Set(ByVal value As String)
            _UfrNum = value
        End Set
    End Property

    Public Property EntryDate() As Date
        Get
            Return _EntryDate
        End Get
        Set(ByVal value As Date)
            _EntryDate = value
        End Set
    End Property


    Public ReadOnly Property CashRctColumnNames() As String
        Get
            Return "([ProgNum] , [ProgDesc] , [ProgRate] , [Division] , [FiscalYr] , [Location] , [UfrNum] , [EntryDate] )"
        End Get
    End Property

    Public ReadOnly Property CashRctColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} )" _
, (_ProgNum) _
, (_ProgDesc) _
, (_ProgRate) _
, (_Division) _
, (_FiscalYr) _
, (_Location) _
, (_UfrNum) _
, (_EntryDate) _
)
        End Get
    End Property
End Class
