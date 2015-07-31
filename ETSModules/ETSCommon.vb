Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports ETS.Common.Module1
Imports ps.common

Public Class ETSCommon

    Public KnownYN As New Collection        'contains collection of data items already validated 
    Public BeginDate As Date
    Public EndDate As Date

    Public Sub StartCollections()
        Dim KnownYN As New Collection
    End Sub

    Public Shared Function CheckYN(ByVal YNTable As String, ByVal YNCol As String, ByVal YNData As String, ByVal YNValue As String) As String
        YNValue = "N"
        Dim YNKEY As String = String.Concat(YNTable, YNCol, YNData)
        ' If KnownYN.Contains(YNKEY) Then
        ' YNValue = KnownYN.Item(YNKEY).ToString
        'Else
        Dim validstr As String = ""
        Using db As Database = New Database(top_data_path)
            Dim sql As String = "Select Count ('" & YNCol & "') "
            sql = sql & " as validnum from " & YNTable & " where "
            sql = sql & YNCol & " = '" & YNData & "'"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            While rs.Read()
                validstr = rs("validnum").ToString
            End While
            rs.Close()
        End Using

        If Val(validstr) = 0 Then
            YNValue = "N"
        Else
            YNValue = "Y"
        End If
        ' KnownYN.Add(YNKEY, YNValue)
        ' End If
        Return YNValue


    End Function

    Public Shared Function CheckNumRecords(ByVal sqlstmnt As String) As Integer

        Dim NumRecs As Integer = 0

        Using db As Database = New Database(top_data_path)
            Dim rs As SqlDataReader = db.ExecuteQuery(sqlstmnt)
            While rs.Read()
                NumRecs = NumRecs + 1
            End While
            rs.Close()
        End Using
        Return NumRecs

    End Function

    Public Shared Function CheckOnceYN(ByVal YNTable As String, ByVal YNCol As String, ByVal YNData As String, ByVal YNValue As String) As String
        'YNValue = "N"
        Dim YNCount As Integer
        Using db As Database = New Database(top_data_path)
            Dim sql As String = "Select Count (" & YNCol & ") "
            sql = sql & " as validnum from " & YNTable & " where "
            sql = sql & YNCol & " = '" & YNData & " '"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            While rs.Read()
                YNCount = CInt(Val(rs("validnum").ToString))
            End While
            rs.Close()
        End Using

        Return YNCount.ToString

        If YNCount = 0 Then
            YNValue = "N"
        Else
            YNValue = "Y"
        End If
    End Function

    Public Shared Function GetBeginEndDates() As String
        Dim begindate As String = ""
        Dim enddate As String = ""

        Using db As Database = New Database(top_data_path)
            Dim sql As String = "Select Beg_Date, End_Date from rpthead "
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            While rs.Read()
                begindate = CStr(CDate(rs("beg_date")))
                enddate = CStr(CDate(rs("end_date")))
            End While
            rs.Close()
        End Using

        Return BeginDate & "*" & EndDate

    End Function

    'Public Shared Function GetComboBoxItems(ByVal frm As String, ByVal cntrl As String, ByVal pkg As String) As List(Of String)

    '    Dim ComboBoxItems As ComboBox.ObjectCollection

    '    Using db As Database = New Database(top_data_path)
    '        Dim sql As String = "Select datum, datum_desc from reference where form_name = '" & frm & "' and ctrl_name = '" & cntrl & "' and  package_type = '" & package_Type & "'"
    '        Dim rs As SqlDataReader = db.ExecuteQuery(sql)
    '        While rs.Read()
    '            ComboBoxItems.Add(CDate(rs("datum")) & "," & CDate(rs("datum_desc")))
    '        End While
    '        rs.Close()
    '    End Using

    'End Function

    Public Shared Function GetDatum(ByVal YNTable As String, ByVal YNWhereCol As String, ByVal YNKeyData As String, ByVal YNFromCol As String) As String

        Dim validstr As String = ""
        Using db As Database = New Database(top_data_path)
            Dim sql As String = "Select " & YNFromCol & " from " & YNTable & " where " & YNWhereCol & " = '" & YNKeyData & "'"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            While rs.Read()
                validstr = (rs(YNFromCol)).ToString
            End While
            rs.Close()
        End Using
        If validstr = "System.Data.SqlClient.SqlDataReader" Then
            validstr = ""
        End If
        Return validstr

    End Function

    Private Sub sqlcode()
        If (senddpt) = "" Then
            '     dptnumlookup.ShowDialog()
            senddpt = selected_dpt_num
            retdpt = selected_dpt_num
            retdptdesc = selected_dpt_desc
            valid_dpt = "Y"
        Else
            '    Dim sqlstmnt As String
            Using db As Database = New Database(top_data_path)
                Dim sql As String = sqlstmnt
                Dim rs As SqlDataReader = db.ExecuteQuery(sql)
                Dim intcount As Integer = 0

                While rs.Read()
                    retdptdesc = rs("dept_desc").ToString
                    retdpt = rs("dept").ToString
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
        'xxxxxxxxxxxxx

        Using db As Database = New Database(top_data_path)
            Dim sql As String = sqlstmnt

            sqlstmnt = " insert into cctime "
            sqlstmnt = sqlstmnt & "(entry_date,pay_num,name_key,screen_nam,entry_num,line_num,pay_Freq,ded_dfq,date,job_num,pay_class,hours,pcs_prod,dept_num,pay_dol,cl_pct,Sort_name,pay_Freq)"
            '        sqlstmnt = sqlstmnt & " values (" & System.DateTime & "','" & pr_num & "','" & Trim(ee_num.Text) & "','" & ee_Screen_nam.Text & "','" & ee_entry_num.Text & "','" & Val(ee_array(0, n)) + Val(CStr(last_line_num)) & "','" & ee_pay_dfq.Text & "','" & ee_ded_dfq.Text & "','" & ee_array(1, n) & "','" & ee_array(2, n) & "','" & ee_array(4, n) & "','" & ee_array(5, n) & "','" & Val(ee_array(6, n)) & "','" & ee_array(8, n) & "','" & ee_array(9, n) & "','" & ee_array(10, n) & "','" & ee_sort_name & "','" & PayFreq & ")"
            '         db.updateQuery(sql)
        End Using
    End Sub


    Public Shared Function ConnDivide(ByVal TopPath As String) As ConnectionData
        Dim Parts As String()
        Parts = Strings.Split(TopPath, ";")
        Dim ConnectionParts As New ConnectionData

        ConnectionParts.dbServer = Trim(Microsoft.VisualBasic.Strings.Right(Parts(0), Microsoft.VisualBasic.Strings.Len(Parts(0)) - InStr(Parts(0), "=")))
        ConnectionParts.dbName = Trim(Microsoft.VisualBasic.Strings.Right(Parts(1), Microsoft.VisualBasic.Strings.Len(Parts(1)) - InStr(Parts(1), "=")))
        ConnectionParts.dbUserID = Trim(Microsoft.VisualBasic.Strings.Right(Parts(2), Microsoft.VisualBasic.Strings.Len(Parts(2)) - InStr(Parts(2), "=")))
        ConnectionParts.dbPWD = Trim(Microsoft.VisualBasic.Strings.Right(Parts(3), Microsoft.VisualBasic.Strings.Len(Parts(3)) - InStr(Parts(3), "=")))

        If ConnectionParts.dbUserID = "true" Then 'trusted connection
            ConnectionParts.dbUserID = ""
            ConnectionParts.dbPWD = ""
        End If

        Return ConnectionParts
    End Function

End Class

