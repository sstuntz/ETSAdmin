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

Public Class apckrcon_frm1
    Inherits System.Windows.Forms.Form
    Public rowvalue, colvalue As Object
    Public selected_chk_num As String
    Public PaymentRowData As List(Of PaymentData)

    Private Sub rebuild_grid()
        Dim sql As String = "select chk_num, dt_clear, net_Amt, screen_nam from payment where dt_Clear = '" & recon_date.Text & "'"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        selected_lookup_num = ""
        Select Case SelectedIndex
            Case 0
                On Error Resume Next
                DataGridView1.Rows(0).Selected = False
                SelectedIndex = 1
                On Error GoTo 0
            Case Is > DataGridView1.Rows.Count
                SelectedIndex = 1
            Case Else
                DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
                ' DataGridView1.Rows(SelectedIndex).Selected = True
                'DataGridView1.Rows(SelectedIndex).Cells(0).Selected = True
                DataGridView1.PerformLayout()
        End Select


        DataGridView1.AutoResizeColumns()
        Dim totamt As Double = 0
        Dim i As Integer
        tot_cks.Text = ""

        For i = 0 To DataGridView1.RowCount - 1
            totamt = CDbl(DataGridView1.Rows(i).Cells("net_amt").Value) + totamt
            tot_cks.Text = CStr(Val(tot_cks.Text) + 1)
        Next

        tot.Text = Format(totamt, "###,###.00") '

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("chk_num", e.RowIndex).Value.ToString
            selected_lookup_desc = DataGridView1.Item("dt_clear", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index
    End Sub

    Private Sub checknum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles checknum.Enter
        Call ets_set_selected()
    End Sub

    Private Sub checknum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles checknum.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))

        'check for valid check number
        'move the recon date into the record entered
        'and then clear box for new entry

        If KeyAscii = 13 Or KeyAscii = 9 Then
            valid_check = "N"
            'get the payment record.
            valid_check = ValidateDatumYN("payment", "chk_num", checknum.Text)
            If valid_check = "N" Then
                MsgBox("This check number is not valid.  Please enter another one.")
                Exit Sub
            End If
            sqlstmnt = "Select * from payment where chk_num = '" & checknum.Text & "'"
            PaymentRowData = ETSSQL.GetPaymentData(sqlstmnt)
            If PaymentRowData.Item(0).dflag = "Y" Then
                MsgBox("Check Previously Deleted")
                Call ets_set_selected()
                Exit Sub
            End If
            'check if already cleared
            'If checkset.Fields("dt_clear") > CVDate("01/01/1901") Then
            '         MsgBox "Check# already Reconciled. "


            'if OK then display the name and amount
            Text1.Text = PaymentRowData.Item(0).ScreenNam
            Text2.Text = PaymentRowData.Item(0).NetAmt.ToString



            Response = MsgBox("Is this the right check?", vbYesNo)
            If Response = 7 Then
                Text1.Text = ""
                Text2.Text = ""
                '    checknum = ""
                Call ets_set_selected()
                checknum.Focus()
                Exit Sub
            Else
                sqlstmnt = "update payment set dt_clear = '" & recon_date.Text & "' , recon = 'Y' where chk_num = " & checknum.Text
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If
            Text1.Text = ""
            Text2.Text = ""


        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub checknum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles checknum.Leave
        Call ets_de_selected()
        checknum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub OutCks_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OutCks.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "apckout.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Private Sub CmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CMdExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub finished_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles finished.Click

        Call rebuild_grid()
        proof.Focus()

    End Sub

    Private Sub apckrcon_frm1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub proof_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles proof.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "apckrcn.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub recon_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles recon_date.Enter
        Call ets_set_selected()
        checknum.Text = ""
    End Sub

    Private Sub recon_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles recon_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = recon_date.Text
            If etsdate(senddate, "") = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                recon_date.Text = etsdate(senddate, "")
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
                sqlstmnt = "update rpthead set beg_date = '" & recon_date.Text & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If

            checknum.Focus()
        End If
eventexitsub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub recon_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles recon_date.Leave
        recon_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub reverse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles reverse.Click

        '    Grid1.Col = 0
        '    selected_chk_num = Grid1.Text
        '
        '    If Not IsNumeric(selected_chk_num) Then
        '    MsgBox "Nothing selected"
        '    Exit Sub
        '    End If
        '
        '
        '  If selected_chk_num = "" Then
        '    MsgBox "Nothing selected"
        '    Exit Sub
        '    End If
        '
        '     Data1.RecordSource = "select * from payment where chk_num = " & Val(selected_chk_num)
        '     Data1.Refresh
        '    If Data1.Recordset.RecordCount > 0 Then
        '    Do While Not Data1.Recordset.EOF        'added do loop 11/14/05 lhw
        '        Data1.Recordset.edit
        '        Data1.Recordset.Fields("dt_Clear") = CVDate("1/1/1901")
        '        Data1.Recordset.Fields("recon") = "N"
        '        Data1.Recordset.Update
        '        Data1.Recordset.MoveNext
        '    Loop
        '    End If

        Call rebuild_grid()

        proof.Focus()

    End Sub

End Class