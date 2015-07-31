Option Strict On
Option Explicit On
Imports ETSCommon
Imports ETSCommon.MODULE1
Imports System.Configuration
Imports System.Data.SqlClient

Module pr_common
    'create when client payroll set up 1/1/98

    Public fed_adj As Decimal
    Public tax As Decimal
    Public st1_adj As Decimal
    Public st2_adj As Decimal
    Public annuallizer As Double
    Public saved_state_for_tax1 As String
    Public saved_state_for_tax2 As String
    Public saved_entry_num As Integer
    Public saved_Chk_num As Integer
    Public pct As Decimal = 0

    Public freq_code As String
    Public bank_dep_data(4, 3) As String
    Public state As String
    Public sched As String
    Public beg_chk_num As Integer
    Public last_Chk_num As Integer
    Public present_quarter_num As Integer
    Public present_quarter_date As Date
    Public end_quarter_date As Date

    Public selected_loookup_num As String
    Public selected_dpt_num_desc As String
    'Global selected_pay_num As String
    Public a As String
    Public b As String
    Public c As Decimal
    Public d As Decimal

    Public tots(50) As Decimal
    Public qtots(50) As Decimal
    Public db_path As String
    Public table_name As String
    Public field_name As String
    Public text_val As String
    Public temp_path As String
    Public tot_cks As Integer

    'Public nam_chkdb As dao.Database
    'Public nam_chkset As dao.Recordset
    'Public reconset As dao.Recordset

    Public quarter_begin_Date As Date
    Public quarter_end_Date As Date
    Public ee_Screen_nam As String
    Public ee_sort_name As String

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
            Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
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

    Sub check_dup_soc_sec_num(ByVal sendlookup As String, ByVal valid_lookup As String)
        'this checks for a duplicate ss number

        Select Case package_Type
            Case "EE"
                sqlstmnt = "select ss_num, screen_nam from nam_ee where ss_num = '" & sendlookup & "'"
            Case "CC"
                sqlstmnt = "select ss_num, screen_nam from nam_cc where ss_num = '" & sendlookup & "'"
        End Select

        Dim YNCount As Integer = 0
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                YNCount = YNCount + 1
            End While
            rs.Close()
        End Using

        '  Return YNCount.ToString

        If YNCount = 0 Then
            valid_lookup = "Y"
        Else
            valid_lookup = "N"
            '  MsgBox("This is a duplicate SS#. Already entered for " & tmpset.Fields("screen_nam").Value)
            'moved to calling form
        End If
    End Sub

    Sub etsdednum_chk(ByVal senddpt As String, ByVal retdpt As String, ByVal retdptdesc As String, ByVal valid_dpt As String)

        Select Case package_Type
            Case "EE"
                sqlstmnt = " select * from eededuct where dept = '" & senddpt & "'"
           Case "EEHR" 'added lhw 11/22/98
                sqlstmnt = " select * from eededuct where dept = '" & senddpt & "'"
            Case "CC"
                sqlstmnt = " select * from ccdeduct where dept = '" & senddpt & "'"
        End Select

        Dim YNCount As Integer = 0
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                YNCount = YNCount + 1
                retdpt = rs("ded_dol").ToString
                  retdptdesc = rs("plan_desc").ToString
            End While
            rs.Close()
        End Using

        '  Return YNCount.ToString

        If YNCount = 0 Then
            valid_dpt = "N"
        Else
            valid_dpt = "Y"
            End If
    End Sub

    Sub prchknumverify(ByVal chknumber As Integer)
        Select Case package_Type
            Case "EE"
                sqlstmnt = "select * from eeckstub where chk_num = " & chknumber
            Case "CC"
                sqlstmnt = "select * from ccckstub where chk_num = " & chknumber
        End Select
        Dim YNCount As Integer = 0
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
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
    End Sub

    Sub prchknumverify_recon(ByVal chknumber As Integer)
        Select Case package_Type
            Case "EE"
                sqlstmnt = "select * from eeckstub where chk_num = " & chknumber
            Case Else
                sqlstmnt = "select * from ccckstub where chk_num = " & chknumber
        End Select
        Dim YNCount As Integer = 0
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
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

    Sub state_Tax_calc(ByVal tax As Decimal, ByVal st1_adj As Decimal, ByVal state As String, ByVal sched As String, ByVal annuallizer As Decimal, ByVal b As String)
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
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
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
                Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
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
                Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
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
                Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
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

    Sub TDI_calc(ByVal st_tax As Decimal, ByVal st1_adj As Decimal, ByVal b As String)
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
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
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
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
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
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
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

End Module