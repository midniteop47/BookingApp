@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code


@ModelType BookingApp.Tech
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"

End Code

<h2>Details</h2>

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
            @Html.DisplayNameFor(Function(model) model.PostcodeRange)
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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
