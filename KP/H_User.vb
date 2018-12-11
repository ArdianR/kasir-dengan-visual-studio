Public Class H_User


    Dim UserList As New List(Of Entity.Users)

    Private Sub FormatGridWithBothTableAndColumnStyles()
        Me.DgView.DefaultCellStyle.ForeColor = Color.Navy
        Me.DgView.RowsDefaultCellStyle.BackColor = Color.AliceBlue
        Me.DgView.GridColor = Color.Blue
        Me.DgView.BorderStyle = BorderStyle.Fixed3D
        Me.DgView.RowHeadersBorderStyle = BorderStyle.Fixed3D


        DgView.AutoGenerateColumns = False

        Dim UserColumn As New DataGridViewTextBoxColumn()
        UserColumn.DataPropertyName = "Username"
        UserColumn.HeaderText = "Username"
        UserColumn.Width = 100

        Dim FirstColumn As New DataGridViewTextBoxColumn()
        FirstColumn.DataPropertyName = "first_name"
        FirstColumn.HeaderText = "First Name"
        FirstColumn.Width = 125

        Dim LastColumn As New DataGridViewTextBoxColumn()
        LastColumn.DataPropertyName = "last_name"
        LastColumn.HeaderText = "Last Name"
        LastColumn.Width = 125

        Dim ActColumn As New DataGridViewTextBoxColumn()
        ActColumn.DataPropertyName = "actived"
        ActColumn.HeaderText = "Actived"
        ActColumn.Width = 150

        DgView.Columns.Add(UserColumn)
        DgView.Columns.Add(FirstColumn)
        DgView.Columns.Add(LastColumn)
        DgView.Columns.Add(ActColumn)
      
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        Try
            Dim query = (From a In UserList Where a.Username.Contains(txtSearch.Text) Select a).ToList
            DgView.DataSource = query
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "DVD Rental")
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


    Private Sub H_User_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Operate = Nothing
    End Sub

    Private Sub H_User_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim columns As String() = {"username", "first_name", "last_name", "actived"}
            KPModule.FillListWithoutParam(UserList, columns, "usp_SelectUserList", _
                                                             GetType(Entity.Users))
            FormatGridWithBothTableAndColumnStyles()
            DgView.DataSource = UserList
            txtSearch.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "DVD Rental")
        End Try
    End Sub
End Class