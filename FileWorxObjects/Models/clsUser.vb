Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class ClsUser
    Inherits clsBussiness

    Public Property Username() As String

    Public Property Password() As String

    Sub New()
        ClassID = BussinessClass.USER
    End Sub
    Public Sub Update()
        If ID.Equals(Guid.Empty) Then
            InsertData()
        Else
            UpdateData()
        End If
    End Sub
    Private Sub UpdateData()
        Dim apiURL = "https://localhost:44321/api/user/putuser/" * ID.ToString
        api.UpdateData(apiURL, Me)
    End Sub

    Private Sub InsertData()
        Dim apiURL = "https://localhost:44321/api/user/postuser"
        api.InsertData(apiURL, Me)
    End Sub

    Public Async Function Read() As Task
        Dim apiURL = "https://localhost:44321/api/user/getuser/" & ID.ToString
        Dim responseBody As String = Await api.ReadData(apiURL)
        Dim data As ClsUser = JsonConvert.DeserializeObject(Of ClsUser)(responseBody)
        CreationDate = data.CreationDate
        Description = data.Description
        Name = data.Name
        ClassID = data.ClassID
        Username = data.Username
        Password = data.Password
    End Function
End Class
