<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmpwd_inp
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
	Public WithEvents Pwd_text As System.Windows.Forms.TextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmpwd_inp))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command1 = New System.Windows.Forms.Button
		Me.Pwd_text = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Password Checker"
		Me.ClientSize = New System.Drawing.Size(386, 206)
		Me.Location = New System.Drawing.Point(68, 59)
		Me.ControlBox = False
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmpwd_inp"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Cancel"
		Me.Command1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command1.Size = New System.Drawing.Size(89, 25)
		Me.Command1.Location = New System.Drawing.Point(288, 8)
		Me.Command1.TabIndex = 2
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.Pwd_text.AutoSize = False
		Me.Pwd_text.Size = New System.Drawing.Size(233, 25)
		Me.Pwd_text.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.Pwd_text.Location = New System.Drawing.Point(64, 96)
		Me.Pwd_text.PasswordChar = ChrW(42)
		Me.Pwd_text.TabIndex = 0
		Me.Pwd_text.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Pwd_text.AcceptsReturn = True
		Me.Pwd_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.Pwd_text.BackColor = System.Drawing.SystemColors.Window
		Me.Pwd_text.CausesValidation = True
		Me.Pwd_text.Enabled = True
		Me.Pwd_text.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Pwd_text.HideSelection = True
		Me.Pwd_text.ReadOnly = False
		Me.Pwd_text.Maxlength = 0
		Me.Pwd_text.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Pwd_text.MultiLine = False
		Me.Pwd_text.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Pwd_text.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.Pwd_text.TabStop = True
		Me.Pwd_text.Visible = True
		Me.Pwd_text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Pwd_text.Name = "Pwd_text"
		Me.Label1.Text = "Type your password below."
		Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Size = New System.Drawing.Size(233, 33)
		Me.Label1.Location = New System.Drawing.Point(64, 48)
		Me.Label1.TabIndex = 1
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
		Me.Controls.Add(Command1)
		Me.Controls.Add(Pwd_text)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class