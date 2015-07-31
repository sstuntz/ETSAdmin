Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports ETSCommon.MODULE1
Imports ETSCommon
Imports System.Configuration
Imports System.Data.SqlClient

Friend Class vac_acc
    Inherits System.Windows.Forms.Form

    '****************
    'revision History
    'original date of this form is 9/23/96 -SCS

    '****************

    Private Sub vac_acc_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        Using db As Database = New Database(ConfigurationManager.AppSettings("connectionString"))
            Dim sql As String = " select * from ccvac where acc_elig = 'Y' order by accrual_Cnt DESC;"
            Dim rs As SqlDataReader = db.ExecuteQuery(sql)
            rs.Read()
            msg = CStr(CInt(CDbl(rs("accrual_cnt").ToString) + 1))
            intcount = intcount + 1
            rs.Close()
        End Using
        num_acc.Text = msg
        'go thru the file and add an accrual to each max
    End Sub

    Private Sub reset_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles reset_Renamed.Click
        Response = MsgBox("Are you sure you want to reset all the accruals for a new year?", MsgBoxStyle.YesNo)
        If Response = 6 Then
            'probably done in a sql 
            'Do While Not ccvac.Recordset.EOF
            '    'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '    ccvac.Recordset.edit()
            '    'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '    ccvac.Recordset.Fields("accrual_cnt").Value = 0
            '    'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '    ccvac.Recordset.Fields("max_vac").Value = ccvac.Recordset.Fields("max_vac").Value - ccvac.Recordset.Fields("used_vac").Value
            '    'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '    ccvac.Recordset.Fields("used_vac").Value = 0
            '    'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '    ccvac.Recordset.Fields("max_hol").Value = ccvac.Recordset.Fields("max_hol").Value - ccvac.Recordset.Fields("used_hol").Value
            '    'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '    ccvac.Recordset.Fields("used_hol").Value = 0
            '    'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '    ccvac.Recordset.Fields("max_sick").Value = ccvac.Recordset.Fields("max_sick").Value - ccvac.Recordset.Fields("used_sick").Value
            '    'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '    ccvac.Recordset.Fields("used_sick").Value = 0
            '    'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '    ccvac.Recordset.Fields("max_pers").Value = ccvac.Recordset.Fields("max_pers").Value - ccvac.Recordset.Fields("used_pers").Value
            '    'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '    ccvac.Recordset.Fields("used_pers").Value = 0

            '    'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '    ccvac.Recordset.Update()
            '    'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
            '    ccvac.Recordset.MoveNext()
            'Loop
            Me.Close()
        End If

    End Sub

    Private Sub upd_vac_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles upd_vac.Click

        'Do While Not ccvac.Recordset.EOF
        '    'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    If ccvac.Recordset.Fields("acc_elig").Value = "Y" Then
        '        'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        ccvac.Recordset.edit()
        '        'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        ccvac.Recordset.Fields("accrual_cnt").Value = ccvac.Recordset.Fields("accrual_cnt").Value + 1
        '        'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        ccvac.Recordset.Fields("max_vac").Value = ccvac.Recordset.Fields("max_vac").Value + ccvac.Recordset.Fields("v_accrual").Value
        '        'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        ccvac.Recordset.Fields("max_hol").Value = ccvac.Recordset.Fields("max_hol").Value + ccvac.Recordset.Fields("h_accrual").Value
        '        'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        ccvac.Recordset.Fields("max_sick").Value = ccvac.Recordset.Fields("max_sick").Value + ccvac.Recordset.Fields("s_accrual").Value
        '        'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        ccvac.Recordset.Fields("max_pers").Value = ccvac.Recordset.Fields("max_pers").Value + ccvac.Recordset.Fields("p_accrual").Value

        '        'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '        ccvac.Recordset.Update()
        '    End If

        '    'UPGRADE_ISSUE: Data property ccvac.Recordset was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"'
        '    ccvac.Recordset.MoveNext()
        'Loop

        Me.Close()

    End Sub

    Private Sub cmdclose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Me.Close()
    End Sub
End Class