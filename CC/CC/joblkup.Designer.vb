<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class jobnumlookup
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
    Public WithEvents txtfields As System.Windows.Forms.TextBox
	Public WithEvents edit As System.Windows.Forms.Button
	Public WithEvents addacct As System.Windows.Forms.Button
	Public WithEvents Cancel As System.Windows.Forms.Button
	Public WithEvents Accept As System.Windows.Forms.Button
	Public WithEvents Label2 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtfields = New System.Windows.Forms.TextBox
        Me.edit = New System.Windows.Forms.Button
        Me.addacct = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.Accept = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.JobNumgrid = New System.Windows.Forms.DataGridView
        Me.JobNum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JobDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pay_class = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.JobNumgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtfields
        '
        Me.txtfields.AcceptsReturn = True
        Me.txtfields.BackColor = System.Drawing.SystemColors.Window
        Me.txtfields.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtfields.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfields.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.Location = New System.Drawing.Point(360, 80)
        Me.txtfields.MaxLength = 6
        Me.txtfields.Name = "txtfields"
        Me.txtfields.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtfields.Size = New System.Drawing.Size(65, 20)
        Me.txtfields.TabIndex = 5
        Me.txtfields.Text = " "
        '
        'edit
        '
        Me.edit.BackColor = System.Drawing.SystemColors.Control
        Me.edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.edit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edit.Location = New System.Drawing.Point(360, 282)
        Me.edit.Name = "edit"
        Me.edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edit.Size = New System.Drawing.Size(73, 49)
        Me.edit.TabIndex = 1
        Me.edit.Text = "Edit"
        Me.edit.UseVisualStyleBackColor = False
        '
        'addacct
        '
        Me.addacct.BackColor = System.Drawing.SystemColors.Control
        Me.addacct.Cursor = System.Windows.Forms.Cursors.Default
        Me.addacct.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addacct.ForeColor = System.Drawing.SystemColors.ControlText
        Me.addacct.Location = New System.Drawing.Point(360, 205)
        Me.addacct.Name = "addacct"
        Me.addacct.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.addacct.Size = New System.Drawing.Size(73, 49)
        Me.addacct.TabIndex = 2
        Me.addacct.Text = "Add"
        Me.addacct.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(368, 0)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(97, 25)
        Me.Cancel.TabIndex = 3
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Accept
        '
        Me.Accept.BackColor = System.Drawing.SystemColors.Control
        Me.Accept.Cursor = System.Windows.Forms.Cursors.Default
        Me.Accept.Enabled = False
        Me.Accept.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Accept.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Accept.Location = New System.Drawing.Point(336, 133)
        Me.Accept.Name = "Accept"
        Me.Accept.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Accept.Size = New System.Drawing.Size(129, 49)
        Me.Accept.TabIndex = 0
        Me.Accept.Text = "Use Selected Name"
        Me.Accept.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(346, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(119, 29)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Enter a Job Num to Locate"
        '
        'JobNumgrid
        '
        Me.JobNumgrid.AllowUserToAddRows = False
        Me.JobNumgrid.AllowUserToDeleteRows = False
        Me.JobNumgrid.AllowUserToOrderColumns = True
        Me.JobNumgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.JobNumgrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JobNum, Me.JobDesc, Me.Pay_class})
        Me.JobNumgrid.Location = New System.Drawing.Point(12, 48)
        Me.JobNumgrid.Name = "JobNumgrid"
        Me.JobNumgrid.ReadOnly = True
        Me.JobNumgrid.Size = New System.Drawing.Size(310, 375)
        Me.JobNumgrid.TabIndex = 8
        '
        'JobNum
        '
        Me.JobNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.JobNum.DataPropertyName = "Job_num"
        Me.JobNum.HeaderText = "Job Num"
        Me.JobNum.Name = "JobNum"
        Me.JobNum.ReadOnly = True
        Me.JobNum.Width = 73
        '
        'JobDesc
        '
        Me.JobDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.JobDesc.DataPropertyName = "Job_Desc"
        Me.JobDesc.HeaderText = "Job Description"
        Me.JobDesc.Name = "JobDesc"
        Me.JobDesc.ReadOnly = True
        Me.JobDesc.Width = 106
        '
        'Pay_class
        '
        Me.Pay_class.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Pay_class.DataPropertyName = "pay_class"
        Me.Pay_class.HeaderText = "Pay Class"
        Me.Pay_class.Name = "Pay_class"
        Me.Pay_class.ReadOnly = True
        Me.Pay_class.Width = 80
        '
        'jobnumlookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(480, 461)
        Me.ControlBox = False
        Me.Controls.Add(Me.JobNumgrid)
        Me.Controls.Add(Me.txtfields)
        Me.Controls.Add(Me.edit)
        Me.Controls.Add(Me.addacct)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Accept)
        Me.Controls.Add(Me.Label2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(74, 71)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "jobnumlookup"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Job Number Look up"
        CType(Me.JobNumgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents JobNumgrid As System.Windows.Forms.DataGridView
    Friend WithEvents JobNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JobDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pay_class As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class