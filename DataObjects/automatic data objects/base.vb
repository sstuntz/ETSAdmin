Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class CashRctData
	Private _NameKey as String
	Private _ScreenNam as String
	Private _SortName as String
	Private _AdmitDate as Date
	Private _TermDate as Date
	Private _ActStatus as String
	Private _Sex as String
	Private _Dob as Date
	Private _Birthplace as String
	Private _SsNum as String
	Private _MedNum as String
	Private _MassHNum as String
	Private _MisNum as String
	Private _OtherNum as String
	Private _AttNum as String
	Private _Region as String
	Private _Town as String
	Private _Refer as String
	Private _Race as String
	Private _Memo1 as String
	Private _Memo2 as String
	Private _Memo3 as String
	Private _Code1 as String
	Private _Code2 as String
	Private _Code3 as String
	Private _Code4 as String
	Private _EntryDate as Date
	Private _Dflag as String
	Private _Agency as Integer

Public Property NameKey()  as String
	Get
		Return _NameKey
	End Get
	Set (ByVal value  as String )
		_NameKey = value
	End Set
End Property

Public Property ScreenNam()  as String
	Get
		Return _ScreenNam
	End Get
	Set (ByVal value  as String )
		_ScreenNam = value
	End Set
End Property

Public Property SortName()  as String
	Get
		Return _SortName
	End Get
	Set (ByVal value  as String )
		_SortName = value
	End Set
End Property

Public Property AdmitDate()  as Date
	Get
		Return _AdmitDate
	End Get
	Set (ByVal value  as Date )
		_AdmitDate = value
	End Set
End Property

Public Property TermDate()  as Date
	Get
		Return _TermDate
	End Get
	Set (ByVal value  as Date )
		_TermDate = value
	End Set
End Property

Public Property ActStatus()  as String
	Get
		Return _ActStatus
	End Get
	Set (ByVal value  as String )
		_ActStatus = value
	End Set
End Property

Public Property Sex()  as String
	Get
		Return _Sex
	End Get
	Set (ByVal value  as String )
		_Sex = value
	End Set
End Property

Public Property Dob()  as Date
	Get
		Return _Dob
	End Get
	Set (ByVal value  as Date )
		_Dob = value
	End Set
End Property

Public Property Birthplace()  as String
	Get
		Return _Birthplace
	End Get
	Set (ByVal value  as String )
		_Birthplace = value
	End Set
End Property

Public Property SsNum()  as String
	Get
		Return _SsNum
	End Get
	Set (ByVal value  as String )
		_SsNum = value
	End Set
End Property

Public Property MedNum()  as String
	Get
		Return _MedNum
	End Get
	Set (ByVal value  as String )
		_MedNum = value
	End Set
End Property

Public Property MassHNum()  as String
	Get
		Return _MassHNum
	End Get
	Set (ByVal value  as String )
		_MassHNum = value
	End Set
End Property

Public Property MisNum()  as String
	Get
		Return _MisNum
	End Get
	Set (ByVal value  as String )
		_MisNum = value
	End Set
End Property

Public Property OtherNum()  as String
	Get
		Return _OtherNum
	End Get
	Set (ByVal value  as String )
		_OtherNum = value
	End Set
End Property

Public Property AttNum()  as String
	Get
		Return _AttNum
	End Get
	Set (ByVal value  as String )
		_AttNum = value
	End Set
End Property

Public Property Region()  as String
	Get
		Return _Region
	End Get
	Set (ByVal value  as String )
		_Region = value
	End Set
End Property

Public Property Town()  as String
	Get
		Return _Town
	End Get
	Set (ByVal value  as String )
		_Town = value
	End Set
End Property

Public Property Refer()  as String
	Get
		Return _Refer
	End Get
	Set (ByVal value  as String )
		_Refer = value
	End Set
End Property

Public Property Race()  as String
	Get
		Return _Race
	End Get
	Set (ByVal value  as String )
		_Race = value
	End Set
End Property

Public Property Memo1()  as String
	Get
		Return _Memo1
	End Get
	Set (ByVal value  as String )
		_Memo1 = value
	End Set
End Property

Public Property Memo2()  as String
	Get
		Return _Memo2
	End Get
	Set (ByVal value  as String )
		_Memo2 = value
	End Set
End Property

Public Property Memo3()  as String
	Get
		Return _Memo3
	End Get
	Set (ByVal value  as String )
		_Memo3 = value
	End Set
End Property

Public Property Code1()  as String
	Get
		Return _Code1
	End Get
	Set (ByVal value  as String )
		_Code1 = value
	End Set
End Property

Public Property Code2()  as String
	Get
		Return _Code2
	End Get
	Set (ByVal value  as String )
		_Code2 = value
	End Set
End Property

Public Property Code3()  as String
	Get
		Return _Code3
	End Get
	Set (ByVal value  as String )
		_Code3 = value
	End Set
End Property

Public Property Code4()  as String
	Get
		Return _Code4
	End Get
	Set (ByVal value  as String )
		_Code4 = value
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


Public ReadOnly Property CashRctColumnNames() as string
		Get 
	              	              	              return "([NameKey] , [ScreenNam] , [SortName] , [AdmitDate] , [TermDate] , [ActStatus] , [Sex] , [Dob] , [Birthplace] , [SsNum] , [MedNum] , [MassHNum] , [MisNum] , [OtherNum] , [AttNum] , [Region] , [Town] , [Refer] , [Race] , [Memo1] , [Memo2] , [Memo3] , [Code1] , [Code2] , [Code3] , [Code4] , [EntryDate] , [Dflag] , [Agency] )"
		End Get
End Property

Public ReadOnly Property CashRctColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} )"  _  
	 , (_NameKey) _ 
	 , (_ScreenNam) _ 
	 , (_SortName) _ 
	 , (_AdmitDate) _ 
	 , (_TermDate) _ 
	 , (_ActStatus) _ 
	 , (_Sex) _ 
	 , (_Dob) _ 
	 , (_Birthplace) _ 
	 , (_SsNum) _ 
	 , (_MedNum) _ 
	 , (_MassHNum) _ 
	 , (_MisNum) _ 
	 , (_OtherNum) _ 
	 , (_AttNum) _ 
	 , (_Region) _ 
	 , (_Town) _ 
	 , (_Refer) _ 
	 , (_Race) _ 
	 , (_Memo1) _ 
	 , (_Memo2) _ 
	 , (_Memo3) _ 
	 , (_Code1) _ 
	 , (_Code2) _ 
	 , (_Code3) _ 
	 , (_Code4) _ 
	 , (_EntryDate) _ 
	 , (_Dflag) _ 
	 , (_Agency) _ 
)
		End Get
End Property
End Class
