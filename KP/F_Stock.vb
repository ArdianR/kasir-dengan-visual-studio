Imports System.Data.OleDb
Public Class F_Stock

#Region "Deklarasi"
    Public Proses As String
    Protected AccessStock As New AccessData.AccessStock
    Dim columns As String() = {}
#End Region

    Private Sub Aktif_Inputan(ByVal Bol As Boolean, ByVal pros As String)
        Dim C As Control

        For Each C In Me.Controls
            If C.HasChildren Then
                For Each hChild As Control In C.Controls
                    If TypeOf hChild Is TextBox AndAlso UCase(hChild.Name) <> UCase("txtID") Then
                        hChild.Enabled = Bol
                        If UCase(pros) = "ADD" AndAlso UCase(hChild.Name) <> UCase("txtname") Then
                            hChild.Text = "0"
                            Cbcategory.SelectedIndex = 0
                        End If
                    End If
                    If TypeOf hChild Is TextBox AndAlso UCase(pros) = UCase("clear") Then
                        hChild.Text = ""
                        Cbcategory.SelectedIndex = 0
                    End If
                Next
            ElseIf TypeOf C Is Button AndAlso UCase(C.Name) = UCase("btnsave") Then
                C.Enabled = Bol
                Cbcategory.SelectedIndex = 0
            End If
        Next
        Cbcategory.SelectedIndex = 0
    End Sub

    Private Function IDNo() As String

        Dim StockList As New List(Of Entity.Stock)

        KPModule.FillListWithoutParam(StockList, columns, "usp_SelectStockTop1", GetType(Entity.Stock))
        If StockList.Count = 0 Then
            txtID.Text = "S001"
        Else

            txtID.Text = "S" & Format(Val(CInt(Microsoft.VisualBasic.Right(StockList.First.Stock_ID,
                                                                           StockList.First.Stock_ID.Length - 1)) + 1), "000")

        End If
        Return txtID.Text
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Proses = Nothing
        Aktif_Inputan(False, "clear")
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Proses = "add"
            Aktif_Inputan(True, Proses)
            IDNo()
            txtName.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub SortCbCategory()
        Dim CategoryList As New List(Of Entity.Category) From {{"G00", "- Choice -"}}
        KPModule.FillListWithoutParam(CategoryList, columns, "usp_SelectCategory", _
        GetType(Entity.Category))
        Cbcategory.DataSource = CategoryList
        Cbcategory.DisplayMember = "Category_Name"
        Cbcategory.ValueMember = "Category_ID"
    End Sub

    Private Sub F_Group_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SortCbCategory()
            Cbcategory.SelectedIndex = 0
            DtDate.Text = Now
            Aktif_Inputan(False, "")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Try
            Proses = "find"
            Dim frm_Hstock As New H_Stock
            frm_Hstock.ShowDialog()
            txtID.Text = frm_Hstock.ID
            txtName.Text = frm_Hstock.NAMA
            txtPrice.Text = frm_Hstock.PRICEBUY
            txtSell.Text = frm_Hstock.PRICESELL
            txtStockItem.Text = frm_Hstock.ITEM
            Cbcategory.Text = frm_Hstock.CATEGORY

            If txtID.Text <> "" Then

                Dim StockList As New List(Of Entity.Stock)

                KPModule.FillListWithoutParam(StockList, columns, "usp_selectstock", GetType(Entity.Stock))

                Dim stock = (From grp In StockList
                     Where grp.Stock_ID.Equals(txtID.Text)).Single
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub txtPrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrice.KeyPress
        Try
            If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
                e.Handled() = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim Stock As New Entity.Stock With {.Stock_ID = txtID.Text, .Tanggal = DtDate.Text, .Stock_Name = txtName.Text,
                                                .Price_Buy = txtPrice.Text, .Price_Sell = txtSell.Text, .Stock_Item = txtStockItem.Text,
                                                .Category_Name = Cbcategory.Text}

            Dim mYes_No As String = MsgBox("Apakah kamu ingin menyimpan data ?", vbYesNo, "KP")
            If mYes_No = vbYes Then
                If UCase(Proses) = "ADD" Then
                    AccessStock.StockInsert(Stock)
                ElseIf UCase(Proses) = "EDIT" Then
                    AccessStock.StockUpdate(Stock)
                End If
                btnCancel.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If UCase(Proses) <> UCase("find") Then
            MsgBox("Cari data terlebih dahulu", MsgBoxStyle.Information, "KP")

            Exit Sub
        End If
        Proses = "edit"
        Aktif_Inputan(True, "")
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If UCase(Proses) <> UCase("find") Then
            MsgBox("Cari data terlebih dahulu", MsgBoxStyle.Information, "KP")
            Exit Sub
        End If
        Dim Stock As New Entity.Stock With {.Stock_ID = txtID.Text}
        Dim mYes_No As String = MsgBox("Apakah kamu ingin menghapus data ?", vbYesNo, "KP")
        If mYes_No = vbYes Then
            AccessStock.StockDelete(Stock)
            btnCancel.PerformClick()
        End If
    End Sub

    Private Sub txtStockItem_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStockItem.KeyPress
        Try
            If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
                e.Handled() = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtSell_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSell.KeyPress
        Try
            If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
                e.Handled() = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class