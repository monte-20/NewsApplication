Imports System.Net
Imports System.Web.Http
Imports Newtonsoft.Json

Namespace Controllers
    Public Class UserController
        Inherits ApiController

        <HttpPost>
        Public Function Users(<FromBody()> filter As clsBussinessFilter) As clsListView
            Dim items As New clsUserQuery
            With items
                .filter = filter
            End With
            Dim usersData = items.ListLoad

            Return usersData
        End Function

        Public Function GetUser(id As Guid) As ClsUser
            Dim item As New ClsUser With {.ID = id}
            item.Read()
            Return item
        End Function

        ' POST: api/User
        Public Sub PostUser(<FromBody()> user As ClsUser)
            user.Update()
        End Sub

        ' PUT: api/User/5
        Public Sub PutUser(ByVal id As Guid, <FromBody()> ByVal user As ClsUser)
            user.ID = id
            user.Update()
        End Sub

    End Class
End Namespace