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

Public Class frmprog
    Inherits System.Windows.Forms.Form
    Public TagColumnName As String
    Public frmTableName As String = "program"
    Public frmWhereClause As String = " where prog_num = '" & selected_prog_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String
    Dim refs As New List(Of RefData)


    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        'test for completeness on txtfields only
        'fields 0 1 2 3 6 9 16 17 18 20 40 49


        'For num = 0 To 100
        '    msg = "," & CStr(num) & ","
        '    Response = InStr(",0,2,3,4,", msg)
        '    'If Response <> 0 Then
        '    '    If Len(txtFields(num).Text) = 0 Then
        '    '        MsgBox("You must fill in all required fields.")
        '    '        txtFields(num).Focus()
        '    '        Exit Sub
        '    '    End If
        '    'End If

        'Next

        'check combobox for not null and not -1   
        'if add make sure not a duplicate


        For Each Me.cntrl In Me.Controls
            If Not (String.IsNullOrEmpty(Trim(CStr(cntrl.Tag)))) Then
                If TypeOf Me.cntrl Is TextBox Then
                    For cnt As Integer = 0 To RowData.Count - 1
                        If RowData.Item(cnt).ColumnName = cntrl.Tag.ToString Then
                            RowData.Item(cnt).ActualData = cntrl.Text
                        End If
                    Next
                End If
                If TypeOf Me.cntrl Is ComboBox Then
                    For cnt As Integer = 0 To RowData.Count - 1
                        If RowData.Item(cnt).ColumnName = cntrl.Tag.ToString Then
                            RowData.Item(cnt).ActualData = division.SelectedIndex.ToString
                        End If
                    Next
                End If

            End If
        Next

        Select Case entry_type.ToString
            Case "ADD"
                Call ETSSQL.InsertData(frmTableName, RowData)
            Case "EDIT"
                Call ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)
        End Select
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
        selected_lookup_num = ""
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub division_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles division.Enter
        Call ets_set_selected()
    End Sub

    Private Sub division_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles division.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            If division.SelectedIndex = -1 Then division.SelectedIndex = 0
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub division_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles division.Leave
        division.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub frmprog_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        Dim refs As New List(Of RefData)
        refs = ETSSQL.GetRefData("ATT", "frmprog")
        For Each ref In refs
            Select Case Me.Controls(ref.ControlName).GetType.ToString
                Case "System.Windows.Forms.ComboBox"
                    Dim ctrl As String = Me.Controls(ref.ControlName).ToString
                    division.Items.Add(ref.DatumDesc)
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

        frmWhereClause = "where prog_num = '" & selected_prog_num & "' and fiscal_yr = '" & selected_prog_year & "'"

        If entry_type = "ADD" Then
            Me.Text = "ADD Program Form"
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                    Txtfields(0).Enabled = True
                End If
            Next
            Txtfields(3).Text = CStr(current_fiscal) 'Year(Date)
            Txtfields(6).Text = Today.ToShortDateString
            frmWhereClause = ""

        Else
            'make sure combo box set to what is stored
            Me.Text = "Edit Program Form"
            entry_type = "EDIT"
            cmdUpdate.Visible = True
            Dim rs As New Collection
            RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    If Not IsNothing(frmdata) Then
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
                    division.SelectedText = refs.Item(CInt(frmdata.ActualData)).DatumDesc
                    division.SelectedIndex = CInt(refs.Item(CInt(frmdata.ActualData)).Datum)
                End If
            Next
            Txtfields(0).Enabled = False

        End If
    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = Txtfields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = Txtfields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index
                Case 0
                    If entry_type = "ADD" And Len(Txtfields(Index).Text) = 0 Then
                        MsgBox("Can not lookup on an ADD.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    If ETSCommon.CheckYN("program", "prog_num", Txtfields(Index).Text, "N") = "Y" Then
                        MsgBox("The number has been used. Please re-enter another number.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    '	valid_YN = "N"

                Case 1
                    If Len(Txtfields(Index).Text) = 0 Then
                        MsgBox("You must enter a description.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                Case 2  'rate

                    If IsNumeric(Txtfields(Index).Text) Then
                        Txtfields(Index).Text = String.Format(Txtfields(Index).Text, "C")
                    Else
                        MsgBox("Invalid Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                Case 3 'fiscal year
                    If Not IsNumeric(Txtfields(Index).Text) Then
                        MsgBox("Please enter a number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    If Len(Txtfields(Index).Text) <> 4 Then
                        MsgBox("Please enter a 4 digit year.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If



                Case 4  'location
                    '		valid_YN = "N"
                    Txtfields(Index).Text = UCase(Txtfields(Index).Text)
                    If Len(Txtfields(Index).Text) = 0 Then
                        saved_entry_type = entry_type
                        prog_loc_lookup.ShowDialog()
                        entry_type = saved_entry_type
                        Txtfields(Index).Text = selected_lookup_num
                    Else
                        If Not chk_prog_loc_type(Txtfields(Index).Text) Then
                            MsgBox("Invalid input.")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If

                Case 5 'ufr
                    '	valid_YN = "N"
                    Txtfields(Index).Text = UCase(Txtfields(Index).Text)
                    If Len(Txtfields(Index).Text) = 0 Then
                        saved_entry_type = entry_type
                        '     ufr_lookup.Show 1
                        entry_type = saved_entry_type
                        Txtfields(Index).Text = selected_lookup_num
                    End If
                    '  Call chk_ufr_type(Txtfields(Index), Valid_YN)
                    'If valid_YN = "N" Then
                    '	MsgBox("Invalid input.")
                    '	Call ets_set_selected()
                    '	GoTo EventExitSub
                    'End If

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
        Dim Index As Short = Txtfields.GetIndex(CType(eventSender, TextBox))

        Txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

   
End Class