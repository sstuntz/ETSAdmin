<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class cc_dup_Dep
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
	Public WithEvents prenote_date As System.Windows.Forms.TextBox
    Public WithEvents dirdepach As System.Windows.Forms.Button
    Public WithEvents prenote_rpt As System.Windows.Forms.Button
	Public WithEvents prenote As System.Windows.Forms.Button
	Public WithEvents dirdeprpt As System.Windows.Forms.Button
    Public WithEvents Cancel As System.Windows.Forms.Button
	Public WithEvents Process As System.Windows.Forms.Button
	Public WithEvents check_Date As System.Windows.Forms.TextBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Line2 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Line1 As Microsoft.VisualBasic.PowerPacks.LineShape
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Me.Line2 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.Line1 = New Microsoft.VisualBasic.PowerPacks.LineShape
        Me.prenote_date = New System.Windows.Forms.TextBox
        Me.dirdepach = New System.Windows.Forms.Button
        Me.prenote_rpt = New System.Windows.Forms.Button
        Me.prenote = New System.Windows.Forms.Button
        Me.dirdeprpt = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.Process = New System.Windows.Forms.Button
        Me.check_Date = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Line2, Me.Line1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(498, 457)
        Me.ShapeContainer1.TabIndex = 18
        Me.ShapeContainer1.TabStop = False
        '
        'Line2
        '
        Me.Line2.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Line2.Name = "Line2"
        Me.Line2.X1 = 16
        Me.Line2.X2 = 480
        Me.Line2.Y1 = 40
        Me.Line2.Y2 = 40
        '
        'Line1
        '
        Me.Line1.BorderColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 216
        Me.Line1.X2 = 216
        Me.Line1.Y1 = 40
        Me.Line1.Y2 = 344
        '
        'prenote_date
        '
        Me.prenote_date.AcceptsReturn = True
        Me.prenote_date.BackColor = System.Drawing.SystemColors.Window
        Me.prenote_date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.prenote_date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prenote_date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.prenote_date.Location = New System.Drawing.Point(40, 160)
        Me.prenote_date.MaxLength = 0
        Me.prenote_date.Name = "prenote_date"
        Me.prenote_date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.prenote_date.Size = New System.Drawing.Size(106, 20)
        Me.prenote_date.TabIndex = 10
        '
        'dirdepach
        '
        Me.dirdepach.BackColor = System.Drawing.SystemColors.Control
        Me.dirdepach.Cursor = System.Windows.Forms.Cursors.Default
        Me.dirdepach.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dirdepach.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dirdepach.Location = New System.Drawing.Point(272, 280)
        Me.dirdepach.Name = "dirdepach"
        Me.dirdepach.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dirdepach.Size = New System.Drawing.Size(201, 33)
        Me.dirdepach.TabIndex = 9
        Me.dirdepach.Text = "Direct Deposit Report from CCACH"
        Me.dirdepach.UseVisualStyleBackColor = False
        '
        'prenote_rpt
        '
        Me.prenote_rpt.BackColor = System.Drawing.SystemColors.Control
        Me.prenote_rpt.Cursor = System.Windows.Forms.Cursors.Default
        Me.prenote_rpt.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prenote_rpt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.prenote_rpt.Location = New System.Drawing.Point(24, 272)
        Me.prenote_rpt.Name = "prenote_rpt"
        Me.prenote_rpt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.prenote_rpt.Size = New System.Drawing.Size(145, 33)
        Me.prenote_rpt.TabIndex = 8
        Me.prenote_rpt.Text = "Pre-Note Report"
        Me.prenote_rpt.UseVisualStyleBackColor = False
        '
        'prenote
        '
        Me.prenote.BackColor = System.Drawing.SystemColors.Control
        Me.prenote.Cursor = System.Windows.Forms.Cursors.Default
        Me.prenote.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prenote.ForeColor = System.Drawing.SystemColors.ControlText
        Me.prenote.Location = New System.Drawing.Point(24, 200)
        Me.prenote.Name = "prenote"
        Me.prenote.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.prenote.Size = New System.Drawing.Size(145, 41)
        Me.prenote.TabIndex = 7
        Me.prenote.Text = "Create Pre-Note File"
        Me.prenote.UseVisualStyleBackColor = False
        '
        'dirdeprpt
        '
        Me.dirdeprpt.BackColor = System.Drawing.SystemColors.Control
        Me.dirdeprpt.Cursor = System.Windows.Forms.Cursors.Default
        Me.dirdeprpt.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dirdeprpt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dirdeprpt.Location = New System.Drawing.Point(272, 232)
        Me.dirdeprpt.Name = "dirdeprpt"
        Me.dirdeprpt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dirdeprpt.Size = New System.Drawing.Size(201, 33)
        Me.dirdeprpt.TabIndex = 6
        Me.dirdeprpt.Text = " Direct Deposit Report from CCCKSTUB"
        Me.dirdeprpt.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(408, 8)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(65, 25)
        Me.Cancel.TabIndex = 2
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Process
        '
        Me.Process.BackColor = System.Drawing.SystemColors.Control
        Me.Process.Cursor = System.Windows.Forms.Cursors.Default
        Me.Process.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Process.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Process.Location = New System.Drawing.Point(304, 176)
        Me.Process.Name = "Process"
        Me.Process.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Process.Size = New System.Drawing.Size(129, 33)
        Me.Process.TabIndex = 1
        Me.Process.Text = "Create Deposit File"
        Me.Process.UseVisualStyleBackColor = False
        '
        'check_Date
        '
        Me.check_Date.AcceptsReturn = True
        Me.check_Date.BackColor = System.Drawing.SystemColors.Window
        Me.check_Date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.check_Date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.check_Date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.check_Date.Location = New System.Drawing.Point(312, 144)
        Me.check_Date.MaxLength = 0
        Me.check_Date.Name = "check_Date"
        Me.check_Date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.check_Date.Size = New System.Drawing.Size(106, 20)
        Me.check_Date.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(32, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(148, 39)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Enter the Date of the last Pre Note File."
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(248, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(201, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Create Direct Deposit File"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(177, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Create Pre-Note Data File"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(232, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(148, 39)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Enter Check Date for which you want to process the direct deposit"
        '
        'cc_dup_Dep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(498, 457)
        Me.ControlBox = False
        Me.Controls.Add(Me.prenote_date)
        Me.Controls.Add(Me.dirdepach)
        Me.Controls.Add(Me.prenote_rpt)
        Me.Controls.Add(Me.prenote)
        Me.Controls.Add(Me.dirdeprpt)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Process)
        Me.Controls.Add(Me.check_Date)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(111, 103)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "cc_dup_Dep"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create Consumer Direct Deposit Files - Net ck only To A:"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class