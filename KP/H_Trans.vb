Imports System.Collections.Generic
Public Class H_Trans

    'Dim DtDataview As New DataView
    'Dim objDataTable As New DataTable
    Dim TransList As New List(Of Entity.Trans)

    Private Sub FormatGridWithBothTableAndColumnStyles()
        Me.DgView.DefaultCellStyle.ForeColor = Color.Navy
        Me.DgView.RowsDefaultCellStyle.BackColor = Color.AliceBlue
        Me.DgView.GridColor = Color.Blue
        Me.DgView.BorderStyle = BorderStyle.Fixed3D
        Me.DgView.RowHeadersBorderStyle = BorderStyle.Fixed3D

        DgView.AutoGenerateColumns = False

        Dim TanggalColumn As New DataGridViewTextBoxColumn()
        TanggalColumn.DataPropertyName = "Tanggal"
        TanggalColumn.HeaderText = "Tanggal"
        TanggalColumn.Width = 130

        Dim TransColumn As New DataGridViewTextBoxColumn()
        TransColumn.DataPropertyName = "TransNo"
        TransColumn.HeaderText = "Transaction No"
        TransColumn.Width = 130

        Dim ItemColumn As New DataGridViewTextBoxColumn()
        ItemColumn.DataPropertyName = "total_item"
        ItemColumn.HeaderText = "Item"
        ItemColumn.Width = 120

        Dim TotalColumn As New DataGridViewTextBoxColumn()
        TotalColumn.DataPropertyName = "Total_Bayar"
        TotalColumn.HeaderText = "Total"
        TotalColumn.Width = 130

        Dim TunaiColumn As New DataGridViewTextBoxColumn()
        TunaiColumn.DataPropertyName = "Dibayar"
        TunaiColumn.HeaderText = "Tunai"
        TunaiColumn.Width = 130

        Dim KembaliColumn As New DataGridViewTextBoxColumn()
        KembaliColumn.DataPropertyName = "Kembali"
        KembaliColumn.HeaderText = "Kembali"
        KembaliColumn.Width = 130

        DgView.Columns.Add(TransColumn)
        DgView.Columns.Add(TanggalColumn)
        DgView.Columns.Add(ItemColumn)
        DgView.Columns.Add(TotalColumn)
        DgView.Columns.Add(TunaiColumn)
        DgView.Columns.Add(KembaliColumn)

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    

    Private Sub DgView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgView.CellDoubleClick
        If Operate <> Nothing Then
            Dim row As DataGridViewRow = DgView.Rows(e.RowIndex)
            txtSearch.Text = row.Cells(0).Value
            Operate = Nothing
            Me.Close()
        End If

    End Sub

    Private Sub H_Trans_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Operate = Nothing
    End Sub

    Private Sub H_Trans_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim columns As String() = {"tanggal", "TransNo", "Total_Item", "total_beli", "Total_Jual", "total_dibeli", "total_bayar", "dibayar", "kembali"}
            KPModule.FillListWithoutParam(TransList, columns, "usp_SelectTransList", GetType(Entity.Trans))

            FormatGridWithBothTableAndColumnStyles()
            DgView.DataSource = TransList

            txtSearch.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        Try

            Dim query = (From a In TransList Where a.TransNo.Contains(txtSearch.Text)).ToList

            DgView.DataSource = query

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub
End Class