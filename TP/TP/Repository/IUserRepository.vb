Public Interface IUserRepository
    Function GetAllUsers(ByVal isProvider As Boolean) As List(Of UserModel)
End Interface
