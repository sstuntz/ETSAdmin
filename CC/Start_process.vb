Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ps.common
Imports ETS.Common.Module1
Imports System.Configuration
Imports System.Data.SqlClient
Imports ETS.pr_common
Imports ETS.stpr_mod
Imports ETS.clpr_mod

Public Class start_process
    Inherits System.Windows.Forms.Form
    '****************
    'revision History
    'original date of this form is 9/23/96 -SCS
    '10/28/2008 lhw standard form
    ' single check is handled by deleting all the others if only one check wanted
    'this is easier than making all the sql statement either all or by name key = to

    '****************
    Public fica_bal As Decimal
    Public med_bal As Decimal
    Public makeup_pay_amt As Decimal
    Public tmp_last_chk_num As Integer
    Public formdone As Boolean = False

    Public Sub blank_cktmp()
        Using db As Database = New Database(top_data_path)
            db.ExecuteQuery("delete cccktmp")
        End Using
    End Sub

    Private Sub beg_chk_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles beg_chk_num.Enter
        Call ets_set_selected()
    End Sub

    Private Sub beg_chk_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles beg_chk_num.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            'check number must be greter than any check number used
            valid_check = prchknumverify(CInt(beg_chk_num.Text))
            If valid_check = "N" Then
                MsgBox("Check number has been used.  Please enter another.")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            'last check for negative pay
            sqlstmnt = "select * from cccktmp where net_pay < 0 "
            intcount = 0
            Using db As Database = New Database(top_data_path)
                Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
                While rs.Read()
                    intcount = intcount + 1
                End While
                rs.Close()
            End Using

            If intcount <> 0 Then
                MsgBox("There is a negative payment amount. It will need to be corrected before proceeding.  Check your edit.")
                GoTo EventExitSub
            End If

            end_Date.Focus()
            KeyAscii = 0

        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub beg_chk_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles beg_chk_num.Leave
        Call ets_de_selected()
        beg_chk_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Close()

    End Sub

    Private Sub end_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles end_Date.Enter
        Call ets_set_selected()

    End Sub

    Private Sub end_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles end_Date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = end_Date.Text
            valid_Date = etsdate(senddate, valid_Date)

            If valid_Date = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                end_Date.Text = valid_Date
                end_Date.Text = CStr(CDate(end_Date.Text))

            End If

            If CDbl(num_cks.Text) > 0 Then
                prt_Chk.Enabled = True
                prt_Chk.Focus()
                KeyAscii = 0
            Else
                MsgBox("There are no checks to print.")
                Cancel.Focus()
            End If
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub start_process_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        sys_Date.Text = CStr(Date.Today)   ', "short date") 'medium to short 2002

        ctrform(Me)
        Dim intcount As Integer = 0

        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery("select  top 1 Pay_num from cctime where paid = 'Y' and void = 'N' order by pay_num desc")
            While rs.Read()
                pr_num = CInt(Val(rs("pay_num")) + 1)
                intcount = intcount + 1
            End While
            rs.Close()
        End Using

        If intcount = 0 Then
            pr_num = 1
        End If

        Pr_num1.Text = CStr(pr_num)

        formdone = True

    End Sub

    Private Sub pr_Start_date1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_Start_date1.Enter
        Dim YNCount As Integer = 0
        sqlstmnt = "delete from cccktmp"
        ETSSQL.ExecuteSQL(sqlstmnt)

        Call ets_set_selected()

    End Sub

    Private Sub pr_Start_date1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles pr_Start_date1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            valid_Date = "N"
            senddate = pr_Start_date1.Text
            valid_Date = etsdate(senddate, valid_Date)
            If valid_Date = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                retdate = CDate(valid_Date)
                pr_Start_date = CDate(retdate)
                pr_Start_date1.Text = CStr(retdate)
                pr_Start_date1.Text = CStr(CDate(pr_Start_date1.Text))
                present_quarter_num = DatePart(Microsoft.VisualBasic.DateInterval.Quarter, pr_Start_date)
                Process.Enabled = True
                System.Windows.Forms.SendKeys.Send("{TAB}")
                KeyAscii = 0
            End If
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub pr_Start_date1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles pr_Start_date1.Leave
        Call ets_de_selected()
        pr_Start_date1.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub Process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Click
        'we now find the present quarter that we are working on
        'we emtpy the ytd table and refill it up to current information
        Call ytd_create(0)
        selected_name_key = Trim(selected_name_key)
        'we create a blank check temp table that will hold it all until
        'the checks have been printed at which time it goes to chkstb
        '1clear cktmp

        Using db As Database = New Database(top_data_path)
            Dim sql As String = "delete from cccktmp"
            db.ExecuteQuery(sql)
        End Using

        Using db As Database = New Database(top_data_path)
            Dim sql As String = "   with cte as (SELECT line_num, pay_num, name_key, entry_num, row_number() OVER (partition by name_key,entry_num ORDER BY name_key, entry_num) AS row FROM cctime where pay_num = '" & Pr_num1.Text & "')  update cte set line_num = row"
            db.ExecuteQuery(sql)
        End Using
            'a different entry num creates a second record and is treated as a separate employee (for creating 2 checks in one payroll)

            If single_pr.Checked Then 'single check payroll
                sqlstmnt = "select distinct name_key, entry_num from cctime where (paid = 'N' or paid = 'S') and void = 'N' and pay_num = '" & Pr_num1.Text & "'  and name_key = '"
                sqlstmnt = sqlstmnt & selected_name_key & "' order by name_key,entry_num"
            Else
                sqlstmnt = "select distinct name_key, entry_num from cctime where (paid = 'N' or paid = 'S') and void = 'N' and pay_num = '" & Pr_num1.Text & "' order by name_key,entry_num"
            End If

            Dim YNCount As Integer = 0
            Dim empcount As Integer = 0
            Using db As Database = New Database(top_data_path)
                Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
                While rs.Read()
                    YNCount = YNCount + 1
                    If Val(rs("entry_num")) = 1 Then
                        empcount = empcount + 1
                    End If
                End While
                rs.Close()
            End Using

            If YNCount = 0 Then
                MsgBox("There are no records to process.")
                Me.Close()
                Exit Sub
            Else
                num_cks.Text = YNCount.ToString
                num_emp.Text = empcount.ToString
            End If

            'make all the OO and NO payclass records as paid with an S so can set check number later
            ' a whole series of sql commands all within this using
            '  Using db As Database = New Database(top_data_path)
            '  Dim sql As String = sqlstmnt
            ' db.ExecuteQuery(sql)


            If single_pr.Checked Then 'single check payroll
                sqlstmnt = "update cctime set paid = 'S' where paid = 'N' and void = 'N' and pay_num = '" & Pr_num1.Text & "'"
                sqlstmnt = sqlstmnt & " and (pay_class = 'OO' or pay_class = 'NO') and name_key = '" & Trim(selected_name_key) & "'"
            Else
                sqlstmnt = "update cctime set paid = 'S' where paid = 'N' and void = 'N' and pay_num = '" & Pr_num1.Text & "' "
                sqlstmnt = sqlstmnt & " and (pay_class = 'OO' or pay_class = 'NO')"
            End If

            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                db.ExecuteUpdate(sqlstmnt)
                '  End Using

                ' num_emp.Text = CStr(0)
                '  num_cks.Text = CStr(0)

                '2creates the basic record which is then filled

            If single_pr.Checked Then 'single check payroll
                sqlstmnt = " INSERT INTO cccktmp (name_key,entry_num) SELECT  name_key,  entry_num FROM cctime WHERE (paid = 'N') AND (void = 'N') AND (pay_num = '" & Pr_num1.Text & "' )"
                sqlstmnt = sqlstmnt & " and name_key = '" & Trim(selected_name_key) & " ' GROUP BY name_key, entry_num"
            Else
                sqlstmnt = " INSERT INTO cccktmp (name_key,entry_num) SELECT  name_key,  entry_num FROM cctime WHERE (paid = 'N') AND (void = 'N') AND (pay_num = '" & Pr_num1.Text & "' ) GROUP BY name_key, entry_num"
            End If
            db.ExecuteUpdate(sqlstmnt)

            'fills from nam cc
            sqlstmnt = "Update cccktmp SET fwt_exmts = nam_cc.fwt_exmts, swt_exmts = nam_cc.swt_exmts, dept_num = nam_cc.dept_num, disab_num = nam_cc.disab_num, fund_code = nam_cc.fund_code, sort_name = nam_cc.sort_name, screen_nam = nam_cc.screen_nam, state1_code = nam_cc.state1_tax, desc1 = nam_cc.desc1, desc2 = nam_cc.desc2, desc3 = nam_cc.desc3,chk_dirdep = nam_cc.ddep_net "
                sqlstmnt = sqlstmnt & "  FROM nam_cc, cccktmp WHERE nam_cc.name_key = cccktmp.name_key "
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = "UPDATe cccktmp SET pay_num = cctime.pay_num, pay_freq = cctime.pay_freq, ded_dfq = cctime.ded_dfq "
                sqlstmnt = sqlstmnt & " FROM  cctime, cccktmp where cctime.name_key = cccktmp.name_key and cctime.pay_num = '" & Pr_num1.Text & "'"

                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = " Update cccktmp set chk_Date = '" & pr_Start_date & "' , encum_date = '" & pr_Start_date & "' "
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = "update cccktmp set recon = 'Y', r_date = '" & pr_Start_date & "' where chk_dirDep = 'Y' "
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = "UPDATE cccktmp SET dduct1_dol = nam_cc.dduct1_dol, dduct1_num = nam_cc.dduct1_num from nam_cc, cccktmp  where(nam_cc.name_key = cccktmp.name_key) and cccktmp.ded_dfq = nam_cc.dduct1_dfq"
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = "UPDATE cccktmp SET dduct2_dol = nam_cc.dduct2_dol, dduct2_num = nam_cc.dduct1_num from nam_cc, cccktmp  where(nam_cc.name_key = cccktmp.name_key) and cccktmp.ded_dfq = nam_cc.dduct2_dfq"
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = "UPDATE cccktmp SET dduct3_dol = nam_cc.dduct3_dol, dduct3_num = nam_cc.dduct3_num from nam_cc, cccktmp  where(nam_cc.name_key = cccktmp.name_key) and cccktmp.ded_dfq = nam_cc.dduct3_dfq"
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = "UPDATE cccktmp SET dduct4_dol = nam_cc.dduct4_dol, dduct4_num = nam_cc.dduct4_num from nam_cc, cccktmp  where(nam_cc.name_key = cccktmp.name_key) and cccktmp.ded_dfq = nam_cc.dduct4_dfq"
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = "UPDATE cccktmp SET add_fwt = nam_cc.add_fwt from nam_cc, cccktmp  where(nam_cc.name_key = cccktmp.name_key) and cccktmp.ded_dfq = nam_cc.addfwt_dfq"
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = "UPDATE cccktmp SET add_swt = nam_cc.add_swt from nam_cc, cccktmp  where(nam_cc.name_key = cccktmp.name_key) and cccktmp.ded_dfq = nam_cc.addswt_dfq"
                db.ExecuteUpdate(sqlstmnt)

                'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

                sqlstmnt = " update cccktmp set ind_hrs = shours, ind_dol = sdol from (SELECT  name_key, SUM(hours) AS shours, SUM(pay_dol) AS sdol FROM cctime"
            sqlstmnt = sqlstmnt & " WHERE (paid <> 'Y') AND (void = 'N') AND (pay_num = '" & Pr_num1.Text & "' ) and pay_class in ('IH','IP','SI','IF','SP' )"
                sqlstmnt = sqlstmnt & " GROUP BY name_key ) as tbl left join cccktmp on cccktmp.name_key = tbl.name_key "
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = " update cccktmp set stipend = sdol from (SELECT  name_key, SUM(hours) AS shours, SUM(pay_dol) AS sdol FROM cctime"
            sqlstmnt = sqlstmnt & " WHERE (paid <> 'Y') AND (void = 'N') AND (pay_num = '" & Pr_num1.Text & "' ) and pay_class in ('ST')"
                sqlstmnt = sqlstmnt & " GROUP BY name_key ) as tbl left join cccktmp on cccktmp.name_key = tbl.name_key "
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = " update cccktmp set no_pay_hrs = shours from (SELECT  name_key, SUM(hours) AS shours, SUM(pay_dol) AS sdol FROM cctime"
            sqlstmnt = sqlstmnt & " WHERE (paid <> 'Y') AND (void = 'N') AND (pay_num = '" & Pr_num1.Text & "' ) and pay_class in ('NO')"
                sqlstmnt = sqlstmnt & " GROUP BY name_key ) as tbl left join cccktmp on cccktmp.name_key = tbl.name_key "
                db.ExecuteUpdate(sqlstmnt)

                'Case Else 'direct hours - already have total hours so just subtract them
            sqlstmnt = " update cccktmp set dir_hrs = shours, dir_dol = sdol from (SELECT  name_key, SUM(hours) AS shours, SUM(pay_dol) AS sdol FROM cctime"
            sqlstmnt = sqlstmnt & " WHERE (paid <> 'Y') AND (void = 'N') AND (pay_num = '" & Pr_num1.Text & "' ) and pay_class not in ('IH','IP','SI','IF','SP','ST','NO' )"
                sqlstmnt = sqlstmnt & " GROUP BY name_key ) as tbl left join cccktmp on cccktmp.name_key = tbl.name_key "
                db.ExecuteUpdate(sqlstmnt)

                'xxxxxxxxxxxxxxxxxxxxx
                'now same thing for job number
            '        Case "81808"  vacation
                sqlstmnt = " update cccktmp set vac_hrs = shours, vac_dol = sdol from (SELECT  name_key, SUM(hours) AS shours, SUM(pay_dol) AS sdol FROM cctime"
            sqlstmnt = sqlstmnt & " WHERE (paid <> 'Y') AND (void = 'N') AND (pay_num = '" & Pr_num1.Text & "' ) and (job_num = '81808' )"
                sqlstmnt = sqlstmnt & " GROUP BY name_key ) as tbl left join cccktmp on cccktmp.name_key = tbl.name_key "
                db.ExecuteUpdate(sqlstmnt)

            '    Case "82801"  sick
                sqlstmnt = " update cccktmp set sick_hrs = shours, sick_dol = sdol from (SELECT  name_key, SUM(hours) AS shours, SUM(pay_dol) AS sdol FROM cctime"
            sqlstmnt = sqlstmnt & " WHERE (paid <> 'Y') AND (void = 'N') AND (pay_num = '" & Pr_num1.Text & "' ) and (job_num = '82801' )"
                sqlstmnt = sqlstmnt & " GROUP BY name_key ) as tbl left join cccktmp on cccktmp.name_key = tbl.name_key "
                db.ExecuteUpdate(sqlstmnt)

            'Case "83801"  hol
                sqlstmnt = " update cccktmp set hol_hrs = shours, hol_dol = sdol from (SELECT  name_key, SUM(hours) AS shours, SUM(pay_dol) AS sdol FROM cctime"
            sqlstmnt = sqlstmnt & " WHERE (paid <> 'Y') AND (void = 'N') AND (pay_num = '" & Pr_num1.Text & "' ) and (job_num = '83801' )"
                sqlstmnt = sqlstmnt & " GROUP BY name_key ) as tbl left join cccktmp on cccktmp.name_key = tbl.name_key "
                db.ExecuteUpdate(sqlstmnt)

            '    Case "88887"-  minimum

                sqlstmnt = " update cccktmp set  minimum = sdol from (SELECT  name_key, SUM(hours) AS shours, SUM(pay_dol) AS sdol FROM cctime"
            sqlstmnt = sqlstmnt & " WHERE (paid  <> 'Y') AND (void = 'N') AND (pay_num = '" & Pr_num1.Text & "' ) and (job_num = '88887' )"
                sqlstmnt = sqlstmnt & " GROUP BY name_key ) as tbl left join cccktmp on cccktmp.name_key = tbl.name_key "
                db.ExecuteUpdate(sqlstmnt)

                'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

                'we calculate the gross pays and the blended ot rate if used by the agency
                'true gross is the sum of all the dollars
                sqlstmnt = " Update cccktmp  set cccktmp.full_gross = cccktmp.dir_dol + cccktmp.ind_dol, cccktmp.fed_gross =cccktmp.dir_dol + cccktmp.ind_dol"
                db.ExecuteUpdate(sqlstmnt)
                'End Using

                'get various agency settings from ccsys
                Dim taxstipendYN As String = "N"
                Dim taxmakeupYN As String = "N"
                Dim minckamt As Decimal = 0 '0 depend on minckdfq  <> W
                Dim taxminYN As String = "N"
                Dim makeuprate As Decimal = 0
                '  Using db As Database = New Database(top_data_path)
                Dim rs As SqlDataReader = db.ExecuteQuery("select * from ccsys")
                While rs.Read()
                    taxstipendYN = rs("tax_stipend").ToString
                    minckamt = CDec(rs("min_ck_amt").ToString)
                    taxminYN = rs("tax_minimum").ToString
                    makeuprate = CDec(rs("makeup_rate").ToString)
                    taxmakeupYN = rs("tax_makeup").ToString
                End While
                rs.Close()
                'End Using

                If taxstipendYN = "N" Then
                    sqlstmnt = " Update cccktmp  set cccktmp.fed_gross = cccktmp.full_gross - cccktmp.stipend"
                    db.ExecuteUpdate(sqlstmnt)
                End If

                Dim minckamtyn As String = "N"
                If minckamt <> 0 Then
                    minckamtyn = "Y"
                End If

                'calculate makeup pay - 

                sqlstmnt = " update cccktmp set makeup = tbl.shours *'" & makeuprate & "' - tbl.spay"
                sqlstmnt = sqlstmnt & "  FROM         cccktmp INNER JOIN  (SELECT     name_key, SUM(hours) AS shours, SUM(pay_dol) AS spay"
                sqlstmnt = sqlstmnt & " FROM cctime WHERE (pay_class = 'PC') AND (void = N'N') AND (paid = N'N')"
                sqlstmnt = sqlstmnt & " GROUP BY name_key) AS tbl ON cccktmp.name_key = tbl.name_key INNER JOIN nam_cc ON cccktmp.name_key = nam_cc.name_key"
                sqlstmnt = sqlstmnt & "   WHERE     (nam_cc.makeup = N'Y')"
                db.ExecuteUpdate(sqlstmnt)

                '    If makeup_pay_amt < 0 Then makeup_pay_amt = 0
                sqlstmnt = " update cccktmp set makeup = 0 where makeup < 0 "
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = " update cccktmp set full_gross = full_gross + makeup"
                db.ExecuteUpdate(sqlstmnt)

                'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

                'chk if makeup is taxable
                If taxmakeupYN = "Y" Then
                    sqlstmnt = " Update cccktmp  set cccktmp.fed_gross = cccktmp.full_gross + cccktmp.makeup"
                    db.ExecuteUpdate(sqlstmnt)
                End If

                'calculate min check amount
                If minckamtyn = "Y" Then
                    sqlstmnt = " Update cccktmp  set minimum = '" & minckamt & "' - cccktmp.full_gross,  cccktmp.full_gross = convert(money, '" & minckamt & "') from cccktmp AS cccktmp_1 CROSS JOIN cccktmp WHERE (cccktmp.full_gross <'" & minckamt & "') AND (cccktmp.desc3 = 'MIN')"
                    db.ExecuteUpdate(sqlstmnt)
                End If

                'chk if min check is taxable 
                If taxminYN = "N" Then
                    sqlstmnt = " Update cccktmp  set cccktmp.fed_gross = cccktmp.full_gross - cccktmp.minimum"
                    db.ExecuteUpdate(sqlstmnt)
                End If

                'XXXXXXXXXXXXXXXXXXXXXX
                Dim fica_pct As Decimal = 0
                Dim fica_bal As Decimal = 0
                Dim med_bal As Decimal = 0
                Dim med_pct As Decimal = 0
                Dim fwt_exmpt As Decimal = 0
                Dim swt_exmpt As Decimal = 0

                '  Using db As Database = New Database(top_data_path)
                '  Dim rs As SqlDataReader = db.ExecuteQuery("select * from taxtbl")
                rs = db.ExecuteQuery("select * from taxtbl")
                While rs.Read()
                    fica_bal = CDec(rs("fica_max"))
                    med_bal = CDec(rs("med_max"))
                    fica_pct = CDec(rs("fica_pct"))
                    med_pct = CDec(rs("med_pct"))
                    fwt_exmpt = CDec(rs("fwt_exmpt"))
                    swt_exmpt = CDec(rs("swt_exmpt"))
                End While
                rs.Close()
                'End Using
                'XXXXXXXXXXXXXXXXXXXXXXXXXX

                sqlstmnt = " Update cccktmp SET fica_gross = CASE WHEN ('106800.0000' - isnull(ccytd.ytd_fica_gross,0) > cccktmp.fed_gross) THEN cccktmp.fed_gross WHEN ('106800.0000' - isnull(ccytd.ytd_fica_gross,0) < 0) "
                sqlstmnt = sqlstmnt & " THEN 0.0 ELSE ('106800.0000' - isnull(ccytd.ytd_fica_gross,0)) END FROM cccktmp LEFT OUTER JOIN ccytd ON cccktmp.name_key = ccytd.name_key"
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = "update cccktmp set cccktmp.fica_gross =  0 from cccktmp inner join nam_cc on cccktmp.name_key = nam_cc.name_key  where nam_cc.fica_exmt = 'Y'"
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = "update cccktmp set cccktmp.med_gross =  cccktmp.fed_gross from cccktmp inner join nam_cc on cccktmp.name_key = nam_cc.name_key  where nam_cc.med_exmt = 'N'"
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = "update cccktmp set fica_tax = fica_gross * '" & fica_pct & "' , med_tax = med_gross * '" & med_pct & "', state1_gross = fed_gross"
                db.ExecuteUpdate(sqlstmnt)

                'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                'put annualizer and dol exempt into ccktstub to calc fed tax
                sqlstmnt = " UPDATE    cccktmp set  fed_tax = (cccktmp.fed_gross * Annualizer.Multiplier - taxtbl.fwt_exmpt * cccktmp.fwt_exmts - tax_rates.min_amt)* tax_rates.tax_pct / Annualizer.Multiplier + tax_rates.tax_amt + cccktmp.add_fwt"
                sqlstmnt = sqlstmnt & " from cccktmp INNER JOIN nam_cc ON cccktmp.name_key = nam_cc.name_key LEFT OUTER JOIN taxtbl ON cccktmp.state1_code = taxtbl.state LEFT OUTER JOIN"
                sqlstmnt = sqlstmnt & "           tax_rates ON nam_cc.file_status = tax_rates.sched LEFT OUTER JOIN Annualizer ON cccktmp.pay_freq = Annualizer.PayFreq"
                sqlstmnt = sqlstmnt & " WHERE     (cccktmp.fed_gross > 0) AND (cccktmp.fed_gross BETWEEN tax_rates.min_amt AND tax_rates.max_Amt)"
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = " update cccktmp set fed_tax = 0 where fed_tax < 0"
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = " Update cccktmp set state1_tax = (cccktmp.state1_gross * Annualizer.Multiplier - taxtbl.swt_exmpt * cccktmp.swt_exmts) * tax_rates.tax_pct / Annualizer.Multiplier + cccktmp.add_swt"
                sqlstmnt = sqlstmnt & " FROM         cccktmp LEFT OUTER JOIN tax_rates ON cccktmp.state1_code = tax_rates.state LEFT OUTER JOIN"
                sqlstmnt = sqlstmnt & " taxtbl ON cccktmp.state1_code = taxtbl.state LEFT OUTER JOIN  Annualizer ON cccktmp.pay_freq = Annualizer.PayFreq"
                sqlstmnt = sqlstmnt & " WHERE(cccktmp.state1_gross > 0)"
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = " update cccktmp set state1_tax = 0 where state1_tax < 0"
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = " Update cccktmp set state2_tax = (cccktmp.state2_gross * Annualizer.Multiplier - taxtbl.swt_exmpt * cccktmp.swt_exmts) * tax_rates.tax_pct / Annualizer.Multiplier + cccktmp.add_swt"
                sqlstmnt = sqlstmnt & " FROM         cccktmp LEFT OUTER JOIN tax_rates ON cccktmp.state2_code = tax_rates.state LEFT OUTER JOIN"
                sqlstmnt = sqlstmnt & " taxtbl ON cccktmp.state2_code = taxtbl.state LEFT OUTER JOIN  Annualizer ON cccktmp.pay_freq = Annualizer.PayFreq"
                sqlstmnt = sqlstmnt & " WHERE(cccktmp.state2_gross > 0)"
                db.ExecuteUpdate(sqlstmnt)

                sqlstmnt = " update cccktmp set state2_tax = 0 where state2_tax < 0"
                db.ExecuteUpdate(sqlstmnt)

                'XXXXXXXXXXXXXXXXXXXXXXXXXX
                '        'this calc net pay after all else is done
                '            cccktmp.Recordset.Fields("net_pay").Value = cccktmp.Recordset.Fields("full_gross").Value - cccktmp.Recordset.Fields("state1_tax").Value - cccktmp.Recordset.Fields("fed_Tax").Value - cccktmp.Recordset.Fields("fica_tax").Value - cccktmp.Recordset.Fields("med_Tax").Value - cccktmp.Recordset.Fields("add_fwt").Value - cccktmp.Recordset.Fields("add_swt").Value - cccktmp.Recordset.Fields("tdi_tax").Value - cccktmp.Recordset.Fields("dduct1_dol").Value - cccktmp.Recordset.Fields("dduct2_dol").Value - cccktmp.Recordset.Fields("dduct3_Dol").Value - cccktmp.Recordset.Fields("dduct4_Dol").Value

                sqlstmnt = " update cccktmp set net_pay = full_gross - fed_tax - fica_tax - med_tax - state1_tax - state2_tax - dduct1_dol - dduct2_dol - dduct3_dol - dduct4_dol - add_fwt - add_swt - add_fica - add_med "
                db.ExecuteUpdate(sqlstmnt)

                intcount = 0
                Dim ScreenName As String = ""
                '  Using db As Database = New Database(top_data_path)
                ' Dim rs As SqlDataReader = db.ExecuteQuery("Select name_key, screen_nam, net_pay from cccktmp where net_pay < 0")
                rs = db.ExecuteQuery("Select name_key, screen_nam, net_pay from cccktmp where net_pay < 0")
                While rs.Read()
                    intcount = intcount + 1
                    ScreenName = rs("screen_nam").ToString
                End While
                rs.Close()
                ' End Using

                If intcount <> 0 Then
                    MsgBox("There is a negative payment amount. It will need to be corrected before proceeding.  Check your edit.")
                    MsgBox("The check is for " & ScreenName)
                End If
            End Using ' for the whole process
            'XXXXXXXXXXXXXXXXXXXXXXXXXX
            '1 cccked  5-14-98
            ''print check edit report
            prtDestination = 1
            prtDiscardSavedData = 1
            msg = Pr_num1.Text
            prtParameterFields(1) = ""
            prtParameterFields(0) = "pay_num;" & msg & ";FALSE"

            prtreportfilename = cc_report_path & "cccked.rpt"
            CrystalForm.ShowDialog()
            prtParameterFields(0) = ""
            prtParameterFields(1) = ""

            Response = MsgBox("Check the edit. Choose NO to edit or YES to print checks.", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
            If Response = 7 Then
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Cancel.Focus()
            sqlstmnt = "delete from cccktmp"
            ETSSQL.ExecuteSQL(sqlstmnt)
                Exit Sub
            End If

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

            Response = MsgBox("Do you wish to continue with the payroll to print checks?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
            If Response = 7 Then
                MsgBox("Your data is in cktmp.  Please take care in not changing it before printing checks.")
                Me.Close()
                Exit Sub

        End If

        end_Date.Enabled = True
            beg_chk_num.Enabled = True
            System.Windows.Forms.SendKeys.Send("{TAB}")
            KeyAscii = 0

    End Sub

    Private Sub Process_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Enter
        end_Date.Text = ""
    End Sub

    Private Sub prt_Chk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles prt_Chk.Click

        sqlstmnt = " update rpthead set beg_num = '" & beg_chk_num.Text & "' , check_date = '" & pr_Start_date1.Text & "' , end_Date = '" & end_Date.Text & "'"
        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            db.ExecuteQuery(sql)
        End Using

        intcount = 0
        Dim ScreenName As String = ""
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery("Select name_key, screen_nam, net_pay from cccktmp where net_pay < 0")
            While rs.Read()
                intcount = intcount + 1
                ScreenName = rs("screen_nam").ToString
            End While
            rs.Close()
        End Using
        If intcount <> 0 Then
            For ETS.Common.Module1.num = 1 To intcount
                MsgBox("There is a negative payment amount. It will need to be corrected before proceeding.  Check your edit.")
                MsgBox("The check is for " & ScreenName)
            Next
        End If

        '        'this orders the checks properly for printing

        Dim sortorder As String = "N"
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery("select * from ccsys")
            While rs.Read()
                sortorder = rs("cc_sort1").ToString & ", " & rs("cc_sort2").ToString & ", " & rs("cc_sort3").ToString & ", " & rs("cc_sort4").ToString & ", " & rs("cc_sort5").ToString & ", " & rs("cc_sort6").ToString
            End While
            rs.Close()
        End Using

        'stop at last_choice

        sortorder = Strings.Left(sortorder, (InStr(sortorder, "last_choice")) - 3)

        'put check numbers into cccktmp in the right sort order
        Dim FirstCheckNum As Integer = CInt(beg_chk_num.Text) - 1

        sqlstmnt = " WITH CTE AS (SELECT chk_num, chk_date, chk_dirdep, pay_num, name_key, screen_nam, sort_name, entry_num, row_number() OVER (ORDER BY " & sortorder & ") AS row"
        sqlstmnt = sqlstmnt & " FROM cccktmp)    Update cte SET  chk_num = row +  '" & FirstCheckNum & "'"
        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            db.ExecuteQuery(sql)
        End Using

        sqlstmnt = "update cccktmp set chk_Date = '" & pr_Start_date1.Text & "'"
        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            db.ExecuteQuery(sql)
        End Using

        ETSCommon.CheckNumRecords("select * from cccktmp").ToString()

        chks_prted.Text = ETSCommon.CheckNumRecords("select * from cccktmp").ToString()        'fills in the number of checks printed

        MsgBox("Check the printer and make sure it is on line and the checks are lined up.")

restart_here:
        '        'xxprint the checks
        prtDestination = 1
        prtreportfilename = cc_report_path & "cccheck.rpt"
        CrystalForm.ShowDialog()

        Response = MsgBox("Did the checks all print? ", MsgBoxStyle.YesNo)
        If Response = 6 Then
            close_pr.Enabled = True
            close_pr.Focus()
        Else
            ' frmre_pr_chk.ShowDialog()
            GoTo restart_here
        End If

    End Sub

    Private Sub close_pr_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles close_pr.Click
        Response = MsgBox("Do you want to update the records?", MsgBoxStyle.YesNo)
        Dim new_pr As Integer = 0
        If Response = 6 Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim last_Chk_num As Integer = 0
            Using db As Database = New Database(top_data_path)
                Dim rs As SqlDataReader = db.ExecuteQuery(" select top (1) * from ccckstub order by  chk_num desc")
                While rs.Read()
                    last_Chk_num = CInt(rs("chk_num"))
                End While
                rs.Close()
            End Using

            If last_Chk_num = 0 Then
                MsgBox("Since this is the first payroll of the year you must enter the beginning check number.")
            Else
                'the for loop adds records to ckstub to show voided checks.
                If CDbl(beg_chk_num.Text) - last_Chk_num > 1 Then
                    sqlstmnt = "insert into ccckstub (chk_num,recon,encum_Date,void) "
                    sqlstmnt = sqlstmnt & " Values ('" & Val(CStr(last_Chk_num)) + 1 & "','Y','" & CDate(Today) & "','Y'),"
                    For ETS.Common.Module1.num = 2 To (CInt(beg_chk_num.Text) - last_Chk_num - 1)
                        sqlstmnt = sqlstmnt & " ('" & Val(CStr(last_Chk_num)) + num & "','Y','" & CDate(Today) & "','Y'),"
                    Next
                    'remove last comma at end of sqlstmnt
                    sqlstmnt = sqlstmnt.Substring(0, Len(sqlstmnt) - 1)
                    last_Chk_num = last_Chk_num + num - 1
                    Using db As Database = New Database(top_data_path)
                        Dim sql As String = sqlstmnt
                        db.ExecuteQuery(sql)
                    End Using
                End If
            End If

            sqlstmnt = " insert into ccckstub select * from cccktmp"
            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                db.ExecuteQuery(sql)
            End Using

            ''for adding records to cctime for makeup and min check
            '' minimu added during time sheet entry
            'sqlstmnt = " INSERT INTO cctime SELECT cctime_1.* FROM cctime AS cctime_1 INNER JOIN  cccktmp ON cctime_1.name_key = cccktmp.name_key AND cctime_1.pay_num = cccktmp.pay_num AND cctime_1.entry_num = cccktmp.entry_num WHERE(cccktmp.minimum <> 0)"
            'Using db As Database = New Database(top_data_path)
            '    Dim sql As String = sqlstmnt
            '    'db.ExecuteQuery(sql)
            'End Using

            'sqlstmnt = " UPDATE cctime set  pay_dol = derivedtbl_1.minimum, date = '" & end_Date.Text & "', job_num = '88887', pay_class = 'SP', hours = '0', pcs_prod = '0', cl_pct = '0', line_num = '99'"
            'sqlstmnt = sqlstmnt & " FROM         (SELECT     TOP (1) cccktmp.pay_num, cccktmp.name_key, cccktmp.screen_nam, cccktmp.sort_name, cctime_1.pay_dol, cccktmp.minimum"
            'sqlstmnt = sqlstmnt & " FROM  cccktmp INNER JOIN cctime AS cctime_1 ON cccktmp.name_key = cctime_1.name_key AND cccktmp.pay_num = cctime_1.pay_num AND "
            'sqlstmnt = sqlstmnt & " cccktmp.entry_num = cctime_1.entry_num  WHERe (cccktmp.minimum <> 0)) AS derivedtbl_1 CROSS JOIN cctime"

            ''    sqlstmnt = " Update cctime set date = '" & end_Date.Text & "', job_num = '88887', pay_class = 'SP', hours = '0', pcs_prod = '0', pay_dol = 'x', cl_pct = '0', line_num = 'x'"
            'Using db As Database = New Database(top_data_path)
            '    Dim sql As String = sqlstmnt
            '    db.ExecuteQuery(sql)
            'End Using

            '                    tmpset.Fields("date").Value = end_Date.Text
            '                    tmpset.Fields("job_num").Value = "88887"
            '                    tmpset.Fields("pay_class").Value = "SP"
            '                    tmpset.Fields("hours").Value = 0
            '                    tmpset.Fields("pcs_prod").Value = 0
            '                    tmpset.Fields("pay_dol").Value = cccktmp.Recordset.Fields("min_diff").Value
            '                    tmpset.Fields("cl_pct").Value = 0
            '                    tmpset.Fields("line_num").Value = tmpset.Fields("line_num").Value + 1

            sqlstmnt = " INSERT INTO cctime SELECT cctime_1.* FROM cctime AS cctime_1 INNER JOIN  cccktmp ON cctime_1.name_key = cccktmp.name_key AND cctime_1.pay_num = cccktmp.pay_num AND cctime_1.entry_num = cccktmp.entry_num WHERE(cccktmp.makeup <> 0)"
            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                db.ExecuteQuery(sql)
            End Using

            'sqlstmnt = " UPDATE cctime set  pay_dol = derivedtbl_1.makeup, date = '" & end_Date.Text & "', job_num = '88887', pay_class = 'SP', hours = '0', pcs_prod = '0', cl_pct = '0', line_num = '99'"
            'sqlstmnt = sqlstmnt & " FROM         (SELECT     TOP (1) cccktmp.pay_num, cccktmp.name_key, cccktmp.screen_nam, cccktmp.sort_name, cctime_1.pay_dol, cccktmp.makeup"
            'sqlstmnt = sqlstmnt & " FROM  cccktmp INNER JOIN cctime AS cctime_1 ON cccktmp.name_key = cctime_1.name_key AND cccktmp.pay_num = cctime_1.pay_num AND "
            'sqlstmnt = sqlstmnt & " cccktmp.entry_num = cctime_1.entry_num  WHERe (cccktmp.makeup <> 0)) AS derivedtbl_1 CROSS JOIN cctime"


            ''  sqlstmnt = " Update cctime set date = '" & end_Date.Text & "', job_num = '88886', pay_class = 'SP', hours = '0', pcs_prod = '0', pay_dol = 'x', cl_pct = '0', line_num = 'x'"
            'Using db As Database = New Database(top_data_path)
            '    Dim sql As String = sqlstmnt
            '    db.ExecuteQuery(sql)
            'End Using


            ''                tmpset.Fields("date").Value = end_Date.Text
            ''                tmpset.Fields("job_num").Value = "88886"
            ''                tmpset.Fields("pay_class").Value = "SP"
            ''                tmpset.Fields("hours").Value = 0
            ''                tmpset.Fields("pcs_prod").Value = 0
            ''                tmpset.Fields("pay_dol").Value = cccktmp.Recordset.Fields("makeup").Value
            ''                tmpset.Fields("cl_pct").Value = 0
            ''                tmpset.Fields("line_num").Value = tmpset.Fields("line_num").Value + 1

            'this is where we update all the cctime records for chk number and paid flag

            sqlstmnt = " UPDATE  cctime SET chk_num = cccktmp.chk_num, paid = 'Y' FROM  cccktmp INNER JOIN "
            sqlstmnt = sqlstmnt & " cctime ON cccktmp.name_key = cctime.name_key AND cccktmp.entry_num = cctime.entry_num AND cccktmp.pay_num = cctime.pay_num"
            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                db.ExecuteQuery(sql)
            End Using

            '        'now we update the vacation database

            sqlstmnt = " update ccvac set used_vac = shours from  (select name_key, SUM(hours) as shours from cctime"
            sqlstmnt = sqlstmnt & " WHERE (paid = 'Y') AND (void = 'N') and job_num = '81808'  GROUP BY name_key ) as tbl left join cctime on cctime.name_key = tbl.name_key "
            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                db.ExecuteQuery(sql)
            End Using

            sqlstmnt = " update ccvac set used_sick = shours from  (select name_key, SUM(hours) as shours from cctime"
            sqlstmnt = sqlstmnt & " WHERE (paid = 'Y') AND (void = 'N') and job_num = '82801'  GROUP BY name_key ) as tbl left join cctime on cctime.name_key = tbl.name_key "
            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                db.ExecuteQuery(sql)
            End Using

            sqlstmnt = " update ccvac set used_hol = shours from  (select name_key, SUM(hours) as shours from cctime"
            sqlstmnt = sqlstmnt & " WHERE (paid = 'Y') AND (void = 'N') and job_num = '83801'  GROUP BY name_key ) as tbl left join cctime on cctime.name_key = tbl.name_key "
            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                db.ExecuteQuery(sql)
            End Using

            sqlstmnt = " update ccvac set rem_vac = max_vac - used_vac, rem_hol = max_hol - used_hol, rem_sick = max_sick - used_sick"
            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                db.ExecuteQuery(sql)
            End Using

            sqlstmnt = " update cctime set paid = 'Y', chk_num = '0', encum_Date = '" & pr_Start_date1.Text & "' where paid = 'S' and pay_num = '" & Pr_num1.Text & "'"
            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                db.ExecuteQuery(sql)
            End Using


            '        'here we update the job file for this payroll
            Call update_job(1, CInt(Pr_num1.Text))  ' for the whole    xxscs

            '        'xxprint the check register
            prtDestination = 1
            prtreportfilename = cc_report_path & "ccckreg.rpt"
            CrystalForm.ShowDialog()

            Response = MsgBox("Is the check register OK?", MsgBoxStyle.YesNo)
            If Response = MsgBoxResult.Yes Then
                'Single check

                '            'added next if end if 7/26/05 lhw to fix pay num
                '            If single_pr.Checked Then
                '                ccckstub.Recordset.MoveLast()
                '                new_pr = ccckstub.Recordset.Fields("pay_num").Value + 1
                '                cctime.RecordSource = "select * from cctime where paid = 'N' and void = 'N'"
                '                cctime.Refresh()
                '                '

                '                             '            End If
                sqlstmnt = " update cctime set paid = 'Y', chk_num = '0', encum_Date = '" & pr_Start_date1.Text & "' where paid = 'S' and pay_num = '" & Pr_num1.Text & "'"
                Using db As Database = New Database(top_data_path)
                    Dim sql As String = sqlstmnt
                    db.ExecuteQuery(sql)
                End Using

                sqlstmnt = " update cctime set pay_num =  '" & Pr_num1.Text & "' where (paid = 'N' or paid = 'S') and void = 'N' "
                Using db As Database = New Database(top_data_path)
                    Dim sql As String = sqlstmnt
                    db.ExecuteQuery(sql)
                End Using

                Call blank_cktmp()
                Me.Close()
            Else
                MsgBox("If you wish to start over, click the cancel button after this message and be sure to restore data file from BEFORE disk.")
            End If
        Else
            MsgBox("If you wish to start over, click the cancel button after this message.")
        End If

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub single_pr_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles single_pr.CheckedChanged
        If formdone = False Then Exit Sub

        msg = InputBox("Enter the name key for the person who needs a single check.")
        If Len(msg) = 0 Then
            full_pr.Checked = True
            Exit Sub
        End If
        Call chkname(msg)
        If valid_name = "N" Then
            MsgBox("This is not a valid name key.  Please click on the button and re-enter.")
            full_pr.Checked = True
        Else
            Response = MsgBox("The check will be for " & selected_screen_nam, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
            If Response = 7 Then
                full_pr.Checked = True
                Exit Sub
            End If
            selected_name_key = msg
            pr_Start_date1.Focus()
        End If

    End Sub

End Class