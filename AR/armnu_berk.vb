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

Friend Class frm_armenu
	Inherits System.Windows.Forms.Form
	
	Private Sub EDBNK_Click()
		function_type = ""
		frmnamechk.Show()
		
	End Sub
	
	Private Sub EDTYPE_Click()
		frmtype.Show()
	End Sub
	
	Public Sub add_rec_inv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles add_rec_inv.Click
        'frmrbatch.ShowDialog()
		function_type = ""
	End Sub
	
	Public Sub advr_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles advr_rpt.Click
		MsgBox(" This will print a report of ALL ADVANCE PAYMENTS")
        prtDestination = CInt(CInt(CStr(0)))
        prtreportfilename = ar_report_path & "arcbatchv.rpt"
        ' Call frmcrystal_Call

    End Sub

    Public Sub after_zip_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles after_zip.Click
        'code in mod1 5/98
        'ets.dat must have drive letter in it
        'Call after_backup(ar_data_path & "ar.mdb")
        ''code changed 9/20/01 to flag if backup not done in mod
        'If valid_yn = "Y" Then
        '	MsgBox("AR backup is complete.")
        'Else
        '	MsgBox("AR backup is NOT complete.")
        '	Exit Sub
        'End If
    End Sub

    Public Sub ar_chart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ar_chart.Click
        acctlookup.Show()
    End Sub

    Private Sub arincust_rpt_Click()
        prtDestination = CInt(CInt(CStr(0)))
        prtreportfilename = ar_report_path & "arincust.rpt"
        ' Call frmcrystal_Call
    End Sub

    Public Sub Before_Zip_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Before_Zip.Click
        'code is in mod1 5/98
        'ets.dat must have letter of zip drive
        'Call before_backup(ar_data_path & "ar.mdb")
        ''code changed 9/20/01 to flag if backup not done in mod
        'If valid_yn = "Y" Then
        '	MsgBox("AR backup is complete.")
        'Else
        '	MsgBox("AR backup is NOT complete.")
        '	Exit Sub
        'End If
    End Sub

    Private Sub cc_opn_Click()
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "ar1cc.rpt"
        ' Call frmcrystal_Call
    End Sub

    Public Sub create_rec_inv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles create_rec_inv.Click
        'recur_invlookup.Show()
    End Sub

    Private Sub csmisc_Click()
        '     Dim arcashglm_frm As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object arcashglm_frm.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	arcashglm_frm.Show()
    End Sub

    Public Sub cust_srpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cust_srpt.Click
        prtDestination = CInt(CInt(CStr(0)))
        prtreportfilename = ar_report_path & "arcust1.rpt"
        '  ' Call frmcrystal_Call

    End Sub

    Public Sub del_inv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles del_inv.Click
        Response = MsgBox("This is for Deleting Records, Continue?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = MsgBoxResult.No Then
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        'arinvdel_frm.Show()
    End Sub

    Public Sub ed_cash_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ed_cash.Click
        'frmarcash.Show()
    End Sub

    Public Sub ent_inv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ent_inv.Click
        '	invoicelookup.Show()
    End Sub

    Public Sub EXMAIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EXMAIN.Click
        EtsMainMenu.Show()
        Me.Close()
    End Sub

    Public Sub EXWIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EXWIN.Click
        Me.Close()

        End
    End Sub

    Private Sub frm_cash1_Click()
        'frmar_cash1.Show()

    End Sub

    Private Sub frm_edinv_Click()

    End Sub

    Private Sub frm_invoice_Click()
        '		invoicelookup.Show()
    End Sub

    Private Sub frm_miscinv_Click()
        '  Dim frmar_inv As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object frmar_inv.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		frmar_inv.Show()
    End Sub

    Private Sub frm_wrkinv_Click()

    End Sub

    Private Sub frminv_std_Click()

    End Sub

    Private Sub frminv_wrk_Click()
        'ar_wk_bill.Show()
    End Sub

    Private Sub frm_armenu_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Text = "ETS Accounts Receivable Menu - " & agency_name

        'tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
        'tmpset = tmpdb.OpenRecordset("reference")

        ''UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        'For num = 0 To Me.Controls.Count() - 1
        '	'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        '	If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.ToolStripMenuItem Then
        '		sqlstmnt = "select * from reference where ctrl_name = " & Chr(34) & CType(Me.Controls(num), Object).Name & Chr(34)
        '		tmpset = tmpdb.OpenRecordset(sqlstmnt)
        '		Do While Not tmpset.EOF
        '			CType(Me.Controls(num), Object).Text = tmpset.Fields("datum_desc").Value
        '			tmpset.MoveNext()
        '		Loop 
        '	End If
        'Next 

        ''this is to change command buttons and needs to be on the form where the buttons are
        ''UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        'For num = 0 To Me.Controls.Count() - 1
        '	'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        '	If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.Button Then
        '		sqlstmnt = "select * from reference where ctrl_name = " & Chr(34) & CType(Me.Controls(num), Object).Name & Chr(34)
        '		tmpset = tmpdb.OpenRecordset(sqlstmnt)
        '		Do While Not tmpset.EOF
        '			CType(Me.Controls(num), Object).Text = tmpset.Fields("datum_desc").Value
        '			tmpset.MoveNext()
        '		Loop 
        '	End If
        'Next 

    End Sub

    Public Sub frm_aratbm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_aratbm.Click
        '	frmaratb1m.ShowDialog()
    End Sub

    Public Sub frm_atbrpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_atbrpt.Click
        '		frmaratb1.ShowDialog()

    End Sub

    Public Sub frm_cashsum_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_cashsum.Click
        '		arcashgl_frm.Show()
    End Sub

    Public Sub frm_entcash1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_entcash1.Click
        ' ar_cash_edit_sel.Show
        '		ar_bat_lookup.Show()
        'frmar_cash1.Show
    End Sub

    Public Sub frm_opnrpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_opnrpt.Click
        prtDestination = CInt(CInt(CStr(0)))
        prtreportfilename = ar_report_path & "aropen.rpt"
        ' Call frmcrystal_Call
    End Sub

    Public Sub frm_rptgen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_rptgen.Click
        '   Dim custrpt_lookup As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object custrpt_lookup.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		custrpt_lookup.Show()
    End Sub

    Public Sub frm_salessum_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_salessum.Click
        '		arinvgl_frm.Show()
    End Sub

    Public Sub frmnameaddr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frmnameaddr.Click
        package_Type = "AR"
        function_type = ""
        frmnamechk.Show()
    End Sub

    Private Sub invrd_rpt_Click()
        prtDestination = CInt(CInt(CStr(0)))
        prtreportfilename = ar_report_path & "arindist.rpt"
        '  ' Call frmcrystal_Call
    End Sub

    Public Sub inv_prt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles inv_prt.Click
        prtDestination = CInt(CInt(CStr(0)))
        prtreportfilename = ar_report_path & "armprint.rpt"
        '  ' Call frmcrystal_Call
    End Sub

    Public Sub je_stat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles je_stat.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = gl_report_path & "jestat.rpt"
        '  ' Call frmcrystal_Call
    End Sub

    Public Sub jetmp_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jetmp_rpt.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arjetmp.rpt"
        '  ' Call frmcrystal_Call
    End Sub

    Public Sub minv_log_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles minv_log.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE

        ' Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\Monthly Invoice Log.doc")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.CurValues. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'PrintOptions = Word.CurValues.ToolsOptionsPrint
        ''UPGRADE_WARNING: Couldn't resolve default property of object PrintOptions.Background. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Background = PrintOptions.Background
        ''UPGRADE_NOTE: Object PrintOptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'PrintOptions = Nothing
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=0)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FilePrintDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FilePrintDefault()
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=Background)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileClose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileClose(2)
        ''UPGRADE_NOTE: Object Word may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'Word = Nothing
    End Sub

    Public Sub minv_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles minv_rpt.Click
        '   frmxaropn.ShowDialog()
    End Sub

    Private Sub one_cust_Click()

    End Sub

    Private Sub mnth_rpt_Click()
        '  Dim frmaropn As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object frmaropn.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '  frmaropn.Show()
    End Sub

    Private Sub misc_inv_Click()
        ' Dim arinvglm_frm As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object arinvglm_frm.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ' arinvglm_frm.Show()
    End Sub

    Public Sub one_pay_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles one_pay.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "ar1cust.rpt"
        ' Call frmcrystal_Call
    End Sub

    Private Sub ot_Csh_Click()
        'ar_cash_edit_sel.Show()

    End Sub

    Public Sub pap_inv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pap_inv.Click
        Response = MsgBox("This will update the invoice file.  Do you want to continue?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = 7 Then Exit Sub

        'tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
        'tmpset = tmpdb.OpenRecordset("invoice", dao.RecordsetTypeEnum.dbOpenDynaset)
        'tmp1set = tmpdb.OpenRecordset("cash", dao.RecordsetTypeEnum.dbOpenDynaset)

        'sqlstmnt = "select * from cash where trans_code = 'ADV' "
        'tmp1set = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        'Do While Not tmp1set.EOF
        '    sqlstmnt = " select * from invoice where invoice = " & Chr(34) & tmp1set.Fields("invoice").Value & Chr(34)

        '    tmpset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        '    'change trans_code to ADVP when posted to invoice
        '    If Not tmpset.EOF Then
        '        tmp1set.edit() 'cash
        '        tmp1set.Fields("trans_Code").Value = "ADVP"
        '        tmp1set.Fields("inv_num").Value = tmpset.Fields("inv_num").Value
        '        tmp1set.update()
        '        'count the number of invoice to allocate  the adv to
        '        num = 0
        '        tmpset.MoveFirst()
        '        Do While Not tmpset.EOF
        '            num = num + 1
        '            tmpset.MoveNext()
        '        Loop

        '        tot_amt = 0 'make sure it is all allocated
        '        tmpset.MoveFirst()
        '        Do While Not tmpset.EOF
        '            tmpset.edit()
        '            tmpset.Fields("paid_date").Value = tmp1set.Fields("encum_Date").Value
        '            tmpset.Fields("chk_num").Value = tmp1set.Fields("chk_num").Value
        '            tmpset.Fields("bank_key").Value = tmp1set.Fields("bank_key").Value
        '            Call bank_nameget(tmp1set.Fields("bank_key"))
        '            tmpset.Fields("bank_name").Value = bank_screen_nam
        '            tmpset.Fields("pay_amt").Value = VB6.Format(tmp1set.Fields("chk_alloc").Value / num, "FIXED")
        '            tot_amt = tot_amt + CDbl(VB6.Format(tmp1set.Fields("chk_alloc").Value / num, "FIXED"))
        '            tmpset.Fields("bal_due").Value = tmpset.Fields("bal_due").Value - CDbl(VB6.Format(tmp1set.Fields("chk_alloc").Value / num, "FIXED"))
        '            If tmpset.Fields("bal_Due").Value = 0 Then
        '                tmpset.Fields("paid").Value = "Y"
        '            End If
        '            tmpset.update()
        '            tmpset.MoveNext()
        '        Loop
        '        If tot_amt <> tmp1set.Fields("chk_alloc").Value Then
        '            tmpset.MoveLast()
        '            tmpset.edit()
        '            tmpset.Fields("pay_Amt").Value = tmpset.Fields("pay_Amt").Value + (tmp1set.Fields("chk_alloc").Value - tot_amt)
        '            tmpset.Fields("bal_Due").Value = tmpset.Fields("bal_Due").Value - (tmp1set.Fields("chk_alloc").Value - tot_amt)
        '            If tmpset.Fields("bal_Due").Value = 0 Then
        '                tmpset.Fields("paid").Value = "Y"
        '            End If
        '            tmpset.update()
        '        End If
        '    End If
        '    tmp1set.MoveNext()
        'Loop

        MsgBox("You are about to print a report of Unapplied Advance Payments")

        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arcbatchv1.rpt"
        '  ' Call frmcrystal_Call
    End Sub

    Public Sub par_close_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles par_close.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE

        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\arclose.doc")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.CurValues. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'PrintOptions = Word.CurValues.ToolsOptionsPrint
        ''UPGRADE_WARNING: Couldn't resolve default property of object PrintOptions.Background. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Background = PrintOptions.Background
        ''UPGRADE_NOTE: Object PrintOptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'PrintOptions = Nothing
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=0)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FilePrintDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FilePrintDefault()
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=Background)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileClose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileClose(2)
        ''UPGRADE_NOTE: Object Word may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'Word = Nothing
    End Sub

    Public Sub pcp_prt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pcp_prt.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE

        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("c:\etsacct\documents\Cash Posting Sheet.doc")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.CurValues. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'PrintOptions = Word.CurValues.ToolsOptionsPrint
        ''UPGRADE_WARNING: Couldn't resolve default property of object PrintOptions.Background. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Background = PrintOptions.Background
        ''UPGRADE_NOTE: Object PrintOptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'PrintOptions = Nothing
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=0)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FilePrintDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FilePrintDefault()
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=Background)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileClose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileClose(2)
        ''UPGRADE_NOTE: Object Word may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'Word = Nothing
    End Sub

    Public Sub pcr_void_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pcr_void.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE

        '    Dim Word As Object
        '   Dim PrintOptions As Object
        '    Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\arvoid.doc")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.CurValues. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'PrintOptions = Word.CurValues.ToolsOptionsPrint
        ''UPGRADE_WARNING: Couldn't resolve default property of object PrintOptions.Background. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Background = PrintOptions.Background
        ''UPGRADE_NOTE: Object PrintOptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'PrintOptions = Nothing
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=0)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FilePrintDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FilePrintDefault()
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=Background)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileClose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileClose(2)
        ''UPGRADE_NOTE: Object Word may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'Word = Nothing
    End Sub

    Public Sub pinv_void_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pinv_void.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE

        '    Dim Word As Object
        '   Dim PrintOptions As Object
        ''   Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\arvoid.doc")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.CurValues. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'PrintOptions = Word.CurValues.ToolsOptionsPrint
        ''UPGRADE_WARNING: Couldn't resolve default property of object PrintOptions.Background. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Background = PrintOptions.Background
        ''UPGRADE_NOTE: Object PrintOptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'PrintOptions = Nothing
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=0)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FilePrintDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FilePrintDefault()
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=Background)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileClose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileClose(2)
        ''UPGRADE_NOTE: Object Word may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'Word = Nothing
    End Sub

    Public Sub PMINVED_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PMINVED.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arinved.rpt"
        '  ' Call frmcrystal_Call
    End Sub

    Public Sub prt_chart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prt_chart.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ap_report_path & "glchart.rpt"
        '  ' Call frmcrystal_Call
    End Sub

    Public Sub prt_log_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prt_log.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE

        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\Monthly Cash Log.doc")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.CurValues. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'PrintOptions = Word.CurValues.ToolsOptionsPrint
        ''UPGRADE_WARNING: Couldn't resolve default property of object PrintOptions.Background. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Background = PrintOptions.Background
        ''UPGRADE_NOTE: Object PrintOptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'PrintOptions = Nothing
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=0)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FilePrintDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FilePrintDefault()
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=Background)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileClose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileClose(2)
        ''UPGRADE_NOTE: Object Word may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'Word = Nothing
    End Sub

    Private Sub re_bal_due_Click()
        MsgBox("Be patient. This may take awhile")
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        '  Call check_for_Complete_invoice(0, Today)
        MsgBox("Process Complete")
        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Public Sub rec_bal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rec_bal.Click
        '  Dim ar_cal_bal As Object
        Response = MsgBox("This will update payment dates, Continue?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = MsgBoxResult.No Then
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
        'UPGRADE_WARNING: Couldn't resolve default property of object ar_cal_bal.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '   ar_cal_bal.Show()
    End Sub

    Public Sub reg_int_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles reg_int.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE

        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\A R cash.doc")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.CurValues. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'PrintOptions = Word.CurValues.ToolsOptionsPrint
        ''UPGRADE_WARNING: Couldn't resolve default property of object PrintOptions.Background. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Background = PrintOptions.Background
        ''UPGRADE_NOTE: Object PrintOptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'PrintOptions = Nothing
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=0)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FilePrintDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FilePrintDefault()
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=Background)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileClose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileClose(2)
        ''UPGRADE_NOTE: Object Word may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'Word = Nothing
    End Sub

    Public Sub rev_cash_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rev_cash.Click
        'ar_cash_rev1.Show()
    End Sub

    Public Sub rpt_bank_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpt_bank.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ap_report_path & "arbank.rpt"
        '  ' Call frmcrystal_Call
    End Sub

    Public Sub rpt_csort_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpt_csort.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arcusta.rpt"
        '  ' Call frmcrystal_Call
    End Sub

    Private Sub rpt_edcash_Click()
        '   frmcaropn.Show
    End Sub

    Public Sub rpt_invdoc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpt_invdoc.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE

        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\arinv.doc")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.CurValues. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'PrintOptions = Word.CurValues.ToolsOptionsPrint
        ''UPGRADE_WARNING: Couldn't resolve default property of object PrintOptions.Background. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Background = PrintOptions.Background
        ''UPGRADE_NOTE: Object PrintOptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'PrintOptions = Nothing
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=0)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FilePrintDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FilePrintDefault()
        'If (Background <> 0) Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Word.ToolsOptionsPrint(Background:=Background)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileClose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileClose(2)
        ''UPGRADE_NOTE: Object Word may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'Word = Nothing
    End Sub

    Public Sub rpt_mcshreg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpt_mcshreg.Click
        '  frmcaropn.Show()
    End Sub

    Private Sub rpt_minvreg_Click()
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arinvd.rpt"
        '  ' Call frmcrystal_Call
    End Sub

    Public Sub rpt_num_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpt_num.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arcustn.rpt"
        '  ' Call frmcrystal_Call
    End Sub

    Private Sub rpt_stmtage_Click()
        '  frmstmt.Show()
    End Sub

    Public Sub unpd_cons_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles unpd_cons.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "ar1cc.rpt"
        ' Call frmcrystal_Call
    End Sub

    Public Sub UPCKF_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles UPCKF.Click
        '  arupchk.Show()

    End Sub

    Public Sub vcash_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vcash_rpt.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arckvoided.rpt"
        '  ' Call frmcrystal_Call
    End Sub

    Public Sub vinv_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vinv_rpt.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arinvvoided.rpt"
        '  ' Call frmcrystal_Call
    End Sub
	
	Public Sub void_cash_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_cash.Click
        '	arcashvd_frm1.Show()
	End Sub
	
	Public Sub void_inv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_inv.Click
        'arinvvd_frm1.Show()
	End Sub
	
	Public Sub wire_int_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles wire_int.Click
		'this is the code to print a txt file
		'the txt file will contain instructions
		'ALL OF THE CODE IS HERE
		
        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer
		
        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\A R Wire or Multiline pmt.doc")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.CurValues. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'PrintOptions = Word.CurValues.ToolsOptionsPrint
        ''UPGRADE_WARNING: Couldn't resolve default property of object PrintOptions.Background. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Background = PrintOptions.Background
        ''UPGRADE_NOTE: Object PrintOptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'PrintOptions = Nothing
        'If (Background <> 0) Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	Word.ToolsOptionsPrint(Background:=0)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FilePrintDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FilePrintDefault()
        'If (Background <> 0) Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	Word.ToolsOptionsPrint(Background:=Background)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileClose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileClose(2)
        ''UPGRADE_NOTE: Object Word may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'Word = Nothing
	End Sub
End Class