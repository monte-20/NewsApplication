Imports System.Data.SqlClient
Imports System.IO
Imports Newtonsoft.Json

Public Class ClsPhotos
    Inherits clsFile

    Sub New()
        ClassID = BussinessClass.PHOTOS
    End Sub


    Public Property Photo() As String

    Private Sub CopyPhoto()
        Dim directoryPath = clsShared.PhotosPath
        Dim path As String = directoryPath & ID.ToString
        path &= Photo.Substring(Photo.LastIndexOf("."))
        If Not Directory.Exists(directoryPath) Then
            Directory.CreateDirectory(directoryPath)
        End If
        If Not path.Equals(Photo) Then
            File.Copy(Photo, path, True)
            Photo = path
        End If
    End Sub

    Public Sub Update()
        If ID.Equals(Guid.Empty) Then
            InsertData()
        Else
            UpdateData()
        End If
        CopyPhoto()
    End Sub

    Private Sub UpdateData()
        Dim apiURL = "https://localhost:44321/api/photo/putphoto/" & ID.ToString
        api.UpdateData(apiURL, Me)
    End Sub

    Private Sub InsertData()
        Dim apiURL = "https://localhost:44321/api/photo/postphoto"
        api.InsertData(apiURL, Me)
    End Sub

    Public Async Function Read() As Task
        Dim apiURL = "https://localhost:44321/api/photo/getphoto/" & ID.ToString
        Dim responseBody As String = Await api.ReadData(apiURL)
        Dim data As ClsPhotos = JsonConvert.DeserializeObject(Of ClsPhotos)(responseBody)
        CreationDate = data.CreationDate
        Description = data.Description
        Name = data.Name
        ClassID = data.ClassID
        Body = data.Body
        Photo = data.Photo
    End Function
    Public Sub DeletePhoto()
        If File.Exists(Photo) Then
            File.Delete(Photo)
        End If
    End Sub
End Class
