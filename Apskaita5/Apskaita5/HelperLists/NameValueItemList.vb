Namespace HelperLists

    <Serializable()> _
    Public Class NameValueItemList
        Inherits ReadOnlyListBase(Of NameValueItemList, NameValueItem)

#Region " Business Methods "

        Public Function GetItemByValue(ByVal ValueToFind As String) As NameValueItem
            For Each i As NameValueItem In Me
                If i.Value.Trim.ToLower.TrimStart(New Char() {"0"c}) = _
                    ValueToFind.Trim.ToLower.TrimStart(New Char() {"0"c}) Then Return i
            Next
            Return Nothing
        End Function

        Public Function GetItemByName(ByVal NameToFind As String) As NameValueItem
            For Each i As NameValueItem In Me
                If i.Name.Trim.ToLower = NameToFind.Trim.ToLower Then Return i
            Next
            Return Nothing
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.NameValueItemList1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetNameValueItemList(ByVal ListType As SettingListType) As NameValueItemList
            Return DataPortal.Fetch(Of NameValueItemList)(New Criteria(ListType))
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _Type As SettingListType
            Public ReadOnly Property [Type]() As SettingListType
                Get
                    Return _Type
                End Get
            End Property
            Public Sub New(ByVal nType As SettingListType)
                _Type = nType
            End Sub
        End Class

        <RunLocal()> _
        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            Using FR As IO.StreamReader = IO.File.OpenText(IO.Path.Combine(AppPath(), PULICCODESFILENAME))

                RaiseListChangedEvents = False
                IsReadOnly = False

                Dim SectionFound As Boolean = False
                Dim CurrentLine As String = FR.ReadLine
                Do Until CurrentLine Is Nothing

                    If Not String.IsNullOrEmpty(CurrentLine.Trim) Then

                        If CurrentLine.Contains("'''###") Then

                            If (CurrentLine.Trim.ToLower = ("'''###" & VMICODESGPMSLOT & "###'''").ToLower _
                                AndAlso criteria.Type = SettingListType.VmiCodeList) OrElse _
                                (CurrentLine.Trim.ToLower = ("'''###" & SODRACODESGPMSLOT & "###'''").ToLower _
                                AndAlso criteria.Type = SettingListType.SodraCodeList) OrElse _
                                (CurrentLine.Trim.ToLower = ("'''###" & MUNICIPALITIESCODESSLOT & "###'''").ToLower _
                                AndAlso criteria.Type = SettingListType.MunicipalityCodeList) OrElse _
                                (CurrentLine.Trim.ToLower = ("'''###" & SODRABRANCHESSLOT & "###'''").ToLower _
                                AndAlso criteria.Type = SettingListType.SodraBranchesList) OrElse _
                                (CurrentLine.Trim.ToLower = ("'''###" & CLASESESTATESLOT & "###'''").ToLower _
                                AndAlso criteria.Type = SettingListType.AssetGroupList) Then

                                SectionFound = True

                            Else

                                SectionFound = False

                            End If

                        ElseIf SectionFound Then

                            Add(NameValueItem.GetNameValueItem(CurrentLine))

                        End If

                    End If

                    CurrentLine = FR.ReadLine

                Loop

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace