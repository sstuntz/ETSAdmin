Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

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
    Private _Cost1 As String
    Private _Cost2 As String
	Private _Cost3 as String
	Private _Cost4 as String
    Private _Cost5 As String
    Private _ContractKey As String
    Private _Billable As String
    Private _ADPCode As String

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

    Public Property Cost1() As String
        Get
            Return _Cost1
        End Get
        Set(ByVal value As String)
            _Cost1 = value
        End Set
    End Property

    Public Property Cost2() As String
        Get
            Return _Cost2
        End Get
        Set(ByVal value As String)
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

    Public Property ContractKey() As String
        Get
            Return _ContractKey
        End Get
        Set(ByVal value As String)
            _ContractKey = value
        End Set
    End Property

    Public Property Billable() As String
        Get
            Return _Billable
        End Get
        Set(ByVal value As String)
            _Billable = value
        End Set
    End Property

    Public Property ADPCode() As String
        Get
            Return _ADPCode
        End Get
        Set(ByVal value As String)
            _ADPCode = value
        End Set
    End Property

Public ReadOnly Property ccjobColumnNames() as string
		Get 
            Return "([job_num] , [job_desc] , [name_key] , [screen_nam] , [sort_name] , [pay_class] , [type] , [prev_rate] , [pcs_hr] , [rate_hr] , [pc_rate] , [min_wage] , [step_grp] , [final] , [sell_prc] , [dept_num] , [t_s_date] , [wc_num] , [wc_rate] , [dflag] , [agency] , [difficulty] , [payper_dol] , [payper_hrs] , [dol_pd_ytd] , [hrs_ytd] , [dol_pyr] , [hrs_pyr] , [dr_acct_nu] , [cr_acct_nu] , [jrnl_num] , [jrnl_line] , [bill_rate] , [spvr_rate] , [hwb] , [payper_pcs] , [pcs_ytd] , [pcs_pyr] , [Cost1] , [Cost2] , [cost3] , [cost4] , [cost5], [ContractKey], [Billable], [adp_code] )"
		End Get
End Property

Public ReadOnly Property ccjobColumnData() as string
		Get 
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} , {43}, {44}, {45} )" _
, Database.StringParam(_JobNum.ToString) _
, Database.StringParam(_JobDesc.ToString) _
, Database.StringParam(_NameKey.ToString) _
, Database.StringParam(_ScreenNam.ToString) _
, Database.StringParam(_SortName.ToString) _
, Database.StringParam(_PayClass.ToString) _
, Database.StringParam(_Type.ToString) _
, (_PrevRate.ToString) _
, (_PcsHr.ToString) _
, (_RateHr.ToString) _
, (_PcRate.ToString) _
, (_MinWage.ToString) _
, Database.StringParam(_StepGrp.ToString) _
, Database.StringParam(_Final.ToString) _
, (_SellPrc.ToString) _
, Database.StringParam(_DeptNum.ToString) _
, Database.StringParam(_TSDate.ToShortDateString) _
, Database.StringParam(_WcNum.ToString) _
, (_WcRate.ToString) _
, Database.StringParam(_Dflag.ToString) _
, Database.StringParam(_Agency.ToString) _
, Database.StringParam(_Difficulty.ToString) _
, (_PayperDol.ToString) _
, (_PayperHrs.ToString) _
, (_DolPdYtd.ToString) _
, (_HrsYtd.ToString) _
, (_DolPyr.ToString) _
, (_HrsPyr.ToString) _
, Database.StringParam(_DrAcctNu.ToString) _
, Database.StringParam(_CrAcctNu.ToString) _
, (_JrnlNum.ToString) _
, (_JrnlLine.ToString) _
, (_BillRate.ToString) _
, (_SpvrRate.ToString) _
, (_Hwb.ToString) _
, (_PayperPcs.ToString) _
, (_PcsYtd.ToString) _
, (_PcsPyr.ToString) _
, Database.StringParam(_Cost1.ToString) _
, Database.StringParam(_Cost2.ToString) _
, Database.StringParam(_Cost3.ToString) _
, Database.StringParam(_Cost4.ToString) _
, Database.StringParam(_Cost5.ToString) _
, Database.StringParam(_ContractKey.ToString) _
, Database.StringParam(_Billable.ToString) _
, Database.StringParam(_ADPCode.ToString) _
)
		End Get
End Property
End Class
