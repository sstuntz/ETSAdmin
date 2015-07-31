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

Public Class frmcc_autho
    Inherits System.Windows.Forms.Form
    Dim tmp_txtField_value As Object 'used for default values - TMK 8/26/03

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "cc_fund"
    Public frmWhereClause As String = " where name_key = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Dim SelectedIndex As Integer

    Private Sub rebuild_grid()  'ByVal sql As String)
        'if edit just the selected contract string else cc fund lookup

        'scsdo
        'cc_fund.RecordSource = "select * from cc_Fund where bill_type = ""140"" and  name_key = " & Chr(34) & selected_name_key & Chr(34)
        'cc_fund.Refresh()
        'Do While Not cc_fund.Recordset.EOF
        '    List1.Items.Add(cc_fund.Recordset.Fields("contract_key") 
        '    cc_fund.Recordset.MoveNext()
        'Loop

        If Val(CStr(new_Fiscal)) = 0 Then
            new_Fiscal = CInt(CStr(Year(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 6, Today))))
        End If

        If current_fiscal <> new_Fiscal Then
            sqlstmnt = "Select autho_num, name_key, sort_name, contract_key from cc_autho where year(autho_End) <> '" & new_Fiscal & "' order by sort_name"
        Else
            sqlstmnt = "Select autho_num, name_key, sort_name, contract_key from cc_autho where year(autho_End) = '" & new_Fiscal & "' order by sort_name"
        End If

        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sqlstmnt)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        selected_lookup_num = ""
        If SelectedIndex > 0 Then
            DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
            DataGridView1.Rows(SelectedIndex).Selected = True
            DataGridView1.Rows(SelectedIndex).Cells(0).Selected = True
            DataGridView1.PerformLayout()
        Else
            On Error Resume Next
            DataGridView1.Rows(0).Selected = False
            On Error GoTo 0
        End If

        DataGridView1.AutoResizeColumns()
    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_contract_key = DataGridView1.Item("contract_key", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub

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


        If entry_type = "ADD" Then
            If selectedcell = False Then
                MsgBox("Nothing selected from contracts")
                Exit Sub
            End If
        End If

        Dim bnum As String = txtFields(1).Text & selected_contract_key

        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                TagColumnName = Me.cntrl.Tag.ToString
                Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                frmdata.ActualData = Me.cntrl.Text
            End If
        Next

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
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmcc_autho_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        DataGridView1.Columns.Add("contract_key", "Contract")
        DataGridView1.Columns.Item(0).DataPropertyName = "contract_key"

        ctrform(Me)
        selectedcell = False

        sqlstmnt = "select * from cc_autho where "
        frmWhereClause = " where name_key = '" & selected_contract_key & "' and name_key = '" & selected_name_key & "'"

        Dim autho As New List(Of AuthoData)
        autho = ETSSQL.GetAuthoData(sqlstmnt)

        If autho.Count = 0 Then
            entry_type = "ADD"
        End If

        If entry_type = "ADD" Then
            'blank all the fields and make the key enabled
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                    txtFields(1).Enabled = True
                End If
            Next
            txtFields(1).Enabled = True

        Else
            entry_type = "EDIT"

            cmdUpdate.Visible = True

            txtFields(1).Text = selected_name_key
            txtFields(2).Text = selected_sort_name
            rebuild_grid()

            'scsdo
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
            txtFields(0).Enabled = False
        End If
        function_type = "DATA_ENTRY"
        DataGridView1.Rows(0).Selected = True

        txtFields(25).Text = CStr(CDate(Today))

    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            saved_entry_type = entry_type

            Select Case Index
                Case 0  ' sw name key

                    selected_name_key = ""
                    saved_package_Type = package_Type

                    If Val(txtFields(Index).Text) = 0 Then
                        package_Type = "TY"
                        frmnamechk.ShowDialog()
                        txtFields(Index).Text = selected_name_key
                        package_Type = saved_package_Type
                    End If

                    If chkname(txtFields(Index).Text) = "N" Then
                        Text1.Text = ""
                        MsgBox(" Invalid Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    Text1.Text = selected_screen_nam
                    'the following code is used to get additional data from nam_Addr
                    Text2.Text = ETSCommon.GetDatum("nam_addr", "name_key", selected_name_key, "telephone")

                Case 1  'name key

                    selected_name_key = ""
                    saved_package_Type = package_Type

                    If Val(txtFields(Index).Text) = 0 Then
                        package_Type = "ATT"
                        frmnamechk.ShowDialog()
                        txtFields(Index).Text = selected_name_key
                        package_Type = saved_package_Type
                    End If

                    If chkname(txtFields(Index).Text) = "N" Then
                        Text1.Text = ""
                        MsgBox(" Invalid Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    entry_type = saved_entry_type
                    txtFields(Index).Text = selected_name_key
                    txtFields(CShort(Index + 1)).Text = selected_sort_name

                    If entry_type = "ADD" Then
                        rebuild_grid()
                    End If

                Case 11 'customer key

                    selected_name_key = ""
                    package_Type_saved = package_Type

                    If Val(txtFields(Index).Text) = 0 Then
                        package_Type = "AR"
                        frmnamechk.ShowDialog()
                        txtFields(Index).Text = selected_name_key
                        package_Type = saved_package_Type
                    End If

                    If chkname(txtFields(Index).Text) = "N" Then
                        Text1.Text = ""
                        MsgBox(" Invalid Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    entry_type = saved_entry_type
                    txtFields(Index).Text = selected_name_key

                    package_Type = package_Type_saved

                Case 5, 6

                    Dim retdate As String = ETS.Common.Module1.etsdate(txtFields(Index).Text, "N")

                    If retdate = "N" Then
                        txtFields(Index).Text = ""
                        MsgBox(" Bad Date")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtFields(Index).Text = retdate
                    End If

                Case 3, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24
                    txtFields(Index).Text = UCase(txtFields(Index).Text)

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

    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Leave
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub
End Class