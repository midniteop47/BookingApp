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
        min-height: 350px;
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
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<form>
   
    <button>Save</button>
</form>
<div>


</div>


<div>
@Html.ActionLink("Back to List", "Index")
</div>
