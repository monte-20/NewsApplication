Imports System.Data.SqlClient

Public Class clsContact
    Inherits clsBussiness

    Public Property Username() As String

    Public Property Password() As String
    Public Property Host() As String

    Sub New()
        ClassID = BussinessClass.CONTACT
    End Sub
    Public Overrides Sub Update()
        MyBase.Update()
        If CanInsert Then
            InsertData()
            CanInsert = False
        Else
            UpdateData()
        End If
    End Sub
    Private Sub UpdateData()
        Dim query As String = "Update T_CONTACT "
        query &= "set C_USERNAME=@C_USERNAME,C_PASSWORD=@C_PASSWORD,C_HOST=@C_HOST "
        query &= "where ID=@ID"

        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@C_USERNAME", Username)
                .Parameters.AddWithValue("@C_PASSWORD", Password)
                .Parameters.AddWithValue("@C_HOST", Host)
            End With
            DBManager.ExecuteNonQuery(com)
        End Using

    End Sub
    Private Sub InsertData()
        Dim query As String = "insert into T_CONTACT VALUES (@ID,@C_USERNAME,@C_PASSWORD,@C_HOST)"

        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@C_USERNAME", Username)
                .Parameters.AddWithValue("@C_PASSWORD", Password)
                .Parameters.AddWithValue("@C_HOST", Host)
            End With
            DBManager.ExecuteNonQuery(com)
        End Using
    End Sub

    Public Overrides Sub Read()
        MyBase.Read()
        Dim query As String = "Select C_USERNAME,C_PASSWORD,C_HOST From T_CONTACT where ID= @ID"
        Dim data(0, 2) As String
        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@ID", ID)
            End With
            DBManager.ReadData(com, data)
        End Using
        Username = data(0, 0)
        Password = data(0, 1)
        Host = data(0, 2)
    End Sub
End Class
