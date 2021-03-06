Namespace Security.DatabaseTableAccess

    <Serializable()> _
Public Class DatabaseTableAccessRole
        Inherits BusinessBase(Of DatabaseTableAccessRole)

#Region " Business Methods "

        Private _GID As Guid = Guid.NewGuid
        Private _VisibleIndex As Integer = 0
        Private _RoleName As String = ""
        Private _RoleNameHumanReadable As String = ""
        Private _TableAccessList As String = ""
        Private _ReadOnlyTableAccessList As String = ""
        Private _IsHelperList As Boolean = False
        Private _ParentRoles As String = ""


        Public Property VisibleIndex() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _VisibleIndex
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _VisibleIndex <> value Then
                    _VisibleIndex = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property RoleName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _RoleName.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _RoleName.Trim <> value.Trim Then
                    _RoleName = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property RoleNameHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _RoleNameHumanReadable.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _RoleNameHumanReadable.Trim <> value.Trim Then
                    _RoleNameHumanReadable = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property TableAccessList() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TableAccessList
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _TableAccessList.Trim <> value.Trim Then
                    _TableAccessList = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property ReadOnlyTableAccessList() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ReadOnlyTableAccessList
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _ReadOnlyTableAccessList.Trim <> value.Trim Then
                    _ReadOnlyTableAccessList = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property IsHelperList() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsHelperList
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _IsHelperList <> value Then
                    _IsHelperList = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property ParentRoles() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ParentRoles.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _ParentRoles.Trim <> value.Trim Then
                    _ParentRoles = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property


        Protected Overrides Function GetIdValue() As Object
            Return _GID
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.StringRequiredRuleArgs("RoleName", "teisės (Role) kodas"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.StringRequiredRuleArgs("RoleNameHumanReadable", _
                "teisės (Role) pavadinimas"))
        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            ' TODO: add authorization rules
            'AuthorizationRules.AllowWrite("", "")
        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewRoleDatabaseAccess() As DatabaseTableAccessRole
            Return New DatabaseTableAccessRole
        End Function

        Friend Shared Function NewRoleDatabaseAccess(ByVal PasteString As String) As DatabaseTableAccessRole
            Return New DatabaseTableAccessRole(PasteString)
        End Function

        Friend Shared Function GetRoleDatabaseAccess(ByVal node As Xml.XmlNode) As DatabaseTableAccessRole
            Return New DatabaseTableAccessRole(node)
        End Function


        Private Sub New()
            MarkAsChild()
            ValidationRules.CheckRules()
        End Sub

        Private Sub New(ByVal PasteString As String)
            MarkAsChild()
            Create(PasteString)
        End Sub

        Private Sub New(ByVal node As Xml.XmlNode)
            MarkAsChild()
            Fetch(node)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal PasteString As String)

            Dim colDelim As Char() = {ControlChars.Tab}

            _VisibleIndex = Integer.Parse(PasteString.Split(colDelim, StringSplitOptions.None)(0))
            _RoleName = PasteString.Split(colDelim, StringSplitOptions.None)(1)
            _RoleNameHumanReadable = PasteString.Split(colDelim, StringSplitOptions.None)(2)
            _TableAccessList = PasteString.Split(colDelim, StringSplitOptions.None)(3)
            _ReadOnlyTableAccessList = PasteString.Split(colDelim, StringSplitOptions.None)(4)
            _IsHelperList = Boolean.Parse(PasteString.Split(colDelim, StringSplitOptions.None)(5))
            If PasteString.Split(colDelim, StringSplitOptions.None).Length > 6 Then _
                _ParentRoles = PasteString.Split(colDelim, StringSplitOptions.None)(6)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal node As Xml.XmlNode)

            _VisibleIndex = Integer.Parse(node.Attributes.GetNamedItem("VisibleIndex").Value)
            _RoleName = node.Attributes.GetNamedItem("RoleName").Value
            _RoleNameHumanReadable = node.Attributes.GetNamedItem("RoleNameHumanReadable").Value
            _TableAccessList = node.Attributes.GetNamedItem("DatabaseTableAccessList").Value
            _ReadOnlyTableAccessList = node.Attributes.GetNamedItem("DatabaseReadOnlyTableAccessList").Value
            _IsHelperList = Boolean.Parse(node.Attributes.GetNamedItem("IsHelperList").Value)
            _ParentRoles = node.Attributes.GetNamedItem("ParentRoles").Value

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert(ByVal writer As Xml.XmlWriter)

            writer.WriteStartElement("RoleDatabaseAccess")

            writer.WriteStartAttribute("VisibleIndex")
            writer.WriteValue(_VisibleIndex)
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("RoleName")
            writer.WriteValue(_RoleName)
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("RoleNameHumanReadable")
            writer.WriteValue(_RoleNameHumanReadable)
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("DatabaseTableAccessList")
            writer.WriteValue(_TableAccessList)
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("DatabaseReadOnlyTableAccessList")
            writer.WriteValue(_ReadOnlyTableAccessList)
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("IsHelperList")
            writer.WriteValue(_IsHelperList)
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("ParentRoles")
            writer.WriteValue(_ParentRoles)
            writer.WriteEndAttribute()

            writer.WriteEndElement()

            MarkOld()

        End Sub

#End Region

    End Class

End Namespace