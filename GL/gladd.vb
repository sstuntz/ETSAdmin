Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient
Imports Valid_YN

Public Class frmgladd
    Inherits System.Windows.Forms.Form

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub copy_dpt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles copy_dpt.Click 'lhw 3/27/00 lhw
        MsgBox("Only do this when No One Else has ETS software Open!")
        Response = MsgBox("You are about to change the Chart of Accounts by Adding new records!  Select Yes to continue", MsgBoxStyle.YesNo)
        If Response = MsgBoxResult.Yes Then
            'first check to make sure not already done
            Dim NewAccts As List(Of AcctNums) = ETSSQL.GetAcctNum(txtfields(1).Text)  'get a  list of acct nums to copy
            If NewAccts.Count <> 0 Then
                MsgBox("These accounts have been set up.")
                Exit Sub
            End If
            NewAccts = Nothing
            'now make it the right one
            NewAccts = ETSSQL.GetAcctNum(txtfields(0).Text)  'get a  list of acct nums to copy
            If NewAccts.Count = 0 Then
                MsgBox("There are no accounts to copy.")
                Exit Sub
            End If
            'cycle thru list to write out new ones
            For Each NewAcct In NewAccts
                sqlstmnt = "insert into chacct  values ("
                sqlstmnt = sqlstmnt & "'" & NewAcct.AcctOnly & "' , '" & NewAcct.AcctPgm & "' , '" & txtfields(1).Text & "' , '" & NewAcct.AcctNum.Substring(0, NewAcct.AcctNum.Length - 2) & txtfields(1).Text & "' , '" & Replace(NewAcct.AcctDesc, "'", "''") & "' , '" & NewAcct.GlREfNo & "' , '" & NewAcct.CRDR & "' , '" & NewAcct.AcctTest & "' , '" & NewAcct.acct_1 & "' , '" & NewAcct.acct_2 & "' , '" & NewAcct.acct_3 & "' , "
                sqlstmnt = sqlstmnt & "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,'N',1)"
                ETSSQL.ExecuteSQL(sqlstmnt)
            Next
        Else
            MsgBox("Records not updated for this select!")
            txtfields(2).Focus()
            Exit Sub
        End If
        MsgBox("Records have been added to the Chart of Accounts.")

    End Sub

    Private Sub frmgladd_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ctrform(Me)
        txtfields(1).Text = ""
        txtfields(0).Text = ""
    End Sub

    Private Sub txtFields_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Enter
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        Call ets_set_selected()
    End Sub

    Private Sub txtfields_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtfields.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        If KeyAscii = 13 Or KeyAscii = 9 Then

            Select Case Index

                Case 0 'dept to select from
                    senddpt = txtfields(Index).Text
                    If ChkDptNum(senddpt) = "N" Then
                        MsgBox("Not a valid department number.")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                Case 1 'dept to copy to
                    'validate the dept
                    senddpt = txtfields(Index).Text
                    If ChkDptNum(senddpt) = "N" Then
                        MsgBox("Not a valid department number. Please create it before continuing")
                        Call ets_set_selected()
                        GoTo EventExitSub
                    End If
                Case 2
                    Select Case txtfields(Index).Text
                        Case "FRED"
                            txtfields(0).Focus()
                        Case Else
                            MsgBox("Enter the correct password(UPPER CASE) or Exit")
                    End Select
                    GoTo EventExitSub
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

    Private Sub txtfields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtfields.Leave
        Dim Index As Short = txtfields.GetIndex(CType(eventSender, TextBox))
        txtFields(Index).BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))

    End Sub
End Class