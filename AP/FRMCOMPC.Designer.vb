<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmcompchk
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
	Public WithEvents one_vouch As System.Windows.Forms.TextBox
	Public WithEvents single_Renamed As System.Windows.Forms.Button
	Public WithEvents prtchksel As System.Windows.Forms.Button
	Public WithEvents prtreg As System.Windows.Forms.Button
	Public WithEvents prtedit As System.Windows.Forms.Button
	Public WithEvents chkdate As System.Windows.Forms.TextBox
	Public WithEvents cancel As System.Windows.Forms.Button
	Public WithEvents begchknum As System.Windows.Forms.TextBox
	Public WithEvents endchkdate As System.Windows.Forms.TextBox
	Public WithEvents begchkdate As System.Windows.Forms.TextBox
	Public WithEvents specific_Chk As System.Windows.Forms.Button
	Public WithEvents range As System.Windows.Forms.Button
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.one_vouch = New System.Windows.Forms.TextBox
        Me.single_Renamed = New System.Windows.Forms.Button
        Me.prtchksel = New System.Windows.Forms.Button
        Me.prtreg = New System.Windows.Forms.Button
        Me.prtedit = New System.Windows.Forms.Button
        Me.chkdate = New System.Windows.Forms.TextBox
        Me.cancel = New System.Windows.Forms.Button
        Me.begchknum = New System.Windows.Forms.TextBox
        Me.endchkdate = New System.Windows.Forms.TextBox
        Me.begchkdate = New System.Windows.Forms.TextBox
        Me.specific_Chk = New System.Windows.Forms.Button
        Me.range = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BankName = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'one_vouch
        '
        Me.one_vouch.AcceptsReturn = True
        Me.one_vouch.BackColor = System.Drawing.SystemColors.Window
        Me.one_vouch.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.one_vouch.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.one_vouch.ForeColor = System.Drawing.SystemColors.WindowText
        Me.one_vouch.Location = New System.Drawing.Point(538, 145)
        Me.one_vouch.MaxLength = 0
        Me.one_vouch.Name = "one_vouch"
        Me.one_vouch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.one_vouch.Size = New System.Drawing.Size(72, 20)
        Me.one_vouch.TabIndex = 17
        Me.one_vouch.Visible = False
        '
        'single_Renamed
        '
        Me.single_Renamed.BackColor = System.Drawing.SystemColors.Control
        Me.single_Renamed.Cursor = System.Windows.Forms.Cursors.Default
        Me.single_Renamed.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.single_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
        Me.single_Renamed.Location = New System.Drawing.Point(440, 112)
        Me.single_Renamed.Name = "single_Renamed"
        Me.single_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.single_Renamed.Size = New System.Drawing.Size(170, 25)
        Me.single_Renamed.TabIndex = 16
        Me.single_Renamed.Text = "Select Individual Vouchers"
        Me.single_Renamed.UseVisualStyleBackColor = False
        '
        'prtchksel
        '
        Me.prtchksel.BackColor = System.Drawing.SystemColors.Control
        Me.prtchksel.Cursor = System.Windows.Forms.Cursors.Default
        Me.prtchksel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prtchksel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.prtchksel.Location = New System.Drawing.Point(228, 324)
        Me.prtchksel.Name = "prtchksel"
        Me.prtchksel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.prtchksel.Size = New System.Drawing.Size(161, 33)
        Me.prtchksel.TabIndex = 6
        Me.prtchksel.Text = "Print Pre-Check Edit"
        Me.prtchksel.UseVisualStyleBackColor = False
        Me.prtchksel.Visible = False
        '
        'prtreg
        '
        Me.prtreg.BackColor = System.Drawing.SystemColors.Control
        Me.prtreg.Cursor = System.Windows.Forms.Cursors.Default
        Me.prtreg.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prtreg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.prtreg.Location = New System.Drawing.Point(188, 388)
        Me.prtreg.Name = "prtreg"
        Me.prtreg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.prtreg.Size = New System.Drawing.Size(233, 33)
        Me.prtreg.TabIndex = 7
        Me.prtreg.Text = "Update/Print Check Register"
        Me.prtreg.UseVisualStyleBackColor = False
        Me.prtreg.Visible = False
        '
        'prtedit
        '
        Me.prtedit.BackColor = System.Drawing.SystemColors.Control
        Me.prtedit.Cursor = System.Windows.Forms.Cursors.Default
        Me.prtedit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prtedit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.prtedit.Location = New System.Drawing.Point(12, 205)
        Me.prtedit.Name = "prtedit"
        Me.prtedit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.prtedit.Size = New System.Drawing.Size(182, 25)
        Me.prtedit.TabIndex = 3
        Me.prtedit.Text = "Verify Due Dates Selected"
        Me.prtedit.UseVisualStyleBackColor = False
        Me.prtedit.Visible = False
        '
        'chkdate
        '
        Me.chkdate.AcceptsReturn = True
        Me.chkdate.BackColor = System.Drawing.SystemColors.Window
        Me.chkdate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.chkdate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkdate.Location = New System.Drawing.Point(316, 284)
        Me.chkdate.MaxLength = 0
        Me.chkdate.Name = "chkdate"
        Me.chkdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkdate.Size = New System.Drawing.Size(81, 20)
        Me.chkdate.TabIndex = 5
        Me.chkdate.Visible = False
        '
        'cancel
        '
        Me.cancel.BackColor = System.Drawing.SystemColors.Control
        Me.cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cancel.Location = New System.Drawing.Point(536, -3)
        Me.cancel.Name = "cancel"
        Me.cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cancel.Size = New System.Drawing.Size(81, 25)
        Me.cancel.TabIndex = 13
        Me.cancel.Text = "Cancel"
        Me.cancel.UseVisualStyleBackColor = False
        '
        'begchknum
        '
        Me.begchknum.AcceptsReturn = True
        Me.begchknum.BackColor = System.Drawing.SystemColors.Window
        Me.begchknum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.begchknum.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.begchknum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.begchknum.Location = New System.Drawing.Point(316, 252)
        Me.begchknum.MaxLength = 0
        Me.begchknum.Name = "begchknum"
        Me.begchknum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.begchknum.Size = New System.Drawing.Size(81, 20)
        Me.begchknum.TabIndex = 4
        Me.begchknum.Visible = False
        '
        'endchkdate
        '
        Me.endchkdate.AcceptsReturn = True
        Me.endchkdate.BackColor = System.Drawing.SystemColors.Window
        Me.endchkdate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.endchkdate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.endchkdate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.endchkdate.Location = New System.Drawing.Point(112, 176)
        Me.endchkdate.MaxLength = 0
        Me.endchkdate.Name = "endchkdate"
        Me.endchkdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.endchkdate.Size = New System.Drawing.Size(81, 20)
        Me.endchkdate.TabIndex = 2
        Me.endchkdate.Visible = False
        '
        'begchkdate
        '
        Me.begchkdate.AcceptsReturn = True
        Me.begchkdate.BackColor = System.Drawing.SystemColors.Window
        Me.begchkdate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.begchkdate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.begchkdate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.begchkdate.Location = New System.Drawing.Point(112, 152)
        Me.begchkdate.MaxLength = 0
        Me.begchkdate.Name = "begchkdate"
        Me.begchkdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.begchkdate.Size = New System.Drawing.Size(81, 20)
        Me.begchkdate.TabIndex = 1
        Me.begchkdate.Visible = False
        '
        'specific_Chk
        '
        Me.specific_Chk.BackColor = System.Drawing.SystemColors.Control
        Me.specific_Chk.Cursor = System.Windows.Forms.Cursors.Default
        Me.specific_Chk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.specific_Chk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.specific_Chk.Location = New System.Drawing.Point(236, 112)
        Me.specific_Chk.Name = "specific_Chk"
        Me.specific_Chk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.specific_Chk.Size = New System.Drawing.Size(169, 25)
        Me.specific_Chk.TabIndex = 9
        Me.specific_Chk.Text = "Select All Unpaid Vouchers"
        Me.specific_Chk.UseVisualStyleBackColor = False
        '
        'range
        '
        Me.range.BackColor = System.Drawing.SystemColors.Control
        Me.range.Cursor = System.Windows.Forms.Cursors.Default
        Me.range.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.range.ForeColor = System.Drawing.SystemColors.ControlText
        Me.range.Location = New System.Drawing.Point(11, 112)
        Me.range.Name = "range"
        Me.range.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.range.Size = New System.Drawing.Size(183, 25)
        Me.range.TabIndex = 0
        Me.range.Text = "Select by Due Date Range"
        Me.range.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(88, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(433, 25)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "You can Add to an Existing Batch of Vouchers to be paid.  Answer the questions as" & _
            "ked carefully. "
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(442, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(83, 33)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Enter each Voucher# :"
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(74, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(173, 17)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "First select a  Bank:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(220, 284)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(97, 17)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Check Date"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(204, 252)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(105, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Begin Check Num"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 176)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(89, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "End  Due Date"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(105, 25)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Begin Due Date"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(88, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(429, 20)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Second, select one of the three ways to load the AP Check Writer File."
        '
        'BankName
        '
        Me.BankName.DisplayMember = "ScreenName"
        Me.BankName.FormattingEnabled = True
        Me.BankName.Location = New System.Drawing.Point(236, 13)
        Me.BankName.Name = "BankName"
        Me.BankName.Size = New System.Drawing.Size(196, 22)
        Me.BankName.TabIndex = 20
        Me.BankName.ValueMember = "TableKEy"
        '
        'frmcompchk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(624, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.BankName)
        Me.Controls.Add(Me.one_vouch)
        Me.Controls.Add(Me.single_Renamed)
        Me.Controls.Add(Me.prtchksel)
        Me.Controls.Add(Me.prtreg)
        Me.Controls.Add(Me.prtedit)
        Me.Controls.Add(Me.chkdate)
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.begchknum)
        Me.Controls.Add(Me.endchkdate)
        Me.Controls.Add(Me.begchkdate)
        Me.Controls.Add(Me.specific_Chk)
        Me.Controls.Add(Me.range)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Location = New System.Drawing.Point(24, 58)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmcompchk"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Selecting Vouchers to Pay"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BankName As System.Windows.Forms.ComboBox
#End Region 
End Class