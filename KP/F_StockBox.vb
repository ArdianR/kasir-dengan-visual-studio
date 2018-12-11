Imports System.Data.OleDb

Public Class F_StockBox

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
                        If UCase(pros) = "Add" AndAlso UCase(hChild.Name) <> UCase("txtjumlahbaru") Then
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

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Try
            Proses = "find"
            Dim frm_Hstock As New H_Stock
            frm_Hstock.ShowDialog()
            txtID.Text = frm_Hstock.ID
            txtName.Text = frm_Hstock.NAMA
            txtJumlahLama.Text = frm_Hstock.ITEM
            If txtID.Text <> "" Then

                Dim StockList As New List(Of Entity.Stock)

                KPModule.FillListWithoutParam(StockList, columns, "usp_selectstock", GetType(Entity.Stock))

                Dim stock = (From grp In StockList
                     Where grp.Stock_ID.Equals(txtID.Text)).Single
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
        txtJumlahBaru.Focus()
    End Sub

    Private Sub btnCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Proses = Nothing
        Aktif_Inputan(False, "clear")
    End Sub

    Private Sub F_StockBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Aktif_Inputan(False, "")
        Koneksi()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtJumlahHasil.Text = "" Then
            MsgBox("Masukan Stock Barang")
            Exit Sub
        Else

            Dim mYes_No As String = MsgBox("Apakah kamu ingin menyimpan data ?", vbYesNo, "KP")
            If mYes_No = vbYes Then

                'update penjualan
                Dim editpenjualan As String = "update t_stock set Stock_item='" & txtJumlahHasil.Text & "' where Stock_id='" & txtID.Text & "'"
                cmd = New OleDbCommand(editpenjualan, Conn)
                cmd.ExecuteNonQuery()
            End If
            btnCancel.PerformClick()
        End If

    End Sub


    Private Sub txtJumlahBaru_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtJumlahBaru.KeyPress
        txtJumlahHasil.Text = Val(txtJumlahBaru.Text) + Val(txtJumlahLama.Text)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Proses = "add"
            Aktif_Inputan(True, Proses)
            txtJumlahBaru.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "KP")
        End Try
    End Sub
End Class