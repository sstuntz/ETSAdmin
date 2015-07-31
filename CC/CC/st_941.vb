Option Strict On
Option Explicit On
Imports ETSCommon
Imports ETSCommon.MODULE1
Imports ETSCommon.Database
Imports System.Configuration
Imports System.Data.SqlClient
Imports System
Imports ETSCommon.ETSCommon
Imports Microsoft.VisualBasic.PowerPacks
Friend Class cc_qtdytd
	Inherits System.Windows.Forms.Form
	Dim end_quarter_date As Date
	Dim present_quarter_date As Date
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		Me.Close()
	End Sub
	
	Private Sub Command1_Click()
		MsgBox("This report has not been created.")
		'prtDestination = 0
		' prtReportFileName = cc_report_path & "ccmntx.rpt"
		'call frmcrystal_call
		
    End Sub
	
	Private Sub Command3_Click()
		'prtDestination = 0
		' prtReportFileName = ee_report_path & "eehta.rpt"
		'call frmcrystal_call
	End Sub
	
	Private Sub Command4_Click()
		'prtDestination = 0
		' prtReportFileName = ee_report_path & "eemui.rpt"
		'call frmcrystal_call
	End Sub
	
	Private Sub cc_run941_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cc_run941.Click
        '		'revised 4/30/01 lhw
        '		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Do While Not cc_941.Recordset.EOF
        '			'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			cc_941.Recordset.Delete()
        '			'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			cc_941.Recordset.MoveNext()
        '		Loop 

        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.AddNew()


        '		db = cc_data_path & "cc.mdb"
        '		tmp1db = DAODBEngine_definst.OpenDatabase(db)
        '		tmp1set = tmp1db.OpenRecordset("ccsys", dao.RecordsetTypeEnum.dbOpenDynaset)
        '		tmp1set.MoveFirst()

        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Fields("er_fed_id").Value = tmp1set.Fields("er_fed_id").Value
        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Fields("agency_name").Value = tmp1set.Fields("agency_name").Value
        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Fields("qtr_End_date").Value = end_quarter_date

        '		'set the sql to get the records from ckstub that you want and the order date
        '		sqlstmnt = "select * from ccckstub where void = 'N' and chk_Date between "
        '		sqlstmnt = sqlstmnt & Chr(35) & present_quarter_date & Chr(35) & " and "
        '		sqlstmnt = sqlstmnt & Chr(35) & end_quarter_date & Chr(35)
        '		sqlstmnt = sqlstmnt & " order by chk_date"
        '		'UPGRADE_ISSUE: Data property ccckstub.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		ccckstub.RecordSource = sqlstmnt
        '		ccckstub.Refresh()
        '		'   On Error Resume Next
        '		'we need to check if there are any records

        '		'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		If ccckstub.Recordset.RecordCount = 0 Then
        '			MsgBox("Nothing to report")
        '			ets_set_selected()
        '			'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '			Exit Sub
        '		End If

        '		'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		ccckstub.Recordset.MoveFirst()

        '		Dim tot_941 As Decimal

        '		'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		Do While Not ccckstub.Recordset.EOF
        '			'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			Select Case Month(ccckstub.Recordset.Fields("chk_Date").Value)

        '				Case 1, 4, 7, 10
        '					'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					msg = "a" & VB.Day(ccckstub.Recordset.Fields("chk_Date").Value)
        '					'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					tot_941 = ccckstub.Recordset.Fields("fica_Tax").Value * 2 + ccckstub.Recordset.Fields("med_Tax").Value * 2 + ccckstub.Recordset.Fields("fed_tax").Value + ccckstub.Recordset.Fields("add_fwt").Value
        '					'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					cc_941.Recordset.Fields(msg).Value = cc_941.Recordset.Fields(msg).Value + tot_941

        '				Case 2, 5, 8, 11
        '					'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					msg = "b" & VB.Day(ccckstub.Recordset.Fields("chk_Date").Value)
        '					'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					tot_941 = ccckstub.Recordset.Fields("fica_Tax").Value * 2 + ccckstub.Recordset.Fields("med_Tax").Value * 2 + ccckstub.Recordset.Fields("fed_tax").Value + ccckstub.Recordset.Fields("add_fwt").Value
        '					'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					cc_941.Recordset.Fields(msg).Value = cc_941.Recordset.Fields(msg).Value + tot_941

        '				Case 3, 6, 9, 12
        '					'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					msg = "c" & VB.Day(ccckstub.Recordset.Fields("chk_Date").Value)
        '					'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					tot_941 = ccckstub.Recordset.Fields("fica_Tax").Value * 2 + ccckstub.Recordset.Fields("med_Tax").Value * 2 + ccckstub.Recordset.Fields("fed_tax").Value + ccckstub.Recordset.Fields("add_fwt").Value
        '					'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '					cc_941.Recordset.Fields(msg).Value = cc_941.Recordset.Fields(msg).Value + tot_941

        '			End Select
        '			' the other totals
        '			'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			cc_941.Recordset.Fields("l2_tot").Value = cc_941.Recordset.Fields("l2_Tot").Value + ccckstub.Recordset.Fields("fed_gross").Value
        '			'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			cc_941.Recordset.Fields("l3_tax").Value = cc_941.Recordset.Fields("l3_tax").Value + ccckstub.Recordset.Fields("fed_tax").Value + ccckstub.Recordset.Fields("add_fwt").Value
        '			'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			cc_941.Recordset.Fields("l6a_swages").Value = cc_941.Recordset.Fields("l6a_swages").Value + ccckstub.Recordset.Fields("fica_gross").Value
        '			'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			cc_941.Recordset.Fields("l7a_mwages").Value = cc_941.Recordset.Fields("l7a_mwages").Value + ccckstub.Recordset.Fields("med_gross").Value


        '			'UPGRADE_ISSUE: Data property ccckstub.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			ccckstub.Recordset.MoveNext()
        '		Loop 

        '		'now we do the data fields

        '		For num = 1 To 31
        '			msg = "a" & num
        '			'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			cc_941.Recordset.Fields("a_Tot").Value = cc_941.Recordset.Fields("a_tot").Value + cc_941.Recordset.Fields(msg).Value
        '		Next 

        '		For num = 1 To 31
        '			msg = "b" & num
        '			'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			cc_941.Recordset.Fields("b_Tot").Value = cc_941.Recordset.Fields("b_tot").Value + cc_941.Recordset.Fields(msg).Value
        '		Next 

        '		For num = 1 To 31
        '			msg = "c" & num
        '			'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			cc_941.Recordset.Fields("c_Tot").Value = cc_941.Recordset.Fields("c_tot").Value + cc_941.Recordset.Fields(msg).Value
        '		Next 

        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Fields("qtr_Tot").Value = cc_941.Recordset.Fields("a_Tot").Value + cc_941.Recordset.Fields("b_Tot").Value + cc_941.Recordset.Fields("c_Tot").Value
        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Fields("l17_dep").Value = cc_941.Recordset.Fields("qtr_Tot").Value

        'reask: 
        '		msg = InputBox("Enter any Adjustment of withheld income tax",  , CStr(0))
        '		If Not IsNumeric(msg) Then
        '			MsgBox("Please enter a number")
        '			GoTo reask
        '		End If
        '		'UPGRADE_ISSUE: Data property tax_tbls.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		tax_tbls.Recordset.MoveFirst()
        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Fields("l4_adj").Value = Val(msg)
        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Fields("l5_adj_tot").Value = cc_941.Recordset.Fields("l3_tax").Value + cc_941.Recordset.Fields("l4_adj").Value
        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_ISSUE: Data property tax_tbls.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Fields("l6b_ss").Value = VB6.Format(cc_941.Recordset.Fields("l6a_swages").Value * tax_tbls.Recordset.Fields("fica_pct").Value * 2, "FIXED")
        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_ISSUE: Data property tax_tbls.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Fields("l7b_med").Value = VB6.Format(cc_941.Recordset.Fields("l7a_mwages").Value * tax_tbls.Recordset.Fields("med_pct").Value * 2, "FIXED")
        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Fields("l8_tot").Value = cc_941.Recordset.Fields("l6b_ss").Value + cc_941.Recordset.Fields("l7b_med").Value

        'reask1: 
        '		msg = InputBox("Enter any Adjustment of fica or med tax",  , CStr(0))
        '		If Not IsNumeric(msg) Then
        '			MsgBox("Please enter a number")
        '			GoTo reask1
        '		End If

        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Fields("l9_ss_adj").Value = Val(msg)

        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Fields("l10_fime").Value = cc_941.Recordset.Fields("l8_tot").Value + cc_941.Recordset.Fields("l9_ss_adj").Value
        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Fields("l11_ttax").Value = cc_941.Recordset.Fields("l5_adj_tot").Value + cc_941.Recordset.Fields("l10_fime").Value
        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Fields("l13_net").Value = cc_941.Recordset.Fields("l11_ttax").Value
        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Fields("l14_tdep").Value = cc_941.Recordset.Fields("l17_dep").Value

        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		If (cc_941.Recordset.Fields("l13_net").Value - cc_941.Recordset.Fields("l14_tdep").Value) > 0 Then
        '			'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			cc_941.Recordset.Fields("l15_bal").Value = cc_941.Recordset.Fields("l13_net").Value - cc_941.Recordset.Fields("l14_tdep").Value
        '		Else
        '			'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '			cc_941.Recordset.Fields("l16_owe").Value = cc_941.Recordset.Fields("l13_net").Value - cc_941.Recordset.Fields("l14_tdep").Value
        '		End If
        '		'UPGRADE_ISSUE: Data property cc_941.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		cc_941.Recordset.Update()

        '		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '		MsgBox("Now you will print the 941.")


        '		prtDestination = CStr(0)
        '		prtreportfilename = cc_report_path & "cc_941.rpt"
        '		Call frmcrystal_Call()
		
	End Sub
	
	Private Sub edsys_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edsys.Click
        'w2sys.ShowDialog()
    End Sub

	Private Sub eehta_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles eehta.Click
		MsgBox("This report is not used for Consumer Payroll")
		'prtDestination = 0
		' prtReportFileName = ee_report_path & "eehta.rpt"
		'call frmcrystal_call
	End Sub
	
	Private Sub final_proof_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles final_proof.Click '1/9/03 lhw added also ee
        'MsgBox(" You must have Crystal Ver7 or higher to print this report.")
        'MsgBox("This is the data printed on the W2 Forms.")

        'MsgBox("This is the data printed on the W2 Form's.")
        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "new_ccw2.rpt"
        'Call frmcrystal_Call()
	End Sub
	
	Private Sub cc_qtdytd_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

    End Sub
	
	Private Sub load_w2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles load_w2.Click
        MsgBox("This is moving data from nam_addr, NAM_CC , and CCYTD.")

        sqlstmnt = "delete from ccw2; "
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = sqlstmnt
            db.ExecuteQuery(sql)
        End Using
        'need to put year into ccw2

        sqlstmnt = " With CTE as (Select nam_addr.name_key, nam_addr.screen_nam, nam_addr.sort_name, nam_addr.salutation, nam_addr.first_name, nam_addr.middle_ini, nam_addr.last_name, "
        sqlstmnt = sqlstmnt & "  nam_addr.suffix, nam_addr.address1, nam_addr.address2, nam_addr.city, nam_addr.state, nam_addr.zip4, nam_cc.ss_num, nam_cc.dept_num, nam_cc.desc1, "
        sqlstmnt = sqlstmnt & "     nam_cc.desc2, nam_cc.state1_tax, nam_cc.state2_tax, ccytd.ytd_full_gross, ccytd.ytd_makeup, ccytd.ytd_fed_gross, ccytd.ytd_fica_gross, ccytd.ytd_med_gross, "
        sqlstmnt = sqlstmnt & "    ccytd.ytd_st1_gross, ccytd.ytd_st2_gross, ccytd.ytd_fed_tax, ccytd.ytd_fica_tax, ccytd.ytd_med_tax, ccytd.ytd_st1_tax, ccytd.ytd_st2_tax, ccytd.ytd_aeic, "
        sqlstmnt = sqlstmnt & "  ccytd.ytd_tdi FROM  ccytd INNER JOIN   nam_addr ON ccytd.name_key = nam_addr.name_key INNER JOIN"
        sqlstmnt = sqlstmnt & "  nam_cc ON ccytd.name_key = nam_cc.name_key"
        sqlstmnt = sqlstmnt & " WHERE(ccytd.ytd_full_gross <> 0))"
        sqlstmnt = sqlstmnt & "insert into ccw2 (select * from cte) "

        MsgBox("All Data has moved to Table: CCW2.")

    End Sub
	
	Private Sub mswage_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mswage.Click
        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccmswage.rpt"
        'Call frmcrystal_Call()
	End Sub
	
	Private Sub MUI_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MUI.Click
        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccmui.rpt"
        'Call frmcrystal_Call()
	End Sub
	
	Private Sub present_qtr_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles present_qtr_num.Leave
		present_qtr_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
	
	Private Sub qtdytd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles qtdytd.Click
        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccqtdytd.rpt"
        'Call frmcrystal_Call()
	End Sub
	
	Private Sub present_qtr_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles present_qtr_num.Enter
		Call ets_set_selected()
	End Sub
	
	Private Sub present_qtr_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles present_qtr_num.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
		If KeyAscii = 13 Or KeyAscii = 9 Then

            If Not IsNumeric(present_qtr_num.Text) Then
                MsgBox("You must enter a number")
                Call ets_set_selected()
                GoTo EventExitSub
            End If
			
			If Val(present_qtr_num.Text) > 4 Or Val(present_qtr_num.Text) < 1 Then
				MsgBox("You must enter a number between 1 and 4")
				Call ets_set_selected()
				GoTo EventExitSub
			End If
			
			Select Case present_qtr_num.Text
				Case CStr(1)
					present_quarter_date = CDate("1/1/" & Year(Today))
					end_quarter_date = CDate("3/31/" & Year(Today))
				Case CStr(2)
					present_quarter_date = CDate("4/1/" & Year(Today))
					end_quarter_date = CDate("6/30/" & Year(Today))
				Case CStr(3)
					present_quarter_date = CDate("7/1/" & Year(Today))
					end_quarter_date = CDate("9/30/" & Year(Today))
				Case CStr(4)
					present_quarter_date = CDate("10/1/" & Year(Today))
					end_quarter_date = CDate("12/31/" & Year(Today))
				Case Else
					present_quarter_date = CDate("1/1/" & Year(Today))
					end_quarter_date = CDate("12/31/" & Year(Today))
			End Select

            Call ytd_create(CInt(present_qtr_num.Text))
            MsgBox("Data File is loaded. You can now print reports.")
        End If

EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
		Call ets_set_selected()
	End Sub
	
	Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
		If KeyAscii = 13 Or KeyAscii = 9 Then			
            If Len(txtfields.Text) <> 4 Then
                MsgBox("Please enter 4 digit Tax Year.")
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
	
	Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Leave
		txtfields.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
	End Sub
	
	Private Sub w2_recon_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles w2_recon.Click
		
        'MsgBox("Print this report on wide(legal) paper.")
        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccw2proof.rpt"
        'Call frmcrystal_Call()
		
	End Sub
End Class