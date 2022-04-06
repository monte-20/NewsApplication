Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ClsNews
    Inherits clsFile
    Public Enum Categories
        General
        Sports
        Health
        Politics
    End Enum
    Private CategoryProp As Categories
    Public Property Category() As Categories
        Get
            Return CategoryProp
        End Get
        Set(value As Categories)
            CategoryProp = value
        End Set
    End Property

    Sub New()
        ClassID = BussinessClasses.NEWS
    End Sub


    Public Overrides Sub Update()
        MyBase.Update()
        Dim query As String = "select * from T_News where id=@ID"
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
        Dim query As String = "Update T_NEWS "
        query &= "set ID=@ID,C_Category=@C_Category "
        query &= "where ID=@ID"

        Using con As New SqlConnection("Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;")
            Using com As New SqlCommand()
                With com
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                    .Parameters.AddWithValue("@C_Category", Category)
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
        Dim query As String = "insert into T_NEWS "
        query &= "VALUES (@ID,@C_Category)"
        Using con As New SqlConnection("Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;")
            Using com As New SqlCommand()
                With com
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                    .Parameters.AddWithValue("@C_Category", Category)
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
        Dim query As String = "Select C_CATEGORY From T_NEWS where ID= @ID"
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
                        Category = reader.GetInt32(0)
                    Loop
                End Using
            End Using
        End Using
    End Sub



End Class
