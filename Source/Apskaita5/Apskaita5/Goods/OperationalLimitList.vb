Imports ApskaitaObjects.My.Resources

Namespace Goods

    ''' <summary>
    ''' Represents an <see cref="IChronologicValidator">IChronologicValidator</see> instance 
    ''' that is used to validate goods operation chronologic restrains.
    ''' </summary>
    ''' <remarks>Should only be used as a child of a goods operation, 
    ''' e.g. <see cref="GoodsOperationAcquisition">GoodsOperationAcquisition</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class OperationalLimitList
        Inherits ReadOnlyListBase(Of OperationalLimitList, OperationalLimit)
        Implements IChronologicValidator

#Region " Business Methods "

        Private Const DatePlaceHolder As String = "<$Date>"

        Private _CurrentOperationType As GoodsOperationType = GoodsOperationType.Acquisition
        Private _CurrentValuationMethod As GoodsValuationMethod = GoodsValuationMethod.FIFO
        Private _CurrentAccountingMethod As GoodsAccountingMethod = GoodsAccountingMethod.Persistent
        Private _CurrentOperationName As String = ""
        Private _CurrentOperationID As Integer = 0
        Private _CurrentOperationDate As Date = Today
        Private _CurrentGoodsID As Integer = 0
        Private _CurrentWarehouseID As Integer = 0

        Private _ConsignmentWasUsed As Boolean = False
        Private _ConsignmentWasUsedDate As Date = Date.MaxValue
        Private _FinancialDataCanChange As Boolean = True
        Private _MinDateApplicable As Boolean = False
        Private _MaxDateApplicable As Boolean = False
        Private _MinDate As Date = Date.MinValue
        Private _MaxDate As Date = Date.MaxValue
        Private _FinancialDataCanChangeExplanation As String = ""
        Private _MinDateExplanation As String = ""
        Private _MaxDateExplanation As String = ""
        Private _LimitsExplanation As String = ""
        Private _BackgroundExplanation As String = ""
        Private _ParentFinancialDataCanChange As Boolean = True
        Private _ParentFinancialDataCanChangeExplanation As String = ""
        Private _BaseValidator As IChronologicValidator


        ''' <summary>
        ''' Gets a human readable name of the validated (parent) goods operation. 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentOperationName() As String _
            Implements IChronologicValidator.CurrentOperationName
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationName
            End Get
        End Property

        ''' <summary>
        ''' Gets a type of the validated (parent) goods operation object.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentOperationType() As GoodsOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationType
            End Get
        End Property

        ''' <summary>
        ''' Gets a valuation method that is applicable to the validated (parent) 
        ''' goods operation object.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentValuationMethod() As GoodsValuationMethod
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentValuationMethod
            End Get
        End Property

        ''' <summary>
        ''' Gets an accounting method that is applicable to the validated (parent) 
        ''' goods operation object.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentAccountingMethod() As GoodsAccountingMethod
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentAccountingMethod
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID of the validated (parent) goods operation object,
        ''' e.g. <see cref="GoodsOperationAcquisition.ID">GoodsOperationAcquisition.ID</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentOperationID() As Integer _
            Implements IChronologicValidator.CurrentOperationID
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationID
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="GoodsItem.ID">ID of the goods</see> that the 
        ''' validated (parent) goods operation object operates with,
        ''' e.g. <see cref="GoodsOperationAcquisition.GoodsInfo">GoodsOperationAcquisition.GoodsInfo.ID</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentGoodsID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentGoodsID
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="Warehouse.ID">ID of the warehouse</see> that the 
        ''' validated (parent) goods operation object operates in,
        ''' e.g. <see cref="GoodsOperationAcquisition.Warehouse">GoodsOperationAcquisition.Warehouse.ID</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentWarehouseID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentWarehouseID
            End Get
        End Property

        ''' <summary>
        ''' Gets the current date of the validated (parent) goods operation 
        ''' (<see cref="Today">Today</see> for a new object). 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentOperationDate() As Date _
            Implements IChronologicValidator.CurrentOperationDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationDate
            End Get
        End Property


        ''' <summary>
        ''' Gets whether the <see cref="ConsignmentPersistenceObject">consignemnt</see>
        ''' owned by the validated (parent) goods operation was used by some other operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ConsignmentWasUsed() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ConsignmentWasUsed
            End Get
        End Property

        ''' <summary>
        ''' Gets a date when the <see cref="ConsignmentPersistenceObject">consignemnt</see>
        ''' owned by the validated (parent) goods operation was used by some other operation.
        ''' </summary>
        ''' <remarks>Defaults to Date.MaxValue.</remarks>
        Public ReadOnly Property ConsignmentWasUsedDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ConsignmentWasUsedDate
            End Get
        End Property


        ''' <summary>
        ''' Wheather the financial data of the validated (parent) goods operation 
        ''' is allowed to be changed.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property FinancialDataCanChange() As Boolean _
            Implements IChronologicValidator.FinancialDataCanChange
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Wheather there is a minimum allowed date for the validated (parent) operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MinDateApplicable() As Boolean _
            Implements IChronologicValidator.MinDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateApplicable
            End Get
        End Property

        ''' <summary>
        ''' Wheather there is a maximum allowed date for the validated (parent) operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MaxDateApplicable() As Boolean _
            Implements IChronologicValidator.MaxDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateApplicable
            End Get
        End Property

        ''' <summary>
        ''' Gets a minimum allowed date for the validated (parent) operation.
        ''' </summary>
        ''' <remarks>Defaults to Date.MinValue.</remarks>
        Public ReadOnly Property MinDate() As Date _
            Implements IChronologicValidator.MinDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a maximum allowed date for the validated (parent) operation.
        ''' </summary>
        ''' <remarks>Defaults to Date.MaxValue.</remarks>
        Public ReadOnly Property MaxDate() As Date _
            Implements IChronologicValidator.MaxDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of why the financial data 
        ''' of the validated (parent) operation is NOT allowed to be changed.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property FinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.FinancialDataCanChangeExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChangeExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of why there is a minimum allowed date 
        ''' for the validated (parent) operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MinDateExplanation() As String _
            Implements IChronologicValidator.MinDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of why there is a maximum allowed date 
        ''' for the validated (parent) operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MaxDateExplanation() As String _
            Implements IChronologicValidator.MaxDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of all the applicable business rules restrains.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property LimitsExplanation() As String _
            Implements IChronologicValidator.LimitsExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LimitsExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' A human readable explanation of the applicable business rules restrains.
        ''' </summary>
        ''' <remarks>More exhaustive than <see cref="LimitsExplanation">LimitsExplanation</see>.</remarks>
        Public ReadOnly Property BackgroundExplanation() As String _
            Implements IChronologicValidator.BackgroundExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BackgroundExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Wheather the financial data of the validated (parent) goods operation 
        ''' is allowed to be changed by the operation's parent document.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ParentFinancialDataCanChange() As Boolean _
        Implements IChronologicValidator.ParentFinancialDataCanChange
            Get
                Return _ParentFinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of why the financial data 
        ''' of the validated (parent) operation is NOT allowed to be changed
        ''' by the operation's parent document.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ParentFinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.ParentFinancialDataCanChangeExplanation
            Get
                Return _ParentFinancialDataCanChangeExplanation
            End Get
        End Property

        Public ReadOnly Property BaseValidator() As IChronologicValidator
            Get
                Return _BaseValidator
            End Get
        End Property



        Public Function GetDate(ByVal WarehouseID As Integer, _
            ByVal ChronologyType As OperationChronologyType, _
            ByVal OperationType As GoodsOperationType) As Date

            For Each i As OperationalLimit In Me
                If i.OperationType = OperationType AndAlso (Not WarehouseID > 0 _
                    OrElse i.WarehouseID = WarehouseID OrElse _
                    Not OperationTypeIsWarehouseDependent(i.OperationType)) AndAlso _
                    i.ChronologyType = ChronologyType Then Return i.[Date]
            Next
            Return Date.MinValue

        End Function

        Public Function GetMaxDate(ByVal WarehouseID As Integer, _
            ByVal ChronologyType As OperationChronologyType, _
            ByVal ParamArray OperationTypes As GoodsOperationType()) As Date

            Dim result As Date = Date.MinValue

            If OperationTypes Is Nothing Then

                For Each i As OperationalLimit In Me
                    If (Not WarehouseID > 0 OrElse i.WarehouseID = WarehouseID OrElse _
                        Not OperationTypeIsWarehouseDependent(i.OperationType)) AndAlso _
                        i.ChronologyType = ChronologyType AndAlso i.[Date].Date > result.Date Then _
                        result = i.[Date]
                Next

            Else

                For Each i As OperationalLimit In Me
                    If (Not WarehouseID > 0 OrElse i.WarehouseID = WarehouseID OrElse _
                        Not OperationTypeIsWarehouseDependent(i.OperationType)) AndAlso _
                        i.ChronologyType = ChronologyType AndAlso Not Array.IndexOf( _
                        OperationTypes, i.OperationType) < 0 AndAlso i.[Date].Date > result.Date Then _
                        result = i.[Date]
                Next

            End If

            Return result

        End Function

        Public Function GetMinDate(ByVal WarehouseID As Integer, _
            ByVal ChronologyType As OperationChronologyType, _
            ByVal ParamArray OperationTypes As GoodsOperationType()) As Date

            Dim result As Date = Date.MaxValue

            If OperationTypes Is Nothing Then

                For Each i As OperationalLimit In Me
                    If (Not WarehouseID > 0 OrElse i.WarehouseID = WarehouseID OrElse _
                        Not OperationTypeIsWarehouseDependent(i.OperationType)) AndAlso _
                        i.ChronologyType = ChronologyType AndAlso i.[Date].Date < result.Date Then _
                        result = i.[Date]
                Next

            Else

                For Each i As OperationalLimit In Me
                    If (Not WarehouseID > 0 OrElse i.WarehouseID = WarehouseID OrElse _
                        Not OperationTypeIsWarehouseDependent(i.OperationType)) AndAlso _
                        i.ChronologyType = ChronologyType AndAlso Not Array.IndexOf( _
                        OperationTypes, i.OperationType) < 0 AndAlso i.[Date].Date < result.Date Then _
                        result = i.[Date]
                Next

            End If

            Return result

        End Function


        Public Function ValidateOperationDate(ByVal operationDate As Date, _
            ByRef errorMessage As String, ByRef errorSeverity As Csla.Validation.RuleSeverity) As Boolean _
            Implements IChronologicValidator.ValidateOperationDate

            If _MinDateApplicable AndAlso operationDate.Date < _MinDate.Date Then
                errorMessage = _MinDateExplanation
                errorSeverity = Validation.RuleSeverity.Error
                Return False
            ElseIf _MaxDateApplicable AndAlso operationDate.Date > _MaxDate.Date Then
                errorMessage = _MaxDateExplanation
                errorSeverity = Validation.RuleSeverity.Error
                Return False
            End If

            Dim lastPriceCut As Date = GetDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.PriceCut)

            If lastPriceCut <> Date.MinValue AndAlso (operationDate.Date < lastPriceCut.Date _
                OrElse (_CurrentOperationID > 0 AndAlso _CurrentOperationDate.Date < lastPriceCut.Date)) Then
                errorMessage = Goods_OperationalLimitList_CouldAffectSubsequentPriceCutWarning
                errorSeverity = Validation.RuleSeverity.Warning
                Return False
            End If

            Return True

        End Function

        Public Function GetBackgroundDescription() As String

            Dim result As String = ""

            Dim tmpResult As String = ""

            For Each i As OperationalLimit In Me
                If i.ChronologyType = OperationChronologyType.Overall AndAlso _
                   (Not _CurrentWarehouseID > 0 OrElse i.WarehouseID = _CurrentWarehouseID _
                    OrElse Not OperationTypeIsWarehouseDependent(i.OperationType)) Then

                    tmpResult = AddWithNewLine(tmpResult, String.Format("{0} - {1}", _
                        ConvertLocalizedName(i.OperationType), i.Date.ToString("yyyy-MM-dd")), False)

                End If
            Next

            If Not String.IsNullOrEmpty(tmpResult.Trim) Then
                result = String.Format(Goods_OperationalLimitList_LastOperationsInWarehouseDescription, _
                    vbCrLf, tmpResult)
            End If

            If Not _CurrentOperationID > 0 Then Return result

            tmpResult = ""

            For Each i As OperationalLimit In Me
                If i.ChronologyType = OperationChronologyType.LastBefore AndAlso _
                   (Not _CurrentWarehouseID > 0 OrElse i.WarehouseID = CurrentWarehouseID _
                    OrElse Not OperationTypeIsWarehouseDependent(i.OperationType)) Then

                    tmpResult = AddWithNewLine(tmpResult, String.Format("{0} - {1}", _
                        ConvertLocalizedName(i.OperationType), i.Date.ToString("yyyy-MM-dd")), False)

                End If
            Next

            If Not String.IsNullOrEmpty(tmpResult.Trim) Then

                If Not String.IsNullOrEmpty(result.Trim) Then
                    result = String.Format(Goods_OperationalLimitList_LastOperationsInWarehouseBeforeTheCurrentOperationDescription, _
                        result, vbCrLf, vbCrLf, vbCrLf, tmpResult)
                Else
                    result = String.Format(Goods_OperationalLimitList_LastOperationsInWarehouseBeforeTheCurrentOperationDescription, _
                        "", "", "", vbCrLf, tmpResult)
                End If

            End If

            tmpResult = ""

            For Each i As OperationalLimit In Me
                If i.ChronologyType = OperationChronologyType.FirstAfter AndAlso _
                   (Not _CurrentWarehouseID > 0 OrElse i.WarehouseID = CurrentWarehouseID _
                    OrElse Not OperationTypeIsWarehouseDependent(i.OperationType)) Then

                    tmpResult = AddWithNewLine(tmpResult, String.Format("{0} - {1}", _
                        ConvertLocalizedName(i.OperationType), i.Date.ToString("yyyy-MM-dd")), False)

                End If
            Next

            If Not String.IsNullOrEmpty(tmpResult.Trim) Then

                If Not String.IsNullOrEmpty(result.Trim) Then
                    result = String.Format(Goods_OperationalLimitList_FirstOperationsInWarehouseAfterTheCurrentOperationDescription, _
                        result, vbCrLf, vbCrLf, vbCrLf, tmpResult)
                Else
                    result = String.Format(Goods_OperationalLimitList_FirstOperationsInWarehouseAfterTheCurrentOperationDescription, _
                        "", "", "", vbCrLf, tmpResult)
                End If

            End If

            Return result

        End Function


        Public Shared Function OperationTypeIsWarehouseDependent(ByVal value As GoodsOperationType) As Boolean
            Return (value <> GoodsOperationType.AccountDiscountsChange AndAlso _
                value <> GoodsOperationType.AccountPurchasesChange AndAlso _
                value <> GoodsOperationType.AccountSalesNetCostsChange AndAlso _
                value <> GoodsOperationType.AccountValueReductionChange AndAlso _
                value <> GoodsOperationType.PriceCut AndAlso _
                value <> GoodsOperationType.ValuationMethodChange AndAlso _
                value <> GoodsOperationType.TransferOfBalance)
        End Function


        Friend Sub SetWarehouse(ByVal warehouse As WarehouseInfo)

            If _CurrentOperationID > 0 OrElse warehouse Is Nothing OrElse _
                warehouse.IsEmpty Then Exit Sub

            _CurrentWarehouseID = warehouse.ID
            FetchLimitations()

        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new OperationalLimitList instance for a new goods operation.
        ''' </summary>
        ''' <param name="goodsSummary">general information about the goods
        ''' that the validated (parent) goods operation object operates with</param>
        ''' <param name="operationType">a type of the validated (parent) goods operation</param>
        ''' <param name="warehouseID">an <see cref="Warehouse.ID">ID of the warehouse</see> 
        ''' that the validated (parent) goods operation object operates in</param>
        ''' <param name="parentValidator">an operation's parent document 
        ''' IChronologicValidator if any</param>
        ''' <remarks></remarks>
        Friend Shared Function NewOperationalLimitList(ByVal goodsSummary As GoodsSummary, _
            ByVal operationType As GoodsOperationType, ByVal warehouseID As Integer, _
            ByVal parentValidator As IChronologicValidator) As OperationalLimitList
            Return New OperationalLimitList(goodsSummary, operationType, _
                warehouseID, parentValidator)
        End Function

        ''' <summary>
        ''' Gets a new OperationalLimitList instance for an existing goods operation.
        ''' </summary>
        ''' <param name="goodsSummary">general information about the goods
        ''' that the validated (parent) goods operation object operates with</param>
        ''' <param name="operationType">a type of the validated (parent) goods operation</param>
        ''' <param name="operationID">an ID of the validated (parent) goods operation</param>
        ''' <param name="operationDate">a date of the validated (parent) goods operation</param>
        ''' <param name="warehouseID">an <see cref="Warehouse.ID">ID of the warehouse</see> 
        ''' that the validated (parent) goods operation object operates in</param>
        ''' <param name="parentValidator">an operation's parent document 
        ''' IChronologicValidator if any</param>
        ''' <param name="dataSource">a datasource containing information about
        ''' the goods operations chronology if any</param>
        ''' <remarks>Use <see cref="GetDataSourceForComplexOperation">GetDataSourceForComplexOperation</see>
        ''' method to fetch a datasource for the complex goods operation child operations.</remarks>
        Friend Shared Function GetOperationalLimitList(ByVal goodsSummary As GoodsSummary, _
            ByVal operationType As GoodsOperationType, ByVal operationID As Integer, _
            ByVal operationDate As Date, ByVal warehouseID As Integer, _
            ByVal parentValidator As IChronologicValidator, ByVal dataSource As DataTable) As OperationalLimitList
            Return New OperationalLimitList(goodsSummary, operationType, operationID, _
                operationDate, warehouseID, parentValidator, dataSource)
        End Function

        ''' <summary>
        ''' Gets a new OperationalLimitList instance by reloading chronology data
        ''' into the current OperationalLimitList instance.
        ''' </summary>
        ''' <param name="currentOperationalLimitList">current OperationalLimitList instance</param>
        ''' <param name="parentValidator">an operation's parent document 
        ''' IChronologicValidator if any</param>
        ''' <param name="dataSource">a datasource containing information about
        ''' the goods operations chronology if any</param>
        ''' <remarks></remarks>
        Friend Shared Function GetUpdatedOperationalLimitList( _
            ByVal currentOperationalLimitList As OperationalLimitList, _
            ByVal parentValidator As IChronologicValidator, _
            ByVal dataSource As DataTable) As OperationalLimitList
            Return New OperationalLimitList(currentOperationalLimitList, parentValidator, dataSource)
        End Function

        ''' <summary>
        ''' Gets a datasource that could be used to bulk fetch chronology validators
        ''' for a complex goods operation child operations.
        ''' </summary>
        ''' <param name="complexOperationID">an <see cref="ComplexOperationPersistenceObject.ID">
        ''' ID of the complex goods operation</see> that the datasource should be fetched for</param>
        ''' <param name="complexOperationDate">a <see cref="ComplexOperationPersistenceObject.OperationDate">
        ''' date of the complex goods operation</see> that the datasource should be fetched for</param>
        ''' <remarks></remarks>
        Friend Shared Function GetDataSourceForComplexOperation(ByVal complexOperationID As Integer, _
            ByVal complexOperationDate As Date) As DataTable

            Dim myComm As New SQLCommand("FetchOperationalLimitListOldComplex")
            myComm.AddParam("?CD", complexOperationID)
            myComm.AddParam("?DT", complexOperationDate.Date)

            Return myComm.Fetch

        End Function

        Friend Shared Function GetDataSourceForNewInventorization(ByVal warehouseID As Integer) As DataTable

            Dim myComm As New SQLCommand("FetchOperationalLimitListNewInventorization")
            myComm.AddParam("?WD", warehouseID)

            Return myComm.Fetch

        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal goodsSummary As GoodsSummary, _
            ByVal operationType As GoodsOperationType, ByVal warehouseID As Integer, _
            ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            Create(goodsSummary, operationType, warehouseID, parentValidator)
        End Sub

        Private Sub New(ByVal goodsSummary As GoodsSummary, _
            ByVal operationType As GoodsOperationType, ByVal operationID As Integer, _
            ByVal operationDate As Date, ByVal warehouseID As Integer, _
            ByVal parentValidator As IChronologicValidator, ByVal dataSource As DataTable)
            ' require use of factory methods
            Fetch(goodsSummary, operationType, operationID, operationDate, _
                warehouseID, parentValidator, dataSource)
        End Sub

        Private Sub New(ByVal currentOperationalLimitList As OperationalLimitList, _
            ByVal parentValidator As IChronologicValidator, ByVal dataSource As DataTable)
            ' require use of factory methods
            Update(currentOperationalLimitList, parentValidator, dataSource)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal goodsSummary As GoodsSummary, _
            ByVal operationType As GoodsOperationType, ByVal warehouseID As Integer, _
            ByVal parentValidator As IChronologicValidator)

            If goodsSummary Is Nothing OrElse Not goodsSummary.ID > 0 Then
                Throw New ArgumentNullException("goodsSummary")
            End If

            _CurrentOperationType = operationType
            _CurrentValuationMethod = goodsSummary.ValuationMethod
            _CurrentAccountingMethod = goodsSummary.AccountingMethod
            _CurrentOperationID = 0
            _CurrentGoodsID = goodsSummary.ID
            _CurrentOperationDate = Today
            _CurrentWarehouseID = warehouseID
            SetOperationName(goodsSummary, operationType)

            Using myData As DataTable = GetDataSource()

                DoFetch(parentValidator, myData)

            End Using

        End Sub

        Private Sub Fetch(ByVal goodsSummary As GoodsSummary, _
            ByVal operationType As GoodsOperationType, ByVal operationID As Integer, _
            ByVal operationDate As Date, ByVal warehouseID As Integer, _
            ByVal parentValidator As IChronologicValidator, ByVal dataSource As DataTable)

            If goodsSummary Is Nothing OrElse Not goodsSummary.ID > 0 Then
                Throw New ArgumentNullException("goodsSummary")
            ElseIf Not operationID > 0 Then
                Throw New ArgumentNullException("operationID")
            End If

            _CurrentOperationType = operationType
            _CurrentValuationMethod = goodsSummary.ValuationMethod
            _CurrentAccountingMethod = goodsSummary.AccountingMethod
            _CurrentOperationID = operationID
            _CurrentGoodsID = goodsSummary.ID
            _CurrentOperationDate = operationDate
            _CurrentWarehouseID = warehouseID
            SetOperationName(goodsSummary, operationType)

            If dataSource Is Nothing Then

                Using myData As DataTable = GetDataSource()

                    DoFetch(parentValidator, myData)

                End Using

            Else

                DoFetch(parentValidator, dataSource)

            End If

        End Sub

        Private Sub Update(ByVal currentOperationalLimitList As OperationalLimitList, _
            ByVal parentValidator As IChronologicValidator, ByVal dataSource As DataTable)

            _CurrentOperationType = currentOperationalLimitList.CurrentOperationType
            _CurrentValuationMethod = currentOperationalLimitList.CurrentValuationMethod
            _CurrentAccountingMethod = currentOperationalLimitList.CurrentAccountingMethod
            _CurrentOperationID = currentOperationalLimitList.CurrentOperationID
            _CurrentGoodsID = currentOperationalLimitList.CurrentGoodsID
            _CurrentOperationDate = currentOperationalLimitList.CurrentOperationDate
            _CurrentWarehouseID = currentOperationalLimitList.CurrentWarehouseID
            _CurrentOperationName = currentOperationalLimitList.CurrentOperationName

            If dataSource Is Nothing OrElse Not _CurrentOperationID > 0 Then

                Using myData As DataTable = GetDataSource()

                    DoFetch(parentValidator, myData)

                End Using

            Else

                DoFetch(parentValidator, dataSource)

            End If

        End Sub

        Private Sub DoFetch(ByVal parentValidator As IChronologicValidator, _
            ByVal myData As DataTable)

            RaiseListChangedEvents = False
            IsReadOnly = False

            _BaseValidator = parentValidator
            If _BaseValidator Is Nothing AndAlso _CurrentOperationType <> GoodsOperationType.Acquisition _
                AndAlso _CurrentOperationType <> GoodsOperationType.RedeemFromBuyer _
                AndAlso _CurrentOperationType <> GoodsOperationType.ConsignmentAdditionalCosts _
                AndAlso _CurrentOperationType <> GoodsOperationType.ConsignmentDiscount _
                AndAlso _CurrentOperationType <> GoodsOperationType.Inventorization _
                AndAlso _CurrentOperationType <> GoodsOperationType.Transfer _
                AndAlso _CurrentOperationType <> GoodsOperationType.ValuationMethodChange _
                AndAlso (_CurrentOperationType <> GoodsOperationType.Discard OrElse _
                _CurrentAccountingMethod = GoodsAccountingMethod.Persistent) Then

                _BaseValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                    _CurrentOperationID, _CurrentOperationDate, _CurrentOperationName, Nothing)

            End If

            _ConsignmentWasUsed = False
            _ConsignmentWasUsedDate = Date.MaxValue

            For Each dr As DataRow In myData.Rows
                If CIntSafe(dr.Item(0), 0) = _CurrentGoodsID Then
                    If CIntSafe(dr.Item(1), 0) = 999 Then
                        _ConsignmentWasUsed = ConvertDbBoolean(CIntSafe(dr.Item(2), 0))
                        _ConsignmentWasUsedDate = CDateSafe(dr.Item(3), Date.MaxValue)
                    ElseIf Not ExcludeItem(dr, _CurrentOperationID, _CurrentOperationDate) Then
                        Add(OperationalLimit.GetOperationalLimit(dr))
                    End If
                End If
            Next

            FetchLimitations()

            _BackgroundExplanation = GetBackgroundDescription()

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

        Private Sub SetOperationName(ByVal goodsSummary As GoodsSummary, _
            ByVal operationType As GoodsOperationType)
            _CurrentOperationName = String.Format("{0} {1}", goodsSummary.Name, _
                ConvertLocalizedName(operationType))
        End Sub

        Private Function GetDataSource() As DataTable

            Dim myComm As SQLCommand

            If _CurrentOperationID > 0 Then

                myComm = New SQLCommand("FetchOperationalLimitListOld")
                myComm.AddParam("?DT", _CurrentOperationDate.Date)

                If _CurrentOperationType = GoodsOperationType.AccountDiscountsChange _
                    OrElse _CurrentOperationType = GoodsOperationType.AccountPurchasesChange _
                    OrElse _CurrentOperationType = GoodsOperationType.AccountSalesNetCostsChange _
                    OrElse _CurrentOperationType = GoodsOperationType.AccountValueReductionChange Then
                    myComm.AddParam("?OD", 0)
                    myComm.AddParam("?VD", 0)
                    myComm.AddParam("?AD", _CurrentOperationID)
                ElseIf _CurrentOperationType = GoodsOperationType.ValuationMethodChange Then
                    myComm.AddParam("?OD", 0)
                    myComm.AddParam("?VD", _CurrentOperationID)
                    myComm.AddParam("?AD", 0)
                Else
                    myComm.AddParam("?OD", _CurrentOperationID)
                    myComm.AddParam("?VD", 0)
                    myComm.AddParam("?AD", 0)
                End If
                myComm.AddParam("?GD", _CurrentGoodsID)

            Else

                myComm = New SQLCommand("FetchOperationalLimitListNew")
                myComm.AddParam("?GD", _CurrentGoodsID)

            End If

            Return myComm.Fetch()

        End Function


        Private Function ExcludeItem(ByVal dr As DataRow, ByVal operationID As Integer, _
            ByVal operationDate As Date) As Boolean

            If Not operationID > 0 Then Return False

            Dim currentType As GoodsOperationType = ConvertDatabaseID(Of GoodsOperationType) _
                (CIntSafe(dr.Item(1), 0))
            Dim currentDate As Date = CDateSafe(dr.Item(3), Date.MinValue)

            If currentDate = Date.MinValue Then Return True

            ' ???
            If currentDate.Date = operationDate.Date _
                AndAlso currentType <> GoodsOperationType.AccountDiscountsChange _
                AndAlso currentType <> GoodsOperationType.AccountPurchasesChange _
                AndAlso currentType <> GoodsOperationType.AccountSalesNetCostsChange _
                AndAlso currentType <> GoodsOperationType.Inventorization _
                AndAlso currentType <> GoodsOperationType.ValuationMethodChange Then

                Return True

            End If

            Return False

        End Function


        Private Sub FetchLimitations()

            SetDefaults()

            If _CurrentOperationID > 0 Then

                Select Case _CurrentOperationType
                    Case GoodsOperationType.Acquisition
                        FetchLimitationsForOldAcquisition()
                    Case GoodsOperationType.Transfer, GoodsOperationType.Discard
                        FetchLimitationsForOldTransferDiscard()
                    Case GoodsOperationType.ConsignmentAdditionalCosts
                        FetchLimitationsForOldAdditionalCosts()
                    Case GoodsOperationType.ConsignmentDiscount
                        FetchLimitationsForOldDiscount()
                    Case GoodsOperationType.Inventorization
                        FetchLimitationsForOldInventorization()
                    Case GoodsOperationType.ValuationMethodChange
                        FetchLimitationsForOldValuationMethod()
                    Case GoodsOperationType.PriceCut
                        FetchLimitationsForOldPriceCut()
                    Case GoodsOperationType.AccountValueReductionChange
                        FetchLimitationsForOldAccountValueReduction()
                    Case GoodsOperationType.AccountDiscountsChange
                        FetchLimitationsForOldAccountDiscounts()
                    Case GoodsOperationType.AccountPurchasesChange
                        FetchLimitationsForOldAccountPurchases()
                    Case GoodsOperationType.AccountSalesNetCostsChange
                        FetchLimitationsForOldAccountSalesNetCosts()
                    Case GoodsOperationType.TransferOfBalance
                        FetchLimitationsForOldTransferOfBalance()
                    Case GoodsOperationType.RedeemFromBuyer
                        FetchLimitationsForOldRedeemFromBuyer()
                    Case Else
                        Throw New NotImplementedException("Prekių operacijos tipas '" _
                            & _CurrentOperationType.ToString & "' neimplementuotas metode " _
                            & "OperationalLimitList.FetchLimitations .")
                End Select

            Else

                Select Case _CurrentOperationType
                    Case GoodsOperationType.Acquisition
                        FetchLimitationsForNewAcquisition()
                    Case GoodsOperationType.Transfer, GoodsOperationType.Discard
                        FetchLimitationsForNewTransferDiscard()
                    Case GoodsOperationType.ConsignmentAdditionalCosts
                        FetchLimitationsForNewAdditionalCosts()
                    Case GoodsOperationType.ConsignmentDiscount
                        FetchLimitationsForNewDiscount()
                    Case GoodsOperationType.Inventorization
                        FetchLimitationsForNewInventorization()
                    Case GoodsOperationType.ValuationMethodChange
                        FetchLimitationsForNewValuationMethod()
                    Case GoodsOperationType.PriceCut
                        FetchLimitationsForNewPriceCut()
                    Case GoodsOperationType.AccountValueReductionChange
                        FetchLimitationsForNewAccountValueReduction()
                    Case GoodsOperationType.AccountDiscountsChange
                        FetchLimitationsForNewAccountDiscounts()
                    Case GoodsOperationType.AccountPurchasesChange
                        FetchLimitationsForNewAccountPurchases()
                    Case GoodsOperationType.AccountSalesNetCostsChange
                        FetchLimitationsForNewAccountSalesNetCosts()
                    Case GoodsOperationType.TransferOfBalance
                        FetchLimitationsForNewTransferOfBalance()
                    Case GoodsOperationType.RedeemFromBuyer
                        FetchLimitationsForNewRedeemFromBuyer()
                    Case Else
                        Throw New NotImplementedException("Prekių operacijos tipas '" _
                            & _CurrentOperationType.ToString & "' neimplementuotas metode " _
                            & "OperationalLimitList.FetchLimitations .")
                End Select

            End If

            If _CurrentOperationType <> GoodsOperationType.TransferOfBalance Then

                SetMinDateApplicable(GetMinDate(_CurrentWarehouseID, OperationChronologyType.Overall, _
                    GoodsOperationType.TransferOfBalance), "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota prekių likučių perkėlimo " _
                    & "operacija.", True)

            End If

            If Not _BaseValidator Is Nothing AndAlso _
                (_CurrentOperationType = GoodsOperationType.AccountDiscountsChange _
                OrElse _CurrentOperationType = GoodsOperationType.AccountPurchasesChange _
                OrElse _CurrentOperationType = GoodsOperationType.AccountSalesNetCostsChange _
                OrElse _CurrentOperationType = GoodsOperationType.AccountValueReductionChange _
                OrElse _CurrentOperationType = GoodsOperationType.PriceCut _
                OrElse (_CurrentOperationType = GoodsOperationType.Discard AndAlso _
                _CurrentAccountingMethod = GoodsAccountingMethod.Persistent)) Then

                If Not _BaseValidator.FinancialDataCanChange Then

                    _FinancialDataCanChange = False
                    _FinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                        _BaseValidator.FinancialDataCanChangeExplanation, False)
                    _ParentFinancialDataCanChange = False
                    _ParentFinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                        _BaseValidator.FinancialDataCanChangeExplanation, False)

                End If

                If _BaseValidator.MaxDateApplicable Then SetMaxDateApplicable( _
                    _BaseValidator.MaxDate, _BaseValidator.MaxDateExplanation, False)

                If _BaseValidator.MinDateApplicable Then SetMinDateApplicable( _
                    _BaseValidator.MinDate, _BaseValidator.MinDateExplanation, False)

            End If

            SetLimitsExplanation()

        End Sub

        Private Sub SetDefaults()

            _FinancialDataCanChange = True
            _FinancialDataCanChangeExplanation = ""
            _ParentFinancialDataCanChange = True
            _ParentFinancialDataCanChangeExplanation = ""

            _MaxDateApplicable = False
            _MaxDate = Date.MaxValue
            _MaxDateExplanation = ""

            _MinDateApplicable = False
            _MinDate = Date.MinValue
            _MinDateExplanation = ""

            _LimitsExplanation = ""

        End Sub

        Private Sub SetMaxDateApplicable(ByVal nDate As Date, ByVal explanation As String, _
            ByVal addOneDay As Boolean)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue Then Exit Sub

            If addOneDay Then nDate = nDate.AddDays(-1)

            If Not nDate.Date < _MaxDate.Date Then Exit Sub

            _MaxDateApplicable = True
            _MaxDate = nDate.Date
            _MaxDateExplanation = explanation.Replace(DatePlaceHolder, nDate.ToString("yyyy-MM-dd"))

        End Sub

        Private Sub SetMinDateApplicable(ByVal nDate As Date, ByVal explanation As String, _
            ByVal addOneDay As Boolean)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue Then Exit Sub

            If addOneDay Then nDate = nDate.AddDays(1)

            If Not nDate.Date > _MinDate.Date Then Exit Sub

            _MinDateApplicable = True
            _MinDate = nDate.Date
            _MinDateExplanation = explanation.Replace(DatePlaceHolder, nDate.ToString("yyyy-MM-dd"))

        End Sub

        Private Sub SetFinancialDataCanChange(ByVal nDate As Date, ByVal explanation As String, _
            ByVal dateExplanation As String, ByVal addOneDay As Boolean)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue _
                OrElse StringIsNullOrEmpty(explanation) Then Exit Sub

            _FinancialDataCanChange = False
            _FinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                explanation, False)

            SetMaxDateApplicable(nDate, dateExplanation, addOneDay)

        End Sub

        Private Sub SetLimitsExplanation()

            _LimitsExplanation = ""

            If Not _FinancialDataCanChange Then
                _LimitsExplanation = _FinancialDataCanChangeExplanation
            End If
            If _MinDateApplicable Then
                _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MinDateExplanation, False)
            End If
            If _MaxDateApplicable Then
                _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MaxDateExplanation, False)
            End If

        End Sub


        Private Sub FetchLimitationsForNewAcquisition()

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.Inventorization)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForOldAcquisition()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            If _ConsignmentWasUsed Then SetFinancialDataCanChange(_ConsignmentWasUsedDate, _
                "Finansinių operacijos duomenų keisti negalima, nes kita operacija panaudojo " _
                & "šią prekių partiją.", "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes kita operacija panaudojo šią prekių partiją.", False)

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota inventorizacijos operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota inventorizacijos operacija.", False)

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.AccountPurchasesChange)

                SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota apskaitos sąskaitų pakeitimo operacija.", False)

            Else

                Dim ValuationMethodDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.ValuationMethodChange)

                SetFinancialDataCanChange(ValuationMethodDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota vertinimo metodo pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota vertinimo metodo pakeitimo operacija.", False)

            End If

            ' Check for subsequent operations that create max date limit without preventing financial changes

            If InventorizationDate <> Date.MinValue AndAlso InventorizationDate <> Date.MaxValue Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių operacija (-os), " _
                    & "o vėlesne data yra registruota inventorizacijos operacija.", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent AndAlso _
                Me._CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių įsigijimo ir/ar " _
                    & "perleidimo ir/ar nurašymo operacija (-os).", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Discard, _
                    GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                    GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių " _
                    & "perleidimo ir/ar nurašymo operacija (-os).", False)

            End If

            ' Check for preceding operations that create min date limit 

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.Inventorization)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForNewTransferDiscard()

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota inventorizacijos operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForOldTransferDiscard()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota inventorizacijos operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota inventorizacijos operacija.", False)

            If _CurrentAccountingMethod = GoodsAccountingMethod.Persistent Then

                Dim ValuationMethodDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.ValuationMethodChange)

                SetFinancialDataCanChange(ValuationMethodDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota vertinimo metodo pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota vertinimo metodo pakeitimo operacija.", False)

            End If

            ' Check for subsequent operations that create max date limit without preventing financial changes

            If InventorizationDate <> Date.MinValue AndAlso InventorizationDate <> Date.MaxValue Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių operacija (-os), " _
                    & "o vėlesne data yra registruota inventorizacijos operacija.", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent AndAlso _
                Me._CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių įsigijimo ir/ar " _
                    & "perleidimo ir/ar nurašymo ir/arba savikainos padidinimo ir/arba nuolaidos operacija (-os).", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Discard, _
                    GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                    GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių " _
                    & "perleidimo ir/ar nurašymo ir/arba savikainos padidinimo ir/arba nuolaidos operacija (-os).", False)

            End If

            ' Check for preceding operations that create min date limit 

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.Inventorization)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota inventorizacijos operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForNewAdditionalCosts()

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                    GoodsOperationType.AccountPurchasesChange, GoodsOperationType.AccountSalesNetCostsChange)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota inventorizacijos " _
                    & "ir/ar apskaitos sąskaitų pakeitimo operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForOldAdditionalCosts()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            If _ConsignmentWasUsed Then SetFinancialDataCanChange(_ConsignmentWasUsedDate, _
                "Finansinių operacijos duomenų keisti negalima, nes kita operacija panaudojo " _
                & "šią prekių partiją.", "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes kita operacija panaudojo šią prekių partiją.", False)

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota inventorizacijos operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota inventorizacijos operacija.", False)

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.AccountSalesNetCostsChange)

                SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota apskaitos sąskaitų pakeitimo operacija.", False)

            Else

                Dim ValuationMethodDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.ValuationMethodChange)

                SetFinancialDataCanChange(ValuationMethodDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota vertinimo metodo pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota vertinimo metodo pakeitimo operacija.", False)

            End If

            ' Check for subsequent operations that create max date limit without preventing financial changes

            If InventorizationDate <> Date.MinValue AndAlso InventorizationDate <> Date.MaxValue Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių operacija (-os), " _
                    & "o vėlesne data yra registruota inventorizacijos operacija.", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent AndAlso _
                Me._CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių įsigijimo ir/ar " _
                    & "perleidimo ir/ar nurašymo operacija (-os).", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Discard, _
                    GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                    GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių " _
                    & "perleidimo ir/ar nurašymo operacija (-os).", False)

            End If

            ' Check for preceding operations that create min date limit 

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.Inventorization, GoodsOperationType.AccountSalesNetCostsChange)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForNewDiscount()

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                    GoodsOperationType.AccountDiscountsChange, GoodsOperationType.AccountSalesNetCostsChange)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota inventorizacijos " _
                    & "ir/ar apskaitos sąskaitų pakeitimo operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForOldDiscount()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            If _ConsignmentWasUsed Then SetFinancialDataCanChange(_ConsignmentWasUsedDate, _
                "Finansinių operacijos duomenų keisti negalima, nes kita operacija panaudojo " _
                & "šią prekių partiją.", "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes kita operacija panaudojo šią prekių partiją.", False)

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota inventorizacijos operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota inventorizacijos operacija.", False)

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.AccountDiscountsChange, _
                    GoodsOperationType.AccountSalesNetCostsChange)

                SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota apskaitos sąskaitų pakeitimo operacija.", False)

            Else

                Dim ValuationMethodDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.ValuationMethodChange)

                SetFinancialDataCanChange(ValuationMethodDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota vertinimo metodo pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota vertinimo metodo pakeitimo operacija.", False)

            End If

            ' Check for subsequent operations that create max date limit without preventing financial changes

            If InventorizationDate <> Date.MinValue AndAlso InventorizationDate <> Date.MaxValue Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių operacija (-os), " _
                    & "o vėlesne data yra registruota inventorizacijos operacija.", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent AndAlso _
                Me._CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių įsigijimo ir/ar " _
                    & "perleidimo ir/ar nurašymo operacija (-os).", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Discard, _
                    GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                    GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių " _
                    & "perleidimo ir/ar nurašymo operacija (-os).", False)

            End If

            ' Check for preceding operations that create min date limit 

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.AccountDiscountsChange, _
                    GoodsOperationType.Inventorization, GoodsOperationType.AccountSalesNetCostsChange)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForNewInventorization()

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.AccountDiscountsChange, _
                    GoodsOperationType.AccountSalesNetCostsChange, _
                    GoodsOperationType.Inventorization, GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                    & "ir/arba apskaitos sąskaitos pakeitimo ir/arba inventorizacijos ir/arba " _
                    & "vertinimo metodo pakeitimo operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            End If

            Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.Acquisition, _
                GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

            SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes šia data yra registruota prekių operacijų.", False)

        End Sub

        Private Sub FetchLimitationsForOldInventorization()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            If _ConsignmentWasUsed Then SetFinancialDataCanChange(_ConsignmentWasUsedDate, _
                "Finansinių operacijos duomenų keisti negalima, nes kita operacija panaudojo " _
                & "šią prekių partiją.", "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes kita operacija panaudojo šią prekių partiją.", False)

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota inventorizacijos operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota inventorizacijos operacija.", False)

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.AccountSalesNetCostsChange, GoodsOperationType.AccountDiscountsChange, _
                    GoodsOperationType.ValuationMethodChange)

                SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo " _
                    & "ir/ar vertinimo metodo pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota apskaitos sąskaitų pakeitimo ir/ar vertinimo metodo pakeitimo operacija.", False)

            Else

                Dim ValuationMethodDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.ValuationMethodChange)

                SetFinancialDataCanChange(ValuationMethodDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota vertinimo metodo pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota vertinimo metodo pakeitimo operacija.", False)

            End If

            ' Check for subsequent operations that create max date limit without preventing financial changes

            Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

            SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes po jos yra registruota prekių įsigijimo ir/ar " _
                & "perleidimo ir/ar nurašymo operacija (-os).", True)

            ' Check for preceding operations that create min date limit 

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.Inventorization, GoodsOperationType.AccountDiscountsChange, _
                    GoodsOperationType.AccountSalesNetCostsChange)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            End If

            Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.Acquisition, _
                GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

            SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

        End Sub

        Private Sub FetchLimitationsForNewValuationMethod()

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                GoodsOperationType.ValuationMethodChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota inventorizacijos " _
                & "ir/ar vertinimo metodo pakeitimo operacija.", True)

            If _CurrentAccountingMethod = GoodsAccountingMethod.Persistent Then

                Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Acquisition, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                    & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", True)

            End If

        End Sub

        Private Sub FetchLimitationsForOldValuationMethod()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota inventorizacijos operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota inventorizacijos operacija.", False)

            Dim ValuationMethodDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.ValuationMethodChange)

            SetFinancialDataCanChange(ValuationMethodDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota vertinimo metodo pakeitimo operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes po jos " _
                & "yra registruota vertinimo metodo pakeitimo operacija.", True)

            ' Check for subsequent operations that create max date limit without preventing financial changes

            Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

            SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes po jos yra registruota prekių įsigijimo ir/ar " _
                & "perleidimo ir/ar nurašymo operacija (-os).", True)

            ' Check for preceding operations that create min date limit 

            Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.Inventorization, _
                GoodsOperationType.ValuationMethodChange)

            SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes šia data yra registruota vertinimo metodo pakeitimo " _
                & "ir/arba inventorizacijos operacija.", True)

            Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.Acquisition, _
                GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

            SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes po jos yra registruota įsigijimo ir/arba nurašymo " _
                & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", True)

        End Sub

        Private Sub FetchLimitationsForNewPriceCut()

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.AccountValueReductionChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

        End Sub

        Private Sub FetchLimitationsForOldPriceCut()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.AccountValueReductionChange)

            SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes po to " _
                & "yra registruota apskaitos sąskaitų pakeitimo operacija.", True)

            ' Check for subsequent operations that create max date limit without preventing financial changes

            ' NONE

            ' Check for preceding operations that create min date limit 

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.AccountValueReductionChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

        End Sub

        Private Sub FetchLimitationsForNewAccountValueReduction()

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.AccountValueReductionChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.Overall, _
                GoodsOperationType.PriceCut)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota nukainojimo operacija.", False)

        End Sub

        Private Sub FetchLimitationsForOldAccountValueReduction()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.AccountValueReductionChange, _
                GoodsOperationType.PriceCut)

            SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo ir/ar nukainojimo operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes po to " _
                & "yra registruota apskaitos sąskaitų pakeitimo ir/ar nukainojimo operacija.", True)

            ' Check for subsequent operations that create max date limit without preventing financial changes

            ' NONE

            ' Check for preceding operations that create min date limit 

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.AccountValueReductionChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.LastBefore, _
                GoodsOperationType.PriceCut)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota nukainojimo operacija.", False)

        End Sub

        Private Sub FetchLimitationsForNewAccountDiscounts()

            If _CurrentAccountingMethod <> GoodsAccountingMethod.Periodic Then Exit Sub

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.AccountDiscountsChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.Overall, _
                GoodsOperationType.Inventorization, GoodsOperationType.ConsignmentDiscount)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota nuolaidos ir/arba " _
                & "inventorizacijos operacija.", False)

        End Sub

        Private Sub FetchLimitationsForOldAccountDiscounts()

            If _CurrentAccountingMethod <> GoodsAccountingMethod.Periodic Then Exit Sub

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization, _
                GoodsOperationType.ConsignmentDiscount)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes šia data yra registruota inventorizacijos ir/ar nuolaidos operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota inventorizacijos ir/ar nuolaidos operacija.", False)

            Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.AccountDiscountsChange)

            SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes po to " _
                & "yra registruota apskaitos sąskaitų pakeitimo operacija.", True)

            ' Check for subsequent operations that create max date limit without preventing financial changes

            ' NONE

            ' Check for preceding operations that create min date limit 

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.AccountDiscountsChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.LastBefore, _
                GoodsOperationType.Inventorization, GoodsOperationType.ConsignmentDiscount)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota nuolaidos ir/arba " _
                & "inventorizacijos operacija.", False)

        End Sub

        Private Sub FetchLimitationsForNewAccountPurchases()

            If _CurrentAccountingMethod <> GoodsAccountingMethod.Periodic Then Exit Sub

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.AccountPurchasesChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.Overall, _
                GoodsOperationType.Inventorization, GoodsOperationType.Acquisition, _
                GoodsOperationType.ConsignmentAdditionalCosts)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota įsigijimo ir/arba savikainos " _
                & "padidinimo ir/arba inventorizacijos operacija.", False)

        End Sub

        Private Sub FetchLimitationsForOldAccountPurchases()

            If _CurrentAccountingMethod <> GoodsAccountingMethod.Periodic Then Exit Sub

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization, _
                GoodsOperationType.Acquisition, GoodsOperationType.ConsignmentAdditionalCosts)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes šia data yra registruota inventorizacijos ir/ar įsigijimo ir/ar " _
                & "savikainos padidinimo operacija.", "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes šia data yra registruota inventorizacijos ir/ar " _
                & "įsigijimo ir/ar savikainos padidinimo operacija.", False)

            Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.AccountPurchasesChange)

            SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes po to " _
                & "yra registruota apskaitos sąskaitų pakeitimo operacija.", True)

            ' Check for subsequent operations that create max date limit without preventing financial changes

            ' NONE

            ' Check for preceding operations that create min date limit 

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.AccountPurchasesChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.LastBefore, _
                GoodsOperationType.Inventorization, GoodsOperationType.Acquisition, _
                GoodsOperationType.ConsignmentAdditionalCosts)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota įsigijimo ir/arba savikainos " _
                & "padidinimo ir/arba inventorizacijos operacija.", False)

        End Sub

        Private Sub FetchLimitationsForNewAccountSalesNetCosts()

            If _CurrentAccountingMethod <> GoodsAccountingMethod.Periodic Then Exit Sub

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.AccountSalesNetCostsChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.Overall, _
                GoodsOperationType.Inventorization, GoodsOperationType.ConsignmentDiscount, _
                GoodsOperationType.ConsignmentAdditionalCosts)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota nuolaidos ir/arba savikainos " _
                & "padidinimo ir/arba inventorizacijos operacija.", False)

        End Sub

        Private Sub FetchLimitationsForOldAccountSalesNetCosts()

            If _CurrentAccountingMethod <> GoodsAccountingMethod.Periodic Then Exit Sub

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization, _
                GoodsOperationType.ConsignmentDiscount, GoodsOperationType.ConsignmentAdditionalCosts)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes šia data yra registruota inventorizacijos ir/ar nuolaidos ir/ar " _
                & "savikainos padidinimo operacija.", "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes šia data yra registruota inventorizacijos ir/ar " _
                & "nuolaidos ir/ar savikainos padidinimo operacija.", False)

            Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.AccountSalesNetCostsChange)

            SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes po to " _
                & "yra registruota apskaitos sąskaitų pakeitimo operacija.", True)

            ' Check for subsequent operations that create max date limit without preventing financial changes

            ' NONE

            ' Check for preceding operations that create min date limit 

            Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                OperationChronologyType.LastBefore, GoodsOperationType.AccountSalesNetCostsChange)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                & "operacija.", True)

            LastSignificantDate = GetMaxDate(_CurrentWarehouseID, OperationChronologyType.LastBefore, _
                GoodsOperationType.Inventorization, GoodsOperationType.ConsignmentDiscount, _
                GoodsOperationType.ConsignmentAdditionalCosts)

            SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes prieš tai yra registruota nuolaidos ir/arba savikainos " _
                & "padidinimo ir/arba inventorizacijos operacija.", False)

        End Sub

        Private Sub FetchLimitationsForNewTransferOfBalance()

            Dim FirstDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                GoodsOperationType.ConsignmentDiscount, GoodsOperationType.ConsignmentAdditionalCosts, _
                GoodsOperationType.AccountDiscountsChange, GoodsOperationType.AccountPurchasesChange, _
                GoodsOperationType.AccountSalesNetCostsChange, GoodsOperationType.AccountValueReductionChange, _
                GoodsOperationType.Acquisition, GoodsOperationType.Discard, GoodsOperationType.PriceCut, _
                GoodsOperationType.Transfer, GoodsOperationType.ValuationMethodChange)

            SetMaxDateApplicable(FirstDate, "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes po to yra registruota kitų prekių operacijų.", False)

        End Sub

        Private Sub FetchLimitationsForOldTransferOfBalance()

            Dim FirstDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                GoodsOperationType.ConsignmentDiscount, GoodsOperationType.ConsignmentAdditionalCosts, _
                GoodsOperationType.AccountDiscountsChange, GoodsOperationType.AccountPurchasesChange, _
                GoodsOperationType.AccountSalesNetCostsChange, GoodsOperationType.AccountValueReductionChange, _
                GoodsOperationType.Acquisition, GoodsOperationType.Discard, GoodsOperationType.PriceCut, _
                GoodsOperationType.Transfer, GoodsOperationType.ValuationMethodChange)

            SetFinancialDataCanChange(FirstDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota kitų operacijų su prekėmis.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes po to " _
                & "yra registruota kitų operacijų su prekėmis.", True)

        End Sub

        Private Sub FetchLimitationsForNewRedeemFromBuyer()

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim lastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.Inventorization)

                SetMinDateApplicable(lastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            Else

                Dim lastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.Overall, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(lastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.Overall, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

        Private Sub FetchLimitationsForOldRedeemFromBuyer()

            ' Check if subsequent operations prevent financial changes
            ' If so also set the max date limitation

            If _ConsignmentWasUsed Then SetFinancialDataCanChange(_ConsignmentWasUsedDate, _
                "Finansinių operacijos duomenų keisti negalima, nes kita operacija panaudojo " _
                & "šią prekių partiją.", "Maksimali leidžiama operacijos data yra " _
                & DatePlaceHolder & ", nes kita operacija panaudojo šią prekių partiją.", False)

            Dim InventorizationDate As Date = GetMinDate(_CurrentWarehouseID, _
                OperationChronologyType.FirstAfter, GoodsOperationType.Inventorization)

            SetFinancialDataCanChange(InventorizationDate, "Finansinių operacijos duomenų keisti " _
                & "negalima, nes vėlesne data yra registruota inventorizacijos operacija.", _
                "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                & "yra registruota inventorizacijos operacija.", False)

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim AccountChangeDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.AccountPurchasesChange)

                SetFinancialDataCanChange(AccountChangeDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota apskaitos sąskaitų pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota apskaitos sąskaitų pakeitimo operacija.", False)

            Else

                Dim ValuationMethodDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.ValuationMethodChange)

                SetFinancialDataCanChange(ValuationMethodDate, "Finansinių operacijos duomenų keisti " _
                    & "negalima, nes vėlesne data yra registruota vertinimo metodo pakeitimo operacija.", _
                    "Maksimali leidžiama operacijos data yra " & DatePlaceHolder & ", nes šia data " _
                    & "yra registruota vertinimo metodo pakeitimo operacija.", False)

            End If

            ' Check for subsequent operations that create max date limit without preventing financial changes

            If InventorizationDate <> Date.MinValue AndAlso InventorizationDate <> Date.MaxValue Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių operacija (-os), " _
                    & "o vėlesne data yra registruota inventorizacijos operacija.", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent AndAlso _
                Me._CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Acquisition, _
                    GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                    GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių įsigijimo ir/ar " _
                    & "perleidimo ir/ar nurašymo operacija (-os).", False)

            ElseIf _CurrentAccountingMethod = GoodsAccountingMethod.Persistent Then

                Dim FirstSignificantDate As Date = GetMinDate(_CurrentWarehouseID, _
                    OperationChronologyType.FirstAfter, GoodsOperationType.Discard, _
                    GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                    GoodsOperationType.ConsignmentDiscount)

                SetMaxDateApplicable(FirstSignificantDate, "Maksimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes šia data yra registruota prekių " _
                    & "perleidimo ir/ar nurašymo operacija (-os).", False)

            End If

            ' Check for preceding operations that create min date limit 

            If _CurrentAccountingMethod = GoodsAccountingMethod.Periodic Then

                Dim LastSignificantDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.AccountPurchasesChange, _
                    GoodsOperationType.Inventorization)

                SetMinDateApplicable(LastSignificantDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš tai yra registruota apskaitos sąskaitos pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

            Else

                Dim LastClosingDate As Date = GetMaxDate(_CurrentWarehouseID, _
                    OperationChronologyType.LastBefore, GoodsOperationType.Inventorization, _
                    GoodsOperationType.ValuationMethodChange)

                SetMinDateApplicable(LastClosingDate, "Minimali leidžiama operacijos data yra " _
                    & DatePlaceHolder & ", nes prieš ją yra registruota vertinimo metodo pakeitimo " _
                    & "ir/arba inventorizacijos operacija.", True)

                If _CurrentValuationMethod = GoodsValuationMethod.LIFO Then

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Acquisition, _
                        GoodsOperationType.Discard, GoodsOperationType.Transfer, _
                        GoodsOperationType.ConsignmentAdditionalCosts, GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes šia data yra registruota įsigijimo ir/arba nurašymo " _
                        & "ir/arba perleidimo ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                Else

                    Dim LastOperationDate As Date = GetMaxDate(_CurrentWarehouseID, _
                        OperationChronologyType.LastBefore, GoodsOperationType.Discard, _
                        GoodsOperationType.Transfer, GoodsOperationType.ConsignmentAdditionalCosts, _
                        GoodsOperationType.ConsignmentDiscount)

                    SetMinDateApplicable(LastOperationDate, "Minimali leidžiama operacijos data yra " _
                        & DatePlaceHolder & ", nes prieš ją yra registruota nurašymo ir/arba perleidimo " _
                        & " ir/arba savikainos padidinimo ir/arba nuolaidos operacija.", False)

                End If

            End If

        End Sub

#End Region

    End Class

End Namespace