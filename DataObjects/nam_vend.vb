Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class nam_vendData
	Private _NameKey as String
	Private _ScreenNam as String
	Private _CntctNa1 as String
	Private _CntctNu1 as String
	Private _CntctNa2 as String
	Private _CntctNu2 as String
	Private _PayDisc as Integer
	Private _YN1099 as String
	Private _RentBox1 as Decimal
	Private _MedBox6 as Decimal
	Private _AmtBox7 as Decimal
	Private _SocSecNu as String
	Private _FedIdNu as String
	Private _StatIdNu as String
	Private _CrPrefAc as String
	Private _DrPrefAc as String
	Private _DiscAcct as String
	Private _StartDate as Date
	Private _EndDate as Date
	Private _Dflag as String
	Private _SpecInst as String
	Private _SortName as String
	Private _Agency as Integer
	Private _Minority as String
	Private _FileFolder as String

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

Public Property CntctNa1()  as String
	Get
		Return _CntctNa1
	End Get
	Set (ByVal value  as String )
		_CntctNa1 = value
	End Set
End Property

Public Property CntctNu1()  as String
	Get
		Return _CntctNu1
	End Get
	Set (ByVal value  as String )
		_CntctNu1 = value
	End Set
End Property

Public Property CntctNa2()  as String
	Get
		Return _CntctNa2
	End Get
	Set (ByVal value  as String )
		_CntctNa2 = value
	End Set
End Property

Public Property CntctNu2()  as String
	Get
		Return _CntctNu2
	End Get
	Set (ByVal value  as String )
		_CntctNu2 = value
	End Set
End Property

Public Property PayDisc()  as Integer
	Get
		Return _PayDisc
	End Get
	Set (ByVal value  as Integer )
		_PayDisc = value
	End Set
End Property

Public Property YN1099()  as String
	Get
		Return _YN1099
	End Get
	Set (ByVal value  as String )
		_YN1099 = value
	End Set
End Property

Public Property RentBox1()  as Decimal
	Get
		Return _RentBox1
	End Get
	Set (ByVal value  as Decimal )
		_RentBox1 = value
	End Set
End Property

Public Property MedBox6()  as Decimal
	Get
		Return _MedBox6
	End Get
	Set (ByVal value  as Decimal )
		_MedBox6 = value
	End Set
End Property

Public Property AmtBox7()  as Decimal
	Get
		Return _AmtBox7
	End Get
	Set (ByVal value  as Decimal )
		_AmtBox7 = value
	End Set
End Property

Public Property SocSecNu()  as String
	Get
		Return _SocSecNu
	End Get
	Set (ByVal value  as String )
		_SocSecNu = value
	End Set
End Property

Public Property FedIdNu()  as String
	Get
		Return _FedIdNu
	End Get
	Set (ByVal value  as String )
		_FedIdNu = value
	End Set
End Property

Public Property StatIdNu()  as String
	Get
		Return _StatIdNu
	End Get
	Set (ByVal value  as String )
		_StatIdNu = value
	End Set
End Property

Public Property CrPrefAc()  as String
	Get
		Return _CrPrefAc
	End Get
	Set (ByVal value  as String )
		_CrPrefAc = value
	End Set
End Property

Public Property DrPrefAc()  as String
	Get
		Return _DrPrefAc
	End Get
	Set (ByVal value  as String )
		_DrPrefAc = value
	End Set
End Property

Public Property DiscAcct()  as String
	Get
		Return _DiscAcct
	End Get
	Set (ByVal value  as String )
		_DiscAcct = value
	End Set
End Property

Public Property StartDate()  as Date
	Get
		Return _StartDate
	End Get
	Set (ByVal value  as Date )
		_StartDate = value
	End Set
End Property

Public Property EndDate()  as Date
	Get
		Return _EndDate
	End Get
	Set (ByVal value  as Date )
		_EndDate = value
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

Public Property SpecInst()  as String
	Get
		Return _SpecInst
	End Get
	Set (ByVal value  as String )
		_SpecInst = value
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

Public Property Agency()  as Integer
	Get
		Return _Agency
	End Get
	Set (ByVal value  as Integer )
		_Agency = value
	End Set
End Property

Public Property Minority()  as String
	Get
		Return _Minority
	End Get
	Set (ByVal value  as String )
		_Minority = value
	End Set
End Property

Public Property FileFolder()  as String
	Get
		Return _FileFolder
	End Get
	Set (ByVal value  as String )
		_FileFolder = value
	End Set
End Property


Public ReadOnly Property nam_vendColumnNames() as string
		Get 
	              	              	              return "([NameKey] , [ScreenNam] , [CntctNa1] , [CntctNu1] , [CntctNa2] , [CntctNu2] , [PayDisc] , [YN1099] , [RentBox1] , [MedBox6] , [AmtBox7] , [SocSecNu] , [FedIdNu] , [StatIdNu] , [CrPrefAc] , [DrPrefAc] , [DiscAcct] , [StartDate] , [EndDate] , [Dflag] , [SpecInst] , [SortName] , [Agency] , [Minority] , [FileFolder] )"
		End Get
End Property

Public ReadOnly Property nam_vendColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} )"  _  
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_CntctNa1.tostring) _ 
	 , database.stringparam(_CntctNu1.tostring) _ 
	 , database.stringparam(_CntctNa2.tostring) _ 
	 , database.stringparam(_CntctNu2.tostring) _ 
	 , (_PayDisc.tostring) _ 
	 , database.stringparam(_YN1099.tostring) _ 
	 , (_RentBox1.tostring) _ 
	 , (_MedBox6.tostring) _ 
	 , (_AmtBox7.tostring) _ 
	 , database.stringparam(_SocSecNu.tostring) _ 
	 , database.stringparam(_FedIdNu.tostring) _ 
	 , database.stringparam(_StatIdNu.tostring) _ 
	 , database.stringparam(_CrPrefAc.tostring) _ 
	 , database.stringparam(_DrPrefAc.tostring) _ 
	 , database.stringparam(_DiscAcct.tostring) _ 
	 , database.stringparam(_StartDate.toshortdatestring) _ 
	 , database.stringparam(_EndDate.toshortdatestring) _ 
	 , database.stringparam(_Dflag.tostring) _ 
	 , database.stringparam(_SpecInst.tostring) _ 
	 , database.stringparam(_SortName.tostring) _ 
	 , (_Agency.tostring) _ 
	 , database.stringparam(_Minority.tostring) _ 
	 , database.stringparam(_FileFolder.tostring) _ 
)
		End Get
End Property
End Class
