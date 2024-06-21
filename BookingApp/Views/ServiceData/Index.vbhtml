@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code
@ModelType IEnumerable(Of BookingApp.ServiceData)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Service)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TechName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Duration)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Service)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.TechName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Duration)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.id}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.id}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.id})
            </td>
        </tr>
    Next

</table>
