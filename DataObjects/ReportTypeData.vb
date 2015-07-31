Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports ps.common
Imports System.Data.SqlClient
Imports System.String

Public Class ReportTypeData

    Private _RptNum As String
    Private _RptPath As String
    Private _RptName As String
    Private _RptDesc As String
    Private _RptPrinter As String

    Public Property RptNum() As String
        Get
            Return _RptNum
        End Get
        Set(ByVal value As String)
            _RptNum = value
        End Set
    End Property

    Public Property RptPath() As String
        Get
            Return _RptPath
        End Get
        Set(ByVal value As String)
            _RptPath = value
        End Set
    End Property

    Public Property RptName() As String
        Get
            Return _RptName
        End Get
        Set(ByVal value As String)
            _RptName = value
        End Set
    End Property

    Public Property RptDesc() As String
        Get
            Return _RptDesc
        End Get
        Set(ByVal value As String)
            _RptDesc = value
        End Set
    End Property

    Public Property RptPrinter() As String
        Get
            Return _RptPrinter
        End Get
        Set(ByVal value As String)
            _RptPrinter = value
        End Set
    End Property


    Public ReadOnly Property ReportTypetColumnNames() As String
        Get
            Return "([RptNum] , [RptPath] , [RptName] , [RptDesc] , [RptPrinter] )"
        End Get
    End Property

    Public ReadOnly Property ReportTypeColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} )" _
, (_RptNum) _
, (_RptPath) _
, (_RptName) _
, (_RptDesc) _
, (_RptPrinter) _
)
        End Get
    End Property
End Class
