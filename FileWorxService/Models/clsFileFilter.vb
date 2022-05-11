Public Class clsFileFilter
    Inherits clsBussinessFilter
    Public Property BodyFilter As String = String.Empty

    Public Function IsFilteredByBody() As Boolean
        Return BodyFilter <> String.Empty
    End Function

    Public Overrides Function isFiltered() As Boolean
        Return MyBase.IsFiltered OrElse
                IsFilteredByBody()
    End Function
End Class
