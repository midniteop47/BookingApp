@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout -Booking.vbhtml"
End Code

<!-- Bootstrap CSS -->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
<link rel="shortcut icon" type="image/x-icon" href="~/favicon.ico" />
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
@Styles.Render("~/Content/css")
@Scripts.Render("~/bundles/modernizr")
<style>
    body {
        margin: 0;
        padding-top: 0;
    }
</style>
<style>
    /* Styling for modal */
    .modal {
        display: none; /* Hidden by default */
        position: fixed; /* Stay in place */
        z-index: 1; /* Sit on top */
        left: 0;
        top: 0;
        width: 100%; /* Full width */
        height: 100%; /* Full height */
        overflow: auto; /* Enable scroll if needed */
        background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        padding-top: 50px; /* 50px from top */
    }

    /* Modal content */
    .modal-content {
        background-color: #fefefe;
        margin: auto;
        padding: 20px;
        border: 1px solid #888;
        width: 80%;
        max-width: 600px;
        text-align: center;
        border-radius: 10px;
    }

    /* Close button */
    .close {
        color: #aaa;
        float: right;
        font-size: 28px;
        font-weight: bold;
    }

        .close:hover,
        .close:focus {
            color: black;
            text-decoration: none;
            cursor: pointer;
        }
</style>
<div style="min-height:500px">
    <div class="form-horizontal">
        <div>
            <label>Your Postcode</label>
            <input id="post" class="form-control" name="post" type="number" />
        </div>
        <br />
        <div>
            <label>How Can We Help</label>
            <select class="form-control" id="Service">
            </select>
            <p id="datares"></p>
        </div>
        <br />
        <div id="brand" style="display:none">
            <label>Brand Name</label>
            <select class="form-control" id="Brand">
            </select>
            <br />
            <label>Appliance Type</label>
            <select class="form-control" id="Prod">
            </select>
            <br />
            <label>Additional Requirements </label>
            <select class="form-control" id="addreq">
            </select>
            <br />
            <ul id="list" style="display:none">
                <li id="Note"></li>
                <li id="Cost"></li>
            </ul>
        </div>
        <br />
        <input type="button" class="form-control" onclick="openModal()" style="background-color: rgb(32, 143, 227); color:white;" id="check" value="Check Availability" />

    </div>
    <br />
    <div>
        <hr />
        <div id="result">

        </div>
    </div>
</div>

<div id="myModal" class="modal">  
    <div class="modal-content">
        <div class="modal-header">
            <h2>Enter Details</h2>
            <span class="close" onclick="closeModal()">&times;</span>
        </div>
        <div class="modal-body">
            <form id="bookingForm" action="@Url.Action("Create", "BookingData")" method="post" enctype="multipart/form-data">
                @Html.AntiForgeryToken()

                <label for="Service">Service:</label>
                <input type="text" id="Service" name="Service" required><br><br>

                <label for="Description">Description:</label>
                <input type="text" id="Description" name="Description" required><br><br>

                <label for="TechName">Tech Name:</label>
                <input type="text" id="TechName" name="TechName" required><br><br>

                <label for="ServiceDate">Service Date:</label>
                <input type="date" id="ServiceDate" name="ServiceDate" required><br><br>

                <label for="ServiceTime">Service Time:</label>
                <input type="time" id="ServiceTime" name="ServiceTime" required><br><br>

                <label for="BrandName">Brand Name:</label>
                <input type="text" id="BrandName" name="BrandName" required><br><br>
                <label for="ApplianceType">Type:</label>
                <input type="text" id="ApplianceType" name="ApplianceType" required><br><br>
                <label for="AdditionalReq">Additional Req:</label>
                <input type="text" id="AdditionalReq" name="AdditionalReq" required><br><br>
      

                <label for="Customer">Customer:</label>
                <input type="text" id="Customer" name="Customer" required><br><br>

                <label for="Address">Address:</label>
                <input type="text" id="Address" name="Address" required><br><br>

                <label for="emial">Email:</label>
                <input type="email" id="emial" name="emial" required><br><br>

                <label for="Phone">Phone:</label>
                <input type="text" id="Phone" name="Phone" required><br><br>

                <label for="Status">Status:</label>
                <input type="text" id="Status" name="Status"><br><br>

                <label for="Postcode">Postcode:</label>
                <input type="text" id="PostCode" name="PostCode" required><br><br>

                <div class="modal-footer">
                    <button type="submit" class="btn btn-default">Save</button>
                </div>
            </form>
            
        </div>
        <div class="modal-footer">
          
        </div>      
       
    </div>

</div>

<script>   
    var modal = document.getElementById('myModal');    
    function openModal() {
        modal.style.display = 'block';
    }       
    function closeModal() {
        modal.style.display = 'none';
    }   
    window.onclick = function (event) {
        if (event.target == modal) {
            closeModal();
        }
    }
</script>
<script>
    

    var Productdata = {}
    function GetServices() {
            $.ajax({
                url: '@Url.Action("ServiceList", "Services")',
                type: 'GET',
                success: function(response) {
                            // Handle success response
                            console.log('Services:', response);

                            // Call populateSelect function with the response data to populate the select element
                        populateSelectS(response);
                    },
                error: function(xhr, status, error) {
                    // Handle error response
                    console.error('Error:', status, error);
                }
            });
    }
    function GetBrand() {
           $.ajax({
                url: '@Url.Action("GetBrands", "Products")',
                  type: 'GET',
                success: function(response) {
                    Productdata = response
                    console.log("Brands", Productdata)
                        populateSelectB(response);
                },
                error: function(xhr, status, error) {
                    console.error('Error:', status, error);
                }
            });
    }
    function GetProducts() {
           $.ajax({
                url: '@Url.Action("GetProdsType", "Products")',
                  type: 'GET',
                success: function(response) {
                    Productdata = response
                    console.log("Products", Productdata)
                        populateSelectC(response);
                },
                error: function(xhr, status, error) {
                    console.error('Error:', status, error);
                }
            });
    }
    function populateSelectS(services) {
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
    function populateSelectB(Brands) {
        const selectElement2 = $('#Brand');
        selectElement2.empty();
        // Create a default option
        const defaultOption = $('<option>').text('Select a Brand').val('');
        selectElement2.append(defaultOption);
            Brands.forEach(Brand => {
            const option = $('<option>').text(Brand).val(Brand);
            selectElement2.append(option);
        });
    }
    function populateSelectC(Prods) {
        const selectElement3 = $('#Prod');
        selectElement3.empty();
        // Create a default option
        const defaultOption = $('<option>').text('Select a Product').val('');
        selectElement3.append(defaultOption);
        Prods.forEach(Prod => {
            const option = $('<option>').text(Prod).val(Prod);
            selectElement3.append(option);
        });
    }
    function populateSelectD(Add) {
        const selectElement4 = $('#addreq');
        selectElement4.empty();
        // Create a default option
        const defaultOption = $('<option>').text('Select a Product').val('');
        selectElement4.append(defaultOption);
        ADDs.forEach(add => {
            const option = $('<option>').text(add).val(add);
            selectElement4.append(option);
        });
    }
    function GetProds(a,b,c) {
        var jdata = {
            a: a,
            b: b,
            c: c
        }
            $.ajax({
                    url: '@Url.Action("GetProd", "Products")',
                    type: 'GET',
                    data : jdata,
                    success: function(response) {
                        Productdata = response
                        console.log("data", Productdata)
                        if (Productdata.length > 0) {
                            populateListItems(Productdata[0]);
                        } else {

                        }

                    },
                    error: function(xhr, status, error) {
                        console.error('Error:', status, error);
                    }
                });
    }   
    function populateListItems(product) {
        // Get references to <li> elements

        var Note = document.getElementById("Note");
        var costLi = document.getElementById("Cost");

        // Populate <li> elements with data
        Note.textContent =  product.Note
        costLi.textContent = 'Cost : ' +product.Cost
        document.getElementById("list").style.display='block'
    }
    function clearItems() {
        // Get references to <li> elements

        var Note = document.getElementById("Note");
        var costLi = document.getElementById("Cost");

        // Populate <li> elements with data
        Note.textContent = ''
        costLi.textContent = ''
        document.getElementById("list").style.display = 'none'
    }
    document.addEventListener('DOMContentLoaded', function () {
        GetServices()
        //GetServicesList()
    });
    $(document).ready(function () {
        $('#Service').change(function () {
            if ($(this).val() !== "") {
                GetBrand()

                $('#brand').show();
            } else {
                $('#brand').hide();
            }
        });
        $('#Brand').change(function () {
            if ($(this).val() !== "") {
                clearItems()
                GetProducts()
            } else {

            }
        });
        $('#Prod').change(function () {
            if ($(this).val() !== "") {
                var brand = document.getElementById("Brand").value.trim();
                var servicetype = document.getElementById("Service").value.trim();
                var Prodtype = document.getElementById("Prod").value.trim();
                GetProds(brand, Prodtype, servicetype)
                $('#datares').show();
            } else {

                $('#datares').hide();
            }
        });

    });

</script>