@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code

@Code
    ViewData("Title") = "Home Page"

End Code

<div class="jumbotron">
    <h1>CDS Booking Management</h1>
    <p class="lead">Welcome</p>
</div>

