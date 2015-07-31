Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports Valid_YN
Imports ETS

Public Class glx_stand
    Inherits System.Windows.Forms.Form

    Dim batch_Amount As Decimal
    Dim vouch_Done As Integer 'noumber of invoices in this session
    Public JeLookupNum As String
    Dim total_amt As Decimal
    Dim JESource As String
    Public JeRowData As List(Of JeData)

    Public Sub tot_amt()
        total_amt = 0
        For Each JeRow In JeRowData
            total_amt = CDec(total_amt + JeRow.Amount)
        Next
        vouchtotaldisplay.Text = Format(total_amt, "#####0.00;-#####0.00")
        If total_amt = 0 Then
            V_done.Enabled = True
        Else
            V_done.Enabled = False
        End If
    End Sub

    Private Sub EnterHeader()
        If entry_type = "ADD" Then
            Me.jrnl_name.SelectedIndex = 0
            Me.jrnl_src.SelectedIndex = 0
            Me.ent_type.SelectedIndex = 0
            JeRowData.Item(0).JrnlName = CStr(jrnl_name.SelectedItem)
            JeRowData.Item(0).JrnlSrc = CStr(jrnl_src.SelectedItem)
            JeRowData.Item(0).EntryType = CStr(ent_type.SelectedItem)
            JeRowData.Item(0).JrnlLineNum = 1
        Else
            Me.ent_Date.Text = JeRowData.Item(0).EntryDate.ToShortDateString
            Me.enc_date.Text = JeRowData.Item(0).EncumDate.ToShortDateString
            Me.OperID.Text = JeRowData.Item(0).OperId.ToString
            Me.jrnl_name.SelectedItem = JeRowData.Item(0).JrnlName.ToString
            Me.jrnl_src.SelectedItem = JeRowData.Item(0).JrnlSrc.ToString
            Me.ent_type.SelectedItem = JeRowData.Item(0).EntryType.ToString
        End If

    End Sub

    Public Sub CloseForm()
        JeRowData.Clear()

        'blank the grid
        Dim linenum As Short
        For linenum = 0 To 9
            V_line(linenum).Text = ""
            acct_num(linenum).Text = ""
            acct_desc(linenum).Text = ""
            line_Tot(linenum).Text = ""
            jrnl_desc(linenum).Text = ""
        Next

        jrnl_name.Items.Clear()
        jrnl_src.Items.Clear()
        ent_type.Items.Clear()

        OperID.Text = ""
        enc_date.Text = ""
        ent_Date.Text = ""
        vouchtotaldisplay.Text = ""

        If je_type = "STAND" Then
            entry_type = "CANCEL"
        End If
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub LoadComboBoxes()

        'reference - form name, control name, package type, data and data desc
        Dim JeRefData As List(Of RefData) = ETSSQL.GetRefData(package_Type, Me.Name)
        jrnl_name.Items.Clear()
        jrnl_src.Items.Clear()
        ent_type.Items.Clear()

        Dim JeRef As RefData
        For Each JeRef In JeRefData
            If JeRef.ControlName = "jrnl_name" Then
                jrnl_name.Items.Add(JeRef.DatumDesc)
            End If
            If JeRef.ControlName = "jrnl_src" Then
                jrnl_src.Items.Add(JeRef.DatumDesc)
            End If
            If JeRef.ControlName = "ent_type" Then
                ent_type.Items.Add(JeRef.DatumDesc)
            End If
        Next

    End Sub

    Private Sub repaint_grid(ByVal offset_grid_line As Short)
        'the offset_grid_line number is the first line visible

        Dim linenum As Short
        If offset_grid_line < 0 Then offset_grid_line = 0
        If offset_grid_line > JeRowData.Count - 6 Then
            offset_grid_line = CShort(JeRowData.Count - 6)
            If offset_grid_line < 0 Then offset_grid_line = 0
            'Exit Sub
        End If

        For linenum = 0 To 9
            On Error Resume Next
            V_line(linenum).Text = JeRowData.Item(linenum + offset_grid_line).JrnlLineNum.ToString
            acct_num(linenum).Text = JeRowData.Item(linenum + offset_grid_line).AcctNum.ToString
            acct_desc(linenum).Text = JeRowData.Item(linenum + offset_grid_line).AcctDesc.ToString
            line_Tot(linenum).Text = JeRowData.Item(linenum + offset_grid_line).Amount.ToString
            line_Tot(linenum).Text = FormatNumber(line_Tot(linenum).Text, 2, TriState.True, TriState.False, TriState.True)
            jrnl_desc(linenum).Text = JeRowData.Item(linenum + offset_grid_line).JrnlDesc.ToString
            If Err.Number <> 0 Then
                V_line(linenum).Text = CStr(linenum + offset_grid_line + 1)
                acct_num(linenum).Text = acct_num_blank
                acct_desc(linenum).Text = ""
                line_Tot(linenum).Text = ""
                jrnl_desc(linenum).Text = ""
                Dim emptyrow As New JeData
                JeRowData.Add(emptyrow)
                JeRowData.Item(linenum + offset_grid_line).JrnlLineNum = CInt(V_line(linenum).Text)
                JeRowData.Item(linenum + offset_grid_line).AcctNum = acct_num_blank
                JeRowData.Item(linenum + offset_grid_line).AcctDesc = ""
                JeRowData.Item(linenum + offset_grid_line).JrnlDesc = ""
            End If
        Next
        On Error GoTo 0

    End Sub

    Private Sub glx_stand_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        JeLookupNum = selected_lookup_num
secondJE:
        acct_num_blank = "____-__-__"
        offset_grid_line = 0
        'JeRowData.Clear()

        Select Case je_type
            Case "STAND"
                Select Case entry_type
                    Case "ADD"
                        Me.Text = "ADD Standard JE Form"
                        'deal with addnew when go to write the form
                        jrnl_num.Text = JeLookupNum  '  next number calculated on lookup form GLMod.GetNextJENum(entry_type).ToString
                        JeLookupNum = ""
                        'create blank jerowdata
                        JeRowData = ETSSQL.GetBlankJeData()
                        JeRowData.Item(0).JrnlNum = CInt(jrnl_num.Text)
                        JeRowData.Item(0).AcctNum = acct_num_blank
                        JeRowData.Item(0).JrnlLineNum = 1
                        'get agency data
                        'set other data void, dflag
                    Case "EDIT"
                        Me.Text = "Edit Standard JE Form"
                        JESource = "select je_stand.*, chacct.acct_desc from je_Stand inner join chacct on je_Stand.acct_num = chacct.acct_num where jrnl_num = " & JeLookupNum & " order by jrnl_line"
                        jrnl_num.Text = JeLookupNum
                        JeRowData = ETSSQL.GetJeData(JESource)
                End Select

            Case "REGULAR"
                Select Case entry_type
                    Case "ADD"
                        Me.Text = "JE Add Form"
                        'deal with addnew when go to write the form
                        jrnl_num.Text = GLMod.GetNextJENum(entry_type).ToString
                        JeLookupNum = ""
                        JeRowData = ETSSQL.GetBlankJeData()
                        JeRowData.Item(0).JrnlNum = CInt(jrnl_num.Text)
                        JeRowData.Item(0).AcctNum = acct_num_blank
                        JeRowData.Item(0).JrnlLineNum = 1

                    Case "EDIT"
                        Me.Text = "JE Edit Form"
                        JESource = "select yrgenled.* ,  chacct.acct_desc from yrgenled  INNER JOIN chacct ON yrgenled.acct_num = chacct.acct_num where(jrnl_num = " & JeLookupNum & ")" & " order by jrnl_line"
                        jrnl_num.Text = JeLookupNum
                        JeRowData = ETSSQL.GetJeData(JESource)
                End Select
        End Select

        ' enc_date.Enabled = False       'changed lhw 04/19/2012  'if stand then ok
        'enc_date.Text = Date.Today.ToShortDateString   'changed lhw 04/19/2012

        Call LoadComboBoxes()
        function_type = "DATA_ENTRY"

        jrnl_num.Enabled = True
        jrnl_num.Focus()
        repaint_grid(0)
        Call EnterHeader()

        Me.ActiveControl = jrnl_num


    End Sub

    Private Sub ent_type_enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ent_type.Enter
        ent_type.BackColor = Color.Aqua()
    End Sub

    Private Sub ent_type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ent_type.SelectedIndexChanged
        JeRowData.Item(0).JrnlName = CStr(ent_type.SelectedItem)
    End Sub

    Private Sub ent_type_keypress(ByVal sender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ent_type.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 9 Or KeyAscii = 13 Then
            JeRowData.Item(0).JrnlName = CStr(jrnl_name.SelectedItem)
            ent_Date.Focus()
        End If

    End Sub

    Private Sub ent_type_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ent_type.Leave
        ent_type.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub jrnl_name_enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jrnl_name.Enter
        jrnl_name.BackColor = Color.Aqua
    End Sub

    Private Sub jrnl_name_keypress(ByVal sender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles jrnl_name.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 9 Or KeyAscii = 13 Then
            JeRowData.Item(0).JrnlName = CStr(jrnl_name.SelectedItem)
            jrnl_src.Focus()
        End If

    End Sub

    Private Sub jrnl_name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles jrnl_name.SelectedIndexChanged
        JeRowData.Item(0).JrnlName = CStr(jrnl_name.SelectedItem)
    End Sub

    Private Sub jrnl_name_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jrnl_name.Leave
        jrnl_name.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub Jrnl_src_enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jrnl_src.Enter
        jrnl_src.BackColor = Color.Aqua
    End Sub

    Private Sub jrnl_src_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles jrnl_src.SelectedIndexChanged
        JeRowData.Item(0).JrnlSrc = CStr(jrnl_src.SelectedItem)
    End Sub

    Private Sub jrnl_src_keypress(ByVal sender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles jrnl_src.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 9 Or KeyAscii = 13 Then
            JeRowData.Item(0).JrnlName = CStr(jrnl_name.SelectedItem)
            ent_type.Focus()
        End If

    End Sub

    Private Sub Jrnl_src_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jrnl_src.Leave
        jrnl_src.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub jrnl_desc_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jrnl_desc.Enter
        '  Dim Index As Short = jrnl_desc.GetIndex(CType(eventSender, TextBox))
        Form.ActiveForm.ActiveControl.BackColor = Color.Aqua

    End Sub

    Private Sub jrnl_desc_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles jrnl_desc.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = jrnl_desc.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            If Len(jrnl_desc(Index).Text) > 25 Then
                MsgBox("Max length of Desc can only be 25 including spaces.")
                jrnl_desc(Index).Focus()
                Form.ActiveForm.ActiveControl.BackColor = Color.Aqua()
                Exit Sub
            End If

            If Index = 9 Then
                offset_grid_line = CShort(offset_grid_line + 1)
                Call repaint_grid(CShort(offset_grid_line))
                V_line(9).Focus()
                KeyAscii = 0
                GoTo EventExitSub
            End If
            JeRowData.Item(CInt(V_line(Index).Text) - 1).JrnlDesc = jrnl_desc(Index).Text
            acct_num(CShort(Index + 1)).Focus()
            KeyAscii = 0
            GoTo EventExitSub
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub jrnl_desc_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jrnl_desc.Leave
        Dim Index As Short = jrnl_desc.GetIndex(CType(eventSender, TextBox))
        jrnl_desc(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub acct_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles acct_num.Enter
        ' Dim Index As Short = acct_num.GetIndex(CType(eventSender, TextBox))
        Form.ActiveForm.ActiveControl.BackColor = Color.Aqua()
        Call tot_amt()

    End Sub

    'Private Sub acct_num_mousedown((ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles acct_num.MouseDown
    '    Dim Index As Short = acct_num.GetIndex(CType(EventHandler, TextBox))
    '    acct_num(Index).SelectAll()
    'End Sub

    Private Sub acct_num_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles acct_num.KeyDown
        Dim KeyCode As Short = CShort(eventArgs.KeyCode)
        Dim Shift As Short = CShort(eventArgs.KeyData \ &H10000)
        Dim Index As Short = acct_num.GetIndex(CType(eventSender, TextBox))
        Select Case KeyCode
            Case CShort(System.Windows.Forms.Keys.F3) 'duplicate line
                'can only be done on a blank line
                If acct_num(Index).Text <> acct_num_blank Or Len(Trim(acct_num(Index).Text)) = 0 Then
                    MsgBox("Please Insert a blank line first")
                    Exit Sub
                End If
                If Index <> 0 Then
                    acct_num(Index).Text = acct_num(CShort(Index - 1)).Text
                    acct_desc(Index).Text = acct_desc(CShort(Index - 1)).Text
                    Dim acctnum As String
                    acctnum = etsacctnum_chk(acct_num(Index).Text)
                    If acctnum.Substring(0, 1) = "N" Then
                        MsgBox("This account does not exist.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                        Exit Sub
                    End If
                    Dim anums = acctnum.Split(CChar("**"))
                    acct_num(Index).Text = anums(0)
                    acct_desc(Index).Text = anums(2)
                    JeRowData.Item(CInt(V_line(Index).Text) - 1).AcctNum = anums(0)  'retacct
                    JeRowData.Item(CInt(V_line(Index).Text) - 1).AcctDesc = anums(2)  'acct_desc(Index).Text
                    JeRowData.Item(CInt(V_line(Index).Text) - 1).JrnlLineNum = CInt(V_line(Index).Text)
                    If retacct = acct_num_blank Then GoTo EventExitSub
                    line_Tot(Index).Focus()
                    KeyAscii = 0
                    line_Tot(Index).Focus()
                    KeyAscii = 0
                    line_Tot(CShort(Index - 1)).Focus()
                    KeyAscii = 0
                    V_done.Enabled = False
                End If
                Call repaint_grid(0) ' (CShort(V_line(0).Text))
                acct_num(Index).Focus()
                acct_num(Index).Select(8, 2)
            Case CShort(System.Windows.Forms.Keys.F5)  'delete line
                msg = "Do you wish to delete this line?"
                Response = MsgBox(msg, MsgBoxStyle.YesNo)
                If Response = MsgBoxResult.No Then Exit Sub
                JeRowData.RemoveAt(CInt(V_line(Index).Text) - 1)
                'renumber the array
                For n = 0 To JeRowData.Count - 1
                    JeRowData.Item(n).JrnlLineNum = n + 1
                Next
                Call repaint_grid(0) ' (CShort(V_line(0).Text))
                Call tot_amt()
                acct_num(Index).Focus()
                acct_num(Index).SelectAll()
            Case CShort(System.Windows.Forms.Keys.F6)  'insert line
                If Index = 0 Then Exit Sub
                msg = "Do you wish to insert a line after this line?"
                Response = MsgBox(msg, MsgBoxStyle.YesNo)
                If Response = MsgBoxResult.No Then Exit Sub
                Dim emptyrow As New JeData
                JeRowData.Insert(CInt(V_line(Index).Text), emptyrow) 'JeRowData.Item(CInt(jrnl_num.Text)))
                'renumber other lines
                For n = 1 To JeRowData.Count - 1
                    JeRowData.Item(n).JrnlLineNum = n + 1
                Next
                Call repaint_grid(0) ' (CShort(V_line(0).Text))
                acct_num(CShort(Index + 1)).Focus()
                acct_num(CShort(Index + 1)).SelectAll()
            Case Else
                Exit Sub
        End Select
EventExitSub:

        If KeyAscii = 0 Then
            eventArgs.Handled = True

        End If

    End Sub

    Private Sub acct_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles acct_num.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = acct_num.GetIndex(CType(eventSender, TextBox))

        If KeyAscii = 13 Or KeyAscii = 9 Then
            acct_num(Index).SelectionStart = 0 'to make sure field is cleared
            Dim acctnum As String
            acctnum = etsacctnum_chk(acct_num(Index).Text)
            If acctnum.Substring(0, 1) = "N" Then
                MsgBox("This account does not exist.")
                Call ets_set_selected()
                acct_num(Index).Focus()
                acct_num(Index).SelectAll()
                GoTo EventExitSub
                Exit Sub
            End If
            Dim anums = acctnum.Split(CChar("**"))
            acct_num(Index).Text = anums(0)
            acct_desc(Index).Text = anums(2)
            JeRowData.Item(CInt(V_line(Index).Text) - 1).AcctNum = anums(0)  'retacct
            JeRowData.Item(CInt(V_line(Index).Text) - 1).AcctDesc = anums(2)  'acct_desc(Index).Text
            JeRowData.Item(CInt(V_line(Index).Text) - 1).JrnlLineNum = CInt(V_line(Index).Text)
            If retacct = acct_num_blank Then GoTo EventExitSub
            line_Tot(Index).Focus()
            KeyAscii = 0
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True

        End If
    End Sub

    Private Sub acct_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles acct_num.Leave
        Dim Index As Short = acct_num.GetIndex(CType(eventSender, TextBox))
        acct_num(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        'line_Tot(Index).Focus()
    End Sub

    Private Sub down_grid_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles down_grid.Click
        '  If JeRowData.Count < 8 Then Exit Sub

        offset_grid_line = CShort(offset_grid_line - 1)
        'If offset_grid_line > JeRowData.Count - 7 Then offset_grid_line = CShort(JeRowData.Count - 7)
        If offset_grid_line < 0 Then offset_grid_line = 0
        Call repaint_grid(CShort(offset_grid_line))

    End Sub

    Public Sub up_grid_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles up_grid.Click
        'if two blank rows do not add to offset grid line

        If JeRowData.Item(offset_grid_line + 7).AcctNum = acct_num_blank Then
            Exit Sub
        Else
            offset_grid_line = CShort(offset_grid_line + 1)
            Call repaint_grid(CShort(offset_grid_line)) 'oldfocus was index?

        End If

    End Sub

    Private Sub enc_Date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles enc_date.Enter
        Form.ActiveForm.ActiveControl.BackColor = Color.Aqua()
    End Sub

    Private Sub enc_Date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles enc_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            valid_Date = "N"
            senddate = enc_date.Text
            If etsdate(senddate, valid_Date) <> "N" Then
                enc_date.Text = CDate(etsdate(senddate, valid_Date)).ToShortDateString
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
            Else
                MsgBox("Bad date")
                Form.ActiveForm.ActiveControl.BackColor = Color.Aqua()
                GoTo EventExitSub
            End If
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub enc_Date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles enc_date.Leave
        enc_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub ent_Date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ent_Date.Enter
        ent_Date.Text = Date.Today.ToShortDateString
    End Sub

    Private Sub ent_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles ent_Date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            valid_Date = "N"
            senddate = ent_Date.Text
            If etsdate(senddate, valid_Date) <> "N" Then
                ent_Date.Text = etsdate(senddate, valid_Date)
                ' OperID.Focus()
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
            Else
                MsgBox("Bad date")
                Form.ActiveForm.ActiveControl.BackColor = Color.Aqua()
                GoTo EventExitSub
            End If
        End If
        Exit Sub
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub ent_Date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ent_Date.Leave
        ent_Date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub OperID_enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OperID.Enter
        Form.ActiveForm.ActiveControl.BackColor = Color.Aqua()
    End Sub

    Public Sub OperId_keypress(ByVal sender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles OperID.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            JeRowData.Item(0).OperId = OperID.Text
            acct_num(0).Focus()
            KeyAscii = 0
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub operid_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OperID.Leave
        OperID.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
        acct_num(0).Focus()
    End Sub

    Private Sub line_tot_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles line_Tot.Enter
        '    Dim Index As Short = line_Tot.GetIndex(CType(eventSender, TextBox))
        ' Form.ActiveForm.ActiveControl.BackColor = Color.Aqua()
        Call ets_set_selected()
    End Sub

    Private Sub line_tot_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles line_Tot.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = line_Tot.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            line_Tot(Index).Text = VB6.Format(line_Tot(Index).Text, "FIXED")

            If IsNumeric(line_Tot(Index).Text) = False Then
                MsgBox("Please enter a number.")
                Form.ActiveForm.ActiveControl.BackColor = Color.Aqua()
                GoTo EventExitSub
            End If
            'if add then repeat the desc
            Select Case entry_type
                Case "ADD"
                    If Index <> 0 Then
                        jrnl_desc(Index).Text = jrnl_desc(CShort(Index - 1)).Text
                    End If
            End Select
            JeRowData.Item(CInt(V_line(Index).Text) - 1).Amount = CDec(line_Tot(Index).Text)
            jrnl_desc(Index).Focus()
            KeyAscii = 0
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub line_Tot_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles line_Tot.Leave
        Dim Index As Short = line_Tot.GetIndex(CType(eventSender, TextBox))
        line_Tot(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Public Sub v_Cancel_gotfocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles V_Cancel.GotFocus
        jrnl_num.Focus()
    End Sub

    Private Sub V_Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles V_Cancel.Click
        Call CloseForm()

    End Sub

    Private Sub V_line_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles V_line.Enter
        Dim Index As Short = V_line.GetIndex(CType(eventSender, TextBox))
        acct_num(Index).Focus()
        KeyAscii = 0
    End Sub

    Private Sub V_line_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles V_line.Leave
        Dim Index As Short = V_line.GetIndex(CType(eventSender, TextBox))
        V_line(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub jrnl_num_gotfocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jrnl_num.GotFocus
        'ent_Date.Text = Date.Today.ToShortDateString
        'Call EnterHeader()
        'Call tot_amt()
        'Call repaint_grid(0)
        JeRowData.Item(0).JrnlNum = CInt(jrnl_num.Text)
        jrnl_name.Focus()
        KeyAscii = 0
        jrnl_num.Enabled = False
    End Sub

    Private Sub jrnl_num_leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles jrnl_num.Leave
        ent_Date.Text = Date.Today.ToShortDateString
        Call EnterHeader()
        Call tot_amt()
        Call repaint_grid(0)
        JeRowData.Item(0).JrnlNum = CInt(jrnl_num.Text)
        jrnl_name.Focus()
        KeyAscii = 0
        jrnl_num.Enabled = False
    End Sub

    Private Sub V_done_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles V_done.Click 'J/E Complete
        'check for valid dates in header first - could have tabbed off the field
        If Len(Trim(ent_Date.Text)) = 0 Then
            MsgBox("Entry date is blank")
            ent_Date.Focus()
            Exit Sub
        End If
        If Len(Trim(enc_date.Text)) = 0 Then
            MsgBox("Effective date is blank")
            enc_date.Focus()
            Exit Sub
        Else
            enc_date.Text = enc_date.Text
        End If



        'check header complete - first item complete and rest are a copy
        'check lines complete
        'checl accts one more time
        'check total one more time

        'delete all rows with blank acct nums - they were added when list was repainted
        'and fill the header
        Dim i As Integer
        For i = JeRowData.Count - 1 To 0 Step -1
            If JeRowData.Item(i).AcctNum = acct_num_blank Then
                JeRowData.RemoveAt(i)
            Else
                JeRowData.Item(i).APost = "N" 'JeRowData.Item(0).APost
                JeRowData.Item(i).dflag = "N" 'JeRowData.Item(0).dflag
                JeRowData.Item(i).EncumDate = JeRowData.Item(0).EncumDate
                JeRowData.Item(i).EntryDate = CDate(ent_Date.Text) 'JeRowData.Item(0).EntryDate
                JeRowData.Item(i).EntryType = JeRowData.Item(0).EntryType 'ent_type.SelectedItem.ToString 
                JeRowData.Item(i).JrnlName = JeRowData.Item(0).JrnlName 'jrnl_name.SelectedItem.ToString 
                JeRowData.Item(i).JrnlNum = CInt(jrnl_num.Text) 'JeRowData.Item(0).JrnlNum
                JeRowData.Item(i).JrnlSrc = JeRowData.Item(0).JrnlSrc 'jrnl_src.SelectedItem.ToString '
                JeRowData.Item(i).OperId = OperID.Text.ToString  'JeRowData.Item(0).OperId
                JeRowData.Item(i).Post = "N" 'JeRowData.Item(0).Post
                JeRowData.Item(i).PostDate = JeRowData.Item(0).PostDate
                JeRowData.Item(i).Void = "N" 'JeRowData.Item(0).Void
                JeRowData.Item(i).Agency = AgencyNum.ToString 'JeRowData.Item(0).Agency
            End If
        Next

        Call tot_amt()
        Dim msg As String = ""
        If total_amt <> 0 Then
            msg = "Journal Entry not in balance - Please Continue"
            GoTo notdone
        End If

        'acct nums  - 
        For Each JeRow In JeRowData
            ' Call etsacctnum_chk(JeRow.AcctNum, "", "", "")
            '  If valid_acct = "N" Then
            If etsacctnum_chk(JeRow.AcctNum) = "N" Then
                msg = "There is an invalid account.  Please edit and  then continue."
                GoTo notdone
                Exit Sub
            End If
        Next

        'check to see if all the data has been entered into the header
        msg = "Header incomplete.  Please complete."
        If Len(JeRowData.Item(0).JrnlName) = 0 Then GoTo notdone
        If Len(JeRowData.Item(0).JrnlSrc) = 0 Then GoTo notdone
        '  If Len(JeRowData.Item(0).OperId) = 0 Then GoTo notdone
        If Len(JeRowData.Item(0).JrnlNum) = 0 Then GoTo notdone
        If Len(JeRowData.Item(0).EntryType) = 0 Then GoTo notdone
        If Len(JeRowData.Item(0).EntryDate) = 0 Then GoTo notdone
        If Len(JeRowData.Item(0).EncumDate) = 0 Then GoTo notdone
        msg = ""

        'check detail lines - line numbers will be fixed here
        Dim inum As Integer = 1
        msg = "Detail lines not complete.  Please complete."
        For Each JeRow In JeRowData
            If Len(JeRow.AcctNum) = 0 Then GoTo notdone
            If Len(JeRow.Amount) = 0 Then GoTo notdone
            ' If Len(JeRow.JrnlDesc) = 0 Then GoTo notdone
            JeRow.JrnlLineNum = inum
            inum = inum + 1
        Next
        msg = ""
        'we now have a good array and if edit old data in data one
        Select Case entry_type
            Case "EDIT"
                If je_type = "STAND" Then
                    sqlstmnt = "delete from je_stand where jrnl_num = " & JeLookupNum
                    ETSSQL.ExecuteSQL(sqlstmnt)
                    'move data to sqlstmnt and insert
                    sqlstmnt = "insert into je_stand values ('"
                    Call GLMod.SQLJEDataString(sqlstmnt, JeRowData)
                    je_type = ""
                    Call CloseForm() 'Me.Close()
                End If
                If je_type = "REGULAR" Then
                    sqlstmnt = "delete from yrgenled where jrnl_num = " & JeLookupNum
                    Call ETSSQL.ExecuteSQL(sqlstmnt)
                    'move data to sqlstmnt and insert
                    sqlstmnt = "insert into yrgenled values ('"
                    Call GLMod.SQLJEDataString(sqlstmnt, JeRowData)
                    je_type = ""
                    Call CloseForm() 'Me.Close()
                End If
            Case "ADD"
                If je_type = "STAND" Then
                    'move data to sqlstmnt and insert
                    sqlstmnt = "insert into je_stand values ('"
                    Call GLMod.SQLJEDataString(sqlstmnt, JeRowData)
                    je_type = ""
                    Call CloseForm() 'Me.Close()
                End If
                If je_type = "REGULAR" Then
                    'move data to sqlstmnt and insert
                    sqlstmnt = "insert into yrgenled values ('"
                    Call GLMod.SQLJEDataString(sqlstmnt, JeRowData)
                    Response = MsgBox("Do you wish to enter another J/E?", MsgBoxStyle.YesNo)
                    If Response = MsgBoxResult.Yes Then
                        JeRowData.Clear()
                        'blank the grid
                        Dim linenum As Short
                        For linenum = 0 To 9
                            V_line(linenum).Text = ""
                            acct_num(linenum).Text = ""
                            acct_desc(linenum).Text = ""
                            line_Tot(linenum).Text = ""
                            jrnl_desc(linenum).Text = ""
                        Next

                        ' OperID.Text = ""
                        'enc_date.Text = ""
                        'ent_Date.Text = ""
                        vouchtotaldisplay.Text = ""

                        jrnl_num.Text = GLMod.GetNextJENum(entry_type).ToString
                        JeLookupNum = ""
                        JeRowData = ETSSQL.GetBlankJeData()
                        JeRowData.Item(0).JrnlNum = CInt(jrnl_num.Text)
                        JeRowData.Item(0).AcctNum = acct_num_blank
                        JeRowData.Item(0).JrnlLineNum = 1
                        repaint_grid(0)
                        Call EnterHeader()
                        jrnl_num.Enabled = True
                        enc_date.Enabled = True
                        Me.ActiveControl = jrnl_num
                        Exit Sub
                    End If
                End If

        End Select

        JeRowData.Clear()
        Call CloseForm()
        Exit Sub
notdone:
        MsgBox(msg)
        repaint_grid(0)
    End Sub

End Class
