Imports System.Data.SqlClient
Imports TP.UserRole

Public Class HomeController
    Inherits System.Web.Mvc.Controller
    Function Index() As ActionResult
        If Session("CurrentUser") Is Nothing Then
            Return RedirectToAction("Index", "Login")
        End If
        Dim users As List(Of UserModel) = New List(Of UserModel)()
        If Session("CurrentUser").Role = UserRole.User Then
            Return View(users)
        End If
        users = UserService.FetchUsers(Session("CurrentUser").Role = UserRole.Provider)
        Return View(users)
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
