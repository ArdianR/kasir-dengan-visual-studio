Imports System.Collections.Generic
Public Class H_DTrans

    'Dim DtDataview As New DataView
    'Dim objDataTable As New DataTable

    Dim DetailList As New List(Of Entity.DetailTrans)

    Private Sub FormatGridWithBothTableAndColumnStyles()
        Me.DgView.DefaultCellStyle.ForeColor = Color.Navy
        Me.DgView.RowsDefaultCellStyle.BackColor = Color.AliceBlue
        Me.DgView.GridColor = Color.Blue
        Me.DgView.BorderStyle = BorderStyle.Fixed3D
        Me.DgView.RowHeadersBorderStyle = BorderStyle.Fixed3D


        DgView.AutoGenerateColumns = False

        Dim NoColumn As New DataGridViewTextBoxColumn()
        NoColumn.DataPropertyName = "Transno"
        NoColumn.HeaderText = "Transaksi"
        NoColumn.Width = 150

        Dim IDColumn As New DataGridViewTextBoxColumn()
        IDColumn.DataPropertyName = "Stock_ID"
        IDColumn.HeaderText = "Kode Barang"
        IDColumn.Visible = False

        Dim NameColumn As New DataGridViewTextBoxColumn()
        NameColumn.DataPropertyName = "Stock_Name"
        NameColumn.HeaderText = "Nama Barang"
        NameColumn.Width = 150

        Dim BuyColumn As New DataGridViewTextBoxColumn()
        BuyColumn.DataPropertyName = "Price_Buy"
        BuyColumn.HeaderText = "Harga Beli"
        BuyColumn.Width = 150

        Dim SellColumn As New DataGridViewTextBoxColumn()
        SellColumn.DataPropertyName = "Price_Sell"
        SellColumn.HeaderText = "Harga Jual"
        SellColumn.Width = 150

        Dim ItemBuyColumn As New DataGridViewTextBoxColumn()
        ItemBuyColumn.DataPropertyName = "Item_Buy"
        ItemBuyColumn.HeaderText = "Item"
        ItemBuyColumn.Width = 100

        Dim BTColumn As New DataGridViewTextBoxColumn()
        BTColumn.DataPropertyName = "Buy_Total"
        BTColumn.HeaderText = "Total Beli"
        BTColumn.Width = 150

        Dim STColumn As New DataGridViewTextBoxColumn()
        STColumn.DataPropertyName = "Sell_Total"
        STColumn.HeaderText = "Total Jual"
        STColumn.Width = 150

        DgView.Columns.Add(NoColumn)
        DgView.Columns.Add(IDColumn)
        DgView.Columns.Add(NameColumn)
        DgView.Columns.Add(BuyColumn)
        DgView.Columns.Add(SellColumn)
        DgView.Columns.Add(ItemBuyColumn)
        DgView.Columns.Add(BTColumn)
        DgView.Columns.Add(STColumn)


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub H_DTrans_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Operate = Nothing
    End Sub

    Private Sub H_DTrans_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim columns As String() = {"TransNo", "stock_id", "stock_name", "price_buy", "price_sell", "item_buy", "buy_total", "sell_total"}

            KPModule.FillListWithoutParam(DetailList, columns, "usp_SelectDetailList", _
                                                            GetType(Entity.DetailTrans))
            FormatGridWithBothTableAndColumnStyles()
            DgView.DataSource = DetailList

            txtSearch.Focus()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        Try

            Dim query = From a In DetailList
            If RbTrans.Checked = True Then
                query = query.Where(Function(u As Entity.DetailTrans) u.TransNo.Contains(txtSearch.Text)).ToList
            ElseIf RbNama.Checked = True Then
                query = query.Where(Function(u As Entity.DetailTrans) u.Stock_Name.Contains(txtSearch.Text)).ToList
            End If

            DgView.DataSource = query




        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub DgView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgView.CellDoubleClick
        If Operate <> Nothing Then
            Dim row As DataGridViewRow = DgView.Rows(e.RowIndex)
            txtSearch.Text = row.Cells(0).Value
            Operate = Nothing
            Me.Close()
        End If

    End Sub


End Class