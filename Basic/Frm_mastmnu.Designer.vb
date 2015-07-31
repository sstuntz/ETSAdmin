<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frm_Mastmnu
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
	Public WithEvents EXMAIN As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents mnu As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents namad As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents type As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents ADDDA As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents name_full As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents nam_type As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents nam_date As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents nam_full_type As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents type_nam As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents rptlab As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frm_Mastmnu))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.MainMenu1 = New System.Windows.Forms.MenuStrip
		Me.mnu = New System.Windows.Forms.ToolStripMenuItem
		Me.EXMAIN = New System.Windows.Forms.ToolStripMenuItem
		Me.ADDDA = New System.Windows.Forms.ToolStripMenuItem
		Me.namad = New System.Windows.Forms.ToolStripMenuItem
		Me.type = New System.Windows.Forms.ToolStripMenuItem
		Me.rptlab = New System.Windows.Forms.ToolStripMenuItem
		Me.name_full = New System.Windows.Forms.ToolStripMenuItem
		Me.nam_type = New System.Windows.Forms.ToolStripMenuItem
		Me.nam_date = New System.Windows.Forms.ToolStripMenuItem
		Me.nam_full_type = New System.Windows.Forms.ToolStripMenuItem
		Me.type_nam = New System.Windows.Forms.ToolStripMenuItem
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.MainMenu1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "ETS Master Name/Address Menu"
		Me.ClientSize = New System.Drawing.Size(551, 367)
		Me.Location = New System.Drawing.Point(73, 111)
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
		Me.Name = "frm_Mastmnu"
		Me.mnu.Name = "mnu"
		Me.mnu.Text = "Menu"
		Me.mnu.Checked = False
		Me.mnu.Enabled = True
		Me.mnu.Visible = True
		Me.EXMAIN.Name = "EXMAIN"
		Me.EXMAIN.Text = "Exit to ETS Main Menu"
		Me.EXMAIN.Checked = False
		Me.EXMAIN.Enabled = True
		Me.EXMAIN.Visible = True
		Me.ADDDA.Name = "ADDDA"
		Me.ADDDA.Text = "Add/Edit Data"
		Me.ADDDA.Checked = False
		Me.ADDDA.Enabled = True
		Me.ADDDA.Visible = True
		Me.namad.Name = "namad"
		Me.namad.Text = "Name/Address"
		Me.namad.Checked = False
		Me.namad.Enabled = True
		Me.namad.Visible = True
		Me.type.Name = "type"
		Me.type.Text = "Types"
		Me.type.Checked = False
		Me.type.Enabled = True
		Me.type.Visible = True
		Me.rptlab.Name = "rptlab"
		Me.rptlab.Text = "Reports"
		Me.rptlab.Checked = False
		Me.rptlab.Enabled = True
		Me.rptlab.Visible = True
		Me.name_full.Name = "name_full"
		Me.name_full.Text = "All Names Alphabetically"
		Me.name_full.Checked = False
		Me.name_full.Enabled = True
		Me.name_full.Visible = True
		Me.nam_type.Name = "nam_type"
		Me.nam_type.Text = "Names for a Type"
		Me.nam_type.Checked = False
		Me.nam_type.Enabled = True
		Me.nam_type.Visible = True
		Me.nam_date.Name = "nam_date"
		Me.nam_date.Text = "Names for an Entry Date"
		Me.nam_date.Checked = False
		Me.nam_date.Enabled = True
		Me.nam_date.Visible = True
		Me.nam_full_type.Name = "nam_full_type"
		Me.nam_full_type.Text = "All Names by Type"
		Me.nam_full_type.Checked = False
		Me.nam_full_type.Enabled = True
		Me.nam_full_type.Visible = True
		Me.type_nam.Name = "type_nam"
		Me.type_nam.Text = "Types for Names"
		Me.type_nam.Checked = False
		Me.type_nam.Enabled = True
		Me.type_nam.Visible = True
		Me.Label5.Text = "typelist 5"
		Me.Label5.Size = New System.Drawing.Size(65, 17)
		Me.Label5.Location = New System.Drawing.Point(256, 120)
		Me.Label5.TabIndex = 4
		Me.Label5.Visible = False
		Me.Label5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "nametype - 4"
		Me.Label4.Size = New System.Drawing.Size(65, 17)
		Me.Label4.Location = New System.Drawing.Point(256, 96)
		Me.Label4.TabIndex = 3
		Me.Label4.Visible = False
		Me.Label4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "namedate - 3"
		Me.Label3.Size = New System.Drawing.Size(73, 17)
		Me.Label3.Location = New System.Drawing.Point(256, 72)
		Me.Label3.TabIndex = 2
		Me.Label3.Visible = False
		Me.Label3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "namecon - 2"
		Me.Label2.Size = New System.Drawing.Size(73, 17)
		Me.Label2.Location = New System.Drawing.Point(256, 48)
		Me.Label2.TabIndex = 1
		Me.Label2.Visible = False
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "namall -1"
		Me.Label1.Size = New System.Drawing.Size(65, 17)
		Me.Label1.Location = New System.Drawing.Point(256, 24)
		Me.Label1.TabIndex = 0
		Me.Label1.Visible = False
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me.mnu, Me.ADDDA, Me.rptlab})
		mnu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.EXMAIN})
		ADDDA.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.namad, Me.type})
		rptlab.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem(){Me.name_full, Me.nam_type, Me.nam_date, Me.nam_full_type, Me.type_nam})
		Me.Controls.Add(MainMenu1)
		Me.MainMenu1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class