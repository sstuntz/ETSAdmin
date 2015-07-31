<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmed_chks
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
	Public WithEvents edit_amt_vis As System.Windows.Forms.TextBox
	Public WithEvents numcks As System.Windows.Forms.TextBox
    Public WithEvents Cont_process As System.Windows.Forms.Button
	Public WithEvents baldue As System.Windows.Forms.TextBox
	Public WithEvents Cancel As System.Windows.Forms.Button
    Public WithEvents cmdUpdate As System.Windows.Forms.Button
	Public WithEvents cmdDelete As System.Windows.Forms.Button
    Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.edit_amt_vis = New System.Windows.Forms.TextBox
        Me.numcks = New System.Windows.Forms.TextBox
        Me.Cont_process = New System.Windows.Forms.Button
        Me.baldue = New System.Windows.Forms.TextBox
        Me.Cancel = New System.Windows.Forms.Button
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.vouch_num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.name_key = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Screen_nam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vouch_amt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bal_due = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.n_chk_amt = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'edit_amt_vis
        '
        Me.edit_amt_vis.AcceptsReturn = True
        Me.edit_amt_vis.BackColor = System.Drawing.SystemColors.Window
        Me.edit_amt_vis.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.edit_amt_vis.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit_amt_vis.ForeColor = System.Drawing.SystemColors.WindowText
        Me.edit_amt_vis.Location = New System.Drawing.Point(29, 431)
        Me.edit_amt_vis.MaxLength = 0
        Me.edit_amt_vis.Name = "edit_amt_vis"
        Me.edit_amt_vis.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edit_amt_vis.Size = New System.Drawing.Size(65, 20)
        Me.edit_amt_vis.TabIndex = 0
        '
        'numcks
        '
        Me.numcks.AcceptsReturn = True
        Me.numcks.BackColor = System.Drawing.SystemColors.Window
        Me.numcks.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.numcks.Enabled = False
        Me.numcks.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numcks.ForeColor = System.Drawing.SystemColors.WindowText
        Me.numcks.Location = New System.Drawing.Point(420, 430)
        Me.numcks.MaxLength = 0
        Me.numcks.Name = "numcks"
        Me.numcks.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.numcks.Size = New System.Drawing.Size(97, 20)
        Me.numcks.TabIndex = 10
        Me.numcks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cont_process
        '
        Me.Cont_process.BackColor = System.Drawing.SystemColors.Control
        Me.Cont_process.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cont_process.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cont_process.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cont_process.Location = New System.Drawing.Point(416, 479)
        Me.Cont_process.Name = "Cont_process"
        Me.Cont_process.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cont_process.Size = New System.Drawing.Size(169, 33)
        Me.Cont_process.TabIndex = 2
        Me.Cont_process.Text = "Edit Done - Continue Processing"
        Me.Cont_process.UseVisualStyleBackColor = False
        '
        'baldue
        '
        Me.baldue.AcceptsReturn = True
        Me.baldue.BackColor = System.Drawing.SystemColors.Window
        Me.baldue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.baldue.Enabled = False
        Me.baldue.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.baldue.ForeColor = System.Drawing.SystemColors.WindowText
        Me.baldue.Location = New System.Drawing.Point(421, 397)
        Me.baldue.MaxLength = 15
        Me.baldue.Name = "baldue"
        Me.baldue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.baldue.Size = New System.Drawing.Size(96, 20)
        Me.baldue.TabIndex = 8
        Me.baldue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(526, 0)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(65, 25)
        Me.Cancel.TabIndex = 7
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUpdate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUpdate.Location = New System.Drawing.Point(114, 431)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUpdate.Size = New System.Drawing.Size(65, 25)
        Me.cmdUpdate.TabIndex = 1
        Me.cmdUpdate.Text = "Save"
        Me.cmdUpdate.UseVisualStyleBackColor = False
        '
        'cmdDelete
        '
        Me.cmdDelete.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDelete.Location = New System.Drawing.Point(24, 479)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDelete.Size = New System.Drawing.Size(251, 33)
        Me.cmdDelete.TabIndex = 5
        Me.cmdDelete.Text = "Delete Selected Record from this group ."
        Me.cmdDelete.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(32, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(369, 17)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Click on the Grid to Recalculate Balance to be paid."
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(30, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(443, 34)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "This is a list of all Unpaid Vouchers you have selected.  You can select a vouche" & _
            "r and change the amount to be paid or you can select a voucher and delete it fro" & _
            "m this group."
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(26, 387)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(173, 37)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "ONLY use these  to change the amount to be paid."
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(260, 432)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(145, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Number of vouchers to pay"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(261, 400)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Balance to be paid"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.vouch_num, Me.name_key, Me.Screen_nam, Me.Vouch_amt, Me.Bal_due, Me.n_chk_amt})
        Me.DataGridView1.Location = New System.Drawing.Point(33, 86)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(603, 271)
        Me.DataGridView1.TabIndex = 15
        '
        'vouch_num
        '
        Me.vouch_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.vouch_num.DataPropertyName = "vouch_num"
        Me.vouch_num.HeaderText = "Voucher#"
        Me.vouch_num.Name = "vouch_num"
        Me.vouch_num.ReadOnly = True
        Me.vouch_num.Width = 79
        '
        'name_key
        '
        Me.name_key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.name_key.DataPropertyName = "name_key"
        Me.name_key.HeaderText = "Name Key"
        Me.name_key.Name = "name_key"
        Me.name_key.ReadOnly = True
        Me.name_key.Width = 81
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
        'Vouch_amt
        '
        Me.Vouch_amt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Vouch_amt.DataPropertyName = "Vouch_amt"
        DataGridViewCellStyle1.NullValue = "c2"
        Me.Vouch_amt.DefaultCellStyle = DataGridViewCellStyle1
        Me.Vouch_amt.HeaderText = "Amount"
        Me.Vouch_amt.Name = "Vouch_amt"
        Me.Vouch_amt.ReadOnly = True
        Me.Vouch_amt.Width = 69
        '
        'Bal_due
        '
        Me.Bal_due.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Bal_due.DataPropertyName = "Bal_due"
        Me.Bal_due.HeaderText = "Balance Due"
        Me.Bal_due.Name = "Bal_due"
        Me.Bal_due.ReadOnly = True
        Me.Bal_due.Width = 93
        '
        'n_chk_amt
        '
        Me.n_chk_amt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.n_chk_amt.DataPropertyName = "n_chk_amt"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.n_chk_amt.DefaultCellStyle = DataGridViewCellStyle2
        Me.n_chk_amt.HeaderText = "Net Amt"
        Me.n_chk_amt.Name = "n_chk_amt"
        Me.n_chk_amt.ReadOnly = True
        Me.n_chk_amt.Width = 69
        '
        'frmed_chks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(753, 585)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.edit_amt_vis)
        Me.Controls.Add(Me.numcks)
        Me.Controls.Add(Me.Cont_process)
        Me.Controls.Add(Me.baldue)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(30, 31)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmed_chks"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Editing Vouchers to be Paid."
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents vouch_num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents name_key As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Screen_nam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vouch_amt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bal_due As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents n_chk_amt As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class