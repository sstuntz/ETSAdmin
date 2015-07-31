<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class apvchdel_frm
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
    Public WithEvents RptPmtDel As System.Windows.Forms.Button
    Public WithEvents RptVouchDel As System.Windows.Forms.Button
    Public WithEvents RecordSelect As System.Windows.Forms.Button
    Public WithEvents CmdExit As System.Windows.Forms.Button
    Public WithEvents DeleteRecords As System.Windows.Forms.Button
    Public WithEvents MovetoHistory As System.Windows.Forms.Button
    Public WithEvents _txtFields_0 As System.Windows.Forms.TextBox
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents DateVer As System.Windows.Forms.Button
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
    Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RptPmtDel = New System.Windows.Forms.Button
        Me.RptVouchDel = New System.Windows.Forms.Button
        Me.RecordSelect = New System.Windows.Forms.Button
        Me.CmdExit = New System.Windows.Forms.Button
        Me.DeleteRecords = New System.Windows.Forms.Button
        Me.MovetoHistory = New System.Windows.Forms.Button
        Me._txtFields_0 = New System.Windows.Forms.TextBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.DateVer = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me._lblLabels_0 = New System.Windows.Forms.Label
        Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RptPmtDel
        '
        Me.RptPmtDel.BackColor = System.Drawing.SystemColors.Control
        Me.RptPmtDel.Cursor = System.Windows.Forms.Cursors.Default
        Me.RptPmtDel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RptPmtDel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RptPmtDel.Location = New System.Drawing.Point(216, 232)
        Me.RptPmtDel.Name = "RptPmtDel"
        Me.RptPmtDel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RptPmtDel.Size = New System.Drawing.Size(225, 25)
        Me.RptPmtDel.TabIndex = 16
        Me.RptPmtDel.Text = "4.  Print Payments to Delete Report"
        Me.RptPmtDel.UseVisualStyleBackColor = False
        '
        'RptVouchDel
        '
        Me.RptVouchDel.BackColor = System.Drawing.SystemColors.Control
        Me.RptVouchDel.Cursor = System.Windows.Forms.Cursors.Default
        Me.RptVouchDel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RptVouchDel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RptVouchDel.Location = New System.Drawing.Point(216, 264)
        Me.RptVouchDel.Name = "RptVouchDel"
        Me.RptVouchDel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RptVouchDel.Size = New System.Drawing.Size(225, 25)
        Me.RptVouchDel.TabIndex = 15
        Me.RptVouchDel.Text = "5.  Print Vouchers to Delete Report"
        Me.RptVouchDel.UseVisualStyleBackColor = False
        '
        'RecordSelect
        '
        Me.RecordSelect.BackColor = System.Drawing.SystemColors.Control
        Me.RecordSelect.Cursor = System.Windows.Forms.Cursors.Default
        Me.RecordSelect.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RecordSelect.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RecordSelect.Location = New System.Drawing.Point(216, 192)
        Me.RecordSelect.Name = "RecordSelect"
        Me.RecordSelect.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RecordSelect.Size = New System.Drawing.Size(225, 25)
        Me.RecordSelect.TabIndex = 3
        Me.RecordSelect.Text = "3.  Select Record to be deleted."
        Me.RecordSelect.UseVisualStyleBackColor = False
        '
        'CmdExit
        '
        Me.CmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.CmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdExit.Location = New System.Drawing.Point(216, 376)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdExit.Size = New System.Drawing.Size(225, 25)
        Me.CmdExit.TabIndex = 6
        Me.CmdExit.Text = "8.  Exit This Form"
        Me.CmdExit.UseVisualStyleBackColor = False
        '
        'DeleteRecords
        '
        Me.DeleteRecords.BackColor = System.Drawing.SystemColors.Control
        Me.DeleteRecords.Cursor = System.Windows.Forms.Cursors.Default
        Me.DeleteRecords.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteRecords.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DeleteRecords.Location = New System.Drawing.Point(216, 336)
        Me.DeleteRecords.Name = "DeleteRecords"
        Me.DeleteRecords.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DeleteRecords.Size = New System.Drawing.Size(257, 25)
        Me.DeleteRecords.TabIndex = 5
        Me.DeleteRecords.Text = "7. Delete Records from PMT and VOUCHER."
        Me.DeleteRecords.UseVisualStyleBackColor = False
        '
        'MovetoHistory
        '
        Me.MovetoHistory.BackColor = System.Drawing.SystemColors.Control
        Me.MovetoHistory.Cursor = System.Windows.Forms.Cursors.Default
        Me.MovetoHistory.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MovetoHistory.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MovetoHistory.Location = New System.Drawing.Point(216, 296)
        Me.MovetoHistory.Name = "MovetoHistory"
        Me.MovetoHistory.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MovetoHistory.Size = New System.Drawing.Size(225, 25)
        Me.MovetoHistory.TabIndex = 4
        Me.MovetoHistory.Text = "6.  Move records to History."
        Me.MovetoHistory.UseVisualStyleBackColor = False
        '
        '_txtFields_0
        '
        Me._txtFields_0.AcceptsReturn = True
        Me._txtFields_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFields.SetIndex(Me._txtFields_0, CType(0, Short))
        Me._txtFields_0.Location = New System.Drawing.Point(296, 112)
        Me._txtFields_0.MaxLength = 0
        Me._txtFields_0.Name = "_txtFields_0"
        Me._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_0.Size = New System.Drawing.Size(97, 20)
        Me._txtFields_0.TabIndex = 1
        Me._txtFields_0.Tag = "END_DATE"
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(488, 0)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(105, 20)
        Me.cmdClose.TabIndex = 8
        Me.cmdClose.TabStop = False
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'DateVer
        '
        Me.DateVer.BackColor = System.Drawing.SystemColors.Control
        Me.DateVer.Cursor = System.Windows.Forms.Cursors.Default
        Me.DateVer.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateVer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DateVer.Location = New System.Drawing.Point(216, 152)
        Me.DateVer.Name = "DateVer"
        Me.DateVer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DateVer.Size = New System.Drawing.Size(225, 25)
        Me.DateVer.TabIndex = 2
        Me.DateVer.Text = "2.  Verify Date."
        Me.DateVer.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(497, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Perform this deletion when no one else is using the AP Files. "
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(42, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(489, 25)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "PMT Records are moved to pmthist and voucher records are moved to vchhist"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(401, 25)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "This will DELETE RECORDS from PAYMENT and VOUCHER."
        '
        '_lblLabels_0
        '
        Me._lblLabels_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_0, CType(0, Short))
        Me._lblLabels_0.Location = New System.Drawing.Point(96, 112)
        Me._lblLabels_0.Name = "_lblLabels_0"
        Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_0.Size = New System.Drawing.Size(169, 17)
        Me._lblLabels_0.TabIndex = 9
        Me._lblLabels_0.Text = "1.  Enter Date to Select Through."
        '
        'txtFields
        '
        '
        'apvchdel_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(593, 498)
        Me.ControlBox = False
        Me.Controls.Add(Me.RptPmtDel)
        Me.Controls.Add(Me.RptVouchDel)
        Me.Controls.Add(Me.RecordSelect)
        Me.Controls.Add(Me.CmdExit)
        Me.Controls.Add(Me.DeleteRecords)
        Me.Controls.Add(Me.MovetoHistory)
        Me.Controls.Add(Me._txtFields_0)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.DateVer)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._lblLabels_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(136, 73)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "apvchdel_frm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Delete Vouches and Payemnt records that balance to Zero."
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class