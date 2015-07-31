Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class CashRctData
	Private _RptNum as String
	Private _RptPath as String
	Private _RptName as String
	Private _RptDesc as String
	Private _RptPrinter as String

Public Property RptNum()  as String
	Get
		Return _RptNum
	End Get
	Set (ByVal value  as String )
		_RptNum = value
	End Set
End Property

Public Property RptPath()  as String
	Get
		Return _RptPath
	End Get
	Set (ByVal value  as String )
		_RptPath = value
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

Public Property RptPrinter()  as String
	Get
		Return _RptPrinter
	End Get
	Set (ByVal value  as String )
		_RptPrinter = value
	End Set
End Property


Public ReadOnly Property CashRctColumnNames() as string
		Get 
	              	              	              return "([RptNum] , [RptPath] , [RptName] , [RptDesc] , [RptPrinter] )"
		End Get
End Property

Public ReadOnly Property CashRctColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} )"  _  
	 , (_RptNum) _ 
	 , (_RptPath) _ 
	 , (_RptName) _ 
	 , (_RptDesc) _ 
	 , (_RptPrinter) _ 
)
		End Get
End Property
End Class
