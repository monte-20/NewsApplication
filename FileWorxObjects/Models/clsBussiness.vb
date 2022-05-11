Imports System.Data.SqlClient
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class clsBussiness
    Public Enum BussinessClass
        USER
        NEWS
        PHOTOS
    End Enum
    Protected ReadOnly Property api As New clsApiManager

    Public Property ID() As Guid = Guid.Empty

    Public Property CreationDate() As Date

    Public Property Description() As String = String.Empty

    Public Property Name() As String

    Public Property ClassID() As BussinessClass

    Public Sub Delete()
        Dim apiURL = "https://localhost:44321/api/bussiness/DeleteItem?id=" & ID.ToString
        api.DeleteData(apiURL)
    End Sub

End Class
