Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class ClientBaseData
    Private _NameKey As String
    Private _ScreenNam As String
    Private _SortName As String
    Private _AdmitDate As Date
    Private _TermDate As Date
    Private _ActStatus As String
    Private _Sex As String
    Private _Dob As Date
    Private _Birthplace As String
    Private _SsNum As String
    Private _MedNum As String
    Private _MassHNum As String
    Private _MisNum As String
    Private _OtherNum As String
    Private _AttNum As String
    Private _Region As String
    Private _Town As String
    Private _Refer As String
    Private _Race As String
    Private _Memo1 As String
    Private _Memo2 As String
    Private _Memo3 As String
    Private _Code1 As String
    Private _Code2 As String
    Private _Code3 As String
    Private _Code4 As String
    Private _EntryDate As Date
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

    Public Property SortName() As String
        Get
            Return _SortName
        End Get
        Set(ByVal value As String)
            _SortName = value
        End Set
    End Property

    Public Property AdmitDate() As Date
        Get
            Return _AdmitDate
        End Get
        Set(ByVal value As Date)
            _AdmitDate = value
        End Set
    End Property

    Public Property TermDate() As Date
        Get
            Return _TermDate
        End Get
        Set(ByVal value As Date)
            _TermDate = value
        End Set
    End Property

    Public Property ActStatus() As String
        Get
            Return _ActStatus
        End Get
        Set(ByVal value As String)
            _ActStatus = value
        End Set
    End Property

    Public Property Sex() As String
        Get
            Return _Sex
        End Get
        Set(ByVal value As String)
            _Sex = value
        End Set
    End Property

    Public Property Dob() As Date
        Get
            Return _Dob
        End Get
        Set(ByVal value As Date)
            _Dob = value
        End Set
    End Property

    Public Property Birthplace() As String
        Get
            Return _Birthplace
        End Get
        Set(ByVal value As String)
            _Birthplace = value
        End Set
    End Property

    Public Property SsNum() As String
        Get
            Return _SsNum
        End Get
        Set(ByVal value As String)
            _SsNum = value
        End Set
    End Property

    Public Property MedNum() As String
        Get
            Return _MedNum
        End Get
        Set(ByVal value As String)
            _MedNum = value
        End Set
    End Property

    Public Property MassHNum() As String
        Get
            Return _MassHNum
        End Get
        Set(ByVal value As String)
            _MassHNum = value
        End Set
    End Property

    Public Property MisNum() As String
        Get
            Return _MisNum
        End Get
        Set(ByVal value As String)
            _MisNum = value
        End Set
    End Property

    Public Property OtherNum() As String
        Get
            Return _OtherNum
        End Get
        Set(ByVal value As String)
            _OtherNum = value
        End Set
    End Property

    Public Property AttNum() As String
        Get
            Return _AttNum
        End Get
        Set(ByVal value As String)
            _AttNum = value
        End Set
    End Property

    Public Property Region() As String
        Get
            Return _Region
        End Get
        Set(ByVal value As String)
            _Region = value
        End Set
    End Property

    Public Property Town() As String
        Get
            Return _Town
        End Get
        Set(ByVal value As String)
            _Town = value
        End Set
    End Property

    Public Property Refer() As String
        Get
            Return _Refer
        End Get
        Set(ByVal value As String)
            _Refer = value
        End Set
    End Property

    Public Property Race() As String
        Get
            Return _Race
        End Get
        Set(ByVal value As String)
            _Race = value
        End Set
    End Property

    Public Property Memo1() As String
        Get
            Return _Memo1
        End Get
        Set(ByVal value As String)
            _Memo1 = value
        End Set
    End Property

    Public Property Memo2() As String
        Get
            Return _Memo2
        End Get
        Set(ByVal value As String)
            _Memo2 = value
        End Set
    End Property

    Public Property Memo3() As String
        Get
            Return _Memo3
        End Get
        Set(ByVal value As String)
            _Memo3 = value
        End Set
    End Property

    Public Property Code1() As String
        Get
            Return _Code1
        End Get
        Set(ByVal value As String)
            _Code1 = value
        End Set
    End Property

    Public Property Code2() As String
        Get
            Return _Code2
        End Get
        Set(ByVal value As String)
            _Code2 = value
        End Set
    End Property

    Public Property Code3() As String
        Get
            Return _Code3
        End Get
        Set(ByVal value As String)
            _Code3 = value
        End Set
    End Property

    Public Property Code4() As String
        Get
            Return _Code4
        End Get
        Set(ByVal value As String)
            _Code4 = value
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


    Public ReadOnly Property ClientBaseColumnNames() As String
        Get
            Return "([NameKey] , [ScreenNam] , [SortName] , [AdmitDate] , [TermDate] , [ActStatus] , [Sex] , [Dob] , [Birthplace] , [SsNum] , [MedNum] , [MassHNum] , [MisNum] , [OtherNum] , [AttNum] , [Region] , [Town] , [Refer] , [Race] , [Memo1] , [Memo2] , [Memo3] , [Code1] , [Code2] , [Code3] , [Code4] , [EntryDate] , [Dflag] , [Agency] )"
        End Get
    End Property

    Public ReadOnly Property ClientBaseColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} )" _
, (_NameKey) _
, (_ScreenNam) _
, (_SortName) _
, (_AdmitDate) _
, (_TermDate) _
, (_ActStatus) _
, (_Sex) _
, (_Dob) _
, (_Birthplace) _
, (_SsNum) _
, (_MedNum) _
, (_MassHNum) _
, (_MisNum) _
, (_OtherNum) _
, (_AttNum) _
, (_Region) _
, (_Town) _
, (_Refer) _
, (_Race) _
, (_Memo1) _
, (_Memo2) _
, (_Memo3) _
, (_Code1) _
, (_Code2) _
, (_Code3) _
, (_Code4) _
, (_EntryDate) _
, (_Dflag) _
, (_Agency) _
)
        End Get
    End Property
End Class
