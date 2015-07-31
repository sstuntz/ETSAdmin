<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class att_ed_cntrl
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
    Public WithEvents Ref_list As System.Windows.Forms.Button
	Public WithEvents CmdClose As System.Windows.Forms.Button
    Public WithEvents End_Date As System.Windows.Forms.TextBox
    Public WithEvents start_date As System.Windows.Forms.TextBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Ref_list = New System.Windows.Forms.Button()
        Me.CmdClose = New System.Windows.Forms.Button()
        Me.End_Date = New System.Windows.Forms.TextBox()
        Me.start_date = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SendEmail = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.ChangePrinter = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.AllContracts = New System.Windows.Forms.RadioButton()
        Me.Unsent = New System.Windows.Forms.RadioButton()
        Me.BilledSent = New System.Windows.Forms.RadioButton()
        Me.Unbilled = New System.Windows.Forms.RadioButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Ref_list
        '
        Me.Ref_list.BackColor = System.Drawing.SystemColors.Control
        Me.Ref_list.Cursor = System.Windows.Forms.Cursors.Default
        Me.Ref_list.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ref_list.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Ref_list.Location = New System.Drawing.Point(505, 605)
        Me.Ref_list.Name = "Ref_list"
        Me.Ref_list.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Ref_list.Size = New System.Drawing.Size(142, 26)
        Me.Ref_list.TabIndex = 2
        Me.Ref_list.Text = "Refresh List"
        Me.Ref_list.UseVisualStyleBackColor = False
        '
        'CmdClose
        '
        Me.CmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.CmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdClose.Location = New System.Drawing.Point(789, 6)
        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdClose.Size = New System.Drawing.Size(101, 23)
        Me.CmdClose.TabIndex = 6
        Me.CmdClose.Text = "Cancel"
        Me.CmdClose.UseVisualStyleBackColor = False
        '
        'End_Date
        '
        Me.End_Date.AcceptsReturn = True
        Me.End_Date.BackColor = System.Drawing.SystemColors.Window
        Me.End_Date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.End_Date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.End_Date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.End_Date.Location = New System.Drawing.Point(398, 4)
        Me.End_Date.MaxLength = 0
        Me.End_Date.Name = "End_Date"
        Me.End_Date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.End_Date.Size = New System.Drawing.Size(121, 20)
        Me.End_Date.TabIndex = 1
        Me.End_Date.Tag = "END_DATE"
        '
        'start_date
        '
        Me.start_date.AcceptsReturn = True
        Me.start_date.BackColor = System.Drawing.SystemColors.Window
        Me.start_date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.start_date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.start_date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.start_date.Location = New System.Drawing.Point(144, 4)
        Me.start_date.MaxLength = 0
        Me.start_date.Name = "start_date"
        Me.start_date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.start_date.Size = New System.Drawing.Size(121, 20)
        Me.start_date.TabIndex = 0
        Me.start_date.Tag = "BEG_DATE"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(271, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(126, 21)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "End date for Billing"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(14, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(124, 21)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Begin date for Billing"
        '
        'SendEmail
        '
        Me.SendEmail.Location = New System.Drawing.Point(726, 605)
        Me.SendEmail.Name = "SendEmail"
        Me.SendEmail.Size = New System.Drawing.Size(164, 41)
        Me.SendEmail.TabIndex = 11
        Me.SendEmail.Text = "Deliver Selected Invoices"
        Me.SendEmail.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(395, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Printer"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(468, 49)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(206, 20)
        Me.TextBox1.TabIndex = 14
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'ChangePrinter
        '
        Me.ChangePrinter.Location = New System.Drawing.Point(700, 49)
        Me.ChangePrinter.Name = "ChangePrinter"
        Me.ChangePrinter.Size = New System.Drawing.Size(133, 23)
        Me.ChangePrinter.TabIndex = 15
        Me.ChangePrinter.Text = "Change Printer"
        Me.ChangePrinter.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(709, 81)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(144, 22)
        Me.ComboBox1.TabIndex = 16
        '
        'AllContracts
        '
        Me.AllContracts.AutoSize = True
        Me.AllContracts.Location = New System.Drawing.Point(351, 628)
        Me.AllContracts.Name = "AllContracts"
        Me.AllContracts.Size = New System.Drawing.Size(107, 18)
        Me.AllContracts.TabIndex = 17
        Me.AllContracts.Text = "List All Contracts"
        Me.AllContracts.UseVisualStyleBackColor = True
        '
        'Unsent
        '
        Me.Unsent.AutoSize = True
        Me.Unsent.Checked = True
        Me.Unsent.Location = New System.Drawing.Point(192, 593)
        Me.Unsent.Name = "Unsent"
        Me.Unsent.Size = New System.Drawing.Size(111, 18)
        Me.Unsent.TabIndex = 18
        Me.Unsent.TabStop = True
        Me.Unsent.Text = "Billed and Unsent "
        Me.Unsent.UseVisualStyleBackColor = True
        '
        'BilledSent
        '
        Me.BilledSent.AutoSize = True
        Me.BilledSent.Location = New System.Drawing.Point(192, 628)
        Me.BilledSent.Name = "BilledSent"
        Me.BilledSent.Size = New System.Drawing.Size(96, 18)
        Me.BilledSent.TabIndex = 19
        Me.BilledSent.Text = "Billed and Sent"
        Me.BilledSent.UseVisualStyleBackColor = True
        '
        'Unbilled
        '
        Me.Unbilled.AutoSize = True
        Me.Unbilled.Location = New System.Drawing.Point(350, 593)
        Me.Unbilled.Name = "Unbilled"
        Me.Unbilled.Size = New System.Drawing.Size(62, 18)
        Me.Unbilled.TabIndex = 20
        Me.Unbilled.Text = "Unbilled"
        Me.Unbilled.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(56, 121)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(950, 429)
        Me.DataGridView1.TabIndex = 21
        '
        'att_ed_cntrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1068, 673)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Unbilled)
        Me.Controls.Add(Me.BilledSent)
        Me.Controls.Add(Me.Unsent)
        Me.Controls.Add(Me.AllContracts)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.ChangePrinter)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SendEmail)
        Me.Controls.Add(Me.Ref_list)
        Me.Controls.Add(Me.CmdClose)
        Me.Controls.Add(Me.End_Date)
        Me.Controls.Add(Me.start_date)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(-6, 46)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "att_ed_cntrl"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Bill Control Editor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SendEmail As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ChangePrinter As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents AllContracts As System.Windows.Forms.RadioButton
    Friend WithEvents Unsent As System.Windows.Forms.RadioButton
    Friend WithEvents BilledSent As System.Windows.Forms.RadioButton
    Friend WithEvents Unbilled As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView

#End Region 
End Class