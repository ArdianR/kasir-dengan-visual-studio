Imports System.Data
Imports System.Data.OleDb
Namespace AccessData
    Public Class AccessCategory

        Public Function CategoryInsert(ByVal Category As Entity.Category) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_InsertCategory", connect)
                        mycommand.CommandType = CommandType.StoredProcedure

                        Dim parameterCategoryID As OleDbParameter = New OleDbParameter("@category_id", OleDbType.VarChar, 4)
                        parameterCategoryID.Value = Category.Category_ID

                        Dim parameterCategoryName As OleDbParameter = New OleDbParameter("@category_name", OleDbType.VarChar, 25)
                        parameterCategoryName.Value = Category.Category_Name

                        With mycommand.Parameters
                            .Add(parameterCategoryID)
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

        Public Function CategoryUpdate(ByVal Category As Entity.Category) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_UpdateCategory", connect)
                        mycommand.CommandType = CommandType.StoredProcedure

                        Dim parameterCategoryName As OleDbParameter = New OleDbParameter("@category_name", OleDbType.VarChar, 25)
                        parameterCategoryName.Value = Category.Category_Name

                        Dim parameterCategoryID As OleDbParameter = New OleDbParameter("@category_id", OleDbType.VarChar, 4)
                        parameterCategoryID.Value = Category.Category_ID

                        With mycommand.Parameters
                            .Add(parameterCategoryName)
                            .Add(parameterCategoryID)

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

        Public Function CategoryDelete(ByVal Category As Entity.Category) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_DeleteCategory", connect)
                        mycommand.CommandType = CommandType.StoredProcedure

                        Dim parameterCategoryID As OleDbParameter = New OleDbParameter("@category_id", OleDbType.VarChar, 4)
                        parameterCategoryID.Value = Category.Category_ID

                        With mycommand.Parameters
                            .Add(parameterCategoryID)
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

