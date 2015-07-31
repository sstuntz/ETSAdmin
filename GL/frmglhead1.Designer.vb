<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmglhead1
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
    Public WithEvents PrtList As System.Windows.Forms.Button
    Public WithEvents CmdUpdate As System.Windows.Forms.Button
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
    Public WithEvents CmdEdit As System.Windows.Forms.Button
    Public WithEvents CmdAdd As System.Windows.Forms.Button
    Public WithEvents Cancel As System.Windows.Forms.Button
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtfields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PrtList = New System.Windows.Forms.Button
        Me.CmdUpdate = New System.Windows.Forms.Button
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
        Me.CmdEdit = New System.Windows.Forms.Button
        Me.CmdAdd = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtfields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.gl_ref_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acct_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.heading_1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Min_1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Max_1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Heading_2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Min_2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Max_2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Heading_3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Min_3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MAx_3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.txtfields, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PrtList
        '
        Me.PrtList.BackColor = System.Drawing.SystemColors.Control
        Me.PrtList.Cursor = System.Windows.Forms.Cursors.Default
        Me.PrtList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrtList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PrtList.Location = New System.Drawing.Point(393, 626)
        Me.PrtList.Name = "PrtList"
        Me.PrtList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PrtList.Size = New System.Drawing.Size(281, 31)
        Me.PrtList.TabIndex = 28
        Me.PrtList.Text = "Print Listing of Category Headings"
        Me.PrtList.UseVisualStyleBackColor = False
        '
        'CmdUpdate
        '
        Me.CmdUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.CmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdUpdate.Enabled = False
        Me.CmdUpdate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdUpdate.Location = New System.Drawing.Point(705, 388)
        Me.CmdUpdate.Name = "CmdUpdate"
        Me.CmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdUpdate.Size = New System.Drawing.Size(81, 25)
        Me.CmdUpdate.TabIndex = 20
        Me.CmdUpdate.Text = "Update"
        Me.CmdUpdate.UseVisualStyleBackColor = False
        '
        '_txtfields_10
        '
        Me._txtfields_10.AcceptsReturn = True
        Me._txtfields_10.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_10.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_10, CType(10, Short))
        Me._txtfields_10.Location = New System.Drawing.Point(689, 578)
        Me._txtfields_10.MaxLength = 4
        Me._txtfields_10.Name = "_txtfields_10"
        Me._txtfields_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_10.Size = New System.Drawing.Size(49, 20)
        Me._txtfields_10.TabIndex = 14
        Me._txtfields_10.Tag = "max-3"
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
        Me._txtfields_9.Location = New System.Drawing.Point(609, 578)
        Me._txtfields_9.MaxLength = 4
        Me._txtfields_9.Name = "_txtfields_9"
        Me._txtfields_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_9.Size = New System.Drawing.Size(49, 20)
        Me._txtfields_9.TabIndex = 13
        Me._txtfields_9.Tag = "min-3"
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
        Me._txtfields_8.Location = New System.Drawing.Point(315, 578)
        Me._txtfields_8.MaxLength = 25
        Me._txtfields_8.Name = "_txtfields_8"
        Me._txtfields_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_8.Size = New System.Drawing.Size(201, 20)
        Me._txtfields_8.TabIndex = 12
        Me._txtfields_8.Tag = "heading_3"
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
        Me._txtfields_7.Location = New System.Drawing.Point(689, 546)
        Me._txtfields_7.MaxLength = 4
        Me._txtfields_7.Name = "_txtfields_7"
        Me._txtfields_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_7.Size = New System.Drawing.Size(49, 20)
        Me._txtfields_7.TabIndex = 11
        Me._txtfields_7.Tag = "max_2"
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
        Me._txtfields_6.Location = New System.Drawing.Point(609, 546)
        Me._txtfields_6.MaxLength = 4
        Me._txtfields_6.Name = "_txtfields_6"
        Me._txtfields_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_6.Size = New System.Drawing.Size(49, 20)
        Me._txtfields_6.TabIndex = 10
        Me._txtfields_6.Tag = "min_2"
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
        Me._txtfields_5.Location = New System.Drawing.Point(315, 546)
        Me._txtfields_5.MaxLength = 20
        Me._txtfields_5.Name = "_txtfields_5"
        Me._txtfields_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_5.Size = New System.Drawing.Size(177, 20)
        Me._txtfields_5.TabIndex = 9
        Me._txtfields_5.Tag = "heading_2"
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
        Me._txtfields_4.Location = New System.Drawing.Point(689, 514)
        Me._txtfields_4.MaxLength = 4
        Me._txtfields_4.Name = "_txtfields_4"
        Me._txtfields_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_4.Size = New System.Drawing.Size(49, 20)
        Me._txtfields_4.TabIndex = 8
        Me._txtfields_4.Tag = "max_1"
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
        Me._txtfields_3.Location = New System.Drawing.Point(609, 514)
        Me._txtfields_3.MaxLength = 4
        Me._txtfields_3.Name = "_txtfields_3"
        Me._txtfields_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_3.Size = New System.Drawing.Size(49, 20)
        Me._txtfields_3.TabIndex = 7
        Me._txtfields_3.Tag = "min_1"
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
        Me._txtfields_2.Location = New System.Drawing.Point(315, 514)
        Me._txtfields_2.MaxLength = 20
        Me._txtfields_2.Name = "_txtfields_2"
        Me._txtfields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_2.Size = New System.Drawing.Size(177, 20)
        Me._txtfields_2.TabIndex = 6
        Me._txtfields_2.Tag = "heading_1"
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
        Me._txtfields_1.Location = New System.Drawing.Point(295, 453)
        Me._txtfields_1.MaxLength = 3
        Me._txtfields_1.Name = "_txtfields_1"
        Me._txtfields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_1.Size = New System.Drawing.Size(65, 20)
        Me._txtfields_1.TabIndex = 5
        Me._txtfields_1.Tag = "acct_type"
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
        Me._txtfields_0.Location = New System.Drawing.Point(231, 453)
        Me._txtfields_0.MaxLength = 0
        Me._txtfields_0.Name = "_txtfields_0"
        Me._txtfields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_0.Size = New System.Drawing.Size(49, 20)
        Me._txtfields_0.TabIndex = 4
        Me._txtfields_0.Tag = "gl_ref_no"
        Me._txtfields_0.Text = " "
        '
        'CmdEdit
        '
        Me.CmdEdit.BackColor = System.Drawing.SystemColors.Control
        Me.CmdEdit.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdEdit.Enabled = False
        Me.CmdEdit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdEdit.Location = New System.Drawing.Point(422, 388)
        Me.CmdEdit.Name = "CmdEdit"
        Me.CmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdEdit.Size = New System.Drawing.Size(73, 25)
        Me.CmdEdit.TabIndex = 3
        Me.CmdEdit.Text = "Edit"
        Me.CmdEdit.UseVisualStyleBackColor = False
        '
        'CmdAdd
        '
        Me.CmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.CmdAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdAdd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdAdd.Location = New System.Drawing.Point(139, 388)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdAdd.Size = New System.Drawing.Size(73, 25)
        Me.CmdAdd.TabIndex = 2
        Me.CmdAdd.Text = "Add"
        Me.CmdAdd.UseVisualStyleBackColor = False
        '
        'Cancel
        '
        Me.Cancel.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancel.Location = New System.Drawing.Point(928, 19)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(97, 25)
        Me.Cancel.TabIndex = 0
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(411, 453)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(313, 16)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "<----Enter AST or CASS or LIAB or CAP or REV or EXP  "
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(522, 572)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(46, 35)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "(25)"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(522, 508)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(36, 29)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "(20)"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(522, 540)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(36, 22)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "(20)"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(172, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(489, 17)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "The UPDATE button will not be active until you enter thru all the fields."
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(172, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(441, 17)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "To ADD a record, first select the ADD button and then enter the data."
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(177, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(457, 25)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "To EDIT a record, first select a record and then select the EDIT Button."
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(686, 482)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(73, 29)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "max 1/2/3"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(606, 482)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(65, 29)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "min 1/2/3"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(339, 482)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(97, 29)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "heading 1/2/3"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(292, 431)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(57, 19)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "acct type"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(237, 431)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(33, 19)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "ref#"
        '
        'txtfields
        '
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gl_ref_no, Me.acct_type, Me.heading_1, Me.Min_1, Me.Max_1, Me.Heading_2, Me.Min_2, Me.Max_2, Me.Heading_3, Me.Min_3, Me.MAx_3})
        Me.DataGridView1.Location = New System.Drawing.Point(116, 88)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(898, 294)
        Me.DataGridView1.TabIndex = 29
        '
        'gl_ref_no
        '
        Me.gl_ref_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.gl_ref_no.DataPropertyName = "gl_ref_no"
        Me.gl_ref_no.HeaderText = "Ref #"
        Me.gl_ref_no.Name = "gl_ref_no"
        Me.gl_ref_no.ReadOnly = True
        Me.gl_ref_no.Width = 59
        '
        'acct_type
        '
        Me.acct_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.acct_type.DataPropertyName = "acct_type"
        Me.acct_type.HeaderText = "Acct Type"
        Me.acct_type.Name = "acct_type"
        Me.acct_type.ReadOnly = True
        Me.acct_type.Width = 85
        '
        'heading_1
        '
        Me.heading_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.heading_1.DataPropertyName = "heading_1"
        Me.heading_1.HeaderText = "Heading 1"
        Me.heading_1.Name = "heading_1"
        Me.heading_1.ReadOnly = True
        Me.heading_1.Width = 85
        '
        'Min_1
        '
        Me.Min_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Min_1.DataPropertyName = "Min_1"
        Me.Min_1.HeaderText = "Min 1"
        Me.Min_1.Name = "Min_1"
        Me.Min_1.ReadOnly = True
        Me.Min_1.Width = 61
        '
        'Max_1
        '
        Me.Max_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Max_1.DataPropertyName = "Max_1"
        Me.Max_1.HeaderText = "Max 1"
        Me.Max_1.Name = "Max_1"
        Me.Max_1.ReadOnly = True
        Me.Max_1.Width = 63
        '
        'Heading_2
        '
        Me.Heading_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Heading_2.DataPropertyName = "Heading_2"
        Me.Heading_2.HeaderText = "Heading 2"
        Me.Heading_2.Name = "Heading_2"
        Me.Heading_2.ReadOnly = True
        Me.Heading_2.Width = 85
        '
        'Min_2
        '
        Me.Min_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Min_2.DataPropertyName = "Min_2"
        Me.Min_2.HeaderText = "Min 2"
        Me.Min_2.Name = "Min_2"
        Me.Min_2.ReadOnly = True
        Me.Min_2.Width = 61
        '
        'Max_2
        '
        Me.Max_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Max_2.DataPropertyName = "Max_2"
        Me.Max_2.HeaderText = "Max 2"
        Me.Max_2.Name = "Max_2"
        Me.Max_2.ReadOnly = True
        Me.Max_2.Width = 63
        '
        'Heading_3
        '
        Me.Heading_3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Heading_3.DataPropertyName = "Heading_3"
        Me.Heading_3.HeaderText = "Heading 3"
        Me.Heading_3.Name = "Heading_3"
        Me.Heading_3.ReadOnly = True
        Me.Heading_3.Width = 85
        '
        'Min_3
        '
        Me.Min_3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Min_3.DataPropertyName = "Min_3"
        Me.Min_3.HeaderText = "Min 3"
        Me.Min_3.Name = "Min_3"
        Me.Min_3.ReadOnly = True
        Me.Min_3.Width = 61
        '
        'MAx_3
        '
        Me.MAx_3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.MAx_3.DataPropertyName = "MAx_3"
        Me.MAx_3.HeaderText = "Max 3"
        Me.MAx_3.Name = "MAx_3"
        Me.MAx_3.ReadOnly = True
        Me.MAx_3.Width = 63
        '
        'frmglhead1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1063, 669)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.PrtList)
        Me.Controls.Add(Me.CmdUpdate)
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
        Me.Controls.Add(Me.CmdEdit)
        Me.Controls.Add(Me.CmdAdd)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
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
        Me.Name = "frmglhead1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "General Ledger Category Headings"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.txtfields, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents gl_ref_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acct_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents heading_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Min_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Max_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Heading_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Min_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Max_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Heading_3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Min_3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MAx_3 As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class