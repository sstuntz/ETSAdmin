Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class diag_codesData
	Private _DsmNum as String
	Private _DsmGroup as String
	Private _DsmDesc as String

Public Property DsmNum()  as String
	Get
		Return _DsmNum
	End Get
	Set (ByVal value  as String )
		_DsmNum = value
	End Set
End Property

Public Property DsmGroup()  as String
	Get
		Return _DsmGroup
	End Get
	Set (ByVal value  as String )
		_DsmGroup = value
	End Set
End Property

Public Property DsmDesc()  as String
	Get
		Return _DsmDesc
	End Get
	Set (ByVal value  as String )
		_DsmDesc = value
	End Set
End Property


Public ReadOnly Property diag_codesColumnNames() as string
		Get 
	              	              	              return "([DsmNum] , [DsmGroup] , [DsmDesc] )"
		End Get
End Property

Public ReadOnly Property diag_codesColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} )"  _  
	 , database.stringparam(_DsmNum.tostring) _ 
	 , database.stringparam(_DsmGroup.tostring) _ 
	 , database.stringparam(_DsmDesc.tostring) _ 
)
		End Get
End Property
End Class
