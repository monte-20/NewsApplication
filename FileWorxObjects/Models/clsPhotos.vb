Imports System.IO
Imports System.Windows.Forms

Public Class ClsPhotos
    Inherits clsNewsBase

    Sub New()

    End Sub

    Private PhotoProp As String
    Public Property Photo() As String
        Get
            Return PhotoProp
        End Get
        Set(value As String)
            PhotoProp = value
        End Set
    End Property

    Public Function BrowsePhoto() As String
        Dim result As DialogResult
        Using fileChooser As New OpenFileDialog
            fileChooser.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif"
            result = fileChooser.ShowDialog
            Photo = fileChooser.FileName
        End Using
        Return Photo
    End Function

    Public Sub Update()
        Dim DataPath As String = clsShared.PhotosPath & ID.ToString & ".txt"
        copyPhoto()
        Dim Data As String = ConvertToString(Me)
        File.WriteAllText(DataPath, Data)
    End Sub

    Private Sub copyPhoto()
        Dim photoPath As String = clsShared.PhotosPath & ID.ToString & "." & Photo.Split(".").Last
        File.Copy(Photo, photoPath, True)
        Photo = photoPath
    End Sub

    Public Sub Read(id As Guid)
        Dim dataPath As String = clsShared.PhotosPath & id.ToString & ".txt"
        Dim data As String
        data = File.ReadAllText(dataPath)
        Parse(data)
    End Sub

    Public Shared Sub Delete(id As Guid)
        Dim dir As New DirectoryInfo(clsShared.PhotosPath)
        Dim files() As FileInfo = dir.GetFiles(id.ToString & ".*")
        For Each fi In files
            File.Delete(fi.FullName)
        Next
    End Sub

    Public Shared Function ReadAll() As List(Of ClsPhotos)
        Dim data As New List(Of ClsPhotos)
        Dim id As Guid
        Dim dir As New DirectoryInfo(clsShared.PhotosPath)
        Dim files() As FileInfo = dir.GetFiles("*.txt")
        Dim fi As FileInfo
        For Each fi In files
            Dim obj As New ClsPhotos
            Guid.TryParse(fi.Name.Split(".")(0), id)
            obj.Read(id)
            data.Add(obj)
        Next
        Return data
    End Function

    Public Shared Function ConvertToString(PhotoObj As ClsPhotos)
        Dim seperator As String = clsShared.Seperator
        Dim data As String = PhotoObj.ID.ToString & seperator &
                        PhotoObj.CreationTime & seperator &
                         PhotoObj.Title & seperator &
                         PhotoObj.Description & seperator &
                         PhotoObj.Body & seperator &
                         PhotoObj.Photo
        Return data
    End Function

    Public Sub Parse(file As String)
        Dim data() As String = file.Split(New String() {clsShared.Seperator}, StringSplitOptions.None)
        Guid.TryParse(data(0), ID)
        Date.TryParse(data(1), CreationTime)
        Title = data(2)
        Description = data(3)
        Body = data(4)
        Photo = data(5)
    End Sub

End Class
