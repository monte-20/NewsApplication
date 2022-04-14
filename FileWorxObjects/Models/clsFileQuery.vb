Imports System.Data.SqlClient

Public Class clsFileQuery
    Public Function run() As String(,)
        Dim rows As Integer = getRows()
        Dim data(rows - 1, 5) As String
        Dim query As String = "select T_BUSSINESSOBJECT.ID , T_BUSSINESSOBJECT.C_DESCRIPTION,T_BUSSINESSOBJECT.C_CREATIONDATE,T_BUSSINESSOBJECT.C_NAME,T_BUSSINESSOBJECT.C_CLASSID,T_FILE.C_BODY from T_BUSSINESSOBJECT,T_FILE where T_file.ID=T_BUSSINESSOBJECT.ID;"
        Dim dbManager As New clsDBConnectionManager


        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
            End With
            dbManager.ReadData(com, data)
        End Using

        Return data
    End Function

    Private Function getRows() As Integer
        Dim data(0, 0) As String
        Dim query As String = "Select Count(*) From T_FILE"
        Dim dbManager As New clsDBConnectionManager

        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
            End With
            dbManager.ReadData(com, data)
        End Using

        Return data(0, 0)
    End Function
    Public Function listLoad() As clsListView
        Dim retreivedData(,) As String = run()
        Dim ItemsList As New clsListView
        For i As Integer = 0 To retreivedData.GetUpperBound(0)
            Dim item As New clsListViewItem
            item.Values.Add(New clsListViewValue With {.Header = "ID", .Value = retreivedData(i, 0)})
            item.Values.Add(New clsListViewValue With {.Header = "Description", .Value = retreivedData(i, 1)})
            item.Values.Add(New clsListViewValue With {.Header = "CreationDate", .Value = retreivedData(i, 2)})
            item.Values.Add(New clsListViewValue With {.Header = "Name", .Value = retreivedData(i, 3)})
            item.Values.Add(New clsListViewValue With {.Header = "ClassID", .Value = retreivedData(i, 4)})
            item.Values.Add(New clsListViewValue With {.Header = "Body", .Value = retreivedData(i, 5)})

            ItemsList.Items.Add(item)
        Next
        Return ItemsList
    End Function
End Class
