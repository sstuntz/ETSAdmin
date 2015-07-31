<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class apvch_ed1
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
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdClose = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.vouch_num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Screen_nam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dt_tbe_pd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.disc_amt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.vouch_amt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Edit = New System.Windows.Forms.Button
        Me.addacct = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(560, 0)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(65, 20)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(39, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(362, 19)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Highlight a record and click on Edit Selected Voucher button."
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(39, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(345, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "These vouchers are Unpaid and Unposted to the General Ledger. "
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.vouch_num, Me.Screen_nam, Me.dt_tbe_pd, Me.disc_amt, Me.vouch_amt})
        Me.DataGridView1.Location = New System.Drawing.Point(27, 73)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(425, 455)
        Me.DataGridView1.TabIndex = 7
        '
        'vouch_num
        '
        Me.vouch_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.vouch_num.DataPropertyName = "vouch_num"
        Me.vouch_num.HeaderText = "Voucher Num"
        Me.vouch_num.Name = "vouch_num"
        Me.vouch_num.ReadOnly = True
        Me.vouch_num.Width = 97
        '
        'Screen_nam
        '
        Me.Screen_nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Screen_nam.DataPropertyName = "Screen_nam"
        Me.Screen_nam.HeaderText = "Screen Name"
        Me.Screen_nam.Name = "Screen_nam"
        Me.Screen_nam.ReadOnly = True
        Me.Screen_nam.Width = 97
        '
        'dt_tbe_pd
        '
        Me.dt_tbe_pd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dt_tbe_pd.DataPropertyName = "dt_tbe_pd"
        Me.dt_tbe_pd.HeaderText = "Pay Date"
        Me.dt_tbe_pd.Name = "dt_tbe_pd"
        Me.dt_tbe_pd.ReadOnly = True
        Me.dt_tbe_pd.Width = 75
        '
        'disc_amt
        '
        Me.disc_amt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.disc_amt.DataPropertyName = "disc_amt"
        Me.disc_amt.HeaderText = "Discount"
        Me.disc_amt.Name = "disc_amt"
        Me.disc_amt.ReadOnly = True
        Me.disc_amt.Width = 74
        '
        'vouch_amt
        '
        Me.vouch_amt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.vouch_amt.DataPropertyName = "vouch_amt"
        Me.vouch_amt.HeaderText = "Amount"
        Me.vouch_amt.Name = "vouch_amt"
        Me.vouch_amt.ReadOnly = True
        Me.vouch_amt.Width = 69
        '
        'Edit
        '
        Me.Edit.BackColor = System.Drawing.SystemColors.Control
        Me.Edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.Edit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Edit.Location = New System.Drawing.Point(504, 137)
        Me.Edit.Name = "Edit"
        Me.Edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Edit.Size = New System.Drawing.Size(73, 49)
        Me.Edit.TabIndex = 8
        Me.Edit.Text = "Edit"
        Me.Edit.UseVisualStyleBackColor = False
        '
        'addacct
        '
        Me.addacct.BackColor = System.Drawing.SystemColors.Control
        Me.addacct.Cursor = System.Windows.Forms.Cursors.Default
        Me.addacct.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addacct.ForeColor = System.Drawing.SystemColors.ControlText
        Me.addacct.Location = New System.Drawing.Point(504, 73)
        Me.addacct.Name = "addacct"
        Me.addacct.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.addacct.Size = New System.Drawing.Size(73, 49)
        Me.addacct.TabIndex = 9
        Me.addacct.Text = "Add"
        Me.addacct.UseVisualStyleBackColor = False
        '
        'apvch_ed1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(632, 554)
        Me.ControlBox = False
        Me.Controls.Add(Me.Edit)
        Me.Controls.Add(Me.addacct)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(114, 114)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "apvch_ed1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Voucher Edit1 Selection Form"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents vouch_num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Screen_nam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dt_tbe_pd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disc_amt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vouch_amt As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents Edit As System.Windows.Forms.Button
    Public WithEvents addacct As System.Windows.Forms.Button
#End Region 
End Class