Namespace Entity
    Public Class Internal
        Private m_no As String
        Public Property No() As String
            Get
                Return m_no
            End Get

            Set(ByVal value As String)
                If value = "" Then
                    Throw New Exception("Masukkan No Using")
                End If
                m_no = value
            End Set
        End Property

        Public Property Tanggal As String

        Public Property Tunai() As Decimal

        Private m_keterangan As String
        Public Property Keterangan() As String
            Get
                Return m_keterangan
            End Get
            Set(ByVal value As String)
                If value = "" Then
                    Throw New Exception("Masukan Keterangan")
                End If
                m_keterangan = value
            End Set
        End Property
    End Class
End Namespace