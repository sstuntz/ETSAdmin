Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common


Public Class PaymentData
    Private _ChkNum As Integer
    Private _VouchNum As Integer
    Private _NameKey As String
    Private _DtPaid As Date
    Private _DtClear As Date
    Private _ChkAlloc As Double
    Private _ChkDisc As Double
    Private _NetAmt As Double
    Private _void As String
    Private _EncumDate As Date
    Private _EntryDate As Date
    Private _glpost As String
    Private _dflag As String
    Private _Agency As String
    Private _ScreenNam As String
    Private _BankKey As String
    Private _Recon As String
    Private _DRAcctNum As String
    Private _CRAcctNum As String
    Private _DiscAcctNum As String
    Private _JrnlNum As Integer
    Private _JrnlLineNum As Integer
    Private _PaymentColumnNames As String
    Private _PaymentColumnData As String

    Public Property ChkNum() As Integer
        Get
            Return _ChkNum
        End Get
        Set(ByVal value As Integer)
            _ChkNum = value
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

    Public Property NameKey() As String
        Get
            Return _NameKey
        End Get
        Set(ByVal value As String)
            _NameKey = value
        End Set
    End Property

    Public Property DtPaid() As Date
        Get
            Return _DtPaid
        End Get
        Set(ByVal value As Date)
            _DtPaid = value
        End Set
    End Property

    Public Property DtClear() As Date
        Get
            Return _DtClear
        End Get
        Set(ByVal value As Date)
            _DtClear = value
        End Set

    End Property

    Public Property ChkAlloc() As Double
        Get
            Return _ChkAlloc
        End Get
        Set(ByVal value As Double)
            _ChkAlloc = value
        End Set
    End Property

    Public Property ChkDisc() As Double
        Get
            Return _ChkDisc
        End Get
        Set(ByVal value As Double)
            _ChkDisc = value
        End Set
    End Property

    Public Property NetAmt() As Double
        Get
            Return _NetAmt
        End Get
        Set(ByVal value As Double)
            _NetAmt = value
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
    Public Property EncumDate() As Date
        Get
            Return _EncumDate
        End Get
        Set(ByVal value As Date)
            _EncumDate = value
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


    Public Property GLpost() As String
        Get
            Return _glpost
        End Get
        Set(ByVal value As String)
            _glpost = value
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

    Public Property Agency() As String
        Get
            Return _Agency
        End Get
        Set(ByVal value As String)
            _Agency = value
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

    Public Property BankKey() As String
        Get
            Return _BankKey
        End Get
        Set(ByVal value As String)
            _BankKey = value
        End Set
    End Property
    Public Property Recon() As String
        Get
            Return _Recon
        End Get
        Set(ByVal value As String)
            _Recon = value
        End Set
    End Property
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

    Public Property DiscAcctNum() As String
        Get
            Return _DiscAcctNum
        End Get
        Set(ByVal value As String)
            _DiscAcctNum = value
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

    Public ReadOnly Property PaymentColumnNames() As String
        Get
            Return "([chk_num] ,[vouch_num] ,[name_key],[dt_paid] ,[dt_clear],[chk_alloc],[chk_disc],[net_amt],[void],[encum_date],[entry_date],[glpost],[dflag],[agency],[Screen_nam],[bank_key],[recon],[dr_acct_nu],[cr_acct_nu],[disc_acct],[jrnl_num], [jrnl_line] )"
        End Get
    End Property
    Public ReadOnly Property PaymentColumnData() As String
        Get
            'Return "'" & _ChkNum.ToString + "','" + _VouchNum.ToString + "','" + _NameKey.ToString + "','" + _DtPaid.ToShortDateString + "','" + _DtClear.ToShortDateString + "','" + _ChkAlloc.ToString + "','" + _ChkDisc.ToString + "','" + _NetAmt.ToString + "'," + _void.ToString + "," + _EncumDate.ToShortDateString + ",'" + _EntryDate.ToShortDateString _
            ' + ",'" + _glpost.ToString + "','" + _dflag.ToString + "','" + _Agency.ToString + "','" + _ScreenNam.ToString + "','" + _BankKey.ToString + "','" + _Recon.ToString + "','" + _DRAcctNum.ToString + "','" + _CRAcctNum.ToString + "','" + _DiscAcctNum.ToString + "','" + _JrnlNum.ToString + "','" + _JrnlLineNum.ToString _
            '+ "')"
            Return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}" _
           , (_ChkNum.ToString) _
           , (_VouchNum.ToString) _
           , Database.StringParam(_NameKey.ToString) _
           , (_DtPaid.ToShortDateString) _
           , (_DtClear.ToShortDateString) _
           , (_ChkAlloc.ToString) _
           , (_ChkDisc.ToString) _
           , (_NetAmt.ToString) _
           , (_void.ToString) _
           , (_EncumDate.ToShortDateString) _
           , (_EntryDate.ToShortDateString) _
           , (_glpost.ToString) _
           , (_dflag.ToString) _
           , (_Agency.ToString) _
           , Database.StringParam(_ScreenNam.ToString) _
           , (_BankKey.ToString) _
           , (_Recon.ToString) _
           , Database.StringParam(_DRAcctNum.ToString) _
           , Database.StringParam(_CRAcctNum.ToString) _
           , Database.StringParam(_DiscAcctNum.ToString) _
           , (_JrnlNum.ToString) _
           , (_JrnlLineNum.ToString))


        End Get
    End Property

End Class
