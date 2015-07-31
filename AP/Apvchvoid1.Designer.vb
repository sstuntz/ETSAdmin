<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class apvchvoid1_frm
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
    Public WithEvents revoucher As System.Windows.Forms.Button
    Public WithEvents Cancel As System.Windows.Forms.Button
    Public WithEvents void_gl As System.Windows.Forms.Button
    Public WithEvents void_no_gl As System.Windows.Forms.Button
    Public WithEvents Label6 As System.Windows.Forms.Label
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
        Me.revoucher = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.void_gl = New System.Windows.Forms.Button
        Me.void_no_gl = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.vouch_num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Screen_nam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Alloc_amt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vend_inv_d = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.vouch_amt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.glpost = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'revoucher
        '
        Me.revoucher.BackColor = System.Drawing.SystemColors.Control
        Me.revoucher.Cursor = System.Windows.Forms.Cursors.Default
        Me.revoucher.Enabled = False
        Me.revoucher.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.revoucher.ForeColor = System.Drawing.SystemColors.ControlText
        Me.revoucher.Location = New System.Drawing.Point(101, 475)
        Me.revoucher.Name = "revoucher"
        Me.revoucher.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.revoucher.Size = New System.Drawing.Size(177, 33)
        Me.revoucher.TabIndex = 9
        Me.revoucher.Text = "Reinstate Voucher"
        Me.revoucher.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(431, 3)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(192, 33)
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
        Me.void_gl.Location = New System.Drawing.Point(100, 420)
        Me.void_gl.Name = "void_gl"
        Me.void_gl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.void_gl.Size = New System.Drawing.Size(177, 41)
        Me.void_gl.TabIndex = 3
        Me.void_gl.Text = "Void Voucher Posted to G/L"
        Me.void_gl.UseVisualStyleBackColor = False
        '
        'void_no_gl
        '
        Me.void_no_gl.BackColor = System.Drawing.SystemColors.Control
        Me.void_no_gl.Cursor = System.Windows.Forms.Cursors.Default
        Me.void_no_gl.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.void_no_gl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.void_no_gl.Location = New System.Drawing.Point(102, 363)
        Me.void_no_gl.Name = "void_no_gl"
        Me.void_no_gl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.void_no_gl.Size = New System.Drawing.Size(177, 41)
        Me.void_no_gl.TabIndex = 1
        Me.void_no_gl.Text = "Void Voucher NOT posted to G/L"
        Me.void_no_gl.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(317, 475)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(233, 41)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "This will allow you to create a new voucher to replace the voucher just voided."
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(317, 363)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(225, 33)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "This will let you void a voucher that has not been posted to the General Ledger. " & _
            ""
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(317, 411)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(241, 49)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "This will Void a Voucher that has been posted to the G/L.  It will create a J/E t" & _
            "o Adjust the General Ledger"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(325, 411)
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
        Me.Label2.Location = New System.Drawing.Point(325, 363)
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
        Me.Label1.Location = New System.Drawing.Point(24, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(306, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select voucher number to void.  Vouchers that are voided or paid will not appear " & _
            "in the list."
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.vouch_num, Me.Screen_nam, Me.Alloc_amt, Me.Vend_inv_d, Me.vouch_amt, Me.glpost})
        Me.DataGridView1.Location = New System.Drawing.Point(39, 68)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(548, 272)
        Me.DataGridView1.TabIndex = 12
        '
        'vouch_num
        '
        Me.vouch_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.vouch_num.DataPropertyName = "vouch_num"
        Me.vouch_num.HeaderText = "Voucher"
        Me.vouch_num.Name = "vouch_num"
        Me.vouch_num.Width = 73
        '
        'Screen_nam
        '
        Me.Screen_nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Screen_nam.DataPropertyName = "Screen_nam"
        Me.Screen_nam.HeaderText = "Name"
        Me.Screen_nam.Name = "Screen_nam"
        Me.Screen_nam.Width = 59
        '
        'Alloc_amt
        '
        Me.Alloc_amt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Alloc_amt.DataPropertyName = "Alloc_amt"
        Me.Alloc_amt.HeaderText = "Line amount"
        Me.Alloc_amt.Name = "Alloc_amt"
        Me.Alloc_amt.Width = 90
        '
        'Vend_inv_d
        '
        Me.Vend_inv_d.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Vend_inv_d.DataPropertyName = "Vend_inv_d"
        Me.Vend_inv_d.HeaderText = "Date"
        Me.Vend_inv_d.Name = "Vend_inv_d"
        Me.Vend_inv_d.Width = 54
        '
        'vouch_amt
        '
        Me.vouch_amt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.vouch_amt.DataPropertyName = "vouch_amt"
        Me.vouch_amt.HeaderText = "Voucher Amt"
        Me.vouch_amt.Name = "vouch_amt"
        Me.vouch_amt.Width = 94
        '
        'glpost
        '
        Me.glpost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.glpost.DataPropertyName = "glpost"
        Me.glpost.HeaderText = "Posted"
        Me.glpost.Name = "glpost"
        Me.glpost.Width = 65
        '
        'apvchvoid1_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(731, 541)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.revoucher)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.void_gl)
        Me.Controls.Add(Me.void_no_gl)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 36)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "apvchvoid1_frm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Accounts Payable- Void a Voucher "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents vouch_num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Screen_nam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Alloc_amt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vend_inv_d As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vouch_amt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents glpost As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class