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
Imports System.String

Public Class prog_loc
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "prog_location"
    Public frmWhereClause As String = " where prog_loc = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        'the following code checks for completeness
        'the string field has a list of the field numbers to check
        '     For num = 0 To 100
        ' msg =      & CStr(num) &
        'Response = InStr(         0             1             2             3             6             9             16            17            18            20            40            49           , msg)
        '    If Response <> 0 Then
        '    If Len(txtFields(num)) = 0 Then
        '    MsgBox ('You must fill in all required fields.')
        '    txtFields(num).SetFocus
        '    Exit Sub
        '    End If
        '    End If
        ' Next


        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                TagColumnName = Me.cntrl.Tag.ToString
                Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                frmdata.ActualData = Me.cntrl.Text
            End If
            If TypeOf Me.cntrl Is ComboBox Then
                TagColumnName = Me.cntrl.Tag.ToString
                Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                frmdata.ActualData = Me.cntrl.Text
            End If

        Next

        Select Case entry_type.ToString
            Case "ADD"
                Call ETSSQL.InsertData(frmTableName, RowData)
            Case "EDIT"
                Call ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)
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
        Me.Close()
        Me.Dispose()

    End Sub


    Private Sub frmprog_loc_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ctrform(Me)

        If entry_type = "ADD" Then
            Me.Text = "ADD Form"
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                    txtFields(0).Enabled = True
                End If
            Next

        Else
            Me.Text = "Edit Form"
            entry_type = "EDIT"
            cmdUpdate.Visible = True
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    cntrl.Text = frmdata.ActualData.ToString
                End If
            Next
            txtFields(0).Enabled = False
            TextBox2.Text = ETSSQL.GetOneSQLValue("Select screen_nam as thevalue from nam_addr where name_key = '" & TextBox1.Text & "'")

        End If
    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index
                Case 0

                    If ETSCommon.CheckYN("prog_location", "prog_loc", txtFields(0).Text, "Y") = "Y" Then

                        MsgBox(" Invalid Number")
                        Call ets_set_selected()
                        Exit Sub
                    End If


                Case 1


            End Select

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

    Private Sub TextBox1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextBox1.Enter
        TextBox1.BackColor = Color.Aqua
        TextBox1.SelectAll()

    End Sub

    Private Sub TextBox1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
         If KeyAscii = 13 Or KeyAscii = 9 Then

            function_type = "DATA_ENTRY"
            saved_package_Type = package_Type
            package_Type = "AR"
            valid_name = "N"
            selected_name_key = ""

            If TextBox1.Text.Length = 0 Then
                frmnamechk.ShowDialog()
                TextBox1.Text = selected_name_key
            End If

            Call chkname(TextBox1.Text)
            package_Type = saved_package_Type

            If valid_name = "N" Then
                MsgBox(" Invalid Name ")
                GoTo EventExitSub
            Else
                TextBox2.Text = selected_screen_nam
             End If

            package_Type = "ATT"
            function_type = " "

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub TextBox1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextBox1.Leave
        TextBox1.BackColor = Color.White
    End Sub
End Class