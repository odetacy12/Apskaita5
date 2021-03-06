Imports ApskaitaObjects.ActiveReports
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.Printing

Friend Class F_LongTermAssetComplexDocumentInfoList
    Implements ISupportsPrinting

    Private _FormManager As CslaActionExtenderReportForm(Of LongTermAssetComplexDocumentInfoList)
    Private _ListViewManager As DataListViewEditControlManager(Of LongTermAssetComplexDocumentInfo)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_LongTermAssetComplexDocumentInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

    End Sub

    Private Function SetDataSources() As Boolean

        Try

            _ListViewManager = New DataListViewEditControlManager(Of LongTermAssetComplexDocumentInfo) _
                (LongTermAssetComplexDocumentInfoListDataListView, ContextMenuStrip1, Nothing, _
                 Nothing, Nothing, Nothing)

            _ListViewManager.AddCancelButton = True
            _ListViewManager.AddButtonHandler("Keisti", "Keisti dokumento duomenis.", _
                AddressOf ChangeItem)
            _ListViewManager.AddButtonHandler("Ištrinti", "Pašalinti dokumento duomenis iš duomenų bazės.", _
                AddressOf DeleteItem)


            _ListViewManager.AddMenuItemHandler(ChangeItem_MenuItem, AddressOf ChangeItem)
            _ListViewManager.AddMenuItemHandler(DeleteItem_MenuItem, AddressOf DeleteItem)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            ' LongTermAssetComplexDocumentInfoList.GetLongTermAssetComplexDocumentInfoList(dateFrom, dateTo)
            _FormManager = New CslaActionExtenderReportForm(Of LongTermAssetComplexDocumentInfoList) _
                (Me, LongTermAssetComplexDocumentInfoListBindingSource, Nothing, Nothing, RefreshButton, _
                 ProgressFiller1, "GetLongTermAssetComplexDocumentInfoList", AddressOf GetReportParams)

            _FormManager.ManageDataListViewStates(LongTermAssetComplexDocumentInfoListDataListView)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        DateFromAccDatePicker.Value = Today.AddMonths(-3)

        Return True

    End Function


    Private Function GetReportParams() As Object()

        'LongTermAssetComplexDocumentInfoList.GetLongTermAssetComplexDocumentInfoList( _
        '    DateFromDateTimePicker.Value.Date, DateToDateTimePicker.Value.Date)
        Return New Object() {DateFromAccDatePicker.Value.Date, DateToAccDatePicker.Value.Date}

    End Function

    Private Sub ChangeItem(ByVal item As LongTermAssetComplexDocumentInfo)
        If item Is Nothing Then Exit Sub
        'AssetOperationManager.GetAssetOperation(item.ID, item.Type, True, item.AttachedJournalEntryID, DocumentType.None)
        _QueryManager.InvokeQuery(Of AssetOperationManager)(Nothing, "GetAssetOperation", True, _
            AddressOf OpenObjectEditForm, item.ID, item.Type, True, item.AttachedJournalEntryID, DocumentType.None)
    End Sub

    Private Sub DeleteItem(ByVal item As LongTermAssetComplexDocumentInfo)

        If item Is Nothing Then Exit Sub

        If AssetOperationManager.CheckIfAssetOperationEditFormOpen(item.ID, item.Type, True, True, True) Then Exit Sub

        If Not YesOrNo("Ar tikrai norite pašalinti kompleksinį IT dokumentą iš duomenų bazės?") Then Exit Sub

        ' AssetOperationManager.DeleteAssetOperation(item.ID, item.Type, True)
        _QueryManager.InvokeQuery(Of AssetOperationManager)(Nothing, "DeleteAssetOperation", False, _
            AddressOf OnItemDeleted, item.ID, item.Type, True)

    End Sub

    Private Sub OnItemDeleted(ByVal result As Object, ByVal exceptionHandled As Boolean)
        If exceptionHandled Then Exit Sub
        If Not YesOrNo("Dokumento duomenys sėkmingai pašalinti iš įmonės duomenų bazės. Atnaujinti sąrašą?") Then Exit Sub
        RefreshButton.PerformClick()
    End Sub


    Public Function GetMailDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetMailDropDownItems
        Return Nothing
    End Function

    Public Function GetPrintDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintDropDownItems
        Return Nothing
    End Function

    Public Function GetPrintPreviewDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintPreviewDropDownItems
        Return Nothing
    End Function

    Public Sub OnMailClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnMailClick
        If _FormManager.DataSource Is Nothing Then Exit Sub

        Using frm As New F_SendObjToEmail(_FormManager.DataSource, 0)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, False, 0, "ITDokumentuSuvestine", Me, _
                _ListViewManager.GetCurrentFilterDescription(), _
                _ListViewManager.GetDisplayOrderIndexes())
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, True, 0, "ITDokumentuSuvestine", Me, _
                _ListViewManager.GetCurrentFilterDescription(), _
                _ListViewManager.GetDisplayOrderIndexes())
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function

End Class