Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class eeachData
	Private _NameKey as String
	Private _ScreenNam as String
	Private _ErNum as String
	Private _ErNam as String
	Private _EmployNum as String
	Private _Name as String
	Private _PayDate as Date
	Private _BnkabaNum as String
	Private _BnkacctNum as String
	Private _COrS as String
	Private _$amt as Decimal

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

Public Property ErNum()  as String
	Get
		Return _ErNum
	End Get
	Set (ByVal value  as String )
		_ErNum = value
	End Set
End Property

Public Property ErNam()  as String
	Get
		Return _ErNam
	End Get
	Set (ByVal value  as String )
		_ErNam = value
	End Set
End Property

Public Property EmployNum()  as String
	Get
		Return _EmployNum
	End Get
	Set (ByVal value  as String )
		_EmployNum = value
	End Set
End Property

Public Property Name()  as String
	Get
		Return _Name
	End Get
	Set (ByVal value  as String )
		_Name = value
	End Set
End Property

Public Property PayDate()  as Date
	Get
		Return _PayDate
	End Get
	Set (ByVal value  as Date )
		_PayDate = value
	End Set
End Property

Public Property BnkabaNum()  as String
	Get
		Return _BnkabaNum
	End Get
	Set (ByVal value  as String )
		_BnkabaNum = value
	End Set
End Property

Public Property BnkacctNum()  as String
	Get
		Return _BnkacctNum
	End Get
	Set (ByVal value  as String )
		_BnkacctNum = value
	End Set
End Property

Public Property COrS()  as String
	Get
		Return _COrS
	End Get
	Set (ByVal value  as String )
		_COrS = value
	End Set
End Property

Public Property $amt()  as Decimal
	Get
		Return _$amt
	End Get
	Set (ByVal value  as Decimal )
		_$amt = value
	End Set
End Property


Public ReadOnly Property eeachColumnNames() as string
		Get 
	              	              	              return "([name_key] , [screen_nam] , [er_num] , [er_nam] , [employ_num] , [name] , [pay_date] , [bnkaba_num] , [bnkacct_num] , [c-or-s] , [$amt] )"
		End Get
End Property

Public ReadOnly Property eeachColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} )"  _  
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_ErNum.tostring) _ 
	 , database.stringparam(_ErNam.tostring) _ 
	 , database.stringparam(_EmployNum.tostring) _ 
	 , database.stringparam(_Name.tostring) _ 
	 , database.stringparam(_PayDate.toshortdatestring) _ 
	 , database.stringparam(_BnkabaNum.tostring) _ 
	 , database.stringparam(_BnkacctNum.tostring) _ 
	 , database.stringparam(_COr-s.tostring) _ 
	 , (_$amt.tostring) _ 
)
		End Get
End Property
End Class
