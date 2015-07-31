<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmre_chk
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
	Public WithEvents edit As System.Windows.Forms.Button
	Public WithEvents Prtchk As System.Windows.Forms.Button
	Public WithEvents newbegnum As System.Windows.Forms.TextBox
	Public WithEvents Lastgood As System.Windows.Forms.TextBox
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
        Me.edit = New System.Windows.Forms.Button
        Me.Prtchk = New System.Windows.Forms.Button
        Me.newbegnum = New System.Windows.Forms.TextBox
        Me.Lastgood = New System.Windows.Forms.TextBox
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
        Me.Cancel.Location = New System.Drawing.Point(477, 1)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel.Size = New System.Drawing.Size(73, 25)
        Me.Cancel.TabIndex = 10
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = False
        '
        'edit
        '
        Me.edit.BackColor = System.Drawing.SystemColors.Control
        Me.edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.edit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.edit.Location = New System.Drawing.Point(400, 40)
        Me.edit.Name = "edit"
        Me.edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.edit.Size = New System.Drawing.Size(139, 27)
        Me.edit.TabIndex = 9
        Me.edit.Text = "Edit"
        Me.edit.UseVisualStyleBackColor = False
        '
        'Prtchk
        '
        Me.Prtchk.BackColor = System.Drawing.SystemColors.Control
        Me.Prtchk.Cursor = System.Windows.Forms.Cursors.Default
        Me.Prtchk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Prtchk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Prtchk.Location = New System.Drawing.Point(224, 192)
        Me.Prtchk.Name = "Prtchk"
        Me.Prtchk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Prtchk.Size = New System.Drawing.Size(177, 33)
        Me.Prtchk.TabIndex = 2
        Me.Prtchk.Text = "Start Reprinting LASER Checks"
        Me.Prtchk.UseVisualStyleBackColor = False
        '
        'newbegnum
        '
        Me.newbegnum.AcceptsReturn = True
        Me.newbegnum.BackColor = System.Drawing.SystemColors.Window
        Me.newbegnum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.newbegnum.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newbegnum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.newbegnum.Location = New System.Drawing.Point(224, 112)
        Me.newbegnum.MaxLength = 0
        Me.newbegnum.Name = "newbegnum"
        Me.newbegnum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.newbegnum.Size = New System.Drawing.Size(145, 25)
        Me.newbegnum.TabIndex = 1
        '
        'Lastgood
        '
        Me.Lastgood.AcceptsReturn = True
        Me.Lastgood.BackColor = System.Drawing.SystemColors.Window
        Me.Lastgood.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Lastgood.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lastgood.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Lastgood.Location = New System.Drawing.Point(224, 40)
        Me.Lastgood.MaxLength = 0
        Me.Lastgood.Name = "Lastgood"
        Me.Lastgood.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Lastgood.Size = New System.Drawing.Size(145, 25)
        Me.Lastgood.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(32, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(329, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Next -- Enter the new beginning check number in the box below."
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(32, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(353, 25)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Be sure that you have re-aligned the checks in the printer.  Then,  in the box be" & _
            "low enter the number of last check printed that is usuable."
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(32, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(177, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Enter New Beginning Check Number"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(32, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(177, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Enter Last Good Check Number"
        '
        'frmre_chk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(567, 414)
        Me.ControlBox = False
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.edit)
        Me.Controls.Add(Me.Prtchk)
        Me.Controls.Add(Me.newbegnum)
        Me.Controls.Add(Me.Lastgood)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(39, 33)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmre_chk"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Restart Checks"
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class