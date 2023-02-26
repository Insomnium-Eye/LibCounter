@ModelType List(Of LibCounter.Book)

@Code
    ViewData("Title") = "Book List"
End Code

<h2>Book List</h2>

<table>
    <thead>
        <tr>
            <th>Name</th>
            <th>Author</th>
            <th>User Rating</th>
            <th>Reviews</th>
            <th>Price</th>
            <th>Year</th>
            <th>Genre</th>
        </tr>
    </thead>
    <tbody>
        @For Each book In Model
            @<tr>
                <td>@book.Name</td>
                <td>@book.Author</td>
                <td>@book.UserRating</td>
                <td>@book.Reviews</td>
                <td>@book.Price</td>
                <td>@book.Year</td>
                <td>@book.Genre</td>
            </tr>
        Next
        Next
    </tbody>
</table>

