Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class ee_941Data
	Private _Agency as Integer
	Private _AgencyName as String
	Private _QtrEndDate as Date
	Private _ErFedId as String
	Private _L1Eenum as String
	Private _L2Tot as Decimal
	Private _L3Tax as Decimal
	Private _L4Adj as Decimal
	Private _L5AdjTot as Decimal
	Private _L6aSwages as Decimal
	Private _L6bSs as Decimal
	Private _L6cStips as Decimal
	Private _L6dSst as Decimal
	Private _L7aMwages as Decimal
	Private _L7bMed as Decimal
	Private _L8Tot as Decimal
	Private _L9SsAdj as Decimal
	Private _L10Fime as Decimal
	Private _L11Ttax as Decimal
	Private _L12Aeic as Decimal
	Private _L13Net as Decimal
	Private _L14Tdep as Decimal
	Private _L15Bal as Decimal
	Private _L16Owe as Decimal
	Private _L17Dep as Decimal
	Private _A1 as Decimal
	Private _A2 as Decimal
	Private _A3 as Decimal
	Private _A4 as Decimal
	Private _A5 as Decimal
	Private _A6 as Decimal
	Private _A7 as Decimal
	Private _A8 as Decimal
	Private _A9 as Decimal
	Private _A10 as Decimal
	Private _A11 as Decimal
	Private _A12 as Decimal
	Private _A13 as Decimal
	Private _A14 as Decimal
	Private _A15 as Decimal
	Private _A16 as Decimal
	Private _A17 as Decimal
	Private _A18 as Decimal
	Private _A19 as Decimal
	Private _A20 as Decimal
	Private _A21 as Decimal
	Private _A22 as Decimal
	Private _A23 as Decimal
	Private _A24 as Decimal
	Private _A25 as Decimal
	Private _A26 as Decimal
	Private _A27 as Decimal
	Private _A28 as Decimal
	Private _A29 as Decimal
	Private _A30 as Decimal
	Private _A31 as Decimal
	Private _ATot as Decimal
	Private _B1 as Decimal
	Private _B2 as Decimal
	Private _B3 as Decimal
	Private _B4 as Decimal
	Private _B5 as Decimal
	Private _B6 as Decimal
	Private _B7 as Decimal
	Private _B8 as Decimal
	Private _B9 as Decimal
	Private _B10 as Decimal
	Private _B11 as Decimal
	Private _B12 as Decimal
	Private _B13 as Decimal
	Private _B14 as Decimal
	Private _B15 as Decimal
	Private _B16 as Decimal
	Private _B17 as Decimal
	Private _B18 as Decimal
	Private _B19 as Decimal
	Private _B20 as Decimal
	Private _B21 as Decimal
	Private _B22 as Decimal
	Private _B23 as Decimal
	Private _B24 as Decimal
	Private _B25 as Decimal
	Private _B26 as Decimal
	Private _B27 as Decimal
	Private _B28 as Decimal
	Private _B29 as Decimal
	Private _B30 as Decimal
	Private _B31 as Decimal
	Private _BTot as Decimal
	Private _C1 as Decimal
	Private _C2 as Decimal
	Private _C3 as Decimal
	Private _C4 as Decimal
	Private _C5 as Decimal
	Private _C6 as Decimal
	Private _C7 as Decimal
	Private _C8 as Decimal
	Private _C9 as Decimal
	Private _C10 as Decimal
	Private _C11 as Decimal
	Private _C12 as Decimal
	Private _C13 as Decimal
	Private _C14 as Decimal
	Private _C15 as Decimal
	Private _C16 as Decimal
	Private _C17 as Decimal
	Private _C18 as Decimal
	Private _C19 as Decimal
	Private _C20 as Decimal
	Private _C21 as Decimal
	Private _C22 as Decimal
	Private _C23 as Decimal
	Private _C24 as Decimal
	Private _C25 as Decimal
	Private _C26 as Decimal
	Private _C27 as Decimal
	Private _C28 as Decimal
	Private _C29 as Decimal
	Private _C30 as Decimal
	Private _C31 as Decimal
	Private _CTot as Decimal
	Private _QtrTot as Decimal

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

Public Property QtrEndDate()  as Date
	Get
		Return _QtrEndDate
	End Get
	Set (ByVal value  as Date )
		_QtrEndDate = value
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

Public Property L1Eenum()  as String
	Get
		Return _L1Eenum
	End Get
	Set (ByVal value  as String )
		_L1Eenum = value
	End Set
End Property

Public Property L2Tot()  as Decimal
	Get
		Return _L2Tot
	End Get
	Set (ByVal value  as Decimal )
		_L2Tot = value
	End Set
End Property

Public Property L3Tax()  as Decimal
	Get
		Return _L3Tax
	End Get
	Set (ByVal value  as Decimal )
		_L3Tax = value
	End Set
End Property

Public Property L4Adj()  as Decimal
	Get
		Return _L4Adj
	End Get
	Set (ByVal value  as Decimal )
		_L4Adj = value
	End Set
End Property

Public Property L5AdjTot()  as Decimal
	Get
		Return _L5AdjTot
	End Get
	Set (ByVal value  as Decimal )
		_L5AdjTot = value
	End Set
End Property

Public Property L6aSwages()  as Decimal
	Get
		Return _L6aSwages
	End Get
	Set (ByVal value  as Decimal )
		_L6aSwages = value
	End Set
End Property

Public Property L6bSs()  as Decimal
	Get
		Return _L6bSs
	End Get
	Set (ByVal value  as Decimal )
		_L6bSs = value
	End Set
End Property

Public Property L6cStips()  as Decimal
	Get
		Return _L6cStips
	End Get
	Set (ByVal value  as Decimal )
		_L6cStips = value
	End Set
End Property

Public Property L6dSst()  as Decimal
	Get
		Return _L6dSst
	End Get
	Set (ByVal value  as Decimal )
		_L6dSst = value
	End Set
End Property

Public Property L7aMwages()  as Decimal
	Get
		Return _L7aMwages
	End Get
	Set (ByVal value  as Decimal )
		_L7aMwages = value
	End Set
End Property

Public Property L7bMed()  as Decimal
	Get
		Return _L7bMed
	End Get
	Set (ByVal value  as Decimal )
		_L7bMed = value
	End Set
End Property

Public Property L8Tot()  as Decimal
	Get
		Return _L8Tot
	End Get
	Set (ByVal value  as Decimal )
		_L8Tot = value
	End Set
End Property

Public Property L9SsAdj()  as Decimal
	Get
		Return _L9SsAdj
	End Get
	Set (ByVal value  as Decimal )
		_L9SsAdj = value
	End Set
End Property

Public Property L10Fime()  as Decimal
	Get
		Return _L10Fime
	End Get
	Set (ByVal value  as Decimal )
		_L10Fime = value
	End Set
End Property

Public Property L11Ttax()  as Decimal
	Get
		Return _L11Ttax
	End Get
	Set (ByVal value  as Decimal )
		_L11Ttax = value
	End Set
End Property

Public Property L12Aeic()  as Decimal
	Get
		Return _L12Aeic
	End Get
	Set (ByVal value  as Decimal )
		_L12Aeic = value
	End Set
End Property

Public Property L13Net()  as Decimal
	Get
		Return _L13Net
	End Get
	Set (ByVal value  as Decimal )
		_L13Net = value
	End Set
End Property

Public Property L14Tdep()  as Decimal
	Get
		Return _L14Tdep
	End Get
	Set (ByVal value  as Decimal )
		_L14Tdep = value
	End Set
End Property

Public Property L15Bal()  as Decimal
	Get
		Return _L15Bal
	End Get
	Set (ByVal value  as Decimal )
		_L15Bal = value
	End Set
End Property

Public Property L16Owe()  as Decimal
	Get
		Return _L16Owe
	End Get
	Set (ByVal value  as Decimal )
		_L16Owe = value
	End Set
End Property

Public Property L17Dep()  as Decimal
	Get
		Return _L17Dep
	End Get
	Set (ByVal value  as Decimal )
		_L17Dep = value
	End Set
End Property

Public Property A1()  as Decimal
	Get
		Return _A1
	End Get
	Set (ByVal value  as Decimal )
		_A1 = value
	End Set
End Property

Public Property A2()  as Decimal
	Get
		Return _A2
	End Get
	Set (ByVal value  as Decimal )
		_A2 = value
	End Set
End Property

Public Property A3()  as Decimal
	Get
		Return _A3
	End Get
	Set (ByVal value  as Decimal )
		_A3 = value
	End Set
End Property

Public Property A4()  as Decimal
	Get
		Return _A4
	End Get
	Set (ByVal value  as Decimal )
		_A4 = value
	End Set
End Property

Public Property A5()  as Decimal
	Get
		Return _A5
	End Get
	Set (ByVal value  as Decimal )
		_A5 = value
	End Set
End Property

Public Property A6()  as Decimal
	Get
		Return _A6
	End Get
	Set (ByVal value  as Decimal )
		_A6 = value
	End Set
End Property

Public Property A7()  as Decimal
	Get
		Return _A7
	End Get
	Set (ByVal value  as Decimal )
		_A7 = value
	End Set
End Property

Public Property A8()  as Decimal
	Get
		Return _A8
	End Get
	Set (ByVal value  as Decimal )
		_A8 = value
	End Set
End Property

Public Property A9()  as Decimal
	Get
		Return _A9
	End Get
	Set (ByVal value  as Decimal )
		_A9 = value
	End Set
End Property

Public Property A10()  as Decimal
	Get
		Return _A10
	End Get
	Set (ByVal value  as Decimal )
		_A10 = value
	End Set
End Property

Public Property A11()  as Decimal
	Get
		Return _A11
	End Get
	Set (ByVal value  as Decimal )
		_A11 = value
	End Set
End Property

Public Property A12()  as Decimal
	Get
		Return _A12
	End Get
	Set (ByVal value  as Decimal )
		_A12 = value
	End Set
End Property

Public Property A13()  as Decimal
	Get
		Return _A13
	End Get
	Set (ByVal value  as Decimal )
		_A13 = value
	End Set
End Property

Public Property A14()  as Decimal
	Get
		Return _A14
	End Get
	Set (ByVal value  as Decimal )
		_A14 = value
	End Set
End Property

Public Property A15()  as Decimal
	Get
		Return _A15
	End Get
	Set (ByVal value  as Decimal )
		_A15 = value
	End Set
End Property

Public Property A16()  as Decimal
	Get
		Return _A16
	End Get
	Set (ByVal value  as Decimal )
		_A16 = value
	End Set
End Property

Public Property A17()  as Decimal
	Get
		Return _A17
	End Get
	Set (ByVal value  as Decimal )
		_A17 = value
	End Set
End Property

Public Property A18()  as Decimal
	Get
		Return _A18
	End Get
	Set (ByVal value  as Decimal )
		_A18 = value
	End Set
End Property

Public Property A19()  as Decimal
	Get
		Return _A19
	End Get
	Set (ByVal value  as Decimal )
		_A19 = value
	End Set
End Property

Public Property A20()  as Decimal
	Get
		Return _A20
	End Get
	Set (ByVal value  as Decimal )
		_A20 = value
	End Set
End Property

Public Property A21()  as Decimal
	Get
		Return _A21
	End Get
	Set (ByVal value  as Decimal )
		_A21 = value
	End Set
End Property

Public Property A22()  as Decimal
	Get
		Return _A22
	End Get
	Set (ByVal value  as Decimal )
		_A22 = value
	End Set
End Property

Public Property A23()  as Decimal
	Get
		Return _A23
	End Get
	Set (ByVal value  as Decimal )
		_A23 = value
	End Set
End Property

Public Property A24()  as Decimal
	Get
		Return _A24
	End Get
	Set (ByVal value  as Decimal )
		_A24 = value
	End Set
End Property

Public Property A25()  as Decimal
	Get
		Return _A25
	End Get
	Set (ByVal value  as Decimal )
		_A25 = value
	End Set
End Property

Public Property A26()  as Decimal
	Get
		Return _A26
	End Get
	Set (ByVal value  as Decimal )
		_A26 = value
	End Set
End Property

Public Property A27()  as Decimal
	Get
		Return _A27
	End Get
	Set (ByVal value  as Decimal )
		_A27 = value
	End Set
End Property

Public Property A28()  as Decimal
	Get
		Return _A28
	End Get
	Set (ByVal value  as Decimal )
		_A28 = value
	End Set
End Property

Public Property A29()  as Decimal
	Get
		Return _A29
	End Get
	Set (ByVal value  as Decimal )
		_A29 = value
	End Set
End Property

Public Property A30()  as Decimal
	Get
		Return _A30
	End Get
	Set (ByVal value  as Decimal )
		_A30 = value
	End Set
End Property

Public Property A31()  as Decimal
	Get
		Return _A31
	End Get
	Set (ByVal value  as Decimal )
		_A31 = value
	End Set
End Property

Public Property ATot()  as Decimal
	Get
		Return _ATot
	End Get
	Set (ByVal value  as Decimal )
		_ATot = value
	End Set
End Property

Public Property B1()  as Decimal
	Get
		Return _B1
	End Get
	Set (ByVal value  as Decimal )
		_B1 = value
	End Set
End Property

Public Property B2()  as Decimal
	Get
		Return _B2
	End Get
	Set (ByVal value  as Decimal )
		_B2 = value
	End Set
End Property

Public Property B3()  as Decimal
	Get
		Return _B3
	End Get
	Set (ByVal value  as Decimal )
		_B3 = value
	End Set
End Property

Public Property B4()  as Decimal
	Get
		Return _B4
	End Get
	Set (ByVal value  as Decimal )
		_B4 = value
	End Set
End Property

Public Property B5()  as Decimal
	Get
		Return _B5
	End Get
	Set (ByVal value  as Decimal )
		_B5 = value
	End Set
End Property

Public Property B6()  as Decimal
	Get
		Return _B6
	End Get
	Set (ByVal value  as Decimal )
		_B6 = value
	End Set
End Property

Public Property B7()  as Decimal
	Get
		Return _B7
	End Get
	Set (ByVal value  as Decimal )
		_B7 = value
	End Set
End Property

Public Property B8()  as Decimal
	Get
		Return _B8
	End Get
	Set (ByVal value  as Decimal )
		_B8 = value
	End Set
End Property

Public Property B9()  as Decimal
	Get
		Return _B9
	End Get
	Set (ByVal value  as Decimal )
		_B9 = value
	End Set
End Property

Public Property B10()  as Decimal
	Get
		Return _B10
	End Get
	Set (ByVal value  as Decimal )
		_B10 = value
	End Set
End Property

Public Property B11()  as Decimal
	Get
		Return _B11
	End Get
	Set (ByVal value  as Decimal )
		_B11 = value
	End Set
End Property

Public Property B12()  as Decimal
	Get
		Return _B12
	End Get
	Set (ByVal value  as Decimal )
		_B12 = value
	End Set
End Property

Public Property B13()  as Decimal
	Get
		Return _B13
	End Get
	Set (ByVal value  as Decimal )
		_B13 = value
	End Set
End Property

Public Property B14()  as Decimal
	Get
		Return _B14
	End Get
	Set (ByVal value  as Decimal )
		_B14 = value
	End Set
End Property

Public Property B15()  as Decimal
	Get
		Return _B15
	End Get
	Set (ByVal value  as Decimal )
		_B15 = value
	End Set
End Property

Public Property B16()  as Decimal
	Get
		Return _B16
	End Get
	Set (ByVal value  as Decimal )
		_B16 = value
	End Set
End Property

Public Property B17()  as Decimal
	Get
		Return _B17
	End Get
	Set (ByVal value  as Decimal )
		_B17 = value
	End Set
End Property

Public Property B18()  as Decimal
	Get
		Return _B18
	End Get
	Set (ByVal value  as Decimal )
		_B18 = value
	End Set
End Property

Public Property B19()  as Decimal
	Get
		Return _B19
	End Get
	Set (ByVal value  as Decimal )
		_B19 = value
	End Set
End Property

Public Property B20()  as Decimal
	Get
		Return _B20
	End Get
	Set (ByVal value  as Decimal )
		_B20 = value
	End Set
End Property

Public Property B21()  as Decimal
	Get
		Return _B21
	End Get
	Set (ByVal value  as Decimal )
		_B21 = value
	End Set
End Property

Public Property B22()  as Decimal
	Get
		Return _B22
	End Get
	Set (ByVal value  as Decimal )
		_B22 = value
	End Set
End Property

Public Property B23()  as Decimal
	Get
		Return _B23
	End Get
	Set (ByVal value  as Decimal )
		_B23 = value
	End Set
End Property

Public Property B24()  as Decimal
	Get
		Return _B24
	End Get
	Set (ByVal value  as Decimal )
		_B24 = value
	End Set
End Property

Public Property B25()  as Decimal
	Get
		Return _B25
	End Get
	Set (ByVal value  as Decimal )
		_B25 = value
	End Set
End Property

Public Property B26()  as Decimal
	Get
		Return _B26
	End Get
	Set (ByVal value  as Decimal )
		_B26 = value
	End Set
End Property

Public Property B27()  as Decimal
	Get
		Return _B27
	End Get
	Set (ByVal value  as Decimal )
		_B27 = value
	End Set
End Property

Public Property B28()  as Decimal
	Get
		Return _B28
	End Get
	Set (ByVal value  as Decimal )
		_B28 = value
	End Set
End Property

Public Property B29()  as Decimal
	Get
		Return _B29
	End Get
	Set (ByVal value  as Decimal )
		_B29 = value
	End Set
End Property

Public Property B30()  as Decimal
	Get
		Return _B30
	End Get
	Set (ByVal value  as Decimal )
		_B30 = value
	End Set
End Property

Public Property B31()  as Decimal
	Get
		Return _B31
	End Get
	Set (ByVal value  as Decimal )
		_B31 = value
	End Set
End Property

Public Property BTot()  as Decimal
	Get
		Return _BTot
	End Get
	Set (ByVal value  as Decimal )
		_BTot = value
	End Set
End Property

Public Property C1()  as Decimal
	Get
		Return _C1
	End Get
	Set (ByVal value  as Decimal )
		_C1 = value
	End Set
End Property

Public Property C2()  as Decimal
	Get
		Return _C2
	End Get
	Set (ByVal value  as Decimal )
		_C2 = value
	End Set
End Property

Public Property C3()  as Decimal
	Get
		Return _C3
	End Get
	Set (ByVal value  as Decimal )
		_C3 = value
	End Set
End Property

Public Property C4()  as Decimal
	Get
		Return _C4
	End Get
	Set (ByVal value  as Decimal )
		_C4 = value
	End Set
End Property

Public Property C5()  as Decimal
	Get
		Return _C5
	End Get
	Set (ByVal value  as Decimal )
		_C5 = value
	End Set
End Property

Public Property C6()  as Decimal
	Get
		Return _C6
	End Get
	Set (ByVal value  as Decimal )
		_C6 = value
	End Set
End Property

Public Property C7()  as Decimal
	Get
		Return _C7
	End Get
	Set (ByVal value  as Decimal )
		_C7 = value
	End Set
End Property

Public Property C8()  as Decimal
	Get
		Return _C8
	End Get
	Set (ByVal value  as Decimal )
		_C8 = value
	End Set
End Property

Public Property C9()  as Decimal
	Get
		Return _C9
	End Get
	Set (ByVal value  as Decimal )
		_C9 = value
	End Set
End Property

Public Property C10()  as Decimal
	Get
		Return _C10
	End Get
	Set (ByVal value  as Decimal )
		_C10 = value
	End Set
End Property

Public Property C11()  as Decimal
	Get
		Return _C11
	End Get
	Set (ByVal value  as Decimal )
		_C11 = value
	End Set
End Property

Public Property C12()  as Decimal
	Get
		Return _C12
	End Get
	Set (ByVal value  as Decimal )
		_C12 = value
	End Set
End Property

Public Property C13()  as Decimal
	Get
		Return _C13
	End Get
	Set (ByVal value  as Decimal )
		_C13 = value
	End Set
End Property

Public Property C14()  as Decimal
	Get
		Return _C14
	End Get
	Set (ByVal value  as Decimal )
		_C14 = value
	End Set
End Property

Public Property C15()  as Decimal
	Get
		Return _C15
	End Get
	Set (ByVal value  as Decimal )
		_C15 = value
	End Set
End Property

Public Property C16()  as Decimal
	Get
		Return _C16
	End Get
	Set (ByVal value  as Decimal )
		_C16 = value
	End Set
End Property

Public Property C17()  as Decimal
	Get
		Return _C17
	End Get
	Set (ByVal value  as Decimal )
		_C17 = value
	End Set
End Property

Public Property C18()  as Decimal
	Get
		Return _C18
	End Get
	Set (ByVal value  as Decimal )
		_C18 = value
	End Set
End Property

Public Property C19()  as Decimal
	Get
		Return _C19
	End Get
	Set (ByVal value  as Decimal )
		_C19 = value
	End Set
End Property

Public Property C20()  as Decimal
	Get
		Return _C20
	End Get
	Set (ByVal value  as Decimal )
		_C20 = value
	End Set
End Property

Public Property C21()  as Decimal
	Get
		Return _C21
	End Get
	Set (ByVal value  as Decimal )
		_C21 = value
	End Set
End Property

Public Property C22()  as Decimal
	Get
		Return _C22
	End Get
	Set (ByVal value  as Decimal )
		_C22 = value
	End Set
End Property

Public Property C23()  as Decimal
	Get
		Return _C23
	End Get
	Set (ByVal value  as Decimal )
		_C23 = value
	End Set
End Property

Public Property C24()  as Decimal
	Get
		Return _C24
	End Get
	Set (ByVal value  as Decimal )
		_C24 = value
	End Set
End Property

Public Property C25()  as Decimal
	Get
		Return _C25
	End Get
	Set (ByVal value  as Decimal )
		_C25 = value
	End Set
End Property

Public Property C26()  as Decimal
	Get
		Return _C26
	End Get
	Set (ByVal value  as Decimal )
		_C26 = value
	End Set
End Property

Public Property C27()  as Decimal
	Get
		Return _C27
	End Get
	Set (ByVal value  as Decimal )
		_C27 = value
	End Set
End Property

Public Property C28()  as Decimal
	Get
		Return _C28
	End Get
	Set (ByVal value  as Decimal )
		_C28 = value
	End Set
End Property

Public Property C29()  as Decimal
	Get
		Return _C29
	End Get
	Set (ByVal value  as Decimal )
		_C29 = value
	End Set
End Property

Public Property C30()  as Decimal
	Get
		Return _C30
	End Get
	Set (ByVal value  as Decimal )
		_C30 = value
	End Set
End Property

Public Property C31()  as Decimal
	Get
		Return _C31
	End Get
	Set (ByVal value  as Decimal )
		_C31 = value
	End Set
End Property

Public Property CTot()  as Decimal
	Get
		Return _CTot
	End Get
	Set (ByVal value  as Decimal )
		_CTot = value
	End Set
End Property

Public Property QtrTot()  as Decimal
	Get
		Return _QtrTot
	End Get
	Set (ByVal value  as Decimal )
		_QtrTot = value
	End Set
End Property


Public ReadOnly Property ee_941ColumnNames() as string
		Get 
	              	              	              return "([agency] , [agency_name] , [qtr_end_date] , [er_fed_id] , [l1_eenum] , [l2_tot] , [l3_tax] , [l4_adj] , [l5_adj_tot] , [l6a_swages] , [l6b_ss] , [l6c_stips] , [l6d_sst] , [l7a_mwages] , [l7b_med] , [l8_tot] , [l9_ss_adj] , [l10_fime] , [l11_ttax] , [l12_aeic] , [l13_net] , [l14_tdep] , [l15_bal] , [l16_owe] , [l17_dep] , [a1] , [a2] , [a3] , [a4] , [a5] , [a6] , [a7] , [a8] , [a9] , [a10] , [a11] , [a12] , [a13] , [a14] , [a15] , [a16] , [a17] , [a18] , [a19] , [a20] , [a21] , [a22] , [a23] , [a24] , [a25] , [a26] , [a27] , [a28] , [a29] , [a30] , [a31] , [a_tot] , [b1] , [b2] , [b3] , [b4] , [b5] , [b6] , [b7] , [b8] , [b9] , [b10] , [b11] , [b12] , [b13] , [b14] , [b15] , [b16] , [b17] , [b18] , [b19] , [b20] , [b21] , [b22] , [b23] , [b24] , [b25] , [b26] , [b27] , [b28] , [b29] , [b30] , [b31] , [b_tot] , [c1] , [c2] , [c3] , [c4] , [c5] , [c6] , [c7] , [c8] , [c9] , [c10] , [c11] , [c12] , [c13] , [c14] , [c15] , [c16] , [c17] , [c18] , [c19] , [c20] , [c21] , [c22] , [c23] , [c24] , [c25] , [c26] , [c27] , [c28] , [c29] , [c30] , [c31] , [c_tot] , [qtr_tot] )"
		End Get
End Property

Public ReadOnly Property ee_941ColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} , {43} , {44} , {45} , {46} , {47} , {48} , {49} , {50} , {51} , {52} , {53} , {54} , {55} , {56} , {57} , {58} , {59} , {60} , {61} , {62} , {63} , {64} , {65} , {66} , {67} , {68} , {69} , {70} , {71} , {72} , {73} , {74} , {75} , {76} , {77} , {78} , {79} , {80} , {81} , {82} , {83} , {84} , {85} , {86} , {87} , {88} , {89} , {90} , {91} , {92} , {93} , {94} , {95} , {96} , {97} , {98} , {99} , {100} , {101} , {102} , {103} , {104} , {105} , {106} , {107} , {108} , {109} , {110} , {111} , {112} , {113} , {114} , {115} , {116} , {117} , {118} , {119} , {120} , {121} )"  _  
	 , (_Agency.tostring) _ 
	 , database.stringparam(_AgencyName.tostring) _ 
	 , database.stringparam(_QtrEndDate.toshortdatestring) _ 
	 , database.stringparam(_ErFedId.tostring) _ 
	 , database.stringparam(_L1Eenum.tostring) _ 
	 , (_L2Tot.tostring) _ 
	 , (_L3Tax.tostring) _ 
	 , (_L4Adj.tostring) _ 
	 , (_L5AdjTot.tostring) _ 
	 , (_L6aSwages.tostring) _ 
	 , (_L6bSs.tostring) _ 
	 , (_L6cStips.tostring) _ 
	 , (_L6dSst.tostring) _ 
	 , (_L7aMwages.tostring) _ 
	 , (_L7bMed.tostring) _ 
	 , (_L8Tot.tostring) _ 
	 , (_L9SsAdj.tostring) _ 
	 , (_L10Fime.tostring) _ 
	 , (_L11Ttax.tostring) _ 
	 , (_L12Aeic.tostring) _ 
	 , (_L13Net.tostring) _ 
	 , (_L14Tdep.tostring) _ 
	 , (_L15Bal.tostring) _ 
	 , (_L16Owe.tostring) _ 
	 , (_L17Dep.tostring) _ 
	 , (_A1.tostring) _ 
	 , (_A2.tostring) _ 
	 , (_A3.tostring) _ 
	 , (_A4.tostring) _ 
	 , (_A5.tostring) _ 
	 , (_A6.tostring) _ 
	 , (_A7.tostring) _ 
	 , (_A8.tostring) _ 
	 , (_A9.tostring) _ 
	 , (_A10.tostring) _ 
	 , (_A11.tostring) _ 
	 , (_A12.tostring) _ 
	 , (_A13.tostring) _ 
	 , (_A14.tostring) _ 
	 , (_A15.tostring) _ 
	 , (_A16.tostring) _ 
	 , (_A17.tostring) _ 
	 , (_A18.tostring) _ 
	 , (_A19.tostring) _ 
	 , (_A20.tostring) _ 
	 , (_A21.tostring) _ 
	 , (_A22.tostring) _ 
	 , (_A23.tostring) _ 
	 , (_A24.tostring) _ 
	 , (_A25.tostring) _ 
	 , (_A26.tostring) _ 
	 , (_A27.tostring) _ 
	 , (_A28.tostring) _ 
	 , (_A29.tostring) _ 
	 , (_A30.tostring) _ 
	 , (_A31.tostring) _ 
	 , (_ATot.tostring) _ 
	 , (_B1.tostring) _ 
	 , (_B2.tostring) _ 
	 , (_B3.tostring) _ 
	 , (_B4.tostring) _ 
	 , (_B5.tostring) _ 
	 , (_B6.tostring) _ 
	 , (_B7.tostring) _ 
	 , (_B8.tostring) _ 
	 , (_B9.tostring) _ 
	 , (_B10.tostring) _ 
	 , (_B11.tostring) _ 
	 , (_B12.tostring) _ 
	 , (_B13.tostring) _ 
	 , (_B14.tostring) _ 
	 , (_B15.tostring) _ 
	 , (_B16.tostring) _ 
	 , (_B17.tostring) _ 
	 , (_B18.tostring) _ 
	 , (_B19.tostring) _ 
	 , (_B20.tostring) _ 
	 , (_B21.tostring) _ 
	 , (_B22.tostring) _ 
	 , (_B23.tostring) _ 
	 , (_B24.tostring) _ 
	 , (_B25.tostring) _ 
	 , (_B26.tostring) _ 
	 , (_B27.tostring) _ 
	 , (_B28.tostring) _ 
	 , (_B29.tostring) _ 
	 , (_B30.tostring) _ 
	 , (_B31.tostring) _ 
	 , (_BTot.tostring) _ 
	 , (_C1.tostring) _ 
	 , (_C2.tostring) _ 
	 , (_C3.tostring) _ 
	 , (_C4.tostring) _ 
	 , (_C5.tostring) _ 
	 , (_C6.tostring) _ 
	 , (_C7.tostring) _ 
	 , (_C8.tostring) _ 
	 , (_C9.tostring) _ 
	 , (_C10.tostring) _ 
	 , (_C11.tostring) _ 
	 , (_C12.tostring) _ 
	 , (_C13.tostring) _ 
	 , (_C14.tostring) _ 
	 , (_C15.tostring) _ 
	 , (_C16.tostring) _ 
	 , (_C17.tostring) _ 
	 , (_C18.tostring) _ 
	 , (_C19.tostring) _ 
	 , (_C20.tostring) _ 
	 , (_C21.tostring) _ 
	 , (_C22.tostring) _ 
	 , (_C23.tostring) _ 
	 , (_C24.tostring) _ 
	 , (_C25.tostring) _ 
	 , (_C26.tostring) _ 
	 , (_C27.tostring) _ 
	 , (_C28.tostring) _ 
	 , (_C29.tostring) _ 
	 , (_C30.tostring) _ 
	 , (_C31.tostring) _ 
	 , (_CTot.tostring) _ 
	 , (_QtrTot.tostring) _ 
)
		End Get
End Property
End Class
