Public Class F_Paket

#Region "Deklarasi"
    Public Proses As String
    Protected AccessPaket As New AccessData.AccessPaket
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
                        End If
                    End If
                    If TypeOf hChild Is TextBox AndAlso UCase(pros) = UCase("clear") Then
                        hChild.Text = ""
                    End If
                Next
            ElseIf TypeOf C Is Button AndAlso UCase(C.Name) = UCase("btnsave") Then
                C.Enabled = Bol
            End If
        Next

    End Sub

    Private Function IDNo() As String

        Dim PaketList As New List(Of Entity.Paket)

        KPModule.FillListWithoutParam(PaketList, columns, "usp_SelectPaketTop1",
                                                         GetType(Entity.Paket))
        If PaketList.Count = 0 Then
            txtID.Text = "PK01"
        Else
            txtID.Text = "PK" & Format(Val(CInt(Microsoft.VisualBasic.Right(PaketList.First.Paket_ID,
                                                                           PaketList.First.Paket_ID.Length - 2)) + 1), "00")
        End If
        Return txtID.Text
    End Function

    Private Sub txtPrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrice.KeyPress
        Try
            If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
                e.Handled() = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtPrice_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrice.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnSave.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            btnCancel.PerformClick()
        End If
    End Sub

    Private Sub F_Paket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Aktif_Inputan(False, "")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim Paket As New Entity.Paket With {.Paket_ID = txtID.Text,
            .Paket_Name = txtName.Text, .Price = txtPrice.Text}
            Dim mYes_No As String = MsgBox("Apakah kamu ingin menyimpan data ?", vbYesNo, "KP")
            If mYes_No = vbYes Then
                If UCase(Proses) = "ADD" Then
                    AccessPaket.PaketInsert(Paket)
                ElseIf UCase(Proses) = "EDIT" Then
                    AccessPaket.PaketUpdate(Paket)
                End If
                btnCancel.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Try
            Proses = "find"
            Dim frm_HPaket As New H_Paket
            frm_HPaket.ShowDialog()
            txtID.Text = frm_HPaket.ID
            If txtID.Text <> "" Then
                Dim PaketList As New List(Of Entity.Paket)
                KPModule.FillListWithoutParam(PaketList, columns, "usp_selectpaket", _
                                                                GetType(Entity.Paket))
                Dim paket = (From grp In PaketList
                Where grp.Paket_ID.Equals(txtID.Text)
                ).Single
                txtName.Text = paket.Paket_Name
                txtPrice.Text = paket.Price
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
        Dim paket As New Entity.Paket With {.Paket_ID = txtID.Text}
        Dim mYes_No As String = MsgBox("Apakah kamu ingin menghapus data ?", vbYesNo, "KP")
        If mYes_No = vbYes Then
            AccessPaket.PaketDelete(paket)
            btnCancel.PerformClick()
        End If
    End Sub
End Class