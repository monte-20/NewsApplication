Imports FileWorxObjects

Public Class frmMainWindow

    Private listManager As clsListViewManager

    Private categoryLayoutDisplayed As Boolean

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayCategoryLayout()
        listManager = New clsListViewManager
        showFilesData()
        DateCB.SelectedIndex = 0
        ItemList.ContextMenuStrip = ListViewItemContextMenu
    End Sub

    Private Sub NewsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewsToolStripMenuItem.Click
        Dim articleDialog As New frmNews()
        If articleDialog.ShowDialog() <> DialogResult.Cancel Then
            showFilesData()
        End If
    End Sub

    Private Sub PhotoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PhotoToolStripMenuItem.Click
        Dim imageArticleDialog As New frmPhotos()
        If imageArticleDialog.ShowDialog() <> DialogResult.Cancel Then
            showFilesData()
        End If
    End Sub

    Private Sub NewUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewUserToolStripMenuItem.Click
        Dim userDialog As New frmUser()
        userDialog.ShowDialog()
    End Sub

    Private Async Sub BussinessViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BussinessViewToolStripMenuItem.Click
        Dim bussinessQuery As New clsBusinessQuery
        Dim data = Await bussinessQuery.run
        UpdateListView(data)
        FilterCB.SelectedIndex = 0
        BodyFilterTB.Enabled = False
    End Sub

    Private Sub UpdateListView(data As clsListView)
        listManager.UpdateListView(data)
    End Sub

    Private Sub FilesViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilesViewToolStripMenuItem.Click
        showFilesData()
        BodyFilterTB.Enabled = True
    End Sub

    Private Async Sub showFilesData()
        Dim fileQuery As New clsFileQuery
        Dim data As clsListView = Await fileQuery.run
        UpdateListView(data)
        FilterCB.SelectedIndex = 1
    End Sub

    Private Sub UsersViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersViewToolStripMenuItem.Click
        showUsersData()
        BodyFilterTB.Enabled = False
    End Sub

    Private Async Sub showUsersData()
        Dim userQuery As New clsUserQuery
        Dim data As clsListView = Await userQuery.run
        UpdateListView(data)
        FilterCB.SelectedIndex = 2
    End Sub

    Private Sub DateCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DateCB.SelectedIndexChanged
        If DateCB.SelectedIndex = 0 Then
            NoDateFilterLayout()
        ElseIf DateCB.SelectedIndex = 1 Then
            ExactDateFilterLayout()
        ElseIf DateCB.SelectedIndex = 2 Then
            IntervalDateFilterLayout()
        End If
    End Sub

    Private Sub NoDateFilterLayout()
        DateTimeFilter1.Hide()
        DateFilterLabel1.Hide()
        DateTimeFilter2.Hide()
        DateFilterLabel2.Hide()
    End Sub

    Private Sub ExactDateFilterLayout()
        DateFilterLabel1.Text = "Exact Date"
        DateTimeFilter1.Show()
        DateFilterLabel1.Show()
        DateTimeFilter2.Hide()
        DateFilterLabel2.Hide()
    End Sub

    Private Sub IntervalDateFilterLayout()
        DateFilterLabel1.Text = "Start Date"
        DateTimeFilter1.Show()
        DateFilterLabel1.Show()
        DateTimeFilter2.Show()
        DateFilterLabel2.Show()
    End Sub

    Private Sub FilterBtn_Click(sender As Object, e As EventArgs) Handles FilterBtn.Click
        If FilterCB.SelectedIndex = 0 Then
            FilterBussiness()
        ElseIf FilterCB.SelectedIndex = 1 Then
            FilterFile()
        ElseIf FilterCB.SelectedIndex = 2 Then
            FilterUser()
        End If
    End Sub

    Private Function BuildBussinessFilter() As clsBusinessFilter
        Dim filter As New clsBusinessFilter
        With filter
            .NameFilter = TitleFilterTB.Text
            If DateCB.SelectedIndex = 1 Then
                .ExactDateFilter = DateTimeFilter1.Value
            ElseIf DateCB.SelectedIndex = 2 Then
                .StartDateFilter = DateTimeFilter1.Value
                .EndDateFilter = DateTimeFilter2.Value
            End If
        End With
        Return filter
    End Function

    Private Function BuildFileFilter() As clsFileFilter
        Dim filter As New clsFileFilter
        With filter
            .NameFilter = TitleFilterTB.Text
            If DateCB.SelectedIndex = 1 Then
                .ExactDateFilter = DateTimeFilter1.Value
            ElseIf DateCB.SelectedIndex = 2 Then
                .StartDateFilter = DateTimeFilter1.Value
                .EndDateFilter = DateTimeFilter2.Value
            End If
            If Not BodyFilterTB.Text = String.Empty Then
                .BodyFilter = BodyFilterTB.Text
            End If
        End With
        Return filter
    End Function

    Private Async Sub FilterBussiness()
        Dim filter As clsBusinessFilter = BuildBussinessFilter()
        Dim bussiness As New clsBusinessQuery With {.Filter = filter}
        Dim data As clsListView = Await bussiness.run
        UpdateListView(data)
    End Sub

    Private Async Sub FilterFile()
        Dim filter As clsFileFilter = BuildFileFilter()
        Dim file As New clsFileQuery With {.Filter = filter}
        Dim data As clsListView = Await file.run
        UpdateListView(data)
    End Sub

    Private Async Sub FilterUser()
        Dim filter As clsBusinessFilter = BuildBussinessFilter()
        Dim user As New clsUserQuery With {.Filter = filter}
        Dim data As clsListView = Await user.run
        UpdateListView(data)
    End Sub

    Private Sub ItemList_SelectedIndexChanged_1(sender As Object, e As MouseEventArgs) Handles ItemList.MouseUp
        If Not e.Button = Windows.Forms.MouseButtons.Left Then
            Return
        End If
        Dim item As ListViewItem = ItemList.FocusedItem
        If item.Index < 0 Then
            Return
        End If
        displayItem(item)
    End Sub

    Private Sub displayItem(item As ListViewItem)
        Dim id As New Guid
        Guid.TryParse(item.SubItems(3).Text, id)
        Dim classID As Integer = Val(item.SubItems(4).Text)
        If isNews(classID) Then
            displayNews(id)
        ElseIf isPhoto(classID) Then
            displayPhoto(id)
        ElseIf isUser(classID) Then
            displayUser(id)
        End If
    End Sub

    Private Async Sub displayNews(id As Guid)
        DisplayCategoryLayout()
        Dim news As ClsNews = Await getNewsObject(id)
        TitleTextBox.Text = news.Name
        CreationDateTextBox.Text = news.CreationDate.ToString
        CategoryTextBox.Text = news.Category.ToString
        BodyTextBox.Text = news.Body
    End Sub
    Private Sub DisplayCategoryLayout()
        TabControl.TabPages.Remove(ImageTab)
        CategoryPanel.Visible = True
        categoryLayoutDisplayed = True
    End Sub
    Private Async Function getNewsObject(id As Guid) As Task(Of ClsNews)
        Dim news As New ClsNews With {.ID = id}
        Await news.Read()
        Return news
    End Function
    Private Async Sub displayUser(id As Guid)
        DisplayCategoryLayout()
        Dim user As ClsUser = Await getUserObject(id)
        TitleTextBox.Text = user.Name
        CreationDateTextBox.Text = user.CreationDate
        CategoryTextBox.Text = "USER"
        BodyTextBox.Text = ""
    End Sub
    Private Async Function getUserObject(id As Guid) As Task(Of ClsUser)
        Dim user As New ClsUser With {.ID = id}
        Await user.Read()
        Return user
    End Function

    Private Async Sub displayPhoto(id As Guid)
        displayImageLayout()
        Dim photo As ClsPhotos = Await getPhotoObject(id)
        TitleTextBox.Text = photo.Name
        CreationDateTextBox.Text = photo.CreationDate
        BodyTextBox.Text = photo.Body
        showphoto(photo.Photo)
    End Sub

    Private Sub displayImageLayout()
        If categoryLayoutDisplayed Then
            TabControl.TabPages.Add(ImageTab)
            CategoryPanel.Visible = False
            categoryLayoutDisplayed = False
        End If
    End Sub

    Private Async Function getPhotoObject(id As Guid) As Task(Of ClsPhotos)
        Dim photo As New ClsPhotos With {.ID = id}
        Await photo.Read()
        Return photo
    End Function

    Private Sub showphoto(photoName As String)
        Dim directoryPath = "D:/Projects/FileWorxWebApp/FileWorxWebApp/FileWorxWebApp/Photos/"
        Dim path = IO.Path.Combine(directoryPath, photoName)
        Using imageFileStream As New IO.FileStream(path, IO.FileMode.Open, IO.FileAccess.Read)
            Dim readInImage As Image = Image.FromStream(imageFileStream)
            ImageBox.Image = readInImage
        End Using
    End Sub

    Private Async Sub ItemList_DoubleClick(sender As Object, e As MouseEventArgs) Handles ItemList.MouseDoubleClick
        If Not e.Button = Windows.Forms.MouseButtons.Left Then
            Return
        End If
        Dim item As ListViewItem = ItemList.FocusedItem
        Dim result As DialogResult = Await UpdateItem(item)
        If result = DialogResult.OK Then
            If isUser(Val(item.SubItems(4).Text)) Then
                showUsersData()
            Else
                showFilesData()
            End If
        End If
    End Sub

    Private Async Function UpdateItem(item As ListViewItem) As Task(Of DialogResult)
        Dim id As New Guid
        Guid.TryParse(item.SubItems(3).Text, id)
        Dim result As DialogResult
        Dim classID As Integer = Val(item.SubItems(4).Text)
        If isNews(classID) Then
            Dim news As ClsNews = Await getNewsObject(id)
            result = New frmNews(news).ShowDialog
        ElseIf isPhoto(classID) Then
            Dim photo As ClsPhotos = Await getPhotoObject(id)
            result = New frmPhotos(photo).ShowDialog
        ElseIf isUser(classID) Then
            Dim user As ClsUser = Await getUserObject(id)
            result = New frmUser(user).ShowDialog
        End If
        Return result
    End Function

    Private Function isNews(classID As Integer) As Boolean
        Return classID = clsBusiness.BusinessClass.NEWS
    End Function

    Private Function isPhoto(classID As Integer) As Boolean
        Return classID = clsBusiness.BusinessClass.PHOTOS
    End Function

    Private Function isUser(classID As Integer) As Boolean
        Return classID = clsBusiness.BusinessClass.USER
    End Function

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim item As ListViewItem = ItemList.FocusedItem
        If item.Index < 0 Then
            Return
        End If
        deleteItem(item)
        ItemList.Items.Remove(item)
    End Sub

    Private Async Sub deleteItem(item As ListViewItem)
        Dim id As New Guid
        Guid.TryParse(item.SubItems(3).Text, id)
        Dim classID As Integer = Val(item.SubItems(4).Text)
        If isNews(classID) Then
            Dim news As ClsNews = Await getNewsObject(id)
            Await news.Delete()
        ElseIf isPhoto(classID) Then
            Dim photo As ClsPhotos = Await getPhotoObject(id)
            Await photo.Delete()
            photo.DeletePhoto()
        ElseIf isUser(classID) Then
            Dim user As ClsUser = Await getUserObject(id)
            Await user.Delete()
        End If
    End Sub

End Class
