<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_DatabaseTableAccessRoleList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_DatabaseTableAccessRoleList))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PasteButton = New System.Windows.Forms.Button
        Me.SaveFileAsButton = New System.Windows.Forms.Button
        Me.SaveFileButton = New System.Windows.Forms.Button
        Me.OpenFileButton = New System.Windows.Forms.Button
        Me.LoadGaugeButton = New System.Windows.Forms.Button
        Me.DatabaseTableAccessRoleListDataGridView = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TableAccessList = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReadOnlyTableAccessList = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IsHelperList = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ParentRoles = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DatabaseTableAccessRoleListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.DatabaseTableAccessRoleListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatabaseTableAccessRoleListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.PasteButton)
        Me.Panel1.Controls.Add(Me.SaveFileAsButton)
        Me.Panel1.Controls.Add(Me.SaveFileButton)
        Me.Panel1.Controls.Add(Me.OpenFileButton)
        Me.Panel1.Controls.Add(Me.LoadGaugeButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Panel1.Size = New System.Drawing.Size(754, 45)
        Me.Panel1.TabIndex = 0
        '
        'PasteButton
        '
        Me.PasteButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PasteButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Paste_icon_24p
        Me.PasteButton.Location = New System.Drawing.Point(521, 9)
        Me.PasteButton.Name = "PasteButton"
        Me.PasteButton.Size = New System.Drawing.Size(30, 30)
        Me.PasteButton.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.PasteButton, "Paste content")
        Me.PasteButton.UseVisualStyleBackColor = True
        '
        'SaveFileAsButton
        '
        Me.SaveFileAsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveFileAsButton.Image = Global.ApskaitaWUI.My.Resources.Resources.filesaveas_22x22
        Me.SaveFileAsButton.Location = New System.Drawing.Point(712, 9)
        Me.SaveFileAsButton.Name = "SaveFileAsButton"
        Me.SaveFileAsButton.Size = New System.Drawing.Size(30, 30)
        Me.SaveFileAsButton.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.SaveFileAsButton, "Išsaugoti failą kaip...")
        Me.SaveFileAsButton.UseVisualStyleBackColor = True
        '
        'SaveFileButton
        '
        Me.SaveFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveFileButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Actions_document_save_icon_24p
        Me.SaveFileButton.Location = New System.Drawing.Point(676, 9)
        Me.SaveFileButton.Name = "SaveFileButton"
        Me.SaveFileButton.Size = New System.Drawing.Size(30, 30)
        Me.SaveFileButton.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.SaveFileButton, "Išsaugoti failą")
        Me.SaveFileButton.UseVisualStyleBackColor = True
        '
        'OpenFileButton
        '
        Me.OpenFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpenFileButton.Image = Global.ApskaitaWUI.My.Resources.Resources.folder_open_icon_24p
        Me.OpenFileButton.Location = New System.Drawing.Point(640, 9)
        Me.OpenFileButton.Name = "OpenFileButton"
        Me.OpenFileButton.Size = New System.Drawing.Size(30, 30)
        Me.OpenFileButton.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.OpenFileButton, "Atidaryti failą")
        Me.OpenFileButton.UseVisualStyleBackColor = True
        '
        'LoadGaugeButton
        '
        Me.LoadGaugeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LoadGaugeButton.Image = Global.ApskaitaWUI.My.Resources.Resources.database_settings_icon_24
        Me.LoadGaugeButton.Location = New System.Drawing.Point(582, 9)
        Me.LoadGaugeButton.Name = "LoadGaugeButton"
        Me.LoadGaugeButton.Size = New System.Drawing.Size(30, 30)
        Me.LoadGaugeButton.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.LoadGaugeButton, "Įkrauti naudojamą šabloną")
        Me.LoadGaugeButton.UseVisualStyleBackColor = True
        '
        'DatabaseTableAccessRoleListDataGridView
        '
        Me.DatabaseTableAccessRoleListDataGridView.AllowUserToOrderColumns = True
        Me.DatabaseTableAccessRoleListDataGridView.AutoGenerateColumns = False
        Me.DatabaseTableAccessRoleListDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DatabaseTableAccessRoleListDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DatabaseTableAccessRoleListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DatabaseTableAccessRoleListDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.TableAccessList, Me.ReadOnlyTableAccessList, Me.IsHelperList, Me.ParentRoles})
        Me.DatabaseTableAccessRoleListDataGridView.DataSource = Me.DatabaseTableAccessRoleListBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DatabaseTableAccessRoleListDataGridView.DefaultCellStyle = DataGridViewCellStyle3
        Me.DatabaseTableAccessRoleListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DatabaseTableAccessRoleListDataGridView.Location = New System.Drawing.Point(0, 45)
        Me.DatabaseTableAccessRoleListDataGridView.Name = "DatabaseTableAccessRoleListDataGridView"
        Me.DatabaseTableAccessRoleListDataGridView.RowHeadersWidth = 20
        Me.DatabaseTableAccessRoleListDataGridView.Size = New System.Drawing.Size(754, 485)
        Me.DatabaseTableAccessRoleListDataGridView.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.DataPropertyName = "VisibleIndex"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "##"
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column1.HeaderText = "Visible Index"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 96
        '
        'TableAccessList
        '
        Me.TableAccessList.DataPropertyName = "TableAccessList"
        Me.TableAccessList.HeaderText = "Table Access List"
        Me.TableAccessList.Name = "TableAccessList"
        '
        'ReadOnlyTableAccessList
        '
        Me.ReadOnlyTableAccessList.DataPropertyName = "ReadOnlyTableAccessList"
        Me.ReadOnlyTableAccessList.HeaderText = "ReadOnly Table Access List"
        Me.ReadOnlyTableAccessList.Name = "ReadOnlyTableAccessList"
        '
        'IsHelperList
        '
        Me.IsHelperList.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.IsHelperList.DataPropertyName = "IsHelperList"
        Me.IsHelperList.HeaderText = "Is Helper List"
        Me.IsHelperList.Name = "IsHelperList"
        Me.IsHelperList.Width = 79
        '
        'ParentRoles
        '
        Me.ParentRoles.DataPropertyName = "ParentRoles"
        Me.ParentRoles.HeaderText = "Parent Roles"
        Me.ParentRoles.Name = "ParentRoles"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "RoleName"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Role Name"
        Me.DataGridViewTextBoxColumn1.MaxInputLength = 255
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 87
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "RoleNameHumanReadable"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Role Name Human Readable"
        Me.DataGridViewTextBoxColumn2.MaxInputLength = 1000
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 132
        '
        'DatabaseTableAccessRoleListBindingSource
        '
        Me.DatabaseTableAccessRoleListBindingSource.DataSource = GetType(AccDataAccessLayer.Security.DatabaseTableAccess.DatabaseTableAccessRole)
        '
        'F_DatabaseTableAccessRoleList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 530)
        Me.Controls.Add(Me.DatabaseTableAccessRoleListDataGridView)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_DatabaseTableAccessRoleList"
        Me.Text = "Teisių sistemos redaktorius"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DatabaseTableAccessRoleListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatabaseTableAccessRoleListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LoadGaugeButton As System.Windows.Forms.Button
    Friend WithEvents SaveFileAsButton As System.Windows.Forms.Button
    Friend WithEvents SaveFileButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileButton As System.Windows.Forms.Button
    Friend WithEvents DatabaseTableAccessRoleListDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DatabaseTableAccessRoleListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PasteButton As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableAccessList As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReadOnlyTableAccessList As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsHelperList As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ParentRoles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
