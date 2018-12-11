Imports System.Data.OleDb
Public Class F_Main

#Region "Deklarasi"
    Dim TransList As New List(Of Entity.Trans)
#End Region

  
#Region "PopulateMenu"
    Private Sub PopulateRoleDetails()
        Dim mydata As New DataSet
        Using connect As New OleDbConnection(My.Settings.KPConnect)
            Using ObjCommand As New OleDbCommand("usp_SelectMenuRole", connect)
                ObjCommand.CommandType = CommandType.StoredProcedure
                ObjCommand.Parameters.Add("@RoleID", OleDbType.Integer).Value = RoleID
                Using objDataAdapter As New OleDbDataAdapter
                    objDataAdapter.SelectCommand = ObjCommand
                    objDataAdapter.Fill(mydata, "data")
                End Using
            End Using
        End Using
        CreateMenu(mydata.Tables("data").DefaultView)
    End Sub

    Private Sub CreateMenu(ByVal dtView As DataView)
        Dim Num As IEnumerator = MenuStrip1.Items.GetEnumerator
        While Num.MoveNext
            Dim ToolMenu As ToolStripMenuItem = DirectCast(Num.Current, ToolStripMenuItem)
            dtView.RowFilter = "MenuID = '" & ToolMenu.Tag.ToString & "'"
            If dtView.Count > 0 Then
                ToolMenu.Visible = True
            Else
                ToolMenu.Visible = False
            End If
            CreateMenuItem(dtView, ToolMenu)
        End While
    End Sub

    Private Sub CreateMenuItem(ByVal dtView As DataView, ByVal ToolMenu As ToolStripMenuItem)
        For i As Integer = 0 To ToolMenu.DropDownItems.Count - 1
            If Not (TypeOf ToolMenu.DropDownItems(i) Is ToolStripMenuItem) Then Continue For
            dtView.RowFilter = "MenuID = '" & ToolMenu.DropDownItems(i).Tag.ToString & "'"
            If dtView.Count > 0 Then
                ToolMenu.DropDownItems(i).Visible = True
            Else
                ToolMenu.DropDownItems(i).Visible = False
                ToolMenu.DropDownItems(i).Tag = ""
            End If
            CreateMenuItem(dtView, ToolMenu.DropDownItems(i))
        Next
    End Sub
#End Region


#Region "PopulateTree"
    Private Sub AddMenuToTree(ByVal YourNodeTree As TreeNode, ByVal YourToolStripMenuItem As ToolStripMenuItem)
        '//cek apakah toolstripmenuitem tsb mempunyai sub menuitem
        '//yang merupakan DropDownItem :
        If YourToolStripMenuItem.DropDownItems.Count > 0 Then
            '//jika ada sub menu item, iterate :
            For i As Int32 = 0 To YourToolStripMenuItem.DropDownItems.Count - 1
                '//jika sub menu itemnya bukan merupakan toolstripmenuitem (bisa saja
                '//merupakan toolstripseparator) maka item tsb tdk ditambahkan ke treeview :
                If Not (TypeOf YourToolStripMenuItem.DropDownItems(i) Is ToolStripMenuItem) OrElse
                    YourToolStripMenuItem.DropDownItems(i).Tag = "" Then Continue For


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

        '//iterate toolstripmenuitem yang ada di MainMenuStrip :
        For Each aItem As ToolStripMenuItem In YourMainMenuStrip.Items
            If aItem.Visible = False Then Continue For
            '//buat node baru utk ditambahkan ke treeview node :
            Dim aNode As New TreeNode(Replace(aItem.Text.ToString, "&", ""))
            aNode.Tag = aItem.Tag.ToString

            TvTransaction.Nodes.Add(aNode)
            '//tambahkan node baru ke treeview jika
            '//node tersebut memiliki node child (DropDownItem):
            AddMenuToTree(aNode, aItem)
        Next
        TvTransaction.ExpandAll()
        TvTransaction.SelectedNode = TvTransaction.Nodes(0)
    End Sub
#End Region


#Region "Transaction_List"
    Private Sub ListTrans()
        Try
            Dim columns As String() = {"tanggal", "TransNo", "Total_Item", "total_beli", "Total_Jual", "total_dibeli", "total_bayar", "dibayar", "kembali"}
            KPModule.FillListWithoutParam(TransList, columns, "usp_SelectTransList", GetType(Entity.Trans))

            FormatGridWithBothTableAndColumnStyles()
            DgView.DataSource = TransList
            txtSearch.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub FormatGridWithBothTableAndColumnStyles()
        Me.DgView.DefaultCellStyle.ForeColor = Color.Navy
        Me.DgView.RowsDefaultCellStyle.BackColor = Color.AliceBlue
        Me.DgView.GridColor = Color.Blue
        Me.DgView.BorderStyle = BorderStyle.Fixed3D
        Me.DgView.RowHeadersBorderStyle = BorderStyle.Fixed3D

        DgView.AutoGenerateColumns = False

        Dim TanggalColumn As New DataGridViewTextBoxColumn()
        TanggalColumn.DataPropertyName = "Tanggal"
        TanggalColumn.HeaderText = "Tanggal"
        TanggalColumn.Width = 150

        Dim TransColumn As New DataGridViewTextBoxColumn()
        TransColumn.DataPropertyName = "TransNo"
        TransColumn.HeaderText = "Transaction No"
        TransColumn.Width = 175

        Dim ItemColumn As New DataGridViewTextBoxColumn()
        ItemColumn.DataPropertyName = "Total_Item"
        ItemColumn.HeaderText = "Item"
        ItemColumn.Width = 150

        Dim totalColumn As New DataGridViewTextBoxColumn()
        totalColumn.DataPropertyName = "Total_Bayar"
        totalColumn.HeaderText = "Total"
        totalColumn.Width = 175

        Dim DibayarColumn As New DataGridViewTextBoxColumn()
        DibayarColumn.DataPropertyName = "Dibayar"
        DibayarColumn.HeaderText = "Tunai"
        DibayarColumn.Width = 175

        Dim KembaliColumn As New DataGridViewTextBoxColumn()
        KembaliColumn.DataPropertyName = "Kembali"
        KembaliColumn.HeaderText = "Kembali"
        KembaliColumn.Width = 175

        DgView.Columns.Add(TransColumn)
        DgView.Columns.Add(TanggalColumn)
        DgView.Columns.Add(ItemColumn)
        DgView.Columns.Add(totalColumn)
        DgView.Columns.Add(DibayarColumn)
        DgView.Columns.Add(KembaliColumn)
    End Sub

#End Region

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub F_Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Dispose()
        My.Forms.F_Login.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Try

            Dim frm_Change As New F_Change
            frm_Change.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AddToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem2.Click
        Try
            Operate = "Add"
            Dim frm_user As New F_User
            frm_user.ShowDialog()
            Operate = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub EditToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem2.Click
        Try
            Dim frm_UserBox As New F_UserBox
            frm_UserBox.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub UserListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserListToolStripMenuItem.Click
        Try
            Dim frm_HUser As New H_User
            frm_HUser.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub F_Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            PopulateRoleDetails()
            PopulateToolStripMenuItem(MenuStrip1)
            ListTrans()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try

    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        Try
          
            Dim query = (From a In TransList Where a.TransNo.Contains(txtSearch.Text)).ToList
           
            DgView.DataSource = query

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub TvTransaction_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TvTransaction.DoubleClick
        Try
            For Each aItem As ToolStripMenuItem In MenuStrip1.Items
                Dim str As String = TvTransaction.SelectedNode.Tag.ToString
                If aItem.DropDownItems.Count > 0 Then
                    For i As Int32 = 0 To aItem.DropDownItems.Count - 1
                        If Not (TypeOf aItem.DropDownItems(i) Is ToolStripMenuItem) Then Continue For
                        Dim currentItem As ToolStripMenuItem = aItem.DropDownItems(i)
                        If str = currentItem.Tag.ToString Then
                            currentItem.PerformClick()
                            Exit Sub
                        Else
                            If currentItem.DropDownItems.Count > 0 Then
                                For x As Int32 = 0 To currentItem.DropDownItems.Count - 1
                                    If Not (TypeOf currentItem.DropDownItems(x) Is ToolStripMenuItem) Then Continue For
                                    Dim currentItem2 As ToolStripMenuItem = currentItem.DropDownItems(x)
                                    If str = currentItem2.Tag.ToString Then
                                        currentItem2.PerformClick()
                                        Exit Sub
                                    End If
                                Next
                            End If
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub FormAccessToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim frm_access As New F_FormAccess
            frm_access.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Try
            F_About.Show()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim frm_stock As New F_Stock
            frm_stock.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Try
            Operate = "Add"
            Dim frm_Trans As New F_Trans
            frm_Trans.ShowDialog()
            Operate = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Try
            Dim frm_HTransRetur As New F_TransRetur
            frm_HTransRetur.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListTransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListTransactionToolStripMenuItem.Click
        Try
            Dim frm_HTrans As New H_Trans
            frm_HTrans.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub StockItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockItemToolStripMenuItem.Click
        Try
            Dim frm_Dreport As New R_StockReport
            frm_Dreport.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub ReturReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturReportToolStripMenuItem.Click
        Try
            Dim frm_Rreport As New R_ReturTrans
            frm_Rreport.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub TransactionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionReportToolStripMenuItem.Click
        Try
            Dim frm_Treport As New R_TransReport
            frm_Treport.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub FormAccessToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormAccessToolStripMenuItem1.Click
        Try
            Dim frm_access As New F_FormAccess
            frm_access.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub StockAddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockAddToolStripMenuItem.Click
        Try
            Dim frm_StockBox As New F_StockBox
            frm_StockBox.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub AddToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem1.Click
        Try
            Dim frm_Category As New F_Category
            frm_Category.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub ListCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListCategoryToolStripMenuItem.Click
        Dim frm_HGenre As New H_Category
        frm_HGenre.ShowDialog()
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Try
            Dim frm_stock As New F_Stock
            frm_stock.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub ListStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListStockToolStripMenuItem.Click
        Dim frm_Hstock As New H_Stock
        frm_Hstock.ShowDialog()
    End Sub

    Private Sub AddToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem3.Click
        Try
            Operate = "Add"
            Dim frm_Int As New F_Internal
            frm_Int.ShowDialog()
            Operate = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub InternalListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternalListToolStripMenuItem.Click
        Dim frm_Hint As New H_Internal
        frm_Hint.ShowDialog()
    End Sub

    
    Private Sub InternalReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternalReportToolStripMenuItem.Click
        Dim frm_Rint As New R_IntReport
        frm_Rint.ShowDialog()
    End Sub

    Private Sub KasirReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KasirReportToolStripMenuItem.Click
        Dim frm_Rint As New R_KasirReport
        frm_Rint.ShowDialog()
    End Sub

    Private Sub ListDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListDetailToolStripMenuItem.Click
        Try
            Dim frm_DTrans As New H_DTrans
            frm_DTrans.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
