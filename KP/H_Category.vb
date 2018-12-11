Public Class H_Category


    Public ID As String
    Dim CategoryList As New List(Of Entity.Category)

    Private Sub FormatGridWithBothTableAndColumnStyles()
        Me.DgView.DefaultCellStyle.ForeColor = Color.Navy
        Me.DgView.RowsDefaultCellStyle.BackColor = Color.AliceBlue
        Me.DgView.GridColor = Color.Blue
        Me.DgView.BorderStyle = BorderStyle.Fixed3D
        Me.DgView.RowHeadersBorderStyle = BorderStyle.Fixed3D


        DgView.AutoGenerateColumns = False

        Dim IDColumn As New DataGridViewTextBoxColumn()
        IDColumn.DataPropertyName = "Category_ID"
        IDColumn.HeaderText = "Category ID"
        IDColumn.Width = 200

        Dim NameColumn As New DataGridViewTextBoxColumn()
        NameColumn.DataPropertyName = "Category_name"
        NameColumn.HeaderText = "Category Name"
        NameColumn.Width = 200



        DgView.Columns.Add(IDColumn)
        DgView.Columns.Add(NameColumn)

    End Sub


    Private Sub DgView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgView.CellDoubleClick
        Dim row As DataGridViewRow = DgView.Rows(e.RowIndex)
        ID = row.Cells(0).Value

        Me.Close()
    End Sub


    Private Sub H_Genre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim columns As String() = {"Category_id", "Category_name"}

            KPModule.FillListWithoutParam(CategoryList, columns, "usp_SelectCategory", _
                                                             GetType(Entity.Category))


            FormatGridWithBothTableAndColumnStyles()
            DgView.DataSource = CategoryList



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "DVD Rental")
        End Try
    End Sub
End Class