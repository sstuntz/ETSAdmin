Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class ccsysData
	Private _Agency as Integer
	Private _AgencyName as String
	Private _ErFedId as String
	Private _ErStId as String
	Private _PayFreq as String
	Private _MinWage as Decimal
	Private _MinCkAmt as Decimal
	Private _MakeupRate as Decimal
	Private _TaxMakeup as String
	Private _CcSort1 as String
	Private _CcSort2 as String
	Private _CcSort3 as String
	Private _CcSort4 as String
	Private _CcSort5 as String
	Private _CcSort6 as String
	Private _TdiPct as Decimal
	Private _TaxMinimum as String
	Private _TaxStipend as String
	Private _MinCkDfq as String
	Private _Fiscal as String
	Private _Cc1DataPath as String

Public Property Agency()  as Integer
	Get
		Return _Agency
	End Get
	Set (ByVal value  as Integer )
		_Agency = value
	End Set
End Property

Public Property AgencyName()  as String
	Get
		Return _AgencyName
	End Get
	Set (ByVal value  as String )
		_AgencyName = value
	End Set
End Property

Public Property ErFedId()  as String
	Get
		Return _ErFedId
	End Get
	Set (ByVal value  as String )
		_ErFedId = value
	End Set
End Property

Public Property ErStId()  as String
	Get
		Return _ErStId
	End Get
	Set (ByVal value  as String )
		_ErStId = value
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

Public Property MinWage()  as Decimal
	Get
		Return _MinWage
	End Get
	Set (ByVal value  as Decimal )
		_MinWage = value
	End Set
End Property

Public Property MinCkAmt()  as Decimal
	Get
		Return _MinCkAmt
	End Get
	Set (ByVal value  as Decimal )
		_MinCkAmt = value
	End Set
End Property

Public Property MakeupRate()  as Decimal
	Get
		Return _MakeupRate
	End Get
	Set (ByVal value  as Decimal )
		_MakeupRate = value
	End Set
End Property

Public Property TaxMakeup()  as String
	Get
		Return _TaxMakeup
	End Get
	Set (ByVal value  as String )
		_TaxMakeup = value
	End Set
End Property

Public Property CcSort1()  as String
	Get
		Return _CcSort1
	End Get
	Set (ByVal value  as String )
		_CcSort1 = value
	End Set
End Property

Public Property CcSort2()  as String
	Get
		Return _CcSort2
	End Get
	Set (ByVal value  as String )
		_CcSort2 = value
	End Set
End Property

Public Property CcSort3()  as String
	Get
		Return _CcSort3
	End Get
	Set (ByVal value  as String )
		_CcSort3 = value
	End Set
End Property

Public Property CcSort4()  as String
	Get
		Return _CcSort4
	End Get
	Set (ByVal value  as String )
		_CcSort4 = value
	End Set
End Property

Public Property CcSort5()  as String
	Get
		Return _CcSort5
	End Get
	Set (ByVal value  as String )
		_CcSort5 = value
	End Set
End Property

Public Property CcSort6()  as String
	Get
		Return _CcSort6
	End Get
	Set (ByVal value  as String )
		_CcSort6 = value
	End Set
End Property

Public Property TdiPct()  as Decimal
	Get
		Return _TdiPct
	End Get
	Set (ByVal value  as Decimal )
		_TdiPct = value
	End Set
End Property

Public Property TaxMinimum()  as String
	Get
		Return _TaxMinimum
	End Get
	Set (ByVal value  as String )
		_TaxMinimum = value
	End Set
End Property

Public Property TaxStipend()  as String
	Get
		Return _TaxStipend
	End Get
	Set (ByVal value  as String )
		_TaxStipend = value
	End Set
End Property

Public Property MinCkDfq()  as String
	Get
		Return _MinCkDfq
	End Get
	Set (ByVal value  as String )
		_MinCkDfq = value
	End Set
End Property

Public Property Fiscal()  as String
	Get
		Return _Fiscal
	End Get
	Set (ByVal value  as String )
		_Fiscal = value
	End Set
End Property

Public Property Cc1DataPath()  as String
	Get
		Return _Cc1DataPath
	End Get
	Set (ByVal value  as String )
		_Cc1DataPath = value
	End Set
End Property


Public ReadOnly Property ccsysColumnNames() as string
		Get 
	              	              	              return "([Agency] , [AgencyName] , [ErFedId] , [ErStId] , [PayFreq] , [MinWage] , [MinCkAmt] , [MakeupRate] , [TaxMakeup] , [CcSort1] , [CcSort2] , [CcSort3] , [CcSort4] , [CcSort5] , [CcSort6] , [TdiPct] , [TaxMinimum] , [TaxStipend] , [MinCkDfq] , [Fiscal] , [Cc1DataPath] )"
		End Get
End Property

Public ReadOnly Property ccsysColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} )"  _  
	 , (_Agency.tostring) _ 
	 , database.stringparam(_AgencyName.tostring) _ 
	 , database.stringparam(_ErFedId.tostring) _ 
	 , database.stringparam(_ErStId.tostring) _ 
	 , database.stringparam(_PayFreq.tostring) _ 
	 , (_MinWage.tostring) _ 
	 , (_MinCkAmt.tostring) _ 
	 , (_MakeupRate.tostring) _ 
	 , database.stringparam(_TaxMakeup.tostring) _ 
	 , database.stringparam(_CcSort1.tostring) _ 
	 , database.stringparam(_CcSort2.tostring) _ 
	 , database.stringparam(_CcSort3.tostring) _ 
	 , database.stringparam(_CcSort4.tostring) _ 
	 , database.stringparam(_CcSort5.tostring) _ 
	 , database.stringparam(_CcSort6.tostring) _ 
	 , (_TdiPct.tostring) _ 
	 , database.stringparam(_TaxMinimum.tostring) _ 
	 , database.stringparam(_TaxStipend.tostring) _ 
	 , database.stringparam(_MinCkDfq.tostring) _ 
	 , database.stringparam(_Fiscal.tostring) _ 
	 , database.stringparam(_Cc1DataPath.tostring) _ 
)
		End Get
End Property
End Class
