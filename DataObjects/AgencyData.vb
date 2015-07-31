Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class AgencyData
    Private _Agency As Integer
    Private _AgencyName As String
    Private _AgencyLine2 As String
    Private _Address1 As String
    Private _Address2 As String
    Private _City As String
    Private _State As String
    Private _Zip As String
    Private _ApCntrNu As String
    Private _DrvName As String

    Public Property Agency() As Integer
        Get
            Return _Agency
        End Get
        Set(ByVal value As Integer)
            _Agency = value
        End Set
    End Property

    Public Property AgencyName() As String
        Get
            Return _AgencyName
        End Get
        Set(ByVal value As String)
            _AgencyName = value
        End Set
    End Property

    Public Property AgencyLine2() As String
        Get
            Return _AgencyLine2
        End Get
        Set(ByVal value As String)
            _AgencyLine2 = value
        End Set
    End Property

    Public Property Address1() As String
        Get
            Return _Address1
        End Get
        Set(ByVal value As String)
            _Address1 = value
        End Set
    End Property

    Public Property Address2() As String
        Get
            Return _Address2
        End Get
        Set(ByVal value As String)
            _Address2 = value
        End Set
    End Property

    Public Property City() As String
        Get
            Return _City
        End Get
        Set(ByVal value As String)
            _City = value
        End Set
    End Property

    Public Property State() As String
        Get
            Return _State
        End Get
        Set(ByVal value As String)
            _State = value
        End Set
    End Property

    Public Property Zip() As String
        Get
            Return _Zip
        End Get
        Set(ByVal value As String)
            _Zip = value
        End Set
    End Property

    Public Property ApCntrNu() As String
        Get
            Return _ApCntrNu
        End Get
        Set(ByVal value As String)
            _ApCntrNu = value
        End Set
    End Property

    Public Property DrvName() As String
        Get
            Return _DrvName
        End Get
        Set(ByVal value As String)
            _DrvName = value
        End Set
    End Property


    Public ReadOnly Property CashRctColumnNames() As String
        Get
            Return "([Agency] , [AgencyName] , [AgencyLine2] , [Address1] , [Address2] , [City] , [State] , [Zip] , [ApCntrNu] , [DrvName] )"
        End Get
    End Property

    Public ReadOnly Property CashRctColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} )" _
, (_Agency) _
, (_AgencyName) _
, (_AgencyLine2) _
, (_Address1) _
, (_Address2) _
, (_City) _
, (_State) _
, (_Zip) _
, (_ApCntrNu) _
, (_DrvName) _
)
        End Get
    End Property
End Class
