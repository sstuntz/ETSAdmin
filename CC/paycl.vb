Option Strict On
Option Explicit On
Imports ETS.Common.Module1

Public Class frmpaycl
    Inherits System.Windows.Forms.Form

    '****************
    'revision History
    'original date of this form is 01/24/1998 - SCS

    '****************
    'Option Explicit



    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        On Error Resume Next
        ' Data1.UpdateRecord
        If Err.Number = 524 Then
            MsgBox("You have not entered all data required. Please complete.")
            Exit Sub
        End If
        'Data1.Recordset.Bookmark = Data1.Recordset.LastModified
        Me.Close()
    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub


    Private Sub frmpaycl_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)

        Select Case entry_type

            Case "ADD"
                'Data1.RecordSource = "select * from cc_paycl where pay_Class = ''"
                'Data1.Refresh
                'Data1.Recordset.AddNew

            Case "EDIT"
                '   Data1.RecordSource = "select * from cc_paycl where pay_Class = " & Chr(34) & selected_lookup_num & Chr(34)
                '  Data1.Refresh
                ' Data1.Recordset.edit
                'txtFields(0) = Data1.Recordset(0)
                ' txtFields(1) = Data1.Recordset(1)
                'txtFields(0).Enabled = False
        End Select

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
                Case 0, 2, 3, 4
                    txtFields(Index).Text = UCase(txtFields(Index).Text)
                    'valid_name = "N"
                    'selected_name_key = ""

                    ' If Val(txtFields(Index)) = 0 Then
                    ' Call namelookup

                    'txtFields(Index) = selected_name_key
                    'End If

                    'Call chkname(txtFields(Index))

                    'If valid_name = "N" Then
                    'MsgBox (" Invalid Number")
                    'Call ets_set_selected
                    'Exit Sub
                    'End If


                    'the following code is used to get additional data from nam_Addr
                    'db = gl_data_path & "glname.mdb"   'lookup to glname
                    'Set tmpdb = OpenDatabase(db)
                    'Set tmpset = tmpdb.OpenRecordset(" nam_addr", dbOpenDynaset)

                    'sqlstmnt = " name_key = "
                    'sqlstmnt = sqlstmnt & Chr(34) & txtFields(Index) & Chr(34)

                    'case 1

                    '   valid_dpt = " N "
                    'senddpt = txtFields(Index)

                    'retdpt = ""
                    'retdptdesc = ""

                    'Call etsdptnum_chk(senddpt, retdpt, retdptdesc, valid_dpt)

                    'If valid_dpt = "N" Then
                    ' MsgBox ("Not a valid department number.")
                    'Call ets_set_selected
                    'Exit Sub
                    'End If

                    'txtFields(Index) = retdpt
                    'text1.Text = retdptdesc

                    'Case 2

                    ' valid_Date = "N"
                    'senddate = txtFields(Index).Text
                    'Call etsdate(senddate, retdate, valid_Date)

                    'If valid_Date <> "N" Then
                    ' txtFields(Index).Text = retdate
                    'txtFields(Index).Text = CVDate(txtFields(Index).Text)
                    'the line below shows how to add days to a date and give a new date
                    'duedate = DateAdd(, 30, txtfields(index))
                    'Else
                    'MsgBox (" Bad Date")
                    'Call ets_set_selected
                    'Exit Sub

                    'End If
            End Select

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Leave
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub
End Class