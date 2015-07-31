Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports PS.Common

Public Class NameCCData
    Private _NameKey As String
    Private _ScreenNam As String
    Private _SortName As String
    Private _Desc1 As String
    Private _Desc2 As String
    Private _Desc3 As String
    Private _DeptNum As String
    Private _FundCode As String
    Private _DisabNum As String
    Private _DisabDesc As String
    Private _SsNum As String
    Private _HireDate As Date
    Private _TermDate As Date
    Private _AnnivMo As String
    Private _Dob As Date
    Private _AvgHrly As Decimal
    Private _Makeup As String
    Private _EPhone As String
    Private _EName As String
    Private _WcNum As String
    Private _WcRate As Decimal
    Private _FicaExmt As String
    Private _MedExmt As String
    Private _FileStatus As String
    Private _PayFreq As String
    Private _Printck As String
    Private _FwtExmts As Integer
    Private _SwtExmts As Integer
    Private _State1Tax As String
    Private _State2Tax As String
    Private _AddFwt As Decimal
    Private _AddfwtDfq As String
    Private _AddSwt As Decimal
    Private _AddswtDfq As String
    Private _AddFica As Decimal
    Private _AddficaDfq As String
    Private _AddMed As Decimal
    Private _AddmedDfq As String
    Private _DdepDfq As String
    Private _DdepNet As String
    Private _Dduct1Num As String
    Private _Dduct1Dol As Decimal
    Private _Dduct1Dfq As String
    Private _Dduct2Num As String
    Private _Dduct2Dol As Decimal
    Private _Dduct2Dfq As String
    Private _Dduct3Num As String
    Private _Dduct3Dol As Decimal
    Private _Dduct3Dfq As String
    Private _Dduct4Num As String
    Private _Dduct4Dol As Decimal
    Private _Dduct4Dfq As String
    Private _Agency As Integer
    Private _Dflag As String
    Private _Text1 As String
    Private _Text2 As String
    Private _Coach As String


    Public Property NameKey() As String
        Get
            Return _NameKey
        End Get
        Set(ByVal value As String)
            _NameKey = value
        End Set
    End Property

    Public Property ScreenNam() As String
        Get
            Return _ScreenNam
        End Get
        Set(ByVal value As String)
            _ScreenNam = value
        End Set
    End Property

    Public Property SortName() As String
        Get
            Return _SortName
        End Get
        Set(ByVal value As String)
            _SortName = value
        End Set
    End Property

    Public Property Desc1() As String
        Get
            Return _Desc1
        End Get
        Set(ByVal value As String)
            _Desc1 = value
        End Set
    End Property

    Public Property Desc2() As String
        Get
            Return _Desc2
        End Get
        Set(ByVal value As String)
            _Desc2 = value
        End Set
    End Property

    Public Property Desc3() As String
        Get
            Return _Desc3
        End Get
        Set(ByVal value As String)
            _Desc3 = value
        End Set
    End Property

    Public Property DeptNum() As String
        Get
            Return _DeptNum
        End Get
        Set(ByVal value As String)
            _DeptNum = value
        End Set
    End Property

    Public Property FundCode() As String
        Get
            Return _FundCode
        End Get
        Set(ByVal value As String)
            _FundCode = value
        End Set
    End Property

    Public Property DisabNum() As String
        Get
            Return _DisabNum
        End Get
        Set(ByVal value As String)
            _DisabNum = value
        End Set
    End Property

    Public Property DisabDesc() As String
        Get
            Return _DisabDesc
        End Get
        Set(ByVal value As String)
            _DisabDesc = value
        End Set
    End Property

    Public Property SsNum() As String
        Get
            Return _SsNum
        End Get
        Set(ByVal value As String)
            _SsNum = value
        End Set
    End Property

    Public Property HireDate() As Date
        Get
            Return _HireDate
        End Get
        Set(ByVal value As Date)
            _HireDate = value
        End Set
    End Property

    Public Property TermDate() As Date
        Get
            Return _TermDate
        End Get
        Set(ByVal value As Date)
            _TermDate = value
        End Set
    End Property

    Public Property AnnivMo() As String
        Get
            Return _AnnivMo
        End Get
        Set(ByVal value As String)
            _AnnivMo = value
        End Set
    End Property

    Public Property Dob() As Date
        Get
            Return _Dob
        End Get
        Set(ByVal value As Date)
            _Dob = value
        End Set
    End Property

    Public Property AvgHrly() As Decimal
        Get
            Return _AvgHrly
        End Get
        Set(ByVal value As Decimal)
            _AvgHrly = value
        End Set
    End Property

    Public Property Makeup() As String
        Get
            Return _Makeup
        End Get
        Set(ByVal value As String)
            _Makeup = value
        End Set
    End Property

    Public Property EPhone() As String
        Get
            Return _EPhone
        End Get
        Set(ByVal value As String)
            _EPhone = value
        End Set
    End Property

    Public Property EName() As String
        Get
            Return _EName
        End Get
        Set(ByVal value As String)
            _EName = value
        End Set
    End Property

    Public Property WcNum() As String
        Get
            Return _WcNum
        End Get
        Set(ByVal value As String)
            _WcNum = value
        End Set
    End Property

    Public Property WcRate() As Decimal
        Get
            Return _WcRate
        End Get
        Set(ByVal value As Decimal)
            _WcRate = value
        End Set
    End Property

    Public Property FicaExmt() As String
        Get
            Return _FicaExmt
        End Get
        Set(ByVal value As String)
            _FicaExmt = value
        End Set
    End Property

    Public Property MedExmt() As String
        Get
            Return _MedExmt
        End Get
        Set(ByVal value As String)
            _MedExmt = value
        End Set
    End Property

    Public Property FileStatus() As String
        Get
            Return _FileStatus
        End Get
        Set(ByVal value As String)
            _FileStatus = value
        End Set
    End Property

    Public Property PayFreq() As String
        Get
            Return _PayFreq
        End Get
        Set(ByVal value As String)
            _PayFreq = value
        End Set
    End Property

    Public Property Printck() As String
        Get
            Return _Printck
        End Get
        Set(ByVal value As String)
            _Printck = value
        End Set
    End Property

    Public Property FwtExmts() As Integer
        Get
            Return _FwtExmts
        End Get
        Set(ByVal value As Integer)
            _FwtExmts = value
        End Set
    End Property

    Public Property SwtExmts() As Integer
        Get
            Return _SwtExmts
        End Get
        Set(ByVal value As Integer)
            _SwtExmts = value
        End Set
    End Property

    Public Property State1Tax() As String
        Get
            Return _State1Tax
        End Get
        Set(ByVal value As String)
            _State1Tax = value
        End Set
    End Property

    Public Property State2Tax() As String
        Get
            Return _State2Tax
        End Get
        Set(ByVal value As String)
            _State2Tax = value
        End Set
    End Property

    Public Property AddFwt() As Decimal
        Get
            Return _AddFwt
        End Get
        Set(ByVal value As Decimal)
            _AddFwt = value
        End Set
    End Property

    Public Property AddfwtDfq() As String
        Get
            Return _AddfwtDfq
        End Get
        Set(ByVal value As String)
            _AddfwtDfq = value
        End Set
    End Property

    Public Property AddSwt() As Decimal
        Get
            Return _AddSwt
        End Get
        Set(ByVal value As Decimal)
            _AddSwt = value
        End Set
    End Property

    Public Property AddswtDfq() As String
        Get
            Return _AddswtDfq
        End Get
        Set(ByVal value As String)
            _AddswtDfq = value
        End Set
    End Property

    Public Property AddFica() As Decimal
        Get
            Return _AddFica
        End Get
        Set(ByVal value As Decimal)
            _AddFica = value
        End Set
    End Property

    Public Property AddficaDfq() As String
        Get
            Return _AddficaDfq
        End Get
        Set(ByVal value As String)
            _AddficaDfq = value
        End Set
    End Property

    Public Property AddMed() As Decimal
        Get
            Return _AddMed
        End Get
        Set(ByVal value As Decimal)
            _AddMed = value
        End Set
    End Property

    Public Property AddmedDfq() As String
        Get
            Return _AddmedDfq
        End Get
        Set(ByVal value As String)
            _AddmedDfq = value
        End Set
    End Property

    Public Property DdepDfq() As String
        Get
            Return _DdepDfq
        End Get
        Set(ByVal value As String)
            _DdepDfq = value
        End Set
    End Property

    Public Property DdepNet() As String
        Get
            Return _DdepNet
        End Get
        Set(ByVal value As String)
            _DdepNet = value
        End Set
    End Property

    Public Property Dduct1Num() As String
        Get
            Return _Dduct1Num
        End Get
        Set(ByVal value As String)
            _Dduct1Num = value
        End Set
    End Property

    Public Property Dduct1Dol() As Decimal
        Get
            Return _Dduct1Dol
        End Get
        Set(ByVal value As Decimal)
            _Dduct1Dol = value
        End Set
    End Property

    Public Property Dduct1Dfq() As String
        Get
            Return _Dduct1Dfq
        End Get
        Set(ByVal value As String)
            _Dduct1Dfq = value
        End Set
    End Property

    Public Property Dduct2Num() As String
        Get
            Return _Dduct2Num
        End Get
        Set(ByVal value As String)
            _Dduct2Num = value
        End Set
    End Property

    Public Property Dduct2Dol() As Decimal
        Get
            Return _Dduct2Dol
        End Get
        Set(ByVal value As Decimal)
            _Dduct2Dol = value
        End Set
    End Property

    Public Property Dduct2Dfq() As String
        Get
            Return _Dduct2Dfq
        End Get
        Set(ByVal value As String)
            _Dduct2Dfq = value
        End Set
    End Property

    Public Property Dduct3Num() As String
        Get
            Return _Dduct3Num
        End Get
        Set(ByVal value As String)
            _Dduct3Num = value
        End Set
    End Property

    Public Property Dduct3Dol() As Decimal
        Get
            Return _Dduct3Dol
        End Get
        Set(ByVal value As Decimal)
            _Dduct3Dol = value
        End Set
    End Property

    Public Property Dduct3Dfq() As String
        Get
            Return _Dduct3Dfq
        End Get
        Set(ByVal value As String)
            _Dduct3Dfq = value
        End Set
    End Property

    Public Property Dduct4Num() As String
        Get
            Return _Dduct4Num
        End Get
        Set(ByVal value As String)
            _Dduct4Num = value
        End Set
    End Property

    Public Property Dduct4Dol() As Decimal
        Get
            Return _Dduct4Dol
        End Get
        Set(ByVal value As Decimal)
            _Dduct4Dol = value
        End Set
    End Property

    Public Property Dduct4Dfq() As String
        Get
            Return _Dduct4Dfq
        End Get
        Set(ByVal value As String)
            _Dduct4Dfq = value
        End Set
    End Property

    Public Property Agency() As Integer
        Get
            Return _Agency
        End Get
        Set(ByVal value As Integer)
            _Agency = value
        End Set
    End Property

    Public Property Dflag() As String
        Get
            Return _Dflag
        End Get
        Set(ByVal value As String)
            _Dflag = value
        End Set
    End Property

    Public Property Text1() As String
        Get
            Return _Text1
        End Get
        Set(ByVal value As String)
            _Text1 = value
        End Set
    End Property

    Public Property Text2() As String
        Get
            Return _Text2
        End Get
        Set(ByVal value As String)
            _Text2 = value
        End Set
    End Property

    Public Property Coach() As String
        Get
            Return _Coach
        End Get
        Set(ByVal value As String)
            _Coach = value
        End Set
    End Property

    Public ReadOnly Property nam_ccColumnNames() As String
        Get
            Return "([Name_Key] , [Screen_Nam] , [Sort_Name] , [Desc1] , [Desc2] , [Desc3] , [Dept_Num] , [Fund_Code] , [Disab_Num] , [Disab_Desc] , [Ss_Num] , [Hire_Date] , [Term_Date] , [Anniv_Mo] , [Dob] , [Avg_Hrly] , [Makeup] , [E_Phone] , [E_Name] , [Wc_Num] , [Wc_Rate] , [Fica_Exmt] , [Med_Exmt] , [File_Status] , [Pay_Freq] , [Printck] , [Fwt_Exmts] , [Swt_Exmts] , [State1_Tax] , [State2_Tax] , [Add_Fwt] , [Addfwt_Dfq] , [Add_Swt] , [Addswt_Dfq] , [Add_Fica] , [Addfica_Dfq] , [Add_Med] , [Addmed_Dfq] , [Ddep_Dfq] , [Ddep_Net] , [Dduct1_Num] , [Dduct1_Dol] , [Dduct1_Dfq] , [Dduct2_Num] , [Dduct2_Dol] , [Dduct2_Dfq] , [Dduct3_Num] , [Dduct3_Dol] , [Dduct3_Dfq] , [Dduct4_Num] , [Dduct4_Dol] , [Dduct4_Dfq] , [Agency] , [Dflag] , [Text1] , [Text2], [Coach] )"
        End Get
    End Property

    Public ReadOnly Property nam_ccColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} , {43} , {44} , {45} , {46} , {47} , {48} , {49} , {50} , {51} , {52} , {53} , {54} , {55}, {56} )" _
, Database.StringParam(_NameKey.ToString) _
, Database.StringParam(_ScreenNam.ToString) _
, Database.StringParam(_SortName.ToString) _
, Database.StringParam(_Desc1.ToString) _
, Database.StringParam(_Desc2.ToString) _
, Database.StringParam(_Desc3.ToString) _
, Database.StringParam(_DeptNum.ToString) _
, Database.StringParam(_FundCode.ToString) _
, Database.StringParam(_DisabNum.ToString) _
, Database.StringParam(_DisabDesc.ToString) _
, Database.StringParam(_SsNum.ToString) _
, Database.StringParam(_HireDate.ToShortDateString) _
, Database.StringParam(_TermDate.ToShortDateString) _
, Database.StringParam(_AnnivMo.ToString) _
, Database.StringParam(_Dob.ToShortDateString) _
, (_AvgHrly.ToString) _
, Database.StringParam(_Makeup.ToString) _
, Database.StringParam(_EPhone.ToString) _
, Database.StringParam(_EName.ToString) _
, Database.StringParam(_WcNum.ToString) _
, (_WcRate.ToString) _
, Database.StringParam(_FicaExmt.ToString) _
, Database.StringParam(_MedExmt.ToString) _
, Database.StringParam(_FileStatus.ToString) _
, Database.StringParam(_PayFreq.ToString) _
, Database.StringParam(_Printck.ToString) _
, (_FwtExmts.ToString) _
, (_SwtExmts.ToString) _
, Database.StringParam(_State1Tax.ToString) _
, Database.StringParam(_State2Tax.ToString) _
, (_AddFwt.ToString) _
, Database.StringParam(_AddfwtDfq.ToString) _
, (_AddSwt.ToString) _
, Database.StringParam(_AddswtDfq.ToString) _
, (_AddFica.ToString) _
, Database.StringParam(_AddficaDfq.ToString) _
, (_AddMed.ToString) _
, Database.StringParam(_AddmedDfq.ToString) _
, Database.StringParam(_DdepDfq.ToString) _
, Database.StringParam(_DdepNet.ToString) _
, Database.StringParam(_Dduct1Num.ToString) _
, (_Dduct1Dol.ToString) _
, Database.StringParam(_Dduct1Dfq.ToString) _
, Database.StringParam(_Dduct2Num.ToString) _
, (_Dduct2Dol.ToString) _
, Database.StringParam(_Dduct2Dfq.ToString) _
, Database.StringParam(_Dduct3Num.ToString) _
, (_Dduct3Dol.ToString) _
, Database.StringParam(_Dduct3Dfq.ToString) _
, Database.StringParam(_Dduct4Num.ToString) _
, (_Dduct4Dol.ToString) _
, Database.StringParam(_Dduct4Dfq.ToString) _
, (_Agency.ToString) _
, Database.StringParam(_Dflag.ToString) _
, Database.StringParam(_Text1.ToString) _
, Database.StringParam(_Text2.ToString) _
, Database.StringParam(_Coach.ToString) _
)
        End Get
    End Property
End Class
