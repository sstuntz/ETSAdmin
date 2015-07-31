Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports ps.common
Imports System.Data.SqlClient

Public Class frmnam_vend
    Inherits System.Windows.Forms.Form

    '****************
    'revision History
    'original date of this form is 9/23/96 -SCS
    'new form for sql 04/25/2011

    '****************
    '****************

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "nam_vend"
    Public frmWhereClause As String = " where name_key = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        'test for completeness on txtfields only
        'fields 0 1 2 3 6 9 16 17 18 20 40 49


        'For num = 0 To 100
        '    msg = "," & CStr(num) & ","
        '    Response = InStr(",0,2,3,4,", msg)
        '    If Response <> 0 Then
        '        If Len(txtFields(num).Text) = 0 Then
        '            MsgBox("You must fill in all required fields.")
        '            txtFields(num).Focus()
        '            Exit Sub
        '        End If
        '    End If

        'Next

        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                TagColumnName = Me.cntrl.Tag.ToString
                Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                frmdata.ActualData = Me.cntrl.Text
            End If
        Next

        'If Len(txtfields(14).Text) = 0 Then
        '    MsgBox("You must enter an account number in CR_ACCT_NU field.")
        '    txtfields(14).Focus()
        '    Exit Sub
        'End If

        'If Len(txtfields(15).Text) = 0 Then
        '    MsgBox("You must enter an account number in DR_ACCT_NU field.")
        '    txtfields(15).Focus()
        '    Exit Sub
        'End If


        'txtfields(17).Text = CStr(Now)

        Select Case entry_type.ToString
            Case "ADD"
                'add sort name and agency
                RowData.Item(21).ActualData = selected_sort_name
                RowData.Item(22).ActualData = CStr((AgencyNum))
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
        selected_lookup_num = ""
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmnam_vend_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Normal     'added lhw 06/19/2012
        ctrform(Me)

        frmWhereClause = " where name_key = '" & selected_lookup_num & "'"
        If entry_type = "ADD" Then
            'blank all the fields and make the key enabled
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                    txtfields(0).Enabled = True
                    txtfields(1).Enabled = True
                End If
            Next
            txtfields(1).Text = selected_screen_nam
            txtfields(0).Text = selected_name_key
            txtfields(0).Enabled = False
            txtfields(1).Enabled = False

        Else
            entry_type = "EDIT"
            cmdUpdate.Visible = True
            'now check if nam vend ever set up even if an edit from name addr
            If chkname(selected_lookup_num) = "N" Then
                entry_type = "ADD"
                For Each Me.cntrl In Me.Controls
                    If TypeOf cntrl Is TextBox Then
                        cntrl.Text = ""
                        txtfields(0).Enabled = True
                        txtfields(1).Enabled = True
                    End If
                Next
                txtfields(0).Text = selected_lookup_num
                txtfields(1).Text = selected_screen_nam
                txtfields(0).Enabled = False
                txtfields(1).Enabled = False
                Exit Sub
            End If


            Dim rs As New Collection
            RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    If Len(frmdata.ActualData) <> 0 Then
                        If frmdata.DataType = "datetime" Or frmdata.DataType = "DATE" Then
                            cntrl.Text = CDate(frmdata.ActualData).ToShortDateString
                        Else
                            cntrl.Text = frmdata.ActualData.ToString
                        End If
                    End If
                End If
            Next
            txtfields(0).Enabled = False
        End If

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index
                Case 3, 5
                    retstring = ets_format(txtfields(Index).Text, "", 2)
                    If retstring <> "N" Then
                        txtfields(Index).Text = retstring
                    Else
                        MsgBox("invalid phone number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                Case 14, 15, 16

                    valid_acct = " N "
                    function_type_saved = function_type
                    function_type = "LOOKUP_ONLY"

                    Dim retacct As String = etsacctnum_chk(txtfields(Index).Text)

                    If retacct = "N" Then
                        txtfields(Index).Text = ""
                        MsgBox(" Bad Account Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtfields(Index).Text = retacct
                    End If
                    txtfields(Index).Text = retacct
                    function_type = function_type_saved

                Case 17, 18

                    valid_Date = "N"
                    senddate = txtfields(Index).Text
                    Call etsdate(senddate, CStr(retdate))

                    If valid_Date <> "N" Then
                        txtfields(Index).Text = CStr(retdate)
                        txtfields(Index).Text = CStr(CDate(txtfields(Index).Text))
                    Else
                        MsgBox(" Bad Date")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                Case 7, 19, 21
                    txtfields(Index).Text = UCase(txtfields(Index).Text)

                    If txtfields(Index).Text <> "Y" And txtfields(Index).Text <> "N" Then
                        MsgBox("You must enter a Y or N")
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

    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

End Class