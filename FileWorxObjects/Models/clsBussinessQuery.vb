
Public Class clsBussinessQuery
    Public Property Filter() As New clsBussinessFilter
    Private ReadOnly Property apiUrl As String = "https://localhost:44321/api/bussiness/bussinessitems"
    Private ReadOnly Property api As New clsApiManager

    Public Async Function run() As Task(Of clsListView)
        Dim data As clsListView = Await api.GetAllData(apiUrl, Filter)

        Return data
    End Function



End Class
