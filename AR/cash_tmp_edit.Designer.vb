<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class ar_cash_edit_sel
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
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents bat_bal As System.Windows.Forms.TextBox
    Public WithEvents del As System.Windows.Forms.Button
	Public WithEvents Edit As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command1 = New System.Windows.Forms.Button
        Me.bat_bal = New System.Windows.Forms.TextBox
        Me.del = New System.Windows.Forms.Button
        Me.Edit = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(406, 358)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(170, 25)
        Me.Command1.TabIndex = 9
        Me.Command1.Text = "Print Reg Cash Edit Report"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'bat_bal
        '
        Me.bat_bal.AcceptsReturn = True
        Me.bat_bal.BackColor = System.Drawing.SystemColors.Window
        Me.bat_bal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.bat_bal.Enabled = False
        Me.bat_bal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bat_bal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.bat_bal.Location = New System.Drawing.Point(248, 361)
        Me.bat_bal.MaxLength = 0
        Me.bat_bal.Name = "bat_bal"
        Me.bat_bal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.bat_bal.Size = New System.Drawing.Size(97, 20)
        Me.bat_bal.TabIndex = 7
        '
        'del
        '
        Me.del.BackColor = System.Drawing.SystemColors.Control
        Me.del.Cursor = System.Windows.Forms.Cursors.Default
        Me.del.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.del.ForeColor = System.Drawing.SystemColors.ControlText
        Me.del.Location = New System.Drawing.Point(11, 395)
        Me.del.Name = "del"
        Me.del.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.del.Size = New System.Drawing.Size(180, 33)
        Me.del.TabIndex = 6
        Me.del.Text = "Delete entries from Batch"
        Me.del.UseVisualStyleBackColor = False
        '
        'Edit
        '
        Me.Edit.BackColor = System.Drawing.SystemColors.Control
        Me.Edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.Edit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Edit.Location = New System.Drawing.Point(355, 25)
        Me.Edit.Name = "Edit"
        Me.Edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Edit.Size = New System.Drawing.Size(174, 33)
        Me.Edit.TabIndex = 4
        Me.Edit.Text = "Edit selected Entry Number"
        Me.Edit.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(567, 2)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(68, 20)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.TabStop = False
        Me.cmdClose.Text = "Cancel "
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(143, 363)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(94, 18)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Balance of Batch:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(311, 38)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Select One Entry Num from the list to Edit. Then click button to right."
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(19, 66)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(596, 286)
        Me.DataGridView1.TabIndex = 13
        '
        'ar_cash_edit_sel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(673, 504)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.bat_bal)
        Me.Controls.Add(Me.del)
        Me.Controls.Add(Me.Edit)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(-3, 26)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ar_cash_edit_sel"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "AR Cash Receipts Entry Edit"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
#End Region 
End Class