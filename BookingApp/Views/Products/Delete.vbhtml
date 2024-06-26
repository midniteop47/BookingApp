@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code


@ModelType BookingApp.Product
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"

End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Product</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            Product Name
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ProductName)
        </dd>

        <dt>
            Product Type
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ProductType)
        </dd>

        <dt>
            Sub Catagoty
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SubCatagoty)
        </dd>

        <dt>
            Service Type
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-danger" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
