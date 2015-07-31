Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class CashRctData
	Private _BNum as String
	Private _NameKey as String
	Private _SortName as String
	Private _AuthoNum as String
	Private _ContractKey as String
	Private _AuthoBeg as Date
	Private _AuthoEnd as Date
	Private _Active as String
	Private _PayCat as String
	Private _CrAcctNu as String
	Private _DrAcctNu as String
	Private _CustKey as String
	Private _UnitRate as Decimal
	Private _Credit as Decimal
	Private _TieBrkNum as String
	Private _TieDesc as String
	Private _ServDesc as String
	Private _ProgDesc as String
	Private _Clothing as String
	Private _Status as String
	Private _Region as String
	Private _Area as String
	Private _Sw as String
	Private _ConPurNum as String
	Private _ConsNum as String
	Private _SwNameKey as String
	Private _EntryDate as Date
	Private _Dflag as String
	Private _Agency as Integer

Public Property BNum()  as String
	Get
		Return _BNum
	End Get
	Set (ByVal value  as String )
		_BNum = value
	End Set
End Property

Public Property NameKey()  as String
	Get
		Return _NameKey
	End Get
	Set (ByVal value  as String )
		_NameKey = value
	End Set
End Property

Public Property SortName()  as String
	Get
		Return _SortName
	End Get
	Set (ByVal value  as String )
		_SortName = value
	End Set
End Property

Public Property AuthoNum()  as String
	Get
		Return _AuthoNum
	End Get
	Set (ByVal value  as String )
		_AuthoNum = value
	End Set
End Property

Public Property ContractKey()  as String
	Get
		Return _ContractKey
	End Get
	Set (ByVal value  as String )
		_ContractKey = value
	End Set
End Property

Public Property AuthoBeg()  as Date
	Get
		Return _AuthoBeg
	End Get
	Set (ByVal value  as Date )
		_AuthoBeg = value
	End Set
End Property

Public Property AuthoEnd()  as Date
	Get
		Return _AuthoEnd
	End Get
	Set (ByVal value  as Date )
		_AuthoEnd = value
	End Set
End Property

Public Property Active()  as String
	Get
		Return _Active
	End Get
	Set (ByVal value  as String )
		_Active = value
	End Set
End Property

Public Property PayCat()  as String
	Get
		Return _PayCat
	End Get
	Set (ByVal value  as String )
		_PayCat = value
	End Set
End Property

Public Property CrAcctNu()  as String
	Get
		Return _CrAcctNu
	End Get
	Set (ByVal value  as String )
		_CrAcctNu = value
	End Set
End Property

Public Property DrAcctNu()  as String
	Get
		Return _DrAcctNu
	End Get
	Set (ByVal value  as String )
		_DrAcctNu = value
	End Set
End Property

Public Property CustKey()  as String
	Get
		Return _CustKey
	End Get
	Set (ByVal value  as String )
		_CustKey = value
	End Set
End Property

Public Property UnitRate()  as Decimal
	Get
		Return _UnitRate
	End Get
	Set (ByVal value  as Decimal )
		_UnitRate = value
	End Set
End Property

Public Property Credit()  as Decimal
	Get
		Return _Credit
	End Get
	Set (ByVal value  as Decimal )
		_Credit = value
	End Set
End Property

Public Property TieBrkNum()  as String
	Get
		Return _TieBrkNum
	End Get
	Set (ByVal value  as String )
		_TieBrkNum = value
	End Set
End Property

Public Property TieDesc()  as String
	Get
		Return _TieDesc
	End Get
	Set (ByVal value  as String )
		_TieDesc = value
	End Set
End Property

Public Property ServDesc()  as String
	Get
		Return _ServDesc
	End Get
	Set (ByVal value  as String )
		_ServDesc = value
	End Set
End Property

Public Property ProgDesc()  as String
	Get
		Return _ProgDesc
	End Get
	Set (ByVal value  as String )
		_ProgDesc = value
	End Set
End Property

Public Property Clothing()  as String
	Get
		Return _Clothing
	End Get
	Set (ByVal value  as String )
		_Clothing = value
	End Set
End Property

Public Property Status()  as String
	Get
		Return _Status
	End Get
	Set (ByVal value  as String )
		_Status = value
	End Set
End Property

Public Property Region()  as String
	Get
		Return _Region
	End Get
	Set (ByVal value  as String )
		_Region = value
	End Set
End Property

Public Property Area()  as String
	Get
		Return _Area
	End Get
	Set (ByVal value  as String )
		_Area = value
	End Set
End Property

Public Property Sw()  as String
	Get
		Return _Sw
	End Get
	Set (ByVal value  as String )
		_Sw = value
	End Set
End Property

Public Property ConPurNum()  as String
	Get
		Return _ConPurNum
	End Get
	Set (ByVal value  as String )
		_ConPurNum = value
	End Set
End Property

Public Property ConsNum()  as String
	Get
		Return _ConsNum
	End Get
	Set (ByVal value  as String )
		_ConsNum = value
	End Set
End Property

Public Property SwNameKey()  as String
	Get
		Return _SwNameKey
	End Get
	Set (ByVal value  as String )
		_SwNameKey = value
	End Set
End Property

Public Property EntryDate()  as Date
	Get
		Return _EntryDate
	End Get
	Set (ByVal value  as Date )
		_EntryDate = value
	End Set
End Property

Public Property Dflag()  as String
	Get
		Return _Dflag
	End Get
	Set (ByVal value  as String )
		_Dflag = value
	End Set
End Property

Public Property Agency()  as Integer
	Get
		Return _Agency
	End Get
	Set (ByVal value  as Integer )
		_Agency = value
	End Set
End Property


Public ReadOnly Property CashRctColumnNames() as string
		Get 
	              	              	              return "([BNum] , [NameKey] , [SortName] , [AuthoNum] , [ContractKey] , [AuthoBeg] , [AuthoEnd] , [Active] , [PayCat] , [CrAcctNu] , [DrAcctNu] , [CustKey] , [UnitRate] , [Credit] , [TieBrkNum] , [TieDesc] , [ServDesc] , [ProgDesc] , [Clothing] , [Status] , [Region] , [Area] , [Sw] , [ConPurNum] , [ConsNum] , [SwNameKey] , [EntryDate] , [Dflag] , [Agency] )"
		End Get
End Property

Public ReadOnly Property CashRctColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} )"  _  
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
