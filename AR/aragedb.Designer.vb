<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmaratb1
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
	Public WithEvents nam_cust As System.Windows.Forms.Label
	Public WithEvents cust_age As System.Windows.Forms.Label
	Public WithEvents calc_prior As System.Windows.Forms.Button
	Public WithEvents Command8 As System.Windows.Forms.Button
	Public WithEvents Command7 As System.Windows.Forms.Button
	Public WithEvents Command6 As System.Windows.Forms.Button
	Public WithEvents Command5 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents _txtFields_2 As System.Windows.Forms.TextBox
	Public WithEvents cash As System.Windows.Forms.Label
	Public WithEvents aropn As System.Windows.Forms.Label
	Public WithEvents invoice As System.Windows.Forms.Label
	Public WithEvents Command4 As System.Windows.Forms.Button
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents _txtFields_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_0 As System.Windows.Forms.TextBox
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
	Public WithEvents cmdRefresh As System.Windows.Forms.Button
	Public WithEvents cmdAdd As System.Windows.Forms.Button
	Public WithEvents Data1 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmaratb1))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.nam_cust = New System.Windows.Forms.Label
		Me.cust_age = New System.Windows.Forms.Label
		Me.calc_prior = New System.Windows.Forms.Button
		Me.Command8 = New System.Windows.Forms.Button
		Me.Command7 = New System.Windows.Forms.Button
		Me.Command6 = New System.Windows.Forms.Button
		Me.Command5 = New System.Windows.Forms.Button
		Me.Command1 = New System.Windows.Forms.Button
		Me._txtFields_2 = New System.Windows.Forms.TextBox
		Me.cash = New System.Windows.Forms.Label
		Me.aropn = New System.Windows.Forms.Label
		Me.invoice = New System.Windows.Forms.Label
		Me.Command4 = New System.Windows.Forms.Button
		Me.Command3 = New System.Windows.Forms.Button
		Me.Command2 = New System.Windows.Forms.Button
		Me._txtFields_1 = New System.Windows.Forms.TextBox
		Me._txtFields_0 = New System.Windows.Forms.TextBox
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdUpdate = New System.Windows.Forms.Button
		Me.cmdRefresh = New System.Windows.Forms.Button
		Me.cmdAdd = New System.Windows.Forms.Button
		Me.Data1 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me._lblLabels_1 = New System.Windows.Forms.Label
		Me._lblLabels_0 = New System.Windows.Forms.Label
		Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Print Regular Aging Reports/Statements"
		Me.ClientSize = New System.Drawing.Size(624, 453)
		Me.Location = New System.Drawing.Point(7, 20)
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
		Me.Name = "frmaratb1"
		Me.nam_cust.Text = "cust"
		Me.nam_cust.Size = New System.Drawing.Size(105, 25)
		Me.nam_cust.Location = New System.Drawing.Point(280, 384)
		Me.nam_cust.Visible = False
		Me.nam_cust.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.nam_cust.BackColor = System.Drawing.Color.Red
		Me.nam_cust.ForeColor = System.Drawing.Color.Black
		Me.nam_cust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.nam_cust.Text = "nam_cust"
		Me.nam_cust.Name = "nam_cust"
		Me.cust_age.Text = "cust_age"
		Me.cust_age.Size = New System.Drawing.Size(105, 20)
		Me.cust_age.Location = New System.Drawing.Point(416, 384)
		Me.cust_age.Visible = False
		Me.cust_age.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cust_age.BackColor = System.Drawing.Color.Red
		Me.cust_age.ForeColor = System.Drawing.Color.Black
		Me.cust_age.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.cust_age.Text = "cust_age"
		Me.cust_age.Name = "cust_age"
		Me.calc_prior.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.calc_prior.Text = "Calc Prior Bal for Statements"
		Me.calc_prior.Size = New System.Drawing.Size(185, 25)
		Me.calc_prior.Location = New System.Drawing.Point(16, 384)
		Me.calc_prior.TabIndex = 21
		Me.calc_prior.Visible = False
		Me.calc_prior.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.calc_prior.BackColor = System.Drawing.SystemColors.Control
		Me.calc_prior.CausesValidation = True
		Me.calc_prior.Enabled = True
		Me.calc_prior.ForeColor = System.Drawing.SystemColors.ControlText
		Me.calc_prior.Cursor = System.Windows.Forms.Cursors.Default
		Me.calc_prior.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.calc_prior.TabStop = True
		Me.calc_prior.Name = "calc_prior"
		Me.Command8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command8.Text = "Statement - One Consumer"
		Me.Command8.Size = New System.Drawing.Size(185, 25)
		Me.Command8.Location = New System.Drawing.Point(376, 288)
		Me.Command8.TabIndex = 18
		Me.Command8.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command8.BackColor = System.Drawing.SystemColors.Control
		Me.Command8.CausesValidation = True
		Me.Command8.Enabled = True
		Me.Command8.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command8.TabStop = True
		Me.Command8.Name = "Command8"
		Me.Command7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command7.Text = "Statement - One Customer"
		Me.Command7.Size = New System.Drawing.Size(185, 25)
		Me.Command7.Location = New System.Drawing.Point(376, 248)
		Me.Command7.TabIndex = 17
		Me.Command7.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command7.BackColor = System.Drawing.SystemColors.Control
		Me.Command7.CausesValidation = True
		Me.Command7.Enabled = True
		Me.Command7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command7.TabStop = True
		Me.Command7.Name = "Command7"
		Me.Command6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command6.Text = "Print Statements - All"
		Me.Command6.Size = New System.Drawing.Size(185, 25)
		Me.Command6.Location = New System.Drawing.Point(376, 208)
		Me.Command6.TabIndex = 16
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
		Me.Command5.Text = "One Customer History"
		Me.Command5.Size = New System.Drawing.Size(200, 22)
		Me.Command5.Location = New System.Drawing.Point(104, 331)
		Me.Command5.TabIndex = 15
		Me.Command5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command5.BackColor = System.Drawing.SystemColors.Control
		Me.Command5.CausesValidation = True
		Me.Command5.Enabled = True
		Me.Command5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command5.TabStop = True
		Me.Command5.Name = "Command5"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Print Unwashed AR Summary"
		Me.Command1.Size = New System.Drawing.Size(200, 24)
		Me.Command1.Location = New System.Drawing.Point(104, 201)
		Me.Command1.TabIndex = 14
		Me.Command1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me._txtFields_2.AutoSize = False
		Me._txtFields_2.Tag = "END_DATE"
		Me._txtFields_2.Size = New System.Drawing.Size(85, 19)
		Me._txtFields_2.Location = New System.Drawing.Point(443, 92)
		Me._txtFields_2.TabIndex = 3
		Me._txtFields_2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtFields_2.AcceptsReturn = True
		Me._txtFields_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_2.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_2.CausesValidation = True
		Me._txtFields_2.Enabled = True
		Me._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_2.HideSelection = True
		Me._txtFields_2.ReadOnly = False
		Me._txtFields_2.Maxlength = 0
		Me._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_2.MultiLine = False
		Me._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_2.TabStop = True
		Me._txtFields_2.Visible = True
		Me._txtFields_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtFields_2.Name = "_txtFields_2"
		Me.cash.Text = "cash"
		Me.cash.Size = New System.Drawing.Size(103, 20)
		Me.cash.Location = New System.Drawing.Point(269, 416)
		Me.cash.Visible = False
		Me.cash.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cash.BackColor = System.Drawing.Color.Red
		Me.cash.ForeColor = System.Drawing.Color.Black
		Me.cash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.cash.Text = "cash"
		Me.cash.Name = "cash"
		Me.aropn.Text = "aropn"
		Me.aropn.Size = New System.Drawing.Size(121, 20)
		Me.aropn.Location = New System.Drawing.Point(376, 424)
		Me.aropn.Visible = False
		Me.aropn.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.aropn.BackColor = System.Drawing.Color.Red
		Me.aropn.ForeColor = System.Drawing.Color.Black
		Me.aropn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.aropn.Text = "aropn"
		Me.aropn.Name = "aropn"
		Me.invoice.Text = "invoice"
		Me.invoice.Size = New System.Drawing.Size(126, 22)
		Me.invoice.Location = New System.Drawing.Point(499, 416)
		Me.invoice.Visible = False
		Me.invoice.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.invoice.BackColor = System.Drawing.Color.Red
		Me.invoice.ForeColor = System.Drawing.Color.Black
		Me.invoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.invoice.Text = "invoice"
		Me.invoice.Name = "invoice"
		Me.Command4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command4.Text = "Summary Aging/Cust by Control#"
		Me.Command4.Size = New System.Drawing.Size(200, 24)
		Me.Command4.Location = New System.Drawing.Point(104, 288)
		Me.Command4.TabIndex = 12
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
		Me.Command3.Text = "Print Washed AR Summary"
		Me.Command3.Size = New System.Drawing.Size(200, 25)
		Me.Command3.Location = New System.Drawing.Point(104, 240)
		Me.Command3.TabIndex = 11
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
		Me.Command2.Text = "Load Data Files"
		Me.Command2.Size = New System.Drawing.Size(128, 25)
		Me.Command2.Location = New System.Drawing.Point(266, 161)
		Me.Command2.TabIndex = 10
		Me.Command2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me._txtFields_1.AutoSize = False
		Me._txtFields_1.Tag = "beg_date"
		Me._txtFields_1.Size = New System.Drawing.Size(85, 19)
		Me._txtFields_1.Location = New System.Drawing.Point(224, 90)
		Me._txtFields_1.TabIndex = 2
		Me._txtFields_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtFields_1.AcceptsReturn = True
		Me._txtFields_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_1.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_1.CausesValidation = True
		Me._txtFields_1.Enabled = True
		Me._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_1.HideSelection = True
		Me._txtFields_1.ReadOnly = False
		Me._txtFields_1.Maxlength = 0
		Me._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_1.MultiLine = False
		Me._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_1.TabStop = True
		Me._txtFields_1.Visible = True
		Me._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtFields_1.Name = "_txtFields_1"
		Me._txtFields_0.AutoSize = False
		Me._txtFields_0.Tag = "BEG_DATE"
		Me._txtFields_0.Size = New System.Drawing.Size(42, 19)
		Me._txtFields_0.Location = New System.Drawing.Point(221, 416)
		Me._txtFields_0.TabIndex = 7
		Me._txtFields_0.Visible = False
		Me._txtFields_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtFields_0.AcceptsReturn = True
		Me._txtFields_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_0.CausesValidation = True
		Me._txtFields_0.Enabled = True
		Me._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_0.HideSelection = True
		Me._txtFields_0.ReadOnly = False
		Me._txtFields_0.Maxlength = 0
		Me._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_0.MultiLine = False
		Me._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_0.TabStop = True
		Me._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtFields_0.Name = "_txtFields_0"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "Cancel"
		Me.cmdClose.Size = New System.Drawing.Size(65, 20)
		Me.cmdClose.Location = New System.Drawing.Point(544, 4)
		Me.cmdClose.TabIndex = 5
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
		Me.cmdUpdate.Text = "Verify"
		Me.cmdUpdate.Size = New System.Drawing.Size(96, 20)
		Me.cmdUpdate.Location = New System.Drawing.Point(278, 128)
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
		Me.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRefresh.Text = "Refresh"
		Me.cmdRefresh.Size = New System.Drawing.Size(65, 20)
		Me.cmdRefresh.Location = New System.Drawing.Point(74, 416)
		Me.cmdRefresh.TabIndex = 1
		Me.cmdRefresh.TabStop = False
		Me.cmdRefresh.Visible = False
		Me.cmdRefresh.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdRefresh.BackColor = System.Drawing.SystemColors.Control
		Me.cmdRefresh.CausesValidation = True
		Me.cmdRefresh.Enabled = True
		Me.cmdRefresh.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdRefresh.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdRefresh.Name = "cmdRefresh"
		Me.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAdd.Text = "Add"
		Me.cmdAdd.Size = New System.Drawing.Size(65, 20)
		Me.cmdAdd.Location = New System.Drawing.Point(8, 416)
		Me.cmdAdd.TabIndex = 0
		Me.cmdAdd.TabStop = False
		Me.cmdAdd.Visible = False
		Me.cmdAdd.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAdd.CausesValidation = True
		Me.cmdAdd.Enabled = True
		Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAdd.Name = "cmdAdd"
		Me.Data1.Size = New System.Drawing.Size(624, 23)
		Me.Data1.Location = New System.Drawing.Point(0, 430)
		Me.Data1.Visible = False
		Me.Data1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Data1.BackColor = System.Drawing.Color.Red
		Me.Data1.ForeColor = System.Drawing.Color.Black
		Me.Data1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Data1.Text = "Data1"
		Me.Data1.Name = "Data1"
		Me.Label3.Text = "This is for Government, Sub Contract, and Private Sales"
		Me.Label3.Size = New System.Drawing.Size(289, 17)
		Me.Label3.Location = New System.Drawing.Point(72, 8)
		Me.Label3.TabIndex = 20
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
		Me.Label2.Text = "Be sure to click on both Verify and Load Data Files after entering the date range above."
		Me.Label2.Size = New System.Drawing.Size(169, 49)
		Me.Label2.Location = New System.Drawing.Point(80, 128)
		Me.Label2.TabIndex = 19
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
		Me.Label4.Text = "Enter Month Begin Date"
		Me.Label4.Size = New System.Drawing.Size(134, 17)
		Me.Label4.Location = New System.Drawing.Point(70, 91)
		Me.Label4.TabIndex = 13
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
		Me.Label1.Text = "Enter the beginning date of month and the ending date of month. The month end date is used as the aging date."
		Me.Label1.Size = New System.Drawing.Size(431, 34)
		Me.Label1.Location = New System.Drawing.Point(74, 47)
		Me.Label1.TabIndex = 9
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
		Me._lblLabels_1.Text = "Enter Month End Date"
		Me._lblLabels_1.Size = New System.Drawing.Size(116, 17)
		Me._lblLabels_1.Location = New System.Drawing.Point(320, 93)
		Me._lblLabels_1.TabIndex = 8
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
		Me._lblLabels_0.Text = "BEG_DATE:"
		Me._lblLabels_0.Size = New System.Drawing.Size(60, 17)
		Me._lblLabels_0.Location = New System.Drawing.Point(151, 416)
		Me._lblLabels_0.TabIndex = 6
		Me._lblLabels_0.Visible = False
		Me._lblLabels_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblLabels_0.BackColor = System.Drawing.SystemColors.Control
		Me._lblLabels_0.Enabled = True
		Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_0.UseMnemonic = True
		Me._lblLabels_0.AutoSize = False
		Me._lblLabels_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_0.Name = "_lblLabels_0"
		Me.Controls.Add(nam_cust)
		Me.Controls.Add(cust_age)
		Me.Controls.Add(calc_prior)
		Me.Controls.Add(Command8)
		Me.Controls.Add(Command7)
		Me.Controls.Add(Command6)
		Me.Controls.Add(Command5)
		Me.Controls.Add(Command1)
		Me.Controls.Add(_txtFields_2)
		Me.Controls.Add(cash)
		Me.Controls.Add(aropn)
		Me.Controls.Add(invoice)
		Me.Controls.Add(Command4)
		Me.Controls.Add(Command3)
		Me.Controls.Add(Command2)
		Me.Controls.Add(_txtFields_1)
		Me.Controls.Add(_txtFields_0)
		Me.Controls.Add(cmdClose)
		Me.Controls.Add(cmdUpdate)
		Me.Controls.Add(cmdRefresh)
		Me.Controls.Add(cmdAdd)
		Me.Controls.Add(Data1)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label1)
		Me.Controls.Add(_lblLabels_1)
		Me.Controls.Add(_lblLabels_0)
		Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
		Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
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