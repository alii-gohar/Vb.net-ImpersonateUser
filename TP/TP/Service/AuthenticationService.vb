Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Net

Public Module AuthenticationService
    Dim con As SqlConnection = New SqlConnection(BaseDBController.ConnectionString)
    Public Function ImpersonateUser(ByVal email As String) As UserModel
        con.Open()
        Dim user As UserModel = New UserModel()
        Dim query As String = "SELECT * FROM [User] WHERE Email = @Email"
        Using cmd As SqlCommand = New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Email", email)
            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    user.ID = CInt(reader("Id"))
                    user.Name = CStr(reader("Name"))
                    user.Email = CStr(reader("Email"))
                    user.Password = CStr(reader("Password"))
                    user.Role = CStr(reader("Role"))
                End If
            End Using
        End Using
        con.Close()
        Return user
    End Function

    Public Function CheckUserCredentials(email As String, password As String) As UserModel
        con.Open()
        Dim query As String = "SELECT * FROM [User] WHERE Email = @Email AND Password = @Password"
        Using cmd As SqlCommand = New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Email", email)
            cmd.Parameters.AddWithValue("@Password", password)
            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Dim user As UserModel = New UserModel()
                    user.ID = CInt(reader("Id"))
                    user.Name = CStr(reader("Name"))
                    user.Email = CStr(reader("Email"))
                    user.Password = CStr(reader("Password"))
                    user.Role = CStr(reader("Role"))
                    con.Close()
                    Return user
                End If
            End Using
        End Using
        con.Close()
        Return Nothing
    End Function


    Public Function RegisterUser(name As String, email As String, password As String, role As String) As UserModel
        con.Open()
        Dim query As String = "SELECT * FROM [User] WHERE Email = @Email"

        Using cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Email", email)

            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    ' Email already exists, return Nothing or handle the error as needed
                    con.Close()
                    Return Nothing
                End If
            End Using
        End Using


        Dim countQuery As String = "SELECT COUNT(*) FROM [User]"
        Dim userCount As Integer = 0

        Using cmdCount As New SqlCommand(countQuery, con)
            userCount = CInt(cmdCount.ExecuteScalar()) + 1
        End Using



        ' Email doesn't exist, proceed with the insertion
        query = "INSERT INTO [User] (ID,Name, Email, Password, Role) VALUES (@ID,@Name, @Email, @Password, @Role)"

        Dim r As UserRole
        [Enum].TryParse(role, True, r)
        Dim roleValue As Integer = CInt(r)


        Using cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@ID", userCount)
            cmd.Parameters.AddWithValue("@Name", name)
            cmd.Parameters.AddWithValue("@Email", email)
            cmd.Parameters.AddWithValue("@Password", password)
            cmd.Parameters.AddWithValue("@Role", roleValue)

            ' Execute the INSERT query
            cmd.ExecuteNonQuery()
        End Using

        con.Close()

        ' Optionally, you can return the UserModel for the newly registered user
        Dim newUser As New UserModel()
        newUser.Name = name
        newUser.Email = email

        Return newUser
    End Function



End Module
