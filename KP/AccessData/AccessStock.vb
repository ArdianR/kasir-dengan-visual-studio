Imports System.Data
Imports System.Data.OleDb

Namespace AccessData
    Public Class AccessStock

        Public Function StockInsert(ByVal Stock As Entity.Stock) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_InsertStock", connect)
                        mycommand.CommandType = CommandType.StoredProcedure

                        Dim parameterStockID As OleDbParameter = New OleDbParameter("@stock_id", OleDbType.VarChar, 5)
                        parameterStockID.Value = Stock.Stock_ID

                        Dim parameterTanggal As OleDbParameter = New OleDbParameter("@tanggal", OleDbType.Date)
                        parameterTanggal.Value = Stock.Tanggal

                        Dim parameterStockName As OleDbParameter = New OleDbParameter("@stock_name", OleDbType.VarChar, 255)
                        parameterStockName.Value = Stock.Stock_Name

                        Dim parameterPriceBuy As OleDbParameter = New OleDbParameter("@price_buy", OleDbType.Currency)
                        parameterPriceBuy.Value = Stock.Price_Buy

                        Dim parameterPriceSell As OleDbParameter = New OleDbParameter("@price_sell", OleDbType.Currency)
                        parameterPriceSell.Value = Stock.Price_Sell

                        Dim parameterStockItem As OleDbParameter = New OleDbParameter("@stock_item", OleDbType.VarChar, 5)
                        parameterStockItem.Value = Stock.Stock_Item

                        Dim parameterCategoryName As OleDbParameter = New OleDbParameter("@category_name", OleDbType.VarChar, 255)
                        parameterCategoryName.Value = Stock.Category_Name

                        With mycommand.Parameters
                            .Add(parameterStockID)
                            .Add(parameterTanggal)
                            .Add(parameterStockName)
                            .Add(parameterPriceBuy)
                            .Add(parameterPriceSell)
                            .Add(parameterStockItem)
                            .Add(parameterCategoryName)

                        End With

                        connect.Open()
                        Using result As OleDbDataReader = mycommand.ExecuteReader(CommandBehavior.CloseConnection)
                            Return result
                        End Using

                    End Using
                End Using

            Catch SqlEx As OleDbException
                Throw New Exception(SqlEx.Message.ToString())
            End Try


        End Function

        Public Function StockUpdate(ByVal Stock As Entity.Stock) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_UpdateStock", connect)
                        mycommand.CommandType = CommandType.StoredProcedure

                        Dim parameterTanggal As OleDbParameter = New OleDbParameter("@tanggal", OleDbType.Date)
                        parameterTanggal.Value = Stock.Tanggal


                        Dim parameterStockName As OleDbParameter = New OleDbParameter("@stock_name", OleDbType.VarChar, 255)
                        parameterStockName.Value = Stock.Stock_Name

                        Dim parameterPriceBuy As OleDbParameter = New OleDbParameter("@price_buy", OleDbType.Currency)
                        parameterPriceBuy.Value = Stock.Price_Buy

                        Dim parameterPriceSell As OleDbParameter = New OleDbParameter("@price_sell", OleDbType.Currency)
                        parameterPriceSell.Value = Stock.Price_Sell

                        Dim parameterStockItem As OleDbParameter = New OleDbParameter("@stock_item", OleDbType.VarChar, 5)
                        parameterStockItem.Value = Stock.Stock_Item

                        Dim parameterCategoryName As OleDbParameter = New OleDbParameter("@category_name", OleDbType.VarChar, 255)
                        parameterCategoryName.Value = Stock.Category_Name

                        Dim parameterStockID As OleDbParameter = New OleDbParameter("@stock_id", OleDbType.VarChar, 5)
                        parameterStockID.Value = Stock.Stock_ID

                        With mycommand.Parameters
                            .Add(parameterTanggal)
                            .Add(parameterStockName)
                            .Add(parameterPriceBuy)
                            .Add(parameterPriceSell)
                            .Add(parameterStockItem)
                            .Add(parameterCategoryName)
                            .Add(parameterStockID)

                        End With
                        connect.Open()
                        Using result As OleDbDataReader = mycommand.ExecuteReader(CommandBehavior.CloseConnection)
                            Return result
                        End Using

                    End Using
                End Using

            Catch SqlEx As OleDbException
                Throw New Exception(SqlEx.Message.ToString())
            End Try

        End Function

        Public Function StockDelete(ByVal Stock As Entity.Stock) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_DeleteStock", connect)
                        mycommand.CommandType = CommandType.StoredProcedure

                        Dim parameterStockID As OleDbParameter = New OleDbParameter("@stock_id", OleDbType.VarChar, 5)
                        parameterStockID.Value = Stock.Stock_ID

                        With mycommand.Parameters
                            .Add(parameterStockID)

                        End With
                        connect.Open()
                        Using result As OleDbDataReader = mycommand.ExecuteReader(CommandBehavior.CloseConnection)
                            Return result
                        End Using
                    End Using
                End Using
            Catch SqlEx As OleDbException
                Throw New Exception(SqlEx.Message.ToString())
            End Try
        End Function

        Public Function FindStockByID(ByVal Stock_ID As String) As IEnumerable(Of Entity.Stock)
            Dim Stock As New List(Of Entity.Stock)()
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_selectStockbyID", connect)
                        mycommand.CommandType = CommandType.StoredProcedure
                        mycommand.Parameters.Add("@stock_id", OleDbType.VarChar).Value = Stock_ID
                        connect.Open()

                        Using rdr As OleDbDataReader = mycommand.ExecuteReader
                            While rdr.Read
                                Stock.Add(rdr("stock_id").ToString(), _
                                rdr("tanggal").ToString(), _
                                rdr("stock_name").ToString(), _
                                rdr("price_buy").ToString(), _
                                rdr("price_sell").ToString(), rdr("stock_item").ToString(), _
                                rdr("category").ToString())

                            End While
                        End Using

                    End Using
                End Using
            Catch sqlex As OleDbException
                Throw New Exception(sqlex.Message.ToString())
            End Try
            Return Stock
        End Function

        Public Function ItemUpdate(ByVal Stock As Entity.Stock) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_UpdateStockItem", connect)
                        mycommand.CommandType = CommandType.StoredProcedure

                        KPModule.AddParameter("@stock_item", OleDbType.VarChar, 25, Stock.Stock_Item, mycommand)
                        KPModule.AddParameter("@stock_id", OleDbType.VarChar, 7, Stock.Stock_ID, mycommand)

                        connect.Open()
                        Using result As OleDbDataReader = mycommand.ExecuteReader(CommandBehavior.CloseConnection)
                            Return result
                        End Using

                    End Using
                End Using

            Catch SqlEx As OleDbException
                Throw New Exception(SqlEx.Message.ToString())
            End Try

        End Function


    End Class
End Namespace

