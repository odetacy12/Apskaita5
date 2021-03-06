<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_Contract
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
        Dim IDLabel As System.Windows.Forms.Label
        Dim InsertDateLabel As System.Windows.Forms.Label
        Dim UpdateDateLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim SerialLabel As System.Windows.Forms.Label
        Dim NumberLabel As System.Windows.Forms.Label
        Dim PersonNameLabel As System.Windows.Forms.Label
        Dim PersonSodraCodeLabel As System.Windows.Forms.Label
        Dim PersonAddressLabel As System.Windows.Forms.Label
        Dim PersonCodeLabel As System.Windows.Forms.Label
        Dim PositionLabel As System.Windows.Forms.Label
        Dim WorkLoadLabel As System.Windows.Forms.Label
        Dim WageLabel As System.Windows.Forms.Label
        Dim HumanReadableWageTypeLabel As System.Windows.Forms.Label
        Dim ExtraPayLabel As System.Windows.Forms.Label
        Dim IsTerminatedLabel As System.Windows.Forms.Label
        Dim AnnualHolidayLabel As System.Windows.Forms.Label
        Dim HolidayCorrectionLabel As System.Windows.Forms.Label
        Dim ContentLabel As System.Windows.Forms.Label
        Dim NPDLabel As System.Windows.Forms.Label
        Dim PNPDLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_Contract))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.RefreshNumberButton = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.ContentTextBox = New System.Windows.Forms.TextBox
        Me.ContractBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel
        Me.PersonCodeTextBox = New System.Windows.Forms.TextBox
        Me.PersonAddressTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.PersonSodraCodeTextBox = New System.Windows.Forms.TextBox
        Me.PersonNameTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.SerialComboBox = New System.Windows.Forms.ComboBox
        Me.NumberAccTextBox = New AccControlsWinForms.AccTextBox
        Me.DateAccDatePicker = New AccControlsWinForms.AccDatePicker
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.UpdateDateTextBox = New System.Windows.Forms.TextBox
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.InsertDateTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel
        Me.PNPDAccTextBox = New AccControlsWinForms.AccTextBox
        Me.NPDAccTextBox = New AccControlsWinForms.AccTextBox
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel
        Me.HolidayCorrectionAccTextBox = New AccControlsWinForms.AccTextBox
        Me.IsTerminatedCheckBox = New System.Windows.Forms.CheckBox
        Me.AnnualHolidayAccTextBox = New AccControlsWinForms.AccTextBox
        Me.TerminationDateAccDatePicker = New AccControlsWinForms.AccDatePicker
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel
        Me.ExtraPayAccTextBox = New AccControlsWinForms.AccTextBox
        Me.WageAccTextBox = New AccControlsWinForms.AccTextBox
        Me.HumanReadableWageTypeComboBox = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel
        Me.WorkLoadAccTextBox = New AccControlsWinForms.AccTextBox
        Me.PositionTextBox = New System.Windows.Forms.TextBox
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        Me.ErrorWarnInfoProvider1 = New AccControlsWinForms.ErrorWarnInfoProvider(Me.components)
        IDLabel = New System.Windows.Forms.Label
        InsertDateLabel = New System.Windows.Forms.Label
        UpdateDateLabel = New System.Windows.Forms.Label
        DateLabel = New System.Windows.Forms.Label
        SerialLabel = New System.Windows.Forms.Label
        NumberLabel = New System.Windows.Forms.Label
        PersonNameLabel = New System.Windows.Forms.Label
        PersonSodraCodeLabel = New System.Windows.Forms.Label
        PersonAddressLabel = New System.Windows.Forms.Label
        PersonCodeLabel = New System.Windows.Forms.Label
        PositionLabel = New System.Windows.Forms.Label
        WorkLoadLabel = New System.Windows.Forms.Label
        WageLabel = New System.Windows.Forms.Label
        HumanReadableWageTypeLabel = New System.Windows.Forms.Label
        ExtraPayLabel = New System.Windows.Forms.Label
        IsTerminatedLabel = New System.Windows.Forms.Label
        AnnualHolidayLabel = New System.Windows.Forms.Label
        HolidayCorrectionLabel = New System.Windows.Forms.Label
        ContentLabel = New System.Windows.Forms.Label
        NPDLabel = New System.Windows.Forms.Label
        PNPDLabel = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.ContractBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IDLabel
        '
        IDLabel.AutoSize = True
        IDLabel.Dock = System.Windows.Forms.DockStyle.Fill
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(3, 7)
        IDLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(122, 23)
        IDLabel.TabIndex = 5
        IDLabel.Text = "ID:"
        IDLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'InsertDateLabel
        '
        InsertDateLabel.AutoSize = True
        InsertDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        InsertDateLabel.Location = New System.Drawing.Point(178, 5)
        InsertDateLabel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        InsertDateLabel.Name = "InsertDateLabel"
        InsertDateLabel.Size = New System.Drawing.Size(76, 13)
        InsertDateLabel.TabIndex = 7
        InsertDateLabel.Text = "Įtraukta DB:"
        '
        'UpdateDateLabel
        '
        UpdateDateLabel.AutoSize = True
        UpdateDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UpdateDateLabel.Location = New System.Drawing.Point(435, 5)
        UpdateDateLabel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        UpdateDateLabel.Name = "UpdateDateLabel"
        UpdateDateLabel.Size = New System.Drawing.Size(81, 13)
        UpdateDateLabel.TabIndex = 9
        UpdateDateLabel.Text = "Pakeista DB:"
        '
        'DateLabel
        '
        DateLabel.AutoSize = True
        DateLabel.Dock = System.Windows.Forms.DockStyle.Fill
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(3, 97)
        DateLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(122, 23)
        DateLabel.TabIndex = 3
        DateLabel.Text = "Data:"
        DateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'SerialLabel
        '
        SerialLabel.AutoSize = True
        SerialLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerialLabel.Location = New System.Drawing.Point(189, 5)
        SerialLabel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        SerialLabel.Name = "SerialLabel"
        SerialLabel.Size = New System.Drawing.Size(43, 13)
        SerialLabel.TabIndex = 5
        SerialLabel.Text = "Serija:"
        '
        'NumberLabel
        '
        NumberLabel.AutoSize = True
        NumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NumberLabel.Location = New System.Drawing.Point(424, 5)
        NumberLabel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        NumberLabel.Name = "NumberLabel"
        NumberLabel.Size = New System.Drawing.Size(56, 13)
        NumberLabel.TabIndex = 7
        NumberLabel.Text = "Numeris:"
        '
        'PersonNameLabel
        '
        PersonNameLabel.AutoSize = True
        PersonNameLabel.Dock = System.Windows.Forms.DockStyle.Fill
        PersonNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PersonNameLabel.Location = New System.Drawing.Point(3, 37)
        PersonNameLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        PersonNameLabel.Name = "PersonNameLabel"
        PersonNameLabel.Size = New System.Drawing.Size(122, 23)
        PersonNameLabel.TabIndex = 4
        PersonNameLabel.Text = "Darbuotojas:"
        PersonNameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PersonSodraCodeLabel
        '
        PersonSodraCodeLabel.AutoSize = True
        PersonSodraCodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PersonSodraCodeLabel.Location = New System.Drawing.Point(419, 5)
        PersonSodraCodeLabel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        PersonSodraCodeLabel.Name = "PersonSodraCodeLabel"
        PersonSodraCodeLabel.Size = New System.Drawing.Size(54, 13)
        PersonSodraCodeLabel.TabIndex = 6
        PersonSodraCodeLabel.Text = "SODRA:"
        '
        'PersonAddressLabel
        '
        PersonAddressLabel.AutoSize = True
        PersonAddressLabel.Dock = System.Windows.Forms.DockStyle.Fill
        PersonAddressLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PersonAddressLabel.Location = New System.Drawing.Point(3, 67)
        PersonAddressLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        PersonAddressLabel.Name = "PersonAddressLabel"
        PersonAddressLabel.Size = New System.Drawing.Size(122, 23)
        PersonAddressLabel.TabIndex = 4
        PersonAddressLabel.Text = "Darbuotojo Adresas:"
        PersonAddressLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PersonCodeLabel
        '
        PersonCodeLabel.AutoSize = True
        PersonCodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PersonCodeLabel.Location = New System.Drawing.Point(393, 5)
        PersonCodeLabel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        PersonCodeLabel.Name = "PersonCodeLabel"
        PersonCodeLabel.Size = New System.Drawing.Size(93, 13)
        PersonCodeLabel.TabIndex = 6
        PersonCodeLabel.Text = "Asmens Kodas:"
        '
        'PositionLabel
        '
        PositionLabel.AutoSize = True
        PositionLabel.Dock = System.Windows.Forms.DockStyle.Fill
        PositionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PositionLabel.Location = New System.Drawing.Point(3, 157)
        PositionLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        PositionLabel.Name = "PositionLabel"
        PositionLabel.Size = New System.Drawing.Size(122, 23)
        PositionLabel.TabIndex = 4
        PositionLabel.Text = "Pareigos:"
        PositionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'WorkLoadLabel
        '
        WorkLoadLabel.AutoSize = True
        WorkLoadLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        WorkLoadLabel.Location = New System.Drawing.Point(425, 5)
        WorkLoadLabel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        WorkLoadLabel.Name = "WorkLoadLabel"
        WorkLoadLabel.Size = New System.Drawing.Size(46, 13)
        WorkLoadLabel.TabIndex = 6
        WorkLoadLabel.Text = "Krūvis:"
        '
        'WageLabel
        '
        WageLabel.AutoSize = True
        WageLabel.Dock = System.Windows.Forms.DockStyle.Fill
        WageLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        WageLabel.Location = New System.Drawing.Point(3, 187)
        WageLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        WageLabel.Name = "WageLabel"
        WageLabel.Size = New System.Drawing.Size(122, 23)
        WageLabel.TabIndex = 4
        WageLabel.Text = "Darbo Užmokestis:"
        WageLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'HumanReadableWageTypeLabel
        '
        HumanReadableWageTypeLabel.AutoSize = True
        HumanReadableWageTypeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        HumanReadableWageTypeLabel.Location = New System.Drawing.Point(199, 5)
        HumanReadableWageTypeLabel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        HumanReadableWageTypeLabel.Name = "HumanReadableWageTypeLabel"
        HumanReadableWageTypeLabel.Size = New System.Drawing.Size(42, 13)
        HumanReadableWageTypeLabel.TabIndex = 6
        HumanReadableWageTypeLabel.Text = "Tipas:"
        '
        'ExtraPayLabel
        '
        ExtraPayLabel.AutoSize = True
        ExtraPayLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ExtraPayLabel.Location = New System.Drawing.Point(443, 5)
        ExtraPayLabel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        ExtraPayLabel.Name = "ExtraPayLabel"
        ExtraPayLabel.Size = New System.Drawing.Size(53, 13)
        ExtraPayLabel.TabIndex = 8
        ExtraPayLabel.Text = "Priedas:"
        '
        'IsTerminatedLabel
        '
        IsTerminatedLabel.AutoSize = True
        IsTerminatedLabel.Dock = System.Windows.Forms.DockStyle.Fill
        IsTerminatedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IsTerminatedLabel.Location = New System.Drawing.Point(3, 217)
        IsTerminatedLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        IsTerminatedLabel.Name = "IsTerminatedLabel"
        IsTerminatedLabel.Size = New System.Drawing.Size(122, 23)
        IsTerminatedLabel.TabIndex = 4
        IsTerminatedLabel.Text = "Sutartis Nutraukta:"
        IsTerminatedLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AnnualHolidayLabel
        '
        AnnualHolidayLabel.AutoSize = True
        AnnualHolidayLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AnnualHolidayLabel.Location = New System.Drawing.Point(170, 5)
        AnnualHolidayLabel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        AnnualHolidayLabel.Name = "AnnualHolidayLabel"
        AnnualHolidayLabel.Size = New System.Drawing.Size(116, 13)
        AnnualHolidayLabel.TabIndex = 8
        AnnualHolidayLabel.Text = "Kasmet. Atostogos:"
        '
        'HolidayCorrectionLabel
        '
        HolidayCorrectionLabel.AutoSize = True
        HolidayCorrectionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        HolidayCorrectionLabel.Location = New System.Drawing.Point(438, 5)
        HolidayCorrectionLabel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        HolidayCorrectionLabel.Name = "HolidayCorrectionLabel"
        HolidayCorrectionLabel.Size = New System.Drawing.Size(109, 13)
        HolidayCorrectionLabel.TabIndex = 10
        HolidayCorrectionLabel.Text = "Atostogų Korekc.:"
        '
        'ContentLabel
        '
        ContentLabel.AutoSize = True
        ContentLabel.Dock = System.Windows.Forms.DockStyle.Fill
        ContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContentLabel.Location = New System.Drawing.Point(3, 127)
        ContentLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        ContentLabel.Name = "ContentLabel"
        ContentLabel.Size = New System.Drawing.Size(122, 23)
        ContentLabel.TabIndex = 4
        ContentLabel.Text = "Turinys:"
        ContentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'NPDLabel
        '
        NPDLabel.AutoSize = True
        NPDLabel.Dock = System.Windows.Forms.DockStyle.Fill
        NPDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NPDLabel.Location = New System.Drawing.Point(3, 247)
        NPDLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        NPDLabel.Name = "NPDLabel"
        NPDLabel.Size = New System.Drawing.Size(122, 23)
        NPDLabel.TabIndex = 6
        NPDLabel.Text = "NPD:"
        NPDLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PNPDLabel
        '
        PNPDLabel.AutoSize = True
        PNPDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PNPDLabel.Location = New System.Drawing.Point(184, 5)
        PNPDLabel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        PNPDLabel.Name = "PNPDLabel"
        PNPDLabel.Size = New System.Drawing.Size(45, 13)
        PNPDLabel.TabIndex = 8
        PNPDLabel.Text = "PNPD:"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.ICancelButton)
        Me.Panel1.Controls.Add(Me.IApplyButton)
        Me.Panel1.Controls.Add(Me.IOkButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 295)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(824, 34)
        Me.Panel1.TabIndex = 1
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(737, 8)
        Me.ICancelButton.Name = "ICancelButton"
        Me.ICancelButton.Size = New System.Drawing.Size(75, 23)
        Me.ICancelButton.TabIndex = 3
        Me.ICancelButton.Text = "Atšaukti"
        Me.ICancelButton.UseVisualStyleBackColor = True
        '
        'IApplyButton
        '
        Me.IApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IApplyButton.Location = New System.Drawing.Point(656, 8)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(75, 23)
        Me.IApplyButton.TabIndex = 2
        Me.IApplyButton.Text = "Taikyti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'IOkButton
        '
        Me.IOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IOkButton.Location = New System.Drawing.Point(575, 8)
        Me.IOkButton.Name = "IOkButton"
        Me.IOkButton.Size = New System.Drawing.Size(75, 23)
        Me.IOkButton.TabIndex = 1
        Me.IOkButton.Text = "OK"
        Me.IOkButton.UseVisualStyleBackColor = True
        '
        'RefreshNumberButton
        '
        Me.RefreshNumberButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Button_Reload_icon_16p
        Me.RefreshNumberButton.Location = New System.Drawing.Point(483, 0)
        Me.RefreshNumberButton.Margin = New System.Windows.Forms.Padding(0)
        Me.RefreshNumberButton.Name = "RefreshNumberButton"
        Me.RefreshNumberButton.Size = New System.Drawing.Size(24, 24)
        Me.RefreshNumberButton.TabIndex = 2
        Me.RefreshNumberButton.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(ContentLabel, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel6, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(PersonAddressLabel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(PersonNameLabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(DateLabel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(NPDLabel, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(IsTerminatedLabel, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(WageLabel, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(PositionLabel, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel10, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel9, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel8, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel7, 1, 5)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(824, 295)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ContentTextBox, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(128, 123)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(696, 24)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'ContentTextBox
        '
        Me.ContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContractBindingSource, "Content", True))
        Me.ContentTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentTextBox.Location = New System.Drawing.Point(1, 3)
        Me.ContentTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.ContentTextBox.MaxLength = 255
        Me.ContentTextBox.Name = "ContentTextBox"
        Me.ContentTextBox.Size = New System.Drawing.Size(674, 20)
        Me.ContentTextBox.TabIndex = 0
        '
        'ContractBindingSource
        '
        Me.ContractBindingSource.DataSource = GetType(ApskaitaObjects.Workers.Contract)
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 5
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.PersonCodeTextBox, 3, 0)
        Me.TableLayoutPanel6.Controls.Add(PersonCodeLabel, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.PersonAddressTextBox, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(128, 63)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(696, 24)
        Me.TableLayoutPanel6.TabIndex = 2
        '
        'PersonCodeTextBox
        '
        Me.PersonCodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContractBindingSource, "PersonCode", True))
        Me.PersonCodeTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonCodeTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PersonCodeTextBox.Location = New System.Drawing.Point(490, 3)
        Me.PersonCodeTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.PersonCodeTextBox.Name = "PersonCodeTextBox"
        Me.PersonCodeTextBox.ReadOnly = True
        Me.PersonCodeTextBox.Size = New System.Drawing.Size(183, 20)
        Me.PersonCodeTextBox.TabIndex = 7
        Me.PersonCodeTextBox.TabStop = False
        Me.PersonCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PersonAddressTextBox
        '
        Me.PersonAddressTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContractBindingSource, "PersonAddress", True))
        Me.PersonAddressTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonAddressTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PersonAddressTextBox.Location = New System.Drawing.Point(1, 3)
        Me.PersonAddressTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.PersonAddressTextBox.Name = "PersonAddressTextBox"
        Me.PersonAddressTextBox.ReadOnly = True
        Me.PersonAddressTextBox.Size = New System.Drawing.Size(368, 20)
        Me.PersonAddressTextBox.TabIndex = 5
        Me.PersonAddressTextBox.TabStop = False
        Me.PersonAddressTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 5
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.PersonSodraCodeTextBox, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(PersonSodraCodeLabel, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.PersonNameTextBox, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(128, 33)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(696, 24)
        Me.TableLayoutPanel5.TabIndex = 1
        '
        'PersonSodraCodeTextBox
        '
        Me.PersonSodraCodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContractBindingSource, "PersonSodraCode", True))
        Me.PersonSodraCodeTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonSodraCodeTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PersonSodraCodeTextBox.Location = New System.Drawing.Point(477, 3)
        Me.PersonSodraCodeTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.PersonSodraCodeTextBox.Name = "PersonSodraCodeTextBox"
        Me.PersonSodraCodeTextBox.ReadOnly = True
        Me.PersonSodraCodeTextBox.Size = New System.Drawing.Size(196, 20)
        Me.PersonSodraCodeTextBox.TabIndex = 7
        Me.PersonSodraCodeTextBox.TabStop = False
        Me.PersonSodraCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PersonNameTextBox
        '
        Me.PersonNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContractBindingSource, "PersonName", True))
        Me.PersonNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonNameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PersonNameTextBox.Location = New System.Drawing.Point(1, 3)
        Me.PersonNameTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.PersonNameTextBox.Name = "PersonNameTextBox"
        Me.PersonNameTextBox.ReadOnly = True
        Me.PersonNameTextBox.Size = New System.Drawing.Size(394, 20)
        Me.PersonNameTextBox.TabIndex = 5
        Me.PersonNameTextBox.TabStop = False
        Me.PersonNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoScroll = True
        Me.TableLayoutPanel4.ColumnCount = 9
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33444!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33445!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33112!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.RefreshNumberButton, 6, 0)
        Me.TableLayoutPanel4.Controls.Add(NumberLabel, 5, 0)
        Me.TableLayoutPanel4.Controls.Add(SerialLabel, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.SerialComboBox, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.NumberAccTextBox, 7, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.DateAccDatePicker, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(128, 93)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(696, 24)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'SerialComboBox
        '
        Me.SerialComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContractBindingSource, "Serial", True))
        Me.SerialComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SerialComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SerialComboBox.FormattingEnabled = True
        Me.SerialComboBox.Location = New System.Drawing.Point(236, 2)
        Me.SerialComboBox.Margin = New System.Windows.Forms.Padding(1, 2, 1, 3)
        Me.SerialComboBox.Name = "SerialComboBox"
        Me.SerialComboBox.Size = New System.Drawing.Size(164, 21)
        Me.SerialComboBox.TabIndex = 1
        '
        'NumberAccTextBox
        '
        Me.NumberAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.ContractBindingSource, "Number", True))
        Me.NumberAccTextBox.DecimalLength = 0
        Me.NumberAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NumberAccTextBox.Location = New System.Drawing.Point(508, 3)
        Me.NumberAccTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.NumberAccTextBox.Name = "NumberAccTextBox"
        Me.NumberAccTextBox.NegativeValue = False
        Me.NumberAccTextBox.Size = New System.Drawing.Size(164, 20)
        Me.NumberAccTextBox.TabIndex = 3
        Me.NumberAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateAccDatePicker
        '
        Me.DateAccDatePicker.BoldedDates = Nothing
        Me.DateAccDatePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.ContractBindingSource, "Date", True))
        Me.DateAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateAccDatePicker.Location = New System.Drawing.Point(0, 0)
        Me.DateAccDatePicker.Margin = New System.Windows.Forms.Padding(0)
        Me.DateAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateAccDatePicker.Name = "DateAccDatePicker"
        Me.DateAccDatePicker.ReadOnly = False
        Me.DateAccDatePicker.ShowWeekNumbers = True
        Me.DateAccDatePicker.Size = New System.Drawing.Size(166, 24)
        Me.DateAccDatePicker.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 8
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.UpdateDateTextBox, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(UpdateDateLabel, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.IDTextBox, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.InsertDateTextBox, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(InsertDateLabel, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(128, 3)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(696, 24)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'UpdateDateTextBox
        '
        Me.UpdateDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContractBindingSource, "UpdateDate", True))
        Me.UpdateDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UpdateDateTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdateDateTextBox.Location = New System.Drawing.Point(520, 3)
        Me.UpdateDateTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.UpdateDateTextBox.Name = "UpdateDateTextBox"
        Me.UpdateDateTextBox.ReadOnly = True
        Me.UpdateDateTextBox.Size = New System.Drawing.Size(153, 20)
        Me.UpdateDateTextBox.TabIndex = 10
        Me.UpdateDateTextBox.TabStop = False
        Me.UpdateDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IDTextBox
        '
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContractBindingSource, "ID", True))
        Me.IDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IDTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IDTextBox.Location = New System.Drawing.Point(1, 3)
        Me.IDTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(153, 20)
        Me.IDTextBox.TabIndex = 6
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'InsertDateTextBox
        '
        Me.InsertDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContractBindingSource, "InsertDate", True))
        Me.InsertDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InsertDateTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsertDateTextBox.Location = New System.Drawing.Point(258, 3)
        Me.InsertDateTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.InsertDateTextBox.Name = "InsertDateTextBox"
        Me.InsertDateTextBox.ReadOnly = True
        Me.InsertDateTextBox.Size = New System.Drawing.Size(153, 20)
        Me.InsertDateTextBox.TabIndex = 8
        Me.InsertDateTextBox.TabStop = False
        Me.InsertDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.ColumnCount = 8
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.PNPDAccTextBox, 3, 0)
        Me.TableLayoutPanel10.Controls.Add(PNPDLabel, 2, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.NPDAccTextBox, 0, 0)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(128, 243)
        Me.TableLayoutPanel10.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 1
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(696, 24)
        Me.TableLayoutPanel10.TabIndex = 8
        '
        'PNPDAccTextBox
        '
        Me.PNPDAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.ContractBindingSource, "PNPD", True))
        Me.PNPDAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNPDAccTextBox.Location = New System.Drawing.Point(233, 3)
        Me.PNPDAccTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.PNPDAccTextBox.Name = "PNPDAccTextBox"
        Me.PNPDAccTextBox.NegativeValue = False
        Me.PNPDAccTextBox.Size = New System.Drawing.Size(159, 20)
        Me.PNPDAccTextBox.TabIndex = 1
        Me.PNPDAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NPDAccTextBox
        '
        Me.NPDAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.ContractBindingSource, "NPD", True))
        Me.NPDAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NPDAccTextBox.Location = New System.Drawing.Point(1, 3)
        Me.NPDAccTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.NPDAccTextBox.Name = "NPDAccTextBox"
        Me.NPDAccTextBox.NegativeValue = False
        Me.NPDAccTextBox.Size = New System.Drawing.Size(159, 20)
        Me.NPDAccTextBox.TabIndex = 0
        Me.NPDAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.AutoScroll = True
        Me.TableLayoutPanel9.ColumnCount = 9
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.HolidayCorrectionAccTextBox, 7, 0)
        Me.TableLayoutPanel9.Controls.Add(HolidayCorrectionLabel, 6, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.IsTerminatedCheckBox, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.AnnualHolidayAccTextBox, 4, 0)
        Me.TableLayoutPanel9.Controls.Add(AnnualHolidayLabel, 3, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.TerminationDateAccDatePicker, 1, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(128, 213)
        Me.TableLayoutPanel9.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(696, 24)
        Me.TableLayoutPanel9.TabIndex = 7
        '
        'HolidayCorrectionAccTextBox
        '
        Me.HolidayCorrectionAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.ContractBindingSource, "HolidayCorrection", True))
        Me.HolidayCorrectionAccTextBox.DecimalLength = 4
        Me.HolidayCorrectionAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HolidayCorrectionAccTextBox.Location = New System.Drawing.Point(551, 3)
        Me.HolidayCorrectionAccTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.HolidayCorrectionAccTextBox.Name = "HolidayCorrectionAccTextBox"
        Me.HolidayCorrectionAccTextBox.Size = New System.Drawing.Size(124, 20)
        Me.HolidayCorrectionAccTextBox.TabIndex = 3
        Me.HolidayCorrectionAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IsTerminatedCheckBox
        '
        Me.IsTerminatedCheckBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IsTerminatedCheckBox.AutoSize = True
        Me.IsTerminatedCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.ContractBindingSource, "IsTerminated", True))
        Me.IsTerminatedCheckBox.Location = New System.Drawing.Point(3, 5)
        Me.IsTerminatedCheckBox.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.IsTerminatedCheckBox.Name = "IsTerminatedCheckBox"
        Me.IsTerminatedCheckBox.Size = New System.Drawing.Size(15, 16)
        Me.IsTerminatedCheckBox.TabIndex = 0
        '
        'AnnualHolidayAccTextBox
        '
        Me.AnnualHolidayAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.ContractBindingSource, "AnnualHoliday", True))
        Me.AnnualHolidayAccTextBox.DecimalLength = 0
        Me.AnnualHolidayAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AnnualHolidayAccTextBox.Location = New System.Drawing.Point(290, 3)
        Me.AnnualHolidayAccTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.AnnualHolidayAccTextBox.Name = "AnnualHolidayAccTextBox"
        Me.AnnualHolidayAccTextBox.NegativeValue = False
        Me.AnnualHolidayAccTextBox.Size = New System.Drawing.Size(124, 20)
        Me.AnnualHolidayAccTextBox.TabIndex = 2
        Me.AnnualHolidayAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TerminationDateAccDatePicker
        '
        Me.TerminationDateAccDatePicker.BoldedDates = Nothing
        Me.TerminationDateAccDatePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.ContractBindingSource, "TerminationDate", True))
        Me.TerminationDateAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TerminationDateAccDatePicker.Location = New System.Drawing.Point(21, 0)
        Me.TerminationDateAccDatePicker.Margin = New System.Windows.Forms.Padding(0)
        Me.TerminationDateAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.TerminationDateAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.TerminationDateAccDatePicker.Name = "TerminationDateAccDatePicker"
        Me.TerminationDateAccDatePicker.ReadOnly = False
        Me.TerminationDateAccDatePicker.ShowWeekNumbers = True
        Me.TerminationDateAccDatePicker.Size = New System.Drawing.Size(126, 24)
        Me.TerminationDateAccDatePicker.TabIndex = 1
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 8
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.ExtraPayAccTextBox, 6, 0)
        Me.TableLayoutPanel8.Controls.Add(ExtraPayLabel, 5, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.WageAccTextBox, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(HumanReadableWageTypeLabel, 2, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.HumanReadableWageTypeComboBox, 3, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(128, 183)
        Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(696, 24)
        Me.TableLayoutPanel8.TabIndex = 6
        '
        'ExtraPayAccTextBox
        '
        Me.ExtraPayAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.ContractBindingSource, "ExtraPay", True))
        Me.ExtraPayAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExtraPayAccTextBox.Location = New System.Drawing.Point(500, 3)
        Me.ExtraPayAccTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.ExtraPayAccTextBox.Name = "ExtraPayAccTextBox"
        Me.ExtraPayAccTextBox.NegativeValue = False
        Me.ExtraPayAccTextBox.Size = New System.Drawing.Size(174, 20)
        Me.ExtraPayAccTextBox.TabIndex = 2
        Me.ExtraPayAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'WageAccTextBox
        '
        Me.WageAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.ContractBindingSource, "Wage", True))
        Me.WageAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WageAccTextBox.Location = New System.Drawing.Point(1, 3)
        Me.WageAccTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.WageAccTextBox.Name = "WageAccTextBox"
        Me.WageAccTextBox.NegativeValue = False
        Me.WageAccTextBox.Size = New System.Drawing.Size(174, 20)
        Me.WageAccTextBox.TabIndex = 0
        Me.WageAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'HumanReadableWageTypeComboBox
        '
        Me.HumanReadableWageTypeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContractBindingSource, "HumanReadableWageType", True))
        Me.HumanReadableWageTypeComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HumanReadableWageTypeComboBox.FormattingEnabled = True
        Me.HumanReadableWageTypeComboBox.Location = New System.Drawing.Point(245, 1)
        Me.HumanReadableWageTypeComboBox.Margin = New System.Windows.Forms.Padding(1, 1, 1, 3)
        Me.HumanReadableWageTypeComboBox.Name = "HumanReadableWageTypeComboBox"
        Me.HumanReadableWageTypeComboBox.Size = New System.Drawing.Size(174, 21)
        Me.HumanReadableWageTypeComboBox.TabIndex = 1
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 5
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.WorkLoadAccTextBox, 3, 0)
        Me.TableLayoutPanel7.Controls.Add(WorkLoadLabel, 2, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.PositionTextBox, 0, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(128, 153)
        Me.TableLayoutPanel7.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(696, 24)
        Me.TableLayoutPanel7.TabIndex = 5
        '
        'WorkLoadAccTextBox
        '
        Me.WorkLoadAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.ContractBindingSource, "WorkLoad", True))
        Me.WorkLoadAccTextBox.DecimalLength = 4
        Me.WorkLoadAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WorkLoadAccTextBox.Location = New System.Drawing.Point(475, 3)
        Me.WorkLoadAccTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.WorkLoadAccTextBox.Name = "WorkLoadAccTextBox"
        Me.WorkLoadAccTextBox.NegativeValue = False
        Me.WorkLoadAccTextBox.Size = New System.Drawing.Size(199, 20)
        Me.WorkLoadAccTextBox.TabIndex = 1
        Me.WorkLoadAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PositionTextBox
        '
        Me.PositionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ContractBindingSource, "Position", True))
        Me.PositionTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PositionTextBox.Location = New System.Drawing.Point(1, 3)
        Me.PositionTextBox.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.PositionTextBox.MaxLength = 100
        Me.PositionTextBox.Name = "PositionTextBox"
        Me.PositionTextBox.Size = New System.Drawing.Size(400, 20)
        Me.PositionTextBox.TabIndex = 0
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(145, 15)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(104, 93)
        Me.ProgressFiller1.TabIndex = 2
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(280, 16)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(192, 92)
        Me.ProgressFiller2.TabIndex = 3
        Me.ProgressFiller2.Visible = False
        '
        'ErrorWarnInfoProvider1
        '
        Me.ErrorWarnInfoProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleInformation = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleWarning = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.ContainerControl = Me
        Me.ErrorWarnInfoProvider1.DataSource = Me.ContractBindingSource
        '
        'F_Contract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 329)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_Contract"
        Me.ShowInTaskbar = False
        Me.Text = "Darbo sutartis"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.ContractBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel10.PerformLayout()
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RefreshNumberButton As System.Windows.Forms.Button
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UpdateDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ContractBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InsertDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents NumberAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents SerialComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PersonNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PersonSodraCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents WorkLoadAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents PositionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PersonCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PersonAddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ExtraPayAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents WageAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents HumanReadableWageTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents HolidayCorrectionAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents IsTerminatedCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AnnualHolidayAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents TableLayoutPanel10 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PNPDAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents NPDAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents ContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ErrorWarnInfoProvider1 As AccControlsWinForms.ErrorWarnInfoProvider
    Friend WithEvents DateAccDatePicker As AccControlsWinForms.AccDatePicker
    Friend WithEvents TerminationDateAccDatePicker As AccControlsWinForms.AccDatePicker
End Class
