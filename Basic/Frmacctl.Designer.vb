<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class acctlookup
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
	Public WithEvents edit As System.Windows.Forms.Button
	Public WithEvents addacct As System.Windows.Forms.Button
	Public WithEvents Cancel As System.Windows.Forms.Button
	Public WithEvents Accept As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.edit = New System.Windows.Forms.Button
        Me.addacct = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.Accept = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Acct_only = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acct_num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acct_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gl_ref_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtinname = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape
        Me.Label99 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'edit
        '
        Me.edit.BackColor = System.Drawing.SystemColors.Control
        Me.edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.edit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edit.Location = New System.Drawing.Point(615, 235)
        Me.edit.Name = "edit"
        Me.edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edit.Size = New System.Drawing.Size(73, 49)
        Me.edit.TabIndex = 3
        Me.edit.Text = "Edit"
        Me.edit.UseVisualStyleBackColor = False
        '
        'addacct
        '
        Me.addacct.BackColor = System.Drawing.SystemColors.Control
        Me.addacct.Cursor = System.Windows.Forms.Cursors.Default
        Me.addacct.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addacct.ForeColor = System.Drawing.SystemColors.ControlText
        Me.addacct.Location = New System.Drawing.Point(615, 154)
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
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(591, 18)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(97, 25)
        Me.Cancel.TabIndex = 15
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Accept
        '
        Me.Accept.BackColor = System.Drawing.SystemColors.Control
        Me.Accept.Cursor = System.Windows.Forms.Cursors.Default
        Me.Accept.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Accept.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Accept.Location = New System.Drawing.Point(535, 70)
        Me.Accept.Name = "Accept"
        Me.Accept.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Accept.Size = New System.Drawing.Size(153, 49)
        Me.Accept.TabIndex = 1
        Me.Accept.Text = "Use Selected Number"
        Me.Accept.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(63, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(305, 33)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Highlight a record and then click the EDIT button or click on the ADD button."
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Acct_only, Me.acct_num, Me.acct_desc, Me.gl_ref_no})
        Me.DataGridView1.Location = New System.Drawing.Point(25, 200)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(514, 418)
        Me.DataGridView1.TabIndex = 8
        '
        'Acct_only
        '
        Me.Acct_only.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Acct_only.DataPropertyName = "acct_only"
        Me.Acct_only.HeaderText = "Acct_only"
        Me.Acct_only.Name = "Acct_only"
        Me.Acct_only.ReadOnly = True
        Me.Acct_only.Width = 85
        '
        'acct_num
        '
        Me.acct_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.acct_num.DataPropertyName = "acct_num"
        Me.acct_num.HeaderText = "Acct Number"
        Me.acct_num.Name = "acct_num"
        Me.acct_num.ReadOnly = True
        Me.acct_num.Width = 103
        '
        'acct_desc
        '
        Me.acct_desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.acct_desc.DataPropertyName = "acct_desc"
        Me.acct_desc.HeaderText = "Desc"
        Me.acct_desc.Name = "acct_desc"
        Me.acct_desc.ReadOnly = True
        Me.acct_desc.Width = 59
        '
        'gl_ref_no
        '
        Me.gl_ref_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.gl_ref_no.DataPropertyName = "gl_ref_no"
        Me.gl_ref_no.HeaderText = "Ref"
        Me.gl_ref_no.Name = "gl_ref_no"
        Me.gl_ref_no.ReadOnly = True
        Me.gl_ref_no.Width = 50
        '
        'txtinname
        '
        Me.txtinname.AcceptsReturn = True
        Me.txtinname.BackColor = System.Drawing.SystemColors.Window
        Me.txtinname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtinname.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinname.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtinname.Location = New System.Drawing.Point(57, 122)
        Me.txtinname.MaxLength = 0
        Me.txtinname.Name = "txtinname"
        Me.txtinname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtinname.Size = New System.Drawing.Size(66, 20)
        Me.txtinname.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(63, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(217, 33)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "To do a lookup enter the acct_only you want to find in the box below. "
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(730, 663)
        Me.ShapeContainer1.TabIndex = 16
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Location = New System.Drawing.Point(15, 8)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(706, 641)
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Location = New System.Drawing.Point(42, 25)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(43, 14)
        Me.Label99.TabIndex = 17
        Me.Label99.Text = "Label3"
        '
        'acctlookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(730, 663)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label99)
        Me.Controls.Add(Me.txtinname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.edit)
        Me.Controls.Add(Me.addacct)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Accept)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Location = New System.Drawing.Point(10, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "acctlookup"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Account Number Look up"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Public WithEvents txtinname As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Acct_only As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acct_num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acct_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gl_ref_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label99 As System.Windows.Forms.Label
#End Region
End Class