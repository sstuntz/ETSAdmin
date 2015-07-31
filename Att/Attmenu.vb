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
Imports PS.Common
Imports System.Data.SqlClient

Public Class AttMenu

    Inherits System.Windows.Forms.Form

    Public Sub a_data_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'not needed by JRI

        ''added 4/21/03 lhw grayson

        'frmArchive.Show(1)
        'If Err.Number <> 0 Then
        '	Exit Sub
        'End If

    End Sub

    Public Sub amend_bill_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles amend_bill.Click
        'not needed by JRI
        ' bill_amend.Show()
    End Sub

    Public Sub autho1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles autho1.Click
        'not needed by JRI
        '  Dim prtreportfilename As Object
        '	Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "autho1.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub bill_Cr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bill_Cr.Click
        Dim bill_attend As New bill_attend
        bill_attend.ShowDialog()

    End Sub

    Public Sub bill100_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bill100.Click
        'not needed by JRI
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "bill100.rpt"
        CrystalForm.ShowDialog()
    End Sub


    Private Sub bt_120_Click()
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "edatt120.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub cc_fund_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cc_fund.Click
        'not needed by JRI
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "ccfund1.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub ccbase_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ccbase.Click
        'not needed by JRI
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "ccbase.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub ccbaseact_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ccbaseact.Click
        'not needed by JRI
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "ccbaseact.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub ccbasetrm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ccbasetrm.Click
        'not needed by JRI
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "ccbasetrm.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub cccont_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cccont.Click

        'not needed by JRI
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "cccont.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub cccont1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cccont1.Click
        'not needed by JRI
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "cccont1.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub cccont2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cccont2.Click
        'not needed by JRI
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "cccont2.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub cl_rpt_Click()
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "ccbaseact.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Public Sub cld_fund_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cld_fund.Click
        Dim fundnumlookup As New fundnumlookup
        function_type = "CLD"
        fundnumlookup.ShowDialog()
        function_type = ""
    End Sub

    Public Sub closecont_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Closecont.Click
        Dim contnumlookup As New contnumlookup
        function_type = "CLD"
        contnumlookup.ShowDialog()
        function_type = ""
    End Sub

    Private Sub closedclient_Click()
        Dim frmnamechk As New frmnamechk
        function_type = "CLD"
        frmnamechk.ShowDialog()
        function_type = ""
    End Sub

    Public Sub cont_roll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cont_roll.Click
        Dim cont_rollover As New cont_rollover
        cont_rollover.ShowDialog()
    End Sub

    Public Sub contaddr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles contaddr.Click
        'not needed by JRI
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "contaddr.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub contall_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles contall.Click
        'not needed by JRI
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "contest1.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Public Sub cr_un_pv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cr_un_pv.Click
        Dim bill_unpv As New bill_unpv
        pv_Type = "CREATE"
        function_type = ""
        bill_unpv.ShowDialog()

    End Sub

    Public Sub create_bill_log1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles create_bill_log1.Click
        Dim create_bill_log As New create_bill_log
        create_bill_log.ShowDialog()
    End Sub

    Public Sub curfisc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles curfisc.Click
        current_fiscal = CInt(CStr(Year(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 6, Today))))
        function_type = "CUR"
        prognumlookup.Show()
    End Sub

    Public Sub curyr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles curyr.Click
        current_fiscal = CInt(CStr(Year(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 6, Today))))
        function_type = ""
        autholookup.ShowDialog()

    End Sub

    Public Sub edit_bill_log_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edit_bill_log.Click
        att_ed_cntrl.ShowDialog()
    End Sub

    Public Sub EXMAIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EXMAIN.Click
        Dim frmetstop As New EtsMainMenu
        Me.Dispose()
        frmetstop.ShowDialog()
        Me.Close()
    End Sub


    Public Sub EXWIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EXWIN.Click
        Me.Close()
        End
    End Sub


    Private Sub attmenu_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Text = "ETS Attendance Menu - " & agency_name

        Call med_open()
        If med_flag = "Y" Then
            medfee_mnu.Visible = True
        End If

        If proc_flag = "Y" Then
            proc_bill.Visible = True
        End If

        Dim refs As New List(Of RefData)
        refs = ETSSQL.GetRefData("ATT", "ATTMENU")

        For Each ref In refs
            Dim bool As Boolean
            If ref.ControlVisible = "y" Then
                bool = True
            Else
                bool = False
            End If

            Call SetMenuItem(ref.ControlName, bool)

        Next


    End Sub

    Public Sub frm_edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_edit.Click
        edit_attend.ShowDialog()

    End Sub

    Public Sub frm_res_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_res.Click
        create_attend.ShowDialog()
    End Sub

    Public Sub frm_nameaddr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_nameaddr.Click
        Dim frmnamechk As New frmnamechk
        function_type = ""
        frmnamechk.ShowDialog()
    End Sub
    Public Sub frm_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_rpt.Click

        'not needed by JRI
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\Monthly Invoice Log.doc"
        WordForm.ShowDialog()
        Me.BringToFront()

    End Sub

    Public Sub histview_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles histview.Click
        'not needed by JRI
        '   hist_view.Show
    End Sub

    Public Sub medfee_mnu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles medfee_mnu.Click
        'not needed by JRI
        ' medfeelookup.Show
    End Sub

    Public Sub namaddr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles namaddr.Click
        'not needed by JRI
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "namaddr.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub opencont_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opencont.Click
        function_type = ""
        contnumlookup.ShowDialog()
    End Sub

    Public Sub opn_fund_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles opn_fund.Click
        function_type = ""
        fundnumlookup.ShowDialog()
    End Sub

    Public Sub pfisc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pfisc.Click
        current_fiscal = CInt(CStr(Year(DateAdd(Microsoft.VisualBasic.DateInterval.Month, -6, Today))))
        function_type = "PRIOR"
        prognumlookup.Show()
    End Sub

    Public Sub Pgm_roll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Pgm_roll.Click
        Dim pgm_rollover As New pgm_rollover
        pgm_rollover.ShowDialog()
    End Sub

    Public Sub proc_bill_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles proc_bill.Click
        'not needed by JRI

        'entry_type = "PROC"
        'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        'Call prepare_medopn_tmp_bill()
        'Call med_write(temp_proc_num)

    End Sub

    Public Sub prog_loc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prog_loc.Click
        ' not needed by JRI

        Dim prog_loc_lookup As New prog_loc_lookup
        function_type = ""
        entry_type = "DATA_ENTRY"
        prog_loc_lookup.Show()

    End Sub

    Public Sub progedit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles progedit.Click
        'not needed by JRI

        Dim prtreportfilename As Object
        Dim prtDestination As Object
        function_type = ""
        prtDestination = 0
        prtreportfilename = att_report_path & "proglst.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Public Sub prt_log_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prt_log.Click
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "bill_cntrl.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub pryr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pryr.Click
        current_fiscal = CInt(CStr(Year(DateAdd(Microsoft.VisualBasic.DateInterval.Month, -6, Today))))
        function_type = ""
        autholookup.ShowDialog()

    End Sub

    Public Sub pv7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pv7.Click
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        function_type = ""
        prtDestination = 0
        prtreportfilename = att_report_path & "pv7.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Public Sub pvform_mnu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pvform_mnu.Click
        function_type = ""
        pv_Type = "TEMP"
        pvformlookup.ShowDialog()
    End Sub

    Public Sub rpt_typ_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpt_typ.Click
        Dim rptlookup As New rptlookup
        function_type = ""
        rptlookup.ShowDialog()
    End Sub

    Public Sub rpttype_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpttype.Click
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "rpttype.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Public Sub TCRPT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TCRPT.Click
        Dim custrpt_lookup As New custrpt_lookup
        custrpt_lookup.Show()
    End Sub

    Public Sub turn22_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles turn22.Click
        'not needed by JRI
        Dim prtreportfilename As Object
        Dim prtDestination As Object
        prtDestination = 0
        prtreportfilename = att_report_path & "turn22.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Public Sub ufr_num_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ufr_num.Click
        'not needed by JRI
        function_type = ""
        entry_type = "DATA_ENTRY"
        'ufr_lookup.Show

    End Sub

    Public Sub void_add_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_add.Click
        bill_void.ShowDialog()
    End Sub

    Public Sub void_unpv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_unpv.Click
        function_type = "VOID"
        bill_unpv.ShowDialog()

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

    Private Sub EmailControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailControl1.Click
        att_ed_cntrl.ShowDialog()
    End Sub

    Private Sub Switch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Switch.Click
        package_Type = "AR"
        Dim armenu As New armenu
        armenu.ShowDialog()
        Me.Close()
    End Sub

    Private Sub NewAdmit_Click(sender As System.Object, e As System.EventArgs) Handles NewAdmit.Click
        Dim AdmitForm As New Admitform
        AdmitForm.showdialog()
        Me.Close()
    End Sub
End Class