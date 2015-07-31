<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class apvdr_frm
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
	Public WithEvents Command6 As System.Windows.Forms.Button
	Public WithEvents Command5 As System.Windows.Forms.Button
	Public WithEvents Command4 As System.Windows.Forms.Button
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents _txtField0_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtField1_1 As System.Windows.Forms.TextBox
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents txtField0 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents txtField1 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(apvdr_frm))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command6 = New System.Windows.Forms.Button
		Me.Command5 = New System.Windows.Forms.Button
		Me.Command4 = New System.Windows.Forms.Button
		Me.Command3 = New System.Windows.Forms.Button
		Me.Command2 = New System.Windows.Forms.Button
		Me.Command1 = New System.Windows.Forms.Button
		Me._txtField0_0 = New System.Windows.Forms.TextBox
		Me._txtField1_1 = New System.Windows.Forms.TextBox
		Me.cmdUpdate = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me._lblLabels_0 = New System.Windows.Forms.Label
		Me._lblLabels_1 = New System.Windows.Forms.Label
		Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.txtField0 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.txtField1 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtField0, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtField1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Print Voucher Reports selected by  Date Range "
		Me.ClientSize = New System.Drawing.Size(602, 444)
		Me.Location = New System.Drawing.Point(13, 31)
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
		Me.Name = "apvdr_frm"
		Me.Command6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command6.Text = "Vouchers/Dept/Acct#"
		Me.Command6.Size = New System.Drawing.Size(137, 26)
		Me.Command6.Location = New System.Drawing.Point(64, 313)
		Me.Command6.TabIndex = 13
		Me.Command6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command6.BackColor = System.Drawing.SystemColors.Control
		Me.Command6.CausesValidation = True
		Me.Command6.Enabled = True
		Me.Command6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command6.TabStop = True
		Me.Command6.Name = "Command6"
		Me.Command5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command5.Text = "Vouchers/4 digit Acct"
		Me.Command5.Size = New System.Drawing.Size(150, 26)
		Me.Command5.Location = New System.Drawing.Point(354, 169)
		Me.Command5.TabIndex = 12
		Me.Command5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command5.BackColor = System.Drawing.SystemColors.Control
		Me.Command5.CausesValidation = True
		Me.Command5.Enabled = True
		Me.Command5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command5.TabStop = True
		Me.Command5.Name = "Command5"
		Me.Command4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command4.Text = "Non Reimburseables"
		Me.Command4.Size = New System.Drawing.Size(137, 32)
		Me.Command4.Location = New System.Drawing.Point(63, 361)
		Me.Command4.TabIndex = 11
		Me.Command4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command4.BackColor = System.Drawing.SystemColors.Control
		Me.Command4.CausesValidation = True
		Me.Command4.Enabled = True
		Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command4.TabStop = True
		Me.Command4.Name = "Command4"
		Me.Command3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command3.Text = "Vouchers/Dept/Alpha"
		Me.Command3.Size = New System.Drawing.Size(137, 31)
		Me.Command3.Location = New System.Drawing.Point(65, 267)
		Me.Command3.TabIndex = 10
		Me.Command3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command3.BackColor = System.Drawing.SystemColors.Control
		Me.Command3.CausesValidation = True
		Me.Command3.Enabled = True
		Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command3.TabStop = True
		Me.Command3.Name = "Command3"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.Text = "Vouchers/Acct#"
		Me.Command2.Size = New System.Drawing.Size(138, 30)
		Me.Command2.Location = New System.Drawing.Point(64, 217)
		Me.Command2.TabIndex = 9
		Me.Command2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Vouchers/Date Range"
		Me.Command1.Size = New System.Drawing.Size(139, 31)
		Me.Command1.Location = New System.Drawing.Point(65, 168)
		Me.Command1.TabIndex = 7
		Me.Command1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me._txtField0_0.AutoSize = False
		Me._txtField0_0.Tag = "BEG_DATE"
		Me._txtField0_0.Size = New System.Drawing.Size(81, 19)
		Me._txtField0_0.Location = New System.Drawing.Point(152, 72)
		Me._txtField0_0.TabIndex = 1
		Me._txtField0_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtField0_0.AcceptsReturn = True
		Me._txtField0_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtField0_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtField0_0.CausesValidation = True
		Me._txtField0_0.Enabled = True
		Me._txtField0_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtField0_0.HideSelection = True
		Me._txtField0_0.ReadOnly = False
		Me._txtField0_0.Maxlength = 0
		Me._txtField0_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtField0_0.MultiLine = False
		Me._txtField0_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtField0_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtField0_0.TabStop = True
		Me._txtField0_0.Visible = True
		Me._txtField0_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtField0_0.Name = "_txtField0_0"
		Me._txtField1_1.AutoSize = False
		Me._txtField1_1.Tag = "END_DATE"
		Me._txtField1_1.Size = New System.Drawing.Size(89, 19)
		Me._txtField1_1.Location = New System.Drawing.Point(400, 73)
		Me._txtField1_1.TabIndex = 3
		Me._txtField1_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtField1_1.AcceptsReturn = True
		Me._txtField1_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtField1_1.BackColor = System.Drawing.SystemColors.Window
		Me._txtField1_1.CausesValidation = True
		Me._txtField1_1.Enabled = True
		Me._txtField1_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtField1_1.HideSelection = True
		Me._txtField1_1.ReadOnly = False
		Me._txtField1_1.Maxlength = 0
		Me._txtField1_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtField1_1.MultiLine = False
		Me._txtField1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtField1_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtField1_1.TabStop = True
		Me._txtField1_1.Visible = True
		Me._txtField1_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtField1_1.Name = "_txtField1_1"
		Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdUpdate.Text = "Verify"
		Me.cmdUpdate.Size = New System.Drawing.Size(65, 20)
		Me.cmdUpdate.Location = New System.Drawing.Point(232, 120)
		Me.cmdUpdate.TabIndex = 4
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
		Me.cmdClose.Text = "Cancel"
		Me.cmdClose.Size = New System.Drawing.Size(96, 27)
		Me.cmdClose.Location = New System.Drawing.Point(504, 2)
		Me.cmdClose.TabIndex = 5
		Me.cmdClose.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.Label2.Text = "NEXT....Select Report to Print:"
		Me.Label2.Size = New System.Drawing.Size(157, 19)
		Me.Label2.Location = New System.Drawing.Point(20, 139)
		Me.Label2.TabIndex = 8
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
		Me.Label1.Text = "First...select the Vouchers by entering the beginning and ending vouucher date range. If this is for One Date, make the dates the same. Be sure to ""VERIFY"" your selection."
		Me.Label1.Size = New System.Drawing.Size(417, 41)
		Me.Label1.Location = New System.Drawing.Point(24, 16)
		Me.Label1.TabIndex = 6
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
		Me._lblLabels_0.Text = "Enter the Beginning VoucherDate"
		Me._lblLabels_0.Size = New System.Drawing.Size(129, 25)
		Me._lblLabels_0.Location = New System.Drawing.Point(16, 72)
		Me._lblLabels_0.TabIndex = 0
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
		Me._lblLabels_1.Text = "Enter the Ending Voucher Date"
		Me._lblLabels_1.Size = New System.Drawing.Size(129, 25)
		Me._lblLabels_1.Location = New System.Drawing.Point(264, 72)
		Me._lblLabels_1.TabIndex = 2
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
		Me.Controls.Add(Command6)
		Me.Controls.Add(Command5)
		Me.Controls.Add(Command4)
		Me.Controls.Add(Command3)
		Me.Controls.Add(Command2)
		Me.Controls.Add(Command1)
		Me.Controls.Add(_txtField0_0)
		Me.Controls.Add(_txtField1_1)
		Me.Controls.Add(cmdUpdate)
		Me.Controls.Add(cmdClose)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Controls.Add(_lblLabels_0)
		Me.Controls.Add(_lblLabels_1)
		Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
		Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
		Me.txtField0.SetIndex(_txtField0_0, CType(0, Short))
		Me.txtField1.SetIndex(_txtField1_1, CType(1, Short))
		CType(Me.txtField1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtField0, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class