Namespace ActiveReports

    ''' <summary>
    ''' Represents a report that contains <see cref="Documents.Service">service data</see>.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public NotInheritable Class ServiceInfoItemList
        Inherits ReadOnlyListBase(Of ServiceInfoItemList, ServiceInfoItem)

#Region " Business Methods "

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.ServiceInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a current service info report from the database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function GetServiceInfoItemList() As ServiceInfoItemList
            Return DataPortal.Fetch(Of ServiceInfoItemList)(New Criteria())
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
               My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchServiceInfoList")
            myComm.AddParam("?LN", LanguageCodeLith)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(ServiceInfoItem.GetServiceInfoItem(dr))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace