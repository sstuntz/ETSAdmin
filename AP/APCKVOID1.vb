Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports System.Data.SqlClient
Imports ETS.Common.Module1
Imports PS.Common
Imports ETS

Public Class apckvoid1_frm

    Inherits System.Windows.Forms.Form
    Public rowvalue, colvalue As Object
    Public selected_net As Double
    Public selected_DR As String
    Public selected_CR As String
    Public saved_date As Date
    Public glposted As String
    Dim SelectedIndex As Integer
    Dim JESource As String
    Public JeRowData As List(Of JeData)


    Public Sub rebuild_grid()

        Dim sql As String = "select * from payment where void  = 'N' and dflag  = 'N' order by  chk_num "
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
        selected_voucher = 0
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("chk_num", e.RowIndex).Value.ToString
            selected_lookup_desc = DataGridView1.Item("glpost", e.RowIndex).Value.ToString
            selected_net = CDbl(DataGridView1.Item("net_amt", e.RowIndex).Value.ToString)
            selected_CR = DataGridView1.Item("cr_acct_nu", e.RowIndex).Value.ToString
            selected_DR = DataGridView1.Item("dr_acct_nu", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub apckvoid_frm1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

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
        Response = MsgBox("Are you sure that you want to void this check?", CType(256 + 4, MsgBoxStyle))
        If Response = 7 Then
            Exit Sub
        End If
        save_voucher_num = selected_lookup_num

        sqlstmnt = "update payment set void_chk = 'Y', recon = 'Y', dt_Clear = " & Today & " where chk_num = '" & selected_lookup_num & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        'if there is a voucher# used
        'set all voucher.paid to "N"

        If selected_voucher <> 0 Then
            sqlstmnt = "update voucher set paid = 'N' from payment INNER JOIN voucher ON payment.vouch_num = voucher.vouch_num"
            sqlstmnt = sqlstmnt & " where chk_num = '" & selected_voucher & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)
        End If

        'create a new J/E to reverse then one created by the voucher
        Dim JrnlNum As Integer
        JrnlNum = GLMod.GetNextJENum("Regular")

        Dim JeRow As New JeData

        JeRow.AcctNum = selected_DR
        JeRow.Amount = selected_net * -1
        JeRow.JrnlLineNum = 1
        JeRow.JrnlNum = JrnlNum
        JeRow.Post = "N"
        JeRow.JrnlDesc = "chk# " & selected_lookup_num
        JeRow.JrnlSrc = "AP"
        JeRow.JrnlName = "VOID"
        JeRow.EntryType = "AD"
        JeRow.EntryDate = Today
        JeRow.EncumDate = Today
        JeRow.PostDate = CDate("1/1/1900")
        JeRow.OperId = "COMP"
        JeRow.APost = "N"
        JeRow.dflag = "N"
        JeRow.Void = "N"
        JeRowData.Add(JeRow)

        JeRow.AcctNum = selected_DR
        JeRow.Amount = selected_net
        JeRow.JrnlLineNum = 2
        JeRow.JrnlNum = JrnlNum
        JeRow.Post = "N"
        JeRow.JrnlDesc = "chk# " & selected_lookup_num
        JeRow.JrnlSrc = "AP"
        JeRow.JrnlName = "VOID"
        JeRow.EntryType = "AD"
        JeRow.EntryDate = Today
        JeRow.EncumDate = Today
        JeRow.PostDate = CDate("1/1/1900")
        JeRow.OperId = "COMP"
        JeRow.APost = "N"
        JeRow.dflag = "N"
        JeRow.Void = "N"
        JeRowData.Add(JeRow)


        sqlstmnt = "insert into yrgenled values ('"
        Call GLMod.SQLJEDataString(sqlstmnt, JeRowData)
        ETSSQL.ExecuteSQL(sqlstmnt)

        MsgBox("Note this J/E# on your worksheet: " & JrnlNum)



        '    jerow.Fields("Acct_num") = paymentset.Fields("cr_acct_nu") ' bank
        '    jerow.Fields("amount") = tot_net 'paymentset.Fields("net_amt")


        '    jerow.AddNew
        '    jerow.Fields("jrnl_num") = Val(high_je_num) + 1
        '    jerow.Fields("jrnl_line") = 2

        '    jerow.Fields("void") = "N"
        '    jerow.Fields("acct_num") = paymentset.Fields("dr_acct_nu") ' control
        '    jerow.Fields("amount") = Val(tot_chk) * -1 'Val(paymentset.Fields("chk_alloc")) * -1
        '    jerow.Update

        MsgBox("You are about to print two reports.  Make sure your printer is online.")
        sqlstmnt = "update rpthead set beg_num = '" & selected_lookup_num & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)
        prtDestination = 1
        prtreportfilename = ap_report_path & "apckvoid.rpt"
        Dim Crystal As New CrystalForm
        CrystalForm.ShowDialog()
        CrystalForm.BringToFront()
        ' CrystalForm.ShowDialog()            'void voucher report
        prtDestination = 1
        prtreportfilename = ap_report_path & "apcvjrnl.rpt"
        CrystalForm.ShowDialog()
        CrystalForm.BringToFront()
        'CrystalForm.ShowDialog()      
        'printout of j/e

        Call rebuild_grid()

    End Sub

    Private Sub void_no_gl_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles void_no_gl.Click

        If Len(selected_lookup_num) = 0 Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        If selected_lookup_desc <> "N" Then
            MsgBox("Item has been posted")
            Exit Sub
        End If

        Response = MsgBox("Are you sure that you want to void this check?", CType(256 + 4, MsgBoxStyle))
        If Response = 7 Then
            Exit Sub
        End If

        sqlstmnt = "update payment set void_chk = 'Y', recon = 'Y', dt_Clear = " & Today & " where chk_num = '" & selected_lookup_num & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        'if there is a voucher# used
        'set all voucher.paid to "N"

        If selected_voucher <> 0 Then
            sqlstmnt = "update voucher set paid = 'N' from payment INNER JOIN voucher ON payment.vouch_num = voucher.vouch_num"
            sqlstmnt = sqlstmnt & " where chk_num = '" & selected_voucher & "'"
            ETSSQL.ExecuteSQL(sqlstmnt)
        End If

        MsgBox("You are about to print a report.  Make sure your printer is online.")
        sqlstmnt = "update rpthead set beg_num = '" & selected_lookup_num & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        prtDestination = 1
        prtreportfilename = ap_report_path & "apckvoid.rpt"
        CrystalForm.ShowDialog()

        selected_lookup_num = ""
        Call rebuild_grid()

    End Sub
End Class