<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmje_x2
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
    Public WithEvents PostDateList As System.Windows.Forms.Button
    Public WithEvents AlphaList As System.Windows.Forms.Button
    Public WithEvents Add_sel As System.Windows.Forms.Button
    Public WithEvents Cancel As System.Windows.Forms.Button
    Public WithEvents text2 As System.Windows.Forms.TextBox
    Public WithEvents encum_date As System.Windows.Forms.TextBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PostDateList = New System.Windows.Forms.Button
        Me.AlphaList = New System.Windows.Forms.Button
        Me.Add_sel = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.text2 = New System.Windows.Forms.TextBox
        Me.encum_date = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.je_tbl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.je_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Post_Date = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PostDateList
        '
        Me.PostDateList.BackColor = System.Drawing.SystemColors.Control
        Me.PostDateList.Cursor = System.Windows.Forms.Cursors.Default
        Me.PostDateList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PostDateList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PostDateList.Location = New System.Drawing.Point(376, 144)
        Me.PostDateList.Name = "PostDateList"
        Me.PostDateList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PostDateList.Size = New System.Drawing.Size(209, 33)
        Me.PostDateList.TabIndex = 10
        Me.PostDateList.Text = "Refresh List by Posting Date/Alpha"
        Me.PostDateList.UseVisualStyleBackColor = False
        '
        'AlphaList
        '
        Me.AlphaList.BackColor = System.Drawing.SystemColors.Control
        Me.AlphaList.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlphaList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AlphaList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.AlphaList.Location = New System.Drawing.Point(376, 96)
        Me.AlphaList.Name = "AlphaList"
        Me.AlphaList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AlphaList.Size = New System.Drawing.Size(209, 33)
        Me.AlphaList.TabIndex = 9
        Me.AlphaList.Text = "Refresh List Alphabetically"
        Me.AlphaList.UseVisualStyleBackColor = False
        '
        'Add_sel
        '
        Me.Add_sel.BackColor = System.Drawing.SystemColors.Control
        Me.Add_sel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Add_sel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Add_sel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Add_sel.Location = New System.Drawing.Point(392, 192)
        Me.Add_sel.Name = "Add_sel"
        Me.Add_sel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Add_sel.Size = New System.Drawing.Size(155, 89)
        Me.Add_sel.TabIndex = 1
        Me.Add_sel.Text = "Add SELECTED Standard Journal Entry to the General Ledger"
        Me.Add_sel.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(472, 8)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(89, 25)
        Me.Cancel.TabIndex = 3
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'text2
        '
        Me.text2.AcceptsReturn = True
        Me.text2.BackColor = System.Drawing.SystemColors.Window
        Me.text2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.text2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.text2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.text2.Location = New System.Drawing.Point(456, 440)
        Me.text2.MaxLength = 0
        Me.text2.Name = "text2"
        Me.text2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.text2.Size = New System.Drawing.Size(49, 20)
        Me.text2.TabIndex = 2
        Me.text2.Tag = "jrnl_num"
        Me.text2.Text = "Text2"
        Me.text2.Visible = False
        '
        'encum_date
        '
        Me.encum_date.AcceptsReturn = True
        Me.encum_date.BackColor = System.Drawing.SystemColors.Window
        Me.encum_date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.encum_date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.encum_date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.encum_date.Location = New System.Drawing.Point(265, 14)
        Me.encum_date.MaxLength = 0
        Me.encum_date.Name = "encum_date"
        Me.encum_date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.encum_date.Size = New System.Drawing.Size(97, 20)
        Me.encum_date.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(232, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(81, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Last Post Date"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(128, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(65, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Description"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(32, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Record#"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(32, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(482, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "2.  Select  a Standard Entry from the list and then select "" Add selected entry t" & _
            "o General Ledger."""
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(30, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(199, 21)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "1. Enter this months Effective Date:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.je_tbl, Me.je_desc, Me.Post_Date})
        Me.DataGridView1.Location = New System.Drawing.Point(33, 121)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(329, 317)
        Me.DataGridView1.TabIndex = 15
        '
        'je_tbl
        '
        Me.je_tbl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.je_tbl.DataPropertyName = "je_tbl"
        Me.je_tbl.HeaderText = "JE Num"
        Me.je_tbl.Name = "je_tbl"
        Me.je_tbl.ReadOnly = True
        Me.je_tbl.Width = 67
        '
        'je_desc
        '
        Me.je_desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.je_desc.DataPropertyName = "je_desc"
        Me.je_desc.HeaderText = "Desc"
        Me.je_desc.Name = "je_desc"
        Me.je_desc.ReadOnly = True
        Me.je_desc.Width = 57
        '
        'Post_Date
        '
        Me.Post_Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Post_Date.DataPropertyName = "post_date"
        Me.Post_Date.HeaderText = "Post Date"
        Me.Post_Date.Name = "Post_Date"
        Me.Post_Date.ReadOnly = True
        Me.Post_Date.Width = 78
        '
        'frmje_x2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(607, 483)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.PostDateList)
        Me.Controls.Add(Me.AlphaList)
        Me.Controls.Add(Me.Add_sel)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.text2)
        Me.Controls.Add(Me.encum_date)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(21, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmje_x2"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Add Standard J/E's to Current Month"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents je_tbl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents je_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Post_Date As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region 
End Class