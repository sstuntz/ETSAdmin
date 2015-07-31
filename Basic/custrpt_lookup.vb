Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports ps.common
Imports System.Data.SqlClient

Public Class custrpt_lookup
    Inherits System.Windows.Forms.Form


    Private Sub rebuild_grid()
        Me.DataGridView1.ClearSelection()
        Dim sql As String = "select rpt_num, rpt_name, rpt_desc, rpt_screen, rpt_date from custrpt where packagetype = '" & package_Type & "'"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        selected_lookup_num = ""
        selected_lookup_desc = ""

        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing

    End Sub

    Private Sub DataGridView1_cellclick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("rpt_num", e.RowIndex).Value.ToString
            selected_lookup_desc = DataGridView1.Item("rpt_name", e.RowIndex).Value.ToString
            Select Case DataGridView1.Item("rpt_screen", e.RowIndex).Value.ToString
                Case "S"
                    prtDestination = 0
                Case "P"
                    prtDestination = 1
            End Select

        End If
    End Sub

    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        'put dates in rpthead
        sqlstmnt = "update rpthead set beg_date = '" & Start_date.Text & "', end_date = ' " & End_Date.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)
        Me.Cursor = Cursors.WaitCursor
        msg = "Date (" & Year(CDate(Start_date.Text)) & "," & Month(CDate(Start_date.Text)) & "," & VB.Day(CDate(Start_date.Text)) & ")"
        prtParameterFields(0) = "Begdate;" & msg & ";FALSE"
        msg = "Date (" & Year(CDate(End_Date.Text)) & "," & Month(CDate(End_Date.Text)) & "," & VB.Day(CDate(End_Date.Text)) & ")"
        prtParameterFields(1) = "EndDate;" & msg & ";FALSE"

        prtreportfilename = ar_report_path & selected_lookup_desc

        CrystalForm.ShowDialog()
        Me.Cursor = Cursors.Default
        '  entry_type = ""
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
        entry_type = "ADD"
        frmcustrpt.ShowDialog()

        selected_lookup_num = ""
        selected_lookup_desc = ""

        Call rebuild_grid()

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        selected_lookup_num = " " '
        selected_lookup_desc = " "
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub custrpt_lookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If

        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Dim sql As String = "select rpt_num, rpt_name, rpt_desc, rpt_screen, rpt_date from custrpt where packagetype = '" & package_Type & "'"

        DataGridView1.Columns.Add("rpt_num", "Rpt Num")
        DataGridView1.Columns.Item(0).DataPropertyName = "rpt_num"
        DataGridView1.Columns.Add("rpt_name", "Rpt Name")
        DataGridView1.Columns.Item(1).DataPropertyName = "rpt_name"
        DataGridView1.Columns.Add("rpt_desc", "Desc")
        DataGridView1.Columns.Item(2).DataPropertyName = "rpt_desc"
        DataGridView1.Columns.Add("rpt_Screen", "Screen or Printer")
        DataGridView1.Columns.Item(3).DataPropertyName = "rpt_Screen"
        DataGridView1.Columns.Add("rpt_date", "Date")
        DataGridView1.Columns.Item(4).DataPropertyName = "rpt_Date"

        ctrform(Me)
        selectedcell = False

        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If

        'get dates for filling form
        Dim HeaderDates As String() = ETSCommon.GetBeginEndDates.Split(CChar("*"))
        Start_date.Text = HeaderDates(0)
        End_Date.Text = HeaderDates(1)

        rebuild_grid()

    End Sub

    Private Sub edit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        entry_type = "EDIT"
        frmcustrpt.ShowDialog()
        Call rebuild_grid()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click
        'delete the record selected
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If


        Response = MsgBox("Do you really want to delete this report?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = MsgBoxResult.Yes Then
            sqlstmnt = " delete from custrpt where rpt_num = " & selected_lookup_num
            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                db.ExecuteQuery(sql)
            End Using
        End If

        Call rebuild_grid()


    End Sub

    Private Sub start_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Start_date.Enter
        Start_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        Start_date.SelectAll()

    End Sub

    Private Sub start_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Start_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = Start_date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")
            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                selected_start_date = CDate(retdate)
                Start_date.Text = CDate(retdate).ToShortDateString
            End If

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0

        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub start_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Start_date.Leave
        Start_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub end_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Date.Enter
        End_Date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        End_Date.SelectAll()

    End Sub

    Private Sub end_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles End_Date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = End_Date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")
            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                End_Date.Text = CDate(retdate).ToShortDateString
                selected_end_date = CDate(retdate)
            End If

            If DateDiff(DateInterval.Day, CDate(Start_date.Text), CDate(End_Date.Text)) < 0 Then
                MsgBox("Invalid date range")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0

        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub end_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Date.Leave
        End_Date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

End Class