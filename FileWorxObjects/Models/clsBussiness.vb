Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class clsBussiness


    Private FileID As Guid
    Public Property ID() As Guid
        Get
            Return FileID
        End Get
        Set(ByVal value As Guid)
            FileID = value
        End Set
    End Property


    Private CreationDate As Date
    Public Property CreationTime() As Date
        Get
            Return CreationDate
        End Get
        Set(ByVal value As Date)
            CreationDate = value
        End Set
    End Property
    Sub New()
        FileID = Guid.NewGuid
        CreationDate = Date.Now
    End Sub
    Private DescriptionProp As String
    Public Property Description() As String
        Get
            Return DescriptionProp
        End Get
        Set(value As String)
            DescriptionProp = value
        End Set
    End Property

    Private TitleProp As String
    Public Property NAME() As String
        Get
            Return TitleProp
        End Get
        Set(value As String)
            TitleProp = value
        End Set
    End Property

    Public Enum BussinessClasses
        USER
        NEWS
        PHOTOS
    End Enum
    Private ClassName As BussinessClasses
    Public Property ClassID() As BussinessClasses
        Get
            Return ClassName
        End Get
        Set(value As BussinessClasses)
            ClassName = value
        End Set
    End Property

    Public Overridable Sub Update()
        Dim query As String = "select * from T_BUSSINESSOBJECT where id=@ID"
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
        Dim query As String = "Update T_BUSSINESSOBJECT "
        query &= "set ID=@ID,C_DESCRIPTION=@C_DESCRIPTION,"
        query &= "C_CREATIONDATE= @C_CREATIONDATE,C_NAME= @C_NAME,C_ClASSID=@C_ClASSID "
        query &= "where ID=@ID"

        Using con As New SqlConnection("Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;")
            Using com As New SqlCommand()
                With com
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                    .Parameters.AddWithValue("@C_DESCRIPTION", Description)
                    .Parameters.AddWithValue("@C_CREATIONDATE", CreationTime)
                    .Parameters.AddWithValue("@C_NAME", NAME)
                    .Parameters.AddWithValue("@C_ClASSID", ClassID)

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
        Dim query As String = "insert into T_BUSSINESSOBJECT "
        query &= "VALUES (@ID,@C_DESCRIPTION, @C_CREATIONDATE, @C_NAME,@C_ClASSID)"

        Using con As New SqlConnection("Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;")
            Using com As New SqlCommand()
                With com
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                    .Parameters.AddWithValue("@C_DESCRIPTION", Description)
                    .Parameters.AddWithValue("@C_CREATIONDATE", CreationTime)
                    .Parameters.AddWithValue("@C_NAME", NAME)
                    .Parameters.AddWithValue("@C_ClASSID", ClassID)

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

    Public Overridable Sub Read()
        Dim query As String = "Select C_DESCRIPTION, C_CREATIONDATE ,C_NAME From T_BUSSINESSOBJECT where ID= @ID"
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
                        Description = reader.GetString(0)
                        CreationTime = reader.GetDateTime(1)
                        NAME = reader.GetString(2)
                    Loop
                End Using
            End Using
        End Using
    End Sub
    Public Sub Delete()
        Dim query As String = "Delete From T_BUSSINESSOBJECT where ID= @ID"
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
                    com.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox.Show(ex.Message.ToString(), "Error Message")
                End Try
            End Using
        End Using
    End Sub
End Class
