<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmxaropn
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.start_date = New System.Windows.Forms.TextBox
        Me.End_Date = New System.Windows.Forms.TextBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'start_date
        '
        Me.start_date.AcceptsReturn = True
        Me.start_date.BackColor = System.Drawing.SystemColors.Window
        Me.start_date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.start_date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.start_date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.start_date.Location = New System.Drawing.Point(242, 80)
        Me.start_date.MaxLength = 0
        Me.start_date.Name = "start_date"
        Me.start_date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.start_date.Size = New System.Drawing.Size(121, 20)
        Me.start_date.TabIndex = 17
        Me.start_date.Tag = "BEG_DATE"
        '
        'End_Date
        '
        Me.End_Date.AcceptsReturn = True
        Me.End_Date.BackColor = System.Drawing.SystemColors.Window
        Me.End_Date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.End_Date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.End_Date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.End_Date.Location = New System.Drawing.Point(464, 80)
        Me.End_Date.MaxLength = 0
        Me.End_Date.Name = "End_Date"
        Me.End_Date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.End_Date.Size = New System.Drawing.Size(121, 20)
        Me.End_Date.TabIndex = 16
        Me.End_Date.Tag = "END_DATE"
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(641, 23)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(65, 34)
        Me.cmdClose.TabIndex = 14
        Me.cmdClose.TabStop = False
        Me.cmdClose.Text = "Cancel"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(159, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(77, 20)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Begin date "
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(404, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "End date "
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(91, 149)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(204, 36)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Income Trial Balance"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(91, 210)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(204, 36)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "A/R Trial Balance"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(91, 270)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(204, 36)
        Me.Button3.TabIndex = 22
        Me.Button3.Text = "Monthly Billing Face Sheets"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(91, 332)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(204, 36)
        Me.Button4.TabIndex = 23
        Me.Button4.Text = "Billed/Paid Analysis by Acct Num"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(91, 393)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(204, 36)
        Me.Button5.TabIndex = 24
        Me.Button5.Text = "Account Ball for one CID#"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(91, 448)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(204, 36)
        Me.Button6.TabIndex = 25
        Me.Button6.Text = "A/R Aging by Invoice Date"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(91, 509)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(204, 36)
        Me.Button7.TabIndex = 26
        Me.Button7.Text = "A/R Aging by Encum Date"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(441, 210)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(204, 36)
        Me.Button8.TabIndex = 27
        Me.Button8.Text = "Unbilled Report"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(441, 270)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(204, 36)
        Me.Button9.TabIndex = 28
        Me.Button9.Text = "Cash Payments Due By Invoice # - All"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(441, 332)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(204, 36)
        Me.Button10.TabIndex = 29
        Me.Button10.Text = "Cash Payments Due by Acct#"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'frmxaropn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 690)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.start_date)
        Me.Controls.Add(Me.End_Date)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Name = "frmxaropn"
        Me.Text = "Monthly A/R Reports"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents start_date As System.Windows.Forms.TextBox
    Public WithEvents End_Date As System.Windows.Forms.TextBox
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
End Class
