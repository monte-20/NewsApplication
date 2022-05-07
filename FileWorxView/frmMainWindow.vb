Imports FileWorxObjects

Public Class frmMainWindow
    Private mainWindow As clsMainWindow
    Private listManager As ListViewManager
    Private categoryLayoutDisplayed As Boolean
    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayCategoryLayout()
        mainWindow = New clsMainWindow
        listManager = New ListViewManager
        listManager.ShowItems(mainWindow.GetItems)
        UpdateNumberOfItems()
    End Sub

    Private Sub NewsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewsToolStripMenuItem.Click
        Dim articleDialog As New frmNews()
        If articleDialog.ShowDialog() <> DialogResult.Cancel Then
            listManager.ShowItems(mainWindow.GetItems)
        End If

    End Sub

    Private Sub PhotoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PhotoToolStripMenuItem.Click
        Dim imageArticleDialog As New frmPhotos()
        If imageArticleDialog.ShowDialog() <> DialogResult.Cancel Then
            listManager.ShowItems(mainWindow.GetItems)
        End If
    End Sub

    Private Sub NewUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewUserToolStripMenuItem.Click
        Dim userDialog As New frmUser()
        userDialog.ShowDialog()
    End Sub

    Private Sub BussinessViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BussinessViewToolStripMenuItem.Click
        Dim bussinessQuery As New clsBussinessQuery
        Dim data As clsListView = bussinessQuery.listLoad
        listManager.UpdateListView(data)
        BussinessRadioButton.Checked = True
        HideBodyFilter()
        UpdateNumberOfItems()
    End Sub

    Private Sub FilesViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilesViewToolStripMenuItem.Click
        Dim fileQuery As New clsFileQuery
        Dim data As clsListView = fileQuery.listLoad
        listManager.UpdateListView(data)
        FileRadioButton.Checked = True
        ShowBodyFilter()
        UpdateNumberOfItems()
    End Sub

    Private Sub UsersViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersViewToolStripMenuItem.Click
        Dim userQuery As New clsUserQuery
        Dim data As clsListView = userQuery.listLoad
        listManager.UpdateListView(data)
        UserRadioButton.Checked = True
        HideBodyFilter()
        UpdateNumberOfItems()
    End Sub

    Private Sub ShowBodyFilter()
        BodyFilterLabel.Show()
        BodyFilterTextBox.Show()
    End Sub

    Private Sub HideBodyFilter()
        BodyFilterLabel.Hide()
        BodyFilterTextBox.Hide()
    End Sub


    Private Sub ItemList_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim item As ListViewItem = ItemList.FocusedItem
        If item.Index > -1 Then
            TitleTextBox.Text = item.Text
            CreationDateTextBox.Text = item.SubItems(1).Text
            BodyTextBox.Text = item.SubItems(5).Text
            CheckItemLayout(item)
        End If

    End Sub

    Private Sub CheckItemLayout(item As ListViewItem)
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

    Private Sub ItemList_DoubleClick(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Or
            e.Clicks = 2 Then
            Dim item As ListViewItem = ItemList.FocusedItem
            Dim result As DialogResult = updateItem(item)
            If result <> DialogResult.Cancel Then
                mainWindow.RefreshData(result)
                listManager.ShowItems(mainWindow.GetItems)
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
    Private Sub ItemList_KeyDown(sender As Object, e As KeyEventArgs)
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


    Private Sub ExactDateRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles ExactDateRadioButton.CheckedChanged
        If ExactDateRadioButton.Checked Then
            DateFilterLabel1.Text = "Date"
            DateFilterLabel1.Show()
            DateTimeFilter1.Show()
            DateFilterLabel2.Hide()
            DateTimeFilter2.Hide()
        End If
    End Sub
    Private Sub IntervalDateRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles IntervalDateRadioButton.CheckedChanged
        If IntervalDateRadioButton.Checked Then
            DateFilterLabel1.Text = "Start Date"
            DateFilterLabel1.Show()
            DateTimeFilter1.Show()
            DateFilterLabel2.Show()
            DateTimeFilter2.Show()
        End If
    End Sub
    Private Sub NoneDateRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles NoneDateRadioButton.CheckedChanged
        If NoneDateRadioButton.Checked Then
            DateFilterLabel1.Hide()
            DateTimeFilter1.Hide()
            DateFilterLabel2.Hide()
            DateTimeFilter2.Hide()
        End If
    End Sub

    Private Sub FilterBtn_Click(sender As Object, e As EventArgs) Handles FilterBtn.Click
        If BussinessRadioButton.Checked Then
            BussinessFilter()
        ElseIf FileRadioButton.Checked Then
            FileFilter()
        ElseIf UserRadioButton.Checked Then
            UserFilter()
        End If
        UpdateNumberOfItems()
    End Sub

    Private Sub UserFilter()
        Dim titleFilter As String = TitleFilterTextBox.Text
        Dim filter As New clsBussinessFilter
        With filter
            .NameFilter = titleFilter
            If ExactDateRadioButton.Checked Then
                Dim dateFilter As Date = DateTimeFilter1.Value
                .ExactDateFilter = dateFilter
            ElseIf IntervalDateRadioButton.Checked Then
                Dim startDateFilter As Date = DateTimeFilter1.Value
                Dim endDateFilter As Date = DateTimeFilter2.Value
                .StartDateFilter = startDateFilter
                .EndDateFilter = endDateFilter
            End If
        End With
        Dim Users As New clsUserQuery
        With Users
            .filter = filter
        End With
        Dim data = Users.listLoad
        listManager.UpdateListView(data)
    End Sub

    Private Sub FileFilter()
        Dim titleFilter As String = TitleFilterTextBox.Text
        Dim bodyFilter As String = BodyFilterTextBox.Text
        Dim filter As New clsFileFilter
        With filter
            .NameFilter = titleFilter
            .BodyFilter = bodyFilter
            If ExactDateRadioButton.Checked Then
                Dim dateFilter As Date = DateTimeFilter1.Value
                .ExactDateFilter = dateFilter
            ElseIf IntervalDateRadioButton.Checked Then
                Dim startDateFilter As Date = DateTimeFilter1.Value
                Dim endDateFilter As Date = DateTimeFilter2.Value
                .StartDateFilter = startDateFilter
                .EndDateFilter = endDateFilter
            End If
        End With
        Dim files As New clsFileQuery
        With files
            .filter = filter
        End With
        Dim data = files.listLoad
        listManager.UpdateListView(data)
    End Sub

    Private Sub BussinessFilter()
        Dim titleFilter As String = TitleFilterTextBox.Text
        Dim filter As New clsBussinessFilter
        With filter
            .NameFilter = titleFilter
            If ExactDateRadioButton.Checked Then
                Dim dateFilter As Date = DateTimeFilter1.Value
                .ExactDateFilter = dateFilter
            ElseIf IntervalDateRadioButton.Checked Then
                Dim startDateFilter As Date = DateTimeFilter1.Value
                Dim endDateFilter As Date = DateTimeFilter2.Value
                .StartDateFilter = startDateFilter
                .EndDateFilter = endDateFilter
            End If
        End With
        Dim bussiness As New clsBussinessQuery With {.filter = filter}
        Dim data = bussiness.listLoad
        listManager.UpdateListView(data)
    End Sub

    Private Sub UpdateNumberOfItems()
        Dim NumberOfItems As Integer = ItemList.Items.Count
        NumberOfItemsLabel2.Text = NumberOfItems
    End Sub
End Class
