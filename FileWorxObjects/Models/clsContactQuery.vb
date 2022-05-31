Imports System.Data.SqlClient
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class clsContactQuery


    Public Property Filter() As New clsBusinessFilter
    Private ReadOnly Property apiUrl As String = "https://localhost:44321/api/Contact/Contacts"
    Private ReadOnly Property api As New clsApiManager

    Public Async Function run() As Task(Of clsListView)
        Dim data As clsListView = Await api.GetAllData(apiUrl, Filter)

        Return data
    End Function



End Class
