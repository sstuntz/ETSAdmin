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

Public Class frmmmpv2
    Inherits System.Windows.Forms.Form

    Public TagColumnName As String
    Public frmTableName As String '= "Rpt_type"
    Public frmWhereClause As String '= " where rpt_num = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) '= ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String
    Public fill_flag As Integer
    Public doc_qty As Double
    Public line_qty As Double
    Public line_Tot As Double
    Public PVRowData As List(Of PVData)


    Public Sub calc_doc_tot()

        tot_amt = 0
        doc_qty = 0
        line_Tot = 0
        line_qty = 0
        For num As Integer = 1 To 10
            If txtFields(CShort(102 + (num - 1) * 10 + 1)).Text <> "Net Billed" Then
                If txtFields(CShort(100 + (num - 1) * 10 + 1)).Text.Length <> 0 Then
                    tot_amt = tot_amt + CDec(IIf(Decimal.TryParse(txtFields(CShort(100 + (num - 1) * 10 + 5)).Text, Nothing), txtFields(CShort(100 + (num - 1) * 10 + 5)).Text, "0"))
                    doc_qty = doc_qty + CDec(IIf(Decimal.TryParse(txtFields(CShort(100 + (num - 1) * 10 + 2)).Text, Nothing), txtFields(CShort(100 + (num - 1) * 10 + 2)).Text, "0"))
                End If

                If txtFields(CShort(100 + (num - 1) * 10 + 1)).Text = txtFields(101).Text Then
                    line_Tot = line_Tot + Val(txtFields(CShort(100 + (num - 1) * 10 + 5)).Text)
                    line_qty = line_qty + Val(txtFields(CShort(100 + (num - 1) * 10 + 2)).Text)

                End If
            End If
        Next

        txtFields(65).Text = String.Format("{0:F2}", tot_amt)
        txtFields(66).Text = String.Format("{0:F2}", doc_qty)
        txtFields(12).Text = String.Format("{0:F2}", tot_amt)
    End Sub

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        SaveData()

        Select Case pv_Type
            Case "CREATE", "ACT"

                prtDestination = 0    'to screen
                prtreportfilename = att_report_path & "pv6.rpt"
                CrystalForm.ShowDialog()

                Response = MsgBox("Do you wish to save this as a PDF?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, MsgBoxStyle))
                If Response = MsgBoxResult.Yes Then
                    prtDestination = 2     'to pdf
                    prtreportfilename = att_report_path & "pv6.rpt"
                    CrystalForm.ShowDialog()
                    KeyAscii = 0
                End If

                If pv_Type = "ACT" Then
                    Me.Dispose()
                    Exit Sub
                End If

                Response = MsgBox("OK to update records?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, MsgBoxStyle))

                If Response = MsgBoxResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    sqlstmnt = "select * from cc_cont where contract_key =  '" & selected_contract_key & "'"

                    Dim NextInvoice As New CompanyInvoiceData
                    NextInvoice = ETSSQL.GetBlankCompanyInvoiceData
                    NextInvoice.InvNum = att_mod.GetNextCompanyInvoiceNum
                    NextInvoice.Invoice = PVRowData.Item(0).VinvNum37  'Data1.Recordset.Fields("vinv_num-37")
                    NextInvoice.LineNum = 1
                    NextInvoice.TransCode = "INV"
                    NextInvoice.NameKey = ETSCommon.GetDatum("cc_cont", "Contract_key", selected_contract_key, "name_key")

                    'look up the proper name
                    saved_package_Type = package_Type
                    package_Type = "TY"
                    Call chkname(NextInvoice.NameKey)
                    package_Type = saved_package_Type
                    NextInvoice.ScreenNam = selected_screen_nam
                    NextInvoice.SortName = selected_sort_name
                    NextInvoice.InvDesc = PVRowData.Item(0).Desc38
                    NextInvoice.ContractKey = PVRowData.Item(0).ContractKey
                    NextInvoice.FromDate = PVRowData.Item(0).FrmDate40 '? tmpset.Fields("serv_beg").Value = txtFields(68).Text
                    NextInvoice.ToDate = PVRowData.Item(0).ToDate41  '    tmpset.Fields("serv_end").Value = txtFields(67).Text
                    NextInvoice.EntryDate = Today
                    NextInvoice.InvoiceDate = PVRowData.Item(0).Pvdate7
                    NextInvoice.EncumDate = CDate(txtFields(67).Text)
                    NextInvoice.BalDue = CDec(tot_amt)
                    NextInvoice.AllocAmt = CDec(tot_amt)
                    NextInvoice.InvAmt = 0
                    NextInvoice.CrAcctNu = PVRowData.Item(0).CrAcctNu
                    NextInvoice.DrAcctNu = PVRowData.Item(0).DrAcctNu
                    NextInvoice.InvNum = GetNextCompanyInvoiceNum()
                    'put the invoice in file
                    sqlstmnt = "insert into invoice " & NextInvoice.CompanyInvoiceColumnNames & "  values " & NextInvoice.CompanyInvoiceColumnData
                    ETSSQL.ExecuteSQL(sqlstmnt)

                    'now to update the contract if this is an unsupported pv
                    sqlstmnt = "update cc_Cont set last_invnum = '" & NextInvoice.InvNum
                    sqlstmnt = sqlstmnt & "' , last_billdate = '" & NextInvoice.InvoiceDate
                    sqlstmnt = sqlstmnt & "' , month_units = '" & doc_qty.ToString
                    sqlstmnt = sqlstmnt & "' , month_dol = '" & tot_amt.ToString
                    sqlstmnt = sqlstmnt & "' where contract_key = '" & selected_contract_key & "'"
                    ETSSQL.ExecuteSQL(sqlstmnt)
                    Dim OldYtdUnits As Double = CDbl(ETSCommon.GetDatum("cc_cont", "Contract_key", selected_contract_key, "ytd_units"))
                    Dim OldYtdDol As Decimal = CDec(ETSCommon.GetDatum("cc_cont", "Contract_key", selected_contract_key, "ytd_dol"))


                    sqlstmnt = "update cc_Cont set ytd_units = " & (OldYtdUnits + doc_qty)
                    sqlstmnt = sqlstmnt & " , ytd_dol = '" & (OldYtdDol + tot_amt)
                    sqlstmnt = sqlstmnt & "' where contract_key = '" & selected_contract_key & "'"
                    ETSSQL.ExecuteSQL(sqlstmnt)

                    'update the bill control file

                    sqlstmnt = "select * from bill_cntrl where contract_key = '" & selected_contract_key
                    sqlstmnt = sqlstmnt & "' and serv_beg >= '" & NextInvoice.FromDate
                    sqlstmnt = sqlstmnt & "' and serv_end <= '" & NextInvoice.ToDate & "'"



                    If ETSCommon.CheckNumRecords(sqlstmnt) = 0 Then
                        Dim BillCtrl As New List(Of ETSData)
                        Dim num As Integer = 0
                        For Each bill In BillCtrl
                            If num = 0 Then BillCtrl.Item(0).ActualData = selected_contract_key
                            If num = 1 Then BillCtrl.Item(0).ActualData = CStr(NextInvoice.FromDate)
                            If num = 2 Then BillCtrl.Item(0).ActualData = CStr(NextInvoice.ToDate)
                            If num = 3 Then BillCtrl.Item(0).ActualData = CStr(NextInvoice.EncumDate)
                            If num = 4 Then BillCtrl.Item(0).ActualData = NextInvoice.Invoice
                            If num = 5 Then BillCtrl.Item(0).ActualData = CStr(NextInvoice.AllocAmt)
                            If num = 6 Then BillCtrl.Item(0).ActualData = "Not an active contract"
                            If num = 7 Then BillCtrl.Item(0).ActualData = CStr(NextInvoice.InvNum)
                            num = num + 1
                        Next


                        '    tmpset.Fields("bill_Date").Value = invoice.Recordset.Fields("invoice_Date")
                        '    tmpset.Fields("invoice").Value = invoice.Recordset.Fields("invoice")
                        '    tmpset.Fields("amt_billed").Value = tot_amt 'invoice.Recordset.Fields("bal_Due")
                        '    tmpset.Fields("inv_num").Value = invoice.Recordset.Fields("inv_num")
                        '    tmpset.Fields("comment").Value = "Not an active contract"
                        '    tmpset.Fields("serv_beg").Value = txtFields(68).Text
                        '    tmpset.Fields("serv_end").Value = txtFields(67).Text

                    Else
                        Dim BillCtrl As List(Of BillControlData)
                        BillCtrl = ETSSQL.GetBillControlData(sqlstmnt)


                        BillCtrl.Item(0).BillDate = NextInvoice.EncumDate
                        BillCtrl.Item(0).Invoice = NextInvoice.Invoice
                        BillCtrl.Item(0).AmtBilled = NextInvoice.AllocAmt
                        BillCtrl.Item(0).Comment = "Not an active contract"
                        BillCtrl.Item(0).InvNum = NextInvoice.InvNum
                        sqlstmnt = "update  bill_cntrl set  bill_date = '" & BillCtrl.Item(0).BillDate & "', invoice = '" & BillCtrl.Item(0).Invoice
                        sqlstmnt = sqlstmnt & "' , amt_billed = '" & BillCtrl.Item(0).AmtBilled & "' , inv_num = '" & BillCtrl.Item(0).InvNum
                        sqlstmnt = sqlstmnt & "' , comment = '  ' where contract_key = '" & selected_contract_key
                        sqlstmnt = sqlstmnt & "' and serv_beg >= '" & NextInvoice.FromDate
                        sqlstmnt = sqlstmnt & "' and serv_end <= '" & NextInvoice.ToDate & "'"

                        ETSSQL.ExecuteSQL(sqlstmnt)

                    End If

                    ''now move mmpv_tmp to mmpv_hist

                    sqlstmnt = "insert into mmpv_hist select * from mmpv_tmp"
                    ETSSQL.ExecuteSQL(sqlstmnt)

                    ''now delete the tmp records
                    sqlstmnt = "delete from mmpv_tmp"
                    ETSSQL.ExecuteSQL(sqlstmnt)

                    selected_end_date = NextInvoice.ToDate
                    prtDestination = 1 'do move and merge
                    MergeForm.ShowDialog()
                    Me.Cursor = Cursors.Default

                    '     Me.Close()
                    '    bill_unpv.Show() 'pvformlookup.Show   'on unsupporte pvs go back to the lookup refreshed
                    '   Exit Sub
                End If

            Case Else
                Call calc_doc_tot()

        End Select

        Me.Close()
        Me.Dispose()
        bill_unpv.Show()

    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub frmmmpv2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ctrform(Me)
        fill_flag = 0

        Select Case pv_Type
            Case "TEMP"
                frmTableName = "mmpv"
                frmWhereClause = " where pv_form =  '" & selected_lookup_num & "'"
                Me.Text = "This is the PV form template edit form - page 2"
            Case "ACT"
                frmTableName = "mmpv_tmp"
                frmWhereClause = " where pv_form =  '" & selected_lookup_num & "' and contract_key = '" & selected_contract_key & "'"
                Me.Text = "This is an actual PV form - page 2"
            Case "CREATE"
                frmTableName = "mmpv_tmp"
                frmWhereClause = " where pv_form =  '" & selected_lookup_num & "' and contract_key = '" & selected_contract_key & "'"
                Me.Text = "This will create a billable PV form"
            Case Else
                frmTableName = "mmpv"
                frmWhereClause = " where pv_form =  '" & selected_lookup_num & "'"
                Me.Text = "This is the PV form template edit form - page 2"
        End Select

        Select Case entry_type
            Case "ADD"

                PVRowData = ETSSQL.GetBlankPVData
            Case "EDIT"
                Me.Text = "Edit PV Form"
                entry_type = "EDIT"
                cmdUpdate.Visible = True
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

                PVRowData = ETSSQL.GetPVData(sqlstmnt)

        End Select

        function_type = "DATA_ENTRY"

        Call calc_doc_tot()

        Me.BringToFront()

        _txtFields_97.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        _txtFields_97.AutoCompleteSource = AutoCompleteSource.CustomSource
        _txtFields_97.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        _txtFields_98.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        _txtFields_98.AutoCompleteSource = AutoCompleteSource.CustomSource
        _txtFields_98.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        txtFields(102).Focus()


    End Sub

    Private Sub save_goto1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles save_goto1.Click
        Call SaveData()

        Me.Dispose()
        entry_type = "EDIT"
        frmmmpv1.ShowDialog()

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
        Me.ActiveControl.BackColor = Color.Aqua '(RGB(0, 255, 255))
        If Index = 102 Then
            If Len(txtFields(32).Text) <> 0 Then
                If InStr(txtFields(32).Text, "to") = 0 Then
                    txtFields(32).Text = txtFields(32).Text & txtFields(68).Text & " to " & txtFields(67).Text
                End If
            End If

        End If

    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index

                Case 67, 68


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


                Case 97, 98
                    'check account numbers

                    Dim retacct As String = etsacctnum_chk(txtFields(Index).Text)

                    If retacct = "N" Then
                        txtFields(Index).Text = ""
                        MsgBox(" Bad Account Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtFields(Index).Text = retacct
                    End If

                Case 101, 111, 121, 131, 141, 151, 161, 171, 181, 191 'line numb
                    'if no line number then no qty or dollars

                    If txtFields(Index).Text = "" Then
                        txtFields(CShort(Index + 2)).Focus()
                        KeyAscii = 0
                        txtFields(CShort(Index + 1)).Enabled = False
                        txtFields(CShort(Index + 3)).Enabled = False
                        txtFields(CShort(Index + 4)).Enabled = False
                        GoTo EventExitSub
                    Else
                        txtFields(CShort(Index + 1)).Enabled = True
                        txtFields(CShort(Index + 3)).Enabled = True
                        txtFields(CShort(Index + 4)).Enabled = True
                        txtFields(CShort(Index + 1)).Focus()
                        KeyAscii = 0
                        GoTo EventExitSub

                    End If

                Case 102, 112, 122, 132, 142, 152, 162, 172, 182, 192 'qty
                    If Val(txtFields(Index).Text) = 0 Then
                        txtFields(CShort(Index + 2)).Enabled = False
                        txtFields(CShort(Index + 3)).Enabled = True
                        txtFields(CShort(Index + 3)).Focus()
                        KeyAscii = 0
                        txtFields(CShort(Index + 2)).Enabled = False
                        txtFields(Index).Text = ""
                        GoTo EventExitSub
                    Else
                        txtFields(CShort(Index + 2)).Enabled = True
                        txtFields(CShort(Index + 2)).Focus()
                        KeyAscii = 0
                        GoTo EventExitSub 'need this to avoid the tab stop order
                    End If

                Case 104, 114, 124, 134, 144, 154, 164, 174, 184, 194 'unit pric
                    'calculate the amount and make the total non editable

                    txtFields(CShort(Index + 1)).Text = CStr(CDbl(txtFields(CShort(Index - 2)).Text) * Val(txtFields(Index).Text))
                    txtFields(CShort(Index + 1)).Enabled = False
                    If Val(txtFields(Index).Text) = 0 Then
                        txtFields(Index).Text = ""
                        txtFields(CShort(Index + 1)).Text = ""
                    End If
                    Call calc_doc_tot()

                    If Index < 194 Then
                        txtFields(CShort(Index - 3 + 10)).Focus()
                    Else
                        txtFields(32).Focus()
                        KeyAscii = 0
                        GoTo EventExitSub
                    End If

                Case 105, 115, 125, 135, 145, 155, 165, 175, 185, 195


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
        Call calc_doc_tot()

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

    Private Sub _txtFields_102_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _txtFields_102.TextChanged

    End Sub
End Class