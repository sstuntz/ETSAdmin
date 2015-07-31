<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmnamechk
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
    Public WithEvents Selectname As System.Windows.Forms.Button
	Public WithEvents Cancel As System.Windows.Forms.Button
	Public WithEvents Add_Renamed As System.Windows.Forms.Button
    Public WithEvents txtinname As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmnamechk))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.edit = New System.Windows.Forms.Button
        Me.Selectname = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.Add_Renamed = New System.Windows.Forms.Button
        Me.txtinname = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Sort_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Name_key = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Screen_nam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'edit
        '
        Me.edit.BackColor = System.Drawing.SystemColors.Control
        Me.edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.edit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edit.Location = New System.Drawing.Point(487, 54)
        Me.edit.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.edit.Name = "edit"
        Me.edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edit.Size = New System.Drawing.Size(56, 41)
        Me.edit.TabIndex = 3
        Me.edit.Text = "Edit"
        Me.edit.UseVisualStyleBackColor = False
        '
        'Selectname
        '
        Me.Selectname.BackColor = System.Drawing.SystemColors.Control
        Me.Selectname.Cursor = System.Windows.Forms.Cursors.Default
        Me.Selectname.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Selectname.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Selectname.Location = New System.Drawing.Point(412, 110)
        Me.Selectname.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Selectname.Name = "Selectname"
        Me.Selectname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Selectname.Size = New System.Drawing.Size(124, 41)
        Me.Selectname.TabIndex = 2
        Me.Selectname.Text = "Use Selected Name"
        Me.Selectname.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(602, 12)
        Me.Cancel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(76, 25)
        Me.Cancel.TabIndex = 6
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Add_Renamed
        '
        Me.Add_Renamed.BackColor = System.Drawing.SystemColors.Control
        Me.Add_Renamed.Cursor = System.Windows.Forms.Cursors.Default
        Me.Add_Renamed.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Add_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Add_Renamed.Location = New System.Drawing.Point(403, 55)
        Me.Add_Renamed.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Add_Renamed.Name = "Add_Renamed"
        Me.Add_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Add_Renamed.Size = New System.Drawing.Size(56, 41)
        Me.Add_Renamed.TabIndex = 5
        Me.Add_Renamed.Text = "Add"
        Me.Add_Renamed.UseVisualStyleBackColor = False
        '
        'txtinname
        '
        Me.txtinname.AcceptsReturn = True
        Me.txtinname.BackColor = System.Drawing.SystemColors.Window
        Me.txtinname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtinname.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinname.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtinname.Location = New System.Drawing.Point(124, 55)
        Me.txtinname.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtinname.MaxLength = 0
        Me.txtinname.Name = "txtinname"
        Me.txtinname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtinname.Size = New System.Drawing.Size(221, 20)
        Me.txtinname.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(138, 161)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(234, 49)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(127, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(186, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "To do a lookup enter the name you want to find in the box below. "
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sort_name, Me.Name_key, Me.Screen_nam})
        Me.DataGridView1.Location = New System.Drawing.Point(130, 230)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(478, 455)
        Me.DataGridView1.TabIndex = 11
        '
        'Sort_name
        '
        Me.Sort_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Sort_name.DataPropertyName = "sort_name"
        Me.Sort_name.HeaderText = "Sort Name"
        Me.Sort_name.Name = "Sort_name"
        Me.Sort_name.ReadOnly = True
        Me.Sort_name.Width = 82
        '
        'Name_key
        '
        Me.Name_key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Name_key.DataPropertyName = "name_key"
        Me.Name_key.HeaderText = "Key"
        Me.Name_key.Name = "Name_key"
        Me.Name_key.ReadOnly = True
        Me.Name_key.Width = 51
        '
        'Screen_nam
        '
        Me.Screen_nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Screen_nam.DataPropertyName = "screen_nam"
        Me.Screen_nam.HeaderText = "Screen Name"
        Me.Screen_nam.Name = "Screen_nam"
        Me.Screen_nam.ReadOnly = True
        Me.Screen_nam.Width = 97
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 14)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Screen Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 14)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Sort Name"
        '
        'TextBox1
        '
        Me.TextBox1.AcceptsReturn = True
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox1.Location = New System.Drawing.Point(124, 95)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TextBox1.MaxLength = 0
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox1.Size = New System.Drawing.Size(221, 20)
        Me.TextBox1.TabIndex = 13
        '
        'frmnamechk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(696, 697)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.edit)
        Me.Controls.Add(Me.Selectname)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Add_Renamed)
        Me.Controls.Add(Me.txtinname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Location = New System.Drawing.Point(39, 32)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmnamechk"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Name Check "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Sort_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Name_key As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Screen_nam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents TextBox1 As System.Windows.Forms.TextBox
#End Region
End Class