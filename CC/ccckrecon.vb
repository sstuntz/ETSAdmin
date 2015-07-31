Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETS.Common.Module1
Imports PS.Common

Public Class ccckrecon_frm
    Inherits System.Windows.Forms.Form
    'form revision removed dbgrid 11/06/2008 lhw
    'data1 is not filled on form load because grid is not enabled until after some events

    '*********************************************


    Public rowvalue, colvalue As Object
    Public Sub rebuild_grid()

        '  For num = Grid1.Rows - 1 To 1 Step -1
        '    Grid1.RemoveItem num
        '    Next
        '
        '    'put headings here where xxx is replaced with a field name
        '
        '    Grid1.AddItem "chk_num" & Chr(9) & "r_date" & Chr(9) & "net_pay" & Chr(9) & "screen_nam", 0
        '
        '
        '        Data1.Refresh
        '        num = 1
        '        Data1.Recordset.MoveFirst
        '        Do While Not Data1.Recordset.EOF
        '        'put in the data for the grid
        '        Grid1.AddItem Data1.Recordset.Fields("chk_num") & Chr(9) & Data1.Recordset.Fields("r_Date") & Chr(9) & Data1.Recordset.Fields("net_pay") & Chr(9) & Data1.Recordset.Fields("screen_nam"), num
        '
        '        Data1.Recordset.MoveNext
        '        num = num + 1
        '        Loop
        '        Grid1.RemoveItem num
        '        selectedcell = False
        '
        '        'fix sizes and number of columns
        '
        '        Grid1.ColWidth(0) = 1600
        '        Grid1.ColWidth(1) = 1600
        '        Grid1.ColWidth(2) = 1600
        '        Grid1.ColWidth(3) = 2200


    End Sub
    Private Sub checknum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles checknum.Enter
        Call ets_set_selected()

    End Sub

    Private Sub checknum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles checknum.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        'check for valid check number
        'move the recon date into the record entered
        'and then clear box for new entry
        On Error Resume Next

        If KeyAscii = 13 Then

            If Len(checknum.Text) = 0 Then
                MsgBox("Please enter a Check Number")
                Call ets_set_selected() 'puts the color in the box
                GoTo EventExitSub
            End If

            valid_check = "N"
            ' Call prchknumverify_recon(Val(checknum.Text))

            If valid_check = "Y" Then

                'checkset.edit()
                'If checkset.Fields("r_date").Value > CDate("01/01/1901") Then
                '	MsgBox("Check# already Reconciled")
                '	Call ets_set_selected()
                '	GoTo EventExitSub
                'Else

                '	Text1.Text = checkset.Fields("screen_nam").Value
                '	Text2.Text = checkset.Fields("net_pay").Value
                '	Response = MsgBox("Is this the right check?", MsgBoxStyle.YesNo)
                '	If Response = 7 Then
                '		Text1.Text = ""
                '		Text2.Text = ""
                '		Call ets_set_selected()
                '		checknum.Focus()
                '		GoTo EventExitSub
                '	End If
                '	Text1.Text = ""
                '	Text2.Text = ""
                'End If

                'checkset.Fields("r_date").Value = recon_date.Text
                'checkset.Fields("recon").Value = "Y"
                'checkset.Update()

                '' Call prchknumrecon(Val(checknum.Text), recon_Date) 'update recon

                checknum.Text = ""
                Call ets_set_selected()

            Else
                MsgBox("Not a valid Check# - Please Re-enter or update the recon table.")
                Call ets_set_selected()
                GoTo EventExitSub
            End If


        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub checknum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles checknum.Leave
        Call ets_de_selected()
        checknum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub cmdcancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdcancel.Click
        Me.Close()

    End Sub

    Private Sub cmdsave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdsave.Click
        Me.Close()
    End Sub

    Private Sub command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles command2.Click
        prtDestination = 0
        prtreportfilename = CShort(cc_report_path & "ccckout.rpt")
        ' Call frmcrystal_Call

    End Sub



    'Private Sub Grid1_MouseDown(Button As Integer, _
    ''Shift As Integer, X As Single, Y As Single)
    '
    '' Get the value of the row and column that the mouse is over
    '    'rowvalue = DBGrid1.RowContaining(Y)
    '    selectedcell = True
    '    SendKeys "(TAB)"
    '    KeyAscii = 0
    '
    '
    '   ' ColValue = DataGrid1.ColContaining(X)
    'End Sub


    Private Sub finished_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles finished.Click
        'found this ti be data1 which is ee chnaged to data2 which is cc 1/18/01 lhw
        'Dim total As Decimal
        'tot_cks.Text = CStr(0)
        ''UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Data1.RecordSource = "select * from ccrecon where r_Date =  #" & recon_date.Text & "#"
        'Data1.Refresh()

        ''UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If Data1.Recordset.RecordCount > 0 Then

        '	total = 0
        '	tot_cks.Text = CStr(0)

        '	'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	Do While Not Data1.Recordset.EOF
        '		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		total = total + Data1.Recordset.Fields("net_pay")
        '		'UPGRADE_ISSUE: Data property Data1.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object Data1.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		Data1.Recordset.MoveNext()
        '		tot_cks.Text = CStr(CDbl(tot_cks.Text) + 1)
        '	Loop 

        '	'DBGrid1.Visible = True             '11/06/2008 lhw
        '	' Grid1.Visible = True

        '	Call rebuild_grid()


        '          tot.Text = String.Format(total, "###,###.00")
        '	proof.Focus()


        'Else
        '	MsgBox("There are no checks for this recon date.")


        'End If

    End Sub

    Private Sub ccckrecon_frm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
    End Sub

    Private Sub proof_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles proof.Click
        prtDestination = 0
        prtreportfilename = CShort(cc_report_path & "ccckrcn.rpt")
        ' Call frmcrystal_Call
    End Sub

    Private Sub recon_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles recon_date.Enter
        Call ets_set_selected()
        recon_date.Text = CStr(Today) '11/06/2008 lhw

        checknum.Text = ""
    End Sub


    Private Sub recon_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles recon_date.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        If KeyAscii = 13 Then
            valid_Date = "N"
            senddate = recon_date.Text
            Call etsdate(senddate, retdate)

            If valid_Date <> "N" Then
                recon_date.Text = retdate
                recon_date.Text = CStr(CDate(recon_date.Text))

                'want to push recon date to rpthead
                'UPGRADE_ISSUE: Data property data2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                'UPGRADE_WARNING: Couldn't resolve default property of object data2.Recordset.edit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'data2.Recordset.edit()
                ''UPGRADE_ISSUE: Data property data2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                ''UPGRADE_WARNING: Couldn't resolve default property of object data2.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'data2.Recordset.Fields("clrecon_date") = recon_date.Text
                ''UPGRADE_ISSUE: Data property data2.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
                ''UPGRADE_WARNING: Couldn't resolve default property of object data2.Recordset.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'data2.Recordset.Update()

                checknum.Focus()

                KeyAscii = 0 'turn off bell
            Else
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            End If
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub recon_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles recon_date.Leave
        recon_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub


    Private Sub reverse_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles reverse.Click
        'found this to be data1 which is ee changed to data2 which is cc 1/18/01 lhw
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        '
        '   Grid1.Col = 0
        '   selected_lookup_num = Grid1.Text
        '   Grid1.Col = 1
        '   selected_lookup_desc = Grid1.Text
        '
        '   'added 11/06/2008 lhw
        '   Response = MsgBox("Do you really want to unselect this check?", vbYesNo + vbDefaultButton2)
        '      If Response = vbYes Then
        '       sqlstmnt = " select * from ccrecon where chk_num = " & selected_lookup_num
        '       Data1.RecordSource = sqlstmnt
        '       Data1.Refresh
        '
        '
        '   Data1.Recordset.edit 'was 2050 changed to 1901 same as staff 11/06/2008 lhw
        '    Data1.Recordset.Fields("r_Date") = CVDate("1/1/1901")
        '    Data1.Recordset.Fields("recon") = "N"
        '    Data1.Recordset.Update
        '    MsgBox "Check has been un-reconed."
        '
        '    Data1.RecordSource = "select * from ccrecon where r_Date =  #" & recon_date & "#"
        '
        '    Call rebuild_grid
        '
        '   End If

        proof.Focus()
    End Sub
End Class