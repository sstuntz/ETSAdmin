Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common


Public Class CashReceiptData
    Private _BankKey As String
    Private _EncumDate As Date
    Private _NameKey As String
    Private _ScreenNam As String
    Private _SortName As String
    Private _ChkNum As String
    Private _ChkDate As Date
    Private _GrossAmt As Decimal
    Private _ChkDisc As Decimal
    Private _CheckAmt As Decimal
    Private _EntryNum As Integer
    Private _InvNum As Integer
    Private _LineNum As Integer
    Private _Invoice As String
    Private _TransCode As String
    Private _ChkAlloc As Decimal
    Private _DrAcctNu As String
    Private _CrAcctNu As String
    Private _Memo As String
    Private _Donor As String
    Private _EntryDate As Date
    Private _Checked As String
    Private _VoidChk As String
    Private _Glpost As String
    Private _Dflag As String
    Private _Agency As Integer
    Private _DiscAcct As String
    Private _JrnlNum As Integer
    Private _JrnlLine As Integer
    Private _Fund As String
    Private _BatchNum As Integer
    Private _BatchDesc As String
    Private _BatchDate As Date
    Private _BatchTotal As Decimal
    Private _SM As String

    Public Property BankKey() As String
        Get
            Return _BankKey
        End Get
        Set(ByVal value As String)
            _BankKey = value
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

    Public Property ChkNum() As String
        Get
            Return _ChkNum
        End Get
        Set(ByVal value As String)
            _ChkNum = value
        End Set
    End Property

    Public Property ChkDate() As Date
        Get
            Return _ChkDate
        End Get
        Set(ByVal value As Date)
            _ChkDate = value
        End Set
    End Property

    Public Property GrossAmt() As Decimal
        Get
            Return _GrossAmt
        End Get
        Set(ByVal value As Decimal)
            _GrossAmt = value
        End Set
    End Property

    Public Property ChkDisc() As Decimal
        Get
            Return _ChkDisc
        End Get
        Set(ByVal value As Decimal)
            _ChkDisc = value
        End Set
    End Property

    Public Property CheckAmt() As Decimal
        Get
            Return _CheckAmt
        End Get
        Set(ByVal value As Decimal)
            _CheckAmt = value
        End Set
    End Property

    Public Property EntryNum() As Integer
        Get
            Return _EntryNum
        End Get
        Set(ByVal value As Integer)
            _EntryNum = value
        End Set
    End Property

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

    Public Property ChkAlloc() As Decimal
        Get
            Return _ChkAlloc
        End Get
        Set(ByVal value As Decimal)
            _ChkAlloc = value
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

    Public Property Memo() As String
        Get
            Return _Memo
        End Get
        Set(ByVal value As String)
            _Memo = value
        End Set
    End Property

    Public Property Donor() As String
        Get
            Return _Donor
        End Get
        Set(ByVal value As String)
            _Donor = value
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

    Public Property Checked() As String
        Get
            Return _Checked
        End Get
        Set(ByVal value As String)
            _Checked = value
        End Set
    End Property

    Public Property VoidChk() As String
        Get
            Return _VoidChk
        End Get
        Set(ByVal value As String)
            _VoidChk = value
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

    Public Property DiscAcct() As String
        Get
            Return _DiscAcct
        End Get
        Set(ByVal value As String)
            _DiscAcct = value
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

    Public Property Fund() As String
        Get
            Return _Fund
        End Get
        Set(ByVal value As String)
            _Fund = value
        End Set
    End Property

    Public Property BatchNum() As Integer
        Get
            Return _BatchNum
        End Get
        Set(ByVal value As Integer)
            _BatchNum = value
        End Set
    End Property

    Public Property BatchDesc() As String
        Get
            Return _BatchDesc
        End Get
        Set(ByVal value As String)
            _BatchDesc = value
        End Set
    End Property

    Public Property BatchDate() As Date
        Get
            Return _BatchDate
        End Get
        Set(ByVal value As Date)
            _BatchDate = value
        End Set
    End Property

    Public Property BatchTotal() As Decimal
        Get
            Return _BatchTotal
        End Get
        Set(ByVal value As Decimal)
            _BatchTotal = value
        End Set
    End Property

    Public Property SM() As String
        Get
            Return _SM
        End Get
        Set(ByVal value As String)
            _SM = value
        End Set
    End Property


    Public ReadOnly Property CashReceiptColumnNames() As String
        Get
            Return "([Bank_Key] , [Encum_Date] , [Name_Key] , [Screen_Nam] , [Sort_Name] , [Chk_Num] , [Chk_Date] , [Gross_Amt] , [Chk_Disc] , [Check_Amt] , [Entry_Num] , [Inv_Num] , [Line_Num] , [Invoice] , [Trans_Code] , [Chk_Alloc] , [Dr_Acct_Nu] , [Cr_Acct_Nu] , [Memo] , [Donor] , [Entry_Date] , [Checked] , [Void_Chk] , [Glpost] , [Dflag] , [Agency] , [Disc_Acct] , [Jrnl_Num] , [Jrnl_Line] , [Fund] , [Batch_Num] , [Batch_Desc] , [Batch_Date] , [Batch_Total] , [S_M] )"
        End Get
    End Property

    Public ReadOnly Property CashReceiptColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} )" _
, Database.StringParam(_BankKey.ToString) _
, Database.StringParam(_EncumDate.ToShortDateString) _
, Database.StringParam(_NameKey.ToString) _
, Database.StringParam(_ScreenNam.ToString) _
, Database.StringParam(_SortName.ToString) _
, Database.StringParam(_ChkNum.ToString) _
, Database.StringParam(_ChkDate.ToShortDateString) _
, (_GrossAmt.ToString) _
, (_ChkDisc.ToString) _
, (_CheckAmt.ToString) _
, (_EntryNum.ToString) _
, (_InvNum.ToString) _
, (_LineNum.ToString) _
, Database.StringParam(_Invoice.ToString) _
, Database.StringParam(_TransCode.ToString) _
, (_ChkAlloc.ToString) _
, Database.StringParam(_DrAcctNu.ToString) _
, Database.StringParam(_CrAcctNu.ToString) _
, Database.StringParam(_Memo.ToString) _
, Database.StringParam(_Donor.ToString) _
, Database.StringParam(_EntryDate.ToShortDateString) _
, Database.StringParam(_Checked.ToString) _
, Database.StringParam(_VoidChk.ToString) _
, Database.StringParam(_Glpost.ToString) _
, Database.StringParam(_Dflag.ToString) _
, (_Agency.ToString) _
, Database.StringParam(_DiscAcct.ToString) _
, (_JrnlNum.ToString) _
, (_JrnlLine.ToString) _
, Database.StringParam(_Fund.ToString) _
, (_BatchNum.ToString) _
, Database.StringParam(_BatchDesc.ToString) _
, Database.StringParam(_BatchDate.ToShortDateString) _
, (_BatchTotal.ToString) _
, Database.StringParam(_SM.ToString) _
)
        End Get
    End Property
End Class
