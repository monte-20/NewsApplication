Imports System.Data.SqlClient

Public Class clsDBConnectionManager

    Private Shared ReadOnly ConnectionString As String = "Initial Catalog=FileWorx;" &
        "Data Source=localhost;Integrated Security=SSPI;"
    Public Sub ExecuteNonQuery(command As SqlCommand)
        Using con As New SqlConnection(ConnectionString)
            command.Connection = con
            Try
                con.Open()
                command.ExecuteNonQuery()
            Catch ex As SqlException
                Debug.Print(ex.Message.ToString())
            End Try
        End Using
    End Sub

    Public Sub ReadData(command As SqlCommand, ByRef data(,) As String)
        Using con As New SqlConnection(ConnectionString)
            command.Connection = con
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
    End Sub
End Class
