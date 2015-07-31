Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports System
Imports System.Configuration
Imports PS.Common.Database
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient

Public Class ccdeduct
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "cc_deduct"
    Public frmWhereClause As String = " where ded_num = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        '
        '    If TypeOf Me.cntrl Is TextBox Then
        '        numstr = Me.cntrl.Name.ToString.Substring(11)
        '        TagColumnName = Me.cntrl.Tag.ToString
        '        RowData.Find(AddressOf FindColumnName)
        '        num1 = CInt(numstr)
        '        RowData.Item(num1).ActualData = Me.cntrl.Text
        '    End If
        'Next
        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                TagColumnName = Me.cntrl.Tag.ToString
                Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                If frmdata.DataType = "datetime" Or frmdata.DataType = "DATE" Then
                    If Len(Me.cntrl.Text) <> 0 Then
                        frmdata.ActualData = CDate(cntrl.Text).ToShortDateString
                    End If
                Else
                    frmdata.ActualData = cntrl.Text
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

    Private Sub frmccdeduct_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ctrform(Me)

        If entry_type = "ADD" Then
            For Each Me.cntrl In Me.Controls
                If TypeOf Me.cntrl Is TextBox Then
                    cntrl.Text = ""
                End If
            Next
            txtFields(0).Enabled = True
        Else
            entry_type = "EDIT"
            cmdUpdate.Visible = True
            Dim rs As New Collection
            RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
            For Each Me.cntrl In Me.Controls
                If TypeOf Me.cntrl Is TextBox Then
                    If String.IsNullOrEmpty(CStr(Me.cntrl.Tag)) Then Me.cntrl.Tag = ""
                    TagColumnName = Me.cntrl.Tag.ToString.Trim
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
            Next
            txtFields(0).Enabled = False
        End If

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

                Case 0 'check for length of field
                    If Len(txtFields(Index).Text) <> 4 Then
                        MsgBox("Deduction number must be 4 characters long.")
                        GoTo EventExitSub
                        Call ets_set_selected()
                    End If

                    'check for duplicates if add
                    'under edit this field can not get focus so ok to just check
                    If ETSCommon.CheckNumRecords("select * from cc_deduct where ded_num = '" & txtFields(0).Text & "'") <> 0 Then
                        MsgBox("This number has been used. Please enter a different one or cancel.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                Case 2
                    selected_name_key = ""
                    selected_screen_nam = ""

                    If Len(txtFields(Index).Text) = 0 Then
                        function_type_saved = entry_type
                        function_type = "DATA_ENTRY"
                        package_Type_saved = package_Type
                        package_Type = "TY"
                        frmnamechk.ShowDialog()
                        package_Type = package_Type_saved
                        function_type = function_type_saved
                        txtFields(Index).Text = selected_name_key
                        txtFields(CShort(Index + 1)).Text = selected_screen_nam
                    Else
                        valid_name = chkname_top(txtFields(Index).Text)

                        If valid_name = "N" Then
                            txtFields(CShort(Index + 1)).Text = ""
                            MsgBox("Not a valid number. Please enter correct number.")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        Else
                            txtFields(Index).Text = selected_name_key
                            txtFields(CShort(Index + 1)).Text = selected_screen_nam
                        End If
                    End If

                Case 5, 13 ' check acct number
                    valid_acct = "N"
                    saved_function_Type = function_type
                    function_type = "DATA_ENTRY"
                    retacct = etsacctnum_chk(txtFields(Index).Text)
                    If retacct = "N" Then
                        MsgBox("Invalid Account.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtFields(Index).Text = retacct
                    End If
                    function_type = saved_function_Type

                    '    Case 6
                    'checks for type
                    '  txtFields(Index) = UCase(txtFields(Index))

                    '  If txtFields(Index) <> "NT" Then
                    ' If txtFields(Index) <> "PEN" Then
                    'If txtFields(Index) <> "AT" Then
                    '   MsgBox "Please enter  NT,PEN,AT"
                    '  Call ets_set_selected
                    ' Exit Sub
                    'End If
                    '  End If
                    ' End If

                Case 7, 8
                    If Len(txtFields(Index).Text) = 0 Then
                        System.Windows.Forms.SendKeys.Send("{tab}")
                        KeyAscii = 0
                        GoTo EventExitSub
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

                Case 11
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
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub
End Class