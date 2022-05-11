Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class FileController
        Inherits ApiController

        <HttpPost>
        Public Function Files(<FromBody()> filter As clsFileFilter) As clsListView
            Dim items As New clsFileQuery
            With items
                .filter = filter
            End With
            Dim filesData = items.ListLoad

            Return filesData
        End Function



    End Class
End Namespace