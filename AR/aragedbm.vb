Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks
Friend Class frmaratb1m
	Inherits System.Windows.Forms.Form
	Public invoicedb As dao.Database
	'UPGRADE_WARNING: Arrays in structure invoiceset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public invoiceset As dao.Recordset
	Public cashdb As dao.Database
	'UPGRADE_WARNING: Arrays in structure cashset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public cashset As dao.Recordset
	Public cust_agedb As dao.Database
	'UPGRADE_WARNING: Arrays in structure cust_ageset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public cust_ageset As dao.Recordset
	Public cust_namdb As dao.Database
	'UPGRADE_WARNING: Arrays in structure cust_namset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public cust_namset As dao.Recordset
	
	Public sqlstmt As String
	Public aropnmdb As dao.Database
	'UPGRADE_WARNING: Arrays in structure aropnmset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	Public aropnmset As dao.Recordset
	
	Public saved_date As Date
	
	
	Private Sub arcustage_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles arcustage.Click
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "arcustage.rpt"
		' Call frmcrystal_Call
		
	End Sub
	
	Private Sub Bal_zero_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Bal_zero.Click
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "aropnm_proof.rpt"
		' Call frmcrystal_Call
		
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
	
	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click 'for BCARC 5/14/00 lhw
		'misc sales/cash
		
		'UPGRADE_ISSUE: Data method Data1.UpdateRecord was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.UpdateRecord()
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Bookmark = VB6.CopyArray(Data1.Recordset.LastModified)
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		'1 clean aropnm and cust age
		'2 select invoice records prior to end date
		MsgBox("This cleans aropnm and cust_age.  Then Loads Inv's to aropnm.")
		aropnm.Refresh()
		'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		If aropnm.Recordset.RecordCount <> 0 Then
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.MoveFirst()
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Do While Not aropnm.Recordset.EOF
				'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				aropnm.Recordset.delete()
				'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				aropnm.Recordset.MoveNext()
			Loop 
		End If
		
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
		
		'2 select/add invoices prior to end date                               'added for BCARC to select misc sales 5/14/00lhw
		sqlstmt = "select * from invoice WHERE invoice.dflag <> 'Y' and invoice.void <> 'Y' and invoice.trans_code = 'MISC'"
		sqlstmt = sqlstmt & " and invoice.encum_Date <= " & Chr(35) & txtfields(2).Text & Chr(35)
		sqlstmt = sqlstmt & " order by invoice.name_key "
		
		'UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.recordsource = sqlstmt
		invoice.Refresh()
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.MoveFirst()
		
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not invoice.Recordset.EOF
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.AddNew()
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("inv_num").Value = invoice.Recordset.Fields("inv_num").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("line_num").Value = invoice.Recordset.Fields("line_num").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("item_num").Value = 0
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("type").Value = invoice.Recordset.Fields("trans_code").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("name_key").Value = invoice.Recordset.Fields("name_key").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("screen_nam").Value = invoice.Recordset.Fields("screen_nam").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("sort_name").Value = invoice.Recordset.Fields("sort_name").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("encum_date").Value = invoice.Recordset.Fields("encum_date").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("invoice_date").Value = invoice.Recordset.Fields("invoice_date").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("alloc_amt").Value = invoice.Recordset.Fields("alloc_amt").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("inv_desc").Value = invoice.Recordset.Fields("inv_desc").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("invoice").Value = invoice.Recordset.Fields("invoice").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("dt_paid").Value = invoice.Recordset.Fields("paid_date").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("paid").Value = invoice.Recordset.Fields("paid").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("bal_due").Value = invoice.Recordset.Fields("bal_due").Value
			
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.update()
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			invoice.Recordset.MoveNext()
		Loop 
		
		'MsgBox "Invoices Loaded to Aropnm"
		MsgBox("Be sure to select Load Data Files/Calculate Aging Next.")
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		
		Command2.Focus()
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "armisage.rpt"
		' Call frmcrystal_Call
		
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		'3 select all payment record for  misc cash
		MsgBox("Be patient..wait for the message that Aging is Complete.")
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		db = ar_data_path & "ar.mdb"
		cashdb = DAODBEngine_definst.OpenDatabase(db)
		cashset = cashdb.OpenRecordset("cash")
		
		'select all MISC cash
		sqlstmt = "select * from cash WHERE cash.dflag <> 'Y' and cash.void_chk <> 'Y'"
		sqlstmt = sqlstmt & " and cash.encum_Date <= " & Chr(35) & txtfields(2).Text & Chr(35)
		sqlstmt = sqlstmt & " and cash.inv_num = 0 and cash.donor = 'MISC'"
		sqlstmt = sqlstmt & " order by cash.name_key "
		
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
		Do While Not cash.Recordset.EOF
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.AddNew()
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("inv_num").Value = cash.Recordset.Fields("inv_num").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("line_num").Value = cash.Recordset.Fields("line_num").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("item_num").Value = 1
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("type").Value = cash.Recordset.Fields("trans_code").Value '"PMT"
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("name_key").Value = cash.Recordset.Fields("name_key").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("screen_nam").Value = cash.Recordset.Fields("screen_nam").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("sort_name").Value = cash.Recordset.Fields("sort_name").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("encum_date").Value = cash.Recordset.Fields("encum_date").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("chk_num").Value = cash.Recordset.Fields("chk_num").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("dt_paid").Value = cash.Recordset.Fields("chk_date").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("bank_key").Value = cash.Recordset.Fields("bank_key").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("inv_desc").Value = "Paid on Account"
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("pay_amt").Value = cash.Recordset.Fields("chk_alloc").Value * -1 '7/24/98 cash is +
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("paid").Value = "N"
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("bal_due").Value = 0
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("alloc_amt").Value = cash.Recordset.Fields("chk_alloc").Value * -1
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.update()
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash.Recordset.MoveNext()
		Loop 
		
		'MsgBox "Misc Cash has been loaded to aropnm."
		
		
		
		'4. add new records to cust age first
		'MsgBox "Now Adding new records to cust age."
		sqlstmnt = "select * from nam_cust where cust_type = 'C' or cust_type = 'M' order by name_key"
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
		
		'5. Select from aropnm and load balances prev,cur,30,60,90+
		
		'MsgBox "Now moving data from aropnm to cust age."
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
		
		
		sqlstmt = "select * from aropnm order by name_key , inv_num "
		'UPGRADE_ISSUE: Data property aropnm.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		aropnm.recordsource = sqlstmt
		aropnm.Refresh()
		
		prev_tot = 0
		'datediff takes care of over end of year
		'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		aropnm.Recordset.MoveFirst()
		'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not aropnm.Recordset.EOF
			'UPGRADE_ISSUE: Data property cust_age.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.recordsource = "select * from cust_age where name_key = " & Chr(34) & aropnm.Recordset.Fields("name_key").Value & Chr(34)
			cust_age.Refresh()
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			If aropnm.Recordset.Fields("item_num").Value = 0 Then '0 items are invoices
				'added 7/31/00 to trap if no record in  cust for records in inv or cash
				
				'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Select Case DateDiff(Microsoft.VisualBasic.DateInterval.Month, aropnm.Recordset.Fields("encum_date").Value, CDate(txtfields(2).Text))
					Case 0
						
						On Error Resume Next '7/31/00
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.edit()
						If Err.Number = 3021 Then
							'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
							MsgBox("No record in nam_cust for this payment record : " & aropnm.Recordset.Fields("name_key").Value & Chr(10) & "You need to add the missing customers to Name Address and Customer Files.")
						End If
						
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.Fields("bal_c").Value = cust_age.Recordset.Fields("bal_c").Value + aropnm.Recordset.Fields("alloc_amt").Value
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.update()
						On Error GoTo 0
						
					Case 1
						On Error Resume Next '7/31/00
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.edit()
						If Err.Number = 3021 Then
							'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
							MsgBox("No record in nam_cust for this payment record : " & aropnm.Recordset.Fields("name_key").Value & Chr(10) & "You need to add the missing customers to Name Address and Customer Files.")
						End If
						
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.Fields("bal_30").Value = cust_age.Recordset.Fields("bal_30").Value + aropnm.Recordset.Fields("alloc_amt").Value
						
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.update()
						On Error GoTo 0
						
					Case 2
						On Error Resume Next '7/31/00
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.edit()
						If Err.Number = 3021 Then
							'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
							MsgBox("No record in nam_cust for this payment record : " & aropnm.Recordset.Fields("name_key").Value & Chr(10) & "You need to add the missing customers to Name Address and Customer Files.")
						End If
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.Fields("bal_60").Value = cust_age.Recordset.Fields("bal_60").Value + aropnm.Recordset.Fields("alloc_amt").Value
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.update()
						On Error GoTo 0
						
					Case Else
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.edit()
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.Fields("bal_90").Value = cust_age.Recordset.Fields("bal_90").Value + aropnm.Recordset.Fields("alloc_amt").Value
						'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
						cust_age.Recordset.update()
				End Select
				
			Else 'this is for the payment records
				
				On Error Resume Next '2000
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				cust_age.Recordset.edit()
				If Err.Number = 3021 Then
					'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					MsgBox("No record in nam_cust for this payment record : " & aropnm.Recordset.Fields("name_key").Value & Chr(10) & "You need to add the missing customers to Name Address and Customer Files.")
				End If
				
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				cust_age.Recordset.Fields("payment").Value = cust_age.Recordset.Fields("payment").Value + aropnm.Recordset.Fields("alloc_amt").Value
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				cust_age.Recordset.update()
			End If
			
			On Error GoTo 0
			'cust_age.Recordset.Update
			
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.MoveNext()
		Loop 
		
		'next want to apply the cash to balaces
		'only one record per customer
		Dim tmp_c As Decimal
		Dim tmp_30 As Decimal
		Dim tmp_60 As Decimal
		Dim tmp_90 As Decimal
		Dim move_90 As Decimal
		
		sqlstmt = "select * from cust_age order by name_key "
		'UPGRADE_ISSUE: Data property cust_age.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		cust_age.recordsource = sqlstmt
		cust_age.Refresh()
		'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		cust_age.Recordset.MoveFirst()
		tmp_c = 0
		tmp_30 = 0
		tmp_60 = 0
		tmp_90 = 0
		
		
		'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not cust_age.Recordset.EOF
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.Recordset.edit()
			'if payment + 90 = + leave in there and do no more calc
			'if payment + 90 = - then 90 is 0 and dif to 60
			'-
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			tmp_90 = cust_age.Recordset.Fields("payment").Value + cust_age.Recordset.Fields("bal_90").Value
			
			If tmp_90 < 0 Then
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				cust_age.Recordset.Fields("over90").Value = 0
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				tmp_60 = cust_age.Recordset.Fields("bal_60").Value + tmp_90 'neg
				
			Else
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				cust_age.Recordset.Fields("over90").Value = tmp_90
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				tmp_60 = cust_age.Recordset.Fields("bal_60").Value
			End If
			
			
			If tmp_60 < 0 Then
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				tmp_30 = cust_age.Recordset.Fields("bal_30").Value + tmp_60 'neg
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				cust_age.Recordset.Fields("over60").Value = 0
			Else
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				cust_age.Recordset.Fields("over60").Value = tmp_60
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				tmp_30 = cust_age.Recordset.Fields("bal_30").Value
			End If
			
			
			If tmp_30 < 0 Then
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				tmp_c = cust_age.Recordset.Fields("bal_c").Value + tmp_30 ' was ("bal_c")
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				cust_age.Recordset.Fields("over30").Value = 0
			Else
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				cust_age.Recordset.Fields("over30").Value = tmp_30
				'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				tmp_c = cust_age.Recordset.Fields("bal_c").Value
			End If
			
			
			'xxneed to reselect cust age here and then calc the following
			
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.Recordset.Fields("current").Value = tmp_c
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.Recordset.Fields("prev_bal").Value = cust_age.Recordset.Fields("bal_30").Value + cust_age.Recordset.Fields("bal_60").Value + cust_age.Recordset.Fields("bal_90").Value '7/31/00 added below
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.Recordset.Fields("total_amt").Value = cust_age.Recordset.Fields("bal_c").Value + cust_age.Recordset.Fields("bal_30").Value + cust_age.Recordset.Fields("bal_60").Value + cust_age.Recordset.Fields("bal_90").Value + cust_age.Recordset.Fields("payment").Value
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.Recordset.update()
			'tmp_c = 0
			'tmp_30 = 0
			'tmp_60 = 0
			'tmp_90 = 0
			
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.Recordset.MoveNext()
			'tmp_c = 0
			' tmp_30 = 0
			' tmp_60 = 0
			' tmp_90 = 0
			
		Loop 
		'add a record from cust_age so lookups will work even if no activity
		sqlstmt = "select * from cust_age where prev_bal <> 0 or current < 0 order by name_key "
		'UPGRADE_ISSUE: Data property cust_age.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		cust_age.recordsource = sqlstmt
		cust_age.Refresh()
		On Error Resume Next
		'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		cust_age.Recordset.MoveFirst()
		If Err.Number = 3021 Then
			MsgBox("Aging is complete! You can run reports now.")
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			Exit Sub
		End If
		
		'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not cust_age.Recordset.EOF
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.AddNew()
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("inv_num").Value = Val(cust_age.Recordset.Fields("name_key").Value)
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("line_num").Value = 1
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("item_num").Value = 1
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("type").Value = "XX"
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("name_key").Value = cust_age.Recordset.Fields("name_key").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("screen_nam").Value = cust_age.Recordset.Fields("screen_nam").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("sort_name").Value = cust_age.Recordset.Fields("sort_name").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("encum_date").Value = txtfields(2).Text
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("chk_num").Value = "1"
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("dt_paid").Value = txtfields(2).Text
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("bank_key").Value = "1"
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("pay_amt").Value = 0 '7/24/98 cash is +
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("paid").Value = "N"
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("bal_due").Value = 0
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("alloc_amt").Value = 0
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.update()
			'UPGRADE_ISSUE: Data property cust_age.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cust_age.Recordset.MoveNext()
		Loop 
		
		MsgBox("Aging is complete! You can run reports now.")
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'Command1.SetFocus
		
		
	End Sub
	
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "ar_invoice_create.rpt"
		' Call frmcrystal_Call
		
	End Sub
	
	Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
		'UPGRADE_ISSUE: Data method Data1.UpdateRecord was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.UpdateRecord()
		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Data1.Recordset.Bookmark = VB6.CopyArray(Data1.Recordset.LastModified)
		'GoTo arfix  'here for debugging
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		'1 clean aropnm
		'2 select invoice records prior to end date this includes previous bal fwd record
		'3 select all payment record for  misc cash
		'4 need to delete from invoice the old bal fwd record before we write new one to invoice 03/03/2009
		'  otherwise we will select it again when the process is done again
		'5 Add a new record to invoice that is the new Bal Forward record
		
		
		MsgBox("This Process will take a few minutes..Be Patient.")
		'MsgBox "This cleans aropnm .  Then Loads Inv's and Cash to AROPNM."
		aropnm.Refresh()
		'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		If aropnm.Recordset.RecordCount <> 0 Then
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.MoveFirst()
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Do While Not aropnm.Recordset.EOF
				'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				aropnm.Recordset.delete()
				'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				aropnm.Recordset.MoveNext()
			Loop 
		End If
		
		
		'2 select/add invoices prior to end date and a bal fwd record
		sqlstmt = "select * from invoice WHERE invoice.dflag <> 'Y' and invoice.void <> 'Y' and invoice.trans_code = 'MISC'"
		sqlstmt = sqlstmt & " and invoice.encum_Date <= " & Chr(35) & txtfields(3).Text & Chr(35)
		sqlstmt = sqlstmt & " order by invoice.name_key "
		
		'UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.recordsource = sqlstmt
		invoice.Refresh()
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.MoveFirst()
		
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not invoice.Recordset.EOF
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.AddNew()
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("inv_num").Value = invoice.Recordset.Fields("inv_num").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("line_num").Value = invoice.Recordset.Fields("line_num").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("item_num").Value = 0
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("type").Value = invoice.Recordset.Fields("trans_code").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("name_key").Value = invoice.Recordset.Fields("name_key").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("screen_nam").Value = invoice.Recordset.Fields("screen_nam").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("sort_name").Value = invoice.Recordset.Fields("sort_name").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("encum_date").Value = invoice.Recordset.Fields("encum_date").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("invoice_date").Value = invoice.Recordset.Fields("invoice_date").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("alloc_amt").Value = invoice.Recordset.Fields("alloc_amt").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("inv_desc").Value = invoice.Recordset.Fields("inv_desc").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("invoice").Value = invoice.Recordset.Fields("invoice").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("dt_paid").Value = invoice.Recordset.Fields("paid_date").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("paid").Value = invoice.Recordset.Fields("paid").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("bal_due").Value = invoice.Recordset.Fields("bal_due").Value
			
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.update()
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			invoice.Recordset.MoveNext()
		Loop 
		
		
		
		'MsgBox "Invoices Loaded to Aropnm"
		
		'3 select all payment record for  misc cash
		
		db = ar_data_path & "ar.mdb"
		cashdb = DAODBEngine_definst.OpenDatabase(db)
		cashset = cashdb.OpenRecordset("cash")
		
		'select all MISC cash
		sqlstmt = "select * from cash WHERE cash.dflag <> 'Y' and cash.void_chk <> 'Y'"
		sqlstmt = sqlstmt & " and cash.encum_Date <= " & Chr(35) & txtfields(3).Text & Chr(35)
		sqlstmt = sqlstmt & " and cash.inv_num = 0 and cash.donor = 'MISC'"
		sqlstmt = sqlstmt & " order by cash.name_key "
		
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
		Do While Not cash.Recordset.EOF
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.AddNew()
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("inv_num").Value = cash.Recordset.Fields("inv_num").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("line_num").Value = cash.Recordset.Fields("line_num").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("item_num").Value = 1
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("type").Value = cash.Recordset.Fields("trans_code").Value '"PMT"
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("name_key").Value = cash.Recordset.Fields("name_key").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("screen_nam").Value = cash.Recordset.Fields("screen_nam").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("sort_name").Value = cash.Recordset.Fields("sort_name").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("encum_date").Value = cash.Recordset.Fields("encum_date").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("chk_num").Value = cash.Recordset.Fields("chk_num").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("dt_paid").Value = cash.Recordset.Fields("chk_date").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("bank_key").Value = cash.Recordset.Fields("bank_key").Value
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("inv_desc").Value = "Paid on Account"
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("pay_amt").Value = cash.Recordset.Fields("chk_alloc").Value * -1 '7/24/98 cash is +
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("paid").Value = "N"
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("bal_due").Value = 0
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.Fields("alloc_amt").Value = cash.Recordset.Fields("chk_alloc").Value * -1
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.update()
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash.Recordset.MoveNext()
		Loop 
		
		'4 need to delete from invoice the old bal fwd record before we write new one to invoice
		'otherwise we will select it again when the process is done again!!!!03/03/2009
		
		'*****start of New Code 03/03/2009 lhw
		'there should only be one bal fwd record/cust in the file
		
		sqlstmt = "select * from invoice WHERE invoice.inv_desc = 'Balance Forward'"
		sqlstmt = sqlstmt & " order by invoice.name_key "
		
		'UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.recordsource = sqlstmt
		invoice.Refresh()
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.MoveFirst()
		
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		If invoice.Recordset.RecordCount <> 0 Then
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			invoice.Recordset.MoveFirst()
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			Do While Not invoice.Recordset.EOF
				'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				invoice.Recordset.delete()
				'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				invoice.Recordset.MoveNext()
			Loop 
		End If
		'******end of new code 03/03/2009 lhw
		
		
		'MsgBox "Misc Cash has been loaded to aropnm ."
		
		'arfix: 'here for debugging
		'5 Add a new record to invoice that is the new Bal Forward record
		
		Dim tot_amt As Decimal
		Dim start_inv_num As Integer
		Dim saved_date As Date
		start_inv_num = 991001
		saved_date = CDate(txtfields(3).Text)
		
		
		sqlstmt = "select * from aropnm where aropnm.alloc_amt <> 0 order by aropnm.name_key "
		
		'UPGRADE_ISSUE: Data property aropnm.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		aropnm.recordsource = sqlstmt
		aropnm.Refresh()
		
		On Error Resume Next
		'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		aropnm.Recordset.MoveFirst()
		If Err.Number = 3021 Then
			MsgBox("No AROPNM records were selected")
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			Exit Sub
		End If
		On Error GoTo 0
		
		
		
		'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		saved_name_key = aropnm.Recordset.Fields("name_key").Value
		tot_amt = 0
		
		'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		Do While Not aropnm.Recordset.EOF
			
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			If saved_name_key = aropnm.Recordset.Fields("name_key").Value Then
				'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				tot_amt = tot_amt + aropnm.Recordset.Fields("alloc_amt").Value
			Else
				If tot_amt <> 0 Then
					
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.AddNew()
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("inv_num").Value = start_inv_num
					start_inv_num = start_inv_num + 1
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("line_num").Value = 1
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("invoice").Value = start_inv_num
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("trans_code").Value = "MISC"
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("name_key").Value = saved_name_key
					
					Call cust_nameget(saved_name_key)
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					'UPGRADE_WARNING: Couldn't resolve default property of object cust_screen_nam. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("screen_nam").Value = cust_screen_nam
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					'UPGRADE_WARNING: Couldn't resolve default property of object cust_sort_name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					invoice.Recordset.Fields("sort_name").Value = cust_sort_name
					
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("inv_desc").Value = "Balance Forward"
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("dr_acct_nu").Value = "1260-00-00"
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("cr_acct_nu").Value = "4071-00-15"
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("alloc_amt").Value = tot_amt
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("entry_date").Value = saved_date
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("invoice_date").Value = saved_date
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("encum_date").Value = saved_date
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("chk_num").Value = "99999"
					'invoice.Recordset.Fields("paid_date") = saved_date
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("pay_amt").Value = 0
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("bal_due").Value = tot_amt
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("units").Value = 1
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("paid").Value = "N"
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.Fields("glpost").Value = "Y"
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.update()
				End If
				
				'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				tot_amt = aropnm.Recordset.Fields("alloc_amt").Value
				'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				saved_name_key = aropnm.Recordset.Fields("name_key").Value
			End If
			
			'UPGRADE_ISSUE: Data property aropnm.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			aropnm.Recordset.MoveNext()
			
		Loop 
		'write out last record
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.AddNew()
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("inv_num").Value = start_inv_num
		start_inv_num = start_inv_num + 1
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("line_num").Value = 1
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("invoice").Value = start_inv_num
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("trans_code").Value = "MISC"
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("name_key").Value = saved_name_key
		
		Call cust_nameget(saved_name_key)
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object cust_screen_nam. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		invoice.Recordset.Fields("screen_nam").Value = cust_screen_nam
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		'UPGRADE_WARNING: Couldn't resolve default property of object cust_sort_name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		invoice.Recordset.Fields("sort_name").Value = cust_sort_name
		
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("inv_desc").Value = "Balance Forward"
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("dr_acct_nu").Value = "1260-00-00"
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("cr_acct_nu").Value = "4071-00-15"
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("alloc_amt").Value = tot_amt
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("entry_date").Value = saved_date
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("invoice_date").Value = saved_date
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("encum_date").Value = saved_date
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("chk_num").Value = 99999
		'invoice.Recordset.Fields("paid_date") = saved_date
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("pay_amt").Value = 0
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("bal_due").Value = tot_amt
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("units").Value = 1
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("paid").Value = "N"
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.Fields("glpost").Value = "Y"
		'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
		invoice.Recordset.update()
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		MsgBox("New Invoice records have been written.")
		'MsgBox "cash=fund and inv=inv_type = X .can select and delete when sure."
		
	End Sub
	
	Private Sub Command5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command5.Click
		'did it this way because inv_type could be null!!!!
		'written for BCARC 6/29/04 lhw
		Response = MsgBox("If you continue, you will DELETE Invoice and Cash Records!!Select YES to Continue", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
		If Response = MsgBoxResult.Yes Then
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
			
			sqlstmt = "select * from invoice WHERE invoice.dflag <> 'Y' and invoice.void <> 'Y' and invoice.trans_code = 'MISC'"
			sqlstmt = sqlstmt & " and invoice.encum_Date <= " & Chr(35) & txtfields(3).Text & Chr(35)
			sqlstmt = sqlstmt & " and invoice.units <> 1"
			sqlstmt = sqlstmt & " order by invoice.name_key "
			
			'UPGRADE_ISSUE: Data property invoice.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			invoice.recordsource = sqlstmt
			invoice.Refresh()
			
			'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			If invoice.Recordset.RecordCount <> 0 Then
				'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				invoice.Recordset.MoveFirst()
				'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Do While Not invoice.Recordset.EOF
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.delete()
					'UPGRADE_ISSUE: Data property invoice.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					invoice.Recordset.MoveNext()
				Loop 
			End If
			
			'MsgBox "Invoice Records have been Deleted."
			
			sqlstmt = "select * from cash WHERE cash.dflag <> 'Y' and cash.void_chk <> 'Y'"
			sqlstmt = sqlstmt & " and cash.encum_Date <= " & Chr(35) & txtfields(3).Text & Chr(35)
			sqlstmt = sqlstmt & " and cash.inv_num = 0 and cash.donor = 'MISC'"
			sqlstmt = sqlstmt & " order by cash.name_key "
			
			'UPGRADE_ISSUE: Data property cash.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			cash.recordsource = sqlstmt
			cash.Refresh()
			
			'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
			If cash.Recordset.RecordCount <> 0 Then
				'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				cash.Recordset.MoveFirst()
				'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
				Do While Not cash.Recordset.EOF
					'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					cash.Recordset.delete()
					'UPGRADE_ISSUE: Data property cash.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
					cash.Recordset.MoveNext()
				Loop 
			End If
			
			
			MsgBox("Records have been deleted from Invoice and Cash.")
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			
			
		Else
			MsgBox("No records have been deleted. ")
			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
			Exit Sub
		End If
		
		
		
		
		
	End Sub
	
	Private Sub Command6_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command6.Click 'statements all
		On Error Resume Next
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "armisstmt_a.rpt"
		' Call frmcrystal_Call
		If Err.Number = 20504 Then
			MsgBox("This report has not been created")
			Exit Sub
		End If
		On Error GoTo 0
	End Sub
	
	Private Sub Command7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command7.Click 'one customer
		prtDestination = CStr(0)
		prtreportfilename = ar_report_path & "armisstmt_1.rpt"
		' Call frmcrystal_Call
	End Sub
	
	
	
	'UPGRADE_ISSUE: Data event Data1.Error was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub Data1_Error(ByRef DataErr As Short, ByRef Response As Short)
		'This is where you would put error handling code
		'If you want to ignore errors, comment out the next line
		'If you want to trap them, add code here to handle them
		MsgBox("Data error event hit err:" & ErrorToString(DataErr))
		Response = 0 'throw away the error
	End Sub
	
	Private Sub frmaratb1m_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		On Error Resume Next
		
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