Namespace HelperLists

    <Serializable()> _
    Public Class ServiceInfoList
        Inherits ReadOnlyListBase(Of ServiceInfoList, ServiceInfo)

#Region " Business Methods "

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.ServiceInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement filter and sorting in gridview
        <NonSerialized()> _
        Private _FilteredList As Csla.FilteredBindingList(Of ServiceInfo) = Nothing
        <NonSerialized()> _
        Private _Filter() As Object = Nothing


        Public Shared Function GetList() As ServiceInfoList

            Dim result As ServiceInfoList = CacheManager.GetItemFromCache(Of ServiceInfoList)( _
                GetType(ServiceInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of ServiceInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(ServiceInfoList), result, Nothing)
            End If

            Return result

        End Function

        Public Shared Function GetCachedFilteredList(ByVal ShowEmpty As Boolean, _
            ByVal ShowSales As Boolean, ByVal ShowPurchases As Boolean, _
            ByVal ShowObsolete As Boolean) As Csla.FilteredBindingList(Of ServiceInfo)

            Dim FilterToApply(3) As Object
            FilterToApply(0) = ConvertDbBoolean(ShowEmpty)
            FilterToApply(1) = ConvertDbBoolean(ShowSales)
            FilterToApply(2) = ConvertDbBoolean(ShowPurchases)
            FilterToApply(3) = ConvertDbBoolean(ShowObsolete)

            Dim result As Csla.FilteredBindingList(Of ServiceInfo) = _
                CacheManager.GetItemFromCache(Of Csla.FilteredBindingList(Of ServiceInfo)) _
                (GetType(ServiceInfoList), FilterToApply)

            If result Is Nothing Then

                Dim BaseList As ServiceInfoList = ServiceInfoList.GetList
                result = New Csla.FilteredBindingList(Of ServiceInfo)(BaseList, AddressOf ServiceInfoFilter)
                result.ApplyFilter("", FilterToApply)
                CacheManager.AddCacheItem(GetType(ServiceInfoList), result, FilterToApply)

            End If

            Return result

        End Function

        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(ServiceInfoList))
        End Sub

        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(ServiceInfoList))
        End Function

        Private Shared Function ServiceInfoFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing OrElse DirectCast(filterValue, Object()).Length < 4 Then Return True

            Dim ShowEmpty As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(0), Integer))
            Dim ShowSales As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(1), Integer))
            Dim ShowPurchases As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(2), Integer))
            Dim ShowObsolete As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(3), Integer))

            ' no criteria to apply
            If ShowEmpty AndAlso ShowObsolete AndAlso ShowSales AndAlso ShowPurchases Then Return True

            Dim CI As ServiceInfo = DirectCast(item, ServiceInfo)

            If Not ShowEmpty AndAlso Not CI.ID > 0 Then Return False
            If Not ShowObsolete AndAlso CI.IsObsolete Then Return False
            If Not ShowSales AndAlso CI.Type = Documents.TradedItemType.Sales Then Return False
            If Not ShowPurchases AndAlso CI.Type = Documents.TradedItemType.Purchases Then Return False

            Return True

        End Function

        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        Private Shared Function GetListOnServer() As ServiceInfoList
            Dim result As New ServiceInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function


        Public Function GetFilteredList() As Csla.FilteredBindingList(Of ServiceInfo)

            If _FilteredList Is Nothing Then

                _FilteredList = New Csla.FilteredBindingList(Of ServiceInfo) _
                    (New Csla.SortedBindingList(Of ServiceInfo)(Me), AddressOf ServiceInfoFilter)
                _Filter = New Object() {ConvertDbBoolean(False), ConvertDbBoolean(True), _
                    ConvertDbBoolean(True), ConvertDbBoolean(True)}
                _FilteredList.ApplyFilter("", _Filter)

            End If

            Return _FilteredList

        End Function

        Public Function ApplyFilter(ByVal ShowSales As Boolean, ByVal ShowPurchases As Boolean, _
            ByVal ShowObsolete As Boolean) As Boolean

            If _FilteredList Is Nothing Then _FilteredList = _
                New Csla.FilteredBindingList(Of ServiceInfo) _
                (New Csla.SortedBindingList(Of ServiceInfo)(Me), AddressOf ServiceInfoFilter)

            Dim FilterToApply(3) As Object
            FilterToApply(0) = ConvertDbBoolean(False)
            FilterToApply(1) = ConvertDbBoolean(ShowSales)
            FilterToApply(2) = ConvertDbBoolean(ShowPurchases)
            FilterToApply(3) = ConvertDbBoolean(ShowObsolete)
            _Filter = FilterToApply

            _FilteredList.ApplyFilter("", _Filter)

            Return True

        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public Sub New()
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
               "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Dim myComm As New SQLCommand("FetchServiceInfoList")

            Using myData As DataTable = myComm.Fetch

                Using contentData As DataTable = RegionalContentInfoList. _
                    GetRegionalContentInfoListDataTable(Of Documents.Service)()

                    Using priceData As DataTable = RegionalPriceInfoList. _
                        GetRegionalPriceInfoListDataTable(Of Documents.Service)()

                        RaiseListChangedEvents = False
                        IsReadOnly = False

                        Add(ServiceInfo.NewServiceInfo)

                        For Each dr As DataRow In myData.Rows
                            Add(ServiceInfo.GetServiceInfo(dr, contentData, priceData))
                        Next

                        IsReadOnly = True
                        RaiseListChangedEvents = True

                    End Using

                End Using

            End Using

        End Sub

#End Region

    End Class

End Namespace