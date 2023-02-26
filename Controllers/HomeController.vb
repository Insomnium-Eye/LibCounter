

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Public Function Index() As ActionResult
        Dim books As List(Of Book) = Book.GetBooksFromCsv(Server.MapPath("~/Data/book.csv"))
        Return View(books)

    End Function


    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
