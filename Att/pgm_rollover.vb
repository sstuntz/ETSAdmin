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

Public Class pgm_rollover
    Inherits System.Windows.Forms.Form

    Dim div_array(20) As String
    Dim division As String

    Private Sub rebuild_grid()  'ByVal sql As String)
        'get a one item list of programs rolled over
        Dim listofprograms As String
        sqlstmnt = "select * from program where fiscal_yr = '" & to_fiscal.Text & "'"
        listofprograms = ETSSQL.GetOneItemList(sqlstmnt, "prog_num")
        Dim ListPrograms() = listofprograms.Split(CChar("*"))
        Dim ProgramList As String = ""
        If ListPrograms.Count > 1 Then
            ProgramList = "'"
            For n As Integer = 0 To ListPrograms.Count - 2
                ProgramList = ProgramList & ListPrograms(n) & "','"
            Next
            ProgramList = VB.Left(ProgramList, (Len(ProgramList) - 2))
        Else
            ProgramList = "''"
        End If
        'then make the sql not include them
        sqlstmnt = "select prog_num,prog_desc,prog_rate,fiscal_yr, division from program where fiscal_yr = '" & frm_fiscal.Text & "' and prog_num not in (" & ProgramList & ") order by prog_num "
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sqlstmnt)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False

        For n As Integer = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows.Item(n).Cells(5).Value = div_array(CInt(DataGridView1.Rows.Item(n).Cells(5).Value.ToString)) 'div_array(Data1.Recordset.Fields("division") + 1)
        Next

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No Programs to rollover.")
            Exit Sub
        End If

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
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub

    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click
        'actually do the rollwver

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        'get the old data
        Dim olddata As ProgramData = ETSSQL.GetProgramDataOne(selected_prog_num, frm_fiscal.Text)
        'input the new date
        olddata.EntryDate = Today
        sqlstmnt = "Insert into Program values ('" & olddata.ProgNum & "' , '" & olddata.ProgDesc & "' , " & olddata.ProgRate & "  , '" & olddata.Division & "' , '" & to_fiscal.Text & "' , ' " & olddata.Location & "' ,   '" & olddata.UfrNum & "' , '" & olddata.EntryDate & "')"
        selected_prog_num = olddata.ProgNum
        ETSSQL.ExecuteSQL(sqlstmnt)

        selected_prog_year = to_fiscal.Text
        entry_type = "EDIT"
        frmprog.ShowDialog()

        rebuild_grid()

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub prg_rollover_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
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
        'data filled in rebuild grid

        to_fiscal.Text = CStr(Year(Today) + 1)
        frm_fiscal.Text = CStr(Year(Today))

        ctrform(Me)
        selectedcell = False
        rebuild_grid()

    End Sub

    Private Sub frm_fiscal_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_fiscal.Enter
        Call ets_set_selected()
    End Sub

    Private Sub frm_fiscal_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles frm_fiscal.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            'check for number

            If Not IsNumeric(frm_fiscal.Text) Then
                MsgBox("Please enter a number")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            If Len(frm_fiscal.Text) <> 4 Then
                MsgBox("Please enter a 4 digit year.")
                Call ets_set_selected()
                GoTo EventExitSub
            End If
            System.Windows.Forms.SendKeys.Send("{TAB}")
            KeyAscii = 0

        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub frm_fiscal_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_fiscal.Leave
        frm_fiscal.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub


    Private Sub to_fiscal_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles to_fiscal.Enter
        Call ets_set_selected()
    End Sub

    Private Sub to_fiscal_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles to_fiscal.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            'check for number

            If Not IsNumeric(to_fiscal.Text) Then
                MsgBox("Please enter a number")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            If Len(frm_fiscal.Text) <> 4 Then
                MsgBox("Please enter a 4 digit year.")
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

    Private Sub to_fiscal_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles to_fiscal.Leave
        to_fiscal.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub
End Class