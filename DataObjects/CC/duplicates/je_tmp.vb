Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class je_tmpData
	Private _DedNum as String
	Private _AcctNum as String
	Private _DolAmt as Decimal
	Private _DeptNum as String
	Private _ChkDate as Date

Public Property DedNum()  as String
	Get
		Return _DedNum
	End Get
	Set (ByVal value  as String )
		_DedNum = value
	End Set
End Property

Public Property AcctNum()  as String
	Get
		Return _AcctNum
	End Get
	Set (ByVal value  as String )
		_AcctNum = value
	End Set
End Property

Public Property DolAmt()  as Decimal
	Get
		Return _DolAmt
	End Get
	Set (ByVal value  as Decimal )
		_DolAmt = value
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

Public Property ChkDate()  as Date
	Get
		Return _ChkDate
	End Get
	Set (ByVal value  as Date )
		_ChkDate = value
	End Set
End Property


Public ReadOnly Property je_tmpColumnNames() as string
		Get 
	              	              	              return "([ded_num] , [acct_num] , [dol_amt] , [dept_num] , [chk_date] )"
		End Get
End Property

Public ReadOnly Property je_tmpColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} )"  _  
	 , database.stringparam(_DedNum.tostring) _ 
	 , database.stringparam(_AcctNum.tostring) _ 
	 , (_DolAmt.tostring) _ 
	 , database.stringparam(_DeptNum.tostring) _ 
	 , database.stringparam(_ChkDate.toshortdatestring) _ 
)
		End Get
End Property
End Class
