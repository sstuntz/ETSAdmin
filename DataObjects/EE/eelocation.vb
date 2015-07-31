Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class locationData
	Private _LocNum as String
	Private _Desc as String
	Private _AppHrs as Double
	Private _LregHrs as Double
	Private _HrsBen as Double
	Private _SpservHrs as Double
	Private _RYtd as Double
	Private _YtdApp as Double
	Private _Lovt as Double
	Private _BenYtd as Double
	Private _OYtd as Double
	Private _AHrs as Double
	Private _BHrs as Double

Public Property LocNum()  as String
	Get
		Return _LocNum
	End Get
	Set (ByVal value  as String )
		_LocNum = value
	End Set
End Property

Public Property Desc()  as String
	Get
		Return _Desc
	End Get
	Set (ByVal value  as String )
		_Desc = value
	End Set
End Property

Public Property AppHrs()  as Double
	Get
		Return _AppHrs
	End Get
	Set (ByVal value  as Double )
		_AppHrs = value
	End Set
End Property

Public Property LregHrs()  as Double
	Get
		Return _LregHrs
	End Get
	Set (ByVal value  as Double )
		_LregHrs = value
	End Set
End Property

Public Property HrsBen()  as Double
	Get
		Return _HrsBen
	End Get
	Set (ByVal value  as Double )
		_HrsBen = value
	End Set
End Property

Public Property SpservHrs()  as Double
	Get
		Return _SpservHrs
	End Get
	Set (ByVal value  as Double )
		_SpservHrs = value
	End Set
End Property

Public Property RYtd()  as Double
	Get
		Return _RYtd
	End Get
	Set (ByVal value  as Double )
		_RYtd = value
	End Set
End Property

Public Property YtdApp()  as Double
	Get
		Return _YtdApp
	End Get
	Set (ByVal value  as Double )
		_YtdApp = value
	End Set
End Property

Public Property Lovt()  as Double
	Get
		Return _Lovt
	End Get
	Set (ByVal value  as Double )
		_Lovt = value
	End Set
End Property

Public Property BenYtd()  as Double
	Get
		Return _BenYtd
	End Get
	Set (ByVal value  as Double )
		_BenYtd = value
	End Set
End Property

Public Property OYtd()  as Double
	Get
		Return _OYtd
	End Get
	Set (ByVal value  as Double )
		_OYtd = value
	End Set
End Property

Public Property AHrs()  as Double
	Get
		Return _AHrs
	End Get
	Set (ByVal value  as Double )
		_AHrs = value
	End Set
End Property

Public Property BHrs()  as Double
	Get
		Return _BHrs
	End Get
	Set (ByVal value  as Double )
		_BHrs = value
	End Set
End Property


Public ReadOnly Property locationColumnNames() as string
		Get 
	              	              	              return "([loc_num] , [desc] , [app_hrs] , [lreg_hrs] , [hrs_ben] , [spserv_hrs] , [r-ytd] , [ytd_app] , [lovt] , [ben_ytd] , [o-ytd] , [a_hrs] , [b_hrs] )"
		End Get
End Property

Public ReadOnly Property locationColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} )"  _  
	 , database.stringparam(_LocNum.tostring) _ 
	 , database.stringparam(_Desc.tostring) _ 
	 , (_AppHrs.tostring) _ 
	 , (_LregHrs.tostring) _ 
	 , (_HrsBen.tostring) _ 
	 , (_SpservHrs.tostring) _ 
	 , (_RYtd.tostring) _ 
	 , (_YtdApp.tostring) _ 
	 , (_Lovt.tostring) _ 
	 , (_BenYtd.tostring) _ 
	 , (_OYtd.tostring) _ 
	 , (_AHrs.tostring) _ 
	 , (_BHrs.tostring) _ 
)
		End Get
End Property
End Class
