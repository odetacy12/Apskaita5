Namespace General

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>Values are stored in the database table financialstatementsstructure.</remarks>
    <Serializable()> _
    Public Class ConsolidatedReportItem
        Inherits BusinessBase(Of ConsolidatedReportItem)

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Name As String = ""
        Private _OldName As String = ""
        Private _Level As Integer = 0
        Private _Type As FinancialStatementItemType
        Private _IsCredit As Boolean = False
        Private _HasAccountsAssigned As Boolean = False
        Private _Children As ConsolidatedReportItemList _
            = ConsolidatedReportItemList.NewConsolidatedReportItemList


        ''' <summary>
        ''' Gets an ID of ConsolidatedReportItem, which defines sequence of items in the report.
        ''' Set method is marked as friend because ID is only assigned internaly from ConsolidatedReport.ResetChildrenID
        ''' when items ID's need to be reset (renumbered sequentialy) after loading from TreeView control
        ''' </summary>
        ''' <remarks>Value is stored in the database field financialstatementsstructure.ID.</remarks>
        Public Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Friend Set(ByVal value As Integer)
                If _ID <> value Then
                    _ID = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a name of ConsolidatedReportItem, i.e. text of the line in a Consolidated Report.
        ''' </summary>
        ''' <remarks>Value is stored in the database field financialstatementsstructure.Name.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255, False)> _
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
                    If _Type <> FinancialStatementItemType.HeaderGeneral AndAlso _
                        _Type <> FinancialStatementItemType.HeaderStatementOfComprehensiveIncome AndAlso _
                        _Type <> FinancialStatementItemType.HeaderStatementOfFinancialPosition Then _
                        _Name = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a value indicating if credit balance is considereded as positive value.
        ''' </summary>
        ''' <remarks>Value is stored in the database field financialstatementsstructure.IsCredit.</remarks>
        Public Property IsCredit() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsCredit
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _IsCredit <> value Then
                    If _Type <> FinancialStatementItemType.HeaderGeneral AndAlso _
                        _Type <> FinancialStatementItemType.HeaderStatementOfComprehensiveIncome AndAlso _
                        _Type <> FinancialStatementItemType.HeaderStatementOfFinancialPosition Then _
                        _IsCredit = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets an old name of ConsolidatedReportItem, i.e. before a change.
        ''' </summary>
        Public ReadOnly Property OldName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OldName
            End Get
        End Property

        ''' <summary>
        ''' Gets a level of ConsolidatedReportItem, i.e. 1 is parent, 2 is child of 1 etc.
        ''' Set method is marked as friend because level is only assigned internaly from 
        ''' ConsolidatedReport.ResetChildrenID when items ID's need to be reset (renumbered sequentialy)
        ''' after loading from TreeView control
        ''' </summary>
        ''' <remarks>Value is calculated, not stored in database.</remarks>
        Public ReadOnly Property Level() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Level
            End Get
        End Property

        ''' <summary>
        ''' Gets a type of ConsolidatedReportItem
        ''' </summary>
        ''' <remarks>Value is stored in the database field financialstatementsstructure.StatementType.</remarks>
        Public ReadOnly Property [Type]() As FinancialStatementItemType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
        End Property

        ''' <summary>
        ''' Returns value indicating if the item currently has any accounts assigned.
        ''' </summary>
        Public ReadOnly Property HasAccountsAssigned() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HasAccountsAssigned
            End Get
        End Property

        ''' <summary>
        ''' Gets a list of child ConsolidatedReportItem.
        ''' </summary>
        Public ReadOnly Property Children() As ConsolidatedReportItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Children
            End Get
        End Property


        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso _Children.IsValid
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _Children.IsDirty
            End Get
        End Property


        Public Function AddChild() As ConsolidatedReportItem

            If _Type = FinancialStatementItemType.HeaderGeneral OrElse _
                _Type = FinancialStatementItemType.HeaderStatementOfComprehensiveIncome OrElse _
                _Type = FinancialStatementItemType.HeaderStatementOfFinancialPosition Then _
                Throw New Exception(My.Resources.General_ConsolidatedReportItem_CannotChangeBaseItem)

            Dim NewChild As ConsolidatedReportItem = ConsolidatedReportItem.NewConsolidatedReportItem(False)
            NewChild._Children = ConsolidatedReportItemList.NewConsolidatedReportItemList
            NewChild._IsCredit = _IsCredit
            NewChild._Type = _Type
            NewChild._Level = _Level + 1

            _Children.Add(NewChild)

            Return NewChild

        End Function

        Public Function RemoveChild(ByVal ChildToRemove As ConsolidatedReportItem) As Boolean

            If DirectCast(ChildToRemove.GetIdValue, Guid) = DirectCast(Me.GetIdValue, Guid) Then _
                Throw New Exception(My.Resources.General_ConsolidatedReportItem_CannotChangeBaseItem)

            For Each c As ConsolidatedReportItem In _Children
                If DirectCast(c.GetIdValue, Guid) = DirectCast(ChildToRemove.GetIdValue, Guid) Then
                    If c._Type = FinancialStatementItemType.HeaderGeneral OrElse _
                        c._Type = FinancialStatementItemType.HeaderStatementOfComprehensiveIncome OrElse _
                        c._Type = FinancialStatementItemType.HeaderStatementOfFinancialPosition OrElse _
                        c._Level < 3 Then Throw New Exception(My.Resources.General_ConsolidatedReportItem_CannotChangeBaseItem)
                    _Children.Remove(ChildToRemove)
                    Return True
                End If
            Next

            For Each c As ConsolidatedReportItem In _Children
                If c.RemoveChild(ChildToRemove) Then Return True
            Next

            Return False

        End Function

        Public Function MoveChildUp(ByVal ChildToMove As ConsolidatedReportItem) As Boolean

            If ChildToMove._Guid = Me._Guid Then Throw New Exception( _
                My.Resources.General_ConsolidatedReportItem_CannotChangeBaseItem)

            For Each c As ConsolidatedReportItem In _Children
                If c._Guid = ChildToMove._Guid Then
                    If c._Type = FinancialStatementItemType.HeaderGeneral OrElse _
                        c._Type = FinancialStatementItemType.HeaderStatementOfComprehensiveIncome OrElse _
                        c._Type = FinancialStatementItemType.HeaderStatementOfFinancialPosition OrElse _
                        c._Level < 3 Then Throw New Exception(My.Resources.General_ConsolidatedReportItem_CannotChangeBaseItem)
                    _Children.MoveUp(ChildToMove).MarkDirty()
                    Return True
                End If
            Next

            For Each c As ConsolidatedReportItem In _Children
                If c.MoveChildUp(ChildToMove) Then Return True
            Next

            Return False

        End Function

        Public Function MoveChildDown(ByVal ChildToMove As ConsolidatedReportItem) As Boolean

            If ChildToMove._Guid = Me._Guid Then Throw New Exception( _
                My.Resources.General_ConsolidatedReportItem_CannotChangeBaseItem)

            For Each c As ConsolidatedReportItem In _Children
                If c._Guid = ChildToMove._Guid Then
                    If c._Type = FinancialStatementItemType.HeaderGeneral OrElse _
                        c._Type = FinancialStatementItemType.HeaderStatementOfComprehensiveIncome OrElse _
                        c._Type = FinancialStatementItemType.HeaderStatementOfFinancialPosition OrElse _
                        c._Level < 3 Then Throw New Exception(My.Resources.General_ConsolidatedReportItem_CannotChangeBaseItem)
                    _Children.MoveDown(ChildToMove).MarkDirty()
                    Return True
                End If
            Next

            For Each c As ConsolidatedReportItem In _Children
                If c.MoveChildDown(ChildToMove) Then Return True
            Next

            Return False

        End Function


        Public Function ChildExists(ByVal child As ConsolidatedReportItem) As Boolean

            If child Is Nothing Then Return False

            If child._Guid = Me._Guid Then Return True

            For Each c As ConsolidatedReportItem In Me._Children
                If c.ChildExists(child) Then Return True
            Next

            Return False

        End Function

        Public Function ChildExists(ByVal guidString As String) As Boolean

            If guidString Is Nothing OrElse String.IsNullOrEmpty(guidString.Trim) Then Return False

            If guidString = Me._Guid.ToString Then Return True

            For Each c As ConsolidatedReportItem In Me._Children
                If c.ChildExists(guidString) Then Return True
            Next

            Return False

        End Function

        Public Function GetGuid() As Guid
            Return _Guid
        End Function


        Public Function GetAllBrokenRules() As String
            Dim result As String = ""
            If Not MyBase.IsValid Then result = _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            For Each c As ConsolidatedReportItem In _Children
                result = AddWithNewLine(result, c.GetAllBrokenRules, False)
            Next
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = ""
            If Me.BrokenRulesCollection.WarningCount > 0 Then result = _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            For Each c As ConsolidatedReportItem In _Children
                result = AddWithNewLine(result, c.GetAllWarnings, False)
            Next
            Return result
        End Function

        Public Function HasWarnings() As Boolean

            If Me.BrokenRulesCollection.WarningCount > 0 Then Return True

            For Each c As ConsolidatedReportItem In _Children
                If c.HasWarnings Then Return True
            Next

            Return False

        End Function


        Friend Sub AddNames(ByRef Names As List(Of String))
            Names.Add(_Name.Trim)
            For Each c As ConsolidatedReportItem In _Children
                c.AddNames(Names)
            Next
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("Name"))
        End Sub

        Friend Sub CheckRules()
            Me.ValidationRules.CheckRules()
            For Each c As ConsolidatedReportItem In _Children
                c.CheckRules()
            Next
        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            ' no authorization is needed
            'AuthorizationRules.AllowWrite("", "")
        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new instance of ConsolidatedReportItem with default values set.
        ''' </summary>
        ''' <param name="createBaseStructure"></param>
        Friend Shared Function NewConsolidatedReportItem( _
            ByVal createBaseStructure As Boolean) As ConsolidatedReportItem
            Return New ConsolidatedReportItem(createBaseStructure)
        End Function

        ''' <summary>
        ''' Gets an existing instance of ConsolidatedReportItem from database query.
        ''' </summary>
        ''' <param name="index"></param>
        ''' <param name="myData">Database query reply data.</param>
        Friend Shared Function GetConsolidatedReportItem(ByVal myData As DataTable, _
            ByRef index As Integer) As ConsolidatedReportItem
            Return New ConsolidatedReportItem(myData, index)
        End Function

        ''' <summary>
        ''' Gets a new instance of ConsolidatedReportItem from xml data.
        ''' </summary>
        ''' <param name="node"><see cref="Xml.XmlNode">XmlNode</see> that contains information about item.</param>
        ''' <param name="level"></param>
        Friend Shared Function GetConsolidatedReportItem(ByVal node As Xml.XmlNode, _
            ByRef level As Integer) As ConsolidatedReportItem
            Return New ConsolidatedReportItem(node, level)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal createBaseStructure As Boolean)

            MarkAsChild()

            _Children = ConsolidatedReportItemList.NewConsolidatedReportItemList

            If createBaseStructure Then
                Create()
            End If

            MarkNew()
            ValidationRules.CheckRules()

        End Sub

        Private Sub New(ByVal myData As DataTable, ByRef index As Integer)
            MarkAsChild()
            Fetch(myData, index)
        End Sub

        Private Sub New(ByVal node As Xml.XmlNode, ByRef level As Integer)
            MarkAsChild()
            Fetch(node, level)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create()

            _Name = FinancialStatementsRootName
            _OldName = FinancialStatementsRootName
            _Type = FinancialStatementItemType.HeaderGeneral

            Dim NewBalanceSheetItem As New ConsolidatedReportItem
            NewBalanceSheetItem._Level = 1
            NewBalanceSheetItem._Name = BalanceStatementRootName
            NewBalanceSheetItem._OldName = BalanceStatementRootName
            NewBalanceSheetItem._Type = FinancialStatementItemType.HeaderStatementOfFinancialPosition
            NewBalanceSheetItem._Children = ConsolidatedReportItemList.NewConsolidatedReportItemList

            Dim NewEstateItem As New ConsolidatedReportItem
            NewEstateItem._Level = 2
            NewEstateItem._IsCredit = False
            NewEstateItem._Name = BalanceAssetsStatementRootName
            NewEstateItem._Type = FinancialStatementItemType.StatementOfFinancialPosition
            NewEstateItem._Children = ConsolidatedReportItemList.NewConsolidatedReportItemList

            Dim NewCapitalItem As New ConsolidatedReportItem
            NewCapitalItem._Level = 2
            NewCapitalItem._IsCredit = True
            NewCapitalItem._Name = BalanceCapitalStatementRootName
            NewCapitalItem._Type = FinancialStatementItemType.StatementOfFinancialPosition
            NewBalanceSheetItem._Children = ConsolidatedReportItemList.NewConsolidatedReportItemList

            NewBalanceSheetItem._Children.Add(NewEstateItem)
            NewBalanceSheetItem._Children.Add(NewCapitalItem)

            Dim NewIncomeStatementItem As New ConsolidatedReportItem
            NewIncomeStatementItem._Level = 1
            NewIncomeStatementItem._IsCredit = True
            NewIncomeStatementItem._Name = IncomeStatementRootName
            NewIncomeStatementItem._OldName = IncomeStatementRootName
            NewIncomeStatementItem._Type = FinancialStatementItemType.HeaderStatementOfComprehensiveIncome
            NewIncomeStatementItem._Children = ConsolidatedReportItemList.NewConsolidatedReportItemList

            Dim NewIncomeStatementFirstItem As New ConsolidatedReportItem
            NewIncomeStatementFirstItem._Level = 2
            NewIncomeStatementFirstItem._IsCredit = True
            NewIncomeStatementFirstItem._Name = IncomeStatementFirstItemRootName
            NewIncomeStatementFirstItem._Type = FinancialStatementItemType.StatementOfComprehensiveIncome
            NewIncomeStatementFirstItem._Children = ConsolidatedReportItemList.NewConsolidatedReportItemList

            NewIncomeStatementItem._Children.Add(NewIncomeStatementFirstItem)

            _Children.Add(NewBalanceSheetItem)
            _Children.Add(NewIncomeStatementItem)

        End Sub

        Private Sub Fetch(ByVal myData As DataTable, ByRef index As Integer)

            If myData.Rows.Count < 1 Then

                Create()

                MarkNew()
                ValidationRules.CheckRules()

                Exit Sub

            End If

            _ID = CIntSafe(myData.Rows(index).Item(0), 0)
            _Name = CStrSafe(myData.Rows(index).Item(1))
            _OldName = _Name
            _Level = CIntSafe(myData.Rows(index).Item(2), 0)
            _Type = EnumValueAttribute.ConvertDatabaseID(Of FinancialStatementItemType) _
                (CIntSafe(myData.Rows(index).Item(3), 0))
            _IsCredit = ConvertDbBoolean(CIntSafe(myData.Rows(index).Item(4), 0))
            _HasAccountsAssigned = ConvertDbBoolean(CIntSafe(myData.Rows(index).Item(5), 0))
            _Children = ConsolidatedReportItemList.NewConsolidatedReportItemList

            If index < myData.Rows.Count - 1 Then

                Dim NextLevel As Integer

                _Children.RaiseListChangedEvents = False

                For i As Integer = index + 1 To myData.Rows.Count - 1

                    NextLevel = CIntSafe(myData.Rows(i).Item(2), 0)

                    If NextLevel = _Level + 1 Then
                        _Children.Add(ConsolidatedReportItem.GetConsolidatedReportItem(myData, i))
                    ElseIf NextLevel <= _Level Then
                        Exit For
                    End If

                Next

                _Children.RaiseListChangedEvents = True

            End If

            ValidationRules.CheckRules()
            MarkOld()

        End Sub

        Private Sub Fetch(ByVal node As Xml.XmlNode, ByRef level As Integer)

            _Name = node.Item("Name").InnerText.Trim
            _IsCredit = ConvertDbBoolean(CIntSafe(node.Item("IsCredit").InnerText.Trim, 0))
            _Type = EnumValueAttribute.ConvertDatabaseID(Of FinancialStatementItemType) _
                (CIntSafe(node.Item("Type").InnerText.Trim, 0))
            _Level = level

            _Children = ConsolidatedReportItemList.NewConsolidatedReportItemList
            For Each n As Xml.XmlNode In node.Item("Children").ChildNodes
                _Children.Add(ConsolidatedReportItem.GetConsolidatedReportItem(n, level + 1))
            Next

            ValidationRules.CheckRules()
            MarkNew()

        End Sub

        Friend Shadows Function Save() As ConsolidatedReportItem

            If _Type <> FinancialStatementItemType.HeaderGeneral Then Throw New InvalidOperationException( _
                My.Resources.General_ConsolidatedReportItem_InvalidSaveOperation)

            Dim result As ConsolidatedReportItem = Me.Clone
            result._Children.Delete()
            result.Update(1)

            Return result

        End Function

        Friend Sub Update(ByRef index As Integer)

            Dim Left As Integer = index

            For Each i As ConsolidatedReportItem In _Children
                index += 1
                i.Update(index)
            Next

            index += 1

            Dim myComm As SQLCommand
            If IsNew Then
                myComm = New SQLCommand("InsertConsolidatedReportItem")
            Else
                myComm = New SQLCommand("UpdateConsolidatedReportItem")
                myComm.AddParam("?AA", _ID)
            End If
            myComm.AddParam("?AB", _Name)
            myComm.AddParam("?AC", ConvertDbBoolean(_IsCredit))
            myComm.AddParam("?AD", EnumValueAttribute.ConvertDatabaseID(_Type))
            myComm.AddParam("?AE", Left)
            myComm.AddParam("?AF", index)

            myComm.Execute()

            If IsNew Then _ID = Convert.ToInt32(myComm.LastInsertID)

            If Not IsNew Then

                myComm = New SQLCommand("UpdateConsolidatedReportAccounts")
                If _Children.Count > 0 Then
                    myComm.AddParam("?AA", "")
                Else
                    myComm.AddParam("?AA", _Name.Trim)
                End If
                myComm.AddParam("?AB", _OldName.Trim)

                myComm.Execute()

            End If

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            _Children.DeleteSelf()

            If IsNew Then Exit Sub

            Dim myComm As New SQLCommand("DeleteConsolidatedReportItem")
            myComm.AddParam("?AA", _ID)

            myComm.Execute()

            myComm = New SQLCommand("UpdateConsolidatedReportAccounts")
            myComm.AddParam("?AA", "")
            myComm.AddParam("?AB", _OldName.Trim)

            myComm.Execute()

        End Sub

        Friend Sub WriteXmlNode(ByRef writer As System.Xml.XmlWriter)

            writer.WriteStartElement("ConsolidatedReportItem")

            writer.WriteStartElement("Name")
            writer.WriteString(_Name.Trim)
            writer.WriteEndElement()

            writer.WriteStartElement("IsCredit")
            writer.WriteString(ConvertDbBoolean(_IsCredit).ToString)
            writer.WriteEndElement()

            writer.WriteStartElement("Type")
            writer.WriteString(EnumValueAttribute.ConvertDatabaseID(_Type).ToString)
            writer.WriteEndElement()

            writer.WriteStartElement("Children")
            For Each c As ConsolidatedReportItem In _Children
                c.WriteXmlNode(writer)
            Next
            writer.WriteEndElement()

            writer.WriteEndElement()

            MarkNew()

        End Sub

#End Region

    End Class

End Namespace