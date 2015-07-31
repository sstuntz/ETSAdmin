Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports ETS.clpr_mod
Imports System.Data.SqlClient
Imports System.String

Public Class job
    Inherits System.Windows.Forms.Form

    Dim num As Short
    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "ccjob"
    Public frmWhereClause As String = " where Job_num = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public jobdata As List(Of String)


    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        'For num = 0 To 100
        '    msg = "," & CStr(num) & ","
        '    Response = InStr(",0,1,2,5,9,15,28,29,", msg)
        '    If Response <> 0 Then
        '        If Len(txtfields(num).Text) = 0 Then
        '            MsgBox("You must fill in all required fields.")
        '            txtfields(num).Focus()
        '            Exit Sub
        '        End If
        '    End If

        'Next

        If txtfields(5).Text = "PC" Then
            If Val(txtfields(8).Text) = 0 Then
                MsgBox("You must enter pcs_hr for a PC class job.")
                txtfields(8).Focus()
                Exit Sub
            End If
        End If

        If txtfields(5).Text = "OP" Then
            If Val(txtfields(8).Text) = 0 Then
                MsgBox("You must enter pcs_hr for a PC class job.")
                txtfields(8).Focus()
                Exit Sub
            End If
        End If

        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                If TypeOf Me.cntrl Is TextBox Then
                    If String.IsNullOrEmpty(CStr(Me.cntrl.Tag)) Then Me.cntrl.Tag = ""
                    TagColumnName = Me.cntrl.Tag.ToString.Trim
                    If Len(TagColumnName) <> 0 Then
                        TagColumnName = Me.cntrl.Tag.ToString
                        Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                        frmdata.ActualData = Me.cntrl.Text
                    End If
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
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmjob_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        sqlstmnt = "select * from ccjob where job_num = '" & selected_lookup_num & "'"
        Me.WindowState = FormWindowState.Normal     'added lhw 06/19/2012
        ctrform(Me)

        Dim refs As New List(Of RefData)
        refs = ETSSQL.GetRefData("ATT", "job")
        For Each ref In refs
            Select Case Me.Controls(ref.ControlName).GetType.ToString
                Case "System.Windows.Forms.ComboBox"
                    Dim ctrl As String = Me.Controls(ref.ControlName).ToString
                    '  race_choice.Items.Add(ref.DatumDesc)
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
            txtfields(0).Focus()
        Else
            entry_type = "EDIT"
            cmdUpdate.Visible = True
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
            txtfields(0).Enabled = False
            txtfields(2).Focus()
        End If
        function_type = "DATA_ENTRY"

        txtfields(16).Text = Today.ToShortDateString
        ContDesc.Text = ETSCommon.GetDatum("Cc_cont", "Contract_key", _txtfields_19.Text, "Cont_desc")
        chkname_top(_txtfields_2.Text)
        _txtfields_3.Text = selected_screen_nam
        _txtfields_4.Text = selected_sort_name

    End Sub

    Private Sub txtfields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
        txtfields(Index).BackColor = Color.Aqua
    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index
                Case 0
                    txtfields(Index).Text = UCase(txtfields(Index).Text)
                    If entry_type = "ADD" Then
                        If Len(RTrim(LTrim(txtfields(Index).Text))) = 0 Then
                            MsgBox("You must enter a job num when adding.")
                            GoTo EventExitSub
                            Call ets_set_selected()
                        End If
                        'test if job number exists
                        jobdata = etsjobnum_chk(txtfields(0).Text)
                        If jobdata(0) = "Y" Then
                            MsgBox("Job already exists.  Please edit it.")
                            KeyAscii = 0
                            GoTo EventExitSub
                        End If
                    End If


                Case 2
                    function_type = "DATA_ENTRY"
                    valid_name = "N"
                    selected_name_key = ""
                    saved_package_Type = package_Type
                    package_Type = "TY" 'changed 4/2/99 so default is for customers without accts receivable

                    If Val(txtfields(Index).Text) = 0 Then
                        Dim frmnamechk As New frmnamechk
                        frmnamechk.ShowDialog()
                        txtfields(Index).Text = selected_name_key
                        txtfields(CShort(Index + 1)).Text = selected_screen_nam
                        txtfields(CShort(Index + 2)).Text = selected_sort_name
                    Else
                        valid_name = chkname(txtfields(Index).Text)
                        If valid_name = "N" Then
                            MsgBox("Invalid client number")
                            txtfields(CShort(Index + 1)).Text = ""
                            txtfields(CShort(Index + 2)).Text = ""
                            Call ets_set_selected()
                            GoTo EventExitSub
                        Else
                            txtfields(Index).Text = selected_name_key
                            txtfields(CShort(Index + 1)).Text = selected_screen_nam
                            txtfields(CShort(Index + 2)).Text = selected_sort_name
                        End If
                    End If

                    package_Type = saved_package_Type

                Case 5
                    txtfields(Index).Text = UCase(txtfields(Index).Text)

                    If Len(RTrim(LTrim(txtfields(Index).Text))) = 0 Then
                        pclasslkup.ShowDialog()
                        txtfields(Index).Text = selected_lookup_num
                    End If

                    If ETSCommon.CheckOnceYN("cc_paycl", "pay_class", txtfields(Index).Text, "N") = "N" Then
                        MsgBox("Invalid Pay Class")
                        GoTo EventExitSub
                    End If

                Case 7, 9, 18, 24, 25, 32, 33, 34, 35
                    If Len(txtfields(Index).Text) = 0 Then
                        txtfields(Index).Text = CStr(0)
                    End If

                    txtfields(Index).Text = String.Format(txtfields(Index).Text, "##0.00")

                Case 8 ' pcs_hr
                    'changed to >= 0.1 8/28/06 per Maggie MacDonald DOL Boston
                    If Val(txtfields(Index).Text) > 0 Then 'added for rounding up 6/02 lhw/scs
                        txtfields(10).Text = CStr(CDbl(txtfields(9).Text) / CDbl(txtfields(8).Text))
                        Text1.Text = String.Format(txtfields(10).Text, "###0.00000000") '9/20/06 shows 8 digits
                        If CDbl(txtfields(10).Text) * 10000 - CInt(CDbl(txtfields(10).Text) * 10000) >= 0.1 Then
                            If CDbl(txtfields(10).Text) * 10000 - CInt(CDbl(txtfields(10).Text) * 10000) < 0.5 Then
                                txtfields(10).Text = CStr(CDec(CDbl(txtfields(10).Text) + 0.0001))
                            End If
                        End If
                        txtfields(10).Text = CStr(CDec(txtfields(10).Text))
                        txtfields(10).Text = String.Format(txtfields(10).Text, "###0.0000") 'changed to 4 from 5 7/8/06 lhw
                        txtfields(7).Focus()
                        KeyAscii = 0
                        GoTo EventExitSub
                    End If


                Case 10, 14 'sell_prc   pc_rate
                    If Len(txtfields(Index).Text) = 0 Then
                        txtfields(Index).Text = CStr(0)
                        GoTo EventExitSub
                    End If

                    txtfields(Index).Text = String.Format(txtfields(Index).Text, "##0.00000")

                Case 15 'dept_num
                    valid_dpt = "N"
                    senddpt = txtfields(15).Text
                    retdpt = ""
                    retdptdesc = ""

                    valid_dpt = etsdptnum_chk(senddpt, retdpt, retdptdesc)

                    If valid_dpt = "N" Then
                        MsgBox("Not a valid department number.")
                        Call ets_set_selected()
                        KeyAscii = 0
                        GoTo EventExitSub
                    End If
                    txtfields(15).Text = valid_dpt

                Case 16 't_s_date
                    Dim retdate As String = ETS.Common.Module1.etsdate(txtfields(Index).Text, "N")

                    If retdate = "N" Then
                        txtfields(Index).Text = ""
                        MsgBox(" Bad Date")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtfields(Index).Text = CDate(retdate).ToShortDateString
                    End If

                Case 19 'contract

                    If Len(_txtfields_19.Text) = 0 Then
                        contnumlookup.ShowDialog()
                        _txtfields_19.Text = selected_contract_key
                        ContDesc.Text = selected_desc
                    Else
                        selected_contract_key = _txtfields_19.Text
                        If ETSCommon.CheckNumRecords("select * from cc_cont where contract_key = '" & _txtfields_19.Text & "'") = 0 Then
                            MsgBox("The contract does not exist.")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                        ContDesc.Text = ETSCommon.GetDatum("cc_Cont", "contract_key", selected_contract_key, "Cont_desc")
                    End If

                Case 20  'billable
                    DirectCast(eventSender, TextBox).Text = UCase(DirectCast(eventSender, TextBox).Text)
                    If DirectCast(eventSender, TextBox).Text <> "Y" Then
                        If DirectCast(eventSender, TextBox).Text <> "N" Then
                            MsgBox("Please use Y or N")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If

                Case 28, 29
                    valid_acct = " N "
                    function_type_saved = function_type
                    function_type = "LOOKUP_ONLY"

                    Dim retacct As String = etsacctnum_chk(txtfields(Index).Text)

                    If retacct = "N" Then
                        txtfields(Index).Text = ""
                        MsgBox(" Bad Account Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtfields(Index).Text = retacct
                    End If
                    function_type = function_type_saved

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

    Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

   
End Class