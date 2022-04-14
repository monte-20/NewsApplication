Imports System.Data.SqlClient

Public Class ClsUser
    Inherits clsBussiness

    Public Property Username() As String

    Public Property Password() As String

    Sub New()
        ClassID = BussinessClass.USER
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
        Dim query As String = "Update T_USER "
        query &= "set C_USERNAME=@C_USERNAME,C_PASSWORD=@C_PASSWORD "
        query &= "where ID=@ID"

        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@C_USERNAME", Username)
                .Parameters.AddWithValue("@C_PASSWORD", Password)
            End With
            DBManager.ExecuteNonQuery(com)
        End Using

    End Sub
    Private Sub InsertData()
        Dim query As String = "insert into T_USER VALUES (@ID,@C_USERNAME,@C_PASSWORD)"

        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@C_USERNAME", Username)
                .Parameters.AddWithValue("@C_PASSWORD", Password)
            End With
            DBManager.ExecuteNonQuery(com)
        End Using
    End Sub

    Public Overrides Sub Read()
        MyBase.Read()
        Dim query As String = "Select C_USERNAME,C_PASSWORD From T_USER where ID= @ID"
        Dim data(0, 1) As String
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
    End Sub
End Class
