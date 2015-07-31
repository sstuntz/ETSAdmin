Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class APCheckData

    Private _VouchNum As Integer
    Private _NameKey As String
    Private _ScreenNam As String
    Private _VouchAmt As Double
    Private _DiscAmt As Double
    Private _PaidAmt As Double
    Private _PaidDisc As Double
    Private _BalDue As Double
    Private _CheckNum As Integer
    Private _NetCheckAmt As Double
    Private _NetDiscAmt As Double
    Private _CheckDate As Date
    Private _Printed As String
    Private _Agency As String
    Private _VendInv As String
    Private _SortName As String
    Private _VendInvDate As Date
    Private _BankKey As String
    Private _APCheckColumnData As String

    Public Property VouchNum() As Integer
        Get
            Return _VouchNum
        End Get
        Set(ByVal value As Integer)
            _VouchNum = value
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

    Public Property ScreenNam() As String
        Get
            Return _ScreenNam
        End Get
        Set(ByVal value As String)
            _ScreenNam = value
        End Set
    End Property

    Public Property VouchAmt() As Double
        Get
            Return _VouchAmt
        End Get
        Set(ByVal value As Double)
            _VouchAmt = value
        End Set
    End Property

    Public Property DiscAmt() As Double
        Get
            Return _DiscAmt
        End Get
        Set(ByVal value As Double)
            _DiscAmt = value
        End Set
    End Property

    Public Property PaidAmt() As Double
        Get
            Return _PaidAmt
        End Get
        Set(ByVal value As Double)
            _PaidAmt = value
        End Set
    End Property

    Public Property PaidDisc() As Double
        Get
            Return _PaidDisc
        End Get
        Set(ByVal value As Double)
            _PaidDisc = value
        End Set
    End Property

    Public Property BalDue() As Double
        Get
            Return _BalDue
        End Get
        Set(ByVal value As Double)
            _BalDue = value
        End Set
    End Property

    Public Property CheckNum() As Integer
        Get
            Return _CheckNum
        End Get
        Set(ByVal value As Integer)
            _CheckNum = value
        End Set
    End Property

    Public Property NetCheckAmt() As Double
        Get
            Return _NetCheckAmt
        End Get
        Set(ByVal value As Double)
            _NetCheckAmt = value
        End Set
    End Property

    Public Property NetDiscAmt() As Double
        Get
            Return _NetDiscAmt
        End Get
        Set(ByVal value As Double)
            _NetDiscAmt = value
        End Set
    End Property

    Public Property CheckDate() As Date
        Get
            Return _CheckDate
        End Get
        Set(ByVal value As Date)
            _CheckDate = value
        End Set
    End Property

    Public Property Printed() As String
        Get
            Return _Printed
        End Get
        Set(ByVal value As String)
            _Printed = value
        End Set
    End Property

    Public Property Agency() As String
        Get
            Return _Agency
        End Get
        Set(ByVal value As String)
            _Agency = value
        End Set
    End Property

    Public Property VendInv() As String
        Get
            Return _VendInv
        End Get
        Set(ByVal value As String)
            _VendInv = value
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

    Public Property VendInvDate() As Date
        Get
            Return _VendInvDate
        End Get
        Set(ByVal value As Date)
            _VendInvDate = value
        End Set
    End Property

    Public Property BankKey() As String
        Get
            Return _BankKey
        End Get
        Set(ByVal value As String)
            _BankKey = value
        End Set
    End Property
    Public ReadOnly Property APCheckColumnNames() As String
        Get
            Return "[vouch_num] , [name_key] ,[screen_nam], [vouch_amt], [disc_amt], [amt_paid],[amt_disc],	[bal_due],	[chk_num],[n_chk_amt],[n_dis_amt],[chk_date],[printed],	[agency] ,[vend_inv],[sort_name],[inv_date], [BankKey]"
        End Get
    End Property
    Public ReadOnly Property APCheckColumnData() As String
        Get
            Return "'" & _VouchNum & "','" & _NameKey.ToString & "','" & _ScreenNam.ToString & "','" & _VouchAmt & "','" & _DiscAmt & "','" & _PaidAmt & "','" & _PaidDisc & "','" & _BalDue & "'," _
            & _CheckNum & "," & _NetCheckAmt & "'," & _NetDiscAmt & ",'" & _CheckDate.ToShortDateString & ",'" & _Printed.ToString & "','" & _Agency.ToString & "','" & _VendInv.ToString & "','" & _SortName.ToString & "','" & _VendInvDate.ToShortDateString & "','" & _BankKey.ToString & "'," _
            & "')"
        End Get
    End Property


End Class
