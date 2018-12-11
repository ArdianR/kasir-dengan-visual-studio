Public Class H_Paket

    Public ID As String
    Dim PaketList As New List(Of Entity.Paket)

    Private Sub FormatGridWithBothTableAndColumnStyles()
        Me.DgView.DefaultCellStyle.ForeColor = Color.Navy
        Me.DgView.RowsDefaultCellStyle.BackColor = Color.AliceBlue
        Me.DgView.GridColor = Color.Blue
        Me.DgView.BorderStyle = BorderStyle.Fixed3D
        Me.DgView.RowHeadersBorderStyle = BorderStyle.Fixed3D


        DgView.AutoGenerateColumns = False

        Dim IDColumn As New DataGridViewTextBoxColumn()
        IDColumn.DataPropertyName = "Paket_id"
        IDColumn.HeaderText = "Paket ID"
        IDColumn.Width = 160

        Dim NameColumn As New DataGridViewTextBoxColumn()
        NameColumn.DataPropertyName = "Paket_name"
        NameColumn.HeaderText = "Name"
        NameColumn.Width = 160

        Dim PriceColumn As New DataGridViewTextBoxColumn()
        PriceColumn.DataPropertyName = "price"
        PriceColumn.HeaderText = "Price"
        PriceColumn.Width = 160

        DgView.Columns.Add(IDColumn)
        DgView.Columns.Add(NameColumn)
        DgView.Columns.Add(PriceColumn)

    End Sub

    Private Sub DgView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgView.CellDoubleClick
        Dim row As DataGridViewRow = DgView.Rows(e.RowIndex)
        ID = row.Cells(0).Value
        Me.Close()
    End Sub

    Private Sub H_Paket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim columns As String() = {"paket_id", "paket_name", "price"}
            KPModule.FillListWithoutParam(PaketList, columns, "usp_SelectPaket", _
                                                                GetType(Entity.Paket))
            FormatGridWithBothTableAndColumnStyles()
            DgView.DataSource = PaketList
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

End Class