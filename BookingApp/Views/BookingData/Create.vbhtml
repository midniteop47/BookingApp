@ModelType BookingApp.BookingData
@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Create</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
    <h4>BookingData</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Service, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Service, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Service, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Description, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Description, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Description, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.TechName, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.TechName, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.TechName, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.ServiceDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.ServiceDate, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.ServiceDate, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.ServiceTime, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.ServiceTime, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.ServiceTime, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Customer, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Customer, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Customer, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Address, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Address, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Address, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Postcode, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Postcode, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Postcode, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.emial, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.emial, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.emial, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Phone, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Phone, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Phone, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.Status, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.Status, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.Status, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div class="form-group">
        @Html.LabelFor(Function(model) model.ServiceTime2, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.EditorFor(Function(model) model.ServiceTime2, New With {.htmlAttributes = New With {.class = "form-control"}})
            @Html.ValidationMessageFor(Function(model) model.ServiceTime2, "", New With {.class = "text-danger"})
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
