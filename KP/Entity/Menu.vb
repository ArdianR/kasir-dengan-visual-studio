
Namespace Entity
    Public Class Menu
        Public Property MenuID As String
        Public Property MenuName As String
        Public Property MenuAction As String
    End Class

    Public Class MenuRole
        Public Property Role As New Entity.Role
        Public Property Menu As New Entity.Menu
    End Class
End Namespace

