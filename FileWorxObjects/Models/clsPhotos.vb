﻿Imports System.Data.SqlClient

Public Class ClsPhotos
    Inherits clsFile

    Sub New()
        ClassID = BussinessClasses.PHOTOS
    End Sub


    Public Property Photo() As String

    Private Sub CopyPhoto()
        Dim path As String = clsShared.PhotosPath & ID.ToString
        path &= Photo.Substring(Photo.LastIndexOf("."))
        If Not path.Equals(Photo) Then
            FileIO.FileSystem.CopyFile(Photo, path, True)
            Photo = path
        End If
    End Sub

    Public Overrides Sub Update()
        MyBase.Update()
        CopyPhoto()
        If CanInsert Then
            InsertData()
            CanInsert = False
        Else
            UpdateData()
        End If
    End Sub
    Private Sub UpdateData()
        Dim query As String = "Update T_PHOTO "
        query &= "set C_LOCATION=@C_LOCATION "
        query &= "where ID=@ID"

        Using com As New SqlCommand()
                With com

                .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                    .Parameters.AddWithValue("@C_LOCATION", Photo)
                End With
            clsDBConnectionManager.ExecuteNonQuery(com)
        End Using

    End Sub
    Private Sub InsertData()
        Dim query As String = "insert into T_PHOTO "
        query &= "VALUES (@ID,@C_LOCATION)"

        Using com As New SqlCommand()
                With com

                .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                    .Parameters.AddWithValue("@C_LOCATION", Photo)
                End With
            clsDBConnectionManager.ExecuteNonQuery(com)
        End Using

    End Sub


    Public Overrides Sub Read()
        MyBase.Read()
        Dim query As String = "Select C_LOCATION From T_PHOTO where ID= @ID"
        Dim data(1, 1) As String
        Using com As New SqlCommand()
                With com

                .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ID", ID)
                End With
            clsDBConnectionManager.ReadData(com, data)
        End Using
        Photo = data(0, 0)
    End Sub
End Class
