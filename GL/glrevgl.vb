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
Imports ETS

Public Class glrevgl_frm
    Inherits System.Windows.Forms.Form

    Public NextJENum As Integer



    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        'test to see that JE exists
        sqlstmnt = "select * from yrgenled WHERE yrgenled.jrnl_num = " & txtFields(0).Text
        sqlstmnt = sqlstmnt & " and yrgenled.post = 'Y'"
        sqlstmnt = sqlstmnt & " Order By jrnl_num, jrnl_line  "

        '    yrgenled.RecordSource = sqlstmnt
        '    yrgenled.Refresh
        '    On Error Resume Next
        '    yrgenled.Recordset.MoveFirst
        'If Error = 3021 Then
        '      MsgBox("This JE either doesn't exist or have not been posted to yrgenled.")
        '      Call ets_set_selected()
        '      Exit Sub
        '  Else
        '      Command4.Focus()
        '  End If

    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click 'lhw 3/26/97
        sqlstmnt = "insert into yrgenled select * from gltmp"
        ETSSQL.ExecuteSQL(sqlstmnt)
        MsgBox("J/E Complete!!! Print the J/E now.")
        Command2.Focus()        '5/15/00  lhw
        Command1.Enabled = False

    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click

        prtDestination = 0
        prtreportfilename = ar_report_path & "rev_jrnl.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "gltmp_rev.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
        '1 this cleans the gltmp table
        sqlstmnt = "delete from gltmp"
        ETSSQL.ExecuteSQL(sqlstmnt)

        ''2 gltmp  
        sqlstmnt = "insert into gltmp "
        sqlstmnt = sqlstmnt & "select * from yrgenled WHERE yrgenled.jrnl_num = " & txtFields(0).Text
        sqlstmnt = sqlstmnt & " and yrgenled.post = 'Y'"
        sqlstmnt = sqlstmnt & " Order By jrnl_num, jrnl_line  "
        ETSSQL.ExecuteSQL(sqlstmnt)
        'change the j/e number
        'change the amt to neg
        NextJENum = GLMod.GetNextJENum("Regular")
        NextJENum = NextJENum + 1
        sqlstmnt = "update gltmp set jrnl_num = " & NextJENum
        ETSSQL.ExecuteSQL(sqlstmnt)
        'put number in rpthead for later reporting
        sqlstmnt = "update gltmp set amount =  (amount* -1)"
        ETSSQL.ExecuteSQL(sqlstmnt)
        sqlstmnt = "update gltmp set encum_date =  '" & _txtFields_1.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        MsgBox("Data is in GLTMP File")
        Command3.Focus()

    End Sub

    Private Sub glrevgl_frm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index
                Case 0
                    '
                    '         sqlstmnt = "select * from yrgenled WHERE yrgenled.jrnl_num = " & txtFields(0)
                    '         sqlstmnt = sqlstmnt & " and yrgenled.post = 'Y'"
                    '         sqlstmnt = sqlstmnt & " Order By jrnl_num, jrnl_line  "
                    '
                    '    yrgenled.RecordSource = sqlstmnt
                    '    yrgenled.Refresh
                    '    On Error Resume Next
                    '    yrgenled.Recordset.MoveFirst
                    '    If Error = 3021 Then
                    '    MsgBox "This JE either doesn't exist or have not been posted to yrgenled."
                    '    Call ets_set_selected
                    '    Exit Sub
                    '    Else
                    '    'Command4.SetFocus
                    '    End If
                    '    On Error GoTo 0



                Case 1
                    valid_Date = "N"
                    senddate = txtFields(Index).Text
                    If etsdate(senddate, valid_Date) <> "N" Then
                        System.Windows.Forms.SendKeys.Send("{tab}")
                        KeyAscii = 0
                    Else
                        MsgBox("Bad date")
                        Form.ActiveForm.ActiveControl.BackColor = Color.Aqua()
                        GoTo EventExitSub
                    End If

                    txtFields(Index).Text = valid_Date

            End Select
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Leave
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        txtFields(Index).SelectionStart = 0
        txtFields(Index).SelectionLength = Len(txtFields(Index).Text)
    End Sub
End Class