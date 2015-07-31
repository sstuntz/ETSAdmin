Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class eeslotData
	Private _NameKey as String
	Private _SlotNum as String
	Private _LocNum as String
	Private _SortName as String
	Private _Dflag as String
	Private _Agency as Integer

Public Property NameKey()  as String
	Get
		Return _NameKey
	End Get
	Set (ByVal value  as String )
		_NameKey = value
	End Set
End Property

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

Public Property SortName()  as String
	Get
		Return _SortName
	End Get
	Set (ByVal value  as String )
		_SortName = value
	End Set
End Property

Public Property Dflag()  as String
	Get
		Return _Dflag
	End Get
	Set (ByVal value  as String )
		_Dflag = value
	End Set
End Property

Public Property Agency()  as Integer
	Get
		Return _Agency
	End Get
	Set (ByVal value  as Integer )
		_Agency = value
	End Set
End Property


Public ReadOnly Property eeslotColumnNames() as string
		Get 
	              	              	              return "([name_key] , [slot_num] , [loc_num] , [sort_name] , [dflag] , [agency] )"
		End Get
End Property

Public ReadOnly Property eeslotColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} )"  _  
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_SlotNum.tostring) _ 
	 , database.stringparam(_LocNum.tostring) _ 
	 , database.stringparam(_SortName.tostring) _ 
	 , database.stringparam(_Dflag.tostring) _ 
	 , (_Agency.tostring) _ 
)
		End Get
End Property
End Class
