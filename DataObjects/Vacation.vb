Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports PS.Common


Public Class VacationData
	Private _NameKey as String
	Private _ScreenNam as String
	Private _Code1Num as String
	Private _Code2Num as String
	Private _VAccrual as Double
	Private _HAccrual as Double
	Private _SAccrual as Double
	Private _PAccrual as Double
	Private _Months as Double
	Private _HrsWeek as Double
	Private _VbegDate as Date
	Private _HbegDate as Date
	Private _SbegDate as Date
	Private _PbegDate as Date
	Private _MaxVac as Double
	Private _UsedVac as Double
	Private _RemVac as Double
	Private _LimitVac as Double
	Private _MaxHol as Double
	Private _UsedHol as Double
	Private _RemHol as Double
	Private _LimitHol as Double
	Private _MaxSick as Double
	Private _UsedSick as Double
	Private _RemSick as Double
	Private _LimitSick as Double
	Private _MaxPers as Double
	Private _UsedPers as Double
	Private _RemPers as Double
	Private _LimitPers as Double
	Private _Agency as Integer
	Private _AccrualCnt as Integer
	Private _AccElig as String
	Private _TermVacPaid as Date

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

Public Property Code1Num()  as String
	Get
		Return _Code1Num
	End Get
	Set (ByVal value  as String )
		_Code1Num = value
	End Set
End Property

Public Property Code2Num()  as String
	Get
		Return _Code2Num
	End Get
	Set (ByVal value  as String )
		_Code2Num = value
	End Set
End Property

Public Property VAccrual()  as Double
	Get
		Return _VAccrual
	End Get
	Set (ByVal value  as Double )
		_VAccrual = value
	End Set
End Property

Public Property HAccrual()  as Double
	Get
		Return _HAccrual
	End Get
	Set (ByVal value  as Double )
		_HAccrual = value
	End Set
End Property

Public Property SAccrual()  as Double
	Get
		Return _SAccrual
	End Get
	Set (ByVal value  as Double )
		_SAccrual = value
	End Set
End Property

Public Property PAccrual()  as Double
	Get
		Return _PAccrual
	End Get
	Set (ByVal value  as Double )
		_PAccrual = value
	End Set
End Property

Public Property Months()  as Double
	Get
		Return _Months
	End Get
	Set (ByVal value  as Double )
		_Months = value
	End Set
End Property

Public Property HrsWeek()  as Double
	Get
		Return _HrsWeek
	End Get
	Set (ByVal value  as Double )
		_HrsWeek = value
	End Set
End Property

Public Property VbegDate()  as Date
	Get
		Return _VbegDate
	End Get
	Set (ByVal value  as Date )
		_VbegDate = value
	End Set
End Property

Public Property HbegDate()  as Date
	Get
		Return _HbegDate
	End Get
	Set (ByVal value  as Date )
		_HbegDate = value
	End Set
End Property

Public Property SbegDate()  as Date
	Get
		Return _SbegDate
	End Get
	Set (ByVal value  as Date )
		_SbegDate = value
	End Set
End Property

Public Property PbegDate()  as Date
	Get
		Return _PbegDate
	End Get
	Set (ByVal value  as Date )
		_PbegDate = value
	End Set
End Property

Public Property MaxVac()  as Double
	Get
		Return _MaxVac
	End Get
	Set (ByVal value  as Double )
		_MaxVac = value
	End Set
End Property

Public Property UsedVac()  as Double
	Get
		Return _UsedVac
	End Get
	Set (ByVal value  as Double )
		_UsedVac = value
	End Set
End Property

Public Property RemVac()  as Double
	Get
		Return _RemVac
	End Get
	Set (ByVal value  as Double )
		_RemVac = value
	End Set
End Property

Public Property LimitVac()  as Double
	Get
		Return _LimitVac
	End Get
	Set (ByVal value  as Double )
		_LimitVac = value
	End Set
End Property

Public Property MaxHol()  as Double
	Get
		Return _MaxHol
	End Get
	Set (ByVal value  as Double )
		_MaxHol = value
	End Set
End Property

Public Property UsedHol()  as Double
	Get
		Return _UsedHol
	End Get
	Set (ByVal value  as Double )
		_UsedHol = value
	End Set
End Property

Public Property RemHol()  as Double
	Get
		Return _RemHol
	End Get
	Set (ByVal value  as Double )
		_RemHol = value
	End Set
End Property

Public Property LimitHol()  as Double
	Get
		Return _LimitHol
	End Get
	Set (ByVal value  as Double )
		_LimitHol = value
	End Set
End Property

Public Property MaxSick()  as Double
	Get
		Return _MaxSick
	End Get
	Set (ByVal value  as Double )
		_MaxSick = value
	End Set
End Property

Public Property UsedSick()  as Double
	Get
		Return _UsedSick
	End Get
	Set (ByVal value  as Double )
		_UsedSick = value
	End Set
End Property

Public Property RemSick()  as Double
	Get
		Return _RemSick
	End Get
	Set (ByVal value  as Double )
		_RemSick = value
	End Set
End Property

Public Property LimitSick()  as Double
	Get
		Return _LimitSick
	End Get
	Set (ByVal value  as Double )
		_LimitSick = value
	End Set
End Property

Public Property MaxPers()  as Double
	Get
		Return _MaxPers
	End Get
	Set (ByVal value  as Double )
		_MaxPers = value
	End Set
End Property

Public Property UsedPers()  as Double
	Get
		Return _UsedPers
	End Get
	Set (ByVal value  as Double )
		_UsedPers = value
	End Set
End Property

Public Property RemPers()  as Double
	Get
		Return _RemPers
	End Get
	Set (ByVal value  as Double )
		_RemPers = value
	End Set
End Property

Public Property LimitPers()  as Double
	Get
		Return _LimitPers
	End Get
	Set (ByVal value  as Double )
		_LimitPers = value
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

Public Property AccrualCnt()  as Integer
	Get
		Return _AccrualCnt
	End Get
	Set (ByVal value  as Integer )
		_AccrualCnt = value
	End Set
End Property

Public Property AccElig()  as String
	Get
		Return _AccElig
	End Get
	Set (ByVal value  as String )
		_AccElig = value
	End Set
End Property

Public Property TermVacPaid()  as Date
	Get
		Return _TermVacPaid
	End Get
	Set (ByVal value  as Date )
		_TermVacPaid = value
	End Set
End Property


Public ReadOnly Property VacationColumnNames() as string
		Get 
	              	              	              return "([name_key] , [screen_nam] , [code1_num] , [code2_num] , [v_accrual] , [h_accrual] , [s_accrual] , [p_accrual] , [months] , [hrs_week] , [vbeg_date] , [hbeg_date] , [sbeg_date] , [pbeg_date] , [max_vac] , [used_vac] , [rem_vac] , [limit_vac] , [max_hol] , [used_hol] , [rem_hol] , [limit_hol] , [max_sick] , [used_sick] , [rem_sick] , [limit_sick] , [max_pers] , [used_pers] , [rem_pers] , [limit_pers] , [agency] , [accrual_cnt] , [acc_elig] , [term_vac_paid] )"
		End Get
End Property

Public ReadOnly Property VacationColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} )"  _  
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_Code1Num.tostring) _ 
	 , database.stringparam(_Code2Num.tostring) _ 
	 , (_VAccrual.tostring) _ 
	 , (_HAccrual.tostring) _ 
	 , (_SAccrual.tostring) _ 
	 , (_PAccrual.tostring) _ 
	 , (_Months.tostring) _ 
	 , (_HrsWeek.tostring) _ 
	 , database.stringparam(_VbegDate.toshortdatestring) _ 
	 , database.stringparam(_HbegDate.toshortdatestring) _ 
	 , database.stringparam(_SbegDate.toshortdatestring) _ 
	 , database.stringparam(_PbegDate.toshortdatestring) _ 
	 , (_MaxVac.tostring) _ 
	 , (_UsedVac.tostring) _ 
	 , (_RemVac.tostring) _ 
	 , (_LimitVac.tostring) _ 
	 , (_MaxHol.tostring) _ 
	 , (_UsedHol.tostring) _ 
	 , (_RemHol.tostring) _ 
	 , (_LimitHol.tostring) _ 
	 , (_MaxSick.tostring) _ 
	 , (_UsedSick.tostring) _ 
	 , (_RemSick.tostring) _ 
	 , (_LimitSick.tostring) _ 
	 , (_MaxPers.tostring) _ 
	 , (_UsedPers.tostring) _ 
	 , (_RemPers.tostring) _ 
	 , (_LimitPers.tostring) _ 
	 , (_Agency.tostring) _ 
	 , (_AccrualCnt.tostring) _ 
	 , database.stringparam(_AccElig.tostring) _ 
	 , database.stringparam(_TermVacPaid.toshortdatestring) _ 
)
		End Get
End Property
End Class
