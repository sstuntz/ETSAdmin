<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class arinvvd_frm1
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
	Public WithEvents high_je_num As System.Windows.Forms.TextBox
	Public WithEvents Data2 As System.Windows.Forms.Label
	Public WithEvents Cancel As System.Windows.Forms.Button
	Public WithEvents void_gl As System.Windows.Forms.Button
	Public WithEvents void_no_gl As System.Windows.Forms.Button
	Public WithEvents Data1 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arinvvd_frm1))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.high_je_num = New System.Windows.Forms.TextBox
		Me.Data2 = New System.Windows.Forms.Label
		Me.Cancel = New System.Windows.Forms.Button
		Me.void_gl = New System.Windows.Forms.Button
		Me.void_no_gl = New System.Windows.Forms.Button
		Me.Data1 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Accounts Receivable- Void an Invoice1"
		Me.ClientSize = New System.Drawing.Size(617, 435)
		Me.Location = New System.Drawing.Point(8, 32)
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
		Me.Name = "arinvvd_frm1"
		Me.high_je_num.AutoSize = False
		Me.high_je_num.Tag = "jrnl_num"
		Me.high_je_num.Size = New System.Drawing.Size(49, 25)
		Me.high_je_num.Location = New System.Drawing.Point(112, 368)
		Me.high_je_num.TabIndex = 6
		Me.high_je_num.Visible = False
		Me.high_je_num.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.high_je_num.AcceptsReturn = True
		Me.high_je_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.high_je_num.BackColor = System.Drawing.SystemColors.Window
		Me.high_je_num.CausesValidation = True
		Me.high_je_num.Enabled = True
		Me.high_je_num.ForeColor = System.Drawing.SystemColors.WindowText
		Me.high_je_num.HideSelection = True
		Me.high_je_num.ReadOnly = False
		Me.high_je_num.Maxlength = 0
		Me.high_je_num.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.high_je_num.MultiLine = False
		Me.high_je_num.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.high_je_num.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.high_je_num.TabStop = True
		Me.high_je_num.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.high_je_num.Name = "high_je_num"
		Me.Data2.Text = "highest je"
		Me.Data2.Size = New System.Drawing.Size(161, 25)
		Me.Data2.Location = New System.Drawing.Point(348, 359)
		Me.Data2.Visible = False
		Me.Data2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Data2.BackColor = System.Drawing.Color.Red
		Me.Data2.ForeColor = System.Drawing.Color.Black
		Me.Data2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Data2.Text = "Data2"
		Me.Data2.Name = "Data2"
		Me.Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Cancel.Text = "Exit this Screen - No Action"
		Me.Cancel.Size = New System.Drawing.Size(203, 26)
		Me.Cancel.Location = New System.Drawing.Point(406, 2)
		Me.Cancel.TabIndex = 5
		Me.Cancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Cancel.BackColor = System.Drawing.SystemColors.Control
		Me.Cancel.CausesValidation = True
		Me.Cancel.Enabled = True
		Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Cancel.TabStop = True
		Me.Cancel.Name = "Cancel"
		Me.void_gl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.void_gl.Text = "Void Invoice Posted to G/L"
		Me.void_gl.Size = New System.Drawing.Size(177, 41)
		Me.void_gl.Location = New System.Drawing.Point(48, 271)
		Me.void_gl.TabIndex = 3
		Me.void_gl.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.void_gl.BackColor = System.Drawing.SystemColors.Control
		Me.void_gl.CausesValidation = True
		Me.void_gl.Enabled = True
		Me.void_gl.ForeColor = System.Drawing.SystemColors.ControlText
		Me.void_gl.Cursor = System.Windows.Forms.Cursors.Default
		Me.void_gl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.void_gl.TabStop = True
		Me.void_gl.Name = "void_gl"
		Me.void_no_gl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.void_no_gl.Text = "Void Invoice NOT posted to G/L"
		Me.void_no_gl.Size = New System.Drawing.Size(177, 41)
		Me.void_no_gl.Location = New System.Drawing.Point(47, 215)
		Me.void_no_gl.TabIndex = 1
		Me.void_no_gl.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.void_no_gl.BackColor = System.Drawing.SystemColors.Control
		Me.void_no_gl.CausesValidation = True
		Me.void_no_gl.Enabled = True
		Me.void_no_gl.ForeColor = System.Drawing.SystemColors.ControlText
		Me.void_no_gl.Cursor = System.Windows.Forms.Cursors.Default
		Me.void_no_gl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.void_no_gl.TabStop = True
		Me.void_no_gl.Name = "void_no_gl"
		Me.Data1.Text = "Data1"
		Me.Data1.Size = New System.Drawing.Size(617, 25)
		Me.Data1.Location = New System.Drawing.Point(0, 410)
		Me.Data1.Visible = False
		Me.Data1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Data1.BackColor = System.Drawing.Color.Red
		Me.Data1.ForeColor = System.Drawing.Color.Black
		Me.Data1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Data1.Text = "Data1"
		Me.Data1.Name = "Data1"
		Me.Label5.Text = "This will let you void a invoice that has not been posted to the General Ledger. "
		Me.Label5.Size = New System.Drawing.Size(225, 33)
		Me.Label5.Location = New System.Drawing.Point(264, 216)
		Me.Label5.TabIndex = 8
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
		Me.Label4.Text = "This will Void a Invoice that has been posted to the G/L.  It will create a J/E to Adjust the General Ledger"
		Me.Label4.Size = New System.Drawing.Size(241, 49)
		Me.Label4.Location = New System.Drawing.Point(264, 264)
		Me.Label4.TabIndex = 7
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
		Me.Label3.Size = New System.Drawing.Size(241, 49)
		Me.Label3.Location = New System.Drawing.Point(272, 264)
		Me.Label3.TabIndex = 4
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
		Me.Label2.Size = New System.Drawing.Size(225, 33)
		Me.Label2.Location = New System.Drawing.Point(272, 216)
		Me.Label2.TabIndex = 2
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
		Me.Label1.Text = "Select invoice number to void"
		Me.Label1.Size = New System.Drawing.Size(97, 33)
		Me.Label1.Location = New System.Drawing.Point(24, 16)
		Me.Label1.TabIndex = 0
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
		Me.Controls.Add(high_je_num)
		Me.Controls.Add(Data2)
		Me.Controls.Add(Cancel)
		Me.Controls.Add(void_gl)
		Me.Controls.Add(void_no_gl)
		Me.Controls.Add(Data1)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class