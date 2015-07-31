Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class ar_wk_bill
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 4-22-97 -SCS
	'it was copied from vouch entry
	'revised 12/27/2007 lhw
	
	'****************
	
	Dim batch_Amount As Decimal
	
	
	Dim vouch_Done As Integer 'noumber of invoices in this session
	Dim vouchtotaldetail As Object
	Public miss As String
	Public add_sub As Integer
	Public wline As Integer
	Public oldfocus As Integer
	Public flag_set As Integer
	Public retdptglnum As String
	
	Sub putinvoice()
		
		
		num = 0 ' num = 0 is the header record
		'line 1 has the header in it so no need to reinput
		
		
		'the combo boxes are not databound so need to move data in
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Fields("ship_via").Value = ship_via.Text
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Fields("terms").Value = terms.Text
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Fields("entry_Date").Value = ent_Date.Text
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Data1.Recordset.Fields("tot_trans").Value = Val(hold(9)) + Val(hold(10)) + Val(hold(11))
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Data1.Recordset.Fields("tot_inv").Value = Val(hold(12))
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Data1.Recordset.Fields("tot_prod").Value = Val(hold(13))
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Data1.Recordset.Fields("tot_post").Value = Val(hold(14))
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Data1.Recordset.Fields("tot_advp").Value = Val(hold(15))
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object cust_sort_name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Data1.Recordset.Fields("sort_name").Value = cust_sort_name
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Data1.Recordset.Fields("line_num").Value = invoice_detail_grid(num, 0)
		
		On Error Resume Next
		If Err.Number = 3421 Then
			MsgBox("No invoice data entered")
			Exit Sub
		End If
		On Error GoTo 0
		
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Data1.Recordset.Fields("quantity").Value = Val(invoice_detail_grid(num, 4))
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Data1.Recordset.Fields("Prod_num").Value = invoice_detail_grid(num, 1)
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Data1.Recordset.Fields("prod_desc").Value = invoice_detail_grid(num, 2)
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Data1.Recordset.Fields("unit_price").Value = Val(invoice_detail_grid(num, 5))
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Data1.Recordset.Fields("line_Tot").Value = invoice_detail_grid(num, 6)
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Data1.Recordset.Fields("cr_pref_ac").Value = invoice_detail_grid(num, 3)
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Fields("dr_pref_ac").Value = workshop_dr_acct_nu
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.update()
		
		'if more than one line fill an array with the header and move it in
		'num 1 and up are the detail lines
		For num = 1 To max_grid_line - 1
			'   If entry_type = "ADD" Or entry_type = "" Then
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.AddNew()
			'the header
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("inv_num").Value = hold(0)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("inv_date").Value = hold(1)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("name_key").Value = hold(2)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("screen_nam").Value = hold(3)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("purch_num").Value = hold(4)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("reference").Value = hold(5)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("ship_via").Value = hold(6)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(7). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("ship_Date").Value = hold(7)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(8). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("terms").Value = hold(8)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(9). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("ups_Cost").Value = hold(9)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(10). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("our_truck").Value = hold(10)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(11). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("other_out").Value = hold(11)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("tot_trans").Value = 0
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("tot_inv").Value = Val(hold(12))
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("tot_prod").Value = 0
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("tot_post").Value = 0
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("tot_advp").Value = 0
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("entry_Date").Value = ent_Date.Text
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object cust_sort_name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("sort_name").Value = cust_sort_name
			
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("line_num").Value = invoice_detail_grid(num, 0)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("quantity").Value = invoice_detail_grid(num, 4)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("Prod_num").Value = invoice_detail_grid(num, 1)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("prod_desc").Value = invoice_detail_grid(num, 2)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("unit_price").Value = invoice_detail_grid(num, 5)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("line_Tot").Value = invoice_detail_grid(num, 6)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("cr_pref_ac").Value = invoice_detail_grid(num, 3)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("dr_pref_ac").Value = workshop_dr_acct_nu
			'9-16-04 not used in workshop
			'Data1.Recordset.Fields("from_date") = hold(1)
			'Data1.Recordset.Fields("to_date") = hold(1)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.update()
			
		Next 
	End Sub
	
	Private Sub dell_bill_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dell_bill.Click
		Response = MsgBox("Do you really want to delete this Bill?", MsgBoxStyle.YesNo)
		If Response = MsgBoxResult.No Then Exit Sub
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not Data1.Recordset.EOF
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.delete()
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.MoveNext()
		Loop 
		Me.Close()
		arwk_bill_Ed1.Show()
	End Sub
	
	Private Sub other_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles other.Enter
		Call ets_set_selected()
		
	End Sub
	
	Private Sub other_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles other.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			other.Text = VB6.Format(other.Text, "###0.00;-###0.00")
			V_line(0).Focus()
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub other_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles other.Leave
		other.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub prod_desc_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prod_desc.Enter
		Dim Index As Short = prod_desc.GetIndex(eventSender)
		Call ets_set_selected()
		'checks to make sure not below lines allready entered
		If Index > max_grid_line Then
			Prod_num(max_grid_line - 1).Focus()
			Exit Sub
		End If
		
	End Sub
	
	Private Sub acct_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles acct_num.Enter
		Dim Index As Short = acct_num.GetIndex(eventSender)
		acct_num(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		acct_num(Index).SelectionStart = 8
		acct_num(Index).SelectionLength = 2 'Len(acct_num(Index).Text)
		
		'checks to make sure not below lines allready entered
		If Index > max_grid_line Then
			Prod_num(max_grid_line - 1).Focus()
			Exit Sub
		End If
		
	End Sub
	Private Sub acct_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles acct_num.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = acct_num.GetIndex(eventSender)
		
		If KeyAscii = 13 Or KeyAscii = 9 Then
			acct_num(Index).SelectionStart = 0 'to make sure field is cleared
			valid_acct = "N"
			Call etsacctnum_chk(acct_num(Index), retacct, retacctdesc, valid_acct)
			If retacct = acct_num_blank Then GoTo EventExitSub
			If valid_acct = "Y" Then
				
				acct_num(Index).Text = retacct
				
				'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(Index + offset_grid_line, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				invoice_detail_grid(Index + offset_grid_line, 3) = retacct
			Else
				
				MsgBox("Invalid acct number - Please re-enter")
				Call ets_set_selected()
				GoTo EventExitSub
			End If
			
			qty(Index).Focus()
			KeyAscii = 0
			
		End If
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub acct_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles acct_num.Leave
		Dim Index As Short = acct_num.GetIndex(eventSender)
		acct_num(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
	
	Private Sub prod_desc_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles prod_desc.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = prod_desc.GetIndex(eventSender)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(Index + offset_grid_line, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			invoice_detail_grid(Index + offset_grid_line, 2) = prod_desc(Index).Text
			acct_num(Index).Focus()
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub prod_desc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prod_desc.Leave
		Dim Index As Short = prod_desc.GetIndex(eventSender)
		prod_desc(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub Prod_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Prod_num.Enter
		Dim Index As Short = Prod_num.GetIndex(eventSender)
		Call ets_set_selected()
		V_done.Enabled = True
		
		If Index = 0 Then
			If Len(name_key.Text) = 0 Then
				inv_num.Focus()
			End If
		End If
		
	End Sub
	
	Private Sub prod_num_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles prod_num.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = prod_num.GetIndex(eventSender)
		Select Case KeyCode
			
			Case System.Windows.Forms.Keys.F3
				
				If Index <> 0 Then
					Prod_num(Index).Text = Prod_num(Index - 1).Text
					System.Windows.Forms.SendKeys.Send("{ENTER}")
				End If
			Case System.Windows.Forms.Keys.F5
				'delete a line
				If CDbl(V_line(Index).Text) > max_grid_line Then
					MsgBox("Line not yet entered, so it can not be deleted.")
					Exit Sub
				End If
				
				msg = "Do you wish to delete this line?"
				Response = MsgBox(msg, MsgBoxStyle.YesNo)
				If Response = MsgBoxResult.No Then Exit Sub
				add_sub = -1
				Call grid_change(add_sub, V_line(Index), Index)
				
			Case System.Windows.Forms.Keys.F6
				'insert a line
				If CDbl(V_line(Index).Text) > max_grid_line Then
					MsgBox("This is the last line. No need to add a line.")
					Exit Sub
				End If
				
				msg = "Do you wish to insert a line before this line?"
				Response = MsgBox(msg, MsgBoxStyle.YesNo)
				If Response = MsgBoxResult.No Then Exit Sub
				add_sub = 1
				Call grid_change(add_sub, V_line(Index), Index)
		End Select
		Call tot_amt()
		V_done.Enabled = False
	End Sub
	Private Sub Prod_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Prod_num.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = Prod_num.GetIndex(eventSender)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			valid_lookup = "N"
			sendlookup = Prod_num(Index).Text
			retlookup = ""
			retlookupdesc = ""
			retdptglnum = ""
			
			Call etsprod_num_chk(sendlookup, retlookup, retlookupdesc, retdptglnum, valid_lookup)
			
			If valid_lookup = "N" Then
				MsgBox("Not a valid product number.")
				Call ets_set_selected()
				Prod_num(Index).Focus()
				KeyAscii = 0
				GoTo EventExitSub
			End If
			
			
			Prod_num(Index).Text = retlookup
			prod_desc(Index).Text = retlookupdesc
			amt(Index).Text = CStr(retlookup_price)
			
			If Prod_num(Index).Text = "99" Then 'for sales tax
				acct_num(Index).Text = retdptglnum
				acct_num(Index).Text = selected_prod_glnum
				'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(Index + offset_grid_line, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				invoice_detail_grid(Index + offset_grid_line, 3) = acct_num(Index).Text
			Else
				acct_num(Index).Text = workshop_cr_acct_nu 'lhw
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(Index + offset_grid_line, 0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			invoice_detail_grid(Index + offset_grid_line, 0) = V_line(Index).Text
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(Index + offset_grid_line, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			invoice_detail_grid(Index + offset_grid_line, 1) = Prod_num(Index).Text
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(Index + offset_grid_line, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			invoice_detail_grid(Index + offset_grid_line, 2) = prod_desc(Index).Text
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(Index + offset_grid_line, 5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			invoice_detail_grid(Index + offset_grid_line, 5) = retlookup_price
			V_done.Enabled = False
			prod_desc(Index).Focus()
			KeyAscii = 0
		End If
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub Prod_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Prod_num.Leave
		Dim Index As Short = Prod_num.GetIndex(eventSender)
		Prod_num(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub amt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles amt.Enter
		Dim Index As Short = amt.GetIndex(eventSender)
		Call ets_set_selected()
		
		'checks to make sure not below lines allready entered
		If Index > max_grid_line Then
			Prod_num(max_grid_line - 1).Focus()
			Exit Sub
		End If
		
	End Sub
	
	Private Sub amt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles amt.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = amt.GetIndex(eventSender)
		
		Dim rnd_tot As Decimal 'added all with rnd tot on 7/3/00 for proper rnding scs
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			If IsNumeric(amt(Index).Text) = False Then
				MsgBox("Please enter a number.")
				Call ets_set_selected()
				GoTo EventExitSub
			End If
			
			If Val(amt(Index).Text) = 0 Then
				MsgBox("You did not enter a unit price?")
			End If
			
			
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(Index + offset_grid_line, 5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			invoice_detail_grid(Index + offset_grid_line, 5) = Val(amt(Index).Text)
			rnd_tot = ((CDbl(amt(Index).Text) * CDbl(qty(Index).Text) * 100) - Int(CDbl(amt(Index).Text) * CDbl(qty(Index).Text) * 100))
			If rnd_tot < 0.5 Then
				line_Tot(Index).Text = CStr(CDbl(amt(Index).Text) * CDbl(qty(Index).Text) - rnd_tot / 100)
			Else
				line_Tot(Index).Text = CStr(CDbl(amt(Index).Text) * CDbl(qty(Index).Text) + ((1 - rnd_tot) / 100))
			End If
			
			'line_Tot(Index) = Format(line_Tot(Index), "FIXED")
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(Index + offset_grid_line, 6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			invoice_detail_grid(Index + offset_grid_line, 6) = line_Tot(Index).Text
			Call tot_amt()
			
			'increases the counter when the last enter key is struck
			If max_grid_line < CDbl(V_line(Index).Text) Then
				max_grid_line = CInt(V_line(Index).Text)
			End If
			
			
			If Index = 7 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				offset_grid_line = offset_grid_line + 1
				Call repaint_grid(offset_grid_line, wline, 7)
				acct_num(7).Text = acct_num(6).Text
				V_line(7).Focus()
				KeyAscii = 0
				GoTo EventExitSub
				
			Else
				If (acct_num(Index + 1)).Text = acct_num_blank Then
					acct_num(Index + 1).Text = acct_num(Index).Text
				End If
			End If
			Prod_num(Index + 1).Focus()
			KeyAscii = 0
			GoTo EventExitSub
			
			
		End If
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub amt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles amt.Leave
		Dim Index As Short = amt.GetIndex(eventSender)
		amt(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		Me.Close()
		'    arwk_bill_Ed1.Show
	End Sub
	
	Private Sub down_grid_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles down_grid.Click
		wline = 0
		If max_grid_line < 6 Then Exit Sub
		
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		offset_grid_line = offset_grid_line - 1
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If offset_grid_line > (max_grid_line - 5) Then offset_grid_line = max_grid_line - 5
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If offset_grid_line < 0 Then offset_grid_line = 0
		
		Call repaint_grid(offset_grid_line, wline, Index)
		
	End Sub
	
	Private Sub enc_Date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles enc_Date.Enter
		Call ets_set_selected()
		
	End Sub
	
	Private Sub enc_Date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles enc_Date.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			valid_Date = "N"
			senddate = enc_date.Text
			Call etsdate(senddate, retdate, valid_Date)
			
			If valid_Date <> "N" Then
				enc_date.Text = retdate
				enc_date.Text = CStr(CDate(enc_date.Text))
				
				enc_date.Text = CStr(CDate(enc_date.Text))
				
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
	Sub grid_change(ByRef add_sub As Object, ByRef wline As Object, ByRef oldfocus As Object)
		
		Select Case add_sub
			Case 1 'add a line from here on out
				
				max_grid_line = max_grid_line + 1
				
				'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				For num = max_grid_line To wline Step -1
					
					For i = 0 To 5
						'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num - 1, i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						invoice_detail_grid(num, i) = invoice_detail_grid(num - 1, i)
					Next i
					
				Next num
				For i = 0 To 5
					'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(wline - 1, i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice_detail_grid(wline - 1, i) = ""
				Next i
				'invoice_detail_grid(n, 1) = Val(invoice_detail_grid(n - 1, 1)) + 1
				
			Case -1
				
				'this test the continuous use of the f5 key
				'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Val(wline) > max_grid_line Then
					'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					wline = max_grid_line
				End If
				
				'this is the special case of deleting the last line
				'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If wline = max_grid_line Then
					max_grid_line = max_grid_line - 1
					
					If max_grid_line < 1 Then max_grid_line = 1
					
					For num = 0 To 5
						'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(wline - 1, num). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						invoice_detail_grid(wline - 1, num) = ""
					Next 
					'UPGRADE_WARNING: Couldn't resolve default property of object oldfocus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If oldfocus - 1 < 0 Then
						'UPGRADE_WARNING: Couldn't resolve default property of object oldfocus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						oldfocus = 1
						'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						offset_grid_line = offset_grid_line - 1
						'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If offset_grid_line < 0 Then offset_grid_line = 0
					End If
					
					Call tot_amt()
					'UPGRADE_WARNING: Couldn't resolve default property of object oldfocus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call repaint_grid(offset_grid_line, wline, oldfocus - 1)
					Exit Sub
				End If
				
				max_grid_line = max_grid_line - 1
				If max_grid_line < 1 Then max_grid_line = 1
				
				'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				For num = wline - 1 To max_grid_line
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice_detail_grid(num, 0) = Val(invoice_detail_grid(num + 1, 0)) - 1
					For i = 0 To 5
						'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num + 1, i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						invoice_detail_grid(num, i) = invoice_detail_grid(num + 1, i)
					Next i
				Next num
				For i = 0 To 5
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(max_grid_line + 1, i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice_detail_grid(max_grid_line + 1, i) = ""
				Next i
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(max_grid_line + 1, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				invoice_detail_grid(max_grid_line + 1, 1) = acct_num_blank
				
		End Select
		Call tot_amt()
		'UPGRADE_WARNING: Couldn't resolve default property of object wline. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Call repaint_grid(offset_grid_line, wline - 1, oldfocus)
		
	End Sub
	
	Sub repaint_grid(ByRef offset_grid_line As Object, ByRef wline As Object, ByRef oldfocus As Object)
		'recalc the offset grid line to keep the focus on the same physical line
		'and for the new line to be sensible
		
		'line renumbering done on v_line getting the focus
		
		For i = 0 To 7
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Len(invoice_detail_grid(i + offset_grid_line, 3)) <> 0 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				acct_num(i).Text = (invoice_detail_grid(i + offset_grid_line, 3))
			Else
				acct_num(i).Text = acct_num_blank
			End If
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(i + offset_grid_line, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Prod_num(i).Text = invoice_detail_grid(i + offset_grid_line, 1)
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(i + offset_grid_line, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			prod_desc(i).Text = invoice_detail_grid(i + offset_grid_line, 2) & ""
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(i + offset_grid_line, 5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			amt(i).Text = invoice_detail_grid(i + offset_grid_line, 5)
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(i + offset_grid_line, 4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			qty(i).Text = invoice_detail_grid(i + offset_grid_line, 4)
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(i + offset_grid_line, 6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			line_Tot(i).Text = invoice_detail_grid(i + offset_grid_line, 6)
			
		Next i
		'UPGRADE_WARNING: Couldn't resolve default property of object oldfocus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If oldfocus < 0 Then oldfocus = 0
		Call tot_amt()
		V_line(oldfocus).Focus()
		
	End Sub
	Private Sub entcleardetail()
		
		For num = 0 To 100
			For i = 0 To 6
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				invoice_detail_grid(num, i) = ""
			Next i
		Next num
		
		'UPGRADE_WARNING: Couldn't resolve default property of object vouchtotaldetail. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		vouchtotaldetail = 0
		'UPGRADE_WARNING: Couldn't resolve default property of object vouchtotaldetail. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		vouchtotaldisplay.Text = VB6.Format(vouchtotaldetail, "#####0.0000;-#####0.0000")
		Call repaint_grid(0, 0, 0)
		
	End Sub
	Private Sub entclearheader()
		name_key.Text = ""
		ref_num.Text = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		inv_num.Text = CStr(Val(hold(0)) + 1)
		'invdate = ""
		'enc_Date = ""
		screen_nam.Text = ""
		purch_num.Text = ""
		'ship_via.Text = " "
		'terms.Text = " "
		ups_Cost.Text = ""
		truck.Text = ""
		other.Text = ""
		
		inv_num.Focus()
		
	End Sub
	
	Private Sub enc_Date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles enc_Date.Leave
		enc_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub End_Session_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Session.Click
		
		' MsgBox " You are about to print the invoice edit proof. Be sure your printer is turned on and on line."
		'prtDestination = 1    'forces to the printer
		'  prtReportFileName = ar_report_path & "arvedit.rpt"
		'' Call frmcrystal_Call
		
		'MsgBox ("Check the proof.  If errors are found..select Edit Invoices from the menu. ")
		
		Me.Close()
		arwk_bill_Ed1.Show()
		
	End Sub
	
	Private Sub ent_Date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ent_Date.Enter
		ent_Date.Text = VB6.Format(Now, "medium date")
	End Sub
	
	Private Sub ar_wk_bill_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		' data1 = ar
		function_type = "DATA_ENTRY"
		'On Error Resume Next
		
		For num = 0 To 100
			For i = 0 To 5
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, i). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				invoice_detail_grid(num, i) = ""
			Next i
		Next num
		
		batch_Amount = 0
		vouch_Done = 0
		
		Call acctnumsetup()
		
		'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For num = 0 To Me.Controls.Count() - 1
			'UPGRADE_ISSUE: Data object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.Label Then
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sqlstmnt = VB.Right(CType(Me.Controls(num), Object).DatabaseName, Len(CType(Me.Controls(num), Object).DatabaseName) - 20)
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CType(Me.Controls(num), Object).DatabaseName = ar_data_path & sqlstmnt
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().recordsource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Len(CType(Me.Controls(num), Object).recordsource) > 0 Then
					CType(Me.Controls(num), Object).Refresh()
				End If
			End If
		Next 
		
		'find all the combo boxes and additem from reference for all on form
		
		tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
		tmpset = tmpdb.OpenRecordset("reference")
		
		'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For num = 0 To Me.Controls.Count() - 1
			'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.ComboBox Then
				sqlstmnt = "select * from reference where ctrl_name = " & Chr(34) & CType(Me.Controls(num), Object).Name & Chr(34)
				tmpset = tmpdb.OpenRecordset(sqlstmnt)
				Do While Not tmpset.EOF
					'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().AddItem. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CType(Me.Controls(num), Object).AddItem(tmpset.Fields("datum"))
					'Debug.Print tmpset.Fields("datum")
					tmpset.MoveNext()
				Loop 
			End If
			
		Next 
		If entry_type = "EDIT" Then
			dell_bill.Visible = True
			V_Cancel.Visible = False
		End If
		
	End Sub
	
	Private Sub invdate_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles invdate.Enter
		Call ets_set_selected()
	End Sub
	
	Private Sub invdate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles invdate.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			valid_Date = "N"
			senddate = invdate.Text
			Call etsdate(senddate, retdate, valid_Date)
			
			If valid_Date <> "N" Then
				invdate.Text = retdate
				invdate.Text = CStr(CDate(invdate.Text))
				
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
	
	Private Sub invdate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles invdate.Leave
		invdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	
	Private Sub line_tot_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles line_tot.Enter
		Dim Index As Short = line_tot.GetIndex(eventSender)
		Call ets_set_selected()
		'checks to make sure not below lines allready entered
		If Index > max_grid_line Then
			Prod_num(max_grid_line - 1).Focus()
			Exit Sub
		End If
	End Sub
	
	Private Sub line_tot_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles line_tot.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = line_tot.GetIndex(eventSender)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			'if line_tot(index) check for yes no
			wline = 0
			
			
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(Index + offset_grid_line, 5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			invoice_detail_grid(Index + offset_grid_line, 5) = line_Tot(Index).Text
			
			If max_grid_line < CDbl(V_line(Index).Text) Then
				max_grid_line = CInt(V_line(Index).Text)
			End If
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub scroll_vouch_grid(ByRef offset_grid_line As Object)
		'calculate the effect of offset here and put in x
		Dim X As Object
		
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		X = offset_grid_line
		
		'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If X > max_grid_line - 7 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			X = max_grid_line - 7
			'MsgBox "max grid " & max_grid_line
		End If
		'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If X < 0 Then X = 0
		For i = 0 To 7
			'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(X + i, 4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			amt(i).Text = invoice_detail_grid(X + i, 4)
			'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(X + i, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			acct_num(i).Text = invoice_detail_grid(X + i, 2) 'lhw
			'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(X + i, 0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			prod_desc(i).Text = invoice_detail_grid(X + i, 0)
			'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(X + i, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			V_line(i).Text = invoice_detail_grid(X + i, 1)
			
			'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(X + i, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			qty(i).Text = invoice_detail_grid(X + i, 3)
			'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(X + i, 5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			line_Tot(i).Text = invoice_detail_grid(X + i, 5)
			
		Next i
		
		'below is only true if adding another line
		
		If Val(V_line(7).Text) = max_grid_line Then
			
			amt(7).Text = ""
			acct_num(7).Text = acct_num(6).Text
			prod_desc(7).Text = ""
			V_line(7).Text = CStr(Val(V_line(6).Text) + 1)
			qty(7).Text = ""
			line_Tot(7).Text = ""
			
		End If
		
	End Sub
	Sub tot_amt()
		'UPGRADE_WARNING: Couldn't resolve default property of object vouchtotaldetail. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		vouchtotaldetail = 0
		
		For num = 0 To max_grid_line
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object vouchtotaldetail. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			vouchtotaldetail = vouchtotaldetail + Val(invoice_detail_grid(num, 6))
		Next num
		
		'UPGRADE_WARNING: Couldn't resolve default property of object vouchtotaldetail. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		vouchtotaldisplay.Text = VB6.Format(vouchtotaldetail, "#####0.00;-#####0.00")
		
	End Sub
	
	Private Sub ship_via_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ship_via.Enter
		ship_via.Text = VB6.GetItemString(ship_via, 0)
	End Sub
	
	Private Sub ship_via_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ship_via.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			enc_date.Focus()
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub terms_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles terms.Enter
		terms.Text = VB6.GetItemString(terms, 0)
	End Sub
	
	Private Sub terms_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles terms.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			'  ups_Cost.SetFocus
			System.Windows.Forms.SendKeys.Send("{TAB}")
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub truck_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles truck.Enter
		Call ets_set_selected()
		
	End Sub
	
	Private Sub truck_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles truck.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			truck.Text = VB6.Format(truck.Text, "###0.00;-###0.00")
			System.Windows.Forms.SendKeys.Send("{tab}")
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub truck_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles truck.Leave
		truck.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub up_grid_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles up_grid.Click
		wline = 0
		If max_grid_line < 6 Then Exit Sub
		
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		offset_grid_line = offset_grid_line + 1
		
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If offset_grid_line > max_grid_line - 8 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			offset_grid_line = max_grid_line - 6
		End If
		
		
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If offset_grid_line > (max_grid_line - 5) Then offset_grid_line = max_grid_line - 5
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If offset_grid_line < 0 Then offset_grid_line = 0
		
		Call repaint_grid(offset_grid_line, wline, Index)
		
	End Sub
	
	Private Sub ups_cost_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ups_cost.Enter
		Call ets_set_selected()
		
	End Sub
	
	Private Sub ups_cost_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ups_cost.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			ups_Cost.Text = VB6.Format(ups_Cost.Text, "###0.00;-###0.00")
			System.Windows.Forms.SendKeys.Send("{tab}")
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub ups_cost_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ups_cost.Leave
		ups_Cost.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	
	Private Sub V_Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles V_Cancel.Click
		
		Call entclearheader()
		Call entcleardetail()
		
		For num = 0 To 16
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(num). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			hold(num) = ""
		Next 
		V_done.Enabled = False
		
		inv_num.Focus() 'lhw
		Data1.Refresh()
		
		
		
		
	End Sub
	
	Private Sub V_done_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles V_done.Click
		
		'check to see if all the data has been entered into the header
		
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(0) = inv_num.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(1) = invdate.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(2) = name_key.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(3) = screen_nam.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(4) = purch_num.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(5) = ref_num.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(6) = ship_via.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(7). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(7) = enc_date.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(8). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(8) = terms.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(9). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(9) = ups_Cost.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(10). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(10) = truck.Text
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(11). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(11) = other.Text
		' hold(12) tot_inv
		' hold(13) tot_prod
		' hold(14) tot_post
		' hold(15) tot_advp
		'UPGRADE_WARNING: Couldn't resolve default property of object hold(16). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		hold(16) = Text1.Text & " " 'added & " " 7/9/04 lhw
		
		For num = 0 To 3 'check for something
			If Len(hold(num)) = 0 Then
				MsgBox("You have not entered all the header data.")
				Exit Sub
			End If
		Next 
		
		For num = 0 To max_grid_line - 1
			
			'now check th array for completeness
			If Len(invoice_detail_grid(num, 1)) = 0 Then GoTo notcomplete
			If Len(invoice_detail_grid(num, 4)) = 0 Then GoTo notcomplete
			If Len(invoice_detail_grid(num, 3)) = 0 Then GoTo notcomplete 'acct_num_blank Then GoTo notcomplete
			
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If invoice_detail_grid(num, 1) = "99999" Then '15 tot_advp
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object hold(15). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				hold(15) = Val(hold(15)) + invoice_detail_grid(num, 6)
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If invoice_detail_grid(num, 1) = "99998" Then '14 tot_post
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object hold(14). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				hold(14) = Val(hold(14)) + invoice_detail_grid(num, 6)
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If invoice_detail_grid(num, 1) < "99998" Then '13 tot_prod
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object hold(13). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				hold(13) = Val(hold(13)) + invoice_detail_grid(num, 6)
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If invoice_detail_grid(num, 1) <> "99999" Then
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object hold(12). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				hold(12) = Val(hold(12)) + invoice_detail_grid(num, 6) '12 tot_inv
			End If
			
			
		Next 
		
		
		'if this is an edit then erase the old records before adding the new one
		If entry_type = "EDIT" Then
			'UPGRADE_ISSUE: Data property Data1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.recordsource = "select * from workshop where inv_num = " & selected_voucher
			Data1.Refresh()
			
			'UPGRADE_WARNING: Couldn't resolve default property of object cust_sort_name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If cust_sort_name = "" Then
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				'UPGRADE_WARNING: Couldn't resolve default property of object cust_sort_name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				cust_sort_name = Data1.Recordset.Fields("Sort_name").Value
			End If
			
			If workshop_dr_acct_nu = "" Then
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				workshop_dr_acct_nu = Data1.Recordset.Fields("dr_pref_ac").Value
			End If
			
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Do While Not Data1.Recordset.EOF
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Data1.Recordset.delete()
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Data1.Recordset.MoveNext()
			Loop 
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.AddNew()
			'put the data in the header
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("inv_num").Value = hold(0)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("inv_date").Value = hold(1)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("name_key").Value = hold(2)
			'now get the right sort name
			Call cust_nameget(hold(2))
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("screen_nam").Value = hold(3)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("purch_num").Value = hold(4)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("reference").Value = hold(5)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("ship_via").Value = hold(6)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(7). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("ship_Date").Value = hold(7)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(8). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("terms").Value = hold(8)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(9). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("ups_Cost").Value = hold(9)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(10). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("our_truck").Value = hold(10)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(11). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("other_out").Value = hold(11)
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("tot_trans").Value = Val(hold(9)) + Val(hold(10)) + Val(hold(11))
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("tot_inv").Value = Val(hold(12))
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("tot_prod").Value = Val(hold(13))
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("tot_post").Value = Val(hold(14))
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("tot_advp").Value = Val(hold(15))
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object cust_sort_name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("Sort_name").Value = cust_sort_name
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.Fields("dr_pref_ac").Value = workshop_dr_acct_nu
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(16). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Data1.Recordset.Fields("message").Value = hold(16)
		End If
		
		Call putinvoice()
		
		batch_Amount = batch_Amount + CDbl(vouchtotaldisplay.Text)
		vouch_Done = vouch_Done + 1
		disp_left_to_enter.Text = VB6.Format(batch_Amount, "#####0.00;-#####0.00")
		
		disp_num_of_vouch.Text = CStr(vouch_Done)
		
		
		Call entcleardetail()
		Call entclearheader()
		
		For num = 1 To 16 'lhw99 don't blank inv_num
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(num). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			hold(num) = ""
		Next 
		
		If entry_type = "EDIT" Then
			Me.Close()
			arwk_bill_Ed1.Show()
		Else
			For num = 0 To 7
				'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				V_line(num).Text = num + 1 + offset_grid_line
			Next 
			
			inv_num.Focus() 'does not get here
			
		End If
		Exit Sub
		
notcomplete: 
		MsgBox("The detail is not complete. Be sure acct num if filled in.")
		End_Session.Enabled = False 'added  next 3 lines 11/27/00 lhw
		V_done.Enabled = False
		acct_num(Index).Focus()
		Exit Sub
		
	End Sub
	
	Private Sub V_line_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles V_line.Enter
		Dim Index As Short = V_line.GetIndex(eventSender)
		
		V_line(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
		For num = 0 To 7
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			V_line(num).Text = num + 1 + offset_grid_line
		Next 
		
		'checks to make sure not below lines all ready entered
		If Index > max_grid_line Then
			Prod_num(max_grid_line - 1).Focus()
			Exit Sub
			
		End If
		
		Prod_num(Index).Focus()
		
		'If Len(Trim(inv_num)) = 0 Then
		'inv_num.SetFocus
		
		'   KeyAscii = 0
		'Else
		'prod_num(Index).SetFocus
		KeyAscii = 0
		' End If
		
		
	End Sub
	
	Private Sub V_line_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles V_line.Leave
		Dim Index As Short = V_line.GetIndex(eventSender)
		V_line(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub name_key_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles name_key.Enter
		Call ets_set_selected()
		
	End Sub
	
	Private Sub name_key_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles name_key.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		If KeyAscii = 13 Or KeyAscii = 9 Then
			valid_name = "N"
			'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			selected_name_key = ""
			selected_sort_name = ""
			
			
			If Len(name_key.Text) = 0 Then
				package_Type_saved = package_Type
				package_Type = "AR"
				Call namelookup()
				package_Type = package_Type_saved
				'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				name_key.Text = selected_name_key
				' sort_name = selected_sort_name
				
			Else
				'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				selected_name_key = name_key.Text
			End If
			
			Call chkname(selected_name_key)
			
			If valid_name = "N" Then
				screen_nam.Text = ""
				MsgBox("Invalid customer number")
				Call ets_set_selected()
				GoTo EventExitSub
			End If
			
			
			Call cust_nameget(selected_name_key)
			
			'UPGRADE_WARNING: Couldn't resolve default property of object cust_screen_nam. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			screen_nam.Text = cust_screen_nam
			
			
			
			System.Windows.Forms.SendKeys.Send("{tab}")
			KeyAscii = 0
		End If
		
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub name_key_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles name_key.Leave
		name_key.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub purch_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles purch_num.Enter
		Call ets_set_selected()
		
	End Sub
	
	Private Sub purch_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles purch_num.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		
		If Len(purch_num.Text) = 0 Then
			purch_num.Text = " "
		End If
		
		If Len(purch_num.Text) > 20 Then 'added 3/2/06 lhw
			MsgBox("You can only enter 20 Characters for P.O. Num.")
			purch_num.Focus()
			Call ets_set_selected()
			GoTo EventExitSub
		End If
		
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			System.Windows.Forms.SendKeys.Send("{tab}")
			KeyAscii = 0
			
		End If
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub purch_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles purch_num.Leave
		purch_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub qty_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles qty.Enter
		Dim Index As Short = qty.GetIndex(eventSender)
		Call ets_set_selected()
		'checks to make sure not below lines allready entered
		If Index > max_grid_line Then
			Prod_num(max_grid_line - 1).Focus()
			Exit Sub
		End If
		
	End Sub
	
	Private Sub qty_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles qty.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = qty.GetIndex(eventSender)
		Select Case KeyCode
			
			Case System.Windows.Forms.Keys.F3
				
				If Index <> 0 Then
					qty(Index).Text = qty(Index - 1).Text
					System.Windows.Forms.SendKeys.Send("{ENTER}")
				End If
		End Select
		
	End Sub
	
	Private Sub qty_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles qty.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = qty.GetIndex(eventSender)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			If Val(qty(Index).Text) = 0 Then
				MsgBox("Please Enter an amount")
				GoTo EventExitSub
			End If
			
			'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(Index + offset_grid_line, 4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			invoice_detail_grid(Index + offset_grid_line, 4) = qty(Index).Text
			
			amt(Index).Focus()
			KeyAscii = 0
		End If
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub qty_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles qty.Leave
		Dim Index As Short = qty.GetIndex(eventSender)
		qty(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub inv_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles inv_num.Enter
		
		
		
		'UPGRADE_WARNING: Couldn't resolve default property of object offset_grid_line. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		offset_grid_line = 0
		max_grid_line = 1
		End_Session.Enabled = True
		
		ent_Date.Text = VB6.Format(Today, "General Date")
		
		Data1.Refresh()
		
		If entry_type = "ADD" Then
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.AddNew()
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Val(hold(0)) <> 0 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object hold(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				inv_num.Text = CStr(Val(hold(0)) + 1)
				
			End If
			invdate.Text = ent_Date.Text
			enc_date.Text = ent_Date.Text
			
		Else
			'Call fillwkbill
			'UPGRADE_ISSUE: Data property Data1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.recordsource = "select * from workshop where inv_num = " & selected_voucher
			
			Data1.Refresh()
			
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			ship_via.Text = Data1.Recordset.Fields("ship_via").Value & ""
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			terms.Text = Data1.Recordset.Fields("terms").Value & ""
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			ent_Date.Text = Data1.Recordset.Fields("entry_Date").Value 'lhw99
			num = 0
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Do While Not Data1.Recordset.EOF
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				invoice_detail_grid(num, 0) = Data1.Recordset.Fields("line_num").Value
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				invoice_detail_grid(num, 1) = Data1.Recordset.Fields("prod_num").Value
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				invoice_detail_grid(num, 2) = Data1.Recordset.Fields("prod_desc").Value
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				invoice_detail_grid(num, 3) = Data1.Recordset.Fields("cr_pref_Ac").Value
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				invoice_detail_grid(num, 4) = Data1.Recordset.Fields("quantity").Value
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				invoice_detail_grid(num, 5) = Data1.Recordset.Fields("unit_price").Value
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(num, 6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				invoice_detail_grid(num, 6) = Data1.Recordset.Fields("line_tot").Value
				num = num + 1
				'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Data1.Recordset.MoveNext()
			Loop 
			max_grid_line = num
			Call repaint_grid(0, 0, 0)
			
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.MoveFirst()
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Data1.Recordset.edit()
			Label2.Visible = False
			Label4.Visible = False
			disp_left_to_enter.Visible = False
			disp_num_of_vouch.Visible = False
			'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_WARNING: Couldn't resolve default property of object hold(16). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			hold(16) = Data1.Recordset.Fields("message").Value
		End If
		
		Call ets_set_selected()
		
	End Sub
	
	Private Sub inv_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles inv_num.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		If KeyAscii = 13 Then
			If Val(inv_num.Text) = 0 Then
				MsgBox("Please enter a number")
				GoTo EventExitSub
			End If
			
			If Not IsNumeric(inv_num.Text) Then
				MsgBox("Not a valid number")
				Call ets_set_selected()
				GoTo EventExitSub
			End If
			
			valid_vouch = "N"
			Call chkwork_numverify(CStr(inv_num.Text))
			If valid_vouch = "N" Then
				MsgBox("This invoice number has been used - Please Re-enter")
				Call ets_set_selected()
				GoTo EventExitSub
			End If
			
			valid_vouch = "N"
			Call chkinv_numverify(CStr(inv_num.Text))
			If valid_vouch = "N" Then
				MsgBox("This invoice number has been used - Please Re-enter")
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
	
	Private Sub inv_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles inv_num.Leave
		inv_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
	
	Private Sub ref_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ref_num.Enter
		Call ets_set_selected()
		
	End Sub
	
	Private Sub ref_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ref_num.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If Len(ref_num.Text) = 0 Then ref_num.Text = " "
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			System.Windows.Forms.SendKeys.Send("{tab}")
			KeyAscii = 0
			
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub ref_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ref_num.Leave
		ref_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
End Class