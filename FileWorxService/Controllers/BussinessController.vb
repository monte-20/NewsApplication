Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class BussinessController
        Inherits ApiController

        <HttpPost>
        Public Function BussinessItems(<FromBody()> filter As clsBussinessFilter) As clsListView
            Dim bussiness As New clsBussinessQuery
            With bussiness
                .filter = filter
            End With
            Dim bussinessData = bussiness.ListLoad
            Return bussinessData
        End Function

        Public Sub DeleteItem(ByVal id As Guid)
            Dim bussinessItem As New clsBussiness With {.ID = id}
            bussinessItem.Delete()
        End Sub
    End Class
End Namespace