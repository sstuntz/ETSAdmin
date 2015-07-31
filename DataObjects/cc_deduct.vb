Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class cc_deductData
	Private _DedNum as String
	Private _DedDol as Decimal
	Private _NameKey as String
	Private _ScreenNam as String
	Private _PlanDesc as String
	Private _DrAcctNu as String
	Private _CrAcctNu as String
	Private _DedType as String
	Private _ChngDate as Date
	Private _DedDate as Date
	Private _Dlfag as String
	Private _Agency as Integer
	Private _StateCode as String
	Private _MaxAmount as Decimal
	Private _Dduct1Num as String
	Private _Dduct2Num as String
	Private _Dduct3Num as String
	Private _Dduct4Num as String

Public Property DedNum()  as String
	Get
		Return _DedNum
	End Get
	Set (ByVal value  as String )
		_DedNum = value
	End Set
End Property

Public Property DedDol()  as Decimal
	Get
		Return _DedDol
	End Get
	Set (ByVal value  as Decimal )
		_DedDol = value
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

Public Property PlanDesc()  as String
	Get
		Return _PlanDesc
	End Get
	Set (ByVal value  as String )
		_PlanDesc = value
	End Set
End Property

Public Property DrAcctNu()  as String
	Get
		Return _DrAcctNu
	End Get
	Set (ByVal value  as String )
		_DrAcctNu = value
	End Set
End Property

Public Property CrAcctNu()  as String
	Get
		Return _CrAcctNu
	End Get
	Set (ByVal value  as String )
		_CrAcctNu = value
	End Set
End Property

Public Property DedType()  as String
	Get
		Return _DedType
	End Get
	Set (ByVal value  as String )
		_DedType = value
	End Set
End Property

Public Property ChngDate()  as Date
	Get
		Return _ChngDate
	End Get
	Set (ByVal value  as Date )
		_ChngDate = value
	End Set
End Property

Public Property DedDate()  as Date
	Get
		Return _DedDate
	End Get
	Set (ByVal value  as Date )
		_DedDate = value
	End Set
End Property

Public Property Dlfag()  as String
	Get
		Return _Dlfag
	End Get
	Set (ByVal value  as String )
		_Dlfag = value
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

Public Property StateCode()  as String
	Get
		Return _StateCode
	End Get
	Set (ByVal value  as String )
		_StateCode = value
	End Set
End Property

Public Property MaxAmount()  as Decimal
	Get
		Return _MaxAmount
	End Get
	Set (ByVal value  as Decimal )
		_MaxAmount = value
	End Set
End Property

Public Property Dduct1Num()  as String
	Get
		Return _Dduct1Num
	End Get
	Set (ByVal value  as String )
		_Dduct1Num = value
	End Set
End Property

Public Property Dduct2Num()  as String
	Get
		Return _Dduct2Num
	End Get
	Set (ByVal value  as String )
		_Dduct2Num = value
	End Set
End Property

Public Property Dduct3Num()  as String
	Get
		Return _Dduct3Num
	End Get
	Set (ByVal value  as String )
		_Dduct3Num = value
	End Set
End Property

Public Property Dduct4Num()  as String
	Get
		Return _Dduct4Num
	End Get
	Set (ByVal value  as String )
		_Dduct4Num = value
	End Set
End Property


Public ReadOnly Property cc_deductColumnNames() as string
		Get 
	              	              	              return "([DedNum] , [DedDol] , [NameKey] , [ScreenNam] , [PlanDesc] , [DrAcctNu] , [CrAcctNu] , [DedType] , [ChngDate] , [DedDate] , [Dlfag] , [Agency] , [StateCode] , [MaxAmount] , [Dduct1Num] , [Dduct2Num] , [Dduct3Num] , [Dduct4Num] )"
		End Get
End Property

Public ReadOnly Property cc_deductColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} )"  _  
	 , database.stringparam(_DedNum.tostring) _ 
	 , (_DedDol.tostring) _ 
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_PlanDesc.tostring) _ 
	 , database.stringparam(_DrAcctNu.tostring) _ 
	 , database.stringparam(_CrAcctNu.tostring) _ 
	 , database.stringparam(_DedType.tostring) _ 
	 , database.stringparam(_ChngDate.toshortdatestring) _ 
	 , database.stringparam(_DedDate.toshortdatestring) _ 
	 , database.stringparam(_Dlfag.tostring) _ 
	 , (_Agency.tostring) _ 
	 , database.stringparam(_StateCode.tostring) _ 
	 , (_MaxAmount.tostring) _ 
	 , database.stringparam(_Dduct1Num.tostring) _ 
	 , database.stringparam(_Dduct2Num.tostring) _ 
	 , database.stringparam(_Dduct3Num.tostring) _ 
	 , database.stringparam(_Dduct4Num.tostring) _ 
)
		End Get
End Property
End Class
