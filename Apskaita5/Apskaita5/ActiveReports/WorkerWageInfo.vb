Imports ApskaitaObjects.Workers
Namespace ActiveReports

    <Serializable()> _
    Public Class WorkerWageInfo
        Inherits ReadOnlyBase(Of WorkerWageInfo)

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _Year As Integer = 0
        Private _Month As Integer = 0
        Private _RateSODRAEmployee As Double = 0
        Private _RateSODRAEmployer As Double = 0
        Private _RatePSDEmployee As Double = 0
        Private _RatePSDEmployer As Double = 0
        Private _RateGuaranteeFund As Double = 0
        Private _RateGPM As Double = 0
        Private _RateHR As Double = 0
        Private _RateSC As Double = 0
        Private _RateON As Double = 0
        Private _RateSickLeave As Double = 0
        Private _NPDFormula As String = ""
        Private _WorkLoad As Double = 0
        Private _ApplicableVDUHourly As Double = 0
        Private _ApplicableVDUDaily As Double = 0
        Private _NormalHoursWorked As Double = 0
        Private _HRHoursWorked As Double = 0
        Private _ONHoursWorked As Double = 0
        Private _SCHoursWorked As Double = 0
        Private _TotalHoursWorked As Double = 0
        Private _TruancyHours As Double = 0
        Private _TotalDaysWorked As Integer = 0
        Private _HolidayWD As Integer = 0
        Private _HolidayRD As Integer = 0
        Private _SickDays As Integer = 0
        Private _StandartHours As Double = 0
        Private _StandartDays As Integer = 0
        Private _ConventionalWage As Double = 0
        Private _WageType As WageType = Workers.WageType.Position
        Private _WageTypeHumanReadable As String = ConvertEnumHumanReadable(Workers.WageType.Position)
        Private _ConventionalExtraPay As Double = 0
        Private _BonusPay As Double = 0
        Private _BonusType As BonusType = 0
        Private _OtherPayRelatedToWork As Double = 0
        Private _OtherPayNotRelatedToWork As Double = 0
        Private _PayOutWage As Double = 0
        Private _PayOutExtraPay As Double = 0
        Private _ActualHourlyPay As Double = 0
        Private _PayOutHR As Double = 0
        Private _PayOutON As Double = 0
        Private _PayOutSC As Double = 0
        Private _PayOutSickLeave As Double = 0
        Private _AnnualWorkingDaysRatio As Double = 0
        Private _UnusedHolidayDaysForCompensation As Double = 0
        Private _PayOutHoliday As Double = 0
        Private _PayOutUnusedHolidayCompensation As Double = 0
        Private _PayOutRedundancyPay As Double = 0
        Private _PayOutTotal As Double = 0
        Private _DeductionGPM As Double = 0
        Private _DeductionPSD As Double = 0
        Private _DeductionPSDSickLeave As Double = 0
        Private _DeductionSODRA As Double = 0
        Private _DeductionImprest As Double = 0
        Private _ImprestPending As Double = 0
        Private _DeductionOtherApplicable As Double = 0
        Private _DeductionOther As Double = 0
        Private _ContributionSODRA As Double = 0
        Private _ContributionPSD As Double = 0
        Private _ContributionGuaranteeFund As Double = 0
        Private _PayOutTotalAfterTaxes As Double = 0
        Private _PayableTotal As Double = 0
        Private _PayOutTotalAfterDeductions As Double = 0
        Private _ApplicableNPD As Double = 0
        Private _ApplicablePNPD As Double = 0
        Private _NPD As Double = 0
        Private _PNPD As Double = 0
        Private _UsedNPD As Double = 0
        Private _OtherIncome As Double = 0
        Private _HoursForVDU As Double = 0
        Private _DaysForVDU As Integer = 0
        Private _WageForVDU As Double = 0
        Private _PayedOutTotalSum As Double = 0


        Public ReadOnly Property Year() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Year
            End Get
        End Property

        Public ReadOnly Property Month() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Month
            End Get
        End Property

        Public ReadOnly Property RateSODRAEmployee() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateSODRAEmployee)
            End Get
        End Property

        Public ReadOnly Property RateSODRAEmployer() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateSODRAEmployer)
            End Get
        End Property

        Public ReadOnly Property RatePSDEmployee() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RatePSDEmployee)
            End Get
        End Property

        Public ReadOnly Property RatePSDEmployer() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RatePSDEmployer)
            End Get
        End Property

        Public ReadOnly Property RateGuaranteeFund() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateGuaranteeFund)
            End Get
        End Property

        Public ReadOnly Property RateGPM() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateGPM)
            End Get
        End Property

        Public ReadOnly Property RateHR() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateHR)
            End Get
        End Property

        Public ReadOnly Property RateSC() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateSC)
            End Get
        End Property

        Public ReadOnly Property RateON() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateON)
            End Get
        End Property

        Public ReadOnly Property RateSickLeave() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_RateSickLeave)
            End Get
        End Property

        Public ReadOnly Property NPDFormula() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NPDFormula.Trim
            End Get
        End Property

        Public ReadOnly Property WorkLoad() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_WorkLoad, 4)
            End Get
        End Property

        Public ReadOnly Property ApplicableVDUHourly() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ApplicableVDUHourly)
            End Get
        End Property

        Public ReadOnly Property ApplicableVDUDaily() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ApplicableVDUDaily)
            End Get
        End Property

        Public ReadOnly Property NormalHoursWorked() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_NormalHoursWorked, 4)
            End Get
        End Property

        Public ReadOnly Property HRHoursWorked() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_HRHoursWorked, 4)
            End Get
        End Property

        Public ReadOnly Property ONHoursWorked() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ONHoursWorked, 4)
            End Get
        End Property

        Public ReadOnly Property SCHoursWorked() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SCHoursWorked, 4)
            End Get
        End Property

        Public ReadOnly Property TotalHoursWorked() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalHoursWorked, 4)
            End Get
        End Property

        Public ReadOnly Property TruancyHours() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TruancyHours, 4)
            End Get
        End Property

        Public ReadOnly Property TotalDaysWorked() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TotalDaysWorked
            End Get
        End Property

        Public ReadOnly Property HolidayWD() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HolidayWD
            End Get
        End Property

        Public ReadOnly Property HolidayRD() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HolidayRD
            End Get
        End Property

        Public ReadOnly Property SickDays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SickDays
            End Get
        End Property

        Public ReadOnly Property StandartHours() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_StandartHours, 4)
            End Get
        End Property

        Public ReadOnly Property StandartDays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _StandartDays
            End Get
        End Property

        Public ReadOnly Property ConventionalWage() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ConventionalWage)
            End Get
        End Property

        Public ReadOnly Property WageType() As WageType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WageType
            End Get
        End Property

        Public ReadOnly Property WageTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WageTypeHumanReadable.Trim
            End Get
        End Property

        Public ReadOnly Property ConventionalExtraPay() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ConventionalExtraPay)
            End Get
        End Property

        Public ReadOnly Property BonusPay() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BonusPay)
            End Get
        End Property

        Public ReadOnly Property BonusType() As BonusType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BonusType
            End Get
        End Property

        Public ReadOnly Property OtherPayRelatedToWork() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OtherPayRelatedToWork)
            End Get
        End Property

        Public ReadOnly Property OtherPayNotRelatedToWork() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OtherPayNotRelatedToWork)
            End Get
        End Property

        Public ReadOnly Property PayOutWage() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutWage)
            End Get
        End Property

        Public ReadOnly Property PayOutExtraPay() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutExtraPay)
            End Get
        End Property

        Public ReadOnly Property ActualHourlyPay() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ActualHourlyPay)
            End Get
        End Property

        Public ReadOnly Property PayOutHR() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutHR)
            End Get
        End Property

        Public ReadOnly Property PayOutON() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutON)
            End Get
        End Property

        Public ReadOnly Property PayOutSC() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutSC)
            End Get
        End Property

        Public ReadOnly Property PayOutSickLeave() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutSickLeave)
            End Get
        End Property

        Public ReadOnly Property AnnualWorkingDaysRatio() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AnnualWorkingDaysRatio, 4)
            End Get
        End Property

        Public ReadOnly Property UnusedHolidayDaysForCompensation() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnusedHolidayDaysForCompensation, 4)
            End Get
        End Property

        Public ReadOnly Property PayOutHoliday() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutHoliday)
            End Get
        End Property

        Public ReadOnly Property PayOutUnusedHolidayCompensation() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutUnusedHolidayCompensation)
            End Get
        End Property

        Public ReadOnly Property PayOutRedundancyPay() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutRedundancyPay)
            End Get
        End Property

        Public ReadOnly Property PayOutTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutTotal)
            End Get
        End Property

        Public ReadOnly Property DeductionGPM() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionGPM)
            End Get
        End Property

        Public ReadOnly Property DeductionPSD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionPSD)
            End Get
        End Property

        Public ReadOnly Property DeductionPSDSickLeave() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionPSDSickLeave)
            End Get
        End Property

        Public ReadOnly Property DeductionSODRA() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionSODRA)
            End Get
        End Property

        Public ReadOnly Property DeductionImprest() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionImprest)
            End Get
        End Property

        Public ReadOnly Property ImprestPending() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ImprestPending)
            End Get
        End Property

        Public ReadOnly Property DeductionOtherApplicable() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionOtherApplicable)
            End Get
        End Property

        Public ReadOnly Property DeductionOther() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionOther)
            End Get
        End Property

        Public ReadOnly Property ContributionSODRA() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ContributionSODRA)
            End Get
        End Property

        Public ReadOnly Property ContributionPSD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ContributionPSD)
            End Get
        End Property

        Public ReadOnly Property ContributionGuaranteeFund() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ContributionGuaranteeFund)
            End Get
        End Property

        Public ReadOnly Property PayOutTotalAfterTaxes() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutTotalAfterTaxes)
            End Get
        End Property

        Public ReadOnly Property PayableTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayableTotal)
            End Get
        End Property

        Public ReadOnly Property PayOutTotalAfterDeductions() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutTotalAfterDeductions)
            End Get
        End Property

        Public ReadOnly Property ApplicableNPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ApplicableNPD)
            End Get
        End Property

        Public ReadOnly Property ApplicablePNPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ApplicablePNPD)
            End Get
        End Property

        Public ReadOnly Property NPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_NPD)
            End Get
        End Property

        Public ReadOnly Property PNPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PNPD)
            End Get
        End Property

        Public ReadOnly Property UsedNPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UsedNPD)
            End Get
        End Property

        Public ReadOnly Property OtherIncome() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OtherIncome)
            End Get
        End Property

        Public ReadOnly Property HoursForVDU() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_HoursForVDU, 4)
            End Get
        End Property

        Public ReadOnly Property DaysForVDU() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DaysForVDU
            End Get
        End Property

        Public ReadOnly Property WageForVDU() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_WageForVDU)
            End Get
        End Property

        Public ReadOnly Property PayedOutTotalSum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayedOutTotalSum)
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return _Year.ToString & " m. " & _Month.ToString & " mėn."
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function GetWorkerWageInfo(ByVal dr As DataRow) As WorkerWageInfo
            Return New WorkerWageInfo(dr)
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal dr As DataRow)
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)

            _WorkLoad = CDblSafe(dr.Item(6), 4, 0)
            _ConventionalWage = CDblSafe(dr.Item(7), 2, 0)
            _WageType = ConvertEnumDatabaseStringCode(Of WageType)(CStrSafe(dr.Item(8)).Trim)
            _ConventionalExtraPay = CDblSafe(dr.Item(9), 2, 0)
            _ApplicableNPD = CDblSafe(dr.Item(10), 2, 0)
            _ApplicablePNPD = CDblSafe(dr.Item(11), 2, 0)
            _ImprestPending = CRound(CDblSafe(dr.Item(13), 2, 0) - CDblSafe(dr.Item(12), 2, 0))
            _UsedNPD = CDblSafe(dr.Item(14), 2, 0)
            _OtherIncome = CDblSafe(dr.Item(15), 2, 0)
            _TotalDaysWorked = CIntSafe(dr.Item(16), 0)
            _NormalHoursWorked = CDblSafe(dr.Item(17), 4, 0)
            _ONHoursWorked = CDblSafe(dr.Item(18), 4, 0)
            _HRHoursWorked = CDblSafe(dr.Item(19), 4, 0)
            _SCHoursWorked = CDblSafe(dr.Item(20), 4, 0)
            _StandartHours = CDblSafe(dr.Item(21), 4, 0)
            _StandartDays = CIntSafe(dr.Item(22), 0)
            _TruancyHours = CDblSafe(dr.Item(23), 4, 0)

            If CInt(dr.Item(24)) = 0 Then ' holidays
                _HolidayWD = CIntSafe(dr.Item(25), 0)
                _HolidayRD = CIntSafe(dr.Item(26), 0)
                _PayOutHoliday = CDblSafe(dr.Item(35), 2, 0)
            Else ' unused holiday compensation
                _UnusedHolidayDaysForCompensation = CDblSafe(dr.Item(25), 4, 0)
                _PayOutUnusedHolidayCompensation = CDblSafe(dr.Item(35), 2, 0)
                ' PayOutUnusedHolidayCompensation = UnusedHolidayDaysForCompensation 
                ' * ApplicableVDUDaily * AnnualWorkingDaysRatio
                ' ->
                ' AnnualWorkingDaysRatio = PayOutUnusedHolidayCompensation
                ' / ApplicableVDUDaily / UnusedHolidayDaysForCompensation
                _AnnualWorkingDaysRatio = CRound(CDblSafe(dr.Item(35), 2, 0) / CDblSafe(dr.Item(25), 2, 0) _
                    / CDblSafe(dr.Item(28), 4, 0), 4)
            End If

            _SickDays = CIntSafe(dr.Item(27), 0)
            _ApplicableVDUDaily = CDblSafe(dr.Item(28), 2, 0)
            _ApplicableVDUHourly = CDblSafe(dr.Item(29), 2, 0)
            _BonusPay = CDblSafe(dr.Item(30), 2, 0)
            _BonusType = ConvertEnumDatabaseStringCode(Of BonusType)(CStrSafe(dr.Item(31)))
            _OtherPayNotRelatedToWork = CDblSafe(dr.Item(32), 2, 0)
            _OtherPayRelatedToWork = CDblSafe(dr.Item(33), 2, 0)
            _PayOutRedundancyPay = CDblSafe(dr.Item(34), 2, 0)
            _DeductionOther = CDblSafe(dr.Item(36), 2, 0)
            _DeductionOtherApplicable = CDblSafe(dr.Item(36), 2, 0)
            _DeductionImprest = CDblSafe(dr.Item(37), 2, 0)
            _NPD = CDblSafe(dr.Item(38), 2, 0)
            _PNPD = CDblSafe(dr.Item(39), 2, 0)
            _DaysForVDU = CIntSafe(dr.Item(40), 0)
            _HoursForVDU = CDblSafe(dr.Item(41), 4, 0)
            _WageForVDU = CDblSafe(dr.Item(42), 2, 0)
            _RateSODRAEmployee = CDblSafe(dr.Item(45), 2, 0)
            _RateSODRAEmployer = CDblSafe(dr.Item(46), 2, 0)
            _RatePSDEmployee = CDblSafe(dr.Item(47), 2, 0)
            _RatePSDEmployer = CDblSafe(dr.Item(48), 2, 0)
            _RateGuaranteeFund = CDblSafe(dr.Item(49), 2, 0)
            _RateGPM = CDblSafe(dr.Item(50), 2, 0)
            _NPDFormula = CStrSafe(dr.Item(51)).Trim
            _RateHR = CDblSafe(dr.Item(52), 2, 0)
            _RateSC = CDblSafe(dr.Item(53), 2, 0)
            _RateON = CDblSafe(dr.Item(54), 2, 0)
            _RateSickLeave = CDblSafe(dr.Item(55), 2, 0)
            _Year = CIntSafe(dr.Item(56))
            _Month = CIntSafe(dr.Item(57))
            _PayedOutTotalSum = CRound(CDblSafe(dr.Item(58), 2) + CDblSafe(dr.Item(59), 2))

            RecalculatePay()

        End Sub

        Private Sub RecalculatePay()

            _TotalHoursWorked = CRound(_NormalHoursWorked + _HRHoursWorked + _
                _ONHoursWorked + _SCHoursWorked, 4)

            If Not _StandartHours > 0 OrElse Not _NormalHoursWorked > 0 Then
                _PayOutWage = 0
                _PayOutExtraPay = 0
            Else
                If _WageType = WageType.Position Then
                    _PayOutWage = CRound(_ConventionalWage * _NormalHoursWorked / _StandartHours)
                Else
                    _PayOutWage = CRound(_ConventionalWage * _NormalHoursWorked)
                End If
                _PayOutExtraPay = CRound(_ConventionalExtraPay * _NormalHoursWorked / _StandartHours)
            End If

            If Not _NormalHoursWorked > 0 AndAlso Not _StandartHours > 0 Then
                _ActualHourlyPay = 0
            ElseIf Not _NormalHoursWorked > 0 Then
                _ActualHourlyPay = CRound((_ConventionalWage + _ConventionalExtraPay + _
                    _OtherPayRelatedToWork) / _StandartHours)
            Else
                _ActualHourlyPay = CRound((PayOutWage + PayOutExtraPay + _
                    _OtherPayRelatedToWork) / _NormalHoursWorked)
            End If

            If _Year = 2008 AndAlso _Month = 6 Then
                _PayOutHR = CRound(_HRHoursWorked * _ApplicableVDUHourly * _RateHR / 100)
                _PayOutON = CRound(_ONHoursWorked * _ApplicableVDUHourly * _RateON / 100)
                _PayOutSC = CRound(_SCHoursWorked * _ApplicableVDUHourly * _RateSC / 100)
            Else
                _PayOutHR = CRound(_HRHoursWorked * _ActualHourlyPay * _RateHR / 100)
                _PayOutON = CRound(_ONHoursWorked * _ActualHourlyPay * _RateON / 100)
                _PayOutSC = CRound(_SCHoursWorked * _ActualHourlyPay * _RateSC / 100)
            End If

            _PayOutSickLeave = CRound(_ApplicableVDUDaily * _SickDays * _RateSickLeave / 100)

            If CRound(_UnusedHolidayDaysForCompensation) > 0 Then
                _PayOutUnusedHolidayCompensation = _
                    CRound(_AnnualWorkingDaysRatio * _ApplicableVDUDaily * _
                    _UnusedHolidayDaysForCompensation)
                _PayOutHoliday = 0
                _HolidayWD = 0
                _HolidayRD = 0
            Else
                _PayOutUnusedHolidayCompensation = 0
                _PayOutHoliday = CRound(_HolidayWD * _ApplicableVDUDaily)
            End If

            _PayOutTotal = CRound(_BonusPay + _OtherPayRelatedToWork + _OtherPayNotRelatedToWork + _
                _PayOutWage + _PayOutExtraPay + _PayOutHR + _PayOutON + _PayOutSC + _PayOutSickLeave + _
                _PayOutHoliday + _PayOutUnusedHolidayCompensation + _PayOutRedundancyPay)

            _HoursForVDU = CRound(_TotalHoursWorked + _TruancyHours, 4)
            _DaysForVDU = Convert.ToInt32(Math.Ceiling(_TruancyHours / 8) + _TotalDaysWorked)
            _WageForVDU = CRound(_OtherPayRelatedToWork + _PayOutWage + _PayOutExtraPay + _
                _PayOutHR + _PayOutON + _PayOutSC)

            Dim TaxBase As Double

            If CRound(_PayOutTotal) >= CRound(_NPD + _PNPD) Then
                TaxBase = CRound(_PayOutTotal - _NPD - _PNPD)
            ElseIf CRound(_PayOutTotal) > CRound(_NPD) Then
                TaxBase = 0
                _PNPD = CRound(_PayOutTotal - _NPD)
            Else
                TaxBase = 0
                _PNPD = 0
                _NPD = CRound(_PayOutTotal)
            End If

            _DeductionGPM = CRound(TaxBase * _RateGPM / 100)

            TaxBase = CRound(_PayOutTotal - _PayOutSickLeave)
            If TaxBase < 0 Then TaxBase = 0

            If _Year > 2008 Then
                _DeductionPSD = CRound(TaxBase * _RatePSDEmployee / 100)
                _ContributionPSD = CRound(TaxBase * _RatePSDEmployer / 100)
            Else
                _DeductionPSD = 0
                _ContributionPSD = 0
            End If
            If _Year = 2009 Then
                _DeductionPSDSickLeave = CRound(_PayOutSickLeave * _RatePSDEmployee / 100)
            Else
                _DeductionPSDSickLeave = 0
            End If

            _DeductionSODRA = CRound(TaxBase * _RateSODRAEmployee / 100)
            _ContributionSODRA = CRound(TaxBase * _RateSODRAEmployer / 100)

            _ContributionGuaranteeFund = CRound(_PayOutTotal * _RateGuaranteeFund / 100)

            _PayOutTotalAfterTaxes = CRound(_PayOutTotal - _DeductionGPM - _
                _DeductionPSD - _DeductionPSDSickLeave - _DeductionSODRA)

            If CRound(_PayOutTotalAfterTaxes) >= CRound(_ImprestPending) Then
                _DeductionImprest = CRound(_ImprestPending)
            Else
                _DeductionImprest = CRound(_PayOutTotalAfterTaxes)
            End If

            Dim WageAfterTaxesAndImprest As Double = CRound(_PayOutTotalAfterTaxes - _DeductionImprest)

            If CRound(WageAfterTaxesAndImprest) >= CRound(_DeductionOther) Then
                _DeductionOtherApplicable = CRound(_DeductionOther)
            Else
                _DeductionOtherApplicable = CRound(WageAfterTaxesAndImprest)
            End If

            _PayOutTotalAfterDeductions = CRound(WageAfterTaxesAndImprest - _DeductionOtherApplicable)
            _PayableTotal = CRound(_PayOutTotalAfterDeductions + _DeductionImprest)

        End Sub

        Friend Sub AddWageItemForInfoObject(ByVal itemToAdd As WorkerWageInfo)
            _WorkLoad = _WorkLoad + itemToAdd._WorkLoad
            _NormalHoursWorked = _NormalHoursWorked + itemToAdd._NormalHoursWorked
            _HRHoursWorked = _HRHoursWorked + itemToAdd._HRHoursWorked
            _ONHoursWorked = _ONHoursWorked + itemToAdd._ONHoursWorked
            _SCHoursWorked = _SCHoursWorked + itemToAdd._SCHoursWorked
            _TotalHoursWorked = _TotalHoursWorked + itemToAdd._TotalHoursWorked
            _TruancyHours = _TruancyHours + itemToAdd._TruancyHours
            _TotalDaysWorked = _TotalDaysWorked + itemToAdd._TotalDaysWorked
            _HolidayWD = _HolidayWD + itemToAdd._HolidayWD
            _HolidayRD = _HolidayRD + itemToAdd._HolidayRD
            _SickDays = _SickDays + itemToAdd._SickDays
            _StandartHours = _StandartHours + itemToAdd._StandartHours
            _StandartDays = _StandartDays + itemToAdd._StandartDays
            _BonusPay = _BonusPay + itemToAdd._BonusPay
            _OtherPayRelatedToWork = _OtherPayRelatedToWork + itemToAdd._OtherPayRelatedToWork
            _OtherPayNotRelatedToWork = _OtherPayNotRelatedToWork + itemToAdd._OtherPayNotRelatedToWork
            _PayOutWage = _PayOutWage + itemToAdd._PayOutWage
            _PayOutExtraPay = _PayOutExtraPay + itemToAdd._PayOutExtraPay
            _ActualHourlyPay = _ActualHourlyPay + itemToAdd._ActualHourlyPay
            _PayOutHR = _PayOutHR + itemToAdd._PayOutHR
            _PayOutON = _PayOutON + itemToAdd._PayOutON
            _PayOutSC = _PayOutSC + itemToAdd._PayOutSC
            _PayOutSickLeave = _PayOutSickLeave + itemToAdd._PayOutSickLeave
            _UnusedHolidayDaysForCompensation = _UnusedHolidayDaysForCompensation + _
                itemToAdd._UnusedHolidayDaysForCompensation
            _PayOutHoliday = _PayOutHoliday + itemToAdd._PayOutHoliday
            _PayOutUnusedHolidayCompensation = _PayOutUnusedHolidayCompensation + _
                itemToAdd._PayOutUnusedHolidayCompensation
            _PayOutRedundancyPay = _PayOutRedundancyPay + itemToAdd._PayOutRedundancyPay
            _PayOutTotal = _PayOutTotal + itemToAdd._PayOutTotal
            _DeductionGPM = _DeductionGPM + itemToAdd._DeductionGPM
            _DeductionPSD = _DeductionPSD + itemToAdd._DeductionPSD
            _DeductionPSDSickLeave = _DeductionPSDSickLeave + itemToAdd._DeductionPSDSickLeave
            _DeductionSODRA = _DeductionSODRA + itemToAdd._DeductionSODRA
            _DeductionImprest = _DeductionImprest + itemToAdd._DeductionImprest
            _DeductionOtherApplicable = _DeductionOtherApplicable + itemToAdd._DeductionOtherApplicable
            _ContributionSODRA = _ContributionSODRA + itemToAdd._ContributionSODRA
            _ContributionPSD = _ContributionPSD + itemToAdd._ContributionPSD
            _ContributionGuaranteeFund = _ContributionGuaranteeFund + itemToAdd._ContributionGuaranteeFund
            _PayOutTotalAfterTaxes = _PayOutTotalAfterTaxes + itemToAdd._PayOutTotalAfterTaxes
            _PayOutTotalAfterDeductions = _PayOutTotalAfterDeductions + itemToAdd._PayOutTotalAfterDeductions
            _NPD = _NPD + itemToAdd._NPD
            _PNPD = _PNPD + itemToAdd._PNPD
            _HoursForVDU = _HoursForVDU + itemToAdd._HoursForVDU
            _DaysForVDU = _DaysForVDU + itemToAdd._DaysForVDU
            _WageForVDU = _WageForVDU + itemToAdd._WageForVDU
            _PayedOutTotalSum = _PayedOutTotalSum + itemToAdd._PayedOutTotalSum
        End Sub

#End Region

    End Class

End Namespace