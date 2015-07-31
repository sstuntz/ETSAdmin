Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports Valid_YN
Public Class glbud
    Inherits System.Windows.Forms.Form

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        sqlstmnt = "update next_bud set bud_yr = '" & txtFields(2).Text & "' where acct_num = '" & txtFields(0).Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        txtFields(0).Focus()
        txtFields(0).Text = ""
        txtFields(1).Text = ""
        txtFields(2).Text = ""
    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glbud_opt.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        MsgBox("This will re-calculate the spread for ALL accounts each time!!!. This will write over existing data!")
        Response = MsgBox("Do you want to Spread the DATA???. Select YES to continue ", MsgBoxStyle.YesNo)
        'Dim total_amt As Decimal
        Dim bud_tot As Decimal
        Dim bud_amt As Decimal
        If Response = MsgBoxResult.Yes Then
            bud_tot = 0
            bud_amt = 0
            tot_amt = 0
            sqlstmnt = "update nex_bud set bud_m1 = bud_yr/12,  bud_m2 = bud_yr/12, bud_m3 = bud_yr/12, bud_m4 = bud_yr/12, bud_m5 = bud_yr/12, bud_m6 = bud_yr/12, bud_m7 = bud_yr/12, bud_m8 = bud_yr/12, bud_m9 = bud_yr/12, bud_m10 = bud_yr/12, bud_m11 = bud_yr/12, bud_m12 = bud_yr/12"
            ETSSQL.ExecuteSQL(sqlstmnt)
            MsgBox("Spread has been completed.")
        End If
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        MsgBox("Be sure that you only do this once. This will write over existing data!")

        Response = MsgBox("This will move data from next_bud to Current Chart of Accounts. Select YES to continue ", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.Yes Then
            If Err.Number = 3021 Then
                MsgBox("Next_Bud does not exist..Call ETS for Help!.")
                Response = 1
                Exit Sub
            End If

            sqlstmnt = "update chacct set bud_m1 = next_bud.bud_m1,  bud_m2 = next_bud.bud_m2, bud_m3 = next_bud.bud_m3, bud_m4 = next_bud.bud_m4, bud_m5 = next_bud.bud_m5, bud_m6 = next_bud.bud_m6, bud_m7 = next_bud.bud_m7, bud_m8 = next_bud.bud_m8, bud_m9 = next_bud.bud_m9, bud_m10 = next_bud.bud_m10, bud_m11 = next_bud.bud_m11, bud_m12 = next_bud.bud_m12"
            sqlstmnt = sqlstmnt & " from nex_bud inner join chacct on next_bud.acct_num = chacct.acct_num"
            ETSSQL.ExecuteSQL(sqlstmnt)
            MsgBox("Update has been completed.")
        End If
    End Sub

    Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
        Response = MsgBox("This will create a next_bu and zero all budget data in next_bud, continue?", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.Yes Then
            sqlstmnt = "Delete from next_bud"
            ETSSQL.ExecuteSQL(sqlstmnt)
            sqlstmnt = " insert into next_bud select * from chacct"
            ETSSQL.ExecuteSQL(sqlstmnt)
            sqlstmnt = "update next_bud set bud_m1 =0, bud_m2 =0, bud_m3 =0, bud_m4 =0, bud_m5 =0, bud_m6 =0, bud_m7 =0, bud_m8 =0, bud_m9 =0, bud_m10 =0, bud_m11 =0, bud_m12 =0, bud_yr =0, bud_ytd =0 "
            ETSSQL.ExecuteSQL(sqlstmnt)
            MsgBox("Next bud data has been zeroed.")
        Else
            MsgBox("Next Budget Data data NOT zeroed.")
        End If
    End Sub

    Private Sub frmglbud_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        txtFields(0).Text = ""
        txtFields(1).Text = ""
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
                Case 0      'acct num
                    'lookup acct num (in next bud) and fill desc
                    Dim acctnum As String
                    acctnum = etsacctnum_chk(txtFields(0).Text)
                    If acctnum.Substring(0, 0) = "N" Then
                        MsgBox("This account does not exist.")
                        Exit Sub
                    End If
                    Dim anums = acctnum.Split(CChar("**"))
                    txtFields(0).Text = anums(0)
                    txtFields(1).Text = anums(2)
                Case 2
                    If Len(txtFields(Index).Text) = 0 Then
                        txtFields(Index).Text = CStr(0)
                    End If
                    txtFields(Index).Text = VB6.Format(txtFields(Index).Text, "###0.00;(###0.00)")
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

End Class