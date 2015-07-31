<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class ccpr_ed
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
	Public WithEvents edit As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.edit = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridview1 = New System.Windows.Forms.DataGridView()
        Me.Pay_num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Name_key = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sort_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Entry_num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'edit
        '
        Me.edit.BackColor = System.Drawing.SystemColors.Control
        Me.edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.edit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edit.Location = New System.Drawing.Point(470, 72)
        Me.edit.Name = "edit"
        Me.edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edit.Size = New System.Drawing.Size(177, 33)
        Me.edit.TabIndex = 1
        Me.edit.Text = "Edit Selected Time Card"
        Me.edit.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(500, 16)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(67, 27)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(40, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(249, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "These time cards are unpaid "
        '
        'DataGridview1
        '
        Me.DataGridview1.AllowUserToAddRows = False
        Me.DataGridview1.AllowUserToDeleteRows = False
        Me.DataGridview1.AllowUserToResizeColumns = False
        Me.DataGridview1.AllowUserToResizeRows = False
        Me.DataGridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridview1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pay_num, Me.Name_key, Me.Sort_name, Me.Entry_num})
        Me.DataGridview1.Location = New System.Drawing.Point(43, 55)
        Me.DataGridview1.MultiSelect = False
        Me.DataGridview1.Name = "DataGridview1"
        Me.DataGridview1.ReadOnly = True
        Me.DataGridview1.RowHeadersVisible = False
        Me.DataGridview1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridview1.Size = New System.Drawing.Size(409, 542)
        Me.DataGridview1.TabIndex = 3
        Me.DataGridview1.TabStop = False
        '
        'Pay_num
        '
        Me.Pay_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Pay_num.DataPropertyName = "pay_num"
        Me.Pay_num.HeaderText = "Pay Num"
        Me.Pay_num.Name = "Pay_num"
        Me.Pay_num.ReadOnly = True
        Me.Pay_num.Width = 74
        '
        'Name_key
        '
        Me.Name_key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Name_key.DataPropertyName = "name_key"
        Me.Name_key.HeaderText = "Name Key"
        Me.Name_key.Name = "Name_key"
        Me.Name_key.ReadOnly = True
        Me.Name_key.Width = 81
        '
        'Sort_name
        '
        Me.Sort_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Sort_name.DataPropertyName = "sort_name"
        Me.Sort_name.HeaderText = "Sort Name"
        Me.Sort_name.Name = "Sort_name"
        Me.Sort_name.ReadOnly = True
        Me.Sort_name.Width = 82
        '
        'Entry_num
        '
        Me.Entry_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Entry_num.DataPropertyName = "entry_num"
        Me.Entry_num.HeaderText = "Entry Num"
        Me.Entry_num.Name = "Entry_num"
        Me.Entry_num.ReadOnly = True
        Me.Entry_num.Width = 81
        '
        'ccpr_ed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(659, 630)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridview1)
        Me.Controls.Add(Me.edit)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(52, 41)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ccpr_ed"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "CC Time Card Edit Selection Form"
        CType(Me.DataGridview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridview1 As System.Windows.Forms.DataGridView
    Friend WithEvents Pay_num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Name_key As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sort_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Entry_num As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region 
End Class