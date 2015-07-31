<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class cc_chkvoid
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
    Public WithEvents rpt_prt As System.Windows.Forms.Button
    Public WithEvents done As System.Windows.Forms.Button
    Public WithEvents chk_num As System.Windows.Forms.TextBox
    Public WithEvents sys_Date As System.Windows.Forms.TextBox
    Public WithEvents Pr_num1 As System.Windows.Forms.TextBox
    Public WithEvents add_only As System.Windows.Forms.Button
    Public WithEvents Cancel As System.Windows.Forms.Button
    Public WithEvents void_add As System.Windows.Forms.Button
    Public WithEvents void_only As System.Windows.Forms.Button
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.rpt_prt = New System.Windows.Forms.Button()
        Me.done = New System.Windows.Forms.Button()
        Me.chk_num = New System.Windows.Forms.TextBox()
        Me.sys_Date = New System.Windows.Forms.TextBox()
        Me.Pr_num1 = New System.Windows.Forms.TextBox()
        Me.add_only = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.void_add = New System.Windows.Forms.Button()
        Me.void_only = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'rpt_prt
        '
        Me.rpt_prt.BackColor = System.Drawing.SystemColors.Control
        Me.rpt_prt.Cursor = System.Windows.Forms.Cursors.Default
        Me.rpt_prt.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpt_prt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rpt_prt.Location = New System.Drawing.Point(200, 312)
        Me.rpt_prt.Name = "rpt_prt"
        Me.rpt_prt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rpt_prt.Size = New System.Drawing.Size(185, 33)
        Me.rpt_prt.TabIndex = 12
        Me.rpt_prt.Text = "Print Voided Check Report"
        Me.rpt_prt.UseVisualStyleBackColor = False
        '
        'done
        '
        Me.done.BackColor = System.Drawing.SystemColors.Control
        Me.done.Cursor = System.Windows.Forms.Cursors.Default
        Me.done.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.done.ForeColor = System.Drawing.SystemColors.ControlText
        Me.done.Location = New System.Drawing.Point(408, 314)
        Me.done.Name = "done"
        Me.done.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.done.Size = New System.Drawing.Size(78, 30)
        Me.done.TabIndex = 10
        Me.done.Text = "Finished"
        Me.done.UseVisualStyleBackColor = False
        '
        'chk_num
        '
        Me.chk_num.AcceptsReturn = True
        Me.chk_num.BackColor = System.Drawing.SystemColors.Window
        Me.chk_num.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.chk_num.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_num.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chk_num.Location = New System.Drawing.Point(250, 83)
        Me.chk_num.MaxLength = 0
        Me.chk_num.Name = "chk_num"
        Me.chk_num.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chk_num.Size = New System.Drawing.Size(95, 20)
        Me.chk_num.TabIndex = 0
        Me.chk_num.Tag = "chk_num"
        '
        'sys_Date
        '
        Me.sys_Date.AcceptsReturn = True
        Me.sys_Date.BackColor = System.Drawing.SystemColors.Window
        Me.sys_Date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sys_Date.Enabled = False
        Me.sys_Date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sys_Date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sys_Date.Location = New System.Drawing.Point(104, 8)
        Me.sys_Date.MaxLength = 0
        Me.sys_Date.Name = "sys_Date"
        Me.sys_Date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sys_Date.Size = New System.Drawing.Size(89, 20)
        Me.sys_Date.TabIndex = 7
        Me.sys_Date.Tag = "entry_date"
        '
        'Pr_num1
        '
        Me.Pr_num1.AcceptsReturn = True
        Me.Pr_num1.BackColor = System.Drawing.SystemColors.Window
        Me.Pr_num1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Pr_num1.Enabled = False
        Me.Pr_num1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pr_num1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Pr_num1.Location = New System.Drawing.Point(317, 154)
        Me.Pr_num1.MaxLength = 0
        Me.Pr_num1.Name = "Pr_num1"
        Me.Pr_num1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Pr_num1.Size = New System.Drawing.Size(46, 20)
        Me.Pr_num1.TabIndex = 6
        Me.Pr_num1.Tag = "pr_num1"
        Me.Pr_num1.Visible = False
        '
        'add_only
        '
        Me.add_only.BackColor = System.Drawing.SystemColors.Control
        Me.add_only.Cursor = System.Windows.Forms.Cursors.Default
        Me.add_only.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_only.ForeColor = System.Drawing.SystemColors.ControlText
        Me.add_only.Location = New System.Drawing.Point(292, 216)
        Me.add_only.Name = "add_only"
        Me.add_only.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.add_only.Size = New System.Drawing.Size(201, 41)
        Me.add_only.TabIndex = 5
        Me.add_only.Text = "Edit Only - for the Service Bureau"
        Me.add_only.UseVisualStyleBackColor = False
        Me.add_only.Visible = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(424, 8)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(89, 25)
        Me.Cancel.TabIndex = 4
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'void_add
        '
        Me.void_add.BackColor = System.Drawing.SystemColors.Control
        Me.void_add.Cursor = System.Windows.Forms.Cursors.Default
        Me.void_add.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.void_add.ForeColor = System.Drawing.SystemColors.ControlText
        Me.void_add.Location = New System.Drawing.Point(161, 216)
        Me.void_add.Name = "void_add"
        Me.void_add.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.void_add.Size = New System.Drawing.Size(116, 41)
        Me.void_add.TabIndex = 3
        Me.void_add.Text = "Void/Add"
        Me.void_add.UseVisualStyleBackColor = False
        '
        'void_only
        '
        Me.void_only.BackColor = System.Drawing.SystemColors.Control
        Me.void_only.Cursor = System.Windows.Forms.Cursors.Default
        Me.void_only.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.void_only.ForeColor = System.Drawing.SystemColors.ControlText
        Me.void_only.Location = New System.Drawing.Point(33, 216)
        Me.void_only.Name = "void_only"
        Me.void_only.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.void_only.Size = New System.Drawing.Size(105, 41)
        Me.void_only.TabIndex = 2
        Me.void_only.Text = "Void Only"
        Me.void_only.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(81, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Entry Date"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(77, 149)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(198, 33)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "This is the Payroll Number assigned to a Void/Add"
        Me.Label4.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(57, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(169, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = " Enter check number to process"
        '
        'cc_chkvoid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(521, 424)
        Me.ControlBox = False
        Me.Controls.Add(Me.rpt_prt)
        Me.Controls.Add(Me.done)
        Me.Controls.Add(Me.chk_num)
        Me.Controls.Add(Me.sys_Date)
        Me.Controls.Add(Me.Pr_num1)
        Me.Controls.Add(Me.add_only)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.void_add)
        Me.Controls.Add(Me.void_only)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(58, 41)
        Me.Name = "cc_chkvoid"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Payroll- Void a Check"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class