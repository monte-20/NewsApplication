Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class clsFile
    Inherits clsBussiness



    Private BodyProp As String
    Public Property Body() As String
        Get
            Return BodyProp
        End Get
        Set(value As String)
            BodyProp = value
        End Set
    End Property

    Public Overrides Sub Update()
        MyBase.Update()
        Dim query As String = "select * from T_FILE where id=@ID"
        Using con As New SqlConnection("Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;")
            Using com As New SqlCommand()
                With com
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                End With
                Try
                    con.Open()
                    Using reader As SqlDataReader = com.ExecuteReader
                        If reader.Read Then
                            UpdateQuery()
                        Else
                            InsertQuery()
                        End If
                    End Using
                Catch ex As SqlException
                    MessageBox.Show(ex.Message.ToString(), "Error Message")
                End Try
            End Using
        End Using
    End Sub
    Private Sub UpdateQuery()
        Dim query As String = "Update T_FILE "
        query &= "set ID=@ID,C_Body=@C_Body "
        query &= "where ID=@ID"

        Using con As New SqlConnection("Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;")
            Using com As New SqlCommand()
                With com
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                    .Parameters.AddWithValue("@C_Body", Body)
                End With
                Try
                    con.Open()
                    com.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox.Show(ex.Message.ToString(), "Error Message")
                End Try
            End Using
        End Using
    End Sub
    Private Sub InsertQuery()
        Dim query As String = "insert into T_File "
        query &= "VALUES (@ID,@C_Body)"

        Using con As New SqlConnection("Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;")
            Using com As New SqlCommand()
                With com
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                    .Parameters.AddWithValue("@C_Body", Body)
                End With
                Try
                    con.Open()
                    com.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox.Show(ex.Message.ToString(), "Error Message")
                End Try
            End Using
        End Using
    End Sub
    Public Overrides Sub Read()
        MyBase.Read()
        Dim query As String = "Select C_BODY From T_FILE where ID= @ID"
        Using con As New SqlConnection("Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;")
            Using com As New SqlCommand()
                With com
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                End With
                con.Open()
                Using reader As SqlDataReader = com.ExecuteReader
                    Do While reader.Read()
                        Body = reader.GetString(0)
                    Loop
                End Using
            End Using
        End Using
    End Sub

End Class
