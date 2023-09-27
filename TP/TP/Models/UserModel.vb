Public Class UserModel
    Public ID As Integer
    Public Name As String
    Public Email As String
    Public Password As String
    Public Role As Integer
    Shared Function GetRole(ByVal role As Integer) As String
        Select Case role
            Case 0
                Return "NotSet"
            Case 1
                Return "User"
            Case 2
                Return "Provider"
            Case 3
                Return "Admin"
        End Select

    End Function

End Class
