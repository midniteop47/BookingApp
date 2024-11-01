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
<style>

    /* The Modal (background) */
    .modal {
        display: none; /* Hidden by default */
        position: fixed; /* Stay in place */
        z-index: 1; /* Sit on top */
        padding-top: 100px; /* Location of the box */
        left: 0;
        top: 0;
        border-radius: 10px;
        width: 100%; /* Full width */
        height: 100%; /* Full height */
        overflow: auto; /* Enable scroll if needed */
        background-color: rgb(0,0,0); /* Fallback color */
        background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
    }

    /* Modal Content */
    .modal-content {
        background-color: #fefefe;
        border-radius: 10px;
        margin: auto;
        padding: 20px;
        border: 1px solid #888;
        width: 80%;
    }

    /* The Close Button */
    .close {
        color: #aaaaaa;
        float: right;
        font-size: 28px;
        font-weight: bold;
    }

        .close:hover,
        .close:focus {
            color: #000;
            text-decoration: none;
            cursor: pointer;
        }
</style>


<div style="min-height:500px">
    <div class="form-horizontal">
        <div>
            <label>Service Date</label>
            <input id="Servicedate" class="form-control" name="ServiceDate" type="date" />
        </div>
        <br />
        <div>
            <label>Postcode</label>
            <input id="postcode" class="form-control" name="post" type="number" />
        </div>
        <br />
        <div id="brand">
            <label>Brand Name</label>
            <select class="form-control" id="Brand">
            </select>
            <br />
            <label>Product</label>
            <select class="form-control" id="Prod">
            </select>
            <br />
            <label>Product Type</label>
            <select class="form-control" id="ProdType">
            </select>
            <br />
            <label>Service</label>
            <select class="form-control" id="Service">
                <option value="">Select a Service</option>
                <option value="Diagnose and fix issue">Diagnose and fix issue</option>
                <option value="Install and remove old machine">Install and remove old machine</option>
            </select>
            <p id="datares"></p>
            <br />
            <ul id="list" style="display:none">
                <li id="Note"></li>
                <li id="Cost"></li>
            </ul>
        </div>
        <br />
        <input type="button" class="form-control" style="background-color: rgb(32, 143, 227); color:white;" id="check" value="Check Availability" onclick="checkAvailability('3053','Install and remove old machine','2024-11-01')" />
    </div>
    <br />
    <div>
        <hr />
        <div id="result">
            <p id="r"></p>
            <table class=" = table table-striped">
                <tbody>
                </tbody>
            </table>
        </div>
    </div>
</div>
<div>
    <div id="bookingModal" class="modal">
        <div class="modal-content">
            <span class="close">&times;</span>
            <h2>Service Booking</h2>
            <p id="t"></p>
            <form id="bookingForm">
                <div class="form-group">
                    <label for="customer">Name:</label>
                    <input type="text" id="customer" name="Customer" class="form-control" required>
                </div>

                <div class="form-group">
                    <label for="address">Address:</label>
                    <input type="text" id="address" name="Address" class="form-control" required>
                </div>

                <div class="form-group">
                    <label for="email">Email:</label>
                    <input type="email" id="email" name="email" class="form-control" required>
                </div>

                <div class="form-group">
                    <label for="phone">Phone:</label>
                    <input type="tel" id="phone" name="Phone" class="form-control" required>
                </div>
                <div class="form-group">
                    <label for="description">Description of Issue:</label>
                    <textarea id="description" name="Description" class="form-control" required></textarea>
                </div>
                <button type="submit" class="btn btn-primary">Book Service</button>
            </form>
        </div>
    </div>
</div>
<script>
    var modal = document.getElementById("bookingModal");
    var span = document.getElementsByClassName("close")[0];
    var Productdata = {}
    /*function GetServices() {
    var prod = document.getElementById("Prod").value.trim();
    console.log(prod);

    $.ajax({
        url: 'Url.Action("ServiceList", "Services")',
        type: 'GET',
        data: { P: prod }, // Change 'Data' to 'data'
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
    })
};
    function populateSelectS(services) {
            const selectElement = $('#Service'); // Get select element using jQuery
        console.log(services)
            // Clear existing options
            selectElement.empty();

            // Create a default option
            const defaultOption = $('<option>').text('Select a service').val('');
            selectElement.append(defaultOption);

            // Iterate over the array of services and create an option for each one
            services.forEach(service => {
                // Assuming each service object has 'id' and 'Service1' properties
                const option = $('<option>').text(service).val(service);
                selectElement.append(option);
            });
    }*/
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
    function populateSelectD(Prods) {
        const selectElement4 = $('#ProdType');
        selectElement4.empty();
        // Create a default option
        const defaultOption = $('<option>').text('Select a Product Type').val('');
        selectElement4.append(defaultOption);
        Prods.forEach(Prod => {
            const option = $('<option>').text(Prod).val(Prod);
            selectElement4.append(option);
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
    function GetProductSub(a,b) {
        var jdata ={
            brand:a,
            product :b
        }
         $.ajax({
              url: '@Url.Action("GetProdsSub", "Products")',
             type: 'GET',
             data: jdata,
              success: function(response) {
                  Productdata = response
                  console.log("sub", Productdata)
                  populateSelectD(response);
              },
              error: function(xhr, status, error) {
                  console.error('Error:', status, error);
              }
          });
  }
    function GetProdCost(x, y, z) {
    var jdata = {
        a: x,
        b: y,
        c: z
    };

    $.ajax({
        url: '@Url.Action("GetCost", "Products")',
        type: 'GET',
        data: jdata,
        success: function(response) {
            console.log("Cost and Note Data:", response);
            if (response.length > 0) {
                populateListItems(response[0]);
            } else {
                console.log("No products found.");
            }
        },
        error: function(xhr, status, error) {
            console.error('Error:', status, error);
        }
    });
}
    $(document).ready(function () {
        var brand
        var Prod
        $('#Brand').change(function () {
            if ($(this).val() !== "") {
                //clearItems()
                var brand = document.getElementById("Brand").value.trim();
                clearItems()
                GetProducts(brand)
            } else {

            }
        });
        $('#Prod').change(function () {
            if ($(this).val() !== "") {
                var brand = document.getElementById("Brand").value.trim();
                var Prod = document.getElementById("Prod").value.trim();
                clearItems()
                GetProductSub(brand, Prod)
                $('#datares').show();
            } else {
                $('#datares').hide();
            }
        });
        $('#Service').change(function () {
            if ($(this).val() !== "") {
                var brand = document.getElementById("Brand").value.trim();
                var ProdType = document.getElementById("ProdType").value.trim();
                var Prod = document.getElementById("Prod").value.trim();
                GetProdCost(brand, Prod, ProdType)

                $('#list').show();
            } else {

                $('#list').hide();
            }
        });

    });
    function populateListItems(product) {


        var Note = document.getElementById("Note");
        var costLi = document.getElementById("Cost");


        Note.textContent =  product.Note
        costLi.textContent = 'Cost : ' +product.Cost
        document.getElementById("list").style.display='block'
    }
    function clearItems() {

        var Note = document.getElementById("Note");
        var costLi = document.getElementById("Cost");

        Note.textContent = ''
        costLi.textContent = ''
        document.getElementById("list").style.display = 'none'
    }
    document.addEventListener('DOMContentLoaded', function () {
        GetBrand()
        GetProducts()
        GetProductSub()
    });
</script>

<script>
function CheckData() {
        var postcode = $('#postcode').val();
        var brand = $('#Brand').val();
        var product = $('#Prod').val();
        var productType = $('#ProdType').val();
        var service = $('#Service').val();

        var missingFields = [];
        if (!postcode) {
            missingFields.push("Post code");
        }
        if (!brand) {
            missingFields.push("Brand Name");
        }
        if (!product) {
            missingFields.push("Product");
        }
        if (!productType) {
            missingFields.push("Product Type");
        }
        if (!service) {
            missingFields.push("Service");
        }

        if (missingFields.length > 0) {
            alert("Please fill in the following fields:\n- " + missingFields.join("\n- "));
            return false;
        } else {
            var jdata = {
                postcode: postcode,
                brand: brand,
                product: product,
                productType: productType,
                service: service
            };

            return  jdata
        }
    }
function checkAvailability(postcode, service, ServiceDate) {
     var sdate = document.getElementById("Servicedate").value
     console.log(sdate)
         $.ajax({
             url: '@Url.Action("CheckAvailability", "Booking")',
             type: 'GET',
             data: {
                 P: postcode,
                 S: service,
                 D: sdate
             },
             success: function(response) {
                 console.log("Response from server:", response);
                 populateTable(response)

             },
             error: function(xhr, status, error) {
                 console.error('Error:', status, error);
             }
         });
 }
 function populateTable(data) {
        const tableBody = $('#result table tbody');
        document.getElementById('r').innerHTML = ''
        tableBody.empty();

        if (data === "No available slots") {
            document.getElementById('r').innerHTML = "No available bookings. Please contact Christy on 04xx xxx xxx.";
        } else {
            const availableSlots = data.AvailableSlots;
            const techName = data.Tech;

            availableSlots.forEach(slot => {
                const row = `
            <tr>
                <td>${slot}</td>
                <td>
                    <button class="btn btn-primary" onclick="performAction('${slot}', '${techName}')">Proceed</button>
                </td>
            </tr>`;
                tableBody.append(row);
            });
        }
    }
 function performAction(Time, name) {
     console.log("Performing action:", Time + ' ' + name);
     showmodel(Time, name);
 }
 function showmodel(time, name) {
     document.getElementById("t").innerHTML='Booking time :' +time
     modal.style.display = "block";
 }
 span.onclick = function () {
     modal.style.display = "none";
 }
 window.onclick = function (event) {
     if (event.target == modal) {
         modal.style.display = "none";
     }
 }

</script>