Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETSCommon.Database
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Configuration
Imports System.Data.SqlClient

Friend Class disablookup
    Inherits System.Windows.Forms.Form
    '****************
    'revision History
    'original date of this form is 9/23/96 -SCS

    '****************

    Private Sub rebuild_grid()

        Dim sql As String = "select disab_num, disab_desc from cc_disab"
        Dim rs As DataSet
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            rs = db.FillDataSet(sql)
        End Using
        Disabgrid.DataSource = rs.Tables(0)

    End Sub

    Private Sub disabgrid_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Disabgrid.CellContentClick
        selectedcell = True
        selected_lookup_num = Disabgrid.Item("disab_num", e.RowIndex).Value.ToString
        selected_lookup_desc = Disabgrid.Item("disab_desc", e.RowIndex).Value.ToString

    End Sub

    Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        entry_type = ""
        Me.Close()

    End Sub

    Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
        On Error Resume Next
        entry_type = "ADD"
        frmdisab.ShowDialog()
        'clear the grid

    End Sub

    Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles edit.Click
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If
        If selected_lookup_num.Length = 0 Then Stop
        entry_type = "EDIT"
        frmdisab.ShowDialog()
        Call rebuild_grid()
        selectedcell = False

    End Sub

    Private Sub disablookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
            addacct.Enabled = False
            edit.Enabled = False
        End If
        rebuild_grid()
        'Dim sql As String = "select disab_num, disab_desc from cc_disab"
        'Dim rs As DataSet
        'Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
        '    rs = db.FillDataSet(sql)
        'End Using
        'Disabgrid.DataSource = rs.Tables(0)
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        selected_lookup_num = " " '
        selected_screen_nam = " "
        selected_plan_desc = " "

        Me.Close()

    End Sub

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        'added this button 2/21/02 lhw
        If selectedcell = False Then
            MsgBox("Nothing selected")
            Exit Sub
        End If

        'move the grid data to the transfer variables
        '   Grid1.Col = 0
        '  selected_lookup_num = Grid1.Text
        ' Grid1.Col = 1
        'selected_lookup_desc = Grid1.Text


        Response = MsgBox("Do you really want to delete this record?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, MsgBoxStyle))
        If Response = MsgBoxResult.Yes Then
            sqlstmnt = " select * from cc_disab where disab_num = " & Chr(34) & selected_lookup_num & Chr(34)
            '       Data1.RecordSource = sqlstmnt
            '      Data1.Refresh

            '   Do While Not Data1.Recordset.EOF
            '  Data1.Recordset.Delete
            ' Data1.Recordset.MoveNext
            'Loop

        End If


        '   Data1.RecordSource = "SELECT * From cc_disab ORDER BY disab_num"

        'Call rebuild_grid

        'clear the grid  added next 13 line to rebuild grid

        MsgBox("Record has been deleted from cc_disab file.")

    End Sub

End Class