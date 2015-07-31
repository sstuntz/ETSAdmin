Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class CashRctData
	Private _BNum as String
	Private _NameKey as String
	Private _ContractKey as String
	Private _ScreenNam as String
	Private _SortName as String
	Private _AuthoNum as String
	Private _BillType as String
	Private _PvForm as String
	Private _RptType as String
	Private _UnitRate as Decimal
	Private _Offset as Decimal
	Private _SlotNum as Integer
	Private _NameChk as String
	Private _SsNum as String
	Private _MedNum as String
	Private _AttDate as Date
	Private _AttCode as String
	Private _AttUnit as Double
	Private _InvoiceDate as Date
	Private _Invoice as String
	Private _CustNum as String
	Private _DrAcctNu as String
	Private _CrAcctNu as String
	Private _EntryDate as Date
	Private _Dflag as String
	Private _Agency as Integer
	Private _Void as String
	Private _ClientPct as Double

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

Public Property ContractKey()  as String
	Get
		Return _ContractKey
	End Get
	Set (ByVal value  as String )
		_ContractKey = value
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

Public Property AuthoNum()  as String
	Get
		Return _AuthoNum
	End Get
	Set (ByVal value  as String )
		_AuthoNum = value
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

Public Property PvForm()  as String
	Get
		Return _PvForm
	End Get
	Set (ByVal value  as String )
		_PvForm = value
	End Set
End Property

Public Property RptType()  as String
	Get
		Return _RptType
	End Get
	Set (ByVal value  as String )
		_RptType = value
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

Public Property SsNum()  as String
	Get
		Return _SsNum
	End Get
	Set (ByVal value  as String )
		_SsNum = value
	End Set
End Property

Public Property MedNum()  as String
	Get
		Return _MedNum
	End Get
	Set (ByVal value  as String )
		_MedNum = value
	End Set
End Property

Public Property AttDate()  as Date
	Get
		Return _AttDate
	End Get
	Set (ByVal value  as Date )
		_AttDate = value
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

Public Property InvoiceDate()  as Date
	Get
		Return _InvoiceDate
	End Get
	Set (ByVal value  as Date )
		_InvoiceDate = value
	End Set
End Property

Public Property Invoice()  as String
	Get
		Return _Invoice
	End Get
	Set (ByVal value  as String )
		_Invoice = value
	End Set
End Property

Public Property CustNum()  as String
	Get
		Return _CustNum
	End Get
	Set (ByVal value  as String )
		_CustNum = value
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

Public Property Void()  as String
	Get
		Return _Void
	End Get
	Set (ByVal value  as String )
		_Void = value
	End Set
End Property

Public Property ClientPct()  as Double
	Get
		Return _ClientPct
	End Get
	Set (ByVal value  as Double )
		_ClientPct = value
	End Set
End Property


Public ReadOnly Property CashRctColumnNames() as string
		Get 
	              	              	              return "([BNum] , [NameKey] , [ContractKey] , [ScreenNam] , [SortName] , [AuthoNum] , [BillType] , [PvForm] , [RptType] , [UnitRate] , [Offset] , [SlotNum] , [NameChk] , [SsNum] , [MedNum] , [AttDate] , [AttCode] , [AttUnit] , [InvoiceDate] , [Invoice] , [CustNum] , [DrAcctNu] , [CrAcctNu] , [EntryDate] , [Dflag] , [Agency] , [Void] , [ClientPct] )"
		End Get
End Property

Public ReadOnly Property CashRctColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} )"  _  
	 , (_BNum) _ 
	 , (_NameKey) _ 
	 , (_ContractKey) _ 
	 , (_ScreenNam) _ 
	 , (_SortName) _ 
	 , (_AuthoNum) _ 
	 , (_BillType) _ 
	 , (_PvForm) _ 
	 , (_RptType) _ 
	 , (_UnitRate) _ 
	 , (_Offset) _ 
	 , (_SlotNum) _ 
	 , (_NameChk) _ 
	 , (_SsNum) _ 
	 , (_MedNum) _ 
	 , (_AttDate) _ 
	 , (_AttCode) _ 
	 , (_AttUnit) _ 
	 , (_InvoiceDate) _ 
	 , (_Invoice) _ 
	 , (_CustNum) _ 
	 , (_DrAcctNu) _ 
	 , (_CrAcctNu) _ 
	 , (_EntryDate) _ 
	 , (_Dflag) _ 
	 , (_Agency) _ 
	 , (_Void) _ 
	 , (_ClientPct) _ 
)
		End Get
End Property
End Class
