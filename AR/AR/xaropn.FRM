VERSION 5.00
Begin VB.Form frmxaropn 
   Caption         =   " AR Reports selected on date range from Invoice"
   ClientHeight    =   6285
   ClientLeft      =   570
   ClientTop       =   630
   ClientWidth     =   8760
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   6285
   ScaleWidth      =   8760
   Begin VB.CommandButton Command4 
      Caption         =   "Monthly Invoice Register/Acct#"
      Height          =   375
      Left            =   2610
      TabIndex        =   11
      Top             =   4095
      Width           =   2880
   End
   Begin VB.CommandButton Command3 
      Caption         =   "Monthly Invoice Register/Date"
      Height          =   435
      Left            =   2610
      TabIndex        =   10
      Top             =   3480
      Width           =   2880
   End
   Begin VB.CommandButton Command2 
      Caption         =   "Monthly Invoice Register/Customer"
      Height          =   435
      Left            =   2610
      TabIndex        =   9
      Top             =   2925
      Width           =   2880
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Monthly Invoice Reg/Invoice#"
      Height          =   420
      Left            =   2610
      TabIndex        =   8
      Top             =   2280
      Width           =   2880
   End
   Begin VB.TextBox txtFields 
      Tag       =   "END_DATE"
      DataSource      =   "Data1"
      Height          =   285
      Index           =   1
      Left            =   5325
      TabIndex        =   4
      Top             =   1005
      Width           =   1290
   End
   Begin VB.TextBox txtFields 
      Tag       =   "BEG_DATE"
      DataSource      =   "Data1"
      Height          =   285
      Index           =   0
      Left            =   2310
      TabIndex        =   3
      Top             =   1005
      Width           =   1230
   End
   Begin VB.CommandButton cmdClose 
      Caption         =   "Cancel"
      Height          =   300
      Left            =   7710
      TabIndex        =   2
      TabStop         =   0   'False
      Top             =   15
      Width           =   975
   End
   Begin VB.CommandButton cmdUpdate 
      Caption         =   "Verify"
      Height          =   300
      Left            =   3675
      TabIndex        =   5
      Top             =   1575
      Width           =   975
   End
   Begin VB.CommandButton cmdRefresh 
      Caption         =   "Refresh"
      Height          =   300
      Left            =   570
      TabIndex        =   1
      TabStop         =   0   'False
      Top             =   5745
      Visible         =   0   'False
      Width           =   975
   End
   Begin VB.CommandButton cmdAdd 
      Caption         =   "Add"
      Height          =   300
      Left            =   1665
      TabIndex        =   0
      TabStop         =   0   'False
      Top             =   5775
      Visible         =   0   'False
      Width           =   975
   End
   Begin VB.Data Data1 
      Align           =   2  'Align Bottom
      Connect         =   "Access 2000;"
      DatabaseName    =   "C:\etsacct\database\ar.mdb"
      DefaultCursorType=   0  'DefaultCursor
      DefaultType     =   2  'UseODBC
      Exclusive       =   0   'False
      Height          =   345
      Left            =   0
      Options         =   0
      ReadOnly        =   0   'False
      RecordsetType   =   1  'Dynaset
      RecordSource    =   "ar_rpthead"
      Top             =   5940
      Visible         =   0   'False
      Width           =   8760
   End
   Begin VB.Label Label1 
      Caption         =   $"xaropn.frx":0000
      Height          =   480
      Left            =   1065
      TabIndex        =   12
      Top             =   180
      Width           =   6360
   End
   Begin VB.Label lblLabels 
      Caption         =   "END_DATE:"
      Height          =   255
      Index           =   1
      Left            =   4305
      TabIndex        =   7
      Top             =   1020
      Width           =   900
   End
   Begin VB.Label lblLabels 
      Caption         =   "BEG_DATE:"
      Height          =   255
      Index           =   0
      Left            =   1305
      TabIndex        =   6
      Top             =   1020
      Width           =   900
   End
End
Attribute VB_Name = "frmxaropn"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

 '****************
'revision History
'original date of this form is 06/25/1998 - SCS

'****************
'Option Explicit
Private Sub cmdRefresh_Click()
  'this is really only needed for multi user apps
  Data1.Refresh
End Sub

Private Sub cmdUpdate_Click()
  Data1.UpdateRecord
  Data1.Recordset.Bookmark = Data1.Recordset.LastModified
End Sub

Private Sub cmdClose_Click()
  Unload Me
End Sub

Private Sub Command1_Click()
  prtDestination = 0
  prtreportfilename = ar_report_path & "arinvreg.rpt"
Call frmcrystal_Call
End Sub

Private Sub Command2_Click()
  prtDestination = 0
  prtreportfilename = ar_report_path & "arincust.rpt"
Call frmcrystal_Call
End Sub

Private Sub Command3_Click()
  prtDestination = 0
  prtreportfilename = ar_report_path & "arinvd.rpt"
Call frmcrystal_Call
End Sub

Private Sub Command4_Click()
  prtDestination = 0
  prtreportfilename = ar_report_path & "arindist.rpt"
Call frmcrystal_Call
End Sub

Private Sub Data1_Error(DataErr As Integer, Response As Integer)
  'This is where you would put error handling code
  'If you want to ignore errors, comment out the next line
  'If you want to trap them, add code here to handle them
  MsgBox "Data error event hit err:" & Error$(DataErr)
  Response = 0  'throw away the error
End Sub

Private Sub Data1_Reposition()
  Screen.MousePointer = vbDefault
  On Error Resume Next
  'This will display the current record position
  'for dynasets and snapshots
  Data1.Caption = "Record: " & (Data1.Recordset.AbsolutePosition + 1)
  'for the table object you must set the index property when
  'the recordset gets created and use the following line
  'Data1.Caption = "Record: " & (Data1.Recordset.RecordCount * (Data1.Recordset.PercentPosition * 0.01)) + 1
End Sub

Private Sub Data1_Validate(Action As Integer, save As Integer)
  'This is where you put validation code
  'This event gets called when the following actions occur
  Select Case Action
    Case vbDataActionMoveFirst
    Case vbDataActionMovePrevious
    Case vbDataActionMoveNext
    Case vbDataActionMoveLast
    Case vbDataActionAddNew
    Case vbDataActionUpdate
    Case vbDataActionDelete
    Case vbDataActionFind
    Case vbDataActionBookmark
    Case vbDataActionClose
    Case vbDataActionUnload
    For num = 0 To Screen.ActiveForm.Controls.Count - 1

   If TypeOf Screen.ActiveForm.Controls(num) Is TextBox Or TypeOf Screen.ActiveForm.Controls(num) Is MaskEdBox Then
   Screen.ActiveForm.Controls(num).DataChanged = False
   End If

    Next
  End Select
  'Screen.MousePointer = vbHourglass
End Sub

Private Sub form_load()
   'Msgbox ("fix the path name and erase this box")
   For num = 0 To Me.Controls.Count - 1
   If TypeOf Me.Controls(num) Is Data Then
      sqlstmnt = Right(Me.Controls(num).DatabaseName, Len(Me.Controls(num).DatabaseName) - 20)
      Me.Controls(num).DatabaseName = ar_data_path & sqlstmnt
      If Len(Me.Controls(num).RecordSource) > 0 Then
         Me.Controls(num).Refresh
      End If
   End If
   Next

End Sub

Private Sub txtFields_GotFocus(Index As Integer)
Call ets_set_selected
End Sub

  Private Sub txtFields_KeyPress(Index As Integer, KeyAscii As Integer)
  If KeyAscii = 13 Or KeyAscii = 9 Then
  
  Select Case Index
    
   Case 0, 1

    valid_Date = "N"
    senddate = txtfields(Index).Text
    Call etsdate(senddate, retdate, valid_Date)

    If valid_Date <> "N" Then
      txtfields(Index).Text = retdate
      txtfields(Index).Text = CVDate(txtfields(Index).Text)
        'the line below shows how to add days to a date and give a new date
      'duedate = DateAdd(, 30, txtfields(index))
    
         SendKeys "{tab}"
         'KeyAscii = 0
   
       Else
          MsgBox (" Bad Date")
          Call ets_set_selected
          Exit Sub
    End If
 
   End Select
   
End If
   
  End Sub

  Private Sub txtFields_LostFocus(Index As Integer)
    txtfields(Index).BackColor = RGB(255, 255, 255)
   End Sub

