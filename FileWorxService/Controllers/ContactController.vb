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
            Dim contactsData = items.ListLoad

            Return contactsData
        End Function

        Public Function GetContact(id As Guid) As clsContact
            Dim contact As New clsContact With {.ID = id}
            contact.Read()
            Return contact
        End Function

        ' POST: api/User
        Public Sub PostContact(<FromBody()> contact As clsContact)
            contact.Update()
        End Sub

        ' PUT: api/User/5
        Public Sub PutContact(ByVal id As Guid, <FromBody()> ByVal contact As clsContact)
            contact.ID = id
            contact.CanInsert = False

            contact.Update()
        End Sub

    End Class
End Namespace