
@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code

@ModelType IEnumerable(Of BookingApp.AuthUser)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"

End Code

<h2>Admin Users</h2>


<p>
    <a href="@Url.Action("Create", "AuthUsers")" class="btn btn-primary btn-lg"><i class="bi bi-person-fill-gear"></i> Add New</a>
</p>


<table class="table table-responsive table-hover">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Name)
            </td>

            <td>
                <a Class="btn btn-default" href="@Url.Action("Edit", "AuthUsers", New With {.id = item.id})"><i class="bi bi-pencil"></i></a>
                <a Class="btn btn-danger" href="@Url.Action("Delete", "AuthUsers", New With {.id = item.id})"><i class="bi bi-trash"></i></a>
            </td>
        </tr>
    Next

</table>
