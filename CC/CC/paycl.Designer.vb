<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmpaycl
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
	Public WithEvents _txtFields_5 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_0 As System.Windows.Forms.TextBox
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_5 As System.Windows.Forms.Label
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
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmpaycl))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me._txtFields_5 = New System.Windows.Forms.TextBox
		Me._txtFields_4 = New System.Windows.Forms.TextBox
		Me._txtFields_3 = New System.Windows.Forms.TextBox
		Me._txtFields_2 = New System.Windows.Forms.TextBox
		Me._txtFields_1 = New System.Windows.Forms.TextBox
		Me._txtFields_0 = New System.Windows.Forms.TextBox
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdUpdate = New System.Windows.Forms.Button
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me._lblLabels_5 = New System.Windows.Forms.Label
		Me._lblLabels_4 = New System.Windows.Forms.Label
		Me._lblLabels_3 = New System.Windows.Forms.Label
		Me._lblLabels_2 = New System.Windows.Forms.Label
		Me._lblLabels_1 = New System.Windows.Forms.Label
		Me._lblLabels_0 = New System.Windows.Forms.Label
		Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "cc_paycl"
		Me.ClientSize = New System.Drawing.Size(501, 419)
		Me.Location = New System.Drawing.Point(74, 101)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmpaycl"
		Me._txtFields_5.AutoSize = False
		Me._txtFields_5.Size = New System.Drawing.Size(57, 19)
		Me._txtFields_5.Location = New System.Drawing.Point(184, 208)
		Me._txtFields_5.Maxlength = 3
		Me._txtFields_5.TabIndex = 12
		Me._txtFields_5.Tag = "type"
		Me._txtFields_5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtFields_5.AcceptsReturn = True
		Me._txtFields_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_5.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_5.CausesValidation = True
		Me._txtFields_5.Enabled = True
		Me._txtFields_5.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_5.HideSelection = True
		Me._txtFields_5.ReadOnly = False
		Me._txtFields_5.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_5.MultiLine = False
		Me._txtFields_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_5.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_5.TabStop = True
		Me._txtFields_5.Visible = True
		Me._txtFields_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtFields_5.Name = "_txtFields_5"
		Me._txtFields_4.AutoSize = False
		Me._txtFields_4.Size = New System.Drawing.Size(57, 19)
		Me._txtFields_4.Location = New System.Drawing.Point(184, 176)
		Me._txtFields_4.Maxlength = 1
		Me._txtFields_4.TabIndex = 10
		Me._txtFields_4.Tag = "pay"
		Me._txtFields_4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtFields_4.AcceptsReturn = True
		Me._txtFields_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_4.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_4.CausesValidation = True
		Me._txtFields_4.Enabled = True
		Me._txtFields_4.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_4.HideSelection = True
		Me._txtFields_4.ReadOnly = False
		Me._txtFields_4.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_4.MultiLine = False
		Me._txtFields_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_4.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_4.TabStop = True
		Me._txtFields_4.Visible = True
		Me._txtFields_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtFields_4.Name = "_txtFields_4"
		Me._txtFields_3.AutoSize = False
		Me._txtFields_3.Size = New System.Drawing.Size(57, 19)
		Me._txtFields_3.Location = New System.Drawing.Point(184, 144)
		Me._txtFields_3.Maxlength = 1
		Me._txtFields_3.TabIndex = 8
		Me._txtFields_3.Tag = "pieces"
		Me._txtFields_3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtFields_3.AcceptsReturn = True
		Me._txtFields_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_3.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_3.CausesValidation = True
		Me._txtFields_3.Enabled = True
		Me._txtFields_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_3.HideSelection = True
		Me._txtFields_3.ReadOnly = False
		Me._txtFields_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_3.MultiLine = False
		Me._txtFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_3.TabStop = True
		Me._txtFields_3.Visible = True
		Me._txtFields_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtFields_3.Name = "_txtFields_3"
		Me._txtFields_2.AutoSize = False
		Me._txtFields_2.Size = New System.Drawing.Size(57, 19)
		Me._txtFields_2.Location = New System.Drawing.Point(184, 112)
		Me._txtFields_2.Maxlength = 1
		Me._txtFields_2.TabIndex = 6
		Me._txtFields_2.Tag = "hours"
		Me._txtFields_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtFields_2.AcceptsReturn = True
		Me._txtFields_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_2.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_2.CausesValidation = True
		Me._txtFields_2.Enabled = True
		Me._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_2.HideSelection = True
		Me._txtFields_2.ReadOnly = False
		Me._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_2.MultiLine = False
		Me._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_2.TabStop = True
		Me._txtFields_2.Visible = True
		Me._txtFields_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtFields_2.Name = "_txtFields_2"
		Me._txtFields_1.AutoSize = False
		Me._txtFields_1.Size = New System.Drawing.Size(169, 19)
		Me._txtFields_1.Location = New System.Drawing.Point(184, 80)
		Me._txtFields_1.Maxlength = 20
		Me._txtFields_1.TabIndex = 4
		Me._txtFields_1.Tag = "pay_desc"
		Me._txtFields_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtFields_1.AcceptsReturn = True
		Me._txtFields_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_1.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_1.CausesValidation = True
		Me._txtFields_1.Enabled = True
		Me._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_1.HideSelection = True
		Me._txtFields_1.ReadOnly = False
		Me._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_1.MultiLine = False
		Me._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_1.TabStop = True
		Me._txtFields_1.Visible = True
		Me._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtFields_1.Name = "_txtFields_1"
		Me._txtFields_0.AutoSize = False
		Me._txtFields_0.Size = New System.Drawing.Size(57, 19)
		Me._txtFields_0.Location = New System.Drawing.Point(184, 48)
		Me._txtFields_0.Maxlength = 2
		Me._txtFields_0.TabIndex = 2
		Me._txtFields_0.Tag = "pay_class"
		Me._txtFields_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtFields_0.AcceptsReturn = True
		Me._txtFields_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_0.CausesValidation = True
		Me._txtFields_0.Enabled = True
		Me._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_0.HideSelection = True
		Me._txtFields_0.ReadOnly = False
		Me._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_0.MultiLine = False
		Me._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_0.TabStop = True
		Me._txtFields_0.Visible = True
		Me._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtFields_0.Name = "_txtFields_0"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "Cancel"
		Me.cmdClose.Size = New System.Drawing.Size(65, 20)
		Me.cmdClose.Location = New System.Drawing.Point(424, 0)
		Me.cmdClose.TabIndex = 0
		Me.cmdClose.TabStop = False
		Me.cmdClose.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdUpdate.Text = "Save"
		Me.cmdUpdate.Size = New System.Drawing.Size(65, 20)
		Me.cmdUpdate.Location = New System.Drawing.Point(392, 256)
		Me.cmdUpdate.TabIndex = 13
		Me.cmdUpdate.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdUpdate.CausesValidation = True
		Me.cmdUpdate.Enabled = True
		Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdUpdate.TabStop = True
		Me.cmdUpdate.Name = "cmdUpdate"
		Me.Label2.Text = "Only enter a valid pay_class.  See documentaion."
		Me.Label2.Size = New System.Drawing.Size(249, 17)
		Me.Label2.Location = New System.Drawing.Point(24, 16)
		Me.Label2.TabIndex = 15
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Be sure to click on save after adding or editing a record. "
		Me.Label1.Size = New System.Drawing.Size(297, 25)
		Me.Label1.Location = New System.Drawing.Point(72, 256)
		Me.Label1.TabIndex = 14
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me._lblLabels_5.Text = "type:"
		Me._lblLabels_5.Size = New System.Drawing.Size(36, 17)
		Me._lblLabels_5.Location = New System.Drawing.Point(112, 208)
		Me._lblLabels_5.TabIndex = 11
		Me._lblLabels_5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblLabels_5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblLabels_5.BackColor = System.Drawing.SystemColors.Control
		Me._lblLabels_5.Enabled = True
		Me._lblLabels_5.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_5.UseMnemonic = True
		Me._lblLabels_5.Visible = True
		Me._lblLabels_5.AutoSize = False
		Me._lblLabels_5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_5.Name = "_lblLabels_5"
		Me._lblLabels_4.Text = "pay:"
		Me._lblLabels_4.Size = New System.Drawing.Size(44, 17)
		Me._lblLabels_4.Location = New System.Drawing.Point(112, 176)
		Me._lblLabels_4.TabIndex = 9
		Me._lblLabels_4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblLabels_4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblLabels_4.BackColor = System.Drawing.SystemColors.Control
		Me._lblLabels_4.Enabled = True
		Me._lblLabels_4.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_4.UseMnemonic = True
		Me._lblLabels_4.Visible = True
		Me._lblLabels_4.AutoSize = False
		Me._lblLabels_4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_4.Name = "_lblLabels_4"
		Me._lblLabels_3.Text = "pieces:"
		Me._lblLabels_3.Size = New System.Drawing.Size(44, 17)
		Me._lblLabels_3.Location = New System.Drawing.Point(112, 144)
		Me._lblLabels_3.TabIndex = 7
		Me._lblLabels_3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblLabels_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblLabels_3.BackColor = System.Drawing.SystemColors.Control
		Me._lblLabels_3.Enabled = True
		Me._lblLabels_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_3.UseMnemonic = True
		Me._lblLabels_3.Visible = True
		Me._lblLabels_3.AutoSize = False
		Me._lblLabels_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_3.Name = "_lblLabels_3"
		Me._lblLabels_2.Text = "hours:"
		Me._lblLabels_2.Size = New System.Drawing.Size(36, 17)
		Me._lblLabels_2.Location = New System.Drawing.Point(112, 112)
		Me._lblLabels_2.TabIndex = 5
		Me._lblLabels_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblLabels_2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblLabels_2.BackColor = System.Drawing.SystemColors.Control
		Me._lblLabels_2.Enabled = True
		Me._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_2.UseMnemonic = True
		Me._lblLabels_2.Visible = True
		Me._lblLabels_2.AutoSize = False
		Me._lblLabels_2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_2.Name = "_lblLabels_2"
		Me._lblLabels_1.Text = "pay_desc:"
		Me._lblLabels_1.Size = New System.Drawing.Size(52, 17)
		Me._lblLabels_1.Location = New System.Drawing.Point(112, 80)
		Me._lblLabels_1.TabIndex = 3
		Me._lblLabels_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblLabels_1.BackColor = System.Drawing.SystemColors.Control
		Me._lblLabels_1.Enabled = True
		Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_1.UseMnemonic = True
		Me._lblLabels_1.Visible = True
		Me._lblLabels_1.AutoSize = False
		Me._lblLabels_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_1.Name = "_lblLabels_1"
		Me._lblLabels_0.Text = "pay_class:"
		Me._lblLabels_0.Size = New System.Drawing.Size(55, 17)
		Me._lblLabels_0.Location = New System.Drawing.Point(112, 48)
		Me._lblLabels_0.TabIndex = 1
		Me._lblLabels_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblLabels_0.BackColor = System.Drawing.SystemColors.Control
		Me._lblLabels_0.Enabled = True
		Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_0.UseMnemonic = True
		Me._lblLabels_0.Visible = True
		Me._lblLabels_0.AutoSize = False
		Me._lblLabels_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_0.Name = "_lblLabels_0"
		Me.Controls.Add(_txtFields_5)
		Me.Controls.Add(_txtFields_4)
		Me.Controls.Add(_txtFields_3)
		Me.Controls.Add(_txtFields_2)
		Me.Controls.Add(_txtFields_1)
		Me.Controls.Add(_txtFields_0)
		Me.Controls.Add(cmdClose)
		Me.Controls.Add(cmdUpdate)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Controls.Add(_lblLabels_5)
		Me.Controls.Add(_lblLabels_4)
		Me.Controls.Add(_lblLabels_3)
		Me.Controls.Add(_lblLabels_2)
		Me.Controls.Add(_lblLabels_1)
		Me.Controls.Add(_lblLabels_0)
		Me.lblLabels.SetIndex(_lblLabels_5, CType(5, Short))
		Me.lblLabels.SetIndex(_lblLabels_4, CType(4, Short))
		Me.lblLabels.SetIndex(_lblLabels_3, CType(3, Short))
		Me.lblLabels.SetIndex(_lblLabels_2, CType(2, Short))
		Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
		Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
		Me.txtFields.SetIndex(_txtFields_5, CType(5, Short))
		Me.txtFields.SetIndex(_txtFields_4, CType(4, Short))
		Me.txtFields.SetIndex(_txtFields_3, CType(3, Short))
		Me.txtFields.SetIndex(_txtFields_2, CType(2, Short))
		Me.txtFields.SetIndex(_txtFields_1, CType(1, Short))
		Me.txtFields.SetIndex(_txtFields_0, CType(0, Short))
		CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class