Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class eeslot1Data
	Private _SlotNum as String
	Private _LocNum as String
	Private _CrPrefAc as String
	Private _DrPrefAc as String
	Private _UfrDesc as String
	Private _IhDesc as String
	Private _DolBud as Decimal
	Private _HrsBud as Double
	Private _DolPdYtd as Decimal
	Private _HrsYtd as Double
	Private _SchedNum as String
	Private _LineNum as String
	Private _Allocated as String
	Private _PayperDol as Decimal
	Private _PayperHrs as Double
	Private _DficaReg as Decimal
	Private _DficaAloc as Decimal
	Private _DmedReg as Decimal
	Private _DmedAloc as Decimal
	Private _FicaYtd as Decimal
	Private _MedYtd as Decimal
	Private _Code1 as String
	Private _Code2 as String
	Private _WcNum as String
	Private _WcRate as Decimal
	Private _Agency as Integer
	Private _FicaAcctNu as String
	Private _MedAcctNu as String
	Private _DolPyr as Decimal
	Private _HrsPyr as Double
	Private _RateZ as Decimal

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

Public Property CrPrefAc()  as String
	Get
		Return _CrPrefAc
	End Get
	Set (ByVal value  as String )
		_CrPrefAc = value
	End Set
End Property

Public Property DrPrefAc()  as String
	Get
		Return _DrPrefAc
	End Get
	Set (ByVal value  as String )
		_DrPrefAc = value
	End Set
End Property

Public Property UfrDesc()  as String
	Get
		Return _UfrDesc
	End Get
	Set (ByVal value  as String )
		_UfrDesc = value
	End Set
End Property

Public Property IhDesc()  as String
	Get
		Return _IhDesc
	End Get
	Set (ByVal value  as String )
		_IhDesc = value
	End Set
End Property

Public Property DolBud()  as Decimal
	Get
		Return _DolBud
	End Get
	Set (ByVal value  as Decimal )
		_DolBud = value
	End Set
End Property

Public Property HrsBud()  as Double
	Get
		Return _HrsBud
	End Get
	Set (ByVal value  as Double )
		_HrsBud = value
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

Public Property SchedNum()  as String
	Get
		Return _SchedNum
	End Get
	Set (ByVal value  as String )
		_SchedNum = value
	End Set
End Property

Public Property LineNum()  as String
	Get
		Return _LineNum
	End Get
	Set (ByVal value  as String )
		_LineNum = value
	End Set
End Property

Public Property Allocated()  as String
	Get
		Return _Allocated
	End Get
	Set (ByVal value  as String )
		_Allocated = value
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

Public Property DficaReg()  as Decimal
	Get
		Return _DficaReg
	End Get
	Set (ByVal value  as Decimal )
		_DficaReg = value
	End Set
End Property

Public Property DficaAloc()  as Decimal
	Get
		Return _DficaAloc
	End Get
	Set (ByVal value  as Decimal )
		_DficaAloc = value
	End Set
End Property

Public Property DmedReg()  as Decimal
	Get
		Return _DmedReg
	End Get
	Set (ByVal value  as Decimal )
		_DmedReg = value
	End Set
End Property

Public Property DmedAloc()  as Decimal
	Get
		Return _DmedAloc
	End Get
	Set (ByVal value  as Decimal )
		_DmedAloc = value
	End Set
End Property

Public Property FicaYtd()  as Decimal
	Get
		Return _FicaYtd
	End Get
	Set (ByVal value  as Decimal )
		_FicaYtd = value
	End Set
End Property

Public Property MedYtd()  as Decimal
	Get
		Return _MedYtd
	End Get
	Set (ByVal value  as Decimal )
		_MedYtd = value
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

Public Property Agency()  as Integer
	Get
		Return _Agency
	End Get
	Set (ByVal value  as Integer )
		_Agency = value
	End Set
End Property

Public Property FicaAcctNu()  as String
	Get
		Return _FicaAcctNu
	End Get
	Set (ByVal value  as String )
		_FicaAcctNu = value
	End Set
End Property

Public Property MedAcctNu()  as String
	Get
		Return _MedAcctNu
	End Get
	Set (ByVal value  as String )
		_MedAcctNu = value
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

Public Property RateZ()  as Decimal
	Get
		Return _RateZ
	End Get
	Set (ByVal value  as Decimal )
		_RateZ = value
	End Set
End Property


Public ReadOnly Property eeslot1ColumnNames() as string
		Get 
	              	              	              return "([slot_num] , [loc_num] , [cr_pref_ac] , [dr_pref_ac] , [ufr_desc] , [ih_desc] , [dol_bud] , [hrs_bud] , [dol_pd_ytd] , [hrs_ytd] , [sched_num] , [line_num] , [allocated] , [payper_dol] , [payper_hrs] , [dfica_reg] , [dfica_aloc] , [dmed_reg] , [dmed_aloc] , [fica_ytd] , [med_ytd] , [code1] , [code2] , [wc_num] , [wc_rate] , [agency] , [fica_acct_nu] , [med_acct_nu] , [dol_pyr] , [hrs_pyr] , [rate_z] )"
		End Get
End Property

Public ReadOnly Property eeslot1ColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} )"  _  
	 , database.stringparam(_SlotNum.tostring) _ 
	 , database.stringparam(_LocNum.tostring) _ 
	 , database.stringparam(_CrPrefAc.tostring) _ 
	 , database.stringparam(_DrPrefAc.tostring) _ 
	 , database.stringparam(_UfrDesc.tostring) _ 
	 , database.stringparam(_IhDesc.tostring) _ 
	 , (_DolBud.tostring) _ 
	 , (_HrsBud.tostring) _ 
	 , (_DolPdYtd.tostring) _ 
	 , (_HrsYtd.tostring) _ 
	 , database.stringparam(_SchedNum.tostring) _ 
	 , database.stringparam(_LineNum.tostring) _ 
	 , database.stringparam(_Allocated.tostring) _ 
	 , (_PayperDol.tostring) _ 
	 , (_PayperHrs.tostring) _ 
	 , (_DficaReg.tostring) _ 
	 , (_DficaAloc.tostring) _ 
	 , (_DmedReg.tostring) _ 
	 , (_DmedAloc.tostring) _ 
	 , (_FicaYtd.tostring) _ 
	 , (_MedYtd.tostring) _ 
	 , database.stringparam(_Code1.tostring) _ 
	 , database.stringparam(_Code2.tostring) _ 
	 , database.stringparam(_WcNum.tostring) _ 
	 , (_WcRate.tostring) _ 
	 , (_Agency.tostring) _ 
	 , database.stringparam(_FicaAcctNu.tostring) _ 
	 , database.stringparam(_MedAcctNu.tostring) _ 
	 , (_DolPyr.tostring) _ 
	 , (_HrsPyr.tostring) _ 
	 , (_RateZ.tostring) _ 
)
		End Get
End Property
End Class
