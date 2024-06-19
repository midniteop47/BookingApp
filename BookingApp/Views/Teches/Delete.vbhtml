@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code


@ModelType BookingApp.Tech
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"

End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this Service Tech?</h3>
<div>
    <h4>Tech</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

        <dt>
            Post code Range
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PostcodeRange)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Services)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Services)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
