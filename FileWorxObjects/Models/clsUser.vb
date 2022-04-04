Imports System.IO

Public Class ClsUser
    Inherits clsBase

    Private NameProp As String
    Public Property Name() As String
        Get
            Return NameProp
        End Get
        Set(ByVal value As String)
            NameProp = value
        End Set
    End Property

    Private UsernameProp As String
    Public Property Username() As String
        Get
            Return UsernameProp
        End Get
        Set(ByVal value As String)
            UsernameProp = value
        End Set
    End Property

    Private PasswordProp As String
    Public Property Password() As String
        Get
            Return PasswordProp
        End Get
        Set(ByVal value As String)
            PasswordProp = value
        End Set
    End Property

    Public Sub Update()
        Dim DataPath As String = clsShared.UserPath & ID.ToString & ".txt"
        Dim Data = ConvertToString(Me)
        File.WriteAllText(DataPath, Data)
    End Sub
    Public Sub Read(id As Guid)
        Dim dataPath As String = clsShared.UserPath & id.ToString & ".txt"
        Dim data As String
        data = File.ReadAllText(dataPath)
        Parse(data)
    End Sub
    Public Sub Delete(id As Guid)
        Dim dataPath As String = clsShared.UserPath & id.ToString & ".txt"
        File.Delete(dataPath)
    End Sub
    Public Shared Function ConvertToString(user As ClsUser)
        Dim seperator As String = clsShared.Seperator
        Dim data As String = user.ID.ToString & seperator &
                    user.CreationTime & seperator &
                    user.Name & seperator &
                    user.Username & seperator &
                    user.Password
        Return data
    End Function

    Public Sub Parse(file As String)
        Dim data() As String = file.Split(New String() {clsShared.Seperator}, StringSplitOptions.None)
        Guid.TryParse(data(0), ID)
        Date.TryParse(data(1), CreationTime)
        Name = data(2)
        Username = data(3)
        Password = data(4)

    End Sub
End Class
