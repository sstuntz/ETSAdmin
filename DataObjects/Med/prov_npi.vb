Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class prov_npiData
	Private _ProvNum as String
	Private _NpiNum as String
	Private _SubmitterName as String
	Private _ProvName as String
	Private _TaxId as String
	Private _TaxonomyCode as String
	Private _ProvId as String
	Private _ProvServLoc as String
	Private _MmisProcId as String

Public Property ProvNum()  as String
	Get
		Return _ProvNum
	End Get
	Set (ByVal value  as String )
		_ProvNum = value
	End Set
End Property

Public Property NpiNum()  as String
	Get
		Return _NpiNum
	End Get
	Set (ByVal value  as String )
		_NpiNum = value
	End Set
End Property

Public Property SubmitterName()  as String
	Get
		Return _SubmitterName
	End Get
	Set (ByVal value  as String )
		_SubmitterName = value
	End Set
End Property

Public Property ProvName()  as String
	Get
		Return _ProvName
	End Get
	Set (ByVal value  as String )
		_ProvName = value
	End Set
End Property

Public Property TaxId()  as String
	Get
		Return _TaxId
	End Get
	Set (ByVal value  as String )
		_TaxId = value
	End Set
End Property

Public Property TaxonomyCode()  as String
	Get
		Return _TaxonomyCode
	End Get
	Set (ByVal value  as String )
		_TaxonomyCode = value
	End Set
End Property

Public Property ProvId()  as String
	Get
		Return _ProvId
	End Get
	Set (ByVal value  as String )
		_ProvId = value
	End Set
End Property

Public Property ProvServLoc()  as String
	Get
		Return _ProvServLoc
	End Get
	Set (ByVal value  as String )
		_ProvServLoc = value
	End Set
End Property

Public Property MmisProcId()  as String
	Get
		Return _MmisProcId
	End Get
	Set (ByVal value  as String )
		_MmisProcId = value
	End Set
End Property


Public ReadOnly Property prov_npiColumnNames() as string
		Get 
	              	              	              return "([ProvNum] , [NpiNum] , [SubmitterName] , [ProvName] , [TaxId] , [TaxonomyCode] , [ProvId] , [ProvServLoc] , [MmisProcId] )"
		End Get
End Property

Public ReadOnly Property prov_npiColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} )"  _  
	 , database.stringparam(_ProvNum.tostring) _ 
	 , database.stringparam(_NpiNum.tostring) _ 
	 , database.stringparam(_SubmitterName.tostring) _ 
	 , database.stringparam(_ProvName.tostring) _ 
	 , database.stringparam(_TaxId.tostring) _ 
	 , database.stringparam(_TaxonomyCode.tostring) _ 
	 , database.stringparam(_ProvId.tostring) _ 
	 , database.stringparam(_ProvServLoc.tostring) _ 
	 , database.stringparam(_MmisProcId.tostring) _ 
)
		End Get
End Property
End Class
