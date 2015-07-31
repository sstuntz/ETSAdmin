Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System
Imports System.IO
Imports System.Data
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient

Public Class arinv
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "invoice"
    Public frmWhereClause As String = " where inv_num = '" & selected_lookup_num & "' and line_num = " & selected_line_num
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        'test for completeness on txtfields only
        'For num = 0 To 100
        '    msg = "," & CStr(num) & ","
        '    Response = InStr(",0,1,4,9,10,", msg)
        '    If Response <> 0 Then
        '        If Len(txtFields(CShort(num)).Text) = 0 Then
        '            MsgBox("You must fill in all required fields.")
        '            txtFields(CShort(num)).Focus()
        '            Exit Sub
        '        End If
        '    End If
        'Next

        Call CheckData()

        Call PutData()

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

    Private Sub Cmdupdate_cont_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdupdate_cont.Click

        Call CheckData()
        Call PutData()
        'now reset fields adding a new line
        txtFields(1).Text = (Val(txtFields(1).Text) + 1).ToString
        txtFields(11).Text = ""
        TextBox4.Text = ""

    End Sub

    Private Sub SaveAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles SaveAdd.Click

        Call CheckData()
        Call PutData()

        'like and add so do the add thing here
        For Each Me.cntrl In Me.Controls
            If TypeOf cntrl Is TextBox Then
                cntrl.Text = ""
                txtFields(0).Enabled = True
            End If
        Next
        txtFields(0).Enabled = True ' these are set to false on load
        txtFields(1).Enabled = True
        txtFields(2).Text = "INV" 'added 5-13-00 lhw
        txtFields(12).Text = CStr(Today.ToShortDateString)
        txtFields(13).Text = CStr(Today.ToShortDateString)
        txtFields(14).Text = GetEndOfPriorMonth(Today).ToShortDateString
        txtFields(15).Text = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 30, CDate(txtFields(13).Text)))
        txtFields(0).Text = att_mod.GetNextCompanyInvoiceNum.ToString
        txtFields(1).Text = "1"
        TextBox2.Text = txtFields(14).Text
        TextBox3.Text = Month(CDate(txtFields(14).Text)) & "/" & "1/" & Year(CDate(txtFields(14).Text))

    End Sub

    Private Sub frmarinv_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        frmWhereClause = " where inv_num = '" & selected_lookup_num & "' and line_num = " & selected_line_num

        If entry_type = "ADD" Then
            'blank all the fields and make the key enabled
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                    txtFields(0).Enabled = True
                End If
            Next
            txtFields(0).Enabled = True ' these are set to false on load
            txtFields(1).Enabled = True
            txtFields(2).Text = "INV" 'added 5-13-00 lhw
            txtFields(12).Text = CStr(Today.ToShortDateString)
            txtFields(13).Text = CStr(Today.ToShortDateString)
            txtFields(14).Text = GetEndOfPriorMonth(Today).ToShortDateString
            txtFields(15).Text = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 30, CDate(txtFields(13).Text)))
            txtFields(0).Text = att_mod.GetNextCompanyInvoiceNum.ToString
            txtFields(1).Text = "1"
            TextBox2.Text = txtFields(14).Text
            TextBox3.Text = Month(CDate(txtFields(14).Text)) & "/" & "1/" & Year(CDate(txtFields(14).Text))
            TextBox5.Text = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "unit_rate")
        Else
            entry_type = "EDIT"
            cmdUpdate.Visible = True
            Dim rs As New Collection
            RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    If Not Len(Me.cntrl.Tag) = 0 Then
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
                End If
            Next
            txtFields(0).Enabled = False
        End If

        txtFields(11).Text = String.Format("{0:N2}", txtFields(11).Text)
        txtFields(20).Text = String.Format("{0:F2}", txtFields(20).Text)
        txtFields(21).Text = String.Format("{0:F2}", txtFields(21).Text)
        txtFields(30).Text = String.Format("{0:F2}", txtFields(30).Text)

        _txtFields_9.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        _txtFields_9.AutoCompleteSource = AutoCompleteSource.CustomSource
        _txtFields_9.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        _txtFields_10.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        _txtFields_10.AutoCompleteSource = AutoCompleteSource.CustomSource
        _txtFields_10.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        selected_contract_key = ""

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        Me.ActiveControl.BackColor = Color.Aqua '(RGB(0, 255, 255))
        Call ets_set_selected()

    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            Select Case Index

                Case 0, 1 'Trap for valid numbers
                    If Val(txtFields(0).Text) = 0 Then
                        MsgBox("Please enter a number")
                        GoTo EventExitSub
                    End If

                    If Not IsNumeric(txtFields(0).Text) Then
                        MsgBox("Not a valid number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    'Valid_YN = "N" ' sets the yn to
                    'Call chkinvline_num(txtFields(0), txtFields(1))

                    'If Valid_YN = "N" Then
                    '    MsgBox("This is a duplicate inv/line number, re-enter correct number")
                    '    Call ets_set_selected()
                    '    GoTo EventExitSub
                    'End If

                Case 11, 30, 20, 21 'format the dollar fields

                    If Len(txtFields(Index).Text) = 0 Then
                        txtFields(Index).Text = CStr(0)
                        GoTo EventExitSub
                    End If
                    txtFields(Index).Text = FormatNumber(txtFields(Index).Text)

                    'this is turned off for now
                    ' valid_YN = "N"    ' sets the yn to n
                    ' Call chkarinv_num(txtFields(0)) ' call will set it to y if no match
                    ' If valid_YN = "N" Then
                    ' MsgBox "This is a duplicate number, re-enter correct number"
                    '  Call ets_set_selected
                    ' Exit Sub
                    ' End If
                    If Index = 11 And entry_type = "ADD" Then
                        txtFields(20).Text = txtFields(11).Text
                    End If

                    If Index = 11 And entry_type = "EDIT" Then
                        txtFields(20).Text = CStr(CDbl(txtFields(11).Text) - CDbl(txtFields(30).Text))
                    End If

                    'added 2/28/01 lhw with the CM DM change

                Case 2
                    txtFields(Index).Text = UCase(txtFields(Index).Text)

                    Select Case txtFields(Index).Text
                        Case "CM", "DM" 'credit or debit memo not checking amt for sign
                            'fill todays dates
                            txtFields(13).Text = CStr(Today.ToShortDateString)
                            txtFields(14).Text = CStr(Today.ToShortDateString)
                            txtFields(15).Text = CStr(Today.ToShortDateString)
                            cmdupdate_cont.Enabled = False
                            SaveAdd.Enabled = False

                        Case "INV"

                        Case "ADJ"

                        Case "PMT"

                        Case "MISC" 'bcarc

                        Case Else

                            MsgBox("Not a valid choice, please enter INV or ADJ or MISC or CM or DM")
                            Call ets_set_selected()
                            GoTo EventExitSub


                    End Select

                Case 4

                    If Len(txtFields(Index).Text) = 0 Then
                        frmnamechk.ShowDialog()
                        Me.txtFields(Index).Text = selected_name_key
                        Me.txtFields(CShort(Index + 1)).Text = selected_screen_nam
                    Else
                        selected_name_key = txtFields(Index).Text
                        selected_screen_nam = ETSCommon.GetDatum("nam_addr", "name_key", selected_name_key, "screen_nam")
                        Me.txtFields(CShort(Index + 1)).Text = selected_screen_nam
                    End If
                    If checkYN("nam_cust", "name_key", txtFields(Index).Text) = "N" Then
                        txtFields(CShort(Index + 1)).Text = ""
                        MsgBox("Invalid customer number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If


                    Dim cust_type As String = ETSCommon.GetDatum("nam_cust", "name_key", selected_name_key, "cust_type")
                    If cust_type = "C" Or cust_type = "M" Then
                        txtFields(2).Text = "MISC"
                    End If

                Case 6

                    package_Type = "TY"
                    If Len(txtFields(Index).Text) = 0 Then
                        frmnamechk.ShowDialog()
                        Me.txtFields(Index).Text = selected_name_key
                        Me.txtFields(CShort(Index + 1)).Text = selected_sort_name
                    Else
                        selected_name_key = txtFields(Index).Text
                    End If
                    If checkYN("nam_addr", "name_key", txtFields(Index).Text) = "N" Then
                        txtFields(CShort(Index + 1)).Text = ""
                        MsgBox("Invalid number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    package_Type = "AR"

                Case 12, 13, 14, 15, 16 'valid dates
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


                    If Index = 13 Then
                        '   txtFields(14).Text = txtFields(13).Text 'default to inv date
                        txtFields(15).Text = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 30, CDate(txtFields(13).Text)))
                    End If

                    If Index = 14 Then
                        'change invoice string
                        txtFields(28).Text = invoice_string_Create(txtFields(14).Text, selected_contract_key)
                    End If

                Case 9 'gl acct number lookup
                    function_type_saved = function_type
                    function_type = "LOOKUP_ONLY"
                    Dim retacct As String = etsacctnum_chk(txtFields(Index).Text)
                    If retacct = "N" Then
                        txtFields(Index).Text = ""
                        MsgBox(" Bad Account Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtFields(Index).Text = retacct
                    End If
                    function_type = function_type_saved
                    TextBox6.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & txtFields(Index).Text & "'")
           
                Case 10 'gl acct number lookup
                    function_type_saved = function_type
                    function_type = "LOOKUP_ONLY"
                    Dim retacct As String = etsacctnum_chk(txtFields(Index).Text)
                    If retacct = "N" Then
                        txtFields(Index).Text = ""
                        MsgBox(" Bad Account Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtFields(Index).Text = retacct
                    End If
                    function_type = function_type_saved
                    TextBox8.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & txtFields(Index).Text & "'")


            End Select

done3:
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If

    End Sub

    Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Leave
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub textbox_enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextBox1.Enter, TextBox2.Enter, TextBox3.Enter, TextBox4.Enter
        Form.ActiveForm.ActiveControl.BackColor = Color.Aqua '(RGB(0, 255, 255))
        Call ets_set_selected()
    End Sub

    Private Sub textbox_leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextBox1.Leave, TextBox2.Leave, TextBox3.Leave, TextBox4.Leave
        ' System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        TextBox6.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & _txtFields_9.Text & "'")
        TextBox8.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & _txtFields_10.Text & "'")

        For Each Me.cntrl In Me.Controls
            If TypeOf cntrl Is TextBox Then
                Me.cntrl.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub TextBox2_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
            Dim retdate As String = ETS.Common.Module1.etsdate(TextBox2.Text, "N")
            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                TextBox2.Text = CDate(retdate).ToShortDateString
            End If
            '  System.Windows.Forms.SendKeys.Send("{tab}")
            ' KeyAscii = 0
            Form.ActiveForm.ActiveControl.BackColor = Color.White
            TextBox4.Text = (DateDiff(DateInterval.Day, CDate(TextBox3.Text), CDate(TextBox2.Text)) + 1).ToString
            _txtFields_11.Text = CStr(CDbl(TextBox4.Text) * CDbl(TextBox5.Text))

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
            Form.ActiveForm.ActiveControl.BackColor = Color.White
        End If
EventExitSub:
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox3_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
            Dim retdate As String = ETS.Common.Module1.etsdate(TextBox3.Text, "N")
            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                TextBox3.Text = CDate(retdate).ToShortDateString
            End If
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
            Form.ActiveForm.ActiveControl.BackColor = Color.White
        End If

EventExitSub:
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub Textbox4_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        'amt to be applied to this invoice
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
            If Not IsNumeric(TextBox4.Text) Then
                MsgBox("Please enter an amount.")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
                Form.ActiveForm.ActiveControl.BackColor = Color.White
            End If
        End If
EventExitSub:
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub Textbox5_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        'amt to be applied to this invoice
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
            If Not IsNumeric(TextBox5.Text) Then
                MsgBox("Please enter an amount.")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                _txtFields_11.Text = CStr(CDbl(TextBox4.Text) * CDbl(TextBox5.Text))
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
                Form.ActiveForm.ActiveControl.BackColor = Color.White
            End If
        End If
EventExitSub:
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Private Sub Textbox1_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Tab) Then
            TextBox1.Text = UCase(TextBox1.Text)
            Dim SavedEntry As String = TextBox1.Text
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                End If
            Next
            TextBox1.Text = SavedEntry
            txtFields(0).Enabled = True ' these are set to false on load
            txtFields(1).Enabled = True
            txtFields(2).Text = "INV" 'added 5-13-00 lhw
            txtFields(12).Text = CStr(Today.ToShortDateString)
            txtFields(13).Text = CStr(Today.ToShortDateString)
            txtFields(14).Text = GetEndOfPriorMonth(Today).ToShortDateString
            txtFields(15).Text = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 30, CDate(txtFields(13).Text)))
            txtFields(0).Text = att_mod.GetNextCompanyInvoiceNum.ToString
            txtFields(1).Text = "1"
            TextBox2.Text = txtFields(14).Text
            TextBox3.Text = Month(CDate(txtFields(14).Text)) & "/1/" & Year(CDate(txtFields(14).Text))
            TextBox5.Text = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "unit_rate")

            If Len(TextBox1.Text) = 0 Then
                contnumlookup.ShowDialog()
                TextBox1.Text = selected_contract_key

            Else
                selected_contract_key = TextBox1.Text
                If ETSCommon.CheckYN("cc_Cont", "contract_key", selected_contract_key, "N") = "N" Then
                    MsgBox("The contract does not exist.")
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If
            End If
            Dim ContractforInvoice As New ContractData
            ContractforInvoice = ETSSQL.GetOneContractData("select * from cc_Cont where contract_key = '" & TextBox1.Text & "'")
            txtFields(4).Text = ContractforInvoice.NameKey
            txtFields(5).Text = ContractforInvoice.ScreenNam
            txtFields(9).Text = ContractforInvoice.DrAcctNu
            txtFields(10).Text = ContractforInvoice.CrAcctNu
            txtFields(28).Text = invoice_string_Create(txtFields(14).Text, selected_contract_key)
            TextBox5.Text = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "unit_rate")
            TextBox6.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & _txtFields_9.Text & "'")
            TextBox8.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & _txtFields_10.Text & "'")


            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
            Form.ActiveForm.ActiveControl.BackColor = Color.White
        End If

EventExitSub:
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If

    End Sub

    Public Function GetEndOfPriorMonth(ByVal TheDate As Date) As Date
        Dim NewDate As Date
        Response = Month(TheDate) - 1
        responseyear = Year(TheDate)
        If Response = 0 Then
            Response = 12
            responseyear = responseyear - 1
        End If

        Select Case Response
            Case 1
                NewDate = CDate("1" & Chr(45) & "31" & Chr(45) & responseyear)
            Case 2
                NewDate = CDate("2" & Chr(45) & "28" & Chr(45) & responseyear)
            Case 3
                NewDate = CDate("3" & Chr(45) & "31" & Chr(45) & responseyear)
            Case 4
                NewDate = CDate("4" & Chr(45) & "30" & Chr(45) & responseyear)
            Case 5
                NewDate = CDate("5" & Chr(45) & "31" & Chr(45) & responseyear)
            Case 6
                NewDate = CDate("6" & Chr(45) & "30" & Chr(45) & responseyear)
            Case 7
                NewDate = CDate("7" & Chr(45) & "31" & Chr(45) & responseyear)
            Case 8
                NewDate = CDate("8" & Chr(45) & "31" & Chr(45) & responseyear)
            Case 9
                NewDate = CDate("9" & Chr(45) & "30" & Chr(45) & responseyear)
            Case 10
                NewDate = CDate("10" & Chr(45) & "31" & Chr(45) & responseyear)
            Case 11
                NewDate = CDate("11" & Chr(45) & "30" & Chr(45) & responseyear)
            Case 12
                NewDate = CDate("12" & Chr(45) & "31" & Chr(45) & responseyear)
        End Select

        If VB.Left(CStr(NewDate), 1) = "2" Then
            If IsDate("2" & Chr(45) & "29" & Chr(45) & responseyear) Then
                NewDate = CDate("2" & Chr(45) & "29" & Chr(45) & responseyear)
            End If
        End If

        Return NewDate

    End Function

    Public Sub PutData()

        Dim NextInvoice As New CompanyInvoiceData
        NextInvoice = ETSSQL.GetBlankCompanyInvoiceData
        NextInvoice.InvNum = CInt(txtFields(0).Text)
        NextInvoice.Invoice = txtFields(28).Text
        NextInvoice.LineNum = CInt(txtFields(1).Text)
        NextInvoice.TransCode = txtFields(2).Text
        NextInvoice.NameKey = txtFields(4).Text
        NextInvoice.ScreenNam = txtFields(5).Text
        If selected_sort_name Is DBNull.Value Then selected_sort_name = ""
        NextInvoice.SortName = selected_sort_name
        NextInvoice.InvDesc = txtFields(8).Text
        NextInvoice.ContractKey = TextBox1.Text
        NextInvoice.FromDate = CDate(TextBox3.Text)
        NextInvoice.ToDate = CDate(TextBox2.Text)
        NextInvoice.EntryDate = CDate(txtFields(12).Text)
        NextInvoice.InvoiceDate = CDate(txtFields(13).Text)
        NextInvoice.EncumDate = CDate(txtFields(14).Text)
        NextInvoice.BalDue = CDec(_txtFields_11.Text)
         If String.IsNullOrEmpty(txtFields(21).Text) Then
            txtFields(21).Text = CStr(0)
        End If
        NextInvoice.InvAmt = CDec(txtFields(21).Text)
        NextInvoice.CrAcctNu = txtFields(10).Text
        NextInvoice.DrAcctNu = txtFields(9).Text
        NextInvoice.InvNum = GetNextCompanyInvoiceNum()
        NextInvoice.Units = CDec(TextBox4.Text)
        NextInvoice.UnitRate = CDec(TextBox5.Text)
        NextInvoice.AllocAmt = CDec(_txtFields_11.Text)
        NextInvoice.PoNum = txtFields(3).Text
        NextInvoice.CcNum = txtFields(6).Text
        NextInvoice.CcName = txtFields(7).Text
        NextInvoice.DtTbePd = CDate(txtFields(15).Text)

        'put the invoice in file
        Select Case entry_type.ToString
            Case "ADD"
                sqlstmnt = "insert into invoice " & NextInvoice.CompanyInvoiceColumnNames & "  values " & NextInvoice.CompanyInvoiceColumnData
                ETSSQL.ExecuteSQL(sqlstmnt)
            Case "EDIT"
                sqlstmnt = "update invoice set "
                ETSSQL.ExecuteSQL(sqlstmnt)
        End Select
    End Sub

    Public Sub CheckData()
        If Len(txtFields(9).Text) = 0 Then
            MsgBox("You must enter a dr acct num.")
            txtFields(9).Focus()
            Exit Sub
        End If

        If Len(txtFields(10).Text) = 0 Then
            MsgBox("You must enter a cr acct num.")
            txtFields(10).Focus()
            Exit Sub
        End If

    End Sub

    Private Sub _txtFields_9_TextChanged(sender As System.Object, e As System.EventArgs) Handles _txtFields_9.TextChanged
        TextBox6.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & txtFields(9).Text & "'")

    End Sub

    Private Sub _txtFields_10_TextChanged(sender As System.Object, e As System.EventArgs) Handles _txtFields_10.TextChanged
        TextBox8.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & txtFields(10).Text & "'")

    End Sub
End Class