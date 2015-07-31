<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class applk
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
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents _txtfields_0 As System.Windows.Forms.TextBox
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents Data1 As System.Windows.Forms.Label
	Public WithEvents edit As System.Windows.Forms.Button
	Public WithEvents addacct As System.Windows.Forms.Button
	Public WithEvents Cancel As System.Windows.Forms.Button
	Public WithEvents Accept As System.Windows.Forms.Button
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents txtfields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(applk))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command2 = New System.Windows.Forms.Button
		Me._txtfields_0 = New System.Windows.Forms.TextBox
		Me.Command1 = New System.Windows.Forms.Button
		Me.Data1 = New System.Windows.Forms.Label
		Me.edit = New System.Windows.Forms.Button
		Me.addacct = New System.Windows.Forms.Button
		Me.Cancel = New System.Windows.Forms.Button
		Me.Accept = New System.Windows.Forms.Button
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.txtfields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.txtfields, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Add/Edit Reimbursement Checks"
		Me.ClientSize = New System.Drawing.Size(627, 442)
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
		Me.Name = "applk"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.Text = "Refresh List "
		Me.Command2.Size = New System.Drawing.Size(105, 33)
		Me.Command2.Location = New System.Drawing.Point(488, 168)
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
		Me._txtfields_0.AutoSize = False
		Me._txtfields_0.Tag = "dt_paid"
		Me._txtfields_0.Size = New System.Drawing.Size(81, 19)
		Me._txtfields_0.Location = New System.Drawing.Point(504, 72)
		Me._txtfields_0.TabIndex = 7
		Me._txtfields_0.Text = " "
		Me._txtfields_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtfields_0.AcceptsReturn = True
		Me._txtfields_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtfields_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtfields_0.CausesValidation = True
		Me._txtfields_0.Enabled = True
		Me._txtfields_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtfields_0.HideSelection = True
		Me._txtfields_0.ReadOnly = False
		Me._txtfields_0.Maxlength = 0
		Me._txtfields_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtfields_0.MultiLine = False
		Me._txtfields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtfields_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtfields_0.TabStop = True
		Me._txtfields_0.Visible = True
		Me._txtfields_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtfields_0.Name = "_txtfields_0"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Refresh List by Check Date above"
		Me.Command1.Size = New System.Drawing.Size(105, 49)
		Me.Command1.Location = New System.Drawing.Point(488, 104)
		Me.Command1.TabIndex = 6
		Me.Command1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.Data1.Text = "Data1"
		Me.Data1.Size = New System.Drawing.Size(113, 20)
		Me.Data1.Location = New System.Drawing.Point(472, 416)
		Me.Data1.Visible = False
		Me.Data1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Data1.BackColor = System.Drawing.Color.Red
		Me.Data1.ForeColor = System.Drawing.Color.Black
		Me.Data1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Data1.Text = "Data1"
		Me.Data1.Name = "Data1"
		Me.edit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.edit.Text = "Edit"
		Me.edit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.edit.Size = New System.Drawing.Size(73, 49)
		Me.edit.Location = New System.Drawing.Point(496, 288)
		Me.edit.TabIndex = 1
		Me.edit.BackColor = System.Drawing.SystemColors.Control
		Me.edit.CausesValidation = True
		Me.edit.Enabled = True
		Me.edit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.edit.Cursor = System.Windows.Forms.Cursors.Default
		Me.edit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.edit.TabStop = True
		Me.edit.Name = "edit"
		Me.addacct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.addacct.Text = "Add"
		Me.addacct.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.addacct.Size = New System.Drawing.Size(73, 49)
		Me.addacct.Location = New System.Drawing.Point(496, 352)
		Me.addacct.TabIndex = 2
		Me.addacct.BackColor = System.Drawing.SystemColors.Control
		Me.addacct.CausesValidation = True
		Me.addacct.Enabled = True
		Me.addacct.ForeColor = System.Drawing.SystemColors.ControlText
		Me.addacct.Cursor = System.Windows.Forms.Cursors.Default
		Me.addacct.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.addacct.TabStop = True
		Me.addacct.Name = "addacct"
		Me.Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Cancel.Text = "Exit to AP Menu"
		Me.Cancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Cancel.Size = New System.Drawing.Size(136, 25)
		Me.Cancel.Location = New System.Drawing.Point(488, 4)
		Me.Cancel.TabIndex = 3
		Me.Cancel.BackColor = System.Drawing.SystemColors.Control
		Me.Cancel.CausesValidation = True
		Me.Cancel.Enabled = True
		Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Cancel.TabStop = True
		Me.Cancel.Name = "Cancel"
		Me.Accept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Accept.Text = "Use Selected Name"
		Me.Accept.Enabled = False
		Me.Accept.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Accept.Size = New System.Drawing.Size(129, 49)
		Me.Accept.Location = New System.Drawing.Point(470, 224)
		Me.Accept.TabIndex = 0
		Me.Accept.BackColor = System.Drawing.SystemColors.Control
		Me.Accept.CausesValidation = True
		Me.Accept.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Accept.Cursor = System.Windows.Forms.Cursors.Default
		Me.Accept.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Accept.TabStop = True
		Me.Accept.Name = "Accept"
		Me.Label3.Text = "Enter a Check Date in the box --->"
		Me.Label3.Size = New System.Drawing.Size(97, 41)
		Me.Label3.Location = New System.Drawing.Point(392, 64)
		Me.Label3.TabIndex = 8
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
		Me.Label2.Text = "Records that are in the list have been previously added.  Select a record and edit the information. Use a common check date for a batch to be selected. Change any other information and then Print Edit Report and/or go to Print Misc Checks."
		Me.Label2.Size = New System.Drawing.Size(329, 65)
		Me.Label2.Location = New System.Drawing.Point(48, 48)
		Me.Label2.TabIndex = 5
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
		Me.Label1.Text = "Highlight a record and click on EDIT or select ADD to add a new record."
		Me.Label1.Size = New System.Drawing.Size(371, 24)
		Me.Label1.Location = New System.Drawing.Point(48, 15)
		Me.Label1.TabIndex = 4
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
		Me.Controls.Add(Command2)
		Me.Controls.Add(_txtfields_0)
		Me.Controls.Add(Command1)
		Me.Controls.Add(Data1)
		Me.Controls.Add(edit)
		Me.Controls.Add(addacct)
		Me.Controls.Add(Cancel)
		Me.Controls.Add(Accept)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.txtfields.SetIndex(_txtfields_0, CType(0, Short))
		CType(Me.txtfields, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class