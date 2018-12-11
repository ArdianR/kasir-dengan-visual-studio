Namespace Entity
    Public Class Role

        Private m_roleid As Int16
        Public Property RoleID() As Int16
            Get
                Return m_roleid
            End Get

            Set(ByVal value As Int16)
                If value.ToString = "" Then
                    Throw New Exception("Masukkan RoleID")
                End If
                m_roleid = value
            End Set
        End Property

        Public Property RoleName() As String

    End Class
End Namespace

