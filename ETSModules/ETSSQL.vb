
Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports System.Collections.Generic
Imports ETS.Common.Module1
Imports PS.Common

Public Class ETSSQL

    Public TagColumnName As String

    Public Shared Sub CheckDataforSQL(ByVal Rowdata As List(Of ETSData))
        'when row column has dashes put brackets around it for SQL compatability

        For Each row In Rowdata
            If row.ColumnName.Contains("-") Then
                row.ColumnName = "[" & row.ColumnName & "]"
            End If
            If row.ColumnName.Contains("print") Then
                row.ColumnName = "[" & row.ColumnName & "]"
            End If
        Next

    End Sub

    Public Shared Function GetData(ByVal TableName As String, ByVal frmWhereClause As String) As List(Of ETSData)
        Dim intcount As Integer = 0
        Dim RetETSData As New List(Of ETSData)

        sqlstmnt = "select column_name ,data_type from information_schema.columns where table_name = '" & TableName & "'"
        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)

            While rs.Read()
                Dim ds As New ETSData
                ds.ColumnNumber = intcount
                ds.ColumnName = rs("Column_Name").ToString
                ds.DataType = rs("Data_type").ToString
                intcount = intcount + 1
                RetETSData.Add(ds)
            End While
            intcount = intcount - 1
            rs.Close()
        End Using

        Using db As Database = New Database(top_data_path)
            If Len(frmWhereClause) <> 0 Then
                sqlstmnt = "select * from " & TableName & " " & frmWhereClause
            Else
                sqlstmnt = "select * from " & TableName & ""
            End If
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                For ETS.Common.Module1.num = 0 To intcount
                    If Not String.IsNullOrEmpty(rs(num).ToString) Then
                        RetETSData.Item(num).ActualData = rs(num).ToString
                    End If
                Next
            End While
            rs.Close()
        End Using

        If intcount = 0 Then        'do not try to edit a blank table
            entry_type = "ADD"

        End If

        Return RetETSData

    End Function

    Public Shared Function GetAllocData(ByVal TableName As String, ByVal frmWhereClause As String) As List(Of String)
        Dim intcount As Integer = 0
        Dim RetAllocData As New List(Of String)

        Using db As Database = New Database(top_data_path)
            If Len(frmWhereClause) <> 0 Then
                sqlstmnt = "select * from " & TableName & frmWhereClause
            Else
                sqlstmnt = "select * from " & TableName & ""
            End If
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                RetAllocData.Add(rs("acct_num").ToString & "**" & rs("factor").ToString)
            End While
            rs.Close()
        End Using

        Return RetAllocData

    End Function

    Public Shared Sub InsertData(ByVal TableName As String, ByVal OneRow As List(Of ETSData))
        sqlstmnt = ""

        sqlstmnt = "Insert into " & TableName & " ("

        For ETS.Common.Module1.num = 0 To OneRow.Count - 1
            sqlstmnt = sqlstmnt & OneRow.Item(num).ColumnName & ","
        Next

        sqlstmnt = Left(sqlstmnt, (Len(sqlstmnt) - 1)) & ") values ("
        For ETS.Common.Module1.num = 0 To OneRow.Count - 1
            sqlstmnt = sqlstmnt & Database.StringParam(OneRow.Item(num).ActualData) & ", "
        Next
        sqlstmnt = Left(sqlstmnt, (Len(sqlstmnt) - 2)) & ")"
        '     sqlstmnt = String.Format(sqlstmnt)
        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            db.ExecuteQuery(sql)
        End Using
    End Sub

    Public Shared Sub UpdateData(ByVal TableName As String, ByVal frmWhereClause As String, ByVal OneRow As List(Of ETSData))
        sqlstmnt = ""

        sqlstmnt = "update " & TableName & " set "

        For ETS.Common.Module1.num = 0 To OneRow.Count - 1
            sqlstmnt = sqlstmnt & OneRow.Item(num).ColumnName & " = " & Database.StringParam(OneRow.Item(num).ActualData) & ","
        Next

        sqlstmnt = Left(sqlstmnt, (Len(sqlstmnt) - 1)) & frmWhereClause

        Using db As Database = New Database(top_data_path)
            db.ExecuteUpdate(sqlstmnt)
        End Using

    End Sub

    Public Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Function GetAcctDesc(ByVal AcctNum As String) As String
        Dim AcctDesc As String = ""
        sqlstmnt = "select acct_Desc from chacct where  acct_num = '" & AcctNum & "'"
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)

            While rs.Read()
                AcctDesc = rs("acct_desc").ToString
            End While
            rs.Close()
        End Using

        Return AcctDesc
    End Function

    Public Shared Function GetAcctNum(ByVal Dpt As String) As List(Of AcctNums)
        Dim AcctNum As New List(Of AcctNums)
        sqlstmnt = "select * from chacct where acct_dpt = '" & Dpt & "' "
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                Dim ds As New AcctNums
                ds.AcctNum = rs("acct_num").ToString
                ds.acct_1 = rs("acct_1").ToString
                ds.acct_2 = rs("acct_2").ToString
                ds.acct_3 = rs("acct_3").ToString
                ds.AcctDesc = rs("acct_desc").ToString
                ds.AcctDpt = rs("acct_dpt").ToString
                ds.AcctOnly = rs("acct_only").ToString
                ds.AcctPgm = rs("acct_pgm").ToString
                ds.AcctTest = rs("acct_test").ToString
                ds.CRDR = rs("cr_dr").ToString
                ds.GlREfNo = rs("gl_ref_no").ToString
                AcctNum.Add(ds)
            End While
            rs.Close()
        End Using

        Return AcctNum
    End Function

    Public Shared Function GetBankData(ByVal Sqlstmnt As String) As List(Of nam_bankData)
        Dim BankData As New List(Of nam_bankData)
        Sqlstmnt = "select * from nam_bank"
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(Sqlstmnt)
            While rs.Read()
                Dim ds As New nam_bankData
                ds.BankKey = rs("bank_key").ToString
                ds.CntctNa1 = rs("cntct_na1").ToString
                ds.CntctNu1 = rs("cntct_nu1").ToString
                ds.CntctNa2 = rs("cntct_na2").ToString
                ds.CntctNu2 = rs("cntct_nu2").ToString
                ds.CrPrefAc = rs("cr_pref_ac").ToString
                ds.DrPrefAc = rs("dr_pref_ac").ToString
                ds.BankReas = rs("bank_reas").ToString
                ds.BkAcctNo = rs("bk_acct_no").ToString
                ds.BkTransit = rs("bk_transit").ToString
                ds.NameKey = rs("name_key").ToString
                ds.ScreenNam = rs("screen_nam").ToString
                ds.SortName = rs("sort_name").ToString
                BankData.Add(ds)
            End While
            rs.Close()
        End Using

        Return BankData
    End Function

    Public Shared Function GetDRAcct(ByVal NameKey As String, ByVal PkgType As String) As String
        Dim AcctNum As String = ""
        Select Case PkgType
            Case "AR"
                sqlstmnt = "select dr_pref_ac from nam_cust where  name_key = '" & NameKey & "'"
            Case "AP"
                sqlstmnt = "select dr_pref_ac from nam_vend where  name_key = '" & NameKey & "'"
        End Select
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                AcctNum = rs("dr_pref_ac").ToString
            End While
            rs.Close()
        End Using

        Return AcctNum
    End Function

    Public Shared Function GetCRAcct(ByVal NameKey As String, ByVal pkgtype As String) As String
        Dim AcctNum As String = ""
        Select Case pkgtype
            Case "AR"
                sqlstmnt = "select cr_pref_ac from nam_cust where  name_key = '" & NameKey & "'"
            Case "AP"
                sqlstmnt = "select cr_pref_ac from nam_vend where  name_key = '" & NameKey & "'"
        End Select
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                AcctNum = rs("cr_pref_ac").ToString
            End While
            rs.Close()
        End Using

        Return AcctNum
    End Function

    Public Shared Function GetTotalAcct(ByVal Sqlstmnt As String) As List(Of AcctNums)
        Dim AcctNum As New List(Of AcctNums)
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(Sqlstmnt)
            While rs.Read()
                Dim ds As New AcctNums
                ds.AcctNum = rs("acctnum").ToString
                ds.acct_1 = rs("acct_1").ToString
                'ds.acct_2 = rs("acct_2").ToString
                'ds.acct_3 = rs("acct_3").ToString
                'ds.AcctDesc = rs("acct_desc").ToString
                'ds.AcctDpt = rs("acct_dpt").ToString
                'ds.AcctOnly = rs("acct_only").ToString
                'ds.AcctPgm = rs("acct_pgm").ToString
                'ds.AcctTest = rs("acct_test").ToString
                'ds.CRDR = rs("cr_dr").ToString
                'ds.GlREfNo = rs("gl_ref_no").ToString
                AcctNum.Add(ds)
            End While
            rs.Close()
        End Using

        Return AcctNum
    End Function

    Public Shared Function GetTotalPayments(ByVal Sqlstmnt As String) As Double
        Dim TotalPayments As Double = 0
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(Sqlstmnt)
            While rs.Read()
                TotalPayments = TotalPayments + CDbl(rs("chk_alloc").ToString)
            End While
            rs.Close()
        End Using

        Return TotalPayments
    End Function

    Public Shared Function GetAgencyData(ByVal Sqlstmnt As String) As AgencyData
        Dim AgencyData As New AgencyData

        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(Sqlstmnt)
            Dim ds As New AgencyData
            While rs.Read()
                ds.Agency = CInt(rs("agency").ToString)
                ds.AgencyName = rs("agency_name").ToString
                ds.AgencyLine2 = rs("agency_line2").ToString
                ds.Address1 = rs("Address1").ToString
                ds.Address2 = rs("Address2").ToString
                ds.City = rs("city").ToString
                ds.State = rs("state").ToString
                ds.Zip = rs("zip").ToString
                ds.ApCntrNu = rs("ap_cntr_nu").ToString
                ds.DrvName = rs("drv_name").ToString
            End While
            rs.Close()
        End Using
        Return AgencyData
    End Function

    Public Shared Function GetAuthoData(ByVal Sqlstmnt As String) As List(Of AuthoData)
        Dim AuthoData As New List(Of AuthoData)

        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(Sqlstmnt)
            While rs.Read()
                Dim ds As New AuthoData
                ds.BNum = rs("b_num").ToString
                ds.NameKey = rs("name_key").ToString
                ds.SortName = rs("sort_name").ToString
                ds.AuthoNum = rs("sutho_num").ToString
                ds.ContractKey = rs("contract_key").ToString
                ds.AuthoBeg = CDate(rs("autho_beg"))
                ds.AuthoEnd = CDate(rs("autho_end"))
                ds.Active = rs("active").ToString
                ds.PayCat = rs("pay_cat").ToString
                ds.CrAcctNu = rs("cr_acct_nu").ToString
                ds.DrAcctNu = rs("dr_acct_nu").ToString
                ds.CustKey = rs("cust_key").ToString
                ds.UnitRate = CDec(CDbl(rs("unit_rate").ToString))
                ds.Credit = CDec(CDbl(rs("credit").ToString))
                ds.TieBrkNum = rs("tie_brk_num").ToString
                ds.TieDesc = rs("tie_desc").ToString
                ds.ServDesc = rs("serv_desc").ToString
                ds.ProgDesc = rs("prog_desc").ToString
                ds.Clothing = rs("clothing").ToString
                ds.Status = rs("status").ToString
                ds.Region = rs("region").ToString
                ds.Area = rs("area").ToString
                ds.Sw = rs("sw").ToString
                ds.ConPurNum = rs("con_pur_num").ToString
                ds.ConsNum = rs("cons_num").ToString
                ds.SwNameKey = rs("sw_name_key").ToString
                ds.EntryDate = CDate(rs("entry_date"))
                ds.Dflag = rs("dflag").ToString
                ds.Agency = CInt(rs("agency").ToString)
                AuthoData.Add(ds)
            End While
            rs.Close()
        End Using
        Return AuthoData
    End Function

    Public Shared Function GetAttendanceData(ByVal Sqlstmnt As String) As List(Of AttendData)
        Dim AttendData As New List(Of AttendData)

        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(Sqlstmnt)
            While rs.Read()
                Dim ds As New AttendData
                ds.BNum = rs("b_num").ToString
                ds.NameKey = rs("name_key").ToString
                ds.ContractKey = rs("Contract_key").ToString
                ds.ScreenNam = rs("screen_nam").ToString
                ds.SortName = rs("sort_name").ToString
                ds.AuthoNum = rs("autho_num").ToString
                ds.BillType = rs("bill_type").ToString
                ds.PvForm = rs("pv_form").ToString
                ds.RptType = rs("rpt_type").ToString
                ds.UnitRate = CDec(CDbl(rs("unit_rate").ToString))
                ds.Offset = CDec(CDbl(rs("offset").ToString))
                ds.SlotNum = CInt(rs("slot_num").ToString)
                ds.NameChk = rs("name_chk").ToString
                ds.SsNum = rs("ss_num").ToString
                ds.MedNum = rs("med_num").ToString
                ds.AttDate = CDate(rs("att_date"))
                ds.AttCode = rs("att_code").ToString
                ds.AttUnit = CDbl(rs("att_unit").ToString)
                ds.InvoiceDate = CDate(rs("invoice_Date"))
                ds.Invoice = rs("invoice").ToString
                ds.CustNum = rs("cust_num").ToString
                ds.DrAcctNu = rs("dr_acct_nu").ToString
                ds.CrAcctNu = rs("cr_acct_nu").ToString
                ds.EntryDate = CDate(rs("entry_date"))
                ds.Dflag = rs("dflag").ToString
                ds.Agency = CInt(rs("agency").ToString)
                ds.Void = rs("void").ToString
                ds.ClientPct = CDbl(rs("client_pct").ToString)
                AttendData.Add(ds)
            End While
            rs.Close()
        End Using

        Return AttendData

    End Function

    'Public Shared Function GetBlankAttendanceData() As List(Of AttendData)
    '    Dim AttendData As New List(Of AttendData)
    '    Dim ds As New AttendData
    '    ds.BNum = ""  'rs("b_num").ToString
    '    ds.NameKey = ""  'rs("name_key").ToString
    '    ds.ContractKey = "" ' "rs("Contract_key").ToString
    '    ds.ScreenNam = "" ' "rs("screen_nam").ToString
    '    ds.SortName = "" ' "rs("sort_name").ToString
    '    ds.AuthoNum = "" ' "rs("autho_num").ToString
    '    ds.BillType = "" ' "rs("bill_type").ToString
    '    ds.PvForm = ""  '"rs("pv_form").ToString
    '    ds.RptType = ""  '"rs("rpt_type").ToString
    '    ds.UnitRate = 0 ' CDec(CDbl(""  "rs("unit_rate").ToString))
    '    ds.Offset = 0 'CDec(CDbl(""  "rs("offset").ToString))
    '    ds.SlotNum = 0 'CInt(""  "rs("slot_num").ToString)
    '    ds.NameChk = "" ' "rs("name_chk").ToString
    '    ds.SsNum = "" ' "rs("ss_num").ToString
    '    ds.MedNum = "" ' "rs("med_num").ToString
    '    'ds.AttDate = CDate(""  "rs("att_date"))
    '    ds.AttCode = "" ' "rs("att_code").ToString
    '    ds.AttUnit = 0 ' CDbl(""  "rs("att_unit").ToString)
    '    'ds.InvoiceDate = CDate(""  "rs("invoice_Date"))
    '    ds.Invoice = "" ' "rs("invoice").ToString
    '    ds.CustNum = "" ' "rs("cust_num").ToString
    '    ds.DrAcctNu = "" ' "rs("dr_acct_nu").ToString
    '    ds.CrAcctNu = ""  '"rs("cr_acct_nu").ToString
    '    'ds.EntryDate = CDate(""  "rs("entry_date"))
    '    ds.Dflag = "" ' "rs("dflag").ToString
    '    ds.Agency = 1 'CInt(""  "rs("agency").ToString)
    '    ds.Void = "" ' "rs("void").ToString
    '    ds.ClientPct = 0 ' CDbl(""  "rs("client_pct").ToString)
    '    AttendData.Add(ds)

    '    Return AttendData

    'End Function

    Public Shared Function GetBlankAttendanceData() As AttendData
        Dim ds As New AttendData
        ds.BNum = ""  'rs("b_num").ToString
        ds.NameKey = ""  'rs("name_key").ToString
        ds.ContractKey = "" ' "rs("Contract_key").ToString
        ds.ScreenNam = "" ' "rs("screen_nam").ToString
        ds.SortName = "" ' "rs("sort_name").ToString
        ds.AuthoNum = "" ' "rs("autho_num").ToString
        ds.BillType = "" ' "rs("bill_type").ToString
        ds.PvForm = ""  '"rs("pv_form").ToString
        ds.RptType = ""  '"rs("rpt_type").ToString
        ds.UnitRate = 0 ' CDec(CDbl(""  "rs("unit_rate").ToString))
        ds.Offset = 0 'CDec(CDbl(""  "rs("offset").ToString))
        ds.SlotNum = 0 'CInt(""  "rs("slot_num").ToString)
        ds.NameChk = "" ' "rs("name_chk").ToString
        ds.SsNum = "" ' "rs("ss_num").ToString
        ds.MedNum = "" ' "rs("med_num").ToString
        'ds.AttDate = CDate(""  "rs("att_date"))
        ds.AttCode = "" ' "rs("att_code").ToString
        ds.AttUnit = 0 ' CDbl(""  "rs("att_unit").ToString)
        'ds.InvoiceDate = CDate(""  "rs("invoice_Date"))
        ds.Invoice = "" ' "rs("invoice").ToString
        ds.CustNum = "" ' "rs("cust_num").ToString
        ds.DrAcctNu = "" ' "rs("dr_acct_nu").ToString
        ds.CrAcctNu = ""  '"rs("cr_acct_nu").ToString
        'ds.EntryDate = CDate(""  "rs("entry_date"))
        ds.Dflag = "N" ' "rs("dflag").ToString
        ds.Agency = 1 'CInt(""  "rs("agency").ToString)
        ds.Void = "N" ' "rs("void").ToString
        ds.ClientPct = 0 ' CDbl(""  "rs("client_pct").ToString)

        Return ds

    End Function

    Public Shared Function GetAttendReportData(ByVal Sqlstmnt As String) As List(Of AttendReportData)
        Dim AttendReportData As New List(Of AttendReportData)

        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(Sqlstmnt)
            While rs.Read()
                Dim ds As New AttendReportData
                ds.BNum = rs("b_num").ToString
                ds.NameKey = rs("name_key").ToString
                ds.ContractKey = rs("Contract_key").ToString
                ds.ScreenNam = rs("screen_nam").ToString
                ds.SortName = rs("sort_name").ToString
                ds.AuthoNum = rs("autho_num").ToString
                ds.BillType = rs("bill_type").ToString
                ds.PvForm = rs("pv_form").ToString
                ds.RptType = rs("rpt_type").ToString
                ds.UnitRate = CDec(CDbl(rs("unit_rate").ToString))
                ds.Offset = CDec(CDbl(rs("offset").ToString))
                ds.SlotNum = CInt(rs("slot_num").ToString)
                ds.NameChk = rs("name_chk").ToString
                ds.SsNum = rs("ss_num").ToString
                ds.MedNum = rs("med_num").ToString
                ds.AttBeg = CDate(rs("att_beg"))
                ds.AttCode = rs("att_code").ToString
                ds.AttUnit = CDbl(rs("att_unit").ToString)
                ds.InvoiceDate = CDate(rs("invoice_Date"))
                ds.Invoice = rs("invoice").ToString
                ds.CustNum = rs("cust_num").ToString
                ds.DrAcctNu = rs("dr_acct_nu").ToString
                ds.CrAcctNu = rs("cr_acct_nu").ToString
                ds.EntryDate = CDate(rs("entry_date"))
                ds.Dflag = rs("dflag").ToString
                ds.Agency = CInt(rs("agency").ToString)
                ds.D1 = rs("d1").ToString
                ds.D2 = rs("d2").ToString
                ds.D3 = rs("d3").ToString
                ds.D4 = rs("d4").ToString
                ds.D5 = rs("d5").ToString
                ds.D6 = rs("d6").ToString
                ds.D7 = rs("d7").ToString
                ds.D8 = rs("d8").ToString
                ds.D9 = rs("d9").ToString
                ds.D10 = rs("d10").ToString
                ds.D11 = rs("d11").ToString
                ds.D12 = rs("d12").ToString
                ds.D13 = rs("d13").ToString
                ds.D14 = rs("d14").ToString
                ds.D15 = rs("d15").ToString
                ds.D16 = rs("d16").ToString
                ds.D17 = rs("d17").ToString
                ds.D18 = rs("d18").ToString
                ds.D19 = rs("d19").ToString
                ds.D20 = rs("d20").ToString
                ds.D21 = rs("d21").ToString
                ds.D22 = rs("d22").ToString
                ds.D23 = rs("d23").ToString
                ds.D24 = rs("d24").ToString
                ds.D25 = rs("d25").ToString
                ds.D26 = rs("d26").ToString
                ds.D27 = rs("d27").ToString
                ds.D28 = rs("d28").ToString
                ds.D29 = rs("d29").ToString
                ds.D30 = rs("d30").ToString
                ds.D31 = rs("d31").ToString
                ds.PayCat = rs("pay_cat").ToString
                ds.AttEnd = CDate(rs("att_end").ToString)
                ds.DolTot = CDec(rs("dol_tot").ToString)
                ds.UnitTot = CDec(rs("unit_tot").ToString)
                ds.Void = rs("void").ToString
                ds.ClientPct = CDbl(rs("client_pct").ToString)
                AttendReportData.Add(ds)
            End While
            rs.Close()
        End Using

        Return AttendReportData

    End Function

    Public Shared Function GetOneAttendReportData(ByVal Sqlstmnt As String) As AttendReportData
        Dim ds As New AttendReportData
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(Sqlstmnt)
            While rs.Read
                ds.BNum = rs("b_num").ToString
                ds.NameKey = rs("name_key").ToString
                ds.ContractKey = rs("Contract_key").ToString
                ds.ScreenNam = rs("screen_nam").ToString
                ds.SortName = rs("sort_name").ToString
                ds.AuthoNum = rs("autho_num").ToString
                ds.BillType = rs("bill_type").ToString
                ds.PvForm = rs("pv_form").ToString
                ds.RptType = rs("rpt_type").ToString
                ds.UnitRate = CDec(CDbl(rs("unit_rate").ToString))
                ds.Offset = CDec(CDbl(rs("offset").ToString))
                ds.SlotNum = CInt(rs("slot_num").ToString)
                ds.NameChk = rs("name_chk").ToString
                ds.SsNum = rs("ss_num").ToString
                ds.MedNum = rs("med_num").ToString
                ds.AttBeg = CDate(rs("att_beg"))
                ds.AttCode = rs("att_code").ToString
                ds.AttUnit = CDbl(rs("att_unit").ToString)
                ds.InvoiceDate = CDate(rs("invoice_Date"))
                ds.Invoice = rs("invoice").ToString
                ds.CustNum = rs("cust_num").ToString
                ds.DrAcctNu = rs("dr_acct_nu").ToString
                ds.CrAcctNu = rs("cr_acct_nu").ToString
                ds.EntryDate = CDate(rs("entry_date"))
                ds.Dflag = rs("dflag").ToString
                ds.Agency = CInt(rs("agency").ToString)
                ds.Void = rs("void").ToString
                ds.ClientPct = CDbl(rs("client_pct").ToString)
            End While
            rs.Close()
        End Using

        Return ds

    End Function

    Public Shared Function GetBlankAttendReportData() As AttendReportData
        Dim ds As New AttendReportData
        ds.BNum = ""  'rs("b_num").ToString
        ds.NameKey = ""  'rs("name_key").ToString
        ds.ContractKey = ""  'rs("Contract_key").ToString
        ds.ScreenNam = ""  'rs("screen_nam").ToString
        ds.SortName = ""  'rs("sort_name").ToString
        ds.AuthoNum = ""  'rs("autho_num").ToString
        ds.BillType = ""  'rs("bill_type").ToString
        ds.PvForm = ""  'rs("pv_form").ToString
        ds.RptType = ""  'rs("rpt_type").ToString
        ds.UnitRate = 0 'CDec(CDbl(rs("unit_rate").ToString))
        ds.Offset = 0 'CDec(CDbl(rs("offset").ToString))
        ds.SlotNum = 0 'CInt(rs("slot_num").ToString)
        ds.NameChk = ""  'rs("name_chk").ToString
        ds.SsNum = ""  'rs("ss_num").ToString
        ds.MedNum = ""  'rs("med_num").ToString
        '    ds.AttDate = CDate(rs("att_date"))
        ds.AttCode = ""  'rs("att_code").ToString
        ds.AttUnit = 0 'CDbl(rs("att_unit").ToString)
        '   ds.InvoiceDate = CDate(rs("invoice_Date"))
        ds.Invoice = ""  'rs("invoice").ToString
        ds.CustNum = ""  'rs("cust_num").ToString
        ds.DrAcctNu = ""  'rs("dr_acct_nu").ToString
        ds.CrAcctNu = ""  'rs("cr_acct_nu").ToString
        '  ds.EntryDate = CDate(rs("entry_date"))
        ds.Dflag = "N"  'rs("dflag").ToString
        ds.Agency = 1 'CInt(rs("agency").ToString)
        ds.Void = "N"  'rs("void").ToString
        ds.ClientPct = 0 'CDbl(rs("client_pct").ToString)
        Return ds

    End Function

    Public Shared Function GetBillControlData(ByVal Sqlstmnt As String) As List(Of BillControlData)
        Dim BillControlData As New List(Of BillControlData)

        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(Sqlstmnt)
            While rs.Read()
                Dim ds As New BillControlData
                ds.ContractKey = rs("Contract_key").ToString
                ds.ServBeg = CDate(rs("serv_beg"))
                ds.ServEnd = CDate(rs("serv_end"))
                ds.BillDate = CDate(rs("bill_Date"))
                ds.Invoice = rs("invoice").ToString
                ds.AmtBilled = CDec(rs("amt_billed").ToString)
                ds.Comment = rs("comment").ToString
                ds.InvNum = CInt(rs("inv_num").ToString)
                BillControlData.Add(ds)
            End While
            rs.Close()
        End Using
        Return BillControlData
    End Function

    Public Shared Function GetBlankBillControlData(ByVal Sqlstmnt As String) As List(Of BillControlData)
        Dim BillControlData As New List(Of BillControlData)
        Dim ds As New BillControlData
        ds.ContractKey = ""
        ' ds.ServBeg = CDate(rs("serv_beg"))
        ' ds.ServEnd = CDate(rs("serv_end"))
        ' ds.BillDate = CDate(rs("bill_Date"))
        ds.Invoice = ""
        ds.AmtBilled = 0
        ds.Comment = ""
        ds.InvNum = 0
        BillControlData.Add(ds)

        Return BillControlData
    End Function

    Public Shared Function GetClientBaseData(ByVal sqlstmnt As String) As List(Of ClientBaseData)
        Dim ClientBaseData As New List(Of ClientBaseData)

        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                Dim ds As New ClientBaseData
                ds.NameKey = rs("name_key").ToString
                ds.ScreenNam = rs("screen_nam").ToString
                ds.SortName = rs("sort_name").ToString
                ds.AdmitDate = CDate(rs("admit_date"))
                ds.TermDate = CDate(rs("term_Date"))
                ds.ActStatus = rs("act_status").ToString
                ds.Sex = rs("sex").ToString
                ds.Dob = CDate(rs("dob"))
                ds.Birthplace = rs("birthplace").ToString
                ds.SsNum = rs("ss_num").ToString
                ds.MedNum = rs("med_num").ToString
                ds.MassHNum = rs("mass_h_num").ToString
                ds.MisNum = rs("mis_num").ToString
                ds.OtherNum = rs("other_num").ToString
                ds.AttNum = rs("att_num").ToString
                ds.Region = rs("region").ToString
                ds.Town = rs("town").ToString
                ds.Refer = rs("refer").ToString
                ds.Race = rs("race").ToString
                ds.Memo1 = rs("memo1").ToString
                ds.Memo2 = rs("memo2").ToString
                ds.Memo3 = rs("memo3").ToString
                ds.Code1 = rs("code1").ToString
                ds.Code2 = rs("code2").ToString
                ds.Code3 = rs("code3").ToString
                ds.Code4 = rs("code4").ToString
                ds.EntryDate = CDate(rs("entry_Date"))
                ds.Dflag = rs("dflag").ToString
                ds.Agency = CInt(rs("agency").ToString)
                ClientBaseData.Add(ds)
            End While
            rs.Close()
        End Using
        Return ClientBaseData
    End Function

    Public Shared Function GetBlankClientBaseData() As ClientBaseData
        Dim ds As New ClientBaseData

        ds.NameKey = ""  'rs("name_key").ToString
        ds.ScreenNam = ""  'rs("screen_nam").ToString
        ds.SortName = ""  'rs("sort_name").ToString
        '         ds.AdmitDate = CDate(""  'rs("admit_date"))
        '        ds.TermDate = CDate(""  'rs("term_Date"))
        ds.ActStatus = "Y"  'rs("act_status").ToString
        ds.Sex = ""  'rs("sex").ToString
        '       ds.Dob = CDate(""  'rs("dob"))
        ds.Birthplace = ""  'rs("birthplace").ToString
        ds.SsNum = ""  'rs("ss_num").ToString
        ds.MedNum = ""  'rs("med_num").ToString
        ds.MassHNum = ""  'rs("mass_h_num").ToString
        ds.MisNum = ""  'rs("mis_num").ToString
        ds.OtherNum = ""  'rs("other_num").ToString
        ds.AttNum = ""  'rs("att_num").ToString
        ds.Region = ""  'rs("region").ToString
        ds.Town = ""  'rs("town").ToString
        ds.Refer = ""  'rs("refer").ToString
        ds.Race = ""  'rs("race").ToString
        ds.Memo1 = ""  'rs("memo1").ToString
        ds.Memo2 = ""  'rs("memo2").ToString
        ds.Memo3 = ""  'rs("memo3").ToString
        ds.Code1 = ""  'rs("code1").ToString
        ds.Code2 = ""  'rs("code2").ToString
        ds.Code3 = ""  'rs("code3").ToString
        ds.Code4 = ""  'rs("code4").ToString
        ds.EntryDate = CDate(Today)
        ds.Dflag = ""  'rs("dflag").ToString
        ds.Agency = 1

        Return ds
    End Function

    Public Shared Function GetContractData(ByVal Sqlstmnt As String) As List(Of ContractData)
        Dim ContractData As New List(Of ContractData)

        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(Sqlstmnt)
            While rs.Read()
                Dim ds As New ContractData
                ds.ContractKey = rs("contract_key").ToString
                ds.ContIdNum = rs("cont_id_num").ToString
                ds.MmarsNum = rs("mmars_num").ToString
                ds.AmendNum = rs("amend_num").ToString
                ds.EntryDate = CDate(rs("entry_Date"))
                ds.ContDesc = rs("cont_desc").ToString
                ds.FiscalYr = rs("fiscal_yr").ToString
                ds.Active = rs("active").ToString
                ds.BillType = rs("bill_type").ToString
                ds.PvForm = rs("pv_form").ToString
                ds.RptType = rs("rpt_type").ToString
                ds.UnitRate = CDec(rs("unit_rate").ToString)
                ds.ContBegD = CDate(rs("cont_beg_d"))
                ds.ContEndD = CDate(rs("cont_end_d"))
                ds.AmndBegD = CDate(rs("amnd_beg_d"))
                ds.AmndEndD = CDate(rs("amnd_end_d"))
                ds.LastInvnum = rs("last_invnum").ToString
                ds.LastBilldate = CDate(rs("last_billdate"))
                ds.ContOffset = CDec(rs("unit_rate").ToString)
                ds.BillOffset = CDec(rs("unit_rate").ToString)
                ds.DrAcctNu = rs("dr_acct_nu").ToString
                ds.CrAcctNu = rs("cr_acct_nu").ToString
                ds.NameKey = rs("name_key").ToString
                ds.ScreenNam = rs("screen_nam").ToString
                ds.ContUnits = CDbl(rs("cont_units").ToString)
                ds.ContDol = CDec(rs("cont_dol").ToString)
                ds.AmendUnits = CDbl(rs("amend_units").ToString)
                ds.AmendDol = CDec(rs("amend_dol").ToString)
                ds.MaxUnits = CDec(rs("max_units").ToString)
                ds.MaxDol = CDec(rs("max_dol").ToString)
                ds.YtdUnits = CDbl(rs("ytd_units").ToString)
                ds.YtdDol = CDec(rs("ytd_dol").ToString)
                ds.SeedUnits = CDbl(rs("seed_units").ToString)
                ds.SeedDol = CDec(rs("seed_dol").ToString)
                ds.MonthUnits = CDbl(rs("month_units").ToString)
                ds.MonthDol = CDec(rs("month_dol").ToString)
                ds.RemUnits = CDbl(rs("rem_units").ToString)
                ds.RemDol = CDec(rs("rem_dol").ToString)
                ds.RedpyDol = CDec(rs("redpy_dol").ToString)
                ds.FlatRate = CDec(rs("flat_rate").ToString)
                ds.Code1 = rs("code1").ToString
                ds.Code2 = rs("code2").ToString
                ds.Code3 = rs("code3").ToString
                ds.BeginDate = CDate(rs("begin_date"))
                ds.EndDate = CDate(rs("end_date"))
                ds.NamkeyDss = rs("namkey_dss").ToString
                ds.PnumDss = rs("pnum_dss").ToString
                ds.NamkeySdr = rs("namkey_sdr").ToString
                ds.PnumSdr = rs("pnum_sdr").ToString
                ds.PrgnamSdr = rs("prgnam_sdr").ToString
                ds.PrgcodeSdr = rs("prgcode_Sdr").ToString
                ds.PrgduraSdr = rs("prgdura_sdr").ToString
                ds.PrepBy = rs("prep_by").ToString
                ds.StateAgcy = rs("state_agcy").ToString
                ds.ReimbType = rs("reimb_type").ToString
                ds.Desc1 = rs("desc1").ToString
                ds.Desc2 = rs("desc2").ToString
                ds.Desc3 = rs("desc3").ToString
                ds.NamkeyLea = rs("namkey_lea").ToString
                ds.PnumLea = rs("pnum_lea").ToString
                ds.PrgnamLea = rs("prgnam_lea").ToString
                ds.PrgcodeLea = rs("prgcode_lea").ToString
                ds.PrgduraLea = rs("prgdura_lea").ToString
                ds.FedidNum = rs("fedid_num").ToString
                ds.AnndaysSch = rs("anndays_Sch").ToString
                ds.AnndaysRes = rs("anndays_res").ToString
                ds.ProgType = rs("prog_type").ToString
                ds.LeaTerms = rs("lea_terms").ToString
                ds.LeaComment = rs("lea_Comment").ToString
                ds.LeaOrderNu = rs("lea_order_nu").ToString
                ds.Dflag = rs("dflag").ToString
                ds.Agency = CInt(rs("agency").ToString)
                ds.InvType = rs("inv_type").ToString
                ds.ProvNumMed = rs("prov_num_med").ToString
                ds.ProsNumMed = rs("pros_num_med").ToString
                ds.PlaceService = rs("place_service").ToString
                ds.BillableCodes = rs("billable_codes").ToString
                ds.InvString = rs("inv_string").ToString
                ds.ProgNum = rs("prog_num").ToString
                ds.DefInc = rs("def_inc").ToString
                ds.LifeAmend = rs("life_amend").ToString
                ContractData.Add(ds)
            End While
            rs.Close()
        End Using
        Return ContractData
    End Function

    Public Shared Function GetOneContractData(ByVal Sqlstmnt As String) As ContractData
        Dim ds As New ContractData
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(Sqlstmnt)
            While rs.Read()
                ds.ContractKey = rs("contract_key").ToString
                ds.ContIdNum = rs("cont_id_num").ToString
                ds.MmarsNum = rs("mmars_num").ToString
                ds.AmendNum = rs("amend_num").ToString
                ds.EntryDate = CDate(rs("entry_Date"))
                ds.ContDesc = rs("cont_desc").ToString
                ds.FiscalYr = rs("fiscal_yr").ToString
                ds.Active = rs("active").ToString
                ds.BillType = rs("bill_type").ToString
                ds.PvForm = rs("pv_form").ToString
                ds.RptType = rs("rpt_type").ToString
                ds.UnitRate = CDec(rs("unit_rate").ToString)
                ds.ContBegD = CDate(rs("cont_beg_d"))
                ds.ContEndD = CDate(rs("cont_end_d"))
                ds.AmndBegD = CDate(rs("amnd_beg_d"))
                ds.AmndEndD = CDate(rs("amnd_end_d"))
                ds.LastInvnum = rs("last_invnum").ToString
                ds.LastBilldate = CDate(rs("last_billdate"))
                ds.ContOffset = CDec(rs("unit_rate").ToString)
                ds.BillOffset = CDec(rs("unit_rate").ToString)
                ds.DrAcctNu = rs("dr_acct_nu").ToString
                ds.CrAcctNu = rs("cr_acct_nu").ToString
                ds.NameKey = rs("name_key").ToString
                ds.ScreenNam = rs("screen_nam").ToString
                ds.ContUnits = CDbl(rs("cont_units").ToString)
                ds.ContDol = CDec(rs("cont_dol").ToString)
                ds.AmendUnits = CDbl(rs("amend_units").ToString)
                ds.AmendDol = CDec(rs("amend_dol").ToString)
                ds.MaxUnits = CDec(rs("max_units").ToString)
                ds.MaxDol = CDec(rs("max_dol").ToString)
                ds.YtdUnits = CDbl(rs("ytd_units").ToString)
                ds.YtdDol = CDec(rs("ytd_dol").ToString)
                ds.SeedUnits = CDbl(rs("seed_units").ToString)
                ds.SeedDol = CDec(rs("seed_dol").ToString)
                ds.MonthUnits = CDbl(rs("month_units").ToString)
                ds.MonthDol = CDec(rs("month_dol").ToString)
                ds.RemUnits = CDbl(rs("rem_units").ToString)
                ds.RemDol = CDec(rs("rem_dol").ToString)
                ds.RedpyDol = CDec(rs("redpy_dol").ToString)
                ds.FlatRate = CDec(rs("flat_rate").ToString)
                ds.Code1 = rs("code1").ToString
                ds.Code2 = rs("code2").ToString
                ds.Code3 = rs("code3").ToString
                ds.BeginDate = CDate(rs("begin_date"))
                ds.EndDate = CDate(rs("end_date"))
                ds.NamkeyDss = rs("namkey_dss").ToString
                ds.PnumDss = rs("pnum_dss").ToString
                ds.NamkeySdr = rs("namkey_sdr").ToString
                ds.PnumSdr = rs("pnum_sdr").ToString
                ds.PrgnamSdr = rs("prgnam_sdr").ToString
                ds.PrgcodeSdr = rs("prgcode_Sdr").ToString
                ds.PrgduraSdr = rs("prgdura_sdr").ToString
                ds.PrepBy = rs("prep_by").ToString
                ds.StateAgcy = rs("state_agcy").ToString
                ds.ReimbType = rs("reimb_type").ToString
                ds.Desc1 = rs("desc1").ToString
                ds.Desc2 = rs("desc2").ToString
                ds.Desc3 = rs("desc3").ToString
                ds.NamkeyLea = rs("namkey_lea").ToString
                ds.PnumLea = rs("pnum_lea").ToString
                ds.PrgnamLea = rs("prgnam_lea").ToString
                ds.PrgcodeLea = rs("prgcode_lea").ToString
                ds.PrgduraLea = rs("prgdura_lea").ToString
                ds.FedidNum = rs("fedid_num").ToString
                ds.AnndaysSch = rs("anndays_Sch").ToString
                ds.AnndaysRes = rs("anndays_res").ToString
                ds.ProgType = rs("prog_type").ToString
                ds.LeaTerms = rs("lea_terms").ToString
                ds.LeaComment = rs("lea_Comment").ToString
                ds.LeaOrderNu = rs("lea_order_nu").ToString
                ds.Dflag = rs("dflag").ToString
                ds.Agency = CInt(rs("agency").ToString)
                ds.InvType = rs("inv_type").ToString
                ds.ProvNumMed = rs("prov_num_med").ToString
                ds.ProsNumMed = rs("pros_num_med").ToString
                ds.PlaceService = rs("place_service").ToString
                ds.BillableCodes = rs("billable_codes").ToString
                ds.InvString = rs("inv_string").ToString
                ds.ProgNum = rs("prog_num").ToString
                ds.DefInc = rs("def_inc").ToString
                ds.LifeAmend = rs("life_amend").ToString
            End While
            rs.Close()
        End Using
        Return ds
    End Function

    Public Shared Function GetOneDepositData(ByVal sqlstmnt As String) As ACHXferAcctsData
        Dim ds As New ACHXferAcctsData
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                ds.NameKey = rs("name_key").ToString
                ds.ScreenNam = rs("screen_nam").ToString
                ds.PkgType = rs("PkgType").ToString
                ds.Bk1Aba = rs("bk1_aba").ToString
                ds.Bk1Num = rs("bk1_num").ToString
                ds.Bk1actNum = rs("bk1act_num").ToString
                ds.Bk1COrS = rs("bk1_c-or-s").ToString
                ds.Bk1Amt = CDec(rs("bk1_amt").ToString)
                ds.Bk2Aba = rs("bk2_aba").ToString
                ds.Bk2Num = rs("bk2_num").ToString
                ds.Bk2actNum = rs("bk2act_num").ToString
                ds.Bk2COrS = rs("bk2_c-or-s").ToString
                ds.Bk2Amt = CDec(rs("bk2_amt").ToString)
                ds.Bk3Aba = rs("bk3_aba").ToString
                ds.Bk3Num = rs("bk3_num").ToString
                ds.Bk3actNum = rs("bk3act_num").ToString
                ds.Bk3COrS = rs("bk3_c-or-s").ToString
                ds.Bk3Amt = CDec(rs("bk3_amt").ToString)
                ds.Bk4Aba = rs("bk4_aba").ToString
                ds.Bk4Num = rs("bk4_num").ToString
                ds.Bk4actNum = rs("bk4act_num").ToString
                ds.Bk4COrS = rs("bk4_c-or-s").ToString
                ds.Bk4Amt = CDec(rs("bk4_amt").ToString)
                If Not IsDBNull(rs("bk1_chg_date")) Then
                    ds.Bk1ChgDate = CDate(rs("bk1_chg_date"))
                End If
                If Not IsDBNull(rs("bk2_chg_date")) Then
                    ds.Bk2ChgDate = CDate(rs("bk2_chg_date"))
                End If
                If Not IsDBNull(rs("bk3_chg_date")) Then
                    ds.Bk3ChgDate = CDate(rs("bk3_chg_date"))
                End If
                If Not IsDBNull(rs("bk4_chg_date")) Then
                    ds.Bk4ChgDate = CDate(rs("bk4_chg_date"))
                End If
                ds.Void = rs("void").ToString
                ds.Dflag = rs("dflag").ToString
                ds.Agency = CInt(rs("agency").ToString)
            End While
            rs.Close()
        End Using
        Return ds
    End Function

    Public Shared Function GetBlankDepositData() As ACHXferAcctsData
        Dim ds As New ACHXferAcctsData
        ds.NameKey = "" '"" '("name_key").ToString
        ds.ScreenNam = "" '("screen_nam").ToString
        ds.PkgType = "AP"
        ds.Bk1Aba = "" '("bk1_aba").ToString
        ds.Bk1Num = "" '("bk1_num").ToString
        ds.Bk1actNum = "" '("bk1act_num").ToString
        ds.Bk1COrS = "" '("bk1_c-or-s").ToString
        ds.Bk1Amt = 0 '("bk1_amt").ToString)
        ds.Bk2Aba = "" '("bk2_aba").ToString
        ds.Bk2Num = "" '("bk2_num").ToString
        ds.Bk2actNum = "" '("bk2act-num").ToString
        ds.Bk2COrS = "" '("bk2_c-or-s").ToString
        ds.Bk2Amt = 0 '("bk2_amt").ToString)
        ds.Bk3Aba = "" '("bk3_aba").ToString
        ds.Bk3Num = "" '("bk3_num").ToString
        ds.Bk3actNum = "" '("bk3act_num").ToString
        ds.Bk3COrS = "" '("bk3_c-or-s").ToString
        ds.Bk3Amt = 0 '("bk3_amt").ToString)
        ds.Bk4Aba = "" '("bk4_aba").ToString
        ds.Bk4Num = "" '("bk4_num").ToString
        ds.Bk4actNum = "" '("bk4act_num").ToString
        ds.Bk4COrS = "" '("bk4_c-or-s").ToString
        ds.Bk4Amt = 0 '("bk4_amt").ToString)
        ds.Bk1ChgDate = Today 'CDate(rs("bk1_chg_date"))
        ds.Bk2ChgDate = Today 'CDate(rs("bk2_chg_date"))
        ds.Bk3ChgDate = Today 'CDate(rs("bk3_chg_date"))
        ds.Bk4ChgDate = Today 'rs("bk4_chg_date"))
        ds.Void = "N"   'rs("void").ToString
        ds.Dflag = "N"  ' rs("dflag").ToString
        ds.Agency = 1   'CInt(rs("agency").ToString)

        Return ds
    End Function

    Public Shared Function GetFundData(ByVal Sqlstmnt As String) As List(Of FundingData)
        Dim FundingData As New List(Of FundingData)

        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(Sqlstmnt)
            While rs.Read()
                Dim ds As New FundingData
                ds.BNum = rs("b_num").ToString
                ds.NameKey = rs("name_key").ToString
                ds.ScreenNam = rs("screen_nam").ToString
                ds.SortName = rs("sort_name").ToString
                ds.ContractKey = rs("contract_key").ToString
                ds.ContIdNum = rs("cont_id_num").ToString
                ds.MmarsNum = rs("mmars_num").ToString
                ds.AmendNum = rs("amend_num").ToString
                ds.EntryDate = CDate(rs("entry_date"))
                ds.Closed = rs("closed").ToString
                ds.BillDate = CDate(rs("bill_date"))
                ds.ClientTotal = CDec(rs("Client_total").ToString)
                ds.Dflag = rs("dflag").ToString
                ds.Agency = CInt(rs("agency").ToString)
                ds.BillType = rs("bill_type").ToString
                ds.BegDate = CDate(rs("beg_date"))
                ds.EndDate = CDate(rs("end_date"))
                ds.Active = rs("active").ToString
                ds.SlotNum = CInt(rs("slot_num").ToString)
                ds.NameChk = rs("name_chk").ToString
                ds.AttCode = rs("att_code").ToString
                ds.AttUnit = CDbl(rs("att_unit").ToString)
                ds.ProgNum = rs("Prog_num").ToString
                ds.UnitRate = CDec(rs("unit_rate").ToString)
                ds.Offset = CDec(rs("offset").ToString)
                ds.Mon = rs("mon").ToString
                ds.Tue = rs("tue").ToString
                ds.Wed = rs("wed").ToString
                ds.Thu = rs("thu").ToString
                ds.Fri = rs("fri").ToString
                ds.Sat = rs("sat").ToString
                ds.Sun = rs("sun").ToString
                ds.Type = rs("type").ToString
                ds.DrAcctNu = rs("dr_acct_nu").ToString
                ds.CrAcctNu = rs("cr_acct_nu").ToString
                ds.RefProvNum = rs("ref_prov_num").ToString
                ds.MedSource = rs("med_source").ToString
                ds.BudAmt = CDec(rs("bud_amt").ToString)
                ds.SpecAmt = CDec(rs("spec_amt").ToString)
                FundingData.Add(ds)
            End While
            rs.Close()
        End Using
        Return FundingData
    End Function

    Public Shared Function GetBlankFundData() As List(Of FundingData)
        Dim fundingdata As New List(Of FundingData)
        Dim ds As New FundingData
        ds.BNum = "" ' ("b_num").ToString
        ds.NameKey = "" ' ("name_key").ToString
        ds.ScreenNam = "" ' ("screen_nam").ToString
        ds.SortName = "" ' ("sort_name").ToString
        ds.ContractKey = "" ' ("contract_key").ToString
        ds.ContIdNum = "" ' ("cont_id_num").ToString
        ds.MmarsNum = "" ' ("mmars_num").ToString
        ds.AmendNum = "" ' ("amend_num").ToString
        ' ds.EntryDate = CDate(rs("entry_date"))
        ds.Closed = "" ' ("closed").ToString
        ds.BillDate = CDate("1/1/1901")
        ds.ClientTotal = 0 'CDec(rs("Client_total").ToString)
        ds.Dflag = "N" ' ("dflag").ToString
        ds.Agency = 0 ' CInt(rs("agency").ToString)
        ds.BillType = "" ' ("bill_type").ToString
        'ds.BegDate = CDate(rs("beg_date"))
        'ds.EndDate = CDate(rs("end_date"))
        ds.Active = "" ' ("active").ToString
        ds.SlotNum = 0 'CInt(rs("slot_num").ToString)
        ds.NameChk = "" ' ("name_chk").ToString
        ds.AttCode = "" ' ("att_code").ToString
        ds.AttUnit = 0 'CDbl(rs("att_unit").ToString)
        ds.ProgNum = "" ' ("Prog_num").ToString
        ds.UnitRate = 0 'CDec(rs("unit_rate").ToString)
        ds.Offset = 0 ' CDec(rs("offset").ToString)
        ds.Mon = "" ' ("mon").ToString
        ds.Tue = "" ' ("tue").ToString
        ds.Wed = "" ' ("wed").ToString
        ds.Thu = "" ' ("thu").ToString
        ds.Fri = "" ' ("fri").ToString
        ds.Sat = "" ' ("sat").ToString
        ds.Sun = "" ' ("sun").ToString
        ds.Type = "" ' ("type").ToString
        ds.DrAcctNu = "" ' ("dr_acct_nu").ToString
        ds.CrAcctNu = "" ' ("cr_acct_nu").ToString
        ds.RefProvNum = "" ' ("ref_prov_num").ToString
        ds.MedSource = "" ' ("med_source").ToString
        ds.BudAmt = 0 ' CDec(rs("bud_amt").ToString)
        ds.SpecAmt = 0 'CDec(rs("spec_amt").ToString)
        FundingData.add(ds)

        Return FundingData

    End Function

    Public Shared Function GetPVData(ByVal Sqlstmnt As String) As List(Of PVData)
        Dim PVData As New List(Of PVData)

        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(Sqlstmnt)
            While rs.Read()
                Dim ds As New PVData
                ds.ContractKey = rs("contract_key").ToString
                ds.PvForm = rs("pv_form").ToString
                ds.Dept1 = rs("dept-1").ToString
                ds.ROrg2 = rs("r-org-2").ToString
                ds.Num3 = rs("num-3").ToString
                ds.Action4 = rs("action-4").ToString
                ds.SchDate5 = CDate(rs("sch_date-5"))
                ds.LiabAcct6 = rs("liab_Acct-6").ToString
                ds.Pvdate7 = CDate(rs("pvdate-7"))
                ds.AcctgPrd8 = rs("acctg_prd-8").ToString
                ds.BudFy9 = rs("bud_fy-9").ToString
                ds.DeptOrg10 = rs("dept_org-10").ToString
                ds.Doctot11 = CDec(rs("doctot-11").ToString)
                ds.Dept12 = rs("dept-12").ToString
                ds.VinvNum13 = rs("vinv_num-13").ToString
                ds.VendCode14 = rs("vend_code-14").ToString
                ds.Emp15 = rs("emp-15").ToString
                ds.Vname16a = rs("vname-16a").ToString
                ds.Vname16b = rs("vname-16b").ToString
                ds.Vname16c = rs("vname-16c").ToString
                ds.Vname16d = rs("vname-16d").ToString
                ds.R01 = rs("r01").ToString
                ds.Ln1 = rs("ln1").ToString
                ds.R02 = rs("r02").ToString
                ds.Ln2 = rs("ln2").ToString
                ds.R03 = rs("r03").ToString
                ds.Ln3 = rs("ln3").ToString
                ds.R04 = rs("r04").ToString
                ds.Ln4 = rs("ln4").ToString
                ds.R05 = rs("r05").ToString
                ds.Ln5 = rs("ln5").ToString
                ds.R06 = rs("r06").ToString
                ds.Ln6 = rs("ln6").ToString
                ds.R07 = rs("r07").ToString
                ds.Ln7 = rs("ln7").ToString
                ds.R08 = rs("r08").ToString
                ds.Ln8 = rs("ln8").ToString
                ds.R09 = rs("r09").ToString
                ds.Ln9 = rs("ln9").ToString
                ds.R010 = rs("r010").ToString
                ds.Ln10 = rs("ln10").ToString
                ds.D1 = rs("d1").ToString
                ds.D2 = rs("d2").ToString
                ds.D3 = rs("d3").ToString
                ds.D4 = rs("d4").ToString
                ds.D5 = rs("d5").ToString
                ds.D6 = rs("d6").ToString
                ds.D7 = rs("d7").ToString
                ds.D8 = rs("d8").ToString
                ds.D9 = rs("d9").ToString
                ds.D10 = rs("d10").ToString
                ds.D12 = rs("d12").ToString
                ds.Q1 = CDbl(rs("q1").ToString)
                ds.Up1 = CDec(rs("up1").ToString)
                ds.A1 = CDec(rs("a1").ToString)
                ds.Q2 = CDbl(rs("q2").ToString)
                ds.Up2 = CDec(rs("up2").ToString)
                ds.A2 = CDec(rs("a2").ToString)
                ds.Q3 = CDbl(rs("q3").ToString)
                ds.Up3 = CDec(rs("up3").ToString)
                ds.A3 = CDec(rs("a3").ToString)
                ds.Q4 = CDbl(rs("q4").ToString)
                ds.Up4 = CDec(rs("up4").ToString)
                ds.A4 = CDec(rs("a4").ToString)
                ds.Q5 = CDbl(rs("q5").ToString)
                ds.Up5 = CDec(rs("up5").ToString)
                ds.A5 = CDec(rs("a5").ToString)
                ds.Q6 = CDbl(rs("q6").ToString)
                ds.Up6 = CDec(rs("up6").ToString)
                ds.A6 = CDec(rs("a6").ToString)
                ds.Q7 = CDbl(rs("q7").ToString)
                ds.Up7 = CDec(rs("up7").ToString)
                ds.A7 = CDec(rs("a7").ToString)
                ds.Q8 = CDbl(rs("q8").ToString)
                ds.Up8 = CDec(rs("up8").ToString)
                ds.A8 = CDec(rs("a8").ToString)
                ds.Q9 = CDbl(rs("q9").ToString)
                ds.Up9 = CDec(rs("up9").ToString)
                ds.A9 = CDec(rs("a9").ToString)
                ds.Q10 = CDbl(rs("q10").ToString)
                ds.Up10 = CDec(rs("up10").ToString)
                ds.A10 = CDec(rs("a10").ToString)
                ds.Ln17 = rs("ln-17").ToString
                ds.Trans18 = rs("trans-18").ToString
                ds.Dept19 = rs("dept-19").ToString
                ds.ROrg20 = rs("r-org-20").ToString
                ds.Number21 = rs("number-21").ToString
                ds.Line22 = rs("line-22").ToString
                ds.Dept23 = rs("dept-23").ToString
                ds.Approp24 = rs("approp-24").ToString
                ds.Sub25 = rs("sub-25").ToString
                ds.Org26 = rs("org-26").ToString
                ds.Sorg27 = rs("sorg-27").ToString
                ds.Obj28 = rs("obj-28").ToString
                ds.Sobj29 = rs("sobj-29").ToString
                ds.Prog30 = rs("prog-30").ToString
                ds.Ty31 = rs("ty-31").ToString
                ds.Proj32 = rs("proj-32").ToString
                ds.Rptg33 = rs("rptg-33").ToString
                ds.Fund34 = rs("fund-34").ToString
                ds.Bsacct35 = rs("bsacct-35").ToString
                ds.Dept36 = rs("dept-36").ToString
                ds.VinvNum37 = rs("vinv_num-37").ToString
                ds.Desc38 = rs("desc-38").ToString
                ds.Disc39 = rs("disc-39").ToString
                ds.FrmDate40 = CDate(rs("frm_date-40"))
                ds.ToDate41 = CDate(rs("to_date-41"))
                ds.Quant42 = CDbl(rs("quant-42").ToString)
                ds.Amount43 = CDec(rs("amount-43").ToString)
                ds.Id44 = rs("id-44").ToString
                ds.Pf45 = rs("pf-45").ToString
                ds.CrAcctNu = rs("cr_acct_nu").ToString
                ds.DrAcctNu = rs("dr_acct_nu").ToString
                ds.Agency = CInt(rs("agency").ToString)
                ds.Print = rs("print").ToString
                ds.EntryDate = CDate(rs("entry_date"))
                ds.Dflag = rs("dflag").ToString
                ds.Void = rs("void").ToString
                PVData.Add(ds)
            End While
            rs.Close()
        End Using
        Return PVData
    End Function

    Public Shared Function GetOnePVData(ByVal Sqlstmnt As String) As PVData
        Dim ds As New PVData
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(Sqlstmnt)
            While rs.Read()
                ds.ContractKey = rs("contract_key").ToString
                ds.PvForm = rs("pv_form").ToString
                ds.Dept1 = rs("dept-1").ToString
                ds.ROrg2 = rs("r-org-2").ToString
                ds.Num3 = rs("num-3").ToString
                ds.Action4 = rs("action-4").ToString
                ds.SchDate5 = CDate(rs("sch_date-5"))
                ds.LiabAcct6 = rs("liab_Acct-6").ToString
                ds.Pvdate7 = CDate(rs("pvdate-7"))
                ds.AcctgPrd8 = rs("acctg_prd-8").ToString
                ds.BudFy9 = rs("bud_fy-9").ToString
                ds.DeptOrg10 = rs("dept_org-10").ToString
                ds.Doctot11 = CDec(rs("doctot-11").ToString)
                ds.Dept12 = rs("dept-12").ToString
                ds.VinvNum13 = rs("vinv_num-13").ToString
                ds.VendCode14 = rs("vend_code-14").ToString
                ds.Emp15 = rs("emp-15").ToString
                ds.Vname16a = rs("vname-16a").ToString
                ds.Vname16b = rs("vname-16b").ToString
                ds.Vname16c = rs("vname-16c").ToString
                ds.Vname16d = rs("vname-16d").ToString
                ds.R01 = rs("r01").ToString
                ds.Ln1 = rs("ln1").ToString
                ds.R02 = rs("r02").ToString
                ds.Ln2 = rs("ln2").ToString
                ds.R03 = rs("r03").ToString
                ds.Ln3 = rs("ln3").ToString
                ds.R04 = rs("r04").ToString
                ds.Ln4 = rs("ln4").ToString
                ds.R05 = rs("r05").ToString
                ds.Ln5 = rs("ln5").ToString
                ds.R06 = rs("r06").ToString
                ds.Ln6 = rs("ln6").ToString
                ds.R07 = rs("r07").ToString
                ds.Ln7 = rs("ln7").ToString
                ds.R08 = rs("r08").ToString
                ds.Ln8 = rs("ln8").ToString
                ds.R09 = rs("r09").ToString
                ds.Ln9 = rs("ln9").ToString
                ds.R010 = rs("r010").ToString
                ds.Ln10 = rs("ln10").ToString
                ds.D1 = rs("d1").ToString
                ds.D2 = rs("d2").ToString
                ds.D3 = rs("d3").ToString
                ds.D4 = rs("d4").ToString
                ds.D5 = rs("d5").ToString
                ds.D6 = rs("d6").ToString
                ds.D7 = rs("d7").ToString
                ds.D8 = rs("d8").ToString
                ds.D9 = rs("d9").ToString
                ds.D10 = rs("d10").ToString
                ds.D12 = rs("d12").ToString
                ds.Q1 = CDbl(rs("q1").ToString)
                ds.Up1 = CDec(rs("up1").ToString)
                ds.A1 = CDec(rs("a1").ToString)
                ds.Q2 = CDbl(rs("q2").ToString)
                ds.Up2 = CDec(rs("up2").ToString)
                ds.A2 = CDec(rs("a2").ToString)
                ds.Q3 = CDbl(rs("q3").ToString)
                ds.Up3 = CDec(rs("up3").ToString)
                ds.A3 = CDec(rs("a3").ToString)
                ds.Q4 = CDbl(rs("q4").ToString)
                ds.Up4 = CDec(rs("up4").ToString)
                ds.A4 = CDec(rs("a4").ToString)
                ds.Q5 = CDbl(rs("q5").ToString)
                ds.Up5 = CDec(rs("up5").ToString)
                ds.A5 = CDec(rs("a5").ToString)
                ds.Q6 = CDbl(rs("q6").ToString)
                ds.Up6 = CDec(rs("up6").ToString)
                ds.A6 = CDec(rs("a6").ToString)
                ds.Q7 = CDbl(rs("q7").ToString)
                ds.Up7 = CDec(rs("up7").ToString)
                ds.A7 = CDec(rs("a7").ToString)
                ds.Q8 = CDbl(rs("q8").ToString)
                ds.Up8 = CDec(rs("up8").ToString)
                ds.A8 = CDec(rs("a8").ToString)
                ds.Q9 = CDbl(rs("q9").ToString)
                ds.Up9 = CDec(rs("up9").ToString)
                ds.A9 = CDec(rs("a9").ToString)
                ds.Q10 = CDbl(rs("q10").ToString)
                ds.Up10 = CDec(rs("up10").ToString)
                ds.A10 = CDec(rs("a10").ToString)
                ds.Ln17 = rs("ln-17").ToString
                ds.Trans18 = rs("trans-18").ToString
                ds.Dept19 = rs("dept-19").ToString
                ds.ROrg20 = rs("r-org-20").ToString
                ds.Number21 = rs("number-21").ToString
                ds.Line22 = rs("line-22").ToString
                ds.Dept23 = rs("dept-23").ToString
                ds.Approp24 = rs("approp-24").ToString
                ds.Sub25 = rs("sub-25").ToString
                ds.Org26 = rs("org-26").ToString
                ds.Sorg27 = rs("sorg-27").ToString
                ds.Obj28 = rs("obj-28").ToString
                ds.Sobj29 = rs("sobj-29").ToString
                ds.Prog30 = rs("prog-30").ToString
                ds.Ty31 = rs("ty-31").ToString
                ds.Proj32 = rs("proj-32").ToString
                ds.Rptg33 = rs("rptg-33").ToString
                ds.Fund34 = rs("fund-34").ToString
                ds.Bsacct35 = rs("bsacct-35").ToString
                ds.Dept36 = rs("dept-36").ToString
                ds.VinvNum37 = rs("vinv_num-37").ToString
                ds.Desc38 = rs("desc-38").ToString
                ds.Disc39 = rs("disc-39").ToString
                ds.FrmDate40 = CDate(rs("frm_date-40"))
                ds.ToDate41 = CDate(rs("to_date-41"))
                ds.Quant42 = CDbl(rs("quant-42").ToString)
                ds.Amount43 = CDec(rs("amount-43").ToString)
                ds.Id44 = rs("id-44").ToString
                ds.Pf45 = rs("pf-45").ToString
                ds.CrAcctNu = rs("cr_acct_nu").ToString
                ds.DrAcctNu = rs("dr_acct_nu").ToString
                ds.Agency = CInt(rs("agency").ToString)
                ds.Print = rs("print").ToString
                ds.EntryDate = CDate(rs("entry_date"))
                ds.Dflag = rs("dflag").ToString
                ds.Void = rs("void").ToString
            End While
            rs.Close()
        End Using
        Return ds
    End Function


    Public Shared Function GetBlankPVData() As List(Of PVData)
        Dim PVData As New List(Of PVData)
        Dim ds As New PVData
        ds.ContractKey = ""
        ds.PvForm = ""
        ds.Dept1 = ""
        ds.ROrg2 = ""
        ds.Num3 = ""
        ds.Action4 = ""
        ' ds.SchDate5 = CDate(rs("sch_date-5"))
        ds.LiabAcct6 = ""
        'ds.Pvdate7 = CDate(rs("pv_date-7"))
        ds.AcctgPrd8 = ""
        ds.BudFy9 = ""
        ds.DeptOrg10 = ""
        ds.Doctot11 = 0
        ds.Dept12 = ""
        ds.VinvNum13 = ""
        ds.VendCode14 = ""
        ds.Emp15 = ""
        ds.Vname16a = ""
        ds.Vname16b = ""
        ds.Vname16c = ""
        ds.Vname16d = ""
        ds.R01 = ""
        ds.Ln1 = ""
        ds.R02 = ""
        ds.Ln2 = ""
        ds.R03 = ""
        ds.Ln3 = ""
        ds.R04 = ""
        ds.Ln4 = ""
        ds.R05 = ""
        ds.Ln5 = ""
        ds.R06 = ""
        ds.Ln6 = ""
        ds.R07 = ""
        ds.Ln7 = ""
        ds.R08 = ""
        ds.Ln8 = ""
        ds.R09 = ""
        ds.Ln9 = ""
        ds.R010 = ""
        ds.Ln10 = ""
        ds.D1 = ""
        ds.D2 = ""
        ds.D3 = ""
        ds.D4 = ""
        ds.D5 = ""
        ds.D6 = ""
        ds.D7 = ""
        ds.D8 = ""
        ds.D9 = ""
        ds.D10 = ""
        ds.D12 = ""
        ds.Q1 = 0
        ds.Up1 = 0
        ds.A1 = 0
        ds.Q2 = 0
        ds.Up2 = 0
        ds.A2 = 0
        ds.Q3 = 0
        ds.Up3 = 0
        ds.A3 = 0
        ds.Q4 = 0
        ds.Up4 = 0
        ds.A4 = 0
        ds.Q5 = 0
        ds.Up5 = 0
        ds.A5 = 0
        ds.Q6 = 0
        ds.Up6 = 0
        ds.A6 = 0
        ds.Q7 = 0
        ds.Up7 = 0
        ds.A7 = 0
        ds.Q8 = 0
        ds.Up8 = 0
        ds.A8 = 0
        ds.Q9 = 0
        ds.Up9 = 0
        ds.A9 = 0
        ds.Q10 = 0
        ds.Up10 = 0
        ds.A10 = 0
        ds.Ln17 = ""
        ds.Trans18 = ""
        ds.Dept19 = ""
        ds.ROrg20 = ""
        ds.Number21 = ""
        ds.Line22 = ""
        ds.Dept23 = ""
        ds.Approp24 = ""
        ds.Sub25 = ""
        ds.Org26 = ""
        ds.Sorg27 = ""
        ds.Obj28 = ""
        ds.Sobj29 = ""
        ds.Prog30 = ""
        ds.Ty31 = ""
        ds.Proj32 = ""
        ds.Rptg33 = ""
        ds.Fund34 = ""
        ds.Bsacct35 = ""
        ds.Dept36 = ""
        ds.VinvNum37 = ""
        ds.Desc38 = ""
        ds.Disc39 = ""
        'ds.FrmDate40 = CDate(rs("frm_date-40"))
        'ds.ToDate41 = CDate(rs("to_date-41"))
        ds.Quant42 = 0
        ds.Amount43 = 0
        ds.Id44 = ""
        ds.Pf45 = ""
        ds.CrAcctNu = ""
        ds.DrAcctNu = ""
        ds.Agency = 1
        ds.Print = ""
        '  ds.EntryDate = CDate(rs("entry_date"))
        ds.Dflag = "N"
        ds.Void = "N"
        PVData.Add(ds)
        Return PVData
    End Function

    Public Shared Function GetContactData(ByVal TableKey As String, ByVal TableName As String) As List(Of ContactData)
        Dim ContactData As New List(Of ContactData)
        Dim TKeyNAme As String = "name_key"
        If TableName = "nam_bank" Then TKeyNAme = "bank_key"

        If Val(TableKey) = 0 Then
            sqlstmnt = "select " & TKeyNAme & ", screen_nam, sort_name from " & TableName & " order by " & TKeyNAme
        Else
            sqlstmnt = "select " & TKeyNAme & ", screen_nam, sort_name from " & TableName & " where name_key = '" & TableKey & "'"
        End If
        Using db As Database = New Database(top_data_path)

            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                Dim ds As New ContactData
                ds.TableKey = rs(TKeyNAme).ToString
                ds.ScreenName = rs("screen_nam").ToString
                ds.SortName = rs("sort_name").ToString
                ContactData.Add(ds)
            End While
            rs.Close()
        End Using

        Return ContactData
    End Function

    Public Shared Function GetOneNameAddrData(ByVal Sqlstmnt As String) As NameAddrData
        Dim ds As New NameAddrData
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(Sqlstmnt)
            While rs.Read
                ds.NameKey = rs("name_key").ToString
                ds.ScreenNam = rs("screen_nam").ToString
                ds.SortName = rs("sort_name").ToString
                ds.Salutation = rs("salutation").ToString
                ds.FirstName = rs("first_name").ToString
                ds.MiddleIni = rs("middle_ini").ToString
                ds.LastName = rs("last_name").ToString
                ds.Address1 = rs("address1").ToString
                ds.Address2 = rs("address2").ToString
                ds.Address3 = rs("address3").ToString
                ds.City = rs("city").ToString
                ds.State = rs("state").ToString
                ds.Zip4 = rs("zip4").ToString
                ds.Telephone = rs("telephone").ToString
                ds.Fax = rs("fax").ToString
                ds.Email = rs("email").ToString
                ds.EntryDate = CDate(rs("entry_date"))
                ds.Dflag = rs("dflag").ToString
                ds.Agency = CInt(rs("agency").ToString)
                ds.Title = rs("title").ToString
                ds.Country = rs("country").ToString
            End While
            rs.Close()
        End Using

        Return ds

    End Function


    Public Shared Function AltDB_GetAcctNum(ByVal NewConnection As String, ByVal sqlstmnt As String) As List(Of AcctNums)
        Dim AcctNum As New List(Of AcctNums)
        sqlstmnt = "select acct_num from chacct where acct_dpt = '00' "
        Using db As Database = New Database(NewConnection)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                Dim ds As New AcctNums
                ds.AcctNum = rs("acct_num").ToString
                AcctNum.Add(ds)
            End While
            rs.Close()
        End Using

        Return AcctNum
    End Function

    Public Shared Function GetRefData(ByVal Pkg As String, ByVal frm As String) As List(Of RefData)
        Dim refData As New List(Of RefData)

        sqlstmnt = "select * from reference where pkg_type = '" & Pkg & "' and form_name = '" & frm & "' order by ctrl_name, datum"
        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)

            While rs.Read()
                Dim ds As New RefData
                ds.ControlName = rs("Ctrl_Name").ToString
                ds.Datum = rs("Datum").ToString
                ds.DatumDesc = rs("Datum_desc").ToString
                ds.ControlVisible = rs("ctrl_vis").ToString
                ds.PackageType = rs("pkg_type").ToString
                ds.FormName = rs("form_name").ToString
                refData.Add(ds)
            End While
            rs.Close()
        End Using

        Return refData
    End Function

    Public Shared Function GetProgramData(ByVal Pgm As String, ByVal fiscal As String) As List(Of ProgramData)
        Dim ProgramData As New List(Of ProgramData)

        sqlstmnt = "select * from Program where prog_num = '" & Pgm & "' and fiscal_yr = '" & fiscal & "' order by prog_num"
        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)

            While rs.Read()
                Dim ds As New ProgramData
                ds.ProgNum = rs("prog_num").ToString
                ds.ProgDesc = rs("prog_desc").ToString
                ds.ProgRate = CDec(rs("prog_rate").ToString)
                ds.Division = rs("division").ToString
                ds.FiscalYr = rs("fiscal_yr").ToString
                ds.Location = rs("location").ToString
                ds.UfrNum = rs("ufr_num").ToString
                ds.EntryDate = CDate(rs("entry_date").ToString)
                ProgramData.Add(ds)
            End While
            rs.Close()
        End Using

        Return ProgramData
    End Function

    Public Shared Function GetProgramDataOne(ByVal Pgm As String, ByVal fiscal As String) As ProgramData
        Dim ds As New ProgramData
        sqlstmnt = "select * from Program where prog_num = '" & Pgm & "' and fiscal_yr = '" & fiscal & "' order by prog_num"
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                ds.ProgNum = rs("prog_num").ToString
                ds.ProgDesc = rs("prog_desc").ToString
                ds.ProgRate = CDec(rs("prog_rate").ToString)
                ds.Division = rs("division").ToString
                ds.FiscalYr = rs("fiscal_yr").ToString
                ds.Location = rs("location").ToString
                ds.UfrNum = rs("ufr_num").ToString
                ds.EntryDate = CDate(rs("entry_date").ToString)
            End While
            rs.Close()
        End Using

        Return ds
    End Function

    Public Shared Function GetJeData(ByVal sqlstmnt As String) As List(Of JeData)
        Dim JeData As New List(Of JeData)

        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)

            While rs.Read()
                Dim ds As New JeData
                ds.AcctNum = rs("acct_num").ToString
                ds.AcctDesc = rs("acct_desc").ToString
                ds.Amount = CDbl(Val(rs("amount").ToString))
                ds.APost = rs("a_post").ToString
                ds.JrnlNum = CInt(Val((rs("jrnl_num").ToString)))
                ds.JrnlLineNum = CInt(Val(rs("jrnl_line").ToString))
                ds.EntryType = rs("entry_type").ToString
                ds.JrnlName = rs("jrnl_name").ToString
                ds.JrnlSrc = rs("jrnl_src").ToString
                ds.EntryDate = CDate(rs("entry_date").ToString)
                ds.EncumDate = CDate(rs("encum_date"))
                ds.PostDate = CDate(rs("post_Date"))
                ds.JrnlDesc = rs("jrnl_desc").ToString
                ds.OperId = rs("oper_id").ToString
                ds.Post = rs("post").ToString
                ds.dflag = rs("dflag").ToString
                ds.Agency = rs("agency").ToString
                ds.Void = rs("void").ToString
                JeData.Add(ds)
            End While
            rs.Close()
        End Using

        Return JeData
    End Function

    Public Shared Function GetBlankJeData() As List(Of JeData)
        Dim JeData As New List(Of JeData)
        Dim ds As New JeData
        ds.AcctNum = ""
        ds.AcctDesc = ""
        ds.Amount = 0
        ds.APost = ""
        ds.JrnlNum = 0
        ds.JrnlLineNum = 0
        ds.EntryType = ""
        ds.JrnlName = ""
        ds.JrnlSrc = ""
        '    ds.EntryDate = CDate(Date.Today.ToShortDateString)
        '   ds.EncumDate = CDate(Date.Today.ToShortDateString)
        '  ds.PostDate = CDate(Date.Today.ToShortDateString)
        ds.JrnlDesc = ""
        ds.OperId = ""
        ds.Post = "N"
        ds.dflag = "N"
        ds.Agency = "1"
        ds.Void = "N"
        JeData.Add(ds)
        Return JeData
    End Function

    Public Shared Function GetVoucherData(ByVal sqlstmnt As String) As List(Of VoucherData)
        Dim VoucherData As New List(Of VoucherData)

        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)

            While rs.Read()
                Dim ds As New VoucherData
                ds.Agency = rs("agency").ToString
                ds.AllocAmt = CDbl(rs("alloc_Amt").ToString)
                ds.BankKey = rs("bank_key").ToString
                ds.BPostDate = CDate(rs("bpost_date"))
                ds.Checked = rs("checked").ToString
                ds.CntrctKey = rs("cntrct_key").ToString
                ds.CRAcctNum = rs("cr_Acct_nu").ToString
                ds.DateRecd = CDate(rs("Date_recd"))
                ds.dflag = rs("dflag").ToString
                ds.DiscAmt = CDbl(rs("disc_amt").ToString)
                ds.DRAcctNum = rs("dr_acct_nu").ToString
                ds.DtTBePaid = CDate(rs("dt_tbe_pd"))
                ds.EncumDate = CDate(rs("encum_Date"))
                ds.EntryDate = CDate(rs("entry_Date"))
                ds.GLpost = rs("glpost").ToString
                ds.JrnlLineNum = CInt(Val((rs("jrnl_line").ToString)))
                ds.JrnlNum = CInt(Val(rs("jrnl_num").ToString))
                ds.Memo = rs("memo").ToString
                ds.NameKey = rs("name_key").ToString
                ds.Paid = rs("paid").ToString
                ds.PONum = rs("po_num").ToString
                ds.Reimb = rs("reimb").ToString
                ds.ScreenNam = rs("Screen_nam").ToString
                ds.SortName = rs("sort_name").ToString
                ds.VendInv = rs("vend_inv").ToString
                ds.VendInvDate = CDate(rs("vend_inv_D"))
                ds.VouchAmt = CDbl(rs("vouch_Amt").ToString)
                ds.VouchLine = CInt(Val(rs("vouch_line").ToString))
                ds.VouchNum = CInt(Val(rs("vouch_num").ToString))
                ds.Void = rs("void").ToString
                ' ds.AcctDesc = rs("acct_desc").ToString
                VoucherData.Add(ds)
            End While
            rs.Close()
        End Using

        Return VoucherData
    End Function

    Public Shared Function GetBlankVoucherData() As List(Of VoucherData)
        Dim VoucherData As New List(Of VoucherData)
        Dim ds As New VoucherData
        ds.Agency = "" 'rs("agency").ToString
        ds.AllocAmt = 0 'CDbl(rs("alloc_Amt").ToString)
        ds.BankKey = "" 'rs("bank_keu").ToString
        '  ds.BPostDate = CDate(rs("bpost_date"))
        ds.Checked = "" 'rs("checked").ToString
        ds.CntrctKey = "" 'rs("cntrct_key").ToString
        ds.CRAcctNum = "" 'rs("cr_Acct_nu").ToString
        ' ds.DateRecd = CDate(rs("Date_recd"))
        ds.dflag = "N" 'rs("dflag").ToString
        ds.DiscAmt = 0 ' CDbl(rs("disc_amt").ToString)
        ds.DRAcctNum = "" ' rs("dr}_acct_num").ToString
        '  ds.DtToBePaid = CDate(rs("post_Date"))
        ' ds.EncumDate = CDate(rs("encum_Date"))
        'ds.EntryDate = CDate(rs("entry_Date"))
        ds.GLpost = "N" 'rs("glpost").ToString
        ds.JrnlLineNum = 0 'CInt(Val((rs("jrnl_line").ToString)))
        ds.JrnlNum = 0 'CInt(Val(rs("jrnl_num").ToString))
        ds.Memo = "" 'rs("memo").ToString
        ds.NameKey = "" 'rs("name_key").ToString
        ds.Paid = "N" 'rs("paid").ToString
        ds.PONum = "" 'rs("po_num").ToString
        ds.Reimb = "" 'rs("reimb").ToString
        ds.ScreenNam = "" 'rs("Screen_nam").ToString
        ds.SortName = "" 'rs("sort_name").ToString
        ds.VendInv = "" ' rs("vend_inv").ToString
        ' ds.VendInvDate = CDate(rs("vend_inv_D"))
        ds.VouchAmt = 0 'CDbl(rs("vouch_Amt").ToString)
        ds.VouchLine = 0 'CInt(Val(rs("vouch_line").ToString))
        ds.VouchNum = 0 'CInt(Val(rs("vouch_num").ToString))
        ds.Void = "N" 'rs("void").ToString
        VoucherData.Add(ds)
        Return VoucherData
    End Function

    Public Shared Function GetAPChecData(ByVal sqlstmnt As String) As List(Of APCheckData)
        Dim APCheckData As New List(Of APCheckData)

        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)

            While rs.Read()
                Dim ds As New APCheckData
                ds.Agency = rs("agency").ToString
                ds.BankKey = rs("bank_key").ToString
                ds.BalDue = CDbl(rs("bal_due").ToString)
                ds.CheckDate = CDate(rs("chk_date"))
                ds.CheckNum = CInt(rs("chk_num").ToString)
                ds.DiscAmt = CDbl(rs("disc_amt").ToString)
                ds.NameKey = rs("name_key").ToString
                ds.NetCheckAmt = CDbl(rs("n_chk_amt").ToString)
                ds.NetDiscAmt = CDbl(rs("n_dis_amt").ToString)
                ds.PaidAmt = CDbl(rs("amt_paid").ToString)
                ds.PaidDisc = CDbl(rs("amt_disc").ToString)
                ds.Printed = rs("printed").ToString
                ds.ScreenNam = rs("Screen_nam").ToString
                ds.SortName = rs("sort_name").ToString
                ds.VendInv = rs("vend_inv").ToString
                ds.VendInvDate = CDate(rs("inv_Date"))
                ds.VouchAmt = CDbl(rs("vouch_Amt").ToString)
                ds.VouchNum = CInt(Val(rs("vouch_num").ToString))
                APCheckData.Add(ds)
            End While
            rs.Close()
        End Using

        Return APCheckData
    End Function

    Public Shared Function GetBlankAPCheckData() As List(Of APCheckData)
        Dim APCheckData As New List(Of APCheckData)
        Dim ds As New APCheckData
        ds.Agency = "" 'rs("agency").ToString
        ds.BankKey = "" 'rs("bank_key").ToString
        ds.BalDue = 0 'CDbl(rs("bal_due").ToString)
        '   ds.CheckDate = "" 'CDate(rs("chk_date"))
        ds.CheckNum = 0 'CInt(rs("chk_num").ToString)
        ds.DiscAmt = 0 'CDbl(rs("disc_amt").ToString)
        ds.NameKey = "" 'rs("name_key").ToString
        ds.NetCheckAmt = 0 'CDbl(rs("n_chk_amt").ToString)
        ds.NetDiscAmt = 0 'CDbl(rs("n_dis_amt").ToString)
        ds.PaidAmt = 0 'CDbl(rs("amt_paid").ToString)
        ds.PaidDisc = 0 'CDbl(rs("amt_disc").ToString)
        ds.Printed = "" 'rs("printed").ToString
        ds.ScreenNam = "" 'rs("Screen_nam").ToString
        ds.SortName = "" ' rs("sort_name").ToString
        ds.VendInv = "" 'rs("vend_inv").ToString
        '   ds.VendInvDate = ""  'CDate(rs("inv_Date"))
        ds.VouchAmt = 0 'CDbl(rs("vouch_Amt").ToString)
        ds.VouchNum = 0 'CInt(Val(rs("vouch_num").ToString))
        APCheckData.Add(ds)
        Return APCheckData
    End Function

    Public Shared Function GetPaymentData(ByVal sqlstmnt As String) As List(Of PaymentData)
        Dim PaymentData As New List(Of PaymentData)

        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)

            While rs.Read()
                Dim ds As New PaymentData
                ds.ChkNum = CInt(Val(rs("chk_num").ToString))
                ds.VouchNum = CInt(Val(rs("vouch_num").ToString))
                ds.NameKey = rs("name_key").ToString
                ds.DtPaid = CDate(rs("dt_paid"))
                ds.DtClear = CDate(rs("dt_clear"))
                ds.ChkAlloc = CDbl(rs("chk_alloc").ToString)
                ds.ChkDisc = CDbl(rs("chk_disc").ToString)
                ds.NetAmt = CDbl(rs("net_amt").ToString)
                ds.Void = rs("void").ToString
                ds.EncumDate = CDate(rs("encum_Date"))
                ds.EntryDate = CDate(rs("entry_date"))
                ds.GLpost = rs("glpost").ToString
                ds.dflag = rs("dflag").ToString
                ds.Agency = rs("agency").ToString
                ds.ScreenNam = rs("Screen_nam").ToString
                ds.BankKey = rs("bank_key").ToString
                ds.Recon = rs("recon").ToString
                ds.DRAcctNum = rs("dr_acct_nu").ToString
                ds.CRAcctNum = rs("cr_Acct_nu").ToString
                ds.DiscAcctNum = (rs("disc_acct").ToString)
                ds.JrnlLineNum = CInt(Val((rs("jrnl_line").ToString)))
                ds.JrnlNum = CInt(Val(rs("jrnl_num").ToString))
                PaymentData.Add(ds)
            End While
            rs.Close()
        End Using

        Return PaymentData
    End Function

    Public Shared Function GetBlankPaymentData() As List(Of PaymentData)
        Dim PaymentData As New List(Of PaymentData)
        Dim ds As New PaymentData
        ds.ChkNum = 0 'CInt(Val(rs("chk_num").ToString))
        ds.VouchNum = 0 'CInt(Val(rs("vouch_num").ToString))
        ds.NameKey = "" 'rs("name_key").ToString
        ' ds.DtPaid = CDate(rs("dt_paid"))
        ' ds.DtClear = CDate(rs("dt_clear"))
        ds.ChkAlloc = 0 ' CDbl(rs("chk_alloc").ToString)
        ds.ChkDisc = 0 'CDbl(rs("chk_disc").ToString)
        ds.NetAmt = 0 'CDbl(rs("net_paid").ToString)
        ds.Void = "N" 'rs("void").ToString
        'ds.EncumDate = CDate(rs("encum_Date"))
        'ds.EntryDate = CDate(rs("entry_date"))
        ds.GLpost = "N" 'rs("glpost").ToString
        ds.dflag = "N" 'rs("dflag").ToString
        ds.Agency = "1" 'rs("agency").ToString
        ds.ScreenNam = "" 'rs("Screen_nam").ToString
        ds.BankKey = "" 'rs("bank_key").ToString
        ds.Recon = "" 'rs("recon").ToString
        ds.DRAcctNum = "" 'rs("dr_acct_nu").ToString
        ds.CRAcctNum = "" 'rs("cr_Acct_nu").ToString
        ds.DiscAcctNum = "" '(rs("disc_acct").ToString)
        ds.JrnlLineNum = 0 'CInt(Val((rs("jrnl_line").ToString)))
        ds.JrnlNum = 0 'CInt(Val(rs("jrnl_num").ToString))
        PaymentData.Add(ds)
        Return PaymentData
    End Function

    Public Shared Function GetBudgetData(ByVal sqlstmnt As String) As List(Of BudgetData)
        Dim BudgetData As New List(Of BudgetData)

        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)

            While rs.Read()
                Dim ds As New BudgetData
                ds.AcctNum = rs("acct_num").ToString
                ds.Mth1 = CDec(rs("bud_m1"))
                ds.Mth2 = CDec(rs("bud_m2"))
                ds.Mth3 = CDec(rs("bud_m3"))
                ds.Mth4 = CDec(rs("bud_m4"))
                ds.Mth5 = CDec(rs("bud_m5"))
                ds.Mth6 = CDec(rs("bud_m6"))
                ds.Mth7 = CDec(rs("bud_m7"))
                ds.Mth8 = CDec(rs("bud_m8"))
                ds.Mth9 = CDec(rs("bud_m9"))
                ds.Mth10 = CDec(rs("bud_m10"))
                ds.Mth11 = CDec(rs("bud_m11"))
                ds.Mth12 = CDec(rs("bud_m12"))
                ds.BudgetTotal = ds.Mth1 + ds.Mth2 + ds.Mth3 + ds.Mth4 + ds.Mth5 + ds.Mth6 + ds.Mth7 + ds.Mth8 + ds.Mth9 + ds.Mth10 + ds.Mth11 + ds.Mth2
                BudgetData.Add(ds)
            End While
            rs.Close()
        End Using

        Return BudgetData

    End Function

    Public Shared Function GetRptTypeData(ByVal sqlstmnt As String) As List(Of ReportTypeData)
        Dim ReportTypeData As New List(Of ReportTypeData)

        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)

            While rs.Read()
                Dim ds As New ReportTypeData
                ds.RptNum = rs("rpt_num").ToString
                ds.RptPath = rs("rpt_path").ToString
                ds.RptName = rs("rpt_name").ToString
                ds.RptDesc = rs("rpt_desc").ToString
                ds.RptPrinter = rs("rpt_printer").ToString
                ReportTypeData.Add(ds)
            End While
            rs.Close()
        End Using

        Return ReportTypeData

    End Function


    Public Shared Sub ExecuteSQL(ByVal sqlstmnt As String)
        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            db.ExecuteUpdate(sql)
        End Using
    End Sub

    Public Shared Sub BeforeBackup(ByVal SqlTable As String)
        'process is:
        '1-erase old beforebackups 
        '2- create new table name with julian date and an B in it
        '3- use sql insert into new beforebackup (no indexes)

        'find tables with name sqltable*B and delete them
        Dim OldBackup As String = GetTableNames(SqlTable & "_____B")
        Dim oldones() As String = OldBackup.Split(CChar("*"))
        For Each oldone In oldones
            If oldone.Length <> 0 Then
                sqlstmnt = "Drop Table " & oldone
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If
        Next

        Dim NewTableName As String = SqlTable & GetJulianDate() & "B"
        sqlstmnt = "select * into " & NewTableName & " from " & SqlTable
        Using db As Database = New Database(top_data_path)
            db.ExecuteUpdate(sqlstmnt)
        End Using


    End Sub

    Public Shared Sub AfterBackup(ByVal SqlTable As String)
        'process is:
        '1-erase old afterbackups
        '2- create new table name with julian date and an A in it
        '3- use sql insert into new afterbackup (no indexes)

        'find tables with name sqltable*A and delete them
        Dim OldBackup As String = GetTableNames(SqlTable & "_____A")
        Dim oldones() As String = OldBackup.Split(CChar("*"))
        For Each oldone In oldones
            If oldone.Length <> 0 Then
                sqlstmnt = "Drop Table " & oldone
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If
        Next

        Dim NewTableName As String = SqlTable & GetJulianDate() & "A"
        sqlstmnt = "select * into " & NewTableName & " from " & SqlTable
        Using db As Database = New Database(top_data_path)
            db.ExecuteUpdate(sqlstmnt)
        End Using

    End Sub

    Public Shared Function GetTableNames(ByVal LikeName As String) As String
        Dim TableNames As String = "*"
        sqlstmnt = "select TABLE_NAME from INFORMATION_SCHEMA.TABLES where TABLE_NAME like '" & LikeName & "'"
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                TableNames = TableNames & "*" & rs("table_name").ToString
            End While
            rs.Close()
        End Using
        Return TableNames
    End Function

    Public Shared Function GetOneItemList(ByVal sqlstmnt As String, ByVal Fld1 As String) As String
        Dim OneItemList As String
        OneItemList = ""
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                OneItemList = OneItemList & rs(Fld1).ToString & "*"
            End While
            rs.Close()
        End Using
        Return OneItemList
    End Function

    Public Shared Function GetProgRate(ByVal ContractKey As String, ByVal ProgNum As String) As Decimal
        Dim Fiscal As String = ETSSQL.GetOneSQLValue(" select fiscal_yr as thevalue from cc_cont where contract_key = '" & ContractKey & "'")
        Dim ProgRate As Decimal = CDec(ETSSQL.GetOneSQLValue("select prog_rate  as thevalue from program where prog_num = '" & ProgNum & "' and fiscal_yr = '" & Fiscal & "'"))
        Return ProgRate
    End Function

    Public Shared Function GetTwoItemList(ByVal sqlstmnt As String, ByVal Fld1 As String, ByVal Fld2 As String) As List(Of String)
        Dim TwoItemList As New List(Of String)
        TwoItemList.Clear()
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                TwoItemList.Add(rs(Fld1).ToString & "*" & rs(Fld2).ToString)
            End While
            rs.Close()
        End Using
        Return TwoItemList
    End Function

    Public Shared Function GetVoucherList(ByVal sqlstmnt As String) As String
        Dim VoucherList As String = ""
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                VoucherList = VoucherList & "*" & rs("vouch_num").ToString
            End While
            VoucherList = VoucherList & "*"
            rs.Close()
        End Using
        Return VoucherList
    End Function

    Public Shared Function GetBNumList(ByVal sqlstmnt As String) As String
        Dim BNumList As String = ""
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                BNumList = BNumList & "*" & rs("b_num").ToString
            End While
            BNumList = BNumList & "*"
            rs.Close()
        End Using
        Return BNumList
    End Function

    Public Shared Function GetBillableList(ByVal sqlstmnt As String) As List(Of Billable)
        Dim Billable As New List(Of Billable)
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                Dim ds As New Billable
                ds.BNum = rs("b_num").ToString
                ds.NameKey = rs("name_key").ToString
                ds.ContractKey = rs("contract_key").ToString
                ds.BillType = rs("bill_type").ToString
                ds.BegDate = CDate(rs("beg_Date").ToString)
                ds.EndDate = CDate(rs("end_Date").ToString)
                ds.Billed = "N"
                Billable.Add(ds)
            End While
            rs.Close()
        End Using
        Return Billable
    End Function

    Public Shared Function GetBilledList(ByVal sqlstmnt As String) As List(Of Billable)
        Dim Billed As New List(Of Billable)
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                Dim ds As New Billable
                ds.BNum = rs("b_num").ToString
                ds.NameKey = rs("name_key").ToString
                ds.ContractKey = rs("contract_key").ToString
                ds.BillType = rs("bill_type").ToString
                ' ds.BegDate = CDate(rs("att_Date").ToString)
                ds.Billed = "Y"
                Billed.Add(ds)
            End While
            rs.Close()
        End Using
        Return Billed
    End Function


    Public Shared Sub RestoreBackup(ByVal SqlTable As String)
        'process is:
        '1 - ask for julian date and whether it is a before or after backup
        '2 -see if it exists
        '3- see if basic table exist
        '4-delete data from basic table
        '5 - insert into basic table from the backuptable found - this means it has indexes
        Dim TempJulianDate As String
        TempJulianDate = InputBox("Enter the Julian Date of the file you want to restore.  Today's Julian Date is " & GetJulianDate())
        Dim TempType As String
        TempType = InputBox("Enter an A if this is for an after restore DB or B for a before backup.")
        Dim NewTableName As String = SqlTable & TempJulianDate & TempType

        Dim OldBackup As String = GetTableNames(NewTableName)
        Dim oldones() As String = OldBackup.Split(CChar("*"))
        For Each oldone In oldones
            If oldone = NewTableName Then
                'is ok so check if real table and if it does delete data
                OldBackup = GetTableNames(SqlTable)
                oldones = OldBackup.Split(CChar("*"))
                For Each oldone1 In oldones
                    If oldone1 = SqlTable Then
                        sqlstmnt = "delete * from " & SqlTable
                        ETSSQL.ExecuteSQL(sqlstmnt)
                    End If
                Next
                sqlstmnt = " select * into " & SqlTable & " from " & NewTableName
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If
        Next


    End Sub

    Public Shared Function GetCompanyInvoiceData(ByVal sqlstmnt As String) As List(Of CompanyInvoiceData)
        Dim CompanyInvoiceData As New List(Of CompanyInvoiceData)

        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)

            While rs.Read()
                Dim ds As New CompanyInvoiceData
                ds.InvNum = CInt(rs("inv_num").ToString)
                ds.LineNum = CInt(rs("line_num").ToString)
                ds.Invoice = rs("invoice").ToString
                ds.TransCode = rs("trans_code").ToString
                ds.PoNum = rs("po_num").ToString
                ds.NameKey = rs("name_key").ToString
                ds.ScreenNam = rs("screen_nam").ToString
                ds.CcNum = rs("cc_num").ToString
                ds.CcName = rs("cc_name").ToString
                ds.InvDesc = rs("inv_desc").ToString
                ds.DrAcctNu = rs("dr_acct_nu").ToString
                ds.CrAcctNu = rs("cr_Acct_nu").ToString
                ds.AllocAmt = CDec(rs("alloc_amt").ToString)
                ds.EntryDate = CDate(rs("entry_Date").ToString)
                ds.InvoiceDate = CDate(rs("invoice_date").ToString)
                ds.EncumDate = CDate(rs("encum_date").ToString)
                ds.DtTbePd = CDate(rs("dt_tbe_pd").ToString)
                ds.PaidDate = CDate(rs("paid_date").ToString)
                ds.ChkNum = rs("chk_num").ToString
                ds.BankKey = rs("bank_key").ToString
                ds.BankName = rs("bank_name").ToString
                ds.PayAmt = CDec(rs("pay_amt").ToString)
                ds.BalDue = CDec(rs("bal_due").ToString)
                ds.InvAmt = CDec(rs("inv_amt").ToString)
                ds.Paid = rs("paid").ToString
                ds.Glpost = rs("glpost").ToString
                ds.Dflag = rs("dflag").ToString
                ds.Agency = CInt(rs("agency").ToString)
                ds.Checked = rs("checked").ToString
                ds.Void = rs("void").ToString
                ds.SortName = rs("sort_name").ToString
                ds.JrnlNum = CInt(rs("jrnl_num").ToString)
                ds.JrnlLine = CInt(rs("jrnl_line").ToString)
                ds.InvType = rs("inv_type").ToString
                ds.ContractKey = rs("contract_key").ToString
                ds.FromDate = CDate(rs("from_date").ToString)
                ds.ToDate = CDate(rs("to_Date").ToString)
                ds.UnitRate = CDec(rs("unit_rate").ToString)
                ds.Units = CDec(rs("units").ToString)
                ds.PmtNum = CInt(rs("pmt_num").ToString)
                CompanyInvoiceData.Add(ds)
            End While
            rs.Close()
        End Using

        Return CompanyInvoiceData
    End Function

    Public Shared Function GetBlankCompanyInvoiceData() As CompanyInvoiceData
        ' Dim BlankCompanyInvoiceData As New CompanyInvoiceData
        Dim ds As New CompanyInvoiceData
        ds.InvNum = 0 'CInt(rs("inv_num").ToString)
        ds.LineNum = 0 'CInt(rs("line_num").ToString)
        ds.Invoice = "" 'rs("invoice").ToString
        ds.TransCode = "" 'rs("trans_code").ToString
        ds.PoNum = "" ' rs(" po_num").ToString
        ds.NameKey = "" ' rs("name_key").ToString
        ds.ScreenNam = "" 'rs("screen_nam").ToString
        ds.CcNum = "" 'rs("cc_num").ToString
        ds.CcName = "" ' rs("cc_name").ToString
        ds.InvDesc = "" ' rs("inv_desc").ToString
        ds.DrAcctNu = "" ' rs("dr_acct_nu").ToString
        ds.CrAcctNu = "" 'rs("cr_Acct_nu").ToString
        ds.AllocAmt = 0 'CDec(rs("alloc_amt").ToString)
        '  ds.EntryDate = CDate(rs("entry_Date").ToString)
        '  ds.InvoiceDate = CDate(rs("invoice_date").ToString)
        '  ds.EncumDate = CDate(rs("encum_date").ToString)
        ds.DtTbePd = CDate("1/1/1901")
        ds.PaidDate = CDate("1/1/1901")
        ds.ChkNum = "" ' rs("chk_num").ToString
        ds.BankKey = "" ' rs("bank_key").ToString
        ds.BankName = "" 'rs("bank_name").ToString
        ds.PayAmt = 0 'CDec(rs("pay_amt").ToString)
        ds.BalDue = 0 'CDec(rs("bal_due").ToString)
        ds.InvAmt = 0 'CDec(rs("inv_amt").ToString)
        ds.Paid = "N" ' rs("paid").ToString
        ds.Glpost = "N" ' rs("glpost").ToString
        ds.Dflag = "N" ' rs("dflag").ToString
        ds.Agency = 1 'CInt(rs("agency").ToString)
        ds.Checked = "N" ' rs("checked").ToString
        ds.Void = "N" ' rs("void").ToString
        ds.SortName = "" 'rs("sort_name").ToString
        ds.JrnlNum = 0 'CInt(rs("jrnl_num").ToString)
        ds.JrnlLine = 0 ' CInt(rs("jrnl_line").ToString)
        ds.InvType = "" 'rs("inv_type").ToString
        ds.ContractKey = "" 'rs("contract_key").ToString
        '  ds.FromDate = CDate(rs("from_date").ToString)
        '  ds.ToDate = CDate(rs("to_Date").ToString)
        ds.UnitRate = 0 ' CDec(rs("unit_rate").ToString)
        ds.Units = 0 'CDec(rs("units").ToString)
        ds.PmtNum = 0 'CInt(rs("pmt_num").ToString)
        '  BlankCompanyInvoiceData.Add(ds)
        ' CompanyInvoiceData.Add(ds)
        Return ds  'BlankCompanyInvoiceData
    End Function

    Public Shared Function GetCompanyInvoiceDataOne(ByVal sqlstmnt As String) As CompanyInvoiceData
        Dim ds As New CompanyInvoiceData
        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            While rs.Read()
                ds.InvNum = CInt(rs("inv_num").ToString)
                ds.LineNum = CInt(rs("line_num").ToString)
                ds.Invoice = rs("invoice").ToString
                ds.TransCode = rs("trans_code").ToString
                ds.PoNum = rs("po_num").ToString
                ds.NameKey = rs("name_key").ToString
                ds.ScreenNam = rs("screen_nam").ToString
                ds.CcNum = rs("cc_num").ToString
                ds.CcName = rs("cc_name").ToString
                ds.InvDesc = rs("inv_desc").ToString
                ds.DrAcctNu = rs("dr_acct_nu").ToString
                ds.CrAcctNu = rs("cr_Acct_nu").ToString
                ds.AllocAmt = CDec(rs("alloc_amt").ToString)
                ds.EntryDate = CDate(rs("entry_Date").ToString)
                ds.InvoiceDate = CDate(rs("invoice_date").ToString)
                ds.EncumDate = CDate(rs("encum_date").ToString)
                ds.DtTbePd = CDate(rs("dt_tbe_pd").ToString)
                ds.PaidDate = CDate(rs("paid_date").ToString)
                ds.ChkNum = rs("chk_num").ToString
                ds.BankKey = rs("bank_key").ToString
                ds.BankName = rs("bank_name").ToString
                ds.PayAmt = CDec(rs("pay_amt").ToString)
                ds.BalDue = CDec(rs("bal_due").ToString)
                ds.InvAmt = CDec(rs("inv_amt").ToString)
                ds.Paid = rs("paid").ToString
                ds.Glpost = rs("glpost").ToString
                ds.Dflag = rs("dflag").ToString
                ds.Agency = CInt(rs("agency").ToString)
                ds.Checked = rs("checked").ToString
                ds.Void = rs("void").ToString
                ds.SortName = rs("sort_name").ToString
                ds.JrnlNum = CInt(rs("jrnl_num").ToString)
                ds.JrnlLine = CInt(rs("jrnl_line").ToString)
                ds.InvType = rs("inv_type").ToString
                ds.ContractKey = rs("contract_key").ToString
                ds.FromDate = CDate(rs("from_date").ToString)
                ds.ToDate = CDate(rs("to_Date").ToString)
                ds.UnitRate = CDec(rs("unit_rate").ToString)
                ds.Units = CDec(rs("units").ToString)
                ds.PmtNum = CInt(rs("pmt_num").ToString)

            End While
            rs.Close()
        End Using

        Return ds
    End Function

    Public Shared Function GetOneSQLValue(ByVal sqlstmnt As String) As String
        Dim ReturnValue As String = ""
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                ReturnValue = rs("TheValue").ToString
            End While
            rs.Close()
        End Using

        Return ReturnValue
    End Function

    Public Shared Function GetCashReceiptData(ByVal sqlstmnt As String) As List(Of CashReceiptData)
        Dim CashReceiptData As New List(Of CashReceiptData)

        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)

            While rs.Read()
                Dim ds As New CashReceiptData
                ds.BankKey = rs("bank_key").ToString
                ds.EncumDate = CDate(rs("encum_Date"))
                ds.NameKey = rs("name_key").ToString
                ds.ScreenNam = rs("Screen_nam").ToString
                ds.SortName = rs("sort_name").ToString
                ds.ChkNum = rs("chk_num").ToString
                ds.ChkDate = CDate(rs("chk_date"))
                ds.GrossAmt = CDec(rs("gross_Amt").ToString)
                ds.ChkDisc = CDec(rs("chk_disc").ToString)
                ds.CheckAmt = CDec(rs("check_Amt").ToString)
                ds.EntryNum = CInt(Val((rs("entry_num").ToString)))
                ds.InvNum = CInt(Val(rs("inv_num").ToString))
                ds.LineNum = CInt(Val((rs("line_num").ToString)))
                ds.Invoice = (rs("invoice").ToString)
                ds.TransCode = (rs("trans_code").ToString)
                ds.ChkAlloc = CDec(rs("chk_alloc").ToString)
                ds.DrAcctNu = rs("dr_acct_nu").ToString
                ds.CrAcctNu = rs("cr_Acct_nu").ToString
                ds.Memo = rs("memo").ToString
                ds.Donor = rs("donor").ToString
                ds.EntryDate = CDate(rs("entry_Date"))
                ds.Checked = rs("checked").ToString
                ds.VoidChk = ("void_chk").ToString
                ds.Glpost = rs("glpost").ToString
                ds.Dflag = rs("dflag").ToString
                ds.Agency = CInt(rs("agency").ToString)
                ds.DiscAcct = rs("disc_acct").ToString
                ds.JrnlNum = CInt(Val(rs("jrnl_num").ToString))
                ds.JrnlLine = CInt(Val((rs("jrnl_line").ToString)))
                ds.Fund = rs("fund").ToString
                ds.BatchNum = CInt(Val(rs("batch_num").ToString))
                ds.BatchDesc = rs("batch_desc").ToString
                ds.BatchDate = CDate(rs("batch_Date"))
                ds.BatchTotal = CDec(rs("batch_total").ToString)
                ds.SM = rs("s_m").ToString
                CashReceiptData.Add(ds)
            End While
            rs.Close()
        End Using

        Return CashReceiptData
    End Function

    Public Shared Function GetBlankCashReceiptData() As CashReceiptData
        '  Dim CashReceiptData As New CashReceiptData
        Dim ds As New CashReceiptData
        ds.BankKey = ""  '""  'rs("bank_key").ToString
        '  ds.EncumDate = ""  'rs("encum_Date"))
        ds.NameKey = ""  'rs("name_key").ToString
        ds.ScreenNam = ""  'rs("Screen_nam").ToString
        ds.SortName = ""  'rs("sort_name").ToString
        ds.ChkNum = ""  'rs("chk_num").ToString
        '  ds.ChkDate = ""  'rs("chk_date"))
        ds.GrossAmt = 0 'CDec(""  'rs("gross_Amt").ToString)
        ds.ChkDisc = 0 'CDec(""  'rs("chk_disc").ToString)
        ds.CheckAmt = 0 'CDec(""  'rs("check_Amt").ToString)
        ds.EntryNum = 0 'CInt(Val((""  'rs("entry_num").ToString)))
        ds.InvNum = 0 'CInt(Val(""  'rs("inv_num").ToString))
        ds.LineNum = 0 'CInt(Val((""  'rs("line_num").ToString)))
        ds.Invoice = ""  'rs("invoice").ToString)
        ds.TransCode = ""  'rs("trans_code").ToString)
        ds.ChkAlloc = 0 'CDec(""  'rs("chk_alloc").ToString)
        ds.DrAcctNu = ""  'rs("dr_acct_nu").ToString
        ds.CrAcctNu = ""  'rs("cr_Acct_nu").ToString
        ds.Memo = ""  'rs("memo").ToString
        ds.Donor = ""  'rs("donor").ToString
        '   ds.EntryDate = CDate(""  'rs("entry_Date"))
        ds.Checked = "N"  'rs("checked").ToString
        ds.VoidChk = "N"   'rs("void_chk").ToString
        ds.Glpost = "N"  'rs("glpost").ToString
        ds.Dflag = "N"  'rs("dflag").ToString
        ds.Agency = 1 ' CInt(""  'rs("agency").ToString)
        ds.DiscAcct = ""  'rs("disc_acct").ToString
        ds.JrnlNum = 0 ' CInt(Val(""  'rs("jrnl_num").ToString))
        ds.JrnlLine = 0 ' CInt(Val((""  'rs("jrnl_line").ToString)))
        ds.Fund = ""  'rs("fund").ToString
        ds.BatchNum = 0 'CInt(Val(""  'rs("batch_num").ToString))
        ds.BatchDesc = ""  'rs("batch_desc").ToString
        '   ds.BatchDate = CDate(""  'rs("batch_Date"))
        ds.BatchTotal = 0 'CDec(""  'rs("batch_total").ToString)
        ds.SM = ""  'rs("s_m").ToString
        ' CashReceiptData.Add(ds)
        Return ds
    End Function
    Public Shared Function GetBlankCashReceiptHeader() As CashReceiptHeader
        Dim ds As New CashReceiptHeader
        ds.BankKey = ""  '""  'rs("bank_key").ToString
        ' ds.EncumDate = ""  'rs("encum_Date"))
        'ds.NameKey = ""  'rs("name_key").ToString
        'ds.ScreenNam = ""  'rs("Screen_nam").ToString
        'ds.SortName = ""  'rs("sort_name").ToString
        ds.ChkNum = ""  'rs("chk_num").ToString
        'ds.ChkDate = ""  'rs("chk_date"))
        ds.GrossAmt = 0 'CDec(""  'rs("gross_Amt").ToString)
        ds.ChkDisc = 0 'CDec(""  'rs("chk_disc").ToString)
        ds.CheckAmt = 0 'CDec(""  'rs("check_Amt").ToString)
        'ds.EntryNum = 0 'CInt(Val((""  'rs("entry_num").ToString)))
        'ds.InvNum = 0 'CInt(Val(""  'rs("inv_num").ToString))
        'ds.LineNum = 0 'CInt(Val((""  'rs("line_num").ToString)))
        'ds.Invoice = ""  'rs("invoice").ToString)
        'ds.TransCode = ""  'rs("trans_code").ToString)
        'ds.ChkAlloc = 0 'CDec(""  'rs("chk_alloc").ToString)
        'ds.DrAcctNu = ""  'rs("dr_acct_nu").ToString
        'ds.CrAcctNu = ""  'rs("cr_Acct_nu").ToString
        'ds.Memo = ""  'rs("memo").ToString
        'ds.Donor = ""  'rs("donor").ToString
        ' ds.EntryDate = CDate(""  'rs("entry_Date"))
        'ds.Checked = "N"  'rs("checked").ToString
        'ds.VoidChk = "N"   'rs("void_chk").ToString
        'ds.Glpost = "N"  'rs("glpost").ToString
        'ds.Dflag = "N"  'rs("dflag").ToString
        'ds.Agency = 0 ' CInt(""  'rs("agency").ToString)
        'ds.DiscAcct = ""  'rs("disc_acct").ToString
        'ds.JrnlNum = 0 ' CInt(Val(""  'rs("jrnl_num").ToString))
        'ds.JrnlLine = 0 ' CInt(Val((""  'rs("jrnl_line").ToString)))
        'ds.Fund = ""  'rs("fund").ToString
        'ds.BatchNum = 0 'CInt(Val(""  'rs("batch_num").ToString))
        ds.BatchDesc = ""  'rs("batch_desc").ToString
        '   ds.BatchDate = CDate(""  'rs("batch_Date"))
        ds.BatchTotal = 0 'CDec(""  'rs("batch_total").ToString)
        '   ds.SM = ""  'rs("s_m").ToString
        Return ds
    End Function


    Public Shared Function GetNameEEData(ByVal sqlstmnt As String) As List(Of NameEEData)
        Dim NameEEData As New List(Of NameEEData)
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read
                Dim ds As New NameEEData
                ds.NameKey = rs("name_key").ToString
                ds.ScreenNam = rs("screen_nam").ToString
                ds.SsNum = rs("ss_num").ToString
                ds.HireDate = CDate(rs("hire_date"))
                ds.TermDate = CDate(rs("term_date"))
                ds.AnnivMo = rs("anniv_mo").ToString
                ds.DeptNum = rs("dept_num").ToString
                ds.SlotNum = rs("slot_num").ToString
                ds.LocNum = rs("loc_num").ToString
                ds.CostNum = rs("cost_num").ToString
                ds.SupNum = rs("sup_num").ToString
                ds.TitleNum = rs("title_num").ToString
                ds.JobTitle = rs("job_title").ToString
                ds.WcNum = rs("wc_num").ToString
                ds.WcRate = CDec(rs("wc_rate").ToString)
                ds.FicaExmt = rs("fica_exmt").ToString
                ds.AeicElig = rs("aeic_elig").ToString
                ds.FileStatus = rs("file_status").ToString
                ds.PayFreq = rs("pay_freq").ToString
                ds.FwtExmts = CInt(rs("fwt_exmts").ToString)
                ds.SwtExmts = CInt(rs("swt_exmts").ToString)
                ds.HrlySal = rs("hrly_sal").ToString
                ds.RegHrs = CDbl(rs("reg_hrs").ToString)
                ds.AnnSal = CDec(rs("ann_sal").ToString)
                ds.State1Tax = rs("state1_tax").ToString
                ds.State2Tax = rs("state2_tax").ToString
                ds.DolRatea = CDec(rs("dol_ratea").ToString)
                ds.DolRateb = CDec(rs("dol_rateb").ToString)
                ds.DolRatec = CDec(rs("dol_ratec").ToString)
                ds.DolRated = CDec(rs("dol_rated").ToString)
                ds.DolRatee = CDec(rs("dol_ratee").ToString)
                ds.DolRatef = CDec(rs("dol_ratef").ToString)
                ds.DolRateg = CDec(rs("dol_rateg").ToString)
                ds.DolRateh = CDec(rs("dol_rateh").ToString)
                ds.DolRatei = CDec(rs("dol_ratei").ToString)
                ds.DolRatej = CDec(rs("dol_ratej").ToString)
                ds.AddFwt = CDec(rs("add_fwt").ToString)
                ds.AddfwtDfq = rs("addfwt_dfq").ToString
                ds.AddSwt = CDec(rs("add_swt").ToString)
                ds.AddswtDfq = rs("addswt_dfq").ToString
                ds.ANtNum = rs("a_nt_num").ToString
                ds.ANtDol = CDec(rs("a_nt_dol").ToString)
                ds.ANtDfq = rs("a_nt_dfq").ToString
                ds.BNtNum = rs("b_nt_num").ToString
                ds.BNtDol = CDec(rs("b_nt_dol").ToString)
                ds.BNtDfq = rs("b_nt_dfq").ToString
                ds.CNtNum = rs("c_nt_num").ToString
                ds.CNtDol = CDec(rs("c_nt_dol").ToString)
                ds.CNtDfq = rs("c_nt_dfq").ToString
                ds.DNtNum = rs("d_nt_num").ToString
                ds.DNtDol = CDec(rs("d_nt_dol").ToString)
                ds.DNtDfq = rs("d_nt_dfq").ToString
                ds.ENtNum = rs("e_nt_num").ToString
                ds.ENtDol = CDec(rs("e_nt_dol").ToString)
                ds.ENtDfq = rs("e_nt_dfq").ToString
                ds.FlxNtNum = rs("flx_nt_num").ToString
                ds.FlxNtDol = CDec(rs("flx_nt_dol").ToString)
                ds.FlxNtDfq = rs("flx_nt_dfq").ToString
                ds.DepNtNum = rs("dep_nt_num").ToString
                ds.DepNtDol = CDec(rs("dep_nt_dol").ToString)
                ds.DepNtDfq = rs("dep_nt_dfq").ToString
                ds.Pen1aNum = rs("pen1a_num").ToString
                ds.Pen1aDol = CDec(rs("pen1a_dol").ToString)
                ds.Pen1aPct = CDbl(rs("pen1a_pct").ToString)
                ds.Pen1aDfq = rs("pen1a_dfq").ToString
                ds.Pen1bNum = rs("pen1b_num").ToString
                ds.Pen1bDol = CDec(rs("pen1b_dol").ToString)
                ds.Pen1bPct = CDbl(rs("pen1b_pct").ToString)
                ds.Pen1bDfq = rs("pen1b_dfq").ToString
                ds.Pen2aNum = rs("pen2a_num").ToString
                ds.Pen2aDol = CDec(rs("pen2a_dol").ToString)
                ds.Pen2aPct = CDbl(rs("pen2a_pct").ToString)
                ds.Pen2aDfq = rs("pen2a_dfq").ToString
                ds.Pen2bNum = rs("pen2b_num").ToString
                ds.Pen2bDol = CDec(rs("pen2b_dol").ToString)
                ds.Pen2bPct = CDbl(rs("pen2b_pct").ToString)
                ds.Pen2bDfq = rs("pen2b_dfq").ToString
                ds.DdepDfq = rs("ddep_dfq").ToString
                ds.DdepNet = rs("ddep_net").ToString
                ds.Save1Num = rs("save1_num").ToString
                ds.Save1Dol = CDec(rs("save1_dol").ToString)
                ds.Save1Dfq = rs("save1_dfq").ToString
                ds.Ddep1Sav1 = rs("ddep1_sav1").ToString
                ds.Save2Num = rs("save2_num").ToString
                ds.Save2Dol = CDec(rs("save2_dol").ToString)
                ds.Save2Dfq = rs("save2_dfq").ToString
                ds.Ddep2Sav2 = rs("ddep2_sav2").ToString
                ds.Save3Num = rs("save3_num").ToString
                ds.Save3Dol = CDec(rs("save3_dol").ToString)
                ds.Save3Dfq = rs("save3_dfq").ToString
                ds.Ddep3Sav3 = rs("ddep3_sav3").ToString
                ds.Dduct1Num = rs("dduct1_num").ToString
                ds.Dduct1Dol = CDec(rs("dduct1_dol").ToString)
                ds.Dduct1Dfq = rs("dduct1_dfq").ToString
                ds.Dduct2Num = rs("dduct2_num").ToString
                ds.Dduct2Dol = CDec(rs("dduct2_dol").ToString)
                ds.Dduct2Dfq = rs("dduct2_dfq").ToString
                ds.Dduct3Num = rs("dduct3_num").ToString
                ds.Dduct3Dol = CDec(rs("dduct3_dol").ToString)
                ds.Dduct3Dfq = rs("dduct3_dfq").ToString
                ds.Dduct4Num = rs("dduct4_num").ToString
                ds.Dduct4Dol = CDec(rs("dduct4_dol").ToString)
                ds.Dduct4Dfq = rs("dduct4_dfq").ToString
                ds.Dduct5Num = rs("dduct5_num").ToString
                ds.Dduct5Dol = CDec(rs("dduct5_dol").ToString)
                ds.Dduct5Dfq = rs("dduct5_dfq").ToString
                ds.Dduct6Num = rs("dduct6_num").ToString
                ds.Dduct6Dol = CDec(rs("dduct6_dol").ToString)
                ds.Dduct6Dfq = rs("dduct6_dfq").ToString
                ds.Dduct7Num = rs("dduct7_num").ToString
                ds.Dduct7Dol = CDec(rs("dduct7_dol").ToString)
                ds.Dduct7Dfq = rs("dduct7_dfq").ToString
                ds.Dduct8Num = rs("dduct8_num").ToString
                ds.Dduct8Dol = CDec(rs("dduct8_dol").ToString)
                ds.Dduct8Dfq = rs("dduct8_dfq").ToString
                ds.Dduct9Num = rs("dduct9_num").ToString
                ds.Dduct9Dol = CDec(rs("dduct9_dol").ToString)
                ds.Dduct9Dfq = rs("dduct9_dfq").ToString
                ds.Misc1Num = rs("misc1_num").ToString
                ds.Misc1Dol = CDec(rs("misc1_dol").ToString)
                ds.Misc1Dfq = rs("misc1_dfq").ToString
                ds.Misc2Num = rs("misc2_num").ToString
                ds.Misc2Dol = CDec(rs("misc2_dol").ToString)
                ds.Misc2Dfq = rs("misc2_dfq").ToString
                ds.Agency = CInt(rs("agency").ToString)
                ds.Dflag = rs("dflag").ToString
                ds.MedExmt = rs("med_exmt").ToString
                ds.SortName = rs("sort_name").ToString
                ds.BeeperNum = rs("beeper_num").ToString
                NameEEData.Add(ds)
            End While
            rs.Close()
        End Using

        Return NameEEData
    End Function

    Public Shared Function GetBlankNameEEData() As NameEEData
        Dim ds As New NameEEData
        ds.NameKey = ""
        ds.ScreenNam = ""
        ds.SsNum = ""
        '     ds.HireDate As Date
        '    ds.TermDate As Date
        ds.AnnivMo = ""
        ds.DeptNum = ""
        ds.SlotNum = ""
        ds.LocNum = ""
        ds.CostNum = ""
        ds.SupNum = ""
        ds.TitleNum = ""
        ds.JobTitle = ""
        ds.WcNum = ""
        ds.WcRate = 0
        ds.FicaExmt = ""
        ds.AeicElig = ""
        ds.FileStatus = ""
        ds.PayFreq = ""
        ds.FwtExmts = 0
        ds.SwtExmts = 0
        ds.HrlySal = ""
        ds.RegHrs = 0
        ds.AnnSal = 0
        ds.State1Tax = ""
        ds.State2Tax = ""
        ds.DolRatea = 0
        ds.DolRateb = 0
        ds.DolRatec = 0
        ds.DolRated = 0
        ds.DolRatee = 0
        ds.DolRatef = 0
        ds.DolRateg = 0
        ds.DolRateh = 0
        ds.DolRatei = 0
        ds.DolRatej = 0
        ds.AddFwt = 0
        ds.AddfwtDfq = ""
        ds.AddSwt = 0
        ds.AddswtDfq = ""
        ds.ANtNum = ""
        ds.ANtDol = 0
        ds.ANtDfq = ""
        ds.BNtNum = ""
        ds.BNtDol = 0
        ds.BNtDfq = ""
        ds.CNtNum = ""
        ds.CNtDol = 0
        ds.CNtDfq = ""
        ds.DNtNum = ""
        ds.DNtDol = 0
        ds.DNtDfq = ""
        ds.ENtNum = ""
        ds.ENtDol = 0
        ds.ENtDfq = ""
        ds.FlxNtNum = ""
        ds.FlxNtDol = 0
        ds.FlxNtDfq = ""
        ds.DepNtNum = ""
        ds.DepNtDol = 0
        ds.DepNtDfq = ""
        ds.Pen1aNum = ""
        ds.Pen1aDol = 0
        ds.Pen1aPct = 0
        ds.Pen1aDfq = ""
        ds.Pen1bNum = ""
        ds.Pen1bDol = 0
        ds.Pen1bPct = 0
        ds.Pen1bDfq = ""
        ds.Pen2aNum = ""
        ds.Pen2aDol = 0
        ds.Pen2aPct = 0
        ds.Pen2aDfq = ""
        ds.Pen2bNum = ""
        ds.Pen2bDol = 0
        ds.Pen2bPct = 0
        ds.Pen2bDfq = ""
        ds.DdepDfq = ""
        ds.DdepNet = ""
        ds.Save1Num = ""
        ds.Save1Dol = 0
        ds.Save1Dfq = ""
        ds.Ddep1Sav1 = ""
        ds.Save2Num = ""
        ds.Save2Dol = 0
        ds.Save2Dfq = ""
        ds.Ddep2Sav2 = ""
        ds.Save3Num = ""
        ds.Save3Dol = 0
        ds.Save3Dfq = ""
        ds.Ddep3Sav3 = ""
        ds.Dduct1Num = ""
        ds.Dduct1Dol = 0
        ds.Dduct1Dfq = ""
        ds.Dduct2Num = ""
        ds.Dduct2Dol = 0
        ds.Dduct2Dfq = ""
        ds.Dduct3Num = ""
        ds.Dduct3Dol = 0
        ds.Dduct3Dfq = ""
        ds.Dduct4Num = ""
        ds.Dduct4Dol = 0
        ds.Dduct4Dfq = ""
        ds.Dduct5Num = ""
        ds.Dduct5Dol = 0
        ds.Dduct5Dfq = ""
        ds.Dduct6Num = ""
        ds.Dduct6Dol = 0
        ds.Dduct6Dfq = ""
        ds.Dduct7Num = ""
        ds.Dduct7Dol = 0
        ds.Dduct7Dfq = ""
        ds.Dduct8Num = ""
        ds.Dduct8Dol = 0
        ds.Dduct8Dfq = ""
        ds.Dduct9Num = ""
        ds.Dduct9Dol = 0
        ds.Dduct9Dfq = ""
        ds.Misc1Num = ""
        ds.Misc1Dol = 0
        ds.Misc1Dfq = ""
        ds.Misc2Num = ""
        ds.Misc2Dol = 0
        ds.Misc2Dfq = ""
        ds.Agency = 1
        ds.Dflag = ""
        ds.MedExmt = ""
        ds.SortName = ""
        ds.BeeperNum = ""

        Return ds


    End Function

    Public Shared Function GetOneNameEEData(ByVal NameKey As String) As NameEEData

        Dim ds As New NameEEData
        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery("select * from name_ee where name_key = '" & NameKey & "'")
            While rs.Read
                ds.NameKey = rs("name_key").ToString
                ds.ScreenNam = rs("screen_nam").ToString
                ds.SsNum = rs("ss_num").ToString
                ds.HireDate = CDate(rs("hire_date"))
                ds.TermDate = CDate(rs("term_date"))
                ds.AnnivMo = rs("anniv_mo").ToString
                ds.DeptNum = rs("dept_num").ToString
                ds.SlotNum = rs("slot_num").ToString
                ds.LocNum = rs("loc_num").ToString
                ds.CostNum = rs("cost_num").ToString
                ds.SupNum = rs("sup_num").ToString
                ds.TitleNum = rs("title_num").ToString
                ds.JobTitle = rs("job_title").ToString
                ds.WcNum = rs("wc_num").ToString
                ds.WcRate = CDec(rs("wc_rate").ToString)
                ds.FicaExmt = rs("fica_exmt").ToString
                ds.AeicElig = rs("aeic_elig").ToString
                ds.FileStatus = rs("file_status").ToString
                ds.PayFreq = rs("pay_freq").ToString
                ds.FwtExmts = CInt(rs("fwt_exmts").ToString)
                ds.SwtExmts = CInt(rs("swt_exmts").ToString)
                ds.HrlySal = rs("hrly_sal").ToString
                ds.RegHrs = CDbl(rs("reg_hrs").ToString)
                ds.AnnSal = CDec(rs("ann_sal").ToString)
                ds.State1Tax = rs("state1_tax").ToString
                ds.State2Tax = rs("state2_tax").ToString
                ds.DolRatea = CDec(rs("dol_ratea").ToString)
                ds.DolRateb = CDec(rs("dol_rateb").ToString)
                ds.DolRatec = CDec(rs("dol_ratec").ToString)
                ds.DolRated = CDec(rs("dol_rated").ToString)
                ds.DolRatee = CDec(rs("dol_ratee").ToString)
                ds.DolRatef = CDec(rs("dol_ratef").ToString)
                ds.DolRateg = CDec(rs("dol_rateg").ToString)
                ds.DolRateh = CDec(rs("dol_rateh").ToString)
                ds.DolRatei = CDec(rs("dol_ratei").ToString)
                ds.DolRatej = CDec(rs("dol_ratej").ToString)
                ds.AddFwt = CDec(rs("add_fwt").ToString)
                ds.AddfwtDfq = rs("addfwt_dfq").ToString
                ds.AddSwt = CDec(rs("add_swt").ToString)
                ds.AddswtDfq = rs("addswt_dfq").ToString
                ds.ANtNum = rs("a_nt_num").ToString
                ds.ANtDol = CDec(rs("a_nt_dol").ToString)
                ds.ANtDfq = rs("a_nt_dfq").ToString
                ds.BNtNum = rs("b_nt_num").ToString
                ds.BNtDol = CDec(rs("b_nt_dol").ToString)
                ds.BNtDfq = rs("b_nt_dfq").ToString
                ds.CNtNum = rs("c_nt_num").ToString
                ds.CNtDol = CDec(rs("c_nt_dol").ToString)
                ds.CNtDfq = rs("c_nt_dfq").ToString
                ds.DNtNum = rs("d_nt_num").ToString
                ds.DNtDol = CDec(rs("d_nt_dol").ToString)
                ds.DNtDfq = rs("d_nt_dfq").ToString
                ds.ENtNum = rs("e_nt_num").ToString
                ds.ENtDol = CDec(rs("e_nt_dol").ToString)
                ds.ENtDfq = rs("e_nt_dfq").ToString
                ds.FlxNtNum = rs("flx_nt_num").ToString
                ds.FlxNtDol = CDec(rs("flx_nt_dol").ToString)
                ds.FlxNtDfq = rs("flx_nt_dfq").ToString
                ds.DepNtNum = rs("dep_nt_num").ToString
                ds.DepNtDol = CDec(rs("dep_nt_dol").ToString)
                ds.DepNtDfq = rs("dep_nt_dfq").ToString
                ds.Pen1aNum = rs("pen1a_num").ToString
                ds.Pen1aDol = CDec(rs("pen1a_dol").ToString)
                ds.Pen1aPct = CDbl(rs("pen1a_pct").ToString)
                ds.Pen1aDfq = rs("pen1a_dfq").ToString
                ds.Pen1bNum = rs("pen1b_num").ToString
                ds.Pen1bDol = CDec(rs("pen1b_dol").ToString)
                ds.Pen1bPct = CDbl(rs("pen1b_pct").ToString)
                ds.Pen1bDfq = rs("pen1b_dfq").ToString
                ds.Pen2aNum = rs("pen2a_num").ToString
                ds.Pen2aDol = CDec(rs("pen2a_dol").ToString)
                ds.Pen2aPct = CDbl(rs("pen2a_pct").ToString)
                ds.Pen2aDfq = rs("pen2a_dfq").ToString
                ds.Pen2bNum = rs("pen2b_num").ToString
                ds.Pen2bDol = CDec(rs("pen2b_dol").ToString)
                ds.Pen2bPct = CDbl(rs("pen2b_pct").ToString)
                ds.Pen2bDfq = rs("pen2b_dfq").ToString
                ds.DdepDfq = rs("ddep_dfq").ToString
                ds.DdepNet = rs("ddep_net").ToString
                ds.Save1Num = rs("save1_num").ToString
                ds.Save1Dol = CDec(rs("save1_dol").ToString)
                ds.Save1Dfq = rs("save1_dfq").ToString
                ds.Ddep1Sav1 = rs("ddep1_sav1").ToString
                ds.Save2Num = rs("save2_num").ToString
                ds.Save2Dol = CDec(rs("save2_dol").ToString)
                ds.Save2Dfq = rs("save2_dfq").ToString
                ds.Ddep2Sav2 = rs("ddep2_sav2").ToString
                ds.Save3Num = rs("save3_num").ToString
                ds.Save3Dol = CDec(rs("save3_dol").ToString)
                ds.Save3Dfq = rs("save3_dfq").ToString
                ds.Ddep3Sav3 = rs("ddep3_sav3").ToString
                ds.Dduct1Num = rs("dduct1_num").ToString
                ds.Dduct1Dol = CDec(rs("dduct1_dol").ToString)
                ds.Dduct1Dfq = rs("dduct1_dfq").ToString
                ds.Dduct2Num = rs("dduct2_num").ToString
                ds.Dduct2Dol = CDec(rs("dduct2_dol").ToString)
                ds.Dduct2Dfq = rs("dduct2_dfq").ToString
                ds.Dduct3Num = rs("dduct3_num").ToString
                ds.Dduct3Dol = CDec(rs("dduct3_dol").ToString)
                ds.Dduct3Dfq = rs("dduct3_dfq").ToString
                ds.Dduct4Num = rs("dduct4_num").ToString
                ds.Dduct4Dol = CDec(rs("dduct4_dol").ToString)
                ds.Dduct4Dfq = rs("dduct4_dfq").ToString
                ds.Dduct5Num = rs("dduct5_num").ToString
                ds.Dduct5Dol = CDec(rs("dduct5_dol").ToString)
                ds.Dduct5Dfq = rs("dduct5_dfq").ToString
                ds.Dduct6Num = rs("dduct6_num").ToString
                ds.Dduct6Dol = CDec(rs("dduct6_dol").ToString)
                ds.Dduct6Dfq = rs("dduct6_dfq").ToString
                ds.Dduct7Num = rs("dduct7_num").ToString
                ds.Dduct7Dol = CDec(rs("dduct7_dol").ToString)
                ds.Dduct7Dfq = rs("dduct7_dfq").ToString
                ds.Dduct8Num = rs("dduct8_num").ToString
                ds.Dduct8Dol = CDec(rs("dduct8_dol").ToString)
                ds.Dduct8Dfq = rs("dduct8_dfq").ToString
                ds.Dduct9Num = rs("dduct9_num").ToString
                ds.Dduct9Dol = CDec(rs("dduct9_dol").ToString)
                ds.Dduct9Dfq = rs("dduct9_dfq").ToString
                ds.Misc1Num = rs("misc1_num").ToString
                ds.Misc1Dol = CDec(rs("misc1_dol").ToString)
                ds.Misc1Dfq = rs("misc1_dfq").ToString
                ds.Misc2Num = rs("misc2_num").ToString
                ds.Misc2Dol = CDec(rs("misc2_dol").ToString)
                ds.Misc2Dfq = rs("misc2_dfq").ToString
                ds.Agency = CInt(rs("agency").ToString)
                ds.Dflag = rs("dflag").ToString
                ds.MedExmt = rs("med_exmt").ToString
                ds.SortName = rs("sort_name").ToString
                ds.BeeperNum = rs("beeper_num").ToString

            End While
            rs.Close()
        End Using
        Return ds

    End Function

    Public Shared Function GetBlankContractData() As ContractData
        Dim ds As New ContractData

        ds.ContractKey = ""
        ds.ContIdNum = ""
        ds.MmarsNum = ""
        ds.AmendNum = ""
        ds.EntryDate = CDate(Today.ToShortDateString)
        ds.ContDesc = ""
        ds.FiscalYr = ""
        ds.Active = "Y"
        ds.BillType = ""
        ds.PvForm = ""
        ds.RptType = ""
        ds.UnitRate = 0
        '   ds.ContBegD = CDate(rs("").toshortdatestring)
        '  ds.ContEndD = CDate(rs("").toshortdatestring)
        ' ds.AmndBegD = CDate(rs("").toshortdatestring)
        'ds.AmndEndD = CDate(rs("").toshortdatestring)
        ds.LastInvnum = ""
        ' ds.LastBilldate = CDate(rs("").toshortdatestring)
        ds.ContOffset = CDec(0.0)
        ds.BillOffset = CDec(0.0)
        ds.DrAcctNu = ""
        ds.CrAcctNu = ""
        ds.NameKey = ""
        ds.ScreenNam = ""
        ds.ContUnits = 0
        ds.ContDol = 0
        ds.AmendUnits = 0
        ds.AmendDol = 0
        ds.MaxUnits = 0
        ds.MaxDol = 0
        ds.YtdUnits = 0
        ds.YtdDol = 0
        ds.SeedUnits = 0
        ds.SeedDol = 0
        ds.MonthUnits = 0
        ds.MonthDol = 0
        ds.RemUnits = 0
        ds.RemDol = 0
        ds.RedpyDol = 0
        ds.FlatRate = 0
        ds.Code1 = "P"
        ds.Code2 = ""
        ds.Code3 = ""
        ' ds.BeginDate = CDate(rs("").toshortdatestring)
        'ds.EndDate = CDate(rs("").toshortdatestring)
        ds.NamkeyDss = ""
        ds.PnumDss = ""
        ds.NamkeySdr = ""
        ds.PnumSdr = ""
        ds.PrgnamSdr = ""
        ds.PrgcodeSdr = ""
        ds.PrgduraSdr = ""
        ds.PrepBy = ""
        ds.StateAgcy = ""
        ds.ReimbType = ""
        ds.Desc1 = ""
        ds.Desc2 = ""
        ds.Desc3 = ""
        ds.NamkeyLea = ""
        ds.PnumLea = ""
        ds.PrgnamLea = ""
        ds.PrgcodeLea = ""
        ds.PrgduraLea = ""
        ds.FedidNum = ""
        ds.AnndaysSch = ""
        ds.AnndaysRes = ""
        ds.ProgType = ""
        ds.LeaTerms = ""
        ds.LeaComment = ""
        ds.LeaOrderNu = ""
        ds.Dflag = "N"
        ds.Agency = 1
        ds.InvType = ""
        ds.ProvNumMed = ""
        ds.ProsNumMed = ""
        ds.PlaceService = ""
        ds.BillableCodes = "X"
        ds.InvString = ""
        ds.ProgNum = ""
        ds.DefInc = "N"
        ds.LifeAmend = ""

        Return ds

    End Function

End Class


