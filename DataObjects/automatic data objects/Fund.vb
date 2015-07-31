Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class CashRctData
	Private _BNum as String
	Private _NameKey as String
	Private _ScreenNam as String
	Private _SortName as String
	Private _ContractKey as String
	Private _ContIdNum as String
	Private _MmarsNum as String
	Private _AmendNum as String
	Private _EntryDate as Date
	Private _Closed as String
	Private _BillDate as Date
	Private _ClientTotal as Decimal
	Private _Dflag as String
	Private _Agency as Integer
	Private _BillType as String
	Private _BegDate as Date
	Private _EndDate as Date
	Private _Active as String
	Private _SlotNum as Integer
	Private _NameChk as String
	Private _AttCode as String
	Private _AttUnit as Double
	Private _ProgNum as String
	Private _UnitRate as Decimal
	Private _Offset as Decimal
	Private _Mon as String
	Private _Tue as String
	Private _Wed as String
	Private _Thu as String
	Private _Fri as String
	Private _Sat as String
	Private _Sun as String
	Private _Type as String
	Private _DrAcctNu as String
	Private _CrAcctNu as String
	Private _RefProvNum as String
	Private _MedSource as String
	Private _BudAmt as Decimal
	Private _SpecAmt as Decimal

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

Public Property ScreenNam()  as String
	Get
		Return _ScreenNam
	End Get
	Set (ByVal value  as String )
		_ScreenNam = value
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

Public Property ContractKey()  as String
	Get
		Return _ContractKey
	End Get
	Set (ByVal value  as String )
		_ContractKey = value
	End Set
End Property

Public Property ContIdNum()  as String
	Get
		Return _ContIdNum
	End Get
	Set (ByVal value  as String )
		_ContIdNum = value
	End Set
End Property

Public Property MmarsNum()  as String
	Get
		Return _MmarsNum
	End Get
	Set (ByVal value  as String )
		_MmarsNum = value
	End Set
End Property

Public Property AmendNum()  as String
	Get
		Return _AmendNum
	End Get
	Set (ByVal value  as String )
		_AmendNum = value
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

Public Property Closed()  as String
	Get
		Return _Closed
	End Get
	Set (ByVal value  as String )
		_Closed = value
	End Set
End Property

Public Property BillDate()  as Date
	Get
		Return _BillDate
	End Get
	Set (ByVal value  as Date )
		_BillDate = value
	End Set
End Property

Public Property ClientTotal()  as Decimal
	Get
		Return _ClientTotal
	End Get
	Set (ByVal value  as Decimal )
		_ClientTotal = value
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

Public Property BillType()  as String
	Get
		Return _BillType
	End Get
	Set (ByVal value  as String )
		_BillType = value
	End Set
End Property

Public Property BegDate()  as Date
	Get
		Return _BegDate
	End Get
	Set (ByVal value  as Date )
		_BegDate = value
	End Set
End Property

Public Property EndDate()  as Date
	Get
		Return _EndDate
	End Get
	Set (ByVal value  as Date )
		_EndDate = value
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

Public Property SlotNum()  as Integer
	Get
		Return _SlotNum
	End Get
	Set (ByVal value  as Integer )
		_SlotNum = value
	End Set
End Property

Public Property NameChk()  as String
	Get
		Return _NameChk
	End Get
	Set (ByVal value  as String )
		_NameChk = value
	End Set
End Property

Public Property AttCode()  as String
	Get
		Return _AttCode
	End Get
	Set (ByVal value  as String )
		_AttCode = value
	End Set
End Property

Public Property AttUnit()  as Double
	Get
		Return _AttUnit
	End Get
	Set (ByVal value  as Double )
		_AttUnit = value
	End Set
End Property

Public Property ProgNum()  as String
	Get
		Return _ProgNum
	End Get
	Set (ByVal value  as String )
		_ProgNum = value
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

Public Property Offset()  as Decimal
	Get
		Return _Offset
	End Get
	Set (ByVal value  as Decimal )
		_Offset = value
	End Set
End Property

Public Property Mon()  as String
	Get
		Return _Mon
	End Get
	Set (ByVal value  as String )
		_Mon = value
	End Set
End Property

Public Property Tue()  as String
	Get
		Return _Tue
	End Get
	Set (ByVal value  as String )
		_Tue = value
	End Set
End Property

Public Property Wed()  as String
	Get
		Return _Wed
	End Get
	Set (ByVal value  as String )
		_Wed = value
	End Set
End Property

Public Property Thu()  as String
	Get
		Return _Thu
	End Get
	Set (ByVal value  as String )
		_Thu = value
	End Set
End Property

Public Property Fri()  as String
	Get
		Return _Fri
	End Get
	Set (ByVal value  as String )
		_Fri = value
	End Set
End Property

Public Property Sat()  as String
	Get
		Return _Sat
	End Get
	Set (ByVal value  as String )
		_Sat = value
	End Set
End Property

Public Property Sun()  as String
	Get
		Return _Sun
	End Get
	Set (ByVal value  as String )
		_Sun = value
	End Set
End Property

Public Property Type()  as String
	Get
		Return _Type
	End Get
	Set (ByVal value  as String )
		_Type = value
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

Public Property CrAcctNu()  as String
	Get
		Return _CrAcctNu
	End Get
	Set (ByVal value  as String )
		_CrAcctNu = value
	End Set
End Property

Public Property RefProvNum()  as String
	Get
		Return _RefProvNum
	End Get
	Set (ByVal value  as String )
		_RefProvNum = value
	End Set
End Property

Public Property MedSource()  as String
	Get
		Return _MedSource
	End Get
	Set (ByVal value  as String )
		_MedSource = value
	End Set
End Property

Public Property BudAmt()  as Decimal
	Get
		Return _BudAmt
	End Get
	Set (ByVal value  as Decimal )
		_BudAmt = value
	End Set
End Property

Public Property SpecAmt()  as Decimal
	Get
		Return _SpecAmt
	End Get
	Set (ByVal value  as Decimal )
		_SpecAmt = value
	End Set
End Property


Public ReadOnly Property CashRctColumnNames() as string
		Get 
	              	              	              return "([BNum] , [NameKey] , [ScreenNam] , [SortName] , [ContractKey] , [ContIdNum] , [MmarsNum] , [AmendNum] , [EntryDate] , [Closed] , [BillDate] , [ClientTotal] , [Dflag] , [Agency] , [BillType] , [BegDate] , [EndDate] , [Active] , [SlotNum] , [NameChk] , [AttCode] , [AttUnit] , [ProgNum] , [UnitRate] , [Offset] , [Mon] , [Tue] , [Wed] , [Thu] , [Fri] , [Sat] , [Sun] , [Type] , [DrAcctNu] , [CrAcctNu] , [RefProvNum] , [MedSource] , [BudAmt] , [SpecAmt] )"
		End Get
End Property

Public ReadOnly Property CashRctColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} )"  _  
	 , (_BNum) _ 
	 , (_NameKey) _ 
	 , (_ScreenNam) _ 
	 , (_SortName) _ 
	 , (_ContractKey) _ 
	 , (_ContIdNum) _ 
	 , (_MmarsNum) _ 
	 , (_AmendNum) _ 
	 , (_EntryDate) _ 
	 , (_Closed) _ 
	 , (_BillDate) _ 
	 , (_ClientTotal) _ 
	 , (_Dflag) _ 
	 , (_Agency) _ 
	 , (_BillType) _ 
	 , (_BegDate) _ 
	 , (_EndDate) _ 
	 , (_Active) _ 
	 , (_SlotNum) _ 
	 , (_NameChk) _ 
	 , (_AttCode) _ 
	 , (_AttUnit) _ 
	 , (_ProgNum) _ 
	 , (_UnitRate) _ 
	 , (_Offset) _ 
	 , (_Mon) _ 
	 , (_Tue) _ 
	 , (_Wed) _ 
	 , (_Thu) _ 
	 , (_Fri) _ 
	 , (_Sat) _ 
	 , (_Sun) _ 
	 , (_Type) _ 
	 , (_DrAcctNu) _ 
	 , (_CrAcctNu) _ 
	 , (_RefProvNum) _ 
	 , (_MedSource) _ 
	 , (_BudAmt) _ 
	 , (_SpecAmt) _ 
)
		End Get
End Property
End Class
