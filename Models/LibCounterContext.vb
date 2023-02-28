Imports System.Data.Entity

Public Class LibCounterContext
    Inherits DbContext

    Public Property Books As DbSet(Of Book)
End Class
