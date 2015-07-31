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
Imports Valid_YN
Imports ETS

Public Class frmglalloc
    Inherits System.Windows.Forms.Form
    Dim sou As String
    Public JeRowData As List(Of JeData)

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Public Sub rebuild_grid()

        Dim sql As String = "SELECT    alloc.acct_num, alloc.amount, alloc.[table], chacct.acct_desc, alloc.factor FROM   alloc INNER JOIn chacct ON alloc.acct_num = chacct.acct_num"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)

    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click

        '1 this zero's amt in alloc
        sqlstmnt = "update alloc set amount = 0"
        ETSSQL.ExecuteSQL(sqlstmnt)

        '2 select data from yrgenled
        sqlstmnt = "select * From yrgenled  "
        sqlstmnt = sqlstmnt & " where ((yrgenled.encum_date) between "
        sqlstmnt = sqlstmnt & Chr(35) & txtField1(1).Text & Chr(35) & " And "
        sqlstmnt = sqlstmnt & Chr(35) & txtField2(2).Text & Chr(35)
        sqlstmnt = sqlstmnt & " ) and (yrgenled.dflag <> 'Y')"
        sqlstmnt = sqlstmnt & " and (yrgenled.a_post <> 'Y')"
        sqlstmnt = sqlstmnt & " and (yrgenled.amount <> 0)"
        sqlstmnt = sqlstmnt & "and (yrgenled.post <> 'Y')"
        sqlstmnt = sqlstmnt & " and (mid(yrgenled.acct_num,9,2) = '" & txtField0(0).Text & "')"
        sqlstmnt = sqlstmnt & " order by left(yrgenled.acct_num,4) "

        If ETS.Common.Module1.CheckRecordCount(sqlstmnt) = 0 Then
            MsgBox("The records for these dates have been posted to the GL!")
            Exit Sub
        End If

        'Second add set selected to array...2 fields: acct_only..amount
        'summed by acct_only(yrgenled) total on amount(yrgenled)

        Select Case txtField0(0).Text
            Case "55"       'added for berk
                '	Do While Not yrgenled.Recordset.EOF
                '		amount_tot = amount_tot + yrgenled.Recordset.Fields("amount").Value
                '		yrgenled.Recordset.MoveNext()
                '	Loop 
                '	old_acct = "5900"
                '	alloc_array(n, 0) = old_acct
                '	alloc_array(n, 1) = amount_tot
            Case Else
                'other dept numbers
                'create the sql stmnt that does the allocation
                'first the totals then the factor
                sqlstmnt = "update alloc set amount =  derivedtbl_1.TotAmt "
                sqlstmnt = sqlstmnt & " FROM (SELECT SUM(amount) AS TotAmt FROM yrgenled"
                sqlstmnt = sqlstmnt & " GROUP BY acct_only, void, dflag, post, encum_date) "
                sqlstmnt = sqlstmnt & " HAVING (post <> N'Y') AND (dflag <> N'Y') AND (void <> N'Y') "
                sqlstmnt = sqlstmnt & " and encum_date between "
                sqlstmnt = sqlstmnt & Chr(35) & txtField1(1).Text & Chr(35) & " And "
                sqlstmnt = sqlstmnt & Chr(35) & txtField2(2).Text & Chr(35) & ") AS derivedtbl_1 CROSS JOIN alloc"
                ETSSQL.ExecuteSQL(sqlstmnt)

                sqlstmnt = "update alloc set amount = round(amount* factor,2)"
                ETSSQL.ExecuteSQL(sqlstmnt)

        End Select

        MsgBox("Allocation Complete. Print Allocation Report. ")

    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glalloc1.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        '*****first need to test to be sure alloc table is in balance
        '
        'need to select data from alloc sorted by acct_num and write out the debit side of je
        'then we need to write out the credit side of j/e

        'check alloc table for valid acct nums
        sqlstmnt = "select * from alloc where alloc.amount <> 0  order by acct_num "
        Dim AcctSplit As String()
        AcctSplit = GLMod.CheckJeData(sqlstmnt).Split(CChar("*"))
        Select Case AcctSplit(0)
            Case "N"
                'ok
            Case "T"
                MsgBox("You need to edit the allocation table.")
                Command2.Focus()
                Exit Sub
            Case "Y"
                MsgBox("You need to edit the allocation table.")
                Command2.Focus()
                Exit Sub
        End Select

        ''*****
        Dim nextjenum As Integer
        nextjenum = GLMod.GetNextJENum("Regular")
        nextjenum = nextjenum + 1

        MsgBox("Note the J/E# on your Worksheet: " & nextjenum)

        JeRowData = ETSSQL.GetBlankJeData()
        'JeRowData.Item(0).JrnlNum = CInt(jrnl_num.Text)
        'JeRowData.Item(0).AcctNum = acct_num_blank
        'JeRowData.Item(0).JrnlName = CStr(jrnl_name.SelectedItem)

        ''	gljrnlset.Fields("jrnl_num").Value = next_je_num
        '	gljrnlset.Fields("jrnl_line").Value = n + 1
        '	n = n + 1
        '	gljrnlset.Fields("entry_type").Value = "SD"
        '	gljrnlset.Fields("jrnl_name").Value = "JE"
        '	gljrnlset.Fields("jrnl_src").Value = "AL"
        '	gljrnlset.Fields("entry_date").Value = Today
        '	gljrnlset.Fields("encum_date").Value = txtField2(2).Text
        '	gljrnlset.Fields("acct_num").Value = allocset.Fields("acct_num").Value
        '	gljrnlset.Fields("amount").Value = allocset.Fields("amount").Value
        '	gljrnlset.Fields("jrnl_desc").Value = "Allocation-" & txtField0(0).Text

        sqlstmnt = "insert into yrgenled values ('"
        Call GLMod.SQLJEDataString(sqlstmnt, JeRowData)
        ETSSQL.ExecuteSQL(sqlstmnt)



        sqlstmnt = "update yrgenled set a_post = 'Y' where "
        sqlstmnt = sqlstmnt & " ((yrgenled.encum_date) between "
        sqlstmnt = sqlstmnt & Chr(35) & txtField1(1).Text & Chr(35) & " And "
        sqlstmnt = sqlstmnt & Chr(35) & txtField2(2).Text & Chr(35)
        sqlstmnt = sqlstmnt & " ) and (yrgenled.dflag <> 'Y')"
        sqlstmnt = sqlstmnt & " and (yrgenled.a_post <> 'Y')"
        sqlstmnt = sqlstmnt & " and (yrgenled.amount <> 0)"
        sqlstmnt = sqlstmnt & "and (yrgenled.post <> 'Y')"
        sqlstmnt = sqlstmnt & " and (mid(yrgenled.acct_num,9,2) = '" & txtField0(0).Text & "')"
        ETSSQL.ExecuteSQL(sqlstmnt)

    End Sub

    Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glalcje.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Command5_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command5.Click
        ''recalculate the total on the screen

        Dim total_amt As Decimal = GLMod.GetTotalAllocation

        Text1.Text = String.Format("{0:c}", total_amt) 'VB6.Format(total_amt, "$#,##0.00;($#,##0.00)")

        ''need message here if total_amt <> 0

        If total_amt <> 0 Then
            MsgBox("Check the figures..Allocation total <> 0 ")
            MsgBox("Reprint the Allocation Report")
            Command2.Focus()
        End If


    End Sub

    Private Sub frmglalloc_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtField0_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField0.Enter
        Dim Index As Short = txtField0.GetIndex(CType(eventSender, TextBox))
        txtField0(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        txtField0(Index).SelectionStart = 0
        txtField0(Index).SelectionLength = Len(txtField0(Index).Text)

    End Sub

    Private Sub txtField0_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField0.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField0.GetIndex(CType(eventSender, TextBox))
        On Error Resume Next
        If KeyAscii = 13 Then

            If Len(txtField0(0).Text) = 0 Then
                MsgBox("Please enter a Dept Number")
                Call ets_set_selected() 'puts the color in the box
                GoTo EventExitSub
            End If
            txtField1(1).Focus()
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtField0_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField0.Leave
        Dim Index As Short = txtField0.GetIndex(CType(eventSender, TextBox))
        Call ets_de_selected()
        txtField0(0).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub txtField1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField1.Enter
        Dim Index As Short = txtField1.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtField1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField1.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            valid_Date = "N"
            senddate = txtField1(1).Text
            Call etsdate(senddate, valid_Date)

            If valid_Date <> "N" Then
                txtField1(1).Text = CStr(valid_Date)
                txtField1(1).Text = CStr(CDate(txtField1(1).Text))
                'update headings  - beg date
                sqlstmnt = "update rpthead set beg_date = '" & valid_Date & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
                txtField2(2).Focus()
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

    Private Sub txtField1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField1.Leave
        Dim Index As Short = txtField1.GetIndex(CType(eventSender, TextBox))
        txtField1(1).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub txtField2_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField2.Enter
        Dim Index As Short = txtField2.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtField2_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField2.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField2.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            valid_Date = "N"
            senddate = txtField1(1).Text
            Call etsdate(senddate, valid_Date)

            If valid_Date <> "N" Then
                txtField1(1).Text = CStr(valid_Date)
                txtField1(1).Text = CStr(CDate(txtField1(1).Text))
                'update headings  - beg date
                sqlstmnt = "update rpthead set end_date = '" & valid_Date & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
                txtField2(2).Focus()
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

    Private Sub txtField2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtField2.Leave
        Dim Index As Short = txtField2.GetIndex(CType(eventSender, TextBox))
        txtField2(2).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

End Class