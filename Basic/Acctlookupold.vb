Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.Compatibility
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports JRI.MODULE1
Imports System.Data.SqlClient
Imports System.Globalization

Friend Class acctlookup
    Inherits System.Windows.Forms.Form

    Private Sub rebuild_grid()
        Dim sql As String = "select acct_only, acct_num, acct_desc, gl_ref_no from chacct order by acct_num"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)

        If entry_type = "ADD" Then
            'find the selected index for the new acct in selected_acct_num
            For rownum = 0 To DataGridView1.RowCount - 1
                If DataGridView1.Rows(rownum).Cells("acct_num").Value.ToString = Trim(selected_acct_num) Then
                    DataGridView1.Rows(rownum).Cells(0).Selected = True
                    DataGridView1.CurrentCell = DataGridView1.Rows(rownum).Cells(0)
                    SelectedIndex = DataGridView1.CurrentRow.Index
                    Exit For
                End If
            Next

        End If

        selectedcell = False
        selected_lookup_num = ""
        selected_acct_num_desc = ""

        DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
        DataGridView1.Rows(SelectedIndex).Selected = True
        DataGridView1.Rows(SelectedIndex).Cells(0).Selected = True
        DataGridView1.PerformLayout()


    End Sub

    Private Sub DataGridView1_cellclick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("acct_num", e.RowIndex).Value.ToString
            selected_acct_num_desc = DataGridView1.Item("acct_desc", e.RowIndex).Value.ToString
            SelectedIndex = DataGridView1.CurrentRow.Index

        End If
    End Sub


    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        ' entry_type = ""
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
        entry_type = "ADD"

        frmgl_enter.ShowDialog()
        Call rebuild_grid()
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        selected_lookup_num = ""
        selected_acct_num_desc = ""
        entry_type = "CANCEL"
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub acctlookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ' ctrform(Me)
        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If

        Dim sql As String = "select acct_only, acct_num, acct_desc, gl_ref_no from chacct order by acct_num"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)

        Select Case entry_type
            Case "ADD"
                addacct.Visible = True
                If pass_level = 0 Then addacct.Enabled = False
            Case "EDIT"
                edit.Visible = True
                If pass_level = 0 Then edit.Enabled = False
        End Select
        If function_type = "DATA_ENTRY" Then

            Accept.Enabled = True
        End If
        If function_type = "LOOKUP_ONLY" Then
            addacct.Enabled = False
            edit.Enabled = False
            Accept.Enabled = True
        End If
        txtinname.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        txtinname.Text = ""
        txtinname.Focus()
        txtinname.SelectAll()

        Me.DataGridView1.ClearSelection()
        ETSForm(Me)
    End Sub

    Private Sub edit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        entry_type = "EDIT"
        Me.Hide()
        frmgl_enter.ShowDialog()
        Me.Show()
        Call rebuild_grid()
    End Sub

    Private Sub txtinname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtinname.TextChanged
        Dim rownum As Integer
        Dim startletter As String

        txtinname.BackColor = Color.White
       
        For rownum = 0 To DataGridView1.RowCount - 1
            startletter = UCase(txtinname.Text) '& e.KeyCode.ToString
            If DataGridView1.Rows(rownum).Cells("acct_only").Value.ToString.StartsWith(startletter, True, CultureInfo.InvariantCulture) Then
                DataGridView1.Rows(rownum).Cells(0).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(rownum).Cells(0)
                Exit For
            End If
        Next

    End Sub

    Private Sub txtinname_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtinname.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))

        If KeyAscii = 13 Then
            Accept.Focus()
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("acct_num", DataGridView1.CurrentRow.Index).Value.ToString
            selected_acct_num_desc = DataGridView1.Item("acct_desc", DataGridView1.CurrentRow.Index).Value.ToString
            SelectedIndex = DataGridView1.CurrentRow.Index
        End If
    End Sub

    Private Sub RectangleShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectangleShape1.Click

    End Sub
End Class


 