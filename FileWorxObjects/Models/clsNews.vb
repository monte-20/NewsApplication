Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class clsNews
    Inherits clsFile
    Public Enum Categories
        General
        Sports
        Health
        Politics
    End Enum

    Public Property Category() As Categories

    Sub New()
        ClassID = BusinessClass.NEWS
    End Sub

    Public Async Function Update() As Task
        If ID.Equals(Guid.Empty) Then
            Await InsertData()
        Else
            Await UpdateData()
        End If
    End Function

    Private Async Function UpdateData() As Task
        Dim apiURL = "https://localhost:44321/api/news/putnews/" & ID.ToString
        Await api.UpdateData(apiURL, Me)
    End Function

    Private Async Function InsertData() As Task
        Dim apiURL = "https://localhost:44321/api/news/postnews"
        Await api.InsertData(apiURL, Me)
    End Function

    Public Async Function Read() As Task
        Dim apiURL = "https://localhost:44321/api/news/getnews/" & ID.ToString
        Dim responseBody As String = Await api.ReadData(apiURL)
        Dim data As clsNews = JsonConvert.DeserializeObject(Of clsNews)(responseBody)
        CreationDate = data.CreationDate
        Description = data.Description
        Name = data.Name
        ClassID = data.ClassID
        Body = data.Body
        Category = data.Category

    End Function




End Class
