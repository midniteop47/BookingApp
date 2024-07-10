@ModelType BookingApp.BookingData
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>BookingData</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Service)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Service)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.TechName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TechName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ServiceDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ServiceDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ServiceTime)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ServiceTime)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Customer)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Customer)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Address)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Address)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.emial)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.emial)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Phone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Phone)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ServiceTime2)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ServiceTime2)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
