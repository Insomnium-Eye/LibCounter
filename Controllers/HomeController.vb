Imports System.Web.Mvc
Imports System.IO
Imports LibCounter

Public Class HomeController
    Inherits Controller

    Public Function Index() As ActionResult
        Return View()
    End Function

    Public Function GetBooks() As JsonResult
        Dim csvPath As String = Server.MapPath("~/App_Data/books.csv")
        Dim books As List(Of Book) = Book.GetBooksFromCsv(csvPath)
        Return Json(books, JsonRequestBehavior.AllowGet)
    End Function

End Class


