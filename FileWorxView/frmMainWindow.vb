Imports FileWorxObjects

Public Class frmMainWindow
    Private mainWindow As clsMainWindow
    Private items As List(Of ListViewItem)
    Private categoryDisplayed As Boolean
    Private Sub NewsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewsToolStripMenuItem.Click
        Dim articleDialog As New frmNews()
        If articleDialog.ShowDialog() <> DialogResult.Cancel Then
            ShowItems()
        End If

    End Sub

    Private Sub PhotoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PhotoToolStripMenuItem.Click
        Dim imageArticleDialog As New frmPhotos()
        If imageArticleDialog.ShowDialog() <> DialogResult.Cancel Then
            ShowItems()
        End If
    End Sub

    Private Sub NewUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewUserToolStripMenuItem.Click
        Dim userDialog As New frmUser()
        userDialog.ShowDialog()
    End Sub

    Private Sub DisplayCategory()
        TabControl.TabPages.Remove(ImageTab)
        CategoryPanel.Visible = True
        categoryDisplayed = True
    End Sub
    Private Sub DisplayImage()
        If categoryDisplayed Then
            TabControl.TabPages.Add(ImageTab)
            CategoryPanel.Visible = False
            categoryDisplayed = False
        End If
    End Sub

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayCategory()
        mainWindow = New clsMainWindow
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        ItemList.Items.Clear()
        ShowItems()
    End Sub

    Private Sub ShowItems()
        ItemList.Items.Clear()
        items = mainWindow.getItems

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

        If mainWindow.itemIsPhoto(item) Then
            DisplayImage()
            Try
                Dim imageFileStream As New IO.FileStream(item.SubItems(4).Text, IO.FileMode.Open, IO.FileAccess.Read)
                Dim readInImage As Image = Image.FromStream(imageFileStream)
                ImageBox.Image = readInImage
                imageFileStream.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            DisplayCategory()
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
                ShowItems()
            End If
        End If
    End Sub
    Public Function updateItem(item As ListViewItem) As DialogResult
        Dim result As DialogResult
        If mainWindow.itemIsPhoto(item) Then

            result = New frmPhotos(mainWindow.itemToPhoto(item)).ShowDialog
        Else

            result = New frmNews(mainWindow.itemToNews(item)).ShowDialog
        End If
        Return result
    End Function
    Private Sub ItemList_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemList.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim item As ListViewItem = ItemList.FocusedItem
            ItemList.Items.Remove(item)
            mainWindow.deleteItem(item)
            e.Handled = True
        End If
    End Sub


End Class
