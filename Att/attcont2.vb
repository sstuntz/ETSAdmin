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

Public Class attcont2
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "cc_cont"
    Public frmWhereClause As String = " where contract_key = '" & selected_contract_key & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        Call SaveData()
        Me.Close()
        Me.Dispose()
        attcont3.ShowDialog()

    End Sub

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If UCase(CName.ColumnName) = UCase(TagColumnName) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub attcont2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load


        Dim refs As New List(Of RefData)
        refs = ETSSQL.GetRefData("ATT", "attcont2")
        For Each ref In refs
            Select Case Me.Controls(ref.ControlName).GetType.ToString
                Case "System.Windows.Forms.ComboBox"
                    Dim ctrl As String = Me.Controls(ref.ControlName).ToString
                    reimb.Items.Add(ref.DatumDesc)
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

        Me.WindowState = FormWindowState.Normal
        ctrform(Me)
        Me.BringToFront()

        If Len(selected_grouping) <> 0 Then
            sqlstmnt = sqlstmnt & " and fiscal_yr = '" & selected_grouping & "'"
        End If

        'always and edit
        entry_type = "EDIT"

        For Each Me.cntrl In Me.Controls
            If TypeOf cntrl Is TextBox Then
                If Not Len(Me.cntrl.Tag) = 0 Then
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
            End If
            If TypeOf cntrl Is ComboBox Then
                TagColumnName = Me.cntrl.Tag.ToString
                Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                If frmdata.ActualData = CStr(-1) Then frmdata.ActualData = CStr(0)
                reimb.SelectedText = refs.Item(CInt(frmdata.ActualData)).DatumDesc
                ' reimb.SelectedIndex = CInt(refs.Item(CInt(frmdata.ActualData)).Datum)
            End If
        Next

        current_fiscal = CInt(CStr(Year(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 6, Today))))

        ' fill in the extra info
        Dim BillPerson As New NameAddrData
        BillPerson = ETSSQL.GetOneNameAddrData("select * from nam_addr where name_key = '" & txtFields(3).Text & "'")
        _Text1_0.Text = BillPerson.ScreenNam
        _Text1_1.Text = BillPerson.Address1
        _Text1_2.Text = BillPerson.Address2
        _Text1_3.Text = BillPerson.City
        _Text1_4.Text = BillPerson.State
        _Text1_5.Text = BillPerson.Zip4
        _Text1_6.Text = BillPerson.Telephone
        TextBox1.Text = BillPerson.Email
        TextBox2.Text = BillPerson.Address3
        selected_name_key = txtFields(3).Text

        txtFields(57).Focus()

    End Sub

    Private Sub reimb_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles reimb.Enter
        Call ets_set_selected()
    End Sub

    Private Sub reimb_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles reimb.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            If reimb.SelectedIndex = -1 Then reimb.SelectedIndex = 0
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub reimb_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles reimb.Leave
        reimb.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub retpg1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles retpg1.Click

        Call SaveData()
        Me.Dispose()
        attcont1.ShowDialog()

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

                Case 0, 7, 36, 39, 40, 41, 42, 43, 47
                    txtFields(Index).Text = UCase(txtFields(Index).Text)

                Case 8
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    If Len(txtFields(8).Text) = 0 Then
                        MsgBox("You must enter the billable codes or an X.")
                        txtFields(8).Focus()
                        GoTo EventExitSub
                    End If

                Case 5, 6

                    If med_flag = "Y" Then
                        If Index = 5 Then num_type = "PROV"
                        If Index = 6 Then num_type = "PROC"
                        'check the med nums if now avail send message and move on
                        function_type = "DATA_ENTRY"
                        If Len(txtFields(Index).Text) = 0 Then
                            '    procnum_lookup.Show 1
                            txtFields(Index).Text = selected_lookup_num
                        End If

                        'check the array
                        'For num = 0 To 200
                        '	If txtFields(Index).Text = med_array(2, num) Then GoTo oknum
                        'Next 
                        MsgBox("Invalid Number.")
                        Call ets_set_selected()
                        GoTo EventExitSub

oknum:
                    End If

                Case 3, 50
                    'look up and fill in name and address info
                    function_type = "DATA_ENTRY"
                    package_Type = "TY"
                    valid_name = "N"

                    If Val(txtFields(Index).Text) = 0 Then
                        frmnamechk.ShowDialog()
                        txtFields(Index).Text = selected_name_key
                        _Text1_0.Text = selected_screen_nam
                    End If

                    Call chkname(txtFields(Index).Text)
                    _Text1_0.Text = selected_screen_nam
                    If valid_name = "N" Then
                        MsgBox(" Invalid Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                Case 57
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    'must be in the list
                    If InStr("B+EHPE+B", txtFields(57).Text) = 0 Then
                        MsgBox("Must enter an E,P,H,B or N")
                        Exit Sub
                    End If

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

    Private Sub SaveData()
        'test for completeness on txtfields only
        'fields 0 1 2 3 6 9 16 17 18 20 40 49


        'For num = 0 To 100
        '    msg = "," & CStr(num) & ","
        '    Response = InStr(",0,1,2,3,6,9,16,17,18,20,40,49,", msg)
        '    If Response <> 0 Then
        '        If Len(Txtfields(num).Text) = 0 Then
        '            MsgBox("You must fill in all required fields.")
        '            Txtfields(num).Focus()
        '            Exit Sub
        '        End If
        '    End If

        'Next

        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                If Not Len(Me.cntrl.Tag) = 0 Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    If Len(TagColumnName) <> 0 Then
                        Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                        frmdata.ActualData = Me.cntrl.Text
                    End If
                End If
            End If
            If TypeOf Me.cntrl Is ComboBox Then
                TagColumnName = Me.cntrl.Tag.ToString
                Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                frmdata.ActualData = CStr(reimb.SelectedIndex)
            End If
        Next

        'always edit on page 2

        
        Call ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)


    End Sub


End Class