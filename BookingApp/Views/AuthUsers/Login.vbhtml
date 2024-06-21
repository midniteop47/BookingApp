@Code
    ViewData("Title") = "Login"
    Layout = "~/Views/Shared/_Layout - Login.vbhtml"

End Code
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

<link rel="stylesheet" href="~/StyleSheetLogin.css">
<div class="main">
    <div style="display: flex; justify-content: center;">
        <img src="//img1.wsimg.com/isteam/ip/02393fd3-2abe-4bd6-a45a-c29e19e65a70/logo%20edits%20new%20copy.jpg/:/rs=h:100,cg:true,m/qt=q:95" />
    </div>
    <h3>Login</h3>
    <form >
        <label for="first">Username:</label>
        <input type="text" id="u" name="u" placeholder="Enter your Username" required>

        <label for="password">Password:</label>
        <input type="password" id="p" name="p" placeholder="Enter your Password" required>
        <div>
            <p id="res"></p>
        </div>
        <div class="wrap">
            <button type="button" onclick="submitForm()">Submit</button>
        </div>
    </form>
</div>

<script>

    console.log('@Html.Raw(ViewBag.res)')
  



    function submitForm() {
    var formData = {
        u: document.getElementById("u").value,
        p: document.getElementById("p").value
    };

    $.ajax({
        url: '@Url.Action("ValidateUserCredentials", "AuthUsers")',
        type: 'POST',
        data: formData,
        success: function(response) {
            // Handle success response
            if (response = "1") {
              window.location.href='@Url.Action("Index", "Home")'
            }
            
        },
        error: function(xhr, status, error) {
            // Handle error response
            console.error('Error:', error);
            document.getElementById("res").innerText = 'Error occurred during login'; // Example error message
        }
    });
}

</script>