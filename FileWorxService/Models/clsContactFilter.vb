Public Class clsContactFilter
    Inherits clsBussinessFilter
    Public Property HostFilter As String = String.Empty

    Public Function IsFilteredByHost() As Boolean
        Return HostFilter <> String.Empty
    End Function

    Public Overrides Function isFiltered() As Boolean
        Return MyBase.IsFiltered OrElse
                IsFilteredByHost()
    End Function
End Class
