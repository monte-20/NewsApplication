Imports System.Windows.Forms

Public Class clsMainWindow
    Private newsData As List(Of ClsNews)
    Private photosData As List(Of ClsPhotos)
    Private newslist As List(Of ListViewItem)
    Private photoslist As List(Of ListViewItem)
    Private listViewItems As List(Of ListViewItem)

    Sub New()
        newsData = New List(Of ClsNews)
        photosData = New List(Of ClsPhotos)
        newslist = New List(Of ListViewItem)
        photoslist = New List(Of ListViewItem)
        listViewItems = New List(Of ListViewItem)
    End Sub

    Public Sub GetFilesData()
        newsData = clsNewsQuery.run
        photosData = clsPhotosQuery.run
    End Sub

    Private Sub AddNewsToList()
        For Each item In newsData
            Dim record As New ListViewItem(item.Name)
            record.SubItems.Add(item.CreationDate)
            record.SubItems.Add(item.Description)
            record.SubItems.Add(item.ID.ToString)
            record.SubItems.Add(item.Category.ToString)
            record.SubItems.Add(item.Body)
            newslist.Add(record)
            listViewItems.Add(record)
        Next
    End Sub

    Private Sub AddPhotosToList()
        For Each item In photosData
            Dim record As New ListViewItem(item.Name)
            record.SubItems.Add(item.CreationDate)
            record.SubItems.Add(item.Description)
            record.SubItems.Add(item.ID.ToString)
            record.SubItems.Add(item.Photo)
            record.SubItems.Add(item.Body)
            photoslist.Add(record)
            listViewItems.Add(record)
        Next

    End Sub

    Public Function GetItems() As List(Of ListViewItem)
        listViewItems.Clear()
        GetFilesData()
        AddNewsToList()
        AddPhotosToList()
        Return listViewItems
    End Function

    Public Sub DeleteItem(item As ListViewItem)
        If photoslist.Contains(item) Then
            Dim photo As ClsPhotos = ItemToPhoto(item)
            photo.Delete()
            photo.DeletePhoto()
        Else
            ItemToNews(item).Delete()
        End If
    End Sub

    Public Sub RefreshData(result As DialogResult)
        If result <> DialogResult.Cancel Then
            newsData.Clear()
            photosData.Clear()
            GetFilesData()
        End If
    End Sub

    Public Function ItemIsPhoto(item As ListViewItem) As Boolean
        Return photoslist.Contains(item)
    End Function

    Public Function ItemToNews(item As ListViewItem) As ClsNews
        Dim obj As New ClsNews

        obj.Name = item.SubItems(0).Text
        Date.TryParse(item.SubItems(1).Text, obj.CreationDate)
        obj.Description = item.SubItems(2).Text
        Guid.TryParse(item.SubItems(3).Text, obj.ID)
        Dim cat = DirectCast([Enum].Parse(GetType(ClsNews.Categories), item.SubItems(4).Text), ClsNews.Categories)
        obj.Category = cat
        obj.Body = item.SubItems(5).Text
        Return obj
    End Function

    Public Function ItemToPhoto(item As ListViewItem) As ClsPhotos
        Dim obj As New ClsPhotos
        obj.Name = item.SubItems(0).Text
        Date.TryParse(item.SubItems(1).Text, obj.CreationDate)
        obj.Description = item.SubItems(2).Text
        Guid.TryParse(item.SubItems(3).Text, obj.ID)
        obj.Photo = item.SubItems(4).Text
        obj.Body = item.SubItems(5).Text
        Return obj
    End Function

End Class
