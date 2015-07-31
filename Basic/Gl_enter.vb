Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETSCommon.Database
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Data.SqlClient
Friend Class frmgl_enter
    Inherits System.Windows.Forms.Form


    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "chacct"
    Public frmWhereClause As String = " where acct_num = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Dim acct_split() As String
  
    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        _txtFields_3.Text = acct_num.Text

        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                TagColumnName = Me.cntrl.Tag.ToString
                Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                frmdata.ActualData = Me.cntrl.Text
            End If
        Next

        Select Case entry_type.ToString
            Case "ADD"
                Call ETSCommon.ETSSQL.InsertData(frmTableName, RowData)
            Case "EDIT"
                Call ETSCommon.ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)
        End Select
        Me.Close()
        Me.Dispose()

    End Sub

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        selected_lookup_num = ""
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmgl_enter_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ctrform(Me)
        frmWhereClause = " where acct_num = '" & selected_lookup_num & "'"
        If entry_type = "ADD" Then
            'blank all the fields and make the key enabled
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                    acct_num.Enabled = True
                End If
            Next

        Else
            entry_type = "EDIT"
            cmdUpdate.Visible = True
            Dim rs As New Collection
            RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    cntrl.Text = frmdata.ActualData.ToString
                  End If
            Next
            acct_num.Text = _txtFields_3.Text
            txtFields(0).Enabled = False
        End If

        'need to create a lookup to glsys

        'If glsys.Recordset.Fields("acct_num_len") <> 10 Then
        '    acct_num.Mask = glsys.Recordset.Fields("Acct_num_mask")
        '    ' Debug.Print acct_num.Mask
        '    acct_num_blank = glsys.Recordset.Fields("Acct_num_blank")
        '    'Debug.Print acct_num_blank
        '    acct_num.Format = glsys.Recordset.Fields("Acct_num_mask")
        'Else
        '    acct_num.Mask = "####-##-##"
        '    acct_num_blank = "____-__-__"
        'End If

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            Select Case Index

                Case 2
                    If Val(txtFields(2).Text) = 0 Then
                        MsgBox("Please enter a number")
                        ' Call ets_set_selected()
                        'GoTo EventExitSub
                        Exit Sub
                    End If
            End Select

            If Index = 2 Then
                Call chk_ref_num_only(_txtFields_5.Text, valid_acct) 'set up new call and used generic call in MOD 04/07/2011
                'If valid_acct = "N" Then
                If valid_dpt = "N" Then
                    msg = "GL_REF_NO " & _txtFields_12.Text & " is not set up."
                    Response = MsgBox(msg)
                    ' Call ets_set_selected()
                    'GoTo EventExitSub
                    Exit Sub
                End If

            End If


            If Index = 3 Then
                txtFields(Index).Text = UCase(txtFields(Index).Text)
                If CStr(txtFields(Index).Text) <> "CR" Then
                    If CStr(txtFields(Index).Text) <> "DR" Then
                        MsgBox("Please enter CR or DR")
                        ' Call ets_set_selected()
                        ' GoTo EventExitSub
                        Exit Sub
                    End If
                End If

            End If
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Leave
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub acct_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles acct_num.Enter
        acct_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))

    End Sub

    Private Sub acct_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles acct_num.KeyPress
        Dim KeyAscii As Short = CShort(Asc(EventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            acct_num.SelectionStart = 0
            valid_acct = "N"
            sendacct = acct_num.Text.ToString
            Call chk_acct_num_only(sendacct, valid_acct)
            If valid_dpt = "Y" Then
                'If valid_acct = "Y" Then
                MsgBox("Account number already exists.")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            acct_split = acct_num.Text.ToString.Split(CChar("-"))
            _txtFields_11.Text = acct_split(0)      'acct_only
            _txtFields_12.Text = acct_split(1)      'prog
            _txtFields_13.Text = acct_split(2)      'dept


            valid_acct = "N"
            Call chk_acct_pgm_only(_txtFields_12.Text, valid_acct)
            ' If valid_acct = "N" Then
            If valid_dpt = "N" Then
                msg = "Program number " & _txtFields_12.Text & " is not set up. Set it up and then re-enter data."
                Response = MsgBox(msg)
                ' Call ets_set_selected()
                GoTo EventExitSub
            End If

            valid_acct = "N"
            Call chk_acct_dpt_only(_txtFields_13.Text, valid_acct)
            ' If valid_acct = "N" Then
            If valid_dpt = "N" Then
                msg = "Department number " & _txtFields_13.Text & " is not set up. Set it up and then re-enter data."
                Response = MsgBox(msg)
                ' Call ets_set_selected()
                GoTo EventExitSub
            End If

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
        acct_num.Focus()
    End Sub

    Private Sub acct_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles acct_num.Leave
        acct_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

End Class




