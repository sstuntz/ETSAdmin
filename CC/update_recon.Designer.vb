<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class update_recon
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
    Public WithEvents ExitUpdateRecon As System.Windows.Forms.Button
    Public WithEvents Cancel As System.Windows.Forms.Button
    Public WithEvents Process As System.Windows.Forms.Button
    Public WithEvents Pr_num1 As System.Windows.Forms.TextBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ExitUpdateRecon = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.Process = New System.Windows.Forms.Button
        Me.Pr_num1 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ExitUpdateRecon
        '
        Me.ExitUpdateRecon.BackColor = System.Drawing.SystemColors.Control
        Me.ExitUpdateRecon.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExitUpdateRecon.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitUpdateRecon.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ExitUpdateRecon.Location = New System.Drawing.Point(200, 200)
        Me.ExitUpdateRecon.Name = "ExitUpdateRecon"
        Me.ExitUpdateRecon.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExitUpdateRecon.Size = New System.Drawing.Size(129, 25)
        Me.ExitUpdateRecon.TabIndex = 5
        Me.ExitUpdateRecon.Text = "Exit to Payroll Menu"
        Me.ExitUpdateRecon.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(386, 2)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(57, 22)
        Me.Cancel.TabIndex = 2
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Process
        '
        Me.Process.BackColor = System.Drawing.SystemColors.Control
        Me.Process.Cursor = System.Windows.Forms.Cursors.Default
        Me.Process.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Process.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Process.Location = New System.Drawing.Point(200, 136)
        Me.Process.Name = "Process"
        Me.Process.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Process.Size = New System.Drawing.Size(129, 25)
        Me.Process.TabIndex = 1
        Me.Process.Text = "Update to Recon"
        Me.Process.UseVisualStyleBackColor = False
        '
        'Pr_num1
        '
        Me.Pr_num1.AcceptsReturn = True
        Me.Pr_num1.BackColor = System.Drawing.SystemColors.Window
        Me.Pr_num1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Pr_num1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pr_num1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Pr_num1.Location = New System.Drawing.Point(248, 72)
        Me.Pr_num1.MaxLength = 0
        Me.Pr_num1.Name = "Pr_num1"
        Me.Pr_num1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Pr_num1.Size = New System.Drawing.Size(41, 20)
        Me.Pr_num1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(64, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(1, 3)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Label5"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(40, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(176, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Enter Payroll Number to update."
        '
        'update_recon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(446, 324)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExitUpdateRecon)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Process)
        Me.Controls.Add(Me.Pr_num1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(107, 81)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "update_recon"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Update Recon Table from Payroll"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class