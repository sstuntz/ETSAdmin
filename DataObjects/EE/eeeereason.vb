Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class eereasonData
	Private _Reason as String
	Private _ReasDesc as String
	Private _Hourly as String
	Private _Dflag as String
	Private _Agency as Integer

Public Property Reason()  as String
	Get
		Return _Reason
	End Get
	Set (ByVal value  as String )
		_Reason = value
	End Set
End Property

Public Property ReasDesc()  as String
	Get
		Return _ReasDesc
	End Get
	Set (ByVal value  as String )
		_ReasDesc = value
	End Set
End Property

Public Property Hourly()  as String
	Get
		Return _Hourly
	End Get
	Set (ByVal value  as String )
		_Hourly = value
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


Public ReadOnly Property eereasonColumnNames() as string
		Get 
	              	              	              return "([reason] , [reas_desc] , [hourly] , [dflag] , [agency] )"
		End Get
End Property

Public ReadOnly Property eereasonColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} )"  _  
	 , database.stringparam(_Reason.tostring) _ 
	 , database.stringparam(_ReasDesc.tostring) _ 
	 , database.stringparam(_Hourly.tostring) _ 
	 , database.stringparam(_Dflag.tostring) _ 
	 , (_Agency.tostring) _ 
)
		End Get
End Property
End Class
