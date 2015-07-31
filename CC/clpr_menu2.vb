Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETSCommon.MODULE1
Imports NameAddr

Public Class clpr_menu2
    Inherits System.Windows.Forms.Form
    '****************
    'revision History
    'original date of this form is 9/23/96 -SCS

    Public Sub adp_ascii_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles adp_ascii.Click
        On Error Resume Next
        Dim prep_adp_cc As New Form
        prep_adp_cc.ShowDialog()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    Public Sub adp_code_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles adp_code.Click
        function_type = ""
        On Error Resume Next
        Dim hmtadplookup As New hmtadplookup
        hmtadplookup.ShowDialog()
        If Err.Number = 91 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    Public Sub afbkup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles afbkup.Click

        Call after_backup(cc_data_path & "cc.mdb")
        MsgBox("CC has been backed up.  Now proceeding with GLNAME.")
        Call after_backup(gl_data_path & "glname.mdb")


    End Sub

    Private Sub Affirm_Click()
        On Error Resume Next
        Err.Number = 424
        'Call errorhandler(err)
    End Sub

    Public Sub after_back_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles after_back.Click
        MsgBox("This is copying cc.mdb to after zip disk..No one else can have the file open!")
        'code is in mod1 5/98
        'ets.dat must have letter of zip drive  6/17/98
        Call after_backup(cc_data_path & "cc.mdb")
    End Sub

    Public Sub avhr_list_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles avhr_list.Click
        'prtparameterfields(0) = ""
        'prtparameterfields(1) = ""

        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccavhrl.rpt"
        'Call frmcrystal_Call()

    End Sub

    Public Sub avhr_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles avhr_rpt.Click
        'prtDestination = CStr(0)
        'prtDiscardSavedData = 1
        'msg = "Date (" & Year(rpthead.Fields("beg_date").Value) & "," & Month(rpthead.Fields("beg_date").Value) & "," & VB.Day(rpthead.Fields("beg_date").Value) & ")"
        'prtparameterfields(0) = "Begin_date;" & msg & ";FALSE"
        'msg = "Date (" & Year(rpthead.Fields("end_date").Value) & "," & Month(rpthead.Fields("end_date").Value) & "," & VB.Day(rpthead.Fields("end_date").Value) & ")"
        'prtparameterfields(1) = "End_date;" & msg & ";FALSE"
        'prtreportfilename = cc_report_path & "ccavghr.rpt"
        'Call frmcrystal_Call()
        'prtparameterfields(0) = ""
        'prtparameterfields(1) = ""

    End Sub

    Public Sub before_back_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles before_back.Click
        MsgBox("This is copying cc.mdb to before zip disk..No one else can have the file open!")
        'code is in mod1 5/98
        'ets.dat must have letter of zip drive  6/17/98
        Call before_backup(cc_data_path & "cc.mdb")
    End Sub

    Public Sub bfbkup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bfbkup.Click 'done from within the software

        '	rpthead = Nothing
        ' Call before_backup(cc_data_path & "cc.mdb")
        ' MsgBox("CC has been backed up.  Now proceeding with GLNAME.")
        'Call before_backup(gl_data_path & "glname.mdb")
        '		rpthead = tmpdb.OpenRecordset("rpthead")
    End Sub

    Public Sub bfgbkup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bfgbkup.Click 'done from the menu event
        '	rpthead = Nothing
        '   Call before_backup(cc_data_path & "cc.mdb")
        '  MsgBox("CC has been backed up.  Now proceeding with GLNAME.")
        ' Call before_backup(gl_data_path & "glname.mdb")
        '		rpthead = tmpdb.OpenRecordset("rpthead")
    End Sub

    Public Sub ca_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ca_rpt.Click
        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccalpha.rpt"
        'Call frmcrystal_Call()
        'prtparameterfields(0) = ""
        'prtparameterfields(1) = ""

    End Sub

    Public Sub ccdb_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ccdb.Click
        function_type = " "
        On Error Resume Next
        Dim frmnamechk As New NameAddr.frmnamechk
        frmnamechk.Show()

        If Err.Number = 91 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    Public Sub ccjf_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ccjf_rpt.Click
        'prtparameterfields(0) = ""
        'prtparameterfields(1) = ""

        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccjfile.rpt"
        'Call frmcrystal_Call()

    End Sub

    Public Sub ccnet_ck_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ccnet_ck.Click
        'prtparameterfields(0) = ""
        'prtparameterfields(1) = ""

        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccnetck.rpt"
        'Call frmcrystal_Call()
    End Sub

    Public Sub cd_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cd_rpt.Click
        'prtparameterfields(0) = ""
        'prtparameterfields(1) = ""

        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccdept.rpt"
        'Call frmcrystal_Call()

    End Sub

    Public Sub cf_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cf_rpt.Click
        'prtparameterfields(0) = ""
        'prtparameterfields(1) = ""

        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccfund.rpt"
        'Call frmcrystal_Call()
    End Sub

    Public Sub cj_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cj_rpt.Click
        'prtparameterfields(0) = ""
        'prtparameterfields(1) = ""

        'prtDiscardSavedData = 1
        'msg = "Date (" & Year(rpthead.Fields("beg_date").Value) & "," & Month(rpthead.Fields("beg_date").Value) & "," & VB.Day(rpthead.Fields("beg_date").Value) & ")"
        'prtparameterfields(0) = "Beg_workdate;" & msg & ";FALSE"
        'msg = "Date (" & Year(rpthead.Fields("end_date").Value) & "," & Month(rpthead.Fields("end_date").Value) & "," & VB.Day(rpthead.Fields("end_date").Value) & ")"
        'prtparameterfields(1) = "End_workdate;" & msg & ";FALSE"

        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccbyjob.rpt"
        'Call frmcrystal_Call()
    End Sub

    Public Sub clijob_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles clijob.Click
        function_type = ""
        On Error Resume Next
         clijoblookup.ShowDialog()
        If Err.Number = 91 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

    Public Sub cnsrfrm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cnsrfrm.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE

        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\ccinput.doc")
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

    Public Sub CPAYJE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CPAYJE.Click
        On Error Resume Next
        Dim prep_je_cc As New prep_je_cc
        prep_je_cc.ShowDialog()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    Public Sub crecon_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles crecon.Click
        On Error Resume Next
        Dim ccckrecon_frm As New Form
        ccckrecon_frm.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    Public Sub cust_file_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cust_file.Click
        '    package_Type = "AR"
        '    function_type = ""
        '    frmnamechk.Show
    End Sub

    Public Sub dedlis_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dedlis.Click
        'prtparameterfields(0) = ""
        'prtparameterfields(1) = ""

        ''1 eeded
        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccded.rpt"
        'Call frmcrystal_Call()
    End Sub

    Public Sub deduct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles deduct.Click
        function_type = ""
        Dim deductslookup As New deductslookup
        deductslookup.ShowDialog()
        If Err.Number = 91 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    Private Sub depart_Click()
        function_type = ""
        On Error Resume Next
        Dim frm_dept As New Form
        frm_dept.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    Private Sub deposit_Click()
        On Error Resume Next
        Dim frmccdepsit As New Form
        frmccdepsit.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    Public Sub dep1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dep1.Click
        'prtparameterfields(0) = ""
        'prtparameterfields(1) = ""

        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccdirdep.rpt"
        'Call frmcrystal_Call()
    End Sub

    Private Sub ed_sal_tim_Click()
        entry_type = "RECURRING"
        On Error Resume Next
        Dim ccpr_Ed As New Form
        ccpr_Ed.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

    Public Sub Disab_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Disab.Click
        function_type = ""
       
        'On Error Resume Next
        Dim disablookup As New disablookup
        disablookup.ShowDialog()
        If Err.Number = 91 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

    Public Sub dup_Dep_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dup_Dep.Click
        On Error Resume Next
        Dim cc_dup_Dep As New cc_dup_Dep
        cc_dup_Dep.ShowDialog()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

    Public Sub edck_alpha_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edck_alpha.Click
        'prtparameterfields(0) = ""
        'prtparameterfields(1) = ""

        'prtDiscardSavedData = 1
        'msg = "Date (" & Year(rpthead.Fields("beg_date").Value) & "," & Month(rpthead.Fields("beg_date").Value) & "," & VB.Day(rpthead.Fields("beg_date").Value) & ")"
        'prtparameterfields(0) = "Begin work date;" & msg & ";FALSE"
        'msg = "Date (" & Year(rpthead.Fields("end_date").Value) & "," & Month(rpthead.Fields("end_date").Value) & "," & VB.Day(rpthead.Fields("end_date").Value) & ")"
        'prtparameterfields(1) = "End work date;" & msg & ";FALSE"

        ''print work1 edit 0 = screen  1 = printer
        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "cctimea.rpt"
        'Call frmcrystal_Call()
    End Sub

    Public Sub edck_dept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edck_dept.Click
        'prtparameterfields(0) = ""
        'prtparameterfields(1) = ""

        'prtDiscardSavedData = 1
        'msg = "Date (" & Year(rpthead.Fields("beg_date").Value) & "," & Month(rpthead.Fields("beg_date").Value) & "," & VB.Day(rpthead.Fields("beg_date").Value) & ")"
        'prtparameterfields(0) = "Begin work date;" & msg & ";FALSE"
        'msg = "Date (" & Year(rpthead.Fields("end_date").Value) & "," & Month(rpthead.Fields("end_date").Value) & "," & VB.Day(rpthead.Fields("end_date").Value) & ")"
        'prtparameterfields(1) = "End work date;" & msg & ";FALSE"

        ''print work1 edit 0 = screen  1 = printer
        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "cctimed.rpt"
        'Call frmcrystal_Call()
    End Sub

    Public Sub ee_edit_mnu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ee_edit_mnu.Click
        entry_type = " "
        On Error Resume Next
        Dim ccpr_ed As New ccpr_ed
        ccpr_ed.Showdialog()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

    Private Sub eedb_Click()
        function_type = " "
        On Error Resume Next
        Dim frmnamechk As New Form
        frmnamechk.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    'Public Sub cchire_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cchire.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "cchire.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Public Sub ccjobl_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ccjobl_rpt.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccjlist.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Private Sub eelist_rpt_Click()
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "eelist.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Private Sub eemnth_Click()
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "eemnths.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Private Sub eems_wage_Click()
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "eemswage.rpt"
    '	Call frmcrystal_Call()

    'End Sub

    'Private Sub eenamadd_rpt_Click()
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "eenamadd.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Private Sub eenet_ck_Click()
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "eenetck.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Private Sub eeone_ee_Click()
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "eeoneee.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Private Sub eeratede_rpt_Click()
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "eeratede.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    Private Sub eeslot_Click()
        On Error Resume Next
        Dim frmeeslot As New Form
        frmeeslot.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

    Public Sub eetime_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles eetime.Click
        entry_type = " "
        On Error Resume Next
        Dim cc_start As New cc_start
        cc_start.Showdialog()
        If Err.Number = 91 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If


    End Sub

    'Private Sub eew2rcon_rpt_Click()
    '	'prtDestination = 0
    '	' prtReportFileName = cc_report_path & "eew2rcon.rpt"
    '	' call frmcrystal_call
    'End Sub

    Private Sub ent_sal_tim_Click()
        entry_type = "RECURRING"
        On Error Resume Next
        Dim cc_ent_Time As New cc_ent_time
        cc_ent_Time.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

    Public Sub EXMAIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles exmain.Click

        Me.Close()
    End Sub

    Public Sub export_ssa_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles export_ssa.Click
        On Error Resume Next
        Dim clpr_ssa_rpt As New Form
        clpr_ssa_rpt.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

    Public Sub EXWIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles exwin.Click
        Me.Close()
        End
    End Sub

    'Public Sub final_alpha_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles final_alpha.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDiscardSavedData = 1
    '	msg = "Date (" & Year(rpthead.Fields("beg_date").Value) & "," & Month(rpthead.Fields("beg_date").Value) & "," & VB.Day(rpthead.Fields("beg_date").Value) & ")"
    '	prtparameterfields(0) = "Begin work date;" & msg & ";FALSE"
    '	msg = "Date (" & Year(rpthead.Fields("end_date").Value) & "," & Month(rpthead.Fields("end_date").Value) & "," & VB.Day(rpthead.Fields("end_date").Value) & ")"
    '	prtparameterfields(1) = "End work date;" & msg & ";FALSE"

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccfedita.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Public Sub final_dept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles final_dept.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDiscardSavedData = 1
    '	msg = "Date (" & Year(rpthead.Fields("beg_date").Value) & "," & Month(rpthead.Fields("beg_date").Value) & "," & VB.Day(rpthead.Fields("beg_date").Value) & ")"
    '	prtparameterfields(0) = "Begin work date;" & msg & ";FALSE"
    '	msg = "Date (" & Year(rpthead.Fields("end_date").Value) & "," & Month(rpthead.Fields("end_date").Value) & "," & VB.Day(rpthead.Fields("end_date").Value) & ")"
    '	prtparameterfields(1) = "End work date;" & msg & ";FALSE"

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccfeditd.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    Private Sub clpr_menu_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Text = "ETS Consumer Payroll Opening Menu - " & agency_name
        db = cc_data_path & "cc.mdb"
        '	tmpdb = DAODBEngine_definst.OpenDatabase(db)
        '	rpthead = tmpdb.OpenRecordset("rpthead")
        '	rpthead.MoveFirst()

    End Sub

    'Public Sub gldept_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gldept_rpt.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "gldept.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Public Sub inactcc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles inactcc.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccterm.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Public Sub j2_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles j2_rpt.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccmojob.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    Public Sub jb_type_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jb_type.Click
        function_type = ""
        On Error Resume Next
        Dim hmtypelookup As New hmtypelookup
        hmtypelookup.ShowDialog()
        If Err.Number = 91 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    'Public Sub jobclass_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jobclass.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccjclass.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    Public Sub JTITLE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles JTITLE.Click
        function_type = ""
        On Error Resume Next
        Dim jobnumlookup As New jobnumlookup
        jobnumlookup.ShowDialog()
        If Err.Number = 91 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    Private Sub locup_Click()
        On Error Resume Next
        Dim locnumlookup As New Form
        locnumlookup.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

    Private Sub namad_Click()
        function_type = ""
        On Error Resume Next
        Dim frmnamechk As New Form
        frmnamechk.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    Private Sub namtype_Click()
        On Error Resume Next
        Dim frmtype As New Form
        frmtype.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    Private Sub m_tmp_Click()

        'write update to cctime for clinets in cctime with nam_cc.desc2 < 100 and paid = N
        'update paid with "Y"
        'update encum_date with date()
        'chk_num = 0
        'need form and put data control for cctime and namcc on it
        On Error Resume Next
        Dim fix_paid As New Form
        fix_paid.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If


    End Sub

    Public Sub MCHK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MCHK.Click
        'this is to put a "Y" in the checked field after report
        'run and is error free.....
        sqlstmnt = "select * from cctime where checked = 'N' "

        db = cc_data_path & "cc.mdb"
        '      '	tmpdb = DAODBEngine_definst.OpenDatabase(db)
        '      '	tmpset = tmpdb.OpenRecordset("cctime")
        '      '	tmpset = tmpdb.OpenRecordset(sqlstmnt)
        '      '	tmpset.MoveFirst()
        '      '	Do While Not tmpset.EOF
        '      tmpset.edit()
        '      tmpset.Fields("checked").Value = "Y"
        '      tmpset.Update()
        '      tmpset.MoveNext()
        'Loop 

        MsgBox("Time Cards have been Marked as Checked")
    End Sub

    Private Sub MUI_Click()

    End Sub

    Private Sub mntx_Click()

    End Sub

    'Public Sub numckreg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles numckreg.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDiscardSavedData = 1
    '	msg = "Date (" & Year(rpthead.Fields("check_date").Value) & "," & Month(rpthead.Fields("check_date").Value) & "," & VB.Day(rpthead.Fields("check_date").Value) & ")"
    '	prtparameterfields(0) = "Check_date;" & msg & ";FALSE"

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccckrnum.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    Private Sub paloc_Click()
        function_type = ""
        On Error Resume Next
        Dim eealloc As New Form
        eealloc.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    'Public Sub offconsumer_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles offconsumer.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDiscardSavedData = 1
    '	msg = "Date (" & Year(rpthead.Fields("beg_date").Value) & "," & Month(rpthead.Fields("beg_date").Value) & "," & VB.Day(rpthead.Fields("beg_date").Value) & ")"
    '	prtparameterfields(0) = "Begin_date;" & msg & ";FALSE"
    '	msg = "Date (" & Year(rpthead.Fields("end_date").Value) & "," & Month(rpthead.Fields("end_date").Value) & "," & VB.Day(rpthead.Fields("end_date").Value) & ")"
    '	prtparameterfields(1) = "End_date;" & msg & ";FALSE"

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccoffc-j.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Public Sub over_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles over_rpt.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "cco100.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Public Sub p2_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles p2_rpt.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDiscardSavedData = 1
    '	msg = "Date (" & Year(rpthead.Fields("beg_date").Value) & "," & Month(rpthead.Fields("beg_date").Value) & "," & VB.Day(rpthead.Fields("beg_date").Value) & ")"
    '	prtparameterfields(0) = "Begin_date;" & msg & ";FALSE"
    '	msg = "Date (" & Year(rpthead.Fields("end_date").Value) & "," & Month(rpthead.Fields("end_date").Value) & "," & VB.Day(rpthead.Fields("end_date").Value) & ")"
    '	prtparameterfields(1) = "End_date;" & msg & ";FALSE"

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccjob.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Public Sub p4_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles p4_rpt.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDiscardSavedData = 1
    '	msg = "Date (" & Year(rpthead.Fields("beg_date").Value) & "," & Month(rpthead.Fields("beg_date").Value) & "," & VB.Day(rpthead.Fields("beg_date").Value) & ")"
    '	prtparameterfields(0) = "Begin_date;" & msg & ";FALSE"
    '	msg = "Date (" & Year(rpthead.Fields("end_date").Value) & "," & Month(rpthead.Fields("end_date").Value) & "," & VB.Day(rpthead.Fields("end_date").Value) & ")"
    '	prtparameterfields(1) = "End_date;" & msg & ";FALSE"

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccoff.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Public Sub p5_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles p5_rpt.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDiscardSavedData = 1
    '	msg = "Date (" & Year(rpthead.Fields("beg_date").Value) & "," & Month(rpthead.Fields("beg_date").Value) & "," & VB.Day(rpthead.Fields("beg_date").Value) & ")"
    '	prtparameterfields(0) = "Begin_date;" & msg & ";FALSE"
    '	msg = "Date (" & Year(rpthead.Fields("end_date").Value) & "," & Month(rpthead.Fields("end_date").Value) & "," & VB.Day(rpthead.Fields("end_date").Value) & ")"
    '	prtparameterfields(1) = "End_date;" & msg & ";FALSE"

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccdirind.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    Public Sub Paycl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Paycl.Click
        function_type = ""
        ' On Error Resume Next
        Dim pclasslookup As New pclasslookup
        pclasslookup.ShowDialog()
        If Err.Number = 91 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

    'Public Sub payreg_all_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles payreg_all.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccckreg-0.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Public Sub Payreg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Payreg.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDiscardSavedData = 1
    '	msg = "Date (" & Year(rpthead.Fields("check_date").Value) & "," & Month(rpthead.Fields("check_date").Value) & "," & VB.Day(rpthead.Fields("check_date").Value) & ")"
    '	prtparameterfields(0) = "Check_date;" & msg & ";FALSE"

    '	'print on wide paper 0 = screen 1 = printer
    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccpayreg.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Public Sub pcd_doc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pcd_doc.Click
    '	'this is the code to print a txt file
    '	'the txt file will contain instructions
    '	'ALL OF THE CODE IS HERE

    '	Dim Word As Object
    '	Dim PrintOptions As Object
    '	Dim Background As Integer

    '	Word = CreateObject("Word.Basic")
    '	'UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '	Word.FileOpen("C:\etsacct\documents\ccckoff.doc")
    '	'UPGRADE_WARNING: Couldn't resolve default property of object Word.CurValues. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '	PrintOptions = Word.CurValues.ToolsOptionsPrint
    '	'UPGRADE_WARNING: Couldn't resolve default property of object PrintOptions.Background. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '	Background = PrintOptions.Background
    '	'UPGRADE_NOTE: Object PrintOptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '	PrintOptions = Nothing
    '	If (Background <> 0) Then
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		Word.ToolsOptionsPrint(Background:=0)
    '	End If
    '	'UPGRADE_WARNING: Couldn't resolve default property of object Word.FilePrintDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '	Word.FilePrintDefault()
    '	If (Background <> 0) Then
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		Word.ToolsOptionsPrint(Background:=Background)
    '	End If
    '	'UPGRADE_WARNING: Couldn't resolve default property of object Word.FileClose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '	Word.FileClose(2)
    '	'UPGRADE_NOTE: Object Word may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '	Word = Nothing
    'End Sub

    'Private Sub PCKOFF_Click()
    '	'this is the code to print a txt file
    '	'the txt file will contain instructions
    '	'ALL OF THE CODE IS HERE new from mark 1998

    '	Dim Word As Object
    '	Dim PrintOptions As Object
    '	Dim Background As Integer

    '	Word = CreateObject("Word.Basic")
    '	'UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '	Word.FileOpen("C:\etsacct\documents\eeckoff.doc")
    '	'UPGRADE_WARNING: Couldn't resolve default property of object Word.CurValues. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '	PrintOptions = Word.CurValues.ToolsOptionsPrint
    '	'UPGRADE_WARNING: Couldn't resolve default property of object PrintOptions.Background. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '	Background = PrintOptions.Background
    '	'UPGRADE_NOTE: Object PrintOptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '	PrintOptions = Nothing
    '	If (Background <> 0) Then
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		Word.ToolsOptionsPrint(Background:=0)
    '	End If
    '	'UPGRADE_WARNING: Couldn't resolve default property of object Word.FilePrintDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '	Word.FilePrintDefault()
    '	If (Background <> 0) Then
    '		'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '		Word.ToolsOptionsPrint(Background:=Background)
    '	End If
    '	'UPGRADE_WARNING: Couldn't resolve default property of object Word.FileClose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '	Word.FileClose(2)
    '	'UPGRADE_NOTE: Object Word may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '	Word = Nothing
    'End Sub

    Public Sub PEDIT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PEDIT.Click
        Response = MsgBox(" Have you done the BEFORE Backup ? Answer No and you will be prompted to DO Before Backup. ", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.No Then
            'code is in mod1 5/98
            'ets.dat must have letter of zip drive
            Call before_backup(cc_data_path & "cc.mdb")
            MsgBox("CC has been backed up.  Now proceeding with GLNAME.")
            Call before_backup(gl_data_path & "glname.mdb")

        End If


        On Error Resume Next
        Dim start_process As New start_process
        start_process.ShowDialog()
        If Err.Number <> 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    Private Sub prtchk_Click()
        On Error Resume Next
        Dim start_proc As New Form
        start_proc.ShowDialog()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

        'start_proc.pr_Start_date1.SetFocus()
    End Sub

    'Public Sub PONEC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PONEC.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDiscardSavedData = 1
    '	msg = "Date (" & Year(rpthead.Fields("beg_date").Value) & "," & Month(rpthead.Fields("beg_date").Value) & "," & VB.Day(rpthead.Fields("beg_date").Value) & ")"
    '	prtparameterfields(0) = "Begin work date;" & msg & ";FALSE"
    '	msg = "Date (" & Year(rpthead.Fields("end_date").Value) & "," & Month(rpthead.Fields("end_date").Value) & "," & VB.Day(rpthead.Fields("end_date").Value) & ")"
    '	prtparameterfields(2) = "End work date;" & msg & ";FALSE"


    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "cc1time.rpt"
    '	Call frmcrystal_Call()
    '	prtparameterfields(2) = ""

    'End Sub

    'Private Sub QHTAX_Click()
    '	'prtDestination = 0
    '	' prtReportFileName = cc_report_path & "eehtax.rpt"
    '	' call frmcrystal_call
    'End Sub

    'Public Sub prod_alpha_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prod_alpha.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDiscardSavedData = 1
    '	msg = "Date (" & Year(rpthead.Fields("beg_date").Value) & "," & Month(rpthead.Fields("beg_date").Value) & "," & VB.Day(rpthead.Fields("beg_date").Value) & ")"
    '	prtparameterfields(0) = "Beg_workdate;" & msg & ";FALSE"
    '	msg = "Date (" & Year(rpthead.Fields("end_date").Value) & "," & Month(rpthead.Fields("end_date").Value) & "," & VB.Day(rpthead.Fields("end_date").Value) & ")"
    '	prtparameterfields(1) = "End_workdate;" & msg & ";FALSE"

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccproda.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Public Sub prod_Dept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prod_Dept.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDiscardSavedData = 1
    '	msg = "Date (" & Year(rpthead.Fields("beg_date").Value) & "," & Month(rpthead.Fields("beg_date").Value) & "," & VB.Day(rpthead.Fields("beg_date").Value) & ")"
    '	prtparameterfields(0) = "Beg_workdate;" & msg & ";FALSE"
    '	msg = "Date (" & Year(rpthead.Fields("end_date").Value) & "," & Month(rpthead.Fields("end_date").Value) & "," & VB.Day(rpthead.Fields("end_date").Value) & ")"
    '	prtparameterfields(1) = "End_workdate;" & msg & ";FALSE"

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccprodd.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    Public Sub prt_crpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prt_crpt.Click
        On Error Resume Next
        Dim custrpt_lookup As New custrpt_lookup
        custrpt_lookup.Showdialog()
        If Err.Number = 91 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

    'Public Sub ps_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ps_rpt.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDiscardSavedData = 1
    '	msg = "Date (" & Year(rpthead.Fields("beg_date").Value) & "," & Month(rpthead.Fields("beg_date").Value) & "," & VB.Day(rpthead.Fields("beg_date").Value) & ")"
    '	prtparameterfields(0) = "Beg_workdate;" & msg & ";FALSE"
    '	msg = "Date (" & Year(rpthead.Fields("end_date").Value) & "," & Month(rpthead.Fields("end_date").Value) & "," & VB.Day(rpthead.Fields("end_date").Value) & ")"
    '	prtparameterfields(1) = "End_workdate;" & msg & ";FALSE"

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccprod1.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Public Sub psum_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles psum_rpt.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDiscardSavedData = 1
    '	msg = "Date (" & Year(rpthead.Fields("beg_date").Value) & "," & Month(rpthead.Fields("beg_date").Value) & "," & VB.Day(rpthead.Fields("beg_date").Value) & ")"
    '	prtparameterfields(0) = "Beg_workdate;" & msg & ";FALSE"
    '	msg = "Date (" & Year(rpthead.Fields("end_date").Value) & "," & Month(rpthead.Fields("end_date").Value) & "," & VB.Day(rpthead.Fields("end_date").Value) & ")"
    '	prtparameterfields(1) = "End_workdate;" & msg & ";FALSE"

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccprod.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    Public Sub QYRPT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles QYRPT.Click
        On Error Resume Next
        Dim cc_qtdytd As New Form
        cc_qtdytd.ShowDialog()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    Private Sub Reas1_Click()
        function_type = ""
        On Error Resume Next
        Dim reasonlookup As New Form
        reasonlookup.ShowDialog()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

    Public Sub re_vac_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles re_vac.Click

        MsgBox("This can be run at any time.  It just refreshes data ")
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Call cc_recalc_usedvac()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        MsgBox("The vacation table has been recalculated .")

    End Sub

    'Public Sub Remvac_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Remvac.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccvsh.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    Private Sub SLOT_Click()
        function_type = ""
        On Error Resume Next
        Dim slotlookup As New Form
        slotlookup.Show()

        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

    Public Sub rev_job_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rev_job.Click
        On Error Resume Next
        Dim frmrate As New Form
        frmrate.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    'Public Sub s2_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles s2_rpt.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccssind.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    'Public Sub s3_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles s3_rpt.Click
    '	prtparameterfields(0) = ""
    '	prtparameterfields(1) = ""

    '	prtDestination = CStr(0)
    '	prtreportfilename = cc_report_path & "ccssi.rpt"
    '	Call frmcrystal_Call()
    'End Sub

    Private Sub spec_rpt_Click()
        On Error Resume Next
        Dim eespecial As New Form
        eespecial.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

    Public Sub STPYSYS_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles STPYSYS.Click
        function_type = ""
        On Error Resume Next
        Dim frmccprsys As New frmccprsys
        frmccprsys.ShowDialog()
        If Err.Number = 91 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    Public Sub strup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles strup.Click

        'eework1 is created from the old data and imported using access
        'the next step is to ensure that this data is valid
        'we do this by checking the name key and saying paid = Y if not in name addr
        'write a report on paid in work1 and fix before going on to next step

        ' this creates the eeckstub and eevac tables in sync witht the original eework1
        '		db = ee_data_path & "ee.mdb"
        '		tmpdb = DAODBEngine_definst.Workspaces(0).OpenDatabase(db)
        '		tmpset = tmpdb.OpenRecordset("eework1")
        '		tmp1db = DAODBEngine_definst.OpenDatabase(gl_data_path & "glname.mdb")
        '		tmp1set = tmp1db.OpenRecordset("nam_addr", dao.RecordsetTypeEnum.dbOpenDynaset)
        '		tmpset.MoveFirst()
        '		On Error Resume Next
        '		GoTo vac

        '		Do While Not tmpset.EOF
        '			sqlstmnt = "name_key = " & Chr(34) & tmpset.Fields("name_key").Value & Chr(34)
        '			tmp1set.FindFirst(sqlstmnt)
        '			' tmp1set.FindFirst sqlstmnt
        '			If tmp1set.NoMatch Then
        '				tmpset.edit()
        '				tmpset.Fields("paid").Value = "Y"
        '				tmpset.Update()
        '			End If
        '			tmpset.MoveNext()
        '		Loop 
        '		'it is important to have run a payroll at this time in order to create
        '		'the ckstub file
        '		'the following stop allows this to happen
        '		'the second time thru just continue
        '		Stop
        '		'we now plug the right data into ckstub from eeckx
        '		'eeckx was created with an id field as field0 so the count starts at one
        '		'UPGRADE_WARNING: Arrays in structure tmp2set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '		Dim tmp2set As dao.Recordset
        '		'UPGRADE_WARNING: Arrays in structure eeckstub may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '		Dim eeckstub As dao.Recordset
        '		tmp2set = tmpdb.OpenRecordset("EECKX", dao.RecordsetTypeEnum.dbOpenDynaset)
        '		eeckstub = tmpdb.OpenRecordset("eeckstub")
        '		eeckstub.MoveFirst()

        '		Do While Not eeckstub.EOF
        '			eeckstub.edit()
        '			sqlstmnt = "field5 = " & Chr(34) & eeckstub.Fields("name_key").Value & Chr(34)
        '			tmp2set.FindFirst(sqlstmnt)
        '			If tmp2set.NoMatch Then
        '				MsgBox(" no valid data for = " & eeckstub.Fields("screen_nam").Value)
        '			Else

        '				eeckstub.Fields("full_gross").Value = tmp2set.Fields(5).Value
        '				eeckstub.Fields("fed_gross").Value = tmp2set.Fields(6).Value
        '				eeckstub.Fields("fed_Tax").Value = tmp2set.Fields(7).Value
        '				eeckstub.Fields("fica_gross").Value = tmp2set.Fields(8).Value
        '				eeckstub.Fields("fica_Tax").Value = tmp2set.Fields(9).Value
        '				eeckstub.Fields("med_gross").Value = tmp2set.Fields(10).Value
        '				eeckstub.Fields("med_tax").Value = tmp2set.Fields(11).Value
        '				eeckstub.Fields("state1_gross").Value = tmp2set.Fields(12).Value
        '				eeckstub.Fields("state1_tax").Value = tmp2set.Fields(13).Value
        '				eeckstub.Fields("state2_gross").Value = tmp2set.Fields(14).Value
        '				eeckstub.Fields("state2_tax").Value = tmp2set.Fields(15).Value
        '				eeckstub.Fields("a_nt_dol").Value = tmp2set.Fields(16).Value
        '				eeckstub.Fields("b_nt_dol").Value = tmp2set.Fields(17).Value
        '				eeckstub.Fields("c_nt_dol").Value = tmp2set.Fields(18).Value
        '				eeckstub.Fields("d_nt_Dol").Value = tmp2set.Fields(19).Value
        '				eeckstub.Fields("e_nt_dol").Value = tmp2set.Fields(20).Value
        '				eeckstub.Fields("flx_nt_Dol").Value = tmp2set.Fields(21).Value
        '				eeckstub.Fields("dep_nt_dol").Value = tmp2set.Fields(22).Value

        '				eeckstub.Update()

        '			End If
        '			eeckstub.MoveNext()
        '		Loop 

        '		'we now plug the right data into eevac from eevacx

        'vac: 

        '		'UPGRADE_WARNING: Arrays in structure eevac may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '		Dim eevac As dao.Recordset
        '		tmp2set = tmpdb.OpenRecordset("EEVACX", dao.RecordsetTypeEnum.dbOpenDynaset)
        '		eevac = tmpdb.OpenRecordset("eevac")
        '		eevac.MoveFirst()

        '		Do While Not eevac.EOF
        '			eevac.edit()
        '			sqlstmnt = "field1 = " & Chr(34) & eevac.Fields("name_key").Value & Chr(34)
        '			tmp2set.FindFirst(sqlstmnt)
        '			If tmp2set.NoMatch Then
        '				MsgBox(" no valid data for = " & eevac.Fields("screen_nam").Value)
        '			Else
        '				For num = 2 To tmp2set.Fields.Count - 1
        '					eevac.Fields(num).Value = tmp2set.Fields(num).Value

        '				Next 
        '				eevac.Fields("hrs_week").Value = eevac.Fields("hrs_week").Value / 8
        '				eevac.Update()

        '				'           eevac.Fields("full_gross") = tmp2set(4)
        '				'           eevac.Fields("fed_gross") = tmp2set(5)
        '				'           eevac.Fields("fed_Tax") = tmp2set(6)
        '				'           eevac.Fields("fica_gross") = tmp2set(7)
        '				'           eevac.Fields("fica_Tax") = tmp2set(8)
        '				''           eevac.Fields("med_gross") = tmp2set(9)
        '				'      eevac.Fields("med_tax") = tmp2set(10)
        '				'       eevac.Fields("state1_gross") = tmp2set(11)
        '				'       eevac.Fields("state1_tax") = tmp2set(12)
        '				'       eevac.Fields("state2_gross") = tmp2set(13)
        '				'       eevac.Fields("state2_tax") = tmp2set(14)
        '				'       eevac.Fields("a_nt_dol") = tmp2set(15)
        '				'       eevac.Fields("b_nt_dol") = tmp2set(16)
        '				'       eevac.Fields("c_nt_dol") = tmp2set(17)
        '				'       eevac.Fields("d_nt_Dol") = tmp2set(18)
        '				'       eevac.Fields("e_nt_dol") = tmp2set(19)
        '				'     eevac.Fields("flx_nt_Dol") = tmp2set(20)
        '				'       eevac.Fields("dep_nt_dol") = tmp2set(21)

        '				'     eevac.Update

        '			End If
        '			eevac.MoveNext()
        '		Loop 


    End Sub

    'Private Sub TrainPer_Click()
    '    On Error Resume Next
    '    Err.Number = 424
    '    Call errorhandler(Err)
    'End Sub


    Private Sub upd_sal_Click()
        'checks to see if any have been added before going on

    End Sub

    Private Sub updslot_Click()
        On Error Resume Next
        Dim slot_alloc As New Form
        slot_alloc.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    'Public Sub tds_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tds_rpt.Click
    '    prtparameterfields(0) = ""
    '    prtparameterfields(1) = ""

    '    prtDestination = CStr(0)
    '    prtreportfilename = cc_report_path & "cctxded.rpt"
    '    Call frmcrystal_Call()
    'End Sub

    Public Sub updjob_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles updjob.Click
        On Error Resume Next
        Dim job_alloc As New job_alloc
        job_alloc.ShowDialog()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    Public Sub updrecon_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles updrecon.Click
        On Error Resume Next
        Dim update_recon As New update_recon
        update_recon.ShowDialog()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

    Public Sub VCHECK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VCHECK.Click

        Response = MsgBox("Have you backed up the cc database?", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.No Then
            Exit Sub
        End If
        'this will be replaced with  a forced backup to the before disk

        On Error Resume Next
        Dim ccchkvoid As New Form
        ccchkvoid.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub


    Public Sub void_chk_gl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_chk_gl.Click
        function_type = "EDIT_ADM"
        On Error Resume Next
        Dim ccchkvoid As New Form
        ccchkvoid.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If

    End Sub

    'Public Sub vouchregis_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vouchregis.Click
    '    prtparameterfields(0) = ""
    '    prtparameterfields(1) = ""

    '    prtDiscardSavedData = 1
    '    msg = "Date (" & Year(rpthead.Fields("check_date").Value) & "," & Month(rpthead.Fields("check_date").Value) & "," & VB.Day(rpthead.Fields("check_date").Value) & ")"
    '    prtparameterfields(0) = "ck_date;" & msg & ";FALSE"

    '    prtDestination = CStr(0)
    '    prtreportfilename = cc_report_path & "ccvchreg.rpt"
    '    Call frmcrystal_Call()
    '    prtparameterfields(1) = ""
    '    prtparameterfields(1) = ""
    'End Sub

    'Public Sub wd_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles wd_rpt.Click
    '    prtparameterfields(0) = ""
    '    prtparameterfields(1) = ""

    '    prtDestination = CStr(0)
    '    prtreportfilename = cc_report_path & "ccwage.rpt"
    '    Call frmcrystal_Call()
    'End Sub

    Public Sub year_end_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles year_end.Click
        On Error Resume Next
        Dim frmccyear As New Form
        frmccyear.Show()
        If Err.Number = 0 Then
            MsgBox("This feature is not available.  Call ETS.")
        End If
    End Sub

End Class