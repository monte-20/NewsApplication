Imports FileWorxObjects
Public Class clsListViewManager
    Public Sub ShowItems(items As List(Of ListViewItem))
        frmMainWindow.ItemList.Items.Clear()
        For Each item As ListViewItem In items
            frmMainWindow.ItemList.Items.Add(item)
        Next
    End Sub
    Public Sub UpdateListView(data As clsListView)
        Dim headers As New List(Of String)
        loadHeaders(data, headers)
        updateListViewHeaders(headers)
        Dim items As New List(Of ListViewItem)
        loadItems(data, items)
        ShowItems(items)
    End Sub

    Private Sub loadHeaders(data As clsListView, ByRef headers As List(Of String))
        If data.Items.Count <= 0 Then
            MessageBox.Show("There is no items here, Add one")
            Return
        End If
        For i As Integer = 0 To 2
            headers.Add(data.Items(0).Values(i).Header)
        Next
    End Sub
    Private Sub updateListViewHeaders(headers As List(Of String))
        frmMainWindow.ItemList.Columns.Clear()
        For Each header As String In headers
            Dim column As New ColumnHeader With {.Text = header}
            frmMainWindow.ItemList.Columns.Add(column)
        Next
    End Sub
    Private Sub loadItems(data As clsListView, ByRef items As List(Of ListViewItem))
        For Each item As clsListViewItem In data.Items
            items.Add(ConvertToListViewItem(item))
        Next
    End Sub

    Private Function ConvertToListViewItem(item As clsListViewItem) As ListViewItem
        Dim ListItem As New ListViewItem(item.Values(0).Value)
        For i As Integer = 1 To item.Values.Count - 1
            ListItem.SubItems.Add(item.Values(i).Value)
        Next
        Return ListItem
    End Function
End Class
