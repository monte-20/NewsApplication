Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ClsUser
    Inherits clsBussiness


    Private UsernameProp As String
    Public Property Username() As String
        Get
            Return UsernameProp
        End Get
        Set(ByVal value As String)
            UsernameProp = value
        End Set
    End Property

    Private PasswordProp As String
    Public Property Password() As String
        Get
            Return PasswordProp
        End Get
        Set(ByVal value As String)
            PasswordProp = value
        End Set
    End Property

    Sub New()
        ClassID = BussinessClasses.USER
    End Sub
    Public Overrides Sub Update()
        MyBase.Update()
        Dim query As String = "select * from T_USER where id=@ID"
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
                            UpdateData()
                        Else
                            InsertData()
                        End If
                    End Using
                Catch ex As SqlException
                    MessageBox.Show(ex.Message.ToString(), "Error Message")
                End Try
            End Using
        End Using
    End Sub
    Private Sub UpdateData()
        Dim query As String = "Update T_USER "
        query &= "set ID=@ID,C_USERNAME=@C_USERNAME,C_PASSWORD=@C_PASSWORD "
        query &= "where ID=@ID"

        Using con As New SqlConnection("Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;")
            Using com As New SqlCommand()
                With com
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                    .Parameters.AddWithValue("@C_USERNAME", Username)
                    .Parameters.AddWithValue("@C_PASSWORD", Password)
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
    Private Sub InsertData()
        Dim query As String = "insert into T_USER "
        query &= "VALUES (@ID,@USERNAME,@PASSWORD)"
        Using con As New SqlConnection("Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;")
            Using com As New SqlCommand()
                With com
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                    .Parameters.AddWithValue("@C_USERNAME", Username)
                    .Parameters.AddWithValue("@C_PASSWORD", Password)
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
        Dim query As String = "Select C_USERNAME,C_PASSWORD From T_USER where ID= @ID"
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
                        Username = reader.GetString(0)
                        Password = reader.GetString(1)
                    Loop
                End Using
            End Using
        End Using
    End Sub
End Class
