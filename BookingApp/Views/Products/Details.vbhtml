@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code


@ModelType BookingApp.Product
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"

End Code

<h2>Details</h2>

<div>
    <h4>Product</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.ProductName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ProductName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ProductType)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ProductType)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SubCatagoty)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SubCatagoty)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ServiceType)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ServiceType)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Note)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Note)
        </dd>
        <dt>
            @Html.DisplayNameFor(Function(model) model.Cost)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cost)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
