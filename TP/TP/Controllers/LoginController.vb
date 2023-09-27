Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports System.Web.Mvc
Imports TP.BaseDBController

Public Class LoginController
    Inherits Controller
    Function Index() As ActionResult
        If Session("CurrentUser") IsNot Nothing Then
            Return RedirectToAction("Index", "Home")
        End If

        Return View()
    End Function

    Function ShiftUser(email As String) As ActionResult
        If Session("CurrentUser").Role = UserRole.Admin Then
            Dim user = ImpersonateUser(email)
            Session("CurrentUser") = user
            Return RedirectToAction("Index", "Home")
        End If

        Return View()
    End Function
    <HttpPost>
    <AllowAnonymous>
    <ValidateAntiForgeryToken>
    Public Async Function AuthenticateLogin(model As LoginViewModel) As Task(Of ActionResult)

        If ModelState.IsValid Then
            ' Check the username and password against the database
            Dim user = AuthenticationService.CheckUserCredentials(model.Email, model.Password)

            If user IsNot Nothing Then
                Session("CurrentUser") = user
                Return RedirectToAction("Index")
            Else
                ViewBag.Message = "Invalid Credentials"
                ModelState.AddModelError("err", "Invalid username or password")
                Return View("Index")
            End If
        End If
        Return View()
    End Function


End Class
