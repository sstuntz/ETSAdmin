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

Public Class att_date_choose
    Inherits System.Windows.Forms.Form
    Dim EdAttendData As List(Of AttendData)


    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click
        If Val(ret2) = 0 Then
            MsgBox("Please select something.")
            Exit Sub
        End If
        ret2 = Combo1.Text

        If ret2 = "ALL" Then
            '    Combo1.ListIndex = 1
            ret2 = "ALL" '& VB6.GetItemString(Combo1, 1)
            Me.Close()
            Exit Sub
        End If

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub Combo1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo1.Enter
        Combo1.SelectedIndex = 0

    End Sub

    Private Sub Combo1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Combo1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            ret2 = Combo1.Text
            Me.Close()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub att_date_choose_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ctrform(Me)
        Combo1.Items.Clear()

        ' Dim saved_date_choice As String

        If selected_bill_type <> "170" Then
            If function_type = "HISTORY" Then
                sqlstmnt = "select * from attend_hist where b_num = '" & selected_name_key & selected_contract_key & "' order by att_Date "
            Else
                sqlstmnt = "select * from attend_tmp where b_num = '" & selected_name_key & selected_contract_key & "' order by att_Date "
            End If
        Else
            'If Del_Day_Flag <> "Y" Then
            '    Combo1.Items.Insert(0, "ALL")
            '    sqlstmnt = "select * from medopn_tmp where name_key = '" & selected_name_key & "' and void = 'N' "
            'Else
            '    sqlstmnt = "select * from medopn_tmp where contract_key = '" & selected_contract_key & "'"
            'End If
            'sqlstmnt = sqlstmnt & " and ((medopn_tmp.from_date) between '" & selected_Date_Range_Start & "' and '" & selected_Date_Range_End & "') order by from_Date "


            'Combo1.Items.Add(Month(Data1.Recordset.Fields("from_Date")) & "-" & Year(Data1.Recordset.Fields("from_Date")))
            'saved_date_choice = Month(Data1.Recordset.Fields("from_Date")) & "-" & Year(Data1.Recordset.Fields("from_Date"))

            'num1 = 2
            '' Do While Not Data1.Recordset.EOF

            ''     If Month(Data1.Recordset.Fields("from_Date")) & "-" & Year(Data1.Recordset.Fields("from_Date")) <> (saved_date_choice) Then
            ''         Combo1.Items.Add(Month(Data1.Recordset.Fields("from_Date")) & "-" & Year(Data1.Recordset.Fields("from_Date")))
            ''        saved_date_choice = Month(Data1.Recordset.Fields("from_Date")) & "-" & Year(Data1.Recordset.Fields("from_Date"))
            ''        num1 = num1 + 1
            ''    End If

            ''      Data1.Recordset.MoveNext()
            ''Loop

            'Exit Sub
        End If

        EdAttendData = ETSSQL.GetAttendanceData(sqlstmnt)
        Dim saved_Date_choice As String = ""

        For num As Integer = 0 To EdAttendData.Count - 1
            If Month(EdAttendData.Item(num).AttDate) & "-" & Year(EdAttendData.Item(num).AttDate) <> (saved_Date_choice) Then
                Combo1.Items.Add(Month(EdAttendData.Item(num).AttDate) & "-" & Year(EdAttendData.Item(num).AttDate))
                saved_Date_choice = Month(EdAttendData.Item(num).AttDate) & "-" & Year(EdAttendData.Item(num).AttDate)
            End If

        Next

    End Sub

    Private Sub Combo1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo1.SelectedIndexChanged
        ret2 = Combo1.Text
        accept.Focus()

    End Sub
End Class