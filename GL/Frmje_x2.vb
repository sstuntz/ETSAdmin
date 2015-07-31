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
Imports Valid_YN
Imports ETS

Public Class frmje_x2
    Inherits System.Windows.Forms.Form

    Public JeLookupNum As String
    Dim JESource As String
    Dim JEUpdate As String
    Public JeRowData As List(Of JeData)
    Public NextJENum As Integer

    Private Sub rebuild_grid()
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(JESource)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        selected_lookup_num = ""
        selected_lookup_desc = ""
    End Sub

    Private Sub DataGridView1_cellclick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            JeLookupNum = DataGridView1.Item("je_tbl", e.RowIndex).Value.ToString
        End If
    End Sub

    Private Sub Add_sel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Add_sel.Click

        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        If Len(encum_date.Text) = 0 Then
            MsgBox("No date entered. Please Enter.")
            Exit Sub
        End If
        'do the processing
        'check the acct nums one more time
        'get next je num
        'write it out 
        'update post date in stand je
        JEUpdate = "select je_stand.*, chacct.acct_desc from je_Stand inner join chacct on je_Stand.acct_num = chacct.acct_num where jrnl_num = " & JeLookupNum
        JeRowData = ETSSQL.GetJeData(JEUpdate)

        'chk acct nums
        valid_check = "N"

        For Each JeRow In JeRowData
            If etsacctnum_chk(JeRow.AcctNum) = "N" Then
                msg = "There is an invalid account.  Please repair it by editing that Standard J/E and then re-processing."
                GoTo notdone
                Exit Sub
            End If
        Next

        NextJENum = GLMod.GetNextJENum("Regular")

        For Each jerow In JeRowData
            jerow.JrnlNum = NextJENum
            jerow.EntryDate = Today
            jerow.EncumDate = CDate(encum_date.Text)
        Next

        sqlstmnt = "insert into yrgenled values ('"
        Call GLMod.SQLJEDataString(sqlstmnt, JeRowData)
        MsgBox("The Journal entry number used is = " & NextJENum)

        'update stnad list with post date

        JEUpdate = "update stand_list set post_date = '" & CDate(encum_date.Text) & "' where je_tbl = " & JeLookupNum
        ETSSQL.ExecuteSQL(JEUpdate)
        MsgBox("This will now print the Journal Entry just created")
        prtDestination = 0
        prtreportfilename = gl_report_path & "glstjrnl.rpt"
        CrystalForm.ShowDialog()
        Call rebuild_grid()
        selected_lookup_num = ""
        JeRowData.Clear()
        Exit Sub
notdone:
        MsgBox(msg)
        rebuild_grid()


    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub AlphaList_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles AlphaList.Click
        JESource = "select je_tbl,je_desc,post_Date from stand_list order by je_desc"
        Call rebuild_grid()
    End Sub

    Private Sub PostDateList_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PostDateList.Click
        JESource = "select je_tbl,je_desc,post_Date from stand_list order by post_Date, je_desc"
        Call rebuild_grid()
    End Sub

    Private Sub encum_date_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles encum_date.Enter
        ets_set_selected()
    End Sub

    Private Sub encum_date_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles encum_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            valid_Date = "N"
            senddate = encum_date.Text
            If etsdate(senddate, valid_Date) <> "N" Then
                encum_date.Text = etsdate(senddate, valid_Date)
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
            Else
                MsgBox("Bad date")
                Form.ActiveForm.ActiveControl.BackColor = Color.Aqua()
                GoTo EventExitSub
            End If
        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub encum_date_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles encum_date.Leave
        encum_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub frmje_x2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        JESource = "select je_tbl,je_desc,post_Date from stand_list order by je_tbl"
        Call rebuild_grid()
        Me.BringToFront()
        selectedcell = False
        function_type = "DATA_ENTRY" 'so you can select

    End Sub

End Class