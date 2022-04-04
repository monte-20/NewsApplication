Public Class clsNewsBase
    Inherits clsBase

    Private DescriptionProp As String
    Public Property Description() As String
        Get
            Return DescriptionProp
        End Get
        Set(value As String)
            DescriptionProp = value
        End Set
    End Property

    Private TitleProp As String
    Public Property Title() As String
        Get
            Return TitleProp
        End Get
        Set(value As String)
            TitleProp = value
        End Set
    End Property

    Private BodyProp As String
    Public Property Body() As String
        Get
            Return BodyProp
        End Get
        Set(value As String)
            BodyProp = value
        End Set
    End Property
End Class
