Imports ApskaitaObjects.My.Resources

Namespace Goods

    ''' <summary>
    ''' Represents a collection of simple goods price cut operations
    ''' that belong to a complex goods price cut document.
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="GoodsComplexOperationPriceCut">GoodsComplexOperationPriceCut</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsPriceCutItemList
        Inherits BusinessListBase(Of GoodsPriceCutItemList, GoodsOperationPriceCut)

#Region " Business Methods "

        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            Return result
        End Function

        Public Function HasWarnings() As Boolean
            For Each i As GoodsOperationPriceCut In Me
                If i.HasWarnings() Then Return True
            Next
            Return False
        End Function


        Friend Sub SetParentDate(ByVal newDate As Date)
            Me.RaiseListChangedEvents = False
            For Each i As GoodsOperationPriceCut In Me
                i.SetParentDate(newDate)
            Next
            Me.RaiseListChangedEvents = True
            Me.ResetBindings()
        End Sub

        Friend Sub SetCommonAccountPriceCutCosts(ByVal accountCosts As Long)
            Me.RaiseListChangedEvents = False
            For Each i As GoodsOperationPriceCut In Me
                i.AccountPriceCutCosts = accountCosts
            Next
            Me.RaiseListChangedEvents = True
            Me.ResetBindings()
        End Sub


        ''' <summary>
        ''' Returns whether the list contains an item for the goods specified.
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' to look for</param>
        ''' <remarks></remarks>
        Public Function ContainsGoods(ByVal goodsID As Integer) As Boolean
            For Each i As GoodsOperationPriceCut In Me
                If i.GoodsInfo.ID = goodsID Then Return True
            Next
            For Each i As GoodsOperationPriceCut In Me.DeletedList
                If Not i.IsNew AndAlso i.GoodsInfo.ID = goodsID Then Return True
            Next
            Return False
        End Function

        ''' <summary>
        ''' Sets new initial amount and value of the goods in the warehouses.
        ''' </summary>
        ''' <param name="values">a query object containing information about amount 
        ''' and value of the goods in the warehouses at a certain date. </param>
        ''' <param name="warnings">an out parameter that returns a description of 
        ''' non critical errors encountered while seting the data</param>
        ''' <remarks></remarks>
        Friend Sub RefreshValuesInWarehouse(ByVal values As GoodsPriceInWarehouseItemList, _
            ByRef warnings As String)

            If values Is Nothing OrElse values.Count < 1 Then
                Throw New Exception(Goods_GoodsPriceCutItemList_GoodsValueListEmpty)
            End If

            warnings = ""

            If values.Count <> Me.Count Then
                warnings = AddWithNewLine(warnings, String.Format( _
                    Goods_GoodsPriceCutItemList_GoodsValueListCountMismatch, _
                    Me.Count.ToString(), values.Count.ToString()), False)
            End If

            Dim successCount As Integer = 0
            Dim isFound As Boolean

            RaiseListChangedEvents = False

            For Each value As GoodsPriceInWarehouseItem In values

                isFound = False

                For Each i As GoodsOperationPriceCut In Me

                    If i.GoodsInfo.ID = value.GoodsID Then

                        Try
                            i.RefreshValuesInWarehouse(value)
                            successCount += 1
                        Catch ex As Exception
                            warnings = AddWithNewLine(warnings, ex.Message, False)
                        End Try

                        isFound = True
                        Exit For

                    End If

                Next

                If Not isFound Then
                    warnings = AddWithNewLine(warnings, String.Format( _
                        Goods_GoodsPriceCutItemList_OrphanGoodsValue, _
                        value.GoodsID.ToString()), False)
                End If

            Next

            RaiseListChangedEvents = True
            Me.ResetBindings()

            If Not StringIsNullOrEmpty(warnings) Then
                If successCount > 0 Then
                    warnings = String.Format(Goods_GoodsPriceCutItemList_RefreshValuesInWarehouseWarning, _
                        successCount.ToString(), values.Count.ToString(), vbCrLf, warnings)
                Else
                    Throw New Exception(String.Format( _
                        Goods_GoodsPriceCutItemList_RefreshValuesInWarehouseException, _
                        vbCrLf, warnings))
                End If
            End If

        End Sub

        ''' <summary>
        ''' Sets new initial amount and value of the goods in the warehouses.
        ''' </summary>
        ''' <param name="value">a query object containing information about amount 
        ''' and value of the goods in the warehouses at a certain date. </param>
        ''' <remarks></remarks>
        Friend Sub RefreshValuesInWarehouse(ByVal value As GoodsPriceInWarehouseItem)

            Dim isFound As Boolean = False

            For Each i As GoodsOperationPriceCut In Me

                If i.GoodsInfo.ID = value.GoodsID Then

                    i.RefreshValuesInWarehouse(value)
                    isFound = True
                    Exit For

                End If

            Next

            If Not isFound Then
                Throw New Exception(String.Format( _
                    Goods_GoodsPriceCutItemList_OrphanGoodsValue, _
                    value.GoodsID.ToString()))
            End If

        End Sub

        ''' <summary>
        ''' Gets a total price cut costs.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Function GetTotalCosts() As Double
            Dim result As Double = 0
            For Each i As GoodsOperationPriceCut In Me
                result = CRound(result + i.TotalValuePriceCut)
            Next
            Return result
        End Function

        ''' <summary>
        ''' Adds items in the list to the current collection.
        ''' </summary>
        ''' <param name="list"></param>
        ''' <remarks>Should only be called by a parent complex price cut document
        ''' because it does not handle CanChangeFinancialData and does not 
        ''' automaticaly initiate reloading of IChronologyValidator of the parent document.
        ''' (ListChanged event fired with type <see cref="ComponentModel.ListChangedType.Reset">ComponentModel.ListChangedType.Reset</see>,
        ''' not ItemAdded or ItemDeleted.</remarks>
        Friend Sub AddRange(ByVal list As GoodsPriceCutItemList)
            CheckNewListForConcurrentItems(list)
            Me.RaiseListChangedEvents = False
            For Each o As GoodsOperationPriceCut In list
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
        Private Sub CheckNewListForConcurrentItems(ByVal list As GoodsPriceCutItemList)

            If list Is Nothing OrElse list.Count < 1 Then
                Throw New Exception(Goods_GoodsPriceCutItemList_NewPriceCutItemListEmpty)
            End If

            Dim message As String = ""

            For Each newItem As GoodsOperationPriceCut In list
                For Each existingItem As GoodsOperationPriceCut In Me
                    If existingItem.GoodsInfo.ID = newItem.GoodsInfo.ID Then
                        message = AddWithNewLine(message, String.Format("{0} (ID={1})", _
                            existingItem.GoodsInfo.Name, existingItem.GoodsInfo.ID), False)
                        Exit For
                    End If
                Next
            Next

            For Each newItem As GoodsOperationPriceCut In list
                For Each deletedItem As GoodsOperationPriceCut In Me
                    If Not deletedItem.IsNew AndAlso deletedItem.GoodsInfo.ID = newItem.GoodsInfo.ID Then
                        message = AddWithNewLine(message, String.Format("{0} (ID={1})", _
                            deletedItem.GoodsInfo.Name, deletedItem.GoodsInfo.ID), False)
                        Exit For
                    End If
                Next
            Next

            If Not String.IsNullOrEmpty(message) Then
                Throw New Exception(String.Format(Goods_GoodsPriceCutItemList_DuplicateItemsInNewPriceCutItemList, _
                    vbCrLf, message))
            End If

        End Sub

        ''' <summary>
        ''' Gets an array of param objects for a <see cref="GoodsPriceInWarehouseItemList">query object</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Function GetGoodsPriceInWarehouseParams() As GoodsPriceInWarehouseParam()
            Dim result As New List(Of GoodsPriceInWarehouseParam)
            For Each i As GoodsOperationPriceCut In Me
                result.Add(i.GetGoodsPriceInWarehouseParam)
            Next
            Return result.ToArray
        End Function


        Friend Function GetLimitations() As OperationalLimitList()
            Dim result As New List(Of OperationalLimitList)
            For Each i As GoodsOperationPriceCut In Me
                result.Add(i.OperationLimitations)
            Next
            Return result.ToArray
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a collection of new goods price cut operations created for 
        ''' goods ID's specified. Use <see cref="GoodsComplexOperationPriceCut.AddRange">
        ''' GoodsComplexOperationPriceCut.AddRange</see> method to add them 
        ''' to a complex goods price cut document.
        ''' </summary>
        ''' <param name="goodsIDs"><see cref="GoodsItem.ID">an array of goods ID's
        ''' that the operation list should be fetched for</see></param>
        ''' <param name="parentValidator">a chronologic validator of a parent document
        ''' that the operation list should be fetched for</param>
        ''' <remarks></remarks>
        Public Shared Function NewGoodsPriceCutItemList(ByVal goodsIDs As Integer(), _
            ByVal parentValidator As IChronologicValidator) As GoodsPriceCutItemList
            Return DataPortal.Create(Of GoodsPriceCutItemList) _
                (New Criteria(goodsIDs, parentValidator))
        End Function

        ''' <summary>
        ''' Gets a new GoodsPriceCutItemList instance to be added 
        ''' to a new complex goods price cut operation.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsPriceCutItemList() As GoodsPriceCutItemList
            Return New GoodsPriceCutItemList
        End Function

        ''' <summary>
        ''' Gets a GoodsPriceCutItemList instance for an existing complex goods price cut 
        ''' operation using database query data.
        ''' </summary>
        ''' <param name="myData">a database query result containg goods operation data</param>
        ''' <param name="limitationsDataSource">a database query result containg 
        ''' chronologic validation data</param>
        ''' <param name="parentValidator">a parent document's IChronologyValidator</param>
        ''' <remarks></remarks>
        Friend Shared Function GetGoodsPriceCutItemList(ByVal myData As DataTable, _
            ByVal limitationsDataSource As DataTable, ByVal parentValidator As IChronologicValidator) As GoodsPriceCutItemList
            Return New GoodsPriceCutItemList(myData, limitationsDataSource, parentValidator)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal myData As DataTable, ByVal limitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = parentValidator.FinancialDataCanChange
            Fetch(myData, limitationsDataSource, parentValidator)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _IDs As Integer()
            Private _ParentValidator As IChronologicValidator
            Public ReadOnly Property IDs() As Integer()
                Get
                    Return _IDs
                End Get
            End Property
            Public ReadOnly Property ParentValidator() As IChronologicValidator
                Get
                    Return _ParentValidator
                End Get
            End Property
            Public Sub New(ByVal nIDs As Integer(), ByVal nParentValidator As IChronologicValidator)
                _IDs = nIDs
                _ParentValidator = nParentValidator
            End Sub
        End Class

        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)

            If Not GoodsComplexOperationPriceCut.CanAddObject() Then
                Throw New System.Security.SecurityException( _
                    My.Resources.Common_SecuritySelectDenied)
            End If

            If criteria.IDs Is Nothing OrElse criteria.IDs.Length < 1 Then
                Throw New Exception(Goods_GoodsPriceCutItemList_GoodsIdsNull)
            End If

            RaiseListChangedEvents = False

            For Each goodsID As Integer In criteria.IDs
                Add(GoodsOperationPriceCut.NewGoodsOperationPriceCutChild(goodsID, _
                    criteria.ParentValidator))
            Next

            RaiseListChangedEvents = True

        End Sub


        Private Sub Fetch(ByVal myData As DataTable, ByVal limitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator)

            RaiseListChangedEvents = False

            For Each dr As DataRow In myData.Rows
                Add(GoodsOperationPriceCut.GetGoodsOperationPriceCutChild( _
                    dr, limitationsDataSource, parentValidator))
            Next

            RaiseListChangedEvents = True

        End Sub

        Friend Sub Update(ByVal parent As GoodsComplexOperationPriceCut)

            RaiseListChangedEvents = False

            For Each item As GoodsOperationPriceCut In DeletedList
                If Not item.IsNew Then item.DeleteChild()
            Next
            DeletedList.Clear()

            For Each item As GoodsOperationPriceCut In Me
                If item.IsNew OrElse item.IsDirty Then
                    item.SaveChild(parent.ID, parent.JournalEntryID, _
                        parent.OperationalLimit.FinancialDataCanChange)
                End If
            Next

            RaiseListChangedEvents = True

        End Sub


        Friend Sub CheckIfCanUpdate(ByVal limitationsDataSource As DataTable, _
            ByVal parent As GoodsComplexOperationPriceCut)

            For Each i As GoodsOperationPriceCut In Me
                i.CheckIfCanUpdate(limitationsDataSource, parent.OperationalLimit.BaseValidator)
            Next

            For Each i As GoodsOperationPriceCut In Me.DeletedList
                i.SetParentProperties(parent.DocumentNumber, parent.Description)
                If i.IsNew OrElse i.IsDirty Then
                    i.CheckIfCanDelete(limitationsDataSource, parent.OperationalLimit.BaseValidator)
                End If
            Next

        End Sub

        Friend Function GetTotalBookEntryList() As BookEntryInternalList

            Dim result As BookEntryInternalList = BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

            For Each o As GoodsOperationPriceCut In Me
                result.AddRange(o.GetTotalBookEntryList())
            Next

            Return result

        End Function

#End Region

    End Class

End Namespace