Public Class clsNewsFilter
    Inherits clsFileFilter

    Public Property CategoryFilter As ClsNews.Categories = -1

    Public Function IsFilteredByCategory() As Boolean
        Return CategoryFilter <> -1
    End Function

    Public Overrides Function isFiltered() As Boolean
        Return MyBase.isFiltered OrElse
                IsFilteredByCategory()
    End Function
End Class
