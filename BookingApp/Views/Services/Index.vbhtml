@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code


@ModelType IEnumerable(Of BookingApp.Service)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">

<div style="padding-bottom: 20px; padding-top: 20px">
    <h2>Services Provided</h2>
</div>

<p>
    <a href="@Url.Action("Create", "Services")" class="btn btn-primary btn-lg"><i class="bi bi-person-add"></i> Add New</a>
</p>


<table class="table">
    <tr>
        <th>
            Services
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @item.Service1
            </td>
            <td>
                <a class="btn btn-default" href="@Url.Action("Edit", "Services", New With {.id = item.id})"><i class="bi bi-pencil"></i></a>
                <a class="btn btn-danger" href="@Url.Action("Delete", "Services", New With {.id = item.id})"><i class="bi bi-trash"></i></a>
            </td>
        </tr>
    Next

</table>
