
Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class BillableClient

    Implements IEquatable(Of BillableClient)

    Private _bNum As String
    Private _BegDate As Date
    Private _EndDate As Date
    Private _BillType As String
    Private _NameKey As String
    Private _ContractKey As String
    Private _Billed As String

    Public Property ContractKey() As String
        Get
            Return _ContractKey
        End Get
        Set(ByVal value As String)
            _ContractKey = value
        End Set
    End Property

    Public Property BegDate() As Date
        Get
            Return _BegDate
        End Get
        Set(ByVal value As Date)
            _BegDate = value
        End Set
    End Property

    Public Property EndDate() As Date
        Get
            Return _EndDate
        End Get
        Set(ByVal value As Date)
            _EndDate = value
        End Set
    End Property

    Public Property BillType() As String
        Get
            Return _BillType
        End Get
        Set(ByVal value As String)
            _BillType = value
        End Set
    End Property

    Public Property BNum() As String
        Get
            Return _bNum
        End Get
        Set(ByVal value As String)
            _bNum = value
        End Set
    End Property

    Public Property NameKey() As String
        Get
            Return _NameKey
        End Get
        Set(ByVal value As String)
            _NameKey = value
        End Set
    End Property

    Public Property Billed() As String
        Get
            Return _Billed
        End Get
        Set(ByVal value As String)
            _Billed = value
        End Set
    End Property

    'Public Function EqualsType(ByVal other As Billable) As Boolean Implements IEquatable(Of Billable).Equals
    '    If other Is Nothing Then Return False
    '    If Me Is other Then Return True
    '    Return BillType.Equals(other.BillType)
    'End Function

    Public Function EqualsClient(ByVal other As BillableClient) As Boolean Implements IEquatable(Of BillableClient).Equals
        If other Is Nothing Then Return False
        If Me Is other Then Return True
        Return NameKey.Equals(other.NameKey)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Dim hashBillablenamekey = If(NameKey Is Nothing, 0, NameKey.GetHashCode)
        Return hashBillablenamekey
    End Function


End Class

