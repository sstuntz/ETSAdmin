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

Public Class frmglie
    Inherits System.Windows.Forms.Form

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Command1_Click()
        prtDestination = 1
        prtreportfilename = gl_report_path & "glbsheet.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Create_je_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Create_je.Click
        entry_type = "ADD"
        je_type = "REGULAR"
        glx_stand.ShowDialog()

    End Sub

    Private Sub frmglie_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

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

    Private Sub post_net_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles post_net.Click

        MsgBox("This will now post the J/E just printed.")

        sqlstmnt = sqlstmnt & "post <> 'Y' and void <> 'Y' and dflag <> 'Y' "
        sqlstmnt = sqlstmnt & " and encum_date = "
        sqlstmnt = sqlstmnt & Chr(35) & txtFields(1).Text & Chr(35) & " order by acct_num "

        If ETS.Common.Module1.CheckRecordCount(sqlstmnt) = 0 Then
            MsgBox("There is no journal entry  for this date.")
            Exit Sub
        End If

        'update flags
        sqlstmnt = " update yrgenled set post = 'Y', post_date = '" & Date.Today & "' "
        sqlstmnt = sqlstmnt & "post <> 'Y' and void <> 'Y' and dflag <> 'Y' "
        sqlstmnt = sqlstmnt & " and encum_date = "
        sqlstmnt = sqlstmnt & Chr(35) & txtFields(1).Text & Chr(35) & " "
        ETSSQL.ExecuteSQL(sqlstmnt)

        Dim mth As String
        mth = "cur_m" & mth_num.Text
        'get total for each acctnum at put into chacct

        'Update(chacct)
        'cur_m1 = derivedtbl_1.TotAmt
        'FROM         (SELECT     SUM(amount) AS TotAmt
        'FROM(yrgenled)
        '                       GROUP BY acct_num) AS derivedtbl_1 CROSS JOIN
        'chacct()

        sqlstmnt = "Update chacct "
        sqlstmnt = sqlstmnt & "SET " & mth & " = derivedtbl_1.TotAmt "
        sqlstmnt = sqlstmnt & " FROM (SELECT SUM(amount) AS TotAmt FROM yrgenled"
        sqlstmnt = sqlstmnt & " GROUP BY acct_num, void, dflag, post, encum_date) "
        sqlstmnt = sqlstmnt & " HAVING (post <> N'Y') AND (dflag <> N'Y') AND (void <> N'Y') "
        sqlstmnt = sqlstmnt & " and encum_date = " & Chr(35) & txtFields(1).Text & Chr(35) & " ) AS derivedtbl_1 CROSS JOIN chacct"
        ETSSQL.ExecuteSQL(sqlstmnt)

        'recalc the current year to date
        sqlstmnt = "update chacct set cur_ytd = cur_m1 + cur_m2 + cur_m3 + cur_m4 + cur_m5 + cur_m6 + cur_m7 + cur_m8 + cur_m9 + cur_m10 + cur_m11 + cur_m12"
        ETSSQL.ExecuteSQL(sqlstmnt)

        Reprint_bal.Focus()
        MsgBox("Net Excess/Loss J/E has been posted.")

    End Sub

    Private Sub Print_Bal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Print_Bal.Click
        prtDestination = 1
        prtreportfilename = gl_report_path & "glbsheet1.rpt"
        CrystalForm.ShowDialog()
        Create_je.Focus()
    End Sub

    Private Sub Print_JE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Print_JE.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glxprf.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Reprint_bal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Reprint_bal.Click
        prtDestination = 1
        prtreportfilename = gl_report_path & "glbsheet.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))

        If KeyAscii = 13 Then
            valid_Date = "N"
            senddate = txtfields(Index).Text
            Call etsdate(senddate, valid_Date)
            num = 0
            If valid_Date <> "N" Then
                txtFields(Index).Text = CStr(retdate)
                txtfields(Index).Text = CStr(CDate(txtfields(Index).Text))
                If Index = 1 Then

                    'fill in the month

                    num = Month(CDate(txtfields(Index).Text))

                    mth_name.Text = Mid("JAN,FEB,MAR,APR,MAY,JUN,JUL,AUG,SEP,OCT,NOV,DEC", 1 + 4 * (num - 1), 3)
                    mth_name.Focus()
                    mth_name.Text = VB.Left(UCase(mth_name.Text), 3)
                    Response = InStr("JUL,AUG,SEP,OCT,NOV,DEC,JAN,FEB,MAR,APR,MAY,JUN", mth_name.Text)

                    If Response = 0 Then
                        MsgBox("Invalid Month")
                        GoTo EventExitSub
                    End If
                    mth_num.Text = CStr(Int(Response / 4) + 1)


                End If
                ' SendKeys "{tab}"
                ' KeyAscii = 0
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

    Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

End Class