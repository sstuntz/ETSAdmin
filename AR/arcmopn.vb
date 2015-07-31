Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient

Public Class arcmopn
    Inherits System.Windows.Forms.Form

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arcmtot.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arcmrep1.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arcmrep2.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arcmone.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub arcmopn_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim HeaderDates As String() = ETSCommon.GetBeginEndDates.Split(CChar("*"))
        txtFields(0).Text = HeaderDates(0)
        txtFields(1).Text = HeaderDates(1)

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index

                Case 0, 1 'date fields

                    senddate = txtFields(Index).Text
                    Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")
                    If retdate = "N" Then
                        senddate = ""
                        MsgBox(" Bad Date")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        selected_start_date = CDate(retdate)
                        txtFields(Index).Text = CDate(retdate).ToShortDateString
                    End If

                    System.Windows.Forms.SendKeys.Send("{tab}")
                    KeyAscii = 0

            End Select

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub _txtFields_1_TextChanged(sender As System.Object, e As System.EventArgs) Handles _txtFields_1.TextChanged
        sqlstmnt = "update rpthead set beg_date = '" & txtFields(0).Text & "', end_date = ' " & txtFields(1).Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)
    End Sub

    Private Sub _txtFields_0_TextChanged(sender As System.Object, e As System.EventArgs) Handles _txtFields_0.TextChanged
        sqlstmnt = "update rpthead set beg_date = '" & txtFields(0).Text & "', end_date = ' " & txtFields(1).Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

    End Sub

 
End Class