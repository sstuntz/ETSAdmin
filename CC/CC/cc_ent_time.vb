Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility
Imports Microsoft.VisualBasic.Conversion
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Data.SqlClient
Imports System.Configuration


Friend Class cc_ent_time
    Inherits System.Windows.Forms.Form
    '****************
    'revision History
    'original date of this form is 6/23/96 -SCS

    '****************
    Dim ee_array(15, 100) As String
    Dim offset_grid_line As Integer
    Dim max_grid_line As Short
    Public total_amount As Double
    Public total_hours As Double
    Public total_pieces As Double
    Public total_vac As Double
    Public total_pers As Double
    Public total_sick As Double
    Public total_hol As Double

    Public wline As Integer
    Public add_sub As Integer
    Public oldfocus As Integer
    Dim a(15) As String
    Public last_line_num As Integer

    Public retpay As Double
    Public retpct As Double
    Public pay As Double
    Public pct As Double
    Public jobdata As List(Of String)


    Sub tot_amt()
        Dim n As Integer = 0
        total_amount = 0
        total_hours = 0
        total_hol = 0
        total_vac = 0
        total_sick = 0
        total_pers = 0
        valid_lookup = "Y"
        total_pieces = 0

        For n = 1 To max_grid_line + 1
            total_amount = total_amount + Val(ee_array(9, n))
            total_hours = total_hours + Val(ee_array(5, n))
            total_pieces = total_pieces + Val(ee_array(6, n))
            If Val(ee_array(2, n)) = 83801 Then total_hol = total_hol + Val(ee_array(5, n))
            If Val(ee_array(2, n)) = 84 Then total_pers = total_pers + Val(ee_array(5, n))
            If Val(ee_array(2, n)) = 82801 Then total_sick = total_sick + Val(ee_array(5, n))
            If Val(ee_array(2, n)) = 81808 Then total_vac = total_vac + Val(ee_array(5, n))

        Next n

        ee_calc_tot_pay.Text = VB6.Format(total_amount, "###0.00;-###0.00")
        ee_calc_tot_hrs.Text = VB6.Format(total_hours, "###0.00")
        ee_calc_tot_pcs.Text = VB6.Format(total_pieces, "#####0.0")

    End Sub

    Sub grid_change(ByVal add_sub As Integer, ByVal wline As Integer, ByVal oldfocus As Integer)
        Dim n As Integer
        Dim i As Integer

        Select Case add_sub
            Case 1 'if add_sub is 1 then add a line from here out

                max_grid_line = CShort(max_grid_line + 1)

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
                    max_grid_line = CShort(max_grid_line - 1)

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

                max_grid_line = CShort(max_grid_line - 1)
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
        Dim i As Short

        'recalc the offset grid line to keep the focus on the same physical line
        'and for the new line to be sensible

        'line renumbering done on jeline getting the focus

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
            pr_arr_pct(i).Text = VB6.Format(ee_array(10, i + 1 + offset_grid_line), "##0.00")

        Next i
        jeline(CShort(oldfocus)).Focus()

        KeyAscii = 0
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cancel.Click
        Me.Close()
    End Sub

    Private Sub ee_ded_dfq_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ee_ded_dfq.Enter
        Call ets_set_selected()
    End Sub

    Private Sub ee_ded_dfq_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ee_ded_dfq.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then

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
        If KeyAscii = 13 Or KeyAscii = 9 Then
            If CDbl(ee_entry_num.Text) > 1 Then
                Response = MsgBox("This is for check #" & ee_entry_num.Text & " for this employee for this payroll run", MsgBoxStyle.YesNo)
                If Response = 7 Then
                    Call ets_set_selected()
                    GoTo EventExitSub
                Else
                    'reset the line counters
                    last_line_num = 0

                End If

            End If

            ee_exp_hrs.Focus()
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
        Dim Index As Short

        If Index >= 0 And Index <= 9 Then
            jeline(Index).Enabled = True
        End If

        pr_Start_date1.Text = CStr(pr_Start_date)
        pr_end_Date1.Text = CStr(pr_end_date)
        Pr_num1.Text = CStr(pr_num)
        sys_Date.Text = CStr(Today)

        Call ets_set_selected()

    End Sub

    Private Sub ee_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ee_num.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim tot_hrs As Double 'added to show prev hrs ent 7/13/04 for mcw by lhw
        If KeyAscii = 13 Or KeyAscii = 9 Then
            last_line_num = 0 'reset the key if looking up someone else

            valid_name = "N"
            selected_name_key = ""

            If Val(ee_num.Text) = 0 Then
                Dim frmnamechk As New NameAddr.frmnamechk
                frmnamechk.ShowDialog()
                ee_num.Text = selected_name_key
                valid_name = "Y"
            Else
                valid_name = chkname(CInt(Val(ee_num.Text)))
            End If

            If valid_name = "N" Then
                MsgBox("Invalid client number")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
                Dim sql As String = "select * from nam_cc where name_key = '" & ee_num.Text & "'"
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                Dim intcount As Integer = 0

                While rs.Read()
                    ee_Screen_nam.Text = rs("screen_nam").ToString
                    '   ee_sort_name.text = rs("sort_name").ToString
                    ee_dept_num.Text = rs("dept_num").ToString
                    ee_entry_num.Text = "1"
                    avg_hrly.Text = VB6.Format(rs("avg_hrly").ToString, "####0.00")
                    ee_pay_dfq.Text = rs("pay_freq").ToString
                    ee_ded_dfq.Text = rs("pay_freq").ToString
                    'scs
                    'If isnull(rs("term_Date)) then
                    '    If rs("term_Date").Value < Today Then
                    '        MsgBox("This person has been terminated and can not be paid.")
                    '        Call ets_set_selected()
                    '        GoTo EventExitSub
                    '    End If
                    'End If
                    intcount = intcount + 1
                End While
                rs.Close()
            End Using

            If intcount = 0 Then
                valid_name = "N"
                MsgBox("Not a valid client number")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                valid_name = "Y"
            End If
            Call calc_used_ben(ee_num.Text)


            Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
                Dim sql As String = "select * from ccvac where name_key = '" & ee_num.Text & "'"
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                Dim intcount As Integer = 0

                While rs.Read()
                    ee_rem_sick.Text = CStr(Val(rs("max_sick")) - Val(rs("used_sick")) + time_sick)
                    If Err.Number = 94 Then
                        ee_rem_sick.Text = CStr(0)
                    End If
                    ee_rem_per.Text = CStr(Val(rs("max_pers")) - Val(rs("used_pers")) + time_pers)
                    If Err.Number = 94 Then
                        ee_rem_per.Text = CStr(0)
                    End If
                    ee_rem_vac.Text = CStr(Val(rs("max_vac")) - Val(rs("used_vac")) + time_vac)
                    If Err.Number = 94 Then
                        ee_rem_vac.Text = CStr(0)
                    End If
                    ee_hol_rem.Text = CStr(Val(rs("max_hol")) - Val(rs("used_hol")) + time_hol)
                    If Err.Number = 94 Then
                        ee_hol_rem.Text = CStr(0)
                    End If
                    intcount = intcount + 1
                End While
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

            sqlstmnt = "select * from cctime where paid <> 'Y'"
            sqlstmnt = sqlstmnt & " and pay_num = " & Pr_num1.Text 'v6 a number
            sqlstmnt = sqlstmnt & " and name_key = '" & ee_num.Text & "' order by line_num desc"

            Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
                Dim sql As String = sqlstmnt
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                Dim intcount As Integer = 0
                tot_hrs = 0
                While rs.Read()
                    last_line_num = CInt(Val(rs("line_num")))

                    ee_Screen_nam.Text = rs("screen_nam").ToString
                    ' ee_sort_name = rs("sort_name").ToString
                    ee_dept_num.Text = rs("dept_num").ToString
                    ee_entry_num.Text = "1"
                    '   avg_hrly.Text = VB6.Format(rs("avg_hrly").ToString, "####0.00")
                    ee_pay_dfq.Text = rs("pay_freq").ToString
                    ee_ded_dfq.Text = rs("pay_freq").ToString
                    tot_hrs = tot_hrs + Val(rs("hours"))
                    intcount = intcount + 1
                End While
                rs.Close()
            End Using

            If intcount = 0 Then
                System.Windows.Forms.SendKeys.Send("{TAB}")
                KeyAscii = 0
                GoTo EventExitSub
            Else
                MsgBox("There is an unpaid entry for this person.  This detail will be added at line = " & last_line_num + 1)
                MsgBox(" Hours Entered Previously = " & tot_hrs)
                ee_exp_hrs.Focus()
                valid_name = "Y"
            End If
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
        If KeyAscii = 13 Or KeyAscii = 9 Then
            If Not IsNumeric(ee_exp_hrs.Text) Then
                MsgBox("Not a number")
                Call ets_set_selected()
                GoTo EventExitSub
            End If
            ee_exp_hrs.Text = VB6.Format(ee_exp_hrs.Text, "######.00;-######.00")

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
        ee_pay_dfq.Text = UCase(ee_pay_dfq.Text)

        Select Case ee_pay_dfq.Text
            Case "A"
            Case "B"
            Case "M"
            Case "W"
            Case "S"
            Case "NT"
            Case Else
                MsgBox("Invalid entry")
                ee_pay_dfq.Focus()
        End Select

        ee_pay_dfq.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        Call ets_set_selected()

    End Sub

    Private Sub cc_ent_time_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Click
        Dim Index As Short
        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            pr_arr_date(CShort(max_grid_line)).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

    End Sub

    Private Sub cc_ent_time_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
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
        function_type = "DATA_ENTRY"
        num_cards.Text = CStr(0)


    End Sub

    Private Sub cc_ent_time_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        Dim Button As Short = CShort(eventArgs.Button \ &H100000)
        Dim Shift As Short = CShort(System.Windows.Forms.Control.ModifierKeys \ &H10000)
        Dim X As Single = CSng(VB6.PixelsToTwipsX(eventArgs.X))
        Dim Y As Single = CSng(VB6.PixelsToTwipsY(eventArgs.Y))
        Dim Index As Integer

        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            pr_arr_date(CShort(max_grid_line)).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

    End Sub

    Private Sub jeline_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jeline.Enter
        Dim Index As Short = jeline.GetIndex(CType(eventSender, TextBox))
        Dim n As Short
        'this section checks to see if you are setting the focus below the last item
        For n = 0 To 9
            jeline(n).Text = CStr(n + 1 + offset_grid_line)
        Next n

        'sets the  linenum to next in the array
        If Val(jeline(Index).Text) = 0 Then
            If Index <> 0 Then
                jeline(Index).Text = CStr(CDbl(jeline(CShort(Index - 1)).Text) + 1)
            Else
                jeline(Index).Text = CStr(1)
            End If

        End If
        If Val(ee_num.Text) = 0 Then

            ee_num.Focus()
        Else

            On Error Resume Next
            pr_arr_date(Index).Focus()
            On Error GoTo 0

            KeyAscii = 0 'moves cursor to next field
        End If

    End Sub

    Private Sub pr_arr_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_date.Enter
        Dim Index As Short = pr_arr_date.GetIndex(CType(eventSender, TextBox))

        Call ets_set_selected()
        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            pr_arr_date((max_grid_line)).Focus() 'set focus at the end of the latest line
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
        If KeyAscii = 13 Or KeyAscii = 9 Then
            valid_Date = "N"
            senddate = pr_arr_date(Index).Text
            valid_Date = etsdate(senddate, valid_Date)

            If valid_Date <> "N" Then
                retdate = CDate(valid_Date)
                ' to test if in a valid date range
                If CDate(retdate) < pr_Start_date Or CDate(retdate) > pr_end_date Then
                    Response = MsgBox("Date is out of the range. Do you wish to edit it?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, MsgBoxStyle))
                    If Response = 6 Then
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                End If
                pr_arr_date(Index).Text = retdate.ToString
                pr_arr_date(Index).Text = CStr(CDate(pr_arr_date(Index).Text))
                pr_arr_job(Index).Focus()
                KeyAscii = 0

            Else
                MsgBox("Bad date")
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

    Private Sub pr_arr_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_date.Leave
        Dim Index As Short = pr_arr_date.GetIndex(CType(eventSender, TextBox))
        pr_arr_date(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub pr_arr_hrs_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_arr_hrs.Enter
        Dim Index As Short = pr_arr_hrs.GetIndex(CType(eventSender, TextBox))
        'checks to make sure not below lines allready entered
        If Index > max_grid_line Then
            pr_arr_date(max_grid_line).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

        Call ets_set_selected()

        If pr_arr_rea(Index).Text = "SP" Then
            pr_arr_hrs(Index).Text = CStr(0)
            pr_arr_dept(Index).Focus()
            KeyAscii = 0
        End If

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
                        Exit Sub
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
        End If

    End Sub

    Private Sub pr_arr_hrs_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_arr_hrs.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = pr_arr_hrs.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then


            If Not IsNumeric(pr_arr_hrs(Index).Text) Then
                MsgBox("Not a number")
                Call ets_set_selected()
                pr_arr_hrs(Index).Focus()
                KeyAscii = 0
                GoTo EventExitSub
            End If

            If pr_arr_hrs(Index).Text < CStr(0.0#) Then 'was.01 changed 11/14/2008 lhw for HMEA
                MsgBox("Please enter a positive amount, or Zero.")
                Call ets_set_selected()
                pr_arr_hrs(Index).Focus()
                KeyAscii = 0
                GoTo EventExitSub
            End If

            ee_array(5, Index + 1 + offset_grid_line) = CStr(CDbl(pr_arr_hrs(Index).Text))
            pr_arr_hrs(Index).Text = VB6.Format(pr_arr_hrs(Index).Text, "###0.00;-###0.00")

            Call tot_amt()

            Select Case Trim(pr_arr_job(Index).Text)

                Case "81808"
                    If CDbl(ee_rem_vac.Text) < total_vac + CDbl(pr_arr_hrs(Index).Text) Then
                        MsgBox(" Exceeding max vacation hours.")
                    End If

                Case "82801" ', 85"
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
                    KeyAscii = 0
                    GoTo done2
                End If
            End If

            'not sure this is needed
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
            pr_arr_date(max_grid_line).Focus() 'set focus at the end of the latest line
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
        If KeyAscii = 13 Or KeyAscii = 9 Then

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
            pr_arr_date(max_grid_line).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

        pr_arr_dept(Index).Text = ee_dept_num.Text
        Call ets_set_selected()
    End Sub

    Private Sub pr_arr_dept_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles pr_arr_dept.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = pr_arr_dept.GetIndex(CType(eventSender, TextBox))
        Dim pay As Double
        Dim pct As Double
        Dim i As Integer

        'allows the f3 code to repeat the information
        If KeyCode = System.Windows.Forms.Keys.F3 Then
            If Index <> 0 Then
                Dim paynums As List(Of Decimal)
                paynums = calc_cc_pay(pr_arr_job(Index).Text, pr_arr_rea(Index).Text, CInt(pr_arr_pcs(Index).Text), CDec(pr_arr_hrs(Index).Text), ee_num.Text, CDec(retpay.ToString), CDec(retpct.ToString))

                pay = paynums(0)
                pct = paynums(1)

                If pr_arr_dept(Index).Text = "NN" Then
                    pct = 0
                    pay = 0
                End If

                pr_Arr_pay(Index).Text = VB6.Format(retpay, "fixed")

                pr_arr_pct(Index).Text = VB6.Format(retpct * 100, "##0.00")
                If Val(pr_arr_pct(Index).Text) > 100 Then
                    For i = 1 To 3 ' Loop 3 times.
                        Beep() ' Sound a tone.
                    Next i
                End If

                ee_array(9, Index + 1 + offset_grid_line) = CStr(Val(pr_Arr_pay(Index).Text))
                'pr_Arr_pay(Index) = Format(pr_Arr_pay(Index), "#,##0.00;-#,##0.00")

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
        End If
    End Sub

    Private Sub pr_arr_dept_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_arr_dept.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = pr_arr_dept.GetIndex(CType(eventSender, TextBox))
        Dim pay As Double
        Dim i As Integer

        If KeyAscii = 13 Or KeyAscii = 9 Then
            pr_arr_dept(Index).Text = UCase(pr_arr_dept(Index).Text)
            If pr_arr_dept(Index).Text = "NN" Then
                pr_Arr_pay(Index).Text = CStr(0)
                pr_arr_pct(Index).Text = VB6.Format(0 * 100, "##0.00")
                pr_arr_pct(Index).Focus()
                KeyAscii = 0

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
                KeyAscii = 0
                GoTo EventExitSub
            End If

            pr_arr_dept(Index).Text = senddpt

            If Len(Trim(pr_arr_pcs(Index).Text)) = 0 Then
                pr_arr_pcs(Index).Text = CStr(0)
            End If

            If pr_arr_rea(Index).Text = "SD" Or pr_arr_rea(Index).Text = "SI" Or pr_arr_rea(Index).Text = "SP" Or pr_arr_rea(Index).Text = "ST" Then
                pr_Arr_pay(Index).Enabled = True
                pr_Arr_pay(Index).Focus()
                KeyAscii = 0
            Else
                Dim paynums As List(Of Decimal)
                paynums = calc_cc_pay(pr_arr_job(Index).Text, pr_arr_rea(Index).Text, CInt(pr_arr_pcs(Index).Text), CDec(pr_arr_hrs(Index).Text), ee_num.Text, CDec(retpay.ToString), CDec(retpct.ToString))

                pay = paynums(0)
                pct = paynums(1)


                If pr_arr_dept(Index).Text = "NN" Then
                    pct = 0
                    pay = 0
                End If

                pr_Arr_pay(Index).Text = VB6.Format(pay, "fixed")

                pr_arr_pct(Index).Text = VB6.Format(pct * 100, "##0.00")

                If Val(pr_arr_pct(Index).Text) > 100 Then
                    For i = 1 To 3 ' Loop 3 times.
                        Beep() ' Sound a tone.
                    Next i
                End If

                ee_array(9, Index + 1 + offset_grid_line) = CStr(Val(pr_Arr_pay(Index).Text))
                'pr_Arr_pay(Index) = Format(pr_Arr_pay(Index), "#,##0.00;-#,##0.00")
                pr_arr_pct(Index).Focus()
                KeyAscii = 0
            End If

donehere:

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
            pr_arr_date(max_grid_line).Focus() 'set focus at the end of the latest line
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
        If KeyAscii = 13 Or KeyAscii = 9 Then

            If Not IsNumeric(pr_Arr_pay(Index).Text) Then
                MsgBox("Not a number")
                Call ets_set_selected()
                pr_Arr_pay(Index).Focus()
                KeyAscii = 0
                GoTo EventExitSub
            End If
            ee_array(9, Index + 1 + offset_grid_line) = CStr(Val(pr_Arr_pay(Index).Text))
            pr_Arr_pay(Index).Text = VB6.Format(pr_Arr_pay(Index).Text, "###0.00;-###0.00")

            Call tot_amt()

            pr_arr_pct(Index).Text = VB6.Format(0 * 100, "##0.00")

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
            pr_arr_date(max_grid_line).Focus() 'set focus at the end of the latest line
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
        If KeyAscii = 13 Or KeyAscii = 9 Then
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
            pr_arr_date(max_grid_line).Focus() 'set focus at the end of the latest line
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

        If KeyAscii = 13 Or KeyAscii = 9 Then

            pr_arr_rea(Index).Text = UCase(pr_arr_rea(Index).Text)
            'look up for valid reason code and move in nonhourly
            If Len(pr_arr_rea(Index).Text) = 0 Then
                'go to lookup reason codes
                ' pclasslookup.ShowDialog()
                pr_arr_rea(Index).Text = selected_lookup_num
            Else
                Call ETSCommon.ETSCommon.CheckOnceYN("cc_paycl", "pay_class", pr_arr_rea(Index).Text, valid_name)
                If valid_name = "N" Then
                    MsgBox("Not a valid pay class code")
                    Call ets_set_selected()
                    pr_arr_rea(Index).Focus()
                    KeyAscii = 0
                    GoTo EventExitSub
                End If
            End If
            'scs not sure where this data is coming from
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
            pr_arr_date(max_grid_line).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

        Call ets_set_selected()
    End Sub

    Private Sub pr_arr_job_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles pr_arr_job.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = pr_arr_job.GetIndex(CType(eventSender, TextBox))
        Dim retpycl As String = ""
        If KeyCode = System.Windows.Forms.Keys.F3 Then

            If Index <> 0 Then
                pr_arr_job(Index).Text = pr_arr_job(CShort(Index - 1)).Text
                jobdata = etsjobnum_chk(pr_arr_job(Index).Text.ToString)
                pr_arr_rea(Index).Text = jobdata(0).ToString
                retpycl = jobdata(0).ToString
                pr_arr_loc(Index).Text = jobdata(1).ToString

                'here we check for duplicate iof namekey,date, and job
                If retpycl = "SI" Or retpycl = "SD" Or retpycl = "SP" Or retpycl = "ST" Then
                    pr_Arr_pay(Index).Enabled = True
                End If

                Select Case retpycl
                    Case "DP", "IP", "OO", "OH"

                        Call CheckValidCliJob(ee_num.Text, pr_arr_job(Index).Text, ETSCommon.MODULE1.valid_YN)


                        If ETSCommon.MODULE1.valid_YN = "N" Then
                            Response = MsgBox("This is not a valid CliJob number for this consumer. Do you wish to make it valid?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
                            If Response = 6 Then
                                selected_job_num = pr_arr_job(Index).Text
                                entry_type = "ADD"
                                'frmclijob.ShowDialog()
                                pr_arr_job(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

                            Else
                                pr_arr_job(Index).Focus()
                                Call ets_set_selected()

                                Exit Sub
                            End If
                        End If

                End Select

                pr_arr_hrs(Index).Focus()
                KeyAscii = 0
            End If
        End If

    End Sub

    Private Sub pr_arr_job_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_arr_job.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = pr_arr_job.GetIndex(CType(eventSender, TextBox))
        Dim retpycl As String = ""
        Dim retloc As String

        If KeyAscii = 13 Or KeyAscii = 9 Or KeyAscii = 9 Then
            pr_arr_job(Index).Text = UCase(pr_arr_job(Index).Text)
            selected_lookup_num = ""
            valid_job = "N"
            retjob = ""
            retloc = ""
            sendjob = Trim(pr_arr_job(Index).Text)
            pr_arr_pcs(Index).Text = "" 'to clear the pcs field if changed
            If sendjob.Length = 0 Then
                Dim jobnumlookup As New jobnumlookup
                jobnumlookup.ShowDialog()
                valid_job = "Y"
                sendjob = selected_job_num
            End If
            jobdata = etsjobnum_chk(sendjob)
            retpycl = jobdata(0).ToString
            retjobdesc = jobdata(1).ToString

            If valid_job = "N" Then
                MsgBox("Invalid job number")
                Call ets_set_selected()
                pr_arr_job(Index).Focus()
                KeyAscii = 0
                GoTo EventExitSub
            End If

            If Len(Trim(selected_lookup_num)) <> 0 Then
                pr_arr_job(Index).Text = selected_lookup_num
                pr_arr_rea(Index).Text = retpycl
            Else
                pr_arr_rea(Index).Text = retpycl
            End If

            pr_arr_loc(Index).Text = retjobdesc

            'here we check for duplicate iof namekey,date, and job
            If retpycl = "SI" Or retpycl = "SD" Or retpycl = "SP" Or retpycl = "ST" Then
                pr_Arr_pay(Index).Enabled = True
            End If

            Select Case retpycl
                Case "DP", "IP", "OO", "OH"
                    Call CheckValidCliJob(ee_num.Text, pr_arr_job(Index).Text, ETSCommon.MODULE1.valid_YN)

                    If ETSCommon.MODULE1.valid_YN = "N" Then
                        Response = MsgBox("This is not a valid CliJob number for this consumer. Do you wish to make it valid?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
                        If Response = 6 Then
                            selected_job_num = pr_arr_job(Index).Text
                            entry_type = "ADD"
                            'frmclijob.ShowDialog()
                            pr_arr_job(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

                        Else
                            pr_arr_job(Index).Focus()
                            Call ets_set_selected()

                            GoTo EventExitSub
                        End If
                    End If

            End Select

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
            pr_arr_date(max_grid_line).Focus() 'set focus at the end of the latest line
            Exit Sub
        End If

        Call ets_set_selected()
    End Sub

    Private Sub pr_arr_pct_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles pr_arr_pct.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = pr_arr_pct.GetIndex(CType(eventSender, TextBox))
        'allows the f3 code to repeat the information

    End Sub

    Private Sub pr_arr_pct_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_arr_pct.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = pr_arr_pct.GetIndex(CType(eventSender, TextBox))
        Dim ee_loc_num As String
        Dim ee_job_num As String
        Dim M As Integer
        Dim n As Integer
        Dim PayFreq As String

        If KeyAscii = 13 Or KeyAscii = 9 Then
            If Not IsNumeric(pr_arr_pct(Index).Text) Then
                MsgBox("Please enter a number")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            If Val(pr_arr_pct(Index).Text) > 100 Then
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
                    KeyAscii = 0
                    GoTo EventExitSub
                End If
            End If

            wline = 0

            'data pushed to array but arrray starts at 1 not 0

            ee_array(0, Index + 1 + offset_grid_line) = jeline(Index).Text 'line
            ee_array(1, Index + 1 + offset_grid_line) = pr_arr_date(Index).Text 'date
            ee_array(2, Index + 1 + offset_grid_line) = pr_arr_job(Index).Text 'job#
            ee_array(3, Index + 1 + offset_grid_line) = pr_arr_loc(Index).Text 'job desc
            ee_array(4, Index + 1 + offset_grid_line) = pr_arr_rea(Index).Text 'pay class
            ee_array(5, Index + 1 + offset_grid_line) = CStr(CDbl(Val(pr_arr_hrs(Index).Text))) 'hours
            ee_array(6, Index + 1 + offset_grid_line) = pr_arr_pcs(Index).Text 'pieces
            '  ee_array(7, Index + 1 + offset_grid_line) = pr_arr_pcs(Index)
            ee_array(8, Index + 1 + offset_grid_line) = pr_arr_dept(Index).Text 'dept
            ee_array(9, Index + 1 + offset_grid_line) = CStr(Val(pr_Arr_pay(Index).Text)) 'pay
            ee_array(10, Index + 1 + offset_grid_line) = CStr(retpct) 'pr_arr_pct(Index)            'pct

            'sets the maxgrid line to max in the array
            If max_grid_line < Val(jeline(Index).Text) Then
                max_grid_line = CShort(jeline(Index).Text)
            End If

            If total_hours = CDbl(ee_exp_hrs.Text) Then

                Response = MsgBox("Have you completed the time card?", MsgBoxStyle.YesNo)
                If Response = 6 Then
                    'push the stuff to work1
                    Call tot_amt()

                    Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
                        Dim sql As String = "Select * from ccsys "
                        Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                        While rs.Read()
                            PayFreq = rs("pay_freq").ToString
                            If rs("min_ck_dfq").ToString = "W" Then
                                If Val(ee_calc_tot_pay.Text) < Val(rs("min_ck_Amt")) Then
                                    Response = MsgBox("This time card does not meet the minimum weekly amount.  Do you wish to have the difference added?", MsgBoxStyle.YesNo)
                                    If Response = MsgBoxResult.Yes Then
                                        max_grid_line = CShort(max_grid_line + 1)
                                        num = max_grid_line
                                        ee_array(0, num) = CStr(max_grid_line)
                                        ee_array(1, num) = ee_array(1, 1) ' pr_arr_date(Index)
                                        ee_array(2, num) = "88887" ' pr_arr_job(Index)
                                        ee_array(3, num) = "MIN DIFFERENCE $ AMOUNT FOR MIN. CK" 'lhw2002
                                        ee_array(4, num) = "SP" ' pr_arr_rea(Index)
                                        ee_array(5, num) = CStr(0) ' pr_arr_hrs(Index)
                                        ee_array(6, num) = CStr(0) ' pr_arr_pcs(Index)
                                        ee_array(8, num) = ee_array(8, 1) ' pr_arr_dept(Index)
                                        ee_array(9, num) = CStr(Val(rs("min_ck_Amt")) - CDbl(ee_calc_tot_pay.Text))
                                        ee_array(10, num) = CStr(0) '' pr_arr_pct(Index)
                                    End If
                                    Call tot_amt()
                                    Call repaint_grid(0, 0, 0)
                                End If
                            End If
                        End While
                        rs.Close()
                    End Using
                End If


                'repaint it differently if the first line has a no pay problem
                If CDbl(ee_array(0, 1)) = 1 And ee_array(4, 1) = "OO" Then ' to correct for no pay lines
                    For ETSCommon.MODULE1.num = 2 To max_grid_line
                        If ee_array(4, num) <> "OO" And ee_array(4, num) <> "NO" Then
                            ee_array(0, 1) = ee_array(0, num)
                            ee_array(0, num) = CStr(1)
                            Call repaint_grid(0, 0, 0)
                            Exit For
                        End If
                    Next
                End If

                If CDbl(ee_array(0, 1)) = 1 And ee_array(4, 1) = "NO" Then
                    For ETSCommon.MODULE1.num = 2 To max_grid_line
                        If ee_array(4, num) <> "OO" And ee_array(4, num) <> "NO" Then
                            ee_array(0, 1) = ee_array(0, num)
                            ee_array(0, num) = CStr(1)
                            Call repaint_grid(0, 0, 0)
                            Exit For
                        End If
                    Next
                End If


                'this checks to make sure the header is complete
                If Len(ee_entry_num.Text) = 0 Or Len(ee_num.Text) = 0 Or CDbl(ee_exp_hrs.Text) < 0 Then
                    MsgBox("Header is not complete.  Please complete and then process.")
                    GoTo done1
                End If

                sqlstmnt = ""
                Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
                    Dim sql As String = sqlstmnt

                    For n = 1 To max_grid_line 'array starts at 1
                        sqlstmnt = " insert into cctime "
                        sqlstmnt = sqlstmnt & "(entry_date,pay_num,name_key,screen_nam,entry_num,line_num,pay_Freq,ded_dfq,date,job_num,pay_class,hours,pcs_prod,dept_num,pay_dol,cl_pct,Sort_name)"
                        sqlstmnt = sqlstmnt & " values ('" & sys_Date.Text & "','" & pr_num & "','" & Trim(ee_num.Text) & "','" & ee_Screen_nam.Text & "','" & ee_entry_num.Text & "','" & Val(ee_array(0, n)) + Val(CStr(last_line_num)) & "','" & ee_pay_dfq.Text & "','" & ee_ded_dfq.Text & "','" & ee_array(1, n) & "','" & ee_array(2, n) & "','" & ee_array(4, n) & "','" & ee_array(5, n) & "','" & Val(ee_array(6, n)) & "','" & ee_array(8, n) & "','" & ee_array(9, n) & "','" & ee_array(10, n) & "','" & selected_sort_name & "')"

                    Next n
                    db.ExecuteQuery(sqlstmnt)
                End Using

                'now we check for HWB and notify that we are adding the record
                'db = cc_data_path & "cc.mdb"
                'jobdb = DAODBEngine_definst.OpenDatabase(db)
                'jobset = jobdb.OpenRecordset("ccjob", dao.RecordsetTypeEnum.dbOpenDynaset)

                'added one to get next line number
                last_line_num = CInt(Val(ee_array(0, n - 1)) + Val(CStr(last_line_num)) + 1)

                For ETSCommon.MODULE1.num = 1 To max_grid_line 'array starts at 1
                    If Len(Trim(ee_array(2, num))) <> 0 Then 'make sure there is ajob num
                        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
                            Dim sql As String = "select dept_num from ccjob where job_num = '" & ee_array(2, num) & "' and hwb <> 0 "
                            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                            Dim intcount As Integer = 0

                            While rs.Read()
                                MsgBox("HWB benefits will be added to this time card.")
                                Using db1 As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
                                    sqlstmnt = " insert into cctime "
                                    sqlstmnt = sqlstmnt & "(entry_date,pay_num,name_key,screen_nam,entry_num,line_num,pay_Freq,ded_dfq,date,job_num,pay_class,hours,pcs_prod,dept_num,pay_dol,cl_pct,Sort_name)"
                                    sqlstmnt = sqlstmnt & " values (" & sys_Date.Text & "','" & pr_num & "','" & Trim(ee_num.Text) & "','" & ee_Screen_nam.Text & "','" & ee_entry_num.Text & "','" & Val(ee_array(0, n)) + Val(CStr(last_line_num)) & "','" & ee_pay_dfq.Text & "','" & ee_ded_dfq.Text & "','" & ee_array(1, n) & "','" & ee_array(2, n) & "','" & ee_array(4, n) & "','" & ee_array(5, n) & "','" & Val(ee_array(6, n)) & "','" & ee_array(8, n) & "','" & ee_array(9, n) & "','" & ee_array(10, n) & "','" & selected_sort_name & "','" & ")"
                                    db1.ExecuteQuery(sqlstmnt)
                                End Using
                            End While
                            rs.Close()
                        End Using
                    End If
                Next

                '         sqlstmnt = "job_num = " & Chr(34) & ee_array(2, num) & Chr(34)
                '        jobset.FindFirst(sqlstmnt)
                '       If jobset.NoMatch Then

                '  Else

                '     sqlstmnt = ""

                '        If jobset.Fields("hwb").Value <> 0 Then
                ' MsgBox("HWB benefits will be added to this time card.")
                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.AddNew()

                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("entry_date").Value = sys_Date.Text
                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("pay_num").Value = pr_num
                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("name_key").Value = Trim(ee_num.Text) 'added 6/30/07 scs
                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("screen_nam").Value = ee_Screen_nam.Text
                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("entry_num").Value = ee_entry_num.Text
                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("line_num").Value = last_line_num
                'last_line_num = last_line_num + 1
                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("date").Value = ee_array(1, num) ' pr_arr_date(Index)
                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("job_num").Value = "88885" 'ee_array(2, n) ' pr_arr_job(Index)
                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("pay_class").Value = "ST" 'ee_array(4, n) ' pr_arr_rea(Index)

                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("hours").Value = 0 'ee_array(5, n) ' pr_arr_hrs(Index)
                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("pcs_prod").Value = 0 'Val(ee_array(6, n)) ' pr_arr_pcs(Index)
                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("dept_num").Value = ee_array(8, num) ' pr_arr_dept(Index)
                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("pay_dol").Value = Val(ee_array(5, num)) * jobset.Fields("hwb").Value 'ee_array(9, n) ' pr_Arr_pay(Index)
                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("cl_pct").Value = 0 'ee_array(10, num) ' pr_arr_pct(Index)
                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("Sort_name").Value = ee_sort_name
                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                ''UPGRADE_ISSUE: Data property ccsys.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Fields("pay_Freq").Value = ccsys.Recordset.Fields("pay_freq").Value

                ''UPGRADE_ISSUE: Data property Data3.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Data3.Recordset.Update()



                Response = MsgBox("Do you wish to enter another time card?", MsgBoxStyle.YesNo)

                If Response = MsgBoxResult.Yes Then
                    For n = 0 To 50
                        For M = 0 To 15
                            ee_array(M, n) = ""
                        Next M
                    Next n
                    max_grid_line = 0
                    offset_grid_line = 0
                    Call repaint_grid(0, 0, 0)
                    num_cards.Text = CStr(CDbl(num_cards.Text) + 1)

                    ee_num.Text = " "
                    ee_entry_num.Text = " "
                    ee_pay_dfq.Text = " "
                    ee_exp_hrs.Text = " "
                    ee_calc_tot_hrs.Text = CStr(0)
                    ee_calc_tot_pay.Text = CStr(0)
                    ee_job_num = " "
                    ee_loc_num = " "
                    ee_hol_rem.Text = " "
                    ee_rem_sick.Text = " "
                    ee_rem_per.Text = " "
                    ee_rem_vac.Text = " "
                    ee_Screen_nam.Text = ""
                    ee_dept_num.Text = ""
                    avg_hrly.Text = ""
                    retpct = 0 'added 6/14/00 to clear the client per for the next screen scs
                    Call tot_amt() 'added 8/14/00 to clear total pieces scs

                    ee_num.Focus()
                    KeyAscii = 0

                    GoTo done1
                Else
                    Me.Close()
                    GoTo EventExitSub
                End If

            Else

            End If 'have you completed time card

        End If 'for tot hours = exp-hrs
        'the following checks to see if you need to add a line

        If Index = 9 Then
            offset_grid_line = offset_grid_line + 1
            Call repaint_grid(offset_grid_line, wline, 9)
            jeline(9).Focus()
            KeyAscii = 0
            GoTo EventExitSub
        End If

        retpct = 0
        pr_arr_date(CShort(Index + 1)).Focus()
        KeyAscii = 0

        '    End If  'for tot hours = exp hrs

        ' End If 'for key =13
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
        Dim Index As Integer
        wline = 0
        If max_grid_line < 9 Then Exit Sub

        offset_grid_line = offset_grid_line + 1

        If offset_grid_line > max_grid_line - 10 Then
            offset_grid_line = max_grid_line - 8
        End If

        If offset_grid_line > (max_grid_line - 7) Then offset_grid_line = max_grid_line - 7
        If offset_grid_line < 0 Then offset_grid_line = 0

        Call repaint_grid(offset_grid_line, wline, Index)

    End Sub

End Class