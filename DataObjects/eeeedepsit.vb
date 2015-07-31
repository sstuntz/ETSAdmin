Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class eedepsitData
	Private _NameKey as String
	Private _ScreenNam as String
	Private _Bk1Aba as String
	Private _Bk1Num as String
	Private _Bk1actNum as String
	Private _Bk1COrS as String
	Private _Bk1Amt as Decimal
	Private _Bk2Aba as String
	Private _Bk2Num as String
	Private _Bk2actNum as String
	Private _Bk2COrS as String
	Private _Bk2Amt as Decimal
	Private _Bk3Aba as String
	Private _Bk3Num as String
	Private _Bk3actNum as String
	Private _Bk3COrS as String
	Private _Bk3Amt as Decimal
	Private _Bk4Aba as String
	Private _Bk4Num as String
	Private _Bk4actNum as String
	Private _Bk4COrS as String
	Private _Bk4Amt as Decimal
	Private _Bk1ChgDate as Date
	Private _Bk2ChgDate as Date
	Private _Bk3ChgDate as Date
	Private _Bk4ChgDate as Date
	Private _Void as String
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

Public Property ScreenNam()  as String
	Get
		Return _ScreenNam
	End Get
	Set (ByVal value  as String )
		_ScreenNam = value
	End Set
End Property

Public Property Bk1Aba()  as String
	Get
		Return _Bk1Aba
	End Get
	Set (ByVal value  as String )
		_Bk1Aba = value
	End Set
End Property

Public Property Bk1Num()  as String
	Get
		Return _Bk1Num
	End Get
	Set (ByVal value  as String )
		_Bk1Num = value
	End Set
End Property

Public Property Bk1actNum()  as String
	Get
		Return _Bk1actNum
	End Get
	Set (ByVal value  as String )
		_Bk1actNum = value
	End Set
End Property

Public Property Bk1COrS()  as String
	Get
		Return _Bk1COrS
	End Get
	Set (ByVal value  as String )
		_Bk1COrS = value
	End Set
End Property

Public Property Bk1Amt()  as Decimal
	Get
		Return _Bk1Amt
	End Get
	Set (ByVal value  as Decimal )
		_Bk1Amt = value
	End Set
End Property

Public Property Bk2Aba()  as String
	Get
		Return _Bk2Aba
	End Get
	Set (ByVal value  as String )
		_Bk2Aba = value
	End Set
End Property

Public Property Bk2Num()  as String
	Get
		Return _Bk2Num
	End Get
	Set (ByVal value  as String )
		_Bk2Num = value
	End Set
End Property

Public Property Bk2actNum()  as String
	Get
		Return _Bk2actNum
	End Get
	Set (ByVal value  as String )
		_Bk2actNum = value
	End Set
End Property

Public Property Bk2COrS()  as String
	Get
		Return _Bk2COrS
	End Get
	Set (ByVal value  as String )
		_Bk2COrS = value
	End Set
End Property

Public Property Bk2Amt()  as Decimal
	Get
		Return _Bk2Amt
	End Get
	Set (ByVal value  as Decimal )
		_Bk2Amt = value
	End Set
End Property

Public Property Bk3Aba()  as String
	Get
		Return _Bk3Aba
	End Get
	Set (ByVal value  as String )
		_Bk3Aba = value
	End Set
End Property

Public Property Bk3Num()  as String
	Get
		Return _Bk3Num
	End Get
	Set (ByVal value  as String )
		_Bk3Num = value
	End Set
End Property

Public Property Bk3actNum()  as String
	Get
		Return _Bk3actNum
	End Get
	Set (ByVal value  as String )
		_Bk3actNum = value
	End Set
End Property

Public Property Bk3COrS()  as String
	Get
		Return _Bk3COrS
	End Get
	Set (ByVal value  as String )
		_Bk3COrS = value
	End Set
End Property

Public Property Bk3Amt()  as Decimal
	Get
		Return _Bk3Amt
	End Get
	Set (ByVal value  as Decimal )
		_Bk3Amt = value
	End Set
End Property

Public Property Bk4Aba()  as String
	Get
		Return _Bk4Aba
	End Get
	Set (ByVal value  as String )
		_Bk4Aba = value
	End Set
End Property

Public Property Bk4Num()  as String
	Get
		Return _Bk4Num
	End Get
	Set (ByVal value  as String )
		_Bk4Num = value
	End Set
End Property

Public Property Bk4actNum()  as String
	Get
		Return _Bk4actNum
	End Get
	Set (ByVal value  as String )
		_Bk4actNum = value
	End Set
End Property

Public Property Bk4COrS()  as String
	Get
		Return _Bk4COrS
	End Get
	Set (ByVal value  as String )
		_Bk4COrS = value
	End Set
End Property

Public Property Bk4Amt()  as Decimal
	Get
		Return _Bk4Amt
	End Get
	Set (ByVal value  as Decimal )
		_Bk4Amt = value
	End Set
End Property

Public Property Bk1ChgDate()  as Date
	Get
		Return _Bk1ChgDate
	End Get
	Set (ByVal value  as Date )
		_Bk1ChgDate = value
	End Set
End Property

Public Property Bk2ChgDate()  as Date
	Get
		Return _Bk2ChgDate
	End Get
	Set (ByVal value  as Date )
		_Bk2ChgDate = value
	End Set
End Property

Public Property Bk3ChgDate()  as Date
	Get
		Return _Bk3ChgDate
	End Get
	Set (ByVal value  as Date )
		_Bk3ChgDate = value
	End Set
End Property

Public Property Bk4ChgDate()  as Date
	Get
		Return _Bk4ChgDate
	End Get
	Set (ByVal value  as Date )
		_Bk4ChgDate = value
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


Public ReadOnly Property eedepsitColumnNames() as string
		Get 
	              	              	              return "([name_key] , [screen_nam] , [bk1_aba] , [bk1_num] , [bk1act_num] , [bk1_c-or-s] , [bk1_amt] , [bk2_aba] , [bk2_num] , [bk2act_num] , [bk2_c-or-s] , [bk2_amt] , [bk3_aba] , [bk3_num] , [bk3act_num] , [bk3_c-or-s] , [bk3_amt] , [bk4_aba] , [bk4_num] , [bk4act_num] , [bk4_c-or-s] , [bk4_amt] , [bk1_chg_date] , [bk2_chg_date] , [bk3_chg_date] , [bk4_chg_date] , [void] , [dflag] , [agency] )"
		End Get
End Property

Public ReadOnly Property eedepsitColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} )"  _  
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_Bk1Aba.tostring) _ 
	 , database.stringparam(_Bk1Num.tostring) _ 
	 , database.stringparam(_Bk1actNum.tostring) _ 
	 , database.stringparam(_Bk1COr-s.tostring) _ 
	 , (_Bk1Amt.tostring) _ 
	 , database.stringparam(_Bk2Aba.tostring) _ 
	 , database.stringparam(_Bk2Num.tostring) _ 
	 , database.stringparam(_Bk2actNum.tostring) _ 
	 , database.stringparam(_Bk2COr-s.tostring) _ 
	 , (_Bk2Amt.tostring) _ 
	 , database.stringparam(_Bk3Aba.tostring) _ 
	 , database.stringparam(_Bk3Num.tostring) _ 
	 , database.stringparam(_Bk3actNum.tostring) _ 
	 , database.stringparam(_Bk3COr-s.tostring) _ 
	 , (_Bk3Amt.tostring) _ 
	 , database.stringparam(_Bk4Aba.tostring) _ 
	 , database.stringparam(_Bk4Num.tostring) _ 
	 , database.stringparam(_Bk4actNum.tostring) _ 
	 , database.stringparam(_Bk4COr-s.tostring) _ 
	 , (_Bk4Amt.tostring) _ 
	 , database.stringparam(_Bk1ChgDate.toshortdatestring) _ 
	 , database.stringparam(_Bk2ChgDate.toshortdatestring) _ 
	 , database.stringparam(_Bk3ChgDate.toshortdatestring) _ 
	 , database.stringparam(_Bk4ChgDate.toshortdatestring) _ 
	 , database.stringparam(_Void.tostring) _ 
	 , database.stringparam(_Dflag.tostring) _ 
	 , (_Agency.tostring) _ 
)
		End Get
End Property
End Class
