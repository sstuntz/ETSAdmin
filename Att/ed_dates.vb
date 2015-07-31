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

Public Class ed_dates
    Inherits System.Windows.Forms.Form

    Dim day_num(41) As String
    Dim sdr_type(4) As String
    Dim message As String
    Dim title As String
    Dim default_Renamed As String
    Dim Start_date As Date
    Dim date_Array(41) As Date
    Dim start_position As Short
    Dim num As Short
    Dim EdAttendData As List(Of AttendData)


    Sub calc_units()

        tot_units.Text = " "
        total_units = 0
        If selected_bill_type <> "125" Then
            For num As Integer = 0 To 41
                If InStr(billable_codes, sdr(CShort(num)).Text) <> 0 And Len(sdr(CShort(num)).Text) <> 0 Then ' = "X" Or sdr(num) = "A" Or sdr(num) = "B" Then
                    total_units = total_units + 1
                End If
            Next
        Else
            For num As Integer = 0 To 41
                total_units = total_units + Val(sdr(CShort(num)).Text)
            Next
        End If

        tot_units.Text = CStr(total_units)

    End Sub

    Private Sub client_pct_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles client_pct.Enter
        'Call ets_set_selected()
    End Sub

    Private Sub client_pct_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles client_pct.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 9 Or KeyAscii = 13 Then
            client_pct.Text = String.Format(client_pct.Text, "D").ToString 'VB6.Format(client_pct.Text, "FIXED")
            cmdUpdate.Focus()
            KeyAscii = 0
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub client_pct_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles client_pct.Leave
        client_pct.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub dayt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dayt.Click
        'code commented out in jri build
        '     Dim Index As Short = dayt.GetIndex(CType(eventSender, Button))
        '     num = 2
        '     Select Case num
        '         Case 1
        '             left2 = dayt(Index).Left + ed_dates.Left
        '             top2 = dayt(Index).Top + dayt(Index).Height + ed_dates.Top
        '             att_in_hrs.ShowDialog()
        '             dayt(Index).Text = day_num(Index) & Chr(13) & ret2
        '             att_in_hrs.Close()
        '         Case 2

        '             left2 = dayt(Index).Left + ed_dates.Left
        '             top2 = dayt(Index).Top + dayt(Index).Height + ed_dates.Top
        '             att_in_code.showdialog()

        '             message = "Enter the hours "   ' Set prompt.
        '             title = "JRI input Demo" ' Set title.
        '             default_Renamed = "0"   ' Set default.
        'Display dialog box at position 100, 100.
        '             sdr(Index) = ret2 'InputBox(message, title, default, dayt(Index).Left, dayt(Index + 1).Top)

        '             dayt(Index).Caption = day_num(Index) & Chr(13) & sdr(Index)

        '         Case 3
        '             left2 = dayt(Index).Left + ed_dates.Left
        '             top2 = dayt(Index).Top + dayt(Index).Height + ed_dates.Top
        '             dptnumlookup.Show(1)

        '             sdr(Index) = selected_dpt_num 'InputBox(message, title, default, dayt(Index).Left, dayt(Index + 1).Top)

        '             dayt(Index).Caption = day_num(Index) & Chr(13) & sdr(Index)


        '     End Select

    End Sub

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        'go through the list that was displayed
        'delete each one
        'add in the ones that have an sdr value
        For Each AttendRow In EdAttendData
            sqlstmnt = "delete from attend_tmp where b_num = '" & AttendRow.BNum & "' and att_Date = '" & AttendRow.AttDate & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)
        Next
        'check to make sure something has been entered
        'item number is offset by the start position
        'write out the data from the first one and only change the code and date
        Dim TempUnit As Double = 0
        Dim TempDate As Date
        Dim TEmpCode As String = ""

        For num As Short = 0 To 41
            If sdr(num).Enabled Then
                ' if blank skip
                If sdr(num).Text.Length <> 0 Then
                    TempDate = date_Array(num)
                    TEmpCode = sdr(num).Text

                    If selected_bill_type = "125" Then
                        TempUnit = Val(sdr(num).Text)
                    End If
                    If selected_bill_type = "120" Then
                        If IsNumeric(sdr(num).Text) Then
                            TempUnit = Val(sdr(num).Text)
                        Else
                            If InStr(billable_codes, sdr(num).Text) = 0 Then 'And Len(sdr(num)) = 0 Then 'sdr(num) <> "X" And sdr(num) <> "A" And sdr(num) <> "B" Then
                                TempUnit = 0
                            Else
                                TempUnit = 1
                            End If
                        End If
                        EdAttendData.Item(0).ClientPct = (Val(client_pct.Text) + 0) / 100
                    End If

                    If selected_bill_type <> "125" Then
                        If InStr(billable_codes, sdr(num).Text) = 0 Then 'And Len(sdr(num)) = 0 Then 'sdr(num) <> "X" And sdr(num) <> "A" And sdr(num) <> "B" Then
                            TempUnit = 0
                        Else
                            TempUnit = 1
                        End If
                    End If
                    If sdr(num).Text <> "" Then
                        EdAttendData.Item(0).AttCode = TEmpCode
                        EdAttendData.Item(0).AttUnit = TempUnit
                        EdAttendData.Item(0).AttDate = TempDate
                        sqlstmnt = "Insert into attend_tmp " & EdAttendData.Item(0).AttendColumnNames & " values " & EdAttendData.Item(0).AttendColumnData
                        ETSSQL.ExecuteSQL(sqlstmnt)
                    End If
                End If 'blank
            End If ' enabled
        Next num
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub dayt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dayt.Enter
        Dim Index As Short = dayt.GetIndex(CType(eventSender, Button))
        If Index = start_position Then
            txtFields(0).Text = selected_name_key
        End If
    End Sub

    Private Sub ed_dates_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ctrform(Me)
        If function_type = "HISTORY" Then
            cmdUpdate.Enabled = False
            sqlstmnt = "select * from attend_hist where b_num = '" & Trim(selected_name_key) & selected_contract_key & "' and void = 'N' order by att_Date  "

        Else
            sqlstmnt = "select * from attend_tmp where b_num = '" & Trim(selected_name_key) & selected_contract_key & "' order by att_Date "
        End If

        EdAttendData = ETSSQL.GetAttendanceData(sqlstmnt)

        If EdAttendData.Count = 0 Then
            MsgBox("No records to edit")
            Exit Sub
        End If

        selected_start_date = EdAttendData.Item(0).AttDate
        selected_end_date = EdAttendData.Item(EdAttendData.Count - 1).AttDate
        ret2 = ""
        responseyear = Year(selected_end_date)

        If Month(selected_start_date) - Month(selected_end_date) <> 0 Then
            'list the months to process and have them select one use a drop down box
            att_date_choose.ShowDialog()

            num = CShort(InStr(ret2, "-"))
            Response = CInt(VB.Left(ret2, num - 1))
            responseyear = CInt(VB.Right(ret2, 4))
            Label2.Visible = True
            Text1.Visible = True
            Text1.Text = ret2

            'need to reset the data1.recordsource to make sure do not delete other records
            Select Case Response
                Case 1
                    selected_start_date = CDate("1" & Chr(45) & "1" & Chr(45) & responseyear)
                    selected_end_date = CDate("1" & Chr(45) & "31" & Chr(45) & responseyear)
                Case 2
                    selected_start_date = CDate("2" & Chr(45) & "1" & Chr(45) & responseyear)
                    selected_end_date = CDate("2" & Chr(45) & "28" & Chr(45) & responseyear)
                Case 3
                    selected_start_date = CDate("3" & Chr(45) & "1" & Chr(45) & responseyear)
                    selected_end_date = CDate("3" & Chr(45) & "31" & Chr(45) & responseyear)
                Case 4
                    selected_start_date = CDate("4" & Chr(45) & "1" & Chr(45) & responseyear)
                    selected_end_date = CDate("4" & Chr(45) & "30" & Chr(45) & responseyear)
                Case 5
                    selected_start_date = CDate("5" & Chr(45) & "1" & Chr(45) & responseyear)
                    selected_end_date = CDate("5" & Chr(45) & "31" & Chr(45) & responseyear)
                Case 6
                    selected_start_date = CDate("6" & Chr(45) & "1" & Chr(45) & responseyear)
                    selected_end_date = CDate("6" & Chr(45) & "30" & Chr(45) & responseyear)
                Case 7
                    selected_start_date = CDate("7" & Chr(45) & "1" & Chr(45) & responseyear)
                    selected_end_date = CDate("7" & Chr(45) & "31" & Chr(45) & responseyear)
                Case 8
                    selected_start_date = CDate("8" & Chr(45) & "1" & Chr(45) & responseyear)
                    selected_end_date = CDate("8" & Chr(45) & "31" & Chr(45) & responseyear)
                Case 9
                    selected_start_date = CDate("9" & Chr(45) & "1" & Chr(45) & responseyear)
                    selected_end_date = CDate("9" & Chr(45) & "30" & Chr(45) & responseyear)
                Case 10
                    selected_start_date = CDate("10" & Chr(45) & "1" & Chr(45) & responseyear)
                    selected_end_date = CDate("10" & Chr(45) & "31" & Chr(45) & responseyear)
                Case 11
                    selected_start_date = CDate("11" & Chr(45) & "1" & Chr(45) & responseyear)
                    selected_end_date = CDate("11" & Chr(45) & "30" & Chr(45) & responseyear)
                Case 12
                    selected_start_date = CDate("12" & Chr(45) & "1" & Chr(45) & responseyear)
                    selected_end_date = CDate("12" & Chr(45) & "31" & Chr(45) & responseyear)
            End Select

            If VB.Left(CStr(selected_end_date), 1) = "2" Then
                If IsDate("2" & Chr(45) & "29" & Chr(45) & responseyear) Then
                    selected_end_date = CDate("2" & Chr(45) & "29" & Chr(45) & responseyear)
                End If
            End If

        End If

        For num As Short = 0 To 41
            dayt(num).Text = ""
        Next

        EdAttendData.Clear()

        If function_type = "HISTORY" Then
            cmdUpdate.Enabled = False
            sqlstmnt = "select * from attend_hist where b_num = '" & Trim(selected_name_key) & selected_contract_key
        Else
            sqlstmnt = "select * from attend_tmp where b_num = '" & Trim(selected_name_key) & selected_contract_key
        End If

        sqlstmnt = sqlstmnt & "' and att_date between '" & selected_start_date & "' and '"
        sqlstmnt = sqlstmnt & selected_end_date & "' and void = 'N' order by att_Date  "

        EdAttendData = ETSSQL.GetAttendanceData(sqlstmnt)


        'first step is get the month then make the first and get that weekday
        ret2 = Month(selected_start_date) & Chr(45) & "1" & Chr(45) & responseyear

        left2 = Weekday(CDate(ret2)) ' MyWeekDay contains 4 because
        ' MyDate represents a Wednesday.
        'start date is the 0 entry in the array
        date_Array(0) = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1 - left2, CDate(ret2))

        For num As Short = 0 To 41
            dayt(num).Enabled = True

            dayt(num).Text = CStr(VB.Day(date_Array(num)))
            day_num(num) = CStr(VB.Day(date_Array(num)))
            If num < 41 Then
                date_Array(num + 1) = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, date_Array(num))
                'set the last days enabled = false
            End If

            If Month(selected_start_date) <> Month(date_Array(num)) Then
                sdr(num).Enabled = False
                'adr(num).Enabled = False
            End If

        Next

        If CDbl(day_num(41)) > 6 Then
            For num As Short = 35 To 41
                dayt(num).Visible = False
                sdr(num).Visible = False
            Next
        End If
        For num As Short = 0 To 41
            sdr(CShort(num)).Text = ""
        Next

        ''now that the calendar is set now to put the att_code in the right field
        For num As Short = 0 To 41
            start_position = num
            If date_Array(num) = selected_start_date Then Exit For
        Next
        billable_codes = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "billable_codes")
        TextBox1.Text = MonthName(Month(selected_start_date))

        total_units = 0
        num = 0
        For Each AttendRow In EdAttendData
            '	'check to make sure the right day is lined up
            For num1 As Integer = start_position To 41
                '  If CDbl(day_num(num1)) = AttendRow.AttDate.Day Then
                If date_Array(num1) = AttendRow.AttDate Then
                    sdr(CShort(num1)).Text = AttendRow.AttCode
                    If AttendRow.BillType = "125" Then
                        sdr(CShort(num1)).Text = AttendRow.AttUnit.ToString
                    End If
                End If
            Next
        Next

        txtFields(0).Text = selected_name_key
        txtFields(1).Text = selected_screen_nam
        txtFields(3).Text = cont_key_display(selected_contract_key)
        txtFields(13).Text = Today.ToShortDateString

        Call calc_units()

        If selected_bill_type = "120" And ETSCommon.GetDatum("cc_cont", "Contract_key", selected_contract_key, "code3") = "EEP" Then
            clientper.Visible = True
            client_pct.Visible = True
            client_pct.Text = Val(EdAttendData.Item(0).ClientPct * 100).ToString
        End If

    End Sub

    Private Sub sdr_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sdr.Enter
        Dim Index As Short = sdr.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub sdr_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles sdr.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = sdr.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            sdr(Index).Text = Trim(UCase(sdr(Index).Text))
            If selected_bill_type = "125" Then
                If Val(sdr(Index).Text) = 0 Then
                    sdr(Index).Text = ""
                Else
                    If Not IsNumeric(CDbl(sdr(Index).Text)) Then
                        MsgBox("This must be a number.")
                        Call ets_set_selected()
                    End If
                End If

            End If

            Call calc_units()

            System.Windows.Forms.SendKeys.Send("{TAB}")
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub sdr_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sdr.Leave
        Dim Index As Short = sdr.GetIndex(CType(eventSender, TextBox))
        sdr(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

End Class