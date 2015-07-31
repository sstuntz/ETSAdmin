<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class clijoblookup
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
	Public WithEvents Data1 As System.Windows.Forms.Label
	Public WithEvents edit As System.Windows.Forms.Button
	Public WithEvents addacct As System.Windows.Forms.Button
	Public WithEvents Cancel As System.Windows.Forms.Button
	Public WithEvents Accept As System.Windows.Forms.Button
    'Public WithEvents Grid1 As AxMSGrid.AxGrid
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.JobGrid = New System.Windows.Forms.DataGridView
        Me.etssqlDataSet = New CCnet.etssqlDataSet
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.btnAccept = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.CcjobTableAdapter = New CCnet.etssqlDataSetTableAdapters.ccjobTableAdapter
        Me.SortName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NameKey = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JobNum = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.JobGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.etssqlDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'JobGrid
        '
        Me.JobGrid.AllowUserToAddRows = False
        Me.JobGrid.AllowUserToDeleteRows = False
        Me.JobGrid.AllowUserToOrderColumns = True
        Me.JobGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.JobGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.JobGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SortName, Me.NameKey, Me.JobNum})
        Me.JobGrid.Location = New System.Drawing.Point(12, 56)
        Me.JobGrid.Name = "JobGrid"
        Me.JobGrid.ReadOnly = True
        Me.JobGrid.Size = New System.Drawing.Size(407, 395)
        Me.JobGrid.TabIndex = 0
        '
        'etssqlDataSet
        '
        Me.etssqlDataSet.DataSetName = "etssqlDataSet"
        Me.etssqlDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(471, 16)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(118, 24)
        Me.BtnCancel.TabIndex = 1
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(455, 97)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(150, 82)
        Me.btnAccept.TabIndex = 2
        Me.btnAccept.Text = "Use Selected Name"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(487, 227)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(76, 40)
        Me.BtnAdd.TabIndex = 3
        Me.BtnAdd.Text = "Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(490, 306)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(72, 40)
        Me.btnEdit.TabIndex = 4
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'CcjobTableAdapter
        '
        Me.CcjobTableAdapter.ClearBeforeFill = True
        '
        'SortName
        '
        Me.SortName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.SortName.DataPropertyName = "sort_name"
        Me.SortName.HeaderText = "SortName"
        Me.SortName.Name = "SortName"
        Me.SortName.ReadOnly = True
        Me.SortName.Width = 79
        '
        'NameKey
        '
        Me.NameKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NameKey.DataPropertyName = "name_key"
        Me.NameKey.HeaderText = "NameKey"
        Me.NameKey.Name = "NameKey"
        Me.NameKey.ReadOnly = True
        Me.NameKey.Width = 78
        '
        'JobNum
        '
        Me.JobNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.JobNum.DataPropertyName = "job_num"
        Me.JobNum.HeaderText = "JobNum"
        Me.JobNum.Name = "JobNum"
        Me.JobNum.ReadOnly = True
        Me.JobNum.Width = 71
        '
        'clijoblookup
        '
        Me.ClientSize = New System.Drawing.Size(617, 486)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.btnAccept)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.JobGrid)
        Me.Name = "clijoblookup"
        CType(Me.JobGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.etssqlDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents JobGrid As System.Windows.Forms.DataGridView
    Friend WithEvents etssqlDataSet As CCnet.etssqlDataSet
    Friend WithEvents CcjobTableAdapter As CCnet.etssqlDataSetTableAdapters.ccjobTableAdapter
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents SortName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameKey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JobNum As System.Windows.Forms.DataGridViewTextBoxColumn
#End Region
End Class