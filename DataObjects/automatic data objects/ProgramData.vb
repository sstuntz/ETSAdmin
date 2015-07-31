Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class CashRctData
	Private _ProgNum as String
	Private _ProgDesc as String
	Private _ProgRate as Decimal
	Private _Division as String
	Private _FiscalYr as String
	Private _Location as String
	Private _UfrNum as String
	Private _EntryDate as Date

Public Property ProgNum()  as String
	Get
		Return _ProgNum
	End Get
	Set (ByVal value  as String )
		_ProgNum = value
	End Set
End Property

Public Property ProgDesc()  as String
	Get
		Return _ProgDesc
	End Get
	Set (ByVal value  as String )
		_ProgDesc = value
	End Set
End Property

Public Property ProgRate()  as Decimal
	Get
		Return _ProgRate
	End Get
	Set (ByVal value  as Decimal )
		_ProgRate = value
	End Set
End Property

Public Property Division()  as String
	Get
		Return _Division
	End Get
	Set (ByVal value  as String )
		_Division = value
	End Set
End Property

Public Property FiscalYr()  as String
	Get
		Return _FiscalYr
	End Get
	Set (ByVal value  as String )
		_FiscalYr = value
	End Set
End Property

Public Property Location()  as String
	Get
		Return _Location
	End Get
	Set (ByVal value  as String )
		_Location = value
	End Set
End Property

Public Property UfrNum()  as String
	Get
		Return _UfrNum
	End Get
	Set (ByVal value  as String )
		_UfrNum = value
	End Set
End Property

Public Property EntryDate()  as Date
	Get
		Return _EntryDate
	End Get
	Set (ByVal value  as Date )
		_EntryDate = value
	End Set
End Property


Public ReadOnly Property CashRctColumnNames() as string
		Get 
	              	              	              return "([ProgNum] , [ProgDesc] , [ProgRate] , [Division] , [FiscalYr] , [Location] , [UfrNum] , [EntryDate] )"
		End Get
End Property

Public ReadOnly Property CashRctColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} )"  _  
	 , (_ProgNum) _ 
	 , (_ProgDesc) _ 
	 , (_ProgRate) _ 
	 , (_Division) _ 
	 , (_FiscalYr) _ 
	 , (_Location) _ 
	 , (_UfrNum) _ 
	 , (_EntryDate) _ 
)
		End Get
End Property
End Class
