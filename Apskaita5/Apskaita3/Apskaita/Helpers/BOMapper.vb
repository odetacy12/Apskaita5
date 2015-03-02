Imports System.Reflection
Imports AccDataAccessLayer.Security
Imports ApskaitaObjects
Imports ApskaitaObjects.General
Imports ApskaitaObjects.Workers
Imports ApskaitaObjects.Assets
Public Module BOMapper

    Public Sub DatabasesToMenu()
        MDIParent1.OpenCompanyMenuItem.DropDownItems.Clear()

        Dim DBlist As DatabaseInfoList
        Try
            DBlist = DatabaseInfoList.GetDatabaseList
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        For i As Integer = 1 To DBlist.Count
            MDIParent1.OpenCompanyMenuItem.DropDownItems.Add _
            (DBlist.Item(i - 1).CompanyName, Nothing, New EventHandler(AddressOf MDIParent1.Baze))
            MDIParent1.OpenCompanyMenuItem.DropDownItems(i - 1).Tag = DBlist.Item(i - 1)
        Next
    End Sub

    Public Sub LogInPrimaryToGUI()

        MDIParent1.NewCompanyMenuItem.Enabled = (GetCurrentIdentity.IsLocalUser OrElse GetCurrentIdentity.IsAdmin)
        MDIParent1.UserAdministrationMenuItem.Enabled = Not GetCurrentIdentity.IsLocalUser
        MDIParent1.LogOffMenuItem.Enabled = False
        MDIParent1.DropCompanyMenuItem.Enabled = (GetCurrentIdentity.IsLocalUser OrElse GetCurrentIdentity.IsAdmin)
        MDIParent1.BackupMenuItem.Enabled = (GetCurrentIdentity.IsLocalUser OrElse _
            (GetCurrentIdentity.ConnectionType = AccDataAccessLayer.ConnectionType.Local AndAlso _
            (GetCurrentIdentity.SQLServer.Trim = "127.0.0.1" OrElse _
            GetCurrentIdentity.SQLServer.Trim.ToLower = "localhost")))
        MDIParent1.ChangePasswordMenuItem.Enabled = Not GetCurrentIdentity.IsLocalUser
        MDIParent1.UpgradeDBMenuItem.Enabled = (GetCurrentIdentity.IsLocalUser OrElse GetCurrentIdentity.IsAdmin)
        MDIParent1.QueryBrowserMenuItem.Enabled = (GetCurrentIdentity.IsLocalUser OrElse GetCurrentIdentity.IsAdmin)
        MDIParent1.SystemEditors_MenuItem.Enabled = (GetCurrentIdentity.IsLocalUser OrElse GetCurrentIdentity.IsAdmin)

        ' Turning of database related menus till user logs in a database
        MDIParent1.GeneralDataMenu.Enabled = False
        MDIParent1.DocumentsMenu.Enabled = False
        MDIParent1.AssetsMenu.Enabled = False
        MDIParent1.WorkersMenu.Enabled = False
        MDIParent1.ReportsMenu.Enabled = False
        MDIParent1.CurrencyRateChangeImpactCalculator_MenuItem.Enabled = False
        MDIParent1.ToolStrip1.Items("GeneralLedgerButton").Enabled = False
        MDIParent1.ToolStrip1.Items("BookEntriesTurnoverButton").Enabled = False
        MDIParent1.ToolStrip1.Items("InvoiceListButton").Enabled = False
        MDIParent1.ToolStrip1.Items("TillButton").Enabled = False
        MDIParent1.ToolStrip1.Items("PersonsButton").Enabled = False
        MDIParent1.ToolStrip1.Items("NewJournalEntryToolStripButton").Enabled = False
        MDIParent1.ToolStrip1.Items("MakeInvoiceButton").Enabled = False
        MDIParent1.ToolStrip1.Items("RegisterInvoiceButton").Enabled = False
        MDIParent1.ToolStrip1.Items("TillIncomeOrderButton").Enabled = False
        MDIParent1.ToolStrip1.Items("TillSpendingsOrderButton").Enabled = False
        MDIParent1.ToolStrip1.Items("ServiceInfoListButton").Enabled = False
        MDIParent1.ToolStrip1.Items("NewServiceButton").Enabled = False
        MDIParent1.ToolStrip1.Items("GoodsTurnoverInfoButton").Enabled = False
        MDIParent1.ToolStrip1.Items("NewGoodsItemButton").Enabled = False
        MDIParent1.ToolStrip1.Items("NewPersonButton").Enabled = False

    End Sub

    Public Sub LogOffToGUI()
        If IsLoggedInDB() Then Exit Sub

        MDIParent1.GeneralDataMenu.Enabled = False
        MDIParent1.DocumentsMenu.Enabled = False
        MDIParent1.AssetsMenu.Enabled = False
        MDIParent1.WorkersMenu.Enabled = False
        MDIParent1.ReportsMenu.Enabled = False
        MDIParent1.CurrencyRateChangeImpactCalculator_MenuItem.Enabled = False
        MDIParent1.ToolStrip1.Items("GeneralLedgerButton").Enabled = False
        MDIParent1.ToolStrip1.Items("BookEntriesTurnoverButton").Enabled = False
        MDIParent1.ToolStrip1.Items("InvoiceListButton").Enabled = False
        MDIParent1.ToolStrip1.Items("TillButton").Enabled = False
        MDIParent1.ToolStrip1.Items("PersonsButton").Enabled = False
        MDIParent1.ToolStrip1.Items("NewJournalEntryToolStripButton").Enabled = False
        MDIParent1.ToolStrip1.Items("MakeInvoiceButton").Enabled = False
        MDIParent1.ToolStrip1.Items("RegisterInvoiceButton").Enabled = False
        MDIParent1.ToolStrip1.Items("TillIncomeOrderButton").Enabled = False
        MDIParent1.ToolStrip1.Items("TillSpendingsOrderButton").Enabled = False
        MDIParent1.ToolStrip1.Items("ServiceInfoListButton").Enabled = False
        MDIParent1.ToolStrip1.Items("NewServiceButton").Enabled = False
        MDIParent1.ToolStrip1.Items("GoodsTurnoverInfoButton").Enabled = False
        MDIParent1.ToolStrip1.Items("NewGoodsItemButton").Enabled = False
        MDIParent1.ToolStrip1.Items("NewPersonButton").Enabled = False

        MDIParent1.ChangePasswordMenuItem.Enabled = Not GetCurrentIdentity.IsLocalUser

        'deaktyvuojam atsijungimo meniu punkta ir parodom fakta statuse
        MDIParent1.LogOffMenuItem.Enabled = False
        If My.Forms.MDIParent1.AdministrationMenu.DropDownItems( _
            My.Forms.MDIParent1.AdministrationMenu.DropDownItems.Count - 1).Text <> "" Then _
                My.Forms.MDIParent1.AdministrationMenu.DropDownItems _
                    .RemoveAt(MDIParent1.AdministrationMenu.DropDownItems.Count - 1)
        MDIParent1.StatusStrip.Items.Item(0).Text = "Neprisijungta prie jokios įmonės"

        For Each child As Form In MDIParent1.MdiChildren
            child.Close()
        Next

    End Sub

    Public Sub LogInToGUI()

        If Not IsLoggedInDB() Then Exit Sub

        MDIParent1.AdministrationMenu.DropDownItems.Add("Prisijungta: " & GetCurrentCompany.Name)
        MDIParent1.LogOffMenuItem.Enabled = True
        MDIParent1.StatusStrip.Items.Item(0).Text = "Prisijungė vartotojas '" _
            & GetCurrentIdentity.Name & "' įmonė: " & GetCurrentCompany.Name
        MDIParent1.CurrencyRateChangeImpactCalculator_MenuItem.Enabled = True

        MDIParent1.ChangePasswordMenuItem.Enabled = True

        MDIParent1.NewJournalEntryMenuItem.Enabled = General.JournalEntry.CanAddObject
        MDIParent1.AccumulativeCosts_MenuItem.Enabled = Documents.AccumulativeCosts.CanAddObject
        MDIParent1.GeneralLedgerMenuItem.Enabled = ActiveReports.JournalEntryInfoList.CanGetObject
        MDIParent1.BookEntriesTurnoverMenuItem.Enabled = ActiveReports.BookEntryInfoListParent.CanGetObject
        MDIParent1.JournalEntryTemplatesMenuItem.Enabled = HelperLists.TemplateJournalEntryInfoList.CanGetObject
        MDIParent1.TransferOfBalanceMenuItem.Enabled = General.TransferOfBalance.CanGetObject

        SetParentMenuItemAuthorization(MDIParent1.GeneralMenuItem)

        MDIParent1.PersonsMenuItem.Enabled = ActiveReports.PersonInfoItemList.CanGetObject
        MDIParent1.PersonGroupsMenuItem.Enabled = General.PersonGroupList.CanGetObject
        MDIParent1.NewPerson_MenuItem.Enabled = General.Person.CanAddObject
        MDIParent1.ImportedPersonList_MenuItem.Enabled = General.ImportedPersonList.CanAddObject

        SetParentMenuItemAuthorization(MDIParent1.PersonsGeneralMenuItem)

        MDIParent1.AccountsListMenuItem.Enabled = General.AccountList.CanGetObject
        MDIParent1.CompanyInfoMenuItem.Enabled = General.Company.CanGetObject
        MDIParent1.DocumentSerialList_MenuItem.Enabled = Settings.DocumentSerialList.CanGetObject

        SetParentMenuItemAuthorization(MDIParent1.GeneralDataMenu)

        MDIParent1.CashAccountList_MenuItem.Enabled = Documents.CashAccountList.CanGetObject
        MDIParent1.TillIncomeOrderMenuItem.Enabled = Documents.TillIncomeOrder.CanAddObject
        MDIParent1.TillSpendingsOrderMenuItem.Enabled = Documents.TillSpendingsOrder.CanAddObject
        MDIParent1.BankTransferMenuItem.Enabled = Documents.BankOperation.CanAddObject
        MDIParent1.BankImportMenuItem.Enabled = Documents.BankOperationItemList.CanAddObject
        MDIParent1.AdvanceReport_MenuItem.Enabled = Documents.AdvanceReport.CanAddObject
        MDIParent1.AdvanceReportListMenuItem.Enabled = ActiveReports.AdvanceReportInfoList.CanGetObject
        MDIParent1.CashOperationInfoListMenuItem.Enabled = ActiveReports.CashOperationInfoList.CanGetObject

        SetParentMenuItemAuthorization(MDIParent1.TillGeneralMenuItem)

        MDIParent1.InvoiceMadeMenuItem.Enabled = Documents.InvoiceMade.CanAddObject
        MDIParent1.InvoiceReceivedMenuItem.Enabled = Documents.InvoiceReceived.CanAddObject
        MDIParent1.InvoiceListMenuItem.Enabled = ActiveReports.InvoiceInfoItemList.CanGetObject

        SetParentMenuItemAuthorization(MDIParent1.InvoicesGeneralMenuItem)

        MDIParent1.ServiceListMenuItem.Enabled = Documents.Service.CanGetObject
        MDIParent1.NewService_MenuItem.Enabled = Documents.Service.CanAddObject
        MDIParent1.NewOffset_MenuItem.Enabled = Documents.Offset.CanAddObject

        SetParentMenuItemAuthorization(MDIParent1.DocumentsMenu)

        MDIParent1.GoodsGroupListMenuItem.Enabled = Goods.GoodsGroupList.CanGetObject
        MDIParent1.WarehouseList_MenuItem.Enabled = Goods.WarehouseList.CanGetObject
        MDIParent1.NewGoodsItem_MenuItem.Enabled = Goods.GoodsItem.CanAddObject
        MDIParent1.GoodsTurnoverInfoList_MenuItem.Enabled = ActiveReports.GoodsTurnoverInfoList.CanGetObject
        MDIParent1.GoodsOperationInfoList_MenuItem.Enabled = ActiveReports.GoodsOperationInfoListParent.CanGetObject
        MDIParent1.ProductionCalculationSheetList_MenuItem.Enabled = _
            ActiveReports.ProductionCalculationItemList.CanGetObject
        MDIParent1.NewProductionCalculation_MenuItem.Enabled = Goods.ProductionCalculation.CanAddObject
        MDIParent1.NewGoodsOperation_MenuItem.Enabled = Goods.GoodsComplexOperationDiscard.CanAddObject _
            OrElse Goods.GoodsComplexOperationInternalTransfer.CanAddObject _
            OrElse Goods.GoodsComplexOperationInventorization.CanAddObject _
            OrElse Goods.GoodsComplexOperationPriceCut.CanAddObject _
            OrElse Goods.GoodsComplexOperationProduction.CanAddObject _
            OrElse Goods.GoodsOperationAcquisition.CanAddObject _
            OrElse Goods.GoodsOperationAdditionalCosts.CanAddObject _
            OrElse Goods.GoodsOperationDiscard.CanAddObject _
            OrElse Goods.GoodsOperationDiscount.CanAddObject _
            OrElse Goods.GoodsOperationPriceCut.CanAddObject _
            OrElse Goods.GoodsOperationTransfer.CanAddObject _
            OrElse Goods.GoodsOperationValuationMethod.CanAddObject _
            OrElse Goods.GoodsOperationAccountChange.CanAddObject
        MDIParent1.GoodsComplexOperationTransferOfBalance_MenuItem.Enabled = _
            Goods.GoodsComplexOperationTransferOfBalance.CanGetObject
        MDIParent1.ImportedGoodsItemList_MenuItem.Enabled = Goods.ImportedGoodsItemList.CanAddObject

        MDIParent1.LTAPurchaseMenuItem.Enabled = LongTermAsset.CanAddObject
        MDIParent1.LTAListMenuItem.Enabled = LongTermAssetInfoList.CanGetObject
        MDIParent1.LTAMassOperationMenuItem.Enabled = LongTermAssetComplexDocument.CanAddObject
        MDIParent1.LongTermAssetCustomGroupList_MenuItem.Enabled = LongTermAssetCustomGroupList.CanGetObject

        SetParentMenuItemAuthorization(MDIParent1.AssetsMenu)

        MDIParent1.WorkerStatusMenuItem.Enabled = ActiveReports.ContractInfoList.CanGetObject
        MDIParent1.NewImprestSheetMenuItem.Enabled = Workers.ImprestSheet.CanAddObject
        MDIParent1.ImprestSheetInfoListMenuItem.Enabled = ActiveReports.ImprestSheetInfoList.CanGetObject
        MDIParent1.NewWageSheetMenuItem.Enabled = Workers.WageSheet.CanAddObject
        MDIParent1.WageSheetInfoListMenuItem.Enabled = ActiveReports.WageSheetInfoList.CanGetObject
        MDIParent1.WorkerInfoCardMenuItem.Enabled = ActiveReports.WorkerWageInfoReport.CanGetObject
        MDIParent1.PayOutNaturalPersonListMenuItem.Enabled = ActiveReports.PayOutNaturalPersonInfoList.CanGetObject
        MDIParent1.DeclarationMenuItem.Enabled = ActiveReports.Declaration.CanGetObject
        MDIParent1.WorkTimeClassList_MenuItem.Enabled = Workers.WorkTimeClassList.CanGetObject
        MDIParent1.WorkTimeSheet_MenuItem.Enabled = Workers.WorkTimeSheet.CanAddObject
        MDIParent1.WorkTimeSheetInfoList_MenuItem.Enabled = ActiveReports.WorkTimeSheetInfoList.CanGetObject

        SetParentMenuItemAuthorization(MDIParent1.WorkersMenu)

        MDIParent1.ConsolidatedReportMenuItem.Enabled = ActiveReports.FinancialStatementsInfo.CanGetObject
        MDIParent1.ConsolidatedReportStructureMenuItem.Enabled = General.ConsolidatedReport.CanGetObject
        MDIParent1.DebtsTableMenuItem.Enabled = ActiveReports.DebtInfoList.CanGetObject

        SetParentMenuItemAuthorization(MDIParent1.ReportsMenu)

        MDIParent1.PersonsButton.Enabled = ActiveReports.PersonInfoItemList.CanGetObject
        MDIParent1.NewPersonButton.Enabled = General.Person.CanAddObject
        MDIParent1.GeneralLedgerButton.Enabled = ActiveReports.JournalEntryInfoList.CanGetObject
        MDIParent1.BookEntriesTurnoverButton.Enabled = ActiveReports.BookEntryInfoListParent.CanGetObject
        MDIParent1.NewJournalEntryToolStripButton.Enabled = General.JournalEntry.CanAddObject
        MDIParent1.InvoiceListButton.Enabled = ActiveReports.InvoiceInfoItemList.CanGetObject
        MDIParent1.TillButton.Enabled = ActiveReports.CashOperationInfoList.CanGetObject
        MDIParent1.MakeInvoiceButton.Enabled = Documents.InvoiceMade.CanAddObject
        MDIParent1.RegisterInvoiceButton.Enabled = Documents.InvoiceReceived.CanAddObject
        MDIParent1.TillIncomeOrderButton.Enabled = Documents.TillIncomeOrder.CanAddObject
        MDIParent1.TillSpendingsOrderButton.Enabled = Documents.TillSpendingsOrder.CanAddObject
        MDIParent1.NewServiceButton.Enabled = Documents.Service.CanAddObject
        MDIParent1.ServiceInfoListButton.Enabled = HelperLists.ServiceInfoList.CanGetObject
        MDIParent1.GoodsTurnoverInfoButton.Enabled = ActiveReports.GoodsTurnoverInfoList.CanGetObject
        MDIParent1.NewGoodsItemButton.Enabled = Goods.GoodsItem.CanAddObject

    End Sub

    Private Sub SetParentMenuItemAuthorization(ByRef ParentMenuItem As ToolStripMenuItem)

        For Each t As ToolStripItem In ParentMenuItem.DropDownItems
            If Not TypeOf t Is ToolStripSeparator AndAlso t.Enabled Then
                ParentMenuItem.Enabled = True
                Exit Sub
            End If
        Next

        ParentMenuItem.Enabled = False

    End Sub



    Friend Sub SaveCommonSettingsLocal(ByVal settingsXmlString As String)
        Try
            MyCustomSettings.CommonSettings = settingsXmlString
            MyCustomSettings.Save()
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko išsaugoti programos nustatymų: " & ex.Message, ex))
        End Try
    End Sub

    Friend Function GetCommonSettingsLocal() As String
        Return MyCustomSettings.CommonSettings
    End Function



    Public Sub AddDGVColumnSelector(ByRef nDataGridView As DataGridView)
        Dim cs As DataGridViewColumnSelector = _
            New DataGridViewColumnSelector(nDataGridView)
        cs.MaxHeight = CInt(2 * Screen.PrimaryScreen.Bounds.Height / 3)
        cs.Width = 200
    End Sub

    Public Sub SetFormLayout(ByRef nForm As Form)
        FormSettings.SetFormProperties(nForm, MyCustomSettings.AutoSizeForm, _
            MyCustomSettings.FormPropertiesList)

        If GetCurrentIdentity.IsAuthenticatedWithDB AndAlso GetCurrentCompany.BaseCurrency.Trim.ToUpper <> "LTL" Then

            Dim baseCurrency As String = GetCurrentCompany.BaseCurrency.Trim.ToUpper

            SetBaseCurrencyLabels(DirectCast(nForm, Control), baseCurrency)

        End If

    End Sub

    Public Sub SetDataGridViewLayOut(ByRef nDataGridView As DataGridView)
        FormSettings.SetDataGridViewProperties(nDataGridView, _
            MyCustomSettings.AutoSizeDataGridViewColumns, MyCustomSettings.DataGridViewColumnPropertiesList)
    End Sub

    Public Sub GetFormLayout(ByVal nForm As Form)
        FormSettings.GetFormProperties(nForm, MyCustomSettings.AutoSizeForm, MyCustomSettings.FormPropertiesList)
        Try
            MyCustomSettings.FormPropertiesList = FormSettings.GetFormPropertiesStringCollection( _
                MyCustomSettings.FormPropertiesList)
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko išsaugoti programos nustatymų: " & ex.Message, ex))
        End Try
    End Sub

    Public Sub GetDataGridViewLayOut(ByRef nDataGridView As DataGridView)
        FormSettings.GetDataGridViewProperties(nDataGridView, MyCustomSettings.AutoSizeDataGridViewColumns, _
            MyCustomSettings.DataGridViewColumnPropertiesList)
        Try
            MyCustomSettings.DataGridViewColumnPropertiesList = FormSettings.GetColumnPropertiesStringCollection( _
                 MyCustomSettings.DataGridViewColumnPropertiesList)
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko išsaugoti programos nustatymų: " & ex.Message, ex))
        End Try
    End Sub

    Private Sub SetBaseCurrencyLabels(ByRef ctrl As Control, ByVal baseCurrency As String)

        If TypeOf ctrl Is Label Then
            DirectCast(ctrl, Label).Text = DirectCast(ctrl, Label).Text.Replace("LTL", baseCurrency)
        ElseIf TypeOf ctrl Is Button Then
            DirectCast(ctrl, Button).Text = DirectCast(ctrl, Button).Text.Replace("LTL", baseCurrency)
        ElseIf TypeOf ctrl Is DataGridView Then
            For Each col As DataGridViewColumn In DirectCast(ctrl, DataGridView).Columns
                col.HeaderText = col.HeaderText.Replace("LTL", baseCurrency)
            Next
        ElseIf ctrl.Controls.Count > 0 Then
            For Each childControl As Control In ctrl.Controls
                SetBaseCurrencyLabels(childControl, baseCurrency)
            Next
        End If

    End Sub



    Public Sub OpenDocumentInEditForm(ByVal JournalEntryID As Integer, _
        ByVal JournalEntryType As DocumentType)

        Select Case JournalEntryType

            Case DocumentType.None
                MDIParent1.LaunchForm(GetType(F_GeneralLedgerEntry), False, False, JournalEntryID, JournalEntryID)
            Case DocumentType.TransferOfBalance
                MDIParent1.LaunchForm(GetType(F_TransferOfBalance), True, False, 0)
            Case DocumentType.AdvanceReport
                MDIParent1.LaunchForm(GetType(F_AdvanceReport), False, False, JournalEntryID, JournalEntryID)
            Case DocumentType.BankOperation
                MDIParent1.LaunchForm(GetType(F_BankOperation), False, False, JournalEntryID, JournalEntryID)
            Case DocumentType.TillIncomeOrder
                MDIParent1.LaunchForm(GetType(F_TillIncomeOrder), False, False, JournalEntryID, JournalEntryID)
            Case DocumentType.TillSpendingOrder
                MDIParent1.LaunchForm(GetType(F_TillSpendingsOrder), False, False, JournalEntryID, JournalEntryID)
            Case DocumentType.Offset
                MDIParent1.LaunchForm(GetType(F_Offset), False, False, JournalEntryID, JournalEntryID)
            Case DocumentType.InvoiceMade
                MDIParent1.LaunchForm(GetType(F_InvoiceMade), False, False, JournalEntryID, JournalEntryID)
            Case DocumentType.InvoiceReceived
                MDIParent1.LaunchForm(GetType(F_InvoiceReceived), False, False, JournalEntryID, JournalEntryID)
            Case DocumentType.ImprestSheet
                MDIParent1.LaunchForm(GetType(F_ImprestSheet), False, False, JournalEntryID, JournalEntryID)
            Case DocumentType.WageSheet
                MDIParent1.LaunchForm(GetType(F_WageSheet), False, False, JournalEntryID, JournalEntryID)
            Case DocumentType.Amortization
                MDIParent1.LaunchForm(GetType(F_LongTermAssetOperation), False, _
                    False, JournalEntryID, JournalEntryID, False, True)
            Case DocumentType.LongTermAssetDiscard
                MDIParent1.LaunchForm(GetType(F_LongTermAssetOperation), False, _
                    False, JournalEntryID, JournalEntryID, False, True)
            Case DocumentType.LongTermAssetAccountChange
                MDIParent1.LaunchForm(GetType(F_LongTermAssetOperation), False, _
                    False, JournalEntryID, JournalEntryID, False, True)
            Case DocumentType.AccumulatedCosts
                MDIParent1.LaunchForm(GetType(F_AccumulativeCosts), False, _
                    False, JournalEntryID, JournalEntryID)

            Case DocumentType.GoodsProduction

                Dim IdInfo As Goods.GoodsOperationIdInfo
                Try
                    IdInfo = GetGoodsOperationIdInfo(JournalEntryID, JournalEntryType)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try

                MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationProduction), False, _
                    False, IdInfo.ID, IdInfo.ID)

            Case DocumentType.GoodsRevalue

                Dim IdInfo As Goods.GoodsOperationIdInfo
                Try
                    IdInfo = GetGoodsOperationIdInfo(JournalEntryID, JournalEntryType)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try

                If IdInfo.IsComplex Then
                    MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationPriceCut), False, _
                        False, IdInfo.ID, IdInfo.ID)
                Else
                    MDIParent1.LaunchForm(GetType(F_GoodsOperationPriceCut), False, _
                        False, IdInfo.ID, IdInfo.ID, False)
                End If

            Case DocumentType.GoodsWriteOff

                Dim IdInfo As Goods.GoodsOperationIdInfo
                Try
                    IdInfo = GetGoodsOperationIdInfo(JournalEntryID, JournalEntryType)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try

                If IdInfo.IsComplex Then
                    MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationDiscard), False, _
                        False, IdInfo.ID, IdInfo.ID)
                Else
                    MDIParent1.LaunchForm(GetType(F_GoodsOperationDiscard), False, _
                        False, IdInfo.ID, IdInfo.ID)
                End If

            Case DocumentType.GoodsInternalTransfer

                Dim IdInfo As Goods.GoodsOperationIdInfo
                Try
                    IdInfo = GetGoodsOperationIdInfo(JournalEntryID, JournalEntryType)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try

                MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationInternalTransfer), False, _
                    False, IdInfo.ID, IdInfo.ID)

            Case DocumentType.GoodsAccountChange

                Dim IdInfo As Goods.GoodsOperationIdInfo
                Try
                    IdInfo = GetGoodsOperationIdInfo(JournalEntryID, JournalEntryType)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try

                MDIParent1.LaunchForm(GetType(F_GoodsOperationAccountChange), False, _
                    False, IdInfo.ID, IdInfo.ID)

            Case DocumentType.GoodsInventorization

                Dim IdInfo As Goods.GoodsOperationIdInfo
                Try
                    IdInfo = GetGoodsOperationIdInfo(JournalEntryID, JournalEntryType)
                Catch ex As Exception
                    ShowError(ex)
                    Exit Sub
                End Try

                MDIParent1.LaunchForm(GetType(F_GoodsComplexOperationInventorization), False, _
                    False, IdInfo.ID, IdInfo.ID)

            Case DocumentType.ClosingEntries
                MsgBox("Klaida. Sąskaitų uždarymo operacija gali būti tik pašalinama " & _
                    "ir įvedama iš naujo, o ne redaguojama.", MsgBoxStyle.Exclamation, "Klaida")
            Case Else
                MsgBox("Klaida. Nenustatytas dokumento tipas.", MsgBoxStyle.Exclamation, "Klaida")
        End Select

    End Sub

    Private Function GetGoodsOperationIdInfo(ByVal JournalEntryID As Integer, _
        ByVal JournalEntryType As DocumentType) As Goods.GoodsOperationIdInfo

        Dim IdInfo As Goods.GoodsOperationIdInfo = LoadObject(Of Goods.GoodsOperationIdInfo) _
            (Nothing, "GetGoodsOperationIdInfo", True, JournalEntryID, JournalEntryType)

        If Not IdInfo.ID > 0 Then Throw New Exception( _
            "Klaida. Dėl nežinomų priežasčių nepavyko nustatyti prekių operacijos ID.")

        Return IdInfo

    End Function



    Public Function FetchCurrencyRate(ByVal CurrencyCode As String, _
        ByVal AtDate As Date) As AccWebCrawler.CurrencyRateList

        Dim paramList As New AccWebCrawler.CurrencyRateList
        paramList.Add(AtDate, CurrencyCode)

        Using frm As New AccWebCrawler.F_LaunchWebCrawler(paramList, GetCurrentCompany.BaseCurrency)
            If frm.ShowDialog <> DialogResult.OK OrElse frm.result Is Nothing _
                OrElse Not TypeOf frm.result Is AccWebCrawler.CurrencyRateList _
                OrElse DirectCast(frm.result, AccWebCrawler.CurrencyRateList).Count < 1 Then Return Nothing
            Return DirectCast(frm.result, AccWebCrawler.CurrencyRateList)
        End Using

    End Function

    Public Function FetchCurrencyRate(ByVal CurrencyList As AccWebCrawler.CurrencyRateList) _
        As AccWebCrawler.CurrencyRateList

        Using frm As New AccWebCrawler.F_LaunchWebCrawler(CurrencyList, GetCurrentCompany.BaseCurrency)
            If frm.ShowDialog <> DialogResult.OK OrElse frm.result Is Nothing _
                OrElse Not TypeOf frm.result Is AccWebCrawler.CurrencyRateList _
                OrElse DirectCast(frm.result, AccWebCrawler.CurrencyRateList).Count < 1 Then Return Nothing
            Return DirectCast(frm.result, AccWebCrawler.CurrencyRateList)
        End Using

    End Function



    Public Function LoadObject(Of T)(ByVal ObjectInstance As T, ByVal MethodName As String, _
        ByVal AllowCancel As Boolean, ByVal ParamArray Params As Object()) As T

        Dim result As T = Nothing

        If Not ObjectInstance Is Nothing Then ObjectInstance = _
            DirectCast(DirectCast(ObjectInstance, ICloneable).Clone, T)

        If MyCustomSettings.UseThreadingForDataTransfer Then

            Dim cfrm As Form = MDIParent1.ActiveForm

            Using frm As New F_AsyncLoad()
                frm.RunAsyncOperation(Of T)(ObjectInstance, MethodName, AllowCancel, Params)
                frm.ShowDialog()
                If Not cfrm Is Nothing Then cfrm.Activate()
                If Not frm.Exception Is Nothing Then Throw frm.Exception
                result = DirectCast(frm.Result, T)
            End Using

        Else

            Using busy As New StatusBusy
                Dim MI As MethodInfo = GetMethodInfo(GetType(T), (Not ObjectInstance Is Nothing), _
                    MethodName, Params)
                If ObjectInstance Is Nothing Then
                    result = DirectCast(MI.Invoke(Nothing, Params), T)
                Else
                    result = DirectCast(MI.Invoke(ObjectInstance, Params), T)
                End If
            End Using

        End If

        Return result

    End Function

    Public Function GetMethodInfo(ByVal ClassType As Type, ByVal IsInstanceMethod As Boolean, _
        ByVal MethodName As String, ByVal Params As Object()) As MethodInfo

        Dim ParamCount As Integer
        If Params Is Nothing Then
            ParamCount = 0
        Else
            ParamCount = Params.Length
        End If

        Dim Methods As MethodInfo()
        If IsInstanceMethod Then
            Methods = ClassType.GetMethods(BindingFlags.Public OrElse BindingFlags.Instance)
        Else
            Methods = ClassType.GetMethods(BindingFlags.Public OrElse BindingFlags.Static)
        End If

        For Each m As MethodInfo In Methods
            If m.Name.Trim.ToLower = MethodName.Trim.ToLower Then
                Dim MethodParams As ParameterInfo() = m.GetParameters
                If MethodParams.Length = 0 AndAlso ParamCount = 0 Then
                    Return m
                ElseIf MethodParams.Length = ParamCount Then
                    Dim ParamsIdentical As Boolean = True
                    For i As Integer = 1 To MethodParams.Length
                        If Not Params(i - 1) Is Nothing AndAlso Not (Params(i - 1).GetType _
                            Is MethodParams(i - 1).ParameterType OrElse _
                            (MethodParams(i - 1).ParameterType.IsInterface AndAlso _
                            Array.IndexOf(Params(i - 1).GetType.GetInterfaces, _
                            MethodParams(i - 1).ParameterType) >= 0)) Then

                            ParamsIdentical = False
                            Exit For

                        End If
                    Next
                    If ParamsIdentical Then Return m
                End If
            End If
        Next

        Throw New Exception("Method '" & MethodName & "' for type '" & ClassType.FullName _
            & "' with param count " & ParamCount.ToString & " is unknown.")

    End Function


    Public Function LoadObjectFromCombo(Of T)(ByVal Combo As ComboBox, ByVal IdPropertyName As String) As T

        If Combo Is Nothing Then Throw New ArgumentNullException( _
            "Klaida. Metodui LoadObjectFromCombo nenurodytas ComboBox'as")
        If IdPropertyName Is Nothing Then IdPropertyName = ""
        IdPropertyName = IdPropertyName.Trim

        Dim result As T = Nothing

        If TypeOf Combo Is AccControls.AccGridComboBox Then

            If DirectCast(Combo, AccGridComboBox).SelectedValue Is Nothing OrElse _
                Not TypeOf DirectCast(Combo, AccGridComboBox).SelectedValue Is T Then Return result

            result = DirectCast(DirectCast(Combo, AccGridComboBox).SelectedValue, T)

        ElseIf TypeOf Combo Is ComboBox Then

            If DirectCast(Combo, ComboBox).SelectedIndex < 0 OrElse _
                DirectCast(Combo, ComboBox).SelectedItem Is Nothing OrElse _
                Not TypeOf DirectCast(Combo, ComboBox).SelectedItem Is T Then Return result

            result = DirectCast(DirectCast(Combo, ComboBox).SelectedItem, T)

        Else
            Throw New NotImplementedException("Klaida. Control tipas '" _
                & Combo.GetType.FullName & "' neimplementuotas metode LoadObjectFromCombo.")
        End If

        If Not String.IsNullOrEmpty(IdPropertyName.Trim) AndAlso _
            Not result.GetType.GetProperty(IdPropertyName.Trim) Is Nothing AndAlso _
            Not result.GetType.GetProperty(IdPropertyName.Trim).GetValue(result, Nothing) Is Nothing AndAlso _
            Not Convert.ToInt16(result.GetType.GetProperty(IdPropertyName.Trim).GetValue(result, Nothing)) > 0 Then _
            Return Nothing

        Return result

    End Function

    Public Sub SetControlReadOnly(Of T As Control)(ByRef cntr As T, ByVal isReadOnly As Boolean)

        Try
            CType(cntr, Object).ReadOnly = isReadOnly
        Catch ex As Exception
            cntr.Enabled = Not isReadOnly
        End Try

        If isReadOnly Then
            cntr.BackColor = System.Drawing.SystemColors.Control
        Else
            cntr.BackColor = System.Drawing.SystemColors.Window
        End If

    End Sub

    Public Function GetSenderText(ByVal sender As Object) As String
        If sender Is Nothing Then Return ""
        Try
            Return sender.Text
        Catch ex As Exception
            Return ""
        End Try
    End Function

End Module


Public Structure PropertyDescription
    Public PropertyName As String
    Public Header As String
    Public IsReadOnly As Boolean
    Public IsVisible As Boolean
    Public UseCheckboxes As Boolean
    Public Format As String

    Shared Function NewOne(ByVal nPropertyName As String, ByVal nHeader As String, ByVal nIsReadOnly As Boolean, _
        ByVal nIsVisible As Boolean, ByVal nUseCheckboxes As Boolean, ByVal nFormat As String) As PropertyDescription
        Dim result As PropertyDescription
        result.IsVisible = nIsVisible
        result.IsReadOnly = nIsReadOnly
        result.PropertyName = nPropertyName
        result.UseCheckboxes = nUseCheckboxes
        result.Header = nHeader
        result.Format = nFormat
        Return result
    End Function
End Structure


