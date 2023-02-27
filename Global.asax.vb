Imports System.Web.Optimization
Imports System.Data.SqlClient
Imports System.IO

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        ' Read books data from CSV and store it in database
        Dim connectionString As String = "Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=MyLocalDatabase;Integrated Security=True"

        Dim books As List(Of Book) = Book.GetBooksFromCsv(Server.MapPath("~/App_Data/books.csv"))
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim command As New SqlCommand("TRUNCATE TABLE Books", connection)
            command.ExecuteNonQuery()
            For Each book As Book In books
                command = New SqlCommand("INSERT INTO Books (Name, Author, UserRating, Reviews, Price, Year, Genre) VALUES (@Name, @Author, @UserRating, @Reviews, @Price, @Year, @Genre)", connection)
                command.Parameters.AddWithValue("@Name", book.Name)
                command.Parameters.AddWithValue("@Author", book.Author)
                command.Parameters.AddWithValue("@UserRating", book.UserRating)
                command.Parameters.AddWithValue("@Reviews", book.Reviews)
                command.Parameters.AddWithValue("@Price", book.Price)
                command.Parameters.AddWithValue("@Year", book.Year)
                command.Parameters.AddWithValue("@Genre", book.Genre)
                command.ExecuteNonQuery()
            Next
        End Using

    End Sub
End Class
