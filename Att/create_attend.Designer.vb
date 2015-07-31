<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class create_attend
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
    Public WithEvents spec_bill As System.Windows.Forms.Button
    Public WithEvents by_bill_type As System.Windows.Forms.RadioButton
	Public WithEvents Ref_list As System.Windows.Forms.Button
	Public WithEvents by_contract As System.Windows.Forms.RadioButton
	Public WithEvents by_Client As System.Windows.Forms.RadioButton
    Public WithEvents CmdClose As System.Windows.Forms.Button
	Public WithEvents Process As System.Windows.Forms.Button
    Public WithEvents End_Date As System.Windows.Forms.TextBox
    Public WithEvents start_date As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.spec_bill = New System.Windows.Forms.Button()
        Me.by_bill_type = New System.Windows.Forms.RadioButton()
        Me.Ref_list = New System.Windows.Forms.Button()
        Me.by_contract = New System.Windows.Forms.RadioButton()
        Me.by_Client = New System.Windows.Forms.RadioButton()
        Me.CmdClose = New System.Windows.Forms.Button()
        Me.Process = New System.Windows.Forms.Button()
        Me.End_Date = New System.Windows.Forms.TextBox()
        Me.start_date = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'spec_bill
        '
        Me.spec_bill.BackColor = System.Drawing.SystemColors.Control
        Me.spec_bill.Cursor = System.Windows.Forms.Cursors.Default
        Me.spec_bill.Enabled = False
        Me.spec_bill.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spec_bill.ForeColor = System.Drawing.SystemColors.ControlText
        Me.spec_bill.Location = New System.Drawing.Point(368, 509)
        Me.spec_bill.Name = "spec_bill"
        Me.spec_bill.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.spec_bill.Size = New System.Drawing.Size(105, 25)
        Me.spec_bill.TabIndex = 9
        Me.spec_bill.Text = "Special Billing"
        Me.spec_bill.UseVisualStyleBackColor = False
        '
        'by_bill_type
        '
        Me.by_bill_type.BackColor = System.Drawing.SystemColors.Control
        Me.by_bill_type.Checked = True
        Me.by_bill_type.Cursor = System.Windows.Forms.Cursors.Default
        Me.by_bill_type.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.by_bill_type.ForeColor = System.Drawing.SystemColors.ControlText
        Me.by_bill_type.Location = New System.Drawing.Point(12, 40)
        Me.by_bill_type.Name = "by_bill_type"
        Me.by_bill_type.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.by_bill_type.Size = New System.Drawing.Size(94, 26)
        Me.by_bill_type.TabIndex = 10
        Me.by_bill_type.TabStop = True
        Me.by_bill_type.Text = "By Bill Type"
        Me.by_bill_type.UseVisualStyleBackColor = False
        '
        'Ref_list
        '
        Me.Ref_list.BackColor = System.Drawing.SystemColors.Control
        Me.Ref_list.Cursor = System.Windows.Forms.Cursors.Default
        Me.Ref_list.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ref_list.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Ref_list.Location = New System.Drawing.Point(507, 40)
        Me.Ref_list.Name = "Ref_list"
        Me.Ref_list.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Ref_list.Size = New System.Drawing.Size(142, 26)
        Me.Ref_list.TabIndex = 2
        Me.Ref_list.Text = "Refresh List"
        Me.Ref_list.UseVisualStyleBackColor = False
        '
        'by_contract
        '
        Me.by_contract.BackColor = System.Drawing.SystemColors.Control
        Me.by_contract.Cursor = System.Windows.Forms.Cursors.Default
        Me.by_contract.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.by_contract.ForeColor = System.Drawing.SystemColors.ControlText
        Me.by_contract.Location = New System.Drawing.Point(188, 33)
        Me.by_contract.Name = "by_contract"
        Me.by_contract.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.by_contract.Size = New System.Drawing.Size(98, 41)
        Me.by_contract.TabIndex = 8
        Me.by_contract.TabStop = True
        Me.by_contract.Text = "By Contract"
        Me.by_contract.UseVisualStyleBackColor = False
        '
        'by_Client
        '
        Me.by_Client.BackColor = System.Drawing.SystemColors.Control
        Me.by_Client.Cursor = System.Windows.Forms.Cursors.Default
        Me.by_Client.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.by_Client.ForeColor = System.Drawing.SystemColors.ControlText
        Me.by_Client.Location = New System.Drawing.Point(342, 40)
        Me.by_Client.Name = "by_Client"
        Me.by_Client.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.by_Client.Size = New System.Drawing.Size(100, 26)
        Me.by_Client.TabIndex = 7
        Me.by_Client.TabStop = True
        Me.by_Client.Text = " By Client"
        Me.by_Client.UseVisualStyleBackColor = False
        '
        'CmdClose
        '
        Me.CmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.CmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdClose.Location = New System.Drawing.Point(528, 6)
        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdClose.Size = New System.Drawing.Size(101, 23)
        Me.CmdClose.TabIndex = 6
        Me.CmdClose.Text = "Cancel"
        Me.CmdClose.UseVisualStyleBackColor = False
        '
        'Process
        '
        Me.Process.BackColor = System.Drawing.SystemColors.Control
        Me.Process.Cursor = System.Windows.Forms.Cursors.Default
        Me.Process.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Process.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Process.Location = New System.Drawing.Point(342, 472)
        Me.Process.Name = "Process"
        Me.Process.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Process.Size = New System.Drawing.Size(157, 31)
        Me.Process.TabIndex = 3
        Me.Process.Text = "Create Records"
        Me.Process.UseVisualStyleBackColor = False
        '
        'End_Date
        '
        Me.End_Date.AcceptsReturn = True
        Me.End_Date.BackColor = System.Drawing.SystemColors.Window
        Me.End_Date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.End_Date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.End_Date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.End_Date.Location = New System.Drawing.Point(384, 4)
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
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(543, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(212, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Records have been created"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(60, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(194, 18)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Available for Creating records"
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
        Me.Label3.Location = New System.Drawing.Point(16, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(124, 21)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Begin date for Billing"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(19, 138)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(394, 304)
        Me.DataGridView1.TabIndex = 13
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(459, 138)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(417, 304)
        Me.DataGridView2.TabIndex = 14
        '
        'create_attend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(916, 562)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.spec_bill)
        Me.Controls.Add(Me.by_bill_type)
        Me.Controls.Add(Me.Ref_list)
        Me.Controls.Add(Me.by_contract)
        Me.Controls.Add(Me.by_Client)
        Me.Controls.Add(Me.CmdClose)
        Me.Controls.Add(Me.Process)
        Me.Controls.Add(Me.End_Date)
        Me.Controls.Add(Me.start_date)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(51, 113)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "create_attend"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Create attendance"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
#End Region 
End Class