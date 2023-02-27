Imports System.Web.Optimization
Imports System.Data.SQLite
Imports System.IO

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        ' Read books data from CSV and store it in database
        Dim connectionString As String = "Data Source=myDatabase.sqlite;Version=3;"
        Dim dbFilePath As String = Server.MapPath("~/App_Data/myDatabase.sqlite")

        If Not File.Exists(dbFilePath) Then
            SQLiteConnection.CreateFile(dbFilePath)
        End If

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Dim command As New SQLiteCommand("CREATE TABLE IF NOT EXISTS Books (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Author TEXT, [User Rating] REAL, Reviews INTEGER, Price REAL, Year INTEGER, Genre TEXT)", connection)
            command.ExecuteNonQuery()

            Dim books As List(Of Book) = Book.GetBooksFromCsv(Server.MapPath("~/App_Data/books.csv"))
            command = New SQLiteCommand("DELETE FROM Books", connection)
            command.ExecuteNonQuery()
            For Each book As Book In books
                command = New SQLiteCommand("INSERT INTO Books (Name, Author, [User Rating], Reviews, Price, Year, Genre) VALUES (@Name, @Author, @UserRating, @Reviews, @Price, @Year, @Genre)", connection)
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


