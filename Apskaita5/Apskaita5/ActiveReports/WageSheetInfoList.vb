Namespace ActiveReports

    ''' <summary>
    ''' Represents a wage sheet report. Contains information about <see cref="Workers.WageSheet">WageSheets</see>.
    ''' </summary>
    ''' <remarks>Values are stored in the database tables du_ziniarastis and du_ziniarastis_d.</remarks>
    <Serializable()> _
    Public Class WageSheetInfoList
        Inherits ReadOnlyListBase(Of WageSheetInfoList, WageSheetInfo)

#Region " Business Methods "

        Private _DateFrom As Date
        Private _DateTo As Date
        Private _ShowPayedOut As Boolean = True
        Private _TotalSumAfterDeductions As Double
        Private _TotalSumPayedOut As Double

        ''' <summary>
        ''' Minimum date of a wage sheet within the report.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DateFrom() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateFrom
            End Get
        End Property

        ''' <summary>
        ''' Maximum date of a wage sheet within the report.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DateTo() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateTo
            End Get
        End Property

        ''' <summary>
        ''' Whether to show information about wage sheets where all the wage is payed out to the workers. 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ShowPayedOut() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ShowPayedOut
            End Get
        End Property

        ''' <summary>
        ''' Total sum of the wage after deductions within the report.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TotalSumAfterDeductions() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TotalSumAfterDeductions
            End Get
        End Property

        ''' <summary>
        ''' Total sum of the wage, that was payed to the workers, within the report.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TotalSumPayedOut() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TotalSumPayedOut
            End Get
        End Property


        Private Sub RecalculateSubTotals()

            _TotalSumAfterDeductions = 0
            _TotalSumPayedOut = 0

            For Each i As WageSheetInfo In Me
                If _ShowPayedOut OrElse Not i.IsPayedOut Then
                    _TotalSumAfterDeductions = CRound(_TotalSumAfterDeductions + i.PayOutAfterDeductions)
                    _TotalSumPayedOut = CRound(_TotalSumPayedOut + i.PayedOut)
                End If
            Next

        End Sub

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.WageSheetInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _FilteredList As Csla.FilteredBindingList(Of WageSheetInfo) = Nothing
        <NonSerialized()> _
        Private _Filter() As Object = Nothing

        ''' <summary>
        ''' Gets a new instance of wage sheet report.
        ''' </summary>
        ''' <param name="nDatefrom">Minimum date of a wage sheet within the report.</param>
        ''' <param name="nDateTo">Maximum date of a wage sheet within the report.</param>
        ''' <remarks></remarks>
        Public Shared Function GetWageSheetInfoList(ByVal nDatefrom As Date, ByVal nDateTo As Date) As WageSheetInfoList
            Return DataPortal.Fetch(Of WageSheetInfoList)(New Criteria(nDatefrom, nDateTo))
        End Function

        ''' <summary>
        ''' Gets a sortable view of the report that is also filtered with respect to <see cref="ShowPayedOut">ShowPayedOut</see>.
        ''' </summary>
        ''' <remarks>Use method <see cref="ApplyFilter">ApplyFilter</see> to set the property <see cref="ShowPayedOut">ShowPayedOut</see>.</remarks>
        Public Function GetFilteredList() As Csla.FilteredBindingList(Of WageSheetInfo)

            If _FilteredList Is Nothing Then

                _FilteredList = New Csla.FilteredBindingList(Of WageSheetInfo) _
                    (New Csla.SortedBindingList(Of WageSheetInfo)(Me), AddressOf WageSheetInfoFilter)
                _Filter = New Object() {ConvertDbBoolean(True)}
                _FilteredList.ApplyFilter("", _Filter)
                _ShowPayedOut = True

            End If

            Return _FilteredList

        End Function


        ''' <summary>
        ''' Sets a filter with respect to <see cref="ShowPayedOut">ShowPayedOut</see>.
        ''' </summary>
        ''' <param name="nShowPayedOutItems">A new value of <see cref="ShowPayedOut">ShowPayedOut</see>.</param>
        ''' <remarks></remarks>
        Public Function ApplyFilter(ByVal nShowPayedOutItems As Boolean) As Boolean

            If _FilteredList Is Nothing Then

                _FilteredList = New Csla.FilteredBindingList(Of WageSheetInfo) _
                    (New Csla.SortedBindingList(Of WageSheetInfo)(Me), AddressOf WageSheetInfoFilter)

            Else

                If ((_Filter Is Nothing OrElse _Filter.Length < 1) AndAlso nShowPayedOutItems) OrElse _
                    ConvertDbBoolean(CIntSafe(_Filter(0))) = nShowPayedOutItems Then Return False

            End If

            _Filter = New Object() {ConvertDbBoolean(nShowPayedOutItems)}
            _FilteredList.ApplyFilter("", _Filter)
            _ShowPayedOut = nShowPayedOutItems
            RecalculateSubTotals()

            Return True

        End Function

        Private Shared Function WageSheetInfoFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing OrElse DirectCast(filterValue, Object()).Length < 1 Then Return True

            Dim nShowPayedOut As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(0), Integer))

            If nShowPayedOut Then Return True

            Dim CI As WageSheetInfo = DirectCast(item, WageSheetInfo)

            If Not nShowPayedOut AndAlso Not CI.IsPayedOut Then Return False

            Return True

        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _DateFrom As Date
            Private _DateTo As Date
            Public ReadOnly Property DateFrom() As Date
                Get
                    Return _DateFrom
                End Get
            End Property
            Public ReadOnly Property DateTo() As Date
                Get
                    Return _DateTo
                End Get
            End Property
            Public Sub New(ByVal nDateFrom As Date, ByVal nDateTo As Date)
                _DateFrom = nDateFrom
                _DateTo = nDateTo
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchWageSheetInfoList")
            myComm.AddParam("?YF", criteria.DateFrom.Year)
            myComm.AddParam("?MF", criteria.DateFrom.Month)
            myComm.AddParam("?YT", criteria.DateTo.Year)
            myComm.AddParam("?MT", criteria.DateTo.Month)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                _TotalSumAfterDeductions = 0
                _TotalSumPayedOut = 0

                For Each dr As DataRow In myData.Rows

                    Dim itemToAdd As WageSheetInfo = WageSheetInfo.GetWageSheetInfo(dr)

                    Add(itemToAdd)

                    _TotalSumAfterDeductions = CRound(_TotalSumAfterDeductions + itemToAdd.PayOutAfterDeductions)
                    _TotalSumPayedOut = CRound(_TotalSumPayedOut + itemToAdd.PayedOut)

                Next

                _DateFrom = criteria.DateFrom
                _DateTo = criteria.DateTo

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace