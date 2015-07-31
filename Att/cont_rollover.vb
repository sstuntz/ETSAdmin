Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System
Imports System.Text
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient

Public Class cont_rollover
    Inherits System.Windows.Forms.Form

    Public old_selected_contract_key As String
    Public new_cont_id_num As String
    Public prog As String

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_contract_key = DataGridView1.Item("contract_key", e.RowIndex).Value.ToString
            old_selected_contract_key = selected_contract_key
            selected_cont_id_num = DataGridView1.Item("cont_id_num", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub

    Public Sub fund_rollover()

        'check if rolled over 
        sqlstmnt = "select * from cc_fund where contract_key = '" & selected_contract_key & "'"
        If ETSCommon.CheckNumRecords(sqlstmnt) > 0 Then
            MsgBox("Funding sources have been rolled over.")
            Exit Sub
        End If

        sqlstmnt = "select * from cc_fund where contract_key = '" & old_selected_contract_key & "'"
        Dim NewFunding As New List(Of FundingData)
        NewFunding = ETSSQL.GetFundData(sqlstmnt)
     
        Dim NewContract As New ContractData
        sqlstmnt = "select * from cc_cont where contract_key = '" & selected_contract_key & "'"
        NewContract = ETSSQL.GetOneContractData(sqlstmnt)

        For Each NewOne In NewFunding
            NewOne.ContractKey = selected_contract_key
            selected_name_key = NewOne.NameKey
            NewOne.BNum = NewOne.NameKey & NewOne.ContractKey
            NewOne.EntryDate = Today
            NewOne.BillDate = CDate("1/1/1901")
            NewOne.Closed = "N"
            NewOne.ClientTotal = 0
            NewOne.Dflag = "N"
            NewOne.Active = "Y"
            NewOne.ContIdNum = NewContract.ContIdNum
            NewOne.AmendNum = NewContract.AmendNum
            NewOne.MmarsNum = NewContract.MmarsNum
            NewOne.BegDate = NewContract.ContBegD
            NewOne.EndDate = NewContract.ContEndD
            '  NewOne.UnitRate = NewContract.UnitRate

            '  get the new rate
            ' take the old unit rate and divide by old prog rate.  Apply this to new prog rate to get new unit rate
            Dim OldRate As Double
            OldRate = CDbl(ETSSQL.GetOneSQLValue("select prog_rate as TheValue from program where prog_num = '" & NewOne.ProgNum & "' and fiscal_yr = '" & frm_fiscal.Text & "'"))
            Dim newpct As Double = NewFunding.Item(0).UnitRate / OldRate
            Dim oldUnitRate As Double
            oldUnitRate = CDbl(ETSSQL.GetOneSQLValue("select unit_rate as TheValue from cc_fund where b_num = '" & selected_name_key & old_selected_contract_key & "'"))
            '  NewOne.UnitRate = CDec(Math.Round(newpct * NewContract.UnitRate, 2))
            NewOne.UnitRate = CDec(Math.Round(newpct * oldUnitRate, 2))

            ' '' if the old unit rate was not 100% of the old program rate then calculate the % and apply it to new program rate
            ' ''this means a cost share contract
            ' ''at this point the unit rate is the old rate so we only need the old prog rate
            ' ''calculate % and if not 100 then apply that
            ''If OldRate <> NewOne.UnitRate Then
            ''    Dim NewPCT As Double = NewOne.UnitRate / OldRate
            ''    NewOne.UnitRate = CDec(Math.Round((NewOne.UnitRate * NewPCT), 2))
            ''End If
        Next

        For cnt As Integer = 0 To NewFunding.Count - 1
            sqlstmnt = "insert into cc_fund " & NewFunding.Item(cnt).FundingColumnNames & "  values " & NewFunding.Item(cnt).FundingColumnData
            ETSSQL.ExecuteSQL(sqlstmnt)
        Next

        sqlstmnt = "update cc_fund set active = 'N', closed = 'Y' where contract_key = '" & old_selected_contract_key & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

    End Sub
    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        If Len(beg_Date.Text) = 0 Then
            MsgBox("You must enter a beginning date.")
            Exit Sub
        End If
        'get prgm # from ccontract
        Dim ContPgm As String
        ContPgm = ETSSQL.GetOneItemList(("select * from cc_cont where fiscal_yr = '" & frm_fiscal.Text & "' and contract_key = '" & selected_contract_key & "'"), "prog_num")
        Dim OneContPgm() As String = ContPgm.Split(CChar("*"))
        ContPgm = OneContPgm(0)

        'check if program exists for proper fiscal year
        sqlstmnt = "select * from program where fiscal_yr = '" & to_fiscal.Text & "' and prog_num = '" & ContPgm & "'"
        If ETSCommon.CheckNumRecords(sqlstmnt) = 0 Then
            'pgm not rolled over
            MsgBox("You must rollover the program first")
            Exit Sub
        End If
        sqlstmnt = "select * from program where fiscal_yr = '" & frm_fiscal.Text & "' and prog_num = '" & ContPgm & "'"
        If ETSCommon.CheckNumRecords(sqlstmnt) = 0 Then
            ' contract does not exist
            MsgBox("You must set the contract up first. No contract to roll over. ")
            Exit Sub
        End If

        Dim yr_Digit As String = Mid(to_fiscal.Text, 3, 2)
        'build new contract key - per jri  
        'same length but now 2-3-6-2-3  2-2
        Dim temp_cont_key As New StringBuilder(selected_contract_key)
        temp_cont_key.Insert(11, yr_Digit)
        temp_cont_key.Remove(13, 2)
        Dim marsamend As String = selected_contract_key.Substring(17)
        new_contract_key = temp_cont_key.ToString
        new_cont_id_num = new_contract_key.Substring(0, 2) & "-" & new_contract_key.Substring(2, 3) & "-" & new_contract_key.Substring(5, 6) & "-" & new_contract_key.Substring(11, 2) & "-" & new_contract_key.Substring(13, 3)

        'first get the contract number right and allow it to be edited
        Response = MsgBox("The new contract number id will be = " & Chr(10) & new_cont_id_num & Chr(10) & "Is this the correct number?", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.No Then
            new_cont_id_num = InputBox("Enter the new contract number with dashes.  You may use the arrow keys to edit.  A number change here will leave the old contract number available to roll over.", "Roll over", new_cont_id_num)
            If Len(new_cont_id_num) = 0 Then
                Exit Sub
            End If
            Dim newc() As String = Split(new_cont_id_num, CChar("-"))
            Dim newcc As New StringBuilder("")
            For Each n In newc
                newcc.Append(n)
            Next
            new_contract_key = newcc.ToString
        End If

        If ETSCommon.CheckOnceYN("cc_cont", "contract_key", new_contract_key, "Y") = "Y" Then
            MsgBox("Contract already created.  Edit to change fields.")
            Exit Sub
        End If

        Dim NewProgRate As Decimal = CDec(ETSSQL.GetOneSQLValue("select prog_rate  as thevalue from program where prog_num = '" & ContPgm & "' and fiscal_yr = '" & to_fiscal.Text & "'"))
        Dim OldProgRate As Decimal = ETSSQL.GetProgRate(old_selected_contract_key, ContPgm)

        Dim NewContract As New ContractData
        NewContract = ETSSQL.GetOneContractData("select * from cc_Cont where contract_key = '" & old_selected_contract_key & "'")
        '    Dim OLDPCT As Double = NewContract.UnitRate / OldProgRate
        NewContract.UnitRate = NewProgRate
        NewContract.UnitRate = Math.Round(NewContract.UnitRate, 2)
        NewContract.ContractKey = new_contract_key
        NewContract.ContIdNum = new_cont_id_num
        NewContract.AmendNum = "00"
        NewContract.EntryDate = Today
        NewContract.FiscalYr = to_fiscal.Text
        NewContract.ContBegD = selected_start_date
        NewContract.ContEndD = CDate("6/30/" & to_fiscal.Text)
        NewContract.PrgduraSdr = CStr(selected_start_date) & " - " & "6/30/" & to_fiscal.Text
        NewContract.PrgduraLea = CStr(selected_start_date) & " - " & "6/30/" & to_fiscal.Text
        NewContract.SeedDol = 0
        NewContract.SeedUnits = 0
        NewContract.YtdDol = 0
        NewContract.YtdUnits = 0
        NewContract.MonthDol = 0
        NewContract.MonthUnits = 0
        NewContract.RemDol = 0
        NewContract.RemUnits = 0
        NewContract.LastInvnum = ""
        NewContract.LastBilldate = CDate("1/1/1901")
        NewContract.ContUnits = NewContract.ContUnits + NewContract.AmendUnits
        NewContract.AmendUnits = 0
        NewContract.AmendDol = 0
        NewContract.ContOffset = 0
        NewContract.BillOffset = 0
        'calculate the contract dollars
        'unit rate times new cont_units
        NewContract.ContDol = CDec(NewContract.UnitRate * NewContract.ContUnits)
        'put new contract
        sqlstmnt = "insert into cc_cont " & NewContract.ContractColumnNames & "  values " & NewContract.ContractColumnData
        ETSSQL.ExecuteSQL(sqlstmnt)

        ''close the old contract
        sqlstmnt = "update cc_Cont set active = 'N' where contract_key = '" & old_selected_contract_key & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        selected_contract_key = NewContract.ContractKey
        selected_grouping = to_fiscal.Text
        entry_type = "EDITROLL"
        ATTContract.ShowDialog()

        'attcont1.ShowDialog()

        Response = MsgBox("Do you wish to roll over the funding sources for this contract." & Chr(13) & "This will be the only chance to do it automatically.", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.Yes Then
            Call fund_rollover()
        End If

        RebuildGrid()

    End Sub

    Private Sub beg_Date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles beg_Date.Enter
        Call ets_set_selected()
    End Sub

    Private Sub beg_Date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles beg_Date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = beg_Date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")

            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                beg_Date.Text = retdate.ToString
                selected_start_date = CDate(beg_Date.Text)
            End If

        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub beg_Date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles beg_Date.Leave
        beg_Date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        selected_grouping = ""
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cont_rollover_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        DataGridView1.Columns.Add("cont_id_num", "Contract")
        DataGridView1.Columns.Add("mmars_num", "MMARS #")
        DataGridView1.Columns.Add("amend_num", "Amend")
        DataGridView1.Columns.Add("cont_desc", "Description")
        DataGridView1.Columns.Add("fiscal_yr", "fiscal_yr")
        DataGridView1.Columns.Add("Contract_Key", "Contract")

        DataGridView1.Columns.Item(0).DataPropertyName = "cont_id_num"
        DataGridView1.Columns.Item(1).DataPropertyName = "mmars_num"
        DataGridView1.Columns.Item(2).DataPropertyName = "amend_num"
        DataGridView1.Columns.Item(3).DataPropertyName = "cont_desc"
        DataGridView1.Columns.Item(4).DataPropertyName = "fiscal_yr"
        DataGridView1.Columns.Item(5).DataPropertyName = "contract_key"

        DataGridView1.Columns.Item(5).Visible = False

        DataGridView1.Columns.Item(4).Width = 50
        DataGridView1.Columns.Item(1).Width = 50
        DataGridView1.Columns.Item(2).Width = 50

        to_fiscal.Text = CStr(Year(Today) + 1)
        frm_fiscal.Text = CStr(Year(Today))

        ctrform(Me)
        selectedcell = False
        RebuildGrid()

    End Sub

    Private Sub frm_fiscal_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_fiscal.Enter
        Call ets_set_selected()
    End Sub

    Private Sub frm_fiscal_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles frm_fiscal.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            'check for number

            If Not IsNumeric(frm_fiscal.Text) Then
                MsgBox("Please enter a number")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            If Len(frm_fiscal.Text) <> 4 Then
                MsgBox("Please enter a 4 digit year.")
                Call ets_set_selected()
                GoTo EventExitSub
            End If


            System.Windows.Forms.SendKeys.Send("{TAB}")
            KeyAscii = 0

        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub frm_fiscal_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_fiscal.Leave
        frm_fiscal.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub RebuildGrid()
        'find contracts that have not been rolled over


        sqlstmnt = "select cont_id_num, cont_desc, fiscal_yr, contract_key from cc_cont where fiscal_yr = '" & frm_fiscal.Text & "' and active = 'Y' "
        sqlstmnt = sqlstmnt & " and cont_End_d = '6/30/" & frm_fiscal.Text & "' order by contract_key"

        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sqlstmnt)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False

        Select Case SelectedIndex
            Case 0
                On Error Resume Next
                DataGridView1.Rows(0).Selected = False
                SelectedIndex = 1
                On Error GoTo 0
            Case Is > DataGridView1.Rows.Count
                SelectedIndex = 1
            Case Else
                DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
                ' DataGridView1.Rows(SelectedIndex).Selected = True
                'DataGridView1.Rows(SelectedIndex).Cells(0).Selected = True
                DataGridView1.PerformLayout()
        End Select


        DataGridView1.AutoResizeColumns()
        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing

    End Sub

    Private Sub to_fiscal_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles to_fiscal.Enter
        Call ets_set_selected()
    End Sub

    Private Sub to_fiscal_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles to_fiscal.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            'check for number

            If Not IsNumeric(to_fiscal.Text) Then
                MsgBox("Please enter a number")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            If Len(to_fiscal.Text) <> 4 Then
                MsgBox("Please enter a 4 digit year.")
                Call ets_set_selected()
                GoTo EventExitSub
            End If


            System.Windows.Forms.SendKeys.Send("{TAB}")
            KeyAscii = 0

        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub to_fiscal_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles to_fiscal.Leave
        to_fiscal.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

End Class