Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class err835Data
	Private _ECode as String
	Private _RecNum as String
	Private _NetDol as Decimal
	Private _FromDate as Date
	Private _ToDate as Date

Public Property ECode()  as String
	Get
		Return _ECode
	End Get
	Set (ByVal value  as String )
		_ECode = value
	End Set
End Property

Public Property RecNum()  as String
	Get
		Return _RecNum
	End Get
	Set (ByVal value  as String )
		_RecNum = value
	End Set
End Property

Public Property NetDol()  as Decimal
	Get
		Return _NetDol
	End Get
	Set (ByVal value  as Decimal )
		_NetDol = value
	End Set
End Property

Public Property FromDate()  as Date
	Get
		Return _FromDate
	End Get
	Set (ByVal value  as Date )
		_FromDate = value
	End Set
End Property

Public Property ToDate()  as Date
	Get
		Return _ToDate
	End Get
	Set (ByVal value  as Date )
		_ToDate = value
	End Set
End Property


Public ReadOnly Property err835ColumnNames() as string
		Get 
	              	              	              return "([ECode] , [RecNum] , [NetDol] , [FromDate] , [ToDate] )"
		End Get
End Property

Public ReadOnly Property err835ColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} )"  _  
	 , database.stringparam(_ECode.tostring) _ 
	 , (_NetDol.tostring) _ 
	 , database.stringparam(_FromDate.toshortdatestring) _ 
	 , database.stringparam(_ToDate.toshortdatestring) _ 
)
		End Get
End Property
End Class
