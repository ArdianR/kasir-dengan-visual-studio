Imports System.Data.OleDb

Public Class H_Stock

    Public ID, NAMA, PRICEBUY, PRICESELL, ITEM, CATEGORY As String
    Dim StockList As New List(Of Entity.Stock)

    Private Sub FormatGridWithBothTableAndColumnStyles()
        Me.DgView.DefaultCellStyle.ForeColor = Color.Navy
        Me.DgView.RowsDefaultCellStyle.BackColor = Color.AliceBlue
        Me.DgView.GridColor = Color.Blue
        Me.DgView.BorderStyle = BorderStyle.Fixed3D
        Me.DgView.RowHeadersBorderStyle = BorderStyle.Fixed3D


        DgView.AutoGenerateColumns = False

        Dim IDColumn As New DataGridViewTextBoxColumn()
        IDColumn.DataPropertyName = "stock_id"
        IDColumn.HeaderText = "ID"
        IDColumn.Visible = False

        Dim TanggalColumn As New DataGridViewTextBoxColumn()
        TanggalColumn.DataPropertyName = "tanggal"
        TanggalColumn.HeaderText = "Tanggal"
        TanggalColumn.Width = 100

        Dim NameColumn As New DataGridViewTextBoxColumn()
        NameColumn.DataPropertyName = "stock_name"
        NameColumn.HeaderText = "Name"
        NameColumn.Width = 150

        Dim PriceBuyColumn As New DataGridViewTextBoxColumn()
        PriceBuyColumn.DataPropertyName = "price_buy"
        PriceBuyColumn.HeaderText = "Price Buy"
        PriceBuyColumn.Width = 150

        Dim PriceSellColumn As New DataGridViewTextBoxColumn()
        PriceSellColumn.DataPropertyName = "price_sell"
        PriceSellColumn.HeaderText = "Price Sell"
        PriceSellColumn.Width = 150

        Dim StockColumn As New DataGridViewTextBoxColumn()
        StockColumn.DataPropertyName = "stock_item"
        StockColumn.HeaderText = "Stock"
        StockColumn.Width = 100

        Dim CategoryColumn As New DataGridViewTextBoxColumn()
        CategoryColumn.DataPropertyName = "category_name"
        CategoryColumn.HeaderText = "Category"
        CategoryColumn.Width = 150

        DgView.Columns.Add(IDColumn)
        DgView.Columns.Add(TanggalColumn)
        DgView.Columns.Add(NameColumn)
        DgView.Columns.Add(PriceBuyColumn)
        DgView.Columns.Add(PriceSellColumn)
        DgView.Columns.Add(StockColumn)
        DgView.Columns.Add(CategoryColumn)

    End Sub

    Private Sub H_Goup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim columns As String() = {"stock_id", "tanggal", "stock_name", "price_buy", "price_sell", "stock_item", "category_name"}
            KPModule.FillListWithoutParam(StockList, columns, "usp_SelectStock", GetType(Entity.Stock))

            FormatGridWithBothTableAndColumnStyles()
            DgView.DataSource = StockList
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub DgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgView.CellDoubleClick
        Dim row As DataGridViewRow = DgView.Rows(e.RowIndex)
        ID = row.Cells(0).Value
        NAMA = row.Cells(2).Value
        PRICEBUY = row.Cells(3).Value
        PRICESELL = row.Cells(4).Value
        ITEM = row.Cells(5).Value
        CATEGORY = row.Cells(6).Value
        Me.Close()
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        Try
            Dim query = From a In StockList
            If RbTitle.Checked = True Then
                query = query.Where(Function(u As Entity.Stock) u.Stock_Name.Contains(txtSearch.Text)).ToList
            ElseIf RbActor.Checked = True Then
                query = query.Where(Function(u As Entity.Stock) u.Category_Name.Contains(txtSearch.Text)).ToList
            End If

            DgView.DataSource = query

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub
End Class