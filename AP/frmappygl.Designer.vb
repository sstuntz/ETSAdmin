<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmappygl
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
    Public WithEvents CmdPrepareJE As System.Windows.Forms.Button
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents CmdPost As System.Windows.Forms.Button
    Public WithEvents Command3 As System.Windows.Forms.Button
    Public WithEvents _txtField0_0 As System.Windows.Forms.TextBox
    Public WithEvents _txtField1_1 As System.Windows.Forms.TextBox
    Public WithEvents cmdUpdate As System.Windows.Forms.Button
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
    Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents txtField0 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    Public WithEvents txtField1 As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CmdPrepareJE = New System.Windows.Forms.Button
        Me.Command2 = New System.Windows.Forms.Button
        Me.CmdPost = New System.Windows.Forms.Button
        Me.Command3 = New System.Windows.Forms.Button
        Me._txtField0_0 = New System.Windows.Forms.TextBox
        Me._txtField1_1 = New System.Windows.Forms.TextBox
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me._lblLabels_0 = New System.Windows.Forms.Label
        Me._lblLabels_1 = New System.Windows.Forms.Label
        Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.txtField0 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        Me.txtField1 = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtField0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtField1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdPrepareJE
        '
        Me.CmdPrepareJE.BackColor = System.Drawing.SystemColors.Control
        Me.CmdPrepareJE.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdPrepareJE.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrepareJE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdPrepareJE.Location = New System.Drawing.Point(246, 180)
        Me.CmdPrepareJE.Name = "CmdPrepareJE"
        Me.CmdPrepareJE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdPrepareJE.Size = New System.Drawing.Size(204, 33)
        Me.CmdPrepareJE.TabIndex = 5
        Me.CmdPrepareJE.Text = "Prepare JE"
        Me.CmdPrepareJE.UseVisualStyleBackColor = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(246, 313)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(206, 31)
        Me.Command2.TabIndex = 8
        Me.Command2.Text = "Print J/E just created."
        Me.Command2.UseVisualStyleBackColor = False
        '
        'CmdPost
        '
        Me.CmdPost.BackColor = System.Drawing.SystemColors.Control
        Me.CmdPost.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdPost.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPost.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdPost.Location = New System.Drawing.Point(246, 267)
        Me.CmdPost.Name = "CmdPost"
        Me.CmdPost.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdPost.Size = New System.Drawing.Size(206, 33)
        Me.CmdPost.TabIndex = 7
        Me.CmdPost.Text = "Write Payment J/E to General Ledger"
        Me.CmdPost.UseVisualStyleBackColor = False
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(246, 223)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(205, 33)
        Me.Command3.TabIndex = 6
        Me.Command3.Text = "Print JE Pre-post report"
        Me.Command3.UseVisualStyleBackColor = False
        '
        '_txtField0_0
        '
        Me._txtField0_0.AcceptsReturn = True
        Me._txtField0_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtField0_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtField0_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtField0_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtField0.SetIndex(Me._txtField0_0, CType(0, Short))
        Me._txtField0_0.Location = New System.Drawing.Point(214, 96)
        Me._txtField0_0.MaxLength = 0
        Me._txtField0_0.Name = "_txtField0_0"
        Me._txtField0_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtField0_0.Size = New System.Drawing.Size(81, 20)
        Me._txtField0_0.TabIndex = 1
        Me._txtField0_0.Tag = "BEG_DATE"
        '
        '_txtField1_1
        '
        Me._txtField1_1.AcceptsReturn = True
        Me._txtField1_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtField1_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtField1_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtField1_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtField1.SetIndex(Me._txtField1_1, CType(1, Short))
        Me._txtField1_1.Location = New System.Drawing.Point(462, 95)
        Me._txtField1_1.MaxLength = 0
        Me._txtField1_1.Name = "_txtField1_1"
        Me._txtField1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtField1_1.Size = New System.Drawing.Size(89, 20)
        Me._txtField1_1.TabIndex = 3
        Me._txtField1_1.Tag = "END_DATE"
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUpdate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUpdate.Location = New System.Drawing.Point(305, 129)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUpdate.Size = New System.Drawing.Size(65, 20)
        Me.cmdUpdate.TabIndex = 4
        Me.cmdUpdate.Text = "Verify"
        Me.cmdUpdate.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(528, 0)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(97, 27)
        Me.cmdClose.TabIndex = 9
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(202, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(18, 24)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "2."
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(202, 319)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(18, 25)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "5."
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(202, 271)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(22, 25)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "4."
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(202, 224)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(20, 18)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "3."
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(74, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(417, 25)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "1.  First...select the Payments for the current month. Be sure to ""VERIFY"" your s" & _
            "election."
        '
        '_lblLabels_0
        '
        Me._lblLabels_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_0, CType(0, Short))
        Me._lblLabels_0.Location = New System.Drawing.Point(78, 96)
        Me._lblLabels_0.Name = "_lblLabels_0"
        Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_0.Size = New System.Drawing.Size(129, 17)
        Me._lblLabels_0.TabIndex = 0
        Me._lblLabels_0.Text = "Enter the Beginning Date"
        '
        '_lblLabels_1
        '
        Me._lblLabels_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_1, CType(1, Short))
        Me._lblLabels_1.Location = New System.Drawing.Point(326, 96)
        Me._lblLabels_1.Name = "_lblLabels_1"
        Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_1.Size = New System.Drawing.Size(129, 17)
        Me._lblLabels_1.TabIndex = 2
        Me._lblLabels_1.Text = "Enter the Ending Date"
        '
        'txtField0
        '
        '
        'txtField1
        '
        '
        'frmappygl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(625, 430)
        Me.ControlBox = False
        Me.Controls.Add(Me.CmdPrepareJE)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.CmdPost)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me._txtField0_0)
        Me.Controls.Add(Me._txtField1_1)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._lblLabels_0)
        Me.Controls.Add(Me._lblLabels_1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(5, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmappygl"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Create AP Payment J/E to G/L"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtField0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtField1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class