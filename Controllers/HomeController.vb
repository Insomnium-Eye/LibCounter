Imports LibCounter.Models
Imports System.Data.Entity

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private db As New LibCounterContext()

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function





    <HttpPost>
    Function CheckOut(username As String, bookId As Integer) As ActionResult
        Dim cart As Cart = Session("Cart")
        If cart Is Nothing Then
            cart = New Cart()
        End If
        Dim book As Book = db.Books.Find(bookId)
        If book IsNot Nothing Then
            ViewBag.CheckedOutBook = book.Name
            TempData("CheckedOutBook") = book.Name
            cart.Books.Add(book)
            Session("Cart") = cart
            ViewBag.CartCount = cart.Books.Count
            TempData("Username") = username
        End If
        Return RedirectToAction("Index")
    End Function



    Function Index() As ActionResult
        Dim csvPath As String = Server.MapPath("~/App_Data/Books.csv")
        Dim books As List(Of Book) = Book.GetBooksFromCsv(csvPath)
        ViewBag.CheckedOutBook = TempData("CheckedOutBook")
        ViewBag.Username = TempData("Username")
        Return View(books)
    End Function

    Function CheckedOutBooks() As ActionResult
        Dim cart As Cart = Session("Cart")
        If cart Is Nothing Then
            cart = New Cart()
        End If
        ViewBag.CheckedOutBooks = cart.Books.Select(Function(b) b.Name)
        Return View()
    End Function

    Function Username() As ActionResult
        Return View()
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing) Then
            db.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
