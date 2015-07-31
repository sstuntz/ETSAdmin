Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmaratb1
	Inherits System.Windows.Forms.Form
	Public invoicedb As dao.Database
	'UPGRADE_WARNING: Arrays in structure invoiceset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public invoiceset As dao.Recordset
	Public cashdb As dao.Database
	'UPGRADE_WARNING: Arrays in structure cashset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public cashset As dao.Recordset
	
	Public sqlstmt As String
	Public aropndb As dao.Database
	'UPGRADE_WARNING: Arrays in structure aropnset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public aropnset As dao.Recordset
	
	Public saved_date As Date
	
	
	Private Sub calc_prior_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles calc_prior.Click
		'4. add new records to cust age first
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		cust_age.Refresh()
		'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		If cust_age.Recordset.RecordCount <> 0 Then
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.Recordset.MoveFirst()
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Do While Not cust_age.Recordset.EOF
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				cust_age.Recordset.delete()
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				cust_age.Recordset.MoveNext()
			Loop 
		End If
		
		sqlstmnt = "select * from nam_cust where cust_type = 'S' or cust_type = 'G' or cust_type = 'P' order by name_key"
		'UPGRADE_ISSUE: Data property nam_cust.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		nam_cust.recordsource = sqlstmnt
		nam_cust.Refresh()
		'UPGRADE_ISSUE: Data property nam_cust.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		nam_cust.Recordset.MoveFirst()
		
		On Error Resume Next
		'UPGRADE_ISSUE: Data property nam_cust.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not nam_cust.Recordset.EOF
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.Recordset.AddNew()
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property nam_cust.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.Recordset.Fields("name_key").Value = Trim(nam_cust.Recordset.Fields("name_key").Value)
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property nam_cust.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.Recordset.Fields("screen_nam").Value = nam_cust.Recordset.Fields("screen_nam").Value
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property nam_cust.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.Recordset.Fields("sort_name").Value = nam_cust.Recordset.Fields("sort_name").Value
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property nam_cust.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.Recordset.Fields("cust_type").Value = nam_cust.Recordset.Fields("cust_type").Value
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.Recordset.update()
			'if record already there getting a 3022 error
			
			'UPGRADE_ISSUE: Data property nam_cust.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			nam_cust.Recordset.MoveNext()
		Loop 
		On Error GoTo 0
		'MsgBox "Records now set up in cust age."
		
		'5. Select from aropn and load balances prev,cur,30,60,90+
		
		'MsgBox "Now moving data from aropn to cust age."
		Dim age_month As Integer
		Dim cur_month As Integer
		Dim age_date As Date
		Dim age_inv As Integer
		Dim prev_tot As Decimal
		'UPGRADE_NOTE: pmt was upgraded to pmt_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim pmt_Renamed As Decimal
		Dim balc As Decimal
		Dim bal30 As Decimal
		Dim bal60 As Decimal
		Dim bal90 As Decimal
		
		
		sqlstmt = "select * from aropn order by name_key , inv_num "
		'UPGRADE_ISSUE: Data property aropn.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		aropn.recordsource = sqlstmt
		aropn.Refresh()
		
		prev_tot = 0
		'datediff takes care of over end of year
		'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		aropn.Recordset.MoveFirst()
		'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not aropn.Recordset.EOF
			'UPGRADE_ISSUE: Data property cust_age.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.recordsource = "select * from cust_age where name_key = " & Chr(34) & aropn.Recordset.Fields("name_key").Value & Chr(34)
			cust_age.Refresh()
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			If aropn.Recordset.Fields("item_num").Value >= 0 Then 'all records
				'added 7/31/00 to trap if no record in  cust for records in inv or cash
				
				'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Select Case DateDiff(Microsoft.VisualBasic.DateInterval.Month, aropn.Recordset.Fields("encum_date").Value, CDate(txtfields(2).Text))
					Case 0 '2/8/01
						
						On Error Resume Next '2/8/01
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.edit()
						If Err.Number = 3021 Then
							'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
							MsgBox("No record in nam_cust for these records : " & aropn.Recordset.Fields("name_key").Value & Chr(10) & "You need to add the missing customers to Name Address and Customer Files.")
						End If
						
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.Fields("bal_c").Value = cust_age.Recordset.Fields("bal_c").Value + aropn.Recordset.Fields("alloc_amt").Value
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.update()
						On Error GoTo 0
						
					Case 1
						On Error Resume Next '2/8/01
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.edit()
						If Err.Number = 3021 Then
							'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
							MsgBox("No record in nam_cust for for these records : " & aropn.Recordset.Fields("name_key").Value & Chr(10) & "You need to add the missing customers to Name Address and Customer Files.")
						End If
						
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.Fields("bal_30").Value = cust_age.Recordset.Fields("bal_30").Value + aropn.Recordset.Fields("alloc_amt").Value
						
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.update()
						On Error GoTo 0
						
					Case 2
						On Error Resume Next '2/8/01
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.edit()
						If Err.Number = 3021 Then
							'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
							MsgBox("No record in nam_cust for for these records : " & aropn.Recordset.Fields("name_key").Value & Chr(10) & "You need to add the missing customers to Name Address and Customer Files.")
						End If
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.Fields("bal_60").Value = cust_age.Recordset.Fields("bal_60").Value + aropn.Recordset.Fields("alloc_amt").Value
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.update()
						On Error GoTo 0
						
					Case Else
						On Error Resume Next '2/8/01
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.edit()
						If Err.Number = 3021 Then
							'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
							MsgBox("No record in nam_cust for for these records : " & aropn.Recordset.Fields("name_key").Value & Chr(10) & "You need to add the missing customers to Name Address and Customer Files.")
						End If
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.Fields("bal_90").Value = cust_age.Recordset.Fields("bal_90").Value + aropn.Recordset.Fields("alloc_amt").Value
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.update()
				End Select
				
				
			End If
			
			On Error GoTo 0
			
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.MoveNext()
		Loop 
		
		MsgBox("Aging is complete.")
	End Sub
	
	'****************
	'revision History
	'original date of this form is 06/01/1998 - SCS
	
	'****************
	'Option Explicit
	Private Sub cmdRefresh_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRefresh.Click
		'this is really only needed for multi user apps
		Data1.Refresh()
	End Sub
	
	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
		
		
		'UPGRADE_ISSUE: Data method Data1.UpdateRecord was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.UpdateRecord()
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Bookmark = VB6.CopyArray(Data1.Recordset.LastModified)
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		'1 clean aropn
		'2 select invoice records prior to end date
		
		'1 this cleans the aropn table
		aropn.Refresh()
		'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		If aropn.Recordset.RecordCount <> 0 Then
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.MoveFirst()
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Do While Not aropn.Recordset.EOF
				'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				aropn.Recordset.delete()
				'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				aropn.Recordset.MoveNext()
			Loop 
		End If
		
		'2 select/add invoices prior to end date
		sqlstmt = "select * from invoice WHERE invoice.dflag <> 'Y' and invoice.void <> 'Y' and invoice.trans_code <> 'MISC' "
		sqlstmt = sqlstmt & " and invoice.encum_Date <= " & Chr(35) & txtfields(2).Text & Chr(35)
		sqlstmt = sqlstmt & " order by invoice.inv_num "
		
		'UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.recordsource = sqlstmt
		invoice.Refresh()
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.MoveFirst()
		
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not invoice.Recordset.EOF
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.AddNew()
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("inv_num").Value = invoice.Recordset.Fields("inv_num").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("line_num").Value = invoice.Recordset.Fields("line_num").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("item_num").Value = 0
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("type").Value = invoice.Recordset.Fields("trans_code").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("name_key").Value = invoice.Recordset.Fields("name_key").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("screen_nam").Value = invoice.Recordset.Fields("screen_nam").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("sort_name").Value = invoice.Recordset.Fields("sort_name").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("encum_date").Value = invoice.Recordset.Fields("encum_date").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("invoice_date").Value = invoice.Recordset.Fields("invoice_date").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("alloc_amt").Value = invoice.Recordset.Fields("alloc_amt").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("invoice").Value = invoice.Recordset.Fields("invoice").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("dt_paid").Value = invoice.Recordset.Fields("paid_date").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("paid").Value = invoice.Recordset.Fields("paid").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("bal_due").Value = invoice.Recordset.Fields("bal_due").Value
			
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.update()
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			invoice.Recordset.MoveNext()
		Loop 
		
		'MsgBox "Invoices Loaded"
		
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		
		Command2.Focus()
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		On Error Resume Next
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "aragedud.rpt"
		' Call frmcrystal_Call
		If Err.Number = 20504 Then
			MsgBox("This report has not been created")
			Exit Sub
		End If
		On Error GoTo 0
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		'3 select all payment record for inv_num > 0 no misc cash
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		db = ar_data_path & "ar.mdb"
		cashdb = DAODBEngine_definst.OpenDatabase(db)
		cashset = cashdb.OpenRecordset("cash")
		
		'select all a/r cash      added ADVP select 3-21-00 lhw
		sqlstmt = "select * from cash WHERE cash.dflag <> 'Y' and cash.void_chk <> 'Y'"
		sqlstmt = sqlstmt & " and cash.encum_Date <= " & Chr(35) & txtfields(2).Text & Chr(35)
		sqlstmt = sqlstmt & " and cash.inv_num > 0 or cash.trans_code = 'ADV' or cash.trans_code = 'ADVP' "
		sqlstmt = sqlstmt & " order by cash.inv_num , cash.line_num "
		
		'UPGRADE_ISSUE: Data property cash.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		cash.recordsource = sqlstmt
		cash.Refresh()
		On Error Resume Next
		'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		cash.Recordset.MoveFirst()
		If Err.Number = 3021 Then
			MsgBox("No cash records were selected")
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			Exit Sub
		End If
		On Error GoTo 0
		
		'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not cash.Recordset.EOF 'changed code to use trans_code not pmt as default
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.AddNew()
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("inv_num").Value = cash.Recordset.Fields("inv_num").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("line_num").Value = cash.Recordset.Fields("line_num").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("invoice").Value = cash.Recordset.Fields("invoice").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("item_num").Value = 1
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("type").Value = cash.Recordset.Fields("trans_code").Value '"PMT"
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("name_key").Value = cash.Recordset.Fields("name_key").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("screen_nam").Value = cash.Recordset.Fields("screen_nam").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("sort_name").Value = cash.Recordset.Fields("sort_name").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("encum_date").Value = cash.Recordset.Fields("encum_date").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("chk_num").Value = cash.Recordset.Fields("chk_num").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("dt_paid").Value = cash.Recordset.Fields("chk_date").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("bank_key").Value = cash.Recordset.Fields("bank_key").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("pay_amt").Value = cash.Recordset.Fields("chk_alloc").Value * -1 '7/24/98 cash is +
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("paid").Value = "N"
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("bal_due").Value = 0
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("alloc_amt").Value = cash.Recordset.Fields("chk_alloc").Value * -1
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.update()
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash.Recordset.MoveNext()
		Loop 
		
		'4. get inv date in pmt record in aropn
		'aropn has a record for inv and for pmts
		Dim age_date As Date
		Dim age_inv As Integer
		'select all invoices
		sqlstmt = "select * from aropn order by inv_num, line_num "
		'UPGRADE_ISSUE: Data property aropn.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		aropn.recordsource = sqlstmt
		aropn.Refresh()
		
		'On Error Resume Next
		
		'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		aropn.Recordset.MoveFirst()
		'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		age_date = aropn.Recordset.Fields("encum_date").Value
		'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		age_inv = aropn.Recordset.Fields("inv_num").Value
		'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		aropn.Recordset.MoveNext()
		
		'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not aropn.Recordset.EOF
			
			
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			If age_inv = aropn.Recordset.Fields("inv_num").Value Then
				'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				aropn.Recordset.edit()
				'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				aropn.Recordset.Fields("encum_date").Value = age_date
				'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				aropn.Recordset.update()
			Else
				'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				age_date = aropn.Recordset.Fields("encum_date").Value
				'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				age_inv = aropn.Recordset.Fields("inv_num").Value
			End If
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.MoveNext()
		Loop 
		
		'xxxxxx
		'5  Move the Y in paid field in 0 recs(inv) into paid field in 1 recs(cash)
		'we are looking for a match on inv num and line num
		'this is done with 2 recordsets
		tmp1db = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
		sqlstmt = "select * from aropn where item_num = 0 and paid = 'Y' order by inv_num ,line_num "
		'UPGRADE_ISSUE: Data property aropn.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		aropn.recordsource = sqlstmt
		aropn.Refresh()
		
		'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not aropn.Recordset.EOF
			sqlstmt = "select * from aropn where item_num = 1 "
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			sqlstmt = sqlstmt & " and inv_num = " & aropn.Recordset.Fields("inv_num").Value
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			sqlstmt = sqlstmt & " and line_num = " & aropn.Recordset.Fields("line_num").Value
			tmp1set = tmp1db.OpenRecordset(sqlstmt, dao.RecordsetTypeEnum.dbOpenDynaset)
			Do While Not tmp1set.EOF
				
				tmp1set.edit()
				tmp1set.Fields("paid").Value = "Y"
				tmp1set.update()
				tmp1set.MoveNext()
			Loop 
			
			
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.MoveNext()
			
		Loop 
		
		'6   2-25-99 lhw
		'put a "N" in paid field for invoices that have a paid date greater than
		'rpthead end_date--to allow for invoices marked as paid if paid after the
		'aging date
		
		
		sqlstmt = "select * from aropn WHERE aropn.item_num = 0 "
		sqlstmt = sqlstmt & " and aropn.dt_paid > " & Chr(35) & txtfields(2).Text & Chr(35)
		'UPGRADE_ISSUE: Data property aropn.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		aropn.recordsource = sqlstmt
		aropn.Refresh()
		On Error Resume Next
		'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		aropn.Recordset.MoveFirst()
		If Err.Number = 3021 Then
			MsgBox("Process continuing to evaluate data. ")
			' Screen.MousePointer = 0
			'Exit Sub
		End If
		
		On Error GoTo 0
		
		'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not aropn.Recordset.EOF
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.edit()
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("paid").Value = "N"
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.update()
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.MoveNext()
		Loop 
		
		'make paid = N for all ADV or ADVX payments so they show up in aging
		'added ADVX 4/03/01 lhw
		
		sqlstmt = "select * from aropn WHERE aropn.type = 'ADV' or aropn.type = 'ADVX' "
		'UPGRADE_ISSUE: Data property aropn.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		aropn.recordsource = sqlstmt
		aropn.Refresh()
		On Error Resume Next
		'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		aropn.Recordset.MoveFirst()
		If Err.Number = 3021 Then 'if no records here then exit  3/22/99
			MsgBox("No Advance payments to process ")
			'Screen.MousePointer = 0
			'Exit Sub
		End If
		On Error GoTo 0
		
		'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not aropn.Recordset.EOF
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.edit()
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.Fields("paid").Value = "N"
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.update()
			'UPGRADE_ISSUE: Data property aropn.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropn.Recordset.MoveNext()
		Loop 
		
		
		
		MsgBox("Data moved to AR open file.")
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		Command1.Focus()
		
		
	End Sub
	
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "aragedmd.rpt"
		' Call frmcrystal_Call
		
	End Sub
	
	Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "aragedsum.rpt"
		' Call frmcrystal_Call
	End Sub
	
	Private Sub Command5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command5.Click
		
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "aragedone.rpt"
		' Call frmcrystal_Call
		
	End Sub
	
	Private Sub Command6_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command6.Click 'statements all
		On Error Resume Next
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "armstmt.rpt"
		' Call frmcrystal_Call
		If Err.Number = 20504 Then
			MsgBox("This report has not been created")
			Exit Sub
		End If
		On Error GoTo 0
	End Sub
	
	Private Sub Command7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command7.Click 'one customer
		On Error Resume Next
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "armstmt1cust.rpt"
		' Call frmcrystal_Call
		If Err.Number = 20504 Then
			MsgBox("This report has not been created")
			Exit Sub
		End If
		On Error GoTo 0
	End Sub
	
	Private Sub Command8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command8.Click 'one consummer
		On Error Resume Next
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "armstmt1con.rpt"
		' Call frmcrystal_Call
		
		If Err.Number = 20504 Then
			MsgBox("This report has not been created")
			Exit Sub
		End If
		On Error GoTo 0
	End Sub
	
	'UPGRADE_ISSUE: Data event Data1.Error was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub Data1_Error(ByRef DataErr As Short, ByRef Response As Short)
		'This is where you would put error handling code
		'If you want to ignore errors, comment out the next line
		'If you want to trap them, add code here to handle them
		MsgBox("Data error event hit err:" & ErrorToString(DataErr))
		Response = 0 'throw away the error
	End Sub
	
	Private Sub frmaratb1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		On Error Resume Next
		' data1 = ar
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
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
		Dim Index As Short = txtFields.GetIndex(eventSender)
		Call ets_set_selected()
	End Sub
	
	Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtfields.GetIndex(eventSender)
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			valid_Date = "N"
			senddate = txtfields(Index).Text
			Call etsdate(senddate, retdate, valid_Date)
			
			If valid_Date <> "N" Then
				txtfields(Index).Text = retdate
				txtfields(Index).Text = CStr(CDate(txtfields(Index).Text))
				
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
	
	Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
		Dim Index As Short = txtfields.GetIndex(eventSender)
		txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
End Class