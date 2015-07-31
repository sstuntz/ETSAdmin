Option Strict On
Option Explicit On
Option Compare Text

Imports System.Data.SqlClient
Imports System.Configuration
Imports ETS.Common.Module1
Imports ps.common

Namespace ETS

    Public Class ApMod
        Public temp_bank_key As String ' added for miscpmt
        Public temp_check_date As String
        Public temp_check_num As Integer
        Public temp_cr_acct As String
        Public temp_dr_acct As String
        Public Shared selected_rec_vouch_num As Integer

        Public Shared Function GetNextVouchNum(ByVal VouchType As String) As Integer
            Select Case VouchType
                Case "ADD"
                    Using db As Database = New Database(top_data_path)
                        Dim sql As String = "select top 1 * from voucher order by vouch_num desc"
                        Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                        While rs.Read()
                            Return CInt(rs("vouch_num").ToString) + 1
                        End While
                        rs.Close()
                    End Using
                Case "RECURRING", "AddRECURRING"

                    Using db As Database = New Database(top_data_path)
                        Dim sql As String = "select top 1 * from rec_vouc order by vouch_num desc"
                        Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                        While rs.Read()
                            Return CInt(rs("vouch_num").ToString) + 1
                        End While
                        rs.Close()
                    End Using
            End Select
        End Function

        Public Shared Function GetNextCheckNumber(ByVal BankNum As Integer) As Integer
            Using db As Database = New Database(top_data_path)
                Dim sql As String = "select top 1 * from payment where bank_key = " & BankNum & " order by chk_num desc "
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                While rs.Read()
                    Return CInt(rs("chk_num").ToString) + 1
                End While
                rs.Close()
            End Using

        End Function

        Public Shared Function chkvouchnumverify(ByVal vouchnumber As Integer) As String

            If ETS.Common.Module1.entry_type = "RECURRING" Then
                'tell if it exists
                If ETS.Common.Module1.checkYN("rec_vouch", "vouch_num", vouchnumber.ToString) = "Y" Then
                    Return "Y"
                Else
                    Return "N"
                End If
            Else
                'tell if it does not exist
                If ETS.Common.Module1.checkYN("voucher", "vouch_num", vouchnumber.ToString) = "Y" Then
                    Return "Y"
                Else
                    Return "N"
                End If
            End If



        End Function

        Sub move_to_vchtmp()
            '        Dim n As Object
            '        Dim filename As Object
            '        Dim batch As Object
            '        Dim vchtmptable As Object
            '        On Error Resume Next
            '        'zap the temp file and then fill it with the batch
            '        Dim vchtmpdb As dao.Database
            '        'Dim vchtmptable As Table
            '        'UPGRADE_WARNING: Arrays in structure vchtmpset may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
            '        Dim vchtmpset As dao.Recordset


            '        FileClose(fnum)

            '        db = ap_data_path & "ap.mdb"
            '        vchtmpdb = DAODBEngine_definst.OpenDatabase(db)
            '        vchtmptable = vchtmpdb.OpenRecordset("vchtmp")

            '        sqlstmnt = "select * from vchtmp "

            '        vchtmpset = vchtmpdb.OpenRecordset(sqlstmnt)

            '        vchtmpset.MoveFirst()

            '        If Err.Number <> 3021 And Err.Number <> 0 Then
            '            MsgBox("Problems with temp file = " & ErrorToString(Err.Number))
            '            Exit Sub
            '        End If

            '        Do Until vchtmpset.EOF

            '            vchtmpset.Delete()
            '            vchtmpset.MoveNext()
            '        Loop

            '        voucherrecordlen = Len(voucher)

            '        fnum = FreeFile()
            '        'UPGRADE_WARNING: Couldn't resolve default property of object batch. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        'UPGRADE_WARNING: Couldn't resolve default property of object filename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        filename = batch & batch_open_list1
            '        'UPGRADE_WARNING: Couldn't resolve default property of object filename. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        FileOpen(fnum, filename, OpenMode.Random, , , voucherrecordlen) ' Open file.
            '        If Err.Number = 53 Then GoTo check_batch
            '        GoTo check_batch1

            'check_batch:
            '        MsgBox("no such batch see the system manager")
            '        Stop

            'check_batch1:

            '        'UPGRADE_WARNING: Couldn't resolve default property of object n. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '        n = 1
            '        Do While Not EOF(fnum)

            '            'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            '            FileGet(fnum, voucher)

            '            'UPGRADE_WARNING: Couldn't resolve default property of object n. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '            n = n + 1
            '            vchtmpset.AddNew()

            '            vchtmpset.Fields("dr_Acct_nu").Value = voucher.dr_Acct
            '            vchtmpset.Fields("cr_Acct_nu").Value = voucher.cr_Acct
            '            vchtmpset.Fields("vouch_num").Value = voucher.vouch_num
            '            vchtmpset.Fields("vouch_line").Value = voucher.vouch_line
            '            vchtmpset.Fields("name_key").Value = voucher.name_key
            '            vchtmpset.Fields("screen_nam").Value = voucher.screen_nam
            '            vchtmpset.Fields("cntrct_key").Value = voucher.cntrct_key
            '            vchtmpset.Fields("vend_inv").Value = voucher.vend_inv
            '            vchtmpset.Fields("vouch_amt").Value = voucher.vouch_Amt
            '            'UPGRADE_WARNING: Couldn't resolve default property of object voucher.vend_inv_d. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '            vchtmpset.Fields("vend_inv_d").Value = voucher.vend_inv_d
            '            'UPGRADE_WARNING: Couldn't resolve default property of object voucher.date_recd. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '            vchtmpset.Fields("date_recd").Value = voucher.date_recd
            '            vchtmpset.Fields("po_num").Value = voucher.po_num
            '            vchtmpset.Fields("chk_num").Value = voucher.chk_num
            '            'UPGRADE_WARNING: Couldn't resolve default property of object voucher.dt_tbe_pd. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '            vchtmpset.Fields("dt_tbe_pd").Value = voucher.dt_tbe_pd
            '            'UPGRADE_WARNING: Couldn't resolve default property of object voucher.dt_paid. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '            vchtmpset.Fields("dt_paid").Value = voucher.dt_paid
            '            vchtmpset.Fields("alloc_amt").Value = voucher.alloc_amt
            '            vchtmpset.Fields("disc_amt").Value = voucher.disc_amt
            '            vchtmpset.Fields("bank_key").Value = voucher.bank_key
            '            'UPGRADE_WARNING: Couldn't resolve default property of object voucher.entry_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '            vchtmpset.Fields("entry_date").Value = voucher.entry_date
            '            'UPGRADE_WARNING: Couldn't resolve default property of object voucher.bpost_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '            vchtmpset.Fields("bpost_Date").Value = voucher.bpost_date
            '            'UPGRADE_WARNING: Couldn't resolve default property of object voucher.encum_date. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            '            vchtmpset.Fields("encum_date").Value = voucher.encum_date
            '            vchtmpset.Fields("glpost").Value = voucher.glpost
            '            vchtmpset.Fields("reimb").Value = voucher.reimb
            '            vchtmpset.Fields("memo").Value = voucher.memo
            '            vchtmpset.Fields("bat_File").Value = batch_open_list1
            '            vchtmpset.update()

            '        Loop


        End Sub

        Sub update_paid_flag()
            'sqlstmnt = "select * from voucher where vouch_num = " & selected_voucher

            'db = ap_data_path & "ap.mdb"
            'voucherdb = DAODBEngine_definst.OpenDatabase(db)
            'voucherset = voucherdb.OpenRecordset("voucher")
            'voucherset = voucherdb.OpenRecordset(sqlstmnt)
            'voucherset.MoveFirst()
            'Do While Not voucherset.EOF
            '    voucherset.edit()
            '    voucherset.Fields("paid").Value = "Y"
            '    voucherset.update()
            '    voucherset.MoveNext()
            'Loop


        End Sub

    End Class
End Namespace