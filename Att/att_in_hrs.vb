Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient

Public Class att_in_hrs
    Inherits System.Windows.Forms.Form

    Private Sub Delete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Delete.Click
        '	medopn.Recordset.delete()
        del_flag = "Y"

        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click

        If Val(txtfields(2).Text) = 0 Then del_flag = "Y"
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub att_in_hrs_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ctrform(Me)

        sqlstmnt = "select * from medopn_tmp where from_date =  '" & saved_Date
        sqlstmnt = sqlstmnt & "' and name_key = '" & selected_name_key & "' order by from_Date, place_serv"

        'now get the second record

        'medopn.RecordSource = sqlstmnt
        'medopn.Refresh()

        'Select Case medopn.Recordset.RecordCount

        '	Case 0 'first record on screen but not yet created so do a different day
        '		sqlstmnt = "select * from medopn_tmp where name_key = " & Chr(34) & selected_name_key & Chr(34) & " order by from_Date, place_serv"

        '		tmpdb = DAODBEngine_definst.OpenDatabase(am_data_path & "med.mdb")

        '		tmpset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        '		medopn.Recordset.AddNew()
        '		entry_type = "ADD"
        '		For num = 0 To medopn.Recordset.Fields.Count - 1
        '			medopn.Recordset((num)) = tmpset.Fields(num).Value
        '		Next 


        '	Case 1

        '		tmpdb = DAODBEngine_definst.OpenDatabase(am_data_path & "med.mdb")
        '		tmpset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        '		medopn.Recordset.AddNew()
        '		entry_type = "ADD"
        '		For num = 0 To medopn.Recordset.Fields.Count - 1
        '			medopn.Recordset((num)) = tmpset.Fields(num).Value
        '		Next 


        '	Case 2

        '		medopn.Recordset.MoveLast()
        '		medopn.Recordset.edit()
        '		entry_type = "EDIT"

        'End Select

    End Sub

    Private Sub Save_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Save.Click
        'copy the first record in and then change for this data

        If Len(txtfields(0).Text) = 0 Then
            MsgBox("You must enter a procedure code.")
            Exit Sub
            Call ets_set_selected()
        End If

        If Len(txtfields(1).Text) = 0 Then
            MsgBox("You must enter a place of service.")
            Exit Sub
            Call ets_set_selected()
        End If

        If CDbl(txtfields(2).Text) = 0 Then
            del_flag = "Y"
            '	medopn.Recordset.delete()
        Else

            '		Call chk_Proc_code(txtfields(0), medopn.Recordset.Fields("from_Date"))
            ' medopn_tmp.Fields("proc_desc") = selected_proc_desc          'removed 6/15/01 
            '  medopn_tmp.Fields("usual_fee") = selected_proc_fee         'removed 6/15/01 
            '			medopn.Recordset.Fields("usual_fee") = selected_proc_fee 'added 6/15/01 
            '			medopn.Recordset.Fields("dol_net_bill") = Int(selected_proc_dol_actual * CDbl(txtfields(2).Text) * 100) / 100
            '			medopn.Recordset.Fields("proc_Desc") = selected_proc_desc
            '			medopn.Recordset.Update()

        End If

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
        If entry_type = "ADD" Then
            If Index = 0 Then
                txtfields(3).Text = CStr(saved_date)
                '	medopn.Recordset.Fields("from_Date") = saved_date
                '	medopn.Recordset.Fields("to_Date") = saved_date
                '	medopn.Recordset.Fields("att_units") = 0
                '	medopn.Recordset.Fields("place_serv") = 2
            End If
        End If

    End Sub

    Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        '	Dim medfeelookup As Object
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index

                Case 0
                    txtfields(Index).Text = UCase(txtfields(Index).Text)
                    ' if blank do lookup
                    function_type = "DATA_ENTRY"
                    '		valid_yn = "N"

                    If Len(Trim(txtfields(Index).Text)) = 0 Then
                        'UPGRADE_WARNING: Couldn't resolve default property of object medfeelookup.Show. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        '			medfeelookup.Show(1)
                        txtfields(Index).Text = selected_lookup_num
                    End If

                    '		Call chk_Proc_code(txtfields(Index), Today)

                    'If valid_yn = "N" Then
                    '	MsgBox("Invalid Procedure Code.")
                    '	Call ets_set_selected()
                    '	GoTo EventExitSub
                    'End If

                    '		medopn.Recordset.Fields("usual_fee") = selected_proc_fee

                Case 1
                    'check the place of service
                    'eitehr 01 or 02

                    Select Case txtfields(Index).Text
                        Case CStr(1)
                            '	txtfields(Index).Text = VB6.Format(txtfields(Index).Text, "00")
                            'Case CStr(2)
                            '	txtfields(Index).Text = VB6.Format(txtfields(Index).Text, "00")
                            'Case "01"
                            '	txtfields(Index).Text = VB6.Format(txtfields(Index).Text, "00")
                            'Case "02"
                            '	txtfields(Index).Text = VB6.Format(txtfields(Index).Text, "00")
                            'Case Else
                            If Not IsNumeric(txtfields(Index).Text) Then
                                MsgBox("You must enter a number between 1 and 99.")
                                Call ets_set_selected()
                                GoTo EventExitSub
                            Else
                                If Val(txtfields(Index).Text) > 100 Or Val(txtfields(Index).Text) < 1 Then
                                    MsgBox("You must enter a number between 1 and 99.")
                                    Call ets_set_selected()
                                    GoTo EventExitSub
                                End If
                            End If

                    End Select

                Case 2

                    If IsNumeric(txtfields(Index).Text) Then
                        '	txtfields(Index).Text = VB6.Format(txtfields(Index).Text, "FIXED")
                    Else
                        MsgBox("Invalid Number")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                    '	medopn.Recordset.Fields("dol_billed") = medopn.Recordset.Fields("usual_fee") * Val(txtfields(Index).Text)

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
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub
End Class