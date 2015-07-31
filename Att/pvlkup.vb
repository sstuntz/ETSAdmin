Option Strict On
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Conversion
Imports Microsoft.VisualBasic.PowerPacks
Imports Microsoft.VisualBasic.Compatibility.VB6
Imports System
Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common
Imports System.Data.SqlClient

public Class pvformlookup
	Inherits System.Windows.Forms.Form
    Dim SelectedIndex As Integer

    Private Sub rebuild_grid()

        Me.DataGridView1.ClearSelection()

        Select Case pv_Type
            Case "TEMP"
                Me.Text = "These are the PV Templates"
                sqlstmnt = "select pv_Form, contract_key from mmpv"

            Case "ACT"
                Me.Text = "These are the Actual PV's"
                sqlstmnt = "select pv_Form, contract_key from  mmpv_tmp"
                extra_com.Text = "Print"
                extra_com.Visible = True

            Case "CREATE"
                Me.Text = "These are the PV Templates available for the Unsupported PVs"
                sqlstmnt = "select pv_Form, contract_key from  from cc_Cont where val(left(bill_type,1)) = 9 and pv_form <> """" and active = 'Y' " 'where bill type is blank but we check this out below just beofre display
                extra_com.Text = "Start Selected PV"
                extra_com.Visible = True
                Accept.Visible = False
                addacct.Visible = False
                edit.Visible = False

            Case "PRINT"
                Me.Text = "These are the Actual PV's that are available to print"
                sqlstmnt = "select pv_Form, contract_key from mmpv_tmp where print = ""Y"" "
                extra_com.Text = "Print"
                extra_com.Visible = True

            Case Else
                Me.Text = "These are the PV Templates"
                sqlstmnt = "select pv_Form, contract_key from  mmpv"
        End Select

        'If Err.Number = 3021 Then
        '    MsgBox("there are no PVs to create")
        '    Err.Clear()
        '    Exit Sub
        'End If

        Dim rs As DataSet
        Using db As Database = New Database(top_data_path)
            rs = db.FillDataSet(sqlstmnt)
        End Using
        DataGridView1.DataSource = rs.Tables(0)
        selectedcell = False
        selected_lookup_num = ""
        Select Case SelectedIndex
            Case 0
                On Error Resume Next
                DataGridView1.Rows(0).Selected = False
                SelectedIndex = 1
                On Error GoTo 0
            Case Is > DataGridView1.Rows.Count
                SelectedIndex = 1
            Case Else
                DataGridView1.FirstDisplayedScrollingRowIndex = SelectedIndex
                ' DataGridView1.Rows(SelectedIndex).Selected = True
                'DataGridView1.Rows(SelectedIndex).Cells(0).Selected = True
                DataGridView1.PerformLayout()
        End Select

        DataGridView1.AutoResizeColumns()
        DataGridView1.ClearSelection()
        DataGridView1.CurrentCell = Nothing

    End Sub

    Private Sub DataGridView1__CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex <> -1 Then
            selectedcell = True
            selected_lookup_num = DataGridView1.Item("pv_form", e.RowIndex).Value.ToString
            selected_contract_key = DataGridView1.Item("contract_key", e.RowIndex).Value.ToString
        End If
        SelectedIndex = DataGridView1.CurrentRow.Index

    End Sub
	Private Sub Accept_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Accept.Click
		If selectedcell = False Then
			MsgBox("Nothing selected")
			Exit Sub
		End If
		
        Me.Close()
        Me.Dispose()

	End Sub
	
	Private Sub addacct_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles addacct.Click
		entry_type = "ADD"
        pv_add.ShowDialog()

        rebuild_grid()

    End Sub
	
	Private Sub Cancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Cancel.Click
		selected_lookup_num = " " '
		selected_screen_nam = " "
		selected_plan_desc = " "
		

        Me.Close()
        Me.Dispose()
		
	End Sub
	
	Private Sub Edit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Edit.Click
		If selectedcell = False Then
			MsgBox("Nothing selected")
			Exit Sub
		End If
	
		entry_type = "EDIT"
        frmmmpv1.ShowDialog()

        rebuild_grid()

	End Sub
	
	Private Sub extra_com_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles extra_com.Click
		
		If selectedcell = False Then
			MsgBox("Nothing selected")
			Exit Sub
        End If

        sqlstmnt = "delete from mmpv_tmp"
        ETSSQL.ExecuteSQL(sqlstmnt)


        Select Case pv_Type
            Case "CREATE"
                sqlstmnt = "select * from mmpv where pv_form = "
                'move records to mmpv_tmp from mmpv
                sqlstmnt = "insert into mmpv_tmp from mmpv where pv_form = " & selected_lookup_num & "'"
                ETSSQL.ExecuteSQL(sqlstmnt)
                entry_type = "EDIT"

                frmmmpv1.Show()
                Me.Close()
                Me.Dispose()

        End Select
		
	End Sub
	
	Private Sub pvformlookup_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
      
        DataGridView1.Columns.Add("pv_form", "PV")
        DataGridView1.Columns.Item(0).DataPropertyName = "pv_form"
        DataGridView1.Columns.Add("contract_key", "Contract")
        DataGridView1.Columns.Item(1).DataPropertyName = "contract_key"
        ' put the dashes in contract?  DataGridView1.Columns.Item(1).DefaultCellStyle.Format = XXX

        DataGridView1.AutoResizeColumns()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        selectedcell = False
        ctrform(Me)
        rebuild_grid()
        If function_type = "DATA_ENTRY" Then
            Accept.Enabled = True
        End If
    End Sub

End Class