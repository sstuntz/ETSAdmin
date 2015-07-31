<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class gl_close
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
	Public WithEvents prt_unposted As System.Windows.Forms.Button
	Public WithEvents mth_num As System.Windows.Forms.TextBox
	Public WithEvents mth_name As System.Windows.Forms.TextBox
	Public WithEvents close_gl As System.Windows.Forms.Button
    Public WithEvents _txtfields_0 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_1 As System.Windows.Forms.TextBox
    Public WithEvents cmdUpdate As System.Windows.Forms.Button
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
    Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents txtfields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command1 = New System.Windows.Forms.Button
        Me.prt_unposted = New System.Windows.Forms.Button
        Me.mth_num = New System.Windows.Forms.TextBox
        Me.mth_name = New System.Windows.Forms.TextBox
        Me.close_gl = New System.Windows.Forms.Button
        Me._txtfields_0 = New System.Windows.Forms.TextBox
        Me._txtfields_1 = New System.Windows.Forms.TextBox
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me._lblLabels_0 = New System.Windows.Forms.Label
        Me._lblLabels_1 = New System.Windows.Forms.Label
        Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.txtfields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfields, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(192, 360)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(145, 25)
        Me.Command1.TabIndex = 14
        Me.Command1.Text = "Exit This Screen"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'prt_unposted
        '
        Me.prt_unposted.BackColor = System.Drawing.SystemColors.Control
        Me.prt_unposted.Cursor = System.Windows.Forms.Cursors.Default
        Me.prt_unposted.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prt_unposted.ForeColor = System.Drawing.SystemColors.ControlText
        Me.prt_unposted.Location = New System.Drawing.Point(192, 312)
        Me.prt_unposted.Name = "prt_unposted"
        Me.prt_unposted.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.prt_unposted.Size = New System.Drawing.Size(153, 33)
        Me.prt_unposted.TabIndex = 13
        Me.prt_unposted.Text = "Print Unposted Entries"
        Me.prt_unposted.UseVisualStyleBackColor = False
        Me.prt_unposted.Visible = False
        '
        'mth_num
        '
        Me.mth_num.AcceptsReturn = True
        Me.mth_num.BackColor = System.Drawing.SystemColors.Window
        Me.mth_num.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.mth_num.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mth_num.ForeColor = System.Drawing.SystemColors.WindowText
        Me.mth_num.Location = New System.Drawing.Point(232, 144)
        Me.mth_num.MaxLength = 0
        Me.mth_num.Name = "mth_num"
        Me.mth_num.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.mth_num.Size = New System.Drawing.Size(57, 26)
        Me.mth_num.TabIndex = 10
        Me.mth_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'mth_name
        '
        Me.mth_name.AcceptsReturn = True
        Me.mth_name.BackColor = System.Drawing.SystemColors.Window
        Me.mth_name.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.mth_name.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mth_name.ForeColor = System.Drawing.SystemColors.WindowText
        Me.mth_name.Location = New System.Drawing.Point(200, 112)
        Me.mth_name.MaxLength = 0
        Me.mth_name.Name = "mth_name"
        Me.mth_name.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.mth_name.Size = New System.Drawing.Size(113, 20)
        Me.mth_name.TabIndex = 2
        Me.mth_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'close_gl
        '
        Me.close_gl.BackColor = System.Drawing.SystemColors.Control
        Me.close_gl.Cursor = System.Windows.Forms.Cursors.Default
        Me.close_gl.Enabled = False
        Me.close_gl.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.close_gl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.close_gl.Location = New System.Drawing.Point(192, 248)
        Me.close_gl.Name = "close_gl"
        Me.close_gl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.close_gl.Size = New System.Drawing.Size(145, 33)
        Me.close_gl.TabIndex = 4
        Me.close_gl.Text = "Select and Post "
        Me.close_gl.UseVisualStyleBackColor = False
        '
        '_txtfields_0
        '
        Me._txtfields_0.AcceptsReturn = True
        Me._txtfields_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_0, CType(0, Short))
        Me._txtfields_0.Location = New System.Drawing.Point(161, 73)
        Me._txtfields_0.MaxLength = 0
        Me._txtfields_0.Name = "_txtfields_0"
        Me._txtfields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_0.Size = New System.Drawing.Size(89, 20)
        Me._txtfields_0.TabIndex = 0
        Me._txtfields_0.Tag = "BEG_DATE"
        '
        '_txtfields_1
        '
        Me._txtfields_1.AcceptsReturn = True
        Me._txtfields_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_1, CType(1, Short))
        Me._txtfields_1.Location = New System.Drawing.Point(400, 72)
        Me._txtfields_1.MaxLength = 0
        Me._txtfields_1.Name = "_txtfields_1"
        Me._txtfields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_1.Size = New System.Drawing.Size(89, 20)
        Me._txtfields_1.TabIndex = 1
        Me._txtfields_1.Tag = "END_DATE"
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUpdate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUpdate.Location = New System.Drawing.Point(232, 194)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUpdate.Size = New System.Drawing.Size(65, 20)
        Me.cmdUpdate.TabIndex = 3
        Me.cmdUpdate.Text = "Verify"
        Me.cmdUpdate.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(512, 0)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(105, 25)
        Me.cmdClose.TabIndex = 7
        Me.cmdClose.Text = "CANCEL"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(296, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(89, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "of the fiscal year"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(160, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "This is Month "
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(64, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(121, 25)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Month to Close-by name"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(481, 25)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "This will allow you to select the J/E's for the current month.   Be sure to ""VERI" & _
            "FY"" your date selection."
        '
        '_lblLabels_0
        '
        Me._lblLabels_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_0, CType(0, Short))
        Me._lblLabels_0.Location = New System.Drawing.Point(24, 72)
        Me._lblLabels_0.Name = "_lblLabels_0"
        Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_0.Size = New System.Drawing.Size(129, 17)
        Me._lblLabels_0.TabIndex = 5
        Me._lblLabels_0.Text = "Enter the Beginning Date: "
        '
        '_lblLabels_1
        '
        Me._lblLabels_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_1, CType(1, Short))
        Me._lblLabels_1.Location = New System.Drawing.Point(272, 72)
        Me._lblLabels_1.Name = "_lblLabels_1"
        Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_1.Size = New System.Drawing.Size(113, 17)
        Me._lblLabels_1.TabIndex = 6
        Me._lblLabels_1.Text = "Enter the Ending Date: "
        '
        'gl_close
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(624, 443)
        Me.ControlBox = False
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.prt_unposted)
        Me.Controls.Add(Me.mth_num)
        Me.Controls.Add(Me.mth_name)
        Me.Controls.Add(Me.close_gl)
        Me.Controls.Add(Me._txtfields_0)
        Me.Controls.Add(Me._txtfields_1)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._lblLabels_0)
        Me.Controls.Add(Me._lblLabels_1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(6, 32)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "gl_close"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Close General Ledger for the Month"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfields, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class