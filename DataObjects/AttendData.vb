Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports PS.Common


Public Class AttendData
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
    Private _AttDate As Date
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
    Private _Void As String
    Private _ClientPct As Double

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

    Public Property AttDate() As Date
        Get
            Return _AttDate
        End Get
        Set(ByVal value As Date)
            _AttDate = value
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

    Public Property Void() As String
        Get
            Return _Void
        End Get
        Set(ByVal value As String)
            _Void = value
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


    Public ReadOnly Property AttendColumnNames() As String
        Get
            Return "([B_Num] , [Name_Key] , [Contract_Key] , [Screen_Nam] , [Sort_Name] , [Autho_Num] , [Bill_Type] , [Pv_Form] , [Rpt_Type] , [Unit_Rate] , [Offset] , [Slot_Num] , [Name_Chk] , [Ss_Num] , [Med_Num] , [Att_Date] , [Att_Code] , [Att_Unit] , [Invoice_Date] , [Invoice] , [Cust_Num] , [Dr_Acct_Nu] , [Cr_Acct_Nu] , [Entry_Date] , [Dflag] , [Agency] , [Void] , [Client_Pct] )"
        End Get
    End Property

    Public ReadOnly Property AttendColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} )" _
, Database.StringParam(_BNum.ToString) _
, Database.StringParam(_NameKey.ToString) _
, Database.StringParam(_ContractKey.ToString) _
, Database.StringParam(_ScreenNam.ToString) _
, Database.StringParam(_SortName.ToString) _
, Database.StringParam(_AuthoNum.ToString) _
, Database.StringParam(_BillType.ToString) _
, Database.StringParam(_PvForm.ToString) _
, Database.StringParam(_RptType.ToString) _
, (_UnitRate.ToString) _
, (_Offset.ToString) _
, (_SlotNum.ToString) _
, Database.StringParam(_NameChk.ToString) _
, Database.StringParam(_SsNum.ToString) _
, Database.StringParam(_MedNum.ToString) _
, Database.StringParam(_AttDate.ToShortDateString) _
, Database.StringParam(_AttCode.ToString) _
, (_AttUnit.ToString) _
, Database.StringParam(_InvoiceDate.ToShortDateString) _
, Database.StringParam(_Invoice.ToString) _
, Database.StringParam(_CustNum.ToString) _
, Database.StringParam(_DrAcctNu.ToString) _
, Database.StringParam(_CrAcctNu.ToString) _
, Database.StringParam(_EntryDate.ToShortDateString) _
, Database.StringParam(_Dflag.ToString) _
, (_Agency.ToString) _
, Database.StringParam(_Void.ToString) _
, (_ClientPct.ToString) _
)
        End Get
    End Property
End Class
