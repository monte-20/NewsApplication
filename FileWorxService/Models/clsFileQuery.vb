Imports System.Data.SqlClient

Public Class clsFileQuery
    Public Property DBManager() As clsDBConnectionManager = New clsDBConnectionManager
    Public Property filter() As clsFileFilter = New clsFileFilter



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
        Dim query As String = "Select Count(T_FILE.ID) From T_BUSSINESSOBJECT,T_FILE " & filters

        Using com As SqlCommand = BuildSQLCommand(query)
            DBManager.ReadData(com, data)
        End Using

        Return data(0, 0)
    End Function

    Private Function BuildQuery() As String
        Dim query As String = "select T_BUSSINESSOBJECT.ID , T_BUSSINESSOBJECT.C_DESCRIPTION,T_BUSSINESSOBJECT.C_CREATIONDATE,T_BUSSINESSOBJECT.C_NAME,"
        query &= " T_BUSSINESSOBJECT.C_CLASSID,T_FILE.C_BODY from T_BUSSINESSOBJECT,T_FILE where T_file.ID=T_BUSSINESSOBJECT.ID "
        If filter.isFiltered() Then
            query &= "and "
            query &= addFilters()
        End If
        Return query
    End Function
    Private Function addFilters() As String
        Dim filters As String = String.Empty
        Dim FilterAdded As Boolean = False
        If filter.IsFilteredByName() Then
            filters &= addNameFilter()
            FilterAdded = True
        End If
        If filter.IsFilteredByBody() Then
            If FilterAdded Then
                filters &= " and "
            End If
            filters &= addBodyFilter()
        End If
        If filter.IsFilteredByDate() Then
            If FilterAdded Then
                filters &= " and "
            End If
            filters &= addDateFilter()
        End If
        Return filters
    End Function
    Private Function addNameFilter() As String
        Return " CHARINDEX(@C_NAME, T_BUSSINESSOBJECT.C_NAME) > 0 "
    End Function
    Private Function addBodyFilter() As String
        Return " CHARINDEX(@C_BODY, T_FILE.C_BODY) > 0 "
    End Function

    Private Function addDateFilter() As String
        If filter.IsFilteredByExactDate() Then
            Return addExactDateFilter()
        Else
            Return addIntervalDateFilter()
        End If
    End Function

    Private Function addExactDateFilter()
        Return " T_BUSSINESSOBJECT.C_CREATIONDATE= @C_CREATIONDATE "
    End Function

    Private Function addIntervalDateFilter()
        Return " T_BUSSINESSOBJECT.C_CREATIONDATE Between @StartDate and @EndDate "
    End Function

    Private Function BuildSQLCommand(query As String) As SqlCommand
        Dim com As New SqlCommand
        With com
            .CommandType = CommandType.Text
            .CommandText = query
            If filter.IsFilteredByName() Then
                .Parameters.AddWithValue("@C_NAME", filter.NameFilter)
            End If
            If filter.IsFilteredByBody() Then
                .Parameters.AddWithValue("@C_BODY", filter.BodyFilter)
            End If
            If filter.IsFilteredByExactDate() Then
                .Parameters.AddWithValue("@C_CREATIONDATE", filter.ExactDateFilter)
            End If
            If filter.IsFilteredByIntervalDate() Then
                .Parameters.AddWithValue("@StartDate", filter.StartDateFilter)
                .Parameters.AddWithValue("@EndDate", filter.EndDateFilter)
            End If
        End With
        Return com
    End Function

    Public Function ListLoad() As clsListView
        Dim retreivedData(,) As String = run()
        Dim ItemsList As New clsListView
        For i As Integer = 0 To retreivedData.GetUpperBound(0)
            Dim item As New clsListViewItem
            item.Values.Add(New clsListViewValue With {.Header = "Name", .Value = retreivedData(i, 3)})
            item.Values.Add(New clsListViewValue With {.Header = "CreationDate", .Value = retreivedData(i, 2)})
            item.Values.Add(New clsListViewValue With {.Header = "Description", .Value = retreivedData(i, 1)})
            item.Values.Add(New clsListViewValue With {.Header = "ID", .Value = retreivedData(i, 0)})
            item.Values.Add(New clsListViewValue With {.Header = "ClassID", .Value = retreivedData(i, 4)})
            item.Values.Add(New clsListViewValue With {.Header = "Body", .Value = retreivedData(i, 5)})
            ItemsList.Items.Add(item)
        Next
        Return ItemsList
    End Function
End Class
