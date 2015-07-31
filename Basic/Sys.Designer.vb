<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmsys
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
	Public WithEvents _txtfields_8 As System.Windows.Forms.TextBox
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
    Public WithEvents _txtfields_7 As System.Windows.Forms.TextBox
	Public WithEvents _txtfields_6 As System.Windows.Forms.TextBox
	Public WithEvents _txtfields_5 As System.Windows.Forms.TextBox
	Public WithEvents _txtfields_4 As System.Windows.Forms.TextBox
	Public WithEvents _txtfields_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtfields_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtfields_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtfields_0 As System.Windows.Forms.TextBox
    Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_7 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_6 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_5 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_4 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_3 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents txtfields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._txtfields_8 = New System.Windows.Forms.TextBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me._txtfields_7 = New System.Windows.Forms.TextBox
        Me._txtfields_6 = New System.Windows.Forms.TextBox
        Me._txtfields_5 = New System.Windows.Forms.TextBox
        Me._txtfields_4 = New System.Windows.Forms.TextBox
        Me._txtfields_3 = New System.Windows.Forms.TextBox
        Me._txtfields_2 = New System.Windows.Forms.TextBox
        Me._txtfields_1 = New System.Windows.Forms.TextBox
        Me._txtfields_0 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me._lblLabels_7 = New System.Windows.Forms.Label
        Me._lblLabels_6 = New System.Windows.Forms.Label
        Me._lblLabels_5 = New System.Windows.Forms.Label
        Me._lblLabels_4 = New System.Windows.Forms.Label
        Me._lblLabels_3 = New System.Windows.Forms.Label
        Me._lblLabels_2 = New System.Windows.Forms.Label
        Me._lblLabels_1 = New System.Windows.Forms.Label
        Me._lblLabels_0 = New System.Windows.Forms.Label
        Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.txtfields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.cmdAdd = New System.Windows.Forms.Button
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfields, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_txtfields_8
        '
        Me._txtfields_8.AcceptsReturn = True
        Me._txtfields_8.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_8, CType(8, Short))
        Me._txtfields_8.Location = New System.Drawing.Point(240, 296)
        Me._txtfields_8.MaxLength = 0
        Me._txtfields_8.Name = "_txtfields_8"
        Me._txtfields_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_8.Size = New System.Drawing.Size(56, 20)
        Me._txtfields_8.TabIndex = 17
        Me._txtfields_8.Tag = "PwdYN"
        Me._txtfields_8.Text = " "
        Me._txtfields_8.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(488, 4)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(65, 20)
        Me.cmdClose.TabIndex = 20
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUpdate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUpdate.Location = New System.Drawing.Point(448, 88)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUpdate.Size = New System.Drawing.Size(65, 20)
        Me.cmdUpdate.TabIndex = 19
        Me.cmdUpdate.Text = "Save"
        Me.cmdUpdate.UseVisualStyleBackColor = False
        '
        '_txtfields_7
        '
        Me._txtfields_7.AcceptsReturn = True
        Me._txtfields_7.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_7, CType(7, Short))
        Me._txtfields_7.Location = New System.Drawing.Point(240, 240)
        Me._txtfields_7.MaxLength = 10
        Me._txtfields_7.Name = "_txtfields_7"
        Me._txtfields_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_7.Size = New System.Drawing.Size(89, 20)
        Me._txtfields_7.TabIndex = 15
        Me._txtfields_7.Tag = "zip"
        '
        '_txtfields_6
        '
        Me._txtfields_6.AcceptsReturn = True
        Me._txtfields_6.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_6.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_6, CType(6, Short))
        Me._txtfields_6.Location = New System.Drawing.Point(136, 240)
        Me._txtfields_6.MaxLength = 2
        Me._txtfields_6.Name = "_txtfields_6"
        Me._txtfields_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_6.Size = New System.Drawing.Size(38, 20)
        Me._txtfields_6.TabIndex = 13
        Me._txtfields_6.Tag = "state"
        '
        '_txtfields_5
        '
        Me._txtfields_5.AcceptsReturn = True
        Me._txtfields_5.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_5, CType(5, Short))
        Me._txtfields_5.Location = New System.Drawing.Point(136, 216)
        Me._txtfields_5.MaxLength = 20
        Me._txtfields_5.Name = "_txtfields_5"
        Me._txtfields_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_5.Size = New System.Drawing.Size(129, 20)
        Me._txtfields_5.TabIndex = 11
        Me._txtfields_5.Tag = "city"
        '
        '_txtfields_4
        '
        Me._txtfields_4.AcceptsReturn = True
        Me._txtfields_4.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_4.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_4, CType(4, Short))
        Me._txtfields_4.Location = New System.Drawing.Point(136, 192)
        Me._txtfields_4.MaxLength = 36
        Me._txtfields_4.Name = "_txtfields_4"
        Me._txtfields_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_4.Size = New System.Drawing.Size(273, 20)
        Me._txtfields_4.TabIndex = 9
        Me._txtfields_4.Tag = "address2"
        '
        '_txtfields_3
        '
        Me._txtfields_3.AcceptsReturn = True
        Me._txtfields_3.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_3, CType(3, Short))
        Me._txtfields_3.Location = New System.Drawing.Point(136, 168)
        Me._txtfields_3.MaxLength = 36
        Me._txtfields_3.Name = "_txtfields_3"
        Me._txtfields_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_3.Size = New System.Drawing.Size(273, 20)
        Me._txtfields_3.TabIndex = 7
        Me._txtfields_3.Tag = "address1"
        '
        '_txtfields_2
        '
        Me._txtfields_2.AcceptsReturn = True
        Me._txtfields_2.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_2, CType(2, Short))
        Me._txtfields_2.Location = New System.Drawing.Point(136, 144)
        Me._txtfields_2.MaxLength = 36
        Me._txtfields_2.Name = "_txtfields_2"
        Me._txtfields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_2.Size = New System.Drawing.Size(273, 20)
        Me._txtfields_2.TabIndex = 5
        Me._txtfields_2.Tag = "agency_line2"
        '
        '_txtfields_1
        '
        Me._txtfields_1.AcceptsReturn = True
        Me._txtfields_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_1, CType(1, Short))
        Me._txtfields_1.Location = New System.Drawing.Point(136, 115)
        Me._txtfields_1.MaxLength = 36
        Me._txtfields_1.Name = "_txtfields_1"
        Me._txtfields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_1.Size = New System.Drawing.Size(273, 20)
        Me._txtfields_1.TabIndex = 3
        Me._txtfields_1.Tag = "agency_name"
        '
        '_txtfields_0
        '
        Me._txtfields_0.AcceptsReturn = True
        Me._txtfields_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtfields_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtfields_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtfields_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtfields.SetIndex(Me._txtfields_0, CType(0, Short))
        Me._txtfields_0.Location = New System.Drawing.Point(136, 88)
        Me._txtfields_0.MaxLength = 0
        Me._txtfields_0.Name = "_txtfields_0"
        Me._txtfields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtfields_0.Size = New System.Drawing.Size(30, 20)
        Me._txtfields_0.TabIndex = 1
        Me._txtfields_0.Tag = "Agency"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(24, 296)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(185, 25)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Use passwords in Sub Menu's?(Y or N)"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(184, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Default is 1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(457, 25)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Be sure to use the ""Save"" button to save changes to this screen.  To exit the scr" & _
            "een without saving changes use the ""Cancel"" button"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(457, 25)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Enter the name and address of the user on this form.  This is the name that will " & _
            "appear on reports, menu's, and the first screen."
        '
        '_lblLabels_7
        '
        Me._lblLabels_7.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_7, CType(7, Short))
        Me._lblLabels_7.Location = New System.Drawing.Point(200, 240)
        Me._lblLabels_7.Name = "_lblLabels_7"
        Me._lblLabels_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_7.Size = New System.Drawing.Size(25, 17)
        Me._lblLabels_7.TabIndex = 14
        Me._lblLabels_7.Text = "zip:"
        '
        '_lblLabels_6
        '
        Me._lblLabels_6.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_6, CType(6, Short))
        Me._lblLabels_6.Location = New System.Drawing.Point(24, 240)
        Me._lblLabels_6.Name = "_lblLabels_6"
        Me._lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_6.Size = New System.Drawing.Size(60, 17)
        Me._lblLabels_6.TabIndex = 12
        Me._lblLabels_6.Text = "state:"
        '
        '_lblLabels_5
        '
        Me._lblLabels_5.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_5, CType(5, Short))
        Me._lblLabels_5.Location = New System.Drawing.Point(24, 216)
        Me._lblLabels_5.Name = "_lblLabels_5"
        Me._lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_5.Size = New System.Drawing.Size(60, 17)
        Me._lblLabels_5.TabIndex = 10
        Me._lblLabels_5.Text = "city:"
        '
        '_lblLabels_4
        '
        Me._lblLabels_4.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_4, CType(4, Short))
        Me._lblLabels_4.Location = New System.Drawing.Point(24, 193)
        Me._lblLabels_4.Name = "_lblLabels_4"
        Me._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_4.Size = New System.Drawing.Size(60, 17)
        Me._lblLabels_4.TabIndex = 8
        Me._lblLabels_4.Text = "address2:"
        '
        '_lblLabels_3
        '
        Me._lblLabels_3.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_3, CType(3, Short))
        Me._lblLabels_3.Location = New System.Drawing.Point(24, 168)
        Me._lblLabels_3.Name = "_lblLabels_3"
        Me._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_3.Size = New System.Drawing.Size(60, 17)
        Me._lblLabels_3.TabIndex = 6
        Me._lblLabels_3.Text = "address1:"
        '
        '_lblLabels_2
        '
        Me._lblLabels_2.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_2, CType(2, Short))
        Me._lblLabels_2.Location = New System.Drawing.Point(24, 144)
        Me._lblLabels_2.Name = "_lblLabels_2"
        Me._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_2.Size = New System.Drawing.Size(60, 17)
        Me._lblLabels_2.TabIndex = 4
        Me._lblLabels_2.Text = "Agency_line2:"
        '
        '_lblLabels_1
        '
        Me._lblLabels_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_1, CType(1, Short))
        Me._lblLabels_1.Location = New System.Drawing.Point(24, 120)
        Me._lblLabels_1.Name = "_lblLabels_1"
        Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_1.Size = New System.Drawing.Size(73, 17)
        Me._lblLabels_1.TabIndex = 2
        Me._lblLabels_1.Text = "Agency_name:"
        '
        '_lblLabels_0
        '
        Me._lblLabels_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_0, CType(0, Short))
        Me._lblLabels_0.Location = New System.Drawing.Point(24, 88)
        Me._lblLabels_0.Name = "_lblLabels_0"
        Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_0.Size = New System.Drawing.Size(60, 17)
        Me._lblLabels_0.TabIndex = 0
        Me._lblLabels_0.Text = "Agency:"
        '
        'txtfields
        '
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAdd.Location = New System.Drawing.Point(448, 141)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAdd.Size = New System.Drawing.Size(65, 20)
        Me.cmdAdd.TabIndex = 26
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = False
        '
        'frmsys
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(596, 449)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me._txtfields_8)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me._txtfields_7)
        Me.Controls.Add(Me._txtfields_6)
        Me.Controls.Add(Me._txtfields_5)
        Me.Controls.Add(Me._txtfields_4)
        Me.Controls.Add(Me._txtfields_3)
        Me.Controls.Add(Me._txtfields_2)
        Me.Controls.Add(Me._txtfields_1)
        Me.Controls.Add(Me._txtfields_0)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._lblLabels_7)
        Me.Controls.Add(Me._lblLabels_6)
        Me.Controls.Add(Me._lblLabels_5)
        Me.Controls.Add(Me._lblLabels_4)
        Me.Controls.Add(Me._lblLabels_3)
        Me.Controls.Add(Me._lblLabels_2)
        Me.Controls.Add(Me._lblLabels_1)
        Me.Controls.Add(Me._lblLabels_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(28, 96)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmsys"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Agency System File(ETSSYS)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfields, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents cmdAdd As System.Windows.Forms.Button
#End Region 
End Class