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

Public Class frmmmpv1
    Inherits System.Windows.Forms.Form

    Public TagColumnName As String
    Public frmTableName As String = "mmpv"
    Public frmWhereClause As String = ""
    Public RowData As List(Of ETSData) ' = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String
    Public fill_flag As Integer
    Public PVRowData As List(Of PVData)

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        If pv_Type = "CREATE" Then
            bill_unpv.ShowDialog()
        End If

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmmmpv1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ctrform(Me)
        fill_flag = 0
        Select Case pv_Type
            Case "TEMP"
                frmTableName = "mmpv"
                frmWhereClause = " where pv_form =  '" & selected_lookup_num & "'"
                Me.Text = "This is the PV form template edit form - page 1"
            Case "ACT"
                frmTableName = "mmpv_tmp"
                frmWhereClause = " where pv_form =  '" & selected_lookup_num & "' and contract_key = '" & selected_contract_key & "'"
                Me.Text = "This is an actual PV form - page 1"
                'either get data from temp or start a new one.
                If ETSCommon.CheckNumRecords("select * from mmpv_tmp where pv_form =  '" & selected_lookup_num & "' and contract_key = '" & selected_contract_key & "'") = 0 Then
                    PVRowData = ETSSQL.GetPVData("select * from mmpv where pv_form = '" & selected_lookup_num & "'")
                    entry_type = "ADD"
                Else
                    RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
                    entry_type = "EDIT"
                End If

            Case "CREATE"
                frmTableName = "mmpv_tmp"
                frmWhereClause = " where pv_form =  '" & selected_lookup_num & "'" ' and contract_key = '" & selected_contract_key & "'"
                Me.Text = "This will create a billable PV form"
            Case Else
                frmTableName = "mmpv"
                frmWhereClause = " where pv_form =  '" & selected_lookup_num & "'"
                Me.Text = "This is the PV form template edit form - page 1"
        End Select

        If entry_type = "ADD" Then
            Me.Text = "ADD PV Form"
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                    txtFields(0).Enabled = True
                End If
            Next
            PVRowData = ETSSQL.GetBlankPVData

        Else
            entry_type = "EDIT"
            save_goto_pg2.Visible = True
            Dim rs As New Collection
            RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    If Len(frmdata.ActualData) <> 0 Then
                        If frmdata.DataType = "datetime" Or frmdata.DataType = "DATE" Then
                            cntrl.Text = CDate(frmdata.ActualData).ToShortDateString
                        Else
                            cntrl.Text = frmdata.ActualData.ToString
                        End If
                    End If
                End If
            Next
            txtFields(0).Enabled = False
            txtFields(1).Enabled = False

            txtFields(0).Text = selected_contract_key
        End If

        function_type = "DATA_ENTRY"
        Me.BringToFront()

    End Sub

    Private Sub save_goto_pg2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles save_goto_pg2.Click

        SaveData()
        Me.Dispose()
        frmmmpv2.ShowDialog()

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
        Me.ActiveControl.BackColor = Color.Aqua '(RGB(0, 255, 255))
        Me.BringToFront()

    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))

        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index
                Case 0

                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    If Len(txtFields(Index).Text) = 0 Then
                        contnumlookup.ShowDialog()
                        txtFields(Index).Text = selected_cont_id_num
                    Else
                        If ValidateDatumYN("cc_cont", "Contract_key", txtFields(Index).Text) = "N" Then
                            MsgBox("Not a valid Contract.")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If

                        txtFields(Index).Text = cont_key_display(selected_contract_key)

                        'get the pv form name and if it does not exist give the error message

                        If Len(ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "pv_form") & "") = 0 Then
                            MsgBox("You must set up the Pv form name in contracts first.")
                            Me.Close()
                            Me.Dispose()
                            GoTo EventExitSub
                        Else
                            'look up if template already exists
                            ' if not and an add then ok to fill

                            If ETSCommon.CheckYN("mmpv", "pv_form", txtFields(Index).Text, "N") = "Y" Then
                                MsgBox("The PV Template is already set up.")
                                Me.Close()
                                GoTo EventExitSub
                            Else
                                If entry_type = "ADD" Then
                                    Dim ContractRowData As New List(Of ContractData)
                                    ContractRowData = ETSSQL.GetContractData("select * from cc_cont  where contract_key = '" & selected_contract_key & "'")
                                    Dim AgencyRowData As New AgencyData
                                    AgencyRowData = ETSSQL.GetAgencyData("select * from agency where agency = 1")

                                    PVRowData.Item(0).ContractKey = selected_contract_key
                                    PVRowData.Item(0).PvForm = ContractRowData.Item(0).PvForm
                                    selected_lookup_num = PVRowData.Item(0).PvForm
                                    PVRowData.Item(0).BudFy9 = ContractRowData.Item(0).FiscalYr
                                    selected_cont_id_num = ContractRowData.Item(0).ContIdNum
                                    PVRowData.Item(0).Dept1 = Mid(selected_cont_id_num, 4, 3)
                                    PVRowData.Item(0).Dept19 = Mid(selected_cont_id_num, 4, 3)
                                    PVRowData.Item(0).Dept23 = Mid(selected_cont_id_num, 4, 3)
                                    PVRowData.Item(0).Dept36 = Mid(selected_cont_id_num, 4, 3)
                                    PVRowData.Item(0).ROrg2 = Mid(selected_cont_id_num, 8, 4)
                                    PVRowData.Item(0).ROrg20 = Mid(selected_cont_id_num, 8, 4)
                                    PVRowData.Item(0).Org26 = Mid(selected_cont_id_num, 8, 4)
                                    PVRowData.Item(0).Num3 = Mid(selected_cont_id_num, 13, 4) & Mid(selected_cont_id_num, 18, 3)
                                    PVRowData.Item(0).Number21 = Mid(selected_cont_id_num, 13, 4) & Mid(selected_cont_id_num, 18, 3)
                                    PVRowData.Item(0).Dept12 = Mid(selected_cont_id_num, 4, 3)
                                    PVRowData.Item(0).VendCode14 = ContractRowData.Item(0).PnumSdr
                                    PVRowData.Item(0).R01 = selected_cont_id_num
                                    PVRowData.Item(0).Ln1 = ContractRowData.Item(0).MmarsNum
                                    selected_mmars_num = PVRowData.Item(0).Ln1
                                    PVRowData.Item(0).Ln17 = ContractRowData.Item(0).MmarsNum
                                    PVRowData.Item(0).Trans18 = VB.Left(selected_cont_id_num, 2)
                                    PVRowData.Item(0).Line22 = selected_mmars_num
                                    PVRowData.Item(0).Desc38 = ContractRowData.Item(0).ContDesc
                                    PVRowData.Item(0).CrAcctNu = ContractRowData.Item(0).CrAcctNu
                                    PVRowData.Item(0).DrAcctNu = ContractRowData.Item(0).DrAcctNu
                                    ' PVRowData.Item(0).Prog30 = ContractRowData.Item(0).prograte
                                    PVRowData.Item(0).Vname16a = AgencyRowData.AgencyName
                                    PVRowData.Item(0).Vname16b = AgencyRowData.Address1
                                    PVRowData.Item(0).Vname16c = AgencyRowData.Address2
                                    PVRowData.Item(0).Vname16d = AgencyRowData.City & ", " & AgencyRowData.State & "  " & AgencyRowData.Zip

                                    txtFields(CShort(Index + 1)).Text = PVRowData.Item(0).PvForm
                                    txtFields(CShort(Index + 1)).Enabled = False
                                    'fill all fields

                                    txtFields(10).Text = PVRowData.Item(0).BudFy9
                                    txtFields(2).Text = Mid(selected_cont_id_num, 4, 3)
                                    txtFields(3).Text = Mid(selected_cont_id_num, 8, 4)
                                    txtFields(4).Text = Mid(selected_cont_id_num, 13, 4) & Mid(selected_cont_id_num, 18, 3)
                                    txtFields(13).Text = Mid(selected_cont_id_num, 4, 3)
                                    txtFields(15).Text = PVRowData.Item(0).VendCode14
                                    txtFields(17).Text = PVRowData.Item(0).Vname16a
                                    txtFields(18).Text = PVRowData.Item(0).Vname16b
                                    txtFields(19).Text = PVRowData.Item(0).Vname16c
                                    txtFields(20).Text = PVRowData.Item(0).Vname16d
                                End If
                            End If
                        End If
                    End If


                Case 6, 8

                    'allow entry of zero on a date field
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

                Case 10

                    If Not IsNumeric(txtFields(Index).Text) Then
                        MsgBox("Please enter a number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    If Len(txtFields(Index).Text) <> 4 Then
                        MsgBox("Please enter a 4 digit year.")
                        Call ets_set_selected()
                        GoTo EventExitSub
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
                TagColumnName = Me.cntrl.Tag.ToString
                Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                frmdata.ActualData = Me.cntrl.Text
            End If
        Next

        Select Case entry_type.ToString
            Case "ADD"
                'add sort name and agency
                RowData.Item(21).ActualData = selected_sort_name
                RowData.Item(22).ActualData = CStr((AgencyNum))
                Call ETSSQL.CheckDataforSQL(RowData)
                Call ETSSQL.InsertData(frmTableName, RowData)
            Case "EDIT"
                Call ETSSQL.CheckDataforSQL(RowData)
                Call ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)
        End Select

    End Sub
End Class