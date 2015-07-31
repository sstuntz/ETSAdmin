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

Public Class create_attend
    Inherits System.Windows.Forms.Form

    Public att_temp_unit As Double
    Public start_fund_Date As Date
    Public end_fund_Date As Date
    Public BNumFundData As List(Of FundingData)
    Dim tot_records As Integer
    Dim recs As Integer
    Dim BasicAttendData As AttendData
    Dim Billable As List(Of Billable)
    Dim BillableContract As List(Of BillableContract)
    Dim BillableClient As List(Of BillableClient)
    Dim Billed As New List(Of Billable)
    Dim ToFind As String


    'how to check if missing
    '"select COUNT(*) as thevalue from cash_tmp1  left outer join chacct on chacct.acct_num = cash_tmp1.dr_acct_nu where chacct.acct_num is null and batch_num = '" & selected_bat_num & "'"))

    Public Sub BuildAttendRecord(ByRef BNum As String, ByVal present_day As Date)

        BasicAttendData = ETSSQL.GetBlankAttendanceData
        Dim BNumContractData As List(Of ContractData) = ETSSQL.GetContractData("Select * from cc_Cont where contract_key = '" & selected_contract_key & "'")
        Dim BnumNameAddr As List(Of ContactData) = ETSSQL.GetContactData(selected_name_key, "nam_addr")
        BNumFundData = ETSSQL.GetFundData("select * from cc_fund where b_num = '" & BNum & "'")
        BasicAttendData.Agency = BNumContractData.Item(0).Agency
        BasicAttendData.AttDate = present_day

        BasicAttendData.BNum = BNum
        BasicAttendData.NameKey = selected_name_key
        BasicAttendData.ContractKey = selected_contract_key
        BasicAttendData.ScreenNam = BnumNameAddr.Item(0).ScreenName
        BasicAttendData.SortName = BnumNameAddr.Item(0).SortName
        '  BasicAttendData.AuthoNum = ""
        BasicAttendData.BillType = BNumContractData.Item(0).BillType
        BasicAttendData.PvForm = BNumContractData.Item(0).PvForm
        BasicAttendData.RptType = BNumContractData.Item(0).RptType
        BasicAttendData.UnitRate = BNumFundData.Item(0).UnitRate
        BasicAttendData.Offset = BNumFundData.Item(0).Offset
        BasicAttendData.SlotNum = BNumFundData.Item(0).SlotNum
        BasicAttendData.NameChk = BNumFundData.Item(0).NameChk
        BasicAttendData.SsNum = ETSCommon.GetDatum("cc_base", "Name_key", selected_name_key, "ss_num")
        '   BasicAttendData.MedNum = = ""
        BasicAttendData.AttCode = BNumFundData.Item(0).AttCode
        BasicAttendData.AttUnit = BNumFundData.Item(0).AttUnit
        If BasicAttendData.BillType = "125" Then
            Get125DailyUnits(present_day)
            BasicAttendData.AttUnit = att_temp_unit
        End If
        BasicAttendData.InvoiceDate = CDate("1/1/1901")
        ' BasicAttendData.Invoice = ""
        BasicAttendData.CustNum = BNumContractData.Item(0).NameKey
        BasicAttendData.DrAcctNu = BNumFundData.Item(0).DrAcctNu
        BasicAttendData.CrAcctNu = BNumFundData.Item(0).CrAcctNu
        BasicAttendData.EntryDate = Today
        BasicAttendData.Dflag = "N"
        BasicAttendData.Void = "N"
        '  BasicAttendData.ClientPct = ""

        sqlstmnt = "Insert into attend_tmp " & BasicAttendData.AttendColumnNames & " values " & BasicAttendData.AttendColumnData
        ETSSQL.ExecuteSQL(sqlstmnt)

    End Sub

    Public Function CheckIfBilled(ByVal Bnum As String) As String
        Dim YNValue As String = "N"
        num = 0
        sqlstmnt = "select * from attend_tmp where b_num = '" & Bnum & "' and att_date BETWEEN "
        sqlstmnt = sqlstmnt & "'" & start_date.Text & "' and '" & End_Date.Text & "' and (void = 'N')"
        num = ETSCommon.CheckNumRecords(sqlstmnt)

        sqlstmnt = "select * from attend_hist where b_num = '" & Bnum & "' and att_date BETWEEN "
        sqlstmnt = sqlstmnt & "'" & start_date.Text & "' and '" & End_Date.Text & "' and (void = 'N')"
        num = num + ETSCommon.CheckNumRecords(sqlstmnt)
        If num > 0 Then YNValue = "Y"

        Return YNValue

    End Function

    Public Sub create_Rec_Type_100(ByVal b_num As String)
        'this is residential billing
        selected_name_key = div_b_num(b_num).ToString()

        present_day = start_fund_Date

        Do While present_day <= end_fund_Date
            Call BuildAttendRecord(b_num, present_day)        'write the attend record
            present_day = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, present_day)
        Loop
    End Sub

    Public Sub create_Rec_Type_120(ByVal b_num As String)
        'vocational billing items
        selected_name_key = div_b_num(b_num).ToString()

        present_day = start_fund_Date
        BNumFundData = ETSSQL.GetFundData("select * from cc_fund where b_num = '" & b_num & "'")

        Do While present_day <= end_fund_Date
            'write the attend recordif the day of the week matches up
            Select Case Weekday(present_day)
                Case 2 '"Monday"
                    If BNumFundData.Item(0).Mon <> "Y" Then
                        GoTo skip_attend
                    End If
                Case 3 '"Tuesday"
                    If BNumFundData.Item(0).Tue <> "Y" Then
                        GoTo skip_attend
                    End If
                Case 4 '"Wednesday"
                    If BNumFundData.Item(0).Wed <> "Y" Then
                        GoTo skip_attend
                    End If
                Case 5 '"Thursday"
                    If BNumFundData.Item(0).Thu <> "Y" Then
                        GoTo skip_attend
                    End If
                Case 6 '"Friday"
                    If BNumFundData.Item(0).Fri <> "Y" Then
                        GoTo skip_attend
                    End If
                Case 7 '"Saturday"
                    If BNumFundData.Item(0).Sat <> "Y" Then
                        GoTo skip_attend
                    End If
                Case 1 '"Sunday"
                    If BNumFundData.Item(0).Sun <> "Y" Then
                        GoTo skip_attend
                    End If
            End Select

            Call BuildAttendRecord(b_num, present_day)        'write the attend record
skip_attend:
            present_day = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, present_day)
        Loop

    End Sub

    Public Sub create_Rec_Type_125(ByVal b_num As String)
        'vocational billing items
        selected_name_key = div_b_num(b_num).ToString()

        present_day = start_fund_Date
        BNumFundData = ETSSQL.GetFundData("select * from cc_fund where b_num = '" & b_num & "'")

        Do While present_day <= end_fund_Date
            'write the attend recordif the day of the week matches up
            Dim att_temp_unit As Double
            Select Case Weekday(present_day)
                Case 2 '"Monday"
                    If Not IsNumeric(BNumFundData.Item(0).Mon) Then
                        GoTo skip_attend
                    Else
                        att_temp_unit = Val(BNumFundData.Item(0).Mon)
                    End If
                Case 3 '"Tuesday"
                    If Not IsNumeric(BNumFundData.Item(0).Tue) Then
                        GoTo skip_attend
                    Else
                        att_temp_unit = Val(BNumFundData.Item(0).Tue)
                    End If
                Case 4 '"Wednesday"
                    If Not IsNumeric(BNumFundData.Item(0).Wed) Then
                        GoTo skip_attend
                    Else
                        att_temp_unit = Val(BNumFundData.Item(0).Wed)
                    End If
                Case 5 '"Thursday"
                    If Not IsNumeric(BNumFundData.Item(0).Thu) Then
                        GoTo skip_attend
                    Else
                        att_temp_unit = Val(BNumFundData.Item(0).Thu)
                    End If
                Case 6 '"Friday"
                    If Not IsNumeric(BNumFundData.Item(0).Fri) Then
                        GoTo skip_attend
                    Else
                        att_temp_unit = Val(BNumFundData.Item(0).Fri)
                    End If
                Case 7 '"Saturday"
                    If Not IsNumeric(BNumFundData.Item(0).Sat) Then
                        GoTo skip_attend
                    Else
                        att_temp_unit = Val(BNumFundData.Item(0).Sat)
                    End If
                Case 1 '"Sunday"
                    If Not IsNumeric(BNumFundData.Item(0).Sun) Then
                        GoTo skip_attend
                    Else
                        att_temp_unit = Val(BNumFundData.Item(0).Sun)
                    End If
            End Select

            Call BuildAttendRecord(b_num, present_day)        'write the attend record
skip_attend:
            present_day = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, present_day)
        Loop

    End Sub

    Public Sub create_Rec_Type_140(ByVal b_num As String)
        'jri does not use

        'Dss billing
        'uses autho to get begin and end dates
        'this finds the contract num and name key from b_num

        'Call div_b_num(b_num).ToString()

        'present_day = CDate( start_date1.Text)
        ' end_date_tmp = CDate( End_Date1.Text)

        'find the right autho for this kid and then we will test the date to get the right autho
        '		autho.RecordSource = "select * from cc_autho where name_key = " & Chr(34) & selected_name_key & Chr(34)
        '		autho.Refresh()
        '		autho.Recordset.MoveFirst()
        '		If Err.Number = 3021 Then 'there is no authorization for this one
        '			msg = "There is no authorization for consumer = " & nam_addr.Recordset.Fields("screen_nam")
        '			MsgBox(msg)
        '			Exit Sub
        '		End If
        '		If contract.Recordset.Fields("cont_end_d") <  end_date Then
        '			MsgBox("Ending date will be set to contract end date")
        '			 end_date_tmp = contract.Recordset.Fields("cont_end_d")
        '		End If
        '		base.RecordSource = "select * from cc_base where name_key = " & Chr(34) & selected_name_key & 

        '		base.Refresh()
        '		tmp1db = DAODBEngine_definst.OpenDatabase(att_data_path & "aratt.mdb")
        '		tmp1set = tmpdb.OpenRecordset("cc_fund", dao.RecordsetTypeEnum.dbOpenDynaset)
        '		tmp1set.FindFirst("b_num = " & Chr(34) & b_num & Chr(34))
        '		If tmp1set.NoMatch Then
        '			Stop
        '		End If
        '		Dim bill_flag As Short 'needed to see if pass autho test but no valid dates
        '		bill_flag = 0
        '		Do While present_day <=  end_date_tmp
        '			'write the attend record
        '			'check the autho and get the autho number
        '			autho.Recordset.MoveFirst()
        '			Do While Not autho.Recordset.EOF
        '				'turn off autho checking 12/99
        '				'  If present_day >= autho.Recordset.Fields("autho_beg") Then
        '				' If present_day <= autho.Recordset.Fields("autho_end") Then
        '				GoTo ok_to_bill
        '				'End If
        '				'End If
        '				autho.Recordset.MoveNext()
        '			Loop 
        '			GoTo not_autho
        'ok_to_bill: 
        '			bill_flag = 1
        ' Call BuildAttendRecord(BNum,present_day)
        '			attend_tmp.Recordset.Fields("autho_num") = autho.Recordset.Fields("autho_num")
        'not_autho: 
        '			present_day = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, present_day)
        '		Loop 
        '		If bill_flag = 0 Then MsgBox("Autho has expired for consumer = " & nam_addr.Recordset.Fields("screen_nam"))

    End Sub

    Public Sub create_Rec_Type_160(ByVal b_num As String)
        'this is lea billing
        selected_name_key = div_b_num(b_num).ToString()
        '         selected_contract_key = calculated in the function and left as a global variable

        present_day = start_fund_Date

        Do While present_day <= end_fund_Date
            Call BuildAttendRecord(b_num, present_day)        'write the attend record
            present_day = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, present_day)
        Loop
    End Sub

    Public Sub create_Rec_Type_161(ByVal b_num As String)
        'this is one amount billing for the month
        selected_name_key = div_b_num(b_num).ToString()
        '         selected_contract_key = calculated in the function and left as a global variable
        present_day = start_fund_Date
        'does first day only and attend rpt makes the rest i hope

        '  Do While present_day <= end_fund_Date
        Call BuildAttendRecord(b_num, present_day)        'write the attend record
        'present_day = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, present_day)
        'Loop
    End Sub

    Public Sub create_Rec_Type_170(ByVal b_num As String)
        'vocational billing items
        'this finds the contract num and name key from b_num
        '	Dim med_num As String
        '  Call div_b_num(b_num).ToString()
        '   sqlstmnt = "select * from medcc where name_key = " & Chr(34) & selected_name_key & Chr(34)
        '		medcc = medmdb.OpenRecordset(sqlstmnt)
        '		'check for the existence of a medicaid number if none then do not create records
        '		'but do thell them who does not have one
        '		If Len(Trim(base.Recordset.Fields("med_num") & "")) = 0 Then
        '			On Error Resume Next
        '			If Len(Trim(medcc.Fields("med_num").Value)) = 0 Then
        '				If Err.Number = 3021 Then
        '					MsgBox("There is no medcc record for name key =" & selected_name_key)
        '					Exit Sub
        '				End If
        '				MsgBox("There is no Medicaid Number for " & medcc.Fields("screen_nam").Value)
        '				Exit Sub
        '			Else
        '				med_num = Trim(medcc.Fields("med_num").Value)
        '			End If
        '			On Error GoTo 0
        '		Else
        '			med_num = Trim(base.Recordset.Fields("med_num"))
        '		End If
        '		present_day = start_fund_Date
        '		Do While present_day <= end_fund_Date
        '			'write the attend recordif the day of the week matches up

        'Select Case Weekday(present_day)
        '    Case 2 '"Monday"
        '        If BNumFundData.Item(0).Mon <> "Y" Then
        '            GoTo skip_attend
        '        End If
        '    Case 3 '"Tuesday"
        '        If BNumFundData.Item(0).Tue <> "Y" Then
        '            GoTo skip_attend
        '        End If
        '    Case 4 '"Wednesday"
        '        If BNumFundData.Item(0).Wed <> "Y" Then
        '            GoTo skip_attend
        '        End If
        '    Case 5 '"Thursday"
        '        If BNumFundData.Item(0).Thu <> "Y" Then
        '            GoTo skip_attend
        '        End If
        '    Case 6 '"Friday"
        '        If BNumFundData.Item(0).Fri <> "Y" Then
        '            GoTo skip_attend
        '        End If
        '    Case 7 '"Saturday"
        '        If BNumFundData.Item(0).Sat <> "Y" Then
        '            GoTo skip_attend
        '        End If
        '    Case 1 '"Sunday"
        '        If BNumFundData.Item(0).Sun <> "Y" Then
        '            GoTo skip_attend
        '        End If
        'End Select
        'Call BuildAttendRecord(b_num,present_day)
        '			medopn_tmp.AddNew()
        '			medopn_tmp.Fields("from_Date").Value = present_day
        '			medopn_tmp.Fields("to_Date").Value = present_day
        '			medopn_tmp.Fields("att_units").Value = cc_fund.Recordset(21) '.Fields("att_unit")
        '			medopn_tmp.Fields("contract_key").Value = cc_fund.Recordset(4)
        '			For num = 0 To 23
        '				medopn_tmp.Fields(num + 4).Value = medcc.Fields(num + 3).Value
        '			Next 
        '			'use the proc code from medcc or att units which are x
        '			'write below if working with b170 records
        '			medopn_tmp.Fields("proc_code").Value = cc_fund.Recordset(20) '.Fields("att_code")
        '			Call chk_Proc_code(medopn_tmp.Fields("proc_code"), medopn_tmp.Fields("from_Date"))
        '			medopn_tmp.Fields("proc_desc").Value = selected_proc_desc
        '			medopn_tmp.Fields("usual_fee").Value = selected_proc_fee
        '			medopn_tmp.Fields("proc_num").Value = contract.Recordset("pros_num_med")
        '			medopn_tmp.Fields("prov_num").Value = contract.Recordset("prov_num_med")
        '			'        rpthead.Recordset.Fields("beg_num") = contract.Recordset("pros_num_med")
        '			temp_proc_num = contract.Recordset("pros_num_med")
        '			medopn_tmp.Fields("place_serv").Value = contract.Recordset("place_service")
        '			medopn_tmp.Fields("dr_acct_nu").Value = contract.Recordset("dr_acct_nu")
        '			medopn_tmp.Fields("cr_acct_nu").Value = contract.Recordset("cr_acct_nu")
        '			medopn_tmp.Fields("sex").Value = base.Recordset.Fields("sex")
        '			medopn_tmp.Fields("dob").Value = base.Recordset.Fields("dob")
        '			medopn_tmp.Fields("med_num").Value = med_num 'base.Recordset("med_num")
        '			medopn_tmp.Fields("pacct_num").Value = medopn_tmp.Fields("name_key").Value
        '			medopn_tmp.Fields("dol_billed").Value = medopn_tmp.Fields("att_units").Value * medopn_tmp.Fields("usual_Fee").Value
        '			medopn_tmp.Fields("dol_net_bill").Value = selected_proc_dol_actual * medopn_tmp.Fields("att_units").Value
        '			'add more fields here as needed
        '			medopn_tmp.Update()
        'skip_attend: 
        '			present_day = DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, present_day)
        '		Loop 
        '		'present_day =  Start_date

    End Sub

    Public Sub create_rec_type()

        Select Case selected_grouping

            Case "PROGRAM"
                'create the temp file for this bill type

                sqlstmnt = "select * from cc_fund LEFT JOIN cc_cont ON cc_fund.contract_key = cc_cont.contract_key where cc_cont.bill_type = '" & selected_bill_type
                sqlstmnt = sqlstmnt & "' and cc_fund.beg_Date <= '" & End_Date.Text '
                sqlstmnt = sqlstmnt & "' and cc_fund.end_date >= '" & start_date.Text & "'"

                If CheckRecordCount(sqlstmnt) = 0 Then
                    MsgBox("No records to be created of the selected type")
                    Exit Sub
                Else
                    recs = recs + CheckRecordCount(sqlstmnt)
                End If
                Using db As Database = New Database(top_data_path)
                    Dim sql As String = sqlstmnt
                    Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                    While rs.Read()
                        Call set_Fund_range(CDate(rs("beg_date").ToString), CDate(rs("end_Date").ToString))
                        selected_contract_key = rs("contract_key").ToString
                        If CheckIfBilled(rs("b_num").ToString) = "N" Then
                            Select Case selected_bill_type
                                Case CStr(100)
                                    Call create_Rec_Type_100(rs("b_num").ToString)
                                Case CStr(120)
                                    Call create_Rec_Type_120(rs("b_num").ToString)
                                Case CStr(125)
                                    Call create_Rec_Type_125(rs("b_num").ToString)
                                Case CStr(140)
                                    Call create_Rec_Type_140(rs("b_num").ToString)
                                Case CStr(160)
                                    Call create_Rec_Type_160(rs("b_num").ToString)
                                Case CStr(170)
                                    Call create_Rec_Type_170(rs("b_num").ToString)
                            End Select
                        Else
                            'nobilled
                        End If
                    End While
                    rs.Close()
                End Using
        
            Case "CLIENT"
                If function_type <> "SPEC_BILL" Then
                    'find cc_Fund that has a the client and
                    'the begin date of funding is before the ending date
                    'and the end date of funding is after the begining date
                    sqlstmnt = " select * from cc_fund where name_key = '" & selected_name_key
                    sqlstmnt = sqlstmnt & "' and beg_Date <= '" & End_Date.Text
                    sqlstmnt = sqlstmnt & "' and end_Date >= '" & start_date.Text & "'"
                End If
                If CheckRecordCount(sqlstmnt) = 0 Then
                    MsgBox("No records to be created of the selected type")
                    Exit Sub
                Else
                    recs = recs + CheckRecordCount(sqlstmnt)
                End If
                Using db As Database = New Database(top_data_path)
                    Dim sql As String = sqlstmnt
                    Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                    While rs.Read()
                        Call set_Fund_range(CDate(rs("beg_date").ToString), CDate(rs("end_Date").ToString))
                        selected_bill_type = ETSCommon.GetDatum("cc_cont", "contract_key", rs("contract_key").ToString, "bill_type")
                        selected_contract_key = rs("contract_key").ToString
                        If CheckIfBilled(rs("b_num").ToString) = "N" Then
                            Select Case selected_bill_type
                                Case CStr(100)
                                    Call create_Rec_Type_100(rs("b_num").ToString)
                                Case CStr(120)
                                    Call create_Rec_Type_120(rs("b_num").ToString)
                                Case CStr(125)
                                    Call create_Rec_Type_125(rs("b_num").ToString)
                                Case CStr(140)
                                    Call create_Rec_Type_140(rs("b_num").ToString)
                                Case CStr(160)
                                    Call create_Rec_Type_160(rs("b_num").ToString)
                                Case CStr(170)
                                    If med_flag = "N" Then Exit Sub
                                    Call create_Rec_Type_170(rs("b_num").ToString)
                                Case Else
                                    MsgBox("This person has a funding record that refers to a contract with an invalid bill type.")
                            End Select
                        End If
                    End While
                    rs.Close()
                End Using

            Case "CONTRACT"

                'assumes that the contract is active since on the list
                sqlstmnt = " select * from cc_fund where contract_key = '" & selected_contract_key
                sqlstmnt = sqlstmnt & "' and beg_Date <= '" & End_Date.Text
                sqlstmnt = sqlstmnt & "' and end_Date >= '" & start_date.Text & "'"
                If CheckRecordCount(sqlstmnt) = 0 Then
                    MsgBox("No records to be created of the selected type")
                    Response = MsgBox("Do you wish to make contract inactive?", MsgBoxStyle.YesNo)
                    If Response = vbYes Then
                        ChangeActiveLevelContract(selected_contract_key, "N")
                    End If
                    Exit Sub
                Else
                    recs = recs + CheckRecordCount(sqlstmnt)
                End If

                Using db As Database = New Database(top_data_path)
                    Dim sql As String = sqlstmnt
                    Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                    While rs.Read()
                        Call set_Fund_range(CDate(rs("beg_date").ToString), CDate(rs("end_Date").ToString))
                        selected_bill_type = ETSCommon.GetDatum("cc_cont", "contract_key", rs("contract_key").ToString, "bill_type")
                        If CheckIfBilled(rs("b_num").ToString) = "N" Then
                            Select Case selected_bill_type
                                Case CStr(100)
                                    Call create_Rec_Type_100(rs("b_num").ToString)
                                Case CStr(120)
                                    Call create_Rec_Type_120(rs("b_num").ToString)
                                Case CStr(125)
                                    Call create_Rec_Type_125(rs("b_num").ToString)
                                Case CStr(140)
                                    Call create_Rec_Type_140(rs("b_num").ToString)
                                Case CStr(160)
                                    Call create_Rec_Type_160(rs("b_num").ToString)
                                Case CStr(170)
                                    If med_flag = "N" Then Exit Sub
                                    Call create_Rec_Type_170(rs("b_num").ToString)
                                Case Else
                                    MsgBox("This person has a funding record that refers to a contract with an invalid bill type.")
                            End Select
                        End If
                    End While
                    rs.Close()
                End Using

        End Select

    End Sub
    Private Sub set_Fund_range(ByVal BegDate As Date, ByVal EndDate As Date)
        Dim temp_beg As Date
        Dim temp_end As Date
        temp_beg = BegDate
        If DateDiff(Microsoft.VisualBasic.DateInterval.Day, temp_beg, CDate(start_date.Text)) < 0 Then
            start_fund_Date = temp_beg
        Else
            start_fund_Date = CDate(start_date.Text)
        End If

        temp_end = EndDate
        If DateDiff(Microsoft.VisualBasic.DateInterval.Day, temp_end, CDate(End_Date.Text)) > 0 Then
            end_fund_Date = temp_end
        Else
            end_fund_Date = CDate(End_Date.Text)
        End If


    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item(0, e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub create_attend_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        '  DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridView2.AutoResizeColumns()
        DataGridView2.RowHeadersVisible = False
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Dim HeaderDates As String() = ETSCommon.GetBeginEndDates.Split(CChar("*"))
        start_date.Text = HeaderDates(0)
        End_Date.Text = HeaderDates(1)

        '   Call med_open()

        Me.Text = Me.Text & "   " & agency_name

    End Sub

    Private Sub RebuildList()

        Cursor.Current = Cursors.WaitCursor

        'get dates for filling form
        Dim HeaderDates As String() = ETSCommon.GetBeginEndDates.Split(CChar("*"))
        start_date.Text = HeaderDates(0)
        End_Date.Text = HeaderDates(1)
        'get billable list from cc fund
        sqlstmnt = "select * from cc_fund where cc_fund.beg_date <= '" & End_Date.Text & "' and cc_fund.end_date >= '" & start_date.Text & "'"

        Billable = ETSSQL.GetBillableList(sqlstmnt)

        'get billed from hist and temp

        sqlstmnt = " SELECT DISTINCT  attend_hist.b_num, attend_hist.name_key, attend_hist.contract_key, attend_hist.bill_type FROM   attend_hist WHERE     (attend_hist.att_date BETWEEN "
        sqlstmnt = sqlstmnt & "'" & start_date.Text & "' and '" & End_Date.Text & "') and (void = 'N')"
        sqlstmnt = sqlstmnt & " UNION SELECT DISTINCT  attend_tmp.b_num,  attend_tmp.name_key,  attend_tmp.contract_key,  attend_tmp.bill_type FROM   attend_tmp  WHERE     (attend_tmp.att_date BETWEEN "
        sqlstmnt = sqlstmnt & "'" & start_date.Text & "' and '" & End_Date.Text & "') and void = 'N'"

        Billed = ETSSQL.GetBilledList(sqlstmnt)
        'put billed flag into billable
        For Each bill In Billed
            ToFind = bill.BNum
            Dim result As Billable = Billable.Find(AddressOf FindBNum)
            If result IsNot Nothing Then
                result.Billed = "Y"
            End If
        Next
        Cursor.Current = Cursors.Default

    End Sub

    Private Function FindBNum(ByVal bnum As Billable) As Boolean
        ' Private Function FindID(ByVal bk As Book) As Boolean
        If bnum.BNum = ToFind Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub end_Date1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Date.Enter
        Call ets_set_selected()
    End Sub

    Private Sub end_Date1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles End_Date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = End_Date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")

            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                End_Date.Text = CDate(retdate).ToShortDateString
                selected_end_date = CDate(retdate)
            End If

            If DateDiff(DateInterval.Day, CDate(start_date.Text), CDate(End_Date.Text)) < 0 Then
                MsgBox("Invalid date range")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0

        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub end_Date1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Date.Leave
        End_Date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub Start_date1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date.Enter
        Call ets_set_selected()
        'selected_start_date = CDate( start_date1.Text)
    End Sub

    Private Sub Start_date1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles start_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Then
            senddate = start_date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")
            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                selected_start_date = CDate(retdate)
                start_date.Text = CDate(retdate).ToShortDateString
            End If

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0

        End If


EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub Start_date1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date.Leave
        start_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub Process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Click
        recs = 0
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If Len(start_date.Text) = 0 Then
            MsgBox("You need to enter a start date.")
            start_date.Focus()
            Exit Sub
        End If

        If Len(End_Date.Text) = 0 Then
            MsgBox("You need to enter an end date.")
            End_Date.Focus()
            Exit Sub
        End If

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub

        End If

        If by_bill_type.Checked Then
            selected_grouping = "PROGRAM"
            selected_bill_type = selected_lookup_num
            MsgBox("start time = " & CStr(TimeOfDay))
            Call create_rec_type()
            MsgBox("stop time = " & CStr(TimeOfDay))

        End If

        If by_contract.Checked Then
            selected_grouping = "CONTRACT"
            selected_contract_key = selected_lookup_num
            Call create_rec_type()
        End If

        If by_Client.Checked Then
            selected_grouping = "CLIENT"
            selected_name_key = selected_lookup_num
            Call create_rec_type()
        End If

        ClearGrids()
        System.Windows.Forms.Cursor.Current = Cursors.Default

        MsgBox("There were " & recs & " records created.")

    End Sub

    Private Sub Ref_list_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Ref_list.Click

        If Len(start_date.Text) = 0 Then
            MsgBox("You need to enter a start date.")
            start_date.Focus()
            Exit Sub
        End If

        If Len(End_Date.Text) = 0 Then
            MsgBox("You need to enter an end date.")
            End_Date.Focus()
            Exit Sub
        End If
        'put dates in rpthead
        sqlstmnt = "update rpthead set beg_date = '" & start_date.Text & "', end_date = ' " & End_Date.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        'clear the grids
        DataGridView1.Columns.Clear()
        DataGridView2.Columns.Clear()

        Call RebuildList()
        'end from load

        Dim billc As New List(Of BillableContract)
        Dim billcl As New List(Of BillableClient)
        For Each bill In Billable
            Dim bc As New BillableContract
            bc.BegDate = bill.BegDate
            bc.Billed = bill.Billed
            bc.BillType = bill.BillType
            bc.BNum = bill.BNum
            bc.ContractKey = bill.ContractKey
            bc.EndDate = bill.EndDate
            bc.NameKey = bill.NameKey
            billc.Add(bc)
            Dim bcl As New BillableClient
            bcl.BegDate = bill.BegDate
            bcl.Billed = bill.Billed
            bcl.BillType = bill.BillType
            bcl.BNum = bill.BNum
            bcl.ContractKey = bill.ContractKey
            bcl.EndDate = bill.EndDate
            bcl.NameKey = bill.NameKey
            billcl.Add(bcl)
        Next

        If by_bill_type.Checked Then

            DataGridView1.Columns.Add("bill_type", "Bill Type")
            DataGridView1.Columns.Item(0).DataPropertyName = "bill_type"
            DataGridView1.Columns.Add("prgm_type", "Program")
            DataGridView1.Columns.Item(1).DataPropertyName = "prgm_type"
            DataGridView2.Columns.Add("bill_type", "Bill Type")
            DataGridView2.Columns.Item(0).DataPropertyName = "bill_type"
            DataGridView2.Columns.Add("prgm_type", "Program")
            DataGridView2.Columns.Item(1).DataPropertyName = "prgm_type"

            Dim nodupes = Billable.Distinct
            For Each bill In nodupes
                Dim DistinctType As String = bill.BillType
                Dim results As List(Of Billable)
                results = Billable.FindAll(Function(column) column.BillType = DistinctType AndAlso column.Billed = "N")
                If results.Count <> 0 Then
                    DataGridView1.Rows.Add(New String() {bill.BillType.ToString, ETSSQL.GetOneSQLValue("select datum_desc as thevalue from reference where datum = '" & bill.BillType & "'")})
                End If
                results = Billable.FindAll(Function(column) column.BillType = DistinctType AndAlso column.Billed = "Y")
                If results.Count <> 0 Then
                    DataGridView2.Rows.Add(New String() {bill.BillType.ToString, ETSSQL.GetOneSQLValue("select datum_desc as thevalue from reference where datum = '" & bill.BillType & "'")})
                End If


                '    If bill.Billed = "N" Then
                '        DataGridView1.Rows.Add(New String() {bill.BillType.ToString, ETSSQL.GetOneSQLValue("select datum_desc as thevalue from reference where datum = '" & bill.BillType & "'")})
                '    Else
                '        DataGridView2.Rows.Add(New String() {bill.BillType.ToString, ETSSQL.GetOneSQLValue("select datum_desc as thevalue from reference where datum = '" & bill.BillType & "'")})
                '    End If
            Next

            DataGridView1.Sort(DataGridView1.Columns("bill_type"), ComponentModel.ListSortDirection.Ascending)

            DataGridView2.Sort(DataGridView2.Columns("bill_type"), ComponentModel.ListSortDirection.Ascending)

        End If

        If by_contract.Checked Then

            DataGridView1.Columns.Add("Contract_key", "Contract")
            DataGridView1.Columns.Item(0).DataPropertyName = "Contract_key"
            DataGridView1.Columns.Add("cont_desc", "Description")
            DataGridView1.Columns.Item(1).DataPropertyName = "cont_desc"
            DataGridView1.Columns.Add("bill_type", "Bill Type")
            DataGridView1.Columns.Item(2).DataPropertyName = "bill_type"

            DataGridView2.Columns.Add("Contract_key", "Contract")
            DataGridView2.Columns.Item(0).DataPropertyName = "Contract_key"
            DataGridView2.Columns.Add("cont_desc", "Description")
            DataGridView2.Columns.Item(1).DataPropertyName = "cont_desc"
            DataGridView2.Columns.Add("bill_type", "Bill Type")
            DataGridView2.Columns.Item(2).DataPropertyName = "bill_type"


            Dim nodupe = billc.Distinct
            For Each bill In nodupe
                Dim OneDesc As String
                OneDesc = ETSSQL.GetOneSQLValue("select cont_Desc as thevalue from cc_Cont where contract_key = '" & bill.ContractKey & "'")
                If bill.Billed = "N" Then
                    DataGridView1.Rows.Add(New String() {bill.ContractKey.ToString, OneDesc.ToString, bill.BillType.ToString})
                Else
                    DataGridView2.Rows.Add(New String() {bill.ContractKey.ToString, OneDesc.ToString, bill.BillType.ToString})
                End If
            Next
            DataGridView1.Sort(DataGridView1.Columns("contract_key"), ComponentModel.ListSortDirection.Ascending)
            DataGridView2.Sort(DataGridView2.Columns("contract_key"), ComponentModel.ListSortDirection.Ascending)
        End If

        If by_Client.Checked Then

            DataGridView1.Columns.Add("name_key", "Name Key")
            DataGridView1.Columns.Item(0).DataPropertyName = "name_key"
            DataGridView1.Columns.Add("sort_name", "Name")
            DataGridView1.Columns.Item(1).DataPropertyName = "sort_name"

            DataGridView2.Columns.Add("name_key", "Name Key")
            DataGridView2.Columns.Item(0).DataPropertyName = "name_key"
            DataGridView2.Columns.Add("sort_name", "Name")
            DataGridView2.Columns.Item(1).DataPropertyName = "sort_name"

            Dim nodupeclients = billcl.Distinct
            For Each bill In nodupeclients
                If bill.Billed = "N" Then
                    DataGridView1.Rows.Add(New String() {bill.NameKey.ToString, ETSSQL.GetOneSQLValue("select sort_name as thevalue from nam_addr where name_key = '" & bill.NameKey & "'")})
                Else
                    DataGridView2.Rows.Add(New String() {bill.NameKey.ToString, ETSSQL.GetOneSQLValue("select sort_name as thevalue from nam_addr where name_key = '" & bill.NameKey & "'")})
                End If
            Next
            DataGridView1.Sort(DataGridView1.Columns("sort_name"), ComponentModel.ListSortDirection.Ascending)
            'billed - grid 2
            For Each bill In Billed
            Next
            DataGridView2.Sort(DataGridView2.Columns("sort_name"), ComponentModel.ListSortDirection.Ascending)

        End If
        On Error Resume Next
        DataGridView1.Rows(0).Selected = False
        DataGridView2.Rows(0).Selected = False
        Cursor.Current = Cursors.Default
        On Error GoTo 0

        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing
        DataGridView2.ClearSelection()
        DataGridView2.CurrentCell = Nothing

    End Sub

    Private Sub spec_bill_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles spec_bill.Click
        'this allows the billing of clients without regard to whether they have been billed
        'password protected
        'goes to cc fund to get the right bnum
        'then control goes to process client with one record
        'billing is done for range of dates at top

        If Not by_Client.Checked Then
            MsgBox("Client must be selection")
            Exit Sub
        End If

        singl = ""

        'frmpwd_inp.Show 1

        If singl <> "DIB" Then
            singl = "N"
            MsgBox("Invalid Password")
            Exit Sub
        End If


        selected_grouping = "CLIENT"
        saved_function_Type = function_type
        function_type = "SPEC_BILL"
        fundnumlookup.ShowDialog()

        sqlstmnt = "select  * from cc_fund where b_num = '" & selected_b_num & "'"
        Call create_rec_type()


        MsgBox("Special Records Created.")
        function_type = saved_function_Type

    End Sub

    Private Sub ClearGrids()
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
    End Sub

    Private Sub by_bill_type_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles by_bill_type.CheckedChanged
        ClearGrids()
    End Sub

    Private Sub by_contract_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles by_contract.CheckedChanged
        ClearGrids()
    End Sub

    Private Sub by_Client_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles by_Client.CheckedChanged
        ClearGrids()
    End Sub

    Private Sub CmdClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClose.Click
        ClearGrids()
    End Sub

    Private Sub OldCodeRefrest()
        If by_bill_type.Checked Then
            '1 - get list of bill types and their name
            '2 - put all in list 1
            '3 - get billed ones and remove list 1 and add to list 2

            DataGridView1.Columns.Add("bill_type", "Bill Type")
            DataGridView1.Columns.Item(0).DataPropertyName = "bill_type"
            DataGridView1.Columns.Add("prgm_type", "Program")
            DataGridView1.Columns.Item(1).DataPropertyName = "prgm_type"
            DataGridView2.Columns.Add("bill_type", "Bill Type")
            DataGridView2.Columns.Item(0).DataPropertyName = "bill_type"
            DataGridView2.Columns.Add("prgm_type", "Program")
            DataGridView2.Columns.Item(1).DataPropertyName = "prgm_type"

            Dim refs As New List(Of RefData)
            refs = ETSSQL.GetRefData("ATT", "create_attend")
            For Each ref In refs
                If ref.ControlName = "list1" Then
                    DataGridView1.Rows.Add(New String() {ref.Datum, ref.DatumDesc})
                End If
            Next
            DataGridView1.Sort(DataGridView1.Columns("bill_type"), ComponentModel.ListSortDirection.Ascending)
            ' check history file and then attend to see if any billing done

            sqlstmnt = " Select distinct bill_type from"
            sqlstmnt = sqlstmnt & "   (SELECT DISTINCT  attend_hist.b_num, cc_cont.* FROM   attend_hist INNER JOIN"
            sqlstmnt = sqlstmnt & " cc_cont ON attend_hist.contract_key = cc_cont.contract_key  WHERE     (attend_hist.att_date BETWEEN "
            sqlstmnt = sqlstmnt & "'" & start_date.Text & "' and '" & End_Date.Text & "') and (void = 'N')"
            sqlstmnt = sqlstmnt & " UNION SELECT DISTINCT  attend_tmp.b_num, cc_cont_1.* FROM   attend_tmp INNER JOIN"
            sqlstmnt = sqlstmnt & " cc_cont AS cc_cont_1 ON attend_tmp.contract_key = cc_cont_1.contract_key  WHERE     (attend_tmp.att_date BETWEEN "
            sqlstmnt = sqlstmnt & "'" & start_date.Text & "' and '" & End_Date.Text & "') and void = 'N') as derivedtbl_1 order by bill_type"

            'the tested sql statement
            ' Select distinct bill_type from
            '   (SELECT DISTINCT  attend_hist.b_num,  cc_cont.* FROM   attend_hist INNER JOIN
            ' cc_cont ON attend_hist.contract_key = cc_cont.contract_key  WHERE     (attend_hist.att_date BETWEEN 
            '' 1 / 1 / 2009 ' and ' 12 / 1 / 2009') and (void = 'N')
            ' UNION SELECT DISTINCT  attend_tmp.b_num, cc_cont_1.* FROM   attend_tmp INNER JOIN
            ' cc_cont AS cc_cont_1 ON attend_tmp.contract_key = cc_cont_1.contract_key  WHERE     (attend_tmp.att_date BETWEEN 
            '' 1 / 1 / 2009 ' and ' 12 / 1 / 2009 ') and (void = 'N')) as derivedtbl_1 order by bill_type

            'these bill types go on gridview2 
            '        sqlstmnt = " select distinct cc_fund.bill_key FROM cc_fund LEFT JOIN attend_rpt ON cc_fund.name_key = attend_rpt.name_key"
            'WHERE attend_rpt.name_key IS NULL and cc_fund.closed = 'N' order by cc_fund.sort_name



            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                While rs.Read()
                    'find in grid1 and write to grid2
                    Dim intcount As Integer = 0
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        If String.Compare(CStr(DataGridView1.Rows(intcount).Cells(0).Value), CStr(rs("bill_type"))) = 0 Then
                            DataGridView2.Rows.Add(New String() {DataGridView1.Rows(intcount).Cells(0).Value.ToString, DataGridView1.Rows(intcount).Cells(1).Value.ToString})
                            DataGridView1.Rows.RemoveAt(intcount)
                            If rs.Read() = True Then
                                intcount = 0
                            Else
                                Continue While
                            End If
                        End If
                        intcount = intcount + 1
                    Next
                End While
                rs.Close()
            End Using

            'now to find out about 170 medicaid
            If med_flag = "Y" Then
                '	tmp1db = DAODBEngine_definst.OpenDatabase(am_data_path & "med.mdb")

                sqlstmnt = " SELECT DISTINCT medopn_tmp.name_key from medopn_tmp  "
                sqlstmnt = sqlstmnt & "WHERE (((medopn_tmp.from_date) Between " & Chr(35) & start_date.Text & Chr(35)
                sqlstmnt = sqlstmnt & " and " & Chr(35) & End_Date.Text & Chr(35)
                sqlstmnt = sqlstmnt & ")) UNION SELECT DISTINCT medopn_hist.name_key from medopn_hist "
                sqlstmnt = sqlstmnt & " WHERE (((medopn_hist.from_date) Between " & Chr(35) & start_date.Text & Chr(35)
                sqlstmnt = sqlstmnt & " and " & Chr(35) & End_Date.Text & Chr(35) & "))"
                sqlstmnt = sqlstmnt & " and void = 'N' "

            End If
        End If

        If by_contract.Checked Then

            DataGridView1.Columns.Add("Contract_key", "Contract")
            DataGridView1.Columns.Item(0).DataPropertyName = "Contract_key"
            DataGridView1.Columns.Add("cont_desc", "Description")
            DataGridView1.Columns.Item(1).DataPropertyName = "cont_desc"
            DataGridView1.Columns.Add("redpy_dol", "Ready Pay")
            DataGridView1.Columns.Item(2).DataPropertyName = "redpy_dol"
            DataGridView1.Columns.Add("bill_type", "Bill Type")
            DataGridView1.Columns.Item(3).DataPropertyName = "bill_type"

            DataGridView2.Columns.Add("Contract_key", "Contract")
            DataGridView2.Columns.Item(0).DataPropertyName = "Contract_key"
            DataGridView2.Columns.Add("cont_desc", "Description")
            DataGridView2.Columns.Item(1).DataPropertyName = "cont_desc"


            sqlstmnt = "select * from cc_cont where cont_end_d > '" & End_Date.Text
            sqlstmnt = sqlstmnt & "' and (bill_type) >= 100  and active = 'Y' order by contract_key"

            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                Dim redpy As String
                While rs.Read()
                    If Val(rs("redpy_dol").ToString) <> 0 Then redpy = "Y" Else redpy = "N"
                    DataGridView1.Rows.Add(New String() {rs("contract_key").ToString, rs("cont_desc").ToString, redpy, rs("bill_type").ToString})
                End While
                rs.Close()
            End Using



            sqlstmnt = " Select distinct contract_key from"
            sqlstmnt = sqlstmnt & "   (SELECT DISTINCT  attend_hist.b_num, cc_cont.* FROM   attend_hist INNER JOIN"
            sqlstmnt = sqlstmnt & " cc_cont ON attend_hist.contract_key = cc_cont.contract_key  WHERE     (attend_hist.att_date BETWEEN "
            sqlstmnt = sqlstmnt & "'" & start_date.Text & "' and '" & End_Date.Text & "') and (cc_Cont.active = 'Y')"
            sqlstmnt = sqlstmnt & " UNION SELECT DISTINCT  attend_tmp.b_num, cc_cont_1.* FROM   attend_tmp INNER JOIN"
            sqlstmnt = sqlstmnt & " cc_cont AS cc_cont_1 ON attend_tmp.contract_key = cc_cont_1.contract_key  WHERE     (attend_tmp.att_date BETWEEN "
            sqlstmnt = sqlstmnt & "'" & start_date.Text & "' and '" & End_Date.Text & "') and cc_Cont_1.active = 'Y') as derivedtbl_1 order by contract_key"

            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                While rs.Read()
                    'find in grid1 and write to grid2
                    Dim intcount As Integer = 0
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        If String.Compare(CStr(DataGridView1.Rows(intcount).Cells(0).Value), CStr(rs("contract_key"))) = 0 Then
                            DataGridView2.Rows.Add(New String() {DataGridView1.Rows(intcount).Cells(0).Value.ToString, DataGridView1.Rows(intcount).Cells(1).Value.ToString})
                            DataGridView1.Rows.RemoveAt(intcount)
                            If rs.Read() = True Then
                                intcount = 0
                            Else
                                Continue While
                            End If
                        End If
                        intcount = intcount + 1
                    Next
                End While
                rs.Close()
            End Using

            '	If med_flag = "Y" Then
            '		tmp1db = DAODBEngine_definst.OpenDatabase(am_data_path & "med.mdb")

            '		sqlstmnt = " SELECT DISTINCT medopn_tmp.contract_key from medopn_tmp  "
            '		sqlstmnt = sqlstmnt & "WHERE (((medopn_tmp.from_date) Between " & Chr(35) &  start_date1.Text & Chr(35)
            '		sqlstmnt = sqlstmnt & " and " & Chr(35) &  End_Date1.Text & Chr(35)
            '		sqlstmnt = sqlstmnt & ")) UNION SELECT DISTINCT medopn_hist.contract_key from medopn_hist "
            '		sqlstmnt = sqlstmnt & " WHERE (((medopn_hist.from_date) Between " & Chr(35) &  start_date1.Text & Chr(35)
            '		sqlstmnt = sqlstmnt & " and " & Chr(35) &  End_Date1.Text & Chr(35) & "))"
            '		sqlstmnt = sqlstmnt & " and void = 'N' "

            '	End If


        End If

        If by_Client.Checked Then

            DataGridView1.Columns.Add("name_key", "Name Key")
            DataGridView1.Columns.Item(0).DataPropertyName = "name_key"
            DataGridView1.Columns.Add("sort_name", "Name")
            DataGridView1.Columns.Item(1).DataPropertyName = "sort_name"

            DataGridView2.Columns.Add("name_key", "Name Key")
            DataGridView2.Columns.Item(0).DataPropertyName = "name_key"
            DataGridView2.Columns.Add("sort_name", "Name")
            DataGridView2.Columns.Item(1).DataPropertyName = "sort_name"


            sqlstmnt = "select distinct name_key, sort_name from cc_fund where beg_Date <= '" & End_Date.Text & "' and end_Date >= '" & start_date.Text & "' order by sort_name"
            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                While rs.Read()
                    DataGridView1.Rows.Add(New String() {rs("name_key").ToString, rs("sort_name").ToString})
                End While
                rs.Close()
            End Using

            sqlstmnt = " Select distinct b_num, sort_name from"
            sqlstmnt = sqlstmnt & "   (SELECT DISTINCT  attend_hist.b_num, attend_hist.sort_name, cc_cont.* FROM   attend_hist INNER JOIN"
            sqlstmnt = sqlstmnt & " cc_cont ON attend_hist.contract_key = cc_cont.contract_key  WHERE     (attend_hist.att_date BETWEEN "
            sqlstmnt = sqlstmnt & "'" & start_date.Text & "' and '" & End_Date.Text & "') and (cc_Cont.active = 'Y')"
            sqlstmnt = sqlstmnt & " UNION SELECT DISTINCT  attend_tmp.b_num, attend_tmp.sort_name, cc_cont_1.* FROM   attend_tmp INNER JOIN"
            sqlstmnt = sqlstmnt & " cc_cont AS cc_cont_1 ON attend_tmp.contract_key = cc_cont_1.contract_key  WHERE     (attend_tmp.att_date BETWEEN "
            sqlstmnt = sqlstmnt & "'" & start_date.Text & "' and '" & End_Date.Text & "') and cc_Cont_1.active = 'Y') as derivedtbl_1 order by sort_name"

            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                Dim NKEy As String
                While rs.Read()
                    'find in grid1 and write to grid2
                    Dim intcount As Integer = 0
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        NKEy = div_b_num(rs("b_num").ToString)
                        If String.Compare(CStr(DataGridView1.Rows(intcount).Cells(0).Value), NKEy) = 0 Then
                            DataGridView2.Rows.Add(New String() {DataGridView1.Rows(intcount).Cells(0).Value.ToString, DataGridView1.Rows(intcount).Cells(1).Value.ToString})
                            DataGridView1.Rows.RemoveAt(intcount)
                            If rs.Read() = True Then
                                intcount = -1
                            Else
                                Continue While
                            End If
                        End If
                        intcount = intcount + 1
                    Next
                End While
                rs.Close()
            End Using

            '	'we now create the list of billed in medicaid to be used when we go thru ccbase
            '	r_Count = 0
            '	If med_flag = "Y" Then
            '		tmp1db = DAODBEngine_definst.OpenDatabase(am_data_path & "med.mdb")

            '		sqlstmnt = " SELECT DISTINCT medopn_tmp.name_key from medopn_tmp  "
            '		sqlstmnt = sqlstmnt & "WHERE (((medopn_tmp.from_date) Between " & Chr(35) &  start_date1.Text & Chr(35)
            '		sqlstmnt = sqlstmnt & " and " & Chr(35) &  End_Date1.Text & Chr(35)
            '		sqlstmnt = sqlstmnt & ")) UNION SELECT DISTINCT medopn_hist.name_key from medopn_hist "
            '		sqlstmnt = sqlstmnt & " WHERE (((medopn_hist.from_date) Between " & Chr(35) &  start_date1.Text & Chr(35)
            '		sqlstmnt = sqlstmnt & " and " & Chr(35) &  End_Date1.Text & Chr(35) & "))"
            '		sqlstmnt = sqlstmnt & " and void = 'N' "
            '	End If

            spec_bill.Enabled = True
        End If
    End Sub

    Public Sub Get125DailyUnits(ByVal present_day As Date)

        Select Case Weekday(present_day)
            Case 2 '"Monday"
                att_temp_unit = Val(BNumFundData.Item(0).Mon)
            Case 3 '"Tuesday"
                att_temp_unit = Val(BNumFundData.Item(0).Tue)
            Case 4 '"Wednesday"
                att_temp_unit = Val(BNumFundData.Item(0).Wed)
            Case 5 '"Thursday"
                att_temp_unit = Val(BNumFundData.Item(0).Thu)
            Case 6 '"Friday"
                att_temp_unit = Val(BNumFundData.Item(0).Fri)
            Case 7 '"Saturday"
                att_temp_unit = Val(BNumFundData.Item(0).Sat)
            Case 1 '"Sunday"
                att_temp_unit = Val(BNumFundData.Item(0).Sun)
        End Select
    End Sub
End Class