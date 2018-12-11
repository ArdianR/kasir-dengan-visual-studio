Imports System.Data.OleDb

Public Class F_TransRetur

#Region "Proses"

    Private Sub FormatGridWithBothTableAndColumnStyles1()
        Me.DGV.DefaultCellStyle.ForeColor = Color.Navy
        Me.DGV.RowsDefaultCellStyle.BackColor = Color.AliceBlue
        Me.DGV.GridColor = Color.Blue
        Me.DGV.BorderStyle = BorderStyle.Fixed3D
        Me.DGV.RowHeadersBorderStyle = BorderStyle.Fixed3D

        DGV.AutoGenerateColumns = False

        Dim StockIDColumn As New DataGridViewTextBoxColumn()
        StockIDColumn.DataPropertyName = "Stock_Id"
        StockIDColumn.HeaderText = "Kode Barang"
        StockIDColumn.Visible = False

        Dim NameColumn As New DataGridViewTextBoxColumn()
        NameColumn.DataPropertyName = "Stock_name"
        NameColumn.HeaderText = "Nama Barang"
        NameColumn.Width = 200

        Dim PriceColumn As New DataGridViewTextBoxColumn()
        PriceColumn.DataPropertyName = "Price_Sell"
        PriceColumn.HeaderText = "Harga"
        PriceColumn.Width = 200

        Dim ItemColumn As New DataGridViewTextBoxColumn()
        ItemColumn.DataPropertyName = "Item_Buy"
        ItemColumn.HeaderText = "Jumlah"
        ItemColumn.Width = 200

        Dim SubTotalColumn As New DataGridViewTextBoxColumn()
        SubTotalColumn.DataPropertyName = "Sell_Total"
        SubTotalColumn.HeaderText = "Total"
        SubTotalColumn.Width = 200

        DGV.Columns.Add(StockIDColumn)
        DGV.Columns.Add(NameColumn)
        DGV.Columns.Add(PriceColumn)
        DGV.Columns.Add(ItemColumn)
        DGV.Columns.Add(SubTotalColumn)

    End Sub

    Private Sub FormatGridWithBothTableAndColumnStyles2()
        Me.DGV1.DefaultCellStyle.ForeColor = Color.Navy
        Me.DGV1.RowsDefaultCellStyle.BackColor = Color.AliceBlue
        Me.DGV1.GridColor = Color.Blue
        Me.DGV1.BorderStyle = BorderStyle.Fixed3D
        Me.DGV1.RowHeadersBorderStyle = BorderStyle.Fixed3D

        DGV1.AutoGenerateColumns = False

        Dim StockIDColumn As New DataGridViewTextBoxColumn()
        StockIDColumn.DataPropertyName = "kode"
        StockIDColumn.HeaderText = "Kode Barang"
        StockIDColumn.Visible = False

        Dim NameColumn As New DataGridViewTextBoxColumn()
        NameColumn.DataPropertyName = "nama"
        NameColumn.HeaderText = "Nama Barang"
        NameColumn.Width = 200

        Dim PriceColumn As New DataGridViewTextBoxColumn()
        PriceColumn.DataPropertyName = "harga"
        PriceColumn.HeaderText = "Harga"
        PriceColumn.Width = 200

        Dim ItemColumn As New DataGridViewTextBoxColumn()
        ItemColumn.DataPropertyName = "jumlah"
        ItemColumn.HeaderText = "Jumlah"
        ItemColumn.Width = 200

        Dim SubTotalColumn As New DataGridViewTextBoxColumn()
        SubTotalColumn.DataPropertyName = "SubTotal"
        SubTotalColumn.HeaderText = "Total"
        SubTotalColumn.Width = 200

        DGV1.Columns.Add(StockIDColumn)
        DGV1.Columns.Add(NameColumn)
        DGV1.Columns.Add(PriceColumn)
        DGV1.Columns.Add(ItemColumn)
        DGV1.Columns.Add(SubTotalColumn)

    End Sub

    Sub TampilData()
        da = New OleDbDataAdapter("select Stock_Id,Stock_Name,Price_Sell,Item_Buy,Sell_Total from T_DetailJual where TransNo='" & TFaktur.Text & "' ", Conn)
        ds = New DataSet
        da.Fill(ds, "Detail")
        DGV.DataSource = ds.Tables("Detail")
        DGV.ReadOnly = True
        cmd = New OleDbCommand("select Tanggal,Total_Item,Total_Bayar,Dibayar,Kembali from T_Trans where TransNo='" & TFaktur.Text & "'", Conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            TTanggal.Text = rd.GetValue(0)
            TItem.Text = rd.GetValue(1)
            TTotal.Text = rd.GetValue(2)
            TDibayar.Text = rd.GetValue(3)
            TKembali.Text = rd.GetValue(4)
        End If
    End Sub

    Sub Cariitem()

        cmd = New OleDbCommand("select sum(jumlah) as ketemu from t_temporer", Conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            TItemretur.Text = rd.GetValue(0)
        Else
            TItemretur.Text = 0
        End If
    End Sub

    Sub CariTotal()
        On Error Resume Next
        cmd = New OleDbCommand("select sum(subtotal) as ketemu from t_temporer", Conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            TTotalRetur.Text = rd.GetValue(0)
        Else
            TTotalRetur.Text = 0
        End If
    End Sub

    Sub Kosongkan()
        TKode.Text = ""
        TNama.Text = ""
        THarga.Text = ""
        TJumlah.Text = ""
        TSubtotal.Text = ""
        TNama.Focus()
    End Sub

    Sub Tampilkan()
        da = New OleDbDataAdapter("Select * from t_temporer", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "t_temporer")
        DGV.DataSource = (ds.Tables("t_temporer"))
        DGV.ReadOnly = True

    End Sub

    Sub Tampilkanretur()
        On Error Resume Next
        da = New OleDbDataAdapter("Select * from t_temporer", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "t_temporer")
        DGV1.DataSource = (ds.Tables("t_temporer"))
        DGV1.ReadOnly = True
    End Sub

    Sub HapusGridRetur()

        da = New OleDbDataAdapter("Delete * from t_temporer", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "t_temporer")
        DGV1.DataSource = (ds.Tables("t_temporer"))
    End Sub

    Sub HapusMaster()
        TTanggal.Clear()
        TItem.Text = ""
        TTotal.Text = ""
        TDibayar.Text = ""
        TKembali.Text = ""
    End Sub

    Sub HapusMasterretur()
        TItemretur.Text = ""
        TTotalRetur.Text = ""
        TDibayarRetur.Text = ""
        TKembaliRetur.Text = ""
    End Sub

    Sub HapusGrid()
        On Error Resume Next
        da = New OleDbDataAdapter("Delete * from t_temporer", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "t_temporer")
        DGV.DataSource = (ds.Tables("t_temporer"))
    End Sub

    Sub simpanretur()

        'simpan ke tabel retur
        Dim simpanretur As String = "Insert into T_retur (Transno,Tanggal,Item_retur,Total) values " & _
        "('" & TFaktur.Text & "','" & TTanggalRetur.Text & "','" & TItemretur.Text & "','" & TTotalRetur.Text & "')"
        cmd = New OleDbCommand(simpanretur, Conn)
        cmd.ExecuteNonQuery()

    End Sub

    Sub updateTrans()

        'update penjualan
        Dim editpenjualan As String = "update t_trans set total='" & TTotal.Text - TTotalRetur.Text & "', item='" & TItem.Text - TItemretur.Text & "' where transno='" & TFaktur.Text & "'"
        cmd = New OleDbCommand(editpenjualan, Conn)
        cmd.ExecuteNonQuery()

    End Sub

    Sub simpanDetailRetur()

        'baca tabel temporer
        da = New OleDbDataAdapter("select * from t_temporer", Conn)
        ds = New DataSet
        da.Fill(ds)
        DGV1.DataSource = ds.Tables(0)
        Dim TBL As DataTable = ds.Tables(0)
        For baris As Integer = 0 To TBL.Rows.Count - 1

            'simpan ke tabel detail
            Dim sqlsimpan As String = "Insert into t_detailretur(transno,stock_id,stock_name,price,item_retur,subtotal) values " & _
            "('" & TFaktur.Text & "','" & TBL.Rows(baris)(0) & "','" & TBL.Rows(baris)(1) & "','" & TBL.Rows(baris)(2) & "','" & TBL.Rows(baris)(3) & "','" & TBL.Rows(baris)(4) & "')"
            cmd = New OleDbCommand(sqlsimpan, Conn)
            cmd.ExecuteNonQuery()


        Next baris

    End Sub

    Sub updatedetail()
        'baca tabel temporer
        da = New OleDbDataAdapter("select * from t_temporer", Conn)
        ds = New DataSet
        da.Fill(ds)
        DGV1.DataSource = ds.Tables(0)
        Dim TBL As DataTable = ds.Tables(0)
        For baris As Integer = 0 To TBL.Rows.Count - 1

            'edit detailjual
            cmd = New OleDbCommand("select * from t_detailjual where transno='" & TFaktur.Text & "' and stock_id='" & TBL.Rows(baris)(0) & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                Dim editdetail As String = "update t_detailjual set item='" & rd.Item(5) - TBL.Rows(baris)(3) & "' where transno='" & TFaktur.Text & "' and stock_id='" & TBL.Rows(baris)(0) & "'"
                cmd = New OleDbCommand(editdetail, Conn)
                cmd.ExecuteNonQuery()
            End If

        Next baris
    End Sub

    Sub updatestock()

        'baca tabel temporer
        da = New OleDbDataAdapter("select * from t_temporer", Conn)
        ds = New DataSet
        da.Fill(ds)
        DGV1.DataSource = ds.Tables(0)
        Dim TBL As DataTable = ds.Tables(0)
        For baris As Integer = 0 To TBL.Rows.Count - 1

            'tambahstok barang
            cmd = New OleDbCommand("select * from t_stock where stock_id='" & TBL.Rows(baris)(0) & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                Dim tambahstok As String = "update t_stock set stock_item= '" & rd.GetValue(5) + TBL.Rows(baris)(3) & "' where stock_id='" & TBL.Rows(baris)(0) & "'"
                cmd = New OleDbCommand(tambahstok, Conn)
                cmd.ExecuteNonQuery()
            End If

        Next baris

    End Sub

#End Region

    Private Sub TFaktur_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TFaktur.KeyPress
        If e.KeyChar = Chr(13) Then
            If TFaktur.Text = "" Then

                Operate = "Edit"
                Dim frm_HTrans As New H_Trans
                frm_HTrans.ShowDialog()
                TFaktur.Text = frm_HTrans.txtSearch.Text
            Else
                cmd = New OleDbCommand("select * from T_Trans where TransNo='" & TFaktur.Text & "'", Conn)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    TampilData()
                    TNama.Focus()
                Else
                    MsgBox("Nomor faktur tidak valid")
                    TFaktur.Focus()
                End If
            End If
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub

    Private Sub Retur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label16.Visible = False
        TKode.Visible = False
        Koneksi()
        TTanggalRetur.Text = Today
        FormatGridWithBothTableAndColumnStyles1()
        FormatGridWithBothTableAndColumnStyles2()

    End Sub

    Private Sub TKode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TKode.KeyPress
        If e.KeyChar = Chr(13) Then
            If TKode.Text = "" Then
                'DaftarBarang.Show()
                MsgBox("kode barang tiadk terdaftar")
            Else
                cmd = New OleDbCommand("Select * from t_detailjual where stock_id='" & TKode.Text & "' and transno='" & TFaktur.Text & "'", Conn)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    TNama.Text = rd.GetString(3)
                    THarga.Text = rd.GetValue(5)
                    TJumlah.Text = rd.GetValue(6)
                    TJumlah.Focus()
                Else
                    MsgBox("Kode barang tidak terdaftar di faktur " & TFaktur.Text & "")
                    TKode.Text = ""
                    TKode.Focus()
                End If
            End If
        End If

        If e.KeyChar = Chr(27) Then
            cmd = New OleDbCommand("select * from t_temporer where kode='" & TKode.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                Dim sqlhapus As String = "delete * from t_temporer where kode='" & TKode.Text & "'"
                cmd = New OleDbCommand(sqlhapus, Conn)
                cmd.ExecuteNonQuery()

                CariTotal()
                Cariitem()
                TKode.Text = ""
            Else
                MsgBox("Kode tidak ada dalam transaksi")
                TKode.Focus()
            End If
        End If
        If e.KeyChar = Chr(9) Then TDibayar.Focus()
    End Sub

    Private Sub TJumlah_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TJumlah.KeyPress
        If e.KeyChar = Chr(13) Then
            cmd = New OleDbCommand("select * from t_detailjual where stock_name='" & TNama.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                TSubtotal.Text = THarga.Text * TJumlah.Text
                Dim sqlsimpan As String = "Insert into t_temporer (kode,nama,harga,jumlah,subtotal) values " & _
                "('" & TKode.Text & "','" & TNama.Text & "','" & THarga.Text & "','" & TJumlah.Text & "','" & TSubtotal.Text & "')"
                cmd = New OleDbCommand(sqlsimpan, Conn)
                cmd.ExecuteNonQuery()

                Tampilkanretur()
                CariTotal()
                Cariitem()
                Kosongkan()
            End If
        End If

    End Sub

    Private Sub CmdTutup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdTutup.Click
        Me.Close()
    End Sub

    Private Sub TDibayarRetur_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TDibayarRetur.KeyPress
        If e.KeyChar = Chr(13) Then
            If Val(TDibayarRetur.Text) < Val(TTotalRetur.Text) Then
                MsgBox("Pembayaran kurang")
                TKembaliRetur.Text = ""
                TDibayarRetur.Focus()
                Exit Sub
            ElseIf Val(TDibayarRetur.Text) = Val(TTotalRetur.Text) Then
                TKembaliRetur.Text = 0
                CmdSimpan.Focus()
            Else
                TKembaliRetur.Text = Val(TDibayarRetur.Text) - Val(TTotalRetur.Text)
                CmdSimpan.Focus()
            End If
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True

    End Sub

    Private Sub CmdBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdBatal.Click
        HapusGrid()
        HapusGridRetur()
        HapusMaster()
        HapusMasterretur()
        Tampilkan()
    End Sub

    Private Sub CmdSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSimpan.Click
        If TTotalRetur.Text = "" Or TItemretur.Text = "" Then
            MsgBox("Data belum lengkap")
            Exit Sub
        End If

        simpanretur()
        simpanDetailRetur()
        updatestock()
        HapusGrid()
        HapusGridRetur()
        Tampilkanretur()
        Kosongkan()
        HapusMaster()
        HapusMasterretur()

    End Sub

    Private Sub TNama_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TNama.KeyPress
        If e.KeyChar = Chr(13) Then
            If TNama.Text = "" Then
                'DaftarBarang.Show()
                MsgBox("kode barang tiadk terdaftar")
            Else
                cmd = New OleDbCommand("Select * from t_detailjual where stock_Name='" & TNama.Text & "' and transno='" & TFaktur.Text & "'", Conn)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    TKode.Text = rd.GetString(2)
                    THarga.Text = rd.GetValue(5)
                    TJumlah.Text = rd.GetValue(6)
                    TJumlah.Focus()
                Else
                    MsgBox("Kode barang tidak terdaftar di faktur " & TFaktur.Text & "")
                    TNama.Text = ""
                    TNama.Focus()
                End If
            End If
        End If

        If e.KeyChar = Chr(27) Then
            cmd = New OleDbCommand("select * from t_temporer where nama='" & TNama.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                Dim sqlhapus As String = "delete * from t_temporer where nama='" & TNama.Text & "'"
                cmd = New OleDbCommand(sqlhapus, Conn)
                cmd.ExecuteNonQuery()

                CariTotal()
                Cariitem()
                TNama.Text = ""
            Else
                MsgBox("Kode tidak ada dalam transaksi")
                TNama.Focus()
            End If
        End If
        If e.KeyChar = Chr(9) Then TDibayar.Focus()
    End Sub

End Class