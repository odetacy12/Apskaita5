Imports ApskaitaObjects.My.Resources
Namespace Goods

    ''' <summary>
    ''' Represents a collection of transfers of goods (initial) balances in warehouses.
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="GoodsComplexOperationTransferOfBalance">GoodsComplexOperationTransferOfBalance</see>.
    ''' Values are stored using <see cref="OperationPersistenceObject">OperationPersistenceObject</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsTransferOfBalanceItemList
        Inherits BusinessListBase(Of GoodsTransferOfBalanceItemList, GoodsTransferOfBalanceItem)

#Region " Business Methods "

        Private _DataImportWarnings As String = ""

        ''' <summary>
        ''' Gets a description of non critical errors encountered when importing
        ''' data from a string.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DataImportWarnings() As String
            Get
                Return _DataImportWarnings
            End Get
        End Property


        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            Return result
        End Function

        Public Function HasWarnings() As Boolean
            For Each i As GoodsTransferOfBalanceItem In Me
                If i.HasWarnings() Then Return True
            Next
            Return False
        End Function


        ''' <summary>
        ''' Returns whether the list contains an item for the goods and the warehouse specified.
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' to look for</param>
        ''' <param name="warehouseID">an <see cref="Warehouse.ID">ID of the warehouse</see>
        ''' to look for</param>
        ''' <remarks></remarks>
        Public Function ContainsGood(ByVal goodsID As Integer, ByVal warehouseID As Integer) As Boolean
            For Each i As GoodsTransferOfBalanceItem In Me
                If i.GoodsInfo.ID = goodsID AndAlso i.Warehouse.ID = warehouseID Then Return True
            Next
            For Each i As GoodsTransferOfBalanceItem In Me.DeletedList
                If Not i.IsNew AndAlso i.GoodsInfo.ID = goodsID AndAlso _
                    i.Warehouse.ID = warehouseID Then Return True
            Next
            Return False
        End Function

        ''' <summary>
        ''' Adds items in the list to the current collection.
        ''' </summary>
        ''' <param name="list"></param>
        ''' <remarks>Should only be called by a parent complex transfer of balance document
        ''' because it does not handle CanChangeFinancialData and does not 
        ''' automaticaly initiate reloading of IChronologyValidator of the parent document.
        ''' (ListChanged event fired with type <see cref="ComponentModel.ListChangedType.Reset">ComponentModel.ListChangedType.Reset</see>,
        ''' not ItemAdded or ItemDeleted.</remarks>
        Friend Sub AddRange(ByVal list As GoodsTransferOfBalanceItemList)
            CheckNewListForConcurrentItems(list)
            Me.RaiseListChangedEvents = False
            For Each o As GoodsTransferOfBalanceItem In list
                Add(o.Clone())
            Next
            Me.RaiseListChangedEvents = True
            Me.ResetBindings()
        End Sub

        ''' <summary>
        ''' Checks a new items list for concurrent items that already exists
        ''' in the document or were deleted from the document. Throws exception
        ''' if concurrent items are found or the new item list is null or empty. 
        ''' </summary>
        ''' <param name="list"></param>
        ''' <remarks></remarks>
        Private Sub CheckNewListForConcurrentItems(ByVal list As GoodsTransferOfBalanceItemList)

            If list Is Nothing OrElse list.Count < 1 Then
                Throw New Exception(Goods_GoodsTransferOfBalanceItemList_NewTransferOfBalanceItemListEmpty)
            End If

            Dim message As String = ""

            For Each newItem As GoodsTransferOfBalanceItem In list
                For Each existingItem As GoodsTransferOfBalanceItem In Me
                    If existingItem.GoodsInfo.ID = newItem.GoodsInfo.ID AndAlso _
                        existingItem.Warehouse.ID = newItem.Warehouse.ID Then
                        message = AddWithNewLine(message, String.Format(Goods_GoodsTransferOfBalanceItemList_ConcurentItem, _
                            existingItem.GoodsInfo.Name, existingItem.Warehouse.Name), False)
                        Exit For
                    End If
                Next
            Next

            For Each newItem As GoodsTransferOfBalanceItem In list
                For Each deletedItem As GoodsTransferOfBalanceItem In Me
                    If Not deletedItem.IsNew AndAlso deletedItem.GoodsInfo.ID _
                        = newItem.GoodsInfo.ID AndAlso deletedItem.Warehouse.ID _
                        = newItem.Warehouse.ID Then
                        message = AddWithNewLine(message, String.Format(Goods_GoodsTransferOfBalanceItemList_ConcurentItem, _
                            deletedItem.GoodsInfo.Name, deletedItem.Warehouse.Name), False)
                        Exit For
                    End If
                Next
            Next

            If Not String.IsNullOrEmpty(message) Then
                Throw New Exception(String.Format(Goods_GoodsTransferOfBalanceItemList_DuplicateItemsInNewTransferOfBalanceItemList, _
                    vbCrLf, message))
            End If

        End Sub

        Friend Function GetLimitations() As OperationalLimitList()
            Dim result As New List(Of OperationalLimitList)
            For Each i As GoodsTransferOfBalanceItem In Me
                result.Add(i.OperationLimitations)
            Next
            Return result.ToArray
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a a collection of new transfer of balance items created for 
        ''' goods ID's specified in the warehouse specified. 
        ''' Use <see cref="GoodsComplexOperationTransferOfBalance.AddRange">
        ''' GoodsComplexOperationTransferOfBalance.AddRange</see> method to add them 
        ''' to a complex transfer of balance document.
        ''' </summary>
        ''' <param name="goodsIDs">an array of <see cref="GoodsItem.ID">goods ID's</see>
        ''' that the operation list should be fetched for</param>
        ''' <param name="warehouseID">an <see cref="Warehouse.ID">ID of the warehouse
        ''' that the goods balance is for</see></param>
        ''' <remarks></remarks>
        Public Shared Function NewGoodsDiscardItemList(ByVal goodsIDs As Integer(), _
            ByVal warehouseID As Integer) As GoodsTransferOfBalanceItemList
            Return DataPortal.Create(Of GoodsTransferOfBalanceItemList) _
                (New Criteria(goodsIDs, warehouseID))
        End Function

        ''' <summary>
        ''' Gets a collection of new transfer of balance items using data in (paste) string. 
        ''' Use <see cref="GoodsComplexOperationTransferOfBalance.AddRange">
        ''' GoodsComplexOperationTransferOfBalance.AddRange</see> method to add them 
        ''' to a complex transfer of balance document.
        ''' </summary>
        ''' <param name="source">a string containing goods balance data
        ''' (lines/items should be delimited by CrLf, columns/fields - by Tab)</param>
        ''' <remarks></remarks>
        Public Shared Function NewGoodsDiscardItemList(ByVal source As String) As GoodsTransferOfBalanceItemList
            Return DataPortal.Create(Of GoodsTransferOfBalanceItemList)(New Criteria(source))
        End Function

        ''' <summary>
        ''' Gets a collection of new transfer of balance items using data in a template datatable,
        ''' see <see cref="GoodsTransferOfBalanceItem.GetDataTableSpecification()">
        ''' GoodsTransferOfBalanceItem.GetDataTableSpecification</see> method.
        ''' </summary>
        ''' <param name="table">a template datatable that contains the data to import</param>
        ''' <remarks></remarks>
        Public Shared Function NewGoodsDiscardItemList(ByVal table As DataTable) As GoodsTransferOfBalanceItemList
            Return DataPortal.Create(Of GoodsTransferOfBalanceItemList)(New Criteria(table))
        End Function

        ''' <summary>
        ''' Gets a new (empty) GoodsTransferOfBalanceItemList instance 
        ''' for a new complex transfer of balance operation.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsTransferOfBalanceItemList() As GoodsTransferOfBalanceItemList
            Return New GoodsTransferOfBalanceItemList
        End Function

        ''' <summary>
        ''' Gets an existing GoodsTransferOfBalanceItemList instance using a 
        ''' database query result.
        ''' </summary>
        ''' <param name="objList">a persistence object list containing the items data</param>
        ''' <param name="limitationsDataSource">a datasource for the 
        ''' <see cref="OperationalLimitList">chronologic validator</see></param>
        ''' <remarks></remarks>
        Friend Shared Function GetGoodsTransferOfBalanceItemList( _
            ByVal objList As List(Of OperationPersistenceObject), _
            ByVal limitationsDataSource As DataTable) As GoodsTransferOfBalanceItemList
            Return New GoodsTransferOfBalanceItemList(objList, limitationsDataSource)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal objList As List(Of OperationPersistenceObject), _
            ByVal limitationsDataSource As DataTable)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
            Fetch(objList, limitationsDataSource)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _IDs As Integer() = Nothing
            Private _WarehouseID As Integer = 0
            Private _Source As String = ""
            Private _UsingStringSource As Boolean = False
            Private _Table As DataTable = Nothing
            Public ReadOnly Property IDs() As Integer()
                Get
                    Return _IDs
                End Get
            End Property
            Public ReadOnly Property WarehouseID() As Integer
                Get
                    Return _WarehouseID
                End Get
            End Property
            Public ReadOnly Property Source() As String
                Get
                    Return _Source
                End Get
            End Property
            Public ReadOnly Property UsingStringSource() As Boolean
                Get
                    Return _UsingStringSource
                End Get
            End Property
            Public ReadOnly Property Table As DataTable
                Get
                    Return _Table
                End Get
            End Property
            Public Sub New(ByVal nIDs As Integer(), ByVal nWarehouseID As Integer)
                _IDs = nIDs
                _WarehouseID = nWarehouseID
            End Sub
            Public Sub New(ByVal nSource As String)
                _Source = nSource
                _UsingStringSource = True
            End Sub
            Public Sub New(ByVal aTable As DataTable)
                _Table = aTable
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)

            If Not GoodsComplexOperationTransferOfBalance.CanAddObject() Then
                Throw New System.Security.SecurityException( _
                    My.Resources.Common_SecuritySelectDenied)
            End If

            If Not criteria.Table Is Nothing Then
                Create(criteria.Table)
            ElseIf criteria.UsingStringSource Then
                Create(criteria.Source)
            Else
                Create(criteria.IDs, criteria.WarehouseID)
            End If

        End Sub

        Private Sub Create(ByVal source As String)

            If StringIsNullOrEmpty(source) Then
                Throw New Exception(Goods_GoodsTransferOfBalanceItemList_SourceNull)
            End If

            Dim goodsList As GoodsInfoList = GoodsInfoList.GetListChild
            Dim warehouseList As WarehouseInfoList = WarehouseInfoList.GetListChild
            Dim lines As String() = source.Split(New String() {vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
            Dim addedCount As Integer = 0
            Dim warnings As String = ""

            RaiseListChangedEvents = False

            For Each line As String In lines
                If AddItem(line, warehouseList, goodsList, warnings) Then addedCount += 1
            Next

            If Not StringIsNullOrEmpty(warnings) Then
                _DataImportWarnings = String.Format(Goods_GoodsTransferOfBalanceItemList_ImportWarningsString, _
                    addedCount.ToString, lines.Length.ToString, vbCrLf, warnings)
            End If

            RaiseListChangedEvents = True

        End Sub

        Private Function AddItem(ByVal line As String, ByVal warehouseList As WarehouseInfoList, _
            ByVal goodsList As GoodsInfoList, ByRef warnings As String) As Boolean

            If StringIsNullOrEmpty(line) Then Return False

            If warnings Is Nothing Then warnings = ""

            Dim currentGoodsName As String = GetField(line, vbTab, 0)

            If StringIsNullOrEmpty(currentGoodsName) Then
                warnings = AddWithNewLine(warnings, String.Format( _
                    Goods_GoodsTransferOfBalanceItemList_LineWithoutGoodsName, _
                    line.Replace(vbTab, "<TAB>")), False)
                Return False
            End If

            Dim currentWarehouseName As String = GetField(line, vbTab, 1)

            If StringIsNullOrEmpty(currentWarehouseName) Then
                warnings = AddWithNewLine(warnings, String.Format( _
                    Goods_GoodsTransferOfBalanceItemList_LineWithoutWarehouseName, _
                    line.Replace(vbTab, "<TAB>")), False)
                Return False
            End If

            Dim currentGoodsInfo As GoodsInfo = goodsList.GetItem(currentGoodsName)
            If currentGoodsInfo Is Nothing OrElse currentGoodsInfo.IsEmpty Then
                warnings = AddWithNewLine(warnings, String.Format( _
                    Goods_GoodsTransferOfBalanceItemList_GoodsUnknown, _
                    currentGoodsName, line.Replace(vbTab, "<TAB>")), False)
                Return False
            End If

            Dim currentWarehouse As WarehouseInfo = warehouseList.GetItem(currentWarehouseName)
            If currentWarehouse Is Nothing OrElse currentWarehouse.IsEmpty Then
                warnings = AddWithNewLine(warnings, String.Format( _
                    Goods_GoodsTransferOfBalanceItemList_WarehouseUnknown, _
                    currentWarehouseName, line.Replace(vbTab, "<TAB>")), False)
                Return False
            End If

            If Not ContainsGood(currentGoodsInfo.ID, currentWarehouse.ID) Then

                Dim currentGoods As GoodsSummary = GoodsSummary.NewGoodsSummary(currentGoodsInfo.ID)

                Me.Add(GoodsTransferOfBalanceItem.NewGoodsTransferOfBalanceItem( _
                    currentGoods, currentWarehouse, line))

            Else

                warnings = AddWithNewLine(warnings, String.Format( _
                    Goods_GoodsTransferOfBalanceItemList_DuplicateLine, _
                    currentWarehouseName, currentGoodsName), False)
                Return False

            End If

            Return True

        End Function

        Private Sub Create(ByVal table As DataTable)

            Dim goodsList As GoodsInfoList = GoodsInfoList.GetListChild
            Dim warehouseList As WarehouseInfoList = WarehouseInfoList.GetListChild
            Dim addedCount As Integer = 0
            Dim warnings As String = ""

            RaiseListChangedEvents = False

            For Each dr As DataRow In table.Rows
                If AddItem(dr, warehouseList, goodsList, warnings) Then addedCount += 1
            Next

            If Not StringIsNullOrEmpty(warnings) Then
                _DataImportWarnings = String.Format(Goods_GoodsTransferOfBalanceItemList_ImportWarningsString,
                    addedCount.ToString, table.Rows.Count.ToString, vbCrLf, warnings)
            End If

            RaiseListChangedEvents = True

        End Sub

        Private Function AddItem(ByVal dr As DataRow, ByVal warehouseList As WarehouseInfoList,
            ByVal goodsList As GoodsInfoList, ByRef warnings As String) As Boolean

            If warnings Is Nothing Then warnings = ""

            Dim currentGoodsName As String = DirectCast(dr.Item("GoodsName"), String)

            If StringIsNullOrEmpty(currentGoodsName) Then
                warnings = AddWithNewLine(warnings, String.Format(
                    Goods_GoodsTransferOfBalanceItemList_LineWithoutGoodsName,
                    DataRowToString(dr)), False)
                Return False
            End If

            Dim currentWarehouseName As String = DirectCast(dr.Item("WarehouseName"), String)

            If StringIsNullOrEmpty(currentWarehouseName) Then
                warnings = AddWithNewLine(warnings, String.Format(
                    Goods_GoodsTransferOfBalanceItemList_LineWithoutWarehouseName,
                    DataRowToString(dr)), False)
                Return False
            End If

            Dim currentGoodsInfo As GoodsInfo = goodsList.GetItem(currentGoodsName)
            If currentGoodsInfo = GoodsInfo.Empty Then
                warnings = AddWithNewLine(warnings, String.Format(
                    Goods_GoodsTransferOfBalanceItemList_GoodsUnknown,
                    currentGoodsName, DataRowToString(dr)), False)
                Return False
            End If

            Dim currentWarehouse As WarehouseInfo = warehouseList.GetItem(currentWarehouseName)
            If currentWarehouse = WarehouseInfo.Empty Then
                warnings = AddWithNewLine(warnings, String.Format(
                    Goods_GoodsTransferOfBalanceItemList_WarehouseUnknown,
                    currentWarehouseName, DataRowToString(dr)), False)
                Return False
            End If

            If Not ContainsGood(currentGoodsInfo.ID, currentWarehouse.ID) Then

                Dim currentGoods As GoodsSummary = GoodsSummary.NewGoodsSummary(currentGoodsInfo.ID)

                Me.Add(GoodsTransferOfBalanceItem.NewGoodsTransferOfBalanceItem(
                    currentGoods, currentWarehouse, dr))

            Else

                warnings = AddWithNewLine(warnings, String.Format(
                    Goods_GoodsTransferOfBalanceItemList_DuplicateLine,
                    currentWarehouseName, currentGoodsName), False)
                Return False

            End If

            Return True

        End Function


        Private Sub Create(ByVal goodsIDs As Integer(), ByVal warehouseID As Integer)

            If goodsIDs Is Nothing OrElse goodsIDs.Length < 1 Then
                Throw New Exception(Goods_GoodsTransferOfBalanceItemList_GoodsIdsNull)
            End If

            Dim warehouse As WarehouseInfo = WarehouseInfoList.GetListChild. _
                GetItem(warehouseID, False)
            If warehouse Is Nothing OrElse warehouse.IsEmpty Then
                Throw New Exception(Goods_GoodsTransferOfBalanceItemList_WarehouseNull)
            End If

            RaiseListChangedEvents = False

            For Each goodsID As Integer In goodsIDs
                Add(GoodsTransferOfBalanceItem.NewGoodsTransferOfBalanceItem( _
                    goodsID, warehouse))
            Next

            RaiseListChangedEvents = True

        End Sub


        Private Sub Fetch(ByVal objList As List(Of OperationPersistenceObject), _
            ByVal limitationsDataSource As DataTable)

            RaiseListChangedEvents = False

            For Each obj As OperationPersistenceObject In objList
                Add(GoodsTransferOfBalanceItem.GetGoodsTransferOfBalanceItem( _
                    obj, limitationsDataSource))
            Next

            RaiseListChangedEvents = True

        End Sub

        Friend Sub Update(ByVal parent As GoodsComplexOperationTransferOfBalance)

            RaiseListChangedEvents = False

            For Each item As GoodsTransferOfBalanceItem In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As GoodsTransferOfBalanceItem In Me
                If item.IsNew Then
                    item.Insert(parent)
                ElseIf item.IsDirty OrElse parent.IsSelfDirty Then
                    item.Update(parent)
                End If
            Next

            RaiseListChangedEvents = True

        End Sub


        Friend Sub CheckIfCanUpdate(ByVal limitationsDataSource As DataTable)

            For Each i As GoodsTransferOfBalanceItem In Me
                i.CheckIfCanUpdate(limitationsDataSource)
            Next

            For Each i As GoodsTransferOfBalanceItem In Me.DeletedList
                If Not i.IsNew Then
                    i.CheckIfCanDelete(limitationsDataSource)
                End If
            Next

        End Sub

#End Region

    End Class

End Namespace