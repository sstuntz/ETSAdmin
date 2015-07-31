Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.Compatibility
Imports ETS.Common.Module1
Imports ps.common
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Globalization

Public Class frmnamechk

    Inherits System.Windows.Forms.Form
    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "nam_addr"
    Public frmWhereClause As String = ""
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String
    Public add_flag As Integer = 0

    Private Sub Add_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Add_Renamed.Click
        'on the add we repaint for the whole list if we were only
        'looking at part of the list
        SelectedIndex = 0
        entry_type = "ADD"

        If add_flag = 0 Then
            MsgBox("This is the short list. To make sure that the person has not been added previously we will now display the full list.")
            frmTableName = "nam_addr"
            add_flag = 1
            rebuild_grid()
            Exit Sub
        End If

        Dim frmnameaddr As New frmnameaddr
        frmnameaddr.ShowDialog()

        If entry_type <> "CANCEL" Then
            Select Case package_Type
                Case "AP"
                    Dim frmnam_vend As New frmnam_vend
                    frmnam_vend.ShowDialog()
                Case "AR"
                    Dim frmnam_cust As New frmnam_cust
                    frmnam_cust.ShowDialog()
                Case "GL"
                    Dim frmnam_bank As New frmnam_bank
                    frmnam_bank.ShowDialog()
                Case "EE"
                    ' Me.Close()
                    entry_type_ee = "EDIT"
                    Dim NameEE As New NameEE
                    NameEE.ShowDialog()
                  
                Case "EEHR"
                    Me.Close()
                    entry_type_ee = "EDIT"
                    Dim frmee1base As New BlankMenuForm
                    frmee1base.ShowDialog()
                Case "CT"
                Case "ATT", "AM"
                    Dim cc_base As New cc_base
                    cc_base.ShowDialog()
                Case "CC"
                    Dim namecc As New NameCC
                    NameCC.ShowDialog()
                Case "CCHR"
                    Dim ct_base As New BlankMenuForm
                    ct_base.ShowDialog()
                Case "AM"
                    Dim medccfrm As New BlankMenuForm
                    medccfrm.ShowDialog()
            End Select
        End If
        add_flag = 0    'reset the lookup back to original nor overriden in section above
        Call rebuild_grid()




    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Selectname.Enabled = False
        add_flag = 0
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edit.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        Dim frmnameaddr As New frmnameaddr
        frmnameaddr.ShowDialog()
        If entry_type <> "CANCEL" Then

            entry_type = "EDIT"

            Select Case package_Type
                Case "AP"
                    Dim frmnam_vend As New frmnam_vend
                    frmnam_vend.ShowDialog()
                Case "AR"
                    Dim frmnam_cust As New frmnam_cust
                    frmnam_cust.ShowDialog()
                Case "GL"
                    Dim frmnam_bank As New frmnam_bank
                    frmnam_bank.ShowDialog()
                Case "EE"
                    Me.Close()
                    entry_type_ee = "EDIT"
                    Dim NameEE As New NameEE
                    NameEE.ShowDialog()
                 Case "EEHR"
                    Me.Close()
                    entry_type_ee = "EDIT"
                    Dim frmee1base As New BlankMenuForm
                    frmee1base.ShowDialog()
                Case "CT"
                Case "ATT", "AM"
                    Dim cc_base As New cc_base
                    cc_base.ShowDialog()
                Case "CC"
                    Me.Hide()
                    NameCC.ShowDialog()
                Case "CCHR"
                    Dim ct_base As New BlankMenuForm
                    ct_base.ShowDialog()
                Case "AM"
                    Dim medccfrm As New BlankMenuForm
                    medccfrm.ShowDialog()
            End Select
        End If
        Call rebuild_grid()

        Me.Visible = True

        Me.BringToFront()

    End Sub

    Private Sub frmnamechk_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Normal     'added lhw 06/19/2012
        ctrform(Me)

        If function_type = "DATA_ENTRY" Then
            Selectname.Enabled = True
        End If

        If function_type = "LOOKUP_ONLY" Then
            Add_Renamed.Enabled = False
            edit.Enabled = False
            Selectname.Enabled = True
        End If

        If function_type = "VIEW" Then 'lhw 11/22/98
            Add_Renamed.Enabled = False
            edit.Enabled = True
            Selectname.Enabled = False
        End If

        Select Case package_Type

            Case "AP"
                sqlstmnt = "SELECT name_key, screen_nam, sort_name From nam_vend ORDER BY sort_name;"
                frmTableName = "nam_vend"
            Case "AR"
                sqlstmnt = "SELECT name_key, screen_nam, sort_name From nam_cust ORDER BY sort_name;"
                frmTableName = "nam_cust"
            Case "EE"
                sqlstmnt = "SELECT name_key, screen_nam,sort_name  From nam_ee ORDER BY sort_name;"
                frmTableName = "nam_ee"
            Case "EEHR"
                sqlstmnt = "SELECT name_key, screen_nam,sort_name  From ee_base ORDER BY sort_name;"
                frmTableName = "ee_base"
                If function_type = "VIEW" Then 'lhw 11/22/98
                    sqlstmnt = "SELECT name_key, screen_nam,sort_name  From nam_ee ORDER BY sort_name;"
                    frmTableName = "nam_ee"
                End If

            Case "CC"
                sqlstmnt = "SELECT name_key, screen_nam, sort_name From nam_cc ORDER BY sort_name;"
                frmTableName = "nam_cc"
            Case "CCHR"
                sqlstmnt = "SELECT name_key, screen_nam, sort_name From cct_base ORDER BY sort_name;"
                frmTableName = "cct_base"
            Case "GL"
                sqlstmnt = "SELECT bank_key, name_key, screen_nam, sort_name From nam_bank ORDER BY sort_name;"
                frmTableName = "nam_bank"
            Case "ATT", "AM"
                sqlstmnt = "SELECT name_key, screen_nam,sort_name From cc_base ORDER BY sort_name;"
                frmTableName = "cc_base"
            Case "TY"
                sqlstmnt = "SELECT name_key, screen_nam, sort_name From nam_addr ORDER BY sort_name;"
                frmTableName = "nam_addr"
            Case Else
                sqlstmnt = "SELECT name_key, screen_nam, sort_name From nam_addr ORDER BY sort_name;"
                frmTableName = "nam_addr"
        End Select

        Call rebuild_grid()

        txtinname.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        txtinname.Text = ""
        txtinname.Focus()
        txtinname.SelectAll()

        Me.DataGridView1.ClearSelection()
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill


    End Sub

    Private Sub Selectname_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Selectname.Click

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub txtinname_TextChanged(ByVal eventSender As System.Object, ByVal e As System.EventArgs) Handles txtinname.TextChanged
        Dim rownum As Integer
        Dim startletter As String
        txtinname.BackColor = Color.White
         For rownum = 0 To DataGridView1.RowCount - 1
            startletter = UCase(txtinname.Text) '& e.KeyCode.ToString
            If DataGridView1.Rows(rownum).Cells("sort_name").Value.ToString.StartsWith(startletter, True, CultureInfo.InvariantCulture) Then
                DataGridView1.Rows(rownum).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(rownum).Cells(0)
                SetSelectedRow()
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
            Selectname.Focus()
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
            Selectname.Focus()
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("name_key", DataGridView1.CurrentRow.Index).Value.ToString
            selected_sort_name = DataGridView1.Item("sort_name", DataGridView1.CurrentRow.Index).Value.ToString
            selected_screen_nam = DataGridView1.Item("screen_nam", DataGridView1.CurrentRow.Index).Value.ToString
            selected_name_key = DataGridView1.Item("name_key", DataGridView1.CurrentRow.Index).Value.ToString

            SelectedIndex = DataGridView1.CurrentRow.Index
        End If
    End Sub

    Private Sub txtinname_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtinname.Leave
        txtinname.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub rebuild_grid()

        Dim sql As String = "select sort_name, name_key, screen_nam from " & frmTableName & "  order by sort_name"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)

        If entry_type = "ADD" Then
            'find the selected index for the new acct in selected_acct_num
            For rownum = 0 To DataGridView1.RowCount - 1
                If DataGridView1.Rows(rownum).Cells("name_key").Value.ToString = Trim(selected_name_key) Then
                    DataGridView1.Rows(rownum).Cells(0).Selected = True
                    DataGridView1.CurrentCell = DataGridView1.Rows(rownum).Cells(0)
                    SelectedIndex = DataGridView1.CurrentRow.Index
                    Exit For
                End If
            Next

        End If

        selectedcell = False
        selected_screen_nam = ""
        selected_name_key = ""
        selected_sort_name = ""

        On Error Resume Next
        If SelectedIndex > 0 Then
            DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
            DataGridView1.Rows(SelectedIndex).Selected = True
            DataGridView1.Rows(SelectedIndex).Cells(0).Selected = True
            DataGridView1.PerformLayout()
        Else
            DataGridView1.Rows(0).Selected = False
        End If
        On Error GoTo 0

        txtinname.Text = ""
        TextBox1.Text = ""

        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("name_key", e.RowIndex).Value.ToString
            selected_name_key = DataGridView1.Item("name_key", e.RowIndex).Value.ToString
            selected_screen_nam = DataGridView1.Item("screen_nam", e.RowIndex).Value.ToString
            selected_sort_name = DataGridView1.Item("sort_name", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

        Dim bm As BindingManagerBase = DataGridView1.BindingContext(DataGridView1.DataSource, DataGridView1.DataMember)
        Dim dr As DataRow = CType(bm.Current, DataRowView).Row
        Dim cm As CurrencyManager = CType(DataGridView1.BindingContext(DataGridView1.DataSource), CurrencyManager)
        SelectedIndex = cm.Position
        selected_lookup_num = dr.Item(1).ToString
        selected_sort_name = dr.Item(0).ToString



    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim rownum As Integer
        Dim startletter As String
        TextBox1.BackColor = Color.White
        For rownum = 0 To DataGridView1.RowCount - 1
            startletter = UCase(TextBox1.Text) '& e.KeyCode.ToString
            If DataGridView1.Rows(rownum).Cells("screen_nam").Value.ToString.StartsWith(startletter, True, CultureInfo.InvariantCulture) Then
                DataGridView1.Rows(rownum).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(rownum).Cells(0)
                SetSelectedRow()
                Exit For
            End If
        Next

    End Sub

    Private Sub textbox1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextBox1.Enter
        TextBox1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        TextBox1.SelectionStart = 0
        TextBox1.SelectionLength = Len(TextBox1.Text)
    End Sub

    Private Sub textbox1_KeyDown(ByVal eventsender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        Dim rownum As Integer
        Dim startletter As String
        If KeyAscii = 13 Then
            Selectname.Focus()
            Exit Sub
        End If
        For rownum = 0 To DataGridView1.RowCount - 1
            startletter = UCase(TextBox1.Text) & e.KeyCode.ToString
            If DataGridView1.Rows(rownum).Cells("screen_nam").Value.ToString.StartsWith(startletter, True, CultureInfo.InvariantCulture) Then
                DataGridView1.Rows(rownum).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(rownum).Cells(0)
                Exit For
            End If
        Next
    End Sub

    Private Sub textbox1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))

        If KeyAscii = 13 Then
            Selectname.Focus()
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("name_key", DataGridView1.CurrentRow.Index).Value.ToString
            selected_sort_name = DataGridView1.Item("sort_name", DataGridView1.CurrentRow.Index).Value.ToString
            selected_screen_nam = DataGridView1.Item("screen_nam", DataGridView1.CurrentRow.Index).Value.ToString
            selected_name_key = DataGridView1.Item("name_key", DataGridView1.CurrentRow.Index).Value.ToString

            SelectedIndex = DataGridView1.CurrentRow.Index
        End If
    End Sub

    Private Sub textbox1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextBox1.Leave
        TextBox1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Public Sub SetSelectedRow()
        selectedcell = True
        selected_lookup_num = DataGridView1.Item("name_key", DataGridView1.CurrentRow.Index).Value.ToString
        selected_sort_name = DataGridView1.Item("sort_name", DataGridView1.CurrentRow.Index).Value.ToString
        selected_screen_nam = DataGridView1.Item("screen_nam", DataGridView1.CurrentRow.Index).Value.ToString
        selected_name_key = DataGridView1.Item("name_key", DataGridView1.CurrentRow.Index).Value.ToString
        SelectedIndex = DataGridView1.CurrentRow.Index
    End Sub

End Class