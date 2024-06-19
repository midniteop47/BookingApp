
@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code

@ModelType IEnumerable(Of BookingApp.Product)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"

End Code

<style>
    .card {
        box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
        transition: 0.3s;
        width: 200px;
        border-radius: 5px;
    }

        .card:hover {
            box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
        }

    .containera {
        padding: 5px 5px 15px 15px;
    }
</style>
<div style="padding-bottom: 20px; padding-top: 20px">
    <h2>Products</h2>
</div>


<p>
    <a href="@Url.Action("Create", "Products")" class="btn btn-primary btn-lg"> <i class="bi bi-file-earmark-plus"></i> Create New</a>
</p>
<hr />
<div class="row">
    @For Each item In Model
        @<div Class="col-md-3 mb-5">
            <div Class="card">
                <div Class="containera">
                    <div>
                        <h3>@Html.DisplayFor(Function(modelItem) item.ProductName)</h3>
                        <hr />
                    </div>
                    <div>
                        <h5>@Html.DisplayFor(Function(modelItem) item.ProductType)</h5>
                        <h5>@Html.DisplayFor(Function(modelItem) item.SubCatagoty)</h5>
                        <h5>@Html.DisplayFor(Function(modelItem) item.ServiceType)</h5>
                        <h5>@Html.DisplayFor(Function(modelItem) item.Cost)</h5>
                        <hr />
                    </div>

                    <div>
                        <a Class="btn btn-default" href="@Url.Action("Edit", "Products", New With {.id = item.id})"><i class="bi bi-pencil"></i></a>
                        <a Class="btn btn-danger" href="@Url.Action("Delete", "Products", New With {.id = item.id})"><i class="bi bi-trash"></i></a>
                    </div>
                </div>
            </div>
        </div>
    Next
</div>

