Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class file_locationData
	Private _FileName as String
	Private _DriveLetter as String
	Private _FolderName as String

Public Property FileName()  as String
	Get
		Return _FileName
	End Get
	Set (ByVal value  as String )
		_FileName = value
	End Set
End Property

Public Property DriveLetter()  as String
	Get
		Return _DriveLetter
	End Get
	Set (ByVal value  as String )
		_DriveLetter = value
	End Set
End Property

Public Property FolderName()  as String
	Get
		Return _FolderName
	End Get
	Set (ByVal value  as String )
		_FolderName = value
	End Set
End Property


Public ReadOnly Property file_locationColumnNames() as string
		Get 
	              	              	              return "([FileName] , [DriveLetter] , [FolderName] )"
		End Get
End Property

Public ReadOnly Property file_locationColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} )"  _  
	 , database.stringparam(_FileName.tostring) _ 
	 , database.stringparam(_DriveLetter.tostring) _ 
	 , database.stringparam(_FolderName.tostring) _ 
)
		End Get
End Property
End Class
