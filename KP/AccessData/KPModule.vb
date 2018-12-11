Imports System.Data
Imports System.Data.OleDb
Imports System.Collections.Generic
Imports System.Runtime.CompilerServices

Module KPModule

    Public Operate, FormShow, UserName, Password, RoleID As String


#Region "Process"

    Public Function GetLeftRightItemFromControl(ByVal Teks As String) As String()
        '//cari item kiri dari teks
        Dim intPanjangString As Integer
        Dim intPosisiDash As Integer
        intPanjangString = Strings.Len(Teks)
        intPosisiDash = Teks.IndexOf(">")
        Dim strID As String = Trim(Strings.Left(Teks, intPosisiDash - 1))
        Dim strNama As String = Trim(Strings.Mid(Teks, intPosisiDash + 2, intPanjangString - intPosisiDash + 2))
        Dim arrString As String() = {strID, strNama}
        Return arrString
    End Function

    Public Sub AddParameter(ByVal Name As String, ByVal Type As OleDbType, _
      ByVal Size As Integer, ByVal Value As Object, ByVal myCommand As OleDbCommand)
        Try
            myCommand.Parameters.Add(Name, Type, Size).Value = Value
        Catch OleDbExceptionErr As OleDbException
            Throw New System.Exception(OleDbExceptionErr.Message, _
                OleDbExceptionErr.InnerException)
        End Try
    End Sub

#End Region

#Region "Fill"

    Private Sub Fill(Of T)(ByVal reader As IDataReader, ByVal list As IList(Of T), _
                                  ByVal type As Type, ByVal fields As String())

        Dim index As Integer = 0

        ' run the reader
        While reader.Read()
            ' create an instance of the type
            Dim item As T = DirectCast(Activator.CreateInstance(type), T)
            ' get all the properties of the type
            Dim properties As Reflection.PropertyInfo() = DirectCast(item.GetType(), Type).GetProperties()
            'Dim MyType As Type = type.GetType("Myproperty")

            If fields.Length <> 0 Then
                For j As Integer = 0 To fields.Length - 1

                    ' get the index of the property
                    index = FindProperyIndexByColumnName(fields(j), properties)
                    ' set the value of the property
                    '  properties(index).GetAccessors(
                    If index <> -1 Then
                        properties(index).SetValue(item,
                        If(reader(fields(j)).ToString = "", "",
                           reader(fields(j))), Nothing)
                    End If

                Next
            Else
                For i As Integer = 0 To reader.FieldCount - 1

                    index = FindProperyIndexByColumnName(reader.GetName(i), properties)
                    Dim a, b As String
                    a = reader(reader.GetName(i)).ToString
                    b = ""
                    If index <> -1 Then
                        properties(index).SetValue(item,
                        If(reader(reader.GetName(i)).ToString = "", "",
                           reader(reader.GetName(i))), Nothing)
                    End If


                Next
            End If

            ' add the item to the list
            list.Add(item)
        End While

    End Sub

    Private Function FindProperyIndexByColumnName(ByVal columnName As String, ByVal prop As Reflection.PropertyInfo()) As Integer
        Dim index As Integer = -1
        For i As Integer = 0 To prop.Length - 1

            If UCase(prop(i).Name) = UCase(columnName) Then
                index = i
                Exit For
            End If

        Next

        Return index

    End Function

    Public Sub FillListWithParam(Of T)(ByVal list As IList(Of T),
                                         ByVal fields As String(), ByVal Query As String,
                                         ByVal type As Type,
                                         ByVal Name As String(), ByVal OleType As OleDbType(),
                                         ByVal Size As Integer(), ByVal Value As Object())

        Using connect As New OleDbConnection(My.Settings.KPConnect)

            Using mycommand As OleDbCommand = New OleDbCommand(Query, connect)
                mycommand.CommandType = CommandType.StoredProcedure
                If Name.Length > 0 Then
                    For i = 0 To Name.Length - 1
                        KPModule.AddParameter(Name(i), OleType(i), Size(i), Value(i), mycommand)
                    Next
                End If
                connect.Open()
                Using reader As OleDbDataReader = mycommand.ExecuteReader()
                    Fill(reader, list, type, fields)
                End Using
            End Using
        End Using

    End Sub

    Public Sub FillListWithoutParam(Of T)(ByVal list As IList(Of T),
                                       ByVal fields As String(), ByVal Query As String,
                                       ByVal type As Type)

        Using connect As New OleDbConnection(My.Settings.KPConnect)

            Using mycommand As OleDbCommand = New OleDbCommand(Query, connect)
                mycommand.CommandType = CommandType.StoredProcedure

                connect.Open()
                Using reader As OleDbDataReader = mycommand.ExecuteReader()
                    Fill(reader, list, type, fields)
                End Using
            End Using
        End Using

    End Sub

#End Region



#Region "ExtesionMethod"

    <Extension()>
    Sub Add(ByVal CategoryList As List(Of Entity.Category), ByVal categoryid As String, ByVal categoryname As String)
        CategoryList.Add(New Entity.Category With {.Category_ID = categoryid, .Category_Name = categoryname})
    End Sub

    <Extension()>
    Sub Add(ByVal StockList As List(Of Entity.Stock), ByVal stockid As String, ByVal tanggal As Date, ByVal categoryname As String,
            ByVal stockname As String, ByVal pricebuy As Decimal, ByVal pricesell As Decimal, ByVal stock As String)
        StockList.Add(New Entity.Stock With {.Stock_ID = stockid, .Tanggal = tanggal, .Stock_Name = stockname, .Price_Buy = pricebuy,
                                             .Price_Sell = pricesell, .Stock_Item = stock, .Category_Name = categoryname})
    End Sub

    <Extension()>
    Sub Add(ByVal TransList As List(Of Entity.Trans), ByVal transno As String, ByVal tanggal As Date, ByVal total_item As String,
            ByVal total_beli As Decimal, ByVal total_jual As Decimal, ByVal total_bayar As Decimal,
            ByVal dibayar As Decimal, ByVal kembali As Decimal, ByVal user As String)
        TransList.Add(New Entity.Trans With {.TransNo = transno, .Tanggal = tanggal, .Total_Item = total_item, .Total_Beli = total_beli,
                                             .Total_Jual = total_jual, .Total_Bayar = total_bayar, .Dibayar = dibayar, .Kembali = kembali})



    End Sub

    <Extension()>
    Sub Add(ByVal UserList As List(Of Entity.Users), ByVal Username As String, ByVal Password As String,
             ByVal First_Name As String, ByVal Last_Name As String,
              ByVal Actived As Boolean, ByVal RoleID As Int16, ByVal RoleName As String)
        UserList.Add(New Entity.Users With {.Username = Username, .Password = Password, .First_Name = First_Name,
                                            .Last_Name = Last_Name, .Actived = Actived,
                                            .Role = New Entity.Role With {.RoleID = RoleID, .RoleName = RoleName}})
    End Sub

    <Extension()>
    Sub Add(ByVal RoleList As List(Of Entity.Role), ByVal RoleID As String, ByVal RoleName As String)
        RoleList.Add(New Entity.Role With {.RoleID = RoleID, .RoleName = RoleName})
    End Sub

    <Extension()>
    Sub Add(ByVal DetailList As List(Of Entity.DetailTrans), ByVal transno As String, ByVal stock_id As String, ByVal stock_name As String,
            ByVal price_buy As Decimal, ByVal price_sell As Decimal, ByVal item_buy As Integer, ByVal buy_total As Decimal, ByVal sell_total As Decimal)
        DetailList.Add(New Entity.DetailTrans With {.TransNo = transno, .Stock_ID = stock_id, .Stock_Name = stock_name, .Price_Buy = price_buy,
                                             .Price_Sell = price_sell, .Item_Buy = item_buy, .Buy_Total = buy_total, .Sell_Total = sell_total})


    End Sub

#End Region

    Public Function SQLTable(ByVal source As String) As DataTable
        Try
            Dim Adp As New OleDb.OleDbDataAdapter(source, str)
            Dim DT As New DataTable
            Adp.Fill(DT)
            SQLTable = DT

        Catch ex As Exception
            MsgBox(ex.Message)
            SQLTable = Nothing
        End Try
    End Function

    Public Conn As OleDbConnection
    Public da As OleDbDataAdapter
    Public ds As DataSet
    Public cmd As OleDbCommand
    Public rd As OleDbDataReader
    Public str As String

    Public Sub Koneksi()
        str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\KP.accdb"
        Conn = New OleDbConnection(str)
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub


End Module
