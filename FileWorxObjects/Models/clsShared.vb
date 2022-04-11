Imports System.Windows.Forms

Public Class clsShared

    Public Shared Function Seperator() As String

        Return "%%$$##"
    End Function

    Public Shared Function UserPath() As String
        Return Application.StartupPath & "\Data\Users\"
    End Function

    Public Shared Function NewsPath() As String
        Return Application.StartupPath & "\Data\News\"
    End Function

    Public Shared Function PhotosPath() As String
        Return Application.StartupPath & "\Data\Photos\"
    End Function



End Class
