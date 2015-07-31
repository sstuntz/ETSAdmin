Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient

Public Class frmxaropn
    Inherits System.Windows.Forms.Form

    Private Sub att_edit_bill_type_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Dim HeaderDates As String() = ETSCommon.GetBeginEndDates.Split(CChar("*"))
        start_date.Text = HeaderDates(0)
        End_Date.Text = HeaderDates(1)
        selected_start_date = CDate(start_date.Text)
        selected_end_date = CDate(End_Date.Text)

        msg = "Date (" & Year(CDate(start_date.Text)) & "," & Month(CDate(start_date.Text)) & "," & VB.Day(CDate(start_date.Text)) & ")"
        prtParameterFields(0) = "Begdate;" & msg & ";FALSE"
        msg = "Date (" & Year(CDate(End_Date.Text)) & "," & Month(CDate(End_Date.Text)) & "," & VB.Day(CDate(End_Date.Text)) & ")"
        prtParameterFields(1) = "EndDate;" & msg & ";FALSE"

        ctrform(Me)
    End Sub

    Private Sub End_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Date.Enter
        Call ets_set_selected()
    End Sub

    Private Sub End_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles End_Date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = End_Date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")

            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                End_Date.Text = CDate(retdate).ToShortDateString
                selected_end_date = CDate(retdate)
            End If

            If DateDiff(DateInterval.Day, CDate(start_date.Text), CDate(End_Date.Text)) < 0 Then
                MsgBox("Invalid date range")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            'put dates in rpthead
            sqlstmnt = "update rpthead set beg_date = '" & start_date.Text & "', end_date = ' " & End_Date.Text & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0

        End If

EventExitSub:
        EventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            EventArgs.Handled = True
        End If
    End Sub

    Private Sub End_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Date.Leave
        End_Date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

        msg = "Date (" & Year(CDate(start_date.Text)) & "," & Month(CDate(start_date.Text)) & "," & VB.Day(CDate(start_date.Text)) & ")"
        prtParameterFields(0) = "Begdate;" & msg & ";FALSE"
        msg = "Date (" & Year(CDate(End_Date.Text)) & "," & Month(CDate(End_Date.Text)) & "," & VB.Day(CDate(End_Date.Text)) & ")"
        prtParameterFields(1) = "EndDate;" & msg & ";FALSE"

    End Sub

    Private Sub Start_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date.Enter
        Call ets_set_selected()

    End Sub

    Private Sub Start_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles start_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Then
            senddate = start_date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")
            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                selected_start_date = CDate(retdate)
                start_date.Text = CDate(retdate).ToShortDateString
            End If

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0

        End If


EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub Start_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date.Leave
        start_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        prtDestination = 0
        prtreportfilename = ar_report_path & "ar_ytd_bal.rpt"
        CrystalForm.ShowDialog()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        prtDestination = 0
        prtreportfilename = ar_report_path & "ar_trial_bal.rpt"
        CrystalForm.ShowDialog()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        prtDestination = 0
        prtreportfilename = ar_report_path & "ar_face_Sheet.rpt"
        CrystalForm.ShowDialog()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        prtDestination = 0
        prtreportfilename = ar_report_path & "ar_acct_recon.rpt"
        CrystalForm.ShowDialog()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        prtDestination = 0
        prtreportfilename = ar_report_path & "ar_acct_recon_one.rpt"
        CrystalForm.ShowDialog()
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        prtDestination = 0
        prtreportfilename = ar_report_path & "ar_age_dun_inv.rpt"
        CrystalForm.ShowDialog()
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        prtDestination = 0
        prtreportfilename = ar_report_path & "ar_age_dun_enc.rpt"
        CrystalForm.ShowDialog()
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        prtDestination = 0
        prtreportfilename = ar_report_path & "ar_unbilled.rpt"
        CrystalForm.ShowDialog()
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        prtDestination = 0
        prtreportfilename = ar_report_path & "ar_reference.rpt"
        CrystalForm.ShowDialog()
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        prtDestination = 0
        prtreportfilename = ar_report_path & "ar_reference1.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class