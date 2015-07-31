Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports JRI.MODULE1
Imports System.Data.SqlClient

Friend Class ar_bat_lookup
	Inherits System.Windows.Forms.Form
	'****************
	'revision History
	'original date of this form is 6/23/97 -SCS
	
	'****************
	
	Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
		
		entry_type = "ADD"
		selected_bat_num = 0
		
		'here we ask what type of batch it is wire or paper
		Response = MsgBox("Do you wish to enter a multi line invoice batch? Answer Yes for multi, No for Single line batch.", MsgBoxStyle.YesNo)
		
		cash_tmp.Refresh()
		'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Do While Not cash_tmp.Recordset.EOF
        '	'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	cash_tmp.Recordset.delete()
        '	'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	cash_tmp.Recordset.MoveNext()
        'Loop 
		
        'If Response = 6 Then
        '	ar_cash_batch.ShowDialog()
        '	'Else
        '	'Response = MsgBox("Will these entries be multi line invoice payments?", vbYesNo + vbDefaultButton2)

        '	' If Response = 6 Then
        '	' ar_cash_batch.Show 1
        'Else
        '	frmar_cash1.ShowDialog()
        '	'End If
        'End If
		
		'clear the grid
		
		'        For num = Grid1.Rows - 1 To 1 Step -1
		'        Grid1.RemoveItem num
		'        Next
		
		'UPGRADE_ISSUE: Data property cash_tmp1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'cash_tmp1.recordsource = "select * from cash_tmp1 order by batch_num"
        'cash_tmp1.Refresh()
		
		'    If Not cash_tmp1.Recordset.EOF Then
		'    cash_tmp1.Recordset.MoveFirst
		'    Grid1.AddItem "Number" & Chr(9) & "Chk Type" & Chr(9) & "Date" & Chr(9) & "Deposit #" & Chr(9) & "Amount", 0
		'    num = 1
		'        msg = "Single"
		'         If cash_tmp1.Recordset.Fields("s_m") = "M" Then msg = "Multi"
		'         Grid1.AddItem cash_tmp1.Recordset.Fields("batch_num") & Chr(9) & msg & Chr(9) & cash_tmp1.Recordset.Fields("batch_date") & Chr(9) & cash_tmp1.Recordset.Fields("batch_desc") & Chr(9) & cash_tmp1.Recordset.Fields("batch_total"), num
		'       Response = cash_tmp1.Recordset.Fields("batch_num")
		'    cash_tmp1.Recordset.MoveNext
		'         num = 2
		'      Do While Not cash_tmp1.Recordset.EOF
		'       If Response <> cash_tmp1.Recordset.Fields("batch_num") Then
		'      msg = "Single"
		'         If cash_tmp1.Recordset.Fields("s_m") = "M" Then msg = "Multi"
		'         Grid1.AddItem cash_tmp1.Recordset.Fields("batch_num") & Chr(9) & msg & Chr(9) & cash_tmp1.Recordset.Fields("batch_date") & Chr(9) & cash_tmp1.Recordset.Fields("batch_desc") & Chr(9) & cash_tmp1.Recordset.Fields("batch_total"), num
		'       num = num + 1
		'       Response = cash_tmp1.Recordset.Fields("batch_num")
		'       End If
		'
		'    cash_tmp1.Recordset.MoveNext
		'
		'    Loop
		'    End If
		'
		'    Grid1.ColWidth(0) = 720
		'    Grid1.ColWidth(1) = 1500
		'    Grid1.ColWidth(2) = 1200
		'    Grid1.ColWidth(3) = 1200
		'    Grid1.ColWidth(4) = 1200
		'
		'    On Error Resume Next
		'    Grid1.RemoveItem num
		
		selectedcell = False
		
	End Sub
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		selected_lookup_num = " " '
		selected_screen_nam = " "
		selected_plan_desc = " "
		
		Me.Close()
		
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        prtDestination = CInt(CStr(0))
		prtreportfilename = ar_report_path & "arcbatch1.rpt"
		'  ' Call frmcrystal_Call
		
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        prtDestination = CInt(CStr(0))
		prtreportfilename = ar_report_path & "arcbatch.rpt"
		' '  ' Call frmcrystal_Call
	End Sub
	
	Private Sub ed_det_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ed_det.Click
		
		If selectedcell = False Then
			MsgBox("Nothing selected")
			Exit Sub
		End If
		
		'     temp_row = Grid1.TopRow
		'    actual_row = Grid1.Row
		'
		'
		'   Grid1.Col = 0
		'    On Error Resume Next
		'    selected_bat_num = Grid1.Text
		'    'check to see if first line
		'    If err = 13 Then
		'    MsgBox ("Please select a line with data on it.")
		'    Exit Sub
		'    End If
		'
		'
		'    Grid1.Col = 1
		'
		'
		'    entry_type = "EDIT"
		'    ar_cash_edit_sel.Show 1
		'
		'         'clear the grid
		'
		'        For num = Grid1.Rows - 1 To 1 Step -1
		'        Grid1.RemoveItem num
		'        Next
		'
		'      cash_tmp1.recordsource = "select * from cash_tmp1 order by batch_num"
		'    cash_tmp1.Refresh
		'
		'    If Not cash_tmp1.Recordset.EOF Then
		'    cash_tmp1.Recordset.MoveFirst
		'    Grid1.AddItem "Number" & Chr(9) & "Chk Type" & Chr(9) & "Date" & Chr(9) & "Deposit #" & Chr(9) & "Amount", 0
		'    num = 1
		'        msg = "Single"
		'         If cash_tmp1.Recordset.Fields("s_m") = "M" Then msg = "Multi"
		'         Grid1.AddItem cash_tmp1.Recordset.Fields("batch_num") & Chr(9) & msg & Chr(9) & cash_tmp1.Recordset.Fields("batch_date") & Chr(9) & cash_tmp1.Recordset.Fields("batch_desc") & Chr(9) & cash_tmp1.Recordset.Fields("batch_total"), num
		'       Response = cash_tmp1.Recordset.Fields("batch_num")
		'    cash_tmp1.Recordset.MoveNext
		'         num = 2
		'      Do While Not cash_tmp1.Recordset.EOF
		'       If Response <> cash_tmp1.Recordset.Fields("batch_num") Then
		'      msg = "Single"
		'         If cash_tmp1.Recordset.Fields("s_m") = "M" Then msg = "Multi"
		'         Grid1.AddItem cash_tmp1.Recordset.Fields("batch_num") & Chr(9) & msg & Chr(9) & cash_tmp1.Recordset.Fields("batch_date") & Chr(9) & cash_tmp1.Recordset.Fields("batch_desc") & Chr(9) & cash_tmp1.Recordset.Fields("batch_total"), num
		'       num = num + 1
		'       Response = cash_tmp1.Recordset.Fields("batch_num")
		'       End If
		'
		'    cash_tmp1.Recordset.MoveNext
		'
		'    Loop
		'    End If
		'
		'    Grid1.ColWidth(0) = 720
		'    Grid1.ColWidth(1) = 1500
		'    Grid1.ColWidth(2) = 1200
		'    Grid1.ColWidth(3) = 1200
		'    Grid1.ColWidth(4) = 1200
		'
		'     On Error Resume Next
		'
		'    Grid1.RemoveItem num
		'   On Error GoTo 0
		'     selectedcell = False
		'
		'     selectedcell = False
		'     On Error Resume Next
		'    Grid1.TopRow = temp_row
		'    Grid1.SelStartRow = actual_row
		'     Grid1.SelEndRow = actual_row
		
		
		
	End Sub
	
	Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Edit.Click
		
		If selectedcell = False Then
			MsgBox("Nothing selected")
			Exit Sub
		End If
		
		'    temp_row = Grid1.TopRow
		'    actual_row = Grid1.Row
		'
		'    Grid1.Col = 0
		'    selected_bat_num = Grid1.Text
		'    Grid1.Col = 1
		'    msg = Grid1.Text
		'
		entry_type = "ADD_EDIT"
		
		cash_tmp.Refresh()
		'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        'Do While Not cash_tmp.Recordset.EOF
        '	'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	cash_tmp.Recordset.delete()
        '	'UPGRADE_ISSUE: Data property cash_tmp.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	cash_tmp.Recordset.MoveNext()
        'Loop 

        'Select Case msg
        '	Case "Multi"
        '		ar_cash_batch.ShowDialog()
        '	Case "Single"
        '		' Response = MsgBox("Will these entries be multi line invoice payments?", vbYesNo + vbDefaultButton2)

        '		' If Response = 6 Then
        '		' ar_cash_batch.Show 1
        '		'Else
        '		frmar_cash1.ShowDialog()
        '		' End If

        'End Select
		
		'       'clear the grid
		'
		'        For num = Grid1.Rows - 1 To 1 Step -1
		'        Grid1.RemoveItem num
		'        Next
		'
		'      cash_tmp1.recordsource = "select * from cash_tmp1 order by batch_num"
		'    cash_tmp1.Refresh
		'
		'    If Not cash_tmp1.Recordset.EOF Then
		'    cash_tmp1.Recordset.MoveFirst
		'    Grid1.AddItem "Number" & Chr(9) & "Chk Type" & Chr(9) & "Date" & Chr(9) & "Deposit #" & Chr(9) & "Amount", 0
		'    num = 1
		'        msg = "Single"
		'         If cash_tmp1.Recordset.Fields("s_m") = "M" Then msg = "Multi"
		'         Grid1.AddItem cash_tmp1.Recordset.Fields("batch_num") & Chr(9) & msg & Chr(9) & cash_tmp1.Recordset.Fields("batch_date") & Chr(9) & cash_tmp1.Recordset.Fields("batch_desc") & Chr(9) & cash_tmp1.Recordset.Fields("batch_total"), num
		'       Response = cash_tmp1.Recordset.Fields("batch_num")
		'    cash_tmp1.Recordset.MoveNext
		'         num = 2
		'      Do While Not cash_tmp1.Recordset.EOF
		'       If Response <> cash_tmp1.Recordset.Fields("batch_num") Then
		'      msg = "Single"
		'     If cash_tmp1.Recordset.Fields("s_m") = "M" Then msg = "Multi"
		'         Grid1.AddItem cash_tmp1.Recordset.Fields("batch_num") & Chr(9) & msg & Chr(9) & cash_tmp1.Recordset.Fields("batch_date") & Chr(9) & cash_tmp1.Recordset.Fields("batch_desc") & Chr(9) & cash_tmp1.Recordset.Fields("batch_total"), num
		'       num = num + 1
		'       Response = cash_tmp1.Recordset.Fields("batch_num")
		'       End If
		'
		'    cash_tmp1.Recordset.MoveNext
		'
		'    Loop
		'    End If
		'
		'    Grid1.ColWidth(0) = 720
		'    Grid1.ColWidth(1) = 1500
		'    Grid1.ColWidth(2) = 1200
		'    Grid1.ColWidth(3) = 1200
		'    Grid1.ColWidth(4) = 1200
		'
		'    Grid1.RemoveItem num
		'
		'     selectedcell = False
		'     selectedcell = False
		''    Grid1.TopRow = temp_row
		'    Grid1.SelStartRow = actual_row
		'     Grid1.SelEndRow = actual_row
		'
		'
	End Sub
	
	Private Sub extra_com_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles extra_com.Click
		
		'    If selectedcell = False Then
		'    MsgBox "Nothing selected"
		'    Exit Sub
		'    End If
		'
		'    'this posts the batch
		'
		'    Screen.MousePointer = vbHourglass
		'
		'    temp_row = Grid1.TopRow
		'    actual_row = Grid1.Row
		'
		'    Grid1.Col = 0
		'    selected_bat_num = Grid1.Text
		'    Grid1.Col = 1
		'    msg = Grid1.Text
		'
		'    'checks the batch to make sure that the detail = the total
		'    'checks all the account numbers
		'    'checks for disc acct if disc amt
		'    'checks for a name key
		'
		'    'check the batch for completeness
		'
		'    cash_tmp1.recordsource = "select * from cash_tmp1 where batch_num = " & selected_bat_num & " order by name_key,chk_num"
		'    cash_tmp1.Refresh
		'
		'    'cash_Tmp1.Recordset.MoveFirst     'should not be necessary and if nothing to post gives an error
		'
		'    tot_amt = 0 'cash_Tmp1.Recordset.Fields("chk_alloc")
		'    'saved_chk_num = cash_Tmp1.Recordset.Fields("chk_num")
		'    'saved_name_key = cash_Tmp1.Recordset.Fields("name_key")
		'    'saved_amount = cash_Tmp1.Recordset.Fields("check_amt") + cash_Tmp1.Recordset.Fields("chk_disc")
		'    Do While Not cash_tmp1.Recordset.EOF
		'
		'        tot_amt = tot_amt + cash_tmp1.Recordset.Fields("chk_alloc")
		'         valid_acct = " N "
		'        Call etsacctnum_chk(cash_tmp1.Recordset.Fields("cr_Acct_nu"), retacct, retacctdesc, valid_acct)
		'
		'        If valid_acct = "N" Then
		'        MsgBox ("BATCH NOT POSTED Invalid  CR account number on entry number = ") & cash_tmp1.Recordset.Fields("entry_num")
		'        Screen.MousePointer = vbDefault
		'        Exit Sub
		'        End If
		'        Call etsacctnum_chk(cash_tmp1.Recordset.Fields("dr_Acct_nu"), retacct, retacctdesc, valid_acct)
		'
		'        If valid_acct = "N" Then
		'        MsgBox ("BATCH NOT POSTED Invalid DR account number on entry number = ") & cash_tmp1.Recordset.Fields("entry_num")
		'        Screen.MousePointer = vbDefault
		'        Call ets_set_selected
		'        Exit Sub
		'        End If
		'
		'        If Len(cash_tmp1.Recordset.Fields("disc_Acct")) <> 0 Then
		'        Call etsacctnum_chk(cash_tmp1.Recordset.Fields("disc_Acct"), retacct, retacctdesc, valid_acct)
		'
		'         If valid_acct = "N" Then
		'        MsgBox ("BATCH NOT POSTED Invalid DR account number on entry number = ") & cash_tmp1.Recordset.Fields("entry_num")
		'        Screen.MousePointer = vbDefault
		'        Call ets_set_selected
		'        Exit Sub
		'        End If
		'        End If
		'
		'         If Len(cash_tmp1.Recordset.Fields("name_key")) = 0 Then
		'         MsgBox ("BATCH NOT POSTED Invalid name key on entry number = ") & cash_tmp1.Recordset.Fields("entry_num")
		'         Screen.MousePointer = vbDefault
		'        Call ets_set_selected
		'        Exit Sub
		'        End If
		'
		'    cash_tmp1.Recordset.MoveNext
		'    Loop
		'
		'    cash_tmp1.Recordset.MoveFirst
		'    'check the batch total
		'    If tot_amt <> cash_tmp1.Recordset.Fields("batch_total") Then
		'           MsgBox "BATCH NOT POSTED The total batch amount is not equal to the detail."
		'           Screen.MousePointer = vbDefault
		'           Exit Sub
		'    End If
		'
		'
		'    'copy the files to cash
		'    'and update invoice
		'     Set tmpdb = OpenDatabase(ar_data_path & "ar.mdb")
		'     Set tmpset = tmpdb.OpenRecordset("invoice", dbOpenDynaset)
		'
		'         cash_tmp1.Refresh
		'
		'         cash_tmp1.Recordset.MoveFirst
		'         Do While Not cash_tmp1.Recordset.EOF
		'
		'         'apply to invoice
		'
		'         If Len(cash_tmp1.Recordset.Fields("inv_num")) <> 0 Then
		'         sqlstmnt = "inv_num = " & cash_tmp1.Recordset.Fields("inv_num")
		'         sqlstmnt = sqlstmnt & " and line_num = " & cash_tmp1.Recordset.Fields("line_num")
		'         'tmpset is invoice
		'        tmpset.FindFirst sqlstmnt
		'
		'        If tmpset.NoMatch Then
		'        'skip update to invoice
		'            If cash_tmp1.Recordset.Fields("trans_Code") <> "ADV" Then
		'            'MsgBox "This invoice number was not in the invoice file but will be posted. Inv number = " & cash_Tmp1.Recordset.Fields("inv_num")
		'            'removed since too many of them 9/29/98
		'            End If
		'        Else
		'        tmpset.edit
		'        tmpset.Fields("paid_date") = cash_tmp1.Recordset.Fields("encum_Date")
		'        tmpset.Fields("chk_num") = cash_tmp1.Recordset.Fields("chk_num")
		'        tmpset.Fields("bank_key") = cash_tmp1.Recordset.Fields("bank_key")
		'        Call bank_nameget(cash_tmp1.Recordset.Fields("bank_key"))
		'        tmpset.Fields("bank_name") = bank_screen_nam
		'        tmpset.Fields("pay_amt") = cash_tmp1.Recordset.Fields("chk_alloc")
		'        tmpset.Fields("bal_due") = tmpset.Fields("bal_due") - cash_tmp1.Recordset.Fields("chk_alloc")
		'        If tmpset.Fields("bal_Due") = 0 Then
		'        tmpset.Fields("paid") = "Y"
		'        End If
		'    tmpset.update
		'    End If
		'    End If
		'
		'    'move to cash
		'     cash.Recordset.AddNew
		'    For num = 0 To cash_tmp1.Recordset.Fields.Count - 1
		'        cash.Recordset(num) = cash_tmp1.Recordset(num)
		'    Next
		'
		'    cash.Recordset.update
		'    cash_tmp1.Recordset.MoveNext
		'    Loop
		'
		'    cash_tmp1.Refresh
		'
		'
		'    Do While Not cash_tmp1.Recordset.EOF
		'    cash_tmp1.Recordset.delete
		'    cash_tmp1.Recordset.MoveNext
		'    Loop
		'
		'    MsgBox "Batch was successfully posted to CASH and INVOICE"
		'
		'
		'
		'        'clear the grid
		'
		'        For num = Grid1.Rows - 1 To 1 Step -1
		'        Grid1.RemoveItem num
		'        Next
		'
		'      cash_tmp1.recordsource = "select * from cash_tmp1 order by batch_num"
		'    cash_tmp1.Refresh
		'
		'    If Not cash_tmp1.Recordset.EOF Then
		'    cash_tmp1.Recordset.MoveFirst
		'    Grid1.AddItem "Number" & Chr(9) & "Chk Type" & Chr(9) & "Date" & Chr(9) & "Deposit #" & Chr(9) & "Amount", 0
		'    num = 1
		'        msg = "Single"
		'         If cash_tmp1.Recordset.Fields("s_m") = "M" Then msg = "Multi"
		'         Grid1.AddItem cash_tmp1.Recordset.Fields("batch_num") & Chr(9) & msg & Chr(9) & cash_tmp1.Recordset.Fields("batch_date") & Chr(9) & cash_tmp1.Recordset.Fields("batch_desc") & Chr(9) & cash_tmp1.Recordset.Fields("batch_total"), num
		'       Response = cash_tmp1.Recordset.Fields("batch_num")
		'    cash_tmp1.Recordset.MoveNext
		'         num = 2
		'      Do While Not cash_tmp1.Recordset.EOF
		'       If Response <> cash_tmp1.Recordset.Fields("batch_num") Then
		'      msg = "Single"
		'         If cash_tmp1.Recordset.Fields("s_m") = "M" Then msg = "Multi"
		'         Grid1.AddItem cash_tmp1.Recordset.Fields("batch_num") & Chr(9) & msg & Chr(9) & cash_tmp1.Recordset.Fields("batch_date") & Chr(9) & cash_tmp1.Recordset.Fields("batch_desc") & Chr(9) & cash_tmp1.Recordset.Fields("batch_total"), num
		'       num = num + 1
		'       Response = cash_tmp1.Recordset.Fields("batch_num")
		'       End If
		'
		'    cash_tmp1.Recordset.MoveNext
		'
		'    Loop
		'    End If
		'
		'    Grid1.ColWidth(0) = 720
		'    Grid1.ColWidth(1) = 1500
		'    Grid1.ColWidth(2) = 1200
		'    Grid1.ColWidth(3) = 1200
		'    Grid1.ColWidth(4) = 1200
		'
		'    On Error Resume Next
		'    Grid1.RemoveItem num
		'
		'     selectedcell = False
		'     selectedcell = False
		'    Grid1.TopRow = temp_row
		'    Grid1.SelStartRow = actual_row
		'     Grid1.SelEndRow = actual_row
		'
		'   Screen.MousePointer = vbDefault
		
	End Sub
	
	Private Sub ar_bat_lookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		On Error Resume Next
		
	
		ctrform(Me)
		selectedcell = False
		
		'clear the grid
		
		'        For num = Grid1.Rows - 1 To 1 Step -1
		'        Grid1.RemoveItem num
		'        Next
		
		'UPGRADE_ISSUE: Data property cash_tmp1.recordsource was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '	cash_tmp1.recordsource = "select * from cash_tmp1 order by batch_num"
        '	cash_tmp1.Refresh()
		
		'    If Not cash_tmp1.Recordset.EOF Then
		'    cash_tmp1.Recordset.MoveFirst
		'    Grid1.AddItem "Number" & Chr(9) & "Chk Type" & Chr(9) & "Date" & Chr(9) & "Deposit #" & Chr(9) & "Amount", 0
		'    num = 1
		'        msg = "Single"
		'        If cash_tmp1.Recordset.Fields("s_m") = "M" Then msg = "Multi"
		'         Grid1.AddItem cash_tmp1.Recordset.Fields("batch_num") & Chr(9) & msg & Chr(9) & cash_tmp1.Recordset.Fields("batch_date") & Chr(9) & cash_tmp1.Recordset.Fields("batch_desc") & Chr(9) & cash_tmp1.Recordset.Fields("batch_total"), num
		'       Response = cash_tmp1.Recordset.Fields("batch_num")
		'    cash_tmp1.Recordset.MoveNext
		'         num = 2
		'      Do While Not cash_tmp1.Recordset.EOF
		'       If Response <> cash_tmp1.Recordset.Fields("batch_num") Then
		'      msg = "Single"
		'     If cash_tmp1.Recordset.Fields("s_m") = "M" Then msg = "Multi"
		'         Grid1.AddItem cash_tmp1.Recordset.Fields("batch_num") & Chr(9) & msg & Chr(9) & cash_tmp1.Recordset.Fields("batch_date") & Chr(9) & cash_tmp1.Recordset.Fields("batch_desc") & Chr(9) & cash_tmp1.Recordset.Fields("batch_total"), num
		'       num = num + 1
		'       Response = cash_tmp1.Recordset.Fields("batch_num")
		'       End If
		'
		'    cash_tmp1.Recordset.MoveNext
		'
		'    Loop
		'    End If
		'
		'    Grid1.ColWidth(0) = 720
		'    Grid1.ColWidth(1) = 1500
		'    Grid1.ColWidth(2) = 1200
		'    Grid1.ColWidth(3) = 1200
		'    Grid1.ColWidth(4) = 1200
		'
		'    Grid1.RemoveItem num
		'
		'
		
		selectedcell = False
	End Sub
	'Private Sub Grid1_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
	'    selectedcell = True
	'     SendKeys "{TAB}"
	'    KeyAscii = 0
	'End Sub
	
	Private Sub Importcsv_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Importcsv.Click
		'added 12/18/03 lhw/tk  moved from V4 5/6/04 lhw
		Dim filename_sel As Object
		
		entry_type = "ADD"
		selected_bat_num = 0
		
		txtfields.Visible = True
		Label4.Visible = True
		If Trim(txtfields.Text) = "" Then
			MsgBox("Enter Encum Date for the Import File.")
			txtfields.Focus()
			Exit Sub
		End If
		
		cash_tmp.Refresh()
		'  Do While Not cash_Tmp.Recordset.EOF
		'    cash_Tmp.Recordset.Delete
		'    cash_Tmp.Recordset.MoveNext
		'  Loop
		
		MsgBox("Please insert disk.")
		
		'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		fnum = FreeFile
		
		'UPGRADE_WARNING: Couldn't resolve default property of object filename_sel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		filename_sel = "A:\RENT.csv"
		err.Clear()
		'UPGRADE_WARNING: Couldn't resolve default property of object filename_sel. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	FileOpen(fnum, filename_sel, OpenMode.Input, , , 1)
		
		Select Case Err.Number
			Case 0
			Case 70
				MsgBox("Drive A:\ not ready.")
				'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
				Exit Sub
			Case Else
				MsgBox("Error #" & Err.Number & " meaning " & ErrorToString(Err.Number) & Chr(10) & "Please fix before trying again.")
				'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
				Exit Sub
		End Select
		
		On Error GoTo 0
		
		Dim fld(6) As Object
		Dim batch_total As Decimal
		batch_total = 0
		'UPGRADE_WARNING: Arrays in structure invoiceset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
        'Dim invoiceset As dao.Recordset
        'tmpdb = DAODBEngine_definst.OpenDatabase(ar_data_path & "ar.mdb")
        'invoiceset = tmpdb.OpenRecordset("cash_tmp1", dao.RecordsetTypeEnum.dbOpenDynaset)

        'tmpset = tmpdb.OpenRecordset("nam_cust", dao.RecordsetTypeEnum.dbOpenDynaset)
		
		num = 0
		Call batch_number_Create()
		saved_entry_num = 1
        'Do While Not EOF(fnum)
        '	err.Clear()
        '	On Error Resume Next
        '	Input(1, msg)

        '	If Err.Number = 62 Then Exit Do
        '	'UPGRADE_WARNING: Couldn't resolve default property of object fld(num). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '	fld(num) = msg

        '	'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '          If num = 6 And Trim(CStr(fld(0))) <> "" Then
        '              num = 0
        '              'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '              sqlstmnt = "Select * from nam_cust where name_key = " & Chr(34) & Trim(fld(0)) & Chr(34)
        '              tmpset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        '              'tmpset.FindFirst "name_key = " & Chr(34) & Trim(fld(0)) & Chr(34)
        '              'If Not tmpset.NoMatch Then
        '              If tmpset.RecordCount <> 0 Then
        '                  'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                  If Trim(fld(3)) <> "" Then
        '                      'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                      batch_total = batch_total + fld(3)
        '                  End If

        '                  invoiceset.AddNew()
        '                  invoiceset.Fields("bank_key").Value = "2177"
        '                  invoiceset.Fields("encum_date").Value = txtfields.Text
        '                  'UPGRADE_WARNING: Couldn't resolve default property of object fld(0). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                  invoiceset.Fields("name_key").Value = fld(0)
        '                  invoiceset.Fields("screen_nam").Value = tmpset.Fields("screen_nam").Value
        '                  invoiceset.Fields("sort_name").Value = tmpset.Fields("sort_name").Value
        '                  'UPGRADE_WARNING: Couldn't resolve default property of object fld(2). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                  invoiceset.Fields("chk_num").Value = fld(2)
        '                  invoiceset.Fields("chk_date").Value = txtfields.Text
        '                  'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                  If Trim(fld(3)) <> "" Then
        '                      'UPGRADE_WARNING: Couldn't resolve default property of object fld(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                      invoiceset.Fields("gross_amt").Value = fld(3)
        '                  End If
        '                  invoiceset.Fields("chk_disc").Value = 0
        '                  'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                  If Trim(fld(3)) <> "" Then
        '                      'UPGRADE_WARNING: Couldn't resolve default property of object fld(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                      invoiceset.Fields("check_amt").Value = fld(3)
        '                      'UPGRADE_WARNING: Couldn't resolve default property of object fld(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                      invoiceset.Fields("chk_alloc").Value = fld(3)
        '                  End If
        '                  invoiceset.Fields("entry_num").Value = saved_entry_num
        '                  saved_entry_num = saved_entry_num + 1
        '                  invoiceset.Fields("inv_num").Value = 0
        '                  invoiceset.Fields("line_num").Value = 1
        '                  invoiceset.Fields("invoice").Value = "MISC"
        '                  invoiceset.Fields("trans_code").Value = "PMT"
        '                  invoiceset.Fields("dr_acct_nu").Value = "1007-00-00" 'bank
        '                  invoiceset.Fields("cr_acct_nu").Value = "1260-00-00"
        '                  invoiceset.Fields("disc_acct").Value = "1260-00-00"
        '                  invoiceset.Fields("donor").Value = "MISC"
        '                  invoiceset.Fields("memo").Value = "ON ACCOUNT"
        '                  invoiceset.Fields("batch_num").Value = selected_bat_num
        '                  invoiceset.Fields("batch_desc").Value = "1"
        '                  invoiceset.Fields("batch_date").Value = txtfields.Text
        '                  'invoiceset.Fields("batch_total") = batch_total
        '                  invoiceset.Fields("s_m").Value = "M"

        '                  invoiceset.update()
        '              Else
        '                  'UPGRADE_WARNING: Couldn't resolve default property of object fld(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                  'UPGRADE_WARNING: Couldn't resolve default property of object fld(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        '                  MsgBox("Customer #" & fld(0) & " (" & fld(1) & ") not in nam_cust table.These are not added to this batch.")

        '              End If

        '          Else
        '              num = num + 1
        '          End If
        'Loop 

        'sqlstmnt = "SELECT batch_total FROM cash_tmp1 where batch_num = " & selected_bat_num & "" 'fixed lhw
        'invoiceset = tmpdb.OpenRecordset(sqlstmnt, dao.RecordsetTypeEnum.dbOpenDynaset)
        'invoiceset.MoveFirst()
        'Do While Not invoiceset.EOF
        '	invoiceset.edit()
        '	invoiceset.Fields("batch_total").Value = batch_total
        '	invoiceset.update()
        '	invoiceset.MoveNext()
        'Loop 

        'MsgBox("Import complete.  Batch Total: $" & batch_total)

        'FileClose(fnum)
        ''UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
        'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        ''turn off entry date area
        'txtfields.Visible = False
        'Label4.Visible = False

        'clear the grid
        '    For num = Grid1.Rows - 1 To 1 Step -1
        '        Grid1.RemoveItem num
        '    Next
        '
        '    'now refresh the grid
        '    cash_tmp1.recordsource = "select * from cash_tmp1 order by batch_num"
        '    cash_tmp1.Refresh
        '
        '    If Not cash_tmp1.Recordset.EOF Then
        '        cash_tmp1.Recordset.MoveFirst
        '        Grid1.AddItem "Number" & Chr(9) & "Chk Type" & Chr(9) & "Date" & Chr(9) & "Deposit #" & Chr(9) & "Amount", 0
        '        num = 1
        '        msg = "Single"
        '        If cash_tmp1.Recordset.Fields("s_m") = "M" Then msg = "Multi"
        '            Grid1.AddItem cash_tmp1.Recordset.Fields("batch_num") & Chr(9) & msg & Chr(9) & cash_tmp1.Recordset.Fields("batch_date") & Chr(9) & cash_tmp1.Recordset.Fields("batch_desc") & Chr(9) & cash_tmp1.Recordset.Fields("batch_total"), num
        '            Response = cash_tmp1.Recordset.Fields("batch_num")
        '            cash_tmp1.Recordset.MoveNext
        '            num = 2
        '            Do While Not cash_tmp1.Recordset.EOF
        '                 If Response <> cash_tmp1.Recordset.Fields("batch_num") Then
        '                    msg = "Single"
        '                    If cash_tmp1.Recordset.Fields("s_m") = "M" Then msg = "Multi"
        '                    Grid1.AddItem cash_tmp1.Recordset.Fields("batch_num") & Chr(9) & msg & Chr(9) & cash_tmp1.Recordset.Fields("batch_date") & Chr(9) & cash_tmp1.Recordset.Fields("batch_desc") & Chr(9) & cash_tmp1.Recordset.Fields("batch_total"), num
        '                    num = num + 1
        '                    Response = cash_tmp1.Recordset.Fields("batch_num")
        '                 End If
        '                 cash_tmp1.Recordset.MoveNext
        '            Loop
        '    End If
        '
        '    Grid1.ColWidth(0) = 720
        '    Grid1.ColWidth(1) = 1500
        '    Grid1.ColWidth(2) = 1200
        '    Grid1.ColWidth(3) = 1200
        '    Grid1.ColWidth(4) = 1200
        '
        '    Grid1.RemoveItem num

        selectedcell = False

    End Sub
	
	Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
		Call ets_set_selected()
	End Sub
	
	Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
		If KeyAscii = 13 Or KeyAscii = 9 Then
			
			valid_Date = "N"
			senddate = txtfields.Text
            Call etsdate(senddate, valid_Date)
			
			If valid_Date <> "N" Then
                txtfields.Text = CStr(retdate)
				txtfields.Text = CStr(CDate(txtfields.Text))
				
				importCSV.Focus()
				KeyAscii = 0
			Else
				MsgBox("Bad date")
				Call ets_set_selected()
				GoTo EventExitSub
			End If
		End If
		
EventExitSub: 
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
		Call ets_set_selected()
	End Sub
End Class