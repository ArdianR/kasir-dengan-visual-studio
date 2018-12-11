Imports System.Data.OleDb

Namespace AccessData
    Public Class AccessDetailTrans

        Public Function FindDetailByNo(ByVal No As String) As IEnumerable(Of Entity.DetailTrans)
            Dim Detail As New List(Of Entity.DetailTrans)()
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_selectDetailbyNo", connect)
                        mycommand.CommandType = CommandType.StoredProcedure
                        mycommand.Parameters.Add("@TransNo", OleDbType.VarChar).Value = No
                        connect.Open()

                        Using rdr As OleDbDataReader = mycommand.ExecuteReader
                            While rdr.Read
                                Detail.Add(rdr("TransNo").ToString(), _
                                rdr("stock_id").ToString(), _
                                rdr("stock_name").ToString(), _
                                rdr("price_buy").ToString(), _
                                rdr("price_sell").ToString(), rdr("item_buy").ToString(), _
                                rdr("buy_total").ToString(), rdr("sell_total").ToString())

                            End While
                        End Using

                    End Using
                End Using
            Catch sqlex As OleDbException
                Throw New Exception(sqlex.Message.ToString())
            End Try
            Return Detail
        End Function

    End Class
End Namespace