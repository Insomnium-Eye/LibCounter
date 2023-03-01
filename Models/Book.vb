Imports System.IO

Public Class Book
    Public Property BookId() As Integer
    Public Property Name() As String
    Public Property Author() As String
    Public Property UserRating() As Double
    Public Property Reviews() As Integer
    Public Property Price() As Double
    Public Property Year() As Integer
    Public Property Genre() As String

    Public Sub New()
    End Sub

    Public Sub New(name As String, author As String, userRating As Double, reviews As Integer, price As Double, year As Integer, genre As String)
        Me.Name = name
        Me.Author = author
        Me.UserRating = userRating
        Me.Reviews = reviews
        Me.Price = price
        Me.Year = year
        Me.Genre = genre
    End Sub

    Public Shared Function GetBooksFromCsv(csvPath As String) As List(Of Book)
        Dim books As New List(Of Book)()
        Using reader As New StreamReader(csvPath)
            While Not reader.EndOfStream
                Dim values As String() = reader.ReadLine().Split(",")
                Try
                    Dim book As New Book()
                    book.Name = values(0)
                    book.Author = values(1)
                    book.UserRating = Double.Parse(values(2))
                    book.Reviews = Integer.Parse(values(3))
                    book.Price = Double.Parse(values(4))
                    book.Year = Integer.Parse(values(5))
                    book.Genre = values(6)
                    books.Add(book)
                Catch ex As FormatException
                    Console.WriteLine("Error parsing book data: {0}", ex.Message)
                End Try
            End While
        End Using
        Return books
    End Function
End Class


