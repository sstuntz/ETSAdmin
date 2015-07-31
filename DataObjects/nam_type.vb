Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class nam_typeData
	Private _NameKey as String
	Private _ScreenNam as String
	Private _Type as String

Public Property NameKey()  as String
	Get
		Return _NameKey
	End Get
	Set (ByVal value  as String )
		_NameKey = value
	End Set
End Property

Public Property ScreenNam()  as String
	Get
		Return _ScreenNam
	End Get
	Set (ByVal value  as String )
		_ScreenNam = value
	End Set
End Property

Public Property Type()  as String
	Get
		Return _Type
	End Get
	Set (ByVal value  as String )
		_Type = value
	End Set
End Property


Public ReadOnly Property nam_typeColumnNames() as string
		Get 
	              	              	              return "([NameKey] , [ScreenNam] , [Type] )"
		End Get
End Property

Public ReadOnly Property nam_typeColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} )"  _  
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_Type.tostring) _ 
)
		End Get
End Property
End Class
