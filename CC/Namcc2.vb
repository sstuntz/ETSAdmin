Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.common.Module1
Imports PS.Common
Imports ETS.pr_common
Imports System.Data.SqlClient
Imports System.String

Public Class namcc2

    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "nam_cc"
    Public frmWhereClause As String = " where name_key = '" & selected_name_key & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control

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

    Private Sub frmnamcc2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Dim refs As New List(Of RefData)
        refs = ETSSQL.GetRefData("CC", "namcc2")
        For Each ref In refs
            Select Case Me.Controls(ref.ControlName).GetType.ToString
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

        If entry_type = "ADD" Then

            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                End If
            Next

            txtFields(0).Text = selected_name_key
            txtFields(1).Text = selected_screen_nam
            txtFields(2).Text = selected_sort_name
            'blank all the fields after 3 and make the key enabled

        Else
            entry_type = "EDIT"
            Save_back.Enabled = True

            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    If String.IsNullOrEmpty(CStr(Me.cntrl.Tag)) Then Me.cntrl.Tag = ""
                    TagColumnName = Me.cntrl.Tag.ToString
                    If Len(TagColumnName) <> 0 Then
                        Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                        If Len(frmdata.ActualData) <> 0 Then
                            If frmdata.DataType = "datetime" Or frmdata.DataType = "DATE" Then
                                cntrl.Text = CDate(frmdata.ActualData).ToShortDateString
                            Else
                                cntrl.Text = frmdata.ActualData.ToString
                            End If
                        End If
                    End If
                End If
                If TypeOf cntrl Is ComboBox Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    If frmdata.ActualData = CStr(-1) Then frmdata.ActualData = CStr(0)
                End If

                Dim num As Short
                For num = 24 To 33 Step 3
                    senddpt = txtFields(num).Text
                    Call etsdednum_chk(senddpt, retdpt, retdptdesc, valid_dpt)
                    co_name(num).Text = selected_lookup_desc
                    selected_lookup_desc = ""
                Next
                txtFields(0).Enabled = False
            Next
        End If
        function_type = "DATA_ENTRY"

        If entry_type_ee = "EDIT" Then
            Save_back.Enabled = True
        End If

        saved_name_key = selected_name_key
        saved_screen_nam = selected_screen_nam
        Me.BringToFront()

    End Sub

    Private Sub Save_back_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Save_back.Click
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


        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                TagColumnName = Me.cntrl.Tag.ToString
                If Len(TagColumnName) <> 0 Then
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    If frmdata.DataType = "datetime" Or frmdata.DataType = "DATE" Then
                        frmdata.ActualData = cntrl.Text
                    Else
                        frmdata.ActualData = cntrl.Text
                    End If
                End If
            End If

        Next

        Select Case entry_type.ToString
            Case "ADD"
                'add sort name and agency
                RowData.Item(21).ActualData = selected_sort_name
                RowData.Item(22).ActualData = CStr((AgencyNum))
                Call ETSSQL.InsertData(frmTableName, RowData)
            Case "EDIT"
                Call ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)
        End Select

        'check to make sure that there are deduction number for ded dol
        'For num = 24 To 33 Step 3
        '    If Val(txtFields(num).Text) <> 0 Then
        '        If Len(txtFields(num - 1).Text) = 0 Then
        '            MsgBox("You must have a deduction number for each item with deduction dollars.")
        '            Exit Sub
        '        End If
        '    End If
        'Next

        selected_name_key = saved_name_key
        selected_screen_nam = saved_screen_nam
        Me.Visible = False
        namcc1.Visible = True
        namcc1.Focus()

    End Sub

    Private Sub Save_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles save.Click
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


        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                TagColumnName = Me.cntrl.Tag.ToString
                If Len(TagColumnName) <> 0 Then
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    If frmdata.DataType = "datetime" Or frmdata.DataType = "DATE" Then
                        frmdata.ActualData = cntrl.Text
                    Else
                        frmdata.ActualData = cntrl.Text
                    End If
                End If
            End If

        Next

        Select Case entry_type.ToString
            Case "ADD"
                'add sort name and agency
                RowData.Item(21).ActualData = selected_sort_name
                RowData.Item(22).ActualData = CStr((AgencyNum))
                Call ETSSQL.InsertData(frmTableName, RowData)
            Case "EDIT"
                Call ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)
        End Select
        selected_name_key = saved_name_key
        selected_screen_nam = saved_screen_nam

        Me.Visible = False
        namcc3.Visible = True
        namcc3.Focus()

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()

    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            Select Case Index
                Case 2, 22
                    'checks for yes no
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    If txtFields(Index).Text <> "N" And txtFields(Index).Text <> "Y" Then
                        MsgBox("Please enter a Y or N")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    If Index = 16 And txtFields(Index).Text = "N" Then
                        save.Focus()
                        GoTo EventExitSub
                    End If

                Case 3
                    'checks for yes no v
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    If txtFields(Index).Text <> "N" And txtFields(Index).Text <> "Y" And txtFields(Index).Text <> "V" Then
                        MsgBox("Please enter a Y for checks or V for vouchers or N for nocheck.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                Case 4
                    'checks for m or s
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    If txtFields(Index).Text <> "M" And txtFields(Index).Text <> "S" Then
                        MsgBox("Please enter a M or S")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                Case 5, 21, 14, 22, 25, 28
                    'checks for dfq
                    txtFields(Index).Text = UCase(txtFields(Index).Text)

                    If txtFields(Index).Text <> "A" And txtFields(Index).Text <> "M" And txtFields(Index).Text <> "S" And txtFields(Index).Text <> "B" And txtFields(Index).Text <> "W" Then
                        MsgBox("Please enter an A,M,S,B, or W")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                Case 6, 7, 9
                    'checks for amount
                    If Len(txtFields(Index).Text) = 0 Then
                        txtFields(Index).Text = CStr(0)
                    End If

                Case 11, 12
                    If Len(txtFields(Index).Text) = 0 Then
                        MsgBox("Please enter a response")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    If txtFields(12).Text = "na" Then
                        txtFields(12).Text = " " 'has to be a non zero length field
                        GoTo done1
                    End If
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    If ets_state_chk(txtFields(Index).Text) = "N" Then
                        MsgBox("Invalid state/province")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                Case 23, 26, 29, 32
                    'checks for dollar amounts and reformats them
                    If Len(txtFields(Index).Text) = 0 Then
                        txtFields(Index).Text = CStr(0)
                    End If
                    txtFields(Index).Text = String.Format("{0:F2}", Val(txtFields(Index).Text))
                Case 24, 27, 30, 33
                    'na is a valid name
                    If txtFields(Index).Text = "na" Then
                        co_name(Index).Text = "None"
                        GoTo done1
                    End If

                    If Len(txtFields(Index).Text) = 0 Then
                        dedlkup.ShowDialog()
                        txtFields(Index).Text = selected_ded_num
                        co_name(Index).Text = selected_plan_desc
                    Else
                        senddpt = txtFields(Index).Text
                        valid_dpt = etsdednum_chk(senddpt, retdpt, retdptdesc, valid_dpt)
                        If valid_dpt = "N" Then
                            MsgBox("Not a valid deduction number.")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                        txtFields(Index).Text = senddpt
                        co_name(Index).Text = selected_lookup_desc
                        selected_lookup_desc = ""
                    End If

            End Select
done1:
            System.Windows.Forms.SendKeys.Send("{TAB}")
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
        Call ets_de_selected()
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

End Class