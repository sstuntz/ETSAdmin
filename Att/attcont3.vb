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

Public Class attcont3
    Inherits System.Windows.Forms.Form

    Public ds(50, 50, 50) As String
    Public TagColumnName As String
    Public frmTableName As String = "cc_cont"
    Public frmWhereClause As String = " where contract_key = '" & selected_contract_key & "'"
    Public RowData As List(Of ETSData) = ETSSQL.GetData(frmTableName, frmWhereClause)
    Public num1 As Integer = 0
    Public cntrl As Control

    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click

        Call SaveData()
        Me.Close()
        Me.Dispose()

    End Sub

    Private Function FindColumnName(ByVal CName As ETSData) As Boolean
        If CName.ColumnName = TagColumnName Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub attcont3_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Normal     'added lhw 06/19/2012
        ctrform(Me)
        Me.BringToFront()
        sqlstmnt = "select * from cc_cont where contract_key =  '" & selected_contract_key & "'"

        If Len(selected_grouping) <> 0 Then
            sqlstmnt = sqlstmnt & " and fiscal_yr = '" & selected_grouping & "'"
        End If

        Dim ContractData As New List(Of ContractData)
        ContractData = ETSSQL.GetContractData(sqlstmnt)

        entry_type = "EDIT"

        Dim rs As New Collection
        RowData = ETSSQL.GetData(frmTableName, frmWhereClause)
        For Each Me.cntrl In Me.Controls
            If TypeOf cntrl Is TextBox Then
                If Not Len(Me.cntrl.Tag) = 0 Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                    If Len(frmdata.ActualData) <> 0 Then
                        If frmdata.DataType = "datetime" Or frmdata.DataType = "DATE" Then
                            cntrl.Text = CDate(frmdata.ActualData).ToShortDateString
                        Else
                            cntrl.Text = frmdata.ActualData.ToString
                        End If
                    End If
                End If
            End If
        Next

        current_fiscal = CInt(CStr(Year(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 6, Today))))

        If Len(selected_grouping) = 0 Then
            txtFields(0).Enabled = False
            txtFields(1).Enabled = False
            txtFields(2).Enabled = False
        End If

        sqlstmnt = "select * from cc_cont where contract_key =  '" & selected_contract_key & "'"

        txtFields(0).Text = selected_cont_id_num
        txtFields(1).Text = selected_mmars_num
        txtFields(2).Text = selected_amend_num

        ' fill in the extra info
        Dim BillPerson As New NameAddrData
        BillPerson = ETSSQL.GetOneNameAddrData("select * from nam_addr where name_key = '" & selected_name_key & "'")
        _Text1_0.Text = BillPerson.ScreenNam
        _Text1_1.Text = BillPerson.Address1
        _Text1_2.Text = BillPerson.Address2
        _Text1_3.Text = BillPerson.City
        _Text1_4.Text = BillPerson.State
        _Text1_5.Text = BillPerson.Zip4
        _Text1_6.Text = BillPerson.Telephone
        TextBox1.Text = BillPerson.Email
        TextBox2.Text = BillPerson.Address3

    End Sub

    Private Sub retpg1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles retpg1.Click
        Call SaveData()
        Me.Dispose()
        Me.Close()
        attcont2.ShowDialog()
    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index

                Case 0, 7, 50, 36, 39, 40, 41, 42, 43, 47
                    txtFields(Index).Text = UCase(txtFields(Index).Text)

                Case 3
                    'look up and fill in name and address info
                    function_type = "DATA_ENTRY"
                    package_Type = "TY"
                    valid_name = "N"

                    If Val(txtFields(Index).Text) = 0 Then
                        frmnamechk.ShowDialog()
                        txtFields(Index).Text = selected_name_key
                        _Text1_0.Text = selected_screen_nam
                    End If

                    Call chkname(txtFields(Index).Text)
                    _Text1_0.Text = selected_screen_nam
                    If valid_name = "N" Then
                        MsgBox(" Invalid Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If


                    'the following code is used to get additional data from nam_Addr
                    db = gl_data_path & "glname.mdb" 'lookup to glname
                    'tmpdb = DAODBEngine_definst.OpenDatabase(db)
                    'tmpset = tmpdb.OpenRecordset("nam_addr", dao.RecordsetTypeEnum.dbOpenDynaset)

                    'sqlstmnt = " name_key = "
                    'sqlstmnt = sqlstmnt & Chr(34) & txtFields(Index).Text & Chr(34)
                    'tmpset.FindFirst(sqlstmnt)

                    'Text1(1).Text = tmpset.Fields("address1").Value
                    ''     text1(2).Text = tmpset.Fields("address2")
                    'Text1(3).Text = tmpset.Fields("city").Value
                    'Text1(4).Text = tmpset.Fields("state").Value
                    'Text1(5).Text = tmpset.Fields("zip4").Value
                    ''     text1(6).Text = tmpset.Fields("telephone")


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

    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Leave
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub

    Private Sub SaveData()
        'test for completeness on txtfields only
        'fields 0 1 2 3 6 9 16 17 18 20 40 49


        'For num = 0 To 100
        '    msg = "," & CStr(num) & ","
        '    Response = InStr(",0,1,2,3,6,9,16,17,18,20,40,49,", msg)
        '    If Response <> 0 Then
        '        If Len(Txtfields(num).Text) = 0 Then
        '            MsgBox("You must fill in all required fields.")
        '            Txtfields(num).Focus()
        '            Exit Sub
        '        End If
        '    End If

        'Next


        For Each Me.cntrl In Me.Controls
            If TypeOf Me.cntrl Is TextBox Then
                If Not Len(Me.cntrl.Tag) = 0 Then
                    TagColumnName = Me.cntrl.Tag.ToString
                    If Len(TagColumnName) <> 0 Then
                        Dim frmdata As ETSData = RowData.Find(AddressOf FindColumnName)
                        frmdata.ActualData = Me.cntrl.Text
                    End If
                End If
            End If
        Next

        'always edit after page 1


                Call ETSSQL.UpdateData(frmTableName, frmWhereClause, RowData)

    End Sub
End Class