Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETS.Common.Module1
Imports PS.Common
Imports Microsoft.VisualBasic.ErrObject
Imports System.Data.SqlClient
Imports System
Imports System.Configuration

Public Class frm_mnuap
    Inherits System.Windows.Forms.Form

    Public Sub addname_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addname.Click
        Dim frmnamechk As New frmnamechk
        function_type = ""
        frmnamechk.Show()
    End Sub

    Public Sub after_zip_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles after_zip.Click
        'decide what tables to backup
        Call ETSSQL.AfterBackup("yrgenled")
    End Sub

    Public Sub alloc_tbl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles alloc_tbl.Click
        Dim apAllocLookup As New apAllocLookup
        apalloclookup.Show()
    End Sub

    Public Sub apalloc_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles apalloc_rpt.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "apalloc.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub apclose_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles apclose_rpt.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\apclose.doc"
        WordForm.ShowDialog()
        Me.BringToFront()
    End Sub

    Public Sub apmck_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles apmck.Click
        apmckreg.Show()
    End Sub

    Public Sub apmvch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles apmvch.Click
        apmvreg.Show()
    End Sub

    Public Sub aprdoc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles aprdoc.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\aprecon.doc"
        WordForm.ShowDialog()
        Me.BringToFront()

    End Sub

    Public Sub BATCHED_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim apvch_ed1 As New apvch_ed1
        apvch_ed1.Show()
    End Sub

    Public Sub Before_Zip_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles before_zip.Click
        'decide what tables to backup
        Call ETSSQL.BeforeBackup("yrgenled")
    End Sub

    Public Sub bnklst_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bnklst.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "apbank.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub CHKDOC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CHKDOC.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\apcheck.doc"
        WordForm.ShowDialog()
        Me.BringToFront()

    End Sub

    Public Sub CHKPRT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CHKPRT.Click
        frmcompchk.Show()
    End Sub

    Public Sub CHKVOID_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CHKVOID.Click
        apckvoid1_frm.Show()
    End Sub

    Public Sub del_vch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles del_vch.Click
        'reimbursement checks not in ap yet
        Response = MsgBox("This is for Deleting Records, Continue?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        apvchdel_frm.Show()
    End Sub

    Public Sub e_m_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles e_m.Click
        frmmanual.Show()
    End Sub

    Public Sub ed_ck_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ed_ck.Click
        'reimbursement checks
        ' applk.Show
    End Sub

    Public Sub EDCHART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EDCHART.Click
        Dim acctlookup As New acctlookup
        'function_type = "DATA_ENTRY"
        acctlookup.ShowDialog() 'always this for chart      
    End Sub

    Public Sub edsys_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edsys.Click
        ' entry_type = ""
        Dim frmsys As New frmsys
        frmsys.Show()
    End Sub

    Public Sub EDVOUCH_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EDVOUCH.Click
        Dim apvch_ed1 As New apvch_ed1

        apvch_ed1.ShowDialog()

    End Sub

    Public Sub ent_data_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ent_data.Click
        'reimbursement checks not in ap yet
        '  applk.Show
    End Sub

    Public Sub EXMAIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EXMAIN.Click
        Dim frmetstop As New EtsMainMenu
        EtsMainMenu.Show()
        Me.Close()
        Me.Dispose()
    End Sub

    Public Sub EXWIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EXWIN.Click
        Me.Close()
        End
    End Sub

    Private Sub frm_mnuap_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Text = "ETS Accounts Payable Menu - " ' & agency_name
        ap_report_path = ReportPath
        'change menu item menu names here

    End Sub

    Public Sub gl_chart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gl_chart.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glchart.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub int_prt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles int_prt.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\apmanck.doc"
        WordForm.ShowDialog()
        Me.BringToFront()
    End Sub

    Public Sub je_tmp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles je_tmp.Click
        prtDestination = 0
        prtreportfilename = ar_report_path & "arjetmp.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub JESTAT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles JESTAT.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "jestat.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub load_vend_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles load_vend.Click
        'not in bershire  load vendor for 1099
        ' ap1099.Show()
    End Sub

    Public Sub MATB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MATB.Click
        apatb_frm.Show()
    End Sub

    Public Sub misc_doc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles misc_doc.Click
        'reimbursement checks not in ap yet
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\apmiscpmt.doc"
        WordForm.ShowDialog()
        Me.BringToFront()
    End Sub

    Public Sub mp_log_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mp_log.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\Monthly Payment Log.doc"
        WordForm.ShowDialog()
        Me.BringToFront()
    End Sub

    Public Sub MRC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MRC.Click
        apckrcon_frm1.Show()
    End Sub

    Public Sub mv_log_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mv_log.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\monthly voucher log.doc"
        WordForm.ShowDialog()
        Me.BringToFront()
    End Sub

    Public Sub PAYSUM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PAYSUM.Click
        Dim frmappygl As New frmappygl
        frmappygl.Show()
        'on this we print the monthly ck register

    End Sub

    Public Sub po_mnu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles po_mnu.Click
        'POs not berk
        '   ap_purch_mnu.Show
    End Sub

    Public Sub ponev_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ponev.Click
        apsvch_frm.Show()
    End Sub

    Public Sub pr_int_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_int.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\apvoid.doc"
        WordForm.ShowDialog()
        Me.BringToFront()
    End Sub

    Public Sub prt_1099_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prt_1099.Click
        'reimbursement checks
        '   frm1099.Show
    End Sub

    Public Sub prt_chk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prt_chk.Click
        'reimbursement checks not in ap yet
        '   apmcheck.Show 1
    End Sub

    Public Sub prt_edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prt_edit.Click
        'reimbursement checks not in ap yet
        prtDestination = 0
        prtreportfilename = ap_report_path & "apmsck.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Public Sub Prv_rec_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Prv_rec.Click
        rec_select_process.Show()
    End Sub

    Public Sub PSTAT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PSTAT.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "pmtstat.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub PVCR_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PVCR.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "allvdck.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub PVVR_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PVVR.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "allvvch.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub rec_vouch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rec_vouch.Click
        Dim rec_select As New rec_select
        rec_select.Show()
    End Sub

    Public Sub revedit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles revedit.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "apvedit.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub rpt_gen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RPT_GEN.Click
        Dim custrpt_lookup As New custrpt_lookup
        custrpt_lookup.Show()
    End Sub

    Public Sub rptopn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rptopn.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "apvopn.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub st_cks_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles st_cks.Click
        'reimbursement checks not in ap yet
        'Response = MsgBox("This will erase previous records. Only do this a the beginning of a batch! Select YES to continue?", MsgBoxStyle.YesNo)
        'If Response = MsgBoxResult.No Then
        '	Me.Close()
        'Else
        '	'clear the miscpmt file
        '	tmpdb = DAODBEngine_definst.OpenDatabase(ap_data_path & "ap.mdb")
        '	tmpset = tmpdb.OpenRecordset("miscpmt")
        '	On Error Resume Next
        '	tmpset.MoveFirst()
        '	If Err.Number = 3021 Then
        '		MsgBox("There are no records to delete.")
        '		Exit Sub
        '	End If

        '	Do While Not tmpset.EOF
        '		tmpset.Delete()
        '		tmpset.MoveNext()
        '	Loop 

        'End If
        'MsgBox("You can now enter a new Batch of Travel Checks.")

    End Sub

    Public Sub ten_list_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ten_list.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "apv1099.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub trav_reim_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles trav_reim.Click
        'reimbursement checks not in ap yet
        'entry_type = "ADD"
        '  frmmisp.Show 1
    End Sub

    Public Sub upcheck_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles upcheck.Click
        Dim apupchk As New apupchk
        apupchk.Show()

    End Sub

    Public Sub VCHDOC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VCHDOC.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\apvouch.doc"
        WordForm.ShowDialog()
        Me.BringToFront()
    End Sub

    Public Sub VCHSUM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VCHSUM.Click
        Dim apvchgl_frm As New apvchgl_frm
        apvchgl_frm.Show()
    End Sub

    Public Sub VCHVOID_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VCHVOID.Click
        Dim apvchvoid1_frm As New apvchvoid1_frm
        apvchvoid1_frm.Show()

    End Sub

    Public Sub VDATE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vdate.Click
        apvdr_frm.Show()
    End Sub

    Public Sub vdater_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vdater.Click
        apvvd_frm.Show()
    End Sub

    Public Sub VLIST_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VLIST.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "apvendor.rpt"
        CrystalForm.ShowDialog()
    End Sub


    Public Sub VSTAT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VSTAT.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "apstat.rpt"
        CrystalForm.ShowDialog()
    End Sub


    Public Sub vv_doc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vv_doc.Click

        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\apvoid.doc"
        WordForm.ShowDialog()
        Me.BringToFront()

    End Sub

    Private Sub APCASHT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles APCASHT.Click
        Dim ap_cash As New ap_cash
        ap_cash.Show()
    End Sub

End Class