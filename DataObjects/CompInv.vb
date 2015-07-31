Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common


Public Class CompanyInvoiceData
    Private _InvNum As Integer
    Private _LineNum As Integer
    Private _Invoice As String
    Private _TransCode As String
    Private _PoNum As String
    Private _NameKey As String
    Private _ScreenNam As String
    Private _CcNum As String
    Private _CcName As String
    Private _InvDesc As String
    Private _DrAcctNu As String
    Private _CrAcctNu As String
    Private _AllocAmt As Decimal
    Private _EntryDate As Date
    Private _InvoiceDate As Date
    Private _EncumDate As Date
    Private _DtTbePd As Date
    Private _PaidDate As Date
    Private _ChkNum As String
    Private _BankKey As String
    Private _BankName As String
    Private _PayAmt As Decimal
    Private _BalDue As Decimal
    Private _InvAmt As Decimal
    Private _Paid As String
    Private _Glpost As String
    Private _Dflag As String
    Private _Agency As Integer
    Private _Checked As String
    Private _Void As String
    Private _SortName As String
    Private _JrnlNum As Integer
    Private _JrnlLine As Integer
    Private _InvType As String
    Private _ContractKey As String
    Private _FromDate As Date
    Private _ToDate As Date
    Private _UnitRate As Decimal
    Private _Units As Decimal
    Private _PmtNum As Integer

    Public Property InvNum() As Integer
        Get
            Return _InvNum
        End Get
        Set(ByVal value As Integer)
            _InvNum = value
        End Set
    End Property

    Public Property LineNum() As Integer
        Get
            Return _LineNum
        End Get
        Set(ByVal value As Integer)
            _LineNum = value
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

    Public Property TransCode() As String
        Get
            Return _TransCode
        End Get
        Set(ByVal value As String)
            _TransCode = value
        End Set
    End Property

    Public Property PoNum() As String
        Get
            Return _PoNum
        End Get
        Set(ByVal value As String)
            _PoNum = value
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

    Public Property CcNum() As String
        Get
            Return _CcNum
        End Get
        Set(ByVal value As String)
            _CcNum = value
        End Set
    End Property

    Public Property CcName() As String
        Get
            Return _CcName
        End Get
        Set(ByVal value As String)
            _CcName = value
        End Set
    End Property

    Public Property InvDesc() As String
        Get
            Return _InvDesc
        End Get
        Set(ByVal value As String)
            _InvDesc = value
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

    Public Property AllocAmt() As Decimal
        Get
            Return _AllocAmt
        End Get
        Set(ByVal value As Decimal)
            _AllocAmt = value
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

    Public Property InvoiceDate() As Date
        Get
            Return _InvoiceDate
        End Get
        Set(ByVal value As Date)
            _InvoiceDate = value
        End Set
    End Property

    Public Property EncumDate() As Date
        Get
            Return _EncumDate
        End Get
        Set(ByVal value As Date)
            _EncumDate = value
        End Set
    End Property

    Public Property DtTbePd() As Date
        Get
            Return _DtTbePd
        End Get
        Set(ByVal value As Date)
            _DtTbePd = value
        End Set
    End Property

    Public Property PaidDate() As Date
        Get
            Return _PaidDate
        End Get
        Set(ByVal value As Date)
            _PaidDate = value
        End Set
    End Property

    Public Property ChkNum() As String
        Get
            Return _ChkNum
        End Get
        Set(ByVal value As String)
            _ChkNum = value
        End Set
    End Property

    Public Property BankKey() As String
        Get
            Return _BankKey
        End Get
        Set(ByVal value As String)
            _BankKey = value
        End Set
    End Property

    Public Property BankName() As String
        Get
            Return _BankName
        End Get
        Set(ByVal value As String)
            _BankName = value
        End Set
    End Property

    Public Property PayAmt() As Decimal
        Get
            Return _PayAmt
        End Get
        Set(ByVal value As Decimal)
            _PayAmt = value
        End Set
    End Property

    Public Property BalDue() As Decimal
        Get
            Return _BalDue
        End Get
        Set(ByVal value As Decimal)
            _BalDue = value
        End Set
    End Property

    Public Property InvAmt() As Decimal
        Get
            Return _InvAmt
        End Get
        Set(ByVal value As Decimal)
            _InvAmt = value
        End Set
    End Property

    Public Property Paid() As String
        Get
            Return _Paid
        End Get
        Set(ByVal value As String)
            _Paid = value
        End Set
    End Property

    Public Property Glpost() As String
        Get
            Return _Glpost
        End Get
        Set(ByVal value As String)
            _Glpost = value
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

    Public Property Checked() As String
        Get
            Return _Checked
        End Get
        Set(ByVal value As String)
            _Checked = value
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

    Public Property SortName() As String
        Get
            Return _SortName
        End Get
        Set(ByVal value As String)
            _SortName = value
        End Set
    End Property

    Public Property JrnlNum() As Integer
        Get
            Return _JrnlNum
        End Get
        Set(ByVal value As Integer)
            _JrnlNum = value
        End Set
    End Property

    Public Property JrnlLine() As Integer
        Get
            Return _JrnlLine
        End Get
        Set(ByVal value As Integer)
            _JrnlLine = value
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

    Public Property ContractKey() As String
        Get
            Return _ContractKey
        End Get
        Set(ByVal value As String)
            _ContractKey = value
        End Set
    End Property

    Public Property FromDate() As Date
        Get
            Return _FromDate
        End Get
        Set(ByVal value As Date)
            _FromDate = value
        End Set
    End Property

    Public Property ToDate() As Date
        Get
            Return _ToDate
        End Get
        Set(ByVal value As Date)
            _ToDate = value
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

    Public Property Units() As Decimal
        Get
            Return _Units
        End Get
        Set(ByVal value As Decimal)
            _Units = value
        End Set
    End Property

    Public Property PmtNum() As Integer
        Get
            Return _PmtNum
        End Get
        Set(ByVal value As Integer)
            _PmtNum = value
        End Set
    End Property


    Public ReadOnly Property CompanyInvoiceColumnNames() As String
        Get
            Return "([Inv_num] , [Line_Num] , [Invoice] , [Trans_Code] , [Po_Num] , [Name_Key] , [Screen_Nam] , [Cc_Num] , [Cc_Name] , [Inv_Desc] , [Dr_Acct_Nu] , [Cr_Acct_Nu] , [Alloc_Amt] , [Entry_Date] , [Invoice_Date] , [Encum_Date] , [Dt_Tbe_Pd] , [Paid_Date] , [Chk_Num] , [Bank_Key] , [Bank_Name] , [Pay_Amt] , [Bal_Due] , [Inv_Amt] , [Paid] , [Glpost] , [Dflag] , [Agency] , [Checked] , [Void] , [Sort_Name] , [Jrnl_Num] , [Jrnl_Line] , [Inv_Type] , [Contract_Key] , [From_Date] , [To_Date] , [Unit_Rate] , [Units] , [Pmt_Num] )"
        End Get
    End Property

    Public ReadOnly Property CompanyInvoiceColumnData() As String
        Get
            '    Return String.Format(" {0}, {1}, {2}, {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} " _
            '                         , _InvNum.ToString _
            '                         , _LineNum.ToString _
            '                         , Database.StringParam(_Invoice.ToString) _
            '                            , Database.StringParam(_TransCode.ToString) _
            '                            , Database.StringParam(_PoNum.ToString) _
            '                            , Database.StringParam(_NameKey.ToString) _
            '                            , Database.StringParam(_ScreenNam.ToString) _
            '                            , Database.StringParam(_CcNum.ToString) _
            '                            , Database.StringParam(_CcName.ToString) _
            '                               , Database.StringParam(_InvDesc.ToString) _
            '                               , Database.StringParam(_DrAcctNu.ToString) _
            '                            , Database.StringParam(_CrAcctNu.ToString) _
            '                            , (_AllocAmt.ToString) _
            '                            , Database.StringParam(_EntryDate.ToShortDateString) _
            '                            , Database.StringParam(_InvoiceDate.ToShortDateString) _
            '                            , Database.StringParam(_EncumDate.ToShortDateString) _
            '                            , Database.StringParam(_DtTbePd.ToShortDateString) _
            '                            , Database.StringParam(_PaidDate.ToShortDateString) _
            '                         )
            'End Get

            Return String.Format("({0} , {1}, {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} )" _
                    , (_InvNum.ToString) _
                    , (_LineNum.ToString) _
                    , Database.StringParam(_Invoice.ToString) _
                    , Database.StringParam(_TransCode.ToString) _
                    , Database.StringParam(_PoNum.ToString) _
                    , Database.StringParam(_NameKey.ToString) _
                    , Database.StringParam(_ScreenNam.ToString) _
                    , Database.StringParam(_CcNum.ToString) _
                    , Database.StringParam(_CcName.ToString) _
                    , Database.StringParam(_InvDesc.ToString) _
                    , Database.StringParam(_DrAcctNu.ToString) _
                    , Database.StringParam(_CrAcctNu.ToString) _
                    , (_AllocAmt.ToString) _
                    , Database.StringParam(_EntryDate.ToShortDateString) _
                    , Database.StringParam(_InvoiceDate.ToShortDateString) _
                    , Database.StringParam(_EncumDate.ToShortDateString) _
                    , Database.StringParam(_DtTbePd.ToShortDateString) _
                    , Database.StringParam(_PaidDate.ToShortDateString) _
                    , Database.StringParam(_ChkNum.ToString) _
                    , Database.StringParam(_BankKey.ToString) _
                    , Database.StringParam(_BankName.ToString) _
                    , (_PayAmt.ToString) _
                    , (_BalDue.ToString) _
                    , (_InvAmt.ToString) _
                    , Database.StringParam(_Paid.ToString) _
                    , Database.StringParam(_Glpost.ToString) _
                    , Database.StringParam(_Dflag.ToString) _
                    , (_Agency.ToString) _
                    , Database.StringParam(_Checked.ToString) _
                    , Database.StringParam(_Void.ToString) _
                    , Database.StringParam(_SortName.ToString) _
                    , (_JrnlNum.ToString) _
                    , (_JrnlLine.ToString) _
                    , Database.StringParam(_InvType.ToString) _
                    , Database.StringParam(_ContractKey.ToString) _
                    , Database.StringParam(_FromDate.ToShortDateString) _
                    , Database.StringParam(_ToDate.ToShortDateString) _
                    , (_UnitRate.ToString) _
                    , (_Units.ToString) _
                    , (_PmtNum.ToString) _
                    )
        End Get
    End Property
End Class
