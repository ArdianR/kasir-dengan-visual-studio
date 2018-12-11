Imports System.Data
Imports System.Data.OleDb
Namespace AccessData
    Public Class AccessTrans


        Public Function TRANSInsert(ByVal TRANS As Entity.Trans) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_InsertTRANS", connect)
                        mycommand.CommandType = CommandType.StoredProcedure

                        KPModule.AddParameter("@transno", OleDbType.VarChar, 7, TRANS.TransNo, mycommand)
                        KPModule.AddParameter("@tanggal", OleDbType.Date, 0, TRANS.Tanggal, mycommand)
                        KPModule.AddParameter("@total_item", OleDbType.VarChar, 7, TRANS.Total_Item, mycommand)
                        KPModule.AddParameter("@total_beli", OleDbType.Currency, 0, TRANS.Total_Beli, mycommand)
                        KPModule.AddParameter("@total_jual", OleDbType.Currency, 0, TRANS.Total_Jual, mycommand)
                        KPModule.AddParameter("@total_bayar", OleDbType.Currency, 0, TRANS.Total_Bayar, mycommand)
                        KPModule.AddParameter("@dibayar", OleDbType.Currency, 0, TRANS.Dibayar, mycommand)
                        KPModule.AddParameter("@kembali", OleDbType.Currency, 0, TRANS.Kembali, mycommand)
                        
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

        Public Function TRANSUpdate(ByVal TRANS As Entity.Trans) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_UpdateTRANS", connect)
                        mycommand.CommandType = CommandType.StoredProcedure

                        KPModule.AddParameter("@tanggal", OleDbType.Date, 0, TRANS.Tanggal, mycommand)
                        KPModule.AddParameter("@total_item", OleDbType.VarChar, 7, TRANS.Total_Item, mycommand)
                        KPModule.AddParameter("@total_beli", OleDbType.Currency, 0, TRANS.Total_Beli, mycommand)
                        KPModule.AddParameter("@total_jual", OleDbType.Currency, 0, TRANS.Total_Jual, mycommand)
                        KPModule.AddParameter("@total_bayar", OleDbType.Currency, 0, TRANS.Total_Bayar, mycommand)
                        KPModule.AddParameter("@dibayar", OleDbType.Currency, 0, TRANS.Dibayar, mycommand)
                        KPModule.AddParameter("@kembali", OleDbType.Currency, 0, TRANS.Kembali, mycommand)
                        KPModule.AddParameter("@transno", OleDbType.VarChar, 7, TRANS.TransNo, mycommand)


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

        Public Function FindTransByNo(ByVal No As String) As IEnumerable(Of Entity.Trans)
            Dim Trans As New List(Of Entity.Trans)()
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_selectTransbyNo", connect)
                        mycommand.CommandType = CommandType.StoredProcedure
                        mycommand.Parameters.Add("@TransNo", OleDbType.VarChar).Value = No
                        connect.Open()

                        Using rdr As OleDbDataReader = mycommand.ExecuteReader
                            While rdr.Read
                                Trans.Add(rdr("transno").ToString(), _
                                rdr("tanggal").ToString(), _
                                rdr("total_item").ToString(), _
                                rdr("total_beli").ToString(), _
                                rdr("total_jual").ToString(), rdr("totaldibeli").ToString(), _
                                rdr("total_dibayar").ToString(), rdr("dibayar").ToString(), _
                                rdr("kembali").ToString())

                            End While
                        End Using

                    End Using
                End Using
            Catch sqlex As OleDbException
                Throw New Exception(sqlex.Message.ToString())
            End Try
            Return Trans
        End Function

    End Class
End Namespace
