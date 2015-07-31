Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETS.Common.Module1
Imports ps.common
Imports ETSCommon
Imports Microsoft.VisualBasic.Compatibility
Imports System.Configuration
Imports System.Data.SqlClient


Public Class frmnameaddr
    Inherits System.Windows.Forms.Form

    Public sel_Type_array As String

    Public sqlstmnt As String
    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "nam_addr"
    Public frmWhereClause As String = " where name_key = '" & selected_name_key & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String
    Public search_array(10, 10) As String
    Public frmload As Integer = 0

    Public Sub check_last(ByVal last As String)
        'to check for commas or other pictuation in last name which causes problems in ascii output
        'either MED or Payroll W2 files 10/02/2008 lhw
        Response = InStr(last, ",")
        If Response = 0 Then
            Response = InStr(Name, " ")
        Else
            MsgBox("Please remove the comma from last_name field.")
        End If
    End Sub

    Private Sub avail_types_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles avail_types.DoubleClick
        'this removes the item from this list and adds it to the other list

        sqlstmnt = "insert into nam_Type (name_key, screen_nam, type) values (" & Database.StringParam(selected_name_key) & "," & Database.StringParam(selected_screen_nam) & "," & Database.StringParam(VB6.GetItemString(sel_types, sel_types.SelectedIndex)) & ")"
        Using db As Database = New Database(top_data_path)
            sqlstmnt = db.ExecuteQuery(sqlstmnt).ToString
        End Using
        sel_types.Items.Add(VB6.GetItemString(avail_types, avail_types.SelectedIndex))
        avail_types.Items.RemoveAt(avail_types.SelectedIndex)
        avail_types.Refresh()
        sel_types.Refresh()

    End Sub

    Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click

        selected_name_key = txtfields(0).Text
        selected_screen_nam = txtfields(1).Text
        selected_sort_name = txtfields(2).Text
        txtfields(16).Text = CStr(Now)

        If Len(selected_screen_nam) = 0 Then
            MsgBox("You must enter a screen name")
            Call ets_set_selected()
            txtfields(1).Focus()
            Exit Sub
        End If

        'create autonmuber name key
        '   txtfields(0).Text = GLMod.GetNextNameKey
        '  selected_name_key = txtfields(0).Text

        If Len(selected_name_key) = 0 Then
            MsgBox("You must enter a name key")
            Call ets_set_selected()
            txtfields(0).Focus()
            Exit Sub
        End If

        If Len(selected_sort_name) = 0 Then
            MsgBox("You must enter a sort name")
            Call ets_set_selected()
            txtfields(2).Focus()
            Exit Sub
        End If


        setup.Enabled = True
        sel_types.Enabled = True
        avail_types.Enabled = True

        cmdAdd.Visible = False
        cmdUpdate.Visible = True
        cmdUpdate.Focus()

        cmdUpdate.Focus()

    End Sub

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        If package_Type = "EE" And entry_type = "ADD" Then
            If Len(_txtfields_15.Text) = 0 Then
                MsgBox("You must enter an email address for this staff person.")
                _txtfields_15.Focus()
                Exit Sub
            End If
        End If

        selected_screen_nam = txtfields(1).Text
        selected_name_key = txtfields(0).Text
        'go thru controls and those with tags get moved to etsdata
        Dim cntrl As Control

        For Each cntrl In Me.Controls
            If Not (String.IsNullOrEmpty(Trim(CStr(cntrl.Tag)))) Then
                For cnt As Integer = 0 To RowData.Count - 1
                    If RowData.Item(cnt).ColumnName = cntrl.Tag.ToString Then
                        RowData.Item(cnt).ActualData = cntrl.Text
                    End If
                Next
            End If
        Next

        Select Case entry_type.ToString
            Case "ADD"
                Call ETSSQL.InsertData(frmTableName, RowData)

            Case "EDIT"
                Call ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)

        End Select

        On Error Resume Next
        sqlstmnt = "update nam_bank set screen_nam =" & Database.StringParam(txtfields(1).Text) & ",  sort_name = " & Database.StringParam(txtfields(2).Text) & " where bank_key = " & Database.StringParam(selected_name_key)
        ETSSQL.ExecuteSQL(sqlstmnt)
        sqlstmnt = "update nam_cust set screen_nam =" & Database.StringParam(txtfields(1).Text) & ",  sort_name = " & Database.StringParam(txtfields(2).Text) & " where name_key = " & Database.StringParam(selected_name_key)
        ETSSQL.ExecuteSQL(sqlstmnt)
        sqlstmnt = "update nam_vend set screen_nam =" & Database.StringParam(txtfields(1).Text) & ",  sort_name = " & Database.StringParam(txtfields(2).Text) & " where name_key = " & Database.StringParam(selected_name_key)
        ETSSQL.ExecuteSQL(sqlstmnt)
        sqlstmnt = "update cc_fund set screen_nam =" & Database.StringParam(txtfields(1).Text) & ",  sort_name = " & Database.StringParam(txtfields(2).Text) & " where name_key = " & Database.StringParam(selected_name_key)
        ETSSQL.ExecuteSQL(sqlstmnt)
        sqlstmnt = "update cc_cont set screen_nam =" & Database.StringParam(txtfields(1).Text) & " where name_key = " & Database.StringParam(selected_name_key)
        ETSSQL.ExecuteSQL(sqlstmnt)
        sqlstmnt = "update cc_base set screen_nam =" & Database.StringParam(txtfields(1).Text) & ",  sort_name = " & Database.StringParam(txtfields(2).Text) & " where name_key = " & Database.StringParam(selected_name_key)
        ETSSQL.ExecuteSQL(sqlstmnt)
        On Error GoTo 0

        '   setup.Items.Clear()
        '  sel_types.Items.Clear()
        ' avail_types.Items.Clear()
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click

        setup.Items.Clear()
        sel_types.Items.Clear()
        avail_types.Items.Clear()

        entry_type = "CANCEL"
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmnameaddr_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        If Len(selected_name_key) = 0 Then
            entry_type = "ADD"
            cmdAdd.Visible = True
            '  If pass_level = 0 Then cmdAdd.Enabled = False
            '    sel_types.Enabled = False
            '   avail_types.Enabled = False
            Label6.Visible = True
        Else
            entry_type = "EDIT"
            cmdUpdate.Visible = True
            '    If pass_level = 0 Then cmdUpdate.Enabled = False
            Dim rs As New Collection
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    If Not IsNothing(frmdata) Then
                        If Len(frmdata.ActualData) <> 0 Then
                            If frmdata.DataType = "datetime" Or frmdata.DataType = "DATE" Then
                                cntrl.Text = CDate(frmdata.ActualData).ToShortDateString
                            Else
                                cntrl.Text = frmdata.ActualData.ToString
                            End If
                        End If
                    End If
                End If
                'If TypeOf cntrl Is TextBox Then
                '    For cnt As Integer = 0 To RowData.Count - 1
                '        If RowData.Item(cnt).ColumnName = cntrl.Tag.ToString Then
                '            cntrl.Text = RowData.Item(cnt).ActualData.ToString
                '        End If
                '    Next
                'End If
            Next

        End If

        'here we want to fill the three list boxes
        'avail types is all that have not been used
        'sel types is used
        'we assume that nam_types and type source are available

        'If entry_type = "ADD" Then
        '    setup.Enabled = False
        '    sel_types.Enabled = False
        '    avail_types.Enabled = False
        '    setup.Items.Clear()
        '    sel_types.Items.Clear()
        'End If

        If entry_type = "EDIT" Then
            ' setup.Enabled = True
            ' sel_types.Enabled = True
            ' avail_types.Enabled = True
            _txtfields_0.Enabled = False
            _txtfields_0.Text = selected_name_key

            'setup - from table names
            'create a list from table names of all places to check and then do a lookup in each
            '    Using db As Database = New Database(top_data_path)
            '        Dim sql As String = "select * from table_names"
            '        Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            '        intcount = 0
            '        While rs.Read()
            '            search_array(intcount, 0) = rs("db").ToString
            '            search_array(intcount, 1) = rs("tbl").ToString
            '            intcount = intcount + 1
            '        End While
            '        rs.Close()
            '    End Using
            '    intcount = intcount - 1
            '    'now do lookups using check yn
            '    Dim YNValue As String = ""
            '    Dim YNCount As Integer
            '    For ETS.Common.Module1.num = 0 To intcount
            '        If search_array(num, 1) = "nam_bank" Then
            '            YNCount = CInt(CheckOnceYN(search_array(num, 1), "bank_key", selected_name_key, YNValue))
            '        Else
            '            YNCount = CInt(CheckOnceYN(search_array(num, 1), "Name_key", selected_name_key, YNValue))
            '        End If
            '        If YNCount <> 0 Then
            '            setup.Items.Add(search_array(num, 1))
            '        End If
            '    Next
            '    'sel types 
            '    Using db As Database = New Database(top_data_path)
            '        Dim sql As String = "select * from nam_type where name_key = '" & selected_name_key & "'"
            '        Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            '        intcount = 0
            '        While rs.Read()
            '            sel_types.Items.Add(rs("type").ToString)
            '        End While
            '        rs.Close()
            '    End Using


            '    frmload = 1
        End If

        ''avail types - all but what is above
        'Using db As Database = New Database(top_data_path)
        '    Dim sql As String = "select * from type_source "
        '    Dim rs As SqlDataReader = db.ExecuteQuery(sql)
        '    intcount = 0
        '    While rs.Read()
        '        avail_types.Items.Add(rs("type_names").ToString)
        '    End While
        '    rs.Close()
        'End Using

    End Sub

    'Private Sub sel_types_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles sel_types.DoubleClick
    '    ''this removes an item from the list and refreshes the list

    '    sqlstmnt = "delete from nam_Type where name_key = " & Database.StringParam(selected_name_key) & " and type = " & Database.StringParam(VB6.GetItemString(sel_types, sel_types.SelectedIndex))
    '    Using db As Database = New Database(top_data_path)
    '        sqlstmnt = db.ExecuteQuery(sqlstmnt).ToString
    '    End Using
    '    avail_types.Items.Add(VB6.GetItemString(sel_types, sel_types.SelectedIndex))
    '    sel_types.Items.RemoveAt(sel_types.SelectedIndex)

    '    avail_types.Refresh()
    '    sel_types.Refresh()

    'End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        On Error Resume Next
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        Call ets_set_selected()
        'autonumber set on add button
        If entry_type = "ADD" Then
            If Index = 1 Then
                txtfields(1).Text = txtfields(4).Text & " " & txtfields(6).Text
                txtfields(2).Text = txtfields(6).Text & ", " & txtfields(4).Text
            End If
        End If

    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Integer = Asc(eventArgs.KeyChar)
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            If Index = 0 Then
                txtfields(Index).Text = Trim(txtfields(Index).Text)
                If Len(txtfields(Index).Text) > 8 Then
                    MsgBox("Name key is too long")
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If

                valid_name = "N"
                If chkname_top(txtfields(0).Text) = "Y" Then
                    MsgBox("This number has already been used.")
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If

                If Not IsNumeric(txtfields(0).Text) Then
                    MsgBox("Please enter a number.")
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If

            End If

            If Index = 1 Then
                selected_screen_nam = txtfields(1).Text
                If Len(txtfields(Index).Text) = 0 Then
                    MsgBox("This must be filled in")
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If
            End If

            If Index = 2 Then
                If Len(txtfields(Index).Text) = 0 Then
                    MsgBox("This must be filled in")
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If

            End If
            If Index = 4 Then 'added 04/02/2009 lhw med and w2 files
                Response = InStr(txtfields(Index).Text, ",")
                If Response <> 0 Then
                    MsgBox("Please remove the comma from first_name field.")
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If
                txtfields(1).Text = txtfields(4).Text & " " & txtfields(6).Text
                txtfields(2).Text = txtfields(6).Text & ", " & txtfields(4).Text
            End If

            If Index = 6 Then 'added 10/02/2008 lhw med and w2 files
                Response = InStr(txtfields(Index).Text, ",")
                If Response <> 0 Then
                    MsgBox("Please remove the comma from last_name field.")
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If
                txtfields(1).Text = txtfields(4).Text & " " & txtfields(6).Text
                txtfields(2).Text = txtfields(6).Text & ", " & txtfields(4).Text
            End If

            If Index = 10 Then
                txtfields(Index).Text = StrConv(txtfields(Index).Text, VbStrConv.ProperCase)
            End If

            If Index = 11 Then
                txtfields(Index).Text = UCase(txtfields(Index).Text)
                If ets_state_chk(txtfields(Index).Text) = "N" Then
                    MsgBox("Invalid state/province")
                    Call ets_set_selected()
                    GoTo EventExitSub
                End If
            End If

            If Index = 12 Then
                'this adds a dash if on the sitxth character
                If Len(txtfields(Index).Text) > 5 Then
                    txtfields(Index).Text = VB.Left(txtfields(Index).Text, 5) & "-" & VB.Right(txtfields(Index).Text, 4)
                End If
            End If

            If Index = 13 Then
                If Len(txtfields(Index).Text) <> 0 Then
                    retstring = ets_format(txtfields(Index).Text, retstring, CInt("2"))
                    If retstring = "N" Then
                        MsgBox("invalid phone number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    txtfields(Index).Text = retstring
                    retstring = ""
                End If
            End If

            If Index = 14 Then
                If Len(txtfields(Index).Text) <> 0 Then
                    retstring = ets_format(txtfields(Index).Text, retstring, CInt("2"))
                    If retstring = "N" Then
                        MsgBox("invalid fax number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    txtfields(Index).Text = retstring
                    retstring = ""
                End If
            End If

            If Index = 18 Then
                txtfields(Index).Text = UCase(txtfields(Index).Text)
            End If

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

        txtfields(Index).BackColor = Color.White

    End Sub

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub textbox1_enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextBox1.Enter
        TextBox1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub textbox1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TextBox1.Leave
        TextBox1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub TextBox1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        Dim KeyAscii As Integer = Asc(EventArgs.KeyChar)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If

    End Sub
End Class