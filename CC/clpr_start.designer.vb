<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class clpr_start
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
    Public WithEvents Cancel As System.Windows.Forms.Button
    Public WithEvents Process As System.Windows.Forms.Button
    Public WithEvents Pr_num1 As System.Windows.Forms.TextBox
    Public WithEvents sys_Date As System.Windows.Forms.TextBox
    Public WithEvents pr_end_Date1 As System.Windows.Forms.TextBox
    Public WithEvents pr_Start_date1 As System.Windows.Forms.TextBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Cancel = New System.Windows.Forms.Button
        Me.Process = New System.Windows.Forms.Button
        Me.Pr_num1 = New System.Windows.Forms.TextBox
        Me.sys_Date = New System.Windows.Forms.TextBox
        Me.pr_end_Date1 = New System.Windows.Forms.TextBox
        Me.pr_Start_date1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(352, 16)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(72, 33)
        Me.Cancel.TabIndex = 5
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Process
        '
        Me.Process.BackColor = System.Drawing.SystemColors.Control
        Me.Process.Cursor = System.Windows.Forms.Cursors.Default
        Me.Process.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Process.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Process.Location = New System.Drawing.Point(128, 192)
        Me.Process.Name = "Process"
        Me.Process.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Process.Size = New System.Drawing.Size(129, 33)
        Me.Process.TabIndex = 4
        Me.Process.Text = "Start Payroll Entry"
        Me.Process.UseVisualStyleBackColor = False
        '
        'Pr_num1
        '
        Me.Pr_num1.AcceptsReturn = True
        Me.Pr_num1.BackColor = System.Drawing.SystemColors.Window
        Me.Pr_num1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Pr_num1.Enabled = False
        Me.Pr_num1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pr_num1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Pr_num1.Location = New System.Drawing.Point(208, 144)
        Me.Pr_num1.MaxLength = 0
        Me.Pr_num1.Name = "Pr_num1"
        Me.Pr_num1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Pr_num1.Size = New System.Drawing.Size(97, 20)
        Me.Pr_num1.TabIndex = 3
        '
        'sys_Date
        '
        Me.sys_Date.AcceptsReturn = True
        Me.sys_Date.BackColor = System.Drawing.SystemColors.Window
        Me.sys_Date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sys_Date.Enabled = False
        Me.sys_Date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sys_Date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sys_Date.Location = New System.Drawing.Point(72, 144)
        Me.sys_Date.MaxLength = 0
        Me.sys_Date.Name = "sys_Date"
        Me.sys_Date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sys_Date.Size = New System.Drawing.Size(97, 20)
        Me.sys_Date.TabIndex = 2
        '
        'pr_end_Date1
        '
        Me.pr_end_Date1.AcceptsReturn = True
        Me.pr_end_Date1.BackColor = System.Drawing.SystemColors.Window
        Me.pr_end_Date1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.pr_end_Date1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pr_end_Date1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.pr_end_Date1.Location = New System.Drawing.Point(208, 80)
        Me.pr_end_Date1.MaxLength = 0
        Me.pr_end_Date1.Name = "pr_end_Date1"
        Me.pr_end_Date1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pr_end_Date1.Size = New System.Drawing.Size(97, 20)
        Me.pr_end_Date1.TabIndex = 1
        '
        'pr_Start_date1
        '
        Me.pr_Start_date1.AcceptsReturn = True
        Me.pr_Start_date1.BackColor = System.Drawing.SystemColors.Window
        Me.pr_Start_date1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.pr_Start_date1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pr_Start_date1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.pr_Start_date1.Location = New System.Drawing.Point(72, 80)
        Me.pr_Start_date1.MaxLength = 0
        Me.pr_Start_date1.Name = "pr_Start_date1"
        Me.pr_Start_date1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pr_Start_date1.Size = New System.Drawing.Size(97, 20)
        Me.pr_Start_date1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(216, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(97, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Payroll Number"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(80, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(81, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Entry Date"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(216, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Payroll End Date"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(80, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Payroll Start Date"
        '
        'cc_start
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(446, 396)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Process)
        Me.Controls.Add(Me.Pr_num1)
        Me.Controls.Add(Me.sys_Date)
        Me.Controls.Add(Me.pr_end_Date1)
        Me.Controls.Add(Me.pr_Start_date1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(58, 101)
        Me.Name = "cc_start"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Payroll"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class