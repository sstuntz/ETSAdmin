Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports ps.common
Imports System.Data.SqlClient

Public Class frmglhead
    Inherits System.Windows.Forms.Form
    Public edit_flag As String

    Private Sub acct_type_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles acct_type1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        'this should write the selection from the list
        'to the table using the combo box
        If KeyAscii = 13 Then
            txtField1(1).Text = acct_type1.Text
        End If

        txtField2(2).Focus()

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click

    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        'prtDestination = 0
        'prtreportfilename = gl_report_path & "glhead.rpt"
        'Call frmcrystal_Call
    End Sub

    Private Sub frmglhead_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        ' recordsource = headings

        Select Case entry_type

            Case "ADD"
                cmdAdd.Visible = True
                If pass_level = 0 Then cmdAdd.Enabled = False
            Case "EDIT"
                cmdUpdate.Visible = True
                If pass_level = 0 Then cmdUpdate.Enabled = False
        End Select

    End Sub

    Private Sub txtField0_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField0.Enter
        Dim Index As Short = txtField0.GetIndex(CType(eventSender, TextBox))
        'do not use ets set selected here
        txtField0(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        txtField0(Index).SelectionStart = 0
        txtField0(Index).SelectionLength = Len(txtField0(Index).Text)


    End Sub

    Private Sub txtField0_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField0.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField0.GetIndex(CType(eventSender, TextBox))
        'this is a test for a number already used
        'used 2nd data source data2 so focus not on first record

        If KeyAscii = 13 Then
            On Error Resume Next

            '   Dim tempdb As database
            '   Dim tempset As Recordset
            '    db = gl_data_path + "glchr.mdb"
            ' Set tempdb = OpenDatabase(db)
            'Set tempset = tempdb.OpenRecordset("headings", dbOpenDynaset)

            sqlstmnt = "gl_ref_no = " & txtField0(0).Text 'use with numbers no quotes
            'sqlstmnt = "acct_dpt = " & Chr(34) & txtField0(0) & Chr(34) 'use with strings

            'tempset.FindFirst sqlstmnt

            'If tempset.NoMatch Then
            'acct_type.SetFocus    'move focust to combo box
            ' Else
            ' MsgBox "This number has been used - please re-enter a new Gl Ref Number"
            ' Call ets_set_selected
            ' Exit Sub
            ' End If


        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub txtField0_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField0.Leave
        Dim Index As Short = txtField0.GetIndex(CType(eventSender, TextBox))
        txtField0(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub txtField10_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField10.Enter
        Dim Index As Short = txtField10.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtField10_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField10.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField10.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            cmdUpdate.Enabled = True
            cmdUpdate.Focus()

        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub txtField10_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField10.Leave
        Dim Index As Short = txtField10.GetIndex(CType(eventSender, TextBox))
        txtField10(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub


    Private Sub txtField2_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField2.Enter
        Dim Index As Short = txtField2.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()

    End Sub

    Private Sub txtField2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField2.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField2.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            txtField3(3).Focus()
        End If

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub txtField2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField2.Leave
        Dim Index As Short = txtField2.GetIndex(CType(eventSender, TextBox))
        txtField2(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub


    Private Sub txtField3_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField3.Enter
        Dim Index As Short = txtField3.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtField3_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField3.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField3.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            txtField4(4).Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub txtField3_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField3.Leave
        Dim Index As Short = txtField3.GetIndex(CType(eventSender, TextBox))
        txtField3(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub


    Private Sub txtField4_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField4.Enter
        Dim Index As Short = txtField4.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtField4_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField4.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField4.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            txtField5(5).Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub txtField4_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField4.Leave
        Dim Index As Short = txtField4.GetIndex(CType(eventSender, TextBox))
        txtField4(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub


    Private Sub txtField5_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField5.Enter
        Dim Index As Short = txtField5.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtField5_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField5.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField5.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            txtField6(6).Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub txtField5_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField5.Leave
        Dim Index As Short = txtField5.GetIndex(CType(eventSender, TextBox))
        txtField5(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub


    Private Sub txtField6_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField6.Enter
        Dim Index As Short = txtField6.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtField6_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField6.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField6.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            txtField7(7).Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub txtField6_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField6.Leave
        Dim Index As Short = txtField6.GetIndex(CType(eventSender, TextBox))
        txtField6(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub


    Private Sub txtField7_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField7.Enter
        Dim Index As Short = txtField7.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()

    End Sub

    Private Sub txtField7_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField7.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField7.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            txtField8(8).Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub txtField7_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField7.Leave
        Dim Index As Short = txtField7.GetIndex(CType(eventSender, TextBox))
        txtField7(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub


    Private Sub txtField8_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField8.Enter
        Dim Index As Short = txtField8.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtField8_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField8.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField8.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            txtField9(9).Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub txtField8_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField8.Leave
        Dim Index As Short = txtField8.GetIndex(CType(eventSender, TextBox))
        txtField8(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub


    Private Sub txtField9_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField9.Enter
        Dim Index As Short = txtField9.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtField9_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField9.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField9.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            txtField10(10).Focus()
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub txtField9_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField9.Leave
        Dim Index As Short = txtField9.GetIndex(CType(eventSender, TextBox))
        txtField9(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click

    End Sub
End Class