Imports System.Data.SqlClient
Imports System.Net.Http
Imports System.Text

Public Class clsBussinessQuery


    Public Property DBManager() As New clsDBConnectionManager
    Public Property filter() As New clsBussinessFilter
    Public Function run() As String(,)
        Dim query As String = BuildQuery()

        Dim rows As Integer = getRows(generateFilters(query))
        Dim data(rows - 1, 4) As String
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
        Dim query As String = "Select Count(*) From T_BUSSINESSOBJECT " & filters

        Using com As SqlCommand = BuildSQLCommand(query)

            DBManager.ReadData(com, data)
        End Using

        Return data(0, 0)
    End Function
    Private Function BuildQuery() As String
        Dim query As String = "Select ID,C_DESCRIPTION,C_CREATIONDATE,C_NAME,C_CLASSID From T_BUSSINESSOBJECT "
        If isFiltered() Then
            query &= "where"
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
                .Parameters.AddWithValue("@C_NAME", filter.NameFilter)
            End If
            If IsFilteredByExactDate() Then
                .Parameters.AddWithValue("@C_CREATIONDATE", filter.ExactDateFilter)
            End If
            If IsFilteredByIntervalDate() Then
                .Parameters.AddWithValue("@StartDate", filter.StartDateFilter)
                .Parameters.AddWithValue("@EndDate", filter.EndDateFilter)
            End If
        End With
        Return com
    End Function


    Public Function listLoad() As clsListView
        Dim retreivedData(,) As String = run()

        Dim ItemsList As New clsListView
        For i As Integer = 0 To retreivedData.GetUpperBound(0)
            Dim item As New clsListViewItem
            'item.Values.Add(New clsListViewValue With {.Header = "ID", .Value = retreivedData(i, 0)})
            item.Values.Add(New clsListViewValue With {.Header = "Name", .Value = retreivedData(i, 3)})
            item.Values.Add(New clsListViewValue With {.Header = "CreationDate", .Value = retreivedData(i, 2)})
            item.Values.Add(New clsListViewValue With {.Header = "Description", .Value = retreivedData(i, 1)})
            'item.Values.Add(New clsListViewValue With {.Header = "ClassID", .Value = retreivedData(i, 4)})

            ItemsList.Items.Add(item)
        Next
        Return ItemsList
    End Function

    Private Function isFiltered() As Boolean
        Return IsFilteredByName() OrElse
                IsFilteredByDate()
    End Function
    Private Function IsFilteredByName() As Boolean
        Return filter.NameFilter <> String.Empty
    End Function
    Private Function IsFilteredByDate() As Boolean
        Return IsFilteredByExactDate() OrElse
            IsFilteredByIntervalDate()
    End Function
    Private Function IsFilteredByExactDate() As Boolean
        Return filter.ExactDateFilter <> Date.MinValue
    End Function
    Private Function IsFilteredByIntervalDate() As Boolean
        Return filter.StartDateFilter <> Date.MinValue AndAlso filter.EndDateFilter <> Date.MinValue
    End Function

End Class
