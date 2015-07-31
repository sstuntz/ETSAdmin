Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common


Public Class FundingData
    Private _BNum As String
    Private _NameKey As String
    Private _ScreenNam As String
    Private _SortName As String
    Private _ContractKey As String
    Private _ContIdNum As String
    Private _MmarsNum As String
    Private _AmendNum As String
    Private _EntryDate As Date
    Private _Closed As String
    Private _BillDate As Date
    Private _ClientTotal As Decimal
    Private _Dflag As String
    Private _Agency As Integer
    Private _BillType As String
    Private _BegDate As Date
    Private _EndDate As Date
    Private _Active As String
    Private _SlotNum As Integer
    Private _NameChk As String
    Private _AttCode As String
    Private _AttUnit As Double
    Private _ProgNum As String
    Private _UnitRate As Decimal
    Private _Offset As Decimal
    Private _Mon As String
    Private _Tue As String
    Private _Wed As String
    Private _Thu As String
    Private _Fri As String
    Private _Sat As String
    Private _Sun As String
    Private _Type As String
    Private _DrAcctNu As String
    Private _CrAcctNu As String
    Private _RefProvNum As String
    Private _MedSource As String
    Private _BudAmt As Decimal
    Private _SpecAmt As Decimal

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

    Public Property Closed() As String
        Get
            Return _Closed
        End Get
        Set(ByVal value As String)
            _Closed = value
        End Set
    End Property

    Public Property BillDate() As Date
        Get
            Return _BillDate
        End Get
        Set(ByVal value As Date)
            _BillDate = value
        End Set
    End Property

    Public Property ClientTotal() As Decimal
        Get
            Return _ClientTotal
        End Get
        Set(ByVal value As Decimal)
            _ClientTotal = value
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

    Public Property BillType() As String
        Get
            Return _BillType
        End Get
        Set(ByVal value As String)
            _BillType = value
        End Set
    End Property

    Public Property BegDate() As Date
        Get
            Return _BegDate
        End Get
        Set(ByVal value As Date)
            _BegDate = value
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

    Public Property Active() As String
        Get
            Return _Active
        End Get
        Set(ByVal value As String)
            _Active = value
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

    Public Property ProgNum() As String
        Get
            Return _ProgNum
        End Get
        Set(ByVal value As String)
            _ProgNum = value
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

    Public Property Mon() As String
        Get
            Return _Mon
        End Get
        Set(ByVal value As String)
            _Mon = value
        End Set
    End Property

    Public Property Tue() As String
        Get
            Return _Tue
        End Get
        Set(ByVal value As String)
            _Tue = value
        End Set
    End Property

    Public Property Wed() As String
        Get
            Return _Wed
        End Get
        Set(ByVal value As String)
            _Wed = value
        End Set
    End Property

    Public Property Thu() As String
        Get
            Return _Thu
        End Get
        Set(ByVal value As String)
            _Thu = value
        End Set
    End Property

    Public Property Fri() As String
        Get
            Return _Fri
        End Get
        Set(ByVal value As String)
            _Fri = value
        End Set
    End Property

    Public Property Sat() As String
        Get
            Return _Sat
        End Get
        Set(ByVal value As String)
            _Sat = value
        End Set
    End Property

    Public Property Sun() As String
        Get
            Return _Sun
        End Get
        Set(ByVal value As String)
            _Sun = value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
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

    Public Property RefProvNum() As String
        Get
            Return _RefProvNum
        End Get
        Set(ByVal value As String)
            _RefProvNum = value
        End Set
    End Property

    Public Property MedSource() As String
        Get
            Return _MedSource
        End Get
        Set(ByVal value As String)
            _MedSource = value
        End Set
    End Property

    Public Property BudAmt() As Decimal
        Get
            Return _BudAmt
        End Get
        Set(ByVal value As Decimal)
            _BudAmt = value
        End Set
    End Property

    Public Property SpecAmt() As Decimal
        Get
            Return _SpecAmt
        End Get
        Set(ByVal value As Decimal)
            _SpecAmt = value
        End Set
    End Property


    Public ReadOnly Property FundingColumnNames() As String
        Get
            Return "([B_Num] , [Name_Key] , [Screen_Nam] , [Sort_Name] , [Contract_Key] , [Cont_Id_Num] , [Mmars_Num] , [Amend_Num] , [Entry_Date] , [Closed] , [Bill_Date] , [Client_Total] , [Dflag] , [Agency] , [Bill_Type] , [Beg_Date] , [End_Date] , [Active] , [Slot_Num] , [Name_Chk] , [Att_Code] , [Att_Unit] , [Prog_Num] , [Unit_Rate] , [Offset] , [Mon] , [Tue] , [Wed] , [Thu] , [Fri] , [Sat] , [Sun] , [Type] , [Dr_Acct_Nu] , [Cr_Acct_Nu] , [Ref_Prov_Num] , [Med_Source] , [Bud_Amt] , [Spec_Amt] )"
        End Get
    End Property

    Public ReadOnly Property FundingColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} )" _
, Database.StringParam(_BNum.ToString) _
, Database.StringParam(_NameKey.ToString) _
, Database.StringParam(_ScreenNam.ToString) _
, Database.StringParam(_SortName.ToString) _
, Database.StringParam(_ContractKey.ToString) _
, Database.StringParam(_ContIdNum.ToString) _
, Database.StringParam(_MmarsNum.ToString) _
, Database.StringParam(_AmendNum.ToString) _
, Database.StringParam(_EntryDate.ToShortDateString) _
, Database.StringParam(_Closed.ToString) _
, Database.StringParam(_BillDate.ToShortDateString) _
, (_ClientTotal.ToString) _
, Database.StringParam(_Dflag.ToString) _
, (_Agency.ToString) _
, Database.StringParam(_BillType.ToString) _
, Database.StringParam(_BegDate.ToShortDateString) _
, Database.StringParam(_EndDate.ToShortDateString) _
, Database.StringParam(_Active.ToString) _
, (_SlotNum.ToString) _
, Database.StringParam(_NameChk.ToString) _
, Database.StringParam(_AttCode.ToString) _
, (_AttUnit.ToString) _
, Database.StringParam(_ProgNum.ToString) _
, (_UnitRate.ToString) _
, (_Offset.ToString) _
, Database.StringParam(_Mon.ToString) _
, Database.StringParam(_Tue.ToString) _
, Database.StringParam(_Wed.ToString) _
, Database.StringParam(_Thu.ToString) _
, Database.StringParam(_Fri.ToString) _
, Database.StringParam(_Sat.ToString) _
, Database.StringParam(_Sun.ToString) _
, Database.StringParam(_Type.ToString) _
, Database.StringParam(_DrAcctNu.ToString) _
, Database.StringParam(_CrAcctNu.ToString) _
, Database.StringParam(_RefProvNum.ToString) _
, Database.StringParam(_MedSource.ToString) _
, (_BudAmt.ToString) _
, (_SpecAmt.ToString) _
)
        End Get
    End Property
End Class
