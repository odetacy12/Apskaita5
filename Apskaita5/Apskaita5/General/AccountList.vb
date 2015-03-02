Namespace General

    <Serializable()> _
    Public Class AccountList
        Inherits BusinessListBase(Of AccountList, Account)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Private _IsFetchedFromFile As Boolean = False
        ' used as server side mediator between FetchFromFile and SaveAllList
        Private SettingsDictionary As Dictionary(Of DefaultAccountType, Long) = Nothing


        Public ReadOnly Property IsFetchedFromFile() As Boolean
            Get
                Return _IsFetchedFromFile
            End Get
        End Property

        Public ReadOnly Property IsSettingsDictionaryAvailable() As Boolean
            Get
                Return Not SettingsDictionary Is Nothing AndAlso SettingsDictionary.Count > 0
            End Get
        End Property

        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                Return IsDirty
            End Get
        End Property

        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As Account = Account.NewAccount
            Me.Add(NewItem)
            Return NewItem
        End Function

        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result

        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Sub Paste(ByVal pasteString As String, ByVal AssociatedReportItems As String(), _
            ByVal overwrite As Boolean)

            If pasteString Is Nothing OrElse String.IsNullOrEmpty(pasteString.Trim) Then _
                Throw New Exception("Klaida. Nėra ką paste'inti, clipboard'as tuščias.")
            If AssociatedReportItems Is Nothing Then Throw New ArgumentNullException( _
                "Parameter AssociatedReportItems cannot be null for method AccountList.AssociatedReportItems.")

            Dim itemList As New List(Of String)(AssociatedReportItems)
            For i As Integer = 1 To itemList.Count
                itemList(i - 1) = itemList(i - 1).Trim.ToUpper
            Next
            Dim canonicalItems As String() = itemList.ToArray

            RaiseListChangedEvents = False

            If overwrite Then Me.Clear()

            For Each dr As String In pasteString.Split(New String() {vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
                Add(Account.NewAccount(dr, canonicalItems))
            Next

            For Each a As Account In Me
                a.ValidateChild()
            Next

            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub

        Public Overrides Function Save() As AccountList

            If Not Me.Count > 0 Then Throw New Exception("Klaida. Neįvesta nė viena sąskaita.")

            If Not Me.IsValid Then Throw New Exception("Įvestuose duomenyse yra klaidų: " _
                 & GetAllBrokenRules())

            Dim result As AccountList = MyBase.Save()
            HelperLists.AccountInfoList.InvalidateCache()
            Return result

        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.AccountList1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return False
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.AccountList3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return False
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetAccountList() As AccountList
            Return DataPortal.Fetch(Of AccountList)(New Criteria())
        End Function

        Friend Shared Function GetAccountListFromFile(ByVal FileName As String) As AccountList
            Return New AccountList(FileName)
        End Function

        Private Sub New()
            ' require use of factory methods
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal FileName As String)
            ' require use of factory methods
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            FetchFromFile(FileName)
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
                "Klaida. Jūsų teisių nepakanka duomenims gauti.")

            Dim myComm As New SQLCommand("GetAccountList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False

                For Each dr As DataRow In myData.Rows
                    Add(Account.GetAccount(dr))
                Next

                RaiseListChangedEvents = True

            End Using

        End Sub

        Private Sub FetchFromFile(ByVal FileName As String)

            Using sr As IO.StreamReader = IO.File.OpenText(FileName)

                RaiseListChangedEvents = False

                SettingsDictionary = New Dictionary(Of DefaultAccountType, Long)
                _IsFetchedFromFile = True

                Dim input As String
                input = sr.ReadLine()
                While Not input Is Nothing

                    If Not String.IsNullOrEmpty(input.Trim) Then

                        Add(Account.NewAccount(input))

                        Dim DataArray As String() = input.Trim.Split(Chr(9))
                        For i As Integer = 4 To DataArray.Length
                            If Not String.IsNullOrEmpty(DataArray(i - 1).Trim) _
                                AndAlso Not SettingsDictionary.ContainsKey( _
                                ConvertEnumDatabaseStringCode(Of DefaultAccountType) _
                                (DataArray(i - 1).Trim.ToUpper)) AndAlso CLongSafe(DataArray(0), 0) > 0 Then _
                                    SettingsDictionary.Add(ConvertEnumDatabaseStringCode(Of DefaultAccountType) _
                                    (DataArray(i - 1).Trim.ToUpper), CLongSafe(DataArray(0), 0))
                        Next

                    End If

                    input = sr.ReadLine()

                End While

                RaiseListChangedEvents = True

            End Using

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai operacijai.")

            For Each item As Account In DeletedList
                If Not item.IsNew Then item.CheckIfCanDelete()
            Next

            DatabaseAccess.TransactionBegin()

            RaiseListChangedEvents = False

            For Each item As Account In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As Account In Me
                If item.IsNew Then
                    item.Insert(Me)
                ElseIf item.IsDirty Then
                    item.Update(Me)
                End If
            Next

            RaiseListChangedEvents = True

            DatabaseAccess.TransactionCommit()

        End Sub

        Friend Sub SaveToDatabase()

            If Not _IsFetchedFromFile Then Throw New Exception("Klaida. Metodas " _
                & "AccountList.SaveToDatabase skirtas tik tipinio plano generavimui iš failo.")

            RaiseListChangedEvents = False

            DeletedList.Clear()

            For Each item As Account In Me
                item.Insert(Me)
            Next

            If Not SettingsDictionary Is Nothing Then

                Dim myComm As SQLCommand
                For Each k As KeyValuePair(Of DefaultAccountType, Long) In SettingsDictionary

                    myComm = New SQLCommand("InsertCompanyAccount")
                    myComm.AddParam("?AA", ConvertEnumDatabaseCode(k.Key))
                    myComm.AddParam("?AB", k.Value)

                    myComm.Execute()

                Next

            End If

            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace