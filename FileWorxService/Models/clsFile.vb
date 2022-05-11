Imports System.Data.SqlClient

Public Class clsFile
    Inherits clsBussiness

    Public Property Body() As String

    Public Overrides Sub Update()
        MyBase.Update()
        If CanInsert Then
            InsertData()
        Else
            UpdateData()
        End If
    End Sub
    Private Sub UpdateData()
        Dim query As String = "Update T_FILE "
        query &= "set C_Body=@C_Body "
        query &= "where ID=@ID"

        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@C_Body", Body)
            End With
            dbManager.ExecuteNonQuery(com)
        End Using

    End Sub
    Private Sub InsertData()
        Dim query As String = "insert into T_File "
        query &= "VALUES (@ID,@C_Body)"

        Using com As New SqlCommand()
                With com

                .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                    .Parameters.AddWithValue("@C_Body", Body)
                End With
            dbmanager.ExecuteNonQuery(com)
        End Using

    End Sub
    Public Overrides Sub Read()
        MyBase.Read()
        Dim query As String = "Select C_BODY From T_FILE where ID= @ID"
        Dim data(0, 0) As String

        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@ID", ID)
            End With
            DBManager.ReadData(com, data)
        End Using
        Body = data(0, 0)
    End Sub

End Class
