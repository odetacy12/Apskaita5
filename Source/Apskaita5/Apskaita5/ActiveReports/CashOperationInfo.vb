Imports ApskaitaObjects.Attributes

Namespace ActiveReports

    ''' <summary>
    ''' Represents an item of <see cref="CashOperationInfoList">CashOperationInfoList</see> report.
    ''' Contains information about an operation in a <see cref="Documents.CashAccount">cash account</see>.
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="CashOperationInfoList">CashOperationInfoList</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class CashOperationInfo
        Inherits ReadOnlyBase(Of CashOperationInfo)

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _OperationType As DocumentType = DocumentType.None
        Private _OperationTypeHumanReadable As String = ""
        Private _AccountName As String = ""
        Private _AccountCurrency As String = ""
        Private _Date As Date = Today
        Private _DocumentNumber As String = ""
        Private _UniqueCode As String = ""
        Private _Content As String = ""
        Private _OriginalContent As String = ""
        Private _Person As String = ""
        Private _OriginalPerson As String = ""
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency
        Private _CurrencyRate As Double = 1
        Private _Sum As Double = 0
        Private _SumLTL As Double = 0
        Private _SumBookEntry As Double = 0
        Private _SumInAccount As Double = 0
        Private _CurrencyRateInAccount As Double = 0
        Private _CurrencyRateChangeImpact As Double = 0
        Private _BankCurrencyConversionCosts As Double = 0
        Private _BankCurrencyConversionCostsLTL As Double = 0
        Private _BookEntryList As String = ""


        ''' <summary>
        ''' Gets a JuornalEntry ID (DB assigned by AUTO_INCREMENT) that is made by the cash account operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.JournalEntry.ID">JournalEntry.ID</see> property.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets a name of the <see cref="Documents.CashAccount">cash account</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountName.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a type of the operation document.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.JournalEntry.DocType">JournalEntry.DocType</see> property.</remarks>
        Public ReadOnly Property OperationType() As DocumentType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationType
            End Get
        End Property

        ''' <summary>
        ''' Gets a type of the operation document as localized human readable string.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.JournalEntry.DocType">JournalEntry.DocType</see> property.</remarks>
        Public ReadOnly Property OperationTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationTypeHumanReadable.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a date of the operation document.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.JournalEntry.Date">JournalEntry.Date</see> property.</remarks>
        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        ''' <summary>
        ''' Gets a number of the operation document.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.JournalEntry.DocNumber">JournalEntry.DocNumber</see> property.</remarks>
        Public ReadOnly Property DocumentNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a unique code of the operation document.
        ''' </summary>
        ''' <remarks>Only applicable to bank and pseudobank operations.</remarks>
        Public ReadOnly Property UniqueCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UniqueCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a content of the operation document.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.JournalEntry.Content">JournalEntry.Content</see> property.</remarks>
        Public ReadOnly Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets an original content of the operation document as it was in the import source.
        ''' </summary>
        ''' <remarks>Only applicable to bank and pseudobank operations.</remarks>
        Public ReadOnly Property OriginalContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OriginalContent.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a person of the operation document.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.JournalEntry.Person">JournalEntry.Person</see> property.</remarks>
        Public ReadOnly Property Person() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Person.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets an original person of the operation document as it was in the import source.
        ''' </summary>
        ''' <remarks>Only applicable to bank and pseudobank operations.</remarks>
        Public ReadOnly Property OriginalPerson() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OriginalPerson.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a currency of the operation document.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a currency rate of the operation document.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDCURRENCYRATE)> _
        Public ReadOnly Property CurrencyRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRate, ROUNDCURRENCYRATE)
            End Get
        End Property

        ''' <summary>
        ''' Gets a sum of the operation document in the original currency.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
        End Property

        ''' <summary>
        ''' Gets a sum of the operation document in the base currency.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets a journal entry sum of the operation document.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumBookEntry() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumBookEntry)
            End Get
        End Property

        ''' <summary>
        ''' Gets a sum of the operation document in the cash account currency.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property SumInAccount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumInAccount)
            End Get
        End Property

        ''' <summary>
        ''' Gets a cash account currency rate of the operation document.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, ROUNDCURRENCYRATE)> _
        Public ReadOnly Property CurrencyRateInAccount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateInAccount, ROUNDCURRENCYRATE)
            End Get
        End Property

        ''' <summary>
        ''' Gets an impact of currency rate change in the operation document.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property CurrencyRateChangeImpact() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateChangeImpact)
            End Get
        End Property

        ''' <summary>
        ''' Gets the costs incured by currency conversion by a bank in the cash account currency.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property BankCurrencyConversionCosts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BankCurrencyConversionCosts)
            End Get
        End Property

        ''' <summary>
        ''' Gets the costs incured by currency conversion by a bank in the base currency.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property BankCurrencyConversionCostsLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BankCurrencyConversionCostsLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets a comma separated list of the book entries of the operation document.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property BookEntryList() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BookEntryList.Trim
            End Get
        End Property


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.ActiveReports_CashOperationInfo_ToString, _
                _Date.ToString("yyyy-MM-dd"), _OperationTypeHumanReadable, _DocumentNumber, _
                DblParser(_Sum), _CurrencyCode, _ID.ToString())
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function GetCashOperationInfo(ByVal dr As DataRow) As CashOperationInfo
            Return New CashOperationInfo(dr)
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

            Dim baseCurrency As String = GetCurrentCompany().BaseCurrency

            _ID = CIntSafe(dr.Item(0), 0)
            _OperationType = Utilities.ConvertDatabaseCharID(Of DocumentType)(CStrSafe(dr.Item(1)).Trim)
            _OperationTypeHumanReadable = Utilities.ConvertLocalizedName(_OperationType)
            _AccountName = CStrSafe(dr.Item(2)).Trim
            _AccountCurrency = CStrSafe(dr.Item(3)).Trim.ToUpper
            _Date = CDateSafe(dr.Item(4), Today)
            _DocumentNumber = CStrSafe(dr.Item(5)).Trim
            _UniqueCode = CStrSafe(dr.Item(6)).Trim
            _Content = CStrSafe(dr.Item(7)).Trim
            _Person = CStrSafe(dr.Item(8)).Trim
            If Not StringIsNullOrEmpty(_Person) AndAlso Not StringIsNullOrEmpty(CStrSafe(dr.Item(9))) Then _
                _Person = _Person & " (" & CStrSafe(dr.Item(9)).Trim & ")"
            _CurrencyCode = CStrSafe(dr.Item(10)).Trim
            If String.IsNullOrEmpty(_CurrencyCode) Then _CurrencyCode = baseCurrency
            _CurrencyRate = CDblSafe(dr.Item(11), ROUNDCURRENCYRATE, 0)
            _SumBookEntry = CDblSafe(dr.Item(12), 2, 0)
            _Sum = CDblSafe(dr.Item(13), 2, 0)
            _SumLTL = CDblSafe(dr.Item(14), 2, 0)
            _SumInAccount = CDblSafe(dr.Item(15), 2, 0)
            _CurrencyRateInAccount = CDblSafe(dr.Item(16), ROUNDCURRENCYRATE, 0)
            _CurrencyRateChangeImpact = CDblSafe(dr.Item(17), 2, 0)
            _OriginalContent = CStrSafe(dr.Item(18)).Trim
            _OriginalPerson = CStrSafe(dr.Item(19)).Trim
            _BookEntryList = CStrSafe(dr.Item(20)).Trim

            If CRound(_Sum, 2) = 0 AndAlso IsBaseCurrency(_CurrencyCode, baseCurrency) Then
                _Sum = _SumBookEntry
            End If
            If CRound(_SumLTL, 2) = 0 AndAlso IsBaseCurrency(_CurrencyCode, baseCurrency) Then
                _SumLTL = _SumBookEntry
            End If
            If CRound(_SumInAccount, 2) = 0 AndAlso CurrenciesEquals(_AccountCurrency, _CurrencyCode, baseCurrency) Then
                _SumInAccount = _Sum
            End If

            If CurrenciesEquals(_AccountCurrency, _CurrencyCode, baseCurrency) Then
                _BankCurrencyConversionCosts = 0
            ElseIf IsBaseCurrency(_AccountCurrency, baseCurrency) Then
                _BankCurrencyConversionCosts = CRound(CRound(_SumLTL) - CRound(_SumInAccount))
            Else
                If CRound(_CurrencyRateInAccount, ROUNDCURRENCYRATE) > 0 Then
                    _BankCurrencyConversionCosts = CRound(ConvertCurrency(_SumLTL, baseCurrency, 1.0, _
                        _AccountCurrency, _CurrencyRateInAccount, baseCurrency, 2, ROUNDCURRENCYRATE, 0) _
                        - CRound(_SumInAccount))
                Else
                    _BankCurrencyConversionCosts = 0
                End If
            End If
            _BankCurrencyConversionCostsLTL = ConvertCurrency(_BankCurrencyConversionCosts, _
                _AccountCurrency, _CurrencyRateInAccount, baseCurrency, 1.0, baseCurrency, _
                2, ROUNDCURRENCYRATE, 0)

            If (_OperationType = DocumentType.TillIncomeOrder OrElse _
                _OperationType = DocumentType.TillSpendingOrder) AndAlso _
                StringIsNullOrEmpty(_Person) Then
                _Person = My.Resources.Documents_TillIncomeOrder_IsUnderPayRoll
            End If

        End Sub

#End Region

    End Class

End Namespace
