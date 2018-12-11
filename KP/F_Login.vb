Public Class F_Login

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try
            Dim AccessUser As New AccessData.AccessUser
            Dim user As New Entity.Users
            user.Username = txtUser.Text
            user.Password = txtPassword.Text

            Dim list As List(Of Entity.Users) = AccessUser.Login(txtUser.Text)
            'jika isi list kosong
            If list.Count = 0 Then
                MsgBox("Username Salah", MsgBoxStyle.Information, "KP")
                txtUser.Focus()
                txtUser.SelectAll()
                Exit Sub
            End If


            UserName = list.First.Username
            Password = list.First.Password
            If txtPassword.Text <> Password Then
                MsgBox("Password Salah", MsgBoxStyle.Information, "KP")
                txtPassword.Focus()
                txtPassword.SelectAll()
                Exit Sub
            End If

            If list.First.Actived = False Then
                MsgBox("User sudah tidak aktif", MsgBoxStyle.Information, "KP")
                txtUser.Focus()
                txtUser.SelectAll()
                Exit Sub
            End If
            RoleID = list.First.Role.RoleID
            Password = list.First.Password

            Me.Close()
            Me.Dispose()
            Dim f_utama As New F_Main
            f_utama.ToolName.Text = list.First.First_Name & If(list.First.Last_Name = "", "", " " & list.First.Last_Name)
            f_utama.ToolRole.Text = list.First.Role.RoleName
            f_utama.ToolTime.Text = Now.Date
            f_utama.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "KP")
        End Try

    End Sub

    Private Sub txtPassword_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub F_Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class