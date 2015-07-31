<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmglalloc2
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
	Public WithEvents cancel As System.Windows.Forms.Button
	Public WithEvents fac_tot As System.Windows.Forms.TextBox
	Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents _txtfields_3 As System.Windows.Forms.TextBox
    Public WithEvents Update1 As System.Windows.Forms.Button
    Public WithEvents _txtfields_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_0 As System.Windows.Forms.TextBox
    Public WithEvents addacct As System.Windows.Forms.Button
    Public WithEvents Delete As System.Windows.Forms.Button
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtfields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cancel = New System.Windows.Forms.Button
        Me.fac_tot = New System.Windows.Forms.TextBox
        Me.Command2 = New System.Windows.Forms.Button
        Me._txtfields_3 = New System.Windows.Forms.TextBox
        Me.Update1 = New System.Windows.Forms.Button
        Me._txtfields_2 = New System.Windows.Forms.TextBox
        Me._txtfields_1 = New System.Windows.Forms.TextBox
        Me._txtfields_0 = New System.Windows.Forms.TextBox
        Me.addacct = New System.Windows.Forms.Button
        Me.Delete = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtfields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.acct_num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acct_only = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Acct_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.factor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Table = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acct_pgm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acct_dpt = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.txtfields, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cancel
        '
        Me.cancel.BackColor = System.Drawing.SystemColors.Control
        Me.cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cancel.Location = New System.Drawing.Point(512, 8)
        Me.cancel.Name = "cancel"
        Me.cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cancel.Size = New System.Drawing.Size(89, 25)
        Me.cancel.TabIndex = 20
        Me.cancel.Text = "Cancel"
        Me.cancel.UseVisualStyleBackColor = False
        '
        'fac_tot
        '
        Me.fac_tot.AcceptsReturn = True
        Me.fac_tot.BackColor = System.Drawing.SystemColors.Window
        Me.fac_tot.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.fac_tot.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fac_tot.ForeColor = System.Drawing.SystemColors.WindowText
        Me.fac_tot.Location = New System.Drawing.Point(529, 514)
        Me.fac_tot.MaxLength = 0
        Me.fac_tot.Name = "fac_tot"
        Me.fac_tot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fac_tot.Size = New System.Drawing.Size(57, 20)
        Me.fac_tot.TabIndex = 19
        Me.fac_tot.Text = " "
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(676, 252)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(193, 25)
        Me.Command2.TabIndex = 18
        Me.Command2.Text = "Print Allocation Report"
        Me.Command2.UseVisualStyleBackColor = False
        '
        '_txtfields_3
        '
        Me._txtfields_3.AcceptsReturn = True
        Me._txtfields_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_3, CType(3, Short))
        Me._txtfields_3.Location = New System.Drawing.Point(312, 514)
        Me._txtfields_3.MaxLength = 0
        Me._txtfields_3.Name = "_txtfields_3"
        Me._txtfields_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_3.Size = New System.Drawing.Size(33, 20)
        Me._txtfields_3.TabIndex = 3
        Me._txtfields_3.Tag = "table"
        Me._txtfields_3.Text = " "
        '
        'Update1
        '
        Me.Update1.BackColor = System.Drawing.SystemColors.Control
        Me.Update1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Update1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Update1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Update1.Location = New System.Drawing.Point(692, 492)
        Me.Update1.Name = "Update1"
        Me.Update1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Update1.Size = New System.Drawing.Size(89, 25)
        Me.Update1.TabIndex = 4
        Me.Update1.Text = "Update"
        Me.Update1.UseVisualStyleBackColor = False
        '
        '_txtfields_2
        '
        Me._txtfields_2.AcceptsReturn = True
        Me._txtfields_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_2, CType(2, Short))
        Me._txtfields_2.Location = New System.Drawing.Point(336, 482)
        Me._txtfields_2.MaxLength = 0
        Me._txtfields_2.Name = "_txtfields_2"
        Me._txtfields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_2.Size = New System.Drawing.Size(241, 20)
        Me._txtfields_2.TabIndex = 5
        Me._txtfields_2.Tag = "desc"
        Me._txtfields_2.Text = " "
        '
        '_txtfields_1
        '
        Me._txtfields_1.AcceptsReturn = True
        Me._txtfields_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_1, CType(1, Short))
        Me._txtfields_1.Location = New System.Drawing.Point(120, 514)
        Me._txtfields_1.MaxLength = 0
        Me._txtfields_1.Name = "_txtfields_1"
        Me._txtfields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_1.Size = New System.Drawing.Size(65, 20)
        Me._txtfields_1.TabIndex = 2
        Me._txtfields_1.Tag = "factor"
        Me._txtfields_1.Text = " "
        '
        '_txtfields_0
        '
        Me._txtfields_0.AcceptsReturn = True
        Me._txtfields_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_0, CType(0, Short))
        Me._txtfields_0.Location = New System.Drawing.Point(120, 482)
        Me._txtfields_0.MaxLength = 0
        Me._txtfields_0.Name = "_txtfields_0"
        Me._txtfields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_0.Size = New System.Drawing.Size(97, 20)
        Me._txtfields_0.TabIndex = 1
        Me._txtfields_0.Tag = "acct_num"
        Me._txtfields_0.Text = " "
        '
        'addacct
        '
        Me.addacct.BackColor = System.Drawing.SystemColors.Control
        Me.addacct.Cursor = System.Windows.Forms.Cursors.Default
        Me.addacct.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addacct.ForeColor = System.Drawing.SystemColors.ControlText
        Me.addacct.Location = New System.Drawing.Point(676, 148)
        Me.addacct.Name = "addacct"
        Me.addacct.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.addacct.Size = New System.Drawing.Size(73, 25)
        Me.addacct.TabIndex = 0
        Me.addacct.Text = "Add"
        Me.addacct.UseVisualStyleBackColor = False
        '
        'Delete
        '
        Me.Delete.BackColor = System.Drawing.SystemColors.Control
        Me.Delete.Cursor = System.Windows.Forms.Cursors.Default
        Me.Delete.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Delete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Delete.Location = New System.Drawing.Point(676, 203)
        Me.Delete.Name = "Delete"
        Me.Delete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Delete.Size = New System.Drawing.Size(97, 25)
        Me.Delete.TabIndex = 9
        Me.Delete.Text = "Delete"
        Me.Delete.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(397, 514)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(105, 33)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Total of factors should be zero."
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(248, 514)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(49, 17)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Table"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(248, 482)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Acct Desc"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(489, 17)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Be sure to Verify all data entry.  The DELETE button will delete records."
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(577, 17)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "To ADD a record, first Select the ADD button. To EDIT a record,  select a record " & _
            "from the grid."
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(457, 33)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "GL Account# must be setup for the accounts to be allocated. Be sure to use the sa" & _
            "me 4 digit  acct_only number for the group."
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(32, 514)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "factor"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(32, 482)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "ACCT NUM"
        '
        'txtfields
        '
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.acct_num, Me.acct_only, Me.Acct_desc, Me.factor, Me.amount, Me.Table, Me.acct_pgm, Me.acct_dpt})
        Me.DataGridView1.Location = New System.Drawing.Point(26, 104)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(566, 337)
        Me.DataGridView1.TabIndex = 21
        '
        'acct_num
        '
        Me.acct_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.acct_num.DataPropertyName = "acct_num"
        Me.acct_num.HeaderText = "Acct Num"
        Me.acct_num.Name = "acct_num"
        Me.acct_num.ReadOnly = True
        Me.acct_num.Width = 84
        '
        'acct_only
        '
        Me.acct_only.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.acct_only.DataPropertyName = "acct_only"
        Me.acct_only.HeaderText = "Acct Only"
        Me.acct_only.Name = "acct_only"
        Me.acct_only.ReadOnly = True
        Me.acct_only.Width = 83
        '
        'Acct_desc
        '
        Me.Acct_desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Acct_desc.DataPropertyName = "Acct_desc"
        Me.Acct_desc.HeaderText = "Description"
        Me.Acct_desc.Name = "Acct_desc"
        Me.Acct_desc.ReadOnly = True
        Me.Acct_desc.Width = 95
        '
        'factor
        '
        Me.factor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.factor.DataPropertyName = "factor"
        DataGridViewCellStyle1.Format = "N4"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.factor.DefaultCellStyle = DataGridViewCellStyle1
        Me.factor.HeaderText = "Factor"
        Me.factor.Name = "factor"
        Me.factor.ReadOnly = True
        Me.factor.Width = 66
        '
        'amount
        '
        Me.amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.amount.DataPropertyName = "amount"
        Me.amount.HeaderText = "Amount"
        Me.amount.Name = "amount"
        Me.amount.ReadOnly = True
        Me.amount.Width = 76
        '
        'Table
        '
        Me.Table.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Table.DataPropertyName = "Table"
        Me.Table.HeaderText = "Table"
        Me.Table.Name = "Table"
        Me.Table.ReadOnly = True
        Me.Table.Width = 61
        '
        'acct_pgm
        '
        Me.acct_pgm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.acct_pgm.DataPropertyName = "acct_pgm"
        Me.acct_pgm.HeaderText = "Program"
        Me.acct_pgm.Name = "acct_pgm"
        Me.acct_pgm.ReadOnly = True
        Me.acct_pgm.Visible = False
        '
        'acct_dpt
        '
        Me.acct_dpt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.acct_dpt.DataPropertyName = "acct_dpt"
        Me.acct_dpt.HeaderText = "Dept"
        Me.acct_dpt.Name = "acct_dpt"
        Me.acct_dpt.ReadOnly = True
        Me.acct_dpt.Visible = False
        '
        'frmglalloc2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(900, 590)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.fac_tot)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me._txtfields_3)
        Me.Controls.Add(Me.Update1)
        Me.Controls.Add(Me._txtfields_2)
        Me.Controls.Add(Me._txtfields_1)
        Me.Controls.Add(Me._txtfields_0)
        Me.Controls.Add(Me.addacct)
        Me.Controls.Add(Me.Delete)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Location = New System.Drawing.Point(21, 40)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmglalloc2"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "General Ledger - Allocation Table Set up"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.txtfields, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents acct_num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acct_only As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Acct_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents factor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Table As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acct_pgm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acct_dpt As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class