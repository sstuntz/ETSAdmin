Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports System
Imports System.Configuration
Imports ETSCommon.Database
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.Compatibility

Friend Class frmclijob
    Inherits System.Windows.Forms.Form

    '****************
    'revision History
    'original date of this form is 01/24/1998 - SCS


    '****************

    Dim cl_rate As Decimal
    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "cc_clijob"
    Public frmWhereClause As String = " where name_key = '" & selected_name_key & "' and job_num = '" & selected_job_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String
    Public jobdata As List(Of String)

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                numstr = Me.cntrl.Name.ToString.Substring(11)
                TagColumnName = Me.cntrl.Tag.ToString
                RowData.Find(AddressOf FindColumnName)
                num1 = CInt(numstr)
                RowData.Item(num1).ActualData = Me.cntrl.Text
            End If
        Next

        Select Case entry_type.ToString
            Case "ADD"
                Call ETSCommon.ETSSQL.InsertData(frmTableName, RowData)
            Case "EDIT"
                Call ETSCommon.ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)
        End Select
        Me.Close()
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

    Private Sub frmclijob_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        frmWhereClause = " where name_key = '" & selected_name_key & "' and job_num = '" & selected_job_num & "'"
        If entry_type = "ADD" Then

        Else
            entry_type = "EDIT"
            txtfields(0).Enabled = False
            cmdUpdate.Visible = True
            Dim rs As New Collection
            RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
            For Each Me.cntrl In Me.Controls
                If TypeOf Me.cntrl Is TextBox Then
                    numstr = Me.cntrl.Name.ToString.Substring(11)
                    TagColumnName = Me.cntrl.Tag.ToString
                    If Trim(TagColumnName) <> "" Then
                        RowData.Find(AddressOf FindColumnName)
                        num1 = CInt(numstr)
                        Me.cntrl.Text = RowData.Item(num1).ActualData.ToString
                    End If
                End If
            Next

        End If

        sendjob = RowData.Item(3).ActualData.ToString
        jobdata = etsjobnum_chk(sendjob)
        txtfields(5).Text = jobdata(1).ToString
        txtfields(7).Text = CStr(Convert.ToDateTime(RowData.Item(7).ActualData))
        If RowData.Item(8).ActualData.Length <> 0 Then
            txtfields(8).Text = CStr(Convert.ToDateTime(RowData.Item(8).ActualData))
        End If


    End Sub

    Private Sub del_rec_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'added 7/8/01lhw
        Response = MsgBox("Do you really want to delete this record?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = MsgBoxResult.Yes Then
            sqlstmnt = "select * from cc_clijob where job_num = " & Chr(34) & selected_lookup_num & Chr(34)
            sqlstmnt = sqlstmnt & " and name_key = " & Chr(34) & selected_name_key & Chr(34)
            'Data1.RecordSource = sqlstmnt
            'Data1.Refresh()
            '' Data1.Recordset.Edit
            '' Data1.Refresh

            ''UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            'Do While Not Data1.Recordset.EOF
            '    'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '    Data1.Recordset.delete()
            '    'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '    Data1.Recordset.MoveNext()
            'Loop

        End If
        MsgBox("Record has been deleted from cc_clijob file.")
    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
        If Index = 0 Then
            txtfields(0).Text = selected_name_key
            txtfields(3).Text = selected_job_num
        End If
    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index
                Case 0
                    function_type = "DATA_ENTRY"
                    valid_name = "N"
                    selected_name_key = ""

                    If Val(txtfields(Index).Text) = 0 Then
                        Call namelookup()
                        txtfields(Index).Text = selected_name_key
                        txtfields(CShort(Index + 1)).Text = selected_screen_nam
                        txtfields(CShort(Index + 2)).Text = selected_sort_name
                    End If

                    Call chkname(CInt(txtfields(Index).Text))

                    If valid_name = "N" Then
                        txtfields(CShort(Index + 1)).Text = ""
                        txtfields(CShort(Index + 2)).Text = ""
                        MsgBox(" Invalid Client Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Else
                        txtfields(CShort(Index + 1)).Text = selected_screen_nam
                        txtfields(CShort(Index + 2)).Text = selected_sort_name

                    End If

                Case 3
                    txtfields(Index).Text = UCase(txtfields(Index).Text)
                    ETSCommon.MODULE1.valid_YN = "N"
                    sendjob = txtfields(Index).Text
                    jobdata = etsjobnum_chk(sendjob)

                    If jobdata(3).ToString = "N" Then
                        MsgBox("Not a valid job number.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    txtfields(3).Text = sendjob
                    txtfields(5).Text = jobdata(1).ToString
                    txtfields(7).Text = VB6.Format(jobdata(2).ToString, "FIXED")

                Case 4
                    'look up the job and get the rate and calculate
                    If CDbl(txtfields(Index).Text) > 1 Or CDbl(txtfields(Index).Text) <= 0 Then
                        MsgBox("Please enter less than 1 and more than 0.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    'changed to >= 0.1 8/28/06 per Maggie MacDonald DOL Boston
                    If Val(txtfields(Index).Text) > 0 Then 'added for rounding up 12/16/2009 lhw/scs
                        'changed to below 1/22/10 for hmea and all others
                        '   txtfields(6) = Val(txtfields(4)) * Val(txtfields(7))
                        '

                        '     If txtfields(6) * 100 - Int(txtfields(6) * 100) >= 0.001 Then
                        '    txtfields(6) = Int(txtfields(6) * 100) / 100 + 0.01
                        '   End If

                        txtfields(6).Text = CStr(Val(txtfields(4).Text) * Val(txtfields(7).Text))
                        'Text1.Text = VB6.Format(txtfields(6).Text, "###0.0000")

                        Call calc_cl_rate(CDec(Val(txtfields(4).Text)), CDec(Val(txtfields(7).Text)), cl_rate) 'added 1/22/10 scs
                        txtfields(6).Text = CStr(cl_rate) 'added 1/22/10 scs


                    End If

                    txtfields(6).Text = CStr(CDec(txtfields(6).Text))
                    txtfields(6).Text = VB6.Format(txtfields(6).Text, "###0.00") 'changed to 4 from 5 7/8/06 lhw



                    ' txtfields(6) = Format(txtfields(4) * retrate, "FIXED")

                Case 8, 9 'added start date 11/13/2008 lhw

                    If Len(txtfields(Index).Text) = 0 Then
                        'UPGRADE_ISSUE: TextBox property txtFields.DataChanged was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
                        '	txtFields(Index).DataChanged = False
                        System.Windows.Forms.SendKeys.Send("{tab}")
                        KeyAscii = 0
                        GoTo EventExitSub
                    End If

                    valid_Date = "N"
                    valid_Date = etsdate(txtfields(Index).Text, valid_Date)
                    If valid_Date = "Y" Then
                        retdate = CDate(valid_Date)
                        txtfields(Index).Text = CStr(CDate(retdate))
                        If Index = 3 Then 'forces anniv month to be the month of hire date
                            txtfields(5).Text = CStr(Month(CDate(txtfields(Index).Text)))
                        End If

                        System.Windows.Forms.SendKeys.Send(("{tab}"))
                        KeyAscii = 0
                        GoTo EventExitSub
                    End If
                    MsgBox("Not a Valid Date")
                    Call ets_set_selected()
                    GoTo EventExitSub

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