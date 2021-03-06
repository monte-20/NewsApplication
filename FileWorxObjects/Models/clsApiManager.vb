Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class clsApiManager
    Private ReadOnly Property client As New HttpClient


    Public Async Function GetAllData(apiUrl As String, filter As clsBusinessFilter) As Task(Of clsListView)
        Try
            Dim body As StringContent = buildBody(filter)
            ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications
            Dim response As HttpResponseMessage = Await client.PostAsync(apiUrl, body)
            Dim responseBody As String = Await response.Content.ReadAsStringAsync()
            Dim data As clsListView = JsonConvert.DeserializeObject(Of clsListView)(responseBody)

            Return data
        Catch e As HttpRequestException
            Console.WriteLine(Environment.NewLine & "Exception Caught!")
            Console.WriteLine("Message :{0} ", e.Message)
            Throw e
        End Try
    End Function
    Private Function AcceptAllCertifications(sender As Object, certification As System.Security.Cryptography.X509Certificates.X509Certificate, chain As System.Security.Cryptography.X509Certificates.X509Chain, sslPolicyErrors As Security.SslPolicyErrors) As Boolean
        Return True
    End Function
    Private Function buildBody(data As Object) As StringContent
        Dim jsonString = JsonConvert.SerializeObject(data)
        Dim body As New StringContent(jsonString, Encoding.UTF8, "application/json")
        Return body
    End Function
    Public Overridable Async Function ReadData(apiUrl As String) As Task(Of String)
        Try
            ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications
            Dim responseBody As String = Await client.GetStringAsync(apiUrl)
            Return responseBody
        Catch e As HttpRequestException
            Debug.WriteLine(Environment.NewLine & "Exception Caught!")
            Debug.WriteLine("Message :{0} ", e.Message)
            Throw e
        End Try
    End Function
    Public Async Function UpdateData(apiUrl As String, data As Object) As Task
        Try
            ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications
            Dim body As StringContent = buildBody(data)
            Dim responseBody As HttpResponseMessage = Await client.PutAsync(apiUrl, body)
        Catch e As HttpRequestException
            Console.WriteLine(Environment.NewLine & "Exception Caught!")
            Console.WriteLine("Message :{0} ", e.Message)
            Throw e
        End Try
    End Function

    Public Async Function InsertData(apiUrl As String, data As Object) As Task
        Try
            ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications
            Dim body As StringContent = buildBody(data)
            Dim responseBody As HttpResponseMessage = Await client.PostAsync(apiUrl, body)
        Catch e As HttpRequestException
            Console.WriteLine(Environment.NewLine & "Exception Caught!")
            Console.WriteLine("Message :{0} ", e.Message)
            Throw e
        End Try

    End Function
    Public Async Function DeleteData(apiURL As String) As Task
        Try
            ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications
            Dim responseBody As HttpResponseMessage = Await client.DeleteAsync(apiURL)
        Catch e As HttpRequestException
            Console.WriteLine(Environment.NewLine & "Exception Caught!")
            Console.WriteLine("Message :{0} ", e.Message)
            Throw e
        End Try
    End Function

End Class
