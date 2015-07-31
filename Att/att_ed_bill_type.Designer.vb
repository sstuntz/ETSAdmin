<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class att_edit_bill_type
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
    Public WithEvents start_date As System.Windows.Forms.TextBox
    Public WithEvents End_Date As System.Windows.Forms.TextBox
    Public WithEvents del_attend As System.Windows.Forms.Button
    Public WithEvents editall As System.Windows.Forms.Button
    Public WithEvents change As System.Windows.Forms.Button
    Public WithEvents Edit As System.Windows.Forms.Button
    Public WithEvents prt_Ed As System.Windows.Forms.Button
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents cmdUpdate As System.Windows.Forms.Button
    Public WithEvents cmdRefresh As System.Windows.Forms.Button
    Public WithEvents cmdAdd As System.Windows.Forms.Button
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.start_date = New System.Windows.Forms.TextBox()
        Me.End_Date = New System.Windows.Forms.TextBox()
        Me.del_attend = New System.Windows.Forms.Button()
        Me.editall = New System.Windows.Forms.Button()
        Me.change = New System.Windows.Forms.Button()
        Me.Edit = New System.Windows.Forms.Button()
        Me.prt_Ed = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Save125Data = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'start_date
        '
        Me.start_date.AcceptsReturn = True
        Me.start_date.BackColor = System.Drawing.SystemColors.Window
        Me.start_date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.start_date.Enabled = False
        Me.start_date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.start_date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.start_date.Location = New System.Drawing.Point(144, 8)
        Me.start_date.MaxLength = 0
        Me.start_date.Name = "start_date"
        Me.start_date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.start_date.Size = New System.Drawing.Size(121, 20)
        Me.start_date.TabIndex = 12
        Me.start_date.Tag = "BEG_DATE"
        '
        'End_Date
        '
        Me.End_Date.AcceptsReturn = True
        Me.End_Date.BackColor = System.Drawing.SystemColors.Window
        Me.End_Date.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.End_Date.Enabled = False
        Me.End_Date.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.End_Date.ForeColor = System.Drawing.SystemColors.WindowText
        Me.End_Date.Location = New System.Drawing.Point(398, 8)
        Me.End_Date.MaxLength = 0
        Me.End_Date.Name = "End_Date"
        Me.End_Date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.End_Date.Size = New System.Drawing.Size(121, 20)
        Me.End_Date.TabIndex = 11
        Me.End_Date.Tag = "END_DATE"
        '
        'del_attend
        '
        Me.del_attend.BackColor = System.Drawing.SystemColors.Control
        Me.del_attend.Cursor = System.Windows.Forms.Cursors.Default
        Me.del_attend.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.del_attend.ForeColor = System.Drawing.SystemColors.ControlText
        Me.del_attend.Location = New System.Drawing.Point(32, 408)
        Me.del_attend.Name = "del_attend"
        Me.del_attend.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.del_attend.Size = New System.Drawing.Size(168, 45)
        Me.del_attend.TabIndex = 10
        Me.del_attend.Text = "Delete all records for this person"
        Me.del_attend.UseVisualStyleBackColor = False
        '
        'editall
        '
        Me.editall.BackColor = System.Drawing.SystemColors.Control
        Me.editall.Cursor = System.Windows.Forms.Cursors.Default
        Me.editall.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editall.ForeColor = System.Drawing.SystemColors.ControlText
        Me.editall.Location = New System.Drawing.Point(512, 392)
        Me.editall.Name = "editall"
        Me.editall.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.editall.Size = New System.Drawing.Size(121, 41)
        Me.editall.TabIndex = 9
        Me.editall.Text = "Edit all Consumers"
        Me.editall.UseVisualStyleBackColor = False
        Me.editall.Visible = False
        '
        'change
        '
        Me.change.BackColor = System.Drawing.SystemColors.Control
        Me.change.Cursor = System.Windows.Forms.Cursors.Default
        Me.change.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.change.ForeColor = System.Drawing.SystemColors.ControlText
        Me.change.Location = New System.Drawing.Point(32, 360)
        Me.change.Name = "change"
        Me.change.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.change.Size = New System.Drawing.Size(168, 33)
        Me.change.TabIndex = 8
        Me.change.Text = "Edit one day for a period"
        Me.change.UseVisualStyleBackColor = False
        '
        'Edit
        '
        Me.Edit.BackColor = System.Drawing.SystemColors.Control
        Me.Edit.Cursor = System.Windows.Forms.Cursors.Default
        Me.Edit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Edit.Location = New System.Drawing.Point(510, 345)
        Me.Edit.Name = "Edit"
        Me.Edit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Edit.Size = New System.Drawing.Size(121, 38)
        Me.Edit.TabIndex = 5
        Me.Edit.Text = "Edit Daily Data"
        Me.Edit.UseVisualStyleBackColor = False
        '
        'prt_Ed
        '
        Me.prt_Ed.BackColor = System.Drawing.SystemColors.Control
        Me.prt_Ed.Cursor = System.Windows.Forms.Cursors.Default
        Me.prt_Ed.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prt_Ed.ForeColor = System.Drawing.SystemColors.ControlText
        Me.prt_Ed.Location = New System.Drawing.Point(360, 496)
        Me.prt_Ed.Name = "prt_Ed"
        Me.prt_Ed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.prt_Ed.Size = New System.Drawing.Size(89, 17)
        Me.prt_Ed.TabIndex = 4
        Me.prt_Ed.Text = "Print Edit"
        Me.prt_Ed.UseVisualStyleBackColor = False
        Me.prt_Ed.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(552, 16)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(65, 20)
        Me.cmdClose.TabIndex = 3
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
        Me.cmdUpdate.Location = New System.Drawing.Point(516, 475)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUpdate.Size = New System.Drawing.Size(65, 20)
        Me.cmdUpdate.TabIndex = 2
        Me.cmdUpdate.TabStop = False
        Me.cmdUpdate.Text = "Save"
        Me.cmdUpdate.UseVisualStyleBackColor = False
        Me.cmdUpdate.Visible = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRefresh.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRefresh.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRefresh.Location = New System.Drawing.Point(145, 542)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRefresh.Size = New System.Drawing.Size(65, 20)
        Me.cmdRefresh.TabIndex = 1
        Me.cmdRefresh.TabStop = False
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        Me.cmdRefresh.Visible = False
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAdd.Location = New System.Drawing.Point(41, 542)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAdd.Size = New System.Drawing.Size(65, 20)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.TabStop = False
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = False
        Me.cmdAdd.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(124, 21)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Begin date for Billing"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(271, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(126, 21)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "End date for Billing"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(31, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(236, 35)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Select One Item From the Following list for detail editing"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(38, 104)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(579, 215)
        Me.DataGridView1.TabIndex = 14
        '
        'Save125Data
        '
        Me.Save125Data.Location = New System.Drawing.Point(270, 365)
        Me.Save125Data.Name = "Save125Data"
        Me.Save125Data.Size = New System.Drawing.Size(149, 27)
        Me.Save125Data.TabIndex = 15
        Me.Save125Data.Text = "Save 125 Data"
        Me.Save125Data.UseVisualStyleBackColor = True
        Me.Save125Data.Visible = False
        '
        'att_edit_bill_type
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(644, 465)
        Me.ControlBox = False
        Me.Controls.Add(Me.Save125Data)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.start_date)
        Me.Controls.Add(Me.End_Date)
        Me.Controls.Add(Me.del_attend)
        Me.Controls.Add(Me.editall)
        Me.Controls.Add(Me.change)
        Me.Controls.Add(Me.Edit)
        Me.Controls.Add(Me.prt_Ed)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(81, 43)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "att_edit_bill_type"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Billing Selection"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Save125Data As System.Windows.Forms.Button
#End Region 
End Class