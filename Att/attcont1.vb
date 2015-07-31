Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports System.String

Public Class attcont1
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "cc_cont"
    Public frmWhereClause As String = " where contract_key = '" & selected_contract_key & "'"
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

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub attcont1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Normal
        ctrform(Me)
        Me.BringToFront()

        sqlstmnt = "select * from cc_cont where contract_key =  '" & selected_contract_key & "'"

        If Len(selected_grouping) <> 0 Then
            sqlstmnt = sqlstmnt & " and fiscal_yr = '" & selected_grouping & "'"
        End If


        If RowData.Count = 0 Then
            entry_type = "ADD"
            'Else                   for rollover to be editroll
            '    entry_type = "EDIT"
        End If

        If entry_type = "ADD" Then
            'blank all the fields and make the key enabled
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                End If
            Next
            Txtfields(41).Text = "N"
            Txtfields(1).Text = "00"
            Txtfields(2).Text = "00"
            Txtfields(15).Text = "00"
            Txtfields(0).Enabled = True
            lblLabels(0).Text = "Contract Key"
            Txtfields(5).Text = "Y"
            Txtfields(36).Text = "0.00"
            Txtfields(35).Text = Today.ToShortDateString
            ' Txtfields(1).Enabled = True
            'Txtfields(2).Enabled = True
        Else
            '  Dim rs As New Collection
            ' RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
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
            Next

            Txtfields(0).Enabled = False
            Txtfields(1).Enabled = False
            Txtfields(2).Enabled = False
            TextBox1.Text = ETSSQL.GetOneSQLValue("Select email as thevalue from nam_addr where name_key = '" & Txtfields(18).Text & "'")
            TextBox2.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & Txtfields(16).Text & "'")
            TextBox3.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & Txtfields(17).Text & "'")
        End If

        current_fiscal = CInt(CStr(Year(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 6, Today))))
        Txtfields(20).Text = "D"

        'If Len(selected_grouping) = 0 Then
        '    Txtfields(0).Enabled = False
        '    Txtfields(1).Enabled = False
        '    Txtfields(2).Enabled = False
        'End If

        Txtfields(25).Text = CStr(Val(Txtfields(21).Text) + Val(Txtfields(23).Text))
        Txtfields(26).Text = CStr(Val(Txtfields(22).Text) + Val(Txtfields(24).Text))
        Txtfields(33).Text = CStr(Val(Txtfields(25).Text) - Val(Txtfields(27).Text) - Val(Txtfields(29).Text))
        Txtfields(34).Text = CStr(Val(Txtfields(26).Text) - Val(Txtfields(28).Text) - Val(Txtfields(30).Text))

        For num As Short = 22 To 34 Step 2
            Txtfields(num).Text = String.Format(Txtfields(num).Text, "C")
        Next

        Txtfields(58).Text = String.Format(Txtfields(58).Text, "C")
        Txtfields(15).Text = String.Format(Txtfields(15).Text, "C")
        Txtfields(36).Text = String.Format(Txtfields(36).Text, "C")
        Txtfields(8).Text = String.Format(Txtfields(8).Text, "C")

        Txtfields(35).Text = CStr(Today)

        _Txtfields_16.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        _Txtfields_16.AutoCompleteSource = AutoCompleteSource.CustomSource
        _Txtfields_16.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        _Txtfields_17.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        _Txtfields_17.AutoCompleteSource = AutoCompleteSource.CustomSource
        _Txtfields_17.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        If entry_type = "ADD" Then
            Txtfields(0).Focus()
        Else
            Txtfields(1).Focus()
        End If

    End Sub

    Private Sub gotopg2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gotopg2.Click

        'one final check on contract key duplication  based on length
        Select selected_contract_key.Length
            Case 16
                selected_contract_key = Txtfields(38).Text & Txtfields(1).Text & Txtfields(2).Text
                Txtfields(38).Text = selected_contract_key
            Case 20
                selected_contract_key = Txtfields(38).Text
            Case Else
                MsgBox("Misformed Contract Key.  Please repair.")
                Exit Sub
        End Select

        If ETSCommon.CheckYN("cc_cont", "contract_key", selected_contract_key, "N") = "Y" Then
            entry_type = "EDIT"
        Else
            entry_type = "ADD"
        End If

        'this updates funding to close sources if contract terminated

        'If Txtfields(10).DataChanged = True Then

        '    'update cc fund    for new date
        '    tmpdb = DAODBEngine_definst.OpenDatabase(att_data_path & "aratt.mdb")
        '    sqlstmnt = "select * from cc_Fund where contract_key = " & Chr(34) & selected_contract_key & Chr(34)
        '    tmpset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        '    If tmpset.NoMatch Then
        '        'no funding records to correct
        '    Else
        '        ' tmpset.MoveFirst
        '        Do While Not tmpset.EOF
        '            If tmpset.Fields("end_Date").Value >= Txtfields(10).Text Then
        '                tmpset.edit()
        '                tmpset.Fields("End_date").Value = Txtfields(10).Text
        '                tmpset.Fields("closed").Value = "Y"
        '                tmpset.Update()
        '            End If
        '            tmpset.MoveNext()
        '        Loop
        '    End If
        'End If

        ''this checks to make sure btype is not changed and to correct funding

        'If Txtfields(6).DataChanged = True Then

        '    'update cc fund    for new btype
        '    tmpdb = DAODBEngine_definst.OpenDatabase(att_data_path & "aratt.mdb")
        '    sqlstmnt = "select * from cc_Fund where contract_key = " & Chr(34) & selected_contract_key & Chr(34)
        '    tmpset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        '    If tmpset.NoMatch Then
        '        'no funding records to correct
        '    Else
        '        ' tmpset.MoveFirst
        '        Do While Not tmpset.EOF
        '            tmpset.edit()
        '            tmpset.Fields("bill_type").Value = Txtfields(6).Text
        '            tmpset.Update()
        '            tmpset.MoveNext()
        '        Loop
        '    End If
        'End If

        If entry_type = "EDIT" Then
            If Len(selected_grouping) <> 0 Then
                'If Txtfields(0).DataChanged Then
                '    'make sure you know which key
                '    'new is data1
                '    'old is tmpset
                '    Response = MsgBox("Do you wish to create new funding records?", MsgBoxStyle.YesNo)
                '    If Response = 6 Then
                '        'select the right records and change them
                '        tmpdb = DAODBEngine_definst.OpenDatabase(att_data_path & "aratt.mdb")
                '        sqlstmnt = "select * from cc_Fund where contract_key = " & Chr(34) & selected_contract_key & Chr(34)
                '        tmpset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
                '        On Error Resume Next
                '        tmpset.MoveFirst()
                '        If Err.Number <> 3021 Then
                '            Do While Not tmpset.EOF
                '                Data1.Recordset.AddNew()
                '                For num = 0 To Data1.Recordset.Fields.Count - 1
                '                    Data1.Recordset((num)) = tmpset.Fields(num).Value
                '                Next
                '                'update the fields you want to change
                '                  Data1.Recordset.Update()
                '            Loop
                '        End If

                '    End If
                'End If
            End If
        End If

        Call SaveData()

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Txtfields.Enter
        Dim Index As Short = Txtfields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()

        If Index = 0 Then
            If entry_type = "ADD" Then
                MsgBox("Enter all 16 digits of the contract without dashes.")
            End If
        End If

    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = Txtfields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index
                Case 0
                    If Len(selected_grouping) = 0 Then

                        Txtfields(Index).Text = UCase(Txtfields(Index).Text)
                        'formats the contract if the right length
                        If Len(Txtfields(Index).Text) <> 16 Then
                            MsgBox("The Contract ID must be 16 characters long with no puctuation.  Please Edit.")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        Else
                            Txtfields(38).Text = Txtfields(0).Text 'since can only be here on add
                            Txtfields(Index).Text = ets_format(Txtfields(Index).Text, msg, 4)
                        End If

                    End If
                Case 1
                    If Len(Txtfields(Index).Text) <> 2 Then
                        If Len(Txtfields(Index).Text) = 1 Then
                            Txtfields(Index).Text = Txtfields(Index).Text & "0"
                        Else
                            MsgBox("You must enter two digits.")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If
                Case 2 ' check to see if duplicate contract
                    If Len(Txtfields(Index).Text) <> 2 Then
                        If Len(Txtfields(Index).Text) = 1 Then
                            Txtfields(Index).Text = Txtfields(Index).Text & "0"
                        Else
                            MsgBox("You must enter two digits.")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If

                    'since on add can check for dups before going on
                    selected_cont_id_num = Txtfields(0).Text
                    selected_mmars_num = Txtfields(1).Text
                    selected_amend_num = Txtfields(2).Text
                    selected_contract_key = Txtfields(38).Text & Txtfields(1).Text & Txtfields(2).Text
                    If ETSCommon.CheckYN("cc_cont", "contract_key", selected_contract_key, "N") = "Y" Then
                        MsgBox("The contract already exists. Please re-enter number.")
                        GoTo EventExitSub
                    End If


                Case 7, 50, 39, 42, 43, 47
                    Txtfields(Index).Text = UCase(Txtfields(Index).Text)

                Case 4
                    Txtfields(Index).Text = UCase(Txtfields(Index).Text)
                    'look up to make sure these are valid reports
                    If Len(Txtfields(Index).Text) = 0 Then
                        function_type = "DATA_ENTRY"
                        rptlookup.ShowDialog()
                        Txtfields(Index).Text = selected_rpt_num
                    End If

                    Select Case Len(Txtfields(Index).Text)
                        Case 3
                            If CheckRecordCount("select * from rpt_type where rpt_num = '" & Txtfields(Index).Text & "'") = 0 Then
                                MsgBox(" You must enter 1,2 or 3 reports")
                                Call ets_set_selected()
                                GoTo EventExitSub
                            End If
                        Case 6
                            If CheckRecordCount("select * from rpt_type where rpt_num = '" & (Txtfields(Index).Text).Substring(0, 3) & "'") = 0 Then
                                MsgBox(" You must enter 1,2 or 3 reports")
                                Call ets_set_selected()
                                GoTo EventExitSub
                            End If
                            If CheckRecordCount("select * from rpt_type where rpt_num = '" & (Txtfields(Index).Text).Substring(3, 3) & "'") = 0 Then
                                MsgBox(" You must enter 1,2 or 3 reports")
                                Call ets_set_selected()
                                GoTo EventExitSub
                            End If

                        Case 9
                            If CheckRecordCount("select * from rpt_type where rpt_num = '" & (Txtfields(Index).Text).Substring(0, 3) & "'") = 0 Then
                                MsgBox(" You must enter 1,2 or 3 reports")
                                Call ets_set_selected()
                                GoTo EventExitSub
                            End If
                            If CheckRecordCount("select * from rpt_type where rpt_num = '" & (Txtfields(Index).Text).Substring(3, 3) & "'") = 0 Then
                                MsgBox(" You must enter 1,2 or 3 reports")
                                Call ets_set_selected()
                                GoTo EventExitSub
                            End If
                            If CheckRecordCount("select * from rpt_type where rpt_num = '" & (Txtfields(Index).Text).Substring(6, 3) & "'") = 0 Then
                                MsgBox(" You must enter 1,2 or 3 reports")
                                Call ets_set_selected()
                                GoTo EventExitSub
                            End If

                        Case Else
                            MsgBox(" You must enter 1,2 or 3 reports")
                            Call ets_set_selected()
                            GoTo EventExitSub
                    End Select
                Case 5
                    Txtfields(Index).Text = UCase(Txtfields(Index).Text)
                    If Txtfields(Index).Text <> "N" Then
                        If Txtfields(Index).Text <> "Y" Then
                            MsgBox("You must enter a Y or a N")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If

                Case 49
                    If Not IsNumeric(Txtfields(Index).Text) Then
                        MsgBox("Please enter a number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    If Len(Txtfields(Index).Text) <> 4 Then
                        MsgBox("Please enter a 4 digit year.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    If entry_type = "ADD" Then
                        Txtfields(10).Text = "6/30/" & Txtfields(Index).Text
                    End If

                Case 20
                    Txtfields(Index).Text = UCase(Txtfields(Index).Text)
                    If Txtfields(Index).Text <> "S" Then
                        If Txtfields(Index).Text <> "D" Then
                            MsgBox("You must enter an S or a D")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If

                Case 8, 15, 36, 37, 58
                    If IsNumeric(Txtfields(Index).Text) Then
                        Val(Txtfields(Index).Text).ToString("F2")
                    Else
                        MsgBox("Invalid Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    'JRI  change funding here as well 

                Case 21, 23
                    Txtfields(25).Text = CStr(Val(Txtfields(21).Text) + Val(Txtfields(23).Text))
                    Txtfields(33).Text = CStr(Val(Txtfields(25).Text) - Val(Txtfields(27).Text))

                Case 22, 24

                    Txtfields(26).Text = CStr(Val(Txtfields(22).Text) + Val(Txtfields(24).Text))
                    Txtfields(34).Text = CStr(Val(Txtfields(26).Text) - Val(Txtfields(28).Text))

                Case 18

                    function_type = "DATA_ENTRY"
                    saved_package_Type = package_Type
                    package_Type = "AR"
                    valid_name = "N"
                    selected_name_key = ""

                    If Val(Txtfields(Index).Text) = 0 Then
                        frmnamechk.ShowDialog()
                        Txtfields(Index).Text = selected_name_key
                    End If

                    Call chkname(Txtfields(Index).Text)
                    package_Type = saved_package_Type

                    If valid_name = "N" Then
                        Txtfields(CShort(Index + 1)).Text = ""
                        MsgBox(" Invalid Customer Number")
                        Call ets_set_selected()
                        GoTo EventExitSub

                    Else
                        Txtfields(19).Text = selected_screen_nam
                        TextBox1.Text = ETSSQL.GetOneSQLValue("Select email as thevalue from nam_addr where name_key = '" & Txtfields(18).Text & "'")
                    End If

                    package_Type = "ATT"
                    function_type = " "


                Case 9, 10, 11, 12

                    If Len(Txtfields(Index).Text) = 0 Then
                        System.Windows.Forms.SendKeys.Send("{tab}")
                        KeyAscii = 0
                        GoTo EventExitSub
                    End If

                    senddate = Txtfields(Index).Text
                    Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")

                    If retdate = "N" Then
                        senddate = ""
                        MsgBox(" Bad Date")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        Txtfields(Index).Text = retdate.ToString
                    End If

                Case 41
                    Txtfields(Index).Text = UCase(Txtfields(Index).Text)
                    If Txtfields(Index).Text <> "N" Then
                        If Txtfields(Index).Text <> "Y" Then
                            MsgBox("You must enter a Y or a N")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                    End If

                Case 40
                    saved_function_Type = function_type
                    function_type = "DATA_ENTRY"
                    retdptdesc = Txtfields(49).Text
                    new_Fiscal = CInt(Val(Txtfields(49).Text))
                    If Len(new_Fiscal) = 0 Then
                        new_Fiscal = Year(Today)
                    End If

                    If Val(Txtfields(Index).Text) = 0 Then
                        prognumlookup.ShowDialog()
                        Txtfields(Index).Text = selected_prog_num
                        Txtfields(CShort(8)).Text = CStr(selected_prog_rate)
                    End If

                    If ETSCommon.CheckNumRecords("select * from program where prog_num = '" & Txtfields(Index).Text & "' and fiscal_yr = '" & new_Fiscal.ToString & "'") = 0 Then
                        MsgBox("Not a valid Program.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    Txtfields(CShort(8)).Text = ETSSQL.GetOneSQLValue("select prog_rate as thevalue from program where prog_num = '" & Txtfields(Index).Text & "' and fiscal_yr = '" & new_Fiscal.ToString & "'")
                    function_type = saved_function_Type

                Case 16, 17
                    saved_function_Type = function_type
                    function_type = "DATA_ENTRY"
                    Call etsacctnum_chk(Txtfields(Index).Text)

                    If valid_acct = "N" Then
                        MsgBox("Not a valid account number.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    Txtfields(Index).Text = retacct
                    If Index = 16 Then
                        TextBox2.Text = ETSSQL.GetOneSQLValue("select acct_desc as thevalue from chacct where acct_num = '" & Txtfields(16).Text & "'")
                    Else
                        TextBox3.Text = ETSSQL.GetOneSQLValue("select acct_desc as thevalue from chacct where acct_num = '" & Txtfields(17).Text & "'")
                    End If

                    function_type = saved_function_Type
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

    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Txtfields.Leave
        Dim Index As Short = Txtfields.GetIndex(CType(eventSender, TextBox))
        Txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        If Index = 16 Or Index = 17 Then
            TextBox2.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & Txtfields(16).Text & "'")
            TextBox3.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & Txtfields(17).Text & "'") 
        End If

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

        selected_cont_id_num = Txtfields(0).Text
        selected_mmars_num = Txtfields(1).Text
        selected_amend_num = Txtfields(2).Text


        Txtfields(38).Text = selected_contract_key
        'check to make sure that the description is not zero length
        If Len(Txtfields(3).Text) = 0 Then
            MsgBox("You must enter a contract description")
            Txtfields(3).Focus()
            Exit Sub
        End If

        If Len(Txtfields(18).Text) = 0 Then
            MsgBox("You must enter a customer name key.")
            Txtfields(18).Focus()
            Exit Sub
        End If

        If Len(Txtfields(9).Text) = 0 Then
            MsgBox("You must enter a contract begin date.")
            Txtfields(9).Focus()
            Exit Sub
        End If

        If Len(Txtfields(39).Text) <> 0 Then
            Response = InStr(Txtfields(39).Text, "****")
            If Response = 0 Then
                MsgBox("You must enter 4 stars in the invoice string.")
                Txtfields(39).Focus()
                Exit Sub
            End If
        End If

        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                TagColumnName = Me.cntrl.Tag.ToString
                If Len(TagColumnName) <> 0 Then
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    frmdata.ActualData = cntrl.Text
                End If
            End If
        Next

        Select Case entry_type.ToString
            Case "ADD"
                'add sort name and agency
                RowData.Item(72).ActualData = CStr((AgencyNum))
                RowData.Item(0).ActualData = Txtfields(38).Text
                RowData.Item(76).ActualData = "X"       'billable codes
                Call ETSSQL.InsertData(frmTableName, RowData)
            Case "EDIT", "EDITROLL"
                Call ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)
        End Select

        Me.Close()
        Me.Dispose()
        attcont2.ShowDialog()

    End Sub

    Private Sub AddChacct_Click(sender As System.Object, e As System.EventArgs) Handles AddChacct.Click
        saved_entry_type = entry_type
        entry_type = "ADD"

        acctlookup.ShowDialog()

        entry_type = saved_entry_type
        'rebuild the drop downs

        _Txtfields_16.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        _Txtfields_16.AutoCompleteSource = AutoCompleteSource.CustomSource
        _Txtfields_16.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        _Txtfields_17.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        _Txtfields_17.AutoCompleteSource = AutoCompleteSource.CustomSource
        _Txtfields_17.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub
End Class