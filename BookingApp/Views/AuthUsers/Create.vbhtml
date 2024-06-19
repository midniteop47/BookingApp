@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code


@ModelType BookingApp.AuthUser
@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"

End Code


<div style="padding-bottom: 20px; padding-top: 20px">
    <h2>Create</h2>
</div>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Admin User</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control", .required = "required"}})
                @Html.ValidationMessageFor(Function(model) model.Name, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Pass, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Pass, "", New With {.htmlAttributes = New With {.class = "form-control", .required = "required", .type = "password"}})
                @Html.ValidationMessageFor(Function(model) model.Pass, "", New With {.class = "text-danger"})

            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Permission, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Permission, New With {.htmlAttributes = New With {.class = "form-control", .disabled = "disabled"}})
                @Html.ValidationMessageFor(Function(model) model.Permission, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
