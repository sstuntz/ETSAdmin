Option Strict On
Option Explicit On
Option Compare Text

Imports System.Data.SqlClient
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common


Namespace ETS.Common

    Public Class Module1

        Declare Sub copy Lib "kernel" (ByVal rename_string As String)
        Declare Function sendmessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wmsg As Integer, ByVal wParam As Short, ByVal lParam As String) As Integer
        Public Const lb_findstring As Integer = &H18F


        'Declare Function GetActiveWindow Lib "user32" () As Integer
        'Declare Function IsWindow Lib "user32" (ByVal hwnd As Integer) As Integer
        'Declare Function CopyFile Lib "kernel32" Alias "CopyFileA" (ByVal lpExistingFileName As String, ByVal lpNewFileName As String, ByVal bFailIfExists As Integer) As Integer

        Declare Function GetActiveWindow Lib "user32" () As Integer
        Declare Function IsWindow Lib "user32" (ByVal hwnd As Integer) As Integer
        Declare Function CopyFile Lib "kernel32" Alias "CopyFileA" (ByVal lpExistingFileName As String, ByVal lpNewFileName As String, ByVal bFailIfExists As Integer) As Integer

        Public Shared acct_num_blank As String
        Public Shared acct_num_len As Integer
        Public Shared actual_row As Integer
        Public Shared agency_name As String
        Public Shared AgencyNum As Integer
        Public Shared am_data_path As String
        Public Shared am_report_path As String
        Public Shared am1_Data_path As String
        Public Shared am1_documents_path As String
        Public Shared am1_report_path As String
        Public Shared ap_control_acct As String
        Public Shared ap_data_path As String
        Public Shared ap_report_path As String
        Public Shared ar_data_path As String
        Public Shared ar_report_path As String
        Public Shared att_data_path As String
        Public Shared att_report_path As String
        Public Shared AcctNums As AutoCompleteStringCollection
        Public Shared avail_apps As Integer
        Public Shared backup_cd As String
        Public Shared backup_string As String
        Public Shared backup_zip As String
        Public Shared bank_dr_acct_nu As String
        Public Shared bank_name_key As String
        Public Shared bank_screen_nam As String
        Public Shared batch_num As Integer
        Public Shared batch_open_list As String
        Public Shared batch_open_list1 As String
        Public Shared calling_form As String
        Public Shared cc_data_path As String
        Public Shared cc_report_path As String
        Public Shared cchr_data_path As String
        Public Shared cchr_report_path As String
        Public Shared chacct_Array(1000, 2) As Object
        Public Shared chknumber As Integer
        Public Shared chksel(1000, 2) As Object
        Public Shared CheckPwd As String
        Public Shared code As Integer
        Public Shared ct_data_path As String
        Public Shared ct_report_path As String
        Public Shared cust_cr_acct As String
        Public Shared cust_dr_acct As String
        Public Shared cust_name_key As String
        Public Shared cust_num As String
        Public Shared cust_phone_num As String
        Public Shared cust_screen_nam As String
        Public Shared cust_sort_name As String
        Public Shared db As String
        Public Shared dbopen As String
        Public Shared DefaultInvoicePrinter As String
        Public Shared delay_array(500, 3) As String
        Public Shared dhb_data_path As String
        Public Shared dhb_report_path As String
        Public Shared discount_account As String
        Public Shared dollars As Decimal
        Public Shared edit_recordsource As String
        Public Shared ee_data_path As String
        Public Shared ee_report_path As String
        Public Shared eehr_data_path As String
        Public Shared eehr_report_path As String
        Public Shared entry_type As String 'to tell entry form if an add or edit
        Public Shared entry_type_ee As String 'needed since ee entry multiple forms each with lookups
        Public Shared entry_type_saved As String
        Public Shared ets_back_color As String
        Public Shared first_voucher_record As String
        Public Shared fnum As Integer
        Public Shared fnum1 As Integer
        Public Shared form_showing As String
        Public Shared formm As String
        Public Shared function_type As String
        Public Shared function_type_saved As String
        Public Shared gl_data_path As String
        Public Shared gl_report_path As String
        Public Shared highest_name_key As String
        Public Shared i As Short
        Public Shared intcount As Integer
        Public Shared InvoiceLocation As String
        Public Shared InvoicePath As String
        Public Shared je_type As String
        Public Shared KeyAscii As Integer
        Public Shared max_grid_line As Integer
        Public Shared mfr_data_path As String
        Public Shared mfr_report_path As String
        Public Shared mm_data_path As String
        Public Shared mm_report_path As String
        Public Shared msg As String
        Public Shared name_level As String
        Public Shared name_Type As String
        Public Shared nextrecord As Integer
        Public Shared num As Integer
        Public Shared num_type As String
        Public Shared num1 As Integer
        Public Shared num2 As Integer
        Public Shared num3 As Integer
        Public Shared num4 As Integer
        Public Shared num5 As Integer
        Public Shared offset_grid_line As Short
        Public Shared package_Type As String
        Public Shared package_Type_saved As String
        Public Shared paid_amount As Decimal
        Public Shared paid_disc_amt As Decimal
        Public Shared pass_level As Integer
        Public Shared pca_data_path As String
        Public Shared pca_report_path As String
        Public Shared pr_end_date As Date
        Public Shared pr_num As Integer
        Public Shared pr_Start_date As Date
        Public Shared present_grid_line As Integer
        Public Shared prtCopiesToPrinter As Integer
        Public Shared prtDestination As Integer
        Public Shared prtDiscardSavedData As Integer
        Public Shared prtParameterFields(20) As String
        Public Shared prtParameterFieldsName(20) As String
        Public Shared prtParameterFieldsValue(20) As String
        Public Shared prtParameterFieldsBoolean(20) As String
        Public Shared prtPrinterName As String
        Public Shared prtreportfilename As String
        Public Shared prtWindowState As Integer
        Public Shared rb_data_path As String
        Public Shared rb_report_path As String
        Public Shared reimb(100) As String
        Public Shared rename_string(100) As String
        Public Shared reportsel(100, 3) As Object
        Public Shared ReportPath As String
        Public Shared Response As Integer
        Public Shared retacct As String
        Public Shared retacctdesc As String
        Public Shared retdate As Date
        Public Shared retdpt As String
        Public Shared retdptdesc As String
        Public Shared retlook As String
        Public Shared retlookup As String
        Public Shared retlookupdesc As String
        Public Shared retstate As String
        Public Shared retstring As String
        Public Shared rpt_path As String
        Public Shared rpt_Type As String
        Public Shared save_bank_key As String
        Public Shared save_entry_date As Object
        Public Shared save_vouch_num As String 'for the reinstated voucher
        Public Shared save_voucher_num As String
        Public Shared saved_acct_num As String
        Public Shared saved_active_control As String
        Public Shared saved_active_form As String
        Public Shared saved_amount As Decimal
        Public Shared saved_cr_Acct As String
        Public Shared saved_data_path As String
        Public Shared saved_Date As Date
        Public Shared saved_entry_type As String
        Public Shared saved_function_Type As String
        Public Shared saved_name_key As String
        Public Shared saved_package_Type As String
        Public Shared saved_screen_nam As String
        Public Shared selected_acct_num As String = ""
        Public Shared selected_acct_num_desc As String
        Public Shared selected_Date_Range_End As Date
        Public Shared selected_Date_Range_Start As Date
        Public Shared selected_ded_code As String
        Public Shared selected_ded_num As String
        Public Shared selected_desc As String
        Public Shared selected_dpt_desc As String
        Public Shared selected_dpt_num As String
        Public Shared selected_end_date As Date
        Public Shared selected_file As String
        Public Shared selected_inv_num As Integer
        Public Shared selected_job_desc As String
        Public Shared selected_job_num As String
        Public Shared selected_line_num As Integer
        Public Shared selected_loc As String
        Public Shared selected_loc_desc As String
        Public Shared selected_loc_num As String
        Public Shared selected_lookup_date As Date
        Public Shared selected_lookup_desc As String
        Public Shared selected_lookup_num As String
        Public Shared selected_lookup_type As String
        Public Shared selected_name_key As String
        Public Shared selected_name_key_ee As String
        Public Shared selected_plan_desc As String
        Public Shared selected_recordsource As String
        Public Shared selected_report As String
        Public Shared selected_screen_nam As String
        Public Shared selected_screen_nam_ee As String
        Public Shared selected_slot_ih As String
        Public Shared selected_slot_loc As String
        Public Shared selected_slot_num As String
        Public Shared selected_sort_name As String
        Public Shared selected_start_date As Date
        Public Shared selected_voucher As Integer
        Public Shared selectedcell As Boolean
        Public Shared SelectedIndex As Integer
        Public Shared sendacct As String
        Public Shared senddate As String
        Public Shared senddpt As String
        Public Shared sendlook As String
        Public Shared sendlookup As String
        Public Shared sendstate As String
        Public Shared singl As String
        Public Shared sqlstmnt As String = ""
        Public Shared temp_row As Integer
        Public Shared tmp_data_path As String
        Public Shared tmp_report_path As String
        Public Shared top_data_path As String
        Public Shared top_path As String
        Public Shared tot_amt As Decimal
        Public Shared tots(22) As Double
        Public Shared trn_data_path As String
        Public Shared trn_report_path As String
        Public Shared v_date As Object
        Public Shared valid_acct As String
        Public Shared valid_check As String
        Public Shared valid_Date As String
        Public Shared valid_dpt As String
        Public Shared valid_look As String
        Public Shared valid_lookup As String
        Public Shared valid_name As String
        Public Shared valid_State As String
        Public Shared valid_vouch As String
        Public Shared valid_YN As String
        Public Shared vend_disc_Acct As String
        Public Shared void_voucher As String
        Public Shared vouch_cr_acct As String
        Public Shared vouch_dr_acct As String
        Public Shared vouch_name_key As String
        Public Shared vouch_num_temp(1000) As String
        Public Shared vouch_screen_nam As String
        Public Shared voucher_counter As Integer
        Public Shared voucher_detail_grid(100, 5) As String
        Public Shared voucher_line_max As Integer
        Public Shared voucherlastrecord As Integer
        Public Shared voucherposition As Integer
        Public Shared voucherrecordlen As Integer

        Public Shared Function AutoAcctNums() As AutoCompleteStringCollection
            Dim autoacctnum As New AutoCompleteStringCollection
            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select Acct_num from chacct where acct_Active = 'Y' order by acct_num"
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                While rs.Read()
                    autoacctnum.Add(rs("acct_num").ToString)
                End While
                rs.Close()
            End Using

            Return autoacctnum

        End Function



        Public Shared Sub bank_nameget(ByVal bank_num As String) 'from ap.mod needed for inv/workshop

            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select name_key,screen_nam,dr_pref_ac from nam_bank where name_key = '" & bank_num & "'"
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                While rs.Read()
                    bank_name_key = rs("name_key").ToString
                    bank_screen_nam = rs("screen_nam").ToString
                    bank_dr_acct_nu = rs("dr_pref_ac").ToString
                End While
                rs.Close()
            End Using

        End Sub

        Public Shared Function checkYN(ByVal tbl As String, ByVal fld As String, ByVal flddata As String) As String
            Dim intcount As Integer = 0
            Dim chkyn As String = "N"
            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select * from " & tbl & " where " & fld & " = '" & flddata & "'"
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)

                While rs.Read()
                    intcount = intcount + 1
                End While
                rs.Close()
            End Using

            If intcount = 0 Then
                chkyn = "N"
            Else
                chkyn = "Y"
            End If

            Return chkyn

        End Function

        Public Shared Function CheckRecordCount(ByVal sqlstmnt As String) As Integer
            Dim intcount As Integer = 0
            Dim NumRecs As Integer = 0

            Using db As Database = New Database(top_data_path)
                Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)

                While rs.Read()
                    intcount = intcount + 1
                End While
                rs.Close()
            End Using

            Return intcount

        End Function

        Public Shared Function CheckValidDate(ByVal ChkDate As String) As Boolean
            If IsDate(ChkDate) = True Then
                Return True
            Else
                Return False
            End If


        End Function

        Public Shared Function chk_acct_num_only(ByVal sendacct As String, ByVal valid_acct As String) As String
            valid_acct = "N"
            valid_acct = checkYN("chacct", "acct_num", CStr(sendacct))
            Return valid_acct
        End Function

        Public Shared Sub chk_acct_dpt_only(ByVal sendacct As String, ByVal valid_acct As String)
            valid_acct = checkYN("dept", "acct_dpt", CStr(sendacct))
        End Sub

        Public Shared Sub chk_ref_num_only(ByVal sendacct As String, ByVal valid_acct As String)
            'not tested
            valid_acct = checkYN("dept", "acct_dpt", CStr(sendacct))

        End Sub

        Public Shared Sub chk_acct_pgm_only(ByVal sendacct As String, ByVal valid_acct As String)

            valid_acct = checkYN("prog", "acct_pgm", CStr(sendacct))

        End Sub

        Public Shared Sub ETSForm(ByRef frmtarget As System.Windows.Forms.Form)
            Dim num As Integer
            frmtarget.WindowState = FormWindowState.Normal
            frmtarget.FormBorderStyle = FormBorderStyle.None
            ctrform(frmtarget)
            For num = 0 To frmtarget.Controls.Count - 1
                Select Case True
                    Case TypeOf (frmtarget.Controls(num)) Is Button
                        frmtarget.Controls(num).Font = New System.Drawing.Font("Arial", 10)
                    Case TypeOf (frmtarget.Controls(num)) Is Label
                        frmtarget.Controls(num).Font = New System.Drawing.Font("Arial", 10)
                End Select
            Next
            On Error Resume Next
            frmtarget.Controls.Item("label99").Text = frmtarget.Text
            frmtarget.Controls.Item("label99").Font = New System.Drawing.Font("Arial", 10, FontStyle.Bold)
            On Error GoTo 0

        End Sub

        Public Shared Sub ctrform(ByRef frmtarget As System.Windows.Forms.Form)
            Dim rect As Rectangle = Screen.PrimaryScreen.WorkingArea
            'Divide the screen in half, and find the center of the form to center it
            frmtarget.Top = CInt((rect.Height / 2) - (frmtarget.Height / 2))
            frmtarget.Left = CInt((rect.Width / 2) - (frmtarget.Width / 2))
        End Sub

        Public Shared Sub ets_set_selected()
            On Error Resume Next
            '  If Form.ActiveForm.ActiveControl.GetType Then
            Form.ActiveForm.ActiveControl.BackColor = Color.Aqua '(RGB(0, 255, 255))

            On Error GoTo 0
        End Sub

        Public Shared Sub ets_de_selected()
            ' Form.ActiveForm.ActiveControl.BackColor = Color.White

        End Sub

        Public Shared Function etsdptnum_chk(ByVal senddpt As String, ByVal retdpt As String, ByVal retdptdesc As String) As String

            If (senddpt) = "" Then
                dptnumlookup.ShowDialog()
                senddpt = selected_dpt_num
                retdpt = selected_dpt_num
                retdptdesc = selected_dpt_desc
                valid_dpt = selected_dpt_num
            Else
                Dim intcount As Integer = 0

                Using db As Database = New Database(top_data_path)
                    Dim sql As String = "select * from dept where acct_dpt = '" & senddpt & "'"
                    Dim rs As SqlDataReader = db.ExecuteQuery(sql)

                    While rs.Read()
                        retdptdesc = rs("dept_desc").ToString
                        retdpt = rs("dept_num").ToString
                        intcount = intcount + 1
                    End While
                    rs.Close()
                End Using

                If intcount = 0 Then
                    valid_dpt = "N"
                Else
                    valid_dpt = senddpt
                End If
            End If
            Return valid_dpt

        End Function

        Public Shared Function ChkDptNum(ByVal senddpt As String) As String
            valid_dpt = "N"
            If (senddpt) = "" Then
                dptnumlookup.ShowDialog()
                senddpt = selected_dpt_num
                retdpt = selected_dpt_num
                retdptdesc = selected_dpt_desc
                valid_dpt = "Y"
            Else
                Dim intcount As Integer = 0
                Using db As Database = New Database(top_data_path)
                    Dim sql As String = "select * from dept where acct_dpt = '" & senddpt & "'"
                    Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                    While rs.Read()
                        retdptdesc = rs("dept_desc").ToString
                        retdpt = rs("dept_num").ToString
                        intcount = intcount + 1
                    End While
                    rs.Close()
                End Using
                If intcount = 0 Then
                    valid_dpt = "N"
                Else
                    valid_dpt = "Y"
                End If
            End If
            Return valid_dpt
        End Function

        Public Shared Sub acctnumsetup()
            acct_num_blank = "____-__-__"
            acct_num_len = 10 'includes dashes
            Dim intcount As Integer = 0

            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select top 1 * from chacct "
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                While rs.Read()
                    retdptdesc = rs("acct_only").ToString
                    intcount = intcount + 1
                End While
                rs.Close()
            End Using
            If intcount = 0 Then
                MsgBox("No Chart of Account available.  Can not run software.  call ETS.")
            End If

            intcount = 0
            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select top 1 * from glsys "
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                While rs.Read()
                    intcount = intcount + 1
                    acct_num_len = CInt(rs("Acct_num_len").ToString)
                    acct_num_blank = rs("Acct_num_blank").ToString
                End While
                rs.Close()
            End Using

            If intcount = 0 Then
                MsgBox("No GLSys table available.  Can not run software.  call ETS.")
            End If

        End Sub

        Public Shared Function chkname_top(ByVal name_key As String) As String
            'to be used for getting sort name and screen nam
            'not to be used for checking names during data entry the procedure below is for that
            'it depends on look ups to the short list
            Dim intcount As Integer = 0

            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select screen_nam, sort_name, name_key from nam_addr where name_key = '" & name_key & "'"
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                While rs.Read()
                    selected_name_key = rs("name_key").ToString
                    selected_screen_nam = rs("screen_nam").ToString
                    selected_sort_name = rs("sort_name").ToString
                    intcount = intcount + 1
                End While
                rs.Close()
            End Using

            If intcount = 0 Then
                Return "N"
            Else
                Return "Y"
            End If

        End Function

        Public Shared Function chkname(ByVal name_key As String) As String
            Dim TblName As String = ""
            TblName = "nam_addr"
            'Select Case package_Type
            '    Case "GL"
            '        TblName = "nam_bank"
            '    Case "AP"
            '        TblName = "nam_vend"
            '    Case "AR"
            '        TblName = "nam_cust"
            '    Case "ATT"
            '        TblName = "cc_base"
            '    Case "AM"
            '        TblName = "cc_base"
            '    Case "MM"
            '        TblName = "cc_base"
            '    Case "PCA"

            '    Case "CC"
            '        TblName = "nam_cc"
            '    Case "CCHR"
            '        TblName = "cct_base"
            '    Case "EE"
            '        TblName = "nam_ee"
            '    Case "EEHR"
            '        TblName = "ee_base"
            '    Case "DHB"

            '    Case "RB"

            '    Case "TRN"

            '    Case "MFR"

            '    Case "CT"

            '    Case Else
            '       
            'End Select
            Dim intcount As Integer = 0
            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select name_key, screen_nam, sort_name from " & TblName & " where name_key = '" & name_key & "'"
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)


                While rs.Read()
                    selected_name_key = rs("name_key").ToString
                    selected_screen_nam = rs("screen_nam").ToString
                    selected_sort_name = rs("sort_name").ToString
                    intcount = intcount + 1
                End While
                rs.Close()
            End Using

            If intcount = 0 Then
                valid_name = "N"
            Else
                valid_name = "Y"
            End If

            Return valid_name

        End Function

        Public Shared Sub vend_nameget(ByVal vend_num As String)
            'needs to return a list
            Dim intcount As Integer = 0
            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select * from nam_vend where name_key = '" & vend_num & "'"
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                While rs.Read()
                    vouch_name_key = rs("name_key").ToString
                    vouch_screen_nam = rs("screen_nam").ToString
                    vouch_dr_acct = rs("dr_pref_ac").ToString
                    vouch_cr_acct = rs("cr_pref_ac").ToString
                    vend_disc_Acct = rs("disc_Acct").ToString
                    intcount = intcount + 1
                End While
                rs.Close()
            End Using

            If intcount = 0 Then
                valid_name = "N"
            Else
                valid_name = "Y"
            End If

        End Sub

        Public Shared Function etsdate(ByVal senddate As String, ByVal valid_Date As String) As String
            ' returns a string that is a valid date or an N to say date entered was  not valid
            Dim xnum As Integer
            Dim myyear As Integer

            'first check if date is ok as typed if not add characters
            If Not IsDate(senddate) Then
                xnum = senddate.Length
                myyear = Year(Today)
                Select Case xnum
                    Case 4
                        senddate = Left(senddate, 2) & "/" & Right(senddate, 2)
                        senddate = senddate & "/" & myyear
                        GoTo validdate
                    Case 6
                        senddate = Left(senddate, 2) & "/" & Mid(senddate, 3, 2) & "/" & Right(senddate, 2)
                        GoTo validdate
                    Case 8
                        senddate = Left(senddate, 2) & "/" & Mid(senddate, 3, 2) & "/" & Right(senddate, 4)
                        GoTo validdate
                    Case Else
                        valid_Date = "N"
                        Return valid_Date
                        Exit Function
                End Select

validdate:
                If Not IsDate(senddate) Then
                    valid_Date = "N"
                    KeyAscii = 0
                Else
                    valid_Date = senddate
                End If
            Else
                'original date ok as entered
                valid_Date = senddate
            End If

            'year test for SQL
            If valid_Date <> "N" Then
                If Year(CDate(valid_Date)) < 1901 Then
                    valid_Date = "N"
                    KeyAscii = 0
                End If
            End If

            If IsDate(valid_Date) Then
                Dim DateConv As Date
                DateConv = CDate(valid_Date)
                valid_Date = DateConv.ToShortDateString
            End If

            Return valid_Date

        End Function

        Public Shared Sub ets_maximized()
            System.Windows.Forms.Form.ActiveForm.WindowState = System.Windows.Forms.FormWindowState.Maximized
        End Sub

        Public Shared Sub hmadp_chk(ByVal sendacct As String, ByVal retacct As String, ByVal retacctdesc As String, ByVal valid_acct As String)
            If (sendacct) = "" Then
                '    hmtadplookup.ShowDialog() 'form
                senddpt = selected_lookup_num 'variables used
                retdpt = selected_lookup_num
                retdptdesc = selected_lookup_desc
                '    dptnumlookup.ShowDialog()
                senddpt = selected_dpt_num
                retdpt = selected_dpt_num
                retdptdesc = selected_dpt_desc
                valid_acct = "Y"
            Else
                Dim intcount As Integer = 0
                Using db As Database = New Database(top_data_path)
                    Dim sql As String = "select * from adp_codes where adp_Code = '" & sendacct & "'"
                    Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                    While rs.Read()
                        retacctdesc = rs("adp_desc").ToString
                        retacct = rs("adp_code").ToString
                        intcount = intcount + 1
                    End While
                    rs.Close()
                End Using

                If intcount = 0 Then
                    valid_acct = "N"
                Else
                    valid_acct = "Y"
                End If
            End If

        End Sub

        Public Shared Sub hmtype_chk(ByVal sendacct As String, ByVal retacct As String, ByVal retacctdesc As String, ByVal valid_acct As String)
            If (sendacct) = "" Then
                'hmttypelookup.ShowDialog() 'form
                senddpt = selected_lookup_num
                retdpt = selected_lookup_num
                retdptdesc = selected_lookup_desc
                valid_acct = "Y"
            Else
                Dim intcount As Integer = 0
                Using db As Database = New Database(top_data_path)
                    Dim sql As String = "select * from job_types where type_name = '" & sendacct & "'"
                    Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                    While rs.Read()
                        retacctdesc = rs("type_desc").ToString
                        retacct = rs("type_name").ToString
                        intcount = intcount + 1
                    End While
                    rs.Close()
                End Using

                If intcount = 0 Then
                    valid_acct = "N"
                Else
                    valid_acct = "Y"
                End If
            End If
        End Sub

        Public Shared Function etsacctnum_chk(ByVal sendacct As String) As String

            If sendacct = acct_num_blank Or Len(sendacct) = 0 Then
                acctlookup.ShowDialog()
                retacct = selected_lookup_num
                retacctdesc = selected_acct_num_desc
                valid_acct = "Y"

                If entry_type = "CANCEL" Then
                    retacct = "N"
                    valid_acct = "N"
                    entry_type = ""
                End If

            Else
                Dim intcount As Integer = 0
                Using db As Database = New Database(top_data_path)
                    Dim sql As String = "select * from chacct where acct_num = '" & sendacct & "'"
                    Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                    While rs.Read()
                        retacctdesc = rs("acct_desc").ToString
                        retacct = rs("acct_num").ToString
                        intcount = intcount + 1
                    End While
                    rs.Close()
                End Using
                If intcount = 0 Then
                    retacct = "N"
                    valid_acct = "N"
                Else
                    valid_acct = "Y"
                    retacct = sendacct
                End If
            End If
            selected_acct_num = retacct
            selected_acct_num_desc = retacctdesc

            Return retacct

        End Function

        Public Shared Function ets_format(ByVal sendstring As String, ByVal retstring As String, ByVal code As Integer) As String
            Dim selected_amend_num As String = ""
            Dim selected_mmars_num As String = ""
            Dim selected_cont_id_num As String = ""
            valid_YN = "N"

            Select Case code
                Case 1 ' social security number
                    num = Len(sendstring)
                    Select Case num
                        Case 9 'add the dashes
                            retstring = Left(sendstring, 3) & "-" & Mid(sendstring, 4, 2) & "-" & Right(sendstring, 4)
                            valid_YN = "Y"
                        Case 11 'make sure dashes are right
                            If Mid(sendstring, 4, 1) = "-" Then
                                If Mid(sendstring, 7, 1) = "-" Then
                                    retstring = sendstring
                                    valid_YN = "Y"
                                End If
                            End If
                        Case Else
                            retstring = "N"
                    End Select
                Case 2 'phone number format before the x for extension and then put this back on
                    sendstring = UCase(sendstring)
                    Dim phonestring As String = sendstring
                    Dim xplace As Integer = sendstring.IndexOf("X")
                    If xplace <> -1 Then
                        sendstring = Left(sendstring, xplace)
                        phonestring = Right(phonestring, phonestring.Length - xplace)
                    End If

                    num = sendstring.Length

                    Select Case num
                        Case 10 'add the dashes
                            retstring = "(" & Left(sendstring, 3) & ") " & Mid(sendstring, 4, 3) & "-" & Right(sendstring, 4)
                            valid_YN = "Y"
                        Case 12  'has the dashes or blanks
                            If Mid(sendstring, 4, 1) = "-" Or Mid(sendstring, 4, 1) = " " Then
                                retstring = "(" & Left(sendstring, 3) & ") " & Mid(sendstring, 5, 3) & "-" & Right(sendstring, 4)
                            End If
                        Case 14     'has been formatted
                            retstring = sendstring
                        Case Else
                            retstring = "N"
                    End Select

                    If xplace <> -1 Then        ' add extension back on
                        retstring = retstring & " " & phonestring
                    End If

                    Return retstring

                Case 3 'currency check
                    ' we will check for number and if no decimal put in two places
                    retstring = String.Format(sendstring, "C")

                Case 4 'attendance contract formatting
                    If Len(sendstring) = 16 Then
                        retstring = Left(sendstring, 2) & "-" & Mid(sendstring, 3, 3) & "-" & Mid(sendstring, 6, 6) & "-" & Mid(sendstring, 12, 2) & "-" & Mid(sendstring, 14, 3)
                        selected_cont_id_num = retstring
                    Else
                        retstring = Left(sendstring, 2) & "-" & Mid(sendstring, 3, 3) & "-" & Mid(sendstring, 6, 4) & "-" & Mid(sendstring, 10, 4) & "-" & Mid(sendstring, 14, 3) & "-" & Mid(sendstring, 17, 2) & "-" & Mid(sendstring, 19, 2)
                        selected_cont_id_num = Left(sendstring, 2) & "-" & Mid(sendstring, 3, 3) & "-" & Mid(sendstring, 6, 4) & "-" & Mid(sendstring, 10, 4) & "-" & Mid(sendstring, 14, 3)
                        selected_mmars_num = Mid(sendstring, 17, 2)
                        selected_amend_num = Mid(sendstring, 19, 2)
                    End If
                    valid_YN = "Y"

            End Select
            Return retstring

        End Function

        Public Shared Function ets_state_chk(ByVal sendstate As String) As String
            Dim n As Integer

            'ADDED CANADIAN PROV 11-7-97 LHW

            Dim state As String = "AL,AK,AS,AZ,AR,CA,CZ,CO,CT,DE,DC,FL,GA,GU,HI,ID,IL,IN,IA,KS,KY,LA,ME,MD,MA,MI,MN,MS,MO,MT,NE,NV,NH,NJ,NM,NY,NC,ND,CM,OH,OK,OR,PA,PR,RI,SC,SD,TN,TX,TT,UT,VT,VA,VI,WA,WV,WI,WY,AB,BC,MB,NB,NF,NS,ON,PE,QC,SK,NT,YT"
            n = InStr(1, state, sendstate, CType(1, CompareMethod))
            If n = 0 Then sendstate = "N"
            If n <> 0 Then sendstate = "Y"
            Return sendstate

        End Function

        Public Shared Function GetJulianDate() As String
            Dim JulianDate As String = Now.Year.ToString.Substring(2, 2) & Now.DayOfYear.ToString.PadLeft(3, CChar("0"))
            Return JulianDate
        End Function

        Public Shared Function ValidateDatumYN(ByVal tbl As String, ByVal fld As String, ByVal datum As String) As String

            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select " & fld & " from " & tbl & " where " & fld & " =  '" & datum & "'"
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                Dim intcount As Integer = 0

                While rs.Read()
                    intcount = intcount + 1
                End While
                rs.Close()

                If intcount = 0 Then
                    ValidateDatumYN = "N"
                Else
                    ValidateDatumYN = "Y"
                End If
            End Using
        End Function

        Public Shared Function TestText(ByVal Txt As String, ByVal Typ As Integer) As String
            TestText = ""
            Select Case Typ
                Case 0 'numeric
                    If Len(Txt) = 0 Then Txt = "0"
                    If Not IsNumeric(Txt) Then
                        Return "NotNumeric"
                    Else
                        If CDbl(Txt) = 0 Then
                            Return "0.00"
                        Else
                            Txt = Txt.Replace(",", "")
                            Return Txt
                        End If
                    End If

                Case 1  ' remove apostrophe

                Case Else
                    Return Txt
            End Select
        End Function

    End Class

End Namespace