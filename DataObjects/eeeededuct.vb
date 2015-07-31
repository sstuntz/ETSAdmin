Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class eedeductData
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
	Private _ANtNum as String
	Private _BNtNum as String
	Private _CNtNum as String
	Private _DNtNum as String
	Private _ENtNum as String
	Private _FlxNtNum as String
	Private _DepNtNum as String
	Private _Pen1aNum as String
	Private _Pen1bNum as String
	Private _Pen2aNum as String
	Private _Pen2bNum as String
	Private _Pen3aNum as String
	Private _Pen3bNum as String
	Private _Save1Num as String
	Private _Save2Num as String
	Private _Save3Num as String
	Private _Dduct1Num as String
	Private _Dduct2Num as String
	Private _Dduct3Num as String
	Private _Dduct4Num as String
	Private _Dduct5Num as String
	Private _Dduct6Num as String
	Private _Dduct7Num as String
	Private _Dduct8Num as String
	Private _Dduct9Num as String
	Private _Misc1Num as String
	Private _Misc2Num as String
	Private _Spread as String

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

Public Property ANtNum()  as String
	Get
		Return _ANtNum
	End Get
	Set (ByVal value  as String )
		_ANtNum = value
	End Set
End Property

Public Property BNtNum()  as String
	Get
		Return _BNtNum
	End Get
	Set (ByVal value  as String )
		_BNtNum = value
	End Set
End Property

Public Property CNtNum()  as String
	Get
		Return _CNtNum
	End Get
	Set (ByVal value  as String )
		_CNtNum = value
	End Set
End Property

Public Property DNtNum()  as String
	Get
		Return _DNtNum
	End Get
	Set (ByVal value  as String )
		_DNtNum = value
	End Set
End Property

Public Property ENtNum()  as String
	Get
		Return _ENtNum
	End Get
	Set (ByVal value  as String )
		_ENtNum = value
	End Set
End Property

Public Property FlxNtNum()  as String
	Get
		Return _FlxNtNum
	End Get
	Set (ByVal value  as String )
		_FlxNtNum = value
	End Set
End Property

Public Property DepNtNum()  as String
	Get
		Return _DepNtNum
	End Get
	Set (ByVal value  as String )
		_DepNtNum = value
	End Set
End Property

Public Property Pen1aNum()  as String
	Get
		Return _Pen1aNum
	End Get
	Set (ByVal value  as String )
		_Pen1aNum = value
	End Set
End Property

Public Property Pen1bNum()  as String
	Get
		Return _Pen1bNum
	End Get
	Set (ByVal value  as String )
		_Pen1bNum = value
	End Set
End Property

Public Property Pen2aNum()  as String
	Get
		Return _Pen2aNum
	End Get
	Set (ByVal value  as String )
		_Pen2aNum = value
	End Set
End Property

Public Property Pen2bNum()  as String
	Get
		Return _Pen2bNum
	End Get
	Set (ByVal value  as String )
		_Pen2bNum = value
	End Set
End Property

Public Property Pen3aNum()  as String
	Get
		Return _Pen3aNum
	End Get
	Set (ByVal value  as String )
		_Pen3aNum = value
	End Set
End Property

Public Property Pen3bNum()  as String
	Get
		Return _Pen3bNum
	End Get
	Set (ByVal value  as String )
		_Pen3bNum = value
	End Set
End Property

Public Property Save1Num()  as String
	Get
		Return _Save1Num
	End Get
	Set (ByVal value  as String )
		_Save1Num = value
	End Set
End Property

Public Property Save2Num()  as String
	Get
		Return _Save2Num
	End Get
	Set (ByVal value  as String )
		_Save2Num = value
	End Set
End Property

Public Property Save3Num()  as String
	Get
		Return _Save3Num
	End Get
	Set (ByVal value  as String )
		_Save3Num = value
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

Public Property Dduct5Num()  as String
	Get
		Return _Dduct5Num
	End Get
	Set (ByVal value  as String )
		_Dduct5Num = value
	End Set
End Property

Public Property Dduct6Num()  as String
	Get
		Return _Dduct6Num
	End Get
	Set (ByVal value  as String )
		_Dduct6Num = value
	End Set
End Property

Public Property Dduct7Num()  as String
	Get
		Return _Dduct7Num
	End Get
	Set (ByVal value  as String )
		_Dduct7Num = value
	End Set
End Property

Public Property Dduct8Num()  as String
	Get
		Return _Dduct8Num
	End Get
	Set (ByVal value  as String )
		_Dduct8Num = value
	End Set
End Property

Public Property Dduct9Num()  as String
	Get
		Return _Dduct9Num
	End Get
	Set (ByVal value  as String )
		_Dduct9Num = value
	End Set
End Property

Public Property Misc1Num()  as String
	Get
		Return _Misc1Num
	End Get
	Set (ByVal value  as String )
		_Misc1Num = value
	End Set
End Property

Public Property Misc2Num()  as String
	Get
		Return _Misc2Num
	End Get
	Set (ByVal value  as String )
		_Misc2Num = value
	End Set
End Property

Public Property Spread()  as String
	Get
		Return _Spread
	End Get
	Set (ByVal value  as String )
		_Spread = value
	End Set
End Property


Public ReadOnly Property eedeductColumnNames() as string
		Get 
	              	              	              return "([ded_num] , [ded_dol] , [name_key] , [screen_nam] , [plan_desc] , [dr_acct_nu] , [cr_acct_nu] , [ded_type] , [chng_date] , [ded_date] , [dlfag] , [agency] , [state_code] , [max_amount] , [a_nt_num] , [b_nt_num] , [c_nt_num] , [d_nt_num] , [e_nt_num] , [flx_nt_num] , [dep_nt_num] , [pen1a_num] , [pen1b_num] , [pen2a_num] , [pen2b_num] , [pen3a_num] , [pen3b_num] , [save1_num] , [save2_num] , [save3_num] , [dduct1_num] , [dduct2_num] , [dduct3_num] , [dduct4_num] , [dduct5_num] , [dduct6_num] , [dduct7_num] , [dduct8_num] , [dduct9_num] , [misc1_num] , [misc2_num] , [spread] )"
		End Get
End Property

Public ReadOnly Property eedeductColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} )"  _  
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
	 , database.stringparam(_ANtNum.tostring) _ 
	 , database.stringparam(_BNtNum.tostring) _ 
	 , database.stringparam(_CNtNum.tostring) _ 
	 , database.stringparam(_DNtNum.tostring) _ 
	 , database.stringparam(_ENtNum.tostring) _ 
	 , database.stringparam(_FlxNtNum.tostring) _ 
	 , database.stringparam(_DepNtNum.tostring) _ 
	 , database.stringparam(_Pen1aNum.tostring) _ 
	 , database.stringparam(_Pen1bNum.tostring) _ 
	 , database.stringparam(_Pen2aNum.tostring) _ 
	 , database.stringparam(_Pen2bNum.tostring) _ 
	 , database.stringparam(_Pen3aNum.tostring) _ 
	 , database.stringparam(_Pen3bNum.tostring) _ 
	 , database.stringparam(_Save1Num.tostring) _ 
	 , database.stringparam(_Save2Num.tostring) _ 
	 , database.stringparam(_Save3Num.tostring) _ 
	 , database.stringparam(_Dduct1Num.tostring) _ 
	 , database.stringparam(_Dduct2Num.tostring) _ 
	 , database.stringparam(_Dduct3Num.tostring) _ 
	 , database.stringparam(_Dduct4Num.tostring) _ 
	 , database.stringparam(_Dduct5Num.tostring) _ 
	 , database.stringparam(_Dduct6Num.tostring) _ 
	 , database.stringparam(_Dduct7Num.tostring) _ 
	 , database.stringparam(_Dduct8Num.tostring) _ 
	 , database.stringparam(_Dduct9Num.tostring) _ 
	 , database.stringparam(_Misc1Num.tostring) _ 
	 , database.stringparam(_Misc2Num.tostring) _ 
	 , database.stringparam(_Spread.tostring) _ 
)
		End Get
End Property
End Class
