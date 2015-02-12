Imports ApskaitaObjects.HelperLists
Namespace Documents

    <Serializable()> _
    Public Class BankOperation
        Inherits BusinessBase(Of BankOperation)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Private _JournalEntryID As Integer = 0
        Private _ID As Integer = 0
        Private _ChronologicValidator As SimpleChronologicValidator
        Private _IsDebit As Boolean = True
        Private _Account As CashAccountInfo = Nothing
        Private _Date As Date = Today
        Private _OldDate As Date = Today
        Private _DocumentNumber As String = ""
        Private _Person As PersonInfo = Nothing
        Private _OriginalPerson As String = ""
        Private _Content As String = ""
        Private _OriginalContent As String = ""
        Private _UniqueCode As String = ""
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency
        Private _CurrencyRate As Double = 1
        Private _CurrencyRateInAccount As Double = 1
        Private _Sum As Double = 0
        Private _SumLTL As Double = 0
        Private _SumInAccount As Double = 0
        Private _SumCorespondences As Double = 0
        Private _AccountBankCurrencyConversionCosts As Long = 0
        Private _BankCurrencyConversionCosts As Double = 0
        Private _AccountCurrencyRateChangeImpact As Long = 0
        Private _CurrencyRateChangeImpact As Double = 0
        Private _IsTransferBetweenAccounts As Boolean = False
        Private _CreditTransferOperationID As Integer = 0
        Private _UniqueCodeInCreditAccount As String = ""
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private _CreditCashAccount As CashAccountInfo = Nothing
        Private WithEvents _BookEntryItems As General.BookEntryList

        Private SuspendChildListChangedEvents As Boolean = False
        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _BookEntryItemsSortedList As Csla.SortedBindingList(Of General.BookEntry) = Nothing

        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property ChronologicValidator() As SimpleChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChronologicValidator
            End Get
        End Property

        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        Public Property IsDebit() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsDebit
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If IsDebitIsReadOnly Then Exit Property
                If _IsDebit <> value Then
                    _IsDebit = value
                    PropertyHasChanged()
                    PropertyHasChanged("IsCredit")
                    If Not _Person Is Nothing AndAlso _Person.ID > 0 AndAlso _BookEntryItems.Count = 1 Then
                        If _IsDebit Then
                            _BookEntryItems(0).Account = _Person.AccountAgainstBankBuyer
                        Else
                            _BookEntryItems(0).Account = _Person.AccountAgainstBankSupplyer
                        End If
                    End If
                    Recalculate(True)
                End If
            End Set
        End Property

        Public Property IsCredit() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _IsDebit
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If IsCreditIsReadOnly Then Exit Property
                If _IsDebit = value Then
                    _IsDebit = Not value
                    PropertyHasChanged()
                    PropertyHasChanged("IsDebit")
                    If Not _Person Is Nothing AndAlso _Person.ID > 0 AndAlso _BookEntryItems.Count = 1 Then
                        If _IsDebit Then
                            _BookEntryItems(0).Account = _Person.AccountAgainstBankBuyer
                        Else
                            _BookEntryItems(0).Account = _Person.AccountAgainstBankSupplyer
                        End If
                    End If
                    Recalculate(True)
                End If
            End Set
        End Property

        Public Property Account() As HelperLists.CashAccountInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As CashAccountInfo)

                CanWriteProperty(True)

                If AccountIsReadOnly Then Exit Property

                If Not (_Account Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Account Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _Account = value) Then

                    Dim OldCurrencyCode, NewCurrencyCode As String
                    If _Account Is Nothing OrElse Not _Account.ID > 0 Then
                        OldCurrencyCode = GetCurrentCompany.BaseCurrency
                    Else
                        OldCurrencyCode = _Account.CurrencyCode.Trim.ToUpper
                    End If
                    If value Is Nothing OrElse Not value.ID > 0 Then
                        NewCurrencyCode = GetCurrentCompany.BaseCurrency
                    Else
                        NewCurrencyCode = value.CurrencyCode.Trim.ToUpper
                    End If

                    _Account = value

                    PropertyHasChanged()

                    If OldCurrencyCode <> NewCurrencyCode Then

                        PropertyHasChanged("AccountCurrency")

                        If NewCurrencyCode.Trim.ToUpper = _CurrencyCode.Trim.ToUpper OrElse _
                            (String.IsNullOrEmpty(CurrencyCode.Trim) AndAlso NewCurrencyCode.Trim.ToUpper _
                            = GetCurrentCompany.BaseCurrency) Then

                            _CurrencyRateInAccount = _CurrencyRate

                        Else

                            If NewCurrencyCode.Trim.ToUpper = GetCurrentCompany.BaseCurrency Then
                                _CurrencyRateInAccount = 1
                            Else
                                _CurrencyRateInAccount = 0
                            End If

                        End If

                        PropertyHasChanged("CurrencyRateInAccount")

                        Recalculate(True)

                    End If

                End If
            End Set
        End Property

        Public ReadOnly Property AccountCurrency() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If Not _Account Is Nothing AndAlso _Account.ID > 0 Then Return _Account.CurrencyCode
                Return GetCurrentCompany.BaseCurrency
            End Get
        End Property

        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                CanWriteProperty(True)
                If _Date.Date <> value.Date Then
                    _Date = value.Date
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property OldDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OldDate
            End Get
        End Property

        Public Property DocumentNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _DocumentNumber.Trim <> value.Trim Then
                    _DocumentNumber = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Person() As PersonInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Person
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As PersonInfo)
                CanWriteProperty(True)

                If PersonIsReadOnly Then Exit Property
                
                If Not (_Person Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Person Is Nothing AndAlso Not value Is Nothing AndAlso _Person = value) Then

                    _Person = value
                    PropertyHasChanged()

                    If Not _Person Is Nothing AndAlso _Person.ID > 0 AndAlso _
                        _ChronologicValidator.FinancialDataCanChange Then

                        If _BookEntryItems.Count < 1 Then
                            Dim entry As General.BookEntry = General.BookEntry.NewBookEntry()
                            If _IsDebit Then
                                entry.Account = _Person.AccountAgainstBankBuyer
                            Else
                                entry.Account = _Person.AccountAgainstBankSupplyer
                            End If
                            entry.Amount = _SumLTL
                            _BookEntryItems.Add(entry)
                        ElseIf _BookEntryItems.Count = 1 Then
                            If _IsDebit Then
                                _BookEntryItems(0).Account = _Person.AccountAgainstBankBuyer
                            Else
                                _BookEntryItems(0).Account = _Person.AccountAgainstBankSupplyer
                            End If
                        End If

                    End If

                End If
            End Set
        End Property

        Public Property OriginalPerson() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OriginalPerson.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Friend Set(ByVal value As String)
                _OriginalPerson = value.Trim
            End Set
        End Property

        Public Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Content.Trim <> value.Trim Then
                    _Content = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property OriginalContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OriginalContent.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Friend Set(ByVal value As String)
                _OriginalContent = value.Trim
            End Set
        End Property

        Public Property UniqueCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UniqueCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _UniqueCode.Trim <> value.Trim Then
                    _UniqueCode = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)

                CanWriteProperty(True)

                If CurrencyCodeIsReadOnly Then Exit Property

                If value Is Nothing Then value = ""

                If Not CurrenciesEquals(_CurrencyCode, value, GetCurrentCompany.BaseCurrency) Then

                    _CurrencyCode = GetCurrencySafe(value, GetCurrentCompany.BaseCurrency)
                    PropertyHasChanged()

                    If Not CurrencyRateIsReadOnly Then
                        If CurrenciesEquals(_CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) Then
                            _CurrencyRate = 1
                        Else
                            _CurrencyRate = 0
                        End If
                        PropertyHasChanged("CurrencyRate")
                    End If

                    If CurrenciesEquals(AccountCurrency, _CurrencyCode, GetCurrentCompany.BaseCurrency) Then
                        _CurrencyRateInAccount = _CurrencyRate
                        PropertyHasChanged("CurrencyRateInAccount")
                    End If

                    Recalculate(True)

                End If

            End Set
        End Property

        Public Property CurrencyRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRate, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)

                If CurrencyRateIsReadOnly Then Exit Property

                If CRound(_CurrencyRate, 6) <> CRound(value, 6) Then

                    _CurrencyRate = CRound(value, 6)
                    PropertyHasChanged()

                    If CurrenciesEquals(AccountCurrency, _CurrencyCode, GetCurrentCompany.BaseCurrency) Then
                        _CurrencyRateInAccount = _CurrencyRate
                        PropertyHasChanged("CurrencyRateInAccount")
                    End If

                    Recalculate(True)

                End If

            End Set
        End Property

        Public Property CurrencyRateInAccount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateInAccount, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)

                If CurrencyRateInAccountIsReadOnly Then Exit Property
                If CurrenciesEquals(AccountCurrency, _CurrencyCode, GetCurrentCompany.BaseCurrency) Then Exit Property

                CanWriteProperty(True)

                If CRound(_CurrencyRateInAccount, 6) <> CRound(value, 6) Then

                    _CurrencyRateInAccount = CRound(value, 6)
                    PropertyHasChanged()

                    Recalculate(True)

                End If

            End Set
        End Property

        Public Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If SumIsReadOnly Then Exit Property
                If CRound(_Sum) <> CRound(value) Then
                    _Sum = CRound(value)
                    PropertyHasChanged()
                    Recalculate(True)
                End If
            End Set
        End Property

        Public ReadOnly Property SumLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTL)
            End Get
        End Property

        Public ReadOnly Property SumInAccount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumInAccount)
            End Get
        End Property

        Public ReadOnly Property SumCorespondences() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumCorespondences)
            End Get
        End Property

        Public Property AccountBankCurrencyConversionCosts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountBankCurrencyConversionCosts
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountBankCurrencyConversionCostsIsReadOnly Then Exit Property
                If _AccountBankCurrencyConversionCosts <> value Then
                    _AccountBankCurrencyConversionCosts = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property BankCurrencyConversionCosts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BankCurrencyConversionCosts)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If BankCurrencyConversionCostsIsReadOnly Then Exit Property
                If CRound(_BankCurrencyConversionCosts) <> CRound(value) Then
                    _BankCurrencyConversionCosts = CRound(value)
                    Recalculate(True)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property AccountCurrencyRateChangeImpact() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountCurrencyRateChangeImpact
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountCurrencyRateChangeImpactIsReadOnly Then Exit Property
                If _AccountCurrencyRateChangeImpact <> value Then
                    _AccountCurrencyRateChangeImpact = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property CurrencyRateChangeImpact() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateChangeImpact)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CurrencyRateChangeImpactIsReadOnly Then Exit Property
                If CRound(_CurrencyRateChangeImpact) <> CRound(value) Then
                    _CurrencyRateChangeImpact = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property IsTransferBetweenAccounts() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsTransferBetweenAccounts
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)

                CanWriteProperty(True)

                If IsTransferBetweenAccountsIsReadOnly Then Exit Property

                If _IsTransferBetweenAccounts <> value Then

                    _IsTransferBetweenAccounts = value
                    PropertyHasChanged()

                    If value AndAlso Not _IsDebit Then
                        _IsDebit = True
                        PropertyHasChanged("IsDebit")
                        PropertyHasChanged("IsCredit")
                    End If

                    If value Then

                        If _CreditCashAccount Is Nothing OrElse Not _CreditCashAccount.ID > 0 Then
                            If Not CurrenciesEquals(_CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) Then
                                _CurrencyCode = GetCurrentCompany.BaseCurrency
                                PropertyHasChanged("CurrencyCode")
                            End If
                            If CRound(_CurrencyRate, 6) <> 1 Then
                                _CurrencyRate = 1
                                PropertyHasChanged("CurrencyRate")
                            End If
                        Else
                            If Not CurrenciesEquals(_CurrencyCode, _CreditCashAccount.CurrencyCode, GetCurrentCompany.BaseCurrency) Then
                                _CurrencyCode = CreditCashAccount.CurrencyCode.Trim.ToUpper
                                PropertyHasChanged("CurrencyCode")
                            End If
                            If CurrenciesEquals(_CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) _
                                AndAlso CRound(_CurrencyRate, 6) <> 1 Then
                                _CurrencyRate = 1
                                PropertyHasChanged("CurrencyRate")
                            ElseIf Not CurrenciesEquals(_CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) _
                                AndAlso CRound(_CurrencyRate, 6) > 0 Then
                                _CurrencyRate = 0
                                PropertyHasChanged("CurrencyRate")
                            End If
                        End If

                        If _AccountCurrencyRateChangeImpact > 0 Then
                            _AccountCurrencyRateChangeImpact = 0
                            PropertyHasChanged("AccountCurrencyRateChangeImpact")
                        End If
                        If CRound(_CurrencyRateChangeImpact) <> 0 Then
                            _CurrencyRateChangeImpact = 0
                            PropertyHasChanged("CurrencyRateChangeImpact")
                        End If

                        _BookEntryItems.Clear()
                        _Person = Nothing
                        PropertyHasChanged("Person")

                        Recalculate(True)

                    End If

                End If

            End Set
        End Property

        Public ReadOnly Property CreditTransferOperationID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CreditTransferOperationID
            End Get
        End Property

        Public Property UniqueCodeInCreditAccount() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UniqueCodeInCreditAccount.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If UniqueCodeInCreditAccountIsReadOnly Then Exit Property
                If value Is Nothing Then value = ""
                If _UniqueCodeInCreditAccount.Trim <> value.Trim Then
                    _UniqueCodeInCreditAccount = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property CreditCashAccount() As CashAccountInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CreditCashAccount
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As CashAccountInfo)
                CanWriteProperty(True)

                If CreditCashAccountIsReadOnly Then Exit Property

                If Not (_CreditCashAccount Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _CreditCashAccount Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _CreditCashAccount = value) Then

                    _CreditCashAccount = value
                    PropertyHasChanged()

                    If _CreditCashAccount Is Nothing OrElse Not _CreditCashAccount.ID > 0 Then
                        If Not CurrenciesEquals(_CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) Then
                            _CurrencyCode = GetCurrentCompany.BaseCurrency
                            PropertyHasChanged("CurrencyCode")
                        End If
                        If CRound(_CurrencyRate, 6) <> 1 Then
                            _CurrencyRate = 1
                            PropertyHasChanged("CurrencyRate")
                        End If
                    Else
                        If Not CurrenciesEquals(_CurrencyCode, _CreditCashAccount.CurrencyCode, GetCurrentCompany.BaseCurrency) Then
                            _CurrencyCode = CreditCashAccount.CurrencyCode.Trim.ToUpper
                            PropertyHasChanged("CurrencyCode")
                        End If
                        If CurrenciesEquals(_CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) _
                            AndAlso CRound(_CurrencyRate, 6) <> 1 Then
                            _CurrencyRate = 1
                            PropertyHasChanged("CurrencyRate")
                        ElseIf Not CurrenciesEquals(_CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) _
                            AndAlso CRound(_CurrencyRate, 6) > 0 Then
                            _CurrencyRate = 0
                            PropertyHasChanged("CurrencyRate")
                        End If
                    End If

                    Recalculate(True)

                End If
            End Set
        End Property

        Public ReadOnly Property BookEntryItems() As General.BookEntryList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BookEntryItems
            End Get
        End Property

        Public ReadOnly Property BookEntryItemsSorted() As Csla.SortedBindingList(Of General.BookEntry)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _BookEntryItemsSortedList Is Nothing Then _BookEntryItemsSortedList = _
                    New Csla.SortedBindingList(Of General.BookEntry)(_BookEntryItems)
                Return _BookEntryItemsSortedList
            End Get
        End Property


        Public ReadOnly Property BookEntryItemsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange OrElse _IsTransferBetweenAccounts
            End Get
        End Property

        Public ReadOnly Property IsDebitIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange OrElse _IsTransferBetweenAccounts
            End Get
        End Property

        Public ReadOnly Property IsCreditIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange OrElse _IsTransferBetweenAccounts
            End Get
        End Property

        Public ReadOnly Property AccountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property PersonIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsTransferBetweenAccounts
            End Get
        End Property

        Public ReadOnly Property CurrencyCodeIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange OrElse _IsTransferBetweenAccounts
            End Get
        End Property

        Public ReadOnly Property CurrencyRateIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property CurrencyRateInAccountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property SumIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property AccountBankCurrencyConversionCostsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property BankCurrencyConversionCostsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property AccountCurrencyRateChangeImpactIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange OrElse _IsTransferBetweenAccounts
            End Get
        End Property

        Public ReadOnly Property CurrencyRateChangeImpactIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange OrElse _IsTransferBetweenAccounts
            End Get
        End Property

        Public ReadOnly Property IsTransferBetweenAccountsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property CreditCashAccountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange OrElse Not _IsTransferBetweenAccounts
            End Get
        End Property

        Public ReadOnly Property UniqueCodeInCreditAccountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _IsTransferBetweenAccounts
            End Get
        End Property
        
        
        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_DocumentNumber.Trim) _
                OrElse Not String.IsNullOrEmpty(_Content.Trim) _
                OrElse Not String.IsNullOrEmpty(_UniqueCode.Trim) _
                OrElse CRound(_Sum) > 0 OrElse _BookEntryItems.Count > 0)
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _BookEntryItems.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso _BookEntryItems.IsValid
            End Get
        End Property


        Public Function GetAllBrokenRules() As String
            Dim result As String = ""
            If Not MyBase.IsValid Then result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            If Not _BookEntryItems.IsValid Then result = AddWithNewLine(result, _
                _BookEntryItems.GetAllBrokenRules, False)
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then _
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            result = AddWithNewLine(result, _BookEntryItems.GetAllWarnings, False)
            Return result
        End Function


        Public Overrides Function Save() As BankOperation

            Me.ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & vbCrLf _
                & Me.GetAllBrokenRules)

            Return MyBase.Save

        End Function


        Private Sub BookEntryItems_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _BookEntryItems.ListChanged

            If SuspendChildListChangedEvents OrElse _IsTransferBetweenAccounts Then Exit Sub

            _SumCorespondences = _BookEntryItems.GetSum
            PropertyHasChanged("SumCorespondences")

            If Me.AccountCurrency.Trim.ToUpper = GetCurrentCompany.BaseCurrency Then
                _SumInAccount = _SumCorespondences
                PropertyHasChanged("SumInAccount")
            End If

            If Me.CurrencyCode.Trim.ToUpper = GetCurrentCompany.BaseCurrency Then
                _Sum = _SumCorespondences
                _SumLTL = _SumCorespondences
                PropertyHasChanged("Sum")
                PropertyHasChanged("SumLTL")
            End If

        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As BankOperation = DirectCast(MyBase.GetClone(), BankOperation)
            result.RestoreChildListsHandles()
            Return result
        End Function

        Protected Overrides Sub OnDeserialized(ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            RestoreChildListsHandles()
        End Sub

        Protected Overrides Sub UndoChangesComplete()
            MyBase.UndoChangesComplete()
            RestoreChildListsHandles()
        End Sub

        ''' <summary>
        ''' Helper method. Takes care of TaskTimeSpans loosing its handler. See GetClone method.
        ''' </summary>
        Friend Sub RestoreChildListsHandles()
            Try
                RemoveHandler _BookEntryItems.ListChanged, AddressOf BookEntryItems_Changed
            Catch ex As Exception
            End Try
            AddHandler _BookEntryItems.ListChanged, AddressOf BookEntryItems_Changed
        End Sub


        Private Sub Recalculate(ByVal RaisePropertyChangedEvents As Boolean)

            Dim SelectedCurrencyInAccount As String = GetCurrencySafe(AccountCurrency, GetCurrentCompany.BaseCurrency)
            Dim SelectedCurrency As String = GetCurrencySafe(_CurrencyCode, GetCurrentCompany.BaseCurrency)

            If _IsTransferBetweenAccounts Then
                If _CreditCashAccount Is Nothing OrElse Not _CreditCashAccount.ID > 0 Then
                    SelectedCurrency = GetCurrentCompany.BaseCurrency
                Else
                    SelectedCurrency = GetCurrencySafe(_CreditCashAccount.CurrencyCode, GetCurrentCompany.BaseCurrency)
                End If
            End If

            Dim SelectedCurrencyRate As Double = _CurrencyRate
            If CurrenciesEquals(SelectedCurrency, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) Then SelectedCurrencyRate = 1

            _SumLTL = CRound(_Sum * _CurrencyRate)

            If _IsTransferBetweenAccounts Then _SumCorespondences = _SumLTL

            If CurrenciesEquals(SelectedCurrencyInAccount, SelectedCurrency, GetCurrentCompany.BaseCurrency) Then

                _SumInAccount = _Sum

            ElseIf CurrenciesEquals(SelectedCurrencyInAccount, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) Then

                If _IsDebit Then
                    _SumInAccount = CRound(_SumLTL - _BankCurrencyConversionCosts)
                Else
                    _SumInAccount = CRound(_SumLTL + _BankCurrencyConversionCosts)
                End If

            Else

                If CRound(_CurrencyRateInAccount, 6) > 0 Then
                    If _IsDebit Then
                        _SumInAccount = CRound(CRound(_SumLTL / _CurrencyRateInAccount) - _
                            CRound(_BankCurrencyConversionCosts / _CurrencyRateInAccount))
                    Else
                        _SumInAccount = CRound(CRound(_SumLTL / _CurrencyRateInAccount) + _
                            CRound(_BankCurrencyConversionCosts / _CurrencyRateInAccount))
                    End If
                Else
                    _SumInAccount = 0
                End If

            End If

            If RaisePropertyChangedEvents Then
                PropertyHasChanged("SumLTL")
                PropertyHasChanged("SumInAccount")
                If _IsTransferBetweenAccounts Then PropertyHasChanged("SumCorespondences")
            End If

        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            If Not _ID > 0 Then Return ""
            Return _Content
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "ChronologicValidator"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Content", "banko operacijos aprašas (turinys)"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("DocumentNumber", "banko operacijos dok. Nr."))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("Sum", "operacijos suma originalia valiuta"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("SumInAccount", "operacijos suma sąskaitos valiuta"))
            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyValid, _
                New CommonValidation.SimpleRuleArgs("CurrencyCode", ""))

            ValidationRules.AddRule(AddressOf AccountValidation, New Validation.RuleArgs("Account"))
            ValidationRules.AddRule(AddressOf UniqueCodeValidation, New Validation.RuleArgs("UniqueCode"))
            ValidationRules.AddRule(AddressOf CurrencyRateValidation, New Validation.RuleArgs("CurrencyRate"))
            ValidationRules.AddRule(AddressOf PersonValidation, New Validation.RuleArgs("Person"))
            ValidationRules.AddRule(AddressOf CurrencyRateInAccountValidation, _
                New Validation.RuleArgs("CurrencyRateInAccount"))
            ValidationRules.AddRule(AddressOf AccountCurrencyRateChangeImpactValidation, _
                New Validation.RuleArgs("AccountCurrencyRateChangeImpact"))
            ValidationRules.AddRule(AddressOf AccountBankCurrencyConversionCostsValidation, _
                New Validation.RuleArgs("AccountBankCurrencyConversionCosts"))
            ValidationRules.AddRule(AddressOf SumLTLValidation, New Validation.RuleArgs("SumLTL"))
            ValidationRules.AddRule(AddressOf CreditCashAccountValidation, _
                New Validation.RuleArgs("CreditCashAccount"))
            ValidationRules.AddRule(AddressOf UniqueCodeInCreditAccountValidation, _
                New Validation.RuleArgs("UniqueCodeInCreditAccount"))


            ValidationRules.AddDependantProperty("Account", "UniqueCode", False)
            ValidationRules.AddDependantProperty("CurrencyCode", "CurrencyRate", False)
            ValidationRules.AddDependantProperty("AccountCurrency", "CurrencyRateInAccount", False)
            ValidationRules.AddDependantProperty("IsTransferBetweenAccounts", "Person", False)
            ValidationRules.AddDependantProperty("CurrencyRateChangeImpact", "AccountCurrencyRateChangeImpact", False)
            ValidationRules.AddDependantProperty("BankCurrencyConversionCosts", "AccountBankCurrencyConversionCosts", False)
            ValidationRules.AddDependantProperty("CurrencyCode", "AccountBankCurrencyConversionCosts", False)
            ValidationRules.AddDependantProperty("AccountCurrency", "AccountBankCurrencyConversionCosts", False)
            ValidationRules.AddDependantProperty("Account", "CreditCashAccount", False)
            ValidationRules.AddDependantProperty("IsTransferBetweenAccounts", "CreditCashAccount", False)
            ValidationRules.AddDependantProperty("CreditCashAccount", "UniqueCodeInCreditAccount", False)
            ValidationRules.AddDependantProperty("IsTransferBetweenAccounts", "UniqueCodeInCreditAccount", False)
            ValidationRules.AddDependantProperty("CurrencyRateChangeImpact", "SumLTL", False)
            ValidationRules.AddDependantProperty("SumCorespondences", "SumLTL", False)
            ValidationRules.AddDependantProperty("IsDebit", "SumLTL", False)

        End Sub


        ''' <summary>
        ''' Rule ensuring that a sum of bank operation is provided.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumLTLValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperation = DirectCast(target, BankOperation)

            If Not CRound(ValObj._SumLTL) > 0 Then

                e.Description = "Nenurodyta lėšų suma."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf (ValObj._IsDebit AndAlso CRound(ValObj._SumLTL) _
                <> CRound(ValObj._SumCorespondences + ValObj._CurrencyRateChangeImpact)) _
                OrElse (Not ValObj._IsDebit AndAlso CRound(ValObj._SumLTL) _
                <> CRound(ValObj._SumCorespondences - ValObj._CurrencyRateChangeImpact)) Then

                e.Description = "Operacijos suma litais turi būti lygi korespondencijų sumai " _
                    & "plius/minus valiutos kurso pasikeitimo įtaka."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the account is set.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperation = DirectCast(target, BankOperation)

            If ValObj._Account Is Nothing OrElse Not ValObj._Account.ID > 0 Then

                e.Description = "Nenurodyta sąskaita, kurioje atliekama operacija."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf ValObj._Account.Type <> CashAccountType.BankAccount AndAlso _
                ValObj._Account.Type <> CashAccountType.PseudoBankAccount Then

                e.Description = "Pasirinktos sąskaitos tipas - ne banko sąskaita, " _
                    & "o " & ConvertEnumHumanReadable(ValObj._Account.Type) & "."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property UniqueCode is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function UniqueCodeValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperation = DirectCast(target, BankOperation)

            If Not ValObj._Account Is Nothing AndAlso ValObj._Account.ID > 0 AndAlso _
                ValObj._Account.EnforceUniqueOperationID AndAlso _
                (ValObj._UniqueCode Is Nothing OrElse String.IsNullOrEmpty(ValObj._UniqueCode.Trim)) Then
                e.Description = "Klaida. Nenurodytas unikalus operacijos kodas."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that a CreditCashAccount is set when necessary.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function CreditCashAccountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperation = DirectCast(target, BankOperation)

            If ValObj._IsTransferBetweenAccounts AndAlso (ValObj._CreditCashAccount Is Nothing _
                OrElse Not ValObj._CreditCashAccount.ID > 0) Then

                e.Description = "Nenurodyta kredituojama sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf ValObj._IsTransferBetweenAccounts AndAlso Not ValObj._CreditCashAccount Is Nothing _
                AndAlso ValObj._CreditCashAccount.ID > 0 AndAlso _
                ValObj._CreditCashAccount.Type <> CashAccountType.BankAccount AndAlso _
                ValObj._CreditCashAccount.Type <> CashAccountType.PseudoBankAccount Then

                e.Description = "Pasirinktos sąskaitos tipas - ne banko sąskaita, " _
                    & "o " & ConvertEnumHumanReadable(ValObj._CreditCashAccount.Type) & "."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf ValObj._IsTransferBetweenAccounts AndAlso Not ValObj._Account Is Nothing _
                AndAlso ValObj._Account.ID > 0 AndAlso ValObj._Account.ID = ValObj._CreditCashAccount.ID Then

                e.Description = "Kredituojama sąskaita negali sutapti su debetuojama."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that a UniqueCodeInCreditAccount is set when necessary.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function UniqueCodeInCreditAccountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperation = DirectCast(target, BankOperation)

            If ValObj._IsTransferBetweenAccounts AndAlso Not ValObj._CreditCashAccount Is Nothing _
                AndAlso ValObj._CreditCashAccount.ID > 0 AndAlso _
                ValObj._CreditCashAccount.EnforceUniqueOperationID AndAlso _
                String.IsNullOrEmpty(ValObj._UniqueCodeInCreditAccount.Trim) Then

                e.Description = "Nenurodytas unikalus operacijos kodas kredituojamoje sąskaitoje."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that CurrencyRate is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function CurrencyRateValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperation = DirectCast(target, BankOperation)

            If CurrenciesEquals(ValObj._CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) _
                AndAlso CRound(ValObj._CurrencyRate, 6) <> 1 Then

                e.Description = "Bazinės valiutos kursas negali būti nelygus 1."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf Not CRound(ValObj._CurrencyRate, 6) > 0 Then

                e.Description = "Nenurodytas operacijos valiutos kursas."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that CurrencyRateInAccount is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function CurrencyRateInAccountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperation = DirectCast(target, BankOperation)

            If CurrenciesEquals(ValObj.AccountCurrency, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) _
                AndAlso CRound(ValObj._CurrencyRateInAccount, 6) <> 1 Then

                e.Description = "Bazinės valiutos kursas negali būti nelygus 1."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf Not CRound(ValObj._CurrencyRateInAccount, 6) > 0 Then

                e.Description = "Nenurodytas sąskaitos valiutos kursas."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that a Person is set when necessary or vice versa.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function PersonValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperation = DirectCast(target, BankOperation)

            If Not ValObj._IsTransferBetweenAccounts AndAlso (ValObj._Person Is Nothing _
                OrElse Not ValObj._Person.ID > 0) Then

                e.Description = "Nenurodytas mokėtojas/gavėjas."
                e.Severity = Validation.RuleSeverity.Warning
                Return False

            ElseIf ValObj._IsTransferBetweenAccounts AndAlso Not ValObj._Person Is Nothing _
                AndAlso ValObj._Person.ID > 0 Then

                e.Description = "Pavedime tarp įmonės sąskaitų mokėtojas/gavėjas nenurodomas."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that a valid currency rate change impact account is set when necessary.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountCurrencyRateChangeImpactValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperation = DirectCast(target, BankOperation)

            If Not ValObj._AccountCurrencyRateChangeImpact > 0 AndAlso _
                CRound(ValObj._CurrencyRateChangeImpact) <> 0 Then

                e.Description = "Nenurodyta valiutos kurso pasikeitimo įtakos apskaitos sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that a valid AccountBankCurrencyConversionCosts is set when necessary.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountBankCurrencyConversionCostsValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As BankOperation = DirectCast(target, BankOperation)

            If CurrenciesEquals(ValObj._CurrencyCode, ValObj.AccountCurrency, GetCurrentCompany.BaseCurrency) AndAlso _
                (ValObj._AccountBankCurrencyConversionCosts > 0 OrElse _
                CRound(ValObj._BankCurrencyConversionCosts) > 0) Then

                e.Description = "Banko valiutos konvertavimo sąnaudos negali atsirasti, " _
                    & "kai mokėjimo valiuta sutampa su sąskaitos valiuta."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf Not ValObj._AccountBankCurrencyConversionCosts > 0 AndAlso _
                CRound(ValObj._BankCurrencyConversionCosts) > 0 Then

                e.Description = "Banko valiutos konvertavimo sąnaudų apskaitos sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Documents.BankOperation2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.BankOperation1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.BankOperation2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.BankOperation3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.BankOperation3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewBankOperation() As BankOperation

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")

            Dim result As New BankOperation
            result._ChronologicValidator = SimpleChronologicValidator. _
                NewSimpleChronologicValidator("banko operacija")
            result._BookEntryItems = General.BookEntryList.NewBookEntryList(BookEntryType.Kreditas)
            result.ValidationRules.CheckRules()
            Return result

        End Function

        Public Shared Function GetBankOperation(ByVal nID As Integer) As BankOperation
            Return DataPortal.Fetch(Of BankOperation)(New Criteria(nID))
        End Function

        Public Shared Sub DeleteBankOperation(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
        End Sub

        Public Shared Function NewBankOperation(ByVal ImportedBankOperation As BankOperationItem, _
            ByVal nAccount As CashAccountInfo, ByVal ThrowOnNotValid As Boolean) As BankOperation
            Return New BankOperation(ImportedBankOperation, nAccount, ThrowOnNotValid)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub


        Private Sub New(ByVal ImportedBankOperation As BankOperationItem, _
            ByVal nAccount As CashAccountInfo, ByVal ThrowOnNotValid As Boolean)
            Create(ImportedBankOperation, nAccount, ThrowOnNotValid)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public Sub New(ByVal nID As Integer)
                _ID = nID
            End Sub
        End Class


        Private Sub Create(ByVal ImportedBankOperation As BankOperationItem, _
            ByVal nAccount As CashAccountInfo, ByVal ThrowOnNotValid As Boolean)

            _ChronologicValidator = SimpleChronologicValidator. _
                NewSimpleChronologicValidator("banko operacija")

            _Account = nAccount
            _Person = ImportedBankOperation.Person
            _Content = ImportedBankOperation.Content
            _CurrencyCode = ImportedBankOperation.Currency
            _CurrencyRate = ImportedBankOperation.CurrencyRate
            _CurrencyRateInAccount = ImportedBankOperation.CurrencyRateInAccount
            _Date = ImportedBankOperation.Date
            _DocumentNumber = ImportedBankOperation.DocumentNumber
            _OriginalPerson = ImportedBankOperation.PersonName.Trim & " (" _
                & ImportedBankOperation.PersonCode.Trim & ")"
            _OriginalContent = ImportedBankOperation.Content
            _Sum = ImportedBankOperation.OriginalSum
            _SumInAccount = ImportedBankOperation.SumInAccountBank
            _SumLTL = ImportedBankOperation.SumLTL
            _IsDebit = ImportedBankOperation.Inflow
            If ImportedBankOperation.Inflow Then
                _BookEntryItems = General.BookEntryList.NewBookEntryList(BookEntryType.Kreditas)
            Else
                _BookEntryItems = General.BookEntryList.NewBookEntryList(BookEntryType.Debetas)
            End If
            _UniqueCode = ImportedBankOperation.UniqueCode
            _AccountBankCurrencyConversionCosts = ImportedBankOperation.AccountBankCurrencyConversionCosts
            _BankCurrencyConversionCosts = ImportedBankOperation.BankCurrencyConversionCosts

            Dim CorrespondingBookEntry As General.BookEntry = General.BookEntry.NewBookEntry
            CorrespondingBookEntry.Amount = ImportedBankOperation.SumLTL
            If ImportedBankOperation.IsBankCosts Then
                CorrespondingBookEntry.Account = nAccount.BankFeeCostsAccount
                _Person = PersonInfo.GetPersonInfo(nAccount.ManagingPersonID)
            Else
                CorrespondingBookEntry.Account = ImportedBankOperation.AccountCorresponding
            End If
            _BookEntryItems.Add(CorrespondingBookEntry)

            ValidationRules.CheckRules()

            If ThrowOnNotValid AndAlso Not IsValid Then Throw New Exception( _
                "Klaida. Nepavyko suformuoti banko operacijos: " & vbCrLf & GetAllBrokenRules())

        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims gauti.")

            Dim myComm As New SQLCommand("FetchBankOperation")
            myComm.AddParam("?BD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception( _
                    "Klaida. Lėšų operacija, kurios ID='" & criteria.ID & "', nerasta.)")

                Dim dr As DataRow = myData.Rows(0)

                _JournalEntryID = criteria.ID

                _ID = CIntSafe(dr.Item(0), 0)
                _Date = CDateSafe(dr.Item(1), Today)
                _OldDate = _Date
                _DocumentNumber = CStrSafe(dr.Item(2)).Trim
                _Content = CStrSafe(dr.Item(3)).Trim
                _UniqueCode = CStrSafe(dr.Item(4)).Trim
                _CurrencyCode = GetCurrencySafe(CStrSafe(dr.Item(5)), GetCurrentCompany.BaseCurrency)
                _CurrencyRate = CDblSafe(dr.Item(6), 6, 0)
                _CurrencyRateInAccount = CDblSafe(dr.Item(7), 6, 0)
                _IsDebit = (CDblSafe(dr.Item(8), 2, 0) > 0)
                _Sum = Math.Abs(CDblSafe(dr.Item(8), 2, 0))
                _SumLTL = Math.Abs(CDblSafe(dr.Item(9), 2, 0))
                _SumInAccount = Math.Abs(CDblSafe(dr.Item(10), 2, 0))
                _AccountCurrencyRateChangeImpact = CLongSafe(dr.Item(11), 0)
                _CurrencyRateChangeImpact = CDblSafe(dr.Item(12), 2, 0)
                _OriginalPerson = CStrSafe(dr.Item(13)).Trim
                _OriginalContent = CStrSafe(dr.Item(14)).Trim
                _AccountBankCurrencyConversionCosts = CLongSafe(dr.Item(15), 0)
                _InsertDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(16), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _UpdateDate = DateTime.SpecifyKind(CDateTimeSafe(dr.Item(17), Date.UtcNow), _
                    DateTimeKind.Utc).ToLocalTime
                _Account = CashAccountInfo.GetCashAccountInfo(dr, 18)
                _Person = PersonInfo.GetPersonInfo(dr, 32)

                If myData.Rows.Count > 1 Then

                    _IsTransferBetweenAccounts = True
                    _CreditTransferOperationID = CIntSafe(myData.Rows(1).Item(0), 0)
                    _UniqueCodeInCreditAccount = CStrSafe(myData.Rows(1).Item(4)).Trim
                    _CreditCashAccount = CashAccountInfo.GetCashAccountInfo(myData.Rows(1), 18)

                End If

                If CurrenciesEquals(_Account.CurrencyCode, _CurrencyCode, GetCurrentCompany.BaseCurrency) Then
                    _BankCurrencyConversionCosts = 0
                ElseIf CurrenciesEquals(_Account.CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) Then
                    If _IsDebit Then
                        _BankCurrencyConversionCosts = CRound(CRound(_SumLTL) - CRound(_SumInAccount))
                    Else
                        _BankCurrencyConversionCosts = CRound(CRound(_SumInAccount) - CRound(_SumLTL))
                    End If
                Else
                    If CRound(_CurrencyRateInAccount, 6) > 0 Then
                        If _IsDebit Then
                            _BankCurrencyConversionCosts = CRound(_SumLTL - _
                                CRound(_SumInAccount * _CurrencyRateInAccount))
                        Else
                            _BankCurrencyConversionCosts = CRound(CRound(_SumInAccount _
                                * _CurrencyRateInAccount) - _SumLTL)
                        End If
                    Else
                        _BankCurrencyConversionCosts = 0
                    End If
                End If

            End Using

            _ChronologicValidator = SimpleChronologicValidator. _
                GetSimpleChronologicValidator(_JournalEntryID, _Date, "banko operacija")

            If Not _IsTransferBetweenAccounts Then

                myComm = New SQLCommand("BookEntriesFetch")
                myComm.AddParam("?BD", _JournalEntryID)

                Using myData As DataTable = myComm.Fetch
                    If _IsDebit Then
                        _BookEntryItems = General.BookEntryList.GetBookEntryList( _
                            myData, BookEntryType.Kreditas, _ChronologicValidator.FinancialDataCanChange, _
                            _ChronologicValidator.FinancialDataCanChangeExplanation, _
                            _AccountCurrencyRateChangeImpact, _AccountBankCurrencyConversionCosts)
                    Else
                        _BookEntryItems = General.BookEntryList.GetBookEntryList( _
                            myData, BookEntryType.Debetas, _ChronologicValidator.FinancialDataCanChange, _
                            _ChronologicValidator.FinancialDataCanChangeExplanation, _
                            _AccountCurrencyRateChangeImpact, _AccountBankCurrencyConversionCosts)
                    End If
                End Using

                _SumCorespondences = _BookEntryItems.GetSum

            Else

                _BookEntryItems = General.BookEntryList.NewBookEntryList(BookEntryType.Kreditas)
                _SumCorespondences = _SumLTL

            End If

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")

            PrepareForInsertUpdate()

            If _Date.Date <= GetCurrentCompany.LastClosingDate.Date Then Throw New Exception( _
                "Klaida. Neleidžiama koreguoti operacijų po uždarymo (" _
                & GetCurrentCompany.LastClosingDate & ").")

            Dim TransactionExisted As Boolean = DatabaseAccess.TransactionExists

            If Not TransactionExisted Then CheckIfUniqueCodeIsUnique()
            Dim JE As General.JournalEntry = GetJournalEntry()

            If Not TransactionExisted Then DatabaseAccess.TransactionBegin()

            JE = JE.SaveServerSide()

            _JournalEntryID = JE.ID
            _InsertDate = JE.InsertDate
            _UpdateDate = JE.UpdateDate

            Dim myComm As New SQLCommand("InsertBankOperation")
            AddWithParams(myComm)
            myComm.AddParam("?AA", _JournalEntryID)
            myComm.AddParam("?AB", _OriginalPerson.Trim)
            myComm.AddParam("?AC", _OriginalContent.Trim)
            myComm.AddParam("?AE", _UniqueCode.Trim)

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            If _IsTransferBetweenAccounts Then

                myComm = New SQLCommand("InsertBankOperation")
                AddWithParamsCreditForTransfer(myComm)
                myComm.AddParam("?AA", _JournalEntryID)
                myComm.AddParam("?AB", _OriginalPerson.Trim)
                myComm.AddParam("?AC", _OriginalContent.Trim)
                myComm.AddParam("?AE", _UniqueCodeInCreditAccount.Trim)

                myComm.Execute()

                _CreditTransferOperationID = Convert.ToInt32(myComm.LastInsertID)

            End If

            If Not TransactionExisted Then DatabaseAccess.TransactionCommit()

            MarkOld()

        End Sub

        Friend Sub InsertServerSide()
            DataPortal_Insert()
        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pakeisti.")

            _ChronologicValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                _JournalEntryID, _ChronologicValidator.CurrentOperationDate, "banko operacija")

            PrepareForInsertUpdate()

            CheckIfUniqueCodeIsUnique()

            Dim myComm As New SQLCommand("UpdateBankOperation")
            If _ChronologicValidator.FinancialDataCanChange Then
                myComm = New SQLCommand("UpdateBankOperation")
                AddWithParams(myComm)
            Else
                myComm = New SQLCommand("UpdateBankOperationNonFinancial")
            End If
            myComm.AddParam("?AE", _UniqueCode.Trim)
            myComm.AddParam("?BD", _ID)

            Dim JE As General.JournalEntry = GetJournalEntry()

            DatabaseAccess.TransactionBegin()

            JE = JE.SaveServerSide()
            _UpdateDate = JE.UpdateDate

            myComm.Execute()

            If _ChronologicValidator.FinancialDataCanChange AndAlso Not _IsTransferBetweenAccounts _
                AndAlso _CreditTransferOperationID > 0 Then

                myComm = New SQLCommand("DeleteCreditAccountBankOperation")
                myComm.AddParam("?BD", _CreditTransferOperationID)

            ElseIf _ChronologicValidator.FinancialDataCanChange AndAlso _IsTransferBetweenAccounts _
                AndAlso Not _CreditTransferOperationID > 0 Then

                myComm = New SQLCommand("InsertBankOperation")
                AddWithParamsCreditForTransfer(myComm)
                myComm.AddParam("?AA", _JournalEntryID)
                myComm.AddParam("?AB", _OriginalPerson.Trim)
                myComm.AddParam("?AC", _OriginalContent.Trim)
                myComm.AddParam("?AE", _UniqueCodeInCreditAccount.Trim)

            ElseIf _IsTransferBetweenAccounts AndAlso _CreditTransferOperationID > 0 Then

                If _ChronologicValidator.FinancialDataCanChange Then
                    myComm = New SQLCommand("UpdateBankOperation")
                    AddWithParamsCreditForTransfer(myComm)
                Else
                    myComm = New SQLCommand("UpdateBankOperationNonFinancial")
                End If
                myComm.AddParam("?BD", _CreditTransferOperationID)
                myComm.AddParam("?AE", _UniqueCodeInCreditAccount.Trim)

            End If

            myComm.Execute()

            If _IsTransferBetweenAccounts AndAlso Not _CreditTransferOperationID > 0 Then _
                _CreditTransferOperationID = Convert.ToInt32(myComm.LastInsertID)

            DatabaseAccess.TransactionCommit()

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pašalinti.")

            IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted(DirectCast(criteria, Criteria).ID, _
                DocumentType.BankOperation)

            Dim myComm As New SQLCommand("DeleteBankOperation")
            myComm.AddParam("?BD", DirectCast(criteria, Criteria).ID)

            DatabaseAccess.TransactionBegin()

            General.JournalEntry.DoDelete(DirectCast(criteria, Criteria).ID)

            myComm.Execute()

            DatabaseAccess.TransactionCommit()

            MarkNew()

        End Sub



        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            Dim OperationSign As Integer = 1
            If Not _IsDebit AndAlso Not _IsTransferBetweenAccounts Then OperationSign = -1

            myComm.AddParam("?AD", _Account.ID)
            myComm.AddParam("?AF", GetCurrencySafe(_CurrencyCode, GetCurrentCompany.BaseCurrency))
            If CurrenciesEquals(_CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) Then
                myComm.AddParam("?AG", 1)
            Else
                myComm.AddParam("?AG", CRound(_CurrencyRate, 6))
            End If
            If CurrenciesEquals(AccountCurrency, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) Then
                myComm.AddParam("?AH", 1)
            ElseIf CurrenciesEquals(AccountCurrency, _CurrencyCode, GetCurrentCompany.BaseCurrency) Then
                myComm.AddParam("?AH", CRound(_CurrencyRate, 6))
            Else
                myComm.AddParam("?AH", CRound(_CurrencyRateInAccount, 6))
            End If
            myComm.AddParam("?AI", CRound(OperationSign * _Sum))
            myComm.AddParam("?AJ", CRound(OperationSign * _SumLTL))
            myComm.AddParam("?AK", CRound(OperationSign * _SumInAccount))
            myComm.AddParam("?AL", _AccountCurrencyRateChangeImpact)
            myComm.AddParam("?AM", CRound(_CurrencyRateChangeImpact))
            If CurrenciesEquals(AccountCurrency, _CurrencyCode, GetCurrentCompany.BaseCurrency) Then
                myComm.AddParam("?AN", 0)
            Else
                myComm.AddParam("?AN", _AccountBankCurrencyConversionCosts)
            End If

        End Sub

        Private Sub AddWithParamsCreditForTransfer(ByRef myComm As SQLCommand)

            myComm.AddParam("?AD", _CreditCashAccount.ID)
            myComm.AddParam("?AF", _CreditCashAccount.CurrencyCode.Trim)
            If CurrenciesEquals(_CreditCashAccount.CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) Then
                myComm.AddParam("?AG", 1)
                myComm.AddParam("?AH", 1)
            Else
                myComm.AddParam("?AG", CRound(_CurrencyRate, 6))
                myComm.AddParam("?AH", CRound(_CurrencyRate, 6))
            End If
            myComm.AddParam("?AI", -CRound(_Sum))
            myComm.AddParam("?AJ", -CRound(_SumLTL))
            myComm.AddParam("?AK", -CRound(_Sum)) ' SumInAccount
            myComm.AddParam("?AL", 0) ' AccountCurrencyRateChangeImpact
            myComm.AddParam("?AM", 0) ' CurrencyRateChangeImpact
            myComm.AddParam("?AN", 0) ' AccountBankCurrencyConversionCosts

        End Sub

        Friend Sub CheckIfUniqueCodeIsUnique()

            If _Account Is Nothing OrElse Not _Account.ID > 0 _
                OrElse Not _Account.EnforceUniqueOperationID Then Exit Sub

            Dim myComm As New SQLCommand("CheckIfBankOperationUniqueCodeIsUnique")
            myComm.AddParam("?OD", _ID)
            myComm.AddParam("?UC", _UniqueCode.Trim)
            myComm.AddParam("?AD", _Account.ID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 Then _
                    Throw New Exception("Klaida. Operacija su tokiu unikaliu kodu jau " _
                    & "yra debetuojamoje sąskaitoje.")
            End Using

            If _CreditCashAccount Is Nothing OrElse Not _CreditCashAccount.ID > 0 _
                OrElse Not _CreditCashAccount.EnforceUniqueOperationID Then Exit Sub

            myComm = New SQLCommand("CheckIfBankOperationUniqueCodeIsUnique")
            myComm.AddParam("?OD", _CreditTransferOperationID)
            myComm.AddParam("?UC", Me._UniqueCodeInCreditAccount.Trim)
            myComm.AddParam("?AD", _CreditCashAccount.ID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 Then _
                    Throw New Exception("Klaida. Operacija su tokiu unikaliu kodu jau " _
                    & "yra kredituojamoje sąskaitoje.")
            End Using

        End Sub

        Private Function GetJournalEntry() As General.JournalEntry

            Dim result As General.JournalEntry
            If IsNew Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.BankOperation)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_JournalEntryID, DocumentType.BankOperation)
                If result.UpdateDate <> _UpdateDate Then Throw New Exception( _
                    "Klaida. Dokumento atnaujinimo data pasikeitė. Teigtina, kad kitas " _
                    & "vartotojas redagavo šį objektą.")
            End If

            result.Content = _Content
            result.Date = _Date
            result.DocNumber = _DocumentNumber
            result.Person = _Person

            If _ChronologicValidator.FinancialDataCanChange Then

                Dim FullBookEntryList As BookEntryInternalList = BookEntryInternalList. _
                NewBookEntryInternalList(BookEntryType.Debetas)

                If _IsDebit Then
                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, _Account.Account, CRound(_SumLTL), Nothing))
                Else
                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, _Account.Account, CRound(_SumLTL), Nothing))
                End If

                If Not _IsTransferBetweenAccounts Then
                    If CRound(_CurrencyRateChangeImpact) > 0 AndAlso _AccountCurrencyRateChangeImpact > 0 Then
                        FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Kreditas, _AccountCurrencyRateChangeImpact, _
                            CRound(_CurrencyRateChangeImpact), Nothing))
                    ElseIf CRound(_CurrencyRateChangeImpact) < 0 AndAlso _AccountCurrencyRateChangeImpact > 0 Then
                        FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Debetas, _AccountCurrencyRateChangeImpact, _
                            CRound(-_CurrencyRateChangeImpact), Nothing))
                    Else
                        _AccountCurrencyRateChangeImpact = 0
                        _CurrencyRateChangeImpact = 0
                    End If
                End If

                If Not CurrenciesEquals(AccountCurrency, _CurrencyCode, GetCurrentCompany.BaseCurrency) _
                    AndAlso _AccountBankCurrencyConversionCosts > 0 _
                    AndAlso CRound(_BankCurrencyConversionCosts) > 0 Then

                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, _AccountBankCurrencyConversionCosts, _
                        CRound(_BankCurrencyConversionCosts), Nothing))
                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, _Account.Account, _
                        CRound(_BankCurrencyConversionCosts), Nothing))

                End If

                If _IsTransferBetweenAccounts Then

                    FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, _CreditCashAccount.Account, CRound(_SumLTL), Nothing))

                Else

                    If _IsDebit Then
                        For Each i As General.BookEntry In _BookEntryItems

                            If i.Account <> _AccountCurrencyRateChangeImpact Then _
                                FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                                BookEntryType.Kreditas, i.Account, i.Amount, i.Person))

                        Next
                    Else
                        For Each i As General.BookEntry In _BookEntryItems

                            If i.Account <> _AccountCurrencyRateChangeImpact Then _
                                FullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                                BookEntryType.Debetas, i.Account, i.Amount, i.Person))

                        Next
                    End If

                End If

                FullBookEntryList.Aggregate()

                result.DebetList.Clear()
                result.CreditList.Clear()

                result.DebetList.LoadBookEntryListFromInternalList(FullBookEntryList, False)
                result.CreditList.LoadBookEntryListFromInternalList(FullBookEntryList, False)

            End If

            If Not result.IsValid Then Throw New Exception("Klaida. Nepavyko generuoti " _
                & "bendrojo žurnalo įrašo.")

            Return result

        End Function

        ''' <summary>
        ''' Repairs possible trivial errors, e.g. LTL rate not equal to 1, etc.
        ''' </summary>
        Private Sub PrepareForInsertUpdate()

            ' No currency means LTL
            If _CurrencyCode Is Nothing OrElse String.IsNullOrEmpty(_CurrencyCode.Trim) Then _
                _CurrencyCode = GetCurrentCompany.BaseCurrency
            _CurrencyCode = GetCurrencySafe(_CurrencyCode, GetCurrentCompany.BaseCurrency)

            If _IsTransferBetweenAccounts Then

                If Not _IsDebit Then _IsDebit = True

                ' For transfers between accounts operation currency should always be 
                ' the same as credited account currency
                If Not CurrenciesEquals(_CreditCashAccount.CurrencyCode, _CurrencyCode, GetCurrentCompany.BaseCurrency) Then _
                    _CurrencyCode = GetCurrencySafe(_CreditCashAccount.CurrencyCode, GetCurrentCompany.BaseCurrency)

                ' CurrencyRateChangeImpact is impossible when transfering between company's own accounts
                _AccountCurrencyRateChangeImpact = 0
                _CurrencyRateChangeImpact = 0

            Else

                ' Remove currency rate change effect BookEntries that was entered into
                ' the correspondences list instead of currency rate change effect field
                ' by some stupid user
                If _AccountCurrencyRateChangeImpact > 0 AndAlso _
                    _BookEntryItems.GetSumInAccount(_AccountCurrencyRateChangeImpact) > 0 Then
                    If _IsDebit Then
                        _CurrencyRateChangeImpact = CRound(_CurrencyRateChangeImpact _
                            + _BookEntryItems.GetSumInAccount(_AccountCurrencyRateChangeImpact))
                    Else
                        _CurrencyRateChangeImpact = CRound(_CurrencyRateChangeImpact _
                            - _BookEntryItems.GetSumInAccount(_AccountCurrencyRateChangeImpact))
                    End If
                End If

                ' only account and impact together make sense
                If _AccountCurrencyRateChangeImpact = 0 Then
                    _CurrencyRateChangeImpact = 0
                ElseIf CRound(_CurrencyRateChangeImpact) = 0 Then
                    _AccountCurrencyRateChangeImpact = 0
                End If

            End If

            ' LTL rate is always 1 (should be unless some stupid user)
            If CurrenciesEquals(_CurrencyCode, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) Then _CurrencyRate = 1

            If CurrenciesEquals(AccountCurrency, GetCurrentCompany.BaseCurrency, GetCurrentCompany.BaseCurrency) Then
                ' LTL rate is always 1 (should be unless some stupid user)
                _CurrencyRateInAccount = 1
            ElseIf CurrenciesEquals(AccountCurrency, _CurrencyCode, GetCurrentCompany.BaseCurrency) Then
                ' if operation currency is the same as account currency, the rates should be equal
                _CurrencyRateInAccount = CRound(_CurrencyRate, 6)
            End If

            ' bank currency conversion costs can only happen if such a conversion 
            ' is done by a bank, i.e. operation currency is different from account currency
            If CurrenciesEquals(AccountCurrency, _CurrencyCode, GetCurrentCompany.BaseCurrency) Then
                _AccountBankCurrencyConversionCosts = 0
                _BankCurrencyConversionCosts = 0
            End If

            Recalculate(False)

            ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " & vbCrLf _
                & Me.GetAllBrokenRules)

        End Sub

#End Region

    End Class

End Namespace