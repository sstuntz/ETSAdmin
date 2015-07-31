Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System
Imports System.Configuration
Imports System.IO
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient

Public Class create_bill_log
    Inherits System.Windows.Forms.Form

    Public start_fund_Date As Date
    Public end_fund_Date As Date
    Public InvoiceLocation As String = ConfigurationManager.AppSettings("InvoiceLocation")
    Public DefaultInvoicePrinter As String = ConfigurationManager.AppSettings("DefaultInvoicePrinter")

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdClose.Click
        Me.Dispose()
    End Sub

    Private Sub create_bill_log_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim HeaderDates As String() = ETSCommon.GetBeginEndDates.Split(CChar("*"))
        start_date.Text = HeaderDates(0)
        End_Date.Text = HeaderDates(1)

    End Sub

    Private Sub pr_end_Date1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Date.Enter
        Call ets_set_selected()
    End Sub

    Private Sub pr_end_Date1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles End_Date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Or KeyAscii = 9 Then
            senddate = End_Date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")

            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                End_Date.Text = CDate(retdate).ToShortDateString
                pr_end_date = CDate(retdate)
                selected_end_date = CDate(retdate)
            End If

            If DateDiff(DateInterval.Day, CDate(start_date.Text), CDate(End_Date.Text)) < 0 Then
                MsgBox("Invalid date range")
                Call ets_set_selected()
                GoTo EventExitSub
            End If

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0

        End If

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If

    End Sub

    Private Sub pr_end_Date1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles End_Date.Leave
        End_Date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub pr_Start_date1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date.Enter
        Call ets_set_selected()
    End Sub

    Private Sub pr_Start_date1_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles start_date.KeyPress
        Dim KeyAscii As Short = CShort(Asc(eventArgs.KeyChar))
        If KeyAscii = 13 Then
            senddate = start_date.Text
            Dim retdate As String = ETS.Common.Module1.etsdate(senddate, "N")
            If retdate = "N" Then
                senddate = ""
                MsgBox(" Bad Date")
                Call ets_set_selected()
                GoTo EventExitSub
            Else
                pr_Start_date = CDate(retdate)
                selected_start_date = CDate(retdate)
                start_date.Text = CDate(retdate).ToShortDateString

            End If

            System.Windows.Forms.SendKeys.Send("{tab}")
            KeyAscii = 0

        End If


EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If

    End Sub

    Private Sub pr_Start_date1_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles start_date.Leave
        start_date.BackColor = System.Drawing.ColorTranslator.FromOle(RGB(255, 255, 255))
    End Sub

    Private Sub Process_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Process.Click

        If Len(start_date.Text) = 0 Then
            MsgBox("You need to enter a start date.")
            start_date.Focus()
            Exit Sub
        End If

        If Len(End_Date.Text) = 0 Then
            MsgBox("You need to enter an end date.")
            End_Date.Focus()
            Exit Sub
        End If

        'check if start and end date are in same month
        If Month(CDate(start_date.Text)) <> Month(CDate(End_Date.Text)) Then
            MsgBox("Start and End date are not in the same month.  Please correct.")
            Exit Sub
        End If
        'create folder string
        'Dim FolderString As String = String.Format("{0:MMyy}", CDate(start_date.Text))

        ''check if file folder set up for invoice
        'Dim InvoiceFolder As String = InvoiceLocation & FolderString
        'Try
        '    ' Determine whether the directory exists. 
        '    If Directory.Exists(InvoiceFolder) Then
        '    End If
        '    ' Try to create the directory. 
        '    InvoicePath = Directory.CreateDirectory(InvoiceFolder).ToString
        'Catch e As Exception
        '    MsgBox("The process to create an invoice directory failed: {0}.", CType(e.ToString(), MsgBoxStyle))
        'End Try

        sqlstmnt = "Select * from bill_cntrl where serv_beg = '" & start_date.Text & "'"

        Dim BillLog As New List(Of BillControlData)
        BillLog = ETSSQL.GetBillControlData(sqlstmnt)
        Dim NewLog As New List(Of BillControlData)

        If BillLog.Count = 0 Then
            Dim ActiveContracts As New List(Of ContractData)
            sqlstmnt = "select * from cc_cont where active = 'Y' "
            ActiveContracts = ETSSQL.GetContractData(sqlstmnt)
            For Each ActCont In ActiveContracts
                selected_contract_key = ActCont.ContractKey
                CheckInvoiceFolder(End_Date.Text, selected_contract_key)
                Dim ds As New BillControlData
                ds.ContractKey = ActCont.ContractKey
                ds.ServBeg = CDate(start_date.Text)
                ds.ServEnd = CDate(End_Date.Text)
                ds.AmtBilled = 0
                ds.BillDate = Today
                ds.Comment = ""
                ds.InvNum = 0
                ds.Invoice = ""
                ds.DeliveryMethod = ActCont.Code3
                If String.IsNullOrEmpty(ds.DeliveryMethod) Then
                    ds.DeliveryMethod = "E"
                End If
                ds.EmailAddress = ETSCommon.GetDatum("nam_addr", "name_key", ActCont.NameKey, "email")
                If Len(ds.EmailAddress) = 0 Then ds.EmailAddress = DefaultInvoicePrinter
                ds.Sent = "N"
                ds.SentDate = CDate("1/1/1901")
                ds.AcctNum = ActCont.CrAcctNu
                ds.PrinterName = "10"
                NewLog.Add(ds)
            Next

        Else
            MsgBox("Records already created for this period. Checking to add new contracts.")
            Dim ActiveContracts As New List(Of ContractData)
            sqlstmnt = "select * from cc_cont where active = 'Y' order by contract_key"
            ActiveContracts = ETSSQL.GetContractData(sqlstmnt)
            For Each ActCont In ActiveContracts
                sqlstmnt = "select * from bill_cntrl where contract_key = '" & ActCont.ContractKey.ToString & "' and serv_beg = '" & start_date.Text & "'"
               If ETSCommon.CheckNumRecords(sqlstmnt) = 0 Then
                    CheckInvoiceFolder(End_Date.Text, selected_contract_key)
                    Dim ds As New BillControlData
                    ds.ContractKey = ActCont.ContractKey
                    ds.ServBeg = CDate(start_date.Text)
                    ds.ServEnd = CDate(End_Date.Text)
                    ds.AmtBilled = 0
                    ds.BillDate = Today
                    ds.Comment = ""
                    ds.InvNum = 0
                    ds.Invoice = ""
                    ds.DeliveryMethod = ActCont.Code3
                    If String.IsNullOrEmpty(ds.DeliveryMethod) Then
                        ds.DeliveryMethod = "E"
                    End If
                    ds.EmailAddress = ETSCommon.GetDatum("nam_addr", "name_key", ActCont.NameKey, "email")
                    If Len(ds.EmailAddress) = 0 Then ds.EmailAddress = DefaultInvoicePrinter
                    ds.Sent = "N"
                    ds.SentDate = CDate("1/1/1901")
                    ds.AcctNum = ActCont.CrAcctNu
                    ds.PrinterName = "10"
                    NewLog.Add(ds)
                End If
            Next

        End If


        For Each NewOne In NewLog
            sqlstmnt = "insert into bill_cntrl " & NewOne.BillControlColumnNames & "  values " & NewOne.BillControlColumnData
            ETSSQL.ExecuteSQL(sqlstmnt)

        Next
        'put dates in rpthead
        sqlstmnt = "update rpthead set beg_date = '" & start_date.Text & "', end_date = ' " & End_Date.Text & "'"
        ETSSQL.ExecuteSQL(sqlstmnt)

        MsgBox("Records created")
        Me.Dispose()

    End Sub
End Class