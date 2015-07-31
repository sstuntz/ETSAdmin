Option Strict On
Option Explicit On
Option Compare Text

Imports System.Data.SqlClient
Imports System.Configuration.ClientSettingsSection
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.IO


Module ar_mod

	Public retlookup_price As Decimal
	Public invoice_detail_grid(100, 6) As Object
	Public hold(16) As Object
	Public Index As Integer
	Public selected_prod_num As String
	Public selected_prod_desc As String
	Public selected_prod_glnum As String
	Public save_invoice_num As String
	Public selected_invoice As String 'added 3/6
	Public void_invoice As String ' added 3/6
	Public workshop_dr_acct_nu As String
	Public workshop_cr_acct_nu As String
	Public workshop_disc_acct As String
	Public saved_entry_num As Integer
	Public bal_Due As Decimal
	Public cred_lmt As Decimal 'wrw prev_read 3/22/03 lhw
	Public saved_batch_num As Integer
	
	Public invoice_dr_acct_nu As String
	Public invoice_cr_acct_nu As String
	Public invoice_disc_acct As String
	Public cust_dr_acct_nu As String
	Public cust_cr_acct_nu As String
	Public cust_disc_acct As String
	Public cust_type As String
	Public user_init As String
	
    Public lea_type As String 'static or temp

    Public TmpCashReceiptHeader As New CashReceiptHeader
    Public DefaultBankKey As String
    Public DefaultMiscNameKey As String


	Public Sub batch_number_Create()
		
		'look for highest nubmer in cash_Tmp1 and add 1
        'if there is nothing in tmp1 then goto cash for the highest and add 1

        selected_bat_num = CInt(ETSSQL.GetOneSQLValue("select top (1) batch_num as TheValue from cash_tmp1 order by batch_num desc")) + 1
        If selected_bat_num = 1 Then
            selected_bat_num = CInt(ETSSQL.GetOneSQLValue("select top (1) batch_num as TheValue from cash order by batch_num desc")) + 1
        Else
            'now to test to see if a later batch has been posted
            Dim temp_num As Integer = CInt(ETSSQL.GetOneSQLValue("select top (1) batch_num as TheValue from cash order by batch_num desc"))
            If temp_num > selected_bat_num - 1 Then
                selected_bat_num = temp_num + 1
            End If
        End If

    End Sub
	Sub chkinv_numverify(ByRef inv_num As Object)
        'Dim tempset As Object
        'Dim tempdb As Object
		'look up to see if inv_num is a duplicate"
		
        'db = ar_data_path & "ar.mdb"
        'tempdb = DAODBEngine_definst.OpenDatabase(db)
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempdb.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset = tempdb.OpenRecordset("invoice", dao.RecordsetTypeEnum.dbOpenDynaset)

        ''UPGRADE_WARNING: Couldn't resolve default property of object inv_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = " inv_num = " & inv_num
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.FindFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset.FindFirst(sqlstmnt)

        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.NoMatch. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If tempset.NoMatch Then
        '	valid_vouch = "Y"
        'Else
        '	valid_vouch = "N"
        'End If
		
	End Sub

	Public Sub check_for_Complete_invoice(ByRef inv_num As Object, ByRef inv_date As Object)
        'Dim selected_paid_date As Object
        'this whole thing done 2/19/01 by l
		'we get total alloc amount from invoce and total cash from payment
		'if they are equal we set paid = "Y" and bal_Due = 0 on all inv records
		'if inv_num = 0 then do it for the invoice file
		'if pmt date not present then put in end date from input screen  7/8/01
		
	  'Dim invoiceset As dao.Recordset
        ''UPGRADE_WARNING: Arrays in structure cashset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim cashset As dao.Recordset
        'tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
        'invoiceset = tmpdb.OpenRecordset("invoice", dao.RecordsetTypeEnum.dbOpenDynaset)
        'cashset = tmpdb.OpenRecordset("cash", dao.RecordsetTypeEnum.dbOpenDynaset)

        'Dim tot_inv As Decimal
        'Dim tot_cash As Decimal


        'Dim saved_inv_num As Object
        'Select Case inv_num
        '	Case 0
        '		'this goes through all of them

        '		sqlstmnt = "select * from invoice order by inv_num "
        '		invoiceset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        '		'UPGRADE_WARNING: Couldn't resolve default property of object saved_inv_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		saved_inv_num = invoiceset.Fields("inv_num").Value
        '		tot_inv = 0
        '		tot_cash = 0

        '		Do While Not invoiceset.EOF
        '			If invoiceset.Fields("inv_num").Value = saved_inv_num Then
        '				tot_inv = tot_inv + invoiceset.Fields("alloc_amt").Value
        '			Else
        '				tot_cash = 0
        '				'UPGRADE_WARNING: Couldn't resolve default property of object saved_inv_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				sqlstmnt = "select * from cash where inv_num = " & saved_inv_num
        '				cashset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        '				Do While Not cashset.EOF
        '					tot_cash = tot_cash + cashset.Fields("chk_alloc").Value
        '					cashset.MoveNext()
        '				Loop 

        '				If tot_inv = tot_cash Then
        '					'UPGRADE_WARNING: Couldn't resolve default property of object saved_inv_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					sqlstmnt = "select * from invoice where inv_num = " & saved_inv_num
        '					tmpset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        '					Do While Not tmpset.EOF
        '						tmpset.Edit()
        '						tmpset.Fields("bal_Due").Value = 0
        '						tmpset.Fields("paid").Value = "Y"
        '						If Len(Trim(tmpset.Fields("paid_date").Value & "")) = 0 Then
        '							tmpset.Fields("paid_date").Value = selected_end_date 'added 7/8/01
        '						End If
        '						tmpset.Update()
        '						tmpset.MoveNext()
        '					Loop 
        '				End If
        '				'UPGRADE_WARNING: Couldn't resolve default property of object saved_inv_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				saved_inv_num = invoiceset.Fields("inv_num").Value

        '				tot_inv = invoiceset.Fields("alloc_amt").Value
        '				tot_cash = 0
        '			End If

        '			invoiceset.MoveNext()
        '		Loop 

        '	Case Else
        '		'UPGRADE_WARNING: Couldn't resolve default property of object inv_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		sqlstmnt = "select * from invoice where inv_num = " & inv_num
        '		invoiceset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        '		'UPGRADE_WARNING: Couldn't resolve default property of object inv_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		sqlstmnt = "select * from cash where inv_num = " & inv_num
        '		cashset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        '		tot_inv = 0
        '		tot_cash = 0

        '		Do While Not invoiceset.EOF
        '			tot_inv = tot_inv + invoiceset.Fields("alloc_amt").Value
        '			invoiceset.MoveNext()
        '		Loop 

        '		Do While Not cashset.EOF
        '			tot_cash = tot_cash + cashset.Fields("chk_alloc").Value
        '			cashset.MoveNext()
        '		Loop 

        '		If tot_inv = tot_cash Then
        '			invoiceset.MoveFirst()
        '			Do While Not invoiceset.EOF
        '				invoiceset.Edit()
        '				invoiceset.Fields("bal_Due").Value = 0
        '				invoiceset.Fields("paid").Value = "Y"
        '				If Len(Trim(invoiceset.Fields("paid_date").Value & "")) = 0 Then
        '					'UPGRADE_WARNING: Couldn't resolve default property of object selected_paid_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					invoiceset.Fields("paid_date").Value = selected_paid_date 'added 7/8/01
        '				End If

        '				invoiceset.Update()
        '				invoiceset.MoveNext()
        '			Loop 
        '		End If


        'End Select

		
		
		
	End Sub
	Public Sub chk_rec1(ByRef invoice As Object, ByRef valid_yn As Object)
        '		Dim tempset As Object
        '		Dim tempdb As Object
		
        'db = ar_data_path & "ar.mdb"
        'tempdb = DAODBEngine_definst.OpenDatabase(db)
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempdb.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset = tempdb.OpenRecordset("rec1_lea", dao.RecordsetTypeEnum.dbOpenDynaset)

        ''UPGRADE_WARNING: Couldn't resolve default property of object invoice. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = " inv_num = " & invoice
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.FindFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset.FindFirst(sqlstmnt)

        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.NoMatch. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If tempset.NoMatch Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object valid_yn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	valid_yn = "Y"
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object valid_yn. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	valid_yn = "N"
        'End If
		
	End Sub
	Sub chkwork_numverify(ByRef inv_number As Object)
        '		Dim tempset As Object
        '		Dim tempdb As Object
		'look up to see if inv_num is a duplicate"
		
        'db = ar_data_path & "ar.mdb"
        'tempdb = DAODBEngine_definst.OpenDatabase(db)
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempdb.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset = tempdb.OpenRecordset("workshop", dao.RecordsetTypeEnum.dbOpenDynaset)

        ''UPGRADE_WARNING: Couldn't resolve default property of object inv_number. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = " inv_num = " & inv_number
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.FindFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset.FindFirst(sqlstmnt)

        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.NoMatch. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If tempset.NoMatch Then
        '	valid_vouch = "Y"
        'Else
        '	valid_vouch = "N"
        'End If
		
	End Sub
	
	Sub chkprod_num(ByRef Prod_num As Object)
        '		Dim tempset As Object
        '		Dim tempdb As Object
		'look up to see if prod_num is a duplicate"
		
        'db = ar_data_path & "ar.mdb"
        'tempdb = DAODBEngine_definst.OpenDatabase(db)
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempdb.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset = tempdb.OpenRecordset("product", dao.RecordsetTypeEnum.dbOpenDynaset)

        ''prod num is a text field
        ''UPGRADE_WARNING: Couldn't resolve default property of object Prod_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = " prod_num = " & Chr(34) & Prod_num & Chr(34)
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.FindFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset.FindFirst(sqlstmnt)

        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.NoMatch. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If tempset.NoMatch Then
        '	valid_yn = "N"

        'Else
        '	valid_yn = "Y"
        'End If
		
	End Sub
	Sub chkinvline_num(ByRef inv_num As Object, ByRef line_num As Object)
        'Dim tempset As Object
        'Dim tempdb As Object
		'look up to see if inv_num/line_num combination is a duplicate"
		
        'db = ar_data_path & "ar.mdb"
        'tempdb = DAODBEngine_definst.OpenDatabase(db)
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempdb.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset = tempdb.OpenRecordset("invoice", dao.RecordsetTypeEnum.dbOpenDynaset)

        ''UPGRADE_WARNING: Couldn't resolve default property of object line_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object inv_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = " inv_num = " & inv_num & " and line_num = " & line_num
        'On Error Resume Next

        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.FindFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset.FindFirst(sqlstmnt)
        'If Err.Number <> 0 Then

        'End If
        ''lhw99
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.NoMatch. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If tempset.NoMatch Then
        '	valid_yn = "Y" 'no message
        'Else
        '	valid_yn = "N" 'message
        'End If
		
	End Sub
	
	Sub etsprod_num_chk(ByRef senddpt As Object, ByRef retdpt As Object, ByRef retdptdesc As Object, ByRef retdptglnum As Object, ByRef valid_dpt As Object)
        'Dim tempset As Object
        'Dim tempdb As Object
        'Dim productlookup As Object
		'although code is for dept, here it refers to product
		'UPGRADE_WARNING: Couldn't resolve default property of object senddpt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If senddpt = "" Then
        'UPGRADE_WARNING: Couldn't resolve default property of object productlookup.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			productlookup.Show(1)


        'UPGRADE_WARNING: Couldn't resolve default property of object senddpt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        senddpt = selected_prod_num
        'UPGRADE_WARNING: Couldn't resolve default property of object retdpt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        retdpt = selected_prod_num
        'UPGRADE_WARNING: Couldn't resolve default property of object retdptdesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        retdptdesc = selected_prod_desc
        'UPGRADE_WARNING: Couldn't resolve default property of object retdptglnum. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        retdptglnum = selected_prod_glnum
        'UPGRADE_WARNING: Couldn't resolve default property of object valid_dpt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        valid_dpt = "Y"

        '	End If

        'db = ar_data_path & "ar.mdb"
        'tempdb = DAODBEngine_definst.OpenDatabase(db)
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempdb.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset = tempdb.OpenRecordset("product", dao.RecordsetTypeEnum.dbOpenDynaset)

        ''UPGRADE_WARNING: Couldn't resolve default property of object senddpt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = " prod_num = " & Chr(34) & senddpt & Chr(34)

        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.FindFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset.FindFirst(sqlstmnt)

        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.NoMatch. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If tempset.NoMatch Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object valid_dpt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	valid_dpt = "N"
        'Else
        '	'UPGRADE_WARNING: Couldn't resolve default property of object valid_dpt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	valid_dpt = "Y"
        '	'UPGRADE_WARNING: Couldn't resolve default property of object tempset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object retdpt. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	retdpt = tempset.Fields("prod_num")
        '	'UPGRADE_WARNING: Couldn't resolve default property of object tempset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object retdptdesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	retdptdesc = tempset.Fields("prod_desc")
        '	'UPGRADE_WARNING: Couldn't resolve default property of object tempset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	retlookup_price = tempset.Fields("unit_price")
        '	'UPGRADE_WARNING: Couldn't resolve default property of object tempset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	selected_prod_glnum = tempset.Fields("cr_acct_nu") & "" 'Sales TX only
        'End If
		
	End Sub
	
	Sub fillwkbill()
        '		Dim ent_Date As Object
        '		Dim other_out As Object
        '		Dim our_Truck As Object
        '		Dim ups_Cost As Object
        '		Dim reference As Object
        '		Dim terms As Object
        '		Dim ship_via As Object
        '		Dim ship_date As Object
        '		Dim inv_date As Object
        '		Dim purch_num As Object
        '		Dim screen_nam As Object
        '		Dim name_key As Object
        '		Dim inv_num As Object
        '		Dim tempset As Object
        '		Dim tempdb As Object
		
        'db = ar_data_path & "ar.mdb"
        'tempdb = DAODBEngine_definst.OpenDatabase(db)

        ''UPGRADE_WARNING: Couldn't resolve default property of object tempdb.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset = tempdb.OpenRecordset("workshop", dao.RecordsetTypeEnum.dbOpenDynaset)
        'sqlstmnt = "select * from workshop where inv_num = "
        'sqlstmnt = sqlstmnt & selected_voucher

        'sqlstmnt = sqlstmnt & " order by line_num"
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempdb.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset = tempdb.OpenRecordset(sqlstmnt)
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset.MoveFirst()

        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not tempset.EOF

        '	'UPGRADE_WARNING: Couldn't resolve default property of object tempset(line_num). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	If tempset("line_num") = 1 Then
        '		'put in header
        '		'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object inv_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		inv_num = tempset("inv_num")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		name_key = tempset("name_key")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object screen_nam. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		screen_nam = tempset("screen_nam")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object purch_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		purch_num = tempset("purch_num")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object inv_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		inv_date = tempset("inv_date")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object ship_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		ship_date = tempset("ship_date")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object ship_via. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		ship_via = tempset("ship_via")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object terms. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		terms = tempset("terms")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object reference. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		reference = tempset("reference")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object ups_Cost. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		ups_Cost = tempset("ups_Cost")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object our_Truck. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		our_Truck = tempset("our_Truck")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object other_out. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		other_out = tempset("other_out")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object ent_Date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		ent_Date = tempset("batch_date")
        '		'entry_date = tempset("entry_date")
        '		'    vouch_Amt = tempset("vouch_amt")
        '	End If

        '	'put in array
        '	'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(i, 0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	invoice_detail_grid(i, 0) = tempset("line_num")
        '	'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(i, 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	invoice_detail_grid(i, 1) = tempset("prod_num")
        '	'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(i, 2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	invoice_detail_grid(i, 2) = tempset("prod_desc")
        '	'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(i, 3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	invoice_detail_grid(i, 3) = tempset("cr_pref_Ac")
        '	'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(i, 4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	invoice_detail_grid(i, 4) = tempset("quantity")
        '	'UPGRADE_WARNING: Couldn't resolve default property of object tempset(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	'UPGRADE_WARNING: Couldn't resolve default property of object invoice_detail_grid(i, 4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	invoice_detail_grid(i, 4) = tempset("unit_price")
        '	i = i + 1

        '	'UPGRADE_WARNING: Couldn't resolve default property of object tempset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	tempset.MoveNext()

        'Loop 
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'max_grid_line = tempset.RecordCount
		
	End Sub
	Sub clearwkbill()
        '		Dim tempset As Object
        '		Dim tempdb As Object
		' this voids and unposted workshop bill
		
        'db = ar_data_path & "ar.mdb"
        'tempdb = DAODBEngine_definst.OpenDatabase(db)

        ''UPGRADE_WARNING: Couldn't resolve default property of object tempdb.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset = tempdb.OpenRecordset("workshop", dao.RecordsetTypeEnum.dbOpenDynaset)
        'sqlstmnt = "select * from workshop where inv_num = "
        'sqlstmnt = sqlstmnt & selected_voucher

        'sqlstmnt = sqlstmnt & " order by inv_line"
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempdb.OpenRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset = tempdb.OpenRecordset(sqlstmnt)
        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'tempset.MoveFirst()

        ''UPGRADE_WARNING: Couldn't resolve default property of object tempset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not tempset.EOF
        '	'UPGRADE_WARNING: Couldn't resolve default property of object tempset.delete. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	tempset.delete()
        '	'UPGRADE_WARNING: Couldn't resolve default property of object tempset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	tempset.MoveNext()
        'Loop 
		
	End Sub
    Public Function cust_nameget(ByVal cust_num As String) As String

        If (cust_num) = "" Then
            frmnamechk.ShowDialog()
            cust_num = selected_name_key
        End If

        Dim intcount As Integer = 0
        Using db As Database = New Database(top_data_path)
            Dim sql As String = "select * from nam_cust where name_key = '" & cust_num & "'"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            While rs.Read()
                cust_name_key = rs("name_key").ToString
                cust_screen_nam = rs("screen_nam").ToString
                cust_sort_name = rs("sort_name").ToString
                cust_dr_acct_nu = rs("dr_pref_ac").ToString
                cust_cr_acct_nu = rs("cr_pref_ac").ToString
                cust_disc_acct = rs("disc_acct").ToString
                cust_type = rs("cust_type").ToString
                cred_lmt = CDec(rs("cred_lmt"))

                workshop_dr_acct_nu = rs("dr_pref_ac").ToString
                workshop_cr_acct_nu = rs("cr_pref_ac").ToString
                workshop_disc_acct = rs("disc_acct").ToString

                invoice_dr_acct_nu = rs("dr_pref_ac").ToString
                invoice_cr_acct_nu = rs("cr_pref_ac").ToString
                invoice_disc_acct = rs("disc_acct").ToString
                intcount = intcount + 1
            End While
            rs.Close()
        End Using

        If intcount = 0 Then
            valid_dpt = "N"
        Else
            valid_dpt = "Y"
        End If

        Return valid_dpt

    End Function

  
End Module