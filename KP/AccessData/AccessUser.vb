Imports System.Data
Imports System.Data.OleDb
Namespace AccessData
    Public Class AccessUser

        Public Function UserInsert(ByVal User As Entity.Users) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_InsertUser", connect)
                        mycommand.CommandType = CommandType.StoredProcedure

                        Dim parameterUserName As OleDbParameter = New OleDbParameter("@UserName", OleDbType.VarChar, 15)
                        parameterUserName.Value = User.Username

                        Dim parameterPassword As OleDbParameter = New OleDbParameter("@Password", OleDbType.VarChar, 15)
                        parameterPassword.Value = User.Password

                        Dim parameterFirstName As OleDbParameter = New OleDbParameter("@first_name", OleDbType.VarChar, 50)
                        parameterFirstName.Value = User.First_Name

                        Dim parameterLastName As OleDbParameter = New OleDbParameter("@last_name", OleDbType.VarChar, 50)
                        parameterLastName.Value = User.Last_Name

                        Dim parameterRoleID As OleDbParameter = New OleDbParameter("@RoleID", OleDbType.Integer)
                        parameterRoleID.Value = User.Role.RoleID

                        With mycommand.Parameters
                            .Add(parameterUserName)
                            .Add(parameterPassword)
                            .Add(parameterFirstName)
                            .Add(parameterLastName)
                            .Add(parameterRoleID)
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

        Public Function UserUpdate(ByVal User As Entity.Users) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_UpdateUser", connect)
                        mycommand.CommandType = CommandType.StoredProcedure



                        Dim parameterPassword As OleDbParameter = New OleDbParameter("@Password", OleDbType.VarChar, 15)
                        parameterPassword.Value = User.Password

                        Dim parameterFirstName As OleDbParameter = New OleDbParameter("@first_name", OleDbType.VarChar, 50)
                        parameterFirstName.Value = User.First_Name

                        Dim parameterLastName As OleDbParameter = New OleDbParameter("@last_name", OleDbType.VarChar, 50)
                        parameterLastName.Value = User.Last_Name

                        Dim parameterRoleID As OleDbParameter = New OleDbParameter("@RoleID", OleDbType.Integer)
                        parameterRoleID.Value = User.Role.RoleID

                        Dim parameterActived As OleDbParameter = New OleDbParameter("@Actived", OleDbType.Boolean)
                        parameterActived.Value = User.Actived

                        Dim parameterUserName As OleDbParameter = New OleDbParameter("@UserName", OleDbType.VarChar, 15)
                        parameterUserName.Value = User.Username



                        With mycommand.Parameters

                            .Add(parameterPassword)
                            .Add(parameterFirstName)
                            .Add(parameterLastName)
                            .Add(parameterRoleID)
                            .Add(parameterActived)
                            .Add(parameterUserName)
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

        Public Function Login(ByVal username As String) As List(Of Entity.Users)
            Dim User As New List(Of Entity.Users)()
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_selectlogin", connect)
                        mycommand.CommandType = CommandType.StoredProcedure
                        mycommand.Parameters.Add("@username", OleDbType.VarChar).Value = username
                        connect.Open()

                        Using rdr As OleDbDataReader = mycommand.ExecuteReader

                            While rdr.Read
                                User.Add(rdr("username").ToString(), _
                                         rdr("Password").ToString(), _
                                         rdr("First_Name").ToString(), _
                                         rdr("Last_Name").ToString(), _
                                         rdr("Actived"), _
                                         rdr("RoleID").ToString(), _
                                         rdr("RoleName").ToString())
                            End While
                        End Using
                    End Using
                End Using
            Catch sqlex As OleDbException
                Throw New Exception(sqlex.Message.ToString())
            End Try
            Return User
        End Function

        Public Function ChangePassword(ByVal User As Entity.Users) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_changepassword", connect)
                        mycommand.CommandType = CommandType.StoredProcedure


                        Dim parameterPassword As OleDbParameter = New OleDbParameter("@Password", OleDbType.VarChar, 15)
                        parameterPassword.Value = User.Password

                        Dim parameterUserName As OleDbParameter = New OleDbParameter("@genre_id", OleDbType.VarChar, 15)
                        parameterUserName.Value = User.Username

                        With mycommand.Parameters
                            .Add(parameterPassword)
                            .Add(parameterUserName)
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

        Public Function DeleteRoleMenu(ByVal MenuRole As Entity.MenuRole) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_DeleteRoleMenu", connect)
                        mycommand.CommandType = CommandType.StoredProcedure


                        Dim parameterRoleID As OleDbParameter = New OleDbParameter("@RoleID", OleDbType.Integer)
                        parameterRoleID.Value = MenuRole.Role.RoleID

                        With mycommand.Parameters
                            .Add(parameterRoleID)
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

        Public Function InsertRoleMenu(ByVal MenuRole As Entity.MenuRole) As OleDbDataReader
            Try
                Using connect As New OleDbConnection(My.Settings.KPConnect)
                    Using mycommand As OleDbCommand = New OleDbCommand("usp_InsertRoleMenu", connect)
                        mycommand.CommandType = CommandType.StoredProcedure


                        Dim parameterRoleID As OleDbParameter = New OleDbParameter("@RoleID", OleDbType.Integer)
                        parameterRoleID.Value = MenuRole.Role.RoleID

                        Dim parameterMenuID As OleDbParameter = New OleDbParameter("@MenuID", OleDbType.VarChar, 10)
                        parameterMenuID.Value = MenuRole.Menu.MenuID


                        With mycommand.Parameters
                            .Add(parameterRoleID)
                            .Add(parameterMenuID)
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

