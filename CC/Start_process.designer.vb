<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class start_process
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
    Public WithEvents full_pr As System.Windows.Forms.RadioButton
    Public WithEvents single_pr As System.Windows.Forms.RadioButton
    Public WithEvents end_Date As System.Windows.Forms.TextBox
    Public WithEvents Pr_num1 As System.Windows.Forms.TextBox
    Public WithEvents beg_chk_num As System.Windows.Forms.TextBox
    Public WithEvents close_pr As System.Windows.Forms.Button
    Public WithEvents chks_prted As System.Windows.Forms.TextBox
    Public WithEvents prt_Chk As System.Windows.Forms.Button
    Public WithEvents num_cks As System.Windows.Forms.TextBox
    Public WithEvents num_emp As System.Windows.Forms.TextBox
    Public WithEvents pr_Start_date1 As System.Windows.Forms.TextBox
    Public WithEvents sys_Date As System.Windows.Forms.TextBox
    Public WithEvents Process As System.Windows.Forms.Button
    Public WithEvents Cancel As System.Windows.Forms.Button
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.full_pr = New System.Windows.Forms.RadioButton()
        Me.single_pr = New System.Windows.Forms.RadioButton()
        Me.end_Date = New System.Windows.Forms.TextBox()
        Me.Pr_num1 = New System.Windows.Forms.TextBox()
        Me.beg_chk_num = New System.Windows.Forms.TextBox()
        Me.close_pr = New System.Windows.Forms.Button()
        Me.chks_prted = New System.Windows.Forms.TextBox()
        Me.prt_Chk = New System.Windows.Forms.Button()
        Me.num_cks = New System.Windows.Forms.TextBox()
        Me.num_emp = New System.Windows.Forms.TextBox()
        Me.pr_Start_date1 = New System.Windows.Forms.TextBox()
        Me.sys_Date = New System.Windows.Forms.TextBox()
        Me.Process = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'full_pr
        '
        Me.full_pr.BackColor = System.Drawing.SystemColors.Control
        Me.full_pr.Checked = True
        Me.full_pr.Cursor = System.Windows.Forms.Cursors.Default
        Me.full_pr.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.full_pr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.full_pr.Location = New System.Drawing.Point(2, 40)
        Me.full_pr.Name = "full_pr"
        Me.full_pr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.full_pr.Size = New System.Drawing.Size(81, 25)
        Me.full_pr.TabIndex = 21
        Me.full_pr.TabStop = True
        Me.full_pr.Text = "Full Payroll"
        Me.full_pr.UseVisualStyleBackColor = False
        '
        'single_pr
        '
        Me.single_pr.BackColor = System.Drawing.SystemColors.Control
        Me.single_pr.Cursor = System.Windows.Forms.Cursors.Default
        Me.single_pr.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.single_pr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.single_pr.Location = New System.Drawing.Point(2, 64)
        Me.single_pr.Name = "single_pr"
        Me.single_pr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.single_pr.Size = New System.Drawing.Size(81, 33)
        Me.single_pr.TabIndex = 20
        Me.single_pr.Text = "Single Check"
        Me.single_pr.UseVisualStyleBackColor = False
        '
        'end_Date
        '
        Me.end_Date.AcceptsReturn = True
        Me.end_Date.BackColor = System.Drawing.SystemColors.Window
        Me.end_Date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.end_Date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.end_Date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.end_Date.Location = New System.Drawing.Point(215, 200)
        Me.end_Date.MaxLength = 0
        Me.end_Date.Name = "end_Date"
        Me.end_Date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.end_Date.Size = New System.Drawing.Size(89, 20)
        Me.end_Date.TabIndex = 3
        '
        'Pr_num1
        '
        Me.Pr_num1.AcceptsReturn = True
        Me.Pr_num1.BackColor = System.Drawing.SystemColors.Window
        Me.Pr_num1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Pr_num1.Enabled = False
        Me.Pr_num1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pr_num1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Pr_num1.Location = New System.Drawing.Point(280, 8)
        Me.Pr_num1.MaxLength = 0
        Me.Pr_num1.Name = "Pr_num1"
        Me.Pr_num1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Pr_num1.Size = New System.Drawing.Size(73, 20)
        Me.Pr_num1.TabIndex = 7
        '
        'beg_chk_num
        '
        Me.beg_chk_num.AcceptsReturn = True
        Me.beg_chk_num.BackColor = System.Drawing.SystemColors.Window
        Me.beg_chk_num.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.beg_chk_num.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.beg_chk_num.ForeColor = System.Drawing.SystemColors.WindowText
        Me.beg_chk_num.Location = New System.Drawing.Point(215, 168)
        Me.beg_chk_num.MaxLength = 0
        Me.beg_chk_num.Name = "beg_chk_num"
        Me.beg_chk_num.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.beg_chk_num.Size = New System.Drawing.Size(89, 20)
        Me.beg_chk_num.TabIndex = 2
        '
        'close_pr
        '
        Me.close_pr.BackColor = System.Drawing.SystemColors.Control
        Me.close_pr.Cursor = System.Windows.Forms.Cursors.Default
        Me.close_pr.Enabled = False
        Me.close_pr.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.close_pr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.close_pr.Location = New System.Drawing.Point(120, 334)
        Me.close_pr.Name = "close_pr"
        Me.close_pr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.close_pr.Size = New System.Drawing.Size(209, 32)
        Me.close_pr.TabIndex = 5
        Me.close_pr.Text = "Close Payroll and Print Check Register"
        Me.close_pr.UseVisualStyleBackColor = False
        '
        'chks_prted
        '
        Me.chks_prted.AcceptsReturn = True
        Me.chks_prted.BackColor = System.Drawing.SystemColors.Window
        Me.chks_prted.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.chks_prted.Enabled = False
        Me.chks_prted.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chks_prted.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chks_prted.Location = New System.Drawing.Point(215, 288)
        Me.chks_prted.MaxLength = 0
        Me.chks_prted.Name = "chks_prted"
        Me.chks_prted.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chks_prted.Size = New System.Drawing.Size(89, 20)
        Me.chks_prted.TabIndex = 17
        '
        'prt_Chk
        '
        Me.prt_Chk.BackColor = System.Drawing.SystemColors.Control
        Me.prt_Chk.Cursor = System.Windows.Forms.Cursors.Default
        Me.prt_Chk.Enabled = False
        Me.prt_Chk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prt_Chk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.prt_Chk.Location = New System.Drawing.Point(160, 240)
        Me.prt_Chk.Name = "prt_Chk"
        Me.prt_Chk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.prt_Chk.Size = New System.Drawing.Size(134, 25)
        Me.prt_Chk.TabIndex = 4
        Me.prt_Chk.Text = "Print Checks"
        Me.prt_Chk.UseVisualStyleBackColor = False
        '
        'num_cks
        '
        Me.num_cks.AcceptsReturn = True
        Me.num_cks.BackColor = System.Drawing.SystemColors.Window
        Me.num_cks.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.num_cks.Enabled = False
        Me.num_cks.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.num_cks.ForeColor = System.Drawing.SystemColors.WindowText
        Me.num_cks.Location = New System.Drawing.Point(339, 127)
        Me.num_cks.MaxLength = 0
        Me.num_cks.Name = "num_cks"
        Me.num_cks.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.num_cks.Size = New System.Drawing.Size(81, 20)
        Me.num_cks.TabIndex = 15
        '
        'num_emp
        '
        Me.num_emp.AcceptsReturn = True
        Me.num_emp.BackColor = System.Drawing.SystemColors.Window
        Me.num_emp.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.num_emp.Enabled = False
        Me.num_emp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.num_emp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.num_emp.Location = New System.Drawing.Point(134, 127)
        Me.num_emp.MaxLength = 0
        Me.num_emp.Name = "num_emp"
        Me.num_emp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.num_emp.Size = New System.Drawing.Size(81, 20)
        Me.num_emp.TabIndex = 12
        '
        'pr_Start_date1
        '
        Me.pr_Start_date1.AcceptsReturn = True
        Me.pr_Start_date1.BackColor = System.Drawing.SystemColors.Window
        Me.pr_Start_date1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.pr_Start_date1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pr_Start_date1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.pr_Start_date1.Location = New System.Drawing.Point(215, 44)
        Me.pr_Start_date1.MaxLength = 0
        Me.pr_Start_date1.Name = "pr_Start_date1"
        Me.pr_Start_date1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pr_Start_date1.Size = New System.Drawing.Size(89, 20)
        Me.pr_Start_date1.TabIndex = 0
        '
        'sys_Date
        '
        Me.sys_Date.AcceptsReturn = True
        Me.sys_Date.BackColor = System.Drawing.SystemColors.Window
        Me.sys_Date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.sys_Date.Enabled = False
        Me.sys_Date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sys_Date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.sys_Date.Location = New System.Drawing.Point(80, 8)
        Me.sys_Date.MaxLength = 0
        Me.sys_Date.Name = "sys_Date"
        Me.sys_Date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.sys_Date.Size = New System.Drawing.Size(89, 20)
        Me.sys_Date.TabIndex = 8
        '
        'Process
        '
        Me.Process.BackColor = System.Drawing.SystemColors.Control
        Me.Process.Cursor = System.Windows.Forms.Cursors.Default
        Me.Process.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Process.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Process.Location = New System.Drawing.Point(160, 88)
        Me.Process.Name = "Process"
        Me.Process.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Process.Size = New System.Drawing.Size(134, 25)
        Me.Process.TabIndex = 1
        Me.Process.Text = "Print Payroll Edit"
        Me.Process.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(374, 24)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(67, 27)
        Me.Cancel.TabIndex = 6
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(67, 208)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(129, 25)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Enter Ending Period Date"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(67, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(129, 25)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Enter Beginning Check Number"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(120, 288)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(73, 25)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Checks Printed"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(242, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(89, 39)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Checks to be Printed"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(49, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(81, 25)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Employees Processed"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(99, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Payroll Check Date"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(2, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(81, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Entry Date"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(200, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(97, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Payroll Number"
        '
        'start_process
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(474, 457)
        Me.ControlBox = False
        Me.Controls.Add(Me.full_pr)
        Me.Controls.Add(Me.single_pr)
        Me.Controls.Add(Me.end_Date)
        Me.Controls.Add(Me.Pr_num1)
        Me.Controls.Add(Me.beg_chk_num)
        Me.Controls.Add(Me.close_pr)
        Me.Controls.Add(Me.chks_prted)
        Me.Controls.Add(Me.prt_Chk)
        Me.Controls.Add(Me.num_cks)
        Me.Controls.Add(Me.num_emp)
        Me.Controls.Add(Me.pr_Start_date1)
        Me.Controls.Add(Me.sys_Date)
        Me.Controls.Add(Me.Process)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(76, 27)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "start_process"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Payroll Edit/Update    (Orig Version)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
End Class