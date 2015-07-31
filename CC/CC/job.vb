Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.Compatibility
Imports System
Imports System.Configuration
Imports ETSCommon.Database
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Data.SqlClient

Friend Class frmjob
	Inherits System.Windows.Forms.Form
	
	'****************
	'revision History
	'original date of this form is 04/14/1998 - SCS

    '****************
    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "ccjob"
    Public frmWhereClause As String = " where job_num = '" & selected_lookup_num & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        For ETSCommon.MODULE1.num = 0 To 100
            msg = "," & CStr(num) & ","
            Response = InStr(",0,1,2,5,9,15,", msg)
            If Response <> 0 Then
                If Len(txtfields(CShort(num)).Text) = 0 Then
                    MsgBox("You must fill in all required fields.")
                    txtfields(CShort(num)).Focus()
                    Exit Sub
                End If
            End If

        Next

        If txtfields(5).Text = "PC" Then
            If Val(txtfields(8).Text) = 0 Then
                MsgBox("You must enter pcs_hr for a PC class job.")
                txtfields(8).Focus()
                Exit Sub
            End If
        End If

        If txtfields(5).Text = "OP" Then
            If Val(txtfields(8).Text) = 0 Then
                MsgBox("You must enter pcs_hr for a PC class job.")
                txtfields(8).Focus()
                Exit Sub
            End If
        End If


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

    Private Sub frmjob_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        frmWhereClause = " where job_num = '" & selected_lookup_num & "'"
        If entry_type = "ADD" Then

        Else
            entry_type = "EDIT"
            cmdUpdate.Visible = True
            Dim rs As New Collection
            RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
            For Each Me.cntrl In Me.Controls
                If TypeOf Me.cntrl Is TextBox Then
                    If Not (Me.cntrl.Tag) Is Nothing Then
                        numstr = Me.cntrl.Name.ToString.Substring(11)
                        TagColumnName = Me.cntrl.Tag.ToString
                        RowData.Find(AddressOf FindColumnName)
                        num1 = CInt(numstr)
                        Me.cntrl.Text = RowData.Item(num1).ActualData.ToString
                    End If
                End If
            Next

        End If

  

        Select Case entry_type

            Case "ADD"
                'cmdAdd.Visible = True
                If pass_level = 0 Then cmdAdd.Enabled = False
            Case "EDIT"
                txtfields(0).Enabled = False
                cmdUpdate.Visible = True
                If pass_level = 0 Then cmdUpdate.Enabled = False
        End Select

        sqlstmnt = "select * from ccjob where job_num = " & Chr(34) & selected_lookup_num & Chr(34)
        '   Data1.RecordSource = sqlstmnt
        '  Data1.Refresh



        '    Data2.Refresh  'cc.mdb
        '   Data2.Recordset.MoveFirst
        '  Data1.Recordset.Fields("min_wage") = Data2.Recordset.Fields("min_wage")



        'added 11/13/2008 lhw
        ' txtfields(36) = Format(txtfields(32), "##0.0000")



    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index
                Case 0

                    If entry_type = "ADD" Then
                        If Len(Trim(txtfields(Index).Text)) = 0 Then
                            MsgBox("You must enter a job num when adding.")
                            GoTo EventExitSub
                            Call ets_set_selected()
                        End If

                        'test if job number exists
                        txtfields(Index).Text = UCase(txtfields(Index).Text)
                        '   valid_job = "N"
                        '  Call etsjobnum_chk(txtfields(0), msg, retjobdesc, valid_job)
                        '   If valid_job = "Y" Then
                        '   MsgBox "Job already exists.  Please edit it."
                        '   Exit Sub
                        '   Call ets_set_selected
                        '   End If
                    End If 'added 6/14/00 scs

                Case 2
                    function_type = "DATA_ENTRY"
                    valid_name = "N"
                    selected_name_key = ""
                    saved_package_Type = package_Type
                    package_Type = "TY" 'changed 4/2/99 so default is for customers without accts receivable

                    If Val(txtfields(Index).Text) = 0 Then
                        Call namelookup()

                        txtfields(Index).Text = selected_name_key
                        txtfields(CShort(Index + 1)).Text = selected_screen_nam
                        txtfields(CShort(Index + 2)).Text = selected_sort_name
                    End If

                    Call chkname(CInt(txtfields(Index).Text))
                    package_Type = saved_package_Type

                    If valid_name = "N" Then
                        txtfields(CShort(Index + 1)).Text = ""
                        txtfields(CShort(Index + 2)).Text = ""
                        MsgBox(" Invalid Customer Number")
                        Call ets_set_selected()

                        GoTo EventExitSub
                    Else
                        txtfields(CShort(Index + 1)).Text = selected_screen_nam
                        txtfields(CShort(Index + 2)).Text = selected_sort_name

                    End If

                Case 5
                    txtfields(Index).Text = UCase(txtfields(Index).Text)
                    'test for valid payclass
                    ETSCommon.MODULE1.valid_YN = "N"

                    If Len(Trim(txtfields(Index).Text)) = 0 Then
                        '   pclasslookup.Show 1

                        txtfields(Index).Text = selected_lookup_num
                    End If

                    ' Call chkpayclass(txtfields(Index), valid_YN)
                    If ETSCommon.MODULE1.valid_YN = "N" Then
                        MsgBox("Invalid Pay Class")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                Case 6 'added for type lookup  11/14/2008 lhw

                    saved_function_Type = function_type
                    function_type = "DATA_ENTRY"
                    valid_dpt = "N"

                    senddpt = txtfields(6).Text
                    retdpt = ""
                    retdptdesc = ""

                    Call hmtype_chk(senddpt, retdpt, retdptdesc, valid_dpt)

                    If valid_dpt = "N" Then
                        MsgBox("Not a valid TYPE .")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    txtfields(Index).Text = retdpt '

                    function_type = saved_function_Type

                Case 7, 9, 18, 24, 25, 33, 34, 35
                    If Len(txtfields(Index).Text) = 0 Then
                        txtfields(Index).Text = CStr(0)
                        GoTo EventExitSub
                    End If

                    txtfields(Index).Text = VB6.Format(txtfields(Index).Text, "##0.00")

                Case 8 ' pcs_hr
                    'changed to >= 0.1 8/28/06 per Maggie MacDonald DOL Boston
                    If Val(txtfields(Index).Text) > 0 Then 'added for rounding up 6/02 lhw/scs
                        txtfields(10).Text = CStr(CDbl(txtfields(9).Text) / CDbl(txtfields(8).Text))
                        Text1.Text = VB6.Format(txtfields(10).Text, "###0.00000000") '9/20/06 shows 8 digits
                        If CDbl(txtfields(10).Text) * 10000 - CInt(CDbl(txtfields(10).Text) * 10000) >= 0.1 Then
                            If CDbl(txtfields(10).Text) * 10000 - CInt(CDbl(txtfields(10).Text) * 10000) < 0.5 Then
                                txtfields(10).Text = CStr(CDec(CDbl(txtfields(10).Text) + 0.0001))
                            End If
                        End If
                        txtfields(10).Text = CStr(CDec(txtfields(10).Text))
                        txtfields(10).Text = VB6.Format(txtfields(10).Text, "###0.0000") 'changed to 4 from 5 7/8/06 lhw
                        txtfields(7).Focus()
                        KeyAscii = 0
                        GoTo EventExitSub
                    End If


                Case 10, 14 'sell_prc   pc_rate
                    If Len(txtfields(Index).Text) = 0 Then
                        txtfields(Index).Text = CStr(0)
                        GoTo EventExitSub
                    End If

                    txtfields(Index).Text = VB6.Format(txtfields(Index).Text, "##0.00000")

                Case 15 'dept_num
                    valid_dpt = "N"
                    senddpt = txtfields(15).Text
                    retdpt = ""
                    retdptdesc = ""

                    valid_dpt = etsdptnum_chk(senddpt, retdpt, retdptdesc)

                    If valid_dpt = "N" Then
                        MsgBox("Not a valid department number.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    txtfields(15).Text = retdpt

                Case 16 't_s_date
                    valid_Date = "N"
                    senddate = txtfields(Index).Text
                    valid_Date = etsdate(senddate, valid_Date)

                    If valid_Date <> "N" Then
                        retdate = CDate(valid_Date)
                        txtfields(Index).Text = CStr(retdate)
                        txtfields(Index).Text = CStr(CDate(txtfields(Index).Text))
                    Else
                        MsgBox(" Bad Date")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If

                Case 28, 29
                    valid_acct = "N"
                    saved_function_Type = function_type
                    function_type = "DATA_ENTRY"
                    Call etsacctnum_chk(txtfields(Index).Text, retacct, retacctdesc, valid_acct)
                    If valid_acct = "Y" Then
                        txtfields(Index).Text = retacct
                    Else
                        MsgBox("Invalid Account.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    function_type = saved_function_Type

                Case 32 'added 11/13/2008 lhw
                    txtfields(32).Text = CStr(CDec(txtfields(32).Text))
                    txtfields(32).Text = VB6.Format(txtfields(32).Text, "##0.00000") 'added 11/17/2008 lhw  4 decimal


                Case 38 'ADP code 11/14/2008 lhw


                    saved_function_Type = function_type
                    function_type = "DATA_ENTRY"
                    valid_dpt = "N"

                    senddpt = txtfields(38).Text
                    retdpt = ""
                    retdptdesc = ""

                    Call hmadp_chk(senddpt, retdpt, retdptdesc, valid_dpt)

                    If valid_dpt = "N" Then
                        MsgBox("Not a valid ADP Code.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    txtfields(Index).Text = retdpt '

                    function_type = saved_function_Type


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

    Private Sub _txtfields_1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _txtfields_1.TextChanged

    End Sub
End Class