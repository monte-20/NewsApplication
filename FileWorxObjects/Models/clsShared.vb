Imports System.Windows.Forms

Public Class clsShared

    Public Shared Function Seperator() As String

        Return "%%$$##"
    End Function

    Public Shared Function UserPath() As String

        '"G:\Visual Studio\Visual Basic\NewsTask1\Data\Users\"
        Return Application.StartupPath & "\Data\Users\"
    End Function

    Public Shared Function NewsPath() As String

        '"G:\Visual Studio\Visual Basic\NewsTask1\Data\News\"
        Return Application.StartupPath & "\Data\News\"
    End Function

    Public Shared Function PhotosPath() As String
        '"G:\Visual Studio\Visual Basic\NewsTask1\Data\Photos\"
        Return Application.StartupPath & "\Data\Photos\"

    End Function



End Class
