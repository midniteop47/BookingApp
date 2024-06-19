@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code

@ModelType BookingApp.Tech
@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"

End Code
<style>
    textarea {
        width: 100%;
        min-height: 200px;
    }
</style>
<h2>Service Tech Details</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
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
            @Html.LabelFor(Function(model) model.PostcodeRange, "Post code Range | use commas ( , ) to seperate each postcode", htmlAttributes:=New With {.class = "control-label col-md-2"})

            <div class="col-md-10">
                @Html.TextAreaFor(Function(model) model.PostcodeRange, New With {.htmlAttributes = New With {.class = "form-control ", .rows = 5, .required = "required"}})
                @Html.ValidationMessageFor(Function(model) model.PostcodeRange, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Services, " Services  | use commas ( , ) to seperate each postcode", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextAreaFor(Function(model) model.Services, New With {.htmlAttributes = New With {.class = "form-control", .required = "required"}})
                @Html.ValidationMessageFor(Function(model) model.Services, "", New With {.class = "text-danger"})
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
<script src="https://ajax.aspnetcdn.com/ajax/jquery.validate/1.17.0/jquery.validate.min.js"></script>
<script src="https://ajax.aspnetcdn.com/ajax/mvc/5.2.3/jquery.validate.unobtrusive.min.js"></script>