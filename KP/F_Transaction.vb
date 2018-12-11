Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class F_Transaction

    Sub BersihkanText()
        txtTotal.Text = ""
        txtDibayar.Text = ""
        txtKembali.Text = ""
        Item.Text = ""
    End Sub

    Sub BuatKolomBaru()
        DgView.Columns.Add("Kode", "Kode")
        DgView.Columns.Add("Nama", "Nama Barang")
        DgView.Columns.Add("Harga", "Harga")
        DgView.Columns.Add("Jumlah", "Jumlah")
        DgView.Columns.Add("Total", "Total")
        Call AturLebarKolom()
    End Sub

    Sub AturLebarKolom()
        DgView.Columns(0).Width = 75
        DgView.Columns(1).Width = 150
        DgView.Columns(2).Width = 75
        DgView.Columns(3).Width = 75
        DgView.Columns(4).Width = 100
    End Sub

    Sub FakturOtomatis()
        cmd = New OleDbCommand("Select * from T_Penjualan where Faktur in (select max(Faktur) from T_Penjualan) order by Faktur desc", Conn)
        Dim urutan As String
        Dim hitung As Long
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            urutan = Format(Now, "yyMMdd") + "0001"
        Else
            If Microsoft.VisualBasic.Left(rd.GetString(0), 6) <> Format(Now, "yyMMdd") Then
                urutan = Format(Now, "yyMMdd") + "0001"
            Else
                hitung = rd.GetString(0) + 1
                urutan = Format(Now, "yyMMdd") + Microsoft.VisualBasic.Right("0000" & hitung, 4)
            End If
        End If
        Faktur.Text = urutan
    End Sub

    Private Sub Penjualan1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call FakturOtomatis()
        txtTanggal.Text = Today
    End Sub

    Private Sub Penjualan1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
        Call BuatKolomBaru()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Jam.Text = TimeOfDay

    End Sub

    Private Sub BTNBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call BersihkanText()
        DgView.Columns.Clear()
        Call BuatKolomBaru()
        DgView.Focus()
    End Sub

    Sub kena(ByVal myGrid As DataGrid)
        ' Set the current cell to cell 1, row 1.
        myGrid.CurrentCell = New DataGridCell(1, 1)
    End Sub


    Private Sub DGV_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.ColumnIndex = 0 Then
            cmd = New OleDbCommand("select * from barang where kode_barang='" & DgView.Rows(e.RowIndex).Cells(0).Value & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                DgView.Rows(e.RowIndex).Cells(1).Value = rd.Item(1)
                DgView.Rows(e.RowIndex).Cells(2).Value = rd.Item(3)
                DgView.Rows(e.RowIndex).Cells(3).Value = 1
                DgView.Rows(e.RowIndex).Cells(4).Value = DgView.Rows(e.RowIndex).Cells(2).Value * DgView.Rows(e.RowIndex).Cells(3).Value
                Call TotalItem()
                Call TotalHarga()
                'DGV.CurrentCell = DGV(3, 0)
                'DGV.Rows(e.RowIndex).Cells(3).Value = Keys.Up
            Else
                MsgBox("Kode barang tidak terdaftar")
            End If
        End If

        If e.ColumnIndex = 3 Then

            cmd = New OleDbCommand("select * from barang where kode_barang='" & DgView.Rows(e.RowIndex).Cells(0).Value & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                If DgView.Rows(e.RowIndex).Cells(3).Value > rd.Item(4) Then
                    MsgBox("Stok barang hanya ada " & rd.Item(4) & "")
                    DgView.Rows(e.RowIndex).Cells(3).Value = 1
                    DgView.Rows(e.RowIndex).Cells(4).Value = DgView.Rows(e.RowIndex).Cells(2).Value * DgView.Rows(e.RowIndex).Cells(3).Value
                    Call TotalItem()
                    Call TotalHarga()
                Else
                    DgView.Rows(e.RowIndex).Cells(4).Value = DgView.Rows(e.RowIndex).Cells(2).Value * DgView.Rows(e.RowIndex).Cells(3).Value
                    Call TotalItem()
                    Call TotalHarga()
                End If
            End If
            DgView.CurrentCell = DgView.Rows(0).Cells(0)
        End If

    End Sub

    Sub TotalItem()
        Dim HitungItem As Integer = 0
        For I As Integer = 0 To DgView.Rows.Count - 1
            HitungItem = HitungItem + Val(DgView.Rows(I).Cells(3).Value)
            Item.Text = HitungItem
        Next
    End Sub

    Sub TotalHarga()
        Dim HitungHarga As Integer = 0
        For I As Integer = 0 To DgView.Rows.Count - 1
            HitungHarga = HitungHarga + Val(DgView.Rows(I).Cells(4).Value)
            txtTotal.Text = HitungHarga
        Next
    End Sub

    Private Sub BTNTutup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Sub HapusBaris()
        On Error Resume Next
        'DGV.Rows.RemoveAt(DGV.CurrentCell.RowIndex)
        Dim baris As Integer = DgView.CurrentCell.RowIndex
        DgView.Rows(baris).Cells(0).Value = ""
        Chr(30)
    End Sub

    Private Sub DGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Up Then
            DgView.CurrentCell = DgView.Rows(0).Cells(3)
        End If
    End Sub


    Private Sub DGV_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        On Error Resume Next
        If e.KeyChar = Chr(27) Then
            DgView.Rows.RemoveAt(DgView.CurrentCell.RowIndex)
            Call TotalItem()
            Call TotalHarga()
            txtDibayar.Clear()
            txtKembali.Text = ""
        End If


    End Sub

    Private Sub Dibayar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            If Val(txtDibayar.Text) < Val(txtTotal.Text) Then
                MsgBox("Pembayaran kurang")
                txtKembali.Text = ""
                txtDibayar.Focus()
                Exit Sub
            ElseIf Val(txtDibayar.Text) = Val(txtTotal.Text) Then
                txtKembali.Text = 0
                BTNSimpan.Focus()
            Else
                txtKembali.Text = Val(txtDibayar.Text) - Val(txtTotal.Text)
                BTNSimpan.Focus()
            End If
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True

    End Sub

    Private Sub BTNSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtTotal.Text = "" Or txtDibayar.Text = "" Or txtKembali.Text = "" Or Item.Text = "" Then
            MsgBox("Data belum lengkap, tidak ada transaksi atau pembayaran masih kosong")
            Exit Sub
        End If

        'simpan ke tabel penjualan
        Dim simpanmaster As String = "Insert into penjualan(faktur,tanggal,item,total,dibayar,kembali,KodePtg) values " & _
        "('" & Faktur.Text & "','" & txtTanggal.Text & "','" & Item.Text & "','" & txtTotal.Text & "','" & txtDibayar.Text & "','" & txtKembali.Text & "','" & MenuUtama.Panel1.Text & "')"
        cmd = New OleDbCommand(simpanmaster, Conn)
        cmd.ExecuteNonQuery()

        For baris As Integer = 0 To DgView.Rows.Count - 2
            'simpan ke tabel detail
            Dim sqlsimpan As String = "Insert into detailjual (faktur,kode_Barang,nama_Barang,harga_Jual,jumlah,subtotal) values " & _
            "('" & Faktur.Text & "','" & DgView.Rows(baris).Cells(0).Value & "','" & DgView.Rows(baris).Cells(1).Value & "','" & DgView.Rows(baris).Cells(2).Value & "','" & DgView.Rows(baris).Cells(3).Value & "','" & DgView.Rows(baris).Cells(4).Value & "')"
            cmd = New OleDbCommand(sqlsimpan, Conn)
            cmd.ExecuteNonQuery()

            'kurangi stok barang
            cmd = New OleDbCommand("select * from barang where kode_barang='" & DgView.Rows(baris).Cells(0).Value & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                Dim kurangistok As String = "update barang set jumlah_barang= '" & rd.Item(4) - DgView.Rows(baris).Cells(3).Value & "' where kode_barang='" & DgView.Rows(baris).Cells(0).Value & "'"
                cmd = New OleDbCommand(kurangistok, Conn)
                cmd.ExecuteNonQuery()
            End If
        Next baris

        DgView.Columns.Clear()
        Call BuatKolomBaru()
        Call FakturOtomatis()
        Call BersihkanText()
    End Sub


End Class