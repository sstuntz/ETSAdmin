Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Imports PS.Common

Public Class VoucherData

    Private _DRAcctNum As String
    Private _CRAcctNum As String
    Private _AcctDesc As String
    Private _VouchNum As Integer
    Private _VouchLine As Integer
    Private _NameKey As String
    Private _ScreenNam As String
    Private _CntrctKey As String
    Private _VendInv As String
    Private _VendInvDate As Date
    Private _DateRecd As Nullable(Of Date)
    Private _PoNum As String
    Private _DtTBePaid As Date
    Private _AllocAmt As Double
    Private _DiscAmt As Double
    Private _BankKey As String
    Private _EntryDate As Date
    Private _BPostDate As Nullable(Of Date)
    Private _EncumDate As Date
    Private _glpost As String
    Private _reimb As String
    Private _memo As String
    Private _dflag As String
    Private _VouchAmt As Double
    Private _paid As String
    Private _Agency As String
    Private _Checked As String
    Private _void As String
    Private _JrnlNum As Integer
    Private _JrnlLineNum As Integer
    Private _SortName As String
    Private _CheckNum As String
    Private _checkDate As Date
    Private _VoucherColumnData As String

    Public Property DRAcctNum() As String
        Get
            Return _DRAcctNum
        End Get
        Set(ByVal value As String)
            _DRAcctNum = value
        End Set
    End Property

    Public Property CRAcctNum() As String
        Get
            Return _CRAcctNum
        End Get
        Set(ByVal value As String)
            _CRAcctNum = value
        End Set
    End Property

    Public Property AcctDesc() As String
        Get
            Return _AcctDesc
        End Get
        Set(ByVal value As String)
            _AcctDesc = value
        End Set
    End Property

    Public Property VouchNum() As Integer
        Get
            Return _VouchNum
        End Get
        Set(ByVal value As Integer)
            _VouchNum = value
        End Set
    End Property
    Public Property VouchLine() As Integer
        Get
            Return _VouchLine
        End Get
        Set(ByVal value As Integer)
            _VouchLine = value
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

    Public Property CntrctKey() As String
        Get
            Return _CntrctKey
        End Get
        Set(ByVal value As String)
            _CntrctKey = value
        End Set
    End Property

    Public Property VendInv() As String
        Get
            Return _VendInv
        End Get
        Set(ByVal value As String)
            _VendInv = value
        End Set
    End Property

    Public Property VendInvDate() As Date
        Get
            Return _VendInvDate
        End Get
        Set(ByVal value As Date)
            _VendInvDate = value
        End Set
    End Property

    Public Property DateRecd() As Nullable(Of Date)
        Get
            Return _DateRecd
        End Get
        Set(ByVal value As Nullable(Of Date))
            _DateRecd = CDate(value)
        End Set
    End Property

    Public Property PONum() As String
        Get
            Return _PoNum
        End Get
        Set(ByVal value As String)
            _PoNum = value
        End Set
    End Property

    Public Property DtTBePaid() As Date
        Get
            Return _DtTBePaid
        End Get
        Set(ByVal value As Date)
            _DtTBePaid = value
        End Set
    End Property

    Public Property AllocAmt() As Double
        Get
            Return _AllocAmt
        End Get
        Set(ByVal value As Double)
            _AllocAmt = value
        End Set
    End Property

    Public Property DiscAmt() As Double
        Get
            Return _DiscAmt
        End Get
        Set(ByVal value As Double)
            _DiscAmt = value
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

    Public Property EntryDate() As Date
        Get
            Return _EntryDate
        End Get
        Set(ByVal value As Date)
            _EntryDate = value
        End Set
    End Property

    Public Property BPostDate() As Nullable(Of Date)
        Get
            Return _BPostDate
        End Get
        Set(ByVal value As Nullable(Of Date))
            _BPostDate = CDate(value)
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

    Public Property GLpost() As String
        Get
            Return _glpost
        End Get
        Set(ByVal value As String)
            _glpost = value
        End Set
    End Property

    Public Property Reimb() As String
        Get
            Return _reimb
        End Get
        Set(ByVal value As String)
            _reimb = value
        End Set
    End Property

    Public Property Memo() As String
        Get
            Return _memo
        End Get
        Set(ByVal value As String)
            _memo = value
        End Set
    End Property

    Public Property dflag() As String
        Get
            Return _dflag
        End Get
        Set(ByVal value As String)
            _dflag = value
        End Set
    End Property

    Public Property VouchAmt() As Double
        Get
            Return _VouchAmt
        End Get
        Set(ByVal value As Double)
            _VouchAmt = value
        End Set
    End Property

    Public Property Paid() As String
        Get
            Return _paid
        End Get
        Set(ByVal value As String)
            _paid = value
        End Set
    End Property

    Public Property Agency() As String
        Get
            Return _Agency
        End Get
        Set(ByVal value As String)
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
            Return _void
        End Get
        Set(ByVal value As String)
            _void = value
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

    Public Property JrnlLineNum() As Integer
        Get
            Return _JrnlLineNum
        End Get
        Set(ByVal value As Integer)
            _JrnlLineNum = value
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

    Public Property CheckNum() As String
        Get
            Return _CheckNum
        End Get
        Set(ByVal value As String)
            _CheckNum = value
        End Set
    End Property

    Public Property CheckDate() As Date
        Get
            Return _checkDate
        End Get
        Set(ByVal value As Date)
            _checkDate = value
        End Set
    End Property

    Public ReadOnly Property VoucherColumnNames() As String
        Get
            Return "([dr_acct_nu] ,[cr_acct_nu] ,[vouch_num] ,[vouch_line] ,[name_key] ,[screen_nam] ,[cntrct_key] ,[vend_inv] ,[vend_inv_d] ,[date_recd]  ,[po_num] ,[dt_tbe_pd] ,[alloc_amt]  ,[disc_amt] ,[bank_key] ,[entry_date] ,[bpost_date] ,[encum_date] ,[glpost] ,[reimb] ,[memo] ,[dflag] ,[vouch_amt] ,[paid] ,[agency] ,[checked],[void], [jrnl_num] ,[jrnl_line]  ,[sort_name])"
        End Get
    End Property
    Public ReadOnly Property VoucherColumnData() As String
        Get
            'Return "'" &  + "','" +  + "','" +  + "','" +  + "','" +  + "','" +  + "','" +  + "','" +  + "'," + + "," +  + ",'" + + "'," +  _
            ' + ",'" +  + "','" +  + "','" +  + "'," +  + "," +  + "," +  + ",'" +  + "','" + + "','" + + "','" +  + "','" +  + "','" +  + "','" + 
            '+ "')"
            ' Return _DRAcctNum.ToString + "," + _CRAcctNum.ToString + "," + _VouchNum.ToString + " , " + _VouchLine.ToString + "," + _NameKey.ToString + "," + _ScreenNam + "," + _CntrctKey + "," + _VendInv + "," + _VendInvDate.ToShortDateString + "," + _DateRecd.ToShortDateString + "," + _PoNum + "," + _DtTBePaid.ToShortDateString _
            ' + "," + _AllocAmt.ToString + "," + _DiscAmt.ToString + "," + _BankKey.ToString + " ," + _EntryDate.ToShortDateString + "," + _BPostDate.ToShortDateString + "," + _EncumDate.ToShortDateString + "," + _glpost + "," + _reimb + "," + _memo + "," + _dflag + "," + _VouchAmt.ToString + "," + _paid + "," + _Agency.ToString + "," + _Checked + "," + _void + "," + _JrnlNum.ToString + "," + _JrnlLineNum.ToString + "," + _SortName _
            '+ ")"
            Return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},'{8}','{9}',{10},'{11}',{12},{13},{14},'{15}','{16}','{17}',{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29}" _
            , Database.StringParam(_DRAcctNum.ToString) _
            , Database.StringParam(_CRAcctNum.ToString) _
            , (_VouchNum.ToString) _
            , (_VouchLine.ToString) _
            , (_NameKey.ToString) _
            , Database.StringParam(_ScreenNam) _
            , Database.StringParam(_CntrctKey) _
            , Database.StringParam(_VendInv) _
            , (_VendInvDate.ToShortDateString) _
            , (_DateRecd) _
            , Database.StringParam(_PoNum) _
            , (_DtTBePaid.ToShortDateString) _
            , (_AllocAmt.ToString) _
            , (_DiscAmt.ToString) _
            , (_BankKey.ToString) _
            , (_EntryDate.ToShortDateString) _
            , (_BPostDate) _
            , (_EncumDate.ToShortDateString) _
            , Database.StringParam(_glpost) _
            , Database.StringParam(_reimb) _
            , Database.StringParam(_memo) _
            , Database.StringParam(_dflag) _
            , (_VouchAmt.ToString) _
            , Database.StringParam(_paid) _
            , Database.StringParam(_Agency.ToString) _
            , Database.StringParam(_Checked) _
            , Database.StringParam(_void) _
            , Database.StringParam(_JrnlNum.ToString) _
            , Database.StringParam(_JrnlLineNum.ToString) _
            , Database.StringParam(_SortName))

        End Get
    End Property


End Class
