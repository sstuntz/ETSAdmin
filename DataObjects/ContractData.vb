Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common


Public Class ContractData
    Private _ContractKey As String
    Private _ContIdNum As String
    Private _MmarsNum As String
    Private _AmendNum As String
    Private _EntryDate As Date
    Private _ContDesc As String
    Private _FiscalYr As String
    Private _Active As String
    Private _BillType As String
    Private _PvForm As String
    Private _RptType As String
    Private _UnitRate As Decimal
    Private _ContBegD As Date
    Private _ContEndD As Date
    Private _AmndBegD As Date
    Private _AmndEndD As Date
    Private _LastInvnum As String
    Private _LastBilldate As Date
    Private _ContOffset As Decimal
    Private _BillOffset As Decimal
    Private _DrAcctNu As String
    Private _CrAcctNu As String
    Private _NameKey As String
    Private _ScreenNam As String
    Private _ContUnits As Double
    Private _ContDol As Decimal
    Private _AmendUnits As Double
    Private _AmendDol As Decimal
    Private _MaxUnits As Double
    Private _MaxDol As Decimal
    Private _YtdUnits As Double
    Private _YtdDol As Decimal
    Private _SeedUnits As Double
    Private _SeedDol As Decimal
    Private _MonthUnits As Double
    Private _MonthDol As Decimal
    Private _RemUnits As Double
    Private _RemDol As Decimal
    Private _RedpyDol As Decimal
    Private _FlatRate As Decimal
    Private _Code1 As String
    Private _Code2 As String
    Private _Code3 As String
    Private _BeginDate As Date
    Private _EndDate As Date
    Private _NamkeyDss As String
    Private _PnumDss As String
    Private _NamkeySdr As String
    Private _PnumSdr As String
    Private _PrgnamSdr As String
    Private _PrgcodeSdr As String
    Private _PrgduraSdr As String
    Private _PrepBy As String
    Private _StateAgcy As String
    Private _ReimbType As String
    Private _Desc1 As String
    Private _Desc2 As String
    Private _Desc3 As String
    Private _NamkeyLea As String
    Private _PnumLea As String
    Private _PrgnamLea As String
    Private _PrgcodeLea As String
    Private _PrgduraLea As String
    Private _FedidNum As String
    Private _AnndaysSch As String
    Private _AnndaysRes As String
    Private _ProgType As String
    Private _LeaTerms As String
    Private _LeaComment As String
    Private _LeaOrderNu As String
    Private _Dflag As String
    Private _Agency As Integer
    Private _InvType As String
    Private _ProvNumMed As String
    Private _ProsNumMed As String
    Private _PlaceService As String
    Private _BillableCodes As String
    Private _InvString As String
    Private _ProgNum As String
    Private _DefInc As String
    Private _LifeAmend As String

    Public Property ContractKey() As String
        Get
            Return _ContractKey
        End Get
        Set(ByVal value As String)
            _ContractKey = value
        End Set
    End Property

    Public Property ContIdNum() As String
        Get
            Return _ContIdNum
        End Get
        Set(ByVal value As String)
            _ContIdNum = value
        End Set
    End Property

    Public Property MmarsNum() As String
        Get
            Return _MmarsNum
        End Get
        Set(ByVal value As String)
            _MmarsNum = value
        End Set
    End Property

    Public Property AmendNum() As String
        Get
            Return _AmendNum
        End Get
        Set(ByVal value As String)
            _AmendNum = value
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

    Public Property ContDesc() As String
        Get
            Return _ContDesc
        End Get
        Set(ByVal value As String)
            _ContDesc = value
        End Set
    End Property

    Public Property FiscalYr() As String
        Get
            Return _FiscalYr
        End Get
        Set(ByVal value As String)
            _FiscalYr = value
        End Set
    End Property

    Public Property Active() As String
        Get
            Return _Active
        End Get
        Set(ByVal value As String)
            _Active = value
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

    Public Property ContBegD() As Date
        Get
            Return _ContBegD
        End Get
        Set(ByVal value As Date)
            _ContBegD = value
        End Set
    End Property

    Public Property ContEndD() As Date
        Get
            Return _ContEndD
        End Get
        Set(ByVal value As Date)
            _ContEndD = value
        End Set
    End Property

    Public Property AmndBegD() As Date
        Get
            Return _AmndBegD
        End Get
        Set(ByVal value As Date)
            _AmndBegD = value
        End Set
    End Property

    Public Property AmndEndD() As Date
        Get
            Return _AmndEndD
        End Get
        Set(ByVal value As Date)
            _AmndEndD = value
        End Set
    End Property

    Public Property LastInvnum() As String
        Get
            Return _LastInvnum
        End Get
        Set(ByVal value As String)
            _LastInvnum = value
        End Set
    End Property

    Public Property LastBilldate() As Date
        Get
            Return _LastBilldate
        End Get
        Set(ByVal value As Date)
            _LastBilldate = value
        End Set
    End Property

    Public Property ContOffset() As Decimal
        Get
            Return _ContOffset
        End Get
        Set(ByVal value As Decimal)
            _ContOffset = value
        End Set
    End Property

    Public Property BillOffset() As Decimal
        Get
            Return _BillOffset
        End Get
        Set(ByVal value As Decimal)
            _BillOffset = value
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

    Public Property NameKey() As String
        Get
            Return _NameKey
        End Get
        Set(ByVal value As String)
            _NameKey = value
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

    Public Property ContUnits() As Double
        Get
            Return _ContUnits
        End Get
        Set(ByVal value As Double)
            _ContUnits = value
        End Set
    End Property

    Public Property ContDol() As Decimal
        Get
            Return _ContDol
        End Get
        Set(ByVal value As Decimal)
            _ContDol = value
        End Set
    End Property

    Public Property AmendUnits() As Double
        Get
            Return _AmendUnits
        End Get
        Set(ByVal value As Double)
            _AmendUnits = value
        End Set
    End Property

    Public Property AmendDol() As Decimal
        Get
            Return _AmendDol
        End Get
        Set(ByVal value As Decimal)
            _AmendDol = value
        End Set
    End Property

    Public Property MaxUnits() As Double
        Get
            Return _MaxUnits
        End Get
        Set(ByVal value As Double)
            _MaxUnits = value
        End Set
    End Property

    Public Property MaxDol() As Decimal
        Get
            Return _MaxDol
        End Get
        Set(ByVal value As Decimal)
            _MaxDol = value
        End Set
    End Property

    Public Property YtdUnits() As Double
        Get
            Return _YtdUnits
        End Get
        Set(ByVal value As Double)
            _YtdUnits = value
        End Set
    End Property

    Public Property YtdDol() As Decimal
        Get
            Return _YtdDol
        End Get
        Set(ByVal value As Decimal)
            _YtdDol = value
        End Set
    End Property

    Public Property SeedUnits() As Double
        Get
            Return _SeedUnits
        End Get
        Set(ByVal value As Double)
            _SeedUnits = value
        End Set
    End Property

    Public Property SeedDol() As Decimal
        Get
            Return _SeedDol
        End Get
        Set(ByVal value As Decimal)
            _SeedDol = value
        End Set
    End Property

    Public Property MonthUnits() As Double
        Get
            Return _MonthUnits
        End Get
        Set(ByVal value As Double)
            _MonthUnits = value
        End Set
    End Property

    Public Property MonthDol() As Decimal
        Get
            Return _MonthDol
        End Get
        Set(ByVal value As Decimal)
            _MonthDol = value
        End Set
    End Property

    Public Property RemUnits() As Double
        Get
            Return _RemUnits
        End Get
        Set(ByVal value As Double)
            _RemUnits = value
        End Set
    End Property

    Public Property RemDol() As Decimal
        Get
            Return _RemDol
        End Get
        Set(ByVal value As Decimal)
            _RemDol = value
        End Set
    End Property

    Public Property RedpyDol() As Decimal
        Get
            Return _RedpyDol
        End Get
        Set(ByVal value As Decimal)
            _RedpyDol = value
        End Set
    End Property

    Public Property FlatRate() As Decimal
        Get
            Return _FlatRate
        End Get
        Set(ByVal value As Decimal)
            _FlatRate = value
        End Set
    End Property

    Public Property Code1() As String
        Get
            Return _Code1
        End Get
        Set(ByVal value As String)
            _Code1 = value
        End Set
    End Property

    Public Property Code2() As String
        Get
            Return _Code2
        End Get
        Set(ByVal value As String)
            _Code2 = value
        End Set
    End Property

    Public Property Code3() As String
        Get
            Return _Code3
        End Get
        Set(ByVal value As String)
            _Code3 = value
        End Set
    End Property

    Public Property BeginDate() As Date
        Get
            Return _BeginDate
        End Get
        Set(ByVal value As Date)
            _BeginDate = value
        End Set
    End Property

    Public Property EndDate() As Date
        Get
            Return _EndDate
        End Get
        Set(ByVal value As Date)
            _EndDate = value
        End Set
    End Property

    Public Property NamkeyDss() As String
        Get
            Return _NamkeyDss
        End Get
        Set(ByVal value As String)
            _NamkeyDss = value
        End Set
    End Property

    Public Property PnumDss() As String
        Get
            Return _PnumDss
        End Get
        Set(ByVal value As String)
            _PnumDss = value
        End Set
    End Property

    Public Property NamkeySdr() As String
        Get
            Return _NamkeySdr
        End Get
        Set(ByVal value As String)
            _NamkeySdr = value
        End Set
    End Property

    Public Property PnumSdr() As String
        Get
            Return _PnumSdr
        End Get
        Set(ByVal value As String)
            _PnumSdr = value
        End Set
    End Property

    Public Property PrgnamSdr() As String
        Get
            Return _PrgnamSdr
        End Get
        Set(ByVal value As String)
            _PrgnamSdr = value
        End Set
    End Property

    Public Property PrgcodeSdr() As String
        Get
            Return _PrgcodeSdr
        End Get
        Set(ByVal value As String)
            _PrgcodeSdr = value
        End Set
    End Property

    Public Property PrgduraSdr() As String
        Get
            Return _PrgduraSdr
        End Get
        Set(ByVal value As String)
            _PrgduraSdr = value
        End Set
    End Property

    Public Property PrepBy() As String
        Get
            Return _PrepBy
        End Get
        Set(ByVal value As String)
            _PrepBy = value
        End Set
    End Property

    Public Property StateAgcy() As String
        Get
            Return _StateAgcy
        End Get
        Set(ByVal value As String)
            _StateAgcy = value
        End Set
    End Property

    Public Property ReimbType() As String
        Get
            Return _ReimbType
        End Get
        Set(ByVal value As String)
            _ReimbType = value
        End Set
    End Property

    Public Property Desc1() As String
        Get
            Return _Desc1
        End Get
        Set(ByVal value As String)
            _Desc1 = value
        End Set
    End Property

    Public Property Desc2() As String
        Get
            Return _Desc2
        End Get
        Set(ByVal value As String)
            _Desc2 = value
        End Set
    End Property

    Public Property Desc3() As String
        Get
            Return _Desc3
        End Get
        Set(ByVal value As String)
            _Desc3 = value
        End Set
    End Property

    Public Property NamkeyLea() As String
        Get
            Return _NamkeyLea
        End Get
        Set(ByVal value As String)
            _NamkeyLea = value
        End Set
    End Property

    Public Property PnumLea() As String
        Get
            Return _PnumLea
        End Get
        Set(ByVal value As String)
            _PnumLea = value
        End Set
    End Property

    Public Property PrgnamLea() As String
        Get
            Return _PrgnamLea
        End Get
        Set(ByVal value As String)
            _PrgnamLea = value
        End Set
    End Property

    Public Property PrgcodeLea() As String
        Get
            Return _PrgcodeLea
        End Get
        Set(ByVal value As String)
            _PrgcodeLea = value
        End Set
    End Property

    Public Property PrgduraLea() As String
        Get
            Return _PrgduraLea
        End Get
        Set(ByVal value As String)
            _PrgduraLea = value
        End Set
    End Property

    Public Property FedidNum() As String
        Get
            Return _FedidNum
        End Get
        Set(ByVal value As String)
            _FedidNum = value
        End Set
    End Property

    Public Property AnndaysSch() As String
        Get
            Return _AnndaysSch
        End Get
        Set(ByVal value As String)
            _AnndaysSch = value
        End Set
    End Property

    Public Property AnndaysRes() As String
        Get
            Return _AnndaysRes
        End Get
        Set(ByVal value As String)
            _AnndaysRes = value
        End Set
    End Property

    Public Property ProgType() As String
        Get
            Return _ProgType
        End Get
        Set(ByVal value As String)
            _ProgType = value
        End Set
    End Property

    Public Property LeaTerms() As String
        Get
            Return _LeaTerms
        End Get
        Set(ByVal value As String)
            _LeaTerms = value
        End Set
    End Property

    Public Property LeaComment() As String
        Get
            Return _LeaComment
        End Get
        Set(ByVal value As String)
            _LeaComment = value
        End Set
    End Property

    Public Property LeaOrderNu() As String
        Get
            Return _LeaOrderNu
        End Get
        Set(ByVal value As String)
            _LeaOrderNu = value
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

    Public Property InvType() As String
        Get
            Return _InvType
        End Get
        Set(ByVal value As String)
            _InvType = value
        End Set
    End Property

    Public Property ProvNumMed() As String
        Get
            Return _ProvNumMed
        End Get
        Set(ByVal value As String)
            _ProvNumMed = value
        End Set
    End Property

    Public Property ProsNumMed() As String
        Get
            Return _ProsNumMed
        End Get
        Set(ByVal value As String)
            _ProsNumMed = value
        End Set
    End Property

    Public Property PlaceService() As String
        Get
            Return _PlaceService
        End Get
        Set(ByVal value As String)
            _PlaceService = value
        End Set
    End Property

    Public Property BillableCodes() As String
        Get
            Return _BillableCodes
        End Get
        Set(ByVal value As String)
            _BillableCodes = value
        End Set
    End Property

    Public Property InvString() As String
        Get
            Return _InvString
        End Get
        Set(ByVal value As String)
            _InvString = value
        End Set
    End Property

    Public Property ProgNum() As String
        Get
            Return _ProgNum
        End Get
        Set(ByVal value As String)
            _ProgNum = value
        End Set
    End Property

    Public Property DefInc() As String
        Get
            Return _DefInc
        End Get
        Set(ByVal value As String)
            _DefInc = value
        End Set
    End Property

    Public Property LifeAmend() As String
        Get
            Return _LifeAmend
        End Get
        Set(ByVal value As String)
            _LifeAmend = value
        End Set
    End Property


    Public ReadOnly Property ContractColumnNames() As String
        Get
            Return "([Contract_Key] , [Cont_Id_Num] , [Mmars_Num] , [Amend_Num] , [Entry_Date] , [Cont_Desc] , [Fiscal_Yr] , [Active] , [Bill_Type] , [Pv_Form] , [Rpt_Type] , [Unit_Rate] , [Cont_Beg_D] , [Cont_End_D] , [Amnd_Beg_D] , [Amnd_End_D] , [Last_Invnum] , [Last_Billdate] , [Cont_Offset] , [Bill_Offset] , [Dr_Acct_Nu] , [Cr_Acct_Nu] , [Name_Key] , [Screen_Nam] , [Cont_Units] , [Cont_Dol] , [Amend_Units] , [Amend_Dol] , [Max_Units] , [Max_Dol] , [Ytd_Units] , [Ytd_Dol] , [Seed_Units] , [Seed_Dol] , [Month_Units] , [Month_Dol] , [Rem_Units] , [Rem_Dol] , [Redpy_Dol] , [Flat_Rate] , [Code1] , [Code2] , [Code3] , [Begin_Date] , [End_Date] , [Namkey_Dss] , [Pnum_Dss] , [Namkey_Sdr] , [Pnum_Sdr] , [Prgnam_Sdr] , [Prgcode_Sdr] , [Prgdura_Sdr] , [Prep_By] , [State_Agcy] , [Reimb_Type] , [Desc1] , [Desc2] , [Desc3] , [Namkey_Lea] , [Pnum_Lea] , [Prgnam_Lea] , [Prgcode_Lea] , [Prgdura_Lea] , [Fedid_Num] , [Anndays_Sch] , [Anndays_Res] , [Prog_Type] , [Lea_Terms] , [Lea_Comment] , [Lea_Order_Nu] , [Dflag] , [Agency] , [Inv_Type] , [Prov_Num_Med] , [Pros_Num_Med] , [Place_Service] , [Billable_Codes] , [Inv_String] , [Prog_Num] , [Def_Inc] , [Life_Amend] )"
        End Get
    End Property

    Public ReadOnly Property ContractColumnNamesNoDates() As String
        Get
            Return "([Contract_Key] , [Cont_Id_Num] , [Mmars_Num] , [Amend_Num] , [Entry_Date] , [Cont_Desc] , [Fiscal_Yr] , [Active] , [Bill_Type] , [Pv_Form] , [Rpt_Type] , [Unit_Rate] , [Last_Invnum] , [Cont_Offset] , [Bill_Offset] , [Dr_Acct_Nu] , [Cr_Acct_Nu] , [Name_Key] , [Screen_Nam] , [Cont_Units] , [Cont_Dol] , [Amend_Units] , [Amend_Dol] , [Max_Units] , [Max_Dol] , [Ytd_Units] , [Ytd_Dol] , [Seed_Units] , [Seed_Dol] , [Month_Units] , [Month_Dol] , [Rem_Units] , [Rem_Dol] , [Redpy_Dol] , [Flat_Rate] , [Code1] , [Code2] , [Code3] , [Namkey_Dss] , [Pnum_Dss] , [Namkey_Sdr] , [Pnum_Sdr] , [Prgnam_Sdr] , [Prgcode_Sdr] , [Prgdura_Sdr] , [Prep_By] , [State_Agcy] , [Reimb_Type] , [Desc1] , [Desc2] , [Desc3] , [Namkey_Lea] , [Pnum_Lea] , [Prgnam_Lea] , [Prgcode_Lea] , [Prgdura_Lea] , [Fedid_Num] , [Anndays_Sch] , [Anndays_Res] , [Prog_Type] , [Lea_Terms] , [Lea_Comment] , [Lea_Order_Nu] , [Dflag] , [Agency] , [Inv_Type] , [Prov_Num_Med] , [Pros_Num_Med] , [Place_Service] , [Billable_Codes] , [Inv_String] , [Prog_Num] , [Def_Inc] , [Life_Amend] )"
        End Get
    End Property

    Public ReadOnly Property ContractColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} , {43} , {44} , {45} , {46} , {47} , {48} , {49} , {50} , {51} , {52} , {53} , {54} , {55} , {56} , {57} , {58} , {59} , {60} , {61} , {62} , {63} , {64} , {65} , {66} , {67} , {68} , {69} , {70} , {71} , {72} , {73} , {74} , {75} , {76} , {77} , {78} , {79} , {80} )" _
, Database.StringParam(_ContractKey.ToString) _
, Database.StringParam(_ContIdNum.ToString) _
, Database.StringParam(_MmarsNum.ToString) _
, Database.StringParam(_AmendNum.ToString) _
, Database.StringParam(_EntryDate.ToShortDateString) _
, Database.StringParam(_ContDesc.ToString) _
, Database.StringParam(_FiscalYr.ToString) _
, Database.StringParam(_Active.ToString) _
, Database.StringParam(_BillType.ToString) _
, Database.StringParam(_PvForm.ToString) _
, Database.StringParam(_RptType.ToString) _
, (_UnitRate.ToString) _
, Database.StringParam(_ContBegD.ToShortDateString) _
, Database.StringParam(_ContEndD.ToShortDateString) _
, Database.StringParam(_AmndBegD.ToShortDateString) _
, Database.StringParam(_AmndEndD.ToShortDateString) _
, Database.StringParam(_LastInvnum.ToString) _
, Database.StringParam(_LastBilldate.ToShortDateString) _
, (_ContOffset.ToString) _
, (_BillOffset.ToString) _
, Database.StringParam(_DrAcctNu.ToString) _
, Database.StringParam(_CrAcctNu.ToString) _
, Database.StringParam(_NameKey.ToString) _
, Database.StringParam(_ScreenNam.ToString) _
, (_ContUnits.ToString) _
, (_ContDol.ToString) _
, (_AmendUnits.ToString) _
, (_AmendDol.ToString) _
, (_MaxUnits.ToString) _
, (_MaxDol.ToString) _
, (_YtdUnits.ToString) _
, (_YtdDol.ToString) _
, (_SeedUnits.ToString) _
, (_SeedDol.ToString) _
, (_MonthUnits.ToString) _
, (_MonthDol.ToString) _
, (_RemUnits.ToString) _
, (_RemDol.ToString) _
, (_RedpyDol.ToString) _
, (_FlatRate.ToString) _
, Database.StringParam(_Code1.ToString) _
, Database.StringParam(_Code2.ToString) _
, Database.StringParam(_Code3.ToString) _
, Database.StringParam(_BeginDate.ToString) _
, Database.StringParam(_EndDate.ToShortDateString) _
, Database.StringParam(_NamkeyDss.ToString) _
, Database.StringParam(_PnumDss.ToString) _
, Database.StringParam(_NamkeySdr.ToString) _
, Database.StringParam(_PnumSdr.ToString) _
, Database.StringParam(_PrgnamSdr.ToString) _
, Database.StringParam(_PrgcodeSdr.ToString) _
, Database.StringParam(_PrgduraSdr.ToString) _
, Database.StringParam(_PrepBy.ToString) _
, Database.StringParam(_StateAgcy.ToString) _
, Database.StringParam(_ReimbType.ToString) _
, Database.StringParam(_Desc1.ToString) _
, Database.StringParam(_Desc2.ToString) _
, Database.StringParam(_Desc3.ToString) _
, Database.StringParam(_NamkeyLea.ToString) _
, Database.StringParam(_PnumLea.ToString) _
, Database.StringParam(_PrgnamLea.ToString) _
, Database.StringParam(_PrgcodeLea.ToString) _
, Database.StringParam(_PrgduraLea.ToString) _
, Database.StringParam(_FedidNum.ToString) _
, Database.StringParam(_AnndaysSch.ToString) _
, Database.StringParam(_AnndaysRes.ToString) _
, Database.StringParam(_ProgType.ToString) _
, Database.StringParam(_LeaTerms.ToString) _
, Database.StringParam(_LeaComment.ToString) _
, Database.StringParam(_LeaOrderNu.ToString) _
, Database.StringParam(_Dflag.ToString) _
, (_Agency.ToString) _
, Database.StringParam(_InvType.ToString) _
, Database.StringParam(_ProvNumMed.ToString) _
, Database.StringParam(_ProsNumMed.ToString) _
, Database.StringParam(_PlaceService.ToString) _
, Database.StringParam(_BillableCodes.ToString) _
, Database.StringParam(_InvString.ToString) _
, Database.StringParam(_ProgNum.ToString) _
, Database.StringParam(_DefInc.ToString) _
, Database.StringParam(_LifeAmend.ToString) _
)
        End Get
    End Property

    Public ReadOnly Property ContractColumnDataNoDates() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} , {43} , {44} , {45} , {46} , {47} , {48} , {49} , {50} , {51} , {52} , {53} , {54} , {55} , {56} , {57} , {58} , {59} , {60} , {61} , {62} , {63} , {64} , {65} , {66} , {67} , {68} , {69} , {70} , {71} , {72} , {73}  )" _
, Database.StringParam(_ContractKey.ToString) _
, Database.StringParam(_ContIdNum.ToString) _
, Database.StringParam(_MmarsNum.ToString) _
, Database.StringParam(_AmendNum.ToString) _
, Database.StringParam(_EntryDate.ToShortDateString) _
, Database.StringParam(_ContDesc.ToString) _
, Database.StringParam(_FiscalYr.ToString) _
, Database.StringParam(_Active.ToString) _
, Database.StringParam(_BillType.ToString) _
, Database.StringParam(_PvForm.ToString) _
, Database.StringParam(_RptType.ToString) _
, (_UnitRate.ToString) _
, Database.StringParam(_LastInvnum.ToString) _
, (_ContOffset.ToString) _
, (_BillOffset.ToString) _
, Database.StringParam(_DrAcctNu.ToString) _
, Database.StringParam(_CrAcctNu.ToString) _
, Database.StringParam(_NameKey.ToString) _
, Database.StringParam(_ScreenNam.ToString) _
, (_ContUnits.ToString) _
, (_ContDol.ToString) _
, (_AmendUnits.ToString) _
, (_AmendDol.ToString) _
, (_MaxUnits.ToString) _
, (_MaxDol.ToString) _
, (_YtdUnits.ToString) _
, (_YtdDol.ToString) _
, (_SeedUnits.ToString) _
, (_SeedDol.ToString) _
, (_MonthUnits.ToString) _
, (_MonthDol.ToString) _
, (_RemUnits.ToString) _
, (_RemDol.ToString) _
, (_RedpyDol.ToString) _
, (_FlatRate.ToString) _
, Database.StringParam(_Code1.ToString) _
, Database.StringParam(_Code2.ToString) _
, Database.StringParam(_Code3.ToString) _
, Database.StringParam(_NamkeyDss.ToString) _
, Database.StringParam(_PnumDss.ToString) _
, Database.StringParam(_NamkeySdr.ToString) _
, Database.StringParam(_PnumSdr.ToString) _
, Database.StringParam(_PrgnamSdr.ToString) _
, Database.StringParam(_PrgcodeSdr.ToString) _
, Database.StringParam(_PrgduraSdr.ToString) _
, Database.StringParam(_PrepBy.ToString) _
, Database.StringParam(_StateAgcy.ToString) _
, Database.StringParam(_ReimbType.ToString) _
, Database.StringParam(_Desc1.ToString) _
, Database.StringParam(_Desc2.ToString) _
, Database.StringParam(_Desc3.ToString) _
, Database.StringParam(_NamkeyLea.ToString) _
, Database.StringParam(_PnumLea.ToString) _
, Database.StringParam(_PrgnamLea.ToString) _
, Database.StringParam(_PrgcodeLea.ToString) _
, Database.StringParam(_PrgduraLea.ToString) _
, Database.StringParam(_FedidNum.ToString) _
, Database.StringParam(_AnndaysSch.ToString) _
, Database.StringParam(_AnndaysRes.ToString) _
, Database.StringParam(_ProgType.ToString) _
, Database.StringParam(_LeaTerms.ToString) _
, Database.StringParam(_LeaComment.ToString) _
, Database.StringParam(_LeaOrderNu.ToString) _
, Database.StringParam(_Dflag.ToString) _
, (_Agency.ToString) _
, Database.StringParam(_InvType.ToString) _
, Database.StringParam(_ProvNumMed.ToString) _
, Database.StringParam(_ProsNumMed.ToString) _
, Database.StringParam(_PlaceService.ToString) _
, Database.StringParam(_BillableCodes.ToString) _
, Database.StringParam(_InvString.ToString) _
, Database.StringParam(_ProgNum.ToString) _
, Database.StringParam(_DefInc.ToString) _
, Database.StringParam(_LifeAmend.ToString) _
)
        End Get
    End Property
End Class
