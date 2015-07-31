Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class AuthoData
    Private _BNum As String
    Private _NameKey As String
    Private _SortName As String
    Private _AuthoNum As String
    Private _ContractKey As String
    Private _AuthoBeg As Date
    Private _AuthoEnd As Date
    Private _Active As String
    Private _PayCat As String
    Private _CrAcctNu As String
    Private _DrAcctNu As String
    Private _CustKey As String
    Private _UnitRate As Decimal
    Private _Credit As Decimal
    Private _TieBrkNum As String
    Private _TieDesc As String
    Private _ServDesc As String
    Private _ProgDesc As String
    Private _Clothing As String
    Private _Status As String
    Private _Region As String
    Private _Area As String
    Private _Sw As String
    Private _ConPurNum As String
    Private _ConsNum As String
    Private _SwNameKey As String
    Private _EntryDate As Date
    Private _Dflag As String
    Private _Agency As Integer

    Public Property BNum() As String
        Get
            Return _BNum
        End Get
        Set(ByVal value As String)
            _BNum = value
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

    Public Property AuthoNum() As String
        Get
            Return _AuthoNum
        End Get
        Set(ByVal value As String)
            _AuthoNum = value
        End Set
    End Property

    Public Property ContractKey() As String
        Get
            Return _ContractKey
        End Get
        Set(ByVal value As String)
            _ContractKey = value
        End Set
    End Property

    Public Property AuthoBeg() As Date
        Get
            Return _AuthoBeg
        End Get
        Set(ByVal value As Date)
            _AuthoBeg = value
        End Set
    End Property

    Public Property AuthoEnd() As Date
        Get
            Return _AuthoEnd
        End Get
        Set(ByVal value As Date)
            _AuthoEnd = value
        End Set
    End Property

    Public Property Active() As String
        Get
            Return _Active
        End Get
        Set(ByVal value As String)
            _Active = value
        End Set
    End Property

    Public Property PayCat() As String
        Get
            Return _PayCat
        End Get
        Set(ByVal value As String)
            _PayCat = value
        End Set
    End Property

    Public Property CrAcctNu() As String
        Get
            Return _CrAcctNu
        End Get
        Set(ByVal value As String)
            _CrAcctNu = value
        End Set
    End Property

    Public Property DrAcctNu() As String
        Get
            Return _DrAcctNu
        End Get
        Set(ByVal value As String)
            _DrAcctNu = value
        End Set
    End Property

    Public Property CustKey() As String
        Get
            Return _CustKey
        End Get
        Set(ByVal value As String)
            _CustKey = value
        End Set
    End Property

    Public Property UnitRate() As Decimal
        Get
            Return _UnitRate
        End Get
        Set(ByVal value As Decimal)
            _UnitRate = value
        End Set
    End Property

    Public Property Credit() As Decimal
        Get
            Return _Credit
        End Get
        Set(ByVal value As Decimal)
            _Credit = value
        End Set
    End Property

    Public Property TieBrkNum() As String
        Get
            Return _TieBrkNum
        End Get
        Set(ByVal value As String)
            _TieBrkNum = value
        End Set
    End Property

    Public Property TieDesc() As String
        Get
            Return _TieDesc
        End Get
        Set(ByVal value As String)
            _TieDesc = value
        End Set
    End Property

    Public Property ServDesc() As String
        Get
            Return _ServDesc
        End Get
        Set(ByVal value As String)
            _ServDesc = value
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

    Public Property Clothing() As String
        Get
            Return _Clothing
        End Get
        Set(ByVal value As String)
            _Clothing = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
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

    Public Property Area() As String
        Get
            Return _Area
        End Get
        Set(ByVal value As String)
            _Area = value
        End Set
    End Property

    Public Property Sw() As String
        Get
            Return _Sw
        End Get
        Set(ByVal value As String)
            _Sw = value
        End Set
    End Property

    Public Property ConPurNum() As String
        Get
            Return _ConPurNum
        End Get
        Set(ByVal value As String)
            _ConPurNum = value
        End Set
    End Property

    Public Property ConsNum() As String
        Get
            Return _ConsNum
        End Get
        Set(ByVal value As String)
            _ConsNum = value
        End Set
    End Property

    Public Property SwNameKey() As String
        Get
            Return _SwNameKey
        End Get
        Set(ByVal value As String)
            _SwNameKey = value
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


    Public ReadOnly Property CashRctColumnNames() As String
        Get
            Return "([BNum] , [NameKey] , [SortName] , [AuthoNum] , [ContractKey] , [AuthoBeg] , [AuthoEnd] , [Active] , [PayCat] , [CrAcctNu] , [DrAcctNu] , [CustKey] , [UnitRate] , [Credit] , [TieBrkNum] , [TieDesc] , [ServDesc] , [ProgDesc] , [Clothing] , [Status] , [Region] , [Area] , [Sw] , [ConPurNum] , [ConsNum] , [SwNameKey] , [EntryDate] , [Dflag] , [Agency] )"
        End Get
    End Property

    Public ReadOnly Property CashRctColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} )" _
, (_BNum) _
, (_NameKey) _
, (_SortName) _
, (_AuthoNum) _
, (_ContractKey) _
, (_AuthoBeg) _
, (_AuthoEnd) _
, (_Active) _
, (_PayCat) _
, (_CrAcctNu) _
, (_DrAcctNu) _
, (_CustKey) _
, (_UnitRate) _
, (_Credit) _
, (_TieBrkNum) _
, (_TieDesc) _
, (_ServDesc) _
, (_ProgDesc) _
, (_Clothing) _
, (_Status) _
, (_Region) _
, (_Area) _
, (_Sw) _
, (_ConPurNum) _
, (_ConsNum) _
, (_SwNameKey) _
, (_EntryDate) _
, (_Dflag) _
, (_Agency) _
)
        End Get
    End Property
End Class
