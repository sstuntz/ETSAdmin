Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class nam_eeData
	Private _NameKey as String
	Private _ScreenNam as String
	Private _SsNum as String
	Private _HireDate as Date
	Private _TermDate as Date
	Private _AnnivMo as String
	Private _DeptNum as String
	Private _SlotNum as String
	Private _LocNum as String
	Private _CostNum as String
	Private _SupNum as String
	Private _TitleNum as String
	Private _JobTitle as String
	Private _WcNum as String
	Private _WcRate as Decimal
	Private _FicaExmt as String
	Private _AeicElig as String
	Private _FileStatus as String
	Private _PayFreq as String
	Private _FwtExmts as Integer
	Private _SwtExmts as Integer
	Private _HrlySal as String
	Private _RegHrs as Double
	Private _AnnSal as Decimal
	Private _State1Tax as String
	Private _State2Tax as String
	Private _DolRatea as Decimal
	Private _DolRateb as Decimal
	Private _DolRatec as Decimal
	Private _DolRated as Decimal
	Private _DolRatee as Decimal
	Private _DolRatef as Decimal
	Private _DolRateg as Decimal
	Private _DolRateh as Decimal
	Private _DolRatei as Decimal
	Private _DolRatej as Decimal
	Private _AddFwt as Decimal
	Private _AddfwtDfq as String
	Private _AddSwt as Decimal
	Private _AddswtDfq as String
	Private _ANtNum as String
	Private _ANtDol as Decimal
	Private _ANtDfq as String
	Private _BNtNum as String
	Private _BNtDol as Decimal
	Private _BNtDfq as String
	Private _CNtNum as String
	Private _CNtDol as Decimal
	Private _CNtDfq as String
	Private _DNtNum as String
	Private _DNtDol as Decimal
	Private _DNtDfq as String
	Private _ENtNum as String
	Private _ENtDol as Decimal
	Private _ENtDfq as String
	Private _FlxNtNum as String
	Private _FlxNtDol as Decimal
	Private _FlxNtDfq as String
	Private _DepNtNum as String
	Private _DepNtDol as Decimal
	Private _DepNtDfq as String
	Private _Pen1aNum as String
	Private _Pen1aDol as Decimal
	Private _Pen1aPct as Double
	Private _Pen1aDfq as String
	Private _Pen1bNum as String
	Private _Pen1bDol as Decimal
	Private _Pen1bPct as Double
	Private _Pen1bDfq as String
	Private _Pen2aNum as String
	Private _Pen2aDol as Decimal
	Private _Pen2aPct as Double
	Private _Pen2aDfq as String
	Private _Pen2bNum as String
	Private _Pen2bDol as Decimal
	Private _Pen2bPct as Double
	Private _Pen2bDfq as String
	Private _DdepDfq as String
	Private _DdepNet as String
	Private _Save1Num as String
	Private _Save1Dol as Decimal
	Private _Save1Dfq as String
	Private _Ddep1Sav1 as String
	Private _Save2Num as String
	Private _Save2Dol as Decimal
	Private _Save2Dfq as String
	Private _Ddep2Sav2 as String
	Private _Save3Num as String
	Private _Save3Dol as Decimal
	Private _Save3Dfq as String
	Private _Ddep3Sav3 as String
	Private _Dduct1Num as String
	Private _Dduct1Dol as Decimal
	Private _Dduct1Dfq as String
	Private _Dduct2Num as String
	Private _Dduct2Dol as Decimal
	Private _Dduct2Dfq as String
	Private _Dduct3Num as String
	Private _Dduct3Dol as Decimal
	Private _Dduct3Dfq as String
	Private _Dduct4Num as String
	Private _Dduct4Dol as Decimal
	Private _Dduct4Dfq as String
	Private _Dduct5Num as String
	Private _Dduct5Dol as Decimal
	Private _Dduct5Dfq as String
	Private _Dduct6Num as String
	Private _Dduct6Dol as Decimal
	Private _Dduct6Dfq as String
	Private _Dduct7Num as String
	Private _Dduct7Dol as Decimal
	Private _Dduct7Dfq as String
	Private _Dduct8Num as String
	Private _Dduct8Dol as Decimal
	Private _Dduct8Dfq as String
	Private _Dduct9Num as String
	Private _Dduct9Dol as Decimal
	Private _Dduct9Dfq as String
	Private _Misc1Num as String
	Private _Misc1Dol as Decimal
	Private _Misc1Dfq as String
	Private _Misc2Num as String
	Private _Misc2Dol as Decimal
	Private _Misc2Dfq as String
	Private _Agency as Integer
	Private _Dflag as String
	Private _MedExmt as String
	Private _SortName as String
	Private _BeeperNum as String

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

Public Property SsNum()  as String
	Get
		Return _SsNum
	End Get
	Set (ByVal value  as String )
		_SsNum = value
	End Set
End Property

Public Property HireDate()  as Date
	Get
		Return _HireDate
	End Get
	Set (ByVal value  as Date )
		_HireDate = value
	End Set
End Property

Public Property TermDate()  as Date
	Get
		Return _TermDate
	End Get
	Set (ByVal value  as Date )
		_TermDate = value
	End Set
End Property

Public Property AnnivMo()  as String
	Get
		Return _AnnivMo
	End Get
	Set (ByVal value  as String )
		_AnnivMo = value
	End Set
End Property

Public Property DeptNum()  as String
	Get
		Return _DeptNum
	End Get
	Set (ByVal value  as String )
		_DeptNum = value
	End Set
End Property

Public Property SlotNum()  as String
	Get
		Return _SlotNum
	End Get
	Set (ByVal value  as String )
		_SlotNum = value
	End Set
End Property

Public Property LocNum()  as String
	Get
		Return _LocNum
	End Get
	Set (ByVal value  as String )
		_LocNum = value
	End Set
End Property

Public Property CostNum()  as String
	Get
		Return _CostNum
	End Get
	Set (ByVal value  as String )
		_CostNum = value
	End Set
End Property

Public Property SupNum()  as String
	Get
		Return _SupNum
	End Get
	Set (ByVal value  as String )
		_SupNum = value
	End Set
End Property

Public Property TitleNum()  as String
	Get
		Return _TitleNum
	End Get
	Set (ByVal value  as String )
		_TitleNum = value
	End Set
End Property

Public Property JobTitle()  as String
	Get
		Return _JobTitle
	End Get
	Set (ByVal value  as String )
		_JobTitle = value
	End Set
End Property

Public Property WcNum()  as String
	Get
		Return _WcNum
	End Get
	Set (ByVal value  as String )
		_WcNum = value
	End Set
End Property

Public Property WcRate()  as Decimal
	Get
		Return _WcRate
	End Get
	Set (ByVal value  as Decimal )
		_WcRate = value
	End Set
End Property

Public Property FicaExmt()  as String
	Get
		Return _FicaExmt
	End Get
	Set (ByVal value  as String )
		_FicaExmt = value
	End Set
End Property

Public Property AeicElig()  as String
	Get
		Return _AeicElig
	End Get
	Set (ByVal value  as String )
		_AeicElig = value
	End Set
End Property

Public Property FileStatus()  as String
	Get
		Return _FileStatus
	End Get
	Set (ByVal value  as String )
		_FileStatus = value
	End Set
End Property

Public Property PayFreq()  as String
	Get
		Return _PayFreq
	End Get
	Set (ByVal value  as String )
		_PayFreq = value
	End Set
End Property

Public Property FwtExmts()  as Integer
	Get
		Return _FwtExmts
	End Get
	Set (ByVal value  as Integer )
		_FwtExmts = value
	End Set
End Property

Public Property SwtExmts()  as Integer
	Get
		Return _SwtExmts
	End Get
	Set (ByVal value  as Integer )
		_SwtExmts = value
	End Set
End Property

Public Property HrlySal()  as String
	Get
		Return _HrlySal
	End Get
	Set (ByVal value  as String )
		_HrlySal = value
	End Set
End Property

Public Property RegHrs()  as Double
	Get
		Return _RegHrs
	End Get
	Set (ByVal value  as Double )
		_RegHrs = value
	End Set
End Property

Public Property AnnSal()  as Decimal
	Get
		Return _AnnSal
	End Get
	Set (ByVal value  as Decimal )
		_AnnSal = value
	End Set
End Property

Public Property State1Tax()  as String
	Get
		Return _State1Tax
	End Get
	Set (ByVal value  as String )
		_State1Tax = value
	End Set
End Property

Public Property State2Tax()  as String
	Get
		Return _State2Tax
	End Get
	Set (ByVal value  as String )
		_State2Tax = value
	End Set
End Property

Public Property DolRatea()  as Decimal
	Get
		Return _DolRatea
	End Get
	Set (ByVal value  as Decimal )
		_DolRatea = value
	End Set
End Property

Public Property DolRateb()  as Decimal
	Get
		Return _DolRateb
	End Get
	Set (ByVal value  as Decimal )
		_DolRateb = value
	End Set
End Property

Public Property DolRatec()  as Decimal
	Get
		Return _DolRatec
	End Get
	Set (ByVal value  as Decimal )
		_DolRatec = value
	End Set
End Property

Public Property DolRated()  as Decimal
	Get
		Return _DolRated
	End Get
	Set (ByVal value  as Decimal )
		_DolRated = value
	End Set
End Property

Public Property DolRatee()  as Decimal
	Get
		Return _DolRatee
	End Get
	Set (ByVal value  as Decimal )
		_DolRatee = value
	End Set
End Property

Public Property DolRatef()  as Decimal
	Get
		Return _DolRatef
	End Get
	Set (ByVal value  as Decimal )
		_DolRatef = value
	End Set
End Property

Public Property DolRateg()  as Decimal
	Get
		Return _DolRateg
	End Get
	Set (ByVal value  as Decimal )
		_DolRateg = value
	End Set
End Property

Public Property DolRateh()  as Decimal
	Get
		Return _DolRateh
	End Get
	Set (ByVal value  as Decimal )
		_DolRateh = value
	End Set
End Property

Public Property DolRatei()  as Decimal
	Get
		Return _DolRatei
	End Get
	Set (ByVal value  as Decimal )
		_DolRatei = value
	End Set
End Property

Public Property DolRatej()  as Decimal
	Get
		Return _DolRatej
	End Get
	Set (ByVal value  as Decimal )
		_DolRatej = value
	End Set
End Property

Public Property AddFwt()  as Decimal
	Get
		Return _AddFwt
	End Get
	Set (ByVal value  as Decimal )
		_AddFwt = value
	End Set
End Property

Public Property AddfwtDfq()  as String
	Get
		Return _AddfwtDfq
	End Get
	Set (ByVal value  as String )
		_AddfwtDfq = value
	End Set
End Property

Public Property AddSwt()  as Decimal
	Get
		Return _AddSwt
	End Get
	Set (ByVal value  as Decimal )
		_AddSwt = value
	End Set
End Property

Public Property AddswtDfq()  as String
	Get
		Return _AddswtDfq
	End Get
	Set (ByVal value  as String )
		_AddswtDfq = value
	End Set
End Property

Public Property ANtNum()  as String
	Get
		Return _ANtNum
	End Get
	Set (ByVal value  as String )
		_ANtNum = value
	End Set
End Property

Public Property ANtDol()  as Decimal
	Get
		Return _ANtDol
	End Get
	Set (ByVal value  as Decimal )
		_ANtDol = value
	End Set
End Property

Public Property ANtDfq()  as String
	Get
		Return _ANtDfq
	End Get
	Set (ByVal value  as String )
		_ANtDfq = value
	End Set
End Property

Public Property BNtNum()  as String
	Get
		Return _BNtNum
	End Get
	Set (ByVal value  as String )
		_BNtNum = value
	End Set
End Property

Public Property BNtDol()  as Decimal
	Get
		Return _BNtDol
	End Get
	Set (ByVal value  as Decimal )
		_BNtDol = value
	End Set
End Property

Public Property BNtDfq()  as String
	Get
		Return _BNtDfq
	End Get
	Set (ByVal value  as String )
		_BNtDfq = value
	End Set
End Property

Public Property CNtNum()  as String
	Get
		Return _CNtNum
	End Get
	Set (ByVal value  as String )
		_CNtNum = value
	End Set
End Property

Public Property CNtDol()  as Decimal
	Get
		Return _CNtDol
	End Get
	Set (ByVal value  as Decimal )
		_CNtDol = value
	End Set
End Property

Public Property CNtDfq()  as String
	Get
		Return _CNtDfq
	End Get
	Set (ByVal value  as String )
		_CNtDfq = value
	End Set
End Property

Public Property DNtNum()  as String
	Get
		Return _DNtNum
	End Get
	Set (ByVal value  as String )
		_DNtNum = value
	End Set
End Property

Public Property DNtDol()  as Decimal
	Get
		Return _DNtDol
	End Get
	Set (ByVal value  as Decimal )
		_DNtDol = value
	End Set
End Property

Public Property DNtDfq()  as String
	Get
		Return _DNtDfq
	End Get
	Set (ByVal value  as String )
		_DNtDfq = value
	End Set
End Property

Public Property ENtNum()  as String
	Get
		Return _ENtNum
	End Get
	Set (ByVal value  as String )
		_ENtNum = value
	End Set
End Property

Public Property ENtDol()  as Decimal
	Get
		Return _ENtDol
	End Get
	Set (ByVal value  as Decimal )
		_ENtDol = value
	End Set
End Property

Public Property ENtDfq()  as String
	Get
		Return _ENtDfq
	End Get
	Set (ByVal value  as String )
		_ENtDfq = value
	End Set
End Property

Public Property FlxNtNum()  as String
	Get
		Return _FlxNtNum
	End Get
	Set (ByVal value  as String )
		_FlxNtNum = value
	End Set
End Property

Public Property FlxNtDol()  as Decimal
	Get
		Return _FlxNtDol
	End Get
	Set (ByVal value  as Decimal )
		_FlxNtDol = value
	End Set
End Property

Public Property FlxNtDfq()  as String
	Get
		Return _FlxNtDfq
	End Get
	Set (ByVal value  as String )
		_FlxNtDfq = value
	End Set
End Property

Public Property DepNtNum()  as String
	Get
		Return _DepNtNum
	End Get
	Set (ByVal value  as String )
		_DepNtNum = value
	End Set
End Property

Public Property DepNtDol()  as Decimal
	Get
		Return _DepNtDol
	End Get
	Set (ByVal value  as Decimal )
		_DepNtDol = value
	End Set
End Property

Public Property DepNtDfq()  as String
	Get
		Return _DepNtDfq
	End Get
	Set (ByVal value  as String )
		_DepNtDfq = value
	End Set
End Property

Public Property Pen1aNum()  as String
	Get
		Return _Pen1aNum
	End Get
	Set (ByVal value  as String )
		_Pen1aNum = value
	End Set
End Property

Public Property Pen1aDol()  as Decimal
	Get
		Return _Pen1aDol
	End Get
	Set (ByVal value  as Decimal )
		_Pen1aDol = value
	End Set
End Property

Public Property Pen1aPct()  as Double
	Get
		Return _Pen1aPct
	End Get
	Set (ByVal value  as Double )
		_Pen1aPct = value
	End Set
End Property

Public Property Pen1aDfq()  as String
	Get
		Return _Pen1aDfq
	End Get
	Set (ByVal value  as String )
		_Pen1aDfq = value
	End Set
End Property

Public Property Pen1bNum()  as String
	Get
		Return _Pen1bNum
	End Get
	Set (ByVal value  as String )
		_Pen1bNum = value
	End Set
End Property

Public Property Pen1bDol()  as Decimal
	Get
		Return _Pen1bDol
	End Get
	Set (ByVal value  as Decimal )
		_Pen1bDol = value
	End Set
End Property

Public Property Pen1bPct()  as Double
	Get
		Return _Pen1bPct
	End Get
	Set (ByVal value  as Double )
		_Pen1bPct = value
	End Set
End Property

Public Property Pen1bDfq()  as String
	Get
		Return _Pen1bDfq
	End Get
	Set (ByVal value  as String )
		_Pen1bDfq = value
	End Set
End Property

Public Property Pen2aNum()  as String
	Get
		Return _Pen2aNum
	End Get
	Set (ByVal value  as String )
		_Pen2aNum = value
	End Set
End Property

Public Property Pen2aDol()  as Decimal
	Get
		Return _Pen2aDol
	End Get
	Set (ByVal value  as Decimal )
		_Pen2aDol = value
	End Set
End Property

Public Property Pen2aPct()  as Double
	Get
		Return _Pen2aPct
	End Get
	Set (ByVal value  as Double )
		_Pen2aPct = value
	End Set
End Property

Public Property Pen2aDfq()  as String
	Get
		Return _Pen2aDfq
	End Get
	Set (ByVal value  as String )
		_Pen2aDfq = value
	End Set
End Property

Public Property Pen2bNum()  as String
	Get
		Return _Pen2bNum
	End Get
	Set (ByVal value  as String )
		_Pen2bNum = value
	End Set
End Property

Public Property Pen2bDol()  as Decimal
	Get
		Return _Pen2bDol
	End Get
	Set (ByVal value  as Decimal )
		_Pen2bDol = value
	End Set
End Property

Public Property Pen2bPct()  as Double
	Get
		Return _Pen2bPct
	End Get
	Set (ByVal value  as Double )
		_Pen2bPct = value
	End Set
End Property

Public Property Pen2bDfq()  as String
	Get
		Return _Pen2bDfq
	End Get
	Set (ByVal value  as String )
		_Pen2bDfq = value
	End Set
End Property

Public Property DdepDfq()  as String
	Get
		Return _DdepDfq
	End Get
	Set (ByVal value  as String )
		_DdepDfq = value
	End Set
End Property

Public Property DdepNet()  as String
	Get
		Return _DdepNet
	End Get
	Set (ByVal value  as String )
		_DdepNet = value
	End Set
End Property

Public Property Save1Num()  as String
	Get
		Return _Save1Num
	End Get
	Set (ByVal value  as String )
		_Save1Num = value
	End Set
End Property

Public Property Save1Dol()  as Decimal
	Get
		Return _Save1Dol
	End Get
	Set (ByVal value  as Decimal )
		_Save1Dol = value
	End Set
End Property

Public Property Save1Dfq()  as String
	Get
		Return _Save1Dfq
	End Get
	Set (ByVal value  as String )
		_Save1Dfq = value
	End Set
End Property

Public Property Ddep1Sav1()  as String
	Get
		Return _Ddep1Sav1
	End Get
	Set (ByVal value  as String )
		_Ddep1Sav1 = value
	End Set
End Property

Public Property Save2Num()  as String
	Get
		Return _Save2Num
	End Get
	Set (ByVal value  as String )
		_Save2Num = value
	End Set
End Property

Public Property Save2Dol()  as Decimal
	Get
		Return _Save2Dol
	End Get
	Set (ByVal value  as Decimal )
		_Save2Dol = value
	End Set
End Property

Public Property Save2Dfq()  as String
	Get
		Return _Save2Dfq
	End Get
	Set (ByVal value  as String )
		_Save2Dfq = value
	End Set
End Property

Public Property Ddep2Sav2()  as String
	Get
		Return _Ddep2Sav2
	End Get
	Set (ByVal value  as String )
		_Ddep2Sav2 = value
	End Set
End Property

Public Property Save3Num()  as String
	Get
		Return _Save3Num
	End Get
	Set (ByVal value  as String )
		_Save3Num = value
	End Set
End Property

Public Property Save3Dol()  as Decimal
	Get
		Return _Save3Dol
	End Get
	Set (ByVal value  as Decimal )
		_Save3Dol = value
	End Set
End Property

Public Property Save3Dfq()  as String
	Get
		Return _Save3Dfq
	End Get
	Set (ByVal value  as String )
		_Save3Dfq = value
	End Set
End Property

Public Property Ddep3Sav3()  as String
	Get
		Return _Ddep3Sav3
	End Get
	Set (ByVal value  as String )
		_Ddep3Sav3 = value
	End Set
End Property

Public Property Dduct1Num()  as String
	Get
		Return _Dduct1Num
	End Get
	Set (ByVal value  as String )
		_Dduct1Num = value
	End Set
End Property

Public Property Dduct1Dol()  as Decimal
	Get
		Return _Dduct1Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct1Dol = value
	End Set
End Property

Public Property Dduct1Dfq()  as String
	Get
		Return _Dduct1Dfq
	End Get
	Set (ByVal value  as String )
		_Dduct1Dfq = value
	End Set
End Property

Public Property Dduct2Num()  as String
	Get
		Return _Dduct2Num
	End Get
	Set (ByVal value  as String )
		_Dduct2Num = value
	End Set
End Property

Public Property Dduct2Dol()  as Decimal
	Get
		Return _Dduct2Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct2Dol = value
	End Set
End Property

Public Property Dduct2Dfq()  as String
	Get
		Return _Dduct2Dfq
	End Get
	Set (ByVal value  as String )
		_Dduct2Dfq = value
	End Set
End Property

Public Property Dduct3Num()  as String
	Get
		Return _Dduct3Num
	End Get
	Set (ByVal value  as String )
		_Dduct3Num = value
	End Set
End Property

Public Property Dduct3Dol()  as Decimal
	Get
		Return _Dduct3Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct3Dol = value
	End Set
End Property

Public Property Dduct3Dfq()  as String
	Get
		Return _Dduct3Dfq
	End Get
	Set (ByVal value  as String )
		_Dduct3Dfq = value
	End Set
End Property

Public Property Dduct4Num()  as String
	Get
		Return _Dduct4Num
	End Get
	Set (ByVal value  as String )
		_Dduct4Num = value
	End Set
End Property

Public Property Dduct4Dol()  as Decimal
	Get
		Return _Dduct4Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct4Dol = value
	End Set
End Property

Public Property Dduct4Dfq()  as String
	Get
		Return _Dduct4Dfq
	End Get
	Set (ByVal value  as String )
		_Dduct4Dfq = value
	End Set
End Property

Public Property Dduct5Num()  as String
	Get
		Return _Dduct5Num
	End Get
	Set (ByVal value  as String )
		_Dduct5Num = value
	End Set
End Property

Public Property Dduct5Dol()  as Decimal
	Get
		Return _Dduct5Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct5Dol = value
	End Set
End Property

Public Property Dduct5Dfq()  as String
	Get
		Return _Dduct5Dfq
	End Get
	Set (ByVal value  as String )
		_Dduct5Dfq = value
	End Set
End Property

Public Property Dduct6Num()  as String
	Get
		Return _Dduct6Num
	End Get
	Set (ByVal value  as String )
		_Dduct6Num = value
	End Set
End Property

Public Property Dduct6Dol()  as Decimal
	Get
		Return _Dduct6Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct6Dol = value
	End Set
End Property

Public Property Dduct6Dfq()  as String
	Get
		Return _Dduct6Dfq
	End Get
	Set (ByVal value  as String )
		_Dduct6Dfq = value
	End Set
End Property

Public Property Dduct7Num()  as String
	Get
		Return _Dduct7Num
	End Get
	Set (ByVal value  as String )
		_Dduct7Num = value
	End Set
End Property

Public Property Dduct7Dol()  as Decimal
	Get
		Return _Dduct7Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct7Dol = value
	End Set
End Property

Public Property Dduct7Dfq()  as String
	Get
		Return _Dduct7Dfq
	End Get
	Set (ByVal value  as String )
		_Dduct7Dfq = value
	End Set
End Property

Public Property Dduct8Num()  as String
	Get
		Return _Dduct8Num
	End Get
	Set (ByVal value  as String )
		_Dduct8Num = value
	End Set
End Property

Public Property Dduct8Dol()  as Decimal
	Get
		Return _Dduct8Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct8Dol = value
	End Set
End Property

Public Property Dduct8Dfq()  as String
	Get
		Return _Dduct8Dfq
	End Get
	Set (ByVal value  as String )
		_Dduct8Dfq = value
	End Set
End Property

Public Property Dduct9Num()  as String
	Get
		Return _Dduct9Num
	End Get
	Set (ByVal value  as String )
		_Dduct9Num = value
	End Set
End Property

Public Property Dduct9Dol()  as Decimal
	Get
		Return _Dduct9Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct9Dol = value
	End Set
End Property

Public Property Dduct9Dfq()  as String
	Get
		Return _Dduct9Dfq
	End Get
	Set (ByVal value  as String )
		_Dduct9Dfq = value
	End Set
End Property

Public Property Misc1Num()  as String
	Get
		Return _Misc1Num
	End Get
	Set (ByVal value  as String )
		_Misc1Num = value
	End Set
End Property

Public Property Misc1Dol()  as Decimal
	Get
		Return _Misc1Dol
	End Get
	Set (ByVal value  as Decimal )
		_Misc1Dol = value
	End Set
End Property

Public Property Misc1Dfq()  as String
	Get
		Return _Misc1Dfq
	End Get
	Set (ByVal value  as String )
		_Misc1Dfq = value
	End Set
End Property

Public Property Misc2Num()  as String
	Get
		Return _Misc2Num
	End Get
	Set (ByVal value  as String )
		_Misc2Num = value
	End Set
End Property

Public Property Misc2Dol()  as Decimal
	Get
		Return _Misc2Dol
	End Get
	Set (ByVal value  as Decimal )
		_Misc2Dol = value
	End Set
End Property

Public Property Misc2Dfq()  as String
	Get
		Return _Misc2Dfq
	End Get
	Set (ByVal value  as String )
		_Misc2Dfq = value
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

Public Property Dflag()  as String
	Get
		Return _Dflag
	End Get
	Set (ByVal value  as String )
		_Dflag = value
	End Set
End Property

Public Property MedExmt()  as String
	Get
		Return _MedExmt
	End Get
	Set (ByVal value  as String )
		_MedExmt = value
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

Public Property BeeperNum()  as String
	Get
		Return _BeeperNum
	End Get
	Set (ByVal value  as String )
		_BeeperNum = value
	End Set
End Property


Public ReadOnly Property nam_eeColumnNames() as string
		Get 
	              	              	              return "([name_key] , [screen_nam] , [ss_num] , [hire_date] , [term_date] , [anniv_mo] , [dept_num] , [slot_num] , [loc_num] , [cost_num] , [sup_num] , [title_num] , [job_title] , [wc_num] , [wc_rate] , [fica_exmt] , [aeic_elig] , [file_status] , [pay_freq] , [fwt_exmts] , [swt_exmts] , [hrly-sal] , [reg_hrs] , [ann_sal] , [state1_tax] , [state2_tax] , [dol_ratea] , [dol_rateb] , [dol_ratec] , [dol_rated] , [dol_ratee] , [dol_ratef] , [dol_rateg] , [dol_rateh] , [dol_ratei] , [dol_ratej] , [add_fwt] , [addfwt_dfq] , [add_swt] , [addswt_dfq] , [a_nt_num] , [a_nt_dol] , [a_nt_dfq] , [b_nt_num] , [b_nt_dol] , [b_nt_dfq] , [c_nt_num] , [c_nt_dol] , [c_nt_dfq] , [d_nt_num] , [d_nt_dol] , [d_nt_dfq] , [e_nt_num] , [e_nt_dol] , [e_nt_dfq] , [flx_nt_num] , [flx_nt_dol] , [flx_nt_dfq] , [dep_nt_num] , [dep_nt_dol] , [dep_nt_dfq] , [pen1a_num] , [pen1a_dol] , [pen1a_pct] , [pen1a_dfq] , [pen1b_num] , [pen1b_dol] , [pen1b_pct] , [pen1b_dfq] , [pen2a_num] , [pen2a_dol] , [pen2a_pct] , [pen2a_dfq] , [pen2b_num] , [pen2b_dol] , [pen2b_pct] , [pen2b_dfq] , [ddep_dfq] , [ddep_net] , [save1_num] , [save1_dol] , [save1_dfq] , [ddep1_sav1] , [save2_num] , [save2_dol] , [save2_dfq] , [ddep2_sav2] , [save3_num] , [save3_dol] , [save3_dfq] , [ddep3_sav3] , [dduct1_num] , [dduct1_dol] , [dduct1_dfq] , [dduct2_num] , [dduct2_dol] , [dduct2_dfq] , [dduct3_num] , [dduct3_dol] , [dduct3_dfq] , [dduct4_num] , [dduct4_dol] , [dduct4_dfq] , [dduct5_num] , [dduct5_dol] , [dduct5_dfq] , [dduct6_num] , [dduct6_dol] , [dduct6_dfq] , [dduct7_num] , [dduct7_dol] , [dduct7_dfq] , [dduct8_num] , [dduct8_dol] , [dduct8_dfq] , [dduct9_num] , [dduct9_dol] , [dduct9_dfq] , [misc1_num] , [misc1_dol] , [misc1_dfq] , [misc2_num] , [misc2_dol] , [misc2_dfq] , [agency] , [dflag] , [med_exmt] , [sort_name] , [beeper_num] )"
		End Get
End Property

Public ReadOnly Property nam_eeColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} , {43} , {44} , {45} , {46} , {47} , {48} , {49} , {50} , {51} , {52} , {53} , {54} , {55} , {56} , {57} , {58} , {59} , {60} , {61} , {62} , {63} , {64} , {65} , {66} , {67} , {68} , {69} , {70} , {71} , {72} , {73} , {74} , {75} , {76} , {77} , {78} , {79} , {80} , {81} , {82} , {83} , {84} , {85} , {86} , {87} , {88} , {89} , {90} , {91} , {92} , {93} , {94} , {95} , {96} , {97} , {98} , {99} , {100} , {101} , {102} , {103} , {104} , {105} , {106} , {107} , {108} , {109} , {110} , {111} , {112} , {113} , {114} , {115} , {116} , {117} , {118} , {119} , {120} , {121} , {122} , {123} , {124} , {125} , {126} , {127} , {128} )"  _  
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_SsNum.tostring) _ 
	 , database.stringparam(_HireDate.toshortdatestring) _ 
	 , database.stringparam(_TermDate.toshortdatestring) _ 
	 , database.stringparam(_AnnivMo.tostring) _ 
	 , database.stringparam(_DeptNum.tostring) _ 
	 , database.stringparam(_SlotNum.tostring) _ 
	 , database.stringparam(_LocNum.tostring) _ 
	 , database.stringparam(_CostNum.tostring) _ 
	 , database.stringparam(_SupNum.tostring) _ 
	 , database.stringparam(_TitleNum.tostring) _ 
	 , database.stringparam(_JobTitle.tostring) _ 
	 , database.stringparam(_WcNum.tostring) _ 
	 , (_WcRate.tostring) _ 
	 , database.stringparam(_FicaExmt.tostring) _ 
	 , database.stringparam(_AeicElig.tostring) _ 
	 , database.stringparam(_FileStatus.tostring) _ 
	 , database.stringparam(_PayFreq.tostring) _ 
	 , (_FwtExmts.tostring) _ 
	 , (_SwtExmts.tostring) _ 
	 , database.stringparam(_HrlySal.tostring) _ 
	 , (_RegHrs.tostring) _ 
	 , (_AnnSal.tostring) _ 
	 , database.stringparam(_State1Tax.tostring) _ 
	 , database.stringparam(_State2Tax.tostring) _ 
	 , (_DolRatea.tostring) _ 
	 , (_DolRateb.tostring) _ 
	 , (_DolRatec.tostring) _ 
	 , (_DolRated.tostring) _ 
	 , (_DolRatee.tostring) _ 
	 , (_DolRatef.tostring) _ 
	 , (_DolRateg.tostring) _ 
	 , (_DolRateh.tostring) _ 
	 , (_DolRatei.tostring) _ 
	 , (_DolRatej.tostring) _ 
	 , (_AddFwt.tostring) _ 
	 , database.stringparam(_AddfwtDfq.tostring) _ 
	 , (_AddSwt.tostring) _ 
	 , database.stringparam(_AddswtDfq.tostring) _ 
	 , database.stringparam(_ANtNum.tostring) _ 
	 , (_ANtDol.tostring) _ 
	 , database.stringparam(_ANtDfq.tostring) _ 
	 , database.stringparam(_BNtNum.tostring) _ 
	 , (_BNtDol.tostring) _ 
	 , database.stringparam(_BNtDfq.tostring) _ 
	 , database.stringparam(_CNtNum.tostring) _ 
	 , (_CNtDol.tostring) _ 
	 , database.stringparam(_CNtDfq.tostring) _ 
	 , database.stringparam(_DNtNum.tostring) _ 
	 , (_DNtDol.tostring) _ 
	 , database.stringparam(_DNtDfq.tostring) _ 
	 , database.stringparam(_ENtNum.tostring) _ 
	 , (_ENtDol.tostring) _ 
	 , database.stringparam(_ENtDfq.tostring) _ 
	 , database.stringparam(_FlxNtNum.tostring) _ 
	 , (_FlxNtDol.tostring) _ 
	 , database.stringparam(_FlxNtDfq.tostring) _ 
	 , database.stringparam(_DepNtNum.tostring) _ 
	 , (_DepNtDol.tostring) _ 
	 , database.stringparam(_DepNtDfq.tostring) _ 
	 , database.stringparam(_Pen1aNum.tostring) _ 
	 , (_Pen1aDol.tostring) _ 
	 , (_Pen1aPct.tostring) _ 
	 , database.stringparam(_Pen1aDfq.tostring) _ 
	 , database.stringparam(_Pen1bNum.tostring) _ 
	 , (_Pen1bDol.tostring) _ 
	 , (_Pen1bPct.tostring) _ 
	 , database.stringparam(_Pen1bDfq.tostring) _ 
	 , database.stringparam(_Pen2aNum.tostring) _ 
	 , (_Pen2aDol.tostring) _ 
	 , (_Pen2aPct.tostring) _ 
	 , database.stringparam(_Pen2aDfq.tostring) _ 
	 , database.stringparam(_Pen2bNum.tostring) _ 
	 , (_Pen2bDol.tostring) _ 
	 , (_Pen2bPct.tostring) _ 
	 , database.stringparam(_Pen2bDfq.tostring) _ 
	 , database.stringparam(_DdepDfq.tostring) _ 
	 , database.stringparam(_DdepNet.tostring) _ 
	 , database.stringparam(_Save1Num.tostring) _ 
	 , (_Save1Dol.tostring) _ 
	 , database.stringparam(_Save1Dfq.tostring) _ 
	 , database.stringparam(_Ddep1Sav1.tostring) _ 
	 , database.stringparam(_Save2Num.tostring) _ 
	 , (_Save2Dol.tostring) _ 
	 , database.stringparam(_Save2Dfq.tostring) _ 
	 , database.stringparam(_Ddep2Sav2.tostring) _ 
	 , database.stringparam(_Save3Num.tostring) _ 
	 , (_Save3Dol.tostring) _ 
	 , database.stringparam(_Save3Dfq.tostring) _ 
	 , database.stringparam(_Ddep3Sav3.tostring) _ 
	 , database.stringparam(_Dduct1Num.tostring) _ 
	 , (_Dduct1Dol.tostring) _ 
	 , database.stringparam(_Dduct1Dfq.tostring) _ 
	 , database.stringparam(_Dduct2Num.tostring) _ 
	 , (_Dduct2Dol.tostring) _ 
	 , database.stringparam(_Dduct2Dfq.tostring) _ 
	 , database.stringparam(_Dduct3Num.tostring) _ 
	 , (_Dduct3Dol.tostring) _ 
	 , database.stringparam(_Dduct3Dfq.tostring) _ 
	 , database.stringparam(_Dduct4Num.tostring) _ 
	 , (_Dduct4Dol.tostring) _ 
	 , database.stringparam(_Dduct4Dfq.tostring) _ 
	 , database.stringparam(_Dduct5Num.tostring) _ 
	 , (_Dduct5Dol.tostring) _ 
	 , database.stringparam(_Dduct5Dfq.tostring) _ 
	 , database.stringparam(_Dduct6Num.tostring) _ 
	 , (_Dduct6Dol.tostring) _ 
	 , database.stringparam(_Dduct6Dfq.tostring) _ 
	 , database.stringparam(_Dduct7Num.tostring) _ 
	 , (_Dduct7Dol.tostring) _ 
	 , database.stringparam(_Dduct7Dfq.tostring) _ 
	 , database.stringparam(_Dduct8Num.tostring) _ 
	 , (_Dduct8Dol.tostring) _ 
	 , database.stringparam(_Dduct8Dfq.tostring) _ 
	 , database.stringparam(_Dduct9Num.tostring) _ 
	 , (_Dduct9Dol.tostring) _ 
	 , database.stringparam(_Dduct9Dfq.tostring) _ 
	 , database.stringparam(_Misc1Num.tostring) _ 
	 , (_Misc1Dol.tostring) _ 
	 , database.stringparam(_Misc1Dfq.tostring) _ 
	 , database.stringparam(_Misc2Num.tostring) _ 
	 , (_Misc2Dol.tostring) _ 
	 , database.stringparam(_Misc2Dfq.tostring) _ 
	 , (_Agency.tostring) _ 
	 , database.stringparam(_Dflag.tostring) _ 
	 , database.stringparam(_MedExmt.tostring) _ 
	 , database.stringparam(_SortName.tostring) _ 
	 , database.stringparam(_BeeperNum.tostring) _ 
)
		End Get
End Property
End Class
