Option Strict Off
Option Explicit On
Imports ETS.Common.Module1
Imports PS.Common

Module Med_mod
	
	
	Public med_flag As String
	Public del_flag As String
	Public mult_mth_flag As String
	Public full_flag As String
	Public proc_flag As String
	Public Del_Day_Flag As String
	Public strTableName As String 'added 6/2/03 TMK for clarifying error messages
	Public del_type As String
	Public med_type As String
    Public function_typeA As String 'added 7/27/02 for adjust and rebills
	
	
	Public uni_counter As Integer
	Public num_prov As Integer
	Public file_array As String
	Public chosen_med_array As Integer 'this is the number in the med array that is being worked on
	
	Public selected_proc_code As String
	Public selected_proc_code_m As String 'added 5/30/03 for procedure code modifiers - TMK
	Public selected_proc_desc As String
	Public selected_proc_fee As Decimal
	Public selected_proc_max As Decimal
	Public selected_place_serv As String
	Public selected_prov_name As String
	Public selected_proc_dol_actual As Decimal
	Public selected_lookup_prior As String
	Public selected_tcn_num As String
	Public selected_ftcnl_num As String
	
	Public selected_mbproc_code As String
	Public selected_mbproc_desc As String
	Public selected_mbdol_fee As Decimal
	Public selected_mbdol_actual As Decimal
	Public selected_print_name As String
	Public selected_mb_num As String
	Public selected_mb_prov_num As String
	Public selected_mb_proc_num As String
	Public selected_clin_key As String
	Public selected_diag_code As String 'added 1/27/05 for pca_import
	Public selected_refp_num As String
	Public selected_refp_name As String
	Public selected_dob As Date
	
	
	Public selected_paper As String
	
	Public selected_proc_num As String
	Public selected_prov_num As String
	
	Public selected_from_date As Date
	Public selected_to_Date As Date
	Public selected_bill_Date As Date
	
    'Public Med_Top_Db As dao.Database
	'UPGRADE_WARNING: Arrays in structure med_batch_ctrl may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Public med_batch_ctrl As dao.Recordset
	Public proc(100, 1) As String
	
	'UPGRADE_WARNING: Arrays in structure medopn may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    '	Public medopn As dao.Recordset
	'UPGRADE_WARNING: Arrays in structure medopn_tmp may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    '	Public medopn_tmp As dao.Recordset
	'UPGRADE_WARNING: Arrays in structure medopn_hist may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    '	Public medopn_hist As dao.Recordset
    '	Public medmdb As dao.Database
    '	Public meddb As dao.Database
	'UPGRADE_WARNING: Arrays in structure medset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    '	Public medset As dao.Recordset
	'UPGRADE_WARNING: Arrays in structure med1set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    '	Public med1set As dao.Recordset
	'UPGRADE_WARNING: Arrays in structure medfee may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    '	Public medfee As dao.Recordset
	'UPGRADE_WARNING: Arrays in structure medcc may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    '	Public medcc As dao.Recordset
	'UPGRADE_WARNING: Arrays in structure medsub may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    '	Public medsub As dao.Recordset
	
	'UPGRADE_WARNING: Arrays in structure mbhp may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    '	Public mbhp As dao.Recordset
	'UPGRADE_WARNING: Arrays in structure mbhp_tmp may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    '	Public mbhp_tmp As dao.Recordset
	'UPGRADE_WARNING: Arrays in structure mbhp_hist may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    '	Public mbhp_hist As dao.Recordset
    'Public mbhp_Top_Db As dao.Database
	'UPGRADE_WARNING: Arrays in structure mbhp_batch_ctrl may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    'Public mbhp_batch_ctrl As dao.Recordset
	Public autho_type As String
	
	Public med_array(10, 200) As String
	
	Public temp_proc_num As String
	Public temp_prov_num As String
	Public temp_name_key As String
	Public temp_place_serv As String
	Public temp_prior_auth As String
	Public temp_clin_name_key As String
	Public temp_fiscal_year As Integer
	Public test_fiscal_year As Integer
	Public temp_refp_num As String 'added 1/28/04 TMK
	Public temp_tcn_num As String 'added tmk 3/12/04  lhw 8/11/04
	Public paper_pos As String 'added 4/7/04 TMK
	
	Dim bat_num As Integer
	Dim b_counter As Integer
	Dim k_counter As Integer
	Dim tot_med As Decimal
	
	Private Const spaces As String = "                                " ' for  filling name etc
	Private Const zeroes As String = "00000000000000000000000000000000" ' for  filling name etc
	Private Const outputfilename As String = "c:\medicaid.dat"
	Private Const outputfilename_a As String = "a:\MMMEDSV.DAT"
	
	Public outputfilename_b As String
	Public outputfilename_mbhp As String
	Sub chk_medcc(ByRef namekey As Object)
		'9/2/05 added two fields lhw for pca import
		'not called in reg pca
        'db = att_data_path & "med.mdb"
        'tmpdb = DAODBEngine_definst.OpenDatabase(db)
        'tmpset = tmpdb.OpenRecordset("medcc", dao.RecordsetTypeEnum.dbOpenDynaset)

        'sqlstmnt = " name_key = "
        ''UPGRADE_WARNING: Couldn't resolve default property of object namekey. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = sqlstmnt & Chr(34) & namekey & Chr(34)

        'tmpset.FindFirst(sqlstmnt)

        'If tmpset.NoMatch Then
        '	valid_name = "N"
        'Else
        '	valid_name = "Y"
        '	selected_refp_num = tmpset.Fields("refp_num").Value & ""
        '	selected_refp_name = tmpset.Fields("refp_nam").Value
        '	selected_dob = tmpset.Fields("dob").Value
        'End If
	End Sub
	
	Public Sub cca_write_new(ByRef temp_proc_num As Object, Optional ByRef Index As Object = Nothing)
		'11/05/04 copied from cca_write VB4 lhw
		' ************  med_write changed for HIPAA 4/8 - tmk **************
		
		' Screen.MousePointer = vbHourglass
		
		'MsgBox "File set to T est fix when ok in.. ISA REcord!" removed 5/31/05 lhw
		
        '	meddb = DAODBEngine_definst.OpenDatabase(am1_Data_path & "med_top.mdb")
        'UPGRADE_WARNING: Couldn() 't resolve default property of object temp_proc_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '       sqlstmnt = "Select * from medopn_bill where proc_num = " & Chr(34) & temp_proc_num & Chr(34) & " order by batch_num_line"

        '		medset = meddb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        '		outputfilename_b = am1_Data_path & "submissions\"
        '	outputfilename_b = outputfilename_b & "med" & medset.Fields("batch_num").Value & ".asc"
        '		fnum = FreeFile
        '		FileOpen(fnum, outputfilename_b, OpenMode.Output, , , 1)
		
		
        '	Dim tmpProcName As String 'This is for HIPAA to compare proc. name to prov. name
        '		Dim tmpConName As String 'This is to eliminate duplicate 'J' records
        '		Dim HLID As Short 'Counter for hierarchical levels
        '		Dim parentHLID As Short 'Indicates which provider the consumers are referencing
        '		Dim serviceCount As Short 'Counter for the service/procedure loop
        '		Dim segmentCount As Integer 'Counter for the number of segments or '~'s
        '		Dim controlID As String 'Holds the batch number for the header/trailer tags
        '		Dim ProcString As String 'Holds the processor information in case of multiple providers
        '		Dim ProcAddress As String 'This is used for the consumer address if there is none
        '		Dim ClaimString As String 'Used if there're more than 50 service lines - 11/17/03
        '		Dim claimSegCount As Short 'Number of segments in the claim line - 11/17/03
		
        'Dim mednumdb As dao.Database
        ''UPGRADE_WARNING: Arrays in structure mednum may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim mednum As dao.Recordset
        'db = am1_Data_path & "med_prov.mdb"
        'Dim tmpwk As dao.Workspace
        'tmpwk = DAODBEngine_definst.Workspaces(0)
        'mednumdb = tmpwk.OpenDatabase(db, False, False, "MS Access;PWD=ETS1")
        'mednum = mednumdb.OpenRecordset("med_nums", dao.RecordsetTypeEnum.dbOpenDynaset)

        'namaddrdb = DAODBEngine_definst.OpenDatabase(am1_Data_path & "glname.mdb")
        'namaddrset = namaddrdb.OpenRecordset("nam_addr", dao.RecordsetTypeEnum.dbOpenDynaset)


        ''need to fetch submitter tax id#
        ''use contract_key in first record as link
        'db = att_data_path & "aratt.mdb"
        'Dim prov_tax_id As String

        'dptdb = DAODBEngine_definst.OpenDatabase(db)
        'dptset = dptdb.OpenRecordset("cc_Cont", dao.RecordsetTypeEnum.dbOpenDynaset)

        'prov_tax_id = ""
        'Do While Not dptset.EOF
        '	If Trim(dptset.Fields("contract_key").Value) = Trim(medset.Fields("contract_key").Value) Then
        '		'If Left(dptset.Fields("contract_key"), 6) = "MAMBHP" Then
        '		'prov_tax_id = dptset.Fields("pnum_Sdr")
        '		prov_tax_id = dptset.Fields("fedid_num").Value
        '		Exit Do
        '	End If
        '	dptset.MoveNext()
        'Loop 

        'If Len(prov_tax_id) = 0 Then
        '	prov_tax_id = "999999999"
        'End If
		
		
		' ------------------ HIPAA ---------------------- 4/8 tmk
		'UPGRADE_WARNING: Couldn't resolve default property of object temp_proc_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	controlID = Left(medset.Fields("batch_num").Value & temp_proc_num & zeroes, 9) 'using temp_proc_num instead of medset.Fields("med_num") - TMK 11/5/03
        '	Print(fnum, "ISA")
        '	Print(fnum, "*00*          *00*          *30*")
        '	Print(fnum, Left(prov_tax_id & spaces, 15) & "*") 'Now Submitter Tax ID
        '	' Print #fnum, Left(temp_proc_num & spaces, 15) & "*"; ' changed from Left(mednum.Fields("med_num") & spaces, 15) & "*"; on 7/1/03 TMK
        '	Print(fnum, "01*143153927      *")
        '	Print(fnum, VB6.Format(Now, "yymmdd") & "*")
        '	Print(fnum, VB6.Format(Now, "hhmm") & "*")
        '	'Print #fnum, "U*00401*" & controlID & "*1*T*:~"; '5/31/05 out
        '	Print(fnum, "U*00401*" & controlID & "*1*P*:~")
        '	Print(fnum, "GS")
        '	Print(fnum, "*HC*")
        '	Print(fnum, Left(prov_tax_id & spaces, 15) & "*") 'Now Submitter Tax ID
        '	' Print #fnum, temp_proc_num & "*"; 'changed from mednum.Fields("med_num") & "*"; on 7/1/03 TMK
        '	Print(fnum, "143153927      *")
        '	Print(fnum, VB6.Format(Now, "yyyymmdd") & "*")
        '	Print(fnum, VB6.Format(Now, "hhmm") & "*" & Left(controlID, 3) & "*X*004010X098A1~")

        '	segmentCount = 0

        '	Print(fnum, "ST*837*0001~")
        '	Print(fnum, "BHT*0019*00*")
        '	Print(fnum, Left(controlID, 3) & "*")
        '	Print(fnum, VB6.Format(Now, "yyyymmdd") & "*")
        '	Print(fnum, VB6.Format(Now, "hhmm") & "*CH~")
        '	Print(fnum, "REF*87*004010X098A1~")

        '	segmentCount = segmentCount + 4 'count the SE segment here

        '	HLID = 1
        '	tmpConName = ""
        '	ProcString = ""
        '	ProcAddress = ""
        '	serviceCount = 1
        '	' -----------------------------------------------

        '	Dim cc_base_ss As String
        '	Dim cc_base_diag As String
        '	Do While Not medset.EOF

        '		Select Case medset.Fields("record_id").Value

        '			Case "G"
        '				sqlstmnt = " med_num = " & Chr(34) & medset.Fields("proc_num").Value & Chr(34)
        '				mednum.FindFirst(sqlstmnt)

        '				If mednum.NoMatch Then
        '					MsgBox("Bad processor number.")
        '					FileClose(fnum)
        '					Exit Sub
        '				End If

        '				sqlstmnt = " name_key = " & Chr(34) & mednum.Fields("name_key").Value & Chr(34)
        '				namaddrset.FindFirst(sqlstmnt)

        '				If namaddrset.NoMatch Then
        '					MsgBox("Bad processor number in glname.")
        '					FileClose(fnum)
        '					Exit Sub
        '				End If

        '				'submitter  Stavros
        '				' ------------------ HIPAA ---------------------- 4/8 tmk
        '				Print(fnum, "NM1")
        '				Print(fnum, "*41*2*" & namaddrset.Fields("screen_nam").Value & "*****46*")
        '				Print(fnum, prov_tax_id & "~")
        '				'Print #fnum, mednum.Fields("med_num") & "~";
        '				Print(fnum, "PER*IC*" & namaddrset.Fields("email").Value & "*TE*")
        '				msg = ""
        '				msg = Mid(namaddrset.Fields("telephone").Value, 2, 3) & Mid(namaddrset.Fields("telephone").Value, 7, 3) & Mid(namaddrset.Fields("telephone").Value, 11, 4)
        '				Print(fnum, msg & "~")
        '				'receiver CCA
        '				Print(fnum, "NM1*40*2*COMMONWEALTH CARE ALLIANCE*****46*DMA7384~")
        '				'Print #fnum, "NM1*40*2*MA MEDICAID*****46*DMA7384~";

        '				ProcString = ProcString & "NM1"
        '				ProcString = ProcString & "*85*2*" & namaddrset.Fields("screen_nam").Value & "*****34*" & prov_tax_id & "~"
        '				' ProcString = ProcString & "*85*2*" & namaddrset.Fields("screen_nam") & "*****24*" & mednum.Fields("med_num") & "~"

        '				ProcString = ProcString & "N3*" & namaddrset.Fields("address1").Value & "~"
        '				ProcAddress = ProcAddress & "N3*" & namaddrset.Fields("address1").Value & "~"
        '				ProcString = ProcString & "N4*" & namaddrset.Fields("city").Value & "*" & namaddrset.Fields("state").Value
        '				ProcAddress = ProcAddress & "N4*" & namaddrset.Fields("city").Value & "*" & namaddrset.Fields("state").Value
        '				ProcString = ProcString & "*" & Left(Trim(namaddrset.Fields("zip4").Value) & zeroes, 5) & "~"
        '				ProcAddress = ProcAddress & "*" & Left(zeroes & Trim(namaddrset.Fields("zip4").Value) & zeroes, 5) & "~"

        '				'not used       ProcString = ProcString & "REF*1D*" & prov_tax_id & "~"

        '				segmentCount = segmentCount + 3
        '				tmpProcName = ""
        '				tmpProcName = namaddrset.Fields("screen_nam").Value
        '				' -----------------------------------------------

        '			Case "H"
        '				sqlstmnt = " med_num = " & Chr(34) & medset.Fields("prov_num").Value & Chr(34)
        '				mednum.FindFirst(sqlstmnt)

        '				If mednum.NoMatch Then
        '					MsgBox("Bad provider number = " & medset.Fields("prov_num").Value)
        '					FileClose(fnum)
        '					Exit Sub
        '				End If

        '				sqlstmnt = " name_key = " & Chr(34) & mednum.Fields("name_key").Value & Chr(34)
        '				namaddrset.FindFirst(sqlstmnt)

        '				If namaddrset.NoMatch Then
        '					MsgBox("Bad processor number in glname.")
        '					FileClose(fnum)
        '					Exit Sub
        '				End If

        '				' ------------------ HIPAA ---------------------- 4/8 tmk
        '				'billing/pay-to
        '				'Check THE SEGMENT COUNT!!

        '				Print(fnum, "HL*" & HLID & "**20*1~")
        '				parentHLID = HLID
        '				'always output BOTH Billing and provider name and address
        '				'     If (namaddrset.Fields("screen_nam") = tmpProcName) Then
        '				'            'Print #fnum, "PRV*BI*ZZ*" & prov_tax_id & "~";
        '				'            'Print #fnum, "PRV*BI*ZZ*" & mednum.Fields("med_num") & "~";
        '				'        Print #fnum, ProcString;
        '				'          segmentCount = segmentCount + 6
        '				'          Else
        '				ProcAddress = ""
        '				'           Print #fnum, "PRV*PT*ZZ*" & prov_tax_id & "~";
        '				'billing provider 85
        '				Print(fnum, ProcString) '3 lines

        '				'pay-to-provider
        '				Print(fnum, "NM1")
        '				Print(fnum, "*87*2*" & namaddrset.Fields("screen_nam").Value & "*****24*" & prov_tax_id & "~")

        '				Print(fnum, "N3*" & namaddrset.Fields("address1").Value & "~")
        '				ProcAddress = ProcAddress & "N3*" & namaddrset.Fields("address1").Value & "~"
        '				Print(fnum, "N4*" & namaddrset.Fields("city").Value & "*" & namaddrset.Fields("state").Value)
        '				ProcAddress = ProcAddress & "N4*" & namaddrset.Fields("city").Value & "*" & namaddrset.Fields("state").Value
        '				Print(fnum, "*" & Left(Trim(namaddrset.Fields("zip4").Value) & zeroes, 5) & "~") 'changed from Right() to Left() TMK
        '				ProcAddress = ProcAddress & "*" & Left(Trim(namaddrset.Fields("zip4").Value) & zeroes, 5) & "~"

        '				'Print #fnum, "REF*1D*" & prov_tax_id & "~";
        '				'Print #fnum, "REF*1D*" & mednum.Fields("med_num") & "~";

        '				segmentCount = segmentCount + 6 '10
        '				'     End If
        '				HLID = HLID + 1
        '				' -----------------------------------------------

        '			Case "J"
        '				'   to get the right folder

        '				For num = 0 To 200
        '					If Trim(medset.Fields("prov_num").Value) = Trim(med_array(2, num)) Then Exit For
        '				Next 

        '				tmpdb = DAODBEngine_definst.OpenDatabase(Left(am1_Data_path, Len(am1_Data_path) - 7) & med_array(4, num) & "glname.mdb")

        '				tmpset = tmpdb.OpenRecordset("nam_addr", dao.RecordsetTypeEnum.dbOpenDynaset)
        '				sqlstmnt = " name_key = " & Chr(34) & medset.Fields("name_key").Value & Chr(34)
        '				tmpset.FindFirst(sqlstmnt)
        '				If tmpset.NoMatch Then
        '					MsgBox("Databases out of kilter.  Call ETS.")
        '					Exit Sub

        '				End If

        '				' ------------------ HIPAA ---------------------- 4/8 tmk
        '				'skip over duplicate J's - 4/10 tmk     (taken out 1/27/04 TMK)

        '				If Not (tmpset.Fields("name_key").Value = tmpConName) Then 'back in lhw
        '					'subscriber
        '					'fetch soc_sec# from cc_base
        '					db = att_data_path & "aratt.mdb"
        '					dptdb = DAODBEngine_definst.OpenDatabase(db)
        '					dptset = dptdb.OpenRecordset("cc_base", dao.RecordsetTypeEnum.dbOpenDynaset)

        '					cc_base_ss = ""
        '					Do While Not dptset.EOF
        '						If Trim(dptset.Fields("name_key").Value) = Trim(medset.Fields("name_key").Value) Then
        '							'cc_base_ss = dptset.Fields("ss_num")
        '							'added 10/15/04 lhw no dashes
        '							cc_base_ss = Left(dptset.Fields("ss_num").Value, 3) & "" & Mid(dptset.Fields("ss_num").Value, 5, 2) & "" & Mid(dptset.Fields("ss_num").Value, 8, 4)


        '							'cc_base_diag =
        '							Exit Do
        '						End If
        '						dptset.MoveNext()
        '					Loop 


        '					Print(fnum, "HL*" & HLID & "*" & parentHLID & "*22*0~")
        '					Print(fnum, "SBR*P*18******MC~")

        '					Print(fnum, "NM1")
        '					Print(fnum, "*IL*1*" & tmpset.Fields("last_name").Value & "*" & tmpset.Fields("first_name").Value & "*")
        '					If (tmpset.Fields("middle_ini").Value >= "A") And (tmpset.Fields("middle_ini").Value <= "Z") Then Print(fnum, tmpset.Fields("middle_ini").Value)
        '					'Print #fnum, "***MI*" & Trim(medset.Fields("name_key")) & "~";
        '					'changed 10/15/04
        '					Print(fnum, "***MI*" & Trim(cc_base_ss) & "~")
        '					'3
        '					'insert payer name
        '					Print(fnum, "NM1*PR*2*COMMONWEALTH CARE ALLIANCE*****PI*DMA7384~")
        '					segmentCount = segmentCount + 1


        '					'Claim information - patient account number is recommended for CLM01



        '					Print(fnum, "CLM*" & cc_base_ss & "*" & medset.Fields("usual_Fee").Value & "***")
        '					'Print #fnum, "CLM*" & medset.Fields("pacct_num") & "*" & medset.Fields("usual_Fee") & "***";
        '					Print(fnum, medset.Fields("place_serv").Value & "::")

        '					ClaimString = "CLM*" & cc_base_ss & "*" & medset.Fields("usual_Fee").Value & "***" 'added 11/17/03
        '					ClaimString = ClaimString & medset.Fields("place_serv").Value & "::" 'added 11/17/03


        '					'INSERT CORRECTED FREQUENCY CODE    3/9/04 TMK
        '					Select Case medset.Fields("rebilled").Value
        '						Case "V" 'voids
        '							Print(fnum, "8")
        '						Case "A" 'replacements
        '							Print(fnum, "7")
        '						Case Else 'originals
        '							Print(fnum, "1")
        '					End Select


        '					Print(fnum, "*Y*A*Y*Y*Y~")

        '					'Print #fnum, "*Y*C*Y*Y*C~";
        '					'ClaimString = ClaimString & "*Y*C*Y*Y*C~"   'added 11/17/03

        '					' prior autho

        '					If (Len(Trim(medset.Fields("prior_auth").Value)) <> 0) Then
        '						Print(fnum, "REF*G1*" & medset.Fields("prior_auth").Value & "~")
        '						ClaimString = ClaimString & "REF*G1*" & medset.Fields("prior_auth").Value & "~"
        '						claimSegCount = claimSegCount + 1
        '						segmentCount = segmentCount + 1
        '					End If


        '					'diag code  'Print #fnum, "HI*BK*medcc_diag*********************~";

        '					'diag code  leave period in file 10/15/04

        '					'       Response = InStr(medset.Fields("prim_Diag") & "", ".")
        '					'       If Response = 0 Then
        '					msg = medset.Fields("prim_Diag").Value & ""
        '					'           Else
        '					'               msg = Left(medset.Fields("prim_Diag"), 3) & Mid(medset.Fields("prim_Diag"), Response + 1)
        '					'       End If

        '					If (Trim(msg) <> "" And Trim(msg) <> "00000") Then
        '						Print(fnum, "HI*BK:" & Trim(msg)) 'changed from Left to Trim 7/18/03 TMK
        '						ClaimString = ClaimString & "HI*BK:" & Trim(msg)

        '						'           Response = InStr(medset.Fields("secnd_Diag") & "", ".")
        '						'           If Response = 0 Then
        '						msg = medset.Fields("secnd_Diag").Value & ""
        '						'           Else
        '						'               msg = Left(medset.Fields("secnd_Diag"), 3) & Mid(medset.Fields("secnd_Diag"), Response + 1)
        '						'           End If

        '						If (Trim(msg) <> "" And Trim(msg) <> "00000") Then
        '							Print(fnum, "*BF:" & Trim(msg)) 'changed from Left to Trim 7/18/03 TMK
        '							ClaimString = ClaimString & "*BF:" & Trim(msg)
        '						End If
        '						Print(fnum, "~")
        '						ClaimString = ClaimString & "~"
        '						claimSegCount = claimSegCount + 1
        '						segmentCount = segmentCount + 1
        '					End If



        '					tmpConName = tmpset.Fields("name_key").Value
        '					segmentCount = segmentCount + 5
        '					HLID = HLID + 1
        '					serviceCount = 1

        '				End If '11/04/04 lhw   '(taken out 1/27/04 to skip duplicate J's -- TMK)
        '				' -----------------------------------------------

        '			Case "K"


        '				' ------------------ HIPAA ---------------------- 4/8 tmk
        '				If serviceCount = 50 Then
        '					Print(fnum, ClaimString)
        '					segmentCount = segmentCount + claimSegCount
        '					serviceCount = 1
        '				End If

        '				Print(fnum, "LX*" & serviceCount & "~")

        '				Print(fnum, "SV1*HC:" & medset.Fields("proc_code").Value)
        '				If (Trim(medset.Fields("proc_code_m").Value & "") <> "") Then Print(fnum, ":" & medset.Fields("proc_code_m").Value) 'added Trim() 9/29/03 TMK
        '				Print(fnum, "*" & medset.Fields("dol_billed").Value & "*UN*" & medset.Fields("att_units").Value)

        '				Print(fnum, "*" & medset.Fields("place_serv").Value & "**1**0~")



        '				Print(fnum, "DTP*472*")
        '				If (medset.Fields("from_Date").Value = medset.Fields("to_Date").Value) Then
        '					Print(fnum, "D8*" & VB6.Format(medset.Fields("from_Date").Value, "yyyymmdd") & "~")
        '				Else
        '					Print(fnum, "RD8*" & VB6.Format(medset.Fields("from_Date").Value, "yyyymmdd"))
        '					Print(fnum, "-" & VB6.Format(medset.Fields("to_Date").Value, "yyyymmdd") & "~")

        '				End If

        '				segmentCount = segmentCount + 3
        '				serviceCount = serviceCount + 1
        '				' -----------------------------------------------

        '			Case Else

        '		End Select
        '		medset.MoveNext()
        '	Loop 

        '	' ------------------ HIPAA ---------------------- 4/8 tmk
        '	medset.MovePrevious()
        '	Print(fnum, "SE*" & segmentCount & "*0001~")
        '	Print(fnum, "GE*1*" & Left(controlID, 3) & "~")
        '	PrintLine(fnum, "IEA*1*" & controlID & "~")
        '	' -----------------------------------------------

        '	FileClose(fnum)

        '	Call copy_ascii(outputfilename_b)
        '	medset.MoveLast()
        '	MsgBox("Please remove the floppy disk and label it with Submitter Name, Submitter #, date, and '837P'")

        '	valid_YN = "Y"
        '	'     Screen.MousePointer = vbDefault


        'End Sub

        'Sub calc_fiscal_year(ByRef calc_date As Object, ByRef test_fiscal_year As Object)
        '	'    the fiscal year is the 4 digit number of the year that ends on 6/30/yyyy
        '	'Dim calc_date As Date

        '	'UPGRADE_WARNING: Couldn't resolve default property of object calc_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	If Month(calc_date) < 7 Then
        '		'UPGRADE_WARNING: Couldn't resolve default property of object calc_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object test_fiscal_year. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		test_fiscal_year = Year(calc_date)
        '	Else
        '		'UPGRADE_WARNING: Couldn't resolve default property of object calc_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		'UPGRADE_WARNING: Couldn't resolve default property of object test_fiscal_year. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		test_fiscal_year = Year(calc_date) + 1
        '	End If

        'End Sub

        'Sub chk_diagnosis(ByRef namekey As Object, ByRef valid_YN As Object)
        '	'added 1/27/05 lhw
        '	'this is only used in SCO
        '	'not called in reg pca

        '	db = am1_Data_path & "dsm.mdb"
        '	tmpdb = DAODBEngine_definst.OpenDatabase(db)
        '	tmpset = tmpdb.OpenRecordset("diag_Codes", dao.RecordsetTypeEnum.dbOpenDynaset)

        '	sqlstmnt = " dsm_num = "
        '	'UPGRADE_WARNING: Couldn't resolve default property of object namekey. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	sqlstmnt = sqlstmnt & Chr(34) & namekey & Chr(34)

        '	tmpset.FindFirst(sqlstmnt)

        '	If tmpset.NoMatch Then
        '		'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		valid_YN = "N"
        '	Else
        '		'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		valid_YN = "Y"
        '		selected_lookup_num = tmpset.Fields("dsm_num").Value
        '		selected_lookup_desc = tmpset.Fields("dsm_desc").Value

        '	End If

        'End Sub

        'Sub chk_Proc_code(ByRef proc As Object, ByRef eff_Date As Object)

        '	'gets the most recent effective date for the usual fee

        '	'UPGRADE_WARNING: Arrays in structure tmp4set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '	Dim tmp4set As dao.Recordset

        '	On Error Resume Next
        '	db = am1_Data_path & "med_fee.mdb"
        '	tmpdb = DAODBEngine_definst.OpenDatabase(db)
        '	'added 6/2/03 to clarify error messages TMK
        '	strTableName = "medfee"
        '	tmp4set = tmpdb.OpenRecordset(strTableName, dao.RecordsetTypeEnum.dbOpenDynaset)

        '	Select Case Err.Number
        '		Case 0
        '		Case 3078 'no db
        '			MsgBox("Contact ETS.  Cannot open table: " & strTableName)
        '			Exit Sub
        '	End Select

        '	On Error GoTo 0

        '	sqlstmnt = " select * from " & strTableName & " where proc_Code = "
        '	'UPGRADE_WARNING: Couldn't resolve default property of object proc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	sqlstmnt = sqlstmnt & Chr(34) & proc & Chr(34)

        '	sqlstmnt = sqlstmnt & " and effective_Date <= "

        '	'UPGRADE_WARNING: Couldn't resolve default property of object eff_Date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	sqlstmnt = sqlstmnt & Chr(35) & eff_Date & Chr(35) & " order by effective_Date desc "

        '	If entry_type = "ADD" Then
        '		sqlstmnt = " select * from " & strTableName & " where proc_Code = "
        '		'UPGRADE_WARNING: Couldn't resolve default property of object proc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		sqlstmnt = sqlstmnt & Chr(34) & proc & Chr(34) & " and effective_Date <= "
        '		'UPGRADE_WARNING: Couldn't resolve default property of object eff_Date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		sqlstmnt = sqlstmnt & Chr(35) & eff_Date & Chr(35) & " order by effective_Date desc "
        '	End If

        '	tmp4set = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        '	If tmp4set.RecordCount = 0 Then
        '		valid_YN = "N"
        '	Else
        '		valid_YN = "Y"
        '		selected_proc_desc = tmp4set.Fields("proc_desc").Value
        '		selected_proc_fee = tmp4set.Fields("dol_fee").Value
        '		selected_proc_max = tmp4set.Fields("max_daily_units").Value
        '		selected_proc_code = tmp4set.Fields("proc_code").Value
        '		selected_proc_dol_actual = tmp4set.Fields("dol_actual").Value
        '	End If

        '	'UPGRADE_NOTE: Object tmp4set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        '	tmp4set = Nothing

        'End Sub
        'Sub chk_Proc_code_pca(ByRef proc As Object, ByRef eff_Date As Object)

        '	'gets the most recent effective date for the usual fee
        '	'used for the PCA import because there is no proc_code_m coming in payroll file
        '	'added 6/22/05 lhw

        '	'UPGRADE_WARNING: Arrays in structure tmp4set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '	Dim tmp4set As dao.Recordset

        '	On Error Resume Next
        '	db = am1_Data_path & "med_fee.mdb"
        '	tmpdb = DAODBEngine_definst.OpenDatabase(db)
        '	'added 6/2/03 to clarify error messages TMK
        '	strTableName = "medfee"
        '	tmp4set = tmpdb.OpenRecordset(strTableName, dao.RecordsetTypeEnum.dbOpenDynaset)

        '	Select Case Err.Number
        '		Case 0
        '		Case 3078 'no db
        '			MsgBox("Contact ETS.  Cannot open table: " & strTableName)
        '			Exit Sub
        '	End Select

        '	On Error GoTo 0

        '	sqlstmnt = " select * from " & strTableName & " where proc_Code = "
        '	'UPGRADE_WARNING: Couldn't resolve default property of object proc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	sqlstmnt = sqlstmnt & Chr(34) & proc & Chr(34)
        '	'lhwxxx 6/16/05 lhw
        '	'add in query on proc_code_m
        '	sqlstmnt = sqlstmnt & " and proc_code_m ='' "

        '	sqlstmnt = sqlstmnt & " and effective_Date <= "

        '	'UPGRADE_WARNING: Couldn't resolve default property of object eff_Date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	sqlstmnt = sqlstmnt & Chr(35) & eff_Date & Chr(35) & " order by effective_Date desc "

        '	If entry_type = "ADD" Then
        '		sqlstmnt = " select * from " & strTableName & " where proc_Code = "
        '		'UPGRADE_WARNING: Couldn't resolve default property of object proc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		sqlstmnt = sqlstmnt & Chr(34) & proc & Chr(34) & " and effective_Date <= "
        '		'UPGRADE_WARNING: Couldn't resolve default property of object eff_Date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		sqlstmnt = sqlstmnt & Chr(35) & eff_Date & Chr(35) & " order by effective_Date desc "
        '	End If

        '	tmp4set = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        '	If tmp4set.RecordCount = 0 Then
        '		valid_YN = "N"
        '	Else
        '		valid_YN = "Y"
        '		selected_proc_desc = tmp4set.Fields("proc_desc").Value
        '		selected_proc_fee = tmp4set.Fields("dol_fee").Value
        '		selected_proc_max = tmp4set.Fields("max_daily_units").Value
        '		selected_proc_code = tmp4set.Fields("proc_code").Value

        '		selected_proc_dol_actual = tmp4set.Fields("dol_actual").Value
        '	End If

        '	'UPGRADE_NOTE: Object tmp4set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        '	tmp4set = Nothing

        'End Sub

        ''THIS VERSION INCLUDES CODE FOR THE PROCEDURE CODE MODIFIER
        'Sub chk_Proc_code_m(ByRef proc As Object, ByRef proc_mod As Object, ByRef eff_Date As Object)

        '	'gets the most recent effective date for the usual fee

        '	'UPGRADE_WARNING: Arrays in structure tmp4set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '	Dim tmp4set As dao.Recordset

        '	On Error Resume Next
        'db = am1_Data_path & "med_fee.mdb"
        'tmpdb = DAODBEngine_definst.OpenDatabase(db)
        'tmp4set = tmpdb.OpenRecordset("medfee", dao.RecordsetTypeEnum.dbOpenDynaset)
        'Select Case Err.Number
        '    Case 0
        '    Case 0 'no db
        '        MsgBox("Contact ETS to activate this module")
        '        Exit Sub
        'End Select

        'On Error GoTo 0

        ''UPGRADE_WARNING: Couldn't resolve default property of object proc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = " select * from medfee where proc_Code = " & Chr(34) & proc & Chr(34)
        ''UPGRADE_WARNING: Couldn't resolve default property of object proc_mod. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If proc_mod <> "" Then
        '    'UPGRADE_WARNING: Couldn't resolve default property of object proc_mod. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    sqlstmnt = sqlstmnt & "and med_proc_code = " & Chr(34) & proc_mod & Chr(34) 'added 6/23/03 TMK
        'Else 'else added 7/24/03 TMK
        '    sqlstmnt = sqlstmnt & "AND med_proc_code = " & Chr(34) & Chr(34)
        'End If
        ''UPGRADE_WARNING: Couldn't resolve default property of object eff_Date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = sqlstmnt & " and effective_Date <= " & Chr(35) & eff_Date & Chr(35) & " order by effective_Date desc "

        'tmp4set = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        'If tmp4set.RecordCount = 0 Then
        '    'try again with an empty proc_code_m = Null - TMK 10/9/03

        '    'UPGRADE_WARNING: Couldn't resolve default property of object proc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    sqlstmnt = " select * from medfee where proc_Code = " & Chr(34) & proc & Chr(34)
        '    'UPGRADE_WARNING: Couldn't resolve default property of object proc_mod. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    If proc_mod <> "" Then
        '        'UPGRADE_WARNING: Couldn't resolve default property of object proc_mod. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        sqlstmnt = sqlstmnt & "and med_proc_code = " & Chr(34) & proc_mod & Chr(34) 'added 6/23/03 TMK
        '    Else
        '        sqlstmnt = sqlstmnt & "AND med_proc_code = Null" 'TMK 10/9/03
        '    End If
        '    'UPGRADE_WARNING: Couldn't resolve default property of object eff_Date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    sqlstmnt = sqlstmnt & " and effective_Date <= " & Chr(35) & eff_Date & Chr(35) & " order by effective_Date desc "

        '    tmp4set = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        '    If tmp4set.RecordCount = 0 Then
        '        Valid_YN = "N"
        '    Else
        '        Valid_YN = "Y"
        '    End If

        'Else
        '    Valid_YN = "Y"
        'End If

        'If Valid_YN = "Y" Then
        '    'added 6/23/03 for modifier TMK
        '    selected_proc_code_m = tmp4set.Fields("med_proc_code").Value & ""
        '    selected_proc_desc = tmp4set.Fields("proc_desc").Value
        '    selected_proc_fee = tmp4set.Fields("dol_fee").Value
        '    selected_proc_max = tmp4set.Fields("max_daily_units").Value
        '    selected_proc_code = tmp4set.Fields("proc_code").Value
        '    selected_proc_dol_actual = tmp4set.Fields("dol_actual").Value
        'End If

        ''UPGRADE_NOTE: Object tmp4set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'tmp4set = Nothing

    End Sub
	
	
	
	'Sub chk_Proc_Mod(proc)
	'Created 6/17/03 to check if there are modified procedure codes to choose from TMK
	
	'    Dim tmp4set As Recordset
	
	'    On Error Resume Next
	
	'    db = am1_Data_path & "med_fee.mdb"
	'    Set tmpdb = OpenDatabase(db)
	'    Set tmp4set = tmpdb.OpenRecordset("medfee", dbOpenDynaset)
	'
	'    If err <> 0 Then
	'        MsgBox "Contact ETS to activate this module"
	'        Exit Sub
	'    End If
	
	'    On Error GoTo 0
	'
	'    sqlstmnt = " select * from medfee where proc_Code = " & Chr(34) & proc & Chr(34)
	'
	'    Set tmp4set = tmpdb.OpenRecordset(sqlstmnt, dbOpenDynaset)
	'
	'    'modified 6/18/03 to only launch when necessary TMK
	'    selected_proc_code_m = ""
	'    If tmp4set.RecordCount = 0 Then
	'        valid_yn = "N"
	'    Else
	'        tmp4set.MoveFirst
	'        Do While Not tmp4set.EOF
	'            If tmp4set.Fields("med_proc_code") <> "" Then
	'                valid_yn = "Y"
	'                selected_proc_code = proc
	'                select_proc_code_m.Show 1
	'                Exit Do
	'            End If
	'            tmp4set.MoveNext
	'        Loop
	'    End If
	'
	'    Set tmp4set = Nothing
	'End Sub
	
	Sub chk_proc_outdated(ByRef proc As Object, ByRef proc_mod As Object, ByRef eff_Date As Object)
		'Created 6/18/03 - TMK
		'this checks to see if the procedure code WITH modifier is not the most recent version
		'if an identical procedure code (including modifier) has a more recent effective date,
		'   then valid_yn is set to "N"
		
        ''UPGRADE_WARNING: Arrays in structure tmp4set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim tmp4set As dao.Recordset
        'valid_YN = "Y"

        'On Error Resume Next

        'db = am1_Data_path & "med_fee.mdb"
        'tmpdb = DAODBEngine_definst.OpenDatabase(db)
        'tmp4set = tmpdb.OpenRecordset("medfee", dao.RecordsetTypeEnum.dbOpenDynaset)

        'Select Case Err.Number
        '	Case 0
        '	Case 0 'no db
        '		MsgBox("Contact ETS to activate this module")
        '		Exit Sub
        'End Select

        'On Error GoTo 0

        'sqlstmnt = " select * from medfee where proc_Code = "
        ''UPGRADE_WARNING: Couldn't resolve default property of object proc_mod. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object proc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = sqlstmnt & Chr(34) & proc & Chr(34) & " and med_proc_code = " & Chr(34) & proc_mod & Chr(34)
        ''UPGRADE_WARNING: Couldn't resolve default property of object eff_Date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = sqlstmnt & " and effective_Date >= " & Chr(35) & eff_Date & Chr(35)

        'tmp4set = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        ''get the right record count
        'tmp4set.MoveLast()
        'tmp4set.MoveFirst()

        ''if there's more than one record with an effective date today or later, this procedure is outdated
        'If tmp4set.RecordCount > 1 Then valid_YN = "N"

        ''UPGRADE_NOTE: Object tmp4set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'tmp4set = Nothing
		
	End Sub
	
	Sub get_changed_med_fee(ByRef proc As Object, ByRef eff_Date As Object)
		'Created 5/22/03 - TMK
		'gets the rate of the old procedure
		'so can calculate adjustments that are for a new procedure code
		'UPGRADE_WARNING: Arrays in structure tmp4set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '	Dim tmp4set As dao.Recordset
		
		On Error Resume Next
		
        'db = am1_Data_path & "med_fee.mdb"
        'tmpdb = DAODBEngine_definst.OpenDatabase(db)
        ''added 6/2/03 to clarify error message TMK
        'strTableName = "medfee"
        'tmp4set = tmpdb.OpenRecordset(strTableName, dao.RecordsetTypeEnum.dbOpenDynaset)

        'Select Case Err.Number
        '	Case 0 'no db
        '	Case 3078
        '		MsgBox("Contact ETS.  Cannot open table: " & strTableName)
        '		Exit Sub
        'End Select

        'On Error GoTo 0

        'sqlstmnt = " select * from " & strTableName & " where proc_Code = "
        ''UPGRADE_WARNING: Couldn't resolve default property of object proc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = sqlstmnt & Chr(34) & proc & Chr(34) & " and effective_Date <= "
        ''UPGRADE_WARNING: Couldn't resolve default property of object eff_Date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = sqlstmnt & Chr(35) & eff_Date & Chr(35) & " order by effective_Date desc "

        'tmp4set = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        'If tmp4set.RecordCount = 0 Then
        '	valid_YN = "N"
        'Else
        '	selected_proc_dol_actual = tmp4set.Fields("dol_actual").Value
        '	tmp4set.MoveLast() 'to get the right recordcount
        '	tmp4set.MoveFirst()

        '	selected_proc_dol_actual = tmp4set.Fields("dol_actual").Value
        'End If

        ''UPGRADE_NOTE: Object tmp4set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'tmp4set = Nothing
		
	End Sub
	
	Sub get_prior_med_fee(ByRef proc As Object, ByRef proc_m As Object, ByRef eff_Date As Object)
		
		'gets the previous effective date for the usual fee
		'so can calculate adjustments
		'UPGRADE_WARNING: Arrays in structure tmp4set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
	'
	End Sub
	
	Sub chk_mbproc_code(ByRef mbproc As Object, ByRef mbnum As Object, ByRef eff_Date As Object)
		
        ''gets the most recent effective date for the usual fee

        ''UPGRADE_WARNING: Arrays in structure tmp4set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim tmp4set As dao.Recordset

        'On Error Resume Next
        'db = am1_Data_path & "mbhp_fee.mdb"
        'tmpdb = DAODBEngine_definst.OpenDatabase(db)
        ''added 6/2/03 to clarify error message TMK
        'strTableName = "mbhpfee"
        'tmp4set = tmpdb.OpenRecordset(strTableName, dao.RecordsetTypeEnum.dbOpenDynaset)

        'Select Case Err.Number
        '	Case 0 'no db
        '	Case 3078
        '		MsgBox("Contact ETS.  Cannot open table: " & strTableName)
        '		Exit Sub
        'End Select

        'On Error GoTo 0

        'sqlstmnt = " select * from " & strTableName & " where mbproc_Code = "
        ''UPGRADE_WARNING: Couldn't resolve default property of object mbproc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = sqlstmnt & Chr(34) & mbproc & Chr(34) & " and effective_Date <= "
        ''UPGRADE_WARNING: Couldn't resolve default property of object eff_Date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = sqlstmnt & Chr(35) & eff_Date & Chr(35) & " order by effective_Date desc "

        'tmp4set = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        'If tmp4set.RecordCount = 0 Then
        '	valid_YN = "N"
        'Else
        '	valid_YN = "Y"
        '	selected_mbproc_code = tmp4set.Fields("mbproc_code").Value
        '	selected_mbproc_desc = tmp4set.Fields("mbproc_desc").Value
        '	selected_mbdol_fee = tmp4set.Fields("dol_fee").Value


        '	'find the right dol_actual fee based on mb num
        '	Select Case mbnum
        '		Case "0300010"
        '			selected_mbdol_actual = tmp4set.Fields("masters_licsw").Value
        '		Case "0300020"
        '			selected_mbdol_actual = tmp4set.Fields("cac_cadac").Value
        '		Case "0300030"
        '			selected_mbdol_actual = tmp4set.Fields("rn").Value
        '		Case "0300040"
        '			selected_mbdol_actual = tmp4set.Fields("md_do").Value
        '		Case "0300050"
        '			selected_mbdol_actual = tmp4set.Fields("psychologist").Value
        '		Case "0300060"
        '			selected_mbdol_actual = tmp4set.Fields("sw_intern").Value
        '		Case "0300070"
        '			selected_mbdol_actual = tmp4set.Fields("psych_intern").Value
        '		Case "0300080"
        '			selected_mbdol_actual = tmp4set.Fields("rncs").Value

        '		Case Else
        '			selected_mbdol_actual = 0

        '	End Select

        'End If
        ''UPGRADE_NOTE: Object tmp4set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'tmp4set = Nothing
		
	End Sub
	Public Sub chk_mb_autho(ByRef autho As Object, ByRef name_key As Object, ByRef from_date As Object, ByRef to_date As Object, ByRef err_Code As Object)
		
        ''UPGRADE_WARNING: Arrays in structure tmp4set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim tmp4set As dao.Recordset

        'On Error Resume Next
        'db = am_data_path & "mbhp.mdb"
        'tmpdb = DAODBEngine_definst.OpenDatabase(db)
        ''added 6/2/03 to clarify error message TMK
        'strTableName = "pri_auth"
        'tmp4set = tmpdb.OpenRecordset(strTableName, dao.RecordsetTypeEnum.dbOpenDynaset)

        'Select Case Err.Number
        '	Case 0 'no db
        '	Case 3078
        '		MsgBox("Contact ETS.  Cannot open table: " & strTableName)
        '		Exit Sub
        'End Select

        'On Error GoTo 0

        ''UPGRADE_WARNING: Couldn't resolve default property of object autho. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = " select * from " & strTableName & " where prior_auth = " & Chr(34) & autho & Chr(34)
        ''UPGRADE_WARNING: Couldn't resolve default property of object name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = sqlstmnt & "and name_key = " & Chr(34) & name_key & Chr(34)

        'tmp4set = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        'If tmp4set.RecordCount = 0 Then
        '	valid_YN = "N"
        'Else 'now we check the date ranges
        '	'UPGRADE_WARNING: Couldn't resolve default property of object err_Code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	err_Code = 0
        '	'UPGRADE_WARNING: Couldn't resolve default property of object from_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
        '	If DateDiff(Microsoft.VisualBasic.DateInterval.Day, tmp4set.Fields("beg_Date").Value, from_date) < 0 Then 'if neg bad
        '		'UPGRADE_WARNING: Couldn't resolve default property of object err_Code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		err_Code = err_Code + 1
        '	End If

        '	'UPGRADE_WARNING: Couldn't resolve default property of object to_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
        '	If DateDiff(Microsoft.VisualBasic.DateInterval.Day, tmp4set.Fields("end_Date").Value, to_date) > 0 Then 'if pos bad
        '		'UPGRADE_WARNING: Couldn't resolve default property of object err_Code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		err_Code = err_Code + 2
        '	End If

        '	'UPGRADE_WARNING: Couldn't resolve default property of object err_Code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	If err_Code <> 0 Then 'set before or after
        '		Select Case err_Code

        '			Case 1 'all before
        '				'UPGRADE_WARNING: Couldn't resolve default property of object to_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
        '				If DateDiff(Microsoft.VisualBasic.DateInterval.Day, tmp4set.Fields("beg_Date").Value, to_date) < 0 Then 'beg date after to date
        '					'UPGRADE_WARNING: Couldn't resolve default property of object err_Code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					err_Code = err_Code + 3
        '				End If

        '			Case 2 'all after
        '				'UPGRADE_WARNING: Couldn't resolve default property of object from_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				'UPGRADE_WARNING: DateDiff behavior may be different. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B38EC3F-686D-4B2E-B5A5-9E8E7A762E32"'
        '				If DateDiff(Microsoft.VisualBasic.DateInterval.Day, tmp4set.Fields("end_Date").Value, from_date) > 0 Then 'if pos bad
        '					'UPGRADE_WARNING: Couldn't resolve default property of object err_Code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					err_Code = err_Code + 3
        '				End If

        '			Case 3 'no change we know the problem

        '		End Select

        '	End If
        '	'err code 0 = good
        '	'err code 1 = start to soon
        '	'err code 2 = end to late
        '	'err code 3 = too long a range runs before and after
        '	'err code 4 = both before
        '	'err code 5 = both after

        '	valid_YN = "Y"
        'End If
        ''UPGRADE_NOTE: Object tmp4set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'tmp4set = Nothing

		
		
	End Sub
	'UPGRADE_NOTE: loc was upgraded to loc_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Sub chk_mbloc(ByRef loc_Renamed As Object, ByRef valid_YN As Object)
		'UPGRADE_WARNING: Arrays in structure tmp4set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '	Dim tmp4set As dao.Recordset

        '	db = am_data_path & "mbhp.mdb"
        '	tmpdb = DAODBEngine_definst.OpenDatabase(db)

        '	'UPGRADE_WARNING: Couldn't resolve default property of object loc_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	sqlstmnt = " select * from serv_loc32 where name_key = " & Chr(34) & loc_Renamed & Chr(34)

        '	tmp4set = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        '	If tmp4set.RecordCount = 0 Then
        '		'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		valid_YN = "N"
        '	Else 'now we check the date ranges
        '		'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		valid_YN = "Y"
        '		selected_lookup_desc = tmp4set.Fields("sort_name").Value
        '	End If

        '	'UPGRADE_NOTE: Object tmp4set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        '	tmp4set = Nothing

        'End Sub
        'Public Sub chk_mbclin(ByRef key As Object, ByRef valid_YN As Object)
        '	'UPGRADE_WARNING: Arrays in structure tmp4set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '	Dim tmp4set As dao.Recordset

        '	db = am_data_path & "mbhp.mdb"
        '	tmpdb = DAODBEngine_definst.OpenDatabase(db)

        '	'UPGRADE_WARNING: Couldn't resolve default property of object key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	sqlstmnt = " select * from clin_prov31 where name_key = " & Chr(34) & key & Chr(34)

        '	tmp4set = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        '	If tmp4set.RecordCount = 0 Then
        '		'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		valid_YN = "N"
        '	Else 'now we check the date ranges
        '		'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		valid_YN = "Y"
        '		selected_lookup_desc = tmp4set.Fields("sort_name").Value
        '		selected_print_name = tmp4set.Fields("name_to_print").Value
        '		selected_mb_num = tmp4set.Fields("mb_num").Value

        '	End If

        '	'UPGRADE_NOTE: Object tmp4set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        '	tmp4set = Nothing

    End Sub
	Public Sub chk_mbrefphys(ByRef key As Object, ByRef valid_YN As Object)
		'UPGRADE_WARNING: Arrays in structure tmp4set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim tmp4set As dao.Recordset

        'db = am_data_path & "mbhp.mdb"
        'tmpdb = DAODBEngine_definst.OpenDatabase(db)

        ''UPGRADE_WARNING: Couldn't resolve default property of object key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = " select * from ref_phys17 where name_key = " & Chr(34) & key & Chr(34)

        'tmp4set = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        'If tmp4set.RecordCount = 0 Then
        '	'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	valid_YN = "N"
        'Else 'now we check the date ranges
        '	'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	valid_YN = "Y"
        '	selected_lookup_desc = tmp4set.Fields("sort_name").Value
        '	selected_print_name = tmp4set.Fields("name_for_form").Value
        '	selected_mb_num = tmp4set.Fields("mb_num").Value

        'End If

        ''UPGRADE_NOTE: Object tmp4set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'tmp4set = Nothing
	End Sub
	Public Sub chk_prov_code(ByRef code3 As Object, ByRef num_type As Object, ByRef valid_YN As Object)
		
        '	For num = 0 To 200
        'If Len(Trim(med_array(1, num))) = 0 Then Exit For
        'UPGRADE_WARNING: Couldn't resolve default property of object code3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If med_array(2, num) = code3 Then
        'UPGRADE_WARNING: Couldn't resolve default property of object num_type. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If num_type = med_array(1, num) Then
        'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'valid_YN = "Y"
        'End If
        'End If
        'Next 
	End Sub
	Public Sub copy_ascii_c(ByRef filename As Object)
		'set up for CPSS to test not writing to A: if answer is no
		
		Dim filename1 As String
		Dim fnum1 As Integer
		Dim batname As String
		Dim seq_num As Short 'created 7/15/03 for HIPAA compliant filename TMK
		Dim tmp_batch_num As Short '  "
		
		On Error Resume Next
		
		Response = MsgBox("Answer Yes to Send file to A:\or Answer No to send to c:\", MsgBoxStyle.YesNo)
		If Response = MsgBoxResult.Yes Then
			
			MsgBox("Please insert a blank floppy in drive a:")
tryagain: 
			
			'get the type of file mb or med
			'UPGRADE_WARNING: Couldn't resolve default property of object filename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Response = InStr(filename, "submissions\")
			'UPGRADE_WARNING: Couldn't resolve default property of object filename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			batname = Mid(filename, Response + 12)
			
			
			'look for a file already so named and if so ask if you want to write over the file
			On Error Resume Next
			Select Case Left(batname, 2)
				Case "ME", "me"
					fnum1 = FreeFile
					
					'--------------------------------------------------------
                    ''changed from a:\MMMEDSV for HIPAA compliancy 7/15/03 TMK
                    'db = am1_Data_path & "med_top.mdb"
                    'tmpdb = DAODBEngine_definst.OpenDatabase(db)
                    'sqlstmnt = "SELECT * FROM batch_control WHERE entry_date = #" & Today & "# ORDER BY batch_num;"
                    'tmpset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
                    'tmpset.MoveFirst()
                    'seq_num = 1
                    'tmp_batch_num = tmpset.Fields("batch_num").Value
                    ''the sequence number will be the number of different batch numbers for one day in batch_control
                    'Do While Not tmpset.EOF
                    '	If tmpset.Fields("batch_num").Value <> tmp_batch_num Then
                    '		seq_num = seq_num + 1
                    '		tmp_batch_num = tmpset.Fields("batch_num").Value
                    '	End If
                    '	tmpset.MoveNext()
                    'Loop 

					
					filename1 = "a:\H" & temp_proc_num & ".00" & Right(CStr(seq_num), 1)
					'--------------------------------------------------------
					
					FileOpen(fnum1, filename1, OpenMode.Input, , , 1)
					If Err.Number = 0 Then
						Response = MsgBox("The A: drive already contains a medicaid submittal file. Do you wish to write over it?  If no then remove floppy and push the no button.", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
						If Response = 7 Then GoTo tryagain
					End If
					'will need to be added if no drive A:
					'If err = 76 Or err = 68 Then
					'MsgBox "This computer does not have a Drive A:" _
					''& "Therefore the output file will be written to the hard drive" _
					''& ""
					
					
					Err.Clear()
					FileClose(fnum1)
					
					'changed for HIPAA compliancy to filename1 TMK 7/15/03
					FileCopy(outputfilename_b, filename1)
					If Err.Number = 61 Then 'added lhw/scs 6/16/02
						MsgBox("File too large to copy to floppy.  Please bill a shorter date range.  Do no bill more than 9000 records.")
						End
					End If
					
					
				Case "MB", "mb"
					
					
					fnum1 = FreeFile
					filename1 = "a:\" & batname
					FileOpen(fnum1, filename1, OpenMode.Input, , , 1)
					If Err.Number = 0 Then
						Response = MsgBox("The A: drive already contains a mbhp submittal file. Do you wish to write over it?  If no then remove floppy and push the no button.", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
						If Response = 7 Then GoTo tryagain
					End If
					Err.Clear()
					FileClose(fnum1)
					
					FileCopy(outputfilename_b, "a:\" & batname)
					
				Case Else
					MsgBox("Ascii file not created.  Please copy it from Submissions.")
					
			End Select
			
			
			Select Case Err.Number
				
				Case 0
				Case 71
					MsgBox("Please put a disk in the a drive.")
					Err.Clear()
					GoTo tryagain
				Case 53
					MsgBox("Please put a disk in the a drive.")
					Err.Clear()
					GoTo tryagain
					
			End Select
			Err.Clear()
			On Error GoTo 0
		Else
			MsgBox("This is copying the file to c:\ on this computer.")
tryagain2: 
			'get the type of file mb or med
			'UPGRADE_WARNING: Couldn't resolve default property of object filename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Response = InStr(filename, "submissions\")
			'UPGRADE_WARNING: Couldn't resolve default property of object filename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			batname = Mid(filename, Response + 12)
			
			
			'look for a file already so named and if so ask if you want to write over the file
			On Error Resume Next
			Select Case Left(batname, 2)
				Case "ME", "me"
					fnum1 = FreeFile
					
					'--------------------------------------------------------
					'changed from a:\MMMEDSV for HIPAA compliancy 7/15/03 TMK
					db = am1_Data_path & "med_top.mdb"
                    'tmpdb = DAODBEngine_definst.OpenDatabase(db)
                    'sqlstmnt = "SELECT * FROM batch_control WHERE entry_date = #" & Today & "# ORDER BY batch_num;"
                    'tmpset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
                    'tmpset.MoveFirst()
                    'seq_num = 1
                    'tmp_batch_num = tmpset.Fields("batch_num").Value
                    ''the sequence number will be the number of different batch numbers for one day in batch_control
                    'Do While Not tmpset.EOF
                    '	If tmpset.Fields("batch_num").Value <> tmp_batch_num Then
                    '		seq_num = seq_num + 1
                    '		tmp_batch_num = tmpset.Fields("batch_num").Value
                    '	End If
                    '	tmpset.MoveNext()
                    'Loop 
					
					
					filename1 = "c:\H" & temp_proc_num & ".00" & Right(CStr(seq_num), 1)
					'--------------------------------------------------------
					
					FileOpen(fnum1, filename1, OpenMode.Input, , , 1)
					If Err.Number = 0 Then
						Response = MsgBox("The C: drive already contains a medicaid submittal file. Do you wish to write over it?  If no then remove floppy and push the no button.", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
						If Response = 7 Then GoTo tryagain2
					End If
					'will need to be added if no drive A:
					'If err = 76 Or err = 68 Then
					'MsgBox "This computer does not have a Drive A:" _
					''& "Therefore the output file will be written to the hard drive" _
					''& ""
					
					
					Err.Clear()
					FileClose(fnum1)
					
					'changed for HIPAA compliancy to filename1 TMK 7/15/03
					FileCopy(outputfilename_b, filename1)
					If Err.Number = 61 Then 'added lhw/scs 6/16/02
						MsgBox("File too large to copy to floppy.  Please bill a shorter date range.  Do no bill more than 9000 records.")
						End
					End If
					
				Case Else
					MsgBox("Ascii file not created.  Please copy it from Submissions.")
					
			End Select
			
			
			Select Case Err.Number
				
				Case 0
				Case 71
					MsgBox("Please put a disk in the a drive.")
					Err.Clear()
					GoTo tryagain
				Case 53
					MsgBox("Please put a disk in the a drive.")
					Err.Clear()
					GoTo tryagain
					
			End Select
			Err.Clear()
			On Error GoTo 0
			
		End If
	End Sub
	
	Public Sub copy_ascii(ByRef filename As Object)
		Dim filename1 As String
		Dim fnum1 As Integer
		Dim batname As String
		Dim seq_num As Short 'created 7/15/03 for HIPAA compliant filename TMK
		Dim tmp_batch_num As Short '  "
		
		On Error Resume Next
		
		MsgBox("Please insert a blank floppy in drive a:")
tryagain: 
		
		'get the type of file mb or med
		'UPGRADE_WARNING: Couldn't resolve default property of object filename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Response = InStr(filename, "submissions\")
		'UPGRADE_WARNING: Couldn't resolve default property of object filename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		batname = Mid(filename, Response + 12)
		
		
		'look for a file already so named and if so ask if you want to write over the file
		On Error Resume Next
		Select Case Left(batname, 2)
			Case "ME", "me"
				fnum1 = FreeFile
				
				'--------------------------------------------------------
				'changed from a:\MMMEDSV for HIPAA compliancy 7/15/03 TMK
				db = am1_Data_path & "med_top.mdb"
                'tmpdb = DAODBEngine_definst.OpenDatabase(db)
                'sqlstmnt = "SELECT * FROM batch_control WHERE entry_date = #" & Today & "# ORDER BY batch_num;"
                'tmpset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
                'tmpset.MoveFirst()
                'seq_num = 1
                'tmp_batch_num = tmpset.Fields("batch_num").Value
                ''the sequence number will be the number of different batch numbers for one day in batch_control
                'Do While Not tmpset.EOF
                '	If tmpset.Fields("batch_num").Value <> tmp_batch_num Then
                '		seq_num = seq_num + 1
                '		tmp_batch_num = tmpset.Fields("batch_num").Value
                '	End If
                '	tmpset.MoveNext()
                'Loop 
                filename1 = "a:\H" & temp_proc_num & ".00" & Right(CStr(seq_num), 1)
				'--------------------------------------------------------
				
				FileOpen(fnum1, filename1, OpenMode.Input, , , 1)
				If Err.Number = 0 Then
					Response = MsgBox("The A: drive already contains a medicaid submittal file. Do you wish to write over it?  If no then remove floppy and push the no button.", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
					If Response = 7 Then GoTo tryagain
				End If
				'will need to be added if no drive A:
				'If err = 76 Or err = 68 Then
				'MsgBox "This computer does not have a Drive A:" _
				''& "Therefore the output file will be written to the hard drive" _
				''& ""
				
				
				Err.Clear()
				FileClose(fnum1)
				
				'changed for HIPAA compliancy to filename1 TMK 7/15/03
				FileCopy(outputfilename_b, filename1)
				If Err.Number = 61 Then 'added lhw/scs 6/16/02
					MsgBox("File too large to copy to floppy.  Please bill a shorter date range.  Do no bill more than 9000 records.")
					End
				End If
				
				
			Case "MB", "mb"
				
				
				fnum1 = FreeFile
				filename1 = "a:\" & batname
				FileOpen(fnum1, filename1, OpenMode.Input, , , 1)
				If Err.Number = 0 Then
					Response = MsgBox("The A: drive already contains a mbhp submittal file. Do you wish to write over it?  If no then remove floppy and push the no button.", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
					If Response = 7 Then GoTo tryagain
				End If
				Err.Clear()
				FileClose(fnum1)
				
				FileCopy(outputfilename_b, "a:\" & batname)
				
			Case Else
				MsgBox("Ascii file not created.  Please copy it from Submissions.")
				
		End Select
		
		
		Select Case Err.Number
			
			Case 0
			Case 71
				MsgBox("Please put a disk in the a drive.")
				Err.Clear()
				GoTo tryagain
			Case 53
				MsgBox("Please put a disk in the a drive.")
				Err.Clear()
				GoTo tryagain
				
		End Select
		Err.Clear()
		On Error GoTo 0
		
		
	End Sub
	Sub create_date_records(ByRef namekey As Object, ByRef begin_date As Object, ByRef stop_date As Object)
		'admin is only one date
		'10/27/06    added to get individual days to send to EDS
        'tmp1db = DAODBEngine_definst.OpenDatabase(am_data_path & "pca_import.mdb")
        'tmp1set = tmp1db.OpenRecordset("valid_meds", dao.RecordsetTypeEnum.dbOpenDynaset)

        ''10/27/2006 added dates to select
        ''UPGRADE_WARNING: Couldn't resolve default property of object namekey. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = "Select * from valid_meds where name_key = " & Chr(34) & Trim(namekey) & Chr(34)
        ''UPGRADE_WARNING: Couldn't resolve default property of object begin_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = sqlstmnt & " AND start_date = " & Chr(35) & begin_date & Chr(35)
        ''UPGRADE_WARNING: Couldn't resolve default property of object stop_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'sqlstmnt = sqlstmnt & " AND end_Date = " & Chr(35) & stop_date & Chr(35)

        'tmp1set = tmp1db.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)



        'tmp1set.MoveFirst()

        'tmpdb = DAODBEngine_definst.OpenDatabase(am_data_path & "pca_import.mdb")
        'tmpset = tmpdb.OpenRecordset("valid_meds", dao.RecordsetTypeEnum.dbOpenDynaset) 'was tmp1db

        'Dim first_date As Date
        'Dim next_date As Date
        'Dim last_date As Date

        'first_date = tmp1set.Fields("start_Date").Value
        'next_date = tmp1set.Fields("start_Date").Value
        'last_date = tmp1set.Fields("end_Date").Value


        'If first_date <= last_date Then

        '	Do While next_date <= last_date

        '		'write out a new date record
        '		tmpset.AddNew()
        '		tmpset.Fields("name_key").Value = tmp1set.Fields("name_key").Value
        '		tmpset.Fields("start_Date").Value = next_date
        '		tmpset.Fields("end_Date").Value = next_date
        '		tmpset.Fields("prior_auth").Value = tmp1set.Fields("prior_auth").Value
        '		tmpset.Fields("att_units").Value = 1
        '		tmpset.Fields("proc_Code").Value = tmp1set.Fields("proc_Code").Value
        '		tmpset.Fields("f1_date").Value = tmp1set.Fields("f1_date").Value
        '		tmpset.Fields("first_name").Value = tmp1set.Fields("first_name").Value
        '		tmpset.Fields("last_name").Value = tmp1set.Fields("last_name").Value
        '		tmpset.Fields("med_num").Value = tmp1set.Fields("med_num").Value
        '		tmpset.Fields("dob").Value = tmp1set.Fields("dob").Value
        '		tmpset.Fields("service_Date").Value = next_date

        '		tmpset.Update()

        '		next_date = System.Date.FromOADate(next_date.ToOADate + 1)
        '	Loop 

        'End If


        ''Set tmp1set = Nothing
        ''Set tmp2set = Nothing
		
	End Sub
	Public Sub ets_chk_med_num(ByRef sendstring As Object, ByRef retstring As Object, ByRef valid_YN As Object)
		'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		valid_YN = "N"
		If Len(sendstring) = 0 Then
			'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			valid_YN = "Y"
			'UPGRADE_WARNING: Couldn't resolve default property of object sendstring. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: Couldn't resolve default property of object retstring. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			retstring = sendstring
			Exit Sub
		End If
		
        '	Dim sendstring_tmp As String
		Dim total_num As Decimal
        '	Dim num1 As Short
		Select Case Len(sendstring)
			
			Case 7, 10
				
				'substitute numbers for the letters and strip the dashes
				
				'UPGRADE_WARNING: Couldn't resolve default property of object sendstring. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '				For num = 1 To Len(sendstring & "")
                'UPGRADE_WARNING: Couldn't resolve default property of object sendstring. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'If Mid(sendstring, num, 1) <> "-" Then
                'UPGRADE_WARNING: Couldn't resolve default property of object sendstring. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'sendstring_tmp = sendstring_tmp & Mid(sendstring, num, 1)
                'End If
                'Next 

                '           sendstring_tmp = UCase(sendstring_tmp)
                'UPGRADE_WARNING: Couldn't resolve default property of object retstring. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                '      retstring = sendstring_tmp
                '          For num = 1 To Len(sendstring_tmp) - 1
                'If Not IsNumeric(Mid(sendstring_tmp, num, 1)) Then
                'Select Case Mid(sendstring_tmp, num, 1)

                '    Case "A", "J"
                '        sendstring_tmp = Left(sendstring_tmp, num - 1) & "1" & Right(sendstring_tmp, Len(sendstring_tmp) - num)

                '    Case "B", "K", "S"
                '        sendstring_tmp = Left(sendstring_tmp, num - 1) & "2" & Right(sendstring_tmp, Len(sendstring_tmp) - num)

                '    Case "C", "L", "T"
                '        sendstring_tmp = Left(sendstring_tmp, num - 1) & "3" & Right(sendstring_tmp, Len(sendstring_tmp) - num)

                '    Case "D", "M", "U"
                '        sendstring_tmp = Left(sendstring_tmp, num - 1) & "4" & Right(sendstring_tmp, Len(sendstring_tmp) - num)

                '    Case "E", "N", "V"
                '        sendstring_tmp = Left(sendstring_tmp, num - 1) & "5" & Right(sendstring_tmp, Len(sendstring_tmp) - num)

                '    Case "F", "O", "W"
                '        sendstring_tmp = Left(sendstring_tmp, num - 1) & "6" & Right(sendstring_tmp, Len(sendstring_tmp) - num)

                '    Case "G", "P", "X"
                '        sendstring_tmp = Left(sendstring_tmp, num - 1) & "7" & Right(sendstring_tmp, Len(sendstring_tmp) - num)

                '    Case "H", "Q", "Y"
                '        sendstring_tmp = Left(sendstring_tmp, num - 1) & "8" & Right(sendstring_tmp, Len(sendstring_tmp) - num)

                '    Case "I", "R", "Z"
                '        sendstring_tmp = Left(sendstring_tmp, num - 1) & "9" & Right(sendstring_tmp, Len(sendstring_tmp) - num)


                'End Select

                '        End If
                '        Next

                ''multiply
                ''type_num = Len(sendstring)
                'num1 = 2
                'For num = Len(sendstring_tmp) - 1 To 1 Step -1

                '    total_num = total_num + num1 * CDbl(Mid(sendstring_tmp, num, 1))
                '    num1 = num1 + 1
                '    If num1 > 7 Then num1 = 2
                'Next

        total_num = 11 - (total_num - Int(total_num / 11) * 11)
        If total_num = 11 Then
            total_num = 1
        Else
            If total_num > 9 Then total_num = 0
        End If

        'UPGRADE_WARNING: Couldn't resolve default property of object retstring. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        retstring = total_num
        'UPGRADE_WARNING: Couldn't resolve default property of object sendstring. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If CDbl(Right(sendstring, 1)) = total_num Then
            'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            valid_YN = "Y"
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            valid_YN = CStr(total_num)
        End If

            Case Else
        'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        valid_YN = "L"
        Exit Sub


        End Select
		
	End Sub
	Public Sub get_med_name_key(ByRef med_name_key As Object)
		
        'For num = 0 To 200
        '	If Len(Trim(med_array(1, num))) = 0 Then Exit For
        '	'UPGRADE_WARNING: Couldn't resolve default property of object med_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	If med_array(2, num) = med_name_key Then
        '		selected_lookup_num = med_array(3, num)
        '		Exit For
        '	End If
        'Next 
		
	End Sub
	Public Sub get_mbhp_name_key(ByRef med_name_key As Object)
		
        'For num = 0 To 200
        '	If Len(Trim(med_array(1, num))) = 0 Then Exit For
        '	'UPGRADE_WARNING: Couldn't resolve default property of object med_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	If med_array(2, num) = med_name_key Then
        '		selected_lookup_num = med_array(3, num)
        '		Exit For
        '	End If
        'Next 
		
	End Sub
	
	Public Sub get_temp_Data_path(ByRef code3 As Object)
		Dim numnum As Integer
		Dim num2 As Integer
		Dim right_Code3 As String
		Dim left_code3 As String
		
		
		'which one in the array is the selection
		'the selection was sorted
		'UPGRADE_WARNING: Couldn't resolve default property of object code3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Response = InStr(code3, "--")
		'  If Response = 0 Then
		'  selected_proc_num = ""
		' Else
		'UPGRADE_WARNING: Couldn't resolve default property of object code3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		left_code3 = Trim(Left(code3, Response - 1))
		'UPGRADE_WARNING: Couldn't resolve default property of object code3. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		right_Code3 = Trim(Right(code3, Len(code3) - (Response + 1)))
		selected_prov_num = right_Code3
		'  End If
		
		For numnum = 0 To 200
			If Len(Trim(med_array(5, numnum))) = 0 Then Exit For
			If Trim(med_array(5, numnum)) = left_code3 Then Exit For
		Next 
		'do not force the drive
		'so work back one level but ignore the ending slash
		msg = ""
		For num2 = Len(am1_Data_path) - 2 To 0 Step -1
			If Mid(am1_Data_path, num2, 1) = "\" Then
				msg = Left(am1_Data_path, num2)
				Exit For
			End If
		Next 
		tmp_data_path = msg & Trim(med_array(4, numnum))
		
	End Sub
	
	Public Sub med_bill(ByRef temp_proc_num As Object, ByRef bat_num As Object)
		'this prints any reports required and writes the CSV file
		
		'UPGRADE_WARNING: Couldn't resolve default property of object temp_proc_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		msg = temp_proc_num
        'prtparameterfields(0) = "Proc_num;" & msg & ";FALSE"
        prtWindowState = 2
        prtDestination = 0
        prtreportfilename = am1_report_path & "mededit.rpt"
		On Error Resume Next
        CrystalForm.ShowDialog()
		Select Case Err.Number
			Case 0
			Case 20504
				' MsgBox "This report was not found. " & prtreportfilename
				Exit Sub
			Case Else
				MsgBox("Error # " & Err.Number & " was generated by Crystal.  It means  " & ErrorToString(Err.Number))
				Exit Sub
		End Select
		On Error GoTo 0
		
		'prtparameterfields(0) = ""
		
		Dim rpt_name As String
		rpt_name = am1_Data_path & "submissions\"
		'UPGRADE_WARNING: Couldn't resolve default property of object bat_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		rpt_name = rpt_name & "med" & bat_num & ".rpt"
		
		'UPGRADE_WARNING: Couldn't resolve default property of object temp_proc_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		msg = temp_proc_num
		' prtparameterfields(0) = "Proc_num;" & msg & ";FALSE"
		'prtWindowState = 2
		'prtDestination = 2
		'prtPrintFileName = rpt_name
		'prtPrintFileType = 7
		'prtreportfilename = am1_report_path & "mededit.rpt"
		On Error Resume Next
        CrystalForm.ShowDialog()
		
		
		
		
	End Sub
	Public Sub med_compress()
		'check the existence of special proc mdb and load the variables
        Exit Sub 'added 7/2/01  to remove feature
		
		Err.Clear()
        '	Dim MyUserName As String
		' Get UserName of default workspace.
        'MyUserName = DAODBEngine_definst.Workspaces(0).UserName
        '	Dim newdb As dao.Database
        'Dim newdbx As String

        'db = am_data_path & "med.mdb"
        'newdbx = am_data_path & "med_comp.mdb"

        ''    Dim tmpwk As Workspace

        ''Set tmpwk = DBEngine.Workspaces(0)
        'On Error Resume Next

        ''Set tmpdb = tmpwk.OpenDatabase(db, True)

        ''check for error if in use

        'DAODBEngine_definst.CompactDatabase(db, newdbx)

        'Select Case Err.Number
        '	Case 0
        '		Kill(db)
        '		Rename(newdbx, db)
        '	Case 3196
        '		MsgBox("Database in use and can not be compressed.")

        '	Case Else
        '		MsgBox("Error # " & Err.Number & " occurred. It means " & Chr(13) & ErrorToString(Err.Number))

        'End Select

		
		'  Set tmpdb = Nothing
	End Sub
	Public Sub med_compress_top()
		'check the existence of special proc mdb and load the variables
		Err.Clear()
        '	Dim MyUserName As String
		' Get UserName of default workspace.
        'MyUserName = DAODBEngine_definst.Workspaces(0).UserName
        'Dim newdb As dao.Database
        'Dim newdbx As String

        'db = am1_Data_path & "med_top.mdb"
        'newdbx = am1_Data_path & "med_top_comp.mdb"

        ''    Dim tmpwk As Workspace

        ''Set tmpwk = DBEngine.Workspaces(0)
        'On Error Resume Next

        ''Set tmpdb = tmpwk.OpenDatabase(db, True)

        ''check for error if in use

        'DAODBEngine_definst.CompactDatabase(db, newdbx)

        'Select Case Err.Number
        '	Case 0
        '		Kill(db)
        '		Rename(newdbx, db)
        '	Case 3196
        '		MsgBox("Database in use and can not be compressed.")

        '	Case Else
        '		MsgBox("Error # " & Err.Number & " occurred. It means " & Chr(13) & ErrorToString(Err.Number))

        'End Select
		
    End Sub
	Public Sub med_num_open(ByRef valid_YN As Object)
		
		'check the existence of special proc mdb and load the variables
		Err.Clear()
        '	Dim MyUserName As String
		' Get UserName of default workspace.
        'MyUserName = DAODBEngine_definst.Workspaces(0).UserName

        'db = am1_Data_path & "med_prov.mdb"

        'Dim tmpwk As dao.Workspace

        'tmpwk = DAODBEngine_definst.Workspaces(0)
        'On Error Resume Next

        'tmpdb = tmpwk.OpenDatabase(db, False, False, "MS Access;PWD=ETS1")
        'tmpset = tmpdb.OpenRecordset("med_nums", dao.RecordsetTypeEnum.dbOpenDynaset)

        'Select Case Err.Number
        '	Case 0
        '		On Error GoTo 0
        '		'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		valid_YN = "Y"

        '	Case Else
        '		On Error GoTo 0
        '		MsgBox("Please contact ETS to activate this module")
        '		Exit Sub

        'End Select

        ''UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'valid_YN = "Y"

        'num = 0
        'Do While Not tmpset.EOF
        '	med_array(1, num) = tmpset.Fields("med_ident").Value
        '	med_array(2, num) = tmpset.Fields("med_num").Value
        '	med_array(3, num) = tmpset.Fields("name_key").Value
        '	med_array(4, num) = tmpset.Fields("dir_path").Value
        '	med_array(5, num) = tmpset.Fields("dir_name").Value
        '	med_array(6, num) = tmpset.Fields("print_copy").Value
        '	med_array(7, num) = tmpset.Fields("rebill").Value
        '	tmpset.MoveNext()
        '	num = num + 1
        'Loop 

        ''UPGRADE_NOTE: Object tmpset may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'tmpset = Nothing
        ''UPGRADE_NOTE: Object tmpdb may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'tmpdb = Nothing

		
	End Sub
	Public Sub med_open()
		'where we open the med.mdb and check for errors
		
		On Error Resume Next
		db = am_data_path & "med.mdb"
        'medmdb = DAODBEngine_definst.OpenDatabase(db)
		
		Select Case Err.Number
			Case 0
				med_flag = "Y"
				
				'set am1 data path to etsmed
                'For num = Len(am_data_path) - 1 To 1 Step -1
                '	If Mid(am_data_path, num, 1) = "\" Then
                '		am1_Data_path = Left(am_data_path, num) & "etsmed\"
                '		am1_report_path = Left(am_data_path, num) & "reports\"
                '		am1_documents_path = Left(am_data_path, num) & "documents\"
                '		Exit For
                '	End If
                'Next 
				
			Case 3024 'no db
				med_flag = "N"
				'MsgBox "Contact ETS to activate this module"
				Exit Sub
				
			Case Else
				med_flag = "N"
				Exit Sub
				
		End Select
		
		
        'medopn_tmp = medmdb.OpenRecordset("medopn_tmp", dao.RecordsetTypeEnum.dbOpenDynaset)
        'medcc = medmdb.OpenRecordset("medcc")

        ''now we determine if the person is a processor and set the flag and the array
        'valid_YN = "N"
        'Call med_num_open(valid_YN)
        'If valid_YN = "N" Then
        '	MsgBox("Call ETS to set up this module.")
        '	med_flag = "N"
        'End If
		
		
	End Sub
	
	Public Sub med_open_Top()
		'where we open the med.mdb and check for errors
		
		On Error Resume Next
		db = am_data_path & "med_top.mdb"
        'medmdb = DAODBEngine_definst.OpenDatabase(db)
		
		Select Case Err.Number
			Case 0
				med_flag = "Y"
				
				'set am1 data path to etsmed
                'For num = Len(am_data_path) - 1 To 1 Step -1
                '	If Mid(am_data_path, num, 1) = "\" Then
                '		am1_Data_path = Left(am_data_path, num) & "etsmed\"
                '		am1_report_path = Left(am_data_path, num) & "reports\"
                '		am1_documents_path = Left(am_data_path, num) & "documents\"
                '		Exit For
                '	End If
                'Next 
				
			Case 3024 'no db
				med_flag = "N"
				MsgBox("The med.mdb is missing from this directory.  Call ETS for help.")
				Exit Sub
				
			Case Else
				med_flag = "N"
				Exit Sub
				
		End Select
		
		
        'medopn_tmp = medmdb.OpenRecordset("medopn_tmp", dao.RecordsetTypeEnum.dbOpenDynaset)
        'medcc = medmdb.OpenRecordset("medcc")

        ''now we determine if the person is a processor and set the flag and the array
        'valid_YN = "N"
        'Call med_num_open(valid_YN)
        'If valid_YN = "N" Then
        '	MsgBox("Call ETS to set up this module.")
        '	med_flag = "N"
        'End If
		
		
		
	End Sub
	Public Sub med_pre_bill(ByRef key As Object)
		'this creates the submission page and prints the edit
		
		
		'    Set medsub = medmdb.OpenRecordset("med_submit", dbOpenDynaset)
		'   Do While Not medsub.EOF
		'  medsub.Delete
		' medsub.MoveNext
		'Loop
		
		'    sqlstmnt = "Select * from medopn_Tmp order by batch_num_line"
		'   Set medset = medmdb.OpenRecordset(sqlstmnt, dbOpenDynaset)
		
		'firdst create the records then go back and add up the ks that make up that claim and header
		
		'  Do While Not medset.EOF
		'     If medset.Fields("record_id") = "G" Or medset.Fields("record_id") = "H" Or medset.Fields("record_id") = "L" Or medset.Fields("record_id") = "M" Then
		'        medsub.AddNew
		'           medsub.Fields("prov_num") = medset.Fields("prov_num")
		'          medsub.Fields("proc_num") = medset.Fields("proc_num")
		'         medsub.Fields("inv_type") = "Medical Services"
		'        medsub.Fields("type") = "Original"
		'       medsub.Fields("inv_date") = medset.Fields("bill_date")
		'      medsub.Fields("batch_num") = medset.Fields("batch_num")
		'     medsub.Fields("batch_num_line_Beg") = medset.Fields("batch_num_line")
		'medsub.Update
		
		'        End If
		
		'   medset.MoveNext
		'  Loop
		
		'first the hs then the gs
		'    Dim end_line As Long
		'   medsub.MoveFirst
		'  Do While Not medsub.EOF
		'     If medsub.Fields("record_id") = "H" Then
		'        medsub.MoveNext
		'       end_line = medsub.Fields("batch_num_line_end")
		'      medsub.MovePrevious
		'     sqlstmnt = "Select * from medopn_Tmp where batch_num_line > " & medsub.Fields("batch_num_line_beg")
		'    sqlstmnt = sqlstmnt & " and batch_num_line < " & end_num & " order by batch_num_line"
		'   Set medset = medmdb.OpenRecordset(sqlstmnt, dbOpenDynaset)
		'  medsub.Edit
		'     Do While Not medset.EOF
		'        If medset.Fields("record_id") = "K" Then
		'       medsub.Fields("tot_claims") = medsub.Fields("tot_claims") + 1
		'      medsub.Fields("tot_dol") = medsub.Fields("tot_dol") + medset.Fields("dol_billed")
		'     End If
		'medset.MoveNext
		'                Loop
		'           medsub.Update
		'      End If
		' medsub.MoveNext
		'Loop
		
		'now add up the hs from above to get the gs
		
		
        prtWindowState = 2
        prtDestination = 0
        prtreportfilename = am1_report_path & "mededit.rpt"
		On Error Resume Next
        CrystalForm.ShowDialog()
		If Err.Number = 20504 Then
			' MsgBox "This report was not found. " & prtreportfilename
			
			Exit Sub
		End If
		On Error GoTo 0
		
		
	End Sub
    Public Sub med_write(ByVal temp_proc_num As String)

        ' Screen.MousePointer = vbHourglass

        '	meddb = DAODBEngine_definst.OpenDatabase(am1_Data_path & "med_top.mdb")
        'UPGRADE_WARNING: Couldn't resolve default property of object temp_proc_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        sqlstmnt = "Select * from medopn_bill where proc_num = " & Chr(34) & temp_proc_num & Chr(34) & " order by batch_num_line "

        '		medset = meddb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        '		outputfilename_b = am1_Data_path & "submissions\"
        '		outputfilename_b = outputfilename_b & "med" & medset.Fields("batch_num").Value & ".asc"
        fnum = FreeFile()
        On Error Resume Next 'added 7/26/06 lhw 
        FileOpen(fnum, outputfilename_b, OpenMode.Output, , , 1)
        If Err.Number = 76 Then
            MsgBox("Submission Directory must be located within the ETSMED directory. Fix this issue!")
            Exit Sub
        End If
        On Error GoTo 0


        Dim tmpProcName As String 'This is for HIPAA to compare proc. name to prov. name
        Dim tmpConName As String 'This is to eliminate duplicate 'J' records
        Dim HLID As Short 'Counter for hierarchical levels
        Dim parentHLID As Short 'Indicates which provider the consumers are referencing
        Dim serviceCount As Short 'Counter for the service/procedure loop
        Dim segmentCount As Integer 'Counter for the number of segments or '~'s
        Dim controlID As String 'Holds the batch number for the header/trailer tags
        Dim ProcString As String 'Holds the processor information in case of multiple providers
        Dim ProcAddress As String 'This is used for the consumer address if there is none

        '	Dim mednumdb As dao.Database
        'UPGRADE_WARNING: Arrays in structure mednum may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '		Dim mednum As dao.Recordset
        db = am1_Data_path & "med_prov.mdb"
        '		Dim tmpwk As dao.Workspace
        '		tmpwk = DAODBEngine_definst.Workspaces(0)
        '	mednumdb = tmpwk.OpenDatabase(db, False, False, "MS Access;PWD=ETS1")
        '		mednum = mednumdb.OpenRecordset("med_nums", dao.RecordsetTypeEnum.dbOpenDynaset)

        '		namaddrdb = DAODBEngine_definst.OpenDatabase(am1_Data_path & "glname.mdb")
        '		namaddrset = namaddrdb.OpenRecordset("nam_addr", dao.RecordsetTypeEnum.dbOpenDynaset)


        ' ------------------ HIPAA ---------------------- 4/8 tmk
        'UPGRADE_WARNING: Couldn't resolve default property of object temp_proc_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		controlID = Left(medset.Fields("batch_num").Value & temp_proc_num & zeroes, 9) 'using temp_proc_num instead of medset.fields("med_num") - 1/14/04 TMK
        '		Print(fnum, "ISA")
        '		Print(fnum, "*00*          *00*          *ZZ*")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object temp_proc_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		Print(fnum, Left(temp_proc_num & spaces, 15) & "*") ' changed from Left(mednum.Fields("med_num") & spaces, 15) & "*"; on 7/1/03 TMK
        '		Print(fnum, "ZZ*DMA7384        *")
        '		Print(fnum, VB6.Format(Now, "yymmdd") & "*")
        '		Print(fnum, VB6.Format(Now, "hhmm") & "*")
        '		Print(fnum, "U*00401*" & controlID & "*1*P*:~")

        '		Print(fnum, "GS")
        '		Print(fnum, "*HC*")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object temp_proc_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		Print(fnum, temp_proc_num & "*") 'changed from mednum.Fields("med_num") & "*"; on 7/1/03 TMK
        '		Print(fnum, "DMA7384*")
        '		Print(fnum, VB6.Format(Now, "yyyymmdd") & "*")
        '		Print(fnum, VB6.Format(Now, "hhmm") & "*" & Left(controlID, 3) & "*X*004010X098A1~")

        '		segmentCount = 0

        '		Print(fnum, "ST*837*0001~")
        '		Print(fnum, "BHT*0019*00*")
        '		Print(fnum, Left(controlID, 3) & "*")
        '		Print(fnum, VB6.Format(Now, "yyyymmdd") & "*")
        '		Print(fnum, VB6.Format(Now, "hhmm") & "*CH~")
        '		Print(fnum, "REF*87*004010X098A1~")

        '		segmentCount = segmentCount + 4 'count the SE segment here

        '		HLID = 1
        '		tmpConName = ""
        '		ProcString = ""
        '		ProcAddress = ""
        '		serviceCount = 1
        '		' -----------------------------------------------

        '		Do While Not medset.EOF

        '			Select Case medset.Fields("record_id").Value

        '				Case "G"
        '					sqlstmnt = " med_num = " & Chr(34) & medset.Fields("proc_num").Value & Chr(34)
        '					mednum.FindFirst(sqlstmnt)

        '					If mednum.NoMatch Then
        '						MsgBox("Bad processor number.")
        '						FileClose(fnum)
        '						Exit Sub
        '					End If

        '					sqlstmnt = " name_key = " & Chr(34) & mednum.Fields("name_key").Value & Chr(34)
        '					namaddrset.FindFirst(sqlstmnt)

        '					If namaddrset.NoMatch Then
        '						MsgBox("Bad processor number in glname.")
        '						FileClose(fnum)
        '						Exit Sub
        '					End If

        '					' ------------------ HIPAA ---------------------- 4/8 tmk
        '					Print(fnum, "NM1")
        '					Print(fnum, "*41*2*" & namaddrset.Fields("screen_nam").Value & "*****46*")
        '					Print(fnum, mednum.Fields("med_num").Value & "~")
        '					Print(fnum, "PER*IC*" & namaddrset.Fields("email").Value & "*TE*")
        '					msg = ""
        '					msg = Mid(namaddrset.Fields("telephone").Value, 2, 3) & Mid(namaddrset.Fields("telephone").Value, 7, 3) & Mid(namaddrset.Fields("telephone").Value, 11, 4)
        '					Print(fnum, msg & "~")

        '					Print(fnum, "NM1*40*2*MA MEDICAID*****46*DMA7384~")

        '					ProcString = ProcString & "NM1"
        '					ProcString = ProcString & "*85*2*" & namaddrset.Fields("screen_nam").Value & "*****24*" & mednum.Fields("med_num").Value & "~"

        '					ProcString = ProcString & "N3*" & namaddrset.Fields("address1").Value & "~"
        '					ProcAddress = ProcAddress & "N3*" & namaddrset.Fields("address1").Value & "~"
        '					ProcString = ProcString & "N4*" & namaddrset.Fields("city").Value & "*" & namaddrset.Fields("state").Value
        '					ProcAddress = ProcAddress & "N4*" & namaddrset.Fields("city").Value & "*" & namaddrset.Fields("state").Value
        '					ProcString = ProcString & "*" & Left(Trim(namaddrset.Fields("zip4").Value) & zeroes, 5) & "~" 'changed from Right() to Left() TMK
        '					ProcAddress = ProcAddress & "*" & Left(zeroes & Trim(namaddrset.Fields("zip4").Value) & zeroes, 5) & "~"

        '					ProcString = ProcString & "REF*1D*" & mednum.Fields("med_num").Value & "~"

        '					segmentCount = segmentCount + 3
        '					tmpProcName = ""
        '					tmpProcName = namaddrset.Fields("screen_nam").Value
        '					' -----------------------------------------------

        '				Case "H"
        '					sqlstmnt = " med_num = " & Chr(34) & medset.Fields("prov_num").Value & Chr(34)
        '					mednum.FindFirst(sqlstmnt)

        '					If mednum.NoMatch Then
        '						MsgBox("Bad provider number = " & medset.Fields("prov_num").Value)
        '						FileClose(fnum)
        '						Exit Sub
        '					End If

        '					sqlstmnt = " name_key = " & Chr(34) & mednum.Fields("name_key").Value & Chr(34)
        '					namaddrset.FindFirst(sqlstmnt)

        '					If namaddrset.NoMatch Then
        '						MsgBox("Bad processor number in glname.")
        '						FileClose(fnum)
        '						Exit Sub
        '					End If

        '					' ------------------ HIPAA ---------------------- 4/8 tmk
        '					Print(fnum, "HL*" & HLID & "**20*1~")
        '					parentHLID = HLID

        '					If (namaddrset.Fields("screen_nam").Value = tmpProcName) Then
        '						Print(fnum, "PRV*BI*ZZ*" & mednum.Fields("med_num").Value & "~")
        '						Print(fnum, ProcString)
        '						segmentCount = segmentCount + 6
        '					Else
        '						ProcAddress = ""
        '						Print(fnum, "PRV*PT*ZZ*" & mednum.Fields("med_num").Value & "~")
        '						Print(fnum, ProcString)

        '						Print(fnum, "NM1")
        '						Print(fnum, "*87*2*" & namaddrset.Fields("screen_nam").Value & "*****24*" & mednum.Fields("med_num").Value & "~")

        '						Print(fnum, "N3*" & namaddrset.Fields("address1").Value & "~")
        '						ProcAddress = ProcAddress & "N3*" & namaddrset.Fields("address1").Value & "~"
        '						Print(fnum, "N4*" & namaddrset.Fields("city").Value & "*" & namaddrset.Fields("state").Value)
        '						ProcAddress = ProcAddress & "N4*" & namaddrset.Fields("city").Value & "*" & namaddrset.Fields("state").Value
        '						Print(fnum, "*" & Left(Trim(namaddrset.Fields("zip4").Value) & zeroes, 5) & "~") 'changed from Right() to Left() TMK
        '						ProcAddress = ProcAddress & "*" & Left(Trim(namaddrset.Fields("zip4").Value) & zeroes, 5) & "~"

        '						Print(fnum, "REF*1D*" & mednum.Fields("med_num").Value & "~")

        '						segmentCount = segmentCount + 10
        '					End If
        '					HLID = HLID + 1
        '					' -----------------------------------------------

        '				Case "J"
        '					'   to get the right folder

        '					For num = 0 To 200
        '						If Trim(medset.Fields("prov_num").Value) = Trim(med_array(2, num)) Then Exit For
        '					Next 

        '					tmpdb = DAODBEngine_definst.OpenDatabase(Left(am1_Data_path, Len(am1_Data_path) - 7) & med_array(4, num) & "glname.mdb")

        '					tmpset = tmpdb.OpenRecordset("nam_addr", dao.RecordsetTypeEnum.dbOpenDynaset)
        '					sqlstmnt = " name_key = " & Chr(34) & medset.Fields("name_key").Value & Chr(34)
        '					tmpset.FindFirst(sqlstmnt)
        '					If tmpset.NoMatch Then
        '						MsgBox("Databases out of kilter.  Call ETS.")
        '						Exit Sub

        '					End If

        '					' ------------------ HIPAA ---------------------- 4/8 tmk
        '					'skip over duplicate J's - 4/10 tmk     (taken out 1/28/04 TMK)
        '					'If Not (tmpset.Fields("name_key") = tmpConName) Then

        '					Print(fnum, "HL*" & HLID & "*" & parentHLID & "*22*0~")
        '					Print(fnum, "SBR*P*18*******MC~")
        '					Print(fnum, "NM1")
        '					Print(fnum, "*IL*1*" & tmpset.Fields("last_name").Value & "*" & tmpset.Fields("first_name").Value & "*")
        '					If (tmpset.Fields("middle_ini").Value >= "A") And (tmpset.Fields("middle_ini").Value <= "Z") Then Print(fnum, tmpset.Fields("middle_ini").Value)
        '					Print(fnum, "***MI*" & medset.Fields("med_num").Value & "~")

        '					If Trim(tmpset.Fields("address1").Value) = "" Then 'added Trim () 7/17/03 TMK
        '						Print(fnum, ProcAddress)
        '					Else
        '						Print(fnum, "N3*" & tmpset.Fields("address1").Value & "~")
        '						Print(fnum, "N4*" & tmpset.Fields("city").Value & "*" & namaddrset.Fields("state").Value)
        '						Print(fnum, "*" & Left(Trim(namaddrset.Fields("zip4").Value) & zeroes, 5) & "~") 'changed from Right() to Left() 7/17/03 TMK
        '					End If

        '					Print(fnum, "DMG*D8*" & VB6.Format(medset.Fields("dob").Value, "yyyymmdd") & "*" & UCase(medset.Fields("sex").Value) & "~") 'UCase added 1/14/04 TMK
        '					Print(fnum, "NM1*PR*2*MEDICAID*****PI*DMA73~")
        '					'Claim information - patient account number is recommended for CLM01
        '					Print(fnum, "CLM*" & medset.Fields("pacct_num").Value & "*" & medset.Fields("usual_Fee").Value & "***")
        '					Print(fnum, medset.Fields("place_serv").Value & "::")

        '					'Insert the correct frequency code - 4/7/04 TMK
        '					Select Case medset.Fields("rebilled").Value
        '						Case "V" 'voids
        '							Print(fnum, "8")
        '						Case "A" 'adjustments
        '							Print(fnum, "7")
        '						Case Else 'originals
        '							Print(fnum, "1")
        '					End Select

        '					Print(fnum, "*Y*C*Y*Y*C~")

        '					Print(fnum, "DTP*454*D8*" & VB6.Format(medset.Fields("from_date").Value, "yyyymmdd") & "~")

        '					'If-statement changed 4/7/04 - TMK
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					If Len(Trim(medset.Fields("ftcnl_num").Value & "")) And Index >= 4 Then
        '						Print(fnum, "REF*F8*" & Left(medset.Fields("ftcnl_num").Value & spaces, 10) & "~")
        '						segmentCount = segmentCount + 1
        '					End If

        '					If Len(Trim(medset.Fields("refp_num").Value & "")) > 0 Then
        '						Print(fnum, "REF*9F*" & medset.Fields("refp_num").Value & "~")
        '						segmentCount = segmentCount + 1
        '					End If

        '					If Len(Trim(medset.Fields("prior_auth").Value & "")) > 0 Then 'added 10/31/03 TMK
        '						Print(fnum, "REF*G1*" & medset.Fields("prior_auth").Value & "~")
        '						segmentCount = segmentCount + 1
        '					End If

        '					Response = InStr(medset.Fields("prim_Diag").Value & "", ".")
        '					If Response = 0 Then
        '						msg = medset.Fields("prim_Diag").Value & ""
        '					Else
        '						msg = Left(medset.Fields("prim_Diag").Value, 3) & Mid(medset.Fields("prim_Diag").Value, Response + 1)
        '					End If

        '					If (Trim(msg) <> "" And Trim(msg) <> "00000") Then
        '						Print(fnum, "HI*BK:" & Trim(msg))

        '						Response = InStr(medset.Fields("secnd_Diag").Value & "", ".")
        '						If Response = 0 Then
        '							msg = medset.Fields("secnd_Diag").Value & ""
        '						Else
        '							msg = Left(medset.Fields("secnd_Diag").Value, 3) & Mid(medset.Fields("secnd_Diag").Value, Response + 1)
        '						End If

        '						If (Trim(msg) <> "" And Trim(msg) <> "00000") Then Print(fnum, "*BF:" & Trim(msg))

        '						Print(fnum, "~")
        '						segmentCount = segmentCount + 1
        '					End If

        '					'add referring provider name only if refp_num exists - 10/31/03 TMK
        '					If Len(Trim(medset.Fields("refp_num").Value & "")) > 0 Then
        '						If Len(Trim(medset.Fields("refp_name").Value & "")) > 0 Then
        '							Print(fnum, "NM1*DN*")
        '							'commented out medcc check 4/23/04 TMK
        '							'Set tmpdb = OpenDatabase(mm_data_path & "med.mdb")
        '							'Set medcc = tmpdb.OpenRecordset("medcc", dbOpenDynaset)
        '							'sqlstmnt = "name_key = " & Chr(34) & medset.Fields("name_key") & Chr(34)

        '							'medcc.FindFirst sqlstmnt

        '							'If medcc.RecordCount > 0 Then
        '							'No longer use medcc.mon as entity check.  Assume refp_name is formatted correctly - TMK 1/14/04

        '							If InStr(medset.Fields("refp_name").Value, ",") = 0 Then
        '								Print(fnum, "2*" & medset.Fields("refp_name").Value & "*****24*" & medset.Fields("refp_num").Value & "~")
        '							Else
        '								Print(fnum, "1*")
        '								Response = InStr(medset.Fields("refp_name").Value, ",")
        '								Print(fnum, Left(medset.Fields("refp_name").Value, Response - 1) & "*")
        '								Print(fnum, Mid(medset.Fields("refp_name").Value, Response + 2) & "****24*" & medset.Fields("refp_num").Value & "~")
        '							End If
        '							'Else
        '							'    MsgBox ("Could not find Consumer #: " & medset.Fields("name_key") & " in medcc.")
        '							'End If
        '						End If
        '						segmentCount = segmentCount + 1
        '					End If

        '					tmpConName = tmpset.Fields("name_key").Value
        '					segmentCount = segmentCount + 9
        '					HLID = HLID + 1
        '					serviceCount = 1
        '					'End If     commented 1/28/04 TMK
        '					' -----------------------------------------------

        '				Case "K"


        '					' ------------------ HIPAA ---------------------- 4/8 tmk
        '					Print(fnum, "LX*" & serviceCount & "~")

        '					Print(fnum, "SV1*HC:" & medset.Fields("proc_code").Value)
        '					If (Trim(medset.Fields("proc_code_m").Value) & "" <> "") Then Print(fnum, ":" & medset.Fields("proc_code_m").Value) 'added Trim() 10/9/03 - TMK
        '					Print(fnum, "*" & medset.Fields("dol_billed").Value & "*UN*" & medset.Fields("att_units").Value)
        '					If Len(Trim(medset.Fields("treat_ind").Value)) <> 0 Then
        '						Print(fnum, "***" & medset.Fields("treat_ind").Value)
        '						If (medset.Fields("fam_plan").Value = "1") Then Print(fnum, "*****Y")
        '					Else
        '						If Len(Trim(medset.Fields("prim_diag").Value)) <> 0 And Not (InStr(medset.Fields("prim_diag").Value, "000") > 0) Then
        '							msg = ""
        '							Print(fnum, "***1")
        '						Else
        '							msg = "***"
        '						End If
        '						If (medset.Fields("fam_plan").Value = "1") Then Print(fnum, msg & "*****Y")
        '					End If

        '					Print(fnum, "~")

        '					Print(fnum, "DTP*472*")
        '					If (medset.Fields("from_Date").Value = medset.Fields("to_Date").Value) Then
        '						Print(fnum, "D8*" & VB6.Format(medset.Fields("from_Date").Value, "yyyymmdd") & "~")
        '					Else
        '						Print(fnum, "RD8*" & VB6.Format(medset.Fields("from_Date").Value, "yyyymmdd"))
        '						Print(fnum, "-" & VB6.Format(medset.Fields("to_Date").Value, "yyyymmdd") & "~")
        '					End If

        '					segmentCount = segmentCount + 3
        '					serviceCount = serviceCount + 1
        '					' -----------------------------------------------

        '				Case Else

        '			End Select
        '			medset.MoveNext()
        '		Loop 

        '		' ------------------ HIPAA ---------------------- 4/8 tmk
        '		medset.MovePrevious()
        '		Print(fnum, "SE*" & segmentCount & "*0001~")
        '		Print(fnum, "GE*1*" & Left(controlID, 3) & "~")
        '		PrintLine(fnum, "IEA*1*" & controlID & "~")
        '		' -----------------------------------------------

        '		FileClose(fnum)

        '		'new call for writing to C: 2/1/06 lhw

        '		Call copy_ascii(outputfilename_b)
        '		medset.MoveLast()
        '		MsgBox("Billing Complete.  Please remove the floppy disk if used and label it with Processor or Provider Name, Number, Bill Date, and '837P'")
        '		'cp change
        '		'    Call copy_ascii_c(outputfilename_b)
        '		'     medset.MoveLast
        '		'   MsgBox ("Billing Complete.  Please find the file on C:\ and upload to MassHealth's Web.")

        '		valid_YN = "Y"
        '		'     Screen.MousePointer = vbDefault

        '	End Sub
        '	Public Sub prepare_medopn_tmp_bill()
        '		meddb = DAODBEngine_definst.OpenDatabase(am1_Data_path & "med_top.mdb")
        '		sqlstmnt = " select distinct proc_num from medopn_bill "
        '		medset = meddb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        '		On Error Resume Next
        '		medset.MoveLast()
        '		If Err.Number <> 0 Then
        '			MsgBox("No records to process")
        '			Exit Sub
        '		End If
        '		On Error GoTo 0

        '		If medset.RecordCount > 1 Then

        '			MsgBox("You will need " & medset.RecordCount & " floppies for processing multiple files.")
        '			'we now need to put different processors into different batch files
        '			'create array of proc nums and amount to be added to batch
        '			medset.MoveFirst()
        '			num = 0
        '			Do While Not medset.EOF
        '				proc(num, 0) = medset.Fields("proc_num").Value
        '				num = num + 1
        '				medset.MoveNext()
        '			Loop 
        '			proc(num, 0) = ""
        '		Else
        '			proc(0, 0) = medset.Fields("proc_num").Value
        '			proc(1, 0) = ""
        '		End If 'end of recordcount > 1



        '		For num = 0 To 100 'do not need to start with zero since no need to add to the batch
        '			If Len(Trim(proc(num, 0))) = 0 Then Exit For
        '			sqlstmnt = " select * from medopn_bill where proc_num = " & Chr(34) & proc(num, 0) & Chr(34)
        '			medset = meddb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        '			medset.MoveFirst()
        '			Do While Not medset.EOF
        '				medset.Edit()
        '				medset.Fields("batch_num").Value = medset.Fields("batch_num").Value + num
        '				medset.Update()
        '				medset.MoveNext()
        '			Loop 

        '		Next 
        '		'this change made to v4 to fix void adjustments 4/28/04
        '		'added "rebilled DESC" in the sort order to ensure Voids precede Replacements - 4/13/04 TMK
        '		sqlstmnt = "select * from medopn_bill order by proc_num, prov_num, name_key, place_serv, prior_auth, from_date, rebilled DESC "
        '		medset = meddb.OpenRecordset(sqlstmnt)
        '		med1set = meddb.OpenRecordset("medopn_bill")

        '		temp_proc_num = ""
        '		temp_prov_num = ""
        '		temp_name_key = ""
        '		temp_prior_auth = ""
        '		temp_refp_num = "" 'added 1/28/04 TMK
        '		temp_fiscal_year = 0
        '		test_fiscal_year = 0
        '		k_counter = 1
        '		b_counter = 1


        '		Do While Not medset.EOF
        '			'check the medicaid number first
        '			valid_YN = "N"
        '			Call ets_chk_med_num(medset.Fields("med_num"), retstring, valid_YN)
        '			If valid_YN = "N" Then
        '				MsgBox("Invalid Med number for " & medset.Fields("screen_nam").Value)
        '				Exit Sub
        '			End If

        '			If temp_proc_num <> medset.Fields("proc_num").Value Then
        '				'check if first if not then trailer record
        '				If temp_proc_num <> "" Then
        '					'write the l record between batches
        '					medset.MovePrevious() 'to get the right batch number etc
        '					Call write_one_Rec("L")

        '					temp_prov_num = "" 'maybe should be below after rec m written
        '					'write the m record
        '					Call write_one_Rec("M")

        '					temp_prov_num = ""
        '					medset.MoveNext()
        '					temp_proc_num = medset.Fields("proc_num").Value
        '				End If

        '				'write the g record
        '				'this works for multiple processors in one file the floppies will separate
        '				Call write_one_Rec("G")
        '				temp_proc_num = medset.Fields("proc_num").Value
        '			End If

        '			If temp_prov_num <> medset.Fields("prov_num").Value Then
        '				If temp_prov_num <> "" Then
        '					'write the l record
        '					Call write_one_Rec("L")
        '				End If
        '				'write the h record
        '				temp_prov_num = medset.Fields("prov_num").Value
        '				Call write_one_Rec("H")
        '			End If

        '			'for one on one j records - including Voids (4/28/04 TMK)
        '			If (medset.Fields("rebilled").Value = "A" Or medset.Fields("rebilled").Value = "R" Or medset.Fields("rebilled").Value = "V") Then
        '				GoTo writej
        '			End If

        '			'this picks up the changes
        '			If temp_name_key = medset.Fields("name_key").Value Then

        '				'added this to get a second J record for change of place of service
        '				'06/23/05 lhw
        '				If temp_place_serv <> medset.Fields("place_serv").Value Then
        '					GoTo writej
        '				Else

        '					'If temp_clin_name_key = medset.Fields("clin_name_key") Then
        '					If temp_prior_auth = medset.Fields("prior_auth").Value Then
        '						Call calc_fiscal_year(medset.Fields("from_date"), test_fiscal_year)
        '						If temp_fiscal_year = test_fiscal_year Then
        '							If temp_refp_num = medset.Fields("refp_num").Value Then 'added 1/28/04 TMK

        '								'If medset.Fields("rebilled") <> "A" Then     'for one on one j records
        '								'If medset.Fields("rebilled") <> "R" Then
        '								'If (medset.Fields("rebilled") <> "A" Or medset.Fields("rebilled") <> "R") Then
        '								GoTo nototalingmed
        '								'End If
        '								'End If
        '								'End If
        '							End If
        '						End If
        '					End If
        '				End If
        '			End If 'added
        '			'so need to total

        '			'If temp_name_key <> "" Then
        '			'Call write_one_Rec("J")
        '			'End If

        'writej: 

        '			temp_name_key = medset.Fields("name_key").Value & ""
        '			temp_place_serv = medset.Fields("place_serv").Value & ""
        '			temp_prior_auth = medset.Fields("prior_auth").Value & ""
        '			Call calc_fiscal_year(medset.Fields("from_date"), test_fiscal_year)
        '			temp_fiscal_year = test_fiscal_year
        '			temp_refp_num = medset.Fields("refp_num").Value & "" 'added 4/23/04 TMK

        '			Call write_one_Rec("J")


        'nototalingmed: 

        '			GoTo newcodeway

        '			'commented out code 1/28/04 TMK
        '			'xxxxxxxxxxxx old code way to xxxxxxxxxxx
        '			'this picks up most of the changes then test for others
        '			'If temp_name_key <> medset.Fields("name_key") Then
        '			'write the j record
        '			'temp_name_key = medset.Fields("name_key")
        '			'temp_place_serv = medset.Fields("place_serv") & ""
        '			'temp_prior_auth = medset.Fields("prior_auth") & ""

        '			'If temp_name_key = "" Then temp_name_key = medset.Fields("name_key") 'for the first j record
        '			'Call write_one_Rec("J")
        '			'temp_name_key = medset.Fields("name_key")
        '			'j_flag = 1
        '			'Response = 1
        '			'End If

        '			'now test for other changes if we have not written a j record just before

        '			'also now test for rebill and adj

        '			'If medset.Fields("rebilled") = "A" Or medset.Fields("rebilled") = "R" Then
        '			'If Response <> 1 Then
        '			'Call write_one_Rec("J")
        '			'Response = 0
        '			'End If
        '			'End If

        '			'     If j_flag <> 1 Then
        '			'If Response <> 1 Then
        '			'For num = 0 To 16
        '			'num1 = num + 4      '7
        '			'hold(num) = medset.Fields(num1).Value & ""

        '			'Next
        '			'medset.MovePrevious
        '			'if both of service and prior auth change only need one j
        '			'sort is by place, auth so will change on place after auth since auth first in fields
        '			'For num = 0 To 16
        '			'num1 = num + 4     '7
        '			'If medset(num1) & "" <> hold(num) Then
        '			'write out the correct prior_auth
        '			'If num = 0 Then
        '			'temp_prior_auth = hold(num)
        '			'End If
        '			'write out the correct place of servi
        '			'If num = 8 Then
        '			'temp_place_serv = hold(num)
        '			'End If

        '			'Call write_one_Rec("J")
        '			'Exit For
        '			'End If
        '			'Next
        '			'medset.MoveNext
        '			'End If


        '			'j_flag = 0
        '			'Response = 0

        '			'xxxxxxxxxxxxxxxx
        'newcodeway: 
        '			'write the k record but count up to 10 the another j 'also need to total this amount
        '			'since it is the current record add the amounts and move on
        '			'based on k_counter fix the line_id letter

        '			'change on 12/29/10 
        '			'if rebill or adj can only have one line so force k-counter to 10 and all set
        '			'If medset.Fields("rebilled") = "A" Or medset.Fields("rebilled") = "R" Then
        '			'k_counter = 11
        '			'End If
        '			'lhwxxxxx
        '			If k_counter = 11 Then
        '				Call write_one_Rec("J")
        '			End If

        '			msg = Mid("ABCDEFGHIJ", k_counter, 1)
        '			medset.Edit()
        '			'medset.Fields("dol_billed") = medset.Fields("att_units") * medset.Fields("usual_Fee")
        '			medset.Fields("line_num").Value = msg
        '			medset.Fields("bill_Date").Value = selected_inv_date
        '			'medset.Fields("batch_num") = bat_num
        '			medset.Fields("batch_num_line").Value = b_counter
        '			b_counter = b_counter + 1
        '			medset.Update()
        '			k_counter = k_counter + 1

        '			medset.MoveNext()

        '		Loop 

        '		'write the last l and m records
        '		medset.MoveLast()
        '		Call write_one_Rec("L")

        '		Call write_one_Rec("M")


        '		'now to go back and add up the usual fees for the total of the J record
        '		medset = meddb.OpenRecordset("select * from medopn_bill order by batch_num_line")
        '		'temp_con_name is used to add all K records into the first occurring J record for that consumer - 4/10 tmk
        '		Dim temp_con_name As String
        '		Dim JCount As Short 'count the occurences of duplicate J's
        '		JCount = 0
        '		temp_con_name = ""
        '		medset.MoveFirst()

        '		Do While Not medset.EOF

        '			If (medset.Fields("record_id").Value = "J") Then '(removed 4/15/04 TMK)And Not (medset.Fields("name_key") = temp_con_name) Then
        '				temp_con_name = medset.Fields("name_key").Value
        '				medset.MoveNext()
        '				JCount = 0
        '				tot_med = 0
        '				num1 = 1

        '				Do While medset.Fields("record_id").Value = "K"
        '					tot_med = tot_med + Val(medset.Fields("dol_billed").Value & "")
        '					num1 = num1 + 1
        '					medset.MoveNext()

        '					'skip over duplicate J's - 4/10 tmk (taken out 1/28/04 TMK
        '					'If (medset.Fields("record_id") = "J") And (medset.Fields("name_key") = temp_con_name) Then
        '					'  medset.MoveNext
        '					'  JCount = JCount + 1
        '					'End If
        '				Loop 

        '				For num = 1 To (num1 + JCount)
        '					medset.MovePrevious()
        '				Next 
        '				medset.Edit()
        '				medset.Fields("att_units").Value = num1 - 1 '# of claims
        '				medset.Fields("usual_fee").Value = tot_med
        '				medset.Update()

        '			End If
        '			medset.MoveNext()
        '		Loop 

        '		'now add js down to the l and l down to the ms
        '		'need to do it for each processor since one file
        '		Dim tot_j_num As Integer
        '		Dim tot_j_claims As Integer
        '		Dim tot_j_dol As Decimal
        '		Dim tot_l_num As Integer
        '		Dim tot_l_claims As Integer
        '		Dim tot_l_dol As Decimal

        '		tot_j_num = 0
        '		tot_j_claims = 0
        '		tot_j_dol = 0
        '		tot_l_num = 0
        '		tot_l_claims = 0
        '		tot_l_dol = 0

        '		medset.MoveFirst()
        '		num_prov = 0
        '		Do While Not medset.EOF

        '			Select Case medset.Fields("record_id").Value
        '				Case "J"
        '					'don't include Voids in submission recap - 4/7/04
        '					If medset.Fields("rebilled").Value <> "V" Then
        '						tot_j_num = tot_j_num + 1
        '						tot_j_dol = tot_j_dol + medset.Fields("usual_Fee").Value
        '						tot_j_claims = tot_j_claims + medset.Fields("att_units").Value
        '					End If
        '				Case "L"
        '					medset.Edit()
        '					medset.Fields("usual_fee").Value = tot_j_dol
        '					medset.Fields("att_units").Value = tot_j_claims
        '					medset.Fields("num_billed").Value = tot_j_num

        '					tot_l_num = tot_l_num + tot_j_num
        '					tot_l_claims = tot_l_claims + tot_j_claims
        '					tot_l_dol = tot_l_dol + tot_j_dol
        '					num_prov = num_prov + 1
        '					tot_j_num = 0
        '					tot_j_claims = 0
        '					tot_j_dol = 0
        '					medset.Update()
        '				Case "M"
        '					medset.Edit()
        '					medset.Fields("usual_fee").Value = tot_l_dol
        '					medset.Fields("att_units").Value = tot_l_claims
        '					medset.Fields("num_billed").Value = tot_l_num
        '					medset.Fields("line_num").Value = num_prov
        '					medset.Update()
        '					num_prov = 0
        '					tot_j_num = 0
        '					tot_j_claims = 0
        '					tot_j_dol = 0
        '					tot_l_num = 0
        '					tot_l_claims = 0
        '					tot_l_dol = 0

        '				Case "G", "H", "K"

        '				Case Else
        '					MsgBox("There is a bad record in medopn. Call ETS for support.")
        '			End Select

        '			medset.MoveNext()
        '		Loop 
        '		Err.Clear()

        '		'medset.MoveLast
        '		'medset.Edit
        '		'medset.Fields("usual_fee") = tot_l_dol
        '		'medset.Fields("att_units") = tot_l_claims
        '		'medset.Fields("num_billed") = tot_l_num
        '		'medset.Update

        '	End Sub

        '	Private Sub write_one_Rec(ByRef rec_id As Object)

        '		med1set.AddNew()
        '		For num = 0 To medset.Fields.Count - 1
        '			med1set.Fields(num).Value = medset.Fields(num).Value
        '		Next 
        '		If Len(Trim(temp_proc_num)) <> 0 Then
        '			med1set.Fields("proc_num").Value = temp_proc_num
        '		End If

        '		med1set.Fields("prov_num").Value = temp_prov_num
        '		med1set.Fields("att_units").Value = 0
        '		med1set.Fields("usual_fee").Value = 0
        '		med1set.Fields("dol_billed").Value = 0
        '		'UPGRADE_WARNING: Couldn't resolve default property of object rec_id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		med1set.Fields("record_id").Value = rec_id
        '		med1set.Fields("bill_Date").Value = selected_inv_date
        '		'med1set.Fields("batch_num") = bat_num
        '		med1set.Fields("batch_num_line").Value = b_counter
        '		med1set.Fields("line_num").Value = ""
        '		'UPGRADE_WARNING: Couldn't resolve default property of object rec_id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		If rec_id <> "K" Then
        '			med1set.Fields("screen_nam").Value = " "
        '			med1set.Fields("sort_name").Value = " "
        '			med1set.Fields("name_key").Value = " "
        '			med1set.Fields("proc_code").Value = " "
        '			med1set.Fields("proc_desc").Value = " "
        '		End If
        '		'UPGRADE_WARNING: Couldn't resolve default property of object rec_id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		If rec_id = "J" Then
        '			med1set.Fields("name_key").Value = temp_name_key
        '			med1set.Fields("place_serv").Value = temp_place_serv
        '			med1set.Fields("prior_auth").Value = temp_prior_auth
        '			med1set.Fields("refp_num").Value = temp_refp_num 'added 1/28/04 TMK
        '		End If
        '		'UPGRADE_WARNING: Couldn't resolve default property of object rec_id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		If rec_id = "M" Then
        '			med1set.Fields("line_num").Value = num_prov
        '		End If

        '		b_counter = b_counter + 1
        '		med1set.Update()
        '		k_counter = 1

        '	End Sub

        '	Public Sub prepare_mbhp_tmp_bill()

        '		meddb = DAODBEngine_definst.OpenDatabase(am1_Data_path & "mbhp_Top.mdb")
        '		sqlstmnt = " select distinct proc_num from mbhp_bill "
        '		medset = meddb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        '		On Error Resume Next
        '		medset.MoveLast()
        '		If Err.Number <> 0 Then
        '			MsgBox("No records to process")
        '			Exit Sub
        '		End If
        '		On Error GoTo 0

        '		If medset.RecordCount > 1 Then

        '			MsgBox("You will need " & medset.RecordCount & " floppies for processing multiple files.")
        '			'we now need to put different processors into different batch files
        '			'create array of proc nums and amount to be added to batch
        '			medset.MoveFirst()
        '			num = 0
        '			Do While Not medset.EOF
        '				proc(num, 0) = medset.Fields("proc_num").Value & ""
        '				num = num + 1
        '				medset.MoveNext()
        '			Loop 
        '			proc(num, 0) = ""
        '		Else
        '			proc(0, 0) = medset.Fields("proc_num").Value & ""
        '			proc(1, 0) = ""
        '		End If 'end of recordcount > 1



        '		For num = 0 To 100 'do not need to start with zero since no need to add to the batch
        '			If Len(Trim(proc(num, 0))) = 0 Then Exit For
        '			sqlstmnt = " select * from mbhp_bill where proc_num = " & Chr(34) & proc(num, 0) & Chr(34)
        '			medset = meddb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        '			medset.MoveFirst()
        '			Do While Not medset.EOF
        '				medset.Edit()
        '				medset.Fields("batch_num").Value = medset.Fields("batch_num").Value + num
        '				bat_num = medset.Fields("batch_num").Value
        '				medset.Update()
        '				medset.MoveNext()
        '			Loop 

        '		Next 

        '		sqlstmnt = "select * from mbhp_bill order by proc_num, prov_num, name_key, prior_auth, clin_name_key, from_date "
        '		medset = meddb.OpenRecordset(sqlstmnt)
        '		med1set = meddb.OpenRecordset("mbhp_bill")

        '		temp_proc_num = ""
        '		temp_prov_num = ""
        '		temp_name_key = ""
        '		temp_prior_auth = ""
        '		temp_tcn_num = "" 'added 3/12/04 tmk added lhw 8\11\04
        '		k_counter = 1
        '		b_counter = 1


        '		Do While Not medset.EOF

        '			If temp_proc_num <> medset.Fields("proc_num").Value Then
        '				'check if first if not then trailer record
        '				If temp_proc_num <> "" Then
        '					'write the l record between batches
        '					medset.MovePrevious() 'to get the right batch number etc
        '					Call write_one_mbrec("YA0")

        '					temp_prov_num = "" 'maybe should be below after rec m written
        '					'write the m record
        '					Call write_one_mbrec("ZA0")

        '					temp_prov_num = ""
        '					medset.MoveNext()
        '					temp_proc_num = medset.Fields("proc_num").Value
        '				End If
        '				'write the g record
        '				'this works for multiple processors in one file the floppies will separate
        '				Call write_one_mbrec("AA0")
        '				temp_proc_num = medset.Fields("proc_num").Value
        '			End If 'change in proc num

        '			If temp_prov_num <> medset.Fields("prov_num").Value Then
        '				If temp_prov_num <> "" Then
        '					'write the l record
        '					Call write_one_mbrec("YA0")
        '				End If
        '				'write the h record
        '				temp_prov_num = medset.Fields("prov_num").Value
        '				Call write_one_mbrec("BA0")

        '			End If

        '			'this picks up  the changes -   added tcn number TMK 3/12/04  lhw 8/11/04
        '			If temp_name_key = medset.Fields("name_key").Value Then
        '				If temp_clin_name_key = medset.Fields("clin_name_key").Value Then
        '					If temp_prior_auth = medset.Fields("prior_auth").Value Then
        '						If temp_tcn_num = medset.Fields("ftcnl_num").Value & "" Then 'tmk 3/30/04  lhw 8/11/04
        '							GoTo nototaling
        '						End If
        '					End If
        '				End If
        '			End If
        '			'so need to total

        '			If temp_name_key <> "" Then
        '				Call write_one_mbrec("XA0")
        '			End If

        '			temp_name_key = medset.Fields("name_key").Value & ""
        '			temp_clin_name_key = medset.Fields("clin_name_key").Value & ""
        '			temp_prior_auth = medset.Fields("prior_auth").Value & ""
        '			temp_tcn_num = medset.Fields("ftcnl_num").Value & "" 'tmk 3/14/04  lhw 8/11/04

        '			Call write_one_mbrec("CA0")
        '			Call write_one_mbrec("DA0")
        '			Call write_one_mbrec("EA0")


        'nototaling: 

        '			medset.Edit()
        '			medset.Fields("bill_Date").Value = selected_inv_date
        '			medset.Fields("batch_num").Value = bat_num
        '			medset.Fields("batch_num_line").Value = b_counter
        '			medset.Fields("seq_num").Value = k_counter
        '			b_counter = b_counter + 1
        '			medset.Update()
        '			k_counter = k_counter + 1

        '			medset.MoveNext()

        '		Loop 
        '		'write the last l and m records
        '		medset.MoveLast()

        '		Call write_one_mbrec("XA0")
        '		Call write_one_mbrec("YA0")

        '		Call write_one_mbrec("ZA0")

        '		Dim X(12) As Object
        '		Dim Y(12) As Object
        '		Dim z(12) As Object

        '		'now to go back and add up the line charges and record counts
        '		medset = meddb.OpenRecordset("select * from mbhp_bill order by batch_num_line")
        '		medset.MoveFirst()
        '		Do While Not medset.EOF
        '			Select Case medset.Fields("record_id").Value

        '				Case "AA0"
        '					'no totaling
        '				Case "BA0"
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					z(6) = 1 'for the whole batch
        '				Case "CA0"
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					X(4) = X(4) + 1 'field 4 in x count of c records
        '				Case "DA0", "DA1"
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					X(5) = X(5) + 1 'field 5 in x count of d records
        '				Case "EA0"
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					X(6) = X(6) + 1 'field 6 in x count of e records
        '				Case "FA0"
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(7). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					X(7) = X(7) + 1 'field 7 in x count of f records
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(12). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					X(12) = X(12) + medset.Fields("usual_fee").Value 'field 12 in x sum of line charges of f records
        '				Case "XA0"
        '					'move to the x record
        '					medset.Edit()
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					medset.Fields("c_count").Value = X(4)
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					medset.Fields("d_count").Value = X(5)
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					medset.Fields("e_count").Value = X(6)
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(7). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					medset.Fields("f_count").Value = X(7)
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(7). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					medset.Fields("t_count").Value = X(4) + X(5) + X(6) + X(7) + 1 'add in for the x record
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(12). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					medset.Fields("usual_fee").Value = X(12)
        '					medset.Update()
        '					'add to y array
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(7). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(8). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					Y(8) = Y(8) + X(7)
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(7). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(9). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					Y(9) = Y(9) + X(4) + X(5) + X(6) + X(7) + 1 'add in for the x record
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(10). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					Y(10) = Y(10) + X(4)
        '					'UPGRADE_WARNING: Couldn't resolve default property of object X(12). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(11). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					Y(11) = Y(11) + X(12)
        '					'clear x array
        '					For num = 0 To 12
        '						'UPGRADE_WARNING: Couldn't resolve default property of object X(num). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '						X(num) = 0
        '					Next 

        '				Case "YA0"
        '					'move to the y record
        '					medset.Edit()
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(8). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					medset.Fields("f_count").Value = Y(8)
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					medset.Fields("t_count").Value = Y(9) + 1 'to reflect this record
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(10). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					medset.Fields("c_count").Value = Y(10)
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(11). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					medset.Fields("usual_Fee").Value = Y(11)
        '					medset.Update()
        '					'add to z array
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(8). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					z(5) = z(5) + Y(8)
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(9). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					z(6) = z(6) + Y(9) + 1 'to reflect this record
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(10). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(7). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					z(7) = z(7) + Y(10)
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(8). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					z(8) = z(8) + 1
        '					'UPGRADE_WARNING: Couldn't resolve default property of object Y(11). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(9). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					z(9) = z(9) + Y(11)
        '					'clear array
        '					For num = 0 To 12
        '						'UPGRADE_WARNING: Couldn't resolve default property of object Y(num). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '						Y(num) = 0
        '					Next 

        '				Case "ZA0"
        '					'move to the z record
        '					medset.Edit()
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(5). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					medset.Fields("f_count").Value = z(5)
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(6). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					medset.Fields("t_count").Value = z(6)
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(7). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					medset.Fields("c_count").Value = z(7)
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(8). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					medset.Fields("d_count").Value = z(8)
        '					'UPGRADE_WARNING: Couldn't resolve default property of object z(9). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '					medset.Fields("usual_Fee").Value = z(9)
        '					medset.Update()
        '					'clear array
        '					For num = 0 To 12
        '						'UPGRADE_WARNING: Couldn't resolve default property of object z(num). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '						z(num) = 0
        '					Next 

        '			End Select

        '			medset.MoveNext()

        '		Loop 

        '	End Sub

        '	Private Sub parse_mbhp_diag_code(ByRef tmpmsg As Object)
        '		'This function puts the treatment indicators into HIPAA format - TMK 9/3/03

        '		Select Case Len(tmpmsg)
        '			Case 1
        '				'no parsing necessary
        '			Case 3
        '				'UPGRADE_WARNING: Couldn't resolve default property of object tmpmsg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				msg = Left(tmpmsg, 1) & ":" & Right(tmpmsg, 1)
        '			Case 5
        '				'UPGRADE_WARNING: Couldn't resolve default property of object tmpmsg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				msg = Left(tmpmsg, 1) & ":" & Mid(tmpmsg, 3, 1) & ":" & Right(tmpmsg, 1)
        '			Case 7
        '				'UPGRADE_WARNING: Couldn't resolve default property of object tmpmsg. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				msg = Left(tmpmsg, 1) & ":" & Mid(tmpmsg, 3, 1) & ":" & Mid(tmpmsg, 5, 1) & ":" & Right(tmpmsg, 1)
        '			Case Else
        '				MsgBox("Error parsing treatment indicator(s).")
        '		End Select

        '	End Sub

        '	Private Sub parse_clinician_name(ByRef name As Object)
        '		'This function puts the clinician's name into HIPAA format - TMK 9/4/03

        '		Dim last As String
        '		'UPGRADE_WARNING: Couldn't resolve default property of object name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		msg = name

        '		'UPGRADE_WARNING: Couldn't resolve default property of object name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		Response = InStr(name, ",")
        '		If Response = 0 Then
        '			'UPGRADE_WARNING: Couldn't resolve default property of object name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			Response = InStr(name, " ")
        '			'UPGRADE_WARNING: Couldn't resolve default property of object name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			last = Mid(name, Response + 1)
        '			'UPGRADE_WARNING: Couldn't resolve default property of object name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			msg = Trim(last) & "*" & Trim(Left(name, Response - 1))
        '		Else
        '			'UPGRADE_WARNING: Couldn't resolve default property of object name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			last = Left(name, Response - 1)

        '			'UPGRADE_WARNING: Couldn't resolve default property of object name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			name = Mid(name, Response + 1)
        '			'UPGRADE_WARNING: Couldn't resolve default property of object name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			Response = InStr(name, ",")
        '			If Response = 0 Then
        '				'UPGRADE_WARNING: Couldn't resolve default property of object name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				msg = Trim(last) & "*" & Trim(name)
        '			Else
        '				'UPGRADE_WARNING: Couldn't resolve default property of object name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '				msg = last & "*" & Trim(Left(name, Response - 1))
        '			End If
        '		End If

        '	End Sub


        '	'***************** changed for HIPAA compliancy ************************
        '	'************************** TMK 9/2/03 *********************************

        '	'!! NOTE: The submitter ID and password are customized for JRI !!

        '	Public Sub mbhp_write(ByRef temp_proc_num As Object, ByRef Index As Object)
        '		' Screen.MousePointer = vbHourglass

        '		meddb = DAODBEngine_definst.OpenDatabase(am1_Data_path & "mbhp_top.mdb")

        '		'UPGRADE_WARNING: Couldn't resolve default property of object temp_proc_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		sqlstmnt = "Select * from mbhp_bill where proc_num = " & Chr(34) & temp_proc_num & Chr(34) & " order by batch_num_line "
        '		medset = meddb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        '		outputfilename_b = am1_Data_path & "submissions\"
        '		outputfilename_b = outputfilename_b & "mbhp" & medset.Fields("batch_num").Value & ".asc"
        '		fnum = FreeFile
        '		FileOpen(fnum, outputfilename_b, OpenMode.Output, , , 1)

        '		Dim mednumdb As dao.Database
        '		'UPGRADE_WARNING: Arrays in structure mednum may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        '		Dim mednum As dao.Recordset
        '		db = am1_Data_path & "med_prov.mdb"

        '		Dim tmpwk As dao.Workspace
        '		tmpwk = DAODBEngine_definst.Workspaces(0)
        '		mednumdb = tmpwk.OpenDatabase(db, False, False, "MS Access;PWD=ETS1")
        '		mednum = mednumdb.OpenRecordset("med_nums", dao.RecordsetTypeEnum.dbOpenDynaset)

        '		namaddrdb = DAODBEngine_definst.OpenDatabase(am1_Data_path & "glname.mdb")
        '		namaddrset = namaddrdb.OpenRecordset("nam_addr", dao.RecordsetTypeEnum.dbOpenDynaset)

        '		db = att_data_path & "aratt.mdb"
        '		Dim prov_tax_id As String

        '		dptdb = DAODBEngine_definst.OpenDatabase(db)
        '		dptset = dptdb.OpenRecordset("cc_Cont", dao.RecordsetTypeEnum.dbOpenDynaset)

        '		prov_tax_id = ""
        '		Do While Not dptset.EOF
        '			If Left(dptset.Fields("contract_key").Value, 6) = "MAMBHP" Then
        '				prov_tax_id = dptset.Fields("pnum_Sdr").Value
        '				Exit Do
        '			End If
        '			dptset.MoveNext()
        '		Loop 

        '		If Len(prov_tax_id) = 0 Then
        '			prov_tax_id = "999999999"
        '		End If

        '		' ------------------ HIPAA ----------------------

        '		Dim tmpProcName As String 'This is for HIPAA to compare proc. name to prov. name
        '		Dim tmpConName As String 'This is to eliminate duplicate 'J' records
        '		Dim tmpPriorAuth As String 'Holds the prior authorization number
        '		Dim tmpRefProvID As String 'Holds the referring provider id number
        '		Dim tmpRendProv As String 'Holds the rendering provider id number
        '		Dim HLID As Short 'Counter for hierarchical levels
        '		Dim parentHLID As Short 'Indicates which provider the consumers are referencing
        '		Dim serviceCount As Short 'Counter for the service/procedure loop
        '		Dim segmentCount As Integer 'Counter for the number of segments or '~'s
        '		Dim controlID As String 'Holds the batch number for the header/trailer tags
        '		Dim ProcString As String 'Holds the processor information in case of multiple providers
        '		Dim ProcAddress As String 'This is used for the consumer address if there is none
        '		Dim claimTotal As Object 'The total dollars billed per claim


        '		controlID = Left(medset.Fields("batch_num").Value & medset.Fields("proc_num").Value, 9)
        '		Print(fnum, "ISA")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object temp_proc_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		Print(fnum, "*03*" & Left(temp_proc_num & spaces, 10) & "*01*" & Left(temp_proc_num & "3" & spaces, 10) & "*ZZ*") 'the added "3" makes up their password - TMK 9/5/03
        '		'UPGRADE_WARNING: Couldn't resolve default property of object temp_proc_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		Print(fnum, Left(temp_proc_num & spaces, 15) & "*")
        '		Print(fnum, "ZZ*FHC &Affiliates*")
        '		Print(fnum, VB6.Format(Now, "yymmdd") & "*")
        '		Print(fnum, VB6.Format(Now, "hhmm") & "*")
        '		Print(fnum, "U*00401*" & controlID & "*0*P*:~")

        '		Print(fnum, "GS")
        '		Print(fnum, "*HC*")
        '		'UPGRADE_WARNING: Couldn't resolve default property of object temp_proc_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		Print(fnum, temp_proc_num & "*")
        '		Print(fnum, "DMA7384*")
        '		Print(fnum, VB6.Format(Now, "yyyymmdd") & "*")
        '		Print(fnum, VB6.Format(Now, "hhmm") & "*" & Left(controlID, 3) & "*X*004010X098A1~")

        '		segmentCount = 0

        '		Print(fnum, "ST*837*0001~")
        '		Print(fnum, "BHT*0019*00*")
        '		Print(fnum, Left(controlID, 3) & "*")
        '		Print(fnum, VB6.Format(Now, "yyyymmdd") & "*")
        '		Print(fnum, VB6.Format(Now, "hhmm") & "*CH~")
        '		Print(fnum, "REF*87*004010X098A1~")

        '		segmentCount = segmentCount + 4 'count the SE segment here

        '		HLID = 1
        '		tmpConName = ""
        '		ProcString = ""
        '		ProcAddress = ""
        '		serviceCount = 1
        '		'UPGRADE_WARNING: Couldn't resolve default property of object claimTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		claimTotal = 0


        '		Do While Not medset.EOF

        '			Select Case medset.Fields("record_id").Value

        '				Case "AA0"
        '					sqlstmnt = " med_num = " & Chr(34) & medset.Fields("proc_num").Value & Chr(34)
        '					mednum.FindFirst(sqlstmnt)

        '					If mednum.NoMatch Then
        '						MsgBox("Bad processor number.")
        '						FileClose(fnum)
        '						Exit Sub
        '					End If

        '					sqlstmnt = " name_key = " & Chr(34) & mednum.Fields("name_key").Value & Chr(34)
        '					namaddrset.FindFirst(sqlstmnt)

        '					If namaddrset.NoMatch Then
        '						MsgBox("Bad processor number in glname.")
        '						FileClose(fnum)
        '						Exit Sub
        '					End If

        '					Print(fnum, "NM1")
        '					Print(fnum, "*41*2*" & namaddrset.Fields("screen_nam").Value & "*****46*")
        '					Print(fnum, mednum.Fields("med_num").Value & "~")
        '					Print(fnum, "PER*IC*" & namaddrset.Fields("email").Value & "*TE*")
        '					msg = ""
        '					msg = Mid(namaddrset.Fields("telephone").Value, 2, 3) & Mid(namaddrset.Fields("telephone").Value, 7, 3) & Mid(namaddrset.Fields("telephone").Value, 11, 4)
        '					Print(fnum, msg & "~")

        '					Print(fnum, "NM1*40*2*ValueOptions, Inc.*****46*FHC &Affiliates~")

        '					ProcString = ProcString & "NM1"
        '					ProcString = ProcString & "*85*2*" & namaddrset.Fields("screen_nam").Value & "*****24*" & mednum.Fields("med_num").Value & "~"

        '					ProcString = ProcString & "N3*" & namaddrset.Fields("address1").Value & "~"
        '					ProcAddress = ProcAddress & "N3*" & namaddrset.Fields("address1").Value & "~"
        '					ProcString = ProcString & "N4*" & namaddrset.Fields("city").Value & "*" & namaddrset.Fields("state").Value
        '					ProcAddress = ProcAddress & "N4*" & namaddrset.Fields("city").Value & "*" & namaddrset.Fields("state").Value
        '					ProcString = ProcString & "*" & Left(Trim(namaddrset.Fields("zip4").Value) & zeroes, 5) & "~" 'changed from Right() to Left() TMK
        '					ProcAddress = ProcAddress & "*" & Left(Trim(namaddrset.Fields("zip4").Value) & zeroes, 5) & "~"

        '					ProcString = ProcString & "REF*LU*" & mednum.Fields("med_num").Value & "~"

        '					segmentCount = segmentCount + 3
        '					tmpProcName = ""
        '					tmpProcName = namaddrset.Fields("screen_nam").Value


        '				Case "BA0"
        '					sqlstmnt = " med_num = " & Chr(34) & medset.Fields("prov_num").Value & Chr(34)
        '					mednum.FindFirst(sqlstmnt)

        '					If mednum.NoMatch Then
        '						MsgBox("Bad provider number = " & medset.Fields("prov_num").Value)
        '						FileClose(fnum)
        '						Exit Sub
        '					End If

        '					sqlstmnt = " name_key = " & Chr(34) & mednum.Fields("name_key").Value & Chr(34)
        '					namaddrset.FindFirst(sqlstmnt)

        '					If namaddrset.NoMatch Then
        '						MsgBox("Bad processor number in glname.")
        '						FileClose(fnum)
        '						Exit Sub
        '					End If

        '					Print(fnum, "HL*" & HLID & "**20*1~")
        '					parentHLID = HLID

        '					If (namaddrset.Fields("screen_nam").Value = tmpProcName) Then
        '						Print(fnum, "PRV*BI*ZZ*" & mednum.Fields("med_num").Value & "~")
        '						Print(fnum, ProcString)
        '						segmentCount = segmentCount + 6
        '					Else
        '						ProcAddress = ""
        '						Print(fnum, "PRV*PT*ZZ*" & mednum.Fields("med_num").Value & "~")
        '						Print(fnum, ProcString)

        '						Print(fnum, "NM1")
        '						Print(fnum, "*87*2*" & namaddrset.Fields("screen_nam").Value & "*****24*" & mednum.Fields("med_num").Value & "~")

        '						Print(fnum, "N3*" & namaddrset.Fields("address1").Value & "~")
        '						ProcAddress = ProcAddress & "N3*" & namaddrset.Fields("address1").Value & "~"
        '						Print(fnum, "N4*" & namaddrset.Fields("city").Value & "*" & namaddrset.Fields("state").Value)
        '						ProcAddress = ProcAddress & "N4*" & namaddrset.Fields("city").Value & "*" & namaddrset.Fields("state").Value
        '						Print(fnum, "*" & Left(Trim(namaddrset.Fields("zip4").Value) & zeroes, 5) & "~") 'changed from Right() to Left() TMK
        '						ProcAddress = ProcAddress & "*" & Left(Trim(namaddrset.Fields("zip4").Value) & zeroes, 5) & "~" & Chr(13)

        '						Print(fnum, "REF*LU*" & mednum.Fields("med_num").Value & "~")

        '						segmentCount = segmentCount + 10
        '					End If

        '					HLID = HLID + 1


        '				Case "CA0"

        '					tmpset = meddb.OpenRecordset("mbhp_tmp", dao.RecordsetTypeEnum.dbOpenDynaset)
        '					tmpset.FindFirst("name_key = " & Chr(34) & medset.Fields("name_key").Value & Chr(34))

        '					If Not (tmpset.Fields("name_key").Value = tmpConName) Then
        '						Print(fnum, "HL*" & HLID & "*" & parentHLID & "*22*0~")
        '						Print(fnum, "SBR*P*18*******MC~")
        '						Print(fnum, "NM1")
        '						Print(fnum, "*IL*1*" & tmpset.Fields("last_name").Value & "*" & tmpset.Fields("first_name").Value & "*")
        '						If (tmpset.Fields("middle_ini").Value >= "A") And (tmpset.Fields("middle_ini").Value <= "Z") Then Print(fnum, tmpset.Fields("middle_ini").Value)
        '						Print(fnum, "***MI*" & tmpset.Fields("insured_id").Value & "~")

        '						Print(fnum, ProcAddress)
        '						Print(fnum, "DMG*D8*" & VB6.Format(medset.Fields("dob").Value, "yyyymmdd") & "*" & UCase(medset.Fields("sex").Value) & "~")
        '						Print(fnum, "NM1*PR*2*ValueOptions, Inc.*****PI*FHC &Affiliates~")

        '						'Claim Information
        '						Print(fnum, "CLM*" & medset.Fields("name_key").Value & "*")

        '						'Get the total claim dollar amount - TMK 9/5/03
        '						sqlstmnt = "Select * from mbhp_bill where record_id = " & Chr(34) & "XA0" & Chr(34) & " AND name_key = " & Chr(34) & medset.Fields("name_key").Value & Chr(34)
        '						tmp1set = meddb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        '						tmp1set.MoveFirst()
        '						'UPGRADE_WARNING: Couldn't resolve default property of object claimTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '						claimTotal = 0
        '						Do While Not tmp1set.EOF
        '							'UPGRADE_WARNING: Couldn't resolve default property of object claimTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '							claimTotal = claimTotal + tmp1set.Fields("usual_fee").Value
        '							tmp1set.MoveNext()
        '						Loop 
        '						'UPGRADE_WARNING: Couldn't resolve default property of object claimTotal. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '						Print(fnum, claimTotal & "***")

        '						Print(fnum, medset.Fields("place_serv").Value & "::")

        '						'UPGRADE_WARNING: Couldn't resolve default property of object Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '						If (Index = 4) Or (Index = 5) Then
        '							Print(fnum, "6") 'rebills
        '							'UPGRADE_WARNING: Couldn't resolve default property of object Index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '						ElseIf (Index = 2) Or (Index = 3) Then 
        '							Print(fnum, "7") 'adjustments (replacements)
        '						Else
        '							Print(fnum, "1") 'originals
        '						End If
        '						Print(fnum, "*Y*C*Y*Y*C~")

        '						Print(fnum, "DTP*454*D8*" & VB6.Format(medset.Fields("from_date").Value, "yyyymmdd") & "~")

        '						'PA write moved here 1/26/04 TMK
        '						If (Len(Trim(medset.Fields("prior_Auth").Value)) <> 0) Then
        '							Print(fnum, "REF*G1*" & medset.Fields("prior_Auth").Value & "~")
        '							tmpPriorAuth = Trim(medset.Fields("prior_Auth").Value)
        '							segmentCount = segmentCount + 1
        '						End If

        '						If Not IsDbNull(medset.Fields("ftcnl_num").Value) Then
        '                            Print(fnum, "REF*F8*" & Left(medset.Fields("ftcnl_num").Value & spaces, 10) & "~")
        '                            segmentCount = segmentCount + 1
        '                        End If

        '					End If


        '				Case "DA0"

        '					'PA information written in CAO - 1/26/04 TMK

        '				Case "EA0"

        '					If Not (tmpset.Fields("name_key").Value = tmpConName) Then
        '						Call remove_period_dsm_code(medset.Fields("prim_diag"), msg)
        '						If (Trim(msg) <> "") Then
        '							Print(fnum, "HI*BK:" & Trim(msg))

        '							Call remove_period_dsm_code(medset.Fields("secnd_diag"), msg)
        '							If (Trim(msg) <> "" And Trim(msg) <> "00000") Then Print(fnum, "*BF:" & Trim(msg))

        '							Call remove_period_dsm_code(medset.Fields("third_diag"), msg)
        '							If (Trim(msg) <> "" And Trim(msg) <> "00000") Then Print(fnum, "*BF:" & Trim(msg))

        '							Call remove_period_dsm_code(medset.Fields("fourth_diag"), msg)
        '							If (Trim(msg) <> "" And Trim(msg) <> "00000") Then Print(fnum, "*BF:" & Trim(msg))

        '							Print(fnum, "~")
        '							segmentCount = segmentCount + 1
        '						End If

        '						'Referring Provider
        '						Print(fnum, "NM1*DN*1*" & Trim(medset.Fields("refp_last").Value) & "*")
        '						Print(fnum, Trim(medset.Fields("refp_first").Value) & "*" & Trim(medset.Fields("refp_mi").Value) & "***")
        '						Print(fnum, "24*" & medset.Fields("refp_id_num").Value & "~")
        '						tmpRefProvID = medset.Fields("refp_id_num").Value

        '						'Rendering Provider
        '						Call parse_clinician_name(medset.Fields("clin_sig"))
        '						Print(fnum, "NM1*82*1*" & msg & "****24*" & medset.Fields("clinician_num").Value & "~")
        '						Print(fnum, "REF*G2*" & medset.Fields("clinician_num").Value & "~") 'changed back to clin_num 12/17/03 TMK
        '						tmpRendProv = medset.Fields("clin_sig").Value

        '						tmpConName = tmpset.Fields("name_key").Value
        '						segmentCount = segmentCount + 12 'add the segments from CAO and DAO as well - TMK 9/3/03
        '						HLID = HLID + 1
        '						serviceCount = 1
        '					End If

        '				Case "FA0"

        '					Print(fnum, "LX*" & serviceCount & "~")

        '					Print(fnum, "SV1*HC:" & medset.Fields("mbproc_code").Value)
        '					If (Len(Trim(medset.Fields("mbproc_code_mod").Value & "")) > 0) Then Print(fnum, ":" & medset.Fields("mbproc_code_mod").Value)
        '					Print(fnum, "*" & medset.Fields("usual_fee").Value & "*UN*" & medset.Fields("units").Value)
        '					Print(fnum, "***")

        '					msg = ""
        '					parse_mbhp_diag_code((medset.Fields("diag_code").Value)) 'replace the commas with colons
        '					If Len(Trim(msg)) = 0 Then
        '						Print(fnum, "1")
        '					Else
        '						Print(fnum, msg)
        '					End If
        '					msg = ""
        '					If (medset.Fields("emg").Value = "1") Then
        '						msg = "**Y"
        '					Else
        '						msg = "**"
        '					End If
        '					If (medset.Fields("fam_plan").Value = "1") Then
        '						msg = msg & "***Y"
        '					Else
        '						If msg = "**" Then msg = ""
        '					End If

        '					Print(fnum, msg & "~")
        '					msg = ""

        '					Print(fnum, "DTP*472*")
        '					If (medset.Fields("from_Date").Value = medset.Fields("to_Date").Value) Then
        '						Print(fnum, "D8*" & VB6.Format(medset.Fields("from_Date").Value, "yyyymmdd") & "~")
        '					Else
        '						Print(fnum, "RD8*" & VB6.Format(medset.Fields("from_Date").Value, "yyyymmdd"))
        '						Print(fnum, "-" & VB6.Format(medset.Fields("to_Date").Value, "yyyymmdd") & "~")
        '					End If

        '					If medset.Fields("prior_Auth").Value <> tmpPriorAuth Then
        '						Print(fnum, "REF*G1*" & medset.Fields("prior_Auth").Value & "~")
        '						segmentCount = segmentCount + 1
        '					End If

        '					'Referring Provider
        '					If medset.Fields("refp_id_num").Value <> tmpRefProvID Then
        '						Print(fnum, "NM1*DN*1*" & medset.Fields("refp_last").Value & "*")
        '						Print(fnum, medset.Fields("refp_first").Value & "*" & medset.Fields("refp_mi").Value & "***")
        '						Print(fnum, "24*" & medset.Fields("refp_id_num").Value & "~")
        '						segmentCount = segmentCount + 1
        '					End If

        '					'Rendering Provider
        '					If medset.Fields("clin_sig").Value <> tmpRendProv Then
        '						Call parse_clinician_name(medset.Fields("clin_sig"))
        '						Print(fnum, "NM1*82*1*" & msg & "****24*" & medset.Fields("clinician_num").Value & "~")
        '						Print(fnum, "REF*G2*" & medset.Fields("clinician_num").Value & "~") 'changed 12/17/03 TMK
        '						segmentCount = segmentCount + 2 'increased to +2 11/24/03
        '					End If

        '					segmentCount = segmentCount + 3
        '					serviceCount = serviceCount + 1

        '			End Select

        '			medset.MoveNext()

        '		Loop 

        '		' ------------------ HIPAA ----------------------
        '		medset.MovePrevious()
        '		Print(fnum, "SE*" & segmentCount & "*0001~")
        '		Print(fnum, "GE*1*" & Left(controlID, 3) & "~")
        '		Print(fnum, "IEA*1*" & controlID & "~")
        '		' -----------------------------------------------

        '		FileClose(fnum)
        '		Call copy_ascii(outputfilename_b)

        '		medset.MoveLast()
        '		MsgBox("Please remove the floppy disk and label it with batch #  = " & medset.Fields("batch_num").Value)

        '		valid_YN = "Y"

        '	End Sub

        '	Public Sub remove_period_dsm_code(ByRef full_Code As Object, ByRef mod_code As Object)
        '		'UPGRADE_WARNING: Couldn't resolve default property of object full_Code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		Response = InStr(full_Code & "", ".")
        '		If Response = 0 Then
        '			'UPGRADE_WARNING: Couldn't resolve default property of object full_Code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object mod_code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			mod_code = full_Code & ""
        '		Else
        '			'UPGRADE_WARNING: Couldn't resolve default property of object full_Code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			'UPGRADE_WARNING: Couldn't resolve default property of object mod_code. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '			mod_code = Left(full_Code, Response - 1) & Mid(full_Code, Response + 1)
        '		End If

        '	End Sub

        '	Public Sub write_one_mbrec(ByRef rec_id As Object)


        '		med1set.AddNew()
        '		For num = 0 To medset.Fields.Count - 1
        '			med1set.Fields(num).Value = medset.Fields(num).Value
        '		Next 
        '		If Len(Trim(temp_proc_num)) <> 0 Then
        '			med1set.Fields("proc_num").Value = temp_proc_num
        '		End If

        '		med1set.Fields("prov_num").Value = temp_prov_num
        '		med1set.Fields("units").Value = 0
        '		med1set.Fields("usual_fee").Value = 0
        '		med1set.Fields("dol_billed").Value = 0
        '		'UPGRADE_WARNING: Couldn't resolve default property of object rec_id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		med1set.Fields("record_id").Value = rec_id
        '		med1set.Fields("bill_Date").Value = selected_inv_date
        '		' med1set.Fields("batch_num") = bat_num
        '		med1set.Fields("batch_num_line").Value = b_counter
        '		'    med1set.Fields("line_num") = ""
        '		'UPGRADE_WARNING: Couldn't resolve default property of object rec_id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		If rec_id <> "FA0" Then
        '			'    med1set.Fields("screen_nam") = " "
        '			med1set.Fields("sort_name").Value = " "
        '			med1set.Fields("name_key").Value = " "
        '			med1set.Fields("mbproc_code").Value = " "
        '			med1set.Fields("mbproc_desc").Value = " "
        '			med1set.Fields("last_name").Value = " "
        '			med1set.Fields("first_name").Value = " "
        '			med1set.Fields("middle_ini").Value = " "
        '		End If
        '		'UPGRADE_WARNING: Couldn't resolve default property of object rec_id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		If rec_id = "CA0" Then
        '			med1set.Fields("name_key").Value = temp_name_key
        '			med1set.Fields("clin_name_key").Value = temp_clin_name_key
        '			med1set.Fields("prior_auth").Value = temp_prior_auth
        '			med1set.Fields("ftcnl_num").Value = temp_tcn_num 'tmk 3/12/04 lhw 8/11/04
        '		End If
        '		'UPGRADE_WARNING: Couldn't resolve default property of object rec_id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		If rec_id = "DA0" Then
        '			med1set.Fields("name_key").Value = temp_name_key
        '			med1set.Fields("clin_name_key").Value = temp_clin_name_key
        '			med1set.Fields("prior_auth").Value = temp_prior_auth
        '			med1set.Fields("ftcnl_num").Value = temp_tcn_num 'tmk 3/12/04 lhw 8/11/04
        '		End If
        '		'UPGRADE_WARNING: Couldn't resolve default property of object rec_id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		If rec_id = "EA0" Then
        '			med1set.Fields("name_key").Value = temp_name_key
        '			med1set.Fields("clin_name_key").Value = temp_clin_name_key
        '			med1set.Fields("prior_auth").Value = temp_prior_auth
        '			med1set.Fields("ftcnl_num").Value = temp_tcn_num 'tmk 3/12/04 lhw 8/11/04
        '		End If
        '		'UPGRADE_WARNING: Couldn't resolve default property of object rec_id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		If rec_id = "XA0" Then
        '			med1set.Fields("name_key").Value = temp_name_key
        '			med1set.Fields("clin_name_key").Value = temp_clin_name_key
        '			med1set.Fields("prior_auth").Value = temp_prior_auth
        '			med1set.Fields("ftcnl_num").Value = temp_tcn_num 'tmk 3/12/04 lhw 8/11/04
        '		End If
        '		'UPGRADE_WARNING: Couldn't resolve default property of object rec_id. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '		If rec_id = "ZA0" Then
        '			'    med1set.Fields("line_num") = num_prov
        '		End If
        '		b_counter = b_counter + 1
        '		med1set.Update()

        '		k_counter = 1
    End Sub
End Module