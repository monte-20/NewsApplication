Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class ClsNews
    Inherits clsFile
    Public Enum Categories
        General
        Sports
        Health
        Politics
    End Enum

    Public Property Category() As Categories

    Sub New()
        ClassID = BussinessClass.NEWS
    End Sub

    Public Sub Update()
        If ID.Equals(Guid.Empty) Then
            InsertData()
        Else
            UpdateData()
        End If
    End Sub

    Private Sub UpdateData()
        Dim apiURL = "https://localhost:44321/api/news/putnews/" & ID.ToString
        api.UpdateData(apiURL, Me)
    End Sub

    Private Sub InsertData()
        Dim apiURL = "https://localhost:44321/api/news/postnews"
        api.InsertData(apiURL, Me)
    End Sub

    Public Async Function Read() As Task
        Dim apiURL = "https://localhost:44321/api/news/getnews/" & ID.ToString
        Dim responseBody As String = Await api.ReadData(apiURL)
        Dim data As ClsNews = JsonConvert.DeserializeObject(Of ClsNews)(responseBody)
        CreationDate = data.CreationDate
        Description = data.Description
        Name = data.Name
        ClassID = data.ClassID
        Body = data.Body
        Category = data.Category

    End Function




End Class
