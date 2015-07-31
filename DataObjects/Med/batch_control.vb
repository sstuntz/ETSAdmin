Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class batch_controlData
	Private _BatchNum as Integer
	Private _BatchNumLineBeg as Integer
	Private _BatchNumLineEnd as Integer
	Private _ProvNum as String
	Private _ProvNameKey as String
	Private _ProcNum as String
	Private _ProcNameKey as String
	Private _Type as String
	Private _InvType as String
	Private _InvDate as Date
	Private _RecordId as String
	Private _TotInv as Integer
	Private _TotClaims as Integer
	Private _TotDol as Decimal
	Private _TotBat as Integer
	Private _EntryDate as Date
	Private _Dflag as String
	Private _Agency as Integer

Public Property BatchNum()  as Integer
	Get
		Return _BatchNum
	End Get
	Set (ByVal value  as Integer )
		_BatchNum = value
	End Set
End Property

Public Property BatchNumLineBeg()  as Integer
	Get
		Return _BatchNumLineBeg
	End Get
	Set (ByVal value  as Integer )
		_BatchNumLineBeg = value
	End Set
End Property

Public Property BatchNumLineEnd()  as Integer
	Get
		Return _BatchNumLineEnd
	End Get
	Set (ByVal value  as Integer )
		_BatchNumLineEnd = value
	End Set
End Property

Public Property ProvNum()  as String
	Get
		Return _ProvNum
	End Get
	Set (ByVal value  as String )
		_ProvNum = value
	End Set
End Property

Public Property ProvNameKey()  as String
	Get
		Return _ProvNameKey
	End Get
	Set (ByVal value  as String )
		_ProvNameKey = value
	End Set
End Property

Public Property ProcNum()  as String
	Get
		Return _ProcNum
	End Get
	Set (ByVal value  as String )
		_ProcNum = value
	End Set
End Property

Public Property ProcNameKey()  as String
	Get
		Return _ProcNameKey
	End Get
	Set (ByVal value  as String )
		_ProcNameKey = value
	End Set
End Property

Public Property Type()  as String
	Get
		Return _Type
	End Get
	Set (ByVal value  as String )
		_Type = value
	End Set
End Property

Public Property InvType()  as String
	Get
		Return _InvType
	End Get
	Set (ByVal value  as String )
		_InvType = value
	End Set
End Property

Public Property InvDate()  as Date
	Get
		Return _InvDate
	End Get
	Set (ByVal value  as Date )
		_InvDate = value
	End Set
End Property

Public Property RecordId()  as String
	Get
		Return _RecordId
	End Get
	Set (ByVal value  as String )
		_RecordId = value
	End Set
End Property

Public Property TotInv()  as Integer
	Get
		Return _TotInv
	End Get
	Set (ByVal value  as Integer )
		_TotInv = value
	End Set
End Property

Public Property TotClaims()  as Integer
	Get
		Return _TotClaims
	End Get
	Set (ByVal value  as Integer )
		_TotClaims = value
	End Set
End Property

Public Property TotDol()  as Decimal
	Get
		Return _TotDol
	End Get
	Set (ByVal value  as Decimal )
		_TotDol = value
	End Set
End Property

Public Property TotBat()  as Integer
	Get
		Return _TotBat
	End Get
	Set (ByVal value  as Integer )
		_TotBat = value
	End Set
End Property

Public Property EntryDate()  as Date
	Get
		Return _EntryDate
	End Get
	Set (ByVal value  as Date )
		_EntryDate = value
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


Public ReadOnly Property batch_controlColumnNames() as string
		Get 
	              	              	              return "([BatchNum] , [BatchNumLineBeg] , [BatchNumLineEnd] , [ProvNum] , [ProvNameKey] , [ProcNum] , [ProcNameKey] , [Type] , [InvType] , [InvDate] , [RecordId] , [TotInv] , [TotClaims] , [TotDol] , [TotBat] , [EntryDate] , [Dflag] , [Agency] )"
		End Get
End Property

Public ReadOnly Property batch_controlColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} )"  _  
	 , (_BatchNum.tostring) _ 
	 , (_BatchNumLineBeg.tostring) _ 
	 , (_BatchNumLineEnd.tostring) _ 
	 , database.stringparam(_ProvNum.tostring) _ 
	 , database.stringparam(_ProvNameKey.tostring) _ 
	 , database.stringparam(_ProcNum.tostring) _ 
	 , database.stringparam(_ProcNameKey.tostring) _ 
	 , database.stringparam(_Type.tostring) _ 
	 , database.stringparam(_InvType.tostring) _ 
	 , database.stringparam(_InvDate.toshortdatestring) _ 
	 , database.stringparam(_RecordId.tostring) _ 
	 , (_TotInv.tostring) _ 
	 , (_TotClaims.tostring) _ 
	 , (_TotDol.tostring) _ 
	 , (_TotBat.tostring) _ 
	 , database.stringparam(_EntryDate.toshortdatestring) _ 
	 , database.stringparam(_Dflag.tostring) _ 
	 , (_Agency.tostring) _ 
)
		End Get
End Property
End Class
