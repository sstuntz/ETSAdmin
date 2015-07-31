Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports ps.common

Public Class cctimeData
	Private _EntryDate as Date
	Private _PayNum as Integer
	Private _NameKey as String
	Private _ScreenNam as String
	Private _SortName as String
	Private _PayFreq as String
	Private _DedDfq as String
	Private _EntryNum as Integer
	Private _LineNum as Integer
    Private _ActDate As Date
	Private _JobNum as String
	Private _PayClass as String
	Private _Hours as Decimal
	Private _PcsProd as Decimal
	Private _DeptNum as String
	Private _PayDol as Decimal
	Private _ClPct as Decimal
	Private _ChkNum as Integer
	Private _Refusal as String
	Private _Paid as String
	Private _Checked as String
	Private _Dflag as String
	Private _Agency as String
	Private _Void as String
	Private _Glpost as String
	Private _EncumDate as Date
	Private _StateTax as String
	Private _JrnlNum as Integer
	Private _JrnlLine as Integer

Public Property EntryDate()  as Date
	Get
		Return _EntryDate
	End Get
	Set (ByVal value  as Date )
		_EntryDate = value
	End Set
End Property

Public Property PayNum()  as Integer
	Get
		Return _PayNum
	End Get
	Set (ByVal value  as Integer )
		_PayNum = value
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

Public Property PayFreq()  as String
	Get
		Return _PayFreq
	End Get
	Set (ByVal value  as String )
		_PayFreq = value
	End Set
End Property

Public Property DedDfq()  as String
	Get
		Return _DedDfq
	End Get
	Set (ByVal value  as String )
		_DedDfq = value
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

    Public Property LineNum() As Integer
        Get
            Return _LineNum
        End Get
        Set(ByVal value As Integer)
            _LineNum = value
        End Set
    End Property

    Public Property ActDate() As Date
        Get
            Return _ActDate
        End Get
        Set(ByVal value As Date)
            _ActDate = value
        End Set
    End Property

Public Property JobNum()  as String
	Get
		Return _JobNum
	End Get
	Set (ByVal value  as String )
		_JobNum = value
	End Set
End Property

Public Property PayClass()  as String
	Get
		Return _PayClass
	End Get
	Set (ByVal value  as String )
		_PayClass = value
	End Set
End Property

Public Property Hours()  as Decimal
	Get
		Return _Hours
	End Get
	Set (ByVal value  as Decimal )
		_Hours = value
	End Set
End Property

Public Property PcsProd()  as Decimal
	Get
		Return _PcsProd
	End Get
	Set (ByVal value  as Decimal )
		_PcsProd = value
	End Set
End Property

Public Property DeptNum()  as String
	Get
		Return _DeptNum
	End Get
	Set (ByVal value  as String )
		_DeptNum = value
	End Set
End Property

Public Property PayDol()  as Decimal
	Get
		Return _PayDol
	End Get
	Set (ByVal value  as Decimal )
		_PayDol = value
	End Set
End Property

Public Property ClPct()  as Decimal
	Get
		Return _ClPct
	End Get
	Set (ByVal value  as Decimal )
		_ClPct = value
	End Set
End Property

Public Property ChkNum()  as Integer
	Get
		Return _ChkNum
	End Get
	Set (ByVal value  as Integer )
		_ChkNum = value
	End Set
End Property

Public Property Refusal()  as String
	Get
		Return _Refusal
	End Get
	Set (ByVal value  as String )
		_Refusal = value
	End Set
End Property

Public Property Paid()  as String
	Get
		Return _Paid
	End Get
	Set (ByVal value  as String )
		_Paid = value
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

Public Property Dflag()  as String
	Get
		Return _Dflag
	End Get
	Set (ByVal value  as String )
		_Dflag = value
	End Set
End Property

Public Property Agency()  as String
	Get
		Return _Agency
	End Get
	Set (ByVal value  as String )
		_Agency = value
	End Set
End Property

Public Property Void()  as String
	Get
		Return _Void
	End Get
	Set (ByVal value  as String )
		_Void = value
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

Public Property EncumDate()  as Date
	Get
		Return _EncumDate
	End Get
	Set (ByVal value  as Date )
		_EncumDate = value
	End Set
End Property

Public Property StateTax()  as String
	Get
		Return _StateTax
	End Get
	Set (ByVal value  as String )
		_StateTax = value
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


Public ReadOnly Property cctimeColumnNames() as string
		Get 
	              	              	              return "([entry_date] , [pay_num] , [name_key] , [screen_nam] , [sort_name] , [pay_freq] , [ded_dfq] , [entry_num] , [line_num] , [date] , [job_num] , [pay_class] , [hours] , [pcs_prod] , [dept_num] , [pay_dol] , [cl_pct] , [chk_num] , [refusal] , [paid] , [checked] , [dflag] , [agency] , [void] , [glpost] , [encum_date] , [state_tax] , [jrnl_num] , [jrnl_line] )"
		End Get
End Property

Public ReadOnly Property cctimeColumnData() as string
		Get 
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} )" _
, Database.StringParam(_EntryDate.ToShortDateString) _
, (_PayNum.ToString) _
, Database.StringParam(_NameKey.ToString) _
, Database.StringParam(_ScreenNam.ToString) _
, Database.StringParam(_SortName.ToString) _
, Database.StringParam(_PayFreq.ToString) _
, Database.StringParam(_DedDfq.ToString) _
, (_EntryNum.ToString) _
, (_LineNum.ToString) _
, Database.StringParam(_ActDate.toshortdatestring) _
, Database.StringParam(_JobNum.ToString) _
, Database.StringParam(_PayClass.ToString) _
, (_Hours.ToString) _
, (_PcsProd.ToString) _
, Database.StringParam(_DeptNum.ToString) _
, (_PayDol.ToString) _
, (_ClPct.ToString) _
, (_ChkNum.ToString) _
, Database.StringParam(_Refusal.ToString) _
, Database.StringParam(_Paid.ToString) _
, Database.StringParam(_Checked.ToString) _
, Database.StringParam(_Dflag.ToString) _
, Database.StringParam(_Agency.ToString) _
, Database.StringParam(_Void.ToString) _
, Database.StringParam(_Glpost.ToString) _
, Database.StringParam(_EncumDate.ToShortDateString) _
, Database.StringParam(_StateTax.ToString) _
, (_JrnlNum.ToString) _
, (_JrnlLine.ToString) _
)
		End Get
End Property
End Class
