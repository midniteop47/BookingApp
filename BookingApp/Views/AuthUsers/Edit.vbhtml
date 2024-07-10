@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code

@ModelType BookingApp.AuthUser
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout.vbhtml"

End Code


<div style="padding-bottom: 20px; padding-top: 20px">
    <h2>Edit Password</h2>
</div>


@Using (Html.BeginForm("Edit", "AuthUsers", New With {.Name = Model.Name}, method:=FormMethod.Post))
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.id)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control", .disabled = "disabled"}})
                @Html.ValidationMessageFor(Function(model) model.Name, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Pass, "Password", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                <input id="Pass" name="Pass" class="form-control" type="password" required />
                @Html.ValidationMessageFor(Function(model) model.Pass, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group" style="display:none">
            @Html.LabelFor(Function(model) model.Permission, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Permission, New With {.htmlAttributes = New With {.class = "form-control", .disabled = "disabled"}})
                @Html.ValidationMessageFor(Function(model) model.Permission, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>  End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
