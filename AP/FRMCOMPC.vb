Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETS.Common.Module1
Imports PS.Common
Imports ETS.ApMod
Imports ETS.GLMod
Imports ETS

Public Class frmcompchk
    Inherits System.Windows.Forms.Form

    'data1 ap payment
    'data2 ap apchecks
    'data3 glname nam_bank
    'data4 ap apck_pad

    Public dorange As String
    'Dim fromwhere As String
    Public new_bal As Decimal
    Public add_chk_num As Integer
    Public beg_chk As Integer
    Public last_chk_num As Integer
    Public begin_Chk_num As Integer
    Public BankKey As String
    Public saved_name_key As String
    Public restart_flag As String
    Public saved_num_vouch As Integer
    Public saved_inv_date As Date
    Public RestartFlag As String = ""
    Public PayType As String
    Public VoucherList As String

    Public Sub pad_check_apron()
        'clear out the padded checks file
        sqlstmnt = "Delete from apck_pad"
        ETSSQL.ExecuteSQL(sqlstmnt)

        sqlstmnt = "INSERT INTO apck_pad (vouch_num, name_key, screen_nam, vouch_amt, disc_amt, amt_paid, amt_disc, bal_due, chk_num, n_chk_amt, n_dis_amt, chk_date, printed, agency, vend_inv, sort_name, inv_date, Bank_key, padcnt)"
        sqlstmnt = sqlstmnt & " select vouch_num, name_key, screen_nam, vouch_amt, disc_amt, amt_paid, amt_disc, bal_due, chk_num, n_chk_amt, n_dis_amt, chk_date, printed, agency, vend_inv, sort_name, inv_date, Bank_key, '1'"
        sqlstmnt = sqlstmnt & " FROM apchecks "
        ETSSQL.ExecuteSQL(sqlstmnt)

        sqlstmnt = " declare @padcnt  int"
        sqlstmnt = sqlstmnt & " declare @chknum as int"
        sqlstmnt = sqlstmnt & " declare ChkCursor Cursor for select  chk_num, count( chk_num) as numvouch  from apck_pad group by chk_num"
        sqlstmnt = sqlstmnt & " open chkcursor;"
        sqlstmnt = sqlstmnt & " fetch next from chkcursor into @chknum, @padcnt"
        sqlstmnt = sqlstmnt & " while @@FETCH_STATUS = 0"
        sqlstmnt = sqlstmnt & " begin"
        sqlstmnt = sqlstmnt & " while @padcnt < 15"
        sqlstmnt = sqlstmnt & " begin"
        sqlstmnt = sqlstmnt & " set @padcnt = @padcnt + 1"
        sqlstmnt = sqlstmnt & " insert into apck_pad ([vouch_num]           ,[name_key]"
        sqlstmnt = sqlstmnt & " ,[screen_nam]           ,[vouch_amt]           ,[disc_amt]           ,[amt_paid]"
        sqlstmnt = sqlstmnt & "  ,[amt_disc]           ,[bal_due]           ,[chk_num]           ,[n_chk_amt]"
        sqlstmnt = sqlstmnt & " ,[n_dis_amt]           ,[chk_date]           ,[printed]           ,[agency]"
        sqlstmnt = sqlstmnt & " ,[vend_inv]           ,[sort_name]           ,[inv_date]           ,[Bank_key], padcnt) "
        sqlstmnt = sqlstmnt & " (select top 1 '0' ,[name_key], ' ' , '0' , '0' , '0' , '0' , '0' , [chk_num] , '0' , '0',[chk_date]"
        sqlstmnt = sqlstmnt & " ,[printed]  ,[agency]  ,' ' ,[sort_name]"
        sqlstmnt = sqlstmnt & " ,[inv_date] , '0',@padcnt  from apchecks where apchecks.chk_num = @chknum )"
        sqlstmnt = sqlstmnt & " End"
        sqlstmnt = sqlstmnt & " fetch next from chkcursor into @chknum, @padcnt"
        sqlstmnt = sqlstmnt & " End"
        sqlstmnt = sqlstmnt & " close chkcursor;"
        sqlstmnt = sqlstmnt & " deallocate chkcursor;"

        ETSSQL.ExecuteSQL(sqlstmnt)

        'fix the padcnt numbering

        sqlstmnt = " with cte as (Select vouch_num, chk_num ,padcnt,  row_number() over(partition by chk_num order by vouch_num desc) as rownumber from apck_pad) "
        sqlstmnt = sqlstmnt & " update cte  set padcnt =cte.rownumber  "
        ETSSQL.ExecuteSQL(sqlstmnt)

    End Sub

    Private Sub begchkdate_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles begchkdate.Enter
        Call ets_set_selected()
        Me.ActiveControl.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
    End Sub

    Private Sub begchkdate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles begchkdate.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = begchkdate.Text
            If etsdate(senddate, "") = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                begchkdate.Text = etsdate(senddate, "")
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
            End If
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub begchkdate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles begchkdate.Leave
        begchkdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub begchknum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles begchknum.Enter
        Me.ActiveControl.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
    End Sub

    Private Sub begchknum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles begchknum.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim message As String
        If KeyAscii = 13 Or KeyAscii = 9 Then
            'check number must be greater than any check number used
            If Len(begchknum.Text) = 0 Then
                MsgBox("Please enter a starting check number.")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            If Not IsNumeric(begchknum.Text) Then
                MsgBox("Please enter a numeric check number.")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            Select Case GetNextCheckNumber(BankName.SelectedValue) - begchknum.Text

                Case Is < 0
                    MsgBox("Check number has been used.  Please enter another.")
                    Call ets_set_selected()
                    GoTo EventExitSub
                Case Is = 0
                    System.Windows.Forms.SendKeys.Send("{tab}")
                    KeyAscii = 0
                Case Is > 0
                    message = "Please verify your starting check number."
                    message = message & Chr(10) & "The number is different than 1 greater than the ending number in the payment table."
                    MsgBox(message)

            End Select
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub begchknum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles begchknum.Leave
        begchknum.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub chkdate_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkdate.Enter
        Me.ActiveControl.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
    End Sub

    Private Sub chkdate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles chkdate.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = chkdate.Text
            If etsdate(senddate, "") = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                chkdate.Text = etsdate(senddate, "")

                Select Case DateDiff(DateInterval.Day, CDate(chkdate.Text), Today)
                    Case Is < -1
                        MsgBox("Date is before Yesterday.  Please enter another date.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    Case Is > 30
                        MsgBox("Date is more than 30 days from Today. Use the mouse to re-enter if wrong'")
                End Select
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
            End If
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub chkdate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkdate.Leave
        Call ets_de_selected()
        chkdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub endchkdate_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles endchkdate.Enter
        Me.ActiveControl.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
    End Sub

    Private Sub endchkdate_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles endchkdate.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = endchkdate.Text
            If etsdate(senddate, "") = "N" Then
                MsgBox("Bad date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                endchkdate.Text = etsdate(senddate, "")
                System.Windows.Forms.SendKeys.Send("{tab}")
                KeyAscii = 0
            End If
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub endchkdate_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles endchkdate.Leave
        endchkdate.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub bankname_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BankName.Enter
        BankName.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
        If Len(BankName.Text) = 0 Then
            '     bankname.Text = bankname.Items(0)
        End If
        BankName.SelectionStart = 0
        BankName.SelectionLength = Len(BankName.Text)

    End Sub

    Private Sub bankname_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankName.SelectedIndexChanged
        BankKey = BankName.SelectedValue.ToString
    End Sub

    Private Sub bankname_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles BankName.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If (KeyAscii = 13 Or KeyAscii = 9) And BankName.SelectedText.ToString.Length = 0 Then
            MsgBox("Please enter a name or select from the list")
            BankName.Focus()
            GoTo EventExitSub
        End If

        BankKey = BankName.SelectedValue.ToString

        If checkYN("nam_bank", "bank_key", BankKey) = "N" Then
            MsgBox(BankName.DisplayMember & " is an invalid bank.  Please select from the list")
            GoTo EventExitSub
        End If

        KeyAscii = 0
        BankKey = BankName.SelectedItem.ToString

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub bankname_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BankName.Leave
        BankName.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub frmcompchk_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'fill bankname combobox
        Dim bkname As List(Of ContactData) = ETSSQL.GetContactData(0, "nam_bank")
        BankName.DataSource = bkname
        BankName.SelectedItem = 0
        BankName.Focus()
        BankName.SelectAll()

    End Sub

    Private Sub one_vouch_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles one_vouch.Enter
        one_vouch.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 255, 255))
    End Sub

    Private Sub one_vouch_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles one_vouch.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 13 Or KeyAscii = 9 Then
            If Len(one_vouch.Text) = 0 Then
                MsgBox("Please enter a number")
                GoTo EventExitSub
            End If
            If Not IsNumeric(one_vouch.Text) Then
                MsgBox("Not a valid number")
                Call ets_set_selected()
                GoTo EventExitSub
            End If
            If chkvouchnumverify(CStr(one_vouch.Text)) = "N" Then
                MsgBox("This voucher number has not been entered.")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            'check if already paid
            If ValidateDatumYN("payment", "vouch_num", one_vouch.Text) = "Y" Then 'already entered
                Response = MsgBox("Voucher already paid. Enter more vouchers?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1)
                If Response = 6 Then 'yes clear text box    
                    one_vouch.Text = ""
                    Call ets_set_selected()
                    GoTo EventExitSub
                Else      'answer is no then don't add a record to apchecks
                    one_vouch.Text = ""
                    begchknum.Visible = True
                    begchknum.Focus()
                End If
            Else

            End If

            If ValidateDatumYN("apchecks", "vouch_num", one_vouch.Text) = "Y" Then 'already entered
                Response = MsgBox("Duplicate Selection. Enter more vouchers?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1)
                If Response = 6 Then 'yes clear text box    
                    one_vouch.Text = ""
                    Call ets_set_selected()
                    GoTo EventExitSub
                Else      'answer is no then don't add a record to apchecks
                    one_vouch.Text = ""
                    begchknum.Visible = True
                    begchknum.Focus()
                End If
            End If

            PayType = "ONE"
            Call GetPayableVouchers()
            If VoucherList.Length = 1 Then
                MsgBox("No Vouchers to process for this voucher and bank.")
                Exit Sub
            End If
            Call WriteAPChecks()

            'frmed_chks.ShowDialog()
            Response = MsgBox("Do you want to enter another voucher?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1)
            If Response = 6 Then
                'yes clear text box
                one_vouch.Text = ""
                one_vouch.Focus()
                Exit Sub
            Else
                Label4.Visible = True
                Label5.Visible = True
                begchknum.Visible = True
                chkdate.Visible = True
                Me.prtchksel.Visible = True
                Me.begchknum.Focus()
            End If
        End If
EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub one_vouch_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles one_vouch.Leave
        one_vouch.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub range_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles range.Click
        If restart_flag = "N" Then
            Exit Sub
        End If

        dorange = "Y"
        chkdate.Text = CStr(CDate(Today))

        Label2.Visible = True
        Label3.Visible = True
        begchkdate.Visible = True
        endchkdate.Visible = True
        '  chkdate.Visible = True
        prtedit.Visible = True
        System.Windows.Forms.SendKeys.Send("{TAB}")
        KeyAscii = 0

    End Sub

    Private Sub prtedit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prtedit.Click
        'this should clear apcheck whenever it is clicked
        sqlstmnt = "Delete from apchecks"
        ETSSQL.ExecuteSQL(sqlstmnt)
        PayType = "RANGE"
        Call GetPayableVouchers()
        If VoucherList.Length = 1 Then
            MsgBox("No Vouchers to process for this selection of bank and date range.")
            Exit Sub
        End If
        Call WriteAPChecks()

        frmed_chks.ShowDialog()

        Label4.Visible = True
        Label5.Visible = True
        begchknum.Visible = True
        chkdate.Visible = True

        Me.prtchksel.Visible = True
        Me.begchknum.Focus()

    End Sub

    Private Sub single_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles single_Renamed.Click

        chkdate.Text = CStr(CDate(Today))
        PayType = "ONE"
        If restart_flag <> "N" Then
            '	Call del_apchecks()
        End If

        one_vouch.Visible = True
        Label6.Visible = True
        one_vouch.Focus()
        KeyAscii = 0

    End Sub

    Private Sub specific_Chk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles specific_Chk.Click
        'all payable vouchers
        chkdate.Text = CStr(CDate(Today))
        PayType = "ALL"
        'this should clear apcheck whenever it is clicked
        sqlstmnt = "Delete from apchecks"
        ETSSQL.ExecuteSQL(sqlstmnt)

        If restart_flag = "N" Then
            Exit Sub
        End If

        Call GetPayableVouchers()
        If VoucherList.Length = 1 Then
            MsgBox("No Vouchers to process for this selection of Bank.")
            Exit Sub
        End If
        Call WriteAPChecks()

        frmed_chks.ShowDialog()

        Label4.Visible = True
        Label5.Visible = True
        begchknum.Visible = True
        chkdate.Visible = True


        Me.prtchksel.Visible = True
        Me.begchknum.Focus()

    End Sub

    Public Sub GetPayableVouchers()

        sqlstmnt = "select * From voucher WHERE (((voucher.vouch_line)=1) "
        sqlstmnt = sqlstmnt & " and (voucher.dflag <> 'Y')"
        sqlstmnt = sqlstmnt & " and (voucher.paid <> 'Y' )"
        sqlstmnt = sqlstmnt & " and (voucher.void <> 'Y' )"
        sqlstmnt = sqlstmnt & " and (bank_key = '" & BankName.SelectedValue.ToString & "')"
        Select Case PayType
            Case "RANGE"
                sqlstmnt = sqlstmnt & " and ((voucher.dt_tbe_pd) Between '"
                sqlstmnt = sqlstmnt & begchkdate.Text & "' And '" & endchkdate.Text & "')) order by voucher.name_key,voucher.vouch_num"

            Case "ALL"
                sqlstmnt = sqlstmnt & ")"
                'nothing left out
            Case "ONE"
                sqlstmnt = sqlstmnt & " and (vouch_num = '" & one_vouch.Text & "'))"
        End Select

        VoucherList = ETSSQL.GetVoucherList(sqlstmnt)

    End Sub

    Public Sub WriteAPChecks()
        ' voucher can be added to apchecks - add the basics then update the fields that need work
        'the vouchers to be added are in a string voucher list to be split 
        Dim vouchers As String() = VoucherList.Split("*")
        For Each voucher In vouchers
            If Len(voucher) <> 0 Then
                sqlstmnt = "insert into apchecks (vouch_num, name_key, screen_nam, vouch_amt, disc_amt, agency, vend_inv, sort_name, bank_key)"
                sqlstmnt = sqlstmnt & " select vouch_num, name_key, screen_nam, vouch_amt, disc_amt, agency, vend_inv, sort_name, bank_key  from voucher where vouch_num = '" & voucher & "' and vouch_line = 1"
                ETSSQL.ExecuteSQL(sqlstmnt)
                'for this voucher total payments and discounts (group by) and update apchecks
                sqlstmnt = "update apchecks set amt_paid = (select isnull(sum(chk_alloc),0) as amt_paid from payment where vouch_num = ' " & voucher & "' and void <> 'Y')"
                ETSSQL.ExecuteSQL(sqlstmnt)
                sqlstmnt = "update apchecks set amt_disc = (select isnull(sum(chk_disc),0) as amt_disc from payment where vouch_num = ' " & voucher & "' and void <> 'Y') "
                ETSSQL.ExecuteSQL(sqlstmnt)
                sqlstmnt = "update apchecks set bal_due = vouch_amt - amt_paid + amt_disc"
                ETSSQL.ExecuteSQL(sqlstmnt)
                sqlstmnt = "update apchecks set n_chk_amt  = bal_Due"
                ETSSQL.ExecuteSQL(sqlstmnt)
            End If
        Next

    End Sub

    Private Sub prtchksel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prtchksel.Click

        If Len(begchknum.Text) = 0 Then
            MsgBox("Please enter a starting check number.")
            begchknum.Focus()
            Exit Sub
        End If

        sqlstmnt = "update rpthead set PackageType = 'AP', beg_date = '" & begchkdate.Text & "', end_date = '" & endchkdate.Text & "', beg_num = '" & begchknum.Text & "', check_date = '" & chkdate.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        'line up apchecks
        'sort name and voucher order
        'put in chkdate
        'put in chknumber and increment when vouch line = 1 or > 15
        sqlstmnt = " with cte as (Select sort_name,vouch_num, chk_num ,  row_number() over(partition by name_key order by sort_name) as rownumber from apchecks) "
        sqlstmnt = sqlstmnt & " update cte  set chk_num =cte.rownumber  where rownumber not between  2 and 15"
        sqlstmnt = sqlstmnt & " update apchecks set chk_num = 1 where chk_num > 15;"
        sqlstmnt = sqlstmnt & " declare @ChkNum int"
        sqlstmnt = sqlstmnt & " set @ChkNum = " & begchknum.Text & " "
        sqlstmnt = sqlstmnt & " declare @ChkType int"
        sqlstmnt = sqlstmnt & " declare ChkCursor Cursor for select chk_num from apchecks order by sort_name, chk_num desc,vouch_num;"
        sqlstmnt = sqlstmnt & " open chkcursor;"
        sqlstmnt = sqlstmnt & " fetch next from chkcursor  into @ChkType;"
        sqlstmnt = sqlstmnt & " while @@FETCH_STATUS = 0"
        sqlstmnt = sqlstmnt & " begin"
        sqlstmnt = sqlstmnt & " if @ChkType <> 0"
        sqlstmnt = sqlstmnt & " begin"
        sqlstmnt = sqlstmnt & " set @chknum = @chknum +1"
        sqlstmnt = sqlstmnt & " update apchecks set chk_num = @ChkNum where current of chkcursor"
        sqlstmnt = sqlstmnt & " End"
        sqlstmnt = sqlstmnt & " Else"
        sqlstmnt = sqlstmnt & " begin"
        sqlstmnt = sqlstmnt & " update apchecks set chk_num = @ChkNum where current of chkcursor"
        sqlstmnt = sqlstmnt & " End"
        sqlstmnt = sqlstmnt & " fetch next from chkcursor into @ChkType;"
        sqlstmnt = sqlstmnt & " End"
        sqlstmnt = sqlstmnt & " close chkcursor;"
        sqlstmnt = sqlstmnt & " deallocate chkcursor;"

        ETSSQL.ExecuteSQL(sqlstmnt)

        sqlstmnt = "update apchecks set chk_date = '" & chkdate.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        MsgBox(" You are about to print the Pre-Check Edit. Be sure your printer is turned on and on line.")

        ' print the pre check edit to printer
        prtDestination = 1
        prtreportfilename = ap_report_path & "apprechk.rpt"
        CrystalForm.ShowDialog()

        MsgBox("Wait for Pre Check Edit To Print")

        Response = MsgBox("Check the proof.  Choose No to edit or Yes to print checks.", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
        If Response = 7 Then
            '	frmed_chks.ShowDialog()
            begchknum.Focus()
            Exit Sub
        Else
            'xx this is the proper place to print checks

            Call pad_check_apron()
            MsgBox("Check the printer and make sure it is one line and the checks are lined up.")
            'Yes will select Laser/ No will select Dot Matrix
            MsgBox("The Checks will now print on the Laser Printer.")
            Response = MsgBoxResult.Yes
            If Response = MsgBoxResult.Yes Then
                prtDestination = 1
                prtreportfilename = ap_report_path & "aplaser.rpt"
                CrystalForm.ShowDialog()
                Response = MsgBox("Did the checks all print?", MsgBoxStyle.YesNo)
                If Response = 6 Then
                    prtreg.Visible = True
                    prtreg.Focus()
                    prtchksel.Enabled = False
                Else
                    frmre_chk.ShowDialog()
                    prtreg.Visible = True
                    prtreg.Focus()
                End If


            Else
                If Response = MsgBoxResult.No Then
                    MsgBox("This is no longer an option.!")
                End If


                Response = MsgBox("Did the checks all print?", MsgBoxStyle.YesNo)
                If Response = 6 Then
                    prtreg.Visible = True
                    prtreg.Focus()
                Else
                    frmre_chk.ShowDialog()
                    prtreg.Visible = True
                    prtreg.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub prtreg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles prtreg.Click

        Response = MsgBox("Do you want to update the records and print the Check Register?", vbYesNo)
        If Response = 6 Then

            sqlstmnt = "insert into payment(chk_num,vouch_num,name_key,dt_paid,chk_alloc,chk_disc,net_Amt,encum_date,entry_Date,screen_nam,bank_key,dr_Acct_nu,cr_acct_nu,disc_acct, jrnl_num, jrnl_line) "
            sqlstmnt = sqlstmnt & " SELECT     apchecks.chk_num, apchecks.vouch_num, apchecks.name_key, apchecks.chk_date, apchecks.n_chk_amt + apchecks.n_dis_amt AS Expr1, apchecks.n_dis_amt, "
            sqlstmnt = sqlstmnt & " apchecks.n_chk_amt, apchecks.chk_date AS Expr2, CONVERT(date, GETDATE()) AS expr3, apchecks.screen_nam, apchecks.Bank_key, voucher.cr_acct_nu, "
            sqlstmnt = sqlstmnt & "  nam_Bank.dr_pref_ac, nam_vend.disc_acct, '0' AS Expr4, '0' AS Expr5"
            sqlstmnt = sqlstmnt & " FROM         apchecks INNER JOIN"
            sqlstmnt = sqlstmnt & "       nam_Bank ON apchecks.Bank_key = nam_Bank.bank_key INNER JOIN"
            sqlstmnt = sqlstmnt & "    nam_vend ON apchecks.name_key = nam_vend.name_key INNER JOIN"
            sqlstmnt = sqlstmnt & "   voucher ON apchecks.vouch_num = voucher.vouch_num AND voucher.vouch_line = 1"
            ETSSQL.ExecuteSQL(sqlstmnt)
            'update paid flag in voucher
            sqlstmnt = " declare @VouchNum int "
            sqlstmnt = sqlstmnt & " declare VouchCursor Cursor for Select vouch_num FROM  apchecks  WHERE     (bal_due = n_chk_amt); "
            sqlstmnt = sqlstmnt & " open VouchCursor;"
            sqlstmnt = sqlstmnt & " fetch next from vouchcursor into @vouchnum;"
            sqlstmnt = sqlstmnt & " While @@fetch_status = 0"
            sqlstmnt = sqlstmnt & " begin "
            sqlstmnt = sqlstmnt & " update voucher set paid = 'Y' where vouch_num = @vouchnum "
            sqlstmnt = sqlstmnt & " fetch next from vouchcursor into @vouchnum;"
            sqlstmnt = sqlstmnt & " End "
            sqlstmnt = sqlstmnt & " close vouchcursor;"
            sqlstmnt = sqlstmnt & "deallocate vouchcursor;"
            ETSSQL.ExecuteSQL(sqlstmnt)

            sqlstmnt = " Delete from apchecks"
            ETSSQL.ExecuteSQL(sqlstmnt)

        Else
            MsgBox("If you wish to start over, click the cancel button after this message.")

        End If
        Me.Close()
        frmlck.Show()

    End Sub

End Class