Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports PS.Common

Public Class nam_bankData
    Private _BankKey As String
    Private _ScreenNam As String
    Private _CntctNa1 As String
    Private _CntctNu1 As String
    Private _CntctNa2 As String
    Private _CntctNu2 As String
    Private _CrPrefAc As String
    Private _DrPrefAc As String
    Private _BankReas As String
    Private _BkAcctNo As String
    Private _BkTransit As String
    Private _Dflag As String
    Private _NameKey As String
    Private _SortName As String

    Public Property BankKey() As String
        Get
            Return _BankKey
        End Get
        Set(ByVal value As String)
            _BankKey = value
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

    Public Property CntctNa1() As String
        Get
            Return _CntctNa1
        End Get
        Set(ByVal value As String)
            _CntctNa1 = value
        End Set
    End Property

    Public Property CntctNu1() As String
        Get
            Return _CntctNu1
        End Get
        Set(ByVal value As String)
            _CntctNu1 = value
        End Set
    End Property

    Public Property CntctNa2() As String
        Get
            Return _CntctNa2
        End Get
        Set(ByVal value As String)
            _CntctNa2 = value
        End Set
    End Property

    Public Property CntctNu2() As String
        Get
            Return _CntctNu2
        End Get
        Set(ByVal value As String)
            _CntctNu2 = value
        End Set
    End Property

    Public Property CrPrefAc() As String
        Get
            Return _CrPrefAc
        End Get
        Set(ByVal value As String)
            _CrPrefAc = value
        End Set
    End Property

    Public Property DrPrefAc() As String
        Get
            Return _DrPrefAc
        End Get
        Set(ByVal value As String)
            _DrPrefAc = value
        End Set
    End Property

    Public Property BankReas() As String
        Get
            Return _BankReas
        End Get
        Set(ByVal value As String)
            _BankReas = value
        End Set
    End Property

    Public Property BkAcctNo() As String
        Get
            Return _BkAcctNo
        End Get
        Set(ByVal value As String)
            _BkAcctNo = value
        End Set
    End Property

    Public Property BkTransit() As String
        Get
            Return _BkTransit
        End Get
        Set(ByVal value As String)
            _BkTransit = value
        End Set
    End Property

    Public Property Dflag() As String
        Get
            Return _Dflag
        End Get
        Set(ByVal value As String)
            _Dflag = value
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

    Public Property SortName() As String
        Get
            Return _SortName
        End Get
        Set(ByVal value As String)
            _SortName = value
        End Set
    End Property


    Public ReadOnly Property nam_bankColumnNames() As String
        Get
            Return "([Bank_Key] , [Screen_Nam] , [Cntct_Na1] , [Cntct_Nu1] , [Cntct_Na2] , [Cntct_Nu2] , [Cr_Pref_Ac] , [Dr_Pref_Ac] , [Bank_Reas] , [Bk_Acct_No] , [Bk_Transit] , [Dflag] , [Name_Key] , [Sort_Name] )"
        End Get
    End Property

    Public ReadOnly Property nam_bankColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} )" _
, Database.StringParam(_BankKey.ToString) _
, Database.StringParam(_ScreenNam.ToString) _
, Database.StringParam(_CntctNa1.ToString) _
, Database.StringParam(_CntctNu1.ToString) _
, Database.StringParam(_CntctNa2.ToString) _
, Database.StringParam(_CntctNu2.ToString) _
, Database.StringParam(_CrPrefAc.ToString) _
, Database.StringParam(_DrPrefAc.ToString) _
, Database.StringParam(_BankReas.ToString) _
, Database.StringParam(_BkAcctNo.ToString) _
, Database.StringParam(_BkTransit.ToString) _
, Database.StringParam(_Dflag.ToString) _
, Database.StringParam(_NameKey.ToString) _
, Database.StringParam(_SortName.ToString) _
)
        End Get
    End Property
End Class
