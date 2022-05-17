Imports System.Data.SqlClient
Imports System.IO
Imports Newtonsoft.Json

Public Class clsPhotos
    Inherits clsFile

    Sub New()
        ClassID = BusinessClass.PHOTOS
    End Sub


    Public Property Photo() As String



    Public Async Function Update() As Task
        If ID.Equals(Guid.Empty) Then
            Await InsertData()
        Else
            Await UpdateData()
        End If
    End Function

    Private Async Function UpdateData() As Task
        Dim apiURL = "https://localhost:44321/api/photo/putphoto/" & ID.ToString
        Await api.UpdateData(apiURL, Me)
    End Function

    Private Async Function InsertData() As Task
        Dim apiURL = "https://localhost:44321/api/photo/postphoto"
        Await api.InsertData(apiURL, Me)
    End Function

    Public Async Function Read() As Task
        Dim apiURL = "https://localhost:44321/api/photo/getphoto/" & ID.ToString
        Dim responseBody As String = Await api.ReadData(apiURL)
        Dim data As clsPhotos = JsonConvert.DeserializeObject(Of clsPhotos)(responseBody)
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
