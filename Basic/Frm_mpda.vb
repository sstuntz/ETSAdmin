Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.Compatibility
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Data.SqlClient
Imports System
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Imports System.IO
Imports ETS.Common.Module1
Imports ps.common

Public Class frm_mpdate
    Inherits System.Windows.Forms.Form

    Public EtsDatArray(500) As String  ' all of the data lines in ets dat
    Public flag As Integer
    Public ctrlon As Integer
    Public MenuCode As String = ConfigurationManager.AppSettings("MenuCode")
    Public ReportPath As String = ConfigurationManager.AppSettings("ReportPath")
    Public DefaulInvoicePrinter As String = ConfigurationManager.AppSettings("DefaultInvoicePrinter")
    Public InvoiceLocation As String = ConfigurationManager.AppSettings("InvoiceLocation")
    Public DefaultBankKey As String = ConfigurationManager.AppSettings("DefaultBankKey")
    Public DefaultMiscNameKey As String = ConfigurationManager.AppSettings("DefaultMiscNameKey")
    Public ConnectString(20) As String
    Public ETSConnectionString As String

    Private Sub frm_mpdate_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        'To get all the data from app.config

        'load the combo box

        Dim forctr As Integer
        For forctr = 1 To 11
            ConnectString(forctr) = ConfigurationManager.AppSettings("ConnectionString" & CStr(forctr))
            Dim builder As New SqlConnectionStringBuilder(ConnectString(forctr))

            If builder.InitialCatalog <> "" Then
                EtsDatCombo.Items.Add(builder.InitialCatalog)
            Else
                If forctr > 2 Then
                    EtsDatCombo.Visible = True
                    combolabel.Visible = True
                    EtsDatCombo.SelectedIndex = 0
                    EtsDatCombo.Focus()
                    top_data_path = ""
                    Exit For
                Else
                    'get the variables - 4 of them - backup, menu list, data path, report path
                    '  backup_zip = EtsDatArray(0)
                    ' backup_string = backup_zip
                    avail_apps = CInt(MenuCode)
                    top_data_path = ConnectString(1)
                    rpt_path = "EtsDatArray(3)"
                    Call getagencydata()
                End If
                Exit For
            End If
        Next

        ar_report_path = ReportPath
        att_report_path = ReportPath
        ap_report_path = ReportPath

        Label10.Text = "Version = " & My.Application.Info.Version.ToString

    End Sub

    Private Sub Text2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Text2.KeyPress
        Dim KeyAscii As Integer = (Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Then

            Select Case Text2.Text
                Case "CHUCK"
                    EtsMainMenu.ShowDialog()
                    Me.Close()
                    Me.Dispose()
                    End
                Case "s"
                    'Me.Dispose()
                    EtsMainMenu.ShowDialog()
                    Me.Close()
                    Me.Dispose()
                    End
                Case Else
                    MsgBox("Enter the correct password(UPPER CASE) or Exit")
            End Select
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub EtsDatCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtsDatCombo.SelectedIndexChanged, EtsDatCombo.KeyPress
        'this is the selected ets dat file
        If flag = 0 Then    'this is to allow form to finish loading without going on
            If CInt(EtsDatCombo.SelectedIndex) = 0 Then
                flag = 1
                Exit Sub
            End If
        End If


        top_data_path = ConnectString(EtsDatCombo.SelectedIndex + 1)
        avail_apps = CInt(MenuCode)

        Call getagencydata()

    End Sub
    Private Sub EtsDatCombo_GotFocus()
        Text1.Text = ""
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cancel.Click
        End
    End Sub

    Private Sub getagencydata()

        Using db As Database = New Database(top_data_path) 'top_data_path)
            Dim sql As String = "select * from etssys"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            While rs.Read()
                agency_name = rs("agency_name").ToString
                AgencyNum = CInt(rs("agency"))
                CheckPwd = rs("PwdYN").ToString
            End While
            rs.Close()
        End Using
        Me.Text1.Text = agency_name.ToString
        Text2.Focus()

    End Sub


End Class