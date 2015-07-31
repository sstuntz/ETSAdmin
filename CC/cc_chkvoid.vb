Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports System.String

Public Class cc_chkvoid
    Inherits System.Windows.Forms.Form

    Public rowvalue, colvalue As Object
    Public sqlstmnt1 As String
    Public a As String
    Public VoidPayCheck As ccckstubData


    Public Sub reverse_je()

        'where code goes in future
        '1 collect all data from job,ccdeduct,cc_ckstub and move to je_tmp
        '2  zero je tmp
        '3 test je tmp for bad account numbers and in balance
        '4 print report from je_tmp separate command1
        '5 write je from je tmp to yrgenled - separate object write_je

        'we set up eededuct as temp so we can do a findfirst
        'db = cc_data_path & "cc.mdb"
        'tmpdb = DAODBEngine_definst.OpenDatabase(db)
        'tmpset = tmpdb.OpenRecordset("cc_deduct", dao.RecordsetTypeEnum.dbOpenDynaset)

        ''2 we need to clear the temp je table before doing anything
        'je_tmp.Refresh()
        ''UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.RecordCount. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'If je_tmp.Recordset.RecordCount <> 0 Then
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.MoveFirst()
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Do While Not je_tmp.Recordset.EOF
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.delete. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        je_tmp.Recordset.delete()
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        je_tmp.Recordset.MoveNext()
        '    Loop
        'End If

        'For num = 0 To 8
        '    tots(num) = 0
        'Next
        'Dim saved_Date As Date

        'saved_Date = Today 'checkset.Fields("chk_Date")

        'checkset.MoveFirst()

        'Do While Not checkset.EOF
        '    tots(0) = tots(0) + checkset.Fields("fed_tax").Value + checkset.Fields("add_fwt").Value
        '    tots(1) = tots(1) + checkset.Fields("fica_tax").Value * 2
        '    tots(2) = tots(2) + checkset.Fields("med_tax").Value * 2
        '    tots(3) = tots(3) + checkset.Fields("net_pay").Value
        '    tots(4) = tots(4) + checkset.Fields("state1_tax").Value + checkset.Fields("add_swt").Value
        '    tots(5) = tots(5) + checkset.Fields("state2_tax").Value
        '    ' tots(6) = tots(6) + checkset.Fields("save1_Ded")
        '    ' tots(7) = tots(7) + checkset.Fields("save2_ded")
        '    ' tots(8) = tots(8) + checkset.Fields("save3_ded")

        '    'read the fields to see if there is an amount then write those that have

        '    For num = 42 To 53 Step 2
        '        If checkset.Fields(num).Value <> 0 Then 'only put in if Dol <> 0
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.AddNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            je_tmp.Recordset.AddNew()
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            je_tmp.Recordset.Fields("ded_num") = checkset.Fields(num + 1).Value & ""
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            je_tmp.Recordset.Fields("dept_num") = checkset.Fields("dept_num").Value & ""
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            je_tmp.Recordset.Fields("dol_amt") = checkset.Fields(num).Value
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            je_tmp.Recordset.Fields("chk_Date") = saved_Date
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            je_tmp.Recordset.Update()
        '        End If
        '    Next



        '    checkset.MoveNext()
        'Loop

        ''move the taxes and net for the proper totalling
        'Dim deds(5) As String
        'deds(0) = "9991"
        'deds(1) = "9992"
        'deds(2) = "9993"
        'deds(3) = "9999"
        'deds(4) = "9970"
        'deds(5) = "9971"
        '' deds(6) = "9994"
        '' deds(7) = "9995"
        '' deds(8) = "9996"

        'On Error GoTo 0
        'For num = 0 To 5 '8
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.AddNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.AddNew()
        '    'get the right deduction number
        '    'tmpset.FindFirst sqlstmnt
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.Fields("ded_num") = deds(num) 'tmpset.Fields("cr_pref_Ac")
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.Fields("dol_amt") = tots(num)
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.Fields("chk_Date") = saved_Date
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.Update()
        'Next

        'On Error GoTo 0 ' other part of fica/med
        'For num = 4 To 5
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.AddNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.AddNew()
        '    'get the right deduction number
        '    'tmpset.FindFirst sqlstmnt
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.Fields("ded_num") = deds(num) 'tmpset.Fields("cr_acct_nu")
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.Fields("dol_amt") = tots(num)
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.Fields("chk_Date") = saved_Date
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.Update()
        'Next
        ''now get the account numbers for the j/e from eededuct
        'je_tmp.Refresh()
        ''UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'je_tmp.Recordset.MoveFirst()

        ''UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not je_tmp.Recordset.EOF
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    sqlstmnt = "ded_num = " & Chr(34) & je_tmp.Recordset.Fields("ded_num") & Chr(34)
        '    tmpset.FindFirst(sqlstmnt)
        '    If tmpset.NoMatch Then
        '        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        MsgBox("Invalid deduction number = " & je_tmp.Recordset.Fields("ded_num"))
        '        Exit Sub
        '    Else
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.edit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        je_tmp.Recordset.edit()
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        je_tmp.Recordset.Fields("acct_num") = tmpset.Fields("cr_acct_nu").Value & ""
        '        'now we adjust the acct number for the dept
        '        ' If tmpset.Fields("ded_type") = "NT" Then
        '        'je_tmp.Recordset.Fields("acct_num") = Left$(je_tmp.Recordset.Fields("acct_num"), 8) & je_tmp.Recordset.Fields("dept_num")
        '        'End If
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        je_tmp.Recordset.Update()
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        je_tmp.Recordset.MoveNext()
        '    End If
        'Loop

        ''the totals are done now to create the je with acct nums

        'checkset.MoveFirst()

        'On Error Resume Next
        ''UPGRADE_NOTE: Object tmpset may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        'tmpset = Nothing

        'sqlstmnt = "select * from cctime where chk_num = " & checkset.Fields("chk_num").Value
        'sqlstmnt = sqlstmnt & " order by job_num "
        'tmpset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

        'tmp1db = DAODBEngine_definst.OpenDatabase(db)
        'tmp1set = tmp1db.OpenRecordset("ccjob", dao.RecordsetTypeEnum.dbOpenDynaset)

        ''set the payper dollars to zero
        ''tmp1set.Refresh
        'tmp1set.MoveFirst()
        'Do While Not tmp1set.EOF
        '    tmp1set.edit()
        '    tmp1set.Fields("dol_pd_ytd").Value = 0
        '    tmp1set.Fields("hrs_ytd").Value = 0
        '    tmp1set.Fields("payper_dol").Value = 0
        '    tmp1set.Fields("payper_hrs").Value = 0
        '    tmp1set.Fields("payper_pcs").Value = 0
        '    tmp1set.Fields("pcs_ytd").Value = 0

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

        'Do While Not tmpset.EOF
        '    tmp1set.FindFirst("job_num = " & Chr(34) & tmpset.Fields("job_num").Value & Chr(34))
        '    If tmp1set.NoMatch Then
        '    Else
        '        tmp1set.edit()
        '        tmp1set.Fields("hrs_ytd").Value = tmp1set.Fields("hrs_ytd").Value + tmpset.Fields("hours").Value
        '        tmp1set.Fields("pcs_ytd").Value = tmp1set.Fields("pcs_ytd").Value + tmpset.Fields("pcs_prod").Value
        '        tmp1set.Fields("dol_pd_ytd").Value = tmp1set.Fields("dol_pd_ytd").Value + tmpset.Fields("pay_Dol").Value
        '        'check if the right payroll

        '        '   If Val(tmpset.Fields("pay_num")) >= CStr(beg_pay_num) And Val(tmpset.Fields("pay_num")) <= CStr(last_pay_num) Then
        '        tmp1set.Fields("payper_hrs").Value = tmp1set.Fields("payper_hrs").Value + tmpset.Fields("hours").Value
        '        tmp1set.Fields("payper_pcs").Value = tmp1set.Fields("payper_pcs").Value + tmpset.Fields("pcs_prod").Value
        '        tmp1set.Fields("payper_dol").Value = tmp1set.Fields("payper_dol").Value + tmpset.Fields("pay_Dol").Value
        '        '  End If
        '        tmp1set.Update()
        '    End If

        '    tmpset.MoveNext()
        'Loop



        ''now we read ccjob to get the gross pay expense amounts
        'sqlstmnt = "select * from ccjob order by dr_acct_nu"
        ''UPGRADE_ISSUE: Data property ccjob.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'ccjob.RecordSource = sqlstmnt
        'ccjob.Refresh()
        ''UPGRADE_ISSUE: Data property ccjob.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object ccjob.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'ccjob.Recordset.MoveFirst()
        ''UPGRADE_ISSUE: Data property ccjob.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object ccjob.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not ccjob.Recordset.EOF

        '    'UPGRADE_ISSUE: Data property ccjob.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object ccjob.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    If ccjob.Recordset.Fields("payper_dol") <> 0 Then
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.AddNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        je_tmp.Recordset.AddNew()
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        'UPGRADE_ISSUE: Data property ccjob.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object ccjob.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        je_tmp.Recordset.Fields("acct_num") = ccjob.Recordset.Fields("dr_acct_nu") & ""
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        'UPGRADE_ISSUE: Data property ccjob.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object ccjob.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        je_tmp.Recordset.Fields("dol_amt") = ccjob.Recordset.Fields("payper_dol") * -1
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        je_tmp.Recordset.Fields("chk_Date") = saved_Date
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        je_tmp.Recordset.Update()
        '    End If

        '    'UPGRADE_ISSUE: Data property ccjob.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object ccjob.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    ccjob.Recordset.MoveNext()
        'Loop


        '' 3   now test the total to make sure it is zero and check acct numbers
        ''   tots(0) = 0
        'Response = 0
        'je_tmp.Refresh()
        ''UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'je_tmp.Recordset.MoveFirst()

        ''now the final test of account numbers and dollar amount

        ''UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not je_tmp.Recordset.EOF
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    tots(0) = tots(0) + je_tmp.Recordset.Fields("dol_amt")
        '    valid_acct = "N"
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    Call chk_acct_num_only(je_tmp.Recordset.Fields("acct_num"), valid_acct)
        '    If valid_acct = "N" Then

        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        MsgBox("You have an invalid account number = " & je_tmp.Recordset.Fields("acct_num"))
        '        Response = 1
        '    End If

        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.MoveNext()
        'Loop
        '' MsgBox "total = " & tots(0)
        'If tots(0) <> 0 Then 'plug amount to largest $ amount
        '    ' Response = 1
        '    'UPGRADE_ISSUE: Data property je_tmp.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    je_tmp.RecordSource = "select * from je_tmp order by dol_Amt desc"
        '    je_tmp.Refresh()
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.MoveFirst()
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.edit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.edit()
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.Fields("dol_amt") = je_tmp.Recordset.Fields("dol_amt") - tots(0)
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.Update()
        'End If

        'If Response = 1 Then
        '    'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '    Exit Sub
        'End If

        ''this pushes je_Tmp to yrgenled
        ''off to write the j/e
        'On Error GoTo 0

        ''UPGRADE_ISSUE: Data property je_tmp.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'je_tmp.RecordSource = "select * from je_tmp order by acct_num"
        'je_tmp.Refresh()
        ''UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'je_tmp.Recordset.MoveFirst()
        ''UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'saved_Date = je_tmp.Recordset.Fields("chk_Date")
        'tots(0) = 0
        'num = 0
        ''UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'num = je_tmp.Recordset.Fields("acct_num")

        'Data1.Refresh()
        'MsgBox("Note the number assigned to this Journal Entry:" & Val(Text1.Text) + 1)

        ''UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        ''UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'Do While Not je_tmp.Recordset.EOF
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    If num = je_tmp.Recordset.Fields("acct_num") Then
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        tots(0) = tots(0) + je_tmp.Recordset.Fields("dol_Amt")
        '    Else
        '        If tots(0) <> 0 Then
        '            'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.AddNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            yrgenled.Recordset.AddNew()
        '            num = num + 1
        '            'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            yrgenled.Recordset.Fields("jrnl_num") = Val(Text1.Text) + 1
        '            'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            yrgenled.Recordset.Fields("jrnl_line") = num
        '            'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            yrgenled.Recordset.Fields("entry_type") = "SD"
        '            'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            yrgenled.Recordset.Fields("jrnl_name") = "PR"
        '            'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            yrgenled.Recordset.Fields("jrnl_src") = "PR"
        '            'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            yrgenled.Recordset.Fields("acct_num") = num
        '            'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            yrgenled.Recordset.Fields("amount") = tots(0)
        '            'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            yrgenled.Recordset.Fields("jrnl_desc") = "CK# = " & checkset.Fields("chk_num").Value
        '            'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            yrgenled.Recordset.Fields("oper_id") = "Auto"
        '            'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            yrgenled.Recordset.Fields("encum_Date") = je_tmp.Recordset.Fields("chk_Date")
        '            On Error Resume Next
        '            'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '            'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '            yrgenled.Recordset.Update()

        '            On Error GoTo 0

        '        End If

        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        tots(0) = je_tmp.Recordset.Fields("dol_Amt")
        '        'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '        a = je_tmp.Recordset.Fields("acct_num")
        '    End If
        '    'UPGRADE_ISSUE: Data property je_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object je_tmp.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    je_tmp.Recordset.MoveNext()
        'Loop
        ''write out the last record if the amount <> 0
        'If tots(0) <> 0 Then
        '    'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.AddNew. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    yrgenled.Recordset.AddNew()
        '    num = num + 1
        '    'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    yrgenled.Recordset.Fields("jrnl_num") = Val(Text1.Text) + 1
        '    'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    yrgenled.Recordset.Fields("jrnl_line") = num
        '    'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    yrgenled.Recordset.Fields("entry_type") = "SD"
        '    'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    yrgenled.Recordset.Fields("jrnl_name") = "PR"
        '    'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    yrgenled.Recordset.Fields("jrnl_src") = "PR"
        '    'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    yrgenled.Recordset.Fields("acct_num") = a
        '    'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    yrgenled.Recordset.Fields("amount") = tots(0)
        '    'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    yrgenled.Recordset.Fields("jrnl_desc") = "CK# = " & checkset.Fields("chk_num").Value
        '    'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    yrgenled.Recordset.Fields("oper_id") = "Auto"
        '    'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    yrgenled.Recordset.Fields("encum_Date") = saved_Date
        '    'UPGRADE_ISSUE: Data property yrgenled.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    'UPGRADE_WARNING: Couldn't resolve default property of object yrgenled.Recordset.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '    yrgenled.Recordset.Update()
        'End If

        'MsgBox("You are about to print a report.  Make sure your printer is online.")
        'prtDestination = 0
        'prtreportfilename = CShort(cc_report_path & "ccpyjrnlv.rpt")
        'CrystalForm.showdialog

        'Dim hwndPreviewWindow As Integer

        '' Get handle for preview window (should be the active window, it will have been just created)
        'hwndPreviewWindow = GetActiveWindow()

        '' Keep checking that the handle is still valid - as long as it is, the Window still exists
        '' and execution is stopped

        'Do While IsWindow(hwndPreviewWindow)
        '    System.Windows.Forms.Application.DoEvents()
        'Loop
        ''UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub

    Public Sub update_tables()
        'first we set the void flag and date on the check in checkset

        sqlstmnt = "update ccckstub set void = 'Y', recon = 'Y', r_date = '" & Today & "' where chk_num = '" & chk_num.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)
        ''now to update recon
        sqlstmnt = "update ccrecon set recon = 'Y', r_date = '" & Today & "' where chk_num = '" & chk_num.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

    End Sub


    Public Sub write_neg_records()

        ''this reads the recordset collected and writes out to cctimetmp.recordset (also cctime) the negative records
        sqlstmnt = "update cctime set void = 'Y' where chk_num = '" & chk_num.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        Dim NegCCTime As List(Of cctimeData)
        sqlstmnt = "select * from cctime where chk_num = '" & chk_num.Text & "'"
        NegCCTime = ETSSQLCC.GetCCTimeData(sqlstmnt)

        For Each chk In NegCCTime
            chk.Hours = chk.Hours * -1
            chk.PayDol = chk.PayDol * -1
            chk.Paid = "Y"
            chk.Void = "Y"
            chk.EntryDate = Today

            sqlstmnt = "insert into cctime " & chk.cctimeColumnNames & " values " & chk.cctimeColumnData & ""
            ETSSQL.ExecuteSQL(sqlstmnt)
        Next

    End Sub

    Private Sub add_only_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles add_only.Click
        'the check must first be run thru a payroll properly
        'when the check has been creadted then this will allow for editing any fields.

        '    If rowvalue = "" Then
        '   MsgBox "Nothing selected"
        '  Exit Sub
        '   End If
        '
        '  msg = "Is this the check you want to edit?" & Chr(10) & "check num = " & dbgrid1.Columns(0).CellText(dbgrid1.RowBookmark(rowvalue)) _
        ''         & Chr(10) & "check date = " & dbgrid1.Columns(1).CellText(dbgrid1.RowBookmark(rowvalue)) _
        ''        & Chr(10) & "name = " & dbgrid1.Columns(5).CellText(dbgrid1.RowBookmark(rowvalue)) _
        ''       & Chr(10) & "net pay = " & Format(dbgrid1.Columns(6).CellText(dbgrid1.RowBookmark(rowvalue)), "$###,###.00")

        '    Response = MsgBox(msg, vbYesNo + vbDefaultButton2)
        '   If Response = vbNo Then
        '  Exit Sub
        ' End If

        '   selected_name_key = dbgrid1.Columns(0).CellText(dbgrid1.RowBookmark(rowvalue))
        'this shows the editor for ckeks and redo
        '  frmaddvoid.Show
        ' Unload Me


    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Close()

    End Sub
    Private Sub chk_num_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chk_num.Enter
        chk_num.Text = ""
        Call ets_set_selected()

    End Sub

    Private Sub chk_num_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles chk_num.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 0 Or KeyAscii = 13 Then

            If Len(chk_num.Text) = 0 Then
                MsgBox("Please enter a Check Number")
                Call ets_set_selected() 'puts the color in the box
                GoTo EventExitSub
            End If

            Err.Clear()

            '    db = cc_data_path & "cc.mdb"
            '    checkdb = DAODBEngine_definst.OpenDatabase(db)
            '    checkset = checkdb.OpenRecordset("ccckstub")

            '    On Error Resume Next
            '    'MsgBox "look up to see if check num is a duplicate"
            '    sqlstmnt = "select * from ccckstub where chk_num = " & chk_num.Text
            '    'following line commented out to give better error message
            '    '    sqlstmnt = sqlstmnt & " and void <> ""Y"" and recon <> ""Y"" and gl_post <> ""Y"" "
            '    checkset = checkdb.OpenRecordset(sqlstmnt)
            '    checkset.MoveFirst()



            '    If Err.Number = 3021 Then
            '        MsgBox("Not a valid Check# - Please Re-enter")
            '        Call ets_set_selected()
            '        GoTo EventExitSub

            '    Else

            '        Select Case checkset.Fields("recon").Value
            '            Case "Y"
            '                If checkset.Fields("chk_dirdep").Value = "N" Then
            '                    MsgBox("This check has been reconciled and can not be voided.")
            '                    Call ets_set_selected()
            '                    GoTo EventExitSub
            '                Else
            '                    MsgBox("This is a Direct Deposit that requires other corrections as well as this one.")
            '                End If

            '            Case "N"

            '        End Select

            '        If checkset.Fields("void").Value = "Y" Then
            '            MsgBox("This check has been voided and can not be voided again.")
            '            Call ets_set_selected()
            '            GoTo EventExitSub
            '        End If


            '        msg = "Is this the check you want to Void?" & Chr(10) & "check num = " & checkset.Fields("chk_num").Value & Chr(10) & "check date = " & checkset.Fields("chk_Date").Value & Chr(10) & "name = " & checkset.Fields("screen_nam").Value & Chr(10) & "net pay = " & VB6.Format(checkset.Fields("net_pay").Value, "$###,###.00")
            '        Response = MsgBox(msg, MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)

            '        If Response = MsgBoxResult.No Then
            '            GoTo EventExitSub
            '        End If

            '        'UPGRADE_ISSUE: Data property rpthead.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '        'UPGRADE_WARNING: Couldn't resolve default property of object rpthead.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        rpthead.Recordset.MoveFirst()
            '        'UPGRADE_ISSUE: Data property rpthead.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '        'UPGRADE_WARNING: Couldn't resolve default property of object rpthead.Recordset.edit. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        rpthead.Recordset.edit()
            '        'UPGRADE_ISSUE: Data property rpthead.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '        'UPGRADE_WARNING: Couldn't resolve default property of object rpthead.Recordset.Fields. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        rpthead.Recordset.Fields("beg_num") = checkset.Fields("chk_num").Value
            '        'UPGRADE_ISSUE: Data property rpthead.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '        'UPGRADE_WARNING: Couldn't resolve default property of object rpthead.Recordset.Update. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        rpthead.Recordset.Update()
            '        'UPGRADE_ISSUE: Data property cctimetmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '        'UPGRADE_WARNING: Couldn't resolve default property of object cctimetmp.Recordset.MoveFirst. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        cctimetmp.Recordset.MoveFirst()
            '        'UPGRADE_ISSUE: Data property cctimetmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '        'UPGRADE_WARNING: Couldn't resolve default property of object cctimetmp.Recordset.EOF. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        Do While Not cctimetmp.Recordset.EOF
            '            'UPGRADE_ISSUE: Data property cctimetmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '            'UPGRADE_WARNING: Couldn't resolve default property of object cctimetmp.Recordset.delete. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '            cctimetmp.Recordset.delete()
            '            'UPGRADE_ISSUE: Data property cctimetmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '            'UPGRADE_WARNING: Couldn't resolve default property of object cctimetmp.Recordset.MoveNext. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '            cctimetmp.Recordset.MoveNext()
            '        Loop

            '        MsgBox("Select either void or void/add.")
            '        '        Exit Sub
            '        'novoid:
            '        '   MsgBox "The check has been " & msg & Chr(13) & " This Action can not be taken."


            '    End If

        End If


EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub chk_num_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chk_num.Leave
        chk_num.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub done_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles done.Click
        Me.Close()
        'also need to clean eecktmp when done
    End Sub

    Private Sub ccchkvoid_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        ctrform(Me)

        sqlstmnt = "select  top 1 Pay_num from cctime where paid = 'Y' and void = 'N' order by pay_num desc"
        Dim HighChk As cctimeData
        HighChk = ETSSQLCC.GetOneCCTimeData("select  top 1 Pay_num from cctime where paid = 'Y' and void = 'N' order by pay_num desc")

        Pr_num1.Text = CStr(HighChk.PayNum)

        sys_Date.Text = Today.ToShortDateString

    End Sub

    Private Sub rpt_prt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles rpt_prt.Click

        MsgBox("You are about to print a report.  Make sure your printer is online.")
        prtDestination = 0
        prtreportfilename = cc_report_path & "ccvoidck.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Private Sub void_add_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_add.Click

        If Len(chk_num.Text) = 0 Then
            MsgBox("Please enter a Check Number")
            chk_num.Focus() 'puts the color in the box
            Exit Sub
        End If

        Label4.Visible = True
        Pr_num1.Visible = True

        sqlstmnt = "select * from ccckstub where chk_num = '" & chk_num.Text & "'"
        VoidPayCheck = ETSSQLCC.GetOneCCchkstubData(sqlstmnt)

        msg = "Confirm that this is the check you want to Void." & Chr(10) & "check num = " & VoidPayCheck.ChkNum & Chr(10) & "check date = " & VoidPayCheck.ChkDate & Chr(10) & "name = " & VoidPayCheck.ScreenNam & Chr(10) & "net pay = " & VoidPayCheck.NetPay
        Response = MsgBox(msg, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))

        If Response = MsgBoxResult.No Then
            Exit Sub
        End If

        'leave message if a j/e has been created

        If VoidPayCheck.GlPost = "Y" Then
            Response = MsgBox("This item has been posted to the General Ledger and will create a new Journal Entry.  Do you want to continue?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
            If Response = 7 Then
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
                '    Call reverse_je()
            End If
        End If

        Call update_tables()

        Dim NegCCTime As List(Of cctimeData)
        sqlstmnt = "select * from cctime where chk_num = '" & chk_num.Text & "'"
        NegCCTime = ETSSQLCC.GetCCTimeData(sqlstmnt)

        For Each chk In NegCCTime
            chk.Paid = "N"
            chk.Void = "N"
            chk.EntryDate = Today
            chk.PayNum = CInt(Pr_num1.Text)

            sqlstmnt = "insert into cctime " & chk.cctimeColumnNames & " values " & chk.cctimeColumnData & ""
            ETSSQL.ExecuteSQL(sqlstmnt)
        Next

        Call write_neg_records()
        chk_num.Focus()
        Call write_neg_records()

        chk_num.Focus()

    End Sub

    Private Sub void_only_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_only.Click

        If Len(chk_num.Text) = 0 Then
            MsgBox("Please enter a Check Number")
            chk_num.Focus() 'puts the color in the box
            Exit Sub
        End If

        sqlstmnt = "select * from ccckstub where chk_num = '" & chk_num.Text & "'"

        VoidPayCheck = ETSSQLCC.GetOneCCchkstubData(sqlstmnt)

        msg = "Confirm that this is the check you want to Void." & Chr(10) & "check num = " & VoidPayCheck.ChkNum & Chr(10) & "check date = " & VoidPayCheck.ChkDate & Chr(10) & "name = " & VoidPayCheck.ScreenNam & Chr(10) & "net pay = " & VoidPayCheck.NetPay
        Response = MsgBox(msg, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))

        If Response = MsgBoxResult.No Then
            Exit Sub
        End If

        'leave message if a j/e has been created

        If VoidPayCheck.GlPost = "Y" Then
            Response = MsgBox("This item has been posted to the General Ledger and will create a new Journal Entry.  Do you want to continue?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
            If Response = 7 Then
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
                '    Call reverse_je()
            End If
        End If

        Call update_tables()

        Call write_neg_records()
        chk_num.Focus()

    End Sub
End Class