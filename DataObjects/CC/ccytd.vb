Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class ccytdData
	Private _NameKey as String
	Private _ScreenNam as String
	Private _YtdDduct1 as Decimal
	Private _YtdDduct2 as Decimal
	Private _YtdDduct3 as Decimal
	Private _YtdDduct4 as Decimal
	Private _YtdMakeup as Decimal
	Private _YtdStipend as Decimal
	Private _YtdMinimum as Decimal
	Private _YtdFullGross as Decimal
	Private _YtdFedGross as Decimal
	Private _YtdFicaGross as Decimal
	Private _YtdMedGross as Decimal
	Private _YtdSt1Gross as Decimal
	Private _YtdSt2Gross as Decimal
	Private _YtdFedTax as Decimal
	Private _YtdFicaTax as Decimal
	Private _YtdMedTax as Decimal
	Private _YtdSt1Tax as Decimal
	Private _YtdSt2Tax as Decimal
	Private _YtdAeic as Decimal
	Private _QtdDduct1 as Decimal
	Private _QtdDduct2 as Decimal
	Private _QtdDduct3 as Decimal
	Private _QtdDduct4 as Decimal
	Private _QtdMakeup as Decimal
	Private _QtdStipend as Decimal
	Private _QtdMinimum as Decimal
	Private _QtdFullGross as Decimal
	Private _QtdFedGross as Decimal
	Private _QtdFicaGross as Decimal
	Private _QtdMedGross as Decimal
	Private _QtdSt1Gross as Decimal
	Private _QtdSt2Gross as Decimal
	Private _QtdFedTax as Decimal
	Private _QtdFicaTax as Decimal
	Private _QtdMedTax as Decimal
	Private _QtdSt1Tax as Decimal
	Private _QtdSt2Tax as Decimal
	Private _QtdAeic as Decimal
	Private _QtdTdi as Decimal
	Private _YtdTdi as Decimal

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

Public Property YtdDduct1()  as Decimal
	Get
		Return _YtdDduct1
	End Get
	Set (ByVal value  as Decimal )
		_YtdDduct1 = value
	End Set
End Property

Public Property YtdDduct2()  as Decimal
	Get
		Return _YtdDduct2
	End Get
	Set (ByVal value  as Decimal )
		_YtdDduct2 = value
	End Set
End Property

Public Property YtdDduct3()  as Decimal
	Get
		Return _YtdDduct3
	End Get
	Set (ByVal value  as Decimal )
		_YtdDduct3 = value
	End Set
End Property

Public Property YtdDduct4()  as Decimal
	Get
		Return _YtdDduct4
	End Get
	Set (ByVal value  as Decimal )
		_YtdDduct4 = value
	End Set
End Property

Public Property YtdMakeup()  as Decimal
	Get
		Return _YtdMakeup
	End Get
	Set (ByVal value  as Decimal )
		_YtdMakeup = value
	End Set
End Property

Public Property YtdStipend()  as Decimal
	Get
		Return _YtdStipend
	End Get
	Set (ByVal value  as Decimal )
		_YtdStipend = value
	End Set
End Property

Public Property YtdMinimum()  as Decimal
	Get
		Return _YtdMinimum
	End Get
	Set (ByVal value  as Decimal )
		_YtdMinimum = value
	End Set
End Property

Public Property YtdFullGross()  as Decimal
	Get
		Return _YtdFullGross
	End Get
	Set (ByVal value  as Decimal )
		_YtdFullGross = value
	End Set
End Property

Public Property YtdFedGross()  as Decimal
	Get
		Return _YtdFedGross
	End Get
	Set (ByVal value  as Decimal )
		_YtdFedGross = value
	End Set
End Property

Public Property YtdFicaGross()  as Decimal
	Get
		Return _YtdFicaGross
	End Get
	Set (ByVal value  as Decimal )
		_YtdFicaGross = value
	End Set
End Property

Public Property YtdMedGross()  as Decimal
	Get
		Return _YtdMedGross
	End Get
	Set (ByVal value  as Decimal )
		_YtdMedGross = value
	End Set
End Property

Public Property YtdSt1Gross()  as Decimal
	Get
		Return _YtdSt1Gross
	End Get
	Set (ByVal value  as Decimal )
		_YtdSt1Gross = value
	End Set
End Property

Public Property YtdSt2Gross()  as Decimal
	Get
		Return _YtdSt2Gross
	End Get
	Set (ByVal value  as Decimal )
		_YtdSt2Gross = value
	End Set
End Property

Public Property YtdFedTax()  as Decimal
	Get
		Return _YtdFedTax
	End Get
	Set (ByVal value  as Decimal )
		_YtdFedTax = value
	End Set
End Property

Public Property YtdFicaTax()  as Decimal
	Get
		Return _YtdFicaTax
	End Get
	Set (ByVal value  as Decimal )
		_YtdFicaTax = value
	End Set
End Property

Public Property YtdMedTax()  as Decimal
	Get
		Return _YtdMedTax
	End Get
	Set (ByVal value  as Decimal )
		_YtdMedTax = value
	End Set
End Property

Public Property YtdSt1Tax()  as Decimal
	Get
		Return _YtdSt1Tax
	End Get
	Set (ByVal value  as Decimal )
		_YtdSt1Tax = value
	End Set
End Property

Public Property YtdSt2Tax()  as Decimal
	Get
		Return _YtdSt2Tax
	End Get
	Set (ByVal value  as Decimal )
		_YtdSt2Tax = value
	End Set
End Property

Public Property YtdAeic()  as Decimal
	Get
		Return _YtdAeic
	End Get
	Set (ByVal value  as Decimal )
		_YtdAeic = value
	End Set
End Property

Public Property QtdDduct1()  as Decimal
	Get
		Return _QtdDduct1
	End Get
	Set (ByVal value  as Decimal )
		_QtdDduct1 = value
	End Set
End Property

Public Property QtdDduct2()  as Decimal
	Get
		Return _QtdDduct2
	End Get
	Set (ByVal value  as Decimal )
		_QtdDduct2 = value
	End Set
End Property

Public Property QtdDduct3()  as Decimal
	Get
		Return _QtdDduct3
	End Get
	Set (ByVal value  as Decimal )
		_QtdDduct3 = value
	End Set
End Property

Public Property QtdDduct4()  as Decimal
	Get
		Return _QtdDduct4
	End Get
	Set (ByVal value  as Decimal )
		_QtdDduct4 = value
	End Set
End Property

Public Property QtdMakeup()  as Decimal
	Get
		Return _QtdMakeup
	End Get
	Set (ByVal value  as Decimal )
		_QtdMakeup = value
	End Set
End Property

Public Property QtdStipend()  as Decimal
	Get
		Return _QtdStipend
	End Get
	Set (ByVal value  as Decimal )
		_QtdStipend = value
	End Set
End Property

Public Property QtdMinimum()  as Decimal
	Get
		Return _QtdMinimum
	End Get
	Set (ByVal value  as Decimal )
		_QtdMinimum = value
	End Set
End Property

Public Property QtdFullGross()  as Decimal
	Get
		Return _QtdFullGross
	End Get
	Set (ByVal value  as Decimal )
		_QtdFullGross = value
	End Set
End Property

Public Property QtdFedGross()  as Decimal
	Get
		Return _QtdFedGross
	End Get
	Set (ByVal value  as Decimal )
		_QtdFedGross = value
	End Set
End Property

Public Property QtdFicaGross()  as Decimal
	Get
		Return _QtdFicaGross
	End Get
	Set (ByVal value  as Decimal )
		_QtdFicaGross = value
	End Set
End Property

Public Property QtdMedGross()  as Decimal
	Get
		Return _QtdMedGross
	End Get
	Set (ByVal value  as Decimal )
		_QtdMedGross = value
	End Set
End Property

Public Property QtdSt1Gross()  as Decimal
	Get
		Return _QtdSt1Gross
	End Get
	Set (ByVal value  as Decimal )
		_QtdSt1Gross = value
	End Set
End Property

Public Property QtdSt2Gross()  as Decimal
	Get
		Return _QtdSt2Gross
	End Get
	Set (ByVal value  as Decimal )
		_QtdSt2Gross = value
	End Set
End Property

Public Property QtdFedTax()  as Decimal
	Get
		Return _QtdFedTax
	End Get
	Set (ByVal value  as Decimal )
		_QtdFedTax = value
	End Set
End Property

Public Property QtdFicaTax()  as Decimal
	Get
		Return _QtdFicaTax
	End Get
	Set (ByVal value  as Decimal )
		_QtdFicaTax = value
	End Set
End Property

Public Property QtdMedTax()  as Decimal
	Get
		Return _QtdMedTax
	End Get
	Set (ByVal value  as Decimal )
		_QtdMedTax = value
	End Set
End Property

Public Property QtdSt1Tax()  as Decimal
	Get
		Return _QtdSt1Tax
	End Get
	Set (ByVal value  as Decimal )
		_QtdSt1Tax = value
	End Set
End Property

Public Property QtdSt2Tax()  as Decimal
	Get
		Return _QtdSt2Tax
	End Get
	Set (ByVal value  as Decimal )
		_QtdSt2Tax = value
	End Set
End Property

Public Property QtdAeic()  as Decimal
	Get
		Return _QtdAeic
	End Get
	Set (ByVal value  as Decimal )
		_QtdAeic = value
	End Set
End Property

Public Property QtdTdi()  as Decimal
	Get
		Return _QtdTdi
	End Get
	Set (ByVal value  as Decimal )
		_QtdTdi = value
	End Set
End Property

Public Property YtdTdi()  as Decimal
	Get
		Return _YtdTdi
	End Get
	Set (ByVal value  as Decimal )
		_YtdTdi = value
	End Set
End Property


Public ReadOnly Property ccytdColumnNames() as string
		Get 
	              	              	              return "([name_key] , [screen_nam] , [ytd_dduct1] , [ytd_dduct2] , [ytd_dduct3] , [ytd_dduct4] , [ytd_makeup] , [ytd_stipend] , [ytd_minimum] , [ytd_full_gross] , [ytd_fed_gross] , [ytd_fica_gross] , [ytd_med_gross] , [ytd_st1_gross] , [ytd_st2_gross] , [ytd_fed_tax] , [ytd_fica_tax] , [ytd_med_tax] , [ytd_st1_tax] , [ytd_st2_tax] , [ytd_aeic] , [qtd_dduct1] , [qtd_dduct2] , [qtd_dduct3] , [qtd_dduct4] , [qtd_makeup] , [qtd_stipend] , [qtd_minimum] , [qtd_full_gross] , [qtd_fed_gross] , [qtd_fica_gross] , [qtd_med_gross] , [qtd_st1_gross] , [qtd_st2_gross] , [qtd_fed_tax] , [qtd_fica_tax] , [qtd_med_tax] , [qtd_st1_tax] , [qtd_st2_tax] , [qtd_aeic] , [qtd_tdi] , [ytd_tdi] )"
		End Get
End Property

Public ReadOnly Property ccytdColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} )"  _  
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , (_YtdDduct1.tostring) _ 
	 , (_YtdDduct2.tostring) _ 
	 , (_YtdDduct3.tostring) _ 
	 , (_YtdDduct4.tostring) _ 
	 , (_YtdMakeup.tostring) _ 
	 , (_YtdStipend.tostring) _ 
	 , (_YtdMinimum.tostring) _ 
	 , (_YtdFullGross.tostring) _ 
	 , (_YtdFedGross.tostring) _ 
	 , (_YtdFicaGross.tostring) _ 
	 , (_YtdMedGross.tostring) _ 
	 , (_YtdSt1Gross.tostring) _ 
	 , (_YtdSt2Gross.tostring) _ 
	 , (_YtdFedTax.tostring) _ 
	 , (_YtdFicaTax.tostring) _ 
	 , (_YtdMedTax.tostring) _ 
	 , (_YtdSt1Tax.tostring) _ 
	 , (_YtdSt2Tax.tostring) _ 
	 , (_YtdAeic.tostring) _ 
	 , (_QtdDduct1.tostring) _ 
	 , (_QtdDduct2.tostring) _ 
	 , (_QtdDduct3.tostring) _ 
	 , (_QtdDduct4.tostring) _ 
	 , (_QtdMakeup.tostring) _ 
	 , (_QtdStipend.tostring) _ 
	 , (_QtdMinimum.tostring) _ 
	 , (_QtdFullGross.tostring) _ 
	 , (_QtdFedGross.tostring) _ 
	 , (_QtdFicaGross.tostring) _ 
	 , (_QtdMedGross.tostring) _ 
	 , (_QtdSt1Gross.tostring) _ 
	 , (_QtdSt2Gross.tostring) _ 
	 , (_QtdFedTax.tostring) _ 
	 , (_QtdFicaTax.tostring) _ 
	 , (_QtdMedTax.tostring) _ 
	 , (_QtdSt1Tax.tostring) _ 
	 , (_QtdSt2Tax.tostring) _ 
	 , (_QtdAeic.tostring) _ 
	 , (_QtdTdi.tostring) _ 
	 , (_YtdTdi.tostring) _ 
)
		End Get
End Property
End Class
