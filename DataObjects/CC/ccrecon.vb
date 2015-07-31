Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class ccreconData
	Private _ChkNum as Integer
	Private _ChkDate as Date
	Private _ChkDirdep as String
	Private _NameKey as String
	Private _ScreenNam as String
	Private _SortName as String
	Private _NetPay as Decimal
	Private _Recon as String
	Private _RDate as Date

Public Property ChkNum()  as Integer
	Get
		Return _ChkNum
	End Get
	Set (ByVal value  as Integer )
		_ChkNum = value
	End Set
End Property

Public Property ChkDate()  as Date
	Get
		Return _ChkDate
	End Get
	Set (ByVal value  as Date )
		_ChkDate = value
	End Set
End Property

Public Property ChkDirdep()  as String
	Get
		Return _ChkDirdep
	End Get
	Set (ByVal value  as String )
		_ChkDirdep = value
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

Public Property NetPay()  as Decimal
	Get
		Return _NetPay
	End Get
	Set (ByVal value  as Decimal )
		_NetPay = value
	End Set
End Property

Public Property Recon()  as String
	Get
		Return _Recon
	End Get
	Set (ByVal value  as String )
		_Recon = value
	End Set
End Property

Public Property RDate()  as Date
	Get
		Return _RDate
	End Get
	Set (ByVal value  as Date )
		_RDate = value
	End Set
End Property


Public ReadOnly Property ccreconColumnNames() as string
		Get 
	              	              	              return "([chk_num] , [chk_date] , [chk_dirdep] , [name_key] , [screen_nam] , [sort_name] , [net_pay] , [recon] , [r_date] )"
		End Get
End Property

Public ReadOnly Property ccreconColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} )"  _  
	 , (_ChkNum.tostring) _ 
	 , database.stringparam(_ChkDate.toshortdatestring) _ 
	 , database.stringparam(_ChkDirdep.tostring) _ 
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_SortName.tostring) _ 
	 , (_NetPay.tostring) _ 
	 , database.stringparam(_Recon.tostring) _ 
	 , database.stringparam(_RDate.toshortdatestring) _ 
)
		End Get
End Property
End Class
