<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class ar_cash_rev1
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
	Public WithEvents new_Date As System.Windows.Forms.TextBox
	Public WithEvents inv_num As System.Windows.Forms.TextBox
	Public WithEvents invoice_id As System.Windows.Forms.TextBox
	Public WithEvents ref_list As System.Windows.Forms.Button
	Public WithEvents ref_lst_inv As System.Windows.Forms.Button
	Public WithEvents ref_list_name As System.Windows.Forms.Button
	Public WithEvents new_amt As System.Windows.Forms.TextBox
	Public WithEvents invoice As System.Windows.Forms.Label
	Public WithEvents cash As System.Windows.Forms.Label
	Public WithEvents Edit As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cash_Tmp1 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ar_cash_rev1))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.new_Date = New System.Windows.Forms.TextBox
		Me.inv_num = New System.Windows.Forms.TextBox
		Me.invoice_id = New System.Windows.Forms.TextBox
		Me.ref_list = New System.Windows.Forms.Button
		Me.ref_lst_inv = New System.Windows.Forms.Button
		Me.ref_list_name = New System.Windows.Forms.Button
		Me.new_amt = New System.Windows.Forms.TextBox
		Me.invoice = New System.Windows.Forms.Label
		Me.cash = New System.Windows.Forms.Label
		Me.Edit = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cash_Tmp1 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label11 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "AR Cash Reversal Entry Screen1"
		Me.ClientSize = New System.Drawing.Size(632, 453)
		Me.Location = New System.Drawing.Point(58, 63)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.Name = "ar_cash_rev1"
		Me.new_Date.AutoSize = False
		Me.new_Date.Size = New System.Drawing.Size(97, 23)
		Me.new_Date.Location = New System.Drawing.Point(344, 424)
		Me.new_Date.TabIndex = 1
		Me.new_Date.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.new_Date.AcceptsReturn = True
		Me.new_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.new_Date.BackColor = System.Drawing.SystemColors.Window
		Me.new_Date.CausesValidation = True
		Me.new_Date.Enabled = True
		Me.new_Date.ForeColor = System.Drawing.SystemColors.WindowText
		Me.new_Date.HideSelection = True
		Me.new_Date.ReadOnly = False
		Me.new_Date.Maxlength = 0
		Me.new_Date.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.new_Date.MultiLine = False
		Me.new_Date.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.new_Date.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.new_Date.TabStop = True
		Me.new_Date.Visible = True
		Me.new_Date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.new_Date.Name = "new_Date"
		Me.inv_num.AutoSize = False
		Me.inv_num.Size = New System.Drawing.Size(75, 22)
		Me.inv_num.Location = New System.Drawing.Point(536, 64)
		Me.inv_num.TabIndex = 14
		Me.inv_num.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.inv_num.AcceptsReturn = True
		Me.inv_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.inv_num.BackColor = System.Drawing.SystemColors.Window
		Me.inv_num.CausesValidation = True
		Me.inv_num.Enabled = True
		Me.inv_num.ForeColor = System.Drawing.SystemColors.WindowText
		Me.inv_num.HideSelection = True
		Me.inv_num.ReadOnly = False
		Me.inv_num.Maxlength = 0
		Me.inv_num.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.inv_num.MultiLine = False
		Me.inv_num.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.inv_num.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.inv_num.TabStop = True
		Me.inv_num.Visible = True
		Me.inv_num.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.inv_num.Name = "inv_num"
		Me.invoice_id.AutoSize = False
		Me.invoice_id.Size = New System.Drawing.Size(75, 22)
		Me.invoice_id.Location = New System.Drawing.Point(536, 88)
		Me.invoice_id.TabIndex = 10
		Me.invoice_id.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.invoice_id.AcceptsReturn = True
		Me.invoice_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.invoice_id.BackColor = System.Drawing.SystemColors.Window
		Me.invoice_id.CausesValidation = True
		Me.invoice_id.Enabled = True
		Me.invoice_id.ForeColor = System.Drawing.SystemColors.WindowText
		Me.invoice_id.HideSelection = True
		Me.invoice_id.ReadOnly = False
		Me.invoice_id.Maxlength = 0
		Me.invoice_id.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.invoice_id.MultiLine = False
		Me.invoice_id.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.invoice_id.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.invoice_id.TabStop = True
		Me.invoice_id.Visible = True
		Me.invoice_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.invoice_id.Name = "invoice_id"
		Me.ref_list.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.ref_list.Text = "Refresh List in Invoice ID order"
		Me.ref_list.Size = New System.Drawing.Size(89, 41)
		Me.ref_list.Location = New System.Drawing.Point(64, 72)
		Me.ref_list.TabIndex = 9
		Me.ref_list.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ref_list.BackColor = System.Drawing.SystemColors.Control
		Me.ref_list.CausesValidation = True
		Me.ref_list.Enabled = True
		Me.ref_list.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ref_list.Cursor = System.Windows.Forms.Cursors.Default
		Me.ref_list.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ref_list.TabStop = True
		Me.ref_list.Name = "ref_list"
		Me.ref_lst_inv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.ref_lst_inv.Text = "Refresh List in Invoice# order"
		Me.ref_lst_inv.Size = New System.Drawing.Size(89, 41)
		Me.ref_lst_inv.Location = New System.Drawing.Point(200, 72)
		Me.ref_lst_inv.TabIndex = 8
		Me.ref_lst_inv.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ref_lst_inv.BackColor = System.Drawing.SystemColors.Control
		Me.ref_lst_inv.CausesValidation = True
		Me.ref_lst_inv.Enabled = True
		Me.ref_lst_inv.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ref_lst_inv.Cursor = System.Windows.Forms.Cursors.Default
		Me.ref_lst_inv.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ref_lst_inv.TabStop = True
		Me.ref_lst_inv.Name = "ref_lst_inv"
		Me.ref_list_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.ref_list_name.Text = "Refresh list by Sort Name"
		Me.ref_list_name.Size = New System.Drawing.Size(89, 41)
		Me.ref_list_name.Location = New System.Drawing.Point(336, 72)
		Me.ref_list_name.TabIndex = 7
		Me.ref_list_name.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ref_list_name.BackColor = System.Drawing.SystemColors.Control
		Me.ref_list_name.CausesValidation = True
		Me.ref_list_name.Enabled = True
		Me.ref_list_name.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ref_list_name.Cursor = System.Windows.Forms.Cursors.Default
		Me.ref_list_name.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ref_list_name.TabStop = True
		Me.ref_list_name.Name = "ref_list_name"
		Me.new_amt.AutoSize = False
		Me.new_amt.Size = New System.Drawing.Size(97, 23)
		Me.new_amt.Location = New System.Drawing.Point(224, 424)
		Me.new_amt.TabIndex = 0
		Me.new_amt.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.new_amt.AcceptsReturn = True
		Me.new_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.new_amt.BackColor = System.Drawing.SystemColors.Window
		Me.new_amt.CausesValidation = True
		Me.new_amt.Enabled = True
		Me.new_amt.ForeColor = System.Drawing.SystemColors.WindowText
		Me.new_amt.HideSelection = True
		Me.new_amt.ReadOnly = False
		Me.new_amt.Maxlength = 0
		Me.new_amt.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.new_amt.MultiLine = False
		Me.new_amt.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.new_amt.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.new_amt.TabStop = True
		Me.new_amt.Visible = True
		Me.new_amt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.new_amt.Name = "new_amt"
		Me.invoice.Text = "invoice"
		Me.invoice.Size = New System.Drawing.Size(129, 20)
		Me.invoice.Location = New System.Drawing.Point(0, 0)
		Me.invoice.Visible = False
		Me.invoice.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.invoice.BackColor = System.Drawing.Color.Red
		Me.invoice.ForeColor = System.Drawing.Color.Black
		Me.invoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.invoice.Text = "invoice"
		Me.invoice.Name = "invoice"
		Me.cash.Text = "cash"
		Me.cash.Size = New System.Drawing.Size(107, 20)
		Me.cash.Location = New System.Drawing.Point(256, 0)
		Me.cash.Visible = False
		Me.cash.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cash.BackColor = System.Drawing.Color.Red
		Me.cash.ForeColor = System.Drawing.Color.Black
		Me.cash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.cash.Text = "cash"
		Me.cash.Name = "cash"
		Me.Edit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Edit.Text = "Reverse Selected Entry"
		Me.Edit.Size = New System.Drawing.Size(150, 33)
		Me.Edit.Location = New System.Drawing.Point(472, 416)
		Me.Edit.TabIndex = 2
		Me.Edit.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Edit.BackColor = System.Drawing.SystemColors.Control
		Me.Edit.CausesValidation = True
		Me.Edit.Enabled = True
		Me.Edit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Edit.Cursor = System.Windows.Forms.Cursors.Default
		Me.Edit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Edit.TabStop = True
		Me.Edit.Name = "Edit"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "Exit this Screen"
		Me.cmdClose.Size = New System.Drawing.Size(99, 20)
		Me.cmdClose.Location = New System.Drawing.Point(536, 2)
		Me.cmdClose.TabIndex = 3
		Me.cmdClose.TabStop = False
		Me.cmdClose.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.Name = "cmdClose"
		Me.cash_Tmp1.Text = "cash tmp1"
		Me.cash_Tmp1.Size = New System.Drawing.Size(105, 20)
		Me.cash_Tmp1.Location = New System.Drawing.Point(136, 0)
		Me.cash_Tmp1.Visible = False
		Me.cash_Tmp1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cash_Tmp1.BackColor = System.Drawing.Color.Red
		Me.cash_Tmp1.ForeColor = System.Drawing.Color.Black
		Me.cash_Tmp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.cash_Tmp1.Text = "cash_Tmp1"
		Me.cash_Tmp1.Name = "cash_Tmp1"
		Me.Label6.Text = "Last"
		Me.Label6.Size = New System.Drawing.Size(33, 17)
		Me.Label6.Location = New System.Drawing.Point(352, 120)
		Me.Label6.TabIndex = 16
		Me.Label6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.BackColor = System.Drawing.SystemColors.Control
		Me.Label6.Enabled = True
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Label5.Text = "Inv_num"
		Me.Label5.Size = New System.Drawing.Size(57, 17)
		Me.Label5.Location = New System.Drawing.Point(448, 64)
		Me.Label5.TabIndex = 15
		Me.Label5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "Check Date"
		Me.Label4.Size = New System.Drawing.Size(94, 18)
		Me.Label4.Location = New System.Drawing.Point(344, 400)
		Me.Label4.TabIndex = 11
		Me.Label4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label7.Text = "For Quick Search enter: "
		Me.Label7.Size = New System.Drawing.Size(131, 18)
		Me.Label7.Location = New System.Drawing.Point(448, 40)
		Me.Label7.TabIndex = 13
		Me.Label7.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label7.BackColor = System.Drawing.SystemColors.Control
		Me.Label7.Enabled = True
		Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = False
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label11.Text = "or Invoice (ID)"
		Me.Label11.Size = New System.Drawing.Size(73, 17)
		Me.Label11.Location = New System.Drawing.Point(448, 88)
		Me.Label11.TabIndex = 12
		Me.Label11.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label11.BackColor = System.Drawing.SystemColors.Control
		Me.Label11.Enabled = True
		Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label11.UseMnemonic = True
		Me.Label11.Visible = True
		Me.Label11.AutoSize = False
		Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label11.Name = "Label11"
		Me.Label3.Text = "Correct the amount to be re-applied if not the full amount. You must use the enter key."
		Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Size = New System.Drawing.Size(177, 65)
		Me.Label3.Location = New System.Drawing.Point(24, 400)
		Me.Label3.TabIndex = 6
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "Amount to Reapply"
		Me.Label2.Size = New System.Drawing.Size(94, 18)
		Me.Label2.Location = New System.Drawing.Point(224, 400)
		Me.Label2.TabIndex = 5
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Select a Line from below to set up a new cash batch for re-applying to a different invoice."
		Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Size = New System.Drawing.Size(345, 38)
		Me.Label1.Location = New System.Drawing.Point(16, 24)
		Me.Label1.TabIndex = 4
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(new_Date)
		Me.Controls.Add(inv_num)
		Me.Controls.Add(invoice_id)
		Me.Controls.Add(ref_list)
		Me.Controls.Add(ref_lst_inv)
		Me.Controls.Add(ref_list_name)
		Me.Controls.Add(new_amt)
		Me.Controls.Add(invoice)
		Me.Controls.Add(cash)
		Me.Controls.Add(Edit)
		Me.Controls.Add(cmdClose)
		Me.Controls.Add(cash_Tmp1)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label11)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class