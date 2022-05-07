﻿Imports System.Data.SqlClient

Public Class clsUserQuery


    Public Property DBManager() As clsDBConnectionManager = New clsDBConnectionManager
    Public Property filter() As New clsBussinessFilter

    Public Function run() As String(,)

        Dim query As String = BuildQuery()
        Dim rows As Integer = getRows(generateFilters(query))
        Dim data(rows - 1, 5) As String
        Using com As SqlCommand = BuildSQLCommand(query)
            DBManager.ReadData(com, data)
        End Using

        Return data
    End Function
    Private Function generateFilters(query As String) As String
        Dim index = query.IndexOf("where")
        If index > 0 Then
            Return query.Substring(index)
        End If
        Return String.Empty
    End Function
    Private Function getRows(filters As String) As Integer
        Dim data(0, 0) As String
        Dim query As String = "Select Count(*) From T_BUSSINESSOBJECT,T_USER " & filters

        Using com As SqlCommand = BuildSQLCommand(query)

            DBManager.ReadData(com, data)
        End Using

        Return data(0, 0)
    End Function
    Private Function BuildQuery() As String
        Dim query As String = "select T_BUSSINESSOBJECT.ID,T_BUSSINESSOBJECT.C_CREATIONDATE,T_BUSSINESSOBJECT.C_NAME,T_BUSSINESSOBJECT.C_CLASSID,T_USER.C_USERNAME,T_USER.C_PASSWORD"
        query &= " from T_BUSSINESSOBJECT,T_USER where T_USER.ID=T_BUSSINESSOBJECT.ID "
        If isFiltered() Then
            query &= "and "
            addFilters(query)
        End If
        Return query
    End Function
    Private Sub addFilters(ByRef query As String)
        Dim FilterAdded As Boolean = False
        If IsFilteredByName() Then
            query &= addNameFilter()
            FilterAdded = True
        End If
        If IsFilteredByDate() Then
            If FilterAdded Then
                query &= " and "
            End If
            query &= addDateFilter()
        End If
    End Sub
    Private Function addNameFilter() As String
        Return " CHARINDEX(@C_NAME, C_NAME ) > 0 "
    End Function

    Private Function addDateFilter() As String
        If IsFilteredByExactDate() Then
            Return addExactDateFilter()
        Else
            Return addIntervalDateFilter()
        End If
    End Function

    Private Function addExactDateFilter()
        Return " C_CREATIONDATE= @C_CREATIONDATE "
    End Function

    Private Function addIntervalDateFilter()
        Return " C_CREATIONDATE Between @StartDate and @EndDate "
    End Function

    Private Function BuildSQLCommand(query As String) As SqlCommand
        Dim com As New SqlCommand
        With com
            .CommandType = CommandType.Text
            .CommandText = query
            If IsFilteredByName() Then
                .Parameters.AddWithValue("@C_NAME", Filter.NameFilter)
            End If
            If IsFilteredByExactDate() Then
                .Parameters.AddWithValue("@C_CREATIONDATE", Filter.ExactDateFilter)
            End If
            If IsFilteredByIntervalDate() Then
                .Parameters.AddWithValue("@StartDate", Filter.StartDateFilter)
                .Parameters.AddWithValue("@EndDate", Filter.EndDateFilter)
            End If
        End With
        Return com
    End Function
    Public Function listLoad() As clsListView
        Dim retreivedData(,) As String = run()
        Dim ItemsList As New clsListView
        For i As Integer = 0 To retreivedData.GetUpperBound(0)
            Dim item As New clsListViewItem
            item.Values.Add(New clsListViewValue With {.Header = "Name", .Value = retreivedData(i, 2)})
            item.Values.Add(New clsListViewValue With {.Header = "CreationDate", .Value = retreivedData(i, 1)})
            item.Values.Add(New clsListViewValue With {.Header = "Username", .Value = retreivedData(i, 4)})

            ' item.Values.Add(New clsListViewValue With {.Header = "ClassID", .Value = retreivedData(i, 3)})
            ' item.Values.Add(New clsListViewValue With {.Header = "Password", .Value = retreivedData(i, 5)})
            'item.Values.Add(New clsListViewValue With {.Header = "ID", .Value = retreivedData(i, 0)})

            ItemsList.Items.Add(item)
        Next
        Return ItemsList
    End Function
    Private Function isFiltered() As Boolean
        Return IsFilteredByName() OrElse
                IsFilteredByDate()
    End Function
    Private Function IsFilteredByName() As Boolean
        Return Filter.NameFilter <> String.Empty
    End Function
    Private Function IsFilteredByDate() As Boolean
        Return IsFilteredByExactDate() OrElse
            IsFilteredByIntervalDate()
    End Function
    Private Function IsFilteredByExactDate() As Boolean
        Return Filter.ExactDateFilter <> Date.MinValue
    End Function
    Private Function IsFilteredByIntervalDate() As Boolean
        Return Filter.StartDateFilter <> Date.MinValue AndAlso Filter.EndDateFilter <> Date.MinValue
    End Function
End Class
