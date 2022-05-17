Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class PhotoController
        Inherits ApiController




        Public Function Getphoto(ByVal id As Guid) As ClsPhotos
            Dim item As New ClsPhotos With {.ID = id}
            item.Read()
            Return item
        End Function

        ' POST: api/File
        Public Sub PostPhoto(<FromBody()> ByVal photo As ClsPhotos)
            photo.Update()
        End Sub

        ' PUT: api/File/5
        Public Sub PutPhoto(ByVal id As Guid, <FromBody()> ByVal photo As ClsPhotos)
            photo.ID = id
            photo.Update()
        End Sub



    End Class
End Namespace