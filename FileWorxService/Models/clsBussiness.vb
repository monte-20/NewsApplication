Imports System.Data.SqlClient

Public Class clsBussiness
    Public Enum BussinessClass
        USER
        NEWS
        PHOTOS
        CONTACT
    End Enum

    Public Property ID() As Guid = Guid.Empty

    Public Property CreationDate() As Date = Date.MinValue


    Public Property Description() As String = String.Empty

    Public Property Name() As String

    Public Property CanInsert As Boolean = True

    Public Property ClassID() As BussinessClass

    Public Property DBManager() As clsDBConnectionManager = New clsDBConnectionManager
    Public Overridable Sub Update()
        If CanInsert Then
            InsertData()
        Else
            UpdateData()
        End If
    End Sub

    Private Sub UpdateData()
        Dim query As String = "Update T_BUSSINESSOBJECT "
        query &= "set C_DESCRIPTION=@C_DESCRIPTION,C_NAME= @C_NAME "
        query &= "where ID=@ID"

        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@C_DESCRIPTION", Description)
                .Parameters.AddWithValue("@C_NAME", Name)

            End With
            DBManager.ExecuteNonQuery(com)
        End Using

    End Sub

    Private Sub InsertData()
        If Equals(ID, Guid.Empty) Then
            ID = Guid.NewGuid
        End If
        If Equals(CreationDate, Date.MinValue) Then
            CreationDate = Date.Now
        End If

        Dim query As String = "insert into T_BUSSINESSOBJECT "
        query &= "VALUES (@ID,@C_DESCRIPTION, @C_CREATIONDATE, @C_NAME,@C_ClASSID)"
        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@C_DESCRIPTION", Description)
                .Parameters.AddWithValue("@C_CREATIONDATE", CreationDate)
                .Parameters.AddWithValue("@C_NAME", Name)
                .Parameters.AddWithValue("@C_ClASSID", ClassID)
            End With
            DBManager.ExecuteNonQuery(com)
        End Using

    End Sub

    Public Overridable Sub Read()
        Dim query As String = "Select C_DESCRIPTION, C_CREATIONDATE ,C_NAME From T_BUSSINESSOBJECT where ID= @ID"
        Dim data(0, 2) As String

        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@ID", ID)
            End With
            DBManager.ReadData(com, data)
        End Using
        Description = data(0, 0)
        Date.TryParse(data(0, 1), CreationDate)
        Name = data(0, 2)
    End Sub

    Public Sub Delete()
        Dim query As String = "Delete From T_BUSSINESSOBJECT where ID= @ID"

        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@ID", ID)
            End With
            DBManager.ExecuteNonQuery(com)
        End Using
    End Sub
End Class
