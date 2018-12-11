
Namespace Entity
    Public Class Paket

        Private m_paketid As String
        Public Property Paket_ID() As String
            Get
                Return m_paketid
            End Get
            Set(ByVal value As String)
                If value = "" Then
                    Throw New Exception("Masukkan Paket ID")
                End If
                m_paketid = value
            End Set
        End Property


        Private m_paketname As String
        Public Property Paket_Name() As String
            Get
                Return m_paketname
            End Get
            Set(ByVal value As String)
                If value = "" Then
                    Throw New Exception("Masukkan Paket Name")
                End If
                m_paketname = value
            End Set
        End Property

        Public Property Price() As Decimal

    End Class
End Namespace
