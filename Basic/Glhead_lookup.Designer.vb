<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class glhead_lookup
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
    Public WithEvents cmdAdd As System.Windows.Forms.Button
    Public WithEvents cmdDelete As System.Windows.Forms.Button
    Public WithEvents cancel As System.Windows.Forms.Button
    Public WithEvents txtField8 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cancel = New System.Windows.Forms.Button
        Me.txtField8 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.gl_ref_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acct_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.heading_1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.min_1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.max_1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.heading_2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.min_2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.max_2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.heading_3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.min_3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.max_3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Accept = New System.Windows.Forms.Button
        Me.edit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.txtField8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAdd.Location = New System.Drawing.Point(499, 24)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAdd.Size = New System.Drawing.Size(73, 23)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "&Add"
        Me.cmdAdd.UseVisualStyleBackColor = False
        '
        'cmdDelete
        '
        Me.cmdDelete.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDelete.Location = New System.Drawing.Point(588, 420)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDelete.Size = New System.Drawing.Size(65, 20)
        Me.cmdDelete.TabIndex = 23
        Me.cmdDelete.Text = "&Delete"
        Me.cmdDelete.UseVisualStyleBackColor = False
        Me.cmdDelete.Visible = False
        '
        'cancel
        '
        Me.cancel.BackColor = System.Drawing.SystemColors.Control
        Me.cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cancel.Location = New System.Drawing.Point(685, 5)
        Me.cancel.Name = "cancel"
        Me.cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cancel.Size = New System.Drawing.Size(65, 20)
        Me.cancel.TabIndex = 25
        Me.cancel.Text = "Cancel"
        Me.cancel.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gl_ref_no, Me.acct_type, Me.heading_1, Me.min_1, Me.max_1, Me.heading_2, Me.min_2, Me.max_2, Me.heading_3, Me.min_3, Me.max_3})
        Me.DataGridView1.Location = New System.Drawing.Point(27, 131)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(723, 283)
        Me.DataGridView1.TabIndex = 29
        '
        'gl_ref_no
        '
        Me.gl_ref_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.gl_ref_no.DataPropertyName = "gl_ref_no"
        Me.gl_ref_no.HeaderText = "Ref#"
        Me.gl_ref_no.Name = "gl_ref_no"
        Me.gl_ref_no.ReadOnly = True
        Me.gl_ref_no.Width = 55
        '
        'acct_type
        '
        Me.acct_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.acct_type.DataPropertyName = "acct_type"
        Me.acct_type.HeaderText = "Type"
        Me.acct_type.Name = "acct_type"
        Me.acct_type.ReadOnly = True
        Me.acct_type.Width = 55
        '
        'heading_1
        '
        Me.heading_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.heading_1.DataPropertyName = "heading_1"
        Me.heading_1.HeaderText = "Head 1"
        Me.heading_1.Name = "heading_1"
        Me.heading_1.ReadOnly = True
        Me.heading_1.Width = 66
        '
        'min_1
        '
        Me.min_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.min_1.DataPropertyName = "min_1"
        Me.min_1.HeaderText = "Min 1"
        Me.min_1.Name = "min_1"
        Me.min_1.ReadOnly = True
        Me.min_1.Width = 57
        '
        'max_1
        '
        Me.max_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.max_1.DataPropertyName = "max_1"
        Me.max_1.HeaderText = "Max 1"
        Me.max_1.Name = "max_1"
        Me.max_1.ReadOnly = True
        Me.max_1.Width = 61
        '
        'heading_2
        '
        Me.heading_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.heading_2.DataPropertyName = "heading_2"
        Me.heading_2.HeaderText = "Head 2"
        Me.heading_2.Name = "heading_2"
        Me.heading_2.ReadOnly = True
        Me.heading_2.Width = 66
        '
        'min_2
        '
        Me.min_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.min_2.DataPropertyName = "min_2"
        Me.min_2.HeaderText = "Min 2"
        Me.min_2.Name = "min_2"
        Me.min_2.ReadOnly = True
        Me.min_2.Width = 57
        '
        'max_2
        '
        Me.max_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.max_2.DataPropertyName = "max_2"
        Me.max_2.HeaderText = "Max 2"
        Me.max_2.Name = "max_2"
        Me.max_2.ReadOnly = True
        Me.max_2.Width = 61
        '
        'heading_3
        '
        Me.heading_3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.heading_3.DataPropertyName = "heading_3"
        Me.heading_3.HeaderText = "Head 3"
        Me.heading_3.Name = "heading_3"
        Me.heading_3.ReadOnly = True
        Me.heading_3.Width = 66
        '
        'min_3
        '
        Me.min_3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.min_3.DataPropertyName = "min_3"
        Me.min_3.HeaderText = "Min 3"
        Me.min_3.Name = "min_3"
        Me.min_3.ReadOnly = True
        Me.min_3.Width = 57
        '
        'max_3
        '
        Me.max_3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.max_3.DataPropertyName = "max_3"
        Me.max_3.HeaderText = "Max 3"
        Me.max_3.Name = "max_3"
        Me.max_3.ReadOnly = True
        Me.max_3.Width = 61
        '
        'Accept
        '
        Me.Accept.BackColor = System.Drawing.SystemColors.Control
        Me.Accept.Cursor = System.Windows.Forms.Cursors.Default
        Me.Accept.Enabled = False
        Me.Accept.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Accept.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Accept.Location = New System.Drawing.Point(626, 52)
        Me.Accept.Name = "Accept"
        Me.Accept.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Accept.Size = New System.Drawing.Size(137, 49)
        Me.Accept.TabIndex = 30
        Me.Accept.Text = "Use Selected Number"
        Me.Accept.UseVisualStyleBackColor = False
        '
        'edit
        '
        Me.edit.BackColor = System.Drawing.SystemColors.Control
        Me.edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.edit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edit.Location = New System.Drawing.Point(499, 63)
        Me.edit.Name = "edit"
        Me.edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edit.Size = New System.Drawing.Size(73, 26)
        Me.edit.TabIndex = 31
        Me.edit.Text = "Edit"
        Me.edit.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(40, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(278, 52)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Highlight a record and then click the EDIT button or just select the ADD button."
        '
        'glhead_lookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(775, 456)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.edit)
        Me.Controls.Add(Me.Accept)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cancel)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(2, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "glhead_lookup"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "General Ledger Category Headings"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.txtField8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Public WithEvents Accept As System.Windows.Forms.Button
    Public WithEvents edit As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gl_ref_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acct_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents heading_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents min_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents max_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents heading_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents min_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents max_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents heading_3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents min_3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents max_3 As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class