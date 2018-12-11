Imports System.Data.OleDb
Public Class F_FormAccess
    Dim AccessUser As New AccessData.AccessUser
    Dim columns As String() = {}


    Private Sub AddMenuToTree(ByVal YourNodeTree As TreeNode, ByVal YourToolStripMenuItem As ToolStripMenuItem)
        '//cek apakah toolstripmenuitem tsb mempunyai sub menuitem
        '//yang merupakan DropDownItem :
        If YourToolStripMenuItem.DropDownItems.Count > 0 Then
            '//jika ada sub menu item, iterate :
            For i As Int32 = 0 To YourToolStripMenuItem.DropDownItems.Count - 1
                '//jika sub menu itemnya bukan merupakan toolstripmenuitem (bisa saja
                '//merupakan toolstripseparator) maka item tsb tdk ditambahkan ke treeview :
                If Not (TypeOf YourToolStripMenuItem.DropDownItems(i) Is ToolStripMenuItem) Then Continue For
                Dim currentItem As ToolStripMenuItem = YourToolStripMenuItem.DropDownItems(i)
                Dim aNode As New TreeNode(Replace(currentItem.Text.ToString, "&", ""))
                aNode.Tag = currentItem.Tag.ToString
                YourNodeTree.Nodes.Add(aNode)
                '//cek jika ada sub menu item lagi dengan method recursive
                AddMenuToTree(aNode, currentItem)
            Next
        End If
    End Sub

    Private Sub PopulateToolStripMenuItem(ByVal YourMainMenuStrip As MenuStrip)
        '  daFormActions.Fill(dsFormActions, "formActions")
        '//iterate toolstripmenuitem yang ada di MainMenuStrip :
        For Each aItem As ToolStripMenuItem In YourMainMenuStrip.Items
            '//buat node baru utk ditambahkan ke treeview node :
            Dim aNode As New TreeNode(Replace(aItem.Text.ToString, "&", ""))
            aNode.Tag = aItem.Tag.ToString
            tvUserRights.Nodes.Add(aNode)
            '//tambahkan node baru ke treeview jika
            '//node tersebut memiliki node child (DropDownItem):
            AddMenuToTree(aNode, aItem)
        Next
        tvUserRights.ExpandAll()
        tvUserRights.SelectedNode = tvUserRights.Nodes(0)
    End Sub

    Private Sub CheckedTreeNode(ByVal Checked As Boolean)
        Dim IEnum As IEnumerator = Me.tvUserRights.Nodes.GetEnumerator
        While IEnum.MoveNext
            Dim aNode As TreeNode = DirectCast(IEnum.Current, TreeNode)
            aNode.Checked = Checked
            AddRecursiveNode(aNode, Checked)
        End While
    End Sub

    Private Sub AddRecursiveNode(ByVal NodeRef As TreeNode, ByVal Checked As Boolean)
        For Each aNode As TreeNode In NodeRef.Nodes
            aNode.Checked = Checked
            AddRecursiveNode(aNode, Checked)
        Next
    End Sub

    Private Sub PopulateRolesToListBox()
        lstRoles.Items.Clear()
        Dim RoleList As New List(Of Entity.Role)
        KPModule.FillListWithoutParam(RoleList, columns, "usp_SelectRole", _
                                                         GetType(Entity.Role))
        For Each items In RoleList
            lstRoles.Items.Add(items.RoleID & " > " & items.RoleName)
        Next
    End Sub

    Private Sub PopulateRoleDetails(ByVal RoleIDs As String)

        Dim mydata As New DataSet
        Using connect As New OleDbConnection(My.Settings.KPConnect)
            Using ObjCommand As New OleDbCommand("usp_SelectMenuRole", connect)
                ObjCommand.CommandType = CommandType.StoredProcedure
                ObjCommand.Parameters.Add("@RoleID", OleDbType.Integer).Value = RoleIDs
                Using objDataAdapter As New OleDbDataAdapter
                    objDataAdapter.SelectCommand = ObjCommand
                    objDataAdapter.Fill(mydata, "data")
                End Using
            End Using
        End Using

        If mydata.Tables("data").Rows.Count = 0 Then
            For Each aNode As TreeNode In tvUserRights.Nodes
                aNode.Checked = False
                AddRecursiveNode(aNode, False)
            Next
        Else
            PopulateItemCheckedToTheTree(mydata.Tables("data").DefaultView)
        End If
    End Sub

    Private Sub PopulateItemCheckedToTheTree(ByVal YourView As DataView)
        Dim IEnum As IEnumerator = Me.tvUserRights.Nodes.GetEnumerator
        While IEnum.MoveNext
            Dim aNode As TreeNode = DirectCast(IEnum.Current, TreeNode)
            YourView.RowFilter = "MenuID = '" & aNode.Tag.ToString & "'"
            If YourView.Count > 0 Then
                aNode.Checked = True
            Else
                aNode.Checked = False
            End If
            AddRecursiveNodeTree(YourView, aNode)
        End While
    End Sub

    Private Sub AddRecursiveNodeTree(ByVal YourView As DataView, ByVal NodeRef As TreeNode)
        For Each aNode As TreeNode In NodeRef.Nodes
            YourView.RowFilter = "MenuID = '" & aNode.Tag.ToString & "'"
            If YourView.Count > 0 Then
                aNode.Checked = True
            Else
                aNode.Checked = False
            End If
            AddRecursiveNodeTree(YourView, aNode)
        Next
    End Sub

    Private Sub InsertItemCheckedOnTheTreeToDatabase(ByVal RoleID As String, ByVal RoleName As String)
        Dim IEnum As IEnumerator = Me.tvUserRights.Nodes.GetEnumerator
        While IEnum.MoveNext
            Dim aNode As TreeNode = DirectCast(IEnum.Current, TreeNode)
            '//insert ke tabel RoleDetails (RoleID, MenuName, FormAction, Tag) :
            If aNode.Checked Then
                Dim MenuRole As New Entity.MenuRole
                MenuRole.Role.RoleID = RoleID
                MenuRole.Menu.MenuID = aNode.Tag.ToString
                AccessUser.InsertRoleMenu(MenuRole)
                AddRecursiveTreeNode(RoleID, aNode)
            End If
        End While
    End Sub

    Private Sub AddRecursiveTreeNode(ByVal RoleID As String, ByVal NodeRef As TreeNode)
        For Each aNode As TreeNode In NodeRef.Nodes
            '//insert ke tabel RoleDetails (RoleID, MenuName, FormAction, Tag) :
            If aNode.Checked Then
                Dim MenuRole As New Entity.MenuRole
                MenuRole.Role.RoleID = RoleID
                MenuRole.Menu.MenuID = aNode.Tag.ToString
                AccessUser.InsertRoleMenu(MenuRole)
            End If
            AddRecursiveTreeNode(RoleID, aNode)
        Next
    End Sub




    Private Sub F_FormAccess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PopulateToolStripMenuItem(My.Forms.F_Main.MenuStrip1)
            PopulateRolesToListBox()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub CheckhedRadioButton(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUncheckedAll.CheckedChanged, rbCheckedAll.CheckedChanged
        Select Case sender.name.ToString.ToUpper
            Case "RBCHECKEDALL"
                CheckedTreeNode(True)
            Case "RBUNCHECKEDALL"
                CheckedTreeNode(False)
        End Select
    End Sub

    Private Sub lstRoles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRoles.SelectedIndexChanged
        Try
            If lstRoles.SelectedIndex <> -1 Then
                Dim arrItems As String() = KPModule.GetLeftRightItemFromControl(lstRoles.SelectedItem.ToString)
                PopulateRoleDetails(arrItems(0))
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "DVD Rental")
        End Try

    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If lstRoles.SelectedIndex = -1 Then
                MsgBox("Pilih dahulu RoleID yang akan diupdate dari List Roles", MsgBoxStyle.Information, "KP")
                Exit Sub
            Else
                Dim arrItems As String() = KPModule.GetLeftRightItemFromControl(lstRoles.SelectedItem.ToString)

                Dim mYes_No As String = MsgBox("Apakah kamu ingin menyimpan data ?", vbYesNo, "KP")
                If mYes_No = vbYes Then
                    Dim MenuRole As New Entity.MenuRole
                    MenuRole.Role.RoleID = arrItems(0)
                    AccessUser.DeleteRoleMenu(MenuRole)

                    InsertItemCheckedOnTheTreeToDatabase(arrItems(0), arrItems(1))
                    lstRoles.SelectedIndex = -1
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try




    End Sub


 
End Class