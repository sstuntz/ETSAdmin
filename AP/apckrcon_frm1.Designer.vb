<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class apckrcon_frm1
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
	Public WithEvents tot_cks As System.Windows.Forms.TextBox
	Public WithEvents Text2 As System.Windows.Forms.TextBox
	Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents finished As System.Windows.Forms.Button
	Public WithEvents tot As System.Windows.Forms.TextBox
	Public WithEvents checknum As System.Windows.Forms.TextBox
	Public WithEvents proof As System.Windows.Forms.Button
	Public WithEvents reverse As System.Windows.Forms.Button
    Public WithEvents CMdExit As System.Windows.Forms.Button
    Public WithEvents recon_date As System.Windows.Forms.TextBox
    Public WithEvents OutCks As System.Windows.Forms.Button
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
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tot_cks = New System.Windows.Forms.TextBox
        Me.Text2 = New System.Windows.Forms.TextBox
        Me.Text1 = New System.Windows.Forms.TextBox
        Me.finished = New System.Windows.Forms.Button
        Me.tot = New System.Windows.Forms.TextBox
        Me.checknum = New System.Windows.Forms.TextBox
        Me.proof = New System.Windows.Forms.Button
        Me.reverse = New System.Windows.Forms.Button
        Me.CMdExit = New System.Windows.Forms.Button
        Me.recon_date = New System.Windows.Forms.TextBox
        Me.OutCks = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.chk_num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dt_clear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.net_amt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Screen_nam = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tot_cks
        '
        Me.tot_cks.AcceptsReturn = True
        Me.tot_cks.BackColor = System.Drawing.SystemColors.Window
        Me.tot_cks.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tot_cks.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tot_cks.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tot_cks.Location = New System.Drawing.Point(479, 259)
        Me.tot_cks.MaxLength = 0
        Me.tot_cks.Name = "tot_cks"
        Me.tot_cks.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tot_cks.Size = New System.Drawing.Size(71, 20)
        Me.tot_cks.TabIndex = 16
        '
        'Text2
        '
        Me.Text2.AcceptsReturn = True
        Me.Text2.BackColor = System.Drawing.SystemColors.Window
        Me.Text2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text2.Enabled = False
        Me.Text2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text2.Location = New System.Drawing.Point(416, 88)
        Me.Text2.MaxLength = 0
        Me.Text2.Name = "Text2"
        Me.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text2.Size = New System.Drawing.Size(97, 20)
        Me.Text2.TabIndex = 15
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Enabled = False
        Me.Text1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(176, 88)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(217, 20)
        Me.Text1.TabIndex = 14
        '
        'finished
        '
        Me.finished.BackColor = System.Drawing.SystemColors.Control
        Me.finished.Cursor = System.Windows.Forms.Cursors.Default
        Me.finished.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.finished.ForeColor = System.Drawing.SystemColors.ControlText
        Me.finished.Location = New System.Drawing.Point(272, 49)
        Me.finished.Name = "finished"
        Me.finished.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.finished.Size = New System.Drawing.Size(297, 33)
        Me.finished.TabIndex = 10
        Me.finished.Text = "Finished entering check#'s..continue Recon process"
        Me.finished.UseVisualStyleBackColor = False
        '
        'tot
        '
        Me.tot.AcceptsReturn = True
        Me.tot.BackColor = System.Drawing.SystemColors.Window
        Me.tot.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tot.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tot.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tot.Location = New System.Drawing.Point(272, 256)
        Me.tot.MaxLength = 0
        Me.tot.Name = "tot"
        Me.tot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tot.Size = New System.Drawing.Size(81, 20)
        Me.tot.TabIndex = 9
        '
        'checknum
        '
        Me.checknum.AcceptsReturn = True
        Me.checknum.BackColor = System.Drawing.SystemColors.Window
        Me.checknum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.checknum.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checknum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.checknum.Location = New System.Drawing.Point(176, 48)
        Me.checknum.MaxLength = 0
        Me.checknum.Name = "checknum"
        Me.checknum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.checknum.Size = New System.Drawing.Size(49, 20)
        Me.checknum.TabIndex = 8
        Me.checknum.Tag = "check_num"
        '
        'proof
        '
        Me.proof.BackColor = System.Drawing.SystemColors.Control
        Me.proof.Cursor = System.Windows.Forms.Cursors.Default
        Me.proof.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.proof.ForeColor = System.Drawing.SystemColors.ControlText
        Me.proof.Location = New System.Drawing.Point(352, 320)
        Me.proof.Name = "proof"
        Me.proof.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.proof.Size = New System.Drawing.Size(145, 33)
        Me.proof.TabIndex = 6
        Me.proof.Text = "Checks Returned Proof"
        Me.proof.UseVisualStyleBackColor = False
        '
        'reverse
        '
        Me.reverse.BackColor = System.Drawing.SystemColors.Control
        Me.reverse.Cursor = System.Windows.Forms.Cursors.Default
        Me.reverse.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reverse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.reverse.Location = New System.Drawing.Point(0, 192)
        Me.reverse.Name = "reverse"
        Me.reverse.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.reverse.Size = New System.Drawing.Size(121, 33)
        Me.reverse.TabIndex = 5
        Me.reverse.Text = "Un-Recon Check#"
        Me.reverse.UseVisualStyleBackColor = False
        '
        'CMdExit
        '
        Me.CMdExit.BackColor = System.Drawing.SystemColors.Control
        Me.CMdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.CMdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMdExit.Location = New System.Drawing.Point(432, 0)
        Me.CMdExit.Name = "CMdExit"
        Me.CMdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CMdExit.Size = New System.Drawing.Size(153, 25)
        Me.CMdExit.TabIndex = 3
        Me.CMdExit.Text = "Exit this screen - No Action"
        Me.CMdExit.UseVisualStyleBackColor = False
        '
        'recon_date
        '
        Me.recon_date.AcceptsReturn = True
        Me.recon_date.BackColor = System.Drawing.SystemColors.Window
        Me.recon_date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.recon_date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.recon_date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.recon_date.Location = New System.Drawing.Point(295, 8)
        Me.recon_date.MaxLength = 0
        Me.recon_date.Name = "recon_date"
        Me.recon_date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.recon_date.Size = New System.Drawing.Size(73, 20)
        Me.recon_date.TabIndex = 1
        Me.recon_date.Tag = "recon_date"
        Me.recon_date.Text = " "
        '
        'OutCks
        '
        Me.OutCks.BackColor = System.Drawing.SystemColors.Control
        Me.OutCks.Cursor = System.Windows.Forms.Cursors.Default
        Me.OutCks.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutCks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OutCks.Location = New System.Drawing.Point(352, 384)
        Me.OutCks.Name = "OutCks"
        Me.OutCks.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OutCks.Size = New System.Drawing.Size(145, 33)
        Me.OutCks.TabIndex = 2
        Me.OutCks.Text = "Outstanding Checks Report"
        Me.OutCks.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(375, 260)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(95, 12)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Number of Checks"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(184, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Total Amount"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(112, 384)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(193, 41)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Click on the button to the right to print Outstanding Checks Report.  This can be" & _
            " reprinted."
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(112, 320)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(193, 41)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Click on the button to the right to print the checks Returned Proof.  This can be" & _
            " reprinted."
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(24, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(129, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Enter each Check#------->"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(113, 65)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "To Un-recon a Check, use mouse to select an entry...Then select the button below." & _
            "  "
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(249, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter the Recon Date to the right and then enter each  CHECK#  that is in the sta" & _
            "tement."
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chk_num, Me.dt_clear, Me.net_amt, Me.Screen_nam})
        Me.DataGridView1.Location = New System.Drawing.Point(148, 130)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(420, 111)
        Me.DataGridView1.TabIndex = 18
        '
        'chk_num
        '
        Me.chk_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.chk_num.DataPropertyName = "chk_num"
        Me.chk_num.HeaderText = "Check Num"
        Me.chk_num.Name = "chk_num"
        Me.chk_num.ReadOnly = True
        Me.chk_num.Width = 86
        '
        'dt_clear
        '
        Me.dt_clear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dt_clear.DataPropertyName = "dt_clear"
        Me.dt_clear.HeaderText = "Date Clear"
        Me.dt_clear.Name = "dt_clear"
        Me.dt_clear.ReadOnly = True
        Me.dt_clear.Width = 82
        '
        'net_amt
        '
        Me.net_amt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.net_amt.DataPropertyName = "net_amt"
        Me.net_amt.HeaderText = "Net Amt"
        Me.net_amt.Name = "net_amt"
        Me.net_amt.ReadOnly = True
        Me.net_amt.Width = 69
        '
        'Screen_nam
        '
        Me.Screen_nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Screen_nam.DataPropertyName = "Screen_nam"
        Me.Screen_nam.HeaderText = "Screen Name"
        Me.Screen_nam.Name = "Screen_nam"
        Me.Screen_nam.ReadOnly = True
        Me.Screen_nam.Width = 97
        '
        'apckrcon_frm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(585, 447)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.tot_cks)
        Me.Controls.Add(Me.Text2)
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.finished)
        Me.Controls.Add(Me.tot)
        Me.Controls.Add(Me.checknum)
        Me.Controls.Add(Me.proof)
        Me.Controls.Add(Me.reverse)
        Me.Controls.Add(Me.CMdExit)
        Me.Controls.Add(Me.recon_date)
        Me.Controls.Add(Me.OutCks)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(34, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "apckrcon_frm1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Accounts Payable Check Reconciliation1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents chk_num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dt_clear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents net_amt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Screen_nam As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class