Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETSCommon
Imports ETSCommon.MODULE1
Imports System.Configuration
Imports System.Data.SqlClient

Friend Class update_recon
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 9/23/96 -SCS
	
	'****************
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		Me.Close()
		
	End Sub
	
    Private Sub update_recon_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'ctrform(Me)
    End Sub

    Private Sub Pr_num1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Pr_num1.Enter
        '  Call ets_set_selected()
    End Sub

    Private Sub pr_num1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_num1.KeyPress
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

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_num1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_num1.Leave
        Pr_num1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub Process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Click

        Select Case package_Type
            Case "EE"
                sqlstmnt = " WITH CTE AS (SELECT chk_num, chk_date, chk_dirdep, name_key, screen_nam, sort_name, net_pay, recon, r_date FROM eeckstub WHERE (NOT EXISTS"
                sqlstmnt = sqlstmnt & "       (SELECT     chk_num, chk_date, chk_dirdep, name_key, screen_nam, sort_name, net_pay, recon, r_date FROM eerecon"
                sqlstmnt = sqlstmnt & "       WHERE      (eeckstub.chk_num = chk_num)and eeckstub.void = 'N' and eeckstub.pay and pay_num = " & Pr_num1.Text & "')))"
                sqlstmnt = sqlstmnt & "insert into eerecon (select * from cte) "
                Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
                    Dim sql As String = sqlstmnt
                    db.ExecuteQuery(sql)
                End Using

            Case "CC"
                Response = MsgBox("Do you have a separate bank account for consumer and staff payrolls?", MsgBoxStyle.YesNo)
                If Response = MsgBoxResult.Yes Then
                    sqlstmnt = " WITH CTE AS (SELECT chk_num, chk_date, chk_dirdep, name_key, screen_nam, sort_name, net_pay, recon, r_date FROM ccckstub WHERE (NOT EXISTS"
                    sqlstmnt = sqlstmnt & "       (SELECT     chk_num, chk_date, chk_dirdep, name_key, screen_nam, sort_name, net_pay, recon, r_date FROM ccrecon"
                    sqlstmnt = sqlstmnt & "       WHERE      (ccckstub.chk_num = chk_num)and ccckstub.void = 'N' and ccckstub.pay and pay_num = " & Pr_num1.Text & "')))"
                    sqlstmnt = sqlstmnt & "insert into ccrecon (select * from cte) "
                    Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
                        Dim sql As String = sqlstmnt
                        db.ExecuteQuery(sql)
                    End Using
                Else
                    sqlstmnt = " WITH CTE AS (SELECT chk_num, chk_date, chk_dirdep, name_key, screen_nam, sort_name, net_pay, recon, r_date FROM eeckstub WHERE (NOT EXISTS"
                    sqlstmnt = sqlstmnt & "       (SELECT     chk_num, chk_date, chk_dirdep, name_key, screen_nam, sort_name, net_pay, recon, r_date FROM eerecon"
                    sqlstmnt = sqlstmnt & "       WHERE      (eeckstub.chk_num = chk_num)and eeckstub.void = 'N' and eeckstub.pay and pay_num = " & Pr_num1.Text & "')))"
                    sqlstmnt = sqlstmnt & "insert into eerecon (select * from cte) "
                    Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
                        Dim sql As String = sqlstmnt
                        db.ExecuteQuery(sql)
                    End Using
                End If
        End Select

        MsgBox("Update Complete")
        Process.Enabled = False
        ExitUpdateRecon.Focus()
    End Sub

    Private Sub ExitUpdateRecon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitUpdateRecon.Click
        Me.Close()
    End Sub

End Class