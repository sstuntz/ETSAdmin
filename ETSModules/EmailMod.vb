Option Explicit On
Option Strict On

Imports Microsoft.Office.Interop.Outlook


Namespace ETS.Common

    Public Class EMailMod

        Public Shared Sub SendEMail(ByVal ToPerson As String, ByVal From As String, ByVal Subject As String, ByVal Body As String, ByVal Attach As String)

            ' Create an Outlook application.
            Dim oApp As Microsoft.Office.Interop.Outlook.Application

            'Dim oApp As Outlook._Application
            oApp = New Microsoft.Office.Interop.Outlook.Application()

            ' Create a new MailItem.
            Dim oMsg As Microsoft.Office.Interop.Outlook.MailItem
            oMsg = CType(oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem), Microsoft.Office.Interop.Outlook.MailItem)
            oMsg.Subject = Subject
            '    oMsg.Body = Body
            oMsg.To = "mgeorge@jri.org"  'ToPerson
            ' Add an attachment
            Dim sSource As String = Attach
            'the attachment string includes the invoice number and we want to show that so
            'the dispaly name for the attachment is just the invoice id

            ' TODO: Replace with attachment name
            Dim sDisplayName As String = Subject

            '       Dim sBodyLen As String = CStr(oMsg.Body.Length)
            '      Dim oAttachs As Microsoft.Office.Interop.Outlook.Attachments = oMsg.Attachments
            '     Dim oAttach As Microsoft.Office.Interop.Outlook.Attachment
            '    oAttach = oAttachs.Add(sSource, , CDbl(sBodyLen) + 1, sDisplayName)

            ' Send
            oMsg.Send()

            ' Clean up
            oApp = Nothing
            oMsg = Nothing
            '   oAttach = Nothing
            '  oAttachs = Nothing

        End Sub
    End Class

End Namespace



