@ModelType List(Of LibCounter.Book)

@Code
    ViewData("Title") = "Home Page"
End Code

@Section Scripts
    <script>
        $(function() {
            loadBooks();
        });

        function loadBooks() {
            $.ajax({
                url: '@Url.Action("GetBooks", "Home")',
                type: 'GET',
                success: function(books) {
                    displayBooks(books);
                },
                error: function(xhr, status, error) {
                    console.error(error);
                }
            });
        }

        function displayBooks(books) {
            var $bookList = $('#book-list');
            $bookList.empty();
            books.forEach(function(book) {
                $bookList.append(`<div class="book">
                                    <div class="book-name">${book.Name}</div>
                                    <div class="book-author">${book.Author}</div>
                                    <div class="book-price">${book.Price}</div>
                                    <div class="book-rating">${book.UserRating}</div>
                                 </div>`);
            });
        }

        function searchBooks() {
            var searchTerm = $('#search-box').val();
            $.ajax({
                url: '@Url.Action("SearchBooks", "Home")',
                type: 'GET',
                data: { searchTerm: searchTerm },
                success: function(books) {
                    displayBooks(books);
                },
                error: function(xhr, status, error) {
                    console.error(error);
                }
            });
        }

        function getTopRatedBooks() {
            $.ajax({
                url: '@Url.Action("GetTopRatedBooks", "Home")',
                type: 'GET',
                success: function(books) {
                    displayBooks(books);
                },
                error: function(xhr, status, error) {
                    console.error(error);
                }
            });
        }
    </script>
End Section

<div class="container">
    <div class="row">
        <div class="col-md-12">
            <h1>Books</h1>
            <div class="input-group">
                <input type="text" class="form-control" id="search-box" placeholder="Search by book name">
                <span class="input-group-btn">
                    <button class="btn btn-default" type="button" onclick="searchBooks()">Search</button>
                </span>
            </div>
            <br>
            <div class="btn-group" role="group" aria-label="...">
                <button type="button" class="btn btn-default" onclick="loadBooks()">All Books</button>
                <button type="button" class="btn btn-default" onclick="getTopRatedBooks()">Top Rated Books</button>
            </div>
            <hr>
            <div id="book-list"></div>
        </div>
    </div>
</div>

