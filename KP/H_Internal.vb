Public Class H_Internal

    Public ID, TANGGAL, TUNAI, KETERANGAN As String
    Dim InternalList As New List(Of Entity.Internal)

    Private Sub FormatGridWithBothTableAndColumnStyles()
        Me.DgView.DefaultCellStyle.ForeColor = Color.Navy
        Me.DgView.RowsDefaultCellStyle.BackColor = Color.AliceBlue
        Me.DgView.GridColor = Color.Blue
        Me.DgView.BorderStyle = BorderStyle.Fixed3D
        Me.DgView.RowHeadersBorderStyle = BorderStyle.Fixed3D


        DgView.AutoGenerateColumns = False

        Dim NoColumn As New DataGridViewTextBoxColumn()
        NoColumn.DataPropertyName = "no"
        NoColumn.HeaderText = "No"
        NoColumn.Visible = False

        Dim TanggalColumn As New DataGridViewTextBoxColumn()
        TanggalColumn.DataPropertyName = "Tanggal"
        TanggalColumn.HeaderText = "Tanggal"
        TanggalColumn.Width = 150

        Dim TunaiColumn As New DataGridViewTextBoxColumn()
        TunaiColumn.DataPropertyName = "Tunai"
        TunaiColumn.HeaderText = "Tunai"
        TunaiColumn.Width = 150

        Dim KetColumn As New DataGridViewTextBoxColumn()
        KetColumn.DataPropertyName = "Keterangan"
        KetColumn.HeaderText = "Keterangan"
        KetColumn.Width = 250

        DgView.Columns.Add(NoColumn)
        DgView.Columns.Add(TanggalColumn)
        DgView.Columns.Add(TunaiColumn)
        DgView.Columns.Add(KetColumn)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub DgView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgView.CellDoubleClick
        Dim row As DataGridViewRow = DgView.Rows(e.RowIndex)
        ID = row.Cells(0).Value
        TANGGAL = row.Cells(1).Value
        TUNAI = row.Cells(2).Value
        KETERANGAN = row.Cells(3).Value
        Me.Close()
    End Sub

    Private Sub H_Cust_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Operate = Nothing
    End Sub

    Private Sub H_Cust_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim columns As String() = {"No", "Tanggal", "Tunai", "Keterangan"}

            KPModule.FillListWithoutParam(InternalList, columns, "usp_SelectIntList", _
                                                             GetType(Entity.Internal))


            FormatGridWithBothTableAndColumnStyles()
            DgView.DataSource = InternalList
            txtSearch.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        Try

            Dim query = (From a In InternalList Where a.Keterangan.Contains(txtSearch.Text) OrElse _
                        a.Tanggal.Contains(txtSearch.Text) Select a).ToList
            DgView.DataSource = query

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try

    End Sub
End Class