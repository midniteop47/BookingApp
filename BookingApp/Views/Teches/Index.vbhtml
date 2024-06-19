@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code

@ModelType IEnumerable(Of BookingApp.Tech)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
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
    <h2>Service Techs</h2>
</div>


<p>
    <a href="@Url.Action("Create", "Teches")" class="btn btn-primary btn-lg"><i class="bi bi-person-add"></i> Add New</a>
</p>
<hr />
<div style="display: flex; flex-wrap: wrap;">
    @For Each item In Model
        @<div Class="col-md-3 mb-5">
            <div class="card">
                <div class="containera">
                    <div>
                        <h4>@Html.DisplayFor(Function(modelItem) item.Name)</h4>
                        <hr />
                    </div>
                    <a class="btn btn-default" href="@Url.Action("Edit", "Teches", New With {.id = item.id})"><i class="bi bi-pencil"></i></a>
                    <a class="btn btn-danger" href="@Url.Action("Delete", "Teches", New With {.id = item.id})"><i class="bi bi-trash"></i></a>
                </div>
            </div>
        </div>
    Next
</div>


