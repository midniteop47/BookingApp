@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code
@ModelType BookingApp.ServiceData
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

<div>
    <h4>ServiceData</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Service)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Service)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.TechName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TechName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Duration)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Duration)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
