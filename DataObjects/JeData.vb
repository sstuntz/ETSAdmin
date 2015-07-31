Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class JeData

    Private _JrnlNum As Integer
    Private _JrnlLineNum As Integer
    Private _EntryType As String
    Private _JrnlName As String
    Private _JrnlSrc As String
    Private _EntryDate As Date
    Private _EncumDate As Date
    Private _PostDate As Date
    Private _AcctNum As String
    Private _AcctDesc As String
    Private _Amount As Double
    Private _JrnlDesc As String
    Private _OperId As String
    Private _APost As String
    Private _Post As String
    Private _dflag As String
    Private _void As String
    Private _Agency As String

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

    Public Property EntryType() As String
        Get
            Return _EntryType
        End Get
        Set(ByVal value As String)
            _EntryType = value
        End Set
    End Property

    Public Property JrnlName() As String
        Get
            Return _JrnlName
        End Get
        Set(ByVal value As String)
            _JrnlName = value
        End Set
    End Property

    Public Property JrnlSrc() As String
        Get
            Return _JrnlSrc
        End Get
        Set(ByVal value As String)
            _JrnlSrc = value
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

    Public Property EncumDate() As Date
        Get
            Return _EncumDate
        End Get
        Set(ByVal value As Date)
            _EncumDate = value
        End Set
    End Property

    Public Property PostDate() As Date
        Get
            Return _PostDate
        End Get
        Set(ByVal value As Date)
            _PostDate = value
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

    Public Property AcctDesc() As String
        Get
            Return _AcctDesc
        End Get
        Set(ByVal value As String)
            _AcctDesc = value
        End Set
    End Property

    Public Property Amount() As Double
        Get
            Return _Amount
        End Get
        Set(ByVal value As Double)
            _Amount = value
        End Set
    End Property

    Public Property JrnlDesc() As String
        Get
            Return _JrnlDesc
        End Get
        Set(ByVal value As String)
            _JrnlDesc = value
        End Set
    End Property

    Public Property OperId() As String
        Get
            Return _OperId
        End Get
        Set(ByVal value As String)
            _OperId = value
        End Set
    End Property

    Public Property APost() As String
        Get
            Return _APost
        End Get
        Set(ByVal value As String)
            _APost = value
        End Set
    End Property

    Public Property Post() As String
        Get
            Return _Post
        End Get
        Set(ByVal value As String)
            _Post = value
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

    Public Property Void() As String
        Get
            Return _void
        End Get
        Set(ByVal value As String)
            _void = value
        End Set
    End Property

End Class
