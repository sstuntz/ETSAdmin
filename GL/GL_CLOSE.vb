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
Imports Valid_YN
Imports ETS

Public Class gl_close
    Inherits System.Windows.Forms.Form

    Private Sub close_gl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles close_gl.Click
        Dim bad_flag As String = "N"
        Dim tot_amt As Double = 0
        Dim sqlwhere As String
        sqlwhere = " WHERE post <> 'Y' and void <> 'Y' and dflag <> 'Y' "
        sqlwhere = sqlwhere & " and encum_date between "
        sqlwhere = sqlwhere & Chr(35) & txtfields(0).Text & Chr(35) & " and "
        sqlwhere = sqlwhere & Chr(35) & txtfields(1).Text & Chr(35) & " "

        sqlstmnt = "select * from yrgenled WHERE post <> 'Y' and void <> 'Y' and dflag <> 'Y' "
        sqlstmnt = sqlstmnt & " and encum_date between "
        sqlstmnt = sqlstmnt & Chr(35) & txtfields(0).Text & Chr(35) & " and "
        sqlstmnt = sqlstmnt & Chr(35) & txtfields(1).Text & Chr(35) & " order by acct_num "

        If ETS.Common.Module1.CheckRecordCount(sqlstmnt) = 0 Then
            MsgBox("There are no journal entry records for this date range.")
            Exit Sub
        End If

        ''we now check the JEs to make sure they are in balance and the acct numbers are good

        Dim AcctSplit As String()
        AcctSplit = GLMod.CheckJeData(sqlstmnt).Split(CChar("*"))
        Select Case AcctSplit(0)
            Case "N"
                'ok
            Case "T"
                MsgBox("Journal Entries for the period selected are out of balance.  Please Edit and try again.")
                Exit Sub
            Case "Y"
                MsgBox("There is an invalid account = " & AcctSplit(1) & Chr(10) & " on JE# = " & AcctSplit(2) & " line # = " & AcctSplit(3))
                MsgBox("There is bad data.  Please make corrections before attempting another post.")
                Exit Sub
        End Select

        Dim mth As String
        mth = "cur_m" & mth_num.Text

        'update flags
        sqlstmnt = " update yrgenled set post = 'Y', post_date = '" & Date.Today & "' " & sqlwhere
        ETSSQL.ExecuteSQL(sqlstmnt)

        'add acct amts and write amount to chacct for the month
        sqlstmnt = "Update chacct "
        sqlstmnt = sqlstmnt & "SET " & mth & " = derivedtbl_1.TotAmt "
        sqlstmnt = sqlstmnt & " FROM (SELECT SUM(amount) AS TotAmt FROM yrgenled"
        sqlstmnt = sqlstmnt & " GROUP BY acct_num, void, dflag, post, encum_date) "
        sqlstmnt = sqlstmnt & " HAVING (post <> N'Y') AND (dflag <> N'Y') AND (void <> N'Y') "
        sqlstmnt = sqlstmnt & " and encum_date between "
        sqlstmnt = sqlstmnt & Chr(35) & txtfields(0).Text & Chr(35) & " and "
        sqlstmnt = sqlstmnt & Chr(35) & txtfields(1).Text & Chr(35) & ") AS derivedtbl_1 CROSS JOIN chacct"
        ETSSQL.ExecuteSQL(sqlstmnt)

        '        SELECT     yrgenled.encum_date, yrgenled.acct_num, yrgenled.amount, yrgenled.post, yrgenled.dflag, yrgenled.void, SUM(yrgenled.amount) AS tot
        'FROM         yrgenled INNER JOIN
        '                      chacct ON yrgenled.acct_num = chacct.acct_num
        'GROUP BY yrgenled.encum_date, yrgenled.acct_num, yrgenled.amount, yrgenled.post, yrgenled.dflag, yrgenled.void
        'HAVING      (yrgenled.void <> N'Y') AND (yrgenled.dflag <> N'Y') AND (yrgenled.post <> N'Y') AND (yrgenled.encum_date BETWEEN CONVERT(DATETIME, '2011-01-01 00:00:00', 
        '                      102) AND CONVERT(DATETIME, '2011-12-31 00:00:00', 102))


        'check for unposted entries and set the button to print the report if there are some
        'go back and make the summary calculations for the fields

        sqlstmnt = "update chacct set cur_ytd = cur_m1 + cur_m2 + cur_m3 + cur_m4 + cur_m5 + cur_m6 + cur_m7 + cur_m8 + cur_m9 + cur_m10 + cur_m11 + cur_m12"
        ETSSQL.ExecuteSQL(sqlstmnt)

        'add bud year to date thru this month
        sqlstmnt = "update chacct set bud_ytd =  bud_m1 "
        For num As Integer = 1 To CInt(mth_num.ToString)
            sqlstmnt = sqlstmnt & "  + bud_m" & num.ToString
        Next
        ETSSQL.ExecuteSQL(sqlstmnt)

        ''tests to see if any unposted j/e entries
        sqlstmnt = " select * from yrgenled where post = 'N' and encum_date gt '" & CDate(txtfields(1).Text)
        If ETS.Common.Module1.CheckRecordCount(sqlstmnt) <> 0 Then
            prt_unposted.Visible = True
        End If

        MsgBox("Select and Post is Complete")

    End Sub

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        'put dates into rprhead

        sqlstmnt = "update rpthead set end_date = '" & _txtfields_0.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)
        close_gl.Enabled = True

        close_gl.Focus()
    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub gl_close_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub mth_name_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mth_name.Enter
        Call ets_set_selected()
    End Sub

    Private Sub mth_name_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles mth_name.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            mth_name.Text = VB.Left(UCase(mth_name.Text), 3)
            Response = InStr("JUL,AUG,SEP,OCT,NOV,DEC,JAN,FEB,MAR,APR,MAY,JUN", mth_name.Text)

            If Response = 0 Then
                MsgBox("Invalid Month")
                GoTo EventExitSub
            End If
            mth_num.Text = CStr(Int(Response / 4) + 1)

            cmdUpdate.Focus()
            KeyAscii = 0
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub mth_name_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mth_name.Leave
        mth_name.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub mth_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mth_num.Enter
        Call ets_set_selected()
    End Sub

    Private Sub mth_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mth_num.Leave
        mth_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub prt_unposted_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prt_unposted.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glunpost.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Form.ActiveForm.ActiveControl.BackColor = Color.Aqua '(RGB(0, 255, 255))
    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            valid_Date = "N"
            senddate = etsdate(txtfields(CShort(Index)).Text, valid_Date)
            If senddate = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                txtfields(Index).Text = CDate(senddate).ToShortDateString
            End If

            Select Case Index
                Case 0
                    'fill in the month
                    'this is for  fiscal month calculation July - June
                    num = Month(CDate(senddate))

                    mth_name.Text = Mid("JAN,FEB,MAR,APR,MAY,JUN,JUL,AUG,SEP,OCT,NOV,DEC,", 1 + 4 * (num - 1), 3)
                    mth_name.Text = VB.Left(UCase(mth_name.Text), 3)
                    Response = InStr("JUL,AUG,SEP,OCT,NOV,DEC,JAN,FEB,MAR,APR,MAY,JUN,", mth_name.Text)

                    If Response = 0 Then
                        MsgBox("Invalid Month")
                        GoTo EventExitSub
                    End If
                    mth_num.Text = CStr(Int(Response / 4) + 1)
                Case 1
                    If DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(txtfields(CShort(Index - 1)).Text), CDate(txtfields(Index).Text)) > 31 Then
                        MsgBox("Date range too large")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

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
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

End Class