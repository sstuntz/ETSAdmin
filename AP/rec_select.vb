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
Imports ETS.ApMod


Public Class rec_select
    Inherits System.Windows.Forms.Form

    Dim SelectedIndex As Integer


    Private Sub rebuild_grid()
        Dim sql As String = "select * from rec_name order by vouch_name"
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

        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing


    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("vouch_num", e.RowIndex).Value.ToString
            selected_lookup_desc = DataGridView1.Item("vouch_name", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub


    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
        entry_type = "AddRECURRING"
        Dim message As String = InputBox("Enter the name of voucher up to 30 characters.")
        selectedcell = False

retry:
        Select Case Message.Length
            Case 0
                MsgBox("Nothing entered.")
                Exit Sub
            Case Is > 30
                MsgBox("Description Too Long.")
                GoTo retry
        End Select

        Dim vnum As Integer = GetNextVouchNum("AddRECURRING")
        selected_lookup_num = CStr(vnum)

        Dim frmvouchent As New frmvouchent
        frmvouchent.ShowDialog()

        If entry_type <> "CANCEL" Then
            'add name if did not cancel from vouchent
            Using db As Database = New Database(top_data_path)
                Dim sql As String = "insert into rec_name (vouch_num,vouch_name) values (" & vnum & ", '" & Message & "' )"
                ETSSQL.ExecuteSQL(sql)
            End Using
        End If
        entry_type = "ADD"

        rebuild_grid()

    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        prtDestination = 0
        prtreportfilename = ap_report_path & "aprecured.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub Delete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles delete.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        If MsgBox("Do you really want to delete this record?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle)) = vbYes Then
            '1 from rec_name
            sqlstmnt = " delete from rec_name where vouch_num = " & selected_lookup_num
            ETSSQL.ExecuteSQL(sqlstmnt)

            '2 delete from rec_vouch data2
            sqlstmnt = " delete from rec_vouc where vouch_num = " & selected_lookup_num
            ETSSQL.ExecuteSQL(sqlstmnt)
            MsgBox("Record has been deleted from recurring voucher file.")
        End If

        Call rebuild_grid()

        ' MsgBox("Record has been deleted from recurring voucher file.")     'moved to above 06/13/2012
    End Sub

    Private Sub rec_select_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Call rebuild_grid()
        function_type = "DATA_ENTRY" 'so you can select
    End Sub

    Private Sub edit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        entry_type = "RECURRING"
        Dim frmvouchent As New frmvouchent
        frmvouchent.ShowDialog()
        Call rebuild_grid()
    End Sub


End Class