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

Public Class prognumlookup
    Inherits System.Windows.Forms.Form
    Dim SelectedIndex As Integer
    Dim selected_fiscal As Integer
    Dim div_array(20) As String

    Private Sub rebuild_grid()  'ByVal sql As String)
        sqlstmnt = "Select  prog_num, prog_desc, prog_rate, fiscal_yr, division from program where fiscal_yr = " & selected_fiscal & " order by prog_num"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sqlstmnt)
        End Using
        DataGridView1.DataSource = rs.Tables(0)

        For n As Integer = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows.Item(n).Cells(5).Value = div_array(CInt(DataGridView1.Rows.Item(n).Cells(5).Value.ToString)) 'div_array(Data1.Recordset.Fields("division") + 1)
        Next

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

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_prog_num = DataGridView1.Item("prog_num", e.RowIndex).Value.ToString
            selected_prog_desc = DataGridView1.Item("prog_desc", e.RowIndex).Value.ToString
            selected_prog_rate = CDec(DataGridView1.Item("prog_Rate", e.RowIndex).Value.ToString)
            selected_prog_year = DataGridView1.Item("fiscal_yr", e.RowIndex).Value.ToString

        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub

    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        Me.Dispose()

    End Sub

    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
        On Error Resume Next

        entry_type = "ADD"
        frmprog.ShowDialog()
        rebuild_grid()

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click

        selected_prog_num = ""
        selected_prog_desc = ""
        selected_prog_rate = 0

        Me.Dispose()

    End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        entry_type = "EDIT"
        frmprog.ShowDialog()

        rebuild_grid()

    End Sub

    Private Sub prognumlookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        'fill div_array(number) = desc
        sqlstmnt = "select * from reference where ctrl_name = 'division'"
        Dim TwoItemList As List(Of String) = ETSSQL.GetTwoItemList(sqlstmnt, "datum", "datum_desc")
        '    div_array(Data2.Recordset.Fields("datum")) = Data2.Recordset.Fields("datum_desc")

        For Each item In TwoItemList
            Dim items() As String = Split(item, CChar("*"))
            div_array(CInt(items(0))) = items(1)
        Next
        DataGridView1.Columns.Add("prog_num", "Program #")
        DataGridView1.Columns.Item(0).DataPropertyName = "prog_num"
        DataGridView1.Columns.Add("prog_desc", "Description")
        DataGridView1.Columns.Item(1).DataPropertyName = "prog_desc"
        DataGridView1.Columns.Add("prog_rate", "Rate")
        DataGridView1.Columns.Item(2).DataPropertyName = "prog_rate"
        DataGridView1.Columns.Item(2).DefaultCellStyle.Format = "N2"
        DataGridView1.Columns.Add("fiscal_yr", "Fiscal Year")
        DataGridView1.Columns.Item(3).DataPropertyName = "Fiscal_yr"
        DataGridView1.Columns.Add("division", "Division")
        DataGridView1.Columns.Item(4).DataPropertyName = "division"
        '  DataGridView1.Columns.Item(4).Visible = False
        DataGridView1.Columns.Add("divdesc", "Divisions")
        DataGridView1.Columns.Item(5).Visible = False

        ctrform(Me)
        selectedcell = False

        Select Case function_type
            Case "CUR"
                selected_fiscal = CInt(CStr(Year(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 6, Today))))
                Me.Text = Me.Text & " - Current Fiscal " & selected_fiscal
            Case "PRIOR"
                selected_fiscal = CInt(InputBox("Which Fiscal Year would you like displayed?  Enter as a 4 character year."))
                Me.Text = Me.Text & " -  Fiscal = " & selected_fiscal
            Case "DATA_ENTRY"
                Accept.Enabled = True
                selected_fiscal = new_Fiscal
            Case Else
                selected_fiscal = CInt(CStr(Year(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 6, Today))))
                Me.Text = Me.Text & ""
        End Select

        rebuild_grid()

    End Sub

End Class