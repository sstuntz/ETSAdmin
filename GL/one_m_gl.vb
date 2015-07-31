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

Public Class one_m_gl
    Inherits System.Windows.Forms.Form

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        sqlstmnt = "delete * from yrgenled WHERE jrnl_num = 99999 "
        ETSSQL.ExecuteSQL(sqlstmnt)
        'create a $0 je line for each 

        sqlstmnt = "update yrgenled set x=x from chacct inner join yrgenled on chacct.acct_num = yrgenled.acct_num"




        'add this record for each line aboce


        '	yrgenled.Recordset.Fields("jrnl_num").Value = 99999
        '	yrgenled.Recordset.Fields("jrnl_line").Value = num + 1
        '	num = num + 1
        '	yrgenled.Recordset.Fields("entry_type").Value = "SD"
        '	yrgenled.Recordset.Fields("jrnl_name").Value = "JE"
        '	yrgenled.Recordset.Fields("jrnl_src").Value = "JE"
        '	yrgenled.Recordset.Fields("acct_num").Value = Trim(chacct.Recordset.Fields("acct_num").Value)
        '	yrgenled.Recordset.Fields("amount").Value = 0
        '	yrgenled.Recordset.Fields("jrnl_desc").Value = "Temporary"
        '	yrgenled.Recordset.Fields("oper_id").Value = "Auto"
        '	yrgenled.Recordset.Fields("encum_Date").Value = txtfields(1).Text
        '	yrgenled.Recordset.Fields("a_post").Value = "Y"
        '	yrgenled.Recordset.Fields("post").Value = "Y"

        MsgBox("You can now print the One Month GL Report")

    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Response = MsgBox("Have you erased JE# 99999? If not, say NO and do it.", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.No Then
            Exit Sub
        End If

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        MsgBox("This is the detail for One Month: Uses Prior_m_ytd field not current_ytd")
        prtDestination = 0
        prtreportfilename = gl_report_path & "glmnth.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        MsgBox("This removes the temporary JE 99999 used to print the One Month GL.")
        sqlstmnt = "delete * from yrgenled WHERE jrnl_num = 99999 "
        ETSSQL.ExecuteSQL(sqlstmnt)
        MsgBox("Temporary JE 99999 has been erased.")
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        Response = MsgBox("Have you erased JE# 99999? If not, say NO and do it.", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.No Then
            Exit Sub
        End If
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub one_m_gl_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index
                Case 1

                    If Len(txtfields(1).Text) = 0 Then
                        MsgBox("Enter This Months End Date")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    valid_Date = "N"
                    senddate = _txtFields_1.Text
                    Call etsdate(senddate, valid_Date)

                    If valid_Date <> "N" Then
                        _txtFields_1.Text = CStr(valid_Date)
                        _txtFields_1.Text = CStr(CDate(_txtFields_1.Text))
                        'update headings  - beg date
                        sqlstmnt = "update rpthead set end_date = '" & valid_Date & "'"
                        ETSSQL.ExecuteSQL(sqlstmnt)
                        KeyAscii = 0 'turn off bell
                    Else
                        MsgBox("Bad date")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
            End Select

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub
End Class