Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports Valid_YN
Imports Microsoft.Office
Imports ETS


Public Class frm_mnugl
    Inherits System.Windows.Forms.Form

    Public Sub add_dpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles add_dpt.Click
        frmgladd.ShowDialog()
    End Sub

    Public Sub add_std_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles add_std.Click
        frmje_x2.ShowDialog() '11/14/2005 lhw
    End Sub

    Public Sub alcalc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles alcalc.Click
        frmglalloc.ShowDialog()
    End Sub

    Public Sub bal_across_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bal_across.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glbal_across.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub bud_month_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bud_month.Enter
        Call ets_set_selected()
    End Sub

    Private Sub bud_month_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles bud_month.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            If CDbl(bud_month.Text) < 1 Or CDbl(bud_month.Text) > 12 Then
                MsgBox("Bad Month was entered.")
                GoTo EventExitSub
                Call ets_set_selected()
            End If

            sqlstmnt = "update chacct set bud_ytd =  bud_m1 "
            For num As Integer = 1 To CInt(bud_month.Text)
                sqlstmnt = sqlstmnt & "  + bud_m" & num.ToString
            Next
            ETSSQL.ExecuteSQL(sqlstmnt)
            bud_month.Visible = False
            Label4.Visible = False
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Public Sub CHACCT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CHACCT.Click
        entry_type = ""
        acctlookup.Show() 'always this for chart
    End Sub

    Private Sub CONALLOC_Click()
        frmglalloc.Show()
    End Sub

    Private Sub CVIEW_Click()

    End Sub

    Public Sub CINCBUD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CINCBUD.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "gliecons.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub close_doc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles close_doc.Click

        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\GL EOM Close.doc"
        WordForm.ShowDialog()
        Me.BringToFront()

    End Sub

    Private Sub copy_gl_Click()
        'copy a file to a backup destination, trap for error if disk not in drive
        MsgBox("Be sure that you have the BEFORE GL.MDB Data Disk in the Zip Drive.  You are backing up several large files so be patience")
        On Error Resume Next
        FileCopy(gl_data_path & "glchr.mdb", "e:\etsacct\glchr.mdb")
        FileCopy(gl_data_path & "gljrnl.mdb", "e:\etsacct\gljrnl.mdb")
        If Err.Number = 71 Then
            MsgBox("NO BACKUP DONE.  Go back to menu and follow instructions!")
            Exit Sub
        End If
        MsgBox("Be sure to remove the BEFORE GL.MDB Data Disk from the Zip Drive")
    End Sub

    Private Sub cml_cons_Click()
        On Error Resume Next
        prtDestination = 0
        prtreportfilename = gl_report_path & "glieconsclp.rpt"
        CrystalForm.ShowDialog()
        If Err.Number = 20504 Then
            MsgBox("This report has not been created")
            Exit Sub
        End If
        On Error GoTo 0
    End Sub

    Private Sub cmp_acct_Click()
        On Error Resume Next
        prtDestination = 0
        prtreportfilename = gl_report_path & "glieconsclp1.rpt"
        CrystalForm.ShowDialog()
        If Err.Number = 20504 Then
            MsgBox("This report has not been created")
            Exit Sub
        End If
        On Error GoTo 0
    End Sub

    Public Sub DEPT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DEPT.Click
        Dim dptnumlookup As New dptnumlookup
        package_Type = "DPT"
        dptnumlookup.Show()

    End Sub

    Public Sub ed_regje_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ed_regje.Click
        je_type = "Regular"
        jelookup.Show()
    End Sub

    Public Sub EDBUD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EDBUD.Click
        MsgBox("This is for the current Fiscal Year.")
        selected_recordsource = "Current"
        frm_budget1.ShowDialog()
    End Sub

    Public Sub ENTBEG_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ENTBEG.Click
        frmglbal1.ShowDialog()
    End Sub

    Public Sub eoy_close_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles eoy_close.Click

        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\GL EOY Close.doc"
        WordForm.ShowDialog()
        Me.BringToFront()
    End Sub

    Public Sub EXMAIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EXMAIN.Click

        EtsMainMenu.Show()
        Me.Close()
        Me.Dispose()
    End Sub


    Public Sub EXWIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EXWIN.Click
        Me.Close()
        End
    End Sub


    Private Sub frm_mnugl_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Text = "ETS General Ledger Menu - " & agency_name
    End Sub

    Public Sub frmnameaddr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frmnameaddr.Click
        function_type = ""
        package_Type = "GL"
        frmnamechk.Show()
    End Sub

    Public Sub glasset_menu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles glasset_menu.Click
        Dim glasset_mnu As New BlankMenuForm
        glasset_mnu.Show()
    End Sub

    Public Sub glgenled_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles glgenled.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "glgenled.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub GLHEAD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles GLHEAD.Click
        frmglhead1.Show()
    End Sub

    Public Sub GLHIST_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles GLHIST.Click
        'move tables to archived tables first
        'then do updates to current files

        Dim frmpwd_inp As New frmpwd_inp
        'be sure all files archived
        'move all cur_  to last_  and move cur_ytd to prior_m_ytd
        'select all accts with dept = 00 and put cur_ytd into cur_beg
        'select all acct#'s  and zero the cur_m1 to m12 and cur_ytd fields and zero the bud_ fields
        frmpwd_inp.ShowDialog()

        If singl <> "MITCH" And singl <> ("FRTKNX" & Month(Now)) Then
            singl = "N"
            MsgBox("Invalid Password")
            Exit Sub
        Else
            Response = MsgBox("This moves current to prior and zero's current and budget data!  Choose No to exit or Yes to continue.", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
            If Response = 7 Then
                Exit Sub
            End If
            sqlstmnt = "update chacct set last_m1 = cur_m1, cur_m1 = 0,bud_m1 = 0, last_m2 = cur_m2, cur_m2 = 0,bud_m2 = 0, last_m3 = cur_m3, cur_m3 = 0,bud_m3 = 0, last_m4 = cur_m4, cur_m1 = 4,bud_m1 = 4, last_m5 = cur_m5, cur_m5= 0,bud_m5 = 0, last_m6 = cur_m6, cur_m6 = 0,bud_m6 = 0, last_m7 = cur_m7, cur_m7 = 0,bud_m7 = 0, last_m8 = cur_m8, cur_m8 = 0,bud_m8 = 0, last_m9 = cur_m9, cur_m9 = 0,bud_m9 = 0, last_m10 = cur_m10, cur_m10 = 0,bud_m10 = 0, last_m11 = cur_m11, cur_m11 = 0,bud_m11 = 0, last_m12 = cur_m12, cur_m12 = 0,bud_m12 = 0, "
            ETSSQL.ExecuteSQL(sqlstmnt)
            sqlstmnt = "update chacct set cur_beg = cur_ytd where acct_dpt = '00' "
            ETSSQL.ExecuteSQL(sqlstmnt)

        End If
    End Sub

    Public Sub GLIE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles glie.Click
        frmglie.ShowDialog()
    End Sub

    Private Sub gliecons1_Click()
        On Error Resume Next
        prtDestination = 0
        prtreportfilename = gl_report_path & "gliecons1.rpt"
        CrystalForm.ShowDialog()
        If Err.Number = 20504 Then
            MsgBox("This report has not been created")
            Exit Sub
        End If
        On Error GoTo 0
    End Sub

    Public Sub glieacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles glieacct.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glieacct.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub glieday_Click()
        prtDestination = 0
        prtreportfilename = gl_report_path & "glieday.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub gliedev_Click()
        prtDestination = 0
        prtreportfilename = gl_report_path & "gliedev.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub glieems_Click()
        prtDestination = 0
        prtreportfilename = gl_report_path & "glieems.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub gliesser_Click()
        prtDestination = 0
        prtreportfilename = gl_report_path & "gliesser.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub glieberk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles glieberk.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "glieberk.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub glieberk_con_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles glieberk_con.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "glieberk_con.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub gliecons_1039_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gliecons_1039.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "gliecons_1039.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub GLINIT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles GLINIT.Click
        'select all accounts in dept 00 and create a JE for each account with no dollars
        'this is done so that reports can pull the related record in gl
        ''check to make sure yrgeneld is blank in order to put in a j/e

        If CheckRecordCount("select * from yrgenled") <> 0 Then
            MsgBox("The data in yrgenled table has not been erased.")
            Exit Sub
        Else
            MsgBox("This adds JE# 1 for dept = 00 (glinit).")

        End If

        'create jerow data and then insert it
        Dim JeRowData As New List(Of JeData)
        Dim i As Integer = 0
        'create list of acctnums with dept  = 00
        Dim AcctRow As List(Of AcctNums)
        AcctRow = ETSSQL.GetAcctNum("00")

        'cycle thru list and add rows to je
        For i = 0 To AcctRow.Count - 1
            Dim emptyrow As New JeData
            JeRowData.Add(emptyrow)
            JeRowData.Item(i).JrnlNum = 1
            JeRowData.Item(i).JrnlLineNum = i + 1
            JeRowData.Item(i).EntryType = "SD"
            JeRowData.Item(i).JrnlName = "GJ"
            JeRowData.Item(i).JrnlSrc = "JE"
            JeRowData.Item(i).EntryDate = Today
            JeRowData.Item(i).EncumDate = CDate("7/31/" & Year(Today))
            JeRowData.Item(i).PostDate = Today
            JeRowData.Item(i).AcctNum = AcctRow.Item(i).AcctNum
            JeRowData.Item(i).Amount = 0
            JeRowData.Item(i).JrnlDesc = "GLINIT"
            JeRowData.Item(i).Post = "N"
            JeRowData.Item(i).APost = "Y"
            JeRowData.Item(i).dflag = "N"
            JeRowData.Item(i).OperId = "Setup"
            JeRowData.Item(i).Void = "N"
            JeRowData.Item(i).Agency = AgencyNum.ToString
        Next

        sqlstmnt = "insert into yrgenled values ('"
        Call GLMod.SQLJEDataString(sqlstmnt, JeRowData)

    End Sub

    Public Sub glron2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles glron2.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glron2.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub GLSBAL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles GLSBAL.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glbsheet.rpt"
        CrystalForm.ShowDialog()
        CrystalForm.ShowDialog()
    End Sub


    Public Sub GLSBUD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles GLSBUD.Click
        Label4.Visible = True
        bud_month.Visible = True
        bud_month.Focus()
        'need to sum budget figures before printing report
    End Sub

    Public Sub GLSINC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles glsinc.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "gliedpt.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub glsinc1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles glsinc1.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "gliedpt1.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub GLTGL1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles GLTGL1.Click
        gl_close.Show()
    End Sub

    Public Sub JEDOC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles JEDOC.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\GL Jentry.doc"
        WordForm.ShowDialog()
        Me.BringToFront()

    End Sub

    Public Sub JXSTAT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles JXSTAT.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "jestat.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub LB_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LB_rpt.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "apbank.rpt"
        CrystalForm.ShowDialog()
        CrystalForm.ShowDialog()
    End Sub

    Public Sub mcw_prt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mcw_prt.Click

        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\Monthly Closing Worksheet.doc"
        WordForm.ShowDialog()
        Me.BringToFront()


    End Sub

    Public Sub move_bal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles move_bal.Click
        Dim frmpwd_inp As New frmpwd_inp
        frmpwd_inp.ShowDialog()

        If singl <> "MITCH" And singl <> ("FRTKNX" & Month(Now)) Then
            singl = "N"
            MsgBox("Invalid Password")
            Exit Sub
        Else
            MsgBox("Also be sure that no other users on the system.")
            'check to make sure they selected a lastfy database in datapath
            If top_data_path.Contains("lastfy") = False Then
                MsgBox("Last Fiscal Year must be selected at the start of processing")
                Exit Sub
            End If

            'move lastfy cur ytd to this yrgenled beg_bal  - move between two databases
            '' 'what if acct not there

            sqlstmnt = " UPDATE chacct cur_beg = lastfy.cur_ytd FROM  chacct INNER JOIN (SELECT acct_num, cur_ytd "
            sqlstmnt = sqlstmnt & " FROM berk_lastfy.dbo.chacct AS chacct_1) AS lastfy ON chacct.acct_num = lastfy.acct_num"
            sqlstmnt = sqlstmnt & " WHERE     (chacct.acct_dpt = '00')"
            ETSSQL.ExecuteSQL(sqlstmnt)

        End If
        MsgBox("Balances have been moved.")
        MsgBox("You are about to print a Proof Report.")
        prtDestination = 0
        prtreportfilename = ap_report_path & "glcurbeg.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Public Sub next_fybud_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles next_fybud.Click
        MsgBox("This is for the next FISCAL YEAR.")
        selected_recordsource = "Next"
        frm_budget1.ShowDialog()
    End Sub

    Public Sub one_gl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles one_gl.Click
        one_m_gl.ShowDialog()
    End Sub

    Public Sub one_inq_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles one_inq.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glgenled1.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub onedpt_gl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles onedpt_gl.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glgenled2.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub op_cash_bal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles op_cash_bal.Click
        'ap_cash.ShowDialog()
    End Sub

    Public Sub op_ed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles op_ed.Click
        glbud.ShowDialog()
    End Sub

    Private Sub ppr_rpt_Click()
        prtDestination = 0
        prtreportfilename = gl_report_path & "glprepost.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub PRNALLOC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PRNALLOC.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glalloc.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub PRNJE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PRNJE.Click
        gljeprt.ShowDialog()
    End Sub

    Public Sub PROG_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PROG.Click
        Dim frm_program As New frm_program
        function_type = ""
        package_Type = "GL"
        frm_program.Show()
    End Sub


    Public Sub prtcht_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prtcht.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glchart.rpt"
        'Dim Crystal As New CrystalForm
        CrystalForm.ShowDialog()
        Me.BringToFront()

    End Sub

    Public Sub rev_je_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rev_je.Click
        glrevgl_frm.ShowDialog()
    End Sub

    Public Sub rpt_gen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RPT_GEN.Click
        Dim custrpt_lookup As New custrpt_lookup
        custrpt_lookup.Show()
    End Sub

    Public Sub STDJE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles STDJE.Click
        je_type = "STAND"
        je_stand_select.Show()
    End Sub


    Public Sub TALLOC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TALLOC.Click
        frmglalloc2.ShowDialog()
    End Sub


    Public Sub trb_acct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles trb_acct.Click
        On Error Resume Next
        prtDestination = 0
        prtreportfilename = gl_report_path & "gltrial_acct.rpt"
        CrystalForm.ShowDialog()
        If Err.Number = 20504 Then
            MsgBox("This report has not been created")
            Exit Sub
        End If
        On Error GoTo 0
    End Sub

    Public Sub Trial_bal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Trial_bal.Click
        On Error Resume Next
        prtDestination = 0
        prtreportfilename = gl_report_path & "gltrial.rpt"
        CrystalForm.ShowDialog()
        If Err.Number = 20504 Then
            MsgBox("This report has not been created")
            Exit Sub
        End If
        On Error GoTo 0
    End Sub

    Public Sub up_prior_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles up_prior.Click
        Response = MsgBox("This moves data in cur_ytd to prior_m_ytd.  Choose No to exit or Yes to continue.", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = vbNo Then
            Exit Sub
        End If
        sqlstmnt = "update chacct set prior_m_ytd = cur_ytd"
        ETSSQL.ExecuteSQL(sqlstmnt)
        MsgBox("Update complete.")
    End Sub

    Public Sub VDA_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VDA.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glgenled3.rpt"
        CrystalForm.ShowDialog()
    End Sub


    Public Sub ytd_accto_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ytd_accto.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glgenled3.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub YTD_GL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles YTD_GL.Click
        MsgBox("This prints a detail listing")
        prtDestination = 0
        prtreportfilename = gl_report_path & "glgenled.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub OTHJE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OTHJE.Click
        entry_type = "ADD"
        je_type = "REGULAR"
        glx_stand.ShowDialog()
        je_type = ""
    End Sub

    Private Sub RenameLastFy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameLastFy.Click
        'the new system renames xxxx_lastfy to xxxx_year where year is fiscal year of the data
        MsgBox("This procedure renames the prior fiscal year database to a historical database including the year in its name.")
        'top data path is the connection string
        'the db name is the 4 digit name of the customer
        'we need to see if old db name plus _lastfy exists
        'so we create a new connection string and check if chacct acct exists
        Dim newsplitconnection() As String = top_data_path.Split(CChar(";"))  'gives elements of connection string
        Dim NewConnection As String = newsplitconnection(0) & ";" & newsplitconnection(1) & "_lastfy;" & newsplitconnection(2)
        newsplitconnection(1) = newsplitconnection(1).Substring(9)
        Dim oldname As String = newsplitconnection(1) & "_lastfy"

        sqlstmnt = "Select * from chacct"
        Dim AcctNum As New List(Of AcctNums)
        AcctNum = ETSSQL.AltDB_GetAcctNum(NewConnection, sqlstmnt)
        If AcctNum.Count = 0 Then
            MsgBox("Last FY database not created")
            Exit Sub
        End If

        Dim newname As String = newsplitconnection(1) & InputBox("Enter Fiscal Year as 4 digits for the database being renamed.")
        sqlstmnt = "ALTER DATABASE " & oldname & " MODIFY NAME = " & newname
        ETSSQL.ExecuteSQL(sqlstmnt)

    End Sub

    Private Sub BeforeBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeforeBackup.Click
        'copy yrgenled and chacct
        Call ETSSQL.BeforeBackup("yrgenled")
        Call ETSSQL.BeforeBackup("chacct")


    End Sub

    Private Sub AfterBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AfterBackup.Click
        'copy yrgenled and chacct
        Call ETSSQL.BeforeBackup("yrgenled")
        Call ETSSQL.BeforeBackup("chacct")

    End Sub

    Private Sub RestoreBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreBackup.Click
        Call ETSSQL.RestoreBackup("chacct")

    End Sub


End Class