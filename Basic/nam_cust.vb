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
Imports Microsoft.VisualBasic.Compatibility


Public Class frmnam_cust
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "nam_cust"
    Public frmWhereClause As String = " where name_key = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        If Len(txtFields(17).Text) = 0 Then
            MsgBox("You must enter an account number in DR_ACCT_NU field.")
            txtFields(17).Focus()
            Exit Sub
        End If

        If Len(txtFields(18).Text) = 0 Then
            MsgBox("You must enter an account number in CR_ACCT_NU field.")
            txtFields(18).Focus()
            Exit Sub
        End If

        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                If Not Len(Me.cntrl.Tag) = 0 Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    If Len(TagColumnName) <> 0 Then
                        Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                        frmdata.ActualData = Me.cntrl.Text
                    End If
                End If
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
        selected_lookup_num = ""
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmnam_cust_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        frmWhereClause = " where name_key = '" & selected_lookup_num & "'"
        If entry_type = "ADD" Then
            'blank all the fields and make the key enabled
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                    txtFields(0).Enabled = True
                End If
            Next
            txtFields(0).Text = selected_name_key
            txtFields(1).Text = selected_screen_nam
            txtFields(2).Text = selected_sort_name
            txtFields(0).Enabled = False
            txtFields(1).Enabled = False
            txtFields(2).Enabled = False
            txtFields(3).Text = selected_screen_nam
            txtFields(4).Text = ETSCommon.GetDatum("nam_addr", "name_key", selected_name_key, "telephone")
            txtFields(5).Text = ETSCommon.GetDatum("nam_addr", "name_key", selected_name_key, "email")

        Else
            entry_type = "EDIT"
            cmdUpdate.Visible = True
            Dim rs As New Collection
            RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    If Len(TagColumnName) <> 0 Then
                        Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                        If Len(frmdata.ActualData) <> 0 Then
                            If frmdata.DataType = "datetime" Or frmdata.DataType = "DATE" Then
                                cntrl.Text = CDate(frmdata.ActualData).ToShortDateString
                            Else
                                cntrl.Text = frmdata.ActualData.ToString
                            End If
                        End If
                    End If
                End If
            Next
            txtFields(0).Enabled = False
            TextBox2.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & txtFields(18).Text & "'")
            TextBox1.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & txtFields(17).Text & "'")

        End If

        _txtFields_18.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        _txtFields_18.AutoCompleteSource = AutoCompleteSource.CustomSource
        _txtFields_18.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        _txtFields_17.AutoCompleteCustomSource = ETS.Common.Module1.AutoAcctNums
        _txtFields_17.AutoCompleteSource = AutoCompleteSource.CustomSource
        _txtFields_17.AutoCompleteMode = AutoCompleteMode.SuggestAppend

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            If KeyAscii = 13 Or KeyAscii = 9 Then

                Select Case Index

                    Case 4, 7, 10, 13
                        Dim NewPhone = ets_format(txtFields(Index).Text, retstring, CInt("2"))
                        If NewPhone = "N" Then
                            MsgBox("invalid phone number")
                            'Call ets_set_selected()
                            GoTo EventExitSub
                        End If
                        txtFields(Index).Text = NewPhone

                    Case 16 'format the credit dollar limit

                        If Len(txtFields(Index).Text) = 0 Then
                            txtFields(Index).Text = CStr(0)
                            GoTo EventExitSub
                        End If

                        txtFields(Index).Text = String.Format(txtFields(Index).Text, "###0.00;-###0.00")

                    Case 28 'format the commission per cent

                        If Len(txtFields(Index).Text) = 0 Then
                            txtFields(Index).Text = CStr(0)
                            GoTo EventExitSub
                        End If

                        txtFields(Index).Text = String.Format(txtFields(Index).Text, "##0.0000")

                    Case 17, 18, 19

                        valid_acct = " N "
                        function_type_saved = function_type
                        function_type = "LOOKUP_ONLY"

                        Dim retacct As String = etsacctnum_chk(txtFields(Index).Text)

                        If retacct = "N" Then
                            txtFields(Index).Text = ""
                            MsgBox(" Bad Account Number")
                            Call ets_set_selected()
                            GoTo EventExitSub
                        Else
                            txtFields(Index).Text = retacct
                        End If
                        function_type = function_type_saved
                    Case 22, 23

                        valid_Date = "N"
                        senddate = txtFields(Index).Text
                        Call etsdate(senddate, CStr(retdate))

                        If valid_Date <> "N" Then
                            txtFields(Index).Text = CStr(retdate)
                            txtFields(Index).Text = CStr(CDate(txtFields(Index).Text))
                            'the line below shows how to add days to a date and give a new date
                            'duedate = DateAdd(, 30, txtfields(index))
                        Else
                            MsgBox(" Bad Date")
                            Call ets_set_selected()
                            GoTo EventExitSub

                        End If
                End Select

            End If

EventExitSub:
            eventArgs.KeyChar = Chr(KeyAscii)
            If KeyAscii = 0 Then
                eventArgs.Handled = True
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
        If Index = 17 Or Index = 18 Then
            TextBox1.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & txtFields(17).Text & "'")
            TextBox2.Text = ETSSQL.GetOneSQLValue("select acctdesc as TheValue from chacct where acct_num = '" & txtFields(18).Text & "'")
            TextBox2.BackColor = Color.White
            TextBox1.BackColor = Color.White
        End If
    End Sub

End Class