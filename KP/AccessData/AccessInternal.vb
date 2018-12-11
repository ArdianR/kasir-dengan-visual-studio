Imports System.Data
Imports System.Data.OleDb
Namespace AccessData

    Public Class AccessInternal
        Public Function InternalInsert(ByVal Internal As Entity.Internal) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_InsertInternal", connect)
                        mycommand.CommandType = CommandType.StoredProcedure

                        KPModule.AddParameter("@no", OleDbType.VarChar, 8, Internal.No, mycommand)
                        KPModule.AddParameter("@tanggal", OleDbType.VarChar, 25, Internal.Tanggal, mycommand)
                        KPModule.AddParameter("@tunai", OleDbType.Currency, 0, Internal.Tunai, mycommand)
                        KPModule.AddParameter("@keterangan", OleDbType.VarChar, 225, Internal.Keterangan, mycommand)

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

        Public Function InternalUpdate(ByVal Internal As Entity.Internal) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_UpdateInternal", connect)
                        mycommand.CommandType = CommandType.StoredProcedure

                        KPModule.AddParameter("@tanggal", OleDbType.VarChar, 25, Internal.Tanggal, mycommand)
                        KPModule.AddParameter("@tunai", OleDbType.Currency, 0, Internal.Tunai, mycommand)
                        KPModule.AddParameter("@keterangan", OleDbType.VarChar, 225, Internal.Keterangan, mycommand)
                        KPModule.AddParameter("@no", OleDbType.VarChar, 8, Internal.No, mycommand)

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

