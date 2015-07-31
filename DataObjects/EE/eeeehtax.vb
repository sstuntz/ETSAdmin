Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class eehtaxData
	Private _NameKey as String
	Private _ScreenNam as String
	Private _Mnth1 as Integer
	Private _Mnth2 as Integer
	Private _Mnth3 as Integer
	Private _AmtRem as Decimal
	Private _Taxable as Decimal
	Private _FirstTest as Decimal
	Private _SecTest as Decimal

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

Public Property Mnth1()  as Integer
	Get
		Return _Mnth1
	End Get
	Set (ByVal value  as Integer )
		_Mnth1 = value
	End Set
End Property

Public Property Mnth2()  as Integer
	Get
		Return _Mnth2
	End Get
	Set (ByVal value  as Integer )
		_Mnth2 = value
	End Set
End Property

Public Property Mnth3()  as Integer
	Get
		Return _Mnth3
	End Get
	Set (ByVal value  as Integer )
		_Mnth3 = value
	End Set
End Property

Public Property AmtRem()  as Decimal
	Get
		Return _AmtRem
	End Get
	Set (ByVal value  as Decimal )
		_AmtRem = value
	End Set
End Property

Public Property Taxable()  as Decimal
	Get
		Return _Taxable
	End Get
	Set (ByVal value  as Decimal )
		_Taxable = value
	End Set
End Property

Public Property FirstTest()  as Decimal
	Get
		Return _FirstTest
	End Get
	Set (ByVal value  as Decimal )
		_FirstTest = value
	End Set
End Property

Public Property SecTest()  as Decimal
	Get
		Return _SecTest
	End Get
	Set (ByVal value  as Decimal )
		_SecTest = value
	End Set
End Property


Public ReadOnly Property eehtaxColumnNames() as string
		Get 
	              	              	              return "([name_key] , [screen_nam] , [mnth_1] , [mnth_2] , [mnth_3] , [amt_rem] , [taxable] , [first_test] , [sec_test] )"
		End Get
End Property

Public ReadOnly Property eehtaxColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} )"  _  
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , (_Mnth1.tostring) _ 
	 , (_Mnth2.tostring) _ 
	 , (_Mnth3.tostring) _ 
	 , (_AmtRem.tostring) _ 
	 , (_Taxable.tostring) _ 
	 , (_FirstTest.tostring) _ 
	 , (_SecTest.tostring) _ 
)
		End Get
End Property
End Class
