Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common


Public Class AttendReportData
    Private _BNum As String
    Private _NameKey As String
    Private _ContractKey As String
    Private _ScreenNam As String
    Private _SortName As String
    Private _AuthoNum As String
    Private _BillType As String
    Private _PvForm As String
    Private _RptType As String
    Private _UnitRate As Decimal
    Private _Offset As Decimal
    Private _SlotNum As Integer
    Private _NameChk As String
    Private _SsNum As String
    Private _MedNum As String
    Private _AttBeg As Date
    Private _AttCode As String
    Private _AttUnit As Double
    Private _InvoiceDate As Date
    Private _Invoice As String
    Private _CustNum As String
    Private _DrAcctNu As String
    Private _CrAcctNu As String
    Private _EntryDate As Date
    Private _Dflag As String
    Private _Agency As Integer
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
    Private _D11 As String
    Private _D12 As String
    Private _D13 As String
    Private _D14 As String
    Private _D15 As String
    Private _D16 As String
    Private _D17 As String
    Private _D18 As String
    Private _D19 As String
    Private _D20 As String
    Private _D21 As String
    Private _D22 As String
    Private _D23 As String
    Private _D24 As String
    Private _D25 As String
    Private _D26 As String
    Private _D27 As String
    Private _D28 As String
    Private _D29 As String
    Private _D30 As String
    Private _D31 As String
    Private _PayCat As String
    Private _AttEnd As Date
    Private _DolTot As Decimal
    Private _UnitTot As Decimal
    Private _ClientPct As Double
    Private _Void As String

    Public Property BNum() As String
        Get
            Return _BNum
        End Get
        Set(ByVal value As String)
            _BNum = value
        End Set
    End Property

    Public Property NameKey() As String
        Get
            Return _NameKey
        End Get
        Set(ByVal value As String)
            _NameKey = value
        End Set
    End Property

    Public Property ContractKey() As String
        Get
            Return _ContractKey
        End Get
        Set(ByVal value As String)
            _ContractKey = value
        End Set
    End Property

    Public Property ScreenNam() As String
        Get
            Return _ScreenNam
        End Get
        Set(ByVal value As String)
            _ScreenNam = value
        End Set
    End Property

    Public Property SortName() As String
        Get
            Return _SortName
        End Get
        Set(ByVal value As String)
            _SortName = value
        End Set
    End Property

    Public Property AuthoNum() As String
        Get
            Return _AuthoNum
        End Get
        Set(ByVal value As String)
            _AuthoNum = value
        End Set
    End Property

    Public Property BillType() As String
        Get
            Return _BillType
        End Get
        Set(ByVal value As String)
            _BillType = value
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

    Public Property RptType() As String
        Get
            Return _RptType
        End Get
        Set(ByVal value As String)
            _RptType = value
        End Set
    End Property

    Public Property UnitRate() As Decimal
        Get
            Return _UnitRate
        End Get
        Set(ByVal value As Decimal)
            _UnitRate = value
        End Set
    End Property

    Public Property Offset() As Decimal
        Get
            Return _Offset
        End Get
        Set(ByVal value As Decimal)
            _Offset = value
        End Set
    End Property

    Public Property SlotNum() As Integer
        Get
            Return _SlotNum
        End Get
        Set(ByVal value As Integer)
            _SlotNum = value
        End Set
    End Property

    Public Property NameChk() As String
        Get
            Return _NameChk
        End Get
        Set(ByVal value As String)
            _NameChk = value
        End Set
    End Property

    Public Property SsNum() As String
        Get
            Return _SsNum
        End Get
        Set(ByVal value As String)
            _SsNum = value
        End Set
    End Property

    Public Property MedNum() As String
        Get
            Return _MedNum
        End Get
        Set(ByVal value As String)
            _MedNum = value
        End Set
    End Property

    Public Property AttBeg() As Date
        Get
            Return _AttBeg
        End Get
        Set(ByVal value As Date)
            _AttBeg = value
        End Set
    End Property

    Public Property AttCode() As String
        Get
            Return _AttCode
        End Get
        Set(ByVal value As String)
            _AttCode = value
        End Set
    End Property

    Public Property AttUnit() As Double
        Get
            Return _AttUnit
        End Get
        Set(ByVal value As Double)
            _AttUnit = value
        End Set
    End Property

    Public Property InvoiceDate() As Date
        Get
            Return _InvoiceDate
        End Get
        Set(ByVal value As Date)
            _InvoiceDate = value
        End Set
    End Property

    Public Property Invoice() As String
        Get
            Return _Invoice
        End Get
        Set(ByVal value As String)
            _Invoice = value
        End Set
    End Property

    Public Property CustNum() As String
        Get
            Return _CustNum
        End Get
        Set(ByVal value As String)
            _CustNum = value
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

    Public Property CrAcctNu() As String
        Get
            Return _CrAcctNu
        End Get
        Set(ByVal value As String)
            _CrAcctNu = value
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

    Public Property Agency() As Integer
        Get
            Return _Agency
        End Get
        Set(ByVal value As Integer)
            _Agency = value
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

    Public Property D11() As String
        Get
            Return _D11
        End Get
        Set(ByVal value As String)
            _D11 = value
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

    Public Property D13() As String
        Get
            Return _D13
        End Get
        Set(ByVal value As String)
            _D13 = value
        End Set
    End Property

    Public Property D14() As String
        Get
            Return _D14
        End Get
        Set(ByVal value As String)
            _D14 = value
        End Set
    End Property

    Public Property D15() As String
        Get
            Return _D15
        End Get
        Set(ByVal value As String)
            _D15 = value
        End Set
    End Property

    Public Property D16() As String
        Get
            Return _D16
        End Get
        Set(ByVal value As String)
            _D16 = value
        End Set
    End Property

    Public Property D17() As String
        Get
            Return _D17
        End Get
        Set(ByVal value As String)
            _D17 = value
        End Set
    End Property

    Public Property D18() As String
        Get
            Return _D18
        End Get
        Set(ByVal value As String)
            _D18 = value
        End Set
    End Property

    Public Property D19() As String
        Get
            Return _D19
        End Get
        Set(ByVal value As String)
            _D19 = value
        End Set
    End Property

    Public Property D20() As String
        Get
            Return _D20
        End Get
        Set(ByVal value As String)
            _D20 = value
        End Set
    End Property

    Public Property D21() As String
        Get
            Return _D21
        End Get
        Set(ByVal value As String)
            _D21 = value
        End Set
    End Property

    Public Property D22() As String
        Get
            Return _D22
        End Get
        Set(ByVal value As String)
            _D22 = value
        End Set
    End Property

    Public Property D23() As String
        Get
            Return _D23
        End Get
        Set(ByVal value As String)
            _D23 = value
        End Set
    End Property

    Public Property D24() As String
        Get
            Return _D24
        End Get
        Set(ByVal value As String)
            _D24 = value
        End Set
    End Property

    Public Property D25() As String
        Get
            Return _D25
        End Get
        Set(ByVal value As String)
            _D25 = value
        End Set
    End Property

    Public Property D26() As String
        Get
            Return _D26
        End Get
        Set(ByVal value As String)
            _D26 = value
        End Set
    End Property

    Public Property D27() As String
        Get
            Return _D27
        End Get
        Set(ByVal value As String)
            _D27 = value
        End Set
    End Property

    Public Property D28() As String
        Get
            Return _D28
        End Get
        Set(ByVal value As String)
            _D28 = value
        End Set
    End Property

    Public Property D29() As String
        Get
            Return _D29
        End Get
        Set(ByVal value As String)
            _D29 = value
        End Set
    End Property

    Public Property D30() As String
        Get
            Return _D30
        End Get
        Set(ByVal value As String)
            _D30 = value
        End Set
    End Property

    Public Property D31() As String
        Get
            Return _D31
        End Get
        Set(ByVal value As String)
            _D31 = value
        End Set
    End Property

    Public Property PayCat() As String
        Get
            Return _PayCat
        End Get
        Set(ByVal value As String)
            _PayCat = value
        End Set
    End Property

    Public Property AttEnd() As Date
        Get
            Return _AttEnd
        End Get
        Set(ByVal value As Date)
            _AttEnd = value
        End Set
    End Property

    Public Property DolTot() As Decimal
        Get
            Return _DolTot
        End Get
        Set(ByVal value As Decimal)
            _DolTot = value
        End Set
    End Property

    Public Property UnitTot() As Decimal
        Get
            Return _UnitTot
        End Get
        Set(ByVal value As Decimal)
            _UnitTot = value
        End Set
    End Property

    Public Property ClientPct() As Double
        Get
            Return _ClientPct
        End Get
        Set(ByVal value As Double)
            _ClientPct = value
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


    Public ReadOnly Property AttendReportColumnNames() As String
        Get
            Return "([B_Num] , [Name_Key] , [Contract_Key] , [Screen_Nam] , [Sort_Name] , [Autho_Num] , [Bill_Type] , [Pv_Form] , [Rpt_Type] , [Unit_Rate] , [Offset] , [Slot_Num] , [Name_Chk] , [Ss_Num] , [Med_Num] , [Att_Beg] , [Att_Code] , [Att_Unit] , [Invoice_Date] , [Invoice] , [Cust_Num] , [Dr_Acct_Nu] , [Cr_Acct_Nu] , [Entry_Date] , [Dflag] , [Agency] , [D1] , [D2] , [D3] , [D4] , [D5] , [D6] , [D7] , [D8] , [D9] , [D10] , [D11] , [D12] , [D13] , [D14] , [D15] , [D16] , [D17] , [D18] , [D19] , [D20] , [D21] , [D22] , [D23] , [D24] , [D25] , [D26] , [D27] , [D28] , [D29] , [D30] , [D31] , [Pay_Cat] , [Att_End] , [Dol_Tot] , [Unit_Tot] , [Client_Pct] , [Void] )"
        End Get
    End Property

    Public ReadOnly Property AttendReportColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} , {43} , {44} , {45} , {46} , {47} , {48} , {49} , {50} , {51} , {52} , {53} , {54} , {55} , {56} , {57} , {58} , {59} , {60} , {61} , {62} )" _
, Database.StringParam(_BNum) _
 , Database.StringParam(_NameKey) _
 , Database.StringParam(_ContractKey) _
 , Database.StringParam(_ScreenNam) _
 , Database.StringParam(_SortName) _
 , Database.StringParam(_AuthoNum) _
 , Database.StringParam(_BillType) _
 , Database.StringParam(_PvForm) _
 , Database.StringParam(_RptType) _
, (_UnitRate.ToString) _
, (_Offset.ToString) _
, (_SlotNum.ToString) _
 , Database.StringParam(_NameChk) _
 , Database.StringParam(_SsNum) _
 , Database.StringParam(_MedNum) _
 , Database.StringParam(_AttBeg.ToShortDateString) _
 , Database.StringParam(_AttCode) _
, (_AttUnit.ToString) _
, Database.StringParam(_InvoiceDate.ToShortDateString) _
 , Database.StringParam(_Invoice) _
 , Database.StringParam(_CustNum) _
 , Database.StringParam(_DrAcctNu) _
 , Database.StringParam(_CrAcctNu) _
, Database.StringParam(_EntryDate.ToShortDateString) _
 , Database.StringParam(_Dflag) _
 , (_Agency.ToString) _
 , Database.StringParam(_D1) _
 , Database.StringParam(_D2) _
 , Database.StringParam(_D3) _
 , Database.StringParam(_D4) _
 , Database.StringParam(_D5) _
 , Database.StringParam(_D6) _
 , Database.StringParam(_D7) _
 , Database.StringParam(_D8) _
 , Database.StringParam(_D9) _
 , Database.StringParam(_D10) _
 , Database.StringParam(_D11) _
 , Database.StringParam(_D12) _
 , Database.StringParam(_D13) _
 , Database.StringParam(_D14) _
 , Database.StringParam(_D15) _
 , Database.StringParam(_D16) _
 , Database.StringParam(_D17) _
 , Database.StringParam(_D18) _
 , Database.StringParam(_D19) _
 , Database.StringParam(_D20) _
 , Database.StringParam(_D21) _
 , Database.StringParam(_D22) _
 , Database.StringParam(_D23) _
 , Database.StringParam(_D24) _
 , Database.StringParam(_D25) _
 , Database.StringParam(_D26) _
 , Database.StringParam(_D27) _
 , Database.StringParam(_D28) _
 , Database.StringParam(_D29) _
 , Database.StringParam(_D30) _
 , Database.StringParam(_D31) _
 , Database.StringParam(_PayCat) _
, Database.StringParam(_AttEnd.ToShortDateString) _
, (_DolTot.ToString) _
, (_UnitTot.ToString) _
, (_ClientPct.ToString) _
 , Database.StringParam(_Void) _
)
        End Get
    End Property
End Class
