Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient

Public Class att_edit_bill_type
    Inherits System.Windows.Forms.Form

    Public Sub get_attend()

        Select Case selected_grouping

            Case "CLIENT"
                sqlstmnt = "select distinct b_num, bill_type, sort_name from attend_tmp where name_key = '" & selected_name_key
                sqlstmnt = sqlstmnt & "' and att_Date between '" & selected_start_date & "' and '" & selected_end_date & "' order by sort_name"

            Case "CONTRACT"
                sqlstmnt = "select distinct b_num, bill_type, sort_name from attend_tmp where contract_key = '" & selected_contract_key
                sqlstmnt = sqlstmnt & "' and att_Date between '" & selected_start_date & "' and '" & selected_end_date & "' order by sort_name"
        End Select

        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            While rs.Read()
                Call div_b_num(rs("b_num").ToString)
                DataGridView1.Rows.Add(New String() {selected_name_key.ToString, selected_contract_key.ToString, rs("bill_type").ToString, rs("sort_name").ToString})
            End While
            rs.Close()
        End Using

        If selected_bill_type = "125" Then
            'go thru rows and get total units
            DataGridView1.SelectAll()
            For Each DGRow As DataGridViewRow In DataGridView1.SelectedRows
                sqlstmnt = "select sum(att_unit) as thevalue from attend_tmp where contract_key = '" & selected_contract_key
                sqlstmnt = sqlstmnt & "' and att_Date between '" & selected_start_date & "' and '" & selected_end_date
                sqlstmnt = sqlstmnt & "' and name_key = '" & DGRow.Cells("name_key").Value.ToString & "'"
                DGRow.Cells("Tot_units").Value = ETSSQL.GetOneSQLValue(sqlstmnt)
            Next
            Save125Data.Visible = True
            DataGridView1.ClearSelection()
        End If

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_bill_type = DataGridView1.Item("bill_type", e.RowIndex).Value.ToString
            selected_name_key = DataGridView1.Item("name_key", e.RowIndex).Value.ToString
            selected_contract_key = DataGridView1.Item("contract_key", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub

    Private Sub change_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles change.Click
        On Error Resume Next
        If Err.Number = 6028 Then
            MsgBox("You must select an item for editing.")
            Exit Sub
        End If

        selected_Date_Range_Start = CDate(start_date.Text)
        selected_Date_Range_End = CDate(End_Date.Text)
        selected_start_date = CDate(start_date.Text)
        selected_end_date = CDate(End_Date.Text)

        If selected_bill_type = "170" Then
            If med_flag = "Y" Then
                '  ed_range_dates_med.Show 1
            End If
        Else
            ed_range_dates.ShowDialog()
        End If

    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub del_attend_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles del_attend.Click

        editname(0) = selected_name_key

        If selected_bill_type = "170" Then
            '    If med_flag = "Y" Then
            '        tmpdb = DAODBEngine_definst.OpenDatabase(am_data_path & "med.mdb")
            '        sqlstmnt = "select * from medopn_tmp where name_key = " & Chr(34) & Trim(selected_name_key) & Chr(34)
            '        sqlstmnt = sqlstmnt & " and contract_key = " & Chr(34) & selected_contract_key & Chr(34)
            '        '        sqlstmnt = sqlstmnt & " and from_Date between " & Chr(35) & selected_start_date & Chr(35) & " and " & Chr(35) & selected_end_date & Chr(35) & " order by from_Date, place_serv "
            '        tmp1set = tmpdb.OpenRecordset(sqlstmnt)

            '        Do While Not tmp1set.EOF
            '            tmp1set.delete()
            '            tmp1set.MoveNext()
            '        Loop
            '        tmp1set = Nothing
            '        Call refresh_list()
            '    End If
        Else 'must be attend so added 6/30/01

            sqlstmnt = "delete from attend_tmp where name_key = '" & Trim(selected_name_key) '
            sqlstmnt = sqlstmnt & "' and contract_key = '" & selected_contract_key
            sqlstmnt = sqlstmnt & "' and att_Date between '" & selected_start_date & "' and '" & selected_end_date & "'"

            ETSSQL.ExecuteSQL(sqlstmnt)

            Call refresh_list()
        End If

    End Sub

    Sub refresh_list()

        If selected_bill_type = "170" And med_flag = "Y" Then
            '	tmpdb = DAODBEngine_definst.OpenDatabase(am_data_path & "med.mdb")
            '	Select Case selected_grouping
            '		Case "CLIENT"
            '			'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '			sqlstmnt = "select * from medopn_tmp where name_key = " & Chr(34) & selected_name_key & Chr(34)
            '			sqlstmnt = sqlstmnt & " and ((medopn_tmp.from_date) Between " & Chr(35) & selected_Date_Range_Start & Chr(35)
            '			sqlstmnt = sqlstmnt & " and " & Chr(35) & selected_Date_Range_End & Chr(35) & ")"

            '			tmpset = medmdb.OpenRecordset(sqlstmnt)

            '			Do While Not tmpset.EOF
            '				tmp1set.AddNew()
            '				tmp1set.Fields("name_key").Value = tmpset.Fields("name_key").Value
            '				tmp1set.Fields("contract_key").Value = tmpset.Fields("contract_key").Value
            '				tmp1set.Fields("b_num").Value = tmp1set.Fields("name_key").Value & tmp1set.Fields("contract_key").Value
            '				tmp1set.Fields("sort_name").Value = tmpset.Fields("sort_name").Value
            '				tmp1set.Fields("autho_num").Value = tmpset.Fields("prior_auth").Value
            '				tmp1set.Fields("bill_type").Value = "170" 'tmpset.Fields("")
            '				tmp1set.Fields("unit_rate").Value = tmpset.Fields("usual_fee").Value
            '				tmp1set.Fields("att_Date").Value = tmpset.Fields("from_date").Value
            '				tmp1set.Fields("att_code").Value = tmpset.Fields("proc_code").Value
            '				tmp1set.Fields("att_unit").Value = tmpset.Fields("att_units").Value
            '				tmp1set.Update()

            '				If Err.Number = 3022 Then Resume Next

            '				tmpset.MoveNext()
            '			Loop 
            '			'UPGRADE_NOTE: Object tmpset may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            '			tmpset = Nothing


            '		Case "CONTRACT"

            '			sqlstmnt = "select distinct name_key from medopn_tmp where contract_key = " & Chr(34) & selected_contract_key & Chr(34)
            '			sqlstmnt = sqlstmnt & " and ((medopn_tmp.from_date) Between " & Chr(35) & selected_Date_Range_Start & Chr(35)
            '			sqlstmnt = sqlstmnt & " and " & Chr(35) & selected_Date_Range_End & Chr(35) & ") order by name_key"

            '			tmp2set = medmdb.OpenRecordset(sqlstmnt)

            '			'sqlstmnt = "select * from medopn_tmp where contract_key = " & Chr(34) & selected_contract_key & Chr(34) & " order by sort_name"
            '			tmpset = medmdb.OpenRecordset("medopn_tmp", dao.RecordsetTypeEnum.dbOpenDynaset)

            '			Do While Not tmp2set.EOF
            '				' tmpset.FindFirst "name_key = " & Chr(34) & tmp2set.Fields("name_key") & Chr(34)        replaced with lower line 8/21/00 
            '				tmpset.FindFirst("name_key = " & Chr(34) & tmp2set.Fields("name_key").Value & Chr(34) & " and contract_key = " & Chr(34) & selected_contract_key & Chr(34))

            '				If Not tmpset.NoMatch Then

            '					tmp1set.AddNew()
            '					tmp1set.Fields("name_key").Value = tmpset.Fields("name_key").Value
            '					tmp1set.Fields("contract_key").Value = tmpset.Fields("contract_key").Value

            '					tmp1set.Fields("b_num").Value = tmpset.Fields("name_key").Value & tmpset.Fields("contract_key").Value
            '					tmp1set.Fields("sort_name").Value = tmpset.Fields("sort_name").Value
            '					tmp1set.Fields("autho_num").Value = tmpset.Fields("prior_auth").Value
            '					tmp1set.Fields("bill_type").Value = "170" 'tmpset.Fields("")
            '					tmp1set.Fields("unit_rate").Value = tmpset.Fields("usual_fee").Value
            '					tmp1set.Fields("att_Date").Value = tmpset.Fields("from_date").Value
            '					tmp1set.Fields("att_code").Value = tmpset.Fields("proc_code").Value
            '					tmp1set.Fields("att_unit").Value = tmpset.Fields("att_units").Value
            '					tmp1set.Update()

            '				End If

            '				If Err.Number = 3022 Then Resume Next
            '				Err.Clear()
            '				tmp2set.MoveNext()
            '			Loop 

            '			'UPGRADE_NOTE: Object tmpset may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            '			tmpset = Nothing
            '			'UPGRADE_ISSUE: Data property Data1.RecordSource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '			Data1.RecordSource = "select * from attend_unq order by sort_name"



            '			Data1.Refresh()
            '	End Select

        Else 'must be attend so added 6/30/01
            'not medicaid
            Call get_attend()
        End If

        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing

    End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Edit.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        editname(0) = selected_name_key
        selected_screen_nam = ETSCommon.GetDatum("nam_Addr", "name_key", selected_name_key, "screen_nam")

        full_flag = "N"

        If selected_bill_type = "170" Then
            If med_flag = "Y" Then
                'ed_dates_med.ShowDialog()
            End If
        Else
            ed_dates.ShowDialog()  'also knows as date_Dat
        End If

    End Sub

    Private Sub editall_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles editall.Click
        full_flag = "Y"
        'Do While Not Data1.Recordset.EOF
        '	'start with the selected name key
        '	'since in sort name order => sort name should work

        '	If Data1.Recordset.Fields("sort_name") >= selected_sort_name Then
        '		editname(num) = Data1.Recordset.Fields("name_key")
        '		num = num + 1
        '	End If
        '	Data1.Recordset.MoveNext()
        'Loop 

        If selected_bill_type = "170" Then
            If med_flag = "Y" Then
                'ed_dates_med.ShowDialog()
            End If
        Else
            ed_dates.ShowDialog()
        End If

        Call refresh_list()

    End Sub

    Private Sub att_edit_bill_type_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        DataGridView1.Columns.Add("name_key", "Name Key")
        DataGridView1.Columns.Item(0).DataPropertyName = "name_key"
        DataGridView1.Columns.Item(0).ReadOnly = True
        DataGridView1.Columns.Add("Contract_key", "Contract")
        DataGridView1.Columns.Item(1).DataPropertyName = "Contract_key"
        DataGridView1.Columns.Item(1).ReadOnly = True
        DataGridView1.Columns.Add("bill_type", "Bill Type")
        DataGridView1.Columns.Item(2).DataPropertyName = "bill_type"
        DataGridView1.Columns.Item(2).ReadOnly = True
        DataGridView1.Columns.Add("sort_name", "Name")
        DataGridView1.Columns.Item(3).DataPropertyName = "sort_name"
        DataGridView1.Columns.Item(3).ReadOnly = True
        If selected_bill_type = "125" Then
            DataGridView1.Columns.Add("Tot_units", "Total Units")
            DataGridView1.Columns.Item(3).DataPropertyName = "Tot_units"
            DataGridView1.Columns.Item(3).ReadOnly = False ' = DataGridViewEditMode.EditOnEnter
        End If



        Dim HeaderDates As String() = ETSCommon.GetBeginEndDates.Split(CChar("*"))
        start_date.Text = HeaderDates(0)
        End_Date.Text = HeaderDates(1)
        selected_start_date = CDate(start_date.Text)
        selected_end_date = CDate(End_Date.Text)

        ctrform(Me)

        'Call med_open()

        ''we will build attend_unq from attend or from medopn depending on what we want
        If med_flag = "Y" And selected_bill_type = "170" Then

            '	'test if editing medicaid
            '	editall.Visible = True
            '	del_attend.Visible = True

            '	Select Case selected_grouping

            '		Case "CLIENT"
            '			editall.Visible = False
            '			'UPGRADE_WARNING: Couldn't resolve default property of object selected_name_key. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '			sqlstmnt = "select * from medopn_tmp where name_key = " & Chr(34) & selected_name_key & Chr(34)
            '			sqlstmnt = sqlstmnt & " and (medopn_tmp.from_date) Between " & Chr(35) & selected_Date_Range_Start & Chr(35)
            '			sqlstmnt = sqlstmnt & " and " & Chr(35) & selected_Date_Range_End & Chr(35)

            '			tmpset = medmdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)

            '			Do While Not tmpset.EOF
            '				tmp1set.AddNew()
            '				tmp1set.Fields("name_key").Value = tmpset.Fields("name_key").Value
            '				tmp1set.Fields("contract_key").Value = tmpset.Fields("contract_key").Value
            '				tmp1set.Fields("b_num").Value = tmp1set.Fields("name_key").Value & tmp1set.Fields("contract_key").Value
            '				tmp1set.Fields("sort_name").Value = tmpset.Fields("sort_name").Value
            '				tmp1set.Fields("autho_num").Value = tmpset.Fields("prior_auth").Value
            '				tmp1set.Fields("bill_type").Value = "170" 'tmpset.Fields("")
            '				tmp1set.Fields("unit_rate").Value = tmpset.Fields("usual_fee").Value
            '				tmp1set.Fields("att_Date").Value = tmpset.Fields("from_date").Value
            '				tmp1set.Fields("att_code").Value = tmpset.Fields("proc_code").Value
            '				tmp1set.Fields("att_unit").Value = tmpset.Fields("att_units").Value
            '				tmp1set.Update()

            '				If Err.Number = 3022 Then Resume Next

            '				tmpset.MoveNext()
            '			Loop 
            '			'UPGRADE_NOTE: Object tmpset may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            '			tmpset = Nothing

            '			Call get_attend()

            '		Case "CONTRACT"
            '			editall.Visible = True
            '			sqlstmnt = "select distinct name_key from medopn_tmp where contract_key = " & Chr(34) & selected_contract_key & Chr(34)
            '			sqlstmnt = sqlstmnt & " and ((medopn_tmp.from_date) Between " & Chr(35) & selected_Date_Range_Start & Chr(35)
            '			sqlstmnt = sqlstmnt & " and " & Chr(35) & selected_Date_Range_End & Chr(35) & ") order by name_key"

            '			tmp2set = medmdb.OpenRecordset(sqlstmnt)

            '			'sqlstmnt = "select * from medopn_tmp where contract_key = " & Chr(34) & selected_contract_key & Chr(34) & " order by sort_name"
            '			tmpset = medmdb.OpenRecordset("medopn_tmp", dao.RecordsetTypeEnum.dbOpenDynaset)

            '			Do While Not tmp2set.EOF
            '				'on 8/22 changed added comment lines and changed tmpset to tmpset2
            '				tmpset.FindFirst("name_key = " & Chr(34) & tmp2set.Fields("name_key").Value & Chr(34) & " and contract_key = " & Chr(34) & selected_contract_key & Chr(34))

            '				If Not tmpset.NoMatch Then
            '					tmp1set.AddNew()
            '					tmp1set.Fields("name_key").Value = tmpset.Fields("name_key").Value
            '					tmp1set.Fields("contract_key").Value = selected_contract_key 'tmpset.Fields("contract_key") 
            '					tmp1set.Fields("b_num").Value = tmp1set.Fields("name_key").Value & tmp1set.Fields("contract_key").Value
            '					tmp1set.Fields("sort_name").Value = tmpset.Fields("sort_name").Value
            '					tmp1set.Fields("autho_num").Value = tmpset.Fields("prior_auth").Value
            '					tmp1set.Fields("bill_type").Value = "170" 'tmpset.Fields("")
            '					tmp1set.Fields("unit_rate").Value = tmpset.Fields("usual_fee").Value
            '					tmp1set.Fields("att_Date").Value = tmpset.Fields("from_date").Value
            '					tmp1set.Fields("att_code").Value = tmpset.Fields("proc_code").Value
            '					tmp1set.Fields("att_unit").Value = tmpset.Fields("att_units").Value
            '					tmp1set.Update()
            '				End If

            '				If Err.Number = 3022 Then Resume Next
            '				Err.Clear()
            '				tmp2set.MoveNext()
            '			Loop 
            '			'UPGRADE_NOTE: Object tmpset may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            '			tmpset = Nothing
            '			Call get_attend()

            '	End Select

        Else
            'not medicaid
            Call get_attend()
        End If


    End Sub

    Private Sub Save125Data_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save125Data.Click
        DataGridView1.SelectAll()
        For Each DGRow As DataGridViewRow In DataGridView1.SelectedRows
            'put the edited data into the first monday of the month and zero the other days
            'zero the month
            sqlstmnt = " update attend_tmp set att_unit = 0 where contract_key = '" & selected_contract_key
            sqlstmnt = sqlstmnt & "' and att_Date between '" & selected_start_date & "' and '" & selected_end_date
            sqlstmnt = sqlstmnt & "' and name_key = '" & DGRow.Cells("name_key").Value.ToString & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)
            'get first monday of month and put data into it
            Dim Dte As Date = New Date(Year(selected_start_date), Month(selected_start_date), 1)
            Do While Dte.DayOfWeek <> DayOfWeek.Monday
                Dte = Dte.AddDays(1)
            Loop
            sqlstmnt = " update attend_tmp set att_unit = '" & DGRow.Cells("tot_units").Value.ToString & "' where contract_key = '" & selected_contract_key
            sqlstmnt = sqlstmnt & "' and att_Date = '" & Dte
            sqlstmnt = sqlstmnt & " ' and name_key = '" & DGRow.Cells("name_key").Value.ToString & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)

        Next
        Me.Close()
        Me.Dispose()

    End Sub
End Class