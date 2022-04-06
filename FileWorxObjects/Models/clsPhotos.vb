Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms

Public Class ClsPhotos
    Inherits clsFile

    Sub New()
        ClassID = BussinessClasses.PHOTOS
    End Sub

    Private PhotoProp As String
    Public Property Photo() As String
        Get
            Return PhotoProp
        End Get
        Set(value As String)
            PhotoProp = value
        End Set
    End Property

    Public Function BrowsePhoto() As String
        Dim result As DialogResult
        Using fileChooser As New OpenFileDialog
            fileChooser.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif"
            result = fileChooser.ShowDialog
            Photo = fileChooser.FileName
        End Using
        Return Photo
    End Function

    Public Overrides Sub Update()
        MyBase.Update()
        Dim query As String = "select * from T_PHOTO where id=@ID"
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
        Dim query As String = "Update T_PHOTO "
        query &= "set ID=@ID,C_LOCATION=@C_LOCATION "
        query &= "where ID=@ID"

        Using con As New SqlConnection("Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;")
            Using com As New SqlCommand()
                With com
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                    .Parameters.AddWithValue("@C_LOCATION", Photo)
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
        Dim query As String = "insert into T_PHOTO "
        query &= "VALUES (@ID,@C_LOCATION)"
        Using con As New SqlConnection("Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;")
            Using com As New SqlCommand()
                With com
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                    .Parameters.AddWithValue("@C_LOCATION", Photo)
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
        Dim query As String = "Select C_LOCATION From T_PHOTO where ID= @ID"
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
                        Photo = reader.GetString(0)
                    Loop
                End Using
            End Using
        End Using
    End Sub
End Class
