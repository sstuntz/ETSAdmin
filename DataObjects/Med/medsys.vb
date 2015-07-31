Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class medsysData
	Private _DefaultContractKey as String

Public Property DefaultContractKey()  as String
	Get
		Return _DefaultContractKey
	End Get
	Set (ByVal value  as String )
		_DefaultContractKey = value
	End Set
End Property


Public ReadOnly Property medsysColumnNames() as string
		Get 
	              	              	              return "([DefaultContractKey] )"
		End Get
End Property

Public ReadOnly Property medsysColumnData() as string
		Get 
	              	              	              return string.format("({0} )"  _  
	 , database.stringparam(_DefaultContractKey.tostring) _ 
)
		End Get
End Property
End Class
