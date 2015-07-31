Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETS.Common.Module1
Imports ps.common
Imports System.Configuration
Imports System.Data.SqlClient

Public Class vac_acc
    Inherits System.Windows.Forms.Form

    Private Sub vac_acc_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)

        Using db As Database = New Database(top_data_path)
            Dim sql As String = "  begin;  if exists(select * from ccvac ) BEGIN;  select top 1 accrual_cnt as vacc from ccvac order by accrual_cnt desc End;  Else   BEGIN; select 0 as vacc end;   End"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            rs.Read()
            intcount = CInt(rs("vacc"))
            intcount = intcount + 1
            msg = intcount.ToString
            rs.Close()
        End Using

        num_acc.Text = msg
        'go thru the file and add an accrual to each max
    End Sub

    Private Sub reset_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles reset_Renamed.Click
        Response = MsgBox("Are you sure you want to reset all the accruals for a new year?", MsgBoxStyle.YesNo)
        If Response = 6 Then
            sqlstmnt = "update ccvac set accrual_cnt =0, max_vac =0, used_vac = 0, max_hol = 0, used_hol =0, max_sick =0, used_sick =0, max_pers= 0, used_pers =0 "
            ETSSQL.ExecuteSQL(sqlstmnt)
            Me.Close()
        End If

    End Sub

    Private Sub upd_vac_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles upd_vac.Click
        'set ee or cc accrual counter + 1

        sqlstmnt = "update ccvac set accrual_cnt = '" & msg & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        sqlstmnt = "update ccvac set max_vac = max_vac + v_accrual, max_hol = max_hol + h_accrual, max_sick = max_sick _ s_accrual, max_pers = maX_pers + p_accrual"

        ETSSQL.ExecuteSQL(sqlstmnt)

        Me.Close()

    End Sub

    Private Sub cmdclose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Me.Close()
    End Sub
End Class