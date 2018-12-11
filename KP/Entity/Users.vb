Namespace Entity
    Public Class Users

        Private m_username As String
        Public Property Username() As String
            Get
                Return m_username
            End Get
            Set(ByVal value As String)
                If value = "" Then
                    Throw New Exception("Masukkan username")
                End If
                m_username = value
            End Set
        End Property

        Private m_password As String
        Public Property Password() As String
            Get
                Return m_password
            End Get

            Set(ByVal value As String)
                If value = "" Then
                    Throw New Exception("Masukkan Password")
                End If
                m_password = value
            End Set
        End Property

        Private m_firstname As String
        Public Property First_Name() As String
            Get
                Return m_firstname
            End Get
            Set(ByVal value As String)
                If value = "" Then
                    Throw New Exception("Masukkan First Name")
                End If
                m_firstname = value
            End Set
        End Property

        Public Property Last_Name() As String

        Public Property Role As New Entity.Role

        Public Property Actived() As Boolean

    End Class
End Namespace

