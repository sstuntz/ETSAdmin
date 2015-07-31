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

Public Class frmcc_fund
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "cc_fund"
    Public frmWhereClause As String = " where name_key = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) ' = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        'test for completeness on txtfields only
        'fields 0 1 2 3 6 9 16 17 18 20 40 49


        'For num = 0 To 100
        '    msg = "," & CStr(num) & ","
        '    Response = InStr(",7,", msg)
        '    If Response <> 0 Then
        '        If Len(txtFields(num).Text) = 0 Then
        '            MsgBox("You must fill in all required fields.")
        '            txtFields(num).Focus()
        '            Exit Sub
        '        End If
        '    End If

        'Next

        Dim bnum As String = txtFields(0).Text & selected_contract_key

        If checkYN("cc_fund", "b_num", bnum) = "Y" Then
            MsgBox("This funding source has been added.")
            Exit Sub
        End If

        'build a cc fund record from here and add it.

        Dim FundRowData As New List(Of FundingData)
        FundRowData = CreatFundingRecord(selected_name_key, selected_contract_key)
        selected_bill_type = FundRowData.Item(0).BillType
        selected_b_num = FundRowData.Item(0).BNum
        selected_lookup_num = selected_b_num
        FundRowData.Item(0).EntryDate = Today

        sqlstmnt = "insert into cc_fund " & FundRowData.Item(0).FundingColumnNames & "  values " & FundRowData.Item(0).FundingColumnData
        ETSSQL.ExecuteSQL(sqlstmnt)
        'goto the right bill type

        Select Case selected_bill_type
            Case "100"
                frmbt_100.ShowDialog()
            Case "120"
                frmbt_120.ShowDialog()
            Case "125"
                frmbt_125.ShowDialog()
            Case "140"
                frmbt_140.ShowDialog()
            Case "160"
                frmbt_160.ShowDialog()
            Case "170"
                Me.Close()
                frmbt_170.Show()

            Case Else
                MsgBox("No such bill type as " & selected_bill_type)
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

    Private Sub frmcc_fund_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Normal     'added lhw 06/19/2012
        ctrform(Me)
        'blank all the fields and make the key enabled
        For Each Me.cntrl In Me.Controls
            If TypeOf cntrl Is TextBox Then
                cntrl.Text = ""
            End If
        Next

        txtFields(11).Text = CStr(CDate(Today))
        selected_contract_key = ""
        selected_name_key = ""
        selected_screen_nam = ""
        selected_sort_name = ""


    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()

        ' Dim DefaultContract As String = ETSCommon.GetDatum("medsys", "contractkey", "1", "default_contract_key")
        'txtFields(7).Text = String.Format(DefaultContract, Left, "20")

    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index
                Case 0
                    selected_name_key = ""
                    saved_package_Type = package_Type

                    If Val(txtFields(Index).Text) = 0 Then
                        package_Type = "TY"
                        frmnamechk.ShowDialog()
                        txtFields(Index).Text = selected_name_key
                        package_Type = saved_package_Type
                    End If

                    If chkname(txtFields(Index).Text) = "N" Then
                        ' Text1.Text = ""
                        MsgBox(" Invalid Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    txtFields(Index).Text = selected_name_key
                    txtFields(CShort(Index + 1)).Text = selected_screen_nam

                    selected_Medicaid_Number = ETSCommon.GetDatum("cc_base", "name_key", txtFields(Index).Text, "med_num")
                    If String.IsNullOrEmpty(selected_Medicaid_Number) Then
                        selected_Medicaid_Number = ""
                        'MsgBox("The person has no Medicaid number in cc_base.")
                        'Response = MsgBox("Click Yes to continue.", vbYesNo)
                        'If Response = vbNo Then
                        '    Call ets_set_selected()
                        '    GoTo EventExitSub
                        'End If
                    End If
                    txtFields(3).Text = selected_Medicaid_Number

                Case 7
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    If Len(txtFields(Index).Text) = 0 Then
                        contnumlookup.ShowDialog()
                        txtFields(Index).Text = selected_cont_id_num
                        txtFields(CShort(Index + 1)).Text = selected_mmars_num
                        txtFields(CShort(Index + 2)).Text = selected_amend_num
                        txtFields(CShort(Index + 3)).Text = selected_dpt_desc
                        txtFields(10).Text = selected_desc
                    Else
                        If ETSCommon.CheckYN("cc_Cont", "contract_key", selected_contract_key, "N") = "N" Then
                            MsgBox("The contract does not exist.")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If

                Case 9

                    Dim TestContractKey As String = txtFields(CShort(Index - 2)).Text & txtFields(CShort(Index - 1)).Text & txtFields(Index).Text
                    If ETSCommon.CheckYN("cc_Cont", "contract_key", TestContractKey, "N") = "N" Then
                        MsgBox("The contract does not exist.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    txtFields(10).Text = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "cont_desc")

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