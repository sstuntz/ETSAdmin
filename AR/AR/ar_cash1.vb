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

Friend Class frmar_cash1
	Inherits System.Windows.Forms.Form
	
	Public colvalue, rowvalue As Object
	Public check_alloc_comp As String
	
	
	Public Sub how_mults_done() 'not used code
        ''check to see if multiline
        ''UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'invoice.recordsource = "select * from invoice where inv_num = " & cash_tmp.Recordset.Fields("inv_num").Value
        'invoice.Refresh()

        ''calc  the balance due to see if can pay in full\
        'bal_Due = 0
        ''UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Do While Not invoice.Recordset.EOF
        '	'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	bal_Due = bal_Due + invoice.Recordset.Fields("bal_due").Value
        '	'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	invoice.Recordset.MoveNext()
        'Loop 


        ''UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'If invoice.Recordset.RecordCount > 1 Then 'multiline
        '	'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	If cash_tmp.Recordset.Fields("chk_Alloc").Value <> bal_Due Then
        '		MsgBox("Since this is not a full payment on the multi line invoice, the next screen will allow detail editing.")
        '		Response = 7
        '	Else

        '		'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Response = MsgBox("This is a multiple line invoice in the amount of " & cash_tmp.Recordset.Fields("bal_Due").Value & Chr(13) & "Proceed to pay all lines of invoice?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
        '	End If

        '	If Response = 6 Then

        '		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		invoice.Recordset.MoveFirst()
        '		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Do While Not invoice.Recordset.EOF 'handle the detail records
        '			Call pay_mult_line_inv()
        '			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			invoice.Recordset.MoveNext()
        '		Loop 
        '	Else
        '		cash_tmp2.Refresh()
        '		'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Do While Not cash_tmp2.Recordset.EOF
        '			'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			cash_tmp2.Recordset.delete()
        '			'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			cash_tmp2.Recordset.MoveNext()
        '		Loop 
        '		'write basic data out ot cash tmp
        '		'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cash_tmp2.Recordset.AddNew()
        '		'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cash_tmp2.Recordset.Fields("bank_key").Value = txtfields(0).Text
        '		'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cash_tmp2.Recordset.Fields("encum_date").Value = pr_start_date1.Text
        '		'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cash_tmp2.Recordset.Fields("batch_num").Value = txtfields(23).Text
        '		'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cash_tmp2.Recordset.Fields("batch_date").Value = pr_start_date1.Text
        '		'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cash_tmp2.Recordset.Fields("batch_desc").Value = txtfields(24).Text
        '		'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cash_tmp2.Recordset.Fields("batch_total").Value = Val(bat_Amt.Text)
        '		'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cash_tmp2.Recordset.Fields("entry_date").Value = Today
        '		'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cash_tmp2.Recordset.Fields("name_key").Value = " 9"
        '		'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cash_tmp2.Recordset.Fields("screen_nam").Value = " 9"
        '		'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cash_tmp2.Recordset.Fields("sort_name").Value = " 9"
        '		'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cash_tmp2.Recordset.Fields("chk_num").Value = "Wire"

        '		'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cash_tmp2.Recordset.Fields("entry_num").Value = saved_entry_num
        '		If entry_type = "ADD" Then
        '			'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			cash_tmp2.Recordset.Fields("s_m").Value = "S"
        '		End If
        '		'UPGRADE_ISSUE: Data property cash_tmp2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cash_tmp2.Recordset.update()
        '		'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		selected_prog_rate = cash_tmp.Recordset.Fields("chk_alloc").Value
        '		saved_entry_type = entry_type

        '		ar_det_app.ShowDialog()
        '		If entry_type = "CANCEL" Then
        '			MsgBox("The entry was cancelled. No Cash applied")
        '			entry_type = saved_entry_type

        '			Exit Sub
        '		End If ' end of response to fully apply


        '	End If




        'Else
        'End If
	End Sub
	
	Public Sub check_comp()
		
		If Len(txtfields(14).Text) = 0 Then
			MsgBox("You must enter an allocated amount.")
			txtfields(14).Focus()
			Exit Sub
		End If
		
		If Len(txtfields(9).Text) = 0 Then
			MsgBox("You must enter a bank dr acct num.")
			txtfields(9).Focus()
			Exit Sub
		End If
		
		If Len(txtfields(16).Text) = 0 Then
			MsgBox("You must enter a cr acct num.")
			txtfields(16).Focus()
			Exit Sub
		End If
		
		If Len(txtfields(4).Text) = 0 Then
			MsgBox("You must enter check number or the word CASH.")
			txtfields(4).Focus()
			Exit Sub
		End If
		
		If Len(txtfields(2).Text) = 0 Then
			MsgBox("You must enter a name key (Customer number).")
			txtfields(2).Focus()
			Exit Sub
		End If
		
		If Len(txtfields(8).Text) = 0 Then
			MsgBox("You must enter a check amount.")
			txtfields(8).Focus()
			Exit Sub
		End If
		
		save.Focus()
		
	End Sub
	Public Sub sub_Tot()
		
		tot_amt = 0
		
		'    For num = 0 To Grid1.Rows - 1
		'    Grid1.Row = num
		'    Grid1.Col = 3
		'    tot_amt = tot_amt + Val(Grid1.Text)
		'    Next
		
		txtfields(6).Text = CStr(Val(txtfields(8).Text) + Val(txtfields(13).Text) - tot_amt) ' - Val(txtFields(14))
        txtfields(6).Text = Format(txtfields(6).Text, "###0.00")
		
	End Sub
	
	Public Sub check_alloc_tot()
		tot_amt = 0
		check_alloc_comp = "N"
		
        saved_amount = CDec(Val(txtfields(8).Text) + Val(txtfields(13).Text)) 'ck + disc
		
        'tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
        'tmp1set = tmpdb.OpenRecordset("cash_tmp", dao.RecordsetTypeEnum.dbOpenDynaset)
		
		'cash_Tmp.Recordset.Refresh 'here adding up $ for a check in cash_tmp
        'Do While Not tmp1set.EOF
        '	tot_amt = tot_amt + tmp1set.Fields("chk_alloc").Value '
        '	tmp1set.MoveNext()
        'Loop 

        'If tot_amt = saved_amount Then 'And tot_amt <> 0 Then
        '	check_alloc_comp = "Y"
        'End If

        '' If tot_amt > saved_amount Then
        '' check_alloc_comp = "NEG"
        '' End If


        'txtfields(6).Text = CStr(saved_amount - tot_amt)
        'txtfields(6).Text = VB6.Format(txtfields(6).Text, "###0.00")

        ''UPGRADE_NOTE: Object tmp1set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'tmp1set = Nothing
		
	End Sub
	Public Sub pay_mult_line_inv()
		
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.AddNew()
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("chk_alloc").Value = invoice.Recordset.Fields("bal_Due").Value
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("bank_key").Value = txtfields(0).Text
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("encum_date").Value = pr_start_date1.Text
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("batch_num").Value = txtfields(15).Text
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("batch_date").Value = pr_start_date1.Text
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("batch_desc").Value = txtfields(10).Text
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("batch_total").Value = Val(bat_Amt.Text)
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("entry_date").Value = Today

        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("name_key").Value = invoice.Recordset.Fields("name_key").Value
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("screen_nam").Value = invoice.Recordset.Fields("screen_nam").Value
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("sort_name").Value = invoice.Recordset.Fields("sort_name").Value
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("chk_num").Value = "Wire"

        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("entry_num").Value = saved_entry_num
        'saved_entry_num = saved_entry_num + 1

        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("chk_date").Value = pr_start_date1.Text

        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("gross_amt").Value = txtfields(6).Text
        ''          cash_Tmp1.Recordset.Fields("chk_disc") = bat_Amt
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("check_amt").Value = txtfields(6).Text
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("inv_num").Value = invoice.Recordset.Fields("inv_num").Value
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("line_num").Value = invoice.Recordset.Fields("line_num").Value
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("invoice").Value = invoice.Recordset.Fields("invoice").Value
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("trans_code").Value = "PMT"
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("cr_acct_nu").Value = invoice.Recordset.Fields("cr_acct_nu").Value
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.Fields("dr_acct_nu").Value = invoice.Recordset.Fields("dr_acct_nu").Value
        ''           cash_Tmp1.Recordset.Fields("disc_acct") = txtFields(10)
        'If entry_type = "ADD" Then
        '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	cash_tmp1.Recordset.Fields("s_m").Value = "S"
        'End If
        ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.Recordset.update()
		
	End Sub
	
	
	Private Sub cmdUpdate_Click()
		'check for completeness of extra data
		
		If Val(txtfields(14).Text) <> 0 Then 'advance pmts to cash
			'check either memo or inv
			
			If Len(txtfields(17).Text) = 0 Then ' a donor payment or else
				If Len(txtfields(11).Text) = 0 Then 'this is a prepayment
					MsgBox("You must enter either a memo or invoice number")
					Exit Sub
					
				Else 'write out the cash record and the new invoice record
					' cash_tmp.Recordset.AddNew
					'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("bank_key").Value = txtfields(0).Text
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("encum_date").Value = txtfields(1).Text
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("name_key").Value = txtfields(2).Text
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("screen_nam").Value = txtfields(3).Text
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("sort_name").Value = selected_sort_name
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("chk_num").Value = txtfields(4).Text
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("chk_Date").Value = txtfields(5).Text
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("invoice").Value = txtfields(7).Text
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("check_amt").Value = Val(txtfields(8).Text)
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("batch").Value = txtfields(10).Text 'added 6/10/98 lhw
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("inv_num").Value = Val(txtfields(11).Text)
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("line_num").Value = 1
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("trans_code").Value = "ADV"
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("chk_Disc").Value = Val(txtfields(13).Text)
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("chk_alloc").Value = Val(txtfields(14).Text)
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("dr_acct_nu").Value = bank_dr_acct_nu ' debit to cash ac
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("cr_Acct_nu").Value = cust_dr_acct_nu ' credit to control
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("disc_acct").Value = cust_disc_acct 'in ar mod 4/29/98 lhw
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("memo").Value = txtfields(17).Text
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("donor").Value = txtfields(18).Text
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("entry_Date").Value = txtfields(19).Text
                    'If entry_type = "ADD" Then
                    '	'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    '	cash_tmp.Recordset.Fields("s_m").Value = "S"
                    'End If
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.update()
				End If
			Else 'write out the cash record for donor etc
				
				If Len(txtfields(16).Text) = 0 Then
					MsgBox("You must enter an account number")
					Exit Sub
				End If
				'cash table
				'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.AddNew()
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("bank_key").Value = txtfields(0).Text
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("encum_date").Value = txtfields(1).Text
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("name_key").Value = txtfields(2).Text
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("screen_nam").Value = txtfields(3).Text
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("sort_name").Value = selected_sort_name
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("chk_num").Value = txtfields(4).Text
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("chk_Date").Value = txtfields(5).Text
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("invoice").Value = txtfields(7).Text
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("check_amt").Value = Val(txtfields(8).Text)
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("batch").Value = txtfields(10).Text
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("inv_num").Value = Val(txtfields(11).Text)
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("line_num").Value = 1
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("chk_Disc").Value = Val(txtfields(13).Text)
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("chk_alloc").Value = Val(txtfields(14).Text)
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("dr_acct_nu").Value = bank_dr_acct_nu 'sbe from bank dr-pref
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("cr_Acct_nu").Value = txtfields(16).Text
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("disc_acct").Value = invoice_disc_acct 's/be from cust disc_acct
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("memo").Value = txtfields(17).Text
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("donor").Value = txtfields(18).Text
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("entry_Date").Value = txtfields(19).Text
                'If entry_type = "ADD" Then
                '	'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '	cash_tmp.Recordset.Fields("s_m").Value = "S"
                'End If
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.update()
			End If
			
		End If
		'we now write out the cash record for the paid invoices
		'we need to cycle thru and write a record for each item paid
        'tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
        'tmpset = tmpdb.OpenRecordset("invoice", dao.RecordsetTypeEnum.dbOpenDynaset)
		
		'    For num = 0 To Grid1.Rows - 1
		'    Grid1.Row = num
		'    Grid1.Col = 3
		'    If Val(Grid1.Text) <> 0 Then
		'    cash_Tmp.Recordset.AddNew
		'    cash_Tmp.Recordset.Fields("chk_alloc") = Val(Grid1.Text)
		'    Grid1.Col = 0
		'    cash_Tmp.Recordset.Fields("inv_num") = Val(Grid1.Text)
		'    sqlstmnt = "inv_num = " & Val(Grid1.Text)
		'    Grid1.Col = 1
		'    cash_Tmp.Recordset.Fields("line_num") = Val(Grid1.Text)
		'    sqlstmnt = sqlstmnt & " and line_num = " & Val(Grid1.Text)
		'    Grid1.Col = 2
		'    cash_Tmp.Recordset.Fields("invoice") = Grid1.Text
		'    Grid1.Col = 5
		'    cash_Tmp.Recordset.Fields("trans_Code") = "PMT"
		'    cash_Tmp.Recordset.Fields("memo") = ""
		'    cash_Tmp.Recordset.Fields("donor") = ""
		'    Grid1.Col = 10
		'    cash_Tmp.Recordset.Fields("dr_Acct_nu") = bank_dr_acct_nu ' bank acct#
		'    Grid1.Col = 10  ' the dr record in invoice
		'    cash_Tmp.Recordset.Fields("cr_Acct_nu") = cust_dr_acct_nu 'Grid1.Text 'control ac
		'
		'        cash_Tmp.Recordset.Fields("bank_key") = txtfields(0)
		'        cash_Tmp.Recordset.Fields("encum_date") = txtfields(1) 'deposit date
		'        cash_Tmp.Recordset.Fields("name_key") = txtfields(2)
		'        cash_Tmp.Recordset.Fields("screen_nam") = txtfields(3)
		'        cash_Tmp.Recordset.Fields("sort_name") = selected_sort_name
		'        cash_Tmp.Recordset.Fields("chk_num") = txtfields(4)
		'        cash_Tmp.Recordset.Fields("chk_Date") = txtfields(5)
		'        cash_Tmp.Recordset.Fields("check_amt") = Val(txtfields(8))
		'         cash_Tmp.Recordset.Fields("batch") = txtfields(10)
		'        If cash_Tmp.Recordset.Fields("line_num") = 1 Then            ' for the discount on line 1 only
		'        cash_Tmp.Recordset.Fields("chk_Disc") = Val(txtfields(13))
		'        Else
		'        cash_Tmp.Recordset.Fields("chk_Disc") = 0
		'        End If
		'        cash_Tmp.Recordset.Fields("entry_Date") = txtfields(19)
		'        cash_Tmp.Recordset.Fields("disc_acct") = invoice_disc_acct 's/be from cust disc_acct
		'        If entry_type = "ADD" Then
		'             cash_Tmp.Recordset.Fields("s_m") = "S"
		'             End If
		'        cash_Tmp.Recordset.update
		'        'tmpset is invoice
		'   tmpset.FindFirst sqlstmnt
		'   tmpset.edit
		'        tmpset.Fields("paid_date") = txtfields(1)
		'        tmpset.Fields("chk_num") = txtfields(4)
		'        tmpset.Fields("bank_key") = txtfields(0)
		'        tmpset.Fields("bank_name") = Text1.Text
		'        Grid1.Col = 3
		'        tmpset.Fields("pay_amt") = Val(Grid1.Text)
		'        tmpset.Fields("bal_due") = tmpset.Fields("bal_due") - Val(Grid1.Text)
		'        If tmpset.Fields("bal_Due") = 0 Then
		'        tmpset.Fields("paid") = "Y"
		'        End If
		'    tmpset.update
		'
		'    End If
		'    Next
		'
		'   On Error Resume Next
		'   For num = 2 To 18
		'   txtfields(num) = ""
		'   Next
		'    On Error GoTo 0
		'
		'    'clear the grid
		'     For num = Grid1.Rows - 1 To 1 Step -1
		'    Grid1.RemoveItem num
		'    Next
		'
		' txtfields(2).SetFocus
		
	End Sub
	
	Private Sub bat_Amt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bat_Amt.Enter
		Call ets_set_selected()
	End Sub
	
	Private Sub bat_Amt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles bat_Amt.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
		If KeyAscii = 13 Or KeyAscii = 9 Then
			'UPDATE the whole batch for any changes
            bat_Amt.Text = Format(bat_Amt.Text, "FIXED")
			tot_amt = 0
			'UPGRADE_ISSUE: Data property cash_tmp1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'cash_tmp1.recordsource = "Select * from cash_Tmp1 where batch_num = " & selected_bat_num
            'cash_tmp1.Refresh()
            ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Do While Not cash_tmp1.Recordset.EOF
            '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '	cash_tmp1.Recordset.edit()
            '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '	cash_tmp1.Recordset.Fields("batch_total").Value = bat_Amt.Text
            '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '	tot_amt = tot_amt + cash_tmp1.Recordset.Fields("chk_Alloc").Value
            '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '	cash_tmp1.Recordset.update()
            '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '	cash_tmp1.Recordset.MoveNext()
            'Loop 

            'cash_tmp1.Refresh()
			'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '	If cash_tmp1.Recordset.EOF Then
            '		unapp.Text = VB6.Format(bat_Amt.Text, "FIXED")
            '	Else
            '		'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '		unapp.Text = VB6.Format(cash_tmp1.Recordset.Fields("batch_total").Value - tot_amt, "FIXED")
            '	End If

            '	txtfields(0).Focus()
            '	KeyAscii = 0
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
	End Sub
	
	Private Sub bat_Amt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bat_Amt.Leave
		bat_Amt.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub frmar_cash1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
	
		
		function_type = "DATA_ENTRY"
		'  Grid1.AddItem "Inv num" & Chr(9) & "line num" & Chr(9) & "Invoice" & Chr(9) & "pay_amt" & Chr(9) & "bal_due" & Chr(9) & "trans" & Chr(9) & "po_num" & Chr(9) & "cc_num" & Chr(9) & "cc_name" & Chr(9) & "inv_desc" & Chr(9) & "dr_acct_nu" & Chr(9) & "cr_acct_nu" & Chr(9) & "alloc_amt" & Chr(9) & "inv date" & Chr(9) & "inv amt", 0
		
		' txtFields(15) =
		txtfields(1).Text = CStr(Today)
		txtfields(19).Text = CStr(Today)
		
		'    Grid1.ColWidth(0) = 720   'inv num
		'    Grid1.ColWidth(1) = 720    'inv_line
		'    Grid1.ColWidth(2) = 1500   'invoice
		'    Grid1.ColWidth(3) = 1000   'pay_amt
		'    Grid1.ColWidth(4) = 1000   'bal_due
		'    Grid1.ColWidth(5) = 1000        'pay amnt calculated
		'    Grid1.ColWidth(6) = 500    'po_num
		'    Grid1.ColWidth(7) = 500   'cc_num
		'    Grid1.ColWidth(8) = 3000    'cc_name
		'    Grid1.ColWidth(9) = 1000   'inv_desc
		'    Grid1.ColWidth(10) = 1200  'dr_acct_nu
		'    Grid1.ColWidth(11) = 1200  'cr_acct_nu
		'    Grid1.ColWidth(12) = 1000  'alloc_amt
		'    Grid1.ColWidth(13) = 1200  'inv_date
		'    Grid1.ColWidth(14) = 1000  'inv_amt
		'
		Select Case entry_type
			
			Case "ADD"
				
				Call batch_number_Create()
				
				bat_Amt.Text = CStr(0)
				txtfields(23).Text = CStr(selected_bat_num)
				
				pr_start_date1.Text = CStr(Today)
				txtfields(24).Text = CStr(1)
				
				'check the deposit number for only one per day
				'UPGRADE_ISSUE: Data property cash_tmp1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp1.recordsource = "Select * from cash_Tmp1 where batch_date = " & Chr(35) & pr_start_date1.Text & Chr(35) & " order by batch_Desc"
                'cash_tmp1.Refresh()
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Do While Not cash_tmp1.Recordset.EOF
                '	txtfields(24).Text = CStr(CDbl(txtfields(24).Text) + 1)
                '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '	cash_tmp1.Recordset.MoveNext()
                '		Loop 
                txtfields(24).Text = CStr(txtfields(24).Text)


                'UPGRADE_ISSUE: Data property cash_tmp1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp1.recordsource = "Select * from cash_Tmp1 where batch_num = " & selected_bat_num
                'cash_tmp1.Refresh()

                'cash_Tmp.Refresh()
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_Tmp.Recordset.AddNew()
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_Tmp.Recordset.Fields("trans_code").Value = "PMT"
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_Tmp.Recordset.Fields("encum_Date").Value = pr_start_date1.Text
                txtfields(1).Text = pr_start_date1.Text
                txtfields(10).Visible = False
                '    lblLabels(10).Visible = False

                'to turn fields off
            Case "EDIT"
                'fill the fields from the batch
                sqlstmnt = "Select * from cash_Tmp1 where batch_num = " & selected_bat_num
                'UPGRADE_ISSUE: Data property cash_tmp1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp1.recordsource = sqlstmnt
                'cash_tmp1.Refresh()
                ''        cash_Tmp1.Recordset.MoveLast
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'pr_start_date1.Text = cash_tmp1.Recordset.Fields("batch_date").Value & ""
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'txtfields(23).Text = cash_tmp1.Recordset.Fields("batch_num").Value
                ''        txtFields(10) = cash_Tmp1.Recordset.Fields("batch_desc")
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'bat_Amt.Text = cash_tmp1.Recordset.Fields("batch_total").Value
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'txtfields(0).Text = cash_tmp1.Recordset.Fields("bank_key").Value
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'txtfields(9).Text = cash_tmp1.Recordset.Fields("dr_acct_nu").Value ' lhw 11/13/98
                ''Call bat_tot

                ''turn off fields after they are filled
                ''  Grid1.Enabled = False   'all editing done below the grid
                ''check amount
                ''UPGRADE_ISSUE: Data property cash_tmp.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_Tmp.recordsource = "select * from cash_Tmp1 where batch_num = " & selected_bat_num & " and entry_num = " & saved_entry_num
                'cash_Tmp.Refresh()
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_Tmp.Recordset.edit()

                ' cash_Tmp.Recordset.Edit
            Case "ADD_EDIT"

                'UPGRADE_ISSUE: Data property cash_tmp1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp1.recordsource = "Select * from cash_Tmp1 order by entry_num"
                'cash_tmp1.Refresh()

                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'If cash_tmp1.Recordset.EOF Then
                '    saved_entry_num = 1
                'Else
                '    'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '    cash_tmp1.Recordset.MoveLast()
                '    'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '    saved_entry_num = cash_tmp1.Recordset.Fields("entry_num").Value + 1
                'End If

                'fill the fields from the batch
                sqlstmnt = "Select * from cash_Tmp1 where batch_num = " & selected_bat_num
                'UPGRADE_ISSUE: Data property cash_tmp1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp1.recordsource = sqlstmnt
                'cash_tmp1.Refresh()

                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'pr_start_date1.Text = cash_tmp1.Recordset.Fields("batch_date").Value & ""
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'txtfields(23).Text = cash_tmp1.Recordset.Fields("batch_num").Value
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'txtfields(24).Text = cash_tmp1.Recordset.Fields("batch_desc").Value
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'bat_Amt.Text = cash_tmp1.Recordset.Fields("batch_total").Value
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'txtfields(0).Text = cash_tmp1.Recordset.Fields("bank_key").Value

                Call bank_nameget(txtfields(0).Text) 'this is the bank
                txtfields(9).Text = bank_dr_acct_nu
                Text1.Text = bank_screen_nam 'selected_screen_nam


        End Select
		
        '	tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
        '	workdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
        '	tmpset = tmpdb.OpenRecordset("invoice", dao.RecordsetTypeEnum.dbOpenDynaset)
		' Set cash_Tmp = tmpdb.OpenRecordset("cash_tmp", dbOpenDynaset)
		
	End Sub
	
	'Private Sub Grid1_Click()
	'
	'         'move bal due to paid amount
	'        If Grid1.Row = 0 Then
	'        Exit Sub
	'        End If
	'
	'        Grid1.Col = 0
	'        selected_inv_num = Grid1.Text
	'
	'        Grid1.Col = 4
	'        tot_amt = Val(Grid1.Text)
	'        Grid1.Col = 3
	'        Grid1.Text = tot_amt
	'        Grid1.Col = 3
	'        txtfields(14) = Format(Val(Grid1.Text), "FIXED")
	'
	'        msg = Grid1.Row
	'        Grid1.Row = msg
	'
	'        Grid1.Col = 0
	'        sqlstmnt = "inv_num = " & Val(Grid1.Text)
	'        Grid1.Col = 1
	'        sqlstmnt = sqlstmnt & " and line_num = " & Val(Grid1.Text)
	'
	'        tmpset.FindFirst sqlstmnt
	'
	'        txtfields(7) = tmpset.Fields("invoice") & ""
	'        txtfields(11) = tmpset.Fields("inv_num")
	'        txtfields(16) = tmpset.Fields("dr_acct_nu") 'credit to the ar control ac
	'        txtfields(9) = bank_dr_acct_nu 'sbe from bank dr-pref  'lhw99
	'        txtfields(15) = invoice_disc_acct
	'        txtfields(21) = tmpset.Fields("line_num")
	'
	'        If Len(txtfields(9)) = 0 Then
	'        txtfields(9).SetFocus
	'        Exit Sub
	'        End If
	'
	'         If Len(txtfields(16)) = 0 Then
	'        txtfields(16).SetFocus
	'        Exit Sub
	'        End If
	'
	'      Grid1.SelStartCol = 3
	'        Grid1.SelStartRow = msg
	'        Grid1.SelEndCol = 3
	'        Grid1.SelEndRow = msg
	'        Call sub_Tot
	'        Call check_comp
	'
	'End Sub
	'
	'Private Sub Grid1_DblClick()
	'
	'
	'    If Grid1.Row = 0 Then
	'    Exit Sub
	'    End If
	'
	'      Grid1.Row = msg
	'       Grid1.Col = 0
	'    selected_inv_num = Grid1.Text
	'
	'    Dim bal As Currency
	'     'this allows you to edit this field's value
	'
	'    bal = Val(InputBox("Amount of this invoice to be paid"))
	'    Grid1.Col = 3
	'    Grid1.Text = bal
	'
	'     txtfields(14) = Format(Val(Grid1.Text), "FIXED")
	'
	'      Grid1.SelStartCol = 3
	'        Grid1.SelStartRow = msg
	'        Grid1.SelEndCol = 3
	'        Grid1.SelEndRow = msg
	'
	'        Call sub_Tot
	'        Call check_comp
	'
	'End Sub
	'
	'Private Sub Grid1_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
	'      'telling the system a selection has been made
	'    selectedcell = True
	'
	'End Sub
	
	Private Sub pr_Start_date1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_Start_date1.Enter
		Call ets_set_selected()
		
		Select Case entry_type
			Case "EDIT"
				
				pr_start_date1.Enabled = False
				txtfields(23).Enabled = False
				'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'pr_start_date1.Text = cash_tmp1.Recordset.Fields("batch_date").Value & ""
                'txtfields(23).Text = CStr(selected_bat_num)
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'txtfields(24).Text = cash_tmp1.Recordset.Fields("batch_desc").Value & ""
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'bat_Amt.Text = VB6.Format(cash_tmp1.Recordset.Fields("batch_total").Value, "FIXED")
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'txtfields(0).Text = cash_tmp1.Recordset.Fields("bank_key").Value & ""
                ''     Call bat_tot
				
				bat_Amt.Focus()
				
			Case "ADD_EDIT"
				pr_start_date1.Enabled = False
				txtfields(23).Enabled = False
				'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'pr_start_date1.Text = cash_tmp1.Recordset.Fields("batch_date").Value & ""
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'txtfields(1).Text = cash_tmp1.Recordset.Fields("batch_date").Value & "" 'lhw11/13/98
                'txtfields(23).Text = CStr(selected_bat_num)
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'txtfields(24).Text = cash_tmp1.Recordset.Fields("batch_desc").Value & ""
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'bat_Amt.Text = VB6.Format(cash_tmp1.Recordset.Fields("batch_total").Value, "FIXED")
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'txtfields(0).Text = cash_tmp1.Recordset.Fields("bank_key").Value & ""
                ''     Call bat_tot
				
				bat_Amt.Focus()
				
		End Select
		
	End Sub
	
	Private Sub pr_Start_date1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_Start_date1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
		If KeyAscii = 13 Then
			valid_Date = "N"
			senddate = pr_start_date1.Text
            Call etsdate(senddate, CStr(retdate))
			
			If valid_Date <> "N" Then
				If Len(senddate) = 0 Then
					MsgBox("You must enter a date")
					Call ets_set_selected()
					GoTo EventExitSub
				End If
				
				pr_Start_date = CDate(retdate)
                pr_start_date1.Text = CStr(retdate)
				selected_start_date = CDate(retdate)
				pr_start_date1.Text = CStr(CDate(pr_start_date1.Text))
				txtfields(1).Text = CStr(CDate(pr_start_date1.Text)) ' lhw 11/13/98
				System.Windows.Forms.SendKeys.Send("{tab}")
				KeyAscii = 0
			Else
				MsgBox("Bad date")
				Call ets_set_selected()
				GoTo EventExitSub
			End If
		End If
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub pr_Start_date1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_Start_date1.Leave
		pr_start_date1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	
	Private Sub Save_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Save.Click
		
		Call check_comp()
		
		If Val(txtfields(13).Text) <> 0 Then 'disc amt
			If Len(txtfields(15).Text) = 0 Then 'disc acct
				MsgBox("Disc Account must be filled in!")
				txtfields(15).Focus()
				Exit Sub
			End If
			
		End If
		
		'check for either an invoice or donor
		'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'If Val(txtfields(11).Text) = 0 And cash_tmp1.Recordset.Fields("s_m").Value = "S" Then 'no invoice
        '	If Len(txtfields(18).Text) = 0 Then 'donor
        '		If Len(txtfields(17).Text) = 0 Then 'memo
        '			MsgBox("Either an invoice or donor/memo fields must be filled in.")
        '			txtfields(18).Focus()
        '			Exit Sub
        '		End If
        '	End If
        'End If
		
		valid_acct = " N "
        Call etsacctnum_chk(txtfields(16).Text)
		
		If valid_acct = "N" Then
			MsgBox("Invalid CR account number!")
			Exit Sub
		End If
        Call etsacctnum_chk(txtfields(9).Text)
		
		If valid_acct = "N" Then
			MsgBox("Invalid DR account number!")
			Call ets_set_selected()
			Exit Sub
		End If
		
		
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(0) = txtfields(0).Text ' these lines put header record in hold
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(1) = txtfields(1).Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(2) = txtfields(2).Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(4) = txtfields(4).Text 'check number
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(5) = txtfields(5).Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(8). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(8) = txtfields(8).Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(13). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(13) = txtfields(13).Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(10). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(10) = txtfields(10).Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(6) = txtfields(6).Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(9). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(9) = txtfields(9).Text
		
		If entry_type = "ADD" Then
			'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '	cash_tmp.Recordset.Fields("s_m").Value = "S"
		End If
		'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp.Recordset.update()
		
		If entry_type = "EDIT" Then
			Me.Close() 'out of here
			Exit Sub
		End If
		
        ''UPGRADE_WARNING: Couldn't resolve default property of object hold(0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'txtfields(0).Text = hold(0) 'these lines write hold to header
        ''UPGRADE_WARNING: Couldn't resolve default property of object hold(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'txtfields(1).Text = hold(1)
        ''   txtFields(2) = hold(2) leave name key as different
        ''UPGRADE_WARNING: Couldn't resolve default property of object hold(4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'txtfields(4).Text = hold(4)
        ''UPGRADE_WARNING: Couldn't resolve default property of object hold(5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'txtfields(5).Text = hold(5)
        ''UPGRADE_WARNING: Couldn't resolve default property of object hold(8). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'txtfields(8).Text = hold(8)
        ''UPGRADE_WARNING: Couldn't resolve default property of object hold(13). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'txtfields(13).Text = hold(13)
        ''UPGRADE_WARNING: Couldn't resolve default property of object hold(9). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'txtfields(9).Text = hold(9)
		
		Call check_alloc_tot()
		
		Select Case check_alloc_comp
			
			Case "Y"
				'If check_alloc_comp = "Y" Then  'check is completely allocated
				'if yes write to cash_tmp1
				'must cycle thru cash tmp
				'no need to check multiple line invoices since handled separately
				
                '		cash_tmp.Refresh()
				'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '	cash_tmp.Recordset.MoveFirst()
				'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Do While Not cash_tmp.Recordset.EOF

                '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '	cash_tmp1.Recordset.AddNew()

                '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '	For num = 0 To cash_tmp1.Recordset.Fields.Count - 1
                '		'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '		'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '		cash_tmp1.Recordset.Fields(num).Value = cash_tmp.Recordset.Fields(num).Value
                '	Next 
                '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '	cash_tmp1.Recordset.Fields("batch_num").Value = txtfields(23).Text
                '	selected_bat_num = CInt(txtfields(23).Text)
                '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '	cash_tmp1.Recordset.Fields("batch_date").Value = pr_start_date1.Text
                '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '	cash_tmp1.Recordset.Fields("batch_desc").Value = txtfields(24).Text
                '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '	cash_tmp1.Recordset.Fields("batch_total").Value = Val(bat_Amt.Text)
                '	If entry_type = "ADD" Then
                '		'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '		cash_tmp1.Recordset.Fields("s_m").Value = "S"
                '	End If
                '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '	cash_tmp1.Recordset.update()
                '	'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '	cash_tmp.Recordset.MoveNext()


                'Loop 
				
				'here we calculated the unapplied balance
				'UPGRADE_ISSUE: Data property cash_tmp1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp1.recordsource = "Select * from cash_Tmp1 where batch_num = " & selected_bat_num

                'cash_tmp1.Refresh()
                'tot_amt = 0
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'Do While Not cash_tmp1.Recordset.EOF
                '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '	tot_amt = tot_amt + cash_tmp1.Recordset.Fields("chk_Alloc").Value
                '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                '	cash_tmp1.Recordset.MoveNext()
                'Loop 
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp1.Recordset.MoveLast()
                ''UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'unapp.Text = VB6.Format(cash_tmp1.Recordset.Fields("batch_total").Value - tot_amt, "FIXED")
                'If CDbl(unapp.Text) < 0 Then
                '	MsgBox("You have exceeded your batch total.")
                'End If
				
				Response = MsgBox("Do you want to enter another check?", MsgBoxStyle.YesNo)
				If Response = 7 Then
					Me.Close() 'no
					Exit Sub
				End If
				
				If Response = 6 Then
					
					On Error Resume Next
					cash_tmp.Refresh()
					
					'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'Do While Not cash_tmp.Recordset.EOF
                    '	'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    '	cash_tmp.Recordset.delete()
                    '	'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    '	cash_tmp.Recordset.MoveNext()
                    'Loop 
					
					
					On Error GoTo 0
					
					txtfields(4).Focus()
					'cash_Tmp.Recordset.Refresh
					'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.AddNew()
                    ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'cash_tmp.Recordset.Fields("trans_code").Value = "PMT"
                    ''UPGRADE_WARNING: Couldn't resolve default property of object hold(0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'txtfields(0).Text = hold(0)
                    ''UPGRADE_WARNING: Couldn't resolve default property of object hold(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'txtfields(1).Text = hold(1)
                    'txtfields(6).Text = CStr(0)
                    'txtfields(19).Text = CStr(Today)
                    ''UPGRADE_WARNING: Couldn't resolve default property of object hold(9). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'txtfields(9).Text = hold(9)

                    ''UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'saved_entry_num = hold(10) + 1
					txtfields(10).Text = CStr(saved_entry_num) 'entry# turned off in add
				End If
				
			Case "N"
				'    Else    'do another record for the check
				MsgBox("The check has not been fully applied.  Please continue.")
				txtfields(2).Focus()
                'cash_tmp.Refresh()
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.AddNew()
                ''UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'cash_tmp.Recordset.Fields("trans_code").Value = "PMT"
                ''UPGRADE_WARNING: Couldn't resolve default property of object hold(0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'txtfields(0).Text = hold(0)
                ''UPGRADE_WARNING: Couldn't resolve default property of object hold(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'txtfields(1).Text = hold(1)
                ''UPGRADE_WARNING: Couldn't resolve default property of object hold(2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'txtfields(2).Text = hold(2)
                ''UPGRADE_WARNING: Couldn't resolve default property of object hold(4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'txtfields(4).Text = hold(4)
                ''UPGRADE_WARNING: Couldn't resolve default property of object hold(5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'txtfields(5).Text = hold(5)
                ''UPGRADE_WARNING: Couldn't resolve default property of object hold(8). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'txtfields(8).Text = hold(8)
                ''UPGRADE_WARNING: Couldn't resolve default property of object hold(13). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'txtfields(13).Text = hold(13)
                ''UPGRADE_WARNING: Couldn't resolve default property of object hold(10). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'txtfields(10).Text = hold(10) + 1
                ''UPGRADE_WARNING: Couldn't resolve default property of object hold(9). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'txtfields(9).Text = hold(9)
				
			Case "NEG"
				Response = MsgBox("Amount applied exceeds check amount. Select Yes to correct.", MsgBoxStyle.YesNo)
				'clear the grid
				'    For num = 1 To Grid1.Rows - 1
				'    Grid1.RemoveItem num
				'    Next
				
				num = 1
				If Response = 6 Then 'this is yes or 6 = yes
					
					'UPGRADE_WARNING: Couldn't resolve default property of object hold(0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'txtfields(0).Text = hold(0) 'these lines write hold to header
                    ''UPGRADE_WARNING: Couldn't resolve default property of object hold(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'txtfields(1).Text = hold(1)
                    ''UPGRADE_WARNING: Couldn't resolve default property of object hold(2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'txtfields(2).Text = hold(2) 'leave name key as different
                    ''UPGRADE_WARNING: Couldn't resolve default property of object hold(4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'txtfields(4).Text = hold(4)
                    ''UPGRADE_WARNING: Couldn't resolve default property of object hold(5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'txtfields(5).Text = hold(5)
                    ''UPGRADE_WARNING: Couldn't resolve default property of object hold(8). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'txtfields(8).Text = hold(8)
                    ''UPGRADE_WARNING: Couldn't resolve default property of object hold(13). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'txtfields(13).Text = hold(13)
                    ''UPGRADE_WARNING: Couldn't resolve default property of object hold(9). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'txtfields(9).Text = hold(9)
                    'invoice.Refresh()
                    ''UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'Response = invoice.Recordset.Fields("inv_num").Value
                    ''UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'Do While Not invoice.Recordset.EOF
                    '	'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    '	bal_Due = invoice.Recordset.Fields("bal_Due").Value

                    '	bal_Due = CDec(VB6.Format(bal_Due, "FIXED"))
                    '	'    Grid1.AddItem invoice.Recordset.Fields("inv_num") & Chr(9) & invoice.Recordset.Fields("line_num") & Chr(9) & invoice.Recordset.Fields("invoice") & Chr(9) & "0" & Chr(9) & bal_Due & Chr(9) & invoice.Recordset.Fields("trans_code") & Chr(9) & invoice.Recordset.Fields("po_num") & Chr(9) & invoice.Recordset.Fields("cc_num") & Chr(9) & invoice.Recordset.Fields("cc_name") & Chr(9) & invoice.Recordset.Fields("inv_Desc") & Chr(9) & invoice.Recordset.Fields("dr_acct_nu") & Chr(9) & invoice.Recordset.Fields("cr_Acct_nu") & Chr(9) & invoice.Recordset.Fields("alloc_amt") & Chr(9) & invoice.Recordset.Fields("invoice_Date") & Chr(9) & invoice.Recordset.Fields("inv_Amt"), num
                    '	'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    '	invoice.Recordset.MoveNext()
                    '	num = num + 1

                    'Loop 
					Exit Sub
				End If
				
				
				
		End Select
		
		'    End If
		
		On Error GoTo 0
		
		'    'clear the grid
		'     For num = Grid1.Rows - 1 To 1 Step -1
		'    Grid1.RemoveItem num
		'    Next
		
		
	End Sub
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
		
		If Index = 0 Then
			txtfields(10).Text = CStr(saved_entry_num)
		End If
		
		If entry_type <> "EDIT" Then
			txtfields(1).Text = pr_start_date1.Text
		End If
		' txtFields(19) = Date
		'if edit then fill the form else it is blank
		'    If entry_type = "EDIT" Then
		'   cash_Tmp.RecordSource = "select * from cash_Tmp1 where entry_num = " & saved_entry_num
		'  cash_Tmp.Refresh
		' cash_Tmp.Recordset.Edit
		'Else
		'    cash_tmp.recordset.AddNew
		'End If
		
		' End If
		
		Call ets_set_selected()
		If Index = 2 Then
			On Error GoTo 0
			
			'    'clear the grid
			'     For num = Grid1.Rows - 1 To 1 Step -1
			'    Grid1.RemoveItem num
			'    Next
		End If
		
	End Sub
	
	
	Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			Select Case Index
				
				Case 0 'bank key
					package_Type_saved = package_Type
					package_Type = "GL"
					valid_name = "N"
						selected_name_key = ""
					
					If Val(txtfields(Index).Text) = 0 Then
                        frmnamechk.ShowDialog()
                        txtfields(Index).Text = selected_name_key
						Text1.Text = selected_screen_nam
					End If
					
                    Call chkname(txtfields(Index).Text)
					package_Type = package_Type_saved
					
					
					If valid_name = "N" Then
						Text1.Text = ""
						MsgBox(" Invalid Bank Number")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					Text1.Text = selected_screen_nam
                    Call bank_nameget(txtfields(Index).Text) 'this is the bank
					txtfields(9).Text = bank_dr_acct_nu
					
				Case 2
					
					valid_name = "N"
					selected_name_key = ""
					package_Type_saved = package_Type
					package_Type = "AR"
					
					If Val(txtfields(Index).Text) = 0 Then
                        frmnamechk.ShowDialog()
                        txtfields(Index).Text = selected_name_key
                        txtfields(CShort(Index + 1)).Text = selected_screen_nam
					End If
					
                    Call chkname(txtfields(Index).Text)
					package_Type = package_Type_saved
					
					If valid_name = "N" Then
						txtfields(3).Text = ""
						txtfields(12).Text = ""
						MsgBox("Invalid  Customer Number")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
					txtfields(3).Text = selected_screen_nam
					txtfields(12).Text = selected_sort_name
					
                    Call cust_nameget(txtfields(Index).Text)
					
                    ''UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'invoice.recordsource = "select * from invoice where name_key = " & Chr(34) & txtfields(Index).Text & Chr(34) & " and paid <> ""Y"" and void <> 'Y' order by inv_num, line_num "

                    'invoice.Refresh()
                    'num = 1

                    'MsgBox("Please apply the cash to invoices in the box or use the mouse to move to Other Payment area")
                    ''UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                    'If invoice.Recordset.RecordCount = 0 Then
                    '	MsgBox("There are no open invoices for this customer.  Please enter the data below if the customer number is correct.")

                    '	txtfields(14).Focus()
                    '	GoTo EventExitSub
                    'End If
					
					If entry_type <> "EDIT" Then
						
						txtfields(9).Text = bank_dr_acct_nu 'lhw99
						
						invoice.Refresh()
						'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        'Response = invoice.Recordset.Fields("inv_num").Value
                        ''UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        'Do While Not invoice.Recordset.EOF
                        '	'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        '	bal_Due = invoice.Recordset.Fields("bal_Due").Value

                        '	'here we apply cash_Tmp1 to the grid

                        '	'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        '	sqlstmnt = "select * from cash_tmp1 where inv_num = " & invoice.Recordset.Fields("inv_num").Value
                        '	'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        '	sqlstmnt = sqlstmnt & " and line_num = " & invoice.Recordset.Fields("line_num").Value
                        '	'UPGRADE_ISSUE: Data property cash_tmp1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        '	cash_tmp1.recordsource = sqlstmnt
                        '	cash_tmp1.Refresh()
                        '	'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        '	Do While Not cash_tmp1.Recordset.EOF
                        '		'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        '		bal_Due = bal_Due - cash_tmp1.Recordset.Fields("chk_alloc").Value
                        '		'UPGRADE_ISSUE: Data property cash_tmp1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        '		cash_tmp1.Recordset.MoveNext()
                        '	Loop 

                        '	'here we apply cash_Tmp1 to the grid
                        '	'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        '	sqlstmnt = "select * from cash_tmp where inv_num = " & invoice.Recordset.Fields("inv_num").Value
                        '	'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        '	sqlstmnt = sqlstmnt & " and line_num = " & invoice.Recordset.Fields("line_num").Value
                        '	rs = workdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
                        '	Do While Not rs.EOF
                        '		bal_Due = bal_Due - rs.Fields("chk_alloc").Value
                        '		rs.MoveNext()
                        '	Loop 

                        '	bal_Due = CDec(VB6.Format(bal_Due, "FIXED"))
                        '	'      Grid1.AddItem invoice.Recordset.Fields("inv_num") & Chr(9) & invoice.Recordset.Fields("line_num") & Chr(9) & invoice.Recordset.Fields("invoice") & Chr(9) & "0" & Chr(9) & bal_Due & Chr(9) & invoice.Recordset.Fields("trans_code") & Chr(9) & invoice.Recordset.Fields("po_num") & Chr(9) & invoice.Recordset.Fields("cc_num") & Chr(9) & invoice.Recordset.Fields("cc_name") & Chr(9) & invoice.Recordset.Fields("inv_Desc") & Chr(9) & invoice.Recordset.Fields("dr_acct_nu") & Chr(9) & invoice.Recordset.Fields("cr_Acct_nu") & Chr(9) & invoice.Recordset.Fields("alloc_amt") & Chr(9) & invoice.Recordset.Fields("invoice_Date") & Chr(9) & invoice.Recordset.Fields("inv_Amt"), num
                        '	'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        '	invoice.Recordset.MoveNext()
                        '	num = num + 1

                        'Loop 
						
					End If
					
				Case 1, 5
					
					valid_Date = "N"
					senddate = txtfields(Index).Text
                    Call etsdate(senddate, CStr(retdate))
					
					If valid_Date <> "N" Then
                        'txtfields(Index).Text = retdate
						txtfields(Index).Text = CStr(CDate(txtfields(Index).Text))
						
					Else
						MsgBox(" Bad Date")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
					If Index = 5 Then 'test for less than deposit date
						'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
						If DateDiff(Microsoft.VisualBasic.DateInterval.Day, CDate(txtfields(1).Text), CDate(txtfields(5).Text)) > 0 Then
							MsgBox("The check date is greater than the deposit date.")
						End If
					End If
					
				Case 7
					txtfields(Index).Text = UCase(txtfields(Index).Text)
					'check the invoice string if match go on else lookup
					
					If Len(txtfields(Index).Text) = 0 Then
						saved_function_Type = function_type
						function_type = "DATA_ENTRY"
						invoicelookup.ShowDialog()
						
						If Val(CStr(selected_inv_num)) = 0 Then
							MsgBox("Not a valid invoice.")
							Call ets_set_selected()
							GoTo EventExitSub
						End If
						'UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        '	invoice.recordsource = "Select * from invoice where inv_num = " & selected_inv_num
                        '	invoice.Refresh()
						'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        '					txtfields(Index).Text = invoice.Recordset.Fields("invoice").Value
						function_type = saved_function_Type
					Else
						
						'UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        '						invoice.recordsource = "Select * from invoice where invoice = " & Chr(34) & txtfields(Index).Text & Chr(34)
						invoice.Refresh()
						
						'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                        '						If invoice.Recordset.EOF Then
                        'MsgBox("This is not a valid invoice ID.")
                        'Call ets_set_selected()
                        'GoTo EventExitSub
                        ' End If
                    End If
				Case 8
                    txtfields(Index).Text = Format(txtfields(Index).Text, "FIXED")
					txtfields(6).Text = txtfields(8).Text
					
				Case 11
					If Len(txtfields(Index).Text) <> 0 Then
						Call chkinv_numverify(txtfields(Index))
						If valid_vouch = "Y" Then
							MsgBox("This is an advance payment.")
							'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                            '		cash_tmp.Recordset.Fields("trans_code").Value = "ADV"
							'Call ets_set_selected          'lhw99
							'Exit Sub
						End If
					End If
					
					save.Focus()
					GoTo EventExitSub
					
				Case 9, 15, 16 'account number checking
					
					txtfields(Index).SelectionStart = 0 'to make sure field is cleared
					valid_acct = "N"
                    Call etsacctnum_chk(txtfields(Index).Text)
					If retacct = acct_num_blank Then GoTo EventExitSub
					If valid_acct = "Y" Then
						txtfields(Index).Text = retacct
						If Index = 9 Then
							txtfields(18).Focus()
							GoTo EventExitSub
						End If
						
					Else
						MsgBox("Invalid acct number - Please re-enter")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
				Case 13
					
					txtfields(Index).Text = CStr(Val(txtfields(Index).Text))
                    txtfields(Index).Text = Format(txtfields(Index).Text, "###0.00")
					'       ' MsgBox "Please apply the cash to invoices in the box or use the mouse to move to Other Payment area"
					'        If Grid1.Rows > 1 Then
					'        Grid1.SelStartCol = 3
					'        Grid1.SelStartRow = 1
					'        Grid1.SelEndCol = 3
					'        Grid1.SelEndRow = 1
					'        End If
					'
				Case 14
					
					Call check_alloc_tot()
                    txtfields(14).Text = Format(txtfields(14).Text, "FIXED")
					
				Case 17, 20
					save.Focus()
					GoTo EventExitSub
					
					
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
	
	Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
		txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub


End Class