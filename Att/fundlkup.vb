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
Imports System.Globalization


Public Class fundnumlookup
    Inherits System.Windows.Forms.Form

    Dim SelectedIndex As Integer

    Public base_lookup As String

    Private Sub rebuild_grid()
        base_lookup = "SELECT cc_fund.sort_name, cc_fund.name_key , cc_fund.contract_key, cc_fund.bill_type, cc_cont.cont_desc, cc_fund.closed FROM cc_fund LEFT JOIN cc_cont ON cc_fund.contract_key = cc_cont.contract_key"

        If function_type = "CLD" Then
            Me.Text = "Funding - Closed Sources "
            sqlstmnt = base_lookup & " where closed = '" & "Y" & "' order by cc_fund.sort_name"
            addacct.Enabled = False
            Accept.Enabled = False
            set_closed_flag.Text = "Click here to re-open this funding source"
        Else
            Me.Text = "Funding - Open Sources "
            sqlstmnt = base_lookup & " where closed = '" & "N" & "' order by cc_fund.sort_name"
        End If

        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sqlstmnt)

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

        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing

        If SelectedIndex = 0 Then DataGridView1.Rows(SelectedIndex).Selected = False

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_sort_name = DataGridView1.Item("sort_name", e.RowIndex).Value.ToString
            selected_name_key = DataGridView1.Item("name_key", e.RowIndex).Value.ToString
            selected_contract_key = DataGridView1.Item("contract_key", e.RowIndex).Value.ToString
            selected_bill_type = DataGridView1.Item("bill_type", e.RowIndex).Value.ToString
            selected_b_num = selected_name_key & selected_contract_key
            selected_lookup_num = selected_b_num
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub

    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click

        entry_type = "ADD"

        frmcc_fund.ShowDialog()

        Call rebuild_grid()

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Dispose()
    End Sub


    Private Sub set_closed_flag_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles set_closed_flag.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        saved_function_Type = function_type


        If function_type <> "CLD" Then
            Response = MsgBox("Are you sure you want to close this funding source", MsgBoxStyle.YesNo)
        Else
            Response = MsgBox("Are you sure you want to re-open this funding source", MsgBoxStyle.YesNo)
        End If

        If Response = MsgBoxResult.Yes Then
            'select the record, edit and update it
            sqlstmnt = base_lookup & " WHERE contract_key = '" & selected_contract_key & "' AND cc_fund.name_key = '" & selected_name_key & "'"

            If function_type <> "CLD" Then
                sqlstmnt = " update cc_fund set closed = 'Y'  WHERE contract_key = '" & selected_contract_key & "' AND cc_fund.name_key = '" & selected_name_key & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
            Else
                sqlstmnt = " update cc_fund set closed = 'N'  WHERE contract_key = '" & selected_contract_key & "' AND cc_fund.name_key = '" & selected_name_key & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If
        Else
            Exit Sub
        End If

        Call rebuild_grid()

    End Sub

    Private Sub fundnumlookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        DataGridView1.Columns.Add("sort_name", "Name")
        DataGridView1.Columns.Item(0).DataPropertyName = "sort_name"
        DataGridView1.Columns.Add("name_key", "Name Key")
        DataGridView1.Columns.Item(1).DataPropertyName = "name_key"
        DataGridView1.Columns.Add("contract_key", "Contract")
        DataGridView1.Columns.Item(2).DataPropertyName = "contract_key"
        DataGridView1.Columns.Add("bill_type", "Bill Type")
        DataGridView1.Columns.Item(3).DataPropertyName = "bill_type"
        DataGridView1.Columns.Add("cont_Desc", "Description")
        DataGridView1.Columns.Item(4).DataPropertyName = "cont_desc"
        DataGridView1.Columns.Add("closed", "closed")
        DataGridView1.Columns.Item(5).DataPropertyName = "closed"
        DataGridView1.Columns.Item(5).Visible = False
        ctrform(Me)
        selectedcell = False

        rebuild_grid()

        selectedcell = False

        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If

        If function_type = "SPEC_BILL" Then
            addacct.Enabled = False
            Edit.Enabled = False
            Accept.Enabled = True
        End If

        Call rebuild_grid()

        txtinname.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        txtinname.Text = ""
        txtinname.Focus()
        txtinname.SelectAll()

        Me.DataGridView1.ClearSelection()

    End Sub

    Private Sub txtinname_TextChanged(ByVal eventSender As System.Object, ByVal e As System.EventArgs) Handles txtinname.TextChanged
        Dim rownum As Integer
        Dim startletter As String
        txtinname.BackColor = Color.White
        For rownum = 0 To DataGridView1.RowCount - 1
            startletter = UCase(txtinname.Text) '& e.KeyCode.ToString
            If DataGridView1.Rows(rownum).Cells("sort_name").Value.ToString.StartsWith(startletter, True, CultureInfo.InvariantCulture) Then
                DataGridView1.Rows(rownum).Cells(0).Selected = False
                DataGridView1.CurrentCell = DataGridView1.Rows(rownum).Cells(0)
                DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.CurrentCell.RowIndex
                Exit For
            End If
        Next

    End Sub

    Private Sub txtinname_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtinname.Enter
        txtinname.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        txtinname.SelectionStart = 0
        txtinname.SelectionLength = Len(txtinname.Text)
    End Sub

    Private Sub Txtinname_KeyDown(ByVal eventsender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtinname.KeyDown
        Dim rownum As Integer
        Dim startletter As String
        If KeyAscii = 13 Then
            txtinname.Focus()
            Exit Sub
        End If
        For rownum = 0 To DataGridView1.RowCount - 1
            startletter = UCase(txtinname.Text) & e.KeyCode.ToString
            If DataGridView1.Rows(rownum).Cells("sort_name").Value.ToString.StartsWith(startletter, True, CultureInfo.InvariantCulture) Then
                DataGridView1.Rows(rownum).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(rownum).Cells(0)
                Exit For
            End If
        Next
    End Sub

    Private Sub txtinname_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtinname.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))

        If KeyAscii = 13 Then
            txtinname.Focus()
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("name_key", DataGridView1.CurrentRow.Index).Value.ToString
            selected_sort_name = DataGridView1.Item("sort_name", DataGridView1.CurrentRow.Index).Value.ToString
            '  selected_screen_nam = DataGridView1.Item("screen_nam", DataGridView1.CurrentRow.Index).Value.ToString
            selected_name_key = DataGridView1.Item("name_key", DataGridView1.CurrentRow.Index).Value.ToString

            SelectedIndex = DataGridView1.CurrentRow.Index
        End If
    End Sub

    Private Sub txtinname_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtinname.Leave
        txtinname.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    '    Private Sub txtinname_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtinname.TextChanged
    '        On Error Resume Next

    '        List1.SelectedIndex = sendmessage(List1.Handle.ToInt32, lb_findstring, -1, CStr(txtinname.Text)) + 6
    '        If Err.Number = 380 Then
    '            List1.SelectedIndex = sendmessage(List1.Handle.ToInt32, lb_findstring, -1, CStr(txtinname.Text))
    '            List1.SelectedIndex = List1.SelectedIndex
    '            Exit Sub
    '        End If

    '        List1.SelectedIndex = List1.SelectedIndex - 6
    '    End Sub

    '	Private Sub txtinname_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtinname.Enter
    '		txtinname.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
    '		txtinname.SelectionStart = 0
    '		txtinname.SelectionLength = Len(txtinname.Text)
    '		List1.SelectedIndex = -1
    '	End Sub

    '	Private Sub txtinname_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtinname.KeyPress
    '		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
    '		If KeyAscii = 13 Then
    '			If Len(txtinname.Text) = 0 Then
    '				MsgBox("Nothing entered")
    '				GoTo EventExitSub
    '			End If

    '			'namechk$ = txtinname.Text

    '			System.Windows.Forms.SendKeys.Send("{tab}")
    '			KeyAscii = 0
    '		End If
    'EventExitSub: 
    '		eventArgs.KeyChar = Chr(KeyAscii)
    '		If KeyAscii = 0 Then
    '			eventArgs.Handled = True
    '		End If
    '	End Sub


    Private Sub edit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        saved_function_Type = function_type
        entry_type = "EDIT"

        Select Case selected_bill_type
            Case "100"
                frmbt_100.ShowDialog()
            Case "120"
                frmbt_120.ShowDialog()
            Case "125"
                frmbt_125.ShowDialog()
            Case "140"
                frmbt_140.ShowDialog()
            Case "160"
                frmbt_160.ShowDialog()
            Case "170"
                frmbt_170.ShowDialog()
                Exit Sub
            Case Else
                MsgBox("No such bill type as " & selected_bill_type)
        End Select


        function_type = saved_function_Type

        Call rebuild_grid()
    End Sub
End Class