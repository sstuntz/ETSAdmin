Option Strict Off
Option Explicit On

Imports System.Data.SqlClient
Imports System.Configuration
Imports PS.Common
Imports ETS.Common.Module1
Imports ETS.pr_common

Namespace ETS

    Public Class stpr_mod
        '****************
        'revision History
        'original date of this form is 8/23/96 -SCS
        'Removed the ap fucntions and put into ap_mod

        '****************

        Public sendloc As String
        Public retloc As String
        Public retlocdesc As String
        Public valid_loc As String

        Public sendslot As String
        Public retslot As String
        Public retslotdesc As String
        Public valid_slot As String

        Public sendtitle As String
        Public rettitle As String
        Public rettitledesc As String
        Public valid_title As String

        Public beg_pay_num As Integer
        Public last_pay_num As Integer

        Public new_case As String 'to fix recuring lookup on stpr_ed1.frm 9/24/2009




        Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)


        Public Sub add_ee_slot_loc(ByRef sendslot As Object, ByRef sendloc As Object, ByRef ee_num As Object)
            'this adds this employee to this slot-loc  combination

            'get sort name
            Call chkname(ee_num)
            'get ih description
            Call etslocnum_chk(sendslot, sendloc, retloc, retlocdesc, valid_loc)

            db = ee_data_path & "ee.mdb"
            'tmpdb = DAODBEngine_definst.OpenDatabase(db)
            'tmpset = tmpdb.OpenRecordset("eeslot", DAO.RecordsetTypeEnum.dbOpenDynaset)

            'tmpset.AddNew()

            ''UPGRADE_WARNING: Couldn't resolve default property of object sendslot. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'tmpset.Fields("slot_num").Value = sendslot
            ''UPGRADE_WARNING: Couldn't resolve default property of object sendloc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'tmpset.Fields("loc_num").Value = sendloc
            ''UPGRADE_WARNING: Couldn't resolve default property of object ee_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'tmpset.Fields("name_key").Value = ee_num
            'tmpset.Fields("sort_name").Value = selected_sort_name
            'tmpset.Update()

        End Sub

        Public Sub allocate_slots(ByRef beg_pay_num As Object, ByRef last_pay_num As Object)
            'the first step is to see what half the year we are in
            ' we do this by checking eeckstub and get the highest check num
            'the date of this check will determine where in the year we are
            db = ee_data_path & "ee.mdb"
            'tmpdb = DAODBEngine_definst.OpenDatabase(db)

            ''UPGRADE_WARNING: Couldn't resolve default property of object last_pay_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ''UPGRADE_WARNING: Couldn't resolve default property of object beg_pay_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'sqlstmnt = "select * from eeckstub where pay_num >= " & beg_pay_num & " and pay_num <= " & last_pay_num & " order by chk_Date"


            'tmpset = tmpdb.OpenRecordset(sqlstmnt, DAO.RecordsetTypeEnum.dbOpenDynaset)

            'On Error Resume Next 'added to trap for no records 2/12/02 lhw
            'tmpset.MoveLast()
            'If Err.Number = 3021 Then
            '    MsgBox("No records for this payroll number.")
            '    Exit Sub
            'End If
            'On Error GoTo 0

            'If function_type = "PREPARE JE" Then
            '    saved_Chk_num = 0 'this is the flag if in first half
            '    On Error Resume Next
            '    If Month(tmpset.Fields("chk_date").Value) > 6 Then
            '        Do While Month(tmpset.Fields("chk_date").Value) > 6
            '            saved_Chk_num = tmpset.Fields("chk_num").Value
            '            tmpset.MovePrevious()
            '        Loop

            '        'get the cut off check num and set the formula flag
            '    End If
            '    sqlstmnt = "select * from eework1 where chk_num >= " & saved_Chk_num & " and void <> ""Y"" and paid = ""Y"" and dflag = ""N"" order by slot_num, loc_num "

            'Else

            '    If Month(tmpset.Fields("chk_Date").Value) = 7 Then 'to control for changeover

            '        Response = MsgBox("Have you changed your allocation table for the new fiscal year? " & Chr(13) & "This message will only appear during July payroll runs.", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2)
            '        'if yes then year is blank and data from work1 inlcuding 7/1 on
            '        'if no then data from work1 before 7/1

            '        If Response = 6 Then
            '            saved_Date = CDate("6/30/" & Year(Today)) 'this is the flag if in second half
            '            sqlstmnt = "select * from eework1 where date > " & Chr(35) & saved_Date & Chr(35) & " and void <> ""Y"" and paid = ""Y"" and dflag = ""N""  "
            '            'sqlstmnt = sqlstmnt & " and pay_num <= " & Chr(34) & last_pay_num & Chr(34) & " order by slot_num, loc_num "   'prob with str comp -7/99
            '            'UPGRADE_WARNING: Couldn't resolve default property of object last_pay_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '            sqlstmnt = sqlstmnt & " and val(pay_num) <= " & last_pay_num & " order by slot_num, loc_num "
            '        Else
            '            saved_Date = CDate("7/01/" & Year(Today)) 'this is the flag if in first half
            '            sqlstmnt = "select * from eework1 where date < " & Chr(35) & saved_Date & Chr(35) & " and void <> ""Y"" and paid = ""Y"" and dflag = ""N"" "
            '            ' sqlstmnt = sqlstmnt & " and pay_num <= " & Chr(34) & last_pay_num & Chr(34) & " order by slot_num, loc_num "  'prob with str comp -7/99
            '            'UPGRADE_WARNING: Couldn't resolve default property of object last_pay_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '            sqlstmnt = sqlstmnt & " and val(pay_num) <= " & last_pay_num & " order by slot_num, loc_num "

            '        End If
            '    End If ' end of control for changeover

            '    'now we control for the other months
            '    Select Case Month(tmpset.Fields("chk_Date").Value)
            '        Case 1, 2, 3, 4, 5, 6

            '            saved_Date = CDate("7/01/" & Year(Today)) 'this is the flag if in first half
            '            sqlstmnt = "select * from eework1 where date < " & Chr(35) & saved_Date & Chr(35) & " and void <> ""Y"" and paid = ""Y"" and dflag = ""N"" "
            '            '     sqlstmnt = sqlstmnt & " and pay_num <= " & Chr(34) & last_pay_num & Chr(34) & " order by slot_num, loc_num " 'prob with str comp -7/99
            '            'UPGRADE_WARNING: Couldn't resolve default property of object last_pay_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '            sqlstmnt = sqlstmnt & " and val(pay_num) <= " & last_pay_num & " order by slot_num, loc_num "


            '        Case 8, 9, 10, 11, 12
            '            saved_Date = CDate("6/30/" & Year(Today)) 'this is the flag if in second half
            '            sqlstmnt = "select * from eework1 where date > " & Chr(35) & saved_Date & Chr(35) & " and void <> ""Y"" and paid = ""Y"" and dflag = ""N"" "
            '            '    sqlstmnt = sqlstmnt & " and pay_num <= " & Chr(34) & last_pay_num & Chr(34) & " order by slot_num, loc_num "   'prob with str comp -7/99
            '            'UPGRADE_WARNING: Couldn't resolve default property of object last_pay_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '            sqlstmnt = sqlstmnt & " and val(pay_num) <= " & last_pay_num & " order by slot_num, loc_num "


            '    End Select

            'End If

            ''go thru the process for all and then go back and do the 99's
            'On Error Resume Next
            ''Set tmpset = tmpdb.OpenRecordset("eework1", dbOpenDynaset)
            'tmpset = tmpdb.OpenRecordset(sqlstmnt, DAO.RecordsetTypeEnum.dbOpenDynaset)

            'tmp1db = DAODBEngine_definst.OpenDatabase(db)
            'tmp1set = tmp1db.OpenRecordset("eeslot1", DAO.RecordsetTypeEnum.dbOpenDynaset)

            ''set the payper dollars to zero
            ''tmp1set.Refresh
            'tmp1set.MoveFirst()
            'Do While Not tmp1set.EOF
            '    tmp1set.Edit()
            '    tmp1set.Fields("dol_pd_ytd").Value = 0
            '    tmp1set.Fields("hrs_ytd").Value = 0
            '    tmp1set.Fields("fica_ytd").Value = 0
            '    tmp1set.Fields("med_ytd").Value = 0
            '    tmp1set.Fields("payper_dol").Value = 0
            '    tmp1set.Fields("payper_hrs").Value = 0
            '    tmp1set.Fields("dfica_reg").Value = 0
            '    tmp1set.Fields("dmed_reg").Value = 0
            '    tmp1set.Fields("dfica_aloc").Value = 0
            '    tmp1set.Fields("dmed_aloc").Value = 0
            '    'If saved_Date > 0 Then
            '    ' tmp1set.Fields("dol_pyr") = 0
            '    ' tmp1set.Fields("hrs_pyr") = 0
            '    ' End If
            '    tmp1set.Update()
            '    tmp1set.MoveNext()
            'Loop

            'For num = 0 To 22
            '    tots(num) = 0
            'Next

            'tmpset.MoveFirst()
            'If Err.Number = 3021 Then
            '    MsgBox("Nothing to allocate for this pay period.")
            '    Exit Sub
            'End If

            'On Error GoTo 0
            'Dim test1 As String
            'test1 = CStr(tmpset.Fields("slot_num").Value) & CStr(tmpset.Fields("loc_num").Value)

            'Do While Not tmpset.EOF
            '    If test1 = CStr(tmpset.Fields("slot_num").Value) & CStr(tmpset.Fields("loc_num").Value) Then
            '        tots(0) = tots(0) + tmpset.Fields("hours").Value
            '        tots(1) = tots(1) + tmpset.Fields("pay_dol").Value
            '        tots(2) = tots(2) + tmpset.Fields("fica_tax").Value
            '        tots(3) = tots(3) + tmpset.Fields("med_tax").Value
            '        'now test if for this pay period range and add it to that
            '        If Val(tmpset.Fields("pay_num").Value) >= Val(CStr(beg_chk_num)) And Val(tmpset.Fields("pay_num").Value) <= Val(CStr(last_Chk_num)) Then

            '            tots(4) = tots(4) + tmpset.Fields("hours").Value
            '            tots(5) = tots(5) + tmpset.Fields("pay_dol").Value
            '            tots(6) = tots(6) + tmpset.Fields("fica_tax").Value
            '            tots(7) = tots(7) + tmpset.Fields("med_tax").Value
            '        End If
            '    Else
            '        'find the slot table record and update it

            '        sqlstmnt = "select * from eeslot1 where slot_num = " & Chr(34) & Left(test1, 4) & Chr(34) & " and loc_num = " & Chr(34) & Right(test1, 2) & Chr(34)
            '        tmp1set = tmpdb.OpenRecordset(sqlstmnt, DAO.RecordsetTypeEnum.dbOpenDynaset)
            '        On Error Resume Next

            '        tmp1set.Edit()
            '        If Err.Number = 3021 Then
            '            MsgBox("There is an invalid slot/location combination in eework1.  This combination is slot num = " & Left(test1, 4) & " and loc_num = " & Right(test1, 2))
            '            Exit Sub
            '        End If
            '        On Error GoTo 0

            '        tmp1set.Fields("dol_pd_ytd").Value = tots(1)
            '        tmp1set.Fields("hrs_ytd").Value = tots(0)
            '        tmp1set.Fields("fica_ytd").Value = tots(2)
            '        tmp1set.Fields("med_ytd").Value = tots(3)
            '        tmp1set.Fields("payper_dol").Value = tots(5)
            '        tmp1set.Fields("payper_hrs").Value = tots(4)
            '        tmp1set.Fields("dfica_reg").Value = tots(6)
            '        tmp1set.Fields("dmed_reg").Value = tots(7)
            '        tmp1set.Update()

            '        test1 = CStr(tmpset.Fields("slot_num").Value) & CStr(tmpset.Fields("loc_num").Value)
            '        For num = 0 To 22
            '            tots(num) = 0
            '        Next
            '        tots(0) = tots(0) + tmpset.Fields("hours").Value
            '        tots(1) = tots(1) + tmpset.Fields("pay_dol").Value
            '        tots(2) = tots(2) + tmpset.Fields("fica_tax").Value
            '        tots(3) = tots(3) + tmpset.Fields("med_tax").Value
            '        'now test if for this pay period range and add it to that
            '        If Val(tmpset.Fields("pay_num").Value) >= Val(CStr(beg_chk_num)) And Val(tmpset.Fields("pay_num").Value) <= Val(CStr(last_Chk_num)) Then
            '            tots(4) = tots(4) + tmpset.Fields("hours").Value
            '            tots(5) = tots(5) + tmpset.Fields("pay_dol").Value
            '            tots(6) = tots(6) + tmpset.Fields("fica_tax").Value
            '            tots(7) = tots(7) + tmpset.Fields("med_tax").Value
            '        End If

            '    End If
            '    tmpset.MoveNext()
            'Loop
            ''move in last total
            'sqlstmnt = "select * from eeslot1 where slot_num = " & Chr(34) & Left(test1, 4) & Chr(34) & " and loc_num = " & Chr(34) & Right(test1, 2) & Chr(34)
            'tmp1set = tmpdb.OpenRecordset(sqlstmnt, DAO.RecordsetTypeEnum.dbOpenDynaset)
            'tmp1set.Edit()

            'tmp1set.Fields("dol_pd_ytd").Value = tots(1)
            'tmp1set.Fields("hrs_ytd").Value = tots(0)
            'tmp1set.Fields("fica_ytd").Value = tots(2)
            'tmp1set.Fields("med_ytd").Value = tots(3)
            'tmp1set.Fields("payper_dol").Value = tots(5)
            'tmp1set.Fields("payper_hrs").Value = tots(4)
            'tmp1set.Fields("dfica_reg").Value = tots(6)
            'tmp1set.Fields("dmed_reg").Value = tots(7)
            'tmp1set.Update()

            ''now move through the slot table and get the 99's and move their $ around
            'tmp1set.Close()
            ''    tmp2set.Close


            'On Error GoTo 0

            ''UPGRADE_NOTE: Object tmp1set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'tmp1set = Nothing
            'tmp1set = tmpdb.OpenRecordset("eeslot1")
            'sqlstmnt = "select * from eeslot1 where loc_num = ""99"" order by slot_num"

            'tmp1set = tmpdb.OpenRecordset(sqlstmnt) ', dbOpenDynaset)
            ''UPGRADE_WARNING: Arrays in structure tmp2set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
            'Dim tmp2set As DAO.Recordset
            ''UPGRADE_WARNING: Arrays in structure tmp3set may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
            'Dim tmp3set As DAO.Recordset

            'On Error Resume Next 'added 2/12/02 lhwxxx
            'tmp1set.MoveFirst()
            'If Err.Number = 3021 Then 'added 2/12/02 lhw
            '    MsgBox("No 99 records to allocate. Continue with JE.")
            '    Exit Sub
            'End If
            'On Error GoTo 0
            ''create a secomd recordset to be allocated into
            'tmpdb = DAODBEngine_definst.OpenDatabase(ee_data_path & "ee.mdb")
            'tmp2set = tmpdb.OpenRecordset("eeslot1", DAO.RecordsetTypeEnum.dbOpenDynaset)
            ''On Error Resume Next
            'Do While Not tmp1set.EOF 'get the 99 level
            '    'move the dollars into tots for calculating the pennies
            '    For num = 0 To 10
            '        tots(num) = 0
            '    Next
            '    tots(0) = tmp1set.Fields("dol_pd_ytd").Value
            '    tots(1) = tmp1set.Fields("hrs_ytd").Value
            '    tots(2) = tmp1set.Fields("fica_ytd").Value
            '    tots(3) = tmp1set.Fields("med_ytd").Value
            '    tots(4) = tmp1set.Fields("payper_dol").Value
            '    tots(5) = tmp1set.Fields("payper_hrs").Value
            '    tots(6) = tmp1set.Fields("dfica_reg").Value
            '    tots(7) = tmp1set.Fields("dmed_reg").Value


            '    sqlstmnt = "select * from eealloc where slot_num = " & Chr(34) & tmp1set.Fields("slot_num").Value & Chr(34) & "order by slot_num"
            '    'Set tmp3set = tmpdb.OpenRecordset("eealloc", dbOpenDynaset)
            '    tmp3set = tmpdb.OpenRecordset(sqlstmnt, DAO.RecordsetTypeEnum.dbOpenDynaset)

            '    On Error Resume Next 'added 3021 trap 12/6/02 lhw
            '    tmp3set.MoveFirst()
            '    If Err.Number = 3021 Then
            '        MsgBox("You are missing a record in the allocation table for this slot:" & Chr(34) & tmpset.Fields("slot_num").Value)
            '        'MsgBox "This will write records, check them carefully, they may not be correct."
            '    End If
            '    On Error GoTo 0

            '    Do While Not tmp3set.EOF 'get the alloc tble
            '        sqlstmnt = "slot_num = " & Chr(34) & tmp3set.Fields("slot_num").Value & Chr(34) & "and loc_num = " & Chr(34) & tmp3set.Fields("loc_num").Value & Chr(34)
            '        tmp2set.FindFirst(sqlstmnt) 'get the first alloc out
            '        tmp2set.Edit()
            '        tmp2set.Fields("dol_pd_ytd").Value = tmp2set.Fields("dol_pd_ytd").Value + Int(tmp1set.Fields("dol_pd_ytd").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        tots(0) = tots(0) - Int(tmp1set.Fields("dol_pd_ytd").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        tmp2set.Fields("hrs_ytd").Value = tmp2set.Fields("hrs_ytd").Value + Int(tmp1set.Fields("hrs_ytd").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        tots(1) = tots(1) - Int(tmp1set.Fields("hrs_ytd").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        tmp2set.Fields("fica_ytd").Value = tmp2set.Fields("fica_ytd").Value + Int(tmp1set.Fields("fica_ytd").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        tots(2) = tots(2) - Int(tmp1set.Fields("fica_ytd").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        tmp2set.Fields("med_ytd").Value = tmp2set.Fields("med_ytd").Value + Int(tmp1set.Fields("med_ytd").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        tots(3) = tots(3) - Int(tmp1set.Fields("med_ytd").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        tmp2set.Fields("payper_dol").Value = tmp2set.Fields("payper_dol").Value + Int(tmp1set.Fields("payper_dol").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        tots(4) = tots(4) - Int(tmp1set.Fields("payper_dol").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        tmp2set.Fields("payper_hrs").Value = tmp2set.Fields("payper_hrs").Value + Int(tmp1set.Fields("payper_hrs").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        tots(5) = tots(5) - Int(tmp1set.Fields("payper_hrs").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        tmp2set.Fields("dfica_reg").Value = tmp2set.Fields("dfica_reg").Value + Int(tmp1set.Fields("dfica_reg").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        tots(6) = tots(6) - Int(tmp1set.Fields("dfica_reg").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        tmp2set.Fields("dmed_reg").Value = tmp2set.Fields("dmed_reg").Value + Int(tmp1set.Fields("dmed_reg").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        tots(7) = tots(7) - Int(tmp1set.Fields("dmed_reg").Value * tmp3set.Fields("factor").Value * 100) / 100
            '        'how to make sure that the allocation ties to the penny
            '        tmp2set.Update()
            '        tmp3set.MoveNext()
            '    Loop  'on alloc

            '    'now wwe move the pennies out to the proper accounts
            '    tmp2set.Edit()
            '    tmp2set.Fields("dol_pd_ytd").Value = tmp2set.Fields("dol_pd_ytd").Value + tots(0)
            '    tmp2set.Fields("hrs_ytd").Value = tmp2set.Fields("hrs_ytd").Value + tots(1)
            '    tmp2set.Fields("fica_ytd").Value = tmp2set.Fields("fica_ytd").Value + tots(2)
            '    tmp2set.Fields("med_ytd").Value = tmp2set.Fields("med_ytd").Value + tots(3)
            '    tmp2set.Fields("payper_dol").Value = tmp2set.Fields("payper_dol").Value + tots(4)
            '    tmp2set.Fields("payper_hrs").Value = tmp2set.Fields("payper_hrs").Value + tots(5)
            '    tmp2set.Fields("dfica_reg").Value = tmp2set.Fields("dfica_reg").Value + tots(6)
            '    tmp2set.Fields("dmed_reg").Value = tmp2set.Fields("dmed_reg").Value + tots(7)
            '    tmp2set.Update()
            '    'now zero the 99
            '    tmp1set.Edit()
            '    tmp1set.Fields("dol_pd_ytd").Value = 0
            '    tmp1set.Fields("hrs_ytd").Value = 0
            '    tmp1set.Fields("fica_ytd").Value = 0
            '    tmp1set.Fields("med_ytd").Value = 0
            '    tmp1set.Fields("payper_dol").Value = 0
            '    tmp1set.Fields("payper_hrs").Value = 0
            '    tmp1set.Fields("dfica_reg").Value = 0
            '    tmp1set.Fields("dmed_reg").Value = 0
            '    tmp1set.Update()
            '    tmp1set.MoveNext()
            'Loop  'on eeslot 1 99s

            ''add the prior fiscal to this year
            'sqlstmnt = "select * from eeslot1 "

            'tmp1set = tmpdb.OpenRecordset(sqlstmnt)
            'tmp1set.MoveFirst()
            'Do While Not tmp1set.EOF
            '    tmp1set.Edit()
            '    tmp1set.Fields("dol_pd_ytd").Value = tmp1set.Fields("dol_pd_ytd").Value + tmp1set.Fields("dol_pyr").Value
            '    tmp1set.Fields("hrs_ytd").Value = tmp1set.Fields("hrs_ytd").Value + tmp1set.Fields("hrs_pyr").Value
            '    tmp1set.Update()
            '    tmp1set.MoveNext()
            'Loop

            ''UPGRADE_NOTE: Object tmp1set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'tmp1set = Nothing
            ''UPGRADE_NOTE: Object tmp2set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'tmp2set = Nothing
            ''UPGRADE_NOTE: Object tmp3set may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            'tmp3set = Nothing

        End Sub

        Sub health_tax_create(ByRef present_quarter_num As Object)
            'find the check count and refill eehtax
            'db = ee_data_path & "ee.mdb"
            'tmpdb = DAODBEngine_definst.OpenDatabase(db)
            'tmpset = tmpdb.OpenRecordset("eehtax", DAO.RecordsetTypeEnum.dbOpenDynaset)
            'On Error Resume Next
            'tmpset.MoveFirst()
            'Do While Not tmpset.EOF
            '    tmpset.Delete()
            '    tmpset.MoveNext()
            'Loop

            'sqlstmnt = "select * from eeckstub where chk_Date >= " & Chr(35)
            'sqlstmnt = sqlstmnt & quarter_begin_Date & Chr(35) & " and chk_date <= "
            'sqlstmnt = sqlstmnt & Chr(35) & quarter_end_Date & Chr(35) & " order by name_key"

            'tmp1set = tmpdb.OpenRecordset(sqlstmnt, DAO.RecordsetTypeEnum.dbOpenDynaset)

            'Dim mth(3) As Short

            'For num = 0 To 3
            '    mth(num) = 0
            'Next

            'tmp1set.MoveFirst()
            'saved_name_key = tmp1set.Fields("name_key").Value
            'saved_screen_nam = tmp1set.Fields("screen_nam").Value

            'Do While Not tmp1set.EOF
            '    'If tmp1set.Fields("name_key") = "50464" Then Stop
            '    If saved_name_key <> tmp1set.Fields("name_key").Value Then
            '        'write out the record
            '        tmpset.AddNew()
            '        tmpset.Fields("name_key").Value = saved_name_key
            '        tmpset.Fields("Screen_nam").Value = saved_screen_nam
            '        tmpset.Fields("mnth_1").Value = mth(1)
            '        tmpset.Fields("mnth_2").Value = mth(2)
            '        tmpset.Fields("mnth_3").Value = mth(3)
            '        tmpset.Update()

            '        For num = 0 To 3
            '            mth(num) = 0
            '        Next
            '        saved_name_key = tmp1set.Fields("name_key").Value
            '        saved_screen_nam = tmp1set.Fields("screen_nam").Value
            '        'UPGRADE_WARNING: Couldn't resolve default property of object present_quarter_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        num = Month(tmp1set.Fields("chk_Date").Value) - (present_quarter_num - 1) * 3
            '        mth(num) = 1
            '    Else
            '        'change the month value
            '        'present_quarter_num is the multiplier
            '        'UPGRADE_WARNING: Couldn't resolve default property of object present_quarter_num. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        num = Month(tmp1set.Fields("chk_Date").Value) - (present_quarter_num - 1) * 3
            '        mth(num) = 1

            '    End If



            '    tmp1set.MoveNext()
            'Loop

            ''get the last record
            'tmpset.AddNew()
            'tmpset.Fields("name_key").Value = saved_name_key
            'tmpset.Fields("Screen_nam").Value = saved_screen_nam
            'tmpset.Fields("mnth_1").Value = mth(1)
            'tmpset.Fields("mnth_2").Value = mth(2)
            'tmpset.Fields("mnth_3").Value = mth(3)
            'tmpset.Update()


            ''End Sub

        End Sub

        'Public Shared Sub ytd_create(ByRef present_quarter_num As Object)
        '    'the quarter to date data is based on the check date

        '    Select Case present_quarter_num
        '        Case 1
        '            quarter_begin_Date = CDate("1/1/" & Year(Today))
        '            quarter_end_Date = CDate("3/31/" & Year(Today))
        '        Case 2
        '            quarter_begin_Date = CDate("4/1/" & Year(Today))
        '            quarter_end_Date = CDate("6/30/" & Year(Today))
        '        Case 3
        '            quarter_begin_Date = CDate("7/1/" & Year(Today))
        '            quarter_end_Date = CDate("9/30/" & Year(Today))
        '        Case 4
        '            quarter_begin_Date = CDate("10/1/" & Year(Today))
        '            quarter_end_Date = CDate("12/31/" & Year(Today))
        '        Case Else
        '            quarter_begin_Date = CDate("1/1/" & Year(Today))
        '            quarter_end_Date = CDate("12/31/" & Year(Today))

        '    End Select

        '    'db = ee_data_path & "ee.mdb"
        '    'tmpdb = DAODBEngine_definst.OpenDatabase(db)
        '    'tmpset = tmpdb.OpenRecordset("eeckstub", DAO.RecordsetTypeEnum.dbOpenDynaset)

        '    ''select all of chkstb that has been paid and add it up by employee
        '    ''this creates the ytd table for calculating max fica and things

        '    'sqlstmnt = "select * from eeckstub where void = 'N' "
        '    'sqlstmnt = sqlstmnt & " and chk_date <= " & Chr(35) & quarter_end_Date
        '    'sqlstmnt = sqlstmnt & Chr(35) & " order by name_key"
        '    'tmpset = tmpdb.OpenRecordset(sqlstmnt, DAO.RecordsetTypeEnum.dbOpenDynaset)


        '    'tmp1db = DAODBEngine_definst.OpenDatabase(db)
        '    'tmp1set = tmp1db.OpenRecordset("eeytd", DAO.RecordsetTypeEnum.dbOpenDynaset)

        '    ''added clear the ytd table here on 9/30/98
        '    'On Error Resume Next
        '    'Do While Not tmp1set.EOF
        '    '    tmp1set.Delete()
        '    '    tmp1set.MoveNext()
        '    'Loop

        '    ''code added 12/99 to skip ytd table on first check run
        '    'tmpset.MoveFirst()
        '    'If Err.Number = 3021 Then
        '    '    MsgBox("There is no year to date information.")
        '    '    Exit Sub
        '    'End If

        '    'On Error GoTo 0

        '    'Err.Clear()
        '    'For num = 0 To 22
        '    '    tots(num) = 0
        '    '    qtots(num) = 0
        '    'Next


        '    'tmpset.MoveFirst()
        '    'tots(0) = tots(0) + tmpset.Fields("a_nt_dol").Value
        '    'tots(1) = tots(1) + tmpset.Fields("b_nt_dol").Value
        '    'tots(2) = tots(2) + tmpset.Fields("c_nt_dol").Value
        '    'tots(3) = tots(3) + tmpset.Fields("d_nt_dol").Value
        '    'tots(4) = tots(4) + tmpset.Fields("e_nt_dol").Value
        '    'tots(5) = tots(5) + tmpset.Fields("flx_nt_Dol").Value
        '    'tots(6) = tots(6) + tmpset.Fields("dep_nt_dol").Value
        '    'tots(7) = tots(7) + tmpset.Fields("pen1a_dol").Value
        '    'tots(8) = tots(8) + tmpset.Fields("pen1b_dol").Value
        '    'tots(9) = tots(9) + tmpset.Fields("pen2a_dol").Value
        '    'tots(10) = tots(10) + tmpset.Fields("pen2b_dol").Value
        '    'tots(11) = tots(11) + tmpset.Fields("full_gross").Value
        '    'tots(12) = tots(12) + tmpset.Fields("fed_gross").Value
        '    'tots(13) = tots(13) + tmpset.Fields("fica_gross").Value
        '    'tots(14) = tots(14) + tmpset.Fields("med_gross").Value
        '    'tots(15) = tots(15) + tmpset.Fields("state1_gross").Value
        '    'tots(16) = tots(16) + tmpset.Fields("state2_gross").Value
        '    'tots(17) = tots(17) + tmpset.Fields("fed_tax").Value + tmpset.Fields("add_fwt").Value
        '    'tots(18) = tots(18) + tmpset.Fields("fica_tax").Value
        '    'tots(19) = tots(19) + tmpset.Fields("med_tax").Value
        '    'tots(20) = tots(20) + tmpset.Fields("state1_tax").Value + tmpset.Fields("add_swt").Value
        '    'tots(21) = tots(21) + tmpset.Fields("state2_tax").Value
        '    'tots(22) = tots(22) + tmpset.Fields("aeic_amt").Value
        '    'saved_name_key = Trim(tmpset.Fields("name_key").Value)
        '    'saved_screen_nam = tmpset.Fields("screen_nam").Value

        '    ''now check to see if in the quarter
        '    'If tmpset.Fields("chk_date").Value >= quarter_begin_Date Then
        '    '    qtots(0) = qtots(0) + tmpset.Fields("a_nt_dol").Value
        '    '    qtots(1) = qtots(1) + tmpset.Fields("b_nt_dol").Value
        '    '    qtots(2) = qtots(2) + tmpset.Fields("c_nt_dol").Value
        '    '    qtots(3) = qtots(3) + tmpset.Fields("d_nt_dol").Value
        '    '    qtots(4) = qtots(4) + tmpset.Fields("e_nt_dol").Value
        '    '    qtots(5) = qtots(5) + tmpset.Fields("flx_nt_Dol").Value
        '    '    qtots(6) = qtots(6) + tmpset.Fields("dep_nt_dol").Value
        '    '    qtots(7) = qtots(7) + tmpset.Fields("pen1a_dol").Value
        '    '    qtots(8) = qtots(8) + tmpset.Fields("pen1b_dol").Value
        '    '    qtots(9) = qtots(9) + tmpset.Fields("pen2a_dol").Value
        '    '    qtots(10) = qtots(10) + tmpset.Fields("pen2b_dol").Value
        '    '    qtots(11) = qtots(11) + tmpset.Fields("full_gross").Value
        '    '    qtots(12) = qtots(12) + tmpset.Fields("fed_gross").Value
        '    '    qtots(13) = qtots(13) + tmpset.Fields("fica_gross").Value
        '    '    qtots(14) = qtots(14) + tmpset.Fields("med_gross").Value
        '    '    qtots(15) = qtots(15) + tmpset.Fields("state1_gross").Value
        '    '    qtots(16) = qtots(16) + tmpset.Fields("state2_gross").Value
        '    '    qtots(17) = qtots(17) + tmpset.Fields("fed_tax").Value + tmpset.Fields("add_fwt").Value
        '    '    qtots(18) = qtots(18) + tmpset.Fields("fica_tax").Value
        '    '    qtots(19) = qtots(19) + tmpset.Fields("med_tax").Value
        '    '    qtots(20) = qtots(20) + tmpset.Fields("state1_tax").Value + tmpset.Fields("add_swt").Value
        '    '    qtots(21) = qtots(21) + tmpset.Fields("state2_tax").Value
        '    '    qtots(22) = qtots(22) + tmpset.Fields("aeic_amt").Value

        '    'End If

        '    'tmpset.MoveNext()

        '    'Do While Not tmpset.EOF
        '    '    'if name key does not change

        '    '    If Trim(tmpset.Fields("name_key").Value) = saved_name_key Then
        '    '        tots(0) = tots(0) + tmpset.Fields("a_nt_dol").Value
        '    '        tots(1) = tots(1) + tmpset.Fields("b_nt_dol").Value
        '    '        tots(2) = tots(2) + tmpset.Fields("c_nt_dol").Value
        '    '        tots(3) = tots(3) + tmpset.Fields("d_nt_dol").Value
        '    '        tots(4) = tots(4) + tmpset.Fields("e_nt_dol").Value
        '    '        tots(5) = tots(5) + tmpset.Fields("flx_nt_Dol").Value
        '    '        tots(6) = tots(6) + tmpset.Fields("dep_nt_dol").Value
        '    '        tots(7) = tots(7) + tmpset.Fields("pen1a_dol").Value
        '    '        tots(8) = tots(8) + tmpset.Fields("pen1b_dol").Value
        '    '        tots(9) = tots(9) + tmpset.Fields("pen2a_dol").Value
        '    '        tots(10) = tots(10) + tmpset.Fields("pen2b_dol").Value
        '    '        tots(11) = tots(11) + tmpset.Fields("full_gross").Value
        '    '        tots(12) = tots(12) + tmpset.Fields("fed_gross").Value
        '    '        tots(13) = tots(13) + tmpset.Fields("fica_gross").Value
        '    '        tots(14) = tots(14) + tmpset.Fields("med_gross").Value
        '    '        tots(15) = tots(15) + tmpset.Fields("state1_gross").Value
        '    '        tots(16) = tots(16) + tmpset.Fields("state2_gross").Value
        '    '        tots(17) = tots(17) + tmpset.Fields("fed_tax").Value + tmpset.Fields("add_fwt").Value
        '    '        tots(18) = tots(18) + tmpset.Fields("fica_tax").Value
        '    '        tots(19) = tots(19) + tmpset.Fields("med_tax").Value
        '    '        tots(20) = tots(20) + tmpset.Fields("state1_tax").Value + tmpset.Fields("add_swt").Value
        '    '        tots(21) = tots(21) + tmpset.Fields("state2_tax").Value
        '    '        tots(22) = tots(22) + tmpset.Fields("aeic_amt").Value

        '    '        'now check to see if in the quarter
        '    '        If tmpset.Fields("chk_date").Value >= quarter_begin_Date Then
        '    '            qtots(0) = qtots(0) + tmpset.Fields("a_nt_dol").Value
        '    '            qtots(1) = qtots(1) + tmpset.Fields("b_nt_dol").Value
        '    '            qtots(2) = qtots(2) + tmpset.Fields("c_nt_dol").Value
        '    '            qtots(3) = qtots(3) + tmpset.Fields("d_nt_dol").Value
        '    '            qtots(4) = qtots(4) + tmpset.Fields("e_nt_dol").Value
        '    '            qtots(5) = qtots(5) + tmpset.Fields("flx_nt_Dol").Value
        '    '            qtots(6) = qtots(6) + tmpset.Fields("dep_nt_dol").Value
        '    '            qtots(7) = qtots(7) + tmpset.Fields("pen1a_dol").Value
        '    '            qtots(8) = qtots(8) + tmpset.Fields("pen1b_dol").Value
        '    '            qtots(9) = qtots(9) + tmpset.Fields("pen2a_dol").Value
        '    '            qtots(10) = qtots(10) + tmpset.Fields("pen2b_dol").Value
        '    '            qtots(11) = qtots(11) + tmpset.Fields("full_gross").Value
        '    '            qtots(12) = qtots(12) + tmpset.Fields("fed_gross").Value
        '    '            qtots(13) = qtots(13) + tmpset.Fields("fica_gross").Value
        '    '            qtots(14) = qtots(14) + tmpset.Fields("med_gross").Value
        '    '            qtots(15) = qtots(15) + tmpset.Fields("state1_gross").Value
        '    '            qtots(16) = qtots(16) + tmpset.Fields("state2_gross").Value
        '    '            qtots(17) = qtots(17) + tmpset.Fields("fed_tax").Value + tmpset.Fields("add_fwt").Value
        '    '            qtots(18) = qtots(18) + tmpset.Fields("fica_tax").Value
        '    '            qtots(19) = qtots(19) + tmpset.Fields("med_tax").Value
        '    '            qtots(20) = qtots(20) + tmpset.Fields("state1_tax").Value + tmpset.Fields("add_swt").Value
        '    '            qtots(21) = qtots(21) + tmpset.Fields("state2_tax").Value
        '    '            qtots(22) = qtots(22) + tmpset.Fields("aeic_amt").Value

        '    '        End If

        '    '    Else
        '    '        'write out the file to the ytd
        '    '        tmp1set.AddNew()
        '    '        tmp1set.Fields("name_key").Value = saved_name_key
        '    '        tmp1set.Fields("screen_nam").Value = saved_screen_nam

        '    '        For num = 0 To 22
        '    '            tmp1set.Fields(num + 2).Value = tots(num)
        '    '            tmp1set.Fields(num + 25).Value = qtots(num)
        '    '        Next
        '    '        tmp1set.Update()

        '    '        For num = 0 To 22
        '    '            tots(num) = 0
        '    '            qtots(num) = 0
        '    '        Next

        '    '        tots(0) = tots(0) + tmpset.Fields("a_nt_dol").Value
        '    '        tots(1) = tots(1) + tmpset.Fields("b_nt_dol").Value
        '    '        tots(2) = tots(2) + tmpset.Fields("c_nt_dol").Value
        '    '        tots(3) = tots(3) + tmpset.Fields("d_nt_dol").Value
        '    '        tots(4) = tots(4) + tmpset.Fields("e_nt_dol").Value
        '    '        tots(5) = tots(5) + tmpset.Fields("flx_nt_Dol").Value
        '    '        tots(6) = tots(6) + tmpset.Fields("dep_nt_dol").Value
        '    '        tots(7) = tots(7) + tmpset.Fields("pen1a_dol").Value
        '    '        tots(8) = tots(8) + tmpset.Fields("pen1b_dol").Value
        '    '        tots(9) = tots(9) + tmpset.Fields("pen2a_dol").Value
        '    '        tots(10) = tots(10) + tmpset.Fields("pen2b_dol").Value
        '    '        tots(11) = tots(11) + tmpset.Fields("full_gross").Value
        '    '        tots(12) = tots(12) + tmpset.Fields("fed_gross").Value
        '    '        tots(13) = tots(13) + tmpset.Fields("fica_gross").Value
        '    '        tots(14) = tots(14) + tmpset.Fields("med_gross").Value
        '    '        tots(15) = tots(15) + tmpset.Fields("state1_gross").Value
        '    '        tots(16) = tots(16) + tmpset.Fields("state2_gross").Value
        '    '        tots(17) = tots(17) + tmpset.Fields("fed_tax").Value + tmpset.Fields("add_fwt").Value
        '    '        tots(18) = tots(18) + tmpset.Fields("fica_tax").Value
        '    '        tots(19) = tots(19) + tmpset.Fields("med_tax").Value
        '    '        tots(20) = tots(20) + tmpset.Fields("state1_tax").Value + tmpset.Fields("add_swt").Value
        '    '        tots(21) = tots(21) + tmpset.Fields("state2_tax").Value
        '    '        tots(22) = tots(22) + tmpset.Fields("aeic_amt").Value
        '    '        saved_name_key = Trim(tmpset.Fields("name_key").Value)
        '    '        saved_screen_nam = tmpset.Fields("screen_nam").Value

        '    '        'now check to see if in the quarter
        '    '        If tmpset.Fields("chk_date").Value >= quarter_begin_Date Then
        '    '            qtots(0) = qtots(0) + tmpset.Fields("a_nt_dol").Value
        '    '            qtots(1) = qtots(1) + tmpset.Fields("b_nt_dol").Value
        '    '            qtots(2) = qtots(2) + tmpset.Fields("c_nt_dol").Value
        '    '            qtots(3) = qtots(3) + tmpset.Fields("d_nt_dol").Value
        '    '            qtots(4) = qtots(4) + tmpset.Fields("e_nt_dol").Value
        '    '            qtots(5) = qtots(5) + tmpset.Fields("flx_nt_Dol").Value
        '    '            qtots(6) = qtots(6) + tmpset.Fields("dep_nt_dol").Value
        '    '            qtots(7) = qtots(7) + tmpset.Fields("pen1a_dol").Value
        '    '            qtots(8) = qtots(8) + tmpset.Fields("pen1b_dol").Value
        '    '            qtots(9) = qtots(9) + tmpset.Fields("pen2a_dol").Value
        '    '            qtots(10) = qtots(10) + tmpset.Fields("pen2b_dol").Value
        '    '            qtots(11) = qtots(11) + tmpset.Fields("full_gross").Value
        '    '            qtots(12) = qtots(12) + tmpset.Fields("fed_gross").Value
        '    '            qtots(13) = qtots(13) + tmpset.Fields("fica_gross").Value
        '    '            qtots(14) = qtots(14) + tmpset.Fields("med_gross").Value
        '    '            qtots(15) = qtots(15) + tmpset.Fields("state1_gross").Value
        '    '            qtots(16) = qtots(16) + tmpset.Fields("state2_gross").Value
        '    '            qtots(17) = qtots(17) + tmpset.Fields("fed_tax").Value + tmpset.Fields("add_fwt").Value
        '    '            qtots(18) = qtots(18) + tmpset.Fields("fica_tax").Value
        '    '            qtots(19) = qtots(19) + tmpset.Fields("med_tax").Value
        '    '            qtots(20) = qtots(20) + tmpset.Fields("state1_tax").Value + tmpset.Fields("add_swt").Value
        '    '            qtots(21) = qtots(21) + tmpset.Fields("state2_tax").Value
        '    '            qtots(22) = qtots(22) + tmpset.Fields("aeic_amt").Value

        '    '        End If
        '    '    End If
        '    '    tmpset.MoveNext()
        '    'Loop

        '    'tmp1set.AddNew()
        '    'tmp1set.Fields("name_key").Value = saved_name_key
        '    'tmp1set.Fields("screen_nam").Value = saved_screen_nam

        '    'For num = 0 To 22
        '    '    tmp1set.Fields(num + 2).Value = tots(num)
        '    '    tmp1set.Fields(num + 25).Value = qtots(num)
        '    'Next
        '    'tmp1set.Update()

        'End Sub

        Sub deduct_amount(ByRef a As Object, ByRef d As Object)

            'db = ee_data_path & "ee.mdb"
            'tmpdb = DAODBEngine_definst.OpenDatabase(db)
            'tmpset = tmpdb.OpenRecordset("eededuct", DAO.RecordsetTypeEnum.dbOpenDynaset)
            ''UPGRADE_WARNING: Couldn't resolve default property of object a. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'sqlstmnt = "Ded_num = " & Chr(34) & a & Chr(34)

            'tmpset.FindFirst(sqlstmnt)

            'If tmpset.NoMatch Then
            '    MsgBox("Error in deduction table. Please correct and try again.")
            'Else
            '    'UPGRADE_WARNING: Couldn't resolve default property of object d. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    d = tmpset.Fields("ded_dol").Value
            'End If

        End Sub

        Sub etsslotnum_chk(ByRef sendslot As Object, ByRef retslot As Object, ByRef retloc As Object, ByRef valid_slot As Object)

            ''UPGRADE_WARNING: Couldn't resolve default property of object sendslot. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'If sendslot = " " Or sendslot = "" Then
            '    saved_entry_type = entry_type

            '    'slotlookup.Show 1     'changed 10/25/2007 lhw

            '    'UPGRADE_WARNING: Couldn't resolve default property of object sendslot. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    sendslot = selected_slot_num
            '    'UPGRADE_WARNING: Couldn't resolve default property of object retslot. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    retslot = selected_slot_num
            '    'UPGRADE_WARNING: Couldn't resolve default property of object retloc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    retloc = selected_loc_num
            '    retslotdesc = selected_slot_ih
            '    'UPGRADE_WARNING: Couldn't resolve default property of object valid_slot. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    valid_slot = "Y"
            '    entry_type = saved_entry_type
            '    Exit Sub
            'End If

            'Dim slotdb As DAO.Database
            ''UPGRADE_WARNING: Arrays in structure slotset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
            'Dim slotset As DAO.Recordset
            'db = ee_data_path & "ee.mdb"
            'slotdb = DAODBEngine_definst.OpenDatabase(db)
            'slotset = slotdb.OpenRecordset("eeslot1", DAO.RecordsetTypeEnum.dbOpenDynaset)

            'sqlstmnt = "slot_num = "
            ''UPGRADE_WARNING: Couldn't resolve default property of object sendslot. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'sqlstmnt = sqlstmnt & Chr(34) & sendslot & Chr(34)

            'slotset.FindFirst(sqlstmnt)

            'If slotset.NoMatch Then
            '    'UPGRADE_WARNING: Couldn't resolve default property of object valid_slot. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    valid_slot = "N"
            'Else
            '    'UPGRADE_WARNING: Couldn't resolve default property of object valid_slot. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    valid_slot = "Y"
            '    'UPGRADE_WARNING: Couldn't resolve default property of object sendslot. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    'UPGRADE_WARNING: Couldn't resolve default property of object retslot. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    retslot = sendslot
            '    ' retloc = slotset("loc_num")
            '    retslotdesc = "  " 'slotset.Field("ih_desc")
            'End If

        End Sub
        Sub ets_title_chk(ByRef sendtitle As Object, ByRef rettitle As Object, ByRef rettitledesc As Object, ByRef valid_title As Object)

            'UPGRADE_WARNING: Couldn't resolve default property of object sendtitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If sendtitle = "" Then
                'saved_active_form = Screen.ActiveForm.Name
                '     saved_active_control = Screen.ActiveControl.Name
                'Screen.ActiveForm.Hide

                '  titlelookup.Show 1

                'UPGRADE_WARNING: Couldn't resolve default property of object sendtitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                sendtitle = selected_lookup_num
                'UPGRADE_WARNING: Couldn't resolve default property of object rettitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                rettitle = selected_lookup_num
                'UPGRADE_WARNING: Couldn't resolve default property of object rettitledesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                rettitledesc = selected_lookup_desc
                'UPGRADE_WARNING: Couldn't resolve default property of object valid_title. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                valid_title = "Y"
                'saved_active_form.Show
                'saved_active_control.SetFocus
                Exit Sub
            End If

            'Dim titledb As DAO.Database
            ''UPGRADE_WARNING: Arrays in structure titleset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
            'Dim titleset As DAO.Recordset
            'db = ee_data_path & "ee.mdb"
            'titledb = DAODBEngine_definst.OpenDatabase(db)
            'titleset = titledb.OpenRecordset("eejtitle", DAO.RecordsetTypeEnum.dbOpenDynaset)

            'sqlstmnt = " title_num = "
            ''UPGRADE_WARNING: Couldn't resolve default property of object sendtitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'sqlstmnt = sqlstmnt & Chr(34) & sendtitle & Chr(34)

            'titleset.FindFirst(sqlstmnt)

            'If titleset.NoMatch Then
            '    'UPGRADE_WARNING: Couldn't resolve default property of object valid_title. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    valid_title = "N"
            '    Exit Sub
            'Else
            '    'UPGRADE_WARNING: Couldn't resolve default property of object rettitledesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    rettitledesc = titleset.Fields("job_title").Value
            '    'UPGRADE_WARNING: Couldn't resolve default property of object sendtitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    'UPGRADE_WARNING: Couldn't resolve default property of object rettitle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    rettitle = sendtitle
            '    'UPGRADE_WARNING: Couldn't resolve default property of object valid_title. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    valid_title = "Y"

            'End If
        End Sub
        Sub etslocnum_chk(ByRef sendslot As Object, ByRef sendloc As Object, ByRef retloc As Object, ByRef retlocdesc As Object, ByRef valid_loc As Object)
            'you find the valid loc for the slot already selected
            'UPGRADE_WARNING: Couldn't resolve default property of object sendloc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If Len(Trim(sendloc)) = 0 Then
                'UPGRADE_WARNING: Couldn't resolve default property of object sendslot. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                selected_lookup_num = sendslot
                '  locnumlookup.Show 1

                'UPGRADE_WARNING: Couldn't resolve default property of object sendloc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                sendloc = selected_lookup_num
                'UPGRADE_WARNING: Couldn't resolve default property of object retloc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                retloc = selected_lookup_num
                'UPGRADE_WARNING: Couldn't resolve default property of object retlocdesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                retlocdesc = selected_lookup_desc
                'UPGRADE_WARNING: Couldn't resolve default property of object valid_loc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                valid_loc = "Y"
                Exit Sub
            End If

            On Error Resume Next
            'Dim locdb As DAO.Database
            ''UPGRADE_WARNING: Arrays in structure locset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
            'Dim locset As DAO.Recordset
            'db = ee_data_path & "ee.mdb"
            'locdb = DAODBEngine_definst.OpenDatabase(db)
            'locset = locdb.OpenRecordset("eeslot1", DAO.RecordsetTypeEnum.dbOpenDynaset)
            'sqlstmnt = " select * from eeslot1 where slot_num = "
            ''UPGRADE_WARNING: Couldn't resolve default property of object sendslot. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'sqlstmnt = sqlstmnt & Chr(34) & sendslot & Chr(34)
            'locset = locdb.OpenRecordset(sqlstmnt)
            'locset.MoveFirst()

            ''the following error trap finds duplicates for the add condition

            ''If Error = 3021 Then
            ''valid_loc = "N"
            ''Exit Sub
            ''End If

            'Do While Not locset.EOF
            '    If sendloc = locset.Fields("loc_num").Value Then
            '        'UPGRADE_WARNING: Couldn't resolve default property of object sendloc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        'UPGRADE_WARNING: Couldn't resolve default property of object retloc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        retloc = sendloc
            '        'UPGRADE_WARNING: Couldn't resolve default property of object retlocdesc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        retlocdesc = locset.Fields("ih_desc").Value
            '        'UPGRADE_WARNING: Couldn't resolve default property of object valid_loc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        valid_loc = "Y"
            '        Exit Sub
            '    End If
            '    locset.MoveNext()
            'Loop

        End Sub


        'UPGRADE_NOTE: loc was upgraded to loc_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Sub valid_slot_loc(ByRef slot As Object, ByRef loc_Renamed As Object, ByRef valid_YN As Object)
            ''UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'valid_YN = "N"
            'db = ee_data_path & "ee.mdb"
            'tmpdb = DAODBEngine_definst.OpenDatabase(db)
            'tmpset = tmpdb.OpenRecordset("ee_Slot1", DAO.RecordsetTypeEnum.dbOpenDynaset)

            'sqlstmnt = " slot_num = "
            ''UPGRADE_WARNING: Couldn't resolve default property of object slot. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'sqlstmnt = sqlstmnt & Chr(34) & slot & Chr(34)
            ''UPGRADE_WARNING: Couldn't resolve default property of object loc_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'sqlstmnt = sqlstmnt & " and loc_num = " & Chr(34) & loc_Renamed & Chr(34)

            'tmpset.FindFirst(sqlstmnt)

            'If tmpset.NoMatch Then
            '    'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    valid_YN = "N"
            'Else
            '    'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    valid_YN = "Y"
            'End If

        End Sub
        Public Sub ets_get_ee_slot1_rate(ByRef sendslot As Object, ByRef sendloc As Object, ByRef ratez As Object) 'added for berkshire 12/01/2002 scs
            'On Error Resume Next
            ''this gets the rate from eeslot 1 table rather than nameee

            'db = ee_data_path & "ee.mdb"
            'tmp3db = DAODBEngine_definst.OpenDatabase(db)
            'tmp3set = tmp3db.OpenRecordset("eeslot1", DAO.RecordsetTypeEnum.dbOpenDynaset)

            'sqlstmnt = " select * from eeslot1 where slot_num  = "
            ''UPGRADE_WARNING: Couldn't resolve default property of object sendslot. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'sqlstmnt = sqlstmnt & Chr(34) & Trim(sendslot) & Chr(34)
            'sqlstmnt = sqlstmnt & " and loc_num  = "
            ''UPGRADE_WARNING: Couldn't resolve default property of object sendloc. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'sqlstmnt = sqlstmnt & Chr(34) & Trim(sendloc) & Chr(34)

            'tmp3set = tmpdb.OpenRecordset(sqlstmnt)
            'tmp3set.MoveFirst()
            'On Error Resume Next
            ''UPGRADE_WARNING: Couldn't resolve default property of object ratez. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'ratez = tmp3set.Fields("rate_z").Value
            ''UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            'If Err.Number = 3265 Or IsDBNull(ratez) = True Then 'blank or null
            '    'UPGRADE_WARNING: Couldn't resolve default property of object ratez. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    ratez = 0
            'End If


        End Sub


        Sub ck_unique_key(ByRef db_path As Object, ByRef table_name As Object, ByRef field_name As Object, ByRef text_val As Object, ByRef valid_YN As Object)

            ''UPGRADE_WARNING: Couldn't resolve default property of object db_path. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'tmpdb = DAODBEngine_definst.OpenDatabase(db_path)
            ''UPGRADE_WARNING: Couldn't resolve default property of object table_name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'tmpset = tmpdb.OpenRecordset(table_name, DAO.RecordsetTypeEnum.dbOpenDynaset)
            ''UPGRADE_WARNING: Couldn't resolve default property of object text_val. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ''UPGRADE_WARNING: Couldn't resolve default property of object field_name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'sqlstmnt = field_name & " = " & Chr(34) & text_val & Chr(34)

            'tmpset.FindFirst(sqlstmnt)

            'If tmpset.NoMatch Then
            '    'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    valid_YN = "N"
            'Else
            '    'UPGRADE_WARNING: Couldn't resolve default property of object valid_YN. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '    valid_YN = "Y"
            'End If

        End Sub
    End Class
End Namespace
