Imports ApskaitaObjects.My.Resources

Namespace Goods

    ''' <summary>
    ''' Represents a helper object that persists data of a complex goods operation,
    ''' e.g. <see cref="GoodsComplexOperationDiscard">GoodsComplexOperationDiscard</see>.
    ''' </summary>
    ''' <remarks>A complex goods operation is an operation that is composed (encapsulates) 
    ''' of several simple goods operations, e.g. <see cref="GoodsComplexOperationDiscard">GoodsComplexOperationDiscard</see>
    ''' is composed of multiple <see cref="GoodsOperationDiscard">GoodsOperationDiscard</see>
    ''' operations (with a common warehouse); <see cref="GoodsComplexOperationInternalTransfer">GoodsComplexOperationInternalTransfer</see>
    ''' is composed of multiple <see cref="GoodsOperationAcquisition">GoodsOperationAcquisition</see>
    ''' (for the warehouse that the the goods is transfered to) and 
    ''' <see cref="GoodsOperationDiscard">GoodsOperationDiscard</see> (for the 
    ''' warehouse that the goods is transfered from) operations.
    ''' Should only be used as a child of a complex goods operation.
    ''' Values are stored in the database table goodscomplexoperations.</remarks>
    <Serializable()> _
    Friend Class ComplexOperationPersistenceObject

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _OperationDate As Date = Today
        Private _OperationType As GoodsComplexOperationType = GoodsComplexOperationType.InternalTransfer
        Private _JournalEntryID As Integer = 0
        Private _DocNo As String = ""
        Private _Content As String = ""
        Private _GoodsID As Integer = 0
        Private _AccountOperation As Long = 0
        Private _WarehouseID As Integer = 0
        Private _Warehouse As WarehouseInfo = Nothing
        Private _SecondaryWarehouseID As Integer = 0
        Private _SecondaryWarehouse As WarehouseInfo = Nothing
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now


        ''' <summary>
        ''' Gets an ID of the operation that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database field goodscomplexoperations.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the operation was inserted into the database.
        ''' </summary>
        ''' <remarks>Value is stored in the database field goodscomplexoperations.InsertDate.</remarks>
        Public ReadOnly Property InsertDate() As DateTime
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the operation was last updated.
        ''' </summary>
        ''' <remarks>Value is stored in the database field goodscomplexoperations.UpdateDate.</remarks>
        Public ReadOnly Property UpdateDate() As DateTime
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a type of the operation.
        ''' </summary>
        ''' <remarks>Is set when creating a new operation and cannot be changed afterwards.
        ''' Value is stored in the database field goodscomplexoperations.OperationType.</remarks>
        Public ReadOnly Property OperationType() As GoodsComplexOperationType
            Get
                Return _OperationType
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="GoodsItem.ID">ID of the goods</see> 
        ''' that the operation operates with.
        ''' </summary>
        ''' <remarks>Equals 0 if the operation operates with multiple goods 
        ''' and there is no specific goods item for the operation, e.g.
        ''' for bulk discard all the discarded goods items are the same;
        ''' for production there is one distinguish goods item - the produced goods.
        ''' Is set when creating a new operation and cannot be changed afterwards.
        ''' Value is stored in the database field goodscomplexoperations.GoodsID.</remarks>
        Public ReadOnly Property GoodsID() As Integer
            Get
                Return _GoodsID
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a date of the operation.
        ''' </summary>
        ''' <remarks>Value is stored in the database field goodscomplexoperations.OperationDate.</remarks>
        Public Property OperationDate() As Date
            Get
                Return _OperationDate
            End Get
            Set(ByVal value As Date)
                If _OperationDate.Date <> value.Date Then
                    _OperationDate = value.Date
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an <see cref="General.JournalEntry.ID">ID of the journal entry</see>
        ''' that is encapsulated by (or associated with) the operation.
        ''' </summary>
        ''' <remarks>Value is stored in the database field goodscomplexoperations.JournalEntryID.</remarks>
        Public Property JournalEntryID() As Integer
            Get
                Return _JournalEntryID
            End Get
            Set(ByVal value As Integer)
                If _JournalEntryID <> value Then
                    _JournalEntryID = value
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a document number of the operation.
        ''' </summary>
        ''' <remarks>Value is stored in the database field goodscomplexoperations.DocNo.</remarks>
        Public Property DocNo() As String
            Get
                Return _DocNo.Trim
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _DocNo.Trim <> value.Trim Then
                    _DocNo = value.Trim
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a content (description) of the operation.
        ''' </summary>
        ''' <remarks>Value is stored in the database field goodscomplexoperations.Content.</remarks>
        Public Property Content() As String
            Get
                Return _Content.Trim
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _Content.Trim <> value.Trim Then
                    _Content = value.Trim
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an <see cref="General.Account.ID">account</see>
        ''' that is specific for the operation.
        ''' </summary>
        ''' <remarks>Currently not in use by any operation.
        ''' Value is stored in the database field goodscomplexoperations.AccountOperation.</remarks>
        Public Property AccountOperation() As Long
            Get
                Return _AccountOperation
            End Get
            Set(ByVal value As Long)
                If _AccountOperation <> value Then
                    _AccountOperation = value
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an <see cref="Goods.Warehouse.ID">ID of the warehouse</see> 
        ''' that the operation operates in.
        ''' </summary>
        ''' <remarks>Value is stored in the database field goodscomplexoperations.WarehouseID.</remarks>
        Public Property WarehouseID() As Integer
            Get
                Return _WarehouseID
            End Get
            Set(ByVal value As Integer)
                If _WarehouseID <> value Then
                    _WarehouseID = value
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a warehouse (warehouse value object) 
        ''' that the operation operates in.
        ''' </summary>
        ''' <remarks>Value is stored in the database field goodscomplexoperations.WarehouseID.</remarks>
        Public Property Warehouse() As WarehouseInfo
            Get
                Return _Warehouse
            End Get
            Set(ByVal value As WarehouseInfo)
                If Not (_Warehouse Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Warehouse Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _Warehouse.ID = value.ID) Then
                    _Warehouse = value
                    If Not _Warehouse Is Nothing Then
                        _WarehouseID = _Warehouse.ID
                    Else
                        _WarehouseID = 0
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an <see cref="Goods.Warehouse.ID">ID of the second warehouse</see> 
        ''' (if any) that the operation operates in, e.g. for goods transfer between warehouses.
        ''' </summary>
        ''' <remarks>Value is stored in the database field goodscomplexoperations.SecondaryWarehouseID.</remarks>
        Public Property SecondaryWarehouseID() As Integer
            Get
                Return _SecondaryWarehouseID
            End Get
            Set(ByVal value As Integer)
                If _SecondaryWarehouseID <> value Then
                    _SecondaryWarehouseID = value
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the second warehouse (if any) that the operation operates in, 
        ''' e.g. for goods transfer between warehouses.
        ''' </summary>
        ''' <remarks>Value is stored in the database field goodscomplexoperations.SecondaryWarehouseID.</remarks>
        Public Property SecondaryWarehouse() As WarehouseInfo
            Get
                Return _SecondaryWarehouse
            End Get
            Set(ByVal value As WarehouseInfo)
                If Not (_SecondaryWarehouse Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _SecondaryWarehouse Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _SecondaryWarehouse.ID = value.ID) Then
                    _SecondaryWarehouse = value
                    If Not _SecondaryWarehouse Is Nothing Then
                        _SecondaryWarehouseID = _SecondaryWarehouse.ID
                    Else
                        _SecondaryWarehouseID = 0
                    End If
                End If
            End Set
        End Property


        ''' <summary>
        ''' Saves the operation to a database and returns a saved operation instance.
        ''' </summary>
        ''' <param name="updateFinancialData">whether to update operation's financial data</param>
        ''' <param name="updateWarehouse">whether to update operation's warehouse data</param>
        ''' <param name="updateSecondaryWarehouse">whether to update operation's 
        ''' secondary warehouse data</param>
        ''' <remarks></remarks>
        Friend Function SaveChild(ByVal updateFinancialData As Boolean, _
            ByVal updateWarehouse As Boolean, ByVal updateSecondaryWarehouse As Boolean) _
            As ComplexOperationPersistenceObject

            Dim result As ComplexOperationPersistenceObject _
                = Clone(Of ComplexOperationPersistenceObject)(Me)

            If result._ID > 0 Then
                result.Update(updateFinancialData, updateWarehouse, updateSecondaryWarehouse)
            Else
                result.Insert()
            End If

            Return result

        End Function


        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Goods_ComplexOperationPersistenceObject_ToString, _
                _OperationDate.ToString("yyyy-MM-dd"), _
                Utilities.ConvertLocalizedName(_OperationType), _ID.ToString())
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new ComplexOperationPersistenceObject instance of requested type.
        ''' </summary>
        ''' <param name="newOperationType">a type of the operation to create</param>
        ''' <param name="operationGoodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' that the operation operates with</param>
        ''' <remarks></remarks>
        Friend Shared Function NewComplexOperationPersistenceObject( _
            ByVal newOperationType As GoodsComplexOperationType, _
            ByVal operationGoodsID As Integer) As ComplexOperationPersistenceObject
            Return New ComplexOperationPersistenceObject(newOperationType, operationGoodsID)
        End Function

        ''' <summary>
        ''' Gets an existing ComplexOperationPersistenceObject instance from a database.
        ''' </summary>
        ''' <param name="operationID">an <see cref="ID">ID</see> of the operation to fetch</param>
        ''' <param name="expectedType">an expected type of the operation</param>
        ''' <param name="throwOnTypeMismatch">whether to throw an exception 
        ''' if the actual operation type does not match the expected type</param>
        ''' <remarks></remarks>
        Friend Shared Function GetComplexOperationPersistenceObject(ByVal operationID As Integer, _
            ByVal expectedType As GoodsComplexOperationType, _
            Optional ByVal throwOnTypeMismatch As Boolean = True) As ComplexOperationPersistenceObject
            Return New ComplexOperationPersistenceObject(operationID, expectedType, _
                throwOnTypeMismatch)
        End Function

        ''' <summary>
        ''' Deletes an existing ComplexOperationPersistenceObject instance from a database.
        ''' </summary>
        ''' <param name="operationID">an <see cref="ID">ID</see> of the operation to delete</param>
        ''' <param name="hasChildOperations">whether the operation has child goods operations
        ''' (that should also be deleted)</param>
        ''' <param name="hasChildConsignments">whether the operation has child 
        ''' goods consignments (that should also be deleted)</param>
        ''' <param name="hasChildConsignmentDiscards">whether the operation has child 
        ''' goods consignments discards (that should also be deleted)</param>
        ''' <remarks></remarks>
        Friend Shared Sub Delete(ByVal operationID As Integer, _
            ByVal hasChildOperations As Boolean, ByVal hasChildConsignments As Boolean, _
            ByVal hasChildConsignmentDiscards As Boolean)

            If hasChildConsignmentDiscards Then
                DeleteConsignmentDiscards(operationID)
            End If

            If hasChildConsignments Then
                DeleteConsignments(operationID)
            End If

            If hasChildOperations Then
                DeleteOperations(operationID)
            End If

            DeleteSelf(operationID)

        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal newOperationType As GoodsComplexOperationType, _
            ByVal operationGoodsID As Integer)
            _OperationType = newOperationType
            _GoodsID = operationGoodsID
        End Sub

        Private Sub New(ByVal operationID As Integer, ByVal expectedType As GoodsComplexOperationType, _
            ByVal throwOnTypeMismatch As Boolean)
            Fetch(operationID, expectedType, throwOnTypeMismatch)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal operationID As Integer, ByVal expectedType As GoodsComplexOperationType, _
            ByVal throwOnTypeMismatch As Boolean)

            If Not operationID > 0 Then
                Throw New ArgumentNullException("operationID", Goods_ComplexOperationPersistenceObject_OperationIdNull)
            End If

            Dim myComm As New SQLCommand("FetchComplexOperationPersistenceObject")
            myComm.AddParam("?OD", operationID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.Common_ObjectNotFound, My.Resources.Goods_ComplexOperationPersistenceObject_TypeName, _
                    operationID.ToString()))

                Dim dr As DataRow = myData.Rows(0)

                _ID = CIntSafe(dr.Item(0), 0)
                _OperationDate = CDateSafe(dr.Item(1), Today)
                _JournalEntryID = CIntSafe(dr.Item(2), 0)
                _DocNo = CStrSafe(dr.Item(3)).Trim
                _Content = CStrSafe(dr.Item(4)).Trim
                _GoodsID = CIntSafe(dr.Item(5), 0)
                _OperationType = Utilities.ConvertDatabaseID(Of GoodsComplexOperationType) _
                    (CIntSafe(dr.Item(6)))
                _AccountOperation = CLongSafe(dr.Item(7), 0)
                _InsertDate = CTimeStampSafe(dr.Item(8))
                _UpdateDate = CTimeStampSafe(dr.Item(9))
                _Warehouse = WarehouseInfo.GetWarehouseInfo(dr, 10)
                _SecondaryWarehouse = WarehouseInfo.GetWarehouseInfo(dr, 15)

                If Not _Warehouse Is Nothing Then
                    _WarehouseID = _Warehouse.ID
                End If
                If Not _SecondaryWarehouse Is Nothing Then
                    _SecondaryWarehouseID = _SecondaryWarehouse.ID
                End If

            End Using

            If throwOnTypeMismatch AndAlso expectedType <> _OperationType Then
                Throw New Exception(String.Format(Goods_ComplexOperationPersistenceObject_OperationTypeMismatch, _
                    _ID.ToString, Utilities.ConvertLocalizedName(_OperationType), _
                    Utilities.ConvertLocalizedName(expectedType)))
            End If

        End Sub


        Private Sub Insert()

            Dim myComm As New SQLCommand("InsertComplexOperationPersistenceObject")
            AddWithParamsGeneral(myComm)
            AddWithParamsFinancial(myComm)
            myComm.AddParam("?AE", _GoodsID)
            myComm.AddParam("?AF", Utilities.ConvertDatabaseID(_OperationType))

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

        End Sub

        Private Sub Update(ByVal updateFinancialData As Boolean, _
            ByVal updateWarehouse As Boolean, ByVal updateSecondaryWarehouse As Boolean)

            Dim myComm As SQLCommand

            If updateFinancialData Then
                myComm = New SQLCommand("UpdateComplexOperationPersistenceObjectFull")
                AddWithParamsFinancial(myComm)
            ElseIf updateWarehouse Then
                myComm = New SQLCommand("UpdateComplexOperationPersistenceObjectGeneral2")
                myComm.AddParam("?AG", _WarehouseID)
            ElseIf updateSecondaryWarehouse Then
                myComm = New SQLCommand("UpdateComplexOperationPersistenceObjectGeneral3")
                myComm.AddParam("?AH", _SecondaryWarehouseID)
            Else
                myComm = New SQLCommand("UpdateComplexOperationPersistenceObjectGeneral")
            End If
            AddWithParamsGeneral(myComm)
            myComm.AddParam("?CD", _ID)

            myComm.Execute()

        End Sub

        Private Sub AddWithParamsGeneral(ByRef myComm As SQLCommand)

            myComm.AddParam("?AA", _OperationDate.Date)
            myComm.AddParam("?AC", _DocNo.Trim)
            myComm.AddParam("?AD", _Content.Trim)

            _UpdateDate = GetCurrentTimeStamp()
            If Not _ID > 0 Then _InsertDate = _UpdateDate
            myComm.AddParam("?AI", _UpdateDate.ToUniversalTime())

        End Sub

        Private Sub AddWithParamsFinancial(ByRef myComm As SQLCommand)

            myComm.AddParam("?AB", _JournalEntryID)
            myComm.AddParam("?AG", _WarehouseID)
            myComm.AddParam("?AH", _SecondaryWarehouseID)
            myComm.AddParam("?AJ", _AccountOperation)

        End Sub


        Private Shared Sub DeleteSelf(ByVal operationID As Integer)

            Dim myComm As New SQLCommand("DeleteComplexOperationPersistenceObject")
            myComm.AddParam("?CD", operationID)

            myComm.Execute()

        End Sub

        Private Shared Sub DeleteOperations(ByVal operationID As Integer)

            Dim myComm As New SQLCommand("DeleteOperationsByComplexParent")
            myComm.AddParam("?CD", operationID)

            myComm.Execute()

        End Sub

        Private Shared Sub DeleteConsignments(ByVal operationID As Integer)

            Dim myComm As New SQLCommand("DeleteConsignmentsByComplexParent")
            myComm.AddParam("?OD", operationID)

            myComm.Execute()

        End Sub

        Private Shared Sub DeleteConsignmentDiscards(ByVal operationID As Integer)

            Dim myComm As New SQLCommand("DeleteConsignmentDiscardsByComplexParent")
            myComm.AddParam("?OD", operationID)

            myComm.Execute()

        End Sub

#End Region

    End Class

End Namespace