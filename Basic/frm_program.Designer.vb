<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frm_program
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
    Public WithEvents PrintRpt As System.Windows.Forms.Button
    Public WithEvents _txtField0_0 As System.Windows.Forms.TextBox
    Public WithEvents _txtField1_1 As System.Windows.Forms.TextBox
    Public WithEvents cmdAdd As System.Windows.Forms.Button
    Public WithEvents cmdUpdate As System.Windows.Forms.Button
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
    Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents txtField0 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents txtField1 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_program))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PrintRpt = New System.Windows.Forms.Button
        Me._txtField0_0 = New System.Windows.Forms.TextBox
        Me._txtField1_1 = New System.Windows.Forms.TextBox
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me._lblLabels_0 = New System.Windows.Forms.Label
        Me._lblLabels_1 = New System.Windows.Forms.Label
        Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.txtField0 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.txtField1 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.cmddel = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdedit = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtField0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtField1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PrintRpt
        '
        Me.PrintRpt.BackColor = System.Drawing.SystemColors.Control
        Me.PrintRpt.Cursor = System.Windows.Forms.Cursors.Default
        Me.PrintRpt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintRpt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PrintRpt.Location = New System.Drawing.Point(571, 415)
        Me.PrintRpt.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PrintRpt.Name = "PrintRpt"
        Me.PrintRpt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PrintRpt.Size = New System.Drawing.Size(268, 38)
        Me.PrintRpt.TabIndex = 10
        Me.PrintRpt.Text = "Print Program Report"
        Me.PrintRpt.UseVisualStyleBackColor = False
        '
        '_txtField0_0
        '
        Me._txtField0_0.AcceptsReturn = True
        Me._txtField0_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtField0_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtField0_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtField0_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtField0.SetIndex(Me._txtField0_0, CType(0, Short))
        Me._txtField0_0.Location = New System.Drawing.Point(321, 314)
        Me._txtField0_0.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me._txtField0_0.MaxLength = 2
        Me._txtField0_0.Name = "_txtField0_0"
        Me._txtField0_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtField0_0.Size = New System.Drawing.Size(53, 20)
        Me._txtField0_0.TabIndex = 1
        Me._txtField0_0.Tag = "acct_pgm"
        '
        '_txtField1_1
        '
        Me._txtField1_1.AcceptsReturn = True
        Me._txtField1_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtField1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtField1_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtField1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtField1.SetIndex(Me._txtField1_1, CType(1, Short))
        Me._txtField1_1.Location = New System.Drawing.Point(321, 351)
        Me._txtField1_1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me._txtField1_1.MaxLength = 30
        Me._txtField1_1.Name = "_txtField1_1"
        Me._txtField1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtField1_1.Size = New System.Drawing.Size(299, 20)
        Me._txtField1_1.TabIndex = 3
        Me._txtField1_1.Tag = "prog_desc"
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAdd.Location = New System.Drawing.Point(841, 95)
        Me.cmdAdd.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAdd.Size = New System.Drawing.Size(87, 43)
        Me.cmdAdd.TabIndex = 4
        Me.cmdAdd.Text = "&Add"
        Me.cmdAdd.UseVisualStyleBackColor = False
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUpdate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUpdate.Location = New System.Drawing.Point(841, 266)
        Me.cmdUpdate.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUpdate.Size = New System.Drawing.Size(87, 46)
        Me.cmdUpdate.TabIndex = 7
        Me.cmdUpdate.Text = "&Update"
        Me.cmdUpdate.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(867, 12)
        Me.cmdClose.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(87, 23)
        Me.cmdClose.TabIndex = 8
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(11, 46)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(215, 149)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        '_lblLabels_0
        '
        Me._lblLabels_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_0, CType(0, Short))
        Me._lblLabels_0.Location = New System.Drawing.Point(129, 314)
        Me._lblLabels_0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblLabels_0.Name = "_lblLabels_0"
        Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_0.Size = New System.Drawing.Size(161, 19)
        Me._lblLabels_0.TabIndex = 0
        Me._lblLabels_0.Text = "Program Number"
        '
        '_lblLabels_1
        '
        Me._lblLabels_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_1, CType(1, Short))
        Me._lblLabels_1.Location = New System.Drawing.Point(129, 351)
        Me._lblLabels_1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me._lblLabels_1.Name = "_lblLabels_1"
        Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_1.Size = New System.Drawing.Size(161, 19)
        Me._lblLabels_1.TabIndex = 2
        Me._lblLabels_1.Text = "Program Description"
        '
        'txtField0
        '
        '
        'txtField1
        '
        '
        'cmddel
        '
        Me.cmddel.Location = New System.Drawing.Point(321, 408)
        Me.cmddel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmddel.Name = "cmddel"
        Me.cmddel.Size = New System.Drawing.Size(100, 26)
        Me.cmddel.TabIndex = 12
        Me.cmddel.Text = "Delete"
        Me.cmddel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 415)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(275, 19)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Select Prog and click here to Delete"
        '
        'cmdedit
        '
        Me.cmdedit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdedit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdedit.Location = New System.Drawing.Point(841, 179)
        Me.cmdedit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdedit.Size = New System.Drawing.Size(87, 39)
        Me.cmdedit.TabIndex = 14
        Me.cmdedit.Text = "&Edit"
        Me.cmdedit.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(267, 45)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(547, 239)
        Me.DataGridView1.TabIndex = 15
        '
        'frm_program
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(977, 506)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmdedit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmddel)
        Me.Controls.Add(Me.PrintRpt)
        Me.Controls.Add(Me._txtField0_0)
        Me.Controls.Add(Me._txtField1_1)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._lblLabels_0)
        Me.Controls.Add(Me._lblLabels_1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(13, 42)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_program"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "General Ledger Programs - Add/Edit"
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtField0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtField1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmddel As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
#End Region
End Class