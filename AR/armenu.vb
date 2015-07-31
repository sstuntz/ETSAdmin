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

Public Class armenu
    Inherits System.Windows.Forms.Form
    Public reportpath As String = ConfigurationManager.AppSettings("ReportPath")


    Private Sub EDBNK_Click()
        function_type = ""
        frmnamechk.Show()

    End Sub

    Private Sub EDTYPE_Click()
        frmtype.Show()
    End Sub

    Public Sub add_rec_inv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles add_rec_inv.Click
        'not needed by JRI
        'frmrbatch.ShowDialog()
        function_type = ""
    End Sub

    Public Sub advr_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles advr_rpt.Click
        MsgBox(" This will print a report of ALL ADVANCE PAYMENTS")
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arcbatchv.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Public Sub ar_chart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ar_chart.Click
        acctlookup.Show()
    End Sub

    Private Sub arincust_rpt_Click()
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arincust.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub cc_opn_Click()
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "ar1cc.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub create_rec_inv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles create_rec_inv.Click
        'not needed for JRI
        'recur_invlookup.Show()
    End Sub

    Public Sub cust_srpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arcust1.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Public Sub del_inv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'not needed by JRI
        Response = MsgBox("This is for Deleting Records, Continue?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = MsgBoxResult.No Then
            Exit Sub
        End If
        'arinvdel_frm.Show()
    End Sub

    Public Sub ed_cash_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ed_cash.Click
        'not needed for JRI
        'frmarcash.Show()
    End Sub

    Public Sub ent_inv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ent_inv.Click
        invoicelookup.ShowDialog()
    End Sub

    Public Sub EXMAIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EXMAIN.Click
        EtsMainMenu.Show()
        Me.Close()
        Me.Dispose()
    End Sub

    Public Sub EXWIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EXWIN.Click
        Me.Close()
        Me.Dispose()
        End
    End Sub

    Private Sub armenu_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Text = "ETS Accounts Receivable Menu - " & agency_name
        ar_report_path = ReportPath

        Dim refs As New List(Of RefData)
        refs = ETSSQL.GetRefData("AR", "ARMENU")

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

    Public Sub frm_aratbm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'not needed byJRI
        '  frmaratb1m.ShowDialog()
    End Sub

    Public Sub frm_atbrpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'not needed byJRI
        ' frmaratb1.ShowDialog()

    End Sub

    Public Sub frm_cashsum_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_cashsum.Click
        'not needed byJRI
        'arcashgl_frm.Show()
    End Sub

    Public Sub frm_entcash1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_entcash1.Click

        ar_bat_lookup.Show()

    End Sub

    Public Sub frm_opnrpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "aropen.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub frm_rptgen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frm_rptgen.Click
        Dim custrpt_lookup As New custrpt_lookup
        custrpt_lookup.Show()
    End Sub

    Public Sub frmnameaddr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles frmnameaddr.Click
        package_Type = "AR"
        function_type = ""
        frmnamechk.Show()
    End Sub

    Private Sub invrd_rpt_Click()
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arindist.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub inv_prt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles inv_prt.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "armprint.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub je_stat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles je_stat.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = gl_report_path & "jestat.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub jetmp_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jetmp_rpt.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arjetmp.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub minv_log_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles minv_log.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\Monthly Invoice Log.doc"
        WordForm.ShowDialog()
        Me.BringToFront()

    End Sub

    Public Sub minv_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles minv_rpt.Click
        frmxaropn.ShowDialog()
    End Sub

    Private Sub misc_inv_Click()
        'not needed byJRI
        '       Dim arinvglm_frm As New arinvglm_frm
        '         arinvglm_frm.Show()
    End Sub

    Public Sub one_pay_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "ar1cust.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub pap_inv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pap_inv.Click
        Response = MsgBox("This will update the invoice file.  Do you want to continue?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = 7 Then Exit Sub
        'get a list of all invoices that have ADV in trans in cash

        Dim ADVList As List(Of CashReceiptData) = ETSSQL.GetCashReceiptData("select * from cash where trans_code = 'ADV' ")
        For Each ADV In advlist
            Dim TOTAL = ETSSQL.GetOneSQLValue("select sum(bal_due) as thevalue from invoice where invoice = '" & ADV.Invoice & "'")
            Dim TotInv As Decimal
            If Not String.IsNullOrEmpty(TOTAL) Then
                TotInv = CDec(ETSSQL.GetOneSQLValue("select sum(bal_due) as thevalue from invoice where invoice = '" & ADV.Invoice & "'"))
            Else
                TotInv = 0
                GoTo nextADV
            End If

            If TotInv = ADV.CheckAmt Then
                sqlstmnt = "update invoice set paid_Date = '" & ADV.EncumDate & "' , chk_num = '" & ADV.ChkNum _
                                  & "' , bank_key = '" & ADV.BankKey & "' ,pay_amt = bal_due, bal_due = 0, paid = 'Y' where invoice = '" _
                                  & ADV.Invoice & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
            Else
                'pay bal due until & run out
                Dim ADVINVList As List(Of CompanyInvoiceData) = ETSSQL.GetCompanyInvoiceData("select * from invoice where invoice = '" & ADV.Invoice & "' order by line_num ")
                For Each ADVInv In ADVINVList
                    TotInv = TotInv - ADVInv.InvAmt
                    If TotInv > 0 Then
                        sqlstmnt = "update invoice set paid_Date = '" & ADV.EncumDate & "' , chk_num = '" & ADV.ChkNum _
                        & "' , bank_key = '" & ADV.BankKey & "' ,pay_amt = bal_due, bal_due = 0, paid = 'Y' where invoice = '" _
                        & ADV.Invoice & "'"
                        ETSSQL.ExecuteSQL(sqlstmnt)
                    Else
                        sqlstmnt = "update invoice set paid_Date = '" & ADV.EncumDate & "' , chk_num = '" & ADV.ChkNum _
                       & "' , bank_key = '" & ADV.BankKey & "' ,pay_amt = '" & TotInv & "', bal_due = '" & ADVInv.BalDue - TotInv & "' where invoice = '" _
                       & ADV.Invoice & "'"
                        ETSSQL.ExecuteSQL(sqlstmnt)
                    End If

                Next
            End If
            sqlstmnt = "update cash set trans_code = 'ADVP' , inv_num = " & ADV.InvNum & " where invoice = '" & ADV.Invoice & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)
nextADV:
        Next

        MsgBox("You are about to print a report of Unapplied Advance Payments")

        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arcbatchv1.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub par_close_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles par_close.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\arclose.doc"
        WordForm.ShowDialog()
        Me.BringToFront()

    End Sub

    Public Sub pcp_prt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pcp_prt.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\Cash Posting Sheet.doc"
        WordForm.ShowDialog()
        Me.BringToFront()
    End Sub

    Public Sub pcr_void_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pcr_void.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\arvoid.doc"
        WordForm.ShowDialog()
        Me.BringToFront()

    End Sub

    Public Sub pinv_void_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pinv_void.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\arvoid.doc"
        WordForm.ShowDialog()
        Me.BringToFront()

    End Sub

    Public Sub PMINVED_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PMINVED.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arinved.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub prt_chart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        prtDestination = CInt(CStr(0))
        prtreportfilename = ap_report_path & "glchart.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub prt_log_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prt_log.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\Monthly Cash Log.doc"
        WordForm.ShowDialog()
        Me.BringToFront()

    End Sub

    Private Sub re_bal_due_Click()
        MsgBox("Be patient. This may take awhile")
        Call check_for_Complete_invoice(0, Now)
        MsgBox("Process Complete")
    End Sub

    Public Sub rec_bal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'not needed byJRI
        ' Dim ar_cal_bal As New ar_cal_bal
        Response = MsgBox("This will update payment dates, Continue?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = MsgBoxResult.No Then
            Exit Sub
        End If
        ' ar_cal_bal.Show()
    End Sub

    Public Sub reg_int_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\A R cash.doc"
        WordForm.ShowDialog()
        Me.BringToFront()

    End Sub

    Public Sub rev_cash_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rev_cash.Click
        'not needed for JRI
        '    ar_cash_rev1.Show()
    End Sub

    Public Sub rpt_bank_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        prtDestination = CInt(CStr(0))
        prtreportfilename = ap_report_path & "arbank.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub rpt_csort_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arcusta.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub rpt_invdoc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpt_invdoc.Click
        'not needed for JRI
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\arinv.doc"
        WordForm.ShowDialog()
        Me.BringToFront()

    End Sub

    Public Sub rpt_mcshreg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpt_mcshreg.Click

        arcmopn.ShowDialog()

    End Sub

    Private Sub rpt_minvreg_Click()
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arinvd.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub rpt_num_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arcustn.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub unpd_cons_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "ar1cc.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub UPCKF_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles UPCKF.Click
        'not needed for JRI
        '       arupchk.Show()

    End Sub

    Public Sub vcash_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vcash_rpt.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arckvoided.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub vinv_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vinv_rpt.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arinvvoided.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Public Sub void_cash_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_cash.Click
        'not needed for JRI
        'arcashvd_frm1.Show()
    End Sub

    Public Sub void_inv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_inv.Click
        'not needed for JRI
        '		arinvvd_frm1.Show()
    End Sub

    Private Sub rpt_cashdoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rpt_cashdoc.Click
        Dim word As New WordForm
        ETS.Common.Module1.selected_file = "C:\etsacct\documents\A R Wire or Multiline pmt.doc"
        WordForm.ShowDialog()
        Me.BringToFront()
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

    Private Sub Switch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Switch.Click
        package_Type = "ATT"
        Dim attmenu As New AttMenu
        attmenu.ShowDialog()
        Me.Close()
    End Sub


End Class