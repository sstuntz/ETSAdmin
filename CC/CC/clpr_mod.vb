Option Strict On
Option Explicit On
Imports ETSCommon
Imports ETSCommon.MODULE1
Imports ETSCommon.Database
Imports System.Configuration
Imports System.Data.SqlClient
Imports System
Imports ETSCommon.ETSCommon

Module cc_mod
    '****************
    'revision History
    'original date of this form is 8/23/96 -SCS
    'Removed the ap fucntions and put into ap_mod

    '****************
    Declare Function GetActiveWindow Lib "user32" () As Integer
    Declare Function IsWindow Lib "user32" (ByVal hwnd As Integer) As Integer


    Declare Function FlashWindow Lib "user32" (ByVal hwnd As Integer, ByVal bInvert As Integer) As Integer
    Declare Function GetCaretBlinkTime Lib "user32" () As Integer
    Public success As Integer

    Public sendjob As String
    Public retjob As String
    Public retjobdesc As String
    Public retrate As Double
    Public valid_job As String
    Public pcs As Double
    Public cc_pwd As String 'added 1/24/05 lhw TMK
    '  Public Beg_chk_num As Integer  in pr common but it is last chk num there
    Public end_chk_num As Integer

    'added these 3 4/13/06 lhw
    Public time_vac As Decimal
    Public time_sick As Decimal
    Public time_hol As Decimal
    Public time_pers As Decimal

    Public selected_screen_nam_cc As String
    Public selected_name_key_cc As String
    Public selected_sort_name_cc As String
    Public selected_pay_num As Integer
    Public selected_entry_num As Integer
    Public cl_rate As Decimal
    Public tots(22) As Double
    Public qtots(22) As Double


    Public Sub CheckValidCliJob(ByVal Namekey As String, ByVal JobNum As String, ByVal ValidYN As String)
        Dim intcount As Integer = 0
        Dim sqlstmnt As String
        sqlstmnt = "select * from cc_clijob where name_key = '" & Namekey & "' and job_num = '" & JobNum & "'"
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)

            While rs.Read()
                intcount = intcount + 1
            End While
            rs.Close()
        End Using

        If intcount = 0 Then
            ValidYN = "N"
        Else
            ValidYN = "Y"
        End If
        'scs
    End Sub

    Sub cc_recalc_usedvac()

        Dim time_vac As Decimal = 0
        Dim time_sick As Decimal = 0
        Dim time_hol As Decimal = 0
        Dim time_pers As Decimal = 0

        sqlstmnt = "select job_num, name_key, SUM(hours) as hours from cctime"
        sqlstmnt = sqlstmnt & " where paid = 'Y' and left(job_num,1) = '8'  group by Job_num, name_key"

        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                Select Case CInt(Left(rs("job_num").ToString, 2))
                    Case 81
                        time_vac = CDec(time_vac + CDbl(rs("hours").ToString))
                    Case 82
                        time_sick = CDec(time_sick + CDbl(rs("hours").ToString))
                    Case 83
                        time_hol = CDec(time_hol + CDbl(rs("hours").ToString))
                    Case 84
                        time_pers = CDec(time_pers + CDbl(rs("hours").ToString))
                End Select
            End While
            rs.Close()
        End Using

        sqlstmnt = "UPDATE ccvac SET rem_vac = max_vac - used_vac, rem_hol = max_hol - used_hol, rem_sick = max_sick - used_sick, rem_pers = max_pers - used_pers"
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            db.ExecuteQuery(sqlstmnt)
        End Using


    End Sub

    Function calc_used_ben(ByVal ee_num As String) As List(Of Decimal)
        Dim time_vac As Decimal = 0
        Dim time_sick As Decimal = 0
        Dim time_hol As Decimal = 0
        Dim time_pers As Decimal = 0
        Dim timeben As New List(Of Decimal)

        sqlstmnt = "select job_num, SUM(hours) as hours from cctime"
        sqlstmnt = sqlstmnt & " where paid = 'N' and name_key = '" & ee_num & "' group by Job_num"

        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                Select Case CInt(Left(rs("job_num").ToString, 2))
                    Case 81
                        time_vac = CDec(time_vac + CDbl(rs("hours").ToString))
                    Case 82
                        time_sick = CDec(time_sick + CDbl(rs("hours").ToString))
                    Case 83
                        time_hol = CDec(time_hol + CDbl(rs("hours").ToString))
                    Case 84
                        time_pers = CDec(time_pers + CDbl(rs("hours").ToString))
                End Select
            End While
            rs.Close()
        End Using

        timeben.Add(time_vac)
        timeben.Add(time_sick)
        timeben.Add(time_hol)
        timeben.Add(time_pers)

        Return timeben

    End Function

    Sub chkdept(ByVal cc_num As String)

        sqlstmnt = "SELECT * FROM nam_cc WHERE"
        sqlstmnt = sqlstmnt & " name_key = " & Chr(34) & cc_num & Chr(34)
        sqlstmnt = sqlstmnt & " AND dept_num = " & Chr(34) & cc_pwd & Chr(34)
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            Dim intcount As Integer = 0

            While rs.Read()
                selected_dpt_num = rs("dept_num").ToString
                intcount = intcount + 1
            End While
            rs.Close()
        End Using

        If intcount = 0 Then
            valid_name = "N"
        Else
            valid_name = "Y"
        End If

    End Sub

    Public Function calc_cc_pay(ByVal job_num As String, ByVal Paycl As String, ByVal pcs As Integer, ByVal hrs As Decimal, ByVal name_key As String, ByVal pay As Decimal, ByVal pct As Decimal) As List(Of Decimal)

        'calculate the pay
        Dim pcs_hr As Decimal = 0
        Dim pc_rate As Decimal = 0
        Dim prev_rate As Decimal = 0
        Dim rate_hr As Decimal = 0
        Dim factor As Decimal = 0
        Dim avg_hrly As Decimal = 0
        Dim cl_pct As Decimal = 0
        Dim returnarray As New List(Of Decimal)

        'create all the variables and then use the calc with fields changed to variables
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = "select * from ccjob where job_num = '" & job_num & "'"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            Dim intcount As Integer = 0

            While rs.Read()
                pcs_hr = CDec(rs("pcs_hr"))
                pc_rate = CDec(rs("pc_rate"))
                prev_rate = CDec(rs("prev_rate"))
                rate_hr = CDec(rs("rate_hr"))
                '  factor = CDec(rs("factor"))
            End While
            rs.Close()
        End Using

        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = "select * from nam_cc where name_key = '" & name_key & "'"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            While rs.Read()
                avg_hrly = CDec(rs("avg_hrly"))
            End While
            rs.Close()
        End Using

        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = "select * from cc_Clijob where name_key = '" & name_key & "'" & " and job_num = '" & job_num & "'"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            While rs.Read()
                cl_pct = CDec(rs("cl_pct"))
            End While
            rs.Close()
        End Using

        Select Case Paycl
            Case "PC"
                pct = (pcs / pcs_hr) / hrs
                pay = pcs * pc_rate
            Case "DH"
                pay = hrs * avg_hrly
            Case "IH"
                pay = hrs * avg_hrly
            Case "NO"
                pct = 0
                pay = 0
            Case "DP" 'changed 1/22/10 scs for rounding with 4 places in percent hmea
                pct = cl_pct
                Call calc_cl_rate(cl_pct, prev_rate, cl_rate)
                pay = hrs * cl_rate
            Case "IP" 'changed 1/22/10 scs for rounding with 4 places in percent hmea
                pct = cl_pct
                Call calc_cl_rate(cl_pct, prev_rate, cl_rate)
                pay = hrs * cl_rate
            Case "SD"

            Case "SI"

            Case "OP"
                pct = Int(pcs / hrs / pcs_hr * 100) / 100 'trunc
                pay = pcs * pc_rate
            Case "OH" 'changed 1/22/10 scs for rounding with 4 places in percent hmea
                pct = cl_pct
                Call calc_cl_rate(cl_pct, prev_rate, cl_rate)
                pay = hrs * cl_rate
            Case "ST"
                pct = 0
                pay = hrs * rate_hr
            Case "OO" 'changed 1/22/10 scs for rounding with 4 places in percent hmea
                pct = cl_pct
                Call calc_cl_rate(cl_pct, prev_rate, cl_rate)
                pay = hrs * cl_rate
            Case "DF" 'direct flat rate
                pay = hrs * rate_hr
            Case "IF" 'indirect flat rate
                pay = hrs * rate_hr
                pct = 0
            Case "MD"
                pay = hrs * rate_hr
                pct = factor
            Case "CI"
                pay = hrs * rate_hr
                pct = 0
        End Select


        returnarray.Add(pay)
        returnarray.Add(pct)
        Return returnarray

    End Function

    Sub calc_cl_rate(ByVal cl_pct As Decimal, ByVal prev_rate As Decimal, ByVal cl_rate As Decimal) 'added 1/22/10 scs
        'the goal here is to calc the cl_rate to be a two decimal value not just for display but for calculation
        cl_rate = cl_pct * prev_rate

        If cl_rate * 100 - Int(cl_rate * 100) >= 0.001 Then 'the test if  it not only two digits already
            cl_rate = (Int(cl_rate * 100) + 1) / 100
        End If

    End Sub

    Public Function etsjobnum_chk(ByVal sendjob As String) As List(Of String)
        Dim intcount As Integer = 0
        Dim jobdata As New List(Of String)

        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = "select * from ccjob where job_num = '" & sendjob & "'"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            While rs.Read()
                jobdata.Add(rs("pay_Class").ToString)
                jobdata.Add(rs("job_desc").ToString)
                jobdata.Add(rs("prev_rate").ToString)
                intcount = intcount + 1
            End While
            rs.Close()
        End Using

        If intcount = 0 Then
            valid_job = "N"
        Else
            valid_job = "Y"
        End If
        jobdata.Add(valid_job)
        Return jobdata

    End Function

    Sub chkpayclass(ByVal sendjob As String, ByVal valid_YN As String)

        Call ETSCommon.ETSCommon.CheckOnceYN("ccpaycl", "pay_class", sendjob, valid_YN)

    End Sub

    Sub ets_disab_num_chk(ByVal sendjob As String, ByVal retlocdesc As String, ByVal valid_YN As String)
        Dim sendloc As String = ""
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = "select * from cc_disab where disab_num = '" & sendjob & "'"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            Dim intcount As Integer = 0

            While rs.Read()
                sendloc = rs("disab_num").ToString
                retlocdesc = rs("disab_desc").ToString
                intcount = intcount + 1
            End While
            rs.Close()
        End Using

        If intcount = 0 Then
            valid_YN = "N"
        Else
            valid_YN = "Y"
        End If

    End Sub

    Public Sub update_job(ByVal beg_pay_num As Integer, ByVal last_pay_num As Integer)
        ' not checking fiscal year since can not summarize by job since first 6 months not in cctme.
        Select Case beg_pay_num
            Case Is = 0 'zero the file 
                sqlstmnt = "update ccjob set (hrs_ytd = 0),(pcs_ytd = 0),(dol_pd_ytd = 0),(payper_hrs = 0),(payper_pcs = 0),(payper_dol = 0)"
            Case Is = 1 ' full year
                sqlstmnt = "UPDATE ccjob SET  "
                sqlstmnt = sqlstmnt & " hrs_ytd = derivedtbl_1.shrs_ytd, pcs_ytd = derivedtbl_1.spcs_ytd, dol_pd_ytd = derivedtbl_1.sdol_pd_ytd "
                sqlstmnt = sqlstmnt & "FROM (SELECT     job_num, SUM(hours) AS shrs_ytd, SUM(pcs_prod) AS spcs_ytd, SUM(pay_dol) AS sdol_pd_ytd "
                sqlstmnt = sqlstmnt & "FROM cctime"
                sqlstmnt = sqlstmnt & " GROUP BY job_num) AS derivedtbl_1 CROSS JOIN "
                sqlstmnt = sqlstmnt & "ccjob "
                sqlstmnt = sqlstmnt & "WHERE (ccjob.job_num = ccjob.job_num)"
            Case Else ' range of pay periods this goes into payper
                sqlstmnt = "UPDATE ccjob SET  "
                sqlstmnt = sqlstmnt & " payper_hrs = derivedtbl_1.shrs_ytd,  payper_pcs = derivedtbl_1.spcs_ytd,  payper_dol = derivedtbl_1.sdol_pd_ytd "
                sqlstmnt = sqlstmnt & "FROM (SELECT job_num, SUM(hours) AS shrs_ytd, SUM(pcs_prod) AS spcs_ytd, SUM(pay_dol) AS sdol_pd_ytd "
                sqlstmnt = sqlstmnt & "FROM cctime"
                sqlstmnt = sqlstmnt & " GROUP BY job_num) AS derivedtbl_1 CROSS JOIN "
                sqlstmnt = sqlstmnt & "ccjob "
                sqlstmnt = sqlstmnt & "WHERE (ccjob.job_num = ccjob.job_num) and pay_num between '" & beg_pay_num & "' and '" & last_pay_num & "'"
        End Select
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = sqlstmnt
            db.ExecuteQuery(sql)
        End Using

    End Sub

    Public Sub ytd_create(ByVal present_quarter_num As Integer)
        Dim quarter_begin_Date As Date
        Dim quarter_End_date As Date
        'the quarter to date data is based on the check date

        Select Case present_quarter_num
            Case 1
                quarter_begin_Date = CDate("1/1/" & Year(Today))
                quarter_End_date = CDate("3/31/" & Year(Today))
            Case 2
                quarter_begin_Date = CDate("4/1/" & Year(Today))
                quarter_End_date = CDate("6/30/" & Year(Today))
            Case 3
                quarter_begin_Date = CDate("7/1/" & Year(Today))
                quarter_End_date = CDate("9/30/" & Year(Today))
            Case 4
                quarter_begin_Date = CDate("10/1/" & Year(Today))
                quarter_End_date = CDate("12/31/" & Year(Today))
            Case Else
                quarter_begin_Date = CDate("1/1/" & Year(Today))
                quarter_End_date = CDate("12/31/" & Year(Today))

        End Select
        'the process is 3 sql procedures
        'the first clears the ytd table of all fields
        'the second adds all the ytd info
        'the third adds the qtd to the info above
      
        sqlstmnt = "delete from ccytd; "
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = sqlstmnt
            db.ExecuteQuery(sql)
        End Using

        'ytd
        sqlstmnt = " UPDATE ccytd SET ccytd.ytd_dduct1 = ytd_dduct1, ccytd.ytd_fica_gross = ytd_fica_gross, ccytd.ytd_dduct2 = ytd_dduct2, ccytd.ytd_dduct3 = ytd_dduct3, ccytd.ytd_dduct4 = ytd_dduct4,"
        sqlstmnt = sqlstmnt & " ccytd.ytd_makeup = ytd_makeup, ccytd.ytd_stipend = ytd_stipend, ccytd.ytd_minimum = ytd_minimum, ccytd.ytd_full_gross = ytd_full_gross, ccytd.ytd_fed_gross = ytd_fed_gross, "
        sqlstmnt = sqlstmnt & " ccytd.ytd_med_gross = ytd_med_gross, ccytd.ytd_st1_gross = ytd_st1_gross, ccytd.ytd_st2_gross = ytd_st2_gross, ccytd.ytd_fed_Tax = ytd_fed_Tax, ccytd.ytd_fica_Tax = ytd_fica_Tax, ccytd.ytd_st1_Tax = ytd_st1_tax, ccytd.ytd_st2_Tax = ytd_st2_tax"
        sqlstmnt = sqlstmnt & " SELECT name_key, SUM(dduct1_dol) AS ytd_dduct1, SUM(dduct2_dol) AS ytd_dduct2, SUM(dduct3_dol) AS ytd_dduct3, SUM(dduct4_dol) AS ytd_dduct4, SUM(makeup) "
        sqlstmnt = sqlstmnt & "  AS ytd_makeup, SUM(stipend) AS ytd_stipend, SUM(minimum) AS ytd_minimum, SUM(full_gross) AS ytd_full_gross, SUM(fed_gross) AS ytd_fed_gross, "
        sqlstmnt = sqlstmnt & " SUM(fica_gross) AS ytd_fica_gross, SUM(med_gross) AS ytd_med_gross, SUM(state1_gross) AS ytd_st1_gross, SUM(state2_gross) AS ytd_st2_gross, "
        sqlstmnt = sqlstmnt & " SUM(fed_tax + add_fwt) AS ytd_fed_tax, SUM(fica_tax + add_fica) AS ytd_fica_tax, SUM(med_tax + add_med) AS ytd_med_tax, SUM(state1_tax + add_swt) "
        sqlstmnt = sqlstmnt & " AS ytd_st1_tax, SUM(state2_tax) AS ytd_st2_tax, SUM(tdi_Tax) AS ytd_tdi"
        sqlstmnt = sqlstmnt & "   FROM ccckstub "
        sqlstmnt = sqlstmnt & " WHERE     (void = 'N')"
        sqlstmnt = sqlstmnt & " GROUP BY name_key;"
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = sqlstmnt
            db.ExecuteQuery(sql)
        End Using

        sqlstmnt = sqlstmnt & "UPDATE ccytd  SET qtd_dduct1 = tbl.sqtd_dduct1, qtd_dduct2 = tbl.sqtd_dduct2, qtd_dduct3 = tbl.sqtd_dduct3, "
        sqlstmnt = sqlstmnt & " qtd_dduct4 = tbl.sqtd_dduct4, qtd_makeup = tbl.sqtd_makeup, "
        sqlstmnt = sqlstmnt & " qtd_stipend = tbl.sqtd_stipend, qtd_minimum = tbl.sqtd_minimum, qtd_full_gross = tbl.sqtd_full_gross, "
        sqlstmnt = sqlstmnt & " qtd_fed_gross = tbl.sqtd_fed_gross, qtd_fica_gross = tbl.sqtd_fica_gross, "
        sqlstmnt = sqlstmnt & " qtd_med_gross = tbl.sqtd_med_gross, qtd_st1_gross = tbl.sqtd_st1_gross, qtd_st2_gross = ccytd.qtd_st2_gross, "
        sqlstmnt = sqlstmnt & " qtd_fed_tax = ccytd.qtd_fed_Tax, qtd_fica_tax = ccytd.qtd_fica_Tax,"
        sqlstmnt = sqlstmnt & " qtd_med_tax = ccytd.qtd_med_Tax, qtd_st1_tax = tbl.sqtd_st1_tax, qtd_st2_tax = ccytd.qtd_st2_tax, qtd_tdi = ccytd.qtd_tdi"
        sqlstmnt = sqlstmnt & " FROM (SELECT     name_key, SUM(dduct1_dol) AS sqtd_dduct1, SUM(dduct2_dol) AS sqtd_dduct2, SUM(dduct3_dol) AS sqtd_dduct3, SUM(dduct4_dol) AS sqtd_dduct4, "
        sqlstmnt = sqlstmnt & " SUM(makeup) AS sqtd_makeup, SUM(stipend) AS sqtd_stipend, SUM(minimum) AS sqtd_minimum, SUM(full_gross) AS sqtd_full_gross, SUM(fed_gross) "
        sqlstmnt = sqlstmnt & "  AS sqtd_fed_gross, SUM(fica_gross) AS sqtd_fica_gross, SUM(med_gross) AS sqtd_med_gross, SUM(state1_gross) AS sqtd_st1_gross, "
        sqlstmnt = sqlstmnt & "  SUM(state2_gross) AS sqtd_st2_gross, SUM(fed_tax + add_fwt) AS sqtd_fed_tax, SUM(fica_tax + add_fica) AS sqtd_fica_tax, SUM(med_tax + add_med) "
        sqlstmnt = sqlstmnt & "  AS sqtd_med_tax, SUM(state1_tax + add_swt) AS sqtd_st1_tax, SUM(state2_tax) AS sqtd_st2_tax, SUM(tdi_Tax) AS sqtd_tdi"
        sqlstmnt = sqlstmnt & " FROM ccckstub "
        sqlstmnt = sqlstmnt & " WHERE      (void = 'N')"
        sqlstmnt = sqlstmnt & "  GROUP BY name_key) AS tbl INNER JOIN"
        sqlstmnt = sqlstmnt & "  ccytd ON tbl.name_key = ccytd.name_key"


        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = sqlstmnt
            db.ExecuteQuery(sql)
        End Using
    End Sub
End Module