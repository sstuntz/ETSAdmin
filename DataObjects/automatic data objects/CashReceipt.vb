Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class CashReceiptData
	Private _BankKey as String
	Private _EncumDate as Date
	Private _NameKey as String
	Private _ScreenNam as String
	Private _SortName as String
	Private _ChkNum as String
	Private _ChkDate as Date
	Private _GrossAmt as Decimal
	Private _ChkDisc as Decimal
	Private _CheckAmt as Decimal
	Private _EntryNum as Integer
	Private _InvNum as Integer
	Private _LineNum as Integer
	Private _Invoice as String
	Private _TransCode as String
	Private _ChkAlloc as Decimal
	Private _DrAcctNu as String
	Private _CrAcctNu as String
	Private _Memo as String
	Private _Donor as String
	Private _EntryDate as Date
	Private _Checked as String
	Private _VoidChk as String
	Private _Glpost as String
	Private _Dflag as String
	Private _Agency as Integer
	Private _DiscAcct as String
	Private _JrnlNum as Integer
	Private _JrnlLine as Integer
	Private _Fund as String
	Private _BatchNum as Integer
	Private _BatchDesc as String
	Private _BatchDate as Date
	Private _BatchTotal as Decimal
	Private _SM as String

Public Property BankKey()  as String
	Get
		Return _BankKey
	End Get
	Set (ByVal value  as String )
		_BankKey = value
	End Set
End Property

Public Property EncumDate()  as Date
	Get
		Return _EncumDate
	End Get
	Set (ByVal value  as Date )
		_EncumDate = value
	End Set
End Property

Public Property NameKey()  as String
	Get
		Return _NameKey
	End Get
	Set (ByVal value  as String )
		_NameKey = value
	End Set
End Property

Public Property ScreenNam()  as String
	Get
		Return _ScreenNam
	End Get
	Set (ByVal value  as String )
		_ScreenNam = value
	End Set
End Property

Public Property SortName()  as String
	Get
		Return _SortName
	End Get
	Set (ByVal value  as String )
		_SortName = value
	End Set
End Property

Public Property ChkNum()  as String
	Get
		Return _ChkNum
	End Get
	Set (ByVal value  as String )
		_ChkNum = value
	End Set
End Property

Public Property ChkDate()  as Date
	Get
		Return _ChkDate
	End Get
	Set (ByVal value  as Date )
		_ChkDate = value
	End Set
End Property

Public Property GrossAmt()  as Decimal
	Get
		Return _GrossAmt
	End Get
	Set (ByVal value  as Decimal )
		_GrossAmt = value
	End Set
End Property

Public Property ChkDisc()  as Decimal
	Get
		Return _ChkDisc
	End Get
	Set (ByVal value  as Decimal )
		_ChkDisc = value
	End Set
End Property

Public Property CheckAmt()  as Decimal
	Get
		Return _CheckAmt
	End Get
	Set (ByVal value  as Decimal )
		_CheckAmt = value
	End Set
End Property

Public Property EntryNum()  as Integer
	Get
		Return _EntryNum
	End Get
	Set (ByVal value  as Integer )
		_EntryNum = value
	End Set
End Property

Public Property InvNum()  as Integer
	Get
		Return _InvNum
	End Get
	Set (ByVal value  as Integer )
		_InvNum = value
	End Set
End Property

Public Property LineNum()  as Integer
	Get
		Return _LineNum
	End Get
	Set (ByVal value  as Integer )
		_LineNum = value
	End Set
End Property

Public Property Invoice()  as String
	Get
		Return _Invoice
	End Get
	Set (ByVal value  as String )
		_Invoice = value
	End Set
End Property

Public Property TransCode()  as String
	Get
		Return _TransCode
	End Get
	Set (ByVal value  as String )
		_TransCode = value
	End Set
End Property

Public Property ChkAlloc()  as Decimal
	Get
		Return _ChkAlloc
	End Get
	Set (ByVal value  as Decimal )
		_ChkAlloc = value
	End Set
End Property

Public Property DrAcctNu()  as String
	Get
		Return _DrAcctNu
	End Get
	Set (ByVal value  as String )
		_DrAcctNu = value
	End Set
End Property

Public Property CrAcctNu()  as String
	Get
		Return _CrAcctNu
	End Get
	Set (ByVal value  as String )
		_CrAcctNu = value
	End Set
End Property

Public Property Memo()  as String
	Get
		Return _Memo
	End Get
	Set (ByVal value  as String )
		_Memo = value
	End Set
End Property

Public Property Donor()  as String
	Get
		Return _Donor
	End Get
	Set (ByVal value  as String )
		_Donor = value
	End Set
End Property

Public Property EntryDate()  as Date
	Get
		Return _EntryDate
	End Get
	Set (ByVal value  as Date )
		_EntryDate = value
	End Set
End Property

Public Property Checked()  as String
	Get
		Return _Checked
	End Get
	Set (ByVal value  as String )
		_Checked = value
	End Set
End Property

Public Property VoidChk()  as String
	Get
		Return _VoidChk
	End Get
	Set (ByVal value  as String )
		_VoidChk = value
	End Set
End Property

Public Property Glpost()  as String
	Get
		Return _Glpost
	End Get
	Set (ByVal value  as String )
		_Glpost = value
	End Set
End Property

Public Property Dflag()  as String
	Get
		Return _Dflag
	End Get
	Set (ByVal value  as String )
		_Dflag = value
	End Set
End Property

Public Property Agency()  as Integer
	Get
		Return _Agency
	End Get
	Set (ByVal value  as Integer )
		_Agency = value
	End Set
End Property

Public Property DiscAcct()  as String
	Get
		Return _DiscAcct
	End Get
	Set (ByVal value  as String )
		_DiscAcct = value
	End Set
End Property

Public Property JrnlNum()  as Integer
	Get
		Return _JrnlNum
	End Get
	Set (ByVal value  as Integer )
		_JrnlNum = value
	End Set
End Property

Public Property JrnlLine()  as Integer
	Get
		Return _JrnlLine
	End Get
	Set (ByVal value  as Integer )
		_JrnlLine = value
	End Set
End Property

Public Property Fund()  as String
	Get
		Return _Fund
	End Get
	Set (ByVal value  as String )
		_Fund = value
	End Set
End Property

Public Property BatchNum()  as Integer
	Get
		Return _BatchNum
	End Get
	Set (ByVal value  as Integer )
		_BatchNum = value
	End Set
End Property

Public Property BatchDesc()  as String
	Get
		Return _BatchDesc
	End Get
	Set (ByVal value  as String )
		_BatchDesc = value
	End Set
End Property

Public Property BatchDate()  as Date
	Get
		Return _BatchDate
	End Get
	Set (ByVal value  as Date )
		_BatchDate = value
	End Set
End Property

Public Property BatchTotal()  as Decimal
	Get
		Return _BatchTotal
	End Get
	Set (ByVal value  as Decimal )
		_BatchTotal = value
	End Set
End Property

Public Property SM()  as String
	Get
		Return _SM
	End Get
	Set (ByVal value  as String )
		_SM = value
	End Set
End Property


Public ReadOnly Property CashReceiptColumnNames() as string
		Get 
	              	              	              return "([BankKey] , [EncumDate] , [NameKey] , [ScreenNam] , [SortName] , [ChkNum] , [ChkDate] , [GrossAmt] , [ChkDisc] , [CheckAmt] , [EntryNum] , [InvNum] , [LineNum] , [Invoice] , [TransCode] , [ChkAlloc] , [DrAcctNu] , [CrAcctNu] , [Memo] , [Donor] , [EntryDate] , [Checked] , [VoidChk] , [Glpost] , [Dflag] , [Agency] , [DiscAcct] , [JrnlNum] , [JrnlLine] , [Fund] , [BatchNum] , [BatchDesc] , [BatchDate] , [BatchTotal] , [SM] )"
		End Get
End Property

Public ReadOnly Property CashReceiptColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} )"  _  
	 , (_BankKey) _ 
	 , (_EncumDate) _ 
	 , (_NameKey) _ 
	 , (_ScreenNam) _ 
	 , (_SortName) _ 
	 , (_ChkNum) _ 
	 , (_ChkDate) _ 
	 , (_GrossAmt) _ 
	 , (_ChkDisc) _ 
	 , (_CheckAmt) _ 
	 , (_EntryNum) _ 
	 , (_InvNum) _ 
	 , (_LineNum) _ 
	 , (_Invoice) _ 
	 , (_TransCode) _ 
	 , (_ChkAlloc) _ 
	 , (_DrAcctNu) _ 
	 , (_CrAcctNu) _ 
	 , (_Memo) _ 
	 , (_Donor) _ 
	 , (_EntryDate) _ 
	 , (_Checked) _ 
	 , (_VoidChk) _ 
	 , (_Glpost) _ 
	 , (_Dflag) _ 
	 , (_Agency) _ 
	 , (_DiscAcct) _ 
	 , (_JrnlNum) _ 
	 , (_JrnlLine) _ 
	 , (_Fund) _ 
	 , (_BatchNum) _ 
	 , (_BatchDesc) _ 
	 , (_BatchDate) _ 
	 , (_BatchTotal) _ 
	 , (_SM) _ 
)
		End Get
End Property
End Class
