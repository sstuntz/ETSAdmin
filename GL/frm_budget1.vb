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

Public Class frm_budget1
    Inherits System.Windows.Forms.Form

    Dim BudgetSource As String
    Public BudgetRowData As List(Of BudgetData)

    Public Sub rebuild_grid()

        Dim sql As String = BudgetSource '"select acct_num, acct_Desc, bud_yr from chacct"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)

        selectedcell = False

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selected_acct_num = ""
            'fill the txtboxes
            'find the acct num and then cycle thru that row
            selected_acct_num = DataGridView1.Item("Acct_num", e.RowIndex).Value.ToString
            selectedcell = True
            ' Exit Sub
        End If

        For Each BudData In BudgetRowData
            If BudData.AcctNum = selected_acct_num Then
                _txtfields_12.Text = String.Format("{0:#.00}", DataGridView1.Item("bud_yr", e.RowIndex).Value)
                _txtfields_0.Text = String.Format("{0:#.00}", BudData.Mth1)
                _txtfields_1.Text = String.Format("{0:#.00}", BudData.Mth2)
                txtfields(2).Text = String.Format("{0:#.00}", BudData.Mth3)
                txtfields(3).Text = String.Format("{0:#.00}", BudData.Mth4)
                txtfields(4).Text = String.Format("{0:#.00}", BudData.Mth5)
                txtfields(5).Text = String.Format("{0:#.00}", BudData.Mth6)
                txtfields(6).Text = String.Format("{0:#.00}", BudData.Mth7)
                txtfields(7).Text = String.Format("{0:#.00}", BudData.Mth8)
                txtfields(8).Text = String.Format("{0:#.00}", BudData.Mth9)
                txtfields(9).Text = String.Format("{0:#.00}", BudData.Mth10)
                txtfields(10).Text = String.Format("{0:#.00}", BudData.Mth11)
                txtfields(11).Text = String.Format("{0:#.00}", BudData.Mth12)
            End If
        Next
        _txtfields_12.Focus()

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Dim ind As Short
        For ind = 0 To 12
            txtfields(ind).Text = ""
        Next
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Balance_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Balance.Click
        Dim amt_total As Decimal
        Dim n As Short
        amt_total = 0
        For n = 0 To 11
            amt_total = CDec(amt_total + Val(txtfields(n).Text))
        Next n
        Text1.Text = CStr(Val(txtfields(12).Text) - amt_total)

        If Val(txtfields(12).Text) - amt_total = 0 Then
            amt_total = 0
            update_Renamed.Focus()
        Else : txtfields(0).Focus() 'if not zero on bud_m1
        End If
        Exit Sub
    End Sub

    Private Sub Spread_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Spread.Click
        Dim n As Short
        tot_amt = 0
        For n = 0 To 11
            txtfields(n).Text = String.Format("{0:#.00}", (Val(txtfields(12).Text) / 12))
        Next n
        tot_amt = 0
        For n = 0 To 11
            tot_amt = tot_amt + CDec(Val(txtfields(n).Text))
        Next

        Text1.Text = VB6.Format(Val(txtfields(12).Text) - tot_amt, "FIXED")

    End Sub

    Private Sub PrintProof_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PrintProof.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glbud.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub refresh1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Refresh1.Click
        selected_acct_num = ""
        Select Case selected_recordsource
            Case "Current"
                Me.Text = "General Ledger Current Year Budget Entry"
                BudgetSource = "select * from chacct order by acct_num"
            Case "Next"
                Me.Text = "General Ledger For Adding/Editing NEXY FISCAL Years Budgets-(Next_Bud)"
                BudgetSource = "select * from next_bud order by acct_num"
        End Select
        BudgetRowData = ETSSQL.GetBudgetData(BudgetSource)
        Call rebuild_grid()
    End Sub

    Private Sub frm_budget1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Select Case selected_recordsource
            Case "Current"
                Me.Text = "General Ledger Current Year Budget Entry"
                BudgetSource = "select * from chacct order by acct_num"
            Case "Next"
                Me.Text = "General Ledger For Adding/Editing NEXY FISCAL Years Budgets-(Next_Bud)"
                BudgetSource = "select * from next_bud order by acct_num"
        End Select
        BudgetRowData = ETSSQL.GetBudgetData(BudgetSource)
        Call rebuild_grid()
    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtfields_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtfields.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Select Case KeyCode
            Case CShort(System.Windows.Forms.Keys.F3)
                If Index < 11 Then
                    txtfields(CShort(Index + 1)).Text = txtfields(Index).Text
                    txtfields(CShort(Index + 1)).Text = VB6.Format(txtfields(CShort(Index + 1)).Text, "FIXED")
                    txtfields(Index).Text = VB6.Format(txtfields(Index).Text, "FIXED")
                    txtfields(CShort(Index + 1)).Focus()

                    If Index = 11 Then
                        txtfields(Index).Text = txtfields(CShort(Index - 1)).Text
                        txtfields(Index).Text = VB6.Format(txtfields(Index).Text, "FIXED")

                    End If

                End If
        End Select


    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Dim n As Short
        If KeyAscii = 13 Or KeyAscii = 9 Then
            Select Case Index
                Case 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
                    txtfields(Index).Text = VB6.Format(txtfields(Index).Text, "FIXED")
                    tot_amt = 0
                    For n = 0 To 11
                        tot_amt = CDec(tot_amt + Val(txtfields(n).Text))
                    Next
                    Text1.Text = VB6.Format(Val(txtfields(12).Text) - tot_amt, "FIXED")
                Case 13     'enter full 8 digits
                    If Len(Trim(txtfields(Index).Text)) <> 10 Then
                        MsgBox("Enter the account number with the dashes xxxx-xx-xx.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    BudgetSource = "select  * from chacct where acct_num = '" & Trim(txtfields(Index).Text) & "'" & " order by acct_num"
                    BudgetRowData = ETSSQL.GetBudgetData(BudgetSource)
                    Call rebuild_grid()
                    rebuild_grid()
                Case 14     'find first four digit of acct num
                    If Len(Trim(txtfields(Index).Text)) <> 4 Then
                        MsgBox("Enter the first 4 digits of the account number  'xxxx' ")
                        Call ets_set_selected()
                        Exit Sub
                    End If

                    BudgetSource = "select * from chacct where acct_only = '" & Trim(txtfields(Index).Text) & "'" & " order by acct_num"
                    BudgetRowData = ETSSQL.GetBudgetData(BudgetSource)
                    If BudgetRowData.Count = 0 Then
                        MsgBox("There are no accounts with these first 4 digits.")
                        Call ets_set_selected()
                        Exit Sub
                    End If
                    rebuild_grid()
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

    Private Sub update_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles update_Renamed.Click
        If Val(Text1.Text) <> 0 Then
            Response = MsgBox("You are not in Balance. Do you wish to update anyway? ", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
            If Response = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        'update the months and the full year budget

        sqlstmnt = "update chacct set bud_m1 = '" & txtfields(0).Text & "', "
        sqlstmnt = sqlstmnt & "  bud_m2 = '" & txtfields(1).Text & "', "
        sqlstmnt = sqlstmnt & "  bud_m3 = '" & txtfields(2).Text & "', "
        sqlstmnt = sqlstmnt & "  bud_m4 = '" & txtfields(3).Text & "', "
        sqlstmnt = sqlstmnt & "  bud_m5 = '" & txtfields(4).Text & "', "
        sqlstmnt = sqlstmnt & "  bud_m6 = '" & txtfields(5).Text & "', "
        sqlstmnt = sqlstmnt & "  bud_m7 = '" & txtfields(6).Text & "', "
        sqlstmnt = sqlstmnt & "  bud_m8 = '" & txtfields(7).Text & "', "
        sqlstmnt = sqlstmnt & "  bud_m9 = '" & txtfields(8).Text & "', "
        sqlstmnt = sqlstmnt & "  bud_m10 = '" & txtfields(9).Text & "', "
        sqlstmnt = sqlstmnt & "  bud_m11 = '" & txtfields(10).Text & "', "
        sqlstmnt = sqlstmnt & "  bud_m12 = '" & txtfields(11).Text & "', "
        sqlstmnt = sqlstmnt & "  bud_yr = '" & txtfields(12).Text & "' "
        sqlstmnt = sqlstmnt & " where acct_num = '" & selected_acct_num & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        Dim num As Short
        For num = 0 To 12
            txtfields(num).Text = ""
        Next

        Call rebuild_grid()

    End Sub

End Class