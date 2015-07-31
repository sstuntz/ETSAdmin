Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ErrObject
Imports System.Data.SqlClient
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports ps.common


Public Class EtsMainMenu
    Inherits System.Windows.Forms.Form

    Sub errorhandler(ByVal err_number As Integer)

        If err_number = 424 Then
            MsgBox("Please contact ETS to activate this module.")
        End If

    End Sub

    Sub pwd_checker()
        entry_type = ""
        If CheckPwd = "N" Then         'added to turn off passwords and levels
            singl = "Y"                'could fix pass_level = 1 if this is "N"    06/13/2012
            Exit Sub
        End If

        frmpwd_inp.ShowDialog()

        If entry_type = "CANCEL" Then
            singl = "N"
            Exit Sub
        End If
        Dim intcount As Integer = 0
        Dim pwd As String = ""
        Using db As Database = New Database(top_data_path)
            Dim sql As String = "select * from pwd where pkg_type = '" & package_Type & "'"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            While rs.Read()
                pass_level = CInt(rs("level").ToString)
                pwd = rs("password").ToString
                intcount = intcount + 1
            End While
            rs.Close()
        End Using

        If intcount <> 0 And singl = pwd Then

        Else
            MsgBox("Invalid Password")
            singl = "N"
        End If

    End Sub

    Public Sub cc_trk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cc_trk.Click

        package_Type = "CT"
        Call pwd_checker()

        If singl <> "N" Then
            Dim ct_menu As New BlankMenuForm
            On Error Resume Next
            ct_menu.Show()
        End If

        Call errorhandler(Err.Number)
        Me.Close()
    End Sub

    Public Sub attmed_mnu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles attmed_mnu.Click
        Dim att_med_menu As New BlankMenuForm

        On Error Resume Next
        package_Type = "AM"
        'need following code since level is set in call
        pass_level = 1
        att_med_menu.Show()

        Me.Close()
        Call errorhandler(Err.Number)
    End Sub

    Public Sub ctrack_mnu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ctrack_mnu.Click
        Dim ctrack_menu As New BlankMenuForm
        On Error Resume Next
        package_Type = "CCHR"
        Call pwd_checker()

        If singl <> "N" Then
            ctrack_menu.Show()
        End If
        Me.Close()
        Call errorhandler(Err.Number)
        Me.Close()
    End Sub

    Public Sub day_mnu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles day_mnu.Click
        Dim day_menu As New BlankMenuForm
        On Error Resume Next
        package_Type = "DHB"
        Call pwd_checker()

        If singl <> "N" Then
            day_menu.Show()
        End If
        Me.Close()
        Call errorhandler(Err.Number)
    End Sub

    Public Sub ed_chrt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ed_chrt.Click
        entry_type = ""
        Dim acctlookup As New acctlookup
        acctlookup.Show() 'always this for chart
    End Sub

    Public Sub ed_head_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ed_head.Click
        Dim frmglhead As New frmglhead1
        frmglhead.Show()
    End Sub

    Public Sub ed_pgms_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ed_pgms.Click
        'Dim frm_program As New frm_program
        'frm_program.Show()
    End Sub

    Public Sub EDDEPT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EDDEPT.Click
        Dim dptnumlookup As New dptnumlookup
        pass_level = 1
        package_Type = "DPT"
        dptnumlookup.Show()

    End Sub


    Private Sub frmetstop_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Call acctnumsetup() 'lhw99
        'this turns on the appropriate menu item
        'avail_apps = 0
        Dim temp_apps As Integer
        temp_apps = avail_apps

        For ETS.Common.Module1.num = 18 To 0 Step -1
            If temp_apps - 2 ^ num >= 0 Then
                Select Case num
                    Case 0
                        mnugl.Visible = True
                    Case 1
                        mnuap.Visible = True
                    Case 2
                        mnuar.Visible = True
                    Case 3
                        wk_mnu.Visible = True
                    Case 4
                        t_menu.Visible = True
                    Case 5
                        attmed_mnu.Visible = True
                    Case 6
                        mnumed.Visible = True
                    Case 7
                        mnupca.Visible = True
                    Case 8
                        mnuclpr.Visible = True
                    Case 9
                        ctrack_mnu.Visible = True
                    Case 10
                        mnustpy.Visible = True
                    Case 11
                        strack.Visible = True
                    Case 12
                        day_mnu.Visible = True
                    Case 13
                        mnures.Visible = True
                    Case 14
                        mnutran.Visible = True
                    Case 15
                        mnumf.Visible = True
                    Case 16
                        cc_trk.Visible = True


                End Select
                temp_apps = CInt(temp_apps - 2 ^ num)
            End If

        Next

        Me.Text = "ETS Main Menu - " & agency_name
        gl_report_path = ReportPath

        Dim refs As New List(Of RefData)
        refs = ETSSQL.GetRefData("GL", "ETSMAINMENU")

        For Each ref In refs

            Dim bool As Boolean
            If ref.ControlVisible = "y" Then
                bool = True
            Else
                bool = False
            End If

            Call SetMenuItem(ref.ControlName, bool)

        Next
        mnuclpr.Visible = True

    End Sub

    Public Sub mna_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mna.Click
        On Error Resume Next
        function_type = ""
        package_Type = "TY"
        Call pwd_checker()
        If singl <> "N" Then
            frm_Mastmnu.Show()
            ' Me.Hide()
        End If
        Call errorhandler(Err.Number)
    End Sub

    Public Sub mnuap_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuap.Click
        Dim frm_mnuap As New BlankMenuForm
        package_Type = "AP" ' get you to vendor
        Call pwd_checker()
        If singl <> "N" Then

            frm_mnuap.ShowDialog()
        End If

    End Sub

    Public Sub mnuar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuar.Click
        On Error Resume Next
        package_Type = "AR"
        Call pwd_checker()
        Dim armenu As New BlankMenuForm
        If singl <> "N" Then
            armenu.Show()
        End If

        Call errorhandler(Err.Number)
        Me.Close() 
    End Sub

    Private Sub mnuatt_Click()
        Dim frm_mnuatt As New BlankMenuForm
        On Error Resume Next
        package_Type = "ATT"
        pass_level = 1
        frm_mnuatt.Show()

        Call errorhandler(Err.Number)
        Me.Close()
       
    End Sub

    Public Sub mnubanks_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnubanks.Click
        Dim frmnamechk As New frmnamechk
        pass_level = 1
        package_Type = "GL"
        function_type = "DATA_ENTRY"
        frmnamechk.Show()

    End Sub

    Public Sub mnuclpr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuclpr.Click
        Dim clpr_menu As New clpr_menu
        package_Type = "CC"
        Call pwd_checker()

        If singl <> "N" Then
            clpr_menu.Show()
        End If

        Call errorhandler(Err.Number)
    End Sub

    Public Sub mnuexit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuexit.Click
        End
    End Sub

    Public Sub mnugl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnugl.Click
        Dim frm_mnugl As New BlankMenuForm
         package_Type = "GL"
        Call pwd_checker()
        If singl <> "N" Then
            frm_mnugl.Show()
        End If
        Call errorhandler(Err.Number)
        Me.Close()
    End Sub

    Public Sub mnumed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnumed.Click
        Dim att_med_menu As New BlankMenuForm
        On Error Resume Next
        package_Type = "MM"
        att_med_menu.Show()

    End Sub

    Public Sub mnumf_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnumf.Click
        Dim mfr_menu As New BlankMenuForm
        On Error Resume Next
        package_Type = "MFR"
        Call pwd_checker()

        If singl <> "N" Then
            mfr_menu.Show()
        End If

        Call errorhandler(Err.Number)

    End Sub

    Public Sub mnupca_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnupca.Click
        Dim pca_menu As New BlankMenuForm
        On Error Resume Next
        package_Type = "PCA"
        pca_menu.Show()
        Me.Close()
    End Sub

    Public Sub mnures_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnures.Click
        Dim rb_menu As New BlankMenuForm
        On Error Resume Next
        package_Type = "RB"
        Call pwd_checker()

        If singl <> "N" Then
            rb_menu.Show()
        End If

        Call errorhandler(Err.Number)
    End Sub

    Public Sub mnustpy_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnustpy.Click
        Dim eemenu_frm As New BlankMenuForm  ' keep this way to make sure no one else can open staff payroll
        On Error Resume Next
        package_Type = "EE"

        Call pwd_checker()
        If singl <> "N" Then
            eemenu_frm.Show()

        End If

        Call errorhandler(Err.Number)
        Me.Close()
    End Sub

    Public Sub mnutran_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnutran.Click
        Dim trn_menu As New BlankMenuForm
        On Error Resume Next
        package_Type = "TRN"
        Call pwd_checker()

        If singl <> "N" Then
            trn_menu.Show()
        End If

        Call errorhandler(Err.Number)
        Me.Close()
    End Sub

    Public Sub name_zip_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles name_zip.Click
        Call ETSSQL.BeforeBackup("nam_addr")
        'XXXX

    End Sub

    Public Sub NAMEUP_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles NAMEUP.Click
        Dim frmsys As New frmsys
        package_Type = "SETUP"
        entry_type = "EDIT"
        frmsys.ShowDialog()

        '   End If
    End Sub

    Public Sub PASS_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PASS.Click

        frmpwd_inp.ShowDialog()

        If singl <> "MITCH" And singl <> ("FRTKNX" & Month(Now)) Then
            singl = "N"
            MsgBox("Invalid Password")
            Exit Sub

        Else
            frmpwds.Show()
            frmpwds.BringToFront()
        End If



    End Sub

    Private Sub rpt_gen_Click()
        Dim frm_rpt_Gen As New BlankMenuForm
        frm_rpt_Gen.Show()
    End Sub

    Public Sub strack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles strack.Click
        Dim strack_mnu As New BlankMenuForm  'keep this way to prevent others from opening

        On Error Resume Next
        package_Type = "EEHR"
        Call pwd_checker()
        If singl <> "N" Then
            strack_mnu.Show()
        End If

        Call errorhandler(Err.Number)
        Me.Close()
    End Sub

    Public Sub t_menu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles t_menu.Click
        Dim attmenu As New BlankMenuForm
        On Error Resume Next
        package_Type = "ATT"
        Call pwd_checker()
        If singl <> "N" Then
            attmenu.ShowDialog()
        End If

        Call errorhandler(Err.Number)
        Me.Close()


    End Sub

    Public Sub wk_mnu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles wk_mnu.Click
        Dim frm_arwrkmnu As New BlankMenuForm
        package_Type = "AR"
        Call pwd_checker()
        If singl <> "N" Then
            frm_arwrkmnu.Show()
        End If

        Call errorhandler(Err.Number)
        Me.Close()
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


End Class