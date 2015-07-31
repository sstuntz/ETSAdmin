<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class ar_bat_lookup
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
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents ed_det As System.Windows.Forms.Button
    Public WithEvents extra_com As System.Windows.Forms.Button
    Public WithEvents edit As System.Windows.Forms.Button
    Public WithEvents addacct As System.Windows.Forms.Button
    Public WithEvents Cancel As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.ed_det = New System.Windows.Forms.Button()
        Me.extra_com = New System.Windows.Forms.Button()
        Me.edit = New System.Windows.Forms.Button()
        Me.addacct = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.AddToBatch = New System.Windows.Forms.Button()
        Me.PrintbyChk = New System.Windows.Forms.Button()
        Me.PushExcel = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(472, 312)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(136, 36)
        Me.Command1.TabIndex = 5
        Me.Command1.Text = "Print Batch Edit Rpt"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'ed_det
        '
        Me.ed_det.BackColor = System.Drawing.SystemColors.Control
        Me.ed_det.Cursor = System.Windows.Forms.Cursors.Default
        Me.ed_det.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ed_det.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ed_det.Location = New System.Drawing.Point(472, 256)
        Me.ed_det.Name = "ed_det"
        Me.ed_det.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ed_det.Size = New System.Drawing.Size(136, 36)
        Me.ed_det.TabIndex = 4
        Me.ed_det.Text = "Delete a Batch"
        Me.ed_det.UseVisualStyleBackColor = False
        '
        'extra_com
        '
        Me.extra_com.BackColor = System.Drawing.SystemColors.Control
        Me.extra_com.Cursor = System.Windows.Forms.Cursors.Default
        Me.extra_com.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.extra_com.ForeColor = System.Drawing.SystemColors.ControlText
        Me.extra_com.Location = New System.Drawing.Point(472, 444)
        Me.extra_com.Name = "extra_com"
        Me.extra_com.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.extra_com.Size = New System.Drawing.Size(140, 57)
        Me.extra_com.TabIndex = 3
        Me.extra_com.Text = "Save Batch to Cash and Apply to Invoices"
        Me.extra_com.UseVisualStyleBackColor = False
        '
        'edit
        '
        Me.edit.BackColor = System.Drawing.SystemColors.Control
        Me.edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.edit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edit.Location = New System.Drawing.Point(472, 200)
        Me.edit.Name = "edit"
        Me.edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edit.Size = New System.Drawing.Size(136, 36)
        Me.edit.TabIndex = 0
        Me.edit.Text = "Edit an Existing Batch"
        Me.edit.UseVisualStyleBackColor = False
        '
        'addacct
        '
        Me.addacct.BackColor = System.Drawing.SystemColors.Control
        Me.addacct.Cursor = System.Windows.Forms.Cursors.Default
        Me.addacct.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addacct.ForeColor = System.Drawing.SystemColors.ControlText
        Me.addacct.Location = New System.Drawing.Point(472, 90)
        Me.addacct.Name = "addacct"
        Me.addacct.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.addacct.Size = New System.Drawing.Size(136, 36)
        Me.addacct.TabIndex = 1
        Me.addacct.Text = "Create a new Batch"
        Me.addacct.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(546, -1)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(81, 25)
        Me.Cancel.TabIndex = 2
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(29, 34)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(417, 609)
        Me.DataGridView1.TabIndex = 15
        '
        'AddToBatch
        '
        Me.AddToBatch.BackColor = System.Drawing.SystemColors.Control
        Me.AddToBatch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddToBatch.Location = New System.Drawing.Point(472, 146)
        Me.AddToBatch.Name = "AddToBatch"
        Me.AddToBatch.Size = New System.Drawing.Size(136, 36)
        Me.AddToBatch.TabIndex = 16
        Me.AddToBatch.Text = "Add to an existing Batch"
        Me.AddToBatch.UseVisualStyleBackColor = False
        '
        'PrintbyChk
        '
        Me.PrintbyChk.BackColor = System.Drawing.SystemColors.Control
        Me.PrintbyChk.Cursor = System.Windows.Forms.Cursors.Default
        Me.PrintbyChk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintbyChk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PrintbyChk.Location = New System.Drawing.Point(472, 372)
        Me.PrintbyChk.Name = "PrintbyChk"
        Me.PrintbyChk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PrintbyChk.Size = New System.Drawing.Size(136, 36)
        Me.PrintbyChk.TabIndex = 17
        Me.PrintbyChk.Text = "Print Batch by Check #"
        Me.PrintbyChk.UseVisualStyleBackColor = False
        '
        'PushExcel
        '
        Me.PushExcel.Location = New System.Drawing.Point(472, 534)
        Me.PushExcel.Name = "PushExcel"
        Me.PushExcel.Size = New System.Drawing.Size(136, 59)
        Me.PushExcel.TabIndex = 18
        Me.PushExcel.Text = "Put Batch/es into Excel"
        Me.PushExcel.UseVisualStyleBackColor = True
        '
        'ar_bat_lookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(628, 670)
        Me.ControlBox = False
        Me.Controls.Add(Me.PushExcel)
        Me.Controls.Add(Me.PrintbyChk)
        Me.Controls.Add(Me.AddToBatch)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.ed_det)
        Me.Controls.Add(Me.extra_com)
        Me.Controls.Add(Me.edit)
        Me.Controls.Add(Me.addacct)
        Me.Controls.Add(Me.Cancel)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(6, 46)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ar_bat_lookup"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Open Cash Batch Look Up"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents AddToBatch As System.Windows.Forms.Button
    Public WithEvents PrintbyChk As System.Windows.Forms.Button
    Friend WithEvents PushExcel As System.Windows.Forms.Button
#End Region 
End Class