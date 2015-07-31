Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class cc_disabData
	Private _DisabNum as String
	Private _DisabDesc as String

Public Property DisabNum()  as String
	Get
		Return _DisabNum
	End Get
	Set (ByVal value  as String )
		_DisabNum = value
	End Set
End Property

Public Property DisabDesc()  as String
	Get
		Return _DisabDesc
	End Get
	Set (ByVal value  as String )
		_DisabDesc = value
	End Set
End Property


Public ReadOnly Property cc_disabColumnNames() as string
		Get 
	              	              	              return "([DisabNum] , [DisabDesc] )"
		End Get
End Property

Public ReadOnly Property cc_disabColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} )"  _  
	 , database.stringparam(_DisabNum.tostring) _ 
	 , database.stringparam(_DisabDesc.tostring) _ 
)
		End Get
End Property
End Class
