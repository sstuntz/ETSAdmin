<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frm_hmadp
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
    Public WithEvents _txtFields_2 As System.Windows.Forms.TextBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents _txtFields_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtFields_0 As System.Windows.Forms.TextBox
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents cmdUpdate As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
    Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._txtFields_2 = New System.Windows.Forms.TextBox
        Me.Command1 = New System.Windows.Forms.Button
        Me._txtFields_1 = New System.Windows.Forms.TextBox
        Me._txtFields_0 = New System.Windows.Forms.TextBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me._lblLabels_2 = New System.Windows.Forms.Label
        Me._lblLabels_1 = New System.Windows.Forms.Label
        Me._lblLabels_0 = New System.Windows.Forms.Label
        Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_txtFields_2
        '
        Me._txtFields_2.AcceptsReturn = True
        Me._txtFields_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFields.SetIndex(Me._txtFields_2, CType(3, Short))
        Me._txtFields_2.Location = New System.Drawing.Point(152, 144)
        Me._txtFields_2.MaxLength = 3
        Me._txtFields_2.Name = "_txtFields_2"
        Me._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_2.Size = New System.Drawing.Size(39, 19)
        Me._txtFields_2.TabIndex = 4
        Me._txtFields_2.Tag = "rec_num"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(144, 248)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(193, 33)
        Me.Command1.TabIndex = 9
        Me.Command1.Text = "Print ADP code Listing"
        Me.Command1.UseVisualStyleBackColor = False
        '
        '_txtFields_1
        '
        Me._txtFields_1.AcceptsReturn = True
        Me._txtFields_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFields.SetIndex(Me._txtFields_1, CType(1, Short))
        Me._txtFields_1.Location = New System.Drawing.Point(152, 101)
        Me._txtFields_1.MaxLength = 30
        Me._txtFields_1.Name = "_txtFields_1"
        Me._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_1.Size = New System.Drawing.Size(239, 19)
        Me._txtFields_1.TabIndex = 1
        Me._txtFields_1.Tag = "adp_desc"
        '
        '_txtFields_0
        '
        Me._txtFields_0.AcceptsReturn = True
        Me._txtFields_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFields.SetIndex(Me._txtFields_0, CType(0, Short))
        Me._txtFields_0.Location = New System.Drawing.Point(152, 56)
        Me._txtFields_0.MaxLength = 5
        Me._txtFields_0.Name = "_txtFields_0"
        Me._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_0.Size = New System.Drawing.Size(61, 19)
        Me._txtFields_0.TabIndex = 0
        Me._txtFields_0.Tag = "adp_code"
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(496, 5)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(65, 20)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUpdate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUpdate.Location = New System.Drawing.Point(392, 200)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUpdate.Size = New System.Drawing.Size(65, 20)
        Me.cmdUpdate.TabIndex = 2
        Me.cmdUpdate.Text = "Save"
        Me.cmdUpdate.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(104, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(245, 24)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Be sure to select SAVE after all Adds or editing"
        '
        '_lblLabels_2
        '
        Me._lblLabels_2.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_2, CType(2, Short))
        Me._lblLabels_2.Location = New System.Drawing.Point(56, 144)
        Me._lblLabels_2.Name = "_lblLabels_2"
        Me._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_2.Size = New System.Drawing.Size(52, 17)
        Me._lblLabels_2.TabIndex = 7
        Me._lblLabels_2.Text = "Rec_num"
        '
        '_lblLabels_1
        '
        Me._lblLabels_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_1, CType(1, Short))
        Me._lblLabels_1.Location = New System.Drawing.Point(56, 104)
        Me._lblLabels_1.Name = "_lblLabels_1"
        Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_1.Size = New System.Drawing.Size(76, 17)
        Me._lblLabels_1.TabIndex = 6
        Me._lblLabels_1.Text = "adp_desc (30)"
        '
        '_lblLabels_0
        '
        Me._lblLabels_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_0, CType(0, Short))
        Me._lblLabels_0.Location = New System.Drawing.Point(56, 56)
        Me._lblLabels_0.Name = "_lblLabels_0"
        Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_0.Size = New System.Drawing.Size(70, 17)
        Me._lblLabels_0.TabIndex = 5
        Me._lblLabels_0.Text = "adp_code (5)"
        '
        'txtFields
        '
        '
        'frm_hmadp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(572, 399)
        Me.ControlBox = False
        Me.Controls.Add(Me._txtFields_2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me._txtFields_1)
        Me.Controls.Add(Me._txtFields_0)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._lblLabels_2)
        Me.Controls.Add(Me._lblLabels_1)
        Me.Controls.Add(Me._lblLabels_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(38, 106)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_hmadp"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ADP CODES"
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class