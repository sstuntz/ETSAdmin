Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class type_sourceData
	Private _TypeNames as String

Public Property TypeNames()  as String
	Get
		Return _TypeNames
	End Get
	Set (ByVal value  as String )
		_TypeNames = value
	End Set
End Property


Public ReadOnly Property type_sourceColumnNames() as string
		Get 
	              	              	              return "([TypeNames] )"
		End Get
End Property

Public ReadOnly Property type_sourceColumnData() as string
		Get 
	              	              	              return string.format("({0} )"  _  
	 , database.stringparam(_TypeNames.tostring) _ 
)
		End Get
End Property
End Class
