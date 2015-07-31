Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility
Imports Microsoft.VisualBasic.Conversion
Imports ETS.Common.Module1
Imports PS.Common
Imports ETS.clpr_mod
Imports ETS.pr_common
Imports ETS.stpr_mod
Imports ETS.Common
Imports ETSCommon
Imports System.Data.SqlClient
Imports System.Configuration
Imports Valid_YN
Imports System
Imports System.String


Public Class cc_ent_time
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

    Public FocusChange As Boolean



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

        ee_calc_tot_pay.Text = String.Format("{0:F2}", total_amount)
        ee_calc_tot_hrs.Text = String.Format("{0:F2}", total_hours)
        ee_calc_tot_pcs.Text = String.Format("{0:F2}", total_pieces)

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
            pr_arr_pct(i).Text = String.Format("{0:F2}", ee_array(10, i + 1 + offset_grid_line))

        Next i
        jeline(CShort(oldfocus)).Focus()

        KeyAscii = 0
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cancel.Click
        Me.Close()
    End Sub

    Private Sub ee_ded_dfq_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ee_ded_dfq.Enter
        'call ets_set_selected()
        ee_ded_dfq.SelectAll()
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
                    Call ets_Set_selected()
                    ee_ded_dfq.SelectAll()
                    ee_ded_dfq.Focus()
                    KeyAscii = 0
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
        Call ets_Set_selected()
        ee_entry_num.SelectAll()

    End Sub

    Private Sub ee_entry_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ee_entry_num.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            If IsNumeric(ee_entry_num.Text) Then
                If CDbl(ee_entry_num.Text) > 1 Then
                    Response = MsgBox("This is for check #" & ee_entry_num.Text & " for this employee for this payroll run", MsgBoxStyle.YesNo)
                    If Response = 7 Then
                        'call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        'reset the line counters
                        last_line_num = 0
                    End If
                End If
            Else
                MsgBox("Please enter a number.")
                GoTo EventExitSub
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
        ee_num.SelectAll()

        If Index >= 0 And Index <= 9 Then
            jeline(Index).Enabled = True
        End If

        pr_Start_date1.Text = CStr(pr_Start_date)
        pr_end_Date1.Text = CStr(pr_end_date)
        Pr_num1.Text = CStr(pr_num)
        sys_Date.Text = CStr(Today)

        Call ets_Set_selected()
        ee_num.BackColor = Color.Aqua

        ee_num.SelectAll()

        Call ets_Set_selected()
        If (Not String.IsNullOrEmpty(ee_num.Text)) Then
            ee_num.SelectionStart = 0
            ee_num.SelectionLength = ee_num.Text.Length
        End If

    End Sub

    Private Sub ee_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ee_num.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim tot_hrs As Double 'added to show prev hrs ent 7/13/04 for mcw by lhw
        If KeyAscii = 13 Or KeyAscii = 9 Then
            last_line_num = 0 'reset the key if looking up someone else
            Dim intcount As Integer = 0
            valid_name = "N"
            selected_name_key = ""

            If Val(ee_num.Text) = 0 Then
                Dim frmnamechk As New frmnamechk
                frmnamechk.ShowDialog()
                ee_num.Text = selected_name_key
                valid_name = "Y"
            Else
                valid_name = chkname(ee_num.Text)
            End If

            If valid_name = "N" Then
                MsgBox("Invalid client number")
                ee_num.Focus()
                ee_num.SelectAll()
                KeyAscii = 0
                GoTo EventExitSub
            End If

            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select * from nam_cc where name_key = '" & ee_num.Text & "'"
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                intcount = 0

                While rs.Read()
                    ee_Screen_nam.Text = rs("screen_nam").ToString
                    '   ee_sort_name.text = rs("sort_name").ToString
                    ee_dept_num.Text = rs("dept_num").ToString
                    ee_entry_num.Text = "1"
                    avg_hrly.Text = String.Format("{0:F2}", rs("avg_hrly"))
                    ee_pay_dfq.Text = rs("pay_freq").ToString
                    ee_ded_dfq.Text = rs("pay_freq").ToString
                    'scs
                    'If isnull(rs("term_Date)) then
                    '    If rs("term_Date").Value < Today Then
                    '        MsgBox("This person has been terminated and can not be paid.")
                    '        'call ets_set_selected()
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
                ee_num.Focus()
                ee_num.SelectAll()
                KeyAscii = 0
                GoTo EventExitSub
            Else
                valid_name = "Y"
            End If
            Call calc_used_ben(ee_num.Text)

            intcount = 0
            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select * from ccvac where name_key = '" & ee_num.Text & "'"
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)

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
            intcount = 0

            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                tot_hrs = 0
                While rs.Read()
                    last_line_num = CInt(Val(rs("line_num")))

                    ee_Screen_nam.Text = rs("screen_nam").ToString
                    ' ee_sort_name = rs("sort_name").ToString
                    ee_dept_num.Text = rs("dept_num").ToString
                    ee_entry_num.Text = "1"
                    '   avg_hrly.Text = string.format(rs("avg_hrly").ToString, "####0.00")
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
        Call ets_Set_selected()
        ee_exp_hrs.SelectAll()

    End Sub

    Private Sub ee_exp_hrs_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ee_exp_hrs.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            If Not IsNumeric(ee_exp_hrs.Text) Then
                MsgBox("Not a number")
                ee_exp_hrs.Focus()
                ee_exp_hrs.SelectAll()
                'call ets_set_selected()
                GoTo EventExitSub
            End If
            ee_exp_hrs.Text = String.Format("{0:f2}", Val(ee_exp_hrs.Text))

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
        'call ets_set_selected()
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
                    Call ets_Set_selected()
                    ee_pay_dfq.Focus()
                    ee_pay_dfq.SelectAll()
                    KeyAscii = 0
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
                ee_pay_dfq.SelectAll()
        End Select

        ee_pay_dfq.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        'call ets_set_selected()

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

        'For Each ctrl As Control In Me.Controls
        '    If TypeOf (ctrl) Is TextBox Then
        '        Dim xctrl As System.Windows.Forms.TextBox = ctrl
        '        xctrl.SelectAll()
        '        AddHandler ctrl.Click, AddressOf AnyTextBox_Click
        '        AddHandler ctrl.GotFocus, AddressOf AnyTextBox_GotFocus
        '    End If
        'Next

    End Sub

    'Private Sub AnyTextBox_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If FocusChange Then
    '        ' current textbox has changed so we'll select the text
    '        sender.SelectAll()
    '        FocusChange = False
    '    End If
    'End Sub

    'Private Sub AnyTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    FocusChange = True
    'End Sub


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
        pr_arr_date(Index).Select(0, pr_arr_date(Index).Text.Length)

        Call ets_Set_selected()
        pr_arr_date(Index).SelectAll()

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
                        Call ets_Set_selected()
                        pr_arr_date(Index).Focus()
                        pr_arr_date(Index).SelectAll()
                        GoTo EventExitSub
                    End If
                End If
                pr_arr_date(Index).Text = retdate.ToString
                pr_arr_date(Index).Text = CStr(CDate(pr_arr_date(Index).Text))
                pr_arr_job(Index).Focus()
                KeyAscii = 0

            Else
                MsgBox("Bad date")
                Call ets_Set_selected()
                pr_arr_date(Index).Focus()
                pr_arr_date(Index).SelectAll()
                KeyAscii = 0
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

        Call ets_Set_selected()
        pr_arr_date(Index).SelectAll()

        If pr_arr_rea(Index).Text = "SP" Then
            pr_arr_hrs(Index).Text = CStr(0)
            pr_arr_dept(Index).Focus()
            KeyAscii = 0
        End If

        If (Not String.IsNullOrEmpty(pr_arr_hrs(Index).Text)) Then
            pr_arr_hrs(Index).SelectionStart = 0
            pr_arr_hrs(Index).SelectionLength = pr_arr_hrs(Index).Text.Length
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
                        Call ets_Set_selected()
                        pr_arr_hrs(Index).Focus()
                        pr_arr_hrs(Index).SelectAll()
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
                Call ets_Set_selected()
                pr_arr_hrs(Index).Focus()
                pr_arr_hrs(Index).SelectAll()
                KeyAscii = 0
                GoTo EventExitSub
            End If

            If Val(pr_arr_hrs(Index).Text) < 0 Then
                MsgBox("Please enter a positive amount, or Zero.")
                Call ets_Set_selected()
                pr_arr_hrs(Index).Focus()
                pr_arr_hrs(Index).SelectAll()
                KeyAscii = 0
                GoTo EventExitSub
            End If

            ee_array(5, Index + 1 + offset_grid_line) = CStr(CDbl(pr_arr_hrs(Index).Text))
            pr_arr_hrs(Index).Text = String.Format("{0:F2}", Val(pr_arr_hrs(Index).Text))

            Call tot_amt()

            Select Case RTrim(pr_arr_job(Index).Text)

                Case "81808"
                    If CDbl(ee_rem_vac.Text) < total_vac + CDbl(pr_arr_hrs(Index).Text) Then
                        MsgBox(" Exceeding max ccvac hours.")
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
                    Call ets_Set_selected()
                    pr_arr_hrs(Index).Focus()
                    pr_arr_hrs(Index).SelectAll()
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

        'call ets_set_selected()
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
        Call ets_Set_selected()
        pr_arr_dept(Index).SelectAll()

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
                retpay = paynums(0)
                retpct = paynums(1)
                If pr_arr_dept(Index).Text = "NN" Then
                    pct = 0
                    pay = 0
                End If
                pr_Arr_pay(Index).Text = String.Format("{0:F2}", retpay)

                pr_arr_pct(Index).Text = String.Format("{0:F2}", retpct * 100)
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
                pr_arr_pct(Index).Text = String.Format("{0:F2}", 0 * 100)
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
                'call ets_set_selected()
                pr_arr_dept(Index).Focus()
                pr_arr_dept(Index).SelectAll()
                KeyAscii = 0
                GoTo EventExitSub
            End If

            pr_arr_dept(Index).Text = senddpt

            If Len(RTrim(pr_arr_pcs(Index).Text)) = 0 Then
                pr_arr_pcs(Index).Text = CStr(0)
            End If

            If pr_arr_rea(Index).Text = "SD" Or pr_arr_rea(Index).Text = "SI" Or pr_arr_rea(Index).Text = "SP" Or pr_arr_rea(Index).Text = "ST" Then
                pr_Arr_pay(Index).Enabled = True
                pr_Arr_pay(Index).Focus()
                KeyAscii = 0
            Else
                Dim paynums As List(Of Decimal)
                If pr_arr_pcs(Index).Text.Length = 0 Then pr_arr_pcs(Index).Text = "0"

                paynums = calc_cc_pay(pr_arr_job(Index).Text, pr_arr_rea(Index).Text, CInt(pr_arr_pcs(Index).Text), CDec(pr_arr_hrs(Index).Text), ee_num.Text, CDec(retpay.ToString), CDec(retpct.ToString))

                pay = paynums(0)
                pct = paynums(1)


                If pr_arr_dept(Index).Text = "NN" Then
                    pct = 0
                    pay = 0
                End If

                pr_Arr_pay(Index).Text = String.Format("{0:F2}", pay)

                pr_arr_pct(Index).Text = String.Format("{0:F2}", pct * 100)

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

        'call ets_set_selected()
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
                'call ets_set_selected()
                pr_Arr_pay(Index).Focus()
                KeyAscii = 0
                GoTo EventExitSub
            End If
            ee_array(9, Index + 1 + offset_grid_line) = CStr(Val(pr_Arr_pay(Index).Text))
            pr_Arr_pay(Index).Text = String.Format("{0:F2}", CDbl(pr_Arr_pay(Index).Text))

            Call tot_amt()

            pr_arr_pct(Index).Text = String.Format("{0:F2}", 0 * 100)

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

        Call ets_Set_selected()
        pr_arr_pcs(Index).SelectAll()

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
                Call tot_amt()
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
                    'call ets_set_selected()
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
        pr_arr_rea(Index).SelectAll()

        Call ets_Set_selected()
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
                Call CheckOnceYN("cc_paycl", "pay_class", pr_arr_rea(Index).Text, valid_name)
                If valid_name = "N" Then
                    MsgBox("Not a valid pay class code")
                    'call ets_set_selected()
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
        pr_arr_job(Index).SelectAll()

        Call ets_Set_selected()
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
                pr_arr_rea(Index).Text = jobdata(1).ToString
                retpycl = jobdata(1).ToString
                pr_arr_loc(Index).Text = jobdata(2).ToString

                'here we check for duplicate iof namekey,date, and job
                If retpycl = "SI" Or retpycl = "SD" Or retpycl = "SP" Or retpycl = "ST" Then
                    pr_Arr_pay(Index).Enabled = True
                End If

                Select Case retpycl
                    Case "DP", "IP", "OO", "OH"

                        Call CheckValidCliJob(ee_num.Text, pr_arr_job(Index).Text, "n")


                        'If Valid_YN = "N" Then  xxscs
                        '    Response = MsgBox("This is not a valid CliJob number for this consumer. Do you wish to make it valid?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
                        '    If Response = 6 Then
                        '        selected_job_num = pr_arr_job(Index).Text
                        '        entry_type = "ADD"
                        '        'frmclijob.ShowDialog()
                        '        pr_arr_job(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

                        '    Else
                        '        pr_arr_job(Index).Focus()
                        '        'call ets_set_selected()

                        '        Exit Sub
                        '    End If
                        'End If

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
            sendjob = RTrim(pr_arr_job(Index).Text)
            pr_arr_pcs(Index).Text = "" 'to clear the pcs field if changed
            If sendjob.Length = 0 Then
                Dim jobnumlookup As New jobnumlookup
                jobnumlookup.ShowDialog()
                valid_job = "Y"
                sendjob = selected_job_num
                pr_arr_job(Index).Text = sendjob
            End If

            jobdata = etsjobnum_chk(sendjob)

            If jobdata(0) = "N" Then
                MsgBox("Invalid job number")
                Call ets_Set_selected()
                pr_arr_job(Index).Focus()
                pr_arr_job(Index).SelectAll()
                KeyAscii = 0
                GoTo EventExitSub
            End If


            retpycl = jobdata(1).ToString
            retjobdesc = jobdata(2).ToString

            If Len(RTrim(selected_lookup_num)) <> 0 Then
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
                    Call CheckValidCliJob(ee_num.Text, pr_arr_job(Index).Text, "N")

                    'If Valid_YN = "N" Then  xxscs
                    '    Response = MsgBox("This is not a valid CliJob number for this consumer. Do you wish to make it valid?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
                    '    If Response = 6 Then
                    '        selected_job_num = pr_arr_job(Index).Text
                    '        entry_type = "ADD"
                    '        'frmclijob.ShowDialog()
                    '        pr_arr_job(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

                    '    Else
                    '        pr_arr_job(Index).Focus()
                    '        'call ets_set_selected()

                    '        GoTo EventExitSub
                    '    End If
                    'End If

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

        Call ets_Set_selected()
        pr_arr_pct(Index).SelectAll()

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
                'call ets_set_selected()
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
                    Call ets_Set_selected()
                    pr_arr_hrs(Index).Focus()
                    pr_arr_hrs(Index).SelectAll()
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
            ee_array(10, Index + 1 + offset_grid_line) = CStr(CDbl(pr_arr_pct(Index).Text) / 100)  'pct

            'sets the maxgrid line to max in the array
            If max_grid_line < Val(jeline(Index).Text) Then
                max_grid_line = CShort(jeline(Index).Text)
            End If

            If total_hours = CDbl(ee_exp_hrs.Text) Then

                Response = MsgBox("Have you completed the time card?", MsgBoxStyle.YesNo)
                If Response = 6 Then
                    'push the stuff to work1
                    Call tot_amt()

                    Using db As Database = New Database(top_data_path)
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
                Else
                    GoTo done1  'not done with time card
                End If

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
                If Len(ee_entry_num.Text) = 0 Or Len(ee_num.Text) = 0 Or CDbl(ee_exp_hrs.Text) < 0 Then
                    MsgBox("Header is not complete.  Please complete and then process.")
                    GoTo done1
                End If

                LoadCCTime()


                'make sure entries start with one for this person

                sqlstmnt = ";with cte as (select name_key, cctime.date, pay_num, line_num, ROW_NUMBER() over (order by cctime.date) as rownum from cctime where name_key = '" & selected_name_key & "' and pay_num = '" & pr_num & "' )"
                sqlstmnt = sqlstmnt & " update cte set line_num = rownum  "
                ETSSQL.ExecuteSQL(sqlstmnt)



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

    Private Sub ets_Set_selected()
        On Error Resume Next
        Dim CNAme As String

        If Me.ActiveControl.GetType.ToString = "System.Windows.Forms.TextBox" Then
            ActiveControl.BackColor = Color.Aqua
            CNAme = ActiveControl.Name.ToString
            ActiveControl.Select()
            '   ActiveControl.
        End If

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