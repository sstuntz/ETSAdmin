Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.Office.Core
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel

Public Class ar_bat_lookup
    Inherits System.Windows.Forms.Form
    Dim SelectedIndex As Integer
    Dim ChkAccts As String
    Dim ExcelApp As Microsoft.Office.Interop.Excel.Application
    Dim ExcelBook As Microsoft.Office.Interop.Excel.Workbook

    Private Sub rebuild_grid()  'ByVal sql As String)
        Dim sql As String = " select distinct t.batch_num, batch_Date, batch_Desc, batch_total, unapp_total from cash_tmp1 T inner join ( select  batch_num,  (batch_total - sum(chk_alloc)) as unapp_total  from cash_tmp1  group by batch_num, batch_total) TT on t.batch_num = tt.batch_num order by batch_date desc, batch_desc desc"
        ' Dim sql As String = "select distinct batch_num, batch_Date, batch_Desc, batch_total, (batch_total - sum(chk_alloc)) as unapp_total  from cash_tmp1 order by batch_num desc"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False

        'If SelectedIndex > 0 Then
        '    DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
        '    DataGridView1.Rows(SelectedIndex).Selected = False
        '    DataGridView1.Rows(SelectedIndex).Cells(0).Selected = True
        '    DataGridView1.PerformLayout()
        'Else
        '    On Error Resume Next
        '    DataGridView1.Rows(0).Selected = False
        '    On Error GoTo 0
        'End If

        DataGridView1.AutoResizeColumns()
        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_bat_num = CInt(DataGridView1.Item("batch_num", e.RowIndex).Value.ToString)
            prtParameterFields(0) = "Batch_num;" & selected_bat_num & ";FALSE"
        End If
        '  SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub

    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
        entry_type = "ADD"
        selected_bat_num = 0
        selected_line_num = 1
        ar_cash_batch.ShowDialog()
        Call rebuild_grid()
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        selected_bat_num = 0
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "arcbatch1.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Private Sub PrintbyChk_Click(sender As System.Object, e As System.EventArgs) Handles PrintbyChk.Click
        prtDestination = CInt(CStr(0))
        prtreportfilename = ar_report_path & "dep_proof_by_check.rpt"
        CrystalForm.ShowDialog()

    End Sub

    Private Sub ed_det_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ed_det.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        Response = MsgBox("Are you sure you want to delete batch # " & selected_bat_num, CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))

        If Response = vbYes Then
            'delete a batch
            sqlstmnt = "Delete from cash_tmp1 where batch_num = '" & selected_bat_num & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)
            MsgBox("Batch deleted.")
        Else
            MsgBox("Nothing Deleted.")
        End If

        rebuild_grid()


    End Sub



    Private Sub extra_com_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles extra_com.Click

        Response = MsgBox("Are you sure you want to apply the selected batches?", MsgBoxStyle.YesNo)
        If Response = vbNo Then Exit Sub

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Selected = True Then

                'this posts the batch

                'checks the batch to make sure that the detail = the total
                'checks all the account numbers
                'checks for disc acct if disc amt
                'checks for a name key
                'check the batch for completeness

                'select COUNT(*) as thevalue from cash_tmp1  left outer join chacct on chacct.acct_num = cash_tmp1.dr_acct_nu where chacct.acct_num is null and batch_num = '9989'

                ChkAccts = ETSSQL.GetOneSQLValue("select cash_tmp1.dr_acct_nu as thevalue from cash_tmp1  left outer join chacct on chacct.acct_num = cash_tmp1.dr_acct_nu where chacct.acct_num is null and batch_num = '" & selected_bat_num & "'")
                If ChkAccts.Length <> 0 Then
                    MsgBox("BATCH NOT POSTED Invalid DR account number on entry number = " & ChkAccts)
                    Exit Sub
                End If
                ChkAccts = ETSSQL.GetOneSQLValue("select cash_tmp1.cr_acct_nu as thevalue from cash_tmp1  left outer join chacct on chacct.acct_num = cash_tmp1.cr_acct_nu where chacct.acct_num is null and batch_num = '" & selected_bat_num & "'")
                If ChkAccts.Length <> 0 Then
                    MsgBox("BATCH NOT POSTED Invalid CR account number on entry number = " & ChkAccts)
                    Exit Sub
                End If
                '  ChkAccts.length = ETSSQL.GetOneSQLValue("select COUNT(*) as thevalue from cash_tmp1  left outer join chacct on chacct.acct_num = cash_tmp1.disc_acct where chacct.acct_num is null and batch_num = '" & selected_bat_num & "'")
                'If ChkAccts = 0 Then
                '    MsgBox("BATCH NOT POSTED Invalid disc account number on entry number = " & ChkAccts)
                '    Exit Sub
                'End If

                'check the batch total
                Dim BatchSum As Double = (ETSSQL.GetTotalPayments("select chk_alloc from cash_tmp1 where batch_num = '" & selected_bat_num & "'"))

                Dim CashRec As List(Of CashReceiptData) = ETSSQL.GetCashReceiptData("select * from cash_tmp1 where batch_num = '" & selected_bat_num & "'")
                If CDec(BatchSum) <> CDec(CashRec(0).BatchTotal) Then
                    MsgBox("BATCH NOT POSTED The total batch amount is not equal to the detail. The detail = " & BatchSum)
                    Exit Sub
                End If


                ChkAccts = ETSSQL.GetOneSQLValue("select cash_tmp1.invoice from cash_tmp1  left outer join invoice on cash_tmp1.inv_num = invoice.inv_num where invoice.void = 'Y' and  cash_tmp1.batch_num = '" & selected_bat_num & "'")
                If ChkAccts.Length <> 0 Then
                    MsgBox("BATCH NOT POSTED  An invoice has bee voided." & ChkAccts)
                    Exit Sub
                End If


                ETSCommon.CheckNumRecords("select * from cash_tmp1 left join invoice on cash_tmp1.inv_num = invoice.inv_num where cash_tmp1.batch_num = '" & selected_bat_num & "'")

                '    'and update invoice
                For Each Cashitem In CashRec
                    If Len(Cashitem.InvNum) <> 0 Then
                        sqlstmnt = " Update invoice "
                        sqlstmnt = sqlstmnt & " set paid_Date = '" & Cashitem.EncumDate & "'"
                        sqlstmnt = sqlstmnt & ", chk_num = '" & Cashitem.ChkNum & "'"
                        sqlstmnt = sqlstmnt & ", bank_key = '" & Cashitem.BankKey & "'"
                        sqlstmnt = sqlstmnt & ", pay_amt = (pay_amt + '" & Cashitem.ChkAlloc & "')"
                        sqlstmnt = sqlstmnt & ", bal_due = (bal_due - '" & Cashitem.ChkAlloc & "')"
                        sqlstmnt = sqlstmnt & " where inv_num = '" & Cashitem.InvNum & "' and line_num = '" & Cashitem.LineNum & "'"
                        ETSSQL.ExecuteSQL(sqlstmnt)
                        sqlstmnt = " Update invoice "
                        sqlstmnt = sqlstmnt & " set paid = 'Y'"
                        sqlstmnt = sqlstmnt & " where bal_due = 0 and inv_num = '" & Cashitem.InvNum & "' and line_num = '" & Cashitem.LineNum & "'"
                        ETSSQL.ExecuteSQL(sqlstmnt)
                    End If
                Next
                '    'move to cash
                sqlstmnt = "insert into cash select * from cash_tmp1 where batch_num = '" & selected_bat_num & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)

                sqlstmnt = "delete from cash_tmp1 where batch_num = '" & selected_bat_num & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If
        Next

        rebuild_grid()


    End Sub

    Private Sub ar_bat_lookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load


        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        DataGridView1.Columns.Add("batch_num", "Batch #")
        DataGridView1.Columns.Item(0).DataPropertyName = "batch_num"
        DataGridView1.Columns.Add("batch_date", "Batch Date")
        DataGridView1.Columns.Item(1).DataPropertyName = "batch_date"
        DataGridView1.Columns.Add("batch_desc", "Batch Desc")
        DataGridView1.Columns.Item(2).DataPropertyName = "batch_desc"
        DataGridView1.Columns.Add("batch_total", "Batch Total")
        DataGridView1.Columns.Item(3).DataPropertyName = "batch_total"
        DataGridView1.Columns.Item(3).DefaultCellStyle.Format = "N2"
        DataGridView1.Columns.Add("unapp_total", "Amount not Applied")
        DataGridView1.Columns.Item(4).DataPropertyName = "unapp_total"
        DataGridView1.Columns.Item(4).DefaultCellStyle.Format = "N2"
        DataGridView1.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ctrform(Me)
        selectedcell = False


        rebuild_grid()

    End Sub

    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        entry_type = "EDIT"
        Call FixEntryNumbers()

        ar_cash_edit_sel.ShowDialog()

        Call rebuild_grid()

    End Sub

    Private Sub AddToBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToBatch.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        selected_line_num = 1

        entry_type = "ADD_EDIT"
        Call FixEntryNumbers()
        ar_cash_batch.ShowDialog()

        Call rebuild_grid()
    End Sub

    Private Sub FixEntryNumbers()
        'renumbers batch in case a delete changes numbers
        'do it by inv inv line number order in batch

        sqlstmnt = ";with cte as (select inv_num, line_num, entry_num, ROW_NUMBER() over (order by inv_num,Line_num) as rownum from cash_tmp1 where batch_num = '" & selected_bat_num & "')"
        sqlstmnt = sqlstmnt & " update cte set entry_num = rownum  "

        ETSSQL.ExecuteSQL(sqlstmnt)



    End Sub

    Private Sub Importcsv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'not needed by JRI
        ''added 12/18/03 lhw/tk  moved from V4 5/6/04 lhw
        'Dim filename_sel As Object

        'entry_type = "ADD"
        'selected_bat_num = 0

        'txtfields.Visible = True
        'Label4.Visible = True
        'If Trim(txtfields.Text) = "" Then
        '    MsgBox("Enter Encum Date for the Import File.")
        '    txtfields.Focus()
        '    Exit Sub
        'End If

        'cash_tmp.Refresh()
        ''  Do While Not cash_Tmp.Recordset.EOF
        ''    cash_Tmp.Recordset.Delete
        ''    cash_Tmp.Recordset.MoveNext
        ''  Loop

        'MsgBox("Please insert disk.")

        'fnum = FreeFile()

        ''UPGRADE_WARNING: Couldn't resolve default property of object filename_sel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'filename_sel = "A:\RENT.csv"
        'Err.Clear()
        ''UPGRADE_WARNING: Couldn't resolve default property of object filename_sel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ''	FileOpen(fnum, filename_sel, OpenMode.Input, , , 1)

        'Select Case Err.Number
        '    Case 0
        '    Case 70
        '        MsgBox("Drive A:\ not ready.")
        '        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '        Exit Sub
        '    Case Else
        '        MsgBox("Error #" & Err.Number & " meaning " & ErrorToString(Err.Number) & Chr(10) & "Please fix before trying again.")
        '        'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        '        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '        Exit Sub
        'End Select

        'On Error GoTo 0

        'Dim fld(6) As Object
        'Dim batch_total As Decimal
        'batch_total = 0
        ''UPGRADE_WARNING: Arrays in structure invoiceset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        ''Dim invoiceset As dao.Recordset
        ''tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
        ''invoiceset = tmpdb.OpenRecordset("cash_tmp1", dao.RecordsetTypeEnum.dbOpenDynaset)

        ''tmpset = tmpdb.OpenRecordset("nam_cust", dao.RecordsetTypeEnum.dbOpenDynaset)

        'num = 0
        'Call batch_number_Create()
        'saved_entry_num = 1
        'Do While Not EOF(fnum)
        '	err.Clear()
        '	On Error Resume Next
        '	Input(1, msg)

        '	If Err.Number = 62 Then Exit Do
        '	'UPGRADE_WARNING: Couldn't resolve default property of object fld(num). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	fld(num) = msg

        '	'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '          If num = 6 And Trim(CStr(fld(0))) <> "" Then
        '              num = 0
        '              'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              sqlstmnt = "Select * from nam_cust where name_key = " & Chr(34) & Trim(fld(0)) & Chr(34)
        '              tmpset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        '              'tmpset.FindFirst "name_key = " & Chr(34) & Trim(fld(0)) & Chr(34)
        '              'If Not tmpset.NoMatch Then
        '              If tmpset.RecordCount <> 0 Then
        '                  'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                  If Trim(fld(3)) <> "" Then
        '                      'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                      batch_total = batch_total + fld(3)
        '                  End If

        '                  invoiceset.AddNew()
        '                  invoiceset.Fields("bank_key").Value = "2177"
        '                  invoiceset.Fields("encum_date").Value = txtfields.Text
        '                  'UPGRADE_WARNING: Couldn't resolve default property of object fld(0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                  invoiceset.Fields("name_key").Value = fld(0)
        '                  invoiceset.Fields("screen_nam").Value = tmpset.Fields("screen_nam").Value
        '                  invoiceset.Fields("sort_name").Value = tmpset.Fields("sort_name").Value
        '                  'UPGRADE_WARNING: Couldn't resolve default property of object fld(2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                  invoiceset.Fields("chk_num").Value = fld(2)
        '                  invoiceset.Fields("chk_date").Value = txtfields.Text
        '                  'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                  If Trim(fld(3)) <> "" Then
        '                      'UPGRADE_WARNING: Couldn't resolve default property of object fld(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                      invoiceset.Fields("gross_amt").Value = fld(3)
        '                  End If
        '                  invoiceset.Fields("chk_disc").Value = 0
        '                  'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                  If Trim(fld(3)) <> "" Then
        '                      'UPGRADE_WARNING: Couldn't resolve default property of object fld(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                      invoiceset.Fields("check_amt").Value = fld(3)
        '                      'UPGRADE_WARNING: Couldn't resolve default property of object fld(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                      invoiceset.Fields("chk_alloc").Value = fld(3)
        '                  End If
        '                  invoiceset.Fields("entry_num").Value = saved_entry_num
        '                  saved_entry_num = saved_entry_num + 1
        '                  invoiceset.Fields("inv_num").Value = 0
        '                  invoiceset.Fields("line_num").Value = 1
        '                  invoiceset.Fields("invoice").Value = "MISC"
        '                  invoiceset.Fields("trans_code").Value = "PMT"
        '                  invoiceset.Fields("dr_acct_nu").Value = "1007-00-00" 'bank
        '                  invoiceset.Fields("cr_acct_nu").Value = "1260-00-00"
        '                  invoiceset.Fields("disc_acct").Value = "1260-00-00"
        '                  invoiceset.Fields("donor").Value = "MISC"
        '                  invoiceset.Fields("memo").Value = "ON ACCOUNT"
        '                  invoiceset.Fields("batch_num").Value = selected_bat_num
        '                  invoiceset.Fields("batch_desc").Value = "1"
        '                  invoiceset.Fields("batch_date").Value = txtfields.Text
        '                  'invoiceset.Fields("batch_total") = batch_total
        '                  invoiceset.Fields("s_m").Value = "M"

        '                  invoiceset.update()
        '              Else
        '                  'UPGRADE_WARNING: Couldn't resolve default property of object fld(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                  'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                  MsgBox("Customer #" & fld(0) & " (" & fld(1) & ") not in nam_cust table.These are not added to this batch.")

        '              End If

        '          Else
        '              num = num + 1
        '          End If
        'Loop 

        'sqlstmnt = "SELECT batch_total FROM cash_tmp1 where batch_num = " & selected_bat_num & "" 'fixed lhw
        'invoiceset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        'invoiceset.MoveFirst()
        'Do While Not invoiceset.EOF
        '	invoiceset.edit()
        '	invoiceset.Fields("batch_total").Value = batch_total
        '	invoiceset.update()
        '	invoiceset.MoveNext()
        'Loop 

        'MsgBox("Import complete.  Batch Total: $" & batch_total)

        'FileClose(fnum)
        ''UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        ''turn off entry date area
        'txtfields.Visible = False
        'Label4.Visible = False

        '  rebuild_grid()

        'selectedcell = False

    End Sub

    Private Sub PushExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PushExcel.Click
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Selected = True Then

                'this puts rows into excel

                'checks the batch to make sure that the detail = the total
                'checks all the account numbers
                'checks for disc acct if disc amt
                'checks for a name key
                'check the batch for completeness

                'select COUNT(*) as thevalue from cash_tmp1  left outer join chacct on chacct.acct_num = cash_tmp1.dr_acct_nu where chacct.acct_num is null and batch_num = '9989'

                ChkAccts = ETSSQL.GetOneSQLValue("select COUNT(*) as thevalue from cash_tmp1  left outer join chacct on chacct.acct_num = cash_tmp1.dr_acct_nu where chacct.acct_num is null and batch_num = '" & selected_bat_num & "'")
                If ChkAccts.Length <> 0 Then
                    MsgBox("BATCH NOT POSTED Invalid DR account number on entry number = " & ChkAccts)
                    Exit Sub
                End If
                ChkAccts = ETSSQL.GetOneSQLValue("select COUNT(*) as thevalue from cash_tmp1  left outer join chacct on chacct.acct_num = cash_tmp1.cr_acct_nu where chacct.acct_num is null and batch_num = '" & selected_bat_num & "'")
                If ChkAccts.Length <> 0 Then
                    MsgBox("BATCH NOT POSTED Invalid CR account number on entry number = " & ChkAccts)
                    Exit Sub
                End If
                ChkAccts = ETSSQL.GetOneSQLValue("select COUNT(*) as thevalue from cash_tmp1  left outer join chacct on chacct.acct_num = cash_tmp1.disc_acct where chacct.acct_num is null and batch_num = '" & selected_bat_num & "'")
                'If ChkAccts = 0 Then
                '    MsgBox("BATCH NOT POSTED Invalid disc account number on entry number = " & ChkAccts)
                '    Exit Sub
                'End If


                'check the batch total
                Dim BatchSum As Double = (ETSSQL.GetTotalPayments("select chk_alloc from cash_tmp1 where batch_num = '" & selected_bat_num & "'"))

                Dim CashRec As List(Of CashReceiptData) = ETSSQL.GetCashReceiptData("select * from cash_tmp1 where batch num = '" & selected_bat_num & "'")
                If BatchSum <> CashRec(0).BatchTotal Then
                    MsgBox("BATCH NOT SENT TO EXCEL The total batch amount is not equal to the detail.")
                    Exit Sub
                End If
                '    'and update invoice
                For Each Cashitem In CashRec

                    'With Excel
                    '    .SheetsInNewWorkbook = 1
                    '    .Workbooks.Add()
                    '    .Worksheets(1).Select()

                    '    Dim i As Integer = 1
                    '    For col = 0 To ComDset.Tables(0).Columns.Count - 1
                    '        .cells(1, i).value = ComDset.Tables(0).Columns(col).ColumnName
                    '        .cells(1, i).EntireRow.Font.Bold = True
                    '        i += 1
                    '    Next

                    '    i = 2

                    '    Dim k As Integer = 1
                    '    For col = 0 To ComDset.Tables(0).Columns.Count - 1
                    '        i = 2
                    '        For row = 0 To ComDset.Tables(0).Rows.Count - 1
                    '            .Cells(i, k).Value = ComDset.Tables(0).Rows(row).ItemArray(col)
                    '            i += 1
                    '        Next
                    '        k += 1
                    '    Next
                    '    filename = "c:\File_Exported.xls"
                    '    .ActiveCell.Worksheet.SaveAs(filename)

                    '   Dim ExcelApp As New Excel.application
                    '   Dim ExcelBook As Escel.workbook

                    Dim cashworkbook As Microsoft.Office.Interop.Excel.Workbook
                    cashworkbook = ExcelApp.Workbooks.Add



                    'Dim ExcelSheet As Object
                    'Dim i As Integer
                    'Dim j As Integer

                    ''create object of excel
                    'ExcelApp = CreateObject("Excel.Application")
                    'ExcelBook = CreateObject("excel.workbooks")
                    'ExcelSheet = CreateObject("ExcelApp.worksheet")

                    'ExcelBook = ExcelApp.WorkBooks.Add
                    'ExcelSheet = ExcelBook.WorkSheets(1)

                    'With ExcelSheet
                    '    For i = 1 To Me.DataGridView1.RowCount
                    '        .cells(i, 1) = Me.DataGridView1.Rows(i - 1).Cells("id").Value
                    '        For j = 1 To DataGridView1.Columns.Count - 1
                    '            .cells(i, j + 1) = DataGridView1.Rows(i - 1).Cells(j).Value
                    '        Next
                    '    Next
                    'End With

                    'If Len(Cashitem.InvNum) <> 0 Then
                    '    sqlstmnt = " Update invoice "
                    '    sqlstmnt = sqlstmnt & " set paid_Date = '" & Cashitem.EncumDate & "'"
                    '    sqlstmnt = sqlstmnt & " set chk_num = '" & Cashitem.ChkNum & "'"
                    '    sqlstmnt = sqlstmnt & " set bank_key = '" & Cashitem.BankKey & "'"
                    '    sqlstmnt = sqlstmnt & " set pay_amt = '" & Cashitem.ChkAlloc & "'"
                    '    sqlstmnt = sqlstmnt & " set bal due = bal_due - '" & Cashitem.ChkAlloc & "'"
                    '    sqlstmnt = sqlstmnt & " where inv_num = '" & Cashitem.InvNum & "' and line_num = '" & Cashitem.LineNum & "'"
                    '    ETSSQL.ExecuteSQL(sqlstmnt)
                    '    sqlstmnt = " Update invoice "
                    '    sqlstmnt = sqlstmnt & " set paid = 'Y'"
                    '    sqlstmnt = sqlstmnt & " where bal_due = 0 and inv_num = '" & Cashitem.InvNum & "' and line_num = '" & Cashitem.LineNum & "'"
                    '    ETSSQL.ExecuteSQL(sqlstmnt)
                    'End If
                Next

            End If
        Next
    End Sub

   
End Class