Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.ApplicationServices

Public Class UserRepository
    Implements IUserRepository
    Dim con As SqlConnection = New SqlConnection(BaseDBController.ConnectionString)
    Public Function GetAllUsers(ByVal isProvider As Boolean) As List(Of UserModel) Implements IUserRepository.GetAllUsers
        Dim users As List(Of UserModel) = New List(Of UserModel)()
        con.Open()
        Dim sqlQuery As String = "SELECT * FROM [User]"
        If isProvider Then
            sqlQuery += "where Role != 2 and Role != 3"
        End If
        Dim cmd As SqlCommand = New SqlCommand(sqlQuery, con)
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dataTable As DataTable = New DataTable()
        adapter.Fill(dataTable)
        ' Iterate through the DataTable and populate the list of users
        For Each row As DataRow In dataTable.Rows
            Dim user As UserModel = New UserModel()
            user.ID = CInt(row("Id"))
            user.Name = CStr(row("Name"))
            user.Email = CStr(row("Email"))
            user.Password = CStr(row("Password"))
            user.Role = CStr(row("Role"))
            users.Add(user)
        Next
        con.Close()
        Return users
    End Function
End Class
