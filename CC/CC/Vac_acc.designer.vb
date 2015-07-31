<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class vac_acc
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
	Public WithEvents cmdclose As System.Windows.Forms.Button
	Public WithEvents num_acc As System.Windows.Forms.TextBox
	Public WithEvents reset_Renamed As System.Windows.Forms.Button
	Public WithEvents upd_vac As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdclose = New System.Windows.Forms.Button
        Me.num_acc = New System.Windows.Forms.TextBox
        Me.reset_Renamed = New System.Windows.Forms.Button
        Me.upd_vac = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdclose
        '
        Me.cmdclose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdclose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdclose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdclose.Location = New System.Drawing.Point(368, 0)
        Me.cmdclose.Name = "cmdclose"
        Me.cmdclose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdclose.Size = New System.Drawing.Size(73, 25)
        Me.cmdclose.TabIndex = 4
        Me.cmdclose.Text = "Cancel"
        Me.cmdclose.UseVisualStyleBackColor = False
        '
        'num_acc
        '
        Me.num_acc.AcceptsReturn = True
        Me.num_acc.BackColor = System.Drawing.SystemColors.Window
        Me.num_acc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.num_acc.Enabled = False
        Me.num_acc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.num_acc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.num_acc.Location = New System.Drawing.Point(320, 64)
        Me.num_acc.MaxLength = 0
        Me.num_acc.Name = "num_acc"
        Me.num_acc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.num_acc.Size = New System.Drawing.Size(41, 25)
        Me.num_acc.TabIndex = 2
        '
        'reset_Renamed
        '
        Me.reset_Renamed.BackColor = System.Drawing.SystemColors.Control
        Me.reset_Renamed.Cursor = System.Windows.Forms.Cursors.Default
        Me.reset_Renamed.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reset_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
        Me.reset_Renamed.Location = New System.Drawing.Point(40, 184)
        Me.reset_Renamed.Name = "reset_Renamed"
        Me.reset_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.reset_Renamed.Size = New System.Drawing.Size(129, 41)
        Me.reset_Renamed.TabIndex = 1
        Me.reset_Renamed.Text = "Reset Vacation Accruals"
        Me.reset_Renamed.UseVisualStyleBackColor = False
        '
        'upd_vac
        '
        Me.upd_vac.BackColor = System.Drawing.SystemColors.Control
        Me.upd_vac.Cursor = System.Windows.Forms.Cursors.Default
        Me.upd_vac.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.upd_vac.ForeColor = System.Drawing.SystemColors.ControlText
        Me.upd_vac.Location = New System.Drawing.Point(264, 104)
        Me.upd_vac.Name = "upd_vac"
        Me.upd_vac.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.upd_vac.Size = New System.Drawing.Size(145, 38)
        Me.upd_vac.TabIndex = 0
        Me.upd_vac.Text = "Update Vacation Accruals"
        Me.upd_vac.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(50, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(240, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "This will be accrual Number for this year"
        '
        'vac_acc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(448, 343)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdclose)
        Me.Controls.Add(Me.num_acc)
        Me.Controls.Add(Me.reset_Renamed)
        Me.Controls.Add(Me.upd_vac)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(62, 82)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "vac_acc"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Vacation Accrual"
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class