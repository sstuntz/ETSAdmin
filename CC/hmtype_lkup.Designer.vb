<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class hmtypelookup
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents delete As System.Windows.Forms.Button
	Public WithEvents Accept As System.Windows.Forms.Button
	Public WithEvents Cancel As System.Windows.Forms.Button
	Public WithEvents addacct As System.Windows.Forms.Button
	Public WithEvents edit As System.Windows.Forms.Button
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.delete = New System.Windows.Forms.Button
        Me.Accept = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.addacct = New System.Windows.Forms.Button
        Me.edit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TypeGrid = New System.Windows.Forms.DataGridView
        Me.Type_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Type_Desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.TypeGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'delete
        '
        Me.delete.BackColor = System.Drawing.SystemColors.Control
        Me.delete.Cursor = System.Windows.Forms.Cursors.Default
        Me.delete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.delete.Location = New System.Drawing.Point(344, 304)
        Me.delete.Name = "delete"
        Me.delete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.delete.Size = New System.Drawing.Size(73, 49)
        Me.delete.TabIndex = 5
        Me.delete.Text = "Delete"
        Me.delete.UseVisualStyleBackColor = False
        '
        'Accept
        '
        Me.Accept.BackColor = System.Drawing.SystemColors.Control
        Me.Accept.Cursor = System.Windows.Forms.Cursors.Default
        Me.Accept.Enabled = False
        Me.Accept.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Accept.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Accept.Location = New System.Drawing.Point(312, 96)
        Me.Accept.Name = "Accept"
        Me.Accept.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Accept.Size = New System.Drawing.Size(137, 49)
        Me.Accept.TabIndex = 0
        Me.Accept.Text = "Use Selected Number"
        Me.Accept.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(376, 8)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(97, 25)
        Me.Cancel.TabIndex = 3
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'addacct
        '
        Me.addacct.BackColor = System.Drawing.SystemColors.Control
        Me.addacct.Cursor = System.Windows.Forms.Cursors.Default
        Me.addacct.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addacct.ForeColor = System.Drawing.SystemColors.ControlText
        Me.addacct.Location = New System.Drawing.Point(344, 168)
        Me.addacct.Name = "addacct"
        Me.addacct.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.addacct.Size = New System.Drawing.Size(73, 49)
        Me.addacct.TabIndex = 2
        Me.addacct.Text = "Add"
        Me.addacct.UseVisualStyleBackColor = False
        '
        'edit
        '
        Me.edit.BackColor = System.Drawing.SystemColors.Control
        Me.edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.edit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edit.Location = New System.Drawing.Point(344, 240)
        Me.edit.Name = "edit"
        Me.edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edit.Size = New System.Drawing.Size(73, 49)
        Me.edit.TabIndex = 1
        Me.edit.Text = "Edit"
        Me.edit.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(14, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(278, 39)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Highlight a record and then click the EDIT button or just select the ADD button."
        '
        'TypeGrid
        '
        Me.TypeGrid.AllowUserToAddRows = False
        Me.TypeGrid.AllowUserToDeleteRows = False
        Me.TypeGrid.AllowUserToOrderColumns = True
        Me.TypeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TypeGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Type_name, Me.Type_Desc})
        Me.TypeGrid.Location = New System.Drawing.Point(17, 54)
        Me.TypeGrid.Name = "TypeGrid"
        Me.TypeGrid.ReadOnly = True
        Me.TypeGrid.Size = New System.Drawing.Size(273, 377)
        Me.TypeGrid.TabIndex = 6
        '
        'Type_name
        '
        Me.Type_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Type_name.DataPropertyName = "type_name"
        Me.Type_name.HeaderText = "Type Name"
        Me.Type_name.Name = "Type_name"
        Me.Type_name.ReadOnly = True
        Me.Type_name.Width = 85
        '
        'Type_Desc
        '
        Me.Type_Desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Type_Desc.DataPropertyName = "type_Desc"
        Me.Type_Desc.HeaderText = "Type Desc"
        Me.Type_Desc.Name = "Type_Desc"
        Me.Type_Desc.ReadOnly = True
        Me.Type_Desc.Width = 83
        '
        'hmtypelookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(491, 471)
        Me.ControlBox = False
        Me.Controls.Add(Me.TypeGrid)
        Me.Controls.Add(Me.delete)
        Me.Controls.Add(Me.Accept)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.addacct)
        Me.Controls.Add(Me.edit)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(105, 32)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "hmtypelookup"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Job Type Lookup"
        CType(Me.TypeGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TypeGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Type_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type_Desc As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class