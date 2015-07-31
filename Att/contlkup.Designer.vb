<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class contnumlookup
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
    Public WithEvents set_closed_flag As System.Windows.Forms.Button
	Public WithEvents Accept As System.Windows.Forms.Button
	Public WithEvents Cancel As System.Windows.Forms.Button
	Public WithEvents addacct As System.Windows.Forms.Button
	Public WithEvents edit As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.set_closed_flag = New System.Windows.Forms.Button
        Me.Accept = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.addacct = New System.Windows.Forms.Button
        Me.edit = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ShowAllContracts = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'set_closed_flag
        '
        Me.set_closed_flag.BackColor = System.Drawing.SystemColors.Control
        Me.set_closed_flag.Cursor = System.Windows.Forms.Cursors.Default
        Me.set_closed_flag.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.set_closed_flag.ForeColor = System.Drawing.SystemColors.ControlText
        Me.set_closed_flag.Location = New System.Drawing.Point(20, 389)
        Me.set_closed_flag.Name = "set_closed_flag"
        Me.set_closed_flag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.set_closed_flag.Size = New System.Drawing.Size(180, 42)
        Me.set_closed_flag.TabIndex = 9
        Me.set_closed_flag.Text = "Click here to make highlighted contract shown inactive"
        Me.set_closed_flag.UseVisualStyleBackColor = False
        '
        'Accept
        '
        Me.Accept.BackColor = System.Drawing.SystemColors.Control
        Me.Accept.Cursor = System.Windows.Forms.Cursors.Default
        Me.Accept.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Accept.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Accept.Location = New System.Drawing.Point(535, 403)
        Me.Accept.Name = "Accept"
        Me.Accept.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Accept.Size = New System.Drawing.Size(137, 49)
        Me.Accept.TabIndex = 1
        Me.Accept.Text = "Use Selected Number"
        Me.Accept.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(566, 6)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(97, 25)
        Me.Cancel.TabIndex = 4
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'addacct
        '
        Me.addacct.BackColor = System.Drawing.SystemColors.Control
        Me.addacct.Cursor = System.Windows.Forms.Cursors.Default
        Me.addacct.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addacct.ForeColor = System.Drawing.SystemColors.ControlText
        Me.addacct.Location = New System.Drawing.Point(261, 403)
        Me.addacct.Name = "addacct"
        Me.addacct.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.addacct.Size = New System.Drawing.Size(73, 49)
        Me.addacct.TabIndex = 3
        Me.addacct.Text = "Add"
        Me.addacct.UseVisualStyleBackColor = False
        '
        'edit
        '
        Me.edit.BackColor = System.Drawing.SystemColors.Control
        Me.edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.edit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edit.Location = New System.Drawing.Point(416, 403)
        Me.edit.Name = "edit"
        Me.edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edit.Size = New System.Drawing.Size(73, 49)
        Me.edit.TabIndex = 2
        Me.edit.Text = "Edit"
        Me.edit.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(20, 37)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(665, 324)
        Me.DataGridView1.TabIndex = 11
        '
        'ShowAllContracts
        '
        Me.ShowAllContracts.Location = New System.Drawing.Point(26, 459)
        Me.ShowAllContracts.Name = "ShowAllContracts"
        Me.ShowAllContracts.Size = New System.Drawing.Size(173, 37)
        Me.ShowAllContracts.TabIndex = 12
        Me.ShowAllContracts.Text = "Show All Contracts"
        Me.ShowAllContracts.UseVisualStyleBackColor = True
        Me.ShowAllContracts.Visible = False
        '
        'contnumlookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(707, 520)
        Me.ControlBox = False
        Me.Controls.Add(Me.ShowAllContracts)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.set_closed_flag)
        Me.Controls.Add(Me.Accept)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.addacct)
        Me.Controls.Add(Me.edit)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(55, 98)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "contnumlookup"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Contract Lookup"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ShowAllContracts As System.Windows.Forms.Button
#End Region 
End Class