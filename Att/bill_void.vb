Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System
Imports System.IO
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient

Public Class bill_void
    Inherits System.Windows.Forms.Form
    Public paid As String

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub bill_void_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoGenerateColumns = False

        DataGridView1.Columns.Add("Contract_key", "Contract")
        DataGridView1.Columns.Item(0).DataPropertyName = "Contract_key"
        DataGridView1.Columns.Add("cont_desc", "Description")
        DataGridView1.Columns.Item(1).DataPropertyName = "Cont_desc"
        DataGridView1.Columns.Add("bill_type", "Bill Type")
        DataGridView1.Columns.Item(2).DataPropertyName = "bill_type"
        DataGridView1.Columns.Add("pv_form", "PV")
        DataGridView1.Columns.Item(3).DataPropertyName = "pv_Form"
        DataGridView1.Columns.Add("rpt_Type", "Report")
        DataGridView1.Columns.Item(4).DataPropertyName = "rpt_type"

        Dim HeaderDates As String() = ETSCommon.GetBeginEndDates.Split(CChar("*"))
        start_date.Text = HeaderDates(0)
        End_Date.Text = HeaderDates(1)


    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_contract_key = DataGridView1.Item("contract_key", e.RowIndex).Value.ToString
            '  selected_desc = DataGridView1.Item("cont_desc", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub

    Private Sub End_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Date.Enter
        Call ets_set_selected()
    End Sub

    Private Sub End_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles End_Date.KeyPress
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
                pr_end_date = CDate(retdate)
                selected_end_date = CDate(retdate)
            End If

            If DateDiff(DateInterval.Day, CDate(start_date.Text), CDate(End_Date.Text)) < 0 Then
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

    Private Sub End_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Date.Leave
        End_Date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub Start_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date.Enter
        Call ets_set_selected()

    End Sub

    Private Sub Start_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles start_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Then
            senddate = start_date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")
            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                selected_start_date = CDate(retdate)
                start_date.Text = CDate(retdate).ToShortDateString
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

    Private Sub Start_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date.Leave
        start_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub Process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        'If paid_amount or posted note to tell them and exit
        sqlstmnt = " select * from invoice where contract_key = '" & selected_contract_key
        sqlstmnt = sqlstmnt & "' and from_Date = '" & start_date.Text
        sqlstmnt = sqlstmnt & "' and to_Date = '" & End_Date.Text
        sqlstmnt = sqlstmnt & "' and glpost = 'Y' "
        If ETSCommon.CheckNumRecords(sqlstmnt) > 0 Then
            MsgBox("Invoice has been posted.  Please reverse before voiding invoice.")
            Exit Sub
        End If

        sqlstmnt = " select * from invoice where contract_key = '" & selected_contract_key
        sqlstmnt = sqlstmnt & "' and from_Date = '" & start_date.Text
        sqlstmnt = sqlstmnt & "' and to_Date = '" & End_Date.Text
        sqlstmnt = sqlstmnt & "' and pay_amt <> 0 "

        If ETSCommon.CheckNumRecords(sqlstmnt) > 0 Then
            MsgBox("Invoice has been paid.  Please reverse cash before voiding invoice.")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        'remove from history if not paid and not posted to GL
        'remove from invoice also
        sqlstmnt = " update attend_hist set void = 'Y'  where contract_key = '" & selected_contract_key
        sqlstmnt = sqlstmnt & "' and att_Date between '" & start_date.Text
        sqlstmnt = sqlstmnt & "' and '" & End_Date.Text
        sqlstmnt = sqlstmnt & "' "
        ETSSQL.ExecuteSQL(sqlstmnt)

        'copy attend hist to attend tmp
        sqlstmnt = " select * from attend_hist where contract_key = '" & selected_contract_key
        sqlstmnt = sqlstmnt & "' and att_Date between '" & start_date.Text
        sqlstmnt = sqlstmnt & "' and '" & End_Date.Text
        sqlstmnt = sqlstmnt & "' order by b_num, att_date"

        Dim MoveAttend As New List(Of AttendData)
        MoveAttend = ETSSQL.GetAttendanceData(sqlstmnt)

        For Each Row In MoveAttend
            Row.Invoice = ""
            Row.InvoiceDate = CDate("1/1/1901")
            Row.Void = "N"
            sqlstmnt = "insert into attend_tmp " & Row.AttendColumnNames & " values " & Row.AttendColumnData
            ETSSQL.ExecuteSQL(sqlstmnt)

        Next

        'end of move

        sqlstmnt = " update invoice set void = 'Y' where contract_key = '" & selected_contract_key
        sqlstmnt = sqlstmnt & "' and from_Date >= '" & start_date.Text
        sqlstmnt = sqlstmnt & "' and to_Date <= '" & End_Date.Text
        sqlstmnt = sqlstmnt & "'  "
        ETSSQL.ExecuteSQL(sqlstmnt)

        '	'repair rpt hist

        sqlstmnt = " update attend_rpt_hist set void = 'Y' where contract_key = '" & selected_contract_key
        sqlstmnt = sqlstmnt & "' and att_beg between '" & start_date.Text
        sqlstmnt = sqlstmnt & "' and '" & End_Date.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        '	'repair mmpv hist
        sqlstmnt = " update mmpv_hist set void = 'Y' where contract_key = '" & selected_contract_key
        sqlstmnt = sqlstmnt & "' and [frm_Date-40] between '" & start_date.Text
        sqlstmnt = sqlstmnt & "' and '" & End_Date.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        '	'repair bill control
        sqlstmnt = " update bill_cntrl set invoice = '' where contract_key = '" & selected_contract_key
        sqlstmnt = sqlstmnt & "' and serv_beg >= '" & start_date.Text
        sqlstmnt = sqlstmnt & "' and serv_End <= '" & End_Date.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        update_contract_ytd(selected_contract_key)

        'if pdf inovice created change name to void
        Dim pdfid As String = invoice_string_Create(End_Date.Text, selected_contract_key) & ".pdf"
        Dim FullLocation As String = CheckInvoiceFolder(End_Date.Text, selected_contract_key)
        Dim FullPathName As String = FullLocation & pdfid
        If File.Exists(FullLocation & pdfid) Then
            FileSystem.Rename(FullPathName, FullLocation & Path.GetFileNameWithoutExtension(FullPathName) & "void" & Path.GetExtension(FullPathName))
        End If

        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        'Ref_list.PerformClick()
        SelectedIndex = 0
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Ref_list_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Ref_list.Click

        If Len(start_date.Text) = 0 Then
            MsgBox("You need to enter a start date.")
            start_date.Focus()
            Exit Sub
        End If

        If Len(End_Date.Text) = 0 Then
            MsgBox("You need to enter an end date.")
            End_Date.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim rs As DataSet
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()

        sqlstmnt = " select distinct attend_hist.contract_key, cc_cont.* from attend_hist "
        sqlstmnt = sqlstmnt & " INNER Join cc_cont ON cc_Cont.contract_key = attend_hist.contract_key  where"
        sqlstmnt = sqlstmnt & " att_Date between '" & start_date.Text
        sqlstmnt = sqlstmnt & "' and '" & End_Date.Text
        sqlstmnt = sqlstmnt & "' and void <> 'Y' "
        sqlstmnt = sqlstmnt & " order by attend_hist.contract_key"

        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sqlstmnt)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        selected_lookup_num = ""
        selected_contract_key = ""
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
        'put dates in rpthead
        sqlstmnt = "update rpthead set beg_date = '" & start_date.Text & "', end_date = ' " & End_Date.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)
        Me.Cursor = Cursors.Default

    End Sub
End Class