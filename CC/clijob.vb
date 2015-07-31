Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports ETS.Common
Imports ETS.pr_common
Imports ETS.clpr_mod
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.Compatibility

Public Class clijob
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
                If TypeOf Me.cntrl Is TextBox Then
                    If String.IsNullOrEmpty(CStr(Me.cntrl.Tag)) Then Me.cntrl.Tag = ""
                    TagColumnName = Me.cntrl.Tag.ToString.Trim
                    If Len(TagColumnName) <> 0 Then
                        TagColumnName = Me.cntrl.Tag.ToString
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

    Private Sub frmclijob_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        frmWhereClause = " where name_key = '" & selected_name_key & "' and job_num = '" & selected_job_num & "'"
        If entry_type = "ADD" Then
            For Each Me.cntrl In Me.Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = ""
                End If
            Next
        Else
            entry_type = "EDIT"
            txtfields(0).Enabled = False
            cmdUpdate.Visible = True
            Dim rs As New Collection
            RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
            For Each Me.cntrl In Me.Controls
                If TypeOf Me.cntrl Is TextBox Then
                    If String.IsNullOrEmpty(CStr(Me.cntrl.Tag)) Then Me.cntrl.Tag = ""
                    TagColumnName = Me.cntrl.Tag.ToString.Trim
                    If Len(TagColumnName) <> 0 Then
                        Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                        If Len(frmdata.ActualData) <> 0 Then
                            If frmdata.DataType = "datetime" Then
                                cntrl.Text = CDate(frmdata.ActualData).ToShortDateString
                            Else
                                cntrl.Text = frmdata.ActualData.ToString
                            End If
                        End If
                    End If
                    'numstr = Me.cntrl.Name.ToString.Substring(11)
                    'TagColumnName = Me.cntrl.Tag.ToString
                    'If Trim(TagColumnName) <> "" Then
                    '    RowData.Find(AddressOf FindColumnName)
                    '    num1 = CInt(numstr)
                    '    Me.cntrl.Text = RowData.Item(num1).ActualData.ToString
                    'End If
                End If
            Next

        End If

        jobdata = etsjobnum_chk(RowData.Item(3).ActualData.ToString)
        txtfields(5).Text = jobdata(2).ToString
        txtfields(7).Text = jobdata(3).ToString
        '     txtfields(8).Text = RowData.Item(7).ActualData.ToString
        txtfields(6).Text = CStr(CDbl(txtfields(7).Text) * CDbl(txtfields(4).Text))
        If RowData.Item(8).ActualData.Length <> 0 Then
            txtfields(9).Text = CStr(Convert.ToDateTime(RowData.Item(8).ActualData))
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
        txtfields(Index).BackColor = Color.Aqua
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
                        Dim frmnamechk As New frmnamechk
                        frmnamechk.ShowDialog()
                        txtfields(Index).Text = selected_name_key
                        txtfields(CShort(Index + 1)).Text = selected_screen_nam
                        txtfields(CShort(Index + 2)).Text = selected_sort_name
                    End If

                    Call chkname(txtfields(Index).Text)

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

                    If txtfields(Index).Text.Length = 0 Then
                        Dim jobnumlookup As New jobnumlookup
                        jobnumlookup.ShowDialog()
                        valid_job = "Y"
                        txtfields(Index).Text = selected_job_num
                    End If
                    jobdata = etsjobnum_chk(txtfields(Index).Text)
                    If jobdata(0).ToString = "N" Then
                        MsgBox("Not a valid job number.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    txtfields(5).Text = jobdata(2).ToString
                    txtfields(7).Text = String.Format("{0:N2}", jobdata(3).ToString)

                Case 4
                    'look up the job and get the rate and calculate
                    If CDbl(txtfields(Index).Text) > 1 Or CDbl(txtfields(Index).Text) <= 0 Then
                        MsgBox("Please enter less than 1 and more than 0.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                    'changed to >= 0.1 8/28/06 per Maggie MacDonald DOL Boston
                    If Val(txtfields(Index).Text) > 0 Then 'added for rounding up 12/16/2009 lhw/scs
                        '     If txtfields(6) * 100 - Int(txtfields(6) * 100) >= 0.001 Then
                        '    txtfields(6) = Int(txtfields(6) * 100) / 100 + 0.01
                        '   End If
                        txtfields(6).Text = CStr(Val(txtfields(4).Text) * Val(txtfields(7).Text))
                        txtfields(6).Text = String.Format("{0:N2}", calc_cl_rate(CDec(Val(txtfields(4).Text)), CDec(Val(txtfields(7).Text)), cl_rate))
                    End If

                Case 8, 9
                    If Len(txtfields(Index).Text) = 0 Then
                        System.Windows.Forms.SendKeys.Send("{tab}")
                        KeyAscii = 0
                        GoTo EventExitSub
                    End If

                    senddate = txtfields(Index).Text
                    valid_Date = etsdate(senddate, CStr(retdate))

                    If valid_Date <> "N" Then
                        txtfields(Index).Text = valid_Date
                    Else
                        MsgBox(" Bad Date")
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