<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class ar_cash_edit_sel
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
	Public WithEvents bat_bal As System.Windows.Forms.TextBox
    Public WithEvents del As System.Windows.Forms.Button
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.bat_bal = New System.Windows.Forms.TextBox()
        Me.del = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.AddEntry = New System.Windows.Forms.Button()
        Me.Save = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(445, 390)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(170, 25)
        Me.Command1.TabIndex = 9
        Me.Command1.Text = "Print Reg Cash Edit Report"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'bat_bal
        '
        Me.bat_bal.AcceptsReturn = True
        Me.bat_bal.BackColor = System.Drawing.SystemColors.Window
        Me.bat_bal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.bat_bal.Enabled = False
        Me.bat_bal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bat_bal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.bat_bal.Location = New System.Drawing.Point(518, 440)
        Me.bat_bal.MaxLength = 0
        Me.bat_bal.Name = "bat_bal"
        Me.bat_bal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.bat_bal.Size = New System.Drawing.Size(97, 20)
        Me.bat_bal.TabIndex = 7
        Me.bat_bal.Visible = False
        '
        'del
        '
        Me.del.BackColor = System.Drawing.SystemColors.Control
        Me.del.Cursor = System.Windows.Forms.Cursors.Default
        Me.del.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.del.ForeColor = System.Drawing.SystemColors.ControlText
        Me.del.Location = New System.Drawing.Point(19, 486)
        Me.del.Name = "del"
        Me.del.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.del.Size = New System.Drawing.Size(246, 33)
        Me.del.TabIndex = 6
        Me.del.Text = "Delete selected entry number/s  from Batch"
        Me.del.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(567, 2)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(68, 20)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.TabStop = False
        Me.cmdClose.Text = "Cancel "
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(365, 440)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(94, 18)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Balance of Batch:"
        Me.Label2.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(19, 66)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(596, 286)
        Me.DataGridView1.TabIndex = 13
        '
        'AddEntry
        '
        Me.AddEntry.Location = New System.Drawing.Point(19, 430)
        Me.AddEntry.Name = "AddEntry"
        Me.AddEntry.Size = New System.Drawing.Size(246, 35)
        Me.AddEntry.TabIndex = 14
        Me.AddEntry.Text = "Add an entry to selected Batch"
        Me.AddEntry.UseVisualStyleBackColor = True
        '
        'Save
        '
        Me.Save.Location = New System.Drawing.Point(19, 383)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(246, 32)
        Me.Save.TabIndex = 15
        Me.Save.Text = "Save Changes"
        Me.Save.UseVisualStyleBackColor = True
        '
        'ar_cash_edit_sel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(673, 550)
        Me.ControlBox = False
        Me.Controls.Add(Me.Save)
        Me.Controls.Add(Me.AddEntry)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.bat_bal)
        Me.Controls.Add(Me.del)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Label2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(-3, 26)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ar_cash_edit_sel"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "AR Cash Receipts Batch Entry Edit"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents AddEntry As System.Windows.Forms.Button
    Friend WithEvents Save As System.Windows.Forms.Button
#End Region 
End Class