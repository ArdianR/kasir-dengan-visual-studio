Imports System.Data
Imports System.Data.OleDb

Namespace AccessData
    Public Class AccessPaket

        Public Function PaketInsert(ByVal Paket As Entity.Paket) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnection)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_InsertPaket", connect)
                        mycommand.CommandType = CommandType.StoredProcedure

                        Dim parameterPaketID As OleDbParameter = New OleDbParameter("@paket_id", OleDbType.VarChar, 4)
                        parameterPaketID.Value = Paket.Paket_ID

                        Dim parameterPaketName As OleDbParameter = New OleDbParameter("@paket_name", OleDbType.VarChar, 25)
                        parameterPaketName.Value = Paket.Paket_Name

                        Dim parameterPrice As OleDbParameter = New OleDbParameter("@Price", OleDbType.Currency)
                        parameterPrice.Value = Paket.Price

                        With mycommand.Parameters
                            .Add(parameterPaketID)
                            .Add(parameterPaketName)
                            .Add(parameterPrice)

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

        Public Function PaketUpdate(ByVal Paket As Entity.Paket) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnection)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_UpdatePaket", connect)
                        mycommand.CommandType = CommandType.StoredProcedure

                        Dim parameterPaketName As OleDbParameter = New OleDbParameter("@paket_name", OleDbType.VarChar, 25)
                        parameterPaketName.Value = Paket.Paket_Name

                        Dim parameterPrice As OleDbParameter = New OleDbParameter("@Price", OleDbType.Currency)
                        parameterPrice.Value = Paket.Price

                        Dim parameterPaketID As OleDbParameter = New OleDbParameter("@paket_id", OleDbType.VarChar, 4)
                        parameterPaketID.Value = Paket.Paket_ID

                        With mycommand.Parameters
                            .Add(parameterPaketName)
                            .Add(parameterPrice)
                            .Add(parameterPaketID)

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

        Public Function PaketDelete(ByVal Paket As Entity.Paket) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnection)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_DeletePaket", connect)
                        mycommand.CommandType = CommandType.StoredProcedure


                        Dim parameterPaketID As OleDbParameter = New OleDbParameter("@paket_id", OleDbType.VarChar, 4)
                        parameterPaketID.Value = Paket.Paket_ID

                        With mycommand.Parameters
                            .Add(parameterPaketID)

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
    End Class
End Namespace