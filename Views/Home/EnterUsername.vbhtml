@ModelType String

@Code
    ViewData("Title") = "Enter Username"
End Code

<h2>Please enter your username:</h2>

@Using (Html.BeginForm("CheckOut", "Home", FormMethod.Post))
    @Html.ValidationSummary(True)

    @<div Class="form-group">
        @Html.LabelFor(Function(model) model, New With {.class = "control-label"})
        @Html.EditorFor(Function(model) model, New With {.class = "form-control"})
        @Html.ValidationMessageFor(Function(model) model)
    </div>

    @<button type="submit" class="btn btn-default">Submit</button>
End Using