<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class ccckrecon_frm
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
	Public WithEvents cmdsave As System.Windows.Forms.Button
	Public WithEvents tot_cks As System.Windows.Forms.TextBox
	Public WithEvents Text2 As System.Windows.Forms.TextBox
	Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents data2 As System.Windows.Forms.Label
	Public WithEvents finished As System.Windows.Forms.Button
	Public WithEvents tot As System.Windows.Forms.TextBox
	Public WithEvents checknum As System.Windows.Forms.TextBox
	Public WithEvents proof As System.Windows.Forms.Button
	Public WithEvents reverse As System.Windows.Forms.Button
	Public WithEvents cmdcancel As System.Windows.Forms.Button
	Public WithEvents recon_date As System.Windows.Forms.TextBox
	Public WithEvents Data1 As System.Windows.Forms.Label
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ccckrecon_frm))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdsave = New System.Windows.Forms.Button
		Me.tot_cks = New System.Windows.Forms.TextBox
		Me.Text2 = New System.Windows.Forms.TextBox
		Me.Text1 = New System.Windows.Forms.TextBox
		Me.data2 = New System.Windows.Forms.Label
		Me.finished = New System.Windows.Forms.Button
		Me.tot = New System.Windows.Forms.TextBox
		Me.checknum = New System.Windows.Forms.TextBox
		Me.proof = New System.Windows.Forms.Button
		Me.reverse = New System.Windows.Forms.Button
		Me.cmdcancel = New System.Windows.Forms.Button
		Me.recon_date = New System.Windows.Forms.TextBox
		Me.Data1 = New System.Windows.Forms.Label
		Me.Command2 = New System.Windows.Forms.Button
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "CC Payroll Check Reconciliation"
		Me.ClientSize = New System.Drawing.Size(631, 447)
		Me.Location = New System.Drawing.Point(-4, 20)
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
		Me.Name = "ccckrecon_frm"
		Me.cmdsave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdsave.Text = "Save"
		Me.cmdsave.Size = New System.Drawing.Size(70, 30)
		Me.cmdsave.Location = New System.Drawing.Point(524, 385)
		Me.cmdsave.TabIndex = 18
		Me.cmdsave.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdsave.BackColor = System.Drawing.SystemColors.Control
		Me.cmdsave.CausesValidation = True
		Me.cmdsave.Enabled = True
		Me.cmdsave.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdsave.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdsave.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdsave.TabStop = True
		Me.cmdsave.Name = "cmdsave"
		Me.tot_cks.AutoSize = False
		Me.tot_cks.Size = New System.Drawing.Size(71, 19)
		Me.tot_cks.Location = New System.Drawing.Point(482, 256)
		Me.tot_cks.TabIndex = 17
		Me.tot_cks.Tag = "tot_cks"
		Me.tot_cks.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tot_cks.AcceptsReturn = True
		Me.tot_cks.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.tot_cks.BackColor = System.Drawing.SystemColors.Window
		Me.tot_cks.CausesValidation = True
		Me.tot_cks.Enabled = True
		Me.tot_cks.ForeColor = System.Drawing.SystemColors.WindowText
		Me.tot_cks.HideSelection = True
		Me.tot_cks.ReadOnly = False
		Me.tot_cks.Maxlength = 0
		Me.tot_cks.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.tot_cks.MultiLine = False
		Me.tot_cks.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.tot_cks.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.tot_cks.TabStop = True
		Me.tot_cks.Visible = True
		Me.tot_cks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.tot_cks.Name = "tot_cks"
		Me.Text2.AutoSize = False
		Me.Text2.Enabled = False
		Me.Text2.Size = New System.Drawing.Size(97, 19)
		Me.Text2.Location = New System.Drawing.Point(416, 88)
		Me.Text2.TabIndex = 15
		Me.Text2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Text2.AcceptsReturn = True
		Me.Text2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.Text2.BackColor = System.Drawing.SystemColors.Window
		Me.Text2.CausesValidation = True
		Me.Text2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Text2.HideSelection = True
		Me.Text2.ReadOnly = False
		Me.Text2.Maxlength = 0
		Me.Text2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text2.MultiLine = False
		Me.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.Text2.TabStop = True
		Me.Text2.Visible = True
		Me.Text2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Text2.Name = "Text2"
		Me.Text1.AutoSize = False
		Me.Text1.Enabled = False
		Me.Text1.Size = New System.Drawing.Size(217, 19)
		Me.Text1.Location = New System.Drawing.Point(176, 88)
		Me.Text1.TabIndex = 14
		Me.Text1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Text1.AcceptsReturn = True
		Me.Text1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.Text1.BackColor = System.Drawing.SystemColors.Window
		Me.Text1.CausesValidation = True
		Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Text1.HideSelection = True
		Me.Text1.ReadOnly = False
		Me.Text1.Maxlength = 0
		Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text1.MultiLine = False
		Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.Text1.TabStop = True
		Me.Text1.Visible = True
		Me.Text1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Text1.Name = "Text1"
		Me.data2.Text = "rpthead"
		Me.data2.Size = New System.Drawing.Size(121, 25)
		Me.data2.Location = New System.Drawing.Point(144, 424)
		Me.data2.Visible = False
		Me.data2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.data2.BackColor = System.Drawing.Color.Red
		Me.data2.ForeColor = System.Drawing.Color.Black
		Me.data2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.data2.Text = "data2"
		Me.data2.Name = "data2"
		Me.finished.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.finished.Text = "Finished entering check#'s..continue Recon process"
		Me.finished.Size = New System.Drawing.Size(297, 33)
		Me.finished.Location = New System.Drawing.Point(256, 40)
		Me.finished.TabIndex = 10
		Me.finished.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.finished.BackColor = System.Drawing.SystemColors.Control
		Me.finished.CausesValidation = True
		Me.finished.Enabled = True
		Me.finished.ForeColor = System.Drawing.SystemColors.ControlText
		Me.finished.Cursor = System.Windows.Forms.Cursors.Default
		Me.finished.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.finished.TabStop = True
		Me.finished.Name = "finished"
		Me.tot.AutoSize = False
		Me.tot.Size = New System.Drawing.Size(81, 19)
		Me.tot.Location = New System.Drawing.Point(272, 256)
		Me.tot.TabIndex = 9
		Me.tot.Tag = "tot"
		Me.tot.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tot.AcceptsReturn = True
		Me.tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.tot.BackColor = System.Drawing.SystemColors.Window
		Me.tot.CausesValidation = True
		Me.tot.Enabled = True
		Me.tot.ForeColor = System.Drawing.SystemColors.WindowText
		Me.tot.HideSelection = True
		Me.tot.ReadOnly = False
		Me.tot.Maxlength = 0
		Me.tot.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.tot.MultiLine = False
		Me.tot.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.tot.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.tot.TabStop = True
		Me.tot.Visible = True
		Me.tot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.tot.Name = "tot"
		Me.checknum.AutoSize = False
		Me.checknum.Size = New System.Drawing.Size(49, 25)
		Me.checknum.Location = New System.Drawing.Point(176, 48)
		Me.checknum.TabIndex = 8
		Me.checknum.Tag = "checknum"
		Me.checknum.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.checknum.AcceptsReturn = True
		Me.checknum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.checknum.BackColor = System.Drawing.SystemColors.Window
		Me.checknum.CausesValidation = True
		Me.checknum.Enabled = True
		Me.checknum.ForeColor = System.Drawing.SystemColors.WindowText
		Me.checknum.HideSelection = True
		Me.checknum.ReadOnly = False
		Me.checknum.Maxlength = 0
		Me.checknum.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.checknum.MultiLine = False
		Me.checknum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.checknum.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.checknum.TabStop = True
		Me.checknum.Visible = True
		Me.checknum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.checknum.Name = "checknum"
		Me.proof.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.proof.Text = "Checks Returned Proof"
		Me.proof.Size = New System.Drawing.Size(145, 33)
		Me.proof.Location = New System.Drawing.Point(352, 320)
		Me.proof.TabIndex = 6
		Me.proof.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.proof.BackColor = System.Drawing.SystemColors.Control
		Me.proof.CausesValidation = True
		Me.proof.Enabled = True
		Me.proof.ForeColor = System.Drawing.SystemColors.ControlText
		Me.proof.Cursor = System.Windows.Forms.Cursors.Default
		Me.proof.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.proof.TabStop = True
		Me.proof.Name = "proof"
		Me.reverse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.reverse.Text = "Un-Recon Check#"
		Me.reverse.Size = New System.Drawing.Size(121, 33)
		Me.reverse.Location = New System.Drawing.Point(8, 264)
		Me.reverse.TabIndex = 5
		Me.reverse.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.reverse.BackColor = System.Drawing.SystemColors.Control
		Me.reverse.CausesValidation = True
		Me.reverse.Enabled = True
		Me.reverse.ForeColor = System.Drawing.SystemColors.ControlText
		Me.reverse.Cursor = System.Windows.Forms.Cursors.Default
		Me.reverse.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.reverse.TabStop = True
		Me.reverse.Name = "reverse"
		Me.cmdcancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdcancel.Text = "Cancel"
		Me.cmdcancel.Size = New System.Drawing.Size(87, 25)
		Me.cmdcancel.Location = New System.Drawing.Point(525, 4)
		Me.cmdcancel.TabIndex = 3
		Me.cmdcancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdcancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdcancel.CausesValidation = True
		Me.cmdcancel.Enabled = True
		Me.cmdcancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdcancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdcancel.TabStop = True
		Me.cmdcancel.Name = "cmdcancel"
		Me.recon_date.AutoSize = False
		Me.recon_date.Size = New System.Drawing.Size(73, 25)
		Me.recon_date.Location = New System.Drawing.Point(288, 8)
		Me.recon_date.TabIndex = 1
		Me.recon_date.Tag = "recon_date"
		Me.recon_date.Text = " "
		Me.recon_date.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.recon_date.AcceptsReturn = True
		Me.recon_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.recon_date.BackColor = System.Drawing.SystemColors.Window
		Me.recon_date.CausesValidation = True
		Me.recon_date.Enabled = True
		Me.recon_date.ForeColor = System.Drawing.SystemColors.WindowText
		Me.recon_date.HideSelection = True
		Me.recon_date.ReadOnly = False
		Me.recon_date.Maxlength = 0
		Me.recon_date.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.recon_date.MultiLine = False
		Me.recon_date.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.recon_date.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.recon_date.TabStop = True
		Me.recon_date.Visible = True
		Me.recon_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.recon_date.Name = "recon_date"
		Me.Data1.Text = "ccrecon"
		Me.Data1.Size = New System.Drawing.Size(105, 25)
		Me.Data1.Location = New System.Drawing.Point(0, 424)
		Me.Data1.Visible = False
		Me.Data1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Data1.BackColor = System.Drawing.Color.Red
		Me.Data1.ForeColor = System.Drawing.Color.Black
		Me.Data1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Data1.Text = "Data1"
		Me.Data1.Name = "Data1"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.Text = "Outstanding Checks Report"
		Me.Command2.Size = New System.Drawing.Size(145, 33)
		Me.Command2.Location = New System.Drawing.Point(352, 384)
		Me.Command2.TabIndex = 2
		Me.Command2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.Label7.Text = "Number of Checks"
		Me.Label7.Size = New System.Drawing.Size(95, 12)
		Me.Label7.Location = New System.Drawing.Point(378, 257)
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
		Me.Label2.Text = "Total Amount"
		Me.Label2.Size = New System.Drawing.Size(73, 17)
		Me.Label2.Location = New System.Drawing.Point(184, 256)
		Me.Label2.TabIndex = 13
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
		Me.Label6.Text = "Click on the button to the right to print Outstanding Checks Report.  This can be reprinted."
		Me.Label6.Size = New System.Drawing.Size(193, 41)
		Me.Label6.Location = New System.Drawing.Point(112, 384)
		Me.Label6.TabIndex = 12
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
		Me.Label5.Text = "Click on the button to the right to print the checks Returned Proof.  This can be reprinted."
		Me.Label5.Size = New System.Drawing.Size(193, 41)
		Me.Label5.Location = New System.Drawing.Point(112, 320)
		Me.Label5.TabIndex = 11
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
		Me.Label4.Text = "Enter each Check#------->"
		Me.Label4.Size = New System.Drawing.Size(129, 17)
		Me.Label4.Location = New System.Drawing.Point(24, 48)
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
		Me.Label3.Text = "To Un-recon a Check, use mouse to select an entry...Then select the button below.  "
		Me.Label3.Size = New System.Drawing.Size(113, 65)
		Me.Label3.Location = New System.Drawing.Point(8, 128)
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
		Me.Label1.Text = "Enter the Recon Date to the right and then enter each  CHECK#  that is in the statement."
		Me.Label1.Size = New System.Drawing.Size(249, 25)
		Me.Label1.Location = New System.Drawing.Point(24, 8)
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
		Me.Controls.Add(cmdsave)
		Me.Controls.Add(tot_cks)
		Me.Controls.Add(Text2)
		Me.Controls.Add(Text1)
		Me.Controls.Add(data2)
		Me.Controls.Add(finished)
		Me.Controls.Add(tot)
		Me.Controls.Add(checknum)
		Me.Controls.Add(proof)
		Me.Controls.Add(reverse)
		Me.Controls.Add(cmdcancel)
		Me.Controls.Add(recon_date)
		Me.Controls.Add(Data1)
		Me.Controls.Add(Command2)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class