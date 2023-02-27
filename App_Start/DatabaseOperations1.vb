Imports System.Data.SQLite

Public Class DatabaseOperations
    Private ReadOnly connectionString As String

    Public Sub New()
        connectionString = "Data Source=myDatabase.sqlite;Version=3;"
    End Sub

    Public Function AddBook(name As String, author As String, rating As Double, reviews As Integer, price As Double, year As Integer, genre As String) As Integer
        Using connection = New SQLiteConnection(connectionString)
            connection.Open()

            Dim sql = "INSERT INTO Books (Name, Author, [User Rating], Reviews, Price, Year, Genre) VALUES (@name, @author, @rating, @reviews, @price, @year, @genre)"
            Using command = New SQLiteCommand(sql, connection)
                command.Parameters.AddWithValue("@name", name)
                command.Parameters.AddWithValue("@author", author)
                command.Parameters.AddWithValue("@rating", rating)
                command.Parameters.AddWithValue("@reviews", reviews)
                command.Parameters.AddWithValue("@price", price)
                command.Parameters.AddWithValue("@year", year)
                command.Parameters.AddWithValue("@genre", genre)

                Return command.ExecuteNonQuery()
            End Using
        End Using
    End Function


    Public Function AddUser(uniqueId As String, username As String, bookCount As Integer) As Integer
        Using connection = New SQLiteConnection(connectionString)
            connection.Open()

            Dim sql = "INSERT INTO Users (UniqueId, Username, BookCount) VALUES (@uniqueId, @username, @bookCount)"
            Using command = New SQLiteCommand(sql, connection)
                command.Parameters.AddWithValue("@uniqueId", uniqueId)
                command.Parameters.AddWithValue("@username", username)
                command.Parameters.AddWithValue("@bookCount", bookCount)

                Return command.ExecuteNonQuery()
            End Using
        End Using
    End Function
End Class
