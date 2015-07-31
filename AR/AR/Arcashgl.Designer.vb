<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class arcashgl_frm
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
	Public WithEvents Command4 As System.Windows.Forms.Button
	Public WithEvents yrgenled As System.Windows.Forms.Label
	Public WithEvents cash As System.Windows.Forms.Label
	Public WithEvents je_tmp As System.Windows.Forms.Label
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents high_je_num As System.Windows.Forms.Label
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents _txtField0_0 As System.Windows.Forms.TextBox
	Public WithEvents _txtField1_1 As System.Windows.Forms.TextBox
	Public WithEvents Data1 As System.Windows.Forms.Label
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
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
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(arcashgl_frm))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command4 = New System.Windows.Forms.Button
		Me.yrgenled = New System.Windows.Forms.Label
		Me.cash = New System.Windows.Forms.Label
		Me.je_tmp = New System.Windows.Forms.Label
		Me.Command2 = New System.Windows.Forms.Button
		Me.Text1 = New System.Windows.Forms.TextBox
		Me.high_je_num = New System.Windows.Forms.Label
		Me.Command3 = New System.Windows.Forms.Button
		Me.Command1 = New System.Windows.Forms.Button
		Me._txtField0_0 = New System.Windows.Forms.TextBox
		Me._txtField1_1 = New System.Windows.Forms.TextBox
		Me.Data1 = New System.Windows.Forms.Label
		Me.cmdUpdate = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
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
		Me.Text = "Create AR Cash Receipts J/E for Month"
		Me.ClientSize = New System.Drawing.Size(623, 453)
		Me.Location = New System.Drawing.Point(9, 24)
		Me.ControlBox = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
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
		Me.Name = "arcashgl_frm"
		Me.Command4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command4.Text = "Prepare JE"
		Me.Command4.Size = New System.Drawing.Size(198, 31)
		Me.Command4.Location = New System.Drawing.Point(236, 180)
		Me.Command4.TabIndex = 5
		Me.Command4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command4.BackColor = System.Drawing.SystemColors.Control
		Me.Command4.CausesValidation = True
		Me.Command4.Enabled = True
		Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command4.TabStop = True
		Me.Command4.Name = "Command4"
		Me.yrgenled.Text = "yrgenled"
		Me.yrgenled.Size = New System.Drawing.Size(144, 27)
		Me.yrgenled.Location = New System.Drawing.Point(271, 403)
		Me.yrgenled.Visible = False
		Me.yrgenled.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.yrgenled.BackColor = System.Drawing.Color.Red
		Me.yrgenled.ForeColor = System.Drawing.Color.Black
		Me.yrgenled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.yrgenled.Text = "yrgenled"
		Me.yrgenled.Name = "yrgenled"
		Me.cash.Text = "cash"
		Me.cash.Size = New System.Drawing.Size(137, 23)
		Me.cash.Location = New System.Drawing.Point(4, 403)
		Me.cash.Visible = False
		Me.cash.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cash.BackColor = System.Drawing.Color.Red
		Me.cash.ForeColor = System.Drawing.Color.Black
		Me.cash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.cash.Text = "cash"
		Me.cash.Name = "cash"
		Me.je_tmp.Text = "je_tmp"
		Me.je_tmp.Size = New System.Drawing.Size(117, 26)
		Me.je_tmp.Location = New System.Drawing.Point(149, 401)
		Me.je_tmp.Visible = False
		Me.je_tmp.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.je_tmp.BackColor = System.Drawing.Color.Red
		Me.je_tmp.ForeColor = System.Drawing.Color.Black
		Me.je_tmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.je_tmp.Text = "je_tmp"
		Me.je_tmp.Name = "je_tmp"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.Text = "Print J/E just created"
		Me.Command2.Size = New System.Drawing.Size(195, 27)
		Me.Command2.Location = New System.Drawing.Point(238, 318)
		Me.Command2.TabIndex = 8
		Me.Command2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.Text1.AutoSize = False
		Me.Text1.Tag = "jrnl_num"
		Me.Text1.Size = New System.Drawing.Size(33, 25)
		Me.Text1.Location = New System.Drawing.Point(578, 396)
		Me.Text1.TabIndex = 14
		Me.Text1.Text = "Text1"
		Me.Text1.Visible = False
		Me.Text1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Text1.AcceptsReturn = True
		Me.Text1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.Text1.BackColor = System.Drawing.SystemColors.Window
		Me.Text1.CausesValidation = True
		Me.Text1.Enabled = True
		Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Text1.HideSelection = True
		Me.Text1.ReadOnly = False
		Me.Text1.Maxlength = 0
		Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text1.MultiLine = False
		Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.Text1.TabStop = True
		Me.Text1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Text1.Name = "Text1"
		Me.high_je_num.Text = "high je num"
		Me.high_je_num.Size = New System.Drawing.Size(153, 28)
		Me.high_je_num.Location = New System.Drawing.Point(416, 399)
		Me.high_je_num.Visible = False
		Me.high_je_num.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.high_je_num.BackColor = System.Drawing.Color.Red
		Me.high_je_num.ForeColor = System.Drawing.Color.Black
		Me.high_je_num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.high_je_num.Text = "high_je_num"
		Me.high_je_num.Name = "high_je_num"
		Me.Command3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command3.Text = "Print JE Pre-post Report"
		Me.Command3.Size = New System.Drawing.Size(195, 28)
		Me.Command3.Location = New System.Drawing.Point(238, 225)
		Me.Command3.TabIndex = 6
		Me.Command3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command3.BackColor = System.Drawing.SystemColors.Control
		Me.Command3.CausesValidation = True
		Me.Command3.Enabled = True
		Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command3.TabStop = True
		Me.Command3.Name = "Command3"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Write Cash J/E to General Ledger"
		Me.Command1.Size = New System.Drawing.Size(195, 27)
		Me.Command1.Location = New System.Drawing.Point(238, 272)
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
		Me._txtField0_0.Size = New System.Drawing.Size(89, 19)
		Me._txtField0_0.Location = New System.Drawing.Point(198, 83)
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
		Me._txtField1_1.Location = New System.Drawing.Point(438, 84)
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
		Me.Data1.Text = "rpthead"
		Me.Data1.Size = New System.Drawing.Size(623, 23)
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
		Me.cmdUpdate.Location = New System.Drawing.Point(304, 119)
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
		Me.cmdClose.Size = New System.Drawing.Size(75, 25)
		Me.cmdClose.Location = New System.Drawing.Point(543, -1)
		Me.cmdClose.TabIndex = 9
		Me.cmdClose.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.Label2.Text = "2."
		Me.Label2.Size = New System.Drawing.Size(20, 18)
		Me.Label2.Location = New System.Drawing.Point(202, 184)
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
		Me.Label6.Text = "5."
		Me.Label6.Size = New System.Drawing.Size(16, 25)
		Me.Label6.Location = New System.Drawing.Point(202, 320)
		Me.Label6.TabIndex = 13
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
		Me.Label4.Text = "4."
		Me.Label4.Size = New System.Drawing.Size(17, 24)
		Me.Label4.Location = New System.Drawing.Point(202, 275)
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
		Me.Label3.Text = "3."
		Me.Label3.Size = New System.Drawing.Size(28, 22)
		Me.Label3.Location = New System.Drawing.Point(202, 230)
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
		Me.Label1.Text = "1.  Enter the range of dates for the current month.   Be sure to ""VERIFY"" your date selection."
		Me.Label1.Size = New System.Drawing.Size(481, 19)
		Me.Label1.Location = New System.Drawing.Point(64, 60)
		Me.Label1.TabIndex = 10
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
		Me._lblLabels_0.Text = "Enter the Beginning Date: "
		Me._lblLabels_0.Size = New System.Drawing.Size(129, 17)
		Me._lblLabels_0.Location = New System.Drawing.Point(64, 84)
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
		Me._lblLabels_1.Text = "Enter the Ending Date: "
		Me._lblLabels_1.Size = New System.Drawing.Size(113, 17)
		Me._lblLabels_1.Location = New System.Drawing.Point(310, 84)
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
		Me.Controls.Add(Command4)
		Me.Controls.Add(yrgenled)
		Me.Controls.Add(cash)
		Me.Controls.Add(je_tmp)
		Me.Controls.Add(Command2)
		Me.Controls.Add(Text1)
		Me.Controls.Add(high_je_num)
		Me.Controls.Add(Command3)
		Me.Controls.Add(Command1)
		Me.Controls.Add(_txtField0_0)
		Me.Controls.Add(_txtField1_1)
		Me.Controls.Add(Data1)
		Me.Controls.Add(cmdUpdate)
		Me.Controls.Add(cmdClose)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
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