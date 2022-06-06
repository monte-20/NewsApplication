Imports System.Data.SqlClient

Public Class ClsNews
    Inherits clsFile
    Public Enum Categories
        General
        Sports
        Health
        Politics
    End Enum

    Public Property Category() As Categories


    Sub New()
        ClassID = BussinessClass.NEWS
    End Sub


    Public Overrides Sub Update()
        MyBase.Update()
        If CanInsert Then
            InsertData()
        Else
            UpdateData()
        End If
    End Sub
    Private Sub UpdateData()
        Dim query As String = "Update T_NEWS "
        query &= "set C_Category=@C_Category "
        query &= "where ID=@ID"

        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@C_Category", Category)
            End With
            dbManager.ExecuteNonQuery(com)
        End Using
    End Sub
    Private Sub InsertData()
        Dim query As String = "insert into T_NEWS "
        query &= "VALUES (@ID,@C_Category)"

        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@ID", ID)
                .Parameters.AddWithValue("@C_Category", Category)
            End With
            DBManager.ExecuteNonQuery(com)
        End Using
    End Sub

    Public Overrides Sub Read()
        MyBase.Read()
        Dim query As String = "Select C_CATEGORY From T_NEWS where ID= @ID"
        Dim data(1, 1) As String
        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@ID", ID)
            End With
            DBManager.ReadData(com, data)
        End Using
        Category = Convert.ToInt32(data(0, 0))
    End Sub



End Class
