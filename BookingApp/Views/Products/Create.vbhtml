
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
<style>
    textarea {
        height: 150px;
        width: 100%;
    }
</style>
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
            <select class="form-control" id="ServiceType" name="ServiceType">
            </select>
            @Html.ValidationMessageFor(Function(model) model.ServiceType, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(model) model.Note, htmlAttributes:=New With {.class = "control-label col-md-2"})
        <div class="col-md-10">
            @Html.TextAreaFor(Function(model) model.Note, New With {.htmlAttributes = New With {.class = "form-control", .required = "required"}})
            @Html.ValidationMessageFor(Function(model) model.Note, "", New With {.class = "text-danger"})
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
<script>

         function GetServices() {
            $.ajax({
                    url: '@Url.Action("ServiceList", "Services")',
            type: 'GET',
            success: function(response) {
                        // Handle success response
                        console.log('Response:', response);

                        // Call populateSelect function with the response data to populate the select element
                        populateSelect(response);
                    },
                    error: function(xhr, status, error) {
                        // Handle error response
                        console.error('Error:', status, error);
                    }
                });
        }

        function populateSelect(services) {
            const selectElement = $('#ServiceType'); // Get select element using jQuery

            // Clear existing options
            selectElement.empty();

            // Create a default option
            const defaultOption = $('<option>').text('Select a service').val('');
            selectElement.append(defaultOption);

            // Iterate over the array of services and create an option for each one
            services.forEach(service => {
                // Assuming each service object has 'id' and 'Service1' properties
                const option = $('<option>').text(service.Service1).val(service.Service1);
                selectElement.append(option);
            });
    }

    document.addEventListener('DOMContentLoaded', function () {
        GetServices()
        GetServicesList()
    });

</script>