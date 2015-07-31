Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System
Imports System.Configuration
Imports JRI.MODULE1
Imports System.Data.SqlClient

Friend Class cont_rollover
	Inherits System.Windows.Forms.Form

	Public old_selected_contract_key As String
	Public newrate As Decimal
    Public prog As String

    Private Sub rebuild_grid()  'ByVal sql As String)
        Dim sql As String = "select distinct batch_num, batch_Date, batch_Desc, batch_total from cash_tmp1 order by batch_num "
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        If SelectedIndex > 0 Then
            DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
            DataGridView1.Rows(SelectedIndex).Selected = True
            DataGridView1.Rows(SelectedIndex).Cells(0).Selected = True
            DataGridView1.PerformLayout()
        End If

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_bat_num = CInt(DataGridView1.Item("batch_num", e.RowIndex).Value.ToString)
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub
	
	'UPGRADE_NOTE: rate was upgraded to rate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Sub calc_new_Rate(ByRef rate_Renamed As Object, ByRef prog As Object, ByRef newrate As Object, ByRef valid_yn As Object)
		'UPGRADE_WARNING: Couldn't resolve default property of object valid_yn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'valid_yn = "N"
        'tmpdb = DAODBEngine_definst.OpenDatabase(att_data_path & "aratt.mdb")
        'tmpset = tmpdb.OpenRecordset("program", dao.RecordsetTypeEnum.dbOpenDynaset)
        ''UPGRADE_WARNING: Couldn't resolve default property of object prog. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = "prog_num = " & Chr(34) & prog & Chr(34) & " and fiscal_yr = " & Chr(34) & frm_fiscal.Text & Chr(34)
        'tmpset.FindFirst(sqlstmnt)

        'If tmpset.NoMatch Then
        '	'MsgBox "Can not roll over this contract since the program has not been set up"
        '	Exit Sub
        'End If


        'tmp1set = tmpdb.OpenRecordset("program", dao.RecordsetTypeEnum.dbOpenDynaset)
        ''UPGRADE_WARNING: Couldn't resolve default property of object prog. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = "prog_num = " & Chr(34) & prog & Chr(34) & " and fiscal_yr = " & Chr(34) & to_fiscal.Text & Chr(34)
        'tmp1set.FindFirst(sqlstmnt)

        'If tmp1set.NoMatch Then
        '	'MsgBox "Can not roll over this contract since the program has not been set up"
        '	Exit Sub
        'End If

        'If tmpset.Fields("prog_rate").Value = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object newrate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	newrate = 0
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object rate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object newrate. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	newrate = VB6.Format((rate_Renamed / tmpset.Fields("prog_rate").Value) * tmp1set.Fields("prog_rate").Value, "FIXED")
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object valid_yn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'valid_yn = "Y"
		
	End Sub
	
	
	
	Public Sub fund_rollover()
		'find the funding sources
        'tmpdb = DAODBEngine_definst.OpenDatabase(att_data_path & "aratt.mdb")
        'tmpset = tmpdb.OpenRecordset("cc_fund", dao.RecordsetTypeEnum.dbOpenDynaset)
        ''Set Fund = tmpdb.OpenRecordset("cc_Fund", dbOpenDynaset)

        ''check to see if rolled over already
        'sqlstmnt = "select * from cc_Fund where contract_key = " & Chr(34) & selected_contract_key & Chr(34)
        ''Set Fund = tmpdb.OpenRecordset(sqlstmnt, dbOpenDynaset)
        ''UPGRADE_ISSUE: Data property fund.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'fund.RecordSource = sqlstmnt
        'fund.Refresh()

        ''UPGRADE_ISSUE: Data property fund.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object fund.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If Not fund.Recordset.EOF Then
        '	MsgBox("Funding sources have been rolled over.")
        '	Exit Sub
        'End If

        'sqlstmnt = "select * from cc_Fund where contract_key = " & Chr(34) & old_selected_contract_key & Chr(34)
        ''Set Fund = tmpdb.OpenRecordset(sqlstmnt, dbOpenDynaset)
        ''UPGRADE_ISSUE: Data property fund.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'fund.RecordSource = sqlstmnt
        'fund.Refresh()

        ''UPGRADE_ISSUE: Data property fund.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object fund.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If fund.Recordset.EOF Then
        '	MsgBox("Nothing to rollover for this contract.")
        '	Exit Sub
        'End If

        ''UPGRADE_WARNING: Arrays in structure contract1 may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim contract1 As dao.Recordset
        'contract1 = tmpdb.OpenRecordset("cc_cont", dao.RecordsetTypeEnum.dbOpenDynaset)
        ''UPGRADE_ISSUE: Data property fund.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object fund.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'fund.Recordset.MoveFirst()
        ''UPGRADE_ISSUE: Data property fund.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object fund.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not fund.Recordset.EOF
        '	'UPGRADE_ISSUE: Data property fund.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object fund.Recordset.edit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	fund.Recordset.edit()
        '	'check the contract
        '	' if closed do not roll over
        '	'UPGRADE_ISSUE: Data property fund.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object fund.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	If fund.Recordset.Fields("closed") = "N" Then
        '		tmpset.AddNew()
        '		'UPGRADE_ISSUE: Data property fund.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object fund.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		For num = 0 To fund.Recordset.Fields.Count - 1
        '			'UPGRADE_ISSUE: Data property fund.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			tmpset.Fields(num).Value = fund.Recordset(num)
        '		Next 

        '		tmpset.Fields("contract_key").Value = selected_contract_key
        '		tmpset.Fields("b_num").Value = tmpset.Fields("name_key").Value & tmpset.Fields("contract_key").Value
        '		tmpset.Fields("entry_Date").Value = Today
        '		tmpset.Fields("closed").Value = "N"
        '		tmpset.Fields("bill_Date").Value = "1/1/1901"
        '		tmpset.Fields("client_Total").Value = 0
        '		tmpset.Fields("dflag").Value = "N"

        '		contract1.FindFirst("contract_key = " & Chr(34) & selected_contract_key & Chr(34))
        '		If contract1.NoMatch Then
        '			MsgBox("no matching contract")
        '			Stop
        '		End If

        '		tmpset.Fields("cont_id_num").Value = contract1.Fields("cont_id_num").Value
        '		tmpset.Fields("amend_num").Value = contract1.Fields("amend_num").Value
        '		tmpset.Fields("mmars_num").Value = contract1.Fields("mmars_num").Value
        '		tmpset.Fields("beg_date").Value = contract1.Fields("cont_beg_d").Value
        '		tmpset.Fields("end_date").Value = contract1.Fields("cont_end_d").Value
        '		tmpset.Fields("active").Value = "Y"
        '		'get the new rate
        '		' if the old rate not 100% then calculate the % and apply it to new rate
        '		Call get_prog_rate(contract1.Fields("prog_num"), contract1.Fields("fiscal_yr"))
        '		tmpset.Fields("unit_rate").Value = selected_prog_rate


        '		'now get the old prog rate to see if it is a percentage
        '		contract1.FindFirst("contract_key = " & Chr(34) & old_selected_contract_key & Chr(34))
        '		If contract1.NoMatch Then Stop

        '		Call get_prog_rate(contract1.Fields("prog_num"), contract1.Fields("fiscal_yr"))
        '		'UPGRADE_ISSUE: Data property fund.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object fund.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		If fund.Recordset.Fields("unit_rate") <> selected_prog_rate Then
        '			'UPGRADE_ISSUE: Data property fund.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object fund.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			tmpset.Fields("unit_rate").Value = (fund.Recordset.Fields("unit_rate") / selected_prog_rate) * tmpset.Fields("unit_rate").Value

        '		End If



        '		tmpset.Update()
        '	End If 'end if closed to not rollover

        '	'UPGRADE_ISSUE: Data property fund.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object fund.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	fund.Recordset.Fields("active") = "N"
        '	'UPGRADE_ISSUE: Data property fund.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object fund.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	fund.Recordset.Fields("closed") = "Y"
        '	'UPGRADE_ISSUE: Data property fund.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object fund.Recordset.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	fund.Recordset.Update()

        '	'UPGRADE_ISSUE: Data property fund.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object fund.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	fund.Recordset.MoveNext()
        'Loop 
		
		
	End Sub
	Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click
		
		Dim temp_Cont_id As String
		Dim temp_cont_key As String
		Dim yr_Digit As String
		
		If selectedcell = False Then
			MsgBox("Nothing selected")
			Exit Sub
		End If
		
		'     temp_row = Grid1.TopRow
		'    actual_row = Grid1.Row
		
		'    Grid1.Col = 0
		'    selected_cont_id_num = Grid1.Text
		
		'    Call cont_key_remove_Dashes(Grid1.Text, retstring)
		msg = retstring
		selected_contract_key = msg
		old_selected_contract_key = msg
		
		yr_Digit = Mid(to_fiscal.Text, 4, 1)
		
		temp_cont_key = VB.Left(msg, 9) & yr_Digit & VB.Right(msg, 10)
		msg = selected_cont_id_num
		temp_Cont_id = VB.Left(msg, 12) & yr_Digit & Mid(msg, 14, 7)
		
		'first get the contract number right and allow it to be edited
		Response = MsgBox("The new contract number will be = " & Chr(10) & temp_Cont_id & Chr(10) & "Is this the correct number?", MsgBoxStyle.YesNo)
		If Response = MsgBoxResult.Yes Then
			'contract.Recordset.Fields("cont_id_num") = temp_Cont_id
			'contract.Recordset.Fields("contract_key") = temp_cont_key
		Else
			' how to handle the edit
            Call cont_key_display(temp_cont_key)
			msg = retstring
			temp_cont_key = InputBox("Enter the new contract number with dashes.  You may use the arrow keys to edit.  A number change here will leave the old contract number available to roll over.", "Roll over", msg)
			If Len(temp_cont_key) = 0 Then
				Exit Sub
			End If
			temp_Cont_id = VB.Left(temp_cont_key, 20)
            Call cont_key_remove_Dashes(temp_cont_key)
			temp_cont_key = retstring
			
		End If
		
		'contract.Recordset.Fields("cont_id_num") = temp_Cont_id
		'contract.Recordset.Fields("contract_key") = temp_cont_key
		
        'valid_yn = "N"
        'Call chk_valid_cont(temp_cont_key, valid_yn)
        'If valid_yn <> "N" Then
        '	MsgBox("Contract already created.  Edit to change fields.")
        '	Exit Sub
        'End If

        'sqlstmnt = " contract_key = " & Chr(34) & old_selected_contract_key & Chr(34)
        'tmpdb = DAODBEngine_definst.OpenDatabase(att_data_path & "aratt.mdb")
        'rs = tmpdb.OpenRecordset("cc_cont", dao.RecordsetTypeEnum.dbOpenDynaset)
        'rs.FindFirst(sqlstmnt)


        'Call calc_new_Rate(rs.Fields("unit_rate"), rs.Fields("prog_num"), newrate, valid_yn)
        'If valid_yn = "N" Then
        '	MsgBox("You must rollover the program first.  Contract not rolled over.")

        '	Exit Sub
        'End If
		
		
		'UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.AddNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.AddNew()
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'For num = 0 To contract.Recordset.Fields.Count - 1
        '	'UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	contract.Recordset((num)) = rs.Fields(num).Value
        'Next 

        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("cont_id_num") = temp_Cont_id
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("contract_key") = temp_cont_key

        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("amend_num") = "00"
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("entry_Date") = Today
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("fiscal_yr") = to_fiscal.Text
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("cont_beg_d") = selected_start_date
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("cont_end_D") = "6/30/" & to_fiscal.Text
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'selected_contract_key = contract.Recordset.Fields("contract_key")
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("prgdura_sdr") = CStr(selected_start_date) & " - " & "6/30/" & to_fiscal.Text
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("prgdura_lea") = CStr(selected_start_date) & " - " & "6/30/" & to_fiscal.Text
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("seed_units") = 0
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("seed_dol") = 0
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("ytd_units") = 0
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("ytd_dol") = 0
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("month_units") = 0
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("month_dol") = 0
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("rem_units") = 0
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("rem_dol") = 0
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("last_invnum") = ""
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("last_billdate") = "1/1/1901"
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("cont_units") = rs.Fields("cont_units").Value + rs.Fields("amend_units").Value
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("amend_units") = 0
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("amend_dol") = 0
        ''calculate the new unit contract rate = old unit/old program* new progr
        'Call calc_new_Rate(rs.Fields("unit_rate"), rs.Fields("prog_num"), newrate, valid_yn)
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("unit_rate") = newrate
        ''calculate the contract dollars
        ''unit rate times new cont_units
        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Fields("cont_dol") = VB6.Format(contract.Recordset.Fields("unit_rate") * contract.Recordset.Fields("cont_units"), "FIXED")

        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.Update()
        ''close the old contract
        'rs.edit()
        'rs.Fields("active").Value = "N"
        'rs.Update()
		
		selected_grouping = to_fiscal.Text
		
		entry_type = "EDITROLL"
        attcont1.ShowDialog()
		
		Response = MsgBox("Do you wish to roll over the funding sources for this contract." & Chr(13) & "This will be the only chance to do it automatically.", MsgBoxStyle.YesNo)
		If Response = MsgBoxResult.Yes Then
			
			Call fund_rollover()
		End If
		
		
		'clear the grid
		'    For num = Grid1.Rows - 1 To 1 Step -1
		'    Grid1.RemoveItem num
		'    Next
		'    Grid1.Col = 0
		'    Grid1.Text = ""
		'     Grid1.Col = 1
		'    Grid1.Text = ""
		'     Grid1.Col = 2
		'    Grid1.Text = ""
		'     Grid1.Col = 3
		'    Grid1.Text = ""
		
		'          Screen.MousePointer = vbHourglass
		
		'       Set tmpdb = OpenDatabase(att_data_path & "aratt.mdb")
		'     Set tmpset = tmpdb.OpenRecordset("cc_cont", dbOpenDynaset)
		
		
		'contract.RecordSource = "select * from cc_cont where fiscal_yr = " & Chr(34) & frm_fiscal & Chr(34)
		'    contract.Refresh
		'   num = 0
		'  contract.Recordset.MoveFirst
		' On Error GoTo 0
		
		'     Do While Not contract.Recordset.EOF
		'   sqlstmnt = "fiscal_yr = " & Chr(34) & to_fiscal & Chr(34)
		'  sqlstmnt = sqlstmnt & "and cont_id_num = " & Chr(34) & contract.Recordset.Fields("cont_id_num") & Chr(34)
		' tmpset.FindFirst sqlstmnt
		'If tmpset.NoMatch Then
		'    Call cont_key_display(contract.Recordset.Fields("contract_key"), retstring)
		'   msg = retstring
		'   Grid1.AddItem msg & Chr(9) & contract.Recordset.Fields("cont_desc") & Chr(9) & contract.Recordset.Fields("fiscal_yr"), num
		'   num = num + 1
		'End If
		'contract.Recordset.MoveNext
		
		' Loop
		'    Grid1.RemoveItem num
		
		'    Grid1.ColWidth(0) = 3000
		'    Grid1.ColWidth(1) = 2250
		'    Grid1.ColWidth(2) = 750
		'    Grid1.ColWidth(3) = 1000
		
		ref_list.Focus()
		
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
	End Sub
	
	Private Sub beg_Date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles beg_Date.Enter
		Call ets_set_selected()
	End Sub
	
	Private Sub beg_Date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles beg_Date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			valid_Date = "N"
			senddate = beg_Date.Text
            'Call etsdate(senddate, retdate, valid_Date)
			
			If valid_Date <> "N" Then
                '	beg_Date.Text = retdate
				beg_Date.Text = CStr(CDate(beg_Date.Text))
				selected_start_date = CDate(beg_Date.Text)
			Else
				MsgBox(" Bad Date")
				Call ets_set_selected()
				GoTo EventExitSub
			End If
			
			ref_list.Focus()
			
			KeyAscii = 0
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
		
	End Sub
	
	Private Sub cont_rollover_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
          DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        DataGridView1.Columns.Add("batch_num", "Batch #")
        DataGridView1.Columns.Item(0).DataPropertyName = "batch_num"
        DataGridView1.Columns.Add("batch_date", "Batch Date")
        DataGridView1.Columns.Item(1).DataPropertyName = "batch_date"
        DataGridView1.Columns.Add("batch_desc", "Batch Desc")
        DataGridView1.Columns.Item(2).DataPropertyName = "batch_desc"
        DataGridView1.Columns.Add("batch_total", "Batch Total")
        DataGridView1.Columns.Item(3).DataPropertyName = "batch_total"
        DataGridView1.Columns.Item(3).DefaultCellStyle.Format = "N2"
        ctrform(Me)
        selectedcell = False

        rebuild_grid()
		
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
	
	Private Sub Ref_list_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Ref_list.Click
		
		
        'tmpdb = DAODBEngine_definst.OpenDatabase(att_data_path & "aratt.mdb")
        'tmpset = tmpdb.OpenRecordset("cc_cont", dao.RecordsetTypeEnum.dbOpenDynaset)

        'sqlstmnt = "select * from cc_cont where fiscal_yr = " & Chr(34) & frm_fiscal.Text & Chr(34)
        'sqlstmnt = sqlstmnt & " and active = 'Y' "
        'sqlstmnt = sqlstmnt & " and cont_End_d = #6/30/" & frm_fiscal.Text & "# order by contract_key"

        ''UPGRADE_ISSUE: Data property contract.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'contract.RecordSource = sqlstmnt
        'contract.Refresh()
        'num = 0

        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'contract.Recordset.MoveFirst()
        'On Error GoTo 0

        ''UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not contract.Recordset.EOF

        '	'UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	msg = contract.Recordset.Fields("contract_key")
        '	'  contract.Recordset.Fields("contract_key") = Left(msg, 9) & CStr(Val(Mid(msg, 10, 1)) + 1) & Right(msg, 10)

        '	sqlstmnt = "fiscal_yr = " & Chr(34) & to_fiscal.Text & Chr(34)
        '	sqlstmnt = sqlstmnt & " and contract_key = " & Chr(34) & VB.Left(msg, 9) & CStr(Val(Mid(msg, 10, 1)) + 1) & VB.Right(msg, 10) & Chr(34)
        '	tmpset.FindFirst(sqlstmnt)
        '          If tmpset.NoMatch Then
        '              'UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '              'UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              Call cont_key_display(contract.Recordset.Fields("contract_key"), retstring)
        '              msg = retstring
        '              '   Grid1.AddItem msg & Chr(9) & contract.Recordset.Fields("cont_desc") & Chr(9) & contract.Recordset.Fields("fiscal_yr"), num
        '              num = num + 1
        '          End If
        '	'UPGRADE_ISSUE: Data property contract.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object contract.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	contract.Recordset.MoveNext()

        'Loop 
		'  Grid1.RemoveItem num
		
		'  Grid1.ColWidth(0) = 3000
		'  Grid1.ColWidth(1) = 2250
		'  Grid1.ColWidth(2) = 750
		'  Grid1.ColWidth(3) = 1000
		'    Grid1.ColWidth(4) = 500
		
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