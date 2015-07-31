Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class eework1Data
	Private _EntryDate as Date
	Private _PayNum as Integer
	Private _NameKey as String
	Private _ScreenNam as String
	Private _PayFreq as String
	Private _DedDfq as String
	Private _EntryNum as Integer
	Private _Factor as Decimal
	Private _LineNum as Integer
	Private _Date as Date
	Private _SlotNum as String
	Private _LocNum as String
	Private _Reason as String
	Private _Hours as Double
	Private _TypeHours as String
	Private _Rate as Decimal
	Private _Multiplier as Decimal
	Private _PayDol as Decimal
	Private _StateTax as String
	Private _FicaGross as Decimal
	Private _FicaTax as Decimal
	Private _MedTax as Decimal
	Private _Checked as String
	Private _ChkNum as Integer
	Private _Dflag as String
	Private _Glpost as String
	Private _EncumDate as Date
	Private _Paid as String
	Private _Agency as Integer
	Private _Void as String
	Private _Alloc as String
	Private _SortName as String

Public Property EntryDate()  as Date
	Get
		Return _EntryDate
	End Get
	Set (ByVal value  as Date )
		_EntryDate = value
	End Set
End Property

Public Property PayNum()  as Integer
	Get
		Return _PayNum
	End Get
	Set (ByVal value  as Integer )
		_PayNum = value
	End Set
End Property

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

Public Property PayFreq()  as String
	Get
		Return _PayFreq
	End Get
	Set (ByVal value  as String )
		_PayFreq = value
	End Set
End Property

Public Property DedDfq()  as String
	Get
		Return _DedDfq
	End Get
	Set (ByVal value  as String )
		_DedDfq = value
	End Set
End Property

Public Property EntryNum()  as Integer
	Get
		Return _EntryNum
	End Get
	Set (ByVal value  as Integer )
		_EntryNum = value
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

Public Property LineNum()  as Integer
	Get
		Return _LineNum
	End Get
	Set (ByVal value  as Integer )
		_LineNum = value
	End Set
End Property

Public Property Date()  as Date
	Get
		Return _Date
	End Get
	Set (ByVal value  as Date )
		_Date = value
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

Public Property Reason()  as String
	Get
		Return _Reason
	End Get
	Set (ByVal value  as String )
		_Reason = value
	End Set
End Property

Public Property Hours()  as Double
	Get
		Return _Hours
	End Get
	Set (ByVal value  as Double )
		_Hours = value
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

Public Property Rate()  as Decimal
	Get
		Return _Rate
	End Get
	Set (ByVal value  as Decimal )
		_Rate = value
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

Public Property StateTax()  as String
	Get
		Return _StateTax
	End Get
	Set (ByVal value  as String )
		_StateTax = value
	End Set
End Property

Public Property FicaGross()  as Decimal
	Get
		Return _FicaGross
	End Get
	Set (ByVal value  as Decimal )
		_FicaGross = value
	End Set
End Property

Public Property FicaTax()  as Decimal
	Get
		Return _FicaTax
	End Get
	Set (ByVal value  as Decimal )
		_FicaTax = value
	End Set
End Property

Public Property MedTax()  as Decimal
	Get
		Return _MedTax
	End Get
	Set (ByVal value  as Decimal )
		_MedTax = value
	End Set
End Property

Public Property Checked()  as String
	Get
		Return _Checked
	End Get
	Set (ByVal value  as String )
		_Checked = value
	End Set
End Property

Public Property ChkNum()  as Integer
	Get
		Return _ChkNum
	End Get
	Set (ByVal value  as Integer )
		_ChkNum = value
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

Public Property Glpost()  as String
	Get
		Return _Glpost
	End Get
	Set (ByVal value  as String )
		_Glpost = value
	End Set
End Property

Public Property EncumDate()  as Date
	Get
		Return _EncumDate
	End Get
	Set (ByVal value  as Date )
		_EncumDate = value
	End Set
End Property

Public Property Paid()  as String
	Get
		Return _Paid
	End Get
	Set (ByVal value  as String )
		_Paid = value
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

Public Property Void()  as String
	Get
		Return _Void
	End Get
	Set (ByVal value  as String )
		_Void = value
	End Set
End Property

Public Property Alloc()  as String
	Get
		Return _Alloc
	End Get
	Set (ByVal value  as String )
		_Alloc = value
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


Public ReadOnly Property eework1ColumnNames() as string
		Get 
	              	              	              return "([entry_date] , [pay_num] , [name_key] , [screen_nam] , [pay_freq] , [ded_dfq] , [entry_num] , [factor] , [line_num] , [date] , [slot_num] , [loc_num] , [reason] , [hours] , [type_hours] , [rate] , [multiplier] , [pay_dol] , [state_tax] , [fica_gross] , [fica_tax] , [med_tax] , [checked] , [chk_num] , [dflag] , [glpost] , [encum_date] , [paid] , [agency] , [void] , [alloc] , [sort_name] )"
		End Get
End Property

Public ReadOnly Property eework1ColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} )"  _  
	 , database.stringparam(_EntryDate.toshortdatestring) _ 
	 , (_PayNum.tostring) _ 
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_PayFreq.tostring) _ 
	 , database.stringparam(_DedDfq.tostring) _ 
	 , (_EntryNum.tostring) _ 
	 , (_Factor.tostring) _ 
	 , (_LineNum.tostring) _ 
	 , database.stringparam(_Date.toshortdatestring) _ 
	 , database.stringparam(_SlotNum.tostring) _ 
	 , database.stringparam(_LocNum.tostring) _ 
	 , database.stringparam(_Reason.tostring) _ 
	 , (_Hours.tostring) _ 
	 , database.stringparam(_TypeHours.tostring) _ 
	 , (_Rate.tostring) _ 
	 , (_Multiplier.tostring) _ 
	 , (_PayDol.tostring) _ 
	 , database.stringparam(_StateTax.tostring) _ 
	 , (_FicaGross.tostring) _ 
	 , (_FicaTax.tostring) _ 
	 , (_MedTax.tostring) _ 
	 , database.stringparam(_Checked.tostring) _ 
	 , (_ChkNum.tostring) _ 
	 , database.stringparam(_Dflag.tostring) _ 
	 , database.stringparam(_Glpost.tostring) _ 
	 , database.stringparam(_EncumDate.toshortdatestring) _ 
	 , database.stringparam(_Paid.tostring) _ 
	 , (_Agency.tostring) _ 
	 , database.stringparam(_Void.tostring) _ 
	 , database.stringparam(_Alloc.tostring) _ 
	 , database.stringparam(_SortName.tostring) _ 
)
		End Get
End Property
End Class
