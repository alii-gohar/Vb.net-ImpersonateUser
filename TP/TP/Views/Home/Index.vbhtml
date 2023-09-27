@ModelType List(Of UserModel)
@Code
    Dim user As New UserModel()
    Dim userExists As Boolean = False
    If Session("CurrentUser") IsNot Nothing Then
        userExists = True
        user = Session("CurrentUser")
    End If

End Code

<main>
    <section class="row" aria-labelledby="aspnetTitle">
        @If userExists Then
            @:You are a @UserModel.GetRole(user.Role)
        End If
    </section>

    <div Class="row">
        <section Class="col-md-4" aria-labelledby="gettingStartedTitle">
        
            @If user.Role <> UserRole.User Then
                @:<h2 id="gettingStartedTitle"> Users :     </h2>
            End If
                
           
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Name</th>
                        <th scope="col">Email</th>
                        <th scope="col">Role</th>
                        @If user.Role = UserRole.Admin Then
                            @:<th scope = "col" > Shift User</th>
                        End If
                    </tr>
                </thead>
                <tbody>
                    @For Each singleUser As UserModel In Model
                        @:<tr>
                            @:<th scope="row">@singleUser.ID</th>
                            @:<td>@singleUser.Name</td>
                            @:<td>@singleUser.Email</td>
                            @:<td>@UserModel.GetRole(singleUser.Role)</td>
        
                            @If user.Role = UserRole.Admin Then
                                @:<td>
                                    @Html.ActionLink("Impersonate", "ShiftUser", "Login", New With {.email = singleUser.Email}, New With {.class = "btn btn-success align-items-end"})
                                @:</td>
                            End If
                        @:</tr>
                    Next

                </tbody>
            </table>

            
        </section>

    </div>
</main>



@*@:<div class="col-md">
    @singleUser.Name
    @:
</div>
@:<div class="col-md">
    @If user.Role = "Admin" Then
        @Html.ActionLink("Impersonate this user", "ShiftUser", "Login", New With {.email = singleUser.Email}, New With {.class = "btn btn-success align-items-end"})
    End If
    @:
</div>*@