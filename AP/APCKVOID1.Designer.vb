<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class apckvoid1_frm
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
    Public WithEvents void_gl As System.Windows.Forms.Button
    Public WithEvents void_no_gl As System.Windows.Forms.Button
    Public WithEvents Label5 As System.Windows.Forms.Label
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
        Me.void_gl = New System.Windows.Forms.Button
        Me.void_no_gl = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.chk_num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Screen_nam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.net_amt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dt_paid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.vouch_num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.glpost = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dr_Acct_nu = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cr_acct_nu = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(355, 3)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(184, 33)
        Me.Cancel.TabIndex = 5
        Me.Cancel.Text = "Exit this screen - No Action"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'void_gl
        '
        Me.void_gl.BackColor = System.Drawing.SystemColors.Control
        Me.void_gl.Cursor = System.Windows.Forms.Cursors.Default
        Me.void_gl.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.void_gl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.void_gl.Location = New System.Drawing.Point(113, 471)
        Me.void_gl.Name = "void_gl"
        Me.void_gl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.void_gl.Size = New System.Drawing.Size(161, 41)
        Me.void_gl.TabIndex = 3
        Me.void_gl.Text = "Void Check Posted to G/L"
        Me.void_gl.UseVisualStyleBackColor = False
        '
        'void_no_gl
        '
        Me.void_no_gl.BackColor = System.Drawing.SystemColors.Control
        Me.void_no_gl.Cursor = System.Windows.Forms.Cursors.Default
        Me.void_no_gl.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.void_no_gl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.void_no_gl.Location = New System.Drawing.Point(113, 405)
        Me.void_no_gl.Name = "void_no_gl"
        Me.void_no_gl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.void_no_gl.Size = New System.Drawing.Size(161, 41)
        Me.void_no_gl.TabIndex = 1
        Me.void_no_gl.Text = "Void Check NOT posted to G/L"
        Me.void_no_gl.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(329, 405)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(225, 33)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "This will let you void a check that has NOT been posted to the General Ledger. "
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(329, 453)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(241, 49)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "This will Void a Check that has been posted to the G/L.  It will create a J/E to " & _
            "Adjust the General Ledger"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(337, 453)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(241, 49)
        Me.Label3.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(337, 405)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(225, 33)
        Me.Label2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(97, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = " Select check number to void"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chk_num, Me.Screen_nam, Me.net_amt, Me.dt_paid, Me.vouch_num, Me.glpost, Me.dr_Acct_nu, Me.cr_acct_nu})
        Me.DataGridView1.Location = New System.Drawing.Point(41, 52)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(639, 272)
        Me.DataGridView1.TabIndex = 13
        '
        'chk_num
        '
        Me.chk_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.chk_num.DataPropertyName = "chk_num"
        Me.chk_num.HeaderText = "Check Number"
        Me.chk_num.Name = "chk_num"
        Me.chk_num.ReadOnly = True
        Me.chk_num.Width = 102
        '
        'Screen_nam
        '
        Me.Screen_nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Screen_nam.DataPropertyName = "Screen_nam"
        Me.Screen_nam.HeaderText = "Name"
        Me.Screen_nam.Name = "Screen_nam"
        Me.Screen_nam.ReadOnly = True
        Me.Screen_nam.Width = 59
        '
        'net_amt
        '
        Me.net_amt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.net_amt.DataPropertyName = "net_amt"
        Me.net_amt.HeaderText = "Amount"
        Me.net_amt.Name = "net_amt"
        Me.net_amt.ReadOnly = True
        Me.net_amt.Width = 69
        '
        'dt_paid
        '
        Me.dt_paid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dt_paid.DataPropertyName = "dt_paid"
        Me.dt_paid.HeaderText = "Date"
        Me.dt_paid.Name = "dt_paid"
        Me.dt_paid.ReadOnly = True
        Me.dt_paid.Width = 54
        '
        'vouch_num
        '
        Me.vouch_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.vouch_num.DataPropertyName = "vouch_num"
        Me.vouch_num.HeaderText = "Voucher"
        Me.vouch_num.Name = "vouch_num"
        Me.vouch_num.ReadOnly = True
        Me.vouch_num.Width = 73
        '
        'glpost
        '
        Me.glpost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.glpost.DataPropertyName = "glpost"
        Me.glpost.HeaderText = "Posted"
        Me.glpost.Name = "glpost"
        Me.glpost.ReadOnly = True
        Me.glpost.Width = 65
        '
        'dr_Acct_nu
        '
        Me.dr_Acct_nu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dr_Acct_nu.DataPropertyName = "dr_Acct_nu"
        Me.dr_Acct_nu.HeaderText = "DrAcct"
        Me.dr_Acct_nu.Name = "dr_Acct_nu"
        Me.dr_Acct_nu.ReadOnly = True
        Me.dr_Acct_nu.Width = 66
        '
        'cr_acct_nu
        '
        Me.cr_acct_nu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.cr_acct_nu.DataPropertyName = "cr_acct_nu"
        Me.cr_acct_nu.HeaderText = "CR Acct"
        Me.cr_acct_nu.Name = "cr_acct_nu"
        Me.cr_acct_nu.ReadOnly = True
        Me.cr_acct_nu.Width = 71
        '
        'apckvoid1_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(715, 611)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.void_gl)
        Me.Controls.Add(Me.void_no_gl)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(64, 130)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "apckvoid1_frm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Accounts Payable- Void a Check "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents chk_num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Screen_nam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents net_amt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dt_paid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vouch_num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents glpost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dr_Acct_nu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cr_acct_nu As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class