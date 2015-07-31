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
Imports System.String

Public Class edit_attend
    Inherits System.Windows.Forms.Form

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Delete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Delete.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        sqlstmnt = " delete from attend_Tmp where  att_Date between '" & start_date.Text
        sqlstmnt = sqlstmnt & "' and '" & End_Date.Text & "' and contract_key = '" & selected_contract_key & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        If by_Client.Checked Then
            MsgBox("You can only delete by contract")
            Exit Sub
        End If

        DataGridView1.Rows.Clear()

        Ref_list.Focus()

    End Sub

    Private Sub edit_attend_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)

        Me.Text = Me.Text & "   " & agency_name
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

        by_contract.Checked = True

        Dim HeaderDates As String() = ETSCommon.GetBeginEndDates.Split(CChar("*"))
        start_date.Text = HeaderDates(0)
        End_Date.Text = HeaderDates(1)

        'Call med_open()
        'If med_flag = "Y" Then
        '	'  Set tmpdb = OpenDatabase(am_data_path & "med.mdb")
        '	'   Set medopn_tmp = tmpdb.OpenRecordset("medopn_tmp")
        '	'   Do While Not medopn_tmp.EOF
        '	'   If medopn_tmp.Fields("record_id") <> "K" Then
        '	'   medopn_tmp.Delete
        '	'   End If
        '	'   medopn_tmp.MoveNext
        '	'   Loop

        '	sqlstmnt = " SELECT DISTINCT medopn_tmp.* from medopn_tmp  "
        '	sqlstmnt = sqlstmnt & "WHERE (medopn_tmp.from_date) Between " & Chr(35) &   start_date.Text & Chr(35)
        '	sqlstmnt = sqlstmnt & " and " & Chr(35) &   End_date.Text & Chr(35) '& " order by sort_name "
        '	'  Set medopn_tmp = tmpdb.OpenRecordset(sqlstmnt)
        'End If

    End Sub

    Private Sub end_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Date.Enter
        Call ets_set_selected()
    End Sub

    Private Sub end_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles End_Date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Then

            Dim retdate As String = ETS.Common.Module1.etsdate(End_Date.Text, "N")

            If retdate = "N" Then
                End_Date.Text = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                End_Date.Text = CDate(retdate).ToShortDateString
            End If

            selected_end_date = CDate(retdate)

            If DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(start_date.Text), CDate(End_Date.Text)) < 0 Then
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

    Private Sub Start_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date.Enter
        Call ets_set_selected()
    End Sub

    Private Sub Start_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles start_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Then
            Dim retdate As String = ETS.Common.Module1.etsdate(start_date.Text, "N")

            If retdate = "N" Then
                start_date.Text = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                start_date.Text = CDate(retdate).ToShortDateString
            End If

            selected_start_date = CDate(retdate)
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

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            If by_contract.Checked Then
                selected_bill_type = DataGridView1.Item("bill_type", e.RowIndex).Value.ToString
                selected_contract_key = DataGridView1.Item("contract_key", e.RowIndex).Value.ToString
            End If

            If by_Client.Checked Then
                selected_name_key = DataGridView1.Item("name_key", e.RowIndex).Value.ToString
                selected_sort_name = DataGridView1.Item("sort_name", e.RowIndex).Value.ToString
            End If


        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub

    Private Sub Process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Click

        selected_Date_Range_Start = CDate(start_date.Text)
        selected_Date_Range_End = CDate(End_Date.Text)

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub

        End If

        If by_contract.Checked Then
            selected_grouping = "CONTRACT"
            att_edit_bill_type.ShowDialog()
            Exit Sub
        End If

        If by_Client.Checked Then
            selected_grouping = "CLIENT"
            att_edit_bill_type.ShowDialog()
            Exit Sub
        End If

        DataGridView1.Rows.Clear()


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

        'put dates in rpthead
        sqlstmnt = "update rpthead set beg_date = '" & start_date.Text & "', end_date = ' " & End_Date.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        If by_contract.Checked Then
            DataGridView1.Columns.Clear()
            DataGridView1.Columns.Add("contract_key", "Contract")
            DataGridView1.Columns.Item(0).DataPropertyName = "contract_key"
            DataGridView1.AutoResizeColumn(0)
            DataGridView1.Columns.Add("cont_Desc", "Description")
            DataGridView1.Columns.Item(1).DataPropertyName = "cont_Desc"
            DataGridView1.Columns.Add("bill_type", "Bill Type")
            DataGridView1.Columns.Item(2).DataPropertyName = "bill_type"
            DataGridView1.Columns.Add("pv_form", "PV")
            DataGridView1.Columns.Item(3).DataPropertyName = "pv_Form"
            DataGridView1.Columns.Add("rpt_type", "RPT")
            DataGridView1.Columns.Item(4).DataPropertyName = "rpt_Type"
            DataGridView1.Columns.Add("redpy_dol", "Ready Pay")
            DataGridView1.Columns.Item(5).DataPropertyName = "redpy_dol"
            '
            Select Case package_Type
                Case "ATT"

                    sqlstmnt = " select distinct cc_cont.contract_key, cont_Desc, cc_cont.bill_type, redpy_dol,cc_cont.pv_form, cc_cont.rpt_type from attend_Tmp  INNER JOIN"
                    sqlstmnt = sqlstmnt & " cc_cont ON attend_tmp.contract_key = cc_cont.contract_key where "
                    sqlstmnt = sqlstmnt & " att_Date between '" & start_date.Text
                    sqlstmnt = sqlstmnt & "' and '" & End_Date.Text & "'"
                    sqlstmnt = sqlstmnt & " order by contract_key"
                    Using db As Database = New Database(top_data_path)
                        Dim sql As String = sqlstmnt
                        Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                        Dim redpy As String
                        While rs.Read()
                            If Val(rs("redpy_dol").ToString) <> 0 Then redpy = "Y" Else redpy = "N"
                            DataGridView1.Rows.Add(New String() {rs("contract_key").ToString, rs("cont_desc").ToString, rs("bill_type").ToString, rs("pv_form").ToString, rs("rpt_type").ToString, redpy, rs("bill_type").ToString})
                        End While
                        rs.Close()
                    End Using

                Case "AM"
                    'chck medicaid
                    '        If med_flag = "Y" Then
                    '
                    '            'now get the records you want -unique contracts in medopn_tmp
                    '  '           Set tmpdb = OpenDatabase(am_data_path & "med.mdb")
                    '  '          sqlstmnt = " SELECT DISTINCT medopn_tmp.contract_key from medopn_tmp  "
                    '  '          'sqlstmnt = sqlstmnt & "left JOIN medopn_tmp AS medopn_tmp_1 ON medopn_tmp.contract_key = medopn_tmp_1.contract_key "
                    '  '          sqlstmnt = sqlstmnt & "WHERE (medopn_tmp.from_date) Between " & Chr(35) &   start_date & Chr(35)
                    '  '          sqlstmnt = sqlstmnt & " and " & Chr(35) &   End_date & Chr(35) '& " order by sort_name "
                    '  '      Set medopn_tmp = tmpdb.OpenRecordset(sqlstmnt)
                    '
                    '  '       If medopn_tmp.RecordCount = 0 Then
                    '            MsgBox "Nothing to edit"
                    '             Screen.MousePointer = 0
                    '  '           Grid1.RemoveItem num
                    '            Exit Sub
                    '            Else
                    '  '          Do While Not medopn_tmp.EOF
                    '
                    '  '           selected_cont_desc = " "
                    '  '      valid_yn = "N"
                    '  '      Call chk_ready_pay(medopn_tmp.Fields("contract_key"), valid_yn)
                    '  '      Call get_contract_Desc(medopn_tmp.Fields("contract_key"), selected_cont_desc)
                    '  '      Call cont_key_display(medopn_tmp.Fields("contract_key"), msg)
                    '  '      Grid1.AddItem msg & Chr(9) & selected_cont_desc & Chr(9) & "170"
                    '  '      medopn_tmp.MoveNext
                    '  '      Loop
                    '
                    '  '          Grid1.RemoveItem num
                    '            Screen.MousePointer = 0
                    '            Exit Sub
                    '  '          End If
                    '
                    '  '      End If
                    '
            End Select
            '
        End If  ' by contract

        If by_Client.Checked Then
            DataGridView1.Columns.Clear()
            DataGridView1.Columns.Add("name_key", "Name Key")
            DataGridView1.Columns.Item(0).DataPropertyName = "name_key"
            DataGridView1.Columns.Add("sort_name", "Sort Name")
            DataGridView1.Columns.Item(1).DataPropertyName = "sort_name"

            Select Case package_Type
                '
                Case "ATT"

                    sqlstmnt = " select distinct name_key, sort_name from attend_Tmp where "
                    sqlstmnt = sqlstmnt & " att_Date between '" & start_date.Text
                    sqlstmnt = sqlstmnt & "' and '" & End_Date.Text & "'"
                    sqlstmnt = sqlstmnt & " order by sort_name"
                    Using db As Database = New Database(top_data_path)
                        Dim sql As String = sqlstmnt
                        Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                        While rs.Read()
                            DataGridView1.Rows.Add(New String() {rs("name_key").ToString, rs("sort_name").ToString})
                        End While
                        rs.Close()
                    End Using

                Case "AM"
                    '          'chck medicaid
                    '        If med_flag = "Y" Then
                    '
                    '  '          Set tmpdb = OpenDatabase(am_data_path & "med.mdb")
                    '  '          sqlstmnt = " SELECT DISTINCT medopn_tmp.name_key, medopn_tmp.sort_name from medopn_tmp  "
                    '  '          sqlstmnt = sqlstmnt & "WHERE (medopn_tmp.from_date) Between " & Chr(35) &   start_date & Chr(35)
                    '  '          sqlstmnt = sqlstmnt & " and " & Chr(35) &   End_date & Chr(35) '& " order by sort_name "
                    '  '          Set medopn_tmp = tmpdb.OpenRecordset(sqlstmnt)
                    '
                    '  '          If medopn_tmp.RecordCount = 0 Then
                    '  '              MsgBox "Nothing to edit"
                    '  '               Screen.MousePointer = 0
                    '  '               Grid1.RemoveItem num
                    '  '              Exit Sub
                    '  '          Else
                    '                'now get the unique list of clients
                    '  '                Set tmpdb = OpenDatabase(am_data_path & "med.mdb")
                    '  '              sqlstmnt = " SELECT DISTINCT medopn_tmp.name_key from medopn_tmp  "
                    '  '              sqlstmnt = sqlstmnt & "left JOIN medopn_tmp AS medopn_tmp_1 ON medopn_tmp.name_key = medopn_tmp_1.name_key "
                    '  '              sqlstmnt = sqlstmnt & "WHERE (medopn_tmp_1.from_date) Between " & Chr(35) &   start_date & Chr(35)
                    '  '              sqlstmnt = sqlstmnt & " and " & Chr(35) &   End_date & Chr(35) '& " order by sort_name "
                    '  '              Set medopn_tmp = tmpdb.OpenRecordset(sqlstmnt)
                    '
                    '  '              num = 1
                    '  '              Do While Not medopn_tmp.EOF
                    '  '              Call chkname_top(medopn_tmp.Fields("name_key"))
                    '  '              Grid1.AddItem medopn_tmp.Fields("name_key") & Chr(9) & selected_sort_name & Chr(9) & "170", num 'selected_cont_desc & Chr(9) & attend_unq.Recordset.Fields("bill_type") & Chr(9) & attend_unq.Recordset.Fields("pv_Form") & Chr(9) & attend_unq.Recordset.Fields("rpt_type") & Chr(9) & valid_yn, num
                    '  '              num = num + 1
                    '  '              medopn_tmp.MoveNext
                    '  '              Loop
                    '  '              Grid1.RemoveItem num
                    '  '              Screen.MousePointer = 0
                    '  '              Exit Sub
                    '
                    '  '          End If
                    '  '        End If    ' medicaid flag
                    '
            End Select
            '
        End If   'by client

        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing

    End Sub

End Class