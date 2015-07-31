Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports System.String

Public Class frmbt_170
    Inherits System.Windows.Forms.Form
    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "cc_fund"
    Public frmWhereClause As String = " where b_num = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) '= ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        Call chk_ccbase(txtfields(0))

        'For num = 0 To 100
        '    msg = "," & CStr(num) & ","
        '    Response = InStr(",2,6,7,10,11,12,21,23,", msg)
        '    If Response <> 0 Then
        '        If Len(txtfields(num).Text) = 0 Then
        '            MsgBox("You must fill in all required fields.")
        '            txtfields(num).Focus()
        '            Exit Sub
        '        End If
        '    End If
        'Next

        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                If Not Len(Me.cntrl.Tag) = 0 Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    frmdata.ActualData = Me.cntrl.Text
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
        fundnumlookup.Show()
    End Sub

    Private Sub frmbt_170_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Normal     'added lhw 06/19/2012
        ctrform(Me)

        sqlstmnt = "select * from cc_fund where b_num =  '" & selected_b_num & "'"

        Dim Funding As New List(Of FundingData)
        Funding = ETSSQL.GetFundData(sqlstmnt)

        If Funding.Count = 0 Then
            entry_type = "ADD"
        Else
            entry_type = "EDIT"
        End If

        If entry_type = "ADD" Then
            'blank all the fields and make the key enabled
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                End If
            Next

        Else
            Dim rs As New Collection
            RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    If Not Len(Me.cntrl.Tag) = 0 Then
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
                End If
            Next

        End If

        Call ContractSeparate(selected_contract_key)
        If Not IsNullOrEmpty(txtfields(2).Text) Then
            txtfields(2).Text = CDate(txtfields(2).Text).ToShortDateString
        End If
        If Not IsNullOrEmpty(txtfields(21).Text) Then
            txtfields(21).Text = CDate(txtfields(21).Text).ToShortDateString
        End If

        txtfields(0).Text = selected_name_key
        txtfields(1).Text = selected_sort_name
        txtfields(3).Text = selected_cont_id_num
        txtfields(4).Text = selected_mmars_num
        txtfields(5).Text = selected_amend_num
        txtfields(13).Text = CStr(CDate(Today))

        txtfields(32).Text = CStr(Val(txtfields(30).Text) + Val(txtfields(31).Text))
        txtfields(30).Text = String.Format(txtfields(30).Text, "C")
        txtfields(31).Text = String.Format(txtfields(31).Text, "C")
        txtfields(32).Text = String.Format(txtfields(32).Text, "C")

        'look up prog rate and desc
        If Val(txtfields(15).Text) <> 0 Then
            txtfields(17).Text = CStr(ETSCommon.GetDatum("program", "prog_num", txtfields(15).Text, "prog_rate"))
            Dim pct As String = CStr(Val(txtfields(6).Text) / Val(txtfields(17).Text))
            Text8.Text = String.Format(pct, "C")
            txtfields(16).Text = ETSCommon.GetDatum("program", "prog_num", txtfields(15).Text, "prog_desc")
        End If

        'look up cont desc. pv form and rpt type
        Text3.Text = ETSCommon.GetDatum("cc_Cont", "Contract_key", selected_contract_key, "cont_Desc")
        txtfields(9).Text = ETSCommon.GetDatum("cc_Cont", "Contract_key", selected_contract_key, "rpt_type")

        function_type = "DATA_ENTRY"

        _txtfields_2.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        _txtfields_2.AutoCompleteSource = AutoCompleteSource.CustomSource
        _txtfields_2.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        _txtfields_7.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        _txtfields_7.AutoCompleteSource = AutoCompleteSource.CustomSource
        _txtfields_7.AutoCompleteMode = AutoCompleteMode.SuggestAppend


    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
        If Index = 2 Then
            txtfields(0).Text = selected_name_key
            txtfields(1).Text = selected_sort_name
            txtfields(3).Text = selected_cont_id_num
            txtfields(4).Text = selected_mmars_num
            txtfields(5).Text = selected_amend_num
            txtfields(13).Text = CStr(CDate(Today))
        End If

    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            function_type = "DATA_ENTRY"

            Select Case Index

                Case 9, 11

                    txtfields(Index).Text = UCase(txtfields(Index).Text)

                Case 10
                    txtfields(Index).Text = UCase(txtfields(Index).Text)
                    ' if blank do lookup

                    'Valid_YN = "N"

                    'If Len(Trim(CChar(txtfields(Index).Text))) = 0 Then
                    '    '  medfeelookup.Show 1
                    '    txtfields(Index).Text = selected_lookup_num
                    'End If

                    'Call chk_Proc_code(txtfields(Index), Today)

                    'If Valid_YN = "N" Then
                    '    MsgBox("Invalid Procedure Code.")
                    '    Call ets_set_selected()
                    '    GoTo EventExitSub
                    'End If

                    txtfields(1).Text = selected_proc_desc
                    txtfields(6).Text = CStr(selected_proc_fee)
                    txtfields(11).Text = CStr(selected_proc_max)


                Case 12, 21

                    Dim retdate As String = ETS.Common.Module1.etsdate(txtfields(Index).Text, "N")

                    If retdate = "N" Then
                        txtfields(Index).Text = ""
                        MsgBox(" Bad Date")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtfields(Index).Text = retdate
                    End If

                Case 22, 14, 15, 16, 17, 18, 19, 20
                    txtfields(Index).Text = UCase(txtfields(Index).Text)

                    If txtfields(Index).Text <> "N" Then
                        If txtfields(Index).Text <> "Y" Then
                            MsgBox("You must enter a Y or a N")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If


                Case 6, 30, 31
                    If Len(txtfields(Index).Text) = 0 Then
                        txtfields(Index).Text = CStr(0)
                    End If

                    If ets_format(txtfields(Index).Text, "", 3) = "N" Then
                        MsgBox("Invalid Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtfields(Index).Text = ets_format(txtfields(Index).Text, "", 3)
                    End If

                    If Val(txtfields(25).Text) <> 0 Then
                        If Index = 6 Then
                            Dim pct As String = CStr(Val(txtfields(6).Text) / Val(txtfields(25).Text))
                            Text8.Text = String.Format(pct, "C")
                        End If
                    End If
                    txtfields(32).Text = CStr(Val(txtfields(30).Text) + Val(txtfields(31).Text))
                    txtfields(30).Text = String.Format(txtfields(30).Text, "C")
                    txtfields(31).Text = String.Format(txtfields(31).Text, "C")
                    txtfields(32).Text = String.Format(txtfields(32).Text, "C")

                Case 23
                    valid_dpt = "N"
                    function_type = "DATA_ENTRY"
                    current_fiscal = CInt(CStr(Year(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 6, Today))))
                    'Call etsprognum_chk(txtfields(Index), sendyear, retdpt, retdptdesc, valid_dpt)
                    'If valid_dpt = "Y" Then
                    '    txtfields(Index).Text = retdpt
                    '    txtfields(Index + 1).Text = retdptdesc
                    '    txtfields(Index + 2).Text = CStr(selected_prog_rate)
                    'Else
                    '    MsgBox("Invalid Program number")
                    '    Call ets_set_selected()
                    '    GoTo EventExitSub
                    'End If

                Case 2, 7
                    Dim retacct As String = etsacctnum_chk(txtfields(Index).Text)

                    If retacct = "N" Then
                        txtfields(Index).Text = ""
                        MsgBox(" Bad Account Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtfields(Index).Text = retacct
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

    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub
End Class