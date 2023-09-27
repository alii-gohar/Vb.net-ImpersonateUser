Imports System.Web.Mvc

Public Class RegisterController
    Inherits Controller

    Public Function Index() As ActionResult

        Return View()
    End Function

    ' POST: Register
    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Function Index(ByVal model As User) As ActionResult
        ' Check if model state is valid
        If ModelState.IsValid Then

            Dim name As String = model.Name
            Dim email As String = model.Email
            Dim password As String = model.Password
            Dim role As String = model.Role

            Dim result As UserModel = AuthenticationService.RegisterUser(model.Name, model.Email, model.Password, model.Role)

            If result Is Nothing Then
                ViewBag.Message = "Email Already Exist"
                Return View("Index")
            End If


            Return RedirectToAction("Index", "Login")
        End If

        ' If model state is not valid, return the view with validation errors
        Return View(model)
    End Function


End Class
