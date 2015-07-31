Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class CashRctData
	Private _ContractKey as String
	Private _PvForm as String
	Private _Dept1 as String
	Private _ROrg-2 as String
	Private _Num3 as String
	Private _Action4 as String
	Private _SchDate5 as Date
	Private _LiabAcct6 as String
	Private _Pvdate7 as Date
	Private _AcctgPrd8 as String
	Private _BudFy9 as String
	Private _DeptOrg10 as String
	Private _Doctot11 as Decimal
	Private _Dept12 as String
	Private _VinvNum13 as String
	Private _VendCode14 as String
	Private _Emp15 as String
	Private _Vname16a as String
	Private _Vname16b as String
	Private _Vname16c as String
	Private _Vname16d as String
	Private _R01 as String
	Private _Ln1 as String
	Private _R02 as String
	Private _Ln2 as String
	Private _R03 as String
	Private _Ln3 as String
	Private _R04 as String
	Private _Ln4 as String
	Private _R05 as String
	Private _Ln5 as String
	Private _R06 as String
	Private _Ln6 as String
	Private _R07 as String
	Private _Ln7 as String
	Private _R08 as String
	Private _Ln8 as String
	Private _R09 as String
	Private _Ln9 as String
	Private _R010 as String
	Private _Ln10 as String
	Private _D1 as String
	Private _D2 as String
	Private _D3 as String
	Private _D4 as String
	Private _D5 as String
	Private _D6 as String
	Private _D7 as String
	Private _D8 as String
	Private _D9 as String
	Private _D10 as String
	Private _D12 as String
	Private _Q1 as Double
	Private _Up1 as Decimal
	Private _A1 as Decimal
	Private _Q2 as Double
	Private _Up2 as Decimal
	Private _A2 as Decimal
	Private _Q3 as Double
	Private _Up3 as Decimal
	Private _A3 as Decimal
	Private _Q4 as Double
	Private _Up4 as Decimal
	Private _A4 as Decimal
	Private _Q5 as Double
	Private _Up5 as Decimal
	Private _A5 as Decimal
	Private _Q6 as Double
	Private _Up6 as Decimal
	Private _A6 as Decimal
	Private _Q7 as Double
	Private _Up7 as Decimal
	Private _A7 as Decimal
	Private _Q8 as Double
	Private _Up8 as Decimal
	Private _A8 as Decimal
	Private _Q9 as Double
	Private _Up9 as Decimal
	Private _A9 as Decimal
	Private _Q10 as Double
	Private _Up10 as Decimal
	Private _A10 as Decimal
	Private _Ln17 as String
	Private _Trans18 as String
	Private _Dept19 as String
	Private _ROrg-20 as String
	Private _Number21 as String
	Private _Line22 as String
	Private _Dept23 as String
	Private _Approp24 as String
	Private _Sub25 as String
	Private _Org26 as String
	Private _Sorg27 as String
	Private _Obj28 as String
	Private _Sobj29 as String
	Private _Prog30 as String
	Private _Ty31 as String
	Private _Proj32 as String
	Private _Rptg33 as String
	Private _Fund34 as String
	Private _Bsacct35 as String
	Private _Dept36 as String
	Private _VinvNum37 as String
	Private _Desc38 as String
	Private _Disc39 as String
	Private _FrmDate40 as Date
	Private _ToDate41 as Date
	Private _Quant42 as Double
	Private _Amount43 as Decimal
	Private _Id44 as String
	Private _Pf45 as String
	Private _CrAcctNu as String
	Private _DrAcctNu as String
	Private _Agency as Integer
	Private _Print as String
	Private _EntryDate as Date
	Private _Dflag as String
	Private _Void as String

Public Property ContractKey()  as String
	Get
		Return _ContractKey
	End Get
	Set (ByVal value  as String )
		_ContractKey = value
	End Set
End Property

Public Property PvForm()  as String
	Get
		Return _PvForm
	End Get
	Set (ByVal value  as String )
		_PvForm = value
	End Set
End Property

Public Property Dept1()  as String
	Get
		Return _Dept1
	End Get
	Set (ByVal value  as String )
		_Dept1 = value
	End Set
End Property

Public Property ROrg-2()  as String
	Get
		Return _ROrg-2
	End Get
	Set (ByVal value  as String )
		_ROrg-2 = value
	End Set
End Property

Public Property Num3()  as String
	Get
		Return _Num3
	End Get
	Set (ByVal value  as String )
		_Num3 = value
	End Set
End Property

Public Property Action4()  as String
	Get
		Return _Action4
	End Get
	Set (ByVal value  as String )
		_Action4 = value
	End Set
End Property

Public Property SchDate5()  as Date
	Get
		Return _SchDate5
	End Get
	Set (ByVal value  as Date )
		_SchDate5 = value
	End Set
End Property

Public Property LiabAcct6()  as String
	Get
		Return _LiabAcct6
	End Get
	Set (ByVal value  as String )
		_LiabAcct6 = value
	End Set
End Property

Public Property Pvdate7()  as Date
	Get
		Return _Pvdate7
	End Get
	Set (ByVal value  as Date )
		_Pvdate7 = value
	End Set
End Property

Public Property AcctgPrd8()  as String
	Get
		Return _AcctgPrd8
	End Get
	Set (ByVal value  as String )
		_AcctgPrd8 = value
	End Set
End Property

Public Property BudFy9()  as String
	Get
		Return _BudFy9
	End Get
	Set (ByVal value  as String )
		_BudFy9 = value
	End Set
End Property

Public Property DeptOrg10()  as String
	Get
		Return _DeptOrg10
	End Get
	Set (ByVal value  as String )
		_DeptOrg10 = value
	End Set
End Property

Public Property Doctot11()  as Decimal
	Get
		Return _Doctot11
	End Get
	Set (ByVal value  as Decimal )
		_Doctot11 = value
	End Set
End Property

Public Property Dept12()  as String
	Get
		Return _Dept12
	End Get
	Set (ByVal value  as String )
		_Dept12 = value
	End Set
End Property

Public Property VinvNum13()  as String
	Get
		Return _VinvNum13
	End Get
	Set (ByVal value  as String )
		_VinvNum13 = value
	End Set
End Property

Public Property VendCode14()  as String
	Get
		Return _VendCode14
	End Get
	Set (ByVal value  as String )
		_VendCode14 = value
	End Set
End Property

Public Property Emp15()  as String
	Get
		Return _Emp15
	End Get
	Set (ByVal value  as String )
		_Emp15 = value
	End Set
End Property

Public Property Vname16a()  as String
	Get
		Return _Vname16a
	End Get
	Set (ByVal value  as String )
		_Vname16a = value
	End Set
End Property

Public Property Vname16b()  as String
	Get
		Return _Vname16b
	End Get
	Set (ByVal value  as String )
		_Vname16b = value
	End Set
End Property

Public Property Vname16c()  as String
	Get
		Return _Vname16c
	End Get
	Set (ByVal value  as String )
		_Vname16c = value
	End Set
End Property

Public Property Vname16d()  as String
	Get
		Return _Vname16d
	End Get
	Set (ByVal value  as String )
		_Vname16d = value
	End Set
End Property

Public Property R01()  as String
	Get
		Return _R01
	End Get
	Set (ByVal value  as String )
		_R01 = value
	End Set
End Property

Public Property Ln1()  as String
	Get
		Return _Ln1
	End Get
	Set (ByVal value  as String )
		_Ln1 = value
	End Set
End Property

Public Property R02()  as String
	Get
		Return _R02
	End Get
	Set (ByVal value  as String )
		_R02 = value
	End Set
End Property

Public Property Ln2()  as String
	Get
		Return _Ln2
	End Get
	Set (ByVal value  as String )
		_Ln2 = value
	End Set
End Property

Public Property R03()  as String
	Get
		Return _R03
	End Get
	Set (ByVal value  as String )
		_R03 = value
	End Set
End Property

Public Property Ln3()  as String
	Get
		Return _Ln3
	End Get
	Set (ByVal value  as String )
		_Ln3 = value
	End Set
End Property

Public Property R04()  as String
	Get
		Return _R04
	End Get
	Set (ByVal value  as String )
		_R04 = value
	End Set
End Property

Public Property Ln4()  as String
	Get
		Return _Ln4
	End Get
	Set (ByVal value  as String )
		_Ln4 = value
	End Set
End Property

Public Property R05()  as String
	Get
		Return _R05
	End Get
	Set (ByVal value  as String )
		_R05 = value
	End Set
End Property

Public Property Ln5()  as String
	Get
		Return _Ln5
	End Get
	Set (ByVal value  as String )
		_Ln5 = value
	End Set
End Property

Public Property R06()  as String
	Get
		Return _R06
	End Get
	Set (ByVal value  as String )
		_R06 = value
	End Set
End Property

Public Property Ln6()  as String
	Get
		Return _Ln6
	End Get
	Set (ByVal value  as String )
		_Ln6 = value
	End Set
End Property

Public Property R07()  as String
	Get
		Return _R07
	End Get
	Set (ByVal value  as String )
		_R07 = value
	End Set
End Property

Public Property Ln7()  as String
	Get
		Return _Ln7
	End Get
	Set (ByVal value  as String )
		_Ln7 = value
	End Set
End Property

Public Property R08()  as String
	Get
		Return _R08
	End Get
	Set (ByVal value  as String )
		_R08 = value
	End Set
End Property

Public Property Ln8()  as String
	Get
		Return _Ln8
	End Get
	Set (ByVal value  as String )
		_Ln8 = value
	End Set
End Property

Public Property R09()  as String
	Get
		Return _R09
	End Get
	Set (ByVal value  as String )
		_R09 = value
	End Set
End Property

Public Property Ln9()  as String
	Get
		Return _Ln9
	End Get
	Set (ByVal value  as String )
		_Ln9 = value
	End Set
End Property

Public Property R010()  as String
	Get
		Return _R010
	End Get
	Set (ByVal value  as String )
		_R010 = value
	End Set
End Property

Public Property Ln10()  as String
	Get
		Return _Ln10
	End Get
	Set (ByVal value  as String )
		_Ln10 = value
	End Set
End Property

Public Property D1()  as String
	Get
		Return _D1
	End Get
	Set (ByVal value  as String )
		_D1 = value
	End Set
End Property

Public Property D2()  as String
	Get
		Return _D2
	End Get
	Set (ByVal value  as String )
		_D2 = value
	End Set
End Property

Public Property D3()  as String
	Get
		Return _D3
	End Get
	Set (ByVal value  as String )
		_D3 = value
	End Set
End Property

Public Property D4()  as String
	Get
		Return _D4
	End Get
	Set (ByVal value  as String )
		_D4 = value
	End Set
End Property

Public Property D5()  as String
	Get
		Return _D5
	End Get
	Set (ByVal value  as String )
		_D5 = value
	End Set
End Property

Public Property D6()  as String
	Get
		Return _D6
	End Get
	Set (ByVal value  as String )
		_D6 = value
	End Set
End Property

Public Property D7()  as String
	Get
		Return _D7
	End Get
	Set (ByVal value  as String )
		_D7 = value
	End Set
End Property

Public Property D8()  as String
	Get
		Return _D8
	End Get
	Set (ByVal value  as String )
		_D8 = value
	End Set
End Property

Public Property D9()  as String
	Get
		Return _D9
	End Get
	Set (ByVal value  as String )
		_D9 = value
	End Set
End Property

Public Property D10()  as String
	Get
		Return _D10
	End Get
	Set (ByVal value  as String )
		_D10 = value
	End Set
End Property

Public Property D12()  as String
	Get
		Return _D12
	End Get
	Set (ByVal value  as String )
		_D12 = value
	End Set
End Property

Public Property Q1()  as Double
	Get
		Return _Q1
	End Get
	Set (ByVal value  as Double )
		_Q1 = value
	End Set
End Property

Public Property Up1()  as Decimal
	Get
		Return _Up1
	End Get
	Set (ByVal value  as Decimal )
		_Up1 = value
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

Public Property Q2()  as Double
	Get
		Return _Q2
	End Get
	Set (ByVal value  as Double )
		_Q2 = value
	End Set
End Property

Public Property Up2()  as Decimal
	Get
		Return _Up2
	End Get
	Set (ByVal value  as Decimal )
		_Up2 = value
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

Public Property Q3()  as Double
	Get
		Return _Q3
	End Get
	Set (ByVal value  as Double )
		_Q3 = value
	End Set
End Property

Public Property Up3()  as Decimal
	Get
		Return _Up3
	End Get
	Set (ByVal value  as Decimal )
		_Up3 = value
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

Public Property Q4()  as Double
	Get
		Return _Q4
	End Get
	Set (ByVal value  as Double )
		_Q4 = value
	End Set
End Property

Public Property Up4()  as Decimal
	Get
		Return _Up4
	End Get
	Set (ByVal value  as Decimal )
		_Up4 = value
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

Public Property Q5()  as Double
	Get
		Return _Q5
	End Get
	Set (ByVal value  as Double )
		_Q5 = value
	End Set
End Property

Public Property Up5()  as Decimal
	Get
		Return _Up5
	End Get
	Set (ByVal value  as Decimal )
		_Up5 = value
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

Public Property Q6()  as Double
	Get
		Return _Q6
	End Get
	Set (ByVal value  as Double )
		_Q6 = value
	End Set
End Property

Public Property Up6()  as Decimal
	Get
		Return _Up6
	End Get
	Set (ByVal value  as Decimal )
		_Up6 = value
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

Public Property Q7()  as Double
	Get
		Return _Q7
	End Get
	Set (ByVal value  as Double )
		_Q7 = value
	End Set
End Property

Public Property Up7()  as Decimal
	Get
		Return _Up7
	End Get
	Set (ByVal value  as Decimal )
		_Up7 = value
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

Public Property Q8()  as Double
	Get
		Return _Q8
	End Get
	Set (ByVal value  as Double )
		_Q8 = value
	End Set
End Property

Public Property Up8()  as Decimal
	Get
		Return _Up8
	End Get
	Set (ByVal value  as Decimal )
		_Up8 = value
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

Public Property Q9()  as Double
	Get
		Return _Q9
	End Get
	Set (ByVal value  as Double )
		_Q9 = value
	End Set
End Property

Public Property Up9()  as Decimal
	Get
		Return _Up9
	End Get
	Set (ByVal value  as Decimal )
		_Up9 = value
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

Public Property Q10()  as Double
	Get
		Return _Q10
	End Get
	Set (ByVal value  as Double )
		_Q10 = value
	End Set
End Property

Public Property Up10()  as Decimal
	Get
		Return _Up10
	End Get
	Set (ByVal value  as Decimal )
		_Up10 = value
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

Public Property Ln17()  as String
	Get
		Return _Ln17
	End Get
	Set (ByVal value  as String )
		_Ln17 = value
	End Set
End Property

Public Property Trans18()  as String
	Get
		Return _Trans18
	End Get
	Set (ByVal value  as String )
		_Trans18 = value
	End Set
End Property

Public Property Dept19()  as String
	Get
		Return _Dept19
	End Get
	Set (ByVal value  as String )
		_Dept19 = value
	End Set
End Property

Public Property ROrg-20()  as String
	Get
		Return _ROrg-20
	End Get
	Set (ByVal value  as String )
		_ROrg-20 = value
	End Set
End Property

Public Property Number21()  as String
	Get
		Return _Number21
	End Get
	Set (ByVal value  as String )
		_Number21 = value
	End Set
End Property

Public Property Line22()  as String
	Get
		Return _Line22
	End Get
	Set (ByVal value  as String )
		_Line22 = value
	End Set
End Property

Public Property Dept23()  as String
	Get
		Return _Dept23
	End Get
	Set (ByVal value  as String )
		_Dept23 = value
	End Set
End Property

Public Property Approp24()  as String
	Get
		Return _Approp24
	End Get
	Set (ByVal value  as String )
		_Approp24 = value
	End Set
End Property

Public Property Sub25()  as String
	Get
		Return _Sub25
	End Get
	Set (ByVal value  as String )
		_Sub25 = value
	End Set
End Property

Public Property Org26()  as String
	Get
		Return _Org26
	End Get
	Set (ByVal value  as String )
		_Org26 = value
	End Set
End Property

Public Property Sorg27()  as String
	Get
		Return _Sorg27
	End Get
	Set (ByVal value  as String )
		_Sorg27 = value
	End Set
End Property

Public Property Obj28()  as String
	Get
		Return _Obj28
	End Get
	Set (ByVal value  as String )
		_Obj28 = value
	End Set
End Property

Public Property Sobj29()  as String
	Get
		Return _Sobj29
	End Get
	Set (ByVal value  as String )
		_Sobj29 = value
	End Set
End Property

Public Property Prog30()  as String
	Get
		Return _Prog30
	End Get
	Set (ByVal value  as String )
		_Prog30 = value
	End Set
End Property

Public Property Ty31()  as String
	Get
		Return _Ty31
	End Get
	Set (ByVal value  as String )
		_Ty31 = value
	End Set
End Property

Public Property Proj32()  as String
	Get
		Return _Proj32
	End Get
	Set (ByVal value  as String )
		_Proj32 = value
	End Set
End Property

Public Property Rptg33()  as String
	Get
		Return _Rptg33
	End Get
	Set (ByVal value  as String )
		_Rptg33 = value
	End Set
End Property

Public Property Fund34()  as String
	Get
		Return _Fund34
	End Get
	Set (ByVal value  as String )
		_Fund34 = value
	End Set
End Property

Public Property Bsacct35()  as String
	Get
		Return _Bsacct35
	End Get
	Set (ByVal value  as String )
		_Bsacct35 = value
	End Set
End Property

Public Property Dept36()  as String
	Get
		Return _Dept36
	End Get
	Set (ByVal value  as String )
		_Dept36 = value
	End Set
End Property

Public Property VinvNum37()  as String
	Get
		Return _VinvNum37
	End Get
	Set (ByVal value  as String )
		_VinvNum37 = value
	End Set
End Property

Public Property Desc38()  as String
	Get
		Return _Desc38
	End Get
	Set (ByVal value  as String )
		_Desc38 = value
	End Set
End Property

Public Property Disc39()  as String
	Get
		Return _Disc39
	End Get
	Set (ByVal value  as String )
		_Disc39 = value
	End Set
End Property

Public Property FrmDate40()  as Date
	Get
		Return _FrmDate40
	End Get
	Set (ByVal value  as Date )
		_FrmDate40 = value
	End Set
End Property

Public Property ToDate41()  as Date
	Get
		Return _ToDate41
	End Get
	Set (ByVal value  as Date )
		_ToDate41 = value
	End Set
End Property

Public Property Quant42()  as Double
	Get
		Return _Quant42
	End Get
	Set (ByVal value  as Double )
		_Quant42 = value
	End Set
End Property

Public Property Amount43()  as Decimal
	Get
		Return _Amount43
	End Get
	Set (ByVal value  as Decimal )
		_Amount43 = value
	End Set
End Property

Public Property Id44()  as String
	Get
		Return _Id44
	End Get
	Set (ByVal value  as String )
		_Id44 = value
	End Set
End Property

Public Property Pf45()  as String
	Get
		Return _Pf45
	End Get
	Set (ByVal value  as String )
		_Pf45 = value
	End Set
End Property

Public Property CrAcctNu()  as String
	Get
		Return _CrAcctNu
	End Get
	Set (ByVal value  as String )
		_CrAcctNu = value
	End Set
End Property

Public Property DrAcctNu()  as String
	Get
		Return _DrAcctNu
	End Get
	Set (ByVal value  as String )
		_DrAcctNu = value
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

Public Property Print()  as String
	Get
		Return _Print
	End Get
	Set (ByVal value  as String )
		_Print = value
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

Public Property Void()  as String
	Get
		Return _Void
	End Get
	Set (ByVal value  as String )
		_Void = value
	End Set
End Property


Public ReadOnly Property CashRctColumnNames() as string
		Get 
	              	              	              return "([ContractKey] , [PvForm] , [Dept1] , [ROrg-2] , [Num3] , [Action4] , [SchDate5] , [LiabAcct6] , [Pvdate7] , [AcctgPrd8] , [BudFy9] , [DeptOrg10] , [Doctot11] , [Dept12] , [VinvNum13] , [VendCode14] , [Emp15] , [Vname16a] , [Vname16b] , [Vname16c] , [Vname16d] , [R01] , [Ln1] , [R02] , [Ln2] , [R03] , [Ln3] , [R04] , [Ln4] , [R05] , [Ln5] , [R06] , [Ln6] , [R07] , [Ln7] , [R08] , [Ln8] , [R09] , [Ln9] , [R010] , [Ln10] , [D1] , [D2] , [D3] , [D4] , [D5] , [D6] , [D7] , [D8] , [D9] , [D10] , [D12] , [Q1] , [Up1] , [A1] , [Q2] , [Up2] , [A2] , [Q3] , [Up3] , [A3] , [Q4] , [Up4] , [A4] , [Q5] , [Up5] , [A5] , [Q6] , [Up6] , [A6] , [Q7] , [Up7] , [A7] , [Q8] , [Up8] , [A8] , [Q9] , [Up9] , [A9] , [Q10] , [Up10] , [A10] , [Ln17] , [Trans18] , [Dept19] , [ROrg-20] , [Number21] , [Line22] , [Dept23] , [Approp24] , [Sub25] , [Org26] , [Sorg27] , [Obj28] , [Sobj29] , [Prog30] , [Ty31] , [Proj32] , [Rptg33] , [Fund34] , [Bsacct35] , [Dept36] , [VinvNum37] , [Desc38] , [Disc39] , [FrmDate40] , [ToDate41] , [Quant42] , [Amount43] , [Id44] , [Pf45] , [CrAcctNu] , [DrAcctNu] , [Agency] , [Print] , [EntryDate] , [Dflag] , [Void] )"
		End Get
End Property

Public ReadOnly Property CashRctColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} , {43} , {44} , {45} , {46} , {47} , {48} , {49} , {50} , {51} , {52} , {53} , {54} , {55} , {56} , {57} , {58} , {59} , {60} , {61} , {62} , {63} , {64} , {65} , {66} , {67} , {68} , {69} , {70} , {71} , {72} , {73} , {74} , {75} , {76} , {77} , {78} , {79} , {80} , {81} , {82} , {83} , {84} , {85} , {86} , {87} , {88} , {89} , {90} , {91} , {92} , {93} , {94} , {95} , {96} , {97} , {98} , {99} , {100} , {101} , {102} , {103} , {104} , {105} , {106} , {107} , {108} , {109} , {110} , {111} , {112} , {113} , {114} , {115} , {116} , {117} )"  _  
	 , (_ContractKey) _ 
	 , (_PvForm) _ 
	 , (_Dept1) _ 
	 , (_ROrg-2) _ 
	 , (_Num3) _ 
	 , (_Action4) _ 
	 , (_SchDate5) _ 
	 , (_LiabAcct6) _ 
	 , (_Pvdate7) _ 
	 , (_AcctgPrd8) _ 
	 , (_BudFy9) _ 
	 , (_DeptOrg10) _ 
	 , (_Doctot11) _ 
	 , (_Dept12) _ 
	 , (_VinvNum13) _ 
	 , (_VendCode14) _ 
	 , (_Emp15) _ 
	 , (_Vname16a) _ 
	 , (_Vname16b) _ 
	 , (_Vname16c) _ 
	 , (_Vname16d) _ 
	 , (_R01) _ 
	 , (_Ln1) _ 
	 , (_R02) _ 
	 , (_Ln2) _ 
	 , (_R03) _ 
	 , (_Ln3) _ 
	 , (_R04) _ 
	 , (_Ln4) _ 
	 , (_R05) _ 
	 , (_Ln5) _ 
	 , (_R06) _ 
	 , (_Ln6) _ 
	 , (_R07) _ 
	 , (_Ln7) _ 
	 , (_R08) _ 
	 , (_Ln8) _ 
	 , (_R09) _ 
	 , (_Ln9) _ 
	 , (_R010) _ 
	 , (_Ln10) _ 
	 , (_D1) _ 
	 , (_D2) _ 
	 , (_D3) _ 
	 , (_D4) _ 
	 , (_D5) _ 
	 , (_D6) _ 
	 , (_D7) _ 
	 , (_D8) _ 
	 , (_D9) _ 
	 , (_D10) _ 
	 , (_D12) _ 
	 , (_Q1) _ 
	 , (_Up1) _ 
	 , (_A1) _ 
	 , (_Q2) _ 
	 , (_Up2) _ 
	 , (_A2) _ 
	 , (_Q3) _ 
	 , (_Up3) _ 
	 , (_A3) _ 
	 , (_Q4) _ 
	 , (_Up4) _ 
	 , (_A4) _ 
	 , (_Q5) _ 
	 , (_Up5) _ 
	 , (_A5) _ 
	 , (_Q6) _ 
	 , (_Up6) _ 
	 , (_A6) _ 
	 , (_Q7) _ 
	 , (_Up7) _ 
	 , (_A7) _ 
	 , (_Q8) _ 
	 , (_Up8) _ 
	 , (_A8) _ 
	 , (_Q9) _ 
	 , (_Up9) _ 
	 , (_A9) _ 
	 , (_Q10) _ 
	 , (_Up10) _ 
	 , (_A10) _ 
	 , (_Ln17) _ 
	 , (_Trans18) _ 
	 , (_Dept19) _ 
	 , (_ROrg-20) _ 
	 , (_Number21) _ 
	 , (_Line22) _ 
	 , (_Dept23) _ 
	 , (_Approp24) _ 
	 , (_Sub25) _ 
	 , (_Org26) _ 
	 , (_Sorg27) _ 
	 , (_Obj28) _ 
	 , (_Sobj29) _ 
	 , (_Prog30) _ 
	 , (_Ty31) _ 
	 , (_Proj32) _ 
	 , (_Rptg33) _ 
	 , (_Fund34) _ 
	 , (_Bsacct35) _ 
	 , (_Dept36) _ 
	 , (_VinvNum37) _ 
	 , (_Desc38) _ 
	 , (_Disc39) _ 
	 , (_FrmDate40) _ 
	 , (_ToDate41) _ 
	 , (_Quant42) _ 
	 , (_Amount43) _ 
	 , (_Id44) _ 
	 , (_Pf45) _ 
	 , (_CrAcctNu) _ 
	 , (_DrAcctNu) _ 
	 , (_Agency) _ 
	 , (_Print) _ 
	 , (_EntryDate) _ 
	 , (_Dflag) _ 
	 , (_Void) _ 
)
		End Get
End Property
End Class
