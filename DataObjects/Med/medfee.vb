Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class medfeeData
	Private _ProcCode as String
	Private _ProcDesc as String
	Private _DolFee as Decimal
	Private _Factor as Decimal
	Private _DolActual as Decimal
	Private _OtherRate as Decimal
	Private _Paper as String
	Private _EntryDate as Date
	Private _EffectiveDate as Date
	Private _MaxDailyUnits as Integer
	Private _Dflag as String
	Private _Void as String
	Private _Agency as Integer
	Private _MedProcCode as String

Public Property ProcCode()  as String
	Get
		Return _ProcCode
	End Get
	Set (ByVal value  as String )
		_ProcCode = value
	End Set
End Property

Public Property ProcDesc()  as String
	Get
		Return _ProcDesc
	End Get
	Set (ByVal value  as String )
		_ProcDesc = value
	End Set
End Property

Public Property DolFee()  as Decimal
	Get
		Return _DolFee
	End Get
	Set (ByVal value  as Decimal )
		_DolFee = value
	End Set
End Property

Public Property Factor()  as Decimal
	Get
		Return _Factor
	End Get
	Set (ByVal value  as Decimal )
		_Factor = value
	End Set
End Property

Public Property DolActual()  as Decimal
	Get
		Return _DolActual
	End Get
	Set (ByVal value  as Decimal )
		_DolActual = value
	End Set
End Property

Public Property OtherRate()  as Decimal
	Get
		Return _OtherRate
	End Get
	Set (ByVal value  as Decimal )
		_OtherRate = value
	End Set
End Property

Public Property Paper()  as String
	Get
		Return _Paper
	End Get
	Set (ByVal value  as String )
		_Paper = value
	End Set
End Property

Public Property EntryDate()  as Date
	Get
		Return _EntryDate
	End Get
	Set (ByVal value  as Date )
		_EntryDate = value
	End Set
End Property

Public Property EffectiveDate()  as Date
	Get
		Return _EffectiveDate
	End Get
	Set (ByVal value  as Date )
		_EffectiveDate = value
	End Set
End Property

Public Property MaxDailyUnits()  as Integer
	Get
		Return _MaxDailyUnits
	End Get
	Set (ByVal value  as Integer )
		_MaxDailyUnits = value
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

Public Property Void()  as String
	Get
		Return _Void
	End Get
	Set (ByVal value  as String )
		_Void = value
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

Public Property MedProcCode()  as String
	Get
		Return _MedProcCode
	End Get
	Set (ByVal value  as String )
		_MedProcCode = value
	End Set
End Property


Public ReadOnly Property medfeeColumnNames() as string
		Get 
	              	              	              return "([ProcCode] , [ProcDesc] , [DolFee] , [Factor] , [DolActual] , [OtherRate] , [Paper] , [EntryDate] , [EffectiveDate] , [MaxDailyUnits] , [Dflag] , [Void] , [Agency] , [MedProcCode] )"
		End Get
End Property

Public ReadOnly Property medfeeColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} )"  _  
	 , database.stringparam(_ProcCode.tostring) _ 
	 , database.stringparam(_ProcDesc.tostring) _ 
	 , (_DolFee.tostring) _ 
	 , (_Factor.tostring) _ 
	 , (_DolActual.tostring) _ 
	 , (_OtherRate.tostring) _ 
	 , database.stringparam(_Paper.tostring) _ 
	 , database.stringparam(_EntryDate.toshortdatestring) _ 
	 , database.stringparam(_EffectiveDate.toshortdatestring) _ 
	 , (_MaxDailyUnits.tostring) _ 
	 , database.stringparam(_Dflag.tostring) _ 
	 , database.stringparam(_Void.tostring) _ 
	 , (_Agency.tostring) _ 
	 , database.stringparam(_MedProcCode.tostring) _ 
)
		End Get
End Property
End Class
