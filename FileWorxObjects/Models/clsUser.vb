Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class clsUser
    Inherits clsBusiness

    Public Property Username() As String

    Public Property Password() As String

    Sub New()
        ClassID = BusinessClass.USER
    End Sub
    Public Async Function Update() As Task
        If CanInsert Then
            Await InsertData()
        Else
            Await UpdateData()
        End If
    End Function
    Private Async Function UpdateData() As Task
        Dim apiURL = "https://localhost:44321/api/user/putuser/" & ID.ToString
        Await api.UpdateData(apiURL, Me)
    End Function

    Private Async Function InsertData() As Task
        Dim apiURL = "https://localhost:44321/api/user/postuser"
        Await api.InsertData(apiURL, Me)
    End Function

    Public Async Function Read() As Task
        Dim apiURL = "https://localhost:44321/api/user/getuser/" & ID.ToString
        Dim responseBody As String = Await api.ReadData(apiURL)
        Dim data As clsUser = JsonConvert.DeserializeObject(Of clsUser)(responseBody)
        CreationDate = data.CreationDate
        Description = data.Description
        Name = data.Name
        ClassID = data.ClassID
        Username = data.Username
        Password = data.Password
    End Function
End Class
