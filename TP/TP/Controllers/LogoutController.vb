Imports System.Web.Mvc

Namespace Controllers
    Public Class LogoutController
        Inherits Controller

        ' GET: Logout
        Function LogoutFunc() As ActionResult
            Session.Remove("CurrentUser")
            Return RedirectToAction("Index", "Home")
        End Function
    End Class
End Namespace