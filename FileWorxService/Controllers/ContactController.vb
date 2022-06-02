Imports System.Net
Imports System.Web.Http
Imports Newtonsoft.Json

Namespace Controllers
    Public Class ContactController
        Inherits ApiController

        <HttpPost>
        Public Function Contacts(<FromBody()> filter As clsContactFilter) As clsListView
            Dim items As New clsContactQuery
            With items
                .Filter = filter
            End With
            Dim usersData = items.ListLoad

            Return usersData
        End Function

        Public Function GetContact(id As Guid) As clsContact
            Dim item As New clsContact With {.ID = id}
            item.Read()
            Return item
        End Function

        ' POST: api/User
        Public Sub PostContact(<FromBody()> user As clsContact)
            user.Update()
        End Sub

        ' PUT: api/User/5
        Public Sub PutContact(ByVal id As Guid, <FromBody()> ByVal user As clsContact)
            user.ID = id
            user.Update()
        End Sub

    End Class
End Namespace