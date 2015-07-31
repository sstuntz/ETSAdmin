Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class CashRctData
	Private _ContractKey as String
	Private _ContIdNum as String
	Private _MmarsNum as String
	Private _AmendNum as String
	Private _EntryDate as Date
	Private _ContDesc as String
	Private _FiscalYr as String
	Private _Active as String
	Private _BillType as String
	Private _PvForm as String
	Private _RptType as String
	Private _UnitRate as Decimal
	Private _ContBegD as Date
	Private _ContEndD as Date
	Private _AmndBegD as Date
	Private _AmndEndD as Date
	Private _LastInvnum as String
	Private _LastBilldate as Date
	Private _ContOffset as Decimal
	Private _BillOffset as Decimal
	Private _DrAcctNu as String
	Private _CrAcctNu as String
	Private _NameKey as String
	Private _ScreenNam as String
	Private _ContUnits as Double
	Private _ContDol as Decimal
	Private _AmendUnits as Double
	Private _AmendDol as Decimal
	Private _MaxUnits as Double
	Private _MaxDol as Decimal
	Private _YtdUnits as Double
	Private _YtdDol as Decimal
	Private _SeedUnits as Double
	Private _SeedDol as Decimal
	Private _MonthUnits as Double
	Private _MonthDol as Decimal
	Private _RemUnits as Double
	Private _RemDol as Decimal
	Private _RedpyDol as Decimal
	Private _FlatRate as Decimal
	Private _Code1 as String
	Private _Code2 as String
	Private _Code3 as String
	Private _BeginDate as Date
	Private _EndDate as Date
	Private _NamkeyDss as String
	Private _PnumDss as String
	Private _NamkeySdr as String
	Private _PnumSdr as String
	Private _PrgnamSdr as String
	Private _PrgcodeSdr as String
	Private _PrgduraSdr as String
	Private _PrepBy as String
	Private _StateAgcy as String
	Private _ReimbType as String
	Private _Desc1 as String
	Private _Desc2 as String
	Private _Desc3 as String
	Private _NamkeyLea as String
	Private _PnumLea as String
	Private _PrgnamLea as String
	Private _PrgcodeLea as String
	Private _PrgduraLea as String
	Private _FedidNum as String
	Private _AnndaysSch as String
	Private _AnndaysRes as String
	Private _ProgType as String
	Private _LeaTerms as String
	Private _LeaComment as String
	Private _LeaOrderNu as String
	Private _Dflag as String
	Private _Agency as Integer
	Private _InvType as String
	Private _ProvNumMed as String
	Private _ProsNumMed as String
	Private _PlaceService as String
	Private _BillableCodes as String
	Private _InvString as String
	Private _ProgNum as String
	Private _DefInc as String
	Private _LifeAmend as String

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

Public Property ContDesc()  as String
	Get
		Return _ContDesc
	End Get
	Set (ByVal value  as String )
		_ContDesc = value
	End Set
End Property

Public Property FiscalYr()  as String
	Get
		Return _FiscalYr
	End Get
	Set (ByVal value  as String )
		_FiscalYr = value
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

Public Property ContBegD()  as Date
	Get
		Return _ContBegD
	End Get
	Set (ByVal value  as Date )
		_ContBegD = value
	End Set
End Property

Public Property ContEndD()  as Date
	Get
		Return _ContEndD
	End Get
	Set (ByVal value  as Date )
		_ContEndD = value
	End Set
End Property

Public Property AmndBegD()  as Date
	Get
		Return _AmndBegD
	End Get
	Set (ByVal value  as Date )
		_AmndBegD = value
	End Set
End Property

Public Property AmndEndD()  as Date
	Get
		Return _AmndEndD
	End Get
	Set (ByVal value  as Date )
		_AmndEndD = value
	End Set
End Property

Public Property LastInvnum()  as String
	Get
		Return _LastInvnum
	End Get
	Set (ByVal value  as String )
		_LastInvnum = value
	End Set
End Property

Public Property LastBilldate()  as Date
	Get
		Return _LastBilldate
	End Get
	Set (ByVal value  as Date )
		_LastBilldate = value
	End Set
End Property

Public Property ContOffset()  as Decimal
	Get
		Return _ContOffset
	End Get
	Set (ByVal value  as Decimal )
		_ContOffset = value
	End Set
End Property

Public Property BillOffset()  as Decimal
	Get
		Return _BillOffset
	End Get
	Set (ByVal value  as Decimal )
		_BillOffset = value
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

Public Property ContUnits()  as Double
	Get
		Return _ContUnits
	End Get
	Set (ByVal value  as Double )
		_ContUnits = value
	End Set
End Property

Public Property ContDol()  as Decimal
	Get
		Return _ContDol
	End Get
	Set (ByVal value  as Decimal )
		_ContDol = value
	End Set
End Property

Public Property AmendUnits()  as Double
	Get
		Return _AmendUnits
	End Get
	Set (ByVal value  as Double )
		_AmendUnits = value
	End Set
End Property

Public Property AmendDol()  as Decimal
	Get
		Return _AmendDol
	End Get
	Set (ByVal value  as Decimal )
		_AmendDol = value
	End Set
End Property

Public Property MaxUnits()  as Double
	Get
		Return _MaxUnits
	End Get
	Set (ByVal value  as Double )
		_MaxUnits = value
	End Set
End Property

Public Property MaxDol()  as Decimal
	Get
		Return _MaxDol
	End Get
	Set (ByVal value  as Decimal )
		_MaxDol = value
	End Set
End Property

Public Property YtdUnits()  as Double
	Get
		Return _YtdUnits
	End Get
	Set (ByVal value  as Double )
		_YtdUnits = value
	End Set
End Property

Public Property YtdDol()  as Decimal
	Get
		Return _YtdDol
	End Get
	Set (ByVal value  as Decimal )
		_YtdDol = value
	End Set
End Property

Public Property SeedUnits()  as Double
	Get
		Return _SeedUnits
	End Get
	Set (ByVal value  as Double )
		_SeedUnits = value
	End Set
End Property

Public Property SeedDol()  as Decimal
	Get
		Return _SeedDol
	End Get
	Set (ByVal value  as Decimal )
		_SeedDol = value
	End Set
End Property

Public Property MonthUnits()  as Double
	Get
		Return _MonthUnits
	End Get
	Set (ByVal value  as Double )
		_MonthUnits = value
	End Set
End Property

Public Property MonthDol()  as Decimal
	Get
		Return _MonthDol
	End Get
	Set (ByVal value  as Decimal )
		_MonthDol = value
	End Set
End Property

Public Property RemUnits()  as Double
	Get
		Return _RemUnits
	End Get
	Set (ByVal value  as Double )
		_RemUnits = value
	End Set
End Property

Public Property RemDol()  as Decimal
	Get
		Return _RemDol
	End Get
	Set (ByVal value  as Decimal )
		_RemDol = value
	End Set
End Property

Public Property RedpyDol()  as Decimal
	Get
		Return _RedpyDol
	End Get
	Set (ByVal value  as Decimal )
		_RedpyDol = value
	End Set
End Property

Public Property FlatRate()  as Decimal
	Get
		Return _FlatRate
	End Get
	Set (ByVal value  as Decimal )
		_FlatRate = value
	End Set
End Property

Public Property Code1()  as String
	Get
		Return _Code1
	End Get
	Set (ByVal value  as String )
		_Code1 = value
	End Set
End Property

Public Property Code2()  as String
	Get
		Return _Code2
	End Get
	Set (ByVal value  as String )
		_Code2 = value
	End Set
End Property

Public Property Code3()  as String
	Get
		Return _Code3
	End Get
	Set (ByVal value  as String )
		_Code3 = value
	End Set
End Property

Public Property BeginDate()  as Date
	Get
		Return _BeginDate
	End Get
	Set (ByVal value  as Date )
		_BeginDate = value
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

Public Property NamkeyDss()  as String
	Get
		Return _NamkeyDss
	End Get
	Set (ByVal value  as String )
		_NamkeyDss = value
	End Set
End Property

Public Property PnumDss()  as String
	Get
		Return _PnumDss
	End Get
	Set (ByVal value  as String )
		_PnumDss = value
	End Set
End Property

Public Property NamkeySdr()  as String
	Get
		Return _NamkeySdr
	End Get
	Set (ByVal value  as String )
		_NamkeySdr = value
	End Set
End Property

Public Property PnumSdr()  as String
	Get
		Return _PnumSdr
	End Get
	Set (ByVal value  as String )
		_PnumSdr = value
	End Set
End Property

Public Property PrgnamSdr()  as String
	Get
		Return _PrgnamSdr
	End Get
	Set (ByVal value  as String )
		_PrgnamSdr = value
	End Set
End Property

Public Property PrgcodeSdr()  as String
	Get
		Return _PrgcodeSdr
	End Get
	Set (ByVal value  as String )
		_PrgcodeSdr = value
	End Set
End Property

Public Property PrgduraSdr()  as String
	Get
		Return _PrgduraSdr
	End Get
	Set (ByVal value  as String )
		_PrgduraSdr = value
	End Set
End Property

Public Property PrepBy()  as String
	Get
		Return _PrepBy
	End Get
	Set (ByVal value  as String )
		_PrepBy = value
	End Set
End Property

Public Property StateAgcy()  as String
	Get
		Return _StateAgcy
	End Get
	Set (ByVal value  as String )
		_StateAgcy = value
	End Set
End Property

Public Property ReimbType()  as String
	Get
		Return _ReimbType
	End Get
	Set (ByVal value  as String )
		_ReimbType = value
	End Set
End Property

Public Property Desc1()  as String
	Get
		Return _Desc1
	End Get
	Set (ByVal value  as String )
		_Desc1 = value
	End Set
End Property

Public Property Desc2()  as String
	Get
		Return _Desc2
	End Get
	Set (ByVal value  as String )
		_Desc2 = value
	End Set
End Property

Public Property Desc3()  as String
	Get
		Return _Desc3
	End Get
	Set (ByVal value  as String )
		_Desc3 = value
	End Set
End Property

Public Property NamkeyLea()  as String
	Get
		Return _NamkeyLea
	End Get
	Set (ByVal value  as String )
		_NamkeyLea = value
	End Set
End Property

Public Property PnumLea()  as String
	Get
		Return _PnumLea
	End Get
	Set (ByVal value  as String )
		_PnumLea = value
	End Set
End Property

Public Property PrgnamLea()  as String
	Get
		Return _PrgnamLea
	End Get
	Set (ByVal value  as String )
		_PrgnamLea = value
	End Set
End Property

Public Property PrgcodeLea()  as String
	Get
		Return _PrgcodeLea
	End Get
	Set (ByVal value  as String )
		_PrgcodeLea = value
	End Set
End Property

Public Property PrgduraLea()  as String
	Get
		Return _PrgduraLea
	End Get
	Set (ByVal value  as String )
		_PrgduraLea = value
	End Set
End Property

Public Property FedidNum()  as String
	Get
		Return _FedidNum
	End Get
	Set (ByVal value  as String )
		_FedidNum = value
	End Set
End Property

Public Property AnndaysSch()  as String
	Get
		Return _AnndaysSch
	End Get
	Set (ByVal value  as String )
		_AnndaysSch = value
	End Set
End Property

Public Property AnndaysRes()  as String
	Get
		Return _AnndaysRes
	End Get
	Set (ByVal value  as String )
		_AnndaysRes = value
	End Set
End Property

Public Property ProgType()  as String
	Get
		Return _ProgType
	End Get
	Set (ByVal value  as String )
		_ProgType = value
	End Set
End Property

Public Property LeaTerms()  as String
	Get
		Return _LeaTerms
	End Get
	Set (ByVal value  as String )
		_LeaTerms = value
	End Set
End Property

Public Property LeaComment()  as String
	Get
		Return _LeaComment
	End Get
	Set (ByVal value  as String )
		_LeaComment = value
	End Set
End Property

Public Property LeaOrderNu()  as String
	Get
		Return _LeaOrderNu
	End Get
	Set (ByVal value  as String )
		_LeaOrderNu = value
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

Public Property InvType()  as String
	Get
		Return _InvType
	End Get
	Set (ByVal value  as String )
		_InvType = value
	End Set
End Property

Public Property ProvNumMed()  as String
	Get
		Return _ProvNumMed
	End Get
	Set (ByVal value  as String )
		_ProvNumMed = value
	End Set
End Property

Public Property ProsNumMed()  as String
	Get
		Return _ProsNumMed
	End Get
	Set (ByVal value  as String )
		_ProsNumMed = value
	End Set
End Property

Public Property PlaceService()  as String
	Get
		Return _PlaceService
	End Get
	Set (ByVal value  as String )
		_PlaceService = value
	End Set
End Property

Public Property BillableCodes()  as String
	Get
		Return _BillableCodes
	End Get
	Set (ByVal value  as String )
		_BillableCodes = value
	End Set
End Property

Public Property InvString()  as String
	Get
		Return _InvString
	End Get
	Set (ByVal value  as String )
		_InvString = value
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

Public Property DefInc()  as String
	Get
		Return _DefInc
	End Get
	Set (ByVal value  as String )
		_DefInc = value
	End Set
End Property

Public Property LifeAmend()  as String
	Get
		Return _LifeAmend
	End Get
	Set (ByVal value  as String )
		_LifeAmend = value
	End Set
End Property


Public ReadOnly Property CashRctColumnNames() as string
		Get 
	              	              	              return "([ContractKey] , [ContIdNum] , [MmarsNum] , [AmendNum] , [EntryDate] , [ContDesc] , [FiscalYr] , [Active] , [BillType] , [PvForm] , [RptType] , [UnitRate] , [ContBegD] , [ContEndD] , [AmndBegD] , [AmndEndD] , [LastInvnum] , [LastBilldate] , [ContOffset] , [BillOffset] , [DrAcctNu] , [CrAcctNu] , [NameKey] , [ScreenNam] , [ContUnits] , [ContDol] , [AmendUnits] , [AmendDol] , [MaxUnits] , [MaxDol] , [YtdUnits] , [YtdDol] , [SeedUnits] , [SeedDol] , [MonthUnits] , [MonthDol] , [RemUnits] , [RemDol] , [RedpyDol] , [FlatRate] , [Code1] , [Code2] , [Code3] , [BeginDate] , [EndDate] , [NamkeyDss] , [PnumDss] , [NamkeySdr] , [PnumSdr] , [PrgnamSdr] , [PrgcodeSdr] , [PrgduraSdr] , [PrepBy] , [StateAgcy] , [ReimbType] , [Desc1] , [Desc2] , [Desc3] , [NamkeyLea] , [PnumLea] , [PrgnamLea] , [PrgcodeLea] , [PrgduraLea] , [FedidNum] , [AnndaysSch] , [AnndaysRes] , [ProgType] , [LeaTerms] , [LeaComment] , [LeaOrderNu] , [Dflag] , [Agency] , [InvType] , [ProvNumMed] , [ProsNumMed] , [PlaceService] , [BillableCodes] , [InvString] , [ProgNum] , [DefInc] , [LifeAmend] )"
		End Get
End Property

Public ReadOnly Property CashRctColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} , {43} , {44} , {45} , {46} , {47} , {48} , {49} , {50} , {51} , {52} , {53} , {54} , {55} , {56} , {57} , {58} , {59} , {60} , {61} , {62} , {63} , {64} , {65} , {66} , {67} , {68} , {69} , {70} , {71} , {72} , {73} , {74} , {75} , {76} , {77} , {78} , {79} , {80} )"  _  
	 , (_ContractKey) _ 
	 , (_ContIdNum) _ 
	 , (_MmarsNum) _ 
	 , (_AmendNum) _ 
	 , (_EntryDate) _ 
	 , (_ContDesc) _ 
	 , (_FiscalYr) _ 
	 , (_Active) _ 
	 , (_BillType) _ 
	 , (_PvForm) _ 
	 , (_RptType) _ 
	 , (_UnitRate) _ 
	 , (_ContBegD) _ 
	 , (_ContEndD) _ 
	 , (_AmndBegD) _ 
	 , (_AmndEndD) _ 
	 , (_LastInvnum) _ 
	 , (_LastBilldate) _ 
	 , (_ContOffset) _ 
	 , (_BillOffset) _ 
	 , (_DrAcctNu) _ 
	 , (_CrAcctNu) _ 
	 , (_NameKey) _ 
	 , (_ScreenNam) _ 
	 , (_ContUnits) _ 
	 , (_ContDol) _ 
	 , (_AmendUnits) _ 
	 , (_AmendDol) _ 
	 , (_MaxUnits) _ 
	 , (_MaxDol) _ 
	 , (_YtdUnits) _ 
	 , (_YtdDol) _ 
	 , (_SeedUnits) _ 
	 , (_SeedDol) _ 
	 , (_MonthUnits) _ 
	 , (_MonthDol) _ 
	 , (_RemUnits) _ 
	 , (_RemDol) _ 
	 , (_RedpyDol) _ 
	 , (_FlatRate) _ 
	 , (_Code1) _ 
	 , (_Code2) _ 
	 , (_Code3) _ 
	 , (_BeginDate) _ 
	 , (_EndDate) _ 
	 , (_NamkeyDss) _ 
	 , (_PnumDss) _ 
	 , (_NamkeySdr) _ 
	 , (_PnumSdr) _ 
	 , (_PrgnamSdr) _ 
	 , (_PrgcodeSdr) _ 
	 , (_PrgduraSdr) _ 
	 , (_PrepBy) _ 
	 , (_StateAgcy) _ 
	 , (_ReimbType) _ 
	 , (_Desc1) _ 
	 , (_Desc2) _ 
	 , (_Desc3) _ 
	 , (_NamkeyLea) _ 
	 , (_PnumLea) _ 
	 , (_PrgnamLea) _ 
	 , (_PrgcodeLea) _ 
	 , (_PrgduraLea) _ 
	 , (_FedidNum) _ 
	 , (_AnndaysSch) _ 
	 , (_AnndaysRes) _ 
	 , (_ProgType) _ 
	 , (_LeaTerms) _ 
	 , (_LeaComment) _ 
	 , (_LeaOrderNu) _ 
	 , (_Dflag) _ 
	 , (_Agency) _ 
	 , (_InvType) _ 
	 , (_ProvNumMed) _ 
	 , (_ProsNumMed) _ 
	 , (_PlaceService) _ 
	 , (_BillableCodes) _ 
	 , (_InvString) _ 
	 , (_ProgNum) _ 
	 , (_DefInc) _ 
	 , (_LifeAmend) _ 
)
		End Get
End Property
End Class
