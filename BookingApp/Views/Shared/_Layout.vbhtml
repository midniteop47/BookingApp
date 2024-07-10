<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - CDS Appliances</title>
    <link rel="shortcut icon" type="image/x-icon" href="~/favicon.ico" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    <style>
        body {
            font-family: 'Segoe UI';
        }
    </style>
</head>

<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("CDS", "Index", "Home", New With {.area = "  "}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>@Html.ActionLink("Booking", "Index", "BookingData")</li>
                    <li>@Html.ActionLink("Service Techs", "Index", "Teches")</li>
                    <li>@Html.ActionLink("Products", "Index", "Products")</li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Settings <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li>@Html.ActionLink("Admin Users", "Index", "AuthUsers")</li>
                            <li>@Html.ActionLink("Services", "Index", "Services")</li>
                        </ul>
                    </li>
                </ul>
                <ul class="nav navbar-nav" style="float:right;">
                    <li>@Html.ActionLink("Logout", "Logout", "AuthUsers")</li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year</p>
        </footer>
    </div>
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
