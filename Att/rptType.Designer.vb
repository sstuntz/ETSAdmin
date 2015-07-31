<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class rpt_Type_frm
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
	Public WithEvents _txtFields_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_0 As System.Windows.Forms.TextBox
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
    Public WithEvents _lblLabels_4 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_3 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._txtFields_4 = New System.Windows.Forms.TextBox
        Me._txtFields_3 = New System.Windows.Forms.TextBox
        Me._txtFields_2 = New System.Windows.Forms.TextBox
        Me._txtFields_1 = New System.Windows.Forms.TextBox
        Me._txtFields_0 = New System.Windows.Forms.TextBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me._lblLabels_4 = New System.Windows.Forms.Label
        Me._lblLabels_3 = New System.Windows.Forms.Label
        Me._lblLabels_2 = New System.Windows.Forms.Label
        Me._lblLabels_1 = New System.Windows.Forms.Label
        Me._lblLabels_0 = New System.Windows.Forms.Label
        Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_txtFields_4
        '
        Me._txtFields_4.AcceptsReturn = True
        Me._txtFields_4.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtFields_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFields.SetIndex(Me._txtFields_4, CType(4, Short))
        Me._txtFields_4.Location = New System.Drawing.Point(80, 144)
        Me._txtFields_4.MaxLength = 30
        Me._txtFields_4.Name = "_txtFields_4"
        Me._txtFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_4.Size = New System.Drawing.Size(241, 19)
        Me._txtFields_4.TabIndex = 13
        Me._txtFields_4.Tag = "rpt_printer"
        '
        '_txtFields_3
        '
        Me._txtFields_3.AcceptsReturn = True
        Me._txtFields_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtFields_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFields.SetIndex(Me._txtFields_3, CType(3, Short))
        Me._txtFields_3.Location = New System.Drawing.Point(80, 112)
        Me._txtFields_3.MaxLength = 35
        Me._txtFields_3.Name = "_txtFields_3"
        Me._txtFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_3.Size = New System.Drawing.Size(273, 19)
        Me._txtFields_3.TabIndex = 11
        Me._txtFields_3.Tag = "rpt_desc"
        '
        '_txtFields_2
        '
        Me._txtFields_2.AcceptsReturn = True
        Me._txtFields_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFields.SetIndex(Me._txtFields_2, CType(2, Short))
        Me._txtFields_2.Location = New System.Drawing.Point(80, 80)
        Me._txtFields_2.MaxLength = 30
        Me._txtFields_2.Name = "_txtFields_2"
        Me._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_2.Size = New System.Drawing.Size(241, 19)
        Me._txtFields_2.TabIndex = 9
        Me._txtFields_2.Tag = "rpt_name"
        '
        '_txtFields_1
        '
        Me._txtFields_1.AcceptsReturn = True
        Me._txtFields_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFields.SetIndex(Me._txtFields_1, CType(1, Short))
        Me._txtFields_1.Location = New System.Drawing.Point(248, 48)
        Me._txtFields_1.MaxLength = 30
        Me._txtFields_1.Name = "_txtFields_1"
        Me._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_1.Size = New System.Drawing.Size(241, 19)
        Me._txtFields_1.TabIndex = 7
        Me._txtFields_1.Tag = "rpt_path"
        '
        '_txtFields_0
        '
        Me._txtFields_0.AcceptsReturn = True
        Me._txtFields_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFields.SetIndex(Me._txtFields_0, CType(0, Short))
        Me._txtFields_0.Location = New System.Drawing.Point(80, 48)
        Me._txtFields_0.MaxLength = 3
        Me._txtFields_0.Name = "_txtFields_0"
        Me._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_0.Size = New System.Drawing.Size(62, 19)
        Me._txtFields_0.TabIndex = 5
        Me._txtFields_0.Tag = "rpt_num"
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(424, 8)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(65, 20)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUpdate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUpdate.Location = New System.Drawing.Point(424, 160)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUpdate.Size = New System.Drawing.Size(65, 20)
        Me.cmdUpdate.TabIndex = 2
        Me.cmdUpdate.Text = "Save"
        Me.cmdUpdate.UseVisualStyleBackColor = False
        '
        '_lblLabels_4
        '
        Me._lblLabels_4.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_4, CType(4, Short))
        Me._lblLabels_4.Location = New System.Drawing.Point(8, 144)
        Me._lblLabels_4.Name = "_lblLabels_4"
        Me._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_4.Size = New System.Drawing.Size(60, 17)
        Me._lblLabels_4.TabIndex = 12
        Me._lblLabels_4.Text = "rpt_printer:"
        '
        '_lblLabels_3
        '
        Me._lblLabels_3.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLabels.SetIndex(Me._lblLabels_3, CType(3, Short))
        Me._lblLabels_3.Location = New System.Drawing.Point(8, 112)
        Me._lblLabels_3.Name = "_lblLabels_3"
        Me._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_3.Size = New System.Drawing.Size(60, 17)
        Me._lblLabels_3.TabIndex = 10
        Me._lblLabels_3.Text = "*rpt_desc:"
        '
        '_lblLabels_2
        '
        Me._lblLabels_2.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLabels.SetIndex(Me._lblLabels_2, CType(2, Short))
        Me._lblLabels_2.Location = New System.Drawing.Point(8, 80)
        Me._lblLabels_2.Name = "_lblLabels_2"
        Me._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_2.Size = New System.Drawing.Size(60, 17)
        Me._lblLabels_2.TabIndex = 8
        Me._lblLabels_2.Text = "*rpt_name:"
        '
        '_lblLabels_1
        '
        Me._lblLabels_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_1, CType(1, Short))
        Me._lblLabels_1.Location = New System.Drawing.Point(176, 45)
        Me._lblLabels_1.Name = "_lblLabels_1"
        Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_1.Size = New System.Drawing.Size(60, 17)
        Me._lblLabels_1.TabIndex = 6
        Me._lblLabels_1.Text = "rpt_path:"
        '
        '_lblLabels_0
        '
        Me._lblLabels_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLabels.SetIndex(Me._lblLabels_0, CType(0, Short))
        Me._lblLabels_0.Location = New System.Drawing.Point(8, 53)
        Me._lblLabels_0.Name = "_lblLabels_0"
        Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_0.Size = New System.Drawing.Size(60, 17)
        Me._lblLabels_0.TabIndex = 4
        Me._lblLabels_0.Text = "*rpt_num:"
        '
        'txtFields
        '
        '
        'rpt_Type_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(547, 242)
        Me.ControlBox = False
        Me.Controls.Add(Me._txtFields_4)
        Me.Controls.Add(Me._txtFields_3)
        Me.Controls.Add(Me._txtFields_2)
        Me.Controls.Add(Me._txtFields_1)
        Me.Controls.Add(Me._txtFields_0)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me._lblLabels_4)
        Me.Controls.Add(Me._lblLabels_3)
        Me.Controls.Add(Me._lblLabels_2)
        Me.Controls.Add(Me._lblLabels_1)
        Me.Controls.Add(Me._lblLabels_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(47, 117)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "rpt_Type_frm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "rpt_type"
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class