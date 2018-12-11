Namespace Entity
    Public Class Stock

        Private m_stockid As String
        Public Property Stock_ID() As String
            Get
                Return m_stockid
            End Get
            Set(ByVal value As String)
                If value = "" Then
                    Throw New Exception("Masukkan Stock ID")
                End If
                m_stockid = value
            End Set
        End Property

        Private m_tanggal As String
        Public Property Tanggal() As String

        Private m_stockname As String
        Public Property Stock_Name() As String
            Get
                Return m_stockname
            End Get
            Set(ByVal value As String)
                If value = "" Then
                    Throw New Exception("Masukkan Stock Name")
                End If
                m_stockname = value
            End Set
        End Property

        Private m_pricebuy As Decimal
        Public Property Price_Buy() As Decimal

        Private m_pricesell As Decimal
        Public Property Price_Sell() As Decimal

        Private m_stockitem As String
        Public Property Stock_Item() As String

        Private m_categoryname As String
        Public Property Category_Name() As String
            Get
                Return m_categoryname
            End Get
            Set(ByVal value As String)
                If value = "" Then
                    Throw New Exception("Pilih Category")
                End If
                m_categoryname = value
            End Set
        End Property


    End Class
End Namespace

