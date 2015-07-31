Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class appogl_frm
	Inherits System.Windows.Forms.Form
	'Public sqlstmnt As String
	'Public glchr As database            'this is the destination
	'Public glchrlset As Recordset
	'Public saved_date As Date
	'Public acct_4 As String
	'Public dpt_2 As String
	'Public acct_8 As String
	'Public acct_8_desc As String
	'Public bud_bal As Currency
	'Public vch_bal As Currency
	
	'this form is for BCARC only
	'select base on invoice.trans_code <> misc 5/21/00 lhw
	
	
	Private Sub cmdRefresh_Click()
		'this is really only needed for multi user apps
		
	End Sub
	
	Private Sub cmdUpdate_Click()
		
		
	End Sub
	Private Sub Command2_Click()
		
		'    prtDestination = 0
		'    prtreportfilename = ar_report_path & "rev_jrnl.rpt"
		'   '  ' Call frmcrystal_Call
		'
	End Sub
	
	Private Sub chacct_Validate(ByRef Action As Short, ByRef save As Short)
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub Command3_Click()
		'        prtDestination = 0
		'        prtreportfilename = gl_report_path & "gltmp_rev.rpt"
		'       '  ' Call frmcrystal_Call
	End Sub
	
	Private Sub appogl_frm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		On Error Resume Next
		
		'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For num = 0 To Me.Controls.Count() - 1
			'UPGRADE_ISSUE: Data object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
			'UPGRADE_WARNING: TypeOf has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			If TypeOf CType(Me.Controls(num), Object) Is System.Windows.Forms.Label Then
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				sqlstmnt = VB.Right(CType(Me.Controls(num), Object).DatabaseName, Len(CType(Me.Controls(num), Object).DatabaseName) - 20)
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().DatabaseName. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CType(Me.Controls(num), Object).DatabaseName = gl_data_path & sqlstmnt
				'UPGRADE_WARNING: Couldn't resolve default property of object Me.Controls().recordsource. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Len(CType(Me.Controls(num), Object).recordsource) > 0 Then
					CType(Me.Controls(num), Object).Refresh()
				End If
			End If
			
		Next 
		
	End Sub
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
		Dim Index As Short = txtFields.GetIndex(eventSender)
		Call ets_set_selected()
	End Sub
	
	
	Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtfields.GetIndex(eventSender)
		'   If KeyAscii = 13 Then
		'
		'   Select Case Index
		'
		'   Case 0
		'          bud_bal = 0
		'          vch_bal = 0
		'
		'          acct_4 = Left(txtfields(0), 4)
		'          dpt_2 = Right(txtfields(0), 2)
		'
		'         sqlstmnt = "select * from chacct WHERE chacct.acct_only = " & Chr(34) & acct_4 & Chr(34)
		'         sqlstmnt = sqlstmnt & " and chacct.acct_pgm = '00'"
		'         sqlstmnt = sqlstmnt & " and chacct.acct_dpt = " & Chr(34) & dpt_2 & Chr(34)
		'
		'
		'    chacct.RecordSource = sqlstmnt
		'    chacct.Refresh
		'    On Error Resume Next
		'    chacct.Recordset.MoveFirst
		'
		'     If Error = 3021 Then
		'            MsgBox "This Acct# doesn't exist."
		'            Call ets_set_selected
		'        Exit Sub
		'      Else
		'            acct_8 = chacct.Recordset.Fields("acct_num")
		'            txtfields(5) = chacct.Recordset.Fields("acct_desc")
		'            bud_bal = chacct.Recordset.Fields("bud_yr") - chacct.Recordset.Fields("cur_ytd")
		'       End If
		'
		'    On Error GoTo 0
		'
		'    Case 1
		'
		'
		'     Case 2
		'
		'         valid_Date = "N"
		'         senddate = txtfields(Index).Text
		'         Call etsdate(senddate, retdate, valid_Date)
		'
		'         If valid_Date <> "N" Then
		'            txtfields(Index).Text = retdate
		'            txtfields(Index).Text = CVDate(txtfields(Index).Text)
		'          Else
		'            MsgBox "Bad date"
		'            Call ets_set_selected
		'            Exit Sub
		'         End If
		'
		'        sqlstmnt = "select * from voucher WHERE voucher.dr_acct_nu = " & Chr(34) & acct_8 & Chr(34)
		'        sqlstmnt = sqlstmnt & " AND voucher.encum_date >= " & Chr(35) & txtfields(Index).Text & Chr(35)
		'
		'        voucher.RecordSource = sqlstmnt
		'        voucher.Refresh
		'        On Error Resume Next
		'          If Error = 3021 Then
		'                MsgBox "There are no Vouchers for this Account."
		'                Call ets_set_selected
		'             Exit Sub
		'        On Error GoTo 0
		'
		'              Else
		'
		'
		'                voucher.Recordset.MoveFirst
		'
		'                Do While Not voucher.Recordset.EOF
		'                    vch_bal = vch_bal + voucher.Recordset.Fields("alloc_amt")
		'                    voucher.Recordset.MoveNext
		'                Loop
		'
		'                txtfields(3) = bud_bal
		'                txtfields(3) = Format(txtfields(3), "###0.00")
		'                txtfields(4) = vch_bal
		'                txtfields(4) = Format(txtfields(4), "###0.00")
		'                txtfields(1) = bud_bal - vch_bal
		'                txtfields(1) = Format(txtfields(1), "###0.00")
		'
		'        End If
		'
		'   End Select
		'
		'          SendKeys "{tab}"
		'            KeyAscii = 0
		'
		'  End If
		'
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
		Dim Index As Short = txtfields.GetIndex(eventSender)
		txtfields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
		txtfields(Index).SelectionStart = 0
		txtfields(Index).SelectionLength = Len(txtfields(Index).Text)
	End Sub
End Class