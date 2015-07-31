Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class cc_clijobData
	Private _NameKey as String
	Private _ScreenNam as String
	Private _SortName as String
	Private _JobNum as String
	Private _ClPct as Decimal
	Private _Dflag as String
	Private _Agency as Integer
	Private _ClMeritDate as Date

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


Public ReadOnly Property cc_clijobColumnNames() as string
		Get 
	              	              	              return "([NameKey] , [ScreenNam] , [SortName] , [JobNum] , [ClPct] , [Dflag] , [Agency] , [ClMeritDate] )"
		End Get
End Property

Public ReadOnly Property cc_clijobColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} )"  _  
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_SortName.tostring) _ 
	 , database.stringparam(_JobNum.tostring) _ 
	 , (_ClPct.tostring) _ 
	 , database.stringparam(_Dflag.tostring) _ 
	 , (_Agency.tostring) _ 
	 , database.stringparam(_ClMeritDate.toshortdatestring) _ 
)
		End Get
End Property
End Class
