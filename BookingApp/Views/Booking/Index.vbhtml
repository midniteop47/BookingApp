@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout -Booking.vbhtml"
End Code


<link rel="shortcut icon" type="image/x-icon" href="~/favicon.ico" />
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
@Styles.Render("~/Content/css")
@Scripts.Render("~/bundles/modernizr")
<style>
    body {
        margin: 0;
        padding-top: 0;
    }
</style>

<div style="min-height:500px">
    <div class="form-horizontal">
        <div>
            <label>Postcode</label>
            <input id="post" class="form-control" name="post" type="number" />
        </div>
        <br />
        <div>
            <label>Service</label>
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
            <label>Product</label>
            <select class="form-control" id="Prod">
            </select>
            <br />
            <ul id="list" style="display:none">              
                <li id="Note"></li>
                <li id="Cost"></li>
            </ul>
        </div>
        <br />
        <input type="button" class="form-control" style="background-color: rgb(32, 143, 227); color:white;" id="check" value="Check Availability" />
    </div>
   <br />
    <div>
        <hr />
        <div id="result">

        </div>
    </div>    
</div>
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
        GetServicesList()
    });
</script>