<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmtype
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Type_names = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.Cancel = New System.Windows.Forms.Button
        Me.Addacct = New System.Windows.Forms.Button
        Me.Edit = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Type_names})
        Me.DataGridView1.Location = New System.Drawing.Point(59, 116)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(286, 281)
        Me.DataGridView1.TabIndex = 0
        '
        'Type_names
        '
        Me.Type_names.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Type_names.DataPropertyName = "type_names"
        Me.Type_names.HeaderText = "Type"
        Me.Type_names.Name = "Type_names"
        Me.Type_names.ReadOnly = True
        Me.Type_names.Width = 56
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(259, 75)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select the ADD button to Add a description.  Select a record to Edit or Delete.  " & _
            "Read the Messages!"
        '
        'Cancel
        '
        Me.Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Cancel.Location = New System.Drawing.Point(467, 20)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(87, 25)
        Me.Cancel.TabIndex = 2
        Me.Cancel.Text = "Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'Addacct
        '
        Me.Addacct.Location = New System.Drawing.Point(351, 124)
        Me.Addacct.Name = "Addacct"
        Me.Addacct.Size = New System.Drawing.Size(116, 29)
        Me.Addacct.TabIndex = 3
        Me.Addacct.Text = "Add"
        Me.Addacct.UseVisualStyleBackColor = True
        '
        'Edit
        '
        Me.Edit.Location = New System.Drawing.Point(350, 199)
        Me.Edit.Name = "Edit"
        Me.Edit.Size = New System.Drawing.Size(116, 35)
        Me.Edit.TabIndex = 4
        Me.Edit.Text = "Edit"
        Me.Edit.UseVisualStyleBackColor = True
        '
        'frmtype
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 419)
        Me.Controls.Add(Me.Edit)
        Me.Controls.Add(Me.Addacct)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmtype"
        Me.Text = "frmtype"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Type_names As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents Addacct As System.Windows.Forms.Button
    Friend WithEvents Edit As System.Windows.Forms.Button
End Class
