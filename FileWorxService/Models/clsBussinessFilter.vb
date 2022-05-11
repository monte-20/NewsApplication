Public Class clsBussinessFilter
    Public Property NameFilter As String = String.Empty
    Public Property ExactDateFilter As Date = Date.MinValue
    Public Property StartDateFilter As Date = Date.MinValue
    Public Property EndDateFilter As Date = Date.MinValue

    Public Overridable Function IsFiltered() As Boolean
        Return IsFilteredByName() OrElse
                IsFilteredByDate()
    End Function
    Public Function IsFilteredByName() As Boolean
        Return NameFilter <> String.Empty
    End Function
    Public Function IsFilteredByDate() As Boolean
        Return IsFilteredByExactDate() OrElse
            IsFilteredByIntervalDate()
    End Function
    Public Function IsFilteredByExactDate() As Boolean
        Return ExactDateFilter <> Date.MinValue
    End Function
    Public Function IsFilteredByIntervalDate() As Boolean
        Return StartDateFilter <> Date.MinValue AndAlso EndDateFilter <> Date.MinValue
    End Function
End Class
