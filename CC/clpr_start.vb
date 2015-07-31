Option Strict On
Option Explicit On
Imports System.Text
Imports VB = Microsoft.VisualBasic
Imports ETS.Common.Module1
Imports Microsoft.VisualBasic.Compatibility
Imports Microsoft.VisualBasic.Conversion
Imports ps.common
Imports System.Data.SqlClient
Imports System.Configuration


Public Class clpr_start
    Inherits System.Windows.Forms.Form

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Close()

    End Sub

    Private Sub cc_start_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
    End Sub

    Private Sub pr_Start_date1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_Start_date1.Enter

        Call ets_set_selected()
        sys_Date.Text = Strings.Format(Now, "short date")
        Pr_num1.Text = CStr(1) ' either first one or add one to max number

        'looks up the payroll number and paints it into the field
        Using db As Database = New Database(top_data_path)
            Dim sql As String = " begin;  if exists(select * from ccckstub ) BEGIN;  select top 1 pay_num as pay  from ccckstub order by pay_num desc End;  Else   BEGIN; select 0 as pay end;   End"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            rs.Read()
            pr_num = CInt(rs("pay"))
            rs.Close()
        End Using
        pr_num = pr_num + 1
        Pr_num1.Text = pr_num.ToString

    End Sub

    Private Sub pr_Start_date1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_Start_date1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            valid_Date = "N"
            senddate = pr_Start_date1.Text
            valid_Date = etsdate(senddate, valid_Date)

            If valid_Date <> "N" Then
                pr_Start_date = CDate(valid_Date)
                pr_Start_date1.Text = pr_Start_date.ToShortDateString
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
            Else
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            End If
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_Start_date1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_Start_date1.Leave
        Call ets_de_selected()
        pr_Start_date1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub pr_end_Date1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_end_Date1.Enter
        Call ets_set_selected()
    End Sub

    Private Sub pr_end_Date1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_end_Date1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            valid_Date = "N"
            senddate = pr_end_Date1.Text
            valid_Date = etsdate(senddate, valid_Date)

            If valid_Date <> "N" Then
                pr_end_date = CDate(valid_Date)
                pr_end_Date1.Text = pr_end_date.ToShortDateString
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
            Else
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            End If
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_end_Date1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_end_Date1.Leave
        pr_end_Date1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub Process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Click

        Using db As Database = New Database(top_data_path)
            Dim sql As String = "update rpthead set beg_Date = '" & CDate(pr_Start_date1.Text) & "', end_date = '" & CDate(pr_end_Date1.Text) & "'"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
        End Using

        'get the largest number from the accrual_cnt fields in eevac
        'this will be the number of accruals taken this year.

        Using db As Database = New Database(top_data_path)
            Dim sql As String = "  begin;  if exists(select * from ccvac ) BEGIN;  select top 1 accrual_cnt as vacc from ccvac order by accrual_cnt desc End;  Else   BEGIN; select 0 as vacc end;   End"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            rs.Read()
            intcount = CInt(rs("vacc"))
            intcount = intcount + 1
            msg = intcount.ToString
            rs.Close()
        End Using
        Response = MsgBox("This will be accrual number = " & msg & Chr(13) & "Do you wish to update the ccvac Accruals now?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = 6 Then
            vac_acc.ShowDialog()
        End If
        cc_ent_time.ShowDialog()

    End Sub


End Class