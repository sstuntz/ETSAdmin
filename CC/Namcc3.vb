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
Imports System.Data.SqlClient
Imports System.String

Public Class namcc3
    Inherits System.Windows.Forms.Form
    Dim tmp_txtField_value As Object 'used for default values - TMK 8/26/03

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "nam_cc"
    Public frmWhereClause As String = " where name_key = '" & selected_name_key & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

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
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub check_change() ' added 5/6/03 lhw

        'looks for changed data and updates the change date field in cc_deposit
        'UPGRADE_WARNING: Controls method Screen.ActiveForm.Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        'For num = 0 To System.Windows.Forms.Form.ActiveForm.Controls.Count() - 1

        '    'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        '    If TypeOf CType(System.Windows.Forms.Form.ActiveForm.Controls(num), Object) Is System.Windows.Forms.TextBox Then

        '        'UPGRADE_WARNING: Couldn't resolve default property of object Screen.ActiveForm.Controls(num).DataChanged. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        If CType(System.Windows.Forms.Form.ActiveForm.Controls(num), Object).DataChanged = True Then
        '            'update the change date for this bank
        '            'added bank aba  19 22 25 29   6/6/00 lhw
        '            On Error Resume Next
        '            'UPGRADE_WARNING: Couldn't resolve default property of object Screen.ActiveForm.Controls(num).Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            Select Case CType(System.Windows.Forms.Form.ActiveForm.Controls(num), Object).Index
        '                'Case 3, 4, 7, 18, 19
        '                'eedepsit.Recordset.Fields("bk1_chg_Date") = Date
        '                'Case 8, 11, 20, 21, 22
        '                ' eedepsit.Recordset.Fields("bk2_chg_Date") = Date
        '                'Case 12, 15, 23, 24, 25     'had 22  to 12 lhw 6/6/00
        '                ' eedepsit.Recordset.Fields("bk3_chg_Date") = Date
        '                Case 16, 26, 27, 28, 29
        '                    'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '                    cc_deposit.Recordset.Fields("bk4_chg_Date").Value = Today
        '            End Select

        '            If Err.Number = 3265 Then
        '                MsgBox("The cc_deposit table has not been updated by ETS." & Chr(10) & "This message will be displayed whenever data is changed until the database is updated.")
        '            End If
        '            On Error GoTo 0
        '        End If

        '    End If

        'Next

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

    Private Sub frmnamcc3_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)

        Dim refs As New List(Of RefData)
        refs = ETSSQL.GetRefData("CC", "namcc3")
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

            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
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
                If TypeOf cntrl Is ComboBox Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    If frmdata.ActualData = CStr(-1) Then frmdata.ActualData = CStr(0)
                End If
            Next
            txtFields(0).Enabled = False
        End If
        function_type = "DATA_ENTRY"

        If entry_type_ee = "EDIT" Then
            Save_back.Enabled = True
        End If

        saved_name_key = selected_name_key
        saved_screen_nam = selected_screen_nam
        Me.BringToFront()

        ''UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Data1.RecordSource = "select * from nam_cc where name_key = " & Chr(34) & selected_name_key_cc & Chr(34)
        'Data1.Refresh()
        'txtFields(1).Text = selected_screen_nam_cc
        'txtFields(0).Text = selected_name_key_cc

        ''UPGRADE_ISSUE: Data property cc_deposit.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cc_deposit.RecordSource = "select * from cc_deposit where name_key = " & Chr(34) & selected_name_key_cc & Chr(34)
        'cc_deposit.Refresh()
        ''UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cc_deposit.Recordset.MoveFirst()

        'If Err.Number = 3021 Then
        '    'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    cc_deposit.Recordset.AddNew()
        '    'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    cc_deposit.Recordset.Fields("screen_nam").Value = selected_screen_nam_cc
        '    'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    cc_deposit.Recordset.Fields("name_key").Value = selected_name_key_cc
        '    'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    cc_deposit.Recordset.Update()

        'Else
        '    'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    cc_deposit.Recordset.Edit()
        '    'lookup bank name
        '    'UPGRADE_ISSUE: Data property cc_deposit.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    If Len(cc_deposit.Recordset.Fields("aba_num").Value) <> 0 Then


        '    End If
        'End If


    End Sub


    Private Sub Save_go_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Save_go.Click
        Call check_change() ' this changes the date in cc_deposit
        Call Update()
        selected_name_key = saved_name_key
        selected_screen_nam = saved_screen_nam
        Me.Dispose()
        namcc2.Dispose()
        namcc1.Dispose()


    End Sub

    Private Sub Save_back_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Save_back.Click

        Call check_change() ' this changes the date in cc_deposit

        Call Update()
        selected_name_key = saved_name_key
        selected_screen_nam = saved_screen_nam
        Me.Visible = False
        namcc2.Visible = True
        namcc2.Focus()

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()

    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then

            Select Case Index

                Case 16
                    'checks for yes no v
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    If txtFields(Index).Text <> "N" And txtFields(Index).Text <> "Y" And txtFields(Index).Text <> "V" Then
                        MsgBox("Please enter a Y for checks or V for vouchers.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                Case 26
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    If txtFields(Index).Text <> "S" Or txtFields(Index).Text <> "C" Then
                        MsgBox("You must enter a C or an S.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                Case 28
                    package_Type_saved = package_Type
                    package_Type = "GL"
                    function_type = "DATA_ENTRY"
                    saved_name_key = selected_name_key
                    saved_screen_nam = selected_screen_nam
                    'looking up bank

                    If Val(txtFields(Index).Text) = 0 Then
                        Dim frmnamechk As New frmnamechk
                        frmnamechk.ShowDialog()
                        txtFields(Index).Text = selected_name_key
                        Desc.Text = selected_screen_nam
                        valid_name = "Y"
                    Else
                        valid_name = chkname(txtFields(Index).Text)
                        txtFields(Index).Text = selected_name_key
                        Desc.Text = selected_screen_nam
                    End If

                    If valid_name = "N" Then
                        MsgBox("Invalid bank number")
                        Call ets_set_selected()
                        package_Type = package_Type_saved
                        GoTo EventExitSub
                    End If

                    selected_name_key = saved_name_key
                    selected_screen_nam = saved_screen_nam

                    txtFields(CShort(Index + 1)).Text = ETSCommon.GetDatum("nam_bank", "bank_key", txtFields(Index).Text, "bk_transit")
                    package_Type = package_Type_saved
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