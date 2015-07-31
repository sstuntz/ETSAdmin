Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class cctimetmpData
	Private _EntryDate as Date
	Private _PayNum as Integer
	Private _NameKey as String
	Private _ScreenNam as String
	Private _SortName as String
	Private _PayFreq as String
	Private _DedDfq as String
	Private _EntryNum as Integer
	Private _LineNum as Integer
	Private _Date as Date
	Private _JobNum as String
	Private _PayClass as String
	Private _Hours as Decimal
	Private _PcsProd as Decimal
	Private _DeptNum as String
	Private _PayDol as Decimal
	Private _ClPct as Decimal
	Private _ChkNum as Integer
	Private _Refusal as String
	Private _Paid as String
	Private _Checked as String
	Private _Dflag as String
	Private _Agency as String
	Private _Void as String
	Private _Glpost as String
	Private _EncumDate as Date
	Private _StateTax as String
	Private _JrnlNum as Integer
	Private _JrnlLine as Integer
	Private _StartTime as Decimal
	Private _EndTime as Decimal
	Private _StartAp as Integer
	Private _EndPa as Integer
	Private _EntBy as String

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

Public Property SortName()  as String
	Get
		Return _SortName
	End Get
	Set (ByVal value  as String )
		_SortName = value
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

Public Property JobNum()  as String
	Get
		Return _JobNum
	End Get
	Set (ByVal value  as String )
		_JobNum = value
	End Set
End Property

Public Property PayClass()  as String
	Get
		Return _PayClass
	End Get
	Set (ByVal value  as String )
		_PayClass = value
	End Set
End Property

Public Property Hours()  as Decimal
	Get
		Return _Hours
	End Get
	Set (ByVal value  as Decimal )
		_Hours = value
	End Set
End Property

Public Property PcsProd()  as Decimal
	Get
		Return _PcsProd
	End Get
	Set (ByVal value  as Decimal )
		_PcsProd = value
	End Set
End Property

Public Property DeptNum()  as String
	Get
		Return _DeptNum
	End Get
	Set (ByVal value  as String )
		_DeptNum = value
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

Public Property ClPct()  as Decimal
	Get
		Return _ClPct
	End Get
	Set (ByVal value  as Decimal )
		_ClPct = value
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

Public Property Refusal()  as String
	Get
		Return _Refusal
	End Get
	Set (ByVal value  as String )
		_Refusal = value
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

Public Property Checked()  as String
	Get
		Return _Checked
	End Get
	Set (ByVal value  as String )
		_Checked = value
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

Public Property Agency()  as String
	Get
		Return _Agency
	End Get
	Set (ByVal value  as String )
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

Public Property StateTax()  as String
	Get
		Return _StateTax
	End Get
	Set (ByVal value  as String )
		_StateTax = value
	End Set
End Property

Public Property JrnlNum()  as Integer
	Get
		Return _JrnlNum
	End Get
	Set (ByVal value  as Integer )
		_JrnlNum = value
	End Set
End Property

Public Property JrnlLine()  as Integer
	Get
		Return _JrnlLine
	End Get
	Set (ByVal value  as Integer )
		_JrnlLine = value
	End Set
End Property

Public Property StartTime()  as Decimal
	Get
		Return _StartTime
	End Get
	Set (ByVal value  as Decimal )
		_StartTime = value
	End Set
End Property

Public Property EndTime()  as Decimal
	Get
		Return _EndTime
	End Get
	Set (ByVal value  as Decimal )
		_EndTime = value
	End Set
End Property

Public Property StartAp()  as Integer
	Get
		Return _StartAp
	End Get
	Set (ByVal value  as Integer )
		_StartAp = value
	End Set
End Property

Public Property EndPa()  as Integer
	Get
		Return _EndPa
	End Get
	Set (ByVal value  as Integer )
		_EndPa = value
	End Set
End Property

Public Property EntBy()  as String
	Get
		Return _EntBy
	End Get
	Set (ByVal value  as String )
		_EntBy = value
	End Set
End Property


Public ReadOnly Property cctimetmpColumnNames() as string
		Get 
	              	              	              return "([EntryDate] , [PayNum] , [NameKey] , [ScreenNam] , [SortName] , [PayFreq] , [DedDfq] , [EntryNum] , [LineNum] , [Date] , [JobNum] , [PayClass] , [Hours] , [PcsProd] , [DeptNum] , [PayDol] , [ClPct] , [ChkNum] , [Refusal] , [Paid] , [Checked] , [Dflag] , [Agency] , [Void] , [Glpost] , [EncumDate] , [StateTax] , [JrnlNum] , [JrnlLine] , [StartTime] , [EndTime] , [StartAp] , [EndPa] , [EntBy] )"
		End Get
End Property

Public ReadOnly Property cctimetmpColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} )"  _  
	 , database.stringparam(_EntryDate.toshortdatestring) _ 
	 , (_PayNum.tostring) _ 
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_SortName.tostring) _ 
	 , database.stringparam(_PayFreq.tostring) _ 
	 , database.stringparam(_DedDfq.tostring) _ 
	 , (_EntryNum.tostring) _ 
	 , (_LineNum.tostring) _ 
	 , database.stringparam(_Date.toshortdatestring) _ 
	 , database.stringparam(_JobNum.tostring) _ 
	 , database.stringparam(_PayClass.tostring) _ 
	 , (_Hours.tostring) _ 
	 , (_PcsProd.tostring) _ 
	 , database.stringparam(_DeptNum.tostring) _ 
	 , (_PayDol.tostring) _ 
	 , (_ClPct.tostring) _ 
	 , (_ChkNum.tostring) _ 
	 , database.stringparam(_Refusal.tostring) _ 
	 , database.stringparam(_Paid.tostring) _ 
	 , database.stringparam(_Checked.tostring) _ 
	 , database.stringparam(_Dflag.tostring) _ 
	 , database.stringparam(_Agency.tostring) _ 
	 , database.stringparam(_Void.tostring) _ 
	 , database.stringparam(_Glpost.tostring) _ 
	 , database.stringparam(_EncumDate.toshortdatestring) _ 
	 , database.stringparam(_StateTax.tostring) _ 
	 , (_JrnlNum.tostring) _ 
	 , (_JrnlLine.tostring) _ 
	 , (_StartTime.tostring) _ 
	 , (_EndTime.tostring) _ 
	 , (_StartAp.tostring) _ 
	 , (_EndPa.tostring) _ 
	 , database.stringparam(_EntBy.tostring) _ 
)
		End Get
End Property
End Class
