Option Strict Off
Option Explicit On

Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.Compatibility
Imports Microsoft.VisualBasic.PowerPacks
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Globalization


Public Class apatb_frm
    Inherits System.Windows.Forms.Form

    Public saved_date As Date

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        '
        ' '1 this cleans the apopn table
        '    apopn.Refresh
        '    If apopn.Recordset.RecordCount <> 0 Then
        '        apopn.Recordset.MoveFirst
        '    Do While Not apopn.Recordset.EOF
        '    apopn.Recordset.delete
        '    apopn.Recordset.MoveNext
        '    Loop
        '   End If
        '
        '   'select all vouchers and load to apopn
        ' '2 voucher data control on form
        'sqlstmt = "select * from voucher WHERE voucher.vouch_line = 1 and voucher.dflag = 'N' and voucher.void = 'N' order by voucher.vouch_num"
        'voucher.RecordSource = sqlstmt
        'voucher.Refresh
        'voucher.Recordset.MoveFirst
        '
        'Do While Not voucher.Recordset.EOF
        'apopn.Recordset.AddNew
        'apopn.Recordset.Fields("vouch_num") = voucher.Recordset.Fields("vouch_num")
        'apopn.Recordset.Fields("item_num") = 0
        'apopn.Recordset.Fields("type") = "VCH"
        'apopn.Recordset.Fields("name_key") = voucher.Recordset.Fields("name_key")
        'apopn.Recordset.Fields("screen_nam") = voucher.Recordset.Fields("screen_nam")
        'apopn.Recordset.Fields("vouch_date") = voucher.Recordset.Fields("encum_date")
        'apopn.Recordset.Fields("dt_tbe_pd") = voucher.Recordset.Fields("dt_tbe_pd")
        'apopn.Recordset.Fields("vouch_amt") = voucher.Recordset.Fields("vouch_amt")
        'apopn.Recordset.Fields("vend_inv") = voucher.Recordset.Fields("vend_inv")
        'apopn.Recordset.Fields("paid") = voucher.Recordset.Fields("paid")
        'apopn.Recordset.Fields("sort_name") = voucher.Recordset.Fields("sort_name")
        '
        '
        'apopn.Recordset.Update
        'voucher.Recordset.MoveNext
        'Loop
        '
        ' 'select all payments and load to apopn
        ' '3 voucher data control on form
        'sqlstmt = "select * from payment WHERE payment.dflag = 'N' and payment.void_chk = 'N'order by payment.vouch_num"
        'payment.RecordSource = sqlstmt
        'payment.Refresh
        'payment.Recordset.MoveFirst
        '
        'Do While Not payment.Recordset.EOF
        'apopn.Recordset.AddNew
        'apopn.Recordset.Fields("vouch_num") = payment.Recordset.Fields("vouch_num")
        'apopn.Recordset.Fields("item_num") = 1
        'apopn.Recordset.Fields("type") = "PMT"
        'apopn.Recordset.Fields("name_key") = payment.Recordset.Fields("name_key")
        'apopn.Recordset.Fields("screen_nam") = payment.Recordset.Fields("screen_nam")
        'apopn.Recordset.Fields("vouch_date") = payment.Recordset.Fields("dt_paid")
        'apopn.Recordset.Fields("chk_num") = payment.Recordset.Fields("chk_num")
        'apopn.Recordset.Fields("dt_paid") = payment.Recordset.Fields("dt_paid")
        'apopn.Recordset.Fields("bank_key") = payment.Recordset.Fields("bank_key")
        'apopn.Recordset.Fields("vouch_amt") = payment.Recordset.Fields("chk_alloc") * -1
        'apopn.Recordset.Update
        'payment.Recordset.MoveNext
        'Loop
        '
        ''4. get vouch date in pmt record in apopn
        ''apopn has a record for vouch and for pmts
        'Dim age_date As Date
        'Dim age_vouch As Long
        '
        'sqlstmt = "select * from apopn order by vouch_num, item_num "
        'apopn.RecordSource = sqlstmt
        'apopn.Refresh
        '
        'On Error Resume Next
        '
        'apopn.Recordset.MoveFirst
        'age_date = apopn.Recordset.Fields("vouch_date")
        'age_vouch = apopn.Recordset.Fields("vouch_num")
        'apopn.Recordset.MoveNext
        '
        'Do While Not apopn.Recordset.EOF
        '
        '
        'If age_vouch = apopn.Recordset.Fields("vouch_num") Then
        '    apopn.Recordset.edit
        '    apopn.Recordset.Fields("vouch_date") = age_date
        '    apopn.Recordset.Update
        '    Else
        '    age_date = apopn.Recordset.Fields("vouch_date")
        '    age_vouch = apopn.Recordset.Fields("vouch_num")
        ' End If
        'apopn.Recordset.MoveNext
        'Loop
        '
        ''5  Move the Y in paid field in 0 recs(vch) into paid field in 1 recs(pmt)
        ''this is done with 2 recordsets
        'Set tmp1db = OpenDatabase(ap_data_path & "ap.mdb")
        'sqlstmt = "select * from apopn where item_num = 0 and paid = 'Y' order by vouch_num "
        'apopn.RecordSource = sqlstmt
        'apopn.Refresh
        '
        'Do While Not apopn.Recordset.EOF
        ' sqlstmt = "select * from apopn where item_num = 1 "
        ' sqlstmt = sqlstmt & " and vouch_num = " & apopn.Recordset.Fields("vouch_num")
        '  Set tmp1set = tmp1db.OpenRecordset(sqlstmt, dbOpenDynaset)
        'Do While Not tmp1set.EOF
        '
        '                    tmp1set.edit
        '                    tmp1set.Fields("paid") = "Y"
        '                    tmp1set.Update
        '                    tmp1set.MoveNext
        'Loop
        '
        '
        '    apopn.Recordset.MoveNext
        '
        ' Loop
        '
        ' '6.
        '  '6   3-1-99 lhw
        ' 'put a "N" in paid field for vouchers that have a paid date greater than
        ' 'rpthead end_date--to allow for vouchers marked as paid if paid after the
        ' 'aging date
        '
        ''***************from here down is the old code replaced 7/27/99 with code below
        ''    sqlstmt = "select * from apopn WHERE apopn.item_num = 0 "
        ''    sqlstmt = sqlstmt & " and apopn.dt_paid > " & Chr(35) & txtFields(1) & Chr(35)
        ''    apopn.RecordSource = sqlstmt
        ''    apopn.Refresh
        '
        ''    apopn.Recordset.MoveFirst
        '
        '' Do While Not apopn.Recordset.EOF
        ''    apopn.Recordset.Edit
        ''    apopn.Recordset.Fields("paid") = "N"
        ''    apopn.Recordset.Update
        ''    apopn.Recordset.MoveNext
        '' Loop
        ''***************from here up is the old code
        ''7/27/99 lhw
        ''this is putting the paid to N for items paid after the end date
        ''the report will then show these as unpaid
        '
        'Set tmp1db = OpenDatabase(ap_data_path & "ap.mdb") '**source
        'sqlstmt = "select * from apopn where item_num = 1 and paid = 'Y'  "
        'sqlstmt = sqlstmt & " and apopn.dt_paid > " & Chr(35) & txtfields(1) & Chr(35)
        'apopn.RecordSource = sqlstmt    'pmt records paid=Y after end date
        'apopn.Refresh
        '
        'Do While Not apopn.Recordset.EOF    'find the voucher and set paid=N
        ' sqlstmt = "select * from apopn where item_num = 0 "
        ' sqlstmt = sqlstmt & " and vouch_num = " & apopn.Recordset.Fields("vouch_num")
        '  Set tmp1set = tmp1db.OpenRecordset(sqlstmt, dbOpenDynaset)
        'Do While Not tmp1set.EOF
        '
        '                    tmp1set.edit
        '                    tmp1set.Fields("paid") = "N"
        '                    tmp1set.Update
        '                    tmp1set.MoveNext
        'Loop
        '
        '
        '    apopn.Recordset.MoveNext
        '
        ' Loop
        '
        'MsgBox "Update Complete"
        'Screen.MousePointer = vbDefault
        '
        '    Command1.SetFocus
    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "apopn.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "apopn1.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "apopn2.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Command4_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command4.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "apopnm.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub apatb_frm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter

        Call ets_set_selected()
    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = txtfields.GetIndex(eventSender)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = txtfields(Index).Text
            If etsdate(senddate, "") = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                txtfields(Index).Text = etsdate(senddate, "")
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
            End If
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        Dim Index As Short = txtfields.GetIndex(eventSender)
        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub
End Class