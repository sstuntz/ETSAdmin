Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports JRI.MODULE1
Imports System.Data.SqlClient

Friend Class ar_cash_edit_sel
	Inherits System.Windows.Forms.Form
    Dim SelectedIndex As Integer

    Private Sub rebuild_grid()  'ByVal sql As String)

        sqlstmnt = "Select chk_alloc, invoice, batch_num, entry_num, batch_Desc, batch_total from cash_tmp1 where batch_num = '" & selected_bat_num & "' order by entry_num"

        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sqlstmnt)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        selected_lookup_num = ""
        On Error Resume Next
        DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
        DataGridView1.Rows(SelectedIndex).Selected = True
        DataGridView1.Rows(SelectedIndex).Cells(0).Selected = True
        DataGridView1.PerformLayout()
        On Error GoTo 0

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("entry_num", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub
	Public rowvalue, colvalue As Object
	Public saved_chk_num As Object
	
    Public Sub calc_bat_Tot()
        sqlstmnt = "Select * from cash_Tmp1 where batch_num = " & selected_bat_num
        tot_amt = CDec(ETSSQL.GetTotalPayments(sqlstmnt))
        bat_bal.Text = String.Format("{0:c2}", tot_amt)
    End Sub
	
	Private Sub addchk_Click()
		'cash_tmp is for 1 check
        'cash_tmp.Refresh()
        ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not cash_tmp.Recordset.EOF
        '	'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp.Recordset.delete. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	cash_tmp.Recordset.delete()
        '	'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	cash_tmp.Recordset.MoveNext()
        'Loop 

        ''UPGRADE_ISSUE: Data property cash_tmp1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.recordsource = "select * from cash_tmp1 order by entry_num"
        'cash_tmp1.Refresh()
        'Call calc_bat_Tot()

        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If cash_tmp1.Recordset.EOF Then
        '	saved_entry_num = 1
        'Else
        '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.MoveLast. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	cash_tmp1.Recordset.MoveLast()
        '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	saved_entry_num = cash_tmp1.Recordset.Fields("entry_num") + 1
        'End If

        'entry_type = "ADD"
        'frmar_cash1.ShowDialog()
        'cash_tmp1.Refresh()
        'Call calc_bat_Tot()
		
	End Sub
	
	Private Sub cash_apply_Click()
		'check the batch for completeness
		'check acct numbers
		
		
        ''check the chk_alloc to total to the check amount
        ''UPGRADE_ISSUE: Data property cash_tmp1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.recordsource = "select * from cash_tmp1 order by name_key,chk_num"
        'cash_tmp1.Refresh()
        'Call calc_bat_Tot()
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'cash_tmp1.Recordset.MoveFirst()

        'tot_amt = 0 'cash_Tmp1.Recordset.Fields("chk_alloc")
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object saved_chk_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'saved_chk_num = cash_tmp1.Recordset.Fields("chk_num")
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'saved_name_key = cash_tmp1.Recordset.Fields("name_key")
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'saved_amount = cash_tmp1.Recordset.Fields("check_amt") + cash_tmp1.Recordset.Fields("chk_disc")
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not cash_tmp1.Recordset.EOF

        '	valid_acct = " N "
        '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	Call etsacctnum_chk(cash_tmp1.Recordset.Fields("cr_Acct_nu"), retacct, retacctdesc, valid_acct)

        '	If valid_acct = "N" Then
        '		'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		MsgBox(("BATCH NOT POSTED Invalid  CR account number on entry number = ") & cash_tmp1.Recordset.Fields("entry_num"))
        '		Exit Sub
        '	End If
        '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	Call etsacctnum_chk(cash_tmp1.Recordset.Fields("dr_Acct_nu"), retacct, retacctdesc, valid_acct)

        '	If valid_acct = "N" Then
        '		'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		MsgBox(("BATCH NOT POSTED Invalid DR account number on entry number = ") & cash_tmp1.Recordset.Fields("entry_num"))
        '		Call ets_set_selected()
        '		Exit Sub
        '	End If

        '	' If cash_Tmp1.Recordset.Fields("name_key") = saved_name_key Then

        '	'If cash_Tmp1.Recordset.Fields("chk_num") <> saved_chk_num Then
        '	'   If tot_amt <> saved_amount Then
        '	'     MsgBox "BATCH NOT POSTED This check is not applied correctly. Check number = " & saved_chk_num
        '	'      Exit Sub
        '	'   Else
        '	'   tot_amt = 0
        '	'  saved_amount = cash_Tmp1.Recordset.Fields("check_amt") + cash_Tmp1.Recordset.Fields("chk_disc")
        '	' saved_chk_num = cash_Tmp1.Recordset.Fields("chk_num")
        '	'saved_name_key = cash_Tmp1.Recordset.Fields("name_key")
        '	'       End If
        '	'   End If
        '	'     Else
        '	'      If tot_amt <> saved_amount Then
        '	'      MsgBox "BATCH NOT POSTED This check is not applied correctly. Check number = " & saved_chk_num
        '	'       Exit Sub
        '	'    Else
        '	'    tot_amt = 0
        '	'   saved_amount = cash_Tmp1.Recordset.Fields("check_amt") + cash_Tmp1.Recordset.Fields("chk_disc")
        '	'  saved_chk_num = cash_Tmp1.Recordset.Fields("chk_num")
        '	' saved_name_key = cash_Tmp1.Recordset.Fields("name_key")
        '	'   End If

        '	'  End If



        '	'     tot_amt = tot_amt + cash_Tmp1.Recordset.Fields("chk_alloc")

        '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	cash_tmp1.Recordset.MoveNext()
        'Loop 


        ''check the last one
        ''  If tot_amt <> saved_amount Then
        ''        MsgBox "BATCH NOT POSTED This check is not applied correctly. Check number = " & saved_chk_num
        ''       Exit Sub
        ''  End If


        ''copy the files to cash
        ''and update invoice
        'tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
        'tmpset = tmpdb.OpenRecordset("invoice", dao.RecordsetTypeEnum.dbOpenDynaset)


        'cash_tmp1.Refresh()
        'Call calc_bat_Tot()

        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'cash_tmp1.Recordset.MoveFirst()
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not cash_tmp1.Recordset.EOF

        '	'apply to invoice

        '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	If Len(cash_tmp1.Recordset.Fields("inv_num")) <> 0 Then
        '		'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		sqlstmnt = "inv_num = " & cash_tmp1.Recordset.Fields("inv_num")
        '		'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		sqlstmnt = sqlstmnt & " and line_num = " & cash_tmp1.Recordset.Fields("line_num")
        '		'tmpset is invoice
        '		tmpset.FindFirst(sqlstmnt)

        '		If tmpset.NoMatch Then
        '			'skip update to invoice
        '			'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			MsgBox("This invoice number was not in the invoice file. Inv number = " & cash_tmp1.Recordset.Fields("inv_num"))

        '		Else
        '			tmpset.edit()
        '			'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			tmpset.Fields("paid_date").Value = cash_tmp1.Recordset.Fields("encum_Date")
        '			'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			tmpset.Fields("chk_num").Value = cash_tmp1.Recordset.Fields("chk_num")
        '			'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			tmpset.Fields("bank_key").Value = cash_tmp1.Recordset.Fields("bank_key")
        '			'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			Call bank_nameget(cash_tmp1.Recordset.Fields("bank_key"))
        '			tmpset.Fields("bank_name").Value = bank_screen_nam
        '			'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			tmpset.Fields("pay_amt").Value = cash_tmp1.Recordset.Fields("chk_alloc")
        '			'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			tmpset.Fields("bal_due").Value = tmpset.Fields("bal_due").Value - cash_tmp1.Recordset.Fields("chk_alloc")
        '			If tmpset.Fields("bal_Due").Value = 0 Then
        '				tmpset.Fields("paid").Value = "Y"
        '			End If
        '			tmpset.update()
        '		End If
        '	End If

        '	'move to cash
        '	'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash.Recordset.AddNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	cash.Recordset.AddNew()
        '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	For num = 0 To cash_tmp1.Recordset.Fields.Count - 1
        '		'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cash.Recordset((num)) = cash_tmp1.Recordset(num)
        '	Next 

        '	'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash.Recordset.update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	cash.Recordset.update()
        '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	cash_tmp1.Recordset.MoveNext()
        'Loop 

        'cash_tmp1.Refresh()
        'Call calc_bat_Tot()

        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not cash_tmp1.Recordset.EOF
        '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.delete. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	cash_tmp1.Recordset.delete()
        '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	cash_tmp1.Recordset.MoveNext()
        'Loop 

        'MsgBox("Batch was successfully posted to CASH and INVOICE")
		
		Me.Close()
	End Sub
	
    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		prtDestination = 0
        prtreportfilename = (ar_report_path & "arcbatch.rpt")
		' Call frmcrystal_Call
	End Sub
	
    Private Sub del_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles del.Click
        'On Error Resume Next
        ''UPGRADE_WARNING: Couldn't resolve default property of object rowvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If Err.Number = 6028 Or rowvalue = "" Then
        '	MsgBox("You must select an item for deleting.")
        '	Exit Sub
        'End If
        'On Error GoTo 0

        'Response = MsgBox("This will delete all the entries for the type selected from the batch.  Do you want to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
        'If Response = 7 Then Exit Sub

        ''save the chk num since it repaint with the grid

        ''   saved_chk_num = DBGrid1.Columns(6).CellText(DBGrid1.RowBookmark(rowvalue))
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'cash_tmp1.Recordset.MoveFirst()
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not cash_tmp1.Recordset.EOF
        '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	If cash_tmp1.Recordset.Fields("chk_num") = saved_chk_num Then
        '		'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.delete. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		cash_tmp1.Recordset.delete()
        '	End If
        '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	cash_tmp1.Recordset.MoveNext()
        'Loop 

        'cash_tmp1.Refresh()
        'Call calc_bat_Tot()

        '' selected_name_key =
        ''1.Columns(0).CellText(dbgrid1.RowBookmark(rowvalue))

        ''UPGRADE_WARNING: Couldn't resolve default property of object rowvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'rowvalue = ""
    End Sub
	
	Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Edit.Click
		
        ''UPGRADE_WARNING: Couldn't resolve default property of object rowvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If Err.Number = 6028 Or rowvalue = "" Then
        '	MsgBox("You must select an item for editing.")
        '	Exit Sub
        'End If
        'On Error GoTo 0

        'cash_tmp.Refresh()
        ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not cash_tmp.Recordset.EOF
        '	'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp.Recordset.delete. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	cash_tmp.Recordset.delete()
        '	'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	cash_tmp.Recordset.MoveNext()
        'Loop 


        ''  saved_entry_num = DBGrid1.Columns(0).CellText(DBGrid1.RowBookmark(rowvalue))
        '' saved_batch_num = DBGrid1.Columns(1).CellText(DBGrid1.RowBookmark(rowvalue))

        ''we now do not allow editing of items with multiple items on one check
        '' sqlstmnt = "Select * from cash_tmp1 where chk_num = " & Chr(34) & DBGrid1.Columns(6).CellText(DBGrid1.RowBookmark(rowvalue)) & Chr(34)
        'sqlstmnt = sqlstmnt & " and batch_num = " & saved_batch_num
        ''UPGRADE_ISSUE: Data property cash_tmp1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.recordsource = sqlstmnt
        'cash_tmp1.Refresh()
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.MoveLast. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'cash_tmp1.Recordset.MoveLast()

        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp1.Recordset.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If cash_tmp1.Recordset.RecordCount > 1 Then
        '	MsgBox("You can not edit a check that has more than one entry.")
        '	Exit Sub
        'End If


        'entry_type = "EDIT"

        'frmar_cash1.ShowDialog()

        ''UPGRADE_ISSUE: Data property cash_tmp1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.recordsource = "select * from cash_Tmp1 where batch_num = " & selected_bat_num & " order by entry_num"
        'cash_tmp1.Refresh()
        'Call calc_bat_Tot()

        ''UPGRADE_WARNING: Couldn't resolve default property of object rowvalue. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'rowvalue = ""
	End Sub
	Private Sub ar_cash_edit_sel_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False

        'DataGridView1.Columns.Add("autho_num", "Autho")
        'DataGridView1.Columns.Item(0).DataPropertyName = "autho_num"
        'DataGridView1.Columns.Add("name_key", "Name Key")
        'DataGridView1.Columns.Item(1).DataPropertyName = "name_key"
        'DataGridView1.Columns.Add("sort_name", "Sort Name")
        'DataGridView1.Columns.Item(2).DataPropertyName = "sort_name"
        'DataGridView1.Columns.Add("contract_key", "Contract")
        'DataGridView1.Columns.Item(3).DataPropertyName = "contract_key"
        '' DataGridView1.Columns.Item(3).DefaultCellStyle.Format = "N2"
        ctrform(Me)
        selectedcell = False

        rebuild_grid()
		
        Call calc_bat_Tot()
    End Sub
	
End Class