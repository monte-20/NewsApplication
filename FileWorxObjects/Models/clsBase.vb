Public MustInherit Class clsBase


    Private FileID As Guid
    Public Property ID() As Guid
        Get
            Return FileID
        End Get
        Set(ByVal value As Guid)
            FileID = value
        End Set
    End Property


    Private CreationDate As Date
    Public Property CreationTime() As Date
        Get
            Return CreationDate
        End Get
        Set(ByVal value As Date)
            CreationDate = value
        End Set
    End Property
    Sub New()
        FileID = Guid.NewGuid
        CreationDate = Date.Now
    End Sub
End Class
