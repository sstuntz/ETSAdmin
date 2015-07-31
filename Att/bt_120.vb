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

Friend Class frmbt_120
    Inherits System.Windows.Forms.Form
    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "cc_fund"
    Public frmWhereClause As String = " where b_num = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) ' = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        'test for completeness on txtfields only
        'fields 0 1 2 3 6 9 16 17 18 20 40 49


        'For num = 0 To 100
        '    msg = "," & CStr(num) & ","
        '    Response = InStr(",0,2,3,4,", msg)
        '    If Response <> 0 Then
        '        If Len(txtFields(num).Text) = 0 Then
        '            MsgBox("You must fill in all required fields.")
        '            txtFields(num).Focus()
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
    End Sub

    Private Sub frmbt_120_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
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

            txtfields(6).Text = ETSCommon.GetDatum("cc_Cont", "Contract_key", selected_contract_key, "unit_rate")
            txtfields(26).Text = ETSCommon.GetDatum("cc_Cont", "Contract_key", selected_contract_key, "cr_acct_nu")
            txtfields(27).Text = ETSCommon.GetDatum("cc_Cont", "Contract_key", selected_contract_key, "dr_acct_nu")
            txtfields(21).Text = ETSCommon.GetDatum("cc_Cont", "Contract_key", selected_contract_key, "cont_End_d")

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
        If Val(txtfields(23).Text) <> 0 Then
            txtfields(25).Text = ETSSQL.GetProgRate(selected_contract_key, txtfields(23).Text).ToString
            Dim pct As String = CStr(Val(txtfields(6).Text) / Val(txtfields(25).Text))
            Text8.Text = String.Format(pct, "C")
            txtfields(24).Text = ETSCommon.GetDatum("program", "prog_num", txtfields(23).Text, "prog_desc")
        End If


        'look up cont desc. pv form and rpt type
        Text2.Text = ETSCommon.GetDatum("cc_Cont", "Contract_key", selected_contract_key, "pv_form")
        Text3.Text = ETSCommon.GetDatum("cc_Cont", "Contract_key", selected_contract_key, "cont_Desc")
        Text4.Text = ETSCommon.GetDatum("cc_Cont", "Contract_key", selected_contract_key, "rpt_type")

        function_type = "DATA_ENTRY"

        If Not IsNullOrEmpty(txtfields(21).Text) Then
            txtfields(21).Text = CDate(txtfields(21).Text).ToShortDateString
        End If

        If Not IsNullOrEmpty(txtfields(12).Text) Then
            txtfields(12).Text = CDate(txtfields(12).Text).ToShortDateString
        End If

        _txtfields_26.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        _txtfields_26.AutoCompleteSource = AutoCompleteSource.CustomSource
        _txtfields_26.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        _txtfields_27.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        _txtfields_27.AutoCompleteSource = AutoCompleteSource.CustomSource
        _txtfields_27.AutoCompleteMode = AutoCompleteMode.SuggestAppend



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

            Select Case Index

                Case 9, 10

                    txtfields(Index).Text = UCase(txtfields(Index).Text)

                Case 12, 21
                    Dim retdate As String = ETS.Common.Module1.etsdate(txtfields(Index).Text, "N")

                    If retdate = "N" Then
                        txtfields(Index).Text = ""
                        MsgBox(" Bad Date")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtfields(Index).Text = CDate(retdate).ToShortDateString
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


                Case 6, 7, 30, 31
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


                Case 8
                    ' no need for this test for JRI
                    'sqlstmnt = "select * from cc_fund where contract_key = '" & selected_contract_key & "'  and slot_num =  '" & txtfields(Index).Text & "'"

                    'If CDbl(ETSCommon.CheckNumRecords(sqlstmnt)) <> 0 Then
                    '    MsgBox("This is a duplicate slot number for this contract.")
                    '    Call ets_set_selected()
                    '    GoTo EventExitSub
                    'End If

                Case 23

                    If Val(txtfields(Index).Text) = 0 Then
                        prognumlookup.ShowDialog()
                        txtfields(Index).Text = selected_prog_num
                        txtfields(CShort(Index + 1)).Text = selected_prog_desc
                        txtfields(CShort(Index + 2)).Text = CStr(selected_prog_rate)
                    End If

                    sqlstmnt = "Select * from program where prog_num = '" & txtfields(Index).Text & "' and fiscal_yr = " & Year(CDate(txtfields(13).Text))

                    If CDbl(ETSCommon.CheckNumRecords(sqlstmnt)) = 0 Then
                        MsgBox("Invalid Program number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtfields(CShort(Index + 1)).Text = ETSCommon.GetDatum("program", "prog_num", txtfields(Index).Text, "prog_desc")
                        txtfields(CShort(Index + 2)).Text = CStr(ETSCommon.GetDatum("program", "prog_num", txtfields(Index).Text, "prog_rate"))
                    End If

                Case 26, 27
                    Call etsacctnum_chk(txtfields(Index).Text)

                    If valid_acct = "N" Then
                        MsgBox("Not a valid account number.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    txtfields(Index).Text = retacct

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