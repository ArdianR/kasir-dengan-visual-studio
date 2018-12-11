Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class F_Trans

#Region "Deklarasi"
    Protected AccessTrans As New AccessData.AccessTrans
    Dim columns As String() = {}
    Dim filenaming As String
#End Region

    Dim scAutoComplete As New AutoCompleteStringCollection

#Region "Process"

    Private Function TransNo() As String
        Dim TransList As New List(Of Entity.Trans)
        KPModule.FillListWithoutParam(TransList, columns, "usp_selectTranstop1", GetType(Entity.Trans))
        If TransList.Count = 0 Then
            txtID.Text = "0000001"
        Else
            txtID.Text = Format(Val(CInt(TransList.First.TransNo) + 1), "0000000")
        End If
        Return txtID.Text
    End Function

    Private Sub Clear()
        Dim C As Control
        Dim T As TextBox
        For Each C In Me.Controls
            If TypeOf C Is TextBox Then
                T = CType(C, TextBox)
                If UCase(T.Name) <> UCase("txtID") Then
                    T.Text = ""
                End If
            End If
        Next
        txtItem.Text = ""
        txtTotal.Text = ""
        txtDibayar.Text = ""
        txtKembali.Text = ""
        txtTotalbeli.Text = ""
        DtDate.Text = Now
    End Sub

    Sub ColumnsAdd()
        DgView.Columns.Add("Stock_Name", "Nama Barang")
        DgView.Columns.Add("Stock_id", "Kode Barang")
        DgView.Columns.Add("Price_Buy", "Harga Beli")
        DgView.Columns.Add("Price_Sell", "Harga Jual")
        DgView.Columns.Add("Total_Item", "Jumlah Jual")
        DgView.Columns.Add("Total_Beli", "Total Beli")
        DgView.Columns.Add("Total_Jual", "Total Jual")
        FormatColumns()
    End Sub

    Sub FormatColumns()
        DgView.Columns(0).Width = 200
        DgView.Columns(1).Visible = False
        DgView.Columns(2).Visible = False
        DgView.Columns(3).Width = 200
        DgView.Columns("Price_Sell").ReadOnly = True
        DgView.Columns(4).Width = 200
        DgView.Columns(5).Visible = False
        DgView.Columns(6).Width = 200
        DgView.Columns("Total_Jual").ReadOnly = True

    End Sub

    Sub TotalItem()
        Dim HitungItem As Integer = 0
        For I As Integer = 0 To DgView.Rows.Count - 1
            HitungItem = HitungItem + Val(DgView.Rows(I).Cells(4).Value)
            txtItem.Text = HitungItem
        Next
    End Sub

    Sub TotalHargaBayar()
        Dim HitungHarga As Integer = 0
        For I As Integer = 0 To DgView.Rows.Count - 1
            HitungHarga = HitungHarga + Val(DgView.Rows(I).Cells(6).Value)
            txtTotal.Text = HitungHarga
        Next
    End Sub

    Sub TotalHargaBeli()
        Dim HitungHarga As Integer = 0
        For I As Integer = 0 To DgView.Rows.Count - 1
            HitungHarga = HitungHarga + Val(DgView.Rows(I).Cells(5).Value)
            txtTotalbeli.Text = HitungHarga
        Next
    End Sub

    Sub HapusBaris()
        On Error Resume Next
        'DgView.Rows.RemoveAt(DgView.CurrentCell.RowIndex)
        Dim baris As Integer = DgView.CurrentCell.RowIndex
        DgView.Rows(baris).Cells(0).Value = ""
        Chr(30)
    End Sub

    Sub simpan2()
        For baris As Integer = 0 To DgView.Rows.Count - 2

            On Error Resume Next

            'simpan ke tabel transaksi
            Dim simpanmaster As String = "Insert into T_Trans(transNo,tanggal,total_item,total_beli,total_jual,total_bayar,dibayar,kembali, total_dibeli) values " & _
            "('" & txtID.Text & "','" & DtDate.Text & "','" & txtItem.Text & "','" & DgView.Rows(baris).Cells(5).Value & "','" & DgView.Rows(baris).Cells(6).Value & "','" & txtTotal.Text & "','" & txtDibayar.Text & "','" & txtKembali.Text & "','" & txtTotalbeli.Text & "')"
            cmd = New OleDbCommand(simpanmaster, Conn)
            cmd.ExecuteNonQuery()


            'kurangi stok barang
            cmd = New OleDbCommand("select * from t_stock where stock_name='" & DgView.Rows(baris).Cells(0).Value & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                Dim kurangistok As String = "update t_stock set stock_item= '" & rd.Item(5) - DgView.Rows(baris).Cells(4).Value & "' where stock_name='" & DgView.Rows(baris).Cells(0).Value & "'"
                cmd = New OleDbCommand(kurangistok, Conn)
                cmd.ExecuteNonQuery()
            End If


            'simpan ke tabel detail
            Dim sqlsimpanDetail As String = "Insert into T_DetailJual (TransNo,Stock_Id,Stock_Name,price_buy, price_sell,Item_buy,buy_total,sell_total) values " & _
            "('" & txtID.Text & "','" & DgView.Rows(baris).Cells(1).Value & "','" & DgView.Rows(baris).Cells(0).Value & "','" & DgView.Rows(baris).Cells(2).Value & "','" & DgView.Rows(baris).Cells(3).Value & "','" & DgView.Rows(baris).Cells(4).Value & "','" & DgView.Rows(baris).Cells(5).Value & "','" & DgView.Rows(baris).Cells(6).Value & "')"
            cmd = New OleDbCommand(sqlsimpanDetail, Conn)
            cmd.ExecuteNonQuery()

        Next baris
    End Sub



#End Region


    Private Sub F_Transaction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Operate = "Add" Then
                Koneksi()
                TransNo()
                ColumnsAdd()
                txtTotalbeli.Visible = False

                'TODO: This line of code loads data into the 'OrdersDataSet.Orders' table. You can move, or remove it, as needed.
                'Me.OrdersTableAdapter.Fill(Me.OrdersDataSet.Orders)


                Dim conn As OleDbConnection
                Dim strConn As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\KP.accdb"


                conn = New OleDbConnection(strConn)

                Dim OrdersTable As New DataTable
                Dim ds As New DataSet
                ds.Tables.Add(OrdersTable)
                Dim OrdersDataAdapter As New OleDbDataAdapter("SELECT stock_name FROM T_Stock", conn)

                OrdersDataAdapter.Fill(OrdersTable)
                DgView.DataSource = ds.Tables("stock_name")

                Dim cmd As New OleDbCommand("Select stock_name From T_Stock", conn)
                Dim dr As OleDbDataReader

                conn.Open()
                dr = cmd.ExecuteReader
                Do While dr.Read
                    scAutoComplete.Add(dr.GetString(0))
                Loop
                conn.Close()

            Else

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "KP")
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Operate = "Add" Then
            Clear()
            DgView.Columns.Clear()
            DgView.Focus()
            ColumnsAdd()
        Else
            Operate = Nothing
            Me.Close()
        End If
    End Sub

    Private Sub txtDibayar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDibayar.KeyPress
        If e.KeyChar = Chr(13) Then
            If Val(txtDibayar.Text) < Val(txtTotal.Text) Then
                MsgBox("Pembayaran kurang")
                txtKembali.Text = ""
                txtDibayar.Focus()
                Exit Sub
            ElseIf Val(txtDibayar.Text) = Val(txtTotal.Text) Then
                txtKembali.Text = 0
                btnSave.Focus()
            Else
                txtKembali.Text = Val(txtDibayar.Text) - Val(txtTotal.Text)
                btnSave.Focus()
            End If
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtItem.Text = "" Then
                MsgBox("Masukan Stock ID", MsgBoxStyle.Information, "KP")
                DgView.Focus()
            ElseIf txtDibayar.Text = "" Then
                MsgBox("Masukan Tunai Pembayaran", MsgBoxStyle.Information, "KP")
                txtDibayar.Focus()
                Exit Sub
            End If

            Dim mYes_No As String = MsgBox("Apakah kamu ingin menyimpan data ?", vbYesNo, "KP")
            If mYes_No = vbYes Then
                If Operate = "Add" Then
                    simpan2()
                    Clear()
                    TransNo()
                    DgView.Columns.Clear()
                    ColumnsAdd()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "KP")
        End Try
    End Sub

    Private Sub F_Transaction_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Operate = Nothing
    End Sub

    Private Sub DgView_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgView.EditingControlShowing
        If DgView.CurrentCell.ColumnIndex = 0 AndAlso TypeOf e.Control Is TextBox Then
            With DirectCast(e.Control, TextBox)
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .AutoCompleteCustomSource = scAutoComplete
            End With
        End If
    End Sub

    Private Sub DgView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgView.KeyDown
        If e.KeyCode = Keys.Up Then
            DgView.CurrentCell = DgView.Rows(0).Cells(3)
        End If
    End Sub

    Private Sub DgView_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DgView.KeyPress
        On Error Resume Next
        If e.KeyChar = Chr(27) Then
            DgView.Rows.RemoveAt(DgView.CurrentCell.RowIndex)
            TotalItem()
            TotalHargaBayar()
            TotalHargaBeli()
            txtDibayar.Clear()
            txtKembali.Text = ""
        End If
    End Sub

    Private Sub DgView_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgView.CellEndEdit
        If e.ColumnIndex = 0 Then
            cmd = New OleDbCommand("select * from T_Stock where stock_Name='" & DgView.Rows(e.RowIndex).Cells(0).Value & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                DgView.Rows(e.RowIndex).Cells(1).Value = rd.Item(0)
                DgView.Rows(e.RowIndex).Cells(2).Value = rd.Item(3)
                DgView.Rows(e.RowIndex).Cells(3).Value = rd.Item(4)
                DgView.Rows(e.RowIndex).Cells(4).Value = 1
                DgView.Rows(e.RowIndex).Cells(5).Value = DgView.Rows(e.RowIndex).Cells(2).Value * DgView.Rows(e.RowIndex).Cells(4).Value
                DgView.Rows(e.RowIndex).Cells(6).Value = DgView.Rows(e.RowIndex).Cells(3).Value * DgView.Rows(e.RowIndex).Cells(4).Value
                TotalItem()
                TotalHargaBayar()
                TotalHargaBeli()
            Else
                MsgBox("Kode barang tidak terdaftar")
            End If
        End If

        If e.ColumnIndex = 4 Then
            cmd = New OleDbCommand("select * from T_Stock where stock_name='" & DgView.Rows(e.RowIndex).Cells(0).Value & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then

                DgView.Rows(e.RowIndex).Cells(5).Value = DgView.Rows(e.RowIndex).Cells(2).Value * DgView.Rows(e.RowIndex).Cells(4).Value
                DgView.Rows(e.RowIndex).Cells(6).Value = DgView.Rows(e.RowIndex).Cells(3).Value * DgView.Rows(e.RowIndex).Cells(4).Value
                TotalItem()
                TotalHargaBayar()
                TotalHargaBeli()
            Else
                DgView.Rows(e.RowIndex).Cells(5).Value = DgView.Rows(e.RowIndex).Cells(2).Value * DgView.Rows(e.RowIndex).Cells(4).Value
                DgView.Rows(e.RowIndex).Cells(6).Value = DgView.Rows(e.RowIndex).Cells(3).Value * DgView.Rows(e.RowIndex).Cells(4).Value
                TotalItem()
                TotalHargaBayar()
                TotalHargaBeli()
            End If

            DgView.CurrentCell = DgView.Rows(0).Cells(0)
        End If

    End Sub

End Class