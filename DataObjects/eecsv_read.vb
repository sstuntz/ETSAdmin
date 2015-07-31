Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class csv_readData
	Private _NameKey as String
	Private _DateIn as Date
	Private _LocSlot as String
	Private _CsvHours as String
	Private _Ot1Hours as Double
	Private _Ot2Hours as Double
	Private _Rate as Decimal
	Private _LocNum as String
	Private _SlotNum as String
	Private _ScreenNam as String
	Private _SortName as String
	Private _TotHours as Double
	Private _TypeHours as String
	Private _Multiplier as Decimal
	Private _PayDol as Decimal
	Private _Reason as String
	Private _StateTax as String

Public Property NameKey()  as String
	Get
		Return _NameKey
	End Get
	Set (ByVal value  as String )
		_NameKey = value
	End Set
End Property

Public Property DateIn()  as Date
	Get
		Return _DateIn
	End Get
	Set (ByVal value  as Date )
		_DateIn = value
	End Set
End Property

Public Property LocSlot()  as String
	Get
		Return _LocSlot
	End Get
	Set (ByVal value  as String )
		_LocSlot = value
	End Set
End Property

Public Property CsvHours()  as String
	Get
		Return _CsvHours
	End Get
	Set (ByVal value  as String )
		_CsvHours = value
	End Set
End Property

Public Property Ot1Hours()  as Double
	Get
		Return _Ot1Hours
	End Get
	Set (ByVal value  as Double )
		_Ot1Hours = value
	End Set
End Property

Public Property Ot2Hours()  as Double
	Get
		Return _Ot2Hours
	End Get
	Set (ByVal value  as Double )
		_Ot2Hours = value
	End Set
End Property

Public Property Rate()  as Decimal
	Get
		Return _Rate
	End Get
	Set (ByVal value  as Decimal )
		_Rate = value
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

Public Property SlotNum()  as String
	Get
		Return _SlotNum
	End Get
	Set (ByVal value  as String )
		_SlotNum = value
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

Public Property SortName()  as String
	Get
		Return _SortName
	End Get
	Set (ByVal value  as String )
		_SortName = value
	End Set
End Property

Public Property TotHours()  as Double
	Get
		Return _TotHours
	End Get
	Set (ByVal value  as Double )
		_TotHours = value
	End Set
End Property

Public Property TypeHours()  as String
	Get
		Return _TypeHours
	End Get
	Set (ByVal value  as String )
		_TypeHours = value
	End Set
End Property

Public Property Multiplier()  as Decimal
	Get
		Return _Multiplier
	End Get
	Set (ByVal value  as Decimal )
		_Multiplier = value
	End Set
End Property

Public Property PayDol()  as Decimal
	Get
		Return _PayDol
	End Get
	Set (ByVal value  as Decimal )
		_PayDol = value
	End Set
End Property

Public Property Reason()  as String
	Get
		Return _Reason
	End Get
	Set (ByVal value  as String )
		_Reason = value
	End Set
End Property

Public Property StateTax()  as String
	Get
		Return _StateTax
	End Get
	Set (ByVal value  as String )
		_StateTax = value
	End Set
End Property


Public ReadOnly Property csv_readColumnNames() as string
		Get 
	              	              	              return "([name_key] , [date_in] , [loc_slot] , [csv_hours] , [ot1_hours] , [ot2_hours] , [rate] , [loc_num] , [slot_num] , [screen_nam] , [sort_name] , [tot_hours] , [type_hours] , [multiplier] , [pay_dol] , [reason] , [state_tax] )"
		End Get
End Property

Public ReadOnly Property csv_readColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} )"  _  
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_DateIn.toshortdatestring) _ 
	 , database.stringparam(_LocSlot.tostring) _ 
	 , database.stringparam(_CsvHours.tostring) _ 
	 , (_Ot1Hours.tostring) _ 
	 , (_Ot2Hours.tostring) _ 
	 , (_Rate.tostring) _ 
	 , database.stringparam(_LocNum.tostring) _ 
	 , database.stringparam(_SlotNum.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_SortName.tostring) _ 
	 , (_TotHours.tostring) _ 
	 , database.stringparam(_TypeHours.tostring) _ 
	 , (_Multiplier.tostring) _ 
	 , (_PayDol.tostring) _ 
	 , database.stringparam(_Reason.tostring) _ 
	 , database.stringparam(_StateTax.tostring) _ 
)
		End Get
End Property
End Class
