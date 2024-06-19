
@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code

@ModelType BookingApp.Product
@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"

End Code

<h2>Product Details</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.LabelFor(Function(model) model.ProductName, "Brand Name", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ProductName, New With {.htmlAttributes = New With {.class = "form-control", .required = "required"}})
                @Html.ValidationMessageFor(Function(model) model.ProductName, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ProductType, "Product Type", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ProductType, New With {.htmlAttributes = New With {.class = "form-control", .required = "required"}})
                @Html.ValidationMessageFor(Function(model) model.ProductType, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.SubCatagoty, "Sub Catagoty", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SubCatagoty, New With {.htmlAttributes = New With {.class = "form-control", .required = "required"}})
                @Html.ValidationMessageFor(Function(model) model.SubCatagoty, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ServiceType, "Service Type", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ServiceType, New With {.htmlAttributes = New With {.class = "form-control", .required = "required"}})
                @Html.ValidationMessageFor(Function(model) model.ServiceType, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Cost, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Cost, New With {.htmlAttributes = New With {.class = "form-control", .required = "required"}})
                @Html.ValidationMessageFor(Function(model) model.Cost, "", New With {.class = "text-danger"})
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
