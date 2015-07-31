Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports System.Data.SqlClient
Imports ETS.pr_common

Public Class clpr_menu
    Inherits System.Windows.Forms.Form

    Dim rpthead As String
    Dim tmpdb As String
    Dim BegDate As Date
    Dim EndDate As Date
    Public Directdeposit As String = ConfigurationManager.AppSettings("DirectDeposit")

    Sub errorhandler(ByVal err_Renamed As Object)

        'If err_Renamed Is 424 Then
        '    MsgBox("Please contact ETS to activate this module.")
        'End If

    End Sub

    Public Sub avhr_list_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles avhr_list.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccavhrl.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Public Sub avhr_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles avhr_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDiscardSavedData = 1
        msg = "Date (" & Year(BegDate) & "," & Month(BegDate) & "," & VB.Day(BegDate) & ")"
        prtParameterFields(0) = "Beg_workdate;" & msg & ";FALSE"
        msg = "Date (" & Year(EndDate) & "," & Month(EndDate) & "," & VB.Day(EndDate) & ")"
        prtParameterFields(1) = "End_workdate;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccavghr.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""


    End Sub

    Public Sub avhr_up_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles avhr_up.Click
        'xx frmavhr.Show(1) 'lhw 12/2/02
    End Sub

    'Public Sub before_back_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles before_back.Click
    '    MsgBox("This is copying cc.mdb to before zip disk..No one else can have the file open!")
    '    'code is in mod1 5/98
    '    'ets.dat must have letter of zip drive  6/17/98
    '    Call before_backup(cc_data_path & "cc.mdb")
    'End Sub

    'Public Sub bfbkup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bfbkup.Click 'done from within the software
    '    'UPGRADE_NOTE: Object rpthead may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '    rpthead = Nothing
    '    Call before_backup(cc_data_path & "cc.mdb")
    '    MsgBox("CC has been backed up.  Now proceeding with GLNAME.")
    '    Call before_backup(gl_data_path & "glname.mdb")
    '    rpthead = tmpdb.OpenRecordset("rpthead")
    'End Sub

    'Public Sub bfgbkup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bfgbkup.Click 'done from the menu event
    '    'UPGRADE_NOTE: Object rpthead may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '    rpthead = Nothing
    '    Call before_backup(cc_data_path & "cc.mdb")
    '    MsgBox("CC has been backed up.  Now proceeding with GLNAME.")
    '    Call before_backup(gl_data_path & "glname.mdb")
    '    rpthead = tmpdb.OpenRecordset("rpthead")
    'End Sub

    Public Sub ca_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ca_rpt.Click
        prtDestination = 0
        prtreportfilename = cc_report_path & "ccalpha.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

    End Sub

    Public Sub ccdb_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ccdb.Click
        package_Type = "CC"
        Dim frmnamechk As New frmnamechk

        function_type = " "
        frmnamechk.ShowDialog()
        package_Type = "CC"
    End Sub

    Public Sub ccjf_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ccjf_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccjfile.rpt"
        CrystalForm.ShowDialog()

    End Sub



    Public Sub ccnet_ck_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ccnet_ck.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccnetck.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub cd_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cd_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccdept.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Public Sub cf_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cf_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccfund.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub cj_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cj_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDiscardSavedData = 1
        msg = "Date (" & Year(BegDate) & "," & Month(BegDate) & "," & VB.Day(BegDate) & ")"
        prtParameterFields(0) = "Beg_workdate;" & msg & ";FALSE"
        msg = "Date (" & Year(EndDate) & "," & Month(EndDate) & "," & VB.Day(EndDate) & ")"
        prtParameterFields(1) = "End_workdate;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccbyjob.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""


    End Sub

    Public Sub clijob_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles clijob.Click
        Dim clijoblookup As New clijoblookup
        function_type = ""
        clijoblookup.ShowDialog()

    End Sub

    Public Sub cnsrfrm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cnsrfrm.Click
        Dim word As New WordForm
        selected_file = "ccinput.doc"
        WordForm.ShowDialog()
        Me.BringToFront()

        word = Nothing
    End Sub

    Public Sub CPAYJE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CPAYJE.Click
        prep_je_cc.showdialog()
    End Sub

    Public Sub crecon_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles crecon.Click
        Dim ccckrecon_frm As New ccckrecon_frm
        ccckrecon_frm.ShowDialog()
    End Sub

    Public Sub cust_file_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cust_file.Click
        '    package_Type = "AR"
        '    function_type = ""
        '    frmnamechk.Show
    End Sub

    Public Sub dedlis_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dedlis.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        '1 eeded
        prtDestination = 0
        prtreportfilename = cc_report_path & "ccded.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub deduct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles deduct.Click
        Dim dedlkup As New dedlkup
        dedlkup.ShowDialog()
    End Sub

    Private Sub deposit_Click()
        'xx frmccdepsit.Show()
    End Sub

    Public Sub dep1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dep1.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccdirdep.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub Disab_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Disab.Click
        Dim disablookup As New disablookup
        function_type = ""
        disablookup.ShowDialog()

    End Sub

    Public Sub dup_Dep_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dup_Dep.Click
        Dim cc_dup_Dep As New DirectDeposit
        cc_dup_Dep.ShowDialog()
    End Sub

    Public Sub edck_alpha_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edck_alpha.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDiscardSavedData = 1
        msg = "Date (" & Year(BegDate) & "," & Month(BegDate) & "," & VB.Day(BegDate) & ")"
        prtParameterFields(0) = "Beg_workdate;" & msg & ";FALSE"
        msg = "Date (" & Year(EndDate) & "," & Month(EndDate) & "," & VB.Day(EndDate) & ")"
        prtParameterFields(1) = "End_workdate;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "cctimea.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

    End Sub

    Public Sub edck_dept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edck_dept.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDiscardSavedData = 1
        msg = "Date (" & Year(BegDate) & "," & Month(BegDate) & "," & VB.Day(BegDate) & ")"
        prtParameterFields(0) = "Beg_workdate;" & msg & ";FALSE"
        msg = "Date (" & Year(EndDate) & "," & Month(EndDate) & "," & VB.Day(EndDate) & ")"
        prtParameterFields(1) = "End_workdate;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "cctimed.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""
    End Sub

    Public Sub ee_edit_mnu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ee_edit_mnu.Click
        Dim ccpr_ed As New ccpr_ed
        entry_type = " "
        ccpr_ed.ShowDialog()

    End Sub

    Public Sub cchire_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cchire.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "cchire.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub ccjobl_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ccjobl_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccjlist.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub eetime_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles eetime.Click
        Dim clpr_start As New clpr_start
        entry_type = " "
        clpr_start.ShowDialog()

    End Sub

    Public Sub EXMAIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles exmain.Click
        Dim frmetstop As New EtsMainMenu
        frmetstop.ShowDialog()
        Me.Close()
    End Sub

    Public Sub EXWIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles exwin.Click
        Me.Close()
        End

    End Sub

    Public Sub final_alpha_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles final_alpha.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDiscardSavedData = 1
        msg = "Date (" & Year(BegDate) & "," & Month(BegDate) & "," & VB.Day(BegDate) & ")"
        prtParameterFields(0) = "Beg_workdate;" & msg & ";FALSE"
        msg = "Date (" & Year(EndDate) & "," & Month(EndDate) & "," & VB.Day(EndDate) & ")"
        prtParameterFields(1) = "End_workdate;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccfedita.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

    End Sub

    Public Sub final_dept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles final_dept.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDiscardSavedData = 1
        msg = "Date (" & Year(BegDate) & "," & Month(BegDate) & "," & VB.Day(BegDate) & ")"
        prtParameterFields(0) = "Beg_workdate;" & msg & ";FALSE"
        msg = "Date (" & Year(EndDate) & "," & Month(EndDate) & "," & VB.Day(EndDate) & ")"
        prtParameterFields(1) = "End_workdate;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccfeditd.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

    End Sub

    Private Sub clpr_menu_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Text = "ETS Consumer Payroll Opening Menu - " & agency_name
        Dim refs As New List(Of RefData)
        refs = ETSSQL.GetRefData("CC", "clpr_menu")

        For Each ref In refs
            Dim bool As Boolean
            If ref.ControlVisible = "y" Then
                bool = True
            Else
                bool = False
            End If

            Call SetMenuItem(ref.ControlName, bool)

        Next

        If Directdeposit = "Y" Then
            dup_Dep.Visible = True
            Outfile.Visible = False
        Else
            dup_Dep.Visible = False
            Outfile.Visible = True
        End If


        'check if timeline table exists so turn it off if it does not
        If CDbl(ETSSQL.GetOneSQLValue("SELECT COUNT(TABLE_NAME) as thevalue FROM INFORMATION_SCHEMA.TABLES WHERE  TABLE_NAME = 'TImeLine'")) = 0 Then
            ImportTimeSheets.Visible = False
        End If

        Dim HeaderDates As String() = ETSCommon.GetBeginEndDates.Split(CChar("*"))
        BegDate = CDate(HeaderDates(0))
        EndDate = CDate(HeaderDates(1))

    End Sub

    Private Function SetMenuItem(ByVal name As String, ByVal enabled As Boolean) As Boolean

        Dim m As ToolStripMenuItem
        m = Me.FindToolStripMenuItem(Me.MainMenu1.Items, name)
        If m IsNot Nothing Then
            m.Visible = enabled
            Return True
        Else
            Return False
        End If

    End Function

    Private Function FindToolStripMenuItem(ByRef menus As ToolStripItemCollection, ByVal name As String) As ToolStripMenuItem

        Dim found As Boolean = False
        Dim t, temp As ToolStripMenuItem
        t = CType(menus(name), ToolStripMenuItem)
        If t Is Nothing Then
            Dim i As Integer = 0
            While Not found And i < menus.Count
                If menus(i).GetType Is GetType(ToolStripMenuItem) Then
                    temp = CType(menus(i), ToolStripMenuItem)
                    t = Me.FindToolStripMenuItem(temp.DropDownItems, name)
                    found = (t IsNot Nothing)
                End If
                i += 1
            End While
        End If
        Return t

    End Function

    Public Sub gldept_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gldept_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "gldept.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub inactcc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles inactcc.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccterm.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub j2_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles j2_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccmojob.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub jobclass_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jobclass.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccjclass.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub JTITLE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles JTITLE.Click
        Dim jobnumlookup As New jobnumlookup
        function_type = ""
        jobnumlookup.ShowDialog()

    End Sub

    Public Sub MCHK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MCHK.Click
        'this is to put a "Y" in the checked field after report
        'run and is error free.....
        ETSSQL.ExecuteSQL("update cctime set checked = 'Y'")
        MsgBox("Time Cards have been Marked as Checked")
    End Sub

    Public Sub numckreg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles numckreg.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        'prtDiscardSavedData = 1
        'msg = "Date (" & Year(rpthead.Fields("check_date").Value) & "," & Month(rpthead.Fields("check_date").Value) & "," & VB.Day(rpthead.Fields("check_date").Value) & ")"
        'prtParameterFields(0) = "Check_date;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccckrnum.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub offconsumer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles offconsumer.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDiscardSavedData = 1
        msg = "Date (" & Year(BegDate) & "," & Month(BegDate) & "," & VB.Day(BegDate) & ")"
        prtParameterFields(0) = "Beg_workdate;" & msg & ";FALSE"
        msg = "Date (" & Year(EndDate) & "," & Month(EndDate) & "," & VB.Day(EndDate) & ")"
        prtParameterFields(1) = "End_workdate;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccoffc-j.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""



    End Sub

    Public Sub over_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles over_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "cco100.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub p2_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles p2_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDiscardSavedData = 1
        msg = "Date (" & Year(BegDate) & "," & Month(BegDate) & "," & VB.Day(BegDate) & ")"
        prtParameterFields(0) = "Beg_workdate;" & msg & ";FALSE"
        msg = "Date (" & Year(EndDate) & "," & Month(EndDate) & "," & VB.Day(EndDate) & ")"
        prtParameterFields(1) = "End_workdate;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccjob.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""
    End Sub

    Public Sub p4_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles p4_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDiscardSavedData = 1
        msg = "Date (" & Year(BegDate) & "," & Month(BegDate) & "," & VB.Day(BegDate) & ")"
        prtParameterFields(0) = "Beg_workdate;" & msg & ";FALSE"
        msg = "Date (" & Year(EndDate) & "," & Month(EndDate) & "," & VB.Day(EndDate) & ")"
        prtParameterFields(1) = "End_workdate;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccoff.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""
    End Sub

    Public Sub p5_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles p5_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDiscardSavedData = 1
        msg = "Date (" & Year(BegDate) & "," & Month(BegDate) & "," & VB.Day(BegDate) & ")"
        prtParameterFields(0) = "Begin work date" & msg & ";FALSE"
        msg = "Date (" & Year(EndDate) & "," & Month(EndDate) & "," & VB.Day(EndDate) & ")"
        prtParameterFields(1) = "End_workdate;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccdirind.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

    End Sub

    Public Sub Paycl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Paycl.Click
        Dim pclasslookup As New pclasslkup
        function_type = ""
        pclasslookup.ShowDialog()

    End Sub

    Public Sub payreg_all_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles payreg_all.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccckreg-0.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub Payreg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles payreg.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        'prtDiscardSavedData = 1
        'msg = "Date (" & Year(rpthead.Fields("check_date").Value) & "," & Month(rpthead.Fields("check_date").Value) & "," & VB.Day(rpthead.Fields("check_date").Value) & ")"
        'prtParameterFields(0) = "Check_date;" & msg & ";FALSE"

        'print on wide paper 0 = screen 1 = printer
        prtDestination = 0
        prtreportfilename = cc_report_path & "ccpayreg.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub pcd_doc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pcd_doc.Click
        Dim word As New WordForm
        selected_file = "ccinput.doc"
        WordForm.ShowDialog()
        Me.BringToFront()

        word = Nothing
    End Sub

    Public Sub PEDIT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PEDIT.Click
        Dim start_process As New start_process
        'Response = MsgBox(" Have you done the BEFORE Backup ? Answer No and you will be prompted to DO Before Backup. ", MsgBoxStyle.YesNo)
        'If Response = MsgBoxResult.No Then
        '    'code is in mod1 5/98
        '    'ets.dat must have letter of zip drive
        '    '   Call before_backup(cc_data_path & "cc.mdb")
        '    MsgBox("CC has been backed up.  Now proceeding with GLNAME.")
        '    '  Call before_backup(gl_data_path & "glname.mdb")

        'End If

        start_process.ShowDialog()

    End Sub

    Private Sub prtchk_Click()
        ' Dim start_proc As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object start_proc.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xx  start_proc.Show()
        'UPGRADE_WARNING: Couldn't resolve default property of object start_proc.pr_Start_date1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'xx pr_Start_date1.SetFocus()
    End Sub

    Public Sub PONEC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PONEC.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDiscardSavedData = 1
        msg = "Date (" & Year(BegDate) & "," & Month(BegDate) & "," & VB.Day(BegDate) & ")"
        prtParameterFields(0) = "Beg_workdate;" & msg & ";FALSE"
        msg = "Date (" & Year(EndDate) & "," & Month(EndDate) & "," & VB.Day(EndDate) & ")"
        prtParameterFields(1) = "End_workdate;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccltime.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""
        prtDestination = 0


    End Sub

    Private Sub QHTAX_Click()
        'prtDestination = 0
        ' prtReportFileName = cc_report_path & "eehtax.rpt"
        ' CrystalForm.showDialog
    End Sub

    Public Sub prod_alpha_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prod_alpha.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""
        Dim HeaderDates As String() = ETSCommon.GetBeginEndDates.Split(CChar("*"))
        BegDate = CDate(HeaderDates(0))
        EndDate = CDate(HeaderDates(1))

        prtDiscardSavedData = 1
        '   msg = "Date (" & Year(BegDate) & "," & Month(BegDate) & "," & VB.Day(BegDate) & ")"
        msg = BegDate.ToShortDateString
        prtParameterFields(0) = "Beg_workdate;" & msg & ";FALSE"
        '  msg = "Date (" & Year(EndDate) & "," & Month(EndDate) & "," & VB.Day(EndDate) & ")"
        msg = EndDate.ToShortDateString
        prtParameterFields(1) = "End_workdate;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccproda.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""
    End Sub

    Public Sub prod_Dept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prod_Dept.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDiscardSavedData = 1
        '   msg = "Date (" & Year(BegDate) & "," & Month(BegDate) & "," & VB.Day(BegDate) & ")"
        msg = BegDate.ToShortDateString
        prtParameterFields(0) = "Beg_workdate;" & msg & ";FALSE"
        '  msg = "Date (" & Year(EndDate) & "," & Month(EndDate) & "," & VB.Day(EndDate) & ")"
        msg = EndDate.ToShortDateString
        prtParameterFields(1) = "End_workdate;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccprodd.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

    End Sub

    Public Sub prt_crpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prt_crpt.Click
        Dim custrpt_lookup As New custrpt_lookup
        custrpt_lookup.ShowDialog()

    End Sub

    Public Sub ps_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ps_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDiscardSavedData = 1
        msg = "Date (" & Year(BegDate) & "," & Month(BegDate) & "," & VB.Day(BegDate) & ")"
        prtParameterFields(0) = "Beg_workdate;" & msg & ";FALSE"
        msg = "Date (" & Year(EndDate) & "," & Month(EndDate) & "," & VB.Day(EndDate) & ")"
        prtParameterFields(1) = "End_workdate;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccprod1.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""
    End Sub

    Public Sub psum_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles psum_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDiscardSavedData = 1
        msg = "Date (" & Year(BegDate) & "," & Month(BegDate) & "," & VB.Day(BegDate) & ")"
        prtParameterFields(0) = "Beg_workdate;" & msg & ";FALSE"
        msg = "Date (" & Year(EndDate) & "," & Month(EndDate) & "," & VB.Day(EndDate) & ")"
        prtParameterFields(1) = "End_workdate;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccprod.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

    End Sub

    Public Sub QYRPT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles QYRPT.Click
        Dim qtdytd As New MthQtrYtd
        function_type = ""
        qtdytd.ShowDialog()

    End Sub

    Private Sub Reas1_Click()
        '  Dim reasonlookup As Object
        function_type = ""
        'xx  reasonlookup.Show()
    End Sub


    Public Sub re_vac_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles re_vac.Click

        MsgBox("This can be run at any time.  It just refreshes data ")
        Call Upd_vac_table()
        MsgBox("The ccvac table has been recalculated")

    End Sub

    Public Sub Remvac_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Remvac.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccvsh.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub rev_job_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rev_job.Click
        ' Dim frmrate As Object
        'xx  frmrate.Show()
    End Sub

    Public Sub s2_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles s2_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccssind.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub s3_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles s3_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccssi.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub STPYSYS_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles STPYSYS.Click
        Dim ccprsys As New ccprsys
        ccprsys.ShowDialog()

    End Sub

    Public Sub strup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        'eework1 is created from the old data and imported using access
        'the next step is to ensure that this data is valid
        'we do this by checking the name key and saying paid = Y if not in name addr
        'write a report on paid in work1 and fix before going on to next step

        ' this creates the eeckstub and eevac tables in sync witht the original eework1
        '        db = ee_data_path & "ee.mdb"
        '        tmpdb = DAODBEngine_definst.Workspaces(0).OpenDatabase(db)
        '        tmpset = tmpdb.OpenRecordset("eework1")
        '        tmp1db = DAODBEngine_definst.OpenDatabase(gl_data_path & "glname.mdb")
        '        tmp1set = tmp1db.OpenRecordset("nam_addr", DAO.RecordsetTypeEnum.dbOpenDynaset)
        '        tmpset.MoveFirst()
        '        On Error Resume Next
        '        GoTo vac

        '        Do While Not tmpset.EOF
        '            sqlstmnt = "name_key = " & Chr(34) & tmpset.Fields("name_key").Value & Chr(34)
        '            tmp1set.FindFirst(sqlstmnt)
        '            ' tmp1set.FindFirst sqlstmnt
        '            If tmp1set.NoMatch Then
        '                tmpset.edit()
        '                tmpset.Fields("paid").Value = "Y"
        '                tmpset.Update()
        '            End If
        '            tmpset.MoveNext()
        '        Loop
        '        'it is important to have run a payroll at this time in order to create
        '        'the ckstub file
        '        'the following stop allows this to happen
        '        'the second time thru just continue
        '        Stop
        '        'we now plug the right data into ckstub from eeckx
        '        'eeckx was created with an id field as field0 so the count starts at one
        '        'UPGRADE_WARNING: Arrays in structure tmp2set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '        Dim tmp2set As DAO.Recordset
        '        'UPGRADE_WARNING: Arrays in structure eeckstub may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '        Dim eeckstub As DAO.Recordset
        '        tmp2set = tmpdb.OpenRecordset("EECKX", DAO.RecordsetTypeEnum.dbOpenDynaset)
        '        eeckstub = tmpdb.OpenRecordset("eeckstub")
        '        eeckstub.MoveFirst()

        '        Do While Not eeckstub.EOF
        '            eeckstub.edit()
        '            sqlstmnt = "field5 = " & Chr(34) & eeckstub.Fields("name_key").Value & Chr(34)
        '            tmp2set.FindFirst(sqlstmnt)
        '            If tmp2set.NoMatch Then
        '                MsgBox(" no valid data for = " & eeckstub.Fields("screen_nam").Value)
        '            Else

        '                eeckstub.Fields("full_gross").Value = tmp2set.Fields(5).Value
        '                eeckstub.Fields("fed_gross").Value = tmp2set.Fields(6).Value
        '                eeckstub.Fields("fed_Tax").Value = tmp2set.Fields(7).Value
        '                eeckstub.Fields("fica_gross").Value = tmp2set.Fields(8).Value
        '                eeckstub.Fields("fica_Tax").Value = tmp2set.Fields(9).Value
        '                eeckstub.Fields("med_gross").Value = tmp2set.Fields(10).Value
        '                eeckstub.Fields("med_tax").Value = tmp2set.Fields(11).Value
        '                eeckstub.Fields("state1_gross").Value = tmp2set.Fields(12).Value
        '                eeckstub.Fields("state1_tax").Value = tmp2set.Fields(13).Value
        '                eeckstub.Fields("state2_gross").Value = tmp2set.Fields(14).Value
        '                eeckstub.Fields("state2_tax").Value = tmp2set.Fields(15).Value
        '                eeckstub.Fields("a_nt_dol").Value = tmp2set.Fields(16).Value
        '                eeckstub.Fields("b_nt_dol").Value = tmp2set.Fields(17).Value
        '                eeckstub.Fields("c_nt_dol").Value = tmp2set.Fields(18).Value
        '                eeckstub.Fields("d_nt_Dol").Value = tmp2set.Fields(19).Value
        '                eeckstub.Fields("e_nt_dol").Value = tmp2set.Fields(20).Value
        '                eeckstub.Fields("flx_nt_Dol").Value = tmp2set.Fields(21).Value
        '                eeckstub.Fields("dep_nt_dol").Value = tmp2set.Fields(22).Value

        '                eeckstub.Update()

        '            End If
        '            eeckstub.MoveNext()
        '        Loop

        '        'we now plug the right data into eevac from eevacx

        'vac:

        '        'UPGRADE_WARNING: Arrays in structure eevac may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '        Dim eevac As DAO.Recordset
        '        tmp2set = tmpdb.OpenRecordset("EEVACX", DAO.RecordsetTypeEnum.dbOpenDynaset)
        '        eevac = tmpdb.OpenRecordset("eevac")
        '        eevac.MoveFirst()

        '        Do While Not eevac.EOF
        '            eevac.edit()
        '            sqlstmnt = "field1 = " & Chr(34) & eevac.Fields("name_key").Value & Chr(34)
        '            tmp2set.FindFirst(sqlstmnt)
        '            If tmp2set.NoMatch Then
        '                MsgBox(" no valid data for = " & eevac.Fields("screen_nam").Value)
        '            Else
        '                For num = 2 To tmp2set.Fields.Count - 1
        '                    eevac.Fields(num).Value = tmp2set.Fields(num).Value

        '                Next
        '                eevac.Fields("hrs_week").Value = eevac.Fields("hrs_week").Value / 8
        '                eevac.Update()

        '                '           eevac.Fields("full_gross") = tmp2set(4)
        '                '           eevac.Fields("fed_gross") = tmp2set(5)
        '                '           eevac.Fields("fed_Tax") = tmp2set(6)
        '                '           eevac.Fields("fica_gross") = tmp2set(7)
        '                '           eevac.Fields("fica_Tax") = tmp2set(8)
        '                ''           eevac.Fields("med_gross") = tmp2set(9)
        '                '      eevac.Fields("med_tax") = tmp2set(10)
        '                '       eevac.Fields("state1_gross") = tmp2set(11)
        '                '       eevac.Fields("state1_tax") = tmp2set(12)
        '                '       eevac.Fields("state2_gross") = tmp2set(13)
        '                '       eevac.Fields("state2_tax") = tmp2set(14)
        '                '       eevac.Fields("a_nt_dol") = tmp2set(15)
        '                '       eevac.Fields("b_nt_dol") = tmp2set(16)
        '                '       eevac.Fields("c_nt_dol") = tmp2set(17)
        '                '       eevac.Fields("d_nt_Dol") = tmp2set(18)
        '                '       eevac.Fields("e_nt_dol") = tmp2set(19)
        '                '     eevac.Fields("flx_nt_Dol") = tmp2set(20)
        '                '       eevac.Fields("dep_nt_dol") = tmp2set(21)

        '                '     eevac.Update

        '            End If
        '            eevac.MoveNext()
        '        Loop


    End Sub

    Public Sub tds_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tds_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "cctxded.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub updjob_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles updjob.Click
        Dim job_alloc As New job_alloc
        job_alloc.ShowDialog()
    End Sub

    Public Sub updrecon_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles updrecon.Click
        Dim update_recon As New update_recon
        update_recon.ShowDialog()
    End Sub

    Public Sub VCHECK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VCHECK.Click
        Dim cc_chkvoid As New cc_chkvoid
        cc_chkvoid.ShowDialog()
    End Sub

    Public Sub void_chk_gl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_chk_gl.Click
        Dim cc_chkvoid As New cc_chkvoid
        function_type = "EDIT_ADM"
        cc_chkvoid.Show()
    End Sub

    Public Sub vouchregis_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vouchregis.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDiscardSavedData = 1
        '    msg = "Date (" & Year(rpthead.Fields("check_date").Value) & "," & Month(rpthead.Fields("check_date").Value) & "," & VB.Day(rpthead.Fields("check_date").Value) & ")"
        '   prtParameterFields(0) = "ck_date;" & msg & ";FALSE"

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccvchreg.rpt"
        CrystalForm.ShowDialog()
        prtParameterFields(1) = ""
        prtParameterFields(1) = ""
    End Sub

    Public Sub wd_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles wd_rpt.Click
        prtParameterFields(0) = ""
        prtParameterFields(1) = ""

        prtDestination = 0
        prtreportfilename = cc_report_path & "ccwage.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub year_end_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles year_end.Click
        frmccyear.ShowDialog()
    End Sub

    Private Sub ImportTimeSheets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportTimeSheets.Click
        Import.ShowDialog()

    End Sub

    Private Sub WebMaint_Click(sender As System.Object, e As System.EventArgs) Handles WebMaintMenu.Click
        WebMaint.ShowDialog()

    End Sub

    Private Sub Contract_Click(sender As System.Object, e As System.EventArgs) Handles Contract.Click
        Dim Contract As New contnumlookup
        Contract.ShowDialog()

    End Sub

    Private Sub MainMenu1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MainMenu1.ItemClicked

    End Sub

    Private Sub supercoach_Click(sender As System.Object, e As System.EventArgs) Handles supercoach.Click
        function_type = "SUPERCOACH"
        package_Type = "EE"
        Dim CreateCoachRel As New CreateCoachRel
         CreateCoachRel.ShowDialog()
        package_Type = "CC"  'since in consumer payroll
        function_type = ""
    End Sub

    Private Sub Outfile_Click(sender As System.Object, e As System.EventArgs) Handles Outfile.Click
        Dim payservice As New PayService
        payservice.ShowDialog()
    End Sub

    Private Sub ConsumerCoach_Click(sender As System.Object, e As System.EventArgs) Handles ConsumerCoach.Click
        function_type = "CONSUMERCOACH"
        package_Type = "EE"
        Dim CreateCoachRel As New CreateCoachRel
        CreateCoachRel.ShowDialog()
        package_Type = "CC"  'since in consumer payroll
        function_type = ""
    End Sub

    Private Sub nameeupdate_Click(sender As System.Object, e As System.EventArgs) Handles nameeupdate.Click
        package_Type = "EE"
        Dim frmnamechk As New frmnamechk

        function_type = " "
        frmnamechk.ShowDialog()
        package_Type = "CC"
    End Sub
End Class