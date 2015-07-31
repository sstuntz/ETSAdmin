Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Imports PS.Common

Public Class PVData
    Private _ContractKey As String
    Private _PvForm As String
    Private _Dept1 As String
    Private _ROrg2 As String
    Private _Num3 As String
    Private _Action4 As String
    Private _SchDate5 As Date
    Private _LiabAcct6 As String
    Private _Pvdate7 As Date
    Private _AcctgPrd8 As String
    Private _BudFy9 As String
    Private _DeptOrg10 As String
    Private _Doctot11 As Decimal
    Private _Dept12 As String
    Private _VinvNum13 As String
    Private _VendCode14 As String
    Private _Emp15 As String
    Private _Vname16a As String
    Private _Vname16b As String
    Private _Vname16c As String
    Private _Vname16d As String
    Private _R01 As String
    Private _Ln1 As String
    Private _R02 As String
    Private _Ln2 As String
    Private _R03 As String
    Private _Ln3 As String
    Private _R04 As String
    Private _Ln4 As String
    Private _R05 As String
    Private _Ln5 As String
    Private _R06 As String
    Private _Ln6 As String
    Private _R07 As String
    Private _Ln7 As String
    Private _R08 As String
    Private _Ln8 As String
    Private _R09 As String
    Private _Ln9 As String
    Private _R010 As String
    Private _Ln10 As String
    Private _D1 As String
    Private _D2 As String
    Private _D3 As String
    Private _D4 As String
    Private _D5 As String
    Private _D6 As String
    Private _D7 As String
    Private _D8 As String
    Private _D9 As String
    Private _D10 As String
    Private _D12 As String
    Private _Q1 As Double
    Private _Up1 As Decimal
    Private _A1 As Decimal
    Private _Q2 As Double
    Private _Up2 As Decimal
    Private _A2 As Decimal
    Private _Q3 As Double
    Private _Up3 As Decimal
    Private _A3 As Decimal
    Private _Q4 As Double
    Private _Up4 As Decimal
    Private _A4 As Decimal
    Private _Q5 As Double
    Private _Up5 As Decimal
    Private _A5 As Decimal
    Private _Q6 As Double
    Private _Up6 As Decimal
    Private _A6 As Decimal
    Private _Q7 As Double
    Private _Up7 As Decimal
    Private _A7 As Decimal
    Private _Q8 As Double
    Private _Up8 As Decimal
    Private _A8 As Decimal
    Private _Q9 As Double
    Private _Up9 As Decimal
    Private _A9 As Decimal
    Private _Q10 As Double
    Private _Up10 As Decimal
    Private _A10 As Decimal
    Private _Ln17 As String
    Private _Trans18 As String
    Private _Dept19 As String
    Private _ROrg20 As String
    Private _Number21 As String
    Private _Line22 As String
    Private _Dept23 As String
    Private _Approp24 As String
    Private _Sub25 As String
    Private _Org26 As String
    Private _Sorg27 As String
    Private _Obj28 As String
    Private _Sobj29 As String
    Private _Prog30 As String
    Private _Ty31 As String
    Private _Proj32 As String
    Private _Rptg33 As String
    Private _Fund34 As String
    Private _Bsacct35 As String
    Private _Dept36 As String
    Private _VinvNum37 As String
    Private _Desc38 As String
    Private _Disc39 As String
    Private _FrmDate40 As Date
    Private _ToDate41 As Date
    Private _Quant42 As Double
    Private _Amount43 As Decimal
    Private _Id44 As String
    Private _Pf45 As String
    Private _CrAcctNu As String
    Private _DrAcctNu As String
    Private _Agency As Integer
    Private _Print As String
    Private _EntryDate As Date
    Private _Dflag As String
    Private _Void As String

    Public Property ContractKey() As String
        Get
            Return _ContractKey
        End Get
        Set(ByVal value As String)
            _ContractKey = value
        End Set
    End Property

    Public Property PvForm() As String
        Get
            Return _PvForm
        End Get
        Set(ByVal value As String)
            _PvForm = value
        End Set
    End Property

    Public Property Dept1() As String
        Get
            Return _Dept1
        End Get
        Set(ByVal value As String)
            _Dept1 = value
        End Set
    End Property

    Public Property ROrg2() As String
        Get
            Return _ROrg2
        End Get
        Set(ByVal value As String)
            _ROrg2 = value
        End Set
    End Property

    Public Property Num3() As String
        Get
            Return _Num3
        End Get
        Set(ByVal value As String)
            _Num3 = value
        End Set
    End Property

    Public Property Action4() As String
        Get
            Return _Action4
        End Get
        Set(ByVal value As String)
            _Action4 = value
        End Set
    End Property

    Public Property SchDate5() As Date
        Get
            Return _SchDate5
        End Get
        Set(ByVal value As Date)
            _SchDate5 = value
        End Set
    End Property

    Public Property LiabAcct6() As String
        Get
            Return _LiabAcct6
        End Get
        Set(ByVal value As String)
            _LiabAcct6 = value
        End Set
    End Property

    Public Property Pvdate7() As Date
        Get
            Return _Pvdate7
        End Get
        Set(ByVal value As Date)
            _Pvdate7 = value
        End Set
    End Property

    Public Property AcctgPrd8() As String
        Get
            Return _AcctgPrd8
        End Get
        Set(ByVal value As String)
            _AcctgPrd8 = value
        End Set
    End Property

    Public Property BudFy9() As String
        Get
            Return _BudFy9
        End Get
        Set(ByVal value As String)
            _BudFy9 = value
        End Set
    End Property

    Public Property DeptOrg10() As String
        Get
            Return _DeptOrg10
        End Get
        Set(ByVal value As String)
            _DeptOrg10 = value
        End Set
    End Property

    Public Property Doctot11() As Decimal
        Get
            Return _Doctot11
        End Get
        Set(ByVal value As Decimal)
            _Doctot11 = value
        End Set
    End Property

    Public Property Dept12() As String
        Get
            Return _Dept12
        End Get
        Set(ByVal value As String)
            _Dept12 = value
        End Set
    End Property

    Public Property VinvNum13() As String
        Get
            Return _VinvNum13
        End Get
        Set(ByVal value As String)
            _VinvNum13 = value
        End Set
    End Property

    Public Property VendCode14() As String
        Get
            Return _VendCode14
        End Get
        Set(ByVal value As String)
            _VendCode14 = value
        End Set
    End Property

    Public Property Emp15() As String
        Get
            Return _Emp15
        End Get
        Set(ByVal value As String)
            _Emp15 = value
        End Set
    End Property

    Public Property Vname16a() As String
        Get
            Return _Vname16a
        End Get
        Set(ByVal value As String)
            _Vname16a = value
        End Set
    End Property

    Public Property Vname16b() As String
        Get
            Return _Vname16b
        End Get
        Set(ByVal value As String)
            _Vname16b = value
        End Set
    End Property

    Public Property Vname16c() As String
        Get
            Return _Vname16c
        End Get
        Set(ByVal value As String)
            _Vname16c = value
        End Set
    End Property

    Public Property Vname16d() As String
        Get
            Return _Vname16d
        End Get
        Set(ByVal value As String)
            _Vname16d = value
        End Set
    End Property

    Public Property R01() As String
        Get
            Return _R01
        End Get
        Set(ByVal value As String)
            _R01 = value
        End Set
    End Property

    Public Property Ln1() As String
        Get
            Return _Ln1
        End Get
        Set(ByVal value As String)
            _Ln1 = value
        End Set
    End Property

    Public Property R02() As String
        Get
            Return _R02
        End Get
        Set(ByVal value As String)
            _R02 = value
        End Set
    End Property

    Public Property Ln2() As String
        Get
            Return _Ln2
        End Get
        Set(ByVal value As String)
            _Ln2 = value
        End Set
    End Property

    Public Property R03() As String
        Get
            Return _R03
        End Get
        Set(ByVal value As String)
            _R03 = value
        End Set
    End Property

    Public Property Ln3() As String
        Get
            Return _Ln3
        End Get
        Set(ByVal value As String)
            _Ln3 = value
        End Set
    End Property

    Public Property R04() As String
        Get
            Return _R04
        End Get
        Set(ByVal value As String)
            _R04 = value
        End Set
    End Property

    Public Property Ln4() As String
        Get
            Return _Ln4
        End Get
        Set(ByVal value As String)
            _Ln4 = value
        End Set
    End Property

    Public Property R05() As String
        Get
            Return _R05
        End Get
        Set(ByVal value As String)
            _R05 = value
        End Set
    End Property

    Public Property Ln5() As String
        Get
            Return _Ln5
        End Get
        Set(ByVal value As String)
            _Ln5 = value
        End Set
    End Property

    Public Property R06() As String
        Get
            Return _R06
        End Get
        Set(ByVal value As String)
            _R06 = value
        End Set
    End Property

    Public Property Ln6() As String
        Get
            Return _Ln6
        End Get
        Set(ByVal value As String)
            _Ln6 = value
        End Set
    End Property

    Public Property R07() As String
        Get
            Return _R07
        End Get
        Set(ByVal value As String)
            _R07 = value
        End Set
    End Property

    Public Property Ln7() As String
        Get
            Return _Ln7
        End Get
        Set(ByVal value As String)
            _Ln7 = value
        End Set
    End Property

    Public Property R08() As String
        Get
            Return _R08
        End Get
        Set(ByVal value As String)
            _R08 = value
        End Set
    End Property

    Public Property Ln8() As String
        Get
            Return _Ln8
        End Get
        Set(ByVal value As String)
            _Ln8 = value
        End Set
    End Property

    Public Property R09() As String
        Get
            Return _R09
        End Get
        Set(ByVal value As String)
            _R09 = value
        End Set
    End Property

    Public Property Ln9() As String
        Get
            Return _Ln9
        End Get
        Set(ByVal value As String)
            _Ln9 = value
        End Set
    End Property

    Public Property R010() As String
        Get
            Return _R010
        End Get
        Set(ByVal value As String)
            _R010 = value
        End Set
    End Property

    Public Property Ln10() As String
        Get
            Return _Ln10
        End Get
        Set(ByVal value As String)
            _Ln10 = value
        End Set
    End Property

    Public Property D1() As String
        Get
            Return _D1
        End Get
        Set(ByVal value As String)
            _D1 = value
        End Set
    End Property

    Public Property D2() As String
        Get
            Return _D2
        End Get
        Set(ByVal value As String)
            _D2 = value
        End Set
    End Property

    Public Property D3() As String
        Get
            Return _D3
        End Get
        Set(ByVal value As String)
            _D3 = value
        End Set
    End Property

    Public Property D4() As String
        Get
            Return _D4
        End Get
        Set(ByVal value As String)
            _D4 = value
        End Set
    End Property

    Public Property D5() As String
        Get
            Return _D5
        End Get
        Set(ByVal value As String)
            _D5 = value
        End Set
    End Property

    Public Property D6() As String
        Get
            Return _D6
        End Get
        Set(ByVal value As String)
            _D6 = value
        End Set
    End Property

    Public Property D7() As String
        Get
            Return _D7
        End Get
        Set(ByVal value As String)
            _D7 = value
        End Set
    End Property

    Public Property D8() As String
        Get
            Return _D8
        End Get
        Set(ByVal value As String)
            _D8 = value
        End Set
    End Property

    Public Property D9() As String
        Get
            Return _D9
        End Get
        Set(ByVal value As String)
            _D9 = value
        End Set
    End Property

    Public Property D10() As String
        Get
            Return _D10
        End Get
        Set(ByVal value As String)
            _D10 = value
        End Set
    End Property

    Public Property D12() As String
        Get
            Return _D12
        End Get
        Set(ByVal value As String)
            _D12 = value
        End Set
    End Property

    Public Property Q1() As Double
        Get
            Return _Q1
        End Get
        Set(ByVal value As Double)
            _Q1 = value
        End Set
    End Property

    Public Property Up1() As Decimal
        Get
            Return _Up1
        End Get
        Set(ByVal value As Decimal)
            _Up1 = value
        End Set
    End Property

    Public Property A1() As Decimal
        Get
            Return _A1
        End Get
        Set(ByVal value As Decimal)
            _A1 = value
        End Set
    End Property

    Public Property Q2() As Double
        Get
            Return _Q2
        End Get
        Set(ByVal value As Double)
            _Q2 = value
        End Set
    End Property

    Public Property Up2() As Decimal
        Get
            Return _Up2
        End Get
        Set(ByVal value As Decimal)
            _Up2 = value
        End Set
    End Property

    Public Property A2() As Decimal
        Get
            Return _A2
        End Get
        Set(ByVal value As Decimal)
            _A2 = value
        End Set
    End Property

    Public Property Q3() As Double
        Get
            Return _Q3
        End Get
        Set(ByVal value As Double)
            _Q3 = value
        End Set
    End Property

    Public Property Up3() As Decimal
        Get
            Return _Up3
        End Get
        Set(ByVal value As Decimal)
            _Up3 = value
        End Set
    End Property

    Public Property A3() As Decimal
        Get
            Return _A3
        End Get
        Set(ByVal value As Decimal)
            _A3 = value
        End Set
    End Property

    Public Property Q4() As Double
        Get
            Return _Q4
        End Get
        Set(ByVal value As Double)
            _Q4 = value
        End Set
    End Property

    Public Property Up4() As Decimal
        Get
            Return _Up4
        End Get
        Set(ByVal value As Decimal)
            _Up4 = value
        End Set
    End Property

    Public Property A4() As Decimal
        Get
            Return _A4
        End Get
        Set(ByVal value As Decimal)
            _A4 = value
        End Set
    End Property

    Public Property Q5() As Double
        Get
            Return _Q5
        End Get
        Set(ByVal value As Double)
            _Q5 = value
        End Set
    End Property

    Public Property Up5() As Decimal
        Get
            Return _Up5
        End Get
        Set(ByVal value As Decimal)
            _Up5 = value
        End Set
    End Property

    Public Property A5() As Decimal
        Get
            Return _A5
        End Get
        Set(ByVal value As Decimal)
            _A5 = value
        End Set
    End Property

    Public Property Q6() As Double
        Get
            Return _Q6
        End Get
        Set(ByVal value As Double)
            _Q6 = value
        End Set
    End Property

    Public Property Up6() As Decimal
        Get
            Return _Up6
        End Get
        Set(ByVal value As Decimal)
            _Up6 = value
        End Set
    End Property

    Public Property A6() As Decimal
        Get
            Return _A6
        End Get
        Set(ByVal value As Decimal)
            _A6 = value
        End Set
    End Property

    Public Property Q7() As Double
        Get
            Return _Q7
        End Get
        Set(ByVal value As Double)
            _Q7 = value
        End Set
    End Property

    Public Property Up7() As Decimal
        Get
            Return _Up7
        End Get
        Set(ByVal value As Decimal)
            _Up7 = value
        End Set
    End Property

    Public Property A7() As Decimal
        Get
            Return _A7
        End Get
        Set(ByVal value As Decimal)
            _A7 = value
        End Set
    End Property

    Public Property Q8() As Double
        Get
            Return _Q8
        End Get
        Set(ByVal value As Double)
            _Q8 = value
        End Set
    End Property

    Public Property Up8() As Decimal
        Get
            Return _Up8
        End Get
        Set(ByVal value As Decimal)
            _Up8 = value
        End Set
    End Property

    Public Property A8() As Decimal
        Get
            Return _A8
        End Get
        Set(ByVal value As Decimal)
            _A8 = value
        End Set
    End Property

    Public Property Q9() As Double
        Get
            Return _Q9
        End Get
        Set(ByVal value As Double)
            _Q9 = value
        End Set
    End Property

    Public Property Up9() As Decimal
        Get
            Return _Up9
        End Get
        Set(ByVal value As Decimal)
            _Up9 = value
        End Set
    End Property

    Public Property A9() As Decimal
        Get
            Return _A9
        End Get
        Set(ByVal value As Decimal)
            _A9 = value
        End Set
    End Property

    Public Property Q10() As Double
        Get
            Return _Q10
        End Get
        Set(ByVal value As Double)
            _Q10 = value
        End Set
    End Property

    Public Property Up10() As Decimal
        Get
            Return _Up10
        End Get
        Set(ByVal value As Decimal)
            _Up10 = value
        End Set
    End Property

    Public Property A10() As Decimal
        Get
            Return _A10
        End Get
        Set(ByVal value As Decimal)
            _A10 = value
        End Set
    End Property

    Public Property Ln17() As String
        Get
            Return _Ln17
        End Get
        Set(ByVal value As String)
            _Ln17 = value
        End Set
    End Property

    Public Property Trans18() As String
        Get
            Return _Trans18
        End Get
        Set(ByVal value As String)
            _Trans18 = value
        End Set
    End Property

    Public Property Dept19() As String
        Get
            Return _Dept19
        End Get
        Set(ByVal value As String)
            _Dept19 = value
        End Set
    End Property

    Public Property ROrg20() As String
        Get
            Return _ROrg20
        End Get
        Set(ByVal value As String)
            _ROrg20 = value
        End Set
    End Property

    Public Property Number21() As String
        Get
            Return _Number21
        End Get
        Set(ByVal value As String)
            _Number21 = value
        End Set
    End Property

    Public Property Line22() As String
        Get
            Return _Line22
        End Get
        Set(ByVal value As String)
            _Line22 = value
        End Set
    End Property

    Public Property Dept23() As String
        Get
            Return _Dept23
        End Get
        Set(ByVal value As String)
            _Dept23 = value
        End Set
    End Property

    Public Property Approp24() As String
        Get
            Return _Approp24
        End Get
        Set(ByVal value As String)
            _Approp24 = value
        End Set
    End Property

    Public Property Sub25() As String
        Get
            Return _Sub25
        End Get
        Set(ByVal value As String)
            _Sub25 = value
        End Set
    End Property

    Public Property Org26() As String
        Get
            Return _Org26
        End Get
        Set(ByVal value As String)
            _Org26 = value
        End Set
    End Property

    Public Property Sorg27() As String
        Get
            Return _Sorg27
        End Get
        Set(ByVal value As String)
            _Sorg27 = value
        End Set
    End Property

    Public Property Obj28() As String
        Get
            Return _Obj28
        End Get
        Set(ByVal value As String)
            _Obj28 = value
        End Set
    End Property

    Public Property Sobj29() As String
        Get
            Return _Sobj29
        End Get
        Set(ByVal value As String)
            _Sobj29 = value
        End Set
    End Property

    Public Property Prog30() As String
        Get
            Return _Prog30
        End Get
        Set(ByVal value As String)
            _Prog30 = value
        End Set
    End Property

    Public Property Ty31() As String
        Get
            Return _Ty31
        End Get
        Set(ByVal value As String)
            _Ty31 = value
        End Set
    End Property

    Public Property Proj32() As String
        Get
            Return _Proj32
        End Get
        Set(ByVal value As String)
            _Proj32 = value
        End Set
    End Property

    Public Property Rptg33() As String
        Get
            Return _Rptg33
        End Get
        Set(ByVal value As String)
            _Rptg33 = value
        End Set
    End Property

    Public Property Fund34() As String
        Get
            Return _Fund34
        End Get
        Set(ByVal value As String)
            _Fund34 = value
        End Set
    End Property

    Public Property Bsacct35() As String
        Get
            Return _Bsacct35
        End Get
        Set(ByVal value As String)
            _Bsacct35 = value
        End Set
    End Property

    Public Property Dept36() As String
        Get
            Return _Dept36
        End Get
        Set(ByVal value As String)
            _Dept36 = value
        End Set
    End Property

    Public Property VinvNum37() As String
        Get
            Return _VinvNum37
        End Get
        Set(ByVal value As String)
            _VinvNum37 = value
        End Set
    End Property

    Public Property Desc38() As String
        Get
            Return _Desc38
        End Get
        Set(ByVal value As String)
            _Desc38 = value
        End Set
    End Property

    Public Property Disc39() As String
        Get
            Return _Disc39
        End Get
        Set(ByVal value As String)
            _Disc39 = value
        End Set
    End Property

    Public Property FrmDate40() As Date
        Get
            Return _FrmDate40
        End Get
        Set(ByVal value As Date)
            _FrmDate40 = value
        End Set
    End Property

    Public Property ToDate41() As Date
        Get
            Return _ToDate41
        End Get
        Set(ByVal value As Date)
            _ToDate41 = value
        End Set
    End Property

    Public Property Quant42() As Double
        Get
            Return _Quant42
        End Get
        Set(ByVal value As Double)
            _Quant42 = value
        End Set
    End Property

    Public Property Amount43() As Decimal
        Get
            Return _Amount43
        End Get
        Set(ByVal value As Decimal)
            _Amount43 = value
        End Set
    End Property

    Public Property Id44() As String
        Get
            Return _Id44
        End Get
        Set(ByVal value As String)
            _Id44 = value
        End Set
    End Property

    Public Property Pf45() As String
        Get
            Return _Pf45
        End Get
        Set(ByVal value As String)
            _Pf45 = value
        End Set
    End Property

    Public Property CrAcctNu() As String
        Get
            Return _CrAcctNu
        End Get
        Set(ByVal value As String)
            _CrAcctNu = value
        End Set
    End Property

    Public Property DrAcctNu() As String
        Get
            Return _DrAcctNu
        End Get
        Set(ByVal value As String)
            _DrAcctNu = value
        End Set
    End Property

    Public Property Agency() As Integer
        Get
            Return _Agency
        End Get
        Set(ByVal value As Integer)
            _Agency = value
        End Set
    End Property

    Public Property Print() As String
        Get
            Return _Print
        End Get
        Set(ByVal value As String)
            _Print = value
        End Set
    End Property

    Public Property EntryDate() As Date
        Get
            Return _EntryDate
        End Get
        Set(ByVal value As Date)
            _EntryDate = value
        End Set
    End Property

    Public Property Dflag() As String
        Get
            Return _Dflag
        End Get
        Set(ByVal value As String)
            _Dflag = value
        End Set
    End Property

    Public Property Void() As String
        Get
            Return _Void
        End Get
        Set(ByVal value As String)
            _Void = value
        End Set
    End Property


    Public ReadOnly Property PVColumnNames() As String
        Get
            Return "([Contract_Key] , [Pv_Form] , [Dept-1] , [R-Org-2] , [Num-3] , [Action-4] , [Sch_Date-5] , [Liab_Acct-6] , [Pvdate-7] , [Acctg_Prd-8] , [Bud_Fy-9] , [Dept_Org-10] , [Doctot-11] , [Dept-12] , [Vinv_Num-13] , [Vend_Code-14] , [Emp-15] , [Vname-16a] , [Vname-16b] , [Vname-16c] , [Vname-16d] , [R01] , [Ln1] , [R02] , [Ln2] , [R03] , [Ln3] , [R04] , [Ln4] , [R05] , [Ln5] , [R06] , [Ln6] , [R07] , [Ln7] , [R08] , [Ln8] , [R09] , [Ln9] , [R010] , [Ln10] , [D1] , [D2] , [D3] , [D4] , [D5] , [D6] , [D7] , [D8] , [D9] , [D10] , [D12] , [Q1] , [Up1] , [A1] , [Q2] , [Up2] , [A2] , [Q3] , [Up3] , [A3] , [Q4] , [Up4] , [A4] , [Q5] , [Up5] , [A5] , [Q6] , [Up6] , [A6] , [Q7] , [Up7] , [A7] , [Q8] , [Up8] , [A8] , [Q9] , [Up9] , [A9] , [Q10] , [Up10] , [A10] , [Ln-17] , [Trans-18] , [Dept-19] , [R-Org-20] , [Number-21] , [Line-22] , [Dept-23] , [Approp-24] , [Sub-25] , [Org-26] , [Sorg-27] , [Obj-28] , [Sobj-29] , [Prog-30] , [Ty-31] , [Proj-32] , [Rptg-33] , [Fund-34] , [Bsacct-35] , [Dept-36] , [Vinv_Num-37] , [Desc-38] , [Disc-39] , [Frm_Date-40] , [To_Date-41] , [Quant-42] , [Amount-43] , [Id-44] , [Pf-45] , [Cr_Acct_Nu] , [Dr_Acct_Nu] , [Agency] , [Print] , [Entry_Date] , [Dflag] , [Void] )"
        End Get
    End Property

    Public ReadOnly Property PVColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} , {43} , {44} , {45} , {46} , {47} , {48} , {49} , {50} , {51} , {52} , {53} , {54} , {55} , {56} , {57} , {58} , {59} , {60} , {61} , {62} , {63} , {64} , {65} , {66} , {67} , {68} , {69} , {70} , {71} , {72} , {73} , {74} , {75} , {76} , {77} , {78} , {79} , {80} , {81} , {82} , {83} , {84} , {85} , {86} , {87} , {88} , {89} , {90} , {91} , {92} , {93} , {94} , {95} , {96} , {97} , {98} , {99} , {100} , {101} , {102} , {103} , {104} , {105} , {106} , {107} , {108} , {109} , {110} , {111} , {112} , {113} , {114} , {115} , {116} , {117} )" _
, Database.StringParam(_ContractKey.ToString) _
, Database.StringParam(_PvForm.ToString) _
, Database.StringParam(_Dept1.ToString) _
, Database.StringParam(_ROrg2.ToString) _
, Database.StringParam(_Num3.ToString) _
, Database.StringParam(_Action4.ToString) _
, Database.StringParam(_SchDate5.ToShortDateString) _
, Database.StringParam(_LiabAcct6.ToString) _
, Database.StringParam(_Pvdate7.ToShortDateString) _
, Database.StringParam(_AcctgPrd8.ToString) _
, Database.StringParam(_BudFy9.ToString) _
, Database.StringParam(_DeptOrg10.ToString) _
, (_Doctot11.ToString) _
, Database.StringParam(_Dept12.ToString) _
, Database.StringParam(_VinvNum13.ToString) _
, Database.StringParam(_VendCode14.ToString) _
, Database.StringParam(_Emp15.ToString) _
, Database.StringParam(_Vname16a.ToString) _
, Database.StringParam(_Vname16b.ToString) _
, Database.StringParam(_Vname16c.ToString) _
, Database.StringParam(_Vname16d.ToString) _
, Database.StringParam(_R01.ToString) _
, Database.StringParam(_Ln1.ToString) _
, Database.StringParam(_R02.ToString) _
, Database.StringParam(_Ln2.ToString) _
, Database.StringParam(_R03.ToString) _
, Database.StringParam(_Ln3.ToString) _
, Database.StringParam(_R04.ToString) _
, Database.StringParam(_Ln4.ToString) _
, Database.StringParam(_R05.ToString) _
, Database.StringParam(_Ln5.ToString) _
, Database.StringParam(_R06.ToString) _
, Database.StringParam(_Ln6.ToString) _
, Database.StringParam(_R07.ToString) _
, Database.StringParam(_Ln7.ToString) _
, Database.StringParam(_R08.ToString) _
, Database.StringParam(_Ln8.ToString) _
, Database.StringParam(_R09.ToString) _
, Database.StringParam(_Ln9.ToString) _
, Database.StringParam(_R010.ToString) _
, Database.StringParam(_Ln10.ToString) _
, Database.StringParam(_D1.ToString) _
, Database.StringParam(_D2.ToString) _
, Database.StringParam(_D3.ToString) _
, Database.StringParam(_D4.ToString) _
, Database.StringParam(_D5.ToString) _
, Database.StringParam(_D6.ToString) _
, Database.StringParam(_D7.ToString) _
, Database.StringParam(_D8.ToString) _
, Database.StringParam(_D9.ToString) _
, Database.StringParam(_D10.ToString) _
, Database.StringParam(_D12.ToString) _
, (_Q1.ToString) _
, (_Up1.ToString) _
, (_A1.ToString) _
, (_Q2.ToString) _
, (_Up2.ToString) _
, (_A2.ToString) _
, (_Q3.ToString) _
, (_Up3.ToString) _
, (_A3.ToString) _
, (_Q4.ToString) _
, (_Up4.ToString) _
, (_A4.ToString) _
, (_Q5.ToString) _
, (_Up5.ToString) _
, (_A5.ToString) _
, (_Q6.ToString) _
, (_Up6.ToString) _
, (_A6.ToString) _
, (_Q7.ToString) _
, (_Up7.ToString) _
, (_A7.ToString) _
, (_Q8.ToString) _
, (_Up8.ToString) _
, (_A8.ToString) _
, (_Q9.ToString) _
, (_Up9.ToString) _
, (_A9.ToString) _
, (_Q10.ToString) _
, (_Up10.ToString) _
, (_A10.ToString) _
, Database.StringParam(_Ln17.ToString) _
, Database.StringParam(_Trans18.ToString) _
, Database.StringParam(_Dept19.ToString) _
, Database.StringParam(_ROrg20.ToString) _
, Database.StringParam(_Number21.ToString) _
, Database.StringParam(_Line22.ToString) _
, Database.StringParam(_Dept23.ToString) _
, Database.StringParam(_Approp24.ToString) _
, Database.StringParam(_Sub25.ToString) _
, Database.StringParam(_Org26.ToString) _
, Database.StringParam(_Sorg27.ToString) _
, Database.StringParam(_Obj28.ToString) _
, Database.StringParam(_Sobj29.ToString) _
, Database.StringParam(_Prog30.ToString) _
, Database.StringParam(_Ty31.ToString) _
, Database.StringParam(_Proj32.ToString) _
, Database.StringParam(_Rptg33.ToString) _
, Database.StringParam(_Fund34.ToString) _
, Database.StringParam(_Bsacct35.ToString) _
, Database.StringParam(_Dept36.ToString) _
, Database.StringParam(_VinvNum37.ToString) _
, Database.StringParam(_Desc38.ToString) _
, Database.StringParam(_Disc39.ToString) _
, Database.StringParam(_FrmDate40.ToShortDateString) _
, Database.StringParam(_ToDate41.ToShortDateString) _
, (_Quant42.ToString) _
, (_Amount43.ToString) _
, Database.StringParam(_Id44.ToString) _
, Database.StringParam(_Pf45.ToString) _
, Database.StringParam(_CrAcctNu.ToString) _
, Database.StringParam(_DrAcctNu.ToString) _
, (_Agency.ToString) _
, Database.StringParam(_Print.ToString) _
, Database.StringParam(_EntryDate.ToShortDateString) _
, Database.StringParam(_Dflag.ToString) _
, Database.StringParam(_Void.ToString) _
)
        End Get
    End Property
End Class
