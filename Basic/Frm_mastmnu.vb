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
Imports System.Globalization

Public Class frm_Mastmnu
    Inherits System.Windows.Forms.Form

    Public Sub EXMAIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EXMAIN.Click

        EtsMainMenu.Show()
        Me.Close()
        'Me.Hide
    End Sub

    Private Sub frm_Mastmnu_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Text = "ETS Master Name/Address Menu - " & agency_name

    End Sub

    Public Sub nam_date_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles nam_date.Click
        '	'3 namedate

        prtDestination = 0
        prtreportfilename = gl_report_path & "namedate.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub nam_full_type_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles nam_full_type.Click
        '4 nametype
        prtDestination = 0
        prtreportfilename = gl_report_path & "nametype.rpt"
        CrystalForm.ShowDialog()
    End Sub


    Public Sub nam_type_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles nam_type.Click
        'report 2 namecon
        prtDestination = 0
        prtreportfilename = gl_report_path & "namecon.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub namad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles namad.Click
        'found commented out 10/24/05 !!!
        Dim frmnamechk As New frmnamechk
        frmnamechk.Show()
        ' Me.Hide()

    End Sub

    Public Sub name_full_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles name_full.Click
        '1 namall
        prtDestination = 0
        prtreportfilename = gl_report_path & "namall.rpt"
        CrystalForm.ShowDialog()

    End Sub


    Public Sub type_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles type.Click
        Dim frmtype As New frmtype
        frmtype.Show()
    End Sub

    Public Sub type_nam_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles type_nam.Click
        '5 typelist
        prtDestination = 0
        prtreportfilename = gl_report_path & "typelist.rpt"
        CrystalForm.ShowDialog()
    End Sub
End Class