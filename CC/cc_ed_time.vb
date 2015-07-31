Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETS.Common.Module1
Imports PS.Common
Imports ETS.pr_common
Imports ETS.clpr_mod
Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility
Imports Microsoft.VisualBasic.Conversion
Imports System.String

Public Class cc_ed_time
    Inherits System.Windows.Forms.Form
   
    Dim ee_array(15, 100) As String
    Dim offset_grid_line As Integer
    Dim max_grid_line As Integer
    Public total_amount As Decimal
    Public total_hours As Decimal
    Public total_pieces As Decimal
    Public total_vac As Decimal
    Public total_pers As Decimal
    Public total_sick As Decimal
    Public total_hol As Decimal

    Public wline As Integer
    Public add_sub As Integer
    Public oldfocus As Integer
    Public a(15) As String
    Public last_line_num As Integer
    Public jobdata As List(Of String)


    Public Sub fill_ee_array()
        'this takes a selected employee and puts it into fields that can be edited
        'it needs to read all the lines in the table with the right employee number
        sqlstmnt = "select * from cctime where name_key = '"
        sqlstmnt = sqlstmnt & selected_name_key
        sqlstmnt = sqlstmnt & "' and entry_num = " & selected_entry_num
        sqlstmnt = sqlstmnt & " and pay_num = " & selected_pay_num 'pay_num is now number
        sqlstmnt = sqlstmnt & " and paid <>  'Y' order by line_num "

        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            i = 1                 'array starts at one
            While rs.Read()
                If CDbl(rs("line_num").ToString) = 1 Then
                    'put in header
                    Me.sys_Date.Text = rs("entry_Date").ToString
                    Me.Pr_num1.Text = rs("pay_num").ToString
                    pr_num = CInt(rs("pay_num"))
                End If
                'put in array
                ee_array(0, i) = rs("line_num").ToString
                ee_array(1, i) = CType(rs("Date"), String) 'String.Format(rs("date"), "d")
                ee_array(2, i) = rs("job_num").ToString
                jobdata = etsjobnum_chk(rs("job_num").ToString)
                If jobdata(0) <> "N" Then ee_array(3, i) = jobdata(2).ToString
                ee_array(4, i) = rs("pay_Class").ToString
                ee_array(5, i) = rs("hours").ToString
                ee_array(6, i) = rs("pcs_prod").ToString
                ee_array(7, i) = rs("pcs_prod").ToString
                ee_array(8, i) = rs("dept_num").ToString
                ee_array(9, i) = rs("pay_dol").ToString
                ee_array(10, i) = rs("cl_pct").ToString
                i = CShort(i + 1)
            End While
            rs.Close()
            max_grid_line = i - 1

        End Using

        selected_sort_name = ETSCommon.GetDatum("nam_addr", "name_key", selected_name_key, "sort_name")


    End Sub

    Sub tot_amt()
        Dim n As Integer
        total_amount = 0
        total_hours = 0
        total_pieces = 0
        total_hol = 0
        total_vac = 0
        total_sick = 0
        total_pers = 0
        valid_lookup = "Y"

        For n = 1 To max_grid_line + 1
            total_amount = CDec(total_amount + Val(ee_array(9, n)))
            total_hours = CDec(total_hours + Val(ee_array(5, n)))
            total_pieces = CDec(total_pieces + Val(ee_array(6, n)))
            If Val(ee_array(2, n)) = 83801 Then total_hol = CDec(total_hol + Val(ee_array(5, n)))
            If Val(ee_array(2, n)) = 84 Then total_pers = CDec(total_pers + Val(ee_array(5, n)))
            If Val(ee_array(2, n)) = 82801 Then total_sick = CDec(total_sick + Val(ee_array(5, n)))
            If Val(ee_array(2, n)) = 81808 Then total_vac = CDec(total_vac + Val(ee_array(5, n)))

        Next n

        ee_calc_tot_pay.Text = Format(total_amount.ToString, "###0.00;-###0.00")
        ee_calc_tot_hrs.Text = Format(total_hours.ToString, "###0.00")
        ee_calc_tot_pcs.Text = Strings.Format(total_pieces, "#####0.0")

    End Sub

    Sub grid_change(ByVal add_sub As Integer, ByVal wline As Integer, ByVal oldfocus As Integer)
        Dim n As Integer
        Dim i As Integer

        Select Case add_sub
            Case 1 'if add_sub is 1 then add a line from here out

                max_grid_line = max_grid_line + 1

                For n = max_grid_line To wline Step -1
                    ee_array(0, n) = CStr(CDbl(ee_array(0, n - 1)) + 1) 'renumbers the next higher jeline

                    For i = 1 To 10
                        ee_array(i, n) = ee_array(i, n - 1)
                    Next i
                Next n
                For i = 1 To 10
                    ee_array(i, wline) = ""
                Next i

            Case -1 'if add_sub is -1 take a line out from where we are to the end
                'this tests the continuous use of f5 key

                If Val(wline) > max_grid_line Then
                    wline = max_grid_line
                End If

                'this is the special case of deleting the last line
                If wline = max_grid_line Then
                    max_grid_line = max_grid_line - 1

                    If max_grid_line < 1 Then max_grid_line = 1

                    For n = 0 To 15
                        ee_array(n, wline) = ""
                    Next n
                    If oldfocus - 1 < 0 Then
                        oldfocus = 1
                        offset_grid_line = offset_grid_line - 1
                        If offset_grid_line < 0 Then offset_grid_line = 0
                    End If

                    Call tot_amt()
                    Call repaint_grid(offset_grid_line, wline, oldfocus - 1)
                    Exit Sub
                End If

                max_grid_line = max_grid_line - 1
                If max_grid_line < 1 Then max_grid_line = 1

                For n = wline To max_grid_line
                    '        ee_array(0, n) = Val(ee_array(0, n + 1)) - 1
                    For i = 1 To 10
                        ee_array(i, n) = ee_array(i, n + 1)
                    Next i
                Next n
                For i = 1 To 10
                    ee_array(i, max_grid_line + 1) = ""
                Next i

        End Select

        Call tot_amt()
        Call repaint_grid(offset_grid_line, wline, oldfocus)

    End Sub

    Sub repaint_grid(ByVal offset_grid_line As Integer, ByVal wline As Integer, ByVal oldfocus As Integer)
        'recalc the offset grid line to keep the focus on the same physical line
        'and for the new line to be sensible

        'line renumbering done on jeline getting the focus
        Dim i As Short

        For i = 0 To 9
            pr_arr_date(i).Text = ee_array(1, i + 1 + offset_grid_line)
            pr_arr_job(i).Text = ee_array(2, i + 1 + offset_grid_line)
            pr_arr_loc(i).Text = ee_array(3, i + 1 + offset_grid_line)
            pr_arr_rea(i).Text = ee_array(4, i + 1 + offset_grid_line)
            pr_arr_hrs(i).Text = ee_array(5, i + 1 + offset_grid_line)
            pr_arr_pcs(i).Text = ee_array(6, i + 1 + offset_grid_line)
            '   pr_arr_pcs(i) = ee_array(7, i + 1 + offset_grid_line)
            pr_arr_dept(i).Text = ee_array(8, i + 1 + offset_grid_line)
            pr_Arr_pay(i).Text = ee_array(9, i + 1 + offset_grid_line)
            pr_arr_pct(i).Text = String.Format("{0:f2}", ee_array(10, i + 1 + offset_grid_line))

        Next i
        jeline(CShort(oldfocus)).Focus()

        KeyAscii = 0
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Dispose()
        ccpr_ed.Show()
    End Sub

    Private Sub del_card_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles del_card.Click
        Response = MsgBox("Are you sure you want to delete this time card?", CType(4 + 256, MsgBoxStyle))
        If Response = 6 Then
            sqlstmnt = " delete from cctime where name_key = '" & selected_name_key
            sqlstmnt = sqlstmnt & "' and entry_num = " & selected_entry_num
            sqlstmnt = sqlstmnt & " and paid <> 'Y'  "

            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                db.ExecuteQuery(sql)
            End Using
            Me.Dispose()
            ccpr_ed.Show()
        Else
            ee_exp_hrs.Focus()
        End If

    End Sub

    Private Sub ed_comp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ed_comp.Click
        Call tot_amt()
        sqlstmnt = ";with cte as (select name_key, cctime.date, pay_num, line_num, ROW_NUMBER() over (order by cctime.date) as rownum from cctime where name_key = '" & selected_name_key & "' and pay_num = '" & pr_num & "' )"
        sqlstmnt = sqlstmnt & " update cte set line_num = rownum  "
        ETSSQL.ExecuteSQL(sqlstmnt)


        If total_hours = CDbl(ee_exp_hrs.Text) Then

            'repaint it differently if the first line has a no pay problem
            If CDbl(ee_array(0, 1)) = 1 And ee_array(4, 1) = "OO" Then ' to correct for no pay lines
                For ETS.Common.Module1.num = 2 To max_grid_line
                    If ee_array(4, num) <> "OO" And ee_array(4, num) <> "NO" Then
                        ee_array(0, 1) = ee_array(0, num)
                        ee_array(0, num) = CStr(1)
                        Call repaint_grid(0, 0, 0)
                        Exit For
                    End If
                Next
            End If

            If CDbl(ee_array(0, 1)) = 1 And ee_array(4, 1) = "NO" Then
                For ETS.Common.Module1.num = 2 To max_grid_line
                    If ee_array(4, num) <> "OO" And ee_array(4, num) <> "NO" Then
                        ee_array(0, 1) = ee_array(0, num)
                        ee_array(0, num) = CStr(1)
                        Call repaint_grid(0, 0, 0)
                        Exit For
                    End If
                Next
            End If


            'this checks to make sure the header is complete
            If Len(ee_entry_num.Text) = 0 Or Len(ee_num.Text) = 0 Then
                MsgBox("Header is not complete.  Please complete and then process.")
                Exit Sub
            End If

            'process is to delete the records and then add.
            sqlstmnt = " delete from cctime where name_key = '" & selected_name_key
            sqlstmnt = sqlstmnt & "' and entry_num = " & selected_entry_num
            sqlstmnt = sqlstmnt & " and paid <> 'Y'  "
            ETSSQL.ExecuteSQL(sqlstmnt)

            'For n = 1 To max_grid_line 'array starts at 1
            '    sqlstmnt = " insert into cctime "
            '    sqlstmnt = sqlstmnt & "(entry_date,pay_num,name_key,screen_nam,entry_num,line_num,pay_Freq,ded_dfq,date,job_num,pay_class,hours,pcs_prod,dept_num,pay_dol,cl_pct,Sort_name)"
            '    sqlstmnt = sqlstmnt & " values ('" & sys_Date.Text & "','" & pr_num & "','" & Trim(ee_num.Text) & "','" & ee_Screen_nam.Text & "','" & ee_entry_num.Text & "','" & Val(ee_array(0, n)) + Val(CStr(last_line_num)) & "','" & ee_pay_dfq.Text & "','" & ee_ded_dfq.Text & "','" & ee_array(1, n) & "','" & ee_array(2, n) & "','" & ee_array(4, n) & "','" & ee_array(5, n) & "','" & Val(ee_array(6, n)) & "','" & ee_array(8, n) & "','" & ee_array(9, n) & "','" & ee_array(10, n) & "','" & selected_sort_name & "')"
            '    ETSSQL.ExecuteSQL(sqlstmnt)
            'Next n

            LoadCCTime()

            Me.Dispose()
            ccpr_ed.Show()

        Else
            MsgBox("Hours are out of balance")
        End If

    End Sub

    Private Sub ee_ded_dfq_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ee_ded_dfq.Enter
        Call ets_set_selected()
    End Sub

    Private Sub ee_ded_dfq_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ee_ded_dfq.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Then

            ee_ded_dfq.Text = UCase(ee_ded_dfq.Text)
            'need too check the entry and to see if each one only entered once
            Select Case ee_ded_dfq.Text
                Case "A"
                Case "B"
                Case "M"
                Case "W"
                Case "S"
                Case "ND"
                Case "A,M"
                Case "A,M,S"
                Case "A,M,B"
                Case "A,M,W"
                Case "A,M,B,W"
                Case "A,M,S,B"
                Case "A,M,S,B,W"
                Case "A,M,S,W"
                Case "A,S,B,W"
                Case "A,S,B"
                Case "A,S,W"
                Case "A,S,"
                Case "A,B,W"
                Case "A,W"
                Case "A,B"
                Case "M,S,B,W"
                Case "M,B,W"
                Case "M,S"
                Case "M,B"
                Case "M,W"
                Case "M,S,W"
                Case "M,S,B"
                Case "S,B,W"
                Case "S,W"
                Case "S,B"
                Case "B,W"

                Case Else
                    MsgBox("invalid entry")
                    Call ets_set_selected()
                    GoTo EventExitSub
            End Select

            ee_exp_hrs.Focus()
            KeyAscii = 0
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub ee_ded_dfq_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ee_ded_dfq.Leave
        ee_ded_dfq.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub ee_entry_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ee_entry_num.Enter
        Call ets_set_selected()
    End Sub

    Private Sub ee_entry_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ee_entry_num.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Then
            If CDbl(ee_entry_num.Text) > 1 Then
                Response = MsgBox("This is for check #" & ee_entry_num.Text & " for this employee for this payroll run", MsgBoxStyle.YesNo)
                If Response = 7 Then
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If

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

    Private Sub ee_entry_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ee_entry_num.Leave
        ee_entry_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub ee_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ee_num.Enter
        Dim pr_end_Date1 As Date = pr_end_date
        Dim pr_Start_date1 As Date = pr_Start_date
        Call ets_set_selected()
        Pr_num1.Text = CStr(pr_num)
        sys_Date.Text = String.Format("{0:d}", Today)
        ee_num.Text = selected_name_key
        ee_entry_num.Text = CStr(selected_entry_num)

        Using db As Database = New Database(top_data_path)
            Dim sql As String = "select * from nam_cc where name_key = '" & ee_num.Text & "'"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            Dim intcount As Integer = 0

            While rs.Read()
                ee_Screen_nam.Text = rs("screen_nam").ToString
                '  ee_sort_name = rs("sort_name").ToString
                ee_slot_num.Text = rs("dept_num").ToString
                ee_entry_num.Text = "1"
                avg_hrly.Text = String.Format("{0:F2}", rs("avg_hrly"))
                ee_pay_dfq.Text = rs("pay_freq").ToString
                ee_ded_dfq.Text = rs("pay_freq").ToString
                intcount = intcount + 1
            End While
            rs.Close()
        End Using

        Call calc_used_ben(ee_num.Text)

        Using db As Database = New Database(top_data_path)
            Dim sql As String = "select * from ccvac where name_key = '" & ee_num.Text & "'"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            Dim intcount As Integer = 0

            'While rs.Read()
            '    ee_rem_sick.Text = CStr(rs("max_sick").Value - (rs("used_sick").Value + time_sick))
            '    If Err.Number = 94 Then
            '        ee_rem_sick.Text = CStr(0)
            '    End If
            '    ee_rem_per.Text = CStr(rs("max_pers").Value - (rs("used_pers").Value + time_pers))
            '    If Err.Number = 94 Then
            '        ee_rem_per.Text = CStr(0)
            '    End If
            '    ee_rem_vac.Text = CStr(rs("max_vac").Value - (rs("used_vac").Value + time_vac))
            '    If Err.Number = 94 Then
            '        ee_rem_vac.Text = CStr(0)
            '    End If
            '    ee_hol_rem.Text = CStr(rs("max_hol").Value - (rs("used_hol").Value + time_hol))
            '    If Err.Number = 94 Then
            '        ee_hol_rem.Text = CStr(0)
            '    End If
            '    intcount = intcount + 1
            'End While
            rs.Close()
        End Using

        If intcount = 0 Then
            ee_rem_sick.Text = CStr(0)
            ee_rem_per.Text = CStr(0)
            ee_rem_vac.Text = CStr(0)
            ee_hol_rem.Text = CStr(0)
        End If
        Call fill_ee_array()

        Call repaint_grid(0, 0, 0)
        ee_num.Enabled = False
        Call tot_amt()
        ee_exp_hrs.Text = ee_calc_tot_hrs.Text

        ee_exp_hrs.Focus()
    End Sub

    Private Sub ee_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ee_num.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim ee_dept_num As String
        If KeyAscii = 13 Then

            valid_name = "N"
            selected_name_key = ""

            If Val(ee_num.Text) = 0 Then
                Call chkname("")
                ee_num.Text = selected_name_key
            End If

            valid_name = chkname(ee_num.Text)

            If valid_name = "N" Then
                MsgBox("Invalid client number")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            'the ee num was changed so have to get new data
            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select * from nam_cc where name_key = '" & ee_num.Text & "'"
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                Dim intcount As Integer = 0

                While rs.Read()
                    ee_Screen_nam.Text = rs("screen_nam").ToString
                    '   ee_sort_name = rs("sort_name").ToString
                    ee_slot_num.Text = rs("dept_num").ToString
                    ee_entry_num.Text = "1"
                    avg_hrly.Text = String.Format("{0:F2}", rs("avg_hrly"))
                    ee_pay_dfq.Text = rs("pay_freq").ToString
                    ee_ded_dfq.Text = rs("pay_freq").ToString
                    ee_dept_num = rs("dept_num").ToString
                    ee_entry_num.Text = "1"
                    pr_arr_job(0).Text = rs("dept_num").ToString
                    pr_arr_pcs(0).Text = "A"
                    '    pr_arr_pcs(0).Text = rs("dol_ratea").ToString
                    'scs
                    'If isnull(rs("term_Date)) then
                    '    If rs("term_Date").tostring < Today Then
                    '        MsgBox("This person has been terminated and can not be paid.")
                    '        Call ets_set_selected()
                    '        GoTo EventExitSub
                    '    End If
                    'End If
                    intcount = intcount + 1
                End While
                rs.Close()
            End Using

            'this looks up the remaining hours and paints them

            Call calc_used_ben(ee_num.Text)

            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select * from ccvac where name_key = '" & ee_num.Text & "'"
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                Dim intcount As Integer = 0

                'While rs.Read()
                '    ee_rem_sick.Text = CStr(rs("max_sick").ToString - (rs("used_sick").Value + time_sick))
                '    If Err.Number = 94 Then
                '        ee_rem_sick.Text = CStr(0)
                '    End If
                '    ee_rem_per.Text = CStr(rs("max_pers").Value - (rs("used_pers").Value + time_pers))
                '    If Err.Number = 94 Then
                '        ee_rem_per.Text = CStr(0)
                '    End If
                '    ee_rem_vac.Text = CStr(rs("max_vac").Value - (rs("used_vac").Value + time_vac))
                '    If Err.Number = 94 Then
                '        ee_rem_vac.Text = CStr(0)
                '    End If
                '    ee_hol_rem.Text = CStr(rs("max_hol").Value - (rs("used_hol").Value + time_hol))
                '    If Err.Number = 94 Then
                '        ee_hol_rem.Text = CStr(0)
                '    End If
                '    intcount = intcount + 1
                'End While
                rs.Close()
            End Using

            If intcount = 0 Then
                ee_rem_sick.Text = CStr(0)
                ee_rem_per.Text = CStr(0)
                ee_rem_vac.Text = CStr(0)
                ee_hol_rem.Text = CStr(0)
            Else
                valid_name = "Y"
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

    Private Sub ee_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ee_num.Leave
        ee_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub ee_exp_hrs_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ee_exp_hrs.Enter
        Call ets_set_selected()

    End Sub

    Private Sub ee_exp_hrs_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ee_exp_hrs.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Then
            If Not IsNumeric(ee_exp_hrs.Text) Then
                MsgBox("Not a number")
                Call ets_set_selected()
                ee_exp_hrs.Focus()
                ee_exp_hrs.SelectAll()
                GoTo EventExitSub
            End If

            If Val(ee_exp_hrs.Text) > 100 Or Val(ee_exp_hrs.Text) < 0 Then
                MsgBox("Please check your expected hours")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            ee_exp_hrs.Text = String.Format("{0:F2}", Val(ee_exp_hrs.Text))

            jeline(0).Focus()
            KeyAscii = 0
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub ee_exp_hrs_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ee_exp_hrs.Leave
        ee_exp_hrs.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub ee_pay_dfq_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ee_pay_dfq.Enter
        Call ets_set_selected()
    End Sub

    Private Sub ee_pay_dfq_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ee_pay_dfq.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            'need too check the entry and to see if each one only entered once
            ee_pay_dfq.Text = UCase(ee_pay_dfq.Text)
            'Stop
            Select Case ee_pay_dfq.Text
                Case "A"
                Case "B"
                Case "M"
                Case "W"
                Case "S"
                Case "NT"
                Case Else
                    MsgBox("Invalid entry")
                    Call ets_set_selected()
                    GoTo EventExitSub
            End Select

            'if prior is n then done and set ded dfq and go on
            If ee_pay_dfq.Text = "NT" Then
                ee_ded_dfq.Text = "ND"
                ee_exp_hrs.Focus()
                KeyAscii = 0
            Else
                ee_ded_dfq.Focus()
                KeyAscii = 0
            End If
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub ee_pay_dfq_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ee_pay_dfq.Leave
        ee_pay_dfq.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub cc_ed_time_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Click
        Dim Index As Integer
        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            pr_arr_date(CShort(max_grid_line)).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

    End Sub

    Private Sub cc_ed_time_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim M As Integer
        Dim n As Integer


        ctrform(Me)
        'sets the variables for the grid when the form is loaded
        max_grid_line = 0
        offset_grid_line = 0
        For n = 0 To 50
            For M = 0 To 15
                ee_array(M, n) = ""
            Next M
        Next n

        fill_ee_array()

    End Sub

    Private Sub cc_ed_time_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        Dim Button As Short = CShort(eventArgs.Button \ &H100000)
        Dim Shift As Short = CShort(System.Windows.Forms.Control.ModifierKeys \ &H10000)
         Dim Index As Integer

        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            pr_arr_date(CShort(max_grid_line)).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

    End Sub

    Private Sub jeline_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jeline.Enter
        Dim Index As Short = jeline.GetIndex(CType(eventSender, TextBox))
        Dim n As Integer
        'this section checks to see if you are setting the focus below the last item
        For n = 0 To 9
            jeline(CShort(n)).Text = CStr(n + 1 + offset_grid_line)
        Next n
        'sets the  linenum to next in the array
        If Val(jeline(Index).Text) = 0 Then
            If Index <> 0 Then
                jeline(Index).Text = CStr(CDbl(jeline(CShort(Index - 1)).Text) + 1)
            Else
                jeline(Index).Text = CStr(1)
            End If

        End If

        pr_arr_date(Index).Focus()
        KeyAscii = 0 'moves cursor to next field

    End Sub

    Private Sub pr_arr_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_date.Enter
        Dim Index As Short = pr_arr_date.GetIndex(CType(eventSender, TextBox))
        If Val(ee_num.Text) = 0 Then
            ee_num.Focus()
            KeyAscii = 0
        End If

        Call ets_set_selected()
        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            pr_arr_date(CShort(max_grid_line)).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

    End Sub

    Private Sub pr_arr_date_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles pr_arr_date.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = pr_arr_date.GetIndex(CType(eventSender, TextBox))
        'allows the f3 code to repeat the information
        Select Case KeyCode

            Case CShort(System.Windows.Forms.Keys.F3)

                If Index <> 0 Then
                    pr_arr_date(Index).Text = pr_arr_date(CShort(Index - 1)).Text

                    pr_arr_job(Index).Focus()
                    KeyAscii = 0
                End If

            Case CShort(System.Windows.Forms.Keys.F4)
                If Index <> 0 Then
                    pr_arr_date(Index).Text = CStr(CDbl(pr_arr_date(CShort(Index - 1)).Text) + 1)
                    pr_arr_job(Index).Focus()
                    KeyAscii = 0
                End If

            Case CShort(System.Windows.Forms.Keys.F5)
                'delete a line
                If CDbl(jeline(Index).Text) > max_grid_line Then
                    MsgBox("Line not yet entered, so it can not be deleted")
                    Exit Sub
                End If

                msg = "Do you wish to delete this line?"
                Response = MsgBox(msg, MsgBoxStyle.YesNo)
                If Response = MsgBoxResult.No Then Exit Sub
                add_sub = -1
                Call grid_change(add_sub, CInt(jeline(Index).Text), Index)

            Case CShort(System.Windows.Forms.Keys.F6)
                'insert a line
                If CDbl(jeline(Index).Text) > max_grid_line Then
                    MsgBox("This is the last line. No need to add a line. ")
                    Exit Sub
                End If

                msg = "Do you wish to insert a line before this line?"
                Response = MsgBox(msg, MsgBoxStyle.YesNo)
                If Response = MsgBoxResult.No Then Exit Sub
                add_sub = 1
                Call grid_change(add_sub, CInt(jeline(Index).Text), Index)

            Case CShort(System.Windows.Forms.Keys.F7)
                If Index <> 0 Then

                    pr_arr_date(Index).Text = pr_arr_date(CShort(Index - 1)).Text
                    pr_arr_job(Index).Text = pr_arr_job(CShort(Index - 1)).Text
                    pr_arr_loc(Index).Text = pr_arr_loc(CShort(Index - 1)).Text
                    pr_arr_rea(Index).Text = pr_arr_rea(CShort(Index - 1)).Text
                    pr_arr_hrs(Index).Text = pr_arr_hrs(CShort(Index - 1)).Text
                    pr_arr_pcs(Index).Text = pr_arr_pcs(CShort(Index - 1)).Text
                    pr_arr_dept(Index).Text = pr_arr_dept(CShort(Index - 1)).Text
                    pr_Arr_pay(Index).Text = pr_Arr_pay(CShort(Index - 1)).Text
                    pr_arr_pct(Index).Text = pr_arr_pct(CShort(Index - 1)).Text
                    'SendKeys "{ENTER}"
                    'KeyAscii = 0
                    pr_arr_pct(Index).Focus()
                    KeyAscii = 0
                End If
        End Select
    End Sub

    Private Sub pr_arr_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_arr_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = pr_arr_date.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            valid_Date = "N"
            senddate = pr_arr_date(Index).Text
            valid_Date = etsdate(senddate, valid_Date)

            If valid_Date <> "N" Then

                pr_arr_date(Index).Text = valid_Date
                pr_arr_job(Index).Focus()
                KeyAscii = 0

            Else
                MsgBox("Bad date")
                Call ets_set_selected()
                pr_arr_date(Index).Focus()
                pr_arr_date(Index).SelectAll()
                GoTo EventExitSub
            End If
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_arr_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_date.Leave
        Dim Index As Short = pr_arr_date.GetIndex(CType(eventSender, TextBox))
        pr_arr_date(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub pr_arr_hrs_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_hrs.Enter
        Dim Index As Short = pr_arr_hrs.GetIndex(CType(eventSender, TextBox))
        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            pr_arr_date(CShort(max_grid_line)).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

        Call ets_set_selected()
    End Sub

    Private Sub pr_arr_hrs_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles pr_arr_hrs.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = pr_arr_hrs.GetIndex(CType(eventSender, TextBox))
        'allows the f3 code to repeat the information
        If KeyCode = System.Windows.Forms.Keys.F3 Then
            If Index <> 0 Then
                pr_arr_hrs(Index).Text = pr_arr_hrs(CShort(Index - 1)).Text
                Call tot_amt()
                If total_hours > CDbl(ee_exp_hrs.Text) Then
                    Response = MsgBox("You have entered more hours than you expected. Do you wish to edit the number?", MsgBoxStyle.YesNo)
                    If Response = 6 Then
                        Call ets_set_selected()
                        pr_arr_hrs(Index).Focus()
                        pr_arr_hrs(Index).SelectAll()
                        Exit Sub
                    End If
                End If
                pr_arr_pcs(Index).Focus()
                KeyAscii = 0
            End If
        End If
    End Sub

    Private Sub pr_arr_hrs_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_arr_hrs.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = pr_arr_hrs.GetIndex(CType(eventSender, TextBox))

        If KeyAscii = 13 Then

            If Not IsNumeric(pr_arr_hrs(Index).Text) Then
                MsgBox("Not a number")
                Call ets_set_selected()
                pr_arr_hrs(Index).Focus()
                pr_arr_hrs(Index).SelectAll()
                KeyAscii = 0
                GoTo EventExitSub
            End If

            If Val(pr_arr_hrs(Index).Text) < 0 Then
                MsgBox("Please enter a positive amount")
                Call ets_set_selected()
                pr_arr_hrs(Index).Focus()
                pr_arr_hrs(Index).SelectAll()
                KeyAscii = 0
                GoTo EventExitSub
            End If

            ee_array(5, Index + 1 + offset_grid_line) = CStr(CDbl(pr_arr_hrs(Index).Text))
            pr_arr_hrs(Index).Text = String.Format("{0:F2}", CDbl(pr_arr_hrs(Index).Text))

            Call tot_amt()

            Select Case RTrim(pr_arr_job(Index).Text)

                Case "81808"
                    If CDbl(ee_rem_vac.Text) < total_vac + CDbl(pr_arr_hrs(Index).Text) Then
                        MsgBox("Exceeding max ccvac hours.")
                    End If

                Case "82801"
                    If CDbl(ee_rem_sick.Text) < total_sick + CDbl(pr_arr_hrs(Index).Text) Then
                        MsgBox("Exceeding max sick hours.")
                    End If

                Case "83801"
                    If CDbl(ee_hol_rem.Text) < total_hol + CDbl(pr_arr_hrs(Index).Text) Then
                        MsgBox("Exceeding max holiday hours.")
                    End If
            End Select

            If total_hours > CDbl(ee_exp_hrs.Text) Then
                Response = MsgBox("You have entered more hours than you expected. Do you wish to edit the number?", MsgBoxStyle.YesNo)
                If Response = 6 Then
                    Call ets_set_selected()
                    pr_arr_hrs(Index).Focus()
                    pr_arr_hrs(Index).SelectAll()
                    KeyAscii = 0
                    GoTo done2
                End If
            End If

            If pr_arr_rea(Index).Text = "PC" Or pr_arr_rea(Index).Text = "OP" Then
                pr_arr_pcs(Index).Focus()
                KeyAscii = 0
            Else
                pr_arr_dept(Index).Focus()
                KeyAscii = 0
            End If

        End If
done2:
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_arr_hrs_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_hrs.Leave
        Dim Index As Short = pr_arr_hrs.GetIndex(CType(eventSender, TextBox))
        pr_arr_hrs(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub pr_arr_loc_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_loc.Enter
        Dim Index As Short = pr_arr_loc.GetIndex(CType(eventSender, TextBox))
        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            pr_arr_date(CShort(max_grid_line)).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

        Call ets_set_selected()
    End Sub

    Private Sub pr_arr_loc_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles pr_arr_loc.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = pr_arr_loc.GetIndex(CType(eventSender, TextBox))
        'allows the f3 code to repeat the information
        If KeyCode = System.Windows.Forms.Keys.F3 Then
            If Index <> 0 Then
                pr_arr_loc(Index).Text = pr_arr_loc(CShort(Index - 1)).Text
                pr_arr_rea(Index).Focus()
                KeyAscii = 0
            End If
        End If
    End Sub

    Private Sub pr_arr_loc_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_arr_loc.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = pr_arr_loc.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then

            pr_arr_rea(Index).Focus()
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_arr_loc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_loc.Leave
        Dim Index As Short = pr_arr_loc.GetIndex(CType(eventSender, TextBox))
        pr_arr_loc(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub pr_arr_dept_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_dept.Enter
        Dim Index As Short = pr_arr_dept.GetIndex(CType(eventSender, TextBox))
        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            pr_arr_date(CShort(max_grid_line)).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

        Call ets_set_selected()
    End Sub

    Private Sub pr_arr_dept_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles pr_arr_dept.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = pr_arr_dept.GetIndex(CType(eventSender, TextBox))
        'allows the f3 code to repeat the information
        'removed for dept since it does calc when entered normally and changes to line number problems  1/22/10  scs

    End Sub

    Private Sub pr_arr_dept_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_arr_dept.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = pr_arr_dept.GetIndex(CType(eventSender, TextBox))
        Dim pay As Decimal
        Dim retpay As Double
        Dim retpct As Double
        If KeyAscii = 13 Then

            pr_arr_dept(Index).Text = UCase(pr_arr_dept(Index).Text)
            If pr_arr_dept(Index).Text = "NN" Then
                pr_Arr_pay(Index).Text = CStr(0)
                pr_arr_pct(Index).Text = CStr(0)
                GoTo donehere
            End If

            valid_dpt = "N"
            senddpt = pr_arr_dept(Index).Text
            retdpt = ""
            retdptdesc = ""

            valid_dpt = etsdptnum_chk(senddpt, retdpt, retdptdesc)

            If valid_dpt = "N" Then
                MsgBox("Not a valid department number.")
                Call ets_set_selected()
                pr_arr_dept(Index).Focus()
                pr_arr_dept(Index).SelectAll()
                KeyAscii = 0
                GoTo EventExitSub
            End If

            pr_arr_dept(Index).Text = valid_dpt

            Dim paynums As List(Of Decimal)
            If pr_arr_pcs(Index).Text.Length = 0 Then pr_arr_pcs(Index).Text = "0"

            paynums = calc_cc_pay(pr_arr_job(Index).Text, pr_arr_rea(Index).Text, CInt(pr_arr_pcs(Index).Text), CDec(pr_arr_hrs(Index).Text), ee_num.Text, CDec(retpay.ToString), CDec(retpct.ToString))

            retpay = paynums(0)
            retpct = paynums(1)

            If pr_arr_dept(Index).Text = "NN" Then
                'pct = 0
                pay = 0
            End If

            pr_Arr_pay(Index).Text = String.Format("{0:f2}", retpay)

            pr_arr_pct(Index).Text = String.Format("{0:f2}", retpct * 100)
            ee_array(9, Index + 1 + offset_grid_line) = CStr(Val(pr_Arr_pay(Index).Text))

            Call tot_amt()

donehere:

            If pr_arr_rea(Index).Text = "SD" Or pr_arr_rea(Index).Text = "SI" Or pr_arr_rea(Index).Text = "SP" Or pr_arr_rea(Index).Text = "ST" Then
                pr_Arr_pay(Index).Enabled = True
                pr_arr_pct(Index).Text = CStr(0)
                pr_Arr_pay(Index).Focus()
                KeyAscii = 0
            Else

                pr_arr_pct(Index).Focus()
                KeyAscii = 0
            End If
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_arr_dept_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_dept.Leave
        Dim Index As Short = pr_arr_dept.GetIndex(CType(eventSender, TextBox))
        pr_arr_dept(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub pr_Arr_pay_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_Arr_pay.Enter
        Dim Index As Short = pr_Arr_pay.GetIndex(CType(eventSender, TextBox))
        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            pr_arr_date(CShort(max_grid_line)).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

        Call ets_set_selected()
    End Sub

    Private Sub pr_Arr_pay_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles pr_Arr_pay.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = pr_Arr_pay.GetIndex(CType(eventSender, TextBox))
        'allows the f3 code to repeat the information
        If KeyCode = System.Windows.Forms.Keys.F3 Then
            If Index <> 0 Then
                pr_Arr_pay(Index).Text = pr_Arr_pay(CShort(Index - 1)).Text
                Call tot_amt()
                pr_arr_pct(Index).Focus()
                KeyAscii = 0
            End If
        End If
    End Sub

    Private Sub pr_Arr_pay_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_Arr_pay.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = pr_Arr_pay.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then

            If Not IsNumeric(pr_Arr_pay(Index).Text) Then
                MsgBox("Not a number")
                Call ets_set_selected()
                pr_Arr_pay(Index).Focus()
                pr_Arr_pay(Index).SelectAll()
                KeyAscii = 0
                GoTo EventExitSub
            End If

            If pr_Arr_pay(Index).Text < CStr(0.01) Then
                MsgBox("Please enter a positive amount")
                Call ets_set_selected()
                pr_Arr_pay(Index).Focus()
                pr_Arr_pay(Index).SelectAll()
                KeyAscii = 0
                GoTo EventExitSub
            End If

            ee_array(9, Index + 1 + offset_grid_line) = CStr(Val(pr_Arr_pay(Index).Text))
            pr_Arr_pay(Index).Text = String.Format("{0:F2}", CDbl(pr_Arr_pay(Index).Text))

            Call tot_amt()

            pr_arr_pct(Index).Focus()
            KeyAscii = 0
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_Arr_pay_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_Arr_pay.Leave
        Dim Index As Short = pr_Arr_pay.GetIndex(CType(eventSender, TextBox))
        pr_Arr_pay(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub pr_arr_pcs_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_pcs.Enter
        Dim Index As Short = pr_arr_pcs.GetIndex(CType(eventSender, TextBox))
        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            pr_arr_date(CShort(max_grid_line)).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

        Call ets_set_selected()
    End Sub

    Private Sub pr_arr_pcs_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles pr_arr_pcs.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = pr_arr_pcs.GetIndex(CType(eventSender, TextBox))
        'allows the f3 code to repeat the information
        If KeyCode = System.Windows.Forms.Keys.F3 Then
            If Index <> 0 Then
                pr_arr_pcs(Index).Text = pr_arr_pcs(CShort(Index - 1)).Text
                pr_arr_dept(Index).Focus()
                KeyAscii = 0
            End If
        End If
    End Sub

    Private Sub pr_arr_pcs_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_arr_pcs.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = pr_arr_pcs.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            If pr_arr_rea(Index).Text = "PC" Then
                If Not IsNumeric(pr_arr_pcs(Index).Text) Then
                    MsgBox("Please enter a number.")
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If
            End If

            If Val(pr_arr_pcs(Index).Text) > 1000 Then
                MsgBox("You have entered more than 1000 pieces.")
            End If

            If Len(pr_arr_pcs(Index).Text) = 0 Then
                pr_arr_pcs(Index).Text = CStr(0)
            End If

            ee_array(6, Index + 1 + offset_grid_line) = CStr(CDbl(Val(pr_arr_pcs(Index).Text)))

            Call tot_amt()

            pr_arr_dept(Index).Focus()
            KeyAscii = 0
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_arr_pcs_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_pcs.Leave
        Dim Index As Short = pr_arr_pcs.GetIndex(CType(eventSender, TextBox))
        pr_arr_pcs(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub pr_arr_rea_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_rea.Enter
        Dim Index As Short = pr_arr_rea.GetIndex(CType(eventSender, TextBox))
        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            pr_arr_date(CShort(max_grid_line)).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

        Call ets_set_selected()
    End Sub

    Private Sub pr_arr_rea_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles pr_arr_rea.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = pr_arr_rea.GetIndex(CType(eventSender, TextBox))
        'allows the f3 code to repeat the information
        If KeyCode = System.Windows.Forms.Keys.F3 Then
            If Index <> 0 Then
                pr_arr_rea(Index).Text = pr_arr_rea(CShort(Index - 1)).Text
                ee_array(4, Index + 1 + offset_grid_line) = pr_arr_rea(Index).Text
                pr_arr_hrs(Index).Focus()
                KeyAscii = 0
            End If
        End If
    End Sub

    Private Sub pr_arr_rea_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_arr_rea.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = pr_arr_rea.GetIndex(CType(eventSender, TextBox))

        If KeyAscii = 13 Then
            'look up for valid reason code and move in nonhourly
            If Len(RTrim(pr_arr_rea(Index).Text)) = 0 Then
                'go to lookup reason codes
                'Screen.ActiveForm.Hide
                pclasslkup.ShowDialog()

                pr_arr_rea(Index).Text = selected_lookup_num
            Else

                '    Call CheckYN("cc_paycl", "pay_class", pr_arr_rea(Index).Text, valid_name)
                If valid_name = "N" Then
                    MsgBox("Not a valid pay class code")
                    Call ets_set_selected()
                    pr_arr_rea(Index).Focus()
                    pr_arr_rea(Index).SelectAll()
                    KeyAscii = 0
                    GoTo EventExitSub
                End If
            End If

            If selected_lookup_desc = "N" Then
                pr_arr_hrs(Index).Text = ""

                pr_arr_pcs(Index).Text = ""
                pr_Arr_pay(Index).Focus()
                KeyAscii = 0
            Else
                ee_array(4, Index + 1 + offset_grid_line) = pr_arr_rea(Index).Text
                pr_arr_hrs(Index).Focus()
                KeyAscii = 0
            End If
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_arr_rea_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_rea.Leave
        Dim Index As Short = pr_arr_rea.GetIndex(CType(eventSender, TextBox))
        pr_arr_rea(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub pr_arr_job_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_job.Enter
        Dim Index As Short = pr_arr_job.GetIndex(CType(eventSender, TextBox))
        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            'pr_arr_date(max_grid_line).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

        Call ets_set_selected()
        ed_comp.Enabled = False
    End Sub

    Private Sub pr_arr_job_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles pr_arr_job.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = pr_arr_job.GetIndex(CType(eventSender, TextBox))
        If KeyCode = System.Windows.Forms.Keys.F3 Then

            If Index <> 0 Then
                pr_arr_job(Index).Text = pr_arr_job(CShort(Index - 1)).Text
                pr_arr_loc(Index).Focus()
                KeyAscii = 0
            End If
        End If

    End Sub

    Private Sub pr_arr_job_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_arr_job.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = pr_arr_job.GetIndex(CType(eventSender, TextBox))
        Dim retloc As String
        Dim retpycl As String

        If KeyAscii = 13 Or KeyAscii = 9 Then
            pr_arr_job(Index).Text = UCase(pr_arr_job(Index).Text)
            selected_lookup_num = ""
            valid_job = "N"
            retpycl = ""
            retloc = ""
            sendjob = RTrim(pr_arr_job(Index).Text)
            pr_arr_pcs(Index).Text = "" 'to clear the pcs field if changed
            If sendjob.Length = 0 Then
                Dim jobnumlookup As New jobnumlookup
                jobnumlookup.ShowDialog()
                valid_job = "Y"
                pr_arr_job(Index).Text = selected_job_num

            End If

            jobdata = etsjobnum_chk(pr_arr_job(Index).Text)

            If jobdata(0) = "N" Then
                MsgBox("Invalid job number")
                Call ets_set_selected()
                pr_arr_job(Index).Focus()
                pr_arr_job(Index).SelectAll()
                KeyAscii = 0
                GoTo EventExitSub
            End If


            retpycl = jobdata(1).ToString
            retjobdesc = jobdata(2).ToString

            If Len(selected_lookup_num) <> 0 Then
                pr_arr_job(Index).Text = selected_lookup_num
                pr_arr_rea(Index).Text = retpycl
            Else
                pr_arr_job(Index).Text = pr_arr_job(Index).Text
                pr_arr_rea(Index).Text = retpycl
            End If

            pr_arr_loc(Index).Text = retjobdesc
            'here we check for duplicate iof namekey,date, and job
            If retpycl = "SI" Or retpycl = "SD" Or retpycl = "SP" Or retpycl = "ST" Then
                pr_Arr_pay(Index).Enabled = True
            End If

            'If retpycl = "DP" Or retpycl = "IP" Then
            '    tmpdb = DAODBEngine_definst.OpenDatabase(cc_data_path & "cc.mdb")

            '    tmp2set = tmpdb.OpenRecordset("cc_clijob", dao.RecordsetTypeEnum.dbOpenDynaset)

            '    tmp2set.FindFirst("name_key = " & Chr(34) & ee_num.Text & Chr(34) & "and job_num = " & Chr(34) & pr_arr_job(Index).Text & Chr(34))

            '    If tmp2set.NoMatch Then
            '        Response = MsgBox("This is not a valid job number for this employee. Do you wish to make it valid?")
            '        If Response = 6 Then
            '            'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '            selected_name_key = ee_num.Text
            '            selected_job_num = pr_arr_job(Index).Text
            '            entry_type = "ADD"
            '            frmclijob.ShowDialog()
            '            pr_arr_job(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

            '        Else
            '            Call ets_set_selected()
            '            GoTo EventExitSub
            '        End If

            '    End If
            'End If

            If Len(pr_arr_loc(Index).Text) <> 0 Then
                pr_arr_hrs(Index).Focus()
                KeyAscii = 0
            Else
                pr_arr_loc(Index).Focus()
                KeyAscii = 0
            End If

        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_arr_job_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_job.Leave
        Dim Index As Short = pr_arr_job.GetIndex(CType(eventSender, TextBox))
        pr_arr_job(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub pr_arr_pct_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_pct.Enter
        Dim Index As Short = pr_arr_pct.GetIndex(CType(eventSender, TextBox))
        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            'pr_arr_date(max_grid_line).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If
        Call ets_set_selected()
    End Sub

    Private Sub pr_arr_pct_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles pr_arr_pct.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = pr_arr_pct.GetIndex(CType(eventSender, TextBox))
        'allows the f3 code to repeat the information
        If KeyCode = System.Windows.Forms.Keys.F3 Then
            If Index <> 0 Then
                pr_arr_pct(Index).Text = pr_arr_pct(CShort(Index - 1)).Text

            End If
        End If
    End Sub

    Private Sub pr_arr_pct_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_arr_pct.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = pr_arr_pct.GetIndex(CType(eventSender, TextBox))

        If KeyAscii = 13 Then

            If CDbl(pr_arr_pct(Index).Text) > 100 Then
                Beep()
                Beep()
            End If

            Call tot_amt()

            'checks the total hours one last time
            If total_hours > CDbl(ee_exp_hrs.Text) Then
                Response = MsgBox("You have entered more hours than you expected. Do you wish to edit the number?", MsgBoxStyle.YesNo)
                If Response = 6 Then
                    Call ets_set_selected()
                    pr_arr_hrs(Index).Focus()
                    pr_arr_hrs(Index).SelectAll()
                    KeyAscii = 0
                    GoTo EventExitSub
                End If
            End If

            wline = 0

            'data pushed to array but arrray starts at 1 not 0

            ee_array(0, Index + 1 + offset_grid_line) = jeline(Index).Text
            ee_array(1, Index + 1 + offset_grid_line) = pr_arr_date(Index).Text
            ee_array(2, Index + 1 + offset_grid_line) = pr_arr_job(Index).Text
            ee_array(3, Index + 1 + offset_grid_line) = pr_arr_loc(Index).Text
            ee_array(4, Index + 1 + offset_grid_line) = pr_arr_rea(Index).Text
            ee_array(5, Index + 1 + offset_grid_line) = CStr(CDbl(Val(pr_arr_hrs(Index).Text)))
            ee_array(6, Index + 1 + offset_grid_line) = pr_arr_pcs(Index).Text
            'ee_array(7, Index + 1 + offset_grid_line) = pr_arr_pcs(Index).Text
            ee_array(8, Index + 1 + offset_grid_line) = pr_arr_dept(Index).Text
            ee_array(9, Index + 1 + offset_grid_line) = CStr(Val(pr_Arr_pay(Index).Text))
            ee_array(10, Index + 1 + offset_grid_line) = CStr(CDbl(pr_arr_pct(Index).Text) / 100)

            'sets the maxgrid line to max in the array
            If max_grid_line < Val(jeline(Index).Text) Then
                max_grid_line = CInt(jeline(Index).Text)
            End If


            If Index = 9 Then
                offset_grid_line = offset_grid_line + 1
                Call repaint_grid(offset_grid_line, wline, 9)
                jeline(9).Focus()
                KeyAscii = 0
                GoTo EventExitSub
            End If

            jeline(CShort(Index + 1)).Focus()
            KeyAscii = 0

            '    End If  'for tot hours = exp hrs

        End If 'for key =13
done1:

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_arr_pct_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_pct.Leave
        Dim Index As Short = pr_arr_pct.GetIndex(CType(eventSender, TextBox))
        pr_arr_pct(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        ed_comp.Enabled = True

    End Sub

    Private Sub sdown_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sdown.Click
        Dim Index As Integer
        wline = 0
        If max_grid_line < 9 Then Exit Sub

        offset_grid_line = offset_grid_line - 1
        If offset_grid_line > (max_grid_line - 7) Then offset_grid_line = max_grid_line - 7
        If offset_grid_line < 0 Then offset_grid_line = 0

        Call repaint_grid(offset_grid_line, wline, Index)

    End Sub

    Private Sub sup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sup.Click
        Dim Index As Integer = 0
        wline = 0
        If max_grid_line < 9 Then Exit Sub

        offset_grid_line = offset_grid_line + 1

        If offset_grid_line > max_grid_line - 10 Then
            offset_grid_line = max_grid_line - 8
        End If

        If offset_grid_line > (max_grid_line - 7) Then offset_grid_line = max_grid_line - 7
        If offset_grid_line < 0 Then offset_grid_line = 0

        Call repaint_grid(offset_grid_line, wline, CInt(Index))

    End Sub

    Public Sub LoadCCTime()

        For n As Integer = 1 To max_grid_line
            'get blank cctime and fill it
            Dim NewCC As New cctimeData
            NewCC = ETSSQLCC.GetBlankCCTimeData
            NewCC.EntryDate = CDate(sys_Date.Text)
            NewCC.PayNum = pr_num
            NewCC.NameKey = ee_num.Text
            NewCC.ScreenNam = ee_Screen_nam.Text
            NewCC.EntryNum = CInt(Val(ee_entry_num.Text))
            NewCC.LineNum = CInt(Val(ee_array(0, n))) '+ Val(CStr(last_line_num)))
            NewCC.PayFreq = ee_pay_dfq.Text
            NewCC.DedDfq = ee_ded_dfq.Text
            NewCC.ActDate = CDate(ee_array(1, n))
            NewCC.JobNum = ee_array(2, n)
            NewCC.PayClass = ee_array(4, n)
            NewCC.Hours = CDec(ee_array(5, n))
            NewCC.PcsProd = CDec(ee_array(6, n))
            NewCC.DeptNum = ee_array(8, n)
            NewCC.PayDol = CDec(ee_array(9, n))
            NewCC.ClPct = CDec(ee_array(10, n))
            NewCC.SortName = selected_sort_name
            NewCC.EncumDate = Today
            sqlstmnt = "insert into cctime " & NewCC.cctimeColumnNames & " values " & NewCC.cctimeColumnData & ""
            ETSSQL.ExecuteSQL(sqlstmnt)
        Next

    End Sub


End Class