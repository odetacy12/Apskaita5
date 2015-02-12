<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_BankOperation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim AccountLabel As System.Windows.Forms.Label
        Dim AccountCurrencyLabel As System.Windows.Forms.Label
        Dim AccountCurrencyRateChangeImpactLabel As System.Windows.Forms.Label
        Dim ContentLabel As System.Windows.Forms.Label
        Dim CurrencyCodeLabel As System.Windows.Forms.Label
        Dim CurrencyRateLabel As System.Windows.Forms.Label
        Dim CurrencyRateChangeImpactLabel As System.Windows.Forms.Label
        Dim CurrencyRateInAccountLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim DocumentNumberLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim OriginalContentLabel As System.Windows.Forms.Label
        Dim OriginalPersonLabel As System.Windows.Forms.Label
        Dim SumLabel As System.Windows.Forms.Label
        Dim SumCorespondencesLabel As System.Windows.Forms.Label
        Dim SumInAccountLabel As System.Windows.Forms.Label
        Dim SumLTLLabel As System.Windows.Forms.Label
        Dim UniqueCodeLabel As System.Windows.Forms.Label
        Dim PersonLabel As System.Windows.Forms.Label
        Dim BankCurrencyConversionCostsLabel As System.Windows.Forms.Label
        Dim AccountBankCurrencyConversionCostsLabel As System.Windows.Forms.Label
        Dim CreditCashAccountLabel As System.Windows.Forms.Label
        Dim UniqueCodeInCreditAccountLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_BankOperation))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CreditCashAccountAccGridComboBox = New AccControls.AccGridComboBox
        Me.BankOperationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UniqueCodeInCreditAccountTextBox = New System.Windows.Forms.TextBox
        Me.IsTransferBetweenAccountsCheckBox = New System.Windows.Forms.CheckBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button
        Me.JournalEntryIDTextBox = New System.Windows.Forms.TextBox
        Me.DocumentNumberTextBox = New System.Windows.Forms.TextBox
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.PersonAccGridComboBox = New AccControls.AccGridComboBox
        Me.AccountAccGridComboBox = New AccControls.AccGridComboBox
        Me.ContentTextBox = New System.Windows.Forms.TextBox
        Me.OriginalContentTextBox = New System.Windows.Forms.TextBox
        Me.OriginalPersonTextBox = New System.Windows.Forms.TextBox
        Me.UniqueCodeTextBox = New System.Windows.Forms.TextBox
        Me.AccountCurrencyRateChangeImpactAccGridComboBox = New AccControls.AccGridComboBox
        Me.AccountCurrencyTextBox = New System.Windows.Forms.TextBox
        Me.CurrencyCodeComboBox = New System.Windows.Forms.ComboBox
        Me.CurrencyRateAccTextBox = New AccControls.AccTextBox
        Me.CurrencyRateChangeImpactAccTextBox = New AccControls.AccTextBox
        Me.CurrencyRateInAccountAccTextBox = New AccControls.AccTextBox
        Me.SumAccTextBox = New AccControls.AccTextBox
        Me.SumCorespondencesAccTextBox = New AccControls.AccTextBox
        Me.SumInAccountAccTextBox = New AccControls.AccTextBox
        Me.SumLTLAccTextBox = New AccControls.AccTextBox
        Me.IsCreditRadioButton = New System.Windows.Forms.RadioButton
        Me.IsDebitRadioButton = New System.Windows.Forms.RadioButton
        Me.GetCurrencyRatesButton = New System.Windows.Forms.Button
        Me.BookEntryItemsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New AccControls.DataGridViewAccGridComboBoxColumn
        Me.DataGridViewTextBoxColumn3 = New AccControls.DataGridViewAccTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New AccControls.DataGridViewAccGridComboBoxColumn
        Me.BookEntryItemsSortedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LimitationsButton = New System.Windows.Forms.Button
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BankCurrencyConversionCostsAccTextBox = New AccControls.AccTextBox
        Me.AccountBankCurrencyConversionCostsAccGridComboBox = New AccControls.AccGridComboBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Panel3 = New System.Windows.Forms.Panel
        AccountLabel = New System.Windows.Forms.Label
        AccountCurrencyLabel = New System.Windows.Forms.Label
        AccountCurrencyRateChangeImpactLabel = New System.Windows.Forms.Label
        ContentLabel = New System.Windows.Forms.Label
        CurrencyCodeLabel = New System.Windows.Forms.Label
        CurrencyRateLabel = New System.Windows.Forms.Label
        CurrencyRateChangeImpactLabel = New System.Windows.Forms.Label
        CurrencyRateInAccountLabel = New System.Windows.Forms.Label
        DateLabel = New System.Windows.Forms.Label
        DocumentNumberLabel = New System.Windows.Forms.Label
        IDLabel = New System.Windows.Forms.Label
        OriginalContentLabel = New System.Windows.Forms.Label
        OriginalPersonLabel = New System.Windows.Forms.Label
        SumLabel = New System.Windows.Forms.Label
        SumCorespondencesLabel = New System.Windows.Forms.Label
        SumInAccountLabel = New System.Windows.Forms.Label
        SumLTLLabel = New System.Windows.Forms.Label
        UniqueCodeLabel = New System.Windows.Forms.Label
        PersonLabel = New System.Windows.Forms.Label
        BankCurrencyConversionCostsLabel = New System.Windows.Forms.Label
        AccountBankCurrencyConversionCostsLabel = New System.Windows.Forms.Label
        CreditCashAccountLabel = New System.Windows.Forms.Label
        UniqueCodeInCreditAccountLabel = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.BankOperationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.BookEntryItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BookEntryItemsSortedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'AccountLabel
        '
        AccountLabel.AutoSize = True
        AccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountLabel.Location = New System.Drawing.Point(102, 32)
        AccountLabel.Name = "AccountLabel"
        AccountLabel.Size = New System.Drawing.Size(60, 13)
        AccountLabel.TabIndex = 0
        AccountLabel.Text = "Sąskaita:"
        '
        'AccountCurrencyLabel
        '
        AccountCurrencyLabel.AutoSize = True
        AccountCurrencyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountCurrencyLabel.Location = New System.Drawing.Point(75, 223)
        AccountCurrencyLabel.Name = "AccountCurrencyLabel"
        AccountCurrencyLabel.Size = New System.Drawing.Size(84, 13)
        AccountCurrencyLabel.TabIndex = 2
        AccountCurrencyLabel.Text = "Valiuta sąsk.:"
        '
        'AccountCurrencyRateChangeImpactLabel
        '
        AccountCurrencyRateChangeImpactLabel.AutoSize = True
        AccountCurrencyRateChangeImpactLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountCurrencyRateChangeImpactLabel.Location = New System.Drawing.Point(5, 170)
        AccountCurrencyRateChangeImpactLabel.Name = "AccountCurrencyRateChangeImpactLabel"
        AccountCurrencyRateChangeImpactLabel.Size = New System.Drawing.Size(153, 13)
        AccountCurrencyRateChangeImpactLabel.TabIndex = 4
        AccountCurrencyRateChangeImpactLabel.Text = "Kurso pasik. įtakos sąsk.:"
        '
        'ContentLabel
        '
        ContentLabel.AutoSize = True
        ContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContentLabel.Location = New System.Drawing.Point(110, 59)
        ContentLabel.Name = "ContentLabel"
        ContentLabel.Size = New System.Drawing.Size(52, 13)
        ContentLabel.TabIndex = 6
        ContentLabel.Text = "Turinys:"
        '
        'CurrencyCodeLabel
        '
        CurrencyCodeLabel.AutoSize = True
        CurrencyCodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyCodeLabel.Location = New System.Drawing.Point(108, 65)
        CurrencyCodeLabel.Name = "CurrencyCodeLabel"
        CurrencyCodeLabel.Size = New System.Drawing.Size(50, 13)
        CurrencyCodeLabel.TabIndex = 10
        CurrencyCodeLabel.Text = "Valiuta:"
        '
        'CurrencyRateLabel
        '
        CurrencyRateLabel.AutoSize = True
        CurrencyRateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyRateLabel.Location = New System.Drawing.Point(109, 92)
        CurrencyRateLabel.Name = "CurrencyRateLabel"
        CurrencyRateLabel.Size = New System.Drawing.Size(49, 13)
        CurrencyRateLabel.TabIndex = 12
        CurrencyRateLabel.Text = "Kursas:"
        '
        'CurrencyRateChangeImpactLabel
        '
        CurrencyRateChangeImpactLabel.AutoSize = True
        CurrencyRateChangeImpactLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyRateChangeImpactLabel.Location = New System.Drawing.Point(16, 144)
        CurrencyRateChangeImpactLabel.Name = "CurrencyRateChangeImpactLabel"
        CurrencyRateChangeImpactLabel.Size = New System.Drawing.Size(142, 13)
        CurrencyRateChangeImpactLabel.TabIndex = 14
        CurrencyRateChangeImpactLabel.Text = "Kurso pasikeitimo įtaka:"
        '
        'CurrencyRateInAccountLabel
        '
        CurrencyRateInAccountLabel.AutoSize = True
        CurrencyRateInAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyRateInAccountLabel.Location = New System.Drawing.Point(50, 249)
        CurrencyRateInAccountLabel.Name = "CurrencyRateInAccountLabel"
        CurrencyRateInAccountLabel.Size = New System.Drawing.Size(108, 13)
        CurrencyRateInAccountLabel.TabIndex = 16
        CurrencyRateInAccountLabel.Text = "Kursas sąsk. val.:"
        '
        'DateLabel
        '
        DateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DateLabel.AutoSize = True
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(314, 0)
        DateLabel.Name = "DateLabel"
        DateLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        DateLabel.Size = New System.Drawing.Size(38, 18)
        DateLabel.TabIndex = 18
        DateLabel.Text = "Data:"
        '
        'DocumentNumberLabel
        '
        DocumentNumberLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DocumentNumberLabel.AutoSize = True
        DocumentNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DocumentNumberLabel.Location = New System.Drawing.Point(507, 0)
        DocumentNumberLabel.Name = "DocumentNumberLabel"
        DocumentNumberLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        DocumentNumberLabel.Size = New System.Drawing.Size(85, 18)
        DocumentNumberLabel.TabIndex = 20
        DocumentNumberLabel.Text = "Dok. numeris:"
        '
        'IDLabel
        '
        IDLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(135, 0)
        IDLabel.Name = "IDLabel"
        IDLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        IDLabel.Size = New System.Drawing.Size(24, 18)
        IDLabel.TabIndex = 22
        IDLabel.Text = "ID:"
        '
        'OriginalContentLabel
        '
        OriginalContentLabel.AutoSize = True
        OriginalContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        OriginalContentLabel.Location = New System.Drawing.Point(83, 85)
        OriginalContentLabel.Name = "OriginalContentLabel"
        OriginalContentLabel.Size = New System.Drawing.Size(79, 13)
        OriginalContentLabel.TabIndex = 28
        OriginalContentLabel.Text = "Orig. turinys:"
        '
        'OriginalPersonLabel
        '
        OriginalPersonLabel.AutoSize = True
        OriginalPersonLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        OriginalPersonLabel.Location = New System.Drawing.Point(46, 138)
        OriginalPersonLabel.Name = "OriginalPersonLabel"
        OriginalPersonLabel.Size = New System.Drawing.Size(116, 13)
        OriginalPersonLabel.TabIndex = 30
        OriginalPersonLabel.Text = "Orig. kontrahentas:"
        '
        'SumLabel
        '
        SumLabel.AutoSize = True
        SumLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumLabel.Location = New System.Drawing.Point(116, 39)
        SumLabel.Name = "SumLabel"
        SumLabel.Size = New System.Drawing.Size(42, 13)
        SumLabel.TabIndex = 32
        SumLabel.Text = "Suma:"
        '
        'SumCorespondencesLabel
        '
        SumCorespondencesLabel.AutoSize = True
        SumCorespondencesLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumCorespondencesLabel.Location = New System.Drawing.Point(70, 197)
        SumCorespondencesLabel.Name = "SumCorespondencesLabel"
        SumCorespondencesLabel.Size = New System.Drawing.Size(88, 13)
        SumCorespondencesLabel.TabIndex = 34
        SumCorespondencesLabel.Text = "Suma koresp.:"
        '
        'SumInAccountLabel
        '
        SumInAccountLabel.AutoSize = True
        SumInAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumInAccountLabel.Location = New System.Drawing.Point(82, 275)
        SumInAccountLabel.Name = "SumInAccountLabel"
        SumInAccountLabel.Size = New System.Drawing.Size(76, 13)
        SumInAccountLabel.TabIndex = 36
        SumInAccountLabel.Text = "Suma sąsk.:"
        '
        'SumLTLLabel
        '
        SumLTLLabel.AutoSize = True
        SumLTLLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumLTLLabel.Location = New System.Drawing.Point(91, 118)
        SumLTLLabel.Name = "SumLTLLabel"
        SumLTLLabel.Size = New System.Drawing.Size(68, 13)
        SumLTLLabel.TabIndex = 38
        SumLTLLabel.Text = "Suma LTL:"
        '
        'UniqueCodeLabel
        '
        UniqueCodeLabel.AutoSize = True
        UniqueCodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UniqueCodeLabel.Location = New System.Drawing.Point(85, 164)
        UniqueCodeLabel.Name = "UniqueCodeLabel"
        UniqueCodeLabel.Size = New System.Drawing.Size(77, 13)
        UniqueCodeLabel.TabIndex = 40
        UniqueCodeLabel.Text = "Unikalus ID:"
        '
        'PersonLabel
        '
        PersonLabel.AutoSize = True
        PersonLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PersonLabel.Location = New System.Drawing.Point(76, 111)
        PersonLabel.Name = "PersonLabel"
        PersonLabel.Size = New System.Drawing.Size(86, 13)
        PersonLabel.TabIndex = 42
        PersonLabel.Text = "Kontrahentas:"
        '
        'BankCurrencyConversionCostsLabel
        '
        BankCurrencyConversionCostsLabel.AutoSize = True
        BankCurrencyConversionCostsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BankCurrencyConversionCostsLabel.Location = New System.Drawing.Point(3, 301)
        BankCurrencyConversionCostsLabel.Name = "BankCurrencyConversionCostsLabel"
        BankCurrencyConversionCostsLabel.Size = New System.Drawing.Size(156, 13)
        BankCurrencyConversionCostsLabel.TabIndex = 39
        BankCurrencyConversionCostsLabel.Text = "Banko konvert. sąnaudos:"
        '
        'AccountBankCurrencyConversionCostsLabel
        '
        AccountBankCurrencyConversionCostsLabel.AutoSize = True
        AccountBankCurrencyConversionCostsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountBankCurrencyConversionCostsLabel.Location = New System.Drawing.Point(14, 327)
        AccountBankCurrencyConversionCostsLabel.Name = "AccountBankCurrencyConversionCostsLabel"
        AccountBankCurrencyConversionCostsLabel.Size = New System.Drawing.Size(145, 13)
        AccountBankCurrencyConversionCostsLabel.TabIndex = 40
        AccountBankCurrencyConversionCostsLabel.Text = "Banko konv. sąn. sąsk.:"
        '
        'CreditCashAccountLabel
        '
        CreditCashAccountLabel.AutoSize = True
        CreditCashAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CreditCashAccountLabel.Location = New System.Drawing.Point(35, 22)
        CreditCashAccountLabel.Name = "CreditCashAccountLabel"
        CreditCashAccountLabel.Size = New System.Drawing.Size(118, 13)
        CreditCashAccountLabel.TabIndex = 43
        CreditCashAccountLabel.Text = "Kredituojama sąsk.:"
        '
        'UniqueCodeInCreditAccountLabel
        '
        UniqueCodeInCreditAccountLabel.AutoSize = True
        UniqueCodeInCreditAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UniqueCodeInCreditAccountLabel.Location = New System.Drawing.Point(76, 49)
        UniqueCodeInCreditAccountLabel.Name = "UniqueCodeInCreditAccountLabel"
        UniqueCodeInCreditAccountLabel.Size = New System.Drawing.Size(77, 13)
        UniqueCodeInCreditAccountLabel.TabIndex = 44
        UniqueCodeInCreditAccountLabel.Text = "Unikalus ID:"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(PersonLabel)
        Me.Panel1.Controls.Add(Me.PersonAccGridComboBox)
        Me.Panel1.Controls.Add(AccountLabel)
        Me.Panel1.Controls.Add(Me.AccountAccGridComboBox)
        Me.Panel1.Controls.Add(ContentLabel)
        Me.Panel1.Controls.Add(Me.ContentTextBox)
        Me.Panel1.Controls.Add(OriginalContentLabel)
        Me.Panel1.Controls.Add(Me.OriginalContentTextBox)
        Me.Panel1.Controls.Add(OriginalPersonLabel)
        Me.Panel1.Controls.Add(Me.OriginalPersonTextBox)
        Me.Panel1.Controls.Add(UniqueCodeLabel)
        Me.Panel1.Controls.Add(Me.UniqueCodeTextBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(745, 261)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CreditCashAccountAccGridComboBox)
        Me.GroupBox1.Controls.Add(UniqueCodeInCreditAccountLabel)
        Me.GroupBox1.Controls.Add(CreditCashAccountLabel)
        Me.GroupBox1.Controls.Add(Me.UniqueCodeInCreditAccountTextBox)
        Me.GroupBox1.Controls.Add(Me.IsTransferBetweenAccountsCheckBox)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 187)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(737, 71)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pavedimas tarp įmonės sąskaitų"
        '
        'CreditCashAccountAccGridComboBox
        '
        Me.CreditCashAccountAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.BankOperationBindingSource, "CreditCashAccount", True))
        Me.CreditCashAccountAccGridComboBox.EmptyValueString = ""
        Me.CreditCashAccountAccGridComboBox.Enabled = False
        Me.CreditCashAccountAccGridComboBox.FilterPropertyName = ""
        Me.CreditCashAccountAccGridComboBox.FormattingEnabled = True
        Me.CreditCashAccountAccGridComboBox.InstantBinding = True
        Me.CreditCashAccountAccGridComboBox.Location = New System.Drawing.Point(158, 19)
        Me.CreditCashAccountAccGridComboBox.Name = "CreditCashAccountAccGridComboBox"
        Me.CreditCashAccountAccGridComboBox.Size = New System.Drawing.Size(562, 21)
        Me.CreditCashAccountAccGridComboBox.TabIndex = 1
        '
        'BankOperationBindingSource
        '
        Me.BankOperationBindingSource.DataSource = GetType(ApskaitaObjects.Documents.BankOperation)
        '
        'UniqueCodeInCreditAccountTextBox
        '
        Me.UniqueCodeInCreditAccountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "UniqueCodeInCreditAccount", True))
        Me.UniqueCodeInCreditAccountTextBox.Location = New System.Drawing.Point(158, 46)
        Me.UniqueCodeInCreditAccountTextBox.MaxLength = 255
        Me.UniqueCodeInCreditAccountTextBox.Name = "UniqueCodeInCreditAccountTextBox"
        Me.UniqueCodeInCreditAccountTextBox.ReadOnly = True
        Me.UniqueCodeInCreditAccountTextBox.Size = New System.Drawing.Size(562, 20)
        Me.UniqueCodeInCreditAccountTextBox.TabIndex = 2
        '
        'IsTransferBetweenAccountsCheckBox
        '
        Me.IsTransferBetweenAccountsCheckBox.AutoSize = True
        Me.IsTransferBetweenAccountsCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BankOperationBindingSource, "IsTransferBetweenAccounts", True))
        Me.IsTransferBetweenAccountsCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsTransferBetweenAccountsCheckBox.Location = New System.Drawing.Point(13, 22)
        Me.IsTransferBetweenAccountsCheckBox.Name = "IsTransferBetweenAccountsCheckBox"
        Me.IsTransferBetweenAccountsCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.IsTransferBetweenAccountsCheckBox.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 9
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ViewJournalEntryButton, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.JournalEntryIDTextBox, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DocumentNumberTextBox, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(DocumentNumberLabel, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DateDateTimePicker, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(DateLabel, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(745, 25)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.ApskaitaWUI.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(287, 0)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 90
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = True
        '
        'JournalEntryIDTextBox
        '
        Me.JournalEntryIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "JournalEntryID", True))
        Me.JournalEntryIDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JournalEntryIDTextBox.Location = New System.Drawing.Point(165, 3)
        Me.JournalEntryIDTextBox.Name = "JournalEntryIDTextBox"
        Me.JournalEntryIDTextBox.ReadOnly = True
        Me.JournalEntryIDTextBox.Size = New System.Drawing.Size(119, 20)
        Me.JournalEntryIDTextBox.TabIndex = 42
        Me.JournalEntryIDTextBox.TabStop = False
        Me.JournalEntryIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DocumentNumberTextBox
        '
        Me.DocumentNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "DocumentNumber", True))
        Me.DocumentNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentNumberTextBox.Location = New System.Drawing.Point(598, 3)
        Me.DocumentNumberTextBox.MaxLength = 50
        Me.DocumentNumberTextBox.Name = "DocumentNumberTextBox"
        Me.DocumentNumberTextBox.Size = New System.Drawing.Size(123, 20)
        Me.DocumentNumberTextBox.TabIndex = 1
        Me.DocumentNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateDateTimePicker
        '
        Me.DateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.BankOperationBindingSource, "Date", True))
        Me.DateDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDateTimePicker.Location = New System.Drawing.Point(358, 3)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(123, 20)
        Me.DateDateTimePicker.TabIndex = 0
        '
        'PersonAccGridComboBox
        '
        Me.PersonAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PersonAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.BankOperationBindingSource, "Person", True))
        Me.PersonAccGridComboBox.EmptyValueString = ""
        Me.PersonAccGridComboBox.FilterPropertyName = ""
        Me.PersonAccGridComboBox.FormattingEnabled = True
        Me.PersonAccGridComboBox.InstantBinding = True
        Me.PersonAccGridComboBox.Location = New System.Drawing.Point(163, 108)
        Me.PersonAccGridComboBox.Name = "PersonAccGridComboBox"
        Me.PersonAccGridComboBox.Size = New System.Drawing.Size(562, 21)
        Me.PersonAccGridComboBox.TabIndex = 3
        '
        'AccountAccGridComboBox
        '
        Me.AccountAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AccountAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.BankOperationBindingSource, "Account", True))
        Me.AccountAccGridComboBox.EmptyValueString = ""
        Me.AccountAccGridComboBox.FilterPropertyName = ""
        Me.AccountAccGridComboBox.FormattingEnabled = True
        Me.AccountAccGridComboBox.InstantBinding = True
        Me.AccountAccGridComboBox.Location = New System.Drawing.Point(163, 29)
        Me.AccountAccGridComboBox.Name = "AccountAccGridComboBox"
        Me.AccountAccGridComboBox.Size = New System.Drawing.Size(562, 21)
        Me.AccountAccGridComboBox.TabIndex = 1
        '
        'ContentTextBox
        '
        Me.ContentTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "Content", True))
        Me.ContentTextBox.Location = New System.Drawing.Point(163, 56)
        Me.ContentTextBox.MaxLength = 255
        Me.ContentTextBox.Name = "ContentTextBox"
        Me.ContentTextBox.Size = New System.Drawing.Size(562, 20)
        Me.ContentTextBox.TabIndex = 2
        '
        'OriginalContentTextBox
        '
        Me.OriginalContentTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OriginalContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "OriginalContent", True))
        Me.OriginalContentTextBox.Location = New System.Drawing.Point(163, 82)
        Me.OriginalContentTextBox.Name = "OriginalContentTextBox"
        Me.OriginalContentTextBox.ReadOnly = True
        Me.OriginalContentTextBox.Size = New System.Drawing.Size(562, 20)
        Me.OriginalContentTextBox.TabIndex = 29
        Me.OriginalContentTextBox.TabStop = False
        '
        'OriginalPersonTextBox
        '
        Me.OriginalPersonTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OriginalPersonTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "OriginalPerson", True))
        Me.OriginalPersonTextBox.Location = New System.Drawing.Point(163, 135)
        Me.OriginalPersonTextBox.Name = "OriginalPersonTextBox"
        Me.OriginalPersonTextBox.ReadOnly = True
        Me.OriginalPersonTextBox.Size = New System.Drawing.Size(562, 20)
        Me.OriginalPersonTextBox.TabIndex = 31
        Me.OriginalPersonTextBox.TabStop = False
        '
        'UniqueCodeTextBox
        '
        Me.UniqueCodeTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UniqueCodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "UniqueCode", True))
        Me.UniqueCodeTextBox.Location = New System.Drawing.Point(163, 161)
        Me.UniqueCodeTextBox.MaxLength = 255
        Me.UniqueCodeTextBox.Name = "UniqueCodeTextBox"
        Me.UniqueCodeTextBox.Size = New System.Drawing.Size(562, 20)
        Me.UniqueCodeTextBox.TabIndex = 4
        '
        'AccountCurrencyRateChangeImpactAccGridComboBox
        '
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.BankOperationBindingSource, "AccountCurrencyRateChangeImpact", True))
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.EmptyValueString = ""
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.FilterPropertyName = ""
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.FormattingEnabled = True
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.InstantBinding = True
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.Location = New System.Drawing.Point(163, 167)
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.Name = "AccountCurrencyRateChangeImpactAccGridComboBox"
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.Size = New System.Drawing.Size(169, 21)
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.TabIndex = 7
        '
        'AccountCurrencyTextBox
        '
        Me.AccountCurrencyTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AccountCurrencyTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "AccountCurrency", True))
        Me.AccountCurrencyTextBox.Location = New System.Drawing.Point(164, 220)
        Me.AccountCurrencyTextBox.Name = "AccountCurrencyTextBox"
        Me.AccountCurrencyTextBox.ReadOnly = True
        Me.AccountCurrencyTextBox.Size = New System.Drawing.Size(168, 20)
        Me.AccountCurrencyTextBox.TabIndex = 3
        Me.AccountCurrencyTextBox.TabStop = False
        Me.AccountCurrencyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrencyCodeComboBox
        '
        Me.CurrencyCodeComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrencyCodeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "CurrencyCode", True))
        Me.CurrencyCodeComboBox.FormattingEnabled = True
        Me.CurrencyCodeComboBox.Location = New System.Drawing.Point(163, 62)
        Me.CurrencyCodeComboBox.Name = "CurrencyCodeComboBox"
        Me.CurrencyCodeComboBox.Size = New System.Drawing.Size(169, 21)
        Me.CurrencyCodeComboBox.TabIndex = 3
        '
        'CurrencyRateAccTextBox
        '
        Me.CurrencyRateAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrencyRateAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "CurrencyRate", True))
        Me.CurrencyRateAccTextBox.DecimalLength = 6
        Me.CurrencyRateAccTextBox.KeepBackColorWhenReadOnly = False
        Me.CurrencyRateAccTextBox.Location = New System.Drawing.Point(163, 89)
        Me.CurrencyRateAccTextBox.Name = "CurrencyRateAccTextBox"
        Me.CurrencyRateAccTextBox.NegativeValue = False
        Me.CurrencyRateAccTextBox.Size = New System.Drawing.Size(169, 20)
        Me.CurrencyRateAccTextBox.TabIndex = 5
        Me.CurrencyRateAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrencyRateChangeImpactAccTextBox
        '
        Me.CurrencyRateChangeImpactAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrencyRateChangeImpactAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "CurrencyRateChangeImpact", True))
        Me.CurrencyRateChangeImpactAccTextBox.KeepBackColorWhenReadOnly = False
        Me.CurrencyRateChangeImpactAccTextBox.Location = New System.Drawing.Point(164, 141)
        Me.CurrencyRateChangeImpactAccTextBox.Name = "CurrencyRateChangeImpactAccTextBox"
        Me.CurrencyRateChangeImpactAccTextBox.Size = New System.Drawing.Size(168, 20)
        Me.CurrencyRateChangeImpactAccTextBox.TabIndex = 6
        Me.CurrencyRateChangeImpactAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrencyRateInAccountAccTextBox
        '
        Me.CurrencyRateInAccountAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrencyRateInAccountAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "CurrencyRateInAccount", True))
        Me.CurrencyRateInAccountAccTextBox.DecimalLength = 6
        Me.CurrencyRateInAccountAccTextBox.KeepBackColorWhenReadOnly = False
        Me.CurrencyRateInAccountAccTextBox.Location = New System.Drawing.Point(164, 246)
        Me.CurrencyRateInAccountAccTextBox.Name = "CurrencyRateInAccountAccTextBox"
        Me.CurrencyRateInAccountAccTextBox.NegativeValue = False
        Me.CurrencyRateInAccountAccTextBox.Size = New System.Drawing.Size(168, 20)
        Me.CurrencyRateInAccountAccTextBox.TabIndex = 8
        Me.CurrencyRateInAccountAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumAccTextBox
        '
        Me.SumAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SumAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "Sum", True))
        Me.SumAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumAccTextBox.Location = New System.Drawing.Point(163, 36)
        Me.SumAccTextBox.Name = "SumAccTextBox"
        Me.SumAccTextBox.Size = New System.Drawing.Size(169, 20)
        Me.SumAccTextBox.TabIndex = 2
        Me.SumAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumCorespondencesAccTextBox
        '
        Me.SumCorespondencesAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SumCorespondencesAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "SumCorespondences", True))
        Me.SumCorespondencesAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumCorespondencesAccTextBox.Location = New System.Drawing.Point(164, 194)
        Me.SumCorespondencesAccTextBox.Name = "SumCorespondencesAccTextBox"
        Me.SumCorespondencesAccTextBox.ReadOnly = True
        Me.SumCorespondencesAccTextBox.Size = New System.Drawing.Size(168, 20)
        Me.SumCorespondencesAccTextBox.TabIndex = 35
        Me.SumCorespondencesAccTextBox.TabStop = False
        Me.SumCorespondencesAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumInAccountAccTextBox
        '
        Me.SumInAccountAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SumInAccountAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "SumInAccount", True))
        Me.SumInAccountAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumInAccountAccTextBox.Location = New System.Drawing.Point(164, 272)
        Me.SumInAccountAccTextBox.Name = "SumInAccountAccTextBox"
        Me.SumInAccountAccTextBox.ReadOnly = True
        Me.SumInAccountAccTextBox.Size = New System.Drawing.Size(168, 20)
        Me.SumInAccountAccTextBox.TabIndex = 37
        Me.SumInAccountAccTextBox.TabStop = False
        Me.SumInAccountAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumLTLAccTextBox
        '
        Me.SumLTLAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SumLTLAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "SumLTL", True))
        Me.SumLTLAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumLTLAccTextBox.Location = New System.Drawing.Point(163, 115)
        Me.SumLTLAccTextBox.Name = "SumLTLAccTextBox"
        Me.SumLTLAccTextBox.ReadOnly = True
        Me.SumLTLAccTextBox.Size = New System.Drawing.Size(169, 20)
        Me.SumLTLAccTextBox.TabIndex = 39
        Me.SumLTLAccTextBox.TabStop = False
        Me.SumLTLAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IsCreditRadioButton
        '
        Me.IsCreditRadioButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IsCreditRadioButton.AutoSize = True
        Me.IsCreditRadioButton.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BankOperationBindingSource, "IsCredit", True))
        Me.IsCreditRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsCreditRadioButton.Location = New System.Drawing.Point(261, 12)
        Me.IsCreditRadioButton.Name = "IsCreditRadioButton"
        Me.IsCreditRadioButton.Size = New System.Drawing.Size(71, 17)
        Me.IsCreditRadioButton.TabIndex = 1
        Me.IsCreditRadioButton.Text = "Kreditas"
        '
        'IsDebitRadioButton
        '
        Me.IsDebitRadioButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IsDebitRadioButton.AutoSize = True
        Me.IsDebitRadioButton.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BankOperationBindingSource, "IsDebit", True))
        Me.IsDebitRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsDebitRadioButton.Location = New System.Drawing.Point(173, 12)
        Me.IsDebitRadioButton.Name = "IsDebitRadioButton"
        Me.IsDebitRadioButton.Size = New System.Drawing.Size(72, 17)
        Me.IsDebitRadioButton.TabIndex = 0
        Me.IsDebitRadioButton.Text = "Debetas"
        '
        'GetCurrencyRatesButton
        '
        Me.GetCurrencyRatesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetCurrencyRatesButton.Location = New System.Drawing.Point(36, 60)
        Me.GetCurrencyRatesButton.Name = "GetCurrencyRatesButton"
        Me.GetCurrencyRatesButton.Size = New System.Drawing.Size(63, 23)
        Me.GetCurrencyRatesButton.TabIndex = 4
        Me.GetCurrencyRatesButton.Text = "$->LTL"
        Me.GetCurrencyRatesButton.UseVisualStyleBackColor = True
        '
        'BookEntryItemsDataGridView
        '
        Me.BookEntryItemsDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BookEntryItemsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.BookEntryItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BookEntryItemsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.BookEntryItemsDataGridView.DataSource = Me.BookEntryItemsSortedBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.BookEntryItemsDataGridView.DefaultCellStyle = DataGridViewCellStyle3
        Me.BookEntryItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BookEntryItemsDataGridView.Location = New System.Drawing.Point(359, 3)
        Me.BookEntryItemsDataGridView.Name = "BookEntryItemsDataGridView"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BookEntryItemsDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.BookEntryItemsDataGridView.RowHeadersWidth = 20
        Me.BookEntryItemsDataGridView.Size = New System.Drawing.Size(383, 353)
        Me.BookEntryItemsDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.CloseOnSingleClick = True
        Me.DataGridViewTextBoxColumn2.ComboDataGridView = Nothing
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Account"
        Me.DataGridViewTextBoxColumn2.EmptyValueString = ""
        Me.DataGridViewTextBoxColumn2.FilterPropertyName = ""
        Me.DataGridViewTextBoxColumn2.HeaderText = "Sąskaita"
        Me.DataGridViewTextBoxColumn2.InstantBinding = True
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.ValueMember = ""
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AllowNegative = False
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Amount"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn3.HeaderText = "Suma"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.CloseOnSingleClick = True
        Me.DataGridViewTextBoxColumn4.ComboDataGridView = Nothing
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Person"
        Me.DataGridViewTextBoxColumn4.EmptyValueString = ""
        Me.DataGridViewTextBoxColumn4.FilterPropertyName = ""
        Me.DataGridViewTextBoxColumn4.HeaderText = "Kontrahentas"
        Me.DataGridViewTextBoxColumn4.InstantBinding = True
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.ValueMember = ""
        '
        'BookEntryItemsSortedBindingSource
        '
        Me.BookEntryItemsSortedBindingSource.DataMember = "BookEntryItemsSorted"
        Me.BookEntryItemsSortedBindingSource.DataSource = Me.BankOperationBindingSource
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.LimitationsButton)
        Me.Panel2.Controls.Add(Me.ICancelButton)
        Me.Panel2.Controls.Add(Me.IOkButton)
        Me.Panel2.Controls.Add(Me.IApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 620)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(745, 32)
        Me.Panel2.TabIndex = 54
        '
        'LimitationsButton
        '
        Me.LimitationsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LimitationsButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Action_lock_icon_24p
        Me.LimitationsButton.Location = New System.Drawing.Point(12, 5)
        Me.LimitationsButton.Name = "LimitationsButton"
        Me.LimitationsButton.Size = New System.Drawing.Size(32, 24)
        Me.LimitationsButton.TabIndex = 0
        Me.LimitationsButton.UseVisualStyleBackColor = True
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(644, 6)
        Me.ICancelButton.Name = "ICancelButton"
        Me.ICancelButton.Size = New System.Drawing.Size(89, 23)
        Me.ICancelButton.TabIndex = 3
        Me.ICancelButton.Text = "Atšaukti"
        Me.ICancelButton.UseVisualStyleBackColor = True
        '
        'IOkButton
        '
        Me.IOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IOkButton.Location = New System.Drawing.Point(438, 6)
        Me.IOkButton.Name = "IOkButton"
        Me.IOkButton.Size = New System.Drawing.Size(89, 23)
        Me.IOkButton.TabIndex = 1
        Me.IOkButton.Text = "Ok"
        Me.IOkButton.UseVisualStyleBackColor = True
        '
        'IApplyButton
        '
        Me.IApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IApplyButton.Location = New System.Drawing.Point(542, 6)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(89, 23)
        Me.IApplyButton.TabIndex = 2
        Me.IApplyButton.Text = "Išsaugoti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.DataSource = Me.BankOperationBindingSource
        '
        'BankCurrencyConversionCostsAccTextBox
        '
        Me.BankCurrencyConversionCostsAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BankCurrencyConversionCostsAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "BankCurrencyConversionCosts", True))
        Me.BankCurrencyConversionCostsAccTextBox.KeepBackColorWhenReadOnly = False
        Me.BankCurrencyConversionCostsAccTextBox.Location = New System.Drawing.Point(164, 298)
        Me.BankCurrencyConversionCostsAccTextBox.Name = "BankCurrencyConversionCostsAccTextBox"
        Me.BankCurrencyConversionCostsAccTextBox.NegativeValue = False
        Me.BankCurrencyConversionCostsAccTextBox.Size = New System.Drawing.Size(168, 20)
        Me.BankCurrencyConversionCostsAccTextBox.TabIndex = 9
        Me.BankCurrencyConversionCostsAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AccountBankCurrencyConversionCostsAccGridComboBox
        '
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.BankOperationBindingSource, "AccountBankCurrencyConversionCosts", True))
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.EmptyValueString = ""
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.FilterPropertyName = ""
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.FormattingEnabled = True
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.InstantBinding = True
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.Location = New System.Drawing.Point(163, 324)
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.Name = "AccountBankCurrencyConversionCostsAccGridComboBox"
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.Size = New System.Drawing.Size(169, 21)
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.TabIndex = 10
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.90503!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.09497!))
        Me.TableLayoutPanel2.Controls.Add(Me.BookEntryItemsDataGridView, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 261)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(745, 359)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.AutoSize = True
        Me.Panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel3.Controls.Add(AccountBankCurrencyConversionCostsLabel)
        Me.Panel3.Controls.Add(Me.IsDebitRadioButton)
        Me.Panel3.Controls.Add(Me.AccountBankCurrencyConversionCostsAccGridComboBox)
        Me.Panel3.Controls.Add(SumCorespondencesLabel)
        Me.Panel3.Controls.Add(BankCurrencyConversionCostsLabel)
        Me.Panel3.Controls.Add(Me.SumCorespondencesAccTextBox)
        Me.Panel3.Controls.Add(Me.BankCurrencyConversionCostsAccTextBox)
        Me.Panel3.Controls.Add(CurrencyRateChangeImpactLabel)
        Me.Panel3.Controls.Add(Me.IsCreditRadioButton)
        Me.Panel3.Controls.Add(Me.CurrencyRateChangeImpactAccTextBox)
        Me.Panel3.Controls.Add(Me.SumInAccountAccTextBox)
        Me.Panel3.Controls.Add(Me.GetCurrencyRatesButton)
        Me.Panel3.Controls.Add(SumLTLLabel)
        Me.Panel3.Controls.Add(Me.SumAccTextBox)
        Me.Panel3.Controls.Add(SumInAccountLabel)
        Me.Panel3.Controls.Add(SumLabel)
        Me.Panel3.Controls.Add(AccountCurrencyRateChangeImpactLabel)
        Me.Panel3.Controls.Add(CurrencyCodeLabel)
        Me.Panel3.Controls.Add(Me.CurrencyRateInAccountAccTextBox)
        Me.Panel3.Controls.Add(Me.AccountCurrencyRateChangeImpactAccGridComboBox)
        Me.Panel3.Controls.Add(Me.SumLTLAccTextBox)
        Me.Panel3.Controls.Add(Me.CurrencyCodeComboBox)
        Me.Panel3.Controls.Add(CurrencyRateInAccountLabel)
        Me.Panel3.Controls.Add(AccountCurrencyLabel)
        Me.Panel3.Controls.Add(CurrencyRateLabel)
        Me.Panel3.Controls.Add(Me.CurrencyRateAccTextBox)
        Me.Panel3.Controls.Add(Me.AccountCurrencyTextBox)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(350, 353)
        Me.Panel3.TabIndex = 0
        '
        'F_BankOperation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(745, 652)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_BankOperation"
        Me.ShowInTaskbar = False
        Me.Text = "Banko operacija"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.BankOperationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.BookEntryItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BookEntryItemsSortedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AccountAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents BankOperationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AccountCurrencyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CurrencyCodeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CurrencyRateAccTextBox As AccControls.AccTextBox
    Friend WithEvents CurrencyRateChangeImpactAccTextBox As AccControls.AccTextBox
    Friend WithEvents CurrencyRateInAccountAccTextBox As AccControls.AccTextBox
    Friend WithEvents DateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents DocumentNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OriginalContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OriginalPersonTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SumAccTextBox As AccControls.AccTextBox
    Friend WithEvents SumCorespondencesAccTextBox As AccControls.AccTextBox
    Friend WithEvents SumInAccountAccTextBox As AccControls.AccTextBox
    Friend WithEvents SumLTLAccTextBox As AccControls.AccTextBox
    Friend WithEvents UniqueCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AccountCurrencyRateChangeImpactAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents PersonAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents BookEntryItemsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents BookEntryItemsSortedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GetCurrencyRatesButton As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents IsCreditRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents IsDebitRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents AccountBankCurrencyConversionCostsAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents BankCurrencyConversionCostsAccTextBox As AccControls.AccTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As AccControls.DataGridViewAccGridComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As AccControls.DataGridViewAccGridComboBoxColumn
    Friend WithEvents IsTransferBetweenAccountsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents UniqueCodeInCreditAccountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CreditCashAccountAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents JournalEntryIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LimitationsButton As System.Windows.Forms.Button
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
End Class
