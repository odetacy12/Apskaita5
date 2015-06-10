Imports ApskaitaObjects.Workers
Public Class F_LabourContractUpdate
    Implements ISupportsPrinting, IObjectEditForm

    Private Obj As ContractUpdate
    Private ContractSerial As String = ""
    Private ContractNumber As Integer = 0
    Private ContractUpdateID As Integer = 0
    Private Loading As Boolean = True


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If Not Obj Is Nothing Then Return Obj.ID
            Return 0
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(ContractUpdate)
        End Get
    End Property


    Public Sub New(ByVal nContractSerial As String, ByVal nContractNumber As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ContractSerial = nContractSerial
        ContractNumber = nContractNumber

    End Sub

    Public Sub New(ByVal nContractUpdateID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ContractUpdateID = nContractUpdateID

    End Sub


    Private Sub F_LabourContractUpdate_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

    End Sub

    Private Sub F_LabourContractUpdate_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not Obj Is Nothing AndAlso TypeOf Obj Is IIsDirtyEnough AndAlso _
            DirectCast(Obj, IIsDirtyEnough).IsDirtyEnough Then
            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))
            If answ <> "Taip" AndAlso answ <> "Ne" Then
                e.Cancel = True
                Exit Sub
            End If
            If answ = "Taip" Then
                If Not SaveObj() Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If

        GetFormLayout(Me)

    End Sub

    Private Sub F_LabourContractUpdate_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Workers.ContractUpdate.CanGetObject Then
            MsgBox("Klaida. Jūsų teisių nepakanka šiai informacijai gauti.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            DisableAllControls(Me)
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        Try
            If ContractUpdateID > 0 Then
                Obj = LoadObject(Of ContractUpdate)(Nothing, "GetContractUpdate", False, ContractUpdateID)
            Else
                Obj = LoadObject(Of ContractUpdate)(Nothing, "NewContractUpdate", False, ContractSerial, ContractNumber)
            End If

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Exit Sub
        End Try

        ContractUpdateBindingSource.DataSource = Obj

        ConfigureButtons()

        SetFormLayout(Me)

    End Sub


    Private Sub OkButton_Click(ByVal sender As System.Object, _
       ByVal e As System.EventArgs) Handles IOkButton.Click

        If Not SaveObj() Then Exit Sub
        Me.Hide()
        Me.Close()

    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IApplyButton.Click
        If SaveObj() Then ConfigureButtons()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ICancelButton.Click
        CancelObj()
    End Sub


    Private Sub LimitationsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LimitationsButton.Click

        If Obj Is Nothing OrElse String.IsNullOrEmpty(Obj.ChronologicValidator.LimitsExplanation.Trim) Then Exit Sub

        MsgBox(Obj.ChronologicValidator.LimitsExplanation, MsgBoxStyle.MsgBoxHelp, "Taikomi Ribojimai")

    End Sub

    Private Sub PositionChangedCheckBox_CheckedChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles PositionChangedCheckBox.CheckedChanged, _
        WorkLoadChangedCheckBox.CheckedChanged, WageChangedCheckBox.CheckedChanged, _
        ExtraPayChangedCheckBox.CheckedChanged, NpdChangedCheckBox.CheckedChanged, _
        PnpdChangedCheckBox.CheckedChanged, AnnualHolidayChangedCheckBox.CheckedChanged, _
        HolidayCorrectionChangedCheckBox.CheckedChanged

        PositionTextBox.ReadOnly = Not PositionChangedCheckBox.Checked
        WorkLoadAccTextBox.ReadOnly = Not WorkLoadChangedCheckBox.Checked
        WageAccTextBox.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange OrElse Not WageChangedCheckBox.Checked
        HumanReadableWageTypeComboBox.Enabled = Obj.ChronologicValidator.FinancialDataCanChange AndAlso WageChangedCheckBox.Checked
        ExtraPayAccTextBox.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange OrElse Not ExtraPayChangedCheckBox.Checked
        NPDAccTextBox.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange OrElse Not NpdChangedCheckBox.Checked
        PNPDAccTextBox.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange OrElse Not PnpdChangedCheckBox.Checked
        AnnualHolidayAccTextBox.ReadOnly = Obj.HolidayCompensationPayed OrElse Not AnnualHolidayChangedCheckBox.Checked
        HolidayCorrectionAccTextBox.ReadOnly = Obj.HolidayCompensationPayed OrElse Not HolidayCorrectionChangedCheckBox.Checked

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
        If Obj Is Nothing Then Exit Sub

        Using frm As New F_SendObjToEmail(Obj, 0)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, False, 0)
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, True, 0)
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function


    Private Function SaveObj() As Boolean

        If Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.BrokenRulesCollection.ToString( _
                Csla.Validation.RuleSeverity.Error), MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        If Obj.BrokenRulesCollection.WarningCount > 0 Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf _
                & Obj.BrokenRulesCollection.ToString(Csla.Validation.RuleSeverity.Warning) & vbCrLf
        Else
            Question = ""
        End If
        If Obj.IsNew Then
            Question = Question & "Ar tikrai norite įtraukti naujus duomenis?"
            Answer = "Nauji duomenys sėkmingai įtraukti."
        Else
            Question = Question & "Ar tikrai norite pakeisti duomenis?"
            Answer = "Duomenys sėkmingai pakeisti."
        End If

        If Not YesOrNo(Question) Then Return False

        Using bm As New BindingsManager(ContractUpdateBindingSource, Nothing, Nothing, True, False)

            Try
                Obj = LoadObject(Of ContractUpdate)(Obj, "Save", False)
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try

            bm.SetNewDataSource(Obj)

        End Using

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj()
        If Obj Is Nothing OrElse Obj.IsNew OrElse Not Obj.IsDirty Then Exit Sub
        Using bm As New BindingsManager(ContractUpdateBindingSource, Nothing, Nothing, True, True)
        End Using
    End Sub

    Private Sub ConfigureButtons()

        If Obj Is Nothing Then Exit Sub

        WageChangedCheckBox.Enabled = Obj.ChronologicValidator.FinancialDataCanChange
        ExtraPayChangedCheckBox.Enabled = Obj.ChronologicValidator.FinancialDataCanChange
        NpdChangedCheckBox.Enabled = Obj.ChronologicValidator.FinancialDataCanChange
        PnpdChangedCheckBox.Enabled = Obj.ChronologicValidator.FinancialDataCanChange

        PositionTextBox.ReadOnly = Not PositionChangedCheckBox.Checked
        WorkLoadAccTextBox.ReadOnly = Not WorkLoadChangedCheckBox.Checked
        WageAccTextBox.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange OrElse Not WageChangedCheckBox.Checked
        HumanReadableWageTypeComboBox.Enabled = Obj.ChronologicValidator.FinancialDataCanChange AndAlso WageChangedCheckBox.Checked
        ExtraPayAccTextBox.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange OrElse Not ExtraPayChangedCheckBox.Checked
        NPDAccTextBox.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange OrElse Not NpdChangedCheckBox.Checked
        PNPDAccTextBox.ReadOnly = Not Obj.ChronologicValidator.FinancialDataCanChange OrElse Not PnpdChangedCheckBox.Checked
        AnnualHolidayAccTextBox.ReadOnly = Not AnnualHolidayChangedCheckBox.Checked
        HolidayCorrectionAccTextBox.ReadOnly = Not HolidayCorrectionChangedCheckBox.Checked
        LimitationsButton.Visible = Not String.IsNullOrEmpty(Obj.ChronologicValidator.LimitsExplanation.Trim)

    End Sub

    Private Function SetDataSources() As Boolean

        LoadEnumLocalizedListToComboBox(HumanReadableWageTypeComboBox, GetType(WageType), False)

        Try

        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

End Class