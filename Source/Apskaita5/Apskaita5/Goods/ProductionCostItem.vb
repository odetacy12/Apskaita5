Imports ApskaitaObjects.Attributes

Namespace Goods

    ''' <summary>
    ''' Represents production template (""recipe"") costs item, i.e. 
    ''' (template) production costs that should be added to the value of the
    ''' goods produced (when applying the template).
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="ProductionCostItemList">ProductionCostItemList</see>.
    ''' Values are stored in the database table kalkuliac_d.</remarks>
    <Serializable()> _
    Public NotInheritable Class ProductionCostItem
        Inherits BusinessBase(Of ProductionCostItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Account As Long = 0
        Private _Amount As Double = 0


        ''' <summary>
        ''' Gets an ID of the template production costs item
        ''' that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Data is stored in database field kalkuliac_d.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a costs <see cref="General.Account.ID">account</see> 
        ''' that should be credited when producing the goods in order to transfer
        ''' costs to the goods value.
        ''' </summary>
        ''' <remarks>Data is stored in database field kalkuliac_d.Sask.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 6)> _
        Public Property Account() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _Account <> value Then
                    _Account = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an amount of costs needed to produce a <see cref="ProductionCalculation.Amount">
        ''' standard amount of goods</see>.
        ''' </summary>
        ''' <remarks>Data is stored in database field kalkuliac_d.Kiek.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Amount) <> CRound(value) Then
                    _Amount = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
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
            Return String.Format(My.Resources.Goods_ProductionCostItem_ToString, _
                _Account.ToString, DblParser(_Amount, 2))
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.AccountFieldValidation, _
                New Csla.Validation.RuleArgs("Account"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Amount"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewProductionCostItem() As ProductionCostItem
            Dim result As New ProductionCostItem
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function GetProductionCostItem(ByVal dr As DataRow) As ProductionCostItem
            Return New ProductionCostItem(dr)
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

            _ID = CIntSafe(dr.Item(1), 0)
            _Account = CLongSafe(dr.Item(2), 0)
            _Amount = CDblSafe(dr.Item(3), 6, 0)

            MarkOld()

        End Sub

        Friend Sub Insert(ByVal parent As ProductionCalculation)

            Dim myComm As New SQLCommand("InsertProductionItem")
            AddWithParams(myComm)
            myComm.AddParam("?AA", parent.ID)
            myComm.AddParam("?AB", Utilities.ConvertDatabaseCharID(ProductionComponentType.Costs))

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As ProductionCalculation)

            Dim myComm As New SQLCommand("UpdateProductionItem")
            myComm.AddParam("?CD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteProductionItem")
            myComm.AddParam("?CD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AC", 0)
            myComm.AddParam("?AD", _Account)
            myComm.AddParam("?AE", CRound(_Amount, 6))
            myComm.AddParam("?AF", 0)

        End Sub

#End Region

    End Class

End Namespace