<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class custrpt_lookup
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
    Public WithEvents RptDelete As System.Windows.Forms.Button
    Public WithEvents Start_date As System.Windows.Forms.TextBox
    Public WithEvents End_Date As System.Windows.Forms.TextBox
    Public WithEvents edit As System.Windows.Forms.Button
    Public WithEvents addacct As System.Windows.Forms.Button
    Public WithEvents Cancel As System.Windows.Forms.Button
    Public WithEvents Accept As System.Windows.Forms.Button
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RptDelete = New System.Windows.Forms.Button
        Me.Start_date = New System.Windows.Forms.TextBox
        Me.End_Date = New System.Windows.Forms.TextBox
        Me.edit = New System.Windows.Forms.Button
        Me.addacct = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.Accept = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.RptGrid = New System.Windows.Forms.DataGridView
        Me.rep_num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rprt_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rpt_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rpt_Screen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rpt_Date = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.RptGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RptDelete
        '
        Me.RptDelete.BackColor = System.Drawing.SystemColors.Control
        Me.RptDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.RptDelete.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RptDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RptDelete.Location = New System.Drawing.Point(384, 416)
        Me.RptDelete.Name = "RptDelete"
        Me.RptDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RptDelete.Size = New System.Drawing.Size(153, 33)
        Me.RptDelete.TabIndex = 9
        Me.RptDelete.Text = "Delete Selected Report"
        Me.RptDelete.UseVisualStyleBackColor = False
        '
        'Start_date
        '
        Me.Start_date.AcceptsReturn = True
        Me.Start_date.BackColor = System.Drawing.SystemColors.Window
        Me.Start_date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Start_date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Start_date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Start_date.Location = New System.Drawing.Point(400, 320)
        Me.Start_date.MaxLength = 0
        Me.Start_date.Name = "Start_date"
        Me.Start_date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Start_date.Size = New System.Drawing.Size(89, 20)
        Me.Start_date.TabIndex = 4
        Me.Start_date.Tag = "BEG_DATE"
        '
        'End_Date
        '
        Me.End_Date.AcceptsReturn = True
        Me.End_Date.BackColor = System.Drawing.SystemColors.Window
        Me.End_Date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.End_Date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.End_Date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.End_Date.Location = New System.Drawing.Point(400, 376)
        Me.End_Date.MaxLength = 0
        Me.End_Date.Name = "End_Date"
        Me.End_Date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.End_Date.Size = New System.Drawing.Size(89, 20)
        Me.End_Date.TabIndex = 6
        Me.End_Date.Tag = "END_DATE"
        '
        'edit
        '
        Me.edit.BackColor = System.Drawing.SystemColors.Control
        Me.edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.edit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edit.Location = New System.Drawing.Point(424, 104)
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
        Me.addacct.Location = New System.Drawing.Point(424, 40)
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
        Me.Cancel.Location = New System.Drawing.Point(488, 0)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(97, 25)
        Me.Cancel.TabIndex = 0
        Me.Cancel.TabStop = False
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Accept
        '
        Me.Accept.BackColor = System.Drawing.SystemColors.Control
        Me.Accept.Cursor = System.Windows.Forms.Cursors.Default
        Me.Accept.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Accept.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Accept.Location = New System.Drawing.Point(392, 184)
        Me.Accept.Name = "Accept"
        Me.Accept.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Accept.Size = New System.Drawing.Size(153, 33)
        Me.Accept.TabIndex = 1
        Me.Accept.Text = "Print"
        Me.Accept.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(392, 240)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(137, 33)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Date prompts if used in report."
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(392, 296)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(129, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Begin Date for Report"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(392, 352)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(129, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "End Date for Report"
        '
        'RptGrid
        '
        Me.RptGrid.AllowUserToAddRows = False
        Me.RptGrid.AllowUserToDeleteRows = False
        Me.RptGrid.AllowUserToOrderColumns = True
        Me.RptGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RptGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rep_num, Me.rprt_name, Me.Rpt_desc, Me.Rpt_Screen, Me.rpt_Date})
        Me.RptGrid.Location = New System.Drawing.Point(16, 58)
        Me.RptGrid.Name = "RptGrid"
        Me.RptGrid.ReadOnly = True
        Me.RptGrid.Size = New System.Drawing.Size(352, 391)
        Me.RptGrid.TabIndex = 14
        '
        'rep_num
        '
        Me.rep_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.rep_num.HeaderText = "Rpt Num"
        Me.rep_num.Name = "rep_num"
        Me.rep_num.ReadOnly = True
        Me.rep_num.Width = 78
        '
        'rprt_name
        '
        Me.rprt_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.rprt_name.HeaderText = "Rpt Name"
        Me.rprt_name.Name = "rprt_name"
        Me.rprt_name.ReadOnly = True
        Me.rprt_name.Width = 84
        '
        'Rpt_desc
        '
        Me.Rpt_desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Rpt_desc.HeaderText = "Rpt Desc"
        Me.Rpt_desc.Name = "Rpt_desc"
        Me.Rpt_desc.ReadOnly = True
        Me.Rpt_desc.Width = 80
        '
        'Rpt_Screen
        '
        Me.Rpt_Screen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Rpt_Screen.HeaderText = "Print/Screen"
        Me.Rpt_Screen.Name = "Rpt_Screen"
        Me.Rpt_Screen.ReadOnly = True
        '
        'rpt_Date
        '
        Me.rpt_Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.rpt_Date.HeaderText = "Dates"
        Me.rpt_Date.Name = "rpt_Date"
        Me.rpt_Date.ReadOnly = True
        Me.rpt_Date.Width = 63
        '
        'custrpt_lookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(593, 480)
        Me.ControlBox = False
        Me.Controls.Add(Me.RptGrid)
        Me.Controls.Add(Me.RptDelete)
        Me.Controls.Add(Me.Start_date)
        Me.Controls.Add(Me.End_Date)
        Me.Controls.Add(Me.edit)
        Me.Controls.Add(Me.addacct)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Accept)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Location = New System.Drawing.Point(29, 39)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "custrpt_lookup"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Custom Report Lookup List."
        CType(Me.RptGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RptGrid As System.Windows.Forms.DataGridView
    Friend WithEvents rep_num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rprt_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rpt_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rpt_Screen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rpt_Date As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class