Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class eeallocData
	Private _SlotNum as String
	Private _LocNum as String
	Private _Factor as Double

Public Property SlotNum()  as String
	Get
		Return _SlotNum
	End Get
	Set (ByVal value  as String )
		_SlotNum = value
	End Set
End Property

Public Property LocNum()  as String
	Get
		Return _LocNum
	End Get
	Set (ByVal value  as String )
		_LocNum = value
	End Set
End Property

Public Property Factor()  as Double
	Get
		Return _Factor
	End Get
	Set (ByVal value  as Double )
		_Factor = value
	End Set
End Property


Public ReadOnly Property eeallocColumnNames() as string
		Get 
	              	              	              return "([slot_num] , [loc_num] , [factor] )"
		End Get
End Property

Public ReadOnly Property eeallocColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} )"  _  
	 , database.stringparam(_SlotNum.tostring) _ 
	 , database.stringparam(_LocNum.tostring) _ 
	 , (_Factor.tostring) _ 
)
		End Get
End Property
End Class
