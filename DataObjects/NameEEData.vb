Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient
Imports PS.Common

Public Class nameEEData
    Private _NameKey As String
    Private _ScreenNam As String
    Private _SsNum As String
    Private _HireDate As Date
    Private _TermDate As Date
    Private _AnnivMo As String
    Private _DeptNum As String
    Private _SlotNum As String
    Private _LocNum As String
    Private _CostNum As String
    Private _SupNum As String
    Private _TitleNum As String
    Private _JobTitle As String
    Private _WcNum As String
    Private _WcRate As Decimal
    Private _FicaExmt As String
    Private _AeicElig As String
    Private _FileStatus As String
    Private _PayFreq As String
    Private _FwtExmts As Integer
    Private _SwtExmts As Integer
    Private _HrlySal As String
    Private _RegHrs As Double
    Private _AnnSal As Decimal
    Private _State1Tax As String
    Private _State2Tax As String
    Private _DolRatea As Decimal
    Private _DolRateb As Decimal
    Private _DolRatec As Decimal
    Private _DolRated As Decimal
    Private _DolRatee As Decimal
    Private _DolRatef As Decimal
    Private _DolRateg As Decimal
    Private _DolRateh As Decimal
    Private _DolRatei As Decimal
    Private _DolRatej As Decimal
    Private _AddFwt As Decimal
    Private _AddfwtDfq As String
    Private _AddSwt As Decimal
    Private _AddswtDfq As String
    Private _ANtNum As String
    Private _ANtDol As Decimal
    Private _ANtDfq As String
    Private _BNtNum As String
    Private _BNtDol As Decimal
    Private _BNtDfq As String
    Private _CNtNum As String
    Private _CNtDol As Decimal
    Private _CNtDfq As String
    Private _DNtNum As String
    Private _DNtDol As Decimal
    Private _DNtDfq As String
    Private _ENtNum As String
    Private _ENtDol As Decimal
    Private _ENtDfq As String
    Private _FlxNtNum As String
    Private _FlxNtDol As Decimal
    Private _FlxNtDfq As String
    Private _DepNtNum As String
    Private _DepNtDol As Decimal
    Private _DepNtDfq As String
    Private _Pen1aNum As String
    Private _Pen1aDol As Decimal
    Private _Pen1aPct As Double
    Private _Pen1aDfq As String
    Private _Pen1bNum As String
    Private _Pen1bDol As Decimal
    Private _Pen1bPct As Double
    Private _Pen1bDfq As String
    Private _Pen2aNum As String
    Private _Pen2aDol As Decimal
    Private _Pen2aPct As Double
    Private _Pen2aDfq As String
    Private _Pen2bNum As String
    Private _Pen2bDol As Decimal
    Private _Pen2bPct As Double
    Private _Pen2bDfq As String
    Private _DdepDfq As String
    Private _DdepNet As String
    Private _Save1Num As String
    Private _Save1Dol As Decimal
    Private _Save1Dfq As String
    Private _Ddep1Sav1 As String
    Private _Save2Num As String
    Private _Save2Dol As Decimal
    Private _Save2Dfq As String
    Private _Ddep2Sav2 As String
    Private _Save3Num As String
    Private _Save3Dol As Decimal
    Private _Save3Dfq As String
    Private _Ddep3Sav3 As String
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
    Private _Dduct5Num As String
    Private _Dduct5Dol As Decimal
    Private _Dduct5Dfq As String
    Private _Dduct6Num As String
    Private _Dduct6Dol As Decimal
    Private _Dduct6Dfq As String
    Private _Dduct7Num As String
    Private _Dduct7Dol As Decimal
    Private _Dduct7Dfq As String
    Private _Dduct8Num As String
    Private _Dduct8Dol As Decimal
    Private _Dduct8Dfq As String
    Private _Dduct9Num As String
    Private _Dduct9Dol As Decimal
    Private _Dduct9Dfq As String
    Private _Misc1Num As String
    Private _Misc1Dol As Decimal
    Private _Misc1Dfq As String
    Private _Misc2Num As String
    Private _Misc2Dol As Decimal
    Private _Misc2Dfq As String
    Private _Agency As Integer
    Private _Dflag As String
    Private _MedExmt As String
    Private _SortName As String
    Private _BeeperNum As String

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

    Public Property DeptNum() As String
        Get
            Return _DeptNum
        End Get
        Set(ByVal value As String)
            _DeptNum = value
        End Set
    End Property

    Public Property SlotNum() As String
        Get
            Return _SlotNum
        End Get
        Set(ByVal value As String)
            _SlotNum = value
        End Set
    End Property

    Public Property LocNum() As String
        Get
            Return _LocNum
        End Get
        Set(ByVal value As String)
            _LocNum = value
        End Set
    End Property

    Public Property CostNum() As String
        Get
            Return _CostNum
        End Get
        Set(ByVal value As String)
            _CostNum = value
        End Set
    End Property

    Public Property SupNum() As String
        Get
            Return _SupNum
        End Get
        Set(ByVal value As String)
            _SupNum = value
        End Set
    End Property

    Public Property TitleNum() As String
        Get
            Return _TitleNum
        End Get
        Set(ByVal value As String)
            _TitleNum = value
        End Set
    End Property

    Public Property JobTitle() As String
        Get
            Return _JobTitle
        End Get
        Set(ByVal value As String)
            _JobTitle = value
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

    Public Property AeicElig() As String
        Get
            Return _AeicElig
        End Get
        Set(ByVal value As String)
            _AeicElig = value
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

    Public Property HrlySal() As String
        Get
            Return _HrlySal
        End Get
        Set(ByVal value As String)
            _HrlySal = value
        End Set
    End Property

    Public Property RegHrs() As Double
        Get
            Return _RegHrs
        End Get
        Set(ByVal value As Double)
            _RegHrs = value
        End Set
    End Property

    Public Property AnnSal() As Decimal
        Get
            Return _AnnSal
        End Get
        Set(ByVal value As Decimal)
            _AnnSal = value
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

    Public Property DolRatea() As Decimal
        Get
            Return _DolRatea
        End Get
        Set(ByVal value As Decimal)
            _DolRatea = value
        End Set
    End Property

    Public Property DolRateb() As Decimal
        Get
            Return _DolRateb
        End Get
        Set(ByVal value As Decimal)
            _DolRateb = value
        End Set
    End Property

    Public Property DolRatec() As Decimal
        Get
            Return _DolRatec
        End Get
        Set(ByVal value As Decimal)
            _DolRatec = value
        End Set
    End Property

    Public Property DolRated() As Decimal
        Get
            Return _DolRated
        End Get
        Set(ByVal value As Decimal)
            _DolRated = value
        End Set
    End Property

    Public Property DolRatee() As Decimal
        Get
            Return _DolRatee
        End Get
        Set(ByVal value As Decimal)
            _DolRatee = value
        End Set
    End Property

    Public Property DolRatef() As Decimal
        Get
            Return _DolRatef
        End Get
        Set(ByVal value As Decimal)
            _DolRatef = value
        End Set
    End Property

    Public Property DolRateg() As Decimal
        Get
            Return _DolRateg
        End Get
        Set(ByVal value As Decimal)
            _DolRateg = value
        End Set
    End Property

    Public Property DolRateh() As Decimal
        Get
            Return _DolRateh
        End Get
        Set(ByVal value As Decimal)
            _DolRateh = value
        End Set
    End Property

    Public Property DolRatei() As Decimal
        Get
            Return _DolRatei
        End Get
        Set(ByVal value As Decimal)
            _DolRatei = value
        End Set
    End Property

    Public Property DolRatej() As Decimal
        Get
            Return _DolRatej
        End Get
        Set(ByVal value As Decimal)
            _DolRatej = value
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

    Public Property ANtNum() As String
        Get
            Return _ANtNum
        End Get
        Set(ByVal value As String)
            _ANtNum = value
        End Set
    End Property

    Public Property ANtDol() As Decimal
        Get
            Return _ANtDol
        End Get
        Set(ByVal value As Decimal)
            _ANtDol = value
        End Set
    End Property

    Public Property ANtDfq() As String
        Get
            Return _ANtDfq
        End Get
        Set(ByVal value As String)
            _ANtDfq = value
        End Set
    End Property

    Public Property BNtNum() As String
        Get
            Return _BNtNum
        End Get
        Set(ByVal value As String)
            _BNtNum = value
        End Set
    End Property

    Public Property BNtDol() As Decimal
        Get
            Return _BNtDol
        End Get
        Set(ByVal value As Decimal)
            _BNtDol = value
        End Set
    End Property

    Public Property BNtDfq() As String
        Get
            Return _BNtDfq
        End Get
        Set(ByVal value As String)
            _BNtDfq = value
        End Set
    End Property

    Public Property CNtNum() As String
        Get
            Return _CNtNum
        End Get
        Set(ByVal value As String)
            _CNtNum = value
        End Set
    End Property

    Public Property CNtDol() As Decimal
        Get
            Return _CNtDol
        End Get
        Set(ByVal value As Decimal)
            _CNtDol = value
        End Set
    End Property

    Public Property CNtDfq() As String
        Get
            Return _CNtDfq
        End Get
        Set(ByVal value As String)
            _CNtDfq = value
        End Set
    End Property

    Public Property DNtNum() As String
        Get
            Return _DNtNum
        End Get
        Set(ByVal value As String)
            _DNtNum = value
        End Set
    End Property

    Public Property DNtDol() As Decimal
        Get
            Return _DNtDol
        End Get
        Set(ByVal value As Decimal)
            _DNtDol = value
        End Set
    End Property

    Public Property DNtDfq() As String
        Get
            Return _DNtDfq
        End Get
        Set(ByVal value As String)
            _DNtDfq = value
        End Set
    End Property

    Public Property ENtNum() As String
        Get
            Return _ENtNum
        End Get
        Set(ByVal value As String)
            _ENtNum = value
        End Set
    End Property

    Public Property ENtDol() As Decimal
        Get
            Return _ENtDol
        End Get
        Set(ByVal value As Decimal)
            _ENtDol = value
        End Set
    End Property

    Public Property ENtDfq() As String
        Get
            Return _ENtDfq
        End Get
        Set(ByVal value As String)
            _ENtDfq = value
        End Set
    End Property

    Public Property FlxNtNum() As String
        Get
            Return _FlxNtNum
        End Get
        Set(ByVal value As String)
            _FlxNtNum = value
        End Set
    End Property

    Public Property FlxNtDol() As Decimal
        Get
            Return _FlxNtDol
        End Get
        Set(ByVal value As Decimal)
            _FlxNtDol = value
        End Set
    End Property

    Public Property FlxNtDfq() As String
        Get
            Return _FlxNtDfq
        End Get
        Set(ByVal value As String)
            _FlxNtDfq = value
        End Set
    End Property

    Public Property DepNtNum() As String
        Get
            Return _DepNtNum
        End Get
        Set(ByVal value As String)
            _DepNtNum = value
        End Set
    End Property

    Public Property DepNtDol() As Decimal
        Get
            Return _DepNtDol
        End Get
        Set(ByVal value As Decimal)
            _DepNtDol = value
        End Set
    End Property

    Public Property DepNtDfq() As String
        Get
            Return _DepNtDfq
        End Get
        Set(ByVal value As String)
            _DepNtDfq = value
        End Set
    End Property

    Public Property Pen1aNum() As String
        Get
            Return _Pen1aNum
        End Get
        Set(ByVal value As String)
            _Pen1aNum = value
        End Set
    End Property

    Public Property Pen1aDol() As Decimal
        Get
            Return _Pen1aDol
        End Get
        Set(ByVal value As Decimal)
            _Pen1aDol = value
        End Set
    End Property

    Public Property Pen1aPct() As Double
        Get
            Return _Pen1aPct
        End Get
        Set(ByVal value As Double)
            _Pen1aPct = value
        End Set
    End Property

    Public Property Pen1aDfq() As String
        Get
            Return _Pen1aDfq
        End Get
        Set(ByVal value As String)
            _Pen1aDfq = value
        End Set
    End Property

    Public Property Pen1bNum() As String
        Get
            Return _Pen1bNum
        End Get
        Set(ByVal value As String)
            _Pen1bNum = value
        End Set
    End Property

    Public Property Pen1bDol() As Decimal
        Get
            Return _Pen1bDol
        End Get
        Set(ByVal value As Decimal)
            _Pen1bDol = value
        End Set
    End Property

    Public Property Pen1bPct() As Double
        Get
            Return _Pen1bPct
        End Get
        Set(ByVal value As Double)
            _Pen1bPct = value
        End Set
    End Property

    Public Property Pen1bDfq() As String
        Get
            Return _Pen1bDfq
        End Get
        Set(ByVal value As String)
            _Pen1bDfq = value
        End Set
    End Property

    Public Property Pen2aNum() As String
        Get
            Return _Pen2aNum
        End Get
        Set(ByVal value As String)
            _Pen2aNum = value
        End Set
    End Property

    Public Property Pen2aDol() As Decimal
        Get
            Return _Pen2aDol
        End Get
        Set(ByVal value As Decimal)
            _Pen2aDol = value
        End Set
    End Property

    Public Property Pen2aPct() As Double
        Get
            Return _Pen2aPct
        End Get
        Set(ByVal value As Double)
            _Pen2aPct = value
        End Set
    End Property

    Public Property Pen2aDfq() As String
        Get
            Return _Pen2aDfq
        End Get
        Set(ByVal value As String)
            _Pen2aDfq = value
        End Set
    End Property

    Public Property Pen2bNum() As String
        Get
            Return _Pen2bNum
        End Get
        Set(ByVal value As String)
            _Pen2bNum = value
        End Set
    End Property

    Public Property Pen2bDol() As Decimal
        Get
            Return _Pen2bDol
        End Get
        Set(ByVal value As Decimal)
            _Pen2bDol = value
        End Set
    End Property

    Public Property Pen2bPct() As Double
        Get
            Return _Pen2bPct
        End Get
        Set(ByVal value As Double)
            _Pen2bPct = value
        End Set
    End Property

    Public Property Pen2bDfq() As String
        Get
            Return _Pen2bDfq
        End Get
        Set(ByVal value As String)
            _Pen2bDfq = value
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

    Public Property Save1Num() As String
        Get
            Return _Save1Num
        End Get
        Set(ByVal value As String)
            _Save1Num = value
        End Set
    End Property

    Public Property Save1Dol() As Decimal
        Get
            Return _Save1Dol
        End Get
        Set(ByVal value As Decimal)
            _Save1Dol = value
        End Set
    End Property

    Public Property Save1Dfq() As String
        Get
            Return _Save1Dfq
        End Get
        Set(ByVal value As String)
            _Save1Dfq = value
        End Set
    End Property

    Public Property Ddep1Sav1() As String
        Get
            Return _Ddep1Sav1
        End Get
        Set(ByVal value As String)
            _Ddep1Sav1 = value
        End Set
    End Property

    Public Property Save2Num() As String
        Get
            Return _Save2Num
        End Get
        Set(ByVal value As String)
            _Save2Num = value
        End Set
    End Property

    Public Property Save2Dol() As Decimal
        Get
            Return _Save2Dol
        End Get
        Set(ByVal value As Decimal)
            _Save2Dol = value
        End Set
    End Property

    Public Property Save2Dfq() As String
        Get
            Return _Save2Dfq
        End Get
        Set(ByVal value As String)
            _Save2Dfq = value
        End Set
    End Property

    Public Property Ddep2Sav2() As String
        Get
            Return _Ddep2Sav2
        End Get
        Set(ByVal value As String)
            _Ddep2Sav2 = value
        End Set
    End Property

    Public Property Save3Num() As String
        Get
            Return _Save3Num
        End Get
        Set(ByVal value As String)
            _Save3Num = value
        End Set
    End Property

    Public Property Save3Dol() As Decimal
        Get
            Return _Save3Dol
        End Get
        Set(ByVal value As Decimal)
            _Save3Dol = value
        End Set
    End Property

    Public Property Save3Dfq() As String
        Get
            Return _Save3Dfq
        End Get
        Set(ByVal value As String)
            _Save3Dfq = value
        End Set
    End Property

    Public Property Ddep3Sav3() As String
        Get
            Return _Ddep3Sav3
        End Get
        Set(ByVal value As String)
            _Ddep3Sav3 = value
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

    Public Property Dduct5Num() As String
        Get
            Return _Dduct5Num
        End Get
        Set(ByVal value As String)
            _Dduct5Num = value
        End Set
    End Property

    Public Property Dduct5Dol() As Decimal
        Get
            Return _Dduct5Dol
        End Get
        Set(ByVal value As Decimal)
            _Dduct5Dol = value
        End Set
    End Property

    Public Property Dduct5Dfq() As String
        Get
            Return _Dduct5Dfq
        End Get
        Set(ByVal value As String)
            _Dduct5Dfq = value
        End Set
    End Property

    Public Property Dduct6Num() As String
        Get
            Return _Dduct6Num
        End Get
        Set(ByVal value As String)
            _Dduct6Num = value
        End Set
    End Property

    Public Property Dduct6Dol() As Decimal
        Get
            Return _Dduct6Dol
        End Get
        Set(ByVal value As Decimal)
            _Dduct6Dol = value
        End Set
    End Property

    Public Property Dduct6Dfq() As String
        Get
            Return _Dduct6Dfq
        End Get
        Set(ByVal value As String)
            _Dduct6Dfq = value
        End Set
    End Property

    Public Property Dduct7Num() As String
        Get
            Return _Dduct7Num
        End Get
        Set(ByVal value As String)
            _Dduct7Num = value
        End Set
    End Property

    Public Property Dduct7Dol() As Decimal
        Get
            Return _Dduct7Dol
        End Get
        Set(ByVal value As Decimal)
            _Dduct7Dol = value
        End Set
    End Property

    Public Property Dduct7Dfq() As String
        Get
            Return _Dduct7Dfq
        End Get
        Set(ByVal value As String)
            _Dduct7Dfq = value
        End Set
    End Property

    Public Property Dduct8Num() As String
        Get
            Return _Dduct8Num
        End Get
        Set(ByVal value As String)
            _Dduct8Num = value
        End Set
    End Property

    Public Property Dduct8Dol() As Decimal
        Get
            Return _Dduct8Dol
        End Get
        Set(ByVal value As Decimal)
            _Dduct8Dol = value
        End Set
    End Property

    Public Property Dduct8Dfq() As String
        Get
            Return _Dduct8Dfq
        End Get
        Set(ByVal value As String)
            _Dduct8Dfq = value
        End Set
    End Property

    Public Property Dduct9Num() As String
        Get
            Return _Dduct9Num
        End Get
        Set(ByVal value As String)
            _Dduct9Num = value
        End Set
    End Property

    Public Property Dduct9Dol() As Decimal
        Get
            Return _Dduct9Dol
        End Get
        Set(ByVal value As Decimal)
            _Dduct9Dol = value
        End Set
    End Property

    Public Property Dduct9Dfq() As String
        Get
            Return _Dduct9Dfq
        End Get
        Set(ByVal value As String)
            _Dduct9Dfq = value
        End Set
    End Property

    Public Property Misc1Num() As String
        Get
            Return _Misc1Num
        End Get
        Set(ByVal value As String)
            _Misc1Num = value
        End Set
    End Property

    Public Property Misc1Dol() As Decimal
        Get
            Return _Misc1Dol
        End Get
        Set(ByVal value As Decimal)
            _Misc1Dol = value
        End Set
    End Property

    Public Property Misc1Dfq() As String
        Get
            Return _Misc1Dfq
        End Get
        Set(ByVal value As String)
            _Misc1Dfq = value
        End Set
    End Property

    Public Property Misc2Num() As String
        Get
            Return _Misc2Num
        End Get
        Set(ByVal value As String)
            _Misc2Num = value
        End Set
    End Property

    Public Property Misc2Dol() As Decimal
        Get
            Return _Misc2Dol
        End Get
        Set(ByVal value As Decimal)
            _Misc2Dol = value
        End Set
    End Property

    Public Property Misc2Dfq() As String
        Get
            Return _Misc2Dfq
        End Get
        Set(ByVal value As String)
            _Misc2Dfq = value
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

    Public Property MedExmt() As String
        Get
            Return _MedExmt
        End Get
        Set(ByVal value As String)
            _MedExmt = value
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

    Public Property BeeperNum() As String
        Get
            Return _BeeperNum
        End Get
        Set(ByVal value As String)
            _BeeperNum = value
        End Set
    End Property


    Public ReadOnly Property nam_eeColumnNames() As String
        Get
            Return "([name_key] , [screen_nam] , [ss_num] , [hire_date] , [term_date] , [anniv_mo] , [dept_num] , [slot_num] , [loc_num] , [cost_num] , [sup_num] , [title_num] , [job_title] , [wc_num] , [wc_rate] , [fica_exmt] , [aeic_elig] , [file_status] , [pay_freq] , [fwt_exmts] , [swt_exmts] , [hrly-sal] , [reg_hrs] , [ann_sal] , [state1_tax] , [state2_tax] , [dol_ratea] , [dol_rateb] , [dol_ratec] , [dol_rated] , [dol_ratee] , [dol_ratef] , [dol_rateg] , [dol_rateh] , [dol_ratei] , [dol_ratej] , [add_fwt] , [addfwt_dfq] , [add_swt] , [addswt_dfq] , [a_nt_num] , [a_nt_dol] , [a_nt_dfq] , [b_nt_num] , [b_nt_dol] , [b_nt_dfq] , [c_nt_num] , [c_nt_dol] , [c_nt_dfq] , [d_nt_num] , [d_nt_dol] , [d_nt_dfq] , [e_nt_num] , [e_nt_dol] , [e_nt_dfq] , [flx_nt_num] , [flx_nt_dol] , [flx_nt_dfq] , [dep_nt_num] , [dep_nt_dol] , [dep_nt_dfq] , [pen1a_num] , [pen1a_dol] , [pen1a_pct] , [pen1a_dfq] , [pen1b_num] , [pen1b_dol] , [pen1b_pct] , [pen1b_dfq] , [pen2a_num] , [pen2a_dol] , [pen2a_pct] , [pen2a_dfq] , [pen2b_num] , [pen2b_dol] , [pen2b_pct] , [pen2b_dfq] , [ddep_dfq] , [ddep_net] , [save1_num] , [save1_dol] , [save1_dfq] , [ddep1_sav1] , [save2_num] , [save2_dol] , [save2_dfq] , [ddep2_sav2] , [save3_num] , [save3_dol] , [save3_dfq] , [ddep3_sav3] , [dduct1_num] , [dduct1_dol] , [dduct1_dfq] , [dduct2_num] , [dduct2_dol] , [dduct2_dfq] , [dduct3_num] , [dduct3_dol] , [dduct3_dfq] , [dduct4_num] , [dduct4_dol] , [dduct4_dfq] , [dduct5_num] , [dduct5_dol] , [dduct5_dfq] , [dduct6_num] , [dduct6_dol] , [dduct6_dfq] , [dduct7_num] , [dduct7_dol] , [dduct7_dfq] , [dduct8_num] , [dduct8_dol] , [dduct8_dfq] , [dduct9_num] , [dduct9_dol] , [dduct9_dfq] , [misc1_num] , [misc1_dol] , [misc1_dfq] , [misc2_num] , [misc2_dol] , [misc2_dfq] , [agency] , [dflag] , [med_exmt] , [sort_name] , [beeper_num] )"
        End Get
    End Property

    Public ReadOnly Property nam_eeColumnData() As String
        Get
            Return String.Format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} , {43} , {44} , {45} , {46} , {47} , {48} , {49} , {50} , {51} , {52} , {53} , {54} , {55} , {56} , {57} , {58} , {59} , {60} , {61} , {62} , {63} , {64} , {65} , {66} , {67} , {68} , {69} , {70} , {71} , {72} , {73} , {74} , {75} , {76} , {77} , {78} , {79} , {80} , {81} , {82} , {83} , {84} , {85} , {86} , {87} , {88} , {89} , {90} , {91} , {92} , {93} , {94} , {95} , {96} , {97} , {98} , {99} , {100} , {101} , {102} , {103} , {104} , {105} , {106} , {107} , {108} , {109} , {110} , {111} , {112} , {113} , {114} , {115} , {116} , {117} , {118} , {119} , {120} , {121} , {122} , {123} , {124} , {125} , {126} , {127} , {128} )" _
, Database.StringParam(_NameKey.ToString) _
, Database.StringParam(_ScreenNam.ToString) _
, Database.StringParam(_SsNum.ToString) _
, Database.StringParam(_HireDate.ToShortDateString) _
, Database.StringParam(_TermDate.ToShortDateString) _
, Database.StringParam(_AnnivMo.ToString) _
, Database.StringParam(_DeptNum.ToString) _
, Database.StringParam(_SlotNum.ToString) _
, Database.StringParam(_LocNum.ToString) _
, Database.StringParam(_CostNum.ToString) _
, Database.StringParam(_SupNum.ToString) _
, Database.StringParam(_TitleNum.ToString) _
, Database.StringParam(_JobTitle.ToString) _
, Database.StringParam(_WcNum.ToString) _
, (_WcRate.ToString) _
, Database.StringParam(_FicaExmt.ToString) _
, Database.StringParam(_AeicElig.ToString) _
, Database.StringParam(_FileStatus.ToString) _
, Database.StringParam(_PayFreq.ToString) _
, (_FwtExmts.ToString) _
, (_SwtExmts.ToString) _
, Database.StringParam(_HrlySal.ToString) _
, (_RegHrs.ToString) _
, (_AnnSal.ToString) _
, Database.StringParam(_State1Tax.ToString) _
, Database.StringParam(_State2Tax.ToString) _
, (_DolRatea.ToString) _
, (_DolRateb.ToString) _
, (_DolRatec.ToString) _
, (_DolRated.ToString) _
, (_DolRatee.ToString) _
, (_DolRatef.ToString) _
, (_DolRateg.ToString) _
, (_DolRateh.ToString) _
, (_DolRatei.ToString) _
, (_DolRatej.ToString) _
, (_AddFwt.ToString) _
, Database.StringParam(_AddfwtDfq.ToString) _
, (_AddSwt.ToString) _
, Database.StringParam(_AddswtDfq.ToString) _
, Database.StringParam(_ANtNum.ToString) _
, (_ANtDol.ToString) _
, Database.StringParam(_ANtDfq.ToString) _
, Database.StringParam(_BNtNum.ToString) _
, (_BNtDol.ToString) _
, Database.StringParam(_BNtDfq.ToString) _
, Database.StringParam(_CNtNum.ToString) _
, (_CNtDol.ToString) _
, Database.StringParam(_CNtDfq.ToString) _
, Database.StringParam(_DNtNum.ToString) _
, (_DNtDol.ToString) _
, Database.StringParam(_DNtDfq.ToString) _
, Database.StringParam(_ENtNum.ToString) _
, (_ENtDol.ToString) _
, Database.StringParam(_ENtDfq.ToString) _
, Database.StringParam(_FlxNtNum.ToString) _
, (_FlxNtDol.ToString) _
, Database.StringParam(_FlxNtDfq.ToString) _
, Database.StringParam(_DepNtNum.ToString) _
, (_DepNtDol.ToString) _
, Database.StringParam(_DepNtDfq.ToString) _
, Database.StringParam(_Pen1aNum.ToString) _
, (_Pen1aDol.ToString) _
, (_Pen1aPct.ToString) _
, Database.StringParam(_Pen1aDfq.ToString) _
, Database.StringParam(_Pen1bNum.ToString) _
, (_Pen1bDol.ToString) _
, (_Pen1bPct.ToString) _
, Database.StringParam(_Pen1bDfq.ToString) _
, Database.StringParam(_Pen2aNum.ToString) _
, (_Pen2aDol.ToString) _
, (_Pen2aPct.ToString) _
, Database.StringParam(_Pen2aDfq.ToString) _
, Database.StringParam(_Pen2bNum.ToString) _
, (_Pen2bDol.ToString) _
, (_Pen2bPct.ToString) _
, Database.StringParam(_Pen2bDfq.ToString) _
, Database.StringParam(_DdepDfq.ToString) _
, Database.StringParam(_DdepNet.ToString) _
, Database.StringParam(_Save1Num.ToString) _
, (_Save1Dol.ToString) _
, Database.StringParam(_Save1Dfq.ToString) _
, Database.StringParam(_Ddep1Sav1.ToString) _
, Database.StringParam(_Save2Num.ToString) _
, (_Save2Dol.ToString) _
, Database.StringParam(_Save2Dfq.ToString) _
, Database.StringParam(_Ddep2Sav2.ToString) _
, Database.StringParam(_Save3Num.ToString) _
, (_Save3Dol.ToString) _
, Database.StringParam(_Save3Dfq.ToString) _
, Database.StringParam(_Ddep3Sav3.ToString) _
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
, Database.StringParam(_Dduct5Num.ToString) _
, (_Dduct5Dol.ToString) _
, Database.StringParam(_Dduct5Dfq.ToString) _
, Database.StringParam(_Dduct6Num.ToString) _
, (_Dduct6Dol.ToString) _
, Database.StringParam(_Dduct6Dfq.ToString) _
, Database.StringParam(_Dduct7Num.ToString) _
, (_Dduct7Dol.ToString) _
, Database.StringParam(_Dduct7Dfq.ToString) _
, Database.StringParam(_Dduct8Num.ToString) _
, (_Dduct8Dol.ToString) _
, Database.StringParam(_Dduct8Dfq.ToString) _
, Database.StringParam(_Dduct9Num.ToString) _
, (_Dduct9Dol.ToString) _
, Database.StringParam(_Dduct9Dfq.ToString) _
, Database.StringParam(_Misc1Num.ToString) _
, (_Misc1Dol.ToString) _
, Database.StringParam(_Misc1Dfq.ToString) _
, Database.StringParam(_Misc2Num.ToString) _
, (_Misc2Dol.ToString) _
, Database.StringParam(_Misc2Dfq.ToString) _
, (_Agency.ToString) _
, Database.StringParam(_Dflag.ToString) _
, Database.StringParam(_MedExmt.ToString) _
, Database.StringParam(_SortName.ToString) _
, Database.StringParam(_BeeperNum.ToString) _
)
        End Get
    End Property
End Class
