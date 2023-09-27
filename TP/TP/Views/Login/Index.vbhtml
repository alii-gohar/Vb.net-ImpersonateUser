@ModelType LoginViewModel


<h2>@ViewBag.Message</h2>

@Using Html.BeginForm("AuthenticateLogin", "Login", FormMethod.Post, New With {.role = "form"})
@Html.AntiForgeryToken()
@<text>
    <div Class="form-group">
        @Html.LabelFor(Function(m) m.Email, New With {.class = "control-label"})
        @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
        @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger"})

    </div>

    <div Class="form-group">
        @Html.LabelFor(Function(m) m.Password, New With {.class = "control-label"})
        @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
        @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
    </div>

    <div class="form-group">
        <input type="submit" value="Log in" class="btn btn-outline-dark" />

    </div>
</text>
End Using
