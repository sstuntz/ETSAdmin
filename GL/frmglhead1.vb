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

Public Class frmglhead1
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "headings"
    Public frmWhereClause As String = "" '  " whe = '" & _txtField0_0.Text & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String

    Private Sub RebuildGrid()
        Dim sql As String = "select * from headings order by gl_ref_no"
        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sql)
        End Using
        DataGridView1.DataSource = rs.Tables(0)

    End Sub

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        frmWhereClause = " where gl_ref_no = '" & _txtfields_0.Text & "'"

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

        Call RebuildGrid()
        CmdAdd.Enabled = True
        CmdUpdate.Enabled = False
        CmdEdit.Enabled = False
        For ETS.Common.Module1.num = 0 To 10
            txtfields(CShort(num)).Text = ""
        Next


    End Sub

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Prtlist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles PrtList.Click
        prtDestination = 0
        prtreportfilename = gl_report_path & "glhead.rpt"
        CrystalForm.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            _txtfields_0.Text = DataGridView1.Item("gl_ref_no", e.RowIndex).Value.ToString
            _txtfields_1.Text = DataGridView1.Item("acct_type", e.RowIndex).Value.ToString
            _txtfields_2.Text = DataGridView1.Item("heading_1", e.RowIndex).Value.ToString
            _txtfields_3.Text = DataGridView1.Item("min_1", e.RowIndex).Value.ToString
            _txtfields_4.Text = DataGridView1.Item("max_1", e.RowIndex).Value.ToString
            _txtfields_5.Text = DataGridView1.Item("heading_2", e.RowIndex).Value.ToString
            _txtfields_6.Text = DataGridView1.Item("min_2", e.RowIndex).Value.ToString
            _txtfields_7.Text = DataGridView1.Item("max_2", e.RowIndex).Value.ToString
            _txtfields_8.Text = DataGridView1.Item("heading_3", e.RowIndex).Value.ToString
            _txtfields_9.Text = DataGridView1.Item("min_3", e.RowIndex).Value.ToString
            _txtfields_10.Text = DataGridView1.Item("max_3", e.RowIndex).Value.ToString
            CmdEdit.Enabled = True
        End If


    End Sub

    Private Sub frmglhead1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        If function_type = "LOOKUP_ONLY" Then
            CmdAdd.Enabled = False
            CmdEdit.Enabled = False
        End If
        Call RebuildGrid()

    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))

        If CBool(CInt(KeyAscii = 13) Or CInt(KeyAscii = 9)) Then

            Select Case Index
                Case 0
                    If entry_type = "ADD" Then 'test if dup ref no
                        If ValidateDatumYN("headings", "gl_ref_no", txtfields(0).Text) = "Y" Then
                            MsgBox("Reference number has been used. Please enter a different number.")
                            Exit Sub
                        End If
                    End If

                Case 1
                    txtfields(Index).Text = UCase(txtfields(Index).Text)
                    If txtfields(Index).Text <> "AST" Then
                        If txtfields(Index).Text <> "CASS" Then
                            If txtfields(Index).Text <> "LIA" Then
                                If txtfields(Index).Text <> "CAP" Then
                                    If txtfields(Index).Text <> "REV" Then
                                        If txtfields(Index).Text <> "EXP" Then
                                            MsgBox("Please enter one of AST or CASS or LIA or CAP or REV or EXP")
                                            Call ets_set_selected()
                                            GoTo EventExitSub
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                Case 2, 5, 8
                    txtfields(Index).Text = UCase(txtfields(Index).Text)


                Case 10
                    CmdUpdate.Enabled = True
            End Select

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If


EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub


    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdEdit.Click
        txtfields(0).Enabled = False
        CmdAdd.Enabled = False
        entry_type = "EDIT"
        txtfields(1).Focus()
    End Sub

    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        _txtfields_0.Text = ""
        _txtfields_1.Text = ""
        _txtfields_2.Text = ""
        _txtfields_3.Text = ""
        _txtfields_4.Text = ""
        _txtfields_5.Text = ""
        _txtfields_6.Text = ""
        _txtfields_7.Text = ""
        _txtfields_8.Text = ""
        _txtfields_9.Text = ""
        _txtfields_10.Text = ""
        entry_type = "ADD"
        txtfields(0).Enabled = True

    End Sub

End Class