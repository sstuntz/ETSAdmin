Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class medopnData
	Private _NameKey as String
	Private _ScreenNam as String
	Private _SortName as String
	Private _RecordId as String
	Private _PriorAuth as String
	Private _ProcNum as String
	Private _ProvNum as String
	Private _ServpNum as String
	Private _ServpNam as String
	Private _PacctNum as String
	Private _RefpNum as String
	Private _RefpName as String
	Private _PlaceServ as String
	Private _AccInd as String
	Private _SrcInd as String
	Private _OtherIns as String
	Private _PrimDiag as String
	Private _SecndDiag as String
	Private _TypeAcc as String
	Private _DateAcc as Date
	Private _FuncLevel as String
	Private _DisD as Date
	Private _PStat as String
	Private _MedNum as String
	Private _Sex as String
	Private _Dob as Date
	Private _ProcCode as String
	Private _ProcDesc as String
	Private _UsualFee as Decimal
	Private _LineNum as String
	Private _FromDate as Date
	Private _ToDate as Date
	Private _ProcCodeM as String
	Private _TreatInd as String
	Private _EmerServ as String
	Private _FamPlan as String
	Private _AttUnits as Decimal
	Private _DolBilled as Decimal
	Private _NumBilled as Integer
	Private _DolNetBill as Decimal
	Private _OtherAmt as Decimal
	Private _Paper as String
	Private _FtcnlNum as String
	Private _TcnNum as String
	Private _BillDate as Date
	Private _RemitDate as Date
	Private _DolPaid as Decimal
	Private _BalDue as Decimal
	Private _Rebilled as String
	Private _BatchNum as Integer
	Private _BatchNumLine as Integer
	Private _ContractKey as String
	Private _EntryDate as Date
	Private _DrAcctNu as String
	Private _CrAcctNu as String
	Private _Void as String
	Private _Dflag as String
	Private _Agency as Integer

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

Public Property RecordId()  as String
	Get
		Return _RecordId
	End Get
	Set (ByVal value  as String )
		_RecordId = value
	End Set
End Property

Public Property PriorAuth()  as String
	Get
		Return _PriorAuth
	End Get
	Set (ByVal value  as String )
		_PriorAuth = value
	End Set
End Property

Public Property ProcNum()  as String
	Get
		Return _ProcNum
	End Get
	Set (ByVal value  as String )
		_ProcNum = value
	End Set
End Property

Public Property ProvNum()  as String
	Get
		Return _ProvNum
	End Get
	Set (ByVal value  as String )
		_ProvNum = value
	End Set
End Property

Public Property ServpNum()  as String
	Get
		Return _ServpNum
	End Get
	Set (ByVal value  as String )
		_ServpNum = value
	End Set
End Property

Public Property ServpNam()  as String
	Get
		Return _ServpNam
	End Get
	Set (ByVal value  as String )
		_ServpNam = value
	End Set
End Property

Public Property PacctNum()  as String
	Get
		Return _PacctNum
	End Get
	Set (ByVal value  as String )
		_PacctNum = value
	End Set
End Property

Public Property RefpNum()  as String
	Get
		Return _RefpNum
	End Get
	Set (ByVal value  as String )
		_RefpNum = value
	End Set
End Property

Public Property RefpName()  as String
	Get
		Return _RefpName
	End Get
	Set (ByVal value  as String )
		_RefpName = value
	End Set
End Property

Public Property PlaceServ()  as String
	Get
		Return _PlaceServ
	End Get
	Set (ByVal value  as String )
		_PlaceServ = value
	End Set
End Property

Public Property AccInd()  as String
	Get
		Return _AccInd
	End Get
	Set (ByVal value  as String )
		_AccInd = value
	End Set
End Property

Public Property SrcInd()  as String
	Get
		Return _SrcInd
	End Get
	Set (ByVal value  as String )
		_SrcInd = value
	End Set
End Property

Public Property OtherIns()  as String
	Get
		Return _OtherIns
	End Get
	Set (ByVal value  as String )
		_OtherIns = value
	End Set
End Property

Public Property PrimDiag()  as String
	Get
		Return _PrimDiag
	End Get
	Set (ByVal value  as String )
		_PrimDiag = value
	End Set
End Property

Public Property SecndDiag()  as String
	Get
		Return _SecndDiag
	End Get
	Set (ByVal value  as String )
		_SecndDiag = value
	End Set
End Property

Public Property TypeAcc()  as String
	Get
		Return _TypeAcc
	End Get
	Set (ByVal value  as String )
		_TypeAcc = value
	End Set
End Property

Public Property DateAcc()  as Date
	Get
		Return _DateAcc
	End Get
	Set (ByVal value  as Date )
		_DateAcc = value
	End Set
End Property

Public Property FuncLevel()  as String
	Get
		Return _FuncLevel
	End Get
	Set (ByVal value  as String )
		_FuncLevel = value
	End Set
End Property

Public Property DisD()  as Date
	Get
		Return _DisD
	End Get
	Set (ByVal value  as Date )
		_DisD = value
	End Set
End Property

Public Property PStat()  as String
	Get
		Return _PStat
	End Get
	Set (ByVal value  as String )
		_PStat = value
	End Set
End Property

Public Property MedNum()  as String
	Get
		Return _MedNum
	End Get
	Set (ByVal value  as String )
		_MedNum = value
	End Set
End Property

Public Property Sex()  as String
	Get
		Return _Sex
	End Get
	Set (ByVal value  as String )
		_Sex = value
	End Set
End Property

Public Property Dob()  as Date
	Get
		Return _Dob
	End Get
	Set (ByVal value  as Date )
		_Dob = value
	End Set
End Property

Public Property ProcCode()  as String
	Get
		Return _ProcCode
	End Get
	Set (ByVal value  as String )
		_ProcCode = value
	End Set
End Property

Public Property ProcDesc()  as String
	Get
		Return _ProcDesc
	End Get
	Set (ByVal value  as String )
		_ProcDesc = value
	End Set
End Property

Public Property UsualFee()  as Decimal
	Get
		Return _UsualFee
	End Get
	Set (ByVal value  as Decimal )
		_UsualFee = value
	End Set
End Property

Public Property LineNum()  as String
	Get
		Return _LineNum
	End Get
	Set (ByVal value  as String )
		_LineNum = value
	End Set
End Property

Public Property FromDate()  as Date
	Get
		Return _FromDate
	End Get
	Set (ByVal value  as Date )
		_FromDate = value
	End Set
End Property

Public Property ToDate()  as Date
	Get
		Return _ToDate
	End Get
	Set (ByVal value  as Date )
		_ToDate = value
	End Set
End Property

Public Property ProcCodeM()  as String
	Get
		Return _ProcCodeM
	End Get
	Set (ByVal value  as String )
		_ProcCodeM = value
	End Set
End Property

Public Property TreatInd()  as String
	Get
		Return _TreatInd
	End Get
	Set (ByVal value  as String )
		_TreatInd = value
	End Set
End Property

Public Property EmerServ()  as String
	Get
		Return _EmerServ
	End Get
	Set (ByVal value  as String )
		_EmerServ = value
	End Set
End Property

Public Property FamPlan()  as String
	Get
		Return _FamPlan
	End Get
	Set (ByVal value  as String )
		_FamPlan = value
	End Set
End Property

Public Property AttUnits()  as Decimal
	Get
		Return _AttUnits
	End Get
	Set (ByVal value  as Decimal )
		_AttUnits = value
	End Set
End Property

Public Property DolBilled()  as Decimal
	Get
		Return _DolBilled
	End Get
	Set (ByVal value  as Decimal )
		_DolBilled = value
	End Set
End Property

Public Property NumBilled()  as Integer
	Get
		Return _NumBilled
	End Get
	Set (ByVal value  as Integer )
		_NumBilled = value
	End Set
End Property

Public Property DolNetBill()  as Decimal
	Get
		Return _DolNetBill
	End Get
	Set (ByVal value  as Decimal )
		_DolNetBill = value
	End Set
End Property

Public Property OtherAmt()  as Decimal
	Get
		Return _OtherAmt
	End Get
	Set (ByVal value  as Decimal )
		_OtherAmt = value
	End Set
End Property

Public Property Paper()  as String
	Get
		Return _Paper
	End Get
	Set (ByVal value  as String )
		_Paper = value
	End Set
End Property

Public Property FtcnlNum()  as String
	Get
		Return _FtcnlNum
	End Get
	Set (ByVal value  as String )
		_FtcnlNum = value
	End Set
End Property

Public Property TcnNum()  as String
	Get
		Return _TcnNum
	End Get
	Set (ByVal value  as String )
		_TcnNum = value
	End Set
End Property

Public Property BillDate()  as Date
	Get
		Return _BillDate
	End Get
	Set (ByVal value  as Date )
		_BillDate = value
	End Set
End Property

Public Property RemitDate()  as Date
	Get
		Return _RemitDate
	End Get
	Set (ByVal value  as Date )
		_RemitDate = value
	End Set
End Property

Public Property DolPaid()  as Decimal
	Get
		Return _DolPaid
	End Get
	Set (ByVal value  as Decimal )
		_DolPaid = value
	End Set
End Property

Public Property BalDue()  as Decimal
	Get
		Return _BalDue
	End Get
	Set (ByVal value  as Decimal )
		_BalDue = value
	End Set
End Property

Public Property Rebilled()  as String
	Get
		Return _Rebilled
	End Get
	Set (ByVal value  as String )
		_Rebilled = value
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

Public Property BatchNumLine()  as Integer
	Get
		Return _BatchNumLine
	End Get
	Set (ByVal value  as Integer )
		_BatchNumLine = value
	End Set
End Property

Public Property ContractKey()  as String
	Get
		Return _ContractKey
	End Get
	Set (ByVal value  as String )
		_ContractKey = value
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

Public Property Void()  as String
	Get
		Return _Void
	End Get
	Set (ByVal value  as String )
		_Void = value
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


Public ReadOnly Property medopnColumnNames() as string
		Get 
	              	              	              return "([NameKey] , [ScreenNam] , [SortName] , [RecordId] , [PriorAuth] , [ProcNum] , [ProvNum] , [ServpNum] , [ServpNam] , [PacctNum] , [RefpNum] , [RefpName] , [PlaceServ] , [AccInd] , [SrcInd] , [OtherIns] , [PrimDiag] , [SecndDiag] , [TypeAcc] , [DateAcc] , [FuncLevel] , [DisD] , [PStat] , [MedNum] , [Sex] , [Dob] , [ProcCode] , [ProcDesc] , [UsualFee] , [LineNum] , [FromDate] , [ToDate] , [ProcCodeM] , [TreatInd] , [EmerServ] , [FamPlan] , [AttUnits] , [DolBilled] , [NumBilled] , [DolNetBill] , [OtherAmt] , [Paper] , [FtcnlNum] , [TcnNum] , [BillDate] , [RemitDate] , [DolPaid] , [BalDue] , [Rebilled] , [BatchNum] , [BatchNumLine] , [ContractKey] , [EntryDate] , [DrAcctNu] , [CrAcctNu] , [Void] , [Dflag] , [Agency] )"
		End Get
End Property

Public ReadOnly Property medopnColumnData() as string
		Get 
	              	              	              return string.format("({0} , {1} , {2} , {3} , {4} , {5} , {6} , {7} , {8} , {9} , {10} , {11} , {12} , {13} , {14} , {15} , {16} , {17} , {18} , {19} , {20} , {21} , {22} , {23} , {24} , {25} , {26} , {27} , {28} , {29} , {30} , {31} , {32} , {33} , {34} , {35} , {36} , {37} , {38} , {39} , {40} , {41} , {42} , {43} , {44} , {45} , {46} , {47} , {48} , {49} , {50} , {51} , {52} , {53} , {54} , {55} , {56} , {57} )"  _  
	 , database.stringparam(_NameKey.tostring) _ 
	 , database.stringparam(_ScreenNam.tostring) _ 
	 , database.stringparam(_SortName.tostring) _ 
	 , database.stringparam(_RecordId.tostring) _ 
	 , database.stringparam(_PriorAuth.tostring) _ 
	 , database.stringparam(_ProcNum.tostring) _ 
	 , database.stringparam(_ProvNum.tostring) _ 
	 , database.stringparam(_ServpNum.tostring) _ 
	 , database.stringparam(_ServpNam.tostring) _ 
	 , database.stringparam(_PacctNum.tostring) _ 
	 , database.stringparam(_RefpNum.tostring) _ 
	 , database.stringparam(_RefpName.tostring) _ 
	 , database.stringparam(_PlaceServ.tostring) _ 
	 , database.stringparam(_AccInd.tostring) _ 
	 , database.stringparam(_SrcInd.tostring) _ 
	 , database.stringparam(_OtherIns.tostring) _ 
	 , database.stringparam(_PrimDiag.tostring) _ 
	 , database.stringparam(_SecndDiag.tostring) _ 
	 , database.stringparam(_TypeAcc.tostring) _ 
	 , database.stringparam(_DateAcc.toshortdatestring) _ 
	 , database.stringparam(_FuncLevel.tostring) _ 
	 , database.stringparam(_DisD.toshortdatestring) _ 
	 , database.stringparam(_PStat.tostring) _ 
	 , database.stringparam(_MedNum.tostring) _ 
	 , database.stringparam(_Sex.tostring) _ 
	 , database.stringparam(_Dob.toshortdatestring) _ 
	 , database.stringparam(_ProcCode.tostring) _ 
	 , database.stringparam(_ProcDesc.tostring) _ 
	 , (_UsualFee.tostring) _ 
	 , database.stringparam(_LineNum.tostring) _ 
	 , database.stringparam(_FromDate.toshortdatestring) _ 
	 , database.stringparam(_ToDate.toshortdatestring) _ 
	 , database.stringparam(_ProcCodeM.tostring) _ 
	 , database.stringparam(_TreatInd.tostring) _ 
	 , database.stringparam(_EmerServ.tostring) _ 
	 , database.stringparam(_FamPlan.tostring) _ 
	 , (_AttUnits.tostring) _ 
	 , (_DolBilled.tostring) _ 
	 , (_NumBilled.tostring) _ 
	 , (_DolNetBill.tostring) _ 
	 , (_OtherAmt.tostring) _ 
	 , database.stringparam(_Paper.tostring) _ 
	 , database.stringparam(_FtcnlNum.tostring) _ 
	 , database.stringparam(_TcnNum.tostring) _ 
	 , database.stringparam(_BillDate.toshortdatestring) _ 
	 , database.stringparam(_RemitDate.toshortdatestring) _ 
	 , (_DolPaid.tostring) _ 
	 , (_BalDue.tostring) _ 
	 , database.stringparam(_Rebilled.tostring) _ 
	 , (_BatchNum.tostring) _ 
	 , (_BatchNumLine.tostring) _ 
	 , database.stringparam(_ContractKey.tostring) _ 
	 , database.stringparam(_EntryDate.toshortdatestring) _ 
	 , database.stringparam(_DrAcctNu.tostring) _ 
	 , database.stringparam(_CrAcctNu.tostring) _ 
	 , database.stringparam(_Void.tostring) _ 
	 , database.stringparam(_Dflag.tostring) _ 
	 , (_Agency.tostring) _ 
)
		End Get
End Property
End Class
