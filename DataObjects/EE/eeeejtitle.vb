Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class eejtitleData
	Private _TitleNum as String
	Private _JobTitle as String

Public Property TitleNum()  as String
	Get
		Return _TitleNum
	End Get
	Set (ByVal value  as String )
		_TitleNum = value
	End Set
End Property

Public Property JobTitle()  as String
	Get
		Return _JobTitle
	End Get
	Set (ByVal value  as String )
		_JobTitle = value
	End Set
End Property


Public ReadOnly Property eejtitleColumnNames() as string
		Get 
	              	              	              return "([title_num] , [job_title] )"
		End Get
End Property

Public ReadOnly Property eejtitleColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} )"  _  
	 , database.stringparam(_TitleNum.tostring) _ 
	 , database.stringparam(_JobTitle.tostring) _ 
)
		End Get
End Property
End Class
