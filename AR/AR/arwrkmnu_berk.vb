Option Strict Off
Option Explicit On
Friend Class frm_arwrkmnu
	Inherits System.Windows.Forms.Form
	
	Private Sub EDPROD_Click()
		
	End Sub
	
	Private Sub EDTYPE_Click()
		
	End Sub
	Private Sub import_batch_Click()
		Dim invoice As Object
		Dim recur1_inv As Object
		Dim cash_tmp As Object
		Dim Label4 As Object
		Dim txtfields As Object
		'need to have excel file formatted corectly and in csv format
		'need to decide where the file will be and name?
		'XXXXXXXXXXXXXXXXXXXXXXX
		'added 12/18/03 lhw/tk  moved from V4 5/6/04 lhw
		Dim filename_sel As Object
		
		entry_type = "ADD"
		selected_bat_num = 0
		
		'UPGRADE_WARNING: Couldn't resolve default property of object txtfields.Visible. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		txtfields.Visible = True
		'UPGRADE_WARNING: Couldn't resolve default property of object Label4.Visible. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Label4.Visible = True
		'UPGRADE_WARNING: Couldn't resolve default property of object txtfields.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Trim(txtfields.Text) = "" Then
			MsgBox("Enter Encum Date for the Import File.")
			'UPGRADE_WARNING: Couldn't resolve default property of object txtfields.SetFocus. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtfields.SetFocus()
			Exit Sub
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object cash_tmp.Refresh. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cash_tmp.Refresh()
		'  Do While Not cash_Tmp.Recordset.EOF
		'    cash_Tmp.Recordset.Delete
		'    cash_Tmp.Recordset.MoveNext
		'  Loop
		
		Response = MsgBox("Has file to import been created update invoice records?", MsgBoxStyle.YesNo)
		Dim fld(6) As Object
		Dim batch_total As Decimal
		'UPGRADE_WARNING: Arrays in structure invoiceset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
		Dim invoiceset As dao.Recordset
		If Response = MsgBoxResult.Yes Then
			'upd_batch.Enabled = False
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			fnum = FreeFile
			
			'UPGRADE_WARNING: Couldn't resolve default property of object filename_sel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			filename_sel = "p:\customers\berk\misc_inv.csv"
			err.Clear()
			'UPGRADE_WARNING: Couldn't resolve default property of object filename_sel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			FileOpen(fnum, filename_sel, OpenMode.Input, , , 1)
			
			Select Case Err.Number
				Case 0
					'Case 70
					'   MsgBox "Drive A:\ not ready."
					'   Screen.MousePointer = vbDefault
					'   Exit Sub
				Case Else
					MsgBox("Error #" & Err.Number & " meaning " & ErrorToString(Err.Number) & Chr(10) & "Please fix before trying again.")
					'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
					Exit Sub
			End Select
			
			On Error GoTo 0
			
			batch_total = 0
			tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
			invoiceset = tmpdb.OpenRecordset("inv_import", dao.RecordsetTypeEnum.dbOpenDynaset)
			
			tmpset = tmpdb.OpenRecordset("nam_cust", dao.RecordsetTypeEnum.dbOpenDynaset)
			
			num = 0
			Call batch_number_Create()
			saved_entry_num = 1
			Do While Not EOF(fnum)
				err.Clear()
				On Error Resume Next
				Input(1, msg)
				
				If Err.Number = 62 Then Exit Do
				'UPGRADE_WARNING: Couldn't resolve default property of object fld(num). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fld(num) = msg
				
				'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If num = 6 And Trim(fld(0)) <> "" Then
					num = 0
					'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sqlstmnt = "Select * from nam_cust where name_key = " & Chr(34) & Trim(fld(0)) & Chr(34)
					tmpset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
					'tmpset.FindFirst "name_key = " & Chr(34) & Trim(fld(0)) & Chr(34)
					'If Not tmpset.NoMatch Then
					If tmpset.RecordCount <> 0 Then
						'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Trim(fld(3)) <> "" Then
							'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							batch_total = batch_total + fld(3)
						End If
						
						invoiceset.AddNew()
						invoiceset.Fields("bank_key").Value = "2177"
						'UPGRADE_WARNING: Couldn't resolve default property of object txtfields.Text. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						invoiceset.Fields("encum_date").Value = txtfields.Text
						'UPGRADE_WARNING: Couldn't resolve default property of object fld(0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						invoiceset.Fields("name_key").Value = fld(0)
						invoiceset.Fields("screen_nam").Value = tmpset.Fields("screen_nam").Value
						invoiceset.Fields("sort_name").Value = tmpset.Fields("sort_name").Value
						'UPGRADE_WARNING: Couldn't resolve default property of object fld(2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						invoiceset.Fields("chk_num").Value = fld(2)
						'UPGRADE_WARNING: Couldn't resolve default property of object txtfields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						invoiceset.Fields("chk_date").Value = txtfields
						'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Trim(fld(3)) <> "" Then
							'UPGRADE_WARNING: Couldn't resolve default property of object fld(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							invoiceset.Fields("gross_amt").Value = fld(3)
						End If
						invoiceset.Fields("chk_disc").Value = 0
						'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Trim(fld(3)) <> "" Then
							'UPGRADE_WARNING: Couldn't resolve default property of object fld(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							invoiceset.Fields("check_amt").Value = fld(3)
							'UPGRADE_WARNING: Couldn't resolve default property of object fld(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							invoiceset.Fields("chk_alloc").Value = fld(3)
						End If
						invoiceset.Fields("entry_num").Value = saved_entry_num
						saved_entry_num = saved_entry_num + 1
						invoiceset.Fields("inv_num").Value = 0
						invoiceset.Fields("line_num").Value = 1
						invoiceset.Fields("invoice").Value = "MISC"
						invoiceset.Fields("trans_code").Value = "PMT"
						invoiceset.Fields("dr_acct_nu").Value = "1007-00-00" 'bank
						invoiceset.Fields("cr_acct_nu").Value = "1260-00-00"
						invoiceset.Fields("disc_acct").Value = "1260-00-00"
						invoiceset.Fields("donor").Value = "MISC"
						invoiceset.Fields("memo").Value = "ON ACCOUNT"
						invoiceset.Fields("batch_num").Value = selected_bat_num
						invoiceset.Fields("batch_desc").Value = "1"
						'UPGRADE_WARNING: Couldn't resolve default property of object txtfields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						invoiceset.Fields("batch_date").Value = txtfields
						'invoiceset.Fields("batch_total") = batch_total
						invoiceset.Fields("s_m").Value = "M"
						
						invoiceset.update()
					Else
						'UPGRADE_WARNING: Couldn't resolve default property of object fld(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						MsgBox("Customer #" & fld(0) & " (" & fld(1) & ") not in nam_cust table.These are not added to this batch.")
						
					End If
					
				Else
					num = num + 1
				End If
			Loop 
			
			sqlstmnt = "SELECT batch_total FROM cash_tmp1 where batch_num = " & selected_bat_num & "" 'fixed lhw
			invoiceset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
			invoiceset.MoveFirst()
			Do While Not invoiceset.EOF
				invoiceset.edit()
				invoiceset.Fields("batch_total").Value = batch_total
				invoiceset.update()
				invoiceset.MoveNext()
			Loop 
			
			MsgBox("Import complete.  Batch Total: $" & batch_total)
			
			FileClose(fnum)
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			
			
		End If
		
		
		
		'XXXXXXXXXXXXXXXXXXXXXXXXX
		
		Response = MsgBox("Do you wish to update invoice records?", MsgBoxStyle.YesNo)
		If Response = MsgBoxResult.Yes Then
			'upd_batch.Enabled = False
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			'check acct numbers for the whole batch
			'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Do While Not recur1_inv.Recordset.EOF
				
				'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If recur1_inv.Recordset.Fields("alloc_Amt") <> 0 Then
					valid_acct = "N"
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call chk_acct_num_only(recur1_inv.Recordset.Fields("dr_Acct_nu"), valid_acct)
					If valid_acct = "N" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						MsgBox("Invalid Account Number. Please Edit the recurring Invoice = " & recur1_inv.Recordset.Fields("inv_num"))
						
						Exit Sub
					End If
					
					valid_acct = "N"
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Call chk_acct_num_only(recur1_inv.Recordset.Fields("cr_Acct_nu"), valid_acct)
					If valid_acct = "N" Then
						'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						MsgBox("Invalid Account Number. Please Edit the recurring Invoice = " & recur1_inv.Recordset.Fields("inv_num"))
						
						Exit Sub
					End If
				End If
				
				'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				recur1_inv.Recordset.MoveNext()
				
			Loop 
			
			'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			recur1_inv.Recordset.MoveFirst()
			
			
			' write out the non zero line items
			num1 = -1 'counter for invoices
			'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Do While Not recur1_inv.Recordset.EOF
				'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If recur1_inv.Recordset.Fields("alloc_Amt") <> 0 Then
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.AddNew()
					
					' If recur1_inv.Recordset.Fields("line_num") = 1 Then
					' num1 = num1 + 1     'only for new invoices
					' End If
					'***************
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("inv_num") = recur1_inv.Recordset.Fields("inv_num") ' inv# have been assigned
					
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("line_num") = recur1_inv.Recordset.Fields("line_num") 'same line#
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("invoice") = recur1_inv.Recordset.Fields("inv_num")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("trans_code") = "MISC"
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("po_num") = recur1_inv.Recordset.Fields("po_num")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("name_key") = recur1_inv.Recordset.Fields("name_key")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("screen_nam") = recur1_inv.Recordset.Fields("screen_nam")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("sort_name") = recur1_inv.Recordset.Fields("sort_name")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("cc_num") = recur1_inv.Recordset.Fields("cc_num")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("cc_name") = recur1_inv.Recordset.Fields("cc_name")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("inv_desc") = recur1_inv.Recordset.Fields("inv_desc")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("dr_Acct_nu") = recur1_inv.Recordset.Fields("dr_acct_nu")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("cr_acct_nu") = recur1_inv.Recordset.Fields("cr_acct_nu")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("entry_date") = recur1_inv.Recordset.Fields("entry_date")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("invoice_date") = recur1_inv.Recordset.Fields("invoice_date")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("encum_Date") = recur1_inv.Recordset.Fields("invoice_date")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("dt_tbe_pd") = recur1_inv.Recordset.Fields("invoice_date") + 30
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("bal_due") = recur1_inv.Recordset.Fields("alloc_amt")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("inv_amt") = recur1_inv.Recordset.Fields("inv_amt")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("alloc_amt") = recur1_inv.Recordset.Fields("alloc_amt")
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("paid") = "N" 'to show on aging
					'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.update()
				End If
				
				'UPGRADE_WARNING: Couldn't resolve default property of object recur1_inv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				recur1_inv.Recordset.MoveNext()
				
			Loop 
			
		Else
			MsgBox("No records were updated.")
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			
		End If
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		MsgBox("Recurring Invoices have been added to Invoice.")
		
		
		
	End Sub
	
	Public Sub after_copy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles after_copy.Click
		'code in mod1 5/98
		'ets.dat must have drive letter in it
		Call after_backup(ar_data_path & "ar.mdb")
		'code changed 9/20/01 to flag if backup not done in mod
		If valid_yn = "Y" Then
			MsgBox("AR backup is complete.")
		Else
			MsgBox("AR backup is NOT complete.")
			Exit Sub
		End If
	End Sub
	
	Public Sub arcmopn_frm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles arcmopn_frm.Click
		frmarcmopn.ShowDialog()
	End Sub
	
	Public Sub Copy_toe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Copy_toe.Click
		'code is in mod1 5/98
		'ets.dat must have letter of zip drive
		Call before_backup(ar_data_path & "ar.mdb")
		'code changed 9/20/01 to flag if backup not done in mod
		If valid_yn = "Y" Then
			MsgBox("AR backup is complete.")
		Else
			MsgBox("AR backup is NOT complete.")
			Exit Sub
		End If
	End Sub
	
	Public Sub cust_sslist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cust_sslist.Click
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "arcust1.rpt"
		'  ' Call frmcrystal_Call
		
	End Sub
	
	Public Sub ed_inv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ed_inv.Click
		entry_type = "EDIT"
		arwk_bill_Ed1.Show()
	End Sub
	
	Public Sub EXMAIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EXMAIN.Click
		frmetstop.Show()
		Me.Close()
	End Sub
	
	Public Sub EXWIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EXWIN.Click
		Me.Close()
		
		End
	End Sub
	
	Private Sub frm_wrkinv_Click()
		
	End Sub
	
	Private Sub frminv_std_Click()
		
	End Sub
	
	Private Sub frm_arwrkmnu_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Me.Text = "A/R Subcontract Billing Menu - " & agency_name
		
		tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
		tmpset = tmpdb.OpenRecordset("reference")
		
		'for menu changes
		'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For num = 0 To Me.Controls.Count() - 1
			'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.ToolStripMenuItem Then
				sqlstmnt = "select * from reference where ctrl_name = " & Chr(34) & CType(Me.Controls(num), Object).Name & Chr(34)
				tmpset = tmpdb.OpenRecordset(sqlstmnt)
				Do While Not tmpset.EOF
					CType(Me.Controls(num), Object).Text = tmpset.Fields("datum_desc").Value
					tmpset.MoveNext()
				Loop 
			End If
		Next 
		
		'for form changes
		'this is to change command buttons and needs to be on the form where the buttons are
		'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For num = 0 To Me.Controls.Count() - 1
			'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.Button Then
				sqlstmnt = "select * from reference where ctrl_name = " & Chr(34) & CType(Me.Controls(num), Object).Name & Chr(34)
				tmpset = tmpdb.OpenRecordset(sqlstmnt)
				Do While Not tmpset.EOF
					CType(Me.Controls(num), Object).Text = tmpset.Fields("datum_desc").Value
					tmpset.MoveNext()
				Loop 
			End If
		Next 
	End Sub
	
	Public Sub frm_rptgen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_rptgen.Click
		Dim custrpt_lookup As Object
		'UPGRADE_WARNING: Couldn't resolve default property of object custrpt_lookup.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		custrpt_lookup.Show()
	End Sub
	
	Public Sub frm_transf_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_transf.Click
		MsgBox("For Non Network Systems ")
	End Sub
	
	Public Sub frm_uphist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_uphist.Click 'this is to put a "Y" in the billed field
		Response = MsgBox(" You can mark this batch as BILLED and then Update to Invoice!. Select Yes to continue ", MsgBoxStyle.YesNo)
		If Response = MsgBoxResult.Yes Then
			arcupchk.Show()
		Else
			Exit Sub
		End If
		
	End Sub
	
	
	
	Public Sub frminv_wrk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frminv_wrk.Click
		entry_type = "ADD"
		ar_wk_bill.Show()
	End Sub
	
	Public Sub frmnameaddr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frmnameaddr.Click
		function_type = ""
		frmnamechk.Show()
		
	End Sub
	
	Private Sub PCKOFF_Click()
		
	End Sub
	
	Public Sub frmprod_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frmprod.Click
		productlookup.Show()
	End Sub
	
	Private Sub frmtypes_Click()
		frmtype.Show()
	End Sub
	
	Private Sub frmwrk_ed_Click()
		
	End Sub
	
	Private Sub onecust_rpt_Click()
		' prtDestination = 1    'forces to the printer
		' prtReportFileName = ar_report_path & "arbatch.rpt"
		'' Call frmcrystal_Call
	End Sub
	
	Private Sub prt_reg_Click()
		' prtDestination = 1    'forces to the printer
		' prtReportFileName = ar_report_path & "arcominv.rpt"
		'' Call frmcrystal_Call
	End Sub
	
	Public Sub im_inv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles im_inv.Click
		
		csvfile_import_inv.ShowDialog()
		
	End Sub
	
	Public Sub je_cr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles je_cr.Click
		arcominvgl_frm.Show()
	End Sub
	
	Private Sub pack_dot_Click()
		'to gove option if selected in error
		Response = MsgBox("This is for Dot Matrix Printer - Be sure forms are lined up, select Yes to continue?", MsgBoxStyle.YesNo)
		If Response = MsgBoxResult.No Then Exit Sub
		prtDestination = CStr(1) 'forces to the printer
		prtreportfilename = ar_report_path & "arpackd.rpt"
		' Call frmcrystal_Call
	End Sub
	
	Public Sub rpt_batch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpt_batch.Click
		prtDestination = CStr(0) 'forces to the printer
		prtreportfilename = ar_report_path & "arcombatch.rpt"
		' Call frmcrystal_Call
	End Sub
	
	Public Sub rpt_calpha_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpt_calpha.Click
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "arcusta.rpt"
		'  ' Call frmcrystal_Call
		
	End Sub
	
	Public Sub rpt_cnum_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpt_cnum.Click
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "arcustn.rpt"
		' Call frmcrystal_Call
	End Sub
	
	Private Sub rpt_invone_Click()
		'to gove option if selected in error
		Response = MsgBox("This is for Dot Matrix Printer - Be sure forms are lined up, select Yes to continue?", MsgBoxStyle.YesNo)
		If Response = MsgBoxResult.No Then Exit Sub
		prtDestination = CStr(1) 'forces to the printer
		prtreportfilename = ar_report_path & "arcprintdot.rpt"
		' Call frmcrystal_Call
	End Sub
	
	Private Sub rpt_minvs_Click()
		
	End Sub
	
	Public Sub rpt_packing_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpt_packing.Click
		'to give option if selected in error
		Response = MsgBox(" Laser Printer Ready??, select Yes to continue?", MsgBoxStyle.YesNo)
		If Response = MsgBoxResult.No Then Exit Sub
		
		prtDestination = CStr(0) 'forces to the printer
		prtreportfilename = ar_report_path & "arpackl.rpt"
		' Call frmcrystal_Call
	End Sub
	
	Public Sub rpt_prod_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpt_prod.Click
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "arprod.rpt"
		'  ' Call frmcrystal_Call
		
	End Sub
	
	Public Sub rpt_wrkinv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpt_wrkinv.Click
		'to give option if selected in error
		Response = MsgBox("Printer Ready??, select Yes to continue?", MsgBoxStyle.YesNo)
		If Response = MsgBoxResult.No Then Exit Sub
		
		prtDestination = CStr(0) 'forces to the printer
		prtreportfilename = ar_report_path & "arcprintl.rpt"
		'  ' Call frmcrystal_Call
	End Sub
	
	Public Sub subinv_doc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles subinv_doc.Click
		'this is the code to print a txt file
		'the txt file will contain instructions
		'ALL OF THE CODE IS HERE   2/27/98
		
		Dim Word As Object
		Dim PrintOptions As Object
		Dim Background As Integer
		
		Word = CreateObject("Word.Basic")
		'UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Word.FileOpen("C:\etsacct\documents\workshop.doc")
		'UPGRADE_WARNING: Couldn't resolve default property of object Word.CurValues. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		PrintOptions = Word.CurValues.ToolsOptionsPrint
		'UPGRADE_WARNING: Couldn't resolve default property of object PrintOptions.Background. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Background = PrintOptions.Background
		'UPGRADE_NOTE: Object PrintOptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		PrintOptions = Nothing
		If (Background <> 0) Then
			'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Word.ToolsOptionsPrint(Background:=0)
		End If
		'UPGRADE_WARNING: Couldn't resolve default property of object Word.FilePrintDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Word.FilePrintDefault()
		If (Background <> 0) Then
			'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Word.ToolsOptionsPrint(Background:=Background)
		End If
		'UPGRADE_WARNING: Couldn't resolve default property of object Word.FileClose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Word.FileClose(2)
		'UPGRADE_NOTE: Object Word may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Word = Nothing
		
	End Sub
	
	Public Sub un_bill_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles un_bill.Click
		prtDestination = CStr(0) 'forces to the printer
		prtreportfilename = ar_report_path & "arunbill.rpt"
		' Call frmcrystal_Call
	End Sub
End Class