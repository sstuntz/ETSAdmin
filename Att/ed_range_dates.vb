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

Public Class ed_range_dates
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

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        For num As Short = 0 To 41
            If Len(sdr(num).Text) <> 0 Then
                If sdr(num).Text = "DEL" Then
                    'delete records
                    sqlstmnt = "delete from attend_tmp where contract_key = '" & selected_contract_key
                    sqlstmnt = sqlstmnt & "' and att_Date = '" & date_Array(num) & "'"
                    ETSSQL.ExecuteSQL(sqlstmnt)
                Else
                    'change records to this value
                    sqlstmnt = "select * from attend_tmp where contract_key = '" & selected_contract_key
                    sqlstmnt = sqlstmnt & "' and att_Date = '" & date_Array(num) & "'"
                    EdAttendData.Clear()
                    EdAttendData = ETSSQL.GetAttendanceData(sqlstmnt)

                    For Each Row In EdAttendData
                        If Row.BillType = "125" Then
                            MsgBox("You can not group modify this bill type.")
                            Me.Close()
                            Exit Sub
                        End If
                        sqlstmnt = " update attend_tmp set  att_code = '" & sdr(num).Text & "' where contract_key = '" & selected_contract_key
                        sqlstmnt = sqlstmnt & "' and att_Date = '" & date_Array(num) & "'"
                        ETSSQL.ExecuteSQL(sqlstmnt)
                    Next
                End If
            End If
        Next
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

    Private Sub ed_range_dates_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        sqlstmnt = "select * from attend_tmp where contract_key = '" & selected_contract_key & "' order by att_Date "

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

            'need to reset the data1.recordsource to make sure do not delete other reocrds
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


        function_type = "DATA_ENTRY"
        For num As Short = 0 To 41
            dayt(num).Text = ""
            sdr(num).Text = ""
        Next

        EdAttendData.Clear()


        sqlstmnt = "select * from attend_tmp where contract_key =  '" & selected_contract_key
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
        ''now that the calendar is set now to put the att_code in the right field
        For num As Short = 0 To 41
            start_position = num            'num is zeroed out whrn leave for loop     
            If date_Array(num) = selected_start_date Then Exit For
        Next


        total_units = 0
        num = 0
        'data no filled since only doing all contract records

        'For Each AttendRow In EdAttendData
        '    '	'check to make sure the right day is lined up
        '    For num1 As Integer = start_position To 41
        '        If CDbl(day_num(num1)) = AttendRow.AttDate.Day Then
        '            sdr(CShort(num1)).Text = AttendRow.AttCode
        '            Exit For
        '        End If
        '    Next
        'Next

      
        txtFields(3).Text = cont_key_display(selected_contract_key)
        txtFields(13).Text = Today.ToShortDateString

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
                If Val(sdr(Index).Text) = 0 Then sdr(Index).Text = "0"
                If Not IsNumeric(CDbl(sdr(Index).Text)) Then
                    MsgBox("This must be a number.")
                    Call ets_set_selected()
                End If
            End If
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