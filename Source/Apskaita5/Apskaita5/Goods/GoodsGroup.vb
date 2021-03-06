Imports ApskaitaObjects.Attributes

Namespace Goods

    ''' <summary>
    ''' Represents a custom (company specific) group of goods.
    ''' </summary>
    ''' <remarks>Values are stored in the database table prekes_gr.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsGroup
        Inherits BusinessBase(Of GoodsGroup)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Name As String = ""
        Private _IsInUse As Boolean = False


        ''' <summary>
        ''' Gets an ID of the custom goods group that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Data is stored in database field prekes_gr.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a name of the custom goods group.
        ''' </summary>
        ''' <remarks>Data is stored in database field prekes_gr.Name.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Name.Trim <> value.Trim Then
                    _Name = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Whether the custom goods group is currently assigned to any goods.
        ''' </summary>
        ''' <remarks>Data retrieved by a subquery.</remarks>
        Public ReadOnly Property IsInUse() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsInUse
            End Get
        End Property



        ''' <summary>
        ''' Gets a human readable description of all the validation errors.
        ''' Returns <see cref="String.Empty" /> if no errors.
        ''' </summary>
        ''' <returns>A human readable description of all the validation errors.
        ''' Returns <see cref="String.Empty" /> if no errors.</returns>
        ''' <remarks></remarks>
        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
        End Function

        ''' <summary>
        ''' Gets a human readable description of all the validation warnings.
        ''' Returns <see cref="String.Empty" /> if no warnings.
        ''' </summary>
        ''' <returns>A human readable description of all the validation warnings.
        ''' Returns <see cref="String.Empty" /> if no warnings.</returns>
        ''' <remarks></remarks>
        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning))
        End Function

        ''' <summary>
        ''' Whether there are any validation warnings.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function HasWarnings() As Boolean
            Return Me.BrokenRulesCollection.WarningCount > 0
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return _Name
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Name"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringValueUniqueInCollectionValidation, _
                New Csla.Validation.RuleArgs("Name"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewGoodsGroup() As GoodsGroup
            Dim result As New GoodsGroup
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function GetGoodsGroup(ByVal dr As DataRow) As GoodsGroup
            Return New GoodsGroup(dr)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.Item(0), 0)
            _Name = CStrSafe(dr.Item(1)).Trim
            _IsInUse = ConvertDbBoolean(CIntSafe(dr.Item(2), 0))

            MarkOld()

        End Sub

        Friend Sub Insert()

            Dim myComm As New SQLCommand("InsertGoodsGroup")
            AddWithParams(myComm)

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update()

            Dim myComm As New SQLCommand("UpdateGoodsGroup")
            myComm.AddParam("?CD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteGoodsGroup")
            myComm.AddParam("?CD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AA", _Name.Trim)

        End Sub

#End Region

    End Class

End Namespace