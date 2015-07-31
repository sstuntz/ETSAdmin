Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Conversion
Imports System
Imports System.Diagnostics.Debug
Imports System.Data.SqlClient
Imports System.String
Imports System.Data.OleDb
Imports ETS.Common.Module1
Imports System.IO
Imports PS.Common
Imports ETS.clpr_mod

Public Class Import
    Inherits System.Windows.Forms.Form

    Public retpay As Double
    Public retpct As Double
    Public pay As Double
    Public pct As Double
    Public jobdata As List(Of String)
    Dim PayNum As Integer = CInt(ETSSQL.GetOneSQLValue("select top(1) pay_num as thevalue from ccckstub order by pay_num desc"))


    Private Sub Import_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get next payroll number
        'select all A (approved) items in timeline without a PR number

        PayrollNumber.Text = CStr(1) ' either first one or add one to max number
        PayrollNumber.Text = (PayNum + 1).ToString

    End Sub

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        Me.Dispose()
    End Sub

    Private Sub SigCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SigCheck.Click

        prtreportfilename = "Error.rpt"
        CrystalForm.ShowDialog()

        'report
    End Sub

    Private Sub DataCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataCheck.Click
        'move to timetmp
        ' valid cli job
        'valid avg hrly  -n namcc
        'hrs can not be 0
        MoveWebtoTemp()

        sqlstmnt = "update cctimetmp set errcode = 'NoHrS' where hours = 0 "
        ETSSQL.ExecuteSQL(sqlstmnt)

        sqlstmnt = "update cctimetmp set errcode = 'BadClijob where exists (select * from cctimetmp left outer join cc_clijob on (cctimetmp.name_key = cc_clijob.name_key and cctimetmp.job_num = cc_clijob.job_num) where cc_clijob.cl_pct IS NULL)"
        ETSSQL.ExecuteSQL(sqlstmnt)

        sqlstmnt = "update cctimetmp set errcode = 'NoAvgHrly where exists (select * from cctimetmp left outer join nam_cc on (cctimetmp.name_key = nam_cc.name_key)  where nam_cc.avg_hrly IS NULL or newnamecc.avghrly = 0)"
        ETSSQL.ExecuteSQL(sqlstmnt)

        MsgBox("Run the edit report before importing to correct errors.")


        'report
    End Sub

    Private Sub ImportSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportSheet.Click
        'move to eetime
        If MsgBox("This will populate the payroll and all changes must be made by Admin. Do you want to proceed?", MsgBoxStyle.YesNo) = vbNo Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor

        sqlstmnt = " insert into cctime "
        sqlstmnt = sqlstmnt & "( entry_date, pay_num, name_key, screen_nam, sort_name, pay_freq, ded_dfq, entry_num, line_num, date, job_num, pay_class, hours, pcs_prod, dept_num, pay_dol, cl_pct, chk_num, refusal, paid, checked, dflag, agency, void, glpost, encum_date, state_tax, jrnl_num, jrnl_line) "
        sqlstmnt = sqlstmnt & "select  entry_date, pay_num, name_key, screen_nam, sort_name, pay_freq, ded_dfq, entry_num, line_num, date, job_num, pay_class, hours, pcs_prod, dept_num, pay_dol, cl_pct, chk_num, refusal, paid, checked, dflag, agency, void, glpost, encum_date, state_tax, jrnl_num, jrnl_line from cctimetmp"
        ETSSQL.ExecuteSQL(sqlstmnt)

        MsgBox("Data Imported for Payroll number = " & PayrollNumber.Text)

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub MoveWebtoTemp()

        sqlstmnt = "delete from cctimetmp"
        ETSSQL.ExecuteSQL(sqlstmnt)

        sqlstmnt = "insert into cctimetmp (name_key,job_num,pcs_prod,[hours],[date])  select ClientID,ActivityCode,Pieces,[hours],LineDate from TimeLine where  (payrollnumber = '0' or payrollnumber is null)  and (linedate between '" & StartDate.Text & "' and '" & EndDate.Text & "')"
        ETSSQL.ExecuteSQL(sqlstmnt)
        Debug.Print(Today.TimeOfDay.ToString)
        sqlstmnt = "update cctimetmp set entry_date = convert(date,getdate()) , pay_num = '" & PayrollNumber.Text & "' where (pay_num = 0 or pay_num is NULL) "
        ETSSQL.ExecuteSQL(sqlstmnt)

        sqlstmnt = "update cctimetmp set cctimetmp.screen_nam = nam_cc.screen_nam, cctimetmp.sort_name = nam_cc.sort_name, cctimetmp.dept_num = nam_cc.dept_num, cctimetmp.pay_freq = nam_cc.pay_freq, cctimetmp.ded_dfq = nam_cc.pay_freq, cctimetmp.entry_num = '1'    FROM cctimetmp INNER JOIN  nam_cc ON cctimetmp.name_key = nam_Cc.name_key    where pay_num = '" & PayrollNumber.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        sqlstmnt = "update cctimetmp  set cctimetmp.pay_class = ccjob.pay_class  FROM cctimetmp INNER JOIN  ccjob ON cctimetmp.job_num = ccjob.job_num  where pay_num = '" & PayrollNumber.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        'make sure entries start with one for this person
        sqlstmnt = ";with cte as (select name_key, cctimetmp.date, pay_num, line_num, ROW_NUMBER() over (partition by name_key order by cctimetmp.date) as rownum from cctimetmp where pay_num = '" & PayrollNumber.Text & "' )"
        sqlstmnt = sqlstmnt & " update cte set line_num = rownum  "
        ETSSQL.ExecuteSQL(sqlstmnt)

        sqlstmnt = "update timeline set PayrollNumber = '" & PayrollNumber.Text & "' where  linedate between '" & StartDate.Text & "' and '" & EndDate.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        Dim WeekSheets As List(Of cctimeData) = ETSSQLCC.GetCCTimeData("SELECT * from cctimetmp where pay_num = '" & PayrollNumber.Text & "' order by name_key,line_num")

        For num As Integer = 0 To WeekSheets.Count - 1
            Dim OneNameCC As New NameCCData
            OneNameCC = ETSSQLCC.GetOneNameCCData("select * from nam_cc where name_key = '" & WeekSheets.Item(num).NameKey & "'")
            Dim jobdata As List(Of String)
            jobdata = etsjobnum_chk(WeekSheets.Item(num).JobNum)
            If jobdata(0) <> "N" Then
                WeekSheets.Item(num).PayClass = jobdata(1).ToString

                Dim paynums As List(Of Decimal)
                paynums = calc_cc_pay(WeekSheets.Item(num).JobNum, WeekSheets.Item(num).PayClass, CInt(WeekSheets.Item(num).PcsProd), WeekSheets.Item(num).Hours, WeekSheets.Item(num).NameKey, CDec(0.0), CDec(0.0))

                If WeekSheets.Item(num).DeptNum = "NN" Then
                    paynums(0) = 0
                    paynums(1) = 0
                End If

                WeekSheets.Item(num).PayDol = paynums(0)
                WeekSheets.Item(num).ClPct = paynums(1)
                sqlstmnt = "update cctimetmp set pay_dol = '" & paynums(0) & "' , cl_pct = '" & paynums(1) & "' where name_key = '" & WeekSheets.Item(num).NameKey & "' and line_num = '" & WeekSheets.Item(num).LineNum & "' and pay_num = '" & PayrollNumber.Text & "'"

                'sqlstmnt = "update cctime set pay_dol = '" & paynums(0) & "' , cl_pct = '" & paynums(1) & "' where name_key = '" & WeekSheets.Item(num).NameKey & "' and line_num = '" & WeekSheets.Item(num).LineNum & "' and pay_num = '" & PayrollNumber.Text & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
                If WeekSheets.Item(num).PayClass = "NO" And WeekSheets.Item(num).PayDol <> 0 Then
                    MsgBox(" name = " & WeekSheets.Item(num).NameKey & " line = " & WeekSheets.Item(num).LineNum & "Please edit their timecard.  There is a no pay problem.")
                End If

            Else
                MsgBox("Invalid job number " & WeekSheets.Item(num).JobNum & " in the web files.  Please fix before import.")
                Exit Sub
            End If

        Next

        'temp fix
        'Dim WeekSheets As List(Of cctimeData) = ETSSQLCC.GetCCTimeData("SELECT * from cctime where [date] between  '3/22/2015' and '5/23/2015' and void = 'N'  order by name_key,line_num")

        ''   Dim WeekSheets As List(Of cctimeData) = ETSSQLCC.GetCCTimeData("SELECT * from cctime where pay_num = '" & PayrollNumber.Text & "' order by name_key,line_num")

        'For num As Integer = 0 To WeekSheets.Count - 1
        '    Dim OneNameCC As New NameCCData
        '    OneNameCC = ETSSQLCC.GetOneNameCCData("select * from nam_cc where name_key = '" & WeekSheets.Item(num).NameKey & "'")
        '    Dim jobdata As List(Of String)
        '    jobdata = etsjobnum_chk(WeekSheets.Item(num).JobNum)
        '    If jobdata(0) <> "N" Then
        '        WeekSheets.Item(num).PayClass = jobdata(1).ToString

        '        Dim paynums As List(Of Decimal)
        '        paynums = calc_cc_pay(WeekSheets.Item(num).JobNum, WeekSheets.Item(num).PayClass, CInt(WeekSheets.Item(num).PcsProd), WeekSheets.Item(num).Hours, WeekSheets.Item(num).NameKey, CDec(0.0), CDec(0.0))

        '        If WeekSheets.Item(num).DeptNum = "NN" Then
        '            paynums(0) = 0
        '            paynums(1) = 0
        '        End If

        '        WeekSheets.Item(num).PayDol = paynums(0)
        '        WeekSheets.Item(num).ClPct = paynums(1)
        '        sqlstmnt = "update cctime set pay_dol = '" & paynums(0) & "' , cl_pct = '" & paynums(1) & "' where name_key = '" & WeekSheets.Item(num).NameKey & "' and line_num = '" & WeekSheets.Item(num).LineNum & "' and pay_num = '" & WeekSheets.Item(num).PayNum & "'"

        '        'sqlstmnt = "update cctime set pay_dol = '" & paynums(0) & "' , cl_pct = '" & paynums(1) & "' where name_key = '" & WeekSheets.Item(num).NameKey & "' and line_num = '" & WeekSheets.Item(num).LineNum & "' and pay_num = '" & PayrollNumber.Text & "'"
        '        ETSSQL.ExecuteSQL(sqlstmnt)
        '        If WeekSheets.Item(num).PayClass = "NO" And WeekSheets.Item(num).PayDol <> 0 Then
        '            MsgBox(" name = " & WeekSheets.Item(num).NameKey & " line = " & WeekSheets.Item(num).LineNum & "Please edit their timecard.  There is a no pay problem.")
        '        End If

        '    Else
        '        MsgBox("Invalid job number " & WeekSheets.Item(num).JobNum & " in the web files.  Please fix before import.")
        '        Exit Sub
        '    End If

        'Next

        Me.Cursor = Cursors.Default


    End Sub

    Private Sub PayrollNumber_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PayrollNumber.Enter
        PayrollNumber.BackColor = Color.Aqua
        PayrollNumber.SelectAll()
    End Sub

    Private Sub PayrollNumber_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles PayrollNumber.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            If CDbl(PayrollNumber.Text) > PayNum + 2 Then
                MsgBox("You can not enter such a high payroll number.")
                Exit Sub
            Else
                If CDbl(PayrollNumber.Text) < PayNum + 1 Then
                    MsgBox("Pay roll number has be paid. Use another number")
                    Exit Sub
                End If

            End If

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_num1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PayrollNumber.Leave
        PayrollNumber.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub ProcessEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles StartDate.Enter, EndDate.Enter, CheckDate.Enter
        DirectCast(sender, TextBox).SelectAll()
        DirectCast(sender, TextBox).BackColor = Color.Aqua
    End Sub

    Private Sub ProcessLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles StartDate.Leave, EndDate.Leave, CheckDate.Leave
        DirectCast(sender, TextBox).BackColor = Color.White
    End Sub

    Private Sub process_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles StartDate.KeyPress, EndDate.KeyPress, CheckDate.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            ' Select Case DirectCast(eventSender, TextBox).Name
            DirectCast(eventSender, TextBox).Text = LTrim(RTrim(DirectCast(eventSender, TextBox).Text))
            If DirectCast(eventSender, TextBox).Text.Length = 0 Then
                MsgBox("You must enter a date.")
                GoTo EventExitSub
            End If
            Dim retdate As String = ETS.Common.Module1.etsdate(DirectCast(eventSender, TextBox).Text, "N")
            If retdate = "N" Then
                DirectCast(eventSender, TextBox).Text = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                DirectCast(eventSender, TextBox).SelectAll()
                GoTo EventExitSub
            Else
                DirectCast(eventSender, TextBox).Text = CDate(retdate).ToShortDateString
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

    
End Class