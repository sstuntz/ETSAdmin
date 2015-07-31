Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class rptheadData
	Private _Agency as Integer
	Private _BEGDATE as Date
	Private _ENDDATE as Date
	Private _BEGNUM as Integer
	Private _ENDNUM as Integer
	Private _CURRMNTH as String
	Private _BUDMNTH as String
	Private _CHECKDATE as Date
	Private _ENTRYDATE as Date
	Private _NAMEKEY as String
	Private _APRECONDATE as Date
	Private _SPRECONDATE as Date
	Private _CLRECONDATE as Date
	Private _MINDATE as Date
	Private _BegDept as String
	Private _EndDept as String
	Private _EffDate as Date

Public Property Agency()  as Integer
	Get
		Return _Agency
	End Get
	Set (ByVal value  as Integer )
		_Agency = value
	End Set
End Property

Public Property BEGDATE()  as Date
	Get
		Return _BEGDATE
	End Get
	Set (ByVal value  as Date )
		_BEGDATE = value
	End Set
End Property

Public Property ENDDATE()  as Date
	Get
		Return _ENDDATE
	End Get
	Set (ByVal value  as Date )
		_ENDDATE = value
	End Set
End Property

Public Property BEGNUM()  as Integer
	Get
		Return _BEGNUM
	End Get
	Set (ByVal value  as Integer )
		_BEGNUM = value
	End Set
End Property

Public Property ENDNUM()  as Integer
	Get
		Return _ENDNUM
	End Get
	Set (ByVal value  as Integer )
		_ENDNUM = value
	End Set
End Property

Public Property CURRMNTH()  as String
	Get
		Return _CURRMNTH
	End Get
	Set (ByVal value  as String )
		_CURRMNTH = value
	End Set
End Property

Public Property BUDMNTH()  as String
	Get
		Return _BUDMNTH
	End Get
	Set (ByVal value  as String )
		_BUDMNTH = value
	End Set
End Property

Public Property CHECKDATE()  as Date
	Get
		Return _CHECKDATE
	End Get
	Set (ByVal value  as Date )
		_CHECKDATE = value
	End Set
End Property

Public Property ENTRYDATE()  as Date
	Get
		Return _ENTRYDATE
	End Get
	Set (ByVal value  as Date )
		_ENTRYDATE = value
	End Set
End Property

Public Property NAMEKEY()  as String
	Get
		Return _NAMEKEY
	End Get
	Set (ByVal value  as String )
		_NAMEKEY = value
	End Set
End Property

Public Property APRECONDATE()  as Date
	Get
		Return _APRECONDATE
	End Get
	Set (ByVal value  as Date )
		_APRECONDATE = value
	End Set
End Property

Public Property SPRECONDATE()  as Date
	Get
		Return _SPRECONDATE
	End Get
	Set (ByVal value  as Date )
		_SPRECONDATE = value
	End Set
End Property

Public Property CLRECONDATE()  as Date
	Get
		Return _CLRECONDATE
	End Get
	Set (ByVal value  as Date )
		_CLRECONDATE = value
	End Set
End Property

Public Property MINDATE()  as Date
	Get
		Return _MINDATE
	End Get
	Set (ByVal value  as Date )
		_MINDATE = value
	End Set
End Property

Public Property BegDept()  as String
	Get
		Return _BegDept
	End Get
	Set (ByVal value  as String )
		_BegDept = value
	End Set
End Property

Public Property EndDept()  as String
	Get
		Return _EndDept
	End Get
	Set (ByVal value  as String )
		_EndDept = value
	End Set
End Property

Public Property EffDate()  as Date
	Get
		Return _EffDate
	End Get
	Set (ByVal value  as Date )
		_EffDate = value
	End Set
End Property


Public ReadOnly Property rptheadColumnNames() as string
		Get 
	              	              	              return "([Agency] , [BEGDATE] , [ENDDATE] , [BEGNUM] , [ENDNUM] , [CURRMNTH] , [BUDMNTH] , [CHECKDATE] , [ENTRYDATE] , [NAMEKEY] , [APRECONDATE] , [SPRECONDATE] , [CLRECONDATE] , [MINDATE] , [BegDept] , [EndDept] , [EffDate] )"
		End Get
End Property

Public ReadOnly Property rptheadColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} )"  _  
	 , (_Agency.tostring) _ 
	 , database.stringparam(_BEGDATE.toshortdatestring) _ 
	 , database.stringparam(_ENDDATE.toshortdatestring) _ 
	 , (_BEGNUM.tostring) _ 
	 , (_ENDNUM.tostring) _ 
	 , database.stringparam(_CURRMNTH.tostring) _ 
	 , database.stringparam(_BUDMNTH.tostring) _ 
	 , database.stringparam(_CHECKDATE.toshortdatestring) _ 
	 , database.stringparam(_ENTRYDATE.toshortdatestring) _ 
	 , database.stringparam(_NAMEKEY.tostring) _ 
	 , database.stringparam(_APRECONDATE.toshortdatestring) _ 
	 , database.stringparam(_SPRECONDATE.toshortdatestring) _ 
	 , database.stringparam(_CLRECONDATE.toshortdatestring) _ 
	 , database.stringparam(_MINDATE.toshortdatestring) _ 
	 , database.stringparam(_BegDept.tostring) _ 
	 , database.stringparam(_EndDept.tostring) _ 
	 , database.stringparam(_EffDate.toshortdatestring) _ 
)
		End Get
End Property
End Class
