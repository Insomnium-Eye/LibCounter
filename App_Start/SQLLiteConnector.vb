Imports System.Data.SQLite

Public Class SQLiteConnector

    Public Shared Function CreateConnection() As SQLiteConnection
        Dim connectionString As String = "Data Source=myDatabase.sqlite;Version=3;"
        Dim connection As New SQLiteConnection(connectionString)
        connection.Open()
        Return connection
    End Function

    Public Sub ExampleUsage()
        ' create the SQLite connection
        Dim connection As SQLiteConnection = SQLiteConnector.CreateConnection()

        ' create a SQL command
        Dim sql As String = "SELECT * FROM myTable"
        Dim command As New SQLiteCommand(sql, connection)

        ' execute the command and read the results
        Dim reader As SQLiteDataReader = command.ExecuteReader()
        While reader.Read()
            Dim column1 As String = reader.GetString(0)
            Dim column2 As String = reader.GetString(1)
            ' do something with the data
        End While

        ' close the connection
        connection.Close()
    End Sub
End Class
