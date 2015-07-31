Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class cc_clijobData
	Private _NameKey as String
	Private _ScreenNam as String
	Private _SortName as String
	Private _JobNum as String
	Private _ClPct as Decimal
	Private _Dflag as String
	Private _Agency as Integer
    Private _ClMeritDate As Date
    Private _StartDate As Date

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

Public Property JobNum()  as String
	Get
		Return _JobNum
	End Get
	Set (ByVal value  as String )
		_JobNum = value
	End Set
End Property

Public Property ClPct()  as Decimal
	Get
		Return _ClPct
	End Get
	Set (ByVal value  as Decimal )
		_ClPct = value
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

Public Property ClMeritDate()  as Date
	Get
		Return _ClMeritDate
	End Get
	Set (ByVal value  as Date )
		_ClMeritDate = value
	End Set
End Property


    Public Property StartDate() As Date
        Get
            Return _StartDate
        End Get
        Set(ByVal value As Date)
            _StartDate = value
        End Set
    End Property

Public ReadOnly Property cc_clijobColumnNames() as string
		Get 
            Return "([name_key] , [screen_nam] , [sort_name] , [job_num] , [cl_pct] , [dflag] , [agency] , [cl_merit_Date], [start_date] )"
		End Get
End Property

Public ReadOnly Property cc_clijobColumnData() as string
		Get 
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} )" _
  , Database.StringParam(_NameKey.ToString) _
  , Database.StringParam(_ScreenNam.ToString) _
  , Database.StringParam(_SortName.ToString) _
  , Database.StringParam(_JobNum.ToString) _
  , (_ClPct.ToString) _
  , Database.StringParam(_Dflag.ToString) _
  , (_Agency.ToString) _
  , Database.StringParam(_ClMeritDate.ToShortDateString) _
  , Database.StringParam(_StartDate.ToShortDateString) _
)
		End Get
End Property
End Class
