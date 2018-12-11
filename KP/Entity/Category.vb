Namespace Entity
    Public Class Category

        Private m_categoryid As String
        Public Property Category_ID() As String
            Get
                Return m_categoryid
            End Get
            Set(ByVal value As String)

                If value = "" Then
                    Throw New Exception("Masukkan Category ID")
                End If
                m_categoryid = value
            End Set
        End Property


        Private m_categoryname As String
        Public Property Category_Name() As String
            Get
                Return m_categoryname
            End Get
            Set(ByVal value As String)

                If value = "" Then
                    Throw New Exception("Masukkan Category Name")
                End If
                m_categoryname = value
            End Set
        End Property

    End Class
End Namespace

