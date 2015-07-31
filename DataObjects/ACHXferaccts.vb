Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports PS.Common

Public Class ACHXferAcctsData
    Private _NameKey As String
    Private _ScreenNam As String
    Private _PkgType As String
    Private _Bk1Aba As String
    Private _Bk1Num As String
    Private _Bk1actNum As String
    Private _Bk1COrS As String
    Private _Bk1Amt As Decimal
    Private _Bk2Aba As String
    Private _Bk2Num As String
    Private _Bk2actNum As String
    Private _Bk2COrS As String
    Private _Bk2Amt As Decimal
    Private _Bk3Aba As String
    Private _Bk3Num As String
    Private _Bk3actNum As String
    Private _Bk3COrS As String
    Private _Bk3Amt As Decimal
    Private _Bk4Aba As String
    Private _Bk4Num As String
    Private _Bk4actNum As String
    Private _Bk4COrS As String
    Private _Bk4Amt As Decimal
    Private _Bk1ChgDate As Date
    Private _Bk2ChgDate As Date
    Private _Bk3ChgDate As Date
    Private _Bk4ChgDate As Date
    Private _Void As String
    Private _Dflag As String
    Private _Agency As Integer

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

    Public Property PkgType() As String
        Get
            Return _PkgType
        End Get
        Set(ByVal value As String)
            _PkgType = value
        End Set
    End Property

    Public Property Bk1Aba() As String
        Get
            Return _Bk1Aba
        End Get
        Set(ByVal value As String)
            _Bk1Aba = value
        End Set
    End Property

    Public Property Bk1Num() As String
        Get
            Return _Bk1Num
        End Get
        Set(ByVal value As String)
            _Bk1Num = value
        End Set
    End Property

    Public Property Bk1actNum() As String
        Get
            Return _Bk1actNum
        End Get
        Set(ByVal value As String)
            _Bk1actNum = value
        End Set
    End Property

    Public Property Bk1COrS() As String
        Get
            Return _Bk1COrS
        End Get
        Set(ByVal value As String)
            _Bk1COrS = value
        End Set
    End Property

    Public Property Bk1Amt() As Decimal
        Get
            Return _Bk1Amt
        End Get
        Set(ByVal value As Decimal)
            _Bk1Amt = value
        End Set
    End Property

    Public Property Bk2Aba() As String
        Get
            Return _Bk2Aba
        End Get
        Set(ByVal value As String)
            _Bk2Aba = value
        End Set
    End Property

    Public Property Bk2Num() As String
        Get
            Return _Bk2Num
        End Get
        Set(ByVal value As String)
            _Bk2Num = value
        End Set
    End Property

    Public Property Bk2actNum() As String
        Get
            Return _Bk2actNum
        End Get
        Set(ByVal value As String)
            _Bk2actNum = value
        End Set
    End Property

    Public Property Bk2COrS() As String
        Get
            Return _Bk2COrS
        End Get
        Set(ByVal value As String)
            _Bk2COrS = value
        End Set
    End Property

    Public Property Bk2Amt() As Decimal
        Get
            Return _Bk2Amt
        End Get
        Set(ByVal value As Decimal)
            _Bk2Amt = value
        End Set
    End Property

    Public Property Bk3Aba() As String
        Get
            Return _Bk3Aba
        End Get
        Set(ByVal value As String)
            _Bk3Aba = value
        End Set
    End Property

    Public Property Bk3Num() As String
        Get
            Return _Bk3Num
        End Get
        Set(ByVal value As String)
            _Bk3Num = value
        End Set
    End Property

    Public Property Bk3actNum() As String
        Get
            Return _Bk3actNum
        End Get
        Set(ByVal value As String)
            _Bk3actNum = value
        End Set
    End Property

    Public Property Bk3COrS() As String
        Get
            Return _Bk3COrS
        End Get
        Set(ByVal value As String)
            _Bk3COrS = value
        End Set
    End Property

    Public Property Bk3Amt() As Decimal
        Get
            Return _Bk3Amt
        End Get
        Set(ByVal value As Decimal)
            _Bk3Amt = value
        End Set
    End Property

    Public Property Bk4Aba() As String
        Get
            Return _Bk4Aba
        End Get
        Set(ByVal value As String)
            _Bk4Aba = value
        End Set
    End Property

    Public Property Bk4Num() As String
        Get
            Return _Bk4Num
        End Get
        Set(ByVal value As String)
            _Bk4Num = value
        End Set
    End Property

    Public Property Bk4actNum() As String
        Get
            Return _Bk4actNum
        End Get
        Set(ByVal value As String)
            _Bk4actNum = value
        End Set
    End Property

    Public Property Bk4COrS() As String
        Get
            Return _Bk4COrS
        End Get
        Set(ByVal value As String)
            _Bk4COrS = value
        End Set
    End Property

    Public Property Bk4Amt() As Decimal
        Get
            Return _Bk4Amt
        End Get
        Set(ByVal value As Decimal)
            _Bk4Amt = value
        End Set
    End Property

    Public Property Bk1ChgDate() As Date
        Get
            Return _Bk1ChgDate
        End Get
        Set(ByVal value As Date)
            _Bk1ChgDate = value
        End Set
    End Property

    Public Property Bk2ChgDate() As Date
        Get
            Return _Bk2ChgDate
        End Get
        Set(ByVal value As Date)
            _Bk2ChgDate = value
        End Set
    End Property

    Public Property Bk3ChgDate() As Date
        Get
            Return _Bk3ChgDate
        End Get
        Set(ByVal value As Date)
            _Bk3ChgDate = value
        End Set
    End Property

    Public Property Bk4ChgDate() As Date
        Get
            Return _Bk4ChgDate
        End Get
        Set(ByVal value As Date)
            _Bk4ChgDate = value
        End Set
    End Property

    Public Property Void() As String
        Get
            Return _Void
        End Get
        Set(ByVal value As String)
            _Void = value
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

    Public Property Agency() As Integer
        Get
            Return _Agency
        End Get
        Set(ByVal value As Integer)
            _Agency = value
        End Set
    End Property


    Public ReadOnly Property ACHXferAcctDataColumnNames() As String
        Get
            Return "([name_key] , [screen_nam] , [PkgType], [bk1_aba] , [bk1_num] , [bk1act_num] , [bk1_c-or-s] , [bk1_amt] , [bk2_aba] , [bk2_num] , [bk2act_num] , [bk2_c-or-s] , [bk2_amt] , [bk3_aba] , [bk3_num] , [bk3act_num] , [bk3_c-or-s] , [bk3_amt] , [bk4_aba] , [bk4_num] , [bk4act_num] , [bk4_c-or-s] , [bk4_amt] , [bk1_chg_date] , [bk2_chg_date] , [bk3_chg_date] , [bk4_chg_date] , [void] , [dflag] , [agency] )"
        End Get
    End Property

    Public ReadOnly Property ACHXferAcctDataColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} ,{29} )" _
, Database.StringParam(_NameKey.ToString) _
, Database.StringParam(_ScreenNam.ToString) _
, Database.StringParam(_PkgType.ToString) _
, Database.StringParam(_Bk1Aba.ToString) _
, Database.StringParam(_Bk1Num.ToString) _
, Database.StringParam(_Bk1actNum.ToString) _
, Database.StringParam(_Bk1COrS.ToString) _
, (_Bk1Amt.ToString) _
, Database.StringParam(_Bk2Aba.ToString) _
, Database.StringParam(_Bk2Num.ToString) _
, Database.StringParam(_Bk2actNum.ToString) _
, Database.StringParam(_Bk2COrS.ToString) _
, (_Bk2Amt.ToString) _
, Database.StringParam(_Bk3Aba.ToString) _
, Database.StringParam(_Bk3Num.ToString) _
, Database.StringParam(_Bk3actNum.ToString) _
, Database.StringParam(_Bk3COrS.ToString) _
, (_Bk3Amt.ToString) _
, Database.StringParam(_Bk4Aba.ToString) _
, Database.StringParam(_Bk4Num.ToString) _
, Database.StringParam(_Bk4actNum.ToString) _
, Database.StringParam(_Bk4COrS.ToString) _
, (_Bk4Amt.ToString) _
, Database.StringParam(_Bk1ChgDate.ToShortDateString) _
, Database.StringParam(_Bk2ChgDate.ToShortDateString) _
, Database.StringParam(_Bk3ChgDate.ToShortDateString) _
, Database.StringParam(_Bk4ChgDate.ToShortDateString) _
, Database.StringParam(_Void.ToString) _
, Database.StringParam(_Dflag.ToString) _
, (_Agency.ToString) _
)
        End Get
    End Property
End Class
