Imports System.Data.SqlClient

Public Class clsUserQuery


    Public Property DBManager() As clsDBConnectionManager = New clsDBConnectionManager

    Public Function run() As String(,)
        Dim rows As Integer = getRows()
        Dim data(rows - 1, 5) As String
        Dim query As String = "select T_BUSSINESSOBJECT.ID,T_BUSSINESSOBJECT.C_CREATIONDATE,T_BUSSINESSOBJECT.C_NAME,T_BUSSINESSOBJECT.C_CLASSID,T_USER.C_USERNAME,T_USER.C_PASSWORD from T_BUSSINESSOBJECT,T_USER where T_USER.ID=T_BUSSINESSOBJECT.ID;"

        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
            End With
            DBManager.ReadData(com, data)
        End Using

        Return data
    End Function

    Private Function getRows() As Integer
        Dim data(0, 0) As String
        Dim query As String = "Select Count(*) From T_USER"

        Using com As New SqlCommand()
            With com
                .CommandType = CommandType.Text
                .CommandText = query
            End With
            DBManager.ReadData(com, data)
        End Using

        Return data(0, 0)
    End Function
    Public Function listLoad() As clsListView
        Dim retreivedData(,) As String = run()
        Dim ItemsList As New clsListView
        For i As Integer = 0 To retreivedData.GetUpperBound(0)
            Dim item As New clsListViewItem
            item.Values.Add(New clsListViewValue With {.Header = "ID", .Value = retreivedData(i, 0)})
            item.Values.Add(New clsListViewValue With {.Header = "CreationDate", .Value = retreivedData(i, 1)})
            item.Values.Add(New clsListViewValue With {.Header = "Name", .Value = retreivedData(i, 2)})
            item.Values.Add(New clsListViewValue With {.Header = "ClassID", .Value = retreivedData(i, 3)})
            item.Values.Add(New clsListViewValue With {.Header = "Username", .Value = retreivedData(i, 4)})
            item.Values.Add(New clsListViewValue With {.Header = "Password", .Value = retreivedData(i, 5)})

            ItemsList.Items.Add(item)
        Next
        Return ItemsList
    End Function
End Class
