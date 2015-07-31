Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports System.Collections.Generic
Imports ETS.Common.Module1
Imports PS.Common

Public Class ETSSQLCC


    Public Shared Function GetOneCCTimeData(ByVal sqlstmnt As String) As cctimeData

        Dim ds As New cctimeData
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read
                ds.EntryDate = CDate(rs("entry_Date").ToString)  ' Date
                ds.PayNum = CInt(rs("pay_num").ToString)  ' Integer
                ds.NameKey = rs("name_key").ToString  ' String
                ds.ScreenNam = rs("screen_nam").ToString  ' String
                ds.SortName = rs("sort_name").ToString  ' String
                ds.PayFreq = rs("pay_freq").ToString  ' String
                ds.DedDfq = rs("ded_dfq").ToString  ' String
                ds.EntryNum = CInt(rs("entry_num").ToString)  ' Integer
                ds.LineNum = CInt(rs("line_num").ToString)  ' Integer
                ds.ActDate = CDate(rs("Date").ToString)  ' Date
                ds.JobNum = rs("job_num").ToString  ' String
                ds.PayClass = rs("pay_class").ToString    ' String
                ds.Hours = CDec(rs("hours").ToString)  ' Decimal
                ds.PcsProd = CDec(rs("pcs_prod").ToString)  ' Decimal
                ds.DeptNum = rs("dept_num").ToString
                ds.PayDol = CDec(rs("pay_dol").ToString)  ' Decimal
                ds.ClPct = CDec(rs("cl_pct").ToString)  ' Decimal
                ds.ChkNum = CInt(rs("chk_num").ToString)  ' Integer
                ds.Refusal = rs("refusal").ToString  ' String
                ds.Paid = rs("paid").ToString  ' String
                ds.Checked = rs("checked").ToString  ' String
                ds.Dflag = rs("dflag").ToString  ' String
                ds.Agency = rs("agency").ToString  ' String
                ds.Void = rs("void").ToString  ' String
                ds.Glpost = rs("glpost").ToString  ' String
                ds.EncumDate = CDate(rs("encum_date").ToString)  ' Date
                ds.StateTax = rs("state_Tax").ToString  ' String
                ds.JrnlNum = CInt(rs("jrnl_num").ToString)  ' Integer
                ds.JrnlLine = CInt(rs("jrnl_line").ToString)  ' Integer

            End While
            rs.Close()
        End Using
        Return ds

    End Function

    Public Shared Function GetCCTimeData(ByVal sqlstmnt As String) As List(Of cctimeData)
        Dim CCTimeData As New List(Of cctimeData)
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read
                Dim ds As New cctimeData
                ds.EntryDate = CDate(rs("entry_Date").ToString)  ' Date
                ds.PayNum = CInt(rs("pay_num").ToString)  ' Integer
                ds.NameKey = rs("name_key").ToString  ' String
                ds.ScreenNam = rs("screen_nam").ToString  ' String
                ds.SortName = rs("sort_name").ToString  ' String
                ds.PayFreq = rs("pay_freq").ToString  ' String
                ds.DedDfq = rs("ded_dfq").ToString  ' String
                ds.EntryNum = CInt(Val(rs("entry_num").ToString))  ' Integer
                ds.LineNum = CInt(Val(rs("line_num").ToString)) ' Integer
                ds.ActDate = CDate(rs("Date").ToString)  ' Date
                ds.JobNum = rs("job_num").ToString  ' String
                ds.PayClass = rs("pay_class").ToString    ' String
                ds.Hours = CDec(rs("hours").ToString)  ' Decimal
                ds.PcsProd = CDec(rs("pcs_prod").ToString)  ' Decimal
                ds.DeptNum = rs("dept_num").ToString
                ds.PayDol = CDec(rs("pay_dol").ToString)  ' Decimal
                ds.ClPct = CDec(rs("cl_pct").ToString)  ' Decimal
                ds.ChkNum = CInt(Val(rs("chk_num").ToString))  ' Integer
                ds.Refusal = rs("refusal").ToString  ' String
                ds.Paid = rs("paid").ToString  ' String
                ds.Checked = rs("checked").ToString  ' String
                ds.Dflag = rs("dflag").ToString  ' String
                ds.Agency = rs("agency").ToString  ' String
                ds.Void = rs("void").ToString  ' String
                ds.Glpost = rs("glpost").ToString  ' String
                ' ds.EncumDate = CDate(rs("encum_date").ToString)  ' Date
                ds.StateTax = rs("state_Tax").ToString  ' String
                '   ds.JrnlNum = CInt(rs("jrnl_num").ToString)  ' Integer
                '  ds.JrnlLine = CInt(rs("jrnl_line").ToString)  ' Integer
                CCTimeData.Add(ds)
            End While
            rs.Close()
        End Using

        Return CCTimeData
    End Function

    Public Shared Function GetBlankNameCCData() As NameCCData
        Dim ds As New NameCCData
        ds.NameKey = ""    '("").tostring  '    String
        ds.ScreenNam = ""    '("").tostring  '    String
        ds.SortName = ""    '("").tostring  '    String
        ds.Desc1 = ""    '("").tostring  '    String
        ds.Desc2 = ""    '("").tostring  '    String
        ds.Desc3 = ""    '("").tostring  '    String
        ds.DeptNum = ""    '("").tostring  '    String
        ds.FundCode = ""    '("").tostring  '    String
        ds.DisabNum = ""    '("").tostring  '    String
        ds.DisabDesc = ""    '("").tostring  '    String
        ds.SsNum = ""    '("").tostring  '    String
        ds.HireDate = CDate("1/1/2001")    '("").tostring  '    Date
        ds.TermDate = CDate("1/1/2050")    '("").tostring  '    Date
        ds.AnnivMo = ""    '("").tostring  '    String
        ds.Dob = CDate("1/1/2001")     '("").tostring  '    Date
        ds.AvgHrly = 0    '("").tostring  '    Decimal
        ds.Makeup = ""    '("").tostring  '    String
        ds.EPhone = ""    '("").tostring  '    String
        ds.EName = ""    '("").tostring  '    String
        ds.WcNum = ""    '("").tostring  '    String
        ds.WcRate = 0    '("").tostring  '    Decimal
        ds.FicaExmt = ""    '("").tostring  '    String
        ds.MedExmt = ""    '("").tostring  '    String
        ds.FileStatus = ""    '("").tostring  '    String
        ds.PayFreq = ""    '("").tostring  '    String
        ds.Printck = ""    '("").tostring  '    String
        ds.FwtExmts = 0    '("").tostring  '    Integer
        ds.SwtExmts = 0    '("").tostring  '    Integer
        ds.State1Tax = ""    '("").tostring  '    String
        ds.State2Tax = ""    '("").tostring  '    String
        ds.AddFwt = 0   '("").tostring  '    Decimal
        ds.AddfwtDfq = ""    '("").tostring  '    String
        ds.AddSwt = 0    '("").tostring  '    Decimal
        ds.AddswtDfq = ""    '("").tostring  '    String
        ds.AddFica = 0    '("").tostring  '    Decimal
        ds.AddficaDfq = ""    '("").tostring  '    String
        ds.AddMed = 0    '("").tostring  '    Decimal
        ds.AddmedDfq = ""    '("").tostring  '    String
        ds.DdepDfq = ""    '("").tostring  '    String
        ds.DdepNet = ""    '("").tostring  '    String
        ds.Dduct1Num = ""    '("").tostring  '    String
        ds.Dduct1Dol = 0    '("").tostring  '    Decimal
        ds.Dduct1Dfq = ""    '("").tostring  '    String
        ds.Dduct2Num = ""    '("").tostring  '    String
        ds.Dduct2Dol = 0    '("").tostring  '    Decimal
        ds.Dduct2Dfq = ""    '("").tostring  '    String
        ds.Dduct3Num = ""    '("").tostring  '    String
        ds.Dduct3Dol = 0    '("").tostring  '    Decimal
        ds.Dduct3Dfq = ""    '("").tostring  '    String
        ds.Dduct4Num = ""    '("").tostring  '    String
        ds.Dduct4Dol = 0    '("").tostring  '    Decimal
        ds.Dduct4Dfq = ""    '("").tostring  '    String
        ds.Agency = 1  '("").tostring  '    Integer
        ds.Dflag = ""    '("").tostring  '    String
        ds.Text1 = ""    '("").tostring  '    String
        ds.Text2 = ""    '("").tostring  '    String
        ds.Coach = ""
        Return ds
    End Function


    Public Shared Function GetOneNameCCData(ByVal sqlstmnt As String) As NameCCData

        Dim ds As New NameCCData
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read
                ds.NameKey = rs("name_key").ToString  '    String
                ds.ScreenNam = rs("screen_nam").ToString  '    String
                ds.SortName = rs("sort_name").ToString  '    String
                ds.Desc1 = rs("desc1").ToString  '    String
                ds.Desc2 = rs("desc2").ToString  '    String
                ds.Desc3 = rs("desc3").ToString  '    String
                ds.DeptNum = rs("dept_num").ToString  '    String
                ds.FundCode = rs("fund_code").ToString  '    String
                ds.DisabNum = rs("disab_num").ToString  '    String
                ds.DisabDesc = rs("disab_desc").ToString  '    String
                ds.SsNum = rs("ss_num").ToString  '    String
                ds.HireDate = CDate(rs("hire_Date").ToString)  '    Date
                If Not IsDBNull(rs("term_Date")) Then
                    ds.TermDate = CDate(rs("term_date").ToString)  '    Date
                End If
                ds.AnnivMo = rs("anniv_mo").ToString  '    String
                ds.Dob = CDate(rs("dob").ToString) '    Date
                ds.AvgHrly = CDec(rs("avg_hrly").ToString)  '    Decimal
                ds.Makeup = rs("makeup").ToString  '    String
                ds.EPhone = rs("e_phone").ToString  '    String
                ds.EName = rs("e_name").ToString  '    String
                ds.WcNum = rs("wc_num").ToString  '    String
                ds.WcRate = CDec(rs("wc_rate").ToString) '    Decimal
                ds.FicaExmt = rs("fica_exmt").ToString  '    String
                ds.MedExmt = rs("med_exmt").ToString  '    String
                ds.FileStatus = rs("file_status").ToString  '    String
                ds.PayFreq = rs("pay_freq").ToString  '    String
                ds.Printck = rs("printck").ToString  '    String
                ds.FwtExmts = CInt(rs("fwt_exmts").ToString)  '    Integer
                ds.SwtExmts = CInt(rs("swt_exmts").ToString) '    Integer
                ds.State1Tax = rs("state1_tax").ToString  '    String
                ds.State2Tax = rs("state2_tax").ToString  '    String
                ds.AddFwt = CDec(rs("add_fwt").ToString) '    Decimal
                ds.AddfwtDfq = rs("addfwt_dfq").ToString  '    String
                ds.AddSwt = CDec(rs("add_swt").ToString) '    Decimal
                ds.AddswtDfq = rs("addswt_dfq").ToString  '    String
                ds.AddFica = CDec(rs("add_fica").ToString) '    Decimal
                ds.AddficaDfq = rs("addfica_dfq").ToString  '    String
                ds.AddMed = CDec(rs("add_med").ToString) '    Decimal
                ds.AddmedDfq = rs("addmed_dfq").ToString  '    String
                ds.DdepDfq = rs("ddep_dfq").ToString  '    String
                ds.DdepNet = rs("ddep_net").ToString  '    String
                ds.Dduct1Num = rs("dduct1_num").ToString  '    String
                ds.Dduct1Dol = CDec(rs("dduct1_dol").ToString) '    Decimal
                ds.Dduct1Dfq = rs("dduct1_dfq").ToString  '    String
                ds.Dduct2Num = rs("dduct2_num").ToString  '    String
                ds.Dduct2Dol = CDec(rs("dduct2_dol").ToString) '    Decimal
                ds.Dduct2Dfq = rs("dduct2_dfq").ToString  '    String
                ds.Dduct3Num = rs("dduct3_num").ToString  '    String
                ds.Dduct3Dol = CDec(rs("dduct3_dol").ToString) '    Decimal
                ds.Dduct3Dfq = rs("dduct3_dfq").ToString  '    String
                ds.Dduct4Num = rs("dduct4_num").ToString  '    String
                ds.Dduct4Dol = CDec(rs("dduct4_dol").ToString) '    Decimal
                ds.Dduct4Dfq = rs("dduct4_dfq").ToString  '    String
                ds.Agency = CInt(rs("agency").ToString)  '    Integer
                ds.Dflag = rs("dflag").ToString  '    String
                ds.Text1 = rs("text1").ToString  '    String
                ds.Text2 = rs("text2").ToString  '    String
                ds.Coach = rs("coach").ToString
            End While
            rs.Close()
        End Using
        Return ds

    End Function

    Public Shared Function GetNameCCData(ByVal sqlstmnt As String) As List(Of NameCCData)
        Dim NameCCData As New List(Of NameCCData)
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read
                Dim ds As New NameCCData
                ds.NameKey = rs("name_key").ToString  '    String
                ds.ScreenNam = rs("screen_nam").ToString  '    String
                ds.SortName = rs("sort_name").ToString  '    String
                ds.Desc1 = rs("desc1").ToString  '    String
                ds.Desc2 = rs("desc2").ToString  '    String
                ds.Desc3 = rs("desc3").ToString  '    String
                ds.DeptNum = rs("dept_num").ToString  '    String
                ds.FundCode = rs("fund_code").ToString  '    String
                ds.DisabNum = rs("disab_num").ToString  '    String
                ds.DisabDesc = rs("disab_desc").ToString  '    String
                ds.SsNum = rs("ss_num").ToString  '    String
                ds.HireDate = CDate(rs("hire_Date").ToString)  '    Date
                ds.TermDate = CDate(rs("term_date").ToString)  '    Date
                ds.AnnivMo = rs("anniv_mo").ToString  '    String
                ds.Dob = CDate(rs("dob").ToString) '    Date
                ds.AvgHrly = CDec(rs("avg_hrly").ToString)  '    Decimal
                ds.Makeup = rs("makeup").ToString  '    String
                ds.EPhone = rs("e_phone").ToString  '    String
                ds.EName = rs("e_name").ToString  '    String
                ds.WcNum = rs("wc_num").ToString  '    String
                ds.WcRate = CDec(rs("wc_rate").ToString) '    Decimal
                ds.FicaExmt = rs("fica_exmt").ToString  '    String
                ds.MedExmt = rs("med_exmt").ToString  '    String
                ds.FileStatus = rs("file_status").ToString  '    String
                ds.PayFreq = rs("pay_freq").ToString  '    String
                ds.Printck = rs("printck").ToString  '    String
                ds.FwtExmts = CInt(rs("fwt_exmts").ToString)  '    Integer
                ds.SwtExmts = CInt(rs("swt_exmts").ToString) '    Integer
                ds.State1Tax = rs("state1_tax").ToString  '    String
                ds.State2Tax = rs("state2_tax").ToString  '    String
                ds.AddFwt = CDec(rs("add_fwt").ToString) '    Decimal
                ds.AddfwtDfq = rs("addfwt_dfq").ToString  '    String
                ds.AddSwt = CDec(rs("add_swt").ToString) '    Decimal
                ds.AddswtDfq = rs("addswt_dfq").ToString  '    String
                ds.AddFica = CDec(rs("add_fica").ToString) '    Decimal
                ds.AddficaDfq = rs("addfica_dfq").ToString  '    String
                ds.AddMed = CDec(rs("add_med").ToString) '    Decimal
                ds.AddmedDfq = rs("addmed_dfq").ToString  '    String
                ds.DdepDfq = rs("ddep_dfq").ToString  '    String
                ds.DdepNet = rs("ddep_net").ToString  '    String
                ds.Dduct1Num = rs("dduct1_num").ToString  '    String
                ds.Dduct1Dol = CDec(rs("dduct1_dol").ToString) '    Decimal
                ds.Dduct1Dfq = rs("dduct1_dfq").ToString  '    String
                ds.Dduct2Num = rs("dduct2_num").ToString  '    String
                ds.Dduct2Dol = CDec(rs("dduct2_dol").ToString) '    Decimal
                ds.Dduct2Dfq = rs("dduct2_dfq").ToString  '    String
                ds.Dduct3Num = rs("dduct3_num").ToString  '    String
                ds.Dduct3Dol = CDec(rs("dduct3_dol").ToString) '    Decimal
                ds.Dduct3Dfq = rs("dduct3_dfq").ToString  '    String
                ds.Dduct4Num = rs("dduct4_num").ToString  '    String
                ds.Dduct4Dol = CDec(rs("dduct4_dol").ToString) '    Decimal
                ds.Dduct4Dfq = rs("dduct4_dfq").ToString  '    String
                ds.Agency = CInt(rs("agency").ToString)  '    Integer
                ds.Dflag = rs("dflag").ToString  '    String
                ds.Text1 = rs("text1").ToString  '    String
                ds.Text2 = rs("text2").ToString  '    String
                ds.Coach = rs("coach").ToString
                NameCCData.Add(ds)
            End While
            rs.Close()
        End Using

        Return NameCCData
    End Function

    Public Shared Function GetBlankCCTimeData() As cctimeData
        Dim ds As New cctimeData
        '  ds.EntryDate = Date
        ds.PayNum = 0
        ds.NameKey = ""
        ds.ScreenNam = ""
        ds.SortName = ""
        ds.PayFreq = ""
        ds.DedDfq = ""
        ds.EntryNum = 0
        ds.LineNum = 0
        '  ds.ActDate = Date
        ds.JobNum = ""
        ds.PayClass = ""
        ds.Hours = 0
        ds.PcsProd = 0
        ds.DeptNum = ""
        ds.PayDol = 0
        ds.ClPct = 0
        ds.ChkNum = 0
        ds.Refusal = ""
        ds.Paid = "N"
        ds.Checked = "N"
        ds.Dflag = "N"
        ds.Agency = "1"
        ds.Void = "N"
        ds.Glpost = "N"
        '  ds.EncumDate = Date
        ds.StateTax = ""
        ds.JrnlNum = 0
        ds.JrnlLine = 0
        Return ds

    End Function



    Public Shared Function GetOneCCchkstubData(ByVal sqlstmnt As String) As ccckstubData

        Dim ds As New ccckstubData
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read
                ds.ChkNum = CInt(rs("chk_num"))  ' Integer
                ds.ChkDate = CDate(rs("chk_date").ToString)  ' Date
                ds.ChkDirdep = rs("chk_dirdep").ToString  ' String
                ds.PayNum = CInt(rs("pay_num")) ' Integer
                ds.NameKey = rs("name_key").ToString  ' String
                ds.ScreenNam = rs("screen_nam").ToString  ' String
                ds.SortName = rs("sort_name").ToString  ' String
                ds.Desc1 = rs("desc1").ToString  ' String
                ds.Desc2 = rs("desc2").ToString  ' String
                ds.Desc3 = rs("desc3").ToString  ' String
                ds.DeptNum = rs("dept_num").ToString  ' String
                ds.FundCode = rs("fund_code").ToString  ' String
                ds.DisabNum = rs("disab_num").ToString  ' String
                ds.PayFreq = rs("pay_freq").ToString  ' String
                ds.DedDfq = rs("ded_dfq").ToString  ' String
                ds.FwtExmts = CInt(rs("fwt_exmts"))  ' Integer
                ds.SwtExmts = CInt(rs("swt_exmts"))  ' Integer
                ds.BlendOvt = CDec(rs("blend_ovt"))  ' Decimal
                ds.DirHrs = CDbl(rs("dir_hrs")) ' Double
                ds.DirDol = CDec(rs("dir_dol"))   ' Decimal
                ds.IndHrs = CDbl(rs("ind_hrs"))   ' Double
                ds.IndDol = CDec(rs("ind_dol"))   ' Decimal
                ds.NoPayHrs = CDec(rs("no_pay_hrs"))   ' Decimal
                ds.VacHrs = CDbl(rs("vac_hrs"))   ' Double
                ds.VacDol = CDec(rs("vac_dol"))   ' Decimal
                ds.SickHrs = CDbl(rs("sick_hrs"))   ' Double
                ds.SickDol = CDec(rs("Sick_dol"))   ' Decimal
                ds.HolHrs = CDbl(rs("hol_hrs"))   ' Double
                ds.HolDol = CDec(rs("hol_dol"))   ' Decimal
                ds.PersHrs = CDbl(rs("pers_hrs"))   ' Double
                ds.PersDol = CDec(rs("pers_dol"))   ' Decimal
                ds.Makeup = CDec(rs("makeup"))   ' Decimal
                ds.Stipend = CDec(rs("stipend"))   ' Decimal
                ds.Minimum = CDec(rs("minimum"))   ' Decimal
                ds.FullGross = CDec(rs("full_gross"))   ' Decimal
                ds.FedGross = CDec(rs("fed_gross"))   ' Decimal
                ds.FedTax = CDec(rs("fed_tax"))   ' Decimal
                ds.FicaGross = CDec(rs("fica_gross"))   ' Decimal
                ds.FicaTax = CDec(rs("fica_tax"))   ' Decimal
                ds.MedGross = CDec(rs("med_gross"))   ' Decimal
                ds.MedTax = CDec(rs("med_tax"))   ' Decimal
                ds.State1Gross = CDec(rs("state1_gross"))   ' Decimal
                ds.State1Tax = CDec(rs("state1_tax"))   ' Decimal
                ds.State2Gross = CDec(rs("state2_gross"))   ' Decimal
                ds.State2Tax = CDec(rs("state2_tax"))   ' Decimal
                ds.NetPay = CDec(rs("net_pay"))   ' Decimal
                ds.Dduct1Dol = CDec(rs("dduct1_dol"))   ' Decimal
                ds.Dduct1Num = rs("dduct1_num").ToString  ' String
                ds.Dduct2Dol = CDec(rs("dduct2_dol"))   ' Decimal
                ds.Dduct2Num = rs("dduct2_num").ToString  ' String
                ds.Dduct3Dol = CDec(rs("dduct3_dol"))   ' Decimal
                ds.Dduct3Num = rs("dduct3_num").ToString  ' String
                ds.Dduct4Dol = CDec(rs("dduct4_dol"))   ' Decimal
                ds.Dduct4Num = rs("dduct4_num").ToString  ' String
                ds.GlPost = rs("gl_post").ToString  ' String
                ds.EncumDate = CDate(rs("encum_date").ToString)  ' Date
                ds.Recon = rs("recon").ToString  ' String
                ds.RDate = CDate(rs("r_date").ToString)  ' Date
                ds.Void = rs("void").ToString  ' String
                ds.Agency = CInt(rs("agency"))  ' Integer
                ds.Dflag = rs("dflag").ToString  ' String
                ds.AddFwt = CDec(rs("Add_fwt"))   ' Decimal
                ds.AddSwt = CDec(rs("Add_swt"))   ' Decimal
                ds.AddFica = CDec(rs("Add_fica"))   ' Decimal
                ds.AddMed = CDec(rs("Add_med"))   ' Decimal
                ds.State1Code = rs("state1_code").ToString  ' String
                ds.State2Code = rs("state2_code").ToString  ' String
                ds.EntryNum = CInt(rs("entry_num"))  ' Integer
                ds.TdiTax = CDec(rs("tdi_tax"))   ' Decimal
                ds.JrnlNum = CInt(rs("jrnl_num"))  ' Integer
                ds.JrnlLine = CInt(rs("jrnl_line"))  ' Integer


            End While
            rs.Close()
        End Using
        Return ds

    End Function

End Class
