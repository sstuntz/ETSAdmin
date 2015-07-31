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
Imports ETS

Public Class frmglalloc2
    Inherits System.Windows.Forms.Form

    Public AcctOnly As String
    Public AcctDpt As String
    Public AcctDesc As String
    Public AcctPgrm As String

    Public Sub rebuild_grid()
        Dim sqlstmnt As String = "SELECT     alloc.acct_num, alloc.acct_only, alloc.acct_pgm, alloc.acct_dpt, chacct.acct_desc, alloc.factor, alloc.amount, alloc.[table],  chacct.acct_pgm, chacct.acct_dpt"
        sqlstmnt = sqlstmnt & " from alloc INNER JOIN chacct ON alloc.acct_num = chacct.acct_num ORDER BY alloc.[table], chacct.acct_num"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sqlstmnt)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'fill the txtboxes
        'find the acct num and then cycle thru that row
        If e.RowIndex <> -1 Then
            selected_acct_num = DataGridView1.Item("Acct_num", e.RowIndex).Value.ToString
            selectedcell = True
            txtfields(0).Text = DataGridView1.Item("Acct_num", e.RowIndex).Value.ToString
            txtfields(2).Text = DataGridView1.Item("Acct_desc", e.RowIndex).Value.ToString
            txtfields(1).Text = DataGridView1.Item("factor", e.RowIndex).Value.ToString
            txtfields(3).Text = DataGridView1.Item("table", e.RowIndex).Value.ToString
            AcctOnly = DataGridView1.Item("acct_only", e.RowIndex).Value.ToString
            AcctDpt = DataGridView1.Item("acct_dpt", e.RowIndex).Value.ToString
            AcctPgrm = DataGridView1.Item("acct_pgm", e.RowIndex).Value.ToString
            txtfields(0).Enabled = False
            entry_type = "EDIT"
        End If


    End Sub

    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click

        txtfields(0).Enabled = True
        txtfields(0).Focus()

        'this will blank the fields when you click on Add button
        txtfields(0).Text = ""
        txtfields(1).Text = CStr(0)
        txtfields(2).Text = ""
        txtfields(3).Text = ""

        entry_type = "ADD"
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cancel.Click
        'blank the variables
        txtfields(0).Text = ""
        txtfields(1).Text = CStr(0)
        txtfields(2).Text = ""
        txtfields(3).Text = ""
        fac_tot.Text = ""

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Update1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Update1.Click

        If entry_type = "ADD" Then
            AcctOnly = _txtfields_0.Text.Substring(0, 4)
            AcctPgrm = _txtfields_0.Text.Substring(5, 2)
            AcctDpt = _txtfields_0.Text.Substring(8, 2)
            sqlstmnt = "insert into alloc values ('" & _txtfields_0.Text & "','" & AcctOnly & "','" & AcctPgrm & "','" & AcctDpt & "','" & _txtfields_2.Text & "','" & _txtfields_1.Text & "', 0 ,'" & _txtfields_3.Text & "')"
            ETSSQL.ExecuteSQL(sqlstmnt)
        Else
            sqlstmnt = "update alloc set acct_num = '" & _txtfields_0.Text & "' , acct_only = '" & AcctOnly
            sqlstmnt = sqlstmnt & "' , factor = '" & _txtfields_1.Text & "' , acct_pgm   = '" & AcctPgrm
            sqlstmnt = sqlstmnt & "' , [table] = '" & _txtfields_3.Text & "' , acct_dpt   = '" & AcctDpt
            sqlstmnt = sqlstmnt & "' where acct_num = '" & _txtfields_0.Text & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)
        End If

        txtfields(0).Enabled = True
        Dim tot As Decimal = GLMod.GetTotalFactor()

        If tot <> 0 Then
            MsgBox("The Allocation Table does not balance to zero(0)")
        End If
        fac_tot.Text = CStr(tot)

        Delete.Enabled = True
        addacct.Enabled = True

        'this will blank the fields when you click on Add button
        txtfields(0).Text = ""
        txtfields(1).Text = CStr(0)
        txtfields(2).Text = ""
        txtfields(3).Text = ""

        Call rebuild_grid()

    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glalloc.rpt" '
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Delete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Delete.Click

        If selectedcell = True Then

            Response = MsgBox("Are you sure that you want to DELETE this Record?", MsgBoxStyle.YesNo)
            If Response = vbNo Then
                Exit Sub
            End If

            sqlstmnt = "delete from alloc where acct_num = '" & selected_acct_num & "'and factor = '" & txtfields(1).Text & "' and [table] = '" & txtfields(3).Text & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)
            txtfields(0).Text = ""
            txtfields(1).Text = CStr(0)
            txtfields(2).Text = ""
            txtfields(3).Text = ""
        End If

        Update1.Enabled = False
        addacct.Enabled = True
        Call rebuild_grid()

        Dim tot As Decimal = GLMod.GetTotalFactor()

        If tot <> 0 Then
            MsgBox("The Allocation Table does not balance to zero(0)")
        End If
        fac_tot.Text = CStr(tot)

    End Sub

    Private Sub frmglalloc2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        Call rebuild_grid()

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            Select Case Index
                Case 0
                    If entry_type = "ADD" Then
                        'make sure not a dup number
                        If ValidateDatumYN("alloc", "acct_num", txtfields(0).Text) = "Y" Then
                            MsgBox("Account number has been used. Please enter a different number.")
                            Exit Sub
                        End If
                    End If
                    'make sure valid acct numb
                    If txtfields(0).Text.Length <> 0 Then
                        If checkYN("chacct", "acct_num", txtfields(0).Text) = "N" Then
                            MsgBox("Not a valid account")
                            Exit Sub
                        End If
                    End If

                    Dim acctnum As String
                    acctnum = etsacctnum_chk(txtfields(0).Text)
                    If acctnum.Substring(0, 0) = "N" Then
                        MsgBox("Not a valid account number.")
                        GoTo EventExitSub
                    End If
                    Dim anums = acctnum.Split(CChar("**"))
                    txtfields(0).Text = anums(0)
                    txtfields(2).Text = anums(2)
                    txtfields(2).Enabled = False
                Case 1
                    If Not IsNumeric(txtfields(Index).Text) Then
                        MsgBox("Please enter a number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    txtfields(Index).Text = VB6.Format(txtfields(Index).Text, ".###0")
                Case 3
                    Update1.Enabled = True
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