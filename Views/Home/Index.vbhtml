@ModelType List(Of Book)

<h2>Book List</h2>

<table>
    <tr>
        <th>Name</th>
        <th>Author</th>
        <th>User Rating</th>
        <th>Reviews</th>
        <th>Price</th>
        <th>Year</th>
        <th>Genre</th>
        <th></th>
    </tr>

    @For Each book In Model
        @<tr>
            <td>@Html.DisplayFor(Function(modelItem) book.Name)</td>
            <td>@Html.DisplayFor(Function(modelItem) book.Author)</td>
            <td>@Html.DisplayFor(Function(modelItem) book.UserRating)</td>
            <td>@Html.DisplayFor(Function(modelItem) book.Reviews)</td>
            <td>@Html.DisplayFor(Function(modelItem) book.Price)</td>
            <td>@Html.DisplayFor(Function(modelItem) book.Year)</td>
            <td>@Html.DisplayFor(Function(modelItem) book.Genre)</td>
            <td>
                @Using (Html.BeginForm("CheckOut", "Home"))
                    @Html.Hidden("bookId", book.BookId)
                    @<button type="submit">Checkout</button>
                End Using
            </td>
        </tr>
    Next
</table>
