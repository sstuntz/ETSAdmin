Option Strict On
Option Explicit On

Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.Compatibility
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Globalization

Public Class apalloc
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "apalloc"
    Public frmWhereClause As String = ""
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String

    Dim temp_array(50, 2) As String
    Public max_items As Short
    Public AllocName As String

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        in_factor.Text = ""
        in_loc.Text = ""
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub apalloc_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ETS.Common.Module1.ctrform(Me)
        AllocName = selected_lookup_num
        Select Case entry_type
            Case "ADD"
                _txtfields_0.Enabled = True
                _txtfields_1.Enabled = True  'lhw
                _txtfields_0.Focus()
                _txtfields_0.Text = ""
                _txtfields_1.Text = ""
            Case "EDIT"
                _txtfields_0.Enabled = False     'lhw
                _txtfields_1.Enabled = False    'lhw
                _txtfields_0.Text = selected_lookup_num
                _txtfields_1.Text = selected_lookup_desc
                in_loc.Focus()
        End Select

        Call rebuild_grid()
        Save.Enabled = False
        SaveEntry.Enabled = False
        _txtfields_0.Select()

    End Sub

    Private Sub rebuild_grid()
        Dim sql As String = "select acct_num, factor from apalloc "
        sql = sql & " where allocname = '" & AllocName & "' order by acct_num "
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False

        tot_amt = CDec(total_factors())

        If tot_amt = 1 Then
            Save.Enabled = True
        Else
            Save.Enabled = False
        End If
        tot_alloc.Text = CStr(FormatPercent(total_factors(), 3))

    End Sub

    Private Function total_factors() As Double
        Dim tot As Double = 0
        Dim i As Integer
        For i = 0 To DataGridView1.RowCount - 1
            tot = CDbl(DataGridView1.Rows(i).Cells("Factor").Value) + tot
        Next
        Return tot

    End Function

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            in_loc.Text = DataGridView1.Item("acctnum", e.RowIndex).Value.ToString
            in_factor.Text = DataGridView1.Item("factor", e.RowIndex).Value.ToString
            entry_type = "EDIT"
        End If
    End Sub

    Private Sub in_factor_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles in_factor.Enter
        Call ets_set_selected()

    End Sub

    Private Sub in_factor_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles in_factor.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))

        If KeyAscii = 13 Or KeyAscii = 9 Then
            SaveEntry.Enabled = True

            If Val(in_factor.Text) > 1 Then
                MsgBox("Allocation must be less than 1.")
                GoTo EventExitSub
            End If
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If

        SaveEntry.Focus()

    End Sub

    Private Sub in_factor_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles in_factor.Leave
        in_factor.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub in_loc_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles in_loc.Enter
        Call ets_set_selected()
    End Sub

    Private Sub in_loc_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles in_loc.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))

        If KeyAscii = 13 Or KeyAscii = 9 Then
            'check for valid acct num
            saved_function_Type = function_type
            function_type = "LOOKUP_ONLY"

            valid_acct = "N"
            sendacct = etsacctnum_chk(in_loc.Text)
            sendacct = sendacct.Substring(0, 10)
            function_type = saved_function_Type

            If sendacct = "N" Then
                MsgBox("Not a valid account number.")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                in_loc.Text = sendacct.Substring(0, 10)

            End If
            'check array first to see if it is an edit

            Dim rownum As Integer
            For rownum = 0 To DataGridView1.RowCount - 1
                If DataGridView1.Rows(rownum).Cells("acctnum").Value.ToString = sendacct Then
                    MsgBox("This Account number already in this allocation. Will treat as an Edit.")
                    DataGridView1.CurrentCell = DataGridView1.Rows(rownum).Cells(0)
                    in_factor.Text = DataGridView1.Rows(rownum).Cells("factor").Value.ToString
                    in_factor.Focus()
                    KeyAscii = 0
                    GoTo EventExitSub
                End If
            Next

            in_factor.Focus()
            KeyAscii = 0

        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub in_loc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles in_loc.Leave
        in_loc.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub Nextloc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles nextloc.Click
        in_factor.Text = ""
        in_loc.Text = ""
        in_loc.Focus()
        KeyAscii = 0

        entry_type = "ADD"
    End Sub

    Private Sub Save_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Save.Click

        'remove old entry before adding the changed one
        sqlstmnt = "Delete  from apalloc where allocname = '" & AllocName & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)
        Dim acct_split As String()

        For rownum = 0 To DataGridView1.RowCount - 1
            acct_split = DataGridView1.Rows(rownum).Cells("acctnum").Value.ToString.Split(CChar("-"))
            sqlstmnt = "insert into apalloc values ('" & txtfields(0).Text & "', '" & DataGridView1.Rows(rownum).Cells("acctnum").Value.ToString & "', '" & acct_split(0) & "', '" & acct_split(1) & "', '" & acct_split(2) & "', '" & txtfields(1).Text & "', '" & DataGridView1.Rows(rownum).Cells("factor").Value.ToString & "' , 0 , 1, 1 "
            sqlstmnt = sqlstmnt & ")"
            ETSSQL.ExecuteSQL(sqlstmnt)
        Next
        in_factor.Text = ""
        in_loc.Text = ""
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
        If Index = 0 And entry_type = "ADD" And Len(Trim(txtfields(0).Text)) = 0 Then
            txtfields(0).Text = InputBox("Enter name of allocation.")
        End If

    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))

        If KeyAscii = 13 Or KeyAscii = 9 Then
            Select Case Index
                Case 0
                    AllocName = txtfields(Index).Text

                Case 1
                    If txtfields(1).Text = "" Then
                        MsgBox("A description is required.")
                        GoTo EventExitSub
                    End If
            End Select
            System.Windows.Forms.SendKeys.Send("{TAB}")
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

    Private Sub SaveEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveEntry.Click

        Select Case entry_type
            Case "ADD"
                Dim acct_split As String() = in_loc.Text.Split(CChar("-"))
                sqlstmnt = "insert into apalloc values ('" & txtfields(0).Text & "', '" & in_loc.Text & "', '" & acct_split(0) & "', '" & acct_split(1) & "', '" & acct_split(2) & "', '" & txtfields(1).Text & "', '" & in_factor.Text & "' , 0 , 1, 1 "
                sqlstmnt = sqlstmnt & ")"
                ETSSQL.ExecuteSQL(sqlstmnt)
            Case "EDIT"
                Dim acct_split As String() = in_loc.Text.Split(CChar("-"))
                sqlstmnt = "update apalloc set acct_num = '" & in_loc.Text & "', acct_only = '" & acct_split(0) & "', acct_pgm ='" & acct_split(1) & "', acct_dpt ='" & acct_split(2) & "', factor ='" & in_factor.Text & "' "
                sqlstmnt = sqlstmnt & " where acct_num = '" & in_loc.Text & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
        End Select
        SaveEntry.Enabled = False
        rebuild_grid()
    End Sub

End Class