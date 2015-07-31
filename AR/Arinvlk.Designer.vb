<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class invoicelookup
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
    Public WithEvents invoice_id As System.Windows.Forms.TextBox
	Public WithEvents invoice As System.Windows.Forms.TextBox
    Public WithEvents edit As System.Windows.Forms.Button
	Public WithEvents addacct As System.Windows.Forms.Button
	Public WithEvents Cancel As System.Windows.Forms.Button
	Public WithEvents Accept As System.Windows.Forms.Button
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.invoice_id = New System.Windows.Forms.TextBox()
        Me.invoice = New System.Windows.Forms.TextBox()
        Me.edit = New System.Windows.Forms.Button()
        Me.addacct = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Accept = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.inv_num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Line_num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Invoice1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Screen_nam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bal_due = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Alloc_amt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cc_num = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cc_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'invoice_id
        '
        Me.invoice_id.AcceptsReturn = True
        Me.invoice_id.BackColor = System.Drawing.SystemColors.Window
        Me.invoice_id.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.invoice_id.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.invoice_id.ForeColor = System.Drawing.SystemColors.WindowText
        Me.invoice_id.Location = New System.Drawing.Point(457, 113)
        Me.invoice_id.MaxLength = 0
        Me.invoice_id.Name = "invoice_id"
        Me.invoice_id.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.invoice_id.Size = New System.Drawing.Size(123, 20)
        Me.invoice_id.TabIndex = 15
        '
        'invoice
        '
        Me.invoice.AcceptsReturn = True
        Me.invoice.BackColor = System.Drawing.SystemColors.Window
        Me.invoice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.invoice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.invoice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.invoice.Location = New System.Drawing.Point(289, 113)
        Me.invoice.MaxLength = 0
        Me.invoice.Name = "invoice"
        Me.invoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.invoice.Size = New System.Drawing.Size(59, 20)
        Me.invoice.TabIndex = 11
        '
        'edit
        '
        Me.edit.BackColor = System.Drawing.SystemColors.Control
        Me.edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.edit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edit.Location = New System.Drawing.Point(544, 625)
        Me.edit.Name = "edit"
        Me.edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edit.Size = New System.Drawing.Size(73, 49)
        Me.edit.TabIndex = 1
        Me.edit.Text = "Edit"
        Me.edit.UseVisualStyleBackColor = False
        '
        'addacct
        '
        Me.addacct.BackColor = System.Drawing.SystemColors.Control
        Me.addacct.Cursor = System.Windows.Forms.Cursors.Default
        Me.addacct.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addacct.ForeColor = System.Drawing.SystemColors.ControlText
        Me.addacct.Location = New System.Drawing.Point(410, 625)
        Me.addacct.Name = "addacct"
        Me.addacct.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.addacct.Size = New System.Drawing.Size(73, 49)
        Me.addacct.TabIndex = 2
        Me.addacct.Text = "Add"
        Me.addacct.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(639, 62)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(97, 31)
        Me.Cancel.TabIndex = 3
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Accept
        '
        Me.Accept.BackColor = System.Drawing.SystemColors.Control
        Me.Accept.Cursor = System.Windows.Forms.Cursors.Default
        Me.Accept.Enabled = False
        Me.Accept.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Accept.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Accept.Location = New System.Drawing.Point(706, 625)
        Me.Accept.Name = "Accept"
        Me.Accept.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Accept.Size = New System.Drawing.Size(129, 49)
        Me.Accept.TabIndex = 0
        Me.Accept.Text = "Use Selected Name"
        Me.Accept.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(377, 113)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(73, 17)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "or Invoice ID"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(120, 82)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(363, 28)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Highlight an existing  invoice and click on the EDIT button if you wish to change" & _
    " an invoice or add lines to it."
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(176, 103)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(2, 1)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Label9"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(121, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(163, 18)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "For Quick Search enter invoice# "
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(120, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(266, 17)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "To Add a new invoice number, select the ADD button."
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.inv_num, Me.Line_num, Me.Invoice1, Me.Screen_nam, Me.Bal_due, Me.Alloc_amt, Me.cc_num, Me.cc_name})
        Me.DataGridView1.Location = New System.Drawing.Point(126, 155)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(725, 444)
        Me.DataGridView1.TabIndex = 20
        '
        'inv_num
        '
        Me.inv_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.inv_num.DataPropertyName = "inv_num"
        Me.inv_num.HeaderText = "Invoice #"
        Me.inv_num.Name = "inv_num"
        Me.inv_num.ReadOnly = True
        Me.inv_num.Width = 75
        '
        'Line_num
        '
        Me.Line_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Line_num.DataPropertyName = "Line_num"
        Me.Line_num.HeaderText = "Line #"
        Me.Line_num.Name = "Line_num"
        Me.Line_num.ReadOnly = True
        Me.Line_num.Width = 61
        '
        'Invoice1
        '
        Me.Invoice1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Invoice1.DataPropertyName = "Invoice"
        Me.Invoice1.HeaderText = "Invoice"
        Me.Invoice1.Name = "Invoice1"
        Me.Invoice1.ReadOnly = True
        Me.Invoice1.Width = 66
        '
        'Screen_nam
        '
        Me.Screen_nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Screen_nam.DataPropertyName = "Screen_nam"
        Me.Screen_nam.HeaderText = "Name"
        Me.Screen_nam.Name = "Screen_nam"
        Me.Screen_nam.ReadOnly = True
        Me.Screen_nam.Width = 59
        '
        'Bal_due
        '
        Me.Bal_due.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Bal_due.DataPropertyName = "Bal_due"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Bal_due.DefaultCellStyle = DataGridViewCellStyle1
        Me.Bal_due.HeaderText = "Open Balance"
        Me.Bal_due.Name = "Bal_due"
        Me.Bal_due.ReadOnly = True
        '
        'Alloc_amt
        '
        Me.Alloc_amt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Alloc_amt.DataPropertyName = "Alloc_amt"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Alloc_amt.DefaultCellStyle = DataGridViewCellStyle2
        Me.Alloc_amt.HeaderText = "Alloc amt"
        Me.Alloc_amt.Name = "Alloc_amt"
        Me.Alloc_amt.ReadOnly = True
        Me.Alloc_amt.Width = 76
        '
        'cc_num
        '
        Me.cc_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.cc_num.DataPropertyName = "cc_num"
        Me.cc_num.HeaderText = "CC #"
        Me.cc_num.Name = "cc_num"
        Me.cc_num.ReadOnly = True
        Me.cc_num.Width = 55
        '
        'cc_name
        '
        Me.cc_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.cc_name.DataPropertyName = "cc_name"
        Me.cc_name.HeaderText = "CC Name"
        Me.cc_name.Name = "cc_name"
        Me.cc_name.ReadOnly = True
        Me.cc_name.Width = 76
        '
        'invoicelookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(877, 696)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.invoice_id)
        Me.Controls.Add(Me.invoice)
        Me.Controls.Add(Me.edit)
        Me.Controls.Add(Me.addacct)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Accept)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(-3, 45)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "invoicelookup"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Enter/Edit Invoices"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents inv_num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Line_num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Invoice1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Screen_nam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bal_due As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Alloc_amt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cc_num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cc_name As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class