Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports ps.common
Imports System.Data.SqlClient
Imports Valid_YN


Public Class frm_program
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "program"
    Public frmWhereClause As String = ""
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String

    Private Sub RebuildGrid()
        Dim sql As String = "select prog_num, prog_Desc from program order by prog_num"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)

    End Sub

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        frmWhereClause = " where prog_num = '" & _txtField0_0.Text & "'"

        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                numstr = Me.cntrl.Name.ToString.Substring(11)
                TagColumnName = Me.cntrl.Tag.ToString
                RowData.Find(AddressOf FindColumnName)
                num1 = CInt(numstr)
                RowData.Item(num1).ActualData = Me.cntrl.Text
            End If
        Next
        Select Case entry_type
            Case "ADD"
                Call ETSSQL.InsertData(frmTableName, RowData)
            Case "EDIT"
                Call ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)
        End Select
        Call RebuildGRid()

    End Sub

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
        _txtField0_0.Text = ""
        _txtField1_1.Text = ""
        entry_type = "ADD"
        _txtField0_0.Enabled = True


        'For Each Me.cntrl In Me.Controls
        '    If TypeOf Me.cntrl Is TextBox Then
        '        numstr = Me.cntrl.Name.ToString.Substring(11)
        '        TagColumnName = Me.cntrl.Tag.ToString
        '        RowData.Find(AddressOf FindColumnName)
        '        num1 = CInt(numstr)
        '        RowData.Item(num1).ActualData = Me.cntrl.Text
        '    End If
        'Next
        'On Error Resume Next
        'Call ETSSQL.InsertData(frmTableName, RowData)
        'If Err.ToString <> "" Then
        '    MsgBox("Already added")
        'End If
        'Call RebuildGRid()

    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub PrintRpt_click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PrintRpt.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glprog.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub frm_program_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Normal     'added lhw 06/19/2012
        ctrform(Me)

        If function_type = "LOOKUP_ONLY" Then
            cmdAdd.Enabled = False
            cmdUpdate.Enabled = False
        End If

        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        DataGridView1.Columns.Add("prog_num", "Program #")
        DataGridView1.Columns.Item(0).DataPropertyName = "prog_num"
        DataGridView1.Columns.Add("prog_desc", "Description")
        DataGridView1.Columns.Item(1).DataPropertyName = "prog_desc"

        selectedcell = False

        RebuildGRid()


    End Sub

    Private Sub txtField0_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField0.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField0.GetIndex(CType(eventSender, TextBox))
        'this is a test for a number already used

        If KeyAscii = 13 Or KeyAscii = 9 Then
            Select Case Index
                Case 0
                    If entry_type = "ADD" Then
                        If checkYN("prog", "acct_pgm", _txtField0_0.Text) = "Y" Then
                            MsgBox(" This Program Number has been used.")
                            GoTo eventexitsub
                            Exit Sub
                        End If
                    End If
            End Select
            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0

        End If
eventexitsub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtField1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtField1.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtField1.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Then
            cmdUpdate.Enabled = True
            cmdUpdate.Focus()
            cmdAdd.Enabled = True
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.RowIndex <> -1 Then
            _txtField0_0.Text = DataGridView1.Item("prog_num", e.RowIndex).Value.ToString
            _txtField1_1.Text = DataGridView1.Item("prog_Desc", e.RowIndex).Value.ToString
        End If
    End Sub
    Private Sub cmdedit_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        entry_type = "EDIT"
        _txtField0_0.Enabled = False

    End Sub
    Private Sub cmddel_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmddel.Click

        sqlstmnt = "delete from program where prog_num = '" & _txtField0_0.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        Call RebuildGrid()

    End Sub


End Class