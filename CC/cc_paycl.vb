Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class cc_payclData
	Private _PayClass as String
	Private _PayDesc as String
	Private _Hours as String
	Private _Pieces as String
	Private _Pay as String
	Private _Type as String

Public Property PayClass()  as String
	Get
		Return _PayClass
	End Get
	Set (ByVal value  as String )
		_PayClass = value
	End Set
End Property

Public Property PayDesc()  as String
	Get
		Return _PayDesc
	End Get
	Set (ByVal value  as String )
		_PayDesc = value
	End Set
End Property

Public Property Hours()  as String
	Get
		Return _Hours
	End Get
	Set (ByVal value  as String )
		_Hours = value
	End Set
End Property

Public Property Pieces()  as String
	Get
		Return _Pieces
	End Get
	Set (ByVal value  as String )
		_Pieces = value
	End Set
End Property

Public Property Pay()  as String
	Get
		Return _Pay
	End Get
	Set (ByVal value  as String )
		_Pay = value
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


Public ReadOnly Property cc_payclColumnNames() as string
		Get 
	              	              	              return "([pay_class] , [pay_desc] , [hours] , [pieces] , [pay] , [type] )"
		End Get
End Property

Public ReadOnly Property cc_payclColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} )"  _  
	 , database.stringparam(_PayClass.tostring) _ 
	 , database.stringparam(_PayDesc.tostring) _ 
	 , database.stringparam(_Hours.tostring) _ 
	 , database.stringparam(_Pieces.tostring) _ 
	 , database.stringparam(_Pay.tostring) _ 
	 , database.stringparam(_Type.tostring) _ 
)
		End Get
End Property
End Class
