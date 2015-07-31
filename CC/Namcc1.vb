Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports ETS.stpr_mod
Imports ETS.pr_common
Imports ETS.clpr_mod
Imports PS.Common
Imports System.Data.SqlClient
Imports System.String

Public Class namcc1

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

    Private Sub dirdep_Click()
        'frmnamcc5.Show 1

    End Sub

    Private Sub frmnamcc1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        Dim refs As New List(Of RefData)
        refs = ETSSQL.GetRefData("CC", "nam_cc")
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

            txtfields(0).Text = selected_name_key
            txtfields(1).Text = selected_screen_nam
            txtfields(2).Text = selected_sort_name
            'blank all the fields after 3 and make the key enabled

        Else
            entry_type = "EDIT"

            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    If IsDBNull(Me.cntrl.Tag.ToString) Then Me.cntrl.Tag = ""
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
            Next
            txtfields(0).Enabled = False
        End If
        function_type = "DATA_ENTRY"

        'the following checks to see if there is a vacation entry in which case yes is put in field vac_elig
        If entry_type_ee = "EDIT" Then
            db = cc_data_path & "cc.mdb"
            'tmpdb = DAODBEngine_definst.OpenDatabase(db)
            'tmpset = tmpdb.OpenRecordset("ccvac", dao.RecordsetTypeEnum.dbOpenDynaset)
            'sqlstmnt = " name_key = " & Chr(34) & selected_name_key_cc & Chr(34)
            'tmpset.FindFirst(sqlstmnt)
            'If tmpset.NoMatch Then
            '    vac_Elig.Text = "N"
            'Else
            '    vac_Elig.Text = "Y"
            'End If

            vacation.Enabled = True

            '.Enabled = True
            'goto4.Enabled = True
            'goto5.Enabled = True
            'goto6.Enabled = True

        End If


        If txtfields(11).Text = "na" Or Len(txtfields(10).Text) = 0 Then
            txtfields(11).Text = "na"
        End If

        saved_name_key = selected_name_key
        saved_screen_nam = selected_screen_nam

        'load new coach field
        CoachNameKey.Text = ETSCommon.GetDatum("nam_cc", "name_key", selected_name_key, "Coach")
        CoachScreenName.Text = ETSCommon.GetDatum("nam_addr", "name_key", CoachNameKey.Text, "screen_nam")


    End Sub

    Private Sub Save_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

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
        namcc2.Visible = True
        namcc2.Focus()


    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter, CoachNameKey.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()

    End Sub

    Private Sub coachnamekey_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles CoachNameKey.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            If CoachNameKey.Text.Length = 0 Then
                'do lookup
                saved_name_key = selected_name_key
                Dim frmnamechk As New frmnamechk
                frmnamechk.ShowDialog()
                CoachNameKey.Text = selected_name_key
                selected_name_key = saved_name_key
                CoachScreenName.Text = ETSCommon.GetDatum("nam_addr", "name_key", CoachNameKey.Text, "screen_nam")
            Else
                'check value
                If ETSCommon.CheckYN("nam_addr", "name_key", CoachNameKey.Text, "screen_nam") = "N" Then
                    MsgBox("Invalid number")
                    GoTo EventExitSub
                End If
                CoachScreenName.Text = ETSCommon.GetDatum("nam_addr", "name_key", CoachNameKey.Text, "screen_nam")
            End If
            System.Windows.Forms.SendKeys.Send("{TAB}")
            KeyAscii = 0
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))

        If KeyAscii = 13 Or KeyAscii = 9 Then
            Select Case Index
                Case 1
                Case 2
                    ets_format(txtfields(Index).Text, retstring, 2)
                    If retstring = "N" Then
                        MsgBox("invalid phone number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    txtfields(Index).Text = retstring
                    retstring = ""

                Case 3, 4, 16
                    If Len(txtfields(Index).Text) = 0 Then
                        System.Windows.Forms.SendKeys.Send("{tab}")
                        KeyAscii = 0
                        GoTo EventExitSub
                    End If
                    Dim retdate As String = ETS.Common.Module1.etsdate(txtfields(Index).Text, "N")
                    If retdate = "N" Then
                        txtfields(Index).Text = ""
                        MsgBox(" Bad Date")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtfields(Index).Text = CDate(retdate).ToShortDateString
                        txtfields(5).Text = CStr(Month(CDate(txtfields(Index).Text)))
                    End If
                Case 5
                    If Val(txtfields(Index).Text) > 12 Or Val(txtfields(Index).Text) < 1 Then
                        MsgBox("Invalid Month Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                Case 6
                    If Len(txtfields(Index).Text) = 0 Then
                        dptnumlookup.ShowDialog()
                        txtfields(Index).Text = selected_lookup_num
                    End If

                    senddpt = txtfields(6).Text
                    retdpt = ""
                    retdptdesc = ""
                    valid_dpt = etsdptnum_chk(senddpt, retdpt, retdptdesc)

                    If valid_dpt = "N" Then
                        MsgBox("Not a valid department number.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    txtfields(6).Text = valid_dpt

                Case 11
                    'this checks the disab name and number
                    If txtfields(11).Text <> "na" Then
                        If Len(txtfields(Index).Text) = 0 Then
                            disablookup.ShowDialog()
                            txtfields(Index).Text = selected_lookup_num
                            txtfields(12).Text = selected_lookup_desc
                        Else
                            valid_dpt = ets_disab_num_chk(txtfields(11).Text, retjobdesc, valid_dpt)
                            If valid_dpt = "N" Then
                                MsgBox("Invalid Disab number.")
                                Call ets_set_selected()
                                GoTo EventExitSub
                            Else
                                txtfields(CShort(Index + 1)).Text = selected_lookup_desc
                            End If
                        End If
                    Else
                        txtfields(12).Text = "Not Applicable"
                    End If

                Case 14, 17

                    If Len(txtfields(Index).Text) = 0 Then
                        txtfields(Index).Text = CStr(0)
                    End If
                    txtfields(Index).Text = String.Format("{0:C}", txtfields(Index).Text)
                Case 18
                    txtfields(Index).Text = UCase(txtfields(Index).Text)
                    If txtfields(Index).Text <> "Y" Then
                        If txtfields(Index).Text <> "N" Then
                            MsgBox("Please use Y or N")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If

                Case 19

                    If Len(txtfields(Index).Text) <> 0 Then
                        If ets_format(txtfields(Index).Text, retstring, 1) = "N" Then
                            MsgBox("Invalid Number")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        Else
                            txtfields(Index).Text = ets_format(txtfields(Index).Text, retstring, 1)
                        End If
                    End If
                    If txtfields(19).Modified = True Then
                        ' check_dup_soc_sec_num(txtfields(19).Text, valid_lookup)
                        If valid_lookup = "N" Then
                            MsgBox("This is a duplicate social security number.  Please check it or leave blank.")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If

            End Select

            System.Windows.Forms.SendKeys.Send("{TAB}")
            KeyAscii = 0


        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave, CoachNameKey.Leave
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Call ets_de_selected()
        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub vac_Elig_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vac_Elig.Enter
        If vac_Elig.Text = "" Then vac_Elig.Text = "N" 'added 7/3/03 TMK
        Call ets_set_selected()
    End Sub

    Private Sub vac_Elig_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles vac_Elig.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        ' this is where to put the code to set up vacation table
        If KeyAscii = 13 Or KeyAscii = 9 Then

            vac_Elig.Text = UCase(vac_Elig.Text)
            If vac_Elig.Text <> "N" And vac_Elig.Text <> "Y" Then
                MsgBox("Please enter a Y or N")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            'UPGRADE_ISSUE: TextBox property vac_Elig.DataChanged was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
            'If entry_type = "ADD" Or vac_Elig.DataChanged = True Then
            '    If vac_Elig.Text = "Y" Then
            '        On Error Resume Next
            '        'this checks to add a vacation table entry and to ask if you want to edit it
            '        'UPGRADE_ISSUE: Data property Data4.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '        Data4.Recordset.AddNew()
            '        'UPGRADE_ISSUE: Data property Data4.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '        Data4.Recordset.Fields("name_key").Value = selected_name_key_cc
            '        'UPGRADE_ISSUE: Data property Data4.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '        Data4.Recordset.Fields("screen_nam").Value = selected_screen_nam_cc
            '        'UPGRADE_ISSUE: Data property Data4.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '        Data4.Recordset.Fields("sort_name").Value = selected_sort_name_cc
            '        'UPGRADE_ISSUE: Data property Data4.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '        Data4.Recordset.Update()
            '        'If err = 3022 Then
            '        'On Error GoTo 0
            '        Response = MsgBox("Do you wish to edit the vacation table now?", 4)
            '        If Response = MsgBoxResult.Yes Then
            '            frmccvac.ShowDialog()
            '        End If
            '        'End If
            '    End If
            'End If

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub vac_Elig_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vac_Elig.Leave
        Call ets_de_selected()
        vac_Elig.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub vacation_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vacation.Click
        'scs  frmccvac.ShowDialog()

    End Sub

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub CoachNameKey_TextChanged(sender As System.Object, e As System.EventArgs) Handles CoachNameKey.TextChanged

    End Sub
End Class
