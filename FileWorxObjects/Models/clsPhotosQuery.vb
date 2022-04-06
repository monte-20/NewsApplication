﻿Imports System.Data.SqlClient

Public Class clsPhotosQuery
    Public Shared Function run() As List(Of ClsPhotos)
        Dim listOfID As List(Of Guid) = getAllID()
        Dim Objects As New List(Of ClsPhotos)
        For Each id In listOfID
            Dim obj As New ClsPhotos
            With obj
                .ID = id
            End With
            obj.Read()
            Objects.Add(obj)
        Next
        Return Objects
    End Function

    Private Shared Function getAllID() As List(Of Guid)
        Dim listOfID As New List(Of Guid)
        Dim query As String = "Select ID From T_PHOTO "
        Using con As New SqlConnection("Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;")
            Using com As New SqlCommand()
                With com
                    .Connection = con
                    .CommandType = CommandType.Text
                    .CommandText = query
                End With
                con.Open()
                Using reader As SqlDataReader = com.ExecuteReader
                    Do While reader.Read()
                        listOfID.Add(reader.GetGuid(0))
                    Loop
                End Using
            End Using
        End Using
        Return listOfID
    End Function
End Class