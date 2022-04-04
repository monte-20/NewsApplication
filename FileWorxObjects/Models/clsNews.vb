Imports System.IO

Public Class ClsNews
    Inherits clsNewsBase
    Public Enum Categories
        General
        Sports
        Health
        Politics
    End Enum
    Private CategoryProp As Categories
    Public Property Category() As Categories
        Get
            Return CategoryProp
        End Get
        Set(value As Categories)
            CategoryProp = value
        End Set
    End Property

    Public Sub Update()
        Dim dataPath As String = clsShared.NewsPath & ID.ToString & ".txt"
        Dim data As String = ConvertToString(Me)
        File.WriteAllText(dataPath, data)
    End Sub

    Public Sub Read(id As Guid)
        Dim dataPath As String = clsShared.NewsPath & id.ToString & ".txt"
        Dim data As String
        data = File.ReadAllText(dataPath)
        Parse(data)
    End Sub

    Public Shared Sub Delete(id As Guid)
        Dim dataPath As String = clsShared.NewsPath & id.ToString & ".txt"
        File.Delete(dataPath)
    End Sub

    Public Shared Function ReadAll() As List(Of ClsNews)
        Dim data As New List(Of ClsNews)
        Dim id As Guid
        Dim dir As New DirectoryInfo(clsShared.NewsPath)
        Dim files() As FileInfo = dir.GetFiles("*.txt")
        Dim fi As FileInfo
        For Each fi In files
            Dim obj As New ClsNews
            Guid.TryParse(fi.Name.Split(".")(0), id)
            obj.Read(id)
            data.Add(obj)
        Next
        Return data
    End Function
    Public Shared Function ConvertToString(News As ClsNews)
        Dim seperator As String = clsShared.Seperator
        Dim data As String = News.ID.ToString & seperator &
                        News.CreationTime & seperator &
                         News.Title & seperator &
                         News.Description & seperator &
                         News.Body & seperator &
                         News.Category
        Return data
    End Function

    Public Sub Parse(file As String)
        Dim data() As String = file.Split(New String() {clsShared.Seperator}, StringSplitOptions.None)
        Guid.TryParse(data(0), ID)
        Date.TryParse(data(1), CreationTime)
        Title = data(2)
        Description = data(3)
        Body = data(4)
        Dim cat = DirectCast([Enum].Parse(GetType(Categories), data(5)), Categories)
        Category = cat
    End Sub

End Class
