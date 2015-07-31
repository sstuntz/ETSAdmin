Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class CashRctData
	Private _Agency as Integer
	Private _AgencyName as String
	Private _AgencyLine2 as String
	Private _Address1 as String
	Private _Address2 as String
	Private _City as String
	Private _State as String
	Private _Zip as String
	Private _ApCntrNu as String
	Private _DrvName as String

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

Public Property AgencyLine2()  as String
	Get
		Return _AgencyLine2
	End Get
	Set (ByVal value  as String )
		_AgencyLine2 = value
	End Set
End Property

Public Property Address1()  as String
	Get
		Return _Address1
	End Get
	Set (ByVal value  as String )
		_Address1 = value
	End Set
End Property

Public Property Address2()  as String
	Get
		Return _Address2
	End Get
	Set (ByVal value  as String )
		_Address2 = value
	End Set
End Property

Public Property City()  as String
	Get
		Return _City
	End Get
	Set (ByVal value  as String )
		_City = value
	End Set
End Property

Public Property State()  as String
	Get
		Return _State
	End Get
	Set (ByVal value  as String )
		_State = value
	End Set
End Property

Public Property Zip()  as String
	Get
		Return _Zip
	End Get
	Set (ByVal value  as String )
		_Zip = value
	End Set
End Property

Public Property ApCntrNu()  as String
	Get
		Return _ApCntrNu
	End Get
	Set (ByVal value  as String )
		_ApCntrNu = value
	End Set
End Property

Public Property DrvName()  as String
	Get
		Return _DrvName
	End Get
	Set (ByVal value  as String )
		_DrvName = value
	End Set
End Property


Public ReadOnly Property CashRctColumnNames() as string
		Get 
	              	              	              return "([Agency] , [AgencyName] , [AgencyLine2] , [Address1] , [Address2] , [City] , [State] , [Zip] , [ApCntrNu] , [DrvName] )"
		End Get
End Property

Public ReadOnly Property CashRctColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} )"  _  
	 , (_Agency) _ 
	 , (_AgencyName) _ 
	 , (_AgencyLine2) _ 
	 , (_Address1) _ 
	 , (_Address2) _ 
	 , (_City) _ 
	 , (_State) _ 
	 , (_Zip) _ 
	 , (_ApCntrNu) _ 
	 , (_DrvName) _ 
)
		End Get
End Property
End Class
