Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETSCommon.MODULE1
Imports ETSCommon.Database
Imports Microsoft.VisualBasic.ErrObject
Imports System.Data.SqlClient
Imports System
Imports System.Configuration
Imports ETSCommon


Public Class frm_mnuap
    Inherits System.Windows.Forms.Form

    Sub errorhandler(ByVal err_number As Integer)

        If err_number = 424 Then
            MsgBox("Please contact ETS to activate this module.")
        End If

    End Sub

    Sub pwd_checker()
        'entry_type = ""
        'frmpwd_inp.ShowDialog()

        'If entry_type = "CANCEL" Then
        '    singl = "N"
        '    Exit Sub
        'End If
        'Dim intcount As Integer = 0
        'Dim pwd As String = ""
        'Using db As Database = New Database(top_data_path)
        '    Dim sql As String = "select * from pwd where pkg_type = '" & package_Type & "'"
        '    Dim rs As SqlDataReader = db.ExecuteQuery(sql)
        '    While rs.Read()
        '        pass_level = CInt(rs("level").ToString)
        '        pwd = rs("password").ToString
        '        intcount = intcount + 1
        '    End While
        '    rs.Close()
        'End Using

        'If intcount <> 0 And singl = pwd Then

        'Else
        '    MsgBox("Invalid Password")
        '    singl = "N"
        'End If

    End Sub

    '**********************************insert


    Private Sub PRDOC_Click()

    End Sub

    Public Sub addname_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addname.Click
        Dim frmnamechk As New NameAddr.frmnamechk
        frmnamechk.Show()
    End Sub


    Private Sub APVCHVND_Click()
        'apvvd_frm.Show

    End Sub

    Private Sub AERL_Click()
        'frmmodrpt.Show
    End Sub

    Public Sub after_zip_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles after_zip.Click
        ''code in mod1 5/98
        ''ets.dat must have drive letter in it
        'Call after_backup(ap_data_path & "ap.mdb")
        ''code changed 9/20/01 to flag if backup not done in mod
        'If valid_YN = "Y" Then
        '	MsgBox("AP backup is complete.")
        'Else
        '	MsgBox("AP backup is NOT complete.")
        '	Exit Sub
        'End If
    End Sub

    Public Sub alloc_tbl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles alloc_tbl.Click
        'apalloclookup.Show
    End Sub

    Public Sub apalloc_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles apalloc_rpt.Click
        'Dim prtreportfilename As Object
        'Dim prtDestination As Object
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtDestination. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtDestination = 0
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtreportfilename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtreportfilename = ap_report_path & "apalloc.rpt"
        '' Call frmcrystal_Call
    End Sub

    Public Sub apclose_rpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles apclose_rpt.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE from Mark 2/27/98 use for win 95 word7+

        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\apclose.doc")
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

    Public Sub apmck_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles apmck.Click
        ' apmckreg.Show
    End Sub

    Public Sub apmvch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles apmvch.Click
        ' apmvreg.Show
    End Sub

    Public Sub aprdoc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles aprdoc.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE from Mark 2/27/98 use for win 95 word7+

        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\aprecon.doc")
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



    Public Sub BATCHED_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BATCHED.Click
        ' frmvouchent.Show
    End Sub

    Public Sub Before_Zip_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles before_zip.Click
        ''code is in mod1 5/98
        ''ets.dat must have letter of zip drive
        'Call before_backup(ap_data_path & "ap.mdb")
        ''code changed 9/20/01 to flag if backup not done in mod
        'If valid_YN = "Y" Then
        '	MsgBox("AP backup is complete.")
        'Else
        '	MsgBox("AP backup is NOT complete.")
        '	Exit Sub
        'End If

    End Sub

    Public Sub bnklst_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles bnklst.Click
        'Dim prtreportfilename As Object
        'Dim prtDestination As Object
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtDestination. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtDestination = 0
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtreportfilename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtreportfilename = ap_report_path & "apbank.rpt"
        ''Call frmcrystal_Call
    End Sub

    Public Sub CHKDOC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CHKDOC.Click
        ''this is the code to print a txt file
        ''the txt file will contain instructions
        ''ALL OF THE CODE IS HERE 2/28/98 mb

        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\apcheck.doc")
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

    Public Sub CHKPRT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CHKPRT.Click
        ' frmcompchk.Show
    End Sub

    Public Sub CHKVOID_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CHKVOID.Click
        '  apckvoid_frm1.Show 1
    End Sub

    Private Sub ckrst_Click()
        '  frmre_chk.Show
    End Sub

    Public Sub del_vch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles del_vch.Click
        'Response = MsgBox("This is for Deleting Records, Continue?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
        'If Response = MsgBoxResult.No Then
        '	'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '	System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '	Exit Sub
        'End If
        ''   apvchdel_frm.Show 1
    End Sub

    Public Sub e_m_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles e_m.Click
        'frmmanual.Show 1
    End Sub

    Public Sub ed_ck_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ed_ck.Click
        ' applk.Show
    End Sub

    Public Sub EDCHART_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EDCHART.Click
        'dim form name as itself and the show as no modul  if modul use .showdialog()
        entry_type = ""
        Dim acctlookup As New acctlookup
        acctlookup.Show() 'always this for chart      
    End Sub

    Private Sub EDDEPT_Click()

    End Sub

    Private Sub EDHEAD_Click()
        ''frm_headings.Show
        'Me.Close()
    End Sub

    Private Sub EDPMTS_Click()

    End Sub

    Public Sub edsys_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edsys.Click
        entry_type = ""
        Dim frmsys As New frmsys
        frmsys.Show()
    End Sub

    Public Sub EDVOUCH_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EDVOUCH.Click
        ' Load apvch_ed1
        ' apvch_ed1.Show
    End Sub

    Public Sub ent_data_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ent_data.Click
        '  applk.Show
    End Sub

    Public Sub EXMAIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EXMAIN.Click
        'Dim frmetstop As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object frmetstop.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'frmetstop.Show()
        'Me.Close()
    End Sub


    Public Sub EXWIN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EXWIN.Click
        Me.Close()

    End Sub


    Private Sub Genled_Click()
        'frm_mnugl.Show
    End Sub

    Private Sub LOC_Click()

    End Sub

    Private Sub GENRPT_Click()
        'frmrptsel.Show
    End Sub

    Private Sub frm_mnuap_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Text = "ETS Accounts Payable Menu - " ' & agency_name

        'tmpdb = DAODBEngine_definst.OpenDatabase(ap_data_path & "ap.mdb")
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

    Private Sub frm_rpt_gen_Click()

    End Sub

    Public Sub gl_chart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles gl_chart.Click
        'Dim prtreportfilename As Object
        'Dim prtDestination As Object
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtDestination. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtDestination = 0
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtreportfilename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtreportfilename = gl_report_path & "glchart.rpt"
        '' Call frmcrystal_Call
    End Sub

    Public Sub int_prt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles int_prt.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE 2/28/98 mb

        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\apmanck.doc")
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

    Public Sub je_tmp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles je_tmp.Click
        'Dim prtreportfilename As Object
        'Dim prtDestination As Object
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtDestination. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtDestination = 0
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtreportfilename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtreportfilename = ar_report_path & "arjetmp.rpt"
        ''   Call frmcrystal_Call
    End Sub

    Public Sub JESTAT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles JESTAT.Click
        'Dim prtreportfilename As Object
        'Dim prtDestination As Object
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtDestination. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtDestination = 0
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtreportfilename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtreportfilename = ap_report_path & "jestat.rpt"
        ''Call frmcrystal_Call
    End Sub

    Public Sub load_vend_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles load_vend.Click
        ' ap1099.Show
    End Sub

    Public Sub MATB_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MATB.Click
        ' apatb_frm.Show 1
    End Sub

    Public Sub misc_doc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles misc_doc.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE 2/28/98 mb

        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\apmiscpmt.doc")
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

    Public Sub mp_log_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mp_log.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE from Mark 2/27/98 use for win 95 word7+

        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\Monthly Payment Log.doc")
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
        'UPGRADE_WARNING: Couldn't resolve default property of object Word.FilePrintDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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

    Public Sub MRC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MRC.Click
        '    apckrcon_frm1.Show 1
        ' recon_date.SetFocus    'lhw 8/22/02
    End Sub

    Public Sub mv_log_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mv_log.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE from Mark 2/27/98 use for win 95 word7+

        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\monthly voucher log.doc")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.CurValues. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'PrintOptions = Word.CurValues.ToolsOptionsPrint
        ''UPGRADE_WARNING: Couldn't resolve default property of object PrintOptions.Background. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Background = PrintOptions.Background
        ''UPGRADE_NOTE: Object PrintOptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'PrintOptions = Nothing
        'If (Background <> 0) Then
        '      'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      Word.ToolsOptionsPrint(Background:=0)
        'End If
        '      'UPGRADE_WARNING: Couldn't resolve default property of object Word.FilePrintDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      Word.FilePrintDefault()
        '      If (Background <> 0) Then
        '          'UPGRADE_WARNING: Couldn't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '          Word.ToolsOptionsPrint(Background:=Background)
        '      End If
        '      'UPGRADE_WARNING: Couldn't resolve default property of object Word.FileClose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '      Word.FileClose(2)
        '      'UPGRADE_NOTE: Object Word may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        '      Word = Nothing
    End Sub

    Public Sub PAYSUM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PAYSUM.Click
        '   frmappygl.Show 1
        'on this we print the monthly ck register
        'and create J/E to G/L and print same
    End Sub

    Private Sub PRTTRB_Click()
        '  apatb_frm.Show 1

    End Sub

    Private Sub RPTLST_Click()
        '  frmrptsel.Show
    End Sub

    Public Sub po_mnu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles po_mnu.Click
        '   ap_purch_mnu.Show
    End Sub

    Public Sub ponev_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ponev.Click
        '   apsvch_frm.Show
    End Sub

    Public Sub pr_int_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_int.Click

        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE  2/27/98

        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\apvoid.doc")
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

    Public Sub prt_1099_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prt_1099.Click
        '   frm1099.Show
    End Sub

    Public Sub prt_chk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prt_chk.Click
        '   apmcheck.Show 1
    End Sub

    Public Sub prt_edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prt_edit.Click
        'Dim prtreportfilename As Object
        'Dim prtDestination As Object
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtDestination. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtDestination = 0
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtreportfilename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtreportfilename = ap_report_path & "apmsck.rpt"
        ''   Call frmcrystal_Call

    End Sub

    Public Sub Prv_rec_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Prv_rec.Click
        '   rec_select_process.Show
    End Sub

    Public Sub PSTAT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PSTAT.Click
        'Dim prtreportfilename As Object
        'Dim prtDestination As Object
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtDestination. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtDestination = 0
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtreportfilename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtreportfilename = ap_report_path & "pmtstat.rpt"
        ''  Call frmcrystal_Call
    End Sub

    Public Sub PVCR_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PVCR.Click
        'Dim prtreportfilename As Object
        'Dim prtDestination As Object
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtDestination. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtDestination = 0
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtreportfilename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtreportfilename = ap_report_path & "allvdck.rpt"
        ''Call frmcrystal_Call
    End Sub

    Public Sub PVVR_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PVVR.Click
        'Dim prtreportfilename As Object
        'Dim prtDestination As Object
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtDestination. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtDestination = 0
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtreportfilename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtreportfilename = ap_report_path & "allvvch.rpt"
        ''Call frmcrystal_Call
    End Sub

    Public Sub rec_vouch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rec_vouch.Click
        '   rec_select.Show 1
    End Sub

    Public Sub revedit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles revedit.Click
        'Dim prtreportfilename As Object
        'Dim prtDestination As Object
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtDestination. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtDestination = 0
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtreportfilename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtreportfilename = ap_report_path & "apvedit.rpt"
        '' Call frmcrystal_Call
    End Sub

    Public Sub rpt_gen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RPT_GEN.Click
        'Dim custrpt_lookup As Object
        ''UPGRADE_WARNING: Couldn't resolve default property of object custrpt_lookup.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'custrpt_lookup.Show()
    End Sub

    Public Sub rptopn_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rptopn.Click
        'Dim prtreportfilename As Object
        'Dim prtDestination As Object
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtDestination. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtDestination = 0
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtreportfilename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtreportfilename = ap_report_path & "apvopn.rpt"
        ''Call frmcrystal_Call

    End Sub

    Private Sub sel_vch_Click()
        'Dim frmcksel As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object frmcksel.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'frmcksel.Show()
    End Sub

    Public Sub st_cks_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles st_cks.Click
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
        'Dim prtreportfilename As Object
        'Dim prtDestination As Object
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtDestination. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtDestination = 0
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtreportfilename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtreportfilename = ap_report_path & "apv1099.rpt"
        ''Call frmcrystal_Call
    End Sub

    Public Sub trav_reim_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles trav_reim.Click
        'entry_type = "ADD"
        '  frmmisp.Show 1
    End Sub

    Public Sub upcheck_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles upcheck.Click
        '  apupchk.Show   'apupchk.frm

    End Sub




    Public Sub VCHDOC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VCHDOC.Click
        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE from Mark 2/27/98 use for win 95 word7+

        '		Dim Word As Object
        '		Dim PrintOptions As Object
        '		Dim Background As Integer

        '        Word = CreateObject("Word.Basic")
        'UPGRADE_WARNING: Couldn() 't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        Word.FileOpen("C:\etsacct\documents\apvouch.doc")
        'UPGRADE_WARNING: Couldn() 't resolve default property of object Word.CurValues. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        PrintOptions = Word.CurValues.ToolsOptionsPrint
        'UPGRADE_WARNING: Couldn() 't resolve default property of object PrintOptions.Background. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        Background = PrintOptions.Background
        '		UPGRADE_NOTE: Object PrintOptions may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        '        PrintOptions = Nothing
        '        If (Background <> 0) Then
        'UPGRADE_WARNING: Couldn() 't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            Word.ToolsOptionsPrint(Background:=0)
        '        End If
        'UPGRADE_WARNING: Couldn() 't resolve default property of object Word.FilePrintDefault. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        Word.FilePrintDefault()
        '        If (Background <> 0) Then
        'UPGRADE_WARNING: Couldn() 't resolve default property of object Word.ToolsOptionsPrint. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        Word.ToolsOptionsPrint(Background:=Background)
        '        End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileClose. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileClose(2)
        ''UPGRADE_NOTE: Object Word may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'Word = Nothing

    End Sub

    Public Sub VCHSUM_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VCHSUM.Click
        'apvchgl_frm.Show(1)
        Dim apvchgl_frm As New apvchgl_frm
        apvchgl_frm.Show()
    End Sub

    Private Sub VNDLST_Click()
        '.Show   'this is the NAME(P)
    End Sub


    Private Sub VSUM_Click()
        '  apvdr_frm.Show
    End Sub


    Public Sub VCHVOID_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VCHVOID.Click
        '  apvchvoid_frm1.Show 1
    End Sub

    Public Sub VDATE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vdate.Click
        '   apvdr_frm.Show 1
    End Sub


    Public Sub vdater_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vdater.Click
        ' apvvd_frm.Show 1
    End Sub


    Public Sub VLIST_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VLIST.Click
        'Dim prtreportfilename As Object
        'Dim prtDestination As Object
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtDestination. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtDestination = 0
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtreportfilename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtreportfilename = ap_report_path & "apvendor.rpt"
        ''Call frmcrystal_Call
    End Sub


    Public Sub VSTAT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VSTAT.Click
        'Dim prtreportfilename As Object
        'Dim prtDestination As Object
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtDestination. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtDestination = 0
        ''UPGRADE_WARNING: Couldn't resolve default property of object prtreportfilename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'prtreportfilename = ap_report_path & "apstat.rpt"
        ''   Call frmcrystal_Call
    End Sub


    Public Sub vv_doc_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles vv_doc.Click

        'this is the code to print a txt file
        'the txt file will contain instructions
        'ALL OF THE CODE IS HERE from Mark 2/27/98 use for win 95 word7+

        'Dim Word As Object
        'Dim PrintOptions As Object
        'Dim Background As Integer

        'Word = CreateObject("Word.Basic")
        ''UPGRADE_WARNING: Couldn't resolve default property of object Word.FileOpen. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Word.FileOpen("C:\etsacct\documents\apvoid.doc")
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

    Private Sub PRTRPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRTRPT.Click

    End Sub

    Private Sub APCASHT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles APCASHT.Click
        Dim ap_cash As New ap_cash
        ap_cash.Show()
    End Sub
End Class