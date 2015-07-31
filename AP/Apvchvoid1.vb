Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports ETS

Public Class apvchvoid1_frm

    Inherits System.Windows.Forms.Form
    Public rowvalue, colvalue As Object
    Public tot_amt As Decimal
    Public saved_date As Date
    Public glposted As String
    Dim SelectedIndex As Integer
    Dim JESource As String
    Public JeRowData As List(Of JeData)
    Public VoucherRowData As List(Of VoucherData)
    Public VoucherLookupNum As Integer
    Public VoucherSource As String


    Public Sub rebuild_grid()
        Dim sql As String = "select * from voucher where void  = 'N' and dflag  = 'N' and paid = 'N' and vouch_line = 1 order by  vouch_num "
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        selected_lookup_num = ""

        Select Case SelectedIndex
            Case 0
                On Error Resume Next
                DataGridView1.Rows(0).Selected = False
                SelectedIndex = 1
                On Error GoTo 0
            Case Is > DataGridView1.Rows.Count
                SelectedIndex = 1
            Case Else
                DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
                ' DataGridView1.Rows(SelectedIndex).Selected = True
                'DataGridView1.Rows(SelectedIndex).Cells(0).Selected = True
                DataGridView1.PerformLayout()
        End Select


        DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
        DataGridView1.Rows(SelectedIndex).Selected = True
        DataGridView1.Rows(SelectedIndex).Cells(0).Selected = True
        DataGridView1.PerformLayout()

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("vouch_num", e.RowIndex).Value.ToString
            selected_lookup_desc = DataGridView1.Item("glpost", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index
        save_voucher_num = selected_lookup_num
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub apvchvoid_frm1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Call rebuild_grid()
    End Sub

    Private Sub revoucher_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles revoucher.Click
        ''a voucher that was paid even if input as paid can not be edited
        entry_type = "Revoucher"
        frmvouchent.ShowDialog()
        rebuild_grid()
    End Sub

    Private Sub void_gl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_gl.Click
        If Len(selected_lookup_num) = 0 Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        If selected_lookup_desc <> "Y" Then
            MsgBox("Item has not been posted")
            Exit Sub
        End If
        Response = MsgBox("Are you sure that you want to void this voucher?", CType(256 + 4, MsgBoxStyle))
        If Response = 7 Then
            Exit Sub
        End If
        save_voucher_num = selected_lookup_num
        'void the voucher and put the J/E num into it to track it.
        Dim JrnlNum As Integer
        JrnlNum = GLMod.GetNextJENum("Regular")
        sqlstmnt = "update voucher set glpost = 'Y' , void = 'Y', jrnl_num = '" & JrnlNum & "' where vouch_num = '" & save_voucher_num & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        'create a new J/E to reverse then one created by the voucher
        VoucherSource = "Select * from voucher where vouch_num = '" & save_voucher_num & "'"
        VoucherLookupNum = CInt(save_voucher_num)
        VoucherRowData = ETSSQL.GetVoucherData(VoucherSource)
        Dim vline As Integer = 1
        Dim tot As Double = 0
        Dim cracct As String = ""
        Dim JeRow As New JeData
        For Each VoucherRow In VoucherRowData
            JeRow.AcctNum = VoucherRow.DRAcctNum
            JeRow.Amount = VoucherRow.AllocAmt * -1
            JeRow.JrnlLineNum = vline
            vline = vline + 1
            JeRow.JrnlNum = JrnlNum
            tot = tot + VoucherRow.AllocAmt
            JeRow.Post = "N"
            JeRow.JrnlDesc = "Vouch# " & save_voucher_num
            JeRow.JrnlSrc = "AP"
            JeRow.JrnlName = "VOID"
            JeRow.EntryType = "SD"
            JeRow.EntryDate = Today
            JeRow.EncumDate = Today
            cracct = VoucherRow.CRAcctNum
            JeRowData.Add(JeRow)
        Next
        'the cr accct
        'Dim JeRow As New JeData
        JeRow.AcctNum = cracct
        JeRow.Amount = tot
        JeRow.JrnlLineNum = vline
        JeRow.JrnlNum = JrnlNum
        JeRow.Post = "N"
        JeRow.JrnlDesc = "Vouch# " & save_voucher_num
        JeRow.JrnlSrc = "AP"
        JeRow.JrnlName = "VOID"
        JeRow.EntryType = "SD"
        JeRow.EntryDate = Today
        JeRow.EncumDate = Today
        JeRowData.Add(JeRow)


        sqlstmnt = "insert into yrgenled values ('"
        Call GLMod.SQLJEDataString(sqlstmnt, JeRowData)
        ETSSQL.ExecuteSQL(sqlstmnt)

        MsgBox("Note this J/E# on your worksheet: " & JrnlNum)
        MsgBox("You are about to print two reports.  Make sure your printer is online.")

        ''write voucher# to rpthead
        sqlstmnt = "update rpthead set beg_num = '" & save_voucher_num & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        'print report and added line above
        prtDestination = 1
        prtreportfilename = ap_report_path & "apvvoid.rpt"
        CrystalForm.ShowDialog()

        prtDestination = 1
        prtreportfilename = ap_report_path & "apvvjrnl.rpt"
        CrystalForm.ShowDialog()

        revoucher.Enabled = True
        Call rebuild_grid()


    End Sub

    Private Sub void_no_gl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_no_gl.Click
        If Len(selected_lookup_num) = 0 Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        If selected_lookup_desc = "Y" Then
            MsgBox("Item has been posted")
            Exit Sub
        End If

        Response = MsgBox("Are you sure that you want to void this voucher?", CType(256 + 4, MsgBoxStyle))
        If Response = 7 Then
            Exit Sub
        End If

        save_voucher_num = selected_lookup_num
        'in voucher table
        'set voucher.void to "N"
        sqlstmnt = "update voucher set void = 'Y' where vouch_num = '" & save_voucher_num & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        MsgBox("You are about to print a report.  Make sure your printer is online.")
        ''write voucher# to rpthead
        sqlstmnt = "update rpthead set beg_num = '" & save_voucher_num & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        'print report and added line above
        prtDestination = 1
        prtreportfilename = ap_report_path & "apvvoid.rpt"
        CrystalForm.ShowDialog()

        revoucher.Enabled = True
        Call rebuild_grid()

    End Sub

End Class