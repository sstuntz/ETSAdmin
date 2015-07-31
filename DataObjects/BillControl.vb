Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.String
Imports ps.common



Public Class BillControlData
    Private _ContractKey As String
    Private _ServBeg As Date
    Private _ServEnd As Date
    Private _BillDate As Date
    Private _Invoice As String
    Private _AmtBilled As Decimal
    Private _Comment As String
    Private _InvNum As Integer
    Private _DeliveryMethod As String
    Private _EmailAddress As String
    Private _Sent As String
    Private _SentDate As Date
    Private _AcctNum As String
    Private _PrinterName As String

    Public Property ContractKey() As String
        Get
            Return _ContractKey
        End Get
        Set(ByVal value As String)
            _ContractKey = value
        End Set
    End Property

    Public Property ServBeg() As Date
        Get
            Return _ServBeg
        End Get
        Set(ByVal value As Date)
            _ServBeg = value
        End Set
    End Property

    Public Property ServEnd() As Date
        Get
            Return _ServEnd
        End Get
        Set(ByVal value As Date)
            _ServEnd = value
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

    Public Property Invoice() As String
        Get
            Return _Invoice
        End Get
        Set(ByVal value As String)
            _Invoice = value
        End Set
    End Property

    Public Property AmtBilled() As Decimal
        Get
            Return _AmtBilled
        End Get
        Set(ByVal value As Decimal)
            _AmtBilled = value
        End Set
    End Property

    Public Property Comment() As String
        Get
            Return _Comment
        End Get
        Set(ByVal value As String)
            _Comment = value
        End Set
    End Property
    'Public Property Comment() As String
    '    Get
    '        Return _Comment
    '    End Get
    '    Set(ByVal value As String)
    '        _Comment = value
    '    End Set
    'End Property

    Public Property InvNum() As Integer
        Get
            Return _InvNum
        End Get
        Set(ByVal value As Integer)
            _InvNum = value
        End Set
    End Property

    Public Property DeliveryMethod() As String
        Get
            Return _DeliveryMethod
        End Get
        Set(ByVal value As String)
            _DeliveryMethod = value
        End Set
    End Property

    Public Property EmailAddress() As String
        Get
            Return _EmailAddress
        End Get
        Set(ByVal value As String)
            _EmailAddress = value
        End Set
    End Property

    Public Property Sent() As String
        Get
            Return _Sent
        End Get
        Set(ByVal value As String)
            _Sent = value
        End Set
    End Property

    Public Property SentDate() As Date
        Get
            Return _SentDate
        End Get
        Set(ByVal value As Date)
            _SentDate = value
        End Set
    End Property

    Public Property AcctNum() As String
        Get
            Return _AcctNum
        End Get
        Set(ByVal value As String)
            _AcctNum = value
        End Set
    End Property

    Public Property PrinterName() As String
        Get
            Return _PrinterName
        End Get
        Set(ByVal value As String)
            _PrinterName = value
        End Set
    End Property

    Public ReadOnly Property BillControlColumnNames() As String
        Get
            Return "([Contract_Key] , [Serv_Beg] , [Serv_End] , [Bill_Date] , [Invoice] , [Amt_Billed] , [Comment] , [Inv_Num], [DeliveryMethod], [EmailAddress], [Sent], [SentDate], [Acct_num], [PrinterName] )"
        End Get
    End Property

    Public ReadOnly Property BillControlColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7}, {8}, {9}, {10}, {11}, {12}, {13} )" _
            , Database.StringParam(_ContractKey.ToString) _
            , Database.StringParam(_ServBeg.ToShortDateString) _
            , Database.StringParam(_ServEnd.ToShortDateString) _
            , Database.StringParam(_BillDate.ToShortDateString) _
            , Database.StringParam(_Invoice.ToString) _
            , (_AmtBilled.ToString) _
            , Database.StringParam(_Comment.ToString) _
            , (_InvNum.ToString) _
            , Database.StringParam(_DeliveryMethod.ToString) _
            , Database.StringParam(_EmailAddress.ToString) _
            , Database.StringParam(_Sent.ToString) _
            , Database.StringParam(_SentDate.ToShortDateString) _
            , Database.StringParam(_AcctNum.ToString) _
            , Database.StringParam(_PrinterName.ToString) _
            )
        End Get
    End Property
End Class
