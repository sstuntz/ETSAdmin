<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class bill_unpv
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
    Public WithEvents encum_Date As System.Windows.Forms.TextBox
    Public WithEvents invoice_string As System.Windows.Forms.TextBox
    Public WithEvents inv_date As System.Windows.Forms.TextBox
    Public WithEvents Ref_list As System.Windows.Forms.Button
    Public WithEvents CmdClose As System.Windows.Forms.Button
	Public WithEvents Process As System.Windows.Forms.Button
    Public WithEvents End_Date As System.Windows.Forms.TextBox
    Public WithEvents start_date As System.Windows.Forms.TextBox
    Public WithEvents _Label4_2 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents _Label4_1 As System.Windows.Forms.Label
    Public WithEvents _Label4_0 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.encum_Date = New System.Windows.Forms.TextBox
        Me.invoice_string = New System.Windows.Forms.TextBox
        Me.inv_date = New System.Windows.Forms.TextBox
        Me.Ref_list = New System.Windows.Forms.Button
        Me.CmdClose = New System.Windows.Forms.Button
        Me.Process = New System.Windows.Forms.Button
        Me.End_Date = New System.Windows.Forms.TextBox
        Me.start_date = New System.Windows.Forms.TextBox
        Me._Label4_2 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me._Label4_1 = New System.Windows.Forms.Label
        Me._Label4_0 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'encum_Date
        '
        Me.encum_Date.AcceptsReturn = True
        Me.encum_Date.BackColor = System.Drawing.SystemColors.Window
        Me.encum_Date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.encum_Date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.encum_Date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.encum_Date.Location = New System.Drawing.Point(496, 79)
        Me.encum_Date.MaxLength = 0
        Me.encum_Date.Name = "encum_Date"
        Me.encum_Date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.encum_Date.Size = New System.Drawing.Size(121, 20)
        Me.encum_Date.TabIndex = 7
        '
        'invoice_string
        '
        Me.invoice_string.AcceptsReturn = True
        Me.invoice_string.BackColor = System.Drawing.SystemColors.Window
        Me.invoice_string.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.invoice_string.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.invoice_string.ForeColor = System.Drawing.SystemColors.WindowText
        Me.invoice_string.Location = New System.Drawing.Point(480, 32)
        Me.invoice_string.MaxLength = 0
        Me.invoice_string.Name = "invoice_string"
        Me.invoice_string.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.invoice_string.Size = New System.Drawing.Size(137, 20)
        Me.invoice_string.TabIndex = 5
        '
        'inv_date
        '
        Me.inv_date.AcceptsReturn = True
        Me.inv_date.BackColor = System.Drawing.SystemColors.Window
        Me.inv_date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.inv_date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inv_date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.inv_date.Location = New System.Drawing.Point(496, 56)
        Me.inv_date.MaxLength = 0
        Me.inv_date.Name = "inv_date"
        Me.inv_date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.inv_date.Size = New System.Drawing.Size(121, 20)
        Me.inv_date.TabIndex = 6
        '
        'Ref_list
        '
        Me.Ref_list.BackColor = System.Drawing.SystemColors.Control
        Me.Ref_list.Cursor = System.Windows.Forms.Cursors.Default
        Me.Ref_list.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ref_list.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Ref_list.Location = New System.Drawing.Point(256, 40)
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
        Me.CmdClose.Location = New System.Drawing.Point(496, 0)
        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdClose.Size = New System.Drawing.Size(101, 26)
        Me.CmdClose.TabIndex = 11
        Me.CmdClose.Text = "Cancel"
        Me.CmdClose.UseVisualStyleBackColor = False
        '
        'Process
        '
        Me.Process.BackColor = System.Drawing.SystemColors.Control
        Me.Process.Cursor = System.Windows.Forms.Cursors.Default
        Me.Process.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Process.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Process.Location = New System.Drawing.Point(496, 410)
        Me.Process.Name = "Process"
        Me.Process.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Process.Size = New System.Drawing.Size(114, 31)
        Me.Process.TabIndex = 8
        Me.Process.Text = "Create PV"
        Me.Process.UseVisualStyleBackColor = False
        '
        'End_Date
        '
        Me.End_Date.AcceptsReturn = True
        Me.End_Date.BackColor = System.Drawing.SystemColors.Window
        Me.End_Date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.End_Date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.End_Date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.End_Date.Location = New System.Drawing.Point(112, 60)
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
        Me.start_date.Location = New System.Drawing.Point(112, 32)
        Me.start_date.MaxLength = 0
        Me.start_date.Name = "start_date"
        Me.start_date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.start_date.Size = New System.Drawing.Size(121, 20)
        Me.start_date.TabIndex = 0
        Me.start_date.Tag = "BEG_DATE"
        '
        '_Label4_2
        '
        Me._Label4_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label4_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label4_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label4_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label4_2.Location = New System.Drawing.Point(409, 81)
        Me._Label4_2.Name = "_Label4_2"
        Me._Label4_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label4_2.Size = New System.Drawing.Size(76, 21)
        Me._Label4_2.TabIndex = 21
        Me._Label4_2.Text = "Encum Date"
        Me._Label4_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(416, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Invoice ID"
        '
        '_Label4_1
        '
        Me._Label4_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label4_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label4_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label4_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label4_1.Location = New System.Drawing.Point(404, 58)
        Me._Label4_1.Name = "_Label4_1"
        Me._Label4_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label4_1.Size = New System.Drawing.Size(79, 21)
        Me._Label4_1.TabIndex = 14
        Me._Label4_1.Text = "Invoice Date"
        Me._Label4_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_Label4_0
        '
        Me._Label4_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label4_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label4_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label4_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label4_0.Location = New System.Drawing.Point(16, 60)
        Me._Label4_0.Name = "_Label4_0"
        Me._Label4_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label4_0.Size = New System.Drawing.Size(93, 21)
        Me._Label4_0.TabIndex = 10
        Me._Label4_0.Text = "End date for Billing"
        Me._Label4_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(100, 21)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Begin date for Billing"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(11, 106)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridView1.Size = New System.Drawing.Size(599, 287)
        Me.DataGridView1.TabIndex = 22
        '
        'bill_unpv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.encum_Date)
        Me.Controls.Add(Me.invoice_string)
        Me.Controls.Add(Me.inv_date)
        Me.Controls.Add(Me.Ref_list)
        Me.Controls.Add(Me.CmdClose)
        Me.Controls.Add(Me.Process)
        Me.Controls.Add(Me.End_Date)
        Me.Controls.Add(Me.start_date)
        Me.Controls.Add(Me._Label4_2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me._Label4_1)
        Me.Controls.Add(Me._Label4_0)
        Me.Controls.Add(Me.Label3)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Location = New System.Drawing.Point(10, 60)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "bill_unpv"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Billing Unsupported PV's"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
#End Region
End Class