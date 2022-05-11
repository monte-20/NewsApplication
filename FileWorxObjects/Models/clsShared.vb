Imports System.Windows.Forms

Public Class clsShared

    Public Shared Function PhotosPath() As String
        Return Application.StartupPath & "\Data\Photos\"
    End Function

End Class
