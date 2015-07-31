<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class apalloc
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
	Public WithEvents _txtfields_1 As System.Windows.Forms.TextBox
	Public WithEvents nextloc As System.Windows.Forms.Button
	Public WithEvents tot_alloc As System.Windows.Forms.TextBox
	Public WithEvents Save As System.Windows.Forms.Button
	Public WithEvents in_factor As System.Windows.Forms.TextBox
	Public WithEvents in_loc As System.Windows.Forms.TextBox
	Public WithEvents _txtfields_0 As System.Windows.Forms.TextBox
    Public WithEvents Cancel As System.Windows.Forms.Button
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents txtfields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._txtfields_1 = New System.Windows.Forms.TextBox
        Me.nextloc = New System.Windows.Forms.Button
        Me.tot_alloc = New System.Windows.Forms.TextBox
        Me.Save = New System.Windows.Forms.Button
        Me.in_factor = New System.Windows.Forms.TextBox
        Me.in_loc = New System.Windows.Forms.TextBox
        Me._txtfields_0 = New System.Windows.Forms.TextBox
        Me.Cancel = New System.Windows.Forms.Button
        Me._Label1_1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me._Label1_0 = New System.Windows.Forms.Label
        Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.txtfields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.AcctNum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Factor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SaveEntry = New System.Windows.Forms.Button
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfields, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_txtfields_1
        '
        Me._txtfields_1.AcceptsReturn = True
        Me._txtfields_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_1, CType(1, Short))
        Me._txtfields_1.Location = New System.Drawing.Point(248, 40)
        Me._txtfields_1.MaxLength = 25
        Me._txtfields_1.Name = "_txtfields_1"
        Me._txtfields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_1.Size = New System.Drawing.Size(184, 20)
        Me._txtfields_1.TabIndex = 1
        Me._txtfields_1.Tag = "descp"
        '
        'nextloc
        '
        Me.nextloc.BackColor = System.Drawing.SystemColors.Control
        Me.nextloc.Cursor = System.Windows.Forms.Cursors.Default
        Me.nextloc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nextloc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.nextloc.Location = New System.Drawing.Point(161, 477)
        Me.nextloc.Name = "nextloc"
        Me.nextloc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.nextloc.Size = New System.Drawing.Size(153, 41)
        Me.nextloc.TabIndex = 4
        Me.nextloc.Text = "Add an  Account Number"
        Me.nextloc.UseVisualStyleBackColor = False
        '
        'tot_alloc
        '
        Me.tot_alloc.AcceptsReturn = True
        Me.tot_alloc.BackColor = System.Drawing.SystemColors.Window
        Me.tot_alloc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tot_alloc.Enabled = False
        Me.tot_alloc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tot_alloc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tot_alloc.Location = New System.Drawing.Point(328, 389)
        Me.tot_alloc.MaxLength = 0
        Me.tot_alloc.Name = "tot_alloc"
        Me.tot_alloc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tot_alloc.Size = New System.Drawing.Size(81, 20)
        Me.tot_alloc.TabIndex = 11
        '
        'Save
        '
        Me.Save.BackColor = System.Drawing.SystemColors.Control
        Me.Save.Cursor = System.Windows.Forms.Cursors.Default
        Me.Save.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Save.Location = New System.Drawing.Point(401, 477)
        Me.Save.Name = "Save"
        Me.Save.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Save.Size = New System.Drawing.Size(81, 41)
        Me.Save.TabIndex = 5
        Me.Save.Text = "Save and Exit"
        Me.Save.UseVisualStyleBackColor = False
        '
        'in_factor
        '
        Me.in_factor.AcceptsReturn = True
        Me.in_factor.BackColor = System.Drawing.SystemColors.Window
        Me.in_factor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.in_factor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_factor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.in_factor.Location = New System.Drawing.Point(393, 430)
        Me.in_factor.MaxLength = 0
        Me.in_factor.Name = "in_factor"
        Me.in_factor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.in_factor.Size = New System.Drawing.Size(65, 20)
        Me.in_factor.TabIndex = 3
        Me.in_factor.Tag = "factor"
        '
        'in_loc
        '
        Me.in_loc.AcceptsReturn = True
        Me.in_loc.BackColor = System.Drawing.SystemColors.Window
        Me.in_loc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.in_loc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_loc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.in_loc.Location = New System.Drawing.Point(217, 428)
        Me.in_loc.MaxLength = 0
        Me.in_loc.Name = "in_loc"
        Me.in_loc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.in_loc.Size = New System.Drawing.Size(121, 20)
        Me.in_loc.TabIndex = 2
        Me.in_loc.Tag = "acct_num"
        '
        '_txtfields_0
        '
        Me._txtfields_0.AcceptsReturn = True
        Me._txtfields_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_0, CType(0, Short))
        Me._txtfields_0.Location = New System.Drawing.Point(249, 8)
        Me._txtfields_0.MaxLength = 20
        Me._txtfields_0.Name = "_txtfields_0"
        Me._txtfields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_0.Size = New System.Drawing.Size(144, 20)
        Me._txtfields_0.TabIndex = 0
        Me._txtfields_0.Tag = "AllocName"
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(512, 0)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(97, 25)
        Me.Cancel.TabIndex = 6
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        '_Label1_1
        '
        Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.SetIndex(Me._Label1_1, CType(1, Short))
        Me._Label1_1.Location = New System.Drawing.Point(128, 40)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(113, 17)
        Me._Label1_1.TabIndex = 13
        Me._Label1_1.Text = "Description (25 Char) "
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(124, 389)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(206, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Total Allocated - Must be 100%"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(353, 429)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(41, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Factor"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(89, 429)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(113, 18)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "ACCOUNT NUMBER"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(256, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(105, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Present Allocation"
        '
        '_Label1_0
        '
        Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.SetIndex(Me._Label1_0, CType(0, Short))
        Me._Label1_0.Location = New System.Drawing.Point(73, 8)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(157, 17)
        Me._Label1_0.TabIndex = 7
        Me._Label1_0.Text = "Name of allocation(20 Char)"
        '
        'txtfields
        '
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AcctNum, Me.Factor})
        Me.DataGridView1.Location = New System.Drawing.Point(187, 109)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(245, 254)
        Me.DataGridView1.TabIndex = 14
        '
        'AcctNum
        '
        Me.AcctNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.AcctNum.DataPropertyName = "acct_num"
        Me.AcctNum.HeaderText = "Account Number"
        Me.AcctNum.Name = "AcctNum"
        Me.AcctNum.ReadOnly = True
        Me.AcctNum.Width = 104
        '
        'Factor
        '
        Me.Factor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Factor.DataPropertyName = "factor"
        Me.Factor.HeaderText = "Factor"
        Me.Factor.Name = "Factor"
        Me.Factor.ReadOnly = True
        Me.Factor.Width = 63
        '
        'SaveEntry
        '
        Me.SaveEntry.Location = New System.Drawing.Point(505, 428)
        Me.SaveEntry.Name = "SaveEntry"
        Me.SaveEntry.Size = New System.Drawing.Size(75, 23)
        Me.SaveEntry.TabIndex = 15
        Me.SaveEntry.Text = "Save Entry"
        Me.SaveEntry.UseVisualStyleBackColor = True
        '
        'apalloc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(610, 573)
        Me.ControlBox = False
        Me.Controls.Add(Me.SaveEntry)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me._txtfields_1)
        Me.Controls.Add(Me.nextloc)
        Me.Controls.Add(Me.tot_alloc)
        Me.Controls.Add(Me.Save)
        Me.Controls.Add(Me.in_factor)
        Me.Controls.Add(Me.in_loc)
        Me.Controls.Add(Me._txtfields_0)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me._Label1_1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me._Label1_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(18, 36)
        Me.Name = "apalloc"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Allocation Table Set Up"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfields, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents AcctNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Factor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaveEntry As System.Windows.Forms.Button
#End Region 
End Class