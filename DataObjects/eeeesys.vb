Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class eesysData
	Private _Agency as Integer
	Private _AgencyName as String
	Private _ErFedId as String
	Private _ErStId as String
	Private _PayFreq as String
	Private _BlendOt as String
	Private _OvtLev as Double
	Private _EeSort1 as String
	Private _EeSort2 as String
	Private _EeSort3 as String
	Private _EeSort4 as String
	Private _EeSort5 as String
	Private _EeSort6 as String

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

Public Property BlendOt()  as String
	Get
		Return _BlendOt
	End Get
	Set (ByVal value  as String )
		_BlendOt = value
	End Set
End Property

Public Property OvtLev()  as Double
	Get
		Return _OvtLev
	End Get
	Set (ByVal value  as Double )
		_OvtLev = value
	End Set
End Property

Public Property EeSort1()  as String
	Get
		Return _EeSort1
	End Get
	Set (ByVal value  as String )
		_EeSort1 = value
	End Set
End Property

Public Property EeSort2()  as String
	Get
		Return _EeSort2
	End Get
	Set (ByVal value  as String )
		_EeSort2 = value
	End Set
End Property

Public Property EeSort3()  as String
	Get
		Return _EeSort3
	End Get
	Set (ByVal value  as String )
		_EeSort3 = value
	End Set
End Property

Public Property EeSort4()  as String
	Get
		Return _EeSort4
	End Get
	Set (ByVal value  as String )
		_EeSort4 = value
	End Set
End Property

Public Property EeSort5()  as String
	Get
		Return _EeSort5
	End Get
	Set (ByVal value  as String )
		_EeSort5 = value
	End Set
End Property

Public Property EeSort6()  as String
	Get
		Return _EeSort6
	End Get
	Set (ByVal value  as String )
		_EeSort6 = value
	End Set
End Property


Public ReadOnly Property eesysColumnNames() as string
		Get 
	              	              	              return "([agency] , [agency_name] , [er_fed_id] , [er_st_id] , [pay_freq] , [blend_ot] , [ovt_lev] , [ee_sort1] , [ee_sort2] , [ee_sort3] , [ee_sort4] , [ee_sort5] , [ee_sort6] )"
		End Get
End Property

Public ReadOnly Property eesysColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} )"  _  
	 , (_Agency.tostring) _ 
	 , database.stringparam(_AgencyName.tostring) _ 
	 , database.stringparam(_ErFedId.tostring) _ 
	 , database.stringparam(_ErStId.tostring) _ 
	 , database.stringparam(_PayFreq.tostring) _ 
	 , database.stringparam(_BlendOt.tostring) _ 
	 , (_OvtLev.tostring) _ 
	 , database.stringparam(_EeSort1.tostring) _ 
	 , database.stringparam(_EeSort2.tostring) _ 
	 , database.stringparam(_EeSort3.tostring) _ 
	 , database.stringparam(_EeSort4.tostring) _ 
	 , database.stringparam(_EeSort5.tostring) _ 
	 , database.stringparam(_EeSort6.tostring) _ 
)
		End Get
End Property
End Class
