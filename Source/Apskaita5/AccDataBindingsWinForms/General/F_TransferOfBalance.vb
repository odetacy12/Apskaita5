Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists
Imports ApskaitaObjects.General

Friend Class F_TransferOfBalance
    Implements ISingleInstanceForm, ISupportsChronologicValidator

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.PersonInfoList), GetType(HelperLists.AccountInfoList)}

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of TransferOfBalance)
    Private _ListViewManagerCredit As DataListViewEditControlManager(Of BookEntry)
    Private _ListViewManagerDebit As DataListViewEditControlManager(Of BookEntry)
    Private _ListViewManagerAnalytic As DataListViewEditControlManager(Of General.TransferOfBalanceAnalytics)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_TransferOfBalance_Load(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            ' TransferOfBalance.GetTransferOfBalance()
            _QueryManager.InvokeQuery(Of TransferOfBalance)(Nothing, "GetTransferOfBalance", _
                True, AddressOf OnDataSourceLoaded)

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti likučių perkėlimo operacijos duomenų.", ex), Nothing)
            DisableAllControls(Me)
        End Try

    End Sub

    Private Sub OnDataSourceLoaded(ByVal source As Object, ByVal exceptionHandled As Boolean)

        If exceptionHandled Then

            DisableAllControls(Me)
            Exit Sub

        ElseIf source Is Nothing Then

            ShowError(New Exception("Klaida. Nepavyko gauti likučių perkėlimo operacijos duomenų."), Nothing)
            DisableAllControls(Me)
            Exit Sub

        End If

        If Not SetDataSources(DirectCast(source, TransferOfBalance)) Then Exit Sub

        Try

            _FormManager = New CslaActionExtenderEditForm(Of TransferOfBalance) _
                (Me, TransferOfBalanceBindingSource, DirectCast(source, TransferOfBalance), _
                 _RequiredCachedLists, nOkButton, ApplyButton, nCancelButton, _
                 Nothing, ProgressFiller1)

            _FormManager.ManageDataListViewStates(DebetListDataListView, _
                CreditListDataListView, AnalyticListDataListView)

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti likučių perkėlimo operacijos duomenų.", ex), Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        ConfigureButtons()

    End Sub

    Private Function SetDataSources(ByVal source As TransferOfBalance) As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            _ListViewManagerCredit = New DataListViewEditControlManager(Of BookEntry) _
                (CreditListDataListView, Nothing, AddressOf OnItemsDeleteCredit, _
                 AddressOf OnItemAddCredit, Nothing, source)

            _ListViewManagerDebit = New DataListViewEditControlManager(Of BookEntry) _
                (DebetListDataListView, Nothing, AddressOf OnItemsDeleteDebit, _
                 AddressOf OnItemAddDebit, Nothing, source)

            _ListViewManagerAnalytic = New DataListViewEditControlManager(Of TransferOfBalanceAnalytics) _
                (AnalyticListDataListView, Nothing, AddressOf OnItemsDeleteAnalytic, _
                 AddressOf OnItemAddAnalytic, Nothing, source)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Dim CM2 As New ContextMenu()
        Dim CMItem1 As New MenuItem("Debeto likučius", AddressOf PasteAccButton_Click)
        CM2.MenuItems.Add(CMItem1)
        Dim CMItem2 As New MenuItem("Debeto likučius overwrite", AddressOf PasteAccButton_Click)
        CM2.MenuItems.Add(CMItem2)
        Dim CMItem3 As New MenuItem("Kredito likučius", AddressOf PasteAccButton_Click)
        CM2.MenuItems.Add(CMItem3)
        Dim CMItem4 As New MenuItem("Kredito likučius overwrite", AddressOf PasteAccButton_Click)
        CM2.MenuItems.Add(CMItem4)
        Dim CMItem5 As New MenuItem("Analitinius likučius", AddressOf PasteAccButton_Click)
        CM2.MenuItems.Add(CMItem5)
        Dim CMItem6 As New MenuItem("Analitinius likučius overwrite", AddressOf PasteAccButton_Click)
        CM2.MenuItems.Add(CMItem6)
        Dim CMItem7 As New MenuItem("Informacija apie formatą", AddressOf PasteAccButton_Click)
        CM2.MenuItems.Add(CMItem7)
        PasteAccButton.ContextMenu = CM2

        Return True

    End Function


    Private Sub OnItemsDeleteCredit(ByVal items As BookEntry())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Eilučių pašalinti neleidžiama:{0}{1}", vbCrLf, _
                _FormManager.DataSource.ChronologicValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        For Each item As BookEntry In items
            _FormManager.DataSource.CreditList.Remove(item)
        Next
    End Sub

    Private Sub OnItemsDeleteDebit(ByVal items As BookEntry())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Eilučių pašalinti neleidžiama:{0}{1}", vbCrLf, _
                _FormManager.DataSource.ChronologicValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        For Each item As BookEntry In items
            _FormManager.DataSource.DebetList.Remove(item)
        Next
    End Sub

    Private Sub OnItemsDeleteAnalytic(ByVal items As TransferOfBalanceAnalytics())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Eilučių pašalinti neleidžiama:{0}{1}", vbCrLf, _
                _FormManager.DataSource.ChronologicValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        For Each item As TransferOfBalanceAnalytics In items
            _FormManager.DataSource.AnalyticsList.Remove(item)
        Next
    End Sub

    Private Sub OnItemAddCredit()
        If _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Keisti dokumento finansinių duomenų negalima, įskaitant kontavimų pridėjimą:{0}{1}", vbCrLf, _
                _FormManager.DataSource.ChronologicValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        _FormManager.DataSource.CreditList.AddNew()
    End Sub

    Private Sub OnItemAddDebit()
        If _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Keisti dokumento finansinių duomenų negalima, įskaitant kontavimų pridėjimą:{0}{1}", vbCrLf, _
                _FormManager.DataSource.ChronologicValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        _FormManager.DataSource.DebetList.AddNew()
    End Sub

    Private Sub OnItemAddAnalytic()
        If _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Keisti dokumento finansinių duomenų negalima, įskaitant kontavimų pridėjimą:{0}{1}", vbCrLf, _
                _FormManager.DataSource.ChronologicValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        _FormManager.DataSource.AnalyticsList.AddNew()
    End Sub


    Private Sub PasteAccButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles PasteAccButton.Click

        If _FormManager.DataSource Is Nothing OrElse Not TransferOfBalance.CanEditObject Then Exit Sub

        If GetSenderText(sender).Trim.ToLower.Contains("informacija") Then
            MsgBox(General.BookEntry.GetPasteStringColumnsDescription,
                MsgBoxStyle.Information, "Info")
            Clipboard.SetText(String.Join(vbTab, General.BookEntry.GetPasteStringColumns))
            Exit Sub
        End If

        Dim overwrite As Boolean = GetSenderText(sender).Trim.ToLower.Contains("overwrite")

        If overwrite Then
            If GetSenderText(sender).Trim.ToLower.Contains("debeto") AndAlso _FormManager.DataSource.DebetList.Count > 0 Then
                If Not YesOrNo("Ar tikrai norite perrašyti visus debetinius likučius?") Then Exit Sub
            ElseIf GetSenderText(sender).Trim.ToLower.Contains("kredito") AndAlso _FormManager.DataSource.CreditList.Count > 0 Then
                If Not YesOrNo("Ar tikrai norite perrašyti visus kreditinius likučius?") Then Exit Sub
            ElseIf GetSenderText(sender).Trim.ToLower.Contains("analitinius") AndAlso _FormManager.DataSource.AnalyticsList.Count > 0 Then
                If Not YesOrNo("Ar tikrai norite perrašyti visus analitinius likučius?") Then Exit Sub
            End If
        End If

        Try
            Using busy As New StatusBusy
                If GetSenderText(sender).Trim.ToLower.Contains("kredito") Then
                    _FormManager.DataSource.PasteCreditList(Clipboard.GetText, overwrite)
                ElseIf GetSenderText(sender).Trim.ToLower.Contains("analitinius") Then
                    Dim data As DataTable = F_DataImport.GetImportedData(TransferOfBalanceAnalytics.GetDataTableSpecification)
                    If data Is Nothing Then Exit Sub
                    _FormManager.DataSource.LoadAnalyticsListFromTemplateDataTable(data, overwrite)
                Else ' let default be debet list
                    _FormManager.DataSource.PasteDebetList(Clipboard.GetText, overwrite)
                End If
            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
            Exit Sub
        End Try

    End Sub


    Public Function ChronologicContent() As String _
        Implements ISupportsChronologicValidator.ChronologicContent
        If _FormManager.DataSource Is Nothing Then Return ""
        Return _FormManager.DataSource.ChronologicValidator.LimitsExplanation
    End Function

    Public Function HasChronologicContent() As Boolean _
        Implements ISupportsChronologicValidator.HasChronologicContent

        Return Not _FormManager.DataSource Is Nothing AndAlso _
            Not StringIsNullOrEmpty(_FormManager.DataSource.ChronologicValidator.LimitsExplanation)

    End Function


    Private Sub _FormManager_DataSourceStateHasChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles _FormManager.DataSourceStateHasChanged
        ConfigureButtons()
    End Sub

    Private Sub ConfigureButtons()

        If _FormManager.DataSource Is Nothing Then Exit Sub

        nCancelButton.Enabled = Not (_FormManager.DataSource.IsNew)
        nOkButton.Enabled = General.TransferOfBalance.CanEditObject
        ApplyButton.Enabled = General.TransferOfBalance.CanEditObject
        PasteAccButton.Enabled = General.TransferOfBalance.CanEditObject

        _ListViewManagerAnalytic.IsReadOnly = Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange

        _ListViewManagerDebit.IsReadOnly = Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange

        _ListViewManagerCredit.IsReadOnly = Not _FormManager.DataSource.ChronologicValidator.FinancialDataCanChange

    End Sub

End Class