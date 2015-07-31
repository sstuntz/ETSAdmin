<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frm_budget1
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
	Public WithEvents _txtfields_14 As System.Windows.Forms.TextBox
    Public WithEvents Refresh1 As System.Windows.Forms.Button
    Public WithEvents _txtfields_13 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_11 As System.Windows.Forms.TextBox
    Public WithEvents PrintProof As System.Windows.Forms.Button
    Public WithEvents _txtfields_12 As System.Windows.Forms.TextBox
    Public WithEvents Spread As System.Windows.Forms.Button
    Public WithEvents Text1 As System.Windows.Forms.TextBox
    Public WithEvents Balance As System.Windows.Forms.Button
    Public WithEvents update_Renamed As System.Windows.Forms.Button
    Public WithEvents _txtfields_10 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_9 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_8 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_7 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_6 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_5 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_4 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_3 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_2 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_1 As System.Windows.Forms.TextBox
    Public WithEvents _txtfields_0 As System.Windows.Forms.TextBox
    Public WithEvents Cancel As System.Windows.Forms.Button
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents _Label5_6 As System.Windows.Forms.Label
    Public WithEvents _Label5_5 As System.Windows.Forms.Label
    Public WithEvents _Label5_4 As System.Windows.Forms.Label
    Public WithEvents _Label5_3 As System.Windows.Forms.Label
    Public WithEvents _Label5_2 As System.Windows.Forms.Label
    Public WithEvents _Label5_1 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents _Label5_0 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label5 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents txtfields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._txtfields_14 = New System.Windows.Forms.TextBox
        Me.Refresh1 = New System.Windows.Forms.Button
        Me._txtfields_13 = New System.Windows.Forms.TextBox
        Me._txtfields_11 = New System.Windows.Forms.TextBox
        Me.PrintProof = New System.Windows.Forms.Button
        Me._txtfields_12 = New System.Windows.Forms.TextBox
        Me.Spread = New System.Windows.Forms.Button
        Me.Text1 = New System.Windows.Forms.TextBox
        Me.Balance = New System.Windows.Forms.Button
        Me.update_Renamed = New System.Windows.Forms.Button
        Me._txtfields_10 = New System.Windows.Forms.TextBox
        Me._txtfields_9 = New System.Windows.Forms.TextBox
        Me._txtfields_8 = New System.Windows.Forms.TextBox
        Me._txtfields_7 = New System.Windows.Forms.TextBox
        Me._txtfields_6 = New System.Windows.Forms.TextBox
        Me._txtfields_5 = New System.Windows.Forms.TextBox
        Me._txtfields_4 = New System.Windows.Forms.TextBox
        Me._txtfields_3 = New System.Windows.Forms.TextBox
        Me._txtfields_2 = New System.Windows.Forms.TextBox
        Me._txtfields_1 = New System.Windows.Forms.TextBox
        Me._txtfields_0 = New System.Windows.Forms.TextBox
        Me.Cancel = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me._Label5_6 = New System.Windows.Forms.Label
        Me._Label5_5 = New System.Windows.Forms.Label
        Me._Label5_4 = New System.Windows.Forms.Label
        Me._Label5_3 = New System.Windows.Forms.Label
        Me._Label5_2 = New System.Windows.Forms.Label
        Me._Label5_1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me._Label5_0 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.txtfields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Acct_num = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Acct_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bud_yr = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfields, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_txtfields_14
        '
        Me._txtfields_14.AcceptsReturn = True
        Me._txtfields_14.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_14.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_14, CType(14, Short))
        Me._txtfields_14.Location = New System.Drawing.Point(248, 32)
        Me._txtfields_14.MaxLength = 0
        Me._txtfields_14.Name = "_txtfields_14"
        Me._txtfields_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_14.Size = New System.Drawing.Size(49, 20)
        Me._txtfields_14.TabIndex = 38
        Me._txtfields_14.Text = " "
        '
        'Refresh1
        '
        Me.Refresh1.BackColor = System.Drawing.SystemColors.Control
        Me.Refresh1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Refresh1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Refresh1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Refresh1.Location = New System.Drawing.Point(523, 40)
        Me.Refresh1.Name = "Refresh1"
        Me.Refresh1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Refresh1.Size = New System.Drawing.Size(150, 25)
        Me.Refresh1.TabIndex = 37
        Me.Refresh1.Text = "Refresh to Original List"
        Me.Refresh1.UseVisualStyleBackColor = False
        '
        '_txtfields_13
        '
        Me._txtfields_13.AcceptsReturn = True
        Me._txtfields_13.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_13.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_13.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_13, CType(13, Short))
        Me._txtfields_13.Location = New System.Drawing.Point(440, 8)
        Me._txtfields_13.MaxLength = 0
        Me._txtfields_13.Name = "_txtfields_13"
        Me._txtfields_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_13.Size = New System.Drawing.Size(105, 20)
        Me._txtfields_13.TabIndex = 36
        Me._txtfields_13.Text = " "
        '
        '_txtfields_11
        '
        Me._txtfields_11.AcceptsReturn = True
        Me._txtfields_11.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_11.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_11, CType(11, Short))
        Me._txtfields_11.Location = New System.Drawing.Point(481, 589)
        Me._txtfields_11.MaxLength = 0
        Me._txtfields_11.Name = "_txtfields_11"
        Me._txtfields_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_11.Size = New System.Drawing.Size(81, 20)
        Me._txtfields_11.TabIndex = 12
        Me._txtfields_11.Tag = "bud_m12"
        Me._txtfields_11.Text = " "
        '
        'PrintProof
        '
        Me.PrintProof.BackColor = System.Drawing.SystemColors.Control
        Me.PrintProof.Cursor = System.Windows.Forms.Cursors.Default
        Me.PrintProof.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintProof.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PrintProof.Location = New System.Drawing.Point(496, 208)
        Me.PrintProof.Name = "PrintProof"
        Me.PrintProof.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PrintProof.Size = New System.Drawing.Size(185, 33)
        Me.PrintProof.TabIndex = 27
        Me.PrintProof.Text = "Print Proof-Budget YR"
        Me.PrintProof.UseVisualStyleBackColor = False
        '
        '_txtfields_12
        '
        Me._txtfields_12.AcceptsReturn = True
        Me._txtfields_12.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_12.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_12.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_12, CType(12, Short))
        Me._txtfields_12.Location = New System.Drawing.Point(145, 477)
        Me._txtfields_12.MaxLength = 0
        Me._txtfields_12.Name = "_txtfields_12"
        Me._txtfields_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_12.Size = New System.Drawing.Size(105, 20)
        Me._txtfields_12.TabIndex = 24
        Me._txtfields_12.Tag = "bud_yr"
        Me._txtfields_12.Text = " "
        '
        'Spread
        '
        Me.Spread.BackColor = System.Drawing.SystemColors.Control
        Me.Spread.Cursor = System.Windows.Forms.Cursors.Default
        Me.Spread.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Spread.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Spread.Location = New System.Drawing.Point(305, 477)
        Me.Spread.Name = "Spread"
        Me.Spread.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Spread.Size = New System.Drawing.Size(177, 25)
        Me.Spread.TabIndex = 26
        Me.Spread.Text = "Spread by 1/12th"
        Me.Spread.UseVisualStyleBackColor = False
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(584, 336)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(97, 20)
        Me.Text1.TabIndex = 22
        Me.Text1.Text = " "
        '
        'Balance
        '
        Me.Balance.BackColor = System.Drawing.SystemColors.Control
        Me.Balance.Cursor = System.Windows.Forms.Cursors.Default
        Me.Balance.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Balance.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Balance.Location = New System.Drawing.Point(584, 296)
        Me.Balance.Name = "Balance"
        Me.Balance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Balance.Size = New System.Drawing.Size(97, 25)
        Me.Balance.TabIndex = 13
        Me.Balance.Text = "Balance"
        Me.Balance.UseVisualStyleBackColor = False
        '
        'update_Renamed
        '
        Me.update_Renamed.BackColor = System.Drawing.SystemColors.Control
        Me.update_Renamed.Cursor = System.Windows.Forms.Cursors.Default
        Me.update_Renamed.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.update_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
        Me.update_Renamed.Location = New System.Drawing.Point(593, 501)
        Me.update_Renamed.Name = "update_Renamed"
        Me.update_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.update_Renamed.Size = New System.Drawing.Size(81, 25)
        Me.update_Renamed.TabIndex = 28
        Me.update_Renamed.Text = "Update"
        Me.update_Renamed.UseVisualStyleBackColor = False
        '
        '_txtfields_10
        '
        Me._txtfields_10.AcceptsReturn = True
        Me._txtfields_10.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_10, CType(10, Short))
        Me._txtfields_10.Location = New System.Drawing.Point(481, 565)
        Me._txtfields_10.MaxLength = 0
        Me._txtfields_10.Name = "_txtfields_10"
        Me._txtfields_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_10.Size = New System.Drawing.Size(81, 20)
        Me._txtfields_10.TabIndex = 11
        Me._txtfields_10.Tag = "bud_m11"
        Me._txtfields_10.Text = " "
        '
        '_txtfields_9
        '
        Me._txtfields_9.AcceptsReturn = True
        Me._txtfields_9.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_9.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_9, CType(9, Short))
        Me._txtfields_9.Location = New System.Drawing.Point(481, 541)
        Me._txtfields_9.MaxLength = 0
        Me._txtfields_9.Name = "_txtfields_9"
        Me._txtfields_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_9.Size = New System.Drawing.Size(81, 20)
        Me._txtfields_9.TabIndex = 10
        Me._txtfields_9.Tag = "bud_m10"
        Me._txtfields_9.Text = " "
        '
        '_txtfields_8
        '
        Me._txtfields_8.AcceptsReturn = True
        Me._txtfields_8.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_8, CType(8, Short))
        Me._txtfields_8.Location = New System.Drawing.Point(481, 517)
        Me._txtfields_8.MaxLength = 0
        Me._txtfields_8.Name = "_txtfields_8"
        Me._txtfields_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_8.Size = New System.Drawing.Size(81, 20)
        Me._txtfields_8.TabIndex = 9
        Me._txtfields_8.Tag = "bud_m9"
        Me._txtfields_8.Text = " "
        '
        '_txtfields_7
        '
        Me._txtfields_7.AcceptsReturn = True
        Me._txtfields_7.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_7, CType(7, Short))
        Me._txtfields_7.Location = New System.Drawing.Point(289, 589)
        Me._txtfields_7.MaxLength = 0
        Me._txtfields_7.Name = "_txtfields_7"
        Me._txtfields_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_7.Size = New System.Drawing.Size(81, 20)
        Me._txtfields_7.TabIndex = 8
        Me._txtfields_7.Tag = "bud_m8"
        Me._txtfields_7.Text = " "
        '
        '_txtfields_6
        '
        Me._txtfields_6.AcceptsReturn = True
        Me._txtfields_6.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_6, CType(6, Short))
        Me._txtfields_6.Location = New System.Drawing.Point(289, 563)
        Me._txtfields_6.MaxLength = 0
        Me._txtfields_6.Name = "_txtfields_6"
        Me._txtfields_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_6.Size = New System.Drawing.Size(81, 20)
        Me._txtfields_6.TabIndex = 7
        Me._txtfields_6.Tag = "bud_m7"
        Me._txtfields_6.Text = " "
        '
        '_txtfields_5
        '
        Me._txtfields_5.AcceptsReturn = True
        Me._txtfields_5.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_5, CType(5, Short))
        Me._txtfields_5.Location = New System.Drawing.Point(289, 541)
        Me._txtfields_5.MaxLength = 0
        Me._txtfields_5.Name = "_txtfields_5"
        Me._txtfields_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_5.Size = New System.Drawing.Size(81, 20)
        Me._txtfields_5.TabIndex = 6
        Me._txtfields_5.Tag = "bud_m6"
        Me._txtfields_5.Text = " "
        '
        '_txtfields_4
        '
        Me._txtfields_4.AcceptsReturn = True
        Me._txtfields_4.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_4, CType(4, Short))
        Me._txtfields_4.Location = New System.Drawing.Point(289, 517)
        Me._txtfields_4.MaxLength = 0
        Me._txtfields_4.Name = "_txtfields_4"
        Me._txtfields_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_4.Size = New System.Drawing.Size(81, 20)
        Me._txtfields_4.TabIndex = 5
        Me._txtfields_4.Tag = "bud_m5"
        Me._txtfields_4.Text = " "
        '
        '_txtfields_3
        '
        Me._txtfields_3.AcceptsReturn = True
        Me._txtfields_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_3, CType(3, Short))
        Me._txtfields_3.Location = New System.Drawing.Point(89, 589)
        Me._txtfields_3.MaxLength = 0
        Me._txtfields_3.Name = "_txtfields_3"
        Me._txtfields_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_3.Size = New System.Drawing.Size(81, 20)
        Me._txtfields_3.TabIndex = 4
        Me._txtfields_3.Tag = "bud_m4"
        Me._txtfields_3.Text = " "
        '
        '_txtfields_2
        '
        Me._txtfields_2.AcceptsReturn = True
        Me._txtfields_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_2, CType(2, Short))
        Me._txtfields_2.Location = New System.Drawing.Point(89, 565)
        Me._txtfields_2.MaxLength = 0
        Me._txtfields_2.Name = "_txtfields_2"
        Me._txtfields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_2.Size = New System.Drawing.Size(81, 20)
        Me._txtfields_2.TabIndex = 3
        Me._txtfields_2.Tag = "bud_m3"
        Me._txtfields_2.Text = " "
        '
        '_txtfields_1
        '
        Me._txtfields_1.AcceptsReturn = True
        Me._txtfields_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_1, CType(1, Short))
        Me._txtfields_1.Location = New System.Drawing.Point(89, 541)
        Me._txtfields_1.MaxLength = 0
        Me._txtfields_1.Name = "_txtfields_1"
        Me._txtfields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_1.Size = New System.Drawing.Size(81, 20)
        Me._txtfields_1.TabIndex = 2
        Me._txtfields_1.Tag = "bud_m2"
        Me._txtfields_1.Text = " "
        '
        '_txtfields_0
        '
        Me._txtfields_0.AcceptsReturn = True
        Me._txtfields_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_0, CType(0, Short))
        Me._txtfields_0.Location = New System.Drawing.Point(89, 517)
        Me._txtfields_0.MaxLength = 0
        Me._txtfields_0.Name = "_txtfields_0"
        Me._txtfields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_0.Size = New System.Drawing.Size(81, 20)
        Me._txtfields_0.TabIndex = 1
        Me._txtfields_0.Tag = "bud_m1"
        Me._txtfields_0.Text = " "
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(592, 0)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(97, 25)
        Me.Cancel.TabIndex = 0
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(17, 613)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(257, 25)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Use the F3 key to dup into next field ."
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(24, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(217, 25)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "OR enter the first 4 digits:"
        '
        '_Label5_6
        '
        Me._Label5_6.BackColor = System.Drawing.SystemColors.Control
        Me._Label5_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label5_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label5_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.SetIndex(Me._Label5_6, CType(6, Short))
        Me._Label5_6.Location = New System.Drawing.Point(393, 589)
        Me._Label5_6.Name = "_Label5_6"
        Me._Label5_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label5_6.Size = New System.Drawing.Size(57, 17)
        Me._Label5_6.TabIndex = 35
        Me._Label5_6.Text = "bud_m12"
        '
        '_Label5_5
        '
        Me._Label5_5.BackColor = System.Drawing.SystemColors.Control
        Me._Label5_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label5_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label5_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.SetIndex(Me._Label5_5, CType(5, Short))
        Me._Label5_5.Location = New System.Drawing.Point(393, 565)
        Me._Label5_5.Name = "_Label5_5"
        Me._Label5_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label5_5.Size = New System.Drawing.Size(57, 17)
        Me._Label5_5.TabIndex = 34
        Me._Label5_5.Text = "bud_m11"
        '
        '_Label5_4
        '
        Me._Label5_4.BackColor = System.Drawing.SystemColors.Control
        Me._Label5_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label5_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label5_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.SetIndex(Me._Label5_4, CType(4, Short))
        Me._Label5_4.Location = New System.Drawing.Point(393, 541)
        Me._Label5_4.Name = "_Label5_4"
        Me._Label5_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label5_4.Size = New System.Drawing.Size(57, 17)
        Me._Label5_4.TabIndex = 33
        Me._Label5_4.Text = "bud_m10"
        '
        '_Label5_3
        '
        Me._Label5_3.BackColor = System.Drawing.SystemColors.Control
        Me._Label5_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label5_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label5_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.SetIndex(Me._Label5_3, CType(3, Short))
        Me._Label5_3.Location = New System.Drawing.Point(393, 517)
        Me._Label5_3.Name = "_Label5_3"
        Me._Label5_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label5_3.Size = New System.Drawing.Size(57, 17)
        Me._Label5_3.TabIndex = 32
        Me._Label5_3.Text = "bud_m9"
        '
        '_Label5_2
        '
        Me._Label5_2.BackColor = System.Drawing.SystemColors.Control
        Me._Label5_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label5_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label5_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.SetIndex(Me._Label5_2, CType(2, Short))
        Me._Label5_2.Location = New System.Drawing.Point(201, 589)
        Me._Label5_2.Name = "_Label5_2"
        Me._Label5_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label5_2.Size = New System.Drawing.Size(57, 17)
        Me._Label5_2.TabIndex = 31
        Me._Label5_2.Text = "bud_m8"
        '
        '_Label5_1
        '
        Me._Label5_1.BackColor = System.Drawing.SystemColors.Control
        Me._Label5_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label5_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label5_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.SetIndex(Me._Label5_1, CType(1, Short))
        Me._Label5_1.Location = New System.Drawing.Point(201, 565)
        Me._Label5_1.Name = "_Label5_1"
        Me._Label5_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label5_1.Size = New System.Drawing.Size(57, 17)
        Me._Label5_1.TabIndex = 30
        Me._Label5_1.Text = "bud_m7"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(201, 541)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(57, 17)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "bud_m6"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(9, 477)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(129, 33)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Yearly Budget Amount to Spread(bud_yr)"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(16, 104)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(497, 17)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "When Balance caculation is zero(0), click on Update.  Then select another record." & _
            ""
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(489, 17)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "You can edit any budget month and click on Balance to calc amount not spread."
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(481, 17)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Then enter an amount in Yearly Budget Amount and click on spread by 1/12th."
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(417, 25)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "To EDIT a record, select a record from the grid OR Enter 8 digit #--->."
        '
        '_Label5_0
        '
        Me._Label5_0.BackColor = System.Drawing.SystemColors.Control
        Me._Label5_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label5_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Label5_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.SetIndex(Me._Label5_0, CType(0, Short))
        Me._Label5_0.Location = New System.Drawing.Point(201, 517)
        Me._Label5_0.Name = "_Label5_0"
        Me._Label5_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label5_0.Size = New System.Drawing.Size(57, 17)
        Me._Label5_0.TabIndex = 18
        Me._Label5_0.Text = "bud_m5"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(25, 589)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "bud_m4"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(25, 565)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "bud_m3"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(25, 541)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "bud_m2"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(25, 517)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "bud_m1"
        '
        'txtfields
        '
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Acct_num, Me.Acct_desc, Me.Bud_yr})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 124)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(446, 331)
        Me.DataGridView1.TabIndex = 41
        '
        'Acct_num
        '
        Me.Acct_num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Acct_num.DataPropertyName = "Acct_num"
        Me.Acct_num.HeaderText = "Acct Number"
        Me.Acct_num.Name = "Acct_num"
        Me.Acct_num.ReadOnly = True
        Me.Acct_num.Width = 103
        '
        'Acct_desc
        '
        Me.Acct_desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Acct_desc.DataPropertyName = "Acct_desc"
        Me.Acct_desc.HeaderText = "Description"
        Me.Acct_desc.Name = "Acct_desc"
        Me.Acct_desc.ReadOnly = True
        Me.Acct_desc.Width = 95
        '
        'Bud_yr
        '
        Me.Bud_yr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Bud_yr.DataPropertyName = "Bud_yr"
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Bud_yr.DefaultCellStyle = DataGridViewCellStyle1
        Me.Bud_yr.HeaderText = "$ Bud Year"
        Me.Bud_yr.Name = "Bud_yr"
        Me.Bud_yr.ReadOnly = True
        Me.Bud_yr.Width = 89
        '
        'frm_budget1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(705, 664)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me._txtfields_14)
        Me.Controls.Add(Me.Refresh1)
        Me.Controls.Add(Me._txtfields_13)
        Me.Controls.Add(Me._txtfields_11)
        Me.Controls.Add(Me.PrintProof)
        Me.Controls.Add(Me._txtfields_12)
        Me.Controls.Add(Me.Spread)
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.Balance)
        Me.Controls.Add(Me.update_Renamed)
        Me.Controls.Add(Me._txtfields_10)
        Me.Controls.Add(Me._txtfields_9)
        Me.Controls.Add(Me._txtfields_8)
        Me.Controls.Add(Me._txtfields_7)
        Me.Controls.Add(Me._txtfields_6)
        Me.Controls.Add(Me._txtfields_5)
        Me.Controls.Add(Me._txtfields_4)
        Me.Controls.Add(Me._txtfields_3)
        Me.Controls.Add(Me._txtfields_2)
        Me.Controls.Add(Me._txtfields_1)
        Me.Controls.Add(Me._txtfields_0)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me._Label5_6)
        Me.Controls.Add(Me._Label5_5)
        Me.Controls.Add(Me._Label5_4)
        Me.Controls.Add(Me._Label5_3)
        Me.Controls.Add(Me._Label5_2)
        Me.Controls.Add(Me._Label5_1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me._Label5_0)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Location = New System.Drawing.Point(21, 40)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_budget1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "General Ledger Current Year Budget Entry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfields, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Acct_num As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Acct_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bud_yr As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class