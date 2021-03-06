Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class clsContact
    Inherits clsBusiness

    Public Property Username() As String

    Public Property Password() As String
    Public Property Host() As String

    Sub New()
        ClassID = BusinessClass.CONTACT
    End Sub
    Public Async Function Update() As Task
        If CanInsert Then
            Await InsertData()
        Else
            Await UpdateData()
        End If
    End Function
    Private Async Function UpdateData() As Task
        Dim apiURL = "https://localhost:44321/api/Contact/putContact/" & ID.ToString
        Await api.UpdateData(apiURL, Me)
    End Function

    Private Async Function InsertData() As Task
        Dim apiURL = "https://localhost:44321/api/Contact/postContact"
        Await api.InsertData(apiURL, Me)
    End Function

    Public Async Function Read() As Task
        Dim apiURL = "https://localhost:44321/api/Contact/getContact/" & ID.ToString
        Dim responseBody As String = Await api.ReadData(apiURL)
        Dim data As clsContact = JsonConvert.DeserializeObject(Of clsContact)(responseBody)
        CreationDate = data.CreationDate
        Description = data.Description
        Name = data.Name
        ClassID = data.ClassID
        Username = data.Username
        Password = data.Password
        Host = data.Host
    End Function
End Class
