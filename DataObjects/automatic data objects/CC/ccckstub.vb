Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class ccckstubData
	Private _ChkNum as Integer
	Private _ChkDate as Date
	Private _ChkDirdep as String
	Private _PayNum as Integer
	Private _NameKey as String
	Private _ScreenNam as String
	Private _SortName as String
	Private _Desc1 as String
	Private _Desc2 as String
	Private _Desc3 as String
	Private _DeptNum as String
	Private _FundCode as String
	Private _DisabNum as String
	Private _PayFreq as String
	Private _DedDfq as String
	Private _FwtExmts as Integer
	Private _SwtExmts as Integer
	Private _BlendOvt as Decimal
	Private _DirHrs as Double
	Private _DirDol as Decimal
	Private _IndHrs as Double
	Private _IndDol as Decimal
	Private _NoPayHrs as Decimal
	Private _VacHrs as Double
	Private _VacDol as Decimal
	Private _SickHrs as Double
	Private _SickDol as Decimal
	Private _HolHrs as Double
	Private _HolDol as Decimal
	Private _PersHrs as Double
	Private _PersDol as Decimal
	Private _Makeup as Decimal
	Private _Stipend as Decimal
	Private _Minimum as Decimal
	Private _FullGross as Decimal
	Private _FedGross as Decimal
	Private _FedTax as Decimal
	Private _FicaGross as Decimal
	Private _FicaTax as Decimal
	Private _MedGross as Decimal
	Private _MedTax as Decimal
	Private _State1Gross as Decimal
	Private _State1Tax as Decimal
	Private _State2Gross as Decimal
	Private _State2Tax as Decimal
	Private _NetPay as Decimal
	Private _Dduct1Dol as Decimal
	Private _Dduct1Num as String
	Private _Dduct2Dol as Decimal
	Private _Dduct2Num as String
	Private _Dduct3Dol as Decimal
	Private _Dduct3Num as String
	Private _Dduct4Dol as Decimal
	Private _Dduct4Num as String
	Private _GlPost as String
	Private _EncumDate as Date
	Private _Recon as String
	Private _RDate as Date
	Private _Void as String
	Private _Agency as Integer
	Private _Dflag as String
	Private _AddFwt as Decimal
	Private _AddSwt as Decimal
	Private _AddFica as Decimal
	Private _AddMed as Decimal
	Private _State1Code as String
	Private _State2Code as String
	Private _EntryNum as Integer
	Private _TdiTax as Decimal
	Private _JrnlNum as Integer
	Private _JrnlLine as Integer

Public Property ChkNum()  as Integer
	Get
		Return _ChkNum
	End Get
	Set (ByVal value  as Integer )
		_ChkNum = value
	End Set
End Property

Public Property ChkDate()  as Date
	Get
		Return _ChkDate
	End Get
	Set (ByVal value  as Date )
		_ChkDate = value
	End Set
End Property

Public Property ChkDirdep()  as String
	Get
		Return _ChkDirdep
	End Get
	Set (ByVal value  as String )
		_ChkDirdep = value
	End Set
End Property

Public Property PayNum()  as Integer
	Get
		Return _PayNum
	End Get
	Set (ByVal value  as Integer )
		_PayNum = value
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

Public Property DeptNum()  as String
	Get
		Return _DeptNum
	End Get
	Set (ByVal value  as String )
		_DeptNum = value
	End Set
End Property

Public Property FundCode()  as String
	Get
		Return _FundCode
	End Get
	Set (ByVal value  as String )
		_FundCode = value
	End Set
End Property

Public Property DisabNum()  as String
	Get
		Return _DisabNum
	End Get
	Set (ByVal value  as String )
		_DisabNum = value
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

Public Property DedDfq()  as String
	Get
		Return _DedDfq
	End Get
	Set (ByVal value  as String )
		_DedDfq = value
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

Public Property BlendOvt()  as Decimal
	Get
		Return _BlendOvt
	End Get
	Set (ByVal value  as Decimal )
		_BlendOvt = value
	End Set
End Property

Public Property DirHrs()  as Double
	Get
		Return _DirHrs
	End Get
	Set (ByVal value  as Double )
		_DirHrs = value
	End Set
End Property

Public Property DirDol()  as Decimal
	Get
		Return _DirDol
	End Get
	Set (ByVal value  as Decimal )
		_DirDol = value
	End Set
End Property

Public Property IndHrs()  as Double
	Get
		Return _IndHrs
	End Get
	Set (ByVal value  as Double )
		_IndHrs = value
	End Set
End Property

Public Property IndDol()  as Decimal
	Get
		Return _IndDol
	End Get
	Set (ByVal value  as Decimal )
		_IndDol = value
	End Set
End Property

Public Property NoPayHrs()  as Decimal
	Get
		Return _NoPayHrs
	End Get
	Set (ByVal value  as Decimal )
		_NoPayHrs = value
	End Set
End Property

Public Property VacHrs()  as Double
	Get
		Return _VacHrs
	End Get
	Set (ByVal value  as Double )
		_VacHrs = value
	End Set
End Property

Public Property VacDol()  as Decimal
	Get
		Return _VacDol
	End Get
	Set (ByVal value  as Decimal )
		_VacDol = value
	End Set
End Property

Public Property SickHrs()  as Double
	Get
		Return _SickHrs
	End Get
	Set (ByVal value  as Double )
		_SickHrs = value
	End Set
End Property

Public Property SickDol()  as Decimal
	Get
		Return _SickDol
	End Get
	Set (ByVal value  as Decimal )
		_SickDol = value
	End Set
End Property

Public Property HolHrs()  as Double
	Get
		Return _HolHrs
	End Get
	Set (ByVal value  as Double )
		_HolHrs = value
	End Set
End Property

Public Property HolDol()  as Decimal
	Get
		Return _HolDol
	End Get
	Set (ByVal value  as Decimal )
		_HolDol = value
	End Set
End Property

Public Property PersHrs()  as Double
	Get
		Return _PersHrs
	End Get
	Set (ByVal value  as Double )
		_PersHrs = value
	End Set
End Property

Public Property PersDol()  as Decimal
	Get
		Return _PersDol
	End Get
	Set (ByVal value  as Decimal )
		_PersDol = value
	End Set
End Property

Public Property Makeup()  as Decimal
	Get
		Return _Makeup
	End Get
	Set (ByVal value  as Decimal )
		_Makeup = value
	End Set
End Property

Public Property Stipend()  as Decimal
	Get
		Return _Stipend
	End Get
	Set (ByVal value  as Decimal )
		_Stipend = value
	End Set
End Property

Public Property Minimum()  as Decimal
	Get
		Return _Minimum
	End Get
	Set (ByVal value  as Decimal )
		_Minimum = value
	End Set
End Property

Public Property FullGross()  as Decimal
	Get
		Return _FullGross
	End Get
	Set (ByVal value  as Decimal )
		_FullGross = value
	End Set
End Property

Public Property FedGross()  as Decimal
	Get
		Return _FedGross
	End Get
	Set (ByVal value  as Decimal )
		_FedGross = value
	End Set
End Property

Public Property FedTax()  as Decimal
	Get
		Return _FedTax
	End Get
	Set (ByVal value  as Decimal )
		_FedTax = value
	End Set
End Property

Public Property FicaGross()  as Decimal
	Get
		Return _FicaGross
	End Get
	Set (ByVal value  as Decimal )
		_FicaGross = value
	End Set
End Property

Public Property FicaTax()  as Decimal
	Get
		Return _FicaTax
	End Get
	Set (ByVal value  as Decimal )
		_FicaTax = value
	End Set
End Property

Public Property MedGross()  as Decimal
	Get
		Return _MedGross
	End Get
	Set (ByVal value  as Decimal )
		_MedGross = value
	End Set
End Property

Public Property MedTax()  as Decimal
	Get
		Return _MedTax
	End Get
	Set (ByVal value  as Decimal )
		_MedTax = value
	End Set
End Property

Public Property State1Gross()  as Decimal
	Get
		Return _State1Gross
	End Get
	Set (ByVal value  as Decimal )
		_State1Gross = value
	End Set
End Property

Public Property State1Tax()  as Decimal
	Get
		Return _State1Tax
	End Get
	Set (ByVal value  as Decimal )
		_State1Tax = value
	End Set
End Property

Public Property State2Gross()  as Decimal
	Get
		Return _State2Gross
	End Get
	Set (ByVal value  as Decimal )
		_State2Gross = value
	End Set
End Property

Public Property State2Tax()  as Decimal
	Get
		Return _State2Tax
	End Get
	Set (ByVal value  as Decimal )
		_State2Tax = value
	End Set
End Property

Public Property NetPay()  as Decimal
	Get
		Return _NetPay
	End Get
	Set (ByVal value  as Decimal )
		_NetPay = value
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

Public Property Dduct1Num()  as String
	Get
		Return _Dduct1Num
	End Get
	Set (ByVal value  as String )
		_Dduct1Num = value
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

Public Property Dduct2Num()  as String
	Get
		Return _Dduct2Num
	End Get
	Set (ByVal value  as String )
		_Dduct2Num = value
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

Public Property Dduct3Num()  as String
	Get
		Return _Dduct3Num
	End Get
	Set (ByVal value  as String )
		_Dduct3Num = value
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

Public Property Dduct4Num()  as String
	Get
		Return _Dduct4Num
	End Get
	Set (ByVal value  as String )
		_Dduct4Num = value
	End Set
End Property

Public Property GlPost()  as String
	Get
		Return _GlPost
	End Get
	Set (ByVal value  as String )
		_GlPost = value
	End Set
End Property

Public Property EncumDate()  as Date
	Get
		Return _EncumDate
	End Get
	Set (ByVal value  as Date )
		_EncumDate = value
	End Set
End Property

Public Property Recon()  as String
	Get
		Return _Recon
	End Get
	Set (ByVal value  as String )
		_Recon = value
	End Set
End Property

Public Property RDate()  as Date
	Get
		Return _RDate
	End Get
	Set (ByVal value  as Date )
		_RDate = value
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

Public Property AddFwt()  as Decimal
	Get
		Return _AddFwt
	End Get
	Set (ByVal value  as Decimal )
		_AddFwt = value
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

Public Property AddFica()  as Decimal
	Get
		Return _AddFica
	End Get
	Set (ByVal value  as Decimal )
		_AddFica = value
	End Set
End Property

Public Property AddMed()  as Decimal
	Get
		Return _AddMed
	End Get
	Set (ByVal value  as Decimal )
		_AddMed = value
	End Set
End Property

Public Property State1Code()  as String
	Get
		Return _State1Code
	End Get
	Set (ByVal value  as String )
		_State1Code = value
	End Set
End Property

Public Property State2Code()  as String
	Get
		Return _State2Code
	End Get
	Set (ByVal value  as String )
		_State2Code = value
	End Set
End Property

Public Property EntryNum()  as Integer
	Get
		Return _EntryNum
	End Get
	Set (ByVal value  as Integer )
		_EntryNum = value
	End Set
End Property

Public Property TdiTax()  as Decimal
	Get
		Return _TdiTax
	End Get
	Set (ByVal value  as Decimal )
		_TdiTax = value
	End Set
End Property

Public Property JrnlNum()  as Integer
	Get
		Return _JrnlNum
	End Get
	Set (ByVal value  as Integer )
		_JrnlNum = value
	End Set
End Property

Public Property JrnlLine()  as Integer
	Get
		Return _JrnlLine
	End Get
	Set (ByVal value  as Integer )
		_JrnlLine = value
	End Set
End Property


Public ReadOnly Property ccckstubColumnNames() as string
		Get 
	              	              	              return "([ChkNum] , [ChkDate] , [ChkDirdep] , [PayNum] , [NameKey] , [ScreenNam] , [SortName] , [Desc1] , [Desc2] , [Desc3] , [DeptNum] , [FundCode] , [DisabNum] , [PayFreq] , [DedDfq] , [FwtExmts] , [SwtExmts] , [BlendOvt] , [DirHrs] , [DirDol] , [IndHrs] , [IndDol] , [NoPayHrs] , [VacHrs] , [VacDol] , [SickHrs] , [SickDol] , [HolHrs] , [HolDol] , [PersHrs] , [PersDol] , [Makeup] , [Stipend] , [Minimum] , [FullGross] , [FedGross] , [FedTax] , [FicaGross] , [FicaTax] , [MedGross] , [MedTax] , [State1Gross] , [State1Tax] , [State2Gross] , [State2Tax] , [NetPay] , [Dduct1Dol] , [Dduct1Num] , [Dduct2Dol] , [Dduct2Num] , [Dduct3Dol] , [Dduct3Num] , [Dduct4Dol] , [Dduct4Num] , [GlPost] , [EncumDate] , [Recon] , [RDate] , [Void] , [Agency] , [Dflag] , [AddFwt] , [AddSwt] , [AddFica] , [AddMed] , [State1Code] , [State2Code] , [EntryNum] , [TdiTax] , [JrnlNum] , [JrnlLine] )"
		End Get
End Property

Public ReadOnly Property ccckstubColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} , {43} , {44} , {45} , {46} , {47} , {48} , {49} , {50} , {51} , {52} , {53} , {54} , {55} , {56} , {57} , {58} , {59} , {60} , {61} , {62} , {63} , {64} , {65} , {66} , {67} , {68} , {69} , {70} )"  _  
	 , (_ChkNum.tostring) _ 
	 , database.stringparam(_ChkDate.toshortdatestring) _ 
	 , database.stringparam(_ChkDirdep.tostring) _ 
	 , (_PayNum.tostring) _ 
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_SortName.tostring) _ 
	 , database.stringparam(_Desc1.tostring) _ 
	 , database.stringparam(_Desc2.tostring) _ 
	 , database.stringparam(_Desc3.tostring) _ 
	 , database.stringparam(_DeptNum.tostring) _ 
	 , database.stringparam(_FundCode.tostring) _ 
	 , database.stringparam(_DisabNum.tostring) _ 
	 , database.stringparam(_PayFreq.tostring) _ 
	 , database.stringparam(_DedDfq.tostring) _ 
	 , (_FwtExmts.tostring) _ 
	 , (_SwtExmts.tostring) _ 
	 , (_BlendOvt.tostring) _ 
	 , (_DirHrs.tostring) _ 
	 , (_DirDol.tostring) _ 
	 , (_IndHrs.tostring) _ 
	 , (_IndDol.tostring) _ 
	 , (_NoPayHrs.tostring) _ 
	 , (_VacHrs.tostring) _ 
	 , (_VacDol.tostring) _ 
	 , (_SickHrs.tostring) _ 
	 , (_SickDol.tostring) _ 
	 , (_HolHrs.tostring) _ 
	 , (_HolDol.tostring) _ 
	 , (_PersHrs.tostring) _ 
	 , (_PersDol.tostring) _ 
	 , (_Makeup.tostring) _ 
	 , (_Stipend.tostring) _ 
	 , (_Minimum.tostring) _ 
	 , (_FullGross.tostring) _ 
	 , (_FedGross.tostring) _ 
	 , (_FedTax.tostring) _ 
	 , (_FicaGross.tostring) _ 
	 , (_FicaTax.tostring) _ 
	 , (_MedGross.tostring) _ 
	 , (_MedTax.tostring) _ 
	 , (_State1Gross.tostring) _ 
	 , (_State1Tax.tostring) _ 
	 , (_State2Gross.tostring) _ 
	 , (_State2Tax.tostring) _ 
	 , (_NetPay.tostring) _ 
	 , (_Dduct1Dol.tostring) _ 
	 , database.stringparam(_Dduct1Num.tostring) _ 
	 , (_Dduct2Dol.tostring) _ 
	 , database.stringparam(_Dduct2Num.tostring) _ 
	 , (_Dduct3Dol.tostring) _ 
	 , database.stringparam(_Dduct3Num.tostring) _ 
	 , (_Dduct4Dol.tostring) _ 
	 , database.stringparam(_Dduct4Num.tostring) _ 
	 , database.stringparam(_GlPost.tostring) _ 
	 , database.stringparam(_EncumDate.toshortdatestring) _ 
	 , database.stringparam(_Recon.tostring) _ 
	 , database.stringparam(_RDate.toshortdatestring) _ 
	 , database.stringparam(_Void.tostring) _ 
	 , (_Agency.tostring) _ 
	 , database.stringparam(_Dflag.tostring) _ 
	 , (_AddFwt.tostring) _ 
	 , (_AddSwt.tostring) _ 
	 , (_AddFica.tostring) _ 
	 , (_AddMed.tostring) _ 
	 , database.stringparam(_State1Code.tostring) _ 
	 , database.stringparam(_State2Code.tostring) _ 
	 , (_EntryNum.tostring) _ 
	 , (_TdiTax.tostring) _ 
	 , (_JrnlNum.tostring) _ 
	 , (_JrnlLine.tostring) _ 
)
		End Get
End Property
End Class
