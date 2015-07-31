Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class referenceData
	Private _FormName as String
	Private _CtrlName as String
	Private _Datum as String
	Private _DatumDesc as String

Public Property FormName()  as String
	Get
		Return _FormName
	End Get
	Set (ByVal value  as String )
		_FormName = value
	End Set
End Property

Public Property CtrlName()  as String
	Get
		Return _CtrlName
	End Get
	Set (ByVal value  as String )
		_CtrlName = value
	End Set
End Property

Public Property Datum()  as String
	Get
		Return _Datum
	End Get
	Set (ByVal value  as String )
		_Datum = value
	End Set
End Property

Public Property DatumDesc()  as String
	Get
		Return _DatumDesc
	End Get
	Set (ByVal value  as String )
		_DatumDesc = value
	End Set
End Property


Public ReadOnly Property referenceColumnNames() as string
		Get 
	              	              	              return "([FormName] , [CtrlName] , [Datum] , [DatumDesc] )"
		End Get
End Property

Public ReadOnly Property referenceColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} )"  _  
	 , database.stringparam(_FormName.tostring) _ 
	 , database.stringparam(_CtrlName.tostring) _ 
	 , database.stringparam(_Datum.tostring) _ 
	 , database.stringparam(_DatumDesc.tostring) _ 
)
		End Get
End Property
End Class
