Imports System.Data.SqlClient

Public Class clsBussinessQuery


    Public Property DBManager() As clsDBConnectionManager = New clsDBConnectionManager

    Public Function run() As String(,)
        Dim rows As Integer = getRows()
        Dim data(rows - 1, 4) As String
        Dim query As String = "Select ID,C_DESCRIPTION,C_CREATIONDATE,C_NAME,C_CLASSID From T_BUSSINESSOBJECT"

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
        Dim query As String = "Select Count(*) From T_BUSSINESSOBJECT"

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
            item.Values.Add(New clsListViewValue With {.Header = "Description", .Value = retreivedData(i, 1)})
            item.Values.Add(New clsListViewValue With {.Header = "CreationDate", .Value = retreivedData(i, 2)})
            item.Values.Add(New clsListViewValue With {.Header = "Name", .Value = retreivedData(i, 3)})
            item.Values.Add(New clsListViewValue With {.Header = "ClassID", .Value = retreivedData(i, 4)})

            ItemsList.Items.Add(item)
        Next
        Return ItemsList
    End Function
End Class
