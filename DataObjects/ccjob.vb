Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class ccjobData
	Private _JobNum as String
	Private _JobDesc as String
	Private _NameKey as String
	Private _ScreenNam as String
	Private _SortName as String
	Private _PayClass as String
	Private _Type as String
	Private _PrevRate as Decimal
	Private _PcsHr as Decimal
	Private _RateHr as Decimal
	Private _PcRate as Double
	Private _MinWage as Decimal
	Private _StepGrp as String
	Private _Final as String
	Private _SellPrc as Decimal
	Private _DeptNum as String
	Private _TSDate as Date
	Private _WcNum as String
	Private _WcRate as Decimal
	Private _Dflag as String
	Private _Agency as String
	Private _Difficulty as String
	Private _PayperDol as Decimal
	Private _PayperHrs as Double
	Private _DolPdYtd as Decimal
	Private _HrsYtd as Double
	Private _DolPyr as Decimal
	Private _HrsPyr as Double
	Private _DrAcctNu as String
	Private _CrAcctNu as String
	Private _JrnlNum as Integer
	Private _JrnlLine as Integer
	Private _BillRate as Decimal
	Private _SpvrRate as Decimal
	Private _Hwb as Decimal
	Private _PayperPcs as Double
	Private _PcsYtd as Double
	Private _PcsPyr as Double
	Private _Cost1 as String
	Private _Cost2 as String
	Private _Cost3 as String
	Private _Cost4 as String
	Private _Cost5 as String

Public Property JobNum()  as String
	Get
		Return _JobNum
	End Get
	Set (ByVal value  as String )
		_JobNum = value
	End Set
End Property

Public Property JobDesc()  as String
	Get
		Return _JobDesc
	End Get
	Set (ByVal value  as String )
		_JobDesc = value
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

Public Property PayClass()  as String
	Get
		Return _PayClass
	End Get
	Set (ByVal value  as String )
		_PayClass = value
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

Public Property PrevRate()  as Decimal
	Get
		Return _PrevRate
	End Get
	Set (ByVal value  as Decimal )
		_PrevRate = value
	End Set
End Property

Public Property PcsHr()  as Decimal
	Get
		Return _PcsHr
	End Get
	Set (ByVal value  as Decimal )
		_PcsHr = value
	End Set
End Property

Public Property RateHr()  as Decimal
	Get
		Return _RateHr
	End Get
	Set (ByVal value  as Decimal )
		_RateHr = value
	End Set
End Property

Public Property PcRate()  as Double
	Get
		Return _PcRate
	End Get
	Set (ByVal value  as Double )
		_PcRate = value
	End Set
End Property

Public Property MinWage()  as Decimal
	Get
		Return _MinWage
	End Get
	Set (ByVal value  as Decimal )
		_MinWage = value
	End Set
End Property

Public Property StepGrp()  as String
	Get
		Return _StepGrp
	End Get
	Set (ByVal value  as String )
		_StepGrp = value
	End Set
End Property

Public Property Final()  as String
	Get
		Return _Final
	End Get
	Set (ByVal value  as String )
		_Final = value
	End Set
End Property

Public Property SellPrc()  as Decimal
	Get
		Return _SellPrc
	End Get
	Set (ByVal value  as Decimal )
		_SellPrc = value
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

Public Property TSDate()  as Date
	Get
		Return _TSDate
	End Get
	Set (ByVal value  as Date )
		_TSDate = value
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

Public Property Dflag()  as String
	Get
		Return _Dflag
	End Get
	Set (ByVal value  as String )
		_Dflag = value
	End Set
End Property

Public Property Agency()  as String
	Get
		Return _Agency
	End Get
	Set (ByVal value  as String )
		_Agency = value
	End Set
End Property

Public Property Difficulty()  as String
	Get
		Return _Difficulty
	End Get
	Set (ByVal value  as String )
		_Difficulty = value
	End Set
End Property

Public Property PayperDol()  as Decimal
	Get
		Return _PayperDol
	End Get
	Set (ByVal value  as Decimal )
		_PayperDol = value
	End Set
End Property

Public Property PayperHrs()  as Double
	Get
		Return _PayperHrs
	End Get
	Set (ByVal value  as Double )
		_PayperHrs = value
	End Set
End Property

Public Property DolPdYtd()  as Decimal
	Get
		Return _DolPdYtd
	End Get
	Set (ByVal value  as Decimal )
		_DolPdYtd = value
	End Set
End Property

Public Property HrsYtd()  as Double
	Get
		Return _HrsYtd
	End Get
	Set (ByVal value  as Double )
		_HrsYtd = value
	End Set
End Property

Public Property DolPyr()  as Decimal
	Get
		Return _DolPyr
	End Get
	Set (ByVal value  as Decimal )
		_DolPyr = value
	End Set
End Property

Public Property HrsPyr()  as Double
	Get
		Return _HrsPyr
	End Get
	Set (ByVal value  as Double )
		_HrsPyr = value
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

Public Property BillRate()  as Decimal
	Get
		Return _BillRate
	End Get
	Set (ByVal value  as Decimal )
		_BillRate = value
	End Set
End Property

Public Property SpvrRate()  as Decimal
	Get
		Return _SpvrRate
	End Get
	Set (ByVal value  as Decimal )
		_SpvrRate = value
	End Set
End Property

Public Property Hwb()  as Decimal
	Get
		Return _Hwb
	End Get
	Set (ByVal value  as Decimal )
		_Hwb = value
	End Set
End Property

Public Property PayperPcs()  as Double
	Get
		Return _PayperPcs
	End Get
	Set (ByVal value  as Double )
		_PayperPcs = value
	End Set
End Property

Public Property PcsYtd()  as Double
	Get
		Return _PcsYtd
	End Get
	Set (ByVal value  as Double )
		_PcsYtd = value
	End Set
End Property

Public Property PcsPyr()  as Double
	Get
		Return _PcsPyr
	End Get
	Set (ByVal value  as Double )
		_PcsPyr = value
	End Set
End Property

Public Property Cost1()  as String
	Get
		Return _Cost1
	End Get
	Set (ByVal value  as String )
		_Cost1 = value
	End Set
End Property

Public Property Cost2()  as String
	Get
		Return _Cost2
	End Get
	Set (ByVal value  as String )
		_Cost2 = value
	End Set
End Property

Public Property Cost3()  as String
	Get
		Return _Cost3
	End Get
	Set (ByVal value  as String )
		_Cost3 = value
	End Set
End Property

Public Property Cost4()  as String
	Get
		Return _Cost4
	End Get
	Set (ByVal value  as String )
		_Cost4 = value
	End Set
End Property

Public Property Cost5()  as String
	Get
		Return _Cost5
	End Get
	Set (ByVal value  as String )
		_Cost5 = value
	End Set
End Property


Public ReadOnly Property ccjobColumnNames() as string
		Get 
	              	              	              return "([JobNum] , [JobDesc] , [NameKey] , [ScreenNam] , [SortName] , [PayClass] , [Type] , [PrevRate] , [PcsHr] , [RateHr] , [PcRate] , [MinWage] , [StepGrp] , [Final] , [SellPrc] , [DeptNum] , [TSDate] , [WcNum] , [WcRate] , [Dflag] , [Agency] , [Difficulty] , [PayperDol] , [PayperHrs] , [DolPdYtd] , [HrsYtd] , [DolPyr] , [HrsPyr] , [DrAcctNu] , [CrAcctNu] , [JrnlNum] , [JrnlLine] , [BillRate] , [SpvrRate] , [Hwb] , [PayperPcs] , [PcsYtd] , [PcsPyr] , [Cost1] , [Cost2] , [Cost3] , [Cost4] , [Cost5] )"
		End Get
End Property

Public ReadOnly Property ccjobColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} )"  _  
	 , database.stringparam(_JobNum.tostring) _ 
	 , database.stringparam(_JobDesc.tostring) _ 
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_SortName.tostring) _ 
	 , database.stringparam(_PayClass.tostring) _ 
	 , database.stringparam(_Type.tostring) _ 
	 , (_PrevRate.tostring) _ 
	 , (_PcsHr.tostring) _ 
	 , (_RateHr.tostring) _ 
	 , (_PcRate.tostring) _ 
	 , (_MinWage.tostring) _ 
	 , database.stringparam(_StepGrp.tostring) _ 
	 , database.stringparam(_Final.tostring) _ 
	 , (_SellPrc.tostring) _ 
	 , database.stringparam(_DeptNum.tostring) _ 
	 , database.stringparam(_TSDate.toshortdatestring) _ 
	 , database.stringparam(_WcNum.tostring) _ 
	 , (_WcRate.tostring) _ 
	 , database.stringparam(_Dflag.tostring) _ 
	 , database.stringparam(_Agency.tostring) _ 
	 , database.stringparam(_Difficulty.tostring) _ 
	 , (_PayperDol.tostring) _ 
	 , (_PayperHrs.tostring) _ 
	 , (_DolPdYtd.tostring) _ 
	 , (_HrsYtd.tostring) _ 
	 , (_DolPyr.tostring) _ 
	 , (_HrsPyr.tostring) _ 
	 , database.stringparam(_DrAcctNu.tostring) _ 
	 , database.stringparam(_CrAcctNu.tostring) _ 
	 , (_JrnlNum.tostring) _ 
	 , (_JrnlLine.tostring) _ 
	 , (_BillRate.tostring) _ 
	 , (_SpvrRate.tostring) _ 
	 , (_Hwb.tostring) _ 
	 , (_PayperPcs.tostring) _ 
	 , (_PcsYtd.tostring) _ 
	 , (_PcsPyr.tostring) _ 
	 , database.stringparam(_Cost1.tostring) _ 
	 , database.stringparam(_Cost2.tostring) _ 
	 , database.stringparam(_Cost3.tostring) _ 
	 , database.stringparam(_Cost4.tostring) _ 
	 , database.stringparam(_Cost5.tostring) _ 
)
		End Get
End Property
End Class
