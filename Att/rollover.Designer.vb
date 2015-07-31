<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class cont_rollover
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
	Public WithEvents ref_list As System.Windows.Forms.Button
    Public WithEvents beg_Date As System.Windows.Forms.TextBox
	Public WithEvents frm_fiscal As System.Windows.Forms.TextBox
	Public WithEvents to_fiscal As System.Windows.Forms.TextBox
	Public WithEvents Accept As System.Windows.Forms.Button
	Public WithEvents Cancel As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ref_list = New System.Windows.Forms.Button
        Me.beg_Date = New System.Windows.Forms.TextBox
        Me.frm_fiscal = New System.Windows.Forms.TextBox
        Me.to_fiscal = New System.Windows.Forms.TextBox
        Me.Accept = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ref_list
        '
        Me.ref_list.BackColor = System.Drawing.SystemColors.Control
        Me.ref_list.Cursor = System.Windows.Forms.Cursors.Default
        Me.ref_list.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ref_list.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ref_list.Location = New System.Drawing.Point(373, 39)
        Me.ref_list.Name = "ref_list"
        Me.ref_list.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ref_list.Size = New System.Drawing.Size(137, 41)
        Me.ref_list.TabIndex = 3
        Me.ref_list.Text = "Refresh"
        Me.ref_list.UseVisualStyleBackColor = False
        '
        'beg_Date
        '
        Me.beg_Date.AcceptsReturn = True
        Me.beg_Date.BackColor = System.Drawing.SystemColors.Window
        Me.beg_Date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.beg_Date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.beg_Date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.beg_Date.Location = New System.Drawing.Point(120, 40)
        Me.beg_Date.MaxLength = 0
        Me.beg_Date.Name = "beg_Date"
        Me.beg_Date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.beg_Date.Size = New System.Drawing.Size(137, 20)
        Me.beg_Date.TabIndex = 2
        '
        'frm_fiscal
        '
        Me.frm_fiscal.AcceptsReturn = True
        Me.frm_fiscal.BackColor = System.Drawing.SystemColors.Window
        Me.frm_fiscal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.frm_fiscal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frm_fiscal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.frm_fiscal.Location = New System.Drawing.Point(88, 0)
        Me.frm_fiscal.MaxLength = 0
        Me.frm_fiscal.Name = "frm_fiscal"
        Me.frm_fiscal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frm_fiscal.Size = New System.Drawing.Size(89, 20)
        Me.frm_fiscal.TabIndex = 0
        '
        'to_fiscal
        '
        Me.to_fiscal.AcceptsReturn = True
        Me.to_fiscal.BackColor = System.Drawing.SystemColors.Window
        Me.to_fiscal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.to_fiscal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.to_fiscal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.to_fiscal.Location = New System.Drawing.Point(288, 0)
        Me.to_fiscal.MaxLength = 0
        Me.to_fiscal.Name = "to_fiscal"
        Me.to_fiscal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.to_fiscal.Size = New System.Drawing.Size(97, 20)
        Me.to_fiscal.TabIndex = 1
        '
        'Accept
        '
        Me.Accept.BackColor = System.Drawing.SystemColors.Control
        Me.Accept.Cursor = System.Windows.Forms.Cursors.Default
        Me.Accept.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Accept.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Accept.Location = New System.Drawing.Point(763, 144)
        Me.Accept.Name = "Accept"
        Me.Accept.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Accept.Size = New System.Drawing.Size(137, 49)
        Me.Accept.TabIndex = 4
        Me.Accept.Text = "Rollover Selected Contract"
        Me.Accept.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(392, 8)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(97, 25)
        Me.Cancel.TabIndex = 5
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(0, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(121, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Begin date for contract"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(0, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(81, 17)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "From Fiscal Year"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(208, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(81, 17)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "To Fiscal Year"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(22, 88)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(735, 484)
        Me.DataGridView1.TabIndex = 9
        '
        'cont_rollover
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(940, 612)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ref_list)
        Me.Controls.Add(Me.beg_Date)
        Me.Controls.Add(Me.frm_fiscal)
        Me.Controls.Add(Me.to_fiscal)
        Me.Controls.Add(Me.Accept)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(45, 113)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "cont_rollover"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Contract Roll over control"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
#End Region 
End Class