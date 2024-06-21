@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code

@ModelType BookingApp.Service
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this Service?</h3>
<div>
   
    <hr />
    <dl class="dl-horizontal">
        <dt>
          Service
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Service1)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-danger" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
