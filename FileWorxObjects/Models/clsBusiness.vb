Imports System.Data.SqlClient
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class clsBusiness
    Public Enum BusinessClass
        USER
        NEWS
        PHOTOS
    End Enum
    Protected ReadOnly Property api As New clsApiManager

    Public Property ID() As Guid = Guid.Empty

    Public Property CreationDate() As Date

    Public Property Description() As String = String.Empty

    Public Property Name() As String

    Public Property ClassID() As BusinessClass

    Public Async Function Delete() As Task
        Dim apiURL = "https://localhost:44321/api/bussiness/DeleteItem?id=" & ID.ToString
        Await api.DeleteData(apiURL)
    End Function

End Class
