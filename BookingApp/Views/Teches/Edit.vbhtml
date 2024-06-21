@code
    If IsNothing(Session("auth")) Then
        Response.RedirectToRoute(New With {.controller = "AuthUsers", .action = "Login"})
    End If
End Code
@ModelType BookingApp.Tech
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<style>
    textarea {
        width: 100%;
        height: 350px;
    }
</style>
<h2>Edit Service Tech</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @<div class="form-horizontal">
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.id)
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Name, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.PostcodeRange, "Post code Range", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextAreaFor(Function(model) model.PostcodeRange, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.PostcodeRange, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<hr />


<h4>Select Services For @Model.Name</h4>
<form action="@Url.Action("Create", "ServiceData", New With {.TechName = Model.Name, .Tid = Model.id, .R = "Y"})" method="post">
    @Html.AntiForgeryToken()
    <div style="display:flex">
        <select id="Service" name="Service" class="form-control" required>
            <!-- Options for the select -->
        </select>
        <input id="Duration" name="Duration" class="form-control" type="text" placeholder="Duration in Hours" />
        <input class="btn btn-default" style="margin-left:5px;" type="submit" value="Append Service" />
    </div>
</form>


<br />
<div>
    <table id="serviceTable" class="table table-responsive table-hover">
        <thead>
            <tr>
                <th>
                    List of Service
                </th>
                <th>
                    
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
            </tr>
        </tbody>
    </table>

</div>
<div style="padding-top:20px">
    @Html.ActionLink("Back to List", "Index")
</div>

<script>
            document.addEventListener('DOMContentLoaded', function () {
                GetServices()
                GetServicesList()
            });

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
            const selectElement = $('#Service'); // Get select element using jQuery

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

 function GetServicesList() {
    $.ajax({
        url: '@Url.Action("ServiceListForTech", "ServiceData")',
        type: 'GET',
        data: { N: '@Model.Name' },
        success: function(response) {
            // Handle success response
            console.log('Response:', response);

            // Clear existing table rows
            $('#serviceTable tbody').empty();

            // Iterate through each service data and populate the table
            $.each(response, function(index, service) {
                 // Construct the delete URL
                var deleteUrl = '@Url.Action("Delete", "ServiceData")' +
                                '?id=' + service.id +
                                '&R=Y&Tid=@Model.id';

                var row = '<tr>' +
                          '<td>' + service.Service + '</td>' +
                          '<td><a href="' + deleteUrl + '">Remove</a></td>' +
                          '</tr>';
                $('#serviceTable tbody').append(row);
            });
        },
        error: function(xhr, status, error) {
            // Handle error response
            console.error('Error:', status, error);
        }
    });
}

</script>