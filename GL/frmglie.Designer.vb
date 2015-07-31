<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmglie
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
	Public WithEvents mth_num As System.Windows.Forms.TextBox
	Public WithEvents mth_name As System.Windows.Forms.TextBox
	Public WithEvents Reprint_bal As System.Windows.Forms.Button
	Public WithEvents Print_JE As System.Windows.Forms.Button
	Public WithEvents Create_je As System.Windows.Forms.Button
	Public WithEvents post_net As System.Windows.Forms.Button
	Public WithEvents Print_Bal As System.Windows.Forms.Button
	Public WithEvents _txtFields_1 As System.Windows.Forms.TextBox
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
    Public WithEvents label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.mth_num = New System.Windows.Forms.TextBox
        Me.mth_name = New System.Windows.Forms.TextBox
        Me.Reprint_bal = New System.Windows.Forms.Button
        Me.Print_JE = New System.Windows.Forms.Button
        Me.Create_je = New System.Windows.Forms.Button
        Me.post_net = New System.Windows.Forms.Button
        Me.Print_Bal = New System.Windows.Forms.Button
        Me._txtFields_1 = New System.Windows.Forms.TextBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me._lblLabels_1 = New System.Windows.Forms.Label
        Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mth_num
        '
        Me.mth_num.AcceptsReturn = True
        Me.mth_num.BackColor = System.Drawing.SystemColors.Window
        Me.mth_num.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.mth_num.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mth_num.ForeColor = System.Drawing.SystemColors.WindowText
        Me.mth_num.Location = New System.Drawing.Point(328, 176)
        Me.mth_num.MaxLength = 0
        Me.mth_num.Name = "mth_num"
        Me.mth_num.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.mth_num.Size = New System.Drawing.Size(41, 26)
        Me.mth_num.TabIndex = 18
        Me.mth_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'mth_name
        '
        Me.mth_name.AcceptsReturn = True
        Me.mth_name.BackColor = System.Drawing.SystemColors.Window
        Me.mth_name.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.mth_name.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mth_name.ForeColor = System.Drawing.SystemColors.WindowText
        Me.mth_name.Location = New System.Drawing.Point(137, 176)
        Me.mth_name.MaxLength = 0
        Me.mth_name.Name = "mth_name"
        Me.mth_name.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.mth_name.Size = New System.Drawing.Size(81, 20)
        Me.mth_name.TabIndex = 15
        Me.mth_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Reprint_bal
        '
        Me.Reprint_bal.BackColor = System.Drawing.SystemColors.Control
        Me.Reprint_bal.Cursor = System.Windows.Forms.Cursors.Default
        Me.Reprint_bal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reprint_bal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Reprint_bal.Location = New System.Drawing.Point(40, 392)
        Me.Reprint_bal.Name = "Reprint_bal"
        Me.Reprint_bal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Reprint_bal.Size = New System.Drawing.Size(297, 25)
        Me.Reprint_bal.TabIndex = 7
        Me.Reprint_bal.Text = "Reprint the Balance Sheet to be sure you are in balance."
        Me.Reprint_bal.UseVisualStyleBackColor = False
        '
        'Print_JE
        '
        Me.Print_JE.BackColor = System.Drawing.SystemColors.Control
        Me.Print_JE.Cursor = System.Windows.Forms.Cursors.Default
        Me.Print_JE.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Print_JE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Print_JE.Location = New System.Drawing.Point(40, 272)
        Me.Print_JE.Name = "Print_JE"
        Me.Print_JE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Print_JE.Size = New System.Drawing.Size(273, 25)
        Me.Print_JE.TabIndex = 8
        Me.Print_JE.Text = " Print General Journal Listing for Net Excess/Loss"
        Me.Print_JE.UseVisualStyleBackColor = False
        '
        'Create_je
        '
        Me.Create_je.BackColor = System.Drawing.SystemColors.Control
        Me.Create_je.Cursor = System.Windows.Forms.Cursors.Default
        Me.Create_je.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Create_je.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Create_je.Location = New System.Drawing.Point(40, 96)
        Me.Create_je.Name = "Create_je"
        Me.Create_je.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Create_je.Size = New System.Drawing.Size(209, 25)
        Me.Create_je.TabIndex = 2
        Me.Create_je.Text = "Enter Journal Entry for Net Excess/Loss"
        Me.Create_je.UseVisualStyleBackColor = False
        '
        'post_net
        '
        Me.post_net.BackColor = System.Drawing.SystemColors.Control
        Me.post_net.Cursor = System.Windows.Forms.Cursors.Default
        Me.post_net.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.post_net.ForeColor = System.Drawing.SystemColors.ControlText
        Me.post_net.Location = New System.Drawing.Point(40, 328)
        Me.post_net.Name = "post_net"
        Me.post_net.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.post_net.Size = New System.Drawing.Size(185, 25)
        Me.post_net.TabIndex = 6
        Me.post_net.Text = "Post Net Excess/Loss to GL"
        Me.post_net.UseVisualStyleBackColor = False
        '
        'Print_Bal
        '
        Me.Print_Bal.BackColor = System.Drawing.SystemColors.Control
        Me.Print_Bal.Cursor = System.Windows.Forms.Cursors.Default
        Me.Print_Bal.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Print_Bal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Print_Bal.Location = New System.Drawing.Point(40, 16)
        Me.Print_Bal.Name = "Print_Bal"
        Me.Print_Bal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Print_Bal.Size = New System.Drawing.Size(313, 25)
        Me.Print_Bal.TabIndex = 1
        Me.Print_Bal.Text = " Print the Balance Sheet to determine Net Excess/Loss"
        Me.Print_Bal.UseVisualStyleBackColor = False
        '
        '_txtFields_1
        '
        Me._txtFields_1.AcceptsReturn = True
        Me._txtFields_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtFields_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFields.SetIndex(Me._txtFields_1, CType(1, Short))
        Me._txtFields_1.Location = New System.Drawing.Point(472, 136)
        Me._txtFields_1.MaxLength = 0
        Me._txtFields_1.Name = "_txtFields_1"
        Me._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtFields_1.Size = New System.Drawing.Size(89, 20)
        Me._txtFields_1.TabIndex = 3
        Me._txtFields_1.Tag = "END_DATE"
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(536, 0)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(65, 20)
        Me.cmdClose.TabIndex = 9
        Me.cmdClose.TabStop = False
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUpdate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUpdate.Location = New System.Drawing.Point(312, 208)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUpdate.Size = New System.Drawing.Size(65, 20)
        Me.cmdUpdate.TabIndex = 4
        Me.cmdUpdate.TabStop = False
        Me.cmdUpdate.Text = "Verify"
        Me.cmdUpdate.UseVisualStyleBackColor = False
        '
        'label11
        '
        Me.label11.BackColor = System.Drawing.SystemColors.Control
        Me.label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label11.Location = New System.Drawing.Point(24, 248)
        Me.label11.Name = "label11"
        Me.label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label11.Size = New System.Drawing.Size(305, 17)
        Me.label11.TabIndex = 23
        Me.label11.Text = "6 - Click on button below to Print JE just created."
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(24, 368)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(281, 17)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "8 - Click on button below to reprint the Balance Sheet."
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(24, 304)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(201, 17)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "7 - Click on button below to Post JE"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(24, 208)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(281, 17)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "5 - When date is correct., click ""Verify"" button to right."
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(376, 176)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(97, 17)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "of the fiscal year."
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(240, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "This is Month"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(24, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(89, 17)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Name of Month."
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(24, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(353, 33)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "4 - Enter the Effective Date for the Journal Entry.  The  month name and number w" & _
            "ill apprear.  Be sure they are correct before continuing. "
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(24, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(305, 17)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "3 - Click button below to enter the amount as a Journal Entry"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(289, 17)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "2 - Determine the Net Excess/Loss (Assets - Liabilities) ."
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(281, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "1 - Click on the button below and ""Print the Balance Sheet"" ."
        '
        '_lblLabels_1
        '
        Me._lblLabels_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabels.SetIndex(Me._lblLabels_1, CType(1, Short))
        Me._lblLabels_1.Location = New System.Drawing.Point(392, 136)
        Me._lblLabels_1.Name = "_lblLabels_1"
        Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_1.Size = New System.Drawing.Size(60, 35)
        Me._lblLabels_1.TabIndex = 10
        Me._lblLabels_1.Text = "Effective Date:"
        '
        'txtFields
        '
        '
        'frmglie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(610, 453)
        Me.ControlBox = False
        Me.Controls.Add(Me.mth_num)
        Me.Controls.Add(Me.mth_name)
        Me.Controls.Add(Me.Reprint_bal)
        Me.Controls.Add(Me.Print_JE)
        Me.Controls.Add(Me.Create_je)
        Me.Controls.Add(Me.post_net)
        Me.Controls.Add(Me.Print_Bal)
        Me.Controls.Add(Me._txtFields_1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._lblLabels_1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(3, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmglie"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Create Closing Journal Entry For A Month"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class