Public Class UserService
    Private Shared ReadOnly userRepository As IUserRepository

    Shared Sub New()
        userRepository = New UserRepository()
    End Sub

    Public Shared Function FetchUsers(ByVal isProvider As Boolean) As List(Of UserModel)
        Return userRepository.GetAllUsers(isProvider)
    End Function
End Class
