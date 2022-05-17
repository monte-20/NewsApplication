Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class NewsController
        Inherits ApiController




        Public Function GetNews(ByVal id As Guid) As ClsNews
            Dim item As New ClsNews With {.ID = id}
            item.Read()
            Return item
        End Function

        Public Sub PostNews(<FromBody()> ByVal news As ClsNews)
            news.Update()
        End Sub

        Public Sub PutNews(ByVal id As Guid, <FromBody()> ByVal news As ClsNews)
            news.ID = id
            news.Update()
        End Sub

    End Class
End Namespace