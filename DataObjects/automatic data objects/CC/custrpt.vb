Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class custrptData
	Private _RptNum as Integer
	Private _RptName as String
	Private _RptDesc as String
	Private _RptScreen as String
	Private _RptDate as String

Public Property RptNum()  as Integer
	Get
		Return _RptNum
	End Get
	Set (ByVal value  as Integer )
		_RptNum = value
	End Set
End Property

Public Property RptName()  as String
	Get
		Return _RptName
	End Get
	Set (ByVal value  as String )
		_RptName = value
	End Set
End Property

Public Property RptDesc()  as String
	Get
		Return _RptDesc
	End Get
	Set (ByVal value  as String )
		_RptDesc = value
	End Set
End Property

Public Property RptScreen()  as String
	Get
		Return _RptScreen
	End Get
	Set (ByVal value  as String )
		_RptScreen = value
	End Set
End Property

Public Property RptDate()  as String
	Get
		Return _RptDate
	End Get
	Set (ByVal value  as String )
		_RptDate = value
	End Set
End Property


Public ReadOnly Property custrptColumnNames() as string
		Get 
	              	              	              return "([RptNum] , [RptName] , [RptDesc] , [RptScreen] , [RptDate] )"
		End Get
End Property

Public ReadOnly Property custrptColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} )"  _  
	 , (_RptNum.tostring) _ 
	 , database.stringparam(_RptName.tostring) _ 
	 , database.stringparam(_RptDesc.tostring) _ 
	 , database.stringparam(_RptScreen.tostring) _ 
	 , database.stringparam(_RptDate.tostring) _ 
)
		End Get
End Property
End Class
