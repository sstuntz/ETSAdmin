Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports PS.Common

Public Class NameAddrData
    Private _NameKey As String
    Private _ScreenNam As String
    Private _SortName As String
    Private _Salutation As String
    Private _FirstName As String
    Private _MiddleIni As String
    Private _LastName As String
    Private _Suffix As String
    Private _Address1 As String
    Private _Address2 As String
    Private _Address3 As String
    Private _City As String
    Private _State As String
    Private _Zip4 As String
    Private _Telephone As String
    Private _Fax As String
    Private _Email As String
    Private _EntryDate As Date
    Private _Dflag As String
    Private _Agency As Integer
    Private _Title As String
    Private _Country As String

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

    Public Property Salutation() As String
        Get
            Return _Salutation
        End Get
        Set(ByVal value As String)
            _Salutation = value
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return _FirstName
        End Get
        Set(ByVal value As String)
            _FirstName = value
        End Set
    End Property

    Public Property MiddleIni() As String
        Get
            Return _MiddleIni
        End Get
        Set(ByVal value As String)
            _MiddleIni = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return _LastName
        End Get
        Set(ByVal value As String)
            _LastName = value
        End Set
    End Property

    Public Property Suffix() As String
        Get
            Return _Suffix
        End Get
        Set(ByVal value As String)
            _Suffix = value
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

    Public Property Address3() As String
        Get
            Return _Address3
        End Get
        Set(ByVal value As String)
            _Address3 = value
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

    Public Property Zip4() As String
        Get
            Return _Zip4
        End Get
        Set(ByVal value As String)
            _Zip4 = value
        End Set
    End Property

    Public Property Telephone() As String
        Get
            Return _Telephone
        End Get
        Set(ByVal value As String)
            _Telephone = value
        End Set
    End Property

    Public Property Fax() As String
        Get
            Return _Fax
        End Get
        Set(ByVal value As String)
            _Fax = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
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

    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
        End Set
    End Property

    Public Property Country() As String
        Get
            Return _Country
        End Get
        Set(ByVal value As String)
            _Country = value
        End Set
    End Property


    Public ReadOnly Property nam_addrColumnNames() As String
        Get
            Return "([NameKey] , [ScreenNam] , [SortName] , [Salutation] , [FirstName] , [MiddleIni] , [LastName] , [Suffix] , [Address1] , [Address2]  , [Address3] , [City] , [State] , [Zip4] , [Telephone] , [Fax] , [Email] , [EntryDate] , [Dflag] , [Agency] , [Title] , [Country] )"
        End Get
    End Property

    Public ReadOnly Property nam_addrColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20}, {21} )" _
, Database.StringParam(_NameKey.ToString) _
, Database.StringParam(_ScreenNam.ToString) _
, Database.StringParam(_SortName.ToString) _
, Database.StringParam(_Salutation.ToString) _
, Database.StringParam(_FirstName.ToString) _
, Database.StringParam(_MiddleIni.ToString) _
, Database.StringParam(_LastName.ToString) _
, Database.StringParam(_Suffix.ToString) _
, Database.StringParam(_Address1.ToString) _
, Database.StringParam(_Address2.ToString) _
, Database.StringParam(_Address3.ToString) _
, Database.StringParam(_City.ToString) _
, Database.StringParam(_State.ToString) _
, Database.StringParam(_Zip4.ToString) _
, Database.StringParam(_Telephone.ToString) _
, Database.StringParam(_Fax.ToString) _
, Database.StringParam(_Email.ToString) _
, Database.StringParam(_EntryDate.ToShortDateString) _
, Database.StringParam(_Dflag.ToString) _
, (_Agency.ToString) _
, Database.StringParam(_Title.ToString) _
, Database.StringParam(_Country.ToString) _
)
        End Get
    End Property
End Class
