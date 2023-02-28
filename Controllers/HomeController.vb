Imports System.Web.Mvc
Imports System.IO.File
Imports LibCounter

Public Class HomeController
    Inherits Controller

    Public Function Index() As ActionResult
        Return View()
    End Function

    Public Function GetBooks() As JsonResult
        Dim csvPath As String = Server.MapPath("~/App_Data/books.csv")
        Dim lines As String() = System.IO.File.ReadAllLines(csvPath)

        Dim books As List(Of Book) = New List(Of Book)

        For i As Integer = 1 To lines.Length - 1
            Dim values As String() = lines(i).Split(","c)
            Try
                Dim book As Book = New Book(
            values(0),
            values(1),
            Double.Parse(values(2)),
            Integer.Parse(values(3)),
            Double.Parse(values(4)),
            Integer.Parse(values(5)),
            values(6)
        )
                books.Add(book)
            Catch ex As Exception
                Debug.WriteLine($"Error parsing line {i}: {ex.Message}")
                Debug.WriteLine($"Values: {String.Join(",", values)}")
            End Try
        Next

        Return Json(books, JsonRequestBehavior.AllowGet)
    End Function



    Public Function SearchBooks(searchTerm As String) As JsonResult
        Dim csvPath As String = Server.MapPath("~/App_Data/books.csv")
        Dim books As List(Of Book) = Book.GetBooksFromCsv(csvPath)
        Dim filteredBooks As List(Of Book) = books.Where(Function(book) book.Name.IndexOf(searchTerm, StringComparison.InvariantCultureIgnoreCase) >= 0).ToList()
        Return Json(filteredBooks, JsonRequestBehavior.AllowGet)
    End Function

    Public Function GetTopRatedBooks() As JsonResult
        Dim csvPath As String = Server.MapPath("~/App_Data/books.csv")
        Dim books As List(Of Book) = Book.GetBooksFromCsv(csvPath)
        Dim topRatedBooks As List(Of Book) = books.OrderByDescending(Function(book) book.UserRating).Take(10).ToList()
        Return Json(topRatedBooks, JsonRequestBehavior.AllowGet)
    End Function
End Class


