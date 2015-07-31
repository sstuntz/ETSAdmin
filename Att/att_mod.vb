Option Strict On
Option Explicit On
Option Compare Text

Imports System.Data.SqlClient
Imports System.Configuration.ClientSettingsSection
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Text
Imports System.IO

Module att_mod
	
	Public left2 As Integer
	Public top2 As Integer
	Public ret2 As String
	Public billable_codes As String
    '	Public tots(20) As Decimal
	Public total_units As Double
	Public responseyear As Integer
	Public editname(600) As String
	Public code3 As String
	Public cont_rate As Decimal
	
	Public tot_Cont_num As String
	Public saved_end_Date As Date
	
	Public selected_cont_id_num As String
	Public selected_mmars_num As String
	Public selected_amend_num As String
	Public selected_contract_key As String
	Public selected_bill_type As String
	Public selected_grouping As String
	Public selected_b_num As String
	Public temp_cont_id_string As String
	Public selected_prog_num As String
	Public selected_prog_desc As String
	Public selected_prog_year As String
	Public selected_prog_rate As Decimal
	Public selected_cont_desc As String
	Public selected_autho_num As String
	Public selected_inv_date As Date
	Public selected_rpt_num As String
	Public selected_bat_num As Integer
	Public selected_Medicaid_Number As String
	Public selected_cc_fund As String
	
	Public cont_prov_num As String 'added 4/6/2007 lhw for cp
	
	Public Response1 As Integer 'added 02/12/2009 for JRI for printing copies bill_attend
	
	Public old_contract_key As String
	Public new_contract_key As String
	Public amend_type As String
	
	Public id_num As String
	Public mmars As String
	Public amend As String
	
	Public present_day As Date
	Public pr_end_date_tmp As Date
	Public pr_start_date_tmp As Date
	Public pr_End_Date1 As Date
	Public pr_start_date1 As Date
	Public sendyear As String
	
	Public rowvalue, colvalue As Object
    Public pv_Type As String
	Public high_inv_num As Integer
	Public new_Fiscal As Integer
    Public current_fiscal As Integer
    Public NextInvNum As Integer
    Public InvoiceLocation As String = ConfigurationManager.AppSettings("InvoiceLocation")

    Public Function div_b_num(ByVal b_num As String) As String
        For num As Integer = 1 To Len(b_num) - 1
            If Not IsNumeric(Mid(b_num, num, 1)) Then
                selected_contract_key = Right(b_num, Len(b_num) - num + 1)
                selected_name_key = Left(b_num, num - 1)
                Exit For
            End If
        Next
        Return selected_name_key
    End Function

    Public Sub ChangeActiveLevelContract(ByVal Contract As String, ByVal ToLevel As String)
        sqlstmnt = " update cc_cont set active = '" & ToLevel & "' where contract_key = '" & selected_contract_key & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)
    End Sub

    Public Function GetNextCompanyInvoiceNum() As Integer

        Using db As Database = New Database(top_data_path)
            Dim sql As String = "select top 1 * from invoice order by inv_num desc"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            While rs.Read()
                Return CInt(rs("inv_num").ToString) + 1
            End While
            rs.Close()
        End Using

    End Function

    Sub chk_ccbase(ByVal namekey As Object)
        'use lookup medicaid number and that will tell if valid

        'db = att_data_path & "aratt.mdb"
        'tmpdb = DAODBEngine_definst.OpenDatabase(db)
        'tmpset = tmpdb.OpenRecordset("cc_base", dao.RecordsetTypeEnum.dbOpenDynaset)

        'sqlstmnt = " name_key = "
        ''UPGRADE_WARNING: Couldn't resolve default property of object namekey. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = sqlstmnt & Chr(34) & namekey & Chr(34)

        'tmpset.FindFirst(sqlstmnt)

        'If tmpset.NoMatch Then
        '	valid_name = "N"
        'Else
        '	valid_name = "Y"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	selected_name_key = tmpset.Fields("name_key").Value
        '	selected_screen_nam = tmpset.Fields("screen_nam").Value
        '	selected_sort_name = tmpset.Fields("sort_name").Value
        '	selected_Medicaid_Number = tmpset.Fields("med_num").Value & ""


        'End If
    End Sub

    Sub chk_dup_slot(ByVal selected_contract_key As Object, ByVal slot As Object, ByVal valid_yn As Object)
        'checks for this exitence in cc_funding and issues a warning
        'db = att_data_path & "aratt.mdb"
        'dptdb = DAODBEngine_definst.OpenDatabase(db)
        'dptset = dptdb.OpenRecordset("cc_fund", dao.RecordsetTypeEnum.dbOpenDynaset)

        ''UPGRADE_WARNING: Couldn't resolve default property of object selected_contract_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = "contract_key = " & Chr(34) & selected_contract_key & Chr(34)
        ''UPGRADE_WARNING: Couldn't resolve default property of object slot. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = sqlstmnt & " and slot_num = " & slot
        'dptset.FindFirst(sqlstmnt)
        'If dptset.NoMatch Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object valid_yn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	valid_yn = "Y"
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object valid_yn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	valid_yn = "N"
        'End If

    End Sub

    Public Function GetReportList(ByVal ContractKey As String) As String
        Dim BatchPrintRpt As String = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "rpt_Type")
        Dim BatchRpt As String = BatchPrintRpt.ToCharArray
        Dim BatchList As String

        Select Case Len(BatchPrintRpt)
            Case 3
                selected_rpt_num = BatchRpt(0) & BatchRpt(1) & BatchRpt(2)
                BatchList = "*" & selected_rpt_num & "*"
            Case 6
                selected_rpt_num = BatchRpt(0) & BatchRpt(1) & BatchRpt(2)
                BatchList = "*" & selected_rpt_num
                selected_rpt_num = BatchRpt(3) & BatchRpt(4) & BatchRpt(5)
                BatchList = BatchList & "*" & selected_rpt_num & "*"
            Case 9
                selected_rpt_num = BatchRpt(0) & BatchRpt(1) & BatchRpt(2)
                BatchList = "*" & selected_rpt_num
                selected_rpt_num = BatchRpt(3) & BatchRpt(4) & BatchRpt(5)
                BatchList = BatchList & "*" & selected_rpt_num
                selected_rpt_num = BatchRpt(6) & BatchRpt(7) & BatchRpt(8)
                BatchList = BatchList & "*" & selected_rpt_num & "*"
            Case Else
                BatchList = "*"
        End Select

        Return BatchList

    End Function

    Function chk_rpt_type(ByVal selected_rpt_num As String) As Boolean
        sqlstmnt = " select * from rpt_type where rpt_num = '" & selected_rpt_num & "'"

        If ETSCommon.CheckYN("rpt_type", "rpt_num", selected_rpt_num, "N") = "Y" Then
            Return True
        Else
            Return False
        End If

    End Function

    Function chk_prog_loc_type(ByVal selected_prog_loc As String) As Boolean

        If ETSCommon.CheckYN("program", "location", selected_prog_loc, "N") = "Y" Then
            Return True
        Else
            Return False
        End If

    End Function

    Sub chk_ufr_type(ByVal selected_rpt_num As Object, ByVal valid_yn As Object)


        'db = att_data_path & "aratt.mdb"
        'dptdb = DAODBEngine_definst.OpenDatabase(db)
        'dptset = dptdb.OpenRecordset("ufr", dao.RecordsetTypeEnum.dbOpenDynaset)

        ''UPGRADE_WARNING: Couldn't resolve default property of object selected_rpt_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dptset.FindFirst("ufr_num = " & Chr(34) & selected_rpt_num & Chr(34))

        'If dptset.NoMatch Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object valid_yn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	valid_yn = "N"
        '	Exit Sub
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object valid_yn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	valid_yn = "Y"
        'End If

    End Sub

    Sub chk_ready_pay(ByVal selected_cont_num As Object, ByVal valid_yn As Object)

        'db = att_data_path & "aratt.mdb"
        'dptdb = DAODBEngine_definst.OpenDatabase(db)
        'dptset = dptdb.OpenRecordset("cc_cont", dao.RecordsetTypeEnum.dbOpenDynaset)

        ''UPGRADE_WARNING: Couldn't resolve default property of object selected_cont_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dptset.FindFirst("contract_key = " & Chr(34) & selected_cont_num & Chr(34))

        'If dptset.NoMatch Then

        'Else
        '	'check for dollars in contract readypay if some then ok
        '	If dptset.Fields("redpy_dol").Value <> 0 Then
        '		'UPGRADE_WARNING: Couldn't resolve default property of object valid_yn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		valid_yn = "Y"
        '	End If

        'End If

    End Sub

    Function chk_valid_cont(ByVal selected_contract_key As String) As Boolean

        If ETSCommon.CheckYN("cc_Cont", "contract_key", selected_contract_key, "N") = "Y" Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub get_contract_Desc(ByVal cont As Object, ByVal desc As Object)
        '    returns the contract desc when needed

        'Dim dptdb As dao.Database
        ''UPGRADE_WARNING: Arrays in structure dptset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim dptset As dao.Recordset
        'db = att_data_path & "aratt.mdb"
        'dptdb = DAODBEngine_definst.OpenDatabase(db)
        'dptset = dptdb.OpenRecordset("cc_Cont", dao.RecordsetTypeEnum.dbOpenDynaset)

        ''UPGRADE_WARNING: Couldn't resolve default property of object cont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dptset.FindFirst("contract_key = " & Chr(34) & cont & Chr(34))

        'If dptset.NoMatch Then
        '	valid_dpt = "N"

        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object desc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	desc = dptset.Fields("cont_desc").Value
        '	msg = dptset.Fields("bill_Type").Value & "" 'used for unsupported pvs
        '	'added this to get prov num for revs for sco
        '	cont_prov_num = dptset.Fields("prov_num_med").Value & ""

        'End If


    End Sub

    Sub get_contract_year(ByVal cont As Object, ByVal desc As Object)
        '    returns the contract desc when needed

        'Dim dptdb As dao.Database
        ''UPGRADE_WARNING: Arrays in structure dptset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim dptset As dao.Recordset
        'db = att_data_path & "aratt.mdb"
        'dptdb = DAODBEngine_definst.OpenDatabase(db)
        'dptset = dptdb.OpenRecordset("cc_Cont", dao.RecordsetTypeEnum.dbOpenDynaset)

        ''UPGRADE_WARNING: Couldn't resolve default property of object cont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'dptset.FindFirst("contract_key = " & Chr(34) & cont & Chr(34))

        'If dptset.NoMatch Then
        '	'valid_dpt = "N"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object desc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	desc = Year(Today)
        '	'UPGRADE_WARNING: Couldn't resolve default property of object desc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	desc = CStr(Year(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 6, Today)))

        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object desc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	desc = dptset.Fields("fiscal_yr").Value

        'End If


    End Sub

    Public Sub get_prog_rate(ByVal cont As Object, ByVal fiscal As Object)

        'Dim dptdb As dao.Database
        ''UPGRADE_WARNING: Arrays in structure dptset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim dptset As dao.Recordset
        'db = att_data_path & "aratt.mdb"
        'dptdb = DAODBEngine_definst.OpenDatabase(db)
        'dptset = dptdb.OpenRecordset("program", dao.RecordsetTypeEnum.dbOpenDynaset)
        ''UPGRADE_WARNING: Couldn't resolve default property of object cont. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = "prog_num = " & Chr(34) & cont & Chr(34)
        ''UPGRADE_WARNING: Couldn't resolve default property of object fiscal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = sqlstmnt & " and fiscal_yr = " & Chr(34) & fiscal & Chr(34)

        'dptset.FindFirst(sqlstmnt)

        'If dptset.NoMatch Then
        '	valid_dpt = "N"

        'Else
        '	selected_prog_rate = dptset.Fields("prog_rate").Value

        'End If

    End Sub

    Function etsprognum_chk(ByVal sendprm As String, ByVal sendfiscal As String) As Boolean

        If ETSCommon.CheckYN("program", "prog_num", sendprm, sendfiscal) = "Y" Then
            Return True
        Else
            Return False
        End If
    End Function
	
    Public Sub find_unique(ByVal cont As String)
        Select Case cont
            Case "CONTRACT"
                sqlstmnt = "select distinct contract_key from attend_tmp order by contract_key"
            Case "CLIENT"
                sqlstmnt = "select distinct name_key from attend_tmp order by name_key"
            Case Else  'unique bnum
                sqlstmnt = "select distinct b_num from attend_tmp order by b_num"
        End Select

    End Sub

    Public Sub ContractSeparate(ByVal selected_contract_key As String)
        selected_cont_id_num = MakeJRIContractID(selected_contract_key)  ' Left(selected_contract_key, Len(selected_contract_key) - 4)
        selected_mmars_num = Mid(selected_contract_key, Len(selected_contract_key) - 3, 2)
        selected_amend_num = Right(selected_contract_key, 2)
    End Sub

    Public Function cont_key_remove_Dashes(ByVal sendstring As String) As String
        Return Left(sendstring, 2) & Mid(sendstring, 4, 3) & Mid(sendstring, 8, 4) & Mid(sendstring, 13, 4) & Mid(sendstring, 18, 3) & Mid(sendstring, 22, 2) & Mid(sendstring, 25, 2)
    End Function

    Public Function cont_key_display(ByVal sendstring As String) As String
        Return Left(sendstring, 2) & "-" & Mid(sendstring, 3, 3) & "-" & Mid(sendstring, 6, 6) & "-" & Mid(sendstring, 12, 2) & "-" & Mid(sendstring, 14, 3) & "-" & Mid(sendstring, 17, 2) & "-" & Mid(sendstring, 19, 2)
    End Function

    Public Function MakeJRIContractID(ByVal Contract As String) As String
        Return Contract.Substring(0, 2) & "-" & Contract.Substring(2, 3) & "-" & Contract.Substring(5, 6) & "-" & Contract.Substring(11, 2) & "-" & Contract.Substring(13, 3) '& "-" & Contract.Substring(16, 2) & "-" & Contract.Substring(18, 2)
    End Function
	Public Sub count_units()
        '		Dim attend_rpt As Object
		
        'If tmpset.Fields("att_Code").Value = "X" Or tmpset.Fields("att_Code").Value = "A" Or tmpset.Fields("att_Code").Value = "B" Or tmpset.Fields("att_Code").Value = "E" Then
        '	attend_rpt.Fields("unit_tot") = attend_rpt.Fields("unit_tot") + tmpset.Fields("att_unit").Value
        '	attend_rpt.Fields("dol_tot") = attend_rpt.Fields("dol_tot") + VB6.Format(tmpset.Fields("unit_rate").Value * tmpset.Fields("att_unit").Value, "FIXED")
        'End If
    End Sub

    Public Function CheckInvoiceFolder(ByVal End_Date As String, ByVal Contract_Key As String) As String
        'see if folder exists and if not create it.
        'return the full path
        'get fiscal year from contract
        Dim FY As String = "FY" & ETSCommon.GetDatum("cc_cont", "contract_key", Contract_Key, "fiscal_yr")
        Dim Sname As String = ETSCommon.GetDatum("cc_cont", "contract_key", Contract_Key, "name_key")
        Dim SortName As String = ETSCommon.GetDatum("nam_addr", "name_key", Sname, "sort_name")
        Dim desiredpathname As String = InvoiceLocation & FY & "\" & SortName & "\"
        If Not Directory.Exists(desiredpathname) Then
            Directory.CreateDirectory(desiredpathname)
        End If
        Return desiredpathname

    End Function

    Public Function invoice_string_Create(ByVal End_Date As String, ByVal ContractKey As String) As String
        Dim wild As String
        Dim num2 As Integer
        Dim invoice_String As String = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "inv_string")
        Dim inv_build = invoice_String.Split(CChar("*"))
        'get the invoice_String and make the invoice number and return it
        'first count the number of wild cards
        num2 = invoice_String.Split(CChar("*")).Length - 1
        '		'now create the wild card
        If num2 <> 0 Then 'put in the wild card
            Response = Month(CDate(End_Date)) + 6
            If Response > 12 Then
                Response = Response - 12
            End If
            Dim inyear As Integer
            If Response > 6 Then
                inyear = Year(CDate(End_Date))
            Else
                inyear = Year(CDate(End_Date)) + 1
            End If
            wild = Response.ToString("D2") & Right(inyear.ToString, 2)
            invoice_String = inv_build(0).ToString & wild.ToString & inv_build(num2).ToString
        End If

        Return invoice_String

    End Function

	Public Sub pv_to_invoice()
        '		Dim mmpv As Object
        '		Dim invoice As Object
        '		Dim selected_look_num As Object
		' the pv num is selected_lookup_num
        'tmp1db = DAODBEngine_definst.OpenDatabase(att_data_path & "aratt.mdb")
        ''UPGRADE_WARNING: Couldn't resolve default property of object selected_look_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = "select * from mmpv_tmp where pv_form = " & Chr(34) & selected_look_num & Chr(34)
        'tmp1set = tmp1db.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        'tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
        'invoice = tmpdb.OpenRecordset("invoice")

        ''UPGRADE_WARNING: Couldn't resolve default property of object mmpv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not mmpv.Recordset.EOF
        '	'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	invoice.Recordset.AddNew()
        '	'          invoice.Recordset.Fields("invoice") = invoice_full
        '	'         invoice.Recordset.Fields("line_num") = num + 1
        '	'       invoice.Recordset.Fields("inv_num") = high_inv_num
        '	'      invoice.Recordset.Fields("trans_code") = "inv"
        '	''     invoice.Recordset.Fields("po_num") = Contract.Recordset.Fields("lea_order_num")
        '	'   invoice.Recordset.Fields("name_key") = attend_rpt.Recordset.Fields("cust_num")
        '	'look up the proper name
        '	'  Call chkname(invoice.Recordset.Fields("name_key"))
        '	' invoice.Recordset.Fields("screen_nam") = selected_screen_nam
        '	'invoice.Recordset.Fields("sort_name") = selected_sort_name
        '	'           invoice.Recordset.Fields("cc_num") = attend_rpt.Recordset.Fields("name_key")
        '	'          invoice.Recordset.Fields("cc_name") = attend_rpt.Recordset.Fields("screen_nam")
        '	'         invoice.Recordset.Fields("inv_desc") = Contract.Recordset.Fields("cont_desc")
        '	'        invoice.Recordset.Fields("cr_acct_nu") = attend_rpt.Recordset.Fields("cr_acct_nu")
        '	'       invoice.Recordset.Fields("dr_acct_nu") = attend_rpt.Recordset.Fields("dr_acct_nu")
        '	'      invoice.Recordset.Fields("alloc_amt") = tot_amt - Contract.Recordset.Fields("bill_offset")
        '	'     invoice.Recordset.Fields("entry_date") = Date
        '	'    invoice.Recordset.Fields("invoice_date") = attend_rpt.Recordset.Fields("invoice_date")
        '	'   invoice.Recordset.Fields("dt_tbe_pd") = DateAdd("d", 30, attend_rpt.Recordset.Fields("invoice_date"))
        '	'  invoice.Recordset.Fields("encum_num") = attend_rpt.Recordset.Fields("invoice_date")
        '	' invoice.Recordset.Fields("bal_due") = attend_rpt.Recordset.Fields("dol_tot") - cc_fund.Recordset.Fields("offset")
        '	'invoice.Recordset.Fields("inv_Amt") = tot_amt - cc_fund.Recordset.Fields("offset")
        '	'UPGRADE_WARNING: Couldn't resolve default property of object invoice.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	invoice.Recordset.Update()
        '	num = num + 1

        '	'UPGRADE_WARNING: Couldn't resolve default property of object mmpv.Recordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	mmpv.Recordset.MoveNext()
        'Loop 
	End Sub
	
    Public Sub update_contract_ytd(ByVal selected_contract_key As String)
        'here we refigure the ytd and the lastest month to date amounts
        'needed for voids and other updates
        '(isnull(bal_due,0) - isnull(chk_alloc,0)) as newbal

        sqlstmnt = " update cc_Cont set last_invnum = '', last_billdate = '1/1/1901' , month_units = 0, month_dol = 0 "
        sqlstmnt = sqlstmnt & " WHERE   contract_key = '" & selected_contract_key & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        'sqlstmnt = " UPDATE  cc_cont SET  ytd_units = (SELECT isnull(SUM(unit_tot),0) AS sumtot"
        'sqlstmnt = sqlstmnt & " FROM attend_rpt_hist WHERE (contract_key = '" & selected_contract_key & "' AND void = 'N')), ytd_dol ="
        'sqlstmnt = sqlstmnt & " (SELECT isnull(SUM(dol_Tot),0) AS sumtot   FROM  attend_rpt_hist AS attend_rpt_hist_1"
        'sqlstmnt = sqlstmnt & " WHERE   (contract_key = '" & selected_contract_key & "' AND void = 'N'))"
        'sqlstmnt = sqlstmnt & " WHERE (contract_key = '" & selected_contract_key & "')"  'to makeit only one contractg
        sqlstmnt = " UPDATE  cc_cont SET  ytd_units = (SELECT isnull(SUM(units),0) AS sumtot"
        sqlstmnt = sqlstmnt & " FROM invoice WHERE (contract_key = '" & selected_contract_key & "' AND void = 'N')), ytd_dol ="
        sqlstmnt = sqlstmnt & " (SELECT isnull(SUM(alloc_amt),0) AS sumtot   FROM  invoice AS attend_rpt_hist_1"
        sqlstmnt = sqlstmnt & " WHERE   (contract_key = '" & selected_contract_key & "' AND void = 'N'))"
        sqlstmnt = sqlstmnt & " WHERE (contract_key = '" & selected_contract_key & "')"  'to makeit only one contractg

        ETSSQL.ExecuteSQL(sqlstmnt)

        sqlstmnt = " Update cc_Cont set rem_dol = (cont_dol + amend_dol - ytd_dol), rem_units = (cont_units + amend_units - ytd_units) where contract_key = '" & selected_contract_key & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

    End Sub
	
    Public Sub pca_div_b_num(ByVal b_num As String, ByVal selected_contract_key As String, ByVal selected_name_key As String)
        Dim test_String As String
        test_String = Left(b_num, 2)
        If CDbl(Left(test_String, 1)) = 0 And Not IsNumeric(Right(test_String, 1)) Then
            selected_contract_key = Right(b_num, 20)
            selected_name_key = Left(b_num, 5) 'chg from 6 to 5 1/18/06 lhw

        Else
            '			For num = 1 To Len(b_num) - 1
            'If Not IsNumeric(Mid(b_num, num, 1)) Then
            selected_contract_key = Right(b_num, Len(b_num) - num + 1)
            selected_name_key = Left(b_num, num - 1)
            'Exit For
            'End If
            '	Next 
        End If

    End Sub

    Public Function CreatFundingRecord(ByVal nameKey As String, ByVal ContractKey As String) As List(Of FundingData)

        Dim FundRowData As List(Of FundingData)
        FundRowData = ETSSQL.GetBlankFundData
        Dim RID As New List(Of ClientBaseData)
        RID = ETSSQL.GetClientBaseData("select * from cc_base where name_key = '" & selected_name_key & "'")
        Dim ContractRowData As New List(Of ContractData)
        ContractRowData = ETSSQL.GetContractData("Select * from cc_cont where contract_key = '" & ContractKey & "'")
        FundRowData.Item(0).BNum = NameKey & ContractKey
        FundRowData.Item(0).NameKey = NameKey
        FundRowData.Item(0).ScreenNam = RID.Item(0).ScreenNam
        FundRowData.Item(0).SortName = RID.Item(0).SortName
        FundRowData.Item(0).ContractKey = ContractKey
        FundRowData.Item(0).ContIdNum = ContractRowData.Item(0).ContIdNum
        FundRowData.Item(0).MmarsNum = ContractRowData.Item(0).MmarsNum
        FundRowData.Item(0).AmendNum = ContractRowData.Item(0).AmendNum
        FundRowData.Item(0).Closed = "N"
        FundRowData.Item(0).ClientTotal = 0
        FundRowData.Item(0).Dflag = "N"
        FundRowData.Item(0).Agency = 1
        FundRowData.Item(0).BillType = ContractRowData.Item(0).BillType
        FundRowData.Item(0).BegDate = RID.Item(0).AdmitDate
        FundRowData.Item(0).EndDate = ContractRowData.Item(0).ContEndD
        FundRowData.Item(0).Active = "Y"
        FundRowData.Item(0).SlotNum = 1
        ' fundrowdata.Item(0).NameChk
        FundRowData.Item(0).AttCode = "X"
        FundRowData.Item(0).AttUnit = 1
        FundRowData.Item(0).ProgNum = ContractRowData.Item(0).ProgNum
        FundRowData.Item(0).UnitRate = 0
        FundRowData.Item(0).Offset = 0
        FundRowData.Item(0).Mon = "N"
        FundRowData.Item(0).Tue = "N"
        FundRowData.Item(0).Wed = "N"
        FundRowData.Item(0).Thu = "N"
        FundRowData.Item(0).Fri = "N"
        FundRowData.Item(0).Sat = "N"
        FundRowData.Item(0).Sun = "N"
        FundRowData.Item(0).Type = ContractRowData.Item(0).ProgType
        FundRowData.Item(0).DrAcctNu = ContractRowData.Item(0).DrAcctNu
        FundRowData.Item(0).CrAcctNu = ContractRowData.Item(0).CrAcctNu
        '  fundrowdata.Item(0).RefProvNum
        ' fundrowdata.Item(0).MedSource
        FundRowData.Item(0).BudAmt = 0
        FundRowData.Item(0).SpecAmt = 0

        If ContractRowData.Item(0).BillType = "125" Then
            FundRowData.Item(0).Mon = "1"
            FundRowData.Item(0).Tue = "1"
            FundRowData.Item(0).Wed = "1"
            FundRowData.Item(0).Thu = "1"
            FundRowData.Item(0).Fri = "1"
            FundRowData.Item(0).Sat = "1"
            FundRowData.Item(0).Sun = "1"
            FundRowData.Item(0).AttCode = "1"
        End If


        Return FundRowData

    End Function

    Public Sub prepare_attend_rpt(ByVal selected_contract_key As String, ByVal start_date As String, ByVal End_Date As String)
        'this create the table of summary records for reporting purposes
        'it starts with tmp and creates on record for each bnum avail

        'if this a retro bill the units are zeroed at the end
        'xxx should the daily units be zeroed also

        'it also checks the max obs

        Dim total_eep_units As Integer
        Dim max_obs As Decimal
        Dim max_units As Decimal
        max_obs = 0
        max_units = 0

        'line counter for eep
        Dim num_sdr As Integer
        num_sdr = 0
        Dim total_eep As Decimal

        sqlstmnt = "delete from attend_rpt"
        ETSSQL.ExecuteSQL(sqlstmnt)
        selected_b_num = ""
        billable_codes = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "billable_codes")

        sqlstmnt = " select distinct b_num from attend_Tmp where contract_key = '" & selected_contract_key
        sqlstmnt = sqlstmnt & "' and att_Date between '" & start_date.ToString
        sqlstmnt = sqlstmnt & "' and '" & End_Date.ToString
        sqlstmnt = sqlstmnt & "' order by b_num"

        Dim BNumList As String = ETSSQL.GetBNumList(sqlstmnt)
        Dim BNums As String() = BNumList.Split(CChar("*"))
        For Each BNum In BNums
            If Len(BNum) <> 0 Then
                sqlstmnt = " select * from attend_Tmp where b_num = '" & BNum
                sqlstmnt = sqlstmnt & "' and att_Date between '" & start_date.ToString
                sqlstmnt = sqlstmnt & "' and '" & End_Date.ToString
                sqlstmnt = sqlstmnt & "' order by att_date"
                Dim AttendMth As New List(Of AttendData)
                AttendMth = ETSSQL.GetAttendanceData(sqlstmnt)
                Dim AttendRpt As New AttendReportData
                For Each AttendDay In AttendMth
                    AttendRpt.BNum = AttendDay.BNum
                    AttendRpt.NameKey = AttendDay.NameKey
                    AttendRpt.ContractKey = AttendDay.ContractKey
                    AttendRpt.ScreenNam = AttendDay.ScreenNam
                    AttendRpt.SortName = AttendDay.SortName
                    AttendRpt.AuthoNum = AttendDay.AuthoNum
                    AttendRpt.BillType = AttendDay.BillType
                    AttendRpt.PvForm = AttendDay.PvForm
                    AttendRpt.RptType = AttendDay.RptType
                    AttendRpt.UnitRate = AttendDay.UnitRate
                    AttendRpt.Offset = AttendDay.Offset
                    AttendRpt.SlotNum = AttendDay.SlotNum
                    AttendRpt.NameChk = AttendDay.NameChk
                    AttendRpt.SsNum = AttendDay.SsNum
                    AttendRpt.MedNum = AttendDay.MedNum
                    If AttendRpt.AttBeg.Year = 1 Then       'put a date in if no date in
                        AttendRpt.AttBeg = AttendDay.AttDate
                    End If
                    AttendRpt.AttCode = AttendDay.AttCode
                    AttendRpt.AttUnit = AttendDay.AttUnit
                    AttendRpt.InvoiceDate = selected_inv_date
                    AttendRpt.Invoice = id_num
                    AttendRpt.CustNum = AttendDay.CustNum
                    AttendRpt.DrAcctNu = AttendDay.DrAcctNu
                    AttendRpt.CrAcctNu = AttendDay.CrAcctNu
                    AttendRpt.EntryDate = Today
                    AttendRpt.Dflag = AttendDay.Dflag
                    AttendRpt.Agency = AttendDay.Agency
                    '  AttendRpt.PayCat = AttendDay.
                    AttendRpt.AttEnd = AttendDay.AttDate
                    AttendRpt.ClientPct = AttendDay.ClientPct
                    AttendRpt.Void = AttendDay.Void
                    Select Case AttendDay.AttDate.Day
                        Case 1
                            AttendRpt.D1 = AttendDay.AttCode
                        Case 2
                            AttendRpt.D2 = AttendDay.AttCode
                        Case 3
                            AttendRpt.D3 = AttendDay.AttCode
                        Case 4
                            AttendRpt.D4 = AttendDay.AttCode
                        Case 5
                            AttendRpt.D5 = AttendDay.AttCode
                        Case 6
                            AttendRpt.D6 = AttendDay.AttCode
                        Case 7
                            AttendRpt.D7 = AttendDay.AttCode
                        Case 8
                            AttendRpt.D8 = AttendDay.AttCode
                        Case 9
                            AttendRpt.D9 = AttendDay.AttCode
                        Case 10
                            AttendRpt.D10 = AttendDay.AttCode
                        Case 11
                            AttendRpt.D11 = AttendDay.AttCode
                        Case 12
                            AttendRpt.D12 = AttendDay.AttCode
                        Case 13
                            AttendRpt.D13 = AttendDay.AttCode
                        Case 14
                            AttendRpt.D14 = AttendDay.AttCode
                        Case 15
                            AttendRpt.D15 = AttendDay.AttCode
                        Case 16
                            AttendRpt.D16 = AttendDay.AttCode
                        Case 17
                            AttendRpt.D17 = AttendDay.AttCode
                        Case 18
                            AttendRpt.D18 = AttendDay.AttCode
                        Case 19
                            AttendRpt.D19 = AttendDay.AttCode
                        Case 20
                            AttendRpt.D20 = AttendDay.AttCode
                        Case 21
                            AttendRpt.D21 = AttendDay.AttCode
                        Case 22
                            AttendRpt.D22 = AttendDay.AttCode
                        Case 23
                            AttendRpt.D23 = AttendDay.AttCode
                        Case 24
                            AttendRpt.D24 = AttendDay.AttCode
                        Case 25
                            AttendRpt.D25 = AttendDay.AttCode
                        Case 26
                            AttendRpt.D26 = AttendDay.AttCode
                        Case 27
                            AttendRpt.D27 = AttendDay.AttCode
                        Case 28
                            AttendRpt.D28 = AttendDay.AttCode
                        Case 29
                            AttendRpt.D29 = AttendDay.AttCode
                        Case 30
                            AttendRpt.D30 = AttendDay.AttCode
                        Case 31
                            AttendRpt.D31 = AttendDay.AttCode
                    End Select

                    If InStr(billable_codes, AttendDay.AttCode) <> 0 And Len(AttendDay.AttCode) <> 0 Then
                        AttendRpt.UnitTot = CDec(AttendRpt.UnitTot + AttendDay.AttUnit)
                        AttendRpt.DolTot = CDec(AttendRpt.DolTot + AttendDay.UnitRate * AttendDay.AttUnit)
                    End If
                    If AttendDay.BillType = "125" Then
                        AttendRpt.UnitTot = CDec(AttendRpt.UnitTot + CDbl(AttendDay.AttCode))
                        AttendRpt.DolTot = CDec(AttendRpt.DolTot + AttendDay.UnitRate * CDbl(AttendDay.AttCode))
                    End If
                    If AttendDay.BillType = "140" Then
                        AttendRpt.PayCat = ETSCommon.GetDatum("Cc_autho", "b_num", AttendDay.BNum, "pay_cat")
                    End If
                    If AttendDay.BillType = "161" Then
                        Dim NumDays As Integer = Date.DaysInMonth(Year(AttendDay.AttDate), Month(AttendDay.AttDate))
                        AttendRpt.UnitTot = AttendRpt.UnitRate * NumDays
                        AttendRpt.DolTot = AttendDay.UnitRate * NumDays
                        AttendRpt.AttEnd = DateAdd(DateInterval.Day, NumDays, AttendRpt.AttBeg)
                    End If

                    max_obs = max_obs + AttendRpt.DolTot
                    max_units = max_units + AttendRpt.UnitTot
                    If amend_type = "RETRO" Then
                        AttendRpt.UnitTot = 0
                    End If

                    'we now save the date for att end to put into the max obs and ssi etc
                    saved_end_Date = AttendRpt.AttEnd
                Next

                'subtract the offset
                AttendRpt.DolTot = AttendRpt.DolTot + AttendRpt.Offset
                'flat rate handled on contract by contract basis so done here
                Dim FlatRate As Double = CDbl(ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "flat_rate"))
                If FlatRate <> 0 Then
                    AttendRpt.DolTot = CDec(FlatRate)
                    'If AttendRpt.UnitTot < 28 Then
                    '    AttendRpt.DolTot = CDec(FlatRate * AttendRpt.UnitTot / 18)
                    'End If
                    If AttendRpt.UnitTot <> DateDiff(DateInterval.Day, CDate(start_date), CDate(End_Date)) + 1 Then
                        AttendRpt.DolTot = CDec(Math.Round(((FlatRate * 10) / 180) * AttendRpt.UnitTot, 2))
                    End If

                End If
                tot_amt = AttendRpt.DolTot
                total_units = AttendRpt.UnitTot

                sqlstmnt = "insert into attend_rpt " & AttendRpt.AttendReportColumnNames & "  values " & AttendRpt.AttendReportColumnData
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If
        Next

        'xxxxxxxxxxxxxxxxxxxxxx

        ''now we check if the maximum obligations have been exceeded
        ''so is the total for this contract in excess of the remaining
        ''if yes write out a new record with minus amounts
        'the first test on max obs are there any $$ on the contract - if yes then test

        Dim ValueContract As New List(Of ContractData)
        ValueContract = ETSSQL.GetContractData("select * from cc_Cont where contract_key = '" & selected_contract_key & "'")

        If ValueContract.Item(0).ContDol > 0 Then
            If (ValueContract.Item(0).ContDol + ValueContract.Item(0).AmendDol - ValueContract.Item(0).SeedDol - ValueContract.Item(0).YtdDol + ValueContract.Item(0).BillOffset - max_obs) < 0 Then
                '		'we now create the minus record
                ' new record with blanks in all the d fields
                Dim AttendRptOBS As New AttendReportData
                AttendRptOBS = ETSSQL.GetBlankAttendReportData
                AttendRptOBS.NameKey = "99999"
                AttendRptOBS.ContractKey = selected_contract_key
                AttendRptOBS.BNum = AttendRptOBS.NameKey & AttendRptOBS.ContractKey
                AttendRptOBS.ScreenNam = "Max Obs Offset"
                AttendRptOBS.SortName = "Max Obs Offset"
                AttendRptOBS.NameChk = "MO"
                AttendRptOBS.Offset = 0
                AttendRptOBS.SlotNum = 99
                AttendRptOBS.SsNum = "  "
                AttendRptOBS.MedNum = "  "
                AttendRptOBS.BillType = ValueContract.Item(0).BillType
                AttendRptOBS.ClientPct = 0
                AttendRptOBS.UnitRate = ValueContract.Item(0).UnitRate
                AttendRptOBS.AttUnit = 0
                AttendRptOBS.Agency = ValueContract.Item(0).Agency
                AttendRptOBS.InvoiceDate = selected_inv_date
                AttendRptOBS.Invoice = id_num
                AttendRptOBS.DrAcctNu = ValueContract.Item(0).DrAcctNu
                AttendRptOBS.CrAcctNu = ValueContract.Item(0).CrAcctNu
                AttendRptOBS.CustNum = ValueContract.Item(0).NameKey
                AttendRptOBS.DolTot = ValueContract.Item(0).RemDol - tot_amt
                AttendRptOBS.UnitTot = CDec(ValueContract.Item(0).RemUnits - total_units)
                AttendRptOBS.AttEnd = saved_end_Date
                If AttendRptOBS.AttBeg.Year = 1 Then       'put a date in if no date in
                    AttendRptOBS.AttBeg = CDate(start_date)
                End If
                AttendRptOBS.EntryDate = Today
                sqlstmnt = "insert into attend_rpt " & AttendRptOBS.AttendReportColumnNames & "  values " & AttendRptOBS.AttendReportColumnData
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If
        End If
        '	'now for the ssi offset
        'If ValueContract.Item(0).BillOffset > 0 Then
        '    ' new record with blanks in all the d fields
        '    Dim AttendRptSSI As New AttendReportData
        '    AttendRptSSI = ETSSQL.GetBlankAttendReportData
        '    AttendRptSSI.NameKey = "99998"
        '    AttendRptSSI.BNum = AttendRptSSI.NameKey & AttendRptSSI.ContractKey
        '    AttendRptSSI.ScreenNam = "SSI Offset"
        '    AttendRptSSI.SortName = "SSI Offset"
        '    AttendRptSSI.NameChk = "SSI"
        '    AttendRptSSI.SlotNum = 98
        '    AttendRptSSI.SsNum = "  "
        '    AttendRptSSI.MedNum = "  "
        '    AttendRptSSI.InvoiceDate = selected_inv_date
        '    AttendRptSSI.Invoice = id_num
        '    AttendRptSSI.Offset = ValueContract.Item(0).BillOffset * -1
        '    AttendRptSSI.DolTot = ValueContract.Item(0).BillOffset * -1
        '    AttendRptSSI.UnitTot = 0
        '    AttendRptSSI.AttEnd = saved_end_Date
        '    If AttendRptSSI.AttBeg.Year = 1 Then       'put a date in if no date in
        '        AttendRptSSI.AttBeg = CDate(start_date)
        '    End If
        '    AttendRptSSI.EntryDate = Today
        '    sqlstmnt = "insert into attend_rpt " & AttendRptSSI.AttendReportColumnNames & "  values " & AttendRptSSI.AttendReportColumnData
        '    ETSSQL.ExecuteSQL(sqlstmnt)
        '    '      End If
        'End If 'for $$ on contract

        '      'now for the flat rate
        ' a new line is not added since dol to set to flat rate
        'If ValueContract.Item(0).FlatRate > 0 Then
        '    ' new record with blanks in all the d fields
        '    Dim AttendRptFFee As New AttendReportData
        '    AttendRptFFee = ETSSQL.GetBlankAttendReportData
        '    AttendRptFFee.NameKey = "99997"
        '    AttendRptFFee.BNum = AttendRptFFee.NameKey & AttendRptFFee.ContractKey
        '    AttendRptFFee.ScreenNam = "Flat Rate"
        '    AttendRptFFee.SortName = "Flat Rate"
        '    AttendRptFFee.NameChk = "FR"
        '    AttendRptFFee.Offset = ValueContract.Item(0).FlatRate * -1
        '    AttendRptFFee.SlotNum = 97
        '    AttendRptFFee.SsNum = "  "
        '    AttendRptFFee.MedNum = "  "
        '    AttendRptFFee.InvoiceDate = selected_inv_date
        '    AttendRptFFee.Invoice = id_num
        '    AttendRptFFee.DolTot = ValueContract.Item(0).FlatRate - tot_amt
        '    AttendRptFFee.UnitTot = 0
        '    AttendRptFFee.AttEnd = saved_end_Date
        '    If AttendRptFFee.AttBeg.Year = 1 Then       'put a date in if no date in
        '        AttendRptFFee.AttBeg = CDate(start_date)
        '    End If
        '    AttendRptFFee.EntryDate = Today
        '    sqlstmnt = "insert into attend_rpt " & AttendRptFFee.AttendReportColumnNames & "  values " & AttendRptFFee.AttendReportColumnData
        '    ETSSQL.ExecuteSQL(sqlstmnt)
        '    '      End If 'for flat rate
        '    '      End If
        'End If 'for flat rate

        '      'now for the eep contract

        If selected_bill_type = "120" And ValueContract.Item(0).Code3 = "EEP" Then
            Dim num_people As Double

            '              'make the calculation to see if need to create a record
tryagain:
            Response = CInt(Val(InputBox("Input the number of billable days this month.")))
            If Response = 0 Then
                MsgBox("There will be no EEP adjustment.")
                Exit Sub
            End If

            If Response > 31 Or Response < 1 Then
                MsgBox("Invalid response for days in the month.")
                GoTo tryagain
            End If

            num_people = Val(InputBox("Input the number of slots in the contract."))
            If num_people < 1 Then
                MsgBox("There will be no EEP adjustment.")
                Exit Sub
            End If

            'billable amount = number of lines of sdr times the days * .85
            total_eep = CDec(num_people * Response * 0.85 * cont_rate)
            total_eep_units = CInt(num_people * Response * 0.85)
            total_eep_units = CInt(Int(num_people * Response * 0.85))
            total_eep = total_eep_units * ValueContract.Item(0).UnitRate


            '  tmpset.MoveFirst()
            ' attend_rpt.MoveLast
            ' tot_amt = attend_rpt.Fields("dol_tot")
            ' tot_units = attend_rpt.Fields("unit_Tot")

            If max_obs > total_eep Then
                ' new record with blanks in all the d fields
                Dim AttendRptEEP As New AttendReportData
                AttendRptEEP = ETSSQL.GetBlankAttendReportData
                AttendRptEEP.NameKey = "99996"
                AttendRptEEP.BNum = AttendRptEEP.NameKey & AttendRptEEP.ContractKey
                AttendRptEEP.ScreenNam = "Percentage Reduction"
                AttendRptEEP.SortName = "Percentage Reduction"
                AttendRptEEP.NameChk = "PR"
                AttendRptEEP.Offset = ValueContract.Item(0).FlatRate * -1
                AttendRptEEP.SlotNum = 96
                AttendRptEEP.SsNum = "  "
                AttendRptEEP.MedNum = "  "
                AttendRptEEP.InvoiceDate = selected_inv_date
                AttendRptEEP.Invoice = id_num
                AttendRptEEP.DolTot = total_eep - max_obs
                AttendRptEEP.UnitTot = total_eep_units - max_units
                AttendRptEEP.AttEnd = saved_end_Date
                If AttendRptEEP.AttBeg.Year = 1 Then       'put a date in if no date in
                    AttendRptEEP.AttBeg = CDate(start_date)
                End If
                AttendRptEEP.EntryDate = Today
                sqlstmnt = "insert into attend_rpt " & AttendRptEEP.AttendReportColumnNames & "  values " & AttendRptEEP.AttendReportColumnData
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If
        End If

    End Sub

    '    Public Sub prepare_attend_rpt(ByVal selected_contract_key As String, ByVal start_date As String, ByVal End_Date As String)
    '        'this create the table of summary records for reporting purposes
    '        'it starts with tmp and creates on record for each bnum avail

    '        'if this a retro bill the units are zeroed at the end
    '        'xxx should the daily units be zeroed also

    '        'it also checks the max obs

    '        Dim total_eep_units As Integer
    '        Dim max_obs As Decimal
    '        Dim max_units As Decimal
    '        max_obs = 0
    '        max_units = 0

    '        'line counter for eep
    '        Dim num_sdr As Integer
    '        num_sdr = 0
    '        Dim total_eep As Decimal

    '        sqlstmnt = "delete from attend_rpt"
    '        ETSSQL.ExecuteSQL(sqlstmnt)
    '        selected_b_num = ""
    '        billable_codes = ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "billable_codes")

    '        sqlstmnt = " select distinct b_num from attend_Tmp where contract_key = '" & selected_contract_key
    '        sqlstmnt = sqlstmnt & "' and att_Date between '" & start_date.ToString
    '        sqlstmnt = sqlstmnt & "' and '" & End_Date.ToString
    '        sqlstmnt = sqlstmnt & "' order by b_num"

    '        Dim BNumList As String = ETSSQL.GetBNumList(sqlstmnt)
    '        Dim BNums As String() = BNumList.Split(CChar("*"))
    '        For Each BNum In BNums
    '            If Len(BNum) <> 0 Then
    '                sqlstmnt = " select * from attend_Tmp where b_num = '" & BNum
    '                sqlstmnt = sqlstmnt & "' and att_Date between '" & start_date.ToString
    '                sqlstmnt = sqlstmnt & "' and '" & End_Date.ToString
    '                sqlstmnt = sqlstmnt & "' order by att_date"
    '                Dim AttendMth As New List(Of AttendData)
    '                AttendMth = ETSSQL.GetAttendanceData(sqlstmnt)
    '                Dim AttendRpt As New AttendReportData
    '                For Each AttendDay In AttendMth
    '                    AttendRpt.BNum = AttendDay.BNum
    '                    AttendRpt.NameKey = AttendDay.NameKey
    '                    AttendRpt.ContractKey = AttendDay.ContractKey
    '                    AttendRpt.ScreenNam = AttendDay.ScreenNam
    '                    AttendRpt.SortName = AttendDay.SortName
    '                    AttendRpt.AuthoNum = AttendDay.AuthoNum
    '                    AttendRpt.BillType = AttendDay.BillType
    '                    AttendRpt.PvForm = AttendDay.PvForm
    '                    AttendRpt.RptType = AttendDay.RptType
    '                    AttendRpt.UnitRate = AttendDay.UnitRate
    '                    AttendRpt.Offset = AttendDay.Offset
    '                    AttendRpt.SlotNum = AttendDay.SlotNum
    '                    AttendRpt.NameChk = AttendDay.NameChk
    '                    AttendRpt.SsNum = AttendDay.SsNum
    '                    AttendRpt.MedNum = AttendDay.MedNum
    '                    If AttendRpt.AttBeg.Year = 1 Then       'put a date in if no date in
    '                        AttendRpt.AttBeg = AttendDay.AttDate
    '                    End If
    '                    AttendRpt.AttCode = AttendDay.AttCode
    '                    AttendRpt.AttUnit = AttendDay.AttUnit
    '                    AttendRpt.InvoiceDate = selected_inv_date
    '                    AttendRpt.Invoice = id_num
    '                    AttendRpt.CustNum = AttendDay.CustNum
    '                    AttendRpt.DrAcctNu = AttendDay.DrAcctNu
    '                    AttendRpt.CrAcctNu = AttendDay.CrAcctNu
    '                    AttendRpt.EntryDate = Today
    '                    AttendRpt.Dflag = AttendDay.Dflag
    '                    AttendRpt.Agency = AttendDay.Agency
    '                    '  AttendRpt.PayCat = AttendDay.
    '                    AttendRpt.AttEnd = AttendDay.AttDate
    '                    AttendRpt.ClientPct = AttendDay.ClientPct
    '                    AttendRpt.Void = AttendDay.Void
    '                    Select Case AttendDay.AttDate.Day
    '                        Case 1
    '                            AttendRpt.D1 = AttendDay.AttCode
    '                        Case 2
    '                            AttendRpt.D2 = AttendDay.AttCode
    '                        Case 3
    '                            AttendRpt.D3 = AttendDay.AttCode
    '                        Case 4
    '                            AttendRpt.D4 = AttendDay.AttCode
    '                        Case 5
    '                            AttendRpt.D5 = AttendDay.AttCode
    '                        Case 6
    '                            AttendRpt.D6 = AttendDay.AttCode
    '                        Case 7
    '                            AttendRpt.D7 = AttendDay.AttCode
    '                        Case 8
    '                            AttendRpt.D8 = AttendDay.AttCode
    '                        Case 9
    '                            AttendRpt.D9 = AttendDay.AttCode
    '                        Case 10
    '                            AttendRpt.D10 = AttendDay.AttCode
    '                        Case 11
    '                            AttendRpt.D11 = AttendDay.AttCode
    '                        Case 12
    '                            AttendRpt.D12 = AttendDay.AttCode
    '                        Case 13
    '                            AttendRpt.D13 = AttendDay.AttCode
    '                        Case 14
    '                            AttendRpt.D14 = AttendDay.AttCode
    '                        Case 15
    '                            AttendRpt.D15 = AttendDay.AttCode
    '                        Case 16
    '                            AttendRpt.D16 = AttendDay.AttCode
    '                        Case 17
    '                            AttendRpt.D17 = AttendDay.AttCode
    '                        Case 18
    '                            AttendRpt.D18 = AttendDay.AttCode
    '                        Case 19
    '                            AttendRpt.D19 = AttendDay.AttCode
    '                        Case 20
    '                            AttendRpt.D20 = AttendDay.AttCode
    '                        Case 21
    '                            AttendRpt.D21 = AttendDay.AttCode
    '                        Case 22
    '                            AttendRpt.D22 = AttendDay.AttCode
    '                        Case 23
    '                            AttendRpt.D23 = AttendDay.AttCode
    '                        Case 24
    '                            AttendRpt.D24 = AttendDay.AttCode
    '                        Case 25
    '                            AttendRpt.D25 = AttendDay.AttCode
    '                        Case 26
    '                            AttendRpt.D26 = AttendDay.AttCode
    '                        Case 27
    '                            AttendRpt.D27 = AttendDay.AttCode
    '                        Case 28
    '                            AttendRpt.D28 = AttendDay.AttCode
    '                        Case 29
    '                            AttendRpt.D29 = AttendDay.AttCode
    '                        Case 30
    '                            AttendRpt.D30 = AttendDay.AttCode
    '                        Case 31
    '                            AttendRpt.D31 = AttendDay.AttCode
    '                    End Select


    '                    If InStr(billable_codes, AttendDay.AttCode) <> 0 And Len(AttendDay.AttCode) <> 0 Then
    '                        AttendRpt.UnitTot = CDec(AttendRpt.UnitTot + AttendDay.AttUnit)
    '                        AttendRpt.DolTot = CDec(AttendRpt.DolTot + AttendDay.UnitRate * AttendDay.AttUnit)
    '                    End If
    '                    If AttendDay.BillType = "125" Then
    '                        AttendRpt.UnitTot = CDec(AttendRpt.UnitTot + CDbl(AttendDay.AttCode))
    '                        AttendRpt.DolTot = CDec(AttendRpt.DolTot + AttendDay.UnitRate * CDbl(AttendDay.AttCode))
    '                    End If
    '                    If AttendDay.BillType = "140" Then
    '                        AttendRpt.PayCat = ETSCommon.GetDatum("Cc_autho", "b_num", AttendDay.BNum, "pay_cat")
    '                    End If
    '                    If AttendDay.BillType = "161" Then
    '                        Dim NumDays As Integer = Date.DaysInMonth(Year(AttendDay.AttDate), Month(AttendDay.AttDate))
    '                        AttendRpt.UnitTot = AttendRpt.UnitRate * NumDays
    '                        AttendRpt.DolTot = AttendDay.UnitRate * NumDays
    '                        AttendRpt.AttEnd = DateAdd(DateInterval.Day, NumDays, AttendRpt.AttBeg)
    '                    End If

    '                    max_obs = max_obs + AttendRpt.DolTot
    '                    max_units = max_units + AttendRpt.UnitTot
    '                    If amend_type = "RETRO" Then
    '                        AttendRpt.UnitTot = 0
    '                    End If

    '                    'we now save the date for att end to put into the max obs and ssi etc
    '                    saved_end_Date = AttendRpt.AttEnd
    '                Next

    '                'subtrract the offset
    '                AttendRpt.DolTot = AttendRpt.DolTot + AttendRpt.Offset
    '                'flat rate handled on contract by contract basis so done here
    '                Dim FlatRate As Double = CDbl(ETSCommon.GetDatum("cc_cont", "contract_key", selected_contract_key, "flat_rate"))
    '                If FlatRate <> 0 Then
    '                    AttendRpt.DolTot = CDec(FlatRate)
    '                    If AttendRpt.UnitTot < 28 Then
    '                        AttendRpt.DolTot = CDec(FlatRate * AttendRpt.UnitTot / 18)
    '                    End If
    '                End If

    '                sqlstmnt = "insert into attend_rpt " & AttendRpt.AttendReportColumnNames & "  values " & AttendRpt.AttendReportColumnData
    '                ETSSQL.ExecuteSQL(sqlstmnt)
    '            End If
    '        Next

    '        'xxxxxxxxxxxxxxxxxxxxxx

    '        ''now we check if the maximum obligations have been exceeded
    '        ''so is the total for this contract in excess of the remaining
    '        ''if yes write out a new record with minus amounts
    '        'the first test on max obs are there any $$ on the contract - if yest then test

    '        Dim ValueContract As New List(Of ContractData)
    '        ValueContract = ETSSQL.GetContractData("select * from cc_Cont where contract_key = '" & selected_contract_key & "'")

    '        If ValueContract.Item(0).ContDol > 0 Then
    '            If (ValueContract.Item(0).ContDol + ValueContract.Item(0).AmendDol - ValueContract.Item(0).SeedDol - ValueContract.Item(0).YtdDol + ValueContract.Item(0).BillOffset - max_obs) < 0 Then
    '                '		'we now create the minus record
    '                ' new record with blanks in all the d fields
    '                Dim AttendRptOBS As New AttendReportData
    '                AttendRptOBS = ETSSQL.GetBlankAttendReportData
    '                AttendRptOBS.NameKey = "99999"
    '                AttendRptOBS.BNum = AttendRptOBS.NameKey & AttendRptOBS.ContractKey
    '                AttendRptOBS.ScreenNam = "Max Obs Offset"
    '                AttendRptOBS.SortName = "Max Obs Offset"
    '                AttendRptOBS.NameChk = "MO"
    '                AttendRptOBS.Offset = 0
    '                AttendRptOBS.SlotNum = 99
    '                AttendRptOBS.SsNum = "  "
    '                AttendRptOBS.MedNum = "  "
    '                AttendRptOBS.InvoiceDate = selected_inv_date
    '                AttendRptOBS.Invoice = id_num
    '                AttendRptOBS.DolTot = (ValueContract.Item(0).ContDol + ValueContract.Item(0).AmendDol - ValueContract.Item(0).SeedDol - ValueContract.Item(0).YtdDol + ValueContract.Item(0).BillOffset - max_obs)
    '                AttendRptOBS.UnitTot = CDec(ValueContract.Item(0).ContUnits + ValueContract.Item(0).AmendUnits - ValueContract.Item(0).YtdUnits - ValueContract.Item(0).SeedUnits - max_units)
    '                AttendRptOBS.AttEnd = saved_end_Date
    '                If AttendRptOBS.AttBeg.Year = 1 Then       'put a date in if no date in
    '                    AttendRptOBS.AttBeg = CDate(start_date)
    '                End If
    '                AttendRptOBS.EntryDate = Today
    '                sqlstmnt = "insert into attend_rpt " & AttendRptOBS.AttendReportColumnNames & "  values " & AttendRptOBS.AttendReportColumnData
    '                ETSSQL.ExecuteSQL(sqlstmnt)
    '            End If
    '        End If
    '        '	'now for the ssi offset
    '        'If ValueContract.Item(0).BillOffset > 0 Then
    '        '    ' new record with blanks in all the d fields
    '        '    Dim AttendRptSSI As New AttendReportData
    '        '    AttendRptSSI = ETSSQL.GetBlankAttendReportData
    '        '    AttendRptSSI.NameKey = "99998"
    '        '    AttendRptSSI.BNum = AttendRptSSI.NameKey & AttendRptSSI.ContractKey
    '        '    AttendRptSSI.ScreenNam = "SSI Offset"
    '        '    AttendRptSSI.SortName = "SSI Offset"
    '        '    AttendRptSSI.NameChk = "SSI"
    '        '    AttendRptSSI.SlotNum = 98
    '        '    AttendRptSSI.SsNum = "  "
    '        '    AttendRptSSI.MedNum = "  "
    '        '    AttendRptSSI.InvoiceDate = selected_inv_date
    '        '    AttendRptSSI.Invoice = id_num
    '        '    AttendRptSSI.Offset = ValueContract.Item(0).BillOffset * -1
    '        '    AttendRptSSI.DolTot = ValueContract.Item(0).BillOffset * -1
    '        '    AttendRptSSI.UnitTot = 0
    '        '    AttendRptSSI.AttEnd = saved_end_Date
    '        '    If AttendRptSSI.AttBeg.Year = 1 Then       'put a date in if no date in
    '        '        AttendRptSSI.AttBeg = CDate(start_date)
    '        '    End If
    '        '    AttendRptSSI.EntryDate = Today
    '        '    sqlstmnt = "insert into attend_rpt " & AttendRptSSI.AttendReportColumnNames & "  values " & AttendRptSSI.AttendReportColumnData
    '        '    ETSSQL.ExecuteSQL(sqlstmnt)
    '        '    '      End If
    '        'End If 'for $$ on contract

    '        '      'now for the flat rate
    '        ' a new line is not added since dol to set to flat rate
    '        'If ValueContract.Item(0).FlatRate > 0 Then
    '        '    ' new record with blanks in all the d fields
    '        '    Dim AttendRptFFee As New AttendReportData
    '        '    AttendRptFFee = ETSSQL.GetBlankAttendReportData
    '        '    AttendRptFFee.NameKey = "99997"
    '        '    AttendRptFFee.BNum = AttendRptFFee.NameKey & AttendRptFFee.ContractKey
    '        '    AttendRptFFee.ScreenNam = "Flat Rate"
    '        '    AttendRptFFee.SortName = "Flat Rate"
    '        '    AttendRptFFee.NameChk = "FR"
    '        '    AttendRptFFee.Offset = ValueContract.Item(0).FlatRate * -1
    '        '    AttendRptFFee.SlotNum = 97
    '        '    AttendRptFFee.SsNum = "  "
    '        '    AttendRptFFee.MedNum = "  "
    '        '    AttendRptFFee.InvoiceDate = selected_inv_date
    '        '    AttendRptFFee.Invoice = id_num
    '        '    AttendRptFFee.DolTot = ValueContract.Item(0).FlatRate - tot_amt
    '        '    AttendRptFFee.UnitTot = 0
    '        '    AttendRptFFee.AttEnd = saved_end_Date
    '        '    If AttendRptFFee.AttBeg.Year = 1 Then       'put a date in if no date in
    '        '        AttendRptFFee.AttBeg = CDate(start_date)
    '        '    End If
    '        '    AttendRptFFee.EntryDate = Today
    '        '    sqlstmnt = "insert into attend_rpt " & AttendRptFFee.AttendReportColumnNames & "  values " & AttendRptFFee.AttendReportColumnData
    '        '    ETSSQL.ExecuteSQL(sqlstmnt)
    '        '    '      End If 'for flat rate
    '        '    '      End If
    '        'End If 'for flat rate

    '        '      'now for the eep contract

    '        If selected_bill_type = "120" And ValueContract.Item(0).Code3 = "EEP" Then
    '            Dim num_people As Double

    '            '              'make the calculation to see if need to create a record
    'tryagain:
    '            Response = CInt(Val(InputBox("Input the number of billable days this month.")))
    '            If Response = 0 Then
    '                MsgBox("There will be no EEP adjustment.")
    '                Exit Sub
    '            End If

    '            If Response > 31 Or Response < 1 Then
    '                MsgBox("Invalid response for days in the month.")
    '                GoTo tryagain
    '            End If

    '            num_people = Val(InputBox("Input the number of slots in the contract."))
    '            If num_people < 1 Then
    '                MsgBox("There will be no EEP adjustment.")
    '                Exit Sub
    '            End If

    '            'billable amount = number of lines of sdr times the days * .85
    '            total_eep = CDec(num_people * Response * 0.85 * cont_rate)
    '            total_eep_units = CInt(num_people * Response * 0.85)
    '            total_eep_units = CInt(Int(num_people * Response * 0.85))
    '            total_eep = total_eep_units * ValueContract.Item(0).UnitRate


    '            '  tmpset.MoveFirst()
    '            ' attend_rpt.MoveLast
    '            ' tot_amt = attend_rpt.Fields("dol_tot")
    '            ' tot_units = attend_rpt.Fields("unit_Tot")

    '            If max_obs > total_eep Then
    '                ' new record with blanks in all the d fields
    '                Dim AttendRptEEP As New AttendReportData
    '                AttendRptEEP = ETSSQL.GetBlankAttendReportData
    '                AttendRptEEP.NameKey = "99996"
    '                AttendRptEEP.BNum = AttendRptEEP.NameKey & AttendRptEEP.ContractKey
    '                AttendRptEEP.ScreenNam = "Percentage Reduction"
    '                AttendRptEEP.SortName = "Percentage Reduction"
    '                AttendRptEEP.NameChk = "PR"
    '                AttendRptEEP.Offset = ValueContract.Item(0).FlatRate * -1
    '                AttendRptEEP.SlotNum = 96
    '                AttendRptEEP.SsNum = "  "
    '                AttendRptEEP.MedNum = "  "
    '                AttendRptEEP.InvoiceDate = selected_inv_date
    '                AttendRptEEP.Invoice = id_num
    '                AttendRptEEP.DolTot = total_eep - max_obs
    '                AttendRptEEP.UnitTot = total_eep_units - max_units
    '                AttendRptEEP.AttEnd = saved_end_Date
    '                If AttendRptEEP.AttBeg.Year = 1 Then       'put a date in if no date in
    '                    AttendRptEEP.AttBeg = CDate(start_date)
    '                End If
    '                AttendRptEEP.EntryDate = Today
    '                sqlstmnt = "insert into attend_rpt " & AttendRptEEP.AttendReportColumnNames & "  values " & AttendRptEEP.AttendReportColumnData
    '                ETSSQL.ExecuteSQL(sqlstmnt)
    '            End If
    '        End If

    '    End Sub

End Module