Imports System.Data.SqlClient

Public Class clsBussiness

    Public Property ID() As Guid = Guid.Empty

    Public Property CreationDate() As Date

    Public Property Description() As String = String.Empty

    Public Property Name() As String

    Public Property CanInsert As Boolean
    Public Enum BussinessClass
        USER
        NEWS
        PHOTOS
    End Enum

    Public Property ClassID() As BussinessClass

    Public Property DBManager() As clsDBConnectionManager = New clsDBConnectionManager
    Public Overridable Sub Update()
        If ID.Equals(Guid.Empty) Then
            CanInsert = True
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
            dbManager.ExecuteNonQuery(com)
        End Using

    End Sub

    Private Sub InsertData()
        ID = Guid.NewGuid
        CreationDate = Date.Now
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
        CreationDate = data(0, 1)
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
