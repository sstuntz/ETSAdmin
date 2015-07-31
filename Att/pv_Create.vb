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

Public Class pv_add
    Inherits System.Windows.Forms.Form
    Public TagColumnName As String
    Public frmTableName As String = "mmpv"
    Public frmWhereClause As String = ""        'this form is always add
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String
    Public PVRowData As List(Of PVData)

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        'test for completeness on txtfields only
        'fields 0 1 2 3 6 9 16 17 18 20 40 49


        'For num = 0 To 100
        '    msg = "," & CStr(num) & ","
        '    Response = InStr(",7,8,9,", msg)
        '    'If Response <> 0 Then
        '    '    If Len(txtFields(num).Text) = 0 Then
        '    '        MsgBox("You must fill in all required fields.")
        '    '        txtFields(num).Focus()
        '    '        Exit Sub
        '    '    End If
        '    'End If

        'Next

        'cycle thru contract and put values where they belong  and then etssys

        Dim ContractRowData As New List(Of ContractData)
        ContractRowData = ETSSQL.GetContractData("select * from cc_cont  where contract_key = '" & selected_contract_key & "'")
        Dim AgencyRowData As New AgencyData
        AgencyRowData = ETSSQL.GetAgencyData("select * from agency where agency = 1")

        PVRowData.Item(0).ContractKey = selected_contract_key
        ' PVRowData.Item(0).PvForm = ContractRowData.Item(0).PvForm
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

        Select Case entry_type.ToString
            Case "ADD"
                Call ETSSQL.InsertData(frmTableName, RowData)
            Case "EDIT"
                Call ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)
        End Select

        entry_type = "EDIT"
        frmmmpv1.ShowDialog()

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

    Private Sub pv_add_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ctrform(Me)

        If entry_type = "ADD" Then
            Me.Text = "ADD PV Form"
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                    txtFields(8).Enabled = True
                    txtFields(9).Enabled = True
                End If
            Next
            PVRowData = ETSSQL.GetBlankPVData
            PVRowData.Item(0).EntryDate = CDate(Today)

        Else
            Me.Text = "Edit PV Form"
            entry_type = "EDIT"
            cmdUpdate.Visible = True
            frmWhereClause = " where pv_num =  '" & selected_lookup_num & "'"
            Dim rs As New Collection
            RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    cntrl.Text = frmdata.ActualData.ToString
                End If
            Next
            txtFields(0).Enabled = False

        End If

        function_type = "DATA_ENTRY"


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

                Case 7  '- contract id lookup
                    txtFields(Index).Text = UCase(txtFields(Index).Text)

                    If Len(txtFields(Index).Text) = 0 Then
                        contnumlookup.ShowDialog()
                        txtFields(Index).Text = selected_cont_id_num
                        txtFields(CShort(Index + 1)).Text = selected_mmars_num
                        txtFields(CShort(Index + 2)).Text = selected_amend_num
                        txtFields(CShort(Index + 3)).Text = selected_dpt_desc
                    Else
                        'check if valid contrct -id -num  -- without dasjes and no mmars or amend
                        If checkYN("cc_Cont", "cont_id_num", txtFields(Index).Text) = "N" Then
                            MsgBox("Not a valid Contract")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If

                    'in no pv form in contract need to set it up
                    '    selected_contract_key = txtFields(7).Text & "-" & txtFields(8).Text & "-" & txtFields(9).Text
                    '  selected_contract_key = txtFields(7).Text & txtFields(8).Text & txtFields(9).Text

                    Dim PVForm As String = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "pv_Form")

                    If PVForm.Length = 0 Then
                        MsgBox("You must set up the Pv form name in contracts first.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    If checkYN("mmpv", "pv_form", PVForm) = "Y" Then
                        MsgBox("The PV Template is already set up.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        cmdUpdate.Enabled = True
                    End If

                Case 9
                    'create full contract key and check it
                    sqlstmnt = txtFields(7).Text & "-" & txtFields(8).Text & "-" & txtFields(9).Text

                    If checkYN("cc_Cont", "contract_key", cont_key_remove_Dashes(sqlstmnt)) = "Y" Then
                        MsgBox("Contract Exists - can not add")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    'get contract desc
                    txtFields(10).Text = ETSCommon.GetDatum("cc_Cont", "contract_key", cont_key_remove_Dashes(sqlstmnt), " cont_Desc")
                    selected_contract_key = cont_key_remove_Dashes(sqlstmnt)

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