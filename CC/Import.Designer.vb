<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Import
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PayrollNumber = New System.Windows.Forms.TextBox()
        Me.SigCheck = New System.Windows.Forms.Button()
        Me.DataCheck = New System.Windows.Forms.Button()
        Me.ImportSheet = New System.Windows.Forms.Button()
        Me.cancel = New System.Windows.Forms.Button()
        Me.NoWorkCoach = New System.Windows.Forms.Button()
        Me.StartDate = New System.Windows.Forms.TextBox()
        Me.EndDate = New System.Windows.Forms.TextBox()
        Me.CheckDate = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(68, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(255, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This will import records to be paid on  Payroll Number"
        '
        'PayrollNumber
        '
        Me.PayrollNumber.Location = New System.Drawing.Point(137, 215)
        Me.PayrollNumber.Name = "PayrollNumber"
        Me.PayrollNumber.Size = New System.Drawing.Size(128, 20)
        Me.PayrollNumber.TabIndex = 3
        '
        'SigCheck
        '
        Me.SigCheck.Location = New System.Drawing.Point(103, 333)
        Me.SigCheck.Name = "SigCheck"
        Me.SigCheck.Size = New System.Drawing.Size(187, 40)
        Me.SigCheck.TabIndex = 5
        Me.SigCheck.Text = "Print Error Report"
        Me.SigCheck.UseVisualStyleBackColor = True
        Me.SigCheck.Visible = False
        '
        'DataCheck
        '
        Me.DataCheck.Location = New System.Drawing.Point(103, 271)
        Me.DataCheck.Name = "DataCheck"
        Me.DataCheck.Size = New System.Drawing.Size(187, 40)
        Me.DataCheck.TabIndex = 4
        Me.DataCheck.Text = "Check Timesheet Data"
        Me.DataCheck.UseVisualStyleBackColor = True
        '
        'ImportSheet
        '
        Me.ImportSheet.Location = New System.Drawing.Point(103, 394)
        Me.ImportSheet.Name = "ImportSheet"
        Me.ImportSheet.Size = New System.Drawing.Size(187, 40)
        Me.ImportSheet.TabIndex = 6
        Me.ImportSheet.Text = "Import Time Sheets"
        Me.ImportSheet.UseVisualStyleBackColor = True
        '
        'cancel
        '
        Me.cancel.BackColor = System.Drawing.SystemColors.Control
        Me.cancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cancel.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.cancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cancel.Location = New System.Drawing.Point(327, 12)
        Me.cancel.Name = "cancel"
        Me.cancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cancel.Size = New System.Drawing.Size(101, 27)
        Me.cancel.TabIndex = 7
        Me.cancel.Text = "Cancel"
        Me.cancel.UseVisualStyleBackColor = False
        '
        'NoWorkCoach
        '
        Me.NoWorkCoach.Location = New System.Drawing.Point(25, 468)
        Me.NoWorkCoach.Name = "NoWorkCoach"
        Me.NoWorkCoach.Size = New System.Drawing.Size(187, 40)
        Me.NoWorkCoach.TabIndex = 28
        Me.NoWorkCoach.Text = "List of Coaches without activity this week."
        Me.NoWorkCoach.UseVisualStyleBackColor = True
        Me.NoWorkCoach.Visible = False
        '
        'StartDate
        '
        Me.StartDate.Location = New System.Drawing.Point(52, 87)
        Me.StartDate.Name = "StartDate"
        Me.StartDate.Size = New System.Drawing.Size(131, 20)
        Me.StartDate.TabIndex = 0
        '
        'EndDate
        '
        Me.EndDate.Location = New System.Drawing.Point(241, 87)
        Me.EndDate.Name = "EndDate"
        Me.EndDate.Size = New System.Drawing.Size(136, 20)
        Me.EndDate.TabIndex = 1
        '
        'CheckDate
        '
        Me.CheckDate.Location = New System.Drawing.Point(140, 157)
        Me.CheckDate.Name = "CheckDate"
        Me.CheckDate.Size = New System.Drawing.Size(122, 20)
        Me.CheckDate.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Start Date for Import"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(244, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "End Date for Import"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(100, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(230, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Check Date that will be used for the date range"
        '
        'Import
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 520)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CheckDate)
        Me.Controls.Add(Me.EndDate)
        Me.Controls.Add(Me.StartDate)
        Me.Controls.Add(Me.NoWorkCoach)
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.ImportSheet)
        Me.Controls.Add(Me.DataCheck)
        Me.Controls.Add(Me.SigCheck)
        Me.Controls.Add(Me.PayrollNumber)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Import"
        Me.Text = "Import Time Sheets"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PayrollNumber As System.Windows.Forms.TextBox
    Friend WithEvents SigCheck As System.Windows.Forms.Button
    Friend WithEvents DataCheck As System.Windows.Forms.Button
    Friend WithEvents ImportSheet As System.Windows.Forms.Button
    Public WithEvents cancel As System.Windows.Forms.Button
    Friend WithEvents NoWorkCoach As System.Windows.Forms.Button
    Friend WithEvents StartDate As System.Windows.Forms.TextBox
    Friend WithEvents EndDate As System.Windows.Forms.TextBox
    Friend WithEvents CheckDate As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
