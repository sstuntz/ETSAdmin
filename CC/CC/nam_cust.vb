Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETSCommon.MODULE1
Imports Microsoft.VisualBasic.Compatibility


Friend Class frmnam_cust
	Inherits System.Windows.Forms.Form
	
	'****************
	'revision History
	'original date of this form is 7/24/97 - SCS
	
	'****************
	'Option Explicit
	
    Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
        If Len(txtFields(17).Text) = 0 Then
            MsgBox("You must enter an account number in DR_ACCT_NU field.")
            txtFields(17).Focus()
            Exit Sub
        End If

        If Len(txtFields(18).Text) = 0 Then
            MsgBox("You must enter an account number in CR_ACCT_NU field.")
            txtFields(18).Focus()
            Exit Sub
        End If



    End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
    Private Sub frmnam_cust_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
      
        Select Case entry_type

            ' Case "ADD"         'this is not used on this form 5/19/00 lhw
            '    cmdAdd.Visible = True
            '   If pass_level = 0 Then cmdAdd.Enabled = False


            Case "EDIT"
                cmdUpdate.Visible = True
                If pass_level = 0 Then cmdUpdate.Enabled = False
        End Select

        sqlstmnt = "select * from nam_cust where name_key = " & Chr(34) & selected_name_key & Chr(34)
     
       'next lines to open reference table so it can be used on this form
        'copied from cc_name form
        '      tmpset = tmpdb.OpenRecordset("reference")
        '
        For ETSCommon.MODULE1.num = 0 To Me.Controls.Count() - 1
            If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.ComboBox Then
                ' sqlstmnt = "select * from reference where ctrl_name = " & Chr(34) & CType(Me.Controls(num), Object).Name & Chr(34)
                '     tmpset = tmpdb.OpenRecordset(sqlstmnt)
                '    Do While Not tmpset.EOF
                'CType(Me.Controls(num), Object).AddItem(tmpset.Fields("datum_desc"))
                'tmpset.MoveNext()
                ' Loop
            End If
        Next

    End Sub
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
		Call ets_set_selected()
		If Index = 3 Then 'first field to get focus after form load
            txtFields(0).Text = selected_name_key
            txtFields(1).Text = selected_screen_nam
            txtFields(2).Text = selected_sort_name
            'txtfields(22).Text = Date

            If entry_type = "ADD" Then
                ' txtFields(17).Text = Mid(Data1.Recordset.Fields("dr_pref_ac").DefaultValue, 2, 10)
                'txtFields(18).Text = Mid(Data1.Recordset.Fields("cr_pref_ac").DefaultValue, 2, 10)
                'txtFields(19).Text = Mid(Data1.Recordset.Fields("disc_acct").DefaultValue, 2, 10)
                txtFields(22).Text = CStr(Today) 'start date
                txtFields(23).Text = CStr(#1/1/2050#) 'end date
            End If

        End If
    End Sub
	
	Private Sub txtFields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtFields.GetIndex(CType(eventSender, TextBox))
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			Select Case Index
				
				Case 4, 7, 10, 13
                    '	Call ets_format(txtfields(Index), retstring, "2", "N")
					If valid_yn = "N" Then
						MsgBox("invalid phone number")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					txtfields(Index).Text = retstring
					retstring = ""
				
				Case 16 'format the credit dollar limit
					
					If Len(txtfields(Index).Text) = 0 Then
						txtfields(Index).Text = CStr(0)
						GoTo EventExitSub
					End If
					
					txtfields(Index).Text = VB6.Format(txtfields(Index).Text, "###0.00;-###0.00")
					
				Case 28 'format the commission per cent
					
					If Len(txtfields(Index).Text) = 0 Then
						txtfields(Index).Text = CStr(0)
						GoTo EventExitSub
					End If
					
					txtfields(Index).Text = VB6.Format(txtfields(Index).Text, "##0.0000")
					
				Case 17, 18, 19
					
					valid_acct = " N "
					function_type_saved = function_type
					function_type = "LOOKUP_ONLY"
					
                    '	Call etsacctnum_chk(txtfields(Index), retacct, retacctdesc, valid_acct)
					
					If valid_acct = "N" Then
						MsgBox("Not a valid account number.")
						Call ets_set_selected()
						GoTo EventExitSub
					End If
					
					txtfields(Index).Text = retacct
					function_type = function_type_saved
				Case 22, 23
					
					valid_Date = "N"
					senddate = txtfields(Index).Text
                    valid_Date = etsdate(senddate, valid_Date)
					
                    If valid_Date <> "N" Then
                        retdate = CDate(valid_Date)
                        txtFields(Index).Text = CStr(retdate)
                        txtFields(Index).Text = CStr(CDate(txtFields(Index).Text))
                        'the line below shows how to add days to a date and give a new date
                        'duedate = DateAdd(, 30, txtfields(index))
                    Else
                        MsgBox(" Bad Date")
                        Call ets_set_selected()
                        GoTo EventExitSub

                    End If
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
		txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		
	End Sub
End Class