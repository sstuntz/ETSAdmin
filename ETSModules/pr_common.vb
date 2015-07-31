Option Strict On
Option Explicit On
Imports PS.Common
Imports ETS.Common.Module1
Imports System.Configuration
Imports System.Data.SqlClient

Namespace ETS

    Public Class pr_common
        'create when client payroll set up 1/1/98

        Public Shared fed_adj As Decimal
        Public Shared tax As Decimal
        Public Shared st1_adj As Decimal
        Public Shared st2_adj As Decimal
        Public Shared annuallizer As Double
        Public Shared saved_state_for_tax1 As String
        Public Shared saved_state_for_tax2 As String
        Public Shared saved_entry_num As Integer
        Public Shared saved_Chk_num As Integer
        Public Shared pct As Decimal = 0

        Public Shared freq_code As String
        Public Shared bank_dep_data(4, 3) As String
        Public Shared state As String
        Public Shared sched As String
        Public Shared beg_chk_num As Integer
        Public Shared last_Chk_num As Integer
        Public Shared present_quarter_num As Integer
        Public Shared present_quarter_date As Date
        Public Shared end_quarter_date As Date

        Public Shared selected_loookup_num As String
        Public Shared selected_dpt_num_desc As String
        Public Shared selected_entry_num As Long
        Public Shared selected_pay_num As String
        Public Shared a As String
        Public Shared b As String
        Public Shared c As Decimal
        Public Shared d As Decimal

        Public Shared tots(50) As Decimal
        Public Shared qtots(50) As Decimal
        Public Shared db_path As String
        Public Shared table_name As String
        Public Shared field_name As String
        Public Shared text_val As String
        Public Shared temp_path As String
        Public Shared tot_cks As Integer

        Public Shared quarter_begin_Date As Date
        Public Shared quarter_end_Date As Date
        Public Shared ee_Screen_nam As String
        Public Shared ee_sort_name As String


        Public Sub aeic_Calc(ByVal a As String, ByVal b As String, ByVal c As Decimal, ByVal d As Decimal)
            'a is if the person in aeic_Elig 2 means both filing ie married
            'b is the pay period
            'c is the federal gross
            'd is the aeic amount

            If a <> "N" Then
                If a = "2" Then
                    a = "M"
                Else
                    a = "S"
                End If

                sqlstmnt = "select * from aeic_rates where pay_freg = '" & b & "' and status = '" & a & "'"
                Dim intcount As Integer = 0
                Using db As Database = New Database(top_data_path)
                    Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
                    While rs.Read()
                        Select Case c
                            Case Is < CDec(rs("not_over").ToString)
                                d = c * CDec(rs("per_wage").ToString)
                            Case Is > CDec(rs("max").ToString)
                                d = (CDec(rs("amount").ToString) - (c - CDec(rs("max").ToString)) * CDec(rs("red_per").ToString))
                            Case Else
                                d = CDec(rs("amount").ToString)
                        End Select
                        If d < 0 Then d = 0
                        intcount = intcount + 1
                    End While
                    rs.Close()
                End Using

                If intcount = 0 Then
                    MsgBox("Invalid data in aeic tax tables. Please correct and reprocess.")
                End If
            End If
        End Sub

        Public Shared Function check_dup_soc_sec_num(ByVal sendlookup As String, ByVal valid_lookup As String) As String
            'this checks for a duplicate ss number and makes sure it is not the one you are entering
            valid_lookup = "N"
            Select Case package_Type
                Case "EE"
                    sqlstmnt = "select ss_num, screen_nam from nam_ee where ss_num = '" & sendlookup & "' and name_key <> '" & selected_name_key & "'"
                Case "CC"
                    sqlstmnt = "select ss_num, screen_nam from nam_cc where ss_num = '" & sendlookup & "' and name_key <> '" & selected_name_key & "'"
            End Select

            Dim YNCount As Integer = 0
            Using db As Database = New Database(top_data_path)
                Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
                While rs.Read()
                    YNCount = YNCount + 1
                End While
                rs.Close()
            End Using
            If YNCount = 0 Then
                valid_lookup = "Y"
            Else
                valid_lookup = "N"
            End If
            Return valid_lookup

        End Function

        Public Shared Function etsdednum_chk(ByVal senddpt As String, ByVal retdpt As String, ByVal retdptdesc As String, ByVal valid_dpt As String) As String

            Select Case package_Type
                Case "EE"
                    sqlstmnt = " select * from eededuct where ded_num = '" & senddpt & "'"
                Case "EEHR" 'added lhw 11/22/98
                    sqlstmnt = " select * from eededuct where ded_num = '" & senddpt & "'"
                Case "CC"
                    sqlstmnt = " select * from cc_deduct where ded_num = '" & senddpt & "'"
            End Select

            Dim YNCount As Integer
            YNCount = 0
            Using db As Database = New Database(top_data_path)
                Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
                While rs.Read()
                    YNCount = YNCount + 1
                        retdpt = rs("ded_dol").ToString
                    selected_lookup_desc = rs("plan_desc").ToString
                End While
                    rs.Close()
            End Using

            If YNCount = 0 Then
                valid_dpt = "N"
            Else
                valid_dpt = "Y"
            End If

            Return valid_dpt

        End Function

        Public Shared Function prchknumverify(ByVal chknumber As Integer) As String
            Select Case package_Type
                Case "EE"
                    sqlstmnt = "select * from eeckstub where chk_num = " & chknumber
                Case "CC"
                    sqlstmnt = "select * from ccckstub where chk_num = " & chknumber
            End Select
            Dim YNCount As Integer = 0
            Using db As Database = New Database(top_data_path)
                Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
                While rs.Read()
                    YNCount = YNCount + 1
                End While
                rs.Close()
            End Using

            '  Return YNCount.ToString

            If YNCount = 0 Then
                valid_check = "Y"
            Else
                valid_check = "N"
            End If

            Return valid_check
        End Function

        Public Shared Sub prchknumverify_recon(ByVal chknumber As Integer)
            Select Case package_Type
                Case "EE"
                    sqlstmnt = "select * from eeckstub where chk_num = " & chknumber
                Case Else
                    sqlstmnt = "select * from ccckstub where chk_num = " & chknumber
            End Select
            Dim YNCount As Integer = 0
            Using db As Database = New Database(top_data_path)
                Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
                While rs.Read()
                    YNCount = YNCount + 1
                End While
                rs.Close()
            End Using

            '  Return YNCount.ToString

            If YNCount = 0 Then
                valid_check = "N"
            Else
                valid_check = "Y"
            End If

        End Sub

        Public Shared Sub state_Tax_calc(ByVal tax As Decimal, ByVal st1_adj As Decimal, ByVal state As String, ByVal sched As String, ByVal annuallizer As Decimal, ByVal b As String)
            'b is the name key of the person
            Select Case package_Type
                Case "EE"
                    sqlstmnt = "select * from eeytd "
                Case "CC"
                    sqlstmnt = "select * from ccytd "
            End Select
            'we need to calculate the fed tax as if this states wages were the only wages
            'using as the basis for these states taxes

            Dim pct As Decimal = 0
            sqlstmnt = " select * from tax_rates where state = '" & state & "'"
            Using db As Database = New Database(top_data_path)
                Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
                While rs.Read()
                    If state = rs("State").ToString Then
                        pct = CDec(rs("tax_pct").ToString)
                    End If
                End While
                rs.Close()
            End Using

            Dim fica_limit As Decimal
            Select Case state

                Case "MA"

                    fica_limit = 0
                    'put in test for the fica removal limit of 2000
                    'the state gross less deductions and exemptions is st1_Adj
                    'we now look up in the ytd table the fica and med and subtract that amount up to 2000
                    'we can add the fica and med amount from this check and subtract that also

                    sqlstmnt = sqlstmnt & " where name_key = '" & b & "'"
                    fica_limit = fica_limit
                    Using db As Database = New Database(top_data_path)
                        Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
                        While rs.Read()
                            fica_limit = CDec(rs("ytd_fica_Tax").ToString + rs("ytd_med_tax").ToString)
                        End While
                        rs.Close()
                    End Using

                    'now do it again for this check
                    Select Case package_Type
                        Case "EE"
                            sqlstmnt = "select * from eecktmp  where name_key = '" & b & "'"
                        Case "CC"
                            sqlstmnt = "select * from cccktmp where name_key = '" & b & "'"
                    End Select

                    fica_limit = fica_limit
                    Using db As Database = New Database(top_data_path)
                        Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
                        While rs.Read()
                            fica_limit = fica_limit + CDec(rs("fica_Tax").ToString + rs("med_tax").ToString)
                        End While
                        rs.Close()
                    End Using

                    If fica_limit > 2000 Then fica_limit = 2000

                    'annualize the state gross for this state and then follow the tax tables
                    pct = 0
                    sqlstmnt = " select * from tax_rates where state = '" & state & "'"
                    Using db As Database = New Database(top_data_path)
                        Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
                        While rs.Read()
                            If state = rs("State").ToString Then
                                If st1_adj >= CDbl(rs("min_amt").ToString) And st1_adj < CDbl(rs("max_amt").ToString) Then
                                    tax = (CDec(rs("tax_amt").ToString) + (st1_adj - CDec(rs("min_amt").ToString) - fica_limit) * CDec(rs("tax_pct").ToString)) / annuallizer
                                    Exit While
                                End If
                                If CDec(rs("max_amt").ToString) = 0 Then
                                    tax = (CDec(rs("tax_amt").ToString) + (st1_adj - CDec(rs("min_amt").ToString) - fica_limit * annuallizer) * CDec(rs("tax_pct").ToString)) / annuallizer
                                End If
                            End If
                        End While
                        rs.Close()
                    End Using

                Case Else
                    ' all other states should be
                    'only ri but careful since fwt exmpt should be the state ones
                    'and the exmpt amt in the taxtbl should be the federal amt so calc works the same
                    'last two lines 1/5/2000 scs & lhw

                    '     Call fed_tax_calc(tax, sched, st1_adj, annuallizer)
                    tax = tax * pct
            End Select
            If tax < 0 Then tax = 0

        End Sub

        Public Shared Sub TDI_calc(ByVal st_tax As Decimal, ByVal st1_adj As Decimal, ByVal b As String)
            'b is the name key of the person
            'pay tdi tax only those on 07 an 08 it is a string field

            Dim tdi_max As Decimal
            Dim tdi_limit As Decimal
            '  tmpset = tmpdb.OpenRecordset("taxtbl", dao.RecordsetTypeEnum.dbOpenDynaset)
            ' tmp1set = tmp1db.OpenRecordset("eeytd", dao.RecordsetTypeEnum.dbOpenDynaset)
            'tmp2set = tmp1db.OpenRecordset("nam_ee", dao.RecordsetTypeEnum.dbOpenDynaset)

            Select Case package_Type
                Case "EE"
                    sqlstmnt = " select * from nam_ee where name_key = '" & b & "'"
                Case "CC"
                    sqlstmnt = " select * from nam_cc where name_key = '" & b & "'"
            End Select

            Dim YNCount As Integer = 0
            Using db As Database = New Database(top_data_path)
                Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
                While rs.Read()
                    Select Case rs("dept_num").ToString
                        Case "07"
                        Case "08"
                        Case Else
                            tax = 0
                            Exit Sub
                    End Select
                End While
                rs.Close()
            End Using

            sqlstmnt = "select * from taxtbl where state = ""RI"" "
            Using db As Database = New Database(top_data_path)
                Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
                While rs.Read()
                    pct = CDec(rs("med_pct").ToString)
                    tdi_max = CDec(rs("med_max").ToString)
                End While
                rs.Close()
            End Using

            'check year to date gross and charge tax up to the max
            Select Case package_Type
                Case "EE"
                    sqlstmnt = " select * from eeytd where name_key = '" & b & "'"
                Case "CC"
                    sqlstmnt = " select * from ccytd where name_key = '" & b & "'"
            End Select

            YNCount = 0
            Using db As Database = New Database(top_data_path)
                Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
                While rs.Read()
                    tdi_limit = tdi_max - CDec(rs("ytd_full_gross").ToString)
                    YNCount = YNCount + 1
                End While
                rs.Close()
            End Using
            If YNCount = 0 Then
                tdi_limit = tdi_max
            End If

            'now do calculate the tax

            If (tdi_limit - st1_adj) > 0 Then
                tax = CDec(st1_adj * pct)
            Else
                If tdi_limit < 0 Then
                    tax = 0
                Else
                    tax = CDec(pct * (st1_adj - tdi_limit))
                End If

            End If

            'truncate to pennies
            tax = Int(tax * 100) / 100

            If tax < 0 Then tax = 0

        End Sub

        Public Shared Sub Upd_vac_table()

        End Sub

    End Class

End Namespace