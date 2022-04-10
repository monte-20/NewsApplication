Imports System.Data.SqlClient

Public Class clsDBConnectionManager
    Public Shared Sub ExecuteNonQuery(command As SqlCommand)
        Using con As New SqlConnection("Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;")
            Using command
                With command
                    .Connection = con
                End With
                Try
                    con.Open()
                    command.ExecuteNonQuery()
                Catch ex As SqlException
                    Debug.Print(ex.Message.ToString())
                End Try
            End Using
        End Using
    End Sub

    Public Shared Sub ReadData(command As SqlCommand, ByRef data(,) As String)
        Using con As New SqlConnection("Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;")
            Using command
                With command
                    .Connection = con
                End With
                con.Open()
                Using reader As SqlDataReader = command.ExecuteReader
                    Dim row As Integer = 0
                    Do While reader.Read()
                        For column = 0 To reader.FieldCount - 1
                            data(row, column) = Convert.ToString(reader.GetValue(column))
                        Next
                        row += 1
                    Loop
                End Using
            End Using
        End Using
    End Sub
End Class
