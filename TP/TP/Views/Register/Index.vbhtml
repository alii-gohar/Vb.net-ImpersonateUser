@ModelType User

<h2>@ViewBag.Message</h2>

@Using Html.BeginForm("Index", "Register", FormMethod.Post, New With {.role = "form"})
    @Html.AntiForgeryToken()
    @<text>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.Name, New With {.class = "control-label"})
            @Html.TextBoxFor(Function(m) m.Name, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.Name, "", New With {.class = "text-danger"})
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(m) m.Email, New With {.class = "control-label"})
            @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger"})
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(m) m.Password, New With {.class = "control-label"})
            @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(m) m.Role, New With {.class = "control-label"})
            @Html.DropDownListFor(Function(m) m.Role, New SelectList(New List(Of SelectListItem) From {
                         New SelectListItem With {.Text = "Admin", .Value = "Admin"},
                         New SelectListItem With {.Text = "User", .Value = "User"},
                         New SelectListItem With {.Text = "Provider", .Value = "Provider"}
                     }, "Value", "Text"), "Select a Role", New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.Role, "", New With {.class = "text-danger"})
        </div>

        <div class="form-group">
            <input type="submit" value="Register" class="btn btn-outline-dark" />
        </div>
    </text>
End Using
