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
Imports System.String

Public Class cc_base
    Inherits System.Windows.Forms.Form
    Dim tmp_txtField_value As Object 'used for default values - TMK 8/26/03

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "cc_base"
    Public frmWhereClause As String = " where name_key = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        'test for completeness on txtfields only
        'fields 0 1 2 3 6 9 16 17 18 20 40 49

        'Dim num As Integer
        'For num = 0 To 100
        '    msg = "," & CStr(num) & ","
        '    Response = InStr(",7,8,10,11,", msg)
        '    If Response <> 0 Then
        '        If Len(txtFields(CShort(num)).Text) = 0 Then
        '            MsgBox("You must fill in all required fields.")
        '            txtFields(CShort(num)).Focus()
        '            Exit Sub
        '        End If
        '    End If

        'Next

        'check first and last name  - warning

        'If Len(Trim(tmpset.Fields("first_name").Value & "")) = 0 Or Len(Trim(tmpset.Fields("last_name").Value & "")) = 0 Then
        '    MsgBox(txtFields(1).Text & " is missing a first or last name in nam_addr.  You will be unable to bill for this person until you have entered it in.")
        'End If

        ''added txtfields(11), med_num, to only check addresses for Medicaid consumers - TMK
        'If Len(Trim(txtFields(11).Text)) > 0 And (Len(Trim("" & tmpset.Fields("address1").Value)) = 0 Or Len(Trim("" & tmpset.Fields("city").Value)) < 2 Or Len(Trim("" & tmpset.Fields("state").Value)) < 2 Or Len(Trim("" & tmpset.Fields("zip4").Value)) < 5) Then 'minimum length requirements

        '    msg = txtFields(1).Text & " has an incomplete or blank address." & Chr(10) & Chr(13)
        '    msg = msg & "Street, Town, State and Zip code are all required in nam_addr." & Chr(10) & Chr(13)
        '    msg = msg & "You will be unable to bill for this person until it is corrected."
        '    MsgBox(msg)
        'End If
        'End If

        'check date of birth format - 4/7/04 TMK
        'If VB.Left(VB.Right(Trim(txtFields(8).Text), 4), 1) = "/" Then
        '    MsgBox("Invalid date of birth.  Please re-format to mm/dd/yyyy.")
        '    txtFields(8).Focus()
        '    Exit Sub
        'End If

        'check gender - 4/7/04 TMK
        txtFields(7).Text = UCase((txtFields(7).Text))
        If txtFields(7).Text <> "M" And txtFields(7).Text <> "F" Then
            MsgBox("You must have an 'M' or 'F' for gender.")
            txtFields(7).Focus()
            Exit Sub
        End If

        If Len(txtFields(5).Text) <> 0 Then
            sqlstmnt = " update cc_fund set end_Date = '" & txtFields(5).Text & "' , closed = 'Y' where name_key = '" & selected_name_key & "' and closed = 'N' "
            ETSSQL.ExecuteSQL(sqlstmnt)
        End If

        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                TagColumnName = Me.cntrl.Tag.ToString
                Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                If frmdata.DataType = "datetime" Or frmdata.DataType = "DATE" Then
                    frmdata.ActualData = Me.cntrl.Text
                Else
                    frmdata.ActualData = cntrl.Text
                End If
            End If
            If TypeOf Me.cntrl Is ComboBox Then
                TagColumnName = Me.cntrl.Tag.ToString
                Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                frmdata.ActualData = race_choice.SelectedIndex.ToString
            End If
        Next

        Select Case entry_type.ToString
            Case "ADD"
                'add sort name and agency
                RowData.Item(2).ActualData = selected_sort_name
                RowData.Item(28).ActualData = CStr((AgencyNum))
                Call ETSSQL.InsertData(frmTableName, RowData)
            Case "EDIT"
                Call ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)
        End Select

        entry_type = saved_entry_type ' reverse what we did earlier.
        Me.Close()
        Me.Dispose()

    End Sub

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cc_base_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Normal     'added lhw 06/19/2012
        ctrform(Me)

        Dim refs As New List(Of RefData)
        refs = ETSSQL.GetRefData("ATT", "cc_base")
        For Each ref In refs
            Select Case Me.Controls(ref.ControlName).GetType.ToString
                Case "System.Windows.Forms.ComboBox"
                    Dim ctrl As String = Me.Controls(ref.ControlName).ToString
                    race_choice.Items.Add(ref.DatumDesc)
                Case "System.Windows.Forms.Label"
                    Me.Controls(ref.ControlName).Text = ref.DatumDesc
                Case "System.Windows.Forms.Button"
            End Select
            If (ref.ControlVisible) = "Y" Then
                Me.Controls(ref.ControlName).Visible = True
            End If
            If (ref.ControlVisible) = "N" Then
                Me.Controls(ref.ControlName).Visible = False
            End If
        Next

        'check to see if created in base  if not and add
        If checkYN("cc_base", "name_key", selected_name_key) = "N" Then
            saved_entry_type = entry_type
            entry_type = "ADD"
        End If

        If entry_type = "ADD" Then

            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                End If
            Next

            txtFields(0).Text = selected_name_key
            txtFields(1).Text = selected_screen_nam
            txtFields(2).Text = selected_sort_name
            txtFields(27).Text = Today.ToShortDateString
            'blank all the fields after 3 and make the key enabled

        Else
            entry_type = "EDIT"
            cmdUpdate.Visible = True

            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    If frmdata.DataType = "datetime" Or frmdata.DataType = "DATE" Then
                        cntrl.Text = CDate(frmdata.ActualData).ToShortDateString
                    Else
                        cntrl.Text = frmdata.ActualData
                    End If
                End If
                If TypeOf cntrl Is ComboBox Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    If frmdata.ActualData = CStr(-1) Then frmdata.ActualData = CStr(0)
                    race_choice.SelectedText = refs.Item(CInt(frmdata.ActualData)).DatumDesc 'since datum did not start at 0
                    '   race_choice.SelectedIndex = CInt(refs.Item(CInt(frmdata.ActualData)).Datum)
                End If
            Next
            txtFields(0).Enabled = False
        End If
        function_type = "DATA_ENTRY"

    End Sub

    Private Sub race_choice_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles race_choice.Enter
        Call ets_set_selected()
    End Sub

    Private Sub race_choice_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles race_choice.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            If race_choice.SelectedIndex = -1 Then race_choice.SelectedIndex = 0
            System.Windows.Forms.SendKeys.Send("{TAB}")
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub race_choice_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles race_choice.Leave
        race_choice.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()

        If Index = 4 Then 'first field to get focus after form load
            txtFields(0).Text = selected_name_key
            txtFields(1).Text = selected_screen_nam
            txtFields(2).Text = selected_sort_name
            txtFields(27).Text = CStr(Today)
        End If

        txtFields(Index).BackColor = Color.Aqua

    End Sub
    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index
                Case 3, 9
                    txtFields(Index).Text = UCase(txtFields(Index).Text)

                Case 7
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    'test for m or f or blank
                    If Len(txtFields(Index).Text) <> 0 Then
                        If txtFields(Index).Text <> "M" Then
                            If txtFields(Index).Text <> "F" Then
                                MsgBox("Please enter M or F")
                                Call ets_set_selected()
                                GoTo EventExitSub
                            End If
                        End If
                    End If

                Case 4, 5, 8
                    'allow entry of zero on a date field
                    If Index = 5 Then 'for terminate date
                        If Len(txtFields(Index).Text) = 0 Then
                            System.Windows.Forms.SendKeys.Send("{tab}")
                            KeyAscii = 0
                            GoTo EventExitSub
                        End If
                    End If

                    Dim retdate As String = ETS.Common.Module1.etsdate(txtFields(Index).Text, "N")

                    If retdate = "N" Then
                        txtFields(Index).Text = ""
                        MsgBox(" Bad Date")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtFields(Index).Text = CDate(retdate).ToShortDateString
                    End If
                Case 10  'ss num
                    If Len(txtFields(Index).Text) <> 0 Then
                        If ets_format(txtFields(Index).Text, retstring, 1) = "N" Then
                            MsgBox("Invalid Number")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        Else
                            txtFields(Index).Text = ets_format(txtFields(Index).Text, retstring, 1)
                        End If
                    End If

                
                  

                Case 11   'med num
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    'test for valid med number
                Case 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
            End Select

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Leave
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtFields(Index).BackColor = Color.White
    End Sub

   
End Class