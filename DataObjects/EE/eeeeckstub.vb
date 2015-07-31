Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class eeckstubData
	Private _ChkNum as Integer
	Private _ChkDate as Date
	Private _ChkDirdep as String
	Private _PayNum as Integer
	Private _NameKey as String
	Private _ScreenNam as String
	Private _DeptNum as String
	Private _SlotNum as String
	Private _LocNum as String
	Private _CostNum as String
	Private _TitleNum as String
	Private _PayFreq as String
	Private _DedDfq as String
	Private _FwtExmts as Integer
	Private _SwtExmts as Integer
	Private _BlendOvt as Decimal
	Private _RegHrs as Double
	Private _RegDol as Decimal
	Private _OvtHrs as Double
	Private _OvtDol as Decimal
	Private _VacHrs as Double
	Private _VacDol as Decimal
	Private _SickHrs as Double
	Private _SickDol as Decimal
	Private _HolHrs as Double
	Private _HolDol as Decimal
	Private _PersHrs as Double
	Private _PersDol as Decimal
	Private _OtherPay as Decimal
	Private _FullGross as Decimal
	Private _FedGross as Decimal
	Private _FedTax as Decimal
	Private _FicaGross as Decimal
	Private _FicaTax as Decimal
	Private _MedGross as Decimal
	Private _MedTax as Decimal
	Private _State1Gross as Decimal
	Private _State1Tax as Decimal
	Private _State2Gross as Decimal
	Private _State2Tax as Decimal
	Private _AeicAmt as Decimal
	Private _NetPay as Decimal
	Private _ANtDol as Decimal
	Private _ANtNum as String
	Private _BNtDol as Decimal
	Private _BNtNum as String
	Private _CNtDol as Decimal
	Private _CNtNum as String
	Private _DNtDol as Decimal
	Private _DNtNum as String
	Private _ENtDol as Decimal
	Private _ENtNum as String
	Private _FlxNtDol as Decimal
	Private _FlxNtNum as String
	Private _DepNtDol as Decimal
	Private _DepNtNum as String
	Private _Pen1aDol as Decimal
	Private _Pen1aNum as String
	Private _Pen1bDol as Decimal
	Private _Pen1bNum as String
	Private _Pen2aDol as Decimal
	Private _Pen2aNum as String
	Private _Pen2bDol as Decimal
	Private _Pen2bNum as String
	Private _Save1Ded as Decimal
	Private _Save2Ded as Decimal
	Private _Save3Ded as Decimal
	Private _Dduct1Dol as Decimal
	Private _Dduct1Num as String
	Private _Dduct2Dol as Decimal
	Private _Dduct2Num as String
	Private _Dduct3Dol as Decimal
	Private _Dduct3Num as String
	Private _Dduct4Dol as Decimal
	Private _Dduct4Num as String
	Private _Dduct5Dol as Decimal
	Private _Dduct5Num as String
	Private _Dduct6Dol as Decimal
	Private _Dduct6Num as String
	Private _Dduct7Dol as Decimal
	Private _Dduct7Num as String
	Private _Dduct8Dol as Decimal
	Private _Dduct8Num as String
	Private _Dduct9Dol as Decimal
	Private _Dduct9Num as String
	Private _Misc1Dol as Decimal
	Private _Misc1Num as String
	Private _Misc2Dol as Decimal
	Private _Misc2Num as String
	Private _GlPost as String
	Private _EncumDate as Date
	Private _Recon as String
	Private _RDate as Date
	Private _Void as String
	Private _Agency as Integer
	Private _Dflag as String
	Private _AddFwt as Decimal
	Private _AddSwt as Decimal
	Private _State1Code as String
	Private _State2Code as String
	Private _Save1Num as String
	Private _Save2Num as String
	Private _Save3Num as String
	Private _EntryNum as Integer
	Private _TdiTax as Decimal
	Private _DdepSav1 as String
	Private _DdepSav2 as String
	Private _DdepSav3 as String
	Private _NoPayHrs as Decimal
	Private _SortName as String
	Private _JrnlNum as Integer
	Private _JrnlLine as Integer

Public Property ChkNum()  as Integer
	Get
		Return _ChkNum
	End Get
	Set (ByVal value  as Integer )
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

Public Property ChkDirdep()  as String
	Get
		Return _ChkDirdep
	End Get
	Set (ByVal value  as String )
		_ChkDirdep = value
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

Public Property DeptNum()  as String
	Get
		Return _DeptNum
	End Get
	Set (ByVal value  as String )
		_DeptNum = value
	End Set
End Property

Public Property SlotNum()  as String
	Get
		Return _SlotNum
	End Get
	Set (ByVal value  as String )
		_SlotNum = value
	End Set
End Property

Public Property LocNum()  as String
	Get
		Return _LocNum
	End Get
	Set (ByVal value  as String )
		_LocNum = value
	End Set
End Property

Public Property CostNum()  as String
	Get
		Return _CostNum
	End Get
	Set (ByVal value  as String )
		_CostNum = value
	End Set
End Property

Public Property TitleNum()  as String
	Get
		Return _TitleNum
	End Get
	Set (ByVal value  as String )
		_TitleNum = value
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

Public Property FwtExmts()  as Integer
	Get
		Return _FwtExmts
	End Get
	Set (ByVal value  as Integer )
		_FwtExmts = value
	End Set
End Property

Public Property SwtExmts()  as Integer
	Get
		Return _SwtExmts
	End Get
	Set (ByVal value  as Integer )
		_SwtExmts = value
	End Set
End Property

Public Property BlendOvt()  as Decimal
	Get
		Return _BlendOvt
	End Get
	Set (ByVal value  as Decimal )
		_BlendOvt = value
	End Set
End Property

Public Property RegHrs()  as Double
	Get
		Return _RegHrs
	End Get
	Set (ByVal value  as Double )
		_RegHrs = value
	End Set
End Property

Public Property RegDol()  as Decimal
	Get
		Return _RegDol
	End Get
	Set (ByVal value  as Decimal )
		_RegDol = value
	End Set
End Property

Public Property OvtHrs()  as Double
	Get
		Return _OvtHrs
	End Get
	Set (ByVal value  as Double )
		_OvtHrs = value
	End Set
End Property

Public Property OvtDol()  as Decimal
	Get
		Return _OvtDol
	End Get
	Set (ByVal value  as Decimal )
		_OvtDol = value
	End Set
End Property

Public Property VacHrs()  as Double
	Get
		Return _VacHrs
	End Get
	Set (ByVal value  as Double )
		_VacHrs = value
	End Set
End Property

Public Property VacDol()  as Decimal
	Get
		Return _VacDol
	End Get
	Set (ByVal value  as Decimal )
		_VacDol = value
	End Set
End Property

Public Property SickHrs()  as Double
	Get
		Return _SickHrs
	End Get
	Set (ByVal value  as Double )
		_SickHrs = value
	End Set
End Property

Public Property SickDol()  as Decimal
	Get
		Return _SickDol
	End Get
	Set (ByVal value  as Decimal )
		_SickDol = value
	End Set
End Property

Public Property HolHrs()  as Double
	Get
		Return _HolHrs
	End Get
	Set (ByVal value  as Double )
		_HolHrs = value
	End Set
End Property

Public Property HolDol()  as Decimal
	Get
		Return _HolDol
	End Get
	Set (ByVal value  as Decimal )
		_HolDol = value
	End Set
End Property

Public Property PersHrs()  as Double
	Get
		Return _PersHrs
	End Get
	Set (ByVal value  as Double )
		_PersHrs = value
	End Set
End Property

Public Property PersDol()  as Decimal
	Get
		Return _PersDol
	End Get
	Set (ByVal value  as Decimal )
		_PersDol = value
	End Set
End Property

Public Property OtherPay()  as Decimal
	Get
		Return _OtherPay
	End Get
	Set (ByVal value  as Decimal )
		_OtherPay = value
	End Set
End Property

Public Property FullGross()  as Decimal
	Get
		Return _FullGross
	End Get
	Set (ByVal value  as Decimal )
		_FullGross = value
	End Set
End Property

Public Property FedGross()  as Decimal
	Get
		Return _FedGross
	End Get
	Set (ByVal value  as Decimal )
		_FedGross = value
	End Set
End Property

Public Property FedTax()  as Decimal
	Get
		Return _FedTax
	End Get
	Set (ByVal value  as Decimal )
		_FedTax = value
	End Set
End Property

Public Property FicaGross()  as Decimal
	Get
		Return _FicaGross
	End Get
	Set (ByVal value  as Decimal )
		_FicaGross = value
	End Set
End Property

Public Property FicaTax()  as Decimal
	Get
		Return _FicaTax
	End Get
	Set (ByVal value  as Decimal )
		_FicaTax = value
	End Set
End Property

Public Property MedGross()  as Decimal
	Get
		Return _MedGross
	End Get
	Set (ByVal value  as Decimal )
		_MedGross = value
	End Set
End Property

Public Property MedTax()  as Decimal
	Get
		Return _MedTax
	End Get
	Set (ByVal value  as Decimal )
		_MedTax = value
	End Set
End Property

Public Property State1Gross()  as Decimal
	Get
		Return _State1Gross
	End Get
	Set (ByVal value  as Decimal )
		_State1Gross = value
	End Set
End Property

Public Property State1Tax()  as Decimal
	Get
		Return _State1Tax
	End Get
	Set (ByVal value  as Decimal )
		_State1Tax = value
	End Set
End Property

Public Property State2Gross()  as Decimal
	Get
		Return _State2Gross
	End Get
	Set (ByVal value  as Decimal )
		_State2Gross = value
	End Set
End Property

Public Property State2Tax()  as Decimal
	Get
		Return _State2Tax
	End Get
	Set (ByVal value  as Decimal )
		_State2Tax = value
	End Set
End Property

Public Property AeicAmt()  as Decimal
	Get
		Return _AeicAmt
	End Get
	Set (ByVal value  as Decimal )
		_AeicAmt = value
	End Set
End Property

Public Property NetPay()  as Decimal
	Get
		Return _NetPay
	End Get
	Set (ByVal value  as Decimal )
		_NetPay = value
	End Set
End Property

Public Property ANtDol()  as Decimal
	Get
		Return _ANtDol
	End Get
	Set (ByVal value  as Decimal )
		_ANtDol = value
	End Set
End Property

Public Property ANtNum()  as String
	Get
		Return _ANtNum
	End Get
	Set (ByVal value  as String )
		_ANtNum = value
	End Set
End Property

Public Property BNtDol()  as Decimal
	Get
		Return _BNtDol
	End Get
	Set (ByVal value  as Decimal )
		_BNtDol = value
	End Set
End Property

Public Property BNtNum()  as String
	Get
		Return _BNtNum
	End Get
	Set (ByVal value  as String )
		_BNtNum = value
	End Set
End Property

Public Property CNtDol()  as Decimal
	Get
		Return _CNtDol
	End Get
	Set (ByVal value  as Decimal )
		_CNtDol = value
	End Set
End Property

Public Property CNtNum()  as String
	Get
		Return _CNtNum
	End Get
	Set (ByVal value  as String )
		_CNtNum = value
	End Set
End Property

Public Property DNtDol()  as Decimal
	Get
		Return _DNtDol
	End Get
	Set (ByVal value  as Decimal )
		_DNtDol = value
	End Set
End Property

Public Property DNtNum()  as String
	Get
		Return _DNtNum
	End Get
	Set (ByVal value  as String )
		_DNtNum = value
	End Set
End Property

Public Property ENtDol()  as Decimal
	Get
		Return _ENtDol
	End Get
	Set (ByVal value  as Decimal )
		_ENtDol = value
	End Set
End Property

Public Property ENtNum()  as String
	Get
		Return _ENtNum
	End Get
	Set (ByVal value  as String )
		_ENtNum = value
	End Set
End Property

Public Property FlxNtDol()  as Decimal
	Get
		Return _FlxNtDol
	End Get
	Set (ByVal value  as Decimal )
		_FlxNtDol = value
	End Set
End Property

Public Property FlxNtNum()  as String
	Get
		Return _FlxNtNum
	End Get
	Set (ByVal value  as String )
		_FlxNtNum = value
	End Set
End Property

Public Property DepNtDol()  as Decimal
	Get
		Return _DepNtDol
	End Get
	Set (ByVal value  as Decimal )
		_DepNtDol = value
	End Set
End Property

Public Property DepNtNum()  as String
	Get
		Return _DepNtNum
	End Get
	Set (ByVal value  as String )
		_DepNtNum = value
	End Set
End Property

Public Property Pen1aDol()  as Decimal
	Get
		Return _Pen1aDol
	End Get
	Set (ByVal value  as Decimal )
		_Pen1aDol = value
	End Set
End Property

Public Property Pen1aNum()  as String
	Get
		Return _Pen1aNum
	End Get
	Set (ByVal value  as String )
		_Pen1aNum = value
	End Set
End Property

Public Property Pen1bDol()  as Decimal
	Get
		Return _Pen1bDol
	End Get
	Set (ByVal value  as Decimal )
		_Pen1bDol = value
	End Set
End Property

Public Property Pen1bNum()  as String
	Get
		Return _Pen1bNum
	End Get
	Set (ByVal value  as String )
		_Pen1bNum = value
	End Set
End Property

Public Property Pen2aDol()  as Decimal
	Get
		Return _Pen2aDol
	End Get
	Set (ByVal value  as Decimal )
		_Pen2aDol = value
	End Set
End Property

Public Property Pen2aNum()  as String
	Get
		Return _Pen2aNum
	End Get
	Set (ByVal value  as String )
		_Pen2aNum = value
	End Set
End Property

Public Property Pen2bDol()  as Decimal
	Get
		Return _Pen2bDol
	End Get
	Set (ByVal value  as Decimal )
		_Pen2bDol = value
	End Set
End Property

Public Property Pen2bNum()  as String
	Get
		Return _Pen2bNum
	End Get
	Set (ByVal value  as String )
		_Pen2bNum = value
	End Set
End Property

Public Property Save1Ded()  as Decimal
	Get
		Return _Save1Ded
	End Get
	Set (ByVal value  as Decimal )
		_Save1Ded = value
	End Set
End Property

Public Property Save2Ded()  as Decimal
	Get
		Return _Save2Ded
	End Get
	Set (ByVal value  as Decimal )
		_Save2Ded = value
	End Set
End Property

Public Property Save3Ded()  as Decimal
	Get
		Return _Save3Ded
	End Get
	Set (ByVal value  as Decimal )
		_Save3Ded = value
	End Set
End Property

Public Property Dduct1Dol()  as Decimal
	Get
		Return _Dduct1Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct1Dol = value
	End Set
End Property

Public Property Dduct1Num()  as String
	Get
		Return _Dduct1Num
	End Get
	Set (ByVal value  as String )
		_Dduct1Num = value
	End Set
End Property

Public Property Dduct2Dol()  as Decimal
	Get
		Return _Dduct2Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct2Dol = value
	End Set
End Property

Public Property Dduct2Num()  as String
	Get
		Return _Dduct2Num
	End Get
	Set (ByVal value  as String )
		_Dduct2Num = value
	End Set
End Property

Public Property Dduct3Dol()  as Decimal
	Get
		Return _Dduct3Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct3Dol = value
	End Set
End Property

Public Property Dduct3Num()  as String
	Get
		Return _Dduct3Num
	End Get
	Set (ByVal value  as String )
		_Dduct3Num = value
	End Set
End Property

Public Property Dduct4Dol()  as Decimal
	Get
		Return _Dduct4Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct4Dol = value
	End Set
End Property

Public Property Dduct4Num()  as String
	Get
		Return _Dduct4Num
	End Get
	Set (ByVal value  as String )
		_Dduct4Num = value
	End Set
End Property

Public Property Dduct5Dol()  as Decimal
	Get
		Return _Dduct5Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct5Dol = value
	End Set
End Property

Public Property Dduct5Num()  as String
	Get
		Return _Dduct5Num
	End Get
	Set (ByVal value  as String )
		_Dduct5Num = value
	End Set
End Property

Public Property Dduct6Dol()  as Decimal
	Get
		Return _Dduct6Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct6Dol = value
	End Set
End Property

Public Property Dduct6Num()  as String
	Get
		Return _Dduct6Num
	End Get
	Set (ByVal value  as String )
		_Dduct6Num = value
	End Set
End Property

Public Property Dduct7Dol()  as Decimal
	Get
		Return _Dduct7Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct7Dol = value
	End Set
End Property

Public Property Dduct7Num()  as String
	Get
		Return _Dduct7Num
	End Get
	Set (ByVal value  as String )
		_Dduct7Num = value
	End Set
End Property

Public Property Dduct8Dol()  as Decimal
	Get
		Return _Dduct8Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct8Dol = value
	End Set
End Property

Public Property Dduct8Num()  as String
	Get
		Return _Dduct8Num
	End Get
	Set (ByVal value  as String )
		_Dduct8Num = value
	End Set
End Property

Public Property Dduct9Dol()  as Decimal
	Get
		Return _Dduct9Dol
	End Get
	Set (ByVal value  as Decimal )
		_Dduct9Dol = value
	End Set
End Property

Public Property Dduct9Num()  as String
	Get
		Return _Dduct9Num
	End Get
	Set (ByVal value  as String )
		_Dduct9Num = value
	End Set
End Property

Public Property Misc1Dol()  as Decimal
	Get
		Return _Misc1Dol
	End Get
	Set (ByVal value  as Decimal )
		_Misc1Dol = value
	End Set
End Property

Public Property Misc1Num()  as String
	Get
		Return _Misc1Num
	End Get
	Set (ByVal value  as String )
		_Misc1Num = value
	End Set
End Property

Public Property Misc2Dol()  as Decimal
	Get
		Return _Misc2Dol
	End Get
	Set (ByVal value  as Decimal )
		_Misc2Dol = value
	End Set
End Property

Public Property Misc2Num()  as String
	Get
		Return _Misc2Num
	End Get
	Set (ByVal value  as String )
		_Misc2Num = value
	End Set
End Property

Public Property GlPost()  as String
	Get
		Return _GlPost
	End Get
	Set (ByVal value  as String )
		_GlPost = value
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

Public Property Recon()  as String
	Get
		Return _Recon
	End Get
	Set (ByVal value  as String )
		_Recon = value
	End Set
End Property

Public Property RDate()  as Date
	Get
		Return _RDate
	End Get
	Set (ByVal value  as Date )
		_RDate = value
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

Public Property Agency()  as Integer
	Get
		Return _Agency
	End Get
	Set (ByVal value  as Integer )
		_Agency = value
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

Public Property AddFwt()  as Decimal
	Get
		Return _AddFwt
	End Get
	Set (ByVal value  as Decimal )
		_AddFwt = value
	End Set
End Property

Public Property AddSwt()  as Decimal
	Get
		Return _AddSwt
	End Get
	Set (ByVal value  as Decimal )
		_AddSwt = value
	End Set
End Property

Public Property State1Code()  as String
	Get
		Return _State1Code
	End Get
	Set (ByVal value  as String )
		_State1Code = value
	End Set
End Property

Public Property State2Code()  as String
	Get
		Return _State2Code
	End Get
	Set (ByVal value  as String )
		_State2Code = value
	End Set
End Property

Public Property Save1Num()  as String
	Get
		Return _Save1Num
	End Get
	Set (ByVal value  as String )
		_Save1Num = value
	End Set
End Property

Public Property Save2Num()  as String
	Get
		Return _Save2Num
	End Get
	Set (ByVal value  as String )
		_Save2Num = value
	End Set
End Property

Public Property Save3Num()  as String
	Get
		Return _Save3Num
	End Get
	Set (ByVal value  as String )
		_Save3Num = value
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

Public Property TdiTax()  as Decimal
	Get
		Return _TdiTax
	End Get
	Set (ByVal value  as Decimal )
		_TdiTax = value
	End Set
End Property

Public Property DdepSav1()  as String
	Get
		Return _DdepSav1
	End Get
	Set (ByVal value  as String )
		_DdepSav1 = value
	End Set
End Property

Public Property DdepSav2()  as String
	Get
		Return _DdepSav2
	End Get
	Set (ByVal value  as String )
		_DdepSav2 = value
	End Set
End Property

Public Property DdepSav3()  as String
	Get
		Return _DdepSav3
	End Get
	Set (ByVal value  as String )
		_DdepSav3 = value
	End Set
End Property

Public Property NoPayHrs()  as Decimal
	Get
		Return _NoPayHrs
	End Get
	Set (ByVal value  as Decimal )
		_NoPayHrs = value
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


Public ReadOnly Property eeckstubColumnNames() as string
		Get 
	              	              	              return "([chk_num] , [chk_date] , [chk_dirdep] , [pay_num] , [name_key] , [screen_nam] , [dept_num] , [slot_num] , [loc_num] , [cost_num] , [title_num] , [pay_freq] , [ded_dfq] , [fwt_exmts] , [swt_exmts] , [blend_ovt] , [reg_hrs] , [reg_dol] , [ovt_hrs] , [ovt_dol] , [vac_hrs] , [vac_dol] , [sick_hrs] , [sick_dol] , [hol_hrs] , [hol_dol] , [pers_hrs] , [pers_dol] , [other_pay] , [full_gross] , [fed_gross] , [fed_tax] , [fica_gross] , [fica_tax] , [med_gross] , [med_tax] , [state1_gross] , [state1_tax] , [state2_gross] , [state2_tax] , [aeic_amt] , [net_pay] , [a_nt_dol] , [a_nt_num] , [b_nt_dol] , [b_nt_num] , [c_nt_dol] , [c_nt_num] , [d_nt_dol] , [d_nt_num] , [e_nt_dol] , [e_nt_num] , [flx_nt_dol] , [flx_nt_num] , [dep_nt_dol] , [dep_nt_num] , [pen1a_dol] , [pen1a_num] , [pen1b_dol] , [pen1b_num] , [pen2a_dol] , [pen2a_num] , [pen2b_dol] , [pen2b_num] , [save1_ded] , [save2_ded] , [save3_ded] , [dduct1_dol] , [dduct1_num] , [dduct2_dol] , [dduct2_num] , [dduct3_dol] , [dduct3_num] , [dduct4_dol] , [dduct4_num] , [dduct5_dol] , [dduct5_num] , [dduct6_dol] , [dduct6_num] , [dduct7_dol] , [dduct7_num] , [dduct8_dol] , [dduct8_num] , [dduct9_dol] , [dduct9_num] , [misc1_dol] , [misc1_num] , [misc2_dol] , [misc2_num] , [gl_post] , [encum_date] , [recon] , [r_date] , [void] , [agency] , [dflag] , [add_fwt] , [add_swt] , [state1_code] , [state2_code] , [save1_num] , [save2_num] , [save3_num] , [entry_num] , [tdi_Tax] , [ddep_sav1] , [ddep_sav2] , [ddep_sav3] , [no_pay_hrs] , [sort_name] , [jrnl_num] , [jrnl_line] )"
		End Get
End Property

Public ReadOnly Property eeckstubColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} , {43} , {44} , {45} , {46} , {47} , {48} , {49} , {50} , {51} , {52} , {53} , {54} , {55} , {56} , {57} , {58} , {59} , {60} , {61} , {62} , {63} , {64} , {65} , {66} , {67} , {68} , {69} , {70} , {71} , {72} , {73} , {74} , {75} , {76} , {77} , {78} , {79} , {80} , {81} , {82} , {83} , {84} , {85} , {86} , {87} , {88} , {89} , {90} , {91} , {92} , {93} , {94} , {95} , {96} , {97} , {98} , {99} , {100} , {101} , {102} , {103} , {104} , {105} , {106} , {107} , {108} , {109} , {110} , {111} )"  _  
	 , (_ChkNum.tostring) _ 
	 , database.stringparam(_ChkDate.toshortdatestring) _ 
	 , database.stringparam(_ChkDirdep.tostring) _ 
	 , (_PayNum.tostring) _ 
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_DeptNum.tostring) _ 
	 , database.stringparam(_SlotNum.tostring) _ 
	 , database.stringparam(_LocNum.tostring) _ 
	 , database.stringparam(_CostNum.tostring) _ 
	 , database.stringparam(_TitleNum.tostring) _ 
	 , database.stringparam(_PayFreq.tostring) _ 
	 , database.stringparam(_DedDfq.tostring) _ 
	 , (_FwtExmts.tostring) _ 
	 , (_SwtExmts.tostring) _ 
	 , (_BlendOvt.tostring) _ 
	 , (_RegHrs.tostring) _ 
	 , (_RegDol.tostring) _ 
	 , (_OvtHrs.tostring) _ 
	 , (_OvtDol.tostring) _ 
	 , (_VacHrs.tostring) _ 
	 , (_VacDol.tostring) _ 
	 , (_SickHrs.tostring) _ 
	 , (_SickDol.tostring) _ 
	 , (_HolHrs.tostring) _ 
	 , (_HolDol.tostring) _ 
	 , (_PersHrs.tostring) _ 
	 , (_PersDol.tostring) _ 
	 , (_OtherPay.tostring) _ 
	 , (_FullGross.tostring) _ 
	 , (_FedGross.tostring) _ 
	 , (_FedTax.tostring) _ 
	 , (_FicaGross.tostring) _ 
	 , (_FicaTax.tostring) _ 
	 , (_MedGross.tostring) _ 
	 , (_MedTax.tostring) _ 
	 , (_State1Gross.tostring) _ 
	 , (_State1Tax.tostring) _ 
	 , (_State2Gross.tostring) _ 
	 , (_State2Tax.tostring) _ 
	 , (_AeicAmt.tostring) _ 
	 , (_NetPay.tostring) _ 
	 , (_ANtDol.tostring) _ 
	 , database.stringparam(_ANtNum.tostring) _ 
	 , (_BNtDol.tostring) _ 
	 , database.stringparam(_BNtNum.tostring) _ 
	 , (_CNtDol.tostring) _ 
	 , database.stringparam(_CNtNum.tostring) _ 
	 , (_DNtDol.tostring) _ 
	 , database.stringparam(_DNtNum.tostring) _ 
	 , (_ENtDol.tostring) _ 
	 , database.stringparam(_ENtNum.tostring) _ 
	 , (_FlxNtDol.tostring) _ 
	 , database.stringparam(_FlxNtNum.tostring) _ 
	 , (_DepNtDol.tostring) _ 
	 , database.stringparam(_DepNtNum.tostring) _ 
	 , (_Pen1aDol.tostring) _ 
	 , database.stringparam(_Pen1aNum.tostring) _ 
	 , (_Pen1bDol.tostring) _ 
	 , database.stringparam(_Pen1bNum.tostring) _ 
	 , (_Pen2aDol.tostring) _ 
	 , database.stringparam(_Pen2aNum.tostring) _ 
	 , (_Pen2bDol.tostring) _ 
	 , database.stringparam(_Pen2bNum.tostring) _ 
	 , (_Save1Ded.tostring) _ 
	 , (_Save2Ded.tostring) _ 
	 , (_Save3Ded.tostring) _ 
	 , (_Dduct1Dol.tostring) _ 
	 , database.stringparam(_Dduct1Num.tostring) _ 
	 , (_Dduct2Dol.tostring) _ 
	 , database.stringparam(_Dduct2Num.tostring) _ 
	 , (_Dduct3Dol.tostring) _ 
	 , database.stringparam(_Dduct3Num.tostring) _ 
	 , (_Dduct4Dol.tostring) _ 
	 , database.stringparam(_Dduct4Num.tostring) _ 
	 , (_Dduct5Dol.tostring) _ 
	 , database.stringparam(_Dduct5Num.tostring) _ 
	 , (_Dduct6Dol.tostring) _ 
	 , database.stringparam(_Dduct6Num.tostring) _ 
	 , (_Dduct7Dol.tostring) _ 
	 , database.stringparam(_Dduct7Num.tostring) _ 
	 , (_Dduct8Dol.tostring) _ 
	 , database.stringparam(_Dduct8Num.tostring) _ 
	 , (_Dduct9Dol.tostring) _ 
	 , database.stringparam(_Dduct9Num.tostring) _ 
	 , (_Misc1Dol.tostring) _ 
	 , database.stringparam(_Misc1Num.tostring) _ 
	 , (_Misc2Dol.tostring) _ 
	 , database.stringparam(_Misc2Num.tostring) _ 
	 , database.stringparam(_GlPost.tostring) _ 
	 , database.stringparam(_EncumDate.toshortdatestring) _ 
	 , database.stringparam(_Recon.tostring) _ 
	 , database.stringparam(_RDate.toshortdatestring) _ 
	 , database.stringparam(_Void.tostring) _ 
	 , (_Agency.tostring) _ 
	 , database.stringparam(_Dflag.tostring) _ 
	 , (_AddFwt.tostring) _ 
	 , (_AddSwt.tostring) _ 
	 , database.stringparam(_State1Code.tostring) _ 
	 , database.stringparam(_State2Code.tostring) _ 
	 , database.stringparam(_Save1Num.tostring) _ 
	 , database.stringparam(_Save2Num.tostring) _ 
	 , database.stringparam(_Save3Num.tostring) _ 
	 , (_EntryNum.tostring) _ 
	 , (_TdiTax.tostring) _ 
	 , database.stringparam(_DdepSav1.tostring) _ 
	 , database.stringparam(_DdepSav2.tostring) _ 
	 , database.stringparam(_DdepSav3.tostring) _ 
	 , (_NoPayHrs.tostring) _ 
	 , database.stringparam(_SortName.tostring) _ 
	 , (_JrnlNum.tostring) _ 
	 , (_JrnlLine.tostring) _ 
)
		End Get
End Property
End Class
