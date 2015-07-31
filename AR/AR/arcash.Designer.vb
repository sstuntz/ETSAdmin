<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmarcash
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
	Public WithEvents _txtfields_19 As System.Windows.Forms.TextBox
	Public WithEvents _txtfields_18 As System.Windows.Forms.TextBox
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
	Public WithEvents cmdRefresh As System.Windows.Forms.Button
	Public WithEvents cmdAdd As System.Windows.Forms.Button
	Public WithEvents Data1 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_19 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_18 As System.Windows.Forms.Label
	Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents txtfields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmarcash))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me._txtfields_19 = New System.Windows.Forms.TextBox
		Me._txtfields_18 = New System.Windows.Forms.TextBox
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdUpdate = New System.Windows.Forms.Button
		Me.cmdRefresh = New System.Windows.Forms.Button
		Me.cmdAdd = New System.Windows.Forms.Button
		Me.Data1 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me._lblLabels_19 = New System.Windows.Forms.Label
		Me._lblLabels_18 = New System.Windows.Forms.Label
		Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.txtfields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtfields, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "View  Cash Receipts"
		Me.ClientSize = New System.Drawing.Size(626, 436)
		Me.Location = New System.Drawing.Point(7, 29)
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
		Me.Name = "frmarcash"
		Me._txtfields_19.AutoSize = False
		Me._txtfields_19.Tag = "donor"
		Me._txtfields_19.Size = New System.Drawing.Size(189, 19)
		Me._txtfields_19.Location = New System.Drawing.Point(344, 372)
		Me._txtfields_19.Maxlength = 30
		Me._txtfields_19.TabIndex = 6
		Me._txtfields_19.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtfields_19.AcceptsReturn = True
		Me._txtfields_19.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtfields_19.BackColor = System.Drawing.SystemColors.Window
		Me._txtfields_19.CausesValidation = True
		Me._txtfields_19.Enabled = True
		Me._txtfields_19.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtfields_19.HideSelection = True
		Me._txtfields_19.ReadOnly = False
		Me._txtfields_19.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtfields_19.MultiLine = False
		Me._txtfields_19.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtfields_19.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtfields_19.TabStop = True
		Me._txtfields_19.Visible = True
		Me._txtfields_19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtfields_19.Name = "_txtfields_19"
		Me._txtfields_18.AutoSize = False
		Me._txtfields_18.Tag = "memo"
		Me._txtfields_18.Size = New System.Drawing.Size(188, 19)
		Me._txtfields_18.Location = New System.Drawing.Point(89, 377)
		Me._txtfields_18.Maxlength = 30
		Me._txtfields_18.TabIndex = 4
		Me._txtfields_18.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._txtfields_18.AcceptsReturn = True
		Me._txtfields_18.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtfields_18.BackColor = System.Drawing.SystemColors.Window
		Me._txtfields_18.CausesValidation = True
		Me._txtfields_18.Enabled = True
		Me._txtfields_18.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtfields_18.HideSelection = True
		Me._txtfields_18.ReadOnly = False
		Me._txtfields_18.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtfields_18.MultiLine = False
		Me._txtfields_18.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtfields_18.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtfields_18.TabStop = True
		Me._txtfields_18.Visible = True
		Me._txtfields_18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtfields_18.Name = "_txtfields_18"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "Cancel"
		Me.cmdClose.Size = New System.Drawing.Size(65, 20)
		Me.cmdClose.Location = New System.Drawing.Point(557, 0)
		Me.cmdClose.TabIndex = 2
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
		Me.cmdUpdate.Location = New System.Drawing.Point(558, 393)
		Me.cmdUpdate.TabIndex = 8
		Me.cmdUpdate.TabStop = False
		Me.cmdUpdate.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdUpdate.CausesValidation = True
		Me.cmdUpdate.Enabled = True
		Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdUpdate.Name = "cmdUpdate"
		Me.cmdRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdRefresh.Text = "Refresh"
		Me.cmdRefresh.Size = New System.Drawing.Size(65, 20)
		Me.cmdRefresh.Location = New System.Drawing.Point(144, 412)
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
		Me.cmdAdd.Location = New System.Drawing.Point(55, 410)
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
		Me.Data1.Size = New System.Drawing.Size(626, 23)
		Me.Data1.Location = New System.Drawing.Point(0, 413)
		Me.Data1.Visible = False
		Me.Data1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Data1.BackColor = System.Drawing.Color.Red
		Me.Data1.ForeColor = System.Drawing.Color.Black
		Me.Data1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Data1.Text = "Data1"
		Me.Data1.Name = "Data1"
		Me.Label3.Text = "Highlight a record and then change the data below.  Save all changes."
		Me.Label3.Size = New System.Drawing.Size(368, 18)
		Me.Label3.Location = New System.Drawing.Point(16, 41)
		Me.Label3.TabIndex = 10
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
		Me.Label2.Text = "Be sure to save all changes."
		Me.Label2.Size = New System.Drawing.Size(140, 19)
		Me.Label2.Location = New System.Drawing.Point(409, 395)
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
		Me.Label1.Text = "This screen will allow you to VIEW cash receipts.  You can only change the memo and donor fields .  If a check is applied incorrectly, you must void the cash receipt and re-enter it.  "
		Me.Label1.Size = New System.Drawing.Size(529, 30)
		Me.Label1.Location = New System.Drawing.Point(17, 12)
		Me.Label1.TabIndex = 7
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
		Me._lblLabels_19.Text = "donor:"
		Me._lblLabels_19.Size = New System.Drawing.Size(47, 17)
		Me._lblLabels_19.Location = New System.Drawing.Point(290, 374)
		Me._lblLabels_19.TabIndex = 5
		Me._lblLabels_19.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblLabels_19.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblLabels_19.BackColor = System.Drawing.SystemColors.Control
		Me._lblLabels_19.Enabled = True
		Me._lblLabels_19.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_19.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_19.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_19.UseMnemonic = True
		Me._lblLabels_19.Visible = True
		Me._lblLabels_19.AutoSize = False
		Me._lblLabels_19.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_19.Name = "_lblLabels_19"
		Me._lblLabels_18.Text = "memo:"
		Me._lblLabels_18.Size = New System.Drawing.Size(60, 17)
		Me._lblLabels_18.Location = New System.Drawing.Point(12, 378)
		Me._lblLabels_18.TabIndex = 3
		Me._lblLabels_18.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._lblLabels_18.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblLabels_18.BackColor = System.Drawing.SystemColors.Control
		Me._lblLabels_18.Enabled = True
		Me._lblLabels_18.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_18.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_18.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_18.UseMnemonic = True
		Me._lblLabels_18.Visible = True
		Me._lblLabels_18.AutoSize = False
		Me._lblLabels_18.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_18.Name = "_lblLabels_18"
		Me.Controls.Add(_txtfields_19)
		Me.Controls.Add(_txtfields_18)
		Me.Controls.Add(cmdClose)
		Me.Controls.Add(cmdUpdate)
		Me.Controls.Add(cmdRefresh)
		Me.Controls.Add(cmdAdd)
		Me.Controls.Add(Data1)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Controls.Add(_lblLabels_19)
		Me.Controls.Add(_lblLabels_18)
		Me.lblLabels.SetIndex(_lblLabels_19, CType(19, Short))
		Me.lblLabels.SetIndex(_lblLabels_18, CType(18, Short))
		Me.txtfields.SetIndex(_txtfields_19, CType(19, Short))
		Me.txtfields.SetIndex(_txtfields_18, CType(18, Short))
		CType(Me.txtfields, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class