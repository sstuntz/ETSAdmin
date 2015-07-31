<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class ar_calc_bal
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
	Public WithEvents mth_num As System.Windows.Forms.TextBox
	Public WithEvents mth_name As System.Windows.Forms.TextBox
	Public WithEvents close_gl As System.Windows.Forms.Button
	Public WithEvents _txtfield_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtfield_1 As System.Windows.Forms.TextBox
	Public WithEvents Data1 As System.Windows.Forms.Label
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents txtfield As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ar_calc_bal))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command1 = New System.Windows.Forms.Button
		Me.mth_num = New System.Windows.Forms.TextBox
		Me.mth_name = New System.Windows.Forms.TextBox
		Me.close_gl = New System.Windows.Forms.Button
		Me._txtfield_0 = New System.Windows.Forms.TextBox
		Me._txtfield_1 = New System.Windows.Forms.TextBox
		Me.Data1 = New System.Windows.Forms.Label
		Me.cmdUpdate = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me._lblLabels_0 = New System.Windows.Forms.Label
		Me._lblLabels_1 = New System.Windows.Forms.Label
		Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.txtfield = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtfield, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "AR Re Calc  Balance Due"
		Me.ClientSize = New System.Drawing.Size(632, 453)
		Me.Location = New System.Drawing.Point(4, 39)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
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
		Me.Name = "ar_calc_bal"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Exit This Screen"
		Me.Command1.Size = New System.Drawing.Size(145, 25)
		Me.Command1.Location = New System.Drawing.Point(464, 408)
		Me.Command1.TabIndex = 13
		Me.Command1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.mth_num.AutoSize = False
		Me.mth_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.mth_num.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.mth_num.Size = New System.Drawing.Size(57, 28)
		Me.mth_num.Location = New System.Drawing.Point(320, 248)
		Me.mth_num.TabIndex = 10
		Me.mth_num.AcceptsReturn = True
		Me.mth_num.BackColor = System.Drawing.SystemColors.Window
		Me.mth_num.CausesValidation = True
		Me.mth_num.Enabled = True
		Me.mth_num.ForeColor = System.Drawing.SystemColors.WindowText
		Me.mth_num.HideSelection = True
		Me.mth_num.ReadOnly = False
		Me.mth_num.Maxlength = 0
		Me.mth_num.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.mth_num.MultiLine = False
		Me.mth_num.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.mth_num.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.mth_num.TabStop = True
		Me.mth_num.Visible = True
		Me.mth_num.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.mth_num.Name = "mth_num"
		Me.mth_name.AutoSize = False
		Me.mth_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.mth_name.Size = New System.Drawing.Size(113, 25)
		Me.mth_name.Location = New System.Drawing.Point(320, 216)
		Me.mth_name.TabIndex = 2
		Me.mth_name.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.mth_name.AcceptsReturn = True
		Me.mth_name.BackColor = System.Drawing.SystemColors.Window
		Me.mth_name.CausesValidation = True
		Me.mth_name.Enabled = True
		Me.mth_name.ForeColor = System.Drawing.SystemColors.WindowText
		Me.mth_name.HideSelection = True
		Me.mth_name.ReadOnly = False
		Me.mth_name.Maxlength = 0
		Me.mth_name.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.mth_name.MultiLine = False
		Me.mth_name.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.mth_name.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.mth_name.TabStop = True
		Me.mth_name.Visible = True
		Me.mth_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.mth_name.Name = "mth_name"
		Me.close_gl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.close_gl.Text = "Recalc Bal Due"
		Me.close_gl.Enabled = False
		Me.close_gl.Font = New System.Drawing.Font("Arial", 12!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.close_gl.Size = New System.Drawing.Size(185, 33)
		Me.close_gl.Location = New System.Drawing.Point(232, 344)
		Me.close_gl.TabIndex = 4
		Me.close_gl.BackColor = System.Drawing.SystemColors.Control
		Me.close_gl.CausesValidation = True
		Me.close_gl.ForeColor = System.Drawing.SystemColors.ControlText
		Me.close_gl.Cursor = System.Windows.Forms.Cursors.Default
		Me.close_gl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.close_gl.TabStop = True
		Me.close_gl.Name = "close_gl"
		Me._txtfield_0.AutoSize = False
		Me._txtfield_0.Tag = "BEG_DATE"
		Me._txtfield_0.Size = New System.Drawing.Size(89, 19)
		Me._txtfield_0.Location = New System.Drawing.Point(320, 144)
		Me._txtfield_0.TabIndex = 0
		Me._txtfield_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtfield_0.AcceptsReturn = True
		Me._txtfield_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtfield_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtfield_0.CausesValidation = True
		Me._txtfield_0.Enabled = True
		Me._txtfield_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtfield_0.HideSelection = True
		Me._txtfield_0.ReadOnly = False
		Me._txtfield_0.Maxlength = 0
		Me._txtfield_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtfield_0.MultiLine = False
		Me._txtfield_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtfield_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtfield_0.TabStop = True
		Me._txtfield_0.Visible = True
		Me._txtfield_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtfield_0.Name = "_txtfield_0"
		Me._txtfield_1.AutoSize = False
		Me._txtfield_1.Tag = "END_DATE"
		Me._txtfield_1.Size = New System.Drawing.Size(89, 19)
		Me._txtfield_1.Location = New System.Drawing.Point(320, 176)
		Me._txtfield_1.TabIndex = 1
		Me._txtfield_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtfield_1.AcceptsReturn = True
		Me._txtfield_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtfield_1.BackColor = System.Drawing.SystemColors.Window
		Me._txtfield_1.CausesValidation = True
		Me._txtfield_1.Enabled = True
		Me._txtfield_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtfield_1.HideSelection = True
		Me._txtfield_1.ReadOnly = False
		Me._txtfield_1.Maxlength = 0
		Me._txtfield_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtfield_1.MultiLine = False
		Me._txtfield_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtfield_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtfield_1.TabStop = True
		Me._txtfield_1.Visible = True
		Me._txtfield_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtfield_1.Name = "_txtfield_1"
		Me.Data1.Size = New System.Drawing.Size(632, 23)
		Me.Data1.Location = New System.Drawing.Point(0, 430)
		Me.Data1.Visible = False
		Me.Data1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Data1.BackColor = System.Drawing.Color.Red
		Me.Data1.ForeColor = System.Drawing.Color.Black
		Me.Data1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Data1.Text = "Data1"
		Me.Data1.Name = "Data1"
		Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdUpdate.Text = "Verify"
		Me.cmdUpdate.Size = New System.Drawing.Size(65, 20)
		Me.cmdUpdate.Location = New System.Drawing.Point(280, 304)
		Me.cmdUpdate.TabIndex = 3
		Me.cmdUpdate.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdUpdate.CausesValidation = True
		Me.cmdUpdate.Enabled = True
		Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdUpdate.TabStop = True
		Me.cmdUpdate.Name = "cmdUpdate"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "CANCEL"
		Me.cmdClose.Size = New System.Drawing.Size(105, 25)
		Me.cmdClose.Location = New System.Drawing.Point(544, 0)
		Me.cmdClose.TabIndex = 7
		Me.cmdClose.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.Label8.Text = "Enter the range of dates and be sure to VERIFY Data Entry."
		Me.Label8.Size = New System.Drawing.Size(337, 17)
		Me.Label8.Location = New System.Drawing.Point(184, 112)
		Me.Label8.TabIndex = 17
		Me.Label8.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label8.BackColor = System.Drawing.SystemColors.Control
		Me.Label8.Enabled = True
		Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label8.UseMnemonic = True
		Me.Label8.Visible = True
		Me.Label8.AutoSize = False
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label8.Name = "Label8"
		Me.Label7.Text = "If the total is ZERO(0), both invoices and payment records will be marked as PAID."
		Me.Label7.Size = New System.Drawing.Size(473, 17)
		Me.Label7.Location = New System.Drawing.Point(24, 32)
		Me.Label7.TabIndex = 16
		Me.Label7.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label7.BackColor = System.Drawing.SystemColors.Control
		Me.Label7.Enabled = True
		Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = False
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label6.Text = "When AGED reports are printed, the records with paid dates greater than the AGING date will show as UNPAID."
		Me.Label6.Size = New System.Drawing.Size(633, 17)
		Me.Label6.Location = New System.Drawing.Point(24, 80)
		Me.Label6.TabIndex = 15
		Me.Label6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.BackColor = System.Drawing.SystemColors.Control
		Me.Label6.Enabled = True
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Label5.Text = "The Current Ending Date will become the payment date.  This range of dates is for the current month that you are closing."
		Me.Label5.Size = New System.Drawing.Size(625, 17)
		Me.Label5.Location = New System.Drawing.Point(24, 56)
		Me.Label5.TabIndex = 14
		Me.Label5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "of the fiscal year"
		Me.Label4.Size = New System.Drawing.Size(89, 17)
		Me.Label4.Location = New System.Drawing.Point(392, 256)
		Me.Label4.TabIndex = 12
		Me.Label4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "This is Month "
		Me.Label3.Size = New System.Drawing.Size(65, 17)
		Me.Label3.Location = New System.Drawing.Point(160, 256)
		Me.Label3.TabIndex = 11
		Me.Label3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "Name of Month"
		Me.Label2.Size = New System.Drawing.Size(121, 25)
		Me.Label2.Location = New System.Drawing.Point(160, 216)
		Me.Label2.TabIndex = 9
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
		Me.Label1.Text = "This is a new form as of 7/8/01.  This will sum ALL invoice and payment lines for ALL invoices."
		Me.Label1.Size = New System.Drawing.Size(513, 17)
		Me.Label1.Location = New System.Drawing.Point(24, 8)
		Me.Label1.TabIndex = 8
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
		Me._lblLabels_0.Text = "Enter Current Month Begin Date: "
		Me._lblLabels_0.Size = New System.Drawing.Size(177, 17)
		Me._lblLabels_0.Location = New System.Drawing.Point(104, 144)
		Me._lblLabels_0.TabIndex = 5
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
		Me._lblLabels_1.Text = "Enter Current Month End Date: "
		Me._lblLabels_1.Size = New System.Drawing.Size(169, 17)
		Me._lblLabels_1.Location = New System.Drawing.Point(104, 176)
		Me._lblLabels_1.TabIndex = 6
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
		Me.Controls.Add(Command1)
		Me.Controls.Add(mth_num)
		Me.Controls.Add(mth_name)
		Me.Controls.Add(close_gl)
		Me.Controls.Add(_txtfield_0)
		Me.Controls.Add(_txtfield_1)
		Me.Controls.Add(Data1)
		Me.Controls.Add(cmdUpdate)
		Me.Controls.Add(cmdClose)
		Me.Controls.Add(Label8)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Controls.Add(_lblLabels_0)
		Me.Controls.Add(_lblLabels_1)
		Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
		Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
		Me.txtfield.SetIndex(_txtfield_0, CType(0, Short))
		Me.txtfield.SetIndex(_txtfield_1, CType(1, Short))
		CType(Me.txtfield, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class