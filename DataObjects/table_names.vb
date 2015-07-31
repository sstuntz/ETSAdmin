Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class table_namesData
	Private _Path as String
	Private _AltPath as String
	Private _Db as String
	Private _Tbl as String

Public Property Path()  as String
	Get
		Return _Path
	End Get
	Set (ByVal value  as String )
		_Path = value
	End Set
End Property

Public Property AltPath()  as String
	Get
		Return _AltPath
	End Get
	Set (ByVal value  as String )
		_AltPath = value
	End Set
End Property

Public Property Db()  as String
	Get
		Return _Db
	End Get
	Set (ByVal value  as String )
		_Db = value
	End Set
End Property

Public Property Tbl()  as String
	Get
		Return _Tbl
	End Get
	Set (ByVal value  as String )
		_Tbl = value
	End Set
End Property


Public ReadOnly Property table_namesColumnNames() as string
		Get 
	              	              	              return "([Path] , [AltPath] , [Db] , [Tbl] )"
		End Get
End Property

Public ReadOnly Property table_namesColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} )"  _  
	 , database.stringparam(_Path.tostring) _ 
	 , database.stringparam(_AltPath.tostring) _ 
	 , database.stringparam(_Db.tostring) _ 
	 , database.stringparam(_Tbl.tostring) _ 
)
		End Get
End Property
End Class
