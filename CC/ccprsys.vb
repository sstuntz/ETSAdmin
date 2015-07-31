Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports ps.common

Public Class ccprsys
    Inherits System.Windows.Forms.Form
    '****************
    'revision History
    'original date of this form is 9/23/96 -SCS

    '****************

    Public sqlstmnt As String
    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "ccsys"
    Public frmWhereClause As String = "where Agency = 1"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control
    Public numstr As String


    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        'go thru controls and those with tags get moved to etsdata
        Dim cntrl As Control
        Dim cmbox As ComboBox
        For Each cntrl In Me.Controls
            If Not (String.IsNullOrEmpty(Trim(CStr(cntrl.Tag)))) Then
                Select Case cntrl.GetType.ToString
                    Case "System.Windows.Forms.TextBox"
                        numstr = cntrl.Name.ToString.Substring(11)
                        TagColumnName = cntrl.Tag.ToString
                        RowData.Find(AddressOf FindColumnName)
                        num1 = CInt(numstr)
                        RowData.Item(num1).ActualData = cntrl.Text
                    Case "System.Windows.Forms.ComboBox"
                        numstr = cntrl.Name.ToString.Substring(8)
                        cmbox = CType(cntrl, ComboBox)
                        TagColumnName = cmbox.Tag.ToString
                        RowData.Find(AddressOf FindColumnName)
                        num1 = CInt(numstr) + 9
                        RowData.Item(num1).ActualData = cmbox.SelectedItem().ToString
                End Select
            End If
        Next

        Select Case entry_type.ToString
            Case "Add"
                Call cmdInsertData()
            Case "Edit"
                Call cmdUpdateData()
        End Select

        ''if min wage changed then update job file
        sqlstmnt = "update ccjob set min_wage = " & RowData.Item(5).ActualData
        sqlstmnt = sqlstmnt & "  where min_wage <> 0"
        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            db.ExecuteUpdate(sql)
        End Using

        Me.Dispose()

    End Sub

    Private Sub frmccprsys_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'basic load data for all data entry forms
        ctrform(Me)
        For Each Me.cntrl In Me.Controls
            If TypeOf cntrl Is TextBox Then
                numstr = cntrl.Name.ToString.Substring(11)
                TagColumnName = cntrl.Tag.ToString
                RowData.Find(AddressOf FindColumnName)
                num1 = CInt(numstr)
                If RowData.Item(num1).ActualData IsNot Nothing Then
                    'If Len(frmdata.ActualData) <> 0 Then
                    '    If frmdata.DataType = "datetime" Then
                    '        cntrl.Text = CDate(frmdata.ActualData).ToShortDateString
                    '    Else
                    cntrl.Text = RowData.Item(num1).ActualData.ToString
                    ' End If
                    'End If
                End If
                '
            End If
        Next
        num1 = 0
        Dim sort_array(10) As String
        sort_array(0) = "dept_num"
        sort_array(1) = "sort_name"
        sort_array(2) = "desc1"
        sort_array(3) = "desc2"
        sort_array(4) = "desc3"
        sort_array(5) = "printck"
        sort_array(6) = "last_choice"
        sort_array(7) = ""

        Dim cmbox As New ComboBox
        For Each Me.cntrl In Me.Controls
            If TypeOf cntrl Is ComboBox Then
                For ETS.Common.Module1.num1 = 0 To 7
                    cmbox = CType(cntrl, ComboBox)
                    cmbox.Items.Add(sort_array(ETS.Common.Module1.num1))
                Next
                'put the right text into the combobox
                ETS.Common.Module1.num1 = CInt(cmbox.Name.ToString.Substring(8)) + 9       'column number
                For ETS.Common.Module1.num = 0 To 7
                    If sort_array(ETS.Common.Module1.num) = RowData.Item(ETS.Common.Module1.num1).ActualData Then
                        cmbox.SelectedIndex = ETS.Common.Module1.num
                    End If
                Next
            End If
        Next

        _txtfields_5.Text = String.Format("{0:C}", _txtfields_5.Text)
        _txtfields_6.Text = String.Format("{0:C}", _txtfields_6.Text)
        _txtfields_7.Text = String.Format("{0:C}", _txtfields_7.Text)
        _txtfields_15.Text = String.Format("{0:C}", _txtfields_15.Text)

    End Sub

    Private Sub _txtfields_0_enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _txtfields_0.Enter, _txtfields_1.Enter, _txtfields_2.Enter, _txtfields_3.Enter, _txtfields_4.Enter, _txtfields_5.Enter, _txtfields_6.Enter, _txtfields_7.Enter, _txtfields_8.Enter, _txtfields_15.Enter, _txtfields_16.Enter, _txtfields_17.Enter, _txtfields_18.Enter, _txtfields_19.Enter
        Call ets_set_selected()
    End Sub

    Private Sub _txtfields_1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _txtfields_8.KeyPress, _txtfields_16.KeyPress, _txtfields_17.KeyPress, _txtfields_18.KeyPress, _txtfields_19.KeyPress
        Me.ActiveControl.Text = Me.ActiveControl.Text.ToUpper()
        If Me.ActiveControl.Text <> "N" And Me.ActiveControl.Text <> "Y" Then
            MsgBox("Please enter a Y or N")
            Me.ActiveControl.Focus()
        End If
    End Sub

    Private Sub _txtfields_2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _txtfields_0.KeyPress, _txtfields_1.KeyPress, _txtfields_2.KeyPress, _txtfields_3.KeyPress, _txtfields_4.KeyPress, _txtfields_5.KeyPress, _txtfields_6.KeyPress, _txtfields_7.KeyPress, _txtfields_8.KeyPress, _txtfields_15.KeyPress, _txtfields_16.KeyPress, _txtfields_17.KeyPress, _txtfields_18.KeyPress, _txtfields_19.KeyPress

        If e.KeyChar = Chr(13) Or e.KeyChar = Chr(9) Then
            e.Handled = True        'gets rid of beep
            'If Me.ActiveControl.Name.Contains(0.ToString) Then
            '    Me.ActiveControl.BackColor = Color.White
            'End If
            ' For num = 0 To 19
            'If Me.ActiveControl.Name.Contains(num.ToString) Then
            Me.ActiveControl.BackColor = Color.White
            'End If
            '   Next
            If Me.ActiveControl.Name.Contains(4.ToString) Then
                _txtfields_4.Text = _txtfields_4.Text.ToUpper()
                Me.ActiveControl.BackColor = Color.White
            End If
            If Me.ActiveControl.Name.Contains(5.ToString) Then
                _txtfields_5.Text = String.Format("{0:n2}", (_txtfields_5.Text))
            End If
            If Me.ActiveControl.Name.Contains(6.ToString) Then
                _txtfields_6.Text = String.Format("{0:n2}", _txtfields_6.Text)
            End If
            If Me.ActiveControl.Name.Contains(15.ToString) Then
                If CDbl(_txtfields_15.Text) > 1 Or CDbl(_txtfields_15.Text) < 0 Then
                    MsgBox("Please enter less than 1 and more than 0.")
                    Exit Sub
                End If
                _txtfields_15.Text = String.Format("{0:n2}", _txtfields_15.Text)
            End If

            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If

    End Sub

    Private Sub _txtfields_0_leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _txtfields_0.Leave, _txtfields_1.Leave, _txtfields_2.Leave, _txtfields_3.Leave, _txtfields_4.Leave, _txtfields_5.Leave, _txtfields_6.Leave, _txtfields_7.Leave, _txtfields_8.Leave, _txtfields_15.Leave, _txtfields_16.Leave, _txtfields_17.Leave, _txtfields_18.Leave, _txtfields_19.Leave
        '   Call ets_de_selected()
        Me.ActiveControl.BackColor = Color.FromArgb(255, 255, 255)
        '  txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Dispose()
    End Sub

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub cmdInsertData()

        sqlstmnt = ""
        sqlstmnt = String.Format("Insert into {0}  values ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20})", frmTableName, _
                                 Database.StringParam(RowData.Item(0).ActualData), _
                                 Database.StringParam(RowData.Item(1).ActualData), _
                                 Database.StringParam(RowData.Item(2).ActualData), _
                                 Database.StringParam(RowData.Item(3).ActualData), _
                                 Database.StringParam(RowData.Item(4).ActualData), _
                                 Database.StringParam(RowData.Item(5).ActualData), _
                                 Database.StringParam(RowData.Item(6).ActualData), _
                                 Database.StringParam(RowData.Item(7).ActualData), _
                                 Database.StringParam(RowData.Item(8).ActualData), _
                                 Database.StringParam(RowData.Item(9).ActualData), _
                                 Database.StringParam(RowData.Item(10).ActualData), _
                                 Database.StringParam(RowData.Item(11).ActualData), _
                                 Database.StringParam(RowData.Item(12).ActualData), _
                                 Database.StringParam(RowData.Item(13).ActualData), _
                                 Database.StringParam(RowData.Item(14).ActualData), _
                                 Database.StringParam(RowData.Item(15).ActualData), _
                                 Database.StringParam(RowData.Item(16).ActualData), _
                                 Database.StringParam(RowData.Item(17).ActualData), _
                                 Database.StringParam(RowData.Item(18).ActualData), _
                                 Database.StringParam(RowData.Item(19).ActualData))



        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt
            db.ExecuteUpdate(sql)
        End Using

        Me.Dispose()


    End Sub

    Private Sub cmdUpdateData()
        sqlstmnt = ""
        sqlstmnt = String.Format("update {0} set {1} = {2},{3} = {4},{5} = {6},{7} = {8},{9} = {10},{11} = {12},{13} = {14},{15} = {16},{17} = {18},{19} = {20},{21} = {22},{23} = {24},{25} = {26},{27} = {28},{29} = {30},{31} = {32},{33} = {34},{35} = {36},{37} = {38}, {39} = {40} where {41} ", frmTableName, _
                                (RowData.Item(0).ColumnName), _
                                 Database.StringParam(RowData.Item(0).ActualData), _
                                 (RowData.Item(1).ColumnName), _
                                 Database.StringParam(RowData.Item(1).ActualData), _
                                 (RowData.Item(2).ColumnName), _
                                 Database.StringParam(RowData.Item(2).ActualData), _
                                (RowData.Item(3).ColumnName), _
                                 Database.StringParam(RowData.Item(3).ActualData), _
                                (RowData.Item(4).ColumnName), _
                                 Database.StringParam(RowData.Item(4).ActualData), _
                                 (RowData.Item(5).ColumnName), _
                                 Database.StringParam(RowData.Item(5).ActualData), _
                               (RowData.Item(6).ColumnName), _
                                 Database.StringParam(RowData.Item(6).ActualData), _
        (RowData.Item(7).ColumnName), _
                                 Database.StringParam(RowData.Item(7).ActualData), _
         (RowData.Item(8).ColumnName), _
                                 Database.StringParam(RowData.Item(8).ActualData), _
         (RowData.Item(9).ColumnName), _
                                 Database.StringParam(RowData.Item(9).ActualData), _
         (RowData.Item(10).ColumnName), _
                                Database.StringParam(RowData.Item(10).ActualData), _
        (RowData.Item(11).ColumnName), _
                                 Database.StringParam(RowData.Item(11).ActualData), _
         (RowData.Item(12).ColumnName), _
                                 Database.StringParam(RowData.Item(12).ActualData), _
         (RowData.Item(13).ColumnName), _
                                 Database.StringParam(RowData.Item(13).ActualData), _
         (RowData.Item(14).ColumnName), _
                                 Database.StringParam(RowData.Item(14).ActualData), _
        (RowData.Item(15).ColumnName), _
                                 Database.StringParam(RowData.Item(15).ActualData), _
        (RowData.Item(16).ColumnName), _
                                 Database.StringParam(RowData.Item(16).ActualData), _
        (RowData.Item(17).ColumnName), _
                                 Database.StringParam(RowData.Item(17).ActualData), _
        (RowData.Item(18).ColumnName), _
                                 Database.StringParam(RowData.Item(18).ActualData), _
        (RowData.Item(19).ColumnName), _
                                Database.StringParam(RowData.Item(19).ActualData), _
                                 frmWhereClause)

        Using db As Database = New Database(top_data_path)
            ' Dim sql As String = sqlstmnt
            db.ExecuteUpdate(sqlstmnt)
        End Using
        Me.Dispose()
    End Sub

End Class