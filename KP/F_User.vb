Public Class F_User
    Dim AccessUser As New AccessData.AccessUser
    Dim columns As String() = {}

    Private Sub SortRole()
        Dim RoleList As New List(Of Entity.Role) From {}
        KPModule.FillListWithoutParam(RoleList, columns, "usp_SelectRole", GetType(Entity.Role))
        CbRole.DataSource = RoleList
        CbRole.DisplayMember = "RoleName"
        CbRole.ValueMember = "RoleID"
    End Sub

    Private Sub Clear()
        Dim C As Control
        Dim T As TextBox
        For Each C In Me.GbDetail.Controls
            If TypeOf C Is TextBox Then
                T = CType(C, TextBox)
                T.Text = ""
            End If
        Next
        CbRole.SelectedIndex = 0
    End Sub

    Private Sub ViewUser()
        Dim list As List(Of Entity.Users) = AccessUser.Login(txtUser.Text)
        txtUser.Text = list.First.Username
        txtPassword.Text = list.First.Password
        txtFirst.Text = list.First.First_Name
        txtLast.Text = list.First.Last_Name
        CbRole.SelectedIndex = CbRole.FindStringExact(list.First.Role.RoleName)
        CbStatus.Checked = If(list.First.Actived = "True", True, False)
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If CbRole.SelectedIndex = 0 Then
                MsgBox("Pilih Role terlebih dahulu", MsgBoxStyle.Information, "DVD Rental")
                Exit Sub
            End If
            Dim User As New Entity.Users With {.Username = txtUser.Text, .Password = txtPassword.Text,
            .First_Name = txtFirst.Text, .Last_Name = txtLast.Text, .Role = New Entity.Role With {.RoleID = CbRole.SelectedValue},
                                               .Actived = If(CbStatus.Checked = True, True, False)}
         
            Dim mYes_No As String = MsgBox("Apakah kamu ingin menyimpan data ?", vbYesNo, "DVD Rental")
            If mYes_No = vbYes Then
                If Operate = "Add" Then
                    AccessUser.UserInsert(User)
                    Clear()
                Else
                    AccessUser.UserUpdate(User)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DVD Rental")
        End Try
        Me.Close()
    End Sub

    Private Sub F_User_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            SortRole()
            If Operate = "Add" Then
                CbStatus.Checked = True
                CbStatus.Visible = False
            Else
                CbStatus.Visible = True
                ViewUser()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DVD Rental")
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Operate = "Add" Then
            Clear()
        Else
            Operate = Nothing
            Me.Close()
        End If
    End Sub

    
End Class