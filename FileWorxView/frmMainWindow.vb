Imports FileWorxObjects

Public Class frmMainWindow
    Private mainWindow As clsMainWindow
    Private categoryLayoutDisplayed As Boolean
    Private Sub NewsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewsToolStripMenuItem.Click
        Dim articleDialog As New frmNews()
        If articleDialog.ShowDialog() <> DialogResult.Cancel Then
            ShowItems(mainWindow.GetItems)
        End If

    End Sub

    Private Sub PhotoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PhotoToolStripMenuItem.Click
        Dim imageArticleDialog As New frmPhotos()
        If imageArticleDialog.ShowDialog() <> DialogResult.Cancel Then
            ShowItems(mainWindow.GetItems)
        End If
    End Sub

    Private Sub NewUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewUserToolStripMenuItem.Click
        Dim userDialog As New frmUser()
        userDialog.ShowDialog()
    End Sub

    Private Sub BussinessViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BussinessViewToolStripMenuItem.Click
        Dim bussinessQuery As New clsBussinessQuery
        Dim data As clsListView = bussinessQuery.listLoad
        UpdateListView(data)
    End Sub
    Private Sub FilesViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilesViewToolStripMenuItem.Click
        Dim fileQuery As New clsFileQuery
        Dim data As clsListView = fileQuery.listLoad
        UpdateListView(data)
    End Sub
    Private Sub UsersViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersViewToolStripMenuItem.Click
        Dim userQuery As New clsUserQuery
        Dim data As clsListView = userQuery.listLoad
        UpdateListView(data)
    End Sub
    Private Sub UpdateListView(data As clsListView)
        Dim headers As New List(Of String)
        loadHeaders(data, headers)
        updateListViewHeaders(headers)
        Dim items As New List(Of ListViewItem)
        loadItems(data, items)
        ShowItems(items)
    End Sub



    Private Sub loadHeaders(data As clsListView, ByRef headers As List(Of String))
        If data.Items.Count > 0 Then
            For Each value As clsListViewValue In data.Items(0).Values
                headers.Add(value.Header)
            Next
        Else
            MessageBox.Show("Bussiness is Empty")
        End If
    End Sub
    Private Sub updateListViewHeaders(headers As List(Of String))
        ItemList.Columns.Clear()
        For Each header As String In headers
            Dim column As New ColumnHeader With {.Text = header}
            ItemList.Columns.Add(column)
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

    Private Sub DisplayCategoryLayout()
        TabControl.TabPages.Remove(ImageTab)
        CategoryPanel.Visible = True
        categoryLayoutDisplayed = True
    End Sub
    Private Sub DisplayImageLayout()
        If categoryLayoutDisplayed Then
            TabControl.TabPages.Add(ImageTab)
            CategoryPanel.Visible = False
            categoryLayoutDisplayed = False
        End If
    End Sub

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayCategoryLayout()
        mainWindow = New clsMainWindow
        ShowItems(mainWindow.GetItems)
    End Sub


    Private Sub ShowItems(items As List(Of ListViewItem))
        ItemList.Items.Clear()
        For Each item As ListViewItem In items
            ItemList.Items.Add(item)
        Next
    End Sub

    Private Sub ItemList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ItemList.SelectedIndexChanged
        Dim item As ListViewItem = ItemList.FocusedItem
        If item.Index > -1 Then
            TitleTextBox.Text = item.Text
            CreationDateTextBox.Text = item.SubItems(1).Text
            BodyTextBox.Text = item.SubItems(5).Text
            CheckLayout(item)
        End If

    End Sub

    Private Sub CheckLayout(item As ListViewItem)
        If mainWindow.ItemIsPhoto(item) Then
            DisplayImageLayout()
            Try
                Dim imageFileStream As New IO.FileStream(item.SubItems(4).Text, IO.FileMode.Open, IO.FileAccess.Read)
                Dim readInImage As Image = Image.FromStream(imageFileStream)
                ImageBox.Image = readInImage
                imageFileStream.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            DisplayCategoryLayout()
            CategoryTextBox.Text = item.SubItems(4).Text
        End If
    End Sub

    Private Sub ItemList_DoubleClick(sender As Object, e As MouseEventArgs) Handles ItemList.MouseDoubleClick, ItemList.MouseUp
        If e.Button = MouseButtons.Right Or
            e.Clicks = 2 Then
            Dim item As ListViewItem = ItemList.FocusedItem
            Dim result As DialogResult = updateItem(item)
            If result <> DialogResult.Cancel Then
                mainWindow.RefreshData(result)
                ShowItems(mainWindow.GetItems)
            End If
        End If
    End Sub
    Public Function updateItem(item As ListViewItem) As DialogResult
        Dim result As DialogResult
        If mainWindow.ItemIsPhoto(item) Then

            result = New frmPhotos(mainWindow.ItemToPhoto(item)).ShowDialog
        Else

            result = New frmNews(mainWindow.ItemToNews(item)).ShowDialog
        End If
        Return result
    End Function
    Private Sub ItemList_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemList.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim item As ListViewItem = ItemList.FocusedItem
            ItemList.Items.Remove(item)
            mainWindow.DeleteItem(item)
            DisplayCategoryLayout()
            TitleTextBox.Clear()
            BodyTextBox.Clear()
            CreationDateTextBox.Clear()
            CategoryTextBox.Clear()
            e.Handled = True
        End If
    End Sub


End Class
