Public Class F_UserBox

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If txtUsername.Text = "" Then
                MsgBox("Masukkan Username", MsgBoxStyle.Information, "DVD Rental")
                Exit Sub
            End If
            Dim RoleList As New List(Of Entity.Users)
            Dim Coltype As System.Data.OleDb.OleDbType() = {System.Data.OleDb.OleDbType.VarChar}
            Dim FieldName As String() = {"@username"}
            Dim Size As Integer() = {15}
            Dim Value As String() = {txtUsername.Text}
            Dim columns As String() = {"username"}
            KPModule.FillListWithParam(RoleList, columns, "usp_selectlogin", _
                                                             GetType(Entity.Users), FieldName, _
                                                             Coltype, Size, Value)
            If RoleList.Count = 0 Then
                MsgBox("Username Salah")
                Exit Sub
            End If
            Dim frm_User As New F_User
            frm_User.txtUser.Text = txtUsername.Text
            frm_User.ShowDialog()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DVD Rental")
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Operate = Nothing
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Operate = "Edit"
        Dim frm_HUser As New H_User
        frm_HUser.ShowDialog()
        txtUsername.Text = frm_HUser.txtSearch.Text
    End Sub
End Class