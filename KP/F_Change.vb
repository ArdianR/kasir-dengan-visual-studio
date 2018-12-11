Public Class F_Change

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            Dim AccessUser As New AccessData.AccessUser
            If txtOld.Text = "" Or txtNew.Text = "" Or txtConfirm.Text = "" Then
                MsgBox("Isi seluruh data terlebih dahulu", MsgBoxStyle.Information, "KP")
                Exit Sub
            End If
            If Password <> txtOld.Text Then
                MsgBox("Password lama salah", MsgBoxStyle.Information, "KP")
                Exit Sub
            ElseIf txtNew.Text <> txtConfirm.Text Then
                MsgBox("Password baru dan confirm password tidak sama", MsgBoxStyle.Information, "KP")
                Exit Sub
            End If
            Dim User As New Entity.Users With {.Password = txtNew.Text, .Username = UserName}

            AccessUser.ChangePassword(User)
            txtOld.Text = ""
            txtNew.Text = ""
            txtConfirm.Text = ""
            MsgBox("Ganti password sukses", MsgBoxStyle.Information, "KP")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "KP")
        End Try
    End Sub

  
    Private Sub F_Change_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class