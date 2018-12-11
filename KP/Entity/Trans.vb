Namespace Entity
    Public Class Trans

        Private m_transno As String
        Public Property TransNo() As String
            Get
                Return m_transno
            End Get
            Set(ByVal value As String)
                If value = "" Then
                    Throw New Exception("Masukkan Transaksi No")
                End If
                m_transno = value
            End Set
        End Property

        Public Property Tanggal() As Date

        Public Property Total_Item() As Int32

        Public Property Total_Beli() As Decimal

        Public Property Total_Jual() As Decimal
          
        Public Property Total_Bayar() As Decimal

        Public Property Dibayar() As Decimal

        Public Property Kembali() As Decimal

    End Class
End Namespace