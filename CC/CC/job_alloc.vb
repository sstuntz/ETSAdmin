Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETSCommon
Imports ETSCommon.MODULE1
Imports System.Configuration
Imports System.Data.SqlClient

Friend Class job_alloc
    Inherits System.Windows.Forms.Form
    '****************
    'revision History
    'original date of this form is 9/23/96 -SCS

    '****************

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub


    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        'prtDestination = CStr(0)
        'prtreportfilename = cc_report_path & "ccprjob.rpt"
        'Call frmcrystal_call()
    End Sub

    Private Sub job_alloc_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Pr_num1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Pr_num1.Enter
        '  Call ets_set_selected()

    End Sub

    Private Sub pr_num1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles Pr_num1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            beg_chk_num = 0
            last_Chk_num = 0
            'check for a comma to set up a range else just one
            If InStr(1, Pr_num1.Text, ",") > 0 Then
                beg_chk_num = CInt(VB.Left(Pr_num1.Text, InStr(1, Pr_num1.Text, ",") - 1))
                last_Chk_num = CInt(VB.Right(Pr_num1.Text, Len(Pr_num1.Text) - InStr(1, Pr_num1.Text, ",")))
            Else
                beg_chk_num = CInt(Pr_num1.Text)
                last_Chk_num = beg_chk_num
            End If

            '     for reporting move to repthead
            sqlstmnt = " update rpthead set beg_num = '" & beg_chk_num & "' , end_num = '" & last_Chk_num & "'"
            Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
                Dim sql As String = sqlstmnt
                db.ExecuteQuery(sql)
            End Using


            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_num1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Pr_num1.Leave
        Pr_num1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub Process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Click

        Call update_job(beg_chk_num, last_Chk_num)
        System.Windows.Forms.SendKeys.Send("{TAB}")
        KeyAscii = 0

    End Sub
End Class