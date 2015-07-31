Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class nam_ccData
	Private _NameKey as String
	Private _ScreenNam as String
	Private _SortName as String
	Private _Desc1 as String
	Private _Desc2 as String
	Private _Desc3 as String
	Private _DeptNum as String
	Private _FundCode as String
	Private _DisabNum as String
	Private _DisabDesc as String
	Private _SsNum as String
	Private _HireDate as Date
	Private _TermDate as Date
	Private _AnnivMo as String
	Private _Dob as Date
	Private _AvgHrly as Decimal
	Private _Makeup as String
	Private _EPhone as String
	Private _EName as String
	Private _WcNum as String
	Private _WcRate as Decimal
	Private _FicaExmt as String
	Private _MedExmt as String
	Private _FileStatus as String
	Private _PayFreq as String
	Private _Printck as String
	Private _FwtExmts as Integer
	Private _SwtExmts as Integer
	Private _State1Tax as String
	Private _State2Tax as String
	Private _AddFwt as Decimal
	Private _AddfwtDfq as String
	Private _AddSwt as Decimal
	Private _AddswtDfq as String
	Private _AddFica as Decimal
	Private _AddficaDfq as String
	Private _AddMed as Decimal
	Private _AddmedDfq as String
	Private _DdepDfq as String
	Private _DdepNet as String
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
	Private _Agency as Integer
	Private _Dflag as String
	Private _Text1 as String
	Private _Text2 as String

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

Public Property DisabDesc()  as String
	Get
		Return _DisabDesc
	End Get
	Set (ByVal value  as String )
		_DisabDesc = value
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

Public Property Dob()  as Date
	Get
		Return _Dob
	End Get
	Set (ByVal value  as Date )
		_Dob = value
	End Set
End Property

Public Property AvgHrly()  as Decimal
	Get
		Return _AvgHrly
	End Get
	Set (ByVal value  as Decimal )
		_AvgHrly = value
	End Set
End Property

Public Property Makeup()  as String
	Get
		Return _Makeup
	End Get
	Set (ByVal value  as String )
		_Makeup = value
	End Set
End Property

Public Property EPhone()  as String
	Get
		Return _EPhone
	End Get
	Set (ByVal value  as String )
		_EPhone = value
	End Set
End Property

Public Property EName()  as String
	Get
		Return _EName
	End Get
	Set (ByVal value  as String )
		_EName = value
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

Public Property MedExmt()  as String
	Get
		Return _MedExmt
	End Get
	Set (ByVal value  as String )
		_MedExmt = value
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

Public Property Printck()  as String
	Get
		Return _Printck
	End Get
	Set (ByVal value  as String )
		_Printck = value
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

Public Property AddFica()  as Decimal
	Get
		Return _AddFica
	End Get
	Set (ByVal value  as Decimal )
		_AddFica = value
	End Set
End Property

Public Property AddficaDfq()  as String
	Get
		Return _AddficaDfq
	End Get
	Set (ByVal value  as String )
		_AddficaDfq = value
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

Public Property AddmedDfq()  as String
	Get
		Return _AddmedDfq
	End Get
	Set (ByVal value  as String )
		_AddmedDfq = value
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

Public Property Text1()  as String
	Get
		Return _Text1
	End Get
	Set (ByVal value  as String )
		_Text1 = value
	End Set
End Property

Public Property Text2()  as String
	Get
		Return _Text2
	End Get
	Set (ByVal value  as String )
		_Text2 = value
	End Set
End Property


Public ReadOnly Property nam_ccColumnNames() as string
		Get 
	              	              	              return "([name_key] , [screen_nam] , [sort_name] , [desc1] , [desc2] , [desc3] , [dept_num] , [fund_code] , [disab_num] , [disab_desc] , [ss_num] , [hire_date] , [term_date] , [anniv_mo] , [dob] , [avg_hrly] , [makeup] , [e_phone] , [e_name] , [wc_num] , [wc_rate] , [fica_exmt] , [med_exmt] , [file_status] , [pay_freq] , [printck] , [fwt_exmts] , [swt_exmts] , [state1_tax] , [state2_tax] , [add_fwt] , [addfwt_dfq] , [add_swt] , [addswt_dfq] , [add_fica] , [addfica_dfq] , [add_med] , [addmed_dfq] , [ddep_dfq] , [ddep_net] , [dduct1_num] , [dduct1_dol] , [dduct1_dfq] , [dduct2_num] , [dduct2_dol] , [dduct2_dfq] , [dduct3_num] , [dduct3_dol] , [dduct3_dfq] , [dduct4_num] , [dduct4_dol] , [dduct4_dfq] , [agency] , [dflag] , [text1] , [text2] )"
		End Get
End Property

Public ReadOnly Property nam_ccColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} , {43} , {44} , {45} , {46} , {47} , {48} , {49} , {50} , {51} , {52} , {53} , {54} , {55} )"  _  
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_SortName.tostring) _ 
	 , database.stringparam(_Desc1.tostring) _ 
	 , database.stringparam(_Desc2.tostring) _ 
	 , database.stringparam(_Desc3.tostring) _ 
	 , database.stringparam(_DeptNum.tostring) _ 
	 , database.stringparam(_FundCode.tostring) _ 
	 , database.stringparam(_DisabNum.tostring) _ 
	 , database.stringparam(_DisabDesc.tostring) _ 
	 , database.stringparam(_SsNum.tostring) _ 
	 , database.stringparam(_HireDate.toshortdatestring) _ 
	 , database.stringparam(_TermDate.toshortdatestring) _ 
	 , database.stringparam(_AnnivMo.tostring) _ 
	 , database.stringparam(_Dob.toshortdatestring) _ 
	 , (_AvgHrly.tostring) _ 
	 , database.stringparam(_Makeup.tostring) _ 
	 , database.stringparam(_EPhone.tostring) _ 
	 , database.stringparam(_EName.tostring) _ 
	 , database.stringparam(_WcNum.tostring) _ 
	 , (_WcRate.tostring) _ 
	 , database.stringparam(_FicaExmt.tostring) _ 
	 , database.stringparam(_MedExmt.tostring) _ 
	 , database.stringparam(_FileStatus.tostring) _ 
	 , database.stringparam(_PayFreq.tostring) _ 
	 , database.stringparam(_Printck.tostring) _ 
	 , (_FwtExmts.tostring) _ 
	 , (_SwtExmts.tostring) _ 
	 , database.stringparam(_State1Tax.tostring) _ 
	 , database.stringparam(_State2Tax.tostring) _ 
	 , (_AddFwt.tostring) _ 
	 , database.stringparam(_AddfwtDfq.tostring) _ 
	 , (_AddSwt.tostring) _ 
	 , database.stringparam(_AddswtDfq.tostring) _ 
	 , (_AddFica.tostring) _ 
	 , database.stringparam(_AddficaDfq.tostring) _ 
	 , (_AddMed.tostring) _ 
	 , database.stringparam(_AddmedDfq.tostring) _ 
	 , database.stringparam(_DdepDfq.tostring) _ 
	 , database.stringparam(_DdepNet.tostring) _ 
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
	 , (_Agency.tostring) _ 
	 , database.stringparam(_Dflag.tostring) _ 
	 , database.stringparam(_Text1.tostring) _ 
	 , database.stringparam(_Text2.tostring) _ 
)
		End Get
End Property
End Class
