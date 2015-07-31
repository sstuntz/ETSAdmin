<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmglbal1
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
    Public WithEvents PrintBal As System.Windows.Forms.Button
    Public WithEvents CalcBegBal As System.Windows.Forms.Button
    Public WithEvents _txtfields_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_0 As System.Windows.Forms.TextBox
    Public WithEvents Cancel As System.Windows.Forms.Button
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
        Me.PrintBal = New System.Windows.Forms.Button
        Me.CalcBegBal = New System.Windows.Forms.Button
        Me._txtfields_2 = New System.Windows.Forms.TextBox
        Me._txtfields_1 = New System.Windows.Forms.TextBox
        Me._txtfields_0 = New System.Windows.Forms.TextBox
        Me.Cancel = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtfields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Acct_num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Acct_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cr_dr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cur_beg = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.txtfields, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PrintBal
        '
        Me.PrintBal.BackColor = System.Drawing.SystemColors.Control
        Me.PrintBal.Cursor = System.Windows.Forms.Cursors.Default
        Me.PrintBal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintBal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PrintBal.Location = New System.Drawing.Point(224, 352)
        Me.PrintBal.Name = "PrintBal"
        Me.PrintBal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PrintBal.Size = New System.Drawing.Size(169, 25)
        Me.PrintBal.TabIndex = 13
        Me.PrintBal.Text = "Print Beg Bal Report"
        Me.PrintBal.UseVisualStyleBackColor = False
        '
        'CalcBegBal
        '
        Me.CalcBegBal.BackColor = System.Drawing.SystemColors.Control
        Me.CalcBegBal.Cursor = System.Windows.Forms.Cursors.Default
        Me.CalcBegBal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalcBegBal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CalcBegBal.Location = New System.Drawing.Point(296, 312)
        Me.CalcBegBal.Name = "CalcBegBal"
        Me.CalcBegBal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CalcBegBal.Size = New System.Drawing.Size(209, 25)
        Me.CalcBegBal.TabIndex = 12
        Me.CalcBegBal.Text = "Cal Beg Bal Total"
        Me.CalcBegBal.UseVisualStyleBackColor = False
        '
        '_txtfields_2
        '
        Me._txtfields_2.AcceptsReturn = True
        Me._txtfields_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_2.Enabled = False
        Me._txtfields_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_2, CType(2, Short))
        Me._txtfields_2.Location = New System.Drawing.Point(400, 280)
        Me._txtfields_2.MaxLength = 0
        Me._txtfields_2.Name = "_txtfields_2"
        Me._txtfields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_2.Size = New System.Drawing.Size(137, 20)
        Me._txtfields_2.TabIndex = 5
        Me._txtfields_2.Tag = "heading_1"
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
        Me._txtfields_1.Location = New System.Drawing.Point(120, 312)
        Me._txtfields_1.MaxLength = 0
        Me._txtfields_1.Name = "_txtfields_1"
        Me._txtfields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_1.Size = New System.Drawing.Size(105, 20)
        Me._txtfields_1.TabIndex = 4
        Me._txtfields_1.Tag = "cur_beg"
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
        Me._txtfields_0.Location = New System.Drawing.Point(120, 280)
        Me._txtfields_0.MaxLength = 0
        Me._txtfields_0.Name = "_txtfields_0"
        Me._txtfields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_0.Size = New System.Drawing.Size(105, 20)
        Me._txtfields_0.TabIndex = 3
        Me._txtfields_0.Tag = "acct_num"
        Me._txtfields_0.Text = " "
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(520, 0)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(97, 25)
        Me.Cancel.TabIndex = 0
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(288, 280)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Beg Bal Total"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(489, 17)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "You can Click on Calc Beg Bal Total anytime.  When done this should be zero(0)."
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(505, 17)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Enter the amount of the beginning balance. Some items are a NEGATIVE amount!"
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
        Me.Label6.Size = New System.Drawing.Size(457, 25)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "To EDIT a record,  select a record from the grid."
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 312)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "cur_beg"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 280)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "acct_num"
        '
        'txtfields
        '
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Acct_num, Me.Acct_desc, Me.cr_dr, Me.cur_beg})
        Me.DataGridView1.Location = New System.Drawing.Point(19, 76)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(568, 179)
        Me.DataGridView1.TabIndex = 42
        '
        'Acct_num
        '
        Me.Acct_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Acct_num.DataPropertyName = "Acct_num"
        Me.Acct_num.HeaderText = "Acct Number"
        Me.Acct_num.Name = "Acct_num"
        Me.Acct_num.ReadOnly = True
        Me.Acct_num.Width = 103
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
        'cr_dr
        '
        Me.cr_dr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.cr_dr.DataPropertyName = "cr_dr"
        Me.cr_dr.HeaderText = "Credit/Debit"
        Me.cr_dr.Name = "cr_dr"
        Me.cr_dr.ReadOnly = True
        Me.cr_dr.Width = 97
        '
        'cur_beg
        '
        Me.cur_beg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.cur_beg.DataPropertyName = "cur_beg"
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.cur_beg.DefaultCellStyle = DataGridViewCellStyle1
        Me.cur_beg.HeaderText = "Beginning"
        Me.cur_beg.Name = "cur_beg"
        Me.cur_beg.ReadOnly = True
        Me.cur_beg.Width = 87
        '
        'frmglbal1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(632, 473)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.PrintBal)
        Me.Controls.Add(Me.CalcBegBal)
        Me.Controls.Add(Me._txtfields_2)
        Me.Controls.Add(Me._txtfields_1)
        Me.Controls.Add(Me._txtfields_0)
        Me.Controls.Add(Me.Cancel)
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
        Me.Name = "frmglbal1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "General Ledger - Enter Beginning Balances"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.txtfields, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Acct_num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Acct_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cr_dr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cur_beg As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class